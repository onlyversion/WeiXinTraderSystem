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
using Gss.Common.Utility;

namespace Gss.PopUpWindow.SystemSetting
{
    /// <summary>
    /// AddGroupAccount.xaml 的交互逻辑
    /// </summary>
    public partial class AddGroupAccount : Window
    {
        public AddGroupAccount()
        {
            InitializeComponent();
        }
        public event Action<AddGroupAccount> SubmitEvent;
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression b =  this.textBox2.GetBindingExpression(TextBox.TextProperty);
            b.UpdateSource();
            if (CommonHelper.GetUIElementError(this))
            {
                MessageBox.Show("请输入正确的数据");
                return;
            }
            if (SubmitEvent != null)
            {
                SubmitEvent.Invoke(this);
            }
        }



        public string Account
        {
            get { return (string)GetValue(AccountProperty); }
            set { SetValue(AccountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Account.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccountProperty =
            DependencyProperty.Register("Account", typeof(string), typeof(AddGroupAccount), new UIPropertyMetadata(""));


    }
}
