﻿#pragma checksum "..\..\..\..\Views\ExecutionWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FE249BAB57157B7AEC6211E70CEC70D4BA291CCB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace EasySaveV3._0.Views {
    
    
    /// <summary>
    /// ExecutionWindow
    /// </summary>
    public partial class ExecutionWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 86 "..\..\..\..\Views\ExecutionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lbResults;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\Views\ExecutionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPause;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\..\..\Views\ExecutionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnStop;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\Views\ExecutionWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCopyFiles;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EasySaveV3.0;component/views/executionwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\ExecutionWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lbResults = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.btnPause = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\..\Views\ExecutionWindow.xaml"
            this.btnPause.Click += new System.Windows.RoutedEventHandler(this.BtnPause_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnStop = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\..\..\Views\ExecutionWindow.xaml"
            this.btnStop.Click += new System.Windows.RoutedEventHandler(this.BtnStop_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnCopyFiles = ((System.Windows.Controls.Button)(target));
            
            #line 90 "..\..\..\..\Views\ExecutionWindow.xaml"
            this.btnCopyFiles.Click += new System.Windows.RoutedEventHandler(this.BtnCopyFiles_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

