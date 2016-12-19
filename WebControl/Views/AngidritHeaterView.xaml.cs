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
    public partial class AngidritHeaterView : ViewBase
    {
        public AngidritHeaterView()
        {
            InitializeComponent();
            heater1.ValueONDelegete = new HMIBooleanBase.StatePosition(ValueOnFunc);
            heater2.ValueONDelegete = new HMIBooleanBase.StatePosition(ValueOnFunc);
            heater3.ValueONDelegete = new HMIBooleanBase.StatePosition(ValueOnFunc);
            heater4.ValueONDelegete = new HMIBooleanBase.StatePosition(ValueOnFunc);
        }

        bool ValueOnFunc(HMIBooleanBase sender, double value)
        {
            if (-20 < value && value < 0)
                return true;
            else
                return false;
        }
    }
}
