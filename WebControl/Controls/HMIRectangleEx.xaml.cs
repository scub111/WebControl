using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace WebControl
{
    public partial class HMIRectangleEx : HMIBooleanBase
    {
        public enum NodeType
        {
            None = 0,
            Computer = 1,
            Camera = 2,
            Registrator = 3,
            Database = 4,
            Monitor = 5,
            Server = 6,
            PLC = 7,
            Router = 8,
            Switch = 9,
            Device = 10
        }

        public HMIRectangleEx()
        {
            InitializeComponent();
            Type = NodeType.Computer;
            pathExternalLink.Visibility = Visibility.Collapsed;
            _CaptionMainHide = false;
        }

        /// <summary>
        /// Описание основное.
        /// </summary>
        public TextBlock CaptionMain
        {
            get { return tbCaptionMain; }
        }

        /// <summary>
        /// Размер шрифта основное описания .
        /// </summary>
        public double CaptionMainFontSize
        {
            get { return tbCaptionMain.FontSize; }
            set { tbCaptionMain.FontSize = value; }
        }

        /// <summary>
        /// Текст основное описания.
        /// </summary>
        public string CaptionMainText
        {
            get { return tbCaptionMain.Text; }
            set { tbCaptionMain.Text = value; }
        }

        /// <summary>
        /// Наименование шрифта основное описания.
        /// </summary>
        public FontFamily CaptionMainFontFamily
        {
            get { return tbCaptionMain.FontFamily; }
            set { tbCaptionMain.FontFamily = value; }
        }

        /// <summary>
        /// Описание дополнительное.
        /// </summary>
        public TextBlock CaptionAdditional
        {
            get { return tbCaptionAdditional; }
        }

        /// <summary>
        /// Размер шрифта дополнительного описания .
        /// </summary>
        public double CaptionAdditionalFontSize
        {
            get { return tbCaptionAdditional.FontSize; }
            set { tbCaptionAdditional.FontSize = value; }
        }

        /// <summary>
        /// Текст дополнительного описания.
        /// </summary>
        public string CaptionAdditionalText
        {
            get { return tbCaptionAdditional.Text; }
            set { tbCaptionAdditional.Text = value; }
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
                    tbCaptionMain.Visibility = Visibility.Collapsed;
                    tbCaptionAdditional.Margin = new Thickness(0, 0, 0, 0);
                }
                else
                {
                    tbCaptionMain.Visibility = Visibility.Visible;
                    tbCaptionAdditional.Margin = new Thickness(0, 20, 0, 0);
                }
            }
        }

        /// <summary>
        /// Тип узла сети.
        /// </summary>
        NodeType _RectangleType;
        public NodeType Type
        {
            get { return _RectangleType; }
            set
            {
                _RectangleType = value;
                grpComputer.Visibility = Visibility.Collapsed;
                grpCamera.Visibility = Visibility.Collapsed;
                grpRegistrator.Visibility = Visibility.Collapsed;
                grpRegistratorDB.Visibility = Visibility.Collapsed;
                grpDatabase.Visibility = Visibility.Collapsed;
                grpMonitor.Visibility = Visibility.Collapsed;
                grpServer.Visibility = Visibility.Collapsed;
                grpPLC.Visibility = Visibility.Collapsed;
                grpRouter.Visibility = Visibility.Collapsed;
                grpSwitch.Visibility = Visibility.Collapsed;

                switch (_RectangleType)
                {
                    case NodeType.Computer:
                        grpComputer.Visibility = Visibility.Visible;
                        break;
                    case NodeType.Camera:
                        grpCamera.Visibility = Visibility.Visible;
                        break;
                    case NodeType.Registrator:
                        grpRegistrator.Visibility = Visibility.Visible;
                        grpRegistratorDB.Visibility = Visibility.Visible;
                        break;
                    case NodeType.Database:
                        grpDatabase.Visibility = Visibility.Visible;
                        break;
                    case NodeType.Monitor:
                        grpMonitor.Visibility = Visibility.Visible;
                        break;
                    case NodeType.Server:
                        grpServer.Visibility = Visibility.Visible;
                        break;
                    case NodeType.PLC:
                        grpPLC.Visibility = Visibility.Visible;
                        break;
                    case NodeType.Router:
                        grpRouter.Visibility = Visibility.Visible;
                        break;
                    case NodeType.Switch:
                        grpSwitch.Visibility = Visibility.Visible;
                        break;
                }
            }
        }

        /// <summary>
        /// Наименование шрифта дополнительного описания.
        /// </summary>
        public FontFamily CaptionAdditionalFontFamily
        {
            get { return tbCaptionAdditional.FontFamily; }
            set { tbCaptionAdditional.FontFamily = value; }
        }

        private void HMIRectangleEx_ItemInited(object sender, EventArgs e)
        {
            tbToolTip.Text = Item.Description;
        }

        private void HMIBooleanBase_Loaded(object sender, RoutedEventArgs e)
        {
            //Type = NodeType.Computer;
        }
    }
}
