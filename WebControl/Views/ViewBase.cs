using DevExpress.Xpf.NavBar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Reflection;
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
    public class ViewBase : UserControlEx
    {
        public ViewBase()
        {
            Loaded += ViewBase_Loaded;
            Unloaded += ViewBase_Unloaded;
            ItemsInited = false;
            HMIControls = new Collection<HMISimpleBase>();
            ItemDataNames = new Collection<string>();
        }

        /// <summary>
        /// Элемент навигации.
        /// </summary>
        public NavBarItem NavItem { get; set; }

        /// <summary>
        /// Инициализация элементов.
        /// </summary>
        bool ItemsInited { get; set; }

        /// <summary>
        /// Коллекция визуальнх элементов.
        /// </summary>
        Collection<HMISimpleBase> HMIControls { get; set; }

        /// <summary>
        /// Список записей.
        /// </summary>
        public Collection<string> ItemDataNames { get; set; }

        void ViewBase_Loaded(object sender, RoutedEventArgs e)
        {
            if (NavItem != null && NavItem.Group != null)
                NavItem.Group.SelectedItem = NavItem;

            Collection<HMISimpleBase> hmiSimpleBaseCollection = new Collection<HMISimpleBase>();

            if (!ItemsInited)
            {
                Type myType = GetType();
                FieldInfo[] FieldInfos = myType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                UIElement uiElement = null;
                foreach (FieldInfo info in FieldInfos)
                    if (info.Name == "LayoutRoot")
                        uiElement = info.GetValue(this) as UIElement;                

                if (uiElement != null)
                    GetTextBoxes(uiElement, HMIControls);

                foreach (HMISimpleBase hmiSimple in HMIControls)
                    ItemDataNames.Add(hmiSimple.DataName);

                ItemsInited = true;
            }

            foreach (string dataName in ItemDataNames)
                Global.Default.VisualControlActivate(dataName);

            Global.Default.ForceInterfaceChanged(this, EventArgs.Empty);
        }

        void ViewBase_Unloaded(object sender, RoutedEventArgs e)
        {
            if (NavItem != null && NavItem.Group != null)
                NavItem.Group.SelectedItem = null;

            foreach (string dataName in ItemDataNames)
                Global.Default.VisualControlDeactivate(dataName);
        }

        private void GetTextBoxes(UIElement uiElement, Collection<HMISimpleBase> textBoxList)
        {
            HMISimpleBase textBox = uiElement as HMISimpleBase;
            if (textBox != null)
            {
                // If the UIElement is a Textbox, add it to the list.
                textBoxList.Add(textBox);
            }
            else
            {
                Panel panel = uiElement as Panel;
                if (panel != null)
                {
                    // If the UIElement is a panel, then loop through it's children
                    foreach (UIElement child in panel.Children)
                    {
                        GetTextBoxes(child, textBoxList);
                    }
                }
            }
        } 


    }
}
