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
	/// A checkBox control.
	/// </summary>
	[Serializable]
	[ToolboxItemCategory("Common Controls")]
	[ToolboxBitmap(typeof(CheckBox), "CheckBox_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.CheckBoxController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.CheckBoxController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[MetadataTag("CH")]
	[Skin(typeof(CheckBoxSkin))]
	[DefaultProperty("Checked")]
	[SRDescription("DescriptionCheckBox")]
	[DefaultEvent("CheckedChanged")]
	[DefaultBindingProperty("CheckState")]
	public class CheckBox : ButtonBase
	{
		/// 
		/// Provides a property reference to AutoCheck property.
		/// </summary>
		private static SerializableProperty AutoCheckProperty = SerializableProperty.Register("AutoCheck", typeof(bool), typeof(CheckBox), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to ThreeState property.
		/// </summary>
		private static SerializableProperty ThreeStateProperty = SerializableProperty.Register("ThreeState", typeof(bool), typeof(CheckBox), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to CheckState property.
		/// </summary>
		private static SerializableProperty CheckStateProperty = SerializableProperty.Register("CheckState", typeof(CheckState), typeof(CheckBox), new SerializablePropertyMetadata(CheckState.Unchecked));

		/// 
		/// Provides a property reference to CheckAlign property.
		/// </summary>
		private static SerializableProperty CheckAlignProperty = SerializableProperty.Register("CheckAlign", typeof(ContentAlignment), typeof(CheckBox), new SerializablePropertyMetadata(ContentAlignment.MiddleLeft));

		/// 
		/// Provides a property reference to Appearance property.
		/// </summary>
		private static SerializableProperty AppearanceProperty = SerializableProperty.Register("Appearance", typeof(Appearance), typeof(CheckBox), new SerializablePropertyMetadata(Appearance.Normal));

		/// 
		/// The CheckStateChangedQueued event registration.
		/// </summary>
		private static readonly SerializableEvent CheckStateChangedQueuedEvent;

		/// 
		/// The CheckStateChanged event registration.
		/// </summary>
		private static readonly SerializableEvent CheckStateChangedEvent;

		/// 
		/// The CheckedChangedQueued event registration.
		/// </summary>
		private static readonly SerializableEvent CheckedChangedQueuedEvent;

		/// 
		/// The CheckedChanged event registration.
		/// </summary>
		private static readonly SerializableEvent CheckedChangedEvent;

		/// 
		/// The AppearanceChanged event registration.
		/// </summary>
		private static readonly SerializableEvent AppearanceChangedEvent;

		/// 
		/// Gets the hanlder for the CheckedChanged event.
		/// </summary>
		private EventHandler CheckedChangedHandler => (EventHandler)GetHandler(CheckedChangedEvent);

		/// 
		/// Gets the hanlder for the CheckedChangedQueued event.
		/// </summary>
		private EventHandler CheckedChangedQueuedHandler => (EventHandler)GetHandler(CheckedChangedQueuedEvent);

		/// 
		/// Gets the hanlder for the CheckStateChanged event.
		/// </summary>
		private EventHandler CheckStateChangedHandler => (EventHandler)GetHandler(CheckStateChangedEvent);

		/// 
		/// Gets the hanlder for the CheckStateChangedQueued event.
		/// </summary>
		private EventHandler CheckStateChangedQueuedHandler => (EventHandler)GetHandler(CheckStateChangedQueuedEvent);

		/// 
		/// Gets the hanlder for the AppearanceChanged event.
		/// </summary>
		private EventHandler AppearanceChangedHandler => (EventHandler)GetHandler(AppearanceChangedEvent);

		/// Gets or sets the horizontal and vertical alignment of the check mark on a <see cref="T:Gizmox.WebGUI.Forms.CheckBox"></see> control.</summary>
		/// One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default value is MiddleLeft.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> enumeration values. </exception>
		[Bindable(true)]
		[SRCategory("CatAppearance")]
		[DefaultValue(ContentAlignment.MiddleLeft)]
		[Localizable(true)]
		[SRDescription("CheckBoxCheckAlignDescr")]
		public ContentAlignment CheckAlign
		{
			get
			{
				return GetValue(CheckAlignProperty);
			}
			set
			{
				if (ClientUtils.GetBitCount((uint)value) != 1)
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ContentAlignment));
				}
				if (SetValue(CheckAlignProperty, value))
				{
					Update();
					FireObservableItemPropertyChanged("CheckAlign");
				}
			}
		}

		/// 
		/// Sets a value indicating whether internal checked value.
		/// </summary>
		/// 
		/// 	true</c> if internal value is checked; otherwise, false</c>.
		/// </value>
		internal CheckState InternalCheckState
		{
			get
			{
				return GetValue(CheckStateProperty);
			}
			set
			{
				CheckState value2 = GetValue(CheckStateProperty);
				if (value2 != value && SetValue(CheckStateProperty, value))
				{
					if (IsCheckedChanged(value2, value))
					{
						OnCheckedChanged(EventArgs.Empty);
						OnCheckedChangedQueued(EventArgs.Empty);
						FireObservableItemPropertyChanged("Checked");
					}
					OnCheckStateChanged(EventArgs.Empty);
					OnCheckStateChangedQueued(EventArgs.Empty);
					FireObservableItemPropertyChanged("CheckState");
				}
			}
		}

		/// 
		/// Gets or sets the state of the check.
		/// </summary>
		/// The state of the check from the CheckState enum. Default is CheckState.Unchecked.</value>
		[SRDescription("The state of the check from the CheckState enum")]
		[RefreshProperties(RefreshProperties.All)]
		[Bindable(true)]
		[SRCategory("CatAppearance")]
		[DefaultValue(CheckState.Unchecked)]
		public CheckState CheckState
		{
			get
			{
				return InternalCheckState;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(CheckState));
				}
				if (CheckState != value)
				{
					InternalCheckState = value;
					Update();
				}
			}
		}

		/// 
		///  Gets or sets a value indicating whether the check box will allow three check states rather than two.
		/// </summary>
		/// 
		/// 	true</c> if [three state]; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		public bool ThreeState
		{
			get
			{
				return GetValue(ThreeStateProperty);
			}
			set
			{
				if (SetValue(ThreeStateProperty, value))
				{
					Update();
					FireObservableItemPropertyChanged("ThreeState");
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.CheckBox" /> is checked.
		/// </summary>
		/// 
		/// 	true</c> if checked; otherwise, false</c>.
		/// </value>
		[SRDescription("Gets or sets a value indicating whether this CheckBox is Checked")]
		[SRCategory("CatAppearance")]
		[Bindable(true)]
		[DefaultValue(false)]
		[RefreshProperties(RefreshProperties.All)]
		[SettingsBindable(true)]
		public bool Checked
		{
			get
			{
				return CheckState != CheckState.Unchecked;
			}
			set
			{
				if (Checked != value)
				{
					CheckState = (value ? CheckState.Checked : CheckState.Unchecked);
				}
			}
		}

		/// Gets or set a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.CheckBox.Checked"></see> or <see cref="P:Gizmox.WebGUI.Forms.CheckBox.CheckState"></see> values and the <see cref="T:Gizmox.WebGUI.Forms.CheckBox"></see>'s appearance are automatically changed when the <see cref="T:Gizmox.WebGUI.Forms.CheckBox"></see> is clicked.</summary>
		/// true if the <see cref="P:Gizmox.WebGUI.Forms.CheckBox.Checked"></see> value or <see cref="P:Gizmox.WebGUI.Forms.CheckBox.CheckState"></see> value and the appearance of the control are automatically changed on the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"></see> event; otherwise, false. The default value is true.</returns>
		/// 1</filterpriority>
		[SRDescription("CheckBoxAutoCheckDescr")]
		[DefaultValue(true)]
		[SRCategory("CatBehavior")]
		public bool AutoCheck
		{
			get
			{
				return GetValue(AutoCheckProperty);
			}
			set
			{
				if (SetValue(AutoCheckProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the flat style.
		/// </summary>
		/// </value>
		public new FlatStyle FlatStyle
		{
			get
			{
				return FlatStyle.Standard;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets the alignment of the text on the <see cref="T:Gizmox.WebGUI.Forms.CheckBox">
		/// </see> control.
		/// </summary>
		/// 
		/// One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default is <see cref="F:System.Drawing.ContentAlignment.MiddleLeft"></see>.
		/// </returns>
		[DefaultValue(ContentAlignment.MiddleLeft)]
		[Localizable(true)]
		public override ContentAlignment TextAlign
		{
			get
			{
				return base.TextAlign;
			}
			set
			{
				base.TextAlign = value;
			}
		}

		/// 
		/// Gets or sets the value that indicating how a control will behave when its <see cref="P:Gizmox.WebGUI.Forms.Control.AutoSize"></see> property is enabled.
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.AutoSizeMode"></see> values.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override AutoSizeMode AutoSizeMode => AutoSizeMode.GrowAndShrink;

		/// 
		/// Gets or sets the appearance.
		/// </summary>
		/// The appearance.</value>
		[SRCategory("CatAppearance")]
		[Localizable(true)]
		[SRDescription("CheckBoxAppearanceDescr")]
		[DefaultValue(Appearance.Normal)]
		[ProxyBrowsable(true)]
		public Appearance Appearance
		{
			get
			{
				return GetValue(AppearanceProperty);
			}
			set
			{
				if (SetValue(AppearanceProperty, value))
				{
					if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
					{
						throw new InvalidEnumArgumentException("value", (int)value, typeof(Appearance));
					}
					OnAppearanceChanged(EventArgs.Empty);
					UpdateParams(AttributeType.Visual);
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
				}
			}
		}

		/// 
		/// Occurs when [client value changed].
		/// </summary>
		[SRDescription("checkedChangedEventDescr")]
		[Category("Client")]
		public event ClientEventHandler ClientCheckedChanged
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
		/// Occurs when the value of the Checked property changes.
		/// </summary>
		public event EventHandler CheckedChanged
		{
			add
			{
				AddCriticalHandler(CheckedChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(CheckedChangedEvent, value);
			}
		}

		/// 
		/// Occurs when the value of the Checked property changes (Queued).
		/// </summary>
		public event EventHandler CheckedChangedQueued
		{
			add
			{
				AddHandler(CheckedChangedQueuedEvent, value);
			}
			remove
			{
				RemoveHandler(CheckedChangedQueuedEvent, value);
			}
		}

		/// 
		/// Occurs when the value of the CheckState property changes.
		/// </summary>
		public event EventHandler CheckStateChanged
		{
			add
			{
				AddCriticalHandler(CheckStateChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(CheckStateChangedEvent, value);
			}
		}

		/// 
		/// Occurs when the value of the CheckState property changes (Queued).
		/// </summary>
		public event EventHandler CheckStateChangedQueued
		{
			add
			{
				AddHandler(CheckStateChangedQueuedEvent, value);
			}
			remove
			{
				RemoveHandler(CheckStateChangedQueuedEvent, value);
			}
		}

		/// 
		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.CheckBox.Checked"></see> property changes.
		/// </summary>
		[SRDescription("CheckBoxOnAppearanceChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler AppearanceChanged
		{
			add
			{
				AddCriticalHandler(AppearanceChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(AppearanceChangedEvent, value);
			}
		}

		/// 
		/// Raises the <see cref="E:AppearanceChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnAppearanceChanged(EventArgs e)
		{
			AppearanceChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.CheckBox" /> instance.
		/// </summary>
		public CheckBox()
		{
			AutoCheck = true;
			SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, blnValue: false);
			TextAlign = ContentAlignment.MiddleLeft;
		}

		/// 
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			bool flag = Checked;
			CheckState checkState = CheckState;
			if (flag)
			{
				if (checkState == CheckState.Indeterminate)
				{
					objWriter.WriteAttributeString("C", "2");
				}
				else
				{
					objWriter.WriteAttributeString("C", "1");
				}
			}
			else
			{
				objWriter.WriteAttributeString("C", "0");
			}
			if (!AutoCheck)
			{
				objWriter.WriteAttributeString("ACK", "0");
			}
			if (ThreeState)
			{
				objWriter.WriteAttributeString("MD", "3");
			}
			objWriter.WriteAttributeString("CA", CheckAlign.ToString());
			RenderAppearanceAttribute(objWriter, blnForceRender: false);
		}

		/// 
		/// An abstract param attribute rendering
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderAppearanceAttribute(objWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the appearance attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderAppearanceAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			Appearance proxyPropertyValue = GetProxyPropertyValue("Appearance", Appearance);
			if (proxyPropertyValue != Appearance.Normal || blnForceRender)
			{
				int num = (int)proxyPropertyValue;
				objWriter.WriteAttributeString("AP", num.ToString());
			}
		}

		/// 
		/// Renders the visual template.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderVisualTemplate(IContext objContext, IAttributeWriter objWriter)
		{
			VisualTemplate visualTemplate = GetProxyPropertyValue("VisualTemplate", VisualTemplate);
			if (visualTemplate == null && Appearance == Appearance.Switch)
			{
				visualTemplate = new CheckBoxSwitchVisualTemplate(blnShowCheckBoxLabel: false, 50, CheckBoxSwitchVisualTemplateSwitchSizing.Percent, string.Empty, string.Empty);
			}
			RenderVisualTemplate(objContext, objWriter, visualTemplate);
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			string type = objEvent.Type;
			if (type == "ValueChange")
			{
				switch (objEvent["C"])
				{
				case "0":
					InternalCheckState = CheckState.Unchecked;
					break;
				case "1":
					InternalCheckState = CheckState.Checked;
					break;
				case "2":
					InternalCheckState = CheckState.Indeterminate;
					break;
				}
			}
			base.FireEvent(objEvent);
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (CheckedChangedHandler != null || CheckStateChangedHandler != null)
			{
				criticalEventsData.Set("VC");
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
			if (HasClientHandler("ValueChange"))
			{
				criticalClientEventsData.Set("VC");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.CheckBox.CheckedChanged"></see> event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnCheckedChanged(EventArgs objEventArgs)
		{
			CheckedChangedHandler?.Invoke(this, objEventArgs);
		}

		/// 
		/// Raises the CheckedChangedQueued event
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnCheckedChangedQueued(EventArgs objEventArgs)
		{
			CheckedChangedQueuedHandler?.Invoke(this, objEventArgs);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.CheckBox.CheckStateChanged"></see> event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnCheckStateChanged(EventArgs objEventArgs)
		{
			CheckStateChangedHandler?.Invoke(this, objEventArgs);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.CheckBox.CheckStateChanged"></see> event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnCheckStateChangedQueued(EventArgs objEventArgs)
		{
			CheckStateChangedQueuedHandler?.Invoke(this, objEventArgs);
		}

		/// 
		/// Returns a <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any. This method should not be overridden.
		/// </summary>
		/// 
		/// A <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any, or null if the <see cref="T:System.ComponentModel.Component"></see> is unnamed.
		/// </returns>
		public override string ToString()
		{
			string arg = base.ToString();
			return $"{arg}, CheckState: {((int)CheckState).ToString()}";
		}

		/// 
		/// Retrieves the size of a rectangular area into which a control can be fitted.
		/// </summary>
		/// <param name="objProposedSize">The custom-sized area for a control.</param>
		/// </returns>
		public override Size GetPreferredSize(Size objProposedSize)
		{
			Size preferredSize = base.GetPreferredSize(objProposedSize);
			if (AutoSize)
			{
				CheckBoxSkin checkBoxSkin = base.Skin as CheckBoxSkin;
				Appearance appearance = Appearance;
				if (appearance == Appearance.Normal)
				{
					if (checkBoxSkin != null)
					{
						preferredSize.Width += Math.Max(checkBoxSkin.LabelNormalStyle.Padding.Horizontal, checkBoxSkin.LabelFocusedStyle.Padding.Horizontal);
						preferredSize.Width += Math.Max((checkBoxSkin.LabelNormalStyle.BorderStyle != BorderStyle.None) ? (checkBoxSkin.LabelNormalStyle.BorderWidth.Left + checkBoxSkin.LabelNormalStyle.BorderWidth.Right) : 0, (checkBoxSkin.LabelFocusedStyle.BorderStyle != BorderStyle.None) ? (checkBoxSkin.LabelFocusedStyle.BorderWidth.Left + checkBoxSkin.LabelFocusedStyle.BorderWidth.Right) : 0);
						preferredSize.Height += Math.Max(checkBoxSkin.LabelNormalStyle.Padding.Vertical, checkBoxSkin.LabelFocusedStyle.Padding.Vertical);
						preferredSize.Height += Math.Max((checkBoxSkin.LabelNormalStyle.BorderStyle != BorderStyle.None) ? (checkBoxSkin.LabelNormalStyle.BorderWidth.Top + checkBoxSkin.LabelNormalStyle.BorderWidth.Bottom) : 0, (checkBoxSkin.LabelFocusedStyle.BorderStyle != BorderStyle.None) ? (checkBoxSkin.LabelFocusedStyle.BorderWidth.Top + checkBoxSkin.LabelFocusedStyle.BorderWidth.Bottom) : 0);
					}
					if (base.HasImageSize || base.Image != null)
					{
						switch (base.TextImageRelation)
						{
						case TextImageRelation.Overlay:
							preferredSize.Width = Math.Max(base.ImageSize.Width, preferredSize.Width);
							preferredSize.Height = Math.Max(base.ImageSize.Height, preferredSize.Height);
							break;
						case TextImageRelation.ImageAboveText:
						case TextImageRelation.TextAboveImage:
							preferredSize.Width = Math.Max(base.ImageSize.Width, preferredSize.Width);
							preferredSize.Height += base.ImageSize.Height;
							preferredSize.Height += checkBoxSkin.ButtonImageTextGap;
							break;
						case TextImageRelation.ImageBeforeText:
						case TextImageRelation.TextBeforeImage:
							preferredSize.Width += base.ImageSize.Width;
							preferredSize.Height = Math.Max(base.ImageSize.Height, preferredSize.Height);
							break;
						}
					}
				}
				if (checkBoxSkin != null)
				{
					switch (appearance)
					{
					case Appearance.Normal:
						preferredSize.Height = Math.Max(checkBoxSkin.CheckBoxImageHeight, preferredSize.Height);
						preferredSize.Width += checkBoxSkin.CheckBoxImageWidth;
						preferredSize.Width += checkBoxSkin.ButtonImageTextGap;
						break;
					case Appearance.Button:
						preferredSize.Height += checkBoxSkin.TopFrameHeight + checkBoxSkin.BottomFrameHeight;
						preferredSize.Width += checkBoxSkin.LeftFrameWidth + checkBoxSkin.RightFrameWidth;
						break;
					}
					PaddingValue padding = checkBoxSkin.Padding;
					if (padding != null)
					{
						preferredSize.Width += padding.Horizontal;
						preferredSize.Height += padding.Vertical;
					}
					if (checkBoxSkin.BorderStyle != BorderStyle.None)
					{
						preferredSize.Height += checkBoxSkin.BorderWidth.Top + checkBoxSkin.BorderWidth.Bottom;
						preferredSize.Width += checkBoxSkin.BorderWidth.Left + checkBoxSkin.BorderWidth.Right;
					}
				}
			}
			return preferredSize;
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new CheckBoxRenderer(this);
		}

		/// 
		/// Returns a flag indicating if checked has changed
		/// </summary>
		/// <param name="enmValue1"></param>
		/// <param name="enmValue2"></param>
		/// </returns>
		private bool IsCheckedChanged(CheckState enmValue1, CheckState enmValue2)
		{
			if (enmValue1 == CheckState.Unchecked)
			{
				return enmValue2 == CheckState.Indeterminate || enmValue2 == CheckState.Checked;
			}
			return enmValue2 == CheckState.Unchecked;
		}

		static CheckBox()
		{
			CheckStateChangedQueuedEvent = SerializableEvent.Register("CheckStateChangedQueued", typeof(EventHandler), typeof(CheckBox));
			CheckStateChangedEvent = SerializableEvent.Register("CheckStateChanged", typeof(EventHandler), typeof(CheckBox));
			CheckedChangedQueuedEvent = SerializableEvent.Register("CheckedChangedQueued", typeof(EventHandler), typeof(CheckBox));
			CheckedChangedEvent = SerializableEvent.Register("CheckedChanged", typeof(EventHandler), typeof(CheckBox));
			AppearanceChangedEvent = SerializableEvent.Register("AppearanceChanged", typeof(EventHandler), typeof(CheckBox));
		}
	}
}
