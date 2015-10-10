using System;
using System.Windows.Data;
using Gss.Entities.Enums;

namespace Gss.PopUpWindow.Converter {
    public class ProductStateEnumConverter : IValueConverter {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            if( !( value is PRODUCT_STATE ) )
                return null;

            PRODUCT_STATE state = ( PRODUCT_STATE )value;
            switch( state ) {
                case PRODUCT_STATE.All:
                    return "正常交易";
                case PRODUCT_STATE.AllowQuotation:
                    return "只报价";
                case PRODUCT_STATE.AllowOrder:
                    return "只买涨";
                case PRODUCT_STATE.AllowRecovery:
                    return "只买跌";
                case PRODUCT_STATE.None:
                    return "全部禁止";
                default :
                    return null;
            }
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            string enumStr = ( string )value;
            switch( enumStr ) {
                case "正常交易":
                    return PRODUCT_STATE.All;
                case "只报价":
                    return PRODUCT_STATE.AllowQuotation;
                case "只买涨":
                    return PRODUCT_STATE.AllowOrder;
                case "只买跌":
                    return PRODUCT_STATE.AllowRecovery;
                case "全部禁止":
                    return PRODUCT_STATE.None;
                default:
                    return PRODUCT_STATE.None;

            }
        }
    }
}
