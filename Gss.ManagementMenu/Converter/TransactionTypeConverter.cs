using System;
using System.Globalization;
using System.Windows.Data;
using Gss.Entities.Enums;

namespace Gss.ManagementMenu.Converter {
    internal class TransactionTypeConverter : IValueConverter {

        public object Convert( object value, Type targetType, object parameter, CultureInfo culture ) {
            if (value == null)
            {
                return null;
            }
            if ((TRANSACTION_TYPE)value == TRANSACTION_TYPE.Order)
            {
                return "买涨";
            }
            else if ((TRANSACTION_TYPE)value == TRANSACTION_TYPE.Recovery)
            {
                return "买跌";
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture ) {
            throw new NotSupportedException( );
        }
    }
}
