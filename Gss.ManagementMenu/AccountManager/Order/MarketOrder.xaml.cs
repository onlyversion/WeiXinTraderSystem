using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Gss.Entities;
using Gss.Entities.TradeManager;
using Gss.ViewModel.Management;
using System.Linq;

namespace Gss.ManagementMenu.AccountManager.Order
{
    /// <summary>
    /// MarketOrder.xaml 的交互逻辑
    /// </summary>
    public partial class MarketOrder : UserControl
    {
        public MarketOrder()
        {
            InitializeComponent();
        }
        #region --- Dependency property ---
  
        /// <summary>
        /// 用户交易账号
        /// </summary>
        public string AccountName
        {
            get { return (string)GetValue(AccountNameProperty); }
            set { SetValue(AccountNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AccountName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccountNameProperty =
            DependencyProperty.Register("AccountName", typeof(string), typeof(MarketOrder));

        public static readonly DependencyProperty FundInformationProperty =
           DependencyProperty.Register("FundInformation", typeof(FundInformation), typeof(MarketOrder));

        /// <summary>
        /// 用户资金信息
        /// </summary>
        public FundInformation FundInformation
        {
            get { return (FundInformation)GetValue(FundInformationProperty); }
            set { SetValue(FundInformationProperty, value); }
        }
        #endregion
  
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ManagementViewModel mv = DataContext as ManagementViewModel;
            DgResult.ItemsSource = mv.GetMarketOrderList(AccountName);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<MarketOrderData> list = DgResult.ItemsSource as List<MarketOrderData>;
            this.FundInformation.LossOrProfit = list.Sum(item => item.LossOrProfit);
        }
    }
}
