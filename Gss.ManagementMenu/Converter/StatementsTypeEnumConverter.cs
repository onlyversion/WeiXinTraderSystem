using System;
using System.Windows.Data;
using Gss.Entities.Enums;

namespace Gss.ManagementMenu.Converter
{
    public class StatementsTypeEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            STATEMENTS_TYPE type = (STATEMENTS_TYPE)value;
            string str = string.Empty;
            switch (type)
            {
                case STATEMENTS_TYPE.MarketOrder:
                    str = "订单报表";
                    break;
                case STATEMENTS_TYPE.PendingOrder:
                    str = " 挂单报表";
                    break;
                case STATEMENTS_TYPE.Warehousing:
                    str = "入库报表";
                    break;
                case STATEMENTS_TYPE.Chargeback:
                    str = "平仓报表";
                    break;
                case STATEMENTS_TYPE.AdjustDeposit:
                    str = "资金报表";
                    break;
                case STATEMENTS_TYPE.AccountBalance:
                    str = "账户结余";
                    break;
                case STATEMENTS_TYPE.OrderTakeReport:
                    str = "买涨交割单报表";
                    break;
                case STATEMENTS_TYPE.OrderBackReport:
                    str = "买跌单报表";
                    break;
                case STATEMENTS_TYPE.OrderCheckReport:
                    str = "买跌交割单报表";
                    break;
                case STATEMENTS_TYPE.JgjReport:
                    str = "转金生金报表";
                    break;
                case STATEMENTS_TYPE.AgentDoDetail:
                    str = "提货受理报表";
                    break;
                default:
                    str = "";
                    break;
            }


            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string str = (string)value;
            STATEMENTS_TYPE type;
            switch (str)
            {
                case "在手订单":
                    type = STATEMENTS_TYPE.MarketOrder;
                    break;
                case "委托订单":
                    type = STATEMENTS_TYPE.PendingOrder;
                    break;
                case "入库报表":
                    type = STATEMENTS_TYPE.Warehousing;
                    break;
                case "平仓历史":
                    type = STATEMENTS_TYPE.Chargeback;
                    break;
                case "资金明细":
                    type = STATEMENTS_TYPE.AdjustDeposit;
                    break;
                case "账户结余":
                    type = STATEMENTS_TYPE.AccountBalance;
                    break;
                case "买涨交割单报表":
                    type = STATEMENTS_TYPE.OrderTakeReport;
                    break;
                case "买跌单报表":
                    type = STATEMENTS_TYPE.OrderBackReport;
                    break;
                case "买跌交割单报表":
                    type = STATEMENTS_TYPE.OrderCheckReport;
                    break;
                case "转金生金报表":
                    type = STATEMENTS_TYPE.JgjReport;
                    break;
                case "提货受理报表":
                    type = STATEMENTS_TYPE.AgentDoDetail;
                    break;
              
                default:
                    throw new NotSupportedException("不支持的字符串转船成“STATEMENTS_TYPE”枚举类型");
            }
            return type;
        }
    }
}
