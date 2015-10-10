using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Gss.Entities.ValidationHelper
{
    /// <summary>
    /// 数字验证验证
    /// </summary>
    public class NumRule : ValidationRule
    {
        public NumRule()
        {
            MaxValue = null;
        }
        private double? maxValue;
        /// <summary>
        /// 最大值
        /// </summary>
        public double? MaxValue
        {
            get { return maxValue; }
            set { maxValue = value; }
        }

        private bool isInteger=true;
        /// <summary>
        /// 是否整数验证(默认为整数验证)
        /// </summary>
        public bool IsInteger
        {
            get { return isInteger; }
            set { isInteger = value; }
        }

        private bool _canMinus=false;
        /// <summary>
        /// 能否输入负数,默认不能输入负数
        /// </summary>
        public bool CanMinus
        {
            get { return _canMinus; }
            set { _canMinus = value; }
        }
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string str = value.ToString();
            if (IsInteger)//整数
            {
                int i;
                if (!int.TryParse(str, out i))
                    return new ValidationResult(false, "必须输入整数");
               
                Regex regex = new Regex(@"^[0-9]*$");
                if (!CanMinus&&i<0)
                {
                    return new ValidationResult(false, "不能输入负数");
                }
                if (!regex.IsMatch(Math.Abs(i).ToString()))
                    return new ValidationResult(false, "必须为整数");
                else if (MaxValue != null&&i>MaxValue)
                {
                    return new ValidationResult(false, string.Format("您输入的数字不能大于{0}",MaxValue));
                }
                else
                    return new ValidationResult(true, null);
            }
            else//浮点数验证
            {
                double i;
                if (!double.TryParse(str, out i))
                    return new ValidationResult(false, "必须为数字");
               
                if (!CanMinus&&i < 0)
                {
                    return new ValidationResult(false, "必须为正数");
                }
                else if (MaxValue != null && i > MaxValue)
                {
                    return new ValidationResult(false, string.Format("您输入的数字不能大于{0}", MaxValue));
                }
                else
                    return new ValidationResult(true, null);
            }

        }

    }
}
