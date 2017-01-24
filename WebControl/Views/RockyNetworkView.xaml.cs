using System.Windows;

namespace WebControl
{
    public partial class RockyNetworkView : ViewBase
    {
        public RockyNetworkView()
        {
            InitializeComponent();
        }

        private void btnNavNetworkView_Click(object sender, RoutedEventArgs e)
        {
            Global.Default.navPanNetwork.Activate();
        }
    }
}
