using System;
using System.Windows.Data;
using Gss.Entities.Enums;

namespace ZdSystem.Converter
{
    internal class AccountTypeEnumConverter : IValueConverter {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            ACCOUNT_TYPE accType = ( ACCOUNT_TYPE )value;
            switch( accType ) {
                case ACCOUNT_TYPE.Manager:
                    return "管理员";
                case ACCOUNT_TYPE.Dealer:
                    return "金商";
                case ACCOUNT_TYPE.DealerClerk:
                    return "金商店员";
                default:
                    return "";
            }
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            string str = ( string )value;
            if( str == "管理员" )
                return ACCOUNT_TYPE.Manager;
            else if( str == "金商" )
                return ACCOUNT_TYPE.Dealer;
            else if (str == "金商店员")
                return ACCOUNT_TYPE.DealerClerk;
            else
                throw new NotSupportedException( str );
        }
    }
}
