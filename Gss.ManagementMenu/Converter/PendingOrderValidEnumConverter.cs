using System;
using System.Windows.Data;
using Gss.Entities.Enums;

namespace Gss.ManagementMenu.Converter {
    public class PendingOrderValidEnumConverter : IValueConverter {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            PENDINGORDER_VALID pendingValid = ( PENDINGORDER_VALID )value;
            if( pendingValid == PENDINGORDER_VALID.Always )
                return "一直有效";
            else if( pendingValid == PENDINGORDER_VALID.CustomerDefine )
                return "客户自定义";
            else
                return "当天有效";
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            string str = ( string )value;
            if( str.Equals( "一直有效" ) )
                return PENDINGORDER_VALID.Always;
            else if( str.Equals( "客户自定义" ) )
                return PENDINGORDER_VALID.CustomerDefine;
            else
                return PENDINGORDER_VALID.OrderDay;
        }
    }
}
