using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Gss.ManagementMenu.Converter
{
    public class TerminationStateConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return "";
            }
            else
            {
                switch (value.ToString())
                {
                    case "0":
                        return "已申请";
                    case "1":
                        return "已审核";
                    case "2":
                        return "已拒绝";

                    default:
                        return "";
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
