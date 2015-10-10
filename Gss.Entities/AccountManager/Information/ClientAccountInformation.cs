using System;
using Gss.Entities.Enums;

namespace Gss.Entities {
    /// <summary>
    /// 客户类型的账户基本资料
    /// </summary>
    [Serializable]
    public class ClientAccountInformation : AccountInformationBase {
        #region 属性
        private CeritificateEnum _ceritificateEnum;
        private string _certificateNumber;
        private CLIENT_TYPE _clientType;
        private string _contact;
        private string _dealer;
        private string _fundsPassword;
        private string _legal;
        private string _openingMan;
        private string _orderPhoneNumber;
        private SEX? _sex;
        private string _userName;
        private string _userID;
        private string _OrgId;
        private string _OrgName;
        private string _BindAccount;
        private string _reperson;

        /// <summary>
        /// 会员负责人
        /// </summary>
        public string Reperson
        {
            get { return _reperson; }
            set
            {
                if (_reperson != value)
                {
                    _reperson = value;
                    RaisePropertyChanged("Reperson");
                }
            }
        }
        /// <summary>
        /// 绑定的客户账号
        /// </summary>
        public string BindAccount
        {
            get { return _BindAccount; }
            set
            {
                if (_BindAccount != value)
                {
                    _BindAccount = value;
                    RaisePropertyChanged("BindAccount");
                }
            }
        }

        private string _Telephone;
        /// <summary>
        /// 会员编码
        /// </summary>
        public string Telephone
        {
            get { return _Telephone; }
            set
            {
                _Telephone = value;
                RaisePropertyChanged("Telephone");
            }
        }

        private bool _IsBroker;
        /// <summary>
        /// 是否经纪人
        /// </summary>
        public bool IsBroker
        {
            get { return _IsBroker; }
            set
            {
                _IsBroker = value;
                RaisePropertyChanged("IsBroker");
            }
        }
        
        /// <summary>
        /// 所属会员
        /// </summary>
        public string OrgName
        {
            get { return _OrgName; }
            set
            {
                if (_OrgName != value)
                {
                    _OrgName = value;
                    RaisePropertyChanged("OrgName");
                }
            }
        }
        /// <summary>
        /// 所属会员Id
        /// </summary>
        public string OrgId
        {
            get { return _OrgId; }
            set
            {
                if (_OrgId != value)
                {
                    _OrgId = value;
                    RaisePropertyChanged("OrgId");
                }
            }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserID
        {
            get { return _userID; }
            set
            {
                if (_userID != value)
                {
                    _userID = value;
                    RaisePropertyChanged("UserID");
                }
            }
        }

        /// <summary>
        /// 获取或设置证件类型
        /// </summary>
        public CeritificateEnum CeritificateEnum {
            get { return _ceritificateEnum; }
            set {
                if( _ceritificateEnum != value ) {
                    _ceritificateEnum = value;
                    RaisePropertyChanged( "CeritificateEnum" );
                }
            }
        }

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

        /// <summary>
        /// 获取或设置用户类型，个体或机构
        /// </summary>
        public CLIENT_TYPE ClientType {
            get { return _clientType; }
            set {
                if( _clientType != value ) {
                    _clientType = value;
                    RaisePropertyChanged( "ClientType" );
                }
            }
        }

        /// <summary>
        /// 获取或设置联系人
        /// </summary>
        public string Contact {
            get { return _contact; }
            set {
                _contact = value;
                RaisePropertyChanged( "Contact" );
            }
        }

        /// <summary>
        /// 获取或设置所属金商
        /// </summary>
        public string Dealer {
            get { return _dealer; }
            set {
                _dealer = value;
                RaisePropertyChanged( "Dealer" );
            }
        }

        /// <summary>
        /// 获取或设置资金密码
        /// </summary>
        public string FundsPassword {
            get { return _fundsPassword; }
            set {
                _fundsPassword = value;
                RaisePropertyChanged( "FundsPassword" );
            }
        }

        private string _LastUpdateManager;
        /// <summary>
        /// 获取或设置最后一次更新用户资料的管理员
        /// </summary>
        public string LastUpdateManager
        {
            get { return _LastUpdateManager; }
            set
            {
                _LastUpdateManager = value;
                RaisePropertyChanged("LastUpdateManager");
            }
        }

        /// <summary>
        /// 获取或设置最后一次用户资料修改时间
        /// </summary>
        public DateTime? LastUpdateTime { get; set; }

        /// <summary>
        /// 获取或设置法人
        /// </summary>
        public string Legal {
            get { return _legal; }
            set {
                _legal = value;
                RaisePropertyChanged( "Legal" );
            }
        }

        /// <summary>
        /// 获取或设置开户人
        /// </summary>
        public string OpeningMan {
            get { return _openingMan; }
            set {
                _openingMan = value;
                RaisePropertyChanged( "OpeningMan" );
            }
        }

        /// <summary>
        /// 获取或设置下单电话
        /// </summary>
        public string OrderPhoneNumber {
            get { return _orderPhoneNumber; }
            set {
                _orderPhoneNumber = value;
                RaisePropertyChanged( "OrderPhoneNumber" );
            }
        }

        /// <summary>
        /// 获取或设置性别
        /// </summary>
        public SEX? Sex {
            get { return _sex; }
            set {
                _sex = value;
                RaisePropertyChanged( "Sex" );
            }
        }

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

        private string _IsEnable;
         /// <summary>
        /// 获取或设置用户姓名
        /// </summary>
        public string IsEnable
        {
            get { return _IsEnable; }
            set {
                _IsEnable = value;
                RaisePropertyChanged("IsEnable");
            }
        }

        private string _PAccount;
        /// <summary>
        /// 经纪人账户名
        /// </summary>
        public string PAccount
        {
            get { return _PAccount; }
            set
            {
                _PAccount = value;
                RaisePropertyChanged("PAccount");
            }
        }

        private string _PUserName;
        /// <summary>
        /// 经纪人用户名
        /// </summary>
        public string PUserName
        {
            get { return _PUserName; }
            set
            {
                _PUserName = value;
                RaisePropertyChanged("PUserName");
            }
        }

        private string _PUserId;
        /// <summary>
        /// 经纪人用户ID
        /// </summary>
        public string PUserId
        {
            get { return _PUserId; }
            set
            {
                _PUserId = value;
                RaisePropertyChanged("PUserId");
            }
        }
        
        #endregion

        #region 构造函数

        /// <summary>
        /// 实例化一个包含默认值的客户信息对象
        /// </summary>
        public ClientAccountInformation( ) {
            CeritificateEnum = CeritificateEnum.ID;
        }

        #endregion

        #region 同步方法

        /// <summary>
        /// 数据同步
        /// </summary>
        /// <param name="clone">同步数据源</param>
        internal void Sync( ClientAccountInformation clone ) {
            base.Sync( clone );

            CeritificateEnum = clone.CeritificateEnum;
            CertificateNumber = clone.CertificateNumber;
            ClientType = clone.ClientType;
            Contact = clone.Contact;
            Dealer = clone.Dealer;
            FundsPassword = clone.FundsPassword;
            Legal = clone.Legal;
            OpeningMan = clone.OpeningMan;
            OrderPhoneNumber = clone.OrderPhoneNumber;
            Sex = clone.Sex;
            UserName = clone.UserName;
            OrgName = clone.OrgName;
            BindAccount = clone.BindAccount;
            OrgId = clone.OrgId;
            LastUpdateManager = clone.LastUpdateManager;
            Telephone = clone.Telephone;
        } 
        #endregion
    }
}
