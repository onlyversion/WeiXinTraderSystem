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
using System.Windows.Shapes;

namespace Gss.PopUpWindow.AccountManager
{
    /// <summary>
    /// 功能：BindingOrgWindow.xaml 的交互逻辑 绑定会员账户功能简化，暂时保留此页面
    /// 
    /// </summary>
    public partial class BindingOrgWindow : Window
    {
        public BindingOrgWindow()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void CommandBinding_Executed_CancelBindingOrg(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandBinding_Executed_BindingOrg(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
