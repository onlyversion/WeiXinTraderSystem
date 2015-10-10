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
using System.Collections.ObjectModel;
using Gss.Entities.JTWEntityes;

namespace Gss.PopUpWindow.AccountManager
{
    /// <summary>
    /// OrgDetialWindow.xaml 的交互逻辑
    /// </summary>
    public partial class OrgDetialWindow : Window
    {
        public event Action ComitEvent;
        public event Action CancelEvent;
        private ObservableCollection<OrgInfo> _POrgList;
        /// <summary>
        /// 微会员列表
        /// </summary>
        public ObservableCollection<OrgInfo> POrgList
        {
            get { return _POrgList; }
            set
            {
                _POrgList = value;
            }
        }
        public OrgDetialWindow()
        {
            POrgList = new ObservableCollection<OrgInfo>();
            //ORG = new OrgInfo();
            InitializeComponent();
        }
        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (ComitEvent != null)
            {
                ComitEvent.Invoke();
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (CancelEvent != null)
            {
                CancelEvent.Invoke();
            }
        }

        private void CommandBinding_Executed_OK(object sender, ExecutedRoutedEventArgs e)
        {
            if (POrgList.Where(p=>p.OrgName == this.orgName.Text.Trim()).Count() >0)
            {
                MessageBox.Show(this.orgName.Text.Trim()+"已存在！");
                return;
            }
            this.DialogResult = true;
        }

        private void CommandBinding_CanExecute_OK(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            foreach (object child in LogicalTreeHelper.GetChildren(grid))
            {
                TextBox txt = child as TextBox;
                if (txt != null)
                {
                    if (Validation.GetHasError(txt))
                        e.CanExecute = false;
                }
            }
        }
        //public static OrgInfo ORG { get; set; }

        public OrgInfo ParentOrgInfo
        {
            get { return (OrgInfo)GetValue(ParentOrgInfoProperty); }
            set { SetValue(ParentOrgInfoProperty, value); }
        }
        public static readonly DependencyProperty ParentOrgInfoProperty =
    DependencyProperty.Register("ParentOrgInfo", typeof(OrgInfo), typeof(OrgDetialWindow), new PropertyMetadata(OnParentInfoChanged));

        private static void OnParentInfoChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OrgDetialWindow sender = d as OrgDetialWindow;
            if (sender.ParentOrgInfo!=null&&!string.IsNullOrEmpty(sender.ParentOrgInfo.OrgName))
                sender.btnCreateOrgCode.IsEnabled = true;
            else
                sender.btnCreateOrgCode.IsEnabled = false;
        }


        public bool IsCanCreateOrgCode
        {
            get { return (bool)GetValue(IsCanCreateOrgCodeProperty); }
            set { SetValue(IsCanCreateOrgCodeProperty, value); }
        }
        public static readonly DependencyProperty IsCanCreateOrgCodeProperty =
    DependencyProperty.Register("IsCanCreateOrgCode", typeof(bool), typeof(OrgDetialWindow));

       
    }
}
