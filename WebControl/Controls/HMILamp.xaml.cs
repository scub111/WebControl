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
    public partial class HMILamp : HMIBooleanBase
    {
        public HMILamp()
        {   
            InitializeComponent();            
        }

        public override Color ColorON
        {
            get
            {
                return (Color)((ColorAnimation)ControlValueON.Storyboard.Children[1]).To;
            }
            set
            {
                ((ColorAnimation)ControlValueON.Storyboard.Children[1]).To = value;
            }
        }

        public override Color ColorOFF
        {
            get
            {
                return ((RadialGradientBrush)elBase.Fill).GradientStops[0].Color;
            }
            set
            {
                ((RadialGradientBrush)elBase.Fill).GradientStops[0].Color = value;
            }
        }

        private void HMILamp_ItemInited(object sender, EventArgs e)
        {
            tbToolTip.Text = Item.Description;
        }
    }
}
