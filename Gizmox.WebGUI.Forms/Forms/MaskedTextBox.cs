// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.MaskedTextBox
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Uses a mask to distinguish between proper and improper user input.
  /// </summary>
  [SRDescription("DescriptionMaskedTextBox")]
  [DefaultProperty("Mask")]
  [ToolboxItemCategory("Common Controls")]
  [ToolboxBitmap(typeof (TextBox), "MaskedTextBox_45.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.MaskedTextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.MaskedTextBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (MaskedTextBoxSkin))]
  [Serializable]
  public class MaskedTextBox : TextBox
  {
    /// <summary>
    /// Provides a property reference to TextMaskFormat property.
    /// </summary>
    private static SerializableProperty TextMaskFormatProperty = SerializableProperty.Register(nameof (TextMaskFormat), typeof (MaskFormat), typeof (MaskedTextBox), new SerializablePropertyMetadata((object) MaskFormat.IncludeLiterals));
    /// <summary>
    /// Provides a property reference to UseTextMaskFormat property.
    /// </summary>
    private static SerializableProperty UseTextMaskFormatProperty = SerializableProperty.Register(nameof (UseTextMaskFormat), typeof (bool), typeof (MaskedTextBox));
    /// <summary>
    /// Provides a property reference to HidePromptOnLeave property.
    /// </summary>
    private static SerializableProperty HidePromptOnLeaveProperty = SerializableProperty.Register(nameof (HidePromptOnLeave), typeof (bool), typeof (MaskedTextBox));
    /// <summary>Provides a property reference to PromptChar property.</summary>
    private static SerializableProperty PromptCharProperty = SerializableProperty.Register(nameof (PromptChar), typeof (char), typeof (MaskedTextBox));
    /// <summary>Provides a property reference to Mask property.</summary>
    private static SerializableProperty MaskProperty = SerializableProperty.Register(nameof (Mask), typeof (string), typeof (MaskedTextBox));
    /// <summary>
    /// Provides a property reference to ResetOnPrompt property.
    /// </summary>
    private static SerializableProperty ResetOnPromptProperty = SerializableProperty.Register(nameof (ResetOnPrompt), typeof (bool), typeof (MaskedTextBox), new SerializablePropertyMetadata((object) true));
    /// <summary>
    /// Provides a property reference to AllowPromptAsInput property.
    /// </summary>
    private static SerializableProperty AllowPromptAsInputProperty = SerializableProperty.Register(nameof (AllowPromptAsInput), typeof (bool), typeof (MaskedTextBox), new SerializablePropertyMetadata((object) true));
    /// <summary>
    /// Provides a property reference to ResetOnSpace property.
    /// </summary>
    private static SerializableProperty ResetOnSpaceProperty = SerializableProperty.Register(nameof (ResetOnSpace), typeof (bool), typeof (MaskedTextBox), new SerializablePropertyMetadata((object) true));
    /// <summary>
    /// The prompt character to use in the displayed masked text
    /// </summary>
    private const char mcntPromptChar = '_';

    /// <summary>Renders the value.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objWriter">The writer.</param>
    /// <param name="blnForceRender">Force render</param>
    protected override void RenderValue(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender)
    {
      string empty = string.Empty;
      string mask = this.Mask;
      string strText = string.IsNullOrEmpty(mask) ? base.Text : this.GetTextOutput(base.Text, mask, this.PromptChar, true, !this.HidePromptOnLeave, this.AllowPromptAsInput, this.ResetOnPrompt, this.ResetOnSpace);
      if (!blnForceRender && string.IsNullOrEmpty(strText))
        return;
      objWriter.WriteAttributeText("VLB", strText);
    }

    /// <summary>Renders the current control attributes.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter">The response writer object.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      if (this.Mask != string.Empty)
        objWriter.WriteAttributeString("MK", this.GetFormatedMask());
      if (this.HidePromptOnLeave)
        objWriter.WriteAttributeString("HPOL", "1");
      this.RenderResetOnSpaceAttribute(objWriter, false);
      this.RenderResetOnPromptAttribute(objWriter, false);
      this.RenderAllowPromptAsInputAttribute(objWriter, false);
      objWriter.WriteAttributeString("PC", this.PromptChar.ToString());
    }

    /// <summary>Render updated control params</summary>
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
      this.RenderResetOnSpaceAttribute(objWriter, true);
      this.RenderResetOnPromptAttribute(objWriter, true);
      this.RenderAllowPromptAsInputAttribute(objWriter, true);
    }

    /// <summary>Renders the ResetOnSpace attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderResetOnSpaceAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!(!this.ResetOnSpace | blnForceRender))
        return;
      objWriter.WriteAttributeString("ROS", this.ResetOnSpace ? "1" : "0");
    }

    /// <summary>Renders the ResetOnPrompt attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderResetOnPromptAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!(!this.ResetOnPrompt | blnForceRender))
        return;
      objWriter.WriteAttributeString("ROP", this.ResetOnPrompt ? "1" : "0");
    }

    /// <summary>Renders the AllowPromptAsInput attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderAllowPromptAsInputAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      if (!(!this.AllowPromptAsInput | blnForceRender))
        return;
      objWriter.WriteAttributeString("API", this.AllowPromptAsInput ? "1" : "0");
    }

    /// <summary>Implements the actual client side selection</summary>
    /// <param name="intStart"></param>
    /// <param name="intLength"></param>
    protected override void InvokeSelection(int intStart, int intLength) => this.InvokeMethodWithId("Common_MaskExecute", (object) "Select", (object) intStart, (object) intLength);

    /// <summary>Returns the formatted string that includes all the assigned character values.</summary>
    /// <returns>The formatted <see cref="T:System.String"></see> that includes all the assigned character values.</returns>
    private string GetTextOutput()
    {
      bool blnIncludeLiterals = false;
      bool blnIncludePrompt = false;
      switch (this.TextMaskFormat)
      {
        case MaskFormat.IncludePrompt:
          blnIncludePrompt = true;
          break;
        case MaskFormat.IncludeLiterals:
          blnIncludeLiterals = true;
          break;
        case MaskFormat.IncludePromptAndLiterals:
          blnIncludeLiterals = true;
          blnIncludePrompt = true;
          break;
      }
      return this.GetTextOutput(base.Text, this.Mask, this.PromptChar, blnIncludeLiterals, blnIncludePrompt, this.AllowPromptAsInput, this.ResetOnPrompt, this.ResetOnSpace);
    }

    /// <summary>Gets the text output.</summary>
    /// <param name="strValue">The STR value.</param>
    /// <param name="strMask">The STR mask.</param>
    /// <param name="chrPromptChar">The CHR prompt char.</param>
    /// <param name="blnIncludeLiterals">if set to <c>true</c> [BLN include literals].</param>
    /// <param name="blnIncludePrompt">if set to <c>true</c> [BLN include prompt].</param>
    /// <returns></returns>
    private string GetTextOutput(
      string strValue,
      string strMask,
      char chrPromptChar,
      bool blnIncludeLiterals,
      bool blnIncludePrompt,
      bool blnAllowPromptAsInput,
      bool blnResetOnPrompt,
      bool blnResetOnSpace)
    {
      return this.GetMaskedTextProvider(strValue, strMask, chrPromptChar, blnIncludeLiterals, blnIncludePrompt, blnAllowPromptAsInput, blnResetOnPrompt, blnResetOnSpace).ToString();
    }

    /// <summary>Gets the masked text provider.</summary>
    /// <param name="strValue">The text value.</param>
    /// <param name="strMask">The mask value.</param>
    /// <param name="chrPromptChar">The prompt char.</param>
    /// <param name="blnIncludeLiterals">if set to <c>true</c> [BLN include literals].</param>
    /// <param name="blnIncludePrompt">if set to <c>true</c> [include prompt].</param>
    /// <returns></returns>
    private MaskedTextProvider GetMaskedTextProvider(
      string strValue,
      string strMask,
      char chrPromptChar,
      bool blnIncludeLiterals,
      bool blnIncludePrompt,
      bool blnAllowPromptAsInput,
      bool blnResetOnPrompt,
      bool blnResetOnSpace)
    {
      if (string.IsNullOrEmpty(strMask))
        strMask = "<>";
      MaskedTextProvider maskedTextProvider = new MaskedTextProvider(strMask, CultureInfo.CurrentUICulture, blnAllowPromptAsInput);
      maskedTextProvider.PromptChar = chrPromptChar;
      maskedTextProvider.IncludeLiterals = blnIncludeLiterals;
      maskedTextProvider.IncludePrompt = blnIncludePrompt;
      maskedTextProvider.ResetOnPrompt = blnResetOnPrompt;
      maskedTextProvider.ResetOnSpace = blnResetOnSpace;
      maskedTextProvider.Set(strValue);
      return maskedTextProvider;
    }

    /// <summary>Gets formated cultured mask.</summary>
    /// <returns></returns>
    private string GetFormatedMask()
    {
      StringBuilder stringBuilder = new StringBuilder();
      string mask = this.Mask;
      if (!string.IsNullOrEmpty(mask))
      {
        foreach (char ch in mask)
        {
          switch (ch)
          {
            case '$':
              stringBuilder.Append(CultureInfo.CurrentUICulture.NumberFormat.CurrencySymbol);
              break;
            case ',':
              stringBuilder.Append(CultureInfo.CurrentUICulture.NumberFormat.NumberGroupSeparator);
              break;
            case '.':
              stringBuilder.Append(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator);
              break;
            case '/':
              stringBuilder.Append(CultureInfo.CurrentUICulture.DateTimeFormat.DateSeparator);
              break;
            case ':':
              stringBuilder.Append(CultureInfo.CurrentUICulture.DateTimeFormat.TimeSeparator);
              break;
            default:
              stringBuilder.Append(ch);
              break;
          }
        }
      }
      return stringBuilder.ToString();
    }

    /// <summary>Gets or sets the input mask to use at run time.</summary>
    /// <returns>A <see cref="T:System.String"></see> representing the current mask. The default value is the empty string which allows any input.</returns>
    /// <exception cref="T:System.ArgumentException">The string supplied to the <see cref="P:Gizmox.WebGUI.Forms.MaskedTextBox.Mask"></see> property is not a valid mask. Invalid masks include masks containing non-printable characters.</exception>
    [Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    [SRDescription("MaskedTextBoxMaskDescr")]
    [RefreshProperties(RefreshProperties.Repaint)]
    [DefaultValue("")]
    public string Mask
    {
      get => this.GetValue<string>(MaskedTextBox.MaskProperty, string.Empty);
      set
      {
        if (!(this.Mask != value))
          return;
        if (value != string.Empty)
          this.SetValue<string>(MaskedTextBox.MaskProperty, value);
        else
          this.RemoveValue<string>(MaskedTextBox.MaskProperty);
        string text = base.Text;
        string textOutput = this.GetTextOutput(base.Text, this.Mask, this.PromptChar, false, false, this.AllowPromptAsInput, this.ResetOnPrompt, this.ResetOnSpace);
        if (textOutput != text)
          this.InternalText = textOutput;
        this.Update();
      }
    }

    /// <summary>Gets or sets the character used to represent the absence of user input in <see cref="T:System.Windows.Forms.MaskedTextBox"></see>.</summary>
    /// <returns>The character used to prompt the user for input. The default is an underscore (_). </returns>
    /// <exception cref="T:System.InvalidOperationException">The prompt character specified is the same as the current password character, <see cref="P:System.Windows.Forms.MaskedTextBox.PasswordChar"></see>. The two are required to be different.</exception>
    /// <exception cref="T:System.ArgumentException">The character specified when setting this property is not a valid prompt character, as determined by the <see cref="M:System.ComponentModel.MaskedTextProvider.IsValidPasswordChar(System.Char)"></see> method of the <see cref="T:System.ComponentModel.MaskedTextProvider"></see> class.</exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [Localizable(true)]
    [SRCategory("CatAppearance")]
    [SRDescription("MaskedTextBoxPromptCharDescr")]
    [DefaultValue('_')]
    [RefreshProperties(RefreshProperties.Repaint)]
    public char PromptChar
    {
      get => this.GetValue<char>(MaskedTextBox.PromptCharProperty, '_');
      set
      {
        if (!MaskedTextProvider.IsValidInputChar(value))
          throw new ArgumentException(SR.GetString("MaskedTextBoxInvalidCharError"));
        char promptChar = this.PromptChar;
        if ((int) promptChar == (int) value)
          return;
        MaskedTextProvider maskedTextProvider = this.GetMaskedTextProvider(base.Text, this.Mask, promptChar, true, true, this.AllowPromptAsInput, this.ResetOnPrompt, this.ResetOnSpace);
        maskedTextProvider.PromptChar = value;
        this.InternalText = maskedTextProvider.ToString();
        if (value != '_')
          this.SetValue<char>(MaskedTextBox.PromptCharProperty, value);
        else
          this.RemoveValue<char>(MaskedTextBox.PromptCharProperty);
        this.Update();
      }
    }

    /// <summary>Gets or sets a value indicating whether the prompt characters in the input mask are hidden when the masked text box loses focus.</summary>
    /// <returns>true if <see cref="P:System.Windows.Forms.MaskedTextBox.PromptChar"></see> is hidden when <see cref="T:System.Windows.Forms.MaskedTextBox"></see> does not have focus; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [DefaultValue(false)]
    [SRCategory("CatBehavior")]
    [SRDescription("MaskedTextBoxHidePromptOnLeaveDescr")]
    [RefreshProperties(RefreshProperties.Repaint)]
    public bool HidePromptOnLeave
    {
      get => this.GetValue<bool>(MaskedTextBox.HidePromptOnLeaveProperty, false);
      set
      {
        if (this.HidePromptOnLeave == value)
          return;
        if (value)
          this.SetValue<bool>(MaskedTextBox.HidePromptOnLeaveProperty, value);
        else
          this.RemoveValue<bool>(MaskedTextBox.HidePromptOnLeaveProperty);
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether System.Windows.Forms.MaskedTextBox.PromptChar
    /// can be entered as valid data by the user.
    /// </summary>
    /// <value>
    ///   <c>true</c> if the user can enter the prompt character into the control; otherwise, <c>false</c>.
    /// </value>
    [SRCategory("CatBehavior")]
    [SRDescription("MaskedTextBoxAllowPromptAsInputDescr")]
    [DefaultValue(true)]
    public bool AllowPromptAsInput
    {
      get => this.GetValue<bool>(MaskedTextBox.AllowPromptAsInputProperty);
      set
      {
        if (!this.SetValue<bool>(MaskedTextBox.AllowPromptAsInputProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>
    /// Gets or sets a value that determines how an input character that matches
    /// the prompt character should be handled.
    /// </summary>
    /// <value>
    ///   <c>true</c> if the prompt character entered as input causes the current editable
    ///     position in the mask to be reset; otherwise, <c>false</c>.to indicate that the prompt
    ///     character is to be processed as a normal input character
    /// </value>
    [SRDescription("MaskedTextBoxResetOnPrompt")]
    [DefaultValue(true)]
    [SRCategory("CatBehavior")]
    public bool ResetOnPrompt
    {
      get => this.GetValue<bool>(MaskedTextBox.ResetOnPromptProperty);
      set
      {
        if (!this.SetValue<bool>(MaskedTextBox.ResetOnPromptProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [reset on space].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [reset on space]; otherwise, <c>false</c>.
    /// </value>
    [SRDescription("MaskedTextBoxResetOnSpace")]
    [DefaultValue(true)]
    [SRCategory("CatBehavior")]
    public bool ResetOnSpace
    {
      get => this.GetValue<bool>(MaskedTextBox.ResetOnSpaceProperty);
      set
      {
        if (!this.SetValue<bool>(MaskedTextBox.ResetOnSpaceProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets or sets the text associated with this control.</summary>
    [DefaultValue("")]
    [SRCategory("CatAppearance")]
    [SRDescription("ControlTextDescr")]
    [Localizable(true)]
    [Bindable(true)]
    public override string Text
    {
      get => this.DesignMode || string.IsNullOrEmpty(this.Mask) || !this.UseTextMaskFormat ? base.Text : this.GetTextOutput();
      set
      {
        this.UseTextMaskFormat = false;
        if (base.Text != value)
        {
          string mask = this.Mask;
          if (string.IsNullOrEmpty(mask))
            base.Text = value;
          else
            base.Text = this.GetTextOutput(value, mask, this.PromptChar, false, false, this.AllowPromptAsInput, this.ResetOnPrompt, this.ResetOnSpace);
        }
        this.UseTextMaskFormat = true;
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether to use text mask format.
    /// </summary>
    /// <value><c>true</c> if use text mask format; otherwise, <c>false</c>.</value>
    private bool UseTextMaskFormat
    {
      get => this.GetValue<bool>(MaskedTextBox.UseTextMaskFormatProperty, true);
      set
      {
        if (this.UseTextMaskFormat == value)
          return;
        if (!value)
          this.SetValue<bool>(MaskedTextBox.UseTextMaskFormatProperty, value);
        else
          this.RemoveValue<bool>(MaskedTextBox.UseTextMaskFormatProperty);
      }
    }

    /// <summary>Defines how Text property should be formatted</summary>
    [DefaultValue(MaskFormat.IncludeLiterals)]
    [SRCategory("CatBehavior")]
    [SRDescription("MaskedTextBoxTextMaskFormat")]
    public MaskFormat TextMaskFormat
    {
      get => this.GetValue<MaskFormat>(MaskedTextBox.TextMaskFormatProperty, MaskFormat.IncludeLiterals);
      set
      {
        if (this.TextMaskFormat == value)
          return;
        if (value != MaskFormat.IncludeLiterals)
          this.SetValue<MaskFormat>(MaskedTextBox.TextMaskFormatProperty, value);
        else
          this.RemoveValue<MaskFormat>(MaskedTextBox.TextMaskFormatProperty);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether text box is multi line.
    /// </summary>
    /// <value>always false for MaskedTextbox.</value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override bool Multiline
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets a value indicating whether the user is allowed to reenter literal values.</summary>
    /// <returns>true to allow literals to be reentered; otherwise, false to prevent the user from overwriting literal characters. The default is true.</returns>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SRCategory("CatBehavior")]
    [DefaultValue(true)]
    [SRDescription("MaskedTextBoxSkipLiterals")]
    public bool SkipLiterals
    {
      get => true;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether pressing ENTER in a multiline TextBox control creates a new line of text in the control or activates the default button for the form. This property is not supported by MaskedTextBox.
    /// </summary>
    /// <value>false in all cases.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override bool AcceptsReturn
    {
      get => false;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value determining how TAB keys are handled for multiline configurations. This property is not supported by MaskedTextBox.
    /// </summary>
    /// <value>false in all cases.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override bool AcceptsTab
    {
      get => false;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets the lines of text in multiline configurations. This property is not supported by MaskedTextBox.
    /// </summary>
    /// <value>An array of type String that contains a single line.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override string[] Lines
    {
      get => base.Lines;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether a multiline text box control automatically wraps words to the beginning of the next line when necessary. This property is not supported by MaskedTextBox.
    /// </summary>
    /// <value>The WordWrap property always returns false.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override bool WordWrap
    {
      get => false;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets the maximum number of characters the user can type or paste into the text box control. This property is not supported by MaskedTextBox.
    /// </summary>
    /// <value>This property always returns 0.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override int MaxLength
    {
      get => base.MaxLength;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets which scroll bars should appear in a multiline TextBox control. This property is not supported by MaskedTextBox.
    /// </summary>
    /// <value>This property always returns ScrollBars.None.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public override ScrollBars ScrollBars
    {
      get => ScrollBars.None;
      set
      {
      }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MaskedTextBox"></see> class using defaults.
    /// </summary>
    public MaskedTextBox() => this.CustomStyle = "Masked";
  }
}
