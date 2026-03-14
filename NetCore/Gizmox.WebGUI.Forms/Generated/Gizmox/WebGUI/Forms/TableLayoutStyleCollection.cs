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
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.TableLayoutStyleCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.TableLayoutStyleCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[Editor("Gizmox.WebGUI.Forms.Design.StyleCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public abstract class TableLayoutStyleCollection : IList, ICollection, IEnumerable, IObservableList
	{
		private ArrayList mobjInnerList = new ArrayList();

		private IArrangedElement mobjOwner;

		/// 
		/// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection" />.
		/// </summary>
		/// </value>
		/// 
		/// The number of elements contained in the <see cref="T:System.Collections.ICollection" />.
		/// </returns>
		public int Count => mobjInnerList.Count;

		bool ICollection.IsSynchronized => mobjInnerList.IsSynchronized;

		object ICollection.SyncRoot => mobjInnerList.SyncRoot;

		bool IList.IsFixedSize => mobjInnerList.IsFixedSize;

		bool IList.IsReadOnly => mobjInnerList.IsReadOnly;

		object IList.this[int index]
		{
			get
			{
				return mobjInnerList[index];
			}
			set
			{
				TableLayoutStyle tableLayoutStyle = (TableLayoutStyle)value;
				EnsureNotOwned(tableLayoutStyle);
				tableLayoutStyle.Owner = Owner;
				mobjInnerList[index] = tableLayoutStyle;
				PerformLayoutIfOwned();
			}
		}

		internal IArrangedElement Owner => mobjOwner;

		internal virtual string PropertyName => null;

		/// 
		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.TableLayoutStyle" /> at the specified index.
		/// </summary>
		/// </value>
		public TableLayoutStyle this[int index]
		{
			get
			{
				return (TableLayoutStyle)((IList)this)[index];
			}
			set
			{
				((IList)this)[index] = value;
			}
		}

		/// 
		/// Occurs when [observable item added].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event ObservableListEventHandler ObservableItemAdded;

		/// 
		/// Occurs when [observable item inserted].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event ObservableListEventHandler ObservableItemInserted;

		/// 
		/// Occurs when [observable item removed].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event ObservableListEventHandler ObservableItemRemoved;

		/// 
		/// Occurs when [observable list cleared].
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public event EventHandler ObservableListCleared;

		internal TableLayoutStyleCollection(IArrangedElement objOwner)
		{
			mobjOwner = objOwner;
		}

		/// 
		/// Adds the specified style.
		/// </summary>
		/// <param name="objStyle">The style.</param>
		/// </returns>
		public int Add(TableLayoutStyle objStyle)
		{
			int result = ((IList)this).Add((object)objStyle);
			if (this.ObservableItemAdded != null)
			{
				this.ObservableItemAdded(this, new ObservableListEventArgs(objStyle));
			}
			return result;
		}

		/// 
		/// Removes all items from the <see cref="T:System.Collections.IList" />.
		/// </summary>
		/// <exception cref="T:System.NotSupportedException">
		/// The <see cref="T:System.Collections.IList" /> is read-only.
		/// </exception>
		public void Clear()
		{
			foreach (TableLayoutStyle mobjInner in mobjInnerList)
			{
				mobjInner.Owner = null;
			}
			mobjInnerList.Clear();
			PerformLayoutIfOwned();
			if (this.ObservableListCleared != null)
			{
				this.ObservableListCleared(this, EventArgs.Empty);
			}
		}

		/// 
		/// Removes the <see cref="T:System.Collections.IList" /> item at the specified index.
		/// </summary>
		/// <param name="index">The zero-based index of the item to remove.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		/// 	<paramref name="index" /> is not a valid index in the <see cref="T:System.Collections.IList" />.
		/// </exception>
		/// <exception cref="T:System.NotSupportedException">
		/// The <see cref="T:System.Collections.IList" /> is read-only.
		/// -or-
		/// The <see cref="T:System.Collections.IList" /> has a fixed size.
		/// </exception>
		public void RemoveAt(int index)
		{
			TableLayoutStyle tableLayoutStyle = (TableLayoutStyle)mobjInnerList[index];
			tableLayoutStyle.Owner = null;
			mobjInnerList.RemoveAt(index);
			PerformLayoutIfOwned();
			if (this.ObservableItemRemoved != null)
			{
				this.ObservableItemRemoved(this, new ObservableListEventArgs(tableLayoutStyle));
			}
		}

		private void EnsureNotOwned(TableLayoutStyle objStyle)
		{
			if (objStyle.Owner != null)
			{
				throw new ArgumentException(SR.GetString("OnlyOneControl", objStyle.GetType().Name), "style");
			}
		}

		void ICollection.CopyTo(Array objArray, int intStartIndex)
		{
			mobjInnerList.CopyTo(objArray, intStartIndex);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return mobjInnerList.GetEnumerator();
		}

		int IList.Add(object objStyle)
		{
			EnsureNotOwned((TableLayoutStyle)objStyle);
			((TableLayoutStyle)objStyle).Owner = Owner;
			int result = mobjInnerList.Add(objStyle);
			PerformLayoutIfOwned();
			return result;
		}

		bool IList.Contains(object objStyle)
		{
			return mobjInnerList.Contains(objStyle);
		}

		int IList.IndexOf(object objStyle)
		{
			return mobjInnerList.IndexOf(objStyle);
		}

		void IList.Insert(int intIndex, object objStyle)
		{
			EnsureNotOwned((TableLayoutStyle)objStyle);
			((TableLayoutStyle)objStyle).Owner = Owner;
			mobjInnerList.Insert(intIndex, objStyle);
			if (this.ObservableItemInserted != null)
			{
				this.ObservableItemInserted(this, new ObservableListEventArgs(objStyle));
			}
			PerformLayoutIfOwned();
		}

		void IList.Remove(object objStyle)
		{
			((TableLayoutStyle)objStyle).Owner = null;
			mobjInnerList.Remove(objStyle);
			PerformLayoutIfOwned();
		}

		private void PerformLayoutIfOwned()
		{
		}

		internal void EnsureOwnership(IArrangedElement objOwner)
		{
			mobjOwner = objOwner;
			for (int i = 0; i < Count; i++)
			{
				this[i].Owner = objOwner;
			}
		}
	}
}
