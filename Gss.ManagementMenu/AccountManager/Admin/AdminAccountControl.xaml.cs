using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Gss.Entities;
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu.AccountManager {
    /// <summary>
    /// AdminAccount.xaml 的交互逻辑
    /// </summary>
    public partial class AdminAccountControl {
        public AdminAccountControl( ) {
            InitializeComponent( );
            this.Loaded += (e, v) =>
                               {
                                   vm = this.DataContext as ManagementViewModel;
                                   //if (vm.ManagerAccountList == null)
                                   //    vm.GetManagerListExecute();
                               };
        }

        private ManagementViewModel vm;
        void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
         
            vm.GetManagerListExecute();
        }

        #region 命令

        private void CommandBinding_Executed_ViewAccount( object sender, ExecutedRoutedEventArgs e ) {

            ClientAccount selectedClient = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            vm.ShowManagerAccountInfo(selectedClient);
        }

        private void CommandBinding_Executed_Delete( object sender, ExecutedRoutedEventArgs e ) {

            ClientAccount selectedMgr = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            vm.DeleteManagerAccount(selectedMgr);
        }

        #endregion

        #region 事件

        private void DataGridRow_MouseDoubleClick( object sender, MouseEventArgs e ) {

            ClientAccount selectedAdmin = (e.Source as DataGridRow).DataContext as ClientAccount;
            vm.ShowManagerAccountInfo(selectedAdmin);
        }

       
        #endregion

        private void CommandBinding_Executed_RolePrivilege(object sender, ExecutedRoutedEventArgs e)
        {
            ClientAccount selectedClient = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            vm.ConfigRolePrivilege(selectedClient);
        }

        private void CommandBinding_CanExecute_RolePrivilege(object sender, CanExecuteRoutedEventArgs e)
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
    }
}
