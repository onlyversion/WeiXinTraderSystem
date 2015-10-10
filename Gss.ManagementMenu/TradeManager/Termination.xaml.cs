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
using Gss.Entities.TradeManager;
using Gss.ManagementMenu.CustomControl;

namespace Gss.ManagementMenu.TradeManager
{
    /// <summary>
    /// Termination.xaml 的交互逻辑
    /// 解约处理
    /// </summary>
    public partial class Termination : UserControl
    {
        ManagementViewModel vm;
        public Termination()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Termination_Loaded);
        }

        void Termination_Loaded(object sender, RoutedEventArgs e)
        {
            vm = this.DataContext as ManagementViewModel;
        }
        void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
            vm = this.DataContext as ManagementViewModel;
            vm.GetTerminationLstExcuted();
        }
     


        /// <summary>
        /// 审核
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBinding_Executed_Check(object sender, ExecutedRoutedEventArgs e)
        {
            vm.ProcessJieYue();
        }
        /// <summary>
        /// 拒绝
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBinding_Executed_Refused(object sender, ExecutedRoutedEventArgs e)
        {
            vm.RefusedJieYue();
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //DataGrid dg = sender as DataGrid;
            TradeJieYue t =dataGrid.SelectedItem as TradeJieYue;
            if (t != null)
            {
                DataGridRow dr = (DataGridRow)(dataGrid.ItemContainerGenerator.ContainerFromItem(t));
                if (dr== null)
                {
                    return;
                }
                if (vm.CurJieYue.State == "0")
                {
                    dr.ContextMenu.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    //dr.ContextMenu.Visibility = System.Windows.Visibility.Hidden;
                    dr.ContextMenu = null;
                }

            }
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

        /// <summary>
        /// 历史订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBinding_Executed_HistoryOrder(object sender, ExecutedRoutedEventArgs e)
        {
            TradeJieYue data = (e.OriginalSource as DataGridRow).DataContext as TradeJieYue;
            OrderInfoWindow orderInfo = new OrderInfoWindow(data.Account);
            orderInfo.DataContext = this.DataContext;
            orderInfo.ShowDialog();
        }

        private void CommandBinding_CanExecute__HistoryOrder(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AutoComboBoxState sf = this.ACB_Search.State;
            if (sf == AutoComboBoxState.AlterState)
            {
                vm.CanGetTerminationLstExcuted = false;
                MessageBox.Show("请选择正确的会员名称！");
            }
            else
            {
                vm.CanGetTerminationLstExcuted = true;
            }
        }
    }
}
