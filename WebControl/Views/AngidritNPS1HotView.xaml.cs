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
    public partial class AngidritNPS1HotView : ViewBase
    {
        public AngidritNPS1HotView()
        {
            InitializeComponent();
            pump1.ValueONDelegete = new HMIBooleanBase.StatePosition(ValueOnFunc);
            pump2.ValueONDelegete = new HMIBooleanBase.StatePosition(ValueOnFunc);
            pump3.ValueONDelegete = new HMIBooleanBase.StatePosition(ValueOnFunc);
        }

        bool ValueOnFunc(HMIBooleanBase sender, double value)
        {
            if (-300 < value && value < 0)
                return true;
            else
                return false;
        }
    }
}
