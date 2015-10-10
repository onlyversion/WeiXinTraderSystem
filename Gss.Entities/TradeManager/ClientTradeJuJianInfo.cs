using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Gss.Entities.TradeManager
{
    /// <summary>
    /// 会员报表信息
    /// </summary>
    public class ClientTradeJuJianInfo:BaseInfo
    {
        public ClientTradeJuJianInfo()
        {
            TradeJuJianLst = new ObservableCollection<TradeJuJian>();
        }
        private bool _Result;
        /// <summary>
        /// 返回结果
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
        /// 返回描述
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

        private ObservableCollection<TradeJuJian> _TradeJuJianLst;
        /// <summary>
        /// 居间列表
        /// </summary>
        public ObservableCollection<TradeJuJian> TradeJuJianLst
        {
            get { return _TradeJuJianLst; }
            set
            {
                _TradeJuJianLst = value;
                RaisePropertyChanged("TradeJuJianLst");
            }
        }

        #region 统计列
        private double
          _qichu;
        /// <summary>
        /// 期初 
        /// </summary>
        public double
            Qichu
        {
            get { return _qichu; }
            set
            {
                _qichu = value;
                RaisePropertyChanged("Qichu");
            }
        }

        private double
            _rujin;
        /// <summary>
        /// 入金 
        /// </summary>
        public double
            Rujin
        {
            get { return _rujin; }
            set
            {
                _rujin = value;
                RaisePropertyChanged("Rujin");
            }
        }

        private double
            _chujin;
        /// <summary>
        /// 出金 
        /// </summary>
        public double
            Chujin
        {
            get { return _chujin; }
            set
            {
                _chujin = value;
                RaisePropertyChanged("Chujin");
            }
        }

        private double
            _manual_rujin;
        /// <summary>
        /// 手工调帐入金
        /// </summary>
        public double
            Manual_rujin
        {
            get { return _manual_rujin; }
            set
            {
                _manual_rujin = value;
                RaisePropertyChanged("Manual_rujin");
            }
        }

        private double
            _manual_chujin;
        /// <summary>
        /// 手工调帐出金 
        /// </summary>
        public double
            Manual_chujin
        {
            get { return _manual_chujin; }
            set
            {
                _manual_chujin = value;
                RaisePropertyChanged("Manual_chujin");
            }
        }

        private double
            _hisyingkui;
        /// <summary>
        /// 统计
        /// </summary>
        public double
            Hisyingkui
        {
            get { return _hisyingkui; }
            set
            {
                _hisyingkui = value;
                RaisePropertyChanged("Hisyingkui");
            }
        }

        private double
            _tradefee;
        /// <summary>
        /// 基础工费 
        /// </summary>
        public double
            Tradefee
        {
            get { return _tradefee; }
            set
            {
                _tradefee = value;
                RaisePropertyChanged("Tradefee");
            }
        }

        private double
            _storagefee;
        /// <summary>
        /// 仓储费 
        /// </summary>
        public double
            Storagefee
        {
            get { return _storagefee; }
            set
            {
                _storagefee = value;
                RaisePropertyChanged("Storagefee");
            }
        }

        private double
            _qimo;
        /// <summary>
        /// 期末 
        /// </summary>
        public double
            Qimo
        {
            get { return _qimo; }
            set
            {
                _qimo = value;
                RaisePropertyChanged("Qimo");
            }
        }

        private double
            _money;
        /// <summary>
        /// 当前余额 
        /// </summary>
        public double
            Money
        {
            get { return _money; }
            set
            {
                _money = value;
                RaisePropertyChanged("Money");
            }
        }

        private double
            _kC_XAG_100kg_Num;
        /// <summary>
        /// 开仓（白银100千克） 
        /// </summary>
        public double
            KC_XAG_100kg_Num
        {
            get { return _kC_XAG_100kg_Num; }
            set
            {
                _kC_XAG_100kg_Num = value;
                RaisePropertyChanged("KC_XAG_100kg_Num");
            }
        }

        private double
            _xAG_100kg_Num;
        /// <summary>
        /// 平仓（白银100千克） 
        /// </summary>
        public double
            XAG_100kg_Num
        {
            get { return _xAG_100kg_Num; }
            set
            {
                _xAG_100kg_Num = value;
                RaisePropertyChanged("XAG_100kg_Num");
            }
        }

        private double
            _kC_XAG_50kg_Num;
        /// <summary>
        /// 开仓（白银50千克） 
        /// </summary>
        public double
            KC_XAG_50kg_Num
        {
            get { return _kC_XAG_50kg_Num; }
            set
            {
                _kC_XAG_50kg_Num = value;
                RaisePropertyChanged("KC_XAG_50kg_Num");
            }
        }

        private double
            _xAG_50kg_Num;
        /// <summary>
        /// 平仓（白银50千克） 
        /// </summary>
        public double
            XAG_50kg_Num
        {
            get { return _xAG_50kg_Num; }
            set
            {
                _xAG_50kg_Num = value;
                RaisePropertyChanged("XAG_50kg_Num");
            }
        }

        private double
            _kC_XAG_20kg_Num;
        /// <summary>
        /// 开仓（白银20千克） 
        /// </summary>
        public double
            KC_XAG_20kg_Num
        {
            get { return _kC_XAG_20kg_Num; }
            set
            {
                _kC_XAG_20kg_Num = value;
                RaisePropertyChanged("KC_XAG_20kg_Num");
            }
        }

        private double
            _xAG_20kg_Num;
        /// <summary>
        /// 平仓（白银20千克） 
        /// </summary>
        public double
            XAG_20kg_Num
        {
            get { return _xAG_20kg_Num; }
            set
            {
                _xAG_20kg_Num = value;
                RaisePropertyChanged("XAG_20kg_Num");
            }
        }

        private double
            _kC_XAU_1000g_Num;
        /// <summary>
        /// 开仓（黄金1千克） 
        /// </summary>
        public double
            KC_XAU_1000g_Num
        {
            get { return _kC_XAU_1000g_Num; }
            set
            {
                _kC_XAU_1000g_Num = value;
                RaisePropertyChanged("KC_XAU_1000g_Num");
            }
        }

        private double
            _xAU_1000g_Num;
        /// <summary>
        /// 平仓（黄金1千克） 
        /// </summary>
        public double
            XAU_1000g_Num
        {
            get { return _xAU_1000g_Num; }
            set
            {
                _xAU_1000g_Num = value;
                RaisePropertyChanged("XAU_1000g_Num");
            }
        }

        private double
            _kC_XPT_1000g_Num;
        /// <summary>
        /// 开仓（铂金1千克） 
        /// </summary>
        public double
            KC_XPT_1000g_Num
        {
            get { return _kC_XPT_1000g_Num; }
            set
            {
                _kC_XPT_1000g_Num = value;
                RaisePropertyChanged("KC_XPT_1000g_Num");
            }
        }

        private double
            _xPT_1000g_Num;
        /// <summary>
        /// 平仓（铂金1千克） 
        /// </summary>
        public double
            XPT_1000g_Num
        {
            get { return _xPT_1000g_Num; }
            set
            {
                _xPT_1000g_Num = value;
                RaisePropertyChanged("XPT_1000g_Num");
            }
        }

        private double
            _kC_XPD_1000g_Num;
        /// <summary>
        /// 开仓（钯金1千克） 
        /// </summary>
        public double
            KC_XPD_1000g_Num
        {
            get { return _kC_XPD_1000g_Num; }
            set
            {
                _kC_XPD_1000g_Num = value;
                RaisePropertyChanged("KC_XPD_1000g_Num");
            }
        }

        private double
            _xPD_1000g_Num;
        /// <summary>
        /// 平仓（钯金1千克） 
        /// </summary>
        public double
            XPD_1000g_Num
        {
            get { return _xPD_1000g_Num; }
            set
            {
                _xPD_1000g_Num = value;
                RaisePropertyChanged("XPD_1000g_Num");
            }
        }

        private double
            _kC_Copper_50t_Num;
        /// <summary>
        /// 开仓（铜50吨） 
        /// </summary>
        public double
            KC_Copper_50t_Num
        {
            get { return _kC_Copper_50t_Num; }
            set
            {
                _kC_Copper_50t_Num = value;
                RaisePropertyChanged("KC_Copper_50t_Num");
            }
        }

        private double
            _copper_50t_Num;
        /// <summary>
        /// 平仓（铜50吨） 
        /// </summary>
        public double
            Copper_50t_Num
        {
            get { return _copper_50t_Num; }
            set
            {
                _copper_50t_Num = value;
                RaisePropertyChanged("Copper_50t_Num");
            }
        }

        private double
            _kC_Copper_20t_Num;
        /// <summary>
        /// 开仓（铜20吨） 
        /// </summary>
        public double
            KC_Copper_20t_Num
        {
            get { return _kC_Copper_20t_Num; }
            set
            {
                _kC_Copper_20t_Num = value;
                RaisePropertyChanged("KC_Copper_20t_Num");
            }
        }

        private double
            _copper_20t_Num;
        /// <summary>
        /// 平仓（铜20吨） 
        /// </summary>
        public double
            Copper_20t_Num
        {
            get { return _copper_20t_Num; }
            set
            {
                _copper_20t_Num = value;
                RaisePropertyChanged("Copper_20t_Num");
            }
        }

        private double
            _kC_UKOil_100_Num;
        /// <summary>
        /// 开仓（原油100吨） 
        /// </summary>
        public double
            KC_UKOil_100_Num
        {
            get { return _kC_UKOil_100_Num; }
            set
            {
                _kC_UKOil_100_Num = value;
                RaisePropertyChanged("KC_UKOil_100_Num");
            }
        }

        private double
            _uKOil_100_Num;
        /// <summary>
        /// 平仓（原油100吨） 
        /// </summary>
        public double
            UKOil_100_Num
        {
            get { return _uKOil_100_Num; }
            set
            {
                _uKOil_100_Num = value;
                RaisePropertyChanged("UKOil_100_Num");
            }
        }

        private double
            _kC_UKOil_50_Num;
        /// <summary>
        /// 开仓（原油50吨） 
        /// </summary>
        public double
            KC_UKOil_50_Num
        {
            get { return _kC_UKOil_50_Num; }
            set
            {
                _kC_UKOil_50_Num = value;
                RaisePropertyChanged("KC_UKOil_50_Num");
            }
        }

        private double
            _uKOil_50_Num;
        /// <summary>
        /// 平仓（原油50吨） 
        /// </summary>
        public double
            UKOil_50_Num
        {
            get { return _uKOil_50_Num; }
            set
            {
                _uKOil_50_Num = value;
                RaisePropertyChanged("UKOil_50_Num");
            }
        }

        private double
            _kC_UKOil_20_Num;
        /// <summary>
        /// 开仓（原油20吨）
        /// </summary>
        public double
            KC_UKOil_20_Num
        {
            get { return _kC_UKOil_20_Num; }
            set
            {
                _kC_UKOil_20_Num = value;
                RaisePropertyChanged("KC_UKOil_20_Num");
            }
        }

        private double
            _uKOil_20_Num;
        /// <summary>
        /// 平仓（原油20吨）
        /// </summary>
        public double
            UKOil_20_Num
        {
            get { return _uKOil_20_Num; }
            set
            {
                _uKOil_20_Num = value;
                RaisePropertyChanged("UKOil_20_Num");
            }
        }

        private double _Yingkui;
        /// <summary>
        /// 浮动盈亏统计
        /// </summary>
        public double Yingkui
        {
            get { return _Yingkui; }
            set
            {
                _Yingkui = value;
                RaisePropertyChanged("Yingkui");
            }
        }

        #endregion



    }
}
