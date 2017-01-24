using System.Windows;

namespace WebControl
{
    public partial class KayerkanskiyNetworkView : ViewBase
    {
        public KayerkanskiyNetworkView()
        {
            InitializeComponent();
        }

        private void btnNavNetworkView_Click(object sender, RoutedEventArgs e)
        {
            Global.Default.navPanNetwork.Activate();
        }
    }
}
