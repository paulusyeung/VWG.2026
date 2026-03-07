using System;
using System.Collections;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Gizmox.WebGUI.Forms.Skins;
using System.Drawing.Design;
using Gizmox.WebGUI.Forms.Client;
using System.Drawing;
using Gizmox.WebGUI.Common.Configuration;

namespace Gizmox.WebGUI.Forms
{
    #region Enums

    /// <summary>
    /// Defines TextBox events types
    /// </summary>
    public enum TextBoxEventTypes
    {
        None = 0,
        TextBoxRealTimeKeyDown = 1,
        TextBoxRealTimeKeyPress = 2,
        TextBoxRealTimeKeyUp = 4,
    }
    #endregion Enums

    /// <summary>
    /// Implements the basic functionality required by text controls.
    /// </summary>    
    [Skin(typeof(TextBoxBaseSkin))]
    [Serializable(), DefaultEvent("TextChanged")]
    public abstract class TextBoxBase : Control
    {

        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to SelectionLength property.
        /// </summary>
        private static SerializableProperty SelectionLengthProperty = SerializableProperty.Register("SelectionLength", typeof(int), typeof(TextBoxBase), new SerializablePropertyMetadata(0));

        /// <summary>
        /// Provides a property reference to AcceptsTab property.
        /// </summary>
        private static SerializableProperty AcceptsTabProperty = SerializableProperty.Register("AcceptsTab", typeof(bool), typeof(TextBoxBase), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to WordWrap property.
        /// </summary>
        private static SerializableProperty WordWrapProperty = SerializableProperty.Register("WordWrap", typeof(bool), typeof(TextBoxBase), new SerializablePropertyMetadata(true));

        /// <summary>
        /// Provides a property reference to Multiline property.
        /// </summary>
        private static SerializableProperty MultilineProperty = SerializableProperty.Register("Multiline", typeof(bool), typeof(TextBoxBase), new SerializablePropertyMetadata(false));

        /// <summary>
        /// Provides a property reference to MaxLength property.
        /// </summary>
        private static SerializableProperty MaxLengthProperty = SerializableProperty.Register("MaxLength", typeof(int), typeof(TextBoxBase), new SerializablePropertyMetadata(0));

        /// <summary>
        /// Provides a property reference to SelectionStart property.
        /// </summary>
        private static SerializableProperty SelectionStartProperty = SerializableProperty.Register("SelectionStart", typeof(int), typeof(TextBoxBase), new SerializablePropertyMetadata(0));

        /// <summary>
        /// Provides a property reference to HideSelection property.
        /// </summary>
        private static SerializableProperty HideSelectionProperty = SerializableProperty.Register("HideSelection", typeof(bool), typeof(TextBoxBase), new SerializablePropertyMetadata(true));

        /// <summary>
        /// 
        /// </summary>
        private static SerializableProperty IsAutoCompleteProperty = SerializableProperty.Register("IsAutoComplete", typeof(bool), typeof(TextBoxBase), new SerializablePropertyMetadata(true));

#endregion Serializable Properties

        #region Methods

        #region Events

        /// <summary>
        /// Gets the key event captures.
        /// </summary>
        /// <returns></returns>
        protected override KeyCaptures GetKeyEventCaptures()
        {
            KeyCaptures enmKeyCaptures = base.GetKeyEventCaptures();
            enmKeyCaptures |= KeyCaptures.UpKeyCapture;
            enmKeyCaptures |= KeyCaptures.DownKeyCapture;
            enmKeyCaptures |= KeyCaptures.RightKeyCapture;
            enmKeyCaptures |= KeyCaptures.LeftKeyCapture;
            enmKeyCaptures |= KeyCaptures.EnterKeyCapture;
            enmKeyCaptures |= KeyCaptures.HomeKeyCapture;
            enmKeyCaptures |= KeyCaptures.EndKeyCapture;
            return enmKeyCaptures;
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            // Select event type
            switch (objEvent.Type)
            {
                case "ValueChange":

                    // Do not exept changes in read only mode
                    if (!this.ReadOnly)
                    {
                        // Set the current text value                     
                        InternalText = CommonUtils.DecodeText(objEvent[WGAttributes.Text]);

                        // If RealTimeKeyboardEvents, force validation to push update down through any databindings
                        if (this.WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents)
                        {
                            this.OnValidating(new CancelEventArgs());
                            this.OnValidated(EventArgs.Empty);
                        }
                    }
                    break;

                case "SelectionChanged":
                    if (objEvent.Contains(WGAttributes.SelectionStart))
                    {
                        this.SetValue<int>(TextBoxBase.SelectionStartProperty, Int32.Parse(objEvent[WGAttributes.SelectionStart]));
                    }

                    if (objEvent.Contains(WGAttributes.SelectionLength))
                    {
                        this.SetValue<int>(TextBoxBase.SelectionLengthProperty, Int32.Parse(objEvent[WGAttributes.SelectionLength]));
                    }
                    break;
                case "TextBoxRealTimeKeyDown":
                    FireKeyDown(objEvent);

                      break;
                case "TextBoxRealTimeKeyPress":
                    // KeyPress will fire on character type keys (keys that will produce a character), not
                    // functional keys, like ESC, TAB, Shift etc. For that type of keys, only KeyDown and KeyUp
                    // will fire.
                    FireKeyPress(objEvent);
                    break;
                case "TextBoxRealTimeKeyUp":

                    FireKeyUp(objEvent);
                    break;

                default:
                    base.FireEvent(objEvent);
                    break;
            }
        }

        /// <summary>
        /// Gets the keys.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        /// <returns></returns>
        private Keys GetKeys(IEvent objEvent)
        {
            // Parse the key down event key code.
            Keys enmKeys = objEvent.KeyCode;

            // Check if the alt key was pressed.
            if (objEvent.AltKey)
            {
                enmKeys |= Keys.Alt;
            }

            // Check if the control key was pressed.
            if (objEvent.ControlKey)
            {
                enmKeys |= Keys.Control;
            }

            // Check if the shift key was pressed.
            if (objEvent.ShiftKey)
            {
                enmKeys |= Keys.Shift;
            }

            return enmKeys;
        }

        /// <summary>
        /// Fires the key down event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        private void FireKeyDown(IEvent objEvent)
        {
            // Raise key down event
            OnKeyDown(new KeyEventArgs(this.GetKeys(objEvent)));
        }

        /// <summary>
        /// Fires the key press.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        private void FireKeyPress(IEvent objEvent)
        {
            Keys enmKeys = this.GetKeys(objEvent);

            // Raise key press event
            OnKeyPress(new KeyPressEventArgs((char)enmKeys));
        }


        /// <summary>
        /// Fires the key up.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        private void FireKeyUp(IEvent objEvent)
        {
            Keys enmKeys = this.GetKeys(objEvent);

            // Raise key up event
            OnKeyUp(new KeyEventArgs(enmKeys));
        }


        /// <summary>
        /// Get flag to state the criticality of keyboard events.
        /// </summary>
        /// <returns></returns>
        private TextBoxEventTypes GetTextBoxCriticalKeyEvents()
        {
            TextBoxEventTypes enmEventTypes = TextBoxEventTypes.None;

            if (base.KeyDownHandler != null)
                enmEventTypes |= TextBoxEventTypes.TextBoxRealTimeKeyDown;
            if (base.KeyPressHandler != null)
                enmEventTypes |= TextBoxEventTypes.TextBoxRealTimeKeyPress;
            if (base.KeyUpHandler != null)
                enmEventTypes |= TextBoxEventTypes.TextBoxRealTimeKeyUp;
            return enmEventTypes;
        }


        /// <summary>
        /// Occurs when [client value changed].
        /// </summary>
        [SRDescription("Occurs when control's text changed in client mode."), Category("Client")]
        public event ClientEventHandler ClientTextChanged
        {
            add
            {
                this.AddClientHandler("ValueChange", value);
            }
            remove
            {
                this.RemoveClientHandler("ValueChange", value);
            }
        }

        /// <summary>
        /// Gets the critical client events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();
            if (this.HasClientHandler("ValueChange"))
            {
                objEvents.Set(WGEvents.ValueChange);
            }

            return objEvents;
        }

        #endregion

        #region Render

        /// <summary>
        /// Renders the current control attributes.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter">The response writer object.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Get MaxLength property
            int intMaxLength = this.MaxLength;

            // If other than default (0), render it.
            if (intMaxLength != 0)
            {
                objWriter.WriteAttributeString(WGAttributes.MaxLength, intMaxLength.ToString());
            }

            // Get ReadOnly property, If other than default (false), render it.
            if (this.ReadOnly)
            {
                objWriter.WriteAttributeString(WGAttributes.ReadOnly, "1");
            }

            // Get WordWrap property, If other than default (true), render it.
            if (!this.WordWrap)
            {
                objWriter.WriteAttributeString(WGAttributes.WordWrap, "0");
            }

            RenderValue(objContext, objWriter, false);

            // Get Multiline property, If other than default (false), render it.
            if (this.Multiline)
            {
                // Get AcceptsTab property, If other than default (false), render it.
                if (this.AcceptsTab)
                {
                    objWriter.WriteAttributeString(WGAttributes.AcceptsTab, "1");
                }
                objWriter.WriteAttributeString(WGAttributes.Multiline, "1");
            }
            //AutoCompleteMode
            RenderIsAutoCompleteAttribute(objWriter, false);

            //Render attribute indicating synchronize TextBox events or not
            if (this.WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents)
            {
                objWriter.WriteAttributeString(WGAttributes.TextBoxRealTimeKeyboardEvents, this.WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents ? "1" : "0");
                RenderTextboxKeyEventsAttributes(objWriter, false);
            }
        }

        /// <summary>
        /// Renders the standard textbox key events attributes.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderTextboxKeyEventsAttributes(IAttributeWriter objWriter, bool blnForceRender)
        {
            int intEvents = (int)GetTextBoxCriticalKeyEvents();

            if (intEvents != 0 || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.TextBoxRealTimeKeyEvents, intEvents.ToString());
            }
        }

        /// <summary>
        /// Renders the is auto complete attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderIsAutoCompleteAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            bool blnIsAutoComplete = this.IsAutoComplete;

            if (!blnIsAutoComplete || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.IsAutoComplete, blnIsAutoComplete ? "1" : "0");
            }

        }

        /// <summary>
        /// Render control params
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter">The response writer object.</param>
        /// <param name="lngRequestID">Request ID.</param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            // Render base params
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);

            // Check if is control params dirty
            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                RenderValue(objContext, objWriter, true);
                objWriter.WriteAttributeString(WGAttributes.ReadOnly, this.ReadOnly ? "1" : "0");

                RenderIsAutoCompleteAttribute(objWriter, true);
            }

            if (this.WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents && this.IsDirtyAttributes(lngRequestID, AttributeType.Events))
            {
                RenderTextboxKeyEventsAttributes(objWriter, true);
            }
        }

        ///// <summary>
        ///// Gets the critical events.
        ///// </summary>
        ///// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            if (this.WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents)
            {
                // Cancel criticality of default KeyDown handler registration - we use our own
                CriticalEventsData objEvents = base.GetCriticalEventsData();
                objEvents.Unset(WGEvents.KeyDown);

                return objEvents;
            }
            return base.GetCriticalEventsData();
        }

        /// <summary>
        /// Renders the value.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected abstract void RenderValue(IContext objContext, IAttributeWriter objWriter, bool blnForceRender);

        #endregion Render

        /// <summary>
        /// Clears all text from the text box control.
        /// </summary>
        public void Clear()
        {
            this.Text = "";
        }

        /// <summary>
        /// Copies the current selection in the text box to the Clipboard.
        /// </summary>
        public void Copy()
        {
            Clipboard.SetText(this.GetClipboardContent(), TextDataFormat.UnicodeText);
        }

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
        public void Paste()
        {
            this.SetClipboardContent(Clipboard.GetText(TextDataFormat.UnicodeText));
        }

        /// <summary>
        /// Sets the content of the clipboard.
        /// </summary>
        /// <param name="strValue">The STR value.</param>
        protected virtual void SetClipboardContent(string strValue)
        {

        }

        /// <summary>
        /// Gets the content of the clipboard.
        /// </summary>
        /// <returns></returns>
        protected virtual string GetClipboardContent()
        {
            return "";
        }

        /// <summary>Selects all text in the text box.</summary>
        public void SelectAll()
        {
            this.Select(0, this.TextLength);
        }

        /// <summary>Scrolls the contents of the control to the current caret position.</summary>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void ScrollToCaret()
        {
            if (this.Multiline)
            {
                base.InvokeMethodWithId("TextBox_Execute", "ScrollToCaret");
            }
        }

        /// <summary>Selects a range of text in the text box.</summary>
        /// <param name="intStart">The position of the first character in the current text selection within the text box. </param>
        /// <param name="intLength">The number of characters to select. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the start parameter is less than zero.</exception>
        public void Select(int intStart, int intLength)
        {
            // Set the new se;lection values
            this.SetValue<int>(TextBoxBase.SelectionLengthProperty, intLength);
            this.SetValue<int>(TextBoxBase.SelectionStartProperty, intStart);

            // Invoke the client Selection itself
            InvokeSelection(intStart, intLength);
        }

        /// <summary>Appends text to the current text of a text box.</summary>
        /// <param name="strText">The text to append to the current contents of the text box. </param>
        public void AppendText(string strText)
        {
            if (strText.Length > 0)
            {
                this.Text = string.Format("{0}{1}", this.Text, strText);
            }
        }

        /// <summary>
        /// Sets the selected text internal.
        /// </summary>
        /// <param name="strText">The text.</param>
        /// <param name="blnClearUndo">if set to <c>true</c> [clear undo].</param>
        internal virtual void SetSelectedTextInternal(string strText, bool blnClearUndo)
        {
            // Get selection start position and length
            int intSelectionStart = this.SelectionStart;
            int intSelectionLength = this.SelectionLength;

            // Set sub-strings to concat later
            string strBefore = this.Text.Substring(0, intSelectionStart);
            string strAfter = this.Text.Substring(intSelectionStart + intSelectionLength, this.TextLength - (intSelectionStart + intSelectionLength));

            // concat the subString to create the new string and set it.
            this.Text = string.Format("{0}{1}{2}", strBefore, strText, strAfter);
        }

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <returns></returns>
        protected override WinFormsCompatibility GetWinFormsCompatibility()
        {
            return new TextBoxBaseWinFormsCompatibility();
        }

        /// <summary>
        /// Called when WinFormsCompatibility option value is changed.
        /// </summary>
        protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
        {
            if (strChangedOptionName == WinFormsCompatibilityPredefinedOptions.TextBoxRealTimeKeyboardEvents)
            {
                // We need to update the whole control.
                this.Update();
            }

            base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this instance is auto complete.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is auto complete; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]
        public bool IsAutoComplete
        {
            get
            {
                return this.GetValue<bool>(TextBoxBase.IsAutoCompleteProperty);
            }
            set
            {
                if (this.SetValue<bool>(TextBoxBase.IsAutoCompleteProperty, value))
                {
                    this.UpdateParams(AttributeType.Control);
                }
            }

        }

        /// <summary>Gets the length of text in the control.</summary>
        /// <returns>The number of characters contained in the text of the control.</returns>
        [Browsable(false)]
        public virtual int TextLength
        {
            get
            {
                return this.Text.Length;
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value></value>
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#else
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
#endif
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        /// <summary>Gets or sets a value indicating the currently selected text in the control.</summary>
        /// <returns>A string that represents the currently selected text in the text box.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRCategory("CatAppearance"), SRDescription("TextBoxSelectedTextDescr"), Browsable(false)]
        public virtual string SelectedText
        {
            get
            {
                if (this.Text == null)
                {
                    return "";
                }
                else
                {
                    return this.Text.Substring(this.SelectionStart, this.SelectionLength);
                }
            }
            set
            {
                this.SetSelectedTextInternal(value, true);
            }
        }

        /// <summary>Gets or sets the number of characters selected in the text box.</summary>
        /// <returns>The number of characters selected in the text box.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is less than zero.</exception>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRDescription("TextBoxSelectionLengthDescr"), SRCategory("CatAppearance"), Browsable(false)]
        public virtual int SelectionLength
        {
            get
            {
                return this.GetValue<int>(TextBoxBase.SelectionLengthProperty);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("SelectionLength", SR.GetString("InvalidArgument", new object[] { "SelectionLength", value.ToString(CultureInfo.CurrentCulture) }));
                }
                // Set the value.   
                if (this.SetValue<int>(TextBoxBase.SelectionLengthProperty, value))
                {
                    // If the value has changed, invoke the client selection.
                    this.InvokeSelection(this.SelectionStart, value);
                }
            }
        }

        /// <summary>Gets or sets the starting point of text selected in the text box.</summary>
        /// <returns>The starting position of text selected in the text box.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is less than zero.</exception>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), SRCategory("CatAppearance"), SRDescription("TextBoxSelectionStartDescr")]
        public int SelectionStart
        {
            get
            {
                return this.GetValue<int>(TextBoxBase.SelectionStartProperty);
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("SelectionStart", SR.GetString("InvalidArgument", new object[] { "SelectionStart", value.ToString(CultureInfo.CurrentCulture) }));
                }
                // Set the value.   
                if (this.SetValue<int>(TextBoxBase.SelectionStartProperty, value))
                {
                    // If the value has changed, invoke the client selection.
                    this.InvokeSelection(value, this.SelectionLength);
                }
            }
        }

        /// <summary>
        /// Gets or sets the maximum number of characters the user can type or paste into the text box control.
        /// </summary>
        /// <value>
        /// The number of characters that can be entered into the control. The default is 0.
        /// </value>
        [Localizable(true), SRDescription("TextBoxMaxLengthDescr"), DefaultValue(0), SRCategory("CatBehavior")]
        public virtual int MaxLength
        {
            get
            {
                return this.GetValue<int>(TextBoxBase.MaxLengthProperty);
            }
            set
            {
                if (this.SetValue<int>(TextBoxBase.MaxLengthProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [read only].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [read only]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), RefreshProperties(RefreshProperties.Repaint), SRCategory("CatBehavior"), SRDescription("TextBoxReadOnlyDescr")]
        public bool ReadOnly
        {
            get
            {
                return this.GetState(ComponentState.ReadOnly);
            }
            set
            {
                // Set the readonly state and update control if value has changed
                if (this.SetStateWithCheck(ComponentState.ReadOnly, value))
                {
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether text box is multi line.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if multi line otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), SRDescription("TextBoxMultilineDescr"), Localizable(true), SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.All)]
        public virtual bool Multiline
        {
            get
            {
                return this.GetValue<bool>(TextBoxBase.MultilineProperty);
            }
            set
            {
                if (this.SetValue<bool>(TextBoxBase.MultilineProperty, value))
                {
                    this.Update();
                }
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
                int intNum2;
                string strText = this.Text;
                ArrayList objList = new ArrayList();
                for (int intNum1 = 0; intNum1 < strText.Length; intNum1 = intNum2)
                {
                    intNum2 = intNum1;
                    while (intNum2 < strText.Length)
                    {
                        char ch1 = strText[intNum2];
                        if ((ch1 == '\r') || (ch1 == '\n'))
                        {
                            break;
                        }
                        intNum2++;
                    }
                    string strText2 = strText.Substring(intNum1, intNum2 - intNum1);
                    objList.Add(strText2);
                    if ((intNum2 < strText.Length) && (strText[intNum2] == '\r'))
                    {
                        intNum2++;
                    }
                    if ((intNum2 < strText.Length) && (strText[intNum2] == '\n'))
                    {
                        intNum2++;
                    }
                }
                if ((strText.Length > 0) && ((strText[strText.Length - 1] == '\r') || (strText[strText.Length - 1] == '\n')))
                {
                    objList.Add("");
                }
                return (string[])objList.ToArray(typeof(string));
            }
            set
            {
                if ((value != null) && (value.Length > 0))
                {
                    StringBuilder objStringBuilder = new StringBuilder(value[0]);
                    for (int intNum1 = 1; intNum1 < value.Length; intNum1++)
                    {
                        objStringBuilder.Append("\r\n");
                        objStringBuilder.Append(value[intNum1]);
                    }
                    this.Text = objStringBuilder.ToString();
                }
                else
                {
                    this.Text = "";
                }
            }
        }

        /// <summary>
        /// Indicates whether a multiline text box control automatically wraps words to the beginning of the next line when necessary.
        /// </summary>
        /// <value>
        /// true if the multiline text box control wraps words; false if the text box control automatically scrolls horizontally when the user types past the right edge of the control. The default is true.
        /// </value>
        [System.ComponentModel.DefaultValue(true)]
        public virtual bool WordWrap
        {
            get
            {
                return this.GetValue<bool>(TextBoxBase.WordWrapProperty);
            }
            set
            {
                if (this.SetValue<bool>(TextBoxBase.WordWrapProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether pressing the TAB key in a multiline text box control types a TAB character in the control instead of moving the focus to the next control in the tab order 
        /// </summary>
        [DefaultValue(false), SRDescription("Gets or sets a value indicating whether pressing the TAB key in a multiline text box control types a TAB character in the control instead of moving the focus to the next control in the tab order."), Localizable(true), SRCategory("CatBehavior"), RefreshProperties(RefreshProperties.All)]
        public virtual bool AcceptsTab
        {
            get
            {
                return this.GetValue<bool>(TextBoxBase.AcceptsTabProperty);
            }
            set
            {
                if (this.SetValue<bool>(TextBoxBase.AcceptsTabProperty, value))
                {
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the control padding.
        /// </summary>
        /// <value></value>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override Padding Padding
        {
            get
            {
                return base.Padding;
            }
            set
            {
                base.Padding = value;
            }
        }


        /// <summary>
        /// Gets a value indicating whether raise click event on mouse down.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if should raise click event on mouse down; otherwise, <c>false</c>.
        /// </value>
        protected override bool ShouldRaiseClickOnRightMouseDown
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [hide selection].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [hide selection]; otherwise, <c>false</c>.
        /// </value>        
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool HideSelection
        {
            get
            {
                return this.GetValue<bool>(TextBoxBase.HideSelectionProperty);
            }
            set
            {
                this.SetValue<bool>(TextBoxBase.HideSelectionProperty, value);
            }
        }

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <value>
        /// The win forms compatibility.
        /// </value>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new TextBoxBaseWinFormsCompatibility WinFormsCompatibility
        {
            get
            {
                return base.WinFormsCompatibility as TextBoxBaseWinFormsCompatibility;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is server events synchronized.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is server events synchronized; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false), SRCategory("CatBehavior"), SRDescription("Determines whether the keyboard events should fire in the WinForms compatible mode.")]
        [Browsable(false)]
        [Obsolete("This property is obsolete. Use WinFormsCompatibility property instead.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool RealTimeKeyboardEvents
        {
            get
            {
                return this.WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents;
            }
            set
            {
                this.WinFormsCompatibility.TextBoxRealTimeKeyboardEvents = value ? WinFormsCompatibilityStates.True : WinFormsCompatibilityStates.False;
            }
        }

        #endregion Properties
    }


}
