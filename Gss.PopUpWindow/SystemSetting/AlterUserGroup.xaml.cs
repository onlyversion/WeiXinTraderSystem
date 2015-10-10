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
using Gss.Entities.SystemSetting;

namespace Gss.PopUpWindow.SystemSetting
{
    /// <summary>
    /// AlterUserGroup.xaml 的交互逻辑
    /// </summary>
    public partial class AlterUserGroup : Window
    {
        public AlterUserGroup()
        {
            InitializeComponent();
        }

        public event Action<AlterUserGroup> SubmitEvent;
        public AlterUserGroup(UserGroup userG)
        {
            InitializeComponent();
            this.grid_Root.BindingGroup.BeginEdit();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.grid_Root.BindingGroup.CancelEdit();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.grid_Root.BindingGroup.CommitEdit())
            {
                if (this.SubmitEvent != null)
                {
                    SubmitEvent.Invoke(this);
                }
            }
            else
            {
                MessageBox.Show("请填写正确的数据");
            }
        }
    }
}
