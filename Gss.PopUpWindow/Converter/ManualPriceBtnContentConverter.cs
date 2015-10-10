using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Gss.PopUpWindow.Converter
{
    public class ManualPriceBtnContentConverter:IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                double SpreadDigit = System.Convert.ToDouble(values[0]);
                SpreadDigit = -SpreadDigit;

                double Number = System.Convert.ToDouble(values[1]);
                return Number * Math.Pow(10, SpreadDigit);
            }
            catch (Exception)
            {

                return 0;
            }
            
        }
        //未使用
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
