using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Gss.Common.Converter {
    public class BooleanInvertedConverter : IValueConverter {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            bool val = System.Convert.ToBoolean( value );
            return !val;
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            bool val = ( bool )value;
            return !val;
        }
    }
}
