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
    public partial class ButtonEx : UserControlEx 
    {
        public ButtonEx()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Текст кнопки.
        /// </summary>
        public string Text
        {
            get { return tbCaption.Text; }
            set { tbCaption.Text = value; }
        }

        /// <summary>
        /// Размер шрифта.
        /// </summary>
        public double TextFontSize
        {
            get { return tbCaption.FontSize; }
            set { tbCaption.FontSize = value; }
        }

        /// <summary>
        /// Источник изображения кнопки.
        /// </summary>
        public ImageSource ImageSource
        {
            get { return imgBase.Source; }
            set { imgBase.Source = value; }
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
        /// Подсказка.
        /// </summary>
        public string ToolTip { get; set; }

        /// <summary>
        /// Событие на щелчок.
        /// </summary>
        public event RoutedEventHandler Click;

        private void ButtonEx1_Loaded(object sender, RoutedEventArgs e)
        {
            tbToolTip.Text = ToolTip;
            
            ButtonEx1_IsEnabledChanged(this, new DependencyPropertyChangedEventArgs());
        }

        private void ButtonEx1_MouseEnter(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "ControlMouseEnter", true);
        }

        private void ButtonEx1_MouseLeave(object sender, MouseEventArgs e)
        {
            VisualStateManager.GoToState(this, "ControlMouseLeave", true);
        }

        private void ButtonEx1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            imgBase.Margin = new Thickness(4, 4, 2, 2);
            tbCaption.Margin = new Thickness(0, 2, 0, 4);
            VisualStateManager.GoToState(this, "ControlMouseDown", true);
            if (Click != null)
                Click(this, null);
        }

        private void ButtonEx1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            imgBase.Margin = new Thickness(3, 3, 3, 3);
            tbCaption.Margin = new Thickness(1, 3, -1, 3);
            VisualStateManager.GoToState(this, "ControlMouseUp", true);
        }

        private void ButtonEx1_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!IsEnabled)
            {
                recMouse.Opacity = tbCaption.Opacity = imgBase.Opacity = 0.5;
            }
            else
            {
                recMouse.Opacity = tbCaption.Opacity = imgBase.Opacity = 1;
            }
        }
    }
}
