using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.TradeManager
{
    /// <summary>
    /// 解约
    /// </summary>
    public class TradeJieYue : BaseInfo
    {
        private int _ApplyId;
        /// <summary>
        /// 申请Id(自增)
        /// </summary>
        public int ApplyId
        {
            get { return _ApplyId; }
            set
            {
                _ApplyId = value;
                RaisePropertyChanged("ApplyId");
            }
        }

        private string _UserID;
        /// <summary>
        /// 用户ID	
        /// </summary>
        public string UserID
        {
            get { return _UserID; }
            set
            {
                _UserID = value;
                RaisePropertyChanged("UserID");
            }
        }

        private string _BankCard;
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankCard
        {
            get { return _BankCard; }
            set
            {
                _BankCard = value;
                RaisePropertyChanged("BankCard");
            }
        }
        private string _CardName;
        /// <summary>
        /// 持卡人
        /// </summary>
        public string CardName
        {
            get { return _CardName; }
            set
            {
                _CardName = value;
                RaisePropertyChanged("CardName");
            }
        }
        private string _OpenBank;
        /// <summary>
        /// 开户行
        /// </summary>
        public string OpenBank
        {
            get { return _OpenBank; }
            set
            {
                _OpenBank = value;
                RaisePropertyChanged("OpenBank");
            }
        }

       
        private DateTime _ApplyTime;
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime ApplyTime
        {
            get { return _ApplyTime; }
            set
            {
                _ApplyTime = value;
                RaisePropertyChanged("ApplyTime");
            }
        }

       

        private string _OrgName;
        /// <summary>
        /// 机构名称
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
        private string _TelePhone;
        /// <summary>
        /// 会员编码
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
        
        private string _State;
        /// <summary>
        /// 状态"0"-已申请，"1"-已审核,"2"已拒绝
        /// </summary>
        public string State
        {
            get { return _State; }
            set
            {
                _State = value;
                RaisePropertyChanged("State");
            }
        }


    

        private string _Account;
        /// <summary>
        /// 用户账号
        /// </summary>
        public string Account
        {
            get { return _Account; }
            set
            {
                _Account = value;
                RaisePropertyChanged("Account");
            }
        }
    }
}
