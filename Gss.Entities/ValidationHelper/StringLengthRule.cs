using System.Windows.Controls;

namespace Gss.Entities.ValidationHelper {
    public class StringLengthRule : ValidationRule {
        private int _minLength = 0;

        /// <summary>
        /// 获取或设置最小长度，默认值为0
        /// </summary>
        public int MinLength {
            get { return _minLength; }
            set { _minLength = value; }
        }

        private int _maxLength = int.MaxValue;

        /// <summary>
        /// 获取或设置最大长度
        /// </summary>
        public int MaxLength {
            get { return _maxLength; }
            set { _maxLength = value; }
        }

        public override ValidationResult Validate( object value, System.Globalization.CultureInfo cultureInfo ) {
            string str = ( string )value;

            if (string.IsNullOrEmpty(str))
            {
                if (this.MinLength != 0)
                {
                    return new ValidationResult(false, "该值不能为空");
                }
                else
                {
                    return new ValidationResult(true, null);
                }
               
            }

            else
            {
                if (str.Length < MinLength || str.Length > MaxLength)
                {
                    return new ValidationResult(false, string.Format("输入长度必须介于{0}和{1}之间", MinLength, MaxLength));
                }
                else
                {
                    return new ValidationResult(true, null);
                }
            }
            }
            
    }
}
