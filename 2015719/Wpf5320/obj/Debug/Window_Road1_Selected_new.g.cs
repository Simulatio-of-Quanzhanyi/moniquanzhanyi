﻿#pragma checksum "..\..\Window_Road1_Selected_new.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2A33C05381DB9160B9CE8432CE47FB56"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18449
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
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


namespace Wpf5320 {
    
    
    /// <summary>
    /// Window_Road1_Selected_new
    /// </summary>
    public partial class Window_Road1_Selected_new : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\Window_Road1_Selected_new.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label systime;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Window_Road1_Selected_new.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbItemName;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Window_Road1_Selected_new.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ESC;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Window_Road1_Selected_new.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\Window_Road1_Selected_new.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ensure;
        
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
            System.Uri resourceLocater = new System.Uri("/Wpf5320;component/window_road1_selected_new.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window_Road1_Selected_new.xaml"
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
            
            #line 4 "..\..\Window_Road1_Selected_new.xaml"
            ((Wpf5320.Window_Road1_Selected_new)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.systime = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.tbItemName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.ESC = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\Window_Road1_Selected_new.xaml"
            this.ESC.Click += new System.Windows.RoutedEventHandler(this.ESC_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Window_Road1_Selected_new.xaml"
            this.Cancel.Click += new System.Windows.RoutedEventHandler(this.ESC_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Ensure = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

