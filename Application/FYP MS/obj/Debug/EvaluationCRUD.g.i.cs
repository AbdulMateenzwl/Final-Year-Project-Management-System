﻿#pragma checksum "..\..\EvaluationCRUD.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DEFF2ED440B41B218459237A8074A2D8950005B27E5D7E77BD02FCBB81110115"
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
    /// EvaluationCRUD
    /// </summary>
    public partial class EvaluationCRUD : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\EvaluationCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchBar;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\EvaluationCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clearTxt;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\EvaluationCRUD.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Grid;
        
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
            System.Uri resourceLocater = new System.Uri("/FYP MS;component/evaluationcrud.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EvaluationCRUD.xaml"
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
            
            #line 17 "..\..\EvaluationCRUD.xaml"
            this.SearchBar.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchBar_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.clearTxt = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\EvaluationCRUD.xaml"
            this.clearTxt.Click += new System.Windows.RoutedEventHandler(this.clearTxt_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 19 "..\..\EvaluationCRUD.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddEvlBtn);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 20 "..\..\EvaluationCRUD.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.UpdateEvlBtnClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Grid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 27 "..\..\EvaluationCRUD.xaml"
            this.Grid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.UpdateEvlBtnClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

