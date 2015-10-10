using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu
{
    /// <summary>
    /// TradeMoneyInfo.xaml 的交互逻辑
    /// </summary>
    public partial class TradeMoneyInfo : UserControl
    {
        public TradeMoneyInfo()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(TradeMoneyInfo_Loaded);
            
        }
        private DispatcherTimer timer;
        private const int DelaySyncTime = 10;//second
        private ManagementViewModel vm;
        void TradeMoneyInfo_Loaded(object sender, RoutedEventArgs e)
        {
            vm = this.DataContext as ManagementViewModel;
            if (timer == null || timer.IsEnabled == false)
            {
                GetTradeMoneyInfo(false);

                timer = new DispatcherTimer(
                  TimeSpan.FromSeconds(DelaySyncTime),
                  DispatcherPriority.Normal,
                  (obj, arg) => SyncTradeMoneyList(),
                  Dispatcher);
                timer.Start();
            }
        }
        /// <summary>
        /// 判断是否在UI线程的对象
        /// </summary>
        private DispatcherObject _dpObj;
        /// <summary>
        /// Sync  background.
        /// 同步
        /// </summary>
        private void SyncTradeMoneyList()
        {
            if (this.dataGrid.Dispatcher.CheckAccess())
            {
                GetTradeMoneyInfo(true);
            }
            else
            {
                this.dataGrid.Dispatcher.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate
                {
                    GetTradeMoneyInfo(true);
                });
            }
        }

        private void GetTradeMoneyInfo(bool warning)
        {
          
            int oldCount = dataGrid.Items.Count;
            dataGrid.ItemsSource = vm.GetTradeMoneyInfo();
            int newCount = dataGrid.Items.Count;
            if (warning && oldCount != newCount)
            {
                vm.Warning();
            }
        }
    }
}
