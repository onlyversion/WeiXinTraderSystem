﻿#pragma checksum "..\..\ManagementMenu.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "807F0962F0C80F6E3B651B4F295A0FEE"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18063
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Gss.ManagementMenu.AccountManager;
using Gss.ManagementMenu.AccountManager.Clerk;
using Gss.ManagementMenu.AccountManager.Dealer;
using Gss.ManagementMenu.AccountManager.Org;
using Gss.ManagementMenu.Converter;
using Gss.ManagementMenu.CustomControl;
using Gss.ManagementMenu.DataManager;
using Gss.ManagementMenu.SystemSetting;
using Gss.ManagementMenu.TakeGoodsManager;
using Gss.ManagementMenu.TradeManager;
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


namespace Gss.ManagementMenu {
    
    
    /// <summary>
    /// ManagementMenu
    /// </summary>
    public partial class ManagementMenu : System.Windows.Controls.TreeView, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\ManagementMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Gss.ManagementMenu.CustomControl.GssTreeViewItem tvAccMgr;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\ManagementMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Gss.ManagementMenu.CustomControl.GssTreeViewItem tvTradeMgr;
        
        #line default
        #line hidden
        
        
        #line 215 "..\..\ManagementMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Gss.ManagementMenu.CustomControl.GssTreeViewItem tvSysSet;
        
        #line default
        #line hidden
        
        
        #line 218 "..\..\ManagementMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbSysSet;
        
        #line default
        #line hidden
        
        
        #line 319 "..\..\ManagementMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Gss.ManagementMenu.CustomControl.GssTreeViewItem tvDataMgr;
        
        #line default
        #line hidden
        
        
        #line 365 "..\..\ManagementMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Gss.ManagementMenu.CustomControl.GssTreeViewItem tvTakeGoodsAccept;
        
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
            System.Uri resourceLocater = new System.Uri("/Gss.ManagementMenu;component/managementmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ManagementMenu.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
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
            
            #line 12 "..\..\ManagementMenu.xaml"
            ((Gss.ManagementMenu.ManagementMenu)(target)).Loaded += new System.Windows.RoutedEventHandler(this.TreeView_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.tvAccMgr = ((Gss.ManagementMenu.CustomControl.GssTreeViewItem)(target));
            return;
            case 3:
            this.tvTradeMgr = ((Gss.ManagementMenu.CustomControl.GssTreeViewItem)(target));
            return;
            case 4:
            this.tvSysSet = ((Gss.ManagementMenu.CustomControl.GssTreeViewItem)(target));
            return;
            case 5:
            this.lbSysSet = ((System.Windows.Controls.ListBox)(target));
            return;
            case 6:
            this.tvDataMgr = ((Gss.ManagementMenu.CustomControl.GssTreeViewItem)(target));
            return;
            case 7:
            this.tvTakeGoodsAccept = ((Gss.ManagementMenu.CustomControl.GssTreeViewItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

