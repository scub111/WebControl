using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using WebControl.DataServiceReference;
using System.Windows.Media.Imaging;
using DevExpress.Xpf.Printing;
using System.Windows.Data;
using System.Threading.Tasks;
using System.Threading;

namespace WebControl
{
    public partial class TrendForm : UserControlEx
    {
        public TrendForm()
        {
            InitializeComponent();
            OnlineUpdate = true;
            TrendInited = false;
            Trends = new Collection<ItemSqlTrend>();

            if (Global.Default.Mode == ModeType.Real || Global.Default.Mode == ModeType.Debug)
            {
                DataClient = Global.Default.CreateDataClient();
                DataClient.GetTrendsCompleted += DataClient_GetTrendsCompleted;
            }

            InitTimeT0 = Global.Default.SqlCurrentTime;
            Count10s = Count1m = Count10m = Count1h = Count6h = Count1d = 1;
            Enter10s = Enter1m = Ent10m = Enter1h = Enter6h = Enter1d = false;

            TimePeriodAuto = true;
            PointCounMax = 1500;

            DateEditComplete = true;
        }

        DataServiceClient DataClient { get; set; }

        HMIBooleanBase HmiBoolean { get; set; }

        /// <summary>
        /// Начальное значение времени.
        /// </summary>
        DateTime T0 { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            deBegin.EditValue = Global.Default.SqlCurrentTime - new TimeSpan(1, 0, 0);
            deEnd.EditValue = Global.Default.SqlCurrentTime;

            if (Global.Default.Mode == ModeType.Demo)
            {
                btnTimePeriodAuto_Click(this, null);
                cbeTimePeriod.SelectedIndex = 1;
            }

            UpdateChart();
        }

        /// <summary>
        /// Реальный объект.
        /// </summary>
        ItemReal Item { get; set; }

        /// <summary>
        /// Элемент-владелец.
        /// </summary>
        HMISimpleBase HMIBase { get; set; }

        /*
        public void SetOwner(HMISimpleBase hmiBase)
        {
            HMIBase = hmiBase;
            Item = hmiBase.Item;
            if (hmiBase is HMIBooleanBase)
                HmiBoolean = hmiBase as HMIBooleanBase;
            SqlTimeLast = Item.SqlTime;
            chart1.ValueFormatString = Item.FormatValue;
        }
         */

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
                SqlTimeLast = Item.SqlTime;
                chrBase.ValueFormatString = Item.FormatValue;
            }
        }

        /// <summary>
        /// Коллекция значений тренда.
        /// </summary>
        //ObservableCollection<ItemSqlTrend> Trends { get; set; }
        Collection<ItemSqlTrend> Trends;

        /// <summary>
        /// Инициирован тренд.
        /// </summary>
        bool TrendInited { get; set; }

        /// <summary>
        /// Автообновление.
        /// </summary>
        bool OnlineUpdate { get; set; }

        /// <summary>
        /// Последнее значение времени при запросе.
        /// </summary>
        DateTime SqlTimeLast { get; set; }

        /// <summary>
        /// Период запроса.
        /// </summary>
        TimeSpan TimeDistance
        {
            get
            {
                return (DateTime)deEnd.EditValue - (DateTime)deBegin.EditValue;
            }
        }

        /// <summary>
        /// Начальное время запуска.
        /// </summary>
        DateTime InitTimeT0 { get; set; }

        /// <summary>
        /// Разница во времени.
        /// </summary>
        TimeSpan TimePeriodDiff { get; set; }

        /// <summary>
        /// Счетчик для 10 секунд.
        /// </summary>
        int Count10s { get; set; }

        /// <summary>
        /// Вхождение в 10 секунд.
        /// </summary>
        bool Enter10s { get; set; }

        /// <summary>
        /// Счетчик для 60 секунд.
        /// </summary>
        int Count1m { get; set; }

        /// <summary>
        /// Вхождение в 60 секунд.
        /// </summary>
        bool Enter1m { get; set; }

        /// <summary>
        /// Счетчик для 600 секунд.
        /// </summary>
        int Count10m { get; set; }

        /// <summary>
        /// Вхождение в 600 секунд.
        /// </summary>
        bool Ent10m { get; set; }

        /// <summary>
        /// Счетчик для 3600 секунд.
        /// </summary>
        int Count1h { get; set; }

        /// <summary>
        /// Вхождение в 3600 секунд.
        /// </summary>
        bool Enter1h { get; set; }

        /// <summary>
        /// Счетчик для 21600 секунд.
        /// </summary>
        int Count6h { get; set; }

        /// <summary>
        /// Вхождение в 21600 секунд.
        /// </summary>
        bool Enter6h { get; set; }

        /// <summary>
        /// Счетчик для 86400 секунд.
        /// </summary>
        int Count1d { get; set; }

        /// <summary>
        /// Вхождение в 21600 секунд.
        /// </summary>
        bool Enter1d { get; set; }

        /// <summary>
        /// Автоматический выбор периода времени выборки.
        /// </summary>
        bool TimePeriodAuto { get; set; }

        /// <summary>
        /// Максималное количество выводимых точек на тренде при автоматическом расчете периода времени.
        /// </summary>
        int PointCounMax { get; set; }

        /// <summary>
        /// Завершение работы элементов редактирования дат.
        /// </summary>
        bool DateEditComplete { get; set; }

        ItemSqlTrends GenerateDemoTrens()
        {

            ItemSqlTrends result = new ItemSqlTrends();
            result.Records = new ObservableCollection<ItemSqlTrend>();

            Random random = new Random();
            TimeSpan tsHour = new TimeSpan(1, 0, 0);
            DateTime starTime = DateTime.Now - tsHour;

            double minValue = 0;
            double maxValue = 0;

            for (int i = 0; i < 360; i++)
            {
                ItemSqlTrend trend = new ItemSqlTrend();
                trend.SqlTime = starTime + new TimeSpan(0, 0, 10 * i);

                switch (Item.DataType)
                {
                    case ItemReal.DataTypeSimple.Boolean:
                        trend.DataValue = random.Next(0, 2);
                        break;
                    case ItemReal.DataTypeSimple.Integer:
                        trend.DataValue = random.Next(0, 50);
                        break;
                    case ItemReal.DataTypeSimple.Real:
                        trend.DataValue = random.Next(0, 50) + random.NextDouble();
                        break;
                }

                if (trend.DataValue < minValue)
                    minValue = trend.DataValue;

                if (trend.DataValue > maxValue)
                    maxValue = trend.DataValue;

                result.Records.Add(trend);
            }

            result.MinValue = minValue;
            result.MaxValue = maxValue;

            return result;
        }

        /// <summary>
        /// Обновление тренда.
        /// </summary>
        private void UpdateChart()
        {
            lblStatus.Text = "Запрос данных...";
            T0 = DateTime.Now;
            ckUpdate.Visibility = System.Windows.Visibility.Visible;

            int timePeriod = cbeTimePeriod.SelectedIndex;

            if (Global.Default.Mode == ModeType.Real || Global.Default.Mode == ModeType.Debug)
                DataClient.GetTrendsAsync(
                    Item.DataName,
                    (int)Item.DataType,
                    (DateTime)deBegin.EditValue + Global.Default.ServerClientTimeZoneDiff,
                    (DateTime)deEnd.EditValue + Global.Default.ServerClientTimeZoneDiff,
                    timePeriod);
            else
            {
                Task task = new Task(() => 
                {
                    Random random = new Random();

                    Thread.Sleep(random.Next(300, 800));
                    this.Dispatcher.BeginInvoke(() =>
                    {
                        DataClient_GetTrendsCompleted(this,
                            new GetTrendsCompletedEventArgs(new object[] { GenerateDemoTrens() }, null, false, null));
                    });
                });
                task.Start();
            }
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
        /// Получение значения периода времени.
        /// </summary>
        short GetTimePeriod()
        {
            TimePeriodDiff = Global.Default.SqlCurrentTime - InitTimeT0;

            Enter10s = Enter1m = Ent10m = Enter1h = Enter6h = Enter1d = false;

            if (TimePeriodDiff.TotalSeconds >= Count10s * 10)
            {
                Count10s++;
                Enter10s = true;
            }
            if (TimePeriodDiff.TotalSeconds >= Count1m * 60)
            {
                Count1m++;
                Enter1m = true;
            }
            if (TimePeriodDiff.TotalSeconds >= Count10m * 600)
            {
                Count10m++;
                Ent10m = true;
            }
            if (TimePeriodDiff.TotalSeconds >= Count1h * 3600)
            {
                Count1h++;
                Enter1h = true;
            }
            if (TimePeriodDiff.TotalSeconds >= Count6h * 21600)
            {
                Count6h++;
                Enter6h = true;
            }
            if (TimePeriodDiff.TotalSeconds >= Count1d * 86400)
            {
                Count1d++;
                Enter1d = true;
            }

            if (Enter1d)
                return 6;
            if (Enter6h)
                return 5;
            else if (Enter1h)
                return 4;
            else if (Ent10m)
                return 3;
            else if (Enter1m)
                return 2;
            else if (Enter10s)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// Расчет необходимого периода времени.
        /// </summary>
        public static int CalculateTimePeriod(DateTime dateBegin, DateTime dateEnd, int pointCounMax)
        {
            TimeSpan diff = dateEnd - dateBegin;
            double count = diff.TotalSeconds / 5.0;

            if (count < pointCounMax)
                return 0;
            else if (count < pointCounMax * 2)
                return 1;
            else if (count < pointCounMax * 2 * 6)
                return 2;
            else if (count < pointCounMax * 2 * 6 * 10)
                return 3;
            else if (count < pointCounMax * 2 * 6 * 10 * 6)
                return 4;
            else if (count < pointCounMax * 2 * 6 * 10 * 6 * 6)
                return 5;
            return 5;
        }

        /// <summary>
        /// Расчет необходимого периода времени с элементами интерфейса.
        /// </summary>
        void CalculateTimePeriodAndDistance()
        {
            if (Visible && deEnd.EditValue != null && deBegin.EditValue != null)
                if (TimePeriodAuto)
                    cbeTimePeriod.SelectedIndex = CalculateTimePeriod((DateTime)deBegin.EditValue, (DateTime)deEnd.EditValue, PointCounMax);

            if (deBegin.EditValue != null && deEnd.EditValue != null)
            {
                TimeSpan distace = new TimeSpan(TimeDistance.Days, TimeDistance.Hours, TimeDistance.Minutes, TimeDistance.Seconds);
                if (distace == new TimeSpan(1, 0, 0))
                    cbeTimeDistance.SelectedIndex = 1;
                else if (distace == new TimeSpan(8, 0, 0))
                    cbeTimeDistance.SelectedIndex = 2;
                else if (distace == new TimeSpan(1, 0, 0, 0))
                    cbeTimeDistance.SelectedIndex = 3;
                else if (distace == new TimeSpan(7, 0, 0, 0))
                    cbeTimeDistance.SelectedIndex = 4;
                else if (distace == new TimeSpan(31, 0, 0, 0))
                    cbeTimeDistance.SelectedIndex = 5;
                else if (distace == new TimeSpan(365, 0, 0, 0))
                    cbeTimeDistance.SelectedIndex = 6;
                else
                    cbeTimeDistance.SelectedIndex = 0;
            }

        }

        /// <summary>
        /// Запрос обновления из вне.
        /// </summary>
        public void UpdateExternal()
        {
            short timePeriodCurrent = GetTimePeriod();
            if (Visible && OnlineUpdate && TrendInited)
            {
                if (SqlTimeLast != Item.SqlTime)
                {
                    if (timePeriodCurrent >= cbeTimePeriod.SelectedIndex)
                    {
                        DateTime t00 = DateTime.Now;
                        chrBase.DataSource = null;

                        // Добавление актуального значения.
                        ItemSqlTrend item = new ItemSqlTrend()
                        {
                            DataValue = GetCorrectDataValue(Item.DataValue),
                            SqlTime = Item.SqlTime,
                        };
                        Trends.Add(item);

                        // Очистка от неактуальных значений.
                        for (int i = 0; i < Trends.Count; i++)
                        {
                            if (Trends[i].SqlTime < Global.Default.SqlCurrentTime - TimeDistance ||
                                Trends[i].SqlTime > Global.Default.SqlCurrentTime)
                                Trends.RemoveAt(i);
                        }

                        chrBase.DataSource = Trends;

                        TimeSpan diff2 = DateTime.Now - t00;

                        lblStatus.Text = string.Format("Сейчас {0} значений (отрисовка за {1} мс)", Trends.Count, diff2.TotalMilliseconds.ToString("0"));

                        deBegin.EditValue = Global.Default.SqlCurrentTime - TimeDistance;
                        deEnd.EditValue = Global.Default.SqlCurrentTime;
                    }
                    SqlTimeLast = Item.SqlTime;
                }
            }
        }

        void DataClient_GetTrendsCompleted(object sender, DataServiceReference.GetTrendsCompletedEventArgs e)
        {
            if (e.Error == null) 
            {
                DateTime t00 = DateTime.Now;
                chrBase.DataSource = null;
                Trends.Clear();
                foreach (ItemSqlTrend record in e.Result.Records)
                {
                    ItemSqlTrend item = new ItemSqlTrend();
                    item.DataValue = GetCorrectDataValue(record.DataValue);
                    item.SqlTime = record.SqlTime;
                    Trends.Add(item);
                }
                TrendInited = true;
                chrBase.DataSource = Trends;

                TimeSpan diff1 = DateTime.Now - T0;
                TimeSpan diff2 = DateTime.Now - t00;

                lblStatus.Text = string.Format("Получено {0} значений за {1} мс (отрисовка за {2} мс)", 
                                                e.Result.Records.Count, 
                                                diff1.TotalMilliseconds.ToString("0"), 
                                                diff2.TotalMilliseconds.ToString("0"));
            }
            else
            {
                lblStatus.Text = "Ошибка запроса";
            }
            ckUpdate.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateChart();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan timePeriod = TimeDistance;
            deEnd.EditValue = deBegin.EditValue;
            deBegin.EditValue = (DateTime)deEnd.EditValue - timePeriod;
            UpdateChart();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan timeDistance = TimeDistance;
            deBegin.EditValue = deEnd.EditValue;
            deEnd.EditValue = (DateTime)deBegin.EditValue + timeDistance;
            UpdateChart();
        }

        private void btnStartPause_Click(object sender, RoutedEventArgs e)
        {
            OnlineUpdate = !OnlineUpdate;

            if (OnlineUpdate)
            {
                deBegin.EditValue = Global.Default.SqlCurrentTime - TimeDistance;
                deEnd.EditValue = Global.Default.SqlCurrentTime;
                UpdateChart();
            }
            else
                TrendInited = false;

            deBegin.IsEnabled = !OnlineUpdate;
            deEnd.IsEnabled = !OnlineUpdate;
            btnUpdate.IsEnabled = !OnlineUpdate;
            btnBack.IsEnabled = !OnlineUpdate;
            btnForward.IsEnabled = !OnlineUpdate;
            btnTimePeriodAuto.IsEnabled = !OnlineUpdate;
            if (!TimePeriodAuto)
                cbeTimePeriod.IsEnabled = !OnlineUpdate;

            if (OnlineUpdate)
                btnStartPause.ImageSource = new BitmapImage(new Uri("/WebControl;component/Images/Pause.png", UriKind.RelativeOrAbsolute));
            else
                btnStartPause.ImageSource = new BitmapImage(new Uri("/WebControl;component/Images/Start.png", UriKind.RelativeOrAbsolute));
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            DateTime dtBegin = (DateTime)deBegin.EditValue;
            DateTime dtEnd = (DateTime)deEnd.EditValue;
            string formatString = "dd.MM.yy HH_mm";

            DocumentPreviewWindow preview = new DocumentPreviewWindow();
            CollectionViewLink link = new CollectionViewLink();
            link.PrintingSystem.ExportOptions.PrintPreview.DefaultExportFormat = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXlsx;
            link.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = string.Format("{0} (с {1} по {2})", Item.Description, dtBegin.ToString(formatString), dtEnd.ToString(formatString));
            link.PaperKind = DevExpress.Xpf.Drawing.Printing.PaperKind.A4;
            link.Margins.Bottom = link.Margins.Top = link.Margins.Left = link.Margins.Right = 10;
            link.ExportServiceUri = string.Format("http://{0}/ExportService.svc", Global.Default.ServerIPAddress);
            LinkPreviewModel model = new LinkPreviewModel(link);

            CollectionViewSource collectionViewSource = new CollectionViewSource
            {
                Source = Trends
            };

            link.CollectionView = collectionViewSource.View;

            link.DetailTemplate = (DataTemplate)Resources["trendDataTemplate"];
            link.ReportHeaderTemplate = (DataTemplate)Resources["trendHeaderTemplate"];

            preview.Model = model;
            link.CreateDocument(false);
            preview.ShowDialog();
        }

        private void btnTimePeriodAuto_Click(object sender, RoutedEventArgs e)
        {
            TimePeriodAuto = !TimePeriodAuto;
            if (TimePeriodAuto)
                btnTimePeriodAuto.ImageSource = new BitmapImage(new Uri("/WebControl;component/Images/Alarm_yes.png", UriKind.RelativeOrAbsolute));
            else
                btnTimePeriodAuto.ImageSource = new BitmapImage(new Uri("/WebControl;component/Images/Alarm_no.png", UriKind.RelativeOrAbsolute));

            cbeTimePeriod.IsEnabled = !TimePeriodAuto;
            if (TimePeriodAuto)
                CalculateTimePeriodAndDistance();
        }

        private void deBegin_EditValueChanging(object sender, DevExpress.Xpf.Editors.EditValueChangingEventArgs e)
        {
            DateEditComplete = false;
            CalculateTimePeriodAndDistance();
        }

        private void deEnd_EditValueChanging(object sender, DevExpress.Xpf.Editors.EditValueChangingEventArgs e)
        {
            DateEditComplete = false;
            CalculateTimePeriodAndDistance();
        }

        public void ChangeBeginTime(TimeSpan distance)
        {
            deBegin.EditValue = ((DateTime)deEnd.EditValue) - distance;
            if (OnlineUpdate)
                UpdateChart();
        }

        private void cbeTimeDistance_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            if (DateEditComplete)
                switch (cbeTimeDistance.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        ChangeBeginTime(new TimeSpan(1, 0, 0));
                        break;
                    case 2:
                        ChangeBeginTime(new TimeSpan(8, 0, 0));
                        break;
                    case 3:
                        ChangeBeginTime(new TimeSpan(1, 0, 0, 0));
                        break;
                    case 4:
                        ChangeBeginTime(new TimeSpan(7, 0, 0, 0));
                        break;
                    case 5:
                        ChangeBeginTime(new TimeSpan(31, 0, 0, 0));
                        break;
                    case 6:
                        ChangeBeginTime(new TimeSpan(365, 0, 0, 0));
                        break;
                }
        }

        private void deBegin_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            DateEditComplete = true;
        }

        private void deEnd_EditValueChanged(object sender, DevExpress.Xpf.Editors.EditValueChangedEventArgs e)
        {
            DateEditComplete = true;
        }
    }
}