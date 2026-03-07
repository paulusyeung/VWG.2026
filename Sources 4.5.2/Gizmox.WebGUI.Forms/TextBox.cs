#region Using

using System;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;
using System.Globalization;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Common.Configuration;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region TextBoxValidation Class

    /// <summary>
    ///
    /// </summary>
    [Serializable()]
    public class TextBoxValidation
    {
        #region Class Members

        private string mstrInValidateMessage = string.Empty;

        private string mstrValueValidationExpression = string.Empty;

        private string mstrCharacterValidationMask = string.Empty;

        private string mstrCharacterValidationExpression = string.Empty;

        #endregion Class Members

        #region C'Tor\D'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxValidation"/> class.
        /// </summary>
        /// <param name="strValueValidationExpression">The value validation expression.</param>
        /// <param name="strInValidateMessage">The in validate message.</param>
        public TextBoxValidation(string strValueValidationExpression, string strInValidateMessage)
        {
            mstrValueValidationExpression = strValueValidationExpression;
            mstrInValidateMessage = strInValidateMessage;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxValidation"/> class.
        /// </summary>
        /// <param name="strValueValidationExpression">The value validation expression.</param>
        /// <param name="strInValidateMessage">The in validate message.</param>
        /// <param name="strCharacterValidationMask">The character validation mask.</param>
        public TextBoxValidation(string strValueValidationExpression, string strInValidateMessage, string strCharacterValidationMask)
            : this(strValueValidationExpression, strInValidateMessage)
        {
            mstrCharacterValidationMask = strCharacterValidationMask;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxValidation"/> class.
        /// </summary>
        /// <param name="strValueValidationExpression">The value validation expression.</param>
        /// <param name="strInValidateMessage">The in validate message.</param>
        /// <param name="strCharacterValidationMask">The character validation mask.</param>
        /// <param name="strCharacterValidationExpression">The character validation expression.</param>
        public TextBoxValidation(string strValueValidationExpression, string strInValidateMessage, string strCharacterValidationMask, string strCharacterValidationExpression)
            : this(strValueValidationExpression, strInValidateMessage, strCharacterValidationMask)
        {
            mstrCharacterValidationExpression = strCharacterValidationExpression;
        }

        #endregion C'Tor\D'Tor

        #region Properties

        /// <summary>
        /// Gets the decimal separator.
        /// </summary>
        /// <value>The decimal separator.</value>
        private static string DecimalSeparator
        {
            get
            {
                return Global.Context.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator;
            }
        }

        /// <summary>
        /// Gets or sets the character validation expression.
        /// </summary>
        /// <value>The character validation expression.</value>
        public string CharacterValidationExpression
        {
            get
            {
                return mstrCharacterValidationExpression;
            }
            set
            {
                mstrCharacterValidationExpression = value;
            }
        }

        /// <summary>
        /// Gets the validator expression.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Obsolete("This property is no lnoger exists - please use the 'ValueValidationExpression' property instead.")]
        public string Expression
        {
            get
            {
                return mstrValueValidationExpression;
            }
        }

        /// <summary>
        /// Gets the value validation expression.
        /// </summary>
        /// <value>The value validation expression.</value>
        public string ValueValidationExpression
        {
            get
            {
                return mstrValueValidationExpression;
            }
        }

        /// <summary>
        /// Gets the validator charecter mask (Example: "0-9" or "a-zA-Z0-9@.").
        /// </summary>
        /// <value></value>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Obsolete("This property is no lnoger exists - please use the 'CharacterValidationMask' property instead.")]
        public string Mask
        {
            get
            {
                return mstrCharacterValidationMask;
            }
        }

        /// <summary>
        /// Gets the character validation mask.
        /// </summary>
        /// <value>The character validation mask.</value>
        public string CharacterValidationMask
        {
            get
            {
                return mstrCharacterValidationMask;
            }
        }

        /// <summary>
        /// Gets the validator invalid message.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [Obsolete("This property is no lnoger exists - please use the 'InValidateMessage' property instead.")]
        public string Message
        {
            get
            {
                return mstrInValidateMessage;
            }
        }

        /// <summary>
        /// Gets the in validate message.
        /// </summary>
        /// <value>The in validate message.</value>
        public string InValidateMessage
        {
            get
            {
                return mstrInValidateMessage;
            }
        }

        #endregion Properties

        #region Predefined Validators

        /// <summary>
        /// Gets an integer validator.
        /// </summary>
        /// <value></value>
        public static TextBoxValidation IntegerValidator
        {
            get
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentUICulture;

                if (Global.Context != null &&
                    Global.Context.CurrentUICulture != null)
                {
                    objCultureInfo = Global.Context.CurrentUICulture;
                }

                return new TextBoxValidation("String(value).match(/^-{0,1}[0-9]*$/)", SR.GetString(objCultureInfo, "WGLablesIntegerRequiered"), "0-9\\-|\\x1B");
            }
        }

        /// <summary>
        /// Gets an integer mask validator.
        /// </summary>
        /// <value></value>
        public static TextBoxValidation IntegerMaskValidator
        {
            get
            {
                return new TextBoxValidation("", "", "0-9\\-|\\x1B");
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="intMinValue"></param>
        /// <param name="intMaxValue"></param>
        public static TextBoxValidation CreateIntegerValidator(int intMinValue, int intMaxValue)
        {
            CultureInfo objCultureInfo = CultureInfo.CurrentUICulture;

            if (Global.Context != null &&
                Global.Context.CurrentUICulture != null)
            {
                objCultureInfo = Global.Context.CurrentUICulture;
            }

            return new TextBoxValidation(String.Format("String(value).match(/^[0-9]*$/)&& (value>={0} && value<={1})", intMinValue, intMaxValue),
                SR.GetString(objCultureInfo, "WGLablesIntegerRangeRequiered", new object[] { intMinValue, intMaxValue }), "0-9|\\x1B");
        }

        /// <summary>
        /// Gets an floating point number validator.
        /// </summary>
        /// <value></value>
        public static TextBoxValidation FloatValidator
        {
            get
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentUICulture;

                if (Global.Context != null &&
                    Global.Context.CurrentUICulture != null)
                {
                    objCultureInfo = Global.Context.CurrentUICulture;
                }

                return new TextBoxValidation(string.Concat("String(value).match(/^-{0,1}[0-9]*([", TextBoxValidation.DecimalSeparator, "][0-9]+){0,1}$/)"), SR.GetString(objCultureInfo, "WGLablesFloatRequiered"), string.Concat("0-9\\", TextBoxValidation.DecimalSeparator, "\\|\\x1B"));

            }
        }

        /// <summary>
        /// Gets an floating point number mask validator.
        /// </summary>
        /// <value></value>
        public static TextBoxValidation FloatMaskValidator
        {
            get
            {
                return new TextBoxValidation("", "", string.Concat("0-9\\", TextBoxValidation.DecimalSeparator, "\\|\\x1B"));
            }
        }

        /// <summary>
        /// Gets an code mask validator.
        /// </summary>
        /// <value></value>
        public static TextBoxValidation CodeMaskValidator
        {
            get
            {
                return new TextBoxValidation("", "", "a-zA-Z0-9_|\\x1B");
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="intMinValue"></param>
        /// <param name="intMaxValue"></param>
        public static TextBoxValidation CreateFloatValidator(double intMinValue, double intMaxValue)
        {
            CultureInfo objCultureInfo = CultureInfo.CurrentUICulture;

            if (Global.Context != null &&
                Global.Context.CurrentUICulture != null)
            {
                objCultureInfo = Global.Context.CurrentUICulture;
            }

            return new TextBoxValidation(String.Format("(value>={0} && value<={1})", intMinValue, intMaxValue),
                SR.GetString(objCultureInfo, "WGLablesFloatRangeRequiered", new object[] { intMinValue, intMaxValue }));

        }

        /// <summary>
        /// Gets an email validator.
        /// </summary>
        /// <value></value>
        public static TextBoxValidation EmailValidator
        {
            get
            {
                CultureInfo objCultureInfo = CultureInfo.CurrentUICulture;

                if (Global.Context != null &&
                    Global.Context.CurrentUICulture != null)
                {
                    objCultureInfo = Global.Context.CurrentUICulture;
                }

                string strEmailRegex = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@" +
                                        @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\." +
                                        @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|" +
                                        @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

                return new TextBoxValidation(string.Format("String(value).match(/{0}/)", strEmailRegex), SR.GetString(objCultureInfo, "WGLablesEmailRequiered"));
            }
        }

        #endregion Predefined Validators
    }

    #endregion TextBoxValidation Class

    #region TextBox Class

    /// <summary>
    /// Implementation of TextBox class.
    /// </summary>
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(TextBox), "TextBox_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(TextBox), "TextBox.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TextBoxController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TextBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TextBoxController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TextBoxController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TextBoxController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TextBoxController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TextBoxController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TextBoxController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TextBoxController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.TextBoxController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.TextBoxController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [System.ComponentModel.ToolboxItem(true)]
    [Serializable()]
    [ToolboxItemCategory("Common Controls")]
    [MetadataTag(WGTags.TextBox)]
    [Skin(typeof(TextBoxSkin))]
    public class TextBox : TextBoxBase
    {
        #region Class Members

        #region Serializable Properties

        /// <summary>
        /// Provides a property reference to CharacterCasing property.
        /// </summary>
        private static SerializableProperty CharacterCasingProperty = SerializableProperty.Register("CharacterCasing", typeof(CharacterCasing), typeof(TextBox));

        /// <summary>
        /// Provides a property reference to Validator property.
        /// </summary>
        private static SerializableProperty ValidatorProperty = SerializableProperty.Register("Validator", typeof(TextBoxValidation), typeof(TextBox));

        /// <summary>
        /// Provides a property reference to PasswordChar property.
        /// </summary>
        private static SerializableProperty PasswordCharProperty = SerializableProperty.Register("PasswordChar", typeof(char), typeof(TextBox));

        /// <summary>
        /// Provides a property reference to UseSystemPasswordChar property.
        /// </summary>
        private static SerializableProperty UseSystemPasswordCharProperty = SerializableProperty.Register("UseSystemPasswordChar", typeof(bool), typeof(TextBox));

        /// <summary>
        /// Provides a property reference to ScrollBars property.
        /// </summary>
        private static SerializableProperty ScrollBarsProperty = SerializableProperty.Register("ScrollBars", typeof(ScrollBars), typeof(TextBox));

        /// <summary>
        /// Provides a property reference to HorizontalAlignment property.
        /// </summary>
        private static SerializableProperty HorizontalAlignmentProperty = SerializableProperty.Register("HorizontalAlignment", typeof(HorizontalAlignment), typeof(TextBox));

        #endregion Serializable Properties

        /// <summary>
        /// Gets the hanlder for the EnterKeyDown event.
        /// </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        protected KeyEventHandler EnterKeyDownHandler
        {
            get
            {
                return (KeyEventHandler)this.GetHandler(TextBox.EnterKeyDownEvent);
            }
        }

        /// <summary>
        /// The EnterKeyDown event registration.
        /// </summary>
        private static readonly SerializableEvent EnterKeyDownEvent = SerializableEvent.Register("EnterKeyDown", typeof(KeyEventHandler), typeof(TextBox));


        /// <summary>
        /// Occurs on enter key down only on single line.
        /// </summary>
        public event KeyEventHandler EnterKeyDown
        {
            add
            {
                this.AddCriticalHandler(TextBox.EnterKeyDownEvent, value);
            }
            remove
            {
                this.RemoveCriticalHandler(TextBox.EnterKeyDownEvent, value);
            }
        }

        /// <summary>
        /// Occurs when [client enter key down].
        /// </summary>
        [SRDescription("Occurs when enter key pressed in client mode."), Category("Client")]
        public event ClientEventHandler ClientEnterKeyDown
        {
            add
            {
                this.AddClientHandler("EnterKeyDown", value);
            }
            remove
            {
                this.RemoveClientHandler("EnterKeyDown", value);
            }
        }

        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
        /// Creates a new <see cref="TextBox"/> instance.
        /// </summary>
        public TextBox()
        {

        }

        #endregion C'Tor/D'Tor

        #region Methods

        /// <summary>
        /// Formats the text.
        /// </summary>
        /// <param name="strValue">The text value.</param>
        /// <returns></returns>
        private string FormatText(string strValue)
        {
            // If there is a valid value 
            if (!string.IsNullOrEmpty(strValue))
            {
                // Select the charecter casing
                switch (this.CharacterCasing)
                {
                    case CharacterCasing.Lower:
                        // Return a lower cased value
                        return strValue.ToLowerInvariant();
                    case CharacterCasing.Upper:
                        // Return a upper cased value
                        return strValue.ToUpperInvariant();
                }
            }

            // Return the value
            return strValue;
        }

        /// <summary>
        /// Set the value from the clip board
        /// </summary>
        /// <param name="strValue"></param>
        protected override void SetClipboardContent(string strValue)
        {
            this.SelectedText = strValue;
        }

        /// <summary>
        /// Get content to be added to the clip board 
        /// </summary>
        /// <returns></returns>
        protected override string GetClipboardContent()
        {
            return this.SelectedText;
        }

        /// <summary>Undoes the last edit operation in the text box.</summary>
        public void Undo()
        {

        }

        /// <summary>
        /// Implements the actual client side selection
        /// </summary>
        /// <param name="intStart"></param>
        /// <param name="intLength"></param>
        protected override void InvokeSelection(int intStart, int intLength)
        {
            this.InvokeMethodWithId("TextBox_Execute", "Select", intStart, intLength);
        }

        /// <summary>
        /// Renders the current control attributes.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter">The response writer object.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            TextBoxValidation objTextBoxValidation = null;

            base.RenderAttributes(objContext, objWriter);

            HorizontalAlignment enmHorizontalAlignment = this.GetProxyPropertyValue<HorizontalAlignment>("TextAlign", this.TextAlign);

            if (enmHorizontalAlignment != HorizontalAlignment.Left)
            {
                objWriter.WriteAttributeString(WGAttributes.TextAlign, enmHorizontalAlignment.ToString());
            }

            // If there is a password char or use system password char definition
            if (this.PasswordChar != '\0' || this.UseSystemPasswordChar)
            {
                objWriter.WriteAttributeString(WGAttributes.Password, "1");
            }

            objTextBoxValidation = Validator;

            if (objTextBoxValidation != null)
            {
                if (objTextBoxValidation.ValueValidationExpression != string.Empty)
                {
                    objWriter.WriteAttributeString(WGAttributes.ValueValidationExpression, objTextBoxValidation.ValueValidationExpression);
                }

                if (objTextBoxValidation.CharacterValidationMask != string.Empty)
                {
                    objWriter.WriteAttributeString(WGAttributes.CharacterValidationMask, objTextBoxValidation.CharacterValidationMask);
                }

                if (objTextBoxValidation.CharacterValidationExpression != string.Empty)
                {
                    objWriter.WriteAttributeString(WGAttributes.CharacterValidationExpression, objTextBoxValidation.CharacterValidationExpression);
                }

                if (objTextBoxValidation.InValidateMessage != string.Empty)
                {
                    objWriter.WriteAttributeText(WGAttributes.InValidateMessage, objTextBoxValidation.InValidateMessage);
                }
            }

            CharacterCasing objCharacterCasing = CharacterCasing;
            if (objCharacterCasing != CharacterCasing.Normal)
            {
                objWriter.WriteAttributeString(WGAttributes.CharacterCasing, ((Byte)objCharacterCasing).ToString());
            }

            if (this.Multiline && this.ScrollBars != ScrollBars.None)
            {
                objWriter.WriteAttributeString(WGAttributes.Scrollbars, Convert.ToInt32(this.ScrollBars).ToString());
            }

            objWriter.WriteAttributeString(WGAttributes.GrayedReadOnlyTextBox, this.WinFormsCompatibility.IsGrayedReadOnlyTextBox ? "1" : "0");
        }

        /// <summary>
        /// Render control params
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter">The response writer object.</param>
        /// <param name="lngRequestID">Request ID.</param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);

            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                objWriter.WriteAttributeString(WGAttributes.GrayedReadOnlyTextBox, this.WinFormsCompatibility.IsGrayedReadOnlyTextBox ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the value.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderValue(IContext objContext, IAttributeWriter objWriter, bool blnForceReder)
        {
            string strText = this.Text;

            if (!string.IsNullOrEmpty(strText) || blnForceReder)
            {
                objWriter.WriteAttributeText(WGAttributes.Value, strText, this.Multiline ? TextFilter.None : TextFilter.CarriageReturn | TextFilter.NewLine);
            }
        }

        /// <summary>
        /// Gets the control renderer.
        /// </summary>
        /// <returns></returns>
        protected override ControlRenderer GetControlRenderer()
        {
            return new TextBoxRenderer(this);
        }

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <returns></returns>
        protected override WinFormsCompatibility GetWinFormsCompatibility()
        {
            return new TextBoxWinFormsCompatibility();
        }

        /// <summary>
        /// Called when WinFormsCompatibility option value is changed.
        /// </summary>
        protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
        {
            if (strChangedOptionName == WinFormsCompatibilityPredefinedOptions.GrayedReadOnlyTextBox)
            {
                // Update control params.
                this.UpdateParams(AttributeType.Control);
            }
            
            base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();
            if (EnterKeyDownHandler != null) objEvents.Set(WGEvents.EnterKeyDown);
            return objEvents;
        }

        /// <summary>
        /// Gets the critical client events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalClientEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalClientEventsData();
            if (this.HasClientHandler("EnterKeyDown"))
            {
                objEvents.Set(WGEvents.EnterKeyDown);
            }

            return objEvents;
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

                case "EnterKeyDown":

                    if (EnterKeyDownHandler != null)
                    {
                        EnterKeyDownHandler(this, new KeyEventArgs(Keys.Enter));
                    }

                    break;

            }

            base.FireEvent(objEvent);
        }

        #endregion Events

        #region Properties

        /// <summary>Gets or sets how text is aligned in a <see cref="T:Gizmox.WebGUI.Forms.TextBox"></see> control.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> enumeration values that specifies how text is aligned in the control. The default is HorizontalAlignment.Left.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">A value that is not within the range of valid values for the enumeration was assigned to the property. </exception>
        /// <filterpriority>1</filterpriority>
        [System.ComponentModel.DefaultValue(HorizontalAlignment.Left), System.ComponentModel.Localizable(true), SRCategory("CatAppearance"), SRDescription("TextBoxTextAlignDescr"), ProxyBrowsable(true)]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return this.GetValue<HorizontalAlignment>(TextBox.HorizontalAlignmentProperty, HorizontalAlignment.Left);

            }
            set
            {
                if (this.TextAlign != value)
                {
                    this.SetValue<HorizontalAlignment>(TextBox.HorizontalAlignmentProperty, value);
                    Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the text associated with this control.
        /// </summary>
        /// <value></value>
        public override string Text
        {
            get
            {
                return this.FormatText(base.Text);
            }
            set
            {
                base.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether pressing ENTER in a multiline TextBox control creates a new line of text in the control or activates the default button for the form.
        /// </summary>
        [System.ComponentModel.DefaultValue(true)]
        public virtual bool AcceptsReturn
        {
            get
            {
                return true;
            }
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
        [System.ComponentModel.DefaultValue(ScrollBars.None), SRCategory("Style"), SRDescription("Scrollbar state definition")]
        public virtual ScrollBars ScrollBars
        {
            get
            {
                return this.GetValue<ScrollBars>(TextBox.ScrollBarsProperty, ScrollBars.None);
            }
            set
            {
                if (!value.GetType().Equals(ScrollBars.GetType()))
                    return;

                if (ScrollBars != value)
                {
                    this.SetValue<ScrollBars>(TextBox.ScrollBarsProperty, value);
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the password charecter.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue('\0'), SRCategory("CatBehavior"), SRDescription("TextBoxPasswordCharDescr")]
        public char PasswordChar
        {
            get
            {
                return this.GetValue<char>(TextBox.PasswordCharProperty, '\0');
            }
            set
            {
                // If the value is diffrent from the charecter
                if (this.PasswordChar != value)
                {
                    // If value is not the default one
                    if (value != '\0')
                    {
                        this.SetValue<char>(TextBox.PasswordCharProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<char>(TextBox.PasswordCharProperty);
                    }

                    // update to reflect changes
                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the text in the <see cref="T:System.Windows.Forms.TextBox"></see> control should appear as the default password character.</summary>
        /// <returns>true if the text in the <see cref="T:System.Windows.Forms.TextBox"></see> control should appear as the default password character; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [SRCategory("CatBehavior"), DefaultValue(false), SRDescription("TextBoxUseSystemPasswordCharDescr")]
        public bool UseSystemPasswordChar
        {
            get
            {
                return this.GetValue<bool>(TextBox.UseSystemPasswordCharProperty, false);
            }
            set
            {
                // If the value is diffrent from the charecter
                if (this.UseSystemPasswordChar != value)
                {
                    // If should use password property
                    if (value)
                    {
                        this.SetValue<bool>(TextBox.UseSystemPasswordCharProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<bool>(TextBox.UseSystemPasswordCharProperty);
                    }

                    // update to reflect changes
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the text box validator.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue(null)]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public TextBoxValidation Validator
        {
            get
            {
                return this.GetValue<TextBoxValidation>(TextBox.ValidatorProperty);
            }
            set
            {
                if (Validator != value)
                {
                    Update();
                    this.SetValue<TextBoxValidation>(TextBox.ValidatorProperty, value);
                }
            }
        }

        /// <summary>Gets a value indicating whether the user can undo the previous operation in a text box control.</summary>
        /// <returns>true if the user can undo the previous operation performed in a text box control; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), SRDescription("TextBoxCanUndoDescr"), System.ComponentModel.Browsable(false)]
        public bool CanUndo
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Indicates if all characters should be left alone or converted to uppercase or lowercase
        /// </summary>
        /// <value></value>
        [SRCategory("CatBehavior"), SRDescription("TextBoxCharacterCasingDescr"), DefaultValue(CharacterCasing.Normal)]
        public CharacterCasing CharacterCasing
        {
            get
            {
                return this.GetValue<CharacterCasing>(TextBox.CharacterCasingProperty, CharacterCasing.Normal);
            }
            set
            {
                if (this.CharacterCasing != value)
                {
                    if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
                    {
                        throw new InvalidEnumArgumentException("value", (int)value, typeof(CharacterCasing));
                    }
                    this.SetValue<CharacterCasing>(TextBox.CharacterCasingProperty, value);

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets the default size.
        /// </summary>
        /// <value>The default size.</value>
        protected override Size DefaultSize
        {
            get
            {
                return new Size(100, 20);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Control"/> is focusable.
        /// </summary>
        /// <value><c>true</c> if focusable; otherwise, <c>false</c>.</value>
        protected override bool Focusable
        {
            get
            {
                return true;
            }
        }

        /// <summary>Gets or sets a value specifying the source of complete strings used for automatic completion.</summary>
        /// <returns>One of the values of <see cref="T:System.Windows.Forms.AutoCompleteSource"></see>. The options are AllSystemSources, AllUrl, FileSystem, HistoryList, RecentlyUsedList, CustomSource, and None. The default is None.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the values of <see cref="T:System.Windows.Forms.AutoCompleteSource"></see>. </exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [DefaultValue(AutoCompleteSource.None), SRDescription("TextBoxAutoCompleteSourceDescr")]
        public AutoCompleteSource AutoCompleteSource
        {
            get
            {
                return AutoCompleteSource.None;
            }
            set
            { }
        }

        /// <summary>
        /// Gets the win forms compatibility.
        /// </summary>
        /// <value>
        /// The win forms compatibility.
        /// </value>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new TextBoxWinFormsCompatibility WinFormsCompatibility
        {
            get
            {
                return base.WinFormsCompatibility as TextBoxWinFormsCompatibility;
            }
        }

        #endregion Properties
    }

    #endregion TextBox Class

    #region TextBoxChangeEventArgs Class

    /// <summary>
    ///
    /// </summary>
    [Serializable()]
    public class TextBoxChangedEventArgs : EventArgs
    {
        #region Class Members

        /// <summary>
        /// 
        /// </summary>
        public readonly TextBox mobjTextBox;

        /// <summary>
        /// 
        /// </summary>
        public readonly string mstrOldValue;

        #endregion Class Members

        #region C'Tor / D'Tor

        /// <summary>
        ///
        /// </summary>
        /// <param name="objTextBox"></param>
        /// <param name="strOldValue"></param>
        public TextBoxChangedEventArgs(TextBox objTextBox, string strOldValue)
        {
            mobjTextBox = objTextBox;
            mstrOldValue = strOldValue;
        }

        #endregion C'Tor / D'Tor
    }

    #endregion TextBoxChangeEventArgs Class

    #region TextBoxRenderer Class

    /// <summary>
    /// Provides support for rendering textboxes
    /// </summary>
    [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
    public class TextBoxRenderer : ControlRenderer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextBoxRenderer"/> class.
        /// </summary>
        /// <param name="objTextBox">The text box.</param>
        internal TextBoxRenderer(TextBox objTextBox)
            : base(objTextBox)
        {
        }

        /// <summary>
        /// Renders the content.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objGraphics">The graphics.</param>
        protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
        {
            // Get the current TextBox
            TextBox objTextBox = this.Control as TextBox;
            if (objTextBox != null)
            {
                //Write the TextBox text
                RenderText(objContext, objGraphics, objTextBox.Text, objTextBox.Font, objTextBox.ForeColor, objTextBox.Size, objTextBox.TextAlign, true);
            }
        }
    }

    #endregion
}
