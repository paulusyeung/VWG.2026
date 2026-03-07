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
	/// Represents a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects that are selected in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
	/// 2</filterpriority>
	[Serializable]
	[ListBindable(false)]
	public class DataGridViewSelectedRowCollection : BaseCollection, IList, ICollection, IEnumerable
	{
		private ArrayList mobjItems;

		/// Gets the row at the specified index.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> at the current index.</returns>
		/// <param name="index">The index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedRowCollection"></see>.</param>
		/// 1</filterpriority>
		public DataGridViewRow this[int index] => (DataGridViewRow)mobjItems[index];

		/// 
		/// Gets the list of elements contained in the <see cref="T:Gizmox.WebGUI.Forms.BaseCollection"></see> instance.
		/// </summary>
		/// </value>
		/// An <see cref="T:System.Collections.ArrayList"></see> containing the elements of the collection. This property returns null unless overridden in a derived class.</returns>
		protected override ArrayList List => mobjItems;

		int ICollection.Count => mobjItems.Count;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		bool IList.IsFixedSize => true;

		bool IList.IsReadOnly => true;

		object IList.this[int index]
		{
			get
			{
				return mobjItems[index];
			}
			set
			{
				throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
			}
		}

		internal DataGridViewSelectedRowCollection()
		{
			mobjItems = new ArrayList();
		}

		internal int Add(DataGridViewRow objDataGridViewRow)
		{
			return mobjItems.Add(objDataGridViewRow);
		}

		/// Clears the collection.</summary>
		/// <exception cref="T:System.NotSupportedException">Always thrown.</exception>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Clear()
		{
			throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
		}

		/// Determines whether the specified row is contained in the collection.</summary>
		/// true if dataGridViewRow is in the collection; otherwise, false.</returns>
		/// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to locate in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedRowCollection"></see>.</param>
		/// 1</filterpriority>
		public bool Contains(DataGridViewRow objDataGridViewRow)
		{
			return mobjItems.IndexOf(objDataGridViewRow) != -1;
		}

		/// Copies the elements of the collection to the specified array, starting at the specified index.</summary>
		/// <param name="arrRows">The one-dimensional array that is the destination of the elements copied from the collection. The array must have zero-based indexing.</param>
		/// <param name="index">The zero-based index in the array at which copying begins.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero.</exception>
		/// <exception cref="T:System.ArgumentException">array is multidimensional.-or-index is equal to or greater than the length of array.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> is greater than the available space from index to the end of array.</exception>
		/// <exception cref="T:System.InvalidCastException">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> cannot be cast automatically to the type of array.</exception>
		/// <exception cref="T:System.ArgumentNullException">array is null.</exception>
		/// 1</filterpriority>
		public void CopyTo(DataGridViewRow[] arrRows, int index)
		{
			mobjItems.CopyTo(arrRows, index);
		}

		/// Inserts a row into the collection at the specified position.</summary>
		/// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to insert into the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedRowCollection"></see>.</param>
		/// <param name="index">The zero-based index at which dataGridViewRow should be inserted. </param>
		/// <exception cref="T:System.NotSupportedException">Always thrown.</exception>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Insert(int index, DataGridViewRow objDataGridViewRow)
		{
			throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
		}

		void ICollection.CopyTo(Array objArray, int index)
		{
			mobjItems.CopyTo(objArray, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return mobjItems.GetEnumerator();
		}

		int IList.Add(object objValue)
		{
			throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
		}

		void IList.Clear()
		{
			throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
		}

		bool IList.Contains(object objValue)
		{
			return mobjItems.Contains(objValue);
		}

		int IList.IndexOf(object objValue)
		{
			return mobjItems.IndexOf(objValue);
		}

		void IList.Insert(int index, object objValue)
		{
			throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
		}

		void IList.Remove(object objValue)
		{
			throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
		}

		void IList.RemoveAt(int index)
		{
			throw new NotSupportedException(SR.GetString("DataGridView_ReadOnlyCollection"));
		}
	}
}
