using System.Windows;
using System.Windows.Controls;
using Gss.Entities;
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu.TakeGoodsManager
{
    /// <summary>
    /// 提货
    /// TakeGoodsCountrol.xaml 的交互逻辑
    /// </summary>
    public partial class TakeGoodsCountrol : UserControl
    {
        public TakeGoodsCountrol()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 是否已执行过查询,并执行成功
        /// </summary>
        private bool isExcuteQueryed=false;
        private void CommandBinding_Executed_DoQuery(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            ErrType err= vm.GetOrderNOInfo(txtOdrerCode.Text.Trim());
            if (err.Err == ERR.SUCCESS)
                isExcuteQueryed = true;
        }

        private void CommandBinding_CanExecute_DoQuery(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(txtOdrerCode.Text))
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void CommandBinding_CanExecute_SubjectGoods(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            decimal au = 0;
            decimal ag = 0;
            decimal pt = 0;
            decimal pd = 0;

            foreach (object child in LogicalTreeHelper.GetChildren(grid))
            {
                TextBox element = child as TextBox;
                if (element != null)
                {
                    if (Validation.GetHasError(element))
                    {
                        e.CanExecute = false;
                        return;
                    }
                }
            }
            if (!isExcuteQueryed)
                e.CanExecute = false;
            else if (string.IsNullOrEmpty(txtAu.Text) && string.IsNullOrEmpty(txtAg.Text) && string.IsNullOrEmpty(txtPt.Text) && string.IsNullOrEmpty(txtPd.Text))
                e.CanExecute = false;
            else if (!string.IsNullOrEmpty(txtAu.Text) && !decimal.TryParse(txtAu.Text.Trim(), out au))
                e.CanExecute = false;
            else if (!string.IsNullOrEmpty(txtAg.Text) && !decimal.TryParse(txtAg.Text.Trim(), out ag))
                e.CanExecute = false;
            else if (!string.IsNullOrEmpty(txtPt.Text) && !decimal.TryParse(txtPt.Text.Trim(), out pt))
                e.CanExecute = false;
            else if (!string.IsNullOrEmpty(txtPd.Text) && !decimal.TryParse(txtPd.Text.Trim(), out pd))
                e.CanExecute = false;
            else if (au < 0 || ag < 0 || pt < 0 || pd < 0)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }

        private void CommandBinding_Executed_SubjectGoods(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            decimal au = 0;
            decimal ag = 0;
            decimal pt = 0;
            decimal pd = 0;
            decimal.TryParse(txtAu.Text.Trim(), out au);
            decimal.TryParse(txtAg.Text.Trim(), out ag);
            decimal.TryParse(txtPt.Text.Trim(), out pt);
            decimal.TryParse(txtPd.Text.Trim(), out pd);
            ManagementViewModel vm = this.DataContext as ManagementViewModel;
            bool rs = vm.SubjectTakeGoodsOrder(au, ag, pt, pd, txtOdrerCode.Text.Trim());
            if (rs)
                vm.GetOrderNOInfo(txtOdrerCode.Text.Trim());
        }



    }
}
