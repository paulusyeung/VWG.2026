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
	/// Implementation of TextBox class.
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(TextBox), "TextBox_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.TextBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.TextBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolboxItem(true)]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("T")]
	[Skin(typeof(TextBoxSkin))]
	public class TextBox : TextBoxBase
	{
		/// 
		/// Provides a property reference to CharacterCasing property.
		/// </summary>
		private static SerializableProperty CharacterCasingProperty = SerializableProperty.Register("CharacterCasing", typeof(CharacterCasing), typeof(TextBox));

		/// 
		/// Provides a property reference to Validator property.
		/// </summary>
		private static SerializableProperty ValidatorProperty = SerializableProperty.Register("Validator", typeof(TextBoxValidation), typeof(TextBox));

		/// 
		/// Provides a property reference to PasswordChar property.
		/// </summary>
		private static SerializableProperty PasswordCharProperty = SerializableProperty.Register("PasswordChar", typeof(char), typeof(TextBox));

		/// 
		/// Provides a property reference to UseSystemPasswordChar property.
		/// </summary>
		private static SerializableProperty UseSystemPasswordCharProperty = SerializableProperty.Register("UseSystemPasswordChar", typeof(bool), typeof(TextBox));

		/// 
		/// Provides a property reference to ScrollBars property.
		/// </summary>
		private static SerializableProperty ScrollBarsProperty = SerializableProperty.Register("ScrollBars", typeof(ScrollBars), typeof(TextBox));

		/// 
		/// Provides a property reference to HorizontalAlignment property.
		/// </summary>
		private static SerializableProperty HorizontalAlignmentProperty = SerializableProperty.Register("HorizontalAlignment", typeof(HorizontalAlignment), typeof(TextBox));

		/// 
		/// The EnterKeyDown event registration.
		/// </summary>
		private static readonly SerializableEvent EnterKeyDownEvent;

		/// 
		/// Gets the hanlder for the EnterKeyDown event.
		/// </summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected KeyEventHandler EnterKeyDownHandler => (KeyEventHandler)GetHandler(EnterKeyDownEvent);

		/// Gets or sets how text is aligned in a <see cref="T:Gizmox.WebGUI.Forms.TextBox"></see> control.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> enumeration values that specifies how text is aligned in the control. The default is HorizontalAlignment.Left.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">A value that is not within the range of valid values for the enumeration was assigned to the property. </exception>
		/// 1</filterpriority>
		[DefaultValue(HorizontalAlignment.Left)]
		[Localizable(true)]
		[SRCategory("CatAppearance")]
		[SRDescription("TextBoxTextAlignDescr")]
		[ProxyBrowsable(true)]
		public HorizontalAlignment TextAlign
		{
			get
			{
				return GetValue(HorizontalAlignmentProperty, HorizontalAlignment.Left);
			}
			set
			{
				if (TextAlign != value)
				{
					SetValue(HorizontalAlignmentProperty, value);
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the text associated with this control.
		/// </summary>
		/// </value>
		public override string Text
		{
			get
			{
				return FormatText(base.Text);
			}
			set
			{
				base.Text = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether pressing ENTER in a multiline TextBox control creates a new line of text in the control or activates the default button for the form.
		/// </summary>
		[DefaultValue(true)]
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

		/// 
		/// Gets or sets which scroll bars should appear in a multiline TextBox control.
		/// </summary>
		/// 
		/// One of the ScrollBars enumeration values that indicates whether a multiline TextBox control appears with no scroll bars, a horizontal scroll bar, a vertical scroll bar, or both. The default is ScrollBars.None.
		/// </value>
		[DefaultValue(ScrollBars.None)]
		[SRCategory("Style")]
		[SRDescription("Scrollbar state definition")]
		public virtual ScrollBars ScrollBars
		{
			get
			{
				return GetValue(ScrollBarsProperty, ScrollBars.None);
			}
			set
			{
				if (value.GetType().Equals(ScrollBars.GetType()) && ScrollBars != value)
				{
					SetValue(ScrollBarsProperty, value);
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the password charecter.
		/// </summary>
		/// </value>
		[DefaultValue('\0')]
		[SRCategory("CatBehavior")]
		[SRDescription("TextBoxPasswordCharDescr")]
		public char PasswordChar
		{
			get
			{
				return GetValue(PasswordCharProperty, '\0');
			}
			set
			{
				if (PasswordChar != value)
				{
					if (value != 0)
					{
						SetValue(PasswordCharProperty, value);
					}
					else
					{
						RemoveValue(PasswordCharProperty);
					}
					Update();
				}
			}
		}

		/// Gets or sets a value indicating whether the text in the <see cref="T:System.Windows.Forms.TextBox"></see> control should appear as the default password character.</summary>
		/// true if the text in the <see cref="T:System.Windows.Forms.TextBox"></see> control should appear as the default password character; otherwise, false.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		[SRDescription("TextBoxUseSystemPasswordCharDescr")]
		public bool UseSystemPasswordChar
		{
			get
			{
				return GetValue(UseSystemPasswordCharProperty, objDefault: false);
			}
			set
			{
				if (UseSystemPasswordChar != value)
				{
					if (value)
					{
						SetValue(UseSystemPasswordCharProperty, value);
					}
					else
					{
						RemoveValue(UseSystemPasswordCharProperty);
					}
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the text box validator.
		/// </summary>
		/// </value>
		[DefaultValue(null)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public TextBoxValidation Validator
		{
			get
			{
				return GetValue(ValidatorProperty);
			}
			set
			{
				if (Validator != value)
				{
					Update();
					SetValue(ValidatorProperty, value);
				}
			}
		}

		/// Gets a value indicating whether the user can undo the previous operation in a text box control.</summary>
		/// true if the user can undo the previous operation performed in a text box control; otherwise, false.</returns>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("TextBoxCanUndoDescr")]
		[Browsable(false)]
		public bool CanUndo => false;

		/// 
		/// Indicates if all characters should be left alone or converted to uppercase or lowercase
		/// </summary>
		/// </value>
		[SRCategory("CatBehavior")]
		[SRDescription("TextBoxCharacterCasingDescr")]
		[DefaultValue(CharacterCasing.Normal)]
		public CharacterCasing CharacterCasing
		{
			get
			{
				return GetValue(CharacterCasingProperty, CharacterCasing.Normal);
			}
			set
			{
				if (CharacterCasing != value)
				{
					if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
					{
						throw new InvalidEnumArgumentException("value", (int)value, typeof(CharacterCasing));
					}
					SetValue(CharacterCasingProperty, value);
					Update();
				}
			}
		}

		/// 
		/// Gets the default size.
		/// </summary>
		/// The default size.</value>
		protected override Size DefaultSize => new Size(100, 20);

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
		/// </summary>
		/// true</c> if focusable; otherwise, false</c>.</value>
		protected override bool Focusable => true;

		/// Gets or sets a value specifying the source of complete strings used for automatic completion.</summary>
		/// One of the values of <see cref="T:System.Windows.Forms.AutoCompleteSource"></see>. The options are AllSystemSources, AllUrl, FileSystem, HistoryList, RecentlyUsedList, CustomSource, and None. The default is None.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not one of the values of <see cref="T:System.Windows.Forms.AutoCompleteSource"></see>. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(AutoCompleteSource.None)]
		[SRDescription("TextBoxAutoCompleteSourceDescr")]
		public AutoCompleteSource AutoCompleteSource
		{
			get
			{
				return AutoCompleteSource.None;
			}
			set
			{
			}
		}

		/// 
		/// Gets the win forms compatibility.
		/// </summary>
		/// 
		/// The win forms compatibility.
		/// </value>
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new TextBoxWinFormsCompatibility WinFormsCompatibility => base.WinFormsCompatibility as TextBoxWinFormsCompatibility;

		/// 
		/// Occurs on enter key down only on single line.
		/// </summary>
		public event KeyEventHandler EnterKeyDown
		{
			add
			{
				AddCriticalHandler(EnterKeyDownEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(EnterKeyDownEvent, value);
			}
		}

		/// 
		/// Occurs when [client enter key down].
		/// </summary>
		[SRDescription("Occurs when enter key pressed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientEnterKeyDown
		{
			add
			{
				AddClientHandler("EnterKeyDown", value);
			}
			remove
			{
				RemoveClientHandler("EnterKeyDown", value);
			}
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.TextBox" /> instance.
		/// </summary>
		public TextBox()
		{
		}

		/// 
		/// Formats the text.
		/// </summary>
		/// <param name="strValue">The text value.</param>
		/// </returns>
		private string FormatText(string strValue)
		{
			if (!string.IsNullOrEmpty(strValue))
			{
				switch (CharacterCasing)
				{
				case CharacterCasing.Lower:
					return strValue.ToLowerInvariant();
				case CharacterCasing.Upper:
					return strValue.ToUpperInvariant();
				}
			}
			return strValue;
		}

		/// 
		/// Set the value from the clip board
		/// </summary>
		/// <param name="strValue"></param>
		protected override void SetClipboardContent(string strValue)
		{
			SelectedText = strValue;
		}

		/// 
		/// Get content to be added to the clip board 
		/// </summary>
		/// </returns>
		protected override string GetClipboardContent()
		{
			return SelectedText;
		}

		/// Undoes the last edit operation in the text box.</summary>
		public void Undo()
		{
		}

		/// 
		/// Implements the actual client side selection
		/// </summary>
		/// <param name="intStart"></param>
		/// <param name="intLength"></param>
		protected override void InvokeSelection(int intStart, int intLength)
		{
			InvokeMethodWithId("TextBox_Execute", "Select", intStart, intLength);
		}

		/// 
		/// Renders the current control attributes.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter">The response writer object.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			TextBoxValidation textBoxValidation = null;
			base.RenderAttributes(objContext, objWriter);
			HorizontalAlignment proxyPropertyValue = GetProxyPropertyValue("TextAlign", TextAlign);
			if (proxyPropertyValue != HorizontalAlignment.Left)
			{
				objWriter.WriteAttributeString("TA", proxyPropertyValue.ToString());
			}
			if (PasswordChar != 0 || UseSystemPasswordChar)
			{
				objWriter.WriteAttributeString("PWD", "1");
			}
			textBoxValidation = Validator;
			if (textBoxValidation != null)
			{
				if (textBoxValidation.ValueValidationExpression != string.Empty)
				{
					objWriter.WriteAttributeString("VVE", textBoxValidation.ValueValidationExpression);
				}
				if (textBoxValidation.CharacterValidationMask != string.Empty)
				{
					objWriter.WriteAttributeString("CVM", textBoxValidation.CharacterValidationMask);
				}
				if (textBoxValidation.CharacterValidationExpression != string.Empty)
				{
					objWriter.WriteAttributeString("CVE", textBoxValidation.CharacterValidationExpression);
				}
				if (textBoxValidation.InValidateMessage != string.Empty)
				{
					objWriter.WriteAttributeText("IVM", textBoxValidation.InValidateMessage);
				}
			}
			CharacterCasing characterCasing = CharacterCasing;
			if (characterCasing != CharacterCasing.Normal)
			{
				byte b = (byte)characterCasing;
				objWriter.WriteAttributeString("CC", b.ToString());
			}
			if (Multiline && ScrollBars != ScrollBars.None)
			{
				objWriter.WriteAttributeString("SB", Convert.ToInt32(ScrollBars).ToString());
			}
			objWriter.WriteAttributeString("GROTB", WinFormsCompatibility.IsGrayedReadOnlyTextBox ? "1" : "0");
		}

		/// 
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
				objWriter.WriteAttributeString("GROTB", WinFormsCompatibility.IsGrayedReadOnlyTextBox ? "1" : "0");
			}
		}

		/// 
		/// Renders the value.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderValue(IContext objContext, IAttributeWriter objWriter, bool blnForceReder)
		{
			string text = Text;
			if (!string.IsNullOrEmpty(text) || blnForceReder)
			{
				objWriter.WriteAttributeText("VLB", text, (!Multiline) ? ((TextFilter)5) : TextFilter.None);
			}
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new TextBoxRenderer(this);
		}

		/// 
		/// Gets the win forms compatibility.
		/// </summary>
		/// </returns>
		protected override WinFormsCompatibility GetWinFormsCompatibility()
		{
			return new TextBoxWinFormsCompatibility();
		}

		/// 
		/// Called when WinFormsCompatibility option value is changed.
		/// </summary>
		protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
		{
			if (strChangedOptionName == "GrayedReadOnlyTextBox")
			{
				UpdateParams(AttributeType.Control);
			}
			base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (EnterKeyDownHandler != null)
			{
				criticalEventsData.Set("EKD");
			}
			return criticalEventsData;
		}

		/// 
		/// Gets the critical client events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			if (HasClientHandler("EnterKeyDown"))
			{
				criticalClientEventsData.Set("EKD");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			string type = objEvent.Type;
			if (type == "EnterKeyDown" && EnterKeyDownHandler != null)
			{
				EnterKeyDownHandler(this, new KeyEventArgs(Keys.Enter));
			}
			base.FireEvent(objEvent);
		}

		static TextBox()
		{
			EnterKeyDownEvent = SerializableEvent.Register("EnterKeyDown", typeof(KeyEventHandler), typeof(TextBox));
		}
	}
}
