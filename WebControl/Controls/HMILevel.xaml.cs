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
    public partial class HMILevel : HMIRealBase 
    {
        public HMILevel()
        {
            InitializeComponent();
            DataValueMin = 0;
            DataValueMax = 100;
        }

        /// <summary>
        /// Минимальное значение.
        /// </summary>
        public double DataValueMin { get; set; }

        /// <summary>
        /// Максимальное значение.
        /// </summary>
        public double DataValueMax { get; set; }

        /// <summary>
        /// Толщина оконтовки.
        /// </summary>
        public double RecMouseStrokeThickness
        {
            get { return recMouse.StrokeThickness; }
            set { recMouse.StrokeThickness = value; }
        }

        /// <summary>
        /// Свет заливки.
        /// </summary>
        public Brush RecBaseFill
        {
            get { return recBase.Fill; }
            set { recBase.Fill = value; }
        }

        private void HMILevel_DataValueChanged(object sender, EventArgs e)
        {
            if (Height > 0)
            {
                double per = (1 - (DataValue - DataValueMin) / (DataValueMax - DataValueMin));
                if (per < 0) per = 0;
                if (per > 1) per = 1;
                double top = per * Height;
                recBase.Margin = new Thickness(0, top, 0, 0);
            }
        }

        private void HMILevel_ItemInited(object sender, EventArgs e)
        {
            tbToolTip.Text = Item.Description;
        }

        private void HMILevel_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            Height = 200;
            Width = 100;
            DataValue = 50;
             */
        }

        private void HMITemp_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            HMILevel_DataValueChanged(null, null);
        }	
    }
}
