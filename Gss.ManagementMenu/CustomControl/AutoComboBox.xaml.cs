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
using System.Collections;
using System.Reflection;

namespace Gss.ManagementMenu.CustomControl
{
    public enum AutoComboBoxState
    {
        /// <summary>
        /// 无
        /// </summary>
        NullState,
        /// <summary>
        /// 已修改
        /// </summary>
        AlterState,
        /// <summary>
        /// 已选择
        /// </summary>
        ComplateState
    }
    /// <summary>
    /// AutoComboBox.xaml 的交互逻辑
    /// </summary>
    public partial class AutoComboBox : UserControl
    {
        public AutoComboBox()
        {
            InitializeComponent();
            State = AutoComboBoxState.NullState;
            this.IsPopOpen = false;
        }

        //public AutoComboBoxState State { get;private set; }
        private AutoComboBoxState _State;

        public AutoComboBoxState State
        {
            get 
            {
                //return _State;
                if (string.IsNullOrEmpty(this.Tbx.Text))
                {
                    return AutoComboBoxState.NullState;
                }
                else
                {
                    Type _type = this.ItemsSource[0].GetType();

                    foreach (var item in this.ItemsSource)
                    {
                        PropertyInfo pro = _type.GetProperty(this.DisplayName);
                        if (pro.GetValue(item,null).ToString() == this.Tbx.Text)
                        {
                            return AutoComboBoxState.ComplateState;
                        }
                    }
                    return AutoComboBoxState.AlterState;
                    
                    //if (view != null)
                    //{
                    //    var sd = _type.GetProperty(DisplayName).ToString();
                    //    view.Filter = delegate(object i)
                    //    {
                    //        PropertyInfo p = _type.GetProperty(DisplayName);
                    //        var ss = p.GetValue(i, null);
                    //        return ss.ToString().Contains(this.Tbx.Text);
                    //    };
                    //};
                }
            }
            private set { _State = value; }
        }


        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IList), typeof(AutoComboBox));




        public string DisplayName
        {
            get { return (string)GetValue(DisplayNameProperty); }
            set { SetValue(DisplayNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayNameProperty =
            DependencyProperty.Register("DisplayName", typeof(string), typeof(AutoComboBox));




        public bool IsPopOpen
        {
            get { return (bool)GetValue(IsPopOpenProperty); }
            set { SetValue(IsPopOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPopOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPopOpenProperty =
            DependencyProperty.Register("IsPopOpen", typeof(bool), typeof(AutoComboBox), new UIPropertyMetadata(false));




        public string SelectedValuePath
        {
            get { return (string)GetValue(SelectedValuePathProperty); }
            set { SetValue(SelectedValuePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedValuePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedValuePathProperty =
            DependencyProperty.Register("SelectedValuePath", typeof(string), typeof(AutoComboBox));




        public object SelectedValue
        {
            get { return (object)GetValue(SelectedValueProperty); }
            set { SetValue(SelectedValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedValueProperty =
            DependencyProperty.Register("SelectedValue", typeof(object), typeof(AutoComboBox), new PropertyMetadata(OnSelectedValueChanged));



        private static void OnSelectedValueChanged(DependencyObject d,DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue == null)
            {
                AutoComboBox ac = d as AutoComboBox;
                ac.SelectedValue = e.OldValue;
            }
        }


        public string KeyWords
        {
            get { return (string)GetValue(KeyWordsProperty); }
            set { SetValue(KeyWordsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for KeyWords.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KeyWordsProperty =
            DependencyProperty.Register("KeyWords", typeof(string), typeof(AutoComboBox));




        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            this.IsPopOpen = !this.IsPopOpen;
            ListCollectionView view = CollectionViewSource.GetDefaultView(ItemsSource) as ListCollectionView;
            if (view != null)
            {
                view.Filter = null;
            }
            e.Handled = true;
        }

        private void UserC_MouseLeave(object sender, MouseEventArgs e)
        {
            if (IsPopOpen && !this.Lst.IsMouseOver)
            {
                IsPopOpen = false;
            }
        }



        private void Tbx_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            IsPopOpen = true;
            if (this.ItemsSource == null && ItemsSource.Count > 0)
            {
                return;
            }
            else
            {
                Type _type = this.ItemsSource[0].GetType();
                ListCollectionView view = CollectionViewSource.GetDefaultView(ItemsSource) as ListCollectionView;

                if (view != null)
                {
                    var sd = _type.GetProperty(DisplayName).ToString();
                    view.Filter = delegate(object i)
                    {
                        PropertyInfo p = _type.GetProperty(DisplayName);
                        var ss = p.GetValue(i, null);
                        return ss.ToString().Contains(this.Tbx.Text);
                    };
                };
            }
        }


        private void Tbx_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!IsPopOpen)
            {
                return;
            }
            switch (e.Key)
            {
                case Key.Down:
                    this.Lst.Focus();
                    break;
                default:
                    break;
            }
        }
        private bool IsLstMouseDown = false;
        private void Lst_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            IsLstMouseDown = true;
            //if (this.Lst.SelectedItem != null)
            //{
            //    this.Tbx.Text = this.Lst.SelectedItem.ToString();
            //    IsPopOpen = false;

            //    this.Tbx.CaretIndex = this.Tbx.Text.Length;
            //    this.Tbx.Focus();
            //}
        }

        private void Lst_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    if (this.Lst.SelectedItem != null)
                    {
                        this.Tbx.Text = this.Lst.SelectedItem.ToString();
                        IsPopOpen = false;

                        this.Tbx.CaretIndex = this.Tbx.Text.Length;
                        this.Tbx.Focus();

                    }
                    break;
                default:
                    break;
            }
        }

        public object CurItem
        {
            get { return (object)GetValue(CurItemProperty); }
            set { SetValue(CurItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurItemProperty =
            DependencyProperty.Register("CurItem", typeof(object), typeof(AutoComboBox), new PropertyMetadata(OnCurItemChanged));



        private static void OnCurItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AutoComboBox ac = d as AutoComboBox;
            if (e.NewValue != null && ac.IsLstMouseDown)
            {
                ac.Tbx.Text = ac.CurItem.ToString();
                ac.IsPopOpen = false;

                ac.Tbx.CaretIndex = ac.Tbx.Text.Length;
                ac.Tbx.Focus();

                ac.IsLstMouseDown = false;

            }
        }


    }

    
}
