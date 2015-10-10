using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Gss.Entities.ValidationHelper
{
    /// <summary>
    /// 身份证验证规则
    /// </summary>
   public class CertificateNumberRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string number = (string)value;

            if (string.IsNullOrEmpty(number))
                return new ValidationResult(false, "该值不能为空");
            if (number.Length != 15 && number.Length != 18)
                return new ValidationResult(false, "身份证号码为15位或18位");
            else
                return new ValidationResult(true, null);

            ////string number = (string)value;

            ////if (string.IsNullOrEmpty(number))
            ////    return new ValidationResult(false, "该值不能为空");
            ////if (number.Length != 15 && number.Length != 18)
            ////    return new ValidationResult(false,"身份证号码为15位或18位");
            //////身份证正则表达式(15位) 
            //// string IDCard1=@"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$"; 
            //////身份证正则表达式(18位) 
            ////string IDCard2=@"^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{4}$"; 

            ////Regex regex ;
            ////if (number.Length == 15)
            ////    regex = new Regex(IDCard1);
            ////else
            ////    regex = new Regex(IDCard2);
            ////Match match = regex.Match(number);
            ////if (match.Success)
            ////    return new ValidationResult(true, null);
            ////else
            ////    return new ValidationResult(false, "身份证格式不正确");
        }
    }
}
