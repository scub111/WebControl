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
    public partial class HMIFan : HMIBooleanBase
    {
        public HMIFan()
        {
            InitializeComponent();
            DataValueChanged += HMIFan_DataValueChanged;
        }

        private void HMIFan_ActualChanged(object sender, EventArgs e)
        {
            if (!Actual)
                StoryboardON.Stop();
        }

        void HMIFan_DataValueChanged(object sender, EventArgs e)
        {
            if (GetStateON(DataValue))
            {
                if (StoryboardON.GetCurrentState() != ClockState.Active)
                    StoryboardON.Begin();
            }
            else
                StoryboardON.Stop();
        }

        private void HMIFan_ItemInited(object sender, EventArgs e)
        {
            tbToolTip.Text = Item.Description;
        }
    }
}
