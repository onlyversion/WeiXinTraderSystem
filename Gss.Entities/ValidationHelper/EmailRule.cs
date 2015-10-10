using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace Gss.Entities.ValidationHelper {
    public class EmailRule : ValidationRule {
        public override ValidationResult Validate( object value, System.Globalization.CultureInfo cultureInfo ) {
            string email = ( string )value;

            if( string.IsNullOrEmpty( email ) )
                return new ValidationResult( false, "该值不能为空" );

            Regex regex = new Regex( "\\w+([-+.]\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*" );
            Match match = regex.Match( email );
            if( match.Success )
                return new ValidationResult( true, null );
            else
                return new ValidationResult( false, "邮箱格式不正确    示例：aaa@bb.ccc" );
        }
    }
}
