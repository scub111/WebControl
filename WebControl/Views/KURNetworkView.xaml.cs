using System.Windows;

namespace WebControl
{
    public partial class KURNetworkView : ViewBase
    {
        public KURNetworkView()
        {
            InitializeComponent();
        }

        private void btnNavNetworkView_Click(object sender, RoutedEventArgs e)
        {
            Global.Default.navPanNetwork.Activate();
        }
    }
}
