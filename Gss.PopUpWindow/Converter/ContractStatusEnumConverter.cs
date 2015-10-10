using System;
using System.Windows.Data;
using Gss.Entities.Enums;

namespace Gss.PopUpWindow.Converter {
    public class ContractStatusEnumConverter : IValueConverter {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            CONTRACT_STATUS status = ( CONTRACT_STATUS )value;
            switch( status ) {
                case CONTRACT_STATUS.Unbound:
                    return "未签约";
                case CONTRACT_STATUS.Auditing:
                    return "审核中";
                case CONTRACT_STATUS.Binding:
                    return "已签约";
                case CONTRACT_STATUS.Termination:
                    return "已解约";
            }
            return "";
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            throw new NotImplementedException( );
        }
    }
}
