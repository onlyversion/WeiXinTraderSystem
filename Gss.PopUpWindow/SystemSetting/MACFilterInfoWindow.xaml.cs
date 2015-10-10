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
using Gss.Entities;

namespace Gss.PopUpWindow {
    /// <summary>
    /// MACFilterInfoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MACFilterInfoWindow : Window {
        public MACFilterInfoWindow( ) {
            InitializeComponent( );
        }

        private void CommandBinding_Executed_Ok( object sender, ExecutedRoutedEventArgs e ) {
            DialogResult = true;
            Close( );
        }

        private void CommandBinding_CanExecute_Ok( object sender, CanExecuteRoutedEventArgs e ) {
            if( IsInitialized ) {
                MACFilterInformation info = DataContext as MACFilterInformation;
                if( info != null ) {
                    e.CanExecute = !string.IsNullOrEmpty( info.MACAddress );
                }
            }
        }

        private void CommandBinding_Executed_Cancel( object sender, ExecutedRoutedEventArgs e ) {
            Close( );
        }

    }
}
