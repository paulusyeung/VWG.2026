using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms;

/// <summary>
///
/// </summary>
[Serializable]
public class DataGridViewMaskedTextBoxCell : DataGridViewTextBoxCell
{
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
	private char mchrPromptChar = '_';

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

	/// <summary>
	/// Gets or sets the mask.
	/// </summary>
	/// <value>The mask.</value>
	[Localizable(true)]
	[RefreshProperties(RefreshProperties.Repaint)]
	[DefaultValue("")]
	public string Mask
	{
		get
		{
			return mstrMask;
		}
		set
		{
			if (Mask != value)
			{
				mstrMask = value;
				string valueText = base.ValueText;
				string textOutput = GetTextOutput(valueText, Mask, PromptChar, blnIncludeLiterals: false, blnIncludePrompt: false, AllowPromptAsInput, ResetOnPrompt, ResetOnSpace);
				if (textOutput != valueText)
				{
					base.Value = textOutput;
				}
				Update();
			}
		}
	}

	/// <summary>Gets or sets the character used to represent the absence of user input in <see cref="T:System.Windows.Forms.MaskedComboBox"></see>.</summary>
	/// <returns>The character used to prompt the user for input. The default is an underscore (_). </returns>
	/// <exception cref="T:System.InvalidOperationException">The prompt character specified is the same as the current password character, <see cref="P:System.Windows.Forms.MaskedComboBox.PasswordChar"></see>. The two are required to be different.</exception>
	/// <exception cref="T:System.ArgumentException">The character specified when setting this property is not a valid prompt character, as determined by the <see cref="M:System.ComponentModel.MaskedTextProvider.IsValidPasswordChar(System.Char)"></see> method of the <see cref="T:System.ComponentModel.MaskedTextProvider"></see> class.</exception>
	/// <filterpriority>1</filterpriority>
	/// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
	[Localizable(true)]
	[DefaultValue('_')]
	[RefreshProperties(RefreshProperties.Repaint)]
	public char PromptChar
	{
		get
		{
			return mchrPromptChar;
		}
		set
		{
			if (!MaskedTextProvider.IsValidInputChar(value))
			{
				throw new ArgumentException("MaskedTextBoxInvalidCharError");
			}
			char promptChar = PromptChar;
			if (promptChar != value)
			{
				MaskedTextProvider maskedTextProvider = GetMaskedTextProvider(base.ValueText, Mask, promptChar, blnIncludeLiterals: true, blnIncludePrompt: true, AllowPromptAsInput, ResetOnPrompt, ResetOnSpace);
				maskedTextProvider.PromptChar = value;
				mchrPromptChar = value;
				base.Value = maskedTextProvider.ToString();
				Update();
			}
		}
	}

	/// <summary>Gets or sets a value indicating whether the prompt characters in the input mask are hidden when the masked text box loses focus.</summary>
	/// <returns>true if <see cref="P:System.Windows.Forms.MaskedComboBox.PromptChar"></see> is hidden when <see cref="T:System.Windows.Forms.MaskedComboBox"></see> does not have focus; otherwise, false. The default is false.</returns>
	/// <filterpriority>1</filterpriority>
	/// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
	[DefaultValue(false)]
	[RefreshProperties(RefreshProperties.Repaint)]
	public bool HidePromptOnLeave
	{
		get
		{
			return mblnHidePromptOnLeave;
		}
		set
		{
			if (HidePromptOnLeave != value)
			{
				mblnHidePromptOnLeave = value;
				Update();
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
			if (mblnAllowPromptAsInput != value)
			{
				mblnAllowPromptAsInput = value;
				Update();
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
			if (mblnResetOnPrompt != value)
			{
				mblnResetOnPrompt = value;
				Update();
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
			if (mblnResetOnSpace != value)
			{
				mblnResetOnSpace = value;
				Update();
			}
		}
	}

	/// <summary>
	/// Initializes the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewMaskedTextBoxCell" /> class.
	/// </summary>
	static DataGridViewMaskedTextBoxCell()
	{
		mobjCellType = typeof(DataGridViewMaskedTextBoxCell);
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewMaskedTextBoxCell"></see> class.
	/// </summary>
	public DataGridViewMaskedTextBoxCell()
	{
	}

	/// <summary>Creates an exact copy of this cell.</summary>
	/// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewMaskedTextBoxCell"></see>.</returns>
	/// <filterpriority>1</filterpriority>
	public override object Clone()
	{
		Type type = GetType();
		DataGridViewMaskedTextBoxCell dataGridViewMaskedTextBoxCell = ((!(type == mobjCellType)) ? ((DataGridViewMaskedTextBoxCell)Activator.CreateInstance(type)) : new DataGridViewMaskedTextBoxCell());
		CloneInternal(dataGridViewMaskedTextBoxCell);
		dataGridViewMaskedTextBoxCell.Mask = Mask;
		dataGridViewMaskedTextBoxCell.PromptChar = PromptChar;
		dataGridViewMaskedTextBoxCell.HidePromptOnLeave = HidePromptOnLeave;
		dataGridViewMaskedTextBoxCell.ResetOnPrompt = ResetOnPrompt;
		dataGridViewMaskedTextBoxCell.ResetOnSpace = ResetOnSpace;
		dataGridViewMaskedTextBoxCell.AllowPromptAsInput = AllowPromptAsInput;
		return dataGridViewMaskedTextBoxCell;
	}

	/// <summary>
	/// Returns a string that describes the current object.
	/// </summary>
	/// <returns>
	/// A string that represents the current object.
	/// </returns>
	public override string ToString()
	{
		return "DataGridViewMaskedTextBoxCell { ColumnIndex=" + base.ColumnIndex + ", RowIndex=" + base.RowIndex + " }";
	}

	/// <summary>Returns the formatted string that includes all the assigned character values.</summary>
	/// <returns>The formatted <see cref="T:System.String"></see> that includes all the assigned character values.</returns>
	private string GetTextOutput()
	{
		return GetTextOutput(base.ValueText);
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
		switch (TextMaskFormat)
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
		return GetTextOutput(strValue, Mask, PromptChar, blnIncludeLiterals, blnIncludePrompt, AllowPromptAsInput, ResetOnPrompt, ResetOnSpace);
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
		StringBuilder stringBuilder = new StringBuilder();
		string mask = Mask;
		if (!string.IsNullOrEmpty(mask))
		{
			string text = mask;
			foreach (char c in text)
			{
				switch (c)
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
					stringBuilder.Append(c);
					break;
				}
			}
		}
		return stringBuilder.ToString();
	}

	/// <summary>Sets the value of the cell. </summary>
	/// <returns>true if the value has been set; otherwise, false.</returns>
	/// <param name="intRowIndex">The index of the cell's parent row. </param>
	/// <param name="objValue">The cell value to set. </param>
	/// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0.</exception>
	/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
	protected override bool SetValue(int intRowIndex, object objValue)
	{
		string mask = Mask;
		string strValue = string.Empty;
		if (objValue != null)
		{
			strValue = objValue.ToString();
		}
		if (!string.IsNullOrEmpty(mask))
		{
			objValue = GetTextOutput(strValue, mask, PromptChar, blnIncludeLiterals: false, blnIncludePrompt: false, AllowPromptAsInput, ResetOnPrompt, ResetOnSpace);
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
		object value = base.GetValue(intRowIndex);
		if (value != null)
		{
			string text = string.Empty;
			if (value != null)
			{
				text = value.ToString();
			}
			if (string.IsNullOrEmpty(Mask) || !UseTextMaskFormat)
			{
				return text;
			}
			return GetTextOutput(text);
		}
		return value;
	}

	/// <summary>
	/// Renders the cell text/value.
	/// </summary>
	/// <param name="objContext">The context.</param>
	/// <param name="objWriter">The writer.</param>
	/// <param name="objFormatedValue">The formated value.</param>
	protected override void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
	{
		string mask = Mask;
		string text = base.ValueText;
		if (!string.IsNullOrEmpty(mask))
		{
			text = GetTextOutput(text, mask, PromptChar, blnIncludeLiterals: true, !HidePromptOnLeave, AllowPromptAsInput, ResetOnPrompt, ResetOnSpace);
		}
		if (!string.IsNullOrEmpty(text))
		{
			objWriter.WriteAttributeText("VLB", text);
		}
	}

	/// <summary>
	/// </summary>
	/// <param name="objContext"></param>
	/// <param name="objWriter"></param>
	/// <param name="blnRenderOwner"></param>
	protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
	{
		base.RenderAttributes(objContext, objWriter, blnRenderOwner);
		string mask = Mask;
		if (mask != string.Empty)
		{
			objWriter.WriteAttributeString("MK", GetFormatedMask());
		}
		if (HidePromptOnLeave)
		{
			objWriter.WriteAttributeString("HPOL", "1");
		}
		if (!ResetOnSpace)
		{
			objWriter.WriteAttributeString("ROS", "0");
		}
		if (!ResetOnPrompt)
		{
			objWriter.WriteAttributeString("ROP", "0");
		}
		if (!AllowPromptAsInput)
		{
			objWriter.WriteAttributeString("API", "0");
		}
		objWriter.WriteAttributeString("PC", PromptChar.ToString());
	}
}
