using System;
using System.Collections.Generic;
using System.Linq;

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
