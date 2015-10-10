using System;
using Gss.Entities.Enums;

namespace Gss.Entities {
    /// <summary>
    /// 金商账户信息类
    /// </summary>
    [Serializable]
    public class DealerAccountInformation : AccountInformationBase {
        #region 属性

        private CeritificateEnum _ceritificateEnum;
        private string _certificateNumber;
        private string _company;
        private string _legal;
        private string _parentDealer;
        private string _personInCharge;

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
        /// 获取或设置公司名称
        /// </summary>
        public string Company {
            get { return _company; }
            set {
                _company = value;
                RaisePropertyChanged( "Company" );
            }
        }

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
        /// 获取或设置所属金商
        /// </summary>
        public string ParentDealer {
            get { return _parentDealer; }
            set {
                _parentDealer = value;
                RaisePropertyChanged( "ParentDealer" );
            }
        }

        /// <summary>
        /// 获取或设置负责人
        /// </summary>
        public string PersonInCharge {
            get { return _personInCharge; }
            set {
                _personInCharge = value;
                RaisePropertyChanged( "Reperson" );
            }
        }

        private string _TradeAccount;
        /// <summary>
        /// 转户绑定
        /// </summary>
        public string TradeAccount
        {
            get { return _TradeAccount; }
            set {
                _TradeAccount = value;
                RaisePropertyChanged("TradeAccount");
            }
        }

        

        #endregion

        #region 构造函数

        /// <summary>
        /// 实例化一个采用默认值的金商账户类
        /// </summary>
        public DealerAccountInformation( ) {
            CeritificateEnum = CeritificateEnum.ID;
        }

        #endregion

        #region 同步方法

        /// <summary>
        /// 金商账户数据同步
        /// </summary>
        /// <param name="dealerAccInfo">同步数据源</param>
        public void Sync( DealerAccountInformation dealerAccInfo ) {
            base.Sync( dealerAccInfo );

            CeritificateEnum = dealerAccInfo.CeritificateEnum;
            CertificateNumber = dealerAccInfo.CertificateNumber;
            Company = dealerAccInfo.Company;
            Legal = dealerAccInfo.Legal;
            ParentDealer = dealerAccInfo.ParentDealer;
            PersonInCharge = dealerAccInfo.PersonInCharge;
            TradeAccount = dealerAccInfo.TradeAccount;
        }

        #endregion
    }
}
