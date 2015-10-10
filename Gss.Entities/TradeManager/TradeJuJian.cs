using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gss.Entities.TradeManager
{
    /// <summary>
    /// 居间
    /// </summary>
    public class TradeJuJian:BaseInfo
    {
        /*
        private string _OrgName;
        /// <summary>
        /// 会员名称
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

        private double _Qichu;
        /// <summary>
        /// 期初
        /// </summary>
        public double Qichu
        {
            get { return _Qichu; }
            set
            {
                _Qichu = value;
                RaisePropertyChanged("Qichu");
            }
        }

        private double _RuJin;
        /// <summary>
        /// 入金
        /// </summary>
        public double RuJin
        {
            get { return _RuJin; }
            set
            {
                _RuJin = value;
                RaisePropertyChanged("RuJin");
            }
        }
        private double _ChuJin;
        /// <summary>
        /// 出金
        /// </summary>
        public double ChuJin
        {
            get { return _ChuJin; }
            set
            {
                _ChuJin = value;
                RaisePropertyChanged("ChuJin");
            }
        }

        private double _Manual_rujin;
        /// <summary>
        /// 调节入金
        /// </summary>
        public double Manual_rujin
        {
            get { return _Manual_rujin; }
            set
            {
                _Manual_rujin = value;
                RaisePropertyChanged("Manual_rujin");
            }
        }

        private double _Manual_chujin;
        /// <summary>
        /// 调节出金
        /// </summary>
        public double Manual_chujin
        {
            get { return _Manual_chujin; }
            set
            {
                _Manual_chujin = value;
                RaisePropertyChanged("Manual_chujin");
            }
        }

        private double _Hisyingkui;
        /// <summary>
        /// 盈亏
        /// </summary>
        public double Hisyingkui
        {
            get { return _Hisyingkui; }
            set
            {
                _Hisyingkui = value;
                RaisePropertyChanged("Hisyingkui");
            }
        }

        private double _Tradefee;
        /// <summary>
        /// 基础工费
        /// </summary>
        public double Tradefee
        {
            get { return _Tradefee; }
            set
            {
                _Tradefee = value;
                RaisePropertyChanged("Tradefee");
            }
        }
        private double _storagefee;
        /// <summary>
        /// 仓储费
        /// </summary>
        public double storagefee
        {
            get { return _storagefee; }
            set
            {
                _storagefee = value;
                RaisePropertyChanged("storagefee");
            }
        }

        private double _qimo;
        /// <summary>
        /// 期末
        /// </summary>
        public double qimo
        {
            get { return _qimo; }
            set
            {
                _qimo = value;
                RaisePropertyChanged("qimo");
            }
        }
        private double _Money;
        /// <summary>
        /// 当前余额
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

        private double _KC_XAG_100kg_Num;
        /// <summary>
        /// 开仓白银100克
        /// </summary>
        public double KC_XAG_100kg_Num
        {
            get { return _KC_XAG_100kg_Num; }
            set
            {
                _KC_XAG_100kg_Num = value;
                RaisePropertyChanged("KC_XAG_100kg_Num");
            }
        }

        private double _XAG_100kg_Num;
        /// <summary>
        /// 平仓白银100克
        /// </summary>
        public double XAG_100kg_Num
        {
            get { return _XAG_100kg_Num; }
            set
            {
                _XAG_100kg_Num = value;
                RaisePropertyChanged("XAG_100kg_Num");
            }
        }

        private double _KC_XAG_50kg_Num;
        /// <summary>
        /// 开仓白银50克
        /// </summary>
        public double KC_XAG_50kg_Num
        {
            get { return _KC_XAG_50kg_Num; }
            set
            {
                _KC_XAG_50kg_Num = value;
                RaisePropertyChanged("KC_XAG_50kg_Num");
            }
        }

        private double _XAG_50kg_Num;
        /// <summary>
        /// 平仓白银50克
        /// </summary>
        public double XAG_50kg_Num
        {
            get { return _XAG_50kg_Num; }
            set
            {
                _XAG_50kg_Num = value;
                RaisePropertyChanged("XAG_50kg_Num");
            }
        }

        private double _KC_XAG_20kg_Num;
        /// <summary>
        /// 开仓白银20克
        /// </summary>
        public double KC_XAG_20kg_Num
        {
            get { return _KC_XAG_20kg_Num; }
            set
            {
                _KC_XAG_20kg_Num = value;
                RaisePropertyChanged("KC_XAG_20kg_Num");
            }
        }
        private double _XAG_20kg_Num;
        /// <summary>
        /// 平仓白银20克
        /// </summary>
        public double XAG_20kg_Num
        {
            get { return _XAG_20kg_Num; }
            set
            {
                _XAG_20kg_Num = value;
                RaisePropertyChanged("XAG_20kg_Num");
            }
        }
        private double _KC_XAU_1000g_Num;
        /// <summary>
        /// 开仓黄金1千克
        /// </summary>
        public double KC_XAU_1000g_Num
        {
            get { return _KC_XAU_1000g_Num; }
            set
            {
                _KC_XAU_1000g_Num = value;
                RaisePropertyChanged("KC_XAU_1000g_Num");
            }
        }


        private double _XAU_1000g_Num;
        /// <summary>
        /// 平仓黄金1千克
        /// </summary>
        public double XAU_1000g_Num
        {
            get { return _XAU_1000g_Num; }
            set
            {
                _XAU_1000g_Num = value;
                RaisePropertyChanged("XAU_1000g_Num");
            }
        }

        */

        private string
    _orgName;
        /// <summary>
        /// 会员名称 
        /// </summary>
        public string
            OrgName
        {
            get { return _orgName; }
            set
            {
                _orgName = value;
                RaisePropertyChanged("OrgName");
            }
        }

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
        /// 盈亏 
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

        private double
            _xAUUSD_DHAVG_PRICE;
        /// <summary>
        /// XAUUSD买涨平均价
        /// </summary>
        public double
            XAUUSD_DHAVG_PRICE
        {
            get { return _xAUUSD_DHAVG_PRICE; }
            set
            {
                _xAUUSD_DHAVG_PRICE = value;
                RaisePropertyChanged("XAUUSD_DHAVG_PRICE");
            }
        }

        private double
            _xAGUSD_DHAVG_PRICE;
        /// <summary>
        /// XAGUSD买涨平均价
        /// </summary>
        public double
            XAGUSD_DHAVG_PRICE
        {
            get { return _xAGUSD_DHAVG_PRICE; }
            set
            {
                _xAGUSD_DHAVG_PRICE = value;
                RaisePropertyChanged("XAGUSD_DHAVG_PRICE");
            }
        }

        private double
            _xPDUSD_DHAVG_PRICE;
        /// <summary>
        /// XPDUSD买涨平均价
        /// </summary>
        public double
            XPDUSD_DHAVG_PRICE
        {
            get { return _xPDUSD_DHAVG_PRICE; }
            set
            {
                _xPDUSD_DHAVG_PRICE = value;
                RaisePropertyChanged("XPDUSD_DHAVG_PRICE");
            }
        }

        private double
            _xPTUSD_DHAVG_PRICE;
        /// <summary>
        /// XPTUSD买涨平均价
        /// </summary>
        public double
            XPTUSD_DHAVG_PRICE
        {
            get { return _xPTUSD_DHAVG_PRICE; }
            set
            {
                _xPTUSD_DHAVG_PRICE = value;
                RaisePropertyChanged("XPTUSD_DHAVG_PRICE");
            }
        }

        private double
            _copper_DHAVG_PRICE;
        /// <summary>
        /// Copper买涨平均价
        /// </summary>
        public double
            Copper_DHAVG_PRICE
        {
            get { return _copper_DHAVG_PRICE; }
            set
            {
                _copper_DHAVG_PRICE = value;
                RaisePropertyChanged("Copper_DHAVG_PRICE");
            }
        }

        private double
            _uKOil_DHAVG_PRICE;
        /// <summary>
        /// UKOil买涨平均价
        /// </summary>
        public double
            UKOil_DHAVG_PRICE
        {
            get { return _uKOil_DHAVG_PRICE; }
            set
            {
                _uKOil_DHAVG_PRICE = value;
                RaisePropertyChanged("UKOil_DHAVG_PRICE");
            }
        }

        private double
            _eURGBP_DHAVG_PRICE;
        /// <summary>
        /// EURGBP买涨平均价
        /// </summary>
        public double
            EURGBP_DHAVG_PRICE
        {
            get { return _eURGBP_DHAVG_PRICE; }
            set
            {
                _eURGBP_DHAVG_PRICE = value;
                RaisePropertyChanged("EURGBP_DHAVG_PRICE");
            }
        }

        private double
            _eURUSD_DHAVG_PRICE;
        /// <summary>
        /// EURUSD买涨平均价
        /// </summary>
        public double
            EURUSD_DHAVG_PRICE
        {
            get { return _eURUSD_DHAVG_PRICE; }
            set
            {
                _eURUSD_DHAVG_PRICE = value;
                RaisePropertyChanged("EURUSD_DHAVG_PRICE");
            }
        }

        private double
            _gBPUSD_DHAVG_PRICE;
        /// <summary>
        /// GBPUSD买涨平均价
        /// </summary>
        public double
            GBPUSD_DHAVG_PRICE
        {
            get { return _gBPUSD_DHAVG_PRICE; }
            set
            {
                _gBPUSD_DHAVG_PRICE = value;
                RaisePropertyChanged("GBPUSD_DHAVG_PRICE");
            }
        }

        private double
            _uSDCHF_DHAVG_PRICE;
        /// <summary>
        /// USDCHF买涨平均价
        /// </summary>
        public double
            USDCHF_DHAVG_PRICE
        {
            get { return _uSDCHF_DHAVG_PRICE; }
            set
            {
                _uSDCHF_DHAVG_PRICE = value;
                RaisePropertyChanged("USDCHF_DHAVG_PRICE");
            }
        }

        private double
            _uSDJPY_DHAVG_PRICE;
        /// <summary>
        /// USDJPY买涨平均价
        /// </summary>
        public double
            USDJPY_DHAVG_PRICE
        {
            get { return _uSDJPY_DHAVG_PRICE; }
            set
            {
                _uSDJPY_DHAVG_PRICE = value;
                RaisePropertyChanged("USDJPY_DHAVG_PRICE");
            }
        }

        private double
            _uSDOLLAR_DHAVG_PRICE;
        /// <summary>
        /// USDOLLAR买涨平均价
        /// </summary>
        public double
            USDOLLAR_DHAVG_PRICE
        {
            get { return _uSDOLLAR_DHAVG_PRICE; }
            set
            {
                _uSDOLLAR_DHAVG_PRICE = value;
                RaisePropertyChanged("USDOLLAR_DHAVG_PRICE");
            }
        }

        private double
            _xAUUSD_HSAVG_PRICE;
        /// <summary>
        /// XAUUSD回收平均价
        /// </summary>
        public double
            XAUUSD_HSAVG_PRICE
        {
            get { return _xAUUSD_HSAVG_PRICE; }
            set
            {
                _xAUUSD_HSAVG_PRICE = value;
                RaisePropertyChanged("XAUUSD_HSAVG_PRICE");
            }
        }

        private double
            _xAGUSD_HSAVG_PRICE;
        /// <summary>
        /// XAGUSD回收平均价
        /// </summary>
        public double
            XAGUSD_HSAVG_PRICE
        {
            get { return _xAGUSD_HSAVG_PRICE; }
            set
            {
                _xAGUSD_HSAVG_PRICE = value;
                RaisePropertyChanged("XAGUSD_HSAVG_PRICE");
            }
        }

        private double
            _xPDUSD_HSAVG_PRICE;
        /// <summary>
        /// XPDUSD回收平均价
        /// </summary>
        public double
            XPDUSD_HSAVG_PRICE
        {
            get { return _xPDUSD_HSAVG_PRICE; }
            set
            {
                _xPDUSD_HSAVG_PRICE = value;
                RaisePropertyChanged("XPDUSD_HSAVG_PRICE");
            }
        }

        private double
            _xPTUSD_HSAVG_PRICE;
        /// <summary>
        /// XPTUSD回收平均价
        /// </summary>
        public double
            XPTUSD_HSAVG_PRICE
        {
            get { return _xPTUSD_HSAVG_PRICE; }
            set
            {
                _xPTUSD_HSAVG_PRICE = value;
                RaisePropertyChanged("XPTUSD_HSAVG_PRICE");
            }
        }

        private double
            _copper_HSAVG_PRICE;
        /// <summary>
        /// Copper回收平均价
        /// </summary>
        public double
            Copper_HSAVG_PRICE
        {
            get { return _copper_HSAVG_PRICE; }
            set
            {
                _copper_HSAVG_PRICE = value;
                RaisePropertyChanged("Copper_HSAVG_PRICE");
            }
        }

        private double
            _uKOil_HSAVG_PRICE;
        /// <summary>
        /// UKOil回收平均价
        /// </summary>
        public double
            UKOil_HSAVG_PRICE
        {
            get { return _uKOil_HSAVG_PRICE; }
            set
            {
                _uKOil_HSAVG_PRICE = value;
                RaisePropertyChanged("UKOil_HSAVG_PRICE");
            }
        }

        private double
            _eURGBP_HSAVG_PRICE;
        /// <summary>
        /// EURGBP回收平均价
        /// </summary>
        public double
            EURGBP_HSAVG_PRICE
        {
            get { return _eURGBP_HSAVG_PRICE; }
            set
            {
                _eURGBP_HSAVG_PRICE = value;
                RaisePropertyChanged("EURGBP_HSAVG_PRICE");
            }
        }

        private double
            _eURUSD_HSAVG_PRICE;
        /// <summary>
        /// EURUSD回收平均价
        /// </summary>
        public double
            EURUSD_HSAVG_PRICE
        {
            get { return _eURUSD_HSAVG_PRICE; }
            set
            {
                _eURUSD_HSAVG_PRICE = value;
                RaisePropertyChanged("EURUSD_HSAVG_PRICE");
            }
        }

        private double
            _gBPUSD_HSAVG_PRICE;
        /// <summary>
        /// GBPUSD回收平均价
        /// </summary>
        public double
            GBPUSD_HSAVG_PRICE
        {
            get { return _gBPUSD_HSAVG_PRICE; }
            set
            {
                _gBPUSD_HSAVG_PRICE = value;
                RaisePropertyChanged("GBPUSD_HSAVG_PRICE");
            }
        }

        private double
            _uSDCHF_HSAVG_PRICE;
        /// <summary>
        /// USDCHF回收平均价
        /// </summary>
        public double
            USDCHF_HSAVG_PRICE
        {
            get { return _uSDCHF_HSAVG_PRICE; }
            set
            {
                _uSDCHF_HSAVG_PRICE = value;
                RaisePropertyChanged("USDCHF_HSAVG_PRICE");
            }
        }

        private double
            _uSDJPY_HSAVG_PRICE;
        /// <summary>
        /// USDJPY回收平均价
        /// </summary>
        public double
            USDJPY_HSAVG_PRICE
        {
            get { return _uSDJPY_HSAVG_PRICE; }
            set
            {
                _uSDJPY_HSAVG_PRICE = value;
                RaisePropertyChanged("USDJPY_HSAVG_PRICE");
            }
        }

        private double
            _uSDOLLAR_HSAVG_PRICE;
        /// <summary>
        /// USDOLLAR回收平均价
        /// </summary>
        public double
            USDOLLAR_HSAVG_PRICE
        {
            get { return _uSDOLLAR_HSAVG_PRICE; }
            set
            {
                _uSDOLLAR_HSAVG_PRICE = value;
                RaisePropertyChanged("USDOLLAR_HSAVG_PRICE");
            }
        }

        private double
            _xAUUSD_DH_NUM;
        /// <summary>
        /// XAUUSD买涨数量
        /// </summary>
        public double
            XAUUSD_DH_NUM
        {
            get { return _xAUUSD_DH_NUM; }
            set
            {
                _xAUUSD_DH_NUM = value;
                RaisePropertyChanged("XAUUSD_DH_NUM");
            }
        }

        private double
            _xAGUSD_DH_NUM;
        /// <summary>
        /// XAGUSD买涨数量
        /// </summary>
        public double
            XAGUSD_DH_NUM
        {
            get { return _xAGUSD_DH_NUM; }
            set
            {
                _xAGUSD_DH_NUM = value;
                RaisePropertyChanged("XAGUSD_DH_NUM ");
            }
        }

        private double
            _xPDUSD_DH_NUM;
        /// <summary>
        /// XPDUSD买涨数量
        /// </summary>
        public double
            XPDUSD_DH_NUM
        {
            get { return _xPDUSD_DH_NUM; }
            set
            {
                _xPDUSD_DH_NUM = value;
                RaisePropertyChanged("XPDUSD_DH_NUM ");
            }
        }

        private double
            _xPTUSD_DH_NUM;
        /// <summary>
        /// XPTUSD买涨数量
        /// </summary>
        public double
            XPTUSD_DH_NUM
        {
            get { return _xPTUSD_DH_NUM; }
            set
            {
                _xPTUSD_DH_NUM = value;
                RaisePropertyChanged("XPTUSD_DH_NUM ");
            }
        }

        private double
            _copper_DH_NUM;
        /// <summary>
        /// Copper买涨数量
        /// </summary>
        public double
            Copper_DH_NUM
        {
            get { return _copper_DH_NUM; }
            set
            {
                _copper_DH_NUM = value;
                RaisePropertyChanged("Copper_DH_NUM ");
            }
        }

        private double
            _uKOil_DH_NUM;
        /// <summary>
        /// UKOil买涨数量
        /// </summary>
        public double
            UKOil_DH_NUM
        {
            get { return _uKOil_DH_NUM; }
            set
            {
                _uKOil_DH_NUM = value;
                RaisePropertyChanged("UKOil_DH_NUM  ");
            }
        }

        private double
            _eURGBP_DH_NUM;
        /// <summary>
        /// EURGBP买涨数量
        /// </summary>
        public double
            EURGBP_DH_NUM
        {
            get { return _eURGBP_DH_NUM; }
            set
            {
                _eURGBP_DH_NUM = value;
                RaisePropertyChanged("EURGBP_DH_NUM ");
            }
        }

        private double
            _eURUSD_DH_NUM;
        /// <summary>
        /// EURUSD买涨数量
        /// </summary>
        public double
            EURUSD_DH_NUM
        {
            get { return _eURUSD_DH_NUM; }
            set
            {
                _eURUSD_DH_NUM = value;
                RaisePropertyChanged("EURUSD_DH_NUM ");
            }
        }

        private double
            _gBPUSD_DH_NUM;
        /// <summary>
        /// GBPUSD买涨数量
        /// </summary>
        public double
            GBPUSD_DH_NUM
        {
            get { return _gBPUSD_DH_NUM; }
            set
            {
                _gBPUSD_DH_NUM = value;
                RaisePropertyChanged("GBPUSD_DH_NUM ");
            }
        }

        private double
            _uSDCHF_DH_NUM;
        /// <summary>
        /// USDCHF买涨数量
        /// </summary>
        public double
            USDCHF_DH_NUM
        {
            get { return _uSDCHF_DH_NUM; }
            set
            {
                _uSDCHF_DH_NUM = value;
                RaisePropertyChanged("USDCHF_DH_NUM ");
            }
        }

        private double
            _uSDJPY_DH_NUM;
        /// <summary>
        /// USDJPY买涨数量
        /// </summary>
        public double
            USDJPY_DH_NUM
        {
            get { return _uSDJPY_DH_NUM; }
            set
            {
                _uSDJPY_DH_NUM = value;
                RaisePropertyChanged("USDJPY_DH_NUM ");
            }
        }

        private double
            _uSDOLLAR_DH_NUM;
        /// <summary>
        /// USDOLLAR买涨数量
        /// </summary>
        public double
            USDOLLAR_DH_NUM
        {
            get { return _uSDOLLAR_DH_NUM; }
            set
            {
                _uSDOLLAR_DH_NUM = value;
                RaisePropertyChanged("USDOLLAR_DH_NUM");
            }
        }

        private double
            _xAUUSD_HS_NUM;
        /// <summary>
        /// XAUUSD回收数量
        /// </summary>
        public double
            XAUUSD_HS_NUM
        {
            get { return _xAUUSD_HS_NUM; }
            set
            {
                _xAUUSD_HS_NUM = value;
                RaisePropertyChanged("XAUUSD_HS_NUM ");
            }
        }

        private double
            _xAGUSD_HS_NUM;
        /// <summary>
        /// XAGUSD回收数量
        /// </summary>
        public double
            XAGUSD_HS_NUM
        {
            get { return _xAGUSD_HS_NUM; }
            set
            {
                _xAGUSD_HS_NUM = value;
                RaisePropertyChanged("XAGUSD_HS_NUM ");
            }
        }

        private double
            _xPDUSD_HS_NUM;
        /// <summary>
        /// XPDUSD回收数量
        /// </summary>
        public double
            XPDUSD_HS_NUM
        {
            get { return _xPDUSD_HS_NUM; }
            set
            {
                _xPDUSD_HS_NUM = value;
                RaisePropertyChanged("XPDUSD_HS_NUM ");
            }
        }

        private double
            _xPTUSD_HS_NUM;
        /// <summary>
        /// XPTUSD回收数量
        /// </summary>
        public double
            XPTUSD_HS_NUM
        {
            get { return _xPTUSD_HS_NUM; }
            set
            {
                _xPTUSD_HS_NUM = value;
                RaisePropertyChanged("XPTUSD_HS_NUM ");
            }
        }

        private double
            _copper_HS_NUM;
        /// <summary>
        /// Copper回收数量
        /// </summary>
        public double
            Copper_HS_NUM
        {
            get { return _copper_HS_NUM; }
            set
            {
                _copper_HS_NUM = value;
                RaisePropertyChanged("Copper_HS_NUM ");
            }
        }

        private double
            _uKOil_HS_NUM;
        /// <summary>
        /// UKOil回收数量
        /// </summary>
        public double
            UKOil_HS_NUM
        {
            get { return _uKOil_HS_NUM; }
            set
            {
                _uKOil_HS_NUM = value;
                RaisePropertyChanged("UKOil_HS_NUM  ");
            }
        }

        private double
            _eURGBP_HS_NUM;
        /// <summary>
        /// EURGBP回收数量
        /// </summary>
        public double
            EURGBP_HS_NUM
        {
            get { return _eURGBP_HS_NUM; }
            set
            {
                _eURGBP_HS_NUM = value;
                RaisePropertyChanged("EURGBP_HS_NUM ");
            }
        }

        private double
            _eURUSD_HS_NUM;
        /// <summary>
        /// EURUSD回收数量
        /// </summary>
        public double
            EURUSD_HS_NUM
        {
            get { return _eURUSD_HS_NUM; }
            set
            {
                _eURUSD_HS_NUM = value;
                RaisePropertyChanged("EURUSD_HS_NUM ");
            }
        }

        private double
            _gBPUSD_HS_NUM;
        /// <summary>
        /// GBPUSD回收数量
        /// </summary>
        public double
            GBPUSD_HS_NUM
        {
            get { return _gBPUSD_HS_NUM; }
            set
            {
                _gBPUSD_HS_NUM = value;
                RaisePropertyChanged("GBPUSD_HS_NUM ");
            }
        }

        private double
            _uSDCHF_HS_NUM;
        /// <summary>
        /// USDCHF回收数量
        /// </summary>
        public double
            USDCHF_HS_NUM
        {
            get { return _uSDCHF_HS_NUM; }
            set
            {
                _uSDCHF_HS_NUM = value;
                RaisePropertyChanged("USDCHF_HS_NUM ");
            }
        }

        private double
            _uSDJPY_HS_NUM;
        /// <summary>
        /// USDJPY回收数量
        /// </summary>
        public double
            USDJPY_HS_NUM
        {
            get { return _uSDJPY_HS_NUM; }
            set
            {
                _uSDJPY_HS_NUM = value;
                RaisePropertyChanged("USDJPY_HS_NUM ");
            }
        }

        private double
            _uSDOLLAR_HS_NUM;
        /// <summary>
        /// USDOLLAR回收数量
        /// </summary>
        public double
            USDOLLAR_HS_NUM
        {
            get { return _uSDOLLAR_HS_NUM; }
            set
            {
                _uSDOLLAR_HS_NUM = value;
                RaisePropertyChanged("USDOLLAR_HS_NUM");
            }
        }

        private double _Yingkui;
        /// <summary>
        /// 浮动盈亏
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
    }
}
