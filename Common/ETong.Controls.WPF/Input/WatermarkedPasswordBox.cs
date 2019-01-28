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

namespace ETong.Controls.WPF
{
    public class WatermarkedPasswordBox : TextBox
    {
        ContentControl WatermarkContent;
        private PasswordBox PasswordContent;

        public object Watermark
        {
            get { return base.GetValue(WatermarkProperty) as object; }
            set { base.SetValue(WatermarkProperty, value); }
        }
        public static readonly DependencyProperty WatermarkProperty =
        DependencyProperty.Register("Watermark", typeof(object), typeof(WatermarkedPasswordBox), new PropertyMetadata(OnWatermarkPropertyChanged));

        private static void OnWatermarkPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            //WatermarkedPasswordBox watermarkTextBox = sender as WatermarkedPasswordBox;
            //if (watermarkTextBox != null && watermarkTextBox.WatermarkContent != null)
            //{
            //    watermarkTextBox.DetermineWatermarkContentVisibility();
            //}
            
        }

        public Style WatermarkStyle
        {
            get { return base.GetValue(WatermarkStyleProperty) as Style; }
            set { base.SetValue(WatermarkStyleProperty, value); }
        }
        public static readonly DependencyProperty WatermarkStyleProperty =
        DependencyProperty.Register("WatermarkStyle", typeof(Style), typeof(WatermarkedPasswordBox), null);

        public WatermarkedPasswordBox()
        {
            DefaultStyleKey = typeof(WatermarkedPasswordBox);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.WatermarkContent = this.GetTemplateChild("watermarkContent") as ContentControl;
            this.PasswordContent = this.GetTemplateChild("ContentElement") as PasswordBox;

            if (WatermarkContent != null && PasswordContent != null)
            {
                PasswordContent.PasswordChanged += new RoutedEventHandler(PasswordContent_PasswordChanged);
                //DetermineWatermarkContentVisibility();
            }
        }

        void PasswordContent_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwdBx = sender as PasswordBox;
            this.Text = passwdBx.Password;
        }

        //protected override void OnGotFocus(RoutedEventArgs e)
        //{
        //    if (WatermarkContent != null && PasswordContent != null && string.IsNullOrEmpty(this.PasswordContent.Password))
        //    {
        //        this.WatermarkContent.Visibility = Visibility.Collapsed;
        //    }
        //    base.OnGotFocus(e);
        //}

        //protected override void OnLostFocus(RoutedEventArgs e)
        //{
        //    if (WatermarkContent != null && PasswordContent != null && string.IsNullOrEmpty(this.PasswordContent.Password))
        //    {
        //        this.WatermarkContent.Visibility = Visibility.Visible;
        //    }
        //    base.OnLostFocus(e);
        //}

        //private void DetermineWatermarkContentVisibility()
        //{
        //    if (string.IsNullOrEmpty(this.PasswordContent.Password))
        //    {
        //        this.WatermarkContent.Visibility = Visibility.Visible;
        //    }
        //    else
        //    {
        //        this.WatermarkContent.Visibility = Visibility.Collapsed;
        //    }
        //}  
    }
}
