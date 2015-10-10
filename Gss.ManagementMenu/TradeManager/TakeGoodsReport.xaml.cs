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
    /// 提货单
    /// TakeGoodsReport.xaml 的交互逻辑
    /// </summary>
    public partial class TakeGoodsReport : UserControl
    {
        public TakeGoodsReport()
        {
            InitializeComponent();
        }

        void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            vm.GetTakeGoodsExecute();
        }
    }
}
