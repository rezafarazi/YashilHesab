﻿#pragma checksum "..\..\Editwin.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3A5C5BFAE0F5F0D7DE8C031B494E52CF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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


namespace rest {
    
    
    /// <summary>
    /// Editwin
    /// </summary>
    public partial class Editwin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\Editwin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border mask;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Editwin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Editwin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox val;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Editwin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox name;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Editwin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox code;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\Editwin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ri;
        
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
            System.Uri resourceLocater = new System.Uri("/rest;component/editwin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Editwin.xaml"
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
            this.mask = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            
            #line 11 "..\..\Editwin.xaml"
            ((System.Windows.Controls.Image)(target)).PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Image_PreviewMouseLeftButtonUp_2);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 13 "..\..\Editwin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.combo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.val = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\Editwin.xaml"
            this.val.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus_1);
            
            #line default
            #line hidden
            
            #line 32 "..\..\Editwin.xaml"
            this.val.LostFocus += new System.Windows.RoutedEventHandler(this.val_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.name = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\Editwin.xaml"
            this.name.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus_1);
            
            #line default
            #line hidden
            
            #line 34 "..\..\Editwin.xaml"
            this.name.LostFocus += new System.Windows.RoutedEventHandler(this.name_LostFocus);
            
            #line default
            #line hidden
            return;
            case 7:
            this.code = ((System.Windows.Controls.TextBox)(target));
            
            #line 36 "..\..\Editwin.xaml"
            this.code.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus_1);
            
            #line default
            #line hidden
            
            #line 36 "..\..\Editwin.xaml"
            this.code.LostFocus += new System.Windows.RoutedEventHandler(this.code_LostFocus);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 42 "..\..\Editwin.xaml"
            ((System.Windows.Shapes.Rectangle)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Rectangle_MouseDown_1);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 43 "..\..\Editwin.xaml"
            ((System.Windows.Controls.Image)(target)).PreviewMouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Image_PreviewMouseLeftButtonUp_1);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ri = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

