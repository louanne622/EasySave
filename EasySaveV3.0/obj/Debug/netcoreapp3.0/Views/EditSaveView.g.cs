﻿#pragma checksum "..\..\..\..\Views\EditSaveView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74C25C06BAEAEDB0A9B1BB2E050CACC9F5F88B87"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using EasySaveV3._0;
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
    /// EditSaveView
    /// </summary>
    public partial class EditSaveView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\..\..\Views\EditSaveView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBackupName;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Views\EditSaveView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button browseButtonSource;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Views\EditSaveView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox selectedPathSource;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Views\EditSaveView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button browseButtonTarget;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Views\EditSaveView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox selectedPathTarget;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\..\..\Views\EditSaveView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtBackupType;
        
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
            System.Uri resourceLocater = new System.Uri("/EasySaveV3.0;component/views/editsaveview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\EditSaveView.xaml"
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
            this.txtBackupName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.browseButtonSource = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\..\Views\EditSaveView.xaml"
            this.browseButtonSource.Click += new System.Windows.RoutedEventHandler(this.OnBrowseButtonClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.selectedPathSource = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.browseButtonTarget = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\..\Views\EditSaveView.xaml"
            this.browseButtonTarget.Click += new System.Windows.RoutedEventHandler(this.OnBrowseButtonClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.selectedPathTarget = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.txtBackupType = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

