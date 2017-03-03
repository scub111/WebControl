using DevExpress.Xpf.Docking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Input;

namespace WebControl
{
    public partial class HMISimpleBase : UserControlEx
    {
        public HMISimpleBase()
        {
            InitNew();
            Inited = false;
            TryInited = false;
            Item = null;
            _DataValue = Global.Default.DoubleUnknown;
            Loaded += HMISimpleBase_Loaded;
            Unloaded += HMISimpleBase_Unloaded;
            MouseEnter += HMIBase_MouseEnter;
            MouseLeave += HMIBase_MouseLeave;
            MouseLeftButtonDown += HMIBase_MouseLeftButtonDown;
            MouseRightButtonDown += HMISimpleBase_MouseRightButtonDown;
            ActualChanged += HMIBase_ActualChanged;

            QualityGoodLastTime = Global.Default.SqlCurrentTime;

            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                //Global.Default.ThreadMain.InterfaceChanged += ThreadMain_InterfaceChanged;
                Global.Default.ItemsUpdated += ItemsUpdated;
                Global.Default.AddUIControl(this);
            }
        }

        /// <summary>
        /// Событие инициализации элемента.
        /// </summary>
        public event EventHandler ItemInited;

        /// <summary>
        /// Событие на изменение актуальности.
        /// </summary>
        public event EventHandler ActualChanged;

        /// <summary>
        /// Событие на изменение основной переменной.
        /// </summary>
        public event EventHandler DataValueChanged;

        /// <summary>
        /// Имя SQL-таблицы.
        /// </summary>
        public string DataName { get; set; }

        /// <summary>
        /// Реальный объект.
        /// </summary>
        public ItemReal Item { get; set; }

        /// <summary>
        /// Окно тренда.
        /// </summary>
        public DocumentPanel TrendDocumentPanel;

        /// <summary>
        /// Окно датализации.
        /// </summary>
        public DocumentPanel DetailDocumentPanel;

        /// <summary>
        /// Инициированы ли данные.
        /// </summary>
        public bool Inited { get; set; }

        /// <summary>
        /// Была сделана ли ранее попытка инициализации.
        /// </summary>
        public bool TryInited { get; set; }

        /// <summary>
        /// Внешняя ссылка для перехода.
        /// </summary>
        public string ExternalLink { get; set; }

        /// <summary>
        /// Время последнего лучшего качества.
        /// </summary>
        DateTime QualityGoodLastTime { get; set; }

        /*
        /// <summary>
        /// Контекстное меню.
        /// </summary>
        ContextMenu ContexMenu { get; set; }

        /// <summary>
        /// Вкладка контекстного меню.
        /// </summary>
        MenuItem MenuItemThisTab { get; set; }

        /// <summary>
        /// Вкладка контекстного меню.
        /// </summary>
        MenuItem MenuItemNextTab { get; set; }
         */


        bool _Actual;
        /// <summary>
        /// Актуальность данных.
        /// </summary>
        public bool Actual
        {
            get { return _Actual; }
            set
            {
                if (_Actual == value) return;
                _Actual = value;
                if (ActualChanged != null)
                    ActualChanged(this, EventArgs.Empty);
            }
        }

        double _DataValue;
        /// <summary>
        /// Значение основной переменной.
        /// </summary>
        public double DataValue
        {
            get { return _DataValue; }
            set
            {
                if (_DataValue == value) return;
                _DataValue = value;
                if (DataValueChanged != null)
                    DataValueChanged(this, EventArgs.Empty);
            }
        }

        void HMISimpleBase_Loaded(object sender, RoutedEventArgs e)
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                Update();

                if (Inited)
                {
                    //Item.VisualControlActivate(this);
                }
            }
        }

        void HMISimpleBase_Unloaded(object sender, RoutedEventArgs e)
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                if (Inited)
                {
                    //Item.VisualControlDeactivate(this);
                }
            }
        }

        /// <summary>
        /// Показ форма тренда.
        /// </summary>
        public void ShowTrend()
        {
            if (Item != null &&
                Item.Trend &&
                Global.Default.DockManager != null &&
                Global.Default.DocumentContainer != null)
                GlobalDefault.ShowForm(ref TrendDocumentPanel, Item.Description, "/WebControl;component/Forms/TrendForm.xaml", new Size(700, 400), true, this);
        }

        /// <summary>
        /// Показ формы детализации.
        /// </summary>
        public void ShowDetail()
        {
            if (Item != null &&
                Global.Default.DockManager != null &&
                Global.Default.DocumentContainer != null)
                GlobalDefault.ShowForm(ref DetailDocumentPanel, Item.Description, "/WebControl;component/Forms/DetailForm.xaml", new Size(420, 430), true, this);
        }

        /// <summary>
        /// Новая инициализация данных.
        /// </summary>
        public void InitNew()
        {
            Inited = false;
            TryInited = false;
        }

        /// <summary>
        /// Обновление данных.
        /// </summary>
        public virtual void Update()
        {
            if (Inited)
            {
                if (TrendDocumentPanel != null)
                    ((TrendForm)TrendDocumentPanel.Control).UpdateExternal();

                if (DetailDocumentPanel != null)
                    ((DetailForm)DetailDocumentPanel.Control).UpdateExternal();

                if (Item.Quality == 192)
                    QualityGoodLastTime = Global.Default.SqlCurrentTime;

                if (Item != null &&
                    (Global.Default.SqlCurrentTime - Item.SqlTime).TotalSeconds < Item.TimeOut &&
                    (Global.Default.SqlCurrentTime - QualityGoodLastTime).TotalSeconds < Item.TimeOut)
                {
                    DataValue = Item.DataValue;
                    Actual = true;
                }
                else
                {
                    DataValue = Global.Default.DoubleUnknown;
                    Actual = false;
                }
            }
            else
            {
                if (Global.Default.ItemsInited &&
                    !TryInited)
                {
                    Item = Global.Default.GetItemReal(DataName);
                    TryInited = true;
                    if (Item != null)
                    {
                        Inited = true;
                        if (ItemInited != null)
                            ItemInited(this, EventArgs.Empty);
                        Update();
                    }
                }
            }
        }

        void ItemsUpdated(object sender, EventArgs e)
        {
            Update();
        }

        void Default_InitItemsCompleted(object sender, EventArgs e)
        {
            Update();
        }

        private void HMIBase_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Item != null && Item.Trend)
                VisualStateManager.GoToState(this, "ControlMouseEnter", true);
        }

        private void HMIBase_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Item != null && Item.Trend)
                VisualStateManager.GoToState(this, "ControlMouseLeave", true);
        }

        private void HMIBase_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ShowTrend();
        }

        private void HMIBase_ActualChanged(object sender, EventArgs e)
        {
            if (Actual)
                VisualStateManager.GoToState(this, "ControlActualTrue", true);
            else
                VisualStateManager.GoToState(this, "ControlActualFalse", true);
        }

        private void HMISimpleBase_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!String.IsNullOrEmpty(ExternalLink))
            {
                ContextMenu ContexMenu = new ContextMenu();

                MenuItem MenuItemThisTab = new MenuItem();
                MenuItemThisTab.Header = "Ссылка в этом окне";
                MenuItemThisTab.Click += menuItemThisTab_Click;
                ContexMenu.Items.Add(MenuItemThisTab);

                MenuItem MenuItemNextTab = new MenuItem();
                MenuItemNextTab.Header = "Ссылка в следующем окне";
                MenuItemNextTab.Click += menuItemNextTab_Click;
                ContexMenu.Items.Add(MenuItemNextTab);

                MenuItem MenuItemDetail = new MenuItem();
                MenuItemDetail.Header = "Детализация";
                MenuItemDetail.Click += MenuItemDetail_Click;
                ContexMenu.Items.Add(MenuItemDetail);

                ContexMenu.IsOpen = true;
                ContexMenu.HorizontalOffset = e.GetPosition(Global.Default.RootVisual).X;
                ContexMenu.VerticalOffset = e.GetPosition(Global.Default.RootVisual).Y;
            }
            else
                MenuItemDetail_Click(null, null);
        }

        void menuItemThisTab_Click(object sender, RoutedEventArgs e)
        {
            HtmlPopupWindowOptions options = new HtmlPopupWindowOptions();
            options.Left = 300;
            options.Top = 150;
            options.Width = 1030;
            options.Height = 800;
            //options.Directories = false;
            //options.Location = false;
            //options.Menubar = false;
            //options.Status = true;
            //options.Toolbar = false;
            options.Resizeable = true;
            HtmlPage.PopupWindow(new Uri(ExternalLink), "self", options);
        }

        void menuItemNextTab_Click(object sender, RoutedEventArgs e)
        {
            HtmlPage.PopupWindow(new Uri(ExternalLink), "_blank", null);
        }

        void MenuItemDetail_Click(object sender, RoutedEventArgs e)
        {
            ShowDetail();
        }
    }
}
