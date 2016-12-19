using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.Core;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //if (App.Current.HasElevatedPermissions)
                //{
                //for notepad
                //dynamic notepad = AutomationFactory.CreateObject("WScript.shell");
                //notepad.Run(@"C:\WINDOWS\NOTEPAD.EXE");
                ThemeManager.ApplicationTheme = Theme.VS2010;


                //}
                //else
                //{
                //    MessageBox.Show("Нет разрешений");
                //}

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
