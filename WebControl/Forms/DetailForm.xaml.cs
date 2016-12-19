using DevExpress.Xpf.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using WebControl.DataServiceReference;
using System.Windows.Media.Imaging;
using DevExpress.Xpf.Printing;
using System.Windows.Data;

namespace WebControl
{
    public partial class DetailForm : UserControlEx
    {
        public DetailForm()
        {
            InitializeComponent();
        }

        HMIBooleanBase HmiBoolean { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            teDataName.Text = Item.DataName;
            teDescription.Text = Item.Description;
            teUnit.Text = Item.Unit;
            teDataType.Text = Item.DataType.ToString();
            teFormatValue.Text = Item.FormatValue;
            teMinValue.Text = Item.MinValue.ToString();
            teMaxValue.Text = Item.MaxValue.ToString();
            teTimeOut.Text = Item.TimeOut.ToString();

            UpdateData();
        }

        /// <summary>
        /// Реальный объект.
        /// </summary>
        ItemReal Item { get; set; }

        /// <summary>
        /// Элемент-владелец.
        /// </summary>
        HMISimpleBase HMIBase { get; set; }
    
        public override void SetOwner(object owner)
        {
            base.SetOwner(owner);
            if (owner is HMISimpleBase)
            {
                HMISimpleBase hmiBase = (HMISimpleBase)owner;
                HMIBase = hmiBase;
                Item = hmiBase.Item;
                if (hmiBase is HMIBooleanBase)
                    HmiBoolean = hmiBase as HMIBooleanBase;

            }
        }

        /// <summary>
        /// Обновление данных.
        /// </summary>
        private void UpdateData()
        {
            teDataValue.Text = Item.DataValue.ToString();
            teQuality.Text = Item.Quality.ToString();
            teDeviceTime.Text = Item.DeviceTime.ToString();
            teSqlTime.Text = string.Format("{0} ({1} c)", Item.SqlTime.ToString(), (Global.Default.SqlCurrentTime - Item.SqlTime).TotalSeconds.ToString("0.#"));
        }

        /// <summary>
        /// Возврат откорректированного значения.
        /// </summary>
        double GetCorrectDataValue(double value)
        {
            if (HmiBoolean != null)
                return HmiBoolean.GetTrendValue(value);
            else
                return value;
        }

        /// <summary>
        /// Запрос обновления из вне.
        /// </summary>
        public void UpdateExternal()
        {
            if (Visible)
            {
                UpdateData();
            }
        }

    }
}