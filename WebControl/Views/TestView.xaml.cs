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
using System.Windows.Shapes;

namespace WebControl
{
    public partial class TestView : ViewBase
    {
        public TestView()
        {
            InitializeComponent();
            heater4.ValueONDelegete = new HMIBooleanBase.StatePosition(ValueOnFunc);
            //heater4.ValueOFFDelegete = new HMIBooleanBase.StatePosition(ValueOffFunc);

            _data = new Collection<TestDataItem>();

            arrXdate = new DateTime[1000];
            arrX = new double[1000];
            arrY = new double[1000];

            for (int i = 0; i < 1000; i++)
            {
                TestDataItem point = new TestDataItem() {Member = DateTime.Now + new TimeSpan(0, 0, i), Value = i};
                _data.Add(point);
                arrXdate[i] = DateTime.Now + new TimeSpan(0, 0, i);
                arrX[i] = i;
                arrY[i] = i;
            }

            MyPoints = new Collection<MyPoint>();
            for (int i = 0; i < 1000; i++)
            {
                MyPoint point = new MyPoint(i, i);
                MyPoints.Add(point);
            }
        }

        DateTime[] arrXdate;
        double[] arrX;
        double[] arrY;

        class MyPoint
        {
            public MyPoint(int member, int value)
            {
                Member = member;
                Value = value;
            }
            public int Member { get; set; }
            public int Value { get; set; }
        }

        public class TestDataItem
        {
            public DateTime Member { get; set; }
            public double Value { get; set; }

        }
        private Collection<TestDataItem> _data;
        //public ObservableCollection<TestDataItem> Data { get { return _data; } }

        bool ValueOnFunc(HMIBooleanBase sender, double value)
        {
            if (-20 < value && value < 0)
                return true;
            else
                return false;
        }

        bool ValueOffFunc(double value)
        {
            if (value == 190)
                return true;
            else
                return false;
        }

        private void ViewBase_Loaded(object sender, RoutedEventArgs e)
        {
            //this.DataContext = this;
        }

        private void heater4_DataValueChanged(object sender, EventArgs e)
        {

        }

        Collection<MyPoint> MyPoints;

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
