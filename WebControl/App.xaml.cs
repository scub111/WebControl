﻿using System;
using System.Windows;
using System.Windows.Input;

namespace WebControl
{
    public partial class App : Application
    {

        public App()
        {
            Startup += Application_Startup;
            Exit += Application_Exit;
            UnhandledException += Application_UnhandledException;

            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            RootVisual = new MainPage();
            //this.RootVisual = new SilverlightControl1();
            RootVisual.AddHandler(UIElement.KeyDownEvent, new KeyEventHandler(HandleKeyDown), true);
            RootVisual.AddHandler(UIElement.KeyUpEvent, new KeyEventHandler(HandleKeyUp), true);

            if (e.InitParams.ContainsKey("ClientIPAddress"))
                Global.Default.ClientIPAddress = e.InitParams["ClientIPAddress"];

            Global.Default.ApplicationStarted = true;
            Global.Default.RootVisual = RootVisual;
        }

        private void HandleKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Ctrl)
                Global.Default.CtrlPressed = true;

            if (e.Key == Key.Shift)
                Global.Default.ShiftPressed = true;
        }

        private void HandleKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Ctrl)
                Global.Default.CtrlPressed = false;

            if (e.Key == Key.Shift)
                Global.Default.ShiftPressed = false;

            if (Global.Default.CtrlPressed && Global.Default.ShiftPressed && e.Key == Key.M)
            {
                if (Global.Default.navPanDevelop != null)
                    Global.Default.navPanDevelop.Activate();                
            }
        }

        private void Application_Exit(object sender, EventArgs e)
        {

        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // Если приложение выполняется вне отладчика, воспользуйтесь для сообщения об исключении
            // механизмом исключений браузера. В IE исключение будет отображаться в виде желтого значка оповещения 
            // в строке состояния, а в Firefox - в виде ошибки скрипта.
            if (!System.Diagnostics.Debugger.IsAttached)
            {

                // ПРИМЕЧАНИЕ. Это позволит приложению выполняться после того, как исключение было выдано,
                // но не было обработано. 
                // Для рабочих приложений такую обработку ошибок следует заменить на код, 
                // оповещающий веб-сайт об ошибке и останавливающий работу приложения.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }

        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
        }
    }
}
