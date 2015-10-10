using System;
using System.Windows.Data;
using Gss.Entities.Enums;

namespace Gss.ManagementMenu.Converter {
    class LogTypeEnumConverter : IValueConverter {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            LOG_TYPE logType = ( LOG_TYPE )value;
            if( logType == LOG_TYPE.Manager )
                return "管理员";
            else
                return "金商";
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            string str = ( string )value;
            if( str == "管理员" )
                return LOG_TYPE.Manager;
            else
                return LOG_TYPE.Dealer;
        }
    }
}
