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
    public partial class HMILabel : HMIRealBase 
    {
        public HMILabel()
        {
            InitializeComponent();
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
        /// Наименование шрифта.
        /// </summary>
        public FontFamily CaptionFontFamily
        {
            get { return txtCaption.FontFamily; }
            set { txtCaption.FontFamily = value; }
        }

        /// <summary>
        /// Радиус скругления.
        /// </summary>
        public double RectangleRadius
        {
            get { return recMouse.RadiusX; }
            set { recMouse.RadiusX = recMouse.RadiusY = value; }
        }

        private void HMILabel_DataValueChanged(object sender, EventArgs e)
        {
            //if (Visible)
            //{
                if (Item != null)
                    txtCaption.Text = Item.ToString();
                else
                    txtCaption.Text = DataValue.ToString();
            //}
        }

        private void HMILabel_ItemInited(object sender, EventArgs e)
        {
            tbToolTip.Text = Item.Description;
        }	
    }
}
