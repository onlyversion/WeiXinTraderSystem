using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gss.Common.Infrastructure;

namespace Gss.Entities {
    public class ClientAccountFilter : ObservableObject {
        private string _accountName;

        /// <summary>
        /// 获取或设置账号
        /// </summary>
        public string AccountName {
            get { return _accountName; }
            set {
                _accountName = value;
                RaisePropertyChanged( "AccountName" );
            }
        }

        private string _userName;

        /// <summary>
        /// 获取或设置用户姓名
        /// </summary>
        public string UserName {
            get { return _userName; }
            set {
                _userName = value;
                RaisePropertyChanged( "UserName" );
            }
        }

        private string _certificateNumber;

        /// <summary>
        /// 获取或设置证件号码
        /// </summary>
        public string CertificateNumber {
            get { return _certificateNumber; }
            set {
                _certificateNumber = value;
                RaisePropertyChanged( "CertificateNumber" );
            }
        }
        
    }
}
