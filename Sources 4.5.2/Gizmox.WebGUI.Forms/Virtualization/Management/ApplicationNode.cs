using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using System.Reflection;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace Gizmox.WebGUI.Virtualization.Management
{
    #region DomTreeNode Class


    [Serializable()]
    internal class ApplicationDOMNode : ServerExplorerNode
    {
        private static ResourceHandle mobjNulImageResourceHandle = new Gizmox.WebGUI.Common.Resources.AssemblyResourceHandle(typeof(AdministrationFormBase), "Resources.null-set-icon.gif");
        private bool mobjIsSelectable;

        /// <summary>
        /// Gets the display text.
        /// </summary>
        /// <param name="objValue">The object value.</param>
        /// <returns></returns>
        protected string GetDisplayText(object objValue)
        {
            string strText1;
            if (objValue == null)
            {
                return string.Empty;
            }

            PropertyDescriptor objPropertyDescriptor2 = TypeDescriptor.GetProperties(objValue)["Text"];
            if ((objPropertyDescriptor2 != null) && (objPropertyDescriptor2.PropertyType == typeof(string)))
            {
                strText1 = (string)objPropertyDescriptor2.GetValue(objValue);
                if ((strText1 != null) && (strText1.Length > 0))
                {
                    return strText1;
                }
            }

            PropertyDescriptor objPropertyDescriptor1 = TypeDescriptor.GetProperties(objValue)["Name"];
            if ((objPropertyDescriptor1 != null) && (objPropertyDescriptor1.PropertyType == typeof(string)))
            {
                strText1 = (string)objPropertyDescriptor1.GetValue(objValue);
                if ((strText1 != null) && (strText1.Length > 0))
                {
                    return strText1;
                }
            }
            strText1 = TypeDescriptor.GetConverter(objValue).ConvertToString(objValue);
            if ((strText1 != null) && (strText1.Length != 0))
            {
                return strText1;
            }

            return objValue.GetType().Name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDOMNode"/> class.
        /// </summary>
        /// <param name="objComponent">The object component.</param>
        /// <param name="blnIsSelectable">if set to <c>true</c> [BLN is selectable].</param>
        internal ApplicationDOMNode(IRegisteredComponent objComponent, bool blnIsSelectable)
        {
            // Update node tag with registered component
            Tag = objComponent;

            // Check if component is proxy component, and if so point to source component.
            ProxyComponent objProxyComponent = objComponent as ProxyComponent;
            if (objProxyComponent != null)
            {
                Gizmox.WebGUI.Forms.Component objSourceComponent = objProxyComponent.SourceComponent;
                if (objSourceComponent != null)
                {
                    objComponent = objSourceComponent;
                }
            }
            

            mobjIsSelectable = blnIsSelectable;
            Label = string.Format("{0}({1})", objComponent.GetType().Name, GetDisplayText(objComponent));
            if (!mobjIsSelectable)
            {
                this.ForeColor = Color.FromArgb(140, 140, 140);
                this.StateImage = mobjNulImageResourceHandle;
            }

            Image objImage = CommonUtils.GetToolboxImageFromControlType(objComponent.GetType());
            if(objImage != null)
            {
                Image = new GatewayResourceHandle(this, "componentImage");
            }
        }

        /// <summary>
        /// Provides a way to handle gateway requests.
        /// </summary>
        /// <param name="objHttpContext">The gateway request HTTP context (which is unavailable in non ASP.NET hosting modes).</param>
        /// <param name="strAction">The gateway request action.</param>
        /// <returns>
        /// By default this method returns a instance of a class which implements the IGatewayHandler and
        /// throws a non implemented HttpException.
        /// </returns>
        /// <remarks>
        /// This method is called from the implementation of IGatewayComponent which replaces the
        /// IGatewayControl interface. The IGatewayCompoenent is implemented by default in the
        /// RegisteredComponent class which is the base class of most of the Visual WebGui
        /// components.
        /// Referencing a RegisterComponent that overrides this method is done the same way that
        /// a control implementing IGatewayControl, which is by using the GatewayReference class.
        /// </remarks>
        protected override Common.Interfaces.IGatewayHandler ProcessGatewayRequest(System.Web.HttpContext objHttpContext, string strAction)
        {
            if (this.Tag != null)
            {
                objHttpContext.Response.ContentType = "image/jpeg";
                System.Drawing.Image objImage = CommonUtils.GetToolboxImageFromControlType(this.Tag.GetType());

                if (objImage != null)
                {
                    objImage.Save(objHttpContext.Response.OutputStream, ImageFormat.Bmp);
                }
            }


            return null;
        }

        /// <summary>
        /// Loads the nodes.
        /// </summary>
        protected override void LoadNodes()
        {
            if (Tag is TreeView)
            {
                foreach (TreeNode objNode in ((TreeView)Tag).Nodes)
                {
                    Nodes.Add(new ApplicationDOMNode((IRegisteredComponent)objNode, Explorer.IsSupportSelect(objNode)));
                }
            }
            else if (Tag is TreeNode)
            {
                foreach (TreeNode objNode in ((TreeNode)Tag).Nodes)
                {
                    Nodes.Add(new ApplicationDOMNode((IRegisteredComponent)objNode, Explorer.IsSupportSelect(objNode)));
                }
            }
            if (Tag is ToolBar)
            {
                foreach (ToolBarButton objNode in ((ToolBar)Tag).Buttons)
                {
                    Nodes.Add(new ApplicationDOMNode((IRegisteredComponent)objNode, Explorer.IsSupportSelect(objNode)));
                }
            }
            else if (Tag is ListView)
            {
                foreach (ListViewItem objItem in ((ListView)Tag).Items)
                {
                    Nodes.Add(new ApplicationDOMNode((IRegisteredComponent)objItem, Explorer.IsSupportSelect(objItem)));
                }
            }
            else if (Tag is MenuItem)
            {
                MenuItem objMenuItem = Tag as MenuItem;
                if (objMenuItem != null)
                {
                    foreach (MenuItem objItem in objMenuItem.MenuItems)
                    {
                        Nodes.Add(new ApplicationDOMNode((IRegisteredComponent)objItem, Explorer.IsSupportSelect(objItem)));
                    }
                }
            }
            else if (Tag is MainMenu)
            {
                MainMenu objMainMenu = Tag as MainMenu;
                if (objMainMenu != null)
                {
                    foreach (MenuItem objItem in objMainMenu.MenuItems)
                    {
                        Nodes.Add(new ApplicationDOMNode((IRegisteredComponent)objItem, Explorer.IsSupportSelect(objItem)));
                    }
                }
            }
            else if (Tag is ToolStrip)
            {
                ToolStrip objToolStrip = Tag as ToolStrip;
                if (objToolStrip != null)
                {
                    foreach (ToolStripItem objItem in objToolStrip.Items)
                    {
                        Nodes.Add(new ApplicationDOMNode((IRegisteredComponent)objItem, Explorer.IsSupportSelect(objItem)));
                    }
                }
            }
            else if (Tag is ToolStripDropDownItem)
            {
                ToolStripDropDownItem objToolStripDropDownItem = Tag as ToolStripDropDownItem;
                if (objToolStripDropDownItem != null)
                {
                    foreach (ToolStripItem objItem in objToolStripDropDownItem.DropDownItems)
                    {
                        Nodes.Add(new ApplicationDOMNode((IRegisteredComponent)objItem, Explorer.IsSupportSelect(objItem)));
                    }
                }
            }
            else if (Tag is Form)
            {
                Form objForm = Tag as Form;
                if (objForm != null)
                {
                    foreach (Form objSubForm in objForm.OwnedForms)
                    {
                        Nodes.Add(new ApplicationDOMNode((IRegisteredComponent)objSubForm, Explorer.IsSupportSelect(objSubForm)));
                    }

                    MainMenu objMainMenu = objForm.Menu;
                    if (objMainMenu != null)
                    {
                        Nodes.Add(new ApplicationDOMNode((IRegisteredComponent)objMainMenu, Explorer.IsSupportSelect(objMainMenu)));
                    }

                    MenuStrip objMenuStrip = objForm.MainMenuStrip;
                    if (objMenuStrip != null)
                    {
                        Nodes.Add(new ApplicationDOMNode((IRegisteredComponent)objMenuStrip, Explorer.IsSupportSelect(objMenuStrip)));
                    }
                }

                LoadControl();
            }
            else if (Tag is ProxyComponent)
            {
                ProxyComponent objProxyComponent = Tag as ProxyComponent;
                if (objProxyComponent != null)
                {
                    foreach (ProxyComponent objSubProxyComponent in objProxyComponent.Components)
                    {
                        Nodes.Add(new ApplicationDOMNode((IRegisteredComponent)objSubProxyComponent, Explorer.IsSupportSelect(objSubProxyComponent)));
                    }
                }
            }
            else if (Tag is Control)
            {
                LoadControl();
            }
        }

        /// <summary>
        /// Loads the control.
        /// </summary>
        private void LoadControl()
        {
            Control objControl = Tag as Control;
            if (objControl != null)
            {
                foreach (Control objSubControl in objControl.Controls)
                {
                    Nodes.Add(new ApplicationDOMNode((IRegisteredComponent)objSubControl, Explorer.IsSupportSelect(objSubControl)));
                }
            }
        }

        /// <summary>
        /// Loads the columns.
        /// </summary>
        /// <param name="objColumns">The object columns.</param>
        protected override void LoadColumns(Gizmox.WebGUI.Forms.ListView.ColumnHeaderCollection objColumns)
        {
            objColumns.Add("Name", 200, HorizontalAlignment.Left);
            objColumns.Add("Value", 300, HorizontalAlignment.Left);
        }

        /// <summary>
        /// Loads the items.
        /// </summary>
        /// <param name="objItems">The object items.</param>
        protected override void LoadItems(Gizmox.WebGUI.Forms.ListView.ListViewItemCollection objItems)
        {
            object objComponent = Tag;
            if (objComponent != null)
            {
                Type objType = objComponent.GetType();
                foreach (PropertyInfo objProperty in objType.GetProperties())
                {
                    object objValue = null;

                    try
                    {
                        objValue = objType.InvokeMember(objProperty.Name, BindingFlags.GetProperty, null, objComponent, new object[] { });
                    }
                    catch { }

                    if (objValue != null)
                    {
                        objItems.Add(objProperty.Name).SubItems.Add(objValue.ToString());
                    }
                    else
                    {
                        objItems.Add(objProperty.Name).SubItems.Add("null");
                    }
                }

                if(this.List != null)
                {
                    if (this.List.Columns.Count > 0)
                    {
                        this.List.SortBy(this.List.Columns[0]);
                    }
                }
            }
        }
    }

    #endregion 

}
