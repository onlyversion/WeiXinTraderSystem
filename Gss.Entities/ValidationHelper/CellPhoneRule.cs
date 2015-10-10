using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Gss.Entities.ValidationHelper {
    public class CellPhoneRule : ValidationRule {
        public override ValidationResult Validate( object value, System.Globalization.CultureInfo cultureInfo ) {
            string phone = ( string )value;

            if( string.IsNullOrEmpty( phone ) )
                return new ValidationResult( false, "该值不能为空" );
            //手机号码现支持13、15、186、188，189开头的11位数字
            //string s = @"^(13[0-9]|15[0-9]|18[6|8|9])\d{8}$";
            string s = @"^(1)\d{10}$";
            if( Regex.IsMatch( phone, s ) )
                return new ValidationResult( true, null );
            else
                return new ValidationResult( false, "手机号码格式不正确" );
        }
    }
}
