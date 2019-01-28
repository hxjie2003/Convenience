using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace ETong.Controls.WPF
{
	/// <summary>
	/// bool类型到Visibility的转换器
	/// </summary>
    public	class BoolToVisibilityConverter:IValueConverter
	{
		/// <summary>
		/// 当绑定源为何值时需要显示
		/// </summary>
		public bool ShowValue { get; set; }

		private Visibility _HideValue = Visibility.Hidden;
		/// <summary>
		/// 当不需要显示时。是折叠或是隐藏
		/// </summary>
		public Visibility HideValue 
		{
			get { return _HideValue; }
			set 
			{
				if (_HideValue!=value)
				{
					if (value == Visibility.Visible) //
					{
						throw new System.Exception("值无效");
					}
					_HideValue = value;					
				}
			}
		}

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			 
			bool boolValue = System.Convert.ToBoolean(value);
			if (boolValue == ShowValue)
			{
				return Visibility.Visible;
			}
			else
				return this.HideValue;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
            return null;
		}
	}
}
