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
using Gss.Entities.DataManager;

namespace Gss.PopUpWindow.DataManager
{
    /// <summary>
    /// ExperienceWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ExperienceWindow : Window
    {
        public ExperienceWindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CurExperienceInformationProperty =
         DependencyProperty.Register("CurExperienceInformation", typeof(ExperienceInformation),
         typeof(ExperienceWindow));


        /// <summary>
        /// 当前操作的体验券
        /// </summary>
        public ExperienceInformation CurExperienceInformation
        {
            get { return (ExperienceInformation)GetValue(CurExperienceInformationProperty); }
            set
            {
                SetValue(CurExperienceInformationProperty, value);
            }
        }

        public static readonly DependencyProperty IsVisibilityProperty =
               DependencyProperty.Register("IsVisibility", typeof(Visibility), typeof(ExperienceWindow));
        
        public Visibility IsVisibility
        {
            get { return (Visibility)GetValue(IsVisibilityProperty); }
            set
            {
                SetValue(IsVisibilityProperty, value);
            }
        }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime StartDate
        {
            get { return (DateTime)GetValue(StartDateProperty); }
            set { SetValue(StartDateProperty, value); }
        }
        public static readonly DependencyProperty StartDateProperty =
     DependencyProperty.Register("StartDate", typeof(DateTime), typeof(ExperienceWindow), new UIPropertyMetadata(DateTime.Today));

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime EndDate
        {
            get { return (DateTime)GetValue(EndDateProperty); }
            set { SetValue(EndDateProperty, value); }
        }
        public static readonly DependencyProperty EndDateProperty =
     DependencyProperty.Register("EndDate", typeof(DateTime), typeof(ExperienceWindow), new UIPropertyMetadata(DateTime.Today));

        /// <summary>
        /// 到期日期
        /// </summary>
        public DateTime EffectiveTime
        {
            get { return (DateTime)GetValue(EffectiveTimeProperty); }
            set { SetValue(EffectiveTimeProperty, value); }
        }
        public static readonly DependencyProperty EffectiveTimeProperty =
     DependencyProperty.Register("EffectiveTime", typeof(DateTime), typeof(ExperienceWindow), new UIPropertyMetadata(DateTime.Today));

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void CbSex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CurExperienceInformation != null)
            {
                if (CurExperienceInformation.Name == "开户送券")
                    txtRceharge.IsReadOnly = true;
                else
                    txtRceharge.IsReadOnly = false;
            }
        }

        
    }
}
