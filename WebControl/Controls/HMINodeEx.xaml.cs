using System;
using System.Collections.Generic;
using System.Linq;
using static WebControl.HMIRectangleEx;
using System.Windows;

namespace WebControl
{
    public partial class HMINodeEx : UserControlEx
    {
        public HMINodeEx()
        {
            InitializeComponent();  
        }

        string _DataNameEx;
        /// <summary>
        /// Имя поля.
        /// </summary>
        public string DataNameEx
        {
            get { return _DataNameEx; }
            set
            {
                _DataNameEx = value;
                rectangle1.DataName = string.Format("{0}_Status", _DataNameEx);
                label1.DataName = string.Format("{0}_ReplyTime", _DataNameEx);
            }
        }

        /// <summary>
        /// Надпись основная.
        /// </summary>
        public string CaptionMain
        {
            get { return rectangle1.CaptionMainText; }
            set { rectangle1.CaptionMainText = value; }
        }

        /// <summary>
        /// Надпись IP.
        /// </summary>
        public string CaptionAdditional
        {
            get { return rectangle1.CaptionAdditionalText; }
            set { rectangle1.CaptionAdditionalText = value; }
        }

        /// <summary>
        /// Тип узла сети.
        /// </summary>
        public NodeType Type
        {
            get { return rectangle1.Type; }
            set { rectangle1.Type = value; }
        }

        /// <summary>
        /// Внешняя ссылка для перехода.
        /// </summary>
        public string ExternalLink
        {
            get { return rectangle1.ExternalLink; }
            set
            {
                rectangle1.ExternalLink = value;
                if (!string.IsNullOrEmpty(rectangle1.ExternalLink))
                    rectangle1.pathExternalLink.Visibility = Visibility.Visible;
            }
        }

        private void UserControlEx_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
