using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Gss.PopUpWindow.ValidationHelper
{
    public class IsDoubleRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                double d = System.Convert.ToDouble(value);
                return new ValidationResult(true, null);
            }
            catch (Exception)
            {

                return new ValidationResult(false, "输入必须为数字");
            }
        }
    }
}
