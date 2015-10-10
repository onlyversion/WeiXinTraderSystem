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
    /// 买跌单
    /// BackGoodsReport.xaml 的交互逻辑
    /// </summary>
    public partial class BackGoodsReport : UserControl
    {
        public BackGoodsReport()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed_UpdateBackGoods(object sender, ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            BzjOrderEntity selectedOrder = (e.OriginalSource as DataGridRow).DataContext as BzjOrderEntity;
            vm.UpdateBuyBackOrder(selectedOrder);
        }

        void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            vm.GetBackGoodsExecute();
        }

        private void CommandBinding_CanExecute_UpdateBackGoods(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ContextMenu menu = this.FindResource("menu") as ContextMenu;
            MenuItem chMenu = menu.Items[0] as MenuItem;
            BzjOrderEntity selEntity = dataGrid.SelectedItem as BzjOrderEntity;
            if (selEntity != null && selEntity.State == 1)
            {
                chMenu.IsEnabled = true;
            }
            else
                chMenu.IsEnabled = false;
        }
    }
}
