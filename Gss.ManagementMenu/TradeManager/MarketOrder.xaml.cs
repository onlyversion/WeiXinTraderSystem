using System;
using System.Windows.Controls;
using System.Windows.Input;
using Gss.Entities;
using Gss.ManagementMenu.AccountManager.Order;
using Gss.ViewModel.Management;
using System.Windows;
using Gss.ManagementMenu.CustomControl;

namespace Gss.ManagementMenu.TradeManager
{
    /// <summary>
    /// MarketOrder.xaml 的交互逻辑
    /// 市价订单\在手订单
    /// </summary>
    public partial class MarketOrder
    {
        public MarketOrder()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed_Chargeback(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            MarketOrderData selectedOrder = (e.OriginalSource as DataGridRow).DataContext as MarketOrderData;
            vm.ChargebackMarketOrder(selectedOrder);
        }

        private void CommandBinding_Executed_Warehousing(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            MarketOrderData selectedOrder = (e.OriginalSource as DataGridRow).DataContext as MarketOrderData;
            vm.WarehousingMarketOrder(selectedOrder);
        }

        private void CommandBinding_CanExecute_Chargeback(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            e.CanExecute = true;
            //权限处理e.CanExecute = vm.AccountAuthority.AllowChargebackOrder;
        }

        private void CommandBinding_CanExecute_Warehousing(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            //e.CanExecute = vm.AccountAuthority.AllowWarehousingOrder;
            MarketOrderData selectedOrder = (e.OriginalSource as DataGridRow).DataContext as MarketOrderData;
            if (selectedOrder.AllowStore)
                e.CanExecute = true;
            //权限处理 e.CanExecute = vm.AccountAuthority.AllowWarehousingOrder;
            else
                e.CanExecute = false;
        }

        private void CommandBinding_Executed_AllowStore(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            MarketOrderData selectedOrder = (e.OriginalSource as DataGridRow).DataContext as MarketOrderData;
            vm.ModifyOrderAllowStore(selectedOrder);
        }

        private void CommandBinding_CanExecute_AllowStore(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        //买跌检测
        private void CommandBinding_Executed_RecordRealWeight(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            MarketOrderData selectedOrder = (e.OriginalSource as DataGridRow).DataContext as MarketOrderData;
            vm.RecordRealWeight(selectedOrder);
        }
        private void CommandBinding_CanExecute_RecordRealWeight(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            MarketOrderData selectedOrder = (e.OriginalSource as DataGridRow).DataContext as MarketOrderData;
            e.CanExecute = true;
            //权限处理e.CanExecute = vm.AccountAuthority.CheckManage&&(selectedOrder.OrderType==TRANSACTION_TYPE.Recovery);
        }
        #region --- Event - DoSearch ---
        /// <summary>
        /// 有效定单查询
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="args">event args</param>
        private void InquiryCustomControl_DoSearch(object sender, CustomControl.DoSearchEventArgs args)
        {
            InquiryCustomControl ctor = sender as InquiryCustomControl;

            if (ctor.CanSearch == false)
            {
                return;
            }
            ManagementViewModel mv = DataContext as ManagementViewModel;
            int pageCount = 0;

            DateTime endDate = new DateTime(args.EndDate.AddDays(1).Year, args.EndDate.AddDays(1).Month, args.EndDate.AddDays(1).Day);
            mv.GetMultiTradeOrderWithPage(args.OrdersTypeString, args.OrgName, args.ProductName,args.AccountName,args.StockCode ,args.StartDate,
                endDate, args.PageIndex, args.PageSize, ref pageCount);
            PageCount = pageCount;
        }


        #endregion

        #region --- Dependency property ---
        /// <summary>
        /// Gets or sets page count.
        /// </summary>
        public int PageCount
        {
            get { return (int)GetValue(PageCountProperty); }
            set { SetValue(PageCountProperty, value); }
        }

        public static readonly DependencyProperty PageCountProperty =
            DependencyProperty.Register("PageCount", typeof(int), typeof(MarketOrder), new UIPropertyMetadata(0));
        #endregion

        private void InquiryCustomControl_DoExcel(object sender, CustomControl.DoSearchEventArgs args)
        {
            ManagementViewModel mv = DataContext as ManagementViewModel;
            int pageCount = 0;

            DateTime endDate = new DateTime(args.EndDate.AddDays(1).Year, args.EndDate.AddDays(1).Month, args.EndDate.AddDays(1).Day);
            mv.GetMultiTradeOrderWithPage(args.OrdersTypeString, args.OrgName, args.ProductName, args.AccountName, args.StockCode, args.StartDate, endDate, args.PageIndex, args.PageSize, ref pageCount);
            PageCount = pageCount;
        }

        private void ContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            ContextMenu cMenu = sender as ContextMenu;
            cMenu.DataContext = DataContext;
            if (cMenu.HasItems && cMenu.Items != null)
            {
                foreach (Control item in cMenu.Items)
                {
                    if (item is MenuItem && item.Visibility == Visibility.Visible)
                        return;
                }
            }
            cMenu.Visibility = Visibility.Collapsed;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ManagementViewModel mv = DataContext as ManagementViewModel;
            if (mv != null)
            {
                mv.TradeOrderInfo.TotalLossOrProfit = 0;
                foreach (var item in mv.TradeOrderInfo.TdOrderList)
                {
                    mv.TradeOrderInfo.TotalLossOrProfit += item.LossOrProfit;
                }

            }
        }

        /// <summary>
        /// 历史订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBinding_Executed_HistoryOrder(object sender, ExecutedRoutedEventArgs e)
        {
            MarketOrderData data = (e.OriginalSource as DataGridRow).DataContext as MarketOrderData;
            OrderInfoWindow orderInfo = new OrderInfoWindow(data.TradeAccount);
            orderInfo.DataContext = this.DataContext;
            orderInfo.ShowDialog();
        }

        private void CommandBinding_CanExecute__HistoryOrder(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        
    }
}
