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
	/// Represents a selectable <see cref="T:System.Windows.Forms.ToolStripItem"></see> that can contain text and images. </summary>
	[Serializable]
	[Skin(typeof(ToolStripButtonSkin))]
	[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripButtonController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class ToolStripButton : ToolStripItem
	{
		private static readonly SerializableProperty menmCheckStateProperty = SerializableProperty.Register("menmCheckState", typeof(CheckState), typeof(ToolStripButton));

		private static readonly SerializableProperty mblnCheckOnClickProperty = SerializableProperty.Register("mblnCheckOnClick", typeof(bool), typeof(ToolStripButton));

		private static readonly SerializableEvent CheckedChangedEvent;

		private static readonly SerializableEvent CheckStateChangedEvent;

		/// 
		/// Gets the CheckedChanged handler.
		/// </summary>
		/// The available changed handler.</value>
		private EventHandler CheckedChangedHandler => (EventHandler)GetHandler(CheckedChanged);

		/// 
		/// Gets the CheckStateChanged handler.
		/// </summary>
		/// The available changed handler.</value>
		private EventHandler CheckStateChangedHandler => (EventHandler)GetHandler(CheckStateChanged);

		private CheckState menmCheckState
		{
			get
			{
				return GetValue(menmCheckStateProperty);
			}
			set
			{
				SetValue(menmCheckStateProperty, value);
			}
		}

		private bool mblnCheckOnClick
		{
			get
			{
				return GetValue(mblnCheckOnClickProperty);
			}
			set
			{
				SetValue(mblnCheckOnClickProperty, value);
			}
		}

		/// 
		/// Gets the type of the tool strip item.
		/// </summary>
		/// The type of the tool strip item.</value>
		protected override int ToolStripItemType => 0;

		/// Gets or sets a value indicating whether default or custom <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> text is displayed on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>. </summary> 
		/// true if default <see cref="T:Gizmox.WebGUI.Forms.ToolTip"></see> text is displayed; otherwise, false. The default is true.</returns>
		[DefaultValue(true)]
		public new bool AutoToolTip
		{
			get
			{
				return base.AutoToolTip;
			}
			set
			{
				base.AutoToolTip = value;
			}
		}

		/// Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> can be selected.</summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> can be selected; otherwise, false.</returns> 
		/// 1</filterpriority>
		public override bool CanSelect => true;

		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> is pressed or not pressed.</summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> is pressed in or not pressed in; otherwise, false. The default is false.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[SRCategory("CatAppearance")]
		[SRDescription("ToolStripButtonCheckedDescr")]
		[DefaultValue(false)]
		public bool Checked
		{
			get
			{
				return menmCheckState != CheckState.Unchecked;
			}
			set
			{
				if (value != Checked)
				{
					CheckState = (value ? CheckState.Checked : CheckState.Unchecked);
				}
			}
		}

		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> should automatically appear pressed in and not pressed in when clicked.</summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> should automatically appear pressed in and not pressed in when clicked; otherwise, false. The default is false.</returns> 
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("ToolStripButtonCheckOnClickDescr")]
		[DefaultValue(false)]
		public bool CheckOnClick
		{
			get
			{
				return mblnCheckOnClick;
			}
			set
			{
				if (mblnCheckOnClick != value)
				{
					mblnCheckOnClick = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> is in the pressed or not pressed state by default, or is in an indeterminate state.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.CheckState"></see> values. The default is Unchecked.</returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.CheckState"></see> values. </exception> 
		/// 1</filterpriority>
		[SRDescription("CheckBoxCheckStateDescr")]
		[DefaultValue(CheckState.Unchecked)]
		[SRCategory("CatAppearance")]
		public CheckState CheckState
		{
			get
			{
				return menmCheckState;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(CheckState));
				}
				if (value != menmCheckState)
				{
					menmCheckState = value;
					Invalidate();
					OnCheckedChanged(EventArgs.Empty);
					OnCheckStateChanged(EventArgs.Empty);
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets a value indicating whether to display the ToolTip that is defined as the default. </summary> 
		/// true in all cases.</returns>
		protected override bool DefaultAutoToolTip => true;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripButton.Checked"></see> property changes.</summary> 
		/// 1</filterpriority>
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

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ToolStripButton.CheckState"></see> property changes.</summary> 
		/// 1</filterpriority>
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

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class.</summary>
		public ToolStripButton()
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class that displays the specified text.</summary> 
		/// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
		public ToolStripButton(string text)
			: base(text, null, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class that displays the specified image.</summary> 
		/// <param name="image">The image to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
		public ToolStripButton(ResourceHandle image)
			: base(null, image, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class that displays the specified text and image.</summary> 
		/// <param name="image">The image to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param> 
		/// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
		public ToolStripButton(string text, ResourceHandle image)
			: base(text, image, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class that displays the specified text and image and that raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event.</summary> 
		/// <param name="onClick">An event handler that raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event.</param> 
		/// <param name="image">The image to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param> 
		/// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
		public ToolStripButton(string text, ResourceHandle image, EventHandler onClick)
			: base(text, image, onClick)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see> class with the specified name that displays the specified text and image and that raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event.</summary> 
		/// <param name="onClick">An event handler that raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripItem.Click"></see> event.</param> 
		/// <param name="name">The name of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param> 
		/// <param name="image">The image to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param> 
		/// <param name="text">The text to display on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripButton"></see>.</param>
		public ToolStripButton(string text, ResourceHandle image, EventHandler onClick, string name)
			: base(text, image, onClick, null)
		{
		}

		/// 
		/// Retrieves the size of a rectangular area into which a control can be fit.
		/// </summary>
		/// <param name="objConstrainingSize">The custom-sized area for a control.</param>
		/// 
		/// A <see cref="T:System.Drawing.Size"></see> ordered pair, representing the width and height of a rectangle.
		/// </returns>
		/// 
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
		///   </PermissionSet>
		public override Size GetPreferredSize(Size objConstrainingSize)
		{
			Size preferredeSizeByText = GetPreferredeSizeByText();
			preferredeSizeByText = base.GetPreferredSizeByImage(preferredeSizeByText);
			return GetPreferredSizeByButtonSkin(SkinFactory.GetSkin(this) as ButtonSkin, preferredeSizeByText);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripButton.CheckedChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnCheckedChanged(EventArgs e)
		{
			CheckedChangedHandler?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.ToolStripButton.CheckStateChanged"></see> event.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnCheckStateChanged(EventArgs e)
		{
			CheckStateChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			string type = objEvent.Type;
			if (type == "CheckedChange")
			{
				bool result = false;
				if (bool.TryParse(objEvent["C"], out result))
				{
					Checked = result;
				}
			}
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
				criticalEventsData.Set("CC");
			}
			return criticalEventsData;
		}

		/// 
		/// Renders the tool strip item's attributes.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objAttributeWriter">The attribute writer.</param>
		protected override void RenderToolStripItemAttributes(IContext objContext, IAttributeWriter objAttributeWriter)
		{
			base.RenderToolStripItemAttributes(objContext, objAttributeWriter);
			RenderToolStripItemTextAttribute(objAttributeWriter, blnForceRender: false);
			RenderToolStripItemCheckedAttribute(objAttributeWriter, blnForceRender: false);
			RenderToolStripItemCheckedOnClickAttribute(objAttributeWriter, blnForceRender: false);
		}

		/// 
		/// Renders the tool strip item checked on click attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderToolStripItemCheckedOnClickAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			if (mblnCheckOnClick || blnForceRender)
			{
				objAttributeWriter.WriteAttributeText("COC", mblnCheckOnClick ? "1" : "0");
			}
		}

		/// 
		/// Renders the tool strip item updated attributes.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objAttributeWriter">The attribute writer.</param>
		/// <param name="lngRequestID">The request ID.</param>
		protected override void RenderToolStripItemUpdatedAttributes(IContext objContext, IAttributeWriter objAttributeWriter, long lngRequestID)
		{
			base.RenderToolStripItemUpdatedAttributes(objContext, objAttributeWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderToolStripItemTextAttribute(objAttributeWriter, blnForceRender: true);
				RenderToolStripItemCheckedAttribute(objAttributeWriter, blnForceRender: true);
				RenderToolStripItemCheckedOnClickAttribute(objAttributeWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the tool strip item text attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderToolStripItemTextAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			if (base.ShouldRenderText)
			{
				string text = Text;
				if (!string.IsNullOrEmpty(text) || blnForceRender)
				{
					objAttributeWriter.WriteAttributeText("TX", text);
				}
			}
		}

		/// 
		/// Renders the tool strip item checked attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderToolStripItemCheckedAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
		{
			bool flag = Checked;
			if (flag || blnForceRender)
			{
				objAttributeWriter.WriteAttributeText("C", flag ? "1" : "0");
			}
		}

		static ToolStripButton()
		{
			CheckedChanged = SerializableEvent.Register("CheckedChanged", typeof(EventHandler), typeof(ToolStripButton));
			CheckStateChanged = SerializableEvent.Register("CheckStateChanged", typeof(EventHandler), typeof(ToolStripButton));
		}
	}
}
