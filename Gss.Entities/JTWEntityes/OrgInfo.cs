using Gss.Entities.Enums;

namespace Gss.Entities.JTWEntityes
{
   public  class OrgInfo:BaseInfo
    {
       private bool _IsCheck ;
        /// <summary>
        /// 是否选中
        /// </summary>
       public bool IsCheck
        {
            get { return _IsCheck; }
            set
            {
                _IsCheck = value;
                RaisePropertyChanged("IsCheck");
            }
        }

       private string _OrgID="";
        /// <summary>
        /// 会员ID
        /// </summary>
        public string OrgID
        {
            get { return _OrgID; }
            set
            {
                _OrgID = value;
                RaisePropertyChanged("OrgID");
            }
        }

        private string _OrgName = "";
        /// <summary>
        /// 所属会员
        /// </summary>
        public string OrgName
        {
            get { return _OrgName; }
            set
            {
                _OrgName = value;
                RaisePropertyChanged("OrgName");
            }
        }

        private string _Coperson = "";
        /// <summary>
        /// 法人
        /// </summary>
        public string Coperson
        {
            get { return _Coperson; }
            set
            {
                _Coperson = value;
                RaisePropertyChanged("Coperson");
            }
        }

        private CeritificateEnum _CardType;
        /// <summary>
        /// 证件类型
        /// </summary>
        public CeritificateEnum CardType
        {
            get { return _CardType; }
            set
            {
                if (value != _CardType)
                {
                    _CardType = value;
                    _CardTypeString = EnumConverter.ConverterCeritificateEnum(value);
                    RaisePropertyChanged("CardTypeString");   
                    RaisePropertyChanged("CardType");
                }
            }
        }

        private string _CardTypeString;
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CardTypeString
        {
            get { return _CardTypeString; }
            set
            {
                if (_CardTypeString != value)
                {
                    _CardTypeString = value;
                    _CardType = EnumConverter.ConverterBackCeritificateEnum(value);
                    RaisePropertyChanged("CardType");
                    RaisePropertyChanged("CardTypeString");
                }
            }
        }

        private string _CardNum = "";
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CardNum
        {
            get { return _CardNum; }
            set
            {
                _CardNum = value;
                RaisePropertyChanged("CardNum");
            }

        }

        private string _ParentOrgID ;
        /// <summary>
        /// 上级会员ID
        /// </summary>
        public string ParentOrgId
        {
            get { return _ParentOrgID; }
            set
            {
                _ParentOrgID = value;
                RaisePropertyChanged("ParentOrgId");
            }
        }

        private string _ParentOrgName ;
        /// <summary>
        /// 上级所属会员
        /// </summary>
        public string ParentOrgName
        {
            get { return _ParentOrgName; }
            set
            {
                _ParentOrgName = value;
                RaisePropertyChanged("ParentOrgName");
            }
        }

        private string _Reperson = "";
        /// <summary>
        /// 负责人
        /// </summary>
        public string Reperson
        {
            get { return _Reperson; }
            set
            {
                _Reperson = value;
                RaisePropertyChanged("Reperson");
            }
        }

        private string _PhoneNum = "";
        /// <summary>
        /// 手机
        /// </summary>
        public string PhoneNum
        {
            get { return _PhoneNum; }
            set
            {
                _PhoneNum = value;
                RaisePropertyChanged("PhoneNum");
            }
        }

        private string _TelePhone = "";
        /// <summary>
        /// 固定电话
        /// </summary>
        public string TelePhone
        {
            get { return _TelePhone; }
            set
            {
                _TelePhone = value;
                RaisePropertyChanged("TelePhone");
            }
        }

        private string _Email = "";
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                RaisePropertyChanged("Email");
            }
        }
        private string _Address = "";
        /// <summary>
        /// 联系地址
        /// </summary>
        public string Address
        {
            get { return _Address; }
            set
            {
                _Address = value;
                RaisePropertyChanged("Address");
            }
        }

        private string _AddTime = "";
        /// <summary>
        /// 新增时间
        /// </summary>
        public string AddTime
        {
            get { return _AddTime; }
            set
            {
                _AddTime = value;
                RaisePropertyChanged("AddTime");
            }
        }

        private bool _Status=true;
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Status
        {
            get { return _Status; }
            set
            {
                _Status = value;
                RaisePropertyChanged("Status");
            }
        }
       // private string _CodeOrgName;
       ///// <summary>
       ///// 带编码的会员名称
       ///// </summary>
       // public string CodeOrgName
       // {
       //     get { return _CodeOrgName; }
       //     set
       //     {
       //         _CodeOrgName = value;
       //         RaisePropertyChanged("CodeOrgName");
       //     }
       // }

        public string OrgNameAndOrgCode
       {
           get { return TelePhone + "  " + OrgName; }
       }

        public override string ToString()
        {
            return this.OrgNameAndOrgCode;
        }
    }
}
