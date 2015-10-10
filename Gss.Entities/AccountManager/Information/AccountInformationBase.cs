using System;
using Gss.Common.Infrastructure;

namespace Gss.Entities {
    /// <summary>
    /// 账户基本资料的基础类型
    /// </summary>
    [Serializable]
    public abstract class AccountInformationBase : ObservableObject {
        #region 属性

        private string _accountName;
        private string _address;
        private string _cellPhoneNumber;
        private string _email;
        private bool _isAccountEnabled = true;
        private bool _isOnline;
        private string _password;
        private string _remark;
        private string _telephoneNumber;

        /// <summary>
        /// 获取或设置用户账号
        /// </summary>
        public string AccountName {
            get { return _accountName; }
            set {
                _accountName = value;
                RaisePropertyChanged( "AccountName" );
            }
        }

        /// <summary>
        /// 获取或设置用户密码
        /// </summary>
        public string AccountPassword {
            get { return _password; }
            set {
                _password = value;
                RaisePropertyChanged( "AccountPassword" );
            }
        }

        /// <summary>
        /// 获取或设置地址
        /// </summary>
        public string Address {
            get { return _address; }
            set {
                _address = value;
                RaisePropertyChanged( "Address" );
            }
        }

        /// <summary>
        /// 获取或设置手机号码
        /// </summary>
        public string CellPhoneNumber {
            get { return _cellPhoneNumber; }
            set {
                _cellPhoneNumber = value;
                RaisePropertyChanged( "CellPhoneNumber" );
            }
        }

        /// <summary>
        /// 获取或设置邮箱
        /// </summary>
        public string Email {
            get { return _email; }
            set {
                _email = value;
                RaisePropertyChanged( "Email" );
            }
        }

        /// <summary>
        /// 获取或设置账户是否启用
        /// </summary>
        public bool IsAccountEnabled {
            get { return _isAccountEnabled; }
            set {
                if( _isAccountEnabled != value ) {
                    _isAccountEnabled = value;
                    RaisePropertyChanged( "IsAccountEnabled" );
                }
            }
        }

        /// <summary>
        /// 获取或设置用户是否在线
        /// </summary>
        public bool IsOnline {
            get { return _isOnline; }
            set {
                if( _isOnline != value ) {
                    _isOnline = value;
                    RaisePropertyChanged( "IsAccountEnabled" );
                }
            }
        }

        /// <summary>
        /// 获取或设置上一次登陆时间
        /// </summary>
        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 获取或设置登陆IP
        /// </summary>
        public string LoginIP { get; set; }

        /// <summary>
        /// 获取或设置登陆MAC
        /// </summary>
        public string LoginMAC { get; set; }

        /// <summary>
        /// 获取开户时间
        /// </summary>
        public DateTime? OpenAccountTime { get; set; }

        /// <summary>
        /// 获取或设置备注信息
        /// </summary>
        public string Remark {
            get { return _remark; }
            set {
                _remark = value;
                RaisePropertyChanged( "Remark" );
            }
        }

        /// <summary>
        /// 获取或设置固定电话
        /// </summary>
        public string TelephoneNumber {
            get { return _telephoneNumber; }
            set {
                _telephoneNumber = value;
                RaisePropertyChanged( "TelephoneNumber" );
            }
        }
        #endregion

        #region 构造函数

        /// <summary>
        /// 用账户名实例化一个账户基本信息类
        /// </summary>
        protected AccountInformationBase( ) {
            OpenAccountTime = DateTime.Now;
        }

        #endregion

        #region 同步方法

        /// <summary>
        /// 账户信息数据同步
        /// </summary>
        /// <param name="clone">同步数据源</param>
        protected void Sync( AccountInformationBase clone ) {
            AccountName = clone.AccountName;
            AccountPassword = clone.AccountPassword;
            Address = clone.Address;
            CellPhoneNumber = clone.CellPhoneNumber;
            Email = clone.Email;
            IsAccountEnabled = clone.IsAccountEnabled;
            IsOnline = clone.IsOnline;
            LastLoginTime = clone.LastLoginTime;
            LoginIP = clone.LoginIP;
            LoginMAC = clone.LoginMAC;
            OpenAccountTime = clone.OpenAccountTime;
            Remark = clone.Remark;
            TelephoneNumber = clone.TelephoneNumber;
        } 

        #endregion
    }
}
