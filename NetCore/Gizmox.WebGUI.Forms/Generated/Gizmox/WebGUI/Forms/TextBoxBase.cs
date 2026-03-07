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
	/// Implements the basic functionality required by text controls.
	/// </summary>    
	[Serializable]
	[Skin(typeof(TextBoxBaseSkin))]
	[DefaultEvent("TextChanged")]
	public abstract class TextBoxBase : Control
	{
		/// 
		/// Provides a property reference to SelectionLength property.
		/// </summary>
		private static SerializableProperty SelectionLengthProperty = SerializableProperty.Register("SelectionLength", typeof(int), typeof(TextBoxBase), new SerializablePropertyMetadata(0));

		/// 
		/// Provides a property reference to AcceptsTab property.
		/// </summary>
		private static SerializableProperty AcceptsTabProperty = SerializableProperty.Register("AcceptsTab", typeof(bool), typeof(TextBoxBase), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to WordWrap property.
		/// </summary>
		private static SerializableProperty WordWrapProperty = SerializableProperty.Register("WordWrap", typeof(bool), typeof(TextBoxBase), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to Multiline property.
		/// </summary>
		private static SerializableProperty MultilineProperty = SerializableProperty.Register("Multiline", typeof(bool), typeof(TextBoxBase), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to MaxLength property.
		/// </summary>
		private static SerializableProperty MaxLengthProperty = SerializableProperty.Register("MaxLength", typeof(int), typeof(TextBoxBase), new SerializablePropertyMetadata(0));

		/// 
		/// Provides a property reference to SelectionStart property.
		/// </summary>
		private static SerializableProperty SelectionStartProperty = SerializableProperty.Register("SelectionStart", typeof(int), typeof(TextBoxBase), new SerializablePropertyMetadata(0));

		/// 
		/// Provides a property reference to HideSelection property.
		/// </summary>
		private static SerializableProperty HideSelectionProperty = SerializableProperty.Register("HideSelection", typeof(bool), typeof(TextBoxBase), new SerializablePropertyMetadata(true));

		/// 
		///
		/// </summary>
		private static SerializableProperty IsAutoCompleteProperty = SerializableProperty.Register("IsAutoComplete", typeof(bool), typeof(TextBoxBase), new SerializablePropertyMetadata(true));

		/// 
		/// Gets or sets a value indicating whether this instance is auto complete.
		/// </summary>
		/// 
		/// 	true</c> if this instance is auto complete; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public bool IsAutoComplete
		{
			get
			{
				return GetValue(IsAutoCompleteProperty);
			}
			set
			{
				if (SetValue(IsAutoCompleteProperty, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// Gets the length of text in the control.</summary>
		/// The number of characters contained in the text of the control.</returns>
		[Browsable(false)]
		public virtual int TextLength => Text.Length;

		/// 
		/// Gets or sets the text associated with this control.
		/// </summary>
		/// </value>
		[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
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

		/// Gets or sets a value indicating the currently selected text in the control.</summary>
		/// A string that represents the currently selected text in the text box.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRCategory("CatAppearance")]
		[SRDescription("TextBoxSelectedTextDescr")]
		[Browsable(false)]
		public virtual string SelectedText
		{
			get
			{
				if (Text == null)
				{
					return "";
				}
				return Text.Substring(SelectionStart, SelectionLength);
			}
			set
			{
				SetSelectedTextInternal(value, blnClearUndo: true);
			}
		}

		/// Gets or sets the number of characters selected in the text box.</summary>
		/// The number of characters selected in the text box.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is less than zero.</exception>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRDescription("TextBoxSelectionLengthDescr")]
		[SRCategory("CatAppearance")]
		[Browsable(false)]
		public virtual int SelectionLength
		{
			get
			{
				return GetValue(SelectionLengthProperty);
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("SelectionLength", SR.GetString("InvalidArgument", "SelectionLength", value.ToString(CultureInfo.CurrentCulture)));
				}
				if (SetValue(SelectionLengthProperty, value))
				{
					InvokeSelection(SelectionStart, value);
				}
			}
		}

		/// Gets or sets the starting point of text selected in the text box.</summary>
		/// The starting position of text selected in the text box.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The assigned value is less than zero.</exception>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRCategory("CatAppearance")]
		[SRDescription("TextBoxSelectionStartDescr")]
		public int SelectionStart
		{
			get
			{
				return GetValue(SelectionStartProperty);
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("SelectionStart", SR.GetString("InvalidArgument", "SelectionStart", value.ToString(CultureInfo.CurrentCulture)));
				}
				if (SetValue(SelectionStartProperty, value))
				{
					InvokeSelection(value, SelectionLength);
				}
			}
		}

		/// 
		/// Gets or sets the maximum number of characters the user can type or paste into the text box control.
		/// </summary>
		/// 
		/// The number of characters that can be entered into the control. The default is 0.
		/// </value>
		[Localizable(true)]
		[SRDescription("TextBoxMaxLengthDescr")]
		[DefaultValue(0)]
		[SRCategory("CatBehavior")]
		public virtual int MaxLength
		{
			get
			{
				return GetValue(MaxLengthProperty);
			}
			set
			{
				if (SetValue(MaxLengthProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [read only].
		/// </summary>
		/// 
		/// 	true</c> if [read only]; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRCategory("CatBehavior")]
		[SRDescription("TextBoxReadOnlyDescr")]
		public bool ReadOnly
		{
			get
			{
				return GetState(ComponentState.ReadOnly);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.ReadOnly, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether text box is multi line.
		/// </summary>
		/// 
		/// 	true</c> if multi line otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		[SRDescription("TextBoxMultilineDescr")]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.All)]
		public virtual bool Multiline
		{
			get
			{
				return GetValue(MultilineProperty);
			}
			set
			{
				if (SetValue(MultilineProperty, value))
				{
					Update();
				}
			}
		}

		/// 
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
				string text = Text;
				ArrayList arrayList = new ArrayList();
				int num = 0;
				while (num < text.Length)
				{
					int i;
					for (i = num; i < text.Length; i++)
					{
						char c = text[i];
						if (c == '\r' || c == '\n')
						{
							break;
						}
					}
					string value = text.Substring(num, i - num);
					arrayList.Add(value);
					if (i < text.Length && text[i] == '\r')
					{
						i++;
					}
					if (i < text.Length && text[i] == '\n')
					{
						i++;
					}
					num = i;
				}
				if (text.Length > 0 && (text[text.Length - 1] == '\r' || text[text.Length - 1] == '\n'))
				{
					arrayList.Add("");
				}
				return (string[])arrayList.ToArray(typeof(string));
			}
			set
			{
				if (value != null && value.Length != 0)
				{
					StringBuilder stringBuilder = new StringBuilder(value[0]);
					for (int i = 1; i < value.Length; i++)
					{
						stringBuilder.Append("\r\n");
						stringBuilder.Append(value[i]);
					}
					Text = stringBuilder.ToString();
				}
				else
				{
					Text = "";
				}
			}
		}

		/// 
		/// Indicates whether a multiline text box control automatically wraps words to the beginning of the next line when necessary.
		/// </summary>
		/// 
		/// true if the multiline text box control wraps words; false if the text box control automatically scrolls horizontally when the user types past the right edge of the control. The default is true.
		/// </value>
		[DefaultValue(true)]
		public virtual bool WordWrap
		{
			get
			{
				return GetValue(WordWrapProperty);
			}
			set
			{
				if (SetValue(WordWrapProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether pressing the TAB key in a multiline text box control types a TAB character in the control instead of moving the focus to the next control in the tab order 
		/// </summary>
		[DefaultValue(false)]
		[SRDescription("Gets or sets a value indicating whether pressing the TAB key in a multiline text box control types a TAB character in the control instead of moving the focus to the next control in the tab order.")]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.All)]
		public virtual bool AcceptsTab
		{
			get
			{
				return GetValue(AcceptsTabProperty);
			}
			set
			{
				if (SetValue(AcceptsTabProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
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

		/// 
		/// Gets a value indicating whether raise click event on mouse down.
		/// </summary>
		/// 
		/// 	true</c> if should raise click event on mouse down; otherwise, false</c>.
		/// </value>
		protected override bool ShouldRaiseClickOnRightMouseDown => false;

		/// 
		/// Gets or sets a value indicating whether [hide selection].
		/// </summary>
		/// 
		///   true</c> if [hide selection]; otherwise, false</c>.
		/// </value>        
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool HideSelection
		{
			get
			{
				return GetValue(HideSelectionProperty);
			}
			set
			{
				SetValue(HideSelectionProperty, value);
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
		public new TextBoxBaseWinFormsCompatibility WinFormsCompatibility => base.WinFormsCompatibility as TextBoxBaseWinFormsCompatibility;

		/// 
		/// Gets or sets a value indicating whether this instance is server events synchronized.
		/// </summary>
		/// 
		/// true</c> if this instance is server events synchronized; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		[SRDescription("Determines whether the keyboard events should fire in the WinForms compatible mode.")]
		[Browsable(false)]
		[Obsolete("This property is obsolete. Use WinFormsCompatibility property instead.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool RealTimeKeyboardEvents
		{
			get
			{
				return WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents;
			}
			set
			{
				WinFormsCompatibility.TextBoxRealTimeKeyboardEvents = (value ? WinFormsCompatibilityStates.True : WinFormsCompatibilityStates.False);
			}
		}

		/// 
		/// Occurs when [client value changed].
		/// </summary>
		[SRDescription("Occurs when control's text changed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientTextChanged
		{
			add
			{
				AddClientHandler("ValueChange", value);
			}
			remove
			{
				RemoveClientHandler("ValueChange", value);
			}
		}

		/// 
		/// Gets the key event captures.
		/// </summary>
		/// </returns>
		protected override KeyCaptures GetKeyEventCaptures()
		{
			KeyCaptures keyEventCaptures = base.GetKeyEventCaptures();
			keyEventCaptures |= KeyCaptures.UpKeyCapture;
			keyEventCaptures |= KeyCaptures.DownKeyCapture;
			keyEventCaptures |= KeyCaptures.RightKeyCapture;
			keyEventCaptures |= KeyCaptures.LeftKeyCapture;
			keyEventCaptures |= KeyCaptures.EnterKeyCapture;
			keyEventCaptures |= KeyCaptures.HomeKeyCapture;
			return keyEventCaptures | KeyCaptures.EndKeyCapture;
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			switch (objEvent.Type)
			{
			case "ValueChange":
				if (!ReadOnly)
				{
					InternalText = CommonUtils.DecodeText(objEvent["TX"]);
					if (WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents)
					{
						OnValidating(new CancelEventArgs());
						OnValidated(EventArgs.Empty);
					}
				}
				break;
			case "SelectionChanged":
				if (objEvent.Contains("SST"))
				{
					SetValue(SelectionStartProperty, int.Parse(objEvent["SST"]));
				}
				if (objEvent.Contains("SLN"))
				{
					SetValue(SelectionLengthProperty, int.Parse(objEvent["SLN"]));
				}
				break;
			case "TextBoxRealTimeKeyDown":
				FireKeyDown(objEvent);
				break;
			case "TextBoxRealTimeKeyPress":
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

		/// 
		/// Gets the keys.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		/// </returns>
		private Keys GetKeys(IEvent objEvent)
		{
			Keys keys = objEvent.KeyCode;
			if (objEvent.AltKey)
			{
				keys |= Keys.Alt;
			}
			if (objEvent.ControlKey)
			{
				keys |= Keys.Control;
			}
			if (objEvent.ShiftKey)
			{
				keys |= Keys.Shift;
			}
			return keys;
		}

		/// 
		/// Fires the key down event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		private new void FireKeyDown(IEvent objEvent)
		{
			OnKeyDown(new KeyEventArgs(GetKeys(objEvent)));
		}

		/// 
		/// Fires the key press.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		private void FireKeyPress(IEvent objEvent)
		{
			Keys keys = GetKeys(objEvent);
			OnKeyPress(new KeyPressEventArgs((char)keys));
		}

		/// 
		/// Fires the key up.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		private void FireKeyUp(IEvent objEvent)
		{
			Keys keys = GetKeys(objEvent);
			OnKeyUp(new KeyEventArgs(keys));
		}

		/// 
		/// Get flag to state the criticality of keyboard events.
		/// </summary>
		/// </returns>
		private TextBoxEventTypes GetTextBoxCriticalKeyEvents()
		{
			TextBoxEventTypes textBoxEventTypes = TextBoxEventTypes.None;
			if (base.KeyDownHandler != null)
			{
				textBoxEventTypes |= TextBoxEventTypes.TextBoxRealTimeKeyDown;
			}
			if (base.KeyPressHandler != null)
			{
				textBoxEventTypes |= TextBoxEventTypes.TextBoxRealTimeKeyPress;
			}
			if (base.KeyUpHandler != null)
			{
				textBoxEventTypes |= TextBoxEventTypes.TextBoxRealTimeKeyUp;
			}
			return textBoxEventTypes;
		}

		/// 
		/// Gets the critical client events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			if (HasClientHandler("ValueChange"))
			{
				criticalClientEventsData.Set("VC");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Renders the current control attributes.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter">The response writer object.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			int maxLength = MaxLength;
			if (maxLength != 0)
			{
				objWriter.WriteAttributeString("MH", maxLength.ToString());
			}
			if (ReadOnly)
			{
				objWriter.WriteAttributeString("RO", "1");
			}
			if (!WordWrap)
			{
				objWriter.WriteAttributeString("WW", "0");
			}
			RenderValue(objContext, objWriter, blnForceRender: false);
			if (Multiline)
			{
				if (AcceptsTab)
				{
					objWriter.WriteAttributeString("ACT", "1");
				}
				objWriter.WriteAttributeString("MLT", "1");
			}
			RenderIsAutoCompleteAttribute(objWriter, blnForceRender: false);
			if (WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents)
			{
				objWriter.WriteAttributeString("TBRTKE", WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents ? "1" : "0");
				RenderTextboxKeyEventsAttributes(objWriter, blnForceRender: false);
			}
		}

		/// 
		/// Renders the standard textbox key events attributes.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderTextboxKeyEventsAttributes(IAttributeWriter objWriter, bool blnForceRender)
		{
			int textBoxCriticalKeyEvents = (int)GetTextBoxCriticalKeyEvents();
			if (textBoxCriticalKeyEvents != 0 || blnForceRender)
			{
				objWriter.WriteAttributeString("TBKEY", textBoxCriticalKeyEvents.ToString());
			}
		}

		/// 
		/// Renders the is auto complete attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderIsAutoCompleteAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			bool isAutoComplete = IsAutoComplete;
			if (!isAutoComplete || blnForceRender)
			{
				objWriter.WriteAttributeString("IAC", isAutoComplete ? "1" : "0");
			}
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
				RenderValue(objContext, objWriter, blnForceRender: true);
				objWriter.WriteAttributeString("RO", ReadOnly ? "1" : "0");
				RenderIsAutoCompleteAttribute(objWriter, blnForceRender: true);
			}
			if (WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents && IsDirtyAttributes(lngRequestID, AttributeType.Events))
			{
				RenderTextboxKeyEventsAttributes(objWriter, blnForceRender: true);
			}
		}

		protected override CriticalEventsData GetCriticalEventsData()
		{
			if (WinFormsCompatibility.IsTextBoxRealTimeKeyboardEvents)
			{
				CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
				criticalEventsData.Unset("KD");
				return criticalEventsData;
			}
			return base.GetCriticalEventsData();
		}

		/// 
		/// Renders the value.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected abstract void RenderValue(IContext objContext, IAttributeWriter objWriter, bool blnForceRender);

		/// 
		/// Clears all text from the text box control.
		/// </summary>
		public void Clear()
		{
			Text = "";
		}

		/// 
		/// Copies the current selection in the text box to the Clipboard.
		/// </summary>
		public void Copy()
		{
			Clipboard.SetText(GetClipboardContent(), TextDataFormat.UnicodeText);
		}

		/// 
		/// Moves the current selection in the text box to the Clipboard.
		/// </summary>
		public void Cut()
		{
			Clipboard.SetText(GetClipboardContent(), TextDataFormat.UnicodeText);
			SelectedText = "";
		}

		/// 
		/// Replaces the current selection in the text box with the contents of the Clipboard.
		/// </summary>
		public void Paste()
		{
			SetClipboardContent(Clipboard.GetText(TextDataFormat.UnicodeText));
		}

		/// 
		/// Sets the content of the clipboard.
		/// </summary>
		/// <param name="strValue">The STR value.</param>
		protected virtual void SetClipboardContent(string strValue)
		{
		}

		/// 
		/// Gets the content of the clipboard.
		/// </summary>
		/// </returns>
		protected virtual string GetClipboardContent()
		{
			return "";
		}

		/// Selects all text in the text box.</summary>
		public void SelectAll()
		{
			Select(0, TextLength);
		}

		/// Scrolls the contents of the control to the current caret position.</summary>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void ScrollToCaret()
		{
			if (Multiline)
			{
				InvokeMethodWithId("TextBox_Execute", "ScrollToCaret");
			}
		}

		/// Selects a range of text in the text box.</summary>
		/// <param name="intStart">The position of the first character in the current text selection within the text box. </param>
		/// <param name="intLength">The number of characters to select. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the start parameter is less than zero.</exception>
		public void Select(int intStart, int intLength)
		{
			SetValue(SelectionLengthProperty, intLength);
			SetValue(SelectionStartProperty, intStart);
			InvokeSelection(intStart, intLength);
		}

		/// Appends text to the current text of a text box.</summary>
		/// <param name="strText">The text to append to the current contents of the text box. </param>
		public void AppendText(string strText)
		{
			if (strText.Length > 0)
			{
				Text = $"{Text}{strText}";
			}
		}

		/// 
		/// Sets the selected text internal.
		/// </summary>
		/// <param name="strText">The text.</param>
		/// <param name="blnClearUndo">if set to true</c> [clear undo].</param>
		internal virtual void SetSelectedTextInternal(string strText, bool blnClearUndo)
		{
			int selectionStart = SelectionStart;
			int selectionLength = SelectionLength;
			string arg = Text.Substring(0, selectionStart);
			string arg2 = Text.Substring(selectionStart + selectionLength, TextLength - (selectionStart + selectionLength));
			Text = $"{arg}{strText}{arg2}";
		}

		/// 
		/// Gets the win forms compatibility.
		/// </summary>
		/// </returns>
		protected override WinFormsCompatibility GetWinFormsCompatibility()
		{
			return new TextBoxBaseWinFormsCompatibility();
		}

		/// 
		/// Called when WinFormsCompatibility option value is changed.
		/// </summary>
		protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
		{
			if (strChangedOptionName == "TextBoxRealTimeKeyboardEvents")
			{
				Update();
			}
			base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
		}
	}
}
