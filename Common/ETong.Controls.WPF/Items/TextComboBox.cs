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
	 
	public class TextComboBox : ComboBox
	{
		static TextComboBox()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(TextComboBox), new FrameworkPropertyMetadata(typeof(TextComboBox)));
		}

		TextBox PART_EditableTextBox = null;
		Button PART_CloseButton = null;

		public object Header
		{
			get { return (object)GetValue(HeaderProperty); }
			set { SetValue(HeaderProperty, value); }
		}
		public static readonly DependencyProperty HeaderProperty =
			DependencyProperty.Register("Header", typeof(object), typeof(TextComboBox), new UIPropertyMetadata(null));

		public string HeaderStringFormat
		{
			get { return (string)GetValue(HeaderStringFormatProperty); }
			set { SetValue(HeaderStringFormatProperty, value); }
		}
		public static readonly DependencyProperty HeaderStringFormatProperty =
			DependencyProperty.Register("HeaderStringFormat", typeof(string), typeof(TextComboBox), new UIPropertyMetadata(null));

		public DataTemplate HeaderTemplate
		{
			get { return (DataTemplate)GetValue(HeaderTemplateProperty); }
			set { SetValue(HeaderTemplateProperty, value); }
		}
		public static readonly DependencyProperty HeaderTemplateProperty =
			DependencyProperty.Register("HeaderTemplate", typeof(DataTemplate), typeof(TextComboBox), new UIPropertyMetadata(null));

		public DataTemplateSelector HeaderTemplateSelector
		{
			get { return (DataTemplateSelector)GetValue(HeaderTemplateSelectorProperty); }
			set { SetValue(HeaderTemplateSelectorProperty, value); }
		}
		public static readonly DependencyProperty HeaderTemplateSelectorProperty =
			DependencyProperty.Register("HeaderTemplateSelector", typeof(DataTemplateSelector), typeof(TextComboBox), new UIPropertyMetadata(null));

		public double HeaderWidth
		{
			get { return (double)GetValue(HeaderWidthProperty); }
			set { SetValue(HeaderWidthProperty, value); }
		}
		public static readonly DependencyProperty HeaderWidthProperty =
			DependencyProperty.Register("HeaderWidth", typeof(double), typeof(TextComboBox), new UIPropertyMetadata(0.0));




		public double MaxDropDownWidth
		{
			get { return (double)GetValue(MaxDropDownWidthProperty); }
			set { SetValue(MaxDropDownWidthProperty, value); }
		}

		// Using a DependencyProperty as the backing store for MaxDropDownWidth.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MaxDropDownWidthProperty =
			DependencyProperty.Register("MaxDropDownWidth", typeof(double), typeof(TextComboBox), new UIPropertyMetadata(Double.PositiveInfinity));




		public Style EditBoxStyle
		{
			get { return (Style)GetValue(EditBoxStyleProperty); }
			set { SetValue(EditBoxStyleProperty, value); }
		}

		// Using a DependencyProperty as the backing store for EditBoxStyle.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty EditBoxStyleProperty =
			DependencyProperty.Register("EditBoxStyle", typeof(Style), typeof(TextComboBox), new UIPropertyMetadata(null));



		public Style  CloseButtonStyle
		{
			get { return (Style )GetValue(CloseButtonStyleProperty); }
			set { SetValue(CloseButtonStyleProperty, value); }
		}

		// Using a DependencyProperty as the backing store for CloseButtonStyle.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty CloseButtonStyleProperty =
			DependencyProperty.Register("CloseButtonStyle", typeof(Style ), typeof(TextComboBox), new UIPropertyMetadata(null));




        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            this.PART_EditableTextBox = this.GetTemplateChild("PART_EditableTextBox") as TextBox;
            if (this.PART_EditableTextBox != null)
            {
                //this.PART_EditableTextBox.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(PART_EditableTextBox_GotKeyboardFocus);
                //this.PART_EditableTextBox.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(PART_EditableTextBox_LostKeyboardFocus);
                this.PART_EditableTextBox.PreviewMouseUp += new MouseButtonEventHandler(PART_EditableTextBox_PreviewMouseUp);
            }
            this.PART_CloseButton = this.GetTemplateChild("PART_CloseButton") as Button;
            if (this.PART_CloseButton != null)
            {
                this.PART_CloseButton.Click += new RoutedEventHandler(PART_CloseButton_Click);
            }
            this.SelectionChanged += new SelectionChangedEventHandler(HeaderComboBox_SelectionChanged);
        }

        void PART_EditableTextBox_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            this.IsDropDownOpen = true;
        }

        void HeaderComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.IsDropDownOpen = false;
        }

		void PART_CloseButton_Click(object sender, RoutedEventArgs e)
		{
			this.IsDropDownOpen = false;
		}

        //void PART_EditableTextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        //{
			 
        //}

        //void PART_EditableTextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        //{
        //    this.IsDropDownOpen = true;
        //}

		protected override void OnDropDownClosed(EventArgs e)
		{
			base.OnDropDownClosed(e);
			Keyboard.ClearFocus();
		} 
	}
}
