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
	/// Represents a Gizmox.WebGUI.Forms status bar control. Although <see cref="T:Gizmox.WebGUI.Forms.ToolStripStatusLabel"></see> replaces and adds functionality to the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control of previous versions, <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> is retained for both backward compatibility and future use if you choose.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(StatusBar), "StatusBar_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.StatusBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.StatusBarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DefaultProperty("Text")]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("SB")]
	[Skin(typeof(StatusBarSkin))]
	[ProxyComponent(typeof(ProxyStatusBar))]
	public class StatusBar : Control
	{
		/// 
		/// Represents the collection of panels in a <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control.
		/// </summary>
		[Serializable]
		[ListBindable(false)]
		public class StatusBarPanelCollection : ICollection, IEnumerable, IList, IObservableList
		{
			private ArrayList mobjList;

			private StatusBar mobjStatusBar;

			/// 
			/// Gets a value indicating whether this collection is read-only.
			/// </summary>
			/// true if this collection is read-only; otherwise, false.</returns>
			public bool IsReadOnly => mobjList.IsReadOnly;

			/// 
			/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> at the specified index.
			/// </summary>
			/// A <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> representing the panel located at the specified index within the collection.</returns>
			/// <param name="index">The index of the panel in the collection to get or set. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanelCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> class. </exception>
			/// <exception cref="T:System.ArgumentNullException">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> assigned to the collection was null. </exception>
			public StatusBarPanel this[int index]
			{
				get
				{
					return (StatusBarPanel)mobjList[index];
				}
				set
				{
					mobjList[index] = value;
				}
			}

			/// 
			/// Gets a value indicating whether the collection has a fixed size.
			/// </summary>
			/// false in all cases.</returns>
			public bool IsFixedSize => mobjList.IsFixedSize;

			/// 
			/// Gets a value indicating whether access to the collection is synchronized (thread safe).
			/// </summary>
			/// false in all cases.</returns>
			public bool IsSynchronized => mobjList.IsSynchronized;

			/// 
			/// Gets the number of items in the collection.
			/// </summary>
			/// The number of <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> objects in the collection.</returns>
			[EditorBrowsable(EditorBrowsableState.Never)]
			[Browsable(false)]
			public int Count => mobjList.Count;

			/// 
			/// Gets an object that can be used to synchronize access to the collection.
			/// </summary>
			/// The object used to synchronize access to the collection.</returns>
			public object SyncRoot => mobjList.SyncRoot;

			bool IList.IsFixedSize => false;

			bool IList.IsReadOnly => false;

			object IList.this[int index]
			{
				get
				{
					return this[index];
				}
				set
				{
					this[index] = (StatusBarPanel)value;
				}
			}

			int ICollection.Count => mobjList.Count;

			bool ICollection.IsSynchronized => mobjList.IsSynchronized;

			object ICollection.SyncRoot => mobjList.SyncRoot;

			/// 
			/// Occurs when [observable item inserted].
			/// </summary>
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public event ObservableListEventHandler ObservableItemInserted;

			/// 
			/// Occurs when [observable item added].
			/// </summary>
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public event ObservableListEventHandler ObservableItemAdded;

			/// 
			/// Occurs when [observable list cleared].
			/// </summary>
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public event EventHandler ObservableListCleared;

			/// 
			/// Occurs when [observable item removed].
			/// </summary>
			[Browsable(false)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public event ObservableListEventHandler ObservableItemRemoved;

			/// 
			/// Removes the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> located at the specified index within the collection.
			/// </summary>
			/// <param name="index">The zero-based index of the item to remove. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than or equal to the value of the <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanelCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> class. </exception>
			public void RemoveAt(int index)
			{
				object objItem = this[index];
				mobjList.RemoveAt(index);
				if (this.ObservableItemRemoved != null)
				{
					this.ObservableItemRemoved(this, new ObservableListEventArgs(objItem));
				}
			}

			/// 
			/// Inserts the specified <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> into the collection at the specified index.
			/// </summary>
			/// <param name="value">A <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> representing the panel to insert. </param>
			/// <param name="index">The zero-based index location where the panel is inserted. </param>
			/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanel.AutoSize"></see> property of the value parameter's panel is not a valid <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelAutoSize"></see> value. </exception>
			/// <exception cref="T:System.ArgumentNullException">The value parameter is null. </exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index parameter is less than zero or greater than the value of the <see cref="P:Gizmox.WebGUI.Forms.StatusBarPanelCollection.Count"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> class. </exception>
			/// <exception cref="T:System.ArgumentException">The value parameter's parent is not null. </exception>
			public void Insert(int index, StatusBarPanel value)
			{
				mobjList.Insert(index, value);
				if (this.ObservableItemInserted != null)
				{
					this.ObservableItemInserted(this, new ObservableListEventArgs(value));
				}
			}

			/// 
			/// Removes the specified <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> from the collection.
			/// </summary>
			/// <param name="value">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> representing the panel to remove from the collection. </param>
			/// <exception cref="T:System.ArgumentNullException">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> assigned to the value parameter is null. </exception>
			public void Remove(StatusBarPanel value)
			{
				mobjList.Remove(value);
				if (this.ObservableItemRemoved != null)
				{
					this.ObservableItemRemoved(this, new ObservableListEventArgs(value));
				}
			}

			/// 
			/// Determines whether the specified panel is located within the collection.
			/// </summary>
			/// true if the panel is located within the collection; otherwise, false.</returns>
			/// <param name="objPanel">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> to locate in the collection. </param>
			public bool Contains(StatusBarPanel objPanel)
			{
				return mobjList.Contains(objPanel);
			}

			/// 
			/// Removes all items from the collection.
			/// </summary>
			public void Clear()
			{
				mobjList.Clear();
				if (this.ObservableListCleared != null)
				{
					this.ObservableListCleared(this, EventArgs.Empty);
				}
			}

			/// 
			/// Returns the index within the collection of the specified panel.
			/// </summary>
			/// The zero-based index where the panel is located within the collection; otherwise, negative one (-1).</returns>
			/// <param name="objPanel">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> to locate in the collection. </param>
			public int IndexOf(StatusBarPanel objPanel)
			{
				return mobjList.IndexOf(objPanel);
			}

			/// 
			/// Adds a <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> to the collection.
			/// </summary>
			/// The zero-based index of the item in the collection.</returns>
			/// <param name="value">A <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> that represents the panel to add to the collection. </param>
			/// <exception cref="T:System.ArgumentException">The parent of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> specified in the value parameter is not null. </exception>
			/// <exception cref="T:System.ArgumentNullException">The <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> being added to the collection was null. </exception>
			public int Add(StatusBarPanel value)
			{
				value.InternalParent = mobjStatusBar;
				int result = mobjList.Add(value);
				if (this.ObservableItemAdded != null)
				{
					this.ObservableItemAdded(this, new ObservableListEventArgs(value));
				}
				return result;
			}

			/// 
			/// Adds an array of <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> objects to the collection.
			/// </summary>
			/// <param name="arrPnels">An array of <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> objects to add. </param>
			/// <exception cref="T:System.ArgumentNullException">The array of <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> objects being added to the collection was null. </exception>
			public void AddRange(StatusBarPanel[] arrPnels)
			{
				foreach (StatusBarPanel value in arrPnels)
				{
					Add(value);
				}
			}

			/// 
			/// Copies the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> to a compatible one-dimensional array, starting at the specified index of the target array.
			/// </summary>
			/// <param name="objDestinationArray">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.  </param>
			/// <param name="index">The zero-based index in the array at which copying begins.</param>
			/// <exception cref="T:System.InvalidCastException">The type in the collection cannot be cast automatically to the type of array.</exception>
			/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero.</exception>
			/// <exception cref="T:System.ArgumentException">array is multidimensional.-or-index is equal to or greater than the length of array.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> is greater than the available space from index to the end of array.</exception>
			/// <exception cref="T:System.ArgumentNullException">array is null.</exception>
			public void CopyTo(Array objDestinationArray, int index)
			{
				mobjList.CopyTo(objDestinationArray, index);
			}

			/// 
			/// Returns an enumerator to use to iterate through the item collection.
			/// </summary>
			/// An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
			public IEnumerator GetEnumerator()
			{
				return mobjList.GetEnumerator();
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> class.
			/// </summary>
			/// <param name="objStatusBar">The <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control that contains this collection. </param>
			public StatusBarPanelCollection(StatusBar objStatusBar)
			{
				mobjStatusBar = objStatusBar;
				mobjList = new ArrayList();
			}

			int IList.Add(object objValue)
			{
				((StatusBarPanel)objValue).InternalParent = mobjStatusBar;
				return Add((StatusBarPanel)objValue);
			}

			void IList.Clear()
			{
				Clear();
			}

			bool IList.Contains(object objValue)
			{
				return Contains((StatusBarPanel)objValue);
			}

			int IList.IndexOf(object objValue)
			{
				return IndexOf((StatusBarPanel)objValue);
			}

			void IList.Insert(int index, object objValue)
			{
				this[index] = (StatusBarPanel)objValue;
			}

			void IList.Remove(object objValue)
			{
				Remove((StatusBarPanel)objValue);
			}

			void IList.RemoveAt(int index)
			{
				Remove(this[index]);
			}

			void ICollection.CopyTo(Array objArray, int index)
			{
				mobjList.CopyTo(objArray, index);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return mobjList.GetEnumerator();
			}
		}

		/// 
		/// Provides a property reference to StatusBarPanelCollection property.
		/// </summary>
		private static SerializableProperty StatusBarPanelCollectionProperty = SerializableProperty.Register("StatusBarPanelCollection", typeof(StatusBarPanelCollection), typeof(StatusBar));

		/// 
		/// Provides a property reference to ShowPanels property.
		/// </summary>
		private static SerializableProperty ShowPanelsProperty = SerializableProperty.Register("ShowPanels", typeof(bool), typeof(StatusBar));

		/// 
		/// Gets or sets a value indicating whether tab stop is enabled.
		/// </summary>
		/// true</c> if tab stop is enabled; otherwise, false</c>.</value>
		[DefaultValue(false)]
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
		/// Gets the default back color internal.
		/// </summary>
		/// The default back color internal.</value>
		internal Color DefaultBackColorInternal => base.DefaultBackColor;

		/// 
		/// Gets the default fore color internal.
		/// </summary>
		/// The default fore color internal.</value>
		internal Color DefaultForeColorInternal => base.DefaultForeColor;

		/// 
		/// Gets or sets a value indicating whether any panels that have been added to the control are displayed.
		/// </summary>
		/// true if panels are displayed; otherwise, false. The default is false.</returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		[SRDescription("StatusBarShowPanelsDescr")]
		public bool ShowPanels
		{
			get
			{
				return GetValue(ShowPanelsProperty, objDefault: false);
			}
			set
			{
				if (ShowPanels != value)
				{
					if (!value)
					{
						RemoveValue(ShowPanelsProperty);
					}
					else
					{
						SetValue(ShowPanelsProperty, value);
					}
					Update();
					FireObservableItemPropertyChanged("ShowPanels");
				}
			}
		}

		/// 
		/// Gets/Sets the controls docking style
		/// </summary>
		/// </value>
		[Localizable(true)]
		[DefaultValue(DockStyle.Bottom)]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				base.Dock = value;
			}
		}

		/// 
		/// Gets the collection of <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> panels contained within the control.
		/// </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanelCollection"></see> containing the <see cref="T:Gizmox.WebGUI.Forms.StatusBarPanel"></see> objects of the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> control.</returns>
		[Browsable(true)]
		[SRCategory("CatAppearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRDescription("StatusBarPanelsDescr")]
		[Localizable(true)]
		[MergableProperty(false)]
		public StatusBarPanelCollection Panels
		{
			get
			{
				StatusBarPanelCollection statusBarPanelCollection = GetValue(StatusBarPanelCollectionProperty, null);
				if (statusBarPanelCollection == null)
				{
					statusBarPanelCollection = CreatePanelsCollection();
					SetValue(StatusBarPanelCollectionProperty, statusBarPanelCollection);
				}
				return statusBarPanelCollection;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.StatusBar"></see> class.
		/// </summary>
		public StatusBar()
		{
			SetStyle(ControlStyles.Selectable | ControlStyles.UserPaint, blnValue: false);
			Dock = DockStyle.Bottom;
			TabStop = false;
		}

		/// 
		/// Called when [register components].
		/// </summary>
		protected override void OnRegisterComponents()
		{
			base.OnRegisterComponents();
			StatusBarPanelCollection panels = Panels;
			if (panels != null)
			{
				RegisterBatch(panels);
			}
		}

		/// 
		/// Called when [unregister components].
		/// </summary>
		protected override void OnUnregisterComponents()
		{
			base.OnUnregisterComponents();
			StatusBarPanelCollection panels = Panels;
			if (panels != null)
			{
				UnRegisterBatch(panels);
			}
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			if (Panels.Count == 0 || !ShowPanels)
			{
				objWriter.WriteAttributeText("TX", Text, (TextFilter)5);
			}
		}

		/// 
		/// Gets the status bar critical events.
		/// </summary>
		/// </returns>
		internal CriticalEventsData GetStatusBarCriticalEventsData()
		{
			return GetCriticalEventsData();
		}

		/// 
		/// Fires the status bar event.
		/// </summary>
		/// <param name="objEvent">The obj event.</param>
		internal void FireStatusBarEvent(IEvent objEvent)
		{
			FireEvent(objEvent);
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
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				objWriter.WriteAttributeText("TX", Text, (TextFilter)5);
			}
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			if (!ShowPanels)
			{
				return;
			}
			foreach (StatusBarPanel panel in Panels)
			{
				RegisterComponent(panel);
				panel.RenderPanel(objContext, objWriter, lngRequestID);
			}
		}

		/// 
		/// Gets the component offsprings.
		/// </summary>
		/// <param name="strOffspringTypeName">The offspring type.</param>
		/// </returns>
		protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
		{
			return Panels;
		}

		/// 
		/// Creates the panels Collection.
		/// </summary>
		/// </returns>
		[Browsable(false)]
		protected virtual StatusBarPanelCollection CreatePanelsCollection()
		{
			return new StatusBarPanelCollection(this);
		}
	}
}
