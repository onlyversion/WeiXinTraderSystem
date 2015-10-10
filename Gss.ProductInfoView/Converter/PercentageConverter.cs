using System;
using System.Windows.Data;
using System.Globalization;

namespace Gss.ProductInfoView.Converter {
    internal class PercentageConverter : IValueConverter {

        public object Convert( object value, Type targetType, object parameter, CultureInfo culture ) {
            double percentage = ( double )value;
            return percentage * 100;
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture ) {
            throw new NotSupportedException( );
        }
    }
}
