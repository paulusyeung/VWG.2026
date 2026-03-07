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
	public class HierarchicInfo : SerializableObject, INotifyPropertyChanged, IComponent, IDisposable
	{
		internal static readonly SerializableEvent HierarchyInfoChangedEvent = SerializableEvent.Register("Event", typeof(Delegate), typeof(HierarchicInfo));

		private BindingSource mobjBindedSource;

		private ObservableCollection<object> mobjFilteringDataMembers;

		private List<object> mobjKeys;

		private ISite mobjSite;

		private SuspendableObservableCollection<object> mobjHiddenColumns;

		private string mstrHierarchyName;

		/// 
		/// Gets the hidden columns indicator.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public SuspendableObservableCollection<object> HiddenColumns
		{
			get
			{
				if (mobjHiddenColumns == null)
				{
					mobjHiddenColumns = new SuspendableObservableCollection<object>();
				}
				return mobjHiddenColumns;
			}
		}

		/// 
		/// Gets or sets the name of the hierarchy.
		/// </summary>
		/// 
		/// The name of the hierarchy.
		/// </value>
		public string HierarchyName
		{
			get
			{
				return mstrHierarchyName;
			}
			set
			{
				mstrHierarchyName = value;
			}
		}

		/// 
		/// Gets or sets the filtering data members.
		/// </summary>
		/// 
		/// The filtering data members.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ObservableCollection<object> FilteringDataMembers
		{
			get
			{
				if (mobjFilteringDataMembers == null)
				{
					FilteringDataMembers = new ObservableCollection<object>();
				}
				return mobjFilteringDataMembers;
			}
			set
			{
				if (mobjFilteringDataMembers != value)
				{
					AttachDetachEventsFromFilteringMembers(mobjFilteringDataMembers, blnAttach: false);
					mobjFilteringDataMembers = value;
					AttachDetachEventsFromFilteringMembers(mobjFilteringDataMembers, blnAttach: true);
					GenerateKeys();
					OnPropertyChanged("FilteringDataMembers");
				}
			}
		}

		/// 
		/// Gets or sets the keys.
		/// </summary>
		/// 
		/// The keys.
		/// </value>
		internal List<object> Keys => mobjKeys;

		/// 
		/// Gets or sets the binded source.
		/// </summary>
		/// 
		/// The binded source.
		/// </value>
		public BindingSource BindedSource
		{
			get
			{
				return mobjBindedSource;
			}
			set
			{
				if (mobjBindedSource != value)
				{
					mobjBindedSource = value;
					OnPropertyChanged("BindedSource");
				}
			}
		}

		/// Gets a value that indicates whether the <see cref="T:System.ComponentModel.Component"></see> is currently in design mode.</summary>
		/// true if the <see cref="T:System.ComponentModel.Component"></see> is in design mode; otherwise, false.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected bool DesignMode => mobjSite?.DesignMode ?? false;

		/// Gets or sets the <see cref="T:System.ComponentModel.ISite"></see> of the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see>.</summary>
		/// The <see cref="T:System.ComponentModel.ISite"></see> associated with the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see>, if any. null if the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see> is not encapsulated in an <see cref="T:System.ComponentModel.IContainer"></see>, the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see> does not have an <see cref="T:System.ComponentModel.ISite"></see> associated with it, or the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see> is removed from its <see cref="T:System.ComponentModel.IContainer"></see>.</returns>
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
				AddHandler(HierarchyInfoChangedEvent, value);
			}
			remove
			{
				RemoveHandler(HierarchyInfoChangedEvent, value);
			}
		}

		public event EventHandler Disposed;

		/// 
		/// Gets the cloned infos.
		/// </summary>
		/// <param name="objHierarchicInfos">The obj hierarchic infos.</param>
		/// <param name="blnIncludeRoot">if set to true</c> [includes root info].</param>
		/// </returns>
		internal static ObservableCollection<object> GetClonedInfos(ObservableCollection<object> objHierarchicInfos, bool blnIncludeRoot)
		{
			ObservableCollection<object> observableCollection = new ObservableCollection<object>();
			int num = ((!blnIncludeRoot) ? 1 : 0);
			for (int i = num; i < objHierarchicInfos.Count; i++)
			{
				observableCollection.Add(objHierarchicInfos[i]);
			}
			return observableCollection;
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo" /> class.
		/// </summary>
		public HierarchicInfo()
		{
			mobjKeys = new List<object>();
		}

		/// 
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			if (string.IsNullOrEmpty(mstrHierarchyName))
			{
				return BindedSource.CurrencyManager.GetListName();
			}
			return mstrHierarchyName;
		}

		/// 
		/// Attaches the detach events from filtering members.
		/// </summary>
		/// <param name="objFilteringDataMembers">The obj filtering data members.</param>
		/// <param name="blnAttach">if set to true</c> [BLN attach].</param>
		private void AttachDetachEventsFromFilteringMembers(ObservableCollection<object> objFilteringDataMembers, bool blnAttach)
		{
			if (objFilteringDataMembers == null || DesignMode)
			{
				return;
			}
			if (blnAttach)
			{
				objFilteringDataMembers.CollectionChanged += mobjFilteringDataMembers_CollectionChanged;
				{
					foreach (FilterRelation objFilteringDataMember in objFilteringDataMembers)
					{
						objFilteringDataMember.PropertyChanged += objFilterRelation_PropertyChanged;
					}
					return;
				}
			}
			objFilteringDataMembers.CollectionChanged -= mobjFilteringDataMembers_CollectionChanged;
			foreach (FilterRelation objFilteringDataMember2 in objFilteringDataMembers)
			{
				objFilteringDataMember2.PropertyChanged -= objFilterRelation_PropertyChanged;
			}
		}

		/// 
		/// Generates the keys.
		/// </summary>
		private void GenerateKeys()
		{
			Keys.Clear();
			foreach (FilterRelation mobjFilteringDataMember in mobjFilteringDataMembers)
			{
				Keys.Add(mobjFilteringDataMember.SourceColumnDataName);
			}
		}

		/// 
		/// Handles the CollectionChanged event of the mobjFilteringDataMembers control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
		private void mobjFilteringDataMembers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (DesignMode)
			{
				return;
			}
			if (e.NewItems != null)
			{
				foreach (FilterRelation newItem in e.NewItems)
				{
					newItem.PropertyChanged += objFilterRelation_PropertyChanged;
				}
			}
			if (e.OldItems != null)
			{
				foreach (FilterRelation oldItem in e.OldItems)
				{
					oldItem.PropertyChanged -= objFilterRelation_PropertyChanged;
				}
			}
			GenerateKeys();
			OnPropertyChanged("FilteringDataMembersChanged");
		}

		/// 
		/// Handles the PropertyChanged event of the objFilterRelation control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data.</param>
		private void objFilterRelation_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			GenerateKeys();
			OnPropertyChanged(e.PropertyName);
		}

		/// 
		/// Called when [property changed].
		/// </summary>
		/// <param name="strName">The name.</param>
		protected void OnPropertyChanged(string strName)
		{
			if (GetHandler(HierarchyInfoChangedEvent) is PropertyChangedEventHandler propertyChangedEventHandler)
			{
				propertyChangedEventHandler(this, new PropertyChangedEventArgs(strName));
			}
		}

		/// Releases all resources used by the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see>.</summary>
		public void Dispose()
		{
			Dispose(disposing: true);
		}

		/// Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.HierarchicInfo"></see> and optionally releases the managed resources.</summary>
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
				this.Disposed?.Invoke(this, EventArgs.Empty);
			}
		}
	}
}
