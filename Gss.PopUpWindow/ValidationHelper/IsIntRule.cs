using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Gss.PopUpWindow.ValidationHelper
{
    public class IsIntRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                string str = value.ToString();
                int i = System.Convert.ToInt32(str);
                return new ValidationResult(true, null);
            }
            catch (Exception)
            {

                return new ValidationResult(true, "必须为整数");
            }
        }
    }
}
