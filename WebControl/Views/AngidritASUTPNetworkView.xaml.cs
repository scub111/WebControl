using System.Windows;

namespace WebControl
{
    public partial class AngidritASUTPNetworkView : ViewBase
    {
        public AngidritASUTPNetworkView()
        {
            InitializeComponent();
        }
        
        private void btnNavNetworkView_Click(object sender, RoutedEventArgs e)
        {
            Global.Default.navPanNetwork.Activate();
        }
    }
}
