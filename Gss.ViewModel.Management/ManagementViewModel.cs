using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using Gss.BusinessService;
using Gss.Common.Infrastructure;
using Gss.Common.Utility;
using Gss.Entities;
using Gss.Entities.AccountManager.Account;
using Gss.Entities.BzjEntities;
using Gss.Entities.DataManager;
using Gss.Entities.Enums;
using Gss.Entities.Interface;
using Gss.Entities.TradeManager;
using Gss.PopUpWindow;
using Gss.PopUpWindow.AccountManager;
using Gss.PopUpWindow.DataManager;
using Gss.PopUpWindow.SystemSetting;
using Gss.StockQuotations;
using Gss.TradeService;
using Microsoft.Win32;
using Gss.Entities.SystemSetting;
using Gss.BzjService;
using Gss.Entities.JTWEntityes;
using Gss.Entities.AccountManager;
using System.Windows.Media;
using Gss.PopUpWindow.TradeManager;

namespace Gss.ViewModel.Management
{
    public partial class ManagementViewModel : ObservableObject, IDisposable
    {
        Object lockobj;//会员报表 查询线程 和 改变浮动盈亏的线程 之间的 线程同步对象

        #region 查询条件
        private SelectCondition _InterOfficeSelectCondtion;
        /// <summary>
        /// 会员报表查询条件
        /// </summary>
        public SelectCondition InterOfficeSelectCondtion
        {
            get { return _InterOfficeSelectCondtion; }
            set
            {
                _InterOfficeSelectCondtion = value;
                RaisePropertyChanged("InterOfficeSelectCondtion");
            }
        }



        private SelectCondition _ClientAccountSelectCondition;
        /// <summary>
        /// 客户账户查询条件
        /// </summary>
        public SelectCondition ClientAccountSelectCondition
        {
            get { return _ClientAccountSelectCondition; }
            private set
            {
                _ClientAccountSelectCondition = value;
                RaisePropertyChanged("ClientAccountSelectCondition");
            }
        }
        private SelectCondition _OnlineAccountSelectCondition;
        /// <summary>
        /// 在线账户查询条件
        /// </summary>
        public SelectCondition OnlineAccountSelectCondition
        {
            get { return _OnlineAccountSelectCondition; }
            private set
            {
                _OnlineAccountSelectCondition = value;
                RaisePropertyChanged("OnlineAccountSelectCondition");
            }
        }

        private SelectCondition _ManagerAccountSelectCondition;
        /// <summary>
        /// 管理员账户查询条件
        /// </summary>
        public SelectCondition ManagerAccountSelectCondition
        {
            get { return _ManagerAccountSelectCondition; }
            private set
            {
                _ManagerAccountSelectCondition = value;
                RaisePropertyChanged("ManagerAccountSelectCondition");
            }
        }

        private SelectCondition _OrgAccountSelectCondition;
        /// <summary>
        /// 会员账户查询条件
        /// </summary>
        public SelectCondition OrgAccountSelectCondition
        {
            get { return _OrgAccountSelectCondition; }
            private set
            {
                _OrgAccountSelectCondition = value;
                RaisePropertyChanged("OrgAccountSelectCondition");
            }
        }

        private SelectCondition _ChuJinSelectCondition;
        /// <summary>
        /// 出金处理查询条件
        /// </summary>
        public SelectCondition ChuJinSelectCondition
        {
            get { return _ChuJinSelectCondition; }
            private set
            {
                _ChuJinSelectCondition = value;
                RaisePropertyChanged("ChuJinSelectCondition");
            }
        }

        private SelectCondition _TerminationSelectCondition;
        /// <summary>
        /// 解约处理查询条件
        /// </summary>
        public SelectCondition TerminationSelectCondition
        {
            get { return _TerminationSelectCondition; }
            set
            {
                _TerminationSelectCondition = value;
                RaisePropertyChanged("TerminationSelectCondition");
            }
        }


        private SelectCondition _FundReportSelectCondition;
        /// <summary>
        /// 资金报表查询条件
        /// </summary>
        public SelectCondition FundReportSelectCondition
        {
            get { return _FundReportSelectCondition; }
            private set
            {
                _FundReportSelectCondition = value;
                RaisePropertyChanged("FundReportSelectCondition");
            }
        }


        #endregion

        #region 成员
        /// <summary>
        /// 后台管理部分WCF服务接口
        /// </summary>
        private IBusinessServiceProvider _businessService;

        /// <summary>
        /// 交易部分WCF服务接口
        /// </summary>
        private ITradeServiceProvider _tradeService;

        /// <summary>
        /// 行情分发类
        /// </summary>
        private StockQuotationsDistribution _quotation;

        /// <summary>
        /// 登陆标识
        /// </summary>
        private string _loginID;

        /// <summary>
        /// 金商账户名，仅店员登录时有效
        /// </summary>
        private string _ClerkAgentId;

        /// <summary>
        /// 登陆账户名
        /// </summary>
        private string _accName;
        /// <summary>
        /// 登陆账户名
        /// </summary>
        public string AccName
        {
            get { return _accName; }
            set
            {
                _accName = value;
                RaisePropertyChanged("AccName");
            }
        }

        /// <summary>
        /// 登陆账户类别，管理员或金商
        /// </summary>
        private ACCOUNT_TYPE _accType;

        /// <summary>
        /// 判断是否在UI线程的对象
        /// </summary>
        private DispatcherObject _dpObj;

        /// <summary>
        /// 静态单例对象
        /// </summary>
        private static ManagementViewModel _singleInstances;

        /// <summary>
        /// 行情地址
        /// </summary>
        private string _quotationAddr;

        /// <summary>
        /// 行情端口
        /// </summary>
        private int _quotationPort;
        #endregion

        #region 委托
        /// <summary>
        /// 定单列表
        /// </summary>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">结束时间</param>
        private delegate void GetClientOrderList(DateTime sTime, DateTime eTime);

        /// <summary>
        /// 客户账户操作委托，添加或删除
        /// </summary>
        /// <param name="clientAcc">要添加或删除的客户账户</param>
        private delegate void ClientAccountDelegate(ClientAccount clientAcc);
        /// <summary>
        /// 添加客户账户列表委托
        /// </summary>
        /// <param name="clientList">要添加的客户账户列表</param>
        private delegate void AddClientListDelegate(List<ClientAccount> clientList);

        /// <summary>
        /// 金商账户操作委托，添加或删除
        /// </summary>
        /// <param name="dealerAcc">要添加或删除的金商账户</param>
        private delegate void DealerAccountDelegate(DealerAccount dealerAcc);
        /// <summary>
        /// 添加金商列表委托
        /// </summary>
        /// <param name="clientList">要添加的金商账户列表</param>
        private delegate void AddDealerListDelegate(List<DealerAccount> dealerList);

        /// <summary>
        /// 管理员账户操作委托，添加或删除
        /// </summary>
        /// <param name="mgrAcc">要添加或删除的管理员账户</param>
        private delegate void ManagerAccountDeleaget(ManagerAccount mgrAcc);
        /// <summary>
        /// 添加管理员列表委托
        /// </summary>
        /// <param name="clientList">要添加的管理员账户列表</param>
        private delegate void AddManagerListDelegate(List<ManagerAccount> mgrList);

        /// <summary>
        /// 添加交易日信息列表委托
        /// </summary>
        /// <param name="infoList">要添加的交易日信息列表</param>
        private delegate void AddTradingDayInfoListDelegate(List<TradingDayInformation> infoList);

        /// <summary>
        /// 节假日信息操作委托，添加或删除
        /// </summary>
        /// <param name="holidayInfo">要添加或删除的节假日信息</param>
        private delegate void HolidayInfoDelegate(HolidayInformation holidayInfo);
        /// <summary>
        /// 添加节假日信息列表委托
        /// </summary>
        /// <param name="infoList">要添加的节假日信息列表</param>
        private delegate void AddHolidayInfoListDelegate(List<HolidayInformation> infoList);

        /// <summary>
        /// 添加日志信息列表委托
        /// </summary>
        /// <param name="infoList">要添加的日志信息列表</param>
        private delegate void AddLogInfoListDeleage(List<LogInformation> infoList);

        /// <summary>
        /// IP地址过滤信息操作委托，添加或删除
        /// </summary>
        /// <param name="ipAddrFilterInfo">要添加或删除的IP地址过滤信息</param>
        private delegate void IPAddrFilterInfoDelegate(IPAddressFilterInformation ipAddrFilterInfo);
        /// <summary>
        /// 添加IP地址过滤信息列表委托
        /// </summary>
        /// <param name="infoList">要添加的IP地址过滤信息列表</param>
        private delegate void AddIPAddrFilterInfoListDelegate(List<IPAddressFilterInformation> infoList);

        /// <summary>
        /// MAC地址过滤信息操作委托，添加或删除
        /// </summary>
        /// <param name="macFilterInfo">要添加或删除的MAC地址过滤信息</param>
        private delegate void MACFilterInfoDelegate(MACFilterInformation macFilterInfo);
        /// <summary>
        /// 添加MAC地址过滤信息列表委托
        /// </summary>
        /// <param name="infoList">要添加的MAC地址过滤信息列表</param>
        private delegate void AddMACFilterInfoListDelegate(List<MACFilterInformation> infoList);

        /// <summary>
        /// 商品信息操作委托，添加或删除
        /// </summary>
        /// <param name="productInfo">要添加或删除的商品信息</param>
        private delegate void ProductInfoDelegate(ProductInformation productInfo);
        /// <summary>
        /// 添加商品信息列表委托
        /// </summary>
        /// <param name="infoList">要添加的商品信息列表</param>
        private delegate void AddProductInfoListDelegate(List<ProductInformation> infoList);

        /// <summary>
        /// 汇率和水信息委托，添加或删除
        /// </summary>
        /// <param name="rateWaterInfo">要添加或删除的汇率和水信息</param>
        private delegate void RateWaterInfoDelegate(ExchangeRateWaterInformation rateWaterInfo);
        /// <summary>
        /// 添加汇率和水信息列表委托
        /// </summary>
        /// <param name="infoList">要添加的汇率和水信息列表</param>
        private delegate void AddRateWaterInfoListDelegate(List<ExchangeRateWaterInformation> infoList);

        /// <summary>
        /// 有效定单操作委托，添加或删除
        /// </summary>
        /// <param name="marketOrder">要添加或删除的有效定单</param>
        private delegate void MarketOrderDataDelegate(MarketOrderData marketOrder);
        /// <summary>
        /// 添加有效定单列表委托
        /// </summary>
        /// <param name="orderList">要添加的有效定单列表</param>
        private delegate void AddMarketOrderListDelegate(List<MarketOrderData> orderList);

        /// <summary>
        ///  限价挂单操作委托，添加或删除
        /// </summary>
        /// <param name="pendingOrder">要添加或删除的限价挂单</param>
        private delegate void PendingOrderDataDelegate(PendingOrderData pendingOrder);
        /// <summary>
        /// 添加限价挂单列表委托
        /// </summary>
        /// <param name="orderList">要添加的限价挂单列表</param>
        private delegate void AddPendingOrderListDelegate(List<PendingOrderData> orderList);
        /// <summary>
        /// 添加对冲交易列表委托
        /// </summary>
        /// <param name="hedgingList">要添加的对冲交易列表</param>
        private delegate void AddHedgingTradeListDelegate(List<HedgingTradeData> hedgingList);
        #endregion

        #region 属性
        private ClientTradeJuJianInfo _TradeJuJianInfo;
        /// <summary>
        /// 居间信息
        /// </summary>
        public ClientTradeJuJianInfo TradeJuJianInfo
        {
            get { return _TradeJuJianInfo; }
            set
            {
                _TradeJuJianInfo = value;
                RaisePropertyChanged("TradeJuJianInfo");
            }
        }

        private ClientHedgingInfo _HedgingInfo;
        /// <summary>
        /// 对冲列表
        /// </summary>
        public ClientHedgingInfo HedgingInfo
        {
            get { return _HedgingInfo; }
            set
            {
                _HedgingInfo = value;
                RaisePropertyChanged("HedgingInfo");
            }
        }

        private ClientUserBaseInfo _UserBaseInfo;
        /// <summary>
        /// 客户管理分页查询结果
        /// </summary>
        public ClientUserBaseInfo UserBaseInfo
        {
            get { return _UserBaseInfo; }
            set
            {
                _UserBaseInfo = value;
                RaisePropertyChanged("UserBaseInfo");
            }
        }


        private ClientUserBaseInfo _OnLineUserBaseInfo;
        /// <summary>
        /// 客户在线分页查询结果
        /// </summary>
        public ClientUserBaseInfo OnLineUserBaseInfo
        {
            get { return _OnLineUserBaseInfo; }
            set
            {
                _OnLineUserBaseInfo = value;
                RaisePropertyChanged("OnLineUserBaseInfo");
            }
        }

        private ClientTradeOrderInfo _TradeOrderInfo;
        /// <summary>
        /// 有效订单分页查询结果
        /// </summary>
        public ClientTradeOrderInfo TradeOrderInfo
        {
            get { return _TradeOrderInfo; }
            set
            {
                _TradeOrderInfo = value;
                RaisePropertyChanged("TradeOrderInfo");
            }
        }
        private ClientTradeHoldOrderInfo _TradeHoldOrderInfo;
   
       /// <summary>
       /// 挂单分页查询结果
       /// </summary>
        public ClientTradeHoldOrderInfo TradeHoldOrderInfo
        {
            get { return _TradeHoldOrderInfo; }
            set
            {
                _TradeHoldOrderInfo = value;
                RaisePropertyChanged("TradeHoldOrderInfo");
            }
        }

        private ClientLTradeOrderInfo _LTradeOrderInfo;
        /// <summary>
        /// 平仓历史分页查询结果
        /// </summary>
        public ClientLTradeOrderInfo LTradeOrderInfo
        {
            get { return _LTradeOrderInfo; }
            set
            {
                _LTradeOrderInfo = value;
                RaisePropertyChanged("LTradeOrderInfo");
            }
        }
        private ClientTradeChuJinInfo _TradeChuJinInfo;
        /// <summary>
        /// 出金分页查询结果
        /// </summary>
        public ClientTradeChuJinInfo TradeChuJinInfo
        {
            get { return _TradeChuJinInfo; }
            set
            {
                _TradeChuJinInfo = value;
                RaisePropertyChanged("TradeChuJinInfo");
            }
        }

        private ClientFundChangeInfo _FundChangeInfo;
        /// <summary>
        /// 资金明细分页查询结果
        /// </summary>
        public ClientFundChangeInfo FundChangeInfo
        {
            get { return _FundChangeInfo; }
            set
            {
                _FundChangeInfo = value;
                RaisePropertyChanged("FundChangeInfo");
            }
        }


        /// <summary>
        /// 获取后台管理ViewMode唯一实例
        /// </summary>
        public static ManagementViewModel GetInstances
        {
            get
            {
                if (_singleInstances == null)
                    _singleInstances = new ManagementViewModel();

                return _singleInstances;
            }
        }

        public string mainWindowTitle;
        /// <summary>
        /// 应用程序标题
        /// </summary>
        public string MainWindowTitle
        {
            get { return mainWindowTitle; }
            private set
            {
                mainWindowTitle = value;
                RaisePropertyChanged("MainWindowTitle");
            }
        }

        #region 当前登录账户的权限
        /// <summary>
        /// 获取当前登陆账户的权限信息
        /// </summary>
        private UserPrivilegesInfo _AccountAuthority;
        /// <summary>
        /// 获取当前登陆账户的权限信息
        /// </summary>
        public UserPrivilegesInfo AccountAuthority
        {
            get { return _AccountAuthority; }
            private set
            {
                _AccountAuthority = value;
                RaisePropertyChanged("AccountAuthority");
            }
        }

        #endregion

        #region 账户管理部分
       
        private ObservableCollection<ClientAccount> _clientAccountListList;
        /// <summary>
        /// 获取用户账户列表
        /// </summary>
        public ObservableCollection<ClientAccount> ClientAccountList
        {
            get { return _clientAccountListList; }
            private set
            {
                _clientAccountListList = value;
                RaisePropertyChanged("ClientAccountList");
            }
        }

        /// <summary>
        /// 获取查询客户账户的过滤信息
        /// </summary>
        public ClientAccountFilter ClientAccFilter { get; private set; }

        private ObservableCollection<ClientAccount> _dealerAccountList;
        /// <summary>
        /// 会员账户列表
        /// </summary>
        public ObservableCollection<ClientAccount> DealerAccountList
        {
            get { return _dealerAccountList; }
            private set
            {
                _dealerAccountList = value;
                RaisePropertyChanged("DealerAccountList");
            }
        }

        /// <summary>
        /// 获取查询在线客户账户的过滤信息
        /// </summary>
        public ClientAccountFilter OnlineClientAccFilter { get; private set; }

        private ObservableCollection<ClientAccount> _managerAccountList;
        /// <summary>
        /// 获取管理员账户列表
        /// </summary>
        public ObservableCollection<ClientAccount> ManagerAccountList
        {
            get { return _managerAccountList; }
            private set
            {
                _managerAccountList = value;
                RaisePropertyChanged("ManagerAccountList");
            }
        }

        private ObservableCollection<ClientAccount> _onlineClientListAccList;
        /// <summary>
        /// 获取在线客户列表
        /// </summary>
        public ObservableCollection<ClientAccount> OnlineClientList
        {
            get { return _onlineClientListAccList; }
            private set
            {
                _onlineClientListAccList = value;
                RaisePropertyChanged("OnlineClientList");
            }
        }

        private bool _isLoadingClientList;
        /// <summary>
        /// 获取是否正在加载客户列表
        /// </summary>
        public bool IsLoadingClientList
        {
            get { return _isLoadingClientList; }
            private set
            {
                _isLoadingClientList = value;
                RaisePropertyChanged("IsLoadingClientList");
            }
        }

        private bool _isLoadingDealerList;

        /// <summary>
        /// 获取是否正在加载金商列表
        /// </summary>
        public bool IsLoadingDealerList
        {
            get { return _isLoadingDealerList; }
            private set
            {
                _isLoadingDealerList = value;
                RaisePropertyChanged("IsLoadingDealerList");
            }
        }

        private bool _isLoadingManagerList;
        /// <summary>
        /// 获取是否正在加载管理员列表
        /// </summary>
        public bool IsLoadingManagerList
        {
            get { return _isLoadingManagerList; }
            private set
            {
                _isLoadingManagerList = value;
                RaisePropertyChanged("IsLoadingManagerList");
            }
        }

        private bool _isLoadingOnlineClientList;

        /// <summary>
        /// 获取是否正在加载在线人员列表
        /// </summary>
        public bool IsLoadingOnlineClientList
        {
            get { return _isLoadingOnlineClientList; }
            private set
            {
                _isLoadingOnlineClientList = value;
                RaisePropertyChanged("IsLoadingOnlineClientList");
            }
        }
        #endregion

        #region 交易管理部分
        private ObservableCollection<MarketOrderData> _marketOrderList;
        /// <summary>
        /// 获取有效定单列表
        /// </summary>
        public ObservableCollection<MarketOrderData> MarketOrderList
        {
            get { return _marketOrderList; }
            private set
            {
                _marketOrderList = value;
                RaisePropertyChanged("MarketOrderList");
            }
        }

        /// <summary>
        /// 获取有效定单查询信息
        /// </summary>
        public RequestInformationBase MarketOrderRequestInfo { get; private set; }

        private ObservableCollection<PendingOrderData> _pendingOrderList;
        /// <summary>
        /// 获取限价挂单列表
        /// </summary>
        public ObservableCollection<PendingOrderData> PendingOrderList
        {
            get { return _pendingOrderList; }
            private set
            {
                _pendingOrderList = value;
                RaisePropertyChanged("PendingOrderList");
            }
        }

        /// <summary>
        /// 获取限价挂单查询信息
        /// </summary>
        public RequestInformationBase PendingOrderRequestInfo { get; private set; }

        private ObservableCollection<HedgingTradeData> _hedgingTradeList;
        /// <summary>
        /// 获取对冲记录列表
        /// </summary>
        public ObservableCollection<HedgingTradeData> HedgingTradeList
        {
            get { return _hedgingTradeList; }
            private set
            {
                _hedgingTradeList = value;
                RaisePropertyChanged("HedgingTradeList");
            }
        }

        /// <summary>
        /// 获取对冲交易历史记录查询信息
        /// </summary>
        public RequestInformationBase HedgingTradeRequestInfo { get; private set; }
        /// <summary>
        /// 获取报表查询信息
        /// </summary>
        public StatementsRequestInformation StatementsRequestInfo { get; private set; }

        private bool _isLoadingMarketOrderList;
        /// <summary>
        /// 获取是否正在加载有效定单列表
        /// </summary>
        public bool IsLoadingMarketOrderList
        {
            get { return _isLoadingMarketOrderList; }
            private set
            {
                _isLoadingMarketOrderList = value;
                RaisePropertyChanged("IsLoadingMarketOrderList");
            }
        }

        private bool _isLoadingPendingOrderList;
        /// <summary>
        /// 获取是否正在加载限价挂单列表
        /// </summary>
        public bool IsLoadingPendingOrderList
        {
            get { return _isLoadingPendingOrderList; }
            private set
            {
                _isLoadingPendingOrderList = value;
                RaisePropertyChanged("IsLoadingPendingOrderList");
            }
        }

        private bool _isLoadingWarehousingHistory;
        /// <summary>
        /// 获取是否正在加载入库单历史记录
        /// </summary>
        public bool IsLoadingWarehousingHistory
        {
            get { return _isLoadingWarehousingHistory; }
            private set
            {
                _isLoadingWarehousingHistory = value;
                RaisePropertyChanged("IsLoadingWarehousingHistory");
            }
        }

        private bool _isLoadingChargebackRecode;
        /// <summary>
        /// 获取是否正在加载平仓历史记录
        /// </summary>
        public bool IsLoadingChargebackRecode
        {
            get { return _isLoadingChargebackRecode; }
            private set
            {
                _isLoadingChargebackRecode = value;
                RaisePropertyChanged("IsLoadingChargebackRecode");
            }
        }

        private bool _isLoadingHedgingTradeList;
        /// <summary>
        /// 获取是否正在加载对冲交易历史记录
        /// </summary>
        public bool IsLoadingHedgingTradeList
        {
            get { return _isLoadingHedgingTradeList; }
            private set
            {
                _isLoadingHedgingTradeList = value;
                RaisePropertyChanged("IsLoadingHedgingTradeList");
            }
        }

        private bool _isLoadingStatements;
        /// <summary>
        /// 获取是否正在下载报表
        /// </summary>
        public bool IsLoadingStatements
        {
            get { return _isLoadingStatements; }
            private set
            {
                _isLoadingStatements = value;
                RaisePropertyChanged("IsLoadingStatements");
            }
        }
        #endregion

        #region 系统设置部分
        private ObservableCollection<TradingDayInformation> _tradingDayInfoes;
        /// <summary>
        /// 获取交易日列表
        /// </summary>
        public ObservableCollection<TradingDayInformation> TradingDayInfoes
        {
            get { return _tradingDayInfoes; }
            private set
            {
                _tradingDayInfoes = value;
                RaisePropertyChanged("TradingDayInfoes");
            }
        }

        private ObservableCollection<HolidayInformation> _holidayInfoes;
        /// <summary>
        /// 获取节假日信息列表
        /// </summary>
        public ObservableCollection<HolidayInformation> HolidayInfoes
        {
            get { return _holidayInfoes; }
            private set
            {
                _holidayInfoes = value;
                RaisePropertyChanged("HolidayInfoes");
            }
        }

        //private TradingSettingInformation _tradingSettingInfo;
        ///// <summary>
        ///// 获取交易设置信息
        ///// </summary>
        //public TradingSettingInformation TradingSettingInfo
        //{
        //    get { return _tradingSettingInfo; }
        //    private set
        //    {
        //        _tradingSettingInfo = value;
        //        RaisePropertyChanged("TradingSettingInfo");
        //        if (value != null)
        //            TradingSettingInfoBackup.Sync(value);
        //    }
        //}

        //private TradingSettingInformation _tradingSettingInfoBackup;
        ///// <summary>
        ///// 获取交易设置的备份信息
        ///// </summary>
        //public TradingSettingInformation TradingSettingInfoBackup
        //{
        //    get
        //    {
        //        if (_tradingSettingInfoBackup == null)
        //            _tradingSettingInfoBackup = new TradingSettingInformation();

        //        return _tradingSettingInfoBackup;
        //    }
        //    private set
        //    {
        //        _tradingSettingInfoBackup = value;
        //        RaisePropertyChanged("TradingSettingInfoBackup");
        //    }
        //}

        private ObservableCollection<LogInformation> _logInfoes;

        /// <summary>
        /// 获取日志信息列表
        /// </summary>
        public ObservableCollection<LogInformation> LogInfoes
        {
            get { return _logInfoes; }
            private set
            {
                _logInfoes = value;
                RaisePropertyChanged("LogInfoes");
            }
        }

        /// <summary>
        /// 获取日志请求信息
        /// </summary>
        public LogRequestInformation LogRequestInfo { get; private set; }

        private ObservableCollection<IPAddressFilterInformation> _ipFilterInfoes;
        /// <summary>
        /// 获取IP地址过滤列表
        /// </summary>
        public ObservableCollection<IPAddressFilterInformation> IPAddrFilterInfoes
        {
            get { return _ipFilterInfoes; }
            private set
            {
                _ipFilterInfoes = value;
                RaisePropertyChanged("IPAddrFilterInfoes");
            }
        }

        private ObservableCollection<MACFilterInformation> _macFilterInfoes;
        /// <summary>
        /// 获取MAC过滤信息列表
        /// </summary>
        public ObservableCollection<MACFilterInformation> MACFilterInfoes
        {
            get { return _macFilterInfoes; }
            private set
            {
                _macFilterInfoes = value;
                RaisePropertyChanged("MACFilterInfoes");
            }
        }

        private ObservableCollection<TradeConfigInfo> _TradeConfigInfoList;
        /// <summary>
        /// 获取交易设置列表
        /// </summary>
        public ObservableCollection<TradeConfigInfo> TradeConfigInfoList
        {
            get { return _TradeConfigInfoList; }
            private set
            {
                _TradeConfigInfoList = value;
                RaisePropertyChanged("TradeConfigInfoList");
            }
        }

        private bool _isLoadingTradingDayInfo;
        /// <summary>
        /// 获取是否正在加载交易日信息
        /// </summary>
        public bool IsLoadingTradingDayInfo
        {
            get { return _isLoadingTradingDayInfo; }
            private set
            {
                _isLoadingTradingDayInfo = value;
                RaisePropertyChanged("IsLoadingTradingDayInfo");
            }
        }

        private bool _isLoadingHolidayInfo;
        /// <summary>
        /// 获取是否正在加载节假日信息列表
        /// </summary>
        public bool IsLoadingHolidayInfo
        {
            get { return _isLoadingHolidayInfo; }
            private set
            {
                _isLoadingHolidayInfo = value;
                RaisePropertyChanged("IsLoadingHolidayInfo");
            }
        }

        private bool _isLoadingLogInfo;
        /// <summary>
        /// 获取是否正在加载日志信息
        /// </summary>
        public bool IsLoadingLogInfo
        {
            get { return _isLoadingLogInfo; }
            private set
            {
                _isLoadingLogInfo = value;
                RaisePropertyChanged("IsLoadingLogInfo");
            }
        }

        private bool _isloadingTradingSettingInfo;
        /// <summary>
        /// 获取是否正在加载交易设置信息
        /// </summary>
        public bool IsLoadingTradingSettingInfo
        {
            get { return _isloadingTradingSettingInfo; }
            private set
            {
                _isloadingTradingSettingInfo = value;
                RaisePropertyChanged("IsLoadingTradingSettingInfo");
            }
        }

        private bool _isLoadingIPAddrFilterInfo;
        /// <summary>
        /// 获取是否正在加载IP地址过滤列表
        /// </summary>
        public bool IsLoadingIPAddrFilter
        {
            get { return _isLoadingIPAddrFilterInfo; }
            private set
            {
                _isLoadingIPAddrFilterInfo = value;
                RaisePropertyChanged("IsLoadingIPAddrFilter");
            }
        }

        private bool _isLoadingMACFilterInfo;
        /// <summary>
        /// 获取是否正在加载MAC过滤列表
        /// </summary>
        public bool IsLoadingMACFilterInfo
        {
            get { return _isLoadingMACFilterInfo; }
            private set
            {
                _isLoadingMACFilterInfo = value;
                RaisePropertyChanged("IsLoadingMACFilterInfo");
            }
        }
        #endregion

        #region 数据管理部分
        private ObservableCollection<ProductInformation> _productInfoes;
        /// <summary>
        /// 获取商品列表
        /// </summary>
        public ObservableCollection<ProductInformation> ProductInfoes
        {
            get { return _productInfoes; }
            private set
            {
                _productInfoes = value;
                RaisePropertyChanged("ProductInfoes");
            }
        }

        private ObservableCollection<ExchangeRateWaterInformation> _rateWaterInfoes;
        /// <summary>
        /// 获取汇率和水信息列表
        /// </summary>
        public ObservableCollection<ExchangeRateWaterInformation> RateWaterInfoes
        {
            get { return _rateWaterInfoes; }
            private set
            {
                _rateWaterInfoes = value;
                RaisePropertyChanged("RateWaterInfoes");
            }
        }

        private bool _isLoadingProductInfoList;
        /// <summary>
        /// 获取是否正在加载商品信息列表
        /// </summary>
        public bool IsLoadingProductInfoList
        {
            get { return _isLoadingProductInfoList; }
            private set
            {
                _isLoadingProductInfoList = value;
                RaisePropertyChanged("IsLoadingProductInfoList");
            }
        }

        private bool _isLoadingRateWaterInfoList;
        /// <summary>
        /// 获取是否正在加载汇率和水信息列表
        /// </summary>
        public bool IsLoadingRateWaterInfoList
        {
            get { return _isLoadingRateWaterInfoList; }
            private set
            {
                _isLoadingRateWaterInfoList = value;
                RaisePropertyChanged("IsLoadingRateWaterInfoList");
            }
        }
        #endregion

        #endregion

        private ObservableCollection<TradeChuJinInformation> _ChuJinList;
        /// <summary>
        /// 出金信息列表
        /// </summary>
        public ObservableCollection<TradeChuJinInformation> ChuJinList
        {
            get { return _ChuJinList; }
            private set
            {
                _ChuJinList = value;
                RaisePropertyChanged("ChuJinList");
            }
        }

        private ObservableCollection<TradeJieYue> _TradeJieYueLst;
        /// <summary>
        /// 解约列表
        /// </summary>
        public ObservableCollection<TradeJieYue> TradeJieYueLst
        {
            get { return _TradeJieYueLst; }
            set
            {
                _TradeJieYueLst = value;
                RaisePropertyChanged("TradeJieYueLst");
            }
        }

        private TradeJieYue _CurJieYue;
        /// <summary>
        /// 解约列表当前选中项
        /// </summary>
        public TradeJieYue CurJieYue
        {
            get { return _CurJieYue; }
            set
            {
                _CurJieYue = value;
                RaisePropertyChanged("CurJieYue");
            }
        }


        private ObservableCollection<FundChangeInformation> _FundReportList;
        /// <summary>
        /// 资金报表信息列表
        /// </summary>
        public ObservableCollection<FundChangeInformation> FundReportList
        {
            get { return _FundReportList; }
            private set
            {
                _FundReportList = value;
                RaisePropertyChanged("FundReportList");
            }
        }

        

        private TradeChuJinInformation _CurChuJin;
        /// <summary>
        /// 当前选中的出金数据
        /// </summary>
        public TradeChuJinInformation CurChuJin
        {
            get { return _CurChuJin; }
            set
            {
                _CurChuJin = value;
                RaisePropertyChanged("CurChuJin");
            }
        }


        #region 构造函数
        /// <summary>
        /// 实例化一个后台管理View Mode对象
        /// </summary>
        private ManagementViewModel()
        {
            lockobj = new Object();
            _TradeJuJianInfo = new ClientTradeJuJianInfo();
            _dpObj = new DependencyObject();
            LogRequestInfo = new LogRequestInformation();

            ClientAccFilter = new ClientAccountFilter();
            OnlineClientAccFilter = new ClientAccountFilter();
            MarketOrderRequestInfo = new RequestInformationBase();
            PendingOrderRequestInfo = new RequestInformationBase();
            HedgingTradeRequestInfo = new RequestInformationBase();
            StatementsRequestInfo = new StatementsRequestInformation();

            _businessService = new BusinessServiceProvider();
            _tradeService = new TradeServiceProvider();
            _bzjService = new BzjServiceProvider();

           // GetNewsCondition = new SelectCondition();

            _BzjInfoInformation = new BzjInfoInformation();
            TakeGoodsDetialSelectCondition = new SelectCondition();

            _TakeGoodsDetailList = new ObservableCollection<BzjTakeGoodsDetailEntity>();
            BindingJgjAccountCondition = new SelectCondition();

            _DeliveryGoodsCondition = new SelectCondition();
            _DeliveryGoodsList = new ObservableCollection<BzjDeliverEntity>();

            _TakeGoodsCondition = new SelectCondition();
            _TakeGoodsList = new ObservableCollection<BzjOrderEntity>();

            _BackGoodsCondition = new SelectCondition();
            _BackGoodsList = new ObservableCollection<BzjOrderEntity>();

            _JgjGoodsCondition = new SelectCondition();
            _JgjGoodsList = new ObservableCollection<BzjOrderEntity>();

            _DeliveryBackGoodsCondition = new SelectCondition();
            _DeliveryBackGoodsList = new List<BzjRecoverOrder>();

            _GetClerkCondition = new SelectCondition();
            _ClerkAccountList = new ObservableCollection<BzjClerk>();
            InterOfficeSelectCondtion = new SelectCondition();
            ClientAccountSelectCondition = new SelectCondition();
            OnlineAccountSelectCondition = new SelectCondition();
            ManagerAccountSelectCondition = new SelectCondition();
            OrgAccountSelectCondition = new SelectCondition();
            FundReportSelectCondition = new SelectCondition();
            OrgSelectCondition = new SelectCondition();
            ChuJinSelectCondition = new SelectCondition();
            TerminationSelectCondition = new SelectCondition();
            TradeConfigInfoList = new ObservableCollection<TradeConfigInfo>();


            NewsList = new ObservableCollection<NewsInfo>();
            ArtilesList = new ObservableCollection<NewsInfo>();
            GetNewsCondition = new SelectCondition();
            GetArticlesCondition = new SelectCondition();

            FundReportList = new ObservableCollection<FundChangeInformation>();
            ChuJinList = new ObservableCollection<TradeChuJinInformation>();
            OrgList = new ObservableCollection<OrgInfo>();

            UserGroups = new ObservableCollection<UserGroup>();
            UserGroupSelectCon = new SelectCondition();
            GroupAccounts = new ObservableCollection<ClientAccount>();
        }

        #endregion

        #region 命令
        #region 账户管理部分命令
        #region 获取客户账户
        private ICommand _GetClientAccountCommand;
        /// <summary>
        /// 获取客户账户的命令
        /// </summary>
        public ICommand GetClientAccountCommand
        {
            get
            {
                if (_GetClientAccountCommand == null)
                    _GetClientAccountCommand = new RelayCommand(GetUserBaseInfoWithPage);

                return _GetClientAccountCommand;
            }
        }
        #region 客户资料分页查询 马友春
        public bool CanGetUserBaseInfoWithPage = true;
        /// <summary>
        /// 客户资料分页查询
        /// </summary>
        /// <param name="Cxqc">查询条件</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="pagesize">输出参数：总页数</param>
        /// <param name="page">返回列表</param>
        /// <returns></returns>
        public void GetUserBaseInfoWithPage()
        {
            if (CanGetUserBaseInfoWithPage == false)
            {
                return;
            }
          
            UserQueryConInfomation uqc = new UserQueryConInfomation
            {
                LoginID = _loginID,
                TradeAccount = ClientAccountSelectCondition.Account,
                UserName = ClientAccountSelectCondition.UserName,
                CardNum = ClientAccountSelectCondition.CardNum,
                OrgName = ClientAccountSelectCondition.OrgName,
                UserTypeInfo = UserTypeInfo.NormalType,
                TelPhone=ClientAccountSelectCondition.Phone,
                StartTime = ClientAccountSelectCondition.StartTime,
                Broker = ClientAccountSelectCondition.Broker,
                EndTime = ClientAccountSelectCondition.EndTime.AddDays(1)
            };
            if (string.IsNullOrEmpty(ClientAccountSelectCondition.IsBroker) || ClientAccountSelectCondition.IsBroker=="全部")
            {
                uqc.IsBroker = "0";
            }
            else if (ClientAccountSelectCondition.IsBroker == "是")
                uqc.IsBroker = "1";
            else
                uqc.IsBroker = "2";
                 
            int pageCount = 0;
            UserBaseInfo = _businessService.GetUserBaseInfoWithPage(uqc, ClientAccountSelectCondition.PageIndex, ClientAccountSelectCondition.PageSize, ref pageCount);

            if (UserBaseInfo.Result)
            {
                ClientAccountSelectCondition.PageCount = pageCount;
            }
            else
            {
                MessageBox.Show(UserBaseInfo.Desc, "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
            }


        }
        ///// <summary>
        ///// 客户资料分页查询
        ///// </summary>
        ///// <param name="Cxqc">查询条件</param>
        ///// <param name="pageindex">当前页</param>
        ///// <param name="pagesize">页大小</param>
        ///// <param name="pagesize">输出参数：总页数</param>
        ///// <param name="page">返回列表</param>
        ///// <returns></returns>
        //public void GetUserBaseInfoWithPage()
        //{
        //    UserQueryConInfomation uqc = new UserQueryConInfomation
        //    {
        //        LoginID = _loginID,
        //        TradeAccount = ClientAccountSelectCondition.Account,
        //        UserName = ClientAccountSelectCondition.UserName,
        //        CardNum = ClientAccountSelectCondition.CardNum,
        //        OrgName = ClientAccountSelectCondition.OrgName,
        //        UserTypeInfo = UserTypeInfo.NormalType,
               
        //    };
        //    List<ClientAccount> clientList;
        //    if (ClientAccountList != null && ClientAccountList.Count > 0)
        //        ClientAccountList.Clear();
        //    else
        //        ClientAccountList = new ObservableCollection<ClientAccount>();
        //    int pageCount = 0;
            
        //    ErrType err = _businessService.GetUserBaseInfoWithPage(uqc, ClientAccountSelectCondition.PageIndex, ClientAccountSelectCondition.PageSize,
        //        ref pageCount, out clientList);
        //    if (err == GeneralErr.Success)
        //    {
        //        if (clientList != null)
        //        {
        //            clientList.ForEach(item => ClientAccountList.Add(item));
        //        }
        //        ClientAccountSelectCondition.PageCount = pageCount;
        //    }
        //    else
        //    {
        //        MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }
        //}
        #endregion
        #endregion

        #region 创建客户账户命令
        private ICommand _createClientAccountCmd;
        /// <summary>
        /// 获取创建客户账户的命令
        /// </summary>
        public ICommand CreateClientAccountCmd
        {
            get
            {
                if (_createClientAccountCmd == null)
                    _createClientAccountCmd = new RelayCommand(CreateClientAccountExecute);

                return _createClientAccountCmd;
            }
        }



        private ICommand _createClientAccountCmd2;
        /// <summary>
        /// 获取创建客户账户的命令
        /// </summary>
        public ICommand CreateClientAccountCmd2
        {
            get
            {
                if (_createClientAccountCmd2 == null)
                    _createClientAccountCmd2 = new RelayCommand(CreatClientAccountEx2);

                return _createClientAccountCmd2;
            }
        }
        /// <summary>
        /// 新增客户账号
        /// </summary>
        private void CreateClientAccountExecute()
        {
            CreateAccount(UserTypeInfo.NormalType);
        }
        ClientAccount newClient;
        ClientAccountInfoWindow clientView;
        /// <summary>
        /// 添加客户账户
        /// </summary>
        private void CreatClientAccountEx2()
        {
             newClient = CreateClientAcc();
             clientView = new ClientAccountInfoWindow
            {
                POrgList=this.POrgList,
                Owner = Application.Current.MainWindow,
                DataContext = newClient,
                CreateMode = true,
                Banks=this.Banks
            };
            clientView.ComitEvent = AddClient;
            clientView.ShowDialog();

        }

        private void AddClient()
        {
            if (string.IsNullOrEmpty(newClient.FundsInfo.banktype))
            {
                MessageBox.Show("银行类型不能为空，请选择银行类型");
                return;
            }
            newClient.AccInfo.UserID = Guid.NewGuid().ToString("n");
            foreach (var item in this.POrgList)
            {
                if (item.OrgName == newClient.AccInfo.OrgName)
                {
                    newClient.AccInfo.Telephone = item.TelePhone;
                    break;
                }
            }

            FundsInformation fim = new FundsInformation() { OpenBank = newClient.FundsInfo.OpenBank, BankCardNumber = newClient.FundsInfo.BankCardNumber, banktype = newClient.FundsInfo.banktype };
            ErrType err = _businessService.AddClientAccount(newClient, fim, UserTypeInfo.NormalType, _loginID);
            if (err == GeneralErr.Success)
            {
                clientView.Close();

                AddClientAccount(UserBaseInfo.TdUserList, newClient);
            }    
            else
            {

                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void CreateAccount(UserTypeInfo info)
        {
            ClientAccount newClient = CreateClientAcc();
            ClientAccountInfoWindow clientView = new ClientAccountInfoWindow
            {
                POrgList=this.POrgList,
                Owner = Application.Current.MainWindow,
                DataContext = newClient,
                CreateMode = true,
            };

            if (clientView.ShowDialog() == true)
            {
                newClient.AccInfo.UserID = Guid.NewGuid().ToString("n");
                ErrType err = _businessService.AddClientAccount(newClient, info, _loginID);
                if (err == GeneralErr.Success)
                    AddClientAccount(UserBaseInfo.TdUserList, newClient);
                else
                {
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                    CreateClientAccountExecute();
                }

            }
        }
        #endregion

        #region 创建金商账户命令
        private ICommand _createDealerAccountCmd;
        /// <summary>
        /// 创建金商账户的命令
        /// </summary>
        public ICommand CreateDealerAccountCmd
        {
            get
            {
                if (_createDealerAccountCmd == null)
                    _createDealerAccountCmd = new RelayCommand(CreateDealerAccountExecute);
                return _createDealerAccountCmd;
            }
        }
        DealerAccountInfoWindow dealerView;
        private void CreateDealerAccountExecute()
        {
            newClient = CreateClientAcc();
            dealerView = new DealerAccountInfoWindow
            {
                POrgList=this.POrgList,
                //CurOrgInfo=this.POrgList.FirstOrDefault(),
                Owner = Application.Current.MainWindow,
                DataContext = newClient,
                CurOrgInfo=POrgList.FirstOrDefault(),
                CreateMode = true,
            };
            dealerView.ComitEvent += new Action(dealerView_ComitEvent);
           dealerView.ShowDialog();
        }

        void dealerView_ComitEvent()
        {
            if (string.IsNullOrEmpty(dealerView.CurOrgInfo.OrgName))
            {
                MessageBox.Show("所属会员必须选择！", "提示信息", MessageBoxButton.OK);
                return;
            }

            newClient.AccInfo.OrgName = dealerView.CurOrgInfo.OrgName;
            newClient.AccInfo.Telephone = dealerView.CurOrgInfo.TelePhone;
            newClient.AccInfo.UserID = Guid.NewGuid().ToString("n");
            //newClient.AccInfo.OrgName = dealerView.CurOrgInfo.OrgName;
            ErrType err = _businessService.AddClientAccount(newClient, UserTypeInfo.OrgType, _loginID);
            if (err == GeneralErr.Success)
            {
                AddClientAccount(DealerAccountList, newClient);
                dealerView.Close();
            }
                
            else
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        #endregion

        #region 获取金商账户列表
        private ICommand _GetDealerListCommand;
        /// <summary>
        ///获取刷新金商账户列表的命令
        /// </summary>
        public ICommand GetDealerListCommand
        {
            get
            {
                if (_GetDealerListCommand == null)
                    _GetDealerListCommand = new RelayCommand(GetDealerListExecute);

                return _GetDealerListCommand;
            }
        }

        public bool CanGetDealerListExecute { get; set; }
        /// <summary>
        /// 刷新金商账户列表
        /// </summary>
        public void GetDealerListExecute()
        {
            if (CanGetDealerListExecute == false)
            {
                return;
            }
            UserQueryConInfomation uqc = new UserQueryConInfomation
            {
                LoginID = _loginID,
                TradeAccount = OrgAccountSelectCondition.Account,
                UserName = OrgAccountSelectCondition.UserName,
                CardNum = OrgAccountSelectCondition.CardNum,
                OrgName= OrgAccountSelectCondition.OrgName,
                UserTypeInfo = UserTypeInfo.OrgType,

            };
            List<ClientAccount> clientList;
            if (DealerAccountList != null && DealerAccountList.Count > 0)
                DealerAccountList.Clear();
            else
                DealerAccountList = new ObservableCollection<ClientAccount>();
            int pageCount = 0;
            ErrType err = _businessService.GetUserBaseInfoWithPage(uqc, OrgAccountSelectCondition.PageIndex, OrgAccountSelectCondition.PageSize,
                ref pageCount, out clientList);
            if (err == GeneralErr.Success)
            {
                if (clientList != null)
                {
                    clientList.ForEach(item => DealerAccountList.Add(item));
                }
                OrgAccountSelectCondition.PageCount = pageCount;
            }
            else
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region 创建管理员命令
        private ICommand _createManagerAccountCmd;
        /// <summary>
        /// 获取创建管理员的命令
        /// </summary>
        public ICommand CreateManagerAccountCmd
        {
            get
            {
                if (_createManagerAccountCmd == null)
                    _createManagerAccountCmd = new RelayCommand(CreateManagerAccountExecute);
                return _createManagerAccountCmd;
            }
        }
        private void CreateManagerAccountExecute()
        {
            ClientAccount newClient = CreateClientAcc();
            ManagerAccountInfoWindow managerView = new ManagerAccountInfoWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = newClient,
                CreateMode = true,
            };

            if (managerView.ShowDialog() == true)
            {
                newClient.AccInfo.UserID = Guid.NewGuid().ToString("n");
                ErrType err = _businessService.AddClientAccount(newClient, UserTypeInfo.AdminType, _loginID);
                if (err == GeneralErr.Success)
                    AddClientAccount(ManagerAccountList, newClient);
                else
                {
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                    CreateManagerAccountExecute();
                }

            }
        }
        #endregion

        #region 获取管理员账户列表
        private ICommand _GetManagerAccountListCommand;
        /// <summary>
        /// 获取管理员账户列表
        /// </summary>
        public ICommand GetManagerAccountListCommand
        {
            get
            {
                if (_GetManagerAccountListCommand == null)
                    _GetManagerAccountListCommand = new RelayCommand(GetManagerListExecute);

                return _GetManagerAccountListCommand;
            }
        }

        /// <summary>
        /// 获取管理员账户列表（采用异步方式）
        /// </summary>
        public void GetManagerListExecute()
        {
            UserQueryConInfomation uqc = new UserQueryConInfomation
            {
                LoginID = _loginID,
                TradeAccount = ManagerAccountSelectCondition.Account,
                UserName = ManagerAccountSelectCondition.UserName,
                CardNum = ManagerAccountSelectCondition.CardNum,
                UserTypeInfo = UserTypeInfo.AdminType,
            };
            List<ClientAccount> clientList;
            if (ManagerAccountList != null && ManagerAccountList.Count > 0)
                ManagerAccountList.Clear();
            else
                ManagerAccountList = new ObservableCollection<ClientAccount>();
            int pageCount = 0;
            ErrType err = _businessService.GetUserBaseInfoWithPage(uqc, ManagerAccountSelectCondition.PageIndex, ManagerAccountSelectCondition.PageSize,
                ref pageCount, out clientList);
            if (err == GeneralErr.Success)
            {
                if (clientList != null)
                {
                    clientList.ForEach(item => ManagerAccountList.Add(item));
                }
                ManagerAccountSelectCondition.PageCount = pageCount;
            }
            else
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #region 获取在线客户列表
        private ICommand _GetOnlineClientsCommand;
        /// <summary>
        /// 获取在线客户列表命令
        /// </summary>
        public ICommand GetOnlineClientsCommand
        {
            get
            {
                if (_GetOnlineClientsCommand == null)
                    _GetOnlineClientsCommand = new RelayCommand(GetOnlineClientsExecute);

                return _GetOnlineClientsCommand;
            }
        }
        /// <summary>
        /// 获取在线用户列表
        /// </summary>
        public void GetOnlineClientsExecute()
        {
            UserQueryConInfomation uqc = new UserQueryConInfomation
            {
                LoginID = _loginID,
                TradeAccount = OnlineAccountSelectCondition.Account,
                UserName = OnlineAccountSelectCondition.UserName,
                CardNum = OnlineAccountSelectCondition.CardNum,
                UserTypeInfo = UserTypeInfo.NormalType,
                OnLine = true,
            };
            int pageCount = 0;
            OnLineUserBaseInfo = _businessService.GetUserBaseInfoWithPage(uqc, OnlineAccountSelectCondition.PageIndex, OnlineAccountSelectCondition.PageSize, ref pageCount);

            if (OnLineUserBaseInfo.Result)
            {
                OnlineAccountSelectCondition.PageCount = pageCount;
            }
            else
            {
                MessageBox.Show(OnLineUserBaseInfo.Desc, "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        ///// <summary>
        ///// 获取在线用户列表
        ///// </summary>
        //public void GetOnlineClientsExecute()
        //{
        //    UserQueryConInfomation uqc = new UserQueryConInfomation
        //    {
        //        LoginID = _loginID,
        //        TradeAccount = OnlineAccountSelectCondition.Account,
        //        UserName = OnlineAccountSelectCondition.UserName,
        //        CardNum = OnlineAccountSelectCondition.CardNum,
        //        UserTypeInfo = UserTypeInfo.NormalType,
        //        OnLine = true,
        //    };
        //    List<ClientAccount> clientList;
        //    if (OnlineClientList != null && OnlineClientList.Count > 0)
        //        OnlineClientList.Clear();
        //    else
        //        OnlineClientList = new ObservableCollection<ClientAccount>();
        //    int pageCount = 0;
        //    ErrType err = _businessService.GetUserBaseInfoWithPage(uqc, OnlineAccountSelectCondition.PageIndex, OnlineAccountSelectCondition.PageSize,
        //        ref pageCount, out clientList);
        //    if (err == GeneralErr.Success)
        //    {
        //        if (clientList != null)
        //        {
        //            clientList.ForEach(item => OnlineClientList.Add(item));
        //        }
        //        OnlineAccountSelectCondition.PageCount = pageCount;
        //    }
        //    else
        //    {
        //        MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }
        //}

        #endregion

        #endregion

        #region 获取限价挂单列表
        #region 获取对冲记录列表

        private ICommand _getHedgingHistoryListCmd;

        /// <summary>
        /// 获取获取对冲记录列表的命令
        /// </summary>
        public ICommand GetHedgingHistoryListCmd
        {
            get
            {
                if (_getHedgingHistoryListCmd == null)
                    _getHedgingHistoryListCmd = new RelayCommand(GetHedgingHistoryListExecuted, GetHedgingHistoryListCanExecuted);

                return _getHedgingHistoryListCmd;
            }
        }

        /// <summary>
        /// 执行获取对冲记录列表命令的方法（采用异步方式）
        /// </summary>
        private void GetHedgingHistoryListExecuted()
        {
            Action action = GetHedgingTradeList;
            action.BeginInvoke(null, null);
        }

        private bool GetHedgingHistoryListCanExecuted()
        {
            return !IsLoadingHedgingTradeList;
        }

        #endregion

        #region 获取报表

        private ICommand _getExportStatementsCmd;

        /// <summary>
        /// 获取获取报表的命令
        /// </summary>
        public ICommand GetExportStatementsCmd
        {
            get
            {
                if (_getExportStatementsCmd == null)
                    _getExportStatementsCmd = new RelayCommand(GetExportStatementsExecuted, GetExportStatementsCanExecuted);

                return _getExportStatementsCmd;
            }
        }

        /// <summary>
        /// 获取报表命令的执行方法（采用异步方式）
        /// </summary>
        private void GetExportStatementsExecuted()
        {
            Action action = ExportStatements;
            action.BeginInvoke(null, null);
        }

        private bool GetExportStatementsCanExecuted()
        {
            return !IsLoadingStatements && StatementsRequestInfo.StatementsType != STATEMENTS_TYPE.NULL;
        }

        #endregion

        #region 解约
        private ICommand _GetTerminationLstCommand;

        /// <summary>
        /// 获取出金数据命令
        /// </summary>
        public ICommand GetTerminationLstCommand
        {
            get
            {
                if (_GetTerminationLstCommand == null)
                    _GetTerminationLstCommand = new RelayCommand(GetTerminationLstExcuted);

                return _GetTerminationLstCommand;
            }
        }
        #endregion

        #region 获取居间列表命令
        private ICommand _GetJuJianCommand;
        /// <summary>
        /// 获取居间列表命令
        /// </summary>
        public ICommand GetJuJianCommand
        {
            get
            {
                if (_GetJuJianCommand == null)
                    _GetJuJianCommand = new RelayCommand(GetJuJianLstEx);

                return _GetJuJianCommand;
            }
        }
        #endregion

        private ICommand _GetChuJinCommand;

        /// <summary>
        /// 获取出金数据命令
        /// </summary>
        public ICommand GetChuJinCommand
        {
            get
            {
                if (_GetChuJinCommand == null)
                    _GetChuJinCommand = new RelayCommand(GetChuJinExecuted);

                return _GetChuJinCommand;
            }
        }




        private ICommand _ChuJinCommand;

        /// <summary>
        /// 获取出金数据命令
        /// </summary>
        public ICommand ChuJinCommand
        {
            get
            {
                if (_ChuJinCommand == null)
                    _ChuJinCommand = new RelayCommand(ChuJinExecuted);

                return _ChuJinCommand;
            }
        }

        private ICommand _GetFundReportCommand;

        /// <summary>
        /// 获取出金数据命令
        /// </summary>
         public ICommand GetFundReportCommand
        {
            get
            {
                if (_GetFundReportCommand == null)
                    _GetFundReportCommand = new RelayCommand(GetFundReportExecuted);

                return _GetFundReportCommand;
            }
        }

        /// <summary>
        /// 会员报表是否可以重新计算盈亏
        /// </summary>
         public bool CanIterofficeReSetYingKui = false;

        #endregion

        #region 系统设置部分命令
        #region 刷新交易日信息列表
        private ICommand _refreshTradingDayInfoCmd;
        /// <summary>
        /// 获取刷新交易日信息列表的命令
        /// </summary>
        public ICommand RefreshTradingDayInfoCmd
        {
            get
            {
                if (_refreshTradingDayInfoCmd == null)
                    _refreshTradingDayInfoCmd = new RelayCommand(RefreshTradingDayInfoExecute);

                return _refreshTradingDayInfoCmd;
            }
        }

        /// <summary>
        /// 刷新交易日信息列表（采用异步方式）
        /// </summary>
        public void RefreshTradingDayInfoExecute()
        {
            //if (!IsLoadingTradingDayInfo)
            //{
            //    Action action = GetTradingDayInfo;
            //    action.BeginInvoke(null, null);
            //}
        }
        #endregion

        #region 新增节假日信息

        private ICommand _addHolidayInfoCmd;

        /// <summary>
        /// 获取新增节假日信息的命令
        /// </summary>
        public ICommand AddHolidayInfoCmd
        {
            get
            {
                if (_addHolidayInfoCmd == null)
                    _addHolidayInfoCmd = new RelayCommand(AddHolidayInfoExecute, AddHolidayInfoCanExecute);

                return _addHolidayInfoCmd;
            }
        }

        /// <summary>
        /// 执行添加节假日信息命令的方法
        /// </summary>
        public void AddHolidayInfoExecute()
        {
            HolidayInformation holidayInfo = new HolidayInformation();
            List<string> Stockcodes = new List<string>();
            foreach (var item in ProductInfoes)
            {
                if (Stockcodes.Contains(item.StockCode))
                {
                    continue;
                }
                Stockcodes.Add(item.StockCode);
            }
            HolidayInfoWindow wnd = new HolidayInfoWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = holidayInfo,
                Codes = Stockcodes,
               
            };

            if (wnd.ShowDialog() == true)
            {
                ErrType err = _businessService.AddHolidayInfo(_loginID, holidayInfo);
                if (err == GeneralErr.Success)
                    AddHolidayInfo(holidayInfo);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool AddHolidayInfoCanExecute()
        {
            return !IsLoadingHolidayInfo;
        }

        #endregion

        #region 刷新节假日信息列表

        private ICommand _refreshHolidayInfoCmd;

        /// <summary>
        /// 获取刷新节假日信息列表命令
        /// </summary>
        public ICommand RefreshHolidayInfoCmd
        {
            get
            {
                if (_refreshHolidayInfoCmd == null)
                    _refreshHolidayInfoCmd = new RelayCommand(RefreshHolidayInfoExecute);

                return _refreshHolidayInfoCmd;
            }
        }

        /// <summary>
        /// 刷新节假日信息列表（采用异步方式）
        /// </summary>
        public void RefreshHolidayInfoExecute()
        {
            if (!IsLoadingHolidayInfo)
            {
                Action action = GetHolidayInfo;
                action.BeginInvoke(null, null);
            }
        }

        #endregion

        #region 刷新日志信息

        private ICommand _getLogInfoCmd;

        /// <summary>
        /// 获取获取日志信息的命令
        /// </summary>
        public ICommand GetLogInfoCmd
        {
            get
            {
                if (_getLogInfoCmd == null)
                    _getLogInfoCmd = new RelayCommand(GetLogInfoCmdExecute);

                return _getLogInfoCmd;
            }
        }

        /// <summary>
        /// 刷新日志信息列表（采用异步方式）
        /// </summary>
        private void GetLogInfoCmdExecute()
        {
            if (!IsLoadingLogInfo)
            {
                Action action = GetLogInfoList;
                action.BeginInvoke(null, null);
            }
        }

        #endregion

        #region 新增IP过滤地址信息

        private ICommand _addIPAddrFilterInfoCmd;

        /// <summary>
        /// 获取新增IP地址过滤信息的命令
        /// </summary>
        public ICommand AddIPAddrFilterInfoCmd
        {
            get
            {
                if (_addIPAddrFilterInfoCmd == null)
                    _addIPAddrFilterInfoCmd = new RelayCommand(AddIPAddrFilterInfoExecute, AddIPAddrFilterInfoCanExecute);

                return _addIPAddrFilterInfoCmd;
            }
        }

        /// <summary>
        /// 执行添加IP地址过滤信息命令的方法
        /// </summary>
        public void AddIPAddrFilterInfoExecute()
        {
            IPAddressFilterInformation ipInfo = new IPAddressFilterInformation();
            IPAddrFilterInfoWindow wnd = new IPAddrFilterInfoWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = ipInfo,
            };

            if (wnd.ShowDialog() == true)
            {
                ErrType err = _businessService.AddIPAddrFilteringInfo(_loginID, ipInfo);
                if (err == GeneralErr.Success)
                    AddIPAddrFilterInfo(ipInfo);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool AddIPAddrFilterInfoCanExecute()
        {
            return !IsLoadingIPAddrFilter;
        }

        #endregion

        #region 刷新IP地址过滤信息列表

        private ICommand _refreshIPAddrFilterListCmd;

        /// <summary>
        /// 获取刷新IP地址过滤信息列表命令
        /// </summary>
        public ICommand RefreshIPAddrFilterListCmd
        {
            get
            {
                if (_refreshIPAddrFilterListCmd == null)
                    _refreshIPAddrFilterListCmd = new RelayCommand(RefreshIPAddrFilterListExecute);

                return _refreshIPAddrFilterListCmd;
            }
        }

        /// <summary>
        /// 刷新IP地址过滤信息列表命令（采用异步方式）
        /// </summary>
        public void RefreshIPAddrFilterListExecute()
        {
            if (!IsLoadingIPAddrFilter)
            {
                Action action = GetIPAddressFilterInfoList;
                action.BeginInvoke(null, null);
            }
        }

        #endregion

        #region 新增MAC过滤信息

        private ICommand _addMACFilterInfoCmd;

        /// <summary>
        /// 获取新增MAC地址过滤信息的命令
        /// </summary>
        public ICommand AddMACFilterInfoCmd
        {
            get
            {
                if (_addMACFilterInfoCmd == null)
                    _addMACFilterInfoCmd = new RelayCommand(AddMACFilterInfoExecute, AddMACFilterInfoCanExecute);

                return _addMACFilterInfoCmd;
            }
        }

        /// <summary>
        /// 执行添加MAC地址过滤信息的方法
        /// </summary>
        public void AddMACFilterInfoExecute()
        {
            MACFilterInformation macInfo = new MACFilterInformation();
            MACFilterInfoWindow wnd = new MACFilterInfoWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = macInfo,
            };

            if (wnd.ShowDialog() == true)
            {
                ErrType err = _businessService.AddMACFilterInfo(_loginID, macInfo);
                if (err == GeneralErr.Success)
                    AddMACFilterInfo(macInfo);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool AddMACFilterInfoCanExecute()
        {
            return !IsLoadingMACFilterInfo;
        }

        #endregion

        #region 刷新MAC过滤信息列表

        private ICommand _refreshMACFilterListCmd;

        /// <summary>
        /// 获取刷新MAC过滤信息列表命令
        /// </summary>
        public ICommand RefreshMACFilterListCmd
        {
            get
            {
                if (_refreshMACFilterListCmd == null)
                    _refreshMACFilterListCmd = new RelayCommand(RefreshMACFilterListExecute);

                return _refreshMACFilterListCmd;
            }
        }

        /// <summary>
        /// 获取MAC过滤信息列表（采用异步方式）
        /// </summary>
        public void RefreshMACFilterListExecute()
        {
            if (!IsLoadingMACFilterInfo)
            {
                Action action = GetMACFilterInfoList;
                action.BeginInvoke(null, null);
            }
        }

        #endregion

        #endregion

        #region 数据管理部分命令

        #region 新增商品命令

        private ICommand _addProductInfoCmd;

        /// <summary>
        /// 获取新增商品信息的命令
        /// </summary>
        public ICommand AddProductInfoCmd
        {
            get
            {
                if (_addProductInfoCmd == null)
                    _addProductInfoCmd = new RelayCommand(AddProductInfoExecute, AddProductInfoCanExecute);

                return _addProductInfoCmd;
            }
        }

        public void AddProductInfoExecute()
        {
            ProductInformation newProductInfo = new ProductInformation();
            ProductInfoWindow wnd = new ProductInfoWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = newProductInfo,
                RawMaterialsCodeList = ProductInfoes.Select(p => p.RawMaterialsCode).Distinct().ToList(),

                IsNew = true
            };

            if (wnd.ShowDialog() == true)
            {
                ErrType err = _businessService.AddProductInfo(_loginID, newProductInfo);
                if (err == GeneralErr.Success)
                    AddProductInfo(newProductInfo);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private bool AddProductInfoCanExecute()
        {
            return !IsLoadingProductInfoList;
        }

        #endregion

        #region 刷新商品列表命令

        private ICommand _refreshProductInfoListCmd;

        /// <summary>
        /// 获取刷新商品列表命令
        /// </summary>
        public ICommand RefreshProductInfoListCmd
        {
            get
            {
                if (_refreshProductInfoListCmd == null)
                    _refreshProductInfoListCmd = new RelayCommand(RefreshProductInfoListExecute);

                return _refreshProductInfoListCmd;
            }
        }

        /// <summary>
        /// 刷新商品列表（采用异步方式）
        /// </summary>
        public void RefreshProductInfoListExecute()
        {
            if (!IsLoadingProductInfoList)
            {
                Action action = GetProductInfoList;
                action.BeginInvoke(null, null);
                GetProductInfoList();
            }
        }

        #endregion

        #region 刷新汇率和水信息列表命令

        private ICommand _refreshRateWaterInfoListCmd;

        /// <summary>
        /// 获取刷新汇率和水信息列表的命令
        /// </summary>
        public ICommand RefreshRateWaterInfoListCmd
        {
            get
            {
                if (_refreshRateWaterInfoListCmd == null)
                    _refreshRateWaterInfoListCmd = new RelayCommand(RefreshRateWaterInfoListExecuted);

                return _refreshRateWaterInfoListCmd;
            }
        }

        /// <summary>
        /// 刷新汇率和水信息列表（采用异步方式）
        /// </summary>
        public void RefreshRateWaterInfoListExecuted()
        {
            Action action = GetRateWaterInfoList;
            action.BeginInvoke(null, null);
        }

        #endregion

        #endregion

        #endregion

        #region 公用接口
        #region 登陆后的初始化方法
        /// <summary>
        /// 登陆后的一些初始化动作
        /// </summary>
        public void Initialize()
        {
            GetBanks();

            //商品列表需要自动加载
            RefreshProductInfoListExecute();

            //账户类型，0：用户，1：管理员，2：金商
            int userType = _accType == ACCOUNT_TYPE.Dealer ? 2 : 1;

            MainWindowTitle = "玖鑫国际微中心管理系统";
            _quotation = new StockQuotationsDistribution(_accName, userType, MacAddress.LocalMAC, _quotationAddr, _quotationPort);
            _quotation.RealTimeDataUpdate += (sender, args) =>
            {
                if (ProductInfoes != null)
                {
                    foreach (var item in ProductInfoes)
                    {
                        if (item.StockCode.Equals(args.StockCode))
                        {
                            item.Update(args.Price, args.Time);
                        }
                    }
                }

                if (TradeJuJianInfo != null && TradeJuJianInfo.TradeJuJianLst.Count>0 && CanIterofficeReSetYingKui)
                {
                    ReSetYingkui();
                }
                
            };
           
            
        }
        #endregion

        #region 初始化动作后进行行情分发
        /// <summary>
        /// 初始化动作后开始行情分发
        /// </summary>
        public void QuotationDistribution()
        {
            _quotation.StartConnect();
        }
        #endregion

        #region 登陆
        /// <summary>
        /// 用户登陆
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="password">密码</param>
        /// <param name="accountType">账户类型，管理员/金商</param>
        /// <returns>登陆成功或失败</returns>
        public ErrType Login(string account, string password, ACCOUNT_TYPE accountType)
        {
            LoginResult loginResult = _businessService.Login(account, password);
            if (loginResult.LoginSuccess)
            {
                _loginID = loginResult.LoginID;
                _accName = account;
                _quotationAddr = loginResult.QuotationAddr;
                _quotationPort = loginResult.QuotationPort;
                _businessService.UserRolePrivileges(_loginID, loginResult.UserID, ref _AccountAuthority);
            }
            return loginResult.LoginSuccess ? GeneralErr.Success : new ErrType(ERR.SERVICE, loginResult.ErrMsg);
        }
        #endregion

        #region 账户管理部分
        #region 显示账户信息并修改
        #region 显示客户账户信息
        /// <summary>
        /// 显示客户账户信息
        /// </summary>
        /// <param name="clientAccount">选中的某个客户账户</param>
        public void ShowAccountInfo(ClientAccount clientAccount)
        {
            clone = (ClientAccount)clientAccount.Clone();
            this.clientAccount = clientAccount;
            clientView = new ClientAccountInfoWindow
            {
                POrgList=this.POrgList,
                Owner = Application.Current.MainWindow,
                DataContext = clone,
            };
            clientView.ComitEvent = ShowAccInfoOnLine;
            clientView.ShowDialog();
        }
        
        private void ShowAccInfoOnLine()
        {
            ErrType err = _businessService.ModifyClientAccountInfo(clone, _loginID);
            if (err == GeneralErr.Success)
            {
                clone.AccInfo.LastUpdateManager = _accName;
                clientAccount.Sync(clone);
                clientView.Close();

            }
            else
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);

        }

        /// <summary>
        /// 显示客户账户信息
        /// </summary>
        /// <param name="clientAccount">选中的某个客户账户</param>
        public void ShowAccountInfo2(ClientAccount clientAccount)
        {
            clone = (ClientAccount)clientAccount.Clone();
            this.clientAccount = clientAccount;
            clientView = new ClientAccountInfoWindow
            {
                Owner = Application.Current.MainWindow,
                POrgList=this.POrgList,
                DataContext = clone,
                Banks = this.Banks,
            };
            clientView.ComitEvent = ShowAccInfo;
            clientView.ShowDialog();
            
        }
        ClientAccount clientAccount;
        ClientAccount clone;
        private void ShowAccInfo()
        {
            //if (string.IsNullOrEmpty(clone.FundsInfo.banktype))
            //{
            //    MessageBox.Show("银行类型不能为空！");
            //    return;
            //}
            FundsInformation fi = new FundsInformation() { OpenBank = clone.FundsInfo.OpenBank, BankCardNumber = clone.FundsInfo.BankCardNumber, banktype = clone.FundsInfo.banktype};
            ErrType err = _businessService.ModifyClientAccountInfo(clone, fi, _loginID);
            if (err == GeneralErr.Success)
            {
                clientAccount.FundsInfo.OpenBank = fi.OpenBank;
                clientAccount.FundsInfo.BankCardNumber = fi.BankCardNumber;
                clone.AccInfo.LastUpdateManager = _accName;
                clientAccount.Sync(clone);
                GetUserBaseInfoWithPage();
                clientView.Close();
            }
            else
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);


            }
        
        }
        #endregion

        #region 显示金商账户信息
        /// <summary>
        /// 显示金商账户信息
        /// </summary>
        /// <param name="dealerAccount">选中的某个金商账户</param>
        public void ShowDealerAccountInfo(ClientAccount clientAccount)
        {
            clone = (ClientAccount)clientAccount.Clone();
            OrgInfo org = POrgList.FirstOrDefault(p=>p.OrgName==clone.AccInfo.OrgName);
            this.clientAccount = clientAccount;
            dealerView = new DealerAccountInfoWindow
            {
                POrgList = this.POrgList,
                Owner = Application.Current.MainWindow,
                CurOrgInfo=org,
                DataContext = clone,
            };
            dealerView.ComitEvent += new Action(ShowDealerAccountInfo);
            dealerView.ShowDialog();
        }
        private void ShowDealerAccountInfo()
        {
           clone.AccInfo.OrgName = dealerView.CurOrgInfo.OrgName;
            ErrType err = _businessService.ModifyClientAccountInfo(clone, _loginID);
            if (err == GeneralErr.Success)
            {
                clientAccount.Sync(clone);
                dealerView.Close();
            }
            else
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        #endregion

        #region 显示管理员账户信息
        /// <summary>
        /// 显示管理员账户信息
        /// </summary>
        /// <param name="adminAccount">选中的某个管理员账户</param>
        public void ShowManagerAccountInfo(ClientAccount clientAccount)
        {
            ClientAccount clone = (ClientAccount)clientAccount.Clone();
            ManagerAccountInfoWindow managerView = new ManagerAccountInfoWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = clone,
            };

            if (managerView.ShowDialog() == true)
            {
                ErrType err = _businessService.ModifyClientAccountInfo(clone, _loginID);
                if (err == GeneralErr.Success)
                {
                    clientAccount.Sync(clone);
                }
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion
        #endregion

        #region 显示资金信息并修改
        /// <summary>
        /// 显示客户的资金信息
        /// </summary>
        /// <param name="clientAccount">选中的客户账户</param>
        public void ShowClientFundsInfo(ClientAccount clientAccount)
        {
            string clientAccName = clientAccount.AccInfo.AccountName;
            FundsInformation clone = (FundsInformation)clientAccount.FundsInfo.Clone();
            ClientFundsInfoWindow fundsInfoWnd = new ClientFundsInfoWindow(AccountAuthority.IsCanAlterDJ)
            {
                Owner = Application.Current.MainWindow,
                DataContext = clone,
            };

            if (fundsInfoWnd.ShowDialog() == true)
            {
                ErrType err = _businessService.ModifyClientFundsInfo(_loginID, _accType, clientAccName, clone);
                if (err == GeneralErr.Success)
                {
                    clientAccount.FundsInfo.Sync(clone);
                }
                else
                {
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
        #endregion

        #region 删除账户
        /// <summary>
        /// 删除指定客户账户
        /// </summary>
        /// <param name="clientAcc">要删除的客户账户</param>
        public void DeleteClientAccount(ClientAccount clientAcc)
        {
            MessageBoxResult mbResult = MessageBox.Show("确定要删除该客户账户吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbResult == MessageBoxResult.Yes)
            {
                ErrType err = _businessService.DeleteClientAccount(clientAcc.AccInfo.AccountName, _loginID);
                if (err == GeneralErr.Success)
                    RemoveClientAccount(ClientAccountList, clientAcc);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// 删除指定的金商账户
        /// </summary>
        /// <param name="dealerAcc">要删除的金商账户</param>
        public void DeleteDealerAccount(ClientAccount dealerAcc)
        {
            MessageBoxResult mbResult = MessageBox.Show("确定要删除该会员账户吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbResult == MessageBoxResult.Yes)
            {
                ErrType err = _businessService.DeleteClientAccount(dealerAcc.AccInfo.AccountName, _loginID);
                if (err == GeneralErr.Success)
                    RemoveClientAccount(DealerAccountList, dealerAcc);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// 删除指定的管理员账户
        /// </summary>
        /// <param name="mgrAcc">要删除的管理员账户</param>
        public void DeleteManagerAccount(ClientAccount mgrAcc)
        {
            MessageBoxResult mbResult = MessageBox.Show("确定要删除该管理员账户吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbResult == MessageBoxResult.Yes)
            {
                ErrType err = _businessService.DeleteClientAccount(mgrAcc.AccInfo.AccountName, _loginID);
                if (err == GeneralErr.Success)
                    RemoveClientAccount(ManagerAccountList, mgrAcc);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #region 库存结算

        /// <summary>
        /// 出入金窗口
        /// </summary>
        public void CashIO(ClientAccount clientAccount)
        {
            AdjustMoneyWindow wnd = new AdjustMoneyWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = clientAccount,
                Title = "库存结算"
            };
            if (wnd.ShowDialog() == true)
            {
                if (wnd.CashIOMode == CASH_IO_MODE.Out)
                {//出金则资金为负数
                    wnd.Deposit = -wnd.Deposit;
                }

                ErrType err = _businessService.CashIO(_loginID, _accType, clientAccount.AccInfo.AccountName, wnd.Deposit);
                if (err == GeneralErr.Success)
                    MessageBox.Show("库存结算操作成功，金额：" + wnd.Deposit, "库存结算操作", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #region 调整资金

        /// <summary>
        /// 调整客户资金
        /// </summary>
        /// <param name="clientAccount"></param>
        public void AdjustMoneyOfClient(ClientAccount clientAccount)
        {
            AdjustMoneyWindow wnd = new AdjustMoneyWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = clientAccount,
                Title = "调节",
            };

            if (wnd.ShowDialog() == true)
            {
                if (wnd.CashIOMode == CASH_IO_MODE.Out)
                {//出金则资金为负数
                    wnd.Deposit = -wnd.Deposit;
                }

                ErrType err = _businessService.AdjustMoney(_loginID, _accType, clientAccount.AccInfo.AccountName, wnd.Deposit);
                if (err == GeneralErr.Success)
                    MessageBox.Show("资金调整成功，金额：" + wnd.Deposit, "调节操作", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #region 持仓新单

        /// <summary>
        /// 为指定的客户持仓新单
        /// </summary>
        /// <param name="clientAccount">指定的某个客户账户</param>
        public void MarketOrder(ClientAccount clientAccount)
        {
            MarketOrderWindow wnd = new MarketOrderWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = clientAccount,
                ProductList = ProductInfoes,
            };
            wnd.MarketOrder += (sender, args) =>
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (s, e) =>
                {
                    ValidationResult result = MarketOrderInfoValidation(args.NewOrderInfo, args.SelectedProduct, clientAccount);
                    if (!result.IsValid)
                    {
                        e.Result = new ErrType(ERR.VALIDATE_FAIL, result.ErrorContent.ToString());
                        return;
                    }

                    int userType = ToUserType(_accType);
                    e.Result = _tradeService.MarketOrder(_loginID, clientAccount.AccInfo.AccountName, userType, args.NewOrderInfo);
                };
                worker.RunWorkerCompleted += (s, e) =>
                {
                    ErrType err = e.Result as ErrType;
                    if (err != GeneralErr.Success)
                    {
                        MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                        wnd.RevertWindowState();
                    }
                    else
                    {
                        wnd.Close();
                        MessageBox.Show("市价订单操作成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                };
                worker.RunWorkerAsync();
            };
            wnd.ShowDialog();
        }

        #endregion

        #region 限价挂单

        /// <summary>
        /// 为指定的客户限价挂单
        /// </summary>
        /// <param name="clientAccount">指定的某个客户账户</param>
        public void PendingOrder(ClientAccount clientAccount)
        {
            PendingOrderWindow wnd = new PendingOrderWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = clientAccount,
                ProductList = ProductInfoes,
            };
            wnd.PendingOrder += (sender, args) =>
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (s, e) =>
                {
                    ValidationResult result = PendingOrderInfoValidation(args.NewOrderInfo, args.SelectedProduct, clientAccount);
                    if (!result.IsValid)
                    {
                        e.Result = new ErrType(ERR.VALIDATE_FAIL, result.ErrorContent.ToString());
                        return;
                    }

                    int userType = ToUserType(_accType);
                    e.Result = _tradeService.PendingOrder(_loginID, clientAccount.AccInfo.AccountName, userType, args.NewOrderInfo);
                };
                worker.RunWorkerCompleted += (s, e) =>
                {
                    ErrType err = e.Result as ErrType;
                    if (err != GeneralErr.Success)
                    {
                        MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                        wnd.RevertWindowState();
                    }
                    else
                    {
                        wnd.Close();
                        MessageBox.Show("限价挂单操作成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                };
                worker.RunWorkerAsync();
            };
            wnd.ShowDialog();
        }

        #endregion

        #endregion

        #region 交易管理部分
        #region 有效定单分页查询 马友春
        /// <summary>
        /// 有效定单分页查询
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public void GetMultiTradeOrderWithPage(string OrderType, string OrgName, string ProductName, string AccountName, string StockCode, DateTime startTime,
            DateTime endTime, int pageindex, int pagesize, ref int pageCount)
        {
            CxQueryConInfomation infomation = new CxQueryConInfomation
            {
                OrgName=OrgName,
                ProductName = ProductName,
                TradeAccount = AccountName,
                LoginID = _loginID,
                StartTime = startTime,
                EndTime = endTime,
                OrderType = OrderType,
                StockCode = StockCode,
            };
            TradeOrderInfo = _businessService.GetMultiTradeOrderWithPage(infomation, pageindex, pagesize, ref pageCount);

            if (TradeOrderInfo.Result)
            {
                foreach (var item in TradeOrderInfo.TdOrderList)
                {
                    ProductInformation productInfo = GetProductInfoByName(item.ProductName);
                    item.OwnedProduct = productInfo;
                }

                //按时间排序处理
                TradeOrderInfo.TdOrderList.OrderByDescending(item => item.OrderTime).ToList();
               
            }
            else
                MessageBox.Show(TradeOrderInfo.Desc, "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
          
        }
        #endregion

        #region 获取市价单
        /// <summary>
        /// 获取市价单
        /// </summary>
        /// <param name="tradeAccount">用户交易账号</param>
        /// <returns></returns>
        public List<MarketOrderData> GetMarketOrderList(string tradeAccount)
        {
            List<MarketOrderData> orderList = _tradeService.GetMarketOrderList(tradeAccount, _loginID);
            orderList = orderList.OrderByDescending(item => item.OrderTime).ToList();
            if (orderList != null)
            {
                ClearMarketOrderList();
                AddMarketOrderList(orderList);
            }
            foreach (var item in orderList)
            {
                ProductInformation productInfo = GetProductInfoByName(item.ProductName);
                item.OwnedProduct = productInfo;
            }
            return orderList;
        } 
        #endregion

        #region 限价定单分页查询 马友春
        /// <summary>
        /// 限价定单分页查询
        /// </summary>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="pageCount"></param>
        /// <returns></returns>
        public void GetMultiTradeHoldOrderWithPage(string OrderType, string OrgName, string ProductName, string AccountName, string StockCode, DateTime startTime, DateTime endTime, int pageindex, int pagesize, ref int pageCount)
        {
            CxQueryConInfomation infomation = new CxQueryConInfomation
            {
                ProductName = ProductName,
                //UserType = (int)_accType,
                TradeAccount = AccountName,
                LoginID = _loginID,
                StartTime = startTime,
                EndTime = endTime,
                OrgName = OrgName,
                OrderType = OrderType,
                StockCode = StockCode
            };
           
            TradeHoldOrderInfo = _businessService.GetMultiTradeHoldOrderWithPage(infomation, pageindex, pagesize, ref pageCount);
            foreach (var item in TradeHoldOrderInfo.TdHoldOrderList)
            {
                ProductInformation productInfo = GetProductInfoByName(item.ProductName);
                item.OwnedProduct = productInfo;
            }
            if (!TradeHoldOrderInfo.Result)
            {
                MessageBox.Show(TradeHoldOrderInfo.Desc, "错误", MessageBoxButton.OK, MessageBoxImage.Warning); 
            }
        }
        #endregion

        #region 获取限价挂单列表
        /// <summary>
        /// 获取挂价单
        /// </summary>
        /// <param name="tradeAccount">用户交易账号</param>
        /// <returns></returns>
        public List<PendingOrderData> GetPendingOrderList(string tradeAccount)
        {
            List<PendingOrderData> orderList = _tradeService.GetTradeHoldOrder( tradeAccount, _loginID);
            orderList = orderList.OrderByDescending(item => item.OrderTime).ToList();
            if (orderList != null)
            {
                ClearPendingOrderList();
                AddPendingOrderList(orderList);
            }
            return orderList;
        }

        #endregion

        #region 获取平仓历史记录列表

        /// <summary>
        /// 平仓历史记录查询
        /// </summary>
        /// <param name="searchInfo">查询条件信息</param>
        /// <param name="pageCount">返回的结果总页数</param>
        /// <returns>平仓历史记录列表</returns>
        public List<MarketHistoryData> GetChargebackRecode(HistorySearchInfo searchInfo, ref int pageCount)
        {
            searchInfo.UserType = ToUserType(_accType);
            List<MarketHistoryData> list;

            IsLoadingChargebackRecode = true;
            ErrType err = _tradeService.GetChargebackRecorder(_loginID, searchInfo, ref pageCount, out list);
            IsLoadingChargebackRecode = false;
            if (err != GeneralErr.Success)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
            else
                return list;
        }

        #endregion

        #region 获取平仓历史记录分页查询
        public void GetMultiLTradeOrderWithPage(string OrderType, string OrgName, string ProductName, string AccountName, string StockCode, DateTime startTime, DateTime endTime, int pageindex, int pagesize, ref int pageCount)
        {
            CxQueryConInfomation infomation = new CxQueryConInfomation
            {
                ProductName = ProductName,
                //UserType = (int)_accType,
                TradeAccount = AccountName,
                LoginID = _loginID,
                StartTime = startTime,
                EndTime = endTime,
                OrgName = OrgName,
                OrderType = OrderType,
                StockCode = StockCode
            };
             LTradeOrderInfo = _businessService.GetMultiLTradeOrderWithPage(infomation, "1", pageindex, pagesize,ref pageCount);
            if (!LTradeOrderInfo.Result)
            {
                MessageBox.Show(LTradeOrderInfo.Desc, "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region 获取入库历史记录列表

        /// <summary>
        /// 入库单查询
        /// </summary>
        /// <param name="searchInfo">history search information</param>
        /// <param name="pageCount">output page count</param>
        /// <returns>WarehousingHistoryData list</returns>
        public List<WarehousingHistoryData> GetWarehousingHistoryList(HistorySearchInfo searchInfo, ref int pageCount)
        {
            searchInfo.UserType = ToUserType(_accType);
            List<WarehousingHistoryData> list;

            IsLoadingWarehousingHistory = true;
            ErrType err = _tradeService.GetWarehousingRecorder(_loginID, searchInfo, ref pageCount, out list);
            IsLoadingWarehousingHistory = false;
            if (err != GeneralErr.Success)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
            else
                return list;
        }

        #endregion

        #region 获取对冲交易历史记录列表

        ///// <summary>
        ///// 获取对冲交易历史记录列表
        ///// </summary>
        //public void GetHedgingTradeList()
        //{
        //    List<HedgingTradeData> list;

        //    IsLoadingHedgingTradeList = true;
        //    DateTime eTime = new DateTime(HedgingTradeRequestInfo.EndTime.AddDays(1).Year,
        //         HedgingTradeRequestInfo.EndTime.AddDays(1).Month, HedgingTradeRequestInfo.EndTime.AddDays(1).Day);
        //    ErrType err = _businessService.GetHedgingTradeList(_loginID, _accType,
        //        new RequestInformationBase { AccountName = HedgingTradeRequestInfo.AccountName, EndTime = eTime, StartTime = HedgingTradeRequestInfo.StartTime }, out list);
        //    if (err == GeneralErr.Success)
        //    {
        //        if (list != null)
        //        {
        //            ClearHedgingTradeList();
        //            AddHedgingTradeList(list);
        //        }
        //    }
        //    else
        //        MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);

        //    IsLoadingHedgingTradeList = false;
        //}


        /// <summary>
        /// 获取对冲交易历史记录列表
        /// </summary>
        public void GetHedgingTradeList()
        {

            IsLoadingHedgingTradeList = true;
            DateTime eTime = new DateTime(HedgingTradeRequestInfo.EndTime.AddDays(1).Year,
                 HedgingTradeRequestInfo.EndTime.AddDays(1).Month, HedgingTradeRequestInfo.EndTime.AddDays(1).Day);
            HedgingInfo = _businessService.GetHedgingTradeList(_loginID, _accType,
                new RequestInformationBase { AccountName = HedgingTradeRequestInfo.AccountName, EndTime = eTime, StartTime = HedgingTradeRequestInfo.StartTime });


            if (!HedgingInfo.Result)
            {
                MessageBox.Show(HedgingInfo.Desc, "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            IsLoadingHedgingTradeList = false;
        }

        #endregion

        #region 导出报表

        /// <summary>
        /// 导出报表
        /// </summary>
        public void ExportStatements()
        {
            string webAddr = string.Empty;
            IsLoadingStatements = true;

            DateTime startTime = StatementsRequestInfo.StartTime;
            DateTime endTime = new DateTime(StatementsRequestInfo.EndTime.AddDays(1).Year, StatementsRequestInfo.EndTime.AddDays(1).Month, StatementsRequestInfo.EndTime.AddDays(1).Day);
            //DateTime endTime = StatementsRequestInfo.EndTime.AddDays(1);
            STATEMENTS_TYPE type = StatementsRequestInfo.StatementsType;
            if (type == STATEMENTS_TYPE.AccountBalance)
                endTime = startTime;
            ErrType err = _businessService.GetExportStatementsWebAddr(_loginID, _accType, startTime, endTime, type, out webAddr);
            if (err == GeneralErr.Success)
            {
                if (string.IsNullOrEmpty(webAddr))
                {
                    MessageBox.Show("获取报表地址失败", "导出报表", MessageBoxButton.OK, MessageBoxImage.Warning);
                    IsLoadingStatements = false;
                    return;
                }

                SaveFileDialog saveDlg = new SaveFileDialog()
                {
                    Filter = "Excel报表|*.xls"
                };
                if (saveDlg.ShowDialog() == true)
                {
                    bool result = WebFileDownloadHelper.DownloadFile(new Uri(webAddr), saveDlg.FileName);
                    if (result)
                        MessageBox.Show("导出完成", "报表导出", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show(WebFileDownloadHelper.LastErrMessage, "下载导出报表", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);

            IsLoadingStatements = false;
        }

        /// <summary>
        /// 导出报表（用户信息）
        /// </summary>
        public void ExportUserExcel()
        {
            string webAddr = string.Empty;
            IsLoadingStatements = true;

            DateTime startTime = ClientAccountSelectCondition.StartTime;
            DateTime endTime = new DateTime(ClientAccountSelectCondition.EndTime.AddDays(1).Year, 
                ClientAccountSelectCondition.EndTime.AddDays(1).Month, ClientAccountSelectCondition.EndTime.AddDays(1).Day);

            STATEMENTS_TYPE type = STATEMENTS_TYPE.UserPeport;
            string IsBroker;
            if (string.IsNullOrEmpty(ClientAccountSelectCondition.IsBroker) || ClientAccountSelectCondition.IsBroker == "全部")
            {
                IsBroker = "0";
            }
            else if (ClientAccountSelectCondition.IsBroker == "是")
                IsBroker = "1";
            else
                IsBroker = "2";
            ErrType err = _businessService.GetExportStatementsWebAddrUser(ClientAccountSelectCondition.Account, ClientAccountSelectCondition.UserName, 
                ClientAccountSelectCondition.Phone, ClientAccountSelectCondition.Broker,ClientAccountSelectCondition.OrgName,IsBroker,
            _loginID, startTime, endTime, type, out webAddr);
            if (err == GeneralErr.Success)
            {
                if (string.IsNullOrEmpty(webAddr))
                {
                    MessageBox.Show("获取报表地址失败", "导出报表", MessageBoxButton.OK, MessageBoxImage.Warning);
                    IsLoadingStatements = false;
                    return;
                }

                SaveFileDialog saveDlg = new SaveFileDialog()
                {
                    Filter = "Excel报表|*.xls"
                };
                if (saveDlg.ShowDialog() == true)
                {
                    bool result = WebFileDownloadHelper.DownloadFile(new Uri(webAddr), saveDlg.FileName);
                    if (result)
                        MessageBox.Show("导出完成", "报表导出", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show(WebFileDownloadHelper.LastErrMessage, "下载导出报表", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);

            IsLoadingStatements = false;
        }
        #endregion

        #region 显示出金详情
        /// <summary>
        /// 显示出金详情
        /// </summary>
        public void ShowPaymentDetails()
        {
            if (CurChuJin == null)
            {
                MessageBox.Show("请先选择需要查看的数据！");
                return;
            }

            FcQueryConInfomation infomation = new FcQueryConInfomation
            {
                LoginID = _loginID,
                Account = CurChuJin.Account,
                Endtime = DateTime.Today.AddDays(1),
                Starttime = DateTime.Today.AddYears(-1),
                OrgName = null,
                Reason = "4"
            };
            int pageCount = 0;
            List<FundChangeInformation> list = new List<FundChangeInformation>();
            ClientFundChangeInfo InFundInfo = _businessService.GetMultiFundChangeWithPage(infomation, 1, 5, ref  pageCount);

            if (!InFundInfo.Result)
            {
                MessageBox.Show(FundChangeInfo.Desc, "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;

            }

            infomation.Reason = "5";
            ClientFundChangeInfo OutFundInfo = _businessService.GetMultiFundChangeWithPage(infomation, 1, 5, ref  pageCount);

            if (!OutFundInfo.Result)
            {
                MessageBox.Show(FundChangeInfo.Desc, "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;

            }
             
            PaymentDetails win = new PaymentDetails() 
            { 
                ChuJinInfo = CurChuJin,
                InFundInfo = InFundInfo,
                OutFundInfo = OutFundInfo
            };
            win.PaymentEvent += new Action<PaymentDetails>(win_PaymentEvent);
            win.RefusedEvent += new Action<PaymentDetails>(win_RefusedEvent);
            win.ShowDialog();

        }

        void win_RefusedEvent(PaymentDetails obj)
        {
            if (MessageBox.Show("确定拒绝吗？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ErrType err = _businessService.RefusedChuJin(CurChuJin.ApplyId, _loginID);
                if (err == GeneralErr.Success)
                {
                    MessageBox.Show("操作成功！");
                    //GetChuJinExecuted();
                    obj.Close();
                    CurChuJin.State = "2";
                    
                }
                else
                {

                    MessageBox.Show(err.ErrMsg);
                }
            }
        }
        /// <summary>
        /// 付款
        /// </summary>
        /// <param name="obj"></param>
        void win_PaymentEvent(PaymentDetails obj)
        {
            string msg = "";
            if (CurChuJin != null && CurChuJin.State == "0")
            {
                MessageBoxResult result = MessageBox.Show("确定付款吗？", "提示信息", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (result == MessageBoxResult.OK)
                {
                    string state = "";
                    ErrType err = _businessService.ProcessChuJin(CurChuJin.ApplyId, _loginID, ref state);
                    if (err.Err == ERR.SUCCESS)
                    {
                        //if (err.Dec == "3")
                        //{
                        //    CurChuJin.State = "3";
                        //    MessageBox.Show("银行正在付款，请稍后查看付款状态", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                        //}
                        //else if (err.Dec == "4")
                        //{
                        //    CurChuJin.State = "4";
                        //    MessageBox.Show("银行付款失败，请手工调账（出金金额+3元手续费）至客户账户后，让客户重新发起出金申请", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                        //}
                        //else
                        //{
                        //    CurChuJin.State = "1";
                        //    MessageBox.Show("付款成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                        //}
                        obj.Close();
                       
                    }
                    else
                    {
                        MessageBox.Show("付款失败", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    CurChuJin.State = state;
                }
            }
            else
            {
                MessageBox.Show("请选择状态为【已申请】的数据！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region 有效定单平仓

        /// <summary>
        /// 有效定单平仓
        /// </summary>
        /// <param name="selectedMarketOrder">选中的某个有效定单</param>
        public void ChargebackMarketOrder(MarketOrderData selectedMarketOrder)
        {
            OrderChangedWindow wnd = new OrderChangedWindow(OrderChangedWindowType.Chargeback)
            {
                Owner = Application.Current.MainWindow,
                DataContext = selectedMarketOrder,
                
            };
            wnd.OrderChanged += (sender, args) =>
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (s, e) =>
                {
                    //这里应该先获取该定单对应的用户，然后进行平仓信息的验证，主要是平仓数量有效数据位的判断
                    //ValidationResult result = ChargebackOrderValidation( args.OrderChangedInfo, 先获取该定单对应的用户 );

                    int userType = ToUserType(_accType);
                    e.Result = _tradeService.ChargebackOrder(_loginID, userType, args.OrderChangedInfo);
                };
                worker.RunWorkerCompleted += (s, e) =>
                {
                    ErrType err = e.Result as ErrType;
                    if (err != GeneralErr.Success)
                    {
                        MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                        wnd.RevertWindowState();
                    }
                    else
                    {
                        wnd.Close();
                        StringBuilder sbStr = new StringBuilder();
                        string orderTypeStr = selectedMarketOrder.OrderType == TRANSACTION_TYPE.Order ? "买涨" : "买跌";
                        sbStr.Append("订单号\t\t\t商品\t类型\t订单价");
                        sbStr.Append(string.Format("{0}\t{1}\t{2}\t{3}", selectedMarketOrder.OrderID, selectedMarketOrder.ProductName, orderTypeStr, selectedMarketOrder.OrderPrice));
                        sbStr.Append("\r\n\r\n");
                        sbStr.Append(string.Format("平仓\t{0}\t于价位：{1}", args.OrderChangedInfo.Count,
                            args.OrderChangedInfo.RealTimePrice));
                        MessageBox.Show(sbStr.ToString(), "提示", MessageBoxButton.OK, MessageBoxImage.Information);

                        //根据结果对定单进行处理，如果定单数量为0，则移除该定单。
                        selectedMarketOrder.OrderQuantity -= args.OrderChangedInfo.Count;
                        if (selectedMarketOrder.OrderQuantity == 0)
                            RemoveMarketOrderData(selectedMarketOrder);
                    }
                };
                worker.RunWorkerAsync();
            };
            wnd.ShowDialog();
        }

        #endregion

        #region 有效定单入库

        /// <summary>
        /// 有效定单入库
        /// </summary>
        /// <param name="selectedMarketOrder">选中的某个有效定单</param>
        public void WarehousingMarketOrder(MarketOrderData selectedMarketOrder)
        {
            OrderChangedWindow wnd = new OrderChangedWindow(OrderChangedWindowType.Warehousing)
            {
                Owner = Application.Current.MainWindow,
                DataContext = selectedMarketOrder,
            };
            wnd.OrderChanged += (sender, args) =>
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (s, e) =>
                {
                    //这里应该先获取该定单对应的用户，然后进行平仓信息的验证，主要是平仓数量有效数据位的判断
                    //ValidationResult result = ChargebackOrderValidation( args.OrderChangedInfo, 先获取该定单对应的用户 );

                    int userType = ToUserType(_accType);
                    e.Result = _tradeService.WarehousingOrder(_loginID, userType, args.OrderChangedInfo);
                };
                worker.RunWorkerCompleted += (s, e) =>
                {
                    ErrType err = e.Result as ErrType;
                    if (err != GeneralErr.Success)
                    {
                        wnd.RevertWindowState();
                        MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        wnd.Close();
                        string msg = string.Format("入库操作成功，数量：{0}", args.OrderChangedInfo.Count);
                        MessageBox.Show(msg, "提示", MessageBoxButton.OK, MessageBoxImage.Information);

                        //根据结果对定单进行处理，如果定单数量为0，则移除该定单。
                        selectedMarketOrder.OrderQuantity -= args.OrderChangedInfo.Count;
                        if (selectedMarketOrder.OrderQuantity == 0)
                            RemoveMarketOrderData(selectedMarketOrder);
                    }
                };
                worker.RunWorkerAsync();
            };
            wnd.ShowDialog();
        }

        #endregion

        #region 有效定单入库限制 马友春
        /// <summary>
        /// 有效定单入库限制 马友春
        /// </summary>
        /// <param name="selectedMarketOrder">选中的某个定单</param>
        public void ModifyOrderAllowStore(MarketOrderData selectedMarketOrder)
        {
            bool allowStoreFlag = selectedMarketOrder.AllowStore;
            ModifyOrderAllowStoreWindow wnd = new ModifyOrderAllowStoreWindow()
            {
                Owner = Application.Current.MainWindow,
                DataContext = selectedMarketOrder,
            };
            wnd.Closed += (sender, args) =>
            {
                if (wnd.DialogResult == true)
                {
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.DoWork += (s, e) =>
                    {
                        int allowStore = selectedMarketOrder.AllowStore ? 1 : 0;
                        e.Result = _businessService.ModifyOrderAllowStore((int)_accType, _loginID, selectedMarketOrder.TradeAccount, selectedMarketOrder.OrderID, allowStore);
                    };
                    worker.RunWorkerCompleted += (s, e) =>
                    {
                        ErrType err = e.Result as ErrType;
                        if (err != GeneralErr.Success)
                        {
                            //Todo:重新窗口状态待处理
                            // wnd.RevertWindowState();
                            MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        else
                        {
                            wnd.Close();
                            string msg = "订单能否入库状态修改成功";
                            MessageBox.Show(msg, "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    };
                    worker.RunWorkerAsync();
                }
                else
                {
                    selectedMarketOrder.AllowStore = allowStoreFlag;
                }
            };
            wnd.ShowDialog();
        }
        #endregion

        #region 撤销限价挂单

        /// <summary>
        /// 撤销指定的限价挂单
        /// </summary>
        /// <param name="selectedPendingOrder">要撤销的限价挂单</param>
        public void RevocationPendingOrder(PendingOrderData selectedPendingOrder)
        {
            string msg = string.Format("确定要撤销该挂单：{0}？", selectedPendingOrder.OrderID);
            MessageBoxResult mbResult = MessageBox.Show(msg, "请确认撤销操作", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbResult == MessageBoxResult.Yes)
            {
                int userType = ToUserType(_accType);
                ErrType err = _tradeService.RevocationPendingOrder(_loginID, userType, selectedPendingOrder);
                if (err == GeneralErr.Success)
                {
                    RemovePendingOrderData(selectedPendingOrder);
                    msg = string.Format("撤销挂单成功：{0}", selectedPendingOrder.OrderID);
                    MessageBox.Show(msg, "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    msg = string.Format("撤销挂单失败：{0}，原因：\r\n{1}", selectedPendingOrder.OrderID, err.ErrMsg);
                    MessageBox.Show(msg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        #endregion

        #region 解约
        public bool CanGetTerminationLstExcuted { get; set; }
        /// <summary>
        /// 获取解约处理
        /// </summary>
        public void GetTerminationLstExcuted()
        {
            if (!CanGetTerminationLstExcuted)
            {
                return;
            }
            string state = "";
            switch (TerminationSelectCondition.State)
            {
                case "全部":
                    state = "All";
                    break;
                case "已申请":
                    state = "0";
                    break;
                case "已审核":
                    state = "1";
                    break;
                case "已拒绝":
                    state = "2";
                    break;

            }
            CJQueryConInfomation infomation = new CJQueryConInfomation
            {
                LoginID = _loginID,
                Account = TerminationSelectCondition.Account,
                Endtime = TerminationSelectCondition.EndTime.AddDays(1),
                Starttime = TerminationSelectCondition.StartTime,
                OrgName = TerminationSelectCondition.OrgName,
                State = state

            };
            int pageCount = 0;
            List<TradeJieYue> list = new List<TradeJieYue>();
            ErrType err = _businessService.GetMultiTerminationWithPage(infomation, TerminationSelectCondition.PageIndex, TerminationSelectCondition.PageSize,
            ref  pageCount, out  list);

            if (err == GeneralErr.Success)
            {
                if (list != null)
                    //按时间排序处理
                    TradeJieYueLst = new ObservableCollection<TradeJieYue>(list.OrderByDescending(item => item.ApplyTime));
                    TerminationSelectCondition.PageCount = pageCount;
            }
            else
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        /// <summary>
        /// 审核解约
        /// </summary>
        public void ProcessJieYue()
        {
            ErrType err = _businessService.ProcessJieYue(CurJieYue.ApplyId, CurJieYue.UserID, _loginID);
            if (err == GeneralErr.Success)
            {
                //CurJieYue.State = "1";
                GetTerminationLstExcuted();
            }
            else
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        /// <summary>
        /// 拒绝解约
        /// </summary>
        public void RefusedJieYue()
        {
            ErrType err = _businessService.RefusedJieYue(CurJieYue.ApplyId, _loginID);
            if (err == GeneralErr.Success)
            {
                //CurJieYue.State = "2";
                GetTerminationLstExcuted();
            }
            else
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

        #region 居间处理
        public bool CanGetJuJianLstEx { get; set; }
        /// <summary>
        /// 获取居间
        /// </summary>
        public void GetJuJianLstEx()
        {
            if (!CanGetJuJianLstEx)
            {

                return;
            }

            _TradeJuJianInfo.TradeJuJianLst.Clear();
            ClearDoubleProperty.Clear(_TradeJuJianInfo);
            _businessService.GetTradeJuJianInfo(InterOfficeSelectCondtion, _loginID, ref _TradeJuJianInfo);
            if (!TradeJuJianInfo.Result)
            {
                MessageBox.Show(TradeJuJianInfo.Desc, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            

        }
        /// <summary>
        /// 重新设置盈亏
        /// </summary>
        public void ReSetYingkui()
        {
            double AllYingkui = 0;
            if (null == TradeJuJianInfo)
            { return; }
            if (null == TradeJuJianInfo.TradeJuJianLst || 0 == TradeJuJianInfo.TradeJuJianLst.Count)
            { return; }
            foreach (var item in TradeJuJianInfo.TradeJuJianLst)
            {
                item.Yingkui = Math.Round( Order(item) + Recovery(item),2);
                AllYingkui += item.Yingkui;
            }
            TradeJuJianInfo.Yingkui = Math.Round(AllYingkui, 2); 
        }

        private double Order(TradeJuJian item)
        {
            double x = 0.000001;
            double resu = 0;
            ProductInformation info;
            if (item.XAUUSD_DH_NUM > x && item.XAUUSD_DHAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "XAUUSD").First();
                if (info!= null && info.SpreadBaseValue > x)
                {
                    resu += (info.RecoveryPrice - item.XAUUSD_DHAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.XAUUSD_DH_NUM;
                }    
            }
            if (item.XAGUSD_DH_NUM > x && item.XAGUSD_DHAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "XAGUSD").First();
                if (info!= null && info.SpreadBaseValue > x)
                {
                    resu += (info.RecoveryPrice - item.XAGUSD_DHAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.XAGUSD_DH_NUM;
                }
                
            }
            if (item.XPDUSD_DH_NUM > x && item.XPDUSD_DHAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "XPDUSD").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu += (info.RecoveryPrice - item.XPDUSD_DHAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.XPDUSD_DH_NUM;
                }
                
            }
            if (item.XPTUSD_DH_NUM > x && item.XPTUSD_DHAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "XPTUSD").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu += (info.RecoveryPrice - item.XPTUSD_DHAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.XPTUSD_DH_NUM;
                }
                
            }
            if (item.Copper_DH_NUM > x && item.Copper_DHAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "Copper").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu += (info.RecoveryPrice - item.Copper_DHAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.Copper_DH_NUM;
                }
                
            }
            if (item.UKOil_DH_NUM > x && item.UKOil_DHAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "UKOil").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu += (info.RecoveryPrice - item.UKOil_DHAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.UKOil_DH_NUM;
                }
                
            }
            if (item.EURGBP_DH_NUM > x && item.EURGBP_DHAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "EURGBP").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu += (info.RecoveryPrice - item.EURGBP_DHAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.EURGBP_DH_NUM;
                }
                
            }
            if (item.EURUSD_DH_NUM > x && item.EURUSD_DHAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "EURUSD").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu += (info.RecoveryPrice - item.EURUSD_DHAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.EURUSD_DH_NUM;
                }
                
            }
            if (item.GBPUSD_DH_NUM > x && item.GBPUSD_DHAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "GBPUSD").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu += (info.RecoveryPrice - item.GBPUSD_DHAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.GBPUSD_DH_NUM;
                }
                
            }
            if (item.USDCHF_DH_NUM > x && item.USDCHF_DHAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "USDCHF").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu += (info.RecoveryPrice - item.USDCHF_DHAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.USDCHF_DH_NUM;
                }
               
            }
            if (item.USDJPY_DH_NUM > x && item.USDJPY_DH_NUM > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "USDJPY").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu += (info.RecoveryPrice - item.USDJPY_DH_NUM) / info.SpreadBaseValue * info.PointValue * item.USDJPY_DH_NUM;
                }
               
            }
            if (item.USDOLLAR_DH_NUM > x && item.USDOLLAR_DHAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "USDOLLAR").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu += (info.RecoveryPrice - item.USDOLLAR_DHAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.USDOLLAR_DH_NUM;
                }
               
            }
            return resu;

        }

        private double Recovery(TradeJuJian item)
        {
            double x = 0.000001;
            double resu = 0;
            ProductInformation info;
            if (item.XAUUSD_HS_NUM > x && item.XAUUSD_HSAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "XAUUSD").First();
                if (info!= null && info.SpreadBaseValue > x)
                {
                    resu -= (info.OrderPrice - item.XAUUSD_HSAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.XAUUSD_HS_NUM;
                }
                
            }
            if (item.XAGUSD_HS_NUM > x && item.XAGUSD_HSAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "XAGUSD").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu -= (info.OrderPrice - item.XAGUSD_HSAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.XAGUSD_HS_NUM;
                }
                
            }
            if (item.XPDUSD_HS_NUM > x && item.XPDUSD_HSAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "XPDUSD").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu -= (info.OrderPrice - item.XPDUSD_HSAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.XPDUSD_HS_NUM;
                }
                
            }
            if (item.XPTUSD_HS_NUM > x && item.XPTUSD_HSAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "XPTUSD").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu -= (info.OrderPrice - item.XPTUSD_HSAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.XPTUSD_HS_NUM;
                }
                
            }
            if (item.Copper_HS_NUM > x && item.Copper_HSAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "Copper").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu -= (info.OrderPrice - item.Copper_HSAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.Copper_HS_NUM;
                }
                
            }
            if (item.UKOil_HS_NUM > x && item.UKOil_HSAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "UKOil").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu -= (info.OrderPrice - item.UKOil_HSAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.UKOil_HS_NUM;
                }
                
            }
            if (item.EURGBP_HS_NUM > x && item.EURGBP_HSAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "EURGBP").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu -= (info.OrderPrice - item.EURGBP_HSAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.EURGBP_HS_NUM;
                }
                
            }
            if (item.EURUSD_HS_NUM > x && item.EURUSD_HSAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "EURUSD").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu -= (info.OrderPrice - item.EURUSD_HSAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.EURUSD_HS_NUM;
                }
                
            }
            if (item.GBPUSD_HS_NUM > x && item.GBPUSD_HSAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "GBPUSD").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu -= (info.OrderPrice - item.GBPUSD_HSAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.GBPUSD_HS_NUM;
                }
                
            }
            if (item.USDCHF_HS_NUM > x && item.USDCHF_HSAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "USDCHF").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu -= (info.OrderPrice - item.USDCHF_HSAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.USDCHF_HS_NUM;
                }
                
            }
            if (item.USDJPY_HS_NUM > x && item.USDJPY_HS_NUM > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "USDJPY").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu -= (info.OrderPrice - item.USDJPY_HS_NUM) / info.SpreadBaseValue * info.PointValue * item.USDJPY_HS_NUM;
                }
                
            }
            if (item.USDOLLAR_HS_NUM > x && item.USDOLLAR_HSAVG_PRICE > x)
            {
                info = ProductInfoes.Where(p => p.RawMaterialsCode == "USDOLLAR").First();
                if (info != null && info.SpreadBaseValue > x)
                {
                    resu -= (info.OrderPrice - item.USDOLLAR_HSAVG_PRICE) / info.SpreadBaseValue * info.PointValue * item.USDOLLAR_HS_NUM;
                }
                
            }
            return resu;
        }
        #endregion

        /// <summary>
        /// 获取客户资金信息
        /// </summary>
        /// <param name="AccountName"></param>
        /// <returns></returns>
        public FundInformation GetAccMoneyInventory(string AccountName)
        {
            FundInformation fund = new FundInformation();
            ErrType err=_tradeService.GetMoneyInventoryEx(AccountName, _loginID, ref fund);
            if (err != GeneralErr.Success)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
            else
                return fund;
        }

        public bool CanGetChuJinExecuted { get; set; }
        /// <summary>
        /// 获取出金数据
        /// </summary>
        public void GetChuJinExecuted()
        {
            if (!CanGetChuJinExecuted)
            {
                return;
            }
            string state = "";
            switch (ChuJinSelectCondition.State)
            {
                case "全部":
                    state = "All";
                    break;
                case "已申请":
                    state = "0";
                    break;
                case "已付款":
                    state = "1";
                    break;
                case "已拒绝":
                    state = "2";
                    break;
                case "处理中":
                    state = "3";
                    break;
                case "处理失败":
                    state = "4";
                    break;

            }
            CJQueryConInfomation infomation = new CJQueryConInfomation
            {
                LoginID = _loginID,
                Account = ChuJinSelectCondition.Account,
                Endtime = ChuJinSelectCondition.EndTime.AddDays(1),
                Starttime = ChuJinSelectCondition.StartTime,
                OrgName = ChuJinSelectCondition.OrgName,
                PayStartTime=ChuJinSelectCondition.PayStartTime,
                PayEndTime=ChuJinSelectCondition.PayEndTime.AddDays(1),
                State = state
                
            };
            int pageCount = 0;
            List<TradeChuJinInformation> list = new List<TradeChuJinInformation>();
             TradeChuJinInfo = _businessService.GetMultiTradeChuJinWithPage(infomation, ChuJinSelectCondition.PageIndex, ChuJinSelectCondition.PageSize,
            ref  pageCount);

             if (TradeChuJinInfo.Result)
            {
                if (list != null)
                    //按时间排序处理
                    //ChuJinList = new ObservableCollection<TradeChuJinInformation>(list.OrderByDescending(item => item.ApplyTime));
                    TradeChuJinInfo.TOrderLst.OrderByDescending(item=>item.ApplyTime);
                ChuJinSelectCondition.PageCount = pageCount;
            }
            else
                 MessageBox.Show(TradeChuJinInfo.Desc,"错误", MessageBoxButton.OK, MessageBoxImage.Warning);
        }


        /// <summary>
        /// 出金处理
        /// </summary>
        public void ChuJinExecuted()
        {
            string msg = "";
            if (CurChuJin != null && CurChuJin.State == "0")
            {
                MessageBoxResult result = MessageBox.Show("确定付款吗？", "提示信息", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (result == MessageBoxResult.OK)
                {
                    string state = "";
                    ErrType err = _businessService.ProcessChuJin(CurChuJin.ApplyId, _loginID,ref state);
                    if (err == GeneralErr.Success)
                    {
                        //if (err.Dec == "3")
                        //{
                        //    CurChuJin.State = "3";
                        //}
                        //else if (err.Dec == "4")
                        //{
                        //    CurChuJin.State = "4";
                        //}                     
                        //else
                        //{
                        //    CurChuJin.State = "1";
                        //}
                       
                        MessageBox.Show("操作成功", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                       
                        msg = string.Format("付款失败：{0}", err.ErrMsg);
                        MessageBox.Show(msg, "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    CurChuJin.State = state;
                }
            }
            else
            {
                MessageBox.Show("请选择状态为【已申请】的数据！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        /// <summary>
        /// 出金拒绝
        /// </summary>
        public void RefusedChuJinExecuted()
        {
            if (MessageBox.Show("确定拒绝吗？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ErrType err = _businessService.RefusedChuJin(CurChuJin.ApplyId, _loginID);
                if (err == GeneralErr.Success)
                {
                    MessageBox.Show("操作成功！");
                    //GetChuJinExecuted();
                    CurChuJin.State = "2";
                }
                else
                {

                    MessageBox.Show(err.ErrMsg);
                }
            }
           
        }

        public bool CanGetFundReportExecuted { get; set; }
         /// <summary>
        /// 获取出金数据
        /// </summary>
        public void GetFundReportExecuted()
        {
            if (!CanGetFundReportExecuted)
            {
                return;
            }
            string state = "";
            switch (FundReportSelectCondition.State)
            {
                case "全部":
                    state = "All";
                    break;
                case "入金":
                    state = "4";
                    break;
                case "出金":
                    state = "5";
                    break;
                case "调节":
                    state = "6";
                    break;
                case "经纪人提成":
                    state = "9";
                    break;
                case "赠金":
                    state = "12";
                    break;
            }
            FcQueryConInfomation infomation = new FcQueryConInfomation
            {
                LoginID = _loginID,
                Account = FundReportSelectCondition.Account,
                Endtime = FundReportSelectCondition.EndTime.AddDays(1),
                Starttime = FundReportSelectCondition.StartTime,
                OrgName = FundReportSelectCondition.OrgName,
                Reason = state
            };
            int pageCount = 0;
            List<FundChangeInformation> list = new List<FundChangeInformation>();
            FundChangeInfo = _businessService.GetMultiFundChangeWithPage(infomation, FundReportSelectCondition.PageIndex, FundReportSelectCondition.PageSize,ref  pageCount);

            if (FundChangeInfo.Result)
            {
                if (list != null)
                    //按时间排序处理
                    FundChangeInfo.TOderLst.OrderByDescending(item => item.OpTime);
                FundReportSelectCondition.PageCount = pageCount;
            }
            else
                MessageBox.Show(FundChangeInfo.Desc, "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// 获取出入金和解约信息
        /// </summary>
        /// <param name="moneyList">ref List<TradeMoneyData></param>
        /// <returns>ErrType</returns>
        public List<TradeMoneyData> GetTradeMoneyInfo()
        {
            List<TradeMoneyData> moneyList = new List<TradeMoneyData>();
            ErrType err = _businessService.GetTradeMoneyInfo(ref moneyList);
            if (err.Err == ERR.SUCCESS)
                return moneyList;
            else
            {
                return null;
            }
        }
        #endregion

        #region 系统设置部分

        #region 交易日管理

        #region 交易日查询命令
        private ICommand _GetTradingDayInfoCommand;
        /// <summary>
        /// 获取客户账户的命令
        /// </summary>
        public ICommand GetTradingDayInfoCommand
        {
            get
            {
                if (_GetTradingDayInfoCommand == null)
                    _GetTradingDayInfoCommand = new RelayCommand(GetTradingDayInfo);

                return _GetTradingDayInfoCommand;
            }
        }
        #endregion
        #region 交易日查询行情编码
        private string _TradingDaySearchCode;
        /// <summary>
        /// 交易日查询行情编码
        /// </summary>
        public string TradingDaySearchCode
        {
            get { return _TradingDaySearchCode; }
            set
            {
                _TradingDaySearchCode = value;
                RaisePropertyChanged("TradingDaySearchCode");
            }
        }

        #endregion
        /// <summary>
        /// 获取交易日信息列表
        /// </summary>
        public void GetTradingDayInfo()
        {
            if (string.IsNullOrEmpty(TradingDaySearchCode))
            {
                MessageBox.Show("请先选择需要查询的商品名称","提示");
            }
            List<TradingDayInformation> list;
            IsLoadingTradingDayInfo = true;

            ErrType err = _businessService.GetTradingDayInfo(_loginID, TradingDaySearchCode, out list);
            IsLoadingTradingDayInfo = false;
            if (err == GeneralErr.Success)
            {
                if (list != null)
                {
                    ClearTradingDayInfoList();
                    AddTradingDayInfoList(list);
                }
            }
            else
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// 显示某个交易日的详细信息
        /// </summary>
        /// <param name="selected">选中的要显示的某个交易日</param>
        public void ShowTradingDayInfo(TradingDayInformation selected)
        {
            TradingDayInformation clone = (TradingDayInformation)selected.Clone();
            TradingDayWindow wnd = new TradingDayWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = clone,
            };

            if (wnd.ShowDialog() == true)
            {
                ErrType err = _businessService.ModifyTradingDayInfo(_loginID, clone);
                if (err == GeneralErr.Success)
                    selected.Sync(clone);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #region 节假日管理

        /// <summary>
        /// 获取节假日信息列表
        /// </summary>
        public void GetHolidayInfo()
        {
            List<HolidayInformation> list;
            IsLoadingHolidayInfo = true;

            ErrType err = _businessService.GetHolidayInfo(_loginID, out list);
            IsLoadingHolidayInfo = false;
            if (err == GeneralErr.Success)
            {
                if (list != null)
                {
                    ClearHolidayInfoList();
                    AddHolidayInfoList(list);
                }
            }
            else
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// 显示节假日信息
        /// </summary>
        /// <param name="selectedHoliday">选中的节假日</param>
        public void ShowHolidayInfo(HolidayInformation selectedHoliday)
        {
            HolidayInformation clone = (HolidayInformation)selectedHoliday.Clone();
            List<string> Stockcodes = new List<string>();
            foreach (var item in ProductInfoes)
            {
                if (Stockcodes.Contains(item.StockCode))
                {
                    continue;
                }
                Stockcodes.Add(item.StockCode);
            }
            HolidayInfoWindow wnd = new HolidayInfoWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = clone,
                Codes = Stockcodes,
            };

            if (wnd.ShowDialog() == true)
            {
                ErrType err = _businessService.ModifyHolidayInfo(_loginID, clone);
                if (err == GeneralErr.Success)
                    selectedHoliday.Sync(clone);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// 删除指定的节假日
        /// </summary>
        /// <param name="selectedHoliday">要删除的节假日</param>
        public void DeleteHolidayInfo(HolidayInformation selectedHoliday)
        {
            MessageBoxResult mbResult = MessageBox.Show("确定删除该节假日吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbResult == MessageBoxResult.Yes)
            {
                ErrType err = _businessService.DeleteHoliday(_loginID, selectedHoliday.HolidayID);
                if (err == GeneralErr.Success)
                    RemoveHolidayInfo(selectedHoliday);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #region 交易设置管理

        /// <summary>
        /// 获取交易设置信息
        /// </summary>
        public void GetTradingSettingInfo()
        {
            if (TradeConfigInfoList == null)
                TradeConfigInfoList = new ObservableCollection<TradeConfigInfo>();
            else
                TradeConfigInfoList.Clear();
            ErrType err = _tradeService.GetTradeSetInfo(_loginID, ref _TradeConfigInfoList);
            if (err != GeneralErr.Success)
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// 添加交易设置信息
        /// </summary>
        public void AddTradingSettingInfo()
        {
            TradeConfigInfo selInfo = new TradeConfigInfo();
            TradeSetWindow window = new TradeSetWindow()
            {
                DataContext = selInfo,
                Owner = Application.Current.MainWindow
            };
            window.CodeEnable = true;
            if (window.ShowDialog() == true)
            {
                if (TradeConfigInfoList.Where(p => p.ObjCode == selInfo.ObjCode).Count() > 0)
                {
                    MessageBox.Show("名称编码不能重复，请重新填写", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
                    AddTradingSettingInfo();
                }
                else
                {
                    ErrType err = _businessService.AddTradeSet(selInfo, _loginID);
                    if (err != GeneralErr.Success)
                        MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                    else
                        TradeConfigInfoList.Add(selInfo);
                }
            }
        }

        /// <summary>
        /// 修改交易设置信息
        /// </summary>
        public void ModifyTradingSettingInfo(TradeConfigInfo selInfo)
        {
            TradeSetWindow window = new TradeSetWindow()
                                        {
                                            DataContext = selInfo,
                                            Owner = Application.Current.MainWindow
                                        };
            window.CodeEnable = false;
            if (window.ShowDialog() == true)
            {
                ErrType err = _businessService.ModifyTradeSet(_loginID, selInfo);
                if (err != GeneralErr.Success)
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                //GetTradingSettingInfo();
            }
        }

        /// <summary>
        /// 删除交易设置信息
        /// </summary>
        public void DelTradingSettingInfo(TradeConfigInfo selInfo)
        {
            MessageBoxResult result = MessageBox.Show("您确定删除当前数据吗？", "提示信息", MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                ErrType err = _businessService.DelTradeSet(selInfo.ObjCode, _loginID);
                if (err != GeneralErr.Success)
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                else
                    TradeConfigInfoList.Remove(selInfo);
            }
        }


        #endregion

        #region 日志记录分页查询 马友春
        /// <summary>
        /// 日志记录分页查询
        /// </summary>
        /// <param name="Cxqc">查询条件</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">页大小</param>
        /// <param name="pagesize">输出参数：总页数</param>
        /// <param name="page">返回列表</param>
        /// <returns></returns>
        public List<LogInformation> GetTradeALogInfoWithPage(int pageindex, int pagesize, ref int pageCount, int logType, DateTime startTime, DateTime endTime,string account)
        {
            DateTime endDate = new DateTime(endTime.AddDays(1).Year, endTime.AddDays(1).Month, endTime.AddDays(1).Day);
            LogQueryConInfomation uqc = new LogQueryConInfomation
            {
                LoginID = _loginID,
                LogType = logType,
                Starttime = startTime,
                Endtime = endDate,
                Account = account
            };
            List<LogInformation> logList;
            ErrType err = _businessService.GetTradeALogInfoWithPage(uqc, pageindex, pagesize, ref pageCount, out logList);
            if (err == GeneralErr.Success)
            {
                if (logList != null)
                {
                    ClearLogInfoList();
                    AddLogInfoList(logList);
                }
            }
            else
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            return logList;
        }
        #endregion

        #region 日志信息

        /// <summary>
        /// 获取日志信息列表
        /// </summary>
        public void GetLogInfoList()
        {
            List<LogInformation> list;
            IsLoadingLogInfo = true;

            ErrType err = _businessService.GetLogInfo(_loginID, LogRequestInfo, out list);
            IsLoadingLogInfo = false;
            if (err == GeneralErr.Success)
            {
                if (list != null)
                {
                    ClearLogInfoList();
                    AddLogInfoList(list);
                }
            }
            else
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        #endregion

        #region IP地址过滤

        /// <summary>
        /// 获取过滤IP地址列表
        /// </summary>
        public void GetIPAddressFilterInfoList()
        {
            List<IPAddressFilterInformation> list;
            IsLoadingIPAddrFilter = true;

            ErrType err = _businessService.GetIPAddrFilteringInfoList(_loginID, out list);
            IsLoadingIPAddrFilter = false;
            if (err == GeneralErr.Success)
            {
                if (list != null)
                {
                    ClearIPAddrFilterList();
                    AddIPAddrFilterInfoList(list);
                }
            }
            else
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// 显示详细的选中的IP地址过滤信息
        /// </summary>
        /// <param name="IpFilterInfo">选中的IP地址过滤条件</param>
        public void ShowIPAddressFilterInfo(IPAddressFilterInformation IpFilterInfo)
        {
            IPAddressFilterInformation clone = (IPAddressFilterInformation)IpFilterInfo.Clone();
            IPAddrFilterInfoWindow wnd = new IPAddrFilterInfoWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = clone,
            };

            if (wnd.ShowDialog() == true)
            {
                ErrType err = _businessService.ModifyIPAddrFilteringInfo(_loginID, clone);
                if (err == GeneralErr.Success)
                    IpFilterInfo.Sync(clone);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// 删除指定的IP地址过滤信息
        /// </summary>
        /// <param name="IpFilterInfo">要删除的IP地址过滤信息</param>
        public void DeleteIPAddressFilterInfo(IPAddressFilterInformation IpFilterInfo)
        {
            MessageBoxResult mbResult = MessageBox.Show("确认删除该条记录吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbResult == MessageBoxResult.Yes)
            {
                ErrType err = _businessService.DeleteIPAddrFilteringInfo(_loginID, IpFilterInfo.FilterID);
                if (err == GeneralErr.Success)
                    RemoveIPAddrFilterInfo(IpFilterInfo);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #region MAC地址过滤

        /// <summary>
        /// 获取MAC过滤信息列表
        /// </summary>
        public void GetMACFilterInfoList()
        {
            List<MACFilterInformation> list;
            IsLoadingMACFilterInfo = true;

            ErrType err = _businessService.GetMACFilterInfoList(_loginID, out list);
            IsLoadingMACFilterInfo = false;
            if (err == GeneralErr.Success)
            {
                if (list != null)
                {
                    ClearMACFilterList();
                    AddMACFilterInfoList(list);
                }
            }
            else
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// 显示并修改选中的MAC过滤信息
        /// </summary>
        /// <param name="macFilterInfo">选中的MAC过滤信息</param>
        public void ShowMACFilterInfo(MACFilterInformation macFilterInfo)
        {
            MACFilterInformation clone = (MACFilterInformation)macFilterInfo.Clone();
            MACFilterInfoWindow wnd = new MACFilterInfoWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = clone,
            };

            if (wnd.ShowDialog() == true)
            {
                ErrType err = _businessService.ModifyMACFilterInfo(_loginID, clone);
                if (err == GeneralErr.Success)
                    macFilterInfo.Sync(clone);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// 删除选中的MAC过滤信息
        /// </summary>
        /// <param name="macFilterInfo">选中的MAC过滤信息</param>
        public void DeleteMACFilterInfo(MACFilterInformation macFilterInfo)
        {
            MessageBoxResult mbResult = MessageBox.Show("确认删除该条记录吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbResult == MessageBoxResult.Yes)
            {
                ErrType err = _businessService.DeleteMACFilterInfo(_loginID, macFilterInfo.FilterID);
                if (err == GeneralErr.Success)
                    RemoveMACFileterInfo(macFilterInfo);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #endregion

        #region 数据管理部分
        #region 获取商品信息列表
        /// <summary>
        /// 获取商品信息列表
        /// </summary>
        public void GetProductInfoList()
        {
            List<ProductInformation> list;
            IsLoadingProductInfoList = true;
            ErrType err = _businessService.GetProductInfoList(_loginID, out list);
            IsLoadingProductInfoList = false;
            if (err == GeneralErr.Success)
            {
                if (list != null)
                {
                    ClearProductInfoList();
                    AddProductInfoList(list);
                }
            }
            else
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        #endregion

        #region 显示商品信息并修改

        /// <summary>
        /// 显示商品信息
        /// </summary>
        /// <param name="productInfo">选中的某个商品信息</param>
        public void ShowProductInfo(ProductInformation productInfo)
        {
            ProductInformation clone = (ProductInformation)productInfo.Clone();
            ProductInfoWindow wnd = new ProductInfoWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = clone,
                RawMaterialsCodeList = ProductInfoes.Select(p => p.RawMaterialsCode).Distinct().ToList(),
                IsNew = false
            };

            if (wnd.ShowDialog() == true)
            {
                ErrType err = _businessService.ModifyProductInfo(_loginID, clone);
                if (err == GeneralErr.Success)
                    productInfo.Sync(clone);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #region 删除商品信息

        /// <summary>
        /// 删除指定商品
        /// </summary>
        /// <param name="productInfo">要删除的商品</param>
        public void DeleteProductInfo(ProductInformation productInfo)
        {
            MessageBoxResult mbResult = MessageBox.Show("确定要删除该商品吗？", "删除确认", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (mbResult == MessageBoxResult.Yes)
            {
                ErrType err = _businessService.DeleteProductInfo(_loginID, productInfo.ProductCode);
                if (err == GeneralErr.Success)
                    RemoveProductInfo(productInfo);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #region 获取汇率和水信息列表

        /// <summary>
        /// 获取汇率和水信息列表
        /// </summary>
        public void GetRateWaterInfoList()
        {
            List<ExchangeRateWaterInformation> list;
            IsLoadingRateWaterInfoList = true;

            ErrType err = _businessService.GetRateWaterInfoList(_loginID, out list);
            IsLoadingRateWaterInfoList = false;
            if (err == GeneralErr.Success)
            {
                if (list != null)
                {
                    ClearRateWaterInfoList();
                    AddRateWaterInfoList(list);
                }
            }
            else
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// 显示汇率和水的信息
        /// </summary>
        /// <param name="rateWaterInfo">选中的某个汇率和水信息</param>
        public void ShowRateWaterInfo(ExchangeRateWaterInformation rateWaterInfo)
        {
            ExchangeRateWaterInformation clone = (ExchangeRateWaterInformation)rateWaterInfo.Clone();
            RateWaterInfoWindow wnd = new RateWaterInfoWindow
            {
                Owner = Application.Current.MainWindow,
                DataContext = clone,
            };

            if (wnd.ShowDialog() == true)
            {
                ErrType err = _businessService.ModifyRateWaterInfo(_loginID, clone);
                if (err == GeneralErr.Success)
                    rateWaterInfo.Sync(clone);
                else
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        #endregion

        #region 手工报价
        /// <summary>
        /// 手工报价
        /// </summary>
        /// <param name="productInfo"></param>
        public void ManualPrice(ProductInformation productInfo)
        {
            ManualPriceWindow window = new ManualPriceWindow()
            {
                Owner = Application.Current.MainWindow,
                DataContext = productInfo,

            };
            window.ManualPriceChangeEvent += new ManualPriceChangeEventHander(window_ManualPriceChangeEvent);
            window.ShowDialog();
            //if (window.ShowDialog() == true)
            //{
            //    if (productInfo != null)
            //    {
            //        double min =productInfo.RealTimePrice- productInfo.SpreadBaseValue * 20;
            //        double max = productInfo.RealTimePrice + productInfo.SpreadBaseValue * 20;
            //        if (window.ManualPrice < min || window.ManualPrice > max)
            //        {
            //            string info = string.Format("实时报价必须大于等于:{0}\t且\t小于等于:{1}",min,max);
            //            MessageBox.Show(info, "提示信息",MessageBoxButton.OK,MessageBoxImage.Error);
            //            return;
            //        }
            //        _businessService.ManualPrice(_loginID, productInfo.ProductCode, window.ManualPrice);
            //    }

            //}
        }

        void window_ManualPriceChangeEvent(object sender, PriceEventArgs args)
        {
            System.Threading.Thread.Sleep(100);
            _businessService.ManualPrice(_loginID, args.StockCode, args.ManualPrice);
        }
        #endregion

        #endregion

        #region 释放资源

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            _businessService.Dispose();
        }

        #endregion

        #endregion

        #region 辅助方法

        #region 创建账户

        /// <summary>
        /// 创建一个客户账户
        /// </summary>
        /// <returns>新创建的包含默认值的客户账户</returns>
        private ClientAccount CreateClientAcc()
        {
            return new ClientAccount
            {
                AccInfo =
                {
                    LastUpdateManager = _accName,
                    LastUpdateTime = DateTime.Now,
                    OpenAccountTime = DateTime.Now,
                    Sex = SEX.Male,
                },
            };
        }

        /// <summary>
        /// 创建一个金商账户
        /// </summary>
        /// <returns>新创建的金商账户</returns>
        private DealerAccount CreateDealerAcc()
        {
            return new DealerAccount
            {
                AccInfo =
                {
                    OpenAccountTime = DateTime.Now,
                },
            };
        }

        #endregion

        #region 有效性验证

        /// <summary>
        /// 验证市价单定单信息的有效性
        /// </summary>
        /// <param name="newInfo">新定单的详细信息</param>
        /// <param name="selectedProduct">选中下单的商品</param>
        /// <param name="operateClient">该市价单定单对应的某个用户</param>
        /// <returns>验证结果</returns>
        private ValidationResult MarketOrderInfoValidation(NewMarketOrderInfo newInfo, ProductInformation selectedProduct, ClientAccount operateClient)
        {
            return OrderInfoBaseValidation(newInfo, selectedProduct, operateClient);
        }

        /// <summary>
        /// 验证限价单定单信息的有效性
        /// </summary>
        /// <param name="newInfo">新挂单的详细信息</param>
        /// <param name="selectedProduct">选中下单的商品</param>
        /// <param name="operateClient">该市价单定单对应的某个用户</param>
        /// <returns>验证结果</returns>
        private ValidationResult PendingOrderInfoValidation(NewPendingOrderInfo newInfo, ProductInformation selectedProduct, ClientAccount operateClient)
        {
            double priceDeviation = selectedProduct.PendingOrderSpread * selectedProduct.SpreadBaseValue;
            double minPriceCaps = newInfo.RealTimePrice - priceDeviation;//最小价格上限
            double maxPriceLows = newInfo.RealTimePrice + priceDeviation;//最大价格下限

            if (newInfo.PendingOrdersPrice > minPriceCaps && newInfo.PendingOrdersPrice < maxPriceLows)
            {
                string msg = string.Format("无效的订单价!\r\n订单价必须大于等于:{0}\t或\t小于等于:{1}", maxPriceLows, minPriceCaps);
                return new ValidationResult(false, msg);
            }

            return OrderInfoBaseValidation(newInfo, selectedProduct, operateClient);
        }

        /// <summary>
        /// 验证定单基本信息的有效性
        /// </summary>
        /// <param name="newInfo">定单基本信息</param>
        /// <param name="selectedProduct">选中下单的商品</param>
        /// <param name="operateClient">该市价单定单对应的某个用户</param>
        /// <returns>ValidationResult</returns>
        private ValidationResult OrderInfoBaseValidation(NewOrderInfoBase newInfo, ProductInformation selectedProduct, ClientAccount operateClient)
        {
            //定单价验证
            if (newInfo.RealTimePrice > selectedProduct.AllowMaxPrice)
                return new ValidationResult(false, "允许的最大交易价格为：" + selectedProduct.AllowMaxPrice);
            if (newInfo.RealTimePrice < selectedProduct.AllowMinPrice)
                return new ValidationResult(false, "允许的最小交易价格为：" + selectedProduct.AllowMinPrice);

            //定单数量的验证
            if (newInfo.Count > operateClient.TransactionSettings.MaxTrade)
                return new ValidationResult(false, "允许的最大交易手数为：" + operateClient.TransactionSettings.MaxTrade);
            if (newInfo.Count < operateClient.TransactionSettings.MinTrade)
                return new ValidationResult(false, "允许的最小交易手数为：" + operateClient.TransactionSettings.MinTrade);
            ValidationResult result = ValidationHelper.OrderCountValidation(newInfo.Count, operateClient.TransactionSettings.OrderUnit);
            if (!result.IsValid)
                return result;

            //止损和止盈价验证
            if (newInfo.StopLossPrice != 0)
            {
                if (newInfo.StopLossPrice < 0)
                    return new ValidationResult(false, "止损价不能小于0");

                //进行止损价的验证
                result = ValidationHelper.StopLossPriceValidation(newInfo.StopLossPrice, selectedProduct.RealTimePrice, (int)newInfo.OrderType, selectedProduct.SpreadBaseValue, selectedProduct.LossProfitSpread);
                if (!result.IsValid)
                    return result;
            }
            if (newInfo.StopProfitPrice != 0)
            {
                if (newInfo.StopProfitPrice < 0)
                    return new ValidationResult(false, "止盈价不能小于0");

                //进行止盈价的验证
                result = ValidationHelper.StopProfitPriceValidation(newInfo.StopProfitPrice, selectedProduct.RealTimePrice, (int)newInfo.OrderType, selectedProduct.SpreadBaseValue, selectedProduct.LossProfitSpread);
                if (!result.IsValid)
                    return result;
            }

            return new ValidationResult(true, null);
        }

        /// <summary>
        /// 平仓信息的验证
        /// </summary>
        /// <param name="ordersInfo">平仓的详细信息</param>
        /// <param name="operateClient">要平仓的某个用户的定单</param>
        /// <returns>ValidationResult</returns>
        private ValidationResult ChargebackOrderValidation(OrderChangedInformation ordersInfo, ClientAccount operateClient)
        {
            return ValidationHelper.OrderCountValidation(ordersInfo.Count, operateClient.TransactionSettings.OrderUnit);
        }
        #endregion

        #region 客户列表操作相关

        /// <summary>
        /// 添加一个客户账户到客户列表
        /// </summary>
        /// <param name="clientAcc">要添加的新的客户账户</param>
        private void AddClientAccount(ObservableCollection<ClientAccount> list, ClientAccount clientAcc)
        {
            if (_dpObj.CheckAccess())
                list.Add(clientAcc);
            else
            {
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new ClientAccountDelegate(item => list.Add(item)),
                    clientAcc);
            }
        }

        /// <summary>
        /// 将一个客户账户从客户列表中移除
        /// </summary>
        /// <param name="clientAcc">要删除的客户账户</param>
        private void RemoveClientAccount(ObservableCollection<ClientAccount> list, ClientAccount clientAcc)
        {
            if (_dpObj.CheckAccess())
                list.Remove(clientAcc);
            else
            {
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new ClientAccountDelegate(item => list.Remove(item)),
                    clientAcc);
            }
        }


        #endregion

        #region 金商列表操作相关

        /// <summary>
        /// 添加一个金商账户到金商账户列表
        /// </summary>
        /// <param name="dealerAcc">要添加的新的金商账户</param>
        private void AddDealerAccount(DealerAccount dealerAcc)
        {
            //if (_dpObj.CheckAccess())
            //    DealerAccountList.Add(dealerAcc);
            //else
            //    _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
            //        new DealerAccountDelegate(item => DealerAccountList.Add(item)),
            //        dealerAcc);
        }

        /// <summary>
        /// 将一个金商账户从金商账户列表中移除
        /// </summary>
        /// <param name="dealerAcc">要移除的金商账户</param>
        private void RemoveDealerAccount(DealerAccount dealerAcc)
        {
            //if (_dpObj.CheckAccess())
            //    DealerAccountList.Remove(dealerAcc);
            //else
            //    _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
            //        new DealerAccountDelegate(item => DealerAccountList.Remove(item)),
            //        dealerAcc);
        }



        /// <summary>
        /// 添加一个金商账户列表到金商账户列表
        /// </summary>
        /// <param name="dealerList">要添加的金商账户列表</param>
        private void AddDealerAccountList(List<DealerAccount> dealerList)
        {
            if (_dpObj.CheckAccess())
                dealerList.ForEach(AddDealerAccount);
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new AddDealerListDelegate(list => list.ForEach(AddDealerAccount)),
                    dealerList);
        }

        #endregion

        #region 管理员列表操作相关

        /// <summary>
        /// 添加一个管理员账户到管理员账户列表
        /// </summary>
        /// <param name="mgrAcc">要添加的新的管理员账户</param>
        private void AddManagerAccount(ManagerAccount mgrAcc)
        {
            //if (_dpObj.CheckAccess())
            //    ManagerAccountList.Add(mgrAcc);
            //else
            //    _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
            //        new ManagerAccountDeleaget(item => ManagerAccountList.Add(item)),
            //        mgrAcc);
        }

        /// <summary>
        /// 将一个管理员账户从管理员账户列表中移除
        /// </summary>
        /// <param name="mgrAcc">要移除的管理员账户</param>
        private void RemoveManagerAccount(ManagerAccount mgrAcc)
        {
            //if (_dpObj.CheckAccess())
            //    ManagerAccountList.Remove(mgrAcc);
            //else
            //    _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
            //        new ManagerAccountDeleaget(item => ManagerAccountList.Remove(item)),
            //        mgrAcc);
        }


        #endregion

        #region 交易日列表操作相关

        /// <summary>
        /// 清楚交易日信息列表
        /// </summary>
        private void ClearTradingDayInfoList()
        {
            if (_dpObj.CheckAccess())
                TradingDayInfoes = new ObservableCollection<TradingDayInformation>();
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(ClearTradingDayInfoList));
        }

        /// <summary>
        /// 添加交易日信息列表到交易日信息列表
        /// </summary>
        /// <param name="infoList">交易日信息列表</param>
        private void AddTradingDayInfoList(List<TradingDayInformation> infoList)
        {
            if (_dpObj.CheckAccess())
                infoList.ForEach(item => TradingDayInfoes.Add(item));
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new AddTradingDayInfoListDelegate(list => list.ForEach(item => TradingDayInfoes.Add(item))),
                    infoList);
        }

        #endregion

        #region 节假日列表操作相关

        /// <summary>
        /// 清除节假日信息列表
        /// </summary>
        private void ClearHolidayInfoList()
        {
            if (_dpObj.CheckAccess())
                HolidayInfoes = new ObservableCollection<HolidayInformation>();
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(ClearHolidayInfoList));
        }

        /// <summary>
        /// 添加一个节假日信息到节假日信息列表
        /// </summary>
        /// <param name="holidayInfo">要添加的节假日信息</param>
        private void AddHolidayInfo(HolidayInformation holidayInfo)
        {
            if (_dpObj.CheckAccess())
                HolidayInfoes.Add(holidayInfo);
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new HolidayInfoDelegate(item => HolidayInfoes.Add(item)),
                    holidayInfo);
        }

        /// <summary>
        /// 将一个节假日从节假日信息列表中移除
        /// </summary>
        /// <param name="holidayInfo">要移除的节假日信息</param>
        private void RemoveHolidayInfo(HolidayInformation holidayInfo)
        {
            if (_dpObj.CheckAccess())
                HolidayInfoes.Remove(holidayInfo);
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new HolidayInfoDelegate(item => HolidayInfoes.Remove(item)),
                    holidayInfo);
        }

        /// <summary>
        /// 添加节假日信息列表到节假日信息列表
        /// </summary>
        /// <param name="infoList">节假日信息列表</param>
        private void AddHolidayInfoList(List<HolidayInformation> infoList)
        {
            if (_dpObj.CheckAccess())
                infoList.ForEach(item => HolidayInfoes.Add(item));
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new AddHolidayInfoListDelegate(list => list.ForEach(item => HolidayInfoes.Add(item))),
                    infoList);
        }

        #endregion

        #region 日志信息操作相关

        /// <summary>
        /// 清除日志信息列表
        /// </summary>
        private void ClearLogInfoList()
        {
            if (_dpObj.CheckAccess())
                LogInfoes = new ObservableCollection<LogInformation>();
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(ClearLogInfoList));
        }

        /// <summary>
        /// 添加一个日志信息列表到日志信息列表
        /// </summary>
        /// <param name="infoList">要添加的日志信息列表</param>
        private void AddLogInfoList(List<LogInformation> infoList)
        {
            if (_dpObj.CheckAccess())
                infoList.ForEach(item => LogInfoes.Add(item));
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new AddLogInfoListDeleage(list => list.ForEach(item => LogInfoes.Add(item))),
                    infoList);
        }

        #endregion

        #region IP地址过滤操作相关
        /// <summary>
        /// 清除IP地址过滤信息列表
        /// </summary>
        private void ClearIPAddrFilterList()
        {
            if (_dpObj.CheckAccess())
                IPAddrFilterInfoes = new ObservableCollection<IPAddressFilterInformation>();
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(ClearIPAddrFilterList));
        }

        /// <summary>
        /// 添加一个IP地址过滤信息到列表
        /// </summary>
        /// <param name="ipAddrFilterInfo">要添加的新的IP地址过滤信息</param>
        private void AddIPAddrFilterInfo(IPAddressFilterInformation ipAddrFilterInfo)
        {
            if (_dpObj.CheckAccess())
                IPAddrFilterInfoes.Add(ipAddrFilterInfo);
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new IPAddrFilterInfoDelegate(item => IPAddrFilterInfoes.Add(item)),
                    ipAddrFilterInfo);
        }

        /// <summary>
        /// 将选定的IP地址过滤信息从列表中移除
        /// </summary>
        /// <param name="ipAddrFilterInfo">要移除的某个IP地址过滤信息</param>
        private void RemoveIPAddrFilterInfo(IPAddressFilterInformation ipAddrFilterInfo)
        {
            if (_dpObj.CheckAccess())
                IPAddrFilterInfoes.Remove(ipAddrFilterInfo);
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new IPAddrFilterInfoDelegate(item => IPAddrFilterInfoes.Remove(item)),
                    ipAddrFilterInfo);
        }

        /// <summary>
        /// 添加IP地址过滤信息列表到IP地址过滤信息列表
        /// </summary>
        /// <param name="infoList">要添加的IP地址过滤信息列表</param>
        private void AddIPAddrFilterInfoList(List<IPAddressFilterInformation> infoList)
        {
            if (_dpObj.CheckAccess())
                infoList.ForEach(item => IPAddrFilterInfoes.Add(item));
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new AddIPAddrFilterInfoListDelegate(list => list.ForEach(item => IPAddrFilterInfoes.Add(item))),
                    infoList);
        }

        #endregion

        #region MAC地址过滤操作相关

        /// <summary>
        /// 清除MAC地址过滤信息列表
        /// </summary>
        private void ClearMACFilterList()
        {
            if (_dpObj.CheckAccess())
                MACFilterInfoes = new ObservableCollection<MACFilterInformation>();
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(ClearMACFilterList));
        }

        /// <summary>
        /// 添加一个MAC地址过滤信息到列表
        /// </summary>
        /// <param name="macFilterInfo">要添加的新的MAC地址过滤信息</param>
        private void AddMACFilterInfo(MACFilterInformation macFilterInfo)
        {
            if (_dpObj.CheckAccess())
                MACFilterInfoes.Add(macFilterInfo);
            else
            {
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new MACFilterInfoDelegate(item => MACFilterInfoes.Add(item)),
                    macFilterInfo);
            }
        }

        /// <summary>
        /// 将选中的MAC过滤信息从列表中移除
        /// </summary>
        /// <param name="macFilterInfo">要移除的某个MAC地址过滤信息</param>
        private void RemoveMACFileterInfo(MACFilterInformation macFilterInfo)
        {
            if (_dpObj.CheckAccess())
                MACFilterInfoes.Remove(macFilterInfo);
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new MACFilterInfoDelegate(item => MACFilterInfoes.Remove(item)),
                    macFilterInfo);
        }

        /// <summary>
        /// 添加MAC过滤信息列表到MAC过滤信息列表
        /// </summary>
        /// <param name="infoList">要添加的MAC过滤信息列表</param>
        private void AddMACFilterInfoList(List<MACFilterInformation> infoList)
        {
            if (_dpObj.CheckAccess())
                infoList.ForEach(item => MACFilterInfoes.Add(item));
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new AddMACFilterInfoListDelegate(list => list.ForEach(item => MACFilterInfoes.Add(item))),
                    infoList);
        }

        #endregion

        #region 商品信息列表操作相关

        /// <summary>
        /// 添加一个商品信息到商品信息列表
        /// </summary>
        /// <param name="productInfo">要添加的商品信息</param>
        private void AddProductInfo(ProductInformation productInfo)
        {
            if (_dpObj.CheckAccess())
                ProductInfoes.Add(productInfo);
            else
                _dpObj.Dispatcher.Invoke(DispatcherPriority.Normal,
                    new ProductInfoDelegate(item => ProductInfoes.Add(item)),
                    productInfo);
        }

        /// <summary>
        /// 将一个商品信息从列表中移除
        /// </summary>
        /// <param name="productInfo">要删除的商品信息</param>
        private void RemoveProductInfo(ProductInformation productInfo)
        {
            if (_dpObj.CheckAccess())
                ProductInfoes.Remove(productInfo);
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new ProductInfoDelegate(item => ProductInfoes.Remove(item)),
                    productInfo);
        }

        /// <summary>
        /// 清除商品信息列表
        /// </summary>
        private void ClearProductInfoList()
        {
            if (_dpObj.CheckAccess())
                ProductInfoes = new ObservableCollection<ProductInformation>();
            else
                _dpObj.Dispatcher.Invoke(DispatcherPriority.Normal,
                    new Action(ClearProductInfoList));
        }

        /// <summary>
        /// 添加一个商品信息列表到商品信息列表
        /// </summary>
        /// <param name="productInfoList">要添加的商品信息列表</param>
        private void AddProductInfoList(List<ProductInformation> productInfoList)
        {
            if (_dpObj.CheckAccess())
                productInfoList.ForEach(AddProductInfo);
            else
                _dpObj.Dispatcher.Invoke(DispatcherPriority.Normal,
                    new AddProductInfoListDelegate(list => list.ForEach(AddProductInfo)),
                    productInfoList);
        }

        #endregion

        #region 汇率和水信息列表操作相关

        /// <summary>
        /// 添加汇率和水信息到信息列表
        /// </summary>
        /// <param name="rateWaterInfo">要添加的汇率和水信息</param>
        private void AddRateWaterInfo(ExchangeRateWaterInformation rateWaterInfo)
        {
            if (_dpObj.CheckAccess())
                RateWaterInfoes.Add(rateWaterInfo);
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new RateWaterInfoDelegate(item => RateWaterInfoes.Add(item)),
                    rateWaterInfo);
        }

        /// <summary>
        /// 清楚汇率和水信息列表
        /// </summary>
        private void ClearRateWaterInfoList()
        {
            if (_dpObj.CheckAccess())
                RateWaterInfoes = new ObservableCollection<ExchangeRateWaterInformation>();
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(ClearRateWaterInfoList));
        }

        /// <summary>
        /// 添加一个汇率和水信息列表到列表
        /// </summary>
        /// <param name="rateWaterInfoList">要添加一个汇率和水的信息列表</param>
        private void AddRateWaterInfoList(List<ExchangeRateWaterInformation> rateWaterInfoList)
        {
            if (_dpObj.CheckAccess())
                rateWaterInfoList.ForEach(AddRateWaterInfo);
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new AddRateWaterInfoListDelegate(list => list.ForEach(AddRateWaterInfo)),
                    rateWaterInfoList);
        }

        #endregion

        #region 有效定单列表操作相关

        /// <summary>
        /// 清楚有效定单列表
        /// </summary>
        private void ClearMarketOrderList()
        {
            if (_dpObj.CheckAccess())
                MarketOrderList = new ObservableCollection<MarketOrderData>();
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(ClearMarketOrderList));
        }

        /// <summary>
        /// 添加一个有效定单到有效定单列表，并为其赋值它所属的商品信息类
        /// </summary>
        /// <param name="orderData">要添加的有效定单</param>
        private void AddMarketOrderData(MarketOrderData orderData)
        {
            ProductInformation productInfo = GetProductInfoByName(orderData.ProductName);
            orderData.OwnedProduct = productInfo;

            if (_dpObj.CheckAccess())
                MarketOrderList.Add(orderData);
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new MarketOrderDataDelegate(AddMarketOrderData),
                    orderData);
        }

        /// <summary>
        /// 从有效定单列表中移除指定的有效定单
        /// </summary>
        /// <param name="orderData">要移除的有效定单</param>
        private void RemoveMarketOrderData(MarketOrderData orderData)
        {
            if (_dpObj.CheckAccess())
                TradeOrderInfo.TdOrderList.Remove(orderData);
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new MarketOrderDataDelegate(RemoveMarketOrderData),
                    orderData);
        }

        /// <summary>
        /// 添加一个有效定单列表到列表
        /// </summary>
        /// <param name="orderList">要添加的有效定单列表</param>
        private void AddMarketOrderList(List<MarketOrderData> orderList)
        {
            if (_dpObj.CheckAccess())
                orderList.ForEach(AddMarketOrderData);
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new AddMarketOrderListDelegate(list => list.ForEach(AddMarketOrderData)),
                    orderList);
        }

        #endregion

        #region 限价挂单列表操作相关

        /// <summary>
        /// 清楚限价挂单列表
        /// </summary>
        private void ClearPendingOrderList()
        {
            if (_dpObj.CheckAccess())
                PendingOrderList = new ObservableCollection<PendingOrderData>();
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(ClearPendingOrderList));
        }

        /// <summary>
        /// 添加一个限价挂单到限价挂单列表，并为其赋值它所属的商品信息类
        /// </summary>
        /// <param name="orderData">要添加的限价挂单</param>
        private void AddPendingOrderData(PendingOrderData orderData)
        {
            ProductInformation productInfo = GetProductInfoByName(orderData.ProductName);
            orderData.OwnedProduct = productInfo;

            if (_dpObj.CheckAccess())
                PendingOrderList.Add(orderData);
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new PendingOrderDataDelegate(AddPendingOrderData),
                    orderData);
        }

        /// <summary>
        /// 从限价挂单列表中移除指定的限价挂单
        /// </summary>
        /// <param name="orderData">要移除的限价挂单</param>
        private void RemovePendingOrderData(PendingOrderData orderData)
        {
            if (_dpObj.CheckAccess())
                TradeHoldOrderInfo.TdHoldOrderList.Remove(orderData);
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new PendingOrderDataDelegate(RemovePendingOrderData),
                    orderData);
        }

        /// <summary>
        /// 添加限价挂单列表到列表
        /// </summary>
        /// <param name="orderList">要添加的限价挂单列表</param>
        private void AddPendingOrderList(List<PendingOrderData> orderList)
        {
            if (_dpObj.CheckAccess())
                orderList.ForEach(AddPendingOrderData);
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new AddPendingOrderListDelegate(list => list.ForEach(AddPendingOrderData)),
                    orderList);
        }

        #endregion

        #region 对冲交易列表操作相关

        /// <summary>
        /// 清楚对冲交易列表
        /// </summary>
        private void ClearHedgingTradeList()
        {
            //HedgingHistoryList
            if (_dpObj.CheckAccess())
                HedgingTradeList = new ObservableCollection<HedgingTradeData>();
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(ClearHedgingTradeList));
        }

        /// <summary>
        /// 添加一个对冲交易列表到对冲交易列表
        /// </summary>
        /// <param name="hedgingList">要添加的对冲交易列表</param>
        private void AddHedgingTradeList(List<HedgingTradeData> hedgingList)
        {
            if (_dpObj.CheckAccess())
                hedgingList.ForEach(item => HedgingTradeList.Add(item));
            else
                _dpObj.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new AddHedgingTradeListDelegate(list => list.ForEach(item => HedgingTradeList.Add(item))),
                    hedgingList);
        }

        #endregion

        #region 根据商品名称获取商品信息类

        /// <summary>
        /// 通过商品名称从商品信息列表中获取商品信息类
        /// </summary>
        /// <param name="productName">商品名称</param>
        /// <returns>商品信息列表中匹配的商品类或者为null</returns>
        private ProductInformation GetProductInfoByName(string productName)
        {
            return ProductInfoes.FirstOrDefault(item => item.ProductName.Equals(productName));
        }

        #endregion


        #region 警告
        /// <summary>
        /// 播放警告声音
        /// </summary>
        public void Warning()
        {
            MediaPlayer player = new MediaPlayer();
            Uri uri = new Uri(@"alert.wav", UriKind.Relative);
            player.Open(uri);
            player.Play();
        }
        #endregion
        /// <summary>
        /// 将账户类型ACCOUNT_TYPE转换成UserType对应的值
        /// </summary>
        /// <param name="accType"></param>
        /// <returns></returns>
        public static int ToUserType(ACCOUNT_TYPE accType)
        {
            if (accType == ACCOUNT_TYPE.Manager)
            {
                return 1;
            }
            else if (accType == ACCOUNT_TYPE.Dealer)
            {
                return 2;
            }
            else
            {
                throw new NotSupportedException(string.Format("不支持的账户类型：{0}", accType));
            }
        }
        #endregion
        #region 客户分组相关ViewModel
        #region 命令
        private ICommand _GeuUserGroupsCmd;

        /// <summary>
        /// 获取用户分组列表命令
        /// </summary>
        public ICommand GeuUserGroupsCmd
        {
            get
            {
                if (_GeuUserGroupsCmd == null)
                    _GeuUserGroupsCmd = new RelayCommand(AddProductInfoExecute);

                return _GeuUserGroupsCmd;
            }
        }



        private ICommand _AddUserGroupCmd;

        /// <summary>
        /// 获取用户分组列表命令
        /// </summary>
        public ICommand AddUserGroupCmd
        {
            get
            {
                if (_AddUserGroupCmd == null)
                    _AddUserGroupCmd = new RelayCommand(AddUserGroupEx);

                return _AddUserGroupCmd;
            }
        }



        private ICommand _DelUserGroupCmd;

        /// <summary>
        /// 删除用户分组列命令
        /// </summary>
        public ICommand DelUserGroupCmd
        {
            get
            {
                if (_DelUserGroupCmd == null)
                    _DelUserGroupCmd = new RelayCommand(DelUserGroupEx);

                return _DelUserGroupCmd;
            }
        }


        private ICommand _AlterUserGroupCmd;

        /// <summary>
        /// 修改用户分组列命令
        /// </summary>
        public ICommand AlterUserGroupCmd
        {
            get
            {
                if (_AlterUserGroupCmd == null)
                    _AlterUserGroupCmd = new RelayCommand(AlterUserGroupEx);

                return _AlterUserGroupCmd;
            }
        }


        private ICommand _AddGroupAccountCmd;

        /// <summary>
        /// 添加组用户
        /// </summary>
        public ICommand AddGroupAccountCmd
        {
            get
            {
                if (_AddGroupAccountCmd == null)
                    _AddGroupAccountCmd = new RelayCommand(AddGroupAccountEx);

                return _AddGroupAccountCmd;
            }
        }

        private ICommand _DelAccountFromGroupCmd;

        /// <summary>
        /// 删除组用户
        /// </summary>
        public ICommand DelAccountFromGroupCmd
        {
            get
            {
                if (_DelAccountFromGroupCmd == null)
                    _DelAccountFromGroupCmd = new RelayCommand(DelAccountFromGroupEx);

                return _DelAccountFromGroupCmd;
            }
        }

        private ICommand _GetAccountsByGroupCmd;

        /// <summary>
        /// 获取分组下的用户
        /// </summary>
        public ICommand GetAccountsByGroupCmd
        {
            get
            {
                if (_GetAccountsByGroupCmd == null)
                    _GetAccountsByGroupCmd = new RelayCommand(GetAccountsByGroupEx);

                return _GetAccountsByGroupCmd;
            }
        }
        #endregion
        #region 获取用户分组
        /// <summary>
        /// 获取用户分组
        /// </summary>
        public void GetUserGroupsEx()
        {
            UserGroups.Clear();
            ErrType rst = _businessService.GetUserGroupsInfo(UserGroups);
            if (rst.Err != ERR.SUCCESS)
            {
                MessageBox.Show("获取用户分组列表失败：" + rst.ErrMsg);
            }
            else if (UserGroups.Count>0)
            {
                CurUserGroup = UserGroups[0];
            }
        }
        #endregion
        #region 添加用户分组
        /// <summary>
        /// 添加用户分组
        /// </summary>
        private void AddUserGroupEx()
        {
            AddUserGroup win = new AddUserGroup();
            win.SubmitEvent += new Action<AddUserGroup>(win_SubmitEvent);
            win.ShowDialog();

        }

        void win_SubmitEvent(AddUserGroup obj)
        {
            try
            {
                foreach (var item in UserGroups)
                {
                    if (item.UserGroupName == obj.UserGroupInstance.UserGroupName)
                    {
                        MessageBox.Show("已存在相同名称的分组！");
                        return;
                    }
                }

                ErrType rst = _businessService.AddUserGroups(obj.UserGroupInstance, _loginID);
                if (rst.Err != ERR.SUCCESS)
                {
                    MessageBox.Show("添加用户分组失败：" + rst.ErrMsg);
                }
                else
                {
                    UserGroups.Add(obj.UserGroupInstance);
                    MessageBox.Show("添加用户分组成功");
                    obj.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加用户分组失败：" + ex.Message);

            }
        }
        #endregion
        #region 删除分组
        private void DelUserGroupEx()
        {
            try
            {
                if (CurUserGroup == null)
                {
                    MessageBox.Show("请先选择需要删除的分组");
                    return;
                }
                if (MessageBox.Show("是否确认删除选中分组："+CurUserGroup.UserGroupName+"？","提示",MessageBoxButton.YesNo,MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return;
                }
                ErrType rst = _businessService.DelUserGroups(CurUserGroup.UserGroupId, _loginID);
                if (rst.Err != ERR.SUCCESS)
                {
                    MessageBox.Show("删除用户分组失败：" + rst.ErrMsg);
                }
                else
                {
                    MessageBox.Show("删除用户分组成功");
                    UserGroups.Remove(CurUserGroup);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除用户分组失败：" + ex.Message);
            }
        }
        #endregion
        #region 修改分组
        private void AlterUserGroupEx()
        {
            AlterUserGroup win = new AlterUserGroup() { DataContext = CurUserGroup };
            win.SubmitEvent += new Action<AlterUserGroup>(win_SubmitEvent);
            win.ShowDialog();
        }

        void win_SubmitEvent(AlterUserGroup obj)
        {
            try
            {
                ErrType rst = _businessService.ModifyUserGroups(CurUserGroup, _loginID);
                if (rst.Err != ERR.SUCCESS)
                {
                    MessageBox.Show("修改用户分组失败：" + rst.ErrMsg);
                }
                else
                {
                    MessageBox.Show("修改用户分组成功");
                    obj.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改用户分组失败：" + ex.Message);

            }
        }

        #endregion
        #region 添加用户到分组
        private void AddGroupAccountEx()
        {
            if (CurUserGroup == null)
            {
                MessageBox.Show("还没有分组，请先添加分组？", "提示", MessageBoxButton.OK, MessageBoxImage.Question);
                return;
                
            }
            AddGroupAccount win = new AddGroupAccount() { DataContext = CurUserGroup };
            win.SubmitEvent += new Action<AddGroupAccount>(win_SubmitEvent);
            win.ShowDialog();
        }

        void win_SubmitEvent(AddGroupAccount obj)
        {
            try
            {
                ClientAccount c = new ClientAccount();
                ErrType rst = _businessService.AddUserToUserGroups(obj.Account, CurUserGroup.UserGroupId, _loginID, ref c);

                if (rst.Err != ERR.SUCCESS)
                {
                    MessageBox.Show(rst.ErrMsg);
                }
                else
                {
                    MessageBox.Show("用户添加到组成功");
                    GroupAccounts.Add(c);
                    obj.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        #endregion
        #region 删除分组下的用户
        private void DelAccountFromGroupEx()
        {
            try
            {
                if (MessageBox.Show("是否确认将：" + CurGroupAccount.AccInfo.UserName+"删除？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    return;
                }
                ErrType rst = _businessService.DelUserFromUserGroups(CurGroupAccount.AccInfo.UserID, CurUserGroup.UserGroupId, _loginID);

                if (rst.Err != ERR.SUCCESS)
                {
                    MessageBox.Show("删除用户失败：" + rst.ErrMsg);

                }
                else
                {
                    MessageBox.Show("删除用户成功");
                    GroupAccounts.Remove(CurGroupAccount);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除用户失败：" + ex.Message);

            }
        }
        #endregion
        #region 获取分组下的所有客户
        public void GetAccountsByGroupEx()
        {
            try
            {
                GroupAccounts.Clear();
                if (CurUserGroup == null)
                {
                    return;
                }
                UserQueryConInfomation uqc = new UserQueryConInfomation
                {
                    LoginID = _loginID,
                    TradeAccount = UserGroupSelectCon.Account,
                    UserName = UserGroupSelectCon.UserName,
                    CardNum = UserGroupSelectCon.CardNum,
                    OrgName = UserGroupSelectCon.OrgName,
                    UserTypeInfo = UserTypeInfo.NormalType,
                    GroupID = CurUserGroup.UserGroupId
                };
                int pageCount = 0;
                UserBaseInfo = _businessService.GetUserBaseInfoWithPage(uqc, UserGroupSelectCon.PageIndex, UserGroupSelectCon.PageSize, ref pageCount);

                if (UserBaseInfo.Result)
                {
                    UserGroupSelectCon.PageCount = pageCount;
                    foreach (var item in UserBaseInfo.TdUserList)
                    {
                        GroupAccounts.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show(UserBaseInfo.Desc, "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        #endregion
        #region 属性
        private ObservableCollection<UserGroup> _UserGroups;
        /// <summary>
        /// 客户分组列表
        /// </summary>
        public ObservableCollection<UserGroup> UserGroups
        {
            get { return _UserGroups; }
            set
            {
                _UserGroups = value;
                RaisePropertyChanged("UserGroups");
            }
        }



        private UserGroup _CurUserGroup;
        /// <summary>
        /// 客户分组列表当前选择项
        /// </summary>
        public UserGroup CurUserGroup
        {
            get { return _CurUserGroup; }
            set
            {
                _CurUserGroup = value;
                if (value != null)
                {
                    GetAccountsByGroupEx();
                }
                RaisePropertyChanged("CurUserGroup");
            }
        }

        private SelectCondition _UserGroupSelectCon;
        /// <summary>
        /// 用户分组查询条件
        /// </summary>
        public SelectCondition UserGroupSelectCon
        {
            get { return _UserGroupSelectCon; }
            set
            {
                _UserGroupSelectCon = value;
                RaisePropertyChanged("UserGroupSelectCon");
            }
        }


        private ObservableCollection<ClientAccount> _GroupAccounts;

        public ObservableCollection<ClientAccount> GroupAccounts
        {
            get { return _GroupAccounts; }
            set
            {
                _GroupAccounts = value;
                RaisePropertyChanged("GroupAccounts");
            }
        }

        private ClientAccount _CurGroupAccount;

        public ClientAccount CurGroupAccount
        {
            get { return _CurGroupAccount; }
            set { _CurGroupAccount = value; }
        }


        #endregion
        #endregion


        public void SetCommissionRatio(int type)
        {
            if (CurOrgInfo != null)
            {
                CommissionRatioSet ratio = new CommissionRatioSet();
                bool isSystem = false;
                if (type == 2)
                    isSystem = true;
                ErrType err = _tradeService.GetCommissionRatio(_loginID, CurOrgInfo.OrgID, ref  ratio, isSystem);
                if (err.Err != ERR.SUCCESS)
                {
                    MessageBox.Show("获取会员返佣比例出错", "提示信息", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    SetCommissionRatioWindow win = new SetCommissionRatioWindow()
                    {
                        Owner = Application.Current.MainWindow,
                        Ratio1=ratio.Ratio1,
                        Ratio2=ratio.Ratio2,
                        Ratio3=ratio.Ratio3,
                        DataContext = this
                    };
                    List<string> orgIDList = new List<string>();
                    if (win.ShowDialog() == true)
                    {
                        if (type == 1)//当前项
                        {
                            orgIDList.Add(CurOrgInfo.OrgID);
                        }
                        else if (type == 2)//默认
                        {
                            orgIDList.Add("system");
                        }
                        else//批量
                        {
                           
                            foreach (OrgInfo org in OrgList)
                            {
                                if (org.IsCheck == true)
                                    orgIDList.Add(org.OrgID);
                            }
                            if(orgIDList.Count==0)
                                orgIDList.Add(CurOrgInfo.OrgID);
                        }
                        ErrType err2 = _tradeService.SetCommissionRatio(_loginID, win.Ratio1, win.Ratio2, win.Ratio3, orgIDList);
                        if (err2.Err != ERR.SUCCESS)
                            MessageBox.Show("设置返佣比例出错！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
           
        }

        /// <summary>
        /// 获取体验券信息
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<ExperienceInformation> GetExperienceInfo(int type, int isEffciive, DateTime? endTime)
        {
            ObservableCollection<ExperienceInformation> list = new ObservableCollection<ExperienceInformation>();
            ErrType rst = _businessService.GetExperienceInfo(_loginID,type,  isEffciive, endTime, ref list);
            if (rst.Err != ERR.SUCCESS)
            {
                MessageBox.Show("获取体验券信息失败：" + rst.ErrMsg);
            }
            return list;
        }

        /// <summary>
        /// 添加体验券
        /// </summary>
        public ExperienceInformation AddExperience()
        {
            ExperienceWindow win = new ExperienceWindow()
            {
                Owner=Application.Current.MainWindow,
                CurExperienceInformation=new ExperienceInformation()
            };
            if (win.ShowDialog() == true)
            {
                if (win.CurExperienceInformation != null)
                {
                    if (win.CurExperienceInformation.Name == "开户送券")
                        win.CurExperienceInformation.Type = 1;
                    else
                        win.CurExperienceInformation.Type = 2;
                }
                win.CurExperienceInformation.StartDate = win.StartDate;
                win.CurExperienceInformation.EndDate = new DateTime(win.EndDate.Year, win.EndDate.Month, win.EndDate.Day,23,59,59);
                win.CurExperienceInformation.EffectiveTime = new DateTime(win.EffectiveTime.Year, win.EffectiveTime.Month, win.EffectiveTime.Day, 23, 59, 59);
                ErrType err = _businessService.AddExperience(_loginID,win.CurExperienceInformation);
                if (err.Err != ERR.SUCCESS)
                {
                    MessageBox.Show("添加体验券失败！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
            }
            return win.CurExperienceInformation;
        }


        /// <summary>
        /// 编辑体验券
        /// </summary>
        /// <param name="ex">体验券</param>
        /// <returns>ResultDesc</returns>
        public void EditExperience(ExperienceInformation ex)
        {
            ExperienceWindow win = new ExperienceWindow()
            {
                Owner = Application.Current.MainWindow,
                CurExperienceInformation = ex,
                StartDate=ex.StartDate,
                EndDate=ex.EndDate,
                EffectiveTime=ex.EffectiveTime
            };
            if (win.ShowDialog() == true)
            {
                if (win.CurExperienceInformation != null)
                {
                    if (win.CurExperienceInformation.Name == "开户送券")
                        win.CurExperienceInformation.Type = 1;
                    else
                        win.CurExperienceInformation.Type = 2;
                }
                win.CurExperienceInformation.StartDate = win.StartDate;
                win.CurExperienceInformation.EndDate = new DateTime(win.EndDate.Year, win.EndDate.Month, win.EndDate.Day, 23, 59, 59);
                win.CurExperienceInformation.EffectiveTime = new DateTime(win.EffectiveTime.Year, win.EffectiveTime.Month, win.EffectiveTime.Day, 23, 59, 59);
                ErrType err = _businessService.EditExperience(_loginID, win.CurExperienceInformation);
                if (err.Err != ERR.SUCCESS)
                    MessageBox.Show("保存体验券失败！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                    MessageBox.Show("保存体验券成功！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// 删除体验券
        /// </summary>
        public bool DelExperience(int id)
        {
            MessageBoxResult rest= MessageBox.Show("确定删除选中体验券记录？", "提示信息", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (rest == MessageBoxResult.OK)
            {
                ErrType err = _businessService.DelExperience(_loginID, id);
                if (err.Err != ERR.SUCCESS)
                {
                    MessageBox.Show("删除失败,请重试！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                    return true;

            }
            return true;
        }
    }
}

