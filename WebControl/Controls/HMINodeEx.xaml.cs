using System;
using System.Collections.Generic;
using System.Linq;

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
            get { return tbCaption.Text; }
            set { tbCaption.Text = value; }
        }

        /// <summary>
        /// Надпись IP.
        /// </summary>
        public string CaptionIP
        {
            get { return rectangle1.DescriptionText; }
            set { rectangle1.DescriptionText = value; }
        }
    }
}
