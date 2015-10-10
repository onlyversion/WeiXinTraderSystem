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

namespace Gss.PopUpWindow
{
    /// <summary>
    /// ModifyOrderAllowStoreWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ModifyOrderAllowStoreWindow : Window
    {
        public ModifyOrderAllowStoreWindow()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed_Ok(object sender, ExecutedRoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CommandBinding_CanExecute_Ok(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
