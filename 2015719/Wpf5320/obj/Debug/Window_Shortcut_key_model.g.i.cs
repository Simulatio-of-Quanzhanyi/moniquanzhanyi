﻿#pragma checksum "..\..\Window_Shortcut_key_model.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9981555BE1431113B826F4E5C6D0EB2A"
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
    /// Window_Shortcut_key_model
    /// </summary>
    public partial class Window_Shortcut_key_model : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\Window_Shortcut_key_model.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bt_exit;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Window_Shortcut_key_model.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label systime;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Window_Shortcut_key_model.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Window_Shortcut_key_model.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ensure;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Window_Shortcut_key_model.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ESC;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Window_Shortcut_key_model.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bt_enter;
        
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
            System.Uri resourceLocater = new System.Uri("/Wpf5320;component/window_shortcut_key_model.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window_Shortcut_key_model.xaml"
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
            this.Bt_exit = ((System.Windows.Controls.Button)(target));
            
            #line 7 "..\..\Window_Shortcut_key_model.xaml"
            this.Bt_exit.Click += new System.Windows.RoutedEventHandler(this.Bt_exit_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.systime = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\Window_Shortcut_key_model.xaml"
            this.Cancel.Click += new System.Windows.RoutedEventHandler(this.ESC_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Ensure = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\Window_Shortcut_key_model.xaml"
            this.Ensure.Click += new System.Windows.RoutedEventHandler(this.Bt_enter_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ESC = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\Window_Shortcut_key_model.xaml"
            this.ESC.Click += new System.Windows.RoutedEventHandler(this.ESC_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Bt_enter = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Window_Shortcut_key_model.xaml"
            this.Bt_enter.Click += new System.Windows.RoutedEventHandler(this.Bt_enter_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

