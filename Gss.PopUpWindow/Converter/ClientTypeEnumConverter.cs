using System;
using System.Windows.Data;
using Gss.Entities.Enums;

namespace Gss.PopUpWindow.Converter {
    public class ClientTypeEnumConverter : IValueConverter {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            CLIENT_TYPE clientType = ( CLIENT_TYPE )value;
            switch( clientType ) {
                case CLIENT_TYPE.Individual:
                    return "个体用户";
                case CLIENT_TYPE.Institutional:
                    return "机构用户";
                default:
                    return "";
            }
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            string str = ( string )value;
            if( str == "机构用户" )
                return CLIENT_TYPE.Institutional;
            else
                return CLIENT_TYPE.Individual;
        }
    }
}
