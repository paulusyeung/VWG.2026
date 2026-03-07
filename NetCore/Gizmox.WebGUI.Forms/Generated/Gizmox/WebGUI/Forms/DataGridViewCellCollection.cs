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
	/// Represents a collection of cells in a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</summary>
	/// 2</filterpriority>
	[Serializable]
	[ListBindable(false)]
	public class DataGridViewCellCollection : BaseCollection, IList, ICollection, IEnumerable
	{
		private ArrayList mobjItems;

		private DataGridViewRow mobjOwner;

		/// Gets or sets the cell at the provided index location. In C#, this property is the indexer for the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> class.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> stored at the given index.</returns>
		/// <param name="index">The zero-based index of the cell to get or set.</param>
		/// <exception cref="T:System.InvalidOperationException">The specified cell when setting this property already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-The specified cell when setting this property already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
		/// <exception cref="T:System.ArgumentNullException">The specified value when setting this property is null.</exception>
		/// 1</filterpriority>
		public DataGridViewCell this[int index]
		{
			get
			{
				return (DataGridViewCell)mobjItems[index];
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.DataGridView != null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CellAlreadyBelongsToDataGridView"));
				}
				if (value.OwningRow != null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CellAlreadyBelongsToDataGridViewRow"));
				}
				if (mobjOwner.DataGridView != null)
				{
					mobjOwner.DataGridView.OnReplacingCell(mobjOwner, index);
				}
				DataGridViewCell dataGridViewCell = (DataGridViewCell)mobjItems[index];
				mobjItems[index] = value;
				value.OwningRowInternal = mobjOwner;
				value.StateInternal = dataGridViewCell.State;
				if (mobjOwner.DataGridView != null)
				{
					value.DataGridViewInternal = mobjOwner.DataGridView;
					value.OwningColumnInternal = mobjOwner.DataGridView.Columns[index];
					mobjOwner.DataGridView.OnReplacedCell(mobjOwner, index);
				}
				dataGridViewCell.DataGridViewInternal = null;
				dataGridViewCell.OwningRowInternal = null;
				dataGridViewCell.OwningColumnInternal = null;
				if (dataGridViewCell.ReadOnly)
				{
					dataGridViewCell.ReadOnlyInternal = false;
				}
				if (dataGridViewCell.Selected && mobjOwner != null && mobjOwner.DataGridView != null)
				{
					mobjOwner.DataGridView.SetSelectedCellCore(dataGridViewCell, blnValue: false, blnClientSource: false);
				}
			}
		}

		/// Gets or sets the cell in the column with the provided name. In C#, this property is the indexer for the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> class.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> stored in the column with the given name.</returns>
		/// <param name="strColumnName">The name of the column in which to get or set the cell.</param>
		/// <exception cref="T:System.InvalidOperationException">The specified cell when setting this property already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-The specified cell when setting this property already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
		/// <exception cref="T:System.ArgumentException">columnName does not match the name of any columns in the control.</exception>
		/// <exception cref="T:System.ArgumentNullException">The specified value when setting this property is null.</exception>
		/// 1</filterpriority>
		public DataGridViewCell this[string strColumnName]
		{
			get
			{
				DataGridViewColumn dataGridViewColumn = null;
				if (mobjOwner.DataGridView != null)
				{
					dataGridViewColumn = mobjOwner.DataGridView.Columns[strColumnName];
				}
				if (dataGridViewColumn == null)
				{
					throw new ArgumentException(SR.GetString("DataGridViewColumnCollection_ColumnNotFound", strColumnName), "columnName");
				}
				return (DataGridViewCell)mobjItems[dataGridViewColumn.Index];
			}
			set
			{
				DataGridViewColumn dataGridViewColumn = null;
				if (mobjOwner.DataGridView != null)
				{
					dataGridViewColumn = mobjOwner.DataGridView.Columns[strColumnName];
				}
				if (dataGridViewColumn == null)
				{
					throw new ArgumentException(SR.GetString("DataGridViewColumnCollection_ColumnNotFound", strColumnName), "columnName");
				}
				this[dataGridViewColumn.Index] = value;
			}
		}

		/// Gets an <see cref="T:System.Collections.ArrayList"></see> containing <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> objects.</summary>
		/// <see cref="T:System.Collections.ArrayList"></see>.</returns>
		protected override ArrayList List => mobjItems;

		int ICollection.Count => mobjItems.Count;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

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
				this[index] = (DataGridViewCell)value;
			}
		}

		/// Occurs when the collection is changed. </summary>
		/// 1</filterpriority>
		public event CollectionChangeEventHandler CollectionChanged;

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> class.</summary>
		/// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that owns the collection.</param>
		public DataGridViewCellCollection(DataGridViewRow objDataGridViewRow)
		{
			mobjItems = new ArrayList();
			mobjOwner = objDataGridViewRow;
		}

		/// Adds a cell to the collection.</summary>
		/// The position in which to insert the new element.</returns>
		/// <param name="objDataGridViewCell">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to add to the collection.</param>
		/// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-dataGridViewCell already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
		/// 1</filterpriority>
		public virtual int Add(DataGridViewCell objDataGridViewCell)
		{
			if (mobjOwner.DataGridView != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
			}
			if (objDataGridViewCell.OwningRow != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CellAlreadyBelongsToDataGridViewRow"));
			}
			return AddInternal(objDataGridViewCell);
		}

		internal int AddInternal(DataGridViewCell objDataGridViewCell)
		{
			int num = mobjItems.Add(objDataGridViewCell);
			objDataGridViewCell.OwningRowInternal = mobjOwner;
			DataGridView dataGridView = mobjOwner.DataGridView;
			if (dataGridView != null && dataGridView.Columns.Count > num)
			{
				objDataGridViewCell.OwningColumnInternal = dataGridView.Columns[num];
			}
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewCell));
			return num;
		}

		/// Adds an array of cells to the collection.</summary>
		/// <param name="arrDataGridViewCells">The array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> objects to add to the collection.</param>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewCells is null.</exception>
		/// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-At least one value in dataGridViewCells is null.-or-At least one cell in dataGridViewCells already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.-or-At least two values in dataGridViewCells are references to the same <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual void AddRange(params DataGridViewCell[] arrDataGridViewCells)
		{
			if (arrDataGridViewCells == null)
			{
				throw new ArgumentNullException("dataGridViewCells");
			}
			if (mobjOwner.DataGridView != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
			}
			foreach (DataGridViewCell dataGridViewCell in arrDataGridViewCells)
			{
				if (dataGridViewCell == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_AtLeastOneCellIsNull"));
				}
				if (dataGridViewCell.OwningRow != null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CellAlreadyBelongsToDataGridViewRow"));
				}
			}
			int num = arrDataGridViewCells.Length;
			for (int j = 0; j < num - 1; j++)
			{
				for (int k = j + 1; k < num; k++)
				{
					if (arrDataGridViewCells[j] == arrDataGridViewCells[k])
					{
						throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CannotAddIdenticalCells"));
					}
				}
			}
			mobjItems.AddRange(arrDataGridViewCells);
			foreach (DataGridViewCell dataGridViewCell2 in arrDataGridViewCells)
			{
				dataGridViewCell2.OwningRowInternal = mobjOwner;
			}
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
		}

		/// Clears all cells from the collection.</summary>
		/// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		/// 1</filterpriority>
		public virtual void Clear()
		{
			if (mobjOwner.DataGridView != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
			}
			foreach (DataGridViewCell mobjItem in mobjItems)
			{
				mobjItem.OwningRowInternal = null;
			}
			mobjItems.Clear();
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null));
		}

		/// Determines whether the specified cell is contained in the collection.</summary>
		/// true if dataGridViewCell is in the collection; otherwise, false.</returns>
		/// <param name="objDataGridViewCell">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to locate in the collection.</param>
		/// 1</filterpriority>
		public virtual bool Contains(DataGridViewCell objDataGridViewCell)
		{
			int num = mobjItems.IndexOf(objDataGridViewCell);
			return num != -1;
		}

		/// Copies the entire collection of cells into an array at a specified location within the array.</summary>
		/// <param name="arrCells">The destination array to which the contents will be copied.</param>
		/// <param name="index">The index of the element in array at which to start copying.</param>
		/// 1</filterpriority>
		public void CopyTo(DataGridViewCell[] arrCells, int index)
		{
			mobjItems.CopyTo(arrCells, index);
		}

		/// Returns the index of the specified cell.</summary>
		/// The zero-based index of the value of dataGridViewCell parameter, if it is found in the collection; otherwise, -1.</returns>
		/// <param name="objDataGridViewCell">The cell to locate in the collection.</param>
		/// 1</filterpriority>
		public int IndexOf(DataGridViewCell objDataGridViewCell)
		{
			return mobjItems.IndexOf(objDataGridViewCell);
		}

		/// Inserts a cell into the collection at the specified index. </summary>
		/// <param name="objDataGridViewCell">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to insert.</param>
		/// <param name="index">The zero-based index at which to place dataGridViewCell.</param>
		/// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-dataGridViewCell already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
		/// 1</filterpriority>
		public virtual void Insert(int index, DataGridViewCell objDataGridViewCell)
		{
			if (mobjOwner.DataGridView != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
			}
			if (objDataGridViewCell.OwningRow != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_CellAlreadyBelongsToDataGridViewRow"));
			}
			mobjItems.Insert(index, objDataGridViewCell);
			objDataGridViewCell.OwningRowInternal = mobjOwner;
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewCell));
		}

		internal void InsertInternal(int index, DataGridViewCell objDataGridViewCell)
		{
			mobjItems.Insert(index, objDataGridViewCell);
			objDataGridViewCell.OwningRowInternal = mobjOwner;
			DataGridView dataGridView = mobjOwner.DataGridView;
			if (dataGridView != null && dataGridView.Columns.Count > index)
			{
				objDataGridViewCell.OwningColumnInternal = dataGridView.Columns[index];
			}
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewCell));
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridViewCellCollection.CollectionChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains the event data. </param>
		protected void OnCollectionChanged(CollectionChangeEventArgs e)
		{
			this.CollectionChanged?.Invoke(this, e);
		}

		/// Removes the specified cell from the collection.</summary>
		/// <param name="objCell">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to remove from the collection.</param>
		/// <exception cref="T:System.ArgumentException">cell could not be found in the collection.</exception>
		/// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		/// 1</filterpriority>
		public virtual void Remove(DataGridViewCell objCell)
		{
			if (mobjOwner.DataGridView != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
			}
			int num = -1;
			int count = mobjItems.Count;
			for (int i = 0; i < count; i++)
			{
				if (mobjItems[i] == objCell)
				{
					num = i;
					break;
				}
			}
			if (num == -1)
			{
				throw new ArgumentException(SR.GetString("DataGridViewCellCollection_CellNotFound"));
			}
			RemoveAt(num);
		}

		/// Removes the cell at the specified index.</summary>
		/// <param name="index">The zero-based index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to be removed.</param>
		/// <exception cref="T:System.InvalidOperationException">The row that owns this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		/// 1</filterpriority>
		public virtual void RemoveAt(int index)
		{
			if (mobjOwner.DataGridView != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewCellCollection_OwningRowAlreadyBelongsToDataGridView"));
			}
			RemoveAtInternal(index);
		}

		internal void RemoveAtInternal(int index)
		{
			DataGridViewCell dataGridViewCell = (DataGridViewCell)mobjItems[index];
			mobjItems.RemoveAt(index);
			dataGridViewCell.DataGridViewInternal = null;
			dataGridViewCell.OwningRowInternal = null;
			if (dataGridViewCell.ReadOnly)
			{
				dataGridViewCell.ReadOnlyInternal = false;
			}
			if (dataGridViewCell.Selected && mobjOwner != null && mobjOwner.DataGridView != null)
			{
				mobjOwner.DataGridView.SetSelectedCellCore(dataGridViewCell, blnValue: false, blnClientSource: false);
			}
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, dataGridViewCell));
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
			return Add((DataGridViewCell)objValue);
		}

		void IList.Clear()
		{
			Clear();
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
			Insert(index, (DataGridViewCell)objValue);
		}

		void IList.Remove(object objValue)
		{
			Remove((DataGridViewCell)objValue);
		}

		void IList.RemoveAt(int index)
		{
			RemoveAt(index);
		}
	}
}
