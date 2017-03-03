using DevExpress.Xpf.Docking;
using DevExpress.Xpf.Printing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WebControl.DataServiceReference;

namespace WebControl
{
    public partial class AngidritMTBView : ViewBase
    {
        public AngidritMTBView()
        {
            InitializeComponent();

            OnlineUpdate = true;

            deBegin.EditValue = Global.Default.SqlCurrentTime - new TimeSpan(24, 0, 0);
            deEnd.EditValue = Global.Default.SqlCurrentTime;

            if (Global.Default.Mode == ModeType.Real || Global.Default.Mode == ModeType.Debug)
            {
                DataClient = Global.Default.CreateDataClient();
                DataClient.GetMTBTIDELOGsCompleted += DataClient_GetMTBTIDELOGsCompleted;
            }
        }

        /// <summary>
        /// Автообновление.
        /// </summary>
        bool OnlineUpdate { get; set; }

        /// <summary>
        /// Объект связи с БД.
        /// </summary>
        DataServiceClient DataClient { get; set; }

        /// <summary>
        /// Основной таймер.
        /// </summary>
        ThreadTimer Timer { get; set; }

        /// <summary>
        /// Начальное значение времени.
        /// </summary>
        DateTime T0 { get; set; }

        /// <summary>
        /// Период запроса.
        /// </summary>
        TimeSpan TimePeriod
        {
            get
            {
                return (DateTime)deEnd.EditValue - (DateTime)deBegin.EditValue;
            }
        }

        /// <summary>
        /// Окно экспорта.
        /// </summary>
        public DocumentPanel ExportDocumentPanel;

        /// <summary>
        /// Обновление данных.
        /// </summary>
        private void UpdateData()
        {
            lblStatus.Text = "Запрос данных...";
            T0 = DateTime.Now;
            ckUpdate.Visibility = System.Windows.Visibility.Visible;
            if (Global.Default.Mode == ModeType.Real || Global.Default.Mode == ModeType.Debug)
            {
                DataClient.GetMTBTIDELOGsAsync("_Angidrit_MTB_TIDELOG", (DateTime)deBegin.EditValue + Global.Default.ServerClientTimeZoneDiff, (DateTime)deEnd.EditValue + Global.Default.ServerClientTimeZoneDiff);
            }
        }

        void DataClient_GetMTBTIDELOGsCompleted(object sender, GetMTBTIDELOGsCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                DateTime t00 = DateTime.Now;

                gridControl.ItemsSource = e.Result;

                TimeSpan diff1 = DateTime.Now - T0;
                TimeSpan diff2 = DateTime.Now - t00;

                lblStatus.Text = string.Format("Получено {0} значений за {1} мс (отрисовка за {2} мс)", 
                                                e.Result.Count, 
                                                diff1.TotalMilliseconds.ToString("0"), 
                                                diff2.TotalMilliseconds.ToString("0"));
            }
            else
            {
                lblStatus.Text = "Ошибка запроса";
            }
            ckUpdate.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void AngidritMTBView_Loaded(object sender, RoutedEventArgs e)
        {
            Timer = new ThreadTimer();
            Timer.Period = 120000;
            Timer.InterfaceChanged += Timer_InterfaceChanged;
            Timer.Run();

            UpdateData();        
        }

        void Timer_InterfaceChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (OnlineUpdate)
                {
                    deBegin.EditValue = Global.Default.SqlCurrentTime - TimePeriod;
                    deEnd.EditValue = Global.Default.SqlCurrentTime;
                    UpdateData();
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }

        private void btnStartPause_Click(object sender, RoutedEventArgs e)
        {
            OnlineUpdate = !OnlineUpdate;

            if (OnlineUpdate)
            {
                deBegin.EditValue = Global.Default.SqlCurrentTime - TimePeriod;
                deEnd.EditValue = Global.Default.SqlCurrentTime;
                UpdateData();
            }

            deBegin.IsEnabled = !OnlineUpdate;
            deEnd.IsEnabled = !OnlineUpdate;
            btnUpdate.IsEnabled = !OnlineUpdate;
            btnBack.IsEnabled = !OnlineUpdate;
            btnForward.IsEnabled = !OnlineUpdate;
            if (OnlineUpdate)
                imgStartPause.Source = new BitmapImage(new Uri("/WebControl;component/Images/Pause.png", UriKind.RelativeOrAbsolute));
            else
                imgStartPause.Source = new BitmapImage(new Uri("/WebControl;component/Images/Start.png", UriKind.RelativeOrAbsolute));
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan timePeriod = TimePeriod;
            deEnd.EditValue = deBegin.EditValue;
            deBegin.EditValue = (DateTime)deEnd.EditValue - timePeriod;
            UpdateData();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan timePeriod = TimePeriod;
            deBegin.EditValue = deEnd.EditValue;
            deEnd.EditValue = (DateTime)deBegin.EditValue + timePeriod;
            UpdateData();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            //Global.Default.ShowForm(ref ExportDocumentPanel, "Форма экспорта данных.", "/WebControl;component/Forms/DataGridExport.xaml", new Size(800, 600), true, this);

            DateTime dtBegin = (DateTime)deBegin.EditValue;
            DateTime dtEnd = (DateTime)deEnd.EditValue;
            string formatString = "dd.MM.yy HH_mm";

            DocumentPreviewWindow preview = new DocumentPreviewWindow();
            PrintableControlLink link = new PrintableControlLink(gridControl.View as DevExpress.Xpf.Printing.IPrintableControl);
            link.PrintingSystem.ExportOptions.PrintPreview.DefaultExportFormat = DevExpress.XtraPrinting.PrintingSystemCommand.ExportXlsx;
            link.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = string.Format("Отчет Ангидрит. МТБ. (с {0} по {1})", dtBegin.ToString(formatString), dtEnd.ToString(formatString));
            link.PaperKind = DevExpress.Xpf.Drawing.Printing.PaperKind.A4;
            link.Margins.Bottom = link.Margins.Top = link.Margins.Left = link.Margins.Right = 10;
            link.ExportServiceUri = string.Format("http://{0}/ExportService.svc", Global.Default.ServerIPAddress);
            LinkPreviewModel model = new LinkPreviewModel(link);
            preview.Model = model;
            link.CreateDocument(false);
            preview.ShowDialog();
        }
    }
}
