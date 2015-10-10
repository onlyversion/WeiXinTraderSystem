using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Gss.Common.Infrastructure;
using Gss.Entities;
using Gss.Entities.BzjEntities;
using Gss.Entities.Enums;
using Gss.Entities.Interface;
using Gss.Entities.SystemSetting;
using Gss.PopUpWindow.AccountManager;
using Gss.PopUpWindow.TradeManager;

namespace Gss.ViewModel.Management
{
    public partial class ManagementViewModel
    {
        
        #region 查询条件
        private SelectCondition _TakeGoodsDetialSelectCondition;
        /// <summary>
        /// 金商提货明细查询条件
        /// </summary>
        public SelectCondition TakeGoodsDetialSelectCondition
        {
            get { return _TakeGoodsDetialSelectCondition; }
            private set
            {
                _TakeGoodsDetialSelectCondition = value;
                RaisePropertyChanged("TakeGoodsDetialSelectCondition");
            }
        }

        private SelectCondition _BindingJgjAccountCondition;
        /// <summary>
        /// 绑定金生金账户
        /// </summary>
        public SelectCondition BindingJgjAccountCondition
        {
            get { return _BindingJgjAccountCondition; }
            private set
            {
                _BindingJgjAccountCondition = value;
                RaisePropertyChanged("BindingJgjAccountCondition");
            }
        }

        private SelectCondition _DeliveryGoodsCondition;
        /// <summary>
        /// 查询金商交割单（买涨）条件
        /// </summary>
        public SelectCondition DeliveryGoodsCondition
        {
            get { return _DeliveryGoodsCondition; }
            private set
            {
                _DeliveryGoodsCondition = value;
                RaisePropertyChanged("DeliveryGoodsCondition");
            }
        }

        private SelectCondition _TakeGoodsCondition;
        /// <summary>
        /// 提货单查询条件
        /// </summary>
        public SelectCondition TakeGoodsCondition
        {
            get { return _TakeGoodsCondition; }
            private set
            {
                _TakeGoodsCondition = value;
                RaisePropertyChanged("TakeGoodsCondition");
            }
        }

        private SelectCondition _BackGoodsCondition;
        /// <summary>
        /// 买跌单查询条件
        /// </summary>
        public SelectCondition BackGoodsCondition
        {
            get { return _BackGoodsCondition; }
            private set
            {
                _BackGoodsCondition = value;
                RaisePropertyChanged("BackGoodsCondition");
            }
        }

        private SelectCondition _JgjGoodsCondition;
        /// <summary>
        /// 金生金单查询条件
        /// </summary>
        public SelectCondition JgjGoodsCondition
        {
            get { return _JgjGoodsCondition; }
            private set
            {
                _JgjGoodsCondition = value;
                RaisePropertyChanged("JgjGoodsCondition");
            }
        }

        private SelectCondition _DeliveryBackGoodsCondition;
        /// <summary>
        /// 交割单（买跌）查询条件
        /// </summary>
        public SelectCondition DeliveryBackGoodsCondition
        {
            get { return _DeliveryBackGoodsCondition; }
            private set
            {
                _DeliveryBackGoodsCondition = value;
                RaisePropertyChanged("DeliveryBackGoodsCondition");
            }
        }

        private SelectCondition _GetClerkCondition;
        /// <summary>
        /// 查询店员信息条件
        /// </summary>
        public SelectCondition GetClerkCondition
        {
            get { return _GetClerkCondition; }
            private set
            {
                _GetClerkCondition = value;
                RaisePropertyChanged("GetClerkCondition");
            }
        }


        #endregion

       
        #region 属性定义
        private BzjClerk _ClerkAccountInfo;
        /// <summary>
        /// 店员账户信息
        /// </summary>
        public BzjClerk ClerkAccountInfo
        {
            get { return _ClerkAccountInfo; }
            set
            {
                _ClerkAccountInfo = value;
                RaisePropertyChanged("ClerkAccountInfo");
            }
        }

        private DealerAuthority _ClerkAuthInfo;
        /// <summary>
        /// 店员权限
        /// </summary>
        public DealerAuthority ClerkAuthInfo
        {
            get
            {

                return _ClerkAuthInfo;
            }
            set
            {
                _ClerkAuthInfo = value;
                RaisePropertyChanged("ClerkAuthInfo");
            }
        }

        /// <summary>
        /// 保证金服务
        /// </summary>
        private IBzjService _bzjService;

        private BzjInfoInformation _BzjInfoInformation;
        /// <summary>
        /// 保证金信息
        /// </summary>
        public BzjInfoInformation BzjInfoInformation
        {
            get { return _BzjInfoInformation; }
            private set
            {
                _BzjInfoInformation = value;
                RaisePropertyChanged("BzjInfoInformation");
            }
        }

        private BzjOrderEntity _BzjOrderEntity;
        /// <summary>
        /// 定单信息
        /// </summary>
        public BzjOrderEntity BzjOrderEntity
        {
            get { return _BzjOrderEntity; }
            private set
            {
                _BzjOrderEntity = value;
                RaisePropertyChanged("BzjOrderEntity");
            }
        }
        #endregion


        #region 数据集
        private ObservableCollection<BzjTakeGoodsDetailEntity> _TakeGoodsDetailList;
        /// <summary>
        /// 金商提货明细
        /// </summary>
        public ObservableCollection<BzjTakeGoodsDetailEntity> TakeGoodsDetailList
        {
            get { return _TakeGoodsDetailList; }
            private set
            {
                _TakeGoodsDetailList = value;
                RaisePropertyChanged("TakeGoodsDetailList");
            }
        }

        private ObservableCollection<BzjDeliverEntity> _DeliveryGoodsList;
        /// <summary>
        /// 金商交割单（买涨）数据集
        /// </summary>
        public ObservableCollection<BzjDeliverEntity> DeliveryGoodsList
        {
            get { return _DeliveryGoodsList; }
            private set
            {
                _DeliveryGoodsList = value;
                RaisePropertyChanged("DeliveryGoodsList");
            }
        }

        private ObservableCollection<BzjOrderEntity> _TakeGoodsList;
        /// <summary>
        /// 提货单数据集
        /// </summary>
        public ObservableCollection<BzjOrderEntity> TakeGoodsList
        {
            get { return _TakeGoodsList; }
            private set
            {
                _TakeGoodsList = value;

                RaisePropertyChanged("TakeGoodsList");
            }
        }

        private ObservableCollection<BzjOrderEntity> _BackGoodsList;
        /// <summary>
        /// 买跌单数据集
        /// </summary>
        public ObservableCollection<BzjOrderEntity> BackGoodsList
        {
            get { return _BackGoodsList; }
            private set
            {
                _BackGoodsList = value;
                RaisePropertyChanged("BackGoodsList");
            }
        }

        private ObservableCollection<BzjOrderEntity> _JgjGoodsList;
        /// <summary>
        /// 金生金单数据集
        /// </summary>
        public ObservableCollection<BzjOrderEntity> JgjGoodsList
        {
            get { return _JgjGoodsList; }
            private set
            {
                _JgjGoodsList = value;
                RaisePropertyChanged("JgjGoodsList");
            }
        }

        private List<BzjRecoverOrder> _DeliveryBackGoodsList;
        /// <summary>
        /// 交割单（买跌）数据集
        /// </summary>
        public List<BzjRecoverOrder> DeliveryBackGoodsList
        {
            get { return _DeliveryBackGoodsList; }
            private set
            {
                _DeliveryBackGoodsList = value;
                RaisePropertyChanged("DeliveryBackGoodsList");
            }
        }


        private ObservableCollection<BzjClerk> _ClerkAccountList;
        /// <summary>
        /// 店员信息列表
        /// </summary>
        public ObservableCollection<BzjClerk> ClerkAccountList
        {
            get { return _ClerkAccountList; }
            private set
            {
                _ClerkAccountList = value;
                RaisePropertyChanged("ClerkAccountList");
            }
        }

    

        
        #endregion


        #region Command
        private ICommand _GetTakeGoodsDetialBzjReportCommand;
        /// <summary>
        /// 金生金
        /// </summary>
        public ICommand GetTakeGoodsDetialBzjReportCommand
        {
            get
            {
                if (_GetTakeGoodsDetialBzjReportCommand == null)
                    _GetTakeGoodsDetialBzjReportCommand = new RelayCommand(GetTakeGoodsDetialBzjReportExecute);
                return _GetTakeGoodsDetialBzjReportCommand;
            }
        }

        private ICommand _BindingBzjAccountCommand;
        /// <summary>
        /// 绑定金生金账户
        /// </summary>
        public ICommand BindingBzjAccountCommand
        {
            get
            {
                if (_BindingBzjAccountCommand == null)
                    _BindingBzjAccountCommand = new RelayCommand(BindingBzjAccountExecute);
                return _BindingBzjAccountCommand;
            }
        }

        private ICommand _GetDeliveryGoodsCommand;
        /// <summary>
        /// 获取买涨交割单命令
        /// </summary>
        public ICommand GetDeliveryGoodsCommand
        {
            get
            {
                if (_GetDeliveryGoodsCommand == null)
                    _GetDeliveryGoodsCommand = new RelayCommand(GetDeliveryGoodsExecute);
                return _GetDeliveryGoodsCommand;
            }
        }


        private ICommand _GetTakeGoodsCommand;
        /// <summary>
        /// 获取买涨单信息命令
        /// </summary>
        public ICommand GetTakeGoodsCommand
        {
            get
            {
                if (_GetTakeGoodsCommand == null)
                    _GetTakeGoodsCommand = new RelayCommand(GetTakeGoodsExecute);
                return _GetTakeGoodsCommand;
            }
        }

        private ICommand _GetBackGoodsCommand;
        /// <summary>
        /// 获取买跌单命令
        /// </summary>
        public ICommand GetBackGoodsCommand
        {
            get
            {
                if (_GetBackGoodsCommand == null)
                    _GetBackGoodsCommand = new RelayCommand(GetBackGoodsExecute);
                return _GetBackGoodsCommand;
            }
        }



        private ICommand _GetJgjGoodsCommand;
        /// <summary>
        /// 获取金生金单数据命令
        /// </summary>
        public ICommand GetJgjGoodsCommand
        {
            get
            {
                if (_GetJgjGoodsCommand == null)
                    _GetJgjGoodsCommand = new RelayCommand(GetJgjGoodsExecute);
                return _GetJgjGoodsCommand;
            }
        }

        private ICommand _GetDeliveryBackGoodsCommand;
        /// <summary>
        /// 获取交割单（买跌）数据命令
        /// </summary>
        public ICommand GetDeliveryBackGoodsCommand
        {
            get
            {
                if (_GetDeliveryBackGoodsCommand == null)
                    _GetDeliveryBackGoodsCommand = new RelayCommand(GetDeliveryBackGoodsExecute);
                return _GetDeliveryBackGoodsCommand;
            }
        }

        private ICommand _CreateClerkCommand;
        /// <summary>
        /// 创建店员命令
        /// </summary>
        public ICommand CreateClerkCommand
        {
            get
            {
                if (_CreateClerkCommand == null)
                    _CreateClerkCommand = new RelayCommand(CreateClerkExecute);
                return _CreateClerkCommand;
            }
        }

        private ICommand _GetClerkCommand;
        /// <summary>
        /// 获取店员信息
        /// </summary>
        public ICommand GetClerkCommand
        {
            get
            {
                if (_GetClerkCommand == null)
                    _GetClerkCommand = new RelayCommand(GetClerkExecute);
                return _GetClerkCommand;
            }
        }

        private ICommand _ShowClerkAccountInfoCommand;
        /// <summary>
        /// 显示店员信息
        /// </summary>
        public ICommand ShowClerkAccountInfoCommand
        {
            get
            {
                if (_ShowClerkAccountInfoCommand == null)
                    _ShowClerkAccountInfoCommand = new RelayCommand(ShowClerkAccountInfoExecute);
                return _ShowClerkAccountInfoCommand;
            }
        }

        private ICommand _DelClerkCommand;
        /// <summary>
        /// 删除店员
        /// </summary>
        public ICommand DelClerkCommand
        {
            get
            {
                if (_DelClerkCommand == null)
                    _DelClerkCommand = new RelayCommand(DelClerkExecute);
                return _DelClerkCommand;
            }
        }
        #endregion


        #region ---账户管理---
        #region 客户管理--> 库存管理（调整库存）
        /// <summary>
        /// 库存管理
        /// </summary>
        public void InventoryManager(ClientAccount client)
        {
            ErrType err = _bzjService.GetAdminUserStockInfo(_loginID, client.AccInfo.UserID, ref _BzjInfoInformation, (int)_accType);
            if (err.Err == ERR.SUCCESS)
            {
                BzjInfoInformation = _BzjInfoInformation;
                InventoryManagerWindow window = new InventoryManagerWindow()
                  {
                      Owner = Application.Current.MainWindow,
                      DataContext = this,

                  };
                if (window.ShowDialog() == true)
                {
                    double au = 0;
                    double ag = 0;
                    double pt = 0;
                    double pd = 0;
                    bool hasError = false;
                    if (BzjInfoInformation.AuUpdate <= 0)
                    {
                        au = BzjInfoInformation.AuUpdate;
                    }
                    else
                    {
                        string deliverNo = DateTime.Now.ToString("yyMMddhhmmsssffff");
                        ErrType error = _bzjService.CreateDeliverAdmin(client.AccInfo.UserID, _accName, client.AccInfo.AccountName, "1",
                            "XAU", _loginID, deliverNo, (decimal)BzjInfoInformation.AuUpdate, (double)BzjInfoInformation.AuPrice, 13, (int)_accType);
                        if (error.Err != ERR.SUCCESS)
                        {
                            MessageBox.Show(error.ErrMsg, error.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }

                    if (BzjInfoInformation.AgUpdate <= 0)
                    {
                        ag = BzjInfoInformation.AgUpdate;
                    }
                    else
                    {
                        string deliverNo = DateTime.Now.ToString("yyMMddhhmmsssffff");
                        ErrType error = _bzjService.CreateDeliverAdmin(client.AccInfo.UserID, _accName, client.AccInfo.AccountName, "1",
                            "XAG", _loginID, deliverNo, (decimal)BzjInfoInformation.AgUpdate, (double)BzjInfoInformation.AgPrice, 13, (int)_accType);
                        if (error.Err != ERR.SUCCESS)
                        {
                            MessageBox.Show(error.ErrMsg, error.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }

                    if (BzjInfoInformation.PtUpdate <= 0)
                    {
                        pt = BzjInfoInformation.PtUpdate;
                    }
                    else
                    {
                        string deliverNo = DateTime.Now.ToString("yyMMddhhmmsssffff");
                        ErrType error = _bzjService.CreateDeliverAdmin(client.AccInfo.UserID, _accName, client.AccInfo.AccountName, "1",
                            "XPT", _loginID, deliverNo, (decimal)BzjInfoInformation.PtUpdate, (double)BzjInfoInformation.PtPrice, 13, (int)_accType);
                        if (error.Err != ERR.SUCCESS)
                        {
                            MessageBox.Show(error.ErrMsg, error.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }

                    if (BzjInfoInformation.PdUpdate <= 0)
                    {
                        pd = BzjInfoInformation.PdUpdate;
                    }
                    else
                    {
                        string deliverNo = DateTime.Now.ToString("yyMMddhhmmsssffff");
                        ErrType error = _bzjService.CreateDeliverAdmin(client.AccInfo.UserID, _accName, client.AccInfo.AccountName, "1",
                            "XPD", _loginID, deliverNo, (decimal)BzjInfoInformation.PdUpdate, (double)BzjInfoInformation.PdPrice, 13, (int)_accType);
                        if (error.Err != ERR.SUCCESS)
                        {
                            MessageBox.Show(error.ErrMsg, error.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                    if (au < 0 || ag < 0 || pt < 0 || pd < 0)
                    {
                        ErrType errDeliver = _bzjService.CreateStockDeliverAdmin(_accName, _loginID, client.AccInfo.UserID,
                                                                            client.AccInfo.AccountName, au, ag, pt, pd, (int)_accType);
                        if (errDeliver.Err != ERR.SUCCESS)
                        {
                            MessageBox.Show(errDeliver.ErrMsg, errDeliver.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }

                    if (BzjInfoInformation.AuUpdate != 0 || BzjInfoInformation.AgUpdate != 0 || BzjInfoInformation.PtUpdate != 0 || BzjInfoInformation.PdUpdate != 0)
                    {
                        MessageBox.Show("库存更改成功", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        #endregion

      

        #region 客户管理--> 实物入库
        /// <summary>
        /// 实物入库
        /// </summary>
        /// <param name="client"></param>
        public void EntityAccept(ClientAccount client)
        {
            EntityAcceptWindow window = new EntityAcceptWindow()
            {
                Owner = Application.Current.MainWindow,
                DataContext = this,
            };
            if (window.ShowDialog() == true)
            {
                string product = "";
                double price = 0;
                switch (window.ProductName)
                {
                    case "黄金":
                        product = "XAU";
                        price = ProductInfoes.Where(p => p.StockCode.Contains("XAU")).FirstOrDefault().RealTimePrice;
                        break;
                    case "白银":
                        product = "XAG";
                        price = ProductInfoes.Where(p => p.StockCode.Contains("XAG")).FirstOrDefault().RealTimePrice;
                        break;
                    case "钯金":
                        product = "XPD";
                        price = ProductInfoes.Where(p => p.StockCode.Contains("XPD")).FirstOrDefault().RealTimePrice;
                        break;
                    case "铂金":
                        product = "XPT";
                        price = ProductInfoes.Where(p => p.StockCode.Contains("XPT")).FirstOrDefault().RealTimePrice;
                        break;
                }
                string deliverNo = DateTime.Now.ToString("yyMMddhhmmsssffff");

                ErrType err = _bzjService.CreateDeliverAdmin(client.AccInfo.UserID, _accName, client.AccInfo.AccountName, "1",
                    product, _loginID, deliverNo, (decimal)window.Total, price, 9, (int)_accType);
                if (err.Err == ERR.SUCCESS)
                {
                    MessageBox.Show("实物入库成功", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

        }
        #endregion 
        #endregion
        
        
        #region ---交易管理---
        #region 有效定单--> 买跌检测[买跌单]
        /// <summary>
        /// 买跌检测[买跌单] 
        /// 定单类型为买跌时有效
        /// </summary>
        /// <param name="selData"></param>
        public void RecordRealWeight(MarketOrderData selData)
        {

            RecordRealWeightWindow window = new RecordRealWeightWindow()
            {
                Owner = Application.Current.MainWindow,
                DataContext = this,
                
            };
            if (window.ShowDialog() == true)
            {
                if (selData.TotalWeight < window.RealWeight)
                    MessageBox.Show("您输入的重量大于您的库存", "提示信息", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    ErrType err = _businessService.RecordRealWeight(selData.OrderID, window.RealWeight, _loginID, (int)_accType);
                    if (err.Err == ERR.SUCCESS)
                    {
                        selData.AllowStore = true;
                        MessageBox.Show("您可以入库了", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                }
              
            }
        }
        #endregion

        #region 获取买涨交割单信息
        public void GetDeliveryGoodsExecute()
        {
            if (DeliveryGoodsList != null && DeliveryGoodsList.Count > 0)
                DeliveryGoodsList.Clear();
            BzjDeliverEntity entity = new BzjDeliverEntity();

            entity.Account = DeliveryGoodsCondition.Account;//客户账号
            entity.DeliverNo = DeliveryGoodsCondition.OrderNO;//单号
            entity.CreateDate = DeliveryGoodsCondition.StartTime.ToString();//提货开始时间
            entity.EndDate = DeliveryGoodsCondition.EndTime.AddDays(1).ToString();//提货结束时间
            int pageCount = 0;
            ErrType err = _bzjService.GetDeliverOrderList(_loginID, entity, DeliveryGoodsCondition.UserName,
                                                          DeliveryGoodsCondition.PageIndex,
                                                          DeliveryGoodsCondition.PageSize, ref pageCount,
                                                          ref _DeliveryGoodsList, (int)_accType);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DeliveryGoodsCondition.PageCount = pageCount;
                DeliveryGoodsList = _DeliveryGoodsList;
            }


        }
        #endregion

        #region 获取买跌交割单数据
        /// <summary>
        /// 获取买跌交割单数据
        /// </summary>
        public void GetDeliveryBackGoodsExecute()
        {
            if (DeliveryBackGoodsList != null && DeliveryBackGoodsList.Count > 0)
                DeliveryBackGoodsList.Clear();
            CxQueryConInfomation query = new CxQueryConInfomation();
            query.UserType = (int)_accType;
            query.TradeAccount = DeliveryBackGoodsCondition.Account;
            query.LoginID = _loginID;
            query.StartTime = DeliveryBackGoodsCondition.StartTime;
            query.EndTime = DeliveryBackGoodsCondition.EndTime.AddDays(1);
            int pageCount = 0;
            ErrType err = _businessService.GetMultiTradeChcekWithPage(query, DeliveryBackGoodsCondition.PageIndex,
                                                                      DeliveryBackGoodsCondition.PageSize, ref pageCount,
                                                                      ref _DeliveryBackGoodsList);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DeliveryBackGoodsCondition.PageCount = pageCount;
                DeliveryBackGoodsList = _DeliveryBackGoodsList;
            }
        }

        #endregion
        
        #region 买跌交割单-->[买跌]处理
        /// <summary>
        /// 交割单[买跌]处理
        /// </summary>
        /// <param name="selectData"></param>
        public void ModifyTradeCheck(BzjRecoverOrder selectData)
        {
            ModifyBackTradeWindow window = new ModifyBackTradeWindow()
            {
                Owner = Application.Current.MainWindow,
                DataContext = this
            };
            if (window.ShowDialog() == true)
            {
                ErrType err = _businessService.ModifyTradeCheck(selectData.OrderId, window.PayTime, _loginID, (int)_accType);
                if (err.Err != ERR.SUCCESS)
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    selectData.PayTime = window.PayTime;
                    selectData.DoPerson = _accName;
                    selectData.StateString = "已受理";
                }
            }
        }
        #endregion

        #region 获取提货单数据
        public void GetTakeGoodsExecute()
        {
            if (TakeGoodsList != null && TakeGoodsList.Count > 0)
                TakeGoodsList.Clear();
            BzjOrderEntity entity = new BzjOrderEntity();

            entity.Account = TakeGoodsCondition.Account;//客户账号
            entity.OrderNO = TakeGoodsCondition.OrderNO;//单号
            entity.Name = TakeGoodsCondition.UserName;//姓名
            entity.OrderCode = TakeGoodsCondition.OrderCode;//验证码
            entity.CreateDate = TakeGoodsCondition.StartTime.ToString();//提货开始时间
            entity.EndDate = TakeGoodsCondition.EndTime.AddDays(1).ToString();//提货结束时间
            int pageCount = 0;
            ErrType err = _bzjService.GetOrderTakeList(_loginID, entity, TakeGoodsCondition.PageIndex,
                TakeGoodsCondition.PageSize, ref pageCount, ref _TakeGoodsList, (int)_accType);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                TakeGoodsCondition.PageCount = pageCount;
                TakeGoodsList = _TakeGoodsList;
            }
        }
        #endregion

        #region 获取买跌单数据信息
        public void GetBackGoodsExecute()
        {
            if (BackGoodsList != null && BackGoodsList.Count > 0)
                BackGoodsList.Clear();
            BzjOrderEntity entity = new BzjOrderEntity();

            entity.Account = BackGoodsCondition.Account;//客户账号
            entity.OrderNO = BackGoodsCondition.OrderNO;//单号
            entity.Name = BackGoodsCondition.UserName;//姓名
            entity.OrderCode = BackGoodsCondition.OrderCode;//验证码
            entity.CreateDate = BackGoodsCondition.StartTime.ToString();//提货开始时间
            entity.EndDate = BackGoodsCondition.EndTime.AddDays(1).ToString();//提货结束时间
            int pageCount = 0;
            ErrType err = _bzjService.GetOrderBackList(_loginID, entity, BackGoodsCondition.PageIndex,
                BackGoodsCondition.PageSize, ref pageCount, ref _BackGoodsList, (int)_accType);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                BackGoodsCondition.PageCount = pageCount;
                BackGoodsList = _BackGoodsList;
            }
        }
        #endregion

        #region 买跌单--> 更新买跌单
        /// <summary>
        /// 更新买跌单
        /// </summary>
        /// <param name="selectData"></param>
        public void UpdateBuyBackOrder(BzjOrderEntity selectData)
        {
            ErrType err = _bzjService.UpdateBuyBackOrder(_loginID, selectData.OrderNO, _accName, (int)_accType);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                MessageBox.Show("更新成功", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
                selectData.OperationDate = DateTime.Now.ToShortDateString();//付款时间
                selectData.ClerkId = _accName;
                selectData.State = 2;//状态更新为完成
            }
        }
        #endregion

        #region 获取金生金单数据
        public void GetJgjGoodsExecute()
        {
            if (JgjGoodsList != null && JgjGoodsList.Count > 0)
                JgjGoodsList.Clear();
            BzjOrderEntity entity = new BzjOrderEntity();

            entity.Account = JgjGoodsCondition.Account;//客户账号
            entity.OrderNO = JgjGoodsCondition.OrderNO;//单号
            entity.Name = JgjGoodsCondition.UserName;//姓名
            entity.OrderCode = JgjGoodsCondition.OrderCode;//验证码
            entity.CreateDate = JgjGoodsCondition.StartTime.ToString();//提货开始时间
            entity.EndDate = JgjGoodsCondition.EndTime.AddDays(1).ToString();//提货结束时间
            int pageCount = 0;
            ErrType err = _bzjService.GetOrderJsjList(_loginID, entity, JgjGoodsCondition.PageIndex,
                JgjGoodsCondition.PageSize, ref pageCount, ref _JgjGoodsList, (int)_accType);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                JgjGoodsCondition.PageCount = pageCount;
                JgjGoodsList = _JgjGoodsList;
            }
        }
        #endregion 
        #endregion


        #region ---提货受理
        #region 提货定单明细
        /// <summary>
        ///	定单明细
        /// </summary>
        /// <param name="orderCode"></param>
        public ErrType GetOrderNOInfo(string orderCode)
        {
            ErrType err = _bzjService.GetOrderNOInfo(_loginID, orderCode, ref _BzjOrderEntity, (int)_accType);
            if (err.Err == ERR.SUCCESS)
                BzjOrderEntity = _BzjOrderEntity;
            else
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return err;
        }
        #endregion

        #region 提货

        /// <summary>
        /// 提货
        /// </summary>
        /// <param name="au"></param>
        /// <param name="ag"></param>
        /// <param name="orderCode"></param>
        public bool SubjectTakeGoodsOrder(decimal au, decimal ag, decimal pt, decimal pd, string orderCode)
        {
            string agentID = "";
            if (_accType == ACCOUNT_TYPE.DealerClerk)
                agentID = _ClerkAgentId;
            else if (_accType == ACCOUNT_TYPE.Dealer)
                agentID = _accName;
            else
                agentID = "";
            ErrType err = _bzjService.UpdateOrder(_accName, _loginID, agentID, "", orderCode, BzjOrderEntity.Account, _accName,
                                                  BzjOrderEntity.UserId, au, ag, pt, pd, (int)_accType);
            if (err.Err == ERR.SUCCESS)
            {
                MessageBox.Show("提货成功", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
            else
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        #endregion

        #region 提货受理明细

        /// <summary>
        /// 提货受理明细
        /// </summary>
        public void GetTakeGoodsDetialBzjReportExecute()
        {
            if (TakeGoodsDetailList != null && TakeGoodsDetailList.Count > 0)
                TakeGoodsDetailList.Clear();
            int pageCount = 0;
            ErrType err = _bzjService.GetAgentOrderList(_accName, _loginID, TakeGoodsDetialSelectCondition.Account, TakeGoodsDetialSelectCondition.OrderNO,
                TakeGoodsDetialSelectCondition.OrderCode, TakeGoodsDetialSelectCondition.UserName, TakeGoodsDetialSelectCondition.StartTime.ToString(),
                 TakeGoodsDetialSelectCondition.EndTime.AddDays(1).ToString(), TakeGoodsDetialSelectCondition.PageIndex,
                 TakeGoodsDetialSelectCondition.PageSize, ref pageCount, ref _TakeGoodsDetailList, (int)_accType);

            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            TakeGoodsDetialSelectCondition.PageCount = pageCount;
            TakeGoodsDetailList = _TakeGoodsDetailList;
        }
        #endregion

        #region 绑定金生金账户
        /// <summary>
        /// 绑定金生金账户
        /// </summary>
        public void BindingBzjAccountExecute()
        {
            ErrType err = _bzjService.AgentBind(BindingJgjAccountCondition.Account, _accName,
                                                BindingJgjAccountCondition.CardNum, _loginID, (int)_accType);
            if (err.Err != ERR.SUCCESS)
            {
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("绑定成功！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion
        #endregion
        
        
        #region ---店员---
        #region 创建店员
        /// <summary>
        /// 创建店员
        /// </summary>
        public void CreateClerkExecute()
        {
            ClerkAccountInfo = new BzjClerk();
            ClerkAccountInfo.AgentId = _accName;
            ClerkAuthInfo = new DealerAuthority();
            ClerkAccountWindow window = new ClerkAccountWindow()
                                            {
                                                AccNameVisibility = Visibility.Visible,
                                                Owner = Application.Current.MainWindow,
                                                DataContext = this
                                            };
            if (window.ShowDialog() == true)
            {
                ClerkAccountInfo.ClerkId = _accName + ClerkAccountInfo.ClerkId;//店员账号默认以金商账户名开头
                ErrType err = _businessService.AddClerk(ClerkAccountInfo, ClerkAuthInfo, _loginID, (int)_accType);
                if (err.Err != ERR.SUCCESS)
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    //Todo:移动到添加的行
                    ClerkAccountList.Add(ClerkAccountInfo);
                }
            }
        }
        #endregion

        #region 获取店员
        /// <summary>
        /// 获取店员
        /// </summary>
        public void GetClerkExecute()
        {
            if (ClerkAccountList != null && ClerkAccountList.Count > 0)
                ClerkAccountList.Clear();
            GetClerkCondition.IsBusy = true;
            BzjClerkQueryCon con = new BzjClerkQueryCon();
            con.LoginId = _loginID;
            string name = _accName;
            if (_accType == ACCOUNT_TYPE.DealerClerk)
                name = _ClerkAgentId;
            con.AgentId = name;
            con.ClerkId = GetClerkCondition.Account;
            con.ClerkName = GetClerkCondition.UserName;
            con.ClerkPhone = GetClerkCondition.Phone;
            con.UserType = (int)_accType;
            int pageCount = 0;
            ErrType err = _businessService.GetClerkBaseInfoWithPage(con, GetClerkCondition.PageIndex,
                GetClerkCondition.PageSize, ref pageCount, ref _ClerkAccountList);
            if (err.Err != ERR.SUCCESS)
                MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Information);
            else
            {
                GetClerkCondition.PageCount = pageCount;
                ClerkAccountList = _ClerkAccountList;
            }
            GetClerkCondition.IsBusy = false;
        }
        #endregion

        #region 显示店员信息
        /// <summary>
        /// 显示店员信息
        /// </summary>
        public void ShowClerkAccountInfoExecute()
        {

            //获取权限
            ErrType errClerk = _businessService.GetClerkAuth(ClerkAccountInfo.ClerkId, _loginID, (int)_accType,
                                                             ref _ClerkAuthInfo);
            if (errClerk.Err != ERR.SUCCESS)
            {
                MessageBox.Show(errClerk.ErrMsg, errClerk.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                ClerkAuthInfo = _ClerkAuthInfo;
            }
            //ClerkAuthInfo.IsCanSelectedAllTiHuoShouLiSub = false;
            //ClerkAuthInfo.IsCanSelcetedAllOperating = false;
            //ClerkAuthInfo.IsCanSelcetedAllTrade = false;
            ClerkAccountWindow window = new ClerkAccountWindow()
            {
                Owner = Application.Current.MainWindow,
                DataContext = this
            };
            if (window.ShowDialog() == true)
            {
                ErrType err = _businessService.ModifyClerk(ClerkAccountInfo, _loginID, (int)_accType);
                if (err.Err != ERR.SUCCESS)
                {
                    MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                ErrType errInfo = _businessService.ModifyClerkAuth(ClerkAuthInfo, ClerkAccountInfo.ClerkId, _loginID,
                                                                   (int)_accType);
                if (errInfo.Err != ERR.SUCCESS)
                {
                    MessageBox.Show(errInfo.ErrMsg, errInfo.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        }
        #endregion

        #region 删除店员
        /// <summary>
        /// 删除店员
        /// </summary>
        public void DelClerkExecute()
        {
            //    ErrType err = _businessService.DelClerk(ClerkAccountInfo.ClerkId, _loginID, (int) _accType);
            //    if (err.Err != ERR.SUCCESS)
            //    {
            //        MessageBox.Show(err.ErrMsg, err.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            //        return;
            //    }
            //    else
            //    {
            //        MessageBox.Show("删除店员成功！", "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
            //        ClerkAccountList.Remove(ClerkAccountInfo);
            //    }
        }
        #endregion 
        #endregion


        #region 激活金生金账户 弃用
        /// <summary>
        /// 激活金生金账户
        /// </summary>
        public void ActivateJgj(ClientAccount client)
        {
            //验证是否已激活金生金账户
            int exist = _bzjService.JgjIsUserExist(1, client.AccInfo.CertificateNumber);
            if (exist == 0)
            {
                string tip;//提示信息
                //随机生成的密码
                string pwd = new Random().Next(100000, 999999).ToString();
                string returnResult = _bzjService.JgjUserRegister((int)client.AccInfo.CeritificateEnum, client.AccInfo.CertificateNumber, pwd,
                    client.AccInfo.Dealer, (int)client.AccInfo.ClientType, client.AccInfo.UserName, client.AccInfo.CellPhoneNumber);

                if (returnResult == "1000")
                {
                    tip = "用户已经存在";
                }
                else if (returnResult == "2000")
                {
                    tip = "系统错误";
                }
                else
                {
                    tip = "金生金账户激活成功";
                    BzjUserBindEntity bzjentity = new BzjUserBindEntity();
                    bzjentity.UserId = client.AccInfo.UserID;
                    bzjentity.JUserId = returnResult;
                    ErrType errJgs = _bzjService.CreateAdminGssUser(bzjentity, _loginID, client.AccInfo.UserID, (int)_accType);
                    if (errJgs.Err != ERR.SUCCESS)
                    {
                        MessageBox.Show(errJgs.ErrMsg, errJgs.ErrTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                MessageBox.Show(tip, "提示信息", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion
    }
}
