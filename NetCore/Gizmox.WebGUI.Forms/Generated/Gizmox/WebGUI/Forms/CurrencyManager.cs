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
/// Manages a list of <see cref="T:Gizmox.WebGUI.Forms.Binding"></see> objects.</summary>
	/// 2</filterpriority>
	[Serializable]
	public class CurrencyManager : BindingManagerBase
	{
		private bool mblnBound;

		private object mobjDataSource;

		/// Specifies the data type of the list.</summary>
		protected Type finalType;

		private bool mblnInChangeRecordState;

		private int mintLastGoodKnownRow;

		[NonSerialized]
		private IList mobjList;

		/// Specifies the current position of the <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see> in the list.</summary>
		protected int listposition;

		private bool mblnPullingData;

		private ItemChangedEventArgs mobjResetEvent;

		private bool mblnShouldBind;

		private bool mblnSuspendPushDataInCurrentChanged;

		/// 
		/// Manual serialization interception for 'NewRow' when the data source is a System.Data.DataView.
		/// A 'NewRow' is a row that has not yet been committed to the underlying DataTable, but can have values in one
		/// or more fields. System.Data.DataView is an unserializable type which means 'NewRow' must be manually serialized
		/// and deserialized.
		/// </summary>
		private object[] marrSerializedDataViewNewRowValues;

		/// 
		/// Gets a value indicating whether [allow add].
		/// </summary>
		/// true</c> if [allow add]; otherwise, false</c>.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool AllowAdd
		{
			get
			{
				if (List is IBindingList)
				{
					return ((IBindingList)List).AllowNew;
				}
				if (List != null && !List.IsReadOnly)
				{
					return !List.IsFixedSize;
				}
				return false;
			}
		}

		/// 
		/// Gets a value indicating whether [allow edit].
		/// </summary>
		/// true</c> if [allow edit]; otherwise, false</c>.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool AllowEdit
		{
			get
			{
				if (List is IBindingList)
				{
					return ((IBindingList)List).AllowEdit;
				}
				if (List == null)
				{
					return false;
				}
				return !List.IsReadOnly;
			}
		}

		/// 
		/// Gets a value indicating whether [allow remove].
		/// </summary>
		/// true</c> if [allow remove]; otherwise, false</c>.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool AllowRemove
		{
			get
			{
				if (List is IBindingList)
				{
					return ((IBindingList)List).AllowRemove;
				}
				if (List != null && !List.IsReadOnly)
				{
					return !List.IsFixedSize;
				}
				return false;
			}
		}

		internal override Type BindType => ListBindingHelper.GetListItemType(List);

		/// Gets the number of items in the list.</summary>
		/// The number of items in the list.</returns>
		/// 1</filterpriority>
		public override int Count
		{
			get
			{
				if (List == null)
				{
					return 0;
				}
				return List.Count;
			}
		}

		/// Gets the current item in the list.</summary>
		/// A list item of type <see cref="T:System.Object"></see>.</returns>
		/// 1</filterpriority>
		public override object Current => this[Position];

		internal override object DataSource => mobjDataSource;

		internal override bool IsBinding => mblnBound;

		/// 
		/// Gets or sets the <see cref="T:System.Object" /> at the specified index.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public object this[int index]
		{
			get
			{
				if (index < 0 || index >= List.Count)
				{
					throw new IndexOutOfRangeException(SR.GetString("ListManagerNoValue", index.ToString(CultureInfo.CurrentCulture)));
				}
				return List[index];
			}
			set
			{
				if (index < 0 || index >= List.Count)
				{
					throw new IndexOutOfRangeException(SR.GetString("ListManagerNoValue", index.ToString(CultureInfo.CurrentCulture)));
				}
				List[index] = value;
			}
		}

		/// Gets the list for this <see cref="T:Gizmox.WebGUI.Forms.CurrencyManager"></see>.</summary>
		/// An <see cref="T:System.Collections.IList"></see> that contains the list.</returns>
		/// 1</filterpriority>
		public IList List
		{
			get
			{
				if (mobjList == null && mobjDataSource != null)
				{
					SetDataSourceInternal(mobjDataSource, blnUpdate: false);
				}
				return mobjList;
			}
		}

		/// Gets or sets the position you are at within the list.</summary>
		/// A number between 0 and <see cref="P:Gizmox.WebGUI.Forms.CurrencyManager.Count"></see> minus 1.</returns>
		/// 1</filterpriority>
		public override int Position
		{
			get
			{
				return listposition;
			}
			set
			{
				if (listposition != -1)
				{
					if (value < 0)
					{
						value = 0;
					}
					int count = List.Count;
					if (value >= count)
					{
						value = count - 1;
					}
					ChangeRecordState(value, listposition != value, blnEndCurrentEdit: true, blnFirePositionChange: true, blnPullData: false);
				}
			}
		}

		/// 
		/// Gets a value indicating whether [should bind].
		/// </summary>
		/// true</c> if [should bind]; otherwise, false</c>.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool ShouldBind => mblnShouldBind;

		/// Occurs when the current item has been altered.</summary>
		/// 1</filterpriority>
		[SRCategory("CatData")]
		public event ItemChangedEventHandler ItemChanged;

		/// Occurs when the list changes or an item in the list changes.</summary>
		/// 1</filterpriority>
		public event ListChangedEventHandler ListChanged;

		/// Occurs when the metadata of the <see cref="P:Gizmox.WebGUI.Forms.CurrencyManager.List"></see> has changed.</summary>
		/// 1</filterpriority>
		[SRCategory("CatData")]
		public event EventHandler MetaDataChanged;

		internal CurrencyManager(object objDataSource)
		{
			mblnShouldBind = true;
			listposition = -1;
			mintLastGoodKnownRow = -1;
			mobjResetEvent = new ItemChangedEventArgs(-1);
			SetDataSource(objDataSource);
		}

		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			marrSerializedDataViewNewRowValues = null;
			try
			{
				if (List != null && List.GetType() == typeof(DataView) && Position >= 0 && Position < List.Count && ((DataRowView)this[Position]).IsNew)
				{
					marrSerializedDataViewNewRowValues = ((DataRowView)this[Position]).Row.ItemArray;
				}
			}
			catch
			{
			}
			base.OnSerializableObjectSerializing(objWriter);
		}

		protected override void OnSerializableObjectDeserialized()
		{
			base.OnSerializableObjectDeserialized();
			if (marrSerializedDataViewNewRowValues != null)
			{
				object[] itemArray = marrSerializedDataViewNewRowValues;
				marrSerializedDataViewNewRowValues = null;
				UnwireEvents(List);
				if (List.GetType() == typeof(DataView))
				{
					DataRowView dataRowView = ((DataView)List).AddNew();
					dataRowView.Row.ItemArray = itemArray;
				}
				WireEvents(List);
				marrSerializedDataViewNewRowValues = null;
			}
		}

		/// Adds a new item to the underlying list.</summary>
		/// <exception cref="T:System.NotSupportedException">The underlying data source does not implement <see cref="T:System.ComponentModel.IBindingList"></see>, or the data source has thrown an exception because the user has attempted to add a row to a read-only or fixed-size <see cref="T:System.Data.DataView"></see>. </exception>
		/// 1</filterpriority>
		public override void AddNew()
		{
			if (!(List is IBindingList bindingList))
			{
				throw new NotSupportedException(SR.GetString("CurrencyManagerCantAddNew"));
			}
			bindingList.AddNew();
			ChangeRecordState(List.Count - 1, Position != List.Count - 1, Position != List.Count - 1, blnFirePositionChange: true, blnPullData: true);
		}

		/// Cancels the current edit operation.</summary>
		/// 1</filterpriority>
		public override void CancelCurrentEdit()
		{
			if (Count > 0)
			{
				object obj = ((Position >= 0 && Position < List.Count) ? List[Position] : null);
				if (obj is IEditableObject editableObject)
				{
					editableObject.CancelEdit();
				}
				if (!CommonUtils.IsMono && List is ICancelAddNew cancelAddNew)
				{
					cancelAddNew.CancelNew(Position);
				}
				OnItemChanged(new ItemChangedEventArgs(Position));
				if (Position != -1)
				{
					OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, Position));
				}
			}
		}

		private void ChangeRecordState(int intNewPosition, bool blnValidating, bool blnEndCurrentEdit, bool blnFirePositionChange, bool blnPullData)
		{
			if (intNewPosition == -1 && List.Count == 0)
			{
				if (listposition != -1)
				{
					listposition = -1;
					OnPositionChanged(EventArgs.Empty);
				}
				return;
			}
			if ((intNewPosition < 0 || intNewPosition >= Count) && IsBinding)
			{
				throw new IndexOutOfRangeException(SR.GetString("ListManagerBadPosition"));
			}
			int num = listposition;
			if (blnEndCurrentEdit)
			{
				mblnInChangeRecordState = true;
				try
				{
					EndCurrentEdit();
				}
				finally
				{
					mblnInChangeRecordState = false;
				}
			}
			if (blnValidating && blnPullData)
			{
				CurrencyManager_PullData();
			}
			listposition = Math.Min(intNewPosition, Count - 1);
			if (blnValidating)
			{
				OnCurrentChanged(EventArgs.Empty);
			}
			if (num != listposition && blnFirePositionChange)
			{
				OnPositionChanged(EventArgs.Empty);
			}
		}

		/// Throws an exception if there is no list, or the list is empty.</summary>
		/// <exception cref="T:System.Exception">There is no list, or the list is empty. </exception>
		protected void CheckEmpty()
		{
			if (mobjDataSource == null || List == null || List.Count == 0)
			{
				throw new InvalidOperationException(SR.GetString("ListManagerEmptyList"));
			}
		}

		private bool CurrencyManager_PullData()
		{
			bool blnSuccess = true;
			mblnPullingData = true;
			try
			{
				PullData(out blnSuccess);
			}
			finally
			{
				mblnPullingData = false;
			}
			return blnSuccess;
		}

		private bool CurrencyManager_PushData()
		{
			if (mblnPullingData)
			{
				return false;
			}
			int num = listposition;
			if (mintLastGoodKnownRow == -1)
			{
				try
				{
					PushData();
				}
				catch (Exception objException)
				{
					OnDataError(objException);
					FindGoodRow();
				}
				mintLastGoodKnownRow = listposition;
			}
			else
			{
				try
				{
					PushData();
				}
				catch (Exception objException2)
				{
					OnDataError(objException2);
					listposition = mintLastGoodKnownRow;
					PushData();
				}
				mintLastGoodKnownRow = listposition;
			}
			return num != listposition;
		}

		/// Ends the current edit operation.</summary>
		/// 1</filterpriority>
		public override void EndCurrentEdit()
		{
			if (Count > 0 && CurrencyManager_PullData())
			{
				object obj = ((Position >= 0 && Position < List.Count) ? List[Position] : null);
				if (obj is IEditableObject editableObject)
				{
					editableObject.EndEdit();
				}
				if (!CommonUtils.IsMono && List is ICancelAddNew cancelAddNew)
				{
					cancelAddNew.EndNew(Position);
				}
			}
		}

		internal int Find(PropertyDescriptor objPropertyDescriptor, object objKey, bool blnKeepIndex)
		{
			if (objKey == null)
			{
				throw new ArgumentNullException("key");
			}
			if (objPropertyDescriptor != null && List is IBindingList && ((IBindingList)List).SupportsSearching)
			{
				return ((IBindingList)List).Find(objPropertyDescriptor, objKey);
			}
			for (int i = 0; i < List.Count; i++)
			{
				object value = objPropertyDescriptor.GetValue(List[i]);
				if (objKey.Equals(value))
				{
					return i;
				}
			}
			return -1;
		}

		private void FindGoodRow()
		{
			int count = List.Count;
			for (int i = 0; i < count; i++)
			{
				listposition = i;
				try
				{
					PushData();
				}
				catch (Exception objException)
				{
					OnDataError(objException);
					continue;
				}
				listposition = i;
				return;
			}
			SuspendBinding();
			throw new InvalidOperationException(SR.GetString("DataBindingPushDataException"));
		}

		/// Gets the property descriptor collection for the underlying list.</summary>
		/// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> for the list.</returns>
		/// 1</filterpriority>
		public override PropertyDescriptorCollection GetItemProperties()
		{
			return GetItemProperties(null);
		}

		internal override PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] arrListAccessors)
		{
			return ListBindingHelper.GetListItemProperties(List, arrListAccessors);
		}

		internal override string GetListName()
		{
			if (List is ITypedList)
			{
				return ((ITypedList)List).GetListName(null);
			}
			return finalType.Name;
		}

		/// Gets the name of the list supplying the data for the binding using the specified set of bound properties.</summary>
		/// If successful, a <see cref="T:System.String"></see> containing name of the list supplying the data for the binding; otherwise, an <see cref="F:System.String.Empty"></see> string.</returns>
		/// <param name="objListAccessors">An <see cref="T:System.Collections.ArrayList"></see> of properties to be found in the data source.</param>
		protected internal override string GetListName(ArrayList objListAccessors)
		{
			if (List is ITypedList)
			{
				PropertyDescriptor[] array = new PropertyDescriptor[objListAccessors.Count];
				objListAccessors.CopyTo(array, 0);
				return ((ITypedList)List).GetListName(array);
			}
			return "";
		}

		internal ListSortDirection GetSortDirection()
		{
			if (List is IBindingList && ((IBindingList)List).SupportsSorting)
			{
				return ((IBindingList)List).SortDirection;
			}
			return ListSortDirection.Ascending;
		}

		internal PropertyDescriptor GetSortProperty()
		{
			if (List is IBindingList && ((IBindingList)List).SupportsSorting)
			{
				return ((IBindingList)List).SortProperty;
			}
			return null;
		}

		private void List_ListChanged(object sender, ListChangedEventArgs e)
		{
			ListChangedEventArgs e2 = ((e.ListChangedType == ListChangedType.ItemMoved && e.OldIndex < 0) ? new ListChangedEventArgs(ListChangedType.ItemAdded, e.NewIndex, e.OldIndex) : ((e.ListChangedType != ListChangedType.ItemMoved || e.NewIndex >= 0) ? e : new ListChangedEventArgs(ListChangedType.ItemDeleted, e.OldIndex, e.NewIndex)));
			int num = listposition;
			UpdateLastGoodKnownRow(e2);
			UpdateIsBinding();
			if (List.Count == 0)
			{
				listposition = -1;
				if (num != -1)
				{
					OnPositionChanged(EventArgs.Empty);
					OnCurrentChanged(EventArgs.Empty);
				}
				if (e2.ListChangedType == ListChangedType.Reset && e.NewIndex == -1)
				{
					OnItemChanged(mobjResetEvent);
				}
				if (e2.ListChangedType == ListChangedType.ItemDeleted)
				{
					OnItemChanged(mobjResetEvent);
				}
				if (e.ListChangedType == ListChangedType.PropertyDescriptorAdded || e.ListChangedType == ListChangedType.PropertyDescriptorDeleted || e.ListChangedType == ListChangedType.PropertyDescriptorChanged)
				{
					OnMetaDataChanged(EventArgs.Empty);
				}
				OnListChanged(e2);
				return;
			}
			mblnSuspendPushDataInCurrentChanged = true;
			try
			{
				switch (e2.ListChangedType)
				{
				case ListChangedType.Reset:
					if (listposition == -1 && List.Count > 0)
					{
						ChangeRecordState(0, blnValidating: true, blnEndCurrentEdit: false, blnFirePositionChange: true, blnPullData: false);
					}
					else
					{
						ChangeRecordState(Math.Min(listposition, List.Count - 1), blnValidating: true, blnEndCurrentEdit: false, blnFirePositionChange: true, blnPullData: false);
					}
					UpdateIsBinding(blnRaiseItemChangedEvent: false);
					OnItemChanged(mobjResetEvent);
					break;
				case ListChangedType.ItemAdded:
					if (e2.NewIndex <= listposition && listposition < List.Count - 1)
					{
						ChangeRecordState(listposition + 1, blnValidating: true, blnEndCurrentEdit: true, listposition != List.Count - 2, blnPullData: false);
						UpdateIsBinding();
						OnItemChanged(mobjResetEvent);
						if (listposition == List.Count - 1)
						{
							OnPositionChanged(EventArgs.Empty);
						}
						break;
					}
					if (e2.NewIndex == listposition && listposition == List.Count - 1 && listposition != -1)
					{
						OnCurrentItemChanged(EventArgs.Empty);
					}
					if (listposition == -1)
					{
						ChangeRecordState(0, blnValidating: false, blnEndCurrentEdit: false, blnFirePositionChange: true, blnPullData: false);
					}
					UpdateIsBinding();
					OnItemChanged(mobjResetEvent);
					break;
				case ListChangedType.ItemDeleted:
					if (e2.NewIndex == listposition)
					{
						ChangeRecordState(Math.Min(listposition, Count - 1), blnValidating: true, blnEndCurrentEdit: false, blnFirePositionChange: true, blnPullData: false);
						OnItemChanged(mobjResetEvent);
					}
					else if (e2.NewIndex < listposition)
					{
						ChangeRecordState(listposition - 1, blnValidating: true, blnEndCurrentEdit: false, blnFirePositionChange: true, blnPullData: false);
						OnItemChanged(mobjResetEvent);
					}
					else
					{
						OnItemChanged(mobjResetEvent);
					}
					break;
				case ListChangedType.ItemMoved:
					if (e2.OldIndex == listposition)
					{
						ChangeRecordState(e2.NewIndex, blnValidating: true, Position > -1 && Position < List.Count, blnFirePositionChange: true, blnPullData: false);
					}
					else if (e2.NewIndex == listposition)
					{
						ChangeRecordState(e2.OldIndex, blnValidating: true, Position > -1 && Position < List.Count, blnFirePositionChange: true, blnPullData: false);
					}
					OnItemChanged(mobjResetEvent);
					break;
				case ListChangedType.ItemChanged:
					if (e2.NewIndex == listposition)
					{
						OnCurrentItemChanged(EventArgs.Empty);
					}
					OnItemChanged(new ItemChangedEventArgs(e2.NewIndex));
					break;
				case ListChangedType.PropertyDescriptorAdded:
				case ListChangedType.PropertyDescriptorDeleted:
				case ListChangedType.PropertyDescriptorChanged:
					mintLastGoodKnownRow = -1;
					if (listposition == -1 && List.Count > 0)
					{
						ChangeRecordState(0, blnValidating: true, blnEndCurrentEdit: false, blnFirePositionChange: true, blnPullData: false);
					}
					else if (listposition > List.Count - 1)
					{
						ChangeRecordState(List.Count - 1, blnValidating: true, blnEndCurrentEdit: false, blnFirePositionChange: true, blnPullData: false);
					}
					OnMetaDataChanged(EventArgs.Empty);
					break;
				}
				OnListChanged(e2);
			}
			finally
			{
				mblnSuspendPushDataInCurrentChanged = false;
			}
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.CurrentChanged"></see> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected internal override void OnCurrentChanged(EventArgs e)
		{
			if (mblnInChangeRecordState)
			{
				return;
			}
			int num = mintLastGoodKnownRow;
			bool flag = false;
			if (!mblnSuspendPushDataInCurrentChanged)
			{
				flag = CurrencyManager_PushData();
			}
			if (Count > 0)
			{
				object obj = List[Position];
				if (obj is IEditableObject)
				{
					((IEditableObject)obj).BeginEdit();
				}
			}
			try
			{
				if (!flag || (flag && num != -1))
				{
					FireCurrentChanged(this, e);
					FireCurrentItemChanged(this, e);
				}
			}
			catch (Exception objException)
			{
				OnDataError(objException);
			}
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.CurrentItemChanged"></see> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected internal override void OnCurrentItemChanged(EventArgs e)
		{
			FireCurrentItemChanged(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.CurrencyManager.ItemChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.ItemChangedEventArgs"></see> that contains the event data. </param>
		protected virtual void OnItemChanged(ItemChangedEventArgs e)
		{
			bool flag = false;
			if ((e.Index == listposition || (e.Index == -1 && Position < Count)) && !mblnInChangeRecordState)
			{
				flag = CurrencyManager_PushData();
			}
			try
			{
				this.ItemChanged?.Invoke(this, e);
			}
			catch (Exception objException)
			{
				OnDataError(objException);
			}
			if (flag)
			{
				OnPositionChanged(EventArgs.Empty);
			}
		}

		private void OnListChanged(ListChangedEventArgs e)
		{
			this.ListChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.CurrencyManager.MetaDataChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected internal void OnMetaDataChanged(EventArgs e)
		{
			this.MetaDataChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.BindingManagerBase.PositionChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnPositionChanged(EventArgs e)
		{
			try
			{
				FirePositionChanged(this, e);
			}
			catch (Exception objException)
			{
				OnDataError(objException);
			}
		}

		/// Forces a repopulation of the data-bound list.</summary>
		/// 1</filterpriority>
		public void Refresh()
		{
			if (List.Count > 0)
			{
				if (listposition >= List.Count)
				{
					mintLastGoodKnownRow = -1;
					listposition = 0;
				}
			}
			else
			{
				listposition = -1;
			}
			List_ListChanged(List, new ListChangedEventArgs(ListChangedType.Reset, -1));
		}

		internal void Release()
		{
			UnwireEvents(List);
		}

		/// Removes the item at the specified index.</summary>
		/// <param name="index">The index of the item to remove from the list. </param>
		/// <exception cref="T:System.IndexOutOfRangeException">There is no row at the specified index. </exception>
		/// 1</filterpriority>
		public override void RemoveAt(int index)
		{
			List.RemoveAt(index);
		}

		/// Resumes data binding.</summary>
		/// 1</filterpriority>
		public override void ResumeBinding()
		{
			mintLastGoodKnownRow = -1;
			try
			{
				if (!mblnShouldBind)
				{
					mblnShouldBind = true;
					listposition = ((List == null || List.Count == 0) ? (-1) : 0);
					UpdateIsBinding();
				}
			}
			catch
			{
				mblnShouldBind = false;
				UpdateIsBinding();
				throw;
			}
		}

		/// 
		/// Sets the data source.
		/// </summary>
		/// <param name="objDataSource">The obj data source.</param>
		internal override void SetDataSource(object objDataSource)
		{
			if (mobjDataSource != objDataSource)
			{
				Release();
				mobjDataSource = objDataSource;
				mobjList = null;
				finalType = null;
				SetDataSourceInternal(objDataSource, blnUpdate: true);
			}
		}

		/// 
		/// Sets the data source internal.
		/// </summary>
		/// <param name="objDataSource">The obj data source.</param>
		/// <param name="blnUpdate">if set to true</c> [BLN update].</param>
		private void SetDataSourceInternal(object objDataSource, bool blnUpdate)
		{
			object obj = objDataSource;
			if (obj is Array)
			{
				finalType = obj.GetType();
				obj = (Array)obj;
			}
			if (obj is IListSource)
			{
				obj = ((IListSource)obj).GetList();
			}
			if (obj is IList)
			{
				if (finalType == null)
				{
					finalType = obj.GetType();
				}
				mobjList = (IList)obj;
				WireEvents(mobjList);
				if (blnUpdate)
				{
					if (mobjList.Count > 0)
					{
						listposition = 0;
					}
					else
					{
						listposition = -1;
					}
					OnItemChanged(mobjResetEvent);
					OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1, -1));
					UpdateIsBinding();
				}
				return;
			}
			if (obj == null)
			{
				throw new ArgumentNullException("dataSource");
			}
			throw new ArgumentException(SR.GetString("ListManagerSetDataSource", obj.GetType().FullName), "dataSource");
		}

		internal void SetSort(PropertyDescriptor objPropertyDescriptor, ListSortDirection sortDirection)
		{
			if (List is IBindingList && ((IBindingList)List).SupportsSorting)
			{
				((IBindingList)List).ApplySort(objPropertyDescriptor, sortDirection);
			}
		}

		/// Suspends data binding to prevents changes from updating the bound data source.</summary>
		/// 1</filterpriority>
		public override void SuspendBinding()
		{
			mintLastGoodKnownRow = -1;
			if (mblnShouldBind)
			{
				mblnShouldBind = false;
				UpdateIsBinding();
			}
		}

		internal void UnwireEvents(IList objList)
		{
			if (objList is IBindingList && ((IBindingList)objList).SupportsChangeNotification)
			{
				((IBindingList)objList).ListChanged -= List_ListChanged;
			}
		}

		/// Updates the status of the binding.</summary>
		protected override void UpdateIsBinding()
		{
			UpdateIsBinding(blnRaiseItemChangedEvent: true);
		}

		private void UpdateIsBinding(bool blnRaiseItemChangedEvent)
		{
			bool flag = List != null && List.Count > 0 && mblnShouldBind && listposition != -1;
			if (List != null && mblnBound != flag)
			{
				mblnBound = flag;
				int num = ((!flag) ? (-1) : 0);
				ChangeRecordState(num, mblnBound, Position != num, blnFirePositionChange: true, blnPullData: false);
				int count = base.Bindings.Count;
				for (int i = 0; i < count; i++)
				{
					base.Bindings[i].UpdateIsBinding();
				}
				if (blnRaiseItemChangedEvent)
				{
					OnItemChanged(mobjResetEvent);
				}
			}
		}

		private void UpdateLastGoodKnownRow(ListChangedEventArgs e)
		{
			switch (e.ListChangedType)
			{
			case ListChangedType.Reset:
				mintLastGoodKnownRow = -1;
				break;
			case ListChangedType.ItemAdded:
				if (e.NewIndex <= mintLastGoodKnownRow && mintLastGoodKnownRow < List.Count - 1)
				{
					mintLastGoodKnownRow++;
				}
				break;
			case ListChangedType.ItemDeleted:
				if (e.NewIndex == mintLastGoodKnownRow)
				{
					mintLastGoodKnownRow = -1;
				}
				break;
			case ListChangedType.ItemMoved:
				if (e.OldIndex == mintLastGoodKnownRow)
				{
					mintLastGoodKnownRow = e.NewIndex;
				}
				break;
			case ListChangedType.ItemChanged:
				if (e.NewIndex == mintLastGoodKnownRow)
				{
					mintLastGoodKnownRow = -1;
				}
				break;
			}
		}

		internal void WireEvents(IList objList)
		{
			if (objList is IBindingList && ((IBindingList)objList).SupportsChangeNotification)
			{
				((IBindingList)objList).ListChanged += List_ListChanged;
			}
		}
	}
}
