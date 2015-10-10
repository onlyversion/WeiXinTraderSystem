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
using Gss.ViewModel.Management;
using Gss.Entities;

namespace Gss.ManagementMenu.AccountManager.Order
{
    /// <summary>
    /// WarehousingHistory.xaml 的交互逻辑
    /// </summary>
    public partial class WarehousingHistory : UserControl
    {
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
            DependencyProperty.Register("PageCount", typeof(int), typeof(WarehousingHistory), new UIPropertyMetadata(0));

        public string AccountName
        {
            get { return (string)GetValue(AccountNameProperty); }
            set { SetValue(AccountNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AccountName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccountNameProperty =
            DependencyProperty.Register("AccountName", typeof(string), typeof(WarehousingHistory));
        #endregion
        public WarehousingHistory()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 入库单查询
        /// </summary>
        /// <param name="sender">event sender</param>
        /// <param name="args">event args</param>
        private void InquiryCustomControl_DoSearch(object sender, CustomControl.DoSearchEventArgs args)
        {
            ManagementViewModel mv = DataContext as ManagementViewModel;
            DateTime endDate = new DateTime(args.EndDate.AddDays(1).Year, args.EndDate.AddDays(1).Month, args.EndDate.AddDays(1).Day);
            HistorySearchInfo searchInfo = new HistorySearchInfo
            {
                ProductName = args.ProductName,
                StartDateTime = args.StartDate,
                EndDateTime = endDate,
                OrdersType = args.OrdersTypeString,
                PageIndex = args.PageIndex,
                PageSize = args.PageSize,
                TradeAccount = AccountName,
            };
            int pageCount = 0;
            
            var historyList = mv.GetWarehousingHistoryList(searchInfo, ref pageCount);
            PageCount = pageCount;
           // DgResult.DataContext = historyList;
            DgResult.ItemsSource = historyList;
        }
    }
}
