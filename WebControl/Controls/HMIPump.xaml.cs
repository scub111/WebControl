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
    public partial class HMIPump : HMIBooleanBase
    {
        public HMIPump()
        {
            InitializeComponent();
            DataValueChanged += HMIPump_DataValueChanged;
        }

        void HMIPump_DataValueChanged(object sender, EventArgs e)
        {
            if (GetStateON(DataValue))
            {
                if (StoryboardON1.GetCurrentState() != ClockState.Active)
                    StoryboardON1.Begin();
            }
            else
                StoryboardON1.Stop();
        }

        /// <summary>
        /// Контекстное меню.
        /// </summary>
        ContextMenu cMenu { get; set; }

        /// <summary>
        /// Элемент контекстного меню.
        /// </summary>
        MenuItem menuItem { get; set; }

        private void HMIBase_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            cMenu = new ContextMenu();

            menuItem = new MenuItem();
            menuItem.Header = "Test";
            cMenu.Items.Add(menuItem);
            menuItem.Click += menuItem_Click;

            cMenu.IsOpen = true;
            //cMenu.HorizontalOffset = e.GetPosition().X;
        }

        void menuItem_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void HMIFan_ItemInited(object sender, EventArgs e)
        {
            tbToolTip.Text = Item.Description;
        }
    }
}
