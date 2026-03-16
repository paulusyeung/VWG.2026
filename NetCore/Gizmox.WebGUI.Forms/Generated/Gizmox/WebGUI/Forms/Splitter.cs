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
	/// Represents a splitter control that enables the user to resize docked controls. <see cref="T:Gizmox.WebGUI.Forms.Splitter"></see> has been replaced by <see cref="T:System.Windows.Forms.SplitContainer"></see> and is provided only for compatibility with previous versions.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(Splitter), "Splitter_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.SplitterController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.SplitterController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("S")]
	[Skin(typeof(SplitterSkin))]
	public class Splitter : Control
	{
		/// 
		/// The SplitterMoved event registration.
		/// </summary>
		private static readonly SerializableEvent SplitterMovedEvent;

		private static readonly SerializableProperty SplitterFixedProperty;

		/// 
		/// Gets the hanlder for the SplitterMoved event.
		/// </summary>
		private SplitterEventHandler SplitterMovedHandler => (SplitterEventHandler)GetHandler(SplitterMovedEvent);

		/// 
		/// Gets or sets a value indicating whether in this instance the splitter is fixed or movable.
		/// </summary>
		/// 
		/// 	true</c> if this instance is splitter fixed. otherwise, false</c>.
		/// </value>
		[SRCategory("CatLayout")]
		[DefaultValue(false)]
		public bool IsSplitterFixed
		{
			get
			{
				return GetValue(SplitterFixedProperty);
			}
			set
			{
				if (SetValue(SplitterFixedProperty, value))
				{
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether tab stop is enabled.
		/// </summary>
		/// true</c> if tab stop is enabled; otherwise, false</c>.</value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new bool TabStop
		{
			get
			{
				return base.TabStop;
			}
			set
			{
				base.TabStop = value;
			}
		}

		/// 
		/// Gets/Sets the controls docking style
		/// </summary>
		[DefaultValue(DockStyle.Left)]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				if (value != DockStyle.Top && value != DockStyle.Bottom && value != DockStyle.Left && value != DockStyle.Right)
				{
					throw new ArgumentException(SR.GetString("SplitterInvalidDockEnum"));
				}
				int width = base.Width;
				int height = base.Height;
				DockStyle dock = base.Dock;
				if (dock == value)
				{
					return;
				}
				base.Dock = value;
				switch (Dock)
				{
				case DockStyle.Top:
				case DockStyle.Bottom:
					if (dock == DockStyle.Left || dock == DockStyle.Right)
					{
						base.Height = width;
					}
					break;
				case DockStyle.Right:
				case DockStyle.Left:
					if (dock == DockStyle.Top || dock == DockStyle.Bottom)
					{
						base.Width = height;
					}
					break;
				}
			}
		}

		/// 
		/// Occurs when the Splitter is Moved.
		/// </summary>
		[SRDescription("SplitterSplitterMovedDescr")]
		[SRCategory("CatBehavior")]
		public event SplitterEventHandler SplitterMoved
		{
			add
			{
				AddCriticalHandler(SplitterMovedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(SplitterMovedEvent, value);
			}
		}

		/// 
		/// Occurs when [client splitter moved].
		/// </summary>
		[SRDescription("Occurs when splitter moved in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientSplitterMoved
		{
			add
			{
				AddClientHandler("SplitterMoved", value);
			}
			remove
			{
				RemoveClientHandler("SplitterMoved", value);
			}
		}

		/// 
		/// An abstract control method rendering
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			RenderControls(objContext, objWriter, 0L);
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			RenderIsSplitterFixedAttribute(objWriter, blnForceRender: false);
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
				RenderIsSplitterFixedAttribute(objWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the is splitter fixed attribute.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderIsSplitterFixedAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			bool isSplitterFixed = IsSplitterFixed;
			if (blnForceRender || isSplitterFixed)
			{
				objWriter.WriteAttributeString("ISF", isSplitterFixed ? "1" : "0");
			}
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			int num = 0;
			int num2 = 0;
			double dblValue = 0.0;
			int num3 = 0;
			if (objEvent.Type == "SplitterMoved")
			{
				if (CommonUtils.TryParse(objEvent["Size"], out dblValue))
				{
					num3 = Convert.ToInt32(dblValue);
				}
				if (CommonUtils.TryParse(objEvent["X"], out dblValue))
				{
					num = Convert.ToInt32(dblValue);
				}
				if (CommonUtils.TryParse(objEvent["Y"], out dblValue))
				{
					num2 = Convert.ToInt32(dblValue);
				}
				if (Context != null && Context.Session != null && ((ISessionRegistry)Context).GetRegisteredComponent(objEvent.Target) is Control control)
				{
					switch (Dock)
					{
					case DockStyle.Right:
					case DockStyle.Left:
						if (control.SetBounds(0, 0, num3, 0, BoundsSpecified.Width))
						{
							control.OnResizeInternal(new LayoutEventArgs(blnIsClientSource: true, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
						}
						break;
					case DockStyle.Top:
					case DockStyle.Bottom:
						if (control.SetBounds(0, 0, 0, num3, BoundsSpecified.Height, blnIsClientSource: true))
						{
							control.OnResizeInternal(new LayoutEventArgs(blnIsClientSource: true, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
						}
						break;
					}
				}
				OnSplitterMoved(new SplitterEventArgs(num, num2, num, num2));
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
			if (SplitterMovedHandler != null)
			{
				criticalEventsData.Set("PC");
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
			if (HasClientHandler("SplitterMoved"))
			{
				criticalClientEventsData.Set("PC");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Splitter"></see> class. <see cref="T:Gizmox.WebGUI.Forms.Splitter"></see> has been replaced by <see cref="T:Gizmox.WebGUI.Forms.SplitContainer"></see>, and is provided only for compatibility with previous versions.
		/// </summary>
		public Splitter()
		{
			SetStyle(ControlStyles.Selectable, blnValue: false);
			Dock = DockStyle.Left;
			base.Width = 3;
			base.Height = 3;
			TabStop = false;
		}

		/// 
		/// Raises the SplitterMoved event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.SplitterEventArgs" /> instance containing the event data.</param>
		protected virtual void OnSplitterMoved(SplitterEventArgs e)
		{
			SplitterMovedHandler?.Invoke(this, e);
		}

		static Splitter()
		{
			SplitterMovedEvent = SerializableEvent.Register("SplitterMoved", typeof(SplitterEventHandler), typeof(Splitter));
			SplitterFixedProperty = SerializableProperty.Register("SplitterFixed", typeof(bool), typeof(Splitter), new SerializablePropertyMetadata(false));
		}
	}
}
