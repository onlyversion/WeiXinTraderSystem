using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Gss.Entities.AccountManager
{
    public class Bank:BaseInfo
    {
        private string _BankCode;
        /// <summary>
        /// 银行编码
        /// </summary>
        public string BankCode
        {
            get { return _BankCode; }
            set
            {
                _BankCode = value;
                RaisePropertyChanged("BankCode");
            }
        }

        private string _BankName;
        /// <summary>
        /// 银行名称
        /// </summary>
        public string BankName
        {
            get { return _BankName; }
            set
            {
                _BankName = value;
                RaisePropertyChanged("BankName");
            }
        }


        public static ObservableCollection<Bank> BankLst { get; set; }

        

    }
}
