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
using Gss.Entities.ValidationHelpers;
using Gss.Entities.Enums;
namespace Gss.PopUpWindow.ModifyPassword
{
    /// <summary>
    /// ModifyPasswordView.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyPasswordWindow : Window
    {

        public ModifyPasswordWindow()
        {
            InitializeComponent();
        }
        //密码
        public static readonly DependencyProperty TradePwdProperty =
            DependencyProperty.Register("TradePwd", typeof(string), typeof(ModifyPasswordWindow), new UIPropertyMetadata(string.Empty));

        //确认密码
        public static readonly DependencyProperty SureTradePwdProperty =
            DependencyProperty.Register("SureTradePwd", typeof(string), typeof(ModifyPasswordWindow), new UIPropertyMetadata(string.Empty));

        /// <summary>
        /// 密码
        /// </summary>
        public string TradePwd
        {
            get
            {
                return (string)GetValue(TradePwdProperty);
            }
            set
            {
                SetValue(TradePwdProperty, value);
            }
        }

        /// <summary>
        /// 确认密码
        /// </summary>
        public string SureTradePwd
        {
            get
            {
                return (string)GetValue(SureTradePwdProperty);
            }
            set
            {
                if (!value.Equals(TradePwd))
                    throw new ArgumentException("确认密码与交易密码必须一致");
                SetValue(SureTradePwdProperty, value);
            }
        }

        private PASSWORD_TYPE _passwordType;



        private void StackPanel_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            RadioButton rb = e.OriginalSource as RadioButton;
            if ((rb.Content as string) == "登陆密码")
                _passwordType = PASSWORD_TYPE.Trade;
            else
                _passwordType = PASSWORD_TYPE.Funds;
        }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public PASSWORD_TYPE PasswordType { get; set; }
        private void CommandBinding_Executed_Password(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            this.DialogResult = true;
            OldPassword = PbOld.Password;
            NewPassword = PbNew.Password;
            PasswordType = _passwordType;
            //StockTradeViewMode vm = DataContext as StockTradeViewMode;

            //if (_passwordType == PASSWORD_TYPE.Trade)
            //    vm.ModifyLoginPassword(PbOld.Password, PbNew.Password);
            //else
            //    vm.ModifyFundsPassword(PbOld.Password, PbNew.Password);

            //PbOld.Password = null;
            //PbNew.Password = null;
            //PbNewConfirm.Password = null;
        }

        PasswordRule rule = new PasswordRule() { MaxLength = 16, MinLength = 6 };
        private void CommandBinding_CanExecute_Password(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {

            ValidationResult PbNewResult = rule.Validate(PbNew.Password, new System.Globalization.CultureInfo("en-US"));
            //Validation validation
            PbNew.ToolTip = PbNewResult.ErrorContent;
            if (!PbNewResult.IsValid)
            {
                PbNew.BorderBrush = Brushes.Red;
            }
            else
            {
                PbNew.BorderBrush = cbrush.BorderBrush;
            }

            ValidationResult PbNewConfirmResult = rule.Validate(PbNewConfirm.Password, new System.Globalization.CultureInfo("en-US"));
            PbNewConfirm.ToolTip = PbNewConfirmResult.ErrorContent;
            if (!PbNewConfirmResult.IsValid)
            {
                PbNewConfirm.BorderBrush = Brushes.Red;
            }
            else
            {
                PbNewConfirm.BorderBrush = cbrush.BorderBrush;
            }

            ValidationResult PbOldResult = rule.Validate(PbOld.Password, new System.Globalization.CultureInfo("en-US"));
            PbOld.ToolTip = PbOldResult.ErrorContent;
            if (!PbOldResult.IsValid)
            {
                PbOld.BorderBrush = Brushes.Red;
            }
            else
            {
                PbOld.BorderBrush = cbrush.BorderBrush;
            }
            e.CanExecute = !string.IsNullOrEmpty(PbOld.Password) && !string.IsNullOrEmpty(PbNew.Password) && !string.IsNullOrEmpty(PbNewConfirm.Password)
                && PbNew.Password == PbNewConfirm.Password
                && PbNew.Password.Length >= 6
                && PbNew.Password.Length <= 16
                && PbNewConfirm.Password.Length >= 6
                && PbNewConfirm.Password.Length <= 16;
        }


    }
}
