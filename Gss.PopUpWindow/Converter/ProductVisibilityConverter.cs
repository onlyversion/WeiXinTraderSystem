using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Gss.Entities.Enums;
using System.Windows;

namespace Gss.PopUpWindow.Converter
{
    /// <summary>
    /// 产品状态转换
    /// </summary>
    public class ProductVisibilityConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            PRODUCT_STATE state = (PRODUCT_STATE)value;
            if (state == PRODUCT_STATE.None || state == PRODUCT_STATE.AllowQuotation)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
