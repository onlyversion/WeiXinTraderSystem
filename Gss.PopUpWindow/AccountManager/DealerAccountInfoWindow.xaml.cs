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
using System.Collections.ObjectModel;
using Gss.Entities.JTWEntityes;

namespace Gss.PopUpWindow
{
    /// <summary>
    /// DealerAccountInfoView.xaml 的交互逻辑
    /// </summary>
    public partial class DealerAccountInfoWindow
    {
        public DealerAccountInfoWindow()
        {
            InitializeComponent();
        }

        public event Action  ComitEvent;

        /// <summary>
        /// 会员列表
        /// </summary>
        public ObservableCollection<OrgInfo> POrgList
        {
            get { return (ObservableCollection<OrgInfo>)GetValue(POrgListProperty); }
            set { SetValue(POrgListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for POrgList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty POrgListProperty =
            DependencyProperty.Register("POrgList", typeof(ObservableCollection<OrgInfo>), typeof(DealerAccountInfoWindow), new UIPropertyMetadata(
                (e, v) =>
                {
                    //ObservableCollection<OrgInfo> info = v.NewValue as ObservableCollection<OrgInfo>;
                    //DealerAccountInfoWindow win = e as DealerAccountInfoWindow;
                    //win.CurOrgInfo = info.FirstOrDefault() as OrgInfo;
                }));

        public bool CreateMode
        {
            get { return (bool)GetValue(CreateModeProperty); }
            set { SetValue(CreateModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CreateMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CreateModeProperty =
            DependencyProperty.Register("CreateMode", typeof(bool), typeof(DealerAccountInfoWindow), new UIPropertyMetadata(false));

        public OrgInfo CurOrgInfo
        {
            get { return (OrgInfo)GetValue(CurOrgInfoProperty); }
            set { SetValue(CurOrgInfoProperty, value); }
        }
        public static readonly DependencyProperty CurOrgInfoProperty =
    DependencyProperty.Register("CurOrgInfo", typeof(OrgInfo), typeof(DealerAccountInfoWindow));

        /// <summary>
        /// 确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandBinding_Executed_Ok(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.ComitEvent != null)
            {
                ComitEvent.Invoke();
            }
        }

        private void CommandBinding_Executed_Cancel(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void CommandBinding_CanExecute_Ok(object sender, CanExecuteRoutedEventArgs e)
        {
            if (IsInitialized)
                e.CanExecute = !TraversalValidationResult.GetHasValidationError(this.Content as UIElement);
        }
    }
}
