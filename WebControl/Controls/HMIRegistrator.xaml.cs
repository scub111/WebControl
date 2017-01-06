using System;
using System.Collections.Generic;
using System.Linq;

namespace WebControl
{
    public partial class HMIRegistrator : HMIBooleanBase
    {
        public HMIRegistrator()
        {
            InitializeComponent();
        }

        private void HMIComputer_ItemInited(object sender, EventArgs e)
        {
            tbToolTip.Text = Item.Description;
        }
    }
}
