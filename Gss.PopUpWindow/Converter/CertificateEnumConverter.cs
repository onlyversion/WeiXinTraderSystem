using System;
using System.Windows.Data;
using Gss.Entities.Enums;

namespace Gss.PopUpWindow.Converter {
    public class CertificateEnumConverter : IValueConverter {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            CeritificateEnum ceritificateEnum = ( CeritificateEnum )value;
            if( ceritificateEnum == CeritificateEnum.ID )
                return "身份证";
            else
                return "其它";
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            string str = ( string )value;
            if (str == "其它")
                return CeritificateEnum.BusinessLicense;
            else
                return CeritificateEnum.ID;
        }
    }
}
