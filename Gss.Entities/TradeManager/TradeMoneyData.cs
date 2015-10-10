namespace Gss.Entities.TradeManager
{
    /// <summary>
    /// 出入金和解约
    /// </summary>
    public class TradeMoneyData : BaseInfo
    {
        private string _Account;
        /// <summary>
        /// 账号
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

        private string _Opertime;
        /// <summary>
        /// 时间
        /// </summary>
        public string Opertime
        {
            get { return _Opertime; }
            set
            {
                _Opertime = value;
                RaisePropertyChanged("Opertime");
            }
        }
        private string _OldValue;
        /// <summary>
        /// 原金额
        /// </summary>
        public string OldValue
        {
            get { return _OldValue; }
            set
            {
                _OldValue = value;
                RaisePropertyChanged("OldValue");
            }
        }

        private string _NewValue;
        /// <summary>
        /// 新金额
        /// </summary>
        public string NewValue
        {
            get { return _NewValue; }
            set
            {
                _NewValue = value;
                RaisePropertyChanged("NewValue");
            }
        }

        private string _ChangeValue;
        /// <summary>
        /// 变动金额
        /// </summary>
        public string ChangeValue
        {
            get { return _ChangeValue; }
            set
            {
                _ChangeValue = value;
                RaisePropertyChanged("ChangeValue");
            }
        }

        private string _Reason;
        /// <summary>
        /// 操作
        /// </summary>
        public string Reason
        {
            get { return _Reason; }
            set
            {
                _Reason = value;
                RaisePropertyChanged("Reason");
            }
        }

        private string _State;
        /// <summary>
        /// 状态
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
    }
}
