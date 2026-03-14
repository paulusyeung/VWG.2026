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
[Serializable]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutColumnStyleCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class TableLayoutColumnStyleCollection : TableLayoutStyleCollection, IObservableList
	{
		internal override string PropertyName => PropertyNames.ColumnStyles;

		/// 
		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.TableLayoutStyle" /> at the specified index.
		/// </summary>
		/// </value>
		public new ColumnStyle this[int index]
		{
			get
			{
				return (ColumnStyle)base[index];
			}
			set
			{
				this[index] = value;
			}
		}

		/// 
		/// Occurs when [observable item added].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event ObservableListEventHandler ObservableItemAdded;

		/// 
		/// Occurs when [observable item inserted].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event ObservableListEventHandler ObservableItemInserted;

		/// 
		/// Occurs when [observable item removed].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event ObservableListEventHandler ObservableItemRemoved;

		/// 
		/// Occurs when [observable list cleared].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler ObservableListCleared;

		internal TableLayoutColumnStyleCollection(IArrangedElement objOwner)
			: base(objOwner)
		{
		}

		internal TableLayoutColumnStyleCollection()
			: base(null)
		{
		}

		/// 
		/// Adds the specified column style.
		/// </summary>
		/// <param name="objcolumnStyle">The column style.</param>
		/// </returns>
		public int Add(ColumnStyle objcolumnStyle)
		{
			if (this.ObservableItemAdded != null)
			{
				this.ObservableItemAdded(this, new ObservableListEventArgs(objcolumnStyle));
			}
			return ((IList)this).Add((object)objcolumnStyle);
		}

		/// 
		/// Adds a new column style.
		/// </summary>
		/// <param name="intWidth"></param>
		/// </returns>
		public int Add(int intWidth)
		{
			ColumnStyle columnStyle = new ColumnStyle(intWidth.ToString());
			if (this.ObservableItemAdded != null)
			{
				this.ObservableItemAdded(this, new ObservableListEventArgs(columnStyle));
			}
			return Add(columnStyle);
		}

		/// 
		/// Determines whether [contains] [the specified column style].
		/// </summary>
		/// <param name="objcolumnStyle">The column style.</param>
		/// 
		/// 	true</c> if [contains] [the specified column style]; otherwise, false</c>.
		/// </returns>
		public bool Contains(ColumnStyle objcolumnStyle)
		{
			return ((IList)this).Contains((object)objcolumnStyle);
		}

		/// 
		/// Indexes the of.
		/// </summary>
		/// <param name="objcolumnStyle">The column style.</param>
		/// </returns>
		public int IndexOf(ColumnStyle objcolumnStyle)
		{
			return ((IList)this).IndexOf((object)objcolumnStyle);
		}

		/// 
		/// Inserts the specified index.
		/// </summary>
		/// <param name="intIndex">The index.</param>
		/// <param name="objcolumnStyle">The column style.</param>
		public void Insert(int intIndex, ColumnStyle objcolumnStyle)
		{
			if (this.ObservableItemInserted != null)
			{
				this.ObservableItemInserted(this, new ObservableListEventArgs(objcolumnStyle));
			}
			((IList)this).Insert(intIndex, (object)objcolumnStyle);
		}

		/// 
		/// Removes the specified column style.
		/// </summary>
		/// <param name="objcolumnStyle">The column style.</param>
		public void Remove(ColumnStyle objcolumnStyle)
		{
			if (this.ObservableItemRemoved != null)
			{
				this.ObservableItemRemoved(this, new ObservableListEventArgs(objcolumnStyle));
			}
			((IList)this).Remove((object)objcolumnStyle);
		}
	}
}
