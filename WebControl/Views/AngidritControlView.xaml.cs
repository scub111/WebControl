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
    public partial class AngidritContolView : ViewBase
    {
        public AngidritContolView()
        {
            InitializeComponent();
            hmiFanZVGU2Ag1.ValueOFFDelegete = FanValueOffFunc;
            hmiFanZVGU2Ag2.ValueOFFDelegete = FanValueOffFunc;
            heater1.ValueONDelegete = HeaterValueOnFunc;
            heater2.ValueONDelegete = HeaterValueOnFunc;
            heater3.ValueONDelegete = HeaterValueOnFunc;
            heater4.ValueONDelegete = HeaterValueOnFunc;
            pump1.ValueONDelegete = new HMIBooleanBase.StatePosition(PumpValueOnFunc);
            pump2.ValueONDelegete = new HMIBooleanBase.StatePosition(PumpValueOnFunc);
            pump3.ValueONDelegete = new HMIBooleanBase.StatePosition(PumpValueOnFunc);
            pump4.ValueONDelegete = new HMIBooleanBase.StatePosition(PumpValueOnFunc);
            pump5.ValueONDelegete = new HMIBooleanBase.StatePosition(PumpValueOnFunc);
            pump6.ValueONDelegete = new HMIBooleanBase.StatePosition(PumpValueOnFunc);
        }

        bool PumpValueOnFunc(HMIBooleanBase sender, double value)
        {
            if (-300 < value && value < 0)
                return true;
            else
                return false;
        }

        bool HeaterValueOnFunc(HMIBooleanBase sender, double value)
        {
            if (-20 < value && value < 0)
                return true;
            else
                return false;
        }

        bool FanValueOffFunc(HMIBooleanBase sender, double value)
        {
            if (value == 2 || value == 5)
                return true;
            else
                return false;
        }
    }
}
