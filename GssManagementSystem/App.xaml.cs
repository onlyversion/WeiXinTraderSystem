using System;
using System.Configuration;
using System.Windows;
using Gss.Common.Utility;
using Gss.Entities;
using Gss.ViewModel.Management;

namespace JxSystem
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ManagementViewModel vm = ManagementViewModel.GetInstances;
            LoginWindow loginWnd = new LoginWindow
            {
                DataContext = vm,
            };
            if (loginWnd.ShowDialog() == true)
            {
                //MainWindow mainWnd = new MainWindow
                //{
                //    DataContext = vm,
                //};
                //Application.Current.MainWindow = mainWnd;
                //mainWnd.Closed += (s, eg) =>
                //{
                //    Current.Shutdown();
                //    vm.Dispose();
                //};

                ////登陆后的一些初始化动作
                //vm.Initialize();

                //mainWnd.Show();
            }
            else
            {
                Current.Shutdown();
                vm.Dispose();
            }
        }


        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            string errMsg = string.Format("{0} \r\n{1}", e.Exception.Message, e.Exception.StackTrace);
            //string ShowException = ConfigurationManager.AppSettings["ShowException"];
            if (ConnectConfigData.ShowException)
                MessageBox.Show(errMsg, "未捕获的异常", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                FileLog.WriteLog("未抛出的异常日志:" + errMsg);
            e.Handled = true;
        }
    }
}
