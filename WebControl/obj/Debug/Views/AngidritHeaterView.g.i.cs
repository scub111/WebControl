﻿#pragma checksum "D:\Мои документы\!Projects\WebControl\WebControl\Views\AngidritHeaterView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E822AE85B7EB2B1B53E8618A5AD8E41C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.18063
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
    
    
    public partial class AngidritHeaterView : WebControl.ViewBase {
        
        internal System.Windows.Controls.Canvas LayoutRoot;
        
        internal WebControl.HMIFan heater1;
        
        internal WebControl.HMIFan heater2;
        
        internal WebControl.HMIFan heater3;
        
        internal WebControl.HMIFan heater4;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/WebControl;component/Views/AngidritHeaterView.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Canvas)(this.FindName("LayoutRoot")));
            this.heater1 = ((WebControl.HMIFan)(this.FindName("heater1")));
            this.heater2 = ((WebControl.HMIFan)(this.FindName("heater2")));
            this.heater3 = ((WebControl.HMIFan)(this.FindName("heater3")));
            this.heater4 = ((WebControl.HMIFan)(this.FindName("heater4")));
        }
    }
}

