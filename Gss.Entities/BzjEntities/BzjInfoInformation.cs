using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.BzjEntities
{
    /// <summary>
    /// 保证金信息
    /// </summary>
    public class BzjInfoInformation : BaseInfo
    {
        /// <summary>
        /// Tolerance value
        /// </summary>
        private const double TOLERANCE = 0.00000001;
        private decimal _Au;
        /// <summary>
        /// 黄金库存数量
        /// </summary>
        public decimal Au
        {
            get { return _Au; }
            set
            {
                _Au = value;
                RaisePropertyChanged("Au");
            }
        }

        private decimal _Ag;
        /// <summary>
        /// 白银库存数量
        /// </summary>
        public decimal Ag
        {
            get { return _Ag; }
            set
            {
                _Ag = value;
                RaisePropertyChanged("Ag");
            }
        }

        private decimal _Pt;
        /// <summary>
        /// 铂金库存数量
        /// </summary>
        public decimal Pt
        {
            get { return _Pt; }
            set
            {
                _Pt = value;
                RaisePropertyChanged("Pt");
            }
        }

        private decimal _Pd;
        /// <summary>
        /// 钯金库存数量
        /// </summary>
        public decimal Pd
        {
            get { return _Pd; }
            set
            {
                _Pd = value;
                RaisePropertyChanged("Pd");
            }
        }

        private decimal _AuPrice;
        /// <summary>
        /// 黄金平均价
        /// </summary>
        public decimal AuPrice
        {
            get { return _AuPrice; }
            set
            {
                _AuPrice = value;
                RaisePropertyChanged("AuPrice");
            }
        }

        private decimal _AgPrice;
        /// <summary>
        /// 白银平均价
        /// </summary>
        public decimal AgPrice
        {
            get { return _AgPrice; }
            set
            {
                _AgPrice = value;
                RaisePropertyChanged("AgPrice");
            }
        }

        private decimal _PtPrice;
        /// <summary>
        /// 铂金平均价
        /// </summary>
        public decimal PtPrice
        {
            get { return _PtPrice; }
            set
            {
                _PtPrice = value;
                RaisePropertyChanged("PtPrice");
            }
        }

        private decimal _PdPrice;
        /// <summary>
        /// 钯金平均价
        /// </summary>
        public decimal PdPrice
        {
            get { return _PdPrice; }
            set
            {
                _PdPrice = value;
                RaisePropertyChanged("PdPrice");
            }
        }

        private string _StockID;
        /// <summary>
        /// 库存ID
        /// </summary>
        public string StockID
        {
            get { return _StockID; }
            set
            {
                _StockID = value;
                RaisePropertyChanged("StockID");
            }
        }

        private string _UserId;
        /// <summary>
        /// 客户ID	
        /// </summary>
        public string UserId
        {
            get { return _UserId; }
            set
            {
                _UserId = value;
                RaisePropertyChanged("UserId");
            }
        }

        private string _LoginID;
        /// <summary>
        /// 登录ID	
        /// </summary>
        public string LoginID
        {
            get { return _LoginID; }
            set
            {
                _LoginID = value;
                RaisePropertyChanged("LoginID");
            }
        }

        private string _AccountName;
        /// <summary>
        /// 用户名	
        /// </summary>
        public string AccountName
        {
            get { return _AccountName; }
            set
            {
                _AccountName = value;
                RaisePropertyChanged("AccountName");
            }
        }

        private decimal _AuRealTimePrice;
        /// <summary>
        /// 黄金实时价
        /// </summary>
        public decimal AuRealTimePrice
        {
            get { return _AuRealTimePrice; }
            set
            {
                _AuRealTimePrice = value;
                RaisePropertyChanged("AuRealTimePrice");
            }
        }

        private decimal _AgRealTimePrice;
        /// <summary>
        /// 白银实时价
        /// </summary>
        public decimal AgRealTimePrice
        {
            get { return _AgRealTimePrice; }
            set
            {
                _AgRealTimePrice = value;
                RaisePropertyChanged("AgRealTimePrice");
            }
        }

        private decimal _PtRealTimePrice;
        /// <summary>
        /// 铂金实时价
        /// </summary>
        public decimal PtRealTimePrice
        {
            get { return _PtRealTimePrice; }
            set
            {
                _PtRealTimePrice = value;
                RaisePropertyChanged("PtRealTimePrice");
            }
        }

        private decimal _PdRealTimePrice;
        /// <summary>
        /// 钯金实时价
        /// </summary>
        public decimal PdRealTimePrice
        {
            get { return _PdRealTimePrice; }
            set
            {
                _PdRealTimePrice = value;
                RaisePropertyChanged("PdRealTimePrice");
            }
        }


        private string _CardNum;
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

        private string _VerifyCode;
        /// <summary>
        /// 验证码
        /// </summary>
        public string VerifyCode
        {
            get
            {
                return _VerifyCode;
            }
            set
            {
                _VerifyCode = value;
                RaisePropertyChanged("VerifyCode");
            }
        }


        private double _AuUpdate;
        /// <summary>
        /// 黄金修改的库存数量
        /// </summary>
        public double AuUpdate
        {
            get { return _AuUpdate; }
            set
            {
                _AuUpdate = value;
                if (value < 0 && Math.Abs(value) > (double)Au)
                    throw new ArgumentException("减少的库存不能大于库存量");
                RaisePropertyChanged("AuUpdate");
            }
        }

        private double _AgUpdate;
        /// <summary>
        /// 白银修改的库存数量
        /// </summary>
        public double AgUpdate
        {
            get { return _AgUpdate; }
            set
            {
                _AgUpdate = value;
                if (value < 0 && Math.Abs(value) > (double)Ag)
                    throw new ArgumentException("减少的库存不能大于库存量");
                RaisePropertyChanged("AgUpdate");
            }
        }

        private double _PtUpdate;
        /// <summary>
        /// 铂金修改的库存数量
        /// </summary>
        public double PtUpdate
        {
            get { return _PtUpdate; }
            set
            {
                _PtUpdate = value;
                if (value < 0 && Math.Abs(value) > (double)Pt)
                    throw new ArgumentException("减少的库存不能大于库存量");
                RaisePropertyChanged("PtUpdate");
            }
        }

        private double _PdUpdate;
        /// <summary>
        /// 钯金修改的库存数量
        /// </summary>
        public double PdUpdate
        {
            get { return _PdUpdate; }
            set
            {
                _PdUpdate = value;
                if (value < 0 && Math.Abs(value) > (double)Pd)
                    throw new ArgumentException("减少的库存不能大于库存量");
                RaisePropertyChanged("PdUpdate");
            }
        }
    }
}
