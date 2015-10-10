using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Gss.Entities;
using Gss.Entities.BzjEntities;
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu.AccountManager.Clerk
{
    /// <summary>
    /// ClerkAccountControl.xaml 的交互逻辑
    /// </summary>
    public partial class ClerkAccountControl : UserControl
    {
        #region 属性

        private ManagementViewModel _mgrViewMode;

        /// <summary>
        /// 获取后台管理VM
        /// </summary>
        public ManagementViewModel MgrViewMode
        {
            get
            {
                if (_mgrViewMode == null)
                    _mgrViewMode = DataContext as ManagementViewModel;

                return _mgrViewMode;
            }
        }

        #endregion
        public ClerkAccountControl()
        {
            InitializeComponent();
        }
        private void DataGridRow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            BzjClerk selectedAdmin = (e.Source as DataGridRow).DataContext as BzjClerk;
            MgrViewMode.ShowClerkAccountInfoExecute();
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
    }
}
