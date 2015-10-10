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

namespace Gss.ManagementMenu.AccountManager {
    /// <summary>
    /// ClientOnline.xaml 的交互逻辑
    /// </summary>
    public partial class ClientOnlineControl {
        #region 属性

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

        public ClientOnlineControl( ) {
            InitializeComponent( );
            //this.Loaded += (e, v) =>
            //{
            //    ManagementViewModel vm = this.DataContext as ManagementViewModel;
            //    vm.GetOnlineClientsExecute();
            //};
        }
        
        #endregion
        void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            vm.GetOnlineClientsExecute();
        }

        #region 事件

        private void DataGridRow_MouseDoubleClick( object sender, MouseEventArgs e ) {
            ClientAccount selectedClient = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            MgrViewMode.ShowAccountInfo(selectedClient);
        }

        #endregion

        #region 命令

        private void CommandBinding_CanExecute_AccountInfo( object sender, CanExecuteRoutedEventArgs e )
        {
            e.CanExecute = true;
            //权限处理
            //e.CanExecute = MgrViewMode.AccountAuthority.AllowViewClientInformation;
        }

        private void CommandBinding_CanExecute_Delete( object sender, CanExecuteRoutedEventArgs e ) {
            e.CanExecute = true;
            //权限处理
            // e.CanExecute = MgrViewMode.AccountAuthority.AllowDeleteClient;
        }

        private void CommandBinding_CanExecute_FundsInfo( object sender, CanExecuteRoutedEventArgs e ) {
            e.CanExecute = true;
            //权限处理
            //e.CanExecute = MgrViewMode.AccountAuthority.AllowViewClientInformation;
        }

        private void CommandBinding_Executed_AccountInfo( object sender, ExecutedRoutedEventArgs e ) {
            ClientAccount selectedClient = ( e.OriginalSource as DataGridRow ).DataContext as ClientAccount;
            MgrViewMode.ShowAccountInfo( selectedClient );
        }

        private void CommandBinding_Executed_Delete( object sender, ExecutedRoutedEventArgs e ) {
            ClientAccount selectedClient = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            MgrViewMode.DeleteClientAccount(selectedClient);
        }

        private void CommandBinding_Executed_FundsInfo( object sender, ExecutedRoutedEventArgs e ) {
            ClientAccount selectedClient = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            MgrViewMode.ShowClientFundsInfo( selectedClient );
        }
     
        #endregion

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
            ClientAccount data = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            OrderInfoWindow orderInfo = new OrderInfoWindow(data.AccInfo.AccountName);
            orderInfo.DataContext = this.DataContext;
            orderInfo.ShowDialog();
        }

        private void CommandBinding_CanExecute__HistoryOrder(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
