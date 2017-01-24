using DevExpress.Xpf.Docking;
using DevExpress.Xpf.NavBar;
using System;

namespace WebControl
{
    public class NavigationWithPanal
    {
        public NavigationWithPanal(NavBarItem navItem, string viewName, DockLayoutManager dockManager, DocumentGroup documentContainer)
        {
            NavItem = navItem;
            navItem.Click += navItem_Click;
            ViewName = viewName;
            DockManager = dockManager;
            DocumentContainer = documentContainer;
        }

        /// <summary>
        /// Элемент навигации.
        /// </summary>
        NavBarItem NavItem { get; set; }

        /// <summary>
        /// Название окна.
        /// </summary>
        string ViewName { get; set; }

        /// <summary>
        /// Панель отображения.
        /// </summary>
        DocumentPanel Panel { get; set; }

        DockLayoutManager DockManager { get; set; }

        DocumentGroup DocumentContainer { get; set; }

        ViewBase ViewBase { get; set; }

        void navItem_Click(object sender, EventArgs e)
        {
            if (Panel == null)
            {
                Panel = DockManager.DockController.AddDocumentPanel(DocumentContainer, new Uri(string.Format("/WebControl;component/Views/{0}.xaml", ViewName), UriKind.Relative));
                Panel.Caption = NavItem.Content;
                ViewBase = (ViewBase)Panel.Control;
                ViewBase.NavItem = NavItem;
            }
            else
            {
                DockManager.DockController.Restore(Panel);
            }
            DockManager.Activate(Panel);
        }

        /// <summary>
        /// Активация элемента навигации.
        /// </summary>
        public void Activate()
        {
            navItem_Click(this, EventArgs.Empty);
        }
    }
}
