using System.Windows;
using Gss.Entities;
using Gss.Entities.TradeManager;
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu.AccountManager.Order
{
    /// <summary>
    /// OrderInfoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OrderInfoWindow : Window
    {
        public OrderInfoWindow()
        {
            InitializeComponent();
            
        }
        public OrderInfoWindow(string AccountName)
        {
            this. AccountName = AccountName;
            InitializeComponent();             
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ManagementViewModel mv = DataContext as ManagementViewModel;
            this.FundInformation = mv.GetAccMoneyInventory(this.AccountName);
        }

        public static readonly DependencyProperty AccountNameProperty =
    DependencyProperty.Register("AccountName", typeof(string), typeof(OrderInfoWindow));  
        /// <summary>
        /// 用户账号
        /// </summary>
        public string AccountName
        {
            get { return (string)GetValue(AccountNameProperty); }
            set { SetValue(AccountNameProperty, value); }
        }

 

        public static readonly DependencyProperty FundInformationProperty =
            DependencyProperty.Register("FundInformation", typeof(FundInformation), typeof(OrderInfoWindow));   

        /// <summary>
        /// 用户资金信息
        /// </summary>
        public FundInformation FundInformation
        {
            get { return (FundInformation)GetValue(FundInformationProperty); }
            set { SetValue(FundInformationProperty, value); }
        }

        
    }
}
