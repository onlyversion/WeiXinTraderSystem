using System;
using System.Windows.Data;

namespace Gss.Common.Converter
{
    /// <summary>
    /// 正负数转换，正数转换为负数
    /// </summary>
     public class PlusMinusConverter : IValueConverter
     {
         public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             if (value == null)
                 return null;
             double val = (double)value;
             if (val != null && val > 0)
                 return -val;
             else
                 return val;
         }

         public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
         {
             bool val = (bool)value;
             return !val;
         }
     }
}
