using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WebControl
{
    public class HMIBooleanBase : HMISimpleBase
    {
        public HMIBooleanBase()
        {
            ValueON = 1;
            ValueOFF = 0;
            DataValueChanged += HMIBooleanBase_DataValueChanged;
        }

        public delegate bool StatePosition(HMIBooleanBase sender, double value);

        /// <summary>
        /// Делегат на включенное состояние.
        /// </summary>
        public StatePosition ValueONDelegete { get; set; }

        /// <summary>
        /// Делегат на выключенное состояние.
        /// </summary>
        public StatePosition ValueOFFDelegete { get; set; }

        /// <summary>
        /// Делегат на неизвестное состояние.
        /// </summary>
        public StatePosition ValueUnknownDelegete { get; set; }


        /// <summary>
        /// Значение для включенного состояния.
        /// </summary>
        public double ValueON { get; set; }

        /// <summary>
        /// Значение для выключенного состояния.
        /// </summary>
        public double ValueOFF { get; set; }


        /// <summary>
        /// Цвет для включенного состояния.
        /// </summary>
        public virtual Color ColorON { get; set; }

        /// <summary>
        /// Цвет для выключенного состояния.
        /// </summary>
        public virtual Color ColorOFF { get; set; }


        /// <summary>
        /// Функция включенного состояния.
        /// </summary>
        public virtual bool GetStateON(double value)
        {
            if (ValueONDelegete != null)
                return ValueONDelegete(this, value);
            else
            {
                if (value == ValueON)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Функция выключеннего состояния.
        /// </summary>
        public virtual bool GetStateOFF(double value)
        {
            if (ValueOFFDelegete != null)
                return ValueOFFDelegete(this, value);
            else
            {
                if (value == ValueOFF)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Функция неизвестного состояния.
        /// </summary>
        public virtual bool GetStateUnknown(double value)
        {
            if (ValueUnknownDelegete != null)
                return ValueUnknownDelegete(this, value);
            else
            {
                if (GetStateON(value))
                    return false;
                else if (GetStateOFF(value))
                    return false;
                else
                    return true;
            }
        }

        /// <summary>
        /// Возврат значения для тренда.
        /// </summary>
        public virtual int GetTrendValue(double value)
        {
            if (GetStateON(value))
                return 1;
            if (GetStateOFF(value))
                return 0;
            if (GetStateUnknown(value))
                return -1;
            return -10;
        }

        private void HMIBooleanBase_DataValueChanged(object sender, EventArgs e)
        {
            if (GetStateON(DataValue))
                VisualStateManager.GoToState(this, "ControlValueON", true);
            if (GetStateOFF(DataValue))
                VisualStateManager.GoToState(this, "ControlValueOFF", true);
            if (GetStateUnknown(DataValue))
                VisualStateManager.GoToState(this, "ControlValueUnknown", true);
        }
    }
}
