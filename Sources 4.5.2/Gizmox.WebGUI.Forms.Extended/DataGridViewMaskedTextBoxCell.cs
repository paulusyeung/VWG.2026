using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Interfaces;
using System.ComponentModel;
using System.Globalization;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class DataGridViewMaskedTextBoxCell : DataGridViewTextBoxCell
    {

        #region Members

        /// <summary>
        /// The prompt character to use in the displayed masked text
        /// </summary>
        private const char mcntPromptChar = '_';

        private static Type mobjCellType;



        /// <summary>
        /// Provides a property reference to TextMaskFormat property.
        /// </summary>
        private MaskFormat menumTextMaskFormat = MaskFormat.IncludeLiterals;        

        /// <summary>
        /// Provides a property reference to UseTextMaskFormat property.
        /// </summary>
        private bool mblnUseTextMaskFormat = false;

        /// <summary>
        /// Provides a property reference to HidePromptOnLeave property.
        /// </summary>
        private bool mblnHidePromptOnLeave = false;

        /// <summary>
        /// Provides a property reference to PromptChar property.
        /// </summary>
        private char mchrPromptChar = mcntPromptChar;

        /// <summary>
        /// Provides a property reference to Mask property.
        /// </summary>
        private string mstrMask = string.Empty;

        /// <summary>
        /// Provides a property reference to ResetOnPrompt property.
        /// </summary>
        private bool mblnResetOnPrompt = true;

        /// <summary>
        /// Provides a property reference to AllowPromptAsInput property.
        /// </summary>
        private bool mblnAllowPromptAsInput = true;

        /// <summary>
        /// Provides a property reference to ResetOnSpace property.
        /// </summary>
        private bool mblnResetOnSpace = true;


        #endregion Members

        #region C'tors / D'tors

        /// <summary>
        /// Initializes the <see cref="DataGridViewMaskedTextBoxCell"/> class.
        /// </summary>
        static DataGridViewMaskedTextBoxCell()
        {
            DataGridViewMaskedTextBoxCell.mobjCellType = typeof(DataGridViewMaskedTextBoxCell);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewMaskedTextBoxCell"></see> class.
        /// </summary>
        public DataGridViewMaskedTextBoxCell()
        {
        }

        #endregion C'tors / D'tors

        #region Methods

        //internal override void FireEvent(IEvent objEvent)
        //{
        //    base.FireEvent(objEvent);
        //}


        /// <summary>Creates an exact copy of this cell.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewMaskedTextBoxCell"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override object Clone()
        {
            DataGridViewMaskedTextBoxCell objCell;
            Type objType = base.GetType();
            if (objType == DataGridViewMaskedTextBoxCell.mobjCellType)
            {
                objCell = new DataGridViewMaskedTextBoxCell();
            }
            else
            {
                objCell = (DataGridViewMaskedTextBoxCell)Activator.CreateInstance(objType);
            }
            base.CloneInternal(objCell);
            objCell.Mask = this.Mask;
            objCell.PromptChar = this.PromptChar;
            objCell.HidePromptOnLeave = this.HidePromptOnLeave;
            objCell.ResetOnPrompt = this.ResetOnPrompt;
            objCell.ResetOnSpace = this.ResetOnSpace;
            objCell.AllowPromptAsInput = this.AllowPromptAsInput;

            return objCell;
        }

        /// <summary>
        /// Returns a string that describes the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return ("DataGridViewMaskedTextBoxCell { ColumnIndex=" + base.ColumnIndex.ToString() + ", RowIndex=" + base.RowIndex.ToString() + " }");
        }

        /// <summary>Returns the formatted string that includes all the assigned character values.</summary>
        /// <returns>The formatted <see cref="T:System.String"></see> that includes all the assigned character values.</returns>
        private string GetTextOutput()
        {

            return this.GetTextOutput(this.ValueText);
        }

        /// <summary>
        /// Gets the text output.
        /// </summary>
        /// <param name="strValue">The value.</param>
        /// <returns></returns>
        private string GetTextOutput(string strValue)
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

            return this.GetTextOutput(strValue, this.Mask, this.PromptChar, blnIncludeLiterals, blnIncludePrompt, this.AllowPromptAsInput, this.ResetOnPrompt,this.ResetOnSpace);
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

        /// <summary>Sets the value of the cell. </summary>
        /// <returns>true if the value has been set; otherwise, false.</returns>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        /// <param name="objValue">The cell value to set. </param>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
        protected override bool SetValue(int intRowIndex, object objValue)
        {
            // Get current mask.
            string strMask = this.Mask;

            string strValue = string.Empty;
            if (objValue != null)
            {
                strValue = objValue.ToString();
            }

            // Check if current mask is valid.
            if (!string.IsNullOrEmpty(strMask))
            {
                // Update masked text value.
                objValue = this.GetTextOutput(strValue, strMask, this.PromptChar, false, false, this.AllowPromptAsInput, this.ResetOnPrompt,this.ResetOnSpace);
            }

            return base.SetValue(intRowIndex, objValue);
        }

        /// <summary>
        /// Gets the value of the cell.
        /// </summary>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        /// <returns>
        /// The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> property is less than 0, indicating that the cell is a row header cell.</exception>
        protected override object GetValue(int intRowIndex)
        {
            object objValue = base.GetValue(intRowIndex);

            if (objValue != null)
            {
                string strValue = string.Empty;
                if (objValue != null)
                {
                    strValue = objValue.ToString();
                }
                
                if (string.IsNullOrEmpty(this.Mask) || !this.UseTextMaskFormat)
                {
                    return strValue;
                }

                return GetTextOutput(strValue);
            }
            else
            {
                return objValue;
            }   
        }
       

        #region Render

        /// <summary>
        /// Renders the cell text/value.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objFormatedValue">The formated value.</param>
        protected override void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
        {
            string strMask = this.Mask;
            string strText = this.ValueText;

            if (!string.IsNullOrEmpty(strMask))
            {
                strText = this.GetTextOutput(strText, strMask, this.PromptChar, true, !this.HidePromptOnLeave, this.AllowPromptAsInput, this.ResetOnPrompt,this.ResetOnSpace);
            }
            
            if (!string.IsNullOrEmpty(strText))
            {
                objWriter.WriteAttributeText(WGAttributes.Value, strText);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter, bool blnRenderOwner)
        {
            base.RenderAttributes(objContext, objWriter, blnRenderOwner);

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
            if (!this.ResetOnSpace)
            {
                objWriter.WriteAttributeString(WGAttributes.ResetOnSpace, "0");
            }

            // Renders the "ResetOnPrompt" property.
            if (!this.ResetOnPrompt)
            {
                objWriter.WriteAttributeString(WGAttributes.ResetOnPrompt, "0");
            }

            // Renders the "AllowPromptAsInput" property.
            if (!this.AllowPromptAsInput)
            {
                objWriter.WriteAttributeString(WGAttributes.AllowPromptAsInput, "0");
            }

            objWriter.WriteAttributeString(WGAttributes.PromptChar, this.PromptChar.ToString());
        }

        #endregion Render


        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets the mask.
        /// </summary>
        /// <value>The mask.</value>
        [Localizable(true), RefreshProperties(RefreshProperties.Repaint), DefaultValue("")]
        public string Mask
        {
            get
            {
                return mstrMask;
            }
            set
            {
                if (this.Mask != value)
                {
                    mstrMask = value;

                    string strCurrentUnformatedText = this.ValueText;
                    string strNewUnformatedText = this.GetTextOutput(strCurrentUnformatedText, this.Mask, this.PromptChar, false, false, this.AllowPromptAsInput, this.ResetOnPrompt,this.ResetOnSpace);
                    if (strNewUnformatedText != strCurrentUnformatedText)
                    {
                        this.Value = strNewUnformatedText;
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
                return mchrPromptChar;
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
                    MaskedTextProvider maskedTextProvider = GetMaskedTextProvider(this.ValueText, this.Mask, chrPromptChar, true, true, this.AllowPromptAsInput, this.ResetOnPrompt,this.ResetOnSpace);

                    // Change PromptChar
                    maskedTextProvider.PromptChar = value;

                    mchrPromptChar = value;

                    // Update Text with the updated text with updated PromptChar
                    this.Value = maskedTextProvider.ToString();

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
                return mblnHidePromptOnLeave;
            }
            set
            {
                if (this.HidePromptOnLeave != value)
                {
                    mblnHidePromptOnLeave = value;

                    this.Update();
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
                return mblnUseTextMaskFormat;
            }
            set
            {
                mblnUseTextMaskFormat = value;
            }
        }

        /// <summary>
        /// Defines how Text property should be formatted
        /// </summary>
        public MaskFormat TextMaskFormat
        {
            get
            {
                return menumTextMaskFormat;
            }
            set
            {
                menumTextMaskFormat = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether System.Windows.Forms.MaskedTextBox.PromptChar
        /// can be entered as valid data by the user.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the user can enter the prompt character into the control; otherwise, <c>false</c>.
        /// </value>
        [Category("CatBehavior")]
        [Description("MaskedTextBoxAllowPromptAsInputDescr")]
        [DefaultValue(true)]
        public bool AllowPromptAsInput
        {
            get
            {
                return mblnAllowPromptAsInput;
            }
            set
            {
                if (this.mblnAllowPromptAsInput != value)
                {
                    mblnAllowPromptAsInput = value;

                    this.Update();
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
        [Description("MaskedTextBoxResetOnPrompt")]
        [DefaultValue(true)]
        [Category("CatBehavior")]
        public bool ResetOnPrompt
        {
            get
            {
                return mblnResetOnPrompt;
            }
            set
            {
                if (this.mblnResetOnPrompt != value)
                {
                    mblnResetOnPrompt = value;

                    this.Update();
                }
            }
        }


        /// <summary>
        /// Gets or sets a value that determines how a space input character should be
        /// handled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the space input character causes the current editable position in
        ///     the mask to be reset; otherwise, <c>false</c> to indicate that it is to be processed
        ///     as a normal input character. The default is true.
        /// </value>
        [Description("MaskedTextBoxResetOnSpace")]
        [DefaultValue(true)]
        [Category("CatBehavior")]
        public bool ResetOnSpace
        {
            get
            {
                return mblnResetOnSpace;
            }
            set
            {
                if (this.mblnResetOnSpace != value)
                {
                    mblnResetOnSpace = value;

                    this.Update();
                }
            }
        }

        #endregion Properties
    }
}