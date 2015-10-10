using System;
using System.Globalization;
using System.Windows.Data;

namespace Gss.Common.Converter {
    public class DateTimeFormatConverter : IValueConverter {

        public object Convert( object value, Type targetType, object parameter, CultureInfo culture ) {
            if (value == null)
                return "";
            DateTime time = ( DateTime )value;
            string format = ( string )parameter;
            if( string.IsNullOrEmpty( format ) )
                format = "yyyy/MM/dd HH:mm:ss";
            if (time == DateTime.MinValue)
                return "";
            return time.ToString( format );
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture ) {
            throw new NotSupportedException( );
        }
    }
}
