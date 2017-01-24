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
            CaptionMainHide = false;
            AutoCaptions = false;
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
        /// Автоматическое заполнение названий.
        /// </summary>
        public bool AutoCaptions { get; set; }

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
                else
                    rectangle1.pathExternalLink.Visibility = Visibility.Collapsed;
            }
        }

        bool _CaptionMainHide;
        /// <summary>
        /// Скрытый основый текст.
        /// </summary>
        public bool CaptionMainHide
        {
            get { return _CaptionMainHide; }
            set
            {

                _CaptionMainHide = value;
                if (_CaptionMainHide)
                {
                    rectangle1.Margin = new Thickness(0, 20, 0, 0);
                }
                else
                {
                    rectangle1.Margin = new Thickness(0, 0, 0, 0);
                }
                rectangle1.CaptionMainHide = _CaptionMainHide;
            }
        }

        private void UserControlEx_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
