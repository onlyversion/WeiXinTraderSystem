using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows;

namespace Gss.ManagementMenu.Converter {
    public class BooleanNullVisibilityConverter : IValueConverter {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            bool? boolean = ( bool? )value;
            if( boolean.HasValue && !boolean.Value )
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            throw new NotImplementedException( );
        }
    }
}
