using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using WebControl.DataServiceReference;

namespace WebControl
{
    public partial class DevelopView : ViewBase
    {
        public DevelopView()
        {
            InitializeComponent();
            DataClient = Global.Default.CreateDataClient();
            DataClient.GetServiceInfoCompleted += DataClient_GetServiceInfoCompleted;
        }


        private void ViewBase_Loaded(object sender, RoutedEventArgs e)
        {
            Global.Default.ThreadMain.InterfaceChanged += ThreadMain_InterfaceChanged;
            teVersion.Content = Global.Default.Version;
            teServerIPAddress.Content = Application.Current.Host.Source.Host;
            ThreadMain_InterfaceChanged(null, null);
            teServiceAddress.Content = Global.Default.WCFEndpointAddress;
            teServiceAddress.NavigateUri = new Uri(Global.Default.WCFEndpointAddress);
            teClientIPAddress.Content = Global.Default.ClientIPAddress;
            teClientGetClientGUID.Content = Global.Default.ClientGUID;
            teClientBrowserInformation.Content = Global.Default.ClientBrowserInformation;
        }

        DataServiceClient DataClient { get; set; }

        void ThreadMain_InterfaceChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                try
                {
                    teServerTime.Content = Global.Default.SqlCurrentTime;
                    teLastUpdateTime.Content = Global.Default.ItemUpdateTime;
                    teServerClientTimeDiff.Content = Global.Default.ServerClientTimeDiff;
                    teTimeZoneDiff.Content = Global.Default.ServerClientTimeZoneDiff;
                    if (Global.Default.ItemsReal.Count > 0)
                        teFirst.Content = Global.Default.ItemsReal[0].SqlTime;
                    teError.Content = string.Format("{0}, {1}", Global.Default.InitFaultCount, Global.Default.UpdatFaultCount);
                    teItemCount.Content = Global.Default.ItemsReal.Count;
                    teLoadTime.Content = string.Format("{0} мс / {1} мс", Global.Default.LoadTime.TotalMilliseconds, Global.Default.ShortUpdateTime.TotalMilliseconds);
                    teGUI.Content = string.Format("{0}", Global.Default.ItemsRealActivatedCount);
                    teServerItemUpdateSync.Content = string.Format("{0} / {1} мс", Global.Default.ServerItemUpdateTime, Global.Default.ItemUpdateTimeDiff.TotalMilliseconds);
                    DataClient.GetServiceInfoAsync();
                }
                catch
                {
                }
            }
        }

        void DataClient_GetServiceInfoCompleted(object sender, GetServiceInfoCompletedEventArgs e)
        {
            if (e.Error == null)
                teServiceInfo.Content = e.Result;
        }
    }
}
