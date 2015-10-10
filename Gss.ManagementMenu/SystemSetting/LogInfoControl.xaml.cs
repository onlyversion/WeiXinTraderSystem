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
using Gss.Entities.JTWEntityes;
using Gss.ViewModel.Management;
using Gss.Entities;

namespace Gss.ManagementMenu.SystemSetting {
    /// <summary>
    /// LogInfoControl.xaml 的交互逻辑
    /// </summary>
    public partial class LogInfoControl : UserControl {
        public LogInfoControl( ) {
            InitializeComponent( );
        }
        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            Query();
        }

        private void dataPager_PageChanged(object sender, CustomControl.PageChangedEventArgs args)
        {
            Query();
        }
        private void Query()
        {
            ManagementViewModel mv = DataContext as ManagementViewModel;
            int pageCount = 0;
            List<LogInformation> accounts = mv.GetTradeALogInfoWithPage(dataPager.PageIndex, dataPager.PageSize,ref pageCount, (int)mv.LogRequestInfo.LogType,mv.LogRequestInfo.StartTime,mv.LogRequestInfo.EndTime,this.TxbAccount.Text.Trim());
            dataPager.PageCount = pageCount;
            //dgGrid.DataContext = accounts;
        }
    }
}
