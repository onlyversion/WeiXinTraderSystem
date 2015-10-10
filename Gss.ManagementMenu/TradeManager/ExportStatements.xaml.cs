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
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu.TradeManager
{
    /// <summary>
    /// ExportStatements.xaml 的交互逻辑
    /// 导出报表
    /// </summary>
    public partial class ExportStatements : UserControl
    {
        public ExportStatements()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 报表类型列表项
        /// </summary>
        public List<string> StatementsTypeItems
        {
            get { return (List<string>)GetValue(StatementsTypeItemsProperty); }
            set { SetValue(StatementsTypeItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StatementsTypeItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatementsTypeItemsProperty =
            DependencyProperty.Register("StatementsTypeItems", typeof(List<string>), typeof(ExportStatements), new UIPropertyMetadata(null));

        /// <summary>
        /// 根据该账户具有的导出报表权限生成导出报表的下拉菜单选项
        /// </summary>
        /// <param name="mgrAuthority">账户权限</param>
        /// <returns></returns>
        private List<string> CreateStatementTypeItems()
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            
            List<string> list = new List<string>();

            if (vm.AccountAuthority.AllowExportMarketOrderReport)
                list.Add("在手订单");
            //if (vm.AccountAuthority.AllowExportPendingOrderReport)
            //    list.Add("委托订单");
            //if (vm.AccountAuthority.WarehousingStatements)
            //    list.Add("入库报表");
            if (vm.AccountAuthority.AllowExportAdjustReport)
                list.Add("平仓历史");
            if (vm.AccountAuthority.AllowExportFundReport)
            {
                list.Add("资金明细");
                //list.Add("账户结余");
            }
            //if (mgrAuthority.OrderTakeReport)
            //    list.Add("买涨交割单报表");
            //if (mgrAuthority.OrderBackReport)
            //    list.Add("买跌单报表");
            //if (mgrAuthority.OrderCheckReport)
            //    list.Add("买跌交割单报表");
            //if (mgrAuthority.JgjReport)
            //    list.Add("转金生金报表");
            //if (mgrAuthority.AgentDoDetail)
            //    list.Add("提货受理报表");

            return list;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
           
            //权限处理
            StatementsTypeItems = CreateStatementTypeItems();
        }

        private void CbStatementsType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            if (cmb != null && cmb.SelectedItem != null)
            {
                panel_1.Visibility = Visibility.Collapsed;
                panel_2.Visibility = Visibility.Collapsed;
                if (cmb.SelectedItem.ToString() == "账户结余")
                    panel_2.Visibility = Visibility.Visible;
                else
                    panel_1.Visibility = Visibility.Visible;

            }
        }


    }
}
