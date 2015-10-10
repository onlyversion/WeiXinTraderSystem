//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Dynamic;
//using System.Linq;
//using System.Text;
//using System.ComponentModel;
//using System.Windows.Data;
//using System.Windows.Controls;
//using System.Windows;
//using System.Globalization;
//using System.Threading;
//using System.Windows.Forms;


//namespace Gss.ManagementMenu.CustomControl
//{
//    //public class AutoFilteredComboBox : ComboBox
//    //{

//    //    private int silenceEvents = 0;

//    //    /// <summary>
//    //    /// Creates a new instance of <see cref="AutoFilteredComboBox" />.
//    //    /// </summary>
//    //    public AutoFilteredComboBox()
//    //    {
//    //        DependencyPropertyDescriptor textProperty = DependencyPropertyDescriptor.FromProperty(ComboBox.TextProperty, typeof(AutoFilteredComboBox));
//    //        textProperty.AddValueChanged(this, this.OnTextChanged);

//    //        this.RegisterIsCaseSensitiveChangeNotification();
//    //        this.IsEditable = true;
//    //    }

//    //    #region IsCaseSensitive Dependency Property
//    //    /// <summary>
//    //    /// The <see cref="DependencyProperty"/> object of the <see cref="IsCaseSensitive" /> dependency property.
//    //    /// </summary>
//    //    public static readonly DependencyProperty IsCaseSensitiveProperty =
//    //        DependencyProperty.Register("IsCaseSensitive", typeof(bool), typeof(AutoFilteredComboBox), new UIPropertyMetadata(false));

//    //    /// <summary>
//    //    /// Gets or sets the way the combo box treats the case sensitivity of typed text.
//    //    /// </summary>
//    //    /// <value>The way the combo box treats the case sensitivity of typed text.</value>
//    //    [System.ComponentModel.Description("The way the combo box treats the case sensitivity of typed text.")]
//    //    [System.ComponentModel.Category("AutoFiltered ComboBox")]
//    //    [System.ComponentModel.DefaultValue(true)]
//    //    public bool IsCaseSensitive
//    //    {
//    //        [System.Diagnostics.DebuggerStepThrough]
//    //        get
//    //        {
//    //            return (bool)this.GetValue(IsCaseSensitiveProperty);
//    //        }
//    //        [System.Diagnostics.DebuggerStepThrough]
//    //        set
//    //        {
//    //            this.SetValue(IsCaseSensitiveProperty, value);
//    //        }
//    //    }

//    //    protected virtual void OnIsCaseSensitiveChanged(object sender, EventArgs e)
//    //    {
//    //        if (this.IsCaseSensitive)
//    //            this.IsTextSearchEnabled = false;

//    //        this.RefreshFilter();
//    //    }

//    //    private void RegisterIsCaseSensitiveChangeNotification()
//    //    {
//    //        DependencyPropertyDescriptor.FromProperty(IsCaseSensitiveProperty, typeof(AutoFilteredComboBox)).AddValueChanged(
//    //            this, this.OnIsCaseSensitiveChanged);
//    //    }
//    //    #endregion

//    //    #region DropDownOnFocus Dependency Property
//    //    /// <summary>
//    //    /// The <see cref="DependencyProperty"/> object of the <see cref="DropDownOnFocus" /> dependency property.
//    //    /// </summary>
//    //    public static readonly DependencyProperty DropDownOnFocusProperty =
//    //        DependencyProperty.Register("DropDownOnFocus", typeof(bool), typeof(AutoFilteredComboBox), new UIPropertyMetadata(true));

//    //    /// <summary>
//    //    /// Gets or sets the way the combo box behaves when it receives focus.
//    //    /// </summary>
//    //    /// <value>The way the combo box behaves when it receives focus.</value>
//    //    [System.ComponentModel.Description("The way the combo box behaves when it receives focus.")]
//    //    [System.ComponentModel.Category("AutoFiltered ComboBox")]
//    //    [System.ComponentModel.DefaultValue(true)]
//    //    public bool DropDownOnFocus
//    //    {
//    //        [System.Diagnostics.DebuggerStepThrough]
//    //        get
//    //        {
//    //            return (bool)this.GetValue(DropDownOnFocusProperty);
//    //        }
//    //        [System.Diagnostics.DebuggerStepThrough]
//    //        set
//    //        {
//    //            this.SetValue(DropDownOnFocusProperty, value);
//    //        }
//    //    }
//    //    #endregion

//    //    #region | Handle selection |
//    //    /// <summary>
//    //    /// Called when <see cref="ComboBox.ApplyTemplate()"/> is called.
//    //    /// </summary>
//    //    public override void OnApplyTemplate()
//    //    {
//    //        base.OnApplyTemplate();

//    //        this.EditableTextBox.SelectionChanged += this.EditableTextBox_SelectionChanged;
//    //    }

//    //    /// <summary>
//    //    /// Gets the text box in charge of the editable portion of the combo box.
//    //    /// </summary>
//    //    protected TextBox EditableTextBox
//    //    {
//    //        get
//    //        {
//    //            TextBox TxtBox = (TextBox)this.Template.FindName("PART_EditableTextBox", this);
//    //            return TxtBox;
//    //        }
//    //    }

//    //    private int start = 0, length = 0;

//    //    private void EditableTextBox_SelectionChanged(object sender, RoutedEventArgs e)
//    //    {
//    //        if (this.silenceEvents == 0)
//    //        {
//    //            this.start = ((TextBox)(e.OriginalSource)).SelectionStart;
//    //            this.length = ((TextBox)(e.OriginalSource)).SelectionLength;

//    //            this.RefreshFilter();
//    //        }
//    //    }
//    //    #endregion

//    //    #region | Handle focus |
//    //    /// <summary>
//    //    /// Invoked whenever an unhandled <see cref="UIElement.GotFocus" /> event
//    //    /// reaches this element in its route.
//    //    /// </summary>
//    //    /// <param name="e">The <see cref="RoutedEventArgs" /> that contains the event data.</param>
//    //    protected override void OnGotFocus(RoutedEventArgs e)
//    //    {
//    //        base.OnGotFocus(e);

//    //        if (this.ItemsSource != null && this.DropDownOnFocus)
//    //        {
//    //            this.IsDropDownOpen = true;
//    //        }
//    //    }
//    //    #endregion

//    //    #region | Handle filtering |
//    //    private void RefreshFilter()
//    //    {
//    //        if (this.ItemsSource != null)
//    //        {
//    //            ICollectionView view = CollectionViewSource.GetDefaultView(this.ItemsSource);
//    //            view.Refresh();
//    //            this.IsDropDownOpen = true;
//    //        }
//    //    }

//    //    private bool FilterPredicate(object value)
//    //    {
//    //        // We don't like nulls.
//    //        if (value == null)
//    //            return false;

//    //        // If there is no text, there's no reason to filter.
//    //        if (this.Text.Length == 0)
//    //            return true;

//    //        string prefix = this.Text;

//    //        // If the end of the text is selected, do not mind it.
//    //        if (this.length > 0 && this.start + this.length == this.Text.Length)
//    //        {
//    //            prefix = prefix.Substring(0, this.start);
//    //        }

//    //        //return value.ToString()
//    //        //    .StartsWith(prefix, !this.IsCaseSensitive, CultureInfo.CurrentCulture);


//    //        return value.ToString()
//    //            .Contains(prefix);
//    //    }
//    //    #endregion

//    //    /// <summary>
//    //    /// Called when the source of an item in a selector changes.
//    //    /// </summary>
//    //    /// <param name="oldValue">Old value of the source.</param>
//    //    /// <param name="newValue">New value of the source.</param>
//    //    protected override void OnItemsSourceChanged(System.Collections.IEnumerable oldValue, System.Collections.IEnumerable newValue)
//    //    {
//    //        if (newValue != null)
//    //        {
//    //            ICollectionView view = CollectionViewSource.GetDefaultView(newValue);
//    //            view.Filter += this.FilterPredicate;
//    //        }

//    //        if (oldValue != null)
//    //        {
//    //            ICollectionView view = CollectionViewSource.GetDefaultView(oldValue);
//    //            view.Filter -= this.FilterPredicate;
//    //        }

//    //        base.OnItemsSourceChanged(oldValue, newValue);
//    //    }

//    //    private void OnTextChanged(object sender, EventArgs e)
//    //    {
//    //        if (!this.IsTextSearchEnabled && this.silenceEvents == 0)
//    //        {
//    //            this.RefreshFilter();

//    //            // Manually simulate the automatic selection that would have been
//    //            // available if the IsTextSearchEnabled dependency property was set.
//    //            if (this.Text.Length > 0)
//    //            {
//    //                foreach (object item in CollectionViewSource.GetDefaultView(this.ItemsSource))
//    //                {
//    //                    int text = item.ToString().Length, prefix = this.Text.Length;
//    //                    this.SelectedItem = item;

//    //                    this.silenceEvents++;
//    //                    this.EditableTextBox.Text = item.ToString();
//    //                    this.EditableTextBox.Select(prefix, text - prefix);
//    //                    this.silenceEvents--;
//    //                    break;
//    //                }
//    //            }
//    //        }
//    //    }
//    //}

//    public class AllComboBox : ComboBox
//    {
//        private BindingBase _itemTemplateBinding;

//        protected override void OnInitialized(EventArgs e)
//        {
//            //add error logger and log when binding error occurs
//            Validation.AddErrorHandler(this, (sender, arg) =>
//            {
//                if (arg.Error.RuleInError is ExceptionValidationRule)
//                    System.Diagnostics.Debug.Fail(arg.Error.ErrorContent.ToString());
//            });

//            //override these propperties
//            OverrideItemsSourceProperty(this);
//            OverrideSelectedItemProperty(this);
//            OverrideTextProperty(this);
//            //attach the on itemsSource changed, refresh the text to notify the viewmodel;
//            ResetTextWhenItemsSourceChanged();
//            //deal with the text error , reselect the same comboboxitem, the text do not update bug.
//            ResetSelectedItemWhenTextError();

//            base.OnInitialized(e);
//        }

//        private void ResetTextWhenItemsSourceChanged()
//        {
//            if (this.IsEditable)
//            {
//                var descriptor = DependencyPropertyDescriptor.FromProperty(ItemsSourceProperty, typeof(AllComboBox));
//                //notify the view model that the text has changed
//                //descriptor.AddValueChanged(this, (s, e) => BindingOperations.GetBindingExpression(this, TextProperty).SafeInvoke(expression => expression.UpdateSource()));
//                descriptor.AddValueChanged(this, (s, e) => BindingOperations.GetBindingExpression(this, TextProperty).SafeInvoke(expression => expression.UpdateSource()));
//            }
//        }

//        private void ResetSelectedItemWhenTextError()
//        {
//            if (this.IsEditable)
//            {
//                var descriptor = DependencyPropertyDescriptor.FromProperty(TextProperty, typeof(AllComboBox));
//                descriptor.AddValueChanged(this, (s, e) =>
//                {
//                    if (this.DisplayList.IsNullOrEmpty() || !DisplayList.Contains(this.Text))
//                        this.SelectedItem = null;
//                });
//            }
//        }

//        private bool IsWapperByDisplayObject
//        { get; set; }

//        public bool HasAllOption
//        {
//            get { return (bool)GetValue(HasAllOptionProperty); }
//            set { SetValue(HasAllOptionProperty, value); }
//        }

//        // Using a DependencyProperty as the backing store for HasAllOption.  This enables animation, styling, binding, etc...
//        public static readonly DependencyProperty HasAllOptionProperty =
//            DependencyProperty.Register("HasAllOption", typeof(bool), typeof(AllComboBox), new UIPropertyMetadata(true));

//        public bool IsAll
//        {
//            get { return (bool)GetValue(IsAllProperty); }
//            set { SetValue(IsAllProperty, value); }
//        }

//        // Using a DependencyProperty as the backing store for IsAll.  This enables animation, styling, binding, etc...
//        public static readonly DependencyProperty IsAllProperty =
//            DependencyProperty.Register("IsAll", typeof(bool), typeof(AllComboBox),
//            new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, null, (d, b) =>
//            {
//                var isAll = (bool)b;
//                if (isAll)
//                {
//                    var cmb = d as AllComboBox;
//                    if (cmb.HasItems && cmb.SelectedIndex != 0)
//                    {
//                        cmb.SelectedIndex = 0;
//                        //notify viewmodel the selected item has changed
//                        BindingOperations.GetBindingExpression(cmb, SelectedItemProperty).UpdateSource();
//                    }
//                }
//                return b;
//            }));

//        public string AllText
//        {
//            get { return (string)GetValue(AllTextProperty); }
//            set { SetValue(AllTextProperty, value); }
//        }

//        // Using a DependencyProperty as the backing store for AllText.  This enables animation, styling, binding, etc...
//        public static readonly DependencyProperty AllTextProperty =
//            DependencyProperty.Register("AllText", typeof(string), typeof(AllComboBox), new UIPropertyMetadata(string.Empty));


//        public IEnumerable<string> DisplayList
//        {
//            get { return (IEnumerable<string>)GetValue(DisplayListProperty); }
//            set { SetValue(DisplayListProperty, value); }
//        }

//        // Using a DependencyProperty as the backing store for DisplayList.  This enables animation, styling, binding, etc...
//        public static readonly DependencyProperty DisplayListProperty =
//            DependencyProperty.Register("DisplayList", typeof(IEnumerable<string>), typeof(AllComboBox), new FrameworkPropertyMetadata(Enumerable.Empty<string>(), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


//        protected override void OnItemTemplateChanged(DataTemplate oldItemTemplate, DataTemplate newItemTemplate)
//        {
//            //get the binding expresion
//            if (newItemTemplate != null && newItemTemplate.HasContent)
//                _itemTemplateBinding = BindingOperations.GetBindingBase(newItemTemplate.LoadContent(), TextBlock.TextProperty);
//            base.OnItemTemplateChanged(oldItemTemplate, newItemTemplate);
//        }

//        private static void OverrideItemsSourceProperty(DependencyObject d)
//        {
//            var cmb = d as AllComboBox;
//            var binding = BindingOperations.GetBinding(cmb, ItemsSourceProperty);
//            if (binding == null) return;
//            var newBinding = CreateBinding(binding.Path.Path, binding.Source, mode: BindingMode.Default, converter: new ItemsSourceConverter(), converterParameter: cmb);
//            cmb.SetBinding(ItemsSourceProperty, newBinding);
//        }

//        private static void OverrideSelectedItemProperty(DependencyObject d)
//        {
//            var cmb = d as AllComboBox;
//            var binding = BindingOperations.GetBinding(cmb, SelectedItemProperty);
//            if (binding == null) return;
//            var newBinding = CreateBinding(binding.Path.Path, converter: new SelectedItemConverter(), converterParameter: cmb);
//            cmb.SetBinding(SelectedItemProperty, newBinding);
//        }

//        private static void OverrideTextProperty(DependencyObject d)
//        {
//            var cmb = d as AllComboBox;
//            var binding = BindingOperations.GetBinding(cmb, TextProperty);
//            if (binding == null) return;
//            var newBinding = CreateBinding(binding.Path.Path);
//            cmb.SetBinding(TextProperty, newBinding);
//        }

//        private static Binding CreateBinding(string path, object source = null, BindingMode mode = BindingMode.TwoWay, IValueConverter converter = null, object converterParameter = null)
//        {
//            var binding = new Binding(path)
//            {
//                Mode = mode,
//                Converter = converter,
//                ConverterParameter = converterParameter,
//                ValidatesOnDataErrors = true,
//                ValidatesOnExceptions = true,
//                NotifyOnValidationError = true
//            };
//            if (source != null)
//                binding.Source = source;
//            return binding;
//        }


//        private class ItemsSourceConverter : IValueConverter
//        {
//            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//            {
//                var source = value as IEnumerable;
//                var cmb = parameter as AllComboBox;
//                if (source.IsNullOrEmpty())
//                {
//                    cmb.DisplayList = Enumerable.Empty<string>();
//                    return value;
//                }

//                if (Equals(source, cmb.ItemsSource))
//                    return source;

//                var composite = new CompositeCollection();
//                var container = new CollectionContainer() { Collection = source };

//                //when the allcombobx is editable and has multBinding
//                if (cmb.IsEditable && cmb.IsTextSearchEnabled && String.IsNullOrEmpty(cmb.DisplayMemberPath) &&
//                    String.IsNullOrEmpty(TextSearch.GetTextPath(cmb)) && cmb._itemTemplateBinding != null)
//                {
//                    //create wrapper databind objects
//                    var list = new List<DisplayObject>(source.Count());
//                    foreach (var item in container.Collection)
//                    {
//                        var display = GetDisplayValue(item, cmb._itemTemplateBinding);
//                        var wrapper = new DisplayObject(item, display);
//                        list.Add(wrapper);
//                    }
//                    container = new CollectionContainer { Collection = list };
//                    //set flag IsWapperByDisplayObject
//                    cmb.IsWapperByDisplayObject = true;
//                }
//                //create the all option if necessary.
//                if (cmb.HasAllOption)
//                {
//                    var all = new DisplayObject(null, cmb.AllText);
//                    composite.Add(all);
//                }
//                composite.Add(container);
//                //set the displayList
//                if (BindingOperations.GetBinding(cmb, DisplayListProperty) != null)
//                    cmb.DisplayList = GetDisplayList(composite, cmb.DisplayMemberPath);

//                return composite;
//            }

//            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//            {
//                return value;
//            }

//            private static string GetDisplayValue(object item, BindingBase bindingBase)
//            {
//                if (bindingBase is MultiBinding)
//                {
//                    var multiBinding = bindingBase as MultiBinding;
//                    object[] values = new object[multiBinding.Bindings.Count];
//                    for (int i = 0; i < multiBinding.Bindings.Count; i++)
//                    {
//                        var b = multiBinding.Bindings[i] as Binding;
//                        var v = item.GetPropertyValue(b.Path.Path);
//                        values[i] = v;
//                    }
//                    return multiBinding.Converter.Convert(values, null, null, null).ToString();
//                }
//                else
//                {
//                    var binding = bindingBase as Binding;
//                    return item.GetPropertyValue(binding.Path.Path).ToString();
//                }
//            }

//            private static IEnumerable<string> GetDisplayList(CompositeCollection collection, string displayMemberPath)
//            {
//                bool hasDisplayMemberPath = !displayMemberPath.IsNullOrEmpty();
//                foreach (var collectionItem in collection)
//                {
//                    if (collectionItem is CollectionContainer)
//                    {
//                        var container = collectionItem as CollectionContainer;
//                        if (container.Collection != null)
//                        {
//                            foreach (var item in container.Collection)
//                            {
//                                if (hasDisplayMemberPath)
//                                    yield return item.GetPropertyValue(displayMemberPath).ToString();
//                                else
//                                    yield return item.ToString();
//                            }
//                        }
//                    }
//                    else
//                    {
//                        yield return collectionItem.ToString();
//                    }
//                }
//            }
//        }


//        private class SelectedItemConverter : IValueConverter
//        {
//            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//            {
//                if (value == null)
//                    return value;
//                var cmb = parameter as AllComboBox;
//                if (cmb.IsWapperByDisplayObject && !cmb.ItemsSource.IsNullOrEmpty())
//                {
//                    foreach (var collectionItem in cmb.ItemsSource)
//                    {
//                        if (collectionItem is CollectionContainer)
//                        {
//                            var container = collectionItem as CollectionContainer;
//                            if (container.Collection != null)
//                            {
//                                foreach (DisplayObject displayObject in container.Collection)
//                                {
//                                    if (Equals(displayObject.Instance, value))
//                                        return displayObject;
//                                }
//                            }
//                        }
//                    }
//                }
//                return value;
//            }

//            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//            {
//                if (value == null)
//                    return value;
//                var displayObject = value as DisplayObject;
//                var cmb = parameter as AllComboBox;
//                //displayObject is null means that this is "All" item
//                if (displayObject == null)
//                {
//                    cmb.IsAll = false;
//                    return value;
//                }
//                //do not always set cmb.IsAll = displayObject.IsAll, it will cause stack over flow
//                if (cmb.IsAll != displayObject.IsAll)
//                    cmb.IsAll = displayObject.IsAll;
//                return displayObject.Instance;
//            }
//        }


//        /// <summary>
//        /// the wrapper class for UI display
//        /// </summary>
//        private class DisplayObject : DynamicObject
//        {
//            private string _tostring;
//            private string _firstBinderName;

//            public DisplayObject(object instance, string tostring)
//            {
//                Instance = instance;
//                _tostring = tostring;
//            }

//            public override bool TryGetMember(GetMemberBinder binder, out object result)
//            {
//                if (IsAll)
//                {
//                    //sometimes, converter will conver to "All Division- All Division" , so just return one "All Division"
//                    if (String.IsNullOrEmpty(_firstBinderName))
//                        _firstBinderName = binder.Name;

//                    result = binder.Name == _firstBinderName ? _tostring : null;
//                }
//                else
//                {
//                    result = Instance.GetPropertyValue(binder.Name);
//                }
//                return true;
//            }

//            public override bool TrySetMember(SetMemberBinder binder, object value)
//            {
//                if (IsAll)
//                    return false;

//                Instance.SetPropertyValue(binder.Name, value);
//                return true;
//            }

//            public object Instance
//            { get; private set; }

//            internal bool IsAll
//            { get { return Instance == null; } }

//            public override string ToString()
//            {
//                return _tostring;
//            }
//        }
//    }

//    /// <summary>
//        /// the wrapper class for UI display
//        /// </summary>
//        private class DisplayObject : DynamicObject
//        {
//            private string _tostring;
//            private string _firstBinderName;

//            public DisplayObject(object instance, string tostring)
//            {
//                Instance = instance;
//                _tostring = tostring;
//            }

//            public override bool TryGetMember(GetMemberBinder binder, out object result)
//            {
//                if (IsAll)
//                {
//                    //sometimes, converter will conver to "All Division- All Division" , so just return one "All Division"
//                    if (String.IsNullOrEmpty(_firstBinderName))
//                        _firstBinderName = binder.Name;

//                    result = binder.Name == _firstBinderName ? _tostring : null;
//                }
//                else
//                {
//                    result = Instance.GetPropertyValue(binder.Name);
//                }
//                return true;
//            }

//            public override bool TrySetMember(SetMemberBinder binder, object value)
//            {
//                if (IsAll)
//                    return false;

//                Instance.SetPropertyValue(binder.Name, value);
//                return true;
//            }

//            public object Instance
//            { get; private set; }

//            internal bool IsAll
//            { get { return Instance == null; } }

//            public override string ToString()
//            {
//                return _tostring;
//            }
//        }
//}


