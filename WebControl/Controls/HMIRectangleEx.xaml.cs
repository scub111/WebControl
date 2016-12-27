using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace WebControl
{
    public partial class HMIRectangleEx : HMIBooleanBase
    {
        public HMIRectangleEx()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Описание.
        /// </summary>
        public TextBlock Description
        {
            get { return tbDescription; }
        }

        /// <summary>
        /// Размер шрифта описания.
        /// </summary>
        public double DescriptionFontSize
        {
            get { return tbDescription.FontSize; }
            set { tbDescription.FontSize = value; }
        }

        /// <summary>
        /// Текст описания.
        /// </summary>
        public string DescriptionText
        {
            get { return tbDescription.Text; }
            set { tbDescription.Text = value; }
        }

        /// <summary>
        /// Наименование шрифта.
        /// </summary>
        public FontFamily DescriptionFontFamily
        {
            get { return tbDescription.FontFamily; }
            set { tbDescription.FontFamily = value; }
        }

        private void HMIRectangleEx_ItemInited(object sender, EventArgs e)
        {
            tbToolTip.Text = Item.Description;
        }
    }
}
