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
using Gss.Entities;
using Gss.Entities.DataManager;
using Gss.ViewModel.Management;

namespace Gss.ManagementMenu.DataManager
{
    /// <summary>
    /// ExperienceControl.xaml 的交互逻辑
    /// </summary>
    public partial class ExperienceControl : UserControl
    {
        public ExperienceControl()
        {
            InitializeComponent();
           this.Loaded += new RoutedEventHandler(ExperienceControl_Loaded);
        }

        void ExperienceControl_Loaded(object sender, RoutedEventArgs e)
        {
            dpTime.SelectedDate = DateTime.Today;
        }
        
        private void CommandBinding_Executed_ViewDetail(object sender, ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            ExperienceInformation exp = (e.OriginalSource as DataGridRow).DataContext as ExperienceInformation;
            vm.EditExperience(exp);
        }

        private void CommandBinding_Executed_Delete(object sender, ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            ExperienceInformation exp = (e.OriginalSource as DataGridRow).DataContext as ExperienceInformation;
            if( vm.DelExperience(exp.Id))
                Query();
        }

        private void DataGridRow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            ExperienceInformation exp = (e.OriginalSource as DataGridRow).DataContext as ExperienceInformation;
            vm.EditExperience(exp);
        }


        private void CommandBinding_Executed_Add(object sender, ExecutedRoutedEventArgs e)
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            if(vm.AddExperience()!=null)
                Query();
        }

        private void ContextMenu_Opened(object sender, RoutedEventArgs e)
        {
            ContextMenu cMenu = sender as ContextMenu;
            cMenu.DataContext = DataContext;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Query();
        }

        private void Query()
        {
            ManagementViewModel vm = DataContext as ManagementViewModel;
            int type = -1, state = -1;
            DateTime? time=null ;
            switch (cmbType.SelectedValue.ToString())
            {
                case "全部":
                    type = -1;
                    break;
                case "开户送券":
                    type = 1;
                    break;
                case "充值送券":
                    type = 2;
                    break;
            }
            switch (cmdState.SelectedValue.ToString())
            {
                case "全部":
                    state = -1;
                    break;
                case "启用":
                    state = 1;
                    break;
                case "未启用":
                    state = 0;
                    break;
            }

            if (dpTime.SelectedDate != null)
            {
                time = dpTime.SelectedDate;
                time= new DateTime(((DateTime)time).Year, ((DateTime)time).Month, ((DateTime)time).Day, 23, 59, 59);
            }
            dgGrid.ItemsSource = vm.GetExperienceInfo(type, state, time);
        }
    }
}
