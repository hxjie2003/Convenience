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

namespace ETong.Controls.WPF
{
    /// <summary>
    /// MessageWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MessageWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();

        private TimeSpan timePass = TimeSpan.Zero;

        private TimeSpan closeTimeout;

        public TimeSpan CloseTimeout
        {
            get { return this.closeTimeout; }

            set { closeTimeout = value; }
        }
        public MessageWindow()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            //this.Owner = App.Current.MainWindow;

            //新增代码
            this.Loaded += new RoutedEventHandler(MessageWindow_Loaded);

            this.Unloaded += new RoutedEventHandler(MessageWindow_Unloaded);

            timer.Interval = TimeSpan.FromSeconds(1);

            timer.Tick += new EventHandler(Timer_Tick);
        }

        void MessageWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        void MessageWindow_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            timePass += TimeSpan.FromSeconds(1);
            if (this.CloseTimeout != TimeSpan.Zero && timePass > CloseTimeout)
            {
                this.DialogResult = true;
            }

            //有设置倒计时的话，显示倒计时
            if (this.CloseTimeout != TimeSpan.Zero)
            {
                runCountdown.Text = (this.CloseTimeout.TotalSeconds - timePass.TotalSeconds).ToString();
            }
        }

        public bool? ShowDialog(string warninginfo, string question, TimeSpan seconds)
        {
            this.tbInfo.Text = warninginfo;

            this.tbShowMsg.Text = question;

            closeTimeout = seconds;

            //有设置倒计时的话，显示倒计时
            if (closeTimeout != TimeSpan.Zero)
            {
                runCountdown.Text = (closeTimeout.TotalSeconds - timePass.TotalSeconds).ToString();
                txbCountdown.Visibility = Visibility.Visible;
            }

            return this.ShowDialog();
        }

        public bool? ShowDialog(string warninginfo,string question)
        {
            this.tbInfo.Text = warninginfo;
            this.tbShowMsg.Text = question;
            return this.ShowDialog();
        }
        

        //private void newTbNo_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    this.DialogResult = false;
        //}

        //private void newTbOk_MouseUp(object sender, MouseButtonEventArgs e)
        //{
        //    this.DialogResult = true;
        //}

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
