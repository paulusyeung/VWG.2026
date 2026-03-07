#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
	/// 
	/// Uses a mask to distinguish between proper and improper user input.
	/// </summary>
	[Serializable]
	[SRDescription("DescriptionMaskedTextBox")]
	[DefaultProperty("Mask")]
	[ToolboxItemCategory("Common Controls")]
	[ToolboxBitmap(typeof(TextBox), "MaskedTextBox_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.MaskedTextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.MaskedTextBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[Skin(typeof(MaskedTextBoxSkin))]
	public class MaskedTextBox : TextBox
	{
		/// 
		/// Provides a property reference to TextMaskFormat property.
		/// </summary>
		private static SerializableProperty TextMaskFormatProperty = SerializableProperty.Register("TextMaskFormat", typeof(MaskFormat), typeof(MaskedTextBox), new SerializablePropertyMetadata(MaskFormat.IncludeLiterals));

		/// 
		/// Provides a property reference to UseTextMaskFormat property.
		/// </summary>
		private static SerializableProperty UseTextMaskFormatProperty = SerializableProperty.Register("UseTextMaskFormat", typeof(bool), typeof(MaskedTextBox));

		/// 
		/// Provides a property reference to HidePromptOnLeave property.
		/// </summary>
		private static SerializableProperty HidePromptOnLeaveProperty = SerializableProperty.Register("HidePromptOnLeave", typeof(bool), typeof(MaskedTextBox));

		/// 
		/// Provides a property reference to PromptChar property.
		/// </summary>
		private static SerializableProperty PromptCharProperty = SerializableProperty.Register("PromptChar", typeof(char), typeof(MaskedTextBox));

		/// 
		/// Provides a property reference to Mask property.
		/// </summary>
		private static SerializableProperty MaskProperty = SerializableProperty.Register("Mask", typeof(string), typeof(MaskedTextBox));

		/// 
		/// Provides a property reference to ResetOnPrompt property.
		/// </summary>
		private static SerializableProperty ResetOnPromptProperty = SerializableProperty.Register("ResetOnPrompt", typeof(bool), typeof(MaskedTextBox), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to AllowPromptAsInput property.
		/// </summary>
		private static SerializableProperty AllowPromptAsInputProperty = SerializableProperty.Register("AllowPromptAsInput", typeof(bool), typeof(MaskedTextBox), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to ResetOnSpace property.
		/// </summary>
		private static SerializableProperty ResetOnSpaceProperty = SerializableProperty.Register("ResetOnSpace", typeof(bool), typeof(MaskedTextBox), new SerializablePropertyMetadata(true));

		/// 
		/// The prompt character to use in the displayed masked text
		/// </summary>
		private const char mcntPromptChar = '_';

		/// 
		/// Gets or sets the input mask to use at run time. 
		/// </summary>
		/// A <see cref="T:System.String"></see> representing the current mask. The default value is the empty string which allows any input.</returns>
		/// <exception cref="T:System.ArgumentException">The string supplied to the <see cref="P:Gizmox.WebGUI.Forms.MaskedTextBox.Mask"></see> property is not a valid mask. Invalid masks include masks containing non-printable characters.</exception> 
		[Editor("Gizmox.WebGUI.Forms.Design.MaskEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		[SRDescription("MaskedTextBoxMaskDescr")]
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
						RemoveValue(MaskProperty);
					}
					string text = base.Text;
					string textOutput = GetTextOutput(base.Text, Mask, PromptChar, blnIncludeLiterals: false, blnIncludePrompt: false, AllowPromptAsInput, ResetOnPrompt, ResetOnSpace);
					if (textOutput != text)
					{
						base.InternalText = textOutput;
					}
					Update();
				}
			}
		}

		/// Gets or sets the character used to represent the absence of user input in <see cref="T:System.Windows.Forms.MaskedTextBox"></see>.</summary>
		/// The character used to prompt the user for input. The default is an underscore (_). </returns>
		/// <exception cref="T:System.InvalidOperationException">The prompt character specified is the same as the current password character, <see cref="P:System.Windows.Forms.MaskedTextBox.PasswordChar"></see>. The two are required to be different.</exception>
		/// <exception cref="T:System.ArgumentException">The character specified when setting this property is not a valid prompt character, as determined by the <see cref="M:System.ComponentModel.MaskedTextProvider.IsValidPasswordChar(System.Char)"></see> method of the <see cref="T:System.ComponentModel.MaskedTextProvider"></see> class.</exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Localizable(true)]
		[SRCategory("CatAppearance")]
		[SRDescription("MaskedTextBoxPromptCharDescr")]
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
					throw new ArgumentException(SR.GetString("MaskedTextBoxInvalidCharError"));
				}
				char promptChar = PromptChar;
				if (promptChar != value)
				{
					MaskedTextProvider maskedTextProvider = GetMaskedTextProvider(base.Text, Mask, promptChar, blnIncludeLiterals: true, blnIncludePrompt: true, AllowPromptAsInput, ResetOnPrompt, ResetOnSpace);
					maskedTextProvider.PromptChar = value;
					InternalText = maskedTextProvider.ToString();
					if (value != '_')
					{
						SetValue(PromptCharProperty, value);
					}
					else
					{
						RemoveValue(PromptCharProperty);
					}
					Update();
				}
			}
		}

		/// Gets or sets a value indicating whether the prompt characters in the input mask are hidden when the masked text box loses focus.</summary>
		/// true if <see cref="P:System.Windows.Forms.MaskedTextBox.PromptChar"></see> is hidden when <see cref="T:System.Windows.Forms.MaskedTextBox"></see> does not have focus; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		[SRDescription("MaskedTextBoxHidePromptOnLeaveDescr")]
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
						RemoveValue(HidePromptOnLeaveProperty);
					}
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether System.Windows.Forms.MaskedTextBox.PromptChar
		/// can be entered as valid data by the user.
		/// </summary>
		/// 
		///   true</c> if the user can enter the prompt character into the control; otherwise, false</c>.
		/// </value>
		[SRCategory("CatBehavior")]
		[SRDescription("MaskedTextBoxAllowPromptAsInputDescr")]
		[DefaultValue(true)]
		public bool AllowPromptAsInput
		{
			get
			{
				return GetValue(AllowPromptAsInputProperty);
			}
			set
			{
				if (SetValue(AllowPromptAsInputProperty, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets a value that determines how an input character that matches
		/// the prompt character should be handled.
		/// </summary>
		/// 
		///   true</c> if the prompt character entered as input causes the current editable
		///     position in the mask to be reset; otherwise, false</c>.to indicate that the prompt
		///     character is to be processed as a normal input character
		/// </value>
		[SRDescription("MaskedTextBoxResetOnPrompt")]
		[DefaultValue(true)]
		[SRCategory("CatBehavior")]
		public bool ResetOnPrompt
		{
			get
			{
				return GetValue(ResetOnPromptProperty);
			}
			set
			{
				if (SetValue(ResetOnPromptProperty, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [reset on space].
		/// </summary>
		/// 
		///   true</c> if [reset on space]; otherwise, false</c>.
		/// </value>
		[SRDescription("MaskedTextBoxResetOnSpace")]
		[DefaultValue(true)]
		[SRCategory("CatBehavior")]
		public bool ResetOnSpace
		{
			get
			{
				return GetValue(ResetOnSpaceProperty);
			}
			set
			{
				if (SetValue(ResetOnSpaceProperty, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets the text associated with this control.  
		/// </summary>
		[DefaultValue("")]
		[SRCategory("CatAppearance")]
		[SRDescription("ControlTextDescr")]
		[Localizable(true)]
		[Bindable(true)]
		public override string Text
		{
			get
			{
				if (base.DesignMode || string.IsNullOrEmpty(Mask) || !UseTextMaskFormat)
				{
					return base.Text;
				}
				return GetTextOutput();
			}
			set
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
		}

		/// 
		/// Gets or sets a value indicating whether to use text mask format.
		/// </summary>
		/// true</c> if use text mask format; otherwise, false</c>.</value>
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
						RemoveValue(UseTextMaskFormatProperty);
					}
				}
			}
		}

		/// 
		/// Defines how Text property should be formatted
		/// </summary>
		[DefaultValue(MaskFormat.IncludeLiterals)]
		[SRCategory("CatBehavior")]
		[SRDescription("MaskedTextBoxTextMaskFormat")]
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
						RemoveValue(TextMaskFormatProperty);
					}
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether text box is multi line.
		/// </summary>
		/// 
		/// 	always false for MaskedTextbox.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

		/// Gets or sets a value indicating whether the user is allowed to reenter literal values.</summary>
		/// true to allow literals to be reentered; otherwise, false to prevent the user from overwriting literal characters. The default is true.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		[SRDescription("MaskedTextBoxSkipLiterals")]
		public bool SkipLiterals
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets a value indicating whether pressing ENTER in a multiline TextBox control creates a new line of text in the control or activates the default button for the form. This property is not supported by MaskedTextBox.
		/// </summary>
		/// 
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

		/// 
		/// Gets or sets a value determining how TAB keys are handled for multiline configurations. This property is not supported by MaskedTextBox.
		/// </summary>
		/// 
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

		/// 
		/// Gets or sets the lines of text in multiline configurations. This property is not supported by MaskedTextBox.
		/// </summary>
		/// 
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

		/// 
		/// Gets or sets a value indicating whether a multiline text box control automatically wraps words to the beginning of the next line when necessary. This property is not supported by MaskedTextBox.
		/// </summary>
		/// 
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

		/// 
		/// Gets or sets the maximum number of characters the user can type or paste into the text box control. This property is not supported by MaskedTextBox.
		/// </summary>
		/// 
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

		/// 
		/// Gets or sets which scroll bars should appear in a multiline TextBox control. This property is not supported by MaskedTextBox.
		/// </summary>
		/// 
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

		/// 
		/// Renders the value.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="blnForceRender">Force render</param>
		protected override void RenderValue(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			string empty = string.Empty;
			string mask = Mask;
			empty = (string.IsNullOrEmpty(mask) ? base.Text : GetTextOutput(base.Text, mask, PromptChar, blnIncludeLiterals: true, !HidePromptOnLeave, AllowPromptAsInput, ResetOnPrompt, ResetOnSpace));
			if (blnForceRender || !string.IsNullOrEmpty(empty))
			{
				objWriter.WriteAttributeText("VLB", empty);
			}
		}

		/// 
		/// Renders the current control attributes.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter">The response writer object.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			string mask = Mask;
			if (mask != string.Empty)
			{
				objWriter.WriteAttributeString("MK", GetFormatedMask());
			}
			if (HidePromptOnLeave)
			{
				objWriter.WriteAttributeString("HPOL", "1");
			}
			RenderResetOnSpaceAttribute(objWriter, blnForceRender: false);
			RenderResetOnPromptAttribute(objWriter, blnForceRender: false);
			RenderAllowPromptAsInputAttribute(objWriter, blnForceRender: false);
			objWriter.WriteAttributeString("PC", PromptChar.ToString());
		}

		/// 
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

		/// 
		/// Renders the ResetOnSpace attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderResetOnSpaceAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (!ResetOnSpace || blnForceRender)
			{
				objWriter.WriteAttributeString("ROS", ResetOnSpace ? "1" : "0");
			}
		}

		/// 
		/// Renders the ResetOnPrompt attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderResetOnPromptAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (!ResetOnPrompt || blnForceRender)
			{
				objWriter.WriteAttributeString("ROP", ResetOnPrompt ? "1" : "0");
			}
		}

		/// 
		/// Renders the AllowPromptAsInput attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderAllowPromptAsInputAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (!AllowPromptAsInput || blnForceRender)
			{
				objWriter.WriteAttributeString("API", AllowPromptAsInput ? "1" : "0");
			}
		}

		/// 
		/// Implements the actual client side selection
		/// </summary>
		/// <param name="intStart"></param>
		/// <param name="intLength"></param>
		protected override void InvokeSelection(int intStart, int intLength)
		{
			InvokeMethodWithId("Common_MaskExecute", "Select", intStart, intLength);
		}

		/// Returns the formatted string that includes all the assigned character values.</summary>
		/// The formatted <see cref="T:System.String"></see> that includes all the assigned character values.</returns>
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

		/// 
		/// Gets the text output.
		/// </summary>
		/// <param name="strValue">The STR value.</param>
		/// <param name="strMask">The STR mask.</param>
		/// <param name="chrPromptChar">The CHR prompt char.</param>
		/// <param name="blnIncludeLiterals">if set to true</c> [BLN include literals].</param>
		/// <param name="blnIncludePrompt">if set to true</c> [BLN include prompt].</param>
		/// </returns>
		private string GetTextOutput(string strValue, string strMask, char chrPromptChar, bool blnIncludeLiterals, bool blnIncludePrompt, bool blnAllowPromptAsInput, bool blnResetOnPrompt, bool blnResetOnSpace)
		{
			MaskedTextProvider maskedTextProvider = GetMaskedTextProvider(strValue, strMask, chrPromptChar, blnIncludeLiterals, blnIncludePrompt, blnAllowPromptAsInput, blnResetOnPrompt, blnResetOnSpace);
			return maskedTextProvider.ToString();
		}

		/// 
		/// Gets the masked text provider.
		/// </summary>
		/// <param name="strValue">The text value.</param>
		/// <param name="strMask">The mask value.</param>
		/// <param name="chrPromptChar">The prompt char.</param>
		/// <param name="blnIncludeLiterals">if set to true</c> [BLN include literals].</param>
		/// <param name="blnIncludePrompt">if set to true</c> [include prompt].</param>
		/// </returns>
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

		/// 
		/// Gets formated cultured mask.
		/// </summary>
		/// </returns>
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

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.MaskedTextBox"></see> class using defaults.
		/// </summary>
		public MaskedTextBox()
		{
			CustomStyle = "Masked";
		}
	}
}
