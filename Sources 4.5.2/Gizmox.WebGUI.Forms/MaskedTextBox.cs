#region Using

using System;
using System.Xml;
using System.Text;
using System.Drawing;
using System.Collections;
using Gizmox.WebGUI.Common.Interfaces;
using System.ComponentModel;
using System.Drawing.Design;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common;
using System.Globalization;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region enums
    /// <summary>
    /// Defines how to format the Text property.
    /// <see cref="T:System.Windows.Forms.MaskedTextBox"></see>.
    /// </summary>
    [Serializable()]   
    public enum MaskFormat
    {
        /// <summary>
        /// ExcludePromptAndLiterals
        /// </summary>
        ExcludePromptAndLiterals,
        /// <summary>
        /// IncludePrompt
        /// </summary>
        IncludePrompt,
        /// <summary>
        /// IncludeLiterals
        /// </summary>
        IncludeLiterals,
        /// <summary>
        /// IncludePromptAndLiterals
        /// </summary>
        IncludePromptAndLiterals
    }
    #endregion enumns

	#region MaskedTextBox Class
	
	/// <summary>
    /// Uses a mask to distinguish between proper and improper user input.
	/// </summary>
    [SRDescription("DescriptionMaskedTextBox"), DefaultProperty("Mask")]
    [Serializable()]   
    [ToolboxItemCategory("Common Controls")]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(TextBox), "MaskedTextBox_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(TextBox), "TextBox.bmp")]
#endif
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MaskedTextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MaskedTextBoxController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MaskedTextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MaskedTextBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MaskedTextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MaskedTextBoxController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MaskedTextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MaskedTextBoxController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MaskedTextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MaskedTextBoxController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MaskedTextBoxController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MaskedTextBoxController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MaskedTextBoxController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MaskedTextBoxController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.MaskedTextBoxController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.MaskedTextBoxController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.MaskedTextBoxSkin))]
    public class MaskedTextBox : TextBox
	{


      /// <summary>
        /// Provides a property reference to TextMaskFormat property.
        /// </summary>
        private static SerializableProperty TextMaskFormatProperty = SerializableProperty.Register("TextMaskFormat", typeof(MaskFormat), typeof(MaskedTextBox), new SerializablePropertyMetadata(MaskFormat.IncludeLiterals));



      /// <summary>
        /// Provides a property reference to UseTextMaskFormat property.
        /// </summary>
        private static SerializableProperty UseTextMaskFormatProperty = SerializableProperty.Register("UseTextMaskFormat", typeof(bool), typeof(MaskedTextBox));



      /// <summary>
        /// Provides a property reference to HidePromptOnLeave property.
        /// </summary>
        private static SerializableProperty HidePromptOnLeaveProperty = SerializableProperty.Register("HidePromptOnLeave", typeof(bool), typeof(MaskedTextBox));



      /// <summary>
        /// Provides a property reference to PromptChar property.
        /// </summary>
        private static SerializableProperty PromptCharProperty = SerializableProperty.Register("PromptChar", typeof(char), typeof(MaskedTextBox));



      /// <summary>
        /// Provides a property reference to Mask property.
        /// </summary>
        private static SerializableProperty MaskProperty = SerializableProperty.Register("Mask", typeof(string), typeof(MaskedTextBox));


        /// <summary>
        /// Provides a property reference to ResetOnPrompt property.
        /// </summary>
        private static SerializableProperty ResetOnPromptProperty = SerializableProperty.Register("ResetOnPrompt", typeof(bool), typeof(MaskedTextBox), new SerializablePropertyMetadata(true));


        /// <summary>
        /// Provides a property reference to AllowPromptAsInput property.
        /// </summary>
        private static SerializableProperty AllowPromptAsInputProperty = SerializableProperty.Register("AllowPromptAsInput", typeof(bool), typeof(MaskedTextBox), new SerializablePropertyMetadata(true));


        /// <summary>
        /// Provides a property reference to ResetOnSpace property.
        /// </summary>
        private static SerializableProperty ResetOnSpaceProperty = SerializableProperty.Register("ResetOnSpace", typeof(bool), typeof(MaskedTextBox), new SerializablePropertyMetadata(true));
		
		#region Methods

        /// <summary>
        /// Renders the value.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="blnForceRender">Force render</param>
        protected override void RenderValue(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            string strText = string.Empty;
            string strMask = this.Mask;

            if (!string.IsNullOrEmpty(strMask))
            {
                strText = this.GetTextOutput(base.Text, strMask, this.PromptChar, true, !this.HidePromptOnLeave, this.AllowPromptAsInput, this.ResetOnPrompt, this.ResetOnSpace);
            }
            else
            {
                strText = base.Text;
            }

            if (blnForceRender || !string.IsNullOrEmpty(strText))
            {
                objWriter.WriteAttributeText(WGAttributes.Value, strText);
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

			// If there is defined mask
            if (strMask != string.Empty)
			{
                objWriter.WriteAttributeString(WGAttributes.Mask, this.GetFormatedMask());
			}

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

            switch(this.TextMaskFormat)
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
            maskedTextProvider.Set(strValue);

            return maskedTextProvider;
        }

        /// <summary>
        /// Gets formated cultured mask.
        /// </summary>
        /// <returns></returns>
        private string GetFormatedMask()
        {
            StringBuilder objSB = new StringBuilder();

            // Get current mask
            string strMask = this.Mask;

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
        ///	<exception cref="T:System.ArgumentException">The string supplied to the <see cref="P:Gizmox.WebGUI.Forms.MaskedTextBox.Mask"></see> property is not a valid mask. Invalid masks include masks containing non-printable characters.</exception> 
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
        [Localizable(true), SRCategory("CatBehavior"), SRDescription("MaskedTextBoxMaskDescr"), RefreshProperties(RefreshProperties.Repaint), DefaultValue("")]
        public string Mask
		{
            get
            {
                return this.GetValue<string>(MaskedTextBox.MaskProperty, string.Empty);
            }
            set
            {
                if (this.Mask != value)
                {
                    if (value != string.Empty)
                    {
                        this.SetValue<string>(MaskedTextBox.MaskProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<string>(MaskedTextBox.MaskProperty);
                    }

                    string strCurrentUnformatedText = base.Text;
                    string strNewUnformatedText = this.GetTextOutput(base.Text, this.Mask, this.PromptChar, false, false, this.AllowPromptAsInput, this.ResetOnPrompt, this.ResetOnSpace);
                    if (strNewUnformatedText != strCurrentUnformatedText)
                    {
                        base.InternalText = strNewUnformatedText;
                    }

                    this.Update();
                }
            }
		}
        /// <summary>Gets or sets the character used to represent the absence of user input in <see cref="T:System.Windows.Forms.MaskedTextBox"></see>.</summary>
        /// <returns>The character used to prompt the user for input. The default is an underscore (_). </returns>
        /// <exception cref="T:System.InvalidOperationException">The prompt character specified is the same as the current password character, <see cref="P:System.Windows.Forms.MaskedTextBox.PasswordChar"></see>. The two are required to be different.</exception>
        /// <exception cref="T:System.ArgumentException">The character specified when setting this property is not a valid prompt character, as determined by the <see cref="M:System.ComponentModel.MaskedTextProvider.IsValidPasswordChar(System.Char)"></see> method of the <see cref="T:System.ComponentModel.MaskedTextProvider"></see> class.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [Localizable(true), SRCategory("CatAppearance"), SRDescription("MaskedTextBoxPromptCharDescr"), DefaultValue(mcntPromptChar), RefreshProperties(RefreshProperties.Repaint)]
        public char PromptChar
        {
            get
            {
                return this.GetValue<char>(MaskedTextBox.PromptCharProperty, mcntPromptChar);
            }
            set
            {

                // Validate that the masked text box char is valid
                if (!MaskedTextProvider.IsValidInputChar(value))
                {
                    throw new ArgumentException(SR.GetString("MaskedTextBoxInvalidCharError"));
                }
               
                char chrPromptChar = this.PromptChar;

                if (chrPromptChar != value)
                {
                    // Get MaskedTextProvider
                    MaskedTextProvider maskedTextProvider = GetMaskedTextProvider(base.Text, this.Mask, chrPromptChar, true, true, this.AllowPromptAsInput, this.ResetOnPrompt, this.ResetOnSpace);

                    // Change PromptChar
                    maskedTextProvider.PromptChar = value;

                    // Update Text with the updated text with updated PromptChar
                    this.InternalText = maskedTextProvider.ToString();

                    if (value != mcntPromptChar)
                    {
                        this.SetValue<char>(MaskedTextBox.PromptCharProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<char>(MaskedTextBox.PromptCharProperty);
                    }

                    this.Update();
                }
            }
        }
 
        /// <summary>Gets or sets a value indicating whether the prompt characters in the input mask are hidden when the masked text box loses focus.</summary>
        /// <returns>true if <see cref="P:System.Windows.Forms.MaskedTextBox.PromptChar"></see> is hidden when <see cref="T:System.Windows.Forms.MaskedTextBox"></see> does not have focus; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue(false), SRCategory("CatBehavior"), SRDescription("MaskedTextBoxHidePromptOnLeaveDescr"), RefreshProperties(RefreshProperties.Repaint)]
        public bool HidePromptOnLeave
        {
            get
            {
                return this.GetValue<bool>(MaskedTextBox.HidePromptOnLeaveProperty, false);
            }
            set
            {
                if (this.HidePromptOnLeave != value)
                {
                    if (value != false)
                    {
                        this.SetValue<bool>(MaskedTextBox.HidePromptOnLeaveProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<bool>(MaskedTextBox.HidePromptOnLeaveProperty);
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
        [SRCategory("CatBehavior")]
        [SRDescription("MaskedTextBoxAllowPromptAsInputDescr")]
        [DefaultValue(true)]
        public bool AllowPromptAsInput
        {
            get
            {
                return this.GetValue<bool>(MaskedTextBox.AllowPromptAsInputProperty);
            }
            set
            {
                if (this.SetValue<bool>(MaskedTextBox.AllowPromptAsInputProperty, value))
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
        [SRDescription("MaskedTextBoxResetOnPrompt")]
        [DefaultValue(true)]
        [SRCategory("CatBehavior")]
        public bool ResetOnPrompt
        {
            get
            {
                return this.GetValue<bool>(MaskedTextBox.ResetOnPromptProperty);
            }
            set
            {
                if (this.SetValue<bool>(MaskedTextBox.ResetOnPromptProperty, value))
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
        [SRDescription("MaskedTextBoxResetOnSpace")]
        [DefaultValue(true)]
        [SRCategory("CatBehavior")]
        public bool ResetOnSpace
        {
            get
            {
                return this.GetValue<bool>(MaskedTextBox.ResetOnSpaceProperty);
            }
            set
            {
                if (this.SetValue<bool>(MaskedTextBox.ResetOnSpaceProperty, value))
                {
                    this.UpdateParams(AttributeType.Control);
                }

            }
        }
 
        /// <summary>
        /// Gets or sets the text associated with this control.  
        /// </summary>
        [System.ComponentModel.DefaultValue("")]
        [SRCategory("CatAppearance")]
        [SRDescription("ControlTextDescr")]
        [System.ComponentModel.Localizable(true)]
        [System.ComponentModel.Bindable(true)]
        public override string Text
        {
            get
            {
                if (this.DesignMode || string.IsNullOrEmpty(this.Mask) || !this.UseTextMaskFormat)
                {
                    return base.Text;    
                }
                return this.GetTextOutput();
                
            }
            set
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
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use text mask format.
        /// </summary>
        /// <value><c>true</c> if use text mask format; otherwise, <c>false</c>.</value>
        private bool UseTextMaskFormat
        {
            get
            {
                return this.GetValue<bool>(MaskedTextBox.UseTextMaskFormatProperty, true);
            }
            set
            {
                if (this.UseTextMaskFormat != value)
                {
                    if (value != true)
                    {
                        this.SetValue<bool>(MaskedTextBox.UseTextMaskFormatProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<bool>(MaskedTextBox.UseTextMaskFormatProperty);
                    }
                }
            }
        }

        /// <summary>
        /// Defines how Text property should be formatted
        /// </summary>
        [DefaultValue(MaskFormat.IncludeLiterals), SRCategory("CatBehavior"), SRDescription("MaskedTextBoxTextMaskFormat")]
        public MaskFormat TextMaskFormat
        {
            get
            {
                return this.GetValue<MaskFormat>(MaskedTextBox.TextMaskFormatProperty, MaskFormat.IncludeLiterals);
            }
            set
            {
                if (this.TextMaskFormat != value)
                {
                    if (value != MaskFormat.IncludeLiterals)
                    {
                        this.SetValue<MaskFormat>(MaskedTextBox.TextMaskFormatProperty, value);
                    }
                    else
                    {
                        this.RemoveValue<MaskFormat>(MaskedTextBox.TextMaskFormatProperty);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether text box is multi line.
        /// </summary>
        /// <value>
        /// 	always false for MaskedTextbox.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool Multiline
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>Gets or sets a value indicating whether the user is allowed to reenter literal values.</summary>
        /// <returns>true to allow literals to be reentered; otherwise, false to prevent the user from overwriting literal characters. The default is true.</returns>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        [SRCategory("CatBehavior"), DefaultValue(true), SRDescription("MaskedTextBoxSkipLiterals")]
        public bool SkipLiterals
        {
            get
            {
                return true;
            }
            set
            {}
        }

        /// <summary>
        /// Gets or sets a value indicating whether pressing ENTER in a multiline TextBox control creates a new line of text in the control or activates the default button for the form. This property is not supported by MaskedTextBox.
        /// </summary>
        /// <value>
        /// false in all cases.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public override bool AcceptsReturn
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets a value determining how TAB keys are handled for multiline configurations. This property is not supported by MaskedTextBox.
        /// </summary>
        /// <value>
        /// false in all cases.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public override bool AcceptsTab
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the lines of text in multiline configurations. This property is not supported by MaskedTextBox.
        /// </summary>
        /// <value>
        /// An array of type String that contains a single line.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public override string[] Lines
        {
            get
            {
                return base.Lines;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a multiline text box control automatically wraps words to the beginning of the next line when necessary. This property is not supported by MaskedTextBox.
        /// </summary>
        /// <value>
        /// The WordWrap property always returns false.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public override bool WordWrap
        {
            get
            {
                return false;
            }
            set
            {
            }

        }

        /// <summary>
        /// Gets or sets the maximum number of characters the user can type or paste into the text box control. This property is not supported by MaskedTextBox.
        /// </summary>
        /// <value>
        /// This property always returns 0.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public override int MaxLength
        {
            get
            {
                return base.MaxLength;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets which scroll bars should appear in a multiline TextBox control. This property is not supported by MaskedTextBox.
        /// </summary>
        /// <value>
        /// This property always returns ScrollBars.None.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        public override ScrollBars ScrollBars
        {
            get
            {
                return ScrollBars.None;
            }
            set
            {
            }
        }

        #endregion Properties


		#region Class Members
		
        /// <summary>
        /// The prompt character to use in the displayed masked text
        /// </summary>
        private const char mcntPromptChar = '_';
        
		
		#endregion Class Members


		#region C'Tor / D'Tor
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MaskedTextBox"></see> class using defaults.
		/// </summary>
		public MaskedTextBox()
		{
            this.CustomStyle = "Masked";
		}
		
		#endregion C'Tor / D'Tor

	}
	
	#endregion MaskedTextBox Class
}
