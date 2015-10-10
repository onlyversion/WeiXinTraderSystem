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

namespace Gss.PopUpWindow.AccountInfoModule {
    /// <summary>
    /// AccountInfoPart.xaml 的交互逻辑
    /// </summary>
    public partial class AccountInfoPart {
        public AccountInfoPart( ) {
            InitializeComponent( );
        }

        /// <summary>
        /// 获取账户部分是否通过验证
        /// </summary>
        public bool ValidationHasError {
            get {
                return Validation.GetHasError( TbName ) || Validation.GetHasError( TbPassword );
            }
        }
    }
}
