using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Gss.Entities;
using Gss.ManagementMenu.AccountManager.Order;
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu.TradeManager {
    /// <summary>
    /// ChargebackRecodexaml.xaml 的交互逻辑
    /// 平仓历史
    /// </summary>
    public partial class ChargebackRecode {
        #region --- Constructor ---
        /// <summary>
        /// Constructor
        /// </summary>
        public ChargebackRecode( ) {
            InitializeComponent( );
        }
        #endregion

        #region --- Dependency property ---
        /// <summary>
        /// Gets or sets page count.
        /// </summary>
        public int PageCount {
            get { return ( int )GetValue( PageCountProperty ); }
            set { SetValue( PageCountProperty, value ); }
        }
        public static readonly DependencyProperty PageCountProperty =
            DependencyProperty.Register( "PageCount", typeof( int ), typeof( ChargebackRecode ), new UIPropertyMetadata( 0 ) );
        #endregion

        #region --- Event - DoSearch ---
        /// <summary>
        ///平仓查询
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="args">event args</param>
        private void InquiryCustomControl_DoSearch( object sender, CustomControl.DoSearchEventArgs args ) {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            //DateTime endDate = new DateTime(args.EndDate.AddDays(1).Year, args.EndDate.AddDays(1).Month, args.EndDate.AddDays(1).Day);
            //HistorySearchInfo searchInfo = new HistorySearchInfo {
            //    ProductName = args.ProductName,
            //    StartDateTime = args.StartDate,
            //    EndDateTime = endDate,
            //    OrdersType = args.OrdersTypeString,
            //    PageIndex = args.PageIndex,
            //    PageSize = args.PageSize,
            //    TradeAccount=args.AccountName,
            //    OrgName = args.OrgName,
            //};

            int pageCount = 0;
            vm.GetMultiLTradeOrderWithPage(args.OrdersTypeString, args.OrgName, args.ProductName, args.AccountName, args.StockCode, args.StartDate, args.EndDate, args.PageIndex, args.PageSize, ref pageCount);
            PageCount = pageCount;
           // DgResult.DataContext = historyList;
        }
        #endregion

        /// <summary>
        /// 历史订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBinding_Executed_HistoryOrder(object sender, ExecutedRoutedEventArgs e)
        {
            MarketHistoryData data = (e.OriginalSource as DataGridRow).DataContext as MarketHistoryData;
            OrderInfoWindow orderInfo = new OrderInfoWindow(data.TradeAccount);
            orderInfo.DataContext = this.DataContext;
            orderInfo.ShowDialog();
        }

        private void CommandBinding_CanExecute__HistoryOrder(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
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
    }
}
