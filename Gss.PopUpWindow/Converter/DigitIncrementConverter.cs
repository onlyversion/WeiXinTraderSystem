using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Gss.PopUpWindow.Converter {
    public class DigitIncrementConverter : IValueConverter {

        public object Convert( object value, Type targetType, object parameter, CultureInfo culture ) {
            int digit = ( int )value;
            return Math.Pow( 10, -digit );
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture ) {
            throw new NotSupportedException( );
        }

    }
}
