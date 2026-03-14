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
	/// Enables the user to select a single option from a group of choices when paired with other <see cref="T:Gizmox.WebGUI.Forms.RadioButton"></see> controls.
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(RadioButton), "RadioButton_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.RadioButtonController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.RadioButtonController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DefaultBindingProperty("Checked")]
	[ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[SRDescription("DescriptionRadioButton")]
	[DefaultProperty("Checked")]
	[DefaultEvent("CheckedChanged")]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("RB")]
	[Skin(typeof(RadioButtonSkin))]
	public class RadioButton : ButtonBase
	{
		/// 
		/// Provides a property reference to Checked property.
		/// </summary>
		private static SerializableProperty CheckedProperty = SerializableProperty.Register("Checked", typeof(bool), typeof(RadioButton), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to CheckAlign property.
		/// </summary>
		private static SerializableProperty CheckAlignProperty = SerializableProperty.Register("CheckAlign", typeof(ContentAlignment), typeof(RadioButton), new SerializablePropertyMetadata(ContentAlignment.MiddleLeft));

		/// 
		/// Provides a property reference to Appearance property.
		/// </summary>
		private static SerializableProperty AppearanceProperty = SerializableProperty.Register("Appearance", typeof(Appearance), typeof(RadioButton), new SerializablePropertyMetadata(Appearance.Normal));

		/// 
		/// The AppearanceChanged event registration.
		/// </summary>
		private static readonly SerializableEvent AppearanceChangedEvent;

		/// 
		/// The CheckedChanged event registration.
		/// </summary>
		private static readonly SerializableEvent CheckedChangedEvent;

		/// 
		/// Gets the hanlder for the AppearanceChanged event.
		/// </summary>
		private EventHandler AppearanceChangedHandler => (EventHandler)GetHandler(AppearanceChanged);

		/// 
		/// Gets the hanlder for the CheckedChanged event.
		/// </summary>
		private EventHandler CheckedChangedHandler => (EventHandler)GetHandler(CheckedChangedEvent);

		/// 
		/// Gets or sets a value indicating whether the control is checked.
		/// </summary>
		/// true if the check box is checked; otherwise, false.</returns>
		[DefaultValue(false)]
		[SRDescription("RadioButtonCheckedDescr")]
		[SRCategory("CatAppearance")]
		[Bindable(true)]
		public bool Checked
		{
			get
			{
				return InternalChecked;
			}
			set
			{
				if (Checked != value)
				{
					SetChecked(value, blnUpdateSibling: true);
					Update();
				}
			}
		}

		/// 
		/// Sets a value indicating whether internal checked value.
		/// </summary>
		/// 
		/// 	true</c> if internal value is checked; otherwise, false</c>.
		/// </value>
		internal bool InternalChecked
		{
			get
			{
				return GetValue(CheckedProperty);
			}
			set
			{
				SetValue(CheckedProperty, value);
			}
		}

		/// Gets or sets the horizontal and vertical alignment of the check mark on a <see cref="T:Gizmox.WebGUI.Forms.RadioButton"></see> control.</summary>
		/// One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default value is MiddleLeft.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> enumeration values. </exception>
		[Bindable(true)]
		[SRCategory("CatAppearance")]
		[DefaultValue(ContentAlignment.MiddleLeft)]
		[Localizable(true)]
		[SRDescription("RadioButtonCheckAlignDescr")]
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
		/// Gets or sets the appearance.
		/// </summary>
		/// The appearance.</value>
		[SRCategory("CatAppearance")]
		[Localizable(true)]
		[SRDescription("RadioButtonAppearanceDescr")]
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
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 1))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(Appearance));
				}
				if (SetValue(AppearanceProperty, value))
				{
					OnAppearanceChanged(EventArgs.Empty);
					UpdateParams(AttributeType.Visual);
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
				}
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
		/// Gets a value indicating whether this instance is defined for tabbing as group.
		/// </summary>
		/// 
		/// 	true</c> if this instance is tab for group; otherwise, false</c>.
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[DefaultValue(false)]
		protected override bool EnableGroupTabbing => true;

		/// 
		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.RadioButton.Checked"></see> property changes.
		/// </summary>
		[SRDescription("RadioButtonOnAppearanceChangedDescr")]
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
		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.RadioButton.Checked"></see> property changes.
		/// </summary>
		[SRDescription("RadioButtonOnCheckedChangedDescr")]
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
		/// Occurs when [client value changed].
		/// </summary>
		[SRDescription("valueChangedEventDescr")]
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
		/// Occurs when checked property value queued for change.
		/// </summary>
		public event EventHandler CheckedChangedQueued;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.RadioButton"></see> class.
		/// </summary>
		public RadioButton()
		{
			SetStyle(ControlStyles.StandardClick, blnValue: false);
			TextAlign = ContentAlignment.MiddleLeft;
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			objWriter.WriteAttributeString("C", Checked ? "1" : "0");
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
			if (proxyPropertyValue == Appearance.Button || blnForceRender)
			{
				int num = (int)proxyPropertyValue;
				objWriter.WriteAttributeString("AP", num.ToString());
			}
		}

		/// 
		/// Returns a <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any. This method should not be overridden.
		/// </summary>
		/// 
		/// A <see cref="T:System.String"></see> containing the name of the <see cref="T:System.ComponentModel.Component"></see>, if any, or null if the <see cref="T:System.ComponentModel.Component"></see> is unnamed.
		/// </returns>
		public override string ToString()
		{
			return $"{base.ToString()}, Checked: {Checked.ToString()}";
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
				RadioButtonSkin radioButtonSkin = base.Skin as RadioButtonSkin;
				Appearance appearance = Appearance;
				if (appearance == Appearance.Normal)
				{
					if (radioButtonSkin != null)
					{
						preferredSize.Width += radioButtonSkin.TextNormalStyle.Padding.Horizontal;
						preferredSize.Height += radioButtonSkin.TextNormalStyle.Padding.Vertical;
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
							preferredSize.Height += radioButtonSkin.ButtonImageTextGap;
							break;
						case TextImageRelation.ImageBeforeText:
						case TextImageRelation.TextBeforeImage:
							preferredSize.Width += base.ImageSize.Width;
							preferredSize.Height = Math.Max(base.ImageSize.Height, preferredSize.Height);
							break;
						}
					}
				}
				if (radioButtonSkin != null)
				{
					switch (appearance)
					{
					case Appearance.Normal:
						preferredSize.Height = Math.Max(radioButtonSkin.RadioImageHeight, preferredSize.Height);
						preferredSize.Width += radioButtonSkin.RadioImageWidth;
						preferredSize.Width += radioButtonSkin.ButtonImageTextGap;
						break;
					case Appearance.Button:
						preferredSize.Height += radioButtonSkin.TopFrameHeight + radioButtonSkin.BottomFrameHeight;
						preferredSize.Width += radioButtonSkin.LeftFrameWidth + radioButtonSkin.RightFrameWidth;
						break;
					}
					PaddingValue padding = radioButtonSkin.Padding;
					if (padding != null)
					{
						preferredSize.Width += padding.Horizontal;
						preferredSize.Height += padding.Vertical;
					}
				}
			}
			return preferredSize;
		}

		/// 
		/// Handles the check.
		/// </summary>
		/// <param name="blnValue">if set to true</c> [value].</param>
		/// <param name="blnUpdateSibling">if set to true</c> [BLN update sibling].</param>
		private void SetChecked(bool blnValue, bool blnUpdateSibling)
		{
			InternalChecked = blnValue;
			if (blnValue && base.Parent != null)
			{
				foreach (Control control in base.Parent.Controls)
				{
					if (control is RadioButton radioButton && radioButton != this && radioButton.InternalChecked)
					{
						radioButton.InternalChecked = false;
						if (radioButton.CheckedChangedHandler != null)
						{
							radioButton.CheckedChangedHandler(radioButton, EventArgs.Empty);
						}
						if (radioButton.CheckedChangedQueued != null)
						{
							radioButton.CheckedChangedQueued(radioButton, EventArgs.Empty);
						}
						if (blnUpdateSibling)
						{
							radioButton.Update();
						}
					}
				}
			}
			OnCheckedChanged(EventArgs.Empty);
			EventHandler eventHandler = this.CheckedChangedQueued;
			if (eventHandler != null)
			{
				this.CheckedChangedQueued(this, EventArgs.Empty);
			}
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new RadioButtonRenderer(this);
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
				SetChecked(blnValue: true, blnUpdateSibling: false);
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
			if (CheckedChangedHandler != null)
			{
				criticalEventsData.Set("VC");
			}
			return criticalEventsData;
		}

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
		/// Raises the <see cref="E:System.Windows.Forms.CheckBox.CheckedChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnCheckedChanged(EventArgs e)
		{
			CheckedChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:AppearanceChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnAppearanceChanged(EventArgs e)
		{
			AppearanceChangedHandler?.Invoke(this, e);
		}

		static RadioButton()
		{
			AppearanceChanged = SerializableEvent.Register("AppearanceChanged", typeof(EventHandler), typeof(RadioButton));
			CheckedChangedEvent = SerializableEvent.Register("CheckedChanged", typeof(EventHandler), typeof(RadioButton));
		}
	}
}
