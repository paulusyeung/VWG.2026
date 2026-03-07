// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Menu
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents the base functionality for all menus.</summary>
  [ListBindable(false)]
  [DesignTimeVisible(false)]
  [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
  [ToolboxItemCategory("Menus & Toolbars")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (MenuSkin))]
  [Serializable]
  public class Menu : Component, IMenu, ISkinable
  {
    /// <summary>The Collapse event registration.</summary>
    private static readonly SerializableEvent CollapseEvent = SerializableEvent.Register("Collapse", typeof (EventHandler), typeof (Menu));
    /// <summary>The Popup event registration.</summary>
    private static readonly SerializableEvent PopupEvent = SerializableEvent.Register("Popup", typeof (EventHandler), typeof (Menu));
    /// <summary>The ItemsInternal property registration.</summary>
    private static readonly SerializableProperty ItemsProperty = SerializableProperty.Register("Items", typeof (MenuItemCollection), typeof (Menu));
    /// <summary>The IsRegisteredInternal property registration.</summary>
    private static readonly SerializableProperty IsRegisteredProperty = SerializableProperty.Register("IsRegistered", typeof (bool), typeof (Menu));
    /// <summary>The ReferenceCountInteranl property registration.</summary>
    private static readonly SerializableProperty ReferenceCountProperty = SerializableProperty.Register("ReferenceCount", typeof (int), typeof (Menu));
    /// <summary>The Owner property registration.</summary>
    private static readonly SerializableProperty OwnerProperty = SerializableProperty.Register(nameof (Owner), typeof (Component), typeof (Menu));
    /// <summary>The Member property registration.</summary>
    private static readonly SerializableProperty MemberProperty = SerializableProperty.Register(nameof (Member), typeof (IIdentifiedComponent), typeof (Menu));
    /// <summary>
    /// The ScrollerForItemcountExceedin property registration.
    /// </summary>
    private static readonly SerializableProperty AutoScrollItemCountProperty = SerializableProperty.Register(nameof (AutoScrollItemCount), typeof (int), typeof (Menu));
    /// <summary>The skin of the current menu</summary>
    [NonSerialized]
    private MenuSkin mobjSkin;

    /// <summary>Occurs when the shortcut menu collapses.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ContextMenuCollapseDescr")]
    public event EventHandler Collapse
    {
      add => this.AddHandler(Menu.CollapseEvent, (Delegate) value);
      remove => this.RemoveHandler(Menu.CollapseEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Collapse event.</summary>
    private EventHandler CollapseHandler => (EventHandler) this.GetHandler(Menu.CollapseEvent);

    /// <summary>Occurs before the shortcut menu is displayed.</summary>
    /// <filterpriority>1</filterpriority>
    [SRDescription("MenuItemOnInitDescr")]
    public event EventHandler Popup
    {
      add => this.AddHandler(Menu.PopupEvent, (Delegate) value);
      remove => this.RemoveHandler(Menu.PopupEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Popup event.</summary>
    private EventHandler PopupHandler => (EventHandler) this.GetHandler(Menu.PopupEvent);

    /// <summary>
    /// Displays the shortcut menu at the specified position and with the specified alignment.
    /// </summary>
    /// <param name="objComponent">The obj component.</param>
    /// <param name="objPoint">The obj point.</param>
    /// <param name="enmDialogAlignment">The enm dialog alignment.</param>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void Show(Component objComponent, Point objPoint, DialogAlignment enmDialogAlignment) => this.ShowInternal(objComponent, (IIdentifiedComponent) null, objPoint, enmDialogAlignment, new bool?());

    /// <summary>Shows the specified obj component.</summary>
    /// <param name="objComponent">The obj component.</param>
    /// <param name="objPoint">The obj point.</param>
    /// <param name="enmDialogAlignment">The enm dialog alignment.</param>
    /// <param name="blnShareFocus">if set to <c>true</c> [BLN share focus].</param>
    public void Show(
      Component objComponent,
      Point objPoint,
      DialogAlignment enmDialogAlignment,
      bool blnShareFocus)
    {
      this.ShowInternal(objComponent, (IIdentifiedComponent) null, objPoint, enmDialogAlignment, new bool?(blnShareFocus));
    }

    /// <summary>
    /// Displays the shortcut menu at the specified position and with the specified alignment.
    /// </summary>
    /// <param name="objSourceComponent">The obj source component.</param>
    /// <param name="objMemberComponent">The obj member component.</param>
    /// <param name="objPoint">The obj point.</param>
    /// <param name="enmDialogAlignment">The enm dialog alignment.</param>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void Show(
      Component objSourceComponent,
      IIdentifiedComponent objMemberComponent,
      Point objPoint,
      DialogAlignment enmDialogAlignment)
    {
      this.ShowInternal(objSourceComponent, objMemberComponent, objPoint, enmDialogAlignment, new bool?());
    }

    /// <summary>Displays the shortcut menu at the specified position.</summary>
    /// <param name="objComponent">The obj component.</param>
    /// <param name="objPoint">The obj point.</param>
    public void Show(Component objComponent, Point objPoint) => this.Show(objComponent, objPoint, DialogAlignment.Custom);

    /// <summary>
    /// Displays the shortcut menu at the specified position and with the specified alignment.
    /// </summary>
    /// <param name="objComponent">The obj component.</param>
    /// <param name="objPoint">The obj point.</param>
    /// <param name="enmLeftRightAlignment">The enm left right alignment.</param>
    [Obsolete("LeftRightAlignment is not suported yet")]
    public void Show(
      Component objComponent,
      Point objPoint,
      LeftRightAlignment enmLeftRightAlignment)
    {
      this.Show(objComponent, objPoint, DialogAlignment.Custom);
    }

    /// <summary>Shows the specified obj source component.</summary>
    /// <param name="objSourceComponent">The obj source component.</param>
    /// <param name="objMemberComponent">The obj member component.</param>
    /// <param name="objPoint">The obj point.</param>
    /// <param name="enmLeftRightAlignment">The enm left right alignment.</param>
    [Obsolete("LeftRightAlignment is not suported yet")]
    public void Show(
      Component objSourceComponent,
      IIdentifiedComponent objMemberComponent,
      Point objPoint,
      LeftRightAlignment enmLeftRightAlignment)
    {
      this.ShowInternal(objSourceComponent, objMemberComponent, objPoint, DialogAlignment.Custom, new bool?());
    }

    /// <summary>
    /// private function to deal with all the common code of the Show function.
    /// </summary>
    /// <param name="objComponent">&gt;The obj component.</param>
    /// <param name="objMemberComponent"></param>
    /// <param name="objPoint">The obj point.</param>
    /// <param name="enmDialogAlignment">The enm dialog alignment.</param>
    private void ShowInternal(
      Component objComponent,
      IIdentifiedComponent objMemberComponent,
      Point objPoint,
      DialogAlignment enmDialogAlignment,
      bool? blnShareFocus)
    {
      Menu.MenuForm mappedMenuForm = this.MappedMenuForm;
      if (objComponent != null)
        this.Owner = objComponent;
      if (objMemberComponent != null)
        this.Member = objMemberComponent;
      if (blnShareFocus.HasValue)
        mappedMenuForm.ShareFocus = blnShareFocus.Value;
      this.OnPopup(EventArgs.Empty);
      if (objMemberComponent != null)
        mappedMenuForm.ShowMenu(objComponent, objMemberComponent, objPoint, enmDialogAlignment);
      else
        mappedMenuForm.ShowMenu(objComponent, objPoint, enmDialogAlignment);
    }

    /// <summary>
    /// Raises the <see cref="E:Popup" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnPopup(EventArgs e)
    {
      EventHandler popupHandler = this.PopupHandler;
      if (popupHandler == null)
        return;
      popupHandler((object) this, e);
    }

    /// <summary>Gets the menu items.</summary>
    /// <value>The menu items.</value>
    ICollection IMenu.MenuItems => (ICollection) this.MenuItems;

    /// <summary>Gets the parent.</summary>
    /// <value>The parent.</value>
    IComponent IMenu.Parent => (IComponent) this.InternalParent;

    /// <summary>Adds a child object.</summary>
    /// <param name="objValue">The child object to add.</param>
    protected override void AddChild(object objValue)
    {
      if (objValue is MenuItem)
        this.MenuItems.Add((MenuItem) objValue);
      else
        base.AddChild(objValue);
    }

    /// <summary>Gets the skin of the current menu.</summary>
    /// <value>The skin of the current menu.</value>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    protected MenuSkin Skin
    {
      get
      {
        if (this.mobjSkin == null)
          this.mobjSkin = (MenuSkin) SkinFactory.GetSkin((ISkinable) this);
        return this.mobjSkin;
      }
    }

    /// <summary>Gets the theme related to the skinable component.</summary>
    /// <value>The theme related to the skinable component.</value>
    string ISkinable.Theme => this.Context.CurrentTheme;

    /// <summary>Gets or sets the context menu code.</summary>
    /// <value></value>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ContextMenu ContextMenu
    {
      get => base.ContextMenu;
      set => base.ContextMenu = value;
    }

    /// <summary>
    /// Number of items required in a single menu to activate scrollers (0 if always activate, -1 if never)
    /// </summary>
    /// <value>Number of items required in a single menu to activate scrollers (0 if always activate, -1 if never).</value>
    [DefaultValue(10)]
    [SRDescription("Number of items required in a single menu to activate scrollers (0 if always activate, -1 if never)")]
    [Localizable(true)]
    [SRCategory("Misc")]
    public int AutoScrollItemCount
    {
      get => this.GetValue<int>(Menu.AutoScrollItemCountProperty, 10);
      set => this.SetValue<int>(Menu.AutoScrollItemCountProperty, value);
    }

    /// <summary>Gets the menu items.</summary>
    /// <value>The menu items.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [ListBindable(false)]
    [Browsable(false)]
    public MenuItemCollection MenuItems
    {
      get
      {
        MenuItemCollection objValue = this.GetValue<MenuItemCollection>(Menu.ItemsProperty, (MenuItemCollection) null);
        if (objValue == null)
        {
          objValue = new MenuItemCollection((Component) this);
          this.SetValue<MenuItemCollection>(Menu.ItemsProperty, objValue);
        }
        return objValue;
      }
    }

    /// <summary>Gets the mapped menu form.</summary>
    /// <value>The mapped menu form.</value>
    private Menu.MenuForm MappedMenuForm
    {
      get
      {
        Menu.MenuForm mappedMenuForm = new Menu.MenuForm(this);
        if (this is ContextMenu && ((ContextMenu) this).RegisteredCollapseEvent)
          mappedMenuForm.Closed += new EventHandler(this.objMenuControl_Closed);
        return mappedMenuForm;
      }
    }

    /// <summary>
    /// Handles the Closed event of the objMenuControl control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void objMenuControl_Closed(object sender, EventArgs e)
    {
      if (!(this is ContextMenu))
        return;
      ((ContextMenu) this).OnCollapse(new EventArgs());
    }

    /// <summary>Gets or sets the owner control.</summary>
    /// <value>The owner control.</value>
    internal Component Owner
    {
      get => this.GetValue<Component>(Menu.OwnerProperty, (Component) null);
      set
      {
        if (value == this.Owner)
          return;
        this.SetValue<Component>(Menu.OwnerProperty, value);
      }
    }

    /// <summary>Gets or sets the member.</summary>
    /// <value>The member.</value>
    internal IIdentifiedComponent Member
    {
      get => this.GetValue<IIdentifiedComponent>(Menu.MemberProperty, (IIdentifiedComponent) null);
      set
      {
        if (value == this.Member)
          return;
        this.SetValue<IIdentifiedComponent>(Menu.MemberProperty, value);
      }
    }

    /// <summary>Fires the click.</summary>
    /// <param name="objMenuItem">The menu item.</param>
    protected internal void FireClick(MenuItem objMenuItem)
    {
      if (this.Owner is Menu.MenuItemControl owner)
      {
        if (owner.Form is Menu.MenuForm)
          owner.Form.Close();
        owner.FireClick(objMenuItem);
      }
      else
        this.Owner?.FireMenuClick(objMenuItem, this.Member);
    }

    /// <summary>Invokes when a menu item was clicked</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This event is obsolete")]
    public override event MenuEventHandler MenuClick
    {
      add => base.MenuClick += value;
      remove => base.MenuClick -= value;
    }

    /// <summary>
    /// <summary>Occurs when a drag-and-drop operation is completed.</summary>
    /// </summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This event is obsolete")]
    public override event DragEventHandler DragDrop
    {
      add => base.DragDrop += value;
      remove => base.DragDrop -= value;
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    internal class MenuForm : Form
    {
      /// <summary>
      /// The PreferdMenuItemIconWidthProperty property registration.
      /// </summary>
      private static readonly SerializableProperty PreferdMenuItemIconWidthProperty = SerializableProperty.Register("PreferdMenuItemIconWidth", typeof (int), typeof (Menu.MenuForm));
      private static readonly SerializableProperty PreferdMenuItemLabelWidthProperty = SerializableProperty.Register("PreferdMenuItemLabelWidth", typeof (int), typeof (Menu.MenuForm));
      private static readonly SerializableProperty PreferdMenuItemShortCutWidthProperty = SerializableProperty.Register("PreferdMenuItemShortCutWidth", typeof (int), typeof (Menu.MenuForm));
      private static readonly SerializableProperty PreferdMenuItemArrowWidthProperty = SerializableProperty.Register("PreferdMenuItemArrowWidth", typeof (int), typeof (Menu.MenuForm));
      private static readonly SerializableProperty ShareFocusProperty = SerializableProperty.Register(nameof (ShareFocus), typeof (bool), typeof (Menu.MenuForm));
      /// <summary>
      /// 
      /// </summary>
      private Menu mobjMenu;

      /// <summary>
      /// Gets a value indicating whether animation is enabled by default.
      /// </summary>
      /// <value><c>true</c> if animation is enabled by default; otherwise, <c>false</c>.</value>
      protected override bool DefaultAnimation => this.AnimationEnabled;

      /// <summary>
      /// Gets or sets the width of the mint preferd menu item icon.
      /// </summary>
      /// <value>The width of the mint preferd menu item icon.</value>
      internal int PreferdMenuItemIconWidthInternal
      {
        get => this.GetValue<int>(Menu.MenuForm.PreferdMenuItemIconWidthProperty);
        set => this.SetValue<int>(Menu.MenuForm.PreferdMenuItemIconWidthProperty, value);
      }

      /// <summary>
      /// Gets or sets a value indicating whether [share focus].
      /// </summary>
      /// <value><c>true</c> if [share focus]; otherwise, <c>false</c>.</value>
      internal bool ShareFocus
      {
        get => this.GetValue<bool>(Menu.MenuForm.ShareFocusProperty);
        set => this.SetValue<bool>(Menu.MenuForm.ShareFocusProperty, value);
      }

      /// <summary>
      /// Gets or sets the width of the mint preferd menu item label.
      /// </summary>
      /// <value>The width of the mint preferd menu item label.</value>
      internal int PreferdMenuItemLabelWidthInternal
      {
        get => this.GetValue<int>(Menu.MenuForm.PreferdMenuItemLabelWidthProperty);
        set => this.SetValue<int>(Menu.MenuForm.PreferdMenuItemLabelWidthProperty, value);
      }

      /// <summary>
      /// Gets or sets the width of the mint preferd menu item shotr cut.
      /// </summary>
      /// <value>The width of the mint preferd menu item shotr cut.</value>
      internal int PreferdMenuItemShortCutWidthInternal
      {
        get => this.GetValue<int>(Menu.MenuForm.PreferdMenuItemShortCutWidthProperty);
        set => this.SetValue<int>(Menu.MenuForm.PreferdMenuItemShortCutWidthProperty, value);
      }

      /// <summary>
      /// Gets or sets the width of the mint preferd menu item arrow.
      /// </summary>
      /// <value>The width of the mint preferd menu item arrow.</value>
      internal int PreferdMenuItemArrowWidthInternal
      {
        get => this.GetValue<int>(Menu.MenuForm.PreferdMenuItemArrowWidthProperty);
        set => this.SetValue<int>(Menu.MenuForm.PreferdMenuItemArrowWidthProperty, value);
      }

      /// <summary>Gets or sets the owning menu.</summary>
      /// <value>The owning menu.</value>
      public Menu OwningMenu => this.mobjMenu;

      /// <summary>
      /// Gets a value indicating whether to reverse control rendering.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if to reverse control rendering; otherwise, <c>false</c>.
      /// </value>
      protected override bool ReverseControls => true;

      /// <summary>Renders the forms attribute</summary>
      /// <param name="objContext"></param>
      /// <param name="objWriter"></param>
      protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
      {
        if (this.OwningMenu != null && this.OwningMenu is MenuItem && this.OwningMenu.Owner != null)
          objWriter.WriteAttributeString("oId", (double) this.OwningMenu.Owner.ID);
        if (this.ShareFocus)
          objWriter.WriteAttributeString("SF", "1");
        objWriter.WriteAttributeString("MILW", this.PreferdMenuItemLabelWidthInternal);
        if (this.PreferdMenuItemShortCutWidthInternal > 0)
          objWriter.WriteAttributeString("MISW", this.PreferdMenuItemShortCutWidthInternal);
        if (this.PreferdMenuItemArrowWidthInternal > 0)
          objWriter.WriteAttributeString("MIAW", this.PreferdMenuItemArrowWidthInternal);
        base.RenderAttributes(objContext, objWriter);
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="!:MenuControl" /> class.
      /// </summary>
      /// <param name="objMenu">The owner menu.</param>
      internal MenuForm(Menu objMenu)
      {
        this.CustomStyle = nameof (Menu);
        this.mobjMenu = objMenu;
        this.Size = new Size(200, 400);
      }

      /// <summary>Shows the menu.</summary>
      /// <param name="objComponent">The obj component.</param>
      /// <param name="objPoint">The obj point.</param>
      /// <param name="enmDialogAlignment">The enm dialog alignment.</param>
      internal void ShowMenu(
        Component objComponent,
        Point objPoint,
        DialogAlignment enmDialogAlignment)
      {
        if (this.OwningMenu == null || this.OwningMenu.MenuItems.Count <= 0)
          return;
        this.InitializeMenu(objPoint);
        int num = (int) this.ShowPopup(objComponent, enmDialogAlignment);
      }

      /// <summary>Shows the menu.</summary>
      /// <param name="objClientComponent">The obj client component.</param>
      /// <param name="objPoint">The obj point.</param>
      /// <param name="enmDialogAlignment">The enm dialog alignment.</param>
      internal void ShowMenu(
        Component objSourceComponent,
        IIdentifiedComponent objMemberComponent,
        Point objPoint,
        DialogAlignment enmDialogAlignment)
      {
        if (this.OwningMenu == null || this.OwningMenu.MenuItems.Count <= 0)
          return;
        this.InitializeMenu(objPoint);
        int num = (int) this.ShowPopup(objSourceComponent, objMemberComponent, enmDialogAlignment);
      }

      /// <summary>Shows the menu internal.</summary>
      /// <param name="objPoint">The obj point.</param>
      /// <returns></returns>
      private void InitializeMenu(Point objPoint)
      {
        this.Controls.Clear();
        bool flag1 = true;
        bool flag2 = false;
        int height = 0;
        Menu.MenuItemControl objSkinable1 = (Menu.MenuItemControl) null;
        Menu.MenuItemControl objSkinable2 = (Menu.MenuItemControl) null;
        foreach (MenuItem menuItem in this.OwningMenu.MenuItems)
        {
          if (menuItem.Visible)
          {
            Menu.MenuItemControl objValue = new Menu.MenuItemControl(menuItem);
            this.Controls.Add((Control) objValue);
            if (objSkinable1 == null && !menuItem.Enabled)
              objSkinable1 = objValue;
            if (!objValue.IsSeperator)
            {
              if (flag1)
              {
                objSkinable2 = objValue;
                this.PreferdMenuItemIconWidthInternal = objValue.GetPreferdIconColumnWidth();
                this.PreferdMenuItemArrowWidthInternal = objValue.GetPreferdArrowWidth();
                flag1 = false;
              }
              if (!flag2 && objValue.HasSubItems)
                flag2 = true;
              this.PreferdMenuItemLabelWidthInternal = Math.Max(this.PreferdMenuItemLabelWidthInternal, objValue.GetPreferdLableWidth());
              this.PreferdMenuItemShortCutWidthInternal = Math.Max(this.PreferdMenuItemShortCutWidthInternal, objValue.GetPreferdShortCutWidth());
            }
            height += objValue.Height;
          }
        }
        int width = this.PreferdMenuItemLabelWidthInternal + this.PreferdMenuItemShortCutWidthInternal + this.PreferdMenuItemIconWidthInternal;
        if (this.OwningMenu.AutoScrollItemCount >= 0 && this.OwningMenu.MenuItems.Count > this.OwningMenu.AutoScrollItemCount)
        {
          this.AutoScroll = true;
          this.ScrollerType = ScrollerType.Arrows;
        }
        if (SkinFactory.GetSkin((ISkinable) this.mobjMenu) is MenuSkin skin1)
        {
          height += skin1.PopupWindowOffsetHeight;
          width += skin1.PopupWindowOffsetWidth;
        }
        if (objSkinable2 != null && SkinFactory.GetSkin((ISkinable) objSkinable2) is MenuItemSkin skin2)
          width += this.Context.RightToLeft ? skin2.MenuItemIconPaddingLTR.Left + skin2.MenuItemIconPaddingLTR.Right : skin2.MenuItemIconPaddingRTL.Left + skin2.MenuItemIconPaddingRTL.Right;
        if (flag2)
          width += this.PreferdMenuItemArrowWidthInternal;
        if (width % 2 != 0)
          ++width;
        if (objSkinable1 != null && SkinFactory.GetSkin((ISkinable) objSkinable1) is MenuItemSkin skin3)
        {
          StyleValue controlDisabledStyle = skin3.ControlDisabledStyle;
          if (controlDisabledStyle != null && controlDisabledStyle.BorderStyle != BorderStyle.None)
          {
            int num1 = width;
            BorderWidth borderWidth = controlDisabledStyle.BorderWidth;
            int left = borderWidth.Left;
            borderWidth = controlDisabledStyle.BorderWidth;
            int right = borderWidth.Right;
            int num2 = left + right;
            width = num1 + num2;
          }
        }
        this.Size = new Size(width, height);
        if (!(objPoint != Point.Empty))
          return;
        this.Location = objPoint;
        this.StartPosition = FormStartPosition.Manual;
      }

      /// <summary>Gets the critical events.</summary>
      /// <returns></returns>
      protected override CriticalEventsData GetCriticalEventsData()
      {
        CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
        if (this.OwningMenu != null && this.OwningMenu is ContextMenu && ((ContextMenu) this.OwningMenu).RegisteredCollapseEvent)
          criticalEventsData.Set("CLO");
        return criticalEventsData;
      }

      /// <summary>Closes all hierarchic forms.</summary>
      internal void CloseAll()
      {
        this.Close();
        if (!(this.Owner is Menu.MenuForm owner))
          return;
        owner.CloseAll();
      }
    }

    /// <summary>
    /// 
    /// </summary>
    [MetadataTag("I")]
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof (MenuItemSkin))]
    [Serializable]
    internal class MenuItemControl : Control
    {
      private static readonly SerializableProperty ShortcutProperty = SerializableProperty.Register(nameof (Shortcut), typeof (Shortcut), typeof (Menu.MenuItemControl));
      /// <summary>
      /// 
      /// </summary>
      private MenuItem mobjMenuItem;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Menu.MenuItemControl" /> class.
      /// </summary>
      /// <param name="objMenuItem">The obj menu item.</param>
      internal MenuItemControl(MenuItem objMenuItem)
      {
        this.mobjMenuItem = objMenuItem;
        this.Text = objMenuItem.Text;
        this.Tag = (object) objMenuItem;
        this.VisualEffect = objMenuItem.VisualEffect;
        int num1 = !this.IsSeperator ? ((MenuItemSkin) this.Skin).Height : ((MenuItemSkin) this.Skin).SeperatorHeight;
        if (!objMenuItem.Enabled && this.Skin is MenuItemSkin skin)
        {
          StyleValue controlDisabledStyle = skin.ControlDisabledStyle;
          if (controlDisabledStyle != null && controlDisabledStyle.BorderStyle != BorderStyle.None)
          {
            int num2 = num1;
            BorderWidth borderWidth = controlDisabledStyle.BorderWidth;
            int top = borderWidth.Top;
            borderWidth = controlDisabledStyle.BorderWidth;
            int bottom = borderWidth.Bottom;
            int num3 = top + bottom;
            num1 = num2 + num3;
          }
        }
        this.Height = num1;
        if (this.HasSubItems)
          return;
        this.Click += new EventHandler(this.MenuItemControl_Click);
      }

      /// <summary>Fires an event.</summary>
      /// <param name="objEvent">event.</param>
      protected override void FireEvent(IEvent objEvent)
      {
        if (objEvent.Type == "Enter")
          this.OnEnter();
        base.FireEvent(objEvent);
      }

      /// <summary>
      /// </summary>
      /// <param name="objContext"></param>
      /// <param name="objWriter"></param>
      protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
      {
        if (this.mobjMenuItem != null)
        {
          if (!string.IsNullOrEmpty(this.mobjMenuItem.Text))
            objWriter.WriteAttributeText("TX", this.mobjMenuItem.Text, TextFilter.NewLine | TextFilter.CarriageReturn);
          if (this.HasSubItems)
            objWriter.WriteAttributeString("HN", "1");
          if (!this.mobjMenuItem.Enabled)
            objWriter.WriteAttributeString("En", "0");
          if (this.mobjMenuItem.Checked)
          {
            if (this.mobjMenuItem.RadioCheck)
              objWriter.WriteAttributeString("RC", "1");
            else
              objWriter.WriteAttributeString("C", "1");
          }
          if (this.mobjMenuItem.Icon != null)
            objWriter.WriteAttributeString("I", this.mobjMenuItem.Icon.ToString());
          if (this.IsSeperator)
            objWriter.WriteAttributeString("ISS", "1");
          if (this.mobjMenuItem.Shortcut != Shortcut.None)
            objWriter.WriteAttributeString("SC", this.GetShortcutString());
          this.mobjMenuItem.ClientAction?.RenderAttributes((IContextMethodInvoker) objContext, objWriter);
          this.mobjMenuItem.RenderExtendedComponentAttributes(objContext, objWriter);
        }
        base.RenderAttributes(objContext, objWriter);
      }

      /// <summary>
      /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click" />
      /// event.
      /// </summary>
      /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      protected override void OnClick(EventArgs objEventArgs)
      {
        if (this.mobjMenuItem == null || this.mobjMenuItem.MenuItems.Count == 0)
        {
          if (this.Form is Menu.MenuForm form)
            form.CloseAll();
          this.mobjMenuItem.FireClick();
        }
        base.OnClick(objEventArgs);
      }

      /// <summary>
      /// Raises the <see cref="E:TransitionVisualEffectEnd" /> event.
      /// </summary>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      protected override void OnTransitionVisualEffectEnd(EventArgs e)
      {
        if (this.mobjMenuItem == null)
          return;
        this.mobjMenuItem.OnTransitionVisualEffectEnd(new EventArgs());
      }

      /// <summary>
      /// Handles the Enter event of the MenuItemControl control.
      /// </summary>
      private void OnEnter() => this.ShowSubMenu(this.Tag as MenuItem);

      /// <summary>Gets/Sets the controls docking style</summary>
      /// <value></value>
      public override DockStyle Dock
      {
        get => DockStyle.Top;
        set => base.Dock = value;
      }

      /// <summary>
      /// Handles the Click event of the MenuItemControl control.
      /// </summary>
      /// <param name="sender">The source of the event.</param>
      /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
      private void MenuItemControl_Click(object sender, EventArgs e)
      {
        if (!(sender is Button button) || this.Form == null || !(button.Tag is MenuItem tag))
          return;
        if (this.HasSubItems)
          this.ShowSubMenu(tag);
        else
          this.OnClick(new EventArgs());
      }

      /// <summary>Shows the sub menu.</summary>
      /// <param name="objMenuItem">The obj menu item.</param>
      private void ShowSubMenu(MenuItem objMenuItem)
      {
        if (!this.HasSubItems)
          return;
        objMenuItem.Show((Component) this, Point.Empty, this.Context.RightToLeft ? DialogAlignment.Left : DialogAlignment.Right, true);
      }

      /// <summary>Fires the click.</summary>
      /// <param name="objMenuItem">The obj menu item.</param>
      internal void FireClick(MenuItem objMenuItem)
      {
        if (this.mobjMenuItem == null)
          return;
        Menu parent = this.mobjMenuItem.Parent;
        if (parent != null)
          parent.FireClick(objMenuItem);
        else
          this.mobjMenuItem.InternalParent?.FireMenuClick(objMenuItem);
      }

      /// <summary>
      /// Gets a value indicating whether this instance is seperator.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance is seperator; otherwise, <c>false</c>.
      /// </value>
      internal bool IsSeperator => this.mobjMenuItem.Text == "-";

      /// <summary>
      /// Gets a value indicating whether this instance has sub items.
      /// </summary>
      /// <value>
      /// 	<c>true</c> if this instance has sub items; otherwise, <c>false</c>.
      /// </value>
      internal bool HasSubItems => this.mobjMenuItem != null && this.mobjMenuItem.MenuItems.Count > 0;

      public Shortcut Shortcut
      {
        get => this.GetValue<Shortcut>(Menu.MenuItemControl.ShortcutProperty);
        set
        {
          if (this.Shortcut == value)
            return;
          this.SetValue<Shortcut>(Menu.MenuItemControl.ShortcutProperty, value);
        }
      }

      /// <summary>Gets the shortcut string.</summary>
      /// <returns></returns>
      private string GetShortcutString()
      {
        TypeConverter converter = TypeDescriptor.GetConverter(typeof (Keys));
        return converter != null ? converter.ConvertToString((object) (Keys) this.mobjMenuItem.Shortcut) : this.Shortcut.ToString();
      }

      /// <summary>Gets the width of the preferd lable.</summary>
      /// <returns></returns>
      internal int GetPreferdLableWidth()
      {
        if (string.IsNullOrEmpty(this.Text))
          return 0;
        if (!(this.Skin is MenuItemSkin skin) || this.Font == null)
          return this.Text.Length * 10;
        StyleValue styleValue = (StyleValue) skin.MenuItemLabelNormalStyle.GetObject(this.Context);
        int num = 0;
        if (styleValue != null)
          num = styleValue.Padding.Left + styleValue.Padding.Right;
        return CommonUtils.GetStringMeasurements(this.Text, this.Font, true).Width + num;
      }

      /// <summary>Gets the font of the text displayed by the control.</summary>
      /// <value></value>
      public override Font Font
      {
        get
        {
          MenuItemSkin skin = this.Skin as MenuItemSkin;
          Font font = base.Font;
          if (skin != null)
          {
            StyleValue styleValue = (StyleValue) ((BidirectionalSkinValue<StyleValue>) skin.MenuItemNormalCenter).GetObject(this.Context);
            if (styleValue != null)
              font = styleValue.Font;
          }
          return font;
        }
      }

      /// <summary>Gets the width of the preferd short cut.</summary>
      /// <returns></returns>
      internal int GetPreferdShortCutWidth()
      {
        if (this.mobjMenuItem.Shortcut == Shortcut.None)
          return 0;
        string shortcutString = this.GetShortcutString();
        if (!(this.Skin is MenuItemSkin skin) || this.Font == null)
          return shortcutString.Length * 10;
        StyleValue styleValue = (StyleValue) skin.MenuItemLabelNormalStyle.GetObject(this.Context);
        int num = 0;
        if (styleValue != null)
          num = styleValue.Padding.Left + styleValue.Padding.Right;
        return CommonUtils.GetStringMeasurements(shortcutString, this.Font, true).Width + num;
      }

      /// <summary>Gets the width of the preferd arrow.</summary>
      /// <returns></returns>
      internal int GetPreferdArrowWidth()
      {
        if (!(this.Skin is MenuItemSkin skin))
          return 0;
        PaddingValue paddingValue = (PaddingValue) skin.MenuItemArrowPadding.GetObject(this.Context);
        int num = 0;
        if (paddingValue != null)
          num = paddingValue.Left + paddingValue.Right;
        return int.Parse(skin.ArrowImageWidth.GetValue(this.Context)) + num;
      }

      /// <summary>Gets the width of the preferd icon column.</summary>
      /// <returns></returns>
      internal int GetPreferdIconColumnWidth() => this.Skin is MenuItemSkin skin ? skin.MenuItemIconsColumnWidth : 0;
    }
  }
}
