﻿#pragma checksum "..\..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6538C8959AA5E2B6508079753396C67C"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18063
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Gss.ManagementMenu;
using Gss.ManagementMenu.Converter;
using Gss.ManagementMenu.CustomControl;
using Gss.ProductInfoView;
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
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Controls;
using Xceed.Wpf.AvalonDock.Converters;
using Xceed.Wpf.AvalonDock.Layout;
using Xceed.Wpf.AvalonDock.Themes;


namespace JxSystem {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 107 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.TranslateTransform SampleBrowserTranslateTransform;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ScaleTransform RenderScale;
        
        #line default
        #line hidden
        
        
        #line 161 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Gss.ManagementMenu.ManagementMenu TvManager;
        
        #line default
        #line hidden
        
        
        #line 164 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.AvalonDock.Layout.LayoutDocumentPane DocumentPane;
        
        #line default
        #line hidden
        
        
        #line 165 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable MainContainer;
        
        #line default
        #line hidden
        
        
        #line 188 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border AccountInfoContainer;
        
        #line default
        #line hidden
        
        
        #line 196 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Path ArrowR1;
        
        #line default
        #line hidden
        
        
        #line 201 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Path ArrowR2;
        
        #line default
        #line hidden
        
        
        #line 207 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Gss.ManagementMenu.CustomControl.PopupButton PBtn;
        
        #line default
        #line hidden
        
        
        #line 209 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.UserControl UC_Accountcement;
        
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
            System.Uri resourceLocater = new System.Uri("/JxSystem;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
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
            
            #line 12 "..\..\..\MainWindow.xaml"
            ((JxSystem.MainWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 61 "..\..\..\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Executed_About);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 62 "..\..\..\MainWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CommandBinding_Executed_ModifyPassword);
            
            #line default
            #line hidden
            return;
            case 4:
            this.SampleBrowserTranslateTransform = ((System.Windows.Media.TranslateTransform)(target));
            return;
            case 5:
            this.RenderScale = ((System.Windows.Media.ScaleTransform)(target));
            return;
            case 6:
            this.TvManager = ((Gss.ManagementMenu.ManagementMenu)(target));
            
            #line 161 "..\..\..\MainWindow.xaml"
            this.TvManager.SelectedItemChanged += new System.Windows.RoutedPropertyChangedEventHandler<object>(this.TvManager_SelectedItemChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.DocumentPane = ((Xceed.Wpf.AvalonDock.Layout.LayoutDocumentPane)(target));
            return;
            case 8:
            this.MainContainer = ((Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable)(target));
            return;
            case 9:
            this.AccountInfoContainer = ((System.Windows.Controls.Border)(target));
            return;
            case 10:
            this.ArrowR1 = ((System.Windows.Shapes.Path)(target));
            return;
            case 11:
            this.ArrowR2 = ((System.Windows.Shapes.Path)(target));
            return;
            case 12:
            this.PBtn = ((Gss.ManagementMenu.CustomControl.PopupButton)(target));
            
            #line 207 "..\..\..\MainWindow.xaml"
            this.PBtn.Click += new System.Windows.RoutedEventHandler(this.PBtn_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.UC_Accountcement = ((System.Windows.Controls.UserControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

