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
using System.Windows.Navigation;

namespace WebControl
{
    public partial class ConnectStatus : UserControlEx
    {
        public ConnectStatus()
        {
            InitializeComponent();
            Loaded += ConnectStatus_Loaded;
            Global.Default.DateTimeSynchronized += Default_DateTimeSynchronized;
            Global.Default.DateTimeOffsetSynchronized += Default_DateTimeOffsetSynchronized;
            Global.Default.ItemsUpdated += Default_ItemsUpdated;
            Global.Default.ThreadMain.InterfaceChanged += ThreadMain_InterfaceChanged;
        }

        void UpdateInterface()
        {
            if (Visible)
            {
                try
                {
                    teVersion.Text = Global.Default.Version;
                    ceDateTimeSyncSuccess.Checked = Global.Default.DateTimeSyncSuccess;
                    ceDateTimeSyncOffsetSuccess.Checked = Global.Default.DateTimeOffsetSyncSuccess;
                    ceItemUpdateSuccess.Checked = Global.Default.ItemsUpdateSuccess;
                }
                catch
                {
                }
            }
        }

        void ThreadMain_InterfaceChanged(object sender, EventArgs e)
        {
            UpdateInterface();
        }

        void ConnectStatus_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateInterface();
        }

        void Default_DateTimeSynchronized(object sender, EventArgs e)
        {
            if (Visible)
                ceDateTimeSyncSuccess.Checked = Global.Default.DateTimeSyncSuccess;
        }

        void Default_DateTimeOffsetSynchronized(object sender, EventArgs e)
        {
            if (Visible)
                ceDateTimeSyncOffsetSuccess.Checked = Global.Default.DateTimeOffsetSyncSuccess;
        }

        void Default_ItemsUpdated(object sender, EventArgs e)
        {
            if (Visible)
                ceItemUpdateSuccess.Checked = Global.Default.ItemsUpdateSuccess;
        }
    }
}
