using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebControl
{
    #region ItemReal
    /// <summary>
    /// Класс элементов реального времени.
    /// </summary>
    public class ItemReal
    {
        public ItemReal()
        {
            DataType = DataTypeSimple.Real;
            VisualControlDict = new Dictionary<UserControlEx, int>();
        }

        /// <summary>
        /// Тип переменной.
        /// </summary>
        public enum DataTypeSimple
        {
            Boolean = 1,            // булевый
            Integer = 2,            // целочисленный
            Real = 3                // вещественный
        };

        /// <summary>
        /// Имя SQL-таблицы.
        /// </summary>
        public string DataName { get; set; }

        /// <summary>
        /// Тренд.
        /// </summary>
        public bool Trend { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Единица измерения.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Значение.
        /// </summary>
        public double DataValue { get; set; }

        /// <summary>
        /// Формат значения.
        /// </summary>
        public string FormatValue { get; set; }

        /// <summary>
        /// Минимальное значение.
        /// </summary>
        public double MinValue { get; set; }

        /// <summary>
        /// Максимальное значение.
        /// </summary>
        public double MaxValue { get; set; }

        /// <summary>
        /// Упрощенный тип переменной.
        /// </summary>
        public DataTypeSimple DataType { get; set; }

        /// <summary>
        /// Качество.
        /// </summary>
        public short Quality { get; set; }

        /// <summary>
        /// Время на SQL-сервере.
        /// </summary>
        public DateTime SqlTime { get; set; }

        /// <summary>
        /// Время на устройстве.
        /// </summary>
        public DateTime DeviceTime { get; set; }

        /// <summary>
        /// Таймаут, с.
        /// </summary>
        public int TimeOut { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Словарь визуальных элементов интерфейса.
        /// </summary>
        Dictionary<UserControlEx, int> VisualControlDict { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", DataValue.ToString(FormatValue), Unit);
        }

        public void VisualControlActivate(UserControlEx control)
        {
            if (!VisualControlDict.ContainsKey(control))
                VisualControlDict.Add(control, 0);
        }

        public void VisualControlDeactivate(UserControlEx control)
        {
            if (VisualControlDict.ContainsKey(control))
                VisualControlDict.Remove(control);
        }

        /// <summary>
        /// Получение общего количества активным визуальных элементов.
        /// </summary>
        public int GetVisualControlActivatedCount()
        {
            return VisualControlDict.Count;
        }
    }
    #endregion
}
