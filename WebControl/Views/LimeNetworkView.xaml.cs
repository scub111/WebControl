using System.Windows;

namespace WebControl
{
    public partial class LimeNetworkView : ViewBase
    {
        public LimeNetworkView()
        {
            InitializeComponent();
        }

        private void btnNavNetworkView_Click(object sender, RoutedEventArgs e)
        {
            Global.Default.navPanNetwork.Activate();
        }
    }
}
