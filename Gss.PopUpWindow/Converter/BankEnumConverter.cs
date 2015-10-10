using System;
using System.Windows.Data;
using Gss.Entities.Enums;

namespace Gss.PopUpWindow.Converter {
    public class BankEnumConverter : IValueConverter {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            BANK bank = ( BANK )value;

            string bankName = string.Empty;
            switch( bank ) {
                case BANK.NULL:
                    bankName = "";
                    break;
                case BANK.HXB:
                    bankName = "华夏银行";
                    break;
                case BANK.ABC:
                    bankName = "中国农业银行";
                    break;
                default:
                    bankName = "其他";
                    break;
            }
            return bankName;
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            throw new NotImplementedException( );
        }
    }
}
