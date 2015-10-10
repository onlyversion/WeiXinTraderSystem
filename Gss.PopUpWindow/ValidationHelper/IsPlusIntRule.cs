using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Gss.PopUpWindow.ValidationHelper
{
    public class IsPlusIntRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                string str = value.ToString();
                int i = System.Convert.ToInt32(str);
                if (i< 0)
                {
                    return new ValidationResult(false, "必须为正整数");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
               
            }
            catch (Exception)
            {

                return new ValidationResult(false, "必须为正整数");
            }
        }
    }
}
