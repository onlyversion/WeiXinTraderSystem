using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Gss.Entities.AccountManager;

namespace Gss.ManagementMenu.Converter
{
    /// <summary>
    /// 银行编号转换银行名称
    /// </summary>
    public class BankTypeConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string bankName = "";
            try
            {
                string bankCode = value.ToString();
                foreach (var item in Bank.BankLst)
                {
                    if (item.BankCode == bankCode)
                    {
                        bankName = item.BankName;
                    }
                }
            }
            catch (Exception)
            {
                
                bankName="";
            }
            
            return bankName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
