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
	/// Represents a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> objects in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
	/// 2</filterpriority>
	[Serializable]
	[ListBindable(false)]
	[Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnCollectionController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnCollectionController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class DataGridViewColumnCollection : BaseCollection, IList, ICollection, IEnumerable
	{
		[Serializable]
		private class ColumnOrderComparer : IComparer
		{
			public int Compare(object objX, object objY)
			{
				DataGridViewColumn dataGridViewColumn = objX as DataGridViewColumn;
				DataGridViewColumn dataGridViewColumn2 = objY as DataGridViewColumn;
				return dataGridViewColumn.DisplayIndex - dataGridViewColumn2.DisplayIndex;
			}
		}

		private int mintColumnCountsVisible;

		private int mintColumnCountsVisibleSelected;

		private static ColumnOrderComparer mobjColumnOrderComparer;

		private int mintColumnsWidthVisible;

		private int mintColumnsWidthVisibleFrozen;

		private DataGridView mobjDataGridView;

		private ArrayList marrItems;

		private ArrayList marrItemsSorted;

		private int mintLastAccessedSortedIndex;

		internal static IComparer ColumnCollectionOrderComparer => mobjColumnOrderComparer;

		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> upon which the collection performs column-related operations.</summary>
		/// <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		protected DataGridView DataGridView => mobjDataGridView;

		/// Gets or sets the column of the given name in the collection. </summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> identified by the columnName parameter.</returns>
		/// <param name="strColumnName">The name of the column to get or set.</param>
		/// <exception cref="T:System.ArgumentNullException">columnName is null.</exception>
		/// 1</filterpriority>
		public DataGridViewColumn this[string strColumnName]
		{
			get
			{
				if (strColumnName == null)
				{
					throw new ArgumentNullException("columnName");
				}
				int count = marrItems.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)marrItems[i];
					if (ClientUtils.IsEquals(dataGridViewColumn.Name, strColumnName, StringComparison.OrdinalIgnoreCase))
					{
						return dataGridViewColumn;
					}
				}
				return null;
			}
		}

		/// Gets or sets the column at the given index in the collection. </summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> at the given index.</returns>
		/// <param name="index">The zero-based index of the column to get or set.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or greater than the number of columns in the collection minus one.</exception>
		/// 1</filterpriority>
		public DataGridViewColumn this[int index] => (DataGridViewColumn)marrItems[index];

		/// 
		/// Gets the list of elements contained in the <see cref="T:Gizmox.WebGUI.Forms.BaseCollection"></see> instance.
		/// </summary>
		/// </value>
		/// An <see cref="T:System.Collections.ArrayList"></see> containing the elements of the collection. This property returns null unless overridden in a derived class.</returns>
		protected override ArrayList List => marrItems;

		int ICollection.Count => marrItems.Count;

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
				throw new NotSupportedException();
			}
		}

		/// Occurs when the collection changes.</summary>
		/// 1</filterpriority>
		public event CollectionChangeEventHandler CollectionChanged;

		static DataGridViewColumnCollection()
		{
			mobjColumnOrderComparer = new ColumnOrderComparer();
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnCollection"></see> class for the given <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
		/// <param name="objDataGridView">The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that created this collection.</param>
		public DataGridViewColumnCollection(DataGridView objDataGridView)
		{
			marrItems = new ArrayList();
			mintLastAccessedSortedIndex = -1;
			InvalidateCachedColumnCounts();
			InvalidateCachedColumnsWidths();
			mobjDataGridView = objDataGridView;
		}

		internal int ActualDisplayIndexToColumnIndex(int intActualDisplayIndex, DataGridViewElementStates enmIncludeFilter)
		{
			DataGridViewColumn dataGridViewColumn = GetFirstColumn(enmIncludeFilter);
			for (int i = 0; i < intActualDisplayIndex; i++)
			{
				dataGridViewColumn = GetNextColumn(dataGridViewColumn, enmIncludeFilter, DataGridViewElementStates.None);
			}
			return dataGridViewColumn.Index;
		}

		/// Adds the given column to the collection.</summary>
		/// The index of the column.</returns>
		/// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to add.</param>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewColumn is null.</exception>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-dataGridViewColumn already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-The dataGridViewColumn<see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.SelectionMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullColumnSelect"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.ColumnHeaderSelect"></see>.
		///  Use the control <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.BeginInit"></see> and <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.EndInit"></see> methods to temporarily set conflicting property values. -or-The dataGridViewColumn<see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> property value is false.-or-dataGridViewColumn has an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see> and a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value of true.-or-dataGridViewColumn has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> property value that would cause the combined <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> values of all columns in the control to exceed 65535.-or-dataGridViewColumn has <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property values that would display it among a set of adjacent columns with the opposite <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control contains at least one row and dataGridViewColumn has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.CellType"></see> property value of null.</exception>
		/// 1</filterpriority>
		public virtual int Add(DataGridViewColumn objDataGridViewColumn)
		{
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			if (DataGridView.InDisplayIndexAdjustments)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
			}
			if (objDataGridViewColumn == null)
			{
				throw new ArgumentNullException("objDataGridViewColumn");
			}
			if (objDataGridViewColumn.Frozen && DataGridView.IsHierarchic(HierarchicInfoSelector.Any))
			{
				throw new Exception("DataGridView does not support hierarchies with frozen columns");
			}
			DataGridView.OnAddingColumn(objDataGridViewColumn);
			InvalidateCachedColumnsOrder();
			int result = (objDataGridViewColumn.IndexInternal = marrItems.Add(objDataGridViewColumn));
			objDataGridViewColumn.DataGridViewInternal = mobjDataGridView;
			UpdateColumnCaches(objDataGridViewColumn, blnAdding: true);
			DataGridView.OnAddedColumn(objDataGridViewColumn);
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewColumn), blnChangeIsInsertion: false, new Point(-1, -1));
			return result;
		}

		/// Adds a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn"></see> with the given column name and column header text to the collection.</summary>
		/// The index of the column.</returns>
		/// <param name="strHeaderText">The text for the column's header.</param>
		/// <param name="strColumnName">The name by which the column will be referred.</param>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.SelectionMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullColumnSelect"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.ColumnHeaderSelect"></see>, which conflicts with the default column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic"></see>.-or-The default column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> property value of 100 would cause the combined <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> values of all columns in the control to exceed 65535.</exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual int Add(string strColumnName, string strHeaderText)
		{
			DataGridViewColumn dataGridViewDefaultColumn = DataGridView.GetDataGridViewDefaultColumn();
			dataGridViewDefaultColumn.Name = strColumnName;
			dataGridViewDefaultColumn.HeaderText = strHeaderText;
			return Add(dataGridViewDefaultColumn);
		}

		/// Adds a range of columns to the collection. </summary>
		/// <param name="arrDataGridViewColumns">An array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> objects to add.</param>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewColumns is null.</exception>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-At least one of the values in dataGridViewColumns is null.-or-At least one of the columns in dataGridViewColumns already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-At least one of the columns in dataGridViewColumns has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.CellType"></see> property value of null and the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control contains at least one row.-or-At least one of the columns in dataGridViewColumns has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.SelectionMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullColumnSelect"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.ColumnHeaderSelect"></see>. 
		/// Use the control <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.BeginInit"></see> and <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.EndInit"></see> methods to temporarily set conflicting property values. -or-At least one of the columns in dataGridViewColumns has an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> property value is false.-or-At least one of the columns in dataGridViewColumns has an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see> and a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value of true.-or-The columns in dataGridViewColumns have <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> property values that would cause the combined <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> values of all columns in the control to exceed 65535.-or-At least two of the values in dataGridViewColumns are references to the same <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see>.-or-At least one of the columns in dataGridViewColumns has <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property values that would display it among a set of adjacent columns with the opposite <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value.</exception>
		/// 1</filterpriority>
		public virtual void AddRange(params DataGridViewColumn[] arrDataGridViewColumns)
		{
			if (arrDataGridViewColumns == null)
			{
				throw new ArgumentNullException("dataGridViewColumns");
			}
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			if (DataGridView.InDisplayIndexAdjustments)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
			}
			ArrayList arrayList = new ArrayList(arrDataGridViewColumns.Length);
			ArrayList arrayList2 = new ArrayList(arrDataGridViewColumns.Length);
			foreach (DataGridViewColumn dataGridViewColumn in arrDataGridViewColumns)
			{
				if (dataGridViewColumn.DisplayIndex != -1)
				{
					arrayList.Add(dataGridViewColumn);
				}
			}
			int j;
			while (arrayList.Count > 0)
			{
				int num = int.MaxValue;
				int index = -1;
				for (j = 0; j < arrayList.Count; j++)
				{
					DataGridViewColumn dataGridViewColumn2 = (DataGridViewColumn)arrayList[j];
					if (dataGridViewColumn2.DisplayIndex < num)
					{
						num = dataGridViewColumn2.DisplayIndex;
						index = j;
					}
				}
				arrayList2.Add(arrayList[index]);
				arrayList.RemoveAt(index);
			}
			foreach (DataGridViewColumn dataGridViewColumn3 in arrDataGridViewColumns)
			{
				if (dataGridViewColumn3.DisplayIndex == -1)
				{
					arrayList2.Add(dataGridViewColumn3);
				}
			}
			j = 0;
			foreach (DataGridViewColumn item in arrayList2)
			{
				arrDataGridViewColumns[j] = item;
				j++;
			}
			DataGridView.OnAddingColumns(arrDataGridViewColumns);
			foreach (DataGridViewColumn dataGridViewColumn5 in arrDataGridViewColumns)
			{
				InvalidateCachedColumnsOrder();
				j = marrItems.Add(dataGridViewColumn5);
				dataGridViewColumn5.IndexInternal = j;
				dataGridViewColumn5.DataGridViewInternal = mobjDataGridView;
				UpdateColumnCaches(dataGridViewColumn5, blnAdding: true);
				DataGridView.OnAddedColumn(dataGridViewColumn5);
			}
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), blnChangeIsInsertion: false, new Point(-1, -1));
		}

		/// Clears the collection. </summary>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see></exception>
		/// 1</filterpriority>
		public virtual void Clear()
		{
			if (Count <= 0)
			{
				return;
			}
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			if (DataGridView.InDisplayIndexAdjustments)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
			}
			for (int i = 0; i < Count; i++)
			{
				DataGridViewColumn dataGridViewColumn = this[i];
				dataGridViewColumn.DataGridViewInternal = null;
				if (dataGridViewColumn.HasHeaderCell)
				{
					dataGridViewColumn.HeaderCell.DataGridViewInternal = null;
				}
			}
			DataGridViewColumn[] array = new DataGridViewColumn[marrItems.Count];
			CopyTo(array, 0);
			DataGridView.OnClearingColumns();
			InvalidateCachedColumnsOrder();
			marrItems.Clear();
			InvalidateCachedColumnCounts();
			InvalidateCachedColumnsWidths();
			DataGridViewColumn[] array2 = array;
			foreach (DataGridViewColumn objDataGridViewColumn in array2)
			{
				DataGridView.OnColumnRemoved(objDataGridViewColumn);
				DataGridView.OnColumnHidden(objDataGridViewColumn);
			}
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), blnChangeIsInsertion: false, new Point(-1, -1));
		}

		internal int ColumnIndexToActualDisplayIndex(int intColumnIndex, DataGridViewElementStates enmIncludeFilter)
		{
			DataGridViewColumn dataGridViewColumn = GetFirstColumn(enmIncludeFilter);
			int num = 0;
			while (dataGridViewColumn != null && dataGridViewColumn.Index != intColumnIndex)
			{
				dataGridViewColumn = GetNextColumn(dataGridViewColumn, enmIncludeFilter, DataGridViewElementStates.None);
				num++;
			}
			return num;
		}

		/// 
		/// Creates the real data member from the proposed member.
		/// </summary>
		/// <param name="strFilteringDataMember">The STR filtering data member.</param>
		internal string GetRealDataMemberForProposedMember(string strFilteringDataMember)
		{
			IEnumerator enumerator = GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)enumerator.Current;
					if (dataGridViewColumn.Name == strFilteringDataMember || dataGridViewColumn.DataPropertyName == strFilteringDataMember)
					{
						return dataGridViewColumn.Name;
					}
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			return null;
		}

		/// Determines whether the collection contains the column referred to by the given name. </summary>
		/// true if the column is contained in the collection; otherwise, false.</returns>
		/// <param name="strColumnName">The name of the column to look for.</param>
		/// <exception cref="T:System.ArgumentNullException">columnName is null.</exception>
		/// 1</filterpriority>
		public virtual bool Contains(string strColumnName)
		{
			if (strColumnName == null)
			{
				throw new ArgumentNullException("columnName");
			}
			int count = marrItems.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)marrItems[i];
				if (string.Compare(dataGridViewColumn.Name, strColumnName, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
				{
					return true;
				}
			}
			return false;
		}

		/// Determines whether the collection contains the given column.</summary>
		/// true if the given column is in the collection; otherwise, false.</returns>
		/// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to look for.</param>
		/// 1</filterpriority>
		public virtual bool Contains(DataGridViewColumn objDataGridViewColumn)
		{
			return marrItems.IndexOf(objDataGridViewColumn) != -1;
		}

		/// Copies the items from the collection to the given array.</summary>
		/// <param name="arrColumns">The destination <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> array.</param>
		/// <param name="index">The index of the destination array at which to start copying.</param>
		/// 1</filterpriority>
		public void CopyTo(DataGridViewColumn[] arrColumns, int index)
		{
			marrItems.CopyTo(arrColumns, index);
		}

		internal bool DisplayInOrder(int intColumnIndex1, int intColumnIndex2)
		{
			int displayIndex = ((DataGridViewColumn)marrItems[intColumnIndex1]).DisplayIndex;
			int displayIndex2 = ((DataGridViewColumn)marrItems[intColumnIndex2]).DisplayIndex;
			return displayIndex < displayIndex2;
		}

		internal DataGridViewColumn GetColumnAtDisplayIndex(int intDisplayIndex)
		{
			if (intDisplayIndex >= 0 && intDisplayIndex < marrItems.Count)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)marrItems[intDisplayIndex];
				if (dataGridViewColumn.DisplayIndex == intDisplayIndex)
				{
					return dataGridViewColumn;
				}
				for (int i = 0; i < marrItems.Count; i++)
				{
					dataGridViewColumn = (DataGridViewColumn)marrItems[i];
					if (dataGridViewColumn.DisplayIndex == intDisplayIndex)
					{
						return dataGridViewColumn;
					}
				}
			}
			return null;
		}

		/// Returns the number of columns that meet the given filter requirements.</summary>
		/// The number of columns that meet the filter requirements.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter for inclusion.</param>
		/// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		public int GetColumnCount(DataGridViewElementStates enmIncludeFilter)
		{
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			switch (enmIncludeFilter)
			{
			case DataGridViewElementStates.Selected | DataGridViewElementStates.Visible:
				if (mintColumnCountsVisibleSelected != -1)
				{
					return mintColumnCountsVisibleSelected;
				}
				break;
			case DataGridViewElementStates.Visible:
				if (mintColumnCountsVisible != -1)
				{
					return mintColumnCountsVisible;
				}
				break;
			}
			int num = 0;
			if ((enmIncludeFilter & DataGridViewElementStates.Resizable) == 0)
			{
				for (int i = 0; i < marrItems.Count; i++)
				{
					if (((DataGridViewColumn)marrItems[i]).StateIncludes(enmIncludeFilter))
					{
						num++;
					}
				}
				switch (enmIncludeFilter)
				{
				default:
					return num;
				case DataGridViewElementStates.Visible:
					mintColumnCountsVisible = num;
					return num;
				case DataGridViewElementStates.Selected | DataGridViewElementStates.Visible:
					mintColumnCountsVisibleSelected = num;
					return num;
				}
			}
			DataGridViewElementStates elementState = enmIncludeFilter & ~DataGridViewElementStates.Resizable;
			for (int j = 0; j < marrItems.Count; j++)
			{
				if (((DataGridViewColumn)marrItems[j]).StateIncludes(elementState) && ((DataGridViewColumn)marrItems[j]).Resizable == DataGridViewTriState.True)
				{
					num++;
				}
			}
			return num;
		}

		internal int GetColumnCount(DataGridViewElementStates enmIncludeFilter, int intFromColumnIndex, int toColumnIndex)
		{
			int num = 0;
			DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)marrItems[intFromColumnIndex];
			while (dataGridViewColumn != (DataGridViewColumn)marrItems[toColumnIndex])
			{
				dataGridViewColumn = GetNextColumn(dataGridViewColumn, enmIncludeFilter, DataGridViewElementStates.None);
				if (dataGridViewColumn.StateIncludes(enmIncludeFilter))
				{
					num++;
				}
			}
			return num;
		}

		internal float GetColumnsFillWeight(DataGridViewElementStates enmIncludeFilter)
		{
			float num = 0f;
			for (int i = 0; i < marrItems.Count; i++)
			{
				if (((DataGridViewColumn)marrItems[i]).StateIncludes(enmIncludeFilter))
				{
					num += ((DataGridViewColumn)marrItems[i]).FillWeight;
				}
			}
			return num;
		}

		private int GetColumnSortedIndex(DataGridViewColumn objDataGridViewColumn)
		{
			if (mintLastAccessedSortedIndex != -1 && marrItemsSorted[mintLastAccessedSortedIndex] == objDataGridViewColumn)
			{
				return mintLastAccessedSortedIndex;
			}
			for (int i = 0; i < marrItemsSorted.Count; i++)
			{
				if (objDataGridViewColumn.Index == ((DataGridViewColumn)marrItemsSorted[i]).Index)
				{
					mintLastAccessedSortedIndex = i;
					return i;
				}
			}
			return -1;
		}

		/// Returns the width, in pixels, required to display all of the columns that meet the given filter requirements. </summary>
		/// The width, in pixels, that is necessary to display all of the columns that meet the filter requirements.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter for inclusion.</param>
		/// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		public int GetColumnsWidth(DataGridViewElementStates enmIncludeFilter)
		{
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			switch (enmIncludeFilter)
			{
			case DataGridViewElementStates.Visible:
				if (mintColumnsWidthVisible == -1)
				{
					break;
				}
				return mintColumnsWidthVisible;
			case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
				if (mintColumnsWidthVisibleFrozen == -1)
				{
					break;
				}
				return mintColumnsWidthVisibleFrozen;
			}
			int num = 0;
			for (int i = 0; i < List.Count; i++)
			{
				if (((DataGridViewColumn)List[i]).StateIncludes(enmIncludeFilter))
				{
					num += ((DataGridViewColumn)List[i]).Thickness;
				}
			}
			switch (enmIncludeFilter)
			{
			case DataGridViewElementStates.Visible:
				mintColumnsWidthVisible = num;
				return num;
			case DataGridViewElementStates.Displayed | DataGridViewElementStates.Visible:
				return num;
			case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
				mintColumnsWidthVisibleFrozen = num;
				return num;
			default:
				return num;
			}
		}

		/// Returns the first column in display order that meets the given inclusion-filter requirements.</summary>
		/// The first column in display order that meets the given filter requirements, or null if no column is found.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represents the filter for inclusion.</param>
		/// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		public DataGridViewColumn GetFirstColumn(DataGridViewElementStates enmIncludeFilter)
		{
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			if (marrItemsSorted == null)
			{
				UpdateColumnOrderCache();
			}
			for (int i = 0; i < marrItemsSorted.Count; i++)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)marrItemsSorted[i];
				if (dataGridViewColumn.StateIncludes(enmIncludeFilter))
				{
					mintLastAccessedSortedIndex = i;
					return dataGridViewColumn;
				}
			}
			return null;
		}

		/// Returns the first column in display order that meets the given inclusion-filter and exclusion-filter requirements. </summary>
		/// The first column in display order that meets the given filter requirements, or null if no column is found.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for inclusion.</param>
		/// <param name="enmExcludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for exclusion.</param>
		/// <exception cref="T:System.ArgumentException">At least one of the filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		public DataGridViewColumn GetFirstColumn(DataGridViewElementStates enmIncludeFilter, DataGridViewElementStates enmExcludeFilter)
		{
			if (enmExcludeFilter == DataGridViewElementStates.None)
			{
				return GetFirstColumn(enmIncludeFilter);
			}
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			if ((enmExcludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "excludeFilter"));
			}
			if (marrItemsSorted == null)
			{
				UpdateColumnOrderCache();
			}
			for (int i = 0; i < marrItemsSorted.Count; i++)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)marrItemsSorted[i];
				if (dataGridViewColumn.StateIncludes(enmIncludeFilter) && dataGridViewColumn.StateExcludes(enmExcludeFilter))
				{
					mintLastAccessedSortedIndex = i;
					return dataGridViewColumn;
				}
			}
			return null;
		}

		/// Returns the last column in display order that meets the given filter requirements. </summary>
		/// The last displayed column in display order that meets the given filter requirements, or null if no column is found.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for inclusion.</param>
		/// <param name="enmExcludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for exclusion.</param>
		/// <exception cref="T:System.ArgumentException">At least one of the filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		public DataGridViewColumn GetLastColumn(DataGridViewElementStates enmIncludeFilter, DataGridViewElementStates enmExcludeFilter)
		{
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			if ((enmExcludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "excludeFilter"));
			}
			if (marrItemsSorted == null)
			{
				UpdateColumnOrderCache();
			}
			for (int num = marrItemsSorted.Count - 1; num >= 0; num--)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)marrItemsSorted[num];
				if (dataGridViewColumn.StateIncludes(enmIncludeFilter) && dataGridViewColumn.StateExcludes(enmExcludeFilter))
				{
					mintLastAccessedSortedIndex = num;
					return dataGridViewColumn;
				}
			}
			return null;
		}

		/// Gets the first column after the given column in display order that meets the given filter requirements. </summary>
		/// The next column that meets the given filter requirements, or null if no column is found.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for inclusion.</param>
		/// <param name="objDataGridViewColumnStart">The column from which to start searching for the next column.</param>
		/// <param name="enmExcludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for exclusion.</param>
		/// <exception cref="T:System.ArgumentException">At least one of the filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewColumnStart is null.</exception>
		public DataGridViewColumn GetNextColumn(DataGridViewColumn objDataGridViewColumnStart, DataGridViewElementStates enmIncludeFilter, DataGridViewElementStates enmExcludeFilter)
		{
			if (objDataGridViewColumnStart == null)
			{
				throw new ArgumentNullException("dataGridViewColumnStart");
			}
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			if ((enmExcludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "excludeFilter"));
			}
			if (marrItemsSorted == null)
			{
				UpdateColumnOrderCache();
			}
			int columnSortedIndex = GetColumnSortedIndex(objDataGridViewColumnStart);
			if (columnSortedIndex == -1)
			{
				bool flag = false;
				int num = int.MaxValue;
				int num2 = int.MaxValue;
				for (columnSortedIndex = 0; columnSortedIndex < marrItems.Count; columnSortedIndex++)
				{
					DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)marrItems[columnSortedIndex];
					if (dataGridViewColumn.StateIncludes(enmIncludeFilter) && dataGridViewColumn.StateExcludes(enmExcludeFilter) && (dataGridViewColumn.DisplayIndex > objDataGridViewColumnStart.DisplayIndex || (dataGridViewColumn.DisplayIndex == objDataGridViewColumnStart.DisplayIndex && dataGridViewColumn.Index > objDataGridViewColumnStart.Index)) && (dataGridViewColumn.DisplayIndex < num2 || (dataGridViewColumn.DisplayIndex == num2 && dataGridViewColumn.Index < num)))
					{
						num = columnSortedIndex;
						num2 = dataGridViewColumn.DisplayIndex;
						flag = true;
					}
				}
				if (!flag)
				{
					return null;
				}
				return (DataGridViewColumn)marrItems[num];
			}
			for (columnSortedIndex++; columnSortedIndex < marrItemsSorted.Count; columnSortedIndex++)
			{
				DataGridViewColumn dataGridViewColumn2 = (DataGridViewColumn)marrItemsSorted[columnSortedIndex];
				if (dataGridViewColumn2.StateIncludes(enmIncludeFilter) && dataGridViewColumn2.StateExcludes(enmExcludeFilter))
				{
					mintLastAccessedSortedIndex = columnSortedIndex;
					return dataGridViewColumn2;
				}
			}
			return null;
		}

		/// Gets the last column prior to the given column in display order that meets the given filter requirements. </summary>
		/// The previous column that meets the given filter requirements, or null if no column is found.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for inclusion.</param>
		/// <param name="objDataGridViewColumnStart">The column from which to start searching for the previous column.</param>
		/// <param name="enmExcludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that represent the filter to apply for exclusion.</param>
		/// <exception cref="T:System.ArgumentException">At least one of the filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewColumnStart is null.</exception>
		public DataGridViewColumn GetPreviousColumn(DataGridViewColumn objDataGridViewColumnStart, DataGridViewElementStates enmIncludeFilter, DataGridViewElementStates enmExcludeFilter)
		{
			if (objDataGridViewColumnStart == null)
			{
				throw new ArgumentNullException("dataGridViewColumnStart");
			}
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			if ((enmExcludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "excludeFilter"));
			}
			if (marrItemsSorted == null)
			{
				UpdateColumnOrderCache();
			}
			int columnSortedIndex = GetColumnSortedIndex(objDataGridViewColumnStart);
			if (columnSortedIndex == -1)
			{
				bool flag = false;
				int num = -1;
				int num2 = -1;
				for (columnSortedIndex = 0; columnSortedIndex < marrItems.Count; columnSortedIndex++)
				{
					DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)marrItems[columnSortedIndex];
					if (dataGridViewColumn.StateIncludes(enmIncludeFilter) && dataGridViewColumn.StateExcludes(enmExcludeFilter) && (dataGridViewColumn.DisplayIndex < objDataGridViewColumnStart.DisplayIndex || (dataGridViewColumn.DisplayIndex == objDataGridViewColumnStart.DisplayIndex && dataGridViewColumn.Index < objDataGridViewColumnStart.Index)) && (dataGridViewColumn.DisplayIndex > num2 || (dataGridViewColumn.DisplayIndex == num2 && dataGridViewColumn.Index > num)))
					{
						num = columnSortedIndex;
						num2 = dataGridViewColumn.DisplayIndex;
						flag = true;
					}
				}
				if (!flag)
				{
					return null;
				}
				return (DataGridViewColumn)marrItems[num];
			}
			for (columnSortedIndex--; columnSortedIndex >= 0; columnSortedIndex--)
			{
				DataGridViewColumn dataGridViewColumn2 = (DataGridViewColumn)marrItemsSorted[columnSortedIndex];
				if (dataGridViewColumn2.StateIncludes(enmIncludeFilter) && dataGridViewColumn2.StateExcludes(enmExcludeFilter))
				{
					mintLastAccessedSortedIndex = columnSortedIndex;
					return dataGridViewColumn2;
				}
			}
			return null;
		}

		/// Gets the index of the given <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> in the collection.</summary>
		/// The index of the given <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see>.</returns>
		/// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to return the index of.</param>
		/// 1</filterpriority>
		public int IndexOf(DataGridViewColumn objDataGridViewColumn)
		{
			return marrItems.IndexOf(objDataGridViewColumn);
		}

		/// Inserts a column at the given index in the collection.</summary>
		/// <param name="intColumnIndex">The zero-based index at which to insert the given column.</param>
		/// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to insert.</param>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewColumn is null.</exception>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-dataGridViewColumn already belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or-The dataGridViewColumn<see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.SelectionMode"></see> property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullColumnSelect"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.ColumnHeaderSelect"></see>. Use the control <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.BeginInit"></see> and <see cref="M:Gizmox.WebGUI.Forms.DataGridView.System.ComponentModel.ISupportInitialize.EndInit"></see> methods to temporarily set conflicting property values. -or-The dataGridViewColumn<see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> 
		/// property value is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> property value is false.-or-dataGridViewColumn has an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see> and a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value of true.-or-dataGridViewColumn has <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property values that would display it among a set of adjacent columns with the opposite <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control contains at least one row and dataGridViewColumn has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.CellType"></see> property value of null.</exception>
		/// 1</filterpriority>
		public virtual void Insert(int intColumnIndex, DataGridViewColumn objDataGridViewColumn)
		{
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			if (DataGridView.InDisplayIndexAdjustments)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
			}
			if (objDataGridViewColumn == null)
			{
				throw new ArgumentNullException("dataGridViewColumn");
			}
			if (objDataGridViewColumn.Frozen && DataGridView.IsHierarchic(HierarchicInfoSelector.Any))
			{
				throw new Exception("DataGridView does not support hierarchies with frozen columns");
			}
			int displayIndex = objDataGridViewColumn.DisplayIndex;
			if (displayIndex == -1)
			{
				objDataGridViewColumn.DisplayIndex = intColumnIndex;
			}
			Point objNewCurrentCell;
			try
			{
				DataGridView.OnInsertingColumn(intColumnIndex, objDataGridViewColumn, out objNewCurrentCell);
			}
			finally
			{
				objDataGridViewColumn.DisplayIndexInternal = displayIndex;
			}
			InvalidateCachedColumnsOrder();
			marrItems.Insert(intColumnIndex, objDataGridViewColumn);
			objDataGridViewColumn.IndexInternal = intColumnIndex;
			objDataGridViewColumn.DataGridViewInternal = mobjDataGridView;
			UpdateColumnCaches(objDataGridViewColumn, blnAdding: true);
			DataGridView.OnInsertedColumn_PreNotification(objDataGridViewColumn);
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewColumn), blnChangeIsInsertion: true, objNewCurrentCell);
		}

		internal void InvalidateCachedColumnCount(DataGridViewElementStates enmIncludeFilter)
		{
			switch (enmIncludeFilter)
			{
			case DataGridViewElementStates.Visible:
				InvalidateCachedColumnCounts();
				break;
			case DataGridViewElementStates.Selected:
				mintColumnCountsVisibleSelected = -1;
				break;
			}
		}

		internal void InvalidateCachedColumnCounts()
		{
			mintColumnCountsVisible = (mintColumnCountsVisibleSelected = -1);
		}

		internal void InvalidateCachedColumnsOrder()
		{
			marrItemsSorted = null;
		}

		internal void InvalidateCachedColumnsWidth(DataGridViewElementStates enmIncludeFilter)
		{
			switch (enmIncludeFilter)
			{
			case DataGridViewElementStates.Visible:
				InvalidateCachedColumnsWidths();
				break;
			case DataGridViewElementStates.Frozen:
				mintColumnsWidthVisibleFrozen = -1;
				break;
			}
		}

		internal void InvalidateCachedColumnsWidths()
		{
			mintColumnsWidthVisible = (mintColumnsWidthVisibleFrozen = -1);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridViewColumnCollection.CollectionChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains the event data.</param>
		protected virtual void OnCollectionChanged(CollectionChangeEventArgs e)
		{
			this.CollectionChanged?.Invoke(this, e);
		}

		private void OnCollectionChanged(CollectionChangeEventArgs ccea, bool blnChangeIsInsertion, Point objNewCurrentCell)
		{
			OnCollectionChanged_PreNotification(ccea);
			OnCollectionChanged(ccea);
			OnCollectionChanged_PostNotification(ccea, blnChangeIsInsertion, objNewCurrentCell);
		}

		private void OnCollectionChanged_PostNotification(CollectionChangeEventArgs ccea, bool blnChangeIsInsertion, Point objNewCurrentCell)
		{
			DataGridViewColumn objDataGridViewColumn = (DataGridViewColumn)ccea.Element;
			if (ccea.Action == CollectionChangeAction.Add && blnChangeIsInsertion)
			{
				DataGridView.OnInsertedColumn_PostNotification(objNewCurrentCell);
			}
			else if (ccea.Action == CollectionChangeAction.Remove)
			{
				DataGridView.OnRemovedColumn_PostNotification(objDataGridViewColumn, objNewCurrentCell);
			}
			DataGridView.OnColumnCollectionChanged_PostNotification(objDataGridViewColumn);
		}

		private void OnCollectionChanged_PreNotification(CollectionChangeEventArgs ccea)
		{
			DataGridView.OnColumnCollectionChanged_PreNotification(ccea);
		}

		/// Removes the column with the specified name from the collection.</summary>
		/// <param name="strColumnName">The name of the column to delete.</param>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see></exception>
		/// <exception cref="T:System.ArgumentException">columnName does not match the name of any column in the collection.</exception>
		/// <exception cref="T:System.ArgumentNullException">columnName is null.</exception>
		/// 1</filterpriority>
		public virtual void Remove(string strColumnName)
		{
			if (strColumnName == null)
			{
				throw new ArgumentNullException("columnName");
			}
			int count = marrItems.Count;
			for (int i = 0; i < count; i++)
			{
				DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)marrItems[i];
				if (string.Compare(dataGridViewColumn.Name, strColumnName, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
				{
					RemoveAt(i);
					return;
				}
			}
			throw new ArgumentException(SR.GetString("DataGridViewColumnCollection_ColumnNotFound", strColumnName), "columnName");
		}

		/// Removes the specified column from the collection.</summary>
		/// <param name="objDataGridViewColumn">The column to delete.</param>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see></exception>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewColumn is null.</exception>
		/// <exception cref="T:System.ArgumentException">dataGridViewColumn is not in the collection.</exception>
		/// 1</filterpriority>
		public virtual void Remove(DataGridViewColumn objDataGridViewColumn)
		{
			if (objDataGridViewColumn == null)
			{
				throw new ArgumentNullException("dataGridViewColumn");
			}
			if (objDataGridViewColumn.DataGridView != DataGridView)
			{
				throw new ArgumentException(SR.GetString("DataGridView_ColumnDoesNotBelongToDataGridView"), "dataGridViewColumn");
			}
			int count = marrItems.Count;
			for (int i = 0; i < count; i++)
			{
				if (marrItems[i] == objDataGridViewColumn)
				{
					RemoveAt(i);
					break;
				}
			}
		}

		/// Removes the column at the given index in the collection.</summary>
		/// <param name="index">The index of the column to delete.</param>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new columns from being added:Selecting all cells in the control.Clearing the selection.Updating column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property values. -or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see></exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero or greater than the number of columns in the control minus one. </exception>
		/// 1</filterpriority>
		public virtual void RemoveAt(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", "index", index.ToString(CultureInfo.CurrentCulture)));
			}
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			if (DataGridView.InDisplayIndexAdjustments)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
			}
			RemoveAtInternal(index, blnForce: false);
		}

		internal void RemoveAtInternal(int index, bool blnForce)
		{
			DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)marrItems[index];
			DataGridView.OnRemovingColumn(dataGridViewColumn, out var objNewCurrentCell, blnForce);
			InvalidateCachedColumnsOrder();
			marrItems.RemoveAt(index);
			dataGridViewColumn.DataGridViewInternal = null;
			UpdateColumnCaches(dataGridViewColumn, blnAdding: false);
			DataGridView.OnRemovedColumn_PreNotification(dataGridViewColumn);
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, dataGridViewColumn), blnChangeIsInsertion: false, objNewCurrentCell);
		}

		void ICollection.CopyTo(Array objArray, int index)
		{
			marrItems.CopyTo(objArray, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return marrItems.GetEnumerator();
		}

		int IList.Add(object objValue)
		{
			return Add((DataGridViewColumn)objValue);
		}

		void IList.Clear()
		{
			Clear();
		}

		bool IList.Contains(object objValue)
		{
			return marrItems.Contains(objValue);
		}

		int IList.IndexOf(object objValue)
		{
			return marrItems.IndexOf(objValue);
		}

		void IList.Insert(int index, object objValue)
		{
			Insert(index, (DataGridViewColumn)objValue);
		}

		void IList.Remove(object objValue)
		{
			Remove((DataGridViewColumn)objValue);
		}

		void IList.RemoveAt(int index)
		{
			RemoveAt(index);
		}

		private void UpdateColumnCaches(DataGridViewColumn objDataGridViewColumn, bool blnAdding)
		{
			if (mintColumnCountsVisible == -1 && mintColumnCountsVisibleSelected == -1 && mintColumnsWidthVisible == -1 && mintColumnsWidthVisibleFrozen == -1)
			{
				return;
			}
			DataGridViewElementStates state = objDataGridViewColumn.State;
			if ((state & DataGridViewElementStates.Visible) != DataGridViewElementStates.None)
			{
				int num = (blnAdding ? 1 : (-1));
				int num2 = 0;
				if (mintColumnsWidthVisible != -1 || (mintColumnsWidthVisibleFrozen != -1 && (state & (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible)) == (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible)))
				{
					num2 = (blnAdding ? objDataGridViewColumn.Width : (-objDataGridViewColumn.Width));
				}
				if (mintColumnCountsVisible != -1)
				{
					mintColumnCountsVisible += num;
				}
				if (mintColumnsWidthVisible != -1)
				{
					mintColumnsWidthVisible += num2;
				}
				if ((state & (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible)) == (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible) && mintColumnsWidthVisibleFrozen != -1)
				{
					mintColumnsWidthVisibleFrozen += num2;
				}
				if ((state & (DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) == (DataGridViewElementStates.Selected | DataGridViewElementStates.Visible) && mintColumnCountsVisibleSelected != -1)
				{
					mintColumnCountsVisibleSelected += num;
				}
			}
		}

		private void UpdateColumnOrderCache()
		{
			marrItemsSorted = (ArrayList)marrItems.Clone();
			marrItemsSorted.Sort(mobjColumnOrderComparer);
			mintLastAccessedSortedIndex = -1;
		}
	}
}
