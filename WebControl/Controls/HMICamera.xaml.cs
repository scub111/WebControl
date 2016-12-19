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
    public partial class HMICamera : HMIBooleanBase
    {
        public HMICamera()
        {
            InitializeComponent();
        }

        private void HMICamera_ItemInited(object sender, EventArgs e)
        {
            tbToolTip.Text = Item.Description;
        }
    }
}
