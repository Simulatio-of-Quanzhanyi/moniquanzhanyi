﻿#pragma checksum "..\..\Window_Project14_SaveAs.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8C45ED0957A981B801B82490B9C47B2B"
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
using Wpf5320;


namespace Wpf5320 {
    
    
    /// <summary>
    /// Window_Project14
    /// </summary>
    public partial class Window_Project14 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Window_Project14_SaveAs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TbFileName;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\Window_Project14_SaveAs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label systime;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Window_Project14_SaveAs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\Window_Project14_SaveAs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ensure;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\Window_Project14_SaveAs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf5320.keyboard keyboard;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Window_Project14_SaveAs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button softkeyboard;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Window_Project14_SaveAs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Wpf5320.softKey softKey;
        
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
            System.Uri resourceLocater = new System.Uri("/Wpf5320;component/window_project14_saveas.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window_Project14_SaveAs.xaml"
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
            
            #line 5 "..\..\Window_Project14_SaveAs.xaml"
            ((Wpf5320.Window_Project14)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown_1);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TbFileName = ((System.Windows.Controls.TextBox)(target));
            
            #line 12 "..\..\Window_Project14_SaveAs.xaml"
            this.TbFileName.GotFocus += new System.Windows.RoutedEventHandler(this.TbFileName_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.systime = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\Window_Project14_SaveAs.xaml"
            this.Cancel.Click += new System.Windows.RoutedEventHandler(this.ESCkey_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Ensure = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\Window_Project14_SaveAs.xaml"
            this.Ensure.Click += new System.Windows.RoutedEventHandler(this.ENTkey_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.keyboard = ((Wpf5320.keyboard)(target));
            return;
            case 7:
            this.softkeyboard = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\Window_Project14_SaveAs.xaml"
            this.softkeyboard.Click += new System.Windows.RoutedEventHandler(this.softkeyboard_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.softKey = ((Wpf5320.softKey)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

