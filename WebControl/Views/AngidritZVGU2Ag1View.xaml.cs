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
using System.Windows.Navigation;

namespace WebControl
{
    public partial class AngidritZVGU2Ag1View : ViewBase
    {
        public AngidritZVGU2Ag1View()
        {
            InitializeComponent();
            this.hmiVFD1.ValueOFFDelegete = ValueOffFunc;
            this.hmiFan1.ValueOFFDelegete = ValueOffFunc;
            this.hmiMotor1.ValueOFFDelegete = ValueOffFunc;
        }


        bool ValueOffFunc(HMIBooleanBase sender, double value)
        {
            if (value == 2 || value == 5)
                return true;
            else
                return false;
        }
    }
}
