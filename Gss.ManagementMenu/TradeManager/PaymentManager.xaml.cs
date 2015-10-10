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
    /// PaymentManager.xaml 的交互逻辑
    /// 出金处理
    /// </summary>
    public partial class PaymentManager : UserControl
    {
        ManagementViewModel vm;
        public PaymentManager()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(PaymentManager_Loaded);
        }

        void PaymentManager_Loaded(object sender, RoutedEventArgs e)
        {
            vm = this.DataContext as ManagementViewModel;
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
            DependencyProperty.Register("PageCount", typeof(int), typeof(PaymentManager), new UIPropertyMetadata(0));
        #endregion

      

        void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
            vm = this.DataContext as ManagementViewModel;
            vm.GetChuJinExecuted();
        }
        ///// <summary>
        ///// 付款
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void CommandBinding_Executed_Payment(object sender, ExecutedRoutedEventArgs e)
        //{
        //    vm.ChuJinExecuted();
        //}

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
        ///// <summary>
        ///// 拒绝
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void CommandBinding_Executed_Refused(object sender, ExecutedRoutedEventArgs e)
        //{
        //    vm.RefusedChuJinExecuted();
        //}

        //private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    DataGrid dg = sender as DataGrid;
        //    TradeChuJinInformation t = dg.SelectedItem as TradeChuJinInformation;
        //    if (t != null) 
        //    { 
        //        DataGridRow dr = (DataGridRow)(dg.ItemContainerGenerator.ContainerFromItem(t));
        //        if (dr == null)
        //        {
        //            return;
        //        }
        //        if (vm.CurChuJin.State == "0")
        //        {
        //            dr.ContextMenu.Visibility = System.Windows.Visibility.Visible;
        //        }
        //        else
        //        {
        //            //dr.ContextMenu.Visibility = System.Windows.Visibility.Hidden;
        //            dr.ContextMenu = null;
        //        }
                
        //    }
        //}

        /// <summary>
        /// 历史订单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBinding_Executed_HistoryOrder(object sender, ExecutedRoutedEventArgs e)
        {
            TradeChuJinInformation data = this.dataGrid.SelectedItem as TradeChuJinInformation;
            OrderInfoWindow orderInfo = new OrderInfoWindow(data.Account);
            orderInfo.DataContext = this.DataContext;
            orderInfo.ShowDialog();
        }
        /// <summary>
        /// 历史订单是否可执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBinding_CanExecute__HistoryOrder(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AutoComboBoxState sf = this.ACB_Search.State;
            if (sf == AutoComboBoxState.AlterState)
            {
                vm.CanGetChuJinExecuted = false;
                MessageBox.Show("请选择正确的会员名称！");
            }
            else
            {
                vm.CanGetChuJinExecuted = true;
            }
        }

        /// <summary>
        /// 出金详情命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBinding_PaymentDetailsCmd(object sender, ExecutedRoutedEventArgs e)
        {
            vm.ShowPaymentDetails();
        }
    }
}
