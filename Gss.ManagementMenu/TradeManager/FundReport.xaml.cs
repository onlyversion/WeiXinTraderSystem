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
using Gss.Entities.TradeManager;
using Gss.ManagementMenu.AccountManager.Order;
using Gss.ViewModel.Management;
using Gss.ManagementMenu.CustomControl;

namespace Gss.ManagementMenu.TradeManager
{
    /// <summary>
    /// FundReport.xaml 的交互逻辑
    /// 资金明细
    /// </summary>
    public partial class FundReport : UserControl
    {
        ManagementViewModel vm;
        public FundReport()
        {
            InitializeComponent();
            this.Loaded += (e, v) =>
            {
                vm = this.DataContext as ManagementViewModel;
            };
        }

        private void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
           
            vm.GetFundReportExecuted();
        }

        /// <summary>
        /// 历史订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBinding_Executed_HistoryOrder(object sender, ExecutedRoutedEventArgs e)
        {
            FundChangeInformation data = (e.OriginalSource as DataGridRow).DataContext as FundChangeInformation;
            OrderInfoWindow orderInfo = new OrderInfoWindow(data.Account);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AutoComboBoxState sf = this.ACB_Search.State;
            if (sf == AutoComboBoxState.AlterState)
            {
                vm.CanGetFundReportExecuted = false;
                MessageBox.Show("请选择正确的会员名称！");
            }
            else
            {
                vm.CanGetFundReportExecuted = true;
            }

        }
    }
}
