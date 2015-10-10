using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Gss.Entities.ValidationHelper
{
    /// <summary>
    /// IP地址验证
    /// </summary>
    public class IPAddressRule : ValidationRule
    {
      
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string str = (string)value;
            if(String.IsNullOrEmpty(str))
                return new ValidationResult(false, "IP地址必须输入");
            Regex regex = new Regex(@"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");

            if (!regex.IsMatch(str))
                return new ValidationResult(false, "请输入正确的正则表达式");
            else
                return new ValidationResult(true, null);

        }

    }
}
