using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Gss.PopUpWindow.Converter {
    public class DateLongTimeConverter : IValueConverter {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            return value;
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            DateTime time = ( DateTime )value;
            return time.ToString( "HH:mm:ss" );
        }
    }
}
