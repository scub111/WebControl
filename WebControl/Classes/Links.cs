using System;
using System.Collections.Generic;
using System.Text;

namespace WebControl
{

    /// <summary>
    /// Класс для симуляции триггера
    /// </summary>
    public class TriggerT<Tp1>
    {
        // Конструктор
        public TriggerT()
        {
        }

        /// <summary>
        /// Вычисление выходного значения
        /// </summary>
        public bool CalculateRet(Tp1 value)
        {
            if (value.Equals(valueLast)) return false;
            valueLast = value;
            return true;
        }

        /// <summary>
        /// Произошло ли изменение значения
        /// </summary>
        public bool IsChanged(Tp1 value)
        {
            if (!value.Equals(valueLast))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Возврат прошлого значения
        /// </summary>
        public Tp1 GetValueLast()
        {
            return valueLast;
        }

        /// <summary>
        /// Задание прошлого значения
        /// </summary>
        public void SetValueLast(Tp1 tValue)
        {
            valueLast = tValue;
        }

        // Значение на предыдущем шаге
        private Tp1 valueLast;
    }
}
