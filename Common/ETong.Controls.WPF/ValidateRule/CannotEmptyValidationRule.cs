using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace ETong.Controls.WPF
{
    public class CannotEmptyValidationRule : ValidationRule
    {
        public string Message { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string valuestring = string.Empty;
            if (value != null) valuestring = value.ToString();
            if (valuestring == "")
            {
                return new ValidationResult(false, Message);
            }
            return ValidationResult.ValidResult;
        }
    }
}
