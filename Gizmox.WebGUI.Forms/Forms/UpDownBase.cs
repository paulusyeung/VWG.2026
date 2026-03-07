// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.UpDownBase
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Implements the basic functionality required by a spin box (also known as an up-down control).
  /// </summary>
  /// <filterpriority>2</filterpriority>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (UpDownBaseSkin))]
  [Serializable]
  public abstract class UpDownBase : ContainerControl
  {
    /// <summary>
    /// Provides a property reference to ChangingText Property.
    /// </summary>
    private static SerializableProperty ChangingTextProperty = SerializableProperty.Register(nameof (ChangingText), typeof (bool), typeof (UpDownBase), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to HideButtons property.
    /// </summary>
    private static SerializableProperty HideButtonsProperty = SerializableProperty.Register(nameof (HideButtons), typeof (bool), typeof (UpDownBase), new SerializablePropertyMetadata((object) false));
    /// <summary>
    /// Provides a property reference to UpDownAlign  Property.
    /// </summary>
    private static SerializableProperty InterceptArrowKeysProperty = SerializableProperty.Register(nameof (InterceptArrowKeys), typeof (bool), typeof (UpDownBase), new SerializablePropertyMetadata((object) true));
    /// <summary>
    /// Provides a property reference to HorizontalAlignment property.
    /// </summary>
    private static SerializableProperty TextAlignProperty = SerializableProperty.Register(nameof (TextAlign), typeof (HorizontalAlignment), typeof (UpDownBase), new SerializablePropertyMetadata((object) HorizontalAlignment.Left));
    /// <summary>Provides a property reference to Text property.</summary>
    private static SerializableProperty TextProperty = SerializableProperty.Register(nameof (Text), typeof (string), typeof (UpDownBase), new SerializablePropertyMetadata((object) string.Empty));
    /// <summary>
    /// Provides a property reference to UpDownAlign  Property.
    /// </summary>
    private static SerializableProperty UpDownAlignProperty = SerializableProperty.Register(nameof (UpDownAlign), typeof (LeftRightAlignment), typeof (UpDownBase), new SerializablePropertyMetadata((object) LeftRightAlignment.Right));
    /// <summary>
    /// Provides a property reference to HideButtons property.
    /// </summary>
    private static SerializableProperty UserEditProperty = SerializableProperty.Register(nameof (UserEdit), typeof (bool), typeof (UpDownBase), new SerializablePropertyMetadata((object) false));

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.UpDownBase"></see> class.
    /// </summary>
    public UpDownBase()
    {
      this.SetStyle(ControlStyles.FixedHeight | ControlStyles.Opaque | ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.StandardClick, false);
      this.SetStyle(ControlStyles.UseTextForAccessibility, false);
    }

    /// <summary>Gets a value indicating whether the container will allow the user to scroll to any controls placed outside of its visible boundaries.</summary>
    /// <returns>false in all cases.</returns>
    /// <filterpriority>1</filterpriority>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool AutoScroll
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether the control should automatically resize based on its contents.</summary>
    /// <returns>true to indicate the control should automatically resize based on its contents; otherwise, false.</returns>
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Browsable(true)]
    public override bool AutoSize
    {
      get => base.AutoSize;
      set => base.AutoSize = value;
    }

    /// <summary>Gets or sets the layout of the <see cref="P:Gizmox.WebGUI.Forms.UpDownBase.BackgroundImage"></see> of the <see cref="T:Gizmox.WebGUI.Forms.UpDownBase"></see>.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> values.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override ImageLayout BackgroundImageLayout
    {
      get => base.BackgroundImageLayout;
      set => base.BackgroundImageLayout = value;
    }

    /// <summary>Gets or sets the border style for the spin box (also known as an up-down control).</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.BorderStyle"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.BorderStyle.Fixed3D"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.BorderStyle"></see> values. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("UpDownBaseBorderStyleDescr")]
    [SRCategory("CatAppearance")]
    [DefaultValue(2)]
    [DispId(-504)]
    public override BorderStyle BorderStyle
    {
      get => base.BorderStyle;
      set => base.BorderStyle = value;
    }

    /// <summary>Gets or sets a value indicating whether the text property is being changed internally by its parent class.</summary>
    /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.UpDownBase.Text"></see> property is being changed internally by the <see cref="T:Gizmox.WebGUI.Forms.UpDownBase"></see> class; otherwise, false.</returns>
    protected bool ChangingText
    {
      get => this.GetValue<bool>(UpDownBase.ChangingTextProperty);
      set => this.SetValue<bool>(UpDownBase.ChangingTextProperty, value);
    }

    /// <summary>Gets the default size.</summary>
    /// <value>The default size.</value>
    protected override Size DefaultSize => new Size(120, this.PreferredHeight);

    /// <summary>Gets the dock padding settings for all edges of the <see cref="T:Gizmox.WebGUI.Forms.UpDownBase"></see> control.</summary>
    /// <filterpriority>1</filterpriority>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new ScrollableControl.DockPaddingEdges DockPadding => base.DockPadding;

    /// <summary>
    /// Gets or sets a value indicating whether the buttons are hidden or not.
    /// </summary>
    /// <returns>true if the buttons are hidden; otherwise, false. The default is false.</returns>
    [DefaultValue(false)]
    [SRCategory("CatAppearance")]
    public bool HideButtons
    {
      get => this.GetValue<bool>(UpDownBase.HideButtonsProperty);
      set
      {
        if (!this.SetValue<bool>(UpDownBase.HideButtonsProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets a value indicating whether the user can use the UP ARROW and DOWN ARROW keys to select values.</summary>
    /// <returns>true if the control allows the use of the UP ARROW and DOWN ARROW keys to select values; otherwise, false. The default value is true.</returns>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(true)]
    [SRDescription("UpDownBaseInterceptArrowKeysDescr")]
    [SRCategory("CatBehavior")]
    public bool InterceptArrowKeys
    {
      get => this.GetValue<bool>(UpDownBase.InterceptArrowKeysProperty);
      set
      {
        if (!this.SetValue<bool>(UpDownBase.InterceptArrowKeysProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the maximum size of the spin box (also known as an up-down control).</summary>
    /// <returns>The <see cref="T:System.Drawing.Size"></see>, which is the maximum size of the spin box.</returns>
    /// <filterpriority>1</filterpriority>
    public override Size MaximumSize
    {
      get => base.MaximumSize;
      set => base.MaximumSize = new Size(value.Width, 0);
    }

    /// <summary>Gets or sets the minimum size of the spin box (also known as an up-down control).</summary>
    /// <returns>The <see cref="T:System.Drawing.Size"></see>, which is the minimum size of the spin box.</returns>
    /// <filterpriority>1</filterpriority>
    public override Size MinimumSize
    {
      get => base.MinimumSize;
      set => base.MinimumSize = new Size(value.Width, 0);
    }

    /// <summary>Gets the height of the spin box (also known as an up-down control).</summary>
    /// <returns>The height, in pixels, of the spin box.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [SRDescription("UpDownBasePreferredHeightDescr")]
    [SRCategory("CatLayout")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int PreferredHeight
    {
      get
      {
        int int32 = Convert.ToInt32(CommonUtils.GetFontHeight(this.Font));
        if (this.BorderStyle == BorderStyle.None)
          return int32 + 3;
        int num1 = int32;
        BorderWidth borderWidth = this.BorderWidth;
        int bottom = borderWidth.Bottom;
        borderWidth = this.BorderWidth;
        int left = borderWidth.Left;
        int num2 = bottom + left;
        borderWidth = this.BorderWidth;
        int right = borderWidth.Right;
        int num3 = num2 + right;
        borderWidth = this.BorderWidth;
        int top = borderWidth.Top;
        int num4 = num3 + top + 3;
        return num1 + num4;
      }
    }

    /// <summary>Gets or sets a value indicating whether the user can edit the band's cells.</summary>
    /// <returns>true if the user cannot edit the band's cells; otherwise, false. The default is false.</returns>
    /// <exception cref="T:System.InvalidOperationException">When setting this property, this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see> instance is a shared <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(false)]
    public virtual bool ReadOnly
    {
      get => this.GetState(Component.ComponentState.ReadOnly);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.ReadOnly, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the text displayed in the spin box (also known as an up-down control).</summary>
    /// <returns>The string value displayed in the spin box.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Localizable(true)]
    public override string Text
    {
      get => this.GetValue<string>(UpDownBase.TextProperty);
      set
      {
        if (!this.SetTextInternal(value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the alignment of the text in the spin box (also known as an up-down control).</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.HorizontalAlignment.Left"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatAppearance")]
    [DefaultValue(HorizontalAlignment.Left)]
    [SRDescription("UpDownBaseTextAlignDescr")]
    [Localizable(true)]
    public HorizontalAlignment TextAlign
    {
      get => this.GetValue<HorizontalAlignment>(UpDownBase.TextAlignProperty);
      set
      {
        if (!this.SetValue<HorizontalAlignment>(UpDownBase.TextAlignProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the text internal.</summary>
    /// <param name="strValue">The value.</param>
    /// <returns></returns>
    protected bool SetTextInternal(string strValue)
    {
      if (!this.SetValue<string>(UpDownBase.TextProperty, strValue))
        return false;
      this.OnTextBoxTextChanged((object) this, EventArgs.Empty);
      this.ChangingText = false;
      if (this.UserEdit)
        this.ValidateEditText();
      return true;
    }

    /// <summary>Gets or sets the alignment of the up and down buttons on the spin box (also known as an up-down control).</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.LeftRightAlignment"></see> values. The default value is <see cref="F:Gizmox.WebGUI.Forms.LeftRightAlignment.Right"></see>.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.LeftRightAlignment"></see> values. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("UpDownBaseAlignmentDescr")]
    [Localizable(true)]
    [DefaultValue(1)]
    [SRCategory("CatAppearance")]
    public LeftRightAlignment UpDownAlign
    {
      get => this.GetValue<LeftRightAlignment>(UpDownBase.UpDownAlignProperty);
      set
      {
        if (!this.SetValue<LeftRightAlignment>(UpDownBase.UpDownAlignProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets a value indicating whether a value has been entered by the user.</summary>
    /// <returns>true if the user has changed the <see cref="P:Gizmox.WebGUI.Forms.UpDownBase.Text"></see> property; otherwise, false.</returns>
    protected bool UserEdit
    {
      get => this.GetValue<bool>(UpDownBase.UserEditProperty);
      set => this.SetValue<bool>(UpDownBase.UserEditProperty, value);
    }

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
    /// </summary>
    /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
    protected override bool Focusable => true;

    /// <summary>
    /// Gets a value indicating whether [supports focus events].
    /// </summary>
    /// <value><c>true</c> if [supports focus events]; otherwise, <c>false</c>.</value>
    protected internal override bool SupportsFocusEvents => true;

    /// <summary>
    /// Gets a value indicating whether raise click event on mouse down.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if should raise click event on mouse down; otherwise, <c>false</c>.
    /// </value>
    protected override bool ShouldRaiseClickOnRightMouseDown => false;

    /// <summary>Gets the resizable allowed directions.</summary>
    protected override string[] ResizableAllowedDirections => new string[2]
    {
      "e",
      "w"
    };

    /// <summary>
    /// When overridden in a derived class,
    /// handles the clicking of the down button on the spin box
    /// (also known as an up-down control).</summary>
    /// <filterpriority>1</filterpriority>
    public abstract void DownButton();

    /// <summary>
    /// Selects a range of text in the spin box
    /// (also known as an up-down control) specifying
    /// the starting position and number of characters
    /// to select.
    /// </summary>
    /// <param name="intStart">The position of the first character to be selected. </param>
    /// <param name="intLength">The total number of characters to be selected. </param>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void Select(int intStart, int intLength) => this.InvokeMethodWithId("UpDownBase_SetSelection", (object) intStart, (object) intLength);

    /// <summary>When overridden in a derived class, handles the clicking of the up button on the spin box (also known as an up-down control).</summary>
    /// <filterpriority>1</filterpriority>
    public abstract void UpButton();

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      if (objEvent.Type == "ValueChange")
      {
        string strValue = CommonUtils.DecodeText(objEvent["VLB"]);
        bool blnIsIndex = objEvent["IX"] == "1";
        if (string.IsNullOrEmpty(strValue))
          return;
        this.SetUpDownValue(strValue, blnIsIndex);
      }
      else
        base.FireEvent(objEvent);
    }

    /// <summary>Gets the key event captures.</summary>
    /// <returns></returns>
    protected override KeyCaptures GetKeyEventCaptures() => base.GetKeyEventCaptures() | KeyCaptures.UpKeyCapture | KeyCaptures.DownKeyCapture | KeyCaptures.EndKeyCapture | KeyCaptures.HomeKeyCapture | KeyCaptures.PageDownKeyCapture | KeyCaptures.PageUpKeyCapture;

    /// <summary>When overridden in a derived class, raises the Changed event.</summary>
    /// <param name="objSource">The source of the event.</param>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected virtual void OnChanged(object objSource, EventArgs e)
    {
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.FontChanged"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected override void OnFontChanged(EventArgs e)
    {
      this.Height = this.PreferredHeight;
      base.OnFontChanged(e);
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.HandleCreated"></see> event.</summary>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
    protected override void OnHandleCreated(EventArgs e) => base.OnHandleCreated(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyDown"></see> event.</summary>
    /// <param name="objSource">The source of the event. </param>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
    protected virtual void OnTextBoxKeyDown(object objSource, KeyEventArgs e)
    {
      if (this.InterceptArrowKeys)
      {
        if (e.KeyData == Keys.Up)
          this.UpButton();
        else if (e.KeyData == Keys.Down)
          this.DownButton();
      }
      if (e.KeyCode != Keys.Enter || !this.UserEdit)
        return;
      this.ValidateEditText();
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyPress"></see> event.</summary>
    /// <param name="objSource">The source of the event. </param>
    /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs"></see> that contains the event data. </param>
    protected virtual void OnTextBoxKeyPress(object objSource, KeyPressEventArgs e) => this.OnKeyPress(e);

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.LostFocus"></see> event.</summary>
    /// <param name="objSource">The source of the event. </param>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnTextBoxLostFocus(object objSource, EventArgs e)
    {
      if (!this.UserEdit)
        return;
      this.ValidateEditText();
    }

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Resize"></see> event.</summary>
    /// <param name="objSource">The source of the event. </param>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnTextBoxResize(object objSource, EventArgs e) => this.Height = this.PreferredHeight;

    /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.TextChanged"></see> event.</summary>
    /// <param name="objSource">The source of the event. </param>
    /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
    protected virtual void OnTextBoxTextChanged(object objSource, EventArgs e)
    {
      if (this.ChangingText)
        this.ChangingText = false;
      else
        this.UserEdit = true;
      this.OnTextChanged(e);
      this.OnChanged(objSource, new EventArgs());
    }

    /// <summary>Renders the scrollable attribute</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      if (this.HideButtons)
        objWriter.WriteAttributeString("HB", "1");
      if (this.ReadOnly)
        objWriter.WriteAttributeString("RO", "1");
      if (!this.InterceptArrowKeys)
        objWriter.WriteAttributeString("IAK", "0");
      if (this.TextAlign != HorizontalAlignment.Center)
        objWriter.WriteAttributeString("TA", this.TextAlign.ToString());
      LeftRightAlignment upDownAlign = this.UpDownAlign;
      if ((upDownAlign != LeftRightAlignment.Left || this.Context.RightToLeft) && (upDownAlign != LeftRightAlignment.Right || !this.Context.RightToLeft))
        return;
      objWriter.WriteAttributeString("UDA", LeftRightAlignment.Left.ToString());
    }

    /// <summary>Sets up down value.</summary>
    /// <param name="strValue">The STR value.</param>
    /// <param name="blnIsIndex">if set to <c>true</c> [BLN is index].</param>
    protected virtual void SetUpDownValue(string strValue, bool blnIsIndex)
    {
    }

    /// <summary>When overridden in a derived class, updates the text displayed in the spin box (also known as an up-down control).</summary>
    protected abstract void UpdateEditText();

    /// <summary>When overridden in a derived class, validates the text displayed in the spin box (also known as an up-down control).</summary>
    protected virtual void ValidateEditText()
    {
    }

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new UpDownBaseRenderer(this);

    /// <summary>Called when [up down].</summary>
    /// <param name="objSource">The source.</param>
    /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.UpDownEventArgs" /> instance containing the event data.</param>
    private void OnUpDown(object objSource, UpDownEventArgs e)
    {
      if (e.ButtonID == 1)
      {
        this.UpButton();
      }
      else
      {
        if (e.ButtonID != 2)
          return;
        this.DownButton();
      }
    }

    internal override Rectangle ApplyBoundsConstraints(
      int intSuggestedX,
      int intSuggestedY,
      int intProposedWidth,
      int intProposedHeight)
    {
      return base.ApplyBoundsConstraints(intSuggestedX, intSuggestedY, intProposedWidth, this.PreferredHeight);
    }

    /// <summary>
    /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseUp"></see> event.
    /// </summary>
    internal virtual void OnStartTimer()
    {
    }

    /// <summary>Called when [stop timer].</summary>
    internal virtual void OnStopTimer()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    internal enum ButtonID
    {
      /// <summary>
      /// 
      /// </summary>
      None,
      /// <summary>
      /// 
      /// </summary>
      Up,
      /// <summary>
      /// 
      /// </summary>
      Down,
    }
  }
}
