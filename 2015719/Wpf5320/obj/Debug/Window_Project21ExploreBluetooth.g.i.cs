﻿#pragma checksum "..\..\Window_Project21ExploreBluetooth.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2CFE02E4363FF4ADA202751C30251818"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
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
    /// Window_Project21
    /// </summary>
    public partial class Window_Project21 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\Window_Project21ExploreBluetooth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button bt_DaoChu;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\Window_Project21ExploreBluetooth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Return;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Window_Project21ExploreBluetooth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label systime;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Window_Project21ExploreBluetooth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ESC;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Window_Project21ExploreBluetooth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Bt_Power;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Window_Project21ExploreBluetooth.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\Window_Project21ExploreBluetooth.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Wpf5320;component/window_project21explorebluetooth.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window_Project21ExploreBluetooth.xaml"
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
            
            #line 4 "..\..\Window_Project21ExploreBluetooth.xaml"
            ((Wpf5320.Window_Project21)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.bt_DaoChu = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\Window_Project21ExploreBluetooth.xaml"
            this.bt_DaoChu.Click += new System.Windows.RoutedEventHandler(this.DaoChu_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Return = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\Window_Project21ExploreBluetooth.xaml"
            this.Return.Click += new System.Windows.RoutedEventHandler(this.Return_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.systime = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.ESC = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\Window_Project21ExploreBluetooth.xaml"
            this.ESC.Click += new System.Windows.RoutedEventHandler(this.ESC_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Bt_Power = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\Window_Project21ExploreBluetooth.xaml"
            this.Bt_Power.Click += new System.Windows.RoutedEventHandler(this.Bt_Power_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\Window_Project21ExploreBluetooth.xaml"
            this.Cancel.Click += new System.Windows.RoutedEventHandler(this.Return_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Ensure = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\Window_Project21ExploreBluetooth.xaml"
            this.Ensure.Click += new System.Windows.RoutedEventHandler(this.DaoChu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

