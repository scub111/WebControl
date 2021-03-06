﻿using DevExpress.Xpf.NavBar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using static WebControl.HMIRectangleEx;

namespace WebControl
{
    public class ViewBase : UserControlEx
    {
        public ViewBase()
        {
            Loaded += ViewBase_Loaded;
            Unloaded += ViewBase_Unloaded;
            ItemsInited = false;
            UserControlExs = new Collection<UserControlEx>();
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
        Collection<UserControlEx> UserControlExs { get; set; }

        /// <summary>
        /// Список записей.
        /// </summary>
        public Collection<string> ItemDataNames { get; set; }

        string FindExtension(string inStr)
        {
            string strOut = "";

            bool isInited = false;
            bool isFinished = false;

            for (int i = 0; i < inStr.Length; i++)
            {
                if (inStr[i] == '}')
                    isFinished = true;

                if (isInited && !isFinished)
                    strOut += inStr[i];

                if (inStr[i] == '{')
                    isInited = true;
            }

            return strOut;
        }

        void ViewBase_Loaded(object sender, RoutedEventArgs e)
        {
            if (NavItem != null && NavItem.Group != null)
                NavItem.Group.SelectedItem = NavItem;

            if (!ItemsInited)
            {
                Type myType = GetType();
                FieldInfo[] FieldInfos = myType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                UIElement uiElement = null;
                foreach (FieldInfo info in FieldInfos)
                    if (info.Name == "LayoutRoot")
                        uiElement = info.GetValue(this) as UIElement;

                if (uiElement != null)
                    GetTextBoxes(uiElement, UserControlExs);

                string dataName;
                string extension;
                //Regex regex = new Regex("({\\w*\\.\\w*\\.\\w*\\.\\w*\\;(\\w*|\\w*\"\\w *\"\\w*)\\;\\w*})");
                foreach (UserControlEx userControl in UserControlExs)
                {
                    if (userControl is HMISimpleBase)
                    {
                        HMISimpleBase hmiSimple = userControl as HMISimpleBase;
                        if (!string.IsNullOrEmpty(hmiSimple.DataName))
                            ItemDataNames.Add(hmiSimple.DataName);
                    }
                    else if (userControl is HMINodeEx)
                    {
                        HMINodeEx hmiNodeEx = userControl as HMINodeEx;
                        if (!string.IsNullOrEmpty(hmiNodeEx.DataNameEx))
                        {
                            ItemDataNames.Add(string.Format("{0}_Status", hmiNodeEx.DataNameEx));
                            ItemDataNames.Add(string.Format("{0}_ReplyTime", hmiNodeEx.DataNameEx));
                        }

                        if (hmiNodeEx.AutoCaptions)
                        {
                            dataName = string.Format("{0}_Status", hmiNodeEx.DataNameEx);
                            if (Global.Default.ItemsRealDict.ContainsKey(dataName))
                            {
                                //MatchCollection matches = regex.Matches(Global.Default.ItemsRealDict[dataName].Description);
                                try
                                {
                                    extension = FindExtension(Global.Default.ItemsRealDict[dataName].Comment);

                                    string[] strOut = extension.Split(';');

                                    hmiNodeEx.CaptionAdditional = strOut[0];
                                    hmiNodeEx.CaptionMain = strOut[1];
                                    hmiNodeEx.Type = (NodeType)int.Parse(strOut[2]);
                                }
                                catch { }
                            }
                        }                
                    }
                }

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

        private void GetTextBoxes(UIElement uiElement, Collection<UserControlEx> textBoxList)
        {
            UserControlEx textBox = uiElement as UserControlEx;
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
