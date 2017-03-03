using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading;
using DevExpress.Xpf.Docking;
using WebControl.DataServiceReference;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Browser;
using System.ComponentModel;

namespace WebControl
{
    /// <summary>
    /// Тип режима работы проекта.
    /// </summary>
    public enum ModeType
    {
        Real,
        Debug,
        Demo
    }


    public class GlobalDefault
    {
        public GlobalDefault()
        {
        }

        /// <summary>
        /// Версия системы.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// Режим работы проекта.
        /// </summary>
        public ModeType Mode { get; set; }

        /// <summary>
        /// Основная форма приложения.
        /// </summary>
        public UserControl MainForm { get; set; }

        /// <summary>
        /// Значение вещественного числа для неизвестной переменной.
        /// </summary>
        public double DoubleUnknown { get; set; }

        /// <summary>
        /// Основной поток обработки данных.
        /// </summary>
        public ThreadTimer ThreadMain { get; set; }

        /// <summary>
        /// Поток синхронизации времени.
        /// </summary>
        public ThreadTimer ThreadSQLSync { get; set; }

        /// <summary>
        /// Поток отправки статистики.
        /// </summary>
        public ThreadTimer ThreadStatistic { get; set; }

        /// <summary>
        /// Сторока подключения к БД.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Инициализация элементов.
        /// </summary>
        public bool ItemsInited { get; set; }

        /// <summary>
        /// Коллекция элементов.
        /// </summary>
        public Collection<ItemReal> ItemsReal { get; set; }

        /// <summary>
        /// Словарь элементов.
        /// </summary>
        public Dictionary<string, ItemReal> ItemsRealDict { get; set; }

        /// <summary>
        /// Коллекция активных элементов.
        /// </summary>
        public Collection<ItemReal> ItemsRealActivated { get; set; }

        /// <summary>
        /// Словарь визуальных элементов интерфейса.
        /// </summary>
        Dictionary<string, int> VisualControlDict { get; set; }

        /// <summary>
        /// Сервис сбора данных.
        /// </summary>
        public DataServiceClient DataClient { get; set; }

        /// <summary>
        /// Менеджер документов.
        /// </summary>
        public DockLayoutManager DockManager { get; set; }

        /// <summary>
        /// Контейнер документов.
        /// </summary>
        public DocumentGroup DocumentContainer { get; set; }

        /// <summary>
        /// Разница между локальным и серверным временем.
        /// </summary>
        public TimeSpan ServerClientTimeDiff { get; set; }

        /// <summary>
        /// Смещение по часовому поясу.
        /// </summary>
        public TimeSpan ServerClientTimeZoneDiff { get; set; }

        /// <summary>
        /// Последнее время опроса данных.
        /// </summary>
        public DateTime ItemUpdateTime { get; set; }

        /// <summary>
        /// Разница между временем обновления значений на клиенте и на сервере.
        /// </summary>
        public TimeSpan ItemUpdateTimeDiff { get; set; }

        /// <summary>
        /// Количество ошибок в инициализации.
        /// </summary>
        public int InitFaultCount { get; set; }

        /// <summary>
        /// Количество ошибок в обновлении.
        /// </summary>
        public int UpdatFaultCount { get; set; }

        /// <summary>
        /// Занятость в инициализации данных.
        /// </summary>
        public bool InitItemsBusy { get; set; }

        /// <summary>
        /// Начальное время загрузки.
        /// </summary>
        DateTime T0 { get; set; }

        /// <summary>
        /// Последнее время отправки на обновление данных.
        /// </summary>
        DateTime T0Short { get; set; }

        /// <summary>
        /// Время загрузки приложения.
        /// </summary>
        public TimeSpan LoadTime { get; set; }

        /// <summary>
        /// Время обновления данных.
        /// </summary>
        public TimeSpan ShortUpdateTime { get; set; }

        /// <summary>
        /// Коллекция визуальных элементов, которые работают с глобальными данными.
        /// </summary>
        Collection<HMISimpleBase> UIControls { get; set; }

        /// <summary>
        /// Панель общей сети
        /// </summary>
        public NavigationWithPanal navPanNetwork { get; set; }

        /// <summary>
        /// Панель сети Рудоуправления.
        /// </summary>
        public NavigationWithPanal navPanAdministrationNetwork { get; set; }

        /// <summary>
        /// Панель сети Ангидрита.
        /// </summary>
        public NavigationWithPanal navPanAngidritNetwork { get; set; }

        /// <summary>
        /// Панель сети АСУТП Ангидрита.
        /// </summary>
        public NavigationWithPanal navPanAngidritASUTPNetwork { get; set; }

        /// <summary>
        /// Панель сети Кайерканского.
        /// </summary>
        public NavigationWithPanal navPanKayerkanskiyNetwork { get; set; }

        /// <summary>
        /// Панель сети КУРа.
        /// </summary>
        public NavigationWithPanal navPanKURNetwork { get; set; }        
        
        /// <summary>
        /// Панель сети Известняков.
        /// </summary>
        public NavigationWithPanal navPanLimeNetwork { get; set; }
                     
        /// <summary>
        /// Панель сети Скального.
        /// </summary>
        public NavigationWithPanal navPanRockyNetwork { get; set; }  
                        
        /// <summary>
        /// Панель сети КУРа.
        /// </summary>
        public NavigationWithPanal navPanLimNetwork { get; set; }        

        /// <summary>
        /// Информационная панель.
        /// </summary>
        public NavigationWithPanal navPanDevelop { get; set; }

        /// <summary>
        /// IP-адресс сервера.
        /// </summary>
        public string ServerIPAddress { get; set; }

        /// <summary>
        /// Время последнего обновления в цикле на сервере.
        /// </summary>
        public DateTime ServerItemUpdateTime { get; set; }

        /// <summary>
        /// IP-адресс клиента.
        /// </summary>
        public string ClientIPAddress { get; set; }

        /// <summary>
        /// Имя клиента.
        /// </summary>
        public string ClientUserName { get; set; }

        /// <summary>
        /// Адрес WCF-службы;
        /// </summary>
        public string WCFEndpointAddress { get; set; }

        /// <summary>
        /// Запущено ли приложение.
        /// </summary>
        public bool ApplicationStarted { get; set; }

        /// <summary>
        /// ID клиентского компьютера.
        /// </summary>
        public string ClientGUID { get; set; }

        /// <summary>
        /// Инициализирована информация о клиенте.
        /// </summary>
        private bool ClientInfoInited { get; set; }

        /// <summary>
        /// Информация о браузере клиента.
        /// </summary>
        public string ClientBrowserInformation { get; set; }

        /// <summary>
        /// Успешна ли синхронизация времени.
        /// </summary>
        public bool DateTimeSyncSuccess { get; set; }

        /// <summary>
        /// Успешна ли синхронизация часового пояса.
        /// </summary>
        public bool DateTimeOffsetSyncSuccess { get; set; }

        /// <summary>
        /// Успешно ли обновление значений.
        /// </summary>
        public bool ItemsUpdateSuccess { get; set; }

        /// <summary>
        /// Активные элементы записей.
        /// </summary>
        public int ItemsRealActivatedCount { get; set; }

        /// <summary>
        /// Список активных записей.
        /// </summary>
        public ObservableCollection<string> ItemsRealDataNameActivated { get; set; }

        /// <summary>
        /// Поток на асинхронный запрос данных.
        /// </summary>
        BackgroundWorker ForceUpdateWorker { get; set; }

        /// <summary>
        /// Событие на синхронизацию времени.
        /// </summary>
        public event EventHandler DateTimeSynchronized;

        /// <summary>
        /// Событие на синхронизацию часового пояса.
        /// </summary>
        public event EventHandler DateTimeOffsetSynchronized;

        /// <summary>
        /// Событие на синхронизацию часового пояса.
        /// </summary>
        public event EventHandler ItemsUpdated;

        /// <summary>
        /// Зажатие Cntr-клавиши.
        /// </summary>
        public bool CtrlPressed;

        /// <summary>
        /// Зажатие Shift-клавиши.
        /// </summary>
        public bool ShiftPressed;

        /// <summary>
        /// Корень графического интерфейса.
        /// </summary>
        public UIElement RootVisual { get; set; }

        /// <summary>
        /// Получение имени текущего пользователя.
        /// </summary>
        private static string GetClientUserName()
        {
            HtmlDocument doc = HtmlPage.Document;

            if (doc == null)
            {
                return string.Empty;
            }

            HtmlElement elm = doc.GetElementById("UsernameField");

            if (elm == null)
            {
                return string.Empty;
            }

            return elm.GetAttribute("value");
        }

        /// <summary>
        /// Получение ID компьютера.
        /// </summary>
        private static string GetClientGUID()
        {
            const string keyname = "ComputerID";
            string key;
            if (System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings.Contains(keyname))
                key = (System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings[keyname] ?? "").ToString();
            else
                key = "";
            if (string.IsNullOrEmpty(key))
            {
                key = Guid.NewGuid().ToString();
                System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings[keyname] = key;
            }
            return key;
        }

        public static void ShowForm(ref DocumentPanel documentPanel, string caption, string uriDirection, Size size, bool activate = true, object owner = null)
        {
            if (documentPanel == null)
            {
                //TrendPanel = Global.Default.DockManager.DockController.AddDocumentPanel(Global.Default.DocumentContainer, new Uri("/WebControl;component/Forms/TrendForm.xaml", UriKind.Relative));
                documentPanel = Global.Default.DockManager.DockController.AddDocumentPanel(new Point(500, 500), size, new Uri(uriDirection, UriKind.Relative));
                documentPanel.Caption = caption;
                if (owner != null)
                {
                    UserControlEx controlEx = (UserControlEx)documentPanel.Control;
                    controlEx.SetOwner(owner);
                }
                Global.Default.DockManager.Activate(documentPanel);
                Global.Default.DockManager.DockController.Float(documentPanel);
            }
            else
            {
                if (activate || documentPanel.Closed)
                {
                    Global.Default.DockManager.DockController.Restore(documentPanel);
                    Global.Default.DockManager.Activate(documentPanel);
                }
            }
        }

        /// <summary>
        /// Создание WCF-клиента.
        /// </summary>
        /// <returns></returns>
        public DataServiceClient CreateDataClient()
        {
            DataServiceClient dataClient = new DataServiceClient();
            dataClient.Endpoint.Address = new System.ServiceModel.EndpointAddress(WCFEndpointAddress);
            dataClient.Endpoint.Binding.OpenTimeout = dataClient.Endpoint.Binding.CloseTimeout = new TimeSpan(0, 0, 3);
            dataClient.Endpoint.Binding.SendTimeout = dataClient.Endpoint.Binding.ReceiveTimeout = new TimeSpan(0, 0, 30);
            return dataClient;
        }

        /// <summary>
        /// Пересоздание WCF-клиента.
        /// </summary>
        private void RecreateDataClient()
        {
            DataClient = CreateDataClient();
            DataClient.GetItemsFullCompleted += DataClient_GetItemsFullCompleted;
            DataClient.GetItemsShortCompleted += DataClient_GetItemsShortCompleted;
            DataClient.GetItemsShortByDataNamesCompleted += DataClient_GetItemsShortByDataNamesCompleted;
            DataClient.GetSqlCurrentTimeCompleted += DataClient_GetSqlCurrentTimeCompleted;
            DataClient.GetDateTimeOffsetCompleted += DataClient_GetDateTimeOffsetCompleted;
            DataClient.SetClientInfoFullCompleted += DataClient_SetClientInfoFullCompleted; 
        }

        /// <summary>
        /// Инициализация переменных.
        /// </summary>
        public void Init()
        {
            Version = "1.42.16";

            Mode = ModeType.Demo;

            T0 = DateTime.Now;

            ClientGUID = GetClientGUID();
            ClientUserName = GetClientUserName();
            ClientIPAddress = "unknown";

            //Автоматическое определение IP-сервера и его WCF-службе подключения в зависимости от режима разработки проекта.
            if (Mode == ModeType.Debug)
                ServerIPAddress = "172.31.106.121";
                //ServerIPAddress = "127.0.0.1";
            else if (Mode == ModeType.Real)
            {
                if (!string.IsNullOrEmpty(Application.Current.Host.Source.Host))
                    ServerIPAddress = Application.Current.Host.Source.Host;
                else
                    ServerIPAddress = "127.0.0.1";
            }

            if (Mode == ModeType.Debug || Mode == ModeType.Real)
            {
                WCFEndpointAddress = string.Format("http://{0}:5555/DataService.svc", ServerIPAddress);
                RecreateDataClient();
            }

            ClientInfoInited = false;

            ApplicationStarted = false;

            ItemsInited = false;

            ShortUpdateTime = new TimeSpan(0, 0, 0);
            
            ClientBrowserInformation = string.Format("{0} v{1} for {2}",
                /*0*/HtmlPage.BrowserInformation.Name,
                /*1*/HtmlPage.BrowserInformation.ProductVersion,
                /*2*/HtmlPage.BrowserInformation.Platform);

            ItemsReal = new Collection<ItemReal>();
            ItemsRealDict = new Dictionary<string, ItemReal>();
            ItemsRealActivated = new Collection<ItemReal>();
            VisualControlDict = new Dictionary<string, int>();

            DoubleUnknown = -1234567.1234;
            UIControls = new Collection<HMISimpleBase>();

            ItemsRealDataNameActivated = new ObservableCollection<string>();


            //ThreadMain = new ThreadTimer() { Period = 5000, Delay = 1000 };
            ThreadMain = new ThreadTimer() { Period = 1000, Delay = 100 };
            ThreadMain.WorkChanged += ThreadMain_WorkChanged;
            ThreadMain.Run();

            ThreadSQLSync = new ThreadTimer() { Period = 3600000 };
            ThreadSQLSync.WorkChanged += ThreadSQLSync_WorkChanged;
            ThreadSQLSync.Run();

            ThreadStatistic = new ThreadTimer() { Period = 60000 };
            ThreadStatistic.WorkChanged += ThreadStatistic_WorkChanged;
            ThreadStatistic.Run();

            ForceUpdateWorker = new BackgroundWorker();
            ForceUpdateWorker.DoWork += ForceUpdateWorker_DoWork;

            CtrlPressed = ShiftPressed = false;
        }

        /// <summary>
        /// Добавление визуального элемента в коллекцию.
        /// </summary>
        public void AddUIControl(HMISimpleBase control)
        {
            UIControls.Add(control);
        }

        /// <summary>
        /// Уведомление об окончании инициализации.
        /// </summary>
        void InvokeUIControlInitItems()
        {
            foreach (HMISimpleBase control in UIControls)
            {
                control.Dispatcher.BeginInvoke(() =>
                {
                    control.InitNew();
                    control.Update();
                });
            }
        }

        /// <summary>
        /// Получение элемента, удовлетворяющего искомому имени.
        /// </summary>
        public ItemReal GetItemReal(string dataName)
        {
            /*
            foreach (ItemReal item in ItemsReal)
                if (item != null && item.DataName == dataName)
                    return item;
             */
            // Для повышения быстродействия.
            if (!string.IsNullOrEmpty(dataName) && ItemsRealDict.ContainsKey(dataName))
                return ItemsRealDict[dataName];
            return null;
        }

        /// <summary>
        /// Генерация общей статистики активных визуальных элементов.
        /// </summary>
        public void CalculateVisualControlStat()
        {
            ItemsRealDataNameActivated.Clear();
            ItemsRealActivated.Clear();
            ItemsRealActivatedCount = 0;

            /*
            foreach (ItemReal item in ItemsReal)
            {
                count = item.GetVisualControlActivatedCount();
                if (count > 0)
                {
                    ItemsRealActivatedCount++;
                    ItemsRealActivated.Add(item);
                    ItemsRealDataNameActivated.Add(item.DataName);
                }
                VisualActivatedCount += count;
            }
             */
            foreach (KeyValuePair<string, int> item in VisualControlDict)
            {
                ItemsRealDataNameActivated.Add(item.Key);
                ItemReal itemReal;
                if (ItemsRealDict.ContainsKey(item.Key))
                    itemReal = ItemsRealDict[item.Key];
                else
                    itemReal = new ItemReal();
                ItemsRealActivated.Add(itemReal);
            }
            ItemsRealActivatedCount = VisualControlDict.Count;
        }

        void ForceUpdateWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            ThreadMain_WorkChanged(sender, EventArgs.Empty);
        }

        /// <summary>
        /// Форсирование события изменения интерфейса.
        /// </summary>
        public void ForceInterfaceChanged(object sender, EventArgs e)
        {
            // Более быстрая реакция
            //ThreadMain_WorkChanged(sender, EventArgs.Empty);

            // Наиболее быстрый вариант
            if (!ForceUpdateWorker.IsBusy)
                ForceUpdateWorker.RunWorkerAsync();

            // Присутствует задержка таймера равная в его Delay.
            //ThreadMain.Force();
        }

        /// <summary>
        /// Серверное время.
        /// </summary>
        public DateTime SqlCurrentTime
        {
            get
            {
                return DateTime.Now + ServerClientTimeDiff;
            }
        }

        /// <summary>
        /// Активация данного элемента при запросе данных.
        /// </summary>
        public void VisualControlActivate(string dataName)
        {
            if (!VisualControlDict.ContainsKey(dataName))
                VisualControlDict.Add(dataName, 0);
        }

        /// <summary>
        /// Деактивация элемента при запросе данных.
        /// </summary>
        public void VisualControlDeactivate(string dataName)
        {
            if (VisualControlDict.ContainsKey(dataName))
                VisualControlDict.Remove(dataName);
        }

        static void GenerateIPAddress(string network, int from, int to, ObservableCollection<ItemSql> collection)
        {
            for (int i = from; i <= to; i++)
            {
                collection.Add(new ItemSql()
                {
                    DataName = string.Format("ping_{0}_{1}_Status", network.Replace('.', '_'), i),
                    Description = string.Format("Узел связи {0}.{1}", network, i),
                    SqlTime = DateTime.Now,
                    DeviceTime = DateTime.Now,
                    DataType = 1,
                    DataValue = 1,
                    MinValue = 0,
                    MaxValue = 1,
                    Trend = true,
                    TimeOut = 20
                });

                collection.Add(new ItemSql()
                {
                    DataName = string.Format("ping_{0}_{1}_ReplyTime", network.Replace('.', '_'), i),
                    Description = string.Format("Узел связи {0}.{1}", network, i),
                    SqlTime = DateTime.Now,
                    DeviceTime = DateTime.Now,
                    DataType = 2,
                    DataValue = 5,
                    MinValue = 0,
                    MaxValue = 1,
                    Trend = true,
                    TimeOut = 20
                });
            }
        }

        static void GetASOPItem(int index, string postfix, ObservableCollection<ItemSql> collection, string unit = "")
        {
            collection.Add(
            new ItemSql()
            {
                DataName = string.Format("Angidrit_asop_FA000SD{0:D2}{1}", index, postfix),
                Description = string.Format("Переменная АСОП. Станция {0}", index),
                SqlTime = DateTime.Now,
                DeviceTime = DateTime.Now,
                DataType = 2,
                DataValue = 1,
                MinValue = 0,
                MaxValue = 1,
                Trend = true,
                TimeOut = 20,
                Unit = unit,
                FormatValue = "0.00"
            }
            );

            collection.Add(
            new ItemSql()
            {
                DataName = string.Format("Angidrit_asop_FA000SD{0:D2}{1}_F", index, postfix),
                Description = string.Format("Переменная АСОП. Станция {0}", index),
                SqlTime = DateTime.Now,
                DeviceTime = DateTime.Now,
                DataType = 1,
                DataValue = 1,
                MinValue = 0,
                MaxValue = 1,
                Trend = true,
                TimeOut = 20
            }
            );
        }

        static void GenerateASOP(ObservableCollection<ItemSql> collection)
        {
            for (int i = 1; i <= 10; i++)
            {
                GetASOPItem(i, "CO", collection, "ppm");
                GetASOPItem(i, "V", collection, "м/c");
                GetASOPItem(i, "T", collection, "C");
                GetASOPItem(i, "DT", collection);
                GetASOPItem(i, "SM", collection);
            }
        }

        ObservableCollection<ItemSql> GetDemoItemSqls()
        {
            ObservableCollection<ItemSql> results = new ObservableCollection<ItemSql>();

            // Рудоуправление.
            GenerateIPAddress("172.31.106", 1, 255, results);

            // Ангидрит.
            GenerateIPAddress("172.24.92", 1, 255, results);

            // Известняки.
            GenerateIPAddress("172.24.43", 193, 255, results);

            // Скальный.
            GenerateIPAddress("172.24.88", 65, 94, results);

            // Кайерканский.
            GenerateIPAddress("172.24.228", 1, 128, results);

            // КУР.
            GenerateIPAddress("172.31.71", 1, 255, results);

            // Межсеть.
            GenerateIPAddress("172.24.251", 1, 255, results);
            GenerateIPAddress("172.24.254", 1, 255, results);
            GenerateIPAddress("172.31.127", 1, 255, results);

            GenerateASOP(results);

            return results;
        }

        ObservableCollection<ItemSqlSimple> GetDemoItemSqlSimples(ObservableCollection<string> ItemsRealDataNameActivated)
        {
            ObservableCollection<ItemSqlSimple> results = new ObservableCollection<ItemSqlSimple>();

            // Имитация передачи первой записи.
            results.Add(new ItemSqlSimple()
            {
                SqlTime = DateTime.Now
            });

            Random random = new Random();
            int currentStatus = 0;

            foreach (var item in ItemsRealDataNameActivated)
            {

                if (item.Contains("_Status"))
                {
                    currentStatus = random.Next(0, 2);

                    results.Add(new ItemSqlSimple()
                    {
                        SqlTime = DateTime.Now,
                        DeviceTime = DateTime.Now,
                        DataValue = currentStatus,
                        Quality = 192
                    });
                }

                else if (item.Contains("_ReplyTime"))
                {
                    results.Add(new ItemSqlSimple()
                    {
                        SqlTime = DateTime.Now,
                        DeviceTime = DateTime.Now,
                        DataValue = currentStatus == 1 ? random.Next(0, 25) : -1,
                        Quality = 192
                    });
                }
                else if (item.Replace("_FA", "").Contains("_F") || item.Contains("DT") || item.Contains("SM"))
                {
                    results.Add(new ItemSqlSimple()
                    {
                        SqlTime = DateTime.Now,
                        DeviceTime = DateTime.Now,
                        DataValue = random.Next(0, 2),
                        Quality = 192
                    });
                }
                else if (item.Contains("Angidrit_asop"))
                {
                    results.Add(new ItemSqlSimple()
                    {
                        SqlTime = DateTime.Now,
                        DeviceTime = DateTime.Now,
                        DataValue = random.Next(0, 50) + random.NextDouble(),
                        Quality = 192
                    });
                }
            }
            return results;
        }
        /// <summary>
        /// Основная функция, которая выполняется в главном потоке.
        /// </summary>
        void ThreadMain_WorkChanged(object sender, EventArgs e)
        {
            CalculateVisualControlStat();
            if (!ItemsInited)
            {
                if (!InitItemsBusy)
                {
                    ItemsReal.Clear();
                    ItemsRealDict.Clear();
                    if (Mode == ModeType.Real || Mode == ModeType.Debug)
                    {
                        DataClient.GetItemsFullAsync();
                        DataClient.GetSqlCurrentTimeAsync();
                        DataClient.GetDateTimeOffsetAsync();
                    }
                    else
                    {
                        DataClient_GetItemsFullCompleted(this, 
                            new GetItemsFullCompletedEventArgs(new object[] { GetDemoItemSqls() }, null, false, null));

                        DataClient_GetSqlCurrentTimeCompleted(this,
                            new GetSqlCurrentTimeCompletedEventArgs(new object[] { DateTime.Now}, null, false, null));

                        DataClient_GetDateTimeOffsetCompleted(this,
                            new GetDateTimeOffsetCompletedEventArgs(new object[] { new DateTimeOffset(DateTime.Now) }, null, false, null));
                    }
                    InitItemsBusy = true;
                }
            }
            if (ItemsInited)
            {
                T0Short = DateTime.Now;
                //DataClient.GetItemsShortAsync();

                if (Mode == ModeType.Real || Mode == ModeType.Debug)
                {
                    DataClient.GetItemsShortByDataNamesAsync(ItemsRealDataNameActivated);
                }
                else
                {
                    DataClient_GetItemsShortByDataNamesCompleted(this,
                        new GetItemsShortByDataNamesCompletedEventArgs(new object[] { GetDemoItemSqlSimples(ItemsRealDataNameActivated) }, null, false, null));
                }
            }

            if (sender == ThreadMain)
                Thread.Sleep((int)ShortUpdateTime.TotalMilliseconds + 10);
        }

        /// <summary>
        /// Обработчик события на завершение вызова функции инициализации элементов.
        /// </summary>
        void DataClient_GetItemsFullCompleted(object sender, GetItemsFullCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                foreach (ItemSql itemReal in e.Result)
                {
                    ItemReal item = new ItemReal()
                    {
                        DataName = itemReal.DataName,
                        Trend = itemReal.Trend,
                        Description = itemReal.Description,
                        Unit = itemReal.Unit,
                        FormatValue = itemReal.FormatValue,
                        MinValue = itemReal.MinValue,
                        MaxValue = itemReal.MaxValue,
                        DataType = (ItemReal.DataTypeSimple)itemReal.DataType,
                        DataValue = itemReal.DataValue,
                        Quality = itemReal.Quality,
                        SqlTime = itemReal.SqlTime,
                        DeviceTime = itemReal.DeviceTime,
                        TimeOut = itemReal.TimeOut,
                        Comment = itemReal.Comment
                    };
                    ItemsReal.Add(item);
                    ItemsRealDict.Add(itemReal.DataName, item);
                }
                if (e.Result.Count > 0)
                {
                    ItemsInited = true;
                    InvokeUIControlInitItems();
                }
            }
            else
            {
                InitFaultCount++;
                ItemsInited = false;
                if (Mode == ModeType.Real || Mode == ModeType.Debug)
                    RecreateDataClient();
            }
            InitItemsBusy = false;
            LoadTime = DateTime.Now - T0;
        }

        /// <summary>
        /// Обработчик события на завершение вызова функции обновления элементов.
        /// </summary>
        void DataClient_GetItemsShortCompleted(object sender, GetItemsShortCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (ItemsReal.Count == e.Result.Count)
                {
                    for (int i = 0; i < e.Result.Count; i++)
                    {
                        ItemsReal[i].DataValue = e.Result[i].DataValue;
                        ItemsReal[i].Quality = e.Result[i].Quality;
                        ItemsReal[i].SqlTime = e.Result[i].SqlTime;
                        ItemsReal[i].DeviceTime = e.Result[i].DeviceTime;
                    }

                    ItemsUpdateSuccess = true;
                }
                else
                {
                    UpdatFaultCount++;
                    ItemsInited = false;
                    ItemsUpdateSuccess = false;
                }

                ItemUpdateTime = SqlCurrentTime;
            }
            else
            {
                UpdatFaultCount++;
                ItemsUpdateSuccess = false;
            }

            // Удедомление интерфейсного потока о завершении обновления элементов.
            MainForm.Dispatcher.BeginInvoke(() =>
            {
                if (ItemsUpdated != null)
                    ItemsUpdated(null, null);
            });

            ShortUpdateTime = DateTime.Now - T0Short;
        }

        /// <summary>
        /// Обработчик события на завершение вызова функции выборочного обновления элементов.
        /// </summary>
        void DataClient_GetItemsShortByDataNamesCompleted(object sender, GetItemsShortByDataNamesCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result.Count > 0 &&
                    ItemsRealDataNameActivated.Count + 1 == e.Result.Count)
                {
                    ServerItemUpdateTime = e.Result[0].SqlTime - ServerClientTimeZoneDiff;

                    for (int i = 0; i < ItemsRealDataNameActivated.Count; i++)
                    {
                        /*
                        ItemReal itemReal = GetItemReal(ItemsRealDataNameActivated[i]);
                        if (itemReal != null)
                        {
                            itemReal.DataValue = e.Result[i].DataValue;
                            itemReal.Quality = e.Result[i].Quality;
                            itemReal.SqlTime = e.Result[i].SqlTime;
                            itemReal.DeviceTime = e.Result[i].DeviceTime;
                        }
                         */
                        ItemsRealActivated[i].DataValue = e.Result[i + 1].DataValue;
                        ItemsRealActivated[i].Quality = e.Result[i + 1].Quality;
                        ItemsRealActivated[i].SqlTime = e.Result[i + 1].SqlTime;
                        ItemsRealActivated[i].DeviceTime = e.Result[i + 1].DeviceTime;
                    }

                    ItemsUpdateSuccess = true;
                    ItemUpdateTime = SqlCurrentTime;
                    ItemUpdateTimeDiff = ItemUpdateTime - ServerItemUpdateTime;
                }
            }
            else
            {
                UpdatFaultCount++;
                ItemsUpdateSuccess = false;
            }

            // Удедомление интерфейсного потока о завершении обновления элементов.
            if (MainForm != null)
                MainForm.Dispatcher.BeginInvoke(() =>
                {
                    if (ItemsUpdated != null)
                        ItemsUpdated(null, null);
                });

            ShortUpdateTime = DateTime.Now - T0Short;
        }


        void ThreadSQLSync_WorkChanged(object sender, EventArgs e)
        {
            if (Mode == ModeType.Real || Mode == ModeType.Debug)
            {

                DataClient.GetSqlCurrentTimeAsync();
                DataClient.GetDateTimeOffsetAsync();
            }
        }

        void DataClient_GetSqlCurrentTimeCompleted(object sender, GetSqlCurrentTimeCompletedEventArgs e)
        {
            if (e.Error == null)
                if (e.Result != DateTime.MinValue)
                {
                    ServerClientTimeDiff = e.Result - DateTime.Now;
                    DateTimeSyncSuccess = true;
                }
                else
                    DateTimeSyncSuccess = false;
            else
                DateTimeSyncSuccess = false;

            if (MainForm != null)
                MainForm.Dispatcher.BeginInvoke(() =>
                {
                    if (DateTimeSynchronized != null)
                        DateTimeSynchronized(null, null);
                });
        }

        void DataClient_GetDateTimeOffsetCompleted(object sender, GetDateTimeOffsetCompletedEventArgs e)
        {
            if (e.Error == null)
                if (e.Result.DateTime != DateTime.MinValue)
                {
                    ServerClientTimeZoneDiff = DateTimeOffset.Now.Offset - e.Result.Offset;
                    DateTimeOffsetSyncSuccess = true;
                }
                else
                    DateTimeOffsetSyncSuccess = false;
            else
                DateTimeOffsetSyncSuccess = false;

            if (MainForm != null)
                MainForm.Dispatcher.BeginInvoke(() =>
                {
                    if (DateTimeOffsetSynchronized != null)
                        DateTimeOffsetSynchronized(null, null);
                });
        }

        void ThreadStatistic_WorkChanged(object sender, EventArgs e)
        {
            if (Mode == ModeType.Real || Mode == ModeType.Debug)
            {
                if (ApplicationStarted)
                {
                    if (!ClientInfoInited)
                        DataClient.SetClientInfoFullAsync(ClientGUID, ClientIPAddress, Version, DateTime.Now, ClientBrowserInformation);

                    if (ClientInfoInited)
                        DataClient.SetClientInfoShortAsync(ClientGUID, DateTime.Now);
                }
            }
        }

        void DataClient_SetClientInfoFullCompleted(object sender, SetClientInfoFullCompletedEventArgs e)
        {
            if (e.Error == null) 
                ClientInfoInited = e.Result;
        }
    }

    class Global
    {
        private readonly static GlobalDefault defaultInstance = new GlobalDefault();
        public static GlobalDefault Default { get { return defaultInstance; } }
    }
}
