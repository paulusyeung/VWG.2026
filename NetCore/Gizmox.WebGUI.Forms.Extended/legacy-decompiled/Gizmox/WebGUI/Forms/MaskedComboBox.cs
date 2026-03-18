using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;

namespace Gizmox.WebGUI.Forms;

/// <summary>
///
/// </summary>
[Serializable]
[ToolboxBitmap(typeof(MaskedComboBox), "Extended.MaskedComboBox_45.png")]
[DesignTimeController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
[ClientController("Gizmox.WebGUI.Forms.Extended.Design.Controllers.MaskedComboBoxController, Gizmox.WebGUI.Forms.Extended.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=63e79e6cd5280864")]
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

	/// <summary>
	/// The prompt character to use in the displayed masked text
	/// </summary>
	private const char mcntPromptChar = '_';

	/// <summary>
	/// Gets or sets the input mask to use at run time. 
	/// </summary>
	/// <returns>A <see cref="T:System.String"></see> representing the current mask. The default value is the empty string which allows any input.</returns>
	/// <exception cref="T:System.ArgumentException">The string supplied to the <see cref="P:Gizmox.WebGUI.Forms.MaskedComboBox.Mask"></see> property is not a valid mask. Invalid masks include masks containing non-printable characters.</exception> 
	[Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[Localizable(true)]
	[RefreshProperties(RefreshProperties.Repaint)]
	[DefaultValue("")]
	public string Mask
	{
		get
		{
			return GetValue(MaskProperty, string.Empty);
		}
		set
		{
			if (Mask != value)
			{
				if (value != string.Empty)
				{
					SetValue(MaskProperty, value);
				}
				else
				{
					RemoveValue<string>(MaskProperty);
				}
				string text = base.Text;
				string textOutput = GetTextOutput(base.Text, Mask, PromptChar, blnIncludeLiterals: false, blnIncludePrompt: false, AllowPromptAsInput, ResetOnPrompt, ResetOnSpace);
				if (textOutput != text)
				{
					base.Text = textOutput;
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
			return GetValue(PromptCharProperty, '_');
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
				MaskedTextProvider maskedTextProvider = GetMaskedTextProvider(base.Text, Mask, promptChar, blnIncludeLiterals: true, blnIncludePrompt: true, AllowPromptAsInput, ResetOnPrompt, ResetOnSpace);
				maskedTextProvider.PromptChar = value;
				Text = maskedTextProvider.ToString();
				if (value != '_')
				{
					SetValue(PromptCharProperty, value);
				}
				else
				{
					RemoveValue<char>(PromptCharProperty);
				}
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
			return GetValue(HidePromptOnLeaveProperty, objDefault: false);
		}
		set
		{
			if (HidePromptOnLeave != value)
			{
				if (value)
				{
					SetValue(HidePromptOnLeaveProperty, value);
				}
				else
				{
					RemoveValue<bool>(HidePromptOnLeaveProperty);
				}
				Update();
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
			return GetValue<bool>(AllowPromptAsInputProperty);
		}
		set
		{
			if (SetValue(AllowPromptAsInputProperty, value))
			{
				UpdateParams(AttributeType.Control);
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
			return GetValue<bool>(ResetOnPromptProperty);
		}
		set
		{
			if (SetValue(ResetOnPromptProperty, value))
			{
				UpdateParams(AttributeType.Control);
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
			return GetValue<bool>(ResetOnSpaceProperty);
		}
		set
		{
			if (SetValue(ResetOnSpaceProperty, value))
			{
				UpdateParams(AttributeType.Control);
			}
		}
	}

	/// <summary>
	/// Gets or sets the text associated with this control.  
	/// </summary>
	[DefaultValue("")]
	[Localizable(true)]
	[Bindable(true)]
	public override string Text
	{
		get
		{
			if (!string.IsNullOrEmpty(Mask))
			{
				if (base.DesignMode || string.IsNullOrEmpty(Mask) || !UseTextMaskFormat)
				{
					return base.Text;
				}
				return GetTextOutput();
			}
			return base.Text;
		}
		set
		{
			if (!string.IsNullOrEmpty(Mask))
			{
				UseTextMaskFormat = false;
				if (base.Text != value)
				{
					string mask = Mask;
					if (string.IsNullOrEmpty(mask))
					{
						base.Text = value;
					}
					else
					{
						base.Text = GetTextOutput(value, mask, PromptChar, blnIncludeLiterals: false, blnIncludePrompt: false, AllowPromptAsInput, ResetOnPrompt, ResetOnSpace);
					}
				}
				UseTextMaskFormat = true;
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
			return GetValue(UseTextMaskFormatProperty, objDefault: true);
		}
		set
		{
			if (UseTextMaskFormat != value)
			{
				if (!value)
				{
					SetValue(UseTextMaskFormatProperty, value);
				}
				else
				{
					RemoveValue<bool>(UseTextMaskFormatProperty);
				}
			}
		}
	}

	/// <summary>
	/// Masked ComboBox does not implement CharacterCasing
	///
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	[DefaultValue(CharacterCasing.Normal)]
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
	[DefaultValue(MaskFormat.IncludeLiterals)]
	[Category("Behavior")]
	[Description("Indicates whether the string returned from the Text property includes literals and/or prompt characters.")]
	public MaskFormat TextMaskFormat
	{
		get
		{
			return GetValue(TextMaskFormatProperty, MaskFormat.IncludeLiterals);
		}
		set
		{
			if (TextMaskFormat != value)
			{
				if (value != MaskFormat.IncludeLiterals)
				{
					SetValue(TextMaskFormatProperty, value);
				}
				else
				{
					RemoveValue<MaskFormat>(TextMaskFormatProperty);
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

	/// <summary>
	/// Fires an event.
	/// </summary>
	/// <param name="objEvent">event.</param>
	protected override void FireEvent(IEvent objEvent)
	{
		if (!string.IsNullOrEmpty(Mask) && objEvent.Type == "ValueChange" && string.IsNullOrEmpty(objEvent["VLB"]))
		{
			Text = CommonUtils.DecodeText(objEvent["TX"]);
		}
		else
		{
			base.FireEvent(objEvent);
		}
	}

	/// <summary>
	/// Render the text attrbute.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	protected override void RenderText(IAttributeWriter objWriter)
	{
		if (string.IsNullOrEmpty(Mask))
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
		base.RenderAttributes(objContext, objWriter);
		string mask = Mask;
		if (!string.IsNullOrEmpty(mask))
		{
			objWriter.WriteAttributeString("MK", GetFormatedMask(mask));
			if (HidePromptOnLeave)
			{
				objWriter.WriteAttributeString("HPOL", "1");
			}
			RenderResetOnSpaceAttribute(objWriter, blnForceRender: false);
			RenderResetOnPromptAttribute(objWriter, blnForceRender: false);
			RenderAllowPromptAsInputAttribute(objWriter, blnForceRender: false);
			objWriter.WriteAttributeString("PC", PromptChar.ToString());
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
		base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
		if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
		{
			RenderResetOnSpaceAttribute(objWriter, blnForceRender: true);
			RenderResetOnPromptAttribute(objWriter, blnForceRender: true);
			RenderAllowPromptAsInputAttribute(objWriter, blnForceRender: true);
		}
	}

	/// <summary>
	/// Renders the ResetOnSpace attribute.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	/// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
	private void RenderResetOnSpaceAttribute(IAttributeWriter objWriter, bool blnForceRender)
	{
		if (!ResetOnSpace || blnForceRender)
		{
			objWriter.WriteAttributeString("ROS", ResetOnSpace ? "1" : "0");
		}
	}

	/// <summary>
	/// Renders the ResetOnPrompt attribute.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	/// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
	private void RenderResetOnPromptAttribute(IAttributeWriter objWriter, bool blnForceRender)
	{
		if (!ResetOnPrompt || blnForceRender)
		{
			objWriter.WriteAttributeString("ROP", ResetOnPrompt ? "1" : "0");
		}
	}

	/// <summary>
	/// Renders the AllowPromptAsInput attribute.
	/// </summary>
	/// <param name="objWriter">The obj writer.</param>
	/// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
	private void RenderAllowPromptAsInputAttribute(IAttributeWriter objWriter, bool blnForceRender)
	{
		if (!AllowPromptAsInput || blnForceRender)
		{
			objWriter.WriteAttributeString("API", AllowPromptAsInput ? "1" : "0");
		}
	}

	/// <summary>
	/// Renders the value.
	/// </summary>
	/// <param name="objWriter">The writer.</param>
	protected override void RenderValue(IAttributeWriter objWriter)
	{
		string mask = Mask;
		if (!string.IsNullOrEmpty(mask))
		{
			string empty = string.Empty;
			empty = (string.IsNullOrEmpty(mask) ? base.Text : GetTextOutput(base.Text, mask, PromptChar, blnIncludeLiterals: true, !HidePromptOnLeave, AllowPromptAsInput, ResetOnPrompt, ResetOnSpace));
			if (!string.IsNullOrEmpty(empty))
			{
				objWriter.WriteAttributeString("VLB", empty);
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
		InvokeMethodWithId("Common_MaskExecute", "Select", intStart, intLength);
	}

	/// <summary>Returns the formatted string that includes all the assigned character values.</summary>
	/// <returns>The formatted <see cref="T:System.String"></see> that includes all the assigned character values.</returns>
	private string GetTextOutput()
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
		return GetTextOutput(base.Text, Mask, PromptChar, blnIncludeLiterals, blnIncludePrompt, AllowPromptAsInput, ResetOnPrompt, ResetOnSpace);
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
		if (!string.IsNullOrEmpty(strValue))
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
		StringBuilder stringBuilder = new StringBuilder();
		if (!string.IsNullOrEmpty(strMask))
		{
			foreach (char c in strMask)
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
}
