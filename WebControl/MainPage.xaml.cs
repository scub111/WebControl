using DevExpress.Xpf.Core;
using DevExpress.Xpf.Docking;
using DevExpress.Xpf.NavBar;
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

namespace WebControl
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            Global.Default.Init();
            ThemeManager.ApplicationTheme = Theme.VS2010;
            InitializeComponent();
        }
        
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.mainPanel.Closed = true;
            Global.Default.MainForm = this;

            Global.Default.ThreadMain.InterfaceChanged += ThreadMain_InterfaceChanged;

            Global.Default.DockManager = dockManager;
            Global.Default.DocumentContainer = documentContainer;
            
            NavigationWithPanal navPanAngidritZVGU2Ag1 = new NavigationWithPanal(navAngidritZVGU2Ag1, "AngidritZVGU2Ag1View", dockManager, documentContainer); navPanAngidritZVGU2Ag1.Activate();
            NavigationWithPanal navPanAngidritZVGU2Ag2 = new NavigationWithPanal(navAngidritZVGU2Ag2, "AngidritZVGU2Ag2View", dockManager, documentContainer); navPanAngidritZVGU2Ag2.Activate();
            NavigationWithPanal navPanAngidritHeater = new NavigationWithPanal(navAngidritHeater, "AngidritHeaterView", dockManager, documentContainer); navPanAngidritHeater.Activate();
            NavigationWithPanal navPanAngidritNPS1Hot = new NavigationWithPanal(navAngidritNPS1Hot, "AngidritNPS1HotView", dockManager, documentContainer); navPanAngidritNPS1Hot.Activate();
            NavigationWithPanal navPanAngidritNPS1Cold = new NavigationWithPanal(navAngidritNPS1Cold, "AngidritNPS1ColdView", dockManager, documentContainer); navPanAngidritNPS1Cold.Activate();
            NavigationWithPanal navPanAngidritNPS2Hot = new NavigationWithPanal(navAngidritNPS2Hot, "AngidritNPS2HotView", dockManager, documentContainer); navPanAngidritNPS2Hot.Activate();
            NavigationWithPanal navPanAngidritNPS2Cold = new NavigationWithPanal(navAngidritNPS2Cold, "AngidritNPS2ColdView", dockManager, documentContainer); navPanAngidritNPS2Cold.Activate();
            NavigationWithPanal navPanAngidritPumping = new NavigationWithPanal(navAngidritPumping, "AngidritPumpingView", dockManager, documentContainer); navPanAngidritPumping.Activate();
            NavigationWithPanal navPanAngidritVVU2Motor = new NavigationWithPanal(navAngidritVVU2Motor, "AngidritVVU2MotorView", dockManager, documentContainer); navPanAngidritVVU2Motor.Activate();
            NavigationWithPanal navPanAngidritVVU2Heater = new NavigationWithPanal(navAngidritVVU2Heater, "AngidritVVU2HeaterView", dockManager, documentContainer); navPanAngidritVVU2Heater.Activate();
            NavigationWithPanal navPanAngidritASOP = new NavigationWithPanal(navAngidritASOP, "AngidritASOPView", dockManager, documentContainer); navPanAngidritASOP.Activate();
            NavigationWithPanal navPanAngidritRP552 = new NavigationWithPanal(navAngidritRP552, "AngidritRP552View", dockManager, documentContainer); navPanAngidritRP552.Activate();
            NavigationWithPanal navPanAngidritRP553 = new NavigationWithPanal(navAngidritRP553, "AngidritRP553View", dockManager, documentContainer); navPanAngidritRP553.Activate();
            NavigationWithPanal navPanAngidritRP554 = new NavigationWithPanal(navAngidritRP554, "AngidritRP554View", dockManager, documentContainer); navPanAngidritRP554.Activate();
            NavigationWithPanal navPanAngidritMTB = new NavigationWithPanal(navAngidritMTB, "AngidritMTBView", dockManager, documentContainer); navPanAngidritMTB.Activate();
            NavigationWithPanal navPanServiceInfo = new NavigationWithPanal(navServiceInfo, "ServiceInfoView", dockManager, documentContainer); navPanServiceInfo.Activate();
            NavigationWithPanal navPanNetwork = new NavigationWithPanal(navNetwork, "NetworkView", dockManager, documentContainer); navPanNetwork.Activate();
            Global.Default.navPanDevelop = new NavigationWithPanal(navDevelop, "DevelopView", dockManager, documentContainer); //navPanDevelop.Activate();
            NavigationWithPanal navPanTest = new NavigationWithPanal(navTest, "TestView", dockManager, documentContainer); //navPanTest.Activate();
            NavigationWithPanal navPanAngidritCommon = new NavigationWithPanal(navAngidritCommon, "AngidritControlView", dockManager, documentContainer); navPanAngidritCommon.Activate();
            ShowStatusConnectionForm();
        }

        /// <summary>
        /// Панель окна статуса подключения.
        /// </summary>
        private DocumentPanel StatusConnectDocumentPanel;

        /// <summary>
        /// Окно статуса подключения.
        /// </summary>
        //private ConnectStatus ConnectStatusForm { get; set; }

        /// <summary>
        /// Показ формы состояния подключения к серверу.
        /// </summary>
        private void ShowStatusConnectionForm()
        {
            GlobalDefault.ShowForm(ref StatusConnectDocumentPanel, "Статус подключения к серверу", "/WebControl;component/Forms/ConnectStatus.xaml", new Size(250, 120), false);

            /*
            if (StatusConnectDocumentPanel == null)
            {
                Uri uri = new Uri("/WebControl;component/Forms/ConnectStatus.xaml", UriKind.Relative);
                StatusConnectDocumentPanel = dockManager.DockController.AddDocumentPanel(new Point(500, 500), new Size(250, 120), uri);
                StatusConnectDocumentPanel.Caption = "Статус подключения к серверу";
                //ConnectStatusForm = (ConnectStatus)StatusConnectDocumentPanel.Control;

                dockManager.Activate(StatusConnectDocumentPanel);
                dockManager.DockController.Float(StatusConnectDocumentPanel);
                //StatusConnectDocumentPanel.MDILocation = new Point(500, 500);
            }
            else
            {
                if (StatusConnectDocumentPanel.Closed)
                {
                    dockManager.DockController.Restore(StatusConnectDocumentPanel);
                    dockManager.Activate(StatusConnectDocumentPanel);
                }
            }
             */
        }

        void ThreadMain_InterfaceChanged(object sender, EventArgs e)
        {
            if (!Global.Default.ItemsUpdateSuccess)
                ShowStatusConnectionForm();
            else
                if (StatusConnectDocumentPanel != null)
                    StatusConnectDocumentPanel.Closed = true;

        }
    }
}
