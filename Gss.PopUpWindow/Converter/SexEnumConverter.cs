using System;
using System.Windows.Data;
using Gss.Entities.Enums;

namespace Gss.PopUpWindow.Converter {
    public class SexEnumConverter : IValueConverter {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            SEX? sex = ( SEX? )value;
            if( sex == null )
                return "";
            else if( sex == SEX.Male )
                return "男";
            else
                return "女";
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            string str = ( string )value;
            if( string.IsNullOrEmpty( str ) )
                return null;
            else if( str == "男" )
                return SEX.Male;
            else
                return SEX.Female;
        }
    }
}
