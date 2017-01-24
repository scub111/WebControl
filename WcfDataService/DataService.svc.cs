using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.ServiceModel;

namespace WcfDataService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
                        ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DataService : IDataService
    {
        public DataService()
        {
            Version = "1.3.2";

            if (IsLocalIpAddress("172.31.106.146"))
                ConnectionString = @"Data Source=172.31.106.121,1444;Initial Catalog=WebControl;Persist Security Info=True;User ID=sa;Password=qwe+ASDFG";
            else
                ConnectionString = @"Data Source=127.0.0.1,1444;Initial Catalog=WebControl;Persist Security Info=True;User ID=sa;Password=qwe+ASDFG";

            ItemsInited = false;

            ValuesCurrentTableName = "_ValuesCurrent";
            CliensTableName = "_Cliens";
            DateTimeFormat = "MM/dd/yyyy HH:mm:ss";

            CreatedDate = DateTime.Now;

            ThreadMain = new ThreadTimer();
            ThreadMain.Period = 5000;
            ThreadMain.WorkChanged += ThreadMain_WorkChanged;
            ThreadMain.Run();

            ItemSqls = new Collection<ItemSql>();
            ItemSqlShorts = new Collection<ItemSqlSimple>();
            ItemSqlDict = new Dictionary<string, ItemSql>();
        }

        /// <summary>
        /// Проверка IP-адреса на локальность.
        /// </summary>
        public static bool IsLocalIpAddress(string local)
        {
            bool result = false;
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            ///IPAddress[] ipList = Dns.GetHostByName(hostName).AddressList;
            IPAddress[] ipList = Dns.GetHostEntry(hostName).AddressList;

            for (int i = 0; i < ipList.Length; i++)
                if (ipList[i].ToString() == local)
                    return true;

            return result;
        }

        void ThreadMain_WorkChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(string.Format("SELECT DataName, Trend, Description, Unit, FormatValue, MinValue, MaxValue, DataType, DataValue, Quality, SqlTime, DeviceTime, TimeOut, Comment FROM {0}",
                                                                    ValuesCurrentTableName),
                                                                    connection);

                SqlDataReader reader = command.ExecuteReader();

                int i = 0;
                while (reader.Read())
                {
                    ItemSql item = new ItemSql();
                    item.DataName = reader.GetString(0).TrimEnd();
                    item.Trend = reader.GetBoolean(1);
                    item.Description = reader.GetString(2).TrimEnd();
                    item.Unit = reader.GetString(3).TrimEnd();
                    item.FormatValue = reader.GetString(4).TrimEnd();
                    item.MinValue = reader.GetDouble(5);
                    item.MaxValue = reader.GetDouble(6);
                    item.DataType = (short)reader.GetByte(7);
                    item.DataValue = reader.GetDouble(8);
                    item.Quality = (short)reader.GetInt32(9);
                    item.SqlTime = reader.GetDateTime(10);
                    item.DeviceTime = reader.GetDateTime(11);
                    item.TimeOut = reader.GetInt32(12);
                    item.Comment = reader.GetString(13).TrimEnd();

                    if (!ItemsInited)
                    {
                        ItemSqls.Add(item);
                        ItemSqlDict.Add(item.DataName, item);
                        ItemSqlShorts.Add(item.GetItemSimple());
                    }
                    else
                    {
                        ItemSqls[i] = item;
                        if (ItemSqlDict.ContainsKey(item.DataName))
                            ItemSqlDict[item.DataName] = item;
                        ItemSqlShorts[i] = item.GetItemSimple();
                    }
                    i++;
                }

                if (!ItemsInited)
                    ItemsInited = true;

                ItemUpdateTime = DateTime.Now;
            }
            catch
            {
                ItemsInited = false;
                ItemSqls.Clear();
                ItemSqlDict.Clear();
                ItemSqlShorts.Clear();
            }
            finally
            {
                connection.Close();
            }
        }

        public void Test()
        {
        }

        /// <summary>
        /// Версия.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Инициализация элементов.
        /// </summary>
        bool ItemsInited { get; set; }

        /// <summary>
        /// Основной поток выполнения считывания даннх с БД.
        /// </summary>
        ThreadTimer ThreadMain { get; set; }

        /// <summary>
        /// Коллекция последний значений технологического процесса.
        /// </summary>
        Collection<ItemSql> ItemSqls { get; set; }

        /// <summary>
        /// Словарь элементов.
        /// </summary>
        public Dictionary<string, ItemSql> ItemSqlDict { get; set; }

        /// <summary>
        /// Коллекция последний значений технологического процесса сокращенном виде.
        /// </summary>
        Collection<ItemSqlSimple> ItemSqlShorts { get; set; }

        /// <summary>
        /// Строка подключения к БД.
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// Название таблицы текущих значений.
        /// </summary>
        string ValuesCurrentTableName { get; set; }

        /// <summary>
        /// Название таблицы информации о клиентах.
        /// </summary>
        string CliensTableName { get; set; }

        /// <summary>
        /// Формат времени.
        /// </summary>
        string DateTimeFormat { get; set; }

        /// <summary>
        /// Количество запросов на обноление данных.
        /// </summary>
        int ReadItemShortCount { get; set; }

        /// <summary>
        /// Время создание сервиса.
        /// </summary>
        DateTime CreatedDate { get; set; }

        /// <summary>
        /// Время последнего обновления в цикле.
        /// </summary>
        DateTime ItemUpdateTime { get; set; }

        /// <summary>
        /// Инициализация элементов.
        /// </summary>
        public Collection<ItemSql> GetItemsFull()
        {
            /*
            Collection<ItemSql> items = new Collection<ItemSql>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(string.Format("SELECT DataName, Trend, Description, Unit, FormatValue, MinValue, MaxValue, DataType, DataValue, Quality, SqlTime, DeviceTime, TimeOut FROM {0}",
                                                                    ValuesCurrentTableName),
                                                                    connection);


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ItemSql item = new ItemSql()
                    {
                        DataName = reader.GetString(0).TrimEnd(),
                        Trend = reader.GetBoolean(1),
                        Description = reader.GetString(2).TrimEnd(),
                        Unit = reader.GetString(3).TrimEnd(),
                        FormatValue = reader.GetString(4).TrimEnd(),
                        MinValue = reader.GetDouble(5),
                        MaxValue = reader.GetDouble(6),
                        DataType = (short)reader.GetByte(7),
                        DataValue = reader.GetDouble(8),
                        Quality = (short)reader.GetInt32(9),
                        SqlTime = reader.GetDateTime(10),
                        DeviceTime = reader.GetDateTime(11),
                        TimeOut = reader.GetInt32(12)
                    };
                    items.Add(item);
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return items;
            */
            return ItemSqls;
        }

        /// <summary>
        /// Обновление элементов.
        /// </summary>
        public Collection<ItemSqlSimple> GetItemsShort()
        {
            /*
            Collection<ItemSqlSimple> items = new Collection<ItemSqlSimple>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(string.Format("SELECT DataValue, Quality, SqlTime, DeviceTime FROM {0}; ",
                                                        ValuesCurrentTableName),
                                                        connection);


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ItemSqlSimple item = new ItemSqlSimple()
                    {
                        DataValue = reader.GetDouble(0),
                        Quality = (short)reader.GetInt32(1),
                        SqlTime = reader.GetDateTime(2),
                        DeviceTime = reader.GetDateTime(3)
                    };
                    items.Add(item);
                }
                ReadItemShortCount++;
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            
            return items;
             */


            ReadItemShortCount++;
            return ItemSqlShorts;

            /*
            Collection<ItemSqlSimple> items = new Collection<ItemSqlSimple>();
            foreach (ItemSqlSimple item in ItemSqlShorts)
            {
                ItemSqlSimple itemNew = new ItemSqlSimple()
                {
                    DataValue = item.DataValue,
                    Quality = item.Quality,
                    SqlTime = item.SqlTime,
                    DeviceTime = item.DeviceTime
                };
                items.Add(itemNew);
                //items.Add(item);
            }
            return items;
             */
        }

        /// <summary>
        /// Выборочное запрос элементов.
        /// </summary>
        public Collection<ItemSqlSimple> GetItemsShortByDataNames(Collection<string> dataNames)
        {
            Collection<ItemSqlSimple> items = new Collection<ItemSqlSimple>();

            // Задание нулевой записи с времененем последнего обновления цикла.
            ItemSqlSimple sqlItem = new ItemSqlSimple();
            sqlItem.SqlTime = ItemUpdateTime;
            items.Add(sqlItem);
            items[0].SqlTime = ItemUpdateTime;

            // Передача записей по имени.
            foreach (string dataName in dataNames)
            {
                ItemSqlSimple item = new ItemSqlSimple();

                if (ItemSqlDict.ContainsKey(dataName))
                    item = ItemSqlDict[dataName].GetItemSimple();

                items.Add(item);
            }
            ReadItemShortCount++;

            return items;
        }

        /// <summary>
        /// Получение вещественного числа из булевого значения.
        /// </summary>
        static double GetDouble(bool value)
        {
            if (value)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// Получение трендовых знаений.
        /// </summary>
        public ItemSqlTrends GetTrends(string tableName, int type, DateTime dateBegin, DateTime dateEnd, int timePeriod)
        {
            ItemSqlTrends trends = new ItemSqlTrends();
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(string.Format(@"SELECT DataValue, SqlTime FROM {0} 
                                                                    WHERE SqlTime BETWEEN '{1}' AND '{2}' AND TimePeriod >= {3} order by SqlTime",
                                                                    /*0*/tableName,
                                                                    /*1*/dateBegin.ToString(DateTimeFormat),
                                                                    /*2*/dateEnd.ToString(DateTimeFormat),
                                                                    /*3*/timePeriod),
                                                                    connection);

                SqlDataReader reader = command.ExecuteReader();

                int i = 0;

                while (reader.Read())
                {
                    ItemSqlTrend item = new ItemSqlTrend();
                    if (type == 1)
                        item.DataValue = GetDouble(reader.GetBoolean(0));
                    else if (type == 2)
                        item.DataValue = reader.GetInt32(0);
                    else
                        item.DataValue = reader.GetDouble(0);

                    item.SqlTime = reader.GetDateTime(1);

                    trends.Records.Add(item);

                    if (i == 0)
                        trends.MinValue = trends.MaxValue = item.DataValue;

                    if (item.DataValue < trends.MinValue)
                        trends.MinValue = item.DataValue;

                    if (item.DataValue > trends.MaxValue)
                        trends.MaxValue = item.DataValue;

                    i++;
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }

            return trends;
        }

        /// <summary>
        /// Получение текущего времени SQL-сервера.
        /// </summary>
        /// <returns></returns>
        public DateTime GetSqlCurrentTime()
        {
            DateTime dateTime = new DateTime();
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(string.Format("SELECT getdate()"), connection);

                dateTime = (DateTime)command.ExecuteScalar();

            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }

            return dateTime;
        }

        /// <summary>
        /// Получение текущего версии WCF-службы.
        /// </summary>
        public string GetVersion()
        {
            return Version;
        }

        /// <summary>
        /// Возврат текущего времени машины со смещением.
        /// </summary>
        /// <returns></returns>
        public DateTimeOffset GetDateTimeOffset()
        {
            return DateTimeOffset.Now;
        }

        /// <summary>
        /// Инициализация информации о клиенте.
        /// </summary>
        public bool SetClientInfoFull(string quid, string ipAddress, string version, DateTime clientTime, string browserInformation)
        {
            bool success = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();

                string statement = string.Format("IF NOT EXISTS (SELECT * FROM {0} WHERE GUID = '{1}') INSERT INTO {0} (GUID) VALUES ('{1}'); ",
                    /*0*/CliensTableName,
                    /*1*/quid);

                statement += string.Format(@"UPDATE {0} SET 
                    SqlTime = GETDATE(), 
                    IPAddress = '{2}', 
                    Version ='{3}', 
                    ClientTime = '{4}', 
                    BrowserInformation ='{5}' 
                    WHERE GUID = '{1}'; ",
                    /*0*/CliensTableName,
                    /*1*/quid,
                    /*2*/ipAddress,
                    /*3*/version,
                    /*4*/clientTime.ToString(DateTimeFormat),
                    /*5*/browserInformation);

                SqlCommand command = new SqlCommand(statement, connection);
                command.ExecuteNonQuery();
                success = true;
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }

            return success;
        }

        /// <summary>
        /// Обновление информации о клиенте.
        /// </summary>
        public bool SetClientInfoShort(string quid, DateTime clientTime)
        {
            bool success = false;
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(string.Format(@"UPDATE {0} SET 
                                                        SqlTime = GETDATE(), 
                                                        ClientTime = '{2}' 
                                                        WHERE GUID = '{1}'; ",
                                                        /*0*/CliensTableName,
                                                        /*1*/quid,
                                                        /*2*/clientTime.ToString(DateTimeFormat)),
                                                        connection);

                command.ExecuteNonQuery();
                success = true;
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }

            return success;
        }

        /// <summary>
        /// Чтение данных с таблицы "TIDELOG".
        /// </summary>
        public Collection<TIDELOGEx> GetMTBTIDELOGs(string tableName, DateTime dateBegin, DateTime dateEnd)
        {
            Collection<TIDELOGEx> items = new Collection<TIDELOGEx>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand(string.Format(@"SELECT ID, SqlTime, TDTime, KMAZS, Operator, Car, Liters, TankTime, TankLevel, TankVolume, TankDensity, TankTemperature FROM {0}
                                                                    WHERE TDTime BETWEEN '{1}' AND '{2}' order by TDTime",
                                                                    /*0*/tableName,
                                                                    /*1*/dateBegin.ToString(DateTimeFormat),
                                                                    /*2*/dateEnd.ToString(DateTimeFormat)),
                                                                    connection);


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    TIDELOGEx item = new TIDELOGEx();
                    item.ID = reader.GetInt32(0);
                    item.SqlTime = reader.GetDateTime(1);
                    item.TDTime = reader.GetDateTime(2);
                    item.KMAZS = reader.GetString(3).TrimEnd();
                    item.Operator = reader.GetString(4).TrimEnd();
                    item.Car = reader.GetString(5).TrimEnd();
                    item.Liters = reader.GetDouble(6);
                    item.TankTime = reader.GetDateTime(7);
                    item.TankLevel = reader.GetDouble(8);
                    item.TankVolume = reader.GetDouble(9);
                    item.TankDensity = reader.GetDouble(10);
                    item.TankTemperature = reader.GetDouble(11);

                    /*
                    TIDELOGEx item = new TIDELOGEx()
                    {
                        ID = reader.GetInt32(0),
                        SqlTime = reader.GetDateTime(1),
                        TDTime = reader.GetDateTime(2),
                        KMAZS = reader.GetString(3).TrimEnd(),
                        Operator = reader.GetString(4).TrimEnd(),
                        Car = reader.GetString(5).TrimEnd(),
                        Liters = reader.GetDouble(6),
                        TankTime = reader.GetDateTime(7),
                        TankLevel = reader.GetDouble(8),
                        TankVolume = reader.GetDouble(9),
                        TankDensity = reader.GetDouble(10),
                        TankTemperature = reader.GetDouble(11),
                    };

                    */
                    items.Add(item);
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
            return items;
        }

        /// <summary>
        /// Запроси информации о сервисе.
        /// </summary>
        public string GetServiceInfo()
        {
            return string.Format("{0} / {1}", CreatedDate, ReadItemShortCount);
        }
    }
}
