﻿#pragma checksum "D:\_Projects\WebControl\WebControl\Views\AngidritMTBView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E98E0614FC2C47D9DB690B933BCE455D"
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
    
    
    public partial class AngidritMTBView : WebControl.ViewBase {
        
        internal System.Windows.Controls.Canvas LayoutRoot;
        
        internal DevExpress.Xpf.Grid.GridControl gridControl;
        
        internal System.Windows.Controls.Button btnStartPause;
        
        internal System.Windows.Controls.TextBlock tbToolTipStartPause;
        
        internal System.Windows.Controls.Image imgStartPause;
        
        internal DevExpress.Xpf.Editors.DateEdit deBegin;
        
        internal DevExpress.Xpf.Editors.DateEdit deEnd;
        
        internal System.Windows.Controls.Button btnUpdate;
        
        internal System.Windows.Controls.TextBlock tbToolTipUpdate;
        
        internal System.Windows.Controls.Button btnBack;
        
        internal System.Windows.Controls.TextBlock tbToolTipBack;
        
        internal System.Windows.Controls.Button btnForward;
        
        internal System.Windows.Controls.TextBlock tbToolTipForward;
        
        internal System.Windows.Controls.Button btnExport;
        
        internal System.Windows.Controls.TextBlock tbToolTipForward1;
        
        internal WebControl.CheckUpdateLabel ckUpdate;
        
        internal System.Windows.Controls.TextBlock lblStatus;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/WebControl;component/Views/AngidritMTBView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Canvas)(this.FindName("LayoutRoot")));
            this.gridControl = ((DevExpress.Xpf.Grid.GridControl)(this.FindName("gridControl")));
            this.btnStartPause = ((System.Windows.Controls.Button)(this.FindName("btnStartPause")));
            this.tbToolTipStartPause = ((System.Windows.Controls.TextBlock)(this.FindName("tbToolTipStartPause")));
            this.imgStartPause = ((System.Windows.Controls.Image)(this.FindName("imgStartPause")));
            this.deBegin = ((DevExpress.Xpf.Editors.DateEdit)(this.FindName("deBegin")));
            this.deEnd = ((DevExpress.Xpf.Editors.DateEdit)(this.FindName("deEnd")));
            this.btnUpdate = ((System.Windows.Controls.Button)(this.FindName("btnUpdate")));
            this.tbToolTipUpdate = ((System.Windows.Controls.TextBlock)(this.FindName("tbToolTipUpdate")));
            this.btnBack = ((System.Windows.Controls.Button)(this.FindName("btnBack")));
            this.tbToolTipBack = ((System.Windows.Controls.TextBlock)(this.FindName("tbToolTipBack")));
            this.btnForward = ((System.Windows.Controls.Button)(this.FindName("btnForward")));
            this.tbToolTipForward = ((System.Windows.Controls.TextBlock)(this.FindName("tbToolTipForward")));
            this.btnExport = ((System.Windows.Controls.Button)(this.FindName("btnExport")));
            this.tbToolTipForward1 = ((System.Windows.Controls.TextBlock)(this.FindName("tbToolTipForward1")));
            this.ckUpdate = ((WebControl.CheckUpdateLabel)(this.FindName("ckUpdate")));
            this.lblStatus = ((System.Windows.Controls.TextBlock)(this.FindName("lblStatus")));
        }
    }
}

