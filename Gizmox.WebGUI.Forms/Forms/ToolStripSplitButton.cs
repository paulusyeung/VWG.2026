// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripSplitButton
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a combination of a standard button on the left and a drop-down button on the right, or the other way around if the value of <see cref="T:System.Windows.Forms.RightToLeft"></see> is Yes.</summary>
  [DefaultEvent("ButtonClick")]
  [Skin(typeof (ToolStripSplitButtonSkin))]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripSplitButtonController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip | ToolStripItemDesignerAvailability.ToolStrip)]
  [Serializable]
  public class ToolStripSplitButton : ToolStripDropDownItem
  {
    private static readonly SerializableEvent ButtonClickEvent = SerializableEvent.Register("ButtonClick", typeof (EventHandler), typeof (ToolStripSplitButton));
    private static readonly SerializableEvent ButtonDoubleClickEvent = SerializableEvent.Register("ButtonDoubleClick", typeof (EventHandler), typeof (ToolStripSplitButton));
    private static readonly SerializableEvent DefaultItemChangedEvent = SerializableEvent.Register("DefaultItemChanged", typeof (EventHandler), typeof (ToolStripSplitButton));

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class.</summary>
    public ToolStripSplitButton()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified text. </summary>
    /// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
    public ToolStripSplitButton(string text)
      : base(text, (ResourceHandle) null, (EventHandler) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified image. </summary>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
    public ToolStripSplitButton(ResourceHandle image)
      : base((string) null, image, (EventHandler) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified text and image.</summary>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
    /// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
    public ToolStripSplitButton(string text, ResourceHandle image)
      : base(text, image, (EventHandler) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified display text, image, and <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event handler.</summary>
    /// <param name="onClick">Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event when the user clicks the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
    /// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
    public ToolStripSplitButton(string text, ResourceHandle image, EventHandler onClick)
      : base(text, image, onClick)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified display text, image, <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event handler, and name.</summary>
    /// <param name="onClick">Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event when the user clicks the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
    /// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
    /// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
    public ToolStripSplitButton(
      string text,
      ResourceHandle image,
      EventHandler onClick,
      string name)
      : base(text, image, onClick, (string) null)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> class with the specified text, image, and <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> array.</summary>
    /// <param name="dropDownItems">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> array of controls.</param>
    /// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
    /// <param name="text">The text to be displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</param>
    public ToolStripSplitButton(string text, ResourceHandle image, ToolStripItem[] dropDownItems)
      : base(text, image, dropDownItems)
    {
    }

    /// <summary>Gets the size of the preferred.</summary>
    /// <param name="objConstrainingSize">Size of the obj constraining.</param>
    /// <returns></returns>
    public override Size GetPreferredSize(Size objConstrainingSize)
    {
      Size preferredeSizeByText = this.GetPreferredeSizeByText();
      if (SkinFactory.GetSkin((ISkinable) this) is ToolStripSplitButtonSkin skin)
      {
        ref Size local = ref preferredeSizeByText;
        int num1 = local.Width + skin.DropDownImageWidth;
        BorderWidth width = skin.DropDownImageContainerStyle.Border.Width;
        int left = width.Left;
        int num2 = num1 + left;
        width = skin.DropDownImageContainerStyle.Border.Width;
        int right = width.Right;
        local.Width = num2 + right;
      }
      Size preferredSizeByImage = this.GetPreferredSizeByImage(preferredeSizeByText);
      return this.GetPreferredSizeByButtonSkin((ButtonSkin) skin, preferredSizeByImage);
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.DropDownItems.Count > 0)
        criticalEventsData.Set("EXP");
      return criticalEventsData;
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripSplitButton.ButtonClick"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnButtonClick(EventArgs e)
    {
      EventHandler buttonClickHandler = this.ButtonClickHandler;
      if (buttonClickHandler == null)
        return;
      buttonClickHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripSplitButton.ButtonDoubleClick"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    public virtual void OnButtonDoubleClick(EventArgs e)
    {
      EventHandler doubleClickHandler = this.ButtonDoubleClickHandler;
      if (doubleClickHandler == null)
        return;
      doubleClickHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripSplitButton.DefaultItemChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnDefaultItemChanged(EventArgs e)
    {
      EventHandler itemChangedHandler = this.DefaultItemChangedHandler;
      if (itemChangedHandler == null)
        return;
      itemChangedHandler((object) this, e);
    }

    /// <summary>If the <see cref="P:Gizmox.WebGUI.Forms.ToolStripItem.Enabled"></see> property is true, calls the <see cref="M:Gizmox.WebGUI.Forms.ToolStripSplitButton.OnButtonClick(System.EventArgs)"></see> method.</summary>
    public void PerformButtonClick()
    {
      if (!this.Enabled || !this.Available)
        return;
      this.PerformClick();
      this.OnButtonClick(EventArgs.Empty);
    }

    /// <summary>This method is not relevant to this class.</summary>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [EditorBrowsable(EditorBrowsableState.Always)]
    public virtual void ResetDropDownButtonWidth()
    {
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      if (objEvent.Type == "DropDown" && this.GetMouseEventArgs(objEvent).Button == MouseButtons.Left)
        this.ShowDropDown();
      base.FireEvent(objEvent);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.DoubleClick"></see> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnDoubleClick(EventArgs e)
    {
      base.OnDoubleClick(e);
      this.OnButtonDoubleClick(new EventArgs());
    }

    /// <summary>Occurs when the standard button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is clicked.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler ButtonClick
    {
      add => this.AddCriticalHandler(ToolStripSplitButton.ButtonClickEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripSplitButton.ButtonClickEvent, (Delegate) value);
    }

    /// <summary>Gets the ButtonClick handler.</summary>
    /// <value>The ButtonClick handler.</value>
    private EventHandler ButtonClickHandler => (EventHandler) this.GetHandler(ToolStripSplitButton.ButtonClickEvent);

    /// <summary>Occurs when the standard button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is double-clicked.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler ButtonDoubleClick
    {
      add => this.AddCriticalHandler(ToolStripSplitButton.ButtonDoubleClickEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripSplitButton.ButtonDoubleClickEvent, (Delegate) value);
    }

    /// <summary>Gets the ButtonDoubleClick handler.</summary>
    /// <value>The ButtonDoubleClick handler.</value>
    private EventHandler ButtonDoubleClickHandler => (EventHandler) this.GetHandler(ToolStripSplitButton.ButtonDoubleClickEvent);

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripSplitButton.DefaultItem"></see> has changed.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler DefaultItemChanged
    {
      add => this.AddCriticalHandler(ToolStripSplitButton.DefaultItemChangedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripSplitButton.DefaultItemChangedEvent, (Delegate) value);
    }

    /// <summary>Gets the DefaultItemChanged handler.</summary>
    /// <value>The DefaultItemChanged handler.</value>
    private EventHandler DefaultItemChangedHandler => (EventHandler) this.GetHandler(ToolStripSplitButton.DefaultItemChangedEvent);

    /// <summary>Gets or sets a value indicating whether default or custom <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> text is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary>
    /// <returns>true if default <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> text is displayed; otherwise, false. The default is true.</returns>
    [DefaultValue(true)]
    public new bool AutoToolTip
    {
      get => base.AutoToolTip;
      set => base.AutoToolTip = value;
    }

    /// <summary>Gets the size and location of the standard button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> that represents the size and location of the standard button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Rectangle ButtonBounds => Rectangle.Empty;

    /// <summary>Gets a value indicating whether the button portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is in the pressed state. </summary>
    /// <returns>true if the button portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is in the pressed state; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ButtonPressed => false;

    /// <summary>Gets the type of the tool strip item.</summary>
    /// <value>The type of the tool strip item.</value>
    protected override int ToolStripItemType => 2;

    /// <summary>Gets a value indicating whether the standard button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is selected or the <see cref="P:Gizmox.WebGUI.Forms.ToolStripSplitButton.DropDownButtonPressed"></see> property is true.</summary>
    /// <returns>true if the button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is selected or whether <see cref="P:Gizmox.WebGUI.Forms.ToolStripSplitButton.DropDownButtonPressed"></see> is true; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public bool ButtonSelected => false;

    /// <summary>Gets a value indicating whether to display the <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> that is defined as the default. </summary>
    /// <returns>true in all cases.</returns>
    protected override bool DefaultAutoToolTip => true;

    /// <summary>Gets or sets the portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> that is activated when the control is first selected.</summary>
    /// <returns>A Forms.ToolStripItem representing the portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> that is activated when first selected. The default value is null.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ToolStripItem DefaultItem
    {
      get => (ToolStripItem) null;
      set
      {
      }
    }

    /// <summary>Gets the size and location, in screen coordinates, of the drop-down button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> that represents the size and location of the drop-down button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>, in screen coordinates.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Rectangle DropDownButtonBounds => Rectangle.Empty;

    /// <summary>Gets a value indicating whether the drop-down portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is in the pressed state. </summary>
    /// <returns>true if the drop-down portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is in the pressed state; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public bool DropDownButtonPressed => this.DropDown.Visible;

    /// <summary>Gets a value indicating whether the drop-down button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is selected.</summary>
    /// <returns>true if the drop-down button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see> is selected; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public bool DropDownButtonSelected => false;

    /// <summary>The width, in pixels, of the drop-down button portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary>
    /// <returns>An <see cref="T:System.Int32"></see> representing the width in pixels.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value is less than zero (0). </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int DropDownButtonWidth
    {
      get => -1;
      set
      {
      }
    }

    /// <summary>Gets the boundaries of the separator between the standard and drop-down button portions of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripSplitButton"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Rectangle"></see> that represents the size and location of the separator.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public Rectangle SplitterBounds => Rectangle.Empty;
  }
}
