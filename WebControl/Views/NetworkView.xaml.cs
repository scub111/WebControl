using System;
using System.Windows;

namespace WebControl
{
    public partial class NetworkView : ViewBase
    {
        public NetworkView()
        {
            InitializeComponent();
            Global.Default.ThreadMain.InterfaceChanged += ThreadMain_InterfaceChanged;
        }

        void ThreadMain_InterfaceChanged(object sender, EventArgs e)
        {
            teSqlTime.Text = Global.Default.SqlCurrentTime.ToString();
        }

        private void ViewBase_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void btnNavAdministrationNetworkView_Click(object sender, RoutedEventArgs e)
        {
            Global.Default.navPanAdministrationNetwork.Activate();
        }

        private void btnNavAngidritNetworkView_Click(object sender, RoutedEventArgs e)
        {
            Global.Default.navPanAngidritNetwork.Activate();
        }

        private void btnNavAngidritASUTPNetworkView_Click(object sender, RoutedEventArgs e)
        {
            Global.Default.navPanAngidritASUTPNetwork.Activate();
        }

        private void btnKayerkanskiyNetworkView_Click(object sender, RoutedEventArgs e)
        {
            Global.Default.navPanKayerkanskiyNetwork.Activate();
        }

        private void btnKURNetworkView_Click(object sender, RoutedEventArgs e)
        {
            Global.Default.navPanKURNetwork.Activate();
        }

        private void btnLimeNetworkView_Click(object sender, RoutedEventArgs e)
        {
            Global.Default.navPanLimeNetwork.Activate();
        }

        private void btnRockyNetworkView_Click(object sender, RoutedEventArgs e)
        {
            Global.Default.navPanRockyNetwork.Activate();
        }
    }
}
