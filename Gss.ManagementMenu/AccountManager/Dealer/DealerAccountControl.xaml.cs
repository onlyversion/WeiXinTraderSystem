using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Gss.ViewModel.Management;
using Gss.Entities;
using Gss.ManagementMenu.CustomControl;

namespace Gss.ManagementMenu.AccountManager.Dealer {
    /// <summary>
    /// DealerAccount.xaml 的交互逻辑
    /// </summary>
    public partial class DealerAccountControl : UserControl {
        public DealerAccountControl( ) {
            InitializeComponent( );
            this.Loaded += (e, v) =>
            {
                vm = this.DataContext as ManagementViewModel;
               // vm.GetDealerListExecute();
            };
        }
        private ManagementViewModel vm;
        void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args){
            vm.GetDealerListExecute();
        }

        #region 命令

        private void CommandBinding_Executed_ViewAccount( object sender, ExecutedRoutedEventArgs e ) {

            ClientAccount selectedClient = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            vm.ShowDealerAccountInfo(selectedClient);
        }

        private void CommandBinding_Executed_Authority( object sender, ExecutedRoutedEventArgs e ) {

        }

        private void CommandBinding_Executed_Delete( object sender, ExecutedRoutedEventArgs e ) {
            ClientAccount selectedDealer = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            vm.DeleteDealerAccount(selectedDealer);
        }
        private void CommandBinding_Executed_RolePrivilege(object sender, ExecutedRoutedEventArgs e)
        {
            ClientAccount selectedClient = (e.OriginalSource as DataGridRow).DataContext as ClientAccount;
            vm.ConfigRolePrivilege(selectedClient);
        }

        private void CommandBinding_CanExecute_RolePrivilege(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        #endregion

        #region 事件

        private void UserControl_Loaded( object sender, RoutedEventArgs e ) {
            ManagementViewModel vm = DataContext as ManagementViewModel;

            if( vm.DealerAccountList == null )
                vm.GetDealerListExecute( );
        }


        #endregion

        private void CommandBinding_Executed_BindingOrg(object sender, ExecutedRoutedEventArgs e)
        {

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
                vm.CanGetDealerListExecute = false;
                MessageBox.Show("请选择正确的会员名称！");
            }
            else
            {
                vm.CanGetDealerListExecute = true;
            }
        }

        

       
    }
}
