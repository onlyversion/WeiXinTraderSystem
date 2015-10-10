using System.Windows;
using System.Windows.Input;

namespace Gss.PopUpWindow.AccountManager
{
    /// <summary>
    /// ClerkAccountWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ClerkAccountWindow : Window
    {

        public static readonly DependencyProperty AccNameVisibilityProperty =
            DependencyProperty.Register("AccNameVisibility", typeof(Visibility), typeof(ClerkAccountWindow), new UIPropertyMetadata(Visibility.Collapsed));

        /// <summary>
        /// 显示
        /// </summary>
        public Visibility AccNameVisibility
        {
            get { return (Visibility)GetValue(AccNameVisibilityProperty); }
            set { SetValue(AccNameVisibilityProperty, value); }
        }
        public ClerkAccountWindow()
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

        private void CommandBinding_Executed_Cancel(object sender, ExecutedRoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
