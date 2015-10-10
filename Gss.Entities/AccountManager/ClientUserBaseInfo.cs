using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Gss.Entities.AccountManager
{
    public class ClientUserBaseInfo : BaseInfo
    {
        public ClientUserBaseInfo()
        {
            TdUserList = new ObservableCollection<ClientAccount>();
        }
        private bool _Result;
        /// <summary>
        /// 结果
        /// </summary>
        public bool Result
        {
            get { return _Result; }
            set
            {
                _Result = value;
                RaisePropertyChanged("Result");
            }
        }

        private string _Desc;
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc
        {
            get { return _Desc; }
            set
            {
                _Desc = value;
                RaisePropertyChanged("Desc");
            }
        }
        private double _Money;
        /// <summary>
        /// 账户余额
        /// </summary>
        public double Money
        {
            get { return _Money; }
            set
            {
                _Money = value;
                RaisePropertyChanged("Money");
            }
        }
        private double _OccMoney;
        /// <summary>
        /// 保证金
        /// </summary>
        public double OccMoney
        {
            get { return _OccMoney; }
            set
            {
                _OccMoney = value;
                RaisePropertyChanged("OccMoney");
            }
        }

        private double _FrozenMoney;
        /// <summary>
        /// 预付款
        /// </summary>
        public double FrozenMoney
        {
            get { return _FrozenMoney; }
            set
            {
                _FrozenMoney = value;
                RaisePropertyChanged("FrozenMoney");
            }
        }
        private double _DongJieMoney;
        /// <summary>
        /// 冻结资金
        /// </summary>
        public double DongJieMoney
        {
            get { return _DongJieMoney; }
            set
            {
                _DongJieMoney = value;
                RaisePropertyChanged("DongJieMoney");
            }
        }

        private ObservableCollection<ClientAccount> _TdUserList;
        /// <summary>
        /// 用户基本信息列表
        /// </summary>
        public ObservableCollection<ClientAccount> TdUserList
        {
            get { return _TdUserList; }
            set
            {
                _TdUserList = value;
                RaisePropertyChanged("TdUserList");
            }
        }

    }
}
