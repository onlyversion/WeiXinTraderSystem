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
using Gss.Entities.BzjEntities;
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu.TradeManager
{
    /// <summary>
    /// DeliveryGoodsBackTabItem.xaml 的交互逻辑
    /// </summary>
    public partial class DeliveryGoodsBackTabItem : UserControl
    {
        public DeliveryGoodsBackTabItem()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed_ModifyState(object sender, ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            BzjRecoverOrder selectedOrder = (e.OriginalSource as DataGridRow).DataContext as BzjRecoverOrder;
            vm.ModifyTradeCheck(selectedOrder);
        }

        private void CommandBinding_CanExecute_ModifyState(object sender, CanExecuteRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            e.CanExecute = true;
            //权限处理e.CanExecute = vm.AccountAuthority.CheckDel;
        }
        void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            vm.GetDeliveryBackGoodsExecute();
        }
    }
}
