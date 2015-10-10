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
using Gss.Entities.JTWEntityes;
using System.Text.RegularExpressions;

namespace Gss.PopUpWindow.SystemSetting
{
    /// <summary>
    /// TradeSetWindow.xaml 的交互逻辑
    /// </summary>
    public partial class TradeSetWindow : Window
    {
        public static readonly DependencyProperty CodeEnableProperty =
     DependencyProperty.Register("CodeEnable", typeof(bool), typeof(TradeSetWindow), new UIPropertyMetadata(false));

        public bool HasError { get; set; }

        public bool CodeEnable
        {
            set { SetValue(CodeEnableProperty, value); }
            get { return (bool)GetValue(CodeEnableProperty); }
        }
        public TradeSetWindow()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            GetObjCodeError();
            if ( HasError ==  true)
            {
                return;
            }
            this.DialogResult = true;
            BindingExpression binding = txtObjName.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
            BindingExpression binding2 = txtCodeEnable.GetBindingExpression(TextBox.TextProperty);
            binding2.UpdateSource();
            BindingExpression binding3 = txtObjValue.GetBindingExpression(TextBox.TextProperty);
            binding3.UpdateSource();
            BindingExpression binding4 = txtRemark.GetBindingExpression(TextBox.TextProperty);
            binding4.UpdateSource();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
           
        }
        TradeConfigInfo tc = new TradeConfigInfo();
        private void acc_Loaded(object sender, RoutedEventArgs e)
        {
             tc = this.DataContext as TradeConfigInfo;
            //if (tc != null)
            //{
            //    switch (tc.ObjCode)
            //    {
            //        case "CCFJSSJ"://0-23
                     
            //            break;
            //        case "GDYXQ"://-1 - 
            //            break;
            //        case "YKGS"://最大50个字符
            //            break;

            //        default:
            //            break;
            //    }

            //    Binding b = new Binding() { Path = new PropertyPath("ObjValue"), Mode= BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.Explicit };
            //    b.ValidationRules.Add();

            //    this.txtObjValue.SetBinding(TextBox.TextProperty, b);
            //}
        }

        private void txtObjValue_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
        public void GetObjCodeError()
        {
            string str = this.txtObjValue.Text;

           

            if (tc.ObjCode == "CCFJSSJ")
            {
                if (!Regex.IsMatch(str, "^[0-9]$|^[1-2][0-3]$"))
                {
                    MessageBox.Show("值的必须在0至23之间的整数");
                    HasError = true;
                    return;
                }
                else
                {
                    HasError = false;
                    return;
                }
               


            }
            else if (tc.ObjCode == "GDYXQ")
            {
               
                if (!Regex.IsMatch(str, "^[0-9]$|^[1-2][0-9]$|^30$|^-1$"))
                {
                    MessageBox.Show("值的必须在-1至30之间的整数");
                    HasError = true;
                    return;
                }
                else
                {
                    HasError = false;
                    return;
                }

            }
            else if (tc.ObjCode == "YKGS")
            {
                if (!Regex.IsMatch(str, @"^.{0,50}$"))
                {
                    MessageBox.Show("值的最大为50个字符");
                    HasError = true;
                    return;
                }
                else
                {
                    HasError = false;
                    return;
                }

            }
        }
    }
}
