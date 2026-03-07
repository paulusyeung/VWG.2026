// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TextBoxBase
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Globalization;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// Implements the basic functionality required by text controls.
  /// </summary>
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (TextBoxBaseSkin))]
  [DefaultEvent("TextChanged")]
  [Serializable]
  public abstract class TextBoxBase : Control
  {
    /// <summary>
    /// Provides a property reference to SelectionLength property.
    /// </summary>
    private static SerializableProperty SelectionLengthProperty = SerializableProperty.Register(nameof (SelectionLength), typeof (int), typeof (TextBoxBase), new SerializablePropertyMetadata((object) 0));
    /// <summary>Provides a property reference to AcceptsTab property.</summary>
    private static SerializableProperty AcceptsTabProperty = SerializableProperty.Register(nameof (AcceptsTab), typeof (bool), typeof (TextBoxBase), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to WordWrap property.</summary>
    private static SerializableProperty WordWrapProperty = SerializableProperty.Register(nameof (WordWrap), typeof (bool), typeof (TextBoxBase), new SerializablePropertyMetadata((object) true));
    /// <summary>Provides a property reference to Multiline property.</summary>
    private static SerializableProperty MultilineProperty = SerializableProperty.Register(nameof (Multiline), typeof (bool), typeof (TextBoxBase), new SerializablePropertyMetadata((object) false));
    /// <summary>Provides a property reference to MaxLength property.</summary>
    private static SerializableProperty MaxLengthProperty = SerializableProperty.Register(nameof (MaxLength), typeof (int), typeof (TextBoxBase), new SerializablePropertyMetadata((object) 0));
    /// <summary>
    /// Provides a property reference to SelectionStart property.
    /// </summary>
    private static SerializableProperty SelectionStartProperty = SerializableProperty.Register(nameof (SelectionStart), typeof (int), typeof (TextBoxBase), new SerializablePropertyMetadata((object) 0));
    /// <summary>
    /// Provides a property reference to HideSelection property.
    /// </summary>
    private static SerializableProperty HideSelectionProperty = SerializableProperty.Register(nameof (HideSelection), typeof (bool), typeof (TextBoxBase), new SerializablePropertyMetadata((object) true));
    /// <summary>
    /// 
    /// </summary>
    private static SerializableProperty IsAutoCompleteProperty = SerializableProperty.Register(nameof (IsAutoComplete), typeof (bool), typeof (TextBoxBase), new SerializablePropertyMetadata((object) true));

    /// <summary>Gets the key event captures.</summary>
    /// <returns></returns>
    protected override KeyCaptures GetKeyEventCaptures() => base.GetKeyEventCaptures() | KeyCaptures.UpKeyCapture | KeyCaptures.DownKeyCapture | KeyCaptures.RightKeyCapture | KeyCaptures.LeftKeyCapture | KeyCaptures.EnterKeyCapture | KeyCaptures.HomeKeyCapture | KeyCaptures.EndKeyCapture;

    /// <summary>Fires an event.</summary>
    /// <param name="objEvent">event.</param>
    protected override void FireEvent(IEvent objEvent)
    {
      switch (objEvent.Type)
      {
        case "ValueChange":
          if (this.ReadOnly)
            break;
          this.InternalText = CommonUtils.DecodeText(objEvent["TX"]);
          if (!this.WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents)
            break;
          this.OnValidating(new CancelEventArgs());
          this.OnValidated(EventArgs.Empty);
          break;
        case "SelectionChanged":
          if (objEvent.Contains("SST"))
            this.SetValue<int>(TextBoxBase.SelectionStartProperty, int.Parse(objEvent["SST"]));
          if (!objEvent.Contains("SLN"))
            break;
          this.SetValue<int>(TextBoxBase.SelectionLengthProperty, int.Parse(objEvent["SLN"]));
          break;
        case "TextBoxRealTimeKeyDown":
          this.FireKeyDown(objEvent);
          break;
        case "TextBoxRealTimeKeyPress":
          this.FireKeyPress(objEvent);
          break;
        case "TextBoxRealTimeKeyUp":
          this.FireKeyUp(objEvent);
          break;
        default:
          base.FireEvent(objEvent);
          break;
      }
    }

    /// <summary>Gets the keys.</summary>
    /// <param name="objEvent">The obj event.</param>
    /// <returns></returns>
    private Keys GetKeys(IEvent objEvent)
    {
      Keys keyCode = objEvent.KeyCode;
      if (objEvent.AltKey)
        keyCode |= Keys.Alt;
      if (objEvent.ControlKey)
        keyCode |= Keys.Control;
      if (objEvent.ShiftKey)
        keyCode |= Keys.Shift;
      return keyCode;
    }

    /// <summary>Fires the key down event.</summary>
    /// <param name="objEvent">event.</param>
    private new void FireKeyDown(IEvent objEvent) => this.OnKeyDown(new KeyEventArgs(this.GetKeys(objEvent)));

    /// <summary>Fires the key press.</summary>
    /// <param name="objEvent">The obj event.</param>
    private void FireKeyPress(IEvent objEvent) => this.OnKeyPress(new KeyPressEventArgs((char) this.GetKeys(objEvent)));

    /// <summary>Fires the key up.</summary>
    /// <param name="objEvent">The obj event.</param>
    private void FireKeyUp(IEvent objEvent) => this.OnKeyUp(new KeyEventArgs(this.GetKeys(objEvent)));

    /// <summary>Get flag to state the criticality of keyboard events.</summary>
    /// <returns></returns>
    private TextBoxEventTypes GetTextBoxCriticalKeyEvents()
    {
      TextBoxEventTypes criticalKeyEvents = TextBoxEventTypes.None;
      if (this.KeyDownHandler != null)
        criticalKeyEvents |= TextBoxEventTypes.TextBoxRealTimeKeyDown;
      if (this.KeyPressHandler != null)
        criticalKeyEvents |= TextBoxEventTypes.TextBoxRealTimeKeyPress;
      if (this.KeyUpHandler != null)
        criticalKeyEvents |= TextBoxEventTypes.TextBoxRealTimeKeyUp;
      return criticalKeyEvents;
    }

    /// <summary>Occurs when [client value changed].</summary>
    [SRDescription("Occurs when control's text changed in client mode.")]
    [Category("Client")]
    public event ClientEventHandler ClientTextChanged
    {
      add => this.AddClientHandler("ValueChange", value);
      remove => this.RemoveClientHandler("ValueChange", value);
    }

    /// <summary>Gets the critical client events.</summary>
    /// <returns></returns>
    protected override CriticalEventsData GetCriticalClientEventsData()
    {
      CriticalEventsData clientEventsData = base.GetCriticalClientEventsData();
      if (this.HasClientHandler("ValueChange"))
        clientEventsData.Set("VC");
      return clientEventsData;
    }

    /// <summary>Renders the current control attributes.</summary>
    /// <param name="objContext">Request context.</param>
    /// <param name="objWriter">The response writer object.</param>
    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      int maxLength = this.MaxLength;
      if (maxLength != 0)
        objWriter.WriteAttributeString("MH", maxLength.ToString());
      if (this.ReadOnly)
        objWriter.WriteAttributeString("RO", "1");
      if (!this.WordWrap)
        objWriter.WriteAttributeString("WW", "0");
      this.RenderValue(objContext, objWriter, false);
      if (this.Multiline)
      {
        if (this.AcceptsTab)
          objWriter.WriteAttributeString("ACT", "1");
        objWriter.WriteAttributeString("MLT", "1");
      }
      this.RenderIsAutoCompleteAttribute(objWriter, false);
      if (!this.WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents)
        return;
      objWriter.WriteAttributeString("TBRTKE", this.WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents ? "1" : "0");
      this.RenderTextboxKeyEventsAttributes(objWriter, false);
    }

    /// <summary>Renders the standard textbox key events attributes.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderTextboxKeyEventsAttributes(IAttributeWriter objWriter, bool blnForceRender)
    {
      int criticalKeyEvents = (int) this.GetTextBoxCriticalKeyEvents();
      if (!(criticalKeyEvents != 0 | blnForceRender))
        return;
      objWriter.WriteAttributeString("TBKEY", criticalKeyEvents.ToString());
    }

    /// <summary>Renders the is auto complete attribute.</summary>
    /// <param name="objWriter">The obj writer.</param>
    /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
    private void RenderIsAutoCompleteAttribute(IAttributeWriter objWriter, bool blnForceRender)
    {
      bool isAutoComplete = this.IsAutoComplete;
      if (!(!isAutoComplete | blnForceRender))
        return;
      objWriter.WriteAttributeString("IAC", isAutoComplete ? "1" : "0");
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
      if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
      {
        this.RenderValue(objContext, objWriter, true);
        objWriter.WriteAttributeString("RO", this.ReadOnly ? "1" : "0");
        this.RenderIsAutoCompleteAttribute(objWriter, true);
      }
      if (!this.WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents || !this.IsDirtyAttributes(lngRequestID, AttributeType.Events))
        return;
      this.RenderTextboxKeyEventsAttributes(objWriter, true);
    }

    protected override CriticalEventsData GetCriticalEventsData()
    {
      if (!this.WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents)
        return base.GetCriticalEventsData();
      CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
      criticalEventsData.Unset("KD");
      return criticalEventsData;
    }

    /// <summary>Renders the value.</summary>
    /// <param name="objContext">The obj context.</param>
    /// <param name="objWriter">The obj writer.</param>
    protected abstract void RenderValue(
      IContext objContext,
      IAttributeWriter objWriter,
      bool blnForceRender);

    /// <summary>Clears all text from the text box control.</summary>
    public void Clear() => this.Text = "";

    /// <summary>
    /// Copies the current selection in the text box to the Clipboard.
    /// </summary>
    public void Copy() => Clipboard.SetText(this.GetClipboardContent(), TextDataFormat.UnicodeText);

    /// <summary>
    /// Moves the current selection in the text box to the Clipboard.
    /// </summary>
    public void Cut()
    {
      Clipboard.SetText(this.GetClipboardContent(), TextDataFormat.UnicodeText);
      this.SelectedText = "";
    }

    /// <summary>
    /// Replaces the current selection in the text box with the contents of the Clipboard.
    /// </summary>
    public void Paste() => this.SetClipboardContent(Clipboard.GetText(TextDataFormat.UnicodeText));

    /// <summary>Sets the content of the clipboard.</summary>
    /// <param name="strValue">The STR value.</param>
    protected virtual void SetClipboardContent(string strValue)
    {
    }

    /// <summary>Gets the content of the clipboard.</summary>
    /// <returns></returns>
    protected virtual string GetClipboardContent() => "";

    /// <summary>Selects all text in the text box.</summary>
    public void SelectAll() => this.Select(0, this.TextLength);

    /// <summary>Scrolls the contents of the control to the current caret position.</summary>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    public void ScrollToCaret()
    {
      if (!this.Multiline)
        return;
      this.InvokeMethodWithId("TextBox_Execute", (object) nameof (ScrollToCaret));
    }

    /// <summary>Selects a range of text in the text box.</summary>
    /// <param name="intStart">The position of the first character in the current text selection within the text box. </param>
    /// <param name="intLength">The number of characters to select. </param>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the start parameter is less than zero.</exception>
    public void Select(int intStart, int intLength)
    {
      this.SetValue<int>(TextBoxBase.SelectionLengthProperty, intLength);
      this.SetValue<int>(TextBoxBase.SelectionStartProperty, intStart);
      this.InvokeSelection(intStart, intLength);
    }

    /// <summary>Appends text to the current text of a text box.</summary>
    /// <param name="strText">The text to append to the current contents of the text box. </param>
    public void AppendText(string strText)
    {
      if (strText.Length <= 0)
        return;
      this.Text = string.Format("{0}{1}", (object) this.Text, (object) strText);
    }

    /// <summary>Sets the selected text internal.</summary>
    /// <param name="strText">The text.</param>
    /// <param name="blnClearUndo">if set to <c>true</c> [clear undo].</param>
    internal virtual void SetSelectedTextInternal(string strText, bool blnClearUndo)
    {
      int selectionStart = this.SelectionStart;
      int selectionLength = this.SelectionLength;
      string str1 = this.Text.Substring(0, selectionStart);
      string str2 = this.Text.Substring(selectionStart + selectionLength, this.TextLength - (selectionStart + selectionLength));
      this.Text = string.Format("{0}{1}{2}", (object) str1, (object) strText, (object) str2);
    }

    /// <summary>Gets the win forms compatibility.</summary>
    /// <returns></returns>
    protected override Gizmox.WebGUI.Forms.WinFormsCompatibility GetWinFormsCompatibility() => (Gizmox.WebGUI.Forms.WinFormsCompatibility) new TextBoxBaseWinFormsCompatibility();

    /// <summary>
    /// Called when WinFormsCompatibility option value is changed.
    /// </summary>
    protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
    {
      if (strChangedOptionName == "TextBoxRealTimeKeyboardEvents")
        this.Update();
      base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is auto complete.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is auto complete; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public bool IsAutoComplete
    {
      get => this.GetValue<bool>(TextBoxBase.IsAutoCompleteProperty);
      set
      {
        if (!this.SetValue<bool>(TextBoxBase.IsAutoCompleteProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets the length of text in the control.</summary>
    /// <returns>The number of characters contained in the text of the control.</returns>
    [Browsable(false)]
    public virtual int TextLength => this.Text.Length;

    /// <summary>Gets or sets the text associated with this control.</summary>
    /// <value></value>
    [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof (UITypeEditor))]
    public override string Text
    {
      get => base.Text;
      set => base.Text = value;
    }

    /// <summary>Gets or sets a value indicating the currently selected text in the control.</summary>
    /// <returns>A string that represents the currently selected text in the text box.</returns>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRCategory("CatAppearance")]
    [SRDescription("TextBoxSelectedTextDescr")]
    [Browsable(false)]
    public virtual string SelectedText
    {
      get => this.Text == null ? "" : this.Text.Substring(this.SelectionStart, this.SelectionLength);
      set => this.SetSelectedTextInternal(value, true);
    }

    /// <summary>Gets or sets the number of characters selected in the text box.</summary>
    /// <returns>The number of characters selected in the text box.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is less than zero.</exception>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRDescription("TextBoxSelectionLengthDescr")]
    [SRCategory("CatAppearance")]
    [Browsable(false)]
    public virtual int SelectionLength
    {
      get => this.GetValue<int>(TextBoxBase.SelectionLengthProperty);
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (SelectionLength), SR.GetString("InvalidArgument", (object) nameof (SelectionLength), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (!this.SetValue<int>(TextBoxBase.SelectionLengthProperty, value))
          return;
        this.InvokeSelection(this.SelectionStart, value);
      }
    }

    /// <summary>Gets or sets the starting point of text selected in the text box.</summary>
    /// <returns>The starting position of text selected in the text box.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is less than zero.</exception>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [SRCategory("CatAppearance")]
    [SRDescription("TextBoxSelectionStartDescr")]
    public int SelectionStart
    {
      get => this.GetValue<int>(TextBoxBase.SelectionStartProperty);
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (SelectionStart), SR.GetString("InvalidArgument", (object) nameof (SelectionStart), (object) value.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
        if (!this.SetValue<int>(TextBoxBase.SelectionStartProperty, value))
          return;
        this.InvokeSelection(value, this.SelectionLength);
      }
    }

    /// <summary>
    /// Gets or sets the maximum number of characters the user can type or paste into the text box control.
    /// </summary>
    /// <value>
    /// The number of characters that can be entered into the control. The default is 0.
    /// </value>
    [Localizable(true)]
    [SRDescription("TextBoxMaxLengthDescr")]
    [DefaultValue(0)]
    [SRCategory("CatBehavior")]
    public virtual int MaxLength
    {
      get => this.GetValue<int>(TextBoxBase.MaxLengthProperty);
      set
      {
        if (!this.SetValue<int>(TextBoxBase.MaxLengthProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets a value indicating whether [read only].</summary>
    /// <value>
    /// 	<c>true</c> if [read only]; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    [RefreshProperties(RefreshProperties.Repaint)]
    [SRCategory("CatBehavior")]
    [SRDescription("TextBoxReadOnlyDescr")]
    public bool ReadOnly
    {
      get => this.GetState(Component.ComponentState.ReadOnly);
      set
      {
        if (!this.SetStateWithCheck(Component.ComponentState.ReadOnly, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether text box is multi line.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if multi line otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    [SRDescription("TextBoxMultilineDescr")]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.All)]
    public virtual bool Multiline
    {
      get => this.GetValue<bool>(TextBoxBase.MultilineProperty);
      set
      {
        if (!this.SetValue<bool>(TextBoxBase.MultilineProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets the lines of text in a text box control.
    /// Each element in the array becomes a line of text in the text box control.
    /// If the 'Multiline' property of the text box control is set to true and a newline
    /// character appears in the text, the text following the newline character is
    /// added to a new element in the array and displayed on a separate line.
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual string[] Lines
    {
      get
      {
        string text = this.Text;
        ArrayList arrayList = new ArrayList();
        int index;
        for (int startIndex = 0; startIndex < text.Length; startIndex = index)
        {
          for (index = startIndex; index < text.Length; ++index)
          {
            switch (text[index])
            {
              case '\n':
              case '\r':
                goto label_5;
              default:
                continue;
            }
          }
label_5:
          string str = text.Substring(startIndex, index - startIndex);
          arrayList.Add((object) str);
          if (index < text.Length && text[index] == '\r')
            ++index;
          if (index < text.Length && text[index] == '\n')
            ++index;
        }
        if (text.Length > 0)
        {
          string str1 = text;
          if (str1[str1.Length - 1] != '\r')
          {
            string str2 = text;
            if (str2[str2.Length - 1] != '\n')
              goto label_15;
          }
          arrayList.Add((object) "");
        }
label_15:
        return (string[]) arrayList.ToArray(typeof (string));
      }
      set
      {
        if (value != null && value.Length != 0)
        {
          StringBuilder stringBuilder = new StringBuilder(value[0]);
          for (int index = 1; index < value.Length; ++index)
          {
            stringBuilder.Append("\r\n");
            stringBuilder.Append(value[index]);
          }
          this.Text = stringBuilder.ToString();
        }
        else
          this.Text = "";
      }
    }

    /// <summary>
    /// Indicates whether a multiline text box control automatically wraps words to the beginning of the next line when necessary.
    /// </summary>
    /// <value>
    /// true if the multiline text box control wraps words; false if the text box control automatically scrolls horizontally when the user types past the right edge of the control. The default is true.
    /// </value>
    [DefaultValue(true)]
    public virtual bool WordWrap
    {
      get => this.GetValue<bool>(TextBoxBase.WordWrapProperty);
      set
      {
        if (!this.SetValue<bool>(TextBoxBase.WordWrapProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether pressing the TAB key in a multiline text box control types a TAB character in the control instead of moving the focus to the next control in the tab order
    /// </summary>
    [DefaultValue(false)]
    [SRDescription("Gets or sets a value indicating whether pressing the TAB key in a multiline text box control types a TAB character in the control instead of moving the focus to the next control in the tab order.")]
    [Localizable(true)]
    [SRCategory("CatBehavior")]
    [RefreshProperties(RefreshProperties.All)]
    public virtual bool AcceptsTab
    {
      get => this.GetValue<bool>(TextBoxBase.AcceptsTabProperty);
      set
      {
        if (!this.SetValue<bool>(TextBoxBase.AcceptsTabProperty, value))
          return;
        this.Update();
      }
    }

    /// <summary>Gets or sets the control padding.</summary>
    /// <value></value>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public override Padding Padding
    {
      get => base.Padding;
      set => base.Padding = value;
    }

    /// <summary>
    /// Gets a value indicating whether raise click event on mouse down.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if should raise click event on mouse down; otherwise, <c>false</c>.
    /// </value>
    protected override bool ShouldRaiseClickOnRightMouseDown => false;

    /// <summary>
    /// Gets or sets a value indicating whether [hide selection].
    /// </summary>
    /// <value>
    ///   <c>true</c> if [hide selection]; otherwise, <c>false</c>.
    /// </value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool HideSelection
    {
      get => this.GetValue<bool>(TextBoxBase.HideSelectionProperty);
      set => this.SetValue<bool>(TextBoxBase.HideSelectionProperty, value);
    }

    /// <summary>Gets the win forms compatibility.</summary>
    /// <value>The win forms compatibility.</value>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public TextBoxBaseWinFormsCompatibility WinFormsCompatibility => base.WinFormsCompatibility as TextBoxBaseWinFormsCompatibility;

    /// <summary>
    /// Gets or sets a value indicating whether this instance is server events synchronized.
    /// </summary>
    /// <value>
    /// <c>true</c> if this instance is server events synchronized; otherwise, <c>false</c>.
    /// </value>
    [DefaultValue(false)]
    [SRCategory("CatBehavior")]
    [SRDescription("Determines whether the keyboard events should fire in the WinForms compatible mode.")]
    [Browsable(false)]
    [Obsolete("This property is obsolete. Use WinFormsCompatibility property instead.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool RealTimeKeyboardEvents
    {
      get => this.WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents;
      set => this.WinFormsCompatibility.TextBoxRealTimeKeyboardEvents = value ? WinFormsCompatibilityStates.True : WinFormsCompatibilityStates.False;
    }
  }
}
