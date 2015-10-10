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
using Gss.Entities.JTWEntityes;
using Gss.ManagementMenu.CustomControl;

namespace Gss.ManagementMenu.AccountManager {
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class ClientAccountControl {
        #region 属性
        private ManagementViewModel vm;
        private ManagementViewModel _mgrViewMode;

        /// <summary>
        /// 获取后台管理VM
        /// </summary>
        public ManagementViewModel MgrViewMode {
            get {
                if( _mgrViewMode == null )
                    _mgrViewMode = DataContext as ManagementViewModel;

                return _mgrViewMode;
            }
        }

        #endregion

        #region 构造函数

        public ClientAccountControl( ) {
            InitializeComponent( );
            this.Loaded += (e, v) =>
            {
                 vm = this.DataContext as ManagementViewModel;
                 
               
            };
        }
        
        #endregion

        #region 命令
        private void CommandBinding_CanExecute_AccountInfo( object sender, CanExecuteRoutedEventArgs e ) {
            e.CanExecute = true;
            //权限处理
            //e.CanExecute = MgrViewMode.AccountAuthority.AllowViewClientInformation;
        }

        private void CommandBinding_CanExecute_AdjustMoney( object sender, CanExecuteRoutedEventArgs e ) {
            e.CanExecute = true;
            //权限处理 e.CanExecute = MgrViewMode.AccountAuthority.AllowAdjustmentAmount;
        }

        private void CommandBinding_CanExecute_CashIO( object sender, CanExecuteRoutedEventArgs e ) {
            e.CanExecute = true;
            //权限处理 e.CanExecute = MgrViewMode.AccountAuthority.AllowCashIO;
        }

        private void CommandBinding_CanExecute_Delete( object sender, CanExecuteRoutedEventArgs e ) {
            e.CanExecute = true;
            //权限处理e.CanExecute = MgrViewMode.AccountAuthority.AllowDeleteClient;
        }

        private void CommandBinding_CanExecute_FundsInfo( object sender, CanExecuteRoutedEventArgs e ) {
            e.CanExecute = true;
            //权限处理e.CanExecute = MgrViewMode.AccountAuthority.AllowViewClientInformation;
        }

        private void CommandBinding_CanExecute_MarketOrder( object sender, CanExecuteRoutedEventArgs e ) {
            e.CanExecute = true;
            //权限处理e.CanExecute = MgrViewMode.AccountAuthority.AllowMarketOrder;
        }

        private void CommandBinding_CanExecute_PendingOrder( object sender, CanExecuteRoutedEventArgs e ) {
            e.CanExecute = true;
            //权限处理e.CanExecute = MgrViewMode.AccountAuthority.AllowPendingOrder;
        }

        private void CommandBinding_Executed_AccountInfo( object sender, ExecutedRoutedEventArgs e ) {
            ClientAccount selectedClient = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            MgrViewMode.ShowAccountInfo2( selectedClient );
        }

        private void CommandBinding_Executed_AdjustMoney( object sender, ExecutedRoutedEventArgs e ) {
            ClientAccount selectedClient = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            MgrViewMode.AdjustMoneyOfClient( selectedClient );
        }

        private void CommandBinding_Executed_CashIO( object sender, ExecutedRoutedEventArgs e ) {
            ClientAccount selectedClient = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            MgrViewMode.CashIO( selectedClient );
        }

        private void CommandBinding_Executed_Delete( object sender, ExecutedRoutedEventArgs e ) {
            ClientAccount selectedClient = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            MgrViewMode.DeleteClientAccount( selectedClient );
        }

        private void CommandBinding_Executed_FundsInfo( object sender, ExecutedRoutedEventArgs e ) {
            ClientAccount selectedClient = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            MgrViewMode.ShowClientFundsInfo( selectedClient );
        }

        private void CommandBinding_Executed_MarketOrder( object sender, ExecutedRoutedEventArgs e ) {
            ClientAccount selectedClient = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            MgrViewMode.MarketOrder( selectedClient );
        }

        private void CommandBinding_Executed_PendingOrder( object sender, ExecutedRoutedEventArgs e ) {
            ClientAccount selectedClient = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            MgrViewMode.PendingOrder( selectedClient );
        }

        #endregion

        #region 事件

        private void DataGridRow_MouseDoubleClick( object sender, MouseEventArgs e ) {
            ClientAccount selectedAdmin = ( e.Source as DataGridRow ).DataContext as ClientAccount;
            MgrViewMode.ShowAccountInfo( selectedAdmin );
        }

        #endregion

        void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            vm.GetUserBaseInfoWithPage();
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
            ClientAccount selectedClient = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            OrderInfoWindow orderInfo = new OrderInfoWindow(selectedClient.AccInfo.AccountName);
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
                MgrViewMode.CanGetUserBaseInfoWithPage = false;
                MessageBox.Show("请选择正确的会员名称！");
            }
            else
            {
                MgrViewMode.CanGetUserBaseInfoWithPage = true;
            }
        }

        private void Button_Excel_Click(object sender, RoutedEventArgs e)
        {
            MgrViewMode.ExportUserExcel();
        }
       
    }
}
