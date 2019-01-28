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

    public class ImageButton : Button
    {
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        public ImageSource IconNormal
        {
            get { return (ImageSource)GetValue(IconNormalProperty); }
            set { SetValue(IconNormalProperty, value); }
        }

        public static readonly DependencyProperty IconNormalProperty =
            DependencyProperty.Register("IconNormal", typeof(ImageSource), typeof(ImageButton), new UIPropertyMetadata(null));


        public ImageSource IconPress
        {
            get { return (ImageSource)GetValue(IconPressProperty); }
            set { SetValue(IconPressProperty, value); }
        }

        public static readonly DependencyProperty IconPressProperty =
            DependencyProperty.Register("IconPress", typeof(ImageSource), typeof(ImageButton), new UIPropertyMetadata(null));
        

        public ImageSource IconDisabled
        {
            get { return (ImageSource)GetValue(IconDisabledProperty); }
            set { SetValue(IconDisabledProperty, value); }
        }
        public static readonly DependencyProperty IconDisabledProperty =
            DependencyProperty.Register("IconDisabled", typeof(ImageSource), typeof(ImageButton), new UIPropertyMetadata(null));


    }
}
