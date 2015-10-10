using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Gss.ManagementMenu.Converter
{
    public class PendingOrdersStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int val = System.Convert.ToInt32(value);
            if (val == 0)
                return "成功";
            else if (val == 1)
                return "取消";
            else
                return "未知类型";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}