﻿#pragma checksum "..\..\Findjob.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "835DB110110BB888974051BC1B6E9065"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Themes;
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
using kurscachWPF;


namespace kurscachWPF {
    
    
    /// <summary>
    /// Findjob
    /// </summary>
    public partial class Findjob : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\Findjob.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border MainBorder;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\Findjob.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Slogan;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\Findjob.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CBVacant;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\Findjob.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button YEAH;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\Findjob.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBSalary;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\Findjob.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border GRID;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\Findjob.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid GRIDREAL;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\Findjob.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SendWorker;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\Findjob.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Current;
        
        #line default
        #line hidden
        
        
        #line 146 "..\..\Findjob.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Admin;
        
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
            System.Uri resourceLocater = new System.Uri("/kurscachWPF;component/findjob.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Findjob.xaml"
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
            this.MainBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            
            #line 41 "..\..\Findjob.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Slogan = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.CBVacant = ((System.Windows.Controls.ComboBox)(target));
            
            #line 62 "..\..\Findjob.xaml"
            this.CBVacant.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.CBVacant_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 62 "..\..\Findjob.xaml"
            this.CBVacant.AddHandler(System.Windows.Controls.Primitives.TextBoxBase.TextChangedEvent, new System.Windows.Controls.TextChangedEventHandler(this.CBVacant_TextChanged));
            
            #line default
            #line hidden
            return;
            case 5:
            this.YEAH = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\Findjob.xaml"
            this.YEAH.Click += new System.Windows.RoutedEventHandler(this.YEAH_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TBSalary = ((System.Windows.Controls.TextBox)(target));
            
            #line 74 "..\..\Findjob.xaml"
            this.TBSalary.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TBSalary_TextChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.GRID = ((System.Windows.Controls.Border)(target));
            return;
            case 8:
            this.GRIDREAL = ((System.Windows.Controls.DataGrid)(target));
            
            #line 83 "..\..\Findjob.xaml"
            this.GRIDREAL.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.GRIDREAL_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.SendWorker = ((System.Windows.Controls.Button)(target));
            
            #line 136 "..\..\Findjob.xaml"
            this.SendWorker.Click += new System.Windows.RoutedEventHandler(this.SendWorker_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Current = ((System.Windows.Controls.TextBox)(target));
            return;
            case 11:
            this.Admin = ((System.Windows.Controls.Button)(target));
            
            #line 146 "..\..\Findjob.xaml"
            this.Admin.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

