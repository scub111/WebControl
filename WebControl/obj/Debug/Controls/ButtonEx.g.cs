﻿#pragma checksum "D:\_Projects\WebControl\WebControl\Controls\ButtonEx.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1E028DA7C06E3BFEDC2A191E6868377D"
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
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;
using WebControl;


namespace WebControl {
    
    
    public partial class ButtonEx : WebControl.UserControlEx {
        
        internal WebControl.UserControlEx ButtonEx1;
        
        internal System.Windows.Controls.TextBlock tbToolTip;
        
        internal System.Windows.VisualStateGroup MouseStateGroup;
        
        internal System.Windows.VisualState ControlMouseEnter;
        
        internal System.Windows.VisualState ControlMouseLeave;
        
        internal System.Windows.VisualStateGroup VisualStateGroup;
        
        internal System.Windows.VisualState ControlMouseDown;
        
        internal System.Windows.VisualState ControlMouseUp;
        
        internal System.Windows.Shapes.Rectangle recMouse;
        
        internal System.Windows.Controls.Viewbox vwWarning;
        
        internal System.Windows.Controls.Image imgBase;
        
        internal System.Windows.Controls.TextBlock tbCaption;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/WebControl;component/Controls/ButtonEx.xaml", System.UriKind.Relative));
            this.ButtonEx1 = ((WebControl.UserControlEx)(this.FindName("ButtonEx1")));
            this.tbToolTip = ((System.Windows.Controls.TextBlock)(this.FindName("tbToolTip")));
            this.MouseStateGroup = ((System.Windows.VisualStateGroup)(this.FindName("MouseStateGroup")));
            this.ControlMouseEnter = ((System.Windows.VisualState)(this.FindName("ControlMouseEnter")));
            this.ControlMouseLeave = ((System.Windows.VisualState)(this.FindName("ControlMouseLeave")));
            this.VisualStateGroup = ((System.Windows.VisualStateGroup)(this.FindName("VisualStateGroup")));
            this.ControlMouseDown = ((System.Windows.VisualState)(this.FindName("ControlMouseDown")));
            this.ControlMouseUp = ((System.Windows.VisualState)(this.FindName("ControlMouseUp")));
            this.recMouse = ((System.Windows.Shapes.Rectangle)(this.FindName("recMouse")));
            this.vwWarning = ((System.Windows.Controls.Viewbox)(this.FindName("vwWarning")));
            this.imgBase = ((System.Windows.Controls.Image)(this.FindName("imgBase")));
            this.tbCaption = ((System.Windows.Controls.TextBlock)(this.FindName("tbCaption")));
        }
    }
}

