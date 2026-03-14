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
/// Provides basic functionality for controls that display a <see cref="T:System.Windows.Forms.ToolStripDropDown"></see> when a <see cref="T:System.Windows.Forms.ToolStripDropDownButton"></see>, <see cref="T:System.Windows.Forms.ToolStripMenuItem"></see>, or <see cref="T:System.Windows.Forms.ToolStripSplitButton"></see> control is clicked.</summary>
	[Serializable]
	[DefaultProperty("DropDownItems")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolStripDropDownItemController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public abstract class ToolStripDropDownItem : ToolStripItem
	{
		private static readonly SerializableProperty mobjDropDownProperty = SerializableProperty.Register("mobjDropDown", typeof(ToolStripDropDown), typeof(ToolStripDropDownItem));

		private static readonly SerializableEvent DropDownOpenedEvent;

		private static readonly SerializableEvent DropDownOpeningEvent;

		private static readonly SerializableEvent DropDownItemClickedEvent;

		private static readonly SerializableEvent DropDownClosedEvent;

		/// 
		/// Gets the DropDownClosed handler.
		/// </summary>
		/// The DropDownClosed handler.</value>
		private EventHandler DropDownClosedHandler => (EventHandler)GetHandler(DropDownClosed);

		/// 
		/// Gets the DropDownItemClicked handler.
		/// </summary>
		/// The DropDownItemClicked handler.</value>
		private ToolStripItemClickedEventHandler DropDownItemClickedHandler => (ToolStripItemClickedEventHandler)GetHandler(DropDownItemClicked);

		/// 
		/// Gets the DropDownOpened handler.
		/// </summary>
		/// The DropDownOpened handler.</value>
		private EventHandler DropDownOpenedHandler => (EventHandler)GetHandler(DropDownOpened);

		/// 
		/// Gets the DropDownOpening handler.
		/// </summary>
		/// The DropDownOpening handler.</value>
		private EventHandler DropDownOpeningHandler => (EventHandler)GetHandler(DropDownOpening);

		private ToolStripDropDown mobjDropDown
		{
			get
			{
				return GetValue(mobjDropDownProperty);
			}
			set
			{
				SetValue(mobjDropDownProperty, value);
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> that will be displayed when this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> is clicked.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> that is associated with the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see>.</returns> 
		/// 1</filterpriority>
		[TypeConverter(typeof(ReferenceConverter))]
		[SRCategory("CatData")]
		[SRDescription("ToolStripDropDownDescr")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ToolStripDropDown DropDown
		{
			get
			{
				if (mobjDropDown == null)
				{
					DropDown = CreateDefaultDropDown();
					if (!(this is ToolStripOverflowButton))
					{
						mobjDropDown.SetAutoGeneratedInternal(autoGenerated: true);
					}
				}
				return mobjDropDown;
			}
			set
			{
				if (mobjDropDown != value)
				{
					mobjDropDown = value;
				}
			}
		}

		/// Gets or sets a value indicating the direction in which the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> emerges from its parent container.</summary> 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownDirection"></see> values.</returns> 
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property is set to a value that is not one of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownDirection"></see> values.</exception>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRCategory("CatBehavior")]
		[Browsable(false)]
		[SRDescription("ToolStripDropDownItemDropDownDirectionDescr")]
		public ToolStripDropDownDirection DropDownDirection
		{
			get
			{
				return ToolStripDropDownDirection.Default;
			}
			set
			{
			}
		}

		/// Gets the collection of items in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> that is associated with this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see>.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItemCollection"></see> of controls.</returns> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Security.Permissions.UIPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRCategory("CatData")]
		[SRDescription("ToolStripDropDownItemsDescr")]
		[Editor("Gizmox.WebGUI.Forms.Design.ContextMenuStripItemCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		public ToolStripItemCollection DropDownItems => DropDown.Items;

		/// Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> has <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> controls associated with it. </summary> 
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> has <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> controls; otherwise, false.</returns> 
		/// 1</filterpriority>
		[Browsable(false)]
		public virtual bool HasDropDownItems => mobjDropDown != null && mobjDropDown.Items.Count > 0;

		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> closes. </summary> 
		/// 1</filterpriority>
		public event EventHandler DropDownClosed
		{
			add
			{
				if (!HasHandler(DropDownClosedEvent) && mobjDropDown != null)
				{
					mobjDropDown.Closed += DropDown_Closed;
				}
				AddCriticalHandler(DropDownClosedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(DropDownClosedEvent, value);
				if (!HasHandler(DropDownClosedEvent) && mobjDropDown != null)
				{
					mobjDropDown.Closed -= DropDown_Closed;
				}
			}
		}

		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is clicked.</summary> 
		/// 1</filterpriority>
		public event ToolStripItemClickedEventHandler DropDownItemClicked
		{
			add
			{
				if (!HasHandler(DropDownItemClickedEvent) && mobjDropDown != null)
				{
					mobjDropDown.ItemClicked += DropDown_ItemClicked;
				}
				AddCriticalHandler(DropDownItemClickedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(DropDownItemClickedEvent, value);
				if (!HasHandler(DropDownItemClickedEvent) && mobjDropDown != null)
				{
					mobjDropDown.ItemClicked -= DropDown_ItemClicked;
				}
			}
		}

		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> has opened.</summary> 
		/// 1</filterpriority>
		public event EventHandler DropDownOpened
		{
			add
			{
				if (!HasHandler(DropDownOpenedEvent) && mobjDropDown != null)
				{
					mobjDropDown.Opened += DropDown_Opened;
				}
				AddCriticalHandler(DropDownOpenedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(DropDownOpenedEvent, value);
				if (!HasHandler(DropDownOpenedEvent) && mobjDropDown != null)
				{
					mobjDropDown.Opened -= DropDown_Opened;
				}
			}
		}

		/// Occurs as the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> is opening.</summary> 
		/// 1</filterpriority>
		public event EventHandler DropDownOpening
		{
			add
			{
				AddCriticalHandler(DropDownOpeningEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(DropDownOpeningEvent, value);
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> class. </summary>
		protected ToolStripDropDownItem()
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> class with the specified display text, image, and action to take when the drop-down control is clicked.</summary> 
		/// <param name="onClick">The action to take when the drop-down control is clicked.</param> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the control.</param> 
		/// <param name="text">The display text of the drop-down control.</param>
		protected ToolStripDropDownItem(string text, ResourceHandle image, EventHandler onClick)
			: base(text, image, onClick)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> class with the specified display text, image, action to take when the drop-down control is clicked, and control name.</summary> 
		/// <param name="onClick">The action to take when the drop-down control is clicked.</param> 
		/// <param name="name">The name of the control.</param> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the control.</param> 
		/// <param name="text">The display text of the drop-down control.</param>
		protected ToolStripDropDownItem(string text, ResourceHandle image, EventHandler onClick, string name)
			: base(text, image, onClick, null)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> class with the specified display text, image, and <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> collection that the drop-down control contains.</summary> 
		/// <param name="dropDownItems">A <see cref="T:Gizmox.WebGUI.Forms.ToolStripItem"></see> collection that the drop-down control contains.</param> 
		/// <param name="image">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to be displayed on the control.</param> 
		/// <param name="text">The display text of the drop-down control.</param>
		protected ToolStripDropDownItem(string text, ResourceHandle image, ToolStripItem[] dropDownItems)
			: this(text, image, (EventHandler)null)
		{
			if (dropDownItems != null)
			{
				DropDownItems.AddRange(dropDownItems);
			}
		}

		/// 
		/// Pres the render tool strip item.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		protected internal override void PreRenderToolStripItem(IContext objContext, long lngRequestID)
		{
			base.PreRenderToolStripItem(objContext, lngRequestID);
			DropDown.PreRenderControl(objContext, lngRequestID);
		}

		/// 
		/// Posts the render tool strip item.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		protected internal override void PostRenderToolStripItem(IContext objContext, long lngRequestID)
		{
			base.PostRenderToolStripItem(objContext, lngRequestID);
			DropDown.PostRenderControl(objContext, lngRequestID);
		}

		/// 
		/// Called when [unregister components].
		/// </summary>
		protected override void OnUnregisterComponents()
		{
			base.OnUnregisterComponents();
			if (mobjDropDown != null)
			{
				UnRegisterBatch(mobjDropDown.Items);
			}
		}

		/// 
		/// Called when [register components].
		/// </summary>
		protected override void OnRegisterComponents()
		{
			base.OnRegisterComponents();
			if (mobjDropDown != null)
			{
				RegisterBatch(mobjDropDown.Items);
			}
		}

		/// 
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="blnDisposing">true</c> to release both managed and unmanaged resources; false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool blnDisposing)
		{
			if (mobjDropDown != null)
			{
				mobjDropDown.Opened -= DropDown_Opened;
				mobjDropDown.Closed -= DropDown_Closed;
				mobjDropDown.ItemClicked -= DropDown_ItemClicked;
				if (blnDisposing && mobjDropDown.IsAutoGenerated)
				{
					mobjDropDown.Dispose();
					mobjDropDown = null;
				}
			}
			base.Dispose(blnDisposing);
		}

		private void DropDown_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			OnDropDownClosed(EventArgs.Empty);
		}

		private void DropDown_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			OnDropDownItemClicked(e);
		}

		private void DropDown_Opened(object sender, EventArgs e)
		{
			OnDropDownOpened(EventArgs.Empty);
		}

		/// Raises the <see cref="E:System.Windows.Forms.ToolStripDropDownItem.DropDownOpened"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected internal virtual void OnDropDownOpened(EventArgs e)
		{
			if (DropDown.OwnerItem == this)
			{
				DropDownOpenedHandler?.Invoke(this, e);
			}
		}

		/// Raises the <see cref="E:System.Windows.Forms.ToolStripDropDownItem.DropDownClosed"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected internal virtual void OnDropDownClosed(EventArgs e)
		{
			Invalidate();
			if (DropDown.OwnerItem == this)
			{
				DropDownClosedHandler?.Invoke(this, e);
				if (!DropDown.IsAutoGenerated)
				{
					DropDown.OwnerItem = null;
				}
			}
		}

		/// Raises the <see cref="E:System.Windows.Forms.ToolStripDropDownItem.DropDownItemClicked"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemClickedEventArgs"></see> that contains the event data.</param>
		protected internal virtual void OnDropDownItemClicked(ToolStripItemClickedEventArgs e)
		{
			if (DropDown.OwnerItem == this)
			{
				DropDownItemClickedHandler?.Invoke(this, e);
			}
		}

		/// Creates a generic <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> for which events can be defined.</summary> 
		/// A <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.</returns>
		protected virtual ToolStripDropDown CreateDefaultDropDown()
		{
			return new ToolStripDropDown(this, blnIsAutoGenerated: true);
		}

		/// Makes a visible <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see> hidden.</summary> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		public void HideDropDown()
		{
			OnDropDownHide(EventArgs.Empty);
		}

		/// Raised in response to the <see cref="M:Gizmox.WebGUI.Forms.ToolStripDropDownItem.HideDropDown"></see> method.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnDropDownHide(EventArgs e)
		{
		}

		/// Raised in response to the <see cref="M:Gizmox.WebGUI.Forms.ToolStripDropDownItem.ShowDropDown"></see> method.</summary> 
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnDropDownShow(EventArgs e)
		{
			DropDownOpeningHandler?.Invoke(this, e);
		}

		/// Displays the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> control associated with this <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see>.</summary> 
		/// <exception cref="T:System.InvalidOperationException">The <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownItem"></see> is the same as the parent <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</exception> 
		/// 1</filterpriority> 
		///  
		///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /> 
		///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /> 
		/// </PermissionSet>
		public void ShowDropDown()
		{
			if (mobjDropDown == null)
			{
				OnDropDownShow(EventArgs.Empty);
			}
			if (mobjDropDown != null && (!mobjDropDown.IsAutoGenerated || DropDownItems.Count > 0))
			{
				if (DropDown == base.ParentInternal)
				{
					throw new InvalidOperationException(SR.GetString("ToolStripShowDropDownInvalidOperation"));
				}
				mobjDropDown.ShowDropDown(this);
			}
		}

		/// 
		/// Gets the component offsprings.
		/// </summary>
		/// <param name="strOffspringTypeName">The offspring type.</param>
		/// </returns>
		protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
		{
			if (strOffspringTypeName == "Gizmox.WebGUI.Forms.ToolStripDropDown")
			{
				List<object> list = new List<object><object>();
				list.Add(DropDown);
				return list;
			}
			return base.GetComponentOffsprings(strOffspringTypeName);
		}

		/// 
		/// Renders the tool strip item's text attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The attribute writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		protected virtual void RenderToolStripDropDownItemTextAttribute(IAttributeWriter objAttributeWriter, bool blnForceRender)
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
		/// Renders the tool strip item's attributes.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objAttributeWriter">The attribute writer.</param>
		protected override void RenderToolStripItemAttributes(IContext objContext, IAttributeWriter objAttributeWriter)
		{
			base.RenderToolStripItemAttributes(objContext, objAttributeWriter);
			RenderToolStripDropDownItemDropDownAttribute(objAttributeWriter);
			RenderToolStripDropDownItemTextAttribute(objAttributeWriter, blnForceRender: false);
		}

		/// 
		/// Renders the tool strip item's drop down attribute.
		/// </summary>
		/// <param name="objAttributeWriter">The obj attribute writer.</param>
		protected virtual void RenderToolStripDropDownItemDropDownAttribute(IAttributeWriter objAttributeWriter)
		{
			objAttributeWriter.WriteAttributeText("DD", "1");
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
				RenderToolStripDropDownItemTextAttribute(objAttributeWriter, blnForceRender: true);
			}
		}

		static ToolStripDropDownItem()
		{
			DropDownOpened = SerializableEvent.Register("DropDownOpened", typeof(EventHandler), typeof(ToolStripDropDownItem));
			DropDownOpening = SerializableEvent.Register("DropDownOpening", typeof(EventHandler), typeof(ToolStripDropDownItem));
			DropDownItemClicked = SerializableEvent.Register("DropDownItemClicked", typeof(ToolStripItemClickedEventHandler), typeof(ToolStripDropDownItem));
			DropDownClosed = SerializableEvent.Register("DropDownClosed", typeof(EventHandler), typeof(ToolStripDropDownItem));
		}
	}
}
