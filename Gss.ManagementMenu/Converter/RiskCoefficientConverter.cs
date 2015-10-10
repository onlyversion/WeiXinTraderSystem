using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace Gss.ManagementMenu.Converter
{
    /// <summary>
    /// 风险率颜色转换，小于100%为红色
    /// </summary>
   public class RiskCoefficientConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                decimal d = System.Convert.ToDecimal(value);
                if (d < 100)
                {
                    return new SolidColorBrush(Colors.Red);
                }
                else
                {
                    return new SolidColorBrush(Colors.Black);
                }
            }
            catch (Exception)
            {

                return new SolidColorBrush(Colors.Red);
            }
           
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
