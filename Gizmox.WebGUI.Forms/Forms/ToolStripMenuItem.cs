// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripMenuItem
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a selectable option displayed on a <see cref="T:System.Windows.Forms.MenuStrip"></see> or <see cref="T:System.Windows.Forms.ContextMenuStrip"></see>. Although <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see> replaces and adds functionality to the <see cref="T:System.Windows.Forms.MenuItem"></see> control of previous versions, <see cref="T:System.Windows.Forms.MenuItem"></see> is retained for both backward compatibility and future use if you choose.</summary>
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripMenuItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip | ToolStripItemDesignerAvailability.MenuStrip)]
  [Skin(typeof (ToolStripMenuItemSkin))]
  [Serializable]
  public class ToolStripMenuItem : ToolStripDropDownItem
  {
    private static readonly SerializableProperty mblnCheckOnClickProperty = SerializableProperty.Register(nameof (mblnCheckOnClick), typeof (bool), typeof (ToolStripMenuItem));
    private static readonly SerializableProperty menmCheckStateProperty = SerializableProperty.Register(nameof (menmCheckState), typeof (CheckState), typeof (ToolStripMenuItem));
    private static readonly SerializableProperty mobjMdiFormProperty = SerializableProperty.Register(nameof (mobjMdiForm), typeof (Form), typeof (ToolStripMenuItem));
    private static readonly SerializableProperty mstrShortcutKeyDisplayStringProperty = SerializableProperty.Register(nameof (mstrShortcutKeyDisplayString), typeof (string), typeof (ToolStripMenuItem));
    private static readonly SerializableProperty menmShortcutKeysProperty = SerializableProperty.Register(nameof (menmShortcutKeys), typeof (Keys), typeof (ToolStripMenuItem));
    private static readonly SerializableProperty mblnShowShortcutKeysProperty = SerializableProperty.Register(nameof (mblnShowShortcutKeys), typeof (bool), typeof (ToolStripMenuItem));
    private static readonly SerializableEvent CheckedChangedEvent = SerializableEvent.Register("CheckedChanged", typeof (EventHandler), typeof (ToolStripMenuItem));
    private static readonly SerializableEvent CheckStateChangedEvent = SerializableEvent.Register("CheckStateChanged", typeof (EventHandler), typeof (ToolStripMenuItem));
    [NonSerialized]
    private TypeConverter mobjTypeConverter;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class.</summary>
    public ToolStripMenuItem() => this.mblnShowShortcutKeys = true;

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified text.</summary>
    /// <param name="text">The text to display on the menu item.</param>
    public ToolStripMenuItem(string text)
      : base(text, (ResourceHandle) null, (EventHandler) null)
    {
      this.mblnShowShortcutKeys = true;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see>.</summary>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param>
    public ToolStripMenuItem(ResourceHandle image)
      : base((string) null, image, (EventHandler) null)
    {
      this.mblnShowShortcutKeys = true;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified text and image.</summary>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param>
    /// <param name="text">The text to display on the menu item.</param>
    public ToolStripMenuItem(string text, ResourceHandle image)
      : base(text, image, (EventHandler) null)
    {
      this.mblnShowShortcutKeys = true;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified text and image and that does the specified action when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is clicked.</summary>
    /// <param name="onClick">An event handler that raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event when the control is clicked.</param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param>
    /// <param name="text">The text to display on the menu item.</param>
    public ToolStripMenuItem(string text, ResourceHandle image, EventHandler onClick)
      : base(text, image, onClick)
    {
      this.mblnShowShortcutKeys = true;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class with the specified name that displays the specified text and image that does the specified action when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is clicked.</summary>
    /// <param name="onClick">An event handler that raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event when the control is clicked.</param>
    /// <param name="name">The name of the menu item.</param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param>
    /// <param name="text">The text to display on the menu item.</param>
    public ToolStripMenuItem(string text, ResourceHandle image, EventHandler onClick, string name)
      : base(text, image, onClick, (string) null)
    {
      this.mblnShowShortcutKeys = true;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified text and image and that contains the specified <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> collection.</summary>
    /// <param name="dropDownItems">The menu items to display when the control is clicked.</param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param>
    /// <param name="text">The text to display on the menu item.</param>
    public ToolStripMenuItem(string text, ResourceHandle image, ToolStripItem[] dropDownItems)
      : base(text, image, dropDownItems)
    {
      this.mblnShowShortcutKeys = true;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> class that displays the specified text and image, does the specified action when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is clicked, and displays the specified shortcut keys.</summary>
    /// <param name="onClick">An event handler that raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event when the control is clicked.</param>
    /// <param name="shortcutKeys">One of the values of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> that represents the shortcut key for the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to display on the control.</param>
    /// <param name="text">The text to display on the menu item.</param>
    public ToolStripMenuItem(
      string text,
      ResourceHandle image,
      EventHandler onClick,
      Keys shortcutKeys)
      : base(text, image, onClick)
    {
      this.mblnShowShortcutKeys = true;
      this.ShortcutKeys = shortcutKeys;
    }

    /// <summary>Gets the preferred size with image.</summary>
    /// <param name="objSizeWithoutImage">The obj size without image.</param>
    /// <returns></returns>
    protected internal override Size GetPreferredSizeByImage(Size objSizeWithoutImage) => base.GetPreferredSizeByImage(objSizeWithoutImage);

    /// <summary>Gets the preferred size by text.</summary>
    /// <returns></returns>
    protected internal override Size GetPreferredeSizeByText() => (this.DisplayStyle == ToolStripItemDisplayStyle.ImageAndText || this.DisplayStyle == ToolStripItemDisplayStyle.Text) && !string.IsNullOrEmpty(this.Text) ? this.GetTextSize(this.Text) : this.GetTextSize(" ");

    /// <summary>
    /// Retrieves the size of a rectangular area into which a control can be fit.
    /// </summary>
    /// <param name="objConstrainingSize">The custom-sized area for a control.</param>
    /// <returns>
    /// A <see cref="T:System.Drawing.Size"></see> ordered pair, representing the width and height of a rectangle.
    /// </returns>
    /// <PermissionSet>
    /// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    /// <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    public override Size GetPreferredSize(Size objConstrainingSize)
    {
      Size preferredSizeByImage = this.GetPreferredSizeByImage(this.GetPreferredeSizeByText());
      if (SkinFactory.GetSkin((ISkinable) this) is ToolStripMenuItemSkin skin)
      {
        string keyDisplayString = this.GetShortcutKeyDisplayString();
        bool flag = this.ShowShortcutKeys && !string.IsNullOrEmpty(keyDisplayString);
        BorderWidth borderWidth1 = skin.MenuItemStyle.Border.Style != BorderStyle.None ? skin.MenuItemStyle.Border.Width : BorderWidth.Empty;
        BorderWidth borderWidth2 = skin.BorderStyle != BorderStyle.None ? skin.BorderWidth : BorderWidth.Empty;
        preferredSizeByImage.Width += skin.Padding.Horizontal + borderWidth2.Left + borderWidth2.Right + borderWidth1.Left + borderWidth1.Right;
        preferredSizeByImage.Height += skin.Padding.Vertical + borderWidth2.Top + borderWidth2.Bottom + borderWidth1.Top + borderWidth1.Bottom;
        if (!this.IsTopLevel && flag)
        {
          preferredSizeByImage.Width += skin.TextShortcutGapSize;
          preferredSizeByImage.Width += skin.ArrowEdgeGapSize;
          preferredSizeByImage.Width += this.GetTextSize(this.GetShortcutKeyDisplayString()).Width;
        }
      }
      return preferredSizeByImage;
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      switch (objEvent.Type)
      {
        case "Shortcut":
          this.OnClick((EventArgs) new MouseEventArgs(this.GetEventButtonsValue(objEvent, MouseButtons.Left), 1, this.GetEventValue(objEvent, "X", 0), this.GetEventValue(objEvent, "Y", 0), 0));
          break;
        case "CheckedChange":
          bool result = false;
          if (!bool.TryParse(objEvent["C"], out result))
            break;
          this.Checked = result;
          break;
        case "Enter":
          this.OnEnter();
          break;
      }
    }

    /// <summary>Renders the tool strip item's drop down attribute.</summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    protected override void RenderToolStripDropDownItemDropDownAttribute(
      IAttributeWriter objAttributeWriter)
    {
    }

    /// <summary>Renders the tool strip item's attributes.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objAttributeWriter">The attribute writer.</param>
    protected override void RenderToolStripItemAttributes(
      IContext objContext,
      IAttributeWriter objAttributeWriter)
    {
      base.RenderToolStripItemAttributes(objContext, objAttributeWriter);
      this.RenderToolStripItemCheckedAttribute(objContext, objAttributeWriter, false);
      this.RenderToolStripItemCheckedOnClickAttribute(objAttributeWriter, false);
      this.RenderToolStripItemHasNodesAttribute(objContext, objAttributeWriter, false);
      this.RenderToolstripMenuItemShortCutAttribute(objContext, objAttributeWriter, false);
    }

    /// <summary>Renders the toolstrip menu item short cut attribute.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForce">if set to <c>true</c> [BLN force].</param>
    private void RenderToolstripMenuItemShortCutAttribute(
      IContext objContext,
      IAttributeWriter objAttributeWriter,
      bool blnForce)
    {
      string keyDisplayString = this.GetShortcutKeyDisplayString();
      if (!string.IsNullOrEmpty(keyDisplayString))
      {
        objAttributeWriter.WriteAttributeString("SC", keyDisplayString);
        objAttributeWriter.WriteAttributeString("SCW", this.GetTextSize(keyDisplayString).Width.ToString());
      }
      else
      {
        if (!blnForce)
          return;
        objAttributeWriter.WriteAttributeString("SC", string.Empty);
        objAttributeWriter.WriteAttributeString("SCW", "");
      }
    }

    /// <summary>
    /// Renders the tool strip item checked on click attribute.
    /// </summary>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderToolStripItemCheckedOnClickAttribute(
      IAttributeWriter objAttributeWriter,
      bool blnForceRender)
    {
      if (!(this.mblnCheckOnClick | blnForceRender))
        return;
      objAttributeWriter.WriteAttributeText("COC", this.mblnCheckOnClick ? "1" : "0");
    }

    /// <summary>Renders the tool strip item has nodes attribute.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    protected virtual void RenderToolStripItemHasNodesAttribute(
      IContext objContext,
      IAttributeWriter objAttributeWriter,
      bool blnForceRender)
    {
      bool flag = this.DropDownItems.Count > 0;
      if (!(flag | blnForceRender))
        return;
      objAttributeWriter.WriteAttributeString("HN", flag ? "1" : "0");
    }

    /// <summary>Renders the tool strip item updated attributes.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objAttributeWriter">The attribute writer.</param>
    /// <param name="lngRequestID">The request ID.</param>
    protected override void RenderToolStripItemUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objAttributeWriter,
      long lngRequestID)
    {
      base.RenderToolStripItemUpdatedAttributes(objContext, objAttributeWriter, lngRequestID);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        this.RenderToolStripItemCheckedAttribute(objContext, objAttributeWriter, true);
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
      {
        this.RenderToolStripItemCheckedOnClickAttribute(objAttributeWriter, true);
        this.RenderToolstripMenuItemShortCutAttribute(objContext, objAttributeWriter, false);
      }
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Extended))
        return;
      this.RenderToolStripItemHasNodesAttribute(objContext, objAttributeWriter, true);
    }

    /// <summary>Renders the tool strip item checked attribute.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objAttributeWriter">The obj attribute writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    protected virtual void RenderToolStripItemCheckedAttribute(
      IContext objContext,
      IAttributeWriter objAttributeWriter,
      bool blnForceRender)
    {
      CheckState checkState = this.CheckState;
      if (!(checkState != 0 | blnForceRender))
        return;
      objAttributeWriter.WriteAttributeString("C", Convert.ToInt32((object) checkState).ToString());
    }

    /// <summary>
    /// Handles the Enter event of the MenuItemControl control.
    /// </summary>
    private void OnEnter() => this.DropDown?.Show();

    /// <summary>Retrieves a value indicating whether a defined shortcut key is valid.</summary>
    /// <returns>true if the shortcut key is valid; otherwise, false. </returns>
    /// <param name="shortcut">The shortcut key to test for validity.</param>
    private bool IsValidShortcut(Keys shortcut)
    {
      Keys keys1 = shortcut & Keys.KeyCode;
      Keys keys2 = shortcut & Keys.Modifiers;
      if (shortcut == Keys.None)
        return false;
      if (keys1 == Keys.Insert || keys1 == Keys.Delete || keys1 >= Keys.F1 && keys1 <= Keys.F24)
        return true;
      if (keys1 == Keys.None || keys2 == Keys.None)
        return false;
      switch (keys1)
      {
        case Keys.ShiftKey:
        case Keys.ControlKey:
        case Keys.Menu:
          return false;
        default:
          return keys2 != Keys.Shift;
      }
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripMenuItem.CheckedChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnCheckedChanged(EventArgs e)
    {
      EventHandler checkedChangedHandler = this.CheckedChangedHandler;
      if (checkedChangedHandler == null)
        return;
      checkedChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripMenuItem.CheckStateChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnCheckStateChanged(EventArgs e)
    {
      EventHandler stateChangedHandler = this.CheckStateChangedHandler;
      if (stateChangedHandler == null)
        return;
      stateChangedHandler((object) this, e);
    }

    /// <summary>Gets the shortcut string.</summary>
    /// <returns></returns>
    private string GetShortcutString(Keys enmShortcutKeys)
    {
      if (this.mobjTypeConverter == null)
        this.mobjTypeConverter = TypeDescriptor.GetConverter(typeof (Keys));
      return this.mobjTypeConverter.ConvertToString((object) enmShortcutKeys);
    }

    /// <summary>Attacheds to DOM.</summary>
    internal void AttachedToDOM()
    {
      this.RegisterShortcut();
      foreach (ToolStripItem dropDownItem in (ArrangedElementCollection) this.DropDownItems)
      {
        if (dropDownItem is ToolStripMenuItem toolStripMenuItem)
          toolStripMenuItem.AttachedToDOM();
      }
    }

    /// <summary>Removings from DOM.</summary>
    internal void RemovingFromDOM()
    {
      this.UnregisterShortcut(false);
      foreach (ToolStripItem dropDownItem in (ArrangedElementCollection) this.DropDownItems)
      {
        if (dropDownItem is ToolStripMenuItem toolStripMenuItem)
          toolStripMenuItem.RemovingFromDOM();
      }
    }

    /// <summary>Unregisters the shortcut.</summary>
    /// <param name="blnForce">if set to <c>true</c> [BLN force].</param>
    private void UnregisterShortcut(bool blnForce)
    {
      if (!(this.menmShortcutKeys != 0 | blnForce))
        return;
      this.GetForm((Component) this.Owner)?.Shortcuts.Remove((IRegisteredComponent) this);
    }

    /// <summary>Registers the shortcut.</summary>
    private void RegisterShortcut()
    {
      Keys menmShortcutKeys = this.menmShortcutKeys;
      if (menmShortcutKeys == Keys.None)
        return;
      this.GetForm((Component) this.Owner)?.Shortcuts.Add(this.KeyToShortcut(menmShortcutKeys), (IRegisteredComponent) this);
    }

    /// <summary>Keys to shortcut.</summary>
    /// <param name="enmKeys">The enm keys.</param>
    /// <returns></returns>
    private string KeyToShortcut(Keys enmKeys)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if ((enmKeys & Keys.Control) == Keys.Control)
        stringBuilder.Append("Ctrl");
      if ((enmKeys & Keys.Shift) == Keys.Shift)
        stringBuilder.Append("Shift");
      if ((enmKeys & Keys.Alt) == Keys.Alt)
        stringBuilder.Append("Alt");
      stringBuilder.Append(this.GetShortcutString(enmKeys & Keys.KeyCode));
      return stringBuilder.ToString();
    }

    /// <summary>Gets the form.</summary>
    /// <param name="objComponent">The obj component.</param>
    /// <returns></returns>
    private Form GetForm(Component objComponent)
    {
      switch (objComponent)
      {
        case ToolStripDropDown _:
          return this.GetForm((Component) ((ToolStripDropDown) objComponent).OwnerItem);
        case ToolStrip _:
          return objComponent.Form;
        case ToolStripItem _:
          return this.GetForm((Component) ((ToolStripItem) objComponent).Owner);
        default:
          return (Form) null;
      }
    }

    /// <summary>Gets the shortcut key display string.</summary>
    /// <returns></returns>
    private string GetShortcutKeyDisplayString()
    {
      string keyDisplayString = string.Empty;
      if (this.ShowShortcutKeys)
      {
        keyDisplayString = this.ShortcutKeyDisplayString;
        if (string.IsNullOrEmpty(keyDisplayString))
        {
          Keys shortcutKeys = this.ShortcutKeys;
          if (shortcutKeys != Keys.None)
            keyDisplayString = this.GetShortcutString(shortcutKeys);
        }
      }
      return keyDisplayString;
    }

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripMenuItem.Checked"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler CheckedChanged
    {
      add => this.AddCriticalHandler(ToolStripMenuItem.CheckedChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripMenuItem.CheckedChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the CheckedChanged handler.</summary>
    /// <value>The CheckedChanged handler.</value>
    private EventHandler CheckedChangedHandler => (EventHandler) this.GetHandler(ToolStripMenuItem.CheckedChangedEvent);

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripMenuItem.CheckState"></see> property changes.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler CheckStateChanged
    {
      add => this.AddCriticalHandler(ToolStripMenuItem.CheckStateChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripMenuItem.CheckStateChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the CheckStateChanged handler.</summary>
    /// <value>The CheckStateChanged handler.</value>
    private EventHandler CheckStateChangedHandler => (EventHandler) this.GetHandler(ToolStripMenuItem.CheckStateChangedEvent);

    private bool mblnCheckOnClick
    {
      get => this.GetValue<bool>(ToolStripMenuItem.mblnCheckOnClickProperty);
      set => this.SetValue<bool>(ToolStripMenuItem.mblnCheckOnClickProperty, value);
    }

    private CheckState menmCheckState
    {
      get => this.GetValue<CheckState>(ToolStripMenuItem.menmCheckStateProperty, CheckState.Unchecked);
      set => this.SetValue<CheckState>(ToolStripMenuItem.menmCheckStateProperty, value);
    }

    private Form mobjMdiForm
    {
      get => this.GetValue<Form>(ToolStripMenuItem.mobjMdiFormProperty, (Form) null);
      set => this.SetValue<Form>(ToolStripMenuItem.mobjMdiFormProperty, value);
    }

    private string mstrShortcutKeyDisplayString
    {
      get => this.GetValue<string>(ToolStripMenuItem.mstrShortcutKeyDisplayStringProperty);
      set => this.SetValue<string>(ToolStripMenuItem.mstrShortcutKeyDisplayStringProperty, value);
    }

    private Keys menmShortcutKeys
    {
      get => this.GetValue<Keys>(ToolStripMenuItem.menmShortcutKeysProperty, Keys.None);
      set => this.SetValue<Keys>(ToolStripMenuItem.menmShortcutKeysProperty, value);
    }

    private bool mblnShowShortcutKeys
    {
      get => this.GetValue<bool>(ToolStripMenuItem.mblnShowShortcutKeysProperty);
      set => this.SetValue<bool>(ToolStripMenuItem.mblnShowShortcutKeysProperty, value);
    }

    /// <summary>
    /// Gets a value indicating whether this instance is top level.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is top level; otherwise, <c>false</c>.
    /// </value>
    internal bool IsTopLevel => !(this.ParentInternal is ToolStripDropDown);

    /// <summary>Gets the type of the tool strip item.</summary>
    /// <value>The type of the tool strip item.</value>
    protected override int ToolStripItemType => 7;

    /// <summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is checked.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is checked or is in an indeterminate state; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [DefaultValue(false)]
    [Bindable(true)]
    [RefreshProperties(RefreshProperties.All)]
    [SRDescription("CheckBoxCheckedDescr")]
    [SRCategory("CatAppearance")]
    public bool Checked
    {
      get => this.CheckState != 0;
      set
      {
        if (value == this.Checked)
          return;
        this.CheckState = value ? CheckState.Checked : CheckState.Unchecked;
      }
    }

    /// <summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> should automatically appear checked and unchecked when clicked.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> should automatically appear checked when clicked; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(false)]
    [SRCategory("CatBehavior")]
    [SRDescription("ToolStripButtonCheckOnClickDescr")]
    public bool CheckOnClick
    {
      get => this.mblnCheckOnClick;
      set
      {
        if (this.mblnCheckOnClick == value)
          return;
        this.mblnCheckOnClick = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets a value indicating whether a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is in the checked, unchecked, or indeterminate state.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.CheckState"></see> values. The default is Unchecked.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The <see cref="P:Gizmox.WebGUI.Forms.ToolStripMenuItem.CheckState"></see> property is not set to one of the <see cref="T:Gizmox.WebGUI.Forms.CheckState"></see> values. </exception>
    /// <filterpriority>1</filterpriority>
    [RefreshProperties(RefreshProperties.All)]
    [SRDescription("CheckBoxCheckStateDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(CheckState.Unchecked)]
    [Bindable(true)]
    public CheckState CheckState
    {
      get => this.menmCheckState;
      set
      {
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 2))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (CheckState));
        if (value == this.CheckState)
          return;
        this.menmCheckState = value;
        this.OnCheckedChanged(EventArgs.Empty);
        this.OnCheckStateChanged(EventArgs.Empty);
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>
    /// Gets or sets whether the item is attached to the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> or <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see> or can float between the two.
    /// </summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ToolStripItemOverflow.AsNeeded"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemOverflow"></see> values. </exception>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRCategory("CatLayout")]
    [DefaultValue(ToolStripItemOverflow.Never)]
    [SRDescription("ToolStripItemOverflowDescr")]
    public new ToolStripItemOverflow Overflow
    {
      get => ToolStripItemOverflow.Never;
      set
      {
      }
    }

    /// <summary>Gets the internal spacing within the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary>
    /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> value representing the spacing.</returns>
    protected override Padding DefaultPadding => this.IsOnDropDown ? new Padding(0, 1, 0, 1) : new Padding(4, 0, 4, 0);

    /// <summary>Gets the default size of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary>
    /// <returns>The <see cref="T:System.Drawing.Size"></see> of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>, measured in pixels. The default is 100 pixels horizontally.</returns>
    protected override Size DefaultSize => new Size(32, 19);

    /// <summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> appears on a multiple document interface (MDI) window list.</summary>
    /// <returns>true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> appears on a MDI window list; otherwise, false.</returns>
    [Browsable(false)]
    public bool IsMdiWindowListEntry => this.MdiForm != null;

    /// <summary>Gets the MDI form.</summary>
    /// <value>The MDI form.</value>
    internal Form MdiForm => this.mobjMdiForm;

    /// <summary>Gets or sets the shortcut key text.</summary>
    /// <returns>A <see cref="T:System.String"></see> representing the shortcut key.</returns>
    [SRDescription("ToolStripMenuItemShortcutKeyDisplayStringDescr")]
    [SRCategory("CatAppearance")]
    [Localizable(true)]
    [DefaultValue(null)]
    public string ShortcutKeyDisplayString
    {
      get => this.mstrShortcutKeyDisplayString;
      set
      {
        if (!(this.mstrShortcutKeyDisplayString != value))
          return;
        this.mstrShortcutKeyDisplayString = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets or sets the shortcut keys associated with the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.Keys.None"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property was not set to one of the <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values.</exception>
    [Localizable(true)]
    [DefaultValue(Keys.None)]
    [SRDescription("MenuItemShortCutDescr")]
    public Keys ShortcutKeys
    {
      get => this.menmShortcutKeys;
      set
      {
        if (value != Keys.None && !this.IsValidShortcut(value))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (Keys));
        if (this.ShortcutKeys == value)
          return;
        this.menmShortcutKeys = value;
        if (this.DesignMode)
          return;
        if (value == Keys.None)
          this.UnregisterShortcut(true);
        else
          this.RegisterShortcut();
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>Gets the forecolor from skin.</summary>
    /// <value>The color of the skin fore.</value>
    protected override Color SkinForeColor
    {
      get
      {
        Color skinForeColor = Color.Empty;
        if (SkinFactory.GetSkin((ISkinable) this) is ToolStripMenuItemSkin skin)
          skinForeColor = skin.MenuItemStyle.ForeColor;
        return skinForeColor;
      }
    }

    /// <summary>Gets or sets a value indicating whether the shortcut keys that are associated with the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> are displayed next to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>. </summary>
    /// <returns>true if the shortcut keys are shown; otherwise, false. The default is true.</returns>
    [Localizable(true)]
    [SRDescription("MenuItemShowShortCutDescr")]
    [DefaultValue(true)]
    public bool ShowShortcutKeys
    {
      get => this.mblnShowShortcutKeys;
      set
      {
        if (value == this.mblnShowShortcutKeys)
          return;
        this.mblnShowShortcutKeys = value;
        this.UpdateParams(AttributeType.Visual);
      }
    }
  }
}
