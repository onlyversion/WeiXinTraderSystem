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
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu.TradeManager
{
    /// <summary>
    /// HistoryData.xaml 的交互逻辑
    /// 历史数据
    /// </summary>
    public partial class HistoryData : UserControl
    {
       
        private ManagementViewModel vm;
        public HistoryData()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            vm = this.DataContext as ManagementViewModel;
        }

        void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
            vm.GetHisDatasCommandEX();
        }

        private void CommandBinding_Executed_Alter(object sender, ExecutedRoutedEventArgs e)
        {
            vm.AlterHisDatasCommandEX();
        }

       
    }
}
