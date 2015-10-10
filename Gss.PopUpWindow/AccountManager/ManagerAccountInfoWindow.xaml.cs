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

namespace Gss.PopUpWindow {
    /// <summary>
    /// ManagerAccountInfoView.xaml 的交互逻辑
    /// </summary>
    public partial class ManagerAccountInfoWindow : Window {
        public ManagerAccountInfoWindow( ) {
            InitializeComponent( );
        }

        public bool CreateMode {
            get { return ( bool )GetValue( CreateModeProperty ); }
            set { SetValue( CreateModeProperty, value ); }
        }

        // Using a DependencyProperty as the backing store for CreateMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateModeProperty =
            DependencyProperty.Register( "CreateMode", typeof( bool ), typeof( ManagerAccountInfoWindow ), new UIPropertyMetadata( false ) );


        private void CommandBinding_Executed_Ok( object sender, ExecutedRoutedEventArgs e ) {
            DialogResult = true;
            Close( );
        }

        private void CommandBinding_Executed_Cancel( object sender, ExecutedRoutedEventArgs e ) {
            Close( );
        }

        private void CommandBinding_CanExecute_Ok( object sender, CanExecuteRoutedEventArgs e ) {
            if( IsInitialized )
                e.CanExecute = !TraversalValidationResult.GetHasValidationError( this.Content as UIElement );
        }
    }
}
