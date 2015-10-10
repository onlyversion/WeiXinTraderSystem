using System;
using System.Windows;

namespace Gss.PopUpWindow.AuthWindows
{
    /// <summary>
    /// RolePrivilegesConfigWindow.xaml 的交互逻辑
    /// </summary>
    public partial class RolePrivilegesConfigWindow : Window
    {
        public RolePrivilegesConfigWindow()
        {
            InitializeComponent();
        }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        public event EventHandler DataGridSelectionChangedEvent;
        private void DataGridSelectionChanged()
        {
            if (DataGridSelectionChangedEvent != null)
                DataGridSelectionChangedEvent(new object(), new EventArgs());
        }
        private void dataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DataGridSelectionChanged();
        }
    }
}
