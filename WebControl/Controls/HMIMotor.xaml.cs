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
    public partial class HMIPLC : HMIBooleanBase
    {
        public HMIPLC()
        {
            InitializeComponent();
        }

        private void HMIMotor_ItemInited(object sender, EventArgs e)
        {
            tbToolTip.Text = Item.Description;
        }

        private void HMIMotor_DataValueChanged(object sender, EventArgs e)
        {
            if (Item.DataValue == ValueON)
            {
                //if (StoryboardON.GetCurrentState() != ClockState.Active)
                    //StoryboardON.Begin();
            }
            else
            {
                //StoryboardON.Stop();
            }
        }
    }
}
