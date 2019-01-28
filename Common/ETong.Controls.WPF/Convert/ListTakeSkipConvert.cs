using System;
using System.Text;
using System.Windows.Data;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ETong.Controls.WPF
{
    public class ListTakeSkipConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter == null)
                return value;

            string par = parameter.ToString();

            if (string.IsNullOrEmpty(par))
                return value;

            string[] pars = par.Split(',');

            IEnumerable<object> list = value as IEnumerable<object>;

            if (list == null)
                return value;

            IEnumerable<object> result = list;
            if (pars.Length > 0)
            {
                int i =0;

                if (int.TryParse(pars[0], out i)) 
                {
                    result = result.Skip(i);
                }

                if (pars.Length > 1)
                {
                    if (int.TryParse(pars[1], out i))
                    {
                        result = result.Take(i);
                    }
                }
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
