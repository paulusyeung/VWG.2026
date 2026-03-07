// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Virtualization.Management.ApplicationDOMNode
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Layout;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Web;

namespace Gizmox.WebGUI.Virtualization.Management
{
  [Serializable]
  internal class ApplicationDOMNode : ServerExplorerNode
  {
    private static ResourceHandle mobjNulImageResourceHandle = (ResourceHandle) new AssemblyResourceHandle(typeof (AdministrationFormBase), "Resources.null-set-icon.gif");
    private bool mobjIsSelectable;

    /// <summary>Gets the display text.</summary>
    /// <param name="objValue">The object value.</param>
    /// <returns></returns>
    protected string GetDisplayText(object objValue)
    {
      if (objValue == null)
        return string.Empty;
      PropertyDescriptor property1 = TypeDescriptor.GetProperties(objValue)["Text"];
      if (property1 != null && property1.PropertyType == typeof (string))
      {
        string displayText = (string) property1.GetValue(objValue);
        if (displayText != null && displayText.Length > 0)
          return displayText;
      }
      PropertyDescriptor property2 = TypeDescriptor.GetProperties(objValue)["Name"];
      if (property2 != null && property2.PropertyType == typeof (string))
      {
        string displayText = (string) property2.GetValue(objValue);
        if (displayText != null && displayText.Length > 0)
          return displayText;
      }
      string str = TypeDescriptor.GetConverter(objValue).ConvertToString(objValue);
      return str != null && str.Length != 0 ? str : objValue.GetType().Name;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Virtualization.Management.ApplicationDOMNode" /> class.
    /// </summary>
    /// <param name="objComponent">The object component.</param>
    /// <param name="blnIsSelectable">if set to <c>true</c> [BLN is selectable].</param>
    internal ApplicationDOMNode(IRegisteredComponent objComponent, bool blnIsSelectable)
    {
      this.Tag = (object) objComponent;
      if (objComponent is ProxyComponent proxyComponent)
      {
        Gizmox.WebGUI.Forms.Component sourceComponent = proxyComponent.SourceComponent;
        if (sourceComponent != null)
          objComponent = (IRegisteredComponent) sourceComponent;
      }
      this.mobjIsSelectable = blnIsSelectable;
      this.Label = string.Format("{0}({1})", (object) objComponent.GetType().Name, (object) this.GetDisplayText((object) objComponent));
      if (!this.mobjIsSelectable)
      {
        this.ForeColor = Color.FromArgb(140, 140, 140);
        this.StateImage = ApplicationDOMNode.mobjNulImageResourceHandle;
      }
      if (CommonUtils.GetToolboxImageFromControlType(objComponent.GetType()) == null)
        return;
      this.Image = (ResourceHandle) new GatewayResourceHandle((IRegisteredComponent) this, "componentImage");
    }

    /// <summary>Provides a way to handle gateway requests.</summary>
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
    protected override IGatewayHandler ProcessGatewayRequest(
      HttpContext objHttpContext,
      string strAction)
    {
      if (this.Tag != null)
      {
        objHttpContext.Response.ContentType = "image/jpeg";
        CommonUtils.GetToolboxImageFromControlType(this.Tag.GetType())?.Save(objHttpContext.Response.OutputStream, ImageFormat.Bmp);
      }
      return (IGatewayHandler) null;
    }

    /// <summary>Loads the nodes.</summary>
    protected override void LoadNodes()
    {
      if (this.Tag is TreeView)
      {
        foreach (TreeNode node in (BaseCollection) ((TreeView) this.Tag).Nodes)
          this.Nodes.Add((TreeNode) new ApplicationDOMNode((IRegisteredComponent) node, this.Explorer.IsSupportSelect((IRegisteredComponent) node)));
      }
      else if (this.Tag is TreeNode)
      {
        foreach (TreeNode node in (BaseCollection) ((TreeNode) this.Tag).Nodes)
          this.Nodes.Add((TreeNode) new ApplicationDOMNode((IRegisteredComponent) node, this.Explorer.IsSupportSelect((IRegisteredComponent) node)));
      }
      if (this.Tag is ToolBar)
      {
        foreach (ToolBarButton button in (IEnumerable) ((ToolBar) this.Tag).Buttons)
          this.Nodes.Add((TreeNode) new ApplicationDOMNode((IRegisteredComponent) button, this.Explorer.IsSupportSelect((IRegisteredComponent) button)));
      }
      else if (this.Tag is ListView)
      {
        foreach (ListViewItem objComponent in ((ListView) this.Tag).Items)
          this.Nodes.Add((TreeNode) new ApplicationDOMNode((IRegisteredComponent) objComponent, this.Explorer.IsSupportSelect((IRegisteredComponent) objComponent)));
      }
      else if (this.Tag is MenuItem)
      {
        if (!(this.Tag is MenuItem tag))
          return;
        foreach (MenuItem menuItem in tag.MenuItems)
          this.Nodes.Add((TreeNode) new ApplicationDOMNode((IRegisteredComponent) menuItem, this.Explorer.IsSupportSelect((IRegisteredComponent) menuItem)));
      }
      else if (this.Tag is MainMenu)
      {
        if (!(this.Tag is MainMenu tag))
          return;
        foreach (MenuItem menuItem in tag.MenuItems)
          this.Nodes.Add((TreeNode) new ApplicationDOMNode((IRegisteredComponent) menuItem, this.Explorer.IsSupportSelect((IRegisteredComponent) menuItem)));
      }
      else if (this.Tag is ToolStrip)
      {
        if (!(this.Tag is ToolStrip tag))
          return;
        foreach (ToolStripItem objComponent in (ArrangedElementCollection) tag.Items)
          this.Nodes.Add((TreeNode) new ApplicationDOMNode((IRegisteredComponent) objComponent, this.Explorer.IsSupportSelect((IRegisteredComponent) objComponent)));
      }
      else if (this.Tag is ToolStripDropDownItem)
      {
        if (!(this.Tag is ToolStripDropDownItem tag))
          return;
        foreach (ToolStripItem dropDownItem in (ArrangedElementCollection) tag.DropDownItems)
          this.Nodes.Add((TreeNode) new ApplicationDOMNode((IRegisteredComponent) dropDownItem, this.Explorer.IsSupportSelect((IRegisteredComponent) dropDownItem)));
      }
      else if (this.Tag is Form)
      {
        if (this.Tag is Form tag)
        {
          foreach (Form ownedForm in tag.OwnedForms)
            this.Nodes.Add((TreeNode) new ApplicationDOMNode((IRegisteredComponent) ownedForm, this.Explorer.IsSupportSelect((IRegisteredComponent) ownedForm)));
          MainMenu menu = tag.Menu;
          if (menu != null)
            this.Nodes.Add((TreeNode) new ApplicationDOMNode((IRegisteredComponent) menu, this.Explorer.IsSupportSelect((IRegisteredComponent) menu)));
          MenuStrip mainMenuStrip = tag.MainMenuStrip;
          if (mainMenuStrip != null)
            this.Nodes.Add((TreeNode) new ApplicationDOMNode((IRegisteredComponent) mainMenuStrip, this.Explorer.IsSupportSelect((IRegisteredComponent) mainMenuStrip)));
        }
        this.LoadControl();
      }
      else if (this.Tag is ProxyComponent)
      {
        if (!(this.Tag is ProxyComponent tag))
          return;
        foreach (ProxyComponent component in (System.Collections.Generic.List<ProxyComponent>) tag.Components)
          this.Nodes.Add((TreeNode) new ApplicationDOMNode((IRegisteredComponent) component, this.Explorer.IsSupportSelect((IRegisteredComponent) component)));
      }
      else
      {
        if (!(this.Tag is Control))
          return;
        this.LoadControl();
      }
    }

    /// <summary>Loads the control.</summary>
    private void LoadControl()
    {
      if (!(this.Tag is Control tag))
        return;
      foreach (Control control in (ArrangedElementCollection) tag.Controls)
        this.Nodes.Add((TreeNode) new ApplicationDOMNode((IRegisteredComponent) control, this.Explorer.IsSupportSelect((IRegisteredComponent) control)));
    }

    /// <summary>Loads the columns.</summary>
    /// <param name="objColumns">The object columns.</param>
    protected override void LoadColumns(ListView.ColumnHeaderCollection objColumns)
    {
      objColumns.Add("Name", 200, HorizontalAlignment.Left);
      objColumns.Add("Value", 300, HorizontalAlignment.Left);
    }

    /// <summary>Loads the items.</summary>
    /// <param name="objItems">The object items.</param>
    protected override void LoadItems(ListView.ListViewItemCollection objItems)
    {
      object tag = this.Tag;
      if (tag == null)
        return;
      Type type = tag.GetType();
      foreach (PropertyInfo property in type.GetProperties())
      {
        object obj = (object) null;
        try
        {
          obj = type.InvokeMember(property.Name, BindingFlags.GetProperty, (Binder) null, tag, new object[0]);
        }
        catch
        {
        }
        if (obj != null)
          objItems.Add(property.Name).SubItems.Add(obj.ToString());
        else
          objItems.Add(property.Name).SubItems.Add("null");
      }
      if (this.List == null || this.List.Columns.Count <= 0)
        return;
      this.List.SortBy(this.List.Columns[0]);
    }
  }
}
