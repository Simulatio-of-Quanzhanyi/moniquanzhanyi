﻿#pragma checksum "..\..\Window_Road4_ChuiZhiDingXian.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8D179E82B9F2FB86AB8960EAFBB05F91"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18408
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
    /// Window_Road4
    /// </summary>
    public partial class Window_Road4 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\Window_Road4_ChuiZhiDingXian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ADD;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Window_Road4_ChuiZhiDingXian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button edit;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Window_Road4_ChuiZhiDingXian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label systime;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\Window_Road4_ChuiZhiDingXian.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ESC;
        
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
            System.Uri resourceLocater = new System.Uri("/Wpf5320;component/window_road4_chuizhidingxian.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window_Road4_ChuiZhiDingXian.xaml"
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
            
            #line 4 "..\..\Window_Road4_ChuiZhiDingXian.xaml"
            ((Wpf5320.Window_Road4)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ADD = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\Window_Road4_ChuiZhiDingXian.xaml"
            this.ADD.Click += new System.Windows.RoutedEventHandler(this.ADD_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.edit = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\Window_Road4_ChuiZhiDingXian.xaml"
            this.edit.Click += new System.Windows.RoutedEventHandler(this.edit_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.systime = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.ESC = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\Window_Road4_ChuiZhiDingXian.xaml"
            this.ESC.Click += new System.Windows.RoutedEventHandler(this.ESC_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

