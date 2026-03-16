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
/// A collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects.</summary>
	/// 2</filterpriority>
	[Serializable]
	[ListBindable(false)]
	[DesignerSerializer("Gizmox.WebGUI.Forms.Design.DataGridViewRowCollectionCodeDomSerializer, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public class DataGridViewRowCollection : IList, ICollection, IEnumerable
	{
		[Serializable]
		private class RowArrayList : ArrayList
		{
			private DataGridViewRowCollection mobjOwner;

			private RowComparer mobjRowComparer;

			public RowArrayList(DataGridViewRowCollection objOwner)
			{
				mobjOwner = objOwner;
			}

			private void CustomQuickSort(int intLeft, int intRight)
			{
				if (intRight - intLeft < 2)
				{
					if (intRight - intLeft > 0 && mobjRowComparer.CompareObjects(mobjRowComparer.GetComparedObject(intLeft), mobjRowComparer.GetComparedObject(intRight), intLeft, intRight) > 0)
					{
						mobjOwner.SwapSortedRows(intLeft, intRight);
					}
					return;
				}
				do
				{
					int num = intLeft + intRight >> 1;
					object obj = Pivot(intLeft, num, intRight);
					int num2 = intLeft + 1;
					int num3 = intRight - 1;
					while (true)
					{
						if (num != num2 && mobjRowComparer.CompareObjects(mobjRowComparer.GetComparedObject(num2), obj, num2, num) < 0)
						{
							num2++;
							continue;
						}
						while (num != num3 && mobjRowComparer.CompareObjects(obj, mobjRowComparer.GetComparedObject(num3), num, num3) < 0)
						{
							num3--;
						}
						if (num2 > num3)
						{
							break;
						}
						if (num2 < num3)
						{
							mobjOwner.SwapSortedRows(num2, num3);
							if (num2 == num)
							{
								num = num3;
							}
							else if (num3 == num)
							{
								num = num2;
							}
						}
						num2++;
						num3--;
						if (num2 > num3)
						{
							break;
						}
					}
					if (num3 - intLeft <= intRight - num2)
					{
						if (intLeft < num3)
						{
							CustomQuickSort(intLeft, num3);
						}
						intLeft = num2;
					}
					else
					{
						if (num2 < intRight)
						{
							CustomQuickSort(num2, intRight);
						}
						intRight = num3;
					}
				}
				while (intLeft < intRight);
			}

			public void CustomSort(RowComparer objRowComparer)
			{
				mobjRowComparer = objRowComparer;
				CustomQuickSort(0, Count - 1);
			}

			private object Pivot(int intLeft, int intCenter, int intRight)
			{
				if (mobjRowComparer.CompareObjects(mobjRowComparer.GetComparedObject(intLeft), mobjRowComparer.GetComparedObject(intCenter), intLeft, intCenter) > 0)
				{
					mobjOwner.SwapSortedRows(intLeft, intCenter);
				}
				if (mobjRowComparer.CompareObjects(mobjRowComparer.GetComparedObject(intLeft), mobjRowComparer.GetComparedObject(intRight), intLeft, intRight) > 0)
				{
					mobjOwner.SwapSortedRows(intLeft, intRight);
				}
				if (mobjRowComparer.CompareObjects(mobjRowComparer.GetComparedObject(intCenter), mobjRowComparer.GetComparedObject(intRight), intCenter, intRight) > 0)
				{
					mobjOwner.SwapSortedRows(intCenter, intRight);
				}
				return mobjRowComparer.GetComparedObject(intCenter);
			}
		}

		[Serializable]
		private class RowComparer
		{
			[Serializable]
			private class ComparedObjectMax
			{
			}

			private bool mblnAscending;

			private IComparer mobjCustomComparer;

			private DataGridView mobjDataGridView;

			private DataGridViewRowCollection mobjDataGridViewRows;

			private DataGridViewColumn mobjDataGridViewSortedColumn;

			private static ComparedObjectMax mobjMax;

			private int mintSortedColumnIndex;

			static RowComparer()
			{
				mobjMax = new ComparedObjectMax();
			}

			public RowComparer(DataGridViewRowCollection objDataGridViewRows, IComparer objCustomComparer, bool blnAscending)
			{
				mobjDataGridView = objDataGridViewRows.DataGridView;
				mobjDataGridViewRows = objDataGridViewRows;
				mobjDataGridViewSortedColumn = mobjDataGridView.SortedColumn;
				if (mobjDataGridViewSortedColumn == null)
				{
					mintSortedColumnIndex = -1;
				}
				else
				{
					mintSortedColumnIndex = mobjDataGridViewSortedColumn.Index;
				}
				mobjCustomComparer = objCustomComparer;
				mblnAscending = blnAscending;
			}

			internal int CompareObjects(object objValue1, object objValue2, int intRowIndex1, int intRowIndex2)
			{
				if (objValue1 is ComparedObjectMax)
				{
					return 1;
				}
				if (objValue2 is ComparedObjectMax)
				{
					return -1;
				}
				int intSortResult = 0;
				if (mobjCustomComparer == null)
				{
					if (!mobjDataGridView.OnSortCompare(mobjDataGridViewSortedColumn, objValue1, objValue2, intRowIndex1, intRowIndex2, out intSortResult))
					{
						intSortResult = ((objValue1 is IComparable || objValue2 is IComparable) ? Comparer.Default.Compare(objValue1, objValue2) : ((objValue1 == null) ? ((objValue2 != null) ? 1 : 0) : ((objValue2 != null) ? Comparer.Default.Compare(objValue1.ToString(), objValue2.ToString()) : (-1))));
						if (intSortResult == 0)
						{
							intSortResult = ((!mblnAscending) ? (intRowIndex2 - intRowIndex1) : (intRowIndex1 - intRowIndex2));
						}
					}
				}
				else
				{
					intSortResult = mobjCustomComparer.Compare(objValue1, objValue2);
				}
				if (mblnAscending)
				{
					return intSortResult;
				}
				return -intSortResult;
			}

			internal object GetComparedObject(int intRowIndex)
			{
				if (mobjDataGridView.NewRowIndex != -1 && intRowIndex == mobjDataGridView.NewRowIndex)
				{
					return mobjMax;
				}
				if (mobjCustomComparer == null)
				{
					DataGridViewRow dataGridViewRow = mobjDataGridViewRows.SharedRow(intRowIndex);
					return dataGridViewRow.Cells[mintSortedColumnIndex].GetValueInternal(intRowIndex);
				}
				return mobjDataGridViewRows[intRowIndex];
			}
		}

		[Serializable]
		private class UnsharingRowEnumerator : IEnumerator
		{
			private int mintCurrent;

			private DataGridViewRowCollection mobjOwner;

			object IEnumerator.Current
			{
				get
				{
					if (mintCurrent == -1)
					{
						throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_EnumNotStarted"));
					}
					if (mintCurrent == mobjOwner.Count)
					{
						throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_EnumFinished"));
					}
					return mobjOwner[mintCurrent];
				}
			}

			public UnsharingRowEnumerator(DataGridViewRowCollection objOwner)
			{
				mobjOwner = objOwner;
				mintCurrent = -1;
			}

			bool IEnumerator.MoveNext()
			{
				if (mintCurrent < mobjOwner.Count - 1)
				{
					mintCurrent++;
					return true;
				}
				mintCurrent = mobjOwner.Count;
				return false;
			}

			void IEnumerator.Reset()
			{
				mintCurrent = -1;
			}
		}

		private DataGridView mobjDataGridView;

		private RowArrayList mobjItems;

		private int mintRowCountsVisible;

		private int mintRowCountsVisibleFrozen;

		private int mintRowCountsVisibleSelected;

		private int mintRowsHeightVisible;

		private int mintRowsHeightVisibleFrozen;

		private List<DataGridViewElementStates> mobjRowStates;

		/// Gets the number of rows in the collection.</summary>
		/// The number of rows in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</returns>
		/// 1</filterpriority>
		public int Count => mobjItems.Count;

		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that owns the collection.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that owns the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</returns>
		protected DataGridView DataGridView => mobjDataGridView;

		internal bool IsCollectionChangedListenedTo => this.CollectionChanged != null;

		/// Gets the <see cref="T:System.Windows.Forms.DataGridViewRow"></see> at the specified index.</summary>
		/// The <see cref="T:System.Windows.Forms.DataGridViewRow"></see> at the specified index. Accessing a <see cref="T:System.Windows.Forms.DataGridViewRow"></see> with this indexer causes the row to become unshared. To keep the row shared, use the <see cref="M:System.Windows.Forms.DataGridViewRowCollection.SharedRow(System.Int32)"></see> method. For more information, see Best Practices for Scaling the Windows Forms DataGridView Control.</returns>
		/// <param name="index">The zero-based index of the <see cref="T:System.Windows.Forms.DataGridViewRow"></see> to get.</param>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public DataGridViewRow this[int index]
		{
			get
			{
				DataGridViewRow dataGridViewRow = SharedRow(index);
				if (dataGridViewRow.Index != -1)
				{
					return dataGridViewRow;
				}
				if (index == 0 && mobjItems.Count == 1)
				{
					dataGridViewRow.IndexInternal = 0;
					dataGridViewRow.StateInternal = SharedRowState(0);
					if (DataGridView != null)
					{
						DataGridView.OnRowUnshared(dataGridViewRow);
					}
					return dataGridViewRow;
				}
				DataGridViewRow dataGridViewRow2 = (DataGridViewRow)dataGridViewRow.Clone();
				dataGridViewRow2.IndexInternal = index;
				dataGridViewRow2.DataGridViewInternal = dataGridViewRow.DataGridView;
				dataGridViewRow2.StateInternal = SharedRowState(index);
				SharedList[index] = dataGridViewRow2;
				int num = 0;
				foreach (DataGridViewCell cell in dataGridViewRow2.Cells)
				{
					cell.DataGridViewInternal = dataGridViewRow.DataGridView;
					cell.OwningRowInternal = dataGridViewRow2;
					cell.OwningColumnInternal = DataGridView.Columns[num];
					num++;
				}
				if (dataGridViewRow2.HasHeaderCell)
				{
					dataGridViewRow2.HeaderCell.DataGridViewInternal = dataGridViewRow.DataGridView;
					dataGridViewRow2.HeaderCell.OwningRowInternal = dataGridViewRow2;
				}
				if (DataGridView != null)
				{
					DataGridView.OnRowUnshared(dataGridViewRow2);
				}
				return dataGridViewRow2;
			}
		}

		/// Gets an array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects.</summary>
		/// An array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects.</returns>
		protected ArrayList List
		{
			get
			{
				int count = Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = this[i];
				}
				return mobjItems;
			}
		}

		internal ArrayList SharedList => mobjItems;

		int ICollection.Count => Count;

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

		/// Occurs when the contents of the collection change.</summary>
		/// 1</filterpriority>
		public event CollectionChangeEventHandler CollectionChanged;

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> class. </summary>
		/// <param name="objDataGridView">The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that owns the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
		public DataGridViewRowCollection(DataGridView objDataGridView)
		{
			InvalidateCachedRowCounts();
			InvalidateCachedRowsHeights();
			mobjDataGridView = objDataGridView;
			mobjRowStates = new List<DataGridViewElementStates>();
			mobjItems = new RowArrayList(this);
		}

		/// Adds a new row to the collection.</summary>
		/// The index of the new row.</returns>
		/// <exception cref="T:System.ArgumentException">The row returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowTemplate"></see> property has more cells than there are columns in the control.</exception>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-This operation would add a frozen row after unfrozen rows.</exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual int Add()
		{
			if (DataGridView.DataSource != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
			}
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			return AddInternal(blnNewRow: false, null);
		}

		/// Adds the specified number of new rows to the collection.</summary>
		/// The index of the last row that was added.</returns>
		/// <param name="intCount">The number of rows to add to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">count is less than 1.</exception>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-The row returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowTemplate"></see> property has more cells than there are columns in the control. -or-This operation would add frozen rows after unfrozen rows.</exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual int Add(int intCount)
		{
			if (intCount <= 0)
			{
				throw new ArgumentOutOfRangeException("count", SR.GetString("DataGridViewRowCollection_CountOutOfRange"));
			}
			if (DataGridView.Columns.Count == 0)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
			}
			if (DataGridView.DataSource != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
			}
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			if (DataGridView.RowTemplate.Cells.Count > DataGridView.Columns.Count)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_RowTemplateTooManyCells"));
			}
			DataGridViewRow rowTemplateClone = DataGridView.RowTemplateClone;
			DataGridViewElementStates state = rowTemplateClone.State;
			rowTemplateClone.DataGridViewInternal = mobjDataGridView;
			int num = 0;
			foreach (DataGridViewCell cell in rowTemplateClone.Cells)
			{
				cell.DataGridViewInternal = mobjDataGridView;
				cell.OwningColumnInternal = DataGridView.Columns[num];
				num++;
			}
			if (rowTemplateClone.HasHeaderCell)
			{
				rowTemplateClone.HeaderCell.DataGridViewInternal = mobjDataGridView;
				rowTemplateClone.HeaderCell.OwningRowInternal = rowTemplateClone;
			}
			if (DataGridView.NewRowIndex != -1)
			{
				int num2 = Count - 1;
				InsertCopiesPrivate(rowTemplateClone, state, num2, intCount);
				return num2 + intCount - 1;
			}
			return AddCopiesPrivate(rowTemplateClone, state, intCount);
		}

		/// Adds a new row to the collection, and populates the cells with the specified objects.</summary>
		/// The index of the new row.</returns>
		/// <param name="arrValues">A variable number of objects that populate the cells of the new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is set to true.- or -The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns. -or-The row returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowTemplate"></see> property has more cells than there are columns in the control.-or-This operation would add a frozen row after unfrozen rows.</exception>
		/// <exception cref="T:System.ArgumentNullException">values is null.</exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual int Add(params object[] arrValues)
		{
			if (arrValues == null)
			{
				throw new ArgumentNullException("values");
			}
			if (DataGridView.VirtualMode)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationInVirtualMode"));
			}
			if (DataGridView.DataSource != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
			}
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			return AddInternal(blnNewRow: false, arrValues);
		}

		/// Adds the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to the collection.</summary>
		/// The index of the new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</returns>
		/// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to add to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
		/// <exception cref="T:System.ArgumentException">dataGridViewRow has more cells than there are columns in the control.</exception>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the dataGridViewRow is not null.-or-dataGridViewRow has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.Selected"></see> property value of true. -or-This operation would add a frozen row after unfrozen rows.</exception>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewRow is null.</exception>
		/// 1</filterpriority>
		public virtual int Add(DataGridViewRow objDataGridViewRow)
		{
			if (DataGridView.Columns.Count == 0)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
			}
			if (DataGridView.DataSource != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
			}
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			return AddInternal(objDataGridViewRow);
		}

		/// Adds the specified number of rows to the collection based on the row at the specified index.</summary>
		/// The index of the last row that was added.</returns>
		/// <param name="intCount">The number of rows to add to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
		/// <param name="indexSource">The index of the row on which to base the new rows.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">indexSource is less than zero or greater than or equal to the number of rows in the control.-or-count is less than zero.</exception>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-This operation would add a frozen row after unfrozen rows.</exception>
		/// 1</filterpriority>
		public virtual int AddCopies(int indexSource, int intCount)
		{
			if (DataGridView.DataSource != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
			}
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			return AddCopiesInternal(indexSource, intCount);
		}

		internal int AddCopiesInternal(int indexSource, int intCount)
		{
			if (DataGridView.NewRowIndex != -1)
			{
				int num = Count - 1;
				InsertCopiesPrivate(indexSource, num, intCount);
				return num + intCount - 1;
			}
			return AddCopiesInternal(indexSource, intCount, DataGridViewElementStates.None, DataGridViewElementStates.Displayed | DataGridViewElementStates.Selected);
		}

		internal int AddCopiesInternal(int indexSource, int intCount, DataGridViewElementStates enmDgvesAdd, DataGridViewElementStates enmDgvesRemove)
		{
			if (indexSource < 0 || Count <= indexSource)
			{
				throw new ArgumentOutOfRangeException("indexSource", SR.GetString("DataGridViewRowCollection_IndexSourceOutOfRange"));
			}
			if (intCount <= 0)
			{
				throw new ArgumentOutOfRangeException("count", SR.GetString("DataGridViewRowCollection_CountOutOfRange"));
			}
			DataGridViewElementStates dataGridViewElementStates = mobjRowStates[indexSource] & ~enmDgvesRemove;
			dataGridViewElementStates |= enmDgvesAdd;
			return AddCopiesPrivate(SharedRow(indexSource), dataGridViewElementStates, intCount);
		}

		private int AddCopiesPrivate(DataGridViewRow objRowTemplate, DataGridViewElementStates enmRowTemplateState, int intCount)
		{
			int count = mobjItems.Count;
			int num;
			if (objRowTemplate.Index == -1)
			{
				DataGridView.OnAddingRow(objRowTemplate, enmRowTemplateState, blnCheckFrozenState: true);
				for (int i = 0; i < intCount - 1; i++)
				{
					SharedList.Add(objRowTemplate);
					mobjRowStates.Add(enmRowTemplateState);
				}
				num = SharedList.Add(objRowTemplate);
				mobjRowStates.Add(enmRowTemplateState);
				DataGridView.OnAddedRow_PreNotification(num);
				OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), count, intCount);
				for (int j = 0; j < intCount; j++)
				{
					DataGridView.OnAddedRow_PostNotification(num - (intCount - 1) + j);
				}
				return num;
			}
			num = AddDuplicateRow(objRowTemplate, blnNewRow: false);
			if (intCount > 1)
			{
				DataGridView.OnAddedRow_PreNotification(num);
				if (RowIsSharable(num))
				{
					DataGridViewRow dataGridViewRow = SharedRow(num);
					DataGridView.OnAddingRow(dataGridViewRow, enmRowTemplateState, blnCheckFrozenState: true);
					for (int k = 1; k < intCount - 1; k++)
					{
						SharedList.Add(dataGridViewRow);
						mobjRowStates.Add(enmRowTemplateState);
					}
					num = SharedList.Add(dataGridViewRow);
					mobjRowStates.Add(enmRowTemplateState);
					DataGridView.OnAddedRow_PreNotification(num);
				}
				else
				{
					UnshareRow(num);
					for (int l = 1; l < intCount; l++)
					{
						num = AddDuplicateRow(objRowTemplate, blnNewRow: false);
						UnshareRow(num);
						DataGridView.OnAddedRow_PreNotification(num);
					}
				}
				OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), count, intCount);
				for (int m = 0; m < intCount; m++)
				{
					DataGridView.OnAddedRow_PostNotification(num - (intCount - 1) + m);
				}
				return num;
			}
			if (IsCollectionChangedListenedTo)
			{
				UnshareRow(num);
			}
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, SharedRow(num)), num, 1);
			return num;
		}

		/// Adds a new row based on the row at the specified index.</summary>
		/// The index of the new row.</returns>
		/// <param name="indexSource">The index of the row on which to base the new row.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">indexSource is less than zero or greater than or equal to the number of rows in the collection.</exception>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-This operation would add a frozen row after unfrozen rows.</exception>
		/// 1</filterpriority>
		public virtual int AddCopy(int indexSource)
		{
			if (DataGridView.DataSource != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
			}
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			return AddCopyInternal(indexSource, DataGridViewElementStates.None, DataGridViewElementStates.Displayed | DataGridViewElementStates.Selected, blnNewRow: false);
		}

		internal int AddCopyInternal(int indexSource, DataGridViewElementStates enmDgvesAdd, DataGridViewElementStates enmDgvesRemove, bool blnNewRow)
		{
			if (DataGridView.NewRowIndex != -1)
			{
				int num = Count - 1;
				InsertCopy(indexSource, num);
				return num;
			}
			if (indexSource < 0 || indexSource >= Count)
			{
				throw new ArgumentOutOfRangeException("indexSource", SR.GetString("DataGridViewRowCollection_IndexSourceOutOfRange"));
			}
			DataGridViewRow dataGridViewRow = SharedRow(indexSource);
			int num2;
			if (dataGridViewRow.Index == -1 && !IsCollectionChangedListenedTo && !blnNewRow)
			{
				DataGridViewElementStates dataGridViewElementStates = mobjRowStates[indexSource] & ~enmDgvesRemove;
				dataGridViewElementStates |= enmDgvesAdd;
				DataGridView.OnAddingRow(dataGridViewRow, dataGridViewElementStates, blnCheckFrozenState: true);
				num2 = SharedList.Add(dataGridViewRow);
				mobjRowStates.Add(dataGridViewElementStates);
				OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, dataGridViewRow), num2, 1);
				return num2;
			}
			num2 = AddDuplicateRow(dataGridViewRow, blnNewRow);
			if (!RowIsSharable(num2) || RowHasValueOrToolTipText(SharedRow(num2)) || IsCollectionChangedListenedTo)
			{
				UnshareRow(num2);
			}
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, SharedRow(num2)), num2, 1);
			return num2;
		}

		private int AddDuplicateRow(DataGridViewRow objRowTemplate, bool blnNewRow)
		{
			DataGridViewRow dataGridViewRow = (DataGridViewRow)objRowTemplate.Clone();
			dataGridViewRow.StateInternal = DataGridViewElementStates.None;
			dataGridViewRow.DataGridViewInternal = mobjDataGridView;
			DataGridViewCellCollection cells = dataGridViewRow.Cells;
			int num = 0;
			foreach (DataGridViewCell item in cells)
			{
				if (blnNewRow)
				{
					item.Value = item.DefaultNewRowValue;
				}
				item.DataGridViewInternal = mobjDataGridView;
				item.OwningColumnInternal = DataGridView.Columns[num];
				num++;
			}
			DataGridViewElementStates dataGridViewElementStates = objRowTemplate.State & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Selected);
			if (dataGridViewRow.HasHeaderCell)
			{
				dataGridViewRow.HeaderCell.DataGridViewInternal = mobjDataGridView;
				dataGridViewRow.HeaderCell.OwningRowInternal = dataGridViewRow;
			}
			DataGridView.OnAddingRow(dataGridViewRow, dataGridViewElementStates, blnCheckFrozenState: true);
			mobjRowStates.Add(dataGridViewElementStates);
			return SharedList.Add(dataGridViewRow);
		}

		internal int AddInternal(DataGridViewRow objDataGridViewRow)
		{
			if (objDataGridViewRow == null)
			{
				throw new ArgumentNullException("dataGridViewRow");
			}
			if (objDataGridViewRow.DataGridView != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_RowAlreadyBelongsToDataGridView"));
			}
			if (DataGridView.Columns.Count == 0)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
			}
			if (objDataGridViewRow.Cells.Count > DataGridView.Columns.Count)
			{
				throw new ArgumentException(SR.GetString("DataGridViewRowCollection_TooManyCells"), "dataGridViewRow");
			}
			if (objDataGridViewRow.Selected)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CannotAddOrInsertSelectedRow"));
			}
			if (DataGridView.NewRowIndex != -1)
			{
				int num = Count - 1;
				InsertInternal(num, objDataGridViewRow);
				return num;
			}
			DataGridView.CompleteCellsCollection(objDataGridViewRow);
			DataGridView.OnAddingRow(objDataGridViewRow, objDataGridViewRow.State, blnCheckFrozenState: true);
			int num2 = 0;
			foreach (DataGridViewCell cell in objDataGridViewRow.Cells)
			{
				cell.DataGridViewInternal = mobjDataGridView;
				if (cell.ColumnIndex == -1)
				{
					cell.OwningColumnInternal = DataGridView.Columns[num2];
				}
				num2++;
			}
			if (objDataGridViewRow.HasHeaderCell)
			{
				objDataGridViewRow.HeaderCell.DataGridViewInternal = DataGridView;
				objDataGridViewRow.HeaderCell.OwningRowInternal = objDataGridViewRow;
			}
			int num3 = SharedList.Add(objDataGridViewRow);
			mobjRowStates.Add(objDataGridViewRow.State);
			objDataGridViewRow.DataGridViewInternal = mobjDataGridView;
			if (!RowIsSharable(num3) || RowHasValueOrToolTipText(objDataGridViewRow) || IsCollectionChangedListenedTo)
			{
				objDataGridViewRow.IndexInternal = num3;
			}
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewRow), num3, 1);
			return num3;
		}

		internal int AddInternal(bool blnNewRow, object[] arrValues)
		{
			if (DataGridView.Columns.Count == 0)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
			}
			if (DataGridView.RowTemplate.Cells.Count > DataGridView.Columns.Count)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_RowTemplateTooManyCells"));
			}
			DataGridViewRow rowTemplateClone = DataGridView.RowTemplateClone;
			if (blnNewRow)
			{
				rowTemplateClone.StateInternal = rowTemplateClone.State | DataGridViewElementStates.Visible;
				foreach (DataGridViewCell cell in rowTemplateClone.Cells)
				{
					cell.Value = cell.DefaultNewRowValue;
				}
			}
			if (arrValues != null)
			{
				rowTemplateClone.SetValuesInternal(arrValues);
			}
			if (DataGridView.NewRowIndex != -1)
			{
				int num = Count - 1;
				Insert(num, rowTemplateClone);
				return num;
			}
			DataGridViewElementStates state = rowTemplateClone.State;
			DataGridView.OnAddingRow(rowTemplateClone, state, blnCheckFrozenState: true);
			rowTemplateClone.DataGridViewInternal = mobjDataGridView;
			int num2 = 0;
			foreach (DataGridViewCell cell2 in rowTemplateClone.Cells)
			{
				cell2.DataGridViewInternal = mobjDataGridView;
				cell2.OwningColumnInternal = DataGridView.Columns[num2];
				num2++;
			}
			int num3 = SharedList.Add(rowTemplateClone);
			mobjRowStates.Add(state);
			if (arrValues != null || !RowIsSharable(num3) || RowHasValueOrToolTipText(rowTemplateClone) || IsCollectionChangedListenedTo)
			{
				rowTemplateClone.IndexInternal = num3;
			}
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, rowTemplateClone), num3, 1);
			return num3;
		}

		/// Adds the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects to the collection.</summary>
		/// <param name="arrDataGridViewRows">An array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects to be added to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-At least one entry in the dataGridViewRows array is null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-At least one row in the dataGridViewRows array has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property value that is not null.-or-At least one row in the dataGridViewRows array has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.Selected"></see> property value of true.-or-Two or more rows in the dataGridViewRows array are identical.-or-At least one row in the dataGridViewRows array contains one or more cells of a type that is incompatible with the type of the corresponding column in the control.-or-At least one row in the dataGridViewRows array contains more cells than there are columns in the control.-or-This operation would add frozen rows after unfrozen rows.</exception>
		/// <exception cref="T:System.ArgumentException">dataGridViewRows contains only one row, and the row it contains has more cells than there are columns in the control.</exception>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewRows is null.</exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual void AddRange(params DataGridViewRow[] arrDataGridViewRows)
		{
			if (arrDataGridViewRows == null)
			{
				throw new ArgumentNullException("dataGridViewRows");
			}
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			if (DataGridView.DataSource != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
			}
			if (DataGridView.NewRowIndex != -1)
			{
				InsertRange(Count - 1, arrDataGridViewRows);
				return;
			}
			if (DataGridView.Columns.Count == 0)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
			}
			int count = mobjItems.Count;
			DataGridView.OnAddingRows(arrDataGridViewRows, blnCheckFrozenStates: true);
			foreach (DataGridViewRow dataGridViewRow in arrDataGridViewRows)
			{
				int num = 0;
				foreach (DataGridViewCell cell in dataGridViewRow.Cells)
				{
					cell.DataGridViewInternal = mobjDataGridView;
					cell.OwningColumnInternal = DataGridView.Columns[num];
					num++;
				}
				if (dataGridViewRow.HasHeaderCell)
				{
					dataGridViewRow.HeaderCell.DataGridViewInternal = mobjDataGridView;
					dataGridViewRow.HeaderCell.OwningRowInternal = dataGridViewRow;
				}
				int indexInternal = SharedList.Add(dataGridViewRow);
				mobjRowStates.Add(dataGridViewRow.State);
				dataGridViewRow.IndexInternal = indexInternal;
				dataGridViewRow.DataGridViewInternal = mobjDataGridView;
			}
			DataGridView.OnAddedRows_PreNotification(arrDataGridViewRows);
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), count, arrDataGridViewRows.Length);
			DataGridView.OnAddedRows_PostNotification(arrDataGridViewRows);
		}

		/// Clears the collection. </summary>
		/// <exception cref="T:System.InvalidOperationException">The collection is data bound and the underlying data source does not support clearing the row data.-or-The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see></exception>
		/// 1</filterpriority>
		public virtual void Clear()
		{
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			if (DataGridView.DataSource != null)
			{
				if (!(DataGridView.DataConnection.List is IBindingList { AllowRemove: not false, SupportsChangeNotification: not false } bindingList))
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CantClearRowCollectionWithWrongSource"));
				}
				bindingList.Clear();
			}
			else
			{
				ClearInternal(blnRecreateNewRow: true);
			}
		}

		internal void ClearInternal(bool blnRecreateNewRow)
		{
			int count = mobjItems.Count;
			if (count > 0)
			{
				DataGridView.OnClearingRows();
				for (int i = 0; i < count; i++)
				{
					SharedRow(i).DetachFromDataGridView();
				}
				SharedList.Clear();
				mobjRowStates.Clear();
				OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), 0, count, blnChangeIsDeletion: true, blnChangeIsInsertion: false, blnRecreateNewRow, new Point(-1, -1));
			}
			else if (blnRecreateNewRow && DataGridView.Columns.Count != 0 && DataGridView.AllowUserToAddRowsInternal && mobjItems.Count == 0)
			{
				DataGridView.AddNewRow(blnCreatedByEditing: false);
			}
		}

		/// Determines whether the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> is in the collection.</summary>
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> is in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>; otherwise, false.</returns>
		/// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to locate in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
		/// 1</filterpriority>
		public virtual bool Contains(DataGridViewRow objDataGridViewRow)
		{
			return mobjItems.IndexOf(objDataGridViewRow) != -1;
		}

		/// Copies the items from the collection into the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> array, starting at the specified index.</summary>
		/// <param name="arrRows">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> array that is the destination of the items copied from the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
		/// <param name="index">The zero-based index in array at which copying begins.</param>
		/// <exception cref="T:System.ArgumentException">array is multidimensional.-or- index is equal to or greater than the length of array.-or- The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> is greater than the available space from index to the end of array. </exception>
		/// <exception cref="T:System.ArgumentNullException">array is null. </exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero. </exception>
		/// 1</filterpriority>
		public void CopyTo(DataGridViewRow[] arrRows, int index)
		{
			mobjItems.CopyTo(arrRows, index);
		}

		internal int DisplayIndexToRowIndex(int visibleRowIndex)
		{
			int num = -1;
			for (int i = 0; i < Count; i++)
			{
				if ((GetRowState(i) & DataGridViewElementStates.Visible) == DataGridViewElementStates.Visible)
				{
					num++;
				}
				if (num == visibleRowIndex)
				{
					return i;
				}
			}
			return -1;
		}

		/// Returns the index of the first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified criteria.</summary>
		/// The index of the first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter; -1 if no row is found.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
		/// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		public int GetFirstRow(DataGridViewElementStates enmIncludeFilter)
		{
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			switch (enmIncludeFilter)
			{
			case DataGridViewElementStates.Visible:
				if (mintRowCountsVisible == 0)
				{
					return -1;
				}
				break;
			case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
				if (mintRowCountsVisibleFrozen == 0)
				{
					return -1;
				}
				break;
			case DataGridViewElementStates.Selected | DataGridViewElementStates.Visible:
				if (mintRowCountsVisibleSelected == 0)
				{
					return -1;
				}
				break;
			}
			int i;
			for (i = 0; i < mobjItems.Count && (GetRowState(i) & enmIncludeFilter) != enmIncludeFilter; i++)
			{
			}
			if (i >= mobjItems.Count)
			{
				return -1;
			}
			return i;
		}

		/// Returns the index of the first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified inclusion and exclusion criteria.</summary>
		/// The index of the first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter, and does not have the attributes specified by excludeFilter; -1 if no row is found.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
		/// <param name="enmExcludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
		/// <exception cref="T:System.ArgumentException">One or both of the specified filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		public int GetFirstRow(DataGridViewElementStates enmIncludeFilter, DataGridViewElementStates enmExcludeFilter)
		{
			if (enmExcludeFilter == DataGridViewElementStates.None)
			{
				return GetFirstRow(enmIncludeFilter);
			}
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			if ((enmExcludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "excludeFilter"));
			}
			switch (enmIncludeFilter)
			{
			case DataGridViewElementStates.Visible:
				if (mintRowCountsVisible == 0)
				{
					return -1;
				}
				break;
			case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
				if (mintRowCountsVisibleFrozen == 0)
				{
					return -1;
				}
				break;
			case DataGridViewElementStates.Selected | DataGridViewElementStates.Visible:
				if (mintRowCountsVisibleSelected == 0)
				{
					return -1;
				}
				break;
			}
			int i;
			for (i = 0; i < mobjItems.Count && ((GetRowState(i) & enmIncludeFilter) != enmIncludeFilter || (GetRowState(i) & enmExcludeFilter) != DataGridViewElementStates.None); i++)
			{
			}
			if (i >= mobjItems.Count)
			{
				return -1;
			}
			return i;
		}

		/// Returns the index of the last <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified criteria.</summary>
		/// The index of the last <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter; -1 if no row is found.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
		/// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		public int GetLastRow(DataGridViewElementStates enmIncludeFilter)
		{
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			switch (enmIncludeFilter)
			{
			case DataGridViewElementStates.Visible:
				if (mintRowCountsVisible == 0)
				{
					return -1;
				}
				break;
			case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
				if (mintRowCountsVisibleFrozen == 0)
				{
					return -1;
				}
				break;
			case DataGridViewElementStates.Selected | DataGridViewElementStates.Visible:
				if (mintRowCountsVisibleSelected == 0)
				{
					return -1;
				}
				break;
			}
			int num = mobjItems.Count - 1;
			while (num >= 0 && (GetRowState(num) & enmIncludeFilter) != enmIncludeFilter)
			{
				num--;
			}
			if (num < 0)
			{
				return -1;
			}
			return num;
		}

		/// Returns the index of the next <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified criteria.</summary>
		/// The index of the first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> after indexStart that has the attributes specified by includeFilter, or -1 if no row is found.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
		/// <param name="indexStart">The index of the row where the method should begin to look for the next <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
		/// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">indexStart is less than -1.</exception>
		public int GetNextRow(int indexStart, DataGridViewElementStates enmIncludeFilter)
		{
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			if (indexStart < -1)
			{
				object[] arrArgs = new object[3]
				{
					"indexStart",
					indexStart.ToString(CultureInfo.CurrentCulture),
					(-1).ToString(CultureInfo.CurrentCulture)
				};
				throw new ArgumentOutOfRangeException("indexStart", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
			}
			int i;
			for (i = indexStart + 1; i < mobjItems.Count && (GetRowState(i) & enmIncludeFilter) != enmIncludeFilter; i++)
			{
			}
			if (i >= mobjItems.Count)
			{
				return -1;
			}
			return i;
		}

		internal int GetNextRow(int indexStart, DataGridViewElementStates enmIncludeFilter, int intSkipRows)
		{
			int num = indexStart;
			do
			{
				num = GetNextRow(num, enmIncludeFilter);
				intSkipRows--;
			}
			while (intSkipRows >= 0 && num != -1);
			return num;
		}

		/// Returns the index of the next <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified inclusion and exclusion criteria.</summary>
		/// The index of the next <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter, and does not have the attributes specified by excludeFilter; -1 if no row is found.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
		/// <param name="indexStart">The index of the row where the method should begin to look for the next <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
		/// <param name="enmExcludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
		/// <exception cref="T:System.ArgumentException">One or both of the specified filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">indexStart is less than -1.</exception>
		public int GetNextRow(int indexStart, DataGridViewElementStates enmIncludeFilter, DataGridViewElementStates enmExcludeFilter)
		{
			if (enmExcludeFilter == DataGridViewElementStates.None)
			{
				return GetNextRow(indexStart, enmIncludeFilter);
			}
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			if ((enmExcludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "excludeFilter"));
			}
			if (indexStart < -1)
			{
				object[] arrArgs = new object[3]
				{
					"indexStart",
					indexStart.ToString(CultureInfo.CurrentCulture),
					(-1).ToString(CultureInfo.CurrentCulture)
				};
				throw new ArgumentOutOfRangeException("indexStart", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
			}
			int i;
			for (i = indexStart + 1; i < mobjItems.Count && ((GetRowState(i) & enmIncludeFilter) != enmIncludeFilter || (GetRowState(i) & enmExcludeFilter) != DataGridViewElementStates.None); i++)
			{
			}
			if (i >= mobjItems.Count)
			{
				return -1;
			}
			return i;
		}

		/// Returns the index of the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified criteria.</summary>
		/// The index of the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter; -1 if no row is found.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
		/// <param name="indexStart">The index of the row where the method should begin to look for the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
		/// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">indexStart is greater than the number of rows in the collection.</exception>
		public int GetPreviousRow(int indexStart, DataGridViewElementStates enmIncludeFilter)
		{
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			if (indexStart > mobjItems.Count)
			{
				throw new ArgumentOutOfRangeException("indexStart", SR.GetString("InvalidHighBoundArgumentEx", "indexStart", indexStart.ToString(CultureInfo.CurrentCulture), mobjItems.Count.ToString(CultureInfo.CurrentCulture)));
			}
			int num = indexStart - 1;
			while (num >= 0 && (GetRowState(num) & enmIncludeFilter) != enmIncludeFilter)
			{
				num--;
			}
			if (num < 0)
			{
				return -1;
			}
			return num;
		}

		/// Returns the index of the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that meets the specified inclusion and exclusion criteria.</summary>
		/// The index of the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has the attributes specified by includeFilter, and does not have the attributes specified by excludeFilter; -1 if no row is found.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
		/// <param name="indexStart">The index of the row where the method should begin to look for the previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
		/// <param name="enmExcludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
		/// <exception cref="T:System.ArgumentException">One or both of the specified filter values is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">indexStart is greater than the number of rows in the collection.</exception>
		public int GetPreviousRow(int indexStart, DataGridViewElementStates enmIncludeFilter, DataGridViewElementStates enmExcludeFilter)
		{
			if (enmExcludeFilter == DataGridViewElementStates.None)
			{
				return GetPreviousRow(indexStart, enmIncludeFilter);
			}
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			if ((enmExcludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "excludeFilter"));
			}
			if (indexStart > mobjItems.Count)
			{
				throw new ArgumentOutOfRangeException("indexStart", SR.GetString("InvalidHighBoundArgumentEx", "indexStart", indexStart.ToString(CultureInfo.CurrentCulture), mobjItems.Count.ToString(CultureInfo.CurrentCulture)));
			}
			int num = indexStart - 1;
			while (num >= 0 && ((GetRowState(num) & enmIncludeFilter) != enmIncludeFilter || (GetRowState(num) & enmExcludeFilter) != DataGridViewElementStates.None))
			{
				num--;
			}
			if (num < 0)
			{
				return -1;
			}
			return num;
		}

		/// Returns the number of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects in the collection that meet the specified criteria.</summary>
		/// The number of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> that have the attributes specified by includeFilter.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
		/// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		public int GetRowCount(DataGridViewElementStates enmIncludeFilter)
		{
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			switch (enmIncludeFilter)
			{
			case DataGridViewElementStates.Visible:
				if (mintRowCountsVisible != -1)
				{
					return mintRowCountsVisible;
				}
				break;
			case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
				if (mintRowCountsVisibleFrozen != -1)
				{
					return mintRowCountsVisibleFrozen;
				}
				break;
			case DataGridViewElementStates.Selected | DataGridViewElementStates.Visible:
				if (mintRowCountsVisibleSelected != -1)
				{
					return mintRowCountsVisibleSelected;
				}
				break;
			}
			int num = 0;
			for (int i = 0; i < mobjItems.Count; i++)
			{
				if ((GetRowState(i) & enmIncludeFilter) == enmIncludeFilter)
				{
					num++;
				}
			}
			switch (enmIncludeFilter)
			{
			case DataGridViewElementStates.Visible:
				mintRowCountsVisible = num;
				return num;
			case DataGridViewElementStates.Displayed | DataGridViewElementStates.Visible:
				return num;
			case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
				mintRowCountsVisibleFrozen = num;
				return num;
			case DataGridViewElementStates.Selected | DataGridViewElementStates.Visible:
				mintRowCountsVisibleSelected = num;
				return num;
			default:
				return num;
			}
		}

		internal int GetRowCount(DataGridViewElementStates enmIncludeFilter, int intFromRowIndex, int toRowIndex)
		{
			int num = 0;
			for (int i = intFromRowIndex + 1; i <= toRowIndex; i++)
			{
				if ((GetRowState(i) & enmIncludeFilter) == enmIncludeFilter)
				{
					num++;
				}
			}
			return num;
		}

		/// Returns the cumulative height of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects that meet the specified criteria.</summary>
		/// The cumulative height of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> that have the attributes specified by includeFilter.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
		/// <exception cref="T:System.ArgumentException">includeFilter is not a valid bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</exception>
		public int GetRowsHeight(DataGridViewElementStates enmIncludeFilter)
		{
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			switch (enmIncludeFilter)
			{
			case DataGridViewElementStates.Visible:
				if (mintRowsHeightVisible != -1)
				{
					return mintRowsHeightVisible;
				}
				break;
			case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
				if (mintRowsHeightVisibleFrozen != -1)
				{
					return mintRowsHeightVisibleFrozen;
				}
				break;
			}
			int num = 0;
			for (int i = 0; i < mobjItems.Count; i++)
			{
				if ((GetRowState(i) & enmIncludeFilter) == enmIncludeFilter)
				{
					num += ((DataGridViewRow)mobjItems[i]).GetHeight(i);
				}
			}
			switch (enmIncludeFilter)
			{
			case DataGridViewElementStates.Visible:
				mintRowsHeightVisible = num;
				return num;
			case DataGridViewElementStates.Displayed | DataGridViewElementStates.Visible:
				return num;
			case DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible:
				mintRowsHeightVisibleFrozen = num;
				return num;
			default:
				return num;
			}
		}

		internal int GetRowsHeight(DataGridViewElementStates enmIncludeFilter, int intFromRowIndex, int toRowIndex)
		{
			int num = 0;
			for (int i = intFromRowIndex; i < toRowIndex; i++)
			{
				if ((GetRowState(i) & enmIncludeFilter) == enmIncludeFilter)
				{
					num += ((DataGridViewRow)mobjItems[i]).GetHeight(i);
				}
			}
			return num;
		}

		private bool GetRowsHeightExceedLimit(DataGridViewElementStates enmIncludeFilter, int intFromRowIndex, int toRowIndex, int intHeightLimit)
		{
			int num = 0;
			for (int i = intFromRowIndex; i < toRowIndex; i++)
			{
				if ((GetRowState(i) & enmIncludeFilter) == enmIncludeFilter)
				{
					num += ((DataGridViewRow)mobjItems[i]).GetHeight(i);
					if (num > intHeightLimit)
					{
						return true;
					}
				}
			}
			return num > intHeightLimit;
		}

		/// Gets the state of the row with the specified index.</summary>
		/// A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the state of the specified row.</returns>
		/// <param name="intRowIndex">The index of the row.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero and greater than the number of rows in the collection minus one.</exception>
		public virtual DataGridViewElementStates GetRowState(int intRowIndex)
		{
			if (intRowIndex < 0 || intRowIndex >= mobjItems.Count)
			{
				throw new ArgumentOutOfRangeException("rowIndex", SR.GetString("DataGridViewRowCollection_RowIndexOutOfRange"));
			}
			DataGridViewRow dataGridViewRow = SharedRow(intRowIndex);
			if (dataGridViewRow.Index == -1)
			{
				return SharedRowState(intRowIndex);
			}
			return dataGridViewRow.GetState(intRowIndex);
		}

		/// Returns the index of a specified item in the collection.</summary>
		/// The index of value if it is a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> found in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>; otherwise, -1.</returns>
		/// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to locate in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
		/// 1</filterpriority>
		public int IndexOf(DataGridViewRow objDataGridViewRow)
		{
			return mobjItems.IndexOf(objDataGridViewRow);
		}

		/// Inserts the specified number of rows into the collection at the specified location.</summary>
		/// <param name="intCount">The number of rows to insert into the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
		/// <param name="intRowIndex">The position at which to insert the rows.</param>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-rowIndex is equal to the number of rows in the collection and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is set to true.-or-The row returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowTemplate"></see> property has more cells than there are columns in the control. -or-This operation would insert a frozen row after unfrozen rows or an unfrozen row before frozen rows.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero or greater than the number of rows in the collection. -or-count is less than 1.</exception>
		/// 1</filterpriority>
		public virtual void Insert(int intRowIndex, int intCount)
		{
			if (DataGridView.DataSource != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
			}
			if (intRowIndex < 0 || Count < intRowIndex)
			{
				throw new ArgumentOutOfRangeException("rowIndex", SR.GetString("DataGridViewRowCollection_IndexDestinationOutOfRange"));
			}
			if (intCount <= 0)
			{
				throw new ArgumentOutOfRangeException("count", SR.GetString("DataGridViewRowCollection_CountOutOfRange"));
			}
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			if (DataGridView.Columns.Count == 0)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
			}
			if (DataGridView.RowTemplate.Cells.Count > DataGridView.Columns.Count)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_RowTemplateTooManyCells"));
			}
			if (DataGridView.NewRowIndex != -1 && intRowIndex == Count)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoInsertionAfterNewRow"));
			}
			DataGridViewRow rowTemplateClone = DataGridView.RowTemplateClone;
			DataGridViewElementStates state = rowTemplateClone.State;
			rowTemplateClone.DataGridViewInternal = mobjDataGridView;
			int num = 0;
			foreach (DataGridViewCell cell in rowTemplateClone.Cells)
			{
				cell.DataGridViewInternal = mobjDataGridView;
				cell.OwningColumnInternal = DataGridView.Columns[num];
				num++;
			}
			if (rowTemplateClone.HasHeaderCell)
			{
				rowTemplateClone.HeaderCell.DataGridViewInternal = mobjDataGridView;
				rowTemplateClone.HeaderCell.OwningRowInternal = rowTemplateClone;
			}
			InsertCopiesPrivate(rowTemplateClone, state, intRowIndex, intCount);
		}

		/// Inserts the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> into the collection.</summary>
		/// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to insert into the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
		/// <param name="intRowIndex">The position at which to insert the row.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero or greater than the number of rows in the collection. </exception>
		/// <exception cref="T:System.ArgumentException">dataGridViewRow has more cells than there are columns in the control.</exception>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-rowIndex is equal to the number of rows in the collection and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is set to true.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of dataGridViewRow is not null.-or-dataGridViewRow has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.Selected"></see> property value of true. -or-This operation would insert a frozen row after unfrozen rows or an unfrozen row before frozen rows.</exception>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewRow is null.</exception>
		/// 1</filterpriority>
		public virtual void Insert(int intRowIndex, DataGridViewRow objDataGridViewRow)
		{
			if (DataGridView.DataSource != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
			}
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			InsertInternal(intRowIndex, objDataGridViewRow);
		}

		/// Inserts a row into the collection at the specified position, and populates the cells with the specified objects.</summary>
		/// <param name="intRowIndex">The position at which to insert the row.</param>
		/// <param name="arrValues">A variable number of objects that populate the cells of the new row.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero or greater than the number of rows in the collection. </exception>
		/// <exception cref="T:System.ArgumentException">The row returned by the control's <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowTemplate"></see> property has more cells than there are columns in the control.</exception>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is set to true.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-rowIndex is equal to the number of rows in the collection and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is set to true.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the row returned by the control's <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowTemplate"></see> property is not null. -or-This operation would insert a frozen row after unfrozen rows or an unfrozen row before frozen rows.</exception>
		/// <exception cref="T:System.ArgumentNullException">values is null.</exception>
		/// 1</filterpriority>
		public virtual void Insert(int intRowIndex, params object[] arrValues)
		{
			if (arrValues == null)
			{
				throw new ArgumentNullException("values");
			}
			if (DataGridView.VirtualMode)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationInVirtualMode"));
			}
			if (DataGridView.DataSource != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
			}
			DataGridViewRow rowTemplateClone = DataGridView.RowTemplateClone;
			rowTemplateClone.SetValuesInternal(arrValues);
			Insert(intRowIndex, rowTemplateClone);
		}

		/// Inserts rows into the collection at the specified position.</summary>
		/// <param name="indexDestination">The position at which to insert the rows.</param>
		/// <param name="intCount">The number of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects to add to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
		/// <param name="indexSource">The index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> on which to base the new rows.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">indexSource is less than zero or greater than the number of rows in the collection minus one.-or-indexDestination is less than zero or greater than the number of rows in the collection.-or-count is less than 1.</exception>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-indexDestination is equal to the number of rows in the collection and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> is true.-or-This operation would insert frozen rows after unfrozen rows or unfrozen rows before frozen rows.</exception>
		/// 1</filterpriority>
		public virtual void InsertCopies(int indexSource, int indexDestination, int intCount)
		{
			if (DataGridView.DataSource != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
			}
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			InsertCopiesPrivate(indexSource, indexDestination, intCount);
		}

		/// 
		/// Inserts the copies private.
		/// </summary>
		/// <param name="indexSource">The index source.</param>
		/// <param name="indexDestination">The index destination.</param>
		/// <param name="intCount">The count.</param>
		private void InsertCopiesPrivate(int indexSource, int indexDestination, int intCount)
		{
			if (indexSource < 0 || Count <= indexSource)
			{
				throw new ArgumentOutOfRangeException("indexSource", SR.GetString("DataGridViewRowCollection_IndexSourceOutOfRange"));
			}
			if (indexDestination < 0 || Count < indexDestination)
			{
				throw new ArgumentOutOfRangeException("indexDestination", SR.GetString("DataGridViewRowCollection_IndexDestinationOutOfRange"));
			}
			if (intCount <= 0)
			{
				throw new ArgumentOutOfRangeException("count", SR.GetString("DataGridViewRowCollection_CountOutOfRange"));
			}
			if (DataGridView.NewRowIndex != -1 && indexDestination == Count)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoInsertionAfterNewRow"));
			}
			DataGridViewElementStates enmRowTemplateState = GetRowState(indexSource) & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Selected);
			InsertCopiesPrivate(SharedRow(indexSource), enmRowTemplateState, indexDestination, intCount);
		}

		/// 
		/// Inserts the copies private.
		/// </summary>
		/// <param name="objRowTemplate">The row template.</param>
		/// <param name="enmRowTemplateState">State of the row template.</param>
		/// <param name="indexDestination">The index destination.</param>
		/// <param name="intCount">The count.</param>
		private void InsertCopiesPrivate(DataGridViewRow objRowTemplate, DataGridViewElementStates enmRowTemplateState, int indexDestination, int intCount)
		{
			Point objNewCurrentCell = new Point(-1, -1);
			if (objRowTemplate.Index == -1)
			{
				if (intCount > 1)
				{
					DataGridView.OnInsertingRow(indexDestination, objRowTemplate, enmRowTemplateState, ref objNewCurrentCell, blnFirstInsertion: true, intCount, blnForce: false);
					for (int i = 0; i < intCount; i++)
					{
						SharedList.Insert(indexDestination + i, objRowTemplate);
						mobjRowStates.Insert(indexDestination + i, enmRowTemplateState);
					}
					DataGridView.OnInsertedRow_PreNotification(indexDestination, intCount);
					OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), indexDestination, intCount, blnChangeIsDeletion: false, blnChangeIsInsertion: true, blnRecreateNewRow: false, objNewCurrentCell);
					for (int j = 0; j < intCount; j++)
					{
						DataGridView.OnInsertedRow_PostNotification(indexDestination + j, objNewCurrentCell, j == intCount - 1);
					}
				}
				else
				{
					DataGridView.OnInsertingRow(indexDestination, objRowTemplate, enmRowTemplateState, ref objNewCurrentCell, blnFirstInsertion: true, 1, blnForce: false);
					SharedList.Insert(indexDestination, objRowTemplate);
					mobjRowStates.Insert(indexDestination, enmRowTemplateState);
					OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, SharedRow(indexDestination)), indexDestination, intCount, blnChangeIsDeletion: false, blnChangeIsInsertion: true, blnRecreateNewRow: false, objNewCurrentCell);
				}
				return;
			}
			InsertDuplicateRow(indexDestination, objRowTemplate, blnFirstInsertion: true, ref objNewCurrentCell);
			if (intCount > 1)
			{
				DataGridView.OnInsertedRow_PreNotification(indexDestination, 1);
				if (RowIsSharable(indexDestination))
				{
					DataGridViewRow dataGridViewRow = SharedRow(indexDestination);
					DataGridView.OnInsertingRow(indexDestination + 1, dataGridViewRow, enmRowTemplateState, ref objNewCurrentCell, blnFirstInsertion: false, intCount - 1, blnForce: false);
					for (int k = 1; k < intCount; k++)
					{
						SharedList.Insert(indexDestination + k, dataGridViewRow);
						mobjRowStates.Insert(indexDestination + k, enmRowTemplateState);
					}
					DataGridView.OnInsertedRow_PreNotification(indexDestination + 1, intCount - 1);
					OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), indexDestination, intCount, blnChangeIsDeletion: false, blnChangeIsInsertion: true, blnRecreateNewRow: false, objNewCurrentCell);
				}
				else
				{
					UnshareRow(indexDestination);
					for (int l = 1; l < intCount; l++)
					{
						InsertDuplicateRow(indexDestination + l, objRowTemplate, blnFirstInsertion: false, ref objNewCurrentCell);
						UnshareRow(indexDestination + l);
					}
					DataGridView.OnInsertedRow_PreNotification(indexDestination + 1, intCount - 1);
					OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), indexDestination, intCount, blnChangeIsDeletion: false, blnChangeIsInsertion: true, blnRecreateNewRow: false, objNewCurrentCell);
				}
				for (int m = 0; m < intCount; m++)
				{
					DataGridView.OnInsertedRow_PostNotification(indexDestination + m, objNewCurrentCell, m == intCount - 1);
				}
			}
			else
			{
				if (IsCollectionChangedListenedTo)
				{
					UnshareRow(indexDestination);
				}
				OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, SharedRow(indexDestination)), indexDestination, 1, blnChangeIsDeletion: false, blnChangeIsInsertion: true, blnRecreateNewRow: false, objNewCurrentCell);
			}
		}

		/// Inserts a row into the collection at the specified position, based on the row at specified position.</summary>
		/// <param name="indexDestination">The position at which to insert the row.</param>
		/// <param name="indexSource">The index of the row on which to base the new row.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">indexSource is less than zero or greater than the number of rows in the collection minus one.-or-indexDestination is less than zero or greater than the number of rows in the collection.</exception>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-indexDestination is equal to the number of rows in the collection and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> is true. -or-This operation would insert a frozen row after unfrozen rows or an unfrozen row before frozen rows.</exception>
		/// 1</filterpriority>
		public virtual void InsertCopy(int indexSource, int indexDestination)
		{
			InsertCopies(indexSource, indexDestination, 1);
		}

		/// 
		/// Inserts the duplicate row.
		/// </summary>
		/// <param name="indexDestination">The index destination.</param>
		/// <param name="objRowTemplate">The row template.</param>
		/// <param name="blnFirstInsertion">if set to true</c> [first insertion].</param>
		/// <param name="objNewCurrentCell">The new current cell.</param>
		private void InsertDuplicateRow(int indexDestination, DataGridViewRow objRowTemplate, bool blnFirstInsertion, ref Point objNewCurrentCell)
		{
			DataGridViewRow dataGridViewRow = (DataGridViewRow)objRowTemplate.Clone();
			dataGridViewRow.StateInternal = DataGridViewElementStates.None;
			dataGridViewRow.DataGridViewInternal = mobjDataGridView;
			DataGridViewCellCollection cells = dataGridViewRow.Cells;
			int num = 0;
			foreach (DataGridViewCell item in cells)
			{
				item.DataGridViewInternal = mobjDataGridView;
				item.OwningColumnInternal = DataGridView.Columns[num];
				num++;
			}
			DataGridViewElementStates dataGridViewElementStates = objRowTemplate.State & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Selected);
			if (dataGridViewRow.HasHeaderCell)
			{
				dataGridViewRow.HeaderCell.DataGridViewInternal = mobjDataGridView;
				dataGridViewRow.HeaderCell.OwningRowInternal = dataGridViewRow;
			}
			DataGridView.OnInsertingRow(indexDestination, dataGridViewRow, dataGridViewElementStates, ref objNewCurrentCell, blnFirstInsertion, 1, blnForce: false);
			SharedList.Insert(indexDestination, dataGridViewRow);
			mobjRowStates.Insert(indexDestination, dataGridViewElementStates);
		}

		/// 
		/// Inserts the internal.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="objDataGridViewRow">The data grid view row.</param>
		internal void InsertInternal(int intRowIndex, DataGridViewRow objDataGridViewRow)
		{
			if (intRowIndex < 0 || Count < intRowIndex)
			{
				throw new ArgumentOutOfRangeException("rowIndex", SR.GetString("DataGridViewRowCollection_RowIndexOutOfRange"));
			}
			if (objDataGridViewRow == null)
			{
				throw new ArgumentNullException("dataGridViewRow");
			}
			if (objDataGridViewRow.DataGridView != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_RowAlreadyBelongsToDataGridView"));
			}
			if (DataGridView.NewRowIndex != -1 && intRowIndex == Count)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoInsertionAfterNewRow"));
			}
			if (DataGridView.Columns.Count == 0)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
			}
			if (objDataGridViewRow.Cells.Count > DataGridView.Columns.Count)
			{
				throw new ArgumentException(SR.GetString("DataGridViewRowCollection_TooManyCells"), "dataGridViewRow");
			}
			if (objDataGridViewRow.Selected)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CannotAddOrInsertSelectedRow"));
			}
			InsertInternal(intRowIndex, objDataGridViewRow, blnForce: false);
		}

		/// 
		/// Inserts the internal.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="objDataGridViewRow">The data grid view row.</param>
		/// <param name="blnForce">if set to true</c> [force].</param>
		internal void InsertInternal(int intRowIndex, DataGridViewRow objDataGridViewRow, bool blnForce)
		{
			Point objNewCurrentCell = new Point(-1, -1);
			if (blnForce)
			{
				if (DataGridView.Columns.Count == 0)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
				}
				if (objDataGridViewRow.Cells.Count > DataGridView.Columns.Count)
				{
					throw new ArgumentException(SR.GetString("DataGridViewRowCollection_TooManyCells"), "dataGridViewRow");
				}
			}
			DataGridView.CompleteCellsCollection(objDataGridViewRow);
			DataGridView.OnInsertingRow(intRowIndex, objDataGridViewRow, objDataGridViewRow.State, ref objNewCurrentCell, blnFirstInsertion: true, 1, blnForce);
			int num = 0;
			foreach (DataGridViewCell cell in objDataGridViewRow.Cells)
			{
				cell.DataGridViewInternal = mobjDataGridView;
				if (cell.ColumnIndex == -1)
				{
					cell.OwningColumnInternal = DataGridView.Columns[num];
				}
				num++;
			}
			if (objDataGridViewRow.HasHeaderCell)
			{
				objDataGridViewRow.HeaderCell.DataGridViewInternal = DataGridView;
				objDataGridViewRow.HeaderCell.OwningRowInternal = objDataGridViewRow;
			}
			SharedList.Insert(intRowIndex, objDataGridViewRow);
			mobjRowStates.Insert(intRowIndex, objDataGridViewRow.State);
			objDataGridViewRow.DataGridViewInternal = mobjDataGridView;
			if (!RowIsSharable(intRowIndex) || RowHasValueOrToolTipText(objDataGridViewRow) || IsCollectionChangedListenedTo)
			{
				objDataGridViewRow.IndexInternal = intRowIndex;
			}
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Add, objDataGridViewRow), intRowIndex, 1, blnChangeIsDeletion: false, blnChangeIsInsertion: true, blnRecreateNewRow: false, objNewCurrentCell);
		}

		/// Inserts the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects into the collection at the specified position.</summary>
		/// <param name="intRowIndex">The position at which to insert the rows.</param>
		/// <param name="arrDataGridViewRows">An array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> objects to add to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-rowIndex is equal to the number of rows in the collection and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> is true.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is not null.-or-At least one entry in the dataGridViewRows array is null.-or-The <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has no columns.-or-At least one row in the dataGridViewRows array has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property value that is not null.-or-At least one row in the dataGridViewRows array has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.Selected"></see> property value of true.-or-Two or more rows in the dataGridViewRows array are identical.-or-At least one row in the dataGridViewRows array contains one or more cells of a type that is incompatible with the type of the corresponding column in the control.-or-At least one row in the dataGridViewRows array contains more cells than there are columns in the control. 
		/// -or-This operation would insert frozen rows after unfrozen rows or unfrozen rows before frozen rows.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero or greater than the number of rows in the collection.</exception>
		/// <exception cref="T:System.ArgumentException">dataGridViewRows contains only one row, and the row it contains has more cells than there are columns in the control.</exception>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewRows is null.</exception>
		/// 1</filterpriority>
		public virtual void InsertRange(int intRowIndex, params DataGridViewRow[] arrDataGridViewRows)
		{
			if (arrDataGridViewRows == null)
			{
				throw new ArgumentNullException("dataGridViewRows");
			}
			if (arrDataGridViewRows.Length == 1)
			{
				Insert(intRowIndex, arrDataGridViewRows[0]);
				return;
			}
			if (intRowIndex < 0 || intRowIndex > Count)
			{
				throw new ArgumentOutOfRangeException("rowIndex", SR.GetString("DataGridViewRowCollection_IndexDestinationOutOfRange"));
			}
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			if (DataGridView.NewRowIndex != -1 && intRowIndex == Count)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoInsertionAfterNewRow"));
			}
			if (DataGridView.DataSource != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_AddUnboundRow"));
			}
			if (DataGridView.Columns.Count == 0)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_NoColumns"));
			}
			Point objNewCurrentCell = new Point(-1, -1);
			DataGridView.OnInsertingRows(intRowIndex, arrDataGridViewRows, ref objNewCurrentCell);
			int num = intRowIndex;
			foreach (DataGridViewRow dataGridViewRow in arrDataGridViewRows)
			{
				int num2 = 0;
				foreach (DataGridViewCell cell in dataGridViewRow.Cells)
				{
					cell.DataGridViewInternal = mobjDataGridView;
					if (cell.ColumnIndex == -1)
					{
						cell.OwningColumnInternal = DataGridView.Columns[num2];
					}
					num2++;
				}
				if (dataGridViewRow.HasHeaderCell)
				{
					dataGridViewRow.HeaderCell.DataGridViewInternal = DataGridView;
					dataGridViewRow.HeaderCell.OwningRowInternal = dataGridViewRow;
				}
				SharedList.Insert(num, dataGridViewRow);
				mobjRowStates.Insert(num, dataGridViewRow.State);
				dataGridViewRow.IndexInternal = num;
				dataGridViewRow.DataGridViewInternal = mobjDataGridView;
				num++;
			}
			DataGridView.OnInsertedRows_PreNotification(intRowIndex, arrDataGridViewRows);
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Refresh, null), intRowIndex, arrDataGridViewRows.Length, blnChangeIsDeletion: false, blnChangeIsInsertion: true, blnRecreateNewRow: false, objNewCurrentCell);
			DataGridView.OnInsertedRows_PostNotification(arrDataGridViewRows, objNewCurrentCell);
		}

		internal void InvalidateCachedRowCount(DataGridViewElementStates enmIncludeFilter)
		{
			switch (enmIncludeFilter)
			{
			case DataGridViewElementStates.Visible:
				InvalidateCachedRowCounts();
				break;
			case DataGridViewElementStates.Frozen:
				mintRowCountsVisibleFrozen = -1;
				break;
			case DataGridViewElementStates.Selected:
				mintRowCountsVisibleSelected = -1;
				break;
			}
		}

		internal void InvalidateCachedRowCounts()
		{
			mintRowCountsVisible = (mintRowCountsVisibleFrozen = (mintRowCountsVisibleSelected = -1));
		}

		internal void InvalidateCachedRowsHeight(DataGridViewElementStates enmIncludeFilter)
		{
			switch (enmIncludeFilter)
			{
			case DataGridViewElementStates.Visible:
				InvalidateCachedRowsHeights();
				break;
			case DataGridViewElementStates.Frozen:
				mintRowsHeightVisibleFrozen = -1;
				break;
			}
		}

		internal void InvalidateCachedRowsHeights()
		{
			mintRowsHeightVisible = (mintRowsHeightVisibleFrozen = -1);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridViewRowCollection.CollectionChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.ComponentModel.CollectionChangeEventArgs"></see> that contains the event data. </param>
		protected virtual void OnCollectionChanged(CollectionChangeEventArgs e)
		{
			this.CollectionChanged?.Invoke(this, e);
		}

		private void OnCollectionChanged(CollectionChangeEventArgs e, int intRowIndex, int intRowCount)
		{
			Point objNewCurrentCell = new Point(-1, -1);
			DataGridViewRow objDataGridViewRow = (DataGridViewRow)e.Element;
			int num = 0;
			if (objDataGridViewRow != null && e.Action == CollectionChangeAction.Add)
			{
				num = SharedRow(intRowIndex).Index;
			}
			OnCollectionChanged_PreNotification(e.Action, intRowIndex, intRowCount, ref objDataGridViewRow, blnChangeIsInsertion: false);
			if (num == -1 && SharedRow(intRowIndex).Index != -1)
			{
				e = new CollectionChangeEventArgs(e.Action, objDataGridViewRow);
			}
			OnCollectionChanged(e);
			OnCollectionChanged_PostNotification(e.Action, intRowIndex, intRowCount, objDataGridViewRow, blnChangeIsDeletion: false, blnChangeIsInsertion: false, blnRecreateNewRow: false, objNewCurrentCell);
		}

		private void OnCollectionChanged(CollectionChangeEventArgs e, int intRowIndex, int intRowCount, bool blnChangeIsDeletion, bool blnChangeIsInsertion, bool blnRecreateNewRow, Point objNewCurrentCell)
		{
			DataGridViewRow objDataGridViewRow = (DataGridViewRow)e.Element;
			int num = 0;
			if (objDataGridViewRow != null && e.Action == CollectionChangeAction.Add)
			{
				num = SharedRow(intRowIndex).Index;
			}
			OnCollectionChanged_PreNotification(e.Action, intRowIndex, intRowCount, ref objDataGridViewRow, blnChangeIsInsertion);
			if (num == -1 && SharedRow(intRowIndex).Index != -1)
			{
				e = new CollectionChangeEventArgs(e.Action, objDataGridViewRow);
			}
			OnCollectionChanged(e);
			OnCollectionChanged_PostNotification(e.Action, intRowIndex, intRowCount, objDataGridViewRow, blnChangeIsDeletion, blnChangeIsInsertion, blnRecreateNewRow, objNewCurrentCell);
		}

		private void OnCollectionChanged_PostNotification(CollectionChangeAction enmCca, int intRowIndex, int intRowCount, DataGridViewRow objDataGridViewRow, bool blnChangeIsDeletion, bool blnChangeIsInsertion, bool blnRecreateNewRow, Point objNewCurrentCell)
		{
			if (blnChangeIsDeletion)
			{
				DataGridView.OnRowsRemovedInternal(intRowIndex, intRowCount);
			}
			else
			{
				DataGridView.OnRowsAddedInternal(intRowIndex, intRowCount);
			}
			switch (enmCca)
			{
			case CollectionChangeAction.Add:
				if (!blnChangeIsInsertion)
				{
					DataGridView.OnAddedRow_PostNotification(intRowIndex);
				}
				else
				{
					DataGridView.OnInsertedRow_PostNotification(intRowIndex, objNewCurrentCell, blnLastInsertion: true);
				}
				break;
			case CollectionChangeAction.Remove:
				DataGridView.OnRemovedRow_PostNotification(objDataGridViewRow, objNewCurrentCell);
				break;
			case CollectionChangeAction.Refresh:
				if (blnChangeIsDeletion)
				{
					DataGridView.OnClearedRows();
				}
				break;
			}
			DataGridView.OnRowCollectionChanged_PostNotification(blnRecreateNewRow, objNewCurrentCell.X == -1, enmCca, objDataGridViewRow, intRowIndex);
		}

		/// 
		/// Called when [collection changed_ pre notification].
		/// </summary>
		/// <param name="enmCca">The cca.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="intRowCount">The row count.</param>
		/// <param name="objDataGridViewRow">The data grid view row.</param>
		/// <param name="blnChangeIsInsertion">if set to true</c> [change is insertion].</param>
		private void OnCollectionChanged_PreNotification(CollectionChangeAction enmCca, int intRowIndex, int intRowCount, ref DataGridViewRow objDataGridViewRow, bool blnChangeIsInsertion)
		{
			bool flag = false;
			bool blnComputeVisibleRows = false;
			switch (enmCca)
			{
			case CollectionChangeAction.Add:
			{
				int num2 = 0;
				UpdateRowCaches(intRowIndex, ref objDataGridViewRow, blnAdding: true);
				if ((GetRowState(intRowIndex) & DataGridViewElementStates.Visible) != DataGridViewElementStates.None)
				{
					int firstDisplayedRowIndex2 = DataGridView.FirstDisplayedRowIndex;
					if (firstDisplayedRowIndex2 != -1)
					{
						num2 = SharedRow(firstDisplayedRowIndex2).GetHeight(firstDisplayedRowIndex2);
					}
				}
				else
				{
					flag = true;
					blnComputeVisibleRows = blnChangeIsInsertion;
				}
				if (blnChangeIsInsertion)
				{
					DataGridView.OnInsertedRow_PreNotification(intRowIndex, 1);
					if (!flag)
					{
						if ((GetRowState(intRowIndex) & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None)
						{
							flag = DataGridView.FirstDisplayedScrollingRowIndex == -1 && GetRowsHeightExceedLimit(DataGridViewElementStates.Visible, 0, intRowIndex, DataGridView.LayoutInfo.Data.Height);
						}
						else if (DataGridView.FirstDisplayedScrollingRowIndex != -1 && intRowIndex > DataGridView.FirstDisplayedScrollingRowIndex)
						{
							flag = GetRowsHeightExceedLimit(DataGridViewElementStates.Visible, 0, intRowIndex, DataGridView.LayoutInfo.Data.Height + DataGridView.VerticalScrollingOffset) && num2 <= DataGridView.LayoutInfo.Data.Height;
						}
					}
				}
				else
				{
					DataGridView.OnAddedRow_PreNotification(intRowIndex);
					if (!flag)
					{
						int num3 = GetRowsHeight(DataGridViewElementStates.Visible) - DataGridView.VerticalScrollingOffset - objDataGridViewRow.GetHeight(intRowIndex);
						objDataGridViewRow = SharedRow(intRowIndex);
						flag = DataGridView.LayoutInfo.Data.Height < num3 && num2 <= DataGridView.LayoutInfo.Data.Height;
					}
				}
				break;
			}
			case CollectionChangeAction.Remove:
			{
				DataGridViewElementStates rowState = GetRowState(intRowIndex);
				bool flag2 = (rowState & DataGridViewElementStates.Visible) != 0;
				bool flag3 = (rowState & DataGridViewElementStates.Frozen) != 0;
				mobjRowStates.RemoveAt(intRowIndex);
				SharedList.RemoveAt(intRowIndex);
				DataGridView.OnRemovedRow_PreNotification(intRowIndex);
				if (!flag2)
				{
					flag = true;
				}
				else if (!flag3)
				{
					if (DataGridView.FirstDisplayedScrollingRowIndex != -1 && intRowIndex > DataGridView.FirstDisplayedScrollingRowIndex)
					{
						int num = 0;
						int firstDisplayedRowIndex = DataGridView.FirstDisplayedRowIndex;
						if (firstDisplayedRowIndex != -1)
						{
							num = SharedRow(firstDisplayedRowIndex).GetHeight(firstDisplayedRowIndex);
						}
						flag = GetRowsHeightExceedLimit(DataGridViewElementStates.Visible, 0, intRowIndex, DataGridView.LayoutInfo.Data.Height + DataGridView.VerticalScrollingOffset) && num <= DataGridView.LayoutInfo.Data.Height;
					}
				}
				else
				{
					flag = DataGridView.FirstDisplayedScrollingRowIndex == -1 && GetRowsHeightExceedLimit(DataGridViewElementStates.Visible, 0, intRowIndex, DataGridView.LayoutInfo.Data.Height);
				}
				break;
			}
			case CollectionChangeAction.Refresh:
				InvalidateCachedRowCounts();
				InvalidateCachedRowsHeights();
				break;
			}
			DataGridView.ResetUIState(blnUseRowShortcut: false, blnComputeVisibleRows);
		}

		/// Removes the row from the collection.</summary>
		/// <param name="objDataGridViewRow">The row to remove from the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</param>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-dataGridViewRow is the row for new records.-or-The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is bound to an <see cref="T:System.ComponentModel.IBindingList"></see> implementation with <see cref="P:System.ComponentModel.IBindingList.AllowRemove"></see> and <see cref="P:System.ComponentModel.IBindingList.SupportsChangeNotification"></see> property values that are not both true. </exception>
		/// <exception cref="T:System.ArgumentException">dataGridViewRow is not contained in this collection.-or-dataGridViewRow is a shared row.</exception>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewRow is null.</exception>
		/// 1</filterpriority>
		public virtual void Remove(DataGridViewRow objDataGridViewRow)
		{
			if (objDataGridViewRow == null)
			{
				throw new ArgumentNullException("dataGridViewRow");
			}
			if (objDataGridViewRow.DataGridView != DataGridView)
			{
				throw new ArgumentException(SR.GetString("DataGridView_RowDoesNotBelongToDataGridView"), "dataGridViewRow");
			}
			if (objDataGridViewRow.Index == -1)
			{
				throw new ArgumentException(SR.GetString("DataGridView_RowMustBeUnshared"), "dataGridViewRow");
			}
			RemoveAt(objDataGridViewRow.Index);
		}

		/// Removes the row at the specified position from the collection.</summary>
		/// <param name="index">The position of the row to remove.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero and greater than the number of rows in the collection minus one. </exception>
		/// <exception cref="T:System.InvalidOperationException">The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is performing one of the following actions that temporarily prevents new rows from being added:Selecting all cells in the control.Clearing the selection.-or-This method is being called from a handler for one of the following <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events:<see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see>-or-index is equal to the number of rows in the collection and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is set to true.-or-The associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is bound to an <see cref="T:System.ComponentModel.IBindingList"></see> implementation with <see cref="P:System.ComponentModel.IBindingList.AllowRemove"></see> and <see cref="P:System.ComponentModel.IBindingList.SupportsChangeNotification"></see> property values that are not both true.</exception>
		/// 1</filterpriority>
		public virtual void RemoveAt(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException("index", SR.GetString("DataGridViewRowCollection_RowIndexOutOfRange"));
			}
			if (DataGridView.NewRowIndex == index)
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CannotDeleteNewRow"));
			}
			if (DataGridView.NoDimensionChangeAllowed)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ForbiddenOperationInEventHandler"));
			}
			if (DataGridView.DataSource != null)
			{
				if (!(DataGridView.DataConnection.List is IBindingList { AllowRemove: not false, SupportsChangeNotification: not false } bindingList))
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CantRemoveRowsWithWrongSource"));
				}
				bindingList.RemoveAt(index);
			}
			else
			{
				RemoveAtInternal(index, blnForce: false);
			}
		}

		internal void RemoveAtInternal(int index, bool blnForce)
		{
			DataGridViewRow dataGridViewRow = SharedRow(index);
			Point objNewCurrentCell = new Point(-1, -1);
			if (IsCollectionChangedListenedTo || dataGridViewRow.GetDisplayed(index))
			{
				dataGridViewRow = this[index];
			}
			dataGridViewRow = SharedRow(index);
			DataGridView.OnRemovingRow(index, out objNewCurrentCell, blnForce);
			UpdateRowCaches(index, ref dataGridViewRow, blnAdding: false);
			if (dataGridViewRow.Index != -1)
			{
				mobjRowStates[index] = dataGridViewRow.State;
				dataGridViewRow.DetachFromDataGridView();
			}
			OnCollectionChanged(new CollectionChangeEventArgs(CollectionChangeAction.Remove, dataGridViewRow), index, 1, blnChangeIsDeletion: true, blnChangeIsInsertion: false, blnRecreateNewRow: false, objNewCurrentCell);
		}

		private static bool RowHasValueOrToolTipText(DataGridViewRow objDataGridViewRow)
		{
			foreach (DataGridViewCell cell in objDataGridViewRow.Cells)
			{
				if (cell.HasValue || cell.HasToolTipText)
				{
					return true;
				}
			}
			return false;
		}

		/// 
		/// Rows the is sharable.
		/// </summary>
		/// <param name="index">The index.</param>
		/// </returns>
		internal bool RowIsSharable(int index)
		{
			DataGridViewRow dataGridViewRow = SharedRow(index);
			if (dataGridViewRow.Index != -1)
			{
				return false;
			}
			foreach (DataGridViewCell cell in dataGridViewRow.Cells)
			{
				if ((cell.State & ~cell.CellStateFromColumnRowStates(mobjRowStates[index])) != DataGridViewElementStates.None)
				{
					return false;
				}
			}
			return true;
		}

		internal void SetRowState(int intRowIndex, DataGridViewElementStates enmElementState, bool blnValue)
		{
			DataGridViewRow dataGridViewRow = SharedRow(intRowIndex);
			if (dataGridViewRow.Index == -1)
			{
				if ((mobjRowStates[intRowIndex] & enmElementState) != 0 != blnValue)
				{
					if (enmElementState == DataGridViewElementStates.Frozen || enmElementState == DataGridViewElementStates.Visible || enmElementState == DataGridViewElementStates.ReadOnly)
					{
						dataGridViewRow.OnSharedStateChanging(intRowIndex, enmElementState);
					}
					if (blnValue)
					{
						mobjRowStates[intRowIndex] |= enmElementState;
					}
					else
					{
						mobjRowStates[intRowIndex] &= ~enmElementState;
					}
					dataGridViewRow.OnSharedStateChanged(intRowIndex, enmElementState);
				}
				return;
			}
			switch (enmElementState)
			{
			case DataGridViewElementStates.Displayed:
				dataGridViewRow.DisplayedInternal = blnValue;
				break;
			case DataGridViewElementStates.Frozen:
				dataGridViewRow.Frozen = blnValue;
				break;
			case DataGridViewElementStates.ReadOnly:
				dataGridViewRow.ReadOnlyInternal = blnValue;
				break;
			case DataGridViewElementStates.Resizable:
				dataGridViewRow.Resizable = (blnValue ? DataGridViewTriState.True : DataGridViewTriState.False);
				break;
			case DataGridViewElementStates.Selected:
				dataGridViewRow.SelectedInternal = blnValue;
				break;
			case DataGridViewElementStates.Visible:
				dataGridViewRow.Visible = blnValue;
				break;
			}
		}

		/// Returns the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> at the specified index.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> positioned at the specified index.</returns>
		/// <param name="intRowIndex">The index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> to get.</param>
		/// 1</filterpriority>
		public DataGridViewRow SharedRow(int intRowIndex)
		{
			return (DataGridViewRow)SharedList[intRowIndex];
		}

		internal DataGridViewElementStates SharedRowState(int intRowIndex)
		{
			return mobjRowStates[intRowIndex];
		}

		internal void Sort(IComparer objCustomComparer, bool blnAscending)
		{
			if (mobjItems.Count > 0)
			{
				RowComparer objRowComparer = new RowComparer(this, objCustomComparer, blnAscending);
				mobjItems.CustomSort(objRowComparer);
			}
		}

		internal void SwapSortedRows(int intRowIndex1, int intRowIndex2)
		{
			DataGridView.SwapSortedRows(intRowIndex1, intRowIndex2);
			DataGridViewRow dataGridViewRow = SharedRow(intRowIndex1);
			DataGridViewRow dataGridViewRow2 = SharedRow(intRowIndex2);
			if (dataGridViewRow.Index != -1)
			{
				dataGridViewRow.IndexInternal = intRowIndex2;
			}
			if (dataGridViewRow2.Index != -1)
			{
				dataGridViewRow2.IndexInternal = intRowIndex1;
			}
			if (DataGridView.VirtualMode)
			{
				int count = DataGridView.Columns.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewCell dataGridViewCell = dataGridViewRow.Cells[i];
					DataGridViewCell dataGridViewCell2 = dataGridViewRow2.Cells[i];
					object valueInternal = dataGridViewCell.GetValueInternal(intRowIndex1);
					object valueInternal2 = dataGridViewCell2.GetValueInternal(intRowIndex2);
					dataGridViewCell.SetValueInternal(intRowIndex1, valueInternal2);
					dataGridViewCell2.SetValueInternal(intRowIndex2, valueInternal);
				}
			}
			object value = mobjItems[intRowIndex1];
			mobjItems[intRowIndex1] = mobjItems[intRowIndex2];
			mobjItems[intRowIndex2] = value;
			DataGridViewElementStates value2 = mobjRowStates[intRowIndex1];
			mobjRowStates[intRowIndex1] = mobjRowStates[intRowIndex2];
			mobjRowStates[intRowIndex2] = value2;
		}

		void ICollection.CopyTo(Array objArray, int index)
		{
			mobjItems.CopyTo(objArray, index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new UnsharingRowEnumerator(this);
		}

		int IList.Add(object objValue)
		{
			return Add((DataGridViewRow)objValue);
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
			Insert(index, (DataGridViewRow)objValue);
		}

		void IList.Remove(object objValue)
		{
			Remove((DataGridViewRow)objValue);
		}

		void IList.RemoveAt(int index)
		{
			RemoveAt(index);
		}

		private void UnshareRow(int intRowIndex)
		{
			SharedRow(intRowIndex).IndexInternal = intRowIndex;
			SharedRow(intRowIndex).StateInternal = SharedRowState(intRowIndex);
		}

		private void UpdateRowCaches(int intRowIndex, ref DataGridViewRow objDataGridViewRow, bool blnAdding)
		{
			if (mintRowCountsVisible == -1 && mintRowCountsVisibleFrozen == -1 && mintRowCountsVisibleSelected == -1 && mintRowsHeightVisible == -1 && mintRowsHeightVisibleFrozen == -1)
			{
				return;
			}
			DataGridViewElementStates rowState = GetRowState(intRowIndex);
			if ((rowState & DataGridViewElementStates.Visible) == 0)
			{
				return;
			}
			int num = (blnAdding ? 1 : (-1));
			int num2 = 0;
			if (mintRowsHeightVisible != -1 || (mintRowsHeightVisibleFrozen != -1 && (rowState & (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible)) == (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible)))
			{
				num2 = (blnAdding ? objDataGridViewRow.GetHeight(intRowIndex) : (-objDataGridViewRow.GetHeight(intRowIndex)));
				objDataGridViewRow = SharedRow(intRowIndex);
			}
			if (mintRowCountsVisible != -1)
			{
				mintRowCountsVisible += num;
			}
			if (mintRowsHeightVisible != -1)
			{
				mintRowsHeightVisible += num2;
			}
			if ((rowState & (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible)) == (DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible))
			{
				if (mintRowCountsVisibleFrozen != -1)
				{
					mintRowCountsVisibleFrozen += num;
				}
				if (mintRowsHeightVisibleFrozen != -1)
				{
					mintRowsHeightVisibleFrozen += num2;
				}
			}
			if ((rowState & (DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) == (DataGridViewElementStates.Selected | DataGridViewElementStates.Visible) && mintRowCountsVisibleSelected != -1)
			{
				mintRowCountsVisibleSelected += num;
			}
		}
	}
}
