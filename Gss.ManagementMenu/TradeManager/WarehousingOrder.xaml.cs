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
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu.TradeManager {
    /// <summary>
    /// WarehousingOrder.xaml 的交互逻辑
    /// 入库订单
    /// </summary>
    public partial class WarehousingOrder {
        #region  --- Constructor ---
        /// <summary>
        /// Constructor
        /// </summary>
        public WarehousingOrder( ) {
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
            DependencyProperty.Register( "PageCount", typeof( int ), typeof( WarehousingOrder ), new UIPropertyMetadata( 0 ) );
        #endregion

        #region --- Event - DoSearch ---
        /// <summary>
        /// 入库单查询
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="args">event args</param>
        private void InquiryCustomControl_DoSearch( object sender, CustomControl.DoSearchEventArgs args ) {
            ManagementViewModel mv = DataContext as ManagementViewModel;
            DateTime endDate = new DateTime(args.EndDate.AddDays(1).Year, args.EndDate.AddDays(1).Month, args.EndDate.AddDays(1).Day);
            HistorySearchInfo searchInfo = new HistorySearchInfo {
                ProductName = args.ProductName,
                StartDateTime = args.StartDate,
                EndDateTime = endDate,
                OrdersType = args.OrdersTypeString,
                PageIndex = args.PageIndex,
                PageSize = args.PageSize,
               TradeAccount=args.AccountName,
             
            };
            int pageCount = 0;
            var historyList = mv.GetWarehousingHistoryList( searchInfo, ref pageCount );
            PageCount = pageCount;
            DgResult.DataContext = historyList;
        }
        #endregion
    }
}
