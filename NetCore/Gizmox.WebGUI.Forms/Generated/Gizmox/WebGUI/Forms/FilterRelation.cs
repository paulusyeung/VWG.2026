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
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class FilterRelation : SerializableObject, INotifyPropertyChanged, IComponent, IDisposable
	{
		internal static readonly SerializableEvent MemberChangedEvent = SerializableEvent.Register("Event", typeof(Delegate), typeof(FilterRelation));

		private string mstrSourceDataMember;

		private string mstrTargetDataMember;

		private ISite mobjSite;

		/// 
		/// Gets or sets the name of the target column data.
		/// </summary>
		/// 
		/// The name of the target column data.
		/// </value>
		public string TargetColumnDataName
		{
			get
			{
				return mstrTargetDataMember;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new Exception("TargetColumnDataName must not be null nor empty");
				}
				mstrTargetDataMember = value;
				OnPropertyChanged("TargetDataMember");
			}
		}

		/// 
		/// Gets or sets the name of the source column data.
		/// </summary>
		/// 
		/// The name of the source column data.
		/// </value>
		public string SourceColumnDataName
		{
			get
			{
				return mstrSourceDataMember;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new Exception("SourceColumnDataName must not be null nor empty");
				}
				mstrSourceDataMember = value;
				OnPropertyChanged("SourceDataMember");
			}
		}

		/// Gets or sets the <see cref="T:System.ComponentModel.ISite"></see> of the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see>.</summary>
		/// The <see cref="T:System.ComponentModel.ISite"></see> associated with the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see>, if any. null if the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see> is not encapsulated in an <see cref="T:System.ComponentModel.IContainer"></see>, the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see> does not have an <see cref="T:System.ComponentModel.ISite"></see> associated with it, or the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see> is removed from its <see cref="T:System.ComponentModel.IContainer"></see>.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual ISite Site
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

		/// 
		/// Occurs when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				AddHandler(MemberChangedEvent, value);
			}
			remove
			{
				RemoveHandler(MemberChangedEvent, value);
			}
		}

		/// 
		/// Represents the method that handles the <see cref="E:System.ComponentModel.IComponent.Disposed" /> event of a component.
		/// </summary>
		public event EventHandler Disposed;

		/// 
		/// Called when [property changed].
		/// </summary>
		/// <param name="strName">The name.</param>
		protected void OnPropertyChanged(string strName)
		{
			if (GetHandler(MemberChangedEvent) is PropertyChangedEventHandler propertyChangedEventHandler)
			{
				propertyChangedEventHandler(this, new PropertyChangedEventArgs(strName));
			}
		}

		/// Releases all resources used by the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see>.</summary>
		public void Dispose()
		{
			Dispose(disposing: true);
		}

		/// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.FilterRelation"></see> and optionally releases the managed resources.</summary>
		/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
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
			}
		}
	}
}
