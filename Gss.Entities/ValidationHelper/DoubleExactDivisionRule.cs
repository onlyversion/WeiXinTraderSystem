using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Gss.Entities.ValidationHelper
{
    public class DoubleExactDivisionRule : ValidationRule
    {
        public DoubleExactDivisionRule()
        {
            this.Dividend = 1d;
            MinValue = null;
            MaxValue = null;
        }
        public double Dividend { get; set; }

        public double? MinValue { get; set; }
        public double? MaxValue { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                string str = value.ToString();
                int w1 = 0;
                int w2 = 0;
                if (str.Contains("."))
                {
                    w1 = str.Length - str.LastIndexOf(".") - 1;
                }
                if (Dividend.ToString().Contains("."))
                {
                    w2 = Dividend.ToString().Length - Dividend.ToString().LastIndexOf(".") - 1;
                }
                int y1 = (int)Math.Pow(10, w1);
                int y2 = (int)Math.Pow(10, w2);
                int y3 = y1 > y2 ? y1 : y2;

                double d = System.Convert.ToDouble(str);
                if ((int)(d*y3) % (int)(Convert.ToDouble(Dividend.ToString())*y3) != 0)
                {
                    return new ValidationResult(false, string.Format("数值必须是{0}的倍数", this.Dividend));
                }
                else if (MinValue != null && d < MinValue)
                {
                    return new ValidationResult(false, string.Format("数值必须大于{0}", this.MinValue));
                }
                else if (MaxValue != null && d > MaxValue)
                {
                    return new ValidationResult(false, string.Format("数值必须小于{0}", this.MaxValue));
                } 
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            catch (Exception)
            {

                return new ValidationResult(false, string.Format("错误数据"));
            }

        }
    }
}
