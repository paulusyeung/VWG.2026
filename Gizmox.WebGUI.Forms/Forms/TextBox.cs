// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TextBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Implementation of TextBox class.</summary>
  [ToolboxBitmap(typeof (TextBox), "TextBox_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.TextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.TextBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [ToolboxItem(true)]
  [ToolboxItemCategory("Common Controls")]
  [Gizmox.WebGUI.Forms.MetadataTag("T")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (TextBoxSkin))]
  [Serializable]
  public class TextBox : TextBoxBase
  {
    /// <summary>
    /// Provides a property reference to CharacterCasing property.
    /// </summary>
    private static SerializableProperty CharacterCasingProperty = SerializableProperty.Register(nameof (CharacterCasing), typeof (CharacterCasing), typeof (TextBox));
    /// <summary>Provides a property reference to Validator property.</summary>
    private static SerializableProperty ValidatorProperty = SerializableProperty.Register(nameof (Validator), typeof (TextBoxValidation), typeof (TextBox));
    /// <summary>
    /// Provides a property reference to PasswordChar property.
    /// </summary>
    private static SerializableProperty PasswordCharProperty = SerializableProperty.Register(nameof (PasswordChar), typeof (char), typeof (TextBox));
    /// <summary>
    /// Provides a property reference to UseSystemPasswordChar property.
    /// </summary>
    private static SerializableProperty UseSystemPasswordCharProperty = SerializableProperty.Register(nameof (UseSystemPasswordChar), typeof (bool), typeof (TextBox));
    /// <summary>Provides a property reference to ScrollBars property.</summary>
    private static SerializableProperty ScrollBarsProperty = SerializableProperty.Register(nameof (ScrollBars), typeof (ScrollBars), typeof (TextBox));
    /// <summary>
    /// Provides a property reference to HorizontalAlignment property.
    /// </summary>
    private static SerializableProperty HorizontalAlignmentProperty = SerializableProperty.Register("HorizontalAlignment", typeof (HorizontalAlignment), typeof (TextBox));
    /// <summary>The EnterKeyDown event registration.</summary>
    private static readonly SerializableEvent EnterKeyDownEvent = SerializableEvent.Register("EnterKeyDown", typeof (KeyEventHandler), typeof (TextBox));

    /// <summary>Gets the hanlder for the EnterKeyDown event.</summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected KeyEventHandler EnterKeyDownHandler => (KeyEventHandler) this.GetHandler(TextBox.EnterKeyDownEvent);

    /// <summary>Occurs on enter key down only on single line.</summary>
    public event KeyEventHandler EnterKeyDown
    {
      add => this.AddCriticalHandler(TextBox.EnterKeyDownEvent, (Delegate) value);
      remove => this.RemoveCriticalHandler(TextBox.EnterKeyDownEvent, (Delegate) value);
    }

    /// <summary>Occurs when [client enter key down].</summary>
    [SRDescription("Occurs when enter key pressed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientEnterKeyDown
    {
      add => this.AddClientHandler("EnterKeyDown", value);
      remove => this.RemoveClientHandler("EnterKeyDown", value);
    }

    /// <summary>Formats the text.</summary>
    /// <param name="strValue">The text value.</param>
    /// <returns></returns>
    private string FormatText(string strValue)
    {
      if (!string.IsNullOrEmpty(strValue))
      {
        switch (this.CharacterCasing)
        {
          case CharacterCasing.Upper:
            return strValue.ToUpperInvariant();
          case CharacterCasing.Lower:
            return strValue.ToLowerInvariant();
        }
      }
      return strValue;
    }

    /// <summary>Set the value from the clip board</summary>
    /// <param name="strValue"></param>
    protected override void SetClipboardContent(string strValue) => this.SelectedText = strValue;

    /// <summary>Get content to be added to the clip board</summary>
    /// <returns></returns>
    protected override string GetClipboardContent() => this.SelectedText;

    /// <summary>Undoes the last edit operation in the text box.</summary>
    public void Undo()
    {
    }

    /// <summary>Implements the actual client side selection</summary>
    /// <param name="intStart"></param>
    /// <param name="intLength"></param>
    protected override void InvokeSelection(int intStart, int intLength) => this.InvokeMethodWithId("TextBox_Execute", (object) "Select", (object) intStart, (object) intLength);

    /// <summary>Renders the current control attributes.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter">The response writer object.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      HorizontalAlignment proxyPropertyValue = this.GetProxyPropertyValue<HorizontalAlignment>("TextAlign", this.TextAlign);
      if (proxyPropertyValue != HorizontalAlignment.Left)
        objWriter.WriteAttributeString("TA", proxyPropertyValue.ToString());
      if (this.PasswordChar != char.MinValue || this.UseSystemPasswordChar)
        objWriter.WriteAttributeString("PWD", "1");
      TextBoxValidation validator = this.Validator;
      if (validator != null)
      {
        if (validator.ValueValidationExpression != string.Empty)
          objWriter.WriteAttributeString("VVE", validator.ValueValidationExpression);
        if (validator.CharacterValidationMask != string.Empty)
          objWriter.WriteAttributeString("CVM", validator.CharacterValidationMask);
        if (validator.CharacterValidationExpression != string.Empty)
          objWriter.WriteAttributeString("CVE", validator.CharacterValidationExpression);
        if (validator.InValidateMessage != string.Empty)
          objWriter.WriteAttributeText("IVM", validator.InValidateMessage);
      }
      CharacterCasing characterCasing = this.CharacterCasing;
      if (characterCasing != CharacterCasing.Normal)
        objWriter.WriteAttributeString("CC", ((byte) characterCasing).ToString());
      if (this.Multiline && this.ScrollBars != ScrollBars.None)
        objWriter.WriteAttributeString("SB", Convert.ToInt32((object) this.ScrollBars).ToString());
      objWriter.WriteAttributeString("GROTB", this.WinFormsCompatibility.IsGrayedReadOnlyTextBox ? "1" : "0");
    }

    /// <summary>Render control params</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter">The response writer object.</param>
    /// <param name="lngRequestID">Request ID.</param>
    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        return;
      objWriter.WriteAttributeString("GROTB", this.WinFormsCompatibility.IsGrayedReadOnlyTextBox ? "1" : "0");
    }

    /// <summary>Renders the value.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected override void RenderValue(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceReder)
    {
      string text = this.Text;
      if (!(!string.IsNullOrEmpty(text) | blnForceReder))
        return;
      objWriter.WriteAttributeText("VLB", text, this.Multiline ? TextFilter.None : TextFilter.NewLine | TextFilter.CarriageReturn);
    }

    /// <summary>Gets the control renderer.</summary>
    /// <returns></returns>
    protected override ControlRenderer GetControlRenderer() => (ControlRenderer) new TextBoxRenderer(this);

    /// <summary>Gets the win forms compatibility.</summary>
    /// <returns></returns>
    protected override Gizmox.WebGUI.Forms.WinFormsCompatibility GetWinFormsCompatibility() => (Gizmox.WebGUI.Forms.WinFormsCompatibility) new TextBoxWinFormsCompatibility();

    /// <summary>
    /// Called when WinFormsCompatibility option value is changed.
    /// </summary>
    protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
    {
      if (strChangedOptionName == "GrayedReadOnlyTextBox")
        this.UpdateParams(AttributeType.Control);
      base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
    }

    /// <summary>Gets the critical events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalEventsData()
    {
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      if (this.EnterKeyDownHandler != null)
        criticalEventsData.Set("EKD");
      return criticalEventsData;
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("EnterKeyDown"))
        clientEventsData.Set("EKD");
      return clientEventsData;
    }

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      if (objEvent.Type == "EnterKeyDown" && this.EnterKeyDownHandler != null)
        this.EnterKeyDownHandler((object) this, new KeyEventArgs(Keys.Enter));
      base.FireEvent(objEvent);
    }

    /// <summary>Gets or sets how text is aligned in a <see cref="T:Gizmox.WebGUI.Forms.TextBox"></see> control.</summary>
    /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> enumeration values that specifies how text is aligned in the control. The default is HorizontalAlignment.Left.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">A value that is not within the range of valid values for the enumeration was assigned to the property. </exception>
    /// <filterpriority>1</filterpriority>
    [DefaultValue(HorizontalAlignment.Left)]
    [Localizable(true)]
    [SRCategory("CatAppearance")]
    [SRDescription("TextBoxTextAlignDescr")]
    [ProxyBrowsable(true)]
    public HorizontalAlignment TextAlign
    {
      get => this.GetValue<HorizontalAlignment>(TextBox.HorizontalAlignmentProperty, HorizontalAlignment.Left);
      set
      {
        if (this.TextAlign == value)
          return;
        this.SetValue<HorizontalAlignment>(TextBox.HorizontalAlignmentProperty, value);
        this.Update();
      }
    }

    /// <summary>Gets or sets the text associated with this control.</summary>
    /// <value></value>
    public override string Text
    {
      get => this.FormatText(base.Text);
      set => base.Text = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether pressing ENTER in a multiline TextBox control creates a new line of text in the control or activates the default button for the form.
    /// </summary>
    [DefaultValue(true)]
    public virtual bool AcceptsReturn
    {
      get => true;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets which scroll bars should appear in a multiline TextBox control.
    /// </summary>
    /// <value>
    /// One of the ScrollBars enumeration values that indicates whether a multiline TextBox control appears with no scroll bars, a horizontal scroll bar, a vertical scroll bar, or both. The default is ScrollBars.None.
    /// </value>
    [DefaultValue(ScrollBars.None)]
    [SRCategory("Style")]
    [SRDescription("Scrollbar state definition")]
    public virtual ScrollBars ScrollBars
    {
      get => this.GetValue<ScrollBars>(TextBox.ScrollBarsProperty, ScrollBars.None);
      set
      {
        if (!value.GetType().Equals(this.ScrollBars.GetType()) || this.ScrollBars == value)
          return;
        this.SetValue<ScrollBars>(TextBox.ScrollBarsProperty, value);
        this.Update();
      }
    }

    /// <summary>Gets or sets the password charecter.</summary>
    /// <value></value>
    [DefaultValue('\0')]
    [SRCategory("CatBehavior")]
    [SRDescription("TextBoxPasswordCharDescr")]
    public char PasswordChar
    {
      get => this.GetValue<char>(TextBox.PasswordCharProperty, char.MinValue);
      set
      {
        if ((int) this.PasswordChar == (int) value)
          return;
        if (value != char.MinValue)
          this.SetValue<char>(TextBox.PasswordCharProperty, value);
        else
          this.RemoveValue<char>(TextBox.PasswordCharProperty);
        this.Update();
      }
    }

    /// <summary>Gets or sets a value indicating whether the text in the <see cref="T:System.Windows.Forms.TextBox"></see> control should appear as the default password character.</summary>
    /// <returns>true if the text in the <see cref="T:System.Windows.Forms.TextBox"></see> control should appear as the default password character; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    [SRDescription("TextBoxUseSystemPasswordCharDescr")]
    public bool UseSystemPasswordChar
    {
      get => this.GetValue<bool>(TextBox.UseSystemPasswordCharProperty, false);
      set
      {
        if (this.UseSystemPasswordChar == value)
          return;
        if (value)
          this.SetValue<bool>(TextBox.UseSystemPasswordCharProperty, value);
        else
          this.RemoveValue<bool>(TextBox.UseSystemPasswordCharProperty);
        this.Update();
      }
    }

    /// <summary>Gets or sets the text box validator.</summary>
    /// <value></value>
    [DefaultValue(null)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TextBoxValidation Validator
    {
      get => this.GetValue<TextBoxValidation>(TextBox.ValidatorProperty);
      set
      {
        if (this.Validator == value)
          return;
        this.Update();
        this.SetValue<TextBoxValidation>(TextBox.ValidatorProperty, value);
      }
    }

    /// <summary>Gets a value indicating whether the user can undo the previous operation in a text box control.</summary>
    /// <returns>true if the user can undo the previous operation performed in a text box control; otherwise, false.</returns>
    /// <filterpriority>1</filterpriority>
    [SRCategory("CatBehavior")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("TextBoxCanUndoDescr")]
    [Browsable(false)]
    public bool CanUndo => false;

    /// <summary>
    /// Indicates if all characters should be left alone or converted to uppercase or lowercase
    /// </summary>
    /// <value></value>
    [SRCategory("CatBehavior")]
    [SRDescription("TextBoxCharacterCasingDescr")]
    [DefaultValue(CharacterCasing.Normal)]
    public CharacterCasing CharacterCasing
    {
      get => this.GetValue<CharacterCasing>(TextBox.CharacterCasingProperty, CharacterCasing.Normal);
      set
      {
        if (this.CharacterCasing == value)
          return;
        if (!ClientUtils.IsEnumValid((Enum) value, (int) value, 0, 2))
          throw new InvalidEnumArgumentException(nameof (value), (int) value, typeof (CharacterCasing));
        this.SetValue<CharacterCasing>(TextBox.CharacterCasingProperty, value);
        this.Update();
      }
    }

    /// <summary>Gets the default size.</summary>
    /// <value>The default size.</value>
    protected override Size DefaultSize => new Size(100, 20);

    /// <summary>
    /// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
    /// </summary>
    /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
    protected override bool Focusable => true;

    /// <summary>Gets or sets a value specifying the source of complete strings used for automatic completion.</summary>
    /// <returns>One of the values of <see cref="T:System.Windows.Forms.AutoCompleteSource"></see>. The options are AllSystemSources, AllUrl, FileSystem, HistoryList, RecentlyUsedList, CustomSource, and None. The default is None.</returns>
    /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the values of <see cref="T:System.Windows.Forms.AutoCompleteSource"></see>. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DefaultValue(AutoCompleteSource.None)]
    [SRDescription("TextBoxAutoCompleteSourceDescr")]
    public AutoCompleteSource AutoCompleteSource
    {
      get => AutoCompleteSource.None;
      set
      {
      }
    }

    /// <summary>Gets the win forms compatibility.</summary>
    /// <value>The win forms compatibility.</value>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public TextBoxWinFormsCompatibility WinFormsCompatibility => base.WinFormsCompatibility as TextBoxWinFormsCompatibility;
  }
}
