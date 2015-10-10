using System;
using System.Globalization;
using System.Windows.Data;
using Gss.Entities.Enums;

namespace Gss.ManagementMenu.Converter{
    internal class TradeTypeConverter : IValueConverter {
        public object Convert( object value, Type targetType, object parameter, CultureInfo culture ) {
            CHARGEBACK_MODE mode = ( CHARGEBACK_MODE )value;
            switch( mode ) {
                case CHARGEBACK_MODE.Auto:
                    return "系统强制平仓";
                case CHARGEBACK_MODE.User:
                    return "手动平仓";
                case CHARGEBACK_MODE.Warehousing:
                    return "入库";
                default:
                    return "";
            }
        }

        public object ConvertBack( object value, Type targetType, object parameter, CultureInfo culture ) {
            throw new NotSupportedException();
        }
    }

    internal class ChargebackTypeConverter:IMultiValueConverter
    {

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string str = "";
                CHARGEBACK_MODE type = (CHARGEBACK_MODE)values[0];
                double price = System.Convert.ToDouble(values[1]);
                double price1 = System.Convert.ToDouble(values[2]);
                double price2 = System.Convert.ToDouble(values[3]);
                double zero = 0.000001;
                switch (type)
                {
                    case CHARGEBACK_MODE.Auto:
                        if (System.Math.Abs(price - price1) <= zero || System.Math.Abs(price - price2) <= zero)
                        {
                            str = "止损/止盈";
                        }
                        else
                        {
                            str = "系统强制平仓";
                        }
                        break;
                    case CHARGEBACK_MODE.User:
                        str = "手动平仓";
                        break;
                    case CHARGEBACK_MODE.Warehousing:
                        str = "入库";
                        break;

                    case CHARGEBACK_MODE.Balance:
                        str = "结算平仓";
                        break;

                    case CHARGEBACK_MODE.AutoStopLose:
                        str = "止损平仓";
                        break;

                    case CHARGEBACK_MODE.AutoStopProfit:
                        str = "止盈平仓";
                        break;

                    //        0  自动平仓（爆仓）
                    //1  手动平仓
                    //如果是手动平仓，需要填写平仓的ip地址和mac地址
                    //2  入库
                    //3 结算平仓
                    //4 自动平仓（止损平仓）
                    //5 自动平仓（止盈平仓）
                }

                return str;
            }
            catch (Exception)
            {

                return "未知";
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
