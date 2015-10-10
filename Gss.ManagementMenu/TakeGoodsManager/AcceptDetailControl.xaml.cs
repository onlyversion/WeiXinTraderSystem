using System.Windows.Controls;
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu.TakeGoodsManager
{
    /// <summary>
    /// 受理明细
    /// AcceptDetailControl.xaml 的交互逻辑
    /// </summary>
    public partial class AcceptDetailControl : UserControl
    {
        public AcceptDetailControl()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed_DoQuery(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {

        }

        private void CommandBinding_CanExecute_DoQuery(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        void dataPage_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            vm.GetTakeGoodsDetialBzjReportExecute();
        }
    }
}
