using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Windows.Media.Animation;
using DevExpress.Xpf.Docking;

namespace WebControl
{
    /// <summary>
    /// Interaction logic for HMILabel.xaml
    /// </summary>
    public partial class HMILabelBoolean : HMIBooleanBase 
    {
        public HMILabelBoolean()
        {
            InitializeComponent();
            TextUnknown = "???";
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
                return (Color)((ColorAnimation)ControlValueOFF.Storyboard.Children[1]).To;
            }
            set
            {
                ((ColorAnimation)ControlValueOFF.Storyboard.Children[1]).To = value;
            }
        }

        /// <summary>
        /// Размер шрифта.
        /// </summary>
        public double CaptionFontSize
        {
            get { return txtCaption.FontSize; }
            set { txtCaption.FontSize = value; }
        }

        /// <summary>
        /// Радиус скругления.
        /// </summary>
        public double RectangleRadius
        {
            get { return recMouse.RadiusX; }
            set { recMouse.RadiusX = recMouse.RadiusY = value; }
        }

        /// <summary>
        /// Текст для включенного состояния.
        /// </summary>
        public string TextON { get; set; }

        /// <summary>
        /// Текст для выключенного состояния.
        /// </summary>
        public string TextOFF { get; set; }

        /// <summary>
        /// Текст для неизвестного состояния.
        /// </summary>
        public string TextUnknown { get; set; }

        private void HMILabelBoolean_DataValueChanged(object sender, EventArgs e)
        {
            if (GetStateON(DataValue))
                txtCaption.Text = TextON;
            if (GetStateOFF(DataValue))
                txtCaption.Text = TextOFF;
            if (GetStateUnknown(DataValue))
                txtCaption.Text = TextUnknown;
        }

        private void HMILabelBoolean_ItemInited(object sender, EventArgs e)
        {
            if (Item != null)
                tbToolTip.Text = Item.Description;
        }	
    }
}
