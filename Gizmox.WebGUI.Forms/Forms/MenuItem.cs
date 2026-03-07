// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MenuItem
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Summary description for Menu Item.</summary>
  [DefaultProperty("Text")]
  [ToolboxItem(false)]
  [DesignTimeVisible(false)]
  [DefaultEvent("Click")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.MenuItemController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.MenuItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Serializable]
  public class MenuItem : Menu
  {
    /// <summary>The TextInteranl property registration.</summary>
    private static readonly SerializableProperty TextProperty = SerializableProperty.Register(nameof (Text), typeof (string), typeof (MenuItem));
    /// <summary>The IconInteranl property registration.</summary>
    private static readonly SerializableProperty IconProperty = SerializableProperty.Register(nameof (Icon), typeof (ResourceHandle), typeof (MenuItem));
    /// <summary>The RadioCheckInteranl property registration.</summary>
    private static readonly SerializableProperty RadioCheckProperty = SerializableProperty.Register(nameof (RadioCheck), typeof (bool), typeof (MenuItem));
    /// <summary>The ShortcutInternal property registration.</summary>
    private static readonly SerializableProperty ShortcutProperty = SerializableProperty.Register(nameof (Shortcut), typeof (Shortcut), typeof (MenuItem));
    /// <summary>The Click event registration.</summary>
    private static readonly SerializableEvent ClickEvent = SerializableEvent.Register("Click", typeof (EventHandler), typeof (MenuItem));
    /// <summary>The Enter event registration.</summary>
    private static readonly SerializableEvent EnterEvent = SerializableEvent.Register("Enter", typeof (EventHandler), typeof (MenuItem));
    /// <summary>The ShowShortcut property registration.</summary>
    private static readonly SerializableProperty ShowShortcutProperty = SerializableProperty.Register(nameof (ShowShortcut), typeof (bool), typeof (MenuItem));
    /// <summary>The Name property registration.</summary>
    private static readonly SerializableProperty NameProperty = SerializableProperty.Register(nameof (Name), typeof (string), typeof (MenuItem));

    /// <summary>Initializes a <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> with a blank caption.</summary>
    public MenuItem()
    {
      this.TextInteranl = "";
      this.InitializeState();
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> class with a specified caption for the menu item.</summary>
    /// <param name="strText">The caption for the menu item. </param>
    public MenuItem(string strText)
    {
      this.TextInteranl = strText;
      this.InitializeState();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> class.
    /// </summary>
    /// <param name="strText">The text.</param>
    /// <param name="strIcon">The icon.</param>
    public MenuItem(string strText, string strIcon)
    {
      this.TextInteranl = strText;
      if (strIcon != "")
        this.IconInteranl = (ResourceHandle) new IconResourceHandle(strIcon + ".gif");
      this.InitializeState();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> class.
    /// </summary>
    /// <param name="strText">The menu item Text</param>
    /// <param name="strIcon">The menu item icon</param>
    /// <param name="objTag">The obj tag.</param>
    public MenuItem(string strText, string strIcon, object objTag)
      : this(strText, strIcon)
    {
      this.Tag = objTag;
    }

    /// <summary>Initializes a new instance of the class with a specified caption and event handler for the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Click"></see> event of the menu item.</summary>
    /// <param name="onClick">The <see cref="T:System.EventHandler"></see> that handles the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Click"></see> event for this menu item. </param>
    /// <param name="strText">The caption for the menu item. </param>
    public MenuItem(string strText, EventHandler onClick)
      : this(MenuMerge.Add, 0, Shortcut.None, strText, onClick, (EventHandler) null, (EventHandler) null, (MenuItem[]) null)
    {
    }

    /// <summary>Initializes a new instance of the class with a specified caption and an array of submenu items defined for the menu item.</summary>
    /// 
    ///             The items param is not impemented.
    ///             <param name="arrItems">An array of <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> objects that contains the submenu items for this menu item[not impemented]. </param>
    /// <param name="strText">The caption for the menu item. </param>
    [Obsolete("The items param is not impemented use public MenuItem(string strText)")]
    public MenuItem(string strText, MenuItem[] arrItems)
      : this(MenuMerge.Add, 0, Shortcut.None, strText, (EventHandler) null, (EventHandler) null, (EventHandler) null, arrItems)
    {
    }

    /// <summary>Initializes a new instance of the class with a specified caption, event handler, and associated shortcut key for the menu item.</summary>
    /// <param name="onClick">The <see cref="T:System.EventHandler"></see> that handles the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Click"></see> event for this menu item. </param>
    /// <param name="enmShortcut">One of the <see cref="T:Gizmox.WebGUI.Forms.Shortcut"></see> values. </param>
    /// <param name="strText">The caption for the menu item. </param>
    public MenuItem(string strText, EventHandler onClick, Shortcut enmShortcut)
      : this(MenuMerge.Add, 0, enmShortcut, strText, onClick, (EventHandler) null, (EventHandler) null, (MenuItem[]) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> class with a specified caption; defined event-handlers for the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Click"></see>, <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Select"></see> and <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Popup"></see> events; a shortcut key; a merge type; and order specified for the menu item.</summary>
    /// 
    ///             The mergeType, mergeOrder, onSelect, onPopup and items params are not impemented.
    ///             <param name="onSelect">The <see cref="T:System.EventHandler"></see> that handles the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Select"></see> event for this menu item[not impemented]. </param>
    /// <param name="intMergeOrder">The relative position that this menu item will take in a merged menu[not impemented]. </param>
    /// <param name="arrItems">An array of <see cref="T:Gizmox.WebGUI.Forms.MenuItem"></see> objects that contains the submenu items for this menu item[not impemented]. </param>
    /// <param name="onClick">The <see cref="T:System.EventHandler"></see> that handles the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Click"></see> event for this menu item. </param>
    /// <param name="enmMergeType">One of the <see cref="T:Gizmox.WebGUI.Forms.MenuMerge"></see> values[not impemented]. </param>
    /// <param name="onPopup">The <see cref="T:System.EventHandler"></see> that handles the <see cref="E:Gizmox.WebGUI.Forms.MenuItem.Popup"></see> event for this menu item[not impemented]. </param>
    /// <param name="enmShortcut">One of the <see cref="T:Gizmox.WebGUI.Forms.Shortcut"></see> values. </param>
    /// <param name="strText">The caption for the menu item. </param>
    [Obsolete("TThe mergeType, mergeOrder, onSelect, onPopup and items params are not impemented use public MenuItem(string text, EventHandler onClick, Shortcut shortcut)")]
    public MenuItem(
      MenuMerge enmMergeType,
      int intMergeOrder,
      Shortcut enmShortcut,
      string strText,
      EventHandler onClick,
      EventHandler onPopup,
      EventHandler onSelect,
      MenuItem[] arrItems)
    {
      this.TextInteranl = strText;
      this.Click += onClick;
      this.ShortcutInternal = enmShortcut;
      this.InitializeState();
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      if (!this.Visible || !this.Enabled)
        return;
      base.FireEvent(objEvent);
      switch (objEvent.Type)
      {
        case "DoubleClick":
          if (!this.Enabled || this.InternalParent == null || !(this.InternalParent is MainMenu))
            break;
          ((MainMenu) this.InternalParent).FireDoubleClick(new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 2, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0));
          break;
        case "Shortcut":
        case "Click":
          if (!this.Enabled)
            break;
          bool flag = true;
          if (objEvent.Type == "Click")
          {
            flag = MouseButtons.Left == this.GetEventButtonsValue(objEvent, MouseButtons.Left);
            if (this.InternalParent != null && this.InternalParent is MainMenu)
              ((MainMenu) this.InternalParent).FireClick(new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0));
          }
          if (!flag)
            break;
          if (this.MenuItems.Count == 0)
            this.OnClick(new EventArgs());
          else
            this.Show((Component) this, Point.Empty, DialogAlignment.Below);
          Component ancestorByType = this.GetAncestorByType(typeof (Control));
          if (ancestorByType == null || this.MenuItems.Count != 0)
            break;
          ancestorByType.FireMenuClick(this);
          break;
        case "Enter":
          if (!this.Enabled || this.EnterHandler == null)
            break;
          this.EnterHandler((object) this, new EventArgs());
          break;
      }
    }

    /// <summary>
    /// Raises the <see cref="E:Click" /> event.
    /// </summary>
    /// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void OnClick(EventArgs objEventArgs)
    {
      if (this.ClickHandler == null)
        return;
      this.ClickHandler((object) this, objEventArgs);
    }

    internal void AttachedToDOM()
    {
      this.RegisterShortcut();
      this.MenuItems.AttachedToDOM();
    }

    internal void RemovingFromDOM()
    {
      this.UnregisterShortcut(false);
      this.MenuItems.RemovingFromDOM();
    }

    private void UnregisterShortcut(bool blnForce)
    {
      if (!(this.ShortcutInternal != 0 | blnForce))
        return;
      this.Form?.Shortcuts.Remove((IRegisteredComponent) this);
    }

    private void RegisterShortcut()
    {
      if (this.ShortcutInternal == Shortcut.None)
        return;
      this.Form?.Shortcuts.Add(this.ShortcutInternal.ToString(), (IRegisteredComponent) this);
    }

    /// <summary>Fires the click.</summary>
    internal void FireClick()
    {
      if (this.ClickHandler != null)
        this.ClickHandler((object) this, new EventArgs());
      if (this.Parent == null)
        return;
      this.Parent.FireClick(this);
    }

    /// <summary>Initializes the state.</summary>
    private void InitializeState() => this.SetState(Component.ComponentState.Visible | Component.ComponentState.Enabled, true);

    /// <summary>Disposes the specified component.</summary>
    /// <param name="blnDisposing"></param>
    protected override void Dispose(bool blnDisposing)
    {
      if (blnDisposing && this.Parent != null)
        this.Parent.MenuItems.Remove(this);
      base.Dispose(blnDisposing);
    }

    /// <summary>Gets the component offsprings.</summary>
    /// <param name="strOffspringTypeName">The offspring type.</param>
    /// <returns></returns>
    protected internal override IList GetComponentOffsprings(string strOffspringTypeName) => (IList) this.MenuItems;

    private string TextInteranl
    {
      get => this.GetValue<string>(MenuItem.TextProperty, string.Empty);
      set => this.SetValue<string>(MenuItem.TextProperty, value);
    }

    private ResourceHandle IconInteranl
    {
      get => this.GetValue<ResourceHandle>(MenuItem.IconProperty, (ResourceHandle) null);
      set => this.SetValue<ResourceHandle>(MenuItem.IconProperty, value);
    }

    private bool RadioCheckInteranl
    {
      get => this.GetValue<bool>(MenuItem.RadioCheckProperty, false);
      set => this.SetValue<bool>(MenuItem.RadioCheckProperty, value);
    }

    private Shortcut ShortcutInternal
    {
      get => this.GetValue<Shortcut>(MenuItem.ShortcutProperty, Shortcut.None);
      set => this.SetValue<Shortcut>(MenuItem.ShortcutProperty, value);
    }

    /// <summary>
    /// 
    /// </summary>
    public override Component InternalParent
    {
      get => base.InternalParent;
      set
      {
        if (base.InternalParent == value)
          return;
        if (value == null && base.InternalParent != null)
          this.UnregisterShortcut(false);
        base.InternalParent = value;
        if (value == null)
          return;
        this.RegisterShortcut();
      }
    }

    /// <summary>Gets or sets the shortcut.</summary>
    /// <value></value>
    [DefaultValue(Shortcut.None)]
    public Shortcut Shortcut
    {
      get => this.ShortcutInternal;
      set
      {
        if (this.ShortcutInternal == value)
          return;
        this.ShortcutInternal = value;
        if (this.DesignMode)
          return;
        if (value == Shortcut.None)
          this.UnregisterShortcut(true);
        else
          this.RegisterShortcut();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to show shortcut.
    /// </summary>
    /// <value><c>true</c> if [show shortcut]; otherwise, <c>false</c>.</value>
    [Localizable(true)]
    [SRDescription("MenuItemShowShortCutDescr")]
    [DefaultValue(true)]
    public bool ShowShortcut
    {
      get => this.GetValue<bool>(MenuItem.ShowShortcutProperty, true);
      set
      {
        if (value == this.ShowShortcut)
          return;
        if (!value)
          this.SetValue<bool>(MenuItem.ShowShortcutProperty, value);
        else
          this.RemoveValue<bool>(MenuItem.ShowShortcutProperty);
      }
    }

    /// <summary>Gets or sets the menu item Text.</summary>
    [DefaultValue("")]
    [Localizable(true)]
    [SRDescription("MenuItemTextDescr")]
    public string Text
    {
      get => this.TextInteranl;
      set
      {
        if (!(this.TextInteranl != value))
          return;
        this.TextInteranl = value;
        if (this.InternalParent == null || !(this.InternalParent is MainMenu))
          return;
        this.InternalParent.Update();
      }
    }

    /// <summary>
    ///  Gets or sets a value indicating whether a check mark
    ///  appears next to the text of the menu item.
    /// </summary>
    [DefaultValue(false)]
    public bool Checked
    {
      get => this.GetState(Component.ComponentState.Checked);
      set => this.SetState(Component.ComponentState.Checked, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether the MenuItem , if checked,
    /// displays a radio-button instead of a check mark.
    /// </summary>
    [DefaultValue(false)]
    public bool RadioCheck
    {
      get => this.RadioCheckInteranl;
      set => this.RadioCheckInteranl = value;
    }

    /// <summary>Gets or sets the menu icon.</summary>
    /// <value></value>
    [DefaultValue(null)]
    public ResourceHandle Icon
    {
      get => this.IconInteranl;
      set => this.IconInteranl = value;
    }

    /// <summary>Indicated if the menu item is visible.</summary>
    [DefaultValue(true)]
    [Browsable(false)]
    public bool Visible
    {
      get => this.GetState(Component.ComponentState.Visible);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.Visible, value) || this.InternalParent == null || !(this.InternalParent is MainMenu))
          return;
        this.InternalParent.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> is enabled.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if enabled; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    public bool Enabled
    {
      get => this.GetState(Component.ComponentState.Enabled);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.Enabled, value) || this.InternalParent == null || !(this.InternalParent is MainMenu))
          return;
        this.InternalParent.Update();
      }
    }

    /// <summary>Gets the parent menu of this menu item.</summary>
    /// <value></value>
    [Browsable(false)]
    public Menu Parent => this.InternalParent as Menu;

    /// <summary>Gets the parent menu items.</summary>
    /// <value>The parent menu items.</value>
    private MenuItemCollection ParentMenuItems
    {
      get
      {
        MenuItemCollection parentMenuItems = (MenuItemCollection) null;
        if (this.InternalParent != null)
        {
          if (this.InternalParent is MainMenu)
            parentMenuItems = ((MainMenu) this.InternalParent).MenuItems;
          else if (this.InternalParent is Menu)
            parentMenuItems = ((Menu) this.InternalParent).MenuItems;
        }
        return parentMenuItems;
      }
    }

    /// <summary>
    /// <para> Gets or sets a value indicating the position of the menu item in its parent menu.</para>
    /// </summary>
    [Browsable(false)]
    public int Index
    {
      get => this.ParentMenuItems != null ? ((IList) this.ParentMenuItems).IndexOf((object) this) : -1;
      set
      {
        int index = this.Index;
        if (index < 0)
          return;
        if (value < 0 || value >= this.ParentMenuItems.Count)
          throw new ArgumentException(SR.GetString("InvalidArgument", (object) nameof (value), (object) value.ToString()));
        if (value == index)
          return;
        this.ParentMenuItems.RemoveAt(index);
        this.ParentMenuItems.Add(value, this);
      }
    }

    /// <summary>Gets the name.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public string Name
    {
      get => this.GetValue<string>(MenuItem.NameProperty, string.Empty);
      set => this.SetValue<string>(MenuItem.NameProperty, value);
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
    public event EventHandler Click
    {
      add => this.AddHandler(MenuItem.ClickEvent, (Delegate) value);
      remove => this.RemoveHandler(MenuItem.ClickEvent, (Delegate) value);
    }

    /// <summary>Occurs when [enter].</summary>
    public event EventHandler Enter
    {
      add => this.AddHandler(MenuItem.EnterEvent, (Delegate) value);
      remove => this.RemoveHandler(MenuItem.EnterEvent, (Delegate) value);
    }

    /// <summary>Gets the hanlder for the Click event.</summary>
    internal EventHandler ClickHandler => (EventHandler) this.GetHandler(MenuItem.ClickEvent);

    /// <summary>Gets the enter handler.</summary>
    /// <value>The enter handler.</value>
    private EventHandler EnterHandler => (EventHandler) this.GetHandler(MenuItem.EnterEvent);
  }
}
