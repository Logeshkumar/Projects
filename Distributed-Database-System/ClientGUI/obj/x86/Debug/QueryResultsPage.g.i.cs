﻿#pragma checksum "..\..\..\QueryResultsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "25DBBA0B19F128721233FFB7CCD20679"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace edu.syr.cse784.eskimodb.ClientGUI {
    
    
    /// <summary>
    /// QueryResultsPage
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class QueryResultsPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\QueryResultsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox gb_QueryResults;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\QueryResultsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dg_QueryResults;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\QueryResultsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_RowsPerPage;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\QueryResultsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tb_RowsPerPage;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\QueryResultsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_PrevPage;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\QueryResultsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button b_NextPage;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\QueryResultsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GroupBox groupBox1;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\QueryResultsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox1;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\QueryResultsPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ClientGUI;component/queryresultspage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\QueryResultsPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 4 "..\..\..\QueryResultsPage.xaml"
            ((edu.syr.cse784.eskimodb.ClientGUI.QueryResultsPage)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.gb_QueryResults = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 3:
            this.dg_QueryResults = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.lbl_RowsPerPage = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.tb_RowsPerPage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.b_PrevPage = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\QueryResultsPage.xaml"
            this.b_PrevPage.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.b_PrevPage_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\QueryResultsPage.xaml"
            this.b_PrevPage.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.b_PrevPage_PreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.b_NextPage = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\QueryResultsPage.xaml"
            this.b_NextPage.PreviewMouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.b_NextPage_PreviewMouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\QueryResultsPage.xaml"
            this.b_NextPage.PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.b_NextPage_PreviewMouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 8:
            this.groupBox1 = ((System.Windows.Controls.GroupBox)(target));
            return;
            case 9:
            this.textBox1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.button1 = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

