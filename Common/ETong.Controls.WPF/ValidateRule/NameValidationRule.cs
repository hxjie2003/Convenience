using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace ETong.Controls.WPF
{
    public class NameValidationRule:ValidationRule
    {
        public string Message { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string valuestring = string.Empty;
            if (value != null) valuestring = value.ToString();
            if (valuestring == "")
            {
                return new ValidationResult(false, "姓名不能为空！");
            }            
            if (valuestring.Length < 2 || valuestring.Length > 18)
            {
                return new ValidationResult(false,"输入姓名不规范:姓名长度必须为2到18位");
            }
            Regex digitregex = new Regex(@"\d");
            if (digitregex.IsMatch(valuestring))
            {             
                return new ValidationResult(false,"输入姓名不规范:不能输入数字");             
            }
            return ValidationResult.ValidResult;
        }
    }
}
