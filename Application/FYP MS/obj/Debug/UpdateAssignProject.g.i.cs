﻿#pragma checksum "..\..\UpdateAssignProject.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "15C1C3B055C90931E80456392D8458244EF8B4AF0C03E41B270203AFBE93C4BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FYP_MS;
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


namespace FYP_MS {
    
    
    /// <summary>
    /// UpdateAssignProject
    /// </summary>
    public partial class UpdateAssignProject : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\UpdateAssignProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBar;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\UpdateAssignProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseBtn;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\UpdateAssignProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AssignBtn;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\UpdateAssignProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ProjectGrid;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\UpdateAssignProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Datepicker;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\UpdateAssignProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchMainAdvbox;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\UpdateAssignProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid MainAdvGrid;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\UpdateAssignProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchCoAdvbox;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\UpdateAssignProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid coAdvGrid;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\UpdateAssignProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IndustryAdvSearchbox;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\UpdateAssignProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid IndAdvGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/FYP MS;component/updateassignproject.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UpdateAssignProject.xaml"
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
            this.SearchBar = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\UpdateAssignProject.xaml"
            this.SearchBar.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchBar_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 18 "..\..\UpdateAssignProject.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.CloseBtn = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\UpdateAssignProject.xaml"
            this.CloseBtn.Click += new System.Windows.RoutedEventHandler(this.CloseBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AssignBtn = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\UpdateAssignProject.xaml"
            this.AssignBtn.Click += new System.Windows.RoutedEventHandler(this.AssignBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ProjectGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 6:
            this.Datepicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.searchMainAdvbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 66 "..\..\UpdateAssignProject.xaml"
            this.searchMainAdvbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.searchMainAdvbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 67 "..\..\UpdateAssignProject.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 9:
            this.MainAdvGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.searchCoAdvbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 86 "..\..\UpdateAssignProject.xaml"
            this.searchCoAdvbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.searchCoAdvbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 87 "..\..\UpdateAssignProject.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 12:
            this.coAdvGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 13:
            this.IndustryAdvSearchbox = ((System.Windows.Controls.TextBox)(target));
            
            #line 106 "..\..\UpdateAssignProject.xaml"
            this.IndustryAdvSearchbox.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.IndustryAdvSearchbox_TextChanged);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 107 "..\..\UpdateAssignProject.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            case 15:
            this.IndAdvGrid = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

