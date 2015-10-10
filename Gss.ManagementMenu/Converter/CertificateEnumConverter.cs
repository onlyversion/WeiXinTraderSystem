using System;
using System.Windows.Data;
using Gss.Entities.Enums;

namespace Gss.ManagementMenu.Converter {
    public class CertificateEnumConverter : IValueConverter {
        public object Convert( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            CeritificateEnum ceritificateEnum = ( CeritificateEnum )value;
            //if( ceritificateEnum == CeritificateEnum. )
            //    return "身份证";
            //else
            //    return "营业执照";
            string str="";
            switch(ceritificateEnum)
            {
                case CeritificateEnum.ID:
                    str= "身份证";
                    break;
                case CeritificateEnum.Company:
                    str = "机构代码";
                    break;
                case CeritificateEnum.BusinessLicense:
                    str = "其它";
                    break;
            }
            return str;
        }

        public object ConvertBack( object value, Type targetType, object parameter, System.Globalization.CultureInfo culture ) {
            string str = ( string )value;
            CeritificateEnum type = new CeritificateEnum();
            switch(str)
            {
                case "身份证":
                    type = CeritificateEnum.ID;
                    break;
                case "机构代码":
                    type = CeritificateEnum.Company;
                    break;
                case "其它":
                    type = CeritificateEnum.BusinessLicense;
                    break;
            }
            return type;
        }
    }
}
