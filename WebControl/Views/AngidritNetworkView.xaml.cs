using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.Core;

namespace WebControl
{
    public partial class AngidritNetworkView : ViewBase
    {
        public AngidritNetworkView()
        {
            InitializeComponent();
            Global.Default.ThreadMain.InterfaceChanged += ThreadMain_InterfaceChanged;
        }

        void ThreadMain_InterfaceChanged(object sender, EventArgs e)
        {
        }

        private void ViewBase_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnNavNetworkView_Click(object sender, RoutedEventArgs e)
        {
            Global.Default.navPanNetwork.Activate();
        }
    }
}
