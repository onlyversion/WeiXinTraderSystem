using System;
using System.Windows.Controls;
using System.Windows.Input;
using Gss.Entities;
using Gss.ManagementMenu.AccountManager.Order;
using Gss.ViewModel.Management;
using System.Windows;
using System.Linq;

namespace Gss.ManagementMenu.TradeManager {
    /// <summary>
    /// PendingOrder.xaml 的交互逻辑
    /// 委托订单\限价订单
    /// </summary>
    public partial class PendingOrder {
        public PendingOrder( ) {
            InitializeComponent( );
        }

        #region 命令

        private void CommandBinding_Executed_Cancel( object sender, System.Windows.Input.ExecutedRoutedEventArgs e ) {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            PendingOrderData selectedOrder = ( e.OriginalSource as DataGridRow ).DataContext as PendingOrderData;
            vm.RevocationPendingOrder( selectedOrder );
        } 

        private void CommandBinding_CanExecute_Cancel( object sender, System.Windows.Input.CanExecuteRoutedEventArgs e ) {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            e.CanExecute = true;
            //权限处理 e.CanExecute = vm.AccountAuthority.AllowRevocationOrder;
        }
        #endregion

        #region --- Event - DoSearch ---
        /// <summary>
        /// 有效定单查询
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="args">event args</param>
        private void InquiryCustomControl_DoSearch(object sender, CustomControl.DoSearchEventArgs args)
        {
            ManagementViewModel mv = DataContext as ManagementViewModel;
            int pageCount = 0;
            DateTime endDate = new DateTime(args.EndDate.AddDays(1).Year, args.EndDate.AddDays(1).Month, args.EndDate.AddDays(1).Day);
            mv.GetMultiTradeHoldOrderWithPage(args.OrdersTypeString, args.OrgName, args.ProductName, args.AccountName,args.StockCode, args.StartDate, endDate, args.PageIndex, args.PageSize, ref pageCount);
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
            DependencyProperty.Register("PageCount", typeof(int), typeof(PendingOrder), new UIPropertyMetadata(0));
        #endregion

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

        /// <summary>
        /// 历史订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBinding_Executed_HistoryOrder(object sender, ExecutedRoutedEventArgs e)
        {
            PendingOrderData data = (e.OriginalSource as DataGridRow).DataContext as PendingOrderData;
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
