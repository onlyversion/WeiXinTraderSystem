﻿#pragma checksum "..\..\..\CustomControl\AutoComboBox.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E2D834CADA3DBF78EACA4CA85BB1B672"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18063
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Gss.ManagementMenu.CustomControl;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Gss.ManagementMenu.CustomControl {
    
    
    /// <summary>
    /// AutoComboBox
    /// </summary>
    public partial class AutoComboBox : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\CustomControl\AutoComboBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Gss.ManagementMenu.CustomControl.AutoComboBox UserC;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\CustomControl\AutoComboBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border borderRoot;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\CustomControl\AutoComboBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Tbx;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\CustomControl\AutoComboBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton Btn_Search;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\CustomControl\AutoComboBox.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Lst;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Gss.ManagementMenu;component/customcontrol/autocombobox.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CustomControl\AutoComboBox.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UserC = ((Gss.ManagementMenu.CustomControl.AutoComboBox)(target));
            return;
            case 2:
            this.borderRoot = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.Tbx = ((System.Windows.Controls.TextBox)(target));
            
            #line 39 "..\..\..\CustomControl\AutoComboBox.xaml"
            this.Tbx.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Tbx_TextChanged);
            
            #line default
            #line hidden
            
            #line 39 "..\..\..\CustomControl\AutoComboBox.xaml"
            this.Tbx.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Tbx_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Btn_Search = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 41 "..\..\..\CustomControl\AutoComboBox.xaml"
            this.Btn_Search.Click += new System.Windows.RoutedEventHandler(this.Btn_Search_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Lst = ((System.Windows.Controls.ListBox)(target));
            
            #line 52 "..\..\..\CustomControl\AutoComboBox.xaml"
            this.Lst.MouseLeave += new System.Windows.Input.MouseEventHandler(this.UserC_MouseLeave);
            
            #line default
            #line hidden
            
            #line 52 "..\..\..\CustomControl\AutoComboBox.xaml"
            this.Lst.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.Lst_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 52 "..\..\..\CustomControl\AutoComboBox.xaml"
            this.Lst.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Lst_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

