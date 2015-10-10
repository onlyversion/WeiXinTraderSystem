using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Gss.PopUpWindow.ValidationHelper {
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

            if( string.IsNullOrEmpty( str ) )
                return new ValidationResult( false, "该值不能为空" );

            if( str.Length < MinLength || str.Length > MaxLength ) 
            {
                return new ValidationResult( false, string.Format( "输入长度必须介于{0}和{1}之间", MinLength, MaxLength ) );
            } else {
                return new ValidationResult( true, null );
            }
        }
    }
}
