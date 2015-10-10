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
using Gss.Common.Utility;

namespace Gss.PopUpWindow.SystemSetting
{
    /// <summary>
    /// AddUserGroup.xaml 的交互逻辑
    /// </summary>
    public partial class AddUserGroup : Window
    {
        public AddUserGroup()
        {
            InitializeComponent();
            UserGroupInstance = new UserGroup();
            this.DataContext = UserGroupInstance;
        }
        public event Action<AddUserGroup> SubmitEvent;
        /// <summary>
        /// 客户组
        /// </summary>
        public UserGroup UserGroupInstance
        {
            get { return (UserGroup)GetValue(UserGroupInstanceProperty); }
            set { SetValue(UserGroupInstanceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserGroupInstance.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserGroupInstanceProperty =
            DependencyProperty.Register("UserGroupInstance", typeof(UserGroup), typeof(AddUserGroup));

        //取消
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //确定
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BindingGroup bg = this.grid_Root.BindingGroup;
            foreach (var item in bg.BindingExpressions)
            {
                item.UpdateSource();
            }
            if (CommonHelper.GetUIElementError(this))
            {
                MessageBox.Show("请输入正确的数据");
                return;
            }
            if (this.SubmitEvent != null)
            {
                SubmitEvent.Invoke(this);
            }
        }


    }
}
