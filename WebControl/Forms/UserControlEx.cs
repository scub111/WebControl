using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace WebControl
{
    public class UserControlEx : UserControl
    {
        public UserControlEx()
        {
            Visible = false;
            this.Loaded += UserControlEx_Loaded;
            this.Unloaded += UserControlEx_Unloaded;
            
        }

        /// <summary>
        /// Видимость формы.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// Установка владельца формы перед инициализацей.
        /// </summary>
        public virtual void SetOwner(object owner)
        {
        }

        void UserControlEx_Loaded(object sender, RoutedEventArgs e)
        {
            Visible = true;
        }

        void UserControlEx_Unloaded(object sender, RoutedEventArgs e)
        {
            Visible = false;
        }
    }
}
