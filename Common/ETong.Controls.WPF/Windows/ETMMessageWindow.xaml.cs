using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace ETong.Controls.WPF
{
	/// <summary>
	/// MessageWindiw.xaml 的交互逻辑
	/// </summary>
	public partial class ETMMessageWindow : Window
	{
		public ETMMessageWindow()
		{
			InitializeComponent();
			this.Loaded += new RoutedEventHandler(ETMMessageWindow_Loaded);
			this.Unloaded += new RoutedEventHandler(ETMMessageWindow_Unloaded);
			this._timer.Tick += new EventHandler(timer_Tick);
			this._timer.Interval = TimeSpan.FromSeconds(1);

		}

		void ETMMessageWindow_Unloaded(object sender, RoutedEventArgs e)
		{
			this._timer.Stop();
			
		} 
		void ETMMessageWindow_Loaded(object sender, RoutedEventArgs e)
		{
			this._timer.Start();
		}


		void timer_Tick(object sender, EventArgs e)
		{
			 
			_timePass += this.TimeInterval;

			//如果closeTimeout==零，则不需要关闭
			if (this.CloseTimeout!=TimeSpan.Zero && this._timePass > this.CloseTimeout)
			{
				this.StartUnLoadStoryboard();
			}
		}

		DispatcherTimer _timer = new DispatcherTimer();
		TimeSpan _timePass = TimeSpan.Zero;
		/// <summary>
		/// 关闭窗口等待的时间间隔
		/// </summary>
		public TimeSpan CloseTimeout { get; set; }
		/// <summary>
		/// 检测时间的频率
		/// </summary>
		public TimeSpan TimeInterval 
		{
			get { return this._timer.Interval; }
			set { this._timer.Interval = value; }
		}

		private bool _IsHappy;
		public bool IsHappy //是否显示笑脸
		{
			get { return _IsHappy; }
			set
			{
				if (_IsHappy != value)
				{
					_IsHappy = value;
					if (_IsHappy)
					{
						this.imgGood.Visibility = System.Windows.Visibility.Visible;
						this.imgBad.Visibility = System.Windows.Visibility.Hidden;
					}
					else
					{
						this.imgGood.Visibility = System.Windows.Visibility.Hidden;
						this.imgBad.Visibility = System.Windows.Visibility.Visible;
					}
				}
			}
		}


		/// <summary>
		/// 错误信息
		/// </summary>
		public string Message 
		{
			get { return this.txtMessage.Text; }
			set { this.txtMessage.Text = value; }
		}

		private void btnOK_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
			//this.StartUnLoadStoryboard();
		}

		public static void ShowMessage(string message)
		{
			ETMMessageWindow wnd = new ETMMessageWindow()
			{
				Message = message,
				 
			};
			wnd.ShowDialog();
		}

		public static void ShowMessage(string message, TimeSpan closeTimeout )
		{
			ETMMessageWindow wnd = new ETMMessageWindow()
			{
				Message = message,
				CloseTimeout = closeTimeout, 
			};
			wnd.ShowDialog();
		}



		public static void ShowMessage(string message,bool isHappy=false) 
		{
			ETMMessageWindow wnd = new ETMMessageWindow() 
			{
				Message =  message,
				IsHappy = isHappy,
			};
			wnd.ShowDialog();
		}

		public static void ShowMessage(string message, TimeSpan closeTimeout, bool isHappy = false) 
		{
			ETMMessageWindow wnd = new ETMMessageWindow()
			{
				Message = message,
				CloseTimeout= closeTimeout,
				IsHappy=  isHappy,
			};
			wnd.ShowDialog();
		}


		void StartUnLoadStoryboard() 
		{
			Storyboard storyBoard = this.FindResource("UnLoadStoryboard") as Storyboard;
			if (storyBoard != null)
			{
				storyBoard.Begin();
			}
		}
		private void UnLoadStoryboard_Completed(object sender, EventArgs e)
		{
			this.Close();
		}


	}
}
