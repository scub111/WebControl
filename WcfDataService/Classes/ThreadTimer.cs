using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace WcfDataService
{
    public class ThreadTimer
    {
        public ThreadTimer()
        {
            Period = 1000;
            Delay = 100;
            TimeError = 50;
            CountWork = 0;
            Worker = new BackgroundWorker();
            Worker.WorkerReportsProgress = true;
            Worker.WorkerSupportsCancellation = true;
            Worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
            Worker.ProgressChanged += new ProgressChangedEventHandler(Worker_ProgressChanged);             
        }

        int _Perion;
        /// <summary>
        /// Период таймера в мс.
        /// </summary>
        public int Period 
        {
            get
            {
                return _Perion;
            }
            set
            {
                float K = _Perion / (float)value;
                _Perion = value;
                CountWork = (int)(CountWork * K);
            }
        }

        /// <summary>
        /// Задержки в цикле в мс.
        /// </summary>
        public int Delay { get; set; }

        /// <summary>
        /// Ошибка в точности таймера.
        /// </summary>
        public int TimeError { get; set; }

        /// <summary>
        /// Время запуска таймера.
        /// </summary>
        DateTime StartTime { get; set; }

        /// <summary>
        /// Счетчик выполнения.
        /// </summary>
        public int CountWork { get; set; }

        /// <summary>
        /// Разница во времени.
        /// </summary>
        TimeSpan TimeDiff;

        /// <summary>
        /// Время выполнения одного цикла.
        /// </summary>
        TimeSpan RunTime;

        /// <summary>
        /// Перепенная для расчет времени выполнения одного цикла.
        /// </summary>
        DateTime T0;

        /// <summary>
        /// Рабочее событие.
        /// </summary>
        public event EventHandler WorkChanged;

        /// <summary>
        /// Событие на обновление интерфейса.
        /// </summary>
        public event EventHandler InterfaceChanged;

        BackgroundWorker Worker { get; set; }

        /// <summary>
        /// Запуск таймера.
        /// </summary>
        public void Run()
        {
            if (!Worker.IsBusy)
            {
                Worker.RunWorkerAsync();
                Reset();
            }
        }

        /// <summary>
        /// Стоп таймера.
        /// </summary>
        public void Stop()
        {
            Worker.CancelAsync();
        }

        /// <summary>
        /// Обнуление переменных.
        /// </summary>
        void Reset()
        {
            StartTime = DateTime.Now;
            CountWork = 0;
        }

        /// <summary>
        /// Выполняется ли поток.
        /// </summary>
        public bool IsBusy
        {
            get
            {
                return Worker.IsBusy;
            }
        }

        /// <summary>
        /// Вызов обработчки события DoWork.
        /// </summary>
        void InvokeWorkChanged(object sender, EventArgs e)
        {
            if (WorkChanged != null)
                WorkChanged(sender, e);
        }

        /// <summary>
        /// Вызов обработчки события ProgressChanged.
        /// </summary>
        void InvokeInterfaceChanged(object sender, EventArgs e)
        {
            if (InterfaceChanged != null)
                InterfaceChanged(sender, e);
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                //Подсчет разницы во времени.
                TimeDiff = DateTime.Now - StartTime;

                if (TimeDiff.TotalMilliseconds >= CountWork * Period)
                {
                    //На случай останова потока.
                    if (Worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }                    
                    
                    CountWork++;

                    T0 = DateTime.Now;
                    InvokeWorkChanged(this, EventArgs.Empty);
                    Worker.ReportProgress(0);
                    RunTime = DateTime.Now - T0;

                    if (RunTime.TotalMilliseconds > Period + TimeError)
                        Reset();
                }
                Thread.Sleep(Delay);
            }
        }

        void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            InvokeInterfaceChanged(this, EventArgs.Empty);
        }
    }
}
