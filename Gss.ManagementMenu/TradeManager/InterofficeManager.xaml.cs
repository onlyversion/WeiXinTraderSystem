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
using System.Timers;
using Gss.ViewModel.Management;
using Gss.ManagementMenu.CustomControl;

namespace Gss.ManagementMenu.TradeManager
{
    /// <summary>
    /// InterofficeManager.xaml 的交互逻辑
    /// 会员报表
    /// </summary>
    public partial class InterofficeManager : UserControl
    {
        ManagementViewModel vm;
        private Timer _interval;
        public InterofficeManager()
        {
            InitializeComponent();

            this._interval = new Timer(300000);//5分钟刷新一次数据
            this._interval.AutoReset = true;
            this._interval.Elapsed += new ElapsedEventHandler(_interval_Elapsed);
        }



        void _interval_Elapsed(object sender, ElapsedEventArgs e)
        {

            vm.GetJuJianLstEx();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            vm = this.DataContext as ManagementViewModel;
            if (vm != null)
            {
                vm.GetJuJianLstEx();
                vm.CanIterofficeReSetYingKui = true;
            }
        }

        private void ReSetTimer()
        {
            _interval.Stop();
            _interval.Start();
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            _interval.Stop();
            vm.CanIterofficeReSetYingKui = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AutoComboBoxState sf = this.ACB_Search.State;
            if (sf == AutoComboBoxState.AlterState)
            {
                vm.CanGetJuJianLstEx = false;
                MessageBox.Show("请选择正确的会员名称！");
            }
            else
            {
                vm.CanGetJuJianLstEx = true;
            }
        }

    }
}
