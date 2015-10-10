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
    /// PendingOrderHistory.xaml 的交互逻辑
    /// </summary>
    public partial class PendingOrderHistory : UserControl
    {
        public PendingOrderHistory()
        {
            InitializeComponent();
        }
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
            DependencyProperty.Register("PageCount", typeof(int), typeof(PendingOrderHistory), new UIPropertyMetadata(0));

        public string AccountName
        {
            get { return (string)GetValue(AccountNameProperty); }
            set { SetValue(AccountNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AccountName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccountNameProperty =
            DependencyProperty.Register("AccountName", typeof(string), typeof(PendingOrderHistory));



        public string LoginID
        {
            get { return (string)GetValue(LoginIDProperty); }
            set { SetValue(LoginIDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoginID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoginIDProperty =
            DependencyProperty.Register("LoginID", typeof(string), typeof(PendingOrderHistory));


        #endregion

        /// <summary>
        /// 有效订单查询
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
            //Todo:此处应调试恢复
            //DgResult.ItemsSource = mv.GetPendingHistoryDataList(searchInfo, LoginID, ref pageCount);
            //PageCount = pageCount;
        }


    }
}
