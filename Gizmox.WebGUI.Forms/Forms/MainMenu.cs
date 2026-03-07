// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MainMenu
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Summary description for MainMenu.</summary>
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (MainMenu), "MainMenu_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.MainMenuController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.MainMenuController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItemFilter("Gizmox.WebGUI.Forms.MainMenu")]
  [ToolboxItemCategory("Menus & Toolbars")]
  [Gizmox.WebGUI.Forms.MetadataTag("MM")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (MainMenuSkin))]
  [ProxyComponent(typeof (ProxyMainMenu))]
  [Serializable]
  public class MainMenu : Control, IRegisteredComponentContainer, IMainMenu
  {
    /// <summary>The Items property registration.</summary>
    private static readonly SerializableProperty ItemsProperty = SerializableProperty.Register("Items", typeof (MenuItemCollection), typeof (MainMenu));

    /// <summary>The main menu menu items</summary>
    private MenuItemCollection ItemsInternal
    {
      get => this.GetValue<MenuItemCollection>(MainMenu.ItemsProperty, (MenuItemCollection) null);
      set => this.SetValue<MenuItemCollection>(MainMenu.ItemsProperty, value);
    }

    /// <summary>
    /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.MainMenu" /> instance.
    /// </summary>
    /// <param name="objControl">parent control.</param>
    internal MainMenu(Control objControl) => this.InternalParent = (Component) objControl;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MainMenu" /> class.
    /// </summary>
    public MainMenu()
      : this((Control) null)
    {
    }

    /// <summary>
    /// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and its child controls and optionally releases the managed resources.
    /// </summary>
    /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
    protected override void Dispose(bool blnDisposing)
    {
      if (blnDisposing && this.Form != null)
        this.Form.Menu = (MainMenu) null;
      base.Dispose(blnDisposing);
    }

    /// <summary>Renders the height.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    internal override void RenderHeight(IContext objContext, IAttributeWriter objWriter)
    {
      if (this.Skin is MainMenuSkin skin)
        objWriter.WriteAttributeString("H", skin.Height.ToString());
      else
        base.RenderHeight(objContext, objWriter);
    }

    /// <summary>MainMenu render impementation</summary>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      string clientString = this.GetMenuItemCriticalEventsData().ToClientString();
      foreach (MenuItem menuItem in this.MenuItems)
      {
        if (menuItem.Visible)
        {
          menuItem.Enter += new EventHandler(this.MenuItem_Enter);
          this.RegisterComponent((IRegisteredComponent) menuItem);
          objWriter.WriteStartElement("I");
          objWriter.WriteAttributeString("Id", menuItem.GetProxyPropertyValue<long>("ID", menuItem.ID).ToString());
          if (!menuItem.Enabled)
            objWriter.WriteAttributeString("En", "0");
          objWriter.WriteAttributeString("E", clientString);
          if (menuItem != null && menuItem.MenuItems.Count > 0)
            objWriter.WriteAttributeString("HN", "1");
          objWriter.WriteAttributeText("TX", menuItem.Text, TextFilter.NewLine | TextFilter.CarriageReturn);
          menuItem.RenderExtendedComponentAttributes(objContext, (IAttributeWriter) objWriter);
          objWriter.WriteEndElement();
        }
      }
    }

    /// <summary>
    /// Gets the critical events of specific menu item instance.
    /// </summary>
    private CriticalEventsData GetMenuItemCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = new CriticalEventsData();
      criticalEventsData.Set("CL");
      if (this.HasHandler(Control.DoubleClickEvent))
        criticalEventsData.Set("DCL");
      return criticalEventsData;
    }

    /// <summary>Handles the Enter event of the MenuItem control.</summary>
    /// <param name="objSender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void MenuItem_Enter(object objSender, EventArgs e)
    {
      if (!(objSender is MenuItem objMenuItem))
        return;
      this.ShowSubMenu(objMenuItem);
    }

    /// <summary>Shows the submenu form.</summary>
    /// <param name="objMenuItem">The obj menu item.</param>
    private void ShowSubMenu(MenuItem objMenuItem)
    {
      if (objMenuItem == null || objMenuItem.MenuItems.Count <= 0)
        return;
      MenuItem objComponent = objMenuItem;
      objComponent.Show((Component) objComponent, Point.Empty, DialogAlignment.Below);
    }

    /// <summary>Adds a child object.</summary>
    /// <param name="objValue">The child object to add.</param>
    protected override void AddChild(object objValue)
    {
      if (objValue is MenuItem)
        this.MenuItems.Add((MenuItem) objValue);
      else
        base.AddChild(objValue);
    }

    /// <summary>
    /// 
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [ListBindable(false)]
    [Browsable(false)]
    public MenuItemCollection MenuItems
    {
      get
      {
        if (this.ItemsInternal == null)
          this.ItemsInternal = new MenuItemCollection((Component) this);
        return this.ItemsInternal;
      }
    }

    /// <summary>Gets the parent of this component.</summary>
    /// <value></value>
    public override Component InternalParent
    {
      get => base.InternalParent;
      set
      {
        if (base.InternalParent == value)
          return;
        if (value == null)
          this.MenuItems.RemovingFromDOM();
        base.InternalParent = value;
        if (value == null)
          return;
        this.MenuItems.AttachedToDOM();
      }
    }

    /// <summary>Called when [register components].</summary>
    protected override void OnRegisterComponents()
    {
      base.OnRegisterComponents();
      if (this.ItemsInternal == null)
        return;
      this.RegisterBatch((ICollection) this.ItemsInternal);
    }

    /// <summary>Called when [unregister components].</summary>
    protected override void OnUnregisterComponents()
    {
      base.OnUnregisterComponents();
      if (this.ItemsInternal == null)
        return;
      this.UnRegisterBatch((ICollection) this.ItemsInternal);
    }

    ICollection IRegisteredComponentContainer.ContainedComponents => (ICollection) this.ItemsInternal;

    ICollection IMainMenu.MenuItems => (ICollection) this.MenuItems;

    IComponent IMainMenu.Parent => (IComponent) this.Parent;

    /// <summary>Fires the click event.</summary>
    /// <param name="objMouseEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs" /> instance containing the event data.</param>
    internal void FireClick(MouseEventArgs objMouseEventArgs) => this.OnClick((EventArgs) objMouseEventArgs);

    /// <summary>Fires the double click event.</summary>
    /// <param name="objMouseEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs" /> instance containing the event data.</param>
    internal void FireDoubleClick(MouseEventArgs objMouseEventArgs) => this.OnDoubleClick((EventArgs) objMouseEventArgs);

    /// <summary>Gets the component offsprings.</summary>
    /// <param name="strOffspringTypeName">The offspring type.</param>
    /// <returns></returns>
    protected internal override IList GetComponentOffsprings(string strOffspringTypeName) => (IList) this.MenuItems;
  }
}
