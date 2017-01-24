using System;
using System.Linq;
using System.Web;
using System.Collections.ObjectModel;

namespace WcfDataService
{
    #region ItemSqlTrends
    /// <summary>
    /// Класс для передачи трендов.
    /// </summary>
    public class ItemSqlTrends
    {
        public ItemSqlTrends()
        {
            Records = new Collection<ItemSqlTrend>();
            MinValue = 0;
            MaxValue = 1;
        }

        /// <summary>
        /// Записи.
        /// </summary>
        public Collection<ItemSqlTrend> Records { get; set; }

        /// <summary>
        /// Минимальное значение.
        /// </summary>
        public double MinValue { get; set; }

        /// <summary>
        /// Максимальное значение.
        /// </summary>
        public double MaxValue { get; set; }
    }
    #endregion

    #region ItemSqlTrend
    /// <summary>
    /// Класс трендов.
    /// </summary>
    public class ItemSqlTrend
    {
        public ItemSqlTrend()
        {
        }

        /// <summary>
        /// Значение.
        /// </summary>
        public double DataValue { get; set; }

        /// <summary>
        /// Время записи на SQL-сервере.
        /// </summary>
        public DateTime SqlTime { get; set; }
    }
    #endregion

    #region ItemSqlSimple
    /// <summary>
    /// Класс обновления значений.
    /// </summary>
    public class ItemSqlSimple : ItemSqlTrend
    {
        public ItemSqlSimple()
        {
        }

        /// <summary>
        /// Качество.
        /// </summary>
        public short Quality { get; set; }

        /// <summary>
        /// Штамп времени.
        /// </summary>
        public DateTime DeviceTime { get; set; }
    }
    #endregion

    #region ItemSql
    /// <summary>
    /// Класс элементов реального времени.
    /// </summary>
    public class ItemSql : ItemSqlSimple
    {
        public ItemSql()
        {
        }
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
        public short DataType { get; set; }

        /// <summary>
        /// Таймаут, с.
        /// </summary>
        public int TimeOut { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public string Comment { get; set; }

        public ItemSqlSimple GetItemSimple()
        {
            ItemSqlSimple item = new ItemSqlSimple();
            item.DataValue = DataValue;
            item.Quality = Quality;
            item.SqlTime = SqlTime;
            item.DeviceTime = DeviceTime;
            return item;
        }
    }
    #endregion

    #region ItemSql

    /// <summary>
    /// Класс для таблицы "TIDELOG"
    /// </summary>
    public class TIDELOGEx
    {
        public TIDELOGEx()
        {
        }

        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Время на сервере.
        /// </summary>
        public DateTime SqlTime { get; set; }

        /// <summary>
        /// Время выдачи топлива.
        /// </summary>
        public DateTime TDTime { get; set; }

        /// <summary>
        /// КМАЗС.
        /// </summary>
        public string KMAZS { get; set; }

        /// <summary>
        /// Оператор.
        /// </summary>
        public string Operator { get; set; }

        /// <summary>
        /// Машина.
        /// </summary>
        public string Car { get; set; }

        /// <summary>
        /// Литры.
        /// </summary>
        public double Liters { get; set; }

        /// <summary>
        /// Ближайнее время резервуара.
        /// </summary>
        public DateTime TankTime { get; set; }

        /// <summary>
        /// Уровень резервуара.
        /// </summary>
        public double TankLevel { get; set; }

        /// <summary>
        /// Объем резервуара.
        /// </summary>
        public double TankVolume { get; set; }

        /// <summary>
        /// Температура резервуара.
        /// </summary>
        public double TankTemperature { get; set; }

        /// <summary>
        /// Плотность резервуара.
        /// </summary>
        public double TankDensity { get; set; }


    }
    #endregion
}