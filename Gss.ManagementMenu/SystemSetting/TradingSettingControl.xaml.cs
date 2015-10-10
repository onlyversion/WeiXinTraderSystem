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
using Gss.Entities.JTWEntityes;
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu.SystemSetting
{
    /// <summary>
    /// TradingSettingControl.xaml 的交互逻辑
    /// </summary>
    public partial class TradingSettingControl : UserControl
    {
        public TradingSettingControl()
        {
            InitializeComponent();
        }

        private ManagementViewModel vm;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            vm = this.DataContext as ManagementViewModel;
            vm.GetTradingSettingInfo();
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

        private void DataGridRow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TradeConfigInfo selInfo = (e.Source as DataGridRow).DataContext as TradeConfigInfo;
            vm.ModifyTradingSettingInfo(selInfo);
        }

        private void CommandBinding_Executed_Add(object sender, ExecutedRoutedEventArgs e)
        {
            vm.AddTradingSettingInfo();
        }

        private void CommandBinding_Executed_Edit(object sender, ExecutedRoutedEventArgs e)
        {
            TradeConfigInfo selInfo = (e.OriginalSource as DataGridRow).DataContext as TradeConfigInfo;
            vm.ModifyTradingSettingInfo(selInfo);
        }

        private void CommandBinding_Executed_Delete(object sender, ExecutedRoutedEventArgs e)
        {
            TradeConfigInfo selInfo = (e.OriginalSource as DataGridRow).DataContext as TradeConfigInfo;
            vm.DelTradingSettingInfo(selInfo);
        }

        private void CommandBinding_Executed_Refresh(object sender, ExecutedRoutedEventArgs e)
        {
            vm.GetTradingSettingInfo();
        }
    }
}
