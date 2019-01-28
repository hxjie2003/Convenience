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
    public class WateMarkTextBox : TextBox
    {
        private Label wateMarkLable;

        private ScrollViewer wateMarkScrollViewer;

        static WateMarkTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WateMarkTextBox), new FrameworkPropertyMetadata(typeof(WateMarkTextBox)));
        }
 


        public string WateMark
        {
            get { return (string)GetValue(WateMarkProperty); }

            set { SetValue(WateMarkProperty, value); }
        }

        public static DependencyProperty WateMarkProperty =
            DependencyProperty.Register("WateMark", typeof(string), typeof(WateMarkTextBox), new UIPropertyMetadata("水印"));


      
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.wateMarkLable = this.GetTemplateChild("TextPrompt") as Label;

            this.wateMarkScrollViewer = this.GetTemplateChild("PART_ContentHost") as ScrollViewer;
        }
    }
}
