using System.Windows;

namespace WebControl
{
    public partial class AdministrationNetworkView : ViewBase
    {
        public AdministrationNetworkView()
        {
            InitializeComponent();
        }

        private void btnNavNetworkView_Click(object sender, RoutedEventArgs e)
        {
            Global.Default.navPanNetwork.Activate();
        }
    }
}
