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
	///
	/// </summary>
	[Serializable]
	[DesignTimeVisible(false)]
	[ToolboxItem(false)]
	public class ContextualTabGroup : SerializableObject, IComponent, IDisposable
	{
		private TabControl mobjTabControl = null;

		/// 
		/// Provides a property reference to Text property.
		/// </summary>
		private static SerializableProperty TextProperty = SerializableProperty.Register("TextProperty", typeof(string), typeof(ContextualTabGroup), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// The disposed event 
		/// </summary>
		private static readonly SerializableEvent DisposedEvent;

		[NonSerialized]
		private ISite mobjSite;

		/// 
		/// Gets or sets the contextual tab group key.
		/// </summary>
		/// 
		/// The contextual tab group text.
		/// </value>
		[DefaultValue("")]
		public string Text
		{
			get
			{
				return GetValue(TextProperty);
			}
			set
			{
				if (SetValue(TextProperty, value) && mobjTabControl != null)
				{
					mobjTabControl.Update();
				}
			}
		}

		/// 
		/// Gets or sets the tab control internal.
		/// </summary>
		/// 
		/// The tab control internal.
		/// </value>
		internal TabControl TabControlInternal
		{
			get
			{
				return mobjTabControl;
			}
			set
			{
				mobjTabControl = value;
			}
		}

		/// 
		/// Gets or sets the <see cref="T:System.ComponentModel.ISite" /> associated with the <see cref="T:System.ComponentModel.IComponent" />.
		/// </summary>
		/// The <see cref="T:System.ComponentModel.ISite" /> object associated with the component; or null, if the component does not have a site.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ISite Site
		{
			get
			{
				return mobjSite;
			}
			set
			{
				mobjSite = value;
			}
		}

		/// Adds an event handler to listen to the <see cref="E:System.ComponentModel.Component.Disposed"></see> event on the component.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public event EventHandler Disposed
		{
			add
			{
				AddHandler(DisposedEvent, value);
			}
			remove
			{
				RemoveHandler(DisposedEvent, value);
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup" /> class.
		/// </summary>
		public ContextualTabGroup()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ContextualTabGroup" /> class.
		/// </summary>
		/// <param name="strKey">The contextual tab group Key.</param>
		/// <param name="strText">The contextual tab group Text.</param>
		public ContextualTabGroup(string strText)
		{
			Text = strText;
		}

		/// 
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			string text = Text;
			if (!string.IsNullOrEmpty(text))
			{
				text = " [" + text + "]";
			}
			ISite site = mobjSite;
			if (site != null)
			{
				return site.Name + text;
			}
			return GetType().FullName + text;
		}

		/// 
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(disposing: true);
		}

		/// 
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing">true</c> to release both managed and unmanaged resources; false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (!disposing)
			{
				return;
			}
			lock (this)
			{
				if (mobjSite != null && mobjSite.Container != null)
				{
					mobjSite.Container.Remove(this);
				}
				((EventHandler)GetHandler(Disposed))?.Invoke(this, EventArgs.Empty);
			}
		}

		static ContextualTabGroup()
		{
			Disposed = SerializableEvent.Register("DisposedEvent", typeof(EventHandler), typeof(ContextualTabGroup));
		}
	}
}
