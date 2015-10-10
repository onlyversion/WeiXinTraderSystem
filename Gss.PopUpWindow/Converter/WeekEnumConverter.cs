using System;
using System.Windows.Data;
using Gss.Entities.Enums;

namespace Gss.PopUpWindow.Converter {
    public class WeekEnumConverter : IValueConverter {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            WEEK week = ( WEEK )value;
            switch( week ) {
                case WEEK.Sunday:
                    return "星期日";
                case WEEK.Monday:
                    return "星期一";
                case WEEK.Tuesday:
                    return "星期二";
                case WEEK.Wednesday:
                    return "星期三";
                case WEEK.Thursday:
                    return "星期四";
                case WEEK.Friday:
                    return "星期五";
                case WEEK.Saturday:
                    return "星期六";
                default:
                    return "未知";
            }
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            throw new NotImplementedException( );
        }
    }
}
