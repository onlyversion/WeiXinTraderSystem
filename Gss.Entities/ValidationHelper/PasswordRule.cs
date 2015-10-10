using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Gss.Entities.ValidationHelpers
{
    /// <summary>
    /// 密码验证规则
    /// </summary>
    public class PasswordRule : ValidationRule
    {
        private int _minLength = 0;

        /// <summary>
        /// 获取或设置最小长度，默认值为0
        /// </summary>
        public int MinLength
        {
            get { return _minLength; }
            set { _minLength = value; }
        }

        private int _maxLength = int.MaxValue;

        /// <summary>
        /// 获取或设置最大长度
        /// </summary>
        public int MaxLength
        {
            get { return _maxLength; }
            set { _maxLength = value; }
        }

        //private string _otherPassword;
        ///// <summary>
        ///// 比对密码
        ///// </summary>
        //public string OtherPassword
        //{
        //    get { return _otherPassword; }
        //    set { _otherPassword = value; }
        //}

        ////比对密码
        //public static readonly DependencyProperty OtherPasswordProperty =
        //    DependencyProperty.Register("OtherPassword", typeof(string), typeof(PasswordRule), new UIPropertyMetadata(string.Empty));

        ///// <summary>
        ///// 客户账号
        ///// </summary>
        //public string OtherPassword
        //{
        //    get { return OtherPasswordProperty }
        //    set { OtherPasswordProperty = value; }
        //}

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            string str = (string)value;

            if (string.IsNullOrEmpty(str))
                return new ValidationResult(false, "该值不能为空");

            if (str.Length < MinLength || str.Length > MaxLength)
            {
                return new ValidationResult(false, string.Format("{0}到{1}个字符，区分大小写", MinLength, MaxLength));
            }
            else
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
