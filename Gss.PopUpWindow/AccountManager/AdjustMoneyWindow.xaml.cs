using System.Windows;
using System.Windows.Input;
using Gss.Entities.Enums;

namespace Gss.PopUpWindow {
    /// <summary>
    /// AdjustMoneyWindow.xaml 的交互逻辑
    /// </summary>
    public partial class AdjustMoneyWindow : Window {
        #region 出入金模式属性
        public CASH_IO_MODE CashIOMode { get; private set; }
        #endregion

        #region 资金依赖属性

        public double Deposit {
            get { return ( double )GetValue( DepositProperty ); }
            set { SetValue( DepositProperty, value ); }
        }

        // Using a DependencyProperty as the backing store for Deposit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DepositProperty =
            DependencyProperty.Register( "Deposit", typeof( double ), typeof( AdjustMoneyWindow ), new UIPropertyMetadata( 0d ) );

        #endregion

        #region 构造函数

        public AdjustMoneyWindow( ) {
            InitializeComponent( );
        }

        #endregion

        #region 命令

        private void CommandBinding_Executed_CashIn( object sender, ExecutedRoutedEventArgs e ) {
            CashIOMode = CASH_IO_MODE.In;
            DialogResult = true;
            this.Close( );
        }

        private void CommandBinding_Executed_CashOut( object sender, ExecutedRoutedEventArgs e ) {
            CashIOMode = CASH_IO_MODE.Out;
            DialogResult = true;
            this.Close( );
        }

        #endregion
    }
}
