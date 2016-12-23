using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace WebControl
{
    public partial class HMINodeEx : UserControl
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
    }
}
