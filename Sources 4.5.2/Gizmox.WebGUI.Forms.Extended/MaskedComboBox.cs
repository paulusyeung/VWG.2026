using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;
using System.Globalization;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(MaskedComboBox), "Extended.MaskedComboBox_45.png")]
#else
    [ToolboxBitmap(typeof(MaskedComboBox), "Extended.MaskedComboBox.png")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
    [ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
#endif
    [Serializable()]
    [Skin(typeof(MaskedComboBoxSkin))]
    public class MaskedComboBox : ComboBox, IRequiresRegistration
    {

        /// <summary>
        /// Provides a property reference to TextMaskFormat property.
        /// </summary>
        private static SerializableProperty TextMaskFormatProperty = SerializableProperty.Register("TextMaskFormat", typeof(MaskFormat), typeof(MaskedComboBox), new SerializablePropertyMetadata(MaskFormat.IncludeLiterals));



        /// <summary>
        /// Provides a property reference to UseTextMaskFormat property.
        /// </summary>
        private static SerializableProperty UseTextMaskFormatProperty = SerializableProperty.Register("UseTextMaskFormat", typeof(bool), typeof(MaskedComboBox));



        /// <summary>
        /// Provides a property reference to HidePromptOnLeave property.
        /// </summary>
        private static SerializableProperty HidePromptOnLeaveProperty = SerializableProperty.Register("HidePromptOnLeave", typeof(bool), typeof(MaskedComboBox));



        /// <summary>
        /// Provides a property reference to PromptChar property.
        /// </summary>
        private static SerializableProperty PromptCharProperty = SerializableProperty.Register("PromptChar", typeof(char), typeof(MaskedComboBox));



        /// <summary>
        /// Provides a property reference to Mask property.
        /// </summary>
        private static SerializableProperty MaskProperty = SerializableProperty.Register("Mask", typeof(string), typeof(MaskedComboBox));


        /// <summary>
        /// Provides a property reference to ResetOnPrompt property.
        /// </summary>
        private static SerializableProperty ResetOnPromptProperty = SerializableProperty.Register("ResetOnPrompt", typeof(bool), typeof(MaskedComboBox), new SerializablePropertyMetadata(true));


        /// <summary>
        /// Provides a property reference to AllowPromptAsInput property.
        /// </summary>
        private static SerializableProperty AllowPromptAsInputProperty = SerializableProperty.Register("AllowPromptAsInput", typeof(bool), typeof(MaskedComboBox), new SerializablePropertyMetadata(true));


        /// <summary>
        /// Provides a property reference to ResetOnSpace property.
        /// </summary>
        private static SerializableProperty ResetOnSpaceProperty = SerializableProperty.Register("ResetOnSpace", typeof(bool), typeof(MaskedComboBox), new SerializablePropertyMetadata(true));
		

        #region Methods

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            if (!string.IsNullOrEmpty(this.Mask))
            {
                if (objEvent.Type == "ValueChange")
                {
                    // Check if the value change event was not originated by the combo box's infrastructure.
                    if (string.IsNullOrEmpty(objEvent[WGAttributes.Value]))
                    {
                        // Set the current text value
                        this.Text = CommonUtils.DecodeText(objEvent[WGAttributes.Text]);
                        return;
                    }
                }
            }

            base.FireEvent(objEvent);
        }

        /// <summary>
        /// Render the text attrbute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderText(IAttributeWriter objWriter)
        {
            if (string.IsNullOrEmpty(this.Mask))
            {
                base.RenderText(objWriter);
            }
        }

        /// <summary>
        /// Renders the current control attributes.
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter">The response writer object.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            // The  base function renders the value to the client using 
            // the control's Text property. The parent Text property is 
            // overridden here and uses the TextMaskFormat to apply formatting
            // to the result returned. The boolean below is set to false below
            // to instruct the Text property get that it should ignore 
            // the TextMaskFormat. After base.RenderAttributies statement is 
            // executed, the boolean is set to true, to instruct the Text property 
            // to perform the formatting in the get.
            base.RenderAttributes(objContext, objWriter);

            string strMask = this.Mask;

            if (!string.IsNullOrEmpty(strMask))
            {
                objWriter.WriteAttributeString(WGAttributes.Mask, this.GetFormatedMask(strMask));

                // Renders the "HidePromptOnLeave" property.
                if (this.HidePromptOnLeave)
                {
                    objWriter.WriteAttributeString(WGAttributes.HidePromptOnLeave, "1");
                }

                // Renders the "ResetOnSpace" property.
                RenderResetOnSpaceAttribute(objWriter, false);

                // Renders the "ResetOnPrompt" property.
                RenderResetOnPromptAttribute(objWriter, false);

                // Renders the "AllowPromptAsInput" property.
                RenderAllowPromptAsInputAttribute(objWriter, false);

                objWriter.WriteAttributeString(WGAttributes.PromptChar, this.PromptChar.ToString());
            }
        }


        /// <summary>
        /// Render updated control params
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
                // Renders the "ResetOnSpace" property.
                RenderResetOnSpaceAttribute(objWriter, true);

                // Renders the "ResetOnPrompt" property.
                RenderResetOnPromptAttribute(objWriter, true);

                // Renders the "AllowPromptAsInput" property.
                RenderAllowPromptAsInputAttribute(objWriter, true);

            }
        }

        /// <summary>
        /// Renders the ResetOnSpace attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderResetOnSpaceAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            // Renders the "ResetOnSpace" property.
            if (!this.ResetOnSpace || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.ResetOnSpace, this.ResetOnSpace ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the ResetOnPrompt attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderResetOnPromptAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            // Renders the "ResetOnPrompt" property.
            if (!this.ResetOnPrompt || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.ResetOnPrompt, this.ResetOnPrompt ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the AllowPromptAsInput attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderAllowPromptAsInputAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            // Renders the "AllowPromptAsInput" property.
            if (!this.AllowPromptAsInput || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.AllowPromptAsInput, this.AllowPromptAsInput ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the value.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        protected override void RenderValue(IAttributeWriter objWriter)
        {
            string strMask = this.Mask;

            if (!string.IsNullOrEmpty(strMask))
            {
                string strText = string.Empty;

                if (!string.IsNullOrEmpty(strMask))
                {
                    strText = this.GetTextOutput(base.Text, strMask, this.PromptChar, true, !this.HidePromptOnLeave, this.AllowPromptAsInput, this.ResetOnPrompt, this.ResetOnSpace);
                }
                else
                {
                    strText = base.Text;
                }

                if (!string.IsNullOrEmpty(strText))
                {
                    objWriter.WriteAttributeString(WGAttributes.Value, strText);
                }
            }
            else
            {
                base.RenderValue(objWriter);
            }
        }

        /// <summary>
        /// Implements the actual client side selection
        /// </summary>
        /// <param name="intStart"></param>
        /// <param name="intLength"></param>
        protected override void InvokeSelection(int intStart, int intLength)
        {
            this.InvokeMethodWithId("Common_MaskExecute", "Select", intStart, intLength);
        }
        /// <summary>Returns the formatted string that includes all the assigned character values.</summary>
        /// <returns>The formatted <see cref="T:System.String"></see> that includes all the assigned character values.</returns>
        private string GetTextOutput()
        {
            bool blnIncludeLiterals = false;
            bool blnIncludePrompt = false;

            switch (this.TextMaskFormat)
            {
                case MaskFormat.IncludeLiterals:
                    blnIncludeLiterals = true;
                    break;
                case MaskFormat.IncludePrompt:
                    blnIncludePrompt = true;
                    break;
                case MaskFormat.IncludePromptAndLiterals:
                    blnIncludeLiterals = true;
                    blnIncludePrompt = true;
                    break;
            }

            return this.GetTextOutput(base.Text, this.Mask, this.PromptChar, blnIncludeLiterals, blnIncludePrompt, this.AllowPromptAsInput, this.ResetOnPrompt, this.ResetOnSpace);
        }

        /// <summary>
        /// Gets the text output.
        /// </summary>
        /// <param name="strValue">The STR value.</param>
        /// <param name="strMask">The STR mask.</param>
        /// <param name="chrPromptChar">The CHR prompt char.</param>
        /// <param name="blnIncludeLiterals">if set to <c>true</c> [BLN include literals].</param>
        /// <param name="blnIncludePrompt">if set to <c>true</c> [BLN include prompt].</param>
        /// <param name="blnAllowPromptAsInput">if set to <c>true</c> [BLN allow prompt as input].</param>
        /// <param name="blnResetOnPrompt">if set to <c>true</c> [BLN reset on prompt].</param>
        /// <param name="blnResetOnSpace">if set to <c>true</c> [BLN reset on space].</param>
        /// <returns></returns>
        private string GetTextOutput(string strValue, string strMask, char chrPromptChar, bool blnIncludeLiterals, bool blnIncludePrompt, bool blnAllowPromptAsInput, bool blnResetOnPrompt, bool blnResetOnSpace)
        {
            MaskedTextProvider maskedTextProvider = GetMaskedTextProvider(strValue, strMask, chrPromptChar, blnIncludeLiterals, blnIncludePrompt, blnAllowPromptAsInput, blnResetOnPrompt, blnResetOnSpace);

            return maskedTextProvider.ToString();
        }

        /// <summary>
        /// Gets the masked text provider.
        /// </summary>
        /// <param name="strValue">The text value.</param>
        /// <param name="strMask">The mask value.</param>
        /// <param name="chrPromptChar">The prompt char.</param>
        /// <param name="blnIncludeLiterals">if set to <c>true</c> [BLN include literals].</param>
        /// <param name="blnIncludePrompt">if set to <c>true</c> [include prompt].</param>
        /// <param name="blnAllowPromptAsInput">if set to <c>true</c> [BLN allow prompt as input].</param>
        /// <param name="blnResetOnPrompt">if set to <c>true</c> [BLN reset on prompt].</param>
        /// <param name="blnResetOnSpace">if set to <c>true</c> [BLN reset on space].</param>
        /// <returns></returns>
        private MaskedTextProvider GetMaskedTextProvider(string strValue, string strMask, char chrPromptChar, bool blnIncludeLiterals, bool blnIncludePrompt, bool blnAllowPromptAsInput, bool blnResetOnPrompt, bool blnResetOnSpace) 
        {
            if (string.IsNullOrEmpty(strMask))
            {
                strMask = "<>";
            }
            MaskedTextProvider maskedTextProvider = new MaskedTextProvider(strMask, CultureInfo.CurrentUICulture, blnAllowPromptAsInput);
            maskedTextProvider.PromptChar = chrPromptChar;
            maskedTextProvider.IncludeLiterals = blnIncludeLiterals;
            maskedTextProvider.IncludePrompt = blnIncludePrompt;
            maskedTextProvider.ResetOnPrompt = blnResetOnPrompt;
            maskedTextProvider.ResetOnSpace = blnResetOnSpace;
            if (!String.IsNullOrEmpty(strValue))
            {
                maskedTextProvider.Set(strValue);
            }

            return maskedTextProvider;
        }

        /// <summary>
        /// Gets formated cultured mask.
        /// </summary>
        /// <returns></returns>
        private string GetFormatedMask(string strMask)
        {
            StringBuilder objSB = new StringBuilder();

            if (!string.IsNullOrEmpty(strMask))
            {
                // Loop on all chars and replece cultured characters
                foreach (char c in strMask)
                {
                    switch (c)
                    {
                        // Currency Symbol
                        case '$':
                            objSB.Append(CultureInfo.CurrentUICulture.NumberFormat.CurrencySymbol);
                            break;

                        // Number Group Separator
                        case ',':
                            objSB.Append(CultureInfo.CurrentUICulture.NumberFormat.NumberGroupSeparator);
                            break;

                        // Number Decimal Separator
                        case '.':
                            objSB.Append(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator);
                            break;

                        // Date Separator
                        case '/':
                            objSB.Append(CultureInfo.CurrentUICulture.DateTimeFormat.DateSeparator);
                            break;

                        // Time Separator
                        case ':':
                            objSB.Append(CultureInfo.CurrentUICulture.DateTimeFormat.TimeSeparator);
                            break;

                        default:
                            objSB.Append(c);
                            break;
                    }
                }
            }

            // Return new formated Mask
            return objSB.ToString();
        }

        #endregion Methods


        #region Properties

        /// <summary>
        /// Gets or sets the input mask to use at run time. 
        /// </summary>
        ///	<returns>A <see cref="T:System.String"></see> representing the current mask. The default value is the empty string which allows any input.</returns>
        ///	<exception cref="T:System.ArgumentException">The string supplied to the <see cref="P:Gizmox.WebGUI.Forms.MaskedComboBox.Mask"></see> property is not a valid mask. Invalid masks include masks containing non-printable characters.</exception> 
#if WG_NET46
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif
        [Localizable(true), RefreshProperties(RefreshProperties.Repaint), DefaultValue("")]
        public string Mask
        {
            get
            {
                return this.GetValue<string>(MaskedComboBox.MaskProperty, string.Empty);
            }
            set
            {
                if (this.Mask != value)
                {
                    if (value != string.Empty)
                    {
                        this.SetValue<string>(MaskedComboBox.MaskProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<string>(MaskedComboBox.MaskProperty);
                    }

                    string strCurrentUnformatedText = base.Text;
                    string strNewUnformatedText = this.GetTextOutput(base.Text, this.Mask, this.PromptChar, false, false, this.AllowPromptAsInput, this.ResetOnPrompt, this.ResetOnSpace);
                    if (strNewUnformatedText != strCurrentUnformatedText)
                    {
                        base.Text = strNewUnformatedText;
                    }

                    this.Update();
                }
            }
        }
        /// <summary>Gets or sets the character used to represent the absence of user input in <see cref="T:System.Windows.Forms.MaskedComboBox"></see>.</summary>
        /// <returns>The character used to prompt the user for input. The default is an underscore (_). </returns>
        /// <exception cref="T:System.InvalidOperationException">The prompt character specified is the same as the current password character, <see cref="P:System.Windows.Forms.MaskedComboBox.PasswordChar"></see>. The two are required to be different.</exception>
        /// <exception cref="T:System.ArgumentException">The character specified when setting this property is not a valid prompt character, as determined by the <see cref="M:System.ComponentModel.MaskedTextProvider.IsValidPasswordChar(System.Char)"></see> method of the <see cref="T:System.ComponentModel.MaskedTextProvider"></see> class.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Localizable(true), DefaultValue(mcntPromptChar), RefreshProperties(RefreshProperties.Repaint)]
        public char PromptChar
        {
            get
            {
                return this.GetValue<char>(MaskedComboBox.PromptCharProperty, mcntPromptChar);
            }
            set
            {

                // Validate that the masked text box char is valid
                if (!MaskedTextProvider.IsValidInputChar(value))
                {
                    throw new ArgumentException("MaskedTextBoxInvalidCharError");
                }

                char chrPromptChar = this.PromptChar;

                if (chrPromptChar != value)
                {
                    // Get MaskedTextProvider
                    MaskedTextProvider maskedTextProvider = GetMaskedTextProvider(base.Text, this.Mask, chrPromptChar, true, true, this.AllowPromptAsInput, this.ResetOnPrompt, this.ResetOnSpace);

                    // Change PromptChar
                    maskedTextProvider.PromptChar = value;

                    // Update Text with the updated text with updated PromptChar
                    this.Text = maskedTextProvider.ToString();

                    if (value != mcntPromptChar)
                    {
                        this.SetValue<char>(MaskedComboBox.PromptCharProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<char>(MaskedComboBox.PromptCharProperty);
                    }

                    this.Update();
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the prompt characters in the input mask are hidden when the masked text box loses focus.</summary>
        /// <returns>true if <see cref="P:System.Windows.Forms.MaskedComboBox.PromptChar"></see> is hidden when <see cref="T:System.Windows.Forms.MaskedComboBox"></see> does not have focus; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue(false), RefreshProperties(RefreshProperties.Repaint)]
        public bool HidePromptOnLeave
        {
            get
            {
                return this.GetValue<bool>(MaskedComboBox.HidePromptOnLeaveProperty, false);
            }
            set
            {
                if (this.HidePromptOnLeave != value)
                {
                    if (value != false)
                    {
                        this.SetValue<bool>(MaskedComboBox.HidePromptOnLeaveProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<bool>(MaskedComboBox.HidePromptOnLeaveProperty);
                    }

                    this.Update();
                }
            }

        }

        /// <summary>
        /// Gets or sets a value indicating whether System.Windows.Forms.MaskedTextBox.PromptChar
        /// can be entered as valid data by the user.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the user can enter the prompt character into the control; otherwise, <c>false</c>.
        /// </value>
        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue(true)]
        public bool AllowPromptAsInput
        {
            get
            {
                return this.GetValue<bool>(MaskedComboBox.AllowPromptAsInputProperty);
            }
            set
            {
                if (this.SetValue<bool>(MaskedComboBox.AllowPromptAsInputProperty, value))
                {
                    this.UpdateParams(AttributeType.Control);
                }

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
        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue(true)]
        public bool ResetOnPrompt
        {
            get
            {
                return this.GetValue<bool>(MaskedComboBox.ResetOnPromptProperty);
            }
            set
            {
                if (this.SetValue<bool>(MaskedComboBox.ResetOnPromptProperty, value))
                {
                    this.UpdateParams(AttributeType.Control);
                }

            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [reset on space].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [reset on space]; otherwise, <c>false</c>.
        /// </value>
        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue(true)]
        public bool ResetOnSpace
        {
            get
            {
                return this.GetValue<bool>(MaskedComboBox.ResetOnSpaceProperty);
            }
            set
            {
                if (this.SetValue<bool>(MaskedComboBox.ResetOnSpaceProperty, value))
                {
                    this.UpdateParams(AttributeType.Control);
                }

            }
        }


        /// <summary>
        /// Gets or sets the text associated with this control.  
        /// </summary>
        [System.ComponentModel.DefaultValue("")]
        [System.ComponentModel.Localizable(true)]
        [System.ComponentModel.Bindable(true)]
        public override string Text
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Mask))
                {
                    if (this.DesignMode || string.IsNullOrEmpty(this.Mask) || !this.UseTextMaskFormat)
                    {
                        return base.Text;
                    }
                    return this.GetTextOutput();
                }
                else
                {
                    return base.Text;
                }
            }
            set
            {
                if (!string.IsNullOrEmpty(this.Mask))
                {
                    this.UseTextMaskFormat = false;
                    if (base.Text != value)
                    {
                        // Get current mask.
                        string strMask = this.Mask;

                        // Check if current mask is valid.
                        if (string.IsNullOrEmpty(strMask))
                        {
                            // Set text value.
                            base.Text = value;
                        }
                        else
                        {
                            // Set masked text value.
                            base.Text = this.GetTextOutput(value, strMask, this.PromptChar, false, false, this.AllowPromptAsInput, this.ResetOnPrompt, this.ResetOnSpace);
                        }
                    }
                    this.UseTextMaskFormat = true;
                }
                else
                {
                    base.Text = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use text mask format.
        /// </summary>
        /// <value><c>true</c> if use text mask format; otherwise, <c>false</c>.</value>
        private bool UseTextMaskFormat
        {
            get
            {
                return this.GetValue<bool>(MaskedComboBox.UseTextMaskFormatProperty, true);
            }
            set
            {
                if (this.UseTextMaskFormat != value)
                {
                    if (value != true)
                    {
                        this.SetValue<bool>(MaskedComboBox.UseTextMaskFormatProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<bool>(MaskedComboBox.UseTextMaskFormatProperty);
                    }
                }
            }
        }

        /// <summary>
        /// Masked ComboBox does not implement CharacterCasing
        /// 
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DefaultValue(CharacterCasing.Normal)]
        public override CharacterCasing CharacterCasing
        {
            get
            {
                return CharacterCasing.Normal;
            }
            set
            {
            }
        }

        /// <summary>
        /// Defines how Text property should be formatted
        /// </summary>
        [DefaultValue(MaskFormat.IncludeLiterals), Category("Behavior"), Description("Indicates whether the string returned from the Text property includes literals and/or prompt characters.")]
        public MaskFormat TextMaskFormat
        {
            get
            {
                return this.GetValue<MaskFormat>(MaskedComboBox.TextMaskFormatProperty, MaskFormat.IncludeLiterals);
            }
            set
            {
                if (this.TextMaskFormat != value)
                {
                    if (value != MaskFormat.IncludeLiterals)
                    {
                        this.SetValue<MaskFormat>(MaskedComboBox.TextMaskFormatProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<MaskFormat>(MaskedComboBox.TextMaskFormatProperty);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the drop down style.
        /// </summary>
        /// <value></value>
        public override ComboBoxStyle DropDownStyle
        {
            get
            {
                return ComboBoxStyle.DropDown;
            }
            set
            {
                base.DropDownStyle = value;
            }
        }

        /// <summary>
        /// Gets or sets the control custom style.
        /// </summary>
        /// <value></value>
        public override string CustomStyle
        {
            get
            {
                return "M";
            }
            set
            {
                base.CustomStyle = value;
            }
        }

        #endregion Properties


        #region Class Members

        /// <summary>
        /// The prompt character to use in the displayed masked text
        /// </summary>
        private const char mcntPromptChar = '_';


        #endregion Class Members
    }
}
