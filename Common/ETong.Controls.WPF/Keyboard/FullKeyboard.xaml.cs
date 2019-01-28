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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ETong.Controls.WPF
{
    /// <summary>
    /// 全键盘
    /// </summary>
    public partial class FullKeyboard : UserControl
    {
        public event RoutedEventHandler CloseClick;
        public event Func<string> OnGetDisplayValue;

        //输入框的标题
        public string KeyboradInputTitle
        {
            set
            {
                this.displayValueTitle.Text = value;
            }
        }

        private DispatcherTimer timer = null;

        private bool _IsPinyinInput = false;
        /// <summary>
        /// 是否处于拼音输入法
        /// </summary>
        public bool IsPinyinInput
        {
            get
            {
                return this._IsPinyinInput;
            }
            set
            {
                if(this._IsPinyinInput != value)
                {
                    this._IsPinyinInput = value;
                    if (this._IsPinyinInput)
                    {
                        this.writerpad.Style = this.FindResource("PinyinPadStyle") as Style;
                        BtnPinyin.Content = "手写";
                    }
                    else
                    {
                        this.writerpad.Style = this.FindResource("WriterPadKeyboardStyle") as Style;
                        BtnPinyin.Content = "拼音";
                    }
                }
            }
        }

        public FullKeyboard()
        {
            InitializeComponent();

            this.LoadKeyboardType = KeyboardType.Full;

            this.Loaded += new RoutedEventHandler(FullKeyboard_Loaded);
            //this.Unloaded += new RoutedEventHandler(FullKeyboard_Unloaded);
            this.IsVisibleChanged += new DependencyPropertyChangedEventHandler(FullKeyboard_IsVisibleChanged);
        }

        void FullKeyboard_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                this.FullKeyboardPanel.Visibility = System.Windows.Visibility.Collapsed;
                this.NumberKeyboardPanel.Visibility = System.Windows.Visibility.Collapsed;
                this.SymbolKeyboardPanel.Visibility = System.Windows.Visibility.Collapsed;

                switch (this.LoadKeyboardType)
                {
                    case KeyboardType.Full:
                        this.FullKeyboardPanel.Visibility = System.Windows.Visibility.Visible;
                        break;
                    case KeyboardType.Number:
                        this.NumberKeyboardPanel.Visibility = System.Windows.Visibility.Visible;
                        break;
                    case KeyboardType.Symbol:
                        this.SymbolKeyboardPanel.Visibility = System.Windows.Visibility.Visible;
                        break;
                }

                this.LoadKeyboardType = KeyboardType.Full;

                if (this.timer != null && !this.timer.IsEnabled)
                {
                    timer.Tick += new EventHandler(timer_Tick);
                    this.timer.Start();
                }

                //恢复正常状态
                IsPinyinInput = false;
                resetInputStatus();
            }
            else
            {
                if (this.timer != null)
                {
                    timer.Tick -= new EventHandler(timer_Tick);
                    this.timer.Stop();
                }
            }
        }

        private void FullKeyboard_Loaded(object sender, RoutedEventArgs e)
        {
            this.displayValueTextBox.Text = string.Empty;
            //this.displayValueTitle.Text = string.Empty;
            if (timer == null)
            {
                timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 0, 0, 300);
            }
        }

        private void FullKeyboard_Unloaded(object sender, RoutedEventArgs e)
        {
            if (this.timer != null)
                this.timer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                if (this.OnGetDisplayValue != null)
                    this.displayValueTextBox.Text = this.OnGetDisplayValue();
            }), null);
        }

        public void SetHwnd(IntPtr hwnd)
        {
            this.letterpad.HWD = hwnd;
            this.writerpad.HWD = hwnd;
            this.numberpad.HWD = hwnd;
            this.symbolberpad.HWD = hwnd;
        }

        #region 键盘操作

        private void letter_Checked(object sender, RoutedEventArgs e)
        {
            if (this.letterpad != null && this.writerpad != null)
            {
                this.letterpad.Visibility = Visibility.Visible;
                this.writerpad.Visibility = Visibility.Collapsed;
            }
        }

        private void writer_Checked(object sender, RoutedEventArgs e)
        {
            if (this.letterpad != null && this.writerpad != null)
            {
                this.letterpad.Visibility = Visibility.Collapsed;
                this.writerpad.Visibility = Visibility.Visible;
            }
        }

        private void btnCloseKeyboard_Click(object sender, RoutedEventArgs e)
        {
            if (this.CloseClick != null)
                this.CloseClick(sender, e);
        }

        #endregion

        private void SymbolKey_Click(object sender, RoutedEventArgs e)
        {
            this.FullKeyboardPanel.Visibility = System.Windows.Visibility.Collapsed;
            this.NumberKeyboardPanel.Visibility = System.Windows.Visibility.Collapsed;
            this.SymbolKeyboardPanel.Visibility = System.Windows.Visibility.Visible;
        }

        private void NumberKey_Click(object sender, RoutedEventArgs e)
        {
            this.FullKeyboardPanel.Visibility = System.Windows.Visibility.Collapsed;
            this.NumberKeyboardPanel.Visibility = System.Windows.Visibility.Visible;
            this.SymbolKeyboardPanel.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void FullKey_Click(object sender, RoutedEventArgs e)
        {
            this.FullKeyboardPanel.Visibility = System.Windows.Visibility.Visible;
            this.NumberKeyboardPanel.Visibility = System.Windows.Visibility.Collapsed;
            this.SymbolKeyboardPanel.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void BtnPinyin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                btn.Content = btn.Content.ToString() == "手写" ? "拼音" : "手写";
                IsPinyinInput = btn.Content.ToString() == "手写";

                resetInputStatus();
            }
            catch(Exception ex)
            {
                //简单提示
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 重置输入状态，或为手写，或为拼音初始状态
        /// </summary>
        private void resetInputStatus()
        {
            this.writerpad.IsPinyinInput = IsPinyinInput;
            this.letterpad.IsPinyinInput = IsPinyinInput;
            if (IsPinyinInput)
            {
                if (this.letterpad.PinyinControl == null)
                    this.letterpad.PinyinControl = this.writerpad;
                if (this.writerpad.PinyinControl == null)
                    this.writerpad.PinyinControl = this.letterpad;
            }
            else
            {
                if (this.letterpad.PinyinControl != null)
                    this.letterpad.PinyinControl = null;
            }

            this.writerpad.ResetInputStatus();
        }

        public KeyboardType LoadKeyboardType { get; set; }

        public enum KeyboardType
        {
            Full,
            Number,
            Symbol
        }
         
        private bool _IsOpen = false;
        /// <summary>
        /// 关闭打开，标示
        /// </summary>
        public bool IsOpen {
            set {
                _IsOpen = value;
                if (!value) {
                    //关闭
                    this.letterpad.CloseHoldKey();
                    this.writerpad.CloseHoldKey();
                }
            }
            get {
                return _IsOpen;
            }
        }

    }
}
