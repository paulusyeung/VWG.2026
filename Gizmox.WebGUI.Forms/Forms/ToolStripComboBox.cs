// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ToolStripComboBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Resources;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Represents a <see cref="T:System.Windows.Forms.ToolStripComboBox"></see> that is properly rendered in a <see cref="T:System.Windows.Forms.ToolStrip"></see>.</summary>
  [DefaultProperty("Items")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripComboBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ContextMenuStrip | ToolStripItemDesignerAvailability.MenuStrip | ToolStripItemDesignerAvailability.ToolStrip)]
  [Serializable]
  public class ToolStripComboBox : ToolStripControlHost
  {
    private static readonly SerializableEvent SelectedIndexChangedEvent = SerializableEvent.Register("SelectedIndexChanged", typeof (EventHandler), typeof (ToolStripComboBox));
    /// <summary>The drop down event</summary>
    private static readonly SerializableEvent DropDownEvent = SerializableEvent.Register("DropDown", typeof (EventHandler), typeof (ToolStripComboBox));
    /// <summary>The drop down closed event</summary>
    private static readonly SerializableEvent DropDownClosedEvent = SerializableEvent.Register("DropDownClosed", typeof (EventHandler), typeof (ToolStripComboBox));

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> class.</summary>
    public ToolStripComboBox()
      : base((Control) new ToolStripComboBox.ToolStripComboBoxControl())
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> class with the specified name. </summary>
    /// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</param>
    public ToolStripComboBox(string name)
      : this()
    {
      this.Name = name;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> class derived from a base control.</summary>
    /// <param name="c">The base control. </param>
    /// <exception cref="T:System.NotSupportedException">The operation is not supported. </exception>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ToolStripComboBox(Control objControl)
      : base(objControl)
    {
    }

    /// <summary>Full updates of this instance.</summary>
    public override void Update()
    {
      base.Update();
      this.ComboBox.Update();
    }

    /// <summary>Handles the selected index changed.</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void HandleSelectedIndexChanged(object sender, EventArgs e) => this.OnSelectedIndexChanged(e);

    /// <summary>Maintains performance when items are added to the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> one at a time.</summary>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void BeginUpdate()
    {
    }

    /// <summary>Resumes painting the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> control after painting is suspended by the <see cref="M:Gizmox.WebGUI.Forms.ToolStripComboBox.BeginUpdate"></see> method.</summary>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public void EndUpdate()
    {
    }

    /// <summary>Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> that starts with the specified string.</summary>
    /// <returns>The zero-based index of the first item found; returns -1 if no match is found.</returns>
    /// <param name="s">The <see cref="T:System.String"></see> to search for.</param>
    /// <filterpriority>1</filterpriority>
    public int FindString(string s) => this.ComboBox.FindString(s);

    /// <summary>Finds the first item after the given index which starts with the given string. </summary>
    /// <returns>The zero-based index of the first item found; returns -1 if no match is found.</returns>
    /// <param name="s">The <see cref="T:System.String"></see> to search for.</param>
    /// <param name="startIndex">The zero-based index of the item before the first item to be searched. Set to -1 to search from the beginning of the control.</param>
    /// <filterpriority>1</filterpriority>
    public int FindString(string s, int startIndex) => this.ComboBox.FindString(s, startIndex);

    /// <summary>Finds the first item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> that exactly matches the specified string.</summary>
    /// <returns>The zero-based index of the first item found; -1 if no match is found.</returns>
    /// <param name="s">The <see cref="T:System.String"></see> to search for.</param>
    /// <filterpriority>1</filterpriority>
    public int FindStringExact(string s) => this.ComboBox.FindStringExact(s);

    /// <summary>Finds the first item after the specified index that exactly matches the specified string.</summary>
    /// <returns>The zero-based index of the first item found; returns -1 if no match is found.</returns>
    /// <param name="s">The <see cref="T:System.String"></see> to search for.</param>
    /// <param name="startIndex">The zero-based index of the item before the first item to be searched. Set to -1 to search from the beginning of the control.</param>
    /// <filterpriority>1</filterpriority>
    public int FindStringExact(string s, int startIndex) => this.ComboBox.FindStringExact(s, startIndex);

    /// <summary>Returns the height, in pixels, of an item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary>
    /// <returns>The height, in pixels, of the item at the specified index.</returns>
    /// <param name="index">The index of the item to return the height of.</param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int GetItemHeight(int index) => 0;

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripComboBox.DropDown"></see> event. </summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnDropDown(EventArgs objEventArgs)
    {
      EventHandler dropDownHandler = this.DropDownHandler;
      if (dropDownHandler == null)
        return;
      dropDownHandler((object) this, objEventArgs);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripComboBox.DropDownClosed"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnDropDownClosed(EventArgs objEventArgs)
    {
      EventHandler downClosedHandler = this.DropDownClosedHandler;
      if (downClosedHandler == null)
        return;
      downClosedHandler((object) this, objEventArgs);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripComboBox.DropDownStyleChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnDropDownStyleChanged(EventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripComboBox.SelectedIndexChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnSelectedIndexChanged(EventArgs e)
    {
      EventHandler indexChangedHandler = this.SelectedIndexChangedHandler;
      if (indexChangedHandler == null)
        return;
      indexChangedHandler((object) this, e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ComboBox.SelectionChangeCommitted"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnSelectionChangeCommitted(EventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripComboBox.TextUpdate"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    protected virtual void OnTextUpdate(EventArgs e)
    {
    }

    /// <summary>Selects a range of text in the editable portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary>
    /// <param name="start">The position of the first character in the current text selection within the text box.</param>
    /// <param name="length">The number of characters to select.</param>
    /// <exception cref="T:System.ArgumentException">The start is less than zero.-or- start minus length is less than zero. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    public void Select(int start, int length) => this.ComboBox.Select(start, length);

    /// <summary>Selects all the text in the editable portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    public void SelectAll() => this.ComboBox.SelectAll();

    /// <summary>Handles the drop down.</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void HandleDropDown(object sender, EventArgs e) => this.OnDropDown(e);

    /// <summary>Handles the drop down closed.</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    private void HandleDropDownClosed(object sender, EventArgs e) => this.OnDropDownClosed(e);

    /// <summary>Subscribes events from the hosted control.</summary>
    /// <param name="objControl">The control from which to subscribe events.</param>
    protected override void OnSubscribeControlEvents(Control objControl)
    {
      if (objControl is ComboBox comboBox)
      {
        comboBox.DropDown += new EventHandler(this.HandleDropDown);
        comboBox.DropDownClosed += new EventHandler(this.HandleDropDownClosed);
      }
      base.OnSubscribeControlEvents(objControl);
    }

    /// <summary>Unsubscribes events from the hosted control.</summary>
    /// <param name="objControl">The control from which to unsubscribe events.</param>
    protected override void OnUnsubscribeControlEvents(Control objControl)
    {
      if (objControl is ComboBox comboBox)
      {
        comboBox.DropDown -= new EventHandler(this.HandleDropDown);
        comboBox.DropDownClosed -= new EventHandler(this.HandleDropDownClosed);
      }
      base.OnUnsubscribeControlEvents(objControl);
    }

    /// <summary>This event is not relevant to this class.</summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new event EventHandler DoubleClick
    {
      add => base.DoubleClick += value;
      remove => base.DoubleClick -= value;
    }

    /// <summary>Occurs when the drop-down portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> is shown.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler DropDown
    {
      add => this.AddCriticalHandler(ToolStripComboBox.DropDownEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripComboBox.DropDownEvent, (Delegate) value);
    }

    /// <summary>Gets the drop down handler.</summary>
    /// <value>The drop down handler.</value>
    private EventHandler DropDownHandler => (EventHandler) this.GetHandler(ToolStripComboBox.DropDownEvent);

    /// <summary>Occurs when the drop-down portion of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> has closed.</summary>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler DropDownClosed
    {
      add => this.AddCriticalHandler(ToolStripComboBox.DropDownClosedEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(ToolStripComboBox.DropDownClosedEvent, (Delegate) value);
    }

    /// <summary>Gets the drop down closed handler.</summary>
    /// <value>The drop down closed handler.</value>
    private EventHandler DropDownClosedHandler => (EventHandler) this.GetHandler(ToolStripComboBox.DropDownClosedEvent);

    /// <summary>Occurs when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripComboBox.DropDownStyle"></see> property has changed.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler DropDownStyleChanged
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripComboBox.SelectedIndex"></see> property has changed.</summary>
    /// <filterpriority>1</filterpriority>
    public event EventHandler SelectedIndexChanged
    {
      add
      {
        if (!this.HasHandler(ToolStripComboBox.SelectedIndexChangedEvent) && this.Control is ComboBox control)
          control.SelectedIndexChanged += new EventHandler(this.HandleSelectedIndexChanged);
        this.AddCriticalHandler(ToolStripComboBox.SelectedIndexChangedEvent, (Delegate) value);
      }
      remove
      {
        this.RemoveCriticalHandler(ToolStripComboBox.SelectedIndexChangedEvent, (Delegate) value);
        if (this.HasHandler(ToolStripComboBox.SelectedIndexChangedEvent) || !(this.Control is ComboBox control))
          return;
        control.SelectedIndexChanged -= new EventHandler(this.HandleSelectedIndexChanged);
      }
    }

    /// <summary>Gets the SelectedIndexChanged handler.</summary>
    /// <value>The SelectedIndexChanged handler.</value>
    private EventHandler SelectedIndexChangedHandler => (EventHandler) this.GetHandler(ToolStripComboBox.SelectedIndexChangedEvent);

    /// <summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> text has changed.</summary>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public event EventHandler TextUpdate
    {
      add
      {
      }
      remove
      {
      }
    }

    /// <summary>Gets or sets the custom string collection to use when the <see cref="P:Gizmox.WebGUI.Forms.ToolStripComboBox.AutoCompleteSource"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.AutoCompleteSource.CustomSource"></see>.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.AutoCompleteStringCollection"></see> that contains the strings.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public AutoCompleteStringCollection AutoCompleteCustomSource
    {
      get => (AutoCompleteStringCollection) null;
      set
      {
      }
    }

    /// <summary>Gets or sets a value that indicates the text completion behavior of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.AutoCompleteMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.AutoCompleteMode.None"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(AutoCompleteMode.None)]
    [SRDescription("ComboBoxAutoCompleteModeDescr")]
    public AutoCompleteMode AutoCompleteMode
    {
      get => this.ComboBox.AutoCompleteMode;
      set => this.ComboBox.AutoCompleteMode = value;
    }

    /// <summary>Gets or sets the source of complete strings used for automatic completion.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.AutoCompleteSource"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.AutoCompleteSource.None"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [SRDescription("ComboBoxAutoCompleteSourceDescr")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Browsable(true)]
    [DefaultValue(AutoCompleteSource.None)]
    public AutoCompleteSource AutoCompleteSource
    {
      get => this.ComboBox.AutoCompleteSource;
      set => this.ComboBox.AutoCompleteSource = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>An <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override ResourceHandle BackgroundImage
    {
      get => base.BackgroundImage;
      set => base.BackgroundImage = value;
    }

    /// <summary>This property is not relevant to this class.</summary>
    /// <returns>An <see cref="T:System.Windows.Forms.ImageLayout"></see>.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override ImageLayout BackgroundImageLayout
    {
      get => base.BackgroundImageLayout;
      set => base.BackgroundImageLayout = value;
    }

    /// <summary>Gets a <see cref="T:System.Windows.Forms.ComboBox"></see> in which the user can enter text, along with a list from which the user can select.</summary>
    /// <returns>A <see cref="T:System.Windows.Forms.ComboBox"></see> for a <see cref="T:System.Windows.Forms.ToolStrip"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public ComboBox ComboBox => this.Control as ComboBox;

    /// <summary>Gets the default size of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary>
    /// <returns>The default <see cref="T:System.Drawing.Size"></see> of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripTextBox"></see> in pixels. The default size is 100 x 20 pixels.</returns>
    protected new virtual Size DefaultSize => new Size(100, 22);

    /// <summary>Gets or sets the height, in pixels, of the drop-down portion box of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary>
    /// <returns>The height, in pixels, of the drop-down box.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int DropDownHeight
    {
      get => 0;
      set
      {
      }
    }

    /// <summary>Gets or sets a value specifying the style of the <see cref="T:System.Windows.Forms.ToolStripComboBox"></see>.</summary>
    /// <returns>One of the <see cref="T:System.Windows.Forms.ComboBoxStyle"></see> values. The default is <see cref="F:System.Windows.Forms.ComboBoxStyle.DropDown"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("ComboBoxStyleDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(ComboBoxStyle.DropDown)]
    [RefreshProperties(RefreshProperties.Repaint)]
    public ComboBoxStyle DropDownStyle
    {
      get => this.ComboBox.DropDownStyle;
      set => this.ComboBox.DropDownStyle = value;
    }

    /// <summary>Gets or sets the width, in pixels, of the of the drop-down portion of a <see cref="T:System.Windows.Forms.ToolStripComboBox"></see>.</summary>
    /// <returns>The width, in pixels, of the drop-down box.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("ComboBoxDropDownWidthDescr")]
    [SRCategory("CatBehavior")]
    public int DropDownWidth
    {
      get => this.ComboBox.DropDownWidth;
      set => this.ComboBox.DropDownWidth = value;
    }

    /// <summary>Resets the width of the drop down.</summary>
    private void ResetDropDownWidth() => this.ComboBox.ResetDropDownWidth();

    /// <summary>
    /// Gets or sets a value indicating whether [dropped down].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [dropped down]; otherwise, <c>false</c>.
    /// </value>
    public bool DroppedDown
    {
      get => this.ComboBox.DroppedDown;
      set => this.ComboBox.DroppedDown = value;
    }

    /// <summary>Gets or sets the appearance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary>
    /// <returns>One of the values of <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see>. The options are <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Flat"></see>, <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Popup"></see>, <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Standard"></see>, and <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.System"></see>. The default is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Popup"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public FlatStyle FlatStyle
    {
      get => FlatStyle.Flat;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> should resize to avoid showing partial items.</summary>
    /// <returns>true if the list portion can contain only complete items; otherwise, false. The default is true.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IntegralHeight
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets a collection of the items contained in this <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary>
    /// <returns>A collection of items.</returns>
    /// <filterpriority>1</filterpriority>
    [Editor("Gizmox.WebGUI.Forms.Design.ListControlStringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof (UITypeEditor))]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [Localizable(true)]
    [SRDescription("ComboBoxItemsDescr")]
    [SRCategory("CatData")]
    public ComboBox.ObjectCollection Items => this.ComboBox.Items;

    /// <summary>Gets or sets the max drop down items.</summary>
    /// <value>The max drop down items.</value>
    [DefaultValue(8)]
    [SRCategory("CatBehavior")]
    [Localizable(true)]
    [SRDescription("ComboBoxMaxDropDownItemsDescr")]
    public int MaxDropDownItems
    {
      get => this.ComboBox.MaxDropDownItems;
      set => this.ComboBox.MaxDropDownItems = value;
    }

    /// <summary>Gets or sets the maximum number of characters allowed in the editable portion of a combo box.</summary>
    /// <returns>The maximum number of characters the user can enter. Values of less than zero are reset to zero, which is the default value.</returns>
    /// <filterpriority>1</filterpriority>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int MaxLength
    {
      get => 0;
      set
      {
      }
    }

    /// <summary>Gets or sets the index specifying the currently selected item.</summary>
    /// <returns>A zero-based index of the currently selected item. A value of negative one (-1) is returned if no item is selected.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ComboBoxSelectedIndexDescr")]
    public int SelectedIndex
    {
      get => this.ComboBox.SelectedIndex;
      set => this.ComboBox.SelectedIndex = value;
    }

    /// <summary>Gets or sets currently selected item in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary>
    /// <returns>The object that is the currently selected item or null if there is no currently selected item.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [Browsable(false)]
    [Bindable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ComboBoxSelectedItemDescr")]
    public object SelectedItem
    {
      get => this.ComboBox.SelectedItem;
      set => this.ComboBox.SelectedItem = value;
    }

    /// <summary>Gets or sets the text that is selected in the editable portion of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see>.</summary>
    /// <returns>A string that represents the currently selected text in the combo box. If <see cref="P:Gizmox.WebGUI.Forms.ToolStripComboBox.DropDownStyle"></see> is set to DropDownList, the return value is an empty string ("").</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [SRDescription("ComboBoxSelectedTextDescr")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public string SelectedText
    {
      get => this.ComboBox.SelectedText;
      set => this.ComboBox.SelectedText = value;
    }

    /// <summary>Gets or sets the number of characters selected in the editable portion of the <see cref="T:System.Windows.Forms.ToolStripComboBox"></see>.</summary>
    /// <returns>The number of characters selected in the <see cref="T:System.Windows.Forms.ToolStripComboBox"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [SRDescription("ComboBoxSelectionLengthDescr")]
    public int SelectionLength
    {
      get => this.ComboBox.SelectionLength;
      set => this.ComboBox.SelectionLength = value;
    }

    /// <summary>Gets or sets the starting index of text selected in the <see cref="T:System.Windows.Forms.ToolStripComboBox"></see>.</summary>
    /// <returns>The zero-based index of the first character in the string of the current text selection.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("ComboBoxSelectionStartDescr")]
    public int SelectionStart
    {
      get => this.ComboBox.SelectionStart;
      set => this.ComboBox.SelectionStart = value;
    }

    /// <summary>Gets or sets a value indicating whether the items in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripComboBox"></see> are sorted.</summary>
    /// <returns>true if the combo box is sorted; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet>
    ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
    ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
    /// </PermissionSet>
    [DefaultValue(false)]
    [SRCategory("CatBehavior")]
    [SRDescription("ComboBoxSortedDescr")]
    public bool Sorted
    {
      get => this.ComboBox.Sorted;
      set => this.ComboBox.Sorted = value;
    }

    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    [Serializable]
    private class ToolStripComboBoxControl : ComboBox
    {
      /// <summary>Gets the default size.</summary>
      /// <value>The default size.</value>
      protected override Size DefaultSize => new Size(100, 22);
    }
  }
}
