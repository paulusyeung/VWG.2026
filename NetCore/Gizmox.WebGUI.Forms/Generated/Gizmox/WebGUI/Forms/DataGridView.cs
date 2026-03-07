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
	/// Displays data in a customizable grid.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(DataGridView), "DataGridView_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGridViewController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.DataGridViewController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ComplexBindingProperties("DataSource", "DataMember")]
	[Editor("System.Windows.Forms.Design.DataGridViewComponentEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(ComponentEditor))]
	[SRDescription("DescriptionDataGridView")]
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.AutoDispatch)]
	[ToolboxItemCategory("Data")]
	[MetadataTag("DG")]
	[Skin(typeof(DataGridViewSkin))]
	public class DataGridView : Control, ISupportInitialize
	{
		[Serializable]
		internal enum DataGridViewValidateCellInternal
		{
			Never,
			Always,
			WhenChanged
		}

		/// 
		/// Represents DataGridView aspect flags that have to be updated with awareness.
		/// </summary>
		[Serializable]
		internal enum PreRenderUpdateType
		{
			/// 
			///  Nothing to update
			/// </summary>
			None = 0,
			/// 
			/// GroupingData changed and has to be updated
			/// </summary>
			GroupingData = 1,
			/// 
			/// FilterRow has to be updated
			/// </summary>
			FilterRow = 2,
			/// 
			/// GroupHeaders have to be rebuilt
			/// </summary>
			GroupHeaders = 4
		}

		/// 
		///
		/// </summary>
		[Serializable]
		private class DataGridRowBlockInfo
		{
			/// 
			///
			/// </summary>
			private bool mblnIsLoaded = false;

			/// 
			/// Gets or sets the last modified.
			/// </summary>
			/// The last modified.</value>
			private long mlngLastModified;

			/// 
			///
			/// </summary>
			private DataGridViewBlocksManager mobjManager;

			/// 
			/// Gets the last modified.
			/// </summary>
			/// The last modified.</value>
			public long LastModified => mlngLastModified;

			/// 
			/// Gets a value indicating whether this instance is loaded.
			/// </summary>
			/// true</c> if this instance is loaded; otherwise, false</c>.</value>
			public bool IsLoaded => mblnIsLoaded;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView.DataGridRowBlockInfo" /> class.
			/// </summary>
			/// <param name="objManager">The manager.</param>
			public DataGridRowBlockInfo(DataGridViewBlocksManager objManager)
			{
				mobjManager = objManager;
				mlngLastModified = mobjManager.GetDataGridLastModified();
			}

			/// 
			/// Loads the rows.
			/// </summary>
			public void LoadRows()
			{
				if (!mblnIsLoaded)
				{
					mblnIsLoaded = true;
				}
			}

			/// 
			/// Updates this block.
			/// </summary>
			internal void Update()
			{
				mlngLastModified = mobjManager.GetCurrentTicks();
			}

			/// 
			/// Determines whether the specified block is dirty.
			/// </summary>
			/// <param name="lngRequestID">Request ID.</param>
			/// 
			/// 	true</c> if the specified block is dirty; otherwise, false</c>.
			/// </returns>
			internal bool IsDirty(long lngRequestID)
			{
				return LastModified > lngRequestID;
			}
		}

		/// 
		///
		/// </summary>
		[Serializable]
		private class DataGridViewBlocksManager
		{
			/// 
			///
			/// </summary>
			private readonly DataGridView mobjDataGridView;

			/// 
			///
			/// </summary>
			private readonly Dictionary<int, DataGridRowBlockInfo> mobjRowBlockInfos = new Dictionary<int, DataGridRowBlockInfo>();

			/// 
			/// Initializes a new instance of the <see cref="!:DataGridRowBlockManager" /> class.
			/// </summary>
			/// <param name="objDataGridView">The data grid view.</param>
			public DataGridViewBlocksManager(DataGridView objDataGridView)
			{
				mobjDataGridView = objDataGridView;
			}

			/// 
			/// Gets the block info.
			/// </summary>
			/// <param name="intBlockId">The int block id.</param>
			/// </returns>
			public DataGridRowBlockInfo GetBlockInfo(int intBlockId)
			{
				DataGridRowBlockInfo value = null;
				if (!mobjRowBlockInfos.TryGetValue(intBlockId, out value))
				{
					value = (mobjRowBlockInfos[intBlockId] = new DataGridRowBlockInfo(this));
				}
				return value;
			}

			/// 
			/// Gets the block info.
			/// </summary>
			/// <param name="objBlock">The block.</param>
			/// </returns>
			public DataGridRowBlockInfo GetBlockInfo(DataGridRowBlock objBlock)
			{
				DataGridRowBlockInfo result = null;
				if (objBlock != null)
				{
					result = GetBlockInfo(objBlock.BlockId);
				}
				return result;
			}

			/// 
			/// Gets the current ticks.
			/// </summary>
			/// </returns>
			internal long GetCurrentTicks()
			{
				return mobjDataGridView.GetCurrentTicks();
			}

			/// 
			/// Clears the block info cache.
			/// </summary>
			internal void ClearBlockInfoCache()
			{
				mobjRowBlockInfos.Clear();
			}

			/// 
			/// Gets the data grid last modified.
			/// </summary>
			/// </returns>
			internal long GetDataGridLastModified()
			{
				return mobjDataGridView.GetLastModified();
			}
		}

		/// 
		///
		/// </summary>
		[Serializable]
		private class DataGridRowBlock : IEnumerable
		{
			/// 
			///
			/// </summary>
			private int mintBlockHeight = -1;

			/// 
			///
			/// </summary>
			private readonly int mintBlockId = 0;

			/// 
			///
			/// </summary>
			private DataGridRowBlockInfo mobjBlockInfo = null;

			/// 
			///
			/// </summary>
			private readonly IList mobjBlockRows = null;

			/// 
			///
			/// </summary>
			private readonly DataGridView mobjDataGrid = null;

			/// 
			///
			/// </summary>
			private readonly bool mblnContainsFrozenRows = false;

			/// 
			/// Gets the height of the block.
			/// </summary>
			/// The height of the block.</value>
			internal int BlockHeight
			{
				get
				{
					if (mintBlockHeight == -1)
					{
						int num = 0;
						foreach (DataGridViewRow item in (IEnumerable)this)
						{
							if (!item.Frozen)
							{
								num += item.Height;
								if (item.Expanded && mobjDataGrid.IsHierarchic(HierarchicInfoSelector.Bounded))
								{
									num += item.ChildGrid.Height;
								}
							}
						}
						mintBlockHeight = num;
					}
					return mintBlockHeight;
				}
			}

			/// 
			/// Gets the block id.
			/// </summary>
			/// The block id.</value>
			public int BlockId => mintBlockId;

			/// 
			/// Gets the block info.
			/// </summary>
			/// The block info.</value>
			public DataGridRowBlockInfo BlockInfo
			{
				get
				{
					if (mobjBlockInfo == null)
					{
						mobjBlockInfo = mobjDataGrid.GetBlockInfo(this);
					}
					return mobjBlockInfo;
				}
			}

			/// 
			/// Gets a value indicating whether [contains frozen rows].
			/// </summary>
			/// true</c> if [contains frozen rows]; otherwise, false</c>.</value>
			public bool ContainsFrozenRows => mblnContainsFrozenRows;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView.DataGridRowBlock" /> class.
			/// </summary>
			/// <param name="objBlockRows">The block rows.</param>
			/// <param name="intBlockId">The block id.</param>
			public DataGridRowBlock(DataGridView objDataGrid, IList objBlockRows, int intBlockId, bool blnContainsFrozenRows)
			{
				mobjBlockRows = objBlockRows;
				mintBlockId = intBlockId;
				mobjDataGrid = objDataGrid;
				mblnContainsFrozenRows = blnContainsFrozenRows;
			}

			/// 
			/// Renders the row block
			/// </summary>
			/// <param name="objContext">The context.</param>
			/// <param name="objWriter">The writer.</param>
			/// <param name="lngRequestID">The request ID.</param>
			/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
			/// <param name="blnFullRender">if set to true</c> [BLN full render].</param>
			/// <param name="intTopPosition">The block's top position.</param>
			/// <param name="intGridScrollTop">The grid scroll top.</param>
			/// <param name="intGridHeight">Height of the grid.</param>
			public void RenderBlock(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner, bool blnFullRender, int intTopPosition, int intGridScrollTop, int intGridHeight)
			{
				DataGridRowBlockInfo blockInfo = BlockInfo;
				if (blockInfo == null)
				{
					return;
				}
				int blockHeight = BlockHeight;
				int num = intTopPosition + blockHeight;
				int num2 = intGridScrollTop + intGridHeight;
				bool flag = blockInfo.IsDirty(lngRequestID);
				bool flag2 = blockInfo.IsLoaded || ContainsFrozenRows;
				if (blnFullRender && !flag2)
				{
					if (intTopPosition >= intGridScrollTop && intTopPosition < num2)
					{
						flag2 = true;
					}
					else if (num > intGridScrollTop && num <= num2)
					{
						flag2 = true;
					}
					else if (intTopPosition <= intGridScrollTop && num >= num2)
					{
						flag2 = true;
					}
					if (flag2)
					{
						blockInfo.LoadRows();
					}
				}
				if (blnFullRender || flag)
				{
					objWriter.WriteStartElement(WGConst.Prefix, "DGVB", WGConst.Namespace);
					objWriter.WriteAttributeString("mId", string.Format("{0}{1}", "DGVB", mintBlockId.ToString()));
					objWriter.WriteAttributeString("oId", mobjDataGrid.ID.ToString());
					objWriter.WriteAttributeString("H", blockHeight.ToString());
					objWriter.WriteAttributeString("LO", flag2 ? "1" : "0");
					if (flag2)
					{
						objWriter.WriteAttributeString("V", "1");
						RenderBlockRows(objContext, objWriter, lngRequestID, blnRenderOwner, flag);
					}
					objWriter.WriteEndElement();
				}
				else
				{
					RenderBlockRows(objContext, objWriter, lngRequestID, blnRenderOwner, flag);
				}
			}

			/// 
			///  Render the block's rows.
			/// </summary>
			/// <param name="objContext"></param>
			/// <param name="objWriter"></param>
			/// <param name="lngRequestID"></param>
			/// <param name="blnRenderOwner"></param>
			/// <param name="blnIsDirtyBlock"></param>
			private void RenderBlockRows(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner, bool blnIsDirtyBlock)
			{
				foreach (DataGridViewRow item in (IEnumerable)this)
				{
					((IRenderableComponentMember)item).RenderComponent(objContext, objWriter, blnIsDirtyBlock ? 0 : lngRequestID, blnRenderOwner);
				}
			}

			/// 
			/// Returns an enumerator that iterates through a collection.
			/// </summary>
			/// 
			/// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
			/// </returns>
			IEnumerator IEnumerable.GetEnumerator()
			{
				return mobjBlockRows.GetEnumerator();
			}
		}

		[Serializable]
		internal class DataGridViewDataConnection : SerializableObject
		{
			private string mstrDataMember;

			private CurrencyManager mobjCurrencyManager = null;

			private int mintLastListCount;

			[NonSerialized]
			private PropertyDescriptorCollection mobjProps = null;

			private const int DATACONNECTIONSTATE_cachedAllowUserToAddRowsInternal = 65536;

			private const int DATACONNECTIONSTATE_cancellingRowEdit = 64;

			private const int DATACONNECTIONSTATE_dataConnection_inSetDataConnection = 1;

			private const int DATACONNECTIONSTATE_dataSourceInitializedHookedUp = 262144;

			private const int DATACONNECTIONSTATE_didNotDeleteRowFromDataGridView = 8192;

			private const int DATACONNECTIONSTATE_doNotChangePositionInTheCurrencyManager = 16;

			private const int DATACONNECTIONSTATE_doNotChangePositionInTheDataGridViewControl = 8;

			private const int DATACONNECTIONSTATE_finishedAddNew = 4;

			private const int DATACONNECTIONSTATE_inAddNew = 512;

			private const int DATACONNECTIONSTATE_inDeleteOperation = 4096;

			private const int DATACONNECTIONSTATE_inEndCurrentEdit = 32768;

			private const int DATACONNECTIONSTATE_interestedInRowEvents = 32;

			private const int DATACONNECTIONSTATE_itemAddedInDeleteOperation = 16384;

			private const int DATACONNECTIONSTATE_listWasReset = 1024;

			private const int DATACONNECTIONSTATE_positionChangingInCurrencyManager = 2048;

			private const int DATACONNECTIONSTATE_processingListChangedEvent = 131072;

			private const int DATACONNECTIONSTATE_processingMetaDataChanges = 2;

			private const int DATACONNECTIONSTATE_restoreRow = 128;

			private const int DATACONNECTIONSTATE_rowValidatingInAddNew = 256;

			/// 
			/// Gets the state of the data connection.
			/// </summary>
			/// The state of the data connection.</value>
			private SerializableBitVector32 mobjDataConnectionState = default(SerializableBitVector32);

			private object mobjDataSource = null;

			private DataGridView mobjOwner = null;

			/// 
			/// Gets or sets the last list count.
			/// </summary>
			/// The last list count.</value>
			private int LastListCount
			{
				get
				{
					return mintLastListCount;
				}
				set
				{
					mintLastListCount = value;
				}
			}

			public bool AllowAdd
			{
				get
				{
					CurrencyManager currencyManager = CurrencyManager;
					if (currencyManager != null && currencyManager.List<object> is IBindingList && currencyManager.AllowAdd)
					{
						return ((IBindingList)currencyManager.List).SupportsChangeNotification;
					}
					return false;
				}
			}

			public bool AllowEdit => CurrencyManager?.AllowEdit ?? false;

			public bool AllowRemove
			{
				get
				{
					CurrencyManager currencyManager = CurrencyManager;
					if (currencyManager != null && currencyManager.List<object> is IBindingList && currencyManager.AllowRemove)
					{
						return ((IBindingList)currencyManager.List).SupportsChangeNotification;
					}
					return false;
				}
			}

			public bool CancellingRowEdit => mobjDataConnectionState[64];

			/// 
			/// Gets the currency manager.
			/// </summary>
			/// The currency manager.</value>
			public CurrencyManager CurrencyManager
			{
				get
				{
					return mobjCurrencyManager;
				}
				private set
				{
					mobjCurrencyManager = value;
				}
			}

			public string DataMember
			{
				get
				{
					return mstrDataMember;
				}
				private set
				{
					mstrDataMember = value;
				}
			}

			public object DataSource
			{
				get
				{
					return mobjDataSource;
				}
				private set
				{
					mobjDataSource = value;
				}
			}

			public bool DoNotChangePositionInTheCurrencyManager
			{
				get
				{
					return mobjDataConnectionState[16];
				}
				set
				{
					mobjDataConnectionState[16] = value;
				}
			}

			public bool InterestedInRowEvents => mobjDataConnectionState[32];

			public IList List => CurrencyManager?.List;

			public bool ListWasReset => mobjDataConnectionState[1024];

			public bool PositionChangingOutsideDataGridView
			{
				get
				{
					if (!mobjDataConnectionState[8])
					{
						return mobjDataConnectionState[2048];
					}
					return false;
				}
			}

			public bool ProcessingListChangedEvent => mobjDataConnectionState[131072];

			public bool ProcessingMetaDataChanges => mobjDataConnectionState[2];

			public bool RestoreRow => mobjDataConnectionState[128];

			/// 
			/// Gets or sets the owner.
			/// </summary>
			/// The owner.</value>
			private DataGridView Owner
			{
				get
				{
					return mobjOwner;
				}
				set
				{
					mobjOwner = value;
				}
			}

			/// 
			/// Gets or sets the props.
			/// </summary>
			/// The props.</value>
			private PropertyDescriptorCollection Props
			{
				get
				{
					if (mobjProps == null && CurrencyManager != null)
					{
						mobjProps = CurrencyManager.GetItemProperties();
					}
					return mobjProps;
				}
				set
				{
					mobjProps = value;
				}
			}

			internal void OnNewRowNeeded()
			{
				mobjDataConnectionState[8] = true;
				try
				{
					AddNew();
				}
				finally
				{
					mobjDataConnectionState[8] = false;
				}
			}

			internal void OnRowEnter(DataGridViewCellEventArgs e)
			{
				CurrencyManager currencyManager = CurrencyManager;
				if (mobjDataConnectionState[2] || !currencyManager.ShouldBind)
				{
					return;
				}
				mobjDataConnectionState[8] = true;
				try
				{
					if (e.RowIndex == Owner.NewRowIndex || mobjDataConnectionState[16] || currencyManager.Position == e.RowIndex)
					{
						return;
					}
					try
					{
						currencyManager.Position = e.RowIndex;
					}
					catch (Exception objException)
					{
						if (ClientUtils.IsCriticalException(objException))
						{
							throw;
						}
						DataGridViewCellCancelEventArgs e2 = new DataGridViewCellCancelEventArgs(e.ColumnIndex, e.RowIndex);
						ProcessException(objException, e2, beginEdit: false);
					}
					if (currencyManager.Current is IEditableObject editableObject)
					{
						editableObject.BeginEdit();
					}
				}
				finally
				{
					mobjDataConnectionState[8] = false;
				}
			}

			internal void OnRowValidating(DataGridViewCellCancelEventArgs e)
			{
				CurrencyManager currencyManager = CurrencyManager;
				if (!currencyManager.ShouldBind)
				{
					return;
				}
				DataGridView owner = Owner;
				if (!mobjDataConnectionState[4] && !owner.IsCurrentRowDirty)
				{
					if (!mobjDataConnectionState[64])
					{
						mobjDataConnectionState[8] = true;
						try
						{
							CancelRowEdit(blnRestoreRow: false, blnAddNewFinished: false);
						}
						finally
						{
							mobjDataConnectionState[8] = false;
						}
					}
				}
				else if (owner.IsCurrentRowDirty)
				{
					mobjDataConnectionState[256] = true;
					try
					{
						currencyManager.EndCurrentEdit();
					}
					catch (Exception objException)
					{
						if (ClientUtils.IsCriticalException(objException))
						{
							throw;
						}
						ProcessException(objException, e, beginEdit: true);
					}
					finally
					{
						mobjDataConnectionState[256] = false;
					}
				}
				mobjDataConnectionState[4] = true;
			}

			public bool ShouldChangeDataMember(object objNewDataSource)
			{
				DataGridView owner = Owner;
				if (owner.BindingContext == null)
				{
					return false;
				}
				if (objNewDataSource != null)
				{
					if (!(owner.BindingContext[objNewDataSource] is CurrencyManager currencyManager))
					{
						return false;
					}
					PropertyDescriptorCollection itemProperties = currencyManager.GetItemProperties();
					string dataMember = DataMember;
					if (dataMember.Length != 0 && itemProperties[dataMember] != null)
					{
						return false;
					}
				}
				return true;
			}

			public void Sort(DataGridViewColumn objDataGridViewColumn, ListSortDirection enmDirection)
			{
				((IBindingList)List).ApplySort(Props[objDataGridViewColumn.BoundColumnIndex], enmDirection);
			}

			private void UnWireEvents()
			{
				CurrencyManager currencyManager = CurrencyManager;
				if (currencyManager != null)
				{
					currencyManager.PositionChanged -= currencyManager_PositionChanged;
					currencyManager.ListChanged -= currencyManager_ListChanged;
					mobjDataConnectionState[32] = false;
				}
			}

			private void WireEvents()
			{
				CurrencyManager currencyManager = CurrencyManager;
				if (currencyManager != null)
				{
					currencyManager.PositionChanged += currencyManager_PositionChanged;
					currencyManager.ListChanged += currencyManager_ListChanged;
					mobjDataConnectionState[32] = true;
				}
			}

			public void ProcessException(Exception objException, DataGridViewCellCancelEventArgs e, bool beginEdit)
			{
				DataGridViewDataErrorEventArgs e2 = new DataGridViewDataErrorEventArgs(objException, e.ColumnIndex, e.RowIndex, DataGridViewDataErrorContexts.Commit);
				Owner.OnDataErrorInternal(e2);
				if (e2.ThrowException)
				{
					throw e2.Exception;
				}
				if (e2.Cancel)
				{
					e.Cancel = true;
					if (beginEdit && CurrencyManager.Current is IEditableObject editableObject)
					{
						editableObject.BeginEdit();
					}
				}
				else
				{
					CancelRowEdit(blnRestoreRow: false, blnAddNewFinished: false);
				}
			}

			private void ProcessListChanged(ListChangedEventArgs e)
			{
				CurrencyManager currencyManager = CurrencyManager;
				DataGridView owner = Owner;
				if (e.ListChangedType == ListChangedType.PropertyDescriptorAdded || e.ListChangedType == ListChangedType.PropertyDescriptorDeleted || e.ListChangedType == ListChangedType.PropertyDescriptorChanged)
				{
					mobjDataConnectionState[2] = true;
					try
					{
						DataSourceMetaDataChanged();
						return;
					}
					finally
					{
						mobjDataConnectionState[2] = false;
					}
				}
				if (mobjDataConnectionState[65536] != owner.AllowUserToAddRowsInternal)
				{
					mobjDataConnectionState[1024] = true;
					try
					{
						owner.RefreshRows(!owner.InSortOperation);
						owner.PushAllowUserToAddRows();
						return;
					}
					finally
					{
						ResetDataConnectionState();
					}
				}
				if (!mobjDataConnectionState[4] && owner.NewRowIndex == e.NewIndex)
				{
					if (e.ListChangedType == ListChangedType.ItemAdded)
					{
						if (mobjDataConnectionState[512] || mobjDataConnectionState[256])
						{
							return;
						}
						if (owner.Columns.Count > 0)
						{
							do
							{
								owner.NewRowIndex = -1;
								owner.AddNewRow(blnCreatedByEditing: false);
							}
							while (DataBoundRowsCount() < currencyManager.Count);
						}
						mobjDataConnectionState[4] = true;
						MatchCurrencyManagerPosition(blnScrollIntoView: true, blnClearSelection: true);
					}
					else
					{
						if (e.ListChangedType != ListChangedType.ItemDeleted)
						{
							return;
						}
						if (mobjDataConnectionState[64])
						{
							owner.PopulateNewRowWithDefaultValues();
							return;
						}
						if (mobjDataConnectionState[32768] || mobjDataConnectionState[512])
						{
							mobjDataConnectionState[1024] = true;
							try
							{
								owner.RefreshRows(!owner.InSortOperation);
								owner.PushAllowUserToAddRows();
								return;
							}
							finally
							{
								mobjDataConnectionState[1024] = false;
							}
						}
						if (mobjDataConnectionState[4096] && currencyManager.List.Count == 0)
						{
							AddNew();
						}
					}
					return;
				}
				if (e.ListChangedType == ListChangedType.ItemAdded && currencyManager.List.Count == (owner.AllowUserToAddRowsInternal ? (owner.Rows.Count - 1) : owner.Rows.Count))
				{
					if (mobjDataConnectionState[4096] && mobjDataConnectionState[8192])
					{
						mobjDataConnectionState[16384] = true;
					}
					return;
				}
				if (e.ListChangedType == ListChangedType.ItemDeleted)
				{
					if (mobjDataConnectionState[4096] && mobjDataConnectionState[16384] && mobjDataConnectionState[8192])
					{
						mobjDataConnectionState[16384] = false;
					}
					else
					{
						if (!mobjDataConnectionState[4] && mobjDataConnectionState[32768])
						{
							mobjDataConnectionState[1024] = true;
							try
							{
								owner.RefreshRows(!owner.InSortOperation);
								owner.PushAllowUserToAddRows();
								return;
							}
							finally
							{
								mobjDataConnectionState[1024] = false;
							}
						}
						if (currencyManager.List.Count == DataBoundRowsCount())
						{
							return;
						}
					}
				}
				mobjDataConnectionState[16] = true;
				try
				{
					switch (e.ListChangedType)
					{
					case ListChangedType.ItemDeleted:
						owner.Rows.RemoveAtInternal(e.NewIndex, blnForce: true);
						mobjDataConnectionState[8192] = false;
						break;
					case ListChangedType.ItemMoved:
					{
						int intLow = Math.Min(e.OldIndex, e.NewIndex);
						int intHigh = Math.Max(e.OldIndex, e.NewIndex);
						owner.InvalidateRows(intLow, intHigh);
						break;
					}
					case ListChangedType.Reset:
					{
						mobjDataConnectionState[1024] = true;
						bool visible = owner.Visible;
						try
						{
							owner.RefreshRows(!owner.InSortOperation);
							owner.PushAllowUserToAddRows();
							ApplySortingInformationFromBackEnd();
						}
						finally
						{
							ResetDataConnectionState();
							if (visible)
							{
								owner.Invalidate(blnInvalidateChildren: true);
							}
						}
						break;
					}
					case ListChangedType.ItemAdded:
						if (owner.NewRowIndex != -1 && e.NewIndex == owner.Rows.Count)
						{
							throw new InvalidOperationException();
						}
						owner.Rows.InsertInternal(e.NewIndex, owner.RowTemplateClone, blnForce: true);
						break;
					case ListChangedType.ItemChanged:
					{
						string text = null;
						if (!CommonUtils.IsMono && e.PropertyDescriptor != null)
						{
							text = e.PropertyDescriptor.Name;
						}
						for (int i = 0; i < owner.Columns.Count; i++)
						{
							DataGridViewColumn dataGridViewColumn = owner.Columns[i];
							if (!dataGridViewColumn.Visible || !dataGridViewColumn.IsDataBound)
							{
								continue;
							}
							if (!CommonUtils.IsNullOrEmpty(text))
							{
								if (string.Compare(dataGridViewColumn.DataPropertyName, text, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
								{
									owner.OnCellCommonChange(i, e.NewIndex);
								}
							}
							else
							{
								owner.OnCellCommonChange(i, e.NewIndex);
							}
						}
						if (owner.CurrentCellAddress.Y == e.NewIndex && owner.IsCurrentCellInEditMode)
						{
							owner.RefreshEdit();
						}
						break;
					}
					}
					if (owner.Rows.Count > 0 && !mobjDataConnectionState[8] && !owner.InSortOperation)
					{
						MatchCurrencyManagerPosition(blnScrollIntoView: false, e.ListChangedType == ListChangedType.Reset);
					}
				}
				finally
				{
					mobjDataConnectionState[16] = false;
				}
			}

			public bool PushValue(int intBoundColumnIndex, int intColumnIndex, int intRowIndex, object objValue)
			{
				try
				{
					if (objValue != null)
					{
						DataGridView owner = Owner;
						Type type = objValue.GetType();
						Type valueType = owner.Columns[intColumnIndex].ValueType;
						if (!valueType.IsAssignableFrom(type))
						{
							TypeConverter typeConverter = BoundColumnConverter(intBoundColumnIndex);
							if (typeConverter != null && typeConverter.CanConvertFrom(type))
							{
								objValue = typeConverter.ConvertFrom(objValue);
							}
							else
							{
								TypeConverter cachedTypeConverter = owner.GetCachedTypeConverter(type);
								if (cachedTypeConverter != null && cachedTypeConverter.CanConvertTo(valueType))
								{
									objValue = cachedTypeConverter.ConvertTo(objValue, valueType);
								}
							}
						}
					}
					Props[intBoundColumnIndex].SetValue(CurrencyManager[intRowIndex], objValue);
				}
				catch (Exception objException)
				{
					if (ClientUtils.IsCriticalException(objException))
					{
						throw;
					}
					DataGridViewCellCancelEventArgs e = new DataGridViewCellCancelEventArgs(intColumnIndex, intRowIndex);
					ProcessException(objException, e, beginEdit: false);
					return !e.Cancel;
				}
				return true;
			}

			public void ResetCachedAllowUserToAddRowsInternal()
			{
				mobjDataConnectionState[65536] = Owner.AllowUserToAddRowsInternal;
			}

			private void ResetDataConnectionState()
			{
				mobjDataConnectionState = new SerializableBitVector32(4);
				if (CurrencyManager != null)
				{
					mobjDataConnectionState[32] = true;
				}
				ResetCachedAllowUserToAddRowsInternal();
			}

			public void SetDataConnection(object objDataSource, string strDataMember)
			{
				CurrencyManager currencyManager = CurrencyManager;
				if (mobjDataConnectionState[1])
				{
					return;
				}
				ResetDataConnectionState();
				if (strDataMember == null)
				{
					strDataMember = string.Empty;
				}
				object dataSource = DataSource;
				if (dataSource is ISupportInitializeNotification supportInitializeNotification && mobjDataConnectionState[262144])
				{
					supportInitializeNotification.Initialized -= DataSource_Initialized;
					mobjDataConnectionState[262144] = false;
				}
				dataSource = (DataSource = objDataSource);
				DataMember = strDataMember;
				DataGridView owner = Owner;
				if (owner.BindingContext == null)
				{
					return;
				}
				mobjDataConnectionState[1] = true;
				try
				{
					UnWireEvents();
					if (dataSource == null || owner.BindingContext == null || dataSource == Convert.DBNull)
					{
						currencyManager = (CurrencyManager = null);
					}
					else if (dataSource is ISupportInitializeNotification { IsInitialized: false } supportInitializeNotification2)
					{
						if (!mobjDataConnectionState[262144])
						{
							supportInitializeNotification2.Initialized += DataSource_Initialized;
							mobjDataConnectionState[262144] = true;
						}
						currencyManager = (CurrencyManager = null);
					}
					else
					{
						currencyManager = (CurrencyManager = owner.BindingContext[dataSource, DataMember] as CurrencyManager);
					}
					WireEvents();
					if (currencyManager != null)
					{
						Props = currencyManager.GetItemProperties();
					}
					else
					{
						Props = null;
					}
				}
				finally
				{
					mobjDataConnectionState[1] = false;
				}
				ResetCachedAllowUserToAddRowsInternal();
				if (currencyManager != null)
				{
					LastListCount = currencyManager.Count;
				}
				else
				{
					LastListCount = -1;
				}
			}

			public void AddNew()
			{
				CurrencyManager currencyManager = CurrencyManager;
				if (currencyManager != null && currencyManager.ShouldBind)
				{
					mobjDataConnectionState[4] = false;
					mobjDataConnectionState[32768] = true;
					try
					{
						currencyManager.EndCurrentEdit();
					}
					finally
					{
						mobjDataConnectionState[32768] = false;
					}
					mobjDataConnectionState[512] = true;
					try
					{
						currencyManager.AddNew();
					}
					finally
					{
						mobjDataConnectionState[512] = false;
					}
				}
			}

			public void ApplySortingInformationFromBackEnd()
			{
				if (CurrencyManager == null)
				{
					return;
				}
				PropertyDescriptor sortProperty = null;
				DataGridView owner = Owner;
				GetSortingInformationFromBackend(out sortProperty, out var objSortOrder);
				if (sortProperty == null)
				{
					for (int i = 0; i < owner.Columns.Count; i++)
					{
						if (owner.Columns[i].IsDataBound)
						{
							owner.Columns[i].HeaderCell.SortGlyphDirection = SortOrder.None;
						}
					}
					owner.SortedColumn = null;
					owner.SortOrder = SortOrder.None;
					return;
				}
				bool flag = false;
				for (int j = 0; j < owner.Columns.Count; j++)
				{
					DataGridViewColumn dataGridViewColumn = owner.Columns[j];
					if (!dataGridViewColumn.IsDataBound || dataGridViewColumn.SortMode == DataGridViewColumnSortMode.NotSortable)
					{
						continue;
					}
					if (ClientUtils.IsEquals(dataGridViewColumn.DataPropertyName, sortProperty.Name, StringComparison.OrdinalIgnoreCase))
					{
						if (!flag && !owner.InSortOperation)
						{
							owner.SortedColumn = dataGridViewColumn;
							owner.SortOrder = objSortOrder;
							flag = true;
						}
						dataGridViewColumn.HeaderCell.SortGlyphDirection = objSortOrder;
					}
					else
					{
						dataGridViewColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
					}
				}
			}

			public TypeConverter BoundColumnConverter(int intBoundColumnIndex)
			{
				return Props[intBoundColumnIndex].Converter;
			}

			public int BoundColumnIndex(string strDataPropertyName)
			{
				PropertyDescriptorCollection props = Props;
				if (props == null)
				{
					return -1;
				}
				int result = -1;
				for (int i = 0; i < props.Count; i++)
				{
					if (string.Compare(props[i].Name, strDataPropertyName, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
					{
						return i;
					}
				}
				return result;
			}

			public SortOrder BoundColumnSortOrder(int intBoundColumnIndex)
			{
				CurrencyManager currencyManager = CurrencyManager;
				IBindingList bindingList = ((currencyManager != null) ? (currencyManager.List<object> as IBindingList) : null);
				if (bindingList != null && bindingList.SupportsSorting && bindingList.IsSorted)
				{
					GetSortingInformationFromBackend(out var sortProperty, out var objSortOrder);
					if (objSortOrder != SortOrder.None && string.Compare(Props[intBoundColumnIndex].Name, sortProperty.Name, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
					{
						return objSortOrder;
					}
				}
				return SortOrder.None;
			}

			public Type BoundColumnValueType(int intBoundColumnIndex)
			{
				return Props[intBoundColumnIndex].PropertyType;
			}

			public void CancelRowEdit(bool blnRestoreRow, bool blnAddNewFinished)
			{
				mobjDataConnectionState[64] = true;
				mobjDataConnectionState[128] = blnRestoreRow;
				try
				{
					object obj = null;
					CurrencyManager currencyManager = CurrencyManager;
					if (currencyManager.Position >= 0 && currencyManager.Position < currencyManager.List.Count)
					{
						obj = currencyManager.Current;
					}
					currencyManager.CancelCurrentEdit();
					IEditableObject editableObject = null;
					if (currencyManager.Position >= 0 && currencyManager.Position < currencyManager.List.Count)
					{
						editableObject = currencyManager.Current as IEditableObject;
					}
					if (editableObject != null && obj == editableObject)
					{
						editableObject.BeginEdit();
					}
				}
				finally
				{
					mobjDataConnectionState[64] = false;
				}
				if (blnAddNewFinished)
				{
					mobjDataConnectionState[4] = true;
				}
			}

			private void currencyManager_ListChanged(object sender, ListChangedEventArgs e)
			{
				mobjDataConnectionState[131072] = true;
				try
				{
					ProcessListChanged(e);
				}
				finally
				{
					mobjDataConnectionState[131072] = false;
				}
				Owner.OnDataBindingComplete(e.ListChangedType);
				LastListCount = CurrencyManager.Count;
			}

			private void currencyManager_PositionChanged(object sender, EventArgs e)
			{
				CurrencyManager currencyManager = CurrencyManager;
				DataGridView owner = Owner;
				if (owner.Columns.Count == 0 || owner.Rows.Count == (owner.AllowUserToAddRowsInternal ? 1 : 0) || mobjDataConnectionState[8] || (owner.AllowUserToAddRowsInternal && mobjDataConnectionState[4] && !mobjDataConnectionState[512] && currencyManager.Position > -1 && currencyManager.Position == owner.NewRowIndex && owner.CurrentCellAddress.Y != owner.NewRowIndex && currencyManager.Count == DataBoundRowsCount() + 1))
				{
					return;
				}
				mobjDataConnectionState[2048] = true;
				try
				{
					if (!owner.InSortOperation)
					{
						bool blnScrollIntoView = true;
						if (mobjDataConnectionState[256] && currencyManager.List<object> is IBindingList { SupportsSorting: not false, IsSorted: not false })
						{
							blnScrollIntoView = false;
						}
						bool flag = mobjDataConnectionState[64] && !mobjDataConnectionState[4];
						int lastListCount = LastListCount;
						flag |= lastListCount == -1 || lastListCount == currencyManager.Count;
						MatchCurrencyManagerPosition(blnScrollIntoView, flag);
					}
				}
				finally
				{
					mobjDataConnectionState[2048] = false;
				}
			}

			private int DataBoundRowsCount()
			{
				DataGridView owner = Owner;
				int num = owner.Rows.Count;
				if (owner.AllowUserToAddRowsInternal && owner.Rows.Count > 0 && (owner.CurrentCellAddress.Y != owner.NewRowIndex || owner.IsCurrentRowDirty))
				{
					num--;
				}
				return num;
			}

			public bool DataFieldIsReadOnly(int intBoundColumnIndex)
			{
				return Props?[intBoundColumnIndex].IsReadOnly ?? false;
			}

			private void DataSource_Initialized(object sender, EventArgs e)
			{
				object dataSource = DataSource;
				if (dataSource is ISupportInitializeNotification supportInitializeNotification)
				{
					supportInitializeNotification.Initialized -= DataSource_Initialized;
				}
				mobjDataConnectionState[262144] = false;
				SetDataConnection(dataSource, DataMember);
				DataGridView owner = Owner;
				owner.RefreshColumnsAndRows();
				owner.OnDataBindingComplete(ListChangedType.Reset);
			}

			private void DataSourceMetaDataChanged()
			{
				Props = CurrencyManager.GetItemProperties();
				Owner.RefreshColumnsAndRows();
			}

			public void DeleteRow(int intRowIndex)
			{
				mobjDataConnectionState[8] = true;
				try
				{
					CurrencyManager currencyManager = CurrencyManager;
					if (!mobjDataConnectionState[4])
					{
						DataGridView owner = Owner;
						bool flag = false;
						if ((owner.NewRowIndex != currencyManager.List.Count) ? (intRowIndex == owner.NewRowIndex) : (intRowIndex == owner.NewRowIndex - 1))
						{
							CancelRowEdit(blnRestoreRow: false, blnAddNewFinished: true);
							return;
						}
						mobjDataConnectionState[4096] = true;
						mobjDataConnectionState[8192] = true;
						try
						{
							currencyManager.RemoveAt(intRowIndex);
							return;
						}
						finally
						{
							mobjDataConnectionState[4096] = false;
							mobjDataConnectionState[8192] = false;
						}
					}
					mobjDataConnectionState[4096] = true;
					mobjDataConnectionState[8192] = true;
					try
					{
						currencyManager.RemoveAt(intRowIndex);
					}
					finally
					{
						mobjDataConnectionState[4096] = false;
						mobjDataConnectionState[8192] = false;
					}
				}
				finally
				{
					mobjDataConnectionState[8] = false;
				}
			}

			public void Dispose()
			{
				UnWireEvents();
				CurrencyManager = null;
			}

			public DataGridViewColumn[] GetCollectionOfBoundDataGridViewColumns()
			{
				PropertyDescriptorCollection props = Props;
				if (props == null)
				{
					return null;
				}
				ArrayList arrayList = new ArrayList();
				for (int i = 0; i < props.Count; i++)
				{
					if (typeof(IList).IsAssignableFrom(props[i].PropertyType))
					{
						TypeConverter converter = TypeDescriptor.GetConverter(typeof(System.Drawing.Image));
						if (!converter.CanConvertFrom(props[i].PropertyType))
						{
							continue;
						}
					}
					DataGridViewColumn columnByPropertyDescriptor = Owner.GetColumnByPropertyDescriptor(props[i]);
					columnByPropertyDescriptor.IsDataBoundInternal = true;
					columnByPropertyDescriptor.BoundColumnIndex = i;
					columnByPropertyDescriptor.DataPropertyName = props[i].Name;
					columnByPropertyDescriptor.Name = props[i].Name;
					columnByPropertyDescriptor.BoundColumnConverter = props[i].Converter;
					columnByPropertyDescriptor.HeaderText = ((!CommonUtils.IsNullOrEmpty(props[i].DisplayName)) ? props[i].DisplayName : props[i].Name);
					columnByPropertyDescriptor.ValueType = props[i].PropertyType;
					columnByPropertyDescriptor.IsBrowsableInternal = props[i].IsBrowsable;
					columnByPropertyDescriptor.ReadOnly = props[i].IsReadOnly;
					arrayList.Add(columnByPropertyDescriptor);
				}
				DataGridViewColumn[] array = new DataGridViewColumn[arrayList.Count];
				arrayList.CopyTo(array);
				return array;
			}

			public string GetError(int intRowIndex)
			{
				IDataErrorInfo dataErrorInfo = null;
				try
				{
					dataErrorInfo = CurrencyManager[intRowIndex] as IDataErrorInfo;
				}
				catch (Exception ex)
				{
					if (ClientUtils.IsCriticalException(ex) && !(ex is IndexOutOfRangeException))
					{
						throw;
					}
					DataGridViewDataErrorEventArgs e = new DataGridViewDataErrorEventArgs(ex, -1, intRowIndex, DataGridViewDataErrorContexts.Display);
					Owner.OnDataErrorInternal(e);
					if (e.ThrowException)
					{
						throw e.Exception;
					}
				}
				if (dataErrorInfo != null)
				{
					return dataErrorInfo.Error;
				}
				return string.Empty;
			}

			public string GetError(int intBoundColumnIndex, int intColumnIndex, int intRowIndex)
			{
				IDataErrorInfo dataErrorInfo = null;
				try
				{
					dataErrorInfo = CurrencyManager[intRowIndex] as IDataErrorInfo;
				}
				catch (Exception ex)
				{
					if (ClientUtils.IsCriticalException(ex) && !(ex is IndexOutOfRangeException))
					{
						throw;
					}
					DataGridViewDataErrorEventArgs e = new DataGridViewDataErrorEventArgs(ex, intColumnIndex, intRowIndex, DataGridViewDataErrorContexts.Display);
					Owner.OnDataErrorInternal(e);
					if (e.ThrowException)
					{
						throw e.Exception;
					}
				}
				if (dataErrorInfo != null)
				{
					return dataErrorInfo[Props[intBoundColumnIndex].Name];
				}
				return string.Empty;
			}

			private void GetSortingInformationFromBackend(out PropertyDescriptor sortProperty, out SortOrder objSortOrder)
			{
				CurrencyManager currencyManager = CurrencyManager;
				IBindingList bindingList = ((currencyManager != null) ? (currencyManager.List<object> as IBindingList) : null);
				IBindingListView bindingListView = ((bindingList != null) ? (bindingList as IBindingListView) : null);
				if (bindingList == null || !bindingList.SupportsSorting || !bindingList.IsSorted)
				{
					objSortOrder = SortOrder.None;
					sortProperty = null;
				}
				else if (bindingList.SortProperty != null)
				{
					sortProperty = bindingList.SortProperty;
					objSortOrder = ((bindingList.SortDirection == ListSortDirection.Ascending) ? SortOrder.Ascending : SortOrder.Descending);
				}
				else if (bindingListView != null)
				{
					ListSortDescriptionCollection sortDescriptions = bindingListView.SortDescriptions;
					if (sortDescriptions != null && sortDescriptions.Count > 0 && sortDescriptions[0].PropertyDescriptor != null)
					{
						sortProperty = sortDescriptions[0].PropertyDescriptor;
						objSortOrder = ((sortDescriptions[0].SortDirection == ListSortDirection.Ascending) ? SortOrder.Ascending : SortOrder.Descending);
					}
					else
					{
						sortProperty = null;
						objSortOrder = SortOrder.None;
					}
				}
				else
				{
					sortProperty = null;
					objSortOrder = SortOrder.None;
				}
			}

			public object GetValue(int intBoundColumnIndex, int intColumnIndex, int intRowIndex)
			{
				object result = null;
				try
				{
					result = Props[intBoundColumnIndex].GetValue(CurrencyManager[intRowIndex]);
				}
				catch (Exception ex)
				{
					if (ClientUtils.IsCriticalException(ex) && !(ex is IndexOutOfRangeException))
					{
						throw;
					}
					DataGridViewDataErrorEventArgs e = new DataGridViewDataErrorEventArgs(ex, intColumnIndex, intRowIndex, DataGridViewDataErrorContexts.Display);
					Owner.OnDataErrorInternal(e);
					if (e.ThrowException)
					{
						throw e.Exception;
					}
				}
				return result;
			}

			/// 
			/// Matches the currency manager position.
			/// </summary>
			/// <param name="blnScrollIntoView">if set to true</c> [scroll into view].</param>
			/// <param name="blnClearSelection">if set to true</c> [clear selection].</param>
			public void MatchCurrencyManagerPosition(bool blnScrollIntoView, bool blnClearSelection)
			{
				DataGridView owner = Owner;
				if (owner.Columns.Count == 0)
				{
					return;
				}
				int num = ((owner.CurrentCellAddress.X == -1) ? owner.FirstDisplayedColumnIndex : owner.CurrentCellAddress.X);
				if (num == -1)
				{
					DataGridViewColumn firstColumn = owner.Columns.GetFirstColumn(DataGridViewElementStates.None);
					firstColumn.Visible = true;
					num = firstColumn.Index;
				}
				int position = CurrencyManager.Position;
				if (position == -1)
				{
					if (!owner.SetCurrentCellAddressCore(-1, -1, blnSetAnchorCellAddress: false, blnValidateCurrentCell: false, blnThroughMouseClick: false))
					{
						throw new InvalidOperationException(SR.GetString("DataGridView_CellChangeCannotBeCommittedOrAborted"));
					}
				}
				else if (position < owner.Rows.Count)
				{
					if ((owner.Rows.GetRowState(position) & DataGridViewElementStates.Visible) == 0)
					{
						owner.Rows[position].Visible = true;
					}
					if ((owner.IsSharedCellVisible(owner.Rows.SharedRow(position).Cells[num], position) || owner.GroupingColumns.Count == 0) && (position != owner.CurrentCellAddress.Y || num != owner.CurrentCellAddress.X) && ((blnScrollIntoView && !owner.ScrollIntoView(num, position, blnForCurrentCellChange: true)) || (num < owner.Columns.Count && position < owner.Rows.Count && !owner.SetAndSelectCurrentCellAddress(num, position, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false, blnClearSelection, blnForceCurrentCellSelection: false))))
					{
						throw new InvalidOperationException(SR.GetString("DataGridView_CellChangeCannotBeCommittedOrAborted"));
					}
				}
			}

			public DataGridViewDataConnection(DataGridView objOwner)
			{
				DataMember = string.Empty;
				LastListCount = -1;
				Owner = objOwner;
				mobjDataConnectionState[4] = true;
			}
		}

		[Serializable]
		internal class LayoutData
		{
			public Rectangle ClientRectangle;

			public Rectangle ColumnHeaders;

			public bool ColumnHeadersVisible;

			public Rectangle Data;

			internal bool dirty;

			public Rectangle Inside;

			public Rectangle ResizeBoxRect;

			public Rectangle RowHeaders;

			public bool RowHeadersVisible;

			public Rectangle TopLeftHeader;

			public LayoutData()
			{
				dirty = true;
				ClientRectangle = Rectangle.Empty;
				Inside = Rectangle.Empty;
				RowHeaders = Rectangle.Empty;
				ColumnHeaders = Rectangle.Empty;
				TopLeftHeader = Rectangle.Empty;
				Data = Rectangle.Empty;
				ResizeBoxRect = Rectangle.Empty;
			}

			public LayoutData(LayoutData src)
			{
				dirty = true;
				ClientRectangle = Rectangle.Empty;
				Inside = Rectangle.Empty;
				RowHeaders = Rectangle.Empty;
				ColumnHeaders = Rectangle.Empty;
				TopLeftHeader = Rectangle.Empty;
				Data = Rectangle.Empty;
				ResizeBoxRect = Rectangle.Empty;
				ClientRectangle = src.ClientRectangle;
				TopLeftHeader = src.TopLeftHeader;
				ColumnHeaders = src.ColumnHeaders;
				RowHeaders = src.RowHeaders;
				Inside = src.Inside;
				Data = src.Data;
				ResizeBoxRect = src.ResizeBoxRect;
				ColumnHeadersVisible = src.ColumnHeadersVisible;
				RowHeadersVisible = src.RowHeadersVisible;
			}

			public override string ToString()
			{
				StringBuilder stringBuilder = new StringBuilder(100);
				stringBuilder.Append(base.ToString());
				stringBuilder.Append(" { \n");
				stringBuilder.Append("ClientRectangle = ");
				stringBuilder.Append(ClientRectangle.ToString());
				stringBuilder.Append('\n');
				stringBuilder.Append("Inside = ");
				stringBuilder.Append(Inside.ToString());
				stringBuilder.Append('\n');
				stringBuilder.Append("TopLeftHeader = ");
				stringBuilder.Append(TopLeftHeader.ToString());
				stringBuilder.Append('\n');
				stringBuilder.Append("ColumnHeaders = ");
				stringBuilder.Append(ColumnHeaders.ToString());
				stringBuilder.Append('\n');
				stringBuilder.Append("RowHeaders = ");
				stringBuilder.Append(RowHeaders.ToString());
				stringBuilder.Append('\n');
				stringBuilder.Append("Data = ");
				stringBuilder.Append(Data.ToString());
				stringBuilder.Append('\n');
				stringBuilder.Append("ResizeBoxRect = ");
				stringBuilder.Append(ResizeBoxRect.ToString());
				stringBuilder.Append('\n');
				stringBuilder.Append("ColumnHeadersVisible = ");
				stringBuilder.Append(ColumnHeadersVisible.ToString());
				stringBuilder.Append('\n');
				stringBuilder.Append("RowHeadersVisible = ");
				stringBuilder.Append(RowHeadersVisible.ToString());
				stringBuilder.Append(" }");
				return stringBuilder.ToString();
			}
		}

		[Serializable]
		internal class DisplayedBandsData
		{
			private bool mblnColumnInsertionOccurred;

			private bool mblnDirty;

			private int mintFirstDisplayedFrozenCol = -1;

			private int mintFirstDisplayedFrozenRow = -1;

			private int mintFirstDisplayedScrollingCol = -1;

			private int mintFirstDisplayedScrollingRow = -1;

			private int mintLastDisplayedFrozenCol = -1;

			private int mintLastDisplayedFrozenRow = -1;

			private int mintLastDisplayedScrollingRow = -1;

			private int mintLastTotallyDisplayedScrollingCol = -1;

			private int mintNumDisplayedFrozenCols;

			private int mintNumDisplayedFrozenRows;

			private int mintNumDisplayedScrollingCols;

			private int mintNumDisplayedScrollingRows;

			private int mintNumTotallyDisplayedFrozenRows;

			private int mintNumTotallyDisplayedScrollingRows;

			private int mintOldFirstDisplayedScrollingCol = -1;

			private int mintOldFirstDisplayedScrollingRow = -1;

			private int mintOldNumDisplayedFrozenRows;

			private int mintOldNumDisplayedScrollingRows;

			private bool mblnRowInsertionOccurred;

			public bool ColumnInsertionOccurred => mblnColumnInsertionOccurred;

			public bool Dirty
			{
				get
				{
					return mblnDirty;
				}
				set
				{
					mblnDirty = value;
				}
			}

			public int FirstDisplayedFrozenCol
			{
				set
				{
					if (value != mintFirstDisplayedFrozenCol)
					{
						EnsureDirtyState();
						mintFirstDisplayedFrozenCol = value;
					}
				}
			}

			public int FirstDisplayedFrozenRow
			{
				set
				{
					if (value != mintFirstDisplayedFrozenRow)
					{
						EnsureDirtyState();
						mintFirstDisplayedFrozenRow = value;
					}
				}
			}

			public int FirstDisplayedScrollingCol
			{
				get
				{
					return mintFirstDisplayedScrollingCol;
				}
				set
				{
					if (value != mintFirstDisplayedScrollingCol)
					{
						EnsureDirtyState();
						mintFirstDisplayedScrollingCol = value;
					}
				}
			}

			public int FirstDisplayedScrollingRow
			{
				get
				{
					return mintFirstDisplayedScrollingRow;
				}
				set
				{
					if (value != mintFirstDisplayedScrollingRow)
					{
						EnsureDirtyState();
						mintFirstDisplayedScrollingRow = value;
					}
				}
			}

			public int LastDisplayedFrozenCol
			{
				set
				{
					if (value != mintLastDisplayedFrozenCol)
					{
						EnsureDirtyState();
						mintLastDisplayedFrozenCol = value;
					}
				}
			}

			public int LastDisplayedFrozenRow
			{
				set
				{
					if (value != mintLastDisplayedFrozenRow)
					{
						EnsureDirtyState();
						mintLastDisplayedFrozenRow = value;
					}
				}
			}

			public int LastDisplayedScrollingRow
			{
				set
				{
					if (value != mintLastDisplayedScrollingRow)
					{
						EnsureDirtyState();
						mintLastDisplayedScrollingRow = value;
					}
				}
			}

			public int LastTotallyDisplayedScrollingCol
			{
				get
				{
					return mintLastTotallyDisplayedScrollingCol;
				}
				set
				{
					if (value != mintLastTotallyDisplayedScrollingCol)
					{
						EnsureDirtyState();
						mintLastTotallyDisplayedScrollingCol = value;
					}
				}
			}

			public int NumDisplayedFrozenCols
			{
				get
				{
					return mintNumDisplayedFrozenCols;
				}
				set
				{
					if (value != mintNumDisplayedFrozenCols)
					{
						EnsureDirtyState();
						mintNumDisplayedFrozenCols = value;
					}
				}
			}

			public int NumDisplayedFrozenRows
			{
				get
				{
					return mintNumDisplayedFrozenRows;
				}
				set
				{
					if (value != mintNumDisplayedFrozenRows)
					{
						EnsureDirtyState();
						mintNumDisplayedFrozenRows = value;
					}
				}
			}

			public int NumDisplayedScrollingCols
			{
				get
				{
					return mintNumDisplayedScrollingCols;
				}
				set
				{
					if (value != mintNumDisplayedScrollingCols)
					{
						EnsureDirtyState();
						mintNumDisplayedScrollingCols = value;
					}
				}
			}

			public int NumDisplayedScrollingRows
			{
				get
				{
					return mintNumDisplayedScrollingRows;
				}
				set
				{
					if (value != mintNumDisplayedScrollingRows)
					{
						EnsureDirtyState();
						mintNumDisplayedScrollingRows = value;
					}
				}
			}

			public int NumTotallyDisplayedFrozenRows
			{
				get
				{
					return mintNumTotallyDisplayedFrozenRows;
				}
				set
				{
					if (value != mintNumTotallyDisplayedFrozenRows)
					{
						EnsureDirtyState();
						mintNumTotallyDisplayedFrozenRows = value;
					}
				}
			}

			public int NumTotallyDisplayedScrollingRows
			{
				get
				{
					return mintNumTotallyDisplayedScrollingRows;
				}
				set
				{
					if (value != mintNumTotallyDisplayedScrollingRows)
					{
						EnsureDirtyState();
						mintNumTotallyDisplayedScrollingRows = value;
					}
				}
			}

			public int OldFirstDisplayedScrollingCol => mintOldFirstDisplayedScrollingCol;

			public int OldFirstDisplayedScrollingRow => mintOldFirstDisplayedScrollingRow;

			public int OldNumDisplayedFrozenRows => mintOldNumDisplayedFrozenRows;

			public int OldNumDisplayedScrollingRows => mintOldNumDisplayedScrollingRows;

			public bool RowInsertionOccurred => mblnRowInsertionOccurred;

			public void CorrectColumnIndexAfterInsertion(int intColumnIndex, int insertionCount)
			{
				EnsureDirtyState();
				if (mintOldFirstDisplayedScrollingCol != -1 && intColumnIndex <= mintOldFirstDisplayedScrollingCol)
				{
					mintOldFirstDisplayedScrollingCol += insertionCount;
				}
				mblnColumnInsertionOccurred = true;
			}

			public void CorrectRowIndexAfterDeletion(int intRowIndex)
			{
				EnsureDirtyState();
				if (mintOldFirstDisplayedScrollingRow != -1 && intRowIndex <= mintOldFirstDisplayedScrollingRow)
				{
					mintOldFirstDisplayedScrollingRow--;
				}
			}

			public void CorrectRowIndexAfterInsertion(int intRowIndex, int insertionCount)
			{
				EnsureDirtyState();
				if (mintOldFirstDisplayedScrollingRow != -1 && intRowIndex <= mintOldFirstDisplayedScrollingRow)
				{
					mintOldFirstDisplayedScrollingRow += insertionCount;
				}
				mblnRowInsertionOccurred = true;
				mintOldNumDisplayedScrollingRows += insertionCount;
				mintOldNumDisplayedFrozenRows += insertionCount;
			}

			public void EnsureDirtyState()
			{
				if (!mblnDirty)
				{
					mblnDirty = true;
					mblnRowInsertionOccurred = false;
					mblnColumnInsertionOccurred = false;
					SetOldValues();
				}
			}

			private void SetOldValues()
			{
				mintOldFirstDisplayedScrollingRow = mintFirstDisplayedScrollingRow;
				mintOldFirstDisplayedScrollingCol = mintFirstDisplayedScrollingCol;
				mintOldNumDisplayedFrozenRows = mintNumDisplayedFrozenRows;
				mintOldNumDisplayedScrollingRows = mintNumDisplayedScrollingRows;
			}
		}

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWALLOWUSERTOADDROWSCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWALLOWUSERTODELETEROWSCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWALLOWUSERTOORDERCOLUMNSCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWALLOWUSERTORESIZECOLUMNSCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWALLOWUSERTORESIZEROWSCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWALTERNATINGROWSDEFAULTCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWAUTOGENERATECOLUMNSCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWAUTOSIZECOLUMNMODECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWAUTOSIZECOLUMNSMODECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWAUTOSIZEROWSMODECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWBACKGROUNDCOLORCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWBORDERSTYLECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCANCELROWEDIT = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLBEGINEDIT = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLBORDERSTYLECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLCLICK = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLCONTENTCLICK = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLCONTENTDOUBLECLICK = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLCONTEXTMENUCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLCONTEXTMENUSTRIPNEEDED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLDOUBLECLICK = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLENDEDIT = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLENTER = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLERRORTEXTCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLERRORTEXTNEEDED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLFORMATTING = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLLEAVE = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLMOUSECLICK = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLMOUSEDOUBLECLICK = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLMOUSEDOWN = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLMOUSEENTER = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLMOUSELEAVE = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLMOUSEMOVE = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLMOUSEUP = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLPAINTING = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLPARSING = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLSTATECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLSTYLECONTENTCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLTOOLTIPTEXTCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLTOOLTIPTEXTNEEDED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLVALIDATED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLVALIDATING = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLVALUECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLVALUENEEDED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLVALUEPUSHED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNADDED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNCONTEXTMENUSTRIPCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNDATAPROPERTYNAMECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNDEFAULTCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNDISPLAYINDEXCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNDIVIDERDOUBLECLICK = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNDIVIDERWIDTHCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNHEADERCELLCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSECLICK = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSEDOUBLECLICK = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNHEADERSBORDERSTYLECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNHEADERSDEFAULTCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNHEADERSHEIGHTCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNHEADERSHEIGHTSIZEMODECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNMINIMUMWIDTHCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNNAMECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNREMOVED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNSORTMODECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNSTATECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNTOOLTIPTEXTCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCOLUMNWIDTHCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCURRENTCELLCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCURRENTCELLDIRTYSTATECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWDATABINDINGCOMPLETE = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWDATAERROR = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWDATAMEMBERCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWDATASOURCECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWDEFAULTCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWDEFAULTVALUESNEEDED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWEDITINGCONTROLSHOWING = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWEDITMODECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWGRIDCOLORCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWMULTISELECTCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWNEWROWNEEDED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWREADONLYCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWCONTEXTMENUCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWCONTEXTMENUNEEDED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWDEFAULTCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWDIRTYSTATENEEDED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWDIVIDERDOUBLECLICK = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWDIVIDERHEIGHTCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWENTER = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWERRORTEXTCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWERRORTEXTNEEDED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEADERCELLCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEADERMOUSECLICK = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEADERMOUSEDOUBLECLICK = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEADERSBORDERSTYLECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEADERSDEFAULTCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEADERSWIDTHCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEADERSWIDTHSIZEMODECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEIGHTCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEIGHTINFONEEDED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWHEIGHTINFOPUSHED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWLEAVE = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWMINIMUMHEIGHTCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWPOSTPAINT = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWPREPAINT = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWSADDED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWSDEFAULTCELLSTYLECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWSREMOVED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWSTATECHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWUNSHARED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWVALIDATED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWROWVALIDATING = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWSCROLL = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWSELECTIONCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWSORTCOMPARE = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWSORTED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWUSERADDEDROW = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWUSERDELETEDROW = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWUSERDELETINGROW = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_DATAGRIDVIEWCELLCONTEXTMENUNEEDED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_HIERARCHICGRIDCREATED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_COLUMNCHOOSERCOLUMNSVISIBILITYCHANGED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_ROWEXPANDING = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_ROWEXPANDED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_ROWCOLLAPSED = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		internal static readonly SerializableEvent EVENT_ROWCOLLAPSING = SerializableEvent.Register("Event", typeof(Delegate), typeof(DataGridView));

		private const int DATAGRIDVIEWSTATE1_allowUserToAddRows = 1;

		private const int DATAGRIDVIEWSTATE1_allowUserToDeleteRows = 2;

		private const int DATAGRIDVIEWSTATE1_allowUserToOrderColumns = 4;

		private const int DATAGRIDVIEWSTATE1_ambientColumnHeadersFont = 67108864;

		private const int DATAGRIDVIEWSTATE1_ambientFont = 33554432;

		private const int DATAGRIDVIEWSTATE1_ambientForeColor = 1024;

		private const int DATAGRIDVIEWSTATE1_ambientRowHeadersFont = 134217728;

		private const int DATAGRIDVIEWSTATE1_autoGenerateColumns = 8388608;

		private const int DATAGRIDVIEWSTATE1_columnHeadersVisible = 8;

		private const int DATAGRIDVIEWSTATE1_currentCellInEditMode = 32768;

		private const int DATAGRIDVIEWSTATE1_customCursorSet = 16777216;

		private const int DATAGRIDVIEWSTATE1_editedCellChanged = 131072;

		private const int DATAGRIDVIEWSTATE1_editedRowChanged = 262144;

		private const int DATAGRIDVIEWSTATE1_editingControlChanging = 16384;

		private const int DATAGRIDVIEWSTATE1_editingControlHidden = 4096;

		private const int DATAGRIDVIEWSTATE1_forwardCharMessage = 32;

		private const int DATAGRIDVIEWSTATE1_ignoringEditingChanges = 512;

		private const int DATAGRIDVIEWSTATE1_isAutoSized = 1073741824;

		private const int DATAGRIDVIEWSTATE1_isRestricted = 536870912;

		private const int DATAGRIDVIEWSTATE1_isRestrictedChecked = 268435456;

		private const int DATAGRIDVIEWSTATE1_leavingWithTabKey = 64;

		private const int DATAGRIDVIEWSTATE1_multiSelect = 128;

		private const int DATAGRIDVIEWSTATE1_newRowCreatedByEditing = 2097152;

		private const int DATAGRIDVIEWSTATE1_newRowEdited = 524288;

		private const int DATAGRIDVIEWSTATE1_readOnly = 1048576;

		private const int DATAGRIDVIEWSTATE1_rowHeadersVisible = 16;

		private const int DATAGRIDVIEWSTATE1_scrolledSinceMouseDown = 2048;

		private const int DATAGRIDVIEWSTATE1_standardTab = 8192;

		private const int DATAGRIDVIEWSTATE1_temporarilyResetCurrentCell = 4194304;

		private const int DATAGRIDVIEWSTATE1_virtualMode = 65536;

		private const int DATAGRIDVIEWSTATE2_allowHorizontalScrollbar = 33554432;

		private const int DATAGRIDVIEWSTATE2_allowUserToResizeColumns = 2;

		private const int DATAGRIDVIEWSTATE2_allowUserToResizeRows = 4;

		private const int DATAGRIDVIEWSTATE2_autoSizedWithoutHandle = 1048576;

		private const int DATAGRIDVIEWSTATE2_cellMouseDownInContentBounds = 268435456;

		private const int DATAGRIDVIEWSTATE2_currentCellWantsInputKey = 8192;

		private const int DATAGRIDVIEWSTATE2_discardEditingControl = 536870912;

		private const int DATAGRIDVIEWSTATE2_enableHeadersVisualStyles = 64;

		private const int DATAGRIDVIEWSTATE2_ignoreCursorChange = 2097152;

		private const int DATAGRIDVIEWSTATE2_inBindingContextChanged = 16777216;

		private const int DATAGRIDVIEWSTATE2_initializing = 524288;

		private const int DATAGRIDVIEWSTATE2_messageFromEditingCtrls = 134217728;

		private const int DATAGRIDVIEWSTATE2_mouseEnterExpected = 32;

		private const int DATAGRIDVIEWSTATE2_mouseOverRemovedEditingCtrl = 8;

		private const int DATAGRIDVIEWSTATE2_mouseOverRemovedEditingPanel = 16;

		private const int DATAGRIDVIEWSTATE2_nextMouseUpIsDouble = 8388608;

		private const int DATAGRIDVIEWSTATE2_raiseSelectionChanged = 262144;

		private const int DATAGRIDVIEWSTATE2_replacedCellReadOnly = 131072;

		private const int DATAGRIDVIEWSTATE2_replacedCellSelected = 65536;

		private const int DATAGRIDVIEWSTATE2_rightToLeftMode = 2048;

		private const int DATAGRIDVIEWSTATE2_rightToLeftValid = 4096;

		private const int DATAGRIDVIEWSTATE2_rowsCollectionClearedInSetCell = 4194304;

		private const int DATAGRIDVIEWSTATE2_showCellErrors = 128;

		private const int DATAGRIDVIEWSTATE2_showCellToolTips = 256;

		private const int DATAGRIDVIEWSTATE2_showColumnRelocationInsertion = 1024;

		private const int DATAGRIDVIEWSTATE2_showEditingIcon = 1;

		private const int DATAGRIDVIEWSTATE2_showRowErrors = 512;

		private const int DATAGRIDVIEWSTATE2_stopRaisingHorizontalScroll = 32768;

		private const int DATAGRIDVIEWSTATE2_stopRaisingVerticalScroll = 16384;

		private const int DATAGRIDVIEWSTATE2_usedFillWeightsDirty = 67108864;

		private const int DATAGRIDVIEWOPER_inAdjustFillingColumn = 524288;

		private const int DATAGRIDVIEWOPER_inAdjustFillingColumns = 262144;

		private const int DATAGRIDVIEWOPER_inBeginEdit = 2097152;

		private const int DATAGRIDVIEWOPER_inBorderStyleChange = 65536;

		private const int DATAGRIDVIEWOPER_inCellValidating = 32768;

		private const int DATAGRIDVIEWOPER_inCurrentCellChange = 131072;

		private const int DATAGRIDVIEWOPER_inDisplayIndexAdjustments = 2048;

		private const int DATAGRIDVIEWOPER_inDispose = 1048576;

		private const int DATAGRIDVIEWOPER_inEndEdit = 4194304;

		private const int DATAGRIDVIEWOPER_inMouseDown = 8192;

		private const int DATAGRIDVIEWOPER_inReadOnlyChange = 16384;

		private const int DATAGRIDVIEWOPER_inRefreshColumns = 1024;

		private const int DATAGRIDVIEWOPER_inSort = 64;

		private const int DATAGRIDVIEWOPER_lastEditCtrlClickDoubled = 4096;

		private const int DATAGRIDVIEWOPER_resizingOperationAboutToStart = 8388608;

		private const int DATAGRIDVIEWOPER_trackCellSelect = 16;

		private const int DATAGRIDVIEWOPER_trackColHeadersResize = 128;

		private const int DATAGRIDVIEWOPER_trackColRelocation = 32;

		private const int DATAGRIDVIEWOPER_trackColResize = 1;

		private const int DATAGRIDVIEWOPER_trackColSelect = 4;

		private const int DATAGRIDVIEWOPER_trackMouseMoves = 512;

		private const int DATAGRIDVIEWOPER_trackRowHeadersResize = 256;

		private const int DATAGRIDVIEWOPER_trackRowResize = 2;

		private const int DATAGRIDVIEWOPER_trackRowSelect = 8;

		private const byte DATAGRIDVIEW_columnSizingHotZone = 6;

		private const byte DATAGRIDVIEW_rowSizingHotZone = 5;

		private const byte DATAGRIDVIEW_insertionBarWidth = 3;

		private const byte DATAGRIDVIEW_bulkPaintThreshold = 8;

		private const int mcntState2_Initializing = 524288;

		private const int VERTICAL_SCROLLBAR_WIDTH = 17;

		private int mintBulkLayoutCount;

		private int mintColumnHeadersHeight;

		private int mintRowHeadersWidth;

		private int mintBulkPaintCount;

		private int mintAutoSizeCount;

		private int mintDimensionChangeCount;

		private int mintSelectionChangeCount;

		private int mintNewRowIndex = -1;

		private bool mblnDisableNavigation;

		private bool mblnShowFilterRow;

		private bool mblnLazyMode;

		private bool mblnIsSelectionChangeCritical;

		private bool mblnSelectOnRightClick;

		private bool mblnEnforceEqualRowSize;

		private bool mblnIsCaptionVisible;

		private PreRenderUpdateType menmPreRenderUpdateTypes = PreRenderUpdateType.None;

		private DataGridViewCellBorderStyle menmCellBorderStyle = DataGridViewCellBorderStyle.Single;

		private DataGridViewAutoSizeRowsMode menmAutoSizeRowsMode;

		private DataGridViewAutoSizeColumnsMode menmAutoSizeColumnsMode;

		private DataGridViewClipboardCopyMode menmClipboardCopyMode;

		private ScrollBars menmScrollBars;

		private DataGridViewSelectionMode menmSelectionMode;

		private DataGridViewColumnHeadersHeightSizeMode menmColumnHeadersHeightSizeMode;

		private DataGridViewEditMode menmEditMode;

		private SortOrder menmSortOrder;

		private DataGridViewRowHeadersWidthSizeMode menmRowHeadersWidthSizeMode;

		private DataGridViewIntLinkedList mobjSelectedBandSnapshotIndexes;

		private DataGridViewCellLinkedList mobjIndividualSelectedCells;

		private DataGridViewIntLinkedList mobjSelectedBandIndexes;

		private DataGridViewCellStyleChangedEventArgs mobjCellStyleChangedEventArgs;

		private DataGridViewDataConnection mobjDataConnection;

		private object mobjUneditedFormattedValue;

		private Color mobjGridColor;

		private Color mobjBackgroundColor;

		private Point mobjCurrentCellCache;

		private Point mobjCurrentCellPoint = Point.Empty;

		private DataGridViewCellValueEventArgs mobjCellValueEventArgs;

		private DataGridViewCellLinkedList mobjIndividualReadOnlyCells;

		private DisplayedBandsData mobjDisplayedBandsInfo;

		private DataGridViewAdvancedBorderStyle mobjAdvancedDataGridViewBorderStyle;

		private LayoutData mobjLayoutInfo = null;

		private DataGridViewCellStyle mobjDefaultCellStyle = null;

		private DataGridViewCellStyle mobjColumnHeadersDefaultCellStyle = null;

		private DataGridViewCellStyle mobjAlternatingRowsDefaultCellStyle = null;

		private DataGridViewCellStyle mobjRowHeadersDefaultCellStyle = null;

		private DataGridViewCellStyle mobjPlaceholderCellStyle = null;

		private DataGridViewCellStyle mobjRowsDefaultCellStyle = null;

		private Control mobjLatestEditingControl = null;

		private Control mobjCachedEditingControl = null;

		private Control mobjEditingControl = null;

		private DataGridViewHeaderCell mobjTopLeftHeaderCell = null;

		private DataGridViewColumnCollection mobjColumns = null;

		private DataGridViewRowCollection mobjRows = null;

		private DataGridViewRow mobjRowTemplate = null;

		private DataGridViewColumn mobjSortedColumn = null;

		private DataGridViewBlocksManager mobjDataGridViewBlocksManager = null;

		private DataGridViewFilterRow mobjDataGridViewFilterRow = null;

		private NavigationKeyFilter menmNavigationKeyFilter = NavigationKeyFilter.None;

		private int mintMaxFilterOptions = 100;

		internal bool mblnSuspendFilterInitialization = false;

		private int minPerformLayoutCount = 0;

		private ObservableCollection<object> mobjHierarchicInfos = null;

		private Dictionary<string, string> mobjRealFilteringDataMemberIndexByProposedFilteringDataMember;

		private DataGridView mobjRootGrid;

		private string mstrFilterTemplate;

		private int mintHierarchyLevel;

		private ShowExpansionIndicator menmExpansionIndicator;

		private int mintCaptionHeight = 0;

		private bool mblnShowExpansionIndicator;

		private ObservableCollection<object> mobjSystemHierarchicInfos = null;

		private UniqueObservableCollection<object> mobjGroupingColumns;

		private bool mblnShowGroupingDropArea;

		private bool mblnSupportGroupCount = false;

		private bool mblnHideGroupedColumns = false;

		private DataGridViewGroupingTreeView mobjGroupingTreeView = null;

		private Color mobjGroupingAreaBackColor;

		private BorderColor mobjGroupingAreaBorderColor;

		private BorderStyle mobjGroupingAreaBorderStyle;

		private BorderWidth mobjGroupingAreaBorderWidth;

		private int mintGroupingAreaHeight;

		private ResourceHandle mobjGroupingAreaBackgroundImage;

		private BackgroundImagePosition menmGroupingAreaBackgroundImagePosition;

		private BackgroundImageRepeat menmGroupingAreaBackgroundImageRepeat;

		private int mintPrevGroupHeaderCellPanelIndex = -1;

		private ExtendedColumnHeaders mobjExtendedColumnHeaders;

		private bool mblnShowColumnChooser;

		private IComparer mblnColumnChooserSorter;

		private List<object> mobjHeadersFilterInfo = null;

		private static readonly SerializableEvent ColumnDividerDoubleClickEvent;

		/// 
		/// The CurrentCellChanged event registration.
		/// </summary>
		private static readonly SerializableEvent CurrentCellChangedEvent;

		/// 
		/// The GroupHeaderFormatting event registration.
		/// </summary>
		private static readonly SerializableEvent GroupHeaderFormattingEvent;

		/// 
		/// The GroupingChangedEvent event registration.
		/// </summary>
		private static readonly SerializableEvent GroupingChangedEvent;

		/// 
		/// The SelectionChanged event registration.
		/// </summary>
		private static readonly SerializableEvent SelectionChangedEvent;

		/// 
		/// ShowCustomFilter event registration.
		/// </summary> 
		private static readonly SerializableEvent CustomHeaderFilterClickedEvent;

		[NonSerialized]
		private Graphics mobjCachedGraphics = null;

		/// 
		/// Gets or sets the data grid view state1.
		/// </summary>
		/// The data grid view state2.</value>
		private SerializableBitVector32 mobjDataGridViewState1 = default(SerializableBitVector32);

		/// 
		/// Gets or sets the data grid view state2.
		/// </summary>
		/// The data grid view state2.</value>
		private SerializableBitVector32 mobjDataGridViewState2 = default(SerializableBitVector32);

		/// 
		/// Gets or sets the data grid view oper.
		/// </summary>
		/// The data grid view oper.</value>
		private SerializableBitVector32 mobjDataGridViewOper = default(SerializableBitVector32);

		private int mintTotalPages = 1;

		private int mintCurrentPage = 1;

		private int mintItemsPerPage = 20;

		private int mintVirtualBlockSize = 20;

		private bool mblnUseInternalPaging = true;

		/// 
		/// The PagingChanged event registration.
		/// </summary>
		private static readonly SerializableEvent PagingChangedEvent;

		/// 
		/// Gets the hanlder for the CurrentCellChanged event.
		/// </summary>
		private Delegate RowExpandingHandler => GetHandler(EVENT_ROWEXPANDING);

		/// 
		/// Gets the hanlder for the CurrentCellChanged event.
		/// </summary>
		private Delegate RowExpandedHandler => GetHandler(EVENT_ROWEXPANDED);

		/// 
		/// Gets the column divider double click handler.
		/// </summary>
		private DataGridViewColumnDividerDoubleClickEventHandler ColumnDividerDoubleClickHandler => (DataGridViewColumnDividerDoubleClickEventHandler)GetHandler(ColumnDividerDoubleClick);

		/// 
		/// Gets the hanlder for the CurrentCellChanged event.
		/// </summary>
		private EventHandler CurrentCellChangedHandler => (EventHandler)GetHandler(CurrentCellChanged);

		/// 
		/// Gets the group header formatting handler.
		/// </summary>
		private GroupHeaderFormattingEventHandler GroupHeaderFormattingHandler => (GroupHeaderFormattingEventHandler)GetHandler(GroupHeaderFormatting);

		/// 
		/// Gets the grouping changed event handler.
		/// </summary>
		private GroupingChangedEventHandler GroupingChangedEventHandler => (GroupingChangedEventHandler)GetHandler(GroupingChanged);

		/// 
		/// Gets the hanlder for the SelectionChanged event.
		/// </summary>
		private EventHandler SelectionChangedHandler => (EventHandler)GetHandler(SelectionChanged);

		/// 
		/// Gets the custom filter applying event handler.
		/// </summary>
		internal CustomFilterApplyingEventHandler CustomHeaderFilterClickedEventHandler => (CustomFilterApplyingEventHandler)GetHandler(CustomHeaderFilterClicked);

		/// 
		/// Gets the list of tags that client events are propogated to.
		/// </summary>
		/// 
		/// The client event propogated tags.
		/// </value>
		protected override string ClientEventsPropogationTags => string.Format("WG:{0},WG:{1},WG:{2}", "DR", "DC", "DL");

		/// 
		/// Gets the owner form.
		/// </summary>
		public override Form Form
		{
			get
			{
				DataGridView rootGrid = RootGrid;
				if (rootGrid != null && rootGrid != this)
				{
					return rootGrid.Form;
				}
				return base.Form;
			}
		}

		/// 
		/// Gets or sets the auto size count.
		/// </summary>
		/// The auto size count.</value>
		private int AutoSizeCount
		{
			get
			{
				return mintAutoSizeCount;
			}
			set
			{
				mintAutoSizeCount = value;
			}
		}

		/// 
		/// Gets or sets the no selection change count.
		/// </summary>
		/// The no selection change count.</value>
		private int NoSelectionChangeCount
		{
			get
			{
				return SelectionChangeCount;
			}
			set
			{
				SelectionChangeCount = value;
				if (value == 0)
				{
					FlushSelectionChanged();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this instance is hierarchic.
		/// </summary>
		/// 
		/// 	true</c> if this instance is hierarchic; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		public bool ExpansionIndicatorColumnVisible
		{
			get
			{
				return IsHierarchic(HierarchicInfoSelector.Any);
			}
			set
			{
				if (mblnShowExpansionIndicator != value)
				{
					mblnShowExpansionIndicator = value;
					Update();
				}
			}
		}

		/// 
		/// Gets the cached graphics.
		/// </summary>
		/// The cached graphics.</value>
		internal Graphics CachedGraphics
		{
			get
			{
				if (mobjCachedGraphics == null)
				{
					mobjCachedGraphics = CommonUtils.GetMeasurementGraphics();
				}
				return mobjCachedGraphics;
			}
		}

		/// 
		/// Gets or sets the extended column headers.
		/// </summary>
		/// 
		/// The extended column headers.
		/// </value>
		[DefaultValue(null)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ExtendedColumnHeaders ExtendedColumnHeaders => mobjExtendedColumnHeaders ?? (mobjExtendedColumnHeaders = new ExtendedColumnHeaders(this));

		/// 
		/// Gets the filter row.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public DataGridViewFilterRow FilterRow => mobjDataGridViewFilterRow;

		/// 
		/// Gets or sets a value indicating whether [show column chooser].
		/// </summary>
		/// 
		///   true</c> if [show column chooser]; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		public bool ShowColumnChooser
		{
			get
			{
				return mblnShowColumnChooser;
			}
			set
			{
				if (mblnShowColumnChooser != value)
				{
					mblnShowColumnChooser = value;
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets the column chooser sorter.
		/// </summary>
		/// 
		/// The column chooser sorter.
		/// </value>
		[DefaultValue(null)]
		[Browsable(false)]
		public IComparer ColumnChooserSorter
		{
			get
			{
				return mblnColumnChooserSorter;
			}
			set
			{
				if (mblnColumnChooserSorter != value)
				{
					mblnColumnChooserSorter = value;
				}
			}
		}

		/// 
		/// Gets or sets the expansion indicator.
		/// </summary>
		/// 
		/// The expansion indicator.
		/// </value>
		[DefaultValue(ShowExpansionIndicator.CheckOnExpand)]
		public virtual ShowExpansionIndicator ExpansionIndicator
		{
			get
			{
				return menmExpansionIndicator;
			}
			set
			{
				if (menmExpansionIndicator != value)
				{
					menmExpansionIndicator = value;
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets the hierarchy level.
		/// </summary>
		/// 
		/// The hierarchy level.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int HierarchyLevel
		{
			get
			{
				return mintHierarchyLevel;
			}
			internal set
			{
				mintHierarchyLevel = value;
			}
		}

		/// 
		/// Gets the real filtering data member index by proposed filtering data member.
		/// </summary>
		internal Dictionary<string, string> RealFilteringDataMemberIndexByProposedFilteringDataMember
		{
			get
			{
				if (mobjRealFilteringDataMemberIndexByProposedFilteringDataMember == null)
				{
					mobjRealFilteringDataMemberIndexByProposedFilteringDataMember = new Dictionary<string, string>();
				}
				return mobjRealFilteringDataMemberIndexByProposedFilteringDataMember;
			}
		}

		/// 
		/// Gets the root grid.
		/// </summary>
		public DataGridView RootGrid
		{
			get
			{
				return mobjRootGrid;
			}
			internal set
			{
				mobjRootGrid = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether this instance is selection change critical.
		/// </summary>
		/// 
		/// 	true</c> if this instance is selection change critical; otherwise, false</c>.
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(false)]
		[Description("Gets or sets a value indicating whether this instance is selection change critical.")]
		[Category("Behavior")]
		public bool IsSelectionChangeCritical
		{
			get
			{
				return mblnIsSelectionChangeCritical;
			}
			set
			{
				mblnIsSelectionChangeCritical = value;
			}
		}

		/// 
		/// Gets or sets the select on right click.
		/// </summary>
		/// The select on right click.</value>
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridView_SelectOnRightClickDescr")]
		[DefaultValue(false)]
		public bool SelectOnRightClick
		{
			get
			{
				return mblnSelectOnRightClick;
			}
			set
			{
				if (mblnSelectOnRightClick != value)
				{
					mblnSelectOnRightClick = value;
					UpdateParams(AttributeType.Control);
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(false)]
		[Description("Gets or sets a value indicating whether caption is visible.")]
		[Category("Behavior")]
		public bool IsCaptionVisible
		{
			get
			{
				return mblnIsCaptionVisible;
			}
			set
			{
				if (mblnIsCaptionVisible != value)
				{
					mblnIsCaptionVisible = value;
					UpdateParams(AttributeType.Layout);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [resize all rows].
		/// </summary>
		/// 
		///   true</c> if [resize all rows]; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Description("Gets or sets a value indicating whether all rows height will change if only one them is changed by the user")]
		[Category("Behavior")]
		public bool EnforceEqualRowSize
		{
			get
			{
				return mblnEnforceEqualRowSize;
			}
			set
			{
				if (mblnEnforceEqualRowSize != value)
				{
					mblnEnforceEqualRowSize = value;
					UpdateParams(AttributeType.Layout);
				}
			}
		}

		/// 
		/// Gets a value indicating whether this instance is virtual.
		/// </summary>
		/// 
		/// 	true</c> if this instance is virtual; otherwise, false</c>.
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		protected virtual bool IsVirtualDataGridView => !base.DesignMode && Context != null && Context.Config.IsFeatureEnabled("ForceVirtualDataGridView", false);

		/// 
		/// Gets or sets the control custom style.
		/// </summary>
		/// </value>
		public override string CustomStyle
		{
			get
			{
				if (!base.DesignMode && Context != null && Context.Config.IsFeatureEnabled("ForceVirtualDataGridView", false))
				{
					return "V";
				}
				return base.CustomStyle;
			}
			set
			{
				base.CustomStyle = value;
			}
		}

		private DataGridViewCell CurrentCellInternal => Rows.SharedRow(mobjCurrentCellPoint.Y).Cells[mobjCurrentCellPoint.X];

		/// 
		/// Gets or sets the displayed bands info.
		/// </summary>
		/// The displayed bands info.</value>
		private DisplayedBandsData DisplayedBandsInfo
		{
			get
			{
				return mobjDisplayedBandsInfo;
			}
			set
			{
				mobjDisplayedBandsInfo = value;
			}
		}

		/// 
		/// Gets the editing control.
		/// </summary>
		/// The editing control.</value>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public Control EditingControl
		{
			get
			{
				return mobjEditingControl;
			}
			private set
			{
				mobjEditingControl = value;
			}
		}

		/// 
		/// Gets or sets the cached editing control.
		/// </summary>
		/// The cached editing control.</value>
		private Control CachedEditingControl
		{
			get
			{
				return mobjCachedEditingControl;
			}
			set
			{
				mobjCachedEditingControl = value;
			}
		}

		/// 
		/// Gets a value indicating whether [in begin edit].
		/// </summary>
		/// true</c> if [in begin edit]; otherwise, false</c>.</value>
		internal bool InBeginEdit => mobjDataGridViewOper[2097152];

		/// 
		/// Gets or sets the bulk paint count.
		/// </summary>
		/// The bulk paint count.</value>
		private int BulkPaintCount
		{
			get
			{
				return mintBulkPaintCount;
			}
			set
			{
				mintBulkPaintCount = value;
			}
		}

		internal bool InEndEdit => mobjDataGridViewOper[4194304];

		/// 
		/// Gets or sets the individual read only cells.
		/// </summary>
		/// The individual read only cells.</value>
		private DataGridViewCellLinkedList IndividualReadOnlyCells
		{
			get
			{
				return mobjIndividualReadOnlyCells;
			}
			set
			{
				mobjIndividualReadOnlyCells = value;
			}
		}

		internal bool InSortOperation => false;

		internal bool InInitialization => false;

		internal bool NoDimensionChangeAllowed => DimensionChangeCount > 0;

		internal bool InDisplayIndexAdjustments
		{
			get
			{
				return mobjDataGridViewOper[2048];
			}
			set
			{
				mobjDataGridViewOper[2048] = value;
			}
		}

		private Point FirstDisplayedCellAddress
		{
			get
			{
				Point result = new Point(-1, -1);
				result.Y = Rows.GetFirstRow(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
				if (result.Y == -1 && FirstDisplayedScrollingRowIndex >= 0)
				{
					result.Y = FirstDisplayedScrollingRowIndex;
				}
				if (result.Y >= 0)
				{
					result.X = FirstDisplayedScrollingColumnIndex;
				}
				return result;
			}
		}

		/// Gets the border style for the upper-left cell in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the style of the border of the upper-left cell in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public virtual DataGridViewAdvancedBorderStyle AdjustedTopLeftHeaderBorderStyle => null;

		/// Gets the border style of the cells in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the border style of the cells in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public DataGridViewAdvancedBorderStyle AdvancedCellBorderStyle => null;

		/// Gets the border style of the column header cells in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the border style of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see> objects in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public DataGridViewAdvancedBorderStyle AdvancedColumnHeadersBorderStyle => null;

		/// Gets the border style of the row header cells in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the border style of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell"></see> objects in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public DataGridViewAdvancedBorderStyle AdvancedRowHeadersBorderStyle => null;

		/// Gets or sets a value indicating whether the option to add rows is displayed to the user.</summary>
		/// true if the add-row option is displayed to the user; otherwise false. The default is true.</returns>
		/// 1</filterpriority>
		[SRDescription("DataGridView_AllowUserToAddRowsDescr")]
		[DefaultValue(true)]
		[SRCategory("CatBehavior")]
		public bool AllowUserToAddRows
		{
			get
			{
				return mobjDataGridViewState1[1];
			}
			set
			{
				if (AllowUserToAddRows != value)
				{
					mobjDataGridViewState1[1] = value;
					if (DataSource != null)
					{
						DataConnection.ResetCachedAllowUserToAddRowsInternal();
					}
					OnAllowUserToAddRowsChanged(EventArgs.Empty);
				}
			}
		}

		/// Gets or sets a value indicating whether the user is allowed to delete rows from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// true if the user can delete rows; otherwise, false. The default is true.</returns>
		/// 1</filterpriority>
		[DefaultValue(true)]
		[SRDescription("DataGridView_AllowUserToDeleteRowsDescr")]
		[SRCategory("CatBehavior")]
		public bool AllowUserToDeleteRows
		{
			get
			{
				return mobjDataGridViewState1[2];
			}
			set
			{
				if (AllowUserToDeleteRows != value)
				{
					mobjDataGridViewState1[2] = value;
					OnAllowUserToDeleteRowsChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Checks datasource and definition for permission to delete rows
		/// </summary>
		internal bool AllowUserToDeleteRowsInternal
		{
			get
			{
				if (DataSource == null)
				{
					return AllowUserToDeleteRows;
				}
				if (AllowUserToDeleteRows)
				{
					return DataConnection.AllowRemove;
				}
				return false;
			}
		}

		/// Gets or sets a value indicating whether manual column repositioning is enabled.</summary>
		/// true if the user can change the column order; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		[SRDescription("DataGridView_AllowUserToOrderColumnsDescr")]
		public bool AllowUserToOrderColumns
		{
			get
			{
				return mobjDataGridViewState1[4];
			}
			set
			{
				if (AllowUserToOrderColumns != value)
				{
					if (value && ShowGroupingDropArea)
					{
						throw new InvalidOperationException("Columns reordering and grouping are not supported simultaneously.");
					}
					mobjDataGridViewState1[4] = value;
					OnAllowUserToOrderColumnsChanged(EventArgs.Empty);
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// Gets or sets a value indicating whether users can resize columns.</summary>
		/// true if users can resize columns; otherwise, false. The default is true.</returns>
		[SRDescription("DataGridView_AllowUserToResizeColumnsDescr")]
		[DefaultValue(true)]
		[SRCategory("CatBehavior")]
		public bool AllowUserToResizeColumns
		{
			get
			{
				return mobjDataGridViewState2[2];
			}
			set
			{
				if (AllowUserToResizeColumns != value)
				{
					mobjDataGridViewState2[2] = value;
					OnAllowUserToResizeColumnsChanged(EventArgs.Empty);
					Update();
				}
			}
		}

		/// Gets or sets a value indicating whether users can resize rows.</summary>
		/// true if all the rows are resizable; otherwise, false. The default is true.</returns>
		[DefaultValue(true)]
		[SRCategory("CatBehavior")]
		[SRDescription("DataGridView_AllowUserToResizeRowsDescr")]
		public bool AllowUserToResizeRows
		{
			get
			{
				return mobjDataGridViewState2[4];
			}
			set
			{
				if (AllowUserToResizeRows != value)
				{
					mobjDataGridViewState2[4] = value;
					OnAllowUserToResizeRowsChanged(EventArgs.Empty);
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the bulk layout count.
		/// </summary>
		/// The bulk layout count.</value>
		private int BulkLayoutCount
		{
			get
			{
				return mintBulkLayoutCount;
			}
			set
			{
				mintBulkLayoutCount = value;
			}
		}

		/// Gets or sets the default cell style applied to odd-numbered rows of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to apply to the odd-numbered rows.</returns>
		/// 1</filterpriority>
		[SRDescription("DataGridView_AlternatingRowsDefaultCellStyleDescr")]
		[SRCategory("CatAppearance")]
		public DataGridViewCellStyle AlternatingRowsDefaultCellStyle
		{
			get
			{
				if (mobjAlternatingRowsDefaultCellStyle == null)
				{
					mobjAlternatingRowsDefaultCellStyle = new DataGridViewCellStyle();
					mobjAlternatingRowsDefaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.AlternatingRows);
				}
				return mobjAlternatingRowsDefaultCellStyle;
			}
			set
			{
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = AlternatingRowsDefaultCellStyle;
				alternatingRowsDefaultCellStyle.RemoveScope(DataGridViewCellStyleScopes.AlternatingRows);
				mobjAlternatingRowsDefaultCellStyle = value;
				if (value != null)
				{
					mobjAlternatingRowsDefaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.AlternatingRows);
				}
				DataGridViewCellStyleDifferences differencesFrom = alternatingRowsDefaultCellStyle.GetDifferencesFrom(AlternatingRowsDefaultCellStyle);
				if (differencesFrom != DataGridViewCellStyleDifferences.None)
				{
					CellStyleChangedEventArgs.ChangeAffectsPreferredSize = differencesFrom == DataGridViewCellStyleDifferences.AffectPreferredSize;
					OnAlternatingRowsDefaultCellStyleChanged(CellStyleChangedEventArgs);
				}
			}
		}

		/// Gets or sets a value indicating whether columns are created automatically when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> or <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataMember"></see> properties are set.</summary>
		/// true if the columns should be created automatically; otherwise, false. The default is true.</returns>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DefaultValue(true)]
		public bool AutoGenerateColumns
		{
			get
			{
				return mobjDataGridViewState1[8388608];
			}
			set
			{
				if (mobjDataGridViewState1[8388608] != value)
				{
					mobjDataGridViewState1[8388608] = value;
					OnAutoGenerateColumnsChanged(EventArgs.Empty);
				}
			}
		}

		internal bool AllowUserToAddRowsInternal
		{
			get
			{
				if (DataSource == null)
				{
					return AllowUserToAddRows;
				}
				if (AllowUserToAddRows)
				{
					return DataConnection.AllowAdd;
				}
				return false;
			}
		}

		/// Gets or sets a value indicating how column widths are determined.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode"></see> value. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.None"></see>. </returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode"></see> value. </exception>
		/// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader"></see>, column headers are hidden, and at least one visible column has an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet"></see>.-or-The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill"></see> and at least one visible column with an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet"></see> is frozen.</exception>
		[DefaultValue(DataGridViewAutoSizeColumnsMode.None)]
		[SRCategory("CatLayout")]
		[SRDescription("DataGridView_AutoSizeColumnsModeDescr")]
		public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode
		{
			get
			{
				return menmAutoSizeColumnsMode;
			}
			set
			{
				switch (value)
				{
				case DataGridViewAutoSizeColumnsMode.None:
				case DataGridViewAutoSizeColumnsMode.ColumnHeader:
				case DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader:
				case DataGridViewAutoSizeColumnsMode.AllCells:
				case DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader:
				case DataGridViewAutoSizeColumnsMode.DisplayedCells:
				case DataGridViewAutoSizeColumnsMode.Fill:
				{
					if (AutoSizeColumnsMode == value)
					{
						break;
					}
					foreach (DataGridViewColumn column in Columns)
					{
						if (column.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet && column.Visible)
						{
							if (value == DataGridViewAutoSizeColumnsMode.ColumnHeader && !ColumnHeadersVisible)
							{
								throw new InvalidOperationException(SR.GetString("DataGridView_CannotAutoSizeColumnsInvisibleColumnHeaders"));
							}
							if (value == DataGridViewAutoSizeColumnsMode.Fill && column.Frozen)
							{
								throw new InvalidOperationException(SR.GetString("DataGridView_CannotAutoFillFrozenColumns"));
							}
						}
					}
					DataGridViewAutoSizeColumnMode[] array = new DataGridViewAutoSizeColumnMode[Columns.Count];
					foreach (DataGridViewColumn column2 in Columns)
					{
						array[column2.Index] = column2.InheritedAutoSizeMode;
					}
					DataGridViewAutoSizeColumnsModeEventArgs e = new DataGridViewAutoSizeColumnsModeEventArgs(array);
					menmAutoSizeColumnsMode = value;
					OnAutoSizeColumnsModeChanged(e);
					break;
				}
				default:
					throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewAutoSizeColumnsMode));
				}
			}
		}

		/// Gets or sets a value indicating how row heights are determined. </summary>
		/// A <see cref="T:System.Windows.Forms.DataGridViewAutoSizeRowsMode"></see> value indicating the sizing mode. The default is <see cref="F:System.Windows.Forms.DataGridViewAutoSizeRowsMode.None"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is <see cref="F:System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders"></see> or <see cref="F:System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders"></see> and row headers are hidden. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.DataGridViewAutoSizeRowsMode"></see> value. </exception>
		/// 1</filterpriority>
		[SRDescription("DataGridView_AutoSizeRowsModeDescr")]
		[DefaultValue(DataGridViewAutoSizeRowsMode.None)]
		[SRCategory("CatLayout")]
		public DataGridViewAutoSizeRowsMode AutoSizeRowsMode
		{
			get
			{
				return menmAutoSizeRowsMode;
			}
			set
			{
				switch (value)
				{
				case DataGridViewAutoSizeRowsMode.AllHeaders:
				case DataGridViewAutoSizeRowsMode.DisplayedHeaders:
					if (!RowHeadersVisible)
					{
						throw new InvalidOperationException(SR.GetString("DataGridView_CannotAutoSizeRowsInvisibleRowHeader"));
					}
					goto case DataGridViewAutoSizeRowsMode.None;
				case DataGridViewAutoSizeRowsMode.None:
				case DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders:
				case DataGridViewAutoSizeRowsMode.AllCells:
				case DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders:
				case DataGridViewAutoSizeRowsMode.DisplayedCells:
				{
					DataGridViewAutoSizeRowsMode autoSizeRowsMode = AutoSizeRowsMode;
					if (autoSizeRowsMode != value)
					{
						DataGridViewAutoSizeModeEventArgs e = new DataGridViewAutoSizeModeEventArgs(autoSizeRowsMode != DataGridViewAutoSizeRowsMode.None);
						menmAutoSizeRowsMode = value;
						OnAutoSizeRowsModeChanged(e);
					}
					break;
				}
				default:
					throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewAutoSizeRowsMode));
				}
			}
		}

		/// Gets or sets the background color for the control.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the background color of the control. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultBackColor"></see> property.</returns>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		/// Gets or sets the background color of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the background color of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. The default is <see cref="P:System.Drawing.SystemColors.AppWorkspace"></see>. </returns>
		/// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:System.Drawing.Color.Empty"></see>. -or-The specified value when setting this property has a <see cref="P:System.Drawing.Color.A"></see> property value that is less that 255.</exception>
		/// 1</filterpriority>
		[SRDescription("DataGridViewBackgroundColorDescr")]
		[SRCategory("CatAppearance")]
		public Color BackgroundColor
		{
			get
			{
				return mobjBackgroundColor;
			}
			set
			{
				if (value.IsEmpty)
				{
					throw new ArgumentException(SR.GetString("DataGridView_EmptyColor", "BackgroundColor"));
				}
				if (value.A < byte.MaxValue)
				{
					throw new ArgumentException(SR.GetString("DataGridView_TransparentColor", "BackgroundColor"));
				}
				if (!value.Equals(BackgroundColor))
				{
					mobjBackgroundColor = value;
					OnBackgroundColorChanged(EventArgs.Empty);
					if (BackColor != value)
					{
						BackColor = value;
					}
				}
			}
		}

		/// Gets or sets the background image displayed in the control.</summary>
		/// An <see cref="T:System.Drawing.Image"></see> that represents the image to display in the background of the control.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override ResourceHandle BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
				base.BackgroundImage = value;
			}
		}

		/// Gets or sets the background image layout as defined in the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> enumeration.</summary>
		/// An <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> value indicating the background image layout. The default is <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override ImageLayout BackgroundImageLayout
		{
			get
			{
				return base.BackgroundImageLayout;
			}
			set
			{
				base.BackgroundImageLayout = value;
			}
		}

		/// Gets or sets the border style for the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.BorderStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.BorderStyle.FixedSingle"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.BorderStyle"></see> value. </exception>
		/// 1</filterpriority>
		[DefaultValue(1)]
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridView_BorderStyleDescr")]
		public override BorderStyle BorderStyle
		{
			get
			{
				return base.BorderStyle;
			}
			set
			{
				if (base.BorderStyle != value)
				{
					base.BorderStyle = value;
					OnBorderStyleChanged(EventArgs.Empty);
				}
			}
		}

		/// Gets the cell border style for the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellBorderStyle"></see> that represents the border style of the cells contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellBorderStyle"></see> value.</exception>
		/// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewCellBorderStyle.Custom"></see>.</exception>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellBorderStyleDescr")]
		[DefaultValue(DataGridViewCellBorderStyle.Single)]
		[SRCategory("CatAppearance")]
		[Browsable(true)]
		public DataGridViewCellBorderStyle CellBorderStyle
		{
			get
			{
				return menmCellBorderStyle;
			}
			set
			{
				if (CellBorderStyle != value && Enum.IsDefined(typeof(DataGridViewCellBorderStyle), value))
				{
					menmCellBorderStyle = value;
					UpdateParams(AttributeType.Visual);
					OnCellBorderStyleChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Gets the cell value event args.
		/// </summary>
		/// The cell value event args.</value>
		internal DataGridViewCellValueEventArgs CellValueEventArgs
		{
			get
			{
				if (mobjCellValueEventArgs == null)
				{
					mobjCellValueEventArgs = new DataGridViewCellValueEventArgs();
				}
				return mobjCellValueEventArgs;
			}
		}

		/// Gets or sets a value that indicates whether users can copy cell text values to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see> and whether row and column header text is included.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewClipboardCopyMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewClipboardCopyMode.EnableWithAutoHeaderText"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewClipboardCopyMode"></see> value.</exception>
		/// 1</filterpriority>
		[DefaultValue(DataGridViewClipboardCopyMode.EnableWithAutoHeaderText)]
		[Browsable(true)]
		[SRDescription("DataGridView_ClipboardCopyModeDescr")]
		[SRCategory("CatBehavior")]
		public DataGridViewClipboardCopyMode ClipboardCopyMode
		{
			get
			{
				return menmClipboardCopyMode;
			}
			set
			{
				menmClipboardCopyMode = value;
			}
		}

		/// Gets or sets the number of columns displayed in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// The number of columns displayed in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">When setting this property, the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property has been set. </exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than 0. </exception>
		/// 1</filterpriority>
		[DefaultValue(0)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int ColumnCount
		{
			get
			{
				return Columns.Count;
			}
			set
			{
				if (value < 0)
				{
					object[] arrArgs = new object[3]
					{
						"ColumnCount",
						value.ToString(CultureInfo.CurrentCulture),
						0.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("ColumnCount", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
				}
				if (DataSource != null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CannotSetColumnCountOnDataBoundDataGridView"));
				}
				if (value == Columns.Count)
				{
					return;
				}
				if (value == 0)
				{
					Columns.Clear();
					return;
				}
				if (value >= Columns.Count)
				{
					while (value > Columns.Count)
					{
						int count = Columns.Count;
						Columns.Add(null, null);
						if (Columns.Count <= count)
						{
							break;
						}
					}
					return;
				}
				while (value < Columns.Count)
				{
					int count2 = Columns.Count;
					Columns.RemoveAt(count2 - 1);
					if (Columns.Count >= count2)
					{
						break;
					}
				}
			}
		}

		/// Gets the border style applied to the column headers.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderBorderStyle"></see> values.</returns>
		/// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewHeaderBorderStyle.Custom"></see>.</exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderBorderStyle"></see> value.</exception>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[DefaultValue(DataGridViewHeaderBorderStyle.Raised)]
		[SRDescription("DataGridView_ColumnHeadersBorderStyleDescr")]
		[Browsable(true)]
		public DataGridViewHeaderBorderStyle ColumnHeadersBorderStyle
		{
			get
			{
				return DataGridViewHeaderBorderStyle.Raised;
			}
			set
			{
			}
		}

		/// Gets or sets the default column header style.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the default column header style.</returns>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ColumnHeadersDefaultCellStyleDescr")]
		[AmbientValue(null)]
		[SRCategory("CatAppearance")]
		public DataGridViewCellStyle ColumnHeadersDefaultCellStyle
		{
			get
			{
				if (mobjColumnHeadersDefaultCellStyle == null)
				{
					mobjColumnHeadersDefaultCellStyle = DefaultColumnHeadersDefaultCellStyle;
				}
				return mobjColumnHeadersDefaultCellStyle;
			}
			set
			{
				DataGridViewCellStyle columnHeadersDefaultCellStyle = ColumnHeadersDefaultCellStyle;
				columnHeadersDefaultCellStyle.RemoveScope(DataGridViewCellStyleScopes.ColumnHeaders);
				mobjColumnHeadersDefaultCellStyle = value;
				if (value != null)
				{
					mobjColumnHeadersDefaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.ColumnHeaders);
				}
				DataGridViewCellStyleDifferences differencesFrom = columnHeadersDefaultCellStyle.GetDifferencesFrom(ColumnHeadersDefaultCellStyle);
				if (differencesFrom != DataGridViewCellStyleDifferences.None)
				{
					CellStyleChangedEventArgs.ChangeAffectsPreferredSize = differencesFrom == DataGridViewCellStyleDifferences.AffectPreferredSize;
					OnColumnHeadersDefaultCellStyleChanged(CellStyleChangedEventArgs);
				}
			}
		}

		/// Gets or sets the height, in pixels, of the column headers row </summary>
		/// The height, in pixels, of the row that contains the column headers. The default is 23.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than the minimum height of 4 pixels or is greater than the maximum height of 32768 pixels.</exception>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[Localizable(true)]
		[SRDescription("DataGridView_ColumnHeadersHeightDescr")]
		public int ColumnHeadersHeight
		{
			get
			{
				return mintColumnHeadersHeight;
			}
			set
			{
				if (value < 4)
				{
					object[] arrArgs = new object[3]
					{
						"ColumnHeadersHeight",
						value.ToString(CultureInfo.CurrentCulture),
						4.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("ColumnHeadersHeight", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
				}
				if (value > 32768)
				{
					object[] arrArgs2 = new object[3]
					{
						"ColumnHeadersHeight",
						value.ToString(CultureInfo.CurrentCulture),
						32768.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("ColumnHeadersHeight", SR.GetString("InvalidHighBoundArgumentEx", arrArgs2));
				}
				if (ColumnHeadersHeightSizeMode != DataGridViewColumnHeadersHeightSizeMode.AutoSize && ColumnHeadersHeight != value)
				{
					SetColumnHeadersHeightInternal(value, blnInvalidInAdjustFillingColumns: true);
				}
			}
		}

		/// Gets or sets a value indicating whether the height of the column headers is adjustable and whether it can be adjusted by the user or is automatically adjusted to fit the contents of the headers. </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode"></see> value indicating the mode by which the height of the column headers row can be adjusted. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode"></see> value.</exception>
		[DefaultValue(DataGridViewColumnHeadersHeightSizeMode.EnableResizing)]
		[RefreshProperties(RefreshProperties.All)]
		[SRCategory("CatBehavior")]
		[SRDescription("DataGridView_ColumnHeadersHeightSizeModeDescr")]
		public DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode
		{
			get
			{
				return menmColumnHeadersHeightSizeMode;
			}
			set
			{
				if (ColumnHeadersHeightSizeMode != value)
				{
					DataGridViewAutoSizeModeEventArgs e = new DataGridViewAutoSizeModeEventArgs(ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize);
					menmColumnHeadersHeightSizeMode = value;
					OnColumnHeadersHeightSizeModeChanged(e);
				}
			}
		}

		/// Gets or sets a value indicating whether the column header row is displayed.</summary>
		/// true if the column headers are displayed; otherwise, false. The default is true.</returns>
		/// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is false and one or more columns have an <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> property value of <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see>.</exception>
		/// 1</filterpriority>
		[SRDescription("DataGridViewColumnHeadersVisibleDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(true)]
		public bool ColumnHeadersVisible
		{
			get
			{
				return mobjDataGridViewState1[8];
			}
			set
			{
				if (ColumnHeadersVisible == value)
				{
					return;
				}
				if (!value)
				{
					for (DataGridViewColumn dataGridViewColumn = Columns.GetFirstColumn(DataGridViewElementStates.Visible); dataGridViewColumn != null; dataGridViewColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
					{
						if (dataGridViewColumn.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.ColumnHeader)
						{
							throw new InvalidOperationException(SR.GetString("DataGridView_ColumnHeadersCannotBeInvisible"));
						}
					}
				}
				mobjDataGridViewState1[8] = value;
				Update();
			}
		}

		/// Gets a collection that contains all the columns in the control.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnCollection"></see> that contains all the columns in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</returns>
		/// 1</filterpriority>
		[MergableProperty(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		public DataGridViewColumnCollection Columns
		{
			get
			{
				if (mobjColumns == null)
				{
					mobjColumns = CreateColumnsInstance();
				}
				return mobjColumns;
			}
		}

		/// 
		/// Gets a value indicating whether this instance is delayed drawing.
		/// </summary>
		/// 
		/// 	true</c> if this instance is delayed drawing; otherwise, false</c>.
		/// </value>
		protected override bool IsDelayedDrawing => true;

		private bool InAdjustFillingColumns
		{
			get
			{
				if (!mobjDataGridViewOper[524288])
				{
					return mobjDataGridViewOper[262144];
				}
				return true;
			}
		}

		/// Gets or sets the currently active cell.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that represents the current cell, or null if there is no current cell. The default is the first cell in the first column or null if there are no cells in the control.</returns>
		/// <exception cref="T:System.ArgumentException">The specified cell when setting this property is not in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
		/// <exception cref="T:System.InvalidOperationException">The value of this property cannot be set because changes to the current cell cannot be committed or canceled.-or-The specified cell when setting this property is in a hidden row or column. </exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DataGridViewCell CurrentCell
		{
			get
			{
				if (mobjCurrentCellPoint.X == -1 && mobjCurrentCellPoint.Y == -1)
				{
					return null;
				}
				DataGridViewRow dataGridViewRow = Rows[mobjCurrentCellPoint.Y];
				return dataGridViewRow.Cells[mobjCurrentCellPoint.X];
			}
			set
			{
				SetCurrentCell(value, blnClientSource: false);
			}
		}

		/// 
		/// Gets a value indicating whether datagridview or any of its columns autosizemode set to fill.
		/// </summary>
		/// 
		/// 	true</c> if [need to adjust filling columns]; otherwise, false</c>.
		/// </value>
		internal bool NeedToAdjustFillingColumns
		{
			get
			{
				bool flag = AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill;
				foreach (DataGridViewColumn column in Columns)
				{
					if (column.AutoSizeMode == DataGridViewAutoSizeColumnMode.Fill || (flag && column.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet))
					{
						return true;
					}
				}
				return false;
			}
		}

		/// 
		/// Gets a value indicating whether [single vertical border added].
		/// </summary>
		/// 
		/// 	true</c> if [single vertical border added]; otherwise, false</c>.
		/// </value>
		internal bool SingleVerticalBorderAdded
		{
			get
			{
				if (mobjLayoutInfo.RowHeadersVisible)
				{
					return false;
				}
				if (AdvancedCellBorderStyle.All != DataGridViewAdvancedCellBorderStyle.Single)
				{
					return CellBorderStyle == DataGridViewCellBorderStyle.SingleVertical;
				}
				return true;
			}
		}

		/// 
		/// Gets a value indicating whether [single horizontal border added].
		/// </summary>
		/// 
		/// 	true</c> if [single horizontal border added]; otherwise, false</c>.
		/// </value>
		internal bool SingleHorizontalBorderAdded
		{
			get
			{
				if (mobjLayoutInfo.ColumnHeadersVisible)
				{
					return false;
				}
				if (AdvancedCellBorderStyle.All != DataGridViewAdvancedCellBorderStyle.Single)
				{
					return CellBorderStyle == DataGridViewCellBorderStyle.SingleHorizontal;
				}
				return true;
			}
		}

		/// Gets the row and column indexes of the currently active cell.</summary>
		/// A <see cref="T:System.Drawing.Point"></see> that represents the row and column indexes of the currently active cell.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public Point CurrentCellAddress => CurrentCellPoint;

		/// Gets the row containing the current cell.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that represents the row containing the current cell, or null if there is no current cell.</returns>
		[Browsable(false)]
		public DataGridViewRow CurrentRow
		{
			get
			{
				if (mobjCurrentCellPoint.X == -1)
				{
					return null;
				}
				return Rows[mobjCurrentCellPoint.Y];
			}
		}

		/// Gets or sets the name of the list or table in the data source for which the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is displaying data.</summary>
		/// The name of the table or list in the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> for which the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is displaying data. The default is <see cref="F:System.String.Empty"></see>.</returns>
		/// <exception cref="T:System.Exception">An error occurred in the data source and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
		/// 1</filterpriority>
		[Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[DefaultValue("")]
		[SRCategory("CatData")]
		[SRDescription("DataGridViewDataMemberDescr")]
		public string DataMember
		{
			get
			{
				if (DataConnection == null)
				{
					return string.Empty;
				}
				return DataConnection.DataMember;
			}
			set
			{
				if (value != DataMember)
				{
					CurrentCell = null;
					if (DataConnection == null)
					{
						DataConnection = new DataGridViewDataConnection(this);
					}
					DataConnection.SetDataConnection(DataSource, value);
					OnDataMemberChanged(EventArgs.Empty);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [lazy mode].
		/// </summary>
		/// true</c> if [lazy mode]; otherwise, false</c>.</value>
		[DefaultValue(false)]
		[SRCategory("CatData")]
		[SRDescription("DataGridViewLazyModeDescr")]
		public bool LazyMode
		{
			get
			{
				return mblnLazyMode;
			}
			set
			{
				mblnLazyMode = value;
			}
		}

		/// Gets or sets the data source that the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is displaying data for.</summary>
		/// The object that contains data for the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> to display.</returns>
		/// <exception cref="T:System.Exception">An error occurred in the data source and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
		/// 1</filterpriority>
		[SRDescription("DataGridViewDataSourceDescr")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRCategory("CatData")]
		[DefaultValue(null)]
		[AttributeProvider(typeof(Binding.IDataSourceAttributeProvider))]
		public object DataSource
		{
			get
			{
				if (DataConnection == null)
				{
					return null;
				}
				return DataConnection.DataSource;
			}
			set
			{
				if (value == DataSource)
				{
					return;
				}
				CurrentCell = null;
				if (DataConnection == null)
				{
					DataConnection = new DataGridViewDataConnection(this);
					DataConnection.SetDataConnection(value, DataMember);
				}
				else
				{
					if (DataConnection.ShouldChangeDataMember(value))
					{
						DataMember = "";
					}
					DataConnection.SetDataConnection(value, DataMember);
					if (value == null)
					{
						DataConnection = null;
					}
				}
				OnDataSourceChanged(EventArgs.Empty);
			}
		}

		/// 
		/// Gets the default background brush.
		/// </summary>
		/// The default background brush.</value>
		private static SolidBrush DefaultBackgroundBrush => (SolidBrush)SystemBrushes.AppWorkspace;

		/// 
		/// Gets the default back brush.
		/// </summary>
		/// The default back brush.</value>
		private static SolidBrush DefaultBackBrush => (SolidBrush)SystemBrushes.Window;

		/// 
		/// Gets the default fore brush.
		/// </summary>
		/// The default fore brush.</value>
		private static SolidBrush DefaultForeBrush => (SolidBrush)SystemBrushes.WindowText;

		/// 
		/// Gets the default headers back brush.
		/// </summary>
		/// The default headers back brush.</value>
		private static SolidBrush DefaultHeadersBackBrush => (SolidBrush)SystemBrushes.Control;

		/// 
		/// Gets the default selection back brush.
		/// </summary>
		/// The default selection back brush.</value>
		private static SolidBrush DefaultSelectionBackBrush => (SolidBrush)SystemBrushes.Highlight;

		/// 
		/// Gets the default selection fore brush.
		/// </summary>
		/// The default selection fore brush.</value>
		private static SolidBrush DefaultSelectionForeBrush => (SolidBrush)SystemBrushes.HighlightText;

		/// Gets or sets the default cell style to be applied to the cells in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> if no other cell style properties are set.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be applied as the default style.</returns>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridView_DefaultCellStyleDescr")]
		[AmbientValue(null)]
		public DataGridViewCellStyle DefaultCellStyle
		{
			get
			{
				if (mobjDefaultCellStyle == null)
				{
					mobjDefaultCellStyle = DefaultDefaultCellStyle;
					return mobjDefaultCellStyle;
				}
				if (mobjDefaultCellStyle.BackColor != Color.Empty && mobjDefaultCellStyle.ForeColor != Color.Empty && mobjDefaultCellStyle.SelectionBackColor != Color.Empty && mobjDefaultCellStyle.SelectionForeColor != Color.Empty && mobjDefaultCellStyle.Font != null && mobjDefaultCellStyle.Alignment != DataGridViewContentAlignment.NotSet && mobjDefaultCellStyle.WrapMode != DataGridViewTriState.NotSet)
				{
					return mobjDefaultCellStyle;
				}
				DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle(mobjDefaultCellStyle);
				dataGridViewCellStyle.Scope = DataGridViewCellStyleScopes.None;
				if (mobjDefaultCellStyle.BackColor == Color.Empty)
				{
					dataGridViewCellStyle.BackColor = DefaultBackBrush.Color;
				}
				if (mobjDefaultCellStyle.ForeColor == Color.Empty)
				{
					dataGridViewCellStyle.ForeColor = base.ForeColor;
					mobjDataGridViewState1[1024] = true;
				}
				if (mobjDefaultCellStyle.SelectionBackColor == Color.Empty)
				{
					dataGridViewCellStyle.SelectionBackColor = DefaultSelectionBackBrush.Color;
				}
				if (mobjDefaultCellStyle.SelectionForeColor == Color.Empty)
				{
					dataGridViewCellStyle.SelectionForeColor = DefaultSelectionForeBrush.Color;
				}
				if (mobjDefaultCellStyle.Font == null)
				{
					dataGridViewCellStyle.Font = base.Font;
					mobjDataGridViewState1[33554432] = true;
				}
				if (mobjDefaultCellStyle.Alignment == DataGridViewContentAlignment.NotSet)
				{
					dataGridViewCellStyle.AlignmentInternal = DataGridViewContentAlignment.MiddleLeft;
				}
				if (mobjDefaultCellStyle.WrapMode == DataGridViewTriState.NotSet)
				{
					dataGridViewCellStyle.WrapModeInternal = DataGridViewTriState.False;
				}
				dataGridViewCellStyle.AddScope(this, DataGridViewCellStyleScopes.DataGridView);
				return dataGridViewCellStyle;
			}
			set
			{
				DataGridViewCellStyle defaultCellStyle = DefaultCellStyle;
				defaultCellStyle.RemoveScope(DataGridViewCellStyleScopes.DataGridView);
				mobjDefaultCellStyle = value;
				if (value != null)
				{
					mobjDefaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.DataGridView);
				}
				DataGridViewCellStyleDifferences differencesFrom = defaultCellStyle.GetDifferencesFrom(DefaultCellStyle);
				if (differencesFrom != DataGridViewCellStyleDifferences.None)
				{
					CellStyleChangedEventArgs.ChangeAffectsPreferredSize = differencesFrom == DataGridViewCellStyleDifferences.AffectPreferredSize;
					OnDefaultCellStyleChanged(CellStyleChangedEventArgs);
				}
			}
		}

		/// 
		/// To be able to get the DefaultDefaultCellStyle from outside.
		/// </summary>
		internal DataGridViewCellStyle DefaultDefaultCellStyleInternal => DefaultDefaultCellStyle;

		/// 
		/// Gets the default default cell style.
		/// </summary>
		/// The default default cell style.</value>
		private DataGridViewCellStyle DefaultDefaultCellStyle
		{
			get
			{
				DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
				dataGridViewCellStyle.BackColor = DefaultBackBrush.Color;
				dataGridViewCellStyle.ForeColor = base.ForeColor;
				dataGridViewCellStyle.SelectionBackColor = DefaultSelectionBackBrush.Color;
				dataGridViewCellStyle.SelectionForeColor = DefaultSelectionForeBrush.Color;
				dataGridViewCellStyle.Font = base.Font;
				dataGridViewCellStyle.AlignmentInternal = DataGridViewContentAlignment.MiddleLeft;
				dataGridViewCellStyle.WrapModeInternal = DataGridViewTriState.False;
				dataGridViewCellStyle.AddScope(this, DataGridViewCellStyleScopes.DataGridView);
				mobjDataGridViewState1[33554432] = true;
				mobjDataGridViewState1[1024] = true;
				return dataGridViewCellStyle;
			}
		}

		/// Gets the default initial size of the control.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> representing the initial size of the control, which is 240 pixels wide by 150 pixels high.</returns>
		protected override Size DefaultSize => new Size(240, 150);

		/// Gets the panel that contains the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditingControl"></see>.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.Panel"></see> that contains the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditingControl"></see>.</returns>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public Panel EditingPanel => null;

		/// Gets or sets a value indicating how to begin editing a cell.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewEditMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewEditMode.EditOnKeystrokeOrF2"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewEditMode"></see> value.</exception>
		/// <exception cref="T:System.Exception">The specified value when setting this property would cause the control to enter edit mode, but initialization of the editing cell value failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
		/// 1</filterpriority>
		[DefaultValue(DataGridViewEditMode.EditOnKeystrokeOrF2)]
		[SRDescription("DataGridView_EditModeDescr")]
		[SRCategory("CatBehavior")]
		public DataGridViewEditMode EditMode
		{
			get
			{
				return menmEditMode;
			}
			set
			{
				DataGridViewEditMode dataGridViewEditMode = menmEditMode;
				if (dataGridViewEditMode != value)
				{
					menmEditMode = value;
					OnEditModeChanged(EventArgs.Empty);
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// Gets or sets a value indicating whether row and column headers use the visual styles of the user's current theme if visual styles are enabled for the application.</summary>
		/// true if visual styles are enabled for the headers; otherwise, false.</returns>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridView_EnableHeadersVisualStylesDescr")]
		[DefaultValue(true)]
		public bool EnableHeadersVisualStyles
		{
			get
			{
				return mobjDataGridViewState2[64];
			}
			set
			{
				if (mobjDataGridViewState2[64] != value)
				{
					mobjDataGridViewState2[64] = value;
					OnGlobalAutoSize();
				}
			}
		}

		/// Gets or sets the first cell currently displayed in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>; typically, this cell is in the upper left corner.</summary>
		/// The first <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> currently displayed in the control.</returns>
		/// <exception cref="T:System.ArgumentException">The specified cell when setting this property is not is not in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </exception>
		/// <exception cref="T:System.InvalidOperationException">The specified cell when setting this property has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.RowIndex"></see> or <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> property value of -1, indicating that it is a header cell or a shared cell. -or-The specified cell when setting this property has a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Visible"></see> property value of false.</exception>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DataGridViewCell FirstDisplayedCell
		{
			get
			{
				if (Rows.Count > 0)
				{
					DataGridViewRow dataGridViewRow = null;
					{
						IEnumerator enumerator = PageRows.GetEnumerator();
						try
						{
							if (enumerator.MoveNext())
							{
								DataGridViewRow dataGridViewRow2 = (DataGridViewRow)enumerator.Current;
								dataGridViewRow = dataGridViewRow2;
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
					}
					if (dataGridViewRow != null && dataGridViewRow.Cells.Count > 0)
					{
						return dataGridViewRow.Cells[0];
					}
				}
				return null;
			}
			set
			{
			}
		}

		/// Gets the width of the portion of the column that is currently scrolled out of view..</summary>
		/// The width of the portion of the column that is scrolled out of view.</returns>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public int FirstDisplayedScrollingColumnHiddenWidth => -1;

		/// Gets or sets the font of the text displayed by the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
		/// The <see cref="T:System.Drawing.Font"></see> to apply to the text displayed by the control. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultFont"></see> property.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether [disable navigation].
		/// </summary>
		/// true</c> if [disable navigation]; otherwise, false</c>.</value>
		[SRDescription("DataGridView_DisableNavigation")]
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		public bool DisableNavigation
		{
			get
			{
				return mblnDisableNavigation;
			}
			set
			{
				if (DisableNavigation != value)
				{
					mblnDisableNavigation = value;
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// Gets or sets the foreground color of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the foreground color of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. The default is the value of the <see cref="P:Gizmox.WebGUI.Forms.Control.DefaultForeColor"></see> property.</returns>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		/// Gets or sets the color of the grid lines separating the cells of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> or <see cref="T:System.Drawing.SystemColors"></see> that represents the color of the grid lines. The default is <see cref="F:System.Drawing.KnownColor.ControlDarkDark"></see>.</returns>
		/// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:System.Drawing.Color.Empty"></see>. -or-The specified value when setting this property has a <see cref="P:System.Drawing.Color.A"></see> property value that is less that 255.</exception>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridViewGridColorDescr")]
		public Color GridColor
		{
			get
			{
				return mobjGridColor;
			}
			set
			{
				mobjGridColor = value;
			}
		}

		/// Gets a value indicating whether the current cell has uncommitted changes.</summary>
		/// true if the current cell has uncommitted changes; otherwise, false.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public bool IsCurrentCellDirty => mobjDataGridViewState1[131072];

		/// 
		/// Gets or sets the max filter options.
		/// </summary>
		/// 
		/// The max filter options.
		/// </value>
		[DefaultValue(100)]
		public int MaxFilterOptions
		{
			get
			{
				return mintMaxFilterOptions;
			}
			set
			{
				if (mintMaxFilterOptions == value || value <= 0)
				{
					return;
				}
				mintMaxFilterOptions = value;
				if (mobjDataGridViewFilterRow == null)
				{
					return;
				}
				for (int i = 0; i < mobjDataGridViewFilterRow.Cells.Count; i++)
				{
					if (Columns[i].Visible)
					{
						(mobjDataGridViewFilterRow.Cells[i] as DataGridViewFilterCell).RefreshFilterCell();
					}
				}
			}
		}

		/// 
		/// Gets or sets the unedited formatted value.
		/// </summary>
		/// The unedited formatted value.</value>
		private object UneditedFormattedValue
		{
			get
			{
				return mobjUneditedFormattedValue;
			}
			set
			{
				mobjUneditedFormattedValue = value;
			}
		}

		/// 
		/// Sets a value indicating whether this instance is current cell dirty internal.
		/// </summary>
		/// 
		/// 	true</c> if this instance is current cell dirty internal; otherwise, false</c>.
		/// </value>
		private bool IsCurrentCellDirtyInternal
		{
			set
			{
				SetIsCurrentCellDirtyInternal(value, blnClientSource: false);
			}
		}

		/// Gets a value indicating whether the currently active cell is being edited.</summary>
		/// true if the current cell is being edited; otherwise, false.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public bool IsCurrentCellInEditMode
		{
			get
			{
				if (EditingControl == null)
				{
					return mobjDataGridViewState1[32768];
				}
				return true;
			}
		}

		/// Gets a value indicating whether the current row has uncommitted changes.</summary>
		/// true if the current row has uncommitted changes; otherwise, false.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public bool IsCurrentRowDirty
		{
			get
			{
				if (!VirtualMode)
				{
					if (!mobjDataGridViewState1[262144])
					{
						return IsCurrentCellDirty;
					}
					return true;
				}
				QuestionEventArgs e = new QuestionEventArgs(mobjDataGridViewState1[262144] || IsCurrentCellDirty);
				OnRowDirtyStateNeeded(e);
				return e.Response;
			}
		}

		/// 
		/// Gets or sets the data connection.
		/// </summary>
		/// The data connection.</value>
		internal DataGridViewDataConnection DataConnection
		{
			get
			{
				return mobjDataConnection;
			}
			set
			{
				mobjDataConnection = value;
			}
		}

		/// Gets or sets the cell located at the intersection of the row with the specified index and the column with the specified name. </summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> at the specified location.</returns>
		/// <param name="strColumnName">The name of the column containing the cell.</param>
		/// <param name="intRowIndex">The index of the row containing the cell.</param>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DataGridViewCell this[string strColumnName, int intRowIndex]
		{
			get
			{
				DataGridViewRow dataGridViewRow = Rows[intRowIndex];
				return dataGridViewRow.Cells[strColumnName];
			}
			set
			{
				DataGridViewRow dataGridViewRow = Rows[intRowIndex];
				dataGridViewRow.Cells[strColumnName] = value;
			}
		}

		/// Gets or sets the cell located at the intersection of the row and column with the specified indexes. </summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> at the specified location.</returns>
		/// <param name="intColumnIndex">The index of the column containing the cell.</param>
		/// <param name="intRowIndex">The index of the row containing the cell.</param>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public DataGridViewCell this[int intColumnIndex, int intRowIndex]
		{
			get
			{
				DataGridViewRow dataGridViewRow = Rows[intRowIndex];
				return dataGridViewRow.Cells[intColumnIndex];
			}
			set
			{
				DataGridViewRow dataGridViewRow = Rows[intRowIndex];
				dataGridViewRow.Cells[intColumnIndex] = value;
			}
		}

		/// Gets or sets a value indicating whether the user is allowed to select more than one cell, row, or column of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> at a time.</summary>
		/// true if the user can select more than one cell, row, or column at a time; otherwise, false. The default is true.</returns>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		[SRDescription("DataGridView_MultiSelectDescr")]
		public bool MultiSelect
		{
			get
			{
				return mobjDataGridViewState1[128];
			}
			set
			{
				if (MultiSelect != value)
				{
					ClearSelection();
					mobjDataGridViewState1[128] = value;
					OnMultiSelectChanged(EventArgs.Empty);
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// Gets the index of the row for new records.</summary>
		/// The index of the row for new records, or -1 if <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> is false.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int NewRowIndex
		{
			get
			{
				return mintNewRowIndex;
			}
			set
			{
				mintNewRowIndex = value;
			}
		}

		/// This property is not relevant for this control.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> instance.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override Padding Padding
		{
			get
			{
				return base.Padding;
			}
			set
			{
				base.Padding = value;
			}
		}

		/// Gets a value indicating whether the user can edit the cells of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
		/// true if the user cannot edit the cells of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control; otherwise, false. The default is false.</returns>
		/// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is true, the current cell is in edit mode, and the current cell contains changes that cannot be committed. </exception>
		/// <exception cref="T:System.Exception">The specified value when setting this property would cause the control to enter edit mode, but initialization of the editing cell value failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ReadOnlyDescr")]
		[DefaultValue(false)]
		[Browsable(true)]
		[SRCategory("CatBehavior")]
		public bool ReadOnly
		{
			get
			{
				return mobjDataGridViewState1[1048576];
			}
			set
			{
				if (value == mobjDataGridViewState1[1048576])
				{
					return;
				}
				if (IsCurrentCellInEditMode)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CommitFailedCannotCompleteOperation"));
				}
				mobjDataGridViewState1[1048576] = value;
				if (value)
				{
					try
					{
						mobjDataGridViewOper[16384] = true;
						for (int i = 0; i < Columns.Count; i++)
						{
							SetReadOnlyColumnCore(i, blnReadOnly: false);
						}
						int count = Rows.Count;
						for (int j = 0; j < count; j++)
						{
							SetReadOnlyRowCore(j, blnReadOnly: false);
						}
					}
					finally
					{
						mobjDataGridViewOper[16384] = false;
					}
				}
				OnReadOnlyChanged(EventArgs.Empty);
				Update();
			}
		}

		/// 
		/// Gets or sets the current page internal.
		/// </summary>
		/// The current page internal.</value>
		private int CurrentPageInternal
		{
			get
			{
				return mintCurrentPage;
			}
			set
			{
				mintCurrentPage = value;
			}
		}

		/// 
		/// Gets or sets the items per page internal.
		/// </summary>
		/// The items per page internal.</value>
		private int ItemsPerPageInternal
		{
			get
			{
				return mintItemsPerPage;
			}
			set
			{
				mintItemsPerPage = value;
			}
		}

		/// 
		/// Gets or sets the virtual block size internal.
		/// </summary>
		/// The virtual block size internal.</value>
		private int VirtualBlockSizeInternal
		{
			get
			{
				return mintVirtualBlockSize;
			}
			set
			{
				mintVirtualBlockSize = value;
			}
		}

		/// 
		/// Gets or sets the total pages internal.
		/// </summary>
		/// The total pages internal.</value>
		private int TotalPagesInternal
		{
			get
			{
				return mintTotalPages;
			}
			set
			{
				mintTotalPages = value;
			}
		}

		/// 
		/// Gets the hanlder for the PagingChanged event.
		/// </summary>
		private EventHandler PagingChangedHandler => (EventHandler)GetHandler(PagingChanged);

		/// 
		/// Uses internal paging algorithem
		/// </summary>
		[DefaultValue(true)]
		public virtual bool UseInternalPaging
		{
			get
			{
				return mblnUseInternalPaging;
			}
			set
			{
				if (mblnUseInternalPaging != value)
				{
					mblnUseInternalPaging = value;
					Update();
				}
			}
		}

		/// 
		/// Gets the first item's index in the current page
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("PageFirstIndex property is obsolete use FirstDisplayedRowIndex instead")]
		public int PageFirstIndex => -1;

		/// 
		/// Gets the last item's index in the current page
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("PageLastIndex property is obsolete use PageRows.Count instead")]
		public int PageLastIndex => -1;

		/// 
		/// Gets or sets the total items.
		/// </summary>
		/// </value>
		[DefaultValue(0)]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("TotalItems property is obsolete use GetRowCount() instead")]
		public int TotalItems
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		/// 
		/// Gets the page rows.
		/// </summary>
		/// The page rows.</value>
		internal IList PageRows
		{
			get
			{
				bool blnPageContainsFrozenRows = false;
				return GetPagedRows(out blnPageContainsFrozenRows);
			}
		}

		/// 
		/// Gets or sets the current page.
		/// </summary>
		/// </value>
		[DefaultValue(1)]
		public int CurrentPage
		{
			get
			{
				return CurrentPageInternal;
			}
			set
			{
				if (value > -1 && value <= TotalPages)
				{
					if (CurrentPageInternal != value)
					{
						CurrentPageInternal = value;
						if (UseInternalPaging)
						{
							base.ScrollTop = 0;
							Update();
						}
					}
					return;
				}
				throw new ArgumentOutOfRangeException("CurrentPage");
			}
		}

		/// 
		/// Gets a value indicating whether this instance is initializing.
		/// </summary>
		/// 
		/// 	true</c> if this instance is initializing; otherwise, false</c>.
		/// </value>
		private bool IsInitializing => mobjDataGridViewState2[524288];

		/// 
		/// Gets or sets the current page.
		/// </summary>
		/// </value>
		[DefaultValue(20)]
		public int ItemsPerPage
		{
			get
			{
				return ItemsPerPageInternal;
			}
			set
			{
				if (ItemsPerPageInternal != value)
				{
					if (value <= 0)
					{
						throw new ArgumentOutOfRangeException("CurrentPage");
					}
					ItemsPerPageInternal = value;
					ClearPaging();
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the size of the virtual block.
		/// </summary>
		/// The size of the virtual block.</value>
		[DefaultValue(20)]
		[SRCategory("CatBehavior")]
		[SRDescription("DataGridView_VirtualBlockSizeDescr")]
		public int VirtualBlockSize
		{
			get
			{
				return VirtualBlockSizeInternal;
			}
			set
			{
				if (VirtualBlockSizeInternal != value)
				{
					if (value <= 0)
					{
						throw new ArgumentOutOfRangeException("VirtualBlockSize");
					}
					VirtualBlockSizeInternal = value;
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the total pages.
		/// </summary>
		/// </value>
		[DefaultValue(1)]
		public int TotalPages
		{
			get
			{
				if (!UseInternalPaging)
				{
					return TotalPagesInternal;
				}
				double num = TotalVisibleItems;
				if (num == 0.0)
				{
					return 1;
				}
				return Convert.ToInt32((int)Math.Ceiling(num / (double)ItemsPerPage));
			}
			set
			{
				if (!UseInternalPaging)
				{
					if (value < 0)
					{
						throw new ArgumentOutOfRangeException("TotalPages");
					}
					if (TotalPagesInternal != value)
					{
						TotalPagesInternal = value;
						Update();
					}
				}
			}
		}

		/// 
		/// Gets the total visible rows.
		/// </summary>
		/// The total visible rows.</value>
		private int TotalVisibleItems
		{
			get
			{
				int num = Rows.GetRowCount(DataGridViewElementStates.Visible);
				if (num > 0 && IsNewRowVisible())
				{
					num--;
				}
				return num;
			}
		}

		/// 
		/// Gets the inherited editing cell style.
		/// </summary>
		/// The inherited editing cell style.</value>
		private DataGridViewCellStyle InheritedEditingCellStyle
		{
			get
			{
				if (mobjCurrentCellPoint.X == -1)
				{
					return null;
				}
				return CurrentCellInternal.GetInheritedStyleInternal(mobjCurrentCellPoint.Y);
			}
		}

		/// 
		/// Gets a value indicating whether [right to left internal].
		/// </summary>
		/// 
		/// 	true</c> if [right to left internal]; otherwise, false</c>.
		/// </value>
		internal bool RightToLeftInternal
		{
			get
			{
				if (!mobjDataGridViewState2[4096])
				{
					mobjDataGridViewState2[2048] = RightToLeft == RightToLeft.Yes;
					mobjDataGridViewState2[4096] = true;
				}
				return mobjDataGridViewState2[2048];
			}
		}

		/// 
		/// Gets a value indicating whether animation is enabled by default.
		/// </summary>
		/// true</c> if animation is enabled by default; otherwise, false</c>.</value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		internal bool DefaultAnimationEnabled => base.AnimationEnabled;

		/// Gets or sets the number of rows displayed in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// The number of rows to display in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		/// <exception cref="T:System.ArgumentException">The specified value when setting this property is less than 0.-or-The specified value is less than 1 and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> is set to true. </exception>
		/// <exception cref="T:System.InvalidOperationException">When setting this property, the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property is set. </exception>
		/// 1</filterpriority>
		[DefaultValue(0)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public int RowCount
		{
			get
			{
				return Rows.Count;
			}
			set
			{
				if (AllowUserToAddRowsInternal)
				{
					if (value < 1)
					{
						object[] arrArgs = new object[3]
						{
							"RowCount",
							value.ToString(CultureInfo.CurrentCulture),
							1.ToString(CultureInfo.CurrentCulture)
						};
						throw new ArgumentOutOfRangeException("RowCount", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
					}
				}
				else if (value < 0)
				{
					object[] arrArgs2 = new object[3]
					{
						"RowCount",
						value.ToString(CultureInfo.CurrentCulture),
						0.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("RowCount", SR.GetString("InvalidLowBoundArgumentEx", arrArgs2));
				}
				if (DataSource != null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CannotSetRowCountOnDataBoundDataGridView"));
				}
				DataGridViewRowCollection rows = Rows;
				if (value == rows.Count)
				{
					return;
				}
				if (value == 0)
				{
					rows.Clear();
					return;
				}
				if (value < rows.Count)
				{
					while (value < rows.Count)
					{
						int count = rows.Count;
						rows.RemoveAt(count - ((!AllowUserToAddRowsInternal) ? 1 : 2));
						if (rows.Count >= count)
						{
							break;
						}
					}
					return;
				}
				if (Columns.Count == 0)
				{
					Columns.Add(GetDataGridViewDefaultColumn());
				}
				int num = value - rows.Count;
				if (num > 0)
				{
					rows.Add(num);
				}
			}
		}

		/// 
		/// Gets or sets the selection change count.
		/// </summary>
		/// The selection change count.</value>
		private int SelectionChangeCount
		{
			get
			{
				return mintSelectionChangeCount;
			}
			set
			{
				mintSelectionChangeCount = value;
			}
		}

		/// 
		/// Gets or sets the dimension change count.
		/// </summary>
		/// The dimension change count.</value>
		private int DimensionChangeCount
		{
			get
			{
				return mintDimensionChangeCount;
			}
			set
			{
				mintDimensionChangeCount = value;
			}
		}

		/// Gets or sets the border style of the row header cells.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderBorderStyle"></see> values.</returns>
		/// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewHeaderBorderStyle.Custom"></see>.</exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderBorderStyle"></see> value.</exception>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[DefaultValue(DataGridViewHeaderBorderStyle.None)]
		[Browsable(true)]
		[SRDescription("DataGridView_RowHeadersBorderStyleDescr")]
		public DataGridViewHeaderBorderStyle RowHeadersBorderStyle
		{
			get
			{
				return mobjAdvancedDataGridViewBorderStyle.All switch
				{
					DataGridViewAdvancedCellBorderStyle.NotSet => DataGridViewHeaderBorderStyle.Custom, 
					DataGridViewAdvancedCellBorderStyle.None => DataGridViewHeaderBorderStyle.None, 
					DataGridViewAdvancedCellBorderStyle.Single => DataGridViewHeaderBorderStyle.Single, 
					DataGridViewAdvancedCellBorderStyle.InsetDouble => DataGridViewHeaderBorderStyle.Sunken, 
					DataGridViewAdvancedCellBorderStyle.OutsetPartial => DataGridViewHeaderBorderStyle.Raised, 
					_ => DataGridViewHeaderBorderStyle.Custom, 
				};
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 4))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewHeaderBorderStyle));
				}
				if (value == RowHeadersBorderStyle)
				{
					return;
				}
				if (value == DataGridViewHeaderBorderStyle.Custom)
				{
					throw new ArgumentException(SR.GetString("DataGridView_CustomCellBorderStyleInvalid", "RowHeadersBorderStyle"));
				}
				mobjDataGridViewOper[65536] = true;
				try
				{
					switch (value)
					{
					case DataGridViewHeaderBorderStyle.Single:
						mobjAdvancedDataGridViewBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Single;
						OnRowHeadersBorderStyleChanged(EventArgs.Empty);
						break;
					case DataGridViewHeaderBorderStyle.Raised:
						mobjAdvancedDataGridViewBorderStyle.All = DataGridViewAdvancedCellBorderStyle.OutsetPartial;
						OnRowHeadersBorderStyleChanged(EventArgs.Empty);
						break;
					case DataGridViewHeaderBorderStyle.Sunken:
						mobjAdvancedDataGridViewBorderStyle.All = DataGridViewAdvancedCellBorderStyle.InsetDouble;
						OnRowHeadersBorderStyleChanged(EventArgs.Empty);
						break;
					case DataGridViewHeaderBorderStyle.None:
						mobjAdvancedDataGridViewBorderStyle.All = DataGridViewAdvancedCellBorderStyle.None;
						OnRowHeadersBorderStyleChanged(EventArgs.Empty);
						break;
					}
				}
				finally
				{
					mobjDataGridViewOper[65536] = false;
				}
			}
		}

		internal DataGridViewCellStyle DefaultColumnHeadersDefaultCellStyleInternal => DefaultColumnHeadersDefaultCellStyle;

		internal DataGridViewCellStyle DefaultRowHeadersDefaultCellStyleInternal => DefaultRowHeadersDefaultCellStyle;

		private DataGridViewCellStyle DefaultColumnHeadersDefaultCellStyle
		{
			get
			{
				DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
				dataGridViewCellStyle.BackColor = DefaultHeadersBackBrush.Color;
				dataGridViewCellStyle.ForeColor = DefaultForeBrush.Color;
				dataGridViewCellStyle.SelectionBackColor = DefaultSelectionBackBrush.Color;
				dataGridViewCellStyle.SelectionForeColor = DefaultSelectionForeBrush.Color;
				dataGridViewCellStyle.Font = base.Font;
				dataGridViewCellStyle.AlignmentInternal = DataGridViewContentAlignment.MiddleLeft;
				dataGridViewCellStyle.WrapModeInternal = DataGridViewTriState.True;
				dataGridViewCellStyle.AddScope(this, DataGridViewCellStyleScopes.ColumnHeaders);
				mobjDataGridViewState1[67108864] = true;
				return dataGridViewCellStyle;
			}
		}

		private DataGridViewCellStyle DefaultRowHeadersDefaultCellStyle
		{
			get
			{
				DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
				dataGridViewCellStyle.BackColor = DefaultHeadersBackBrush.Color;
				dataGridViewCellStyle.ForeColor = DefaultForeBrush.Color;
				dataGridViewCellStyle.SelectionBackColor = DefaultSelectionBackBrush.Color;
				dataGridViewCellStyle.SelectionForeColor = DefaultSelectionForeBrush.Color;
				dataGridViewCellStyle.Font = base.Font;
				dataGridViewCellStyle.AlignmentInternal = DataGridViewContentAlignment.MiddleLeft;
				dataGridViewCellStyle.WrapModeInternal = DataGridViewTriState.True;
				dataGridViewCellStyle.AddScope(this, DataGridViewCellStyleScopes.RowHeaders);
				mobjDataGridViewState1[134217728] = true;
				return dataGridViewCellStyle;
			}
		}

		private DataGridViewCellStyleChangedEventArgs CellStyleChangedEventArgs
		{
			get
			{
				if (mobjCellStyleChangedEventArgs == null)
				{
					mobjCellStyleChangedEventArgs = new DataGridViewCellStyleChangedEventArgs();
				}
				return mobjCellStyleChangedEventArgs;
			}
		}

		/// 
		/// Gets or sets the selected band indexes.
		/// </summary>
		/// The selected band indexes.</value>
		private DataGridViewIntLinkedList SelectedBandIndexes
		{
			get
			{
				return mobjSelectedBandIndexes;
			}
			set
			{
				mobjSelectedBandIndexes = value;
			}
		}

		/// 
		/// Gets or sets the individual selected cells.
		/// </summary>
		/// The individual selected cells.</value>
		private DataGridViewCellLinkedList IndividualSelectedCells
		{
			get
			{
				return mobjIndividualSelectedCells;
			}
			set
			{
				mobjIndividualSelectedCells = value;
			}
		}

		/// 
		/// Gets or sets the selected band snapshot indexes.
		/// </summary>
		/// The selected band snapshot indexes.</value>
		private DataGridViewIntLinkedList SelectedBandSnapshotIndexes
		{
			get
			{
				return mobjSelectedBandSnapshotIndexes;
			}
			set
			{
				mobjSelectedBandSnapshotIndexes = value;
			}
		}

		/// Gets or sets the default style applied to the row header cells.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the default style applied to the row header cells.</returns>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridView_RowHeadersDefaultCellStyleDescr")]
		[AmbientValue(null)]
		public DataGridViewCellStyle RowHeadersDefaultCellStyle
		{
			get
			{
				if (mobjRowHeadersDefaultCellStyle == null)
				{
					mobjRowHeadersDefaultCellStyle = DefaultRowHeadersDefaultCellStyle;
				}
				return mobjRowHeadersDefaultCellStyle;
			}
			set
			{
				DataGridViewCellStyle rowHeadersDefaultCellStyle = RowHeadersDefaultCellStyle;
				rowHeadersDefaultCellStyle.RemoveScope(DataGridViewCellStyleScopes.RowHeaders);
				mobjRowHeadersDefaultCellStyle = value;
				if (value != null)
				{
					mobjRowHeadersDefaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.RowHeaders);
				}
				DataGridViewCellStyleDifferences differencesFrom = rowHeadersDefaultCellStyle.GetDifferencesFrom(RowHeadersDefaultCellStyle);
				if (differencesFrom != DataGridViewCellStyleDifferences.None)
				{
					CellStyleChangedEventArgs.ChangeAffectsPreferredSize = differencesFrom == DataGridViewCellStyleDifferences.AffectPreferredSize;
					OnRowHeadersDefaultCellStyleChanged(CellStyleChangedEventArgs);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether the column that contains row headers is displayed.
		/// </summary>
		/// true</c> if [row headers visible]; otherwise, false</c>.</value>
		/// true if the column that contains row headers is displayed; otherwise, false. The default is true.</returns>
		/// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is false and the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AutoSizeRowsMode"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.AllHeaders"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders"></see>.</exception>
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridViewRowHeadersVisibleDescr")]
		[DefaultValue(true)]
		public bool RowHeadersVisible
		{
			get
			{
				return mobjDataGridViewState1[16];
			}
			set
			{
				if (RowHeadersVisible != value)
				{
					mobjDataGridViewState1[16] = value;
					Update();
					if (NeedToAdjustFillingColumns)
					{
						ResetUIState(blnUseRowShortcut: false, blnComputeVisibleRows: false);
					}
				}
			}
		}

		/// 
		/// Sets a value indicating whether this instance is current row dirty internal.
		/// </summary>
		/// 
		/// 	true</c> if this instance is current row dirty internal; otherwise, false</c>.
		/// </value>
		internal bool IsCurrentRowDirtyInternal
		{
			set
			{
				SetIsCurrentRowDirtyInternal(value, blnClientSource: false);
			}
		}

		/// 
		/// Gets or sets the layout info.
		/// </summary>
		/// The layout info.</value>
		internal LayoutData LayoutInfo
		{
			get
			{
				LayoutData layoutData = mobjLayoutInfo;
				if (layoutData.dirty && base.IsHandleCreated)
				{
					PerformLayoutPrivate(blnInvalidInAdjustFillingColumns: false);
				}
				return layoutData;
			}
			set
			{
				mobjLayoutInfo = value;
			}
		}

		/// Gets or sets the width, in pixels, of the column that contains the row headers.</summary>
		/// The width, in pixels, of the column that contains row headers. The default is 43.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than the minimum width of 4 pixels or is greater than the maximum width of 32768 pixels.</exception>
		/// 1</filterpriority>
		[Localizable(true)]
		[SRDescription("DataGridView_RowHeadersWidthDescr")]
		[SRCategory("CatLayout")]
		[DefaultValue(41)]
		public int RowHeadersWidth
		{
			get
			{
				return mintRowHeadersWidth;
			}
			set
			{
				if (value < 4)
				{
					object[] arrArgs = new object[3]
					{
						"RowHeadersWidth",
						value.ToString(CultureInfo.CurrentCulture),
						4.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("RowHeadersWidth", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
				}
				if (value > 32768)
				{
					object[] arrArgs2 = new object[3]
					{
						"RowHeadersWidth",
						value.ToString(CultureInfo.CurrentCulture),
						32768.ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("RowHeadersWidth", SR.GetString("InvalidHighBoundArgumentEx", arrArgs2));
				}
				if (RowHeadersWidth != value)
				{
					Update();
				}
				if ((RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing || RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.DisableResizing) && RowHeadersWidth != value)
				{
					RowHeadersWidthInternal = value;
				}
			}
		}

		/// 
		/// Sets the row headers width internal.
		/// </summary>
		/// The row headers width internal.</value>
		private int RowHeadersWidthInternal
		{
			set
			{
				mintRowHeadersWidth = value;
				OnRowHeadersWidthChanged(EventArgs.Empty);
			}
		}

		/// Gets or sets a value indicating whether the width of the row headers is adjustable and whether it can be adjusted by the user or is automatically adjusted to fit the contents of the headers. </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value indicating the mode by which the width of the row headers can be adjusted. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value.</exception>
		[RefreshProperties(RefreshProperties.All)]
		[SRDescription("DataGridView_RowHeadersWidthSizeModeDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(DataGridViewRowHeadersWidthSizeMode.EnableResizing)]
		public DataGridViewRowHeadersWidthSizeMode RowHeadersWidthSizeMode
		{
			get
			{
				return menmRowHeadersWidthSizeMode;
			}
			set
			{
				DataGridViewRowHeadersWidthSizeMode rowHeadersWidthSizeMode = RowHeadersWidthSizeMode;
				if (menmRowHeadersWidthSizeMode != value)
				{
					DataGridViewAutoSizeModeEventArgs e = new DataGridViewAutoSizeModeEventArgs(rowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.EnableResizing && rowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.DisableResizing);
					menmRowHeadersWidthSizeMode = value;
					OnRowHeadersWidthSizeModeChanged(e);
				}
			}
		}

		/// Gets a collection that contains all the rows in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> that contains all the rows in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public DataGridViewRowCollection Rows
		{
			get
			{
				if (mobjRows == null)
				{
					mobjRows = CreateRowsInstance();
				}
				return mobjRows;
			}
		}

		/// 
		/// Gets the hierarchic infos.
		/// </summary>
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ObservableCollection<object> HierarchicInfos
		{
			get
			{
				if (mobjHierarchicInfos == null)
				{
					HierarchicInfos = new ObservableCollection<object>();
				}
				return mobjHierarchicInfos;
			}
			set
			{
				if (mobjHierarchicInfos == value)
				{
					return;
				}
				if (mobjHierarchicInfos != null)
				{
					AddRemoveHierarchicInfosEvents(blnIsAdd: false);
				}
				mobjHierarchicInfos = value;
				if (mobjHierarchicInfos != null)
				{
					if (!(this is HierarchicDataGridView))
					{
						RootGrid = this;
						mintHierarchyLevel = 0;
					}
					AddRemoveHierarchicInfosEvents(blnIsAdd: true);
					ResetDataBinding();
				}
			}
		}

		/// 
		/// Gets or sets the system hierarchic infos.
		/// </summary>
		/// 
		/// The system hierarchic infos.
		/// </value>
		internal ObservableCollection<object> SystemHierarchicInfos
		{
			get
			{
				if (mobjSystemHierarchicInfos == null)
				{
					SystemHierarchicInfos = new ObservableCollection<object>();
				}
				return mobjSystemHierarchicInfos;
			}
			set
			{
				if (mobjSystemHierarchicInfos != value)
				{
					mobjSystemHierarchicInfos = value;
					if (!(this is HierarchicDataGridView))
					{
						RootGrid = this;
						mintHierarchyLevel = 0;
					}
				}
			}
		}

		/// 
		/// Gets or sets the data groups.
		/// </summary>
		/// 
		/// The data groups.
		/// </value>
		[Editor("Gizmox.WebGUI.Forms.Design.DataGridViewGroupingColumnsEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public UniqueObservableCollection<object> GroupingColumns
		{
			get
			{
				if (mobjGroupingColumns == null)
				{
					GroupingColumns = new UniqueObservableCollection<object>();
				}
				return mobjGroupingColumns;
			}
			set
			{
				if (value != mobjGroupingColumns)
				{
					if (mobjGroupingColumns != null)
					{
						AddRemoveGroupingColumnEvents(blnIsAdd: false);
					}
					mobjGroupingColumns = value;
					AddRemoveGroupingColumnEvents(blnIsAdd: true);
				}
			}
		}

		/// Gets or sets the default style applied to the row cells of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to apply to the row cells of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridView_RowsDefaultCellStyleDescr")]
		public DataGridViewCellStyle RowsDefaultCellStyle
		{
			get
			{
				if (mobjRowsDefaultCellStyle == null)
				{
					mobjRowsDefaultCellStyle = new DataGridViewCellStyle();
					mobjRowsDefaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.Rows);
				}
				return mobjRowsDefaultCellStyle;
			}
			set
			{
				mobjRowsDefaultCellStyle = RowsDefaultCellStyle;
				mobjRowsDefaultCellStyle.RemoveScope(DataGridViewCellStyleScopes.Rows);
				mobjRowsDefaultCellStyle = value;
				if (value != null)
				{
					mobjRowsDefaultCellStyle.AddScope(this, DataGridViewCellStyleScopes.Rows);
				}
				DataGridViewCellStyleDifferences differencesFrom = mobjRowsDefaultCellStyle.GetDifferencesFrom(RowsDefaultCellStyle);
				if (differencesFrom != DataGridViewCellStyleDifferences.None)
				{
					CellStyleChangedEventArgs.ChangeAffectsPreferredSize = differencesFrom == DataGridViewCellStyleDifferences.AffectPreferredSize;
					OnRowsDefaultCellStyleChanged(CellStyleChangedEventArgs);
				}
			}
		}

		/// 
		/// Gets or sets the latest editing control.
		/// </summary>
		/// The latest editing control.</value>
		private Control LatestEditingControl
		{
			get
			{
				return mobjLatestEditingControl;
			}
			set
			{
				mobjLatestEditingControl = value;
			}
		}

		/// Gets or sets the row that represents the template for all the rows in the control.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> representing the row template.</returns>
		/// <exception cref="T:System.InvalidOperationException">The specified row when setting this property has its <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property set.</exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRCategory("CatAppearance")]
		[Browsable(true)]
		[SRDescription("DataGridView_RowTemplateDescr")]
		public DataGridViewRow RowTemplate
		{
			get
			{
				if (mobjRowTemplate == null)
				{
					mobjRowTemplate = new DataGridViewRow();
				}
				return mobjRowTemplate;
			}
			set
			{
				if (value != null && value.DataGridView != null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_RowAlreadyBelongsToDataGridView"));
				}
				mobjRowTemplate = value;
			}
		}

		internal DataGridViewRow RowTemplateClone
		{
			get
			{
				DataGridViewRow dataGridViewRow = (DataGridViewRow)RowTemplate.Clone();
				CompleteCellsCollection(dataGridViewRow);
				return dataGridViewRow;
			}
		}

		/// Gets or sets the type of scroll bars to display for the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.ScrollBars"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.ScrollBars.Both"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.ScrollBars"></see> value. </exception>
		/// <exception cref="T:System.InvalidOperationException">The value of this property cannot be set because the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is unable to scroll due to a cell change that cannot be committed or canceled. </exception>
		/// 1</filterpriority>
		[SRCategory("CatLayout")]
		[DefaultValue(ScrollBars.Both)]
		[Localizable(true)]
		[SRDescription("DataGridView_ScrollBarsDescr")]
		public ScrollBars ScrollBars
		{
			get
			{
				return menmScrollBars;
			}
			set
			{
				if (menmScrollBars != value)
				{
					menmScrollBars = value;
					UpdateParams(AttributeType.Layout);
				}
			}
		}

		/// Gets or sets a value indicating whether to show cell errors.</summary>
		/// true if a red glyph will appear in a cell that fails validation; otherwise, false. The default is true.</returns>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ShowCellErrorsDescr")]
		[DefaultValue(true)]
		[SRCategory("CatAppearance")]
		public bool ShowCellErrors
		{
			get
			{
				return mobjDataGridViewState2[128];
			}
			set
			{
				if (ShowCellErrors != value)
				{
					mobjDataGridViewState2[128] = value;
					if (!base.DesignMode)
					{
						OnGlobalAutoSize();
					}
				}
			}
		}

		/// 
		/// Gets the grouping area style properties.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public GroupingAreaStyleProperties GroupingAreaStyleProperties => new GroupingAreaStyleProperties(this);

		/// 
		/// Gets or sets a value indicating whether to [show grouping drop area].
		/// </summary>
		/// 
		/// 	true</c> if [show grouping drop area]; otherwise, false</c>.
		/// </value>
		[Description("Gets or sets a value indicating whether to show the grouping drop area.")]
		[DefaultValue(false)]
		[Category("CatAppearance")]
		public bool ShowGroupingDropArea
		{
			get
			{
				return mblnShowGroupingDropArea;
			}
			set
			{
				if (mblnShowGroupingDropArea != value)
				{
					if (value && AllowUserToOrderColumns)
					{
						throw new InvalidOperationException("Columns reordering and grouping are not supported simultaneously.");
					}
					mblnShowGroupingDropArea = value;
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether grouping columns should be hidden.
		/// </summary>
		/// 
		///   true</c> if [hide grouping columns]; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		public bool HideGroupedColumns
		{
			get
			{
				return mblnHideGroupedColumns;
			}
			set
			{
				if (mblnHideGroupedColumns != value)
				{
					mblnHideGroupedColumns = value;
					SwitchPreRenderUpdate(PreRenderUpdateType.GroupingData);
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the backcolor of the grouping area.
		/// </summary>
		/// 
		/// The backcolor of the grouping area.
		/// </value>
		internal Color GroupingAreaBackColor
		{
			get
			{
				return mobjGroupingAreaBackColor;
			}
			set
			{
				if (mobjGroupingAreaBackColor != value)
				{
					mobjGroupingAreaBackColor = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets the height of the grouping area.
		/// </summary>
		/// 
		/// The height of the grouping area.
		/// </value>
		internal int GroupingAreaHeight
		{
			get
			{
				return mintGroupingAreaHeight;
			}
			set
			{
				if (mintGroupingAreaHeight != value)
				{
					mintGroupingAreaHeight = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets the color of the grouping area border.
		/// </summary>
		/// 
		/// The color of the grouping area border.
		/// </value>
		internal BorderColor GroupingAreaBorderColor
		{
			get
			{
				return mobjGroupingAreaBorderColor;
			}
			set
			{
				if (mobjGroupingAreaBorderColor != value)
				{
					mobjGroupingAreaBorderColor = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets the grouping area background image.
		/// </summary>
		/// 
		/// The grouping area background image.
		/// </value>
		internal ResourceHandle GroupingAreaBackgroundImage
		{
			get
			{
				return mobjGroupingAreaBackgroundImage;
			}
			set
			{
				if (mobjGroupingAreaBackgroundImage != value)
				{
					mobjGroupingAreaBackgroundImage = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets the grouping area background image position.
		/// </summary>
		/// 
		/// The grouping area background image position.
		/// </value>
		internal BackgroundImagePosition GroupingAreaBackgroundImagePosition
		{
			get
			{
				return menmGroupingAreaBackgroundImagePosition;
			}
			set
			{
				if (menmGroupingAreaBackgroundImagePosition != value)
				{
					menmGroupingAreaBackgroundImagePosition = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets the grouping area background image repeat.
		/// </summary>
		/// 
		/// The grouping area background image repeat.
		/// </value>
		internal BackgroundImageRepeat GroupingAreaBackgroundImageRepeat
		{
			get
			{
				return menmGroupingAreaBackgroundImageRepeat;
			}
			set
			{
				if (menmGroupingAreaBackgroundImageRepeat != value)
				{
					menmGroupingAreaBackgroundImageRepeat = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets the grouping area border style.
		/// </summary>
		/// 
		/// The grouping area border style.
		/// </value>
		internal BorderStyle GroupingAreaBorderStyle
		{
			get
			{
				return mobjGroupingAreaBorderStyle;
			}
			set
			{
				if (mobjGroupingAreaBorderStyle != value)
				{
					mobjGroupingAreaBorderStyle = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets the width of the grouping area border.
		/// </summary>
		/// 
		/// The width of the grouping area border.
		/// </value>
		internal BorderWidth GroupingAreaBorderWidth
		{
			get
			{
				return mobjGroupingAreaBorderWidth;
			}
			set
			{
				if (mobjGroupingAreaBorderWidth != value)
				{
					mobjGroupingAreaBorderWidth = value;
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [support group count].
		/// </summary>
		/// 
		///   true</c> if [support group count]; otherwise, false</c>.
		/// </value>
		[Description("Gets or sets a value indicating whether to show the items count in group header.")]
		[DefaultValue(false)]
		[Category("CatAppearance")]
		public bool SupportGroupCount
		{
			get
			{
				return mblnSupportGroupCount;
			}
			set
			{
				if (mblnSupportGroupCount != value)
				{
					mblnSupportGroupCount = value;
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether [show filter row].
		/// </summary>
		/// 
		///   true</c> if [show filter row]; otherwise, false</c>.
		/// </value>
		[Description("Gets or sets a value indicating whether to show the filter row.")]
		[DefaultValue(false)]
		[Category("CatAppearance")]
		public bool ShowFilterRow
		{
			get
			{
				return mblnShowFilterRow;
			}
			set
			{
				if (mblnShowFilterRow == value)
				{
					return;
				}
				mblnShowFilterRow = value;
				if (!base.IsLayoutSuspended && !base.DesignMode)
				{
					if (value && mobjDataGridViewFilterRow == null)
					{
						SwitchPreRenderUpdate(PreRenderUpdateType.FilterRow);
					}
					Update();
				}
			}
		}

		/// Gets or sets a value indicating whether or not ToolTips will show when the mouse pointer pauses on a cell.</summary>
		/// true if cell ToolTips are enabled; otherwise, false.</returns>
		[SRCategory("CatAppearance")]
		[DefaultValue(true)]
		[SRDescription("DataGridView_ShowCellToolTipsDescr")]
		public bool ShowCellToolTips
		{
			get
			{
				return mobjDataGridViewState2[256];
			}
			set
			{
				if (ShowCellToolTips != value)
				{
					mobjDataGridViewState2[256] = value;
					Update();
				}
			}
		}

		/// Gets or sets a value indicating whether or not the editing glyph is visible in the row header of the cell being edited.</summary>
		/// true if the editing glyph is visible; otherwise, false. The default is true.</returns>
		[SRDescription("DataGridView_ShowEditingIconDescr")]
		[DefaultValue(true)]
		[SRCategory("CatAppearance")]
		public bool ShowEditingIcon
		{
			get
			{
				return mobjDataGridViewState2[1];
			}
			set
			{
				if (ShowEditingIcon != value)
				{
					mobjDataGridViewState2[1] = value;
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// Gets or sets a value indicating whether row headers will display error glyphs for each row that contains a data entry error. </summary>
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> indicates there is an error; otherwise, false. The default is true.</returns>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridView_ShowRowErrorsDescr")]
		[DefaultValue(true)]
		public bool ShowRowErrors
		{
			get
			{
				return mobjDataGridViewState2[512];
			}
			set
			{
				if (ShowRowErrors != value)
				{
					mobjDataGridViewState2[512] = value;
				}
			}
		}

		/// Gets the column by which the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> contents are currently sorted.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> by which the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> contents are currently sorted.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public DataGridViewColumn SortedColumn
		{
			get
			{
				return mobjSortedColumn;
			}
			private set
			{
				mobjSortedColumn = value;
			}
		}

		/// Gets a value indicating whether the items in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control are sorted in ascending or descending order, or are not sorted.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.SortOrder"></see> values.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public SortOrder SortOrder
		{
			get
			{
				return menmSortOrder;
			}
			private set
			{
				menmSortOrder = value;
			}
		}

		/// 
		/// Gets or sets the data grid view blocks manager.
		/// </summary>
		/// The data grid view blocks manager.</value>
		private DataGridViewBlocksManager BlocksManager
		{
			get
			{
				if (mobjDataGridViewBlocksManager == null)
				{
					mobjDataGridViewBlocksManager = new DataGridViewBlocksManager(this);
				}
				return mobjDataGridViewBlocksManager;
			}
		}

		/// Gets or sets a value indicating whether the TAB key moves the focus to the next control in the tab order rather than moving focus to the next cell in the control.</summary>
		/// true if the TAB key moves the focus to the next control in the tab order; otherwise, false.</returns>
		/// 1</filterpriority>
		[DefaultValue(false)]
		[SRDescription("DataGridView_StandardTabDescr")]
		[SRCategory("CatBehavior")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool StandardTab
		{
			get
			{
				return mobjDataGridViewState1[8192];
			}
			set
			{
				if (mobjDataGridViewState1[8192] != value)
				{
					mobjDataGridViewState1[8192] = value;
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// Gets or sets the header cell located in the upper left corner of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see> located at the upper left corner of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public DataGridViewHeaderCell TopLeftHeaderCell
		{
			get
			{
				if (mobjTopLeftHeaderCell == null)
				{
					TopLeftHeaderCell = new DataGridViewTopLeftHeaderCell();
				}
				return mobjTopLeftHeaderCell;
			}
			set
			{
				if (mobjTopLeftHeaderCell != value)
				{
					if (mobjTopLeftHeaderCell != null)
					{
						mobjTopLeftHeaderCell.DataGridViewInternal = null;
					}
					mobjTopLeftHeaderCell = value;
					if (value != null)
					{
						mobjTopLeftHeaderCell.DataGridViewInternal = this;
					}
					if (ColumnHeadersVisible && RowHeadersVisible)
					{
						OnColumnHeadersGlobalAutoSize();
					}
					mobjTopLeftHeaderCell = value;
				}
			}
		}

		/// Gets the default or user-specified value of the <see cref="P:Gizmox.WebGUI.Forms.Control.Cursor"></see> property. </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.Cursor"></see> representing the normal value of the <see cref="P:Gizmox.WebGUI.Forms.Control.Cursor"></see> property.</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public Cursor UserSetCursor => null;

		/// Gets the number of pixels by which the control is scrolled vertically.</summary>
		/// The number of pixels by which the control is scrolled vertically.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int VerticalScrollingOffset => -1;

		/// Gets or sets a value indicating whether you have provided your own data-management operations for the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
		/// true if the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> uses data-management operations that you provide; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		[SRDescription("DataGridViewVirtualModeDescr")]
		public bool VirtualMode
		{
			get
			{
				return mobjDataGridViewState1[65536];
			}
			set
			{
				if (mobjDataGridViewState1[65536] != value)
				{
					mobjDataGridViewState1[65536] = value;
					InvalidateRowHeights();
				}
			}
		}

		/// 
		/// Gets the placeholder cell style.
		/// </summary>
		/// The placeholder cell style.</value>
		internal DataGridViewCellStyle PlaceholderCellStyle
		{
			get
			{
				if (mobjPlaceholderCellStyle == null)
				{
					mobjPlaceholderCellStyle = new DataGridViewCellStyle();
				}
				return mobjPlaceholderCellStyle;
			}
		}

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
		/// </summary>
		/// true</c> if focusable; otherwise, false</c>.</value>
		protected override bool Focusable => true;

		/// 
		/// Gets or sets the height of the caption.
		/// </summary>
		/// 
		/// The height of the caption.
		/// </value>
		[DefaultValue(0)]
		public int CaptionHeight
		{
			get
			{
				return mintCaptionHeight;
			}
			set
			{
				if (mintCaptionHeight != value)
				{
					mintCaptionHeight = value;
					UpdateParams(AttributeType.Layout);
				}
			}
		}

		/// 
		/// Gets or sets the navigation key filter.
		/// </summary>
		/// 
		/// The navigation key filter.
		/// </value>
		[DefaultValue(NavigationKeyFilter.None)]
		public NavigationKeyFilter NavigationKeyFilter
		{
			get
			{
				return menmNavigationKeyFilter;
			}
			set
			{
				if (menmNavigationKeyFilter != value)
				{
					menmNavigationKeyFilter = value;
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets the headers filter info.
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public List<object> HeadersFilterInfo
		{
			get
			{
				if (mobjHeadersFilterInfo == null)
				{
					mobjHeadersFilterInfo = new List<object>();
				}
				return mobjHeadersFilterInfo;
			}
		}

		/// Gets the collection of cells selected by the user.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedCellCollection"></see> that represents the cells selected by the user.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public DataGridViewSelectedCellCollection SelectedCells
		{
			get
			{
				DataGridViewSelectedCellCollection dataGridViewSelectedCellCollection = new DataGridViewSelectedCellCollection();
				DataGridViewIntLinkedList dataGridViewIntLinkedList = null;
				switch (SelectionMode)
				{
				case DataGridViewSelectionMode.CellSelect:
					dataGridViewSelectedCellCollection.AddCellLinkedList(IndividualSelectedCells);
					return dataGridViewSelectedCellCollection;
				case DataGridViewSelectionMode.FullRowSelect:
				case DataGridViewSelectionMode.RowHeaderSelect:
					dataGridViewIntLinkedList = SelectedBandIndexes;
					foreach (int item in (IEnumerable)dataGridViewIntLinkedList)
					{
						DataGridViewRow dataGridViewRow2 = Rows[item];
						foreach (DataGridViewCell cell in dataGridViewRow2.Cells)
						{
							dataGridViewSelectedCellCollection.Add(cell);
						}
					}
					if (SelectionMode == DataGridViewSelectionMode.RowHeaderSelect)
					{
						dataGridViewSelectedCellCollection.AddCellLinkedList(IndividualSelectedCells);
					}
					return dataGridViewSelectedCellCollection;
				case DataGridViewSelectionMode.FullColumnSelect:
				case DataGridViewSelectionMode.ColumnHeaderSelect:
					if (dataGridViewIntLinkedList == null)
					{
						dataGridViewIntLinkedList = SelectedBandIndexes;
					}
					foreach (int item2 in (IEnumerable)dataGridViewIntLinkedList)
					{
						foreach (DataGridViewRow item3 in (IEnumerable)Rows)
						{
							dataGridViewSelectedCellCollection.Add(item3.Cells[item2]);
						}
					}
					if (SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
					{
						dataGridViewSelectedCellCollection.AddCellLinkedList(IndividualSelectedCells);
					}
					return dataGridViewSelectedCellCollection;
				default:
					return dataGridViewSelectedCellCollection;
				}
			}
		}

		/// Gets the collection of columns selected by the user.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedColumnCollection"></see> that represents the columns selected by the user.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public DataGridViewSelectedColumnCollection SelectedColumns
		{
			get
			{
				DataGridViewSelectedColumnCollection dataGridViewSelectedColumnCollection = new DataGridViewSelectedColumnCollection();
				switch (SelectionMode)
				{
				case DataGridViewSelectionMode.CellSelect:
				case DataGridViewSelectionMode.FullRowSelect:
				case DataGridViewSelectionMode.RowHeaderSelect:
					return dataGridViewSelectedColumnCollection;
				case DataGridViewSelectionMode.FullColumnSelect:
				case DataGridViewSelectionMode.ColumnHeaderSelect:
					foreach (int item in (IEnumerable)SelectedBandIndexes)
					{
						dataGridViewSelectedColumnCollection.Add(Columns[item]);
					}
					return dataGridViewSelectedColumnCollection;
				default:
					return dataGridViewSelectedColumnCollection;
				}
			}
		}

		/// Gets the collection of rows selected by the user.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectedRowCollection"></see> that contains the rows selected by the user.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public DataGridViewSelectedRowCollection SelectedRows
		{
			get
			{
				DataGridViewSelectedRowCollection dataGridViewSelectedRowCollection = new DataGridViewSelectedRowCollection();
				switch (SelectionMode)
				{
				case DataGridViewSelectionMode.CellSelect:
				case DataGridViewSelectionMode.FullColumnSelect:
				case DataGridViewSelectionMode.ColumnHeaderSelect:
					return dataGridViewSelectedRowCollection;
				case DataGridViewSelectionMode.FullRowSelect:
				case DataGridViewSelectionMode.RowHeaderSelect:
					foreach (int item in (IEnumerable)SelectedBandIndexes)
					{
						dataGridViewSelectedRowCollection.Add(Rows[item]);
					}
					return dataGridViewSelectedRowCollection;
				default:
					return dataGridViewSelectedRowCollection;
				}
			}
		}

		/// 
		/// Gets the scroll poisition.
		/// </summary>
		/// The scroll poisition.</value>
		internal Point ScrollPoisition => new Point(base.ScrollLeft, base.ScrollTop);

		/// Gets or sets the index of the column that is the first column displayed on the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// The index of the column that is the first column displayed on the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than 0 or greater than the number of columns in the control minus 1.</exception>
		/// <exception cref="T:System.InvalidOperationException">The specified value when setting this property indicates a column with a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Visible"></see> property value of false.-or-The specified value when setting this property indicates a column with a <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Frozen"></see> property value of true.</exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int FirstDisplayedScrollingColumnIndex
		{
			get
			{
				int result = -1;
				if (Columns.Count > 0 && base.Width > 0)
				{
					DataGridViewColumn dataGridViewColumn = Columns.GetFirstColumn(DataGridViewElementStates.Visible);
					int num = 0;
					while (dataGridViewColumn != null)
					{
						if (num >= base.ScrollLeft)
						{
							result = dataGridViewColumn.Index;
							dataGridViewColumn = null;
						}
						else
						{
							num += dataGridViewColumn.Width;
							dataGridViewColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
						}
					}
				}
				return result;
			}
			set
			{
				if (value < 0 || value >= Columns.Count)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				if (!Columns[value].Visible)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_FirstDisplayedScrollingColumnCannotBeInvisible"));
				}
				if (Columns[value].Frozen)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_FirstDisplayedScrollingColumnCannotBeFrozen"));
				}
				int width = LayoutInfo.Data.Width;
				if (width <= 0)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_NoRoomForDisplayedColumns"));
				}
				if (Columns.GetColumnsWidth(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible) >= width)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_FrozenColumnsPreventFirstDisplayedScrollingColumn"));
				}
				if (value != DisplayedBandsInfo.FirstDisplayedScrollingCol && (mobjCurrentCellPoint.X < 0 || CommitEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Scroll, blnForCurrentCellChange: false, blnForCurrentRowChange: false)) && !IsColumnOutOfBounds(value))
				{
					PerformScrollIntoView(Rows[mobjCurrentCellPoint.Y].Cells[value], blnHidePopups: false);
				}
			}
		}

		/// 
		/// Gets the first index of the displayed column.
		/// </summary>
		/// The first index of the displayed column.</value>
		internal int FirstDisplayedColumnIndex
		{
			get
			{
				if (!base.IsHandleCreated)
				{
					return -1;
				}
				int result = -1;
				DataGridViewColumn firstColumn = Columns.GetFirstColumn(DataGridViewElementStates.Visible);
				if (firstColumn != null)
				{
					if (firstColumn.Frozen)
					{
						return firstColumn.Index;
					}
					if (FirstDisplayedScrollingColumnIndex >= 0)
					{
						result = FirstDisplayedScrollingColumnIndex;
					}
				}
				return result;
			}
		}

		/// 
		/// Gets the first index of the displayed row.
		/// </summary>
		/// The first index of the displayed row.</value>
		internal int FirstDisplayedRowIndex
		{
			get
			{
				if (!base.IsHandleCreated)
				{
					return -1;
				}
				DataGridViewRowCollection rows = Rows;
				int num = rows.GetFirstRow(DataGridViewElementStates.Visible);
				if (num != -1 && (rows.GetRowState(num) & DataGridViewElementStates.Frozen) == 0 && FirstDisplayedScrollingRowIndex >= 0)
				{
					num = FirstDisplayedScrollingRowIndex;
				}
				return num;
			}
		}

		/// 
		/// Gets or sets the first index of the displayed scrolling row.
		/// </summary>
		/// The first index of the displayed scrolling row.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int FirstDisplayedScrollingRowIndex
		{
			get
			{
				int result = -1;
				IList pageRows = PageRows;
				if (pageRows.Count > 0 && base.Height > 0)
				{
					int num = 0;
					foreach (DataGridViewRow item in pageRows)
					{
						if (item.Visible)
						{
							if (num >= base.ScrollTop)
							{
								result = item.Index;
								break;
							}
							num += item.Height;
						}
					}
				}
				return result;
			}
			set
			{
				DataGridViewRowCollection rows = Rows;
				if (value < 0 || value >= rows.Count)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				if ((rows.GetRowState(value) & DataGridViewElementStates.Visible) == 0)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_FirstDisplayedScrollingRowCannotBeInvisible"));
				}
				if ((rows.GetRowState(value) & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_FirstDisplayedScrollingRowCannotBeFrozen"));
				}
				if (value != FirstDisplayedScrollingRowIndex && (mobjCurrentCellPoint.X < 0 || CommitEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Scroll, blnForCurrentCellChange: false, blnForCurrentRowChange: false)))
				{
					PerformScrollIntoView(rows[value].Cells[mobjCurrentCellPoint.X], blnHidePopups: false);
				}
			}
		}

		/// Gets or sets a value indicating how the cells of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> can be selected.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectionMode"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.RowHeaderSelect"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.FullColumnSelect"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewSelectionMode.ColumnHeaderSelect"></see> and the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property of one or more columns is set to <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.Automatic"></see>.</exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSelectionMode"></see> value.</exception>
		/// 1</filterpriority>
		[DefaultValue(DataGridViewSelectionMode.RowHeaderSelect)]
		[Browsable(true)]
		[SRCategory("CatBehavior")]
		[SRDescription("DataGridView_SelectionModeDescr")]
		public DataGridViewSelectionMode SelectionMode
		{
			get
			{
				return menmSelectionMode;
			}
			set
			{
				if (SelectionMode == value)
				{
					return;
				}
				if (!mobjDataGridViewState2[524288] && (value == DataGridViewSelectionMode.FullColumnSelect || value == DataGridViewSelectionMode.ColumnHeaderSelect))
				{
					foreach (DataGridViewColumn column in Columns)
					{
						if (column.SortMode == DataGridViewColumnSortMode.Automatic)
						{
							throw new InvalidOperationException(SR.GetString("DataGridView_SelectionModeAndSortModeClash", value.ToString()));
						}
					}
				}
				ClearSelection();
				menmSelectionMode = value;
				InvokeMethodWithId("DataGridView_InvokeSetSelectionMode", Convert.ToInt32(SupportedSelectionMode).ToString());
			}
		}

		/// 
		/// Gets the supported selection mode.
		/// </summary>
		/// The supported selection mode.</value>
		private DataGridViewSelectionMode SupportedSelectionMode
		{
			get
			{
				DataGridViewSelectionMode selectionMode = SelectionMode;
				if (selectionMode == DataGridViewSelectionMode.CellSelect || selectionMode == DataGridViewSelectionMode.FullRowSelect || selectionMode == DataGridViewSelectionMode.RowHeaderSelect)
				{
					return SelectionMode;
				}
				return DataGridViewSelectionMode.CellSelect;
			}
		}

		/// 
		/// Gets or sets the current cell point.
		/// </summary>
		/// The current cell point.</value>
		internal Point CurrentCellPoint
		{
			get
			{
				return mobjCurrentCellPoint;
			}
			set
			{
				mobjCurrentCellPoint = value;
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRows"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("DataGridViewOnAllowUserToAddRowsChangedDescr")]
		public event EventHandler AllowUserToAddRowsChanged;

		/// Occurs when the value of the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AllowUserToDeleteRowsChanged"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridViewOnAllowUserToDeleteRowsChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler AllowUserToDeleteRowsChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToOrderColumns"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridViewOnAllowUserToOrderColumnsChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler AllowUserToOrderColumnsChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeColumns"></see> property changes.</summary>
		[SRDescription("DataGridViewOnAllowUserToResizeColumnsChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler AllowUserToResizeColumnsChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeRows"></see> property changes.</summary>
		[SRDescription("DataGridViewOnAllowUserToResizeRowsChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler AllowUserToResizeRowsChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AlternatingRowsDefaultCellStyle"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridViewAlternatingRowsDefaultCellStyleChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler AlternatingRowsDefaultCellStyleChanged;

		/// Occurs when the value of the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoGenerateColumnsChanged"></see> property changes.</summary>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public event EventHandler AutoGenerateColumnsChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property of a column changes.</summary>
		[SRDescription("DataGridViewAutoSizeColumnModeChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewAutoSizeColumnModeEventHandler AutoSizeColumnModeChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AutoSizeColumnsMode"></see> property changes.</summary>
		[SRDescription("DataGridViewAutoSizeColumnsModeChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewAutoSizeColumnsModeEventHandler AutoSizeColumnsModeChanged;

		/// Occurs when the value of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridViewAutoSizeRowsModeChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewAutoSizeModeEventHandler AutoSizeRowsModeChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.BackColor"></see> property changes.</summary>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler BackColorChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.BackgroundColor"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridViewBackgroundColorChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler BackgroundColorChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.BackgroundImage"></see> property changes.</summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler BackgroundImageChanged;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.BackgroundImageLayout"></see> property changes.</summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new event EventHandler BackgroundImageLayoutChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.BorderStyle"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridViewBorderStyleChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler BorderStyleChanged;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is true and the cancels edits in a row.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CancelRowEditDescr")]
		[SRCategory("CatAction")]
		public event QuestionEventHandler CancelRowEdit;

		/// Occurs when edit mode starts for the selected cell.</summary>
		/// 1</filterpriority>
		[SRCategory("CatData")]
		[SRDescription("DataGridView_CellBeginEditDescr")]
		public event DataGridViewCellCancelEventHandler CellBeginEdit
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWCELLBEGINEDIT, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWCELLBEGINEDIT, value);
			}
		}

		/// 
		/// Occurs when an hierarchic grid is created.
		/// </summary>
		[SRCategory("CatData")]
		[SRDescription("Raised when a child grid is created")]
		public event HierarchicDataGridViewCreatedEventHandler HierarchicGridCreated
		{
			add
			{
				AddHandler(EVENT_HIERARCHICGRIDCREATED, value);
			}
			remove
			{
				RemoveHandler(EVENT_HIERARCHICGRIDCREATED, value);
			}
		}

		/// 
		/// ColumnChooser dialig is closed, and at least one column's visibility is changed
		/// </summary>
		[SRCategory("CatData")]
		[SRDescription("Raised when ColumnChooser dialig is closed, and at least one column's visibility is changed")]
		public event ColumnChooserColumnsVisibilityChangedHandler ColumnChooserColumnsVisibilityChanged
		{
			add
			{
				AddHandler(EVENT_COLUMNCHOOSERCOLUMNSVISIBILITYCHANGED, value);
			}
			remove
			{
				RemoveHandler(EVENT_COLUMNCHOOSERCOLUMNSVISIBILITYCHANGED, value);
			}
		}

		/// 
		/// Occurs when [row expanding].
		/// </summary>
		[SRCategory("CatData")]
		[SRDescription("Raised when a row is expanding")]
		public event RowExpandingEventHandler RowExpanding
		{
			add
			{
				AddCriticalHandler(EVENT_ROWEXPANDING, value);
			}
			remove
			{
				RemoveCriticalHandler(EVENT_ROWEXPANDING, value);
			}
		}

		/// 
		/// Occurs when [row expanded].
		/// </summary>
		[SRCategory("CatData")]
		[SRDescription("Raised when a row is expanded")]
		public event RowExpandedEventHandler RowExpanded
		{
			add
			{
				AddCriticalHandler(EVENT_ROWEXPANDED, value);
			}
			remove
			{
				RemoveCriticalHandler(EVENT_ROWEXPANDED, value);
			}
		}

		/// 
		/// Occurs when [row collapses].
		/// </summary>
		[SRCategory("CatData")]
		[SRDescription("Raised when a row is collapse")]
		public event RowCollapsedEventHandler RowCollapsed
		{
			add
			{
				AddCriticalHandler(EVENT_ROWCOLLAPSED, value);
			}
			remove
			{
				RemoveCriticalHandler(EVENT_ROWCOLLAPSED, value);
			}
		}

		/// 
		/// Occurs when [row collapsing].
		/// </summary>
		[SRCategory("CatData")]
		[SRDescription("Raised when a row is collapsing")]
		public event RowCollapsingEventHandler RowCollapsing
		{
			add
			{
				AddCriticalHandler(EVENT_ROWCOLLAPSING, value);
			}
			remove
			{
				RemoveCriticalHandler(EVENT_ROWCOLLAPSING, value);
			}
		}

		/// Occurs when the border style of a cell changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellBorderStyleChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler CellBorderStyleChanged;

		/// Occurs when any part of a cell is clicked.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellClickDescr")]
		[SRCategory("CatMouse")]
		public event DataGridViewCellEventHandler CellClick
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWCELLCLICK, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWCELLCLICK, value);
			}
		}

		/// Occurs when the content within a cell is clicked.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellContentClick")]
		[SRCategory("CatMouse")]
		public event DataGridViewCellEventHandler CellContentClick
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWCELLCONTENTCLICK, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWCELLCONTENTCLICK, value);
			}
		}

		/// Occurs when the user double-clicks a cell's contents.</summary>
		[SRDescription("DataGridView_CellContentDoubleClick")]
		[SRCategory("CatMouse")]
		public event DataGridViewCellEventHandler CellContentDoubleClick
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWCELLCONTENTDOUBLECLICK, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWCELLCONTENTDOUBLECLICK, value);
			}
		}

		/// 
		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ContextMenuStrip"></see> property changes.
		/// </summary>
		[SRDescription("DataGridView_CellContextMenuChanged")]
		[SRCategory("CatAction")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public event DataGridViewCellEventHandler CellContextMenuChanged;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ContextMenuStrip"></see> property changes. </summary>
		[SRDescription("DataGridView_CellContextMenuStripChanged")]
		[SRCategory("CatAction")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("CellContextMenuStripChanged event is obsolete use CellContextMenuChanged instead")]
		public event DataGridViewCellEventHandler CellContextMenuStripChanged;

		/// Occurs when the user double-clicks anywhere in a cell.</summary>
		[SRCategory("CatMouse")]
		[SRDescription("DataGridView_CellDoubleClickDescr")]
		public event DataGridViewCellEventHandler CellDoubleClick
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWCELLDOUBLECLICK, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWCELLDOUBLECLICK, value);
			}
		}

		/// Occurs when edit mode stops for the currently selected cell.</summary>
		/// 1</filterpriority>
		[SRCategory("CatData")]
		[SRDescription("DataGridView_CellEndEditDescr")]
		public event DataGridViewCellEventHandler CellEndEdit
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWCELLENDEDIT, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWCELLENDEDIT, value);
			}
		}

		/// Occurs when the current cell changes in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or when the control receives input focus. </summary>
		/// 1</filterpriority>
		[SRCategory("CatFocus")]
		[SRDescription("DataGridView_CellEnterDescr")]
		public event DataGridViewCellEventHandler CellEnter;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ErrorText"></see> property of a cell changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellErrorTextChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewCellEventHandler CellErrorTextChanged;

		/// Occurs when a cell's error text is needed.</summary>
		[SRDescription("DataGridView_CellErrorTextNeededDescr")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRCategory("CatData")]
		public event DataGridViewCellErrorTextNeededEventHandler CellErrorTextNeeded;

		/// Occurs when the contents of a cell need to be formatted for display.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellFormattingDescr")]
		[SRCategory("CatDisplay")]
		public event DataGridViewCellFormattingEventHandler CellFormatting;

		/// Occurs when a cell loses input focus and is no longer the current cell.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellLeaveDescr")]
		[SRCategory("CatFocus")]
		public event DataGridViewCellEventHandler CellLeave;

		/// Occurs whenever the user clicks anywhere on a cell with the mouse.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellMouseClickDescr")]
		[SRCategory("CatMouse")]
		public event DataGridViewCellMouseEventHandler CellMouseClick
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWCELLMOUSECLICK, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWCELLMOUSECLICK, value);
			}
		}

		/// Occurs when a cell within the <see cref="T:System.Windows.Forms.DataGridView"></see> is double-clicked.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellMouseDoubleClickDescr")]
		[SRCategory("CatMouse")]
		public event DataGridViewCellMouseEventHandler CellMouseDoubleClick
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWCELLMOUSEDOUBLECLICK, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWCELLMOUSEDOUBLECLICK, value);
			}
		}

		/// Occurs when the user presses a mouse button while the mouse pointer is within the boundaries of a cell.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellMouseDownDescr")]
		[SRCategory("CatMouse")]
		public event DataGridViewCellMouseEventHandler CellMouseDown
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWCELLMOUSEDOWN, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWCELLMOUSEDOWN, value);
			}
		}

		/// Occurs when the mouse pointer enters a cell.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellMouseEnterDescr")]
		[SRCategory("CatMouse")]
		public event DataGridViewCellEventHandler CellMouseEnter;

		/// Occurs when the mouse pointer leaves a cell.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellMouseLeaveDescr")]
		[SRCategory("CatMouse")]
		public event DataGridViewCellEventHandler CellMouseLeave;

		/// Occurs when the mouse pointer moves over the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellMouseMoveDescr")]
		[SRCategory("CatMouse")]
		public event DataGridViewCellMouseEventHandler CellMouseMove;

		/// Occurs when the user releases a mouse button while over a cell.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellMouseUpDescr")]
		[SRCategory("CatMouse")]
		public event DataGridViewCellMouseEventHandler CellMouseUp
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWCELLMOUSEUP, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWCELLMOUSEUP, value);
			}
		}

		/// Occurs when a cell leaves edit mode if the cell value has been modified.</summary>
		/// 1</filterpriority>
		[SRCategory("CatDisplay")]
		[SRDescription("DataGridView_CellParsingDescr")]
		public event DataGridViewCellParsingEventHandler CellParsing;

		/// Occurs when a cell state changes, such as when the cell loses or gains focus.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellStateChangedDescr")]
		[SRCategory("CatBehavior")]
		public event DataGridViewCellStateChangedEventHandler CellStateChanged;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Style"></see> property of a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellStyleChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewCellEventHandler CellStyleChanged;

		/// Occurs when one of the values of a cell style changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellStyleContentChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewCellStyleContentChangedEventHandler CellStyleContentChanged;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ToolTipText"></see> property value changes for a cell in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("DataGridView_CellToolTipTextChangedDescr")]
		public event DataGridViewCellEventHandler CellToolTipTextChanged;

		/// Occurs when a cell's ToolTip text is needed.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRCategory("CatBehavior")]
		[SRDescription("DataGridView_CellToolTipTextNeededDescr")]
		public event DataGridViewCellToolTipTextNeededEventHandler CellToolTipTextNeeded;

		/// Occurs after the cell has finished validating.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellValidatedDescr")]
		[SRCategory("CatFocus")]
		public event DataGridViewCellEventHandler CellValidated;

		/// Occurs when a cell loses input focus, enabling content validation.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellValidatingDescr")]
		[SRCategory("CatFocus")]
		public event DataGridViewCellValidatingEventHandler CellValidating;

		/// Occurs when the value of a cell changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_CellValueChangedDescr")]
		[SRCategory("CatAction")]
		public event DataGridViewCellEventHandler CellValueChanged;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is true and the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> requires a value for a cell in order to format and display the cell.</summary>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRDescription("DataGridView_CellValueNeededDescr")]
		[SRCategory("CatData")]
		public event DataGridViewCellValueEventHandler CellValueNeeded;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is true and a cell value has changed and requires storage in the underlying data source.</summary>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRDescription("DataGridView_CellValuePushedDescr")]
		[SRCategory("CatData")]
		public event DataGridViewCellValueEventHandler CellValuePushed;

		/// Occurs when a column is added to the control.</summary>
		[SRDescription("DataGridView_ColumnAddedDescr")]
		[SRCategory("CatAction")]
		public event DataGridViewColumnEventHandler ColumnAdded;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.ContextMenuStrip"></see> property of a column changes.</summary>
		[SRDescription("DataGridView_ColumnContextMenuStripChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewColumnEventHandler ColumnContextMenuStripChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DataPropertyName"></see> property for a column changes.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("DataGridView_ColumnDataPropertyNameChangedDescr")]
		public event DataGridViewColumnEventHandler ColumnDataPropertyNameChanged
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWCOLUMNDATAPROPERTYNAMECHANGED, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWCOLUMNDATAPROPERTYNAMECHANGED, value);
			}
		}

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.DefaultCellStyle"></see> property for a column changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ColumnDefaultCellStyleChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewColumnEventHandler ColumnDefaultCellStyleChanged;

		/// Occurs when the value the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DisplayIndex"></see> property for a column changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ColumnDisplayIndexChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewColumnEventHandler ColumnDisplayIndexChanged;

		/// Occurs when the user double-clicks a divider between two columns.</summary>
		[SRDescription("DataGridView_ColumnDividerDoubleClickDescr")]
		[SRCategory("CatMouse")]
		public event DataGridViewColumnDividerDoubleClickEventHandler ColumnDividerDoubleClick
		{
			add
			{
				AddHandler(ColumnDividerDoubleClickEvent, value);
			}
			remove
			{
				RemoveHandler(ColumnDividerDoubleClickEvent, value);
			}
		}

		/// 
		/// Occurs when [client column divider double click].
		/// </summary>
		[SRDescription("Occurs when control's column divider double-clicked in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientColumnDividerDoubleClick
		{
			add
			{
				AddClientHandler("DividerDoubleClick", value);
			}
			remove
			{
				RemoveClientHandler("DividerDoubleClick", value);
			}
		}

		/// 
		/// Occurs when [client cell begin edit].
		/// </summary>
		[SRDescription("Occurs when control's cell editing starts in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientCellBeginEdit
		{
			add
			{
				AddClientHandler("BeginEdit", value);
			}
			remove
			{
				RemoveClientHandler("BeginEdit", value);
			}
		}

		/// 
		/// Occurs when [client cell value change].
		/// </summary>
		[SRDescription("Occurs when control's cell value changed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientCellValueChanged
		{
			add
			{
				AddClientHandler("ValueChange", value);
			}
			remove
			{
				RemoveClientHandler("ValueChange", value);
			}
		}

		/// 
		/// Occurs when [client cell end edit].
		/// </summary>
		[SRDescription("Occurs when control's cell editing ends in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientCellEndEdit
		{
			add
			{
				AddClientHandler("EndEdit", value);
			}
			remove
			{
				RemoveClientHandler("EndEdit", value);
			}
		}

		/// 
		/// Occurs when [client row expanding].
		/// </summary>
		[SRDescription("Occurs when control's row is expanding in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientRowExpanding
		{
			add
			{
				AddClientHandler("Expand", value);
			}
			remove
			{
				RemoveClientHandler("Expand", value);
			}
		}

		/// 
		/// Occurs when [client column width changed].
		/// </summary>
		[SRDescription("Occurs when control's column/row resized in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientRowColumnResized
		{
			add
			{
				AddClientHandler("Resize", value);
			}
			remove
			{
				RemoveClientHandler("Resize", value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DividerWidth"></see> property changes.</summary>
		[SRDescription("DataGridView_ColumnDividerWidthChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewColumnEventHandler ColumnDividerWidthChanged;

		/// Occurs when the contents of a column header cell change.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ColumnHeaderCellChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewColumnEventHandler ColumnHeaderCellChanged;

		/// Occurs when a column header is double-clicked.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ColumnHeaderMouseDoubleClickDescr")]
		[SRCategory("CatMouse")]
		public event DataGridViewCellMouseEventHandler ColumnHeaderMouseDoubleClick
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSEDOUBLECLICK, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSEDOUBLECLICK, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersBorderStyle"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("DataGridView_ColumnHeadersBorderStyleChangedDescr")]
		public event EventHandler ColumnHeadersBorderStyleChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersDefaultCellStyle"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridViewColumnHeadersDefaultCellStyleChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler ColumnHeadersDefaultCellStyleChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersHeight"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridViewColumnHeadersHeightChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler ColumnHeadersHeightChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersHeightSizeMode"></see> property changes.</summary>
		[SRDescription("DataGridView_ColumnHeadersHeightSizeModeChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewAutoSizeModeEventHandler ColumnHeadersHeightSizeModeChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.MinimumWidth"></see> property for a column changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ColumnMinimumWidthChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewColumnEventHandler ColumnMinimumWidthChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Name"></see> property for a column changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ColumnNameChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewColumnEventHandler ColumnNameChanged;

		/// Occurs when a column is removed from the control.</summary>
		[SRDescription("DataGridView_ColumnRemovedDescr")]
		[SRCategory("CatAction")]
		public event DataGridViewColumnEventHandler ColumnRemoved;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property for a column changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridViewColumnSortModeChangedDescr")]
		[SRCategory("CatBehavior")]
		public event DataGridViewColumnEventHandler ColumnSortModeChanged;

		/// Occurs when a column changes state, such as gaining or losing focus.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ColumnStateChangedDescr")]
		[SRCategory("CatBehavior")]
		public event DataGridViewColumnStateChangedEventHandler ColumnStateChanged;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.ToolTipText"></see> property value changes for a column in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_ColumnToolTipTextChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewColumnEventHandler ColumnToolTipTextChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Width"></see> property for a column changes.</summary>
		/// 1</filterpriority>
		[SRCategory("CatAction")]
		[SRDescription("DataGridView_ColumnWidthChangedDescr")]
		public event DataGridViewColumnEventHandler ColumnWidthChanged
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWCOLUMNWIDTHCHANGED, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWCOLUMNWIDTHCHANGED, value);
			}
		}

		/// 
		/// Occurs when the column header mouse click.
		/// </summary>
		[SRCategory("CatAction")]
		[SRDescription("DataGridView_ColumnHeaderMouseClick")]
		public event DataGridViewCellMouseEventHandler ColumnHeaderMouseClick
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSECLICK, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSECLICK, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.CurrentCell"></see> property changes.</summary>
		[SRCategory("CatAction")]
		[SRDescription("DataGridView_CurrentCellChangedDescr")]
		public event EventHandler CurrentCellChanged
		{
			add
			{
				AddCriticalHandler(CurrentCellChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(CurrentCellChangedEvent, value);
			}
		}

		/// 
		/// Occurs when [group header formatting].
		/// </summary>
		public event GroupHeaderFormattingEventHandler GroupHeaderFormatting
		{
			add
			{
				AddHandler(GroupHeaderFormattingEvent, value);
			}
			remove
			{
				RemoveHandler(GroupHeaderFormattingEvent, value);
			}
		}

		/// 
		/// Occurs when [grouping changed].
		/// </summary>
		public event GroupingChangedEventHandler GroupingChanged
		{
			add
			{
				AddHandler(GroupingChangedEvent, value);
			}
			remove
			{
				RemoveHandler(GroupingChangedEvent, value);
			}
		}

		/// Occurs when the state of a cell changes in relation to a change in its contents.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRDescription("DataGridView_CurrentCellDirtyStateChangedDescr")]
		public event EventHandler CurrentCellDirtyStateChanged;

		/// Occurs after a data-binding operation has finished.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_DataBindingCompleteDescr")]
		[SRCategory("CatData")]
		public event DataGridViewBindingCompleteEventHandler DataBindingComplete;

		/// Occurs when an external data-parsing or validation operation throws an exception, or when an attempt to commit data to a data source fails.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("DataGridView_DataErrorDescr")]
		public event DataGridViewDataErrorEventHandler DataError;

		/// Occurs when value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataMember"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridViewDataMemberChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler DataMemberChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridViewDataSourceChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler DataSourceChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DefaultCellStyle"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridViewDefaultCellStyleChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler DefaultCellStyleChanged;

		/// Occurs when the user enters the row for new records so that it can be populated with default values.</summary>
		/// 1</filterpriority>
		[SRCategory("CatData")]
		[SRDescription("DataGridView_DefaultValuesNeededDescr")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public event DataGridViewRowEventHandler DefaultValuesNeeded;

		/// Occurs when a control for editing a cell is showing.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_EditingControlShowingDescr")]
		[SRCategory("CatAction")]
		public event DataGridViewEditingControlShowingEventHandler EditingControlShowing;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditMode"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_EditModeChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler EditModeChanged;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.Font"></see> property value changes. </summary>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public new event EventHandler FontChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.GridColor"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("DataGridViewOnGridColorChangedDescr")]
		public event EventHandler GridColorChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.MultiSelect"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridViewOnMultiSelectChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler MultiSelectChanged;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is true and the user navigates to the new row at the bottom of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// 1</filterpriority>
		[SRCategory("CatData")]
		[SRDescription("DataGridView_NewRowNeededDescr")]
		public event DataGridViewRowEventHandler NewRowNeeded;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ReadOnly"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("DataGridViewOnReadOnlyChangedDescr")]
		public event EventHandler ReadOnlyChanged;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.ContextMenuStrip"></see> property changes.</summary>
		[SRDescription("DataGridView_RowContextMenuStripChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewRowEventHandler RowContextMenuStripChanged;

		/// Occurs when a row's shortcut menu is needed.</summary>
		[SRCategory("CatData")]
		[SRDescription("DataGridView_RowContextMenuStripNeededDescr")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public event DataGridViewRowContextMenuStripNeededEventHandler RowContextMenuStripNeeded;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.DefaultCellStyle"></see> property for a row changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_RowDefaultCellStyleChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewRowEventHandler RowDefaultCellStyleChanged;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control is true and the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> needs to determine whether the current row has uncommitted changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_RowDirtyStateNeededDescr")]
		[SRCategory("CatData")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public event QuestionEventHandler RowDirtyStateNeeded;

		/// Occurs when the user double-clicks the divider between two rows.</summary>
		[SRDescription("DataGridView_RowDividerDoubleClickDescr")]
		[SRCategory("CatMouse")]
		public event DataGridViewRowDividerDoubleClickEventHandler RowDividerDoubleClick;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.DividerHeight"></see> property changes. </summary>
		[SRDescription("DataGridView_RowDividerHeightChangedDescr")]
		[SRCategory("CatAppearance")]
		public event DataGridViewRowEventHandler RowDividerHeightChanged;

		/// Occurs when a row receives input focus and becomes the current row.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_RowEnterDescr")]
		[SRCategory("CatFocus")]
		public event DataGridViewCellEventHandler RowEnter;

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.ErrorText"></see> property of a row changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_RowErrorTextChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewRowEventHandler RowErrorTextChanged;

		/// Occurs when a row's error text is needed.</summary>
		/// 1</filterpriority>
		[SRCategory("CatData")]
		[SRDescription("DataGridView_RowErrorTextNeededDescr")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public event DataGridViewRowErrorTextNeededEventHandler RowErrorTextNeeded;

		/// Occurs when the user changes the contents of a row header cell.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_RowHeaderCellChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewRowEventHandler RowHeaderCellChanged;

		/// Occurs when the user clicks within the boundaries of a row header.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_RowHeaderMouseClickDescr")]
		[SRCategory("CatMouse")]
		public event DataGridViewCellMouseEventHandler RowHeaderMouseClick
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWROWHEADERMOUSECLICK, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWROWHEADERMOUSECLICK, value);
			}
		}

		/// Occurs when a row header is double-clicked.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_RowHeaderMouseDoubleClickDescr")]
		[SRCategory("CatMouse")]
		public event DataGridViewCellMouseEventHandler RowHeaderMouseDoubleClick
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWROWHEADERMOUSEDOUBLECLICK, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWROWHEADERMOUSEDOUBLECLICK, value);
			}
		}

		/// Occurs when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersBorderStyle"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_RowHeadersBorderStyleChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler RowHeadersBorderStyleChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersDefaultCellStyle"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("DataGridViewRowHeadersDefaultCellStyleChangedDescr")]
		public event EventHandler RowHeadersDefaultCellStyleChanged;

		/// Occurs when value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidth"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("DataGridViewRowHeadersWidthChangedDescr")]
		public event EventHandler RowHeadersWidthChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthSizeMode"></see> property changes.</summary>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("DataGridView_RowHeadersWidthSizeModeChangedDescr")]
		public event DataGridViewAutoSizeModeEventHandler RowHeadersWidthSizeModeChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.Height"></see> property for a row changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_RowHeightChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event DataGridViewRowEventHandler RowHeightChanged
		{
			add
			{
				AddHandler(EVENT_DATAGRIDVIEWROWHEIGHTCHANGED, value);
			}
			remove
			{
				RemoveHandler(EVENT_DATAGRIDVIEWROWHEIGHTCHANGED, value);
			}
		}

		/// Occurs when information about row height is requested. </summary>
		[SRCategory("CatData")]
		[SRDescription("DataGridView_RowHeightInfoNeededDescr")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public event DataGridViewRowHeightInfoNeededEventHandler RowHeightInfoNeeded;

		/// Occurs when the user changes the height of a row.</summary>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRDescription("DataGridView_RowHeightInfoPushedDescr")]
		[SRCategory("CatData")]
		public event DataGridViewRowHeightInfoPushedEventHandler RowHeightInfoPushed;

		/// Occurs when a row loses input focus and is no longer the current row.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_RowLeaveDescr")]
		[SRCategory("CatFocus")]
		public event DataGridViewCellEventHandler RowLeave;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.MinimumHeight"></see> property for a row changes.</summary>
		/// 1</filterpriority>
		[SRCategory("CatPropertyChanged")]
		[SRDescription("DataGridView_RowMinimumHeightChangedDescr")]
		public event DataGridViewRowEventHandler RowMinimumHeightChanged;

		/// Occurs after a new row is added to the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		[SRDescription("DataGridView_RowsAddedDescr")]
		[SRCategory("CatAction")]
		public event DataGridViewRowsAddedEventHandler RowsAdded;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowsDefaultCellStyle"></see> property changes.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridViewRowsDefaultCellStyleChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public event EventHandler RowsDefaultCellStyleChanged;

		/// Occurs when a row or rows are deleted from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		[SRCategory("CatAction")]
		[SRDescription("DataGridView_RowsRemovedDescr")]
		public event DataGridViewRowsRemovedEventHandler RowsRemoved;

		/// Occurs when a row changes state, such as losing or gaining input focus.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("DataGridView_RowStateChangedDescr")]
		public event DataGridViewRowStateChangedEventHandler RowStateChanged;

		/// Occurs when a row's state changes from shared to unshared.</summary>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[SRDescription("DataGridView_RowUnsharedDescr")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public event DataGridViewRowEventHandler RowUnshared;

		/// Occurs after a row has finished validating.</summary>
		/// 1</filterpriority>
		[SRCategory("CatFocus")]
		[SRDescription("DataGridView_RowValidatedDescr")]
		public event DataGridViewCellEventHandler RowValidated;

		/// Occurs when a row is validating.</summary>
		/// 1</filterpriority>
		[SRCategory("CatFocus")]
		[SRDescription("DataGridView_RowValidatingDescr")]
		public event DataGridViewCellCancelEventHandler RowValidating;

		/// Occurs when the current selection changes.</summary>
		/// 1</filterpriority>
		[SRCategory("CatAction")]
		[SRDescription("DataGridView_SelectionChangedDescr")]
		public event EventHandler SelectionChanged
		{
			add
			{
				AddCriticalHandler(SelectionChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(SelectionChangedEvent, value);
			}
		}

		/// 
		/// Occurs when [client selection changed].
		/// </summary>
		[SRDescription("Occurs when control's selection changed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientSelectionChanged
		{
			add
			{
				AddClientHandler("SelectionChanged", value);
			}
			remove
			{
				RemoveClientHandler("SelectionChanged", value);
			}
		}

		/// 
		/// Occurs when [client paging changed].
		/// </summary>
		[SRDescription("Occurs when control navigated to another page in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientPagingChanged
		{
			add
			{
				AddClientHandler("Navigate", value);
			}
			remove
			{
				RemoveClientHandler("Navigate", value);
			}
		}

		[SRDescription("Occurs when user is deleting data row in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientUserDeletingRow
		{
			add
			{
				AddClientHandler("Delete", value);
			}
			remove
			{
				RemoveClientHandler("Delete", value);
			}
		}

		/// Occurs when the current selection changes (queued version).</summary>
		/// 1</filterpriority>
		[SRCategory("CatAction")]
		[SRDescription("DataGridView_SelectionChangedDescr")]
		public event EventHandler SelectionChangedQueued;

		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> compares two cell values to perform a sort operation.</summary>
		[SRCategory("CatData")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[SRDescription("DataGridView_SortCompareDescr")]
		public event DataGridViewSortCompareEventHandler SortCompare;

		/// Occurs when the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control completes a sorting operation.</summary>
		[SRCategory("CatData")]
		[SRDescription("DataGridView_SortedDescr")]
		public event EventHandler Sorted;

		/// Occurs when the control style changes.</summary>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public event EventHandler StyleChanged;

		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.Text"></see> property changes.</summary>
		/// 1</filterpriority>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler TextChanged;

		/// 
		/// Occurs when the Text property value changes (Queued).
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new event EventHandler TextChangedQueued;

		/// Occurs when the user has finished adding a row to the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
		/// 1</filterpriority>
		[SRDescription("DataGridView_UserAddedRowDescr")]
		[SRCategory("CatAction")]
		public event DataGridViewRowEventHandler UserAddedRow;

		/// Occurs when the user has finished deleting a row from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
		/// 1</filterpriority>
		[SRCategory("CatAction")]
		[SRDescription("DataGridView_UserDeletedRowDescr")]
		public event DataGridViewRowEventHandler UserDeletedRow;

		/// Occurs when the user deletes a row from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
		/// 1</filterpriority>
		[SRCategory("CatAction")]
		[SRDescription("DataGridView_UserDeletingRowDescr")]
		public event DataGridViewRowCancelEventHandler UserDeletingRow;

		/// 
		/// Occurs when [custom header filter clicked].
		/// </summary>
		public event CustomFilterApplyingEventHandler CustomHeaderFilterClicked
		{
			add
			{
				AddHandler(CustomHeaderFilterClickedEvent, value);
			}
			remove
			{
				RemoveHandler(CustomHeaderFilterClickedEvent, value);
			}
		}

		/// 
		/// Occurs when the paging params have changed.
		/// </summary>
		public event EventHandler PagingChanged
		{
			add
			{
				AddHandler(PagingChangedEvent, value);
			}
			remove
			{
				RemoveHandler(PagingChangedEvent, value);
			}
		}

		/// 
		/// Raises the <see cref="E:CustomHeaderFilterClicked" /> event.
		/// </summary>
		/// <param name="objCustomFilterApplyingEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.CustomFilterApplyingEventArgs" /> instance containing the event data.</param>
		internal void OnCustomHeaderFilterClicked(CustomFilterApplyingEventArgs objCustomFilterApplyingEventArgs)
		{
			CustomHeaderFilterClickedEventHandler?.Invoke(this, objCustomFilterApplyingEventArgs);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> class.
		/// </summary>
		public DataGridView()
		{
			menmEditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
			menmRowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.EnableResizing;
			mobjCurrentCellPoint = new Point(-1, -1);
			mintRowHeadersWidth = 41;
			mintColumnHeadersHeight = 23;
			menmColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			mobjAdvancedDataGridViewBorderStyle = new DataGridViewAdvancedBorderStyle(this);
			NewRowIndex = -1;
			mobjDataGridViewState1[8388635] = true;
			mobjDataGridViewState1[128] = true;
			mobjDataGridViewState2[100664295] = true;
			DisplayedBandsInfo = new DisplayedBandsData();
			ColumnHeadersVisible = true;
			mobjBackgroundColor = DefaultBackgroundBrush.Color;
			DimensionChangeCount = 0;
			SelectedBandIndexes = new DataGridViewIntLinkedList();
			IndividualSelectedCells = new DataGridViewCellLinkedList();
			IndividualReadOnlyCells = new DataGridViewCellLinkedList();
			menmSelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
			menmExpansionIndicator = ShowExpansionIndicator.CheckOnExpand;
			SortOrder = SortOrder.None;
			menmScrollBars = ScrollBars.Both;
			menmClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
			HierarchyLevel = -1;
			SetStyle(ControlStyles.Opaque | ControlStyles.UserMouse | ControlStyles.UserPaint, blnValue: true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, blnValue: false);
			LayoutInfo = new LayoutData
			{
				TopLeftHeader = Rectangle.Empty,
				ColumnHeaders = Rectangle.Empty,
				RowHeaders = Rectangle.Empty,
				ColumnHeadersVisible = true,
				RowHeadersVisible = true
			};
			BorderStyle = BorderStyle.FixedSingle;
			menmAutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
			menmAutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
			InitializeGroupingStyleProperties();
		}

		/// 
		/// Initializes the grouping style properties.
		/// </summary>
		private void InitializeGroupingStyleProperties()
		{
			if (SkinFactory.GetSkin(this) is DataGridViewSkin dataGridViewSkin)
			{
				mobjGroupingAreaBackColor = dataGridViewSkin.GroupingDropAreaStyle.BackColor;
				mobjGroupingAreaBorderColor = dataGridViewSkin.GroupingDropAreaStyle.BorderColor;
				mobjGroupingAreaBorderStyle = dataGridViewSkin.GroupingDropAreaStyle.BorderStyle;
				mobjGroupingAreaBorderWidth = dataGridViewSkin.GroupingDropAreaStyle.BorderWidth;
				menmGroupingAreaBackgroundImageRepeat = dataGridViewSkin.BackgroundImageRepeat;
				menmGroupingAreaBackgroundImagePosition = dataGridViewSkin.BackgroundImagePosition;
				mintGroupingAreaHeight = dataGridViewSkin.DropAreaHeight;
			}
		}

		/// 
		///
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (SelectionChangedHandler != null || CurrentCellChangedHandler != null || IsSelectionChangeCritical)
			{
				criticalEventsData.Set("SLC");
			}
			if (ColumnDividerDoubleClickHandler != null)
			{
				criticalEventsData.Set("CDD");
			}
			if ((object)RowExpandingHandler != null || (object)RowExpandedHandler != null)
			{
				criticalEventsData.Set("EXP");
			}
			if ((object)GetHandler(EVENT_ROWCOLLAPSED) != null || (object)GetHandler(EVENT_ROWCOLLAPSING) != null)
			{
				criticalEventsData.Set("COL");
			}
			return criticalEventsData;
		}

		/// 
		/// Gets the critical client events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			if (HasClientHandler("SelectionChanged"))
			{
				criticalClientEventsData.Set("SLC");
			}
			if (HasClientHandler("DividerDoubleClick"))
			{
				criticalClientEventsData.Set("CDD");
			}
			if (HasClientHandler("Expand"))
			{
				criticalClientEventsData.Set("EXP");
			}
			if (HasClientHandler("Collapse"))
			{
				criticalClientEventsData.Set("COL");
			}
			if (HasClientHandler("BeginEdit"))
			{
				criticalClientEventsData.Set("BE");
			}
			if (HasClientHandler("EndEdit"))
			{
				criticalClientEventsData.Set("EE");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			string member = objEvent.Member;
			if (objEvent.Type == "VisualTemplate")
			{
				base.FireEvent(objEvent);
				return;
			}
			if (string.IsNullOrEmpty(member))
			{
				base.FireEvent(objEvent);
				switch (objEvent.Type)
				{
				case "Navigate":
				{
					string text3 = objEvent["To"];
					switch (text3)
					{
					case "End":
						CurrentPage = TotalPages;
						break;
					case "Home":
						CurrentPage = 1;
						break;
					case "Next":
						if (CurrentPage < TotalPages)
						{
							CurrentPage++;
						}
						break;
					case "Back":
						if (CurrentPage > 1)
						{
							CurrentPage--;
						}
						break;
					default:
					{
						if (int.TryParse(text3, out var result) && result > 0 && result <= TotalPages)
						{
							CurrentPage = result;
						}
						break;
					}
					}
					PagingChangedHandler?.Invoke(this, EventArgs.Empty);
					break;
				}
				case "Delete":
					if (ProcessDeleteKey(Keys.Delete))
					{
						Update();
						SetFocus();
					}
					break;
				case "SelectionChanged":
				{
					NoSelectionChangeCount++;
					bool flag = objEvent["Incremental"] == "1";
					try
					{
						string text2 = objEvent["VLB"];
						if (text2 != null)
						{
							bool flag2 = text2 == "*";
							DataGridViewSelectionMode selectionMode = SelectionMode;
							string[] arrValues = text2.Split(',');
							IList list;
							if (!(MultiSelect && flag))
							{
								IList rows = Rows;
								list = rows;
							}
							else
							{
								list = PageRows;
							}
							IList list2 = list;
							foreach (DataGridViewRow item in list2)
							{
								if (!(item.Visible || flag2))
								{
									continue;
								}
								if (selectionMode == DataGridViewSelectionMode.CellSelect || selectionMode == DataGridViewSelectionMode.RowHeaderSelect)
								{
									foreach (DataGridViewCell cell in item.Cells)
									{
										if (cell.Selected)
										{
											if (!flag2 && !HasValue(arrValues, cell.MemberIDInternal))
											{
												cell.ClientState |= DataGridViewElementClientStates.Selected;
												SetSelectedCellCore(cell.ColumnIndex, cell.RowIndex, blnSelected: false, blnClientSource: true);
												cell.ClientState &= ~DataGridViewElementClientStates.Selected;
											}
										}
										else if (flag2 || HasValue(arrValues, cell.MemberIDInternal))
										{
											cell.ClientState |= DataGridViewElementClientStates.Selected;
											SetSelectedCellCore(cell.ColumnIndex, cell.RowIndex, blnSelected: true, blnClientSource: true);
											cell.ClientState &= ~DataGridViewElementClientStates.Selected;
										}
									}
								}
								if (selectionMode != DataGridViewSelectionMode.FullRowSelect && selectionMode != DataGridViewSelectionMode.RowHeaderSelect)
								{
									continue;
								}
								if (item.Selected)
								{
									if (!flag2 && !HasValue(arrValues, item.MemberIDInternal))
									{
										item.ClientState |= DataGridViewElementClientStates.Selected;
										SetSelectedRowCore(item.Index, blnSelected: false, blnClientSource: true);
										item.ClientState &= ~DataGridViewElementClientStates.Selected;
									}
								}
								else if (flag2 || HasValue(arrValues, item.MemberIDInternal))
								{
									item.ClientState |= DataGridViewElementClientStates.Selected;
									SetSelectedRowCore(item.Index, blnSelected: true, blnClientSource: true);
									item.ClientState &= ~DataGridViewElementClientStates.Selected;
								}
							}
						}
						if (!objEvent.Contains("CRC"))
						{
							break;
						}
						Point memberPosition = GetMemberPosition(objEvent["CRC"]);
						if (!IsInnerCellOutOfBounds(memberPosition.X, memberPosition.Y) && PageRows.Contains(Rows.SharedRow(memberPosition.Y)))
						{
							bool blnValidateCurrentCell = mobjCurrentCellPoint.Y != memberPosition.Y || mobjCurrentCellPoint.X != memberPosition.X;
							this[memberPosition.X, memberPosition.Y].ClientState |= DataGridViewElementClientStates.CurrentCell;
							SetCurrentCellAddressCore(memberPosition.X, memberPosition.Y, blnSetAnchorCellAddress: true, blnValidateCurrentCell, blnThroughMouseClick: false, blnClientSource: true);
							if (!IsInnerCellOutOfBounds(memberPosition.X, memberPosition.Y))
							{
								this[memberPosition.X, memberPosition.Y].ClientState &= ~DataGridViewElementClientStates.CurrentCell;
							}
						}
						break;
					}
					finally
					{
						NoSelectionChangeCount--;
					}
				}
				case "ColumnsReorder":
				{
					if (!objEvent.Contains("DCN") || !objEvent.Contains("TCN"))
					{
						break;
					}
					int num = Convert.ToInt32(objEvent["DCN"]);
					int num2 = Convert.ToInt32(objEvent["TCN"]);
					if (num >= 0 && num < Columns.Count && num2 >= 0 && num2 < Columns.Count && Columns[num] != null && Columns[num2] != null)
					{
						int num3 = Columns[num2].DisplayIndex;
						if (Columns[num].DisplayIndex > num3 && !(objEvent["BFR"] == "1"))
						{
							num3++;
						}
						Columns[num].DisplayIndex = num3;
						Columns.InvalidateCachedColumnsOrder();
						Update();
					}
					break;
				}
				case "ClearFilters":
					ClearAllFilters();
					break;
				case "OpenColumnChooser":
					ShowColumnPickerDialog();
					break;
				case "InsertGroup":
				{
					string strTargetDataPropertyName = objEvent["TCN"] ?? string.Empty;
					string text = objEvent["DCN"];
					if (!string.IsNullOrEmpty(text))
					{
						InsertGroupingColumn(strTargetDataPropertyName, text);
						OnGroupingChanged(DataGridViewGroupingAction.Add, text);
					}
					break;
				}
				}
				return;
			}
			if (member.StartsWith("DGVB"))
			{
				int result2 = -1;
				if (int.TryParse(member.Substring(4), out result2) && objEvent.Type == "Load")
				{
					DataGridRowBlockInfo blockInfo = GetBlockInfo(result2);
					if (blockInfo != null)
					{
						blockInfo.LoadRows();
						blockInfo.Update();
					}
				}
				return;
			}
			Point memberPosition2 = GetMemberPosition(member);
			if (memberPosition2.X != -1 && memberPosition2.Y != -1)
			{
				switch (member[0])
				{
				case 'D':
					Rows.SharedRow(memberPosition2.Y)?.Cells[memberPosition2.X].FireEvent(objEvent);
					break;
				case 'C':
					Columns[memberPosition2.X].FireEvent(objEvent);
					break;
				case 'R':
				{
					DataGridViewRow dataGridViewRow2 = null;
					((!ShowFilterRow) ? Rows.SharedRow(memberPosition2.Y) : ((memberPosition2.Y != 0) ? Rows.SharedRow(memberPosition2.Y - 1) : mobjDataGridViewFilterRow))?.FireEvent(objEvent);
					break;
				}
				}
			}
			else if (memberPosition2.X != -1)
			{
				Columns[memberPosition2.X].HeaderCell?.FireEvent(objEvent);
			}
			else if (memberPosition2.Y != -1)
			{
				Rows[memberPosition2.Y].HeaderCell?.FireEvent(objEvent);
			}
			else if (member == TopLeftHeaderCell.MemberIDInternal)
			{
				TopLeftHeaderCell.FireEvent(objEvent);
			}
		}

		/// 
		/// Called when [grouping changed].
		/// </summary>
		/// <param name="strColumnDataPropertyName">Name of the STR dragged column data property.</param>
		internal void OnGroupingChanged(DataGridViewGroupingAction enmAction, string strColumnDataPropertyName)
		{
			if (!string.IsNullOrEmpty(strColumnDataPropertyName))
			{
				DataGridViewColumnCollection columns = Columns;
				string realDataMemberForProposedMember = columns.GetRealDataMemberForProposedMember(strColumnDataPropertyName);
				DataGridViewColumn dataGridViewColumn = columns[realDataMemberForProposedMember];
				if (dataGridViewColumn != null && GroupingChangedEventHandler != null)
				{
					GroupingChangedEventArgs e = new GroupingChangedEventArgs(enmAction, dataGridViewColumn);
					GroupingChangedEventHandler(this, e);
				}
			}
		}

		/// 
		/// Clears all filters.
		/// </summary>
		public void ClearAllFilters()
		{
			mblnSuspendFilterInitialization = true;
			try
			{
				if (ShowFilterRow && mobjDataGridViewFilterRow != null)
				{
					foreach (DataGridViewFilterCell cell in mobjDataGridViewFilterRow.Cells)
					{
						cell.ClearFilter(blnClearHeaderFilter: true);
					}
				}
				else
				{
					foreach (DataGridViewColumn column in Columns)
					{
						column.ClearFilter(blnClearHeaderFilter: true);
					}
				}
			}
			finally
			{
				mblnSuspendFilterInitialization = false;
			}
			ApplyDataGridViewFilter();
		}

		/// 
		/// Sets the focus abck to the grid.
		/// </summary>
		private void SetFocus()
		{
			if (Context is IApplicationContext applicationContext)
			{
				applicationContext.SetFocused(this, blnInvokeFocusCommand: true);
			}
		}

		/// 
		/// Sets the selected cell core.
		/// </summary>
		/// <param name="intColumnIndex">Index of the int column.</param>
		/// <param name="intRowIndex">Index of the int row.</param>
		/// <param name="blnSelected">if set to true</c> [BLN selected].</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		private void SetSelectedCellCore(int intColumnIndex, int intRowIndex, bool blnSelected, bool blnClientSource)
		{
			if (intColumnIndex < 0 || intColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("columnIndex");
			}
			DataGridViewRowCollection rows = Rows;
			if (intRowIndex < 0 || intRowIndex >= rows.Count)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			DataGridViewRow dataGridViewRow = rows.SharedRow(intRowIndex);
			DataGridViewElementStates rowState = rows.GetRowState(intRowIndex);
			if (IsSharedCellSelected(dataGridViewRow.Cells[intColumnIndex], intRowIndex) == blnSelected)
			{
				return;
			}
			DataGridViewCell dataGridViewCell = rows[intRowIndex].Cells[intColumnIndex];
			DataGridViewIntLinkedList dataGridViewIntLinkedList = null;
			DataGridViewCellLinkedList individualSelectedCells = IndividualSelectedCells;
			if (blnSelected)
			{
				if ((rowState & DataGridViewElementStates.Selected) == 0 && !Columns[intColumnIndex].Selected)
				{
					individualSelectedCells.Add(dataGridViewCell);
					SetSelectedCellCore(dataGridViewCell, blnValue: true, blnClientSource);
				}
				return;
			}
			if ((dataGridViewCell.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.None)
			{
				individualSelectedCells.Remove(dataGridViewCell);
			}
			else
			{
				bool flag = false;
				if (SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
				{
					if (Rows.Count > 8)
					{
						BulkPaintCount++;
						flag = true;
					}
					try
					{
						dataGridViewIntLinkedList = SelectedBandIndexes;
						dataGridViewIntLinkedList.Remove(intColumnIndex);
						Columns[intColumnIndex].SelectedInternal = false;
						for (int i = 0; i < intRowIndex; i++)
						{
							DataGridViewCell objDataGridViewCell = rows[i].Cells[intColumnIndex];
							SetSelectedCellCore(objDataGridViewCell, blnValue: true, blnClientSource);
							individualSelectedCells.Add(objDataGridViewCell);
						}
						for (int j = intRowIndex + 1; j < rows.Count; j++)
						{
							DataGridViewCell objDataGridViewCell = rows[j].Cells[intColumnIndex];
							SetSelectedCellCore(objDataGridViewCell, blnValue: true, blnClientSource);
							individualSelectedCells.Add(objDataGridViewCell);
						}
						if (dataGridViewCell.Selected)
						{
							SetSelectedCellCore(dataGridViewCell, blnValue: false, blnClientSource);
						}
						return;
					}
					finally
					{
						if (flag)
						{
							ExitBulkPaint(intColumnIndex, -1);
						}
					}
				}
				if (SelectionMode == DataGridViewSelectionMode.RowHeaderSelect)
				{
					if (Columns.Count > 8)
					{
						BulkPaintCount++;
						flag = true;
					}
					try
					{
						if (dataGridViewIntLinkedList == null)
						{
							dataGridViewIntLinkedList = SelectedBandIndexes;
						}
						dataGridViewIntLinkedList.Remove(intRowIndex);
						rows.SetRowState(intRowIndex, DataGridViewElementStates.Selected, blnValue: false);
						for (int k = 0; k < intColumnIndex; k++)
						{
							DataGridViewCell objDataGridViewCell = rows[intRowIndex].Cells[k];
							SetSelectedCellCore(objDataGridViewCell, blnValue: true, blnClientSource);
							individualSelectedCells.Add(objDataGridViewCell);
						}
						for (int l = intColumnIndex + 1; l < Columns.Count; l++)
						{
							DataGridViewCell objDataGridViewCell = rows[intRowIndex].Cells[l];
							SetSelectedCellCore(objDataGridViewCell, blnValue: true, blnClientSource);
							individualSelectedCells.Add(objDataGridViewCell);
						}
					}
					finally
					{
						if (flag)
						{
							ExitBulkPaint(-1, intRowIndex);
						}
					}
				}
			}
			if (dataGridViewCell.Selected)
			{
				SetSelectedCellCore(dataGridViewCell, blnValue: false, blnClientSource);
			}
		}

		/// 
		/// Sets the selected cell core.
		/// </summary>
		/// <param name="objDataGridViewCell">The obj data grid view cell.</param>
		/// <param name="blnValue">if set to true</c> [BLN value].</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		internal void SetSelectedCellCore(DataGridViewCell objDataGridViewCell, bool blnValue, bool blnClientSource)
		{
			if (objDataGridViewCell != null)
			{
				if (!blnClientSource && (objDataGridViewCell.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected != blnValue)
				{
					objDataGridViewCell.UpdateParams(AttributeType.Visual);
				}
				objDataGridViewCell.SelectedInternal = blnValue;
			}
		}

		/// 
		/// Gets the member position.
		/// </summary>
		/// <param name="strMember">The STR member.</param>
		/// </returns>
		internal Point GetMemberPosition(string strMember)
		{
			Point result = new Point(-1, -1);
			if (!string.IsNullOrEmpty(strMember))
			{
				if (strMember.Contains("GHC"))
				{
					result = new Point(-1, -1);
				}
				else if (strMember.Contains("HC"))
				{
					int num = int.Parse(strMember.Substring(3));
					result = ((!strMember.Contains("RHC")) ? new Point(num, -1) : new Point(-1, num));
				}
				else
				{
					int num2 = int.Parse(strMember.Substring(1));
					switch (strMember[0])
					{
					case 'D':
					{
						int num3 = (int)Math.Floor((double)(num2 / ColumnCount));
						int x = num2 - num3 * ColumnCount;
						result = new Point(x, num3 - ((ShowFilterRow && num3 > 0) ? 1 : 0));
						break;
					}
					case 'C':
					case 'R':
						result = new Point(num2, num2);
						break;
					}
				}
			}
			return result;
		}

		/// 
		/// Checks if a string collection has value
		/// </summary>
		/// <param name="arrValues"></param>
		/// <param name="strValue"></param>
		/// </returns>
		private bool HasValue(string[] arrValues, string strValue)
		{
			foreach (string text in arrValues)
			{
				if (text == strValue)
				{
					return true;
				}
			}
			return false;
		}

		/// 
		/// Renders the row data.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		private void RenderRowData(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			objWriter.WriteStartElement("XCR");
			foreach (ExtendedHeaderRowData row in mobjExtendedColumnHeaders.Rows)
			{
				row.RenderRow(objWriter);
			}
			objWriter.WriteEndElement();
		}

		/// 
		/// Renders the user controls in extended column header cells collection.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		private void RenderExtendedColumnHeaderCellUserControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			objWriter.WriteStartElement("XC");
			foreach (ExtendedHeaderUserControl headerControl in mobjExtendedColumnHeaders.HeaderControls)
			{
				headerControl.RenderControl(objContext, objWriter, lngRequestID);
			}
			objWriter.WriteEndElement();
		}

		/// 
		/// Raises the <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControl"></see> event.
		/// </summary>
		protected override void OnCreateControl()
		{
			base.OnCreateControl();
			if (mobjCurrentCellPoint.X != -1)
			{
				ScrollIntoView(mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y, blnForCurrentCellChange: false);
			}
			OnGlobalAutoSize();
		}

		/// 
		/// Pre-render control.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
		{
			if (IsDirty(lngRequestID))
			{
				if (ShouldPreRenderUpdate(PreRenderUpdateType.GroupingData))
				{
					InitializeGroupingData();
				}
				if (ShouldPreRenderUpdate(PreRenderUpdateType.GroupHeaders))
				{
					PreRenderGroupingData();
				}
				if (ShouldPreRenderUpdate(PreRenderUpdateType.FilterRow))
				{
					PreRenderFilterRowCells();
				}
			}
			PreRenderTopLeftHeaderCell(objContext, lngRequestID, IsDirty(lngRequestID));
			PreRenderColumns(objContext, lngRequestID, IsDirty(lngRequestID));
			PreRenderRows(objContext, lngRequestID, IsDirty(lngRequestID));
			base.PreRenderControl(objContext, lngRequestID);
		}

		/// 
		/// Initializes grouping system hierarchies and treeview.
		/// </summary>
		private void InitializeGroupingData()
		{
			ResetDataBinding();
			if (HideGroupedColumns)
			{
				UniqueObservableCollection<object> groupingColumns = GroupingColumns;
				DataGridViewColumnCollection columns = Columns;
				foreach (string item in groupingColumns)
				{
					string realDataMemberForProposedMember = columns.GetRealDataMemberForProposedMember(item);
					if (!string.IsNullOrEmpty(realDataMemberForProposedMember))
					{
						columns[realDataMemberForProposedMember].Visible = false;
					}
				}
			}
			if (mobjGroupingTreeView == null)
			{
				mobjGroupingTreeView = new DataGridViewGroupingTreeView(this);
			}
			else
			{
				mobjGroupingTreeView.InitializeGroupingNodes();
			}
			SwitchPreRenderUpdate((PreRenderUpdateType)(-2));
		}

		/// 
		/// Prerenders filter row cells.
		/// </summary>
		private void PreRenderFilterRowCells()
		{
			InitializeFilterRow();
			SwitchPreRenderUpdate((PreRenderUpdateType)(-3));
		}

		/// 
		/// Posts the render control.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		protected internal override void PostRenderControl(IContext objContext, long lngRequestID)
		{
			base.PostRenderControl(objContext, lngRequestID);
			PostRenderTopLeftHeaderCell(objContext, lngRequestID, IsDirty(lngRequestID));
			PostRenderColumns(objContext, lngRequestID, IsDirty(lngRequestID));
			PostRenderRows(objContext, lngRequestID, IsDirty(lngRequestID));
		}

		/// 
		/// Pres the render control internal.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		internal void PreRenderControlInternal(IContext objContext, long lngRequestID)
		{
			PreRenderControl(objContext, lngRequestID);
		}

		/// 
		/// Posts the render control internal.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		internal void PostRenderControlInternal(IContext objContext, long lngRequestID)
		{
			PostRenderControl(objContext, lngRequestID);
		}

		/// 
		/// Pres the render top left header cell.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnForcePreRender">if set to true</c> [BLN force pre render].</param>
		private void PreRenderTopLeftHeaderCell(IContext objContext, long lngRequestID, bool blnForcePreRender)
		{
			TopLeftHeaderCell?.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
		}

		/// 
		/// Posts the render top left header cell.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnForcePostRender">if set to true</c> [BLN force post render].</param>
		private void PostRenderTopLeftHeaderCell(IContext objContext, long lngRequestID, bool blnForcePostRender)
		{
			TopLeftHeaderCell?.PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
		}

		/// 
		/// Checks if the current control needs rendering and
		/// continues to process sub tree/
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected internal override void RenderControl(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			base.RenderControl(objContext, objWriter, lngRequestID);
		}

		/// 
		/// Renders the control's meta attributes
		/// </summary>
		/// <param name="objContext">The current VWG Context</param>
		/// <param name="objWriter">The XML stream writer</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			if (IsVirtualDataGridView)
			{
				objWriter.WriteAttributeString("VR", "1");
			}
			RenderStandardTabAttribute(objWriter, blnForceRender: false);
			RenderEnforceEqualRowSizeAttribute(objWriter, blnForceRender: false);
			RenderIsCaptionVisibleAttribute(objWriter, blnForceRender: false);
			RenderCaptionHeightAttribute(objWriter, blnForceRender: false);
			RenderShowGroupingDropAreaAttribute(objWriter, blnForceRender: false);
			RenderGroupingAreaStyleProperties(objWriter, objContext, blnForceRender: false);
			objWriter.WriteAttributeString("SM", ((int)SupportedSelectionMode).ToString());
			RenderTextAttribute(objWriter, blnForceRender: false);
			RenderDisableNavigation(objWriter, blnForceRender: false);
			RenderScrollbarsAttribute(objWriter, blnForceRender: false);
			RenderCurrentCell(objContext, objWriter, blnForceRender: false);
			if (IsHierarchic(HierarchicInfoSelector.Any))
			{
				RenderHierarchicAttributes(objWriter);
			}
			objWriter.WriteAttributeString("DGVHL", mintHierarchyLevel.ToString());
			objWriter.WriteAttributeString("CP", CurrentPage.ToString());
			objWriter.WriteAttributeString("TOP", TotalPages.ToString());
			RenderMultiSelect(objWriter, blnForceRender: false);
			RenderShowEditingIcon(objWriter, blnForceRender: false);
			if (!RowHeadersVisible)
			{
				objWriter.WriteAttributeString("RHS", "0");
			}
			else
			{
				objWriter.WriteAttributeString("RHS", RowHeadersWidth.ToString());
			}
			if (!ColumnHeadersVisible)
			{
				objWriter.WriteAttributeString("CHS", "0");
			}
			else
			{
				objWriter.WriteAttributeString("CHS", ColumnHeadersHeight.ToString());
			}
			if (CellBorderStyle != DataGridViewCellBorderStyle.Single)
			{
				objWriter.WriteAttributeString("CBS", ((byte)CellBorderStyle).ToString());
			}
			if (ReadOnly)
			{
				objWriter.WriteAttributeString("RO", "1");
			}
			if (IsVirtualDataGridView)
			{
				objWriter.WriteAttributeString("RCT", (Rows.Count + (ShowFilterRow ? 1 : 0)).ToString());
				objWriter.WriteAttributeString("VBS", (UseInternalPaging ? ItemsPerPage : VirtualBlockSize).ToString());
			}
			RenderColumnsCount(objWriter);
			RenderAllowUserToOrderColumns(objWriter, blnForceRender: false);
			RenderSelectOnRightClick(objWriter, blnForceRender: false);
			RenderEditModeAttribute(objWriter, blnForceRender: false);
			RenderShowColumnChooserAttribute(objWriter, blnForceRender: false);
			RenderNavigationKeyFilterAttribute(objWriter, blnForceRender: false);
		}

		/// 
		/// Renders the navigation key filter attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderNavigationKeyFilterAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (menmNavigationKeyFilter != NavigationKeyFilter.None || blnForceRender)
			{
				int num = (int)menmNavigationKeyFilter;
				objWriter.WriteAttributeString("NKF", num.ToString());
			}
		}

		/// 
		/// Renders the grouping area style properties.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="objContext">The obj context.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderGroupingAreaStyleProperties(IAttributeWriter objWriter, IContext objContext, bool blnForceRender)
		{
			if (SkinFactory.GetSkin(this) is DataGridViewSkin dataGridViewSkin)
			{
				if (GroupingAreaStyleProperties.BackColor != dataGridViewSkin.GroupingDropAreaStyle.BackColor || blnForceRender)
				{
					objWriter.WriteAttributeText("GABG", CommonUtils.GetHtmlColor(GroupingAreaBackColor));
				}
				if (ShouldRenderGroupingAreaBorder(dataGridViewSkin) || blnForceRender)
				{
					BorderValue borderValue = new BorderValue();
					borderValue.Width = GroupingAreaBorderWidth;
					borderValue.Color = GroupingAreaBorderColor;
					borderValue.Style = GroupingAreaBorderStyle;
					objWriter.WriteAttributeString("GABR", borderValue.GetValue(objContext));
				}
				if (GroupingAreaBackgroundImage != null)
				{
					objWriter.WriteAttributeString("GABI", GroupingAreaBackgroundImage.ToString());
				}
				if (ShouldRenderGroupingAreaBackgroundImagePosition(dataGridViewSkin) || blnForceRender)
				{
					objWriter.WriteAttributeString("GABIP", (int)GroupingAreaBackgroundImagePosition);
				}
				if (ShouldRenderGroupingAreaBackgroundImageRepeat(dataGridViewSkin) || blnForceRender)
				{
					objWriter.WriteAttributeString("GABIR", (int)GroupingAreaBackgroundImageRepeat);
				}
				if (ShouldRenderGroupingAreaHeight(dataGridViewSkin) || blnForceRender)
				{
					objWriter.WriteAttributeString("DAH", GroupingAreaHeight);
				}
			}
		}

		/// 
		/// Defines whether to render grouping area border.
		/// </summary>
		/// <param name="objSkin">The obj skin.</param>
		/// </returns>
		private bool ShouldRenderGroupingAreaBorder(DataGridViewSkin objSkin)
		{
			return GroupingAreaBorderColor != objSkin.GroupingDropAreaStyle.BorderColor && GroupingAreaBorderStyle != objSkin.GroupingDropAreaStyle.BorderStyle && GroupingAreaBorderWidth != objSkin.GroupingDropAreaStyle.BorderWidth;
		}

		/// 
		///  Defines whether to render grouping area background image repeat.
		/// </summary>
		/// <param name="objSkin">The obj skin.</param>
		/// </returns>
		private bool ShouldRenderGroupingAreaBackgroundImageRepeat(DataGridViewSkin objSkin)
		{
			return GroupingAreaBackgroundImageRepeat != objSkin.GroupingDropAreaStyle.BackgroundImageRepeat;
		}

		/// 
		/// Defines whether to render grouping area height.
		/// </summary>
		/// <param name="objSkin">The obj skin.</param>
		/// </returns>
		private bool ShouldRenderGroupingAreaHeight(DataGridViewSkin objSkin)
		{
			return GroupingAreaHeight != objSkin.DropAreaHeight;
		}

		/// 
		///  Defines whether to render grouping area background image Position.
		/// </summary>
		/// <param name="objSkin">The obj skin.</param>
		/// </returns>
		private bool ShouldRenderGroupingAreaBackgroundImagePosition(DataGridViewSkin objSkin)
		{
			return GroupingAreaBackgroundImagePosition != objSkin.GroupingDropAreaStyle.BackgroundImagePosition;
		}

		/// 
		/// Renders the hidden columns count.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderColumnsCount(IAttributeWriter objWriter)
		{
			objWriter.WriteAttributeString("ACH", Columns.Count);
		}

		/// 
		/// Renders the show grouping drop area attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderShowGroupingDropAreaAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (blnForceRender || ShowGroupingDropArea)
			{
				objWriter.WriteAttributeText("SGDA", ShowGroupingDropArea ? "1" : "0");
			}
		}

		/// 
		/// Renders the scrollbars attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderScrollbarsAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (blnForceRender || ScrollBars != ScrollBars.Both)
			{
				objWriter.WriteAttributeString("SB", ((int)ScrollBars).ToString());
			}
		}

		/// 
		/// Renders the hierarchic attributes.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		private void RenderHierarchicAttributes(IAttributeWriter objWriter)
		{
			objWriter.WriteAttributeText("IHC", "1");
			if (IsHierarchic(HierarchicInfoSelector.Bounded))
			{
				objWriter.WriteAttributeString("BOD", "1");
			}
			RenderExpansionIndicator(objWriter, blnForceRender: false);
		}

		/// 
		/// Renders the expansion indicator.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderExpansionIndicator(IAttributeWriter objWriter, bool blnForceRender)
		{
			ShowExpansionIndicator expansionIndicator = ExpansionIndicator;
			if (expansionIndicator != ShowExpansionIndicator.CheckOnExpand || blnForceRender)
			{
				int num = (int)expansionIndicator;
				objWriter.WriteAttributeString("EIN", num.ToString());
			}
		}

		/// 
		/// Renders the text attribute.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderTextAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			string text = Text;
			if (!string.IsNullOrEmpty(text) || blnForceRender)
			{
				objWriter.WriteAttributeText("TX", text);
			}
		}

		/// 
		/// Renders the edit mode attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderEditModeAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			DataGridViewEditMode editMode = EditMode;
			if (editMode != DataGridViewEditMode.EditOnKeystrokeOrF2 || blnForceRender)
			{
				int num = (int)editMode;
				objWriter.WriteAttributeString("EMD", num.ToString());
			}
		}

		/// 
		/// Renders the standard tab attribute.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderStandardTabAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			bool standardTab = StandardTab;
			if (standardTab || blnForceRender)
			{
				objWriter.WriteAttributeString("STAB", standardTab ? "1" : "0");
			}
		}

		/// 
		/// Renders the allow user to order columns.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> force render.</param>
		private void RenderAllowUserToOrderColumns(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (AllowUserToOrderColumns)
			{
				objWriter.WriteAttributeString("AOC", "1");
			}
			else if (blnForceRender)
			{
				objWriter.WriteAttributeString("AOC", "0");
			}
		}

		/// 
		/// Renders the select on right click.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderSelectOnRightClick(IAttributeWriter objWriter, bool blnForceRender)
		{
			bool selectOnRightClick = SelectOnRightClick;
			if (selectOnRightClick || blnForceRender)
			{
				objWriter.WriteAttributeString("SOR", selectOnRightClick ? "1" : "0");
			}
		}

		/// 
		/// Renders the show column chooser attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderShowColumnChooserAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			bool showColumnChooser = ShowColumnChooser;
			if (showColumnChooser || blnForceRender)
			{
				objWriter.WriteAttributeString("CCH", showColumnChooser ? "1" : "0");
			}
		}

		/// 
		/// Renders the disable navigation.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> force render.</param>
		private void RenderDisableNavigation(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (DisableNavigation)
			{
				objWriter.WriteAttributeString("DNV", "1");
			}
			else if (blnForceRender)
			{
				objWriter.WriteAttributeString("DNV", "0");
			}
		}

		/// 
		/// Renders the multi select.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> force render.</param>
		private void RenderMultiSelect(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (!MultiSelect)
			{
				objWriter.WriteAttributeString("MU", "0");
			}
			else if (blnForceRender)
			{
				objWriter.WriteAttributeString("MU", "1");
			}
		}

		/// 
		/// Renders the show editing icon.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderShowEditingIcon(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (!ShowEditingIcon)
			{
				objWriter.WriteAttributeString("SEI", "0");
			}
			else if (blnForceRender)
			{
				objWriter.WriteAttributeString("SEI", "1");
			}
		}

		/// 
		/// Renders only the control's updated meta attributes
		/// </summary>
		/// <param name="objContext">The current VWG Context</param>
		/// <param name="objWriter">The XML stream writer</param>
		/// <param name="lngRequestID">The ID of the request currently being handled</param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				RenderAllowUserToOrderColumns(objWriter, blnForceRender: true);
				RenderDisableNavigation(objWriter, blnForceRender: true);
				RenderMultiSelect(objWriter, blnForceRender: true);
				RenderStandardTabAttribute(objWriter, blnForceRender: true);
				RenderSelectOnRightClick(objWriter, blnForceRender: true);
				RenderEditModeAttribute(objWriter, blnForceRender: true);
				RenderTextAttribute(objWriter, blnForceRender: true);
				RenderExpansionIndicator(objWriter, blnForceRender: true);
				RenderShowColumnChooserAttribute(objWriter, blnForceRender: true);
				RenderShowEditingIcon(objWriter, blnForceRender: true);
				RenderNavigationKeyFilterAttribute(objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				objWriter.WriteAttributeString("CBS", ((byte)CellBorderStyle).ToString());
				RenderCurrentCell(objContext, objWriter, blnForceRender: true);
				RenderGroupingAreaStyleProperties(objWriter, objContext, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
			{
				RenderEnforceEqualRowSizeAttribute(objWriter, blnForceRender: true);
				RenderIsCaptionVisibleAttribute(objWriter, blnForceRender: true);
				RenderShowGroupingDropAreaAttribute(objWriter, blnForceRender: true);
				RenderScrollbarsAttribute(objWriter, blnForceRender: true);
				RenderCaptionHeightAttribute(objWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the resize all rows attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderEnforceEqualRowSizeAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			bool enforceEqualRowSize = EnforceEqualRowSize;
			if (enforceEqualRowSize || blnForceRender)
			{
				objWriter.WriteAttributeString("EER", enforceEqualRowSize ? "1" : "0");
			}
		}

		/// 
		/// Renders the is caption visible attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderIsCaptionVisibleAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			bool isCaptionVisible = IsCaptionVisible;
			if (isCaptionVisible || blnForceRender)
			{
				objWriter.WriteAttributeString("ICV", isCaptionVisible ? "1" : "0");
			}
		}

		/// 
		/// Renders the caption height attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderCaptionHeightAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (IsCaptionVisible)
			{
				int num = CaptionHeight;
				if (num == 0 && base.Skin is DataGridViewSkin { CaptionStyle: var captionStyle })
				{
					num = CommonUtils.GetFontHeight(captionStyle.Font) + captionStyle.Padding.Vertical;
				}
				objWriter.WriteAttributeString("CH", num.ToString());
			}
		}

		/// 
		/// Renders the current cell.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		private void RenderCurrentCell(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
		{
			if (CurrentCell != null)
			{
				objWriter.WriteAttributeString("CRC", CurrentCell.MemberIDInternal.ToString());
			}
			else if (blnForceRender)
			{
				objWriter.WriteAttributeString("CRC", string.Empty);
			}
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			bool blnRenderOwner = !IsDirty(lngRequestID);
			RenderExtendedColumnHeader(objContext, objWriter, lngRequestID, blnRenderOwner);
			RenderGroupingDropArea(objContext, objWriter, lngRequestID);
			RenderTopLeftHeaderCell(objContext, objWriter, lngRequestID, blnRenderOwner);
			RenderColumns(objContext, objWriter, lngRequestID, blnRenderOwner);
			RenderRows(objContext, objWriter, lngRequestID, blnRenderOwner);
		}

		/// 
		/// Renders the extended column Header.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		private void RenderExtendedColumnHeader(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			if (IsExtendedColumnHeaderVisible())
			{
				RenderRowData(objContext, objWriter, lngRequestID);
				RenderExtendedColumnHeaderCellUserControls(objContext, objWriter, lngRequestID);
			}
		}

		/// 
		/// Renders the grouping drop area.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		private void RenderGroupingDropArea(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			if (ShowGroupingDropArea && mobjGroupingTreeView != null && mobjGroupingTreeView.Nodes.Count > 0)
			{
				((IRenderableComponent)mobjGroupingTreeView).RenderComponent(objContext, objWriter, lngRequestID);
			}
		}

		/// 
		/// Renders the top left header cell.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnRenderOwner">if set to true</c> [BLN render owner].</param>
		private void RenderTopLeftHeaderCell(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			((IRenderableComponentMember)TopLeftHeaderCell)?.RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
		}

		/// 
		/// Pres the render columns.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		/// <param name="blnForcePreRender">if set to true</c> [BLN force pre render].</param>
		private void PreRenderColumns(IContext objContext, long lngRequestID, bool blnForcePreRender)
		{
			for (DataGridViewColumn dataGridViewColumn = Columns.GetFirstColumn(DataGridViewElementStates.Visible); dataGridViewColumn != null; dataGridViewColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
			{
				dataGridViewColumn.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
			}
		}

		/// 
		/// Posts the render columns.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnForcePostRender">if set to true</c> [BLN force post render].</param>
		private void PostRenderColumns(IContext objContext, long lngRequestID, bool blnForcePostRender)
		{
			for (DataGridViewColumn dataGridViewColumn = Columns.GetFirstColumn(DataGridViewElementStates.Visible); dataGridViewColumn != null; dataGridViewColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
			{
				dataGridViewColumn.PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
			}
		}

		/// 
		/// Renders the columns.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		protected void RenderColumns(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			for (DataGridViewColumn dataGridViewColumn = Columns.GetFirstColumn(DataGridViewElementStates.Visible); dataGridViewColumn != null; dataGridViewColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
			{
				((IRenderableComponentMember)dataGridViewColumn).RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
			}
		}

		/// 
		/// Pres the render rows.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		/// <param name="blnForcePreRender">if set to true</c> [BLN force pre render].</param>
		private void PreRenderRows(IContext objContext, long lngRequestID, bool blnForcePreRender)
		{
			bool blnContainsFrozeRows = false;
			IList rows = GetRows(out blnContainsFrozeRows);
			if (rows == null)
			{
				return;
			}
			foreach (DataGridViewRow item in rows)
			{
				item.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
			}
		}

		/// 
		/// Posts the render rows.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		/// <param name="blnForcePostRender">if set to true</c> [BLN force post render].</param>
		private void PostRenderRows(IContext objContext, long lngRequestID, bool blnForcePostRender)
		{
			bool blnContainsFrozeRows = false;
			IList rows = GetRows(out blnContainsFrozeRows);
			if (rows == null)
			{
				return;
			}
			foreach (DataGridViewRow item in rows)
			{
				item.PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
			}
		}

		/// 
		/// Checks whether filter row should be processed.
		/// </summary>
		/// </returns>
		private bool ShouldProcessFilterRow()
		{
			return ShowFilterRow && mobjDataGridViewFilterRow != null && Columns.GetColumnCount(DataGridViewElementStates.Visible) > 0;
		}

		/// 
		/// Gets the rows.
		/// </summary>
		/// <param name="blnContainsFrozeRows">if set to true</c> [BLN contains froze rows].</param>
		/// </returns>
		private IList GetRows(out bool blnContainsFrozeRows)
		{
			IList list = GetPagedRows(out blnContainsFrozeRows);
			if (ShouldProcessFilterRow())
			{
				int num = list.Count + 1;
				DataGridViewRow[] array = new DataGridViewRow[num];
				array[0] = mobjDataGridViewFilterRow;
				for (int i = 1; i < num; i++)
				{
					array[i] = list[i - 1] as DataGridViewRow;
				}
				list = new List(array);
				blnContainsFrozeRows = true;
			}
			DataGridViewRowCollection rows = Rows;
			if (NewRowIndex >= 0 && NewRowIndex < rows.Count)
			{
				DataGridViewRow dataGridViewRow = rows[NewRowIndex];
				if (dataGridViewRow != null && !list.Contains(dataGridViewRow))
				{
					list.Add(dataGridViewRow);
				}
			}
			return list;
		}

		/// 
		/// Renders the datagridview rows.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="lngRequestID">The LNG request ID.</param>
		protected void RenderRows(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
		{
			if (IsVirtualDataGridView)
			{
				if (lngRequestID == 0 && mobjDataGridViewBlocksManager != null)
				{
					mobjDataGridViewBlocksManager.ClearBlockInfoCache();
				}
				int num = 0;
				int scrollTop = base.ScrollTop;
				int height = base.Height;
				{
					foreach (DataGridRowBlock rowBlock in GetRowBlocks())
					{
						rowBlock.RenderBlock(objContext, objWriter, lngRequestID, blnRenderOwner, IsDirty(lngRequestID), num, scrollTop, height);
						num += rowBlock.BlockHeight;
					}
					return;
				}
			}
			bool blnContainsFrozeRows = false;
			IList rows = GetRows(out blnContainsFrozeRows);
			if (rows == null)
			{
				return;
			}
			foreach (DataGridViewRow item in rows)
			{
				if (item.Visible)
				{
					((IRenderableComponentMember)item).RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
				}
			}
		}

		/// 
		/// Gets the row blocks.
		/// </summary>
		/// </returns>
		private IEnumerable GetRowBlocks()
		{
			List<object> list = new List<object>();
			bool blnContainsFrozeRows = false;
			IList rows = GetRows(out blnContainsFrozeRows);
			if (rows != null)
			{
				if (UseInternalPaging)
				{
					list.Add(new DataGridRowBlock(this, rows, 1, blnContainsFrozeRows));
				}
				else
				{
					List<object> list2 = new List<object>();
					blnContainsFrozeRows = false;
					for (int i = 0; i < rows.Count; i++)
					{
						if (list2.Count == VirtualBlockSize)
						{
							list.Add(new DataGridRowBlock(this, list2, list.Count + 1, blnContainsFrozeRows));
							list2 = new List<object>();
							blnContainsFrozeRows = false;
						}
						if (rows[i] is DataGridViewRow dataGridViewRow && dataGridViewRow.GetVisible(dataGridViewRow.Index))
						{
							if (dataGridViewRow.Frozen)
							{
								blnContainsFrozeRows = true;
							}
							list2.Add(dataGridViewRow);
						}
					}
					if (list2.Count > 0)
					{
						list.Add(new DataGridRowBlock(this, list2, list.Count + 1, blnContainsFrozeRows));
					}
				}
			}
			return list.ToArray();
		}

		/// 
		/// Gets a new instance of a data grid view column by recieved type.
		/// </summary>
		/// <param name="objPropertyDescriptor">The obj property descriptor.</param>
		/// </returns>
		public virtual DataGridViewColumn GetColumnByPropertyDescriptor(PropertyDescriptor objPropertyDescriptor)
		{
			if (objPropertyDescriptor != null)
			{
				Type propertyType = objPropertyDescriptor.PropertyType;
				if (propertyType != null)
				{
					TypeConverter converter = TypeDescriptor.GetConverter(typeof(System.Drawing.Image));
					if (propertyType.Equals(typeof(bool)) || propertyType.Equals(typeof(CheckState)))
					{
						return new DataGridViewCheckBoxColumn(propertyType.Equals(typeof(CheckState)));
					}
					if (typeof(System.Drawing.Image).IsAssignableFrom(propertyType) || converter.CanConvertFrom(propertyType) || typeof(ResourceHandle).IsAssignableFrom(propertyType))
					{
						return new DataGridViewImageColumn();
					}
				}
			}
			return new DataGridViewTextBoxColumn();
		}

		/// 
		/// Gets the type of the child grid.
		/// </summary>
		/// <param name="objDataGridViewRow">The obj data grid view row.</param>
		/// </returns>
		public virtual Type GetChildGridType(DataGridViewRow objDataGridViewRow)
		{
			return typeof(HierarchicDataGridView);
		}

		/// 
		/// Gets the data grid view default column.
		/// </summary>
		/// </returns>
		internal DataGridViewColumn GetDataGridViewDefaultColumn()
		{
			return GetColumnByPropertyDescriptor(null);
		}

		/// 
		/// Gets the block manager.
		/// </summary>
		/// The block manager.</value>
		private DataGridRowBlockInfo GetBlockInfo(DataGridRowBlock objBlock)
		{
			return BlocksManager.GetBlockInfo(objBlock);
		}

		/// 
		/// Gets the last modified.
		/// </summary>
		/// </returns>
		internal long GetLastModified()
		{
			return base.LastModified;
		}

		/// 
		/// Gets the block info.
		/// </summary>
		/// <param name="intBlockId">The block id.</param>
		/// </returns>
		private DataGridRowBlockInfo GetBlockInfo(int intBlockId)
		{
			return BlocksManager.GetBlockInfo(intBlockId);
		}

		/// 
		/// Determines whether [is extended column header visible].
		/// </summary>
		/// 
		///   true</c> if [is extended column header visible]; otherwise, false</c>.
		/// </returns>
		private bool IsExtendedColumnHeaderVisible()
		{
			return mobjExtendedColumnHeaders != null && mobjExtendedColumnHeaders.ShowExtendedColumnHeader && mobjExtendedColumnHeaders.Rows.Count > 0;
		}

		/// 
		/// Determines whether [is new row visible].
		/// </summary>
		/// 
		///   true</c> if [is new row visible]; otherwise, false</c>.
		/// </returns>
		private bool IsNewRowVisible()
		{
			bool flag = AllowUserToAddRows;
			if (flag)
			{
				DataGridViewDataConnection dataConnection = DataConnection;
				if (dataConnection != null)
				{
					flag = dataConnection.AllowAdd;
				}
			}
			return flag;
		}

		/// 
		/// Shows the column chooser dialog.
		/// </summary>
		public void ShowColumnPickerDialog()
		{
			ColumnChooserDialog columnChooserDialog = new ColumnChooserDialog(this);
			columnChooserDialog.Closed += DataGridView_ClosedForColumnVisibility;
			columnChooserDialog.ShowDialog();
		}

		/// 
		/// Handles the ClosedForColumnVisibility event of the DataGridView control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void DataGridView_ClosedForColumnVisibility(object sender, EventArgs e)
		{
			if (sender is ColumnChooserDialog { DialogResult: DialogResult.OK } columnChooserDialog)
			{
				UpdateColumnsVisibility(columnChooserDialog);
			}
		}

		/// 
		/// Updates the columns visibility according to the column chooser.
		/// </summary>
		/// <param name="objDialog">The obj dialog.</param>
		internal virtual void UpdateColumnsVisibility(ColumnChooserDialog objDialog)
		{
			foreach (KeyValuePair<DataGridViewColumn, ColumnCheckedStatus> chosenRootColumn in objDialog.ChosenRootColumns)
			{
				DataGridViewColumn key = chosenRootColumn.Key;
				if (key != null)
				{
					List<object> list = new List<object>();
					if (chosenRootColumn.Value.IsChanged)
					{
						key.Visible = chosenRootColumn.Value.IsChecked;
						list.Add(key);
					}
					OnColumnChooserColumnsVisibilityChanged(list);
				}
			}
			UpdateChildGridColumnsVisibility(objDialog);
		}

		/// 
		/// Updates the child grid columns visibility.
		/// </summary>
		/// <param name="objDialog">The obj dialog.</param>
		internal void UpdateChildGridColumnsVisibility(ColumnChooserDialog objDialog)
		{
			if (!IsHierarchic(HierarchicInfoSelector.Public))
			{
				return;
			}
			foreach (HierarchicInfo key in objDialog.ChosenColumnsIndexByTheirHierarchy.Keys)
			{
				UpdateSingleHierarchyColumnsVisibility(key, objDialog.ChosenColumnsIndexByTheirHierarchy[key]);
			}
		}

		/// 
		/// Updates the single hierarchy columns visibility.
		/// </summary>
		/// <param name="objInfo">The obj info.</param>
		/// <param name="objColumnsState">The list.</param>
		internal void UpdateSingleHierarchyColumnsVisibility(HierarchicInfo objInfo, List<KeyValuePair<DataGridViewColumn, ColumnCheckedStatus>> objColumnsState)
		{
			List<object> list = new List<object>();
			List<object> list2 = new List<object>();
			foreach (KeyValuePair<DataGridViewColumn, ColumnCheckedStatus> item in objColumnsState)
			{
				if (item.Value.IsChanged)
				{
					if (item.Value.IsChecked)
					{
						list.Add(item.Key.Name);
					}
					else
					{
						list2.Add(item.Key.Name);
					}
				}
			}
			UpdateHierarchyInfosColumnsVisibility(objInfo, list, list2);
		}

		/// 
		/// Updates the hierarchy infos columns visibility.
		/// </summary>
		/// <param name="objInfo">The obj info.</param>
		/// <param name="objVisibleItems">The obj visible items.</param>
		/// <param name="objNotVisibleItems">The obj not visible items.</param>
		private static void UpdateHierarchyInfosColumnsVisibility(HierarchicInfo objInfo, List<object> objVisibleItems, List<object> objNotVisibleItems)
		{
			objInfo.HiddenColumns.SuspendCollectionChangeNotification();
			objInfo.HiddenColumns.AddRange(objNotVisibleItems);
			objInfo.HiddenColumns.RemoveRange(objVisibleItems);
			objInfo.HiddenColumns.ResumeCollectionChangeNotification(blnInvokeCollectionChangedEvent: true);
		}

		/// 
		/// Updates the single hierarchy columns visibility.
		/// </summary>
		/// <param name="objInfo">The obj info.</param>
		/// <param name="objColumnsState">The list.</param>
		internal void UpdateSingleHierarchyColumnsVisibility(HierarchicInfo objInfo, List<KeyValuePair<string, ColumnCheckedStatus>> objColumnsState)
		{
			List<object> list = new List<object>();
			List<object> list2 = new List<object>();
			foreach (KeyValuePair<string, ColumnCheckedStatus> item in objColumnsState)
			{
				if (item.Value.IsChanged)
				{
					if (item.Value.IsChecked)
					{
						list.Add(item.Key);
					}
					else
					{
						list2.Add(item.Key);
					}
				}
			}
			UpdateHierarchyInfosColumnsVisibility(objInfo, list, list2);
		}

		/// 
		/// Determines whether this instance has rows.
		/// </summary>
		/// 
		///   true</c> if this instance has rows; otherwise, false</c>.
		/// </returns>
		internal bool HasRows()
		{
			if (AllowUserToAddRows)
			{
				return Rows.Count > 1;
			}
			return Rows.Count > 0;
		}

		private void OnGlobalAutoSize()
		{
			Invalidate();
			if (AutoSizeCount <= 0)
			{
				DataGridViewRowHeadersWidthSizeMode rowHeadersWidthSizeMode = RowHeadersWidthSizeMode;
				DataGridViewAutoSizeRowsMode autoSizeRowsMode = AutoSizeRowsMode;
				bool flag = rowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.EnableResizing && rowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.DisableResizing;
				if (flag)
				{
					AutoResizeRowHeadersWidth(rowHeadersWidthSizeMode, ColumnHeadersHeightSizeMode != DataGridViewColumnHeadersHeightSizeMode.AutoSize, autoSizeRowsMode == DataGridViewAutoSizeRowsMode.None);
				}
				if (ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
				{
					AutoResizeColumnHeadersHeight(blnFixedRowHeadersWidth: true, blnFixedColumnsWidth: false);
				}
				if (autoSizeRowsMode != DataGridViewAutoSizeRowsMode.None)
				{
					AdjustShrinkingRows(autoSizeRowsMode, blnFixedWidth: false, blnInternalAutosizing: true);
				}
				AutoResizeAllVisibleColumnsInternal(DataGridViewAutoSizeColumnCriteriaInternal.AllRows | DataGridViewAutoSizeColumnCriteriaInternal.DisplayedRows | DataGridViewAutoSizeColumnCriteriaInternal.Header, blnFixedHeight: true);
				if (flag && (ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize || autoSizeRowsMode != DataGridViewAutoSizeRowsMode.None))
				{
					AutoResizeRowHeadersWidth(rowHeadersWidthSizeMode, blnFixedColumnHeadersHeight: true, blnFixedRowsHeight: true);
				}
				if (ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
				{
					AutoResizeColumnHeadersHeight(blnFixedRowHeadersWidth: true, blnFixedColumnsWidth: true);
				}
				if (autoSizeRowsMode != DataGridViewAutoSizeRowsMode.None)
				{
					AdjustShrinkingRows(autoSizeRowsMode, blnFixedWidth: true, blnInternalAutosizing: true);
				}
			}
		}

		private void SortDataBoundDataGridView_PerformCheck(DataGridViewColumn objDataGridViewColumn)
		{
			if (!(DataConnection.List<object> is IBindingList bindingList))
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotSortDataBoundDataGridViewBoundToNonIBindingList"));
			}
			if (!bindingList.SupportsSorting)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_IBindingListNeedsToSupportSorting"));
			}
			if (!objDataGridViewColumn.IsDataBound)
			{
				throw new ArgumentException(SR.GetString("DataGridView_ColumnNeedsToBeDataBoundWhenSortingDataBoundDataGridView"), "dataGridViewColumn");
			}
		}

		/// 
		/// Updates the state of the rows displayed.
		/// </summary>
		/// <param name="blnDisplayed">if set to true</c> [displayed].</param>
		private void UpdateRowsDisplayedState(bool blnDisplayed)
		{
			DisplayedBandsData displayedBandsInfo = DisplayedBandsInfo;
			int num = displayedBandsInfo.NumDisplayedFrozenRows;
			DataGridViewRowCollection rows = Rows;
			int num2;
			if (num > 0)
			{
				num2 = rows.GetFirstRow(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
				while (num > 0)
				{
					if ((rows.GetRowState(num2) & DataGridViewElementStates.Displayed) == 0 == blnDisplayed)
					{
						rows.SetRowState(num2, DataGridViewElementStates.Displayed, blnDisplayed);
					}
					num2 = rows.GetNextRow(num2, DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
					num--;
				}
			}
			num2 = displayedBandsInfo.FirstDisplayedScrollingRow;
			if (num2 <= -1)
			{
				return;
			}
			for (int num3 = displayedBandsInfo.NumDisplayedScrollingRows; num3 > 0; num3--)
			{
				if ((rows.GetRowState(num2) & DataGridViewElementStates.Displayed) == 0 == blnDisplayed)
				{
					rows.SetRowState(num2, DataGridViewElementStates.Displayed, blnDisplayed);
				}
				num2 = rows.GetNextRow(num2, DataGridViewElementStates.Visible);
			}
		}

		internal void OnRowErrorTextChanged(DataGridViewRow objDataGridViewRow)
		{
			DataGridViewRowEventArgs e = new DataGridViewRowEventArgs(objDataGridViewRow);
			OnRowErrorTextChanged(e);
		}

		internal void OnCellStyleContentChanged(DataGridViewCellStyle objDataGridViewCellStyle, DataGridViewCellStyle.DataGridViewCellStylePropertyInternal property)
		{
			switch (property)
			{
			case DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.Font:
				if ((objDataGridViewCellStyle.Scope & DataGridViewCellStyleScopes.DataGridView) != DataGridViewCellStyleScopes.None && mobjDataGridViewState1[33554432])
				{
					mobjDataGridViewState1[33554432] = false;
				}
				if ((objDataGridViewCellStyle.Scope & DataGridViewCellStyleScopes.ColumnHeaders) != DataGridViewCellStyleScopes.None && mobjDataGridViewState1[67108864])
				{
					mobjDataGridViewState1[67108864] = false;
				}
				if ((objDataGridViewCellStyle.Scope & DataGridViewCellStyleScopes.RowHeaders) != DataGridViewCellStyleScopes.None && mobjDataGridViewState1[134217728])
				{
					mobjDataGridViewState1[134217728] = false;
				}
				break;
			case DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.ForeColor:
				if ((objDataGridViewCellStyle.Scope & DataGridViewCellStyleScopes.DataGridView) != DataGridViewCellStyleScopes.None && mobjDataGridViewState1[1024])
				{
					mobjDataGridViewState1[1024] = false;
				}
				break;
			}
			DataGridViewCellStyleContentChangedEventArgs e = new DataGridViewCellStyleContentChangedEventArgs(objDataGridViewCellStyle, property != DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.Color && property != DataGridViewCellStyle.DataGridViewCellStylePropertyInternal.ForeColor);
			OnCellStyleContentChanged(e);
		}

		/// Notifies the accessible client applications when a new cell becomes the current cell. </summary>
		/// <param name="objCellAddress">A <see cref="T:System.Drawing.Point"></see> indicating the row and column indexes of the new current cell.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Drawing.Point.X"></see> property of cellAddress is less than 0 or greater than the number of columns in the control minus 1. -or-The value of the <see cref="P:System.Drawing.Point.Y"></see> property of cellAddress is less than 0 or greater than the number of rows in the control minus 1.</exception>
		protected virtual void AccessibilityNotifyCurrentCellChanged(Point objCellAddress)
		{
		}

		/// Adjusts the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> for a column header cell of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that is currently being painted.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the border style for the current column header.</returns>
		/// <param name="objDataGridViewAdvancedBorderStylePlaceholder">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that is used to store intermediate changes to the column header border style.</param>
		/// <param name="blnIsFirstDisplayedColumn">true to indicate that the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that is currently being painted is in the first column displayed on the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>; otherwise, false.</param>
		/// <param name="objDataGridViewAdvancedBorderStyleInput">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that that represents the column header border style to modify.</param>
		/// <param name="blnIsLastVisibleColumn">true to indicate that the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that is currently being painted is in the last column in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that has the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.Visible"></see> property set to true; otherwise, false.</param>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public virtual DataGridViewAdvancedBorderStyle AdjustColumnHeaderBorderStyle(DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStyleInput, DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStylePlaceholder, bool blnIsFirstDisplayedColumn, bool blnIsLastVisibleColumn)
		{
			return null;
		}

		/// Returns a value indicating whether all the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cells are currently selected.</summary>
		/// true if all cells (or all visible cells) are selected or if there are no cells (or no visible cells); otherwise, false.</returns>
		/// <param name="blnIncludeInvisibleCells">true to include the rows and columns with <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.Visible"></see> property values of false; otherwise, false. </param>
		/// 1</filterpriority>
		public bool AreAllCellsSelected(bool blnIncludeInvisibleCells)
		{
			DataGridViewRowCollection rows = Rows;
			if (Columns.Count == 0 && rows.Count == 0)
			{
				return true;
			}
			if (!blnIncludeInvisibleCells && (rows.GetFirstRow(DataGridViewElementStates.Visible) == -1 || Columns.GetFirstColumn(DataGridViewElementStates.Visible) == null))
			{
				return true;
			}
			DataGridViewRow dataGridViewRow = null;
			switch (SelectionMode)
			{
			case DataGridViewSelectionMode.CellSelect:
			{
				bool flag = IndividualSelectedCells.Count == Columns.Count * rows.Count;
				if (flag || blnIncludeInvisibleCells)
				{
					return flag;
				}
				for (int num3 = rows.GetFirstRow(DataGridViewElementStates.Visible); num3 != -1; num3 = rows.GetNextRow(num3, DataGridViewElementStates.Visible))
				{
					dataGridViewRow = rows[num3];
					for (DataGridViewColumn dataGridViewColumn3 = Columns.GetFirstColumn(DataGridViewElementStates.Visible); dataGridViewColumn3 != null; dataGridViewColumn3 = Columns.GetNextColumn(dataGridViewColumn3, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
					{
						if (!dataGridViewRow.Cells[dataGridViewColumn3.Index].Selected)
						{
							return false;
						}
					}
				}
				return true;
			}
			case DataGridViewSelectionMode.FullRowSelect:
			case DataGridViewSelectionMode.RowHeaderSelect:
			{
				bool flag = SelectedBandIndexes.Count * Columns.Count + IndividualSelectedCells.Count == Columns.Count * rows.Count;
				if (flag || blnIncludeInvisibleCells)
				{
					return flag;
				}
				for (int num2 = rows.GetFirstRow(DataGridViewElementStates.Visible); num2 != -1; num2 = rows.GetNextRow(num2, DataGridViewElementStates.Visible))
				{
					if ((rows.GetRowState(num2) & DataGridViewElementStates.Selected) == 0)
					{
						dataGridViewRow = rows[num2];
						for (DataGridViewColumn dataGridViewColumn2 = Columns.GetFirstColumn(DataGridViewElementStates.Visible); dataGridViewColumn2 != null; dataGridViewColumn2 = Columns.GetNextColumn(dataGridViewColumn2, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
						{
							if (!dataGridViewRow.Cells[dataGridViewColumn2.Index].Selected)
							{
								return false;
							}
						}
					}
				}
				return true;
			}
			case DataGridViewSelectionMode.FullColumnSelect:
			case DataGridViewSelectionMode.ColumnHeaderSelect:
			{
				DataGridViewIntLinkedList selectedBandIndexes = SelectedBandIndexes;
				bool flag = selectedBandIndexes.Count * rows.Count + IndividualSelectedCells.Count == Columns.Count * rows.Count;
				if (flag || blnIncludeInvisibleCells)
				{
					return flag;
				}
				for (DataGridViewColumn dataGridViewColumn = Columns.GetFirstColumn(DataGridViewElementStates.Visible); dataGridViewColumn != null; dataGridViewColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
				{
					if (!selectedBandIndexes.Contains(dataGridViewColumn.Index))
					{
						for (int num = rows.GetFirstRow(DataGridViewElementStates.Visible); num != -1; num = rows.GetNextRow(num, DataGridViewElementStates.Visible))
						{
							dataGridViewRow = rows[num];
							if (!dataGridViewRow.Cells[dataGridViewColumn.Index].Selected)
							{
								return false;
							}
						}
					}
				}
				return true;
			}
			default:
				return false;
			}
		}

		/// Adjusts the width of the specified column to fit the contents of all its cells, including the header cell. </summary>
		/// <param name="intColumnIndex">The index of the column to resize.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is not in the valid range of 0 to the number of columns minus 1. </exception>
		public void AutoResizeColumn(int intColumnIndex)
		{
			AutoResizeColumn(intColumnIndex, DataGridViewAutoSizeColumnMode.AllCells);
		}

		/// Adjusts the width of the specified column using the specified size mode.</summary>
		/// <param name="intColumnIndex">The index of the column to resize. </param>
		/// <param name="enmAutoSizeColumnMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> values. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is not in the valid range of 0 to the number of columns minus 1. </exception>
		/// <exception cref="T:System.InvalidOperationException">autoSizeColumnMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> is false. </exception>
		/// <exception cref="T:System.ArgumentException">autoSizeColumnMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet"></see>, <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.None"></see>, or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see>. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeColumnMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value.</exception>
		public void AutoResizeColumn(int intColumnIndex, DataGridViewAutoSizeColumnMode enmAutoSizeColumnMode)
		{
			AutoResizeColumn(intColumnIndex, enmAutoSizeColumnMode, blnFixedHeight: true);
		}

		/// Adjusts the width of the specified column using the specified size mode, optionally calculating the width with the expectation that row heights will subsequently be adjusted. </summary>
		/// <param name="intColumnIndex">The index of the column to resize. </param>
		/// <param name="enmAutoSizeColumnMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> values. </param>
		/// <param name="blnFixedHeight">true to calculate the new width based on the current row heights; false to calculate the width with the expectation that the row heights will also be adjusted.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is not in the valid range of 0 to the number of columns minus 1. </exception>
		/// <exception cref="T:System.InvalidOperationException">autoSizeColumnMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> is false. </exception>
		/// <exception cref="T:System.ArgumentException">autoSizeColumnMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet"></see>, <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.None"></see>, or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see>. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeColumnMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value.</exception>
		protected void AutoResizeColumn(int intColumnIndex, DataGridViewAutoSizeColumnMode enmAutoSizeColumnMode, bool blnFixedHeight)
		{
			if (enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.NotSet || enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.None || enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.Fill)
			{
				throw new ArgumentException(SR.GetString("DataGridView_NeedColumnAutoSizingCriteria", "autoSizeColumnMode"));
			}
			switch (enmAutoSizeColumnMode)
			{
			case DataGridViewAutoSizeColumnMode.NotSet:
			case DataGridViewAutoSizeColumnMode.None:
			case DataGridViewAutoSizeColumnMode.ColumnHeader:
			case DataGridViewAutoSizeColumnMode.AllCellsExceptHeader:
			case DataGridViewAutoSizeColumnMode.AllCells:
			case DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader:
			case DataGridViewAutoSizeColumnMode.DisplayedCells:
			case DataGridViewAutoSizeColumnMode.Fill:
				if (intColumnIndex < 0 || intColumnIndex >= Columns.Count)
				{
					throw new ArgumentOutOfRangeException("columnIndex");
				}
				if (enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.ColumnHeader && !ColumnHeadersVisible)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CannotAutoSizeInvisibleColumnHeader"));
				}
				AutoResizeColumnInternal(intColumnIndex, (DataGridViewAutoSizeColumnCriteriaInternal)enmAutoSizeColumnMode, blnFixedHeight);
				break;
			default:
				throw new InvalidEnumArgumentException("autoSizeColumnMode", (int)enmAutoSizeColumnMode, typeof(DataGridViewAutoSizeColumnMode));
			}
		}

		/// Adjusts the height of the column headers to fit the contents of the largest column header.</summary>
		public void AutoResizeColumnHeadersHeight()
		{
			AutoResizeColumnHeadersHeight(blnFixedRowHeadersWidth: true, blnFixedColumnsWidth: true);
		}

		/// Adjusts the height of the column headers based on changes to the contents of the header in the specified column.</summary>
		/// <param name="intColumnIndex">The index of the column containing the header with the changed content.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is not in the valid range of 0 to the number of columns minus 1.</exception>
		public void AutoResizeColumnHeadersHeight(int intColumnIndex)
		{
			AutoResizeColumnHeadersHeight(intColumnIndex, blnFixedRowHeadersWidth: true, blnFixedColumnWidth: true);
		}

		/// Adjusts the height of the column headers to fit their contents, optionally calculating the height with the expectation that the column and/or row header widths will subsequently be adjusted.</summary>
		/// <param name="blnFixedRowHeadersWidth">true to calculate the new height based on the current width of the row headers; false to calculate the height with the expectation that the row headers width will also be adjusted. </param>
		/// <param name="blnFixedColumnsWidth">true to calculate the new height based on the current column widths; false to calculate the height with the expectation that the column widths will also be adjusted.</param>
		protected void AutoResizeColumnHeadersHeight(bool blnFixedRowHeadersWidth, bool blnFixedColumnsWidth)
		{
			if (!ColumnHeadersVisible)
			{
				return;
			}
			int num = 0;
			if (LayoutInfo.TopLeftHeader.Width > 0)
			{
				num = ((!blnFixedRowHeadersWidth) ? TopLeftHeaderCell.GetPreferredSize(-1).Height : TopLeftHeaderCell.GetPreferredHeight(-1, LayoutInfo.TopLeftHeader.Width));
			}
			int count = Columns.Count;
			for (int i = 0; i < count; i++)
			{
				if (Columns[i].Visible)
				{
					num = ((!blnFixedColumnsWidth) ? Math.Max(num, Columns[i].HeaderCell.GetPreferredSize(-1).Height) : Math.Max(num, Columns[i].HeaderCell.GetPreferredHeight(-1, Columns[i].Thickness)));
				}
			}
			if (num < 4)
			{
				num = 4;
			}
			if (num > 32768)
			{
				num = 32768;
			}
			if (num != ColumnHeadersHeight)
			{
				SetColumnHeadersHeightInternal(num, !blnFixedColumnsWidth);
			}
		}

		/// Adjusts the height of the column headers based on changes to the contents of the header in the specified column, optionally calculating the height with the expectation that the column and/or row header widths will subsequently be adjusted.</summary>
		/// <param name="blnFixedRowHeadersWidth">true to calculate the new height based on the current width of the row headers; false to calculate the height with the expectation that the row headers width will also be adjusted.</param>
		/// <param name="intColumnIndex">The index of the column header whose contents should be used to determine new height.</param>
		/// <param name="blnFixedColumnWidth">true to calculate the new height based on the current width of the specified column; false to calculate the height with the expectation that the column width will also be adjusted.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is not in the valid range of 0 to the number of columns minus 1. </exception>
		protected void AutoResizeColumnHeadersHeight(int intColumnIndex, bool blnFixedRowHeadersWidth, bool blnFixedColumnWidth)
		{
			if (base.DesignMode)
			{
				return;
			}
			if (intColumnIndex < -1 || intColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("columnIndex");
			}
			if (!ColumnHeadersVisible)
			{
				return;
			}
			int num = 0;
			if (LayoutInfo.TopLeftHeader.Width > 0)
			{
				num = ((!(intColumnIndex != -1 || blnFixedRowHeadersWidth)) ? TopLeftHeaderCell.GetPreferredSize(-1).Height : TopLeftHeaderCell.GetPreferredHeight(-1, LayoutInfo.TopLeftHeader.Width));
			}
			int count = Columns.Count;
			for (int i = 0; i < count; i++)
			{
				if (Columns[i].Visible)
				{
					num = ((!(intColumnIndex != i || blnFixedColumnWidth)) ? Math.Max(num, Columns[i].HeaderCell.GetPreferredSize(-1).Height) : Math.Max(num, Columns[i].HeaderCell.GetPreferredHeight(-1, Columns[i].Thickness)));
				}
			}
			if (num < 4)
			{
				num = 4;
			}
			if (num > 32768)
			{
				num = 32768;
			}
			if (num != ColumnHeadersHeight)
			{
				SetColumnHeadersHeightInternal(num, !blnFixedColumnWidth);
			}
		}

		/// Adjusts the width of all columns to fit the contents of all their cells, including the header cells.</summary>
		public void AutoResizeColumns()
		{
			AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
		}

		/// Adjusts the width of all columns using the specified size mode.</summary>
		/// <param name="enmAutoSizeColumnsMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode"></see> values. </param>
		/// <exception cref="T:System.ArgumentException">autoSizeColumnsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.None"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill"></see>. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeColumnsMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode"></see> value.</exception>
		/// <exception cref="T:System.InvalidOperationException">autoSizeColumnsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> is false. </exception>
		public void AutoResizeColumns(DataGridViewAutoSizeColumnsMode enmAutoSizeColumnsMode)
		{
			AutoResizeColumns(enmAutoSizeColumnsMode, blnFixedHeight: true);
		}

		/// Adjusts the width of all columns using the specified size mode, optionally calculating the widths with the expectation that row heights will subsequently be adjusted. </summary>
		/// <param name="enmAutoSizeColumnsMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode"></see> values. </param>
		/// <param name="blnFixedHeight">true to calculate the new widths based on the current row heights; false to calculate the widths with the expectation that the row heights will also be adjusted.</param>
		/// <exception cref="T:System.ArgumentException">autoSizeColumnsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.None"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.Fill"></see>. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeColumnsMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode"></see> value.</exception>
		/// <exception cref="T:System.InvalidOperationException">autoSizeColumnsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersVisible"></see> is false. </exception>
		protected void AutoResizeColumns(DataGridViewAutoSizeColumnsMode enmAutoSizeColumnsMode, bool blnFixedHeight)
		{
			for (int i = 0; i < Columns.Count; i++)
			{
				AutoResizeColumn(i, (DataGridViewAutoSizeColumnMode)enmAutoSizeColumnsMode, blnFixedHeight);
			}
			Update();
		}

		/// Adjusts the height of the specified row to fit the contents of all its cells including the header cell.</summary>
		/// <param name="intRowIndex">The index of the row to resize.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not in the valid range of 0 to the number of rows minus 1. </exception>
		public void AutoResizeRow(int intRowIndex)
		{
			AutoResizeRow(intRowIndex, DataGridViewAutoSizeRowMode.AllCells);
		}

		/// Adjusts the height of the specified row using the specified size mode.</summary>
		/// <param name="enmAutoSizeRowMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> values. </param>
		/// <param name="intRowIndex">The index of the row to resize. </param>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeRowMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> value. </exception>
		/// <exception cref="T:System.InvalidOperationException">autoSizeRowMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode.RowHeader"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersVisible"></see> is false. </exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not in the valid range of 0 to the number of rows minus 1.</exception>
		public void AutoResizeRow(int intRowIndex, DataGridViewAutoSizeRowMode enmAutoSizeRowMode)
		{
			AutoResizeRow(intRowIndex, enmAutoSizeRowMode, blnFixedWidth: true);
		}

		/// Adjusts the height of the specified row using the specified size mode, optionally calculating the height with the expectation that column widths will subsequently be adjusted. </summary>
		/// <param name="enmAutoSizeRowMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> values. </param>
		/// <param name="intRowIndex">The index of the row to resize. </param>
		/// <param name="blnFixedWidth">true to calculate the new height based on the current width of the columns; false to calculate the height with the expectation that the column widths will also be adjusted.</param>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeRowMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> value. </exception>
		/// <exception cref="T:System.InvalidOperationException">autoSizeRowMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode.RowHeader"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersVisible"></see> is false. </exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not in the valid range of 0 to the number of rows minus 1.</exception>
		protected void AutoResizeRow(int intRowIndex, DataGridViewAutoSizeRowMode enmAutoSizeRowMode, bool blnFixedWidth)
		{
			if (intRowIndex < 0 || intRowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if ((enmAutoSizeRowMode & (DataGridViewAutoSizeRowMode)(-4)) != 0)
			{
				throw new InvalidEnumArgumentException("autoSizeRowMode", (int)enmAutoSizeRowMode, typeof(DataGridViewAutoSizeRowMode));
			}
			if (enmAutoSizeRowMode == DataGridViewAutoSizeRowMode.RowHeader && !RowHeadersVisible)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotAutoSizeRowInvisibleRowHeader"));
			}
			AutoResizeRowInternal(intRowIndex, enmAutoSizeRowMode, blnFixedWidth, blnInternalAutosizing: false);
		}

		/// Adjusts the width of the row headers using the specified size mode.</summary>
		/// <param name="enmRowHeadersWidthSizeMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> values.</param>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">rowHeadersWidthSizeMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value. </exception>
		/// <exception cref="T:System.ArgumentException">rowHeadersWidthSizeMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing"></see>.</exception>
		public void AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode enmRowHeadersWidthSizeMode)
		{
		}

		/// Adjusts the width of the row headers based on changes to the contents of the header in the specified row and using the specified size mode.</summary>
		/// <param name="enmRowHeadersWidthSizeMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> values.</param>
		/// <param name="intRowIndex">The index of the row header with the changed content.</param>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">rowHeadersWidthSizeMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value. </exception>
		/// <exception cref="T:System.ArgumentException">rowHeadersWidthSizeMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing"></see></exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not in the valid range of 0 to the number of rows minus 1. </exception>
		public void AutoResizeRowHeadersWidth(int intRowIndex, DataGridViewRowHeadersWidthSizeMode enmRowHeadersWidthSizeMode)
		{
		}

		/// Adjusts the width of the row headers using the specified size mode, optionally calculating the width with the expectation that the row and/or column header widths will subsequently be adjusted.</summary>
		/// <param name="blnFixedColumnHeadersHeight">true to calculate the new width based on the current height of the column headers; false to calculate the width with the expectation that the height of the column headers will also be adjusted.</param>
		/// <param name="enmRowHeadersWidthSizeMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> values.</param>
		/// <param name="blnFixedRowsHeight">true to calculate the new width based on the current row heights; false to calculate the width with the expectation that the row heights will also be adjusted.</param>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">rowHeadersWidthSizeMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value. </exception>
		/// <exception cref="T:System.ArgumentException">rowHeadersWidthSizeMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing"></see>.</exception>
		protected void AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode enmRowHeadersWidthSizeMode, bool blnFixedColumnHeadersHeight, bool blnFixedRowsHeight)
		{
		}

		/// Adjusts the width of the row headers based on changes to the contents of the header in the specified row and using the specified size mode, optionally calculating the width with the expectation that the row and/or column header widths will subsequently be adjusted.</summary>
		/// <param name="blnFixedColumnHeadersHeight">true to calculate the new width based on the current height of the column headers; false to calculate the width with the expectation that the height of the column headers will also be adjusted.</param>
		/// <param name="enmRowHeadersWidthSizeMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> values.</param>
		/// <param name="blnFixedRowHeight">true to calculate the new width based on the current height of the specified row; false to calculate the width with the expectation that the row height will also be adjusted.</param>
		/// <param name="intRowIndex">The index of the row containing the header with the changed content.</param>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">rowHeadersWidthSizeMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value. </exception>
		/// <exception cref="T:System.ArgumentException">rowHeadersWidthSizeMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing"></see>.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not in the valid range of 0 to the number of rows minus 1. </exception>
		protected void AutoResizeRowHeadersWidth(int intRowIndex, DataGridViewRowHeadersWidthSizeMode enmRowHeadersWidthSizeMode, bool blnFixedColumnHeadersHeight, bool blnFixedRowHeight)
		{
		}

		/// Adjusts the heights of all rows to fit the contents of all their cells, including the header cells.</summary>
		public void AutoResizeRows()
		{
			AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
		}

		/// Adjusts the heights of the rows using the specified size mode value.</summary>
		/// <param name="enmAutoSizeRowsMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> values. </param>
		/// <exception cref="T:System.ArgumentException">autoSizeRowsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.None"></see>.</exception>
		/// <exception cref="T:System.InvalidOperationException">autoSizeRowsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.AllHeaders"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders"></see>, and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersVisible"></see> is false. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeRowsMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> value. </exception>
		public void AutoResizeRows(DataGridViewAutoSizeRowsMode enmAutoSizeRowsMode)
		{
			AutoResizeRows(enmAutoSizeRowsMode, blnFixedWidth: true);
		}

		/// 
		/// Adjusts the heights of all rows using the specified size mode, optionally calculating the heights with the expectation that column widths will subsequently be adjusted.
		/// </summary>
		/// <param name="enmAutoSizeRowsMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> values.</param>
		/// <param name="blnFixedWidth">true to calculate the new heights based on the current column widths; false to calculate the heights with the expectation that the column widths will also be adjusted.</param>
		/// <exception cref="T:System.ArgumentException">autoSizeRowsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.None"></see>.</exception>
		/// <exception cref="T:System.InvalidOperationException">autoSizeRowsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.AllHeaders"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders"></see>, and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersVisible"></see> is false. </exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeRowsMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> value. </exception>
		protected void AutoResizeRows(DataGridViewAutoSizeRowsMode enmAutoSizeRowsMode, bool blnFixedWidth)
		{
			switch (enmAutoSizeRowsMode)
			{
			case DataGridViewAutoSizeRowsMode.None:
				throw new ArgumentException(SR.GetString("DataGridView_NeedAutoSizingCriteria", "autoSizeRowsMode"));
			case DataGridViewAutoSizeRowsMode.AllHeaders:
			case DataGridViewAutoSizeRowsMode.DisplayedHeaders:
				if (!RowHeadersVisible)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CannotAutoSizeRowsInvisibleRowHeader"));
				}
				goto case DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
			case DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders:
			case DataGridViewAutoSizeRowsMode.AllCells:
			case DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders:
			case DataGridViewAutoSizeRowsMode.DisplayedCells:
				AdjustShrinkingRows(enmAutoSizeRowsMode, blnFixedWidth, blnInternalAutosizing: false);
				Update();
				break;
			default:
				throw new InvalidEnumArgumentException("value", (int)enmAutoSizeRowsMode, typeof(DataGridViewAutoSizeRowsMode));
			}
		}

		/// 
		/// Adjusts the shrinking rows.
		/// </summary>
		/// <param name="enmAutoSizeRowsMode">The auto size rows mode.</param>
		/// <param name="blnFixedWidth">if set to true</c> [fixed width].</param>
		/// <param name="blnInternalAutosizing">if set to true</c> [internal autosizing].</param>
		protected void AdjustShrinkingRows(DataGridViewAutoSizeRowsMode enmAutoSizeRowsMode, bool blnFixedWidth, bool blnInternalAutosizing)
		{
			if ((enmAutoSizeRowsMode & (DataGridViewAutoSizeRowsMode)2) == 0 && ((enmAutoSizeRowsMode & (DataGridViewAutoSizeRowsMode)1) == 0 || !RowHeadersVisible))
			{
				return;
			}
			BulkPaintCount++;
			try
			{
				DataGridViewRowCollection rows = Rows;
				if ((enmAutoSizeRowsMode & (DataGridViewAutoSizeRowsMode)4) != DataGridViewAutoSizeRowsMode.None)
				{
					BulkLayoutCount++;
					try
					{
						for (int num = rows.GetFirstRow(DataGridViewElementStates.Visible); num != -1; num = rows.GetNextRow(num, DataGridViewElementStates.Visible))
						{
							AutoResizeRowInternal(num, MapAutoSizeRowsModeToRowMode(enmAutoSizeRowsMode), blnFixedWidth, blnInternalAutosizing);
						}
						return;
					}
					finally
					{
						ExitBulkLayout(blnInvalidInAdjustFillingColumns: false);
					}
				}
				int height = LayoutInfo.Data.Height;
				int num2 = 0;
				int num3 = rows.GetFirstRow(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
				while (num3 != -1 && num2 < height)
				{
					AutoResizeRowInternal(num3, MapAutoSizeRowsModeToRowMode(enmAutoSizeRowsMode), blnFixedWidth, blnInternalAutosizing);
					num2 += rows.SharedRow(num3).GetHeight(num3);
					num3 = rows.GetNextRow(num3, DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
				}
				if (num2 >= height)
				{
					return;
				}
				int num4 = num2;
				int firstDisplayedScrollingRowIndex = FirstDisplayedScrollingRowIndex;
				num3 = firstDisplayedScrollingRowIndex;
				while (num3 != -1 && num2 < height && firstDisplayedScrollingRowIndex == FirstDisplayedScrollingRowIndex)
				{
					AutoResizeRowInternal(num3, MapAutoSizeRowsModeToRowMode(enmAutoSizeRowsMode), blnFixedWidth, blnInternalAutosizing);
					num2 += rows.SharedRow(num3).GetHeight(num3);
					num3 = rows.GetNextRow(num3, DataGridViewElementStates.Visible);
				}
				do
				{
					firstDisplayedScrollingRowIndex = FirstDisplayedScrollingRowIndex;
					if (num2 < height)
					{
						int previousRow = rows.GetPreviousRow(FirstDisplayedScrollingRowIndex, DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen);
						if (previousRow != -1)
						{
							AutoResizeRowInternal(previousRow, MapAutoSizeRowsModeToRowMode(enmAutoSizeRowsMode), blnFixedWidth, blnInternalAutosizing);
						}
					}
					num2 = num4;
					num3 = FirstDisplayedScrollingRowIndex;
					while (num3 != -1 && num2 < height)
					{
						AutoResizeRowInternal(num3, MapAutoSizeRowsModeToRowMode(enmAutoSizeRowsMode), blnFixedWidth, blnInternalAutosizing);
						num2 += rows.SharedRow(num3).GetHeight(num3);
						num3 = rows.GetNextRow(num3, DataGridViewElementStates.Visible);
					}
				}
				while (firstDisplayedScrollingRowIndex != FirstDisplayedScrollingRowIndex);
			}
			finally
			{
				ExitBulkPaint(-1, -1);
			}
		}

		/// 
		/// Exits the bulk layout.
		/// </summary>
		/// <param name="blnInvalidInAdjustFillingColumns">if set to true</c> [invalid in adjust filling columns].</param>
		protected void ExitBulkLayout(bool blnInvalidInAdjustFillingColumns)
		{
			if (BulkLayoutCount > 0)
			{
				BulkLayoutCount--;
				if (BulkLayoutCount == 0)
				{
					PerformLayoutPrivate(blnInvalidInAdjustFillingColumns);
				}
			}
		}

		/// Adjusts the heights of the specified rows using the specified size mode, optionally calculating the heights with the expectation that column widths will subsequently be adjusted. </summary>
		/// <param name="intRowIndexStart">The index of the first row to resize. </param>
		/// <param name="enmAutoSizeRowMode">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> values. </param>
		/// <param name="blnFixedWidth">true to calculate the new heights based on the current column widths; false to calculate the heights with the expectation that the column widths will also be adjusted.</param>
		/// <param name="intRowsCount">The number of rows to resize. </param>
		/// <exception cref="T:System.ArgumentException">autoSizeRowsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.None"></see>.</exception>
		/// <exception cref="T:System.InvalidOperationException">autoSizeRowsMode has the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.AllHeaders"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders"></see>, and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersVisible"></see> is false. </exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndexStart is less than 0.-or-rowsCount is less than 0.</exception>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeRowsMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> value. </exception>
		protected void AutoResizeRows(int intRowIndexStart, int intRowsCount, DataGridViewAutoSizeRowMode enmAutoSizeRowMode, bool blnFixedWidth)
		{
		}

		/// Puts the current cell in edit mode.</summary>
		/// true if the current cell is already in edit mode or successfully enters edit mode; otherwise, false.</returns>
		/// <param name="blnSelectAll">true to select all the cell's contents; false to not select any contents.</param>
		/// <exception cref="T:System.Exception">Initialization of the editing cell value failed and either there is no handler for the <see cref="E:System.Windows.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:System.Windows.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
		/// <exception cref="T:System.InvalidCastException">The type indicated by the cell's <see cref="P:System.Windows.Forms.DataGridViewCell.EditType"></see> property does not derive from the <see cref="T:System.Windows.Forms.Control"></see> type.-or-The type indicated by the cell's <see cref="P:System.Windows.Forms.DataGridViewCell.EditType"></see> property does not implement the <see cref="T:System.Windows.Forms.IDataGridViewEditingControl"></see> interface.</exception>
		/// <exception cref="T:System.InvalidOperationException"><see cref="P:System.Windows.Forms.DataGridView.CurrentCell"></see> is not set to a valid cell.-or-This method was called in a handler for the <see cref="E:System.Windows.Forms.DataGridView.CellBeginEdit"></see> event.</exception>
		/// 1</filterpriority>
		public virtual bool BeginEdit(bool blnSelectAll)
		{
			return BeginEdit(blnSelectAll, blnClientSource: false);
		}

		/// 
		/// Begins edit.
		/// </summary>
		/// <param name="blnSelectAll">if set to true</c> [BLN select all].</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		/// </returns>
		internal virtual bool BeginEdit(bool blnSelectAll, bool blnClientSource)
		{
			if (mobjCurrentCellPoint.X == -1)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_NoCurrentCell"));
			}
			bool flag = IsCurrentCellInEditMode || BeginEditInternal(blnSelectAll, blnClientSource);
			if (flag && !blnClientSource)
			{
				DataGridViewCell currentCellInternal = CurrentCellInternal;
				if (currentCellInternal != null)
				{
					BeginCellEdit(currentCellInternal);
				}
			}
			return flag;
		}

		/// 
		/// Begins the cell edit.
		/// </summary>
		/// <param name="objDataGridViewCell">The obj data grid view cell.</param>
		internal void BeginCellEdit(DataGridViewCell objDataGridViewCell)
		{
			if (objDataGridViewCell != null)
			{
				string text = $"{ID.ToString()}_{objDataGridViewCell.MemberIDInternal}";
				InvokeMethodWithId("DataGridView_BeginEdit", text);
			}
		}

		/// Cancels edit mode for the currently selected cell and discards any changes.</summary>
		/// true if the cancel was successful; otherwise, false.</returns>
		/// 1</filterpriority>
		public bool CancelEdit()
		{
			return false;
		}

		/// Clears the current selection by unselecting all selected cells.</summary>
		/// 1</filterpriority>
		public void ClearSelection()
		{
			DimensionChangeCount++;
			SelectionChangeCount++;
			bool flag = false;
			DataGridViewIntLinkedList selectedBandIndexes = SelectedBandIndexes;
			DataGridViewCellLinkedList individualSelectedCells = IndividualSelectedCells;
			if (selectedBandIndexes.Count > 8 || individualSelectedCells.Count > 8)
			{
				BulkPaintCount++;
				flag = true;
			}
			try
			{
				RemoveIndividuallySelectedCells();
				switch (SelectionMode)
				{
				default:
					return;
				case DataGridViewSelectionMode.FullRowSelect:
				case DataGridViewSelectionMode.RowHeaderSelect:
					while (selectedBandIndexes.Count > 0)
					{
						SetSelectedRowCore(selectedBandIndexes.HeadInt, blnSelected: false);
					}
					return;
				case DataGridViewSelectionMode.FullColumnSelect:
				case DataGridViewSelectionMode.ColumnHeaderSelect:
					break;
				}
				while (selectedBandIndexes.Count > 0)
				{
					SetSelectedColumnCore(selectedBandIndexes.HeadInt, blnSelected: false);
				}
			}
			finally
			{
				DimensionChangeCount--;
				NoSelectionChangeCount--;
				if (flag)
				{
					ExitBulkPaint(-1, -1);
				}
			}
		}

		/// Cancels the selection of all currently selected cells except the one indicated, optionally ensuring that the indicated cell is selected. </summary>
		/// <param name="intColumnIndexException">The column index to exclude.</param>
		/// <param name="blnSelectExceptionElement">true to select the excluded cell, row, or column; false to retain its original state.</param>
		/// <param name="intRowIndexException">The row index to exclude.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndexException is greater than the highest column index.-or-columnIndexException is less than -1 when <see cref="P:System.Windows.Forms.DataGridView.SelectionMode"></see> is <see cref="F:System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect"></see>; otherwise, columnIndexException is less than 0.-or- rowIndexException is greater than the highest row index.-or-rowIndexException is less than -1 when <see cref="P:System.Windows.Forms.DataGridView.SelectionMode"></see> is <see cref="F:System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect"></see>; otherwise, rowIndexException is less than 0.</exception>
		protected void ClearSelection(int intColumnIndexException, int intRowIndexException, bool blnSelectExceptionElement)
		{
			ClearSelection(intColumnIndexException, intRowIndexException, blnSelectExceptionElement, blnClientSource: false);
		}

		/// Cancels the selection of all currently selected cells except the one indicated, optionally ensuring that the indicated cell is selected. </summary>
		/// <param name="intColumnIndexException">The column index to exclude.</param>
		/// <param name="blnSelectExceptionElement">true to select the excluded cell, row, or column; false to retain its original state.</param>
		/// <param name="intRowIndexException">The row index to exclude.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndexException is greater than the highest column index.-or-columnIndexException is less than -1 when <see cref="P:System.Windows.Forms.DataGridView.SelectionMode"></see> is <see cref="F:System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect"></see>; otherwise, columnIndexException is less than 0.-or- rowIndexException is greater than the highest row index.-or-rowIndexException is less than -1 when <see cref="P:System.Windows.Forms.DataGridView.SelectionMode"></see> is <see cref="F:System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect"></see>; otherwise, rowIndexException is less than 0.</exception>
		private void ClearSelection(int intColumnIndexException, int intRowIndexException, bool blnSelectExceptionElement, bool blnClientSource)
		{
			DataGridViewIntLinkedList selectedBandIndexes = SelectedBandIndexes;
			switch (SelectionMode)
			{
			case DataGridViewSelectionMode.CellSelect:
			case DataGridViewSelectionMode.FullColumnSelect:
			case DataGridViewSelectionMode.ColumnHeaderSelect:
				if (intColumnIndexException < 0 || intColumnIndexException >= Columns.Count)
				{
					throw new ArgumentOutOfRangeException("columnIndexException");
				}
				break;
			case DataGridViewSelectionMode.FullRowSelect:
			case DataGridViewSelectionMode.RowHeaderSelect:
				if (intColumnIndexException < -1 || intColumnIndexException >= Columns.Count)
				{
					throw new ArgumentOutOfRangeException("columnIndexException");
				}
				break;
			}
			switch (SelectionMode)
			{
			case DataGridViewSelectionMode.CellSelect:
			case DataGridViewSelectionMode.FullRowSelect:
			case DataGridViewSelectionMode.RowHeaderSelect:
				if (intRowIndexException < 0 || intRowIndexException >= Rows.Count)
				{
					throw new ArgumentOutOfRangeException("rowIndexException");
				}
				break;
			case DataGridViewSelectionMode.FullColumnSelect:
			case DataGridViewSelectionMode.ColumnHeaderSelect:
				if (intRowIndexException < -1 || intRowIndexException >= Rows.Count)
				{
					throw new ArgumentOutOfRangeException("rowIndexException");
				}
				break;
			}
			DimensionChangeCount++;
			SelectionChangeCount++;
			bool flag = false;
			if (selectedBandIndexes.Count > 8 || IndividualSelectedCells.Count > 8)
			{
				BulkPaintCount++;
				flag = true;
			}
			try
			{
				switch (SelectionMode)
				{
				case DataGridViewSelectionMode.CellSelect:
					RemoveIndividuallySelectedCells(intColumnIndexException, intRowIndexException);
					break;
				case DataGridViewSelectionMode.FullRowSelect:
				case DataGridViewSelectionMode.RowHeaderSelect:
				{
					int num2 = 0;
					while (num2 < selectedBandIndexes.Count)
					{
						if (selectedBandIndexes[num2] != intRowIndexException)
						{
							SetSelectedRowCore(selectedBandIndexes[num2], blnSelected: false, blnClientSource);
						}
						else
						{
							num2++;
						}
					}
					if (SelectionMode == DataGridViewSelectionMode.RowHeaderSelect)
					{
						RemoveIndividuallySelectedCells(intColumnIndexException, intRowIndexException, blnClientSource);
					}
					break;
				}
				case DataGridViewSelectionMode.FullColumnSelect:
				case DataGridViewSelectionMode.ColumnHeaderSelect:
				{
					int num = 0;
					while (num < selectedBandIndexes.Count)
					{
						if (selectedBandIndexes[num] != intColumnIndexException)
						{
							SetSelectedColumnCore(selectedBandIndexes[num], blnSelected: false);
						}
						else
						{
							num++;
						}
					}
					if (SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
					{
						RemoveIndividuallySelectedCells(intColumnIndexException, intRowIndexException);
					}
					break;
				}
				}
				if (blnSelectExceptionElement)
				{
					SetSelectedElementCore(intColumnIndexException, intRowIndexException, blnSelected: true, blnClientSource);
				}
			}
			finally
			{
				DimensionChangeCount--;
				NoSelectionChangeCount--;
				if (flag)
				{
					ExitBulkPaint(-1, -1);
				}
			}
		}

		/// Commits changes in the current cell to the data cache without ending edit mode.</summary>
		/// true if the changes were committed; otherwise false.</returns>
		/// <param name="enmContext">A bitwise combination of <see cref="T:System.Windows.Forms.DataGridViewDataErrorContexts"></see> values that specifies the context in which an error can occur. </param>
		/// <exception cref="T:System.Exception">The cell value could not be committed and either there is no handler for the <see cref="E:System.Windows.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:System.Windows.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		public bool CommitEdit(DataGridViewDataErrorContexts enmContext)
		{
			if (IsCurrentCellInEditMode)
			{
				DataGridViewCell objDataGridViewCurrentCell = CurrentCellInternal;
				DataGridViewDataErrorEventArgs e = CommitEdit(ref objDataGridViewCurrentCell, enmContext, DataGridViewValidateCellInternal.Never, blnFireCellLeave: false, blnFireCellEnter: false, blnFireRowLeave: false, blnFireRowEnter: false, blnFireLeave: false);
				if (e != null)
				{
					if (e.ThrowException)
					{
						throw e.Exception;
					}
					if (e.Cancel)
					{
						return false;
					}
				}
			}
			return true;
		}

		/// 
		/// Commits the edit for operation.
		/// </summary>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="blnForCurrentCellChange">if set to true</c> [for current cell change].</param>
		/// </returns>
		internal bool CommitEditForOperation(int intColumnIndex, int intRowIndex, bool blnForCurrentCellChange)
		{
			return CommitEditForOperation(intColumnIndex, intRowIndex, blnForCurrentCellChange, blnClientSource: false);
		}

		/// 
		/// Commits the edit for operation.
		/// </summary>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="blnForCurrentCellChange">if set to true</c> [for current cell change].</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		/// </returns>
		internal bool CommitEditForOperation(int intColumnIndex, int intRowIndex, bool blnForCurrentCellChange, bool blnClientSource)
		{
			if (blnForCurrentCellChange)
			{
				if (!EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.CurrentCellChange | DataGridViewDataErrorContexts.Parsing, DataGridViewValidateCellInternal.Always, blnFireCellLeave: true, blnFireCellEnter: true, mobjCurrentCellPoint.Y != intRowIndex, mobjCurrentCellPoint.Y != intRowIndex, blnFireLeave: false, EditMode != DataGridViewEditMode.EditOnEnter, blnResetCurrentCell: false, blnResetAnchorCell: false, blnClientSource))
				{
					return false;
				}
				if (mobjCurrentCellPoint.Y != intRowIndex && mobjCurrentCellPoint.Y != -1)
				{
					DataGridViewCell objDataGridViewCell = null;
					int x = mobjCurrentCellPoint.X;
					int y = mobjCurrentCellPoint.Y;
					if (OnRowValidating(ref objDataGridViewCell, x, y))
					{
						if (!IsInnerCellOutOfBounds(x, y))
						{
							OnRowEnter(ref objDataGridViewCell, x, y, blnCanCreateNewRow: true, blnValidationFailureOccurred: true);
							if (IsInnerCellOutOfBounds(x, y))
							{
								return false;
							}
							OnCellEnter(ref objDataGridViewCell, x, y);
							if (IsInnerCellOutOfBounds(x, y))
							{
								return false;
							}
							if (Focused && !IsCurrentCellInEditMode && (EditMode == DataGridViewEditMode.EditOnEnter || (EditMode != DataGridViewEditMode.EditProgrammatically && CurrentCellInternal.EditType == null)))
							{
								BeginEditInternal(blnSelectAll: true);
							}
						}
						return false;
					}
					if (IsInnerCellOutOfBounds(x, y))
					{
						return false;
					}
					OnRowValidated(ref objDataGridViewCell, x, y);
				}
			}
			else if (!CommitEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Scroll, blnForCurrentCellChange: false, mobjCurrentCellPoint.Y != intRowIndex))
			{
				return false;
			}
			if (IsColumnOutOfBounds(intColumnIndex))
			{
				return false;
			}
			DataGridViewRowCollection rows = Rows;
			if (intRowIndex >= rows.Count)
			{
				int lastRow = rows.GetLastRow(DataGridViewElementStates.Visible);
				if (blnForCurrentCellChange && mobjCurrentCellPoint.X == -1 && lastRow != -1)
				{
					SetAndSelectCurrentCellAddress(intColumnIndex, lastRow, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false, blnClearSelection: false, blnForceCurrentCellSelection: false);
				}
				return false;
			}
			if (intRowIndex > -1 && (rows.GetRowState(intRowIndex) & DataGridViewElementStates.Visible) == 0)
			{
				return false;
			}
			return true;
		}

		/// 
		/// Commits the edit.
		/// </summary>
		/// <param name="enmContext">The context.</param>
		/// <param name="blnForCurrentCellChange">if set to true</c> [for current cell change].</param>
		/// <param name="blnForCurrentRowChange">if set to true</c> [for current row change].</param>
		/// </returns>
		private bool CommitEdit(DataGridViewDataErrorContexts enmContext, bool blnForCurrentCellChange, bool blnForCurrentRowChange)
		{
			if (mobjDataGridViewOper[32768])
			{
				return false;
			}
			DataGridViewCell objDataGridViewCurrentCell = CurrentCellInternal;
			DataGridViewDataErrorEventArgs e = CommitEdit(ref objDataGridViewCurrentCell, enmContext, blnForCurrentCellChange ? DataGridViewValidateCellInternal.Always : DataGridViewValidateCellInternal.WhenChanged, blnForCurrentCellChange, blnForCurrentCellChange, blnForCurrentRowChange, blnForCurrentRowChange, blnFireLeave: false);
			if (e != null)
			{
				if (e.ThrowException)
				{
					throw e.Exception;
				}
				if (e.Cancel)
				{
					return false;
				}
				e = CancelEditPrivate();
				if (e != null)
				{
					if (e.ThrowException)
					{
						throw e.Exception;
					}
					if (e.Cancel)
					{
						return false;
					}
				}
			}
			if (blnForCurrentRowChange && blnForCurrentCellChange)
			{
				if (mobjCurrentCellPoint.X == -1)
				{
					return false;
				}
				int x = mobjCurrentCellPoint.X;
				int y = mobjCurrentCellPoint.Y;
				if (OnRowValidating(ref objDataGridViewCurrentCell, x, y))
				{
					if (!IsInnerCellOutOfBounds(x, y))
					{
						OnRowEnter(ref objDataGridViewCurrentCell, x, y, blnCanCreateNewRow: true, blnValidationFailureOccurred: true);
						if (IsInnerCellOutOfBounds(x, y))
						{
							return false;
						}
						OnCellEnter(ref objDataGridViewCurrentCell, x, y);
					}
					return false;
				}
				if (IsInnerCellOutOfBounds(x, y))
				{
					return false;
				}
				OnRowValidated(ref objDataGridViewCurrentCell, x, y);
			}
			return true;
		}

		/// 
		/// Commits the edit.
		/// </summary>
		/// <param name="objDataGridViewCurrentCell">The data grid view current cell.</param>
		/// <param name="enmContext">The context.</param>
		/// <param name="validateCell">The validate cell.</param>
		/// <param name="blnFireCellLeave">if set to true</c> [fire cell leave].</param>
		/// <param name="blnFireCellEnter">if set to true</c> [fire cell enter].</param>
		/// <param name="blnFireRowLeave">if set to true</c> [fire row leave].</param>
		/// <param name="blnFireRowEnter">if set to true</c> [fire row enter].</param>
		/// <param name="blnFireLeave">if set to true</c> [fire leave].</param>
		/// </returns>
		private DataGridViewDataErrorEventArgs CommitEdit(ref DataGridViewCell objDataGridViewCurrentCell, DataGridViewDataErrorContexts enmContext, DataGridViewValidateCellInternal validateCell, bool blnFireCellLeave, bool blnFireCellEnter, bool blnFireRowLeave, bool blnFireRowEnter, bool blnFireLeave)
		{
			return CommitEdit(ref objDataGridViewCurrentCell, enmContext, validateCell, blnFireCellLeave, blnFireCellEnter, blnFireRowLeave, blnFireRowEnter, blnFireLeave, blnClientSource: false);
		}

		/// 
		/// Commits the edit.
		/// </summary>
		/// <param name="objDataGridViewCurrentCell">The data grid view current cell.</param>
		/// <param name="enmContext">The context.</param>
		/// <param name="validateCell">The validate cell.</param>
		/// <param name="blnFireCellLeave">if set to true</c> [fire cell leave].</param>
		/// <param name="blnFireCellEnter">if set to true</c> [fire cell enter].</param>
		/// <param name="blnFireRowLeave">if set to true</c> [fire row leave].</param>
		/// <param name="blnFireRowEnter">if set to true</c> [fire row enter].</param>
		/// <param name="blnFireLeave">if set to true</c> [fire leave].</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		/// </returns>
		private DataGridViewDataErrorEventArgs CommitEdit(ref DataGridViewCell objDataGridViewCurrentCell, DataGridViewDataErrorContexts enmContext, DataGridViewValidateCellInternal validateCell, bool blnFireCellLeave, bool blnFireCellEnter, bool blnFireRowLeave, bool blnFireRowEnter, bool blnFireLeave, bool blnClientSource)
		{
			Control editingControl = EditingControl;
			if (validateCell == DataGridViewValidateCellInternal.Always)
			{
				if (blnFireCellLeave)
				{
					if (mobjCurrentCellPoint.X == -1)
					{
						return null;
					}
					OnCellLeave(ref objDataGridViewCurrentCell, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
				}
				if (blnFireRowLeave)
				{
					if (mobjCurrentCellPoint.X == -1)
					{
						return null;
					}
					OnRowLeave(ref objDataGridViewCurrentCell, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
				}
				if (blnFireLeave)
				{
					base.OnLeave(EventArgs.Empty);
					if (mobjCurrentCellPoint.X > -1 && mobjCurrentCellPoint.Y > -1)
					{
						InvalidateCellPrivate(mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
					}
				}
				if (CanValidateDataBoundDataGridViewCell(objDataGridViewCurrentCell))
				{
					if (mobjCurrentCellPoint.X == -1)
					{
						return null;
					}
					if (OnCellValidating(ref objDataGridViewCurrentCell, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y, enmContext))
					{
						if (blnFireRowEnter)
						{
							if (mobjCurrentCellPoint.X == -1)
							{
								return null;
							}
							OnRowEnter(ref objDataGridViewCurrentCell, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y, blnCanCreateNewRow: true, blnValidationFailureOccurred: true);
						}
						if (blnFireCellEnter)
						{
							if (mobjCurrentCellPoint.X == -1)
							{
								return null;
							}
							OnCellEnter(ref objDataGridViewCurrentCell, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
						}
						if (mobjCurrentCellPoint.X == -1)
						{
							return null;
						}
						DataGridViewDataErrorEventArgs e = new DataGridViewDataErrorEventArgs(null, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y, enmContext);
						e.Cancel = true;
						return e;
					}
					if (!IsCurrentCellInEditMode || !IsCurrentCellDirty)
					{
						if (mobjCurrentCellPoint.X == -1)
						{
							return null;
						}
						OnCellValidated(ref objDataGridViewCurrentCell, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
					}
				}
			}
			if (mobjCurrentCellPoint.X != -1 && IsCurrentCellInEditMode && IsCurrentCellDirty)
			{
				bool flag = CanValidateDataBoundDataGridViewCell(objDataGridViewCurrentCell);
				if (flag)
				{
					if (validateCell == DataGridViewValidateCellInternal.WhenChanged)
					{
						if (mobjCurrentCellPoint.X == -1)
						{
							return null;
						}
						if (OnCellValidating(ref objDataGridViewCurrentCell, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y, enmContext))
						{
							if (mobjCurrentCellPoint.X == -1)
							{
								return null;
							}
							DataGridViewDataErrorEventArgs e2 = new DataGridViewDataErrorEventArgs(null, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y, enmContext);
							e2.Cancel = true;
							return e2;
						}
					}
					object obj = ((editingControl == null) ? CurrentCellInternal.EditingProposedValue : ((IDataGridViewEditingControl)editingControl).GetEditingControlFormattedValue(enmContext));
					if (!PushFormattedValue(ref objDataGridViewCurrentCell, obj, out var objException, blnClientSource))
					{
						if (mobjCurrentCellPoint.X == -1)
						{
							return null;
						}
						DataGridViewDataErrorEventArgs e3 = new DataGridViewDataErrorEventArgs(objException, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y, enmContext);
						e3.Cancel = true;
						OnDataErrorInternal(e3);
						return e3;
					}
					if (!IsCurrentCellInEditMode)
					{
						return null;
					}
					UneditedFormattedValue = obj;
				}
				if (editingControl != null)
				{
					((IDataGridViewEditingControl)editingControl).EditingControlValueChanged = false;
				}
				else
				{
					((IDataGridViewEditingCell)CurrentCellInternal).EditingCellValueChanged = false;
				}
				SetIsCurrentCellDirtyInternal(blnDirty: false, blnClientSource);
				SetIsCurrentRowDirtyInternal(blnDirty: true, blnClientSource);
				if (flag && (validateCell == DataGridViewValidateCellInternal.Always || validateCell == DataGridViewValidateCellInternal.WhenChanged))
				{
					if (mobjCurrentCellPoint.X == -1)
					{
						return null;
					}
					OnCellValidated(ref objDataGridViewCurrentCell, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
				}
			}
			return null;
		}

		/// 
		/// Pushes the formatted value.
		/// </summary>
		/// <param name="objDataGridViewCurrentCell">The data grid view current cell.</param>
		/// <param name="objFormattedValue">The formatted value.</param>
		/// <param name="objException">The exception.</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		/// </returns>
		private bool PushFormattedValue(ref DataGridViewCell objDataGridViewCurrentCell, object objFormattedValue, out Exception objException, bool blnClientSource)
		{
			objException = null;
			DataGridViewCellStyle inheritedEditingCellStyle = InheritedEditingCellStyle;
			DataGridViewCellParsingEventArgs e = OnCellParsing(mobjCurrentCellPoint.Y, mobjCurrentCellPoint.X, objFormattedValue, objDataGridViewCurrentCell.ValueType, inheritedEditingCellStyle);
			if (e.ParsingApplied && e.Value != null && objDataGridViewCurrentCell.ValueType != null && objDataGridViewCurrentCell.ValueType.IsAssignableFrom(e.Value.GetType()))
			{
				if (objDataGridViewCurrentCell.RowIndex == -1)
				{
					objDataGridViewCurrentCell = Rows[mobjCurrentCellPoint.Y].Cells[mobjCurrentCellPoint.X];
				}
				objDataGridViewCurrentCell.Update();
				return objDataGridViewCurrentCell.SetValueInternal(mobjCurrentCellPoint.Y, e.Value);
			}
			object objValue;
			try
			{
				objValue = objDataGridViewCurrentCell.ParseFormattedValue(objFormattedValue, e.InheritedCellStyle, null, null);
			}
			catch (Exception ex)
			{
				if (ClientUtils.IsCriticalException(ex))
				{
					throw;
				}
				objException = ex;
				return false;
			}
			if (objDataGridViewCurrentCell.RowIndex == -1)
			{
				objDataGridViewCurrentCell = Rows[mobjCurrentCellPoint.Y].Cells[mobjCurrentCellPoint.X];
			}
			return objDataGridViewCurrentCell.SetValueInternal(mobjCurrentCellPoint.Y, objValue, blnClientSource);
		}

		/// Creates and returns a new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnCollection"></see>.</summary>
		/// An empty <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnCollection"></see>.</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual DataGridViewColumnCollection CreateColumnsInstance()
		{
			return new DataGridViewColumnCollection(this);
		}

		/// Creates and returns a new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</summary>
		/// An empty <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see>.</returns>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		protected virtual DataGridViewRowCollection CreateRowsInstance()
		{
			return new DataGridViewRowCollection(this);
		}

		/// Returns the number of columns displayed to the user.</summary>
		/// The number of columns displayed to the user.</returns>
		/// <param name="blnIncludePartialColumns">true to include partial columns in the displayed column count; otherwise, false. </param>
		/// 1</filterpriority>
		public int DisplayedColumnCount(bool blnIncludePartialColumns)
		{
			return -1;
		}

		private void RemoveIndividuallySelectedCells()
		{
			bool flag = false;
			DataGridViewCellLinkedList individualSelectedCells = IndividualSelectedCells;
			if (individualSelectedCells.Count > 8)
			{
				BulkPaintCount++;
				flag = true;
			}
			try
			{
				while (individualSelectedCells.Count > 0)
				{
					DataGridViewCell headCell = individualSelectedCells.HeadCell;
					SetSelectedCellCore(headCell.ColumnIndex, headCell.RowIndex, blnSelected: false);
				}
			}
			finally
			{
				if (flag)
				{
					ExitBulkPaint(-1, -1);
				}
			}
		}

		/// 
		/// Removes the individually selected cells.
		/// </summary>
		/// <param name="intColumnIndexException">The int column index exception.</param>
		/// <param name="intRowIndexException">The int row index exception.</param>
		private void RemoveIndividuallySelectedCells(int intColumnIndexException, int intRowIndexException)
		{
			RemoveIndividuallySelectedCells(intColumnIndexException, intRowIndexException, blnClientSource: false);
		}

		/// 
		/// Removes the individually selected cells.
		/// </summary>
		/// <param name="intColumnIndexException">The int column index exception.</param>
		/// <param name="intRowIndexException">The int row index exception.</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		private void RemoveIndividuallySelectedCells(int intColumnIndexException, int intRowIndexException, bool blnClientSource)
		{
			bool flag = false;
			DataGridViewCellLinkedList individualSelectedCells = IndividualSelectedCells;
			if (individualSelectedCells.Count > 8)
			{
				BulkPaintCount++;
				flag = true;
			}
			try
			{
				while (individualSelectedCells.Count > 0)
				{
					DataGridViewCell headCell = individualSelectedCells.HeadCell;
					if (headCell.ColumnIndex != intColumnIndexException || headCell.RowIndex != intRowIndexException)
					{
						SetSelectedCellCore(headCell.ColumnIndex, headCell.RowIndex, blnSelected: false, blnClientSource);
						continue;
					}
					while (individualSelectedCells.Count > 1)
					{
						headCell = individualSelectedCells[1];
						SetSelectedCellCore(headCell.ColumnIndex, headCell.RowIndex, blnSelected: false);
					}
					break;
				}
			}
			finally
			{
				if (flag)
				{
					ExitBulkPaint(-1, -1);
				}
			}
		}

		private void RefreshColumnsAndRows()
		{
			Rows.ClearInternal(blnRecreateNewRow: false);
			RefreshColumns();
			RefreshRows(blnScrollIntoView: true);
		}

		private void RefreshColumns()
		{
			bool visible = base.Visible;
			if (visible)
			{
			}
			mobjDataGridViewOper[1024] = true;
			try
			{
				DataGridViewColumnCollection columns = Columns;
				DataGridViewColumn[] arrBoundColumns = null;
				if (DataConnection != null)
				{
					arrBoundColumns = DataConnection.GetCollectionOfBoundDataGridViewColumns();
				}
				if (AutoGenerateColumns)
				{
					AutoGenerateDataBoundColumns(arrBoundColumns);
				}
				else
				{
					for (int i = 0; i < columns.Count; i++)
					{
						columns[i].IsDataBoundInternal = false;
						columns[i].BoundColumnIndex = -1;
						columns[i].BoundColumnConverter = null;
						if (DataSource != null && columns[i].DataPropertyName.Length != 0)
						{
							MapDataGridViewColumnToDataBoundField(columns[i]);
						}
					}
				}
				if (DataSource != null)
				{
					DataConnection.ApplySortingInformationFromBackEnd();
				}
			}
			finally
			{
				mobjDataGridViewOper[1024] = false;
				if (visible)
				{
					Invalidate(blnInvalidateChildren: true);
				}
			}
		}

		private void MapDataGridViewColumnToDataBoundField(DataGridViewColumn objDataGridViewColumn)
		{
			DataGridViewDataConnection dataConnection = DataConnection;
			int num = dataConnection?.BoundColumnIndex(objDataGridViewColumn.DataPropertyName) ?? (-1);
			if (num != -1)
			{
				objDataGridViewColumn.IsDataBoundInternal = true;
				objDataGridViewColumn.BoundColumnIndex = num;
				objDataGridViewColumn.BoundColumnConverter = dataConnection.BoundColumnConverter(num);
				objDataGridViewColumn.ValueType = dataConnection.BoundColumnValueType(num);
				objDataGridViewColumn.ReadOnly = dataConnection.DataFieldIsReadOnly(objDataGridViewColumn.BoundColumnIndex) || objDataGridViewColumn.ReadOnly;
				InvalidateColumnInternal(objDataGridViewColumn.Index);
				if (objDataGridViewColumn.SortMode != DataGridViewColumnSortMode.NotSortable && !mobjDataGridViewOper[1024])
				{
					objDataGridViewColumn.HeaderCell.SortGlyphDirection = dataConnection.BoundColumnSortOrder(num);
					if (SortedColumn == null && objDataGridViewColumn.HeaderCell.SortGlyphDirection != SortOrder.None)
					{
						SortedColumn = objDataGridViewColumn;
						SortOrder = objDataGridViewColumn.HeaderCell.SortGlyphDirection;
					}
				}
			}
			else
			{
				objDataGridViewColumn.IsDataBoundInternal = false;
				objDataGridViewColumn.BoundColumnIndex = -1;
				objDataGridViewColumn.BoundColumnConverter = null;
				InvalidateColumnInternal(objDataGridViewColumn.Index);
			}
		}

		private void AutoGenerateDataBoundColumns(DataGridViewColumn[] arrBoundColumns)
		{
			DataGridViewColumnCollection columns = Columns;
			DataGridViewColumn[] array = new DataGridViewColumn[columns.Count];
			int num = 0;
			int i;
			for (i = 0; i < columns.Count; i++)
			{
				if (DataSource != null && !CommonUtils.IsNullOrEmpty(columns[i].DataPropertyName) && !columns[i].IsDataBound)
				{
					MapDataGridViewColumnToDataBoundField(columns[i]);
				}
				if (columns[i].IsDataBound && DataConnection != null && DataConnection.BoundColumnIndex(columns[i].DataPropertyName) != -1)
				{
					array[num] = (DataGridViewColumn)columns[i].Clone();
					array[num].DisplayIndex = columns[i].DisplayIndex;
					num++;
				}
			}
			i = 0;
			while (i < columns.Count)
			{
				if (columns[i].IsDataBound)
				{
					columns.RemoveAtInternal(i, blnForce: true);
				}
				else
				{
					i++;
				}
			}
			DataGridViewColumn[] array2;
			if (array.Length == num)
			{
				array2 = array;
			}
			else
			{
				array2 = new DataGridViewColumn[num];
				Array.Copy(array, array2, num);
			}
			Array.Sort(array2, DataGridViewColumnCollection.ColumnCollectionOrderComparer);
			if (arrBoundColumns == null)
			{
				return;
			}
			for (int j = 0; j < arrBoundColumns.Length; j++)
			{
				if (arrBoundColumns[j] == null || !arrBoundColumns[j].IsBrowsableInternal)
				{
					continue;
				}
				bool flag = true;
				int k;
				for (k = 0; k < num; k++)
				{
					if (array2[k] != null && string.Compare(array2[k].DataPropertyName, arrBoundColumns[j].DataPropertyName, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					columns.Add(arrBoundColumns[j]);
					continue;
				}
				columns.Add(array2[k]);
				MapDataGridViewColumnToDataBoundField(array2[k]);
				array2[k] = null;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected void RefreshRows(bool blnScrollIntoView)
		{
			bool visible = base.Visible;
			if (visible)
			{
			}
			try
			{
				if (mobjDataGridViewOper[131072])
				{
					mobjDataGridViewState2[4194304] = true;
				}
				DataGridViewRowCollection rows = Rows;
				rows.ClearInternal(blnRecreateNewRow: true);
				if (DataConnection == null || Columns.Count <= 0)
				{
					return;
				}
				IList list = DataConnection.List;
				if (list == null || list.Count <= 0)
				{
					return;
				}
				int count = list.Count;
				bool doNotChangePositionInTheCurrencyManager = DataConnection.DoNotChangePositionInTheCurrencyManager;
				bool flag = !InSortOperation;
				if (flag)
				{
					DataConnection.DoNotChangePositionInTheCurrencyManager = true;
				}
				try
				{
					rows.AddInternal(RowTemplateClone);
					if (count > 1)
					{
						rows.AddCopiesInternal(0, count - 1);
					}
				}
				finally
				{
					DataConnection.DoNotChangePositionInTheCurrencyManager = doNotChangePositionInTheCurrencyManager;
				}
				if (flag)
				{
					DataConnection.MatchCurrencyManagerPosition(blnScrollIntoView, blnClearSelection: true);
				}
			}
			finally
			{
				if (visible)
				{
					Invalidate(blnInvalidateChildren: true);
				}
			}
		}

		/// Returns the number of rows displayed to the user.</summary>
		/// The number of rows displayed to the user.</returns>
		/// <param name="blnIncludePartialRow">true to include partial rows in the displayed row count; otherwise, false. </param>
		/// 1</filterpriority>
		public int DisplayedRowCount(bool blnIncludePartialRow)
		{
			return -1;
		}

		/// 
		/// Gets a type convertor or creates a new one
		/// </summary>
		/// <param name="objType"></param>
		/// </returns>
		internal TypeConverter GetCachedTypeConverter(Type objType)
		{
			return new TypeConverter();
		}

		/// Commits and ends the edit operation on the current cell using the default error context.</summary>
		/// true if the edit operation is committed and ended; otherwise, false.</returns>
		/// <exception cref="T:System.Exception">The cell value could not be committed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		public bool EndEdit()
		{
			return EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.Parsing);
		}

		/// 
		/// Scrolls the into view.
		/// </summary>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="blnForCurrentCellChange">if set to true</c> [for current cell change].</param>
		/// </returns>
		private bool ScrollIntoView(int intColumnIndex, int intRowIndex, bool blnForCurrentCellChange)
		{
			if (mobjCurrentCellPoint.X >= 0 && (mobjCurrentCellPoint.X != intColumnIndex || mobjCurrentCellPoint.Y != intRowIndex))
			{
				if (!CommitEditForOperation(intColumnIndex, intRowIndex, blnForCurrentCellChange))
				{
					return false;
				}
				if (IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
				{
					return false;
				}
			}
			if (!IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
			{
				DataGridViewRow dataGridViewRow = Rows.SharedRow(intRowIndex);
				if (dataGridViewRow != null)
				{
					PerformScrollIntoView(dataGridViewRow.Cells[intColumnIndex], blnHidePopups: false);
				}
				return true;
			}
			return false;
		}

		/// Commits and ends the edit operation on the current cell using the specified error context.</summary>
		/// true if the edit operation is committed and ended; otherwise, false.</returns>
		/// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values that specifies the context in which an error can occur. </param>
		/// <exception cref="T:System.Exception">The cell value could not be committed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		public bool EndEdit(DataGridViewDataErrorContexts enmContext)
		{
			if (EditMode == DataGridViewEditMode.EditOnEnter)
			{
				return CommitEdit(enmContext);
			}
			return EndEdit(enmContext, DataGridViewValidateCellInternal.Never, blnFireCellLeave: false, blnFireCellEnter: false, blnFireRowLeave: false, blnFireRowEnter: false, blnFireLeave: false, blnKeepFocus: true, blnResetCurrentCell: true, blnResetAnchorCell: true);
		}

		/// 
		/// Determines whether this instance [can validate data bound data grid view cell] the specified data grid view current cell.
		/// </summary>
		/// <param name="objDataGridViewCurrentCell">The data grid view current cell.</param>
		/// 
		/// 	true</c> if this instance [can validate data bound data grid view cell] the specified data grid view current cell; otherwise, false</c>.
		/// </returns>
		private bool CanValidateDataBoundDataGridViewCell(DataGridViewCell objDataGridViewCurrentCell)
		{
			if (objDataGridViewCurrentCell == null && mobjCurrentCellPoint.X > -1)
			{
				objDataGridViewCurrentCell = CurrentCellInternal;
			}
			if (objDataGridViewCurrentCell != null)
			{
				if (!objDataGridViewCurrentCell.OwningColumn.IsDataBoundInternal)
				{
					return true;
				}
				if (mobjDataGridViewOper[1048576])
				{
					return false;
				}
				if (DataConnection == null)
				{
					return true;
				}
				if (DataConnection.ProcessingMetaDataChanges)
				{
					return false;
				}
				if (DataConnection.CancellingRowEdit && !DataConnection.RestoreRow)
				{
					return false;
				}
				if (DataConnection.CurrencyManager.Count <= mobjCurrentCellPoint.Y)
				{
					return false;
				}
				if (DataConnection.PositionChangingOutsideDataGridView)
				{
					return false;
				}
				if (DataConnection.ListWasReset)
				{
					return false;
				}
			}
			return true;
		}

		/// 
		/// Called when [cell validating].
		/// </summary>
		/// <param name="objDataGridViewCell">The data grid view cell.</param>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="enmContext">The context.</param>
		/// </returns>
		internal bool OnCellValidating(ref DataGridViewCell objDataGridViewCell, int intColumnIndex, int intRowIndex, DataGridViewDataErrorContexts enmContext)
		{
			DataGridViewCell dataGridViewCell = ((objDataGridViewCell == null) ? CurrentCellInternal : objDataGridViewCell);
			DataGridViewCellStyle inheritedStyle = dataGridViewCell.GetInheritedStyle(null, intRowIndex, blnIncludeColors: false);
			object valueInternal = dataGridViewCell.GetValueInternal(intRowIndex);
			object objFormattedValue = ((dataGridViewCell.EditingProposedValue == null) ? dataGridViewCell.FormattedValue : dataGridViewCell.EditingProposedValue);
			DataGridViewCellValidatingEventArgs e = new DataGridViewCellValidatingEventArgs(intColumnIndex, intRowIndex, objFormattedValue);
			OnCellValidating(e);
			if (objDataGridViewCell != null)
			{
				if (IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
				{
					objDataGridViewCell = null;
				}
				else
				{
					objDataGridViewCell = Rows.SharedRow(intRowIndex).Cells[intColumnIndex];
				}
			}
			return e.Cancel;
		}

		/// 
		/// Called when [cell validated].
		/// </summary>
		/// <param name="objDataGridViewCell">The data grid view cell.</param>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		internal void OnCellValidated(ref DataGridViewCell objDataGridViewCell, int intColumnIndex, int intRowIndex)
		{
			OnCellValidated(new DataGridViewCellEventArgs(intColumnIndex, intRowIndex));
			if (objDataGridViewCell != null)
			{
				if (IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
				{
					objDataGridViewCell = null;
				}
				else
				{
					objDataGridViewCell = Rows.SharedRow(intRowIndex).Cells[intColumnIndex];
				}
			}
		}

		/// 
		/// Ends the edit.
		/// </summary>
		/// <param name="enmContext">The context.</param>
		/// <param name="validateCell">The validate cell.</param>
		/// <param name="blnFireCellLeave">if set to true</c> [fire cell leave].</param>
		/// <param name="blnFireCellEnter">if set to true</c> [fire cell enter].</param>
		/// <param name="blnFireRowLeave">if set to true</c> [fire row leave].</param>
		/// <param name="blnFireRowEnter">if set to true</c> [fire row enter].</param>
		/// <param name="blnFireLeave">if set to true</c> [fire leave].</param>
		/// <param name="blnKeepFocus">Obsolete(not used), performed on client side.</param>
		/// <param name="blnResetCurrentCell">if set to true</c> [reset current cell].</param>
		/// <param name="blnResetAnchorCell">if set to true</c> [reset anchor cell].</param>
		/// </returns>
		private bool EndEdit(DataGridViewDataErrorContexts enmContext, DataGridViewValidateCellInternal validateCell, bool blnFireCellLeave, bool blnFireCellEnter, bool blnFireRowLeave, bool blnFireRowEnter, bool blnFireLeave, bool blnKeepFocus, bool blnResetCurrentCell, bool blnResetAnchorCell)
		{
			return EndEdit(enmContext, validateCell, blnFireCellLeave, blnFireCellEnter, blnFireRowLeave, blnFireRowEnter, blnFireLeave, blnKeepFocus, blnResetCurrentCell, blnResetAnchorCell, blnClientSource: false);
		}

		/// 
		/// Ends the edit.
		/// </summary>
		/// <param name="enmContext">The context.</param>
		/// <param name="validateCell">The validate cell.</param>
		/// <param name="blnFireCellLeave">if set to true</c> [fire cell leave].</param>
		/// <param name="blnFireCellEnter">if set to true</c> [fire cell enter].</param>
		/// <param name="blnFireRowLeave">if set to true</c> [fire row leave].</param>
		/// <param name="blnFireRowEnter">if set to true</c> [fire row enter].</param>
		/// <param name="blnFireLeave">if set to true</c> [fire leave].</param>
		/// <param name="blnKeepFocus">Obsolete(not used), performed on client side.</param>
		/// <param name="blnResetCurrentCell">if set to true</c> [reset current cell].</param>
		/// <param name="blnResetAnchorCell">if set to true</c> [reset anchor cell].</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		/// </returns>
		private bool EndEdit(DataGridViewDataErrorContexts enmContext, DataGridViewValidateCellInternal validateCell, bool blnFireCellLeave, bool blnFireCellEnter, bool blnFireRowLeave, bool blnFireRowEnter, bool blnFireLeave, bool blnKeepFocus, bool blnResetCurrentCell, bool blnResetAnchorCell, bool blnClientSource)
		{
			if (mobjCurrentCellPoint.X == -1)
			{
				return true;
			}
			mobjDataGridViewOper[4194304] = true;
			try
			{
				int y = mobjCurrentCellPoint.Y;
				int x = mobjCurrentCellPoint.X;
				DataGridViewCell objDataGridViewCurrentCell = CurrentCellInternal;
				DataGridViewDataErrorEventArgs e = CommitEdit(ref objDataGridViewCurrentCell, enmContext, validateCell, blnFireCellLeave, blnFireCellEnter, blnFireRowLeave, blnFireRowEnter, blnFireLeave, blnClientSource);
				if (e != null)
				{
					if (e.ThrowException)
					{
						throw e.Exception;
					}
					if (e.Cancel)
					{
						return false;
					}
					e = CancelEditPrivate();
					if (e != null)
					{
						if (e.ThrowException)
						{
							throw e.Exception;
						}
						if (e.Cancel)
						{
							return false;
						}
					}
				}
				if (!IsCurrentCellInEditMode)
				{
					return true;
				}
				if (y != mobjCurrentCellPoint.Y || x != mobjCurrentCellPoint.X)
				{
					return true;
				}
				if (EditingControl != null)
				{
					mobjDataGridViewState1[16384] = true;
					try
					{
						objDataGridViewCurrentCell.DetachEditingControl();
					}
					finally
					{
						mobjDataGridViewState1[16384] = false;
					}
					LatestEditingControl = EditingControl;
					EditingControl = null;
					if (!blnClientSource)
					{
						InvalidateCellPrivate(mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
					}
					if (EditMode == DataGridViewEditMode.EditOnEnter && blnResetCurrentCell)
					{
						SetCurrentCellAddressCore(-1, -1, blnResetAnchorCell, blnValidateCurrentCell: false, blnThroughMouseClick: false);
					}
				}
				else
				{
					mobjDataGridViewState1[32768] = false;
					InvalidateCellPrivate(mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
				}
				if (!IsInnerCellOutOfBounds(x, y))
				{
					DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(x, y);
					OnCellEndEdit(e2);
				}
			}
			finally
			{
				mobjDataGridViewOper[4194304] = false;
			}
			return true;
		}

		private bool IsColumnOutOfBounds(int intColumnIndex)
		{
			if (intColumnIndex < Columns.Count)
			{
				return intColumnIndex == -1;
			}
			return true;
		}

		private DataGridViewDataErrorEventArgs CancelEditPrivate()
		{
			bool isCurrentCellDirty = IsCurrentCellDirty;
			bool isCurrentRowDirty = IsCurrentRowDirty;
			if (IsCurrentCellInEditMode)
			{
				if (EditingControl != null)
				{
					((IDataGridViewEditingControl)EditingControl).EditingControlValueChanged = false;
				}
				else
				{
					((IDataGridViewEditingCell)CurrentCellInternal).EditingCellValueChanged = false;
				}
				IsCurrentCellDirtyInternal = false;
			}
			if (DataSource != null || VirtualMode)
			{
				if ((isCurrentRowDirty && !isCurrentCellDirty) || (mobjDataGridViewState1[524288] && !mobjDataGridViewState1[262144]))
				{
					bool flag = mobjDataGridViewState1[524288];
					IsCurrentRowDirtyInternal = false;
					if (VirtualMode)
					{
						QuestionEventArgs e = new QuestionEventArgs(flag);
						OnCancelRowEdit(e);
						flag &= e.Response;
					}
					if (DataSource != null)
					{
						int x = mobjCurrentCellPoint.X;
						DataConnection.CancelRowEdit(blnRestoreRow: true, mobjDataGridViewState1[524288]);
						if (DataConnection.List.Count == 0)
						{
							if (isCurrentCellDirty || mobjCurrentCellPoint.Y == -1 || mobjCurrentCellPoint.X == -1)
							{
								if (!IsColumnOutOfBounds(x) && Columns[x].Visible)
								{
									SetAndSelectCurrentCellAddress(x, 0, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false, blnClearSelection: true, blnForceCurrentCellSelection: false);
								}
							}
							else
							{
								DataConnection.OnNewRowNeeded();
							}
						}
						flag = false;
					}
					if (mobjCurrentCellPoint.Y > -1)
					{
						InvalidateRowPrivate(mobjCurrentCellPoint.Y);
						DataGridViewCell objDataGridViewCell = CurrentCellInternal;
						if (IsCurrentCellInEditMode)
						{
							DataGridViewCellStyle objDataGridViewCellStyle = objDataGridViewCell.GetInheritedStyle(null, mobjCurrentCellPoint.Y, blnIncludeColors: true);
							if (EditingControl != null)
							{
								InitializeEditingControlValue(ref objDataGridViewCellStyle, objDataGridViewCell);
							}
							else
							{
								InitializeEditingCellValue(ref objDataGridViewCellStyle, ref objDataGridViewCell);
							}
						}
					}
					if (flag && mobjCurrentCellPoint.Y == NewRowIndex - 1)
					{
						DiscardNewRow();
					}
				}
			}
			else if (!IsCurrentRowDirty && mobjCurrentCellPoint.Y == NewRowIndex - 1 && mobjDataGridViewState1[2097152])
			{
				DiscardNewRow();
			}
			return null;
		}

		private void DiscardNewRow()
		{
			DataGridViewRowCollection rows = Rows;
			DataGridViewRowCancelEventArgs e = new DataGridViewRowCancelEventArgs(rows[NewRowIndex]);
			OnUserDeletingRow(e);
			if (!e.Cancel)
			{
				DataGridViewRow objDataGridViewRow = rows[NewRowIndex];
				rows.RemoveAtInternal(NewRowIndex, blnForce: false);
				DataGridViewRowEventArgs e2 = new DataGridViewRowEventArgs(objDataGridViewRow);
				OnUserDeletedRow(e2);
				if (AllowUserToAddRowsInternal)
				{
					NewRowIndex = rows.Count - 1;
					OnDefaultValuesNeeded(new DataGridViewRowEventArgs(rows[NewRowIndex]));
					InvalidateRowPrivate(NewRowIndex);
				}
			}
		}

		/// Gets the number of cells that satisfy the provided filter.</summary>
		/// The number of cells that match the includeFilter parameter.</returns>
		/// <param name="enmIncludeFilter">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values specifying the cells to count.</param>
		/// <exception cref="T:System.ArgumentException">includeFilter includes the value <see cref="F:Gizmox.WebGUI.Forms.DataGridViewElementStates.ResizableSet"></see>.</exception>
		public int GetCellCount(DataGridViewElementStates enmIncludeFilter)
		{
			DataGridViewRowCollection rows = Rows;
			if ((enmIncludeFilter & ~(DataGridViewElementStates.Displayed | DataGridViewElementStates.Frozen | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Resizable | DataGridViewElementStates.Selected | DataGridViewElementStates.Visible)) != DataGridViewElementStates.None)
			{
				throw new ArgumentException(SR.GetString("DataGridView_InvalidDataGridViewElementStateCombination", "includeFilter"));
			}
			int num = 0;
			DataGridViewCellLinkedList individualSelectedCells = IndividualSelectedCells;
			bool blnDisplayedRequired;
			bool blnFrozenRequired;
			bool blnResizableRequired;
			bool blnReadOnlyRequired;
			bool blnVisibleRequired;
			if ((enmIncludeFilter & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
			{
				if (enmIncludeFilter == DataGridViewElementStates.Selected)
				{
					num = individualSelectedCells.Count;
					switch (SelectionMode)
					{
					case DataGridViewSelectionMode.CellSelect:
						return num;
					case DataGridViewSelectionMode.FullRowSelect:
					case DataGridViewSelectionMode.RowHeaderSelect:
						return num + SelectedBandIndexes.Count * Columns.Count;
					case DataGridViewSelectionMode.FullColumnSelect:
					case DataGridViewSelectionMode.ColumnHeaderSelect:
						return num + SelectedBandIndexes.Count * rows.Count;
					}
				}
				blnDisplayedRequired = (enmIncludeFilter & DataGridViewElementStates.Displayed) == DataGridViewElementStates.Displayed;
				blnFrozenRequired = (enmIncludeFilter & DataGridViewElementStates.Frozen) == DataGridViewElementStates.Frozen;
				blnResizableRequired = (enmIncludeFilter & DataGridViewElementStates.Resizable) == DataGridViewElementStates.Resizable;
				blnReadOnlyRequired = (enmIncludeFilter & DataGridViewElementStates.ReadOnly) == DataGridViewElementStates.ReadOnly;
				blnVisibleRequired = (enmIncludeFilter & DataGridViewElementStates.Visible) == DataGridViewElementStates.Visible;
				foreach (DataGridViewCell item in (IEnumerable)individualSelectedCells)
				{
					if (GetCellCount_CellIncluded(item, item.RowIndex, blnDisplayedRequired, blnFrozenRequired, blnResizableRequired, blnReadOnlyRequired, blnVisibleRequired))
					{
						num++;
					}
				}
				switch (SelectionMode)
				{
				case DataGridViewSelectionMode.CellSelect:
					return num;
				case DataGridViewSelectionMode.FullRowSelect:
				case DataGridViewSelectionMode.RowHeaderSelect:
					foreach (int item2 in (IEnumerable)SelectedBandIndexes)
					{
						DataGridViewRow dataGridViewRow2 = rows.SharedRow(item2);
						foreach (DataGridViewCell cell in dataGridViewRow2.Cells)
						{
							if (GetCellCount_CellIncluded(cell, item2, blnDisplayedRequired, blnFrozenRequired, blnResizableRequired, blnReadOnlyRequired, blnVisibleRequired))
							{
								num++;
							}
						}
					}
					return num;
				case DataGridViewSelectionMode.FullColumnSelect:
				case DataGridViewSelectionMode.ColumnHeaderSelect:
				{
					for (int i = 0; i < rows.Count; i++)
					{
						DataGridViewRow dataGridViewRow = rows.SharedRow(i);
						foreach (int item3 in (IEnumerable)SelectedBandIndexes)
						{
							DataGridViewCell objDataGridViewCell = dataGridViewRow.Cells[item3];
							if (GetCellCount_CellIncluded(objDataGridViewCell, i, blnDisplayedRequired, blnFrozenRequired, blnResizableRequired, blnReadOnlyRequired, blnVisibleRequired))
							{
								num++;
							}
						}
					}
					return num;
				}
				}
			}
			if ((enmIncludeFilter == DataGridViewElementStates.ReadOnly && ReadOnly) || enmIncludeFilter == DataGridViewElementStates.None)
			{
				return rows.Count * Columns.Count;
			}
			blnDisplayedRequired = (enmIncludeFilter & DataGridViewElementStates.Displayed) == DataGridViewElementStates.Displayed;
			blnFrozenRequired = (enmIncludeFilter & DataGridViewElementStates.Frozen) == DataGridViewElementStates.Frozen;
			blnResizableRequired = (enmIncludeFilter & DataGridViewElementStates.Resizable) == DataGridViewElementStates.Resizable;
			blnReadOnlyRequired = (enmIncludeFilter & DataGridViewElementStates.ReadOnly) == DataGridViewElementStates.ReadOnly;
			blnVisibleRequired = (enmIncludeFilter & DataGridViewElementStates.Visible) == DataGridViewElementStates.Visible;
			for (int j = 0; j < rows.Count; j++)
			{
				DataGridViewRow dataGridViewRow3 = rows.SharedRow(j);
				if (blnVisibleRequired && (rows.GetRowState(j) & DataGridViewElementStates.Visible) == 0)
				{
					continue;
				}
				foreach (DataGridViewCell cell2 in dataGridViewRow3.Cells)
				{
					if (GetCellCount_CellIncluded(cell2, j, blnDisplayedRequired, blnFrozenRequired, blnResizableRequired, blnReadOnlyRequired, blnVisibleRequired))
					{
						num++;
					}
				}
			}
			return num;
		}

		/// 
		/// Indicates if a specific row is resizable
		/// </summary>
		/// <param name="intRowIndex"></param>
		/// </returns>
		private bool RowIsResizable(int intRowIndex)
		{
			DataGridViewElementStates rowState = Rows.GetRowState(intRowIndex);
			if ((rowState & DataGridViewElementStates.ResizableSet) == DataGridViewElementStates.ResizableSet)
			{
				return (rowState & DataGridViewElementStates.Resizable) == DataGridViewElementStates.Resizable;
			}
			return AllowUserToResizeRows;
		}

		/// 
		/// Check if cell is included
		/// </summary>
		/// <param name="objDataGridViewCell"></param>
		/// <param name="intRowIndex"></param>
		/// <param name="blnDisplayedRequired"></param>
		/// <param name="blnFrozenRequired"></param>
		/// <param name="blnResizableRequired"></param>
		/// <param name="blnReadOnlyRequired"></param>
		/// <param name="blnVisibleRequired"></param>
		/// </returns>
		private bool GetCellCount_CellIncluded(DataGridViewCell objDataGridViewCell, int intRowIndex, bool blnDisplayedRequired, bool blnFrozenRequired, bool blnResizableRequired, bool blnReadOnlyRequired, bool blnVisibleRequired)
		{
			DataGridViewElementStates rowState = Rows.GetRowState(intRowIndex);
			if (blnDisplayedRequired && ((rowState & DataGridViewElementStates.Displayed) == 0 || !objDataGridViewCell.OwningColumn.Displayed))
			{
				return false;
			}
			if (blnFrozenRequired && (rowState & DataGridViewElementStates.Frozen) == 0 && !objDataGridViewCell.OwningColumn.Frozen && !objDataGridViewCell.StateIncludes(DataGridViewElementStates.Frozen))
			{
				return false;
			}
			if (blnResizableRequired && !RowIsResizable(intRowIndex) && objDataGridViewCell.OwningColumn.Resizable != DataGridViewTriState.True)
			{
				return false;
			}
			if (blnReadOnlyRequired && !ReadOnly && (rowState & DataGridViewElementStates.ReadOnly) == 0 && !objDataGridViewCell.OwningColumn.ReadOnly && !objDataGridViewCell.StateIncludes(DataGridViewElementStates.ReadOnly))
			{
				return false;
			}
			if (blnVisibleRequired && ((rowState & DataGridViewElementStates.Visible) == 0 || !objDataGridViewCell.OwningColumn.Visible))
			{
				return false;
			}
			return true;
		}

		/// Retrieves the formatted values that represent the contents of the selected cells for copying to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> that represents the contents of the selected cells.</returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:Gizmox.WebGUI.Forms.DataGridView.ClipboardCopyMode"></see> is set to <see cref="F:Gizmox.WebGUI.Forms.DataGridViewClipboardCopyMode.Disable"></see>.</exception>
		public virtual DataObject GetClipboardContent()
		{
			return GetClipboardContentInternal(new string[4]
			{
				DataFormats.Html,
				DataFormats.Text,
				DataFormats.UnicodeText,
				DataFormats.CommaSeparatedValue
			});
		}

		private static string ConvertToDataFormats(TextDataFormat enmFormat)
		{
			return enmFormat switch
			{
				TextDataFormat.Text => DataFormats.Text, 
				TextDataFormat.UnicodeText => DataFormats.UnicodeText, 
				TextDataFormat.Rtf => DataFormats.Rtf, 
				TextDataFormat.Html => DataFormats.Html, 
				TextDataFormat.CommaSeparatedValue => DataFormats.CommaSeparatedValue, 
				_ => DataFormats.UnicodeText, 
			};
		}

		/// Retrieves the formatted values that represent the contents of the selected cells for copying to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</summary>
		/// <param name="enmFormat">The serializing format to be produced.</param>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataObject"></see> that represents the contents of the selected cells.</returns>
		/// <exception cref="T:System.NotSupportedException"><see cref="P:Gizmox.WebGUI.Forms.DataGridView.ClipboardCopyMode"></see> is set to <see cref="F:Gizmox.WebGUI.Forms.DataGridViewClipboardCopyMode.Disable"></see>.</exception>
		public virtual DataObject GetClipboardContent(TextDataFormat enmFormat)
		{
			return GetClipboardContentInternal(new string[1] { ConvertToDataFormats(enmFormat) });
		}

		/// 
		///
		/// </summary>
		/// <param name="arrText"></param>
		/// </returns>
		private DataObject GetClipboardContentInternal(string[] arrText)
		{
			DataGridViewCellLinkedList individualSelectedCells = IndividualSelectedCells;
			DataGridViewRowCollection rows = Rows;
			if (ClipboardCopyMode == DataGridViewClipboardCopyMode.Disable)
			{
				throw new NotSupportedException(SR.GetString("DataGridView_DisabledClipboardCopy"));
			}
			DataObject dataObject = new DataObject();
			bool flag = false;
			bool flag2 = false;
			string text = null;
			StringBuilder stringBuilder = null;
			switch (SelectionMode)
			{
			case DataGridViewSelectionMode.CellSelect:
			case DataGridViewSelectionMode.RowHeaderSelect:
			case DataGridViewSelectionMode.ColumnHeaderSelect:
			{
				bool flag5 = false;
				bool flag6 = false;
				bool flag7 = false;
				if (SelectionMode != DataGridViewSelectionMode.RowHeaderSelect)
				{
					if (SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
					{
						flag6 = Columns.GetColumnCount(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible) != 0;
						flag5 = flag6 && rows.GetRowCount(DataGridViewElementStates.Visible) != 0;
					}
				}
				else
				{
					flag7 = rows.GetRowCount(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible) != 0;
					flag5 = flag7 && Columns.GetColumnCount(DataGridViewElementStates.Visible) != 0;
				}
				if (!flag5 && individualSelectedCells.Count > 0)
				{
					foreach (DataGridViewCell item in (IEnumerable)individualSelectedCells)
					{
						if (item.Visible)
						{
							flag5 = true;
							break;
						}
					}
				}
				if (!flag5)
				{
					return null;
				}
				if (SelectionMode == DataGridViewSelectionMode.CellSelect)
				{
					flag = (flag2 = ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText);
					flag &= ColumnHeadersVisible;
					flag2 &= RowHeadersVisible;
				}
				else
				{
					flag = (flag2 = false);
					if (ColumnHeadersVisible)
					{
						if (ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableWithAutoHeaderText)
						{
							if (flag6)
							{
								flag = true;
							}
						}
						else
						{
							flag = ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
						}
					}
					if (RowHeadersVisible)
					{
						if (ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableWithAutoHeaderText)
						{
							if (flag7)
							{
								flag2 = true;
							}
						}
						else
						{
							flag2 = ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
						}
					}
				}
				int num4 = int.MaxValue;
				int num5 = -1;
				DataGridViewColumn dataGridViewColumn2 = null;
				DataGridViewColumn dataGridViewColumn3 = null;
				if (SelectionMode != DataGridViewSelectionMode.RowHeaderSelect)
				{
					if (SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
					{
						int firstRow = rows.GetFirstRow(DataGridViewElementStates.Visible);
						int lastRow = rows.GetLastRow(DataGridViewElementStates.Visible);
						foreach (int item2 in (IEnumerable)SelectedBandIndexes)
						{
							if (Columns[item2].Visible)
							{
								if (dataGridViewColumn2 == null || Columns.DisplayInOrder(item2, dataGridViewColumn2.Index))
								{
									dataGridViewColumn2 = Columns[item2];
								}
								if (dataGridViewColumn3 == null || Columns.DisplayInOrder(dataGridViewColumn3.Index, item2))
								{
									dataGridViewColumn3 = Columns[item2];
								}
								num4 = firstRow;
								num5 = lastRow;
							}
						}
					}
				}
				else
				{
					DataGridViewColumn firstColumn = Columns.GetFirstColumn(DataGridViewElementStates.Visible);
					DataGridViewColumn lastColumn3 = Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);
					foreach (int item3 in (IEnumerable)SelectedBandIndexes)
					{
						if ((rows.GetRowState(item3) & DataGridViewElementStates.Visible) != DataGridViewElementStates.None)
						{
							if (item3 < num4)
							{
								num4 = item3;
							}
							if (item3 > num5)
							{
								num5 = item3;
							}
							dataGridViewColumn2 = firstColumn;
							dataGridViewColumn3 = lastColumn3;
						}
					}
				}
				foreach (DataGridViewCell item4 in (IEnumerable)individualSelectedCells)
				{
					if (item4.Visible)
					{
						if (item4.RowIndex < num4)
						{
							num4 = item4.RowIndex;
						}
						if (item4.RowIndex > num5)
						{
							num5 = item4.RowIndex;
						}
						if (dataGridViewColumn2 == null || Columns.DisplayInOrder(item4.ColumnIndex, dataGridViewColumn2.Index))
						{
							dataGridViewColumn2 = item4.OwningColumn;
						}
						if (dataGridViewColumn3 == null || Columns.DisplayInOrder(dataGridViewColumn3.Index, item4.ColumnIndex))
						{
							dataGridViewColumn3 = item4.OwningColumn;
						}
					}
				}
				foreach (string text4 in arrText)
				{
					if (stringBuilder == null)
					{
						stringBuilder = new StringBuilder(1024);
					}
					else
					{
						stringBuilder.Length = 0;
					}
					if (flag)
					{
						if (RightToLeftInternal)
						{
							DataGridViewColumn dataGridViewColumn = dataGridViewColumn3;
							while (dataGridViewColumn != null)
							{
								DataGridViewColumn previousColumn = ((dataGridViewColumn == dataGridViewColumn2) ? null : Columns.GetPreviousColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None));
								if (dataGridViewColumn.HeaderCell.GetClipboardContentInternal(-1, dataGridViewColumn == dataGridViewColumn3, !flag2 && previousColumn == null, blnInFirstRow: true, blnInLastRow: false, text4) is string value25)
								{
									stringBuilder.Append(value25);
								}
								dataGridViewColumn = previousColumn;
							}
							if (flag2 && TopLeftHeaderCell.GetClipboardContentInternal(-1, blnFirstCell: false, blnLastCell: true, blnInFirstRow: true, blnInLastRow: false, text4) is string value26)
							{
								stringBuilder.Append(value26);
							}
						}
						else
						{
							if (flag2 && TopLeftHeaderCell.GetClipboardContentInternal(-1, blnFirstCell: true, blnLastCell: false, blnInFirstRow: true, blnInLastRow: false, text4) is string value27)
							{
								stringBuilder.Append(value27);
							}
							DataGridViewColumn dataGridViewColumn = dataGridViewColumn2;
							while (dataGridViewColumn != null)
							{
								DataGridViewColumn nextColumn = ((dataGridViewColumn == dataGridViewColumn3) ? null : Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None));
								if (dataGridViewColumn.HeaderCell.GetClipboardContentInternal(-1, !flag2 && dataGridViewColumn == dataGridViewColumn2, nextColumn == null, blnInFirstRow: true, blnInLastRow: false, text4) is string value28)
								{
									stringBuilder.Append(value28);
								}
								dataGridViewColumn = nextColumn;
							}
						}
					}
					bool flag8 = true;
					int num8 = num4;
					int num9 = -1;
					while (num8 != -1)
					{
						num9 = ((num8 == num5) ? (-1) : rows.GetNextRow(num8, DataGridViewElementStates.Visible));
						if (RightToLeftInternal)
						{
							DataGridViewColumn dataGridViewColumn = dataGridViewColumn3;
							while (dataGridViewColumn != null)
							{
								DataGridViewColumn previousColumn = ((dataGridViewColumn == dataGridViewColumn2) ? null : Columns.GetPreviousColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None));
								if (rows.SharedRow(num8).Cells[dataGridViewColumn.Index].GetClipboardContentInternal(num8, dataGridViewColumn == dataGridViewColumn3, !flag2 && previousColumn == null, !flag && flag8, num9 == -1, text4) is string value29)
								{
									stringBuilder.Append(value29);
								}
								dataGridViewColumn = previousColumn;
							}
							if (flag2 && rows.SharedRow(num8).HeaderCell.GetClipboardContentInternal(num8, blnFirstCell: false, blnLastCell: true, !flag && flag8, num9 == -1, text4) is string value30)
							{
								stringBuilder.Append(value30);
							}
						}
						else
						{
							if (flag2 && rows.SharedRow(num8).HeaderCell.GetClipboardContentInternal(num8, blnFirstCell: true, blnLastCell: false, !flag && flag8, num9 == -1, text4) is string value31)
							{
								stringBuilder.Append(value31);
							}
							DataGridViewColumn dataGridViewColumn = dataGridViewColumn2;
							while (dataGridViewColumn != null)
							{
								DataGridViewColumn nextColumn = ((dataGridViewColumn == dataGridViewColumn3) ? null : Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None));
								if (rows.SharedRow(num8).Cells[dataGridViewColumn.Index].GetClipboardContentInternal(num8, !flag2 && dataGridViewColumn == dataGridViewColumn2, nextColumn == null, !flag && flag8, num9 == -1, text4) is string value32)
								{
									stringBuilder.Append(value32);
								}
								dataGridViewColumn = nextColumn;
							}
						}
						num8 = num9;
						flag8 = false;
					}
					if (text4 == DataFormats.Html)
					{
						GetClipboardContentForHtml(stringBuilder);
					}
					dataObject.SetData(text4, blnAutoConvert: false, stringBuilder.ToString());
				}
				return dataObject;
			}
			case DataGridViewSelectionMode.FullRowSelect:
				if (rows.GetRowCount(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible) != 0)
				{
					if (ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableWithAutoHeaderText)
					{
						flag = rows.GetFirstRow(DataGridViewElementStates.Visible, DataGridViewElementStates.Selected) == -1;
						flag2 = true;
					}
					else
					{
						flag = (flag2 = ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText);
					}
					flag &= ColumnHeadersVisible;
					flag2 &= RowHeadersVisible;
					foreach (string text3 in arrText)
					{
						if (stringBuilder == null)
						{
							stringBuilder = new StringBuilder(1024);
						}
						else
						{
							stringBuilder.Length = 0;
						}
						if (flag)
						{
							if (RightToLeftInternal)
							{
								DataGridViewColumn dataGridViewColumn = Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);
								if (dataGridViewColumn != null)
								{
									DataGridViewColumn previousColumn = Columns.GetPreviousColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
									if (dataGridViewColumn.HeaderCell.GetClipboardContentInternal(-1, blnFirstCell: true, !flag2 && previousColumn == null, blnInFirstRow: true, blnInLastRow: false, text3) is string value13)
									{
										stringBuilder.Append(value13);
									}
									while (previousColumn != null)
									{
										dataGridViewColumn = previousColumn;
										previousColumn = Columns.GetPreviousColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
										if (dataGridViewColumn.HeaderCell.GetClipboardContentInternal(-1, blnFirstCell: false, !flag2 && previousColumn == null, blnInFirstRow: true, blnInLastRow: false, text3) is string value14)
										{
											stringBuilder.Append(value14);
										}
									}
								}
								if (flag2 && TopLeftHeaderCell.GetClipboardContentInternal(-1, Columns.GetColumnCount(DataGridViewElementStates.Visible) == 0, blnLastCell: true, blnInFirstRow: true, blnInLastRow: false, text3) is string value15)
								{
									stringBuilder.Append(value15);
								}
							}
							else
							{
								if (flag2 && TopLeftHeaderCell.GetClipboardContentInternal(-1, blnFirstCell: true, Columns.GetColumnCount(DataGridViewElementStates.Visible) == 0, blnInFirstRow: true, blnInLastRow: false, text3) is string value16)
								{
									stringBuilder.Append(value16);
								}
								DataGridViewColumn dataGridViewColumn = Columns.GetFirstColumn(DataGridViewElementStates.Visible);
								if (dataGridViewColumn != null)
								{
									DataGridViewColumn nextColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
									if (dataGridViewColumn.HeaderCell.GetClipboardContentInternal(-1, !flag2, nextColumn == null, blnInFirstRow: true, blnInLastRow: false, text3) is string value17)
									{
										stringBuilder.Append(value17);
									}
									while (nextColumn != null)
									{
										dataGridViewColumn = nextColumn;
										nextColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
										if (dataGridViewColumn.HeaderCell.GetClipboardContentInternal(-1, blnFirstCell: false, nextColumn == null, blnInFirstRow: true, blnInLastRow: false, text3) is string value18)
										{
											stringBuilder.Append(value18);
										}
									}
								}
							}
						}
						bool flag4 = true;
						int num3 = rows.GetFirstRow(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible);
						int nextRow = rows.GetNextRow(num3, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible);
						while (num3 != -1)
						{
							if (RightToLeftInternal)
							{
								DataGridViewColumn dataGridViewColumn = Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.None);
								if (dataGridViewColumn != null)
								{
									DataGridViewColumn previousColumn = Columns.GetPreviousColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
									if (rows.SharedRow(num3).Cells[dataGridViewColumn.Index].GetClipboardContentInternal(num3, blnFirstCell: true, !flag2 && previousColumn == null, !flag && flag4, nextRow == -1, text3) is string value19)
									{
										stringBuilder.Append(value19);
									}
									while (previousColumn != null)
									{
										dataGridViewColumn = previousColumn;
										previousColumn = Columns.GetPreviousColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
										if (rows.SharedRow(num3).Cells[dataGridViewColumn.Index].GetClipboardContentInternal(num3, blnFirstCell: false, !flag2 && previousColumn == null, !flag && flag4, nextRow == -1, text3) is string value20)
										{
											stringBuilder.Append(value20);
										}
									}
								}
								if (flag2 && rows.SharedRow(num3).HeaderCell.GetClipboardContentInternal(num3, Columns.GetColumnCount(DataGridViewElementStates.Visible) == 0, blnLastCell: true, !flag && flag4, nextRow == -1, text3) is string value21)
								{
									stringBuilder.Append(value21);
								}
							}
							else
							{
								DataGridViewColumn dataGridViewColumn = Columns.GetFirstColumn(DataGridViewElementStates.Visible);
								if (flag2 && rows.SharedRow(num3).HeaderCell.GetClipboardContentInternal(num3, blnFirstCell: true, dataGridViewColumn == null, !flag && flag4, nextRow == -1, text3) is string value22)
								{
									stringBuilder.Append(value22);
								}
								if (dataGridViewColumn != null)
								{
									DataGridViewColumn nextColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
									if (rows.SharedRow(num3).Cells[dataGridViewColumn.Index].GetClipboardContentInternal(num3, !flag2, nextColumn == null, !flag && flag4, nextRow == -1, text3) is string value23)
									{
										stringBuilder.Append(value23);
									}
									while (nextColumn != null)
									{
										dataGridViewColumn = nextColumn;
										nextColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
										if (rows.SharedRow(num3).Cells[dataGridViewColumn.Index].GetClipboardContentInternal(num3, blnFirstCell: false, nextColumn == null, !flag && flag4, nextRow == -1, text3) is string value24)
										{
											stringBuilder.Append(value24);
										}
									}
								}
							}
							num3 = nextRow;
							if (num3 != -1)
							{
								nextRow = rows.GetNextRow(num3, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible);
							}
							flag4 = false;
						}
						if (text3 == DataFormats.Html)
						{
							GetClipboardContentForHtml(stringBuilder);
						}
						dataObject.SetData(text3, blnAutoConvert: false, stringBuilder.ToString());
					}
					return dataObject;
				}
				return null;
			case DataGridViewSelectionMode.FullColumnSelect:
				if (Columns.GetColumnCount(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible) != 0)
				{
					if (ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableWithAutoHeaderText)
					{
						flag = true;
						flag2 = Columns.GetFirstColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.Selected) == null;
					}
					else
					{
						flag = (flag2 = ClipboardCopyMode == DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText);
					}
					flag &= ColumnHeadersVisible;
					flag2 &= RowHeadersVisible;
					int firstRow = rows.GetFirstRow(DataGridViewElementStates.Visible);
					foreach (string text2 in arrText)
					{
						if (stringBuilder == null)
						{
							stringBuilder = new StringBuilder(1024);
						}
						else
						{
							stringBuilder.Length = 0;
						}
						if (flag)
						{
							if (RightToLeftInternal)
							{
								DataGridViewColumn lastColumn = Columns.GetLastColumn(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
								DataGridViewColumn dataGridViewColumn = lastColumn;
								if (dataGridViewColumn != null)
								{
									DataGridViewColumn previousColumn = Columns.GetPreviousColumn(dataGridViewColumn, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
									if (dataGridViewColumn.HeaderCell.GetClipboardContentInternal(-1, blnFirstCell: true, !flag2 && previousColumn == null, blnInFirstRow: true, firstRow == -1, text2) is string value)
									{
										stringBuilder.Append(value);
									}
									while (previousColumn != null)
									{
										dataGridViewColumn = previousColumn;
										previousColumn = Columns.GetPreviousColumn(dataGridViewColumn, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
										if (dataGridViewColumn.HeaderCell.GetClipboardContentInternal(-1, blnFirstCell: false, !flag2 && previousColumn == null, blnInFirstRow: true, firstRow == -1, text2) is string value2)
										{
											stringBuilder.Append(value2);
										}
									}
								}
								if (flag2 && TopLeftHeaderCell.GetClipboardContentInternal(-1, lastColumn == null, blnLastCell: true, blnInFirstRow: true, firstRow == -1, text2) is string value3)
								{
									stringBuilder.Append(value3);
								}
							}
							else
							{
								DataGridViewColumn dataGridViewColumn = Columns.GetFirstColumn(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible);
								if (flag2 && TopLeftHeaderCell.GetClipboardContentInternal(-1, blnFirstCell: true, dataGridViewColumn == null, blnInFirstRow: true, firstRow == -1, text2) is string value4)
								{
									stringBuilder.Append(value4);
								}
								if (dataGridViewColumn != null)
								{
									DataGridViewColumn nextColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
									if (dataGridViewColumn.HeaderCell.GetClipboardContentInternal(-1, !flag2, nextColumn == null, blnInFirstRow: true, firstRow == -1, text2) is string value5)
									{
										stringBuilder.Append(value5);
									}
									while (nextColumn != null)
									{
										dataGridViewColumn = nextColumn;
										nextColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
										if (dataGridViewColumn.HeaderCell.GetClipboardContentInternal(-1, blnFirstCell: false, nextColumn == null, blnInFirstRow: true, firstRow == -1, text2) is string value6)
										{
											stringBuilder.Append(value6);
										}
									}
								}
							}
						}
						bool flag3 = true;
						int num = firstRow;
						int num2 = -1;
						if (num != -1)
						{
							num2 = rows.GetNextRow(num, DataGridViewElementStates.Visible);
						}
						while (num != -1)
						{
							if (RightToLeftInternal)
							{
								DataGridViewColumn lastColumn2 = Columns.GetLastColumn(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
								DataGridViewColumn dataGridViewColumn = lastColumn2;
								if (dataGridViewColumn != null)
								{
									DataGridViewColumn previousColumn = Columns.GetPreviousColumn(dataGridViewColumn, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
									if (rows.SharedRow(num).Cells[dataGridViewColumn.Index].GetClipboardContentInternal(num, blnFirstCell: true, !flag2 && previousColumn == null, !flag && flag3, num2 == -1, text2) is string value7)
									{
										stringBuilder.Append(value7);
									}
									while (previousColumn != null)
									{
										dataGridViewColumn = previousColumn;
										previousColumn = Columns.GetPreviousColumn(dataGridViewColumn, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
										if (rows.SharedRow(num).Cells[dataGridViewColumn.Index].GetClipboardContentInternal(num, blnFirstCell: false, !flag2 && previousColumn == null, !flag && flag3, num2 == -1, text2) is string value8)
										{
											stringBuilder.Append(value8);
										}
									}
								}
								if (flag2 && rows.SharedRow(num).HeaderCell.GetClipboardContentInternal(num, lastColumn2 == null, blnLastCell: true, !flag && flag3, num2 == -1, text2) is string value9)
								{
									stringBuilder.Append(value9);
								}
							}
							else
							{
								DataGridViewColumn dataGridViewColumn = Columns.GetFirstColumn(DataGridViewElementStates.Selected | DataGridViewElementStates.Visible);
								if (flag2 && rows.SharedRow(num).HeaderCell.GetClipboardContentInternal(num, blnFirstCell: true, dataGridViewColumn == null, !flag && flag3, num2 == -1, text2) is string value10)
								{
									stringBuilder.Append(value10);
								}
								if (dataGridViewColumn != null)
								{
									DataGridViewColumn nextColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
									if (rows.SharedRow(num).Cells[dataGridViewColumn.Index].GetClipboardContentInternal(num, !flag2, nextColumn == null, !flag && flag3, num2 == -1, text2) is string value11)
									{
										stringBuilder.Append(value11);
									}
									while (nextColumn != null)
									{
										dataGridViewColumn = nextColumn;
										nextColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Selected | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
										if (rows.SharedRow(num).Cells[dataGridViewColumn.Index].GetClipboardContentInternal(num, blnFirstCell: false, nextColumn == null, !flag && flag3, num2 == -1, text2) is string value12)
										{
											stringBuilder.Append(value12);
										}
									}
								}
							}
							num = num2;
							if (num != -1)
							{
								num2 = rows.GetNextRow(num, DataGridViewElementStates.Visible);
							}
							flag3 = false;
						}
						if (text2 == DataFormats.Html)
						{
							GetClipboardContentForHtml(stringBuilder);
						}
						dataObject.SetData(text2, blnAutoConvert: false, stringBuilder.ToString());
					}
					return dataObject;
				}
				return null;
			default:
				return dataObject;
			}
		}

		private static void GetClipboardContentForHtml(StringBuilder sbContent)
		{
			int num = 135 + sbContent.Length;
			int num2 = num + 36;
			string value = string.Format(CultureInfo.InvariantCulture, "Version:1.0\r\nStartHTML:00000097\r\nEndHTML:{0}\r\nStartFragment:00000133\r\nEndFragment:{1}\r\n", new object[2]
			{
				num2.ToString("00000000", CultureInfo.InvariantCulture),
				num.ToString("00000000", CultureInfo.InvariantCulture)
			}) + "\r\n\r\n<!--StartFragment-->";
			sbContent.Insert(0, value);
			sbContent.Append("\r\n<!--EndFragment-->\r\n</BODY>\r\n</HTML>");
		}

		/// Notifies the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that the current cell has uncommitted changes.</summary>
		/// <param name="blnDirty">true to indicate the cell has uncommitted changes; otherwise, false. </param>
		/// 1</filterpriority>
		public virtual void NotifyCurrentCellDirty(bool blnDirty)
		{
			NotifyCurrentCellDirty(blnDirty, blnClientSource: false);
		}

		/// 
		/// Notifies the current cell dirty.
		/// </summary>
		/// <param name="blnDirty">if set to true</c> [BLN dirty].</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		internal void NotifyCurrentCellDirty(bool blnDirty, bool blnClientSource)
		{
			if (!mobjDataGridViewState1[512])
			{
				SetIsCurrentCellDirtyInternal(blnDirty, blnClientSource);
			}
		}

		/// Invalidates the specified cell of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>, forcing it to be repainted.</summary>
		/// <param name="objDataGridViewCell">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to invalidate. </param>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewCell is null.</exception>
		/// <exception cref="T:System.ArgumentException">dataGridViewCell does not belong to the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </exception>
		/// 1</filterpriority>
		public void InvalidateCell(DataGridViewCell objDataGridViewCell)
		{
			objDataGridViewCell?.Update();
		}

		/// Invalidates the cell with the specified row and column indexes, forcing it to be repainted.</summary>
		/// <param name="intColumnIndex">The column index of the cell to invalidate.</param>
		/// <param name="intRowIndex">The row index of the cell to invalidate. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1 or greater than the number of columns in the control minus 1.-or-rowIndex is less than -1 or greater than the number of rows in the control minus 1. </exception>
		/// 1</filterpriority>
		public void InvalidateCell(int intColumnIndex, int intRowIndex)
		{
			if (intColumnIndex < -1 || intColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("columnIndex");
			}
			if (intRowIndex < -1 || intRowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			InvalidateCellPrivate(intColumnIndex, intRowIndex);
		}

		/// Invalidates the specified column of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>, forcing it to be repainted.</summary>
		/// <param name="intColumnIndex">The index of the column to invalidate. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is not in the valid range of 0 to the number of columns minus 1. </exception>
		/// 1</filterpriority>
		public void InvalidateColumn(int intColumnIndex)
		{
		}

		/// Invalidates the specified row of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>, forcing it to be repainted.</summary>
		/// <param name="intRowIndex">The index of the row to invalidate. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not in the valid range of 0 to the number of rows minus 1. </exception>
		/// 1</filterpriority>
		public void InvalidateRow(int intRowIndex)
		{
		}

		private void InvalidateRowHeights()
		{
			Rows.InvalidateCachedRowsHeights();
			if (base.IsHandleCreated)
			{
				PerformLayoutPrivate(blnInvalidInAdjustFillingColumns: false);
				Invalidate();
			}
		}

		/// 
		/// Performs the layout private.
		/// </summary>       
		/// <param name="blnInvalidInAdjustFillingColumns">if set to true</c> [invalid in adjust filling columns].</param>      
		private void PerformLayoutPrivate(bool blnInvalidInAdjustFillingColumns)
		{
			minPerformLayoutCount++;
			try
			{
				if (blnInvalidInAdjustFillingColumns && InAdjustFillingColumns)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterAutoFillColumnParameter"));
				}
				if (base.IsHandleCreated)
				{
					if (ComputeLayout() && minPerformLayoutCount < 3)
					{
						if ((AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode)2) != DataGridViewAutoSizeRowsMode.None)
						{
							AdjustShrinkingRows(AutoSizeRowsMode, blnFixedWidth: true, blnInternalAutosizing: true);
						}
						if (ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
						{
							AutoResizeColumnHeadersHeight(blnFixedRowHeadersWidth: true, blnFixedColumnsWidth: true);
						}
					}
					return;
				}
				DisplayedBandsInfo.FirstDisplayedFrozenCol = -1;
				DisplayedBandsInfo.FirstDisplayedFrozenRow = -1;
				DisplayedBandsInfo.FirstDisplayedScrollingRow = -1;
				DisplayedBandsInfo.FirstDisplayedScrollingCol = -1;
				DisplayedBandsInfo.NumDisplayedFrozenRows = 0;
				DisplayedBandsInfo.NumDisplayedFrozenCols = 0;
				DisplayedBandsInfo.NumDisplayedScrollingRows = 0;
				DisplayedBandsInfo.NumDisplayedScrollingCols = 0;
				DisplayedBandsInfo.NumTotallyDisplayedFrozenRows = 0;
				DisplayedBandsInfo.NumTotallyDisplayedScrollingRows = 0;
				DisplayedBandsInfo.LastDisplayedScrollingRow = -1;
				DisplayedBandsInfo.LastTotallyDisplayedScrollingCol = -1;
				if (LayoutInfo != null)
				{
					LayoutInfo.dirty = true;
				}
			}
			finally
			{
				minPerformLayoutCount--;
			}
		}

		/// 
		/// Computes the layout.
		/// </summary>
		/// </returns>
		private bool ComputeLayout()
		{
			LayoutData layoutData = new LayoutData(mobjLayoutInfo);
			Rectangle resizeBoxRect = mobjLayoutInfo.ResizeBoxRect;
			if (this is HierarchicDataGridView { ContainingRow: var containingRow })
			{
				DataGridView dataGridView = containingRow.DataGridView;
				if (dataGridView != null)
				{
					int num = 0;
					VisualTemplate = dataGridView.VisualTemplate;
					if (dataGridView.ExpansionIndicator != ShowExpansionIndicator.Never && dataGridView.Skin is DataGridViewSkin dataGridViewSkin)
					{
						num = dataGridViewSkin.ExpandCollapseColumnWidth;
					}
					for (DataGridViewColumn dataGridViewColumn = dataGridView.Columns.GetFirstColumn(DataGridViewElementStates.Visible); dataGridViewColumn != null; dataGridViewColumn = dataGridView.Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
					{
						num += dataGridViewColumn.Width;
					}
					layoutData.Inside = new Rectangle(0, 0, num, base.Height);
				}
			}
			else if (mobjLayoutInfo.ClientRectangle.Width > 0 || mobjLayoutInfo.ClientRectangle.Height > 0)
			{
				layoutData.Inside = mobjLayoutInfo.ClientRectangle;
			}
			else
			{
				layoutData.Inside = base.ClientRectangle;
			}
			Rectangle inside = layoutData.Inside;
			int num2 = BorderWidth;
			inside.Inflate(-num2, -num2);
			if (inside.Height < 0)
			{
				inside.Height = 0;
			}
			if (inside.Width < 0)
			{
				inside.Width = 0;
			}
			Rectangle rectangle = inside;
			if (mobjLayoutInfo.ColumnHeadersVisible)
			{
				Rectangle columnHeaders = rectangle;
				columnHeaders.Height = Math.Min(mintColumnHeadersHeight, columnHeaders.Height);
				rectangle.Y += columnHeaders.Height;
				rectangle.Height -= columnHeaders.Height;
				layoutData.ColumnHeaders = columnHeaders;
			}
			else
			{
				layoutData.ColumnHeaders = Rectangle.Empty;
			}
			if (RowHeadersVisible)
			{
				Rectangle rowHeaders = rectangle;
				rowHeaders.Width = Math.Min(mintRowHeadersWidth, rowHeaders.Width);
				if (RightToLeftInternal)
				{
					rowHeaders.X += rectangle.Width - rowHeaders.Width;
				}
				else
				{
					rectangle.X += rowHeaders.Width;
				}
				rectangle.Width -= rowHeaders.Width;
				layoutData.RowHeaders = rowHeaders;
				if (mobjLayoutInfo.ColumnHeadersVisible)
				{
					Rectangle columnHeaders2 = layoutData.ColumnHeaders;
					Rectangle topLeftHeader = columnHeaders2;
					topLeftHeader.Width = Math.Min(mintRowHeadersWidth, topLeftHeader.Width);
					columnHeaders2.Width -= topLeftHeader.Width;
					if (RightToLeftInternal)
					{
						topLeftHeader.X += rectangle.Width;
					}
					else
					{
						columnHeaders2.X += topLeftHeader.Width;
					}
					layoutData.TopLeftHeader = topLeftHeader;
					layoutData.ColumnHeaders = columnHeaders2;
				}
				else
				{
					layoutData.TopLeftHeader = Rectangle.Empty;
				}
			}
			else
			{
				layoutData.RowHeaders = Rectangle.Empty;
				layoutData.TopLeftHeader = Rectangle.Empty;
			}
			if (SingleVerticalBorderAdded)
			{
				if (!RightToLeftInternal)
				{
					rectangle.X++;
				}
				if (rectangle.Width > 0)
				{
					rectangle.Width--;
				}
			}
			if (SingleHorizontalBorderAdded)
			{
				rectangle.Y++;
				if (rectangle.Height > 0)
				{
					rectangle.Height--;
				}
			}
			layoutData.Data = rectangle;
			layoutData.Inside = inside;
			mobjLayoutInfo = layoutData;
			mobjLayoutInfo.dirty = false;
			bool result = AdjustFillingColumns();
			mobjLayoutInfo = layoutData;
			return result;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AllowUserToAddRowsChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnAllowUserToAddRowsChanged(EventArgs e)
		{
			PushAllowUserToAddRows();
			this.AllowUserToAddRowsChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AllowUserToDeleteRowsChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnAllowUserToDeleteRowsChanged(EventArgs e)
		{
			this.AllowUserToDeleteRowsChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AllowUserToOrderColumnsChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnAllowUserToOrderColumnsChanged(EventArgs e)
		{
			this.AllowUserToOrderColumnsChanged?.Invoke(this, e);
		}

		internal void OnAutoSizeColumnModeChanged(DataGridViewColumn objDataGridViewColumn, DataGridViewAutoSizeColumnMode enmPreviousInheritedMode)
		{
			DataGridViewAutoSizeColumnModeEventArgs e = new DataGridViewAutoSizeColumnModeEventArgs(objDataGridViewColumn, enmPreviousInheritedMode);
			OnAutoSizeColumnModeChanged(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeColumnsChanged"></see> event. </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnAllowUserToResizeColumnsChanged(EventArgs e)
		{
			this.AllowUserToResizeColumnsChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeRowsChanged"></see> event. </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnAllowUserToResizeRowsChanged(EventArgs e)
		{
			this.AllowUserToResizeRowsChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AlternatingRowsDefaultCellStyleChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnAlternatingRowsDefaultCellStyleChanged(EventArgs e)
		{
			this.AlternatingRowsDefaultCellStyleChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoGenerateColumnsChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnAutoGenerateColumnsChanged(EventArgs e)
		{
			if (AutoGenerateColumns && DataSource != null)
			{
				RefreshColumnsAndRows();
			}
			this.AutoGenerateColumnsChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeColumnModeChanged"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnModeEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnModeEventArgs.Column"></see> property of e is null.</exception>
		protected virtual void OnAutoSizeColumnModeChanged(DataGridViewAutoSizeColumnModeEventArgs e)
		{
			DataGridViewColumn column = e.Column;
			if (e.Column == null)
			{
				throw new InvalidOperationException(SR.GetString("InvalidNullArgument", "e.Column"));
			}
			DataGridViewAutoSizeColumnMode inheritedAutoSizeMode = column.InheritedAutoSizeMode;
			DataGridViewAutoSizeColumnMode previousMode = e.PreviousMode;
			bool flag = previousMode != DataGridViewAutoSizeColumnMode.Fill && previousMode != DataGridViewAutoSizeColumnMode.None && previousMode != DataGridViewAutoSizeColumnMode.NotSet;
			if (inheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill || previousMode == DataGridViewAutoSizeColumnMode.Fill)
			{
				mobjDataGridViewState2[67108864] = true;
			}
			bool flag2 = (AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode)2) == 0;
			switch (inheritedAutoSizeMode)
			{
			case DataGridViewAutoSizeColumnMode.None:
				if (column.Thickness != column.CachedThickness && flag)
				{
					column.ThicknessInternal = Math.Max(column.MinimumWidth, column.CachedThickness);
				}
				break;
			default:
				if (!flag)
				{
					column.CachedThickness = column.Thickness;
				}
				AutoResizeColumnInternal(column.Index, (DataGridViewAutoSizeColumnCriteriaInternal)inheritedAutoSizeMode, flag2);
				break;
			case DataGridViewAutoSizeColumnMode.Fill:
				break;
			}
			PerformLayoutPrivate(blnInvalidInAdjustFillingColumns: true);
			if (!flag2)
			{
				AdjustShrinkingRows(AutoSizeRowsMode, blnFixedWidth: true, blnInternalAutosizing: true);
				if (ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
				{
					AutoResizeColumnHeadersHeight(column.Index, blnFixedRowHeadersWidth: true, blnFixedColumnWidth: true);
				}
				if (inheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.None && inheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.Fill)
				{
					AutoResizeColumnInternal(column.Index, (DataGridViewAutoSizeColumnCriteriaInternal)inheritedAutoSizeMode, blnFixedHeight: true);
				}
			}
			this.AutoSizeColumnModeChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeColumnsModeChanged"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsModeEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The number of entries in the array returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsModeEventArgs.PreviousModes"></see> property of e is not equal to the number of columns in the control.</exception>
		/// <exception cref="T:System.ArgumentNullException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsModeEventArgs.PreviousModes"></see> property of e is null.</exception>
		protected virtual void OnAutoSizeColumnsModeChanged(DataGridViewAutoSizeColumnsModeEventArgs e)
		{
			DataGridViewAutoSizeColumnMode[] previousModes = e.PreviousModes;
			if (previousModes == null)
			{
				throw new ArgumentNullException("e.PreviousModes");
			}
			if (previousModes.Length != Columns.Count)
			{
				throw new ArgumentException(SR.GetString("DataGridView_PreviousModesHasWrongLength"));
			}
			DataGridViewAutoSizeRowsMode autoSizeRowsMode = AutoSizeRowsMode;
			foreach (DataGridViewColumn column in Columns)
			{
				if (!column.Visible)
				{
					continue;
				}
				DataGridViewAutoSizeColumnMode inheritedAutoSizeMode = column.InheritedAutoSizeMode;
				DataGridViewAutoSizeColumnMode dataGridViewAutoSizeColumnMode = previousModes[column.Index];
				bool flag = dataGridViewAutoSizeColumnMode != DataGridViewAutoSizeColumnMode.Fill && dataGridViewAutoSizeColumnMode != DataGridViewAutoSizeColumnMode.None && dataGridViewAutoSizeColumnMode != DataGridViewAutoSizeColumnMode.NotSet;
				if (inheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill || dataGridViewAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.Fill)
				{
					mobjDataGridViewState2[67108864] = true;
				}
				switch (inheritedAutoSizeMode)
				{
				case DataGridViewAutoSizeColumnMode.None:
					if (column.Thickness != column.CachedThickness && flag)
					{
						column.ThicknessInternal = Math.Max(column.MinimumWidth, column.CachedThickness);
					}
					continue;
				case DataGridViewAutoSizeColumnMode.Fill:
					continue;
				}
				if (!flag)
				{
					column.CachedThickness = column.Thickness;
				}
				AutoResizeColumnInternal(column.Index, (DataGridViewAutoSizeColumnCriteriaInternal)inheritedAutoSizeMode, (autoSizeRowsMode & (DataGridViewAutoSizeRowsMode)2) == 0);
			}
			PerformLayoutPrivate(blnInvalidInAdjustFillingColumns: true);
			if ((autoSizeRowsMode & (DataGridViewAutoSizeRowsMode)2) != DataGridViewAutoSizeRowsMode.None)
			{
				AdjustShrinkingRows(autoSizeRowsMode, blnFixedWidth: true, blnInternalAutosizing: true);
				if (ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
				{
					AutoResizeColumnHeadersHeight(blnFixedRowHeadersWidth: true, blnFixedColumnsWidth: true);
				}
				foreach (DataGridViewColumn column2 in Columns)
				{
					DataGridViewAutoSizeColumnMode inheritedAutoSizeMode2 = column2.InheritedAutoSizeMode;
					if (inheritedAutoSizeMode2 != DataGridViewAutoSizeColumnMode.None && inheritedAutoSizeMode2 != DataGridViewAutoSizeColumnMode.Fill)
					{
						AutoResizeColumnInternal(column2.Index, (DataGridViewAutoSizeColumnCriteriaInternal)inheritedAutoSizeMode2, blnFixedHeight: true);
					}
				}
			}
			DataGridViewAutoSizeColumnsModeEventHandler dataGridViewAutoSizeColumnsModeEventHandler = this.AutoSizeColumnsModeChanged;
			if (dataGridViewAutoSizeColumnsModeEventHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				dataGridViewAutoSizeColumnsModeEventHandler(this, e);
			}
			Update();
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeRowsModeChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeModeEventArgs"></see> that contains the event data. </param>
		protected virtual void OnAutoSizeRowsModeChanged(DataGridViewAutoSizeModeEventArgs e)
		{
			this.AutoSizeRowsModeChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.BackgroundColorChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnBackgroundColorChanged(EventArgs e)
		{
			this.BackgroundColorChanged?.Invoke(this, e);
		}

		internal string OnCellToolTipTextNeeded(int intColumnIndex, int intRowIndex, string strToolTipText)
		{
			DataGridViewCellToolTipTextNeededEventArgs e = new DataGridViewCellToolTipTextNeededEventArgs(intColumnIndex, intRowIndex, strToolTipText);
			OnCellToolTipTextNeeded(e);
			return e.ToolTipText;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.BindingContextChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected override void OnBindingContextChanged(EventArgs e)
		{
			if (mobjDataGridViewState2[16777216])
			{
				return;
			}
			mobjDataGridViewState2[16777216] = true;
			try
			{
				if (DataConnection != null)
				{
					CurrentCell = null;
					try
					{
						DataConnection.SetDataConnection(DataSource, DataMember);
					}
					catch (ArgumentException)
					{
						if (base.DesignMode)
						{
							DataMember = string.Empty;
							RefreshColumnsAndRows();
							return;
						}
						throw;
					}
					RefreshColumnsAndRows();
					base.OnBindingContextChanged(e);
					if (DataConnection.CurrencyManager != null)
					{
						OnDataBindingComplete(ListChangedType.Reset);
					}
				}
				else
				{
					base.OnBindingContextChanged(e);
				}
			}
			finally
			{
				mobjDataGridViewState2[16777216] = false;
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.BorderStyleChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnBorderStyleChanged(EventArgs e)
		{
			this.BorderStyleChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CancelRowEdit"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.QuestionEventArgs"></see> that contains the event data. </param>
		protected virtual void OnCancelRowEdit(QuestionEventArgs e)
		{
			this.CancelRowEdit?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellBeginEdit"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCancelEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellCancelEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellCancelEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected internal virtual void OnCellBeginEdit(DataGridViewCellCancelEventArgs e)
		{
			if (e.ColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("e.ColumnIndex");
			}
			if (e.RowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("e.RowIndex");
			}
			if (GetHandler(EVENT_DATAGRIDVIEWCELLBEGINEDIT) is DataGridViewCellCancelEventHandler dataGridViewCellCancelEventHandler)
			{
				dataGridViewCellCancelEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.CellEndEdit"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected internal virtual void OnCellEndEdit(DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("e.ColumnIndex");
			}
			if (e.RowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("e.RowIndex");
			}
			if (GetHandler(EVENT_DATAGRIDVIEWCELLENDEDIT) is DataGridViewCellEventHandler dataGridViewCellEventHandler)
			{
				dataGridViewCellEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellBorderStyleChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnCellBorderStyleChanged(EventArgs e)
		{
			this.CellBorderStyleChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellErrorTextChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is less than -1 or greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is less than -1 or greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellErrorTextChanged(DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("e.ColumnIndex");
			}
			if (e.RowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("e.RowIndex");
			}
			UpdateCellErrorText(e.ColumnIndex, e.RowIndex);
			DataGridViewCellEventHandler dataGridViewCellEventHandler = this.CellErrorTextChanged;
			if (dataGridViewCellEventHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				dataGridViewCellEventHandler(this, e);
			}
		}

		internal void OnCellErrorTextChanged(DataGridViewCell objDataGridViewCell)
		{
			DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(objDataGridViewCell);
			OnCellErrorTextChanged(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellErrorTextNeeded"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellErrorTextNeededEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellErrorTextNeededEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellErrorTextNeededEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellErrorTextNeeded(DataGridViewCellErrorTextNeededEventArgs e)
		{
			if (e.ColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("e.ColumnIndex");
			}
			if (e.RowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("e.RowIndex");
			}
			DataGridViewCellErrorTextNeededEventHandler dataGridViewCellErrorTextNeededEventHandler = this.CellErrorTextNeeded;
			if (dataGridViewCellErrorTextNeededEventHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				dataGridViewCellErrorTextNeededEventHandler(this, e);
			}
		}

		internal string OnCellErrorTextNeeded(int intColumnIndex, int intRowIndex, string strErrorText)
		{
			DataGridViewCellErrorTextNeededEventArgs e = new DataGridViewCellErrorTextNeededEventArgs(intColumnIndex, intRowIndex, strErrorText);
			OnCellErrorTextNeeded(e);
			return e.ErrorText;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellFormatting"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
		{
			if (e.ColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("e.ColumnIndex");
			}
			if (e.RowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("e.RowIndex");
			}
			DataGridViewCellFormattingEventHandler dataGridViewCellFormattingEventHandler = this.CellFormatting;
			if (dataGridViewCellFormattingEventHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				dataGridViewCellFormattingEventHandler(this, e);
			}
		}

		internal virtual DataGridViewCellFormattingEventArgs OnCellFormatting(int intColumnIndex, int intRowIndex, object objValue, Type objFormattedValueType, DataGridViewCellStyle objCellStyle)
		{
			DataGridViewCellFormattingEventArgs e = new DataGridViewCellFormattingEventArgs(intColumnIndex, intRowIndex, objValue, objFormattedValueType, objCellStyle);
			OnCellFormatting(e);
			return e;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellParsing"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellParsingEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellParsingEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellParsingEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		internal virtual void OnCellParsing(DataGridViewCellParsingEventArgs e)
		{
			if (e.ColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("e.ColumnIndex");
			}
			if (e.RowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("e.RowIndex");
			}
			this.CellParsing?.Invoke(this, e);
		}

		/// 
		/// Called when [cell parsing].
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="objFormattedValue">The formatted value.</param>
		/// <param name="objValueType">Type of the value.</param>
		/// <param name="objCellStyle">The cell style.</param>
		/// </returns>
		internal DataGridViewCellParsingEventArgs OnCellParsing(int intRowIndex, int intColumnIndex, object objFormattedValue, Type objValueType, DataGridViewCellStyle objCellStyle)
		{
			DataGridViewCellParsingEventArgs e = new DataGridViewCellParsingEventArgs(intRowIndex, intColumnIndex, objFormattedValue, objValueType, objCellStyle);
			OnCellParsing(e);
			return e;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellStateChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStateChangedEventArgs"></see> that contains the event data. </param>
		protected virtual void OnCellStateChanged(DataGridViewCellStateChangedEventArgs e)
		{
			DataGridViewCell cell = e.Cell;
			if (e.StateChanged == DataGridViewElementStates.Selected && BulkPaintCount == 0 && (cell.ClientState | DataGridViewElementClientStates.Selected) != DataGridViewElementClientStates.Selected)
			{
				InvalidateCellPrivate(cell);
			}
			DataGridViewCellStateChangedEventHandler dataGridViewCellStateChangedEventHandler = this.CellStateChanged;
			if (dataGridViewCellStateChangedEventHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				dataGridViewCellStateChangedEventHandler(this, e);
			}
			if (e.StateChanged == DataGridViewElementStates.ReadOnly && mobjCurrentCellPoint.X == cell.ColumnIndex && mobjCurrentCellPoint.Y == cell.RowIndex && cell.RowIndex > -1 && !mobjDataGridViewOper[16384] && !cell.ReadOnly && ColumnEditable(mobjCurrentCellPoint.X) && !IsCurrentCellInEditMode && (EditMode == DataGridViewEditMode.EditOnEnter || (EditMode != DataGridViewEditMode.EditProgrammatically && CurrentCellInternal.EditType == null)))
			{
				BeginEditInternal(blnSelectAll: true);
			}
		}

		private void CorrectRowFrozenStates(DataGridViewRow objDataGridViewRow, int intRowIndex, bool blnFrozenStateChanging)
		{
			DataGridViewRowCollection rows = Rows;
			int num;
			if (((rows.GetRowState(intRowIndex) & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None && !blnFrozenStateChanging) || ((rows.GetRowState(intRowIndex) & DataGridViewElementStates.Frozen) == 0 && blnFrozenStateChanging))
			{
				num = rows.GetPreviousRow(intRowIndex, DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
				if (num == -1)
				{
					int firstRow = rows.GetFirstRow(DataGridViewElementStates.Visible);
					if (firstRow != intRowIndex)
					{
						num = firstRow;
					}
				}
				while (num != -1 && num < intRowIndex)
				{
					rows.SetRowState(num, DataGridViewElementStates.Frozen, blnValue: true);
					num = rows.GetNextRow(num, DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen);
				}
				return;
			}
			num = rows.GetNextRow(intRowIndex, DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen);
			if (num == -1)
			{
				int num2 = intRowIndex;
				do
				{
					num = rows.GetNextRow(num2, DataGridViewElementStates.Visible);
					if (num != -1)
					{
						num2 = num;
					}
				}
				while (num != -1);
				if (num2 != intRowIndex)
				{
					num = num2;
				}
			}
			while (num != -1 && num > intRowIndex)
			{
				rows.SetRowState(num, DataGridViewElementStates.Frozen, blnValue: false);
				num = rows.GetPreviousRow(num, DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
			}
		}

		private void CorrectColumnFrozenStates(DataGridViewColumn objDataGridViewColumn, bool blnFrozenStateChanging)
		{
			DataGridViewColumn dataGridViewColumn;
			if ((!objDataGridViewColumn.Frozen || blnFrozenStateChanging) && (objDataGridViewColumn.Frozen || !blnFrozenStateChanging))
			{
				dataGridViewColumn = Columns.GetNextColumn(objDataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen);
				if (dataGridViewColumn == null)
				{
					DataGridViewColumn dataGridViewColumn2 = objDataGridViewColumn;
					do
					{
						dataGridViewColumn = Columns.GetNextColumn(dataGridViewColumn2, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
						if (dataGridViewColumn != null)
						{
							dataGridViewColumn2 = dataGridViewColumn;
						}
					}
					while (dataGridViewColumn != null);
					if (dataGridViewColumn2 != objDataGridViewColumn)
					{
						dataGridViewColumn = dataGridViewColumn2;
					}
				}
				while (dataGridViewColumn != null && Columns.DisplayInOrder(objDataGridViewColumn.Index, dataGridViewColumn.Index))
				{
					dataGridViewColumn.Frozen = false;
					dataGridViewColumn = Columns.GetPreviousColumn(dataGridViewColumn, DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
				}
				return;
			}
			dataGridViewColumn = Columns.GetPreviousColumn(objDataGridViewColumn, DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible, DataGridViewElementStates.None);
			if (dataGridViewColumn == null)
			{
				DataGridViewColumn firstColumn = Columns.GetFirstColumn(DataGridViewElementStates.Visible);
				if (firstColumn != objDataGridViewColumn)
				{
					dataGridViewColumn = firstColumn;
				}
			}
			while (dataGridViewColumn != null && Columns.DisplayInOrder(dataGridViewColumn.Index, objDataGridViewColumn.Index))
			{
				dataGridViewColumn.Frozen = true;
				dataGridViewColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen);
			}
		}

		internal void OnDataGridViewElementStateChanging(DataGridViewElement objElement, int index, DataGridViewElementStates elementState)
		{
			if (objElement is DataGridViewColumn dataGridViewColumn)
			{
				switch (elementState)
				{
				case DataGridViewElementStates.Frozen:
				case DataGridViewElementStates.Visible:
					if (elementState == DataGridViewElementStates.Visible)
					{
						if (!dataGridViewColumn.Visible && dataGridViewColumn.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.ColumnHeader && !ColumnHeadersVisible)
						{
							throw new InvalidOperationException("DataGridView_CannotMakeAutoSizedColumnVisible");
						}
						if (!dataGridViewColumn.Visible && dataGridViewColumn.Frozen && dataGridViewColumn.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
						{
							dataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
						}
						else if (dataGridViewColumn.Visible && mobjCurrentCellPoint.X == dataGridViewColumn.Index)
						{
							ResetCurrentCell();
						}
					}
					if (elementState == DataGridViewElementStates.Frozen && !dataGridViewColumn.Frozen && dataGridViewColumn.Visible && dataGridViewColumn.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
					{
						dataGridViewColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
					}
					CorrectColumnFrozenStates(dataGridViewColumn, elementState == DataGridViewElementStates.Frozen);
					break;
				case DataGridViewElementStates.ReadOnly:
					if (mobjCurrentCellPoint.X == dataGridViewColumn.Index && IsCurrentCellInEditMode && !dataGridViewColumn.ReadOnly && !mobjDataGridViewOper[16384] && !EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.Parsing, DataGridViewValidateCellInternal.Always, blnFireCellLeave: false, blnFireCellEnter: false, blnFireRowLeave: false, blnFireRowEnter: false, blnFireLeave: false, blnKeepFocus: true, blnResetCurrentCell: false, blnResetAnchorCell: false))
					{
						throw new InvalidOperationException("DataGridView_CommitFailedCannotCompleteOperation");
					}
					break;
				}
			}
			else if (objElement is DataGridViewRow dataGridViewRow)
			{
				int num = ((dataGridViewRow.Index > -1) ? dataGridViewRow.Index : index);
				switch (elementState)
				{
				case DataGridViewElementStates.Frozen:
				case DataGridViewElementStates.Visible:
					if (elementState == DataGridViewElementStates.Visible && mobjCurrentCellPoint.Y == num)
					{
						if (DataSource != null && GroupingColumns.Count == 0)
						{
							throw new InvalidOperationException("DataGridView_CurrencyManagerRowCannotBeInvisible");
						}
						ResetCurrentCell();
					}
					CorrectRowFrozenStates(dataGridViewRow, num, elementState == DataGridViewElementStates.Frozen);
					break;
				case DataGridViewElementStates.ReadOnly:
					if (mobjCurrentCellPoint.Y == num && (Rows.GetRowState(num) & DataGridViewElementStates.ReadOnly) == 0 && !ReadOnly && IsCurrentCellInEditMode && !mobjDataGridViewOper[16384] && !EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.Parsing, DataGridViewValidateCellInternal.Always, blnFireCellLeave: false, blnFireCellEnter: false, blnFireRowLeave: false, blnFireRowEnter: false, blnFireLeave: false, blnKeepFocus: true, blnResetCurrentCell: false, blnResetAnchorCell: false))
					{
						throw new InvalidOperationException("DataGridView_CommitFailedCannotCompleteOperation");
					}
					break;
				}
			}
			else if (objElement is DataGridViewCell dataGridViewCell)
			{
				if (elementState == DataGridViewElementStates.ReadOnly && mobjCurrentCellPoint.X == dataGridViewCell.ColumnIndex && mobjCurrentCellPoint.Y == dataGridViewCell.RowIndex && IsCurrentCellInEditMode && !dataGridViewCell.ReadOnly && !mobjDataGridViewOper[16384] && !EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.Parsing, DataGridViewValidateCellInternal.Always, blnFireCellLeave: false, blnFireCellEnter: false, blnFireRowLeave: false, blnFireRowEnter: false, blnFireLeave: false, blnKeepFocus: true, blnResetCurrentCell: false, blnResetAnchorCell: false))
				{
					throw new InvalidOperationException("DataGridView_CommitFailedCannotCompleteOperation");
				}
			}
		}

		internal void OnDataGridViewElementStateChanged(DataGridViewElement objElement, int index, DataGridViewElementStates elementState)
		{
			if (objElement is DataGridViewColumn objDataGridViewColumn)
			{
				DataGridViewColumnStateChangedEventArgs e = new DataGridViewColumnStateChangedEventArgs(objDataGridViewColumn, elementState);
				OnColumnStateChanged(e);
			}
			else
			{
				DataGridViewRow dataGridViewRow = objElement as DataGridViewRow;
				if (dataGridViewRow != null)
				{
					if (GetHandler(EVENT_DATAGRIDVIEWROWSTATECHANGED) is DataGridViewRowStateChangedEventHandler && dataGridViewRow.DataGridView != null && dataGridViewRow.Index == -1)
					{
						dataGridViewRow = Rows[index];
					}
					DataGridViewRowStateChangedEventArgs e2 = new DataGridViewRowStateChangedEventArgs(dataGridViewRow, elementState);
					OnRowStateChanged((dataGridViewRow.Index == -1) ? index : dataGridViewRow.Index, e2);
				}
				else if (objElement is DataGridViewCell objDataGridViewCell)
				{
					DataGridViewCellStateChangedEventArgs e3 = new DataGridViewCellStateChangedEventArgs(objDataGridViewCell, elementState);
					OnCellStateChanged(e3);
				}
			}
			if ((elementState & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected)
			{
				if (SelectionChangeCount > 0)
				{
					mobjDataGridViewState2[262144] = true;
				}
				else
				{
					OnSelectionChanged(EventArgs.Empty);
				}
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellStyleChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellStyleChanged(DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("e.ColumnIndex");
			}
			if (e.RowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("e.RowIndex");
			}
			DataGridViewCellEventHandler dataGridViewCellEventHandler = this.CellStyleChanged;
			if (dataGridViewCellEventHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				dataGridViewCellEventHandler(this, e);
			}
		}

		internal void OnCellStyleChanged(DataGridViewCell objDataGridViewCell)
		{
			DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(objDataGridViewCell);
			OnCellStyleChanged(e);
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.RowHeaderMouseClick"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains information about the mouse and the header cell that was clicked.</param>
		internal void OnRowHeaderMouseClickInternal(DataGridViewCellMouseEventArgs e)
		{
			OnRowHeaderMouseClick(e);
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.RowHeaderMouseClick"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains information about the mouse and the header cell that was clicked.</param>
		internal void OnCellEnterInternal(DataGridViewCellEventArgs e)
		{
			OnCellEnter(e);
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.RowHeaderMouseClick"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains information about the mouse and the header cell that was clicked.</param>
		internal void OnRowHeaderMouseDoubleClickInternal(DataGridViewCellMouseEventArgs e)
		{
			OnRowHeaderMouseDoubleClick(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellStyleContentChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyleContentChangedEventArgs"></see> that contains the event data. </param>
		protected virtual void OnCellStyleContentChanged(DataGridViewCellStyleContentChangedEventArgs e)
		{
			if ((e.CellStyleScope & DataGridViewCellStyleScopes.Cell) == DataGridViewCellStyleScopes.Cell && (e.CellStyleScope & DataGridViewCellStyleScopes.DataGridView) == 0 && e.ChangeAffectsPreferredSize)
			{
				OnGlobalAutoSize();
			}
			Invalidate();
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellToolTipTextChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains information about the cell.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellToolTipTextChanged(DataGridViewCellEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellToolTipTextNeeded"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellToolTipTextNeededEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellToolTipTextNeededEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellToolTipTextNeededEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellToolTipTextNeeded(DataGridViewCellToolTipTextNeededEventArgs e)
		{
			if (e.ColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("e.ColumnIndex");
			}
			if (e.RowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("e.RowIndex");
			}
			this.CellToolTipTextNeeded?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidated"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		internal virtual void OnCellValidated(DataGridViewCellEventArgs e)
		{
			this.CellValidated?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellValidatingEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellValidatingEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellValidatingEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		internal virtual void OnCellValidating(DataGridViewCellValidatingEventArgs e)
		{
			this.CellValidating?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValueChanged"></see> event.
		/// </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data.</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellValueChanged(DataGridViewCellEventArgs e, bool blnClientSource)
		{
			if (e.ColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("e.ColumnIndex");
			}
			if (e.RowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("e.RowIndex");
			}
			OnCellCommonChange(e.ColumnIndex, e.RowIndex, blnClientSource);
			if (IsHierarchic(HierarchicInfoSelector.Bounded))
			{
				HandleHierarchicValueChanged(e.ColumnIndex, e.RowIndex);
			}
			DataGridViewCellEventHandler dataGridViewCellEventHandler = this.CellValueChanged;
			if (dataGridViewCellEventHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				dataGridViewCellEventHandler(this, e);
			}
			if (ShowFilterRow && FilterRow != null && Columns[e.ColumnIndex].AllowRowFiltering)
			{
				(FilterRow.Cells[e.ColumnIndex] as DataGridViewFilterCell).UpdateFilterComboBox();
			}
		}

		/// 
		/// Handles the hierarchic value changed.
		/// </summary>
		/// <param name="intColumnIndex">Index of the int column.</param>
		/// <param name="intRowIndex">Index of the int row.</param>
		private void HandleHierarchicValueChanged(int intColumnIndex, int intRowIndex)
		{
			if (mobjRealFilteringDataMemberIndexByProposedFilteringDataMember != null && mobjRealFilteringDataMemberIndexByProposedFilteringDataMember.ContainsValue(Columns[intColumnIndex].Name))
			{
				DataGridViewRow dataGridViewRow = Rows[intRowIndex];
				bool expanded = dataGridViewRow.Expanded;
				dataGridViewRow.ResetChildGrid();
				if (expanded)
				{
					dataGridViewRow.Expanded = true;
				}
			}
		}

		internal void OnCellCommonChange(int intColumnIndex, int intRowIndex)
		{
			OnCellCommonChange(intColumnIndex, intRowIndex, blnClientSource: false);
		}

		private void OnRowHeaderGlobalAutoSize(int rowIndex)
		{
			if (!RowHeadersVisible)
			{
				return;
			}
			InvalidateCellPrivate(-1, rowIndex);
			if (AutoSizeCount <= 0)
			{
				bool flag = false;
				if (rowIndex != -1)
				{
					flag = (Rows.GetRowState(rowIndex) & DataGridViewElementStates.Displayed) != 0;
				}
				bool flag2 = rowIndex != -1 || ColumnHeadersHeightSizeMode != DataGridViewColumnHeadersHeightSizeMode.AutoSize;
				bool flag3 = rowIndex == -1 || (AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode)1) == 0 || ((AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode)8) != DataGridViewAutoSizeRowsMode.None && rowIndex != -1 && !flag);
				bool flag4 = false;
				if (RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders || (RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders && rowIndex != -1 && flag) || (RowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.EnableResizing && RowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.DisableResizing && rowIndex == -1) || (RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader && rowIndex != -1 && rowIndex == Rows.GetFirstRow(DataGridViewElementStates.Visible)))
				{
					AutoResizeRowHeadersWidth(rowIndex, RowHeadersWidthSizeMode, flag2, flag3);
					flag4 = true;
				}
				if (!flag2)
				{
					AutoResizeColumnHeadersHeight(-1, blnFixedRowHeadersWidth: true, blnFixedColumnWidth: true);
				}
				if (!flag3)
				{
					AutoResizeRowInternal(rowIndex, MapAutoSizeRowsModeToRowMode(AutoSizeRowsMode), blnFixedWidth: true, blnInternalAutosizing: true);
				}
				if (flag4 && (!flag2 || !flag3))
				{
					AutoResizeRowHeadersWidth(rowIndex, RowHeadersWidthSizeMode, blnFixedColumnHeadersHeight: true, blnFixedRowHeight: true);
				}
			}
		}

		private void OnColumnHeaderGlobalAutoSize(int columnIndex)
		{
			if (!ColumnHeadersVisible)
			{
				return;
			}
			InvalidateCellPrivate(columnIndex, -1);
			if (AutoSizeCount > 0)
			{
				return;
			}
			DataGridViewAutoSizeColumnCriteriaInternal inheritedAutoSizeMode = (DataGridViewAutoSizeColumnCriteriaInternal)Columns[columnIndex].InheritedAutoSizeMode;
			DataGridViewAutoSizeColumnCriteriaInternal dataGridViewAutoSizeColumnCriteriaInternal = inheritedAutoSizeMode & DataGridViewAutoSizeColumnCriteriaInternal.Header;
			bool flag = dataGridViewAutoSizeColumnCriteriaInternal == DataGridViewAutoSizeColumnCriteriaInternal.NotSet;
			if (ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
			{
				AutoResizeColumnHeadersHeight(columnIndex, blnFixedRowHeadersWidth: true, flag);
			}
			if (!flag)
			{
				bool flag2 = (AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode)2) == 0;
				AutoResizeColumnInternal(columnIndex, inheritedAutoSizeMode, flag2);
				if (!flag2)
				{
					AdjustShrinkingRows(AutoSizeRowsMode, blnFixedWidth: true, blnInternalAutosizing: true);
					AutoResizeColumnInternal(columnIndex, inheritedAutoSizeMode, blnFixedHeight: true);
				}
				if (ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
				{
					AutoResizeColumnHeadersHeight(columnIndex, blnFixedRowHeadersWidth: true, blnFixedColumnWidth: true);
				}
			}
		}

		private void OnCellCommonChange(int intColumnIndex, int intRowIndex, bool blnClientSource)
		{
			if (intColumnIndex == -1)
			{
				OnRowHeaderGlobalAutoSize(intRowIndex);
				return;
			}
			if (intRowIndex == -1)
			{
				OnColumnHeaderGlobalAutoSize(intColumnIndex);
				return;
			}
			DataGridViewAutoSizeRowsMode autoSizeRowsMode = AutoSizeRowsMode;
			if (!blnClientSource)
			{
				InvalidateCellPrivate(intColumnIndex, intRowIndex);
			}
			bool flag = false;
			if (intRowIndex != -1)
			{
				flag = (Rows.GetRowState(intRowIndex) & DataGridViewElementStates.Displayed) != 0;
			}
			DataGridViewAutoSizeColumnCriteriaInternal inheritedAutoSizeMode = (DataGridViewAutoSizeColumnCriteriaInternal)Columns[intColumnIndex].InheritedAutoSizeMode;
			bool flag2 = (inheritedAutoSizeMode & DataGridViewAutoSizeColumnCriteriaInternal.AllRows) != 0;
			if (flag)
			{
				flag2 = flag2 || (inheritedAutoSizeMode & DataGridViewAutoSizeColumnCriteriaInternal.DisplayedRows) != 0;
			}
			bool flag3 = (autoSizeRowsMode & (DataGridViewAutoSizeRowsMode)2) != 0;
			if (flag3)
			{
				AutoResizeRowInternal(intRowIndex, MapAutoSizeRowsModeToRowMode(autoSizeRowsMode), !flag2, blnInternalAutosizing: true);
			}
			if (flag2)
			{
				AutoResizeColumnInternal(intColumnIndex, inheritedAutoSizeMode, blnFixedHeight: true);
				if (flag3)
				{
					AutoResizeRowInternal(intRowIndex, MapAutoSizeRowsModeToRowMode(autoSizeRowsMode), blnFixedWidth: true, blnInternalAutosizing: true);
				}
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValueNeeded"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellValueEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellValueEventArgs.ColumnIndex"></see> property of e is less than zero or greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellValueEventArgs.RowIndex"></see> property of e is less than zero or greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellValueNeeded(DataGridViewCellValueEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.ColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("e.ColumnIndex");
			}
			if (e.RowIndex < 0 || e.RowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("e.RowIndex");
			}
			this.CellValueNeeded?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValuePushed"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellValueEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellValueEventArgs.ColumnIndex"></see> property of e is less than zero or greater than the number of columns in the control minus one.-or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellValueEventArgs.RowIndex"></see> property of e is less than zero or greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellValuePushed(DataGridViewCellValueEventArgs e)
		{
			if (e.ColumnIndex < 0 || e.ColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("e.ColumnIndex");
			}
			if (e.RowIndex < 0 || e.RowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("e.RowIndex");
			}
			this.CellValuePushed?.Invoke(this, e);
		}

		internal void OnCellValuePushed(int intColumnIndex, int intRowIndex, object objValue)
		{
			DataGridViewCellValueEventArgs cellValueEventArgs = CellValueEventArgs;
			cellValueEventArgs.SetProperties(intColumnIndex, intRowIndex, objValue);
			OnCellValuePushed(cellValueEventArgs);
		}

		internal object OnCellValueNeeded(int intColumnIndex, int intRowIndex)
		{
			DataGridViewCellValueEventArgs cellValueEventArgs = CellValueEventArgs;
			cellValueEventArgs.SetProperties(intColumnIndex, intRowIndex, null);
			OnCellValueNeeded(cellValueEventArgs);
			return cellValueEventArgs.Value;
		}

		internal void OnColumnCommonChange(int intColumnIndex)
		{
			OnColumnGlobalAutoSize(intColumnIndex);
		}

		/// 
		///
		/// </summary>
		/// <param name="intColumnIndex"></param>
		private void OnColumnGlobalAutoSize(int intColumnIndex)
		{
			if (!Columns[intColumnIndex].Visible)
			{
				return;
			}
			InvalidateColumnInternal(intColumnIndex);
			if (AutoSizeCount <= 0)
			{
				bool flag = (AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode)2) == 0;
				DataGridViewAutoSizeColumnCriteriaInternal inheritedAutoSizeMode = (DataGridViewAutoSizeColumnCriteriaInternal)Columns[intColumnIndex].InheritedAutoSizeMode;
				if (inheritedAutoSizeMode != DataGridViewAutoSizeColumnCriteriaInternal.None && inheritedAutoSizeMode != DataGridViewAutoSizeColumnCriteriaInternal.Fill)
				{
					AutoResizeColumnInternal(intColumnIndex, inheritedAutoSizeMode, flag);
				}
				if (ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
				{
					AutoResizeColumnHeadersHeight(intColumnIndex, blnFixedRowHeadersWidth: true, blnFixedColumnWidth: true);
				}
				if (!flag && inheritedAutoSizeMode != DataGridViewAutoSizeColumnCriteriaInternal.None && inheritedAutoSizeMode != DataGridViewAutoSizeColumnCriteriaInternal.Fill)
				{
					AutoResizeColumnInternal(intColumnIndex, inheritedAutoSizeMode, blnFixedHeight: true);
				}
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnAdded"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnColumnAdded(DataGridViewColumnEventArgs e)
		{
			if (e.Column.DataGridView != this)
			{
				throw new ArgumentException(SR.GetString("DataGridView_ColumnDoesNotBelongToDataGridView"));
			}
			DataGridViewColumnEventHandler dataGridViewColumnEventHandler = this.ColumnAdded;
			if (dataGridViewColumnEventHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				dataGridViewColumnEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnContextMenuStripChanged"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnColumnContextMenuStripChanged(DataGridViewColumnEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnDataPropertyNameChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnColumnDataPropertyNameChanged(DataGridViewColumnEventArgs e)
		{
			if (ShowFilterRow && mobjDataGridViewFilterRow != null && e.Column.AllowRowFiltering && mobjDataGridViewFilterRow.Cells.Count > e.Column.Index)
			{
				(mobjDataGridViewFilterRow.Cells[e.Column.Index] as DataGridViewFilterCell).RefreshFilterCell();
			}
			if (e.Column.DataGridView != this)
			{
				throw new ArgumentException(SR.GetString("DataGridView_ColumnDoesNotBelongToDataGridView"));
			}
			if (DataSource != null && e.Column.DataPropertyName.Length != 0 && !mobjDataGridViewOper[1024])
			{
				MapDataGridViewColumnToDataBoundField(e.Column);
			}
			else if (DataSource != null && e.Column.DataPropertyName.Length == 0 && e.Column.IsDataBound)
			{
				e.Column.IsDataBoundInternal = false;
				e.Column.BoundColumnIndex = -1;
				e.Column.BoundColumnConverter = null;
				InvalidateColumnInternal(e.Column.Index);
			}
			if (GetHandler(EVENT_DATAGRIDVIEWCOLUMNDATAPROPERTYNAMECHANGED) is DataGridViewColumnEventHandler dataGridViewColumnEventHandler && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				dataGridViewColumnEventHandler(this, e);
			}
		}

		/// 
		/// Corrects the column frozen states for move.
		/// </summary>
		/// <param name="objDataGridViewColumn">The data grid view column.</param>
		/// <param name="intNewDisplayIndex">New index of the display.</param>
		private void CorrectColumnFrozenStatesForMove(DataGridViewColumn objDataGridViewColumn, int intNewDisplayIndex)
		{
			if (!objDataGridViewColumn.Visible || (intNewDisplayIndex < objDataGridViewColumn.DisplayIndex && objDataGridViewColumn.Frozen) || (intNewDisplayIndex > objDataGridViewColumn.DisplayIndex && !objDataGridViewColumn.Frozen))
			{
				return;
			}
			int count = Columns.Count;
			if (intNewDisplayIndex < objDataGridViewColumn.DisplayIndex)
			{
				int num = intNewDisplayIndex;
				DataGridViewColumn columnAtDisplayIndex;
				do
				{
					columnAtDisplayIndex = Columns.GetColumnAtDisplayIndex(num);
					num++;
				}
				while (num < count && (columnAtDisplayIndex == null || columnAtDisplayIndex == objDataGridViewColumn || !columnAtDisplayIndex.Visible));
				if (columnAtDisplayIndex != null && columnAtDisplayIndex.Frozen)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CannotMoveNonFrozenColumn"));
				}
			}
			else
			{
				int num = intNewDisplayIndex;
				DataGridViewColumn columnAtDisplayIndex2;
				do
				{
					columnAtDisplayIndex2 = Columns.GetColumnAtDisplayIndex(num);
					num--;
				}
				while (num >= 0 && (columnAtDisplayIndex2 == null || !columnAtDisplayIndex2.Visible));
				if (columnAtDisplayIndex2 != null && !columnAtDisplayIndex2.Frozen)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CannotMoveFrozenColumn"));
				}
			}
		}

		/// 
		/// Called when [column display index changing].
		/// </summary>
		/// <param name="objDataGridViewColumn">The data grid view column.</param>
		/// <param name="intNewDisplayIndex">New index of the display.</param>
		internal void OnColumnDisplayIndexChanging(DataGridViewColumn objDataGridViewColumn, int intNewDisplayIndex)
		{
			if (mobjDataGridViewOper[2048])
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterDisplayIndexWithinAdjustments"));
			}
			CorrectColumnFrozenStatesForMove(objDataGridViewColumn, intNewDisplayIndex);
			try
			{
				mobjDataGridViewOper[2048] = true;
				if (intNewDisplayIndex < objDataGridViewColumn.DisplayIndex)
				{
					foreach (DataGridViewColumn column in Columns)
					{
						if (intNewDisplayIndex <= column.DisplayIndex && column.DisplayIndex < objDataGridViewColumn.DisplayIndex)
						{
							column.DisplayIndexInternal = column.DisplayIndex + 1;
							column.DisplayIndexHasChanged = true;
						}
					}
					return;
				}
				foreach (DataGridViewColumn column2 in Columns)
				{
					if (objDataGridViewColumn.DisplayIndex < column2.DisplayIndex && column2.DisplayIndex <= intNewDisplayIndex)
					{
						column2.DisplayIndexInternal = column2.DisplayIndex - 1;
						column2.DisplayIndexHasChanged = true;
					}
				}
			}
			finally
			{
				mobjDataGridViewOper[2048] = false;
			}
		}

		/// 
		/// Called when [column display index changed_ pre notification].
		/// </summary>
		internal void OnColumnDisplayIndexChanged_PreNotification()
		{
			Columns.InvalidateCachedColumnsOrder();
			PerformLayoutPrivate(blnInvalidInAdjustFillingColumns: true);
		}

		/// 
		/// Called when [column display index changed_ post notification].
		/// </summary>
		internal void OnColumnDisplayIndexChanged_PostNotification()
		{
			FlushDisplayIndexChanged(blnRaiseEvent: true);
		}

		internal void OnColumnDataPropertyNameChanged(DataGridViewColumn objDataGridViewColumn)
		{
			OnColumnDataPropertyNameChanged(new DataGridViewColumnEventArgs(objDataGridViewColumn));
		}

		internal void OnColumnNameChanged(DataGridViewColumn objDataGridViewColumn)
		{
			DataGridViewColumnEventArgs e = new DataGridViewColumnEventArgs(objDataGridViewColumn);
			OnColumnNameChanged(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnDefaultCellStyleChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnColumnDefaultCellStyleChanged(DataGridViewColumnEventArgs e)
		{
			DataGridViewColumnEventHandler dataGridViewColumnEventHandler = this.ColumnDefaultCellStyleChanged;
			if (dataGridViewColumnEventHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				dataGridViewColumnEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnDisplayIndexChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnColumnDisplayIndexChanged(DataGridViewColumnEventArgs e)
		{
			DataGridViewColumnEventHandler dataGridViewColumnEventHandler = this.ColumnDisplayIndexChanged;
			if (dataGridViewColumnEventHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				dataGridViewColumnEventHandler(this, e);
			}
		}

		/// 
		/// Called when [column display index changed].
		/// </summary>
		/// <param name="objDataGridViewColumn">The obj data grid view column.</param>
		internal void OnColumnDisplayIndexChanged(DataGridViewColumn objDataGridViewColumn)
		{
			Update();
			DataGridViewColumnEventArgs e = new DataGridViewColumnEventArgs(objDataGridViewColumn);
			OnColumnDisplayIndexChanged(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnDividerDoubleClick"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDividerDoubleClickEventArgs"></see> that contains the event data. </param>
		protected virtual void OnColumnDividerDoubleClick(DataGridViewColumnDividerDoubleClickEventArgs e)
		{
			ColumnDividerDoubleClickHandler?.Invoke(this, e);
		}

		/// 
		/// Raises the column divider double click.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDividerDoubleClickEventArgs" /> instance containing the event data.</param>
		internal void RaiseColumnDividerDoubleClick(DataGridViewColumnDividerDoubleClickEventArgs e)
		{
			OnColumnDividerDoubleClick(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnDividerWidthChanged"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnColumnDividerWidthChanged(DataGridViewColumnEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnHeaderCellChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnColumnHeaderCellChanged(DataGridViewColumnEventArgs e)
		{
		}

		/// 
		/// Fires the column header mouse click.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs" /> instance containing the event data.</param>
		internal void FireColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
		{
			OnColumnHeaderMouseClick(e);
		}

		/// 
		/// Fires the column header mouse double click.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs" /> instance containing the event data.</param>
		internal void FireColumnHeaderMouseDoubleClick(DataGridViewCellMouseEventArgs e)
		{
			OnColumnHeaderMouseDoubleClick(e);
		}

		/// 
		/// Fires the row header mouse click.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs" /> instance containing the event data.</param>
		internal void FireRowHeaderMouseClick(DataGridViewCellMouseEventArgs e)
		{
			OnRowHeaderMouseClick(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnHeaderMouseClick"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs.ColumnIndex"></see> property of e is less than zero or greater than the number of columns in the control minus one.</exception>
		protected virtual void OnColumnHeaderMouseClick(DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && SelectionMode != DataGridViewSelectionMode.FullColumnSelect && SelectionMode != DataGridViewSelectionMode.ColumnHeaderSelect)
			{
				DataGridViewColumn dataGridViewColumn = Columns[e.ColumnIndex];
				if (dataGridViewColumn.SortMode == DataGridViewColumnSortMode.Automatic && (!VirtualMode || dataGridViewColumn.IsDataBound))
				{
					ListSortDirection enmDirection = ListSortDirection.Ascending;
					if (SortedColumn == dataGridViewColumn && SortOrder == SortOrder.Ascending)
					{
						enmDirection = ListSortDirection.Descending;
					}
					if (DataSource == null || (DataSource != null && DataConnection.List<object> is IBindingList && ((IBindingList)DataConnection.List).SupportsSorting && dataGridViewColumn.IsDataBound))
					{
						Sort(dataGridViewColumn, enmDirection);
					}
				}
			}
			if (GetHandler(EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSECLICK) is DataGridViewCellMouseEventHandler dataGridViewCellMouseEventHandler)
			{
				dataGridViewCellMouseEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnHeaderMouseDoubleClick"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains information about the cell and the position of the mouse pointer.</param>
		protected virtual void OnColumnHeaderMouseDoubleClick(DataGridViewCellMouseEventArgs e)
		{
			if (GetHandler(EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSEDOUBLECLICK) is DataGridViewCellMouseEventHandler dataGridViewCellMouseEventHandler && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				dataGridViewCellMouseEventHandler?.Invoke(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersBorderStyleChanged"></see> event. </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnColumnHeadersBorderStyleChanged(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersDefaultCellStyleChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnColumnHeadersDefaultCellStyleChanged(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersHeightChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnColumnHeadersHeightChanged(EventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersHeightSizeModeChanged"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeModeEventArgs"></see> that contains the event data. </param>
		protected virtual void OnColumnHeadersHeightSizeModeChanged(DataGridViewAutoSizeModeEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnMinimumWidthChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnColumnMinimumWidthChanged(DataGridViewColumnEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnNameChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnColumnNameChanged(DataGridViewColumnEventArgs e)
		{
			if (e.Column.DataGridView != this)
			{
				throw new ArgumentException(SR.GetString("DataGridView_ColumnDoesNotBelongToDataGridView"));
			}
			DataGridViewColumn column = e.Column;
			if (!column.HasHeaderCell || !(column.HeaderCell.Value is string) || string.Compare((string)column.HeaderCell.Value, column.Name, ignoreCase: false, CultureInfo.InvariantCulture) != 0)
			{
				return;
			}
			InvalidateCellPrivate(column.Index, -1);
			DataGridViewAutoSizeColumnCriteriaInternal inheritedAutoSizeMode = (DataGridViewAutoSizeColumnCriteriaInternal)column.InheritedAutoSizeMode;
			bool flag = (inheritedAutoSizeMode & DataGridViewAutoSizeColumnCriteriaInternal.Header) == 0 || !ColumnHeadersVisible;
			if (ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
			{
				AutoResizeColumnHeadersHeight(column.Index, blnFixedRowHeadersWidth: true, flag);
			}
			if (!flag)
			{
				bool flag2 = (AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode)2) == 0;
				AutoResizeColumnInternal(column.Index, inheritedAutoSizeMode, flag2);
				if (!flag2)
				{
					AdjustShrinkingRows(AutoSizeRowsMode, blnFixedWidth: true, blnInternalAutosizing: true);
					AutoResizeColumnInternal(column.Index, inheritedAutoSizeMode, blnFixedHeight: true);
				}
				if (ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
				{
					AutoResizeColumnHeadersHeight(column.Index, blnFixedRowHeadersWidth: true, blnFixedColumnWidth: true);
				}
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnRemoved"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
		protected virtual void OnColumnRemoved(DataGridViewColumnEventArgs e)
		{
			DataGridViewColumnEventHandler dataGridViewColumnEventHandler = this.ColumnRemoved;
			if (dataGridViewColumnEventHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				dataGridViewColumnEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnSortModeChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnColumnSortModeChanged(DataGridViewColumnEventArgs e)
		{
		}

		internal void OnColumnSortModeChanged(DataGridViewColumn objDataGridViewColumn)
		{
			DataGridViewColumnEventArgs e = new DataGridViewColumnEventArgs(objDataGridViewColumn);
			OnColumnSortModeChanged(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnStateChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnStateChangedEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.InvalidCastException">The column changed from read-only to read/write, enabling the current cell to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		protected virtual void OnColumnStateChanged(DataGridViewColumnStateChangedEventArgs e)
		{
			DataGridViewColumn column = e.Column;
			switch (e.StateChanged)
			{
			case DataGridViewElementStates.Selected:
				if (column.Visible && BulkPaintCount == 0)
				{
					InvalidateColumnInternal(column.Index);
				}
				break;
			case DataGridViewElementStates.Frozen:
				if (column.Visible)
				{
					mobjDataGridViewState2[67108864] = true;
					PerformLayoutPrivate(blnInvalidInAdjustFillingColumns: true);
					Invalidate();
				}
				break;
			case DataGridViewElementStates.Visible:
			{
				if (!column.Visible && column.Displayed)
				{
					column.DisplayedInternal = false;
				}
				mobjDataGridViewState2[67108864] = true;
				PerformLayoutPrivate(blnInvalidInAdjustFillingColumns: true);
				DataGridViewAutoSizeRowsMode autoSizeRowsMode = AutoSizeRowsMode;
				bool flag = (autoSizeRowsMode & (DataGridViewAutoSizeRowsMode)2) != DataGridViewAutoSizeRowsMode.None || ((autoSizeRowsMode & (DataGridViewAutoSizeRowsMode)1) != DataGridViewAutoSizeRowsMode.None && RowHeadersVisible);
				bool flag2 = false;
				DataGridViewAutoSizeColumnMode inheritedAutoSizeMode = column.InheritedAutoSizeMode;
				if (inheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.None && inheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.Fill)
				{
					int thicknessInternal = column.ThicknessInternal;
					if (column.Visible)
					{
						column.CachedThickness = thicknessInternal;
						AutoResizeColumnInternal(column.Index, (DataGridViewAutoSizeColumnCriteriaInternal)inheritedAutoSizeMode, !flag);
						flag2 = true;
					}
					else if (thicknessInternal != column.CachedThickness)
					{
						column.ThicknessInternal = Math.Max(column.MinimumWidth, column.CachedThickness);
					}
				}
				if (flag)
				{
					if (column.Visible)
					{
						AdjustExpandingRows(column.Index, blnFixedWidth: true);
					}
					else
					{
						AdjustShrinkingRows(autoSizeRowsMode, blnFixedWidth: true, blnInternalAutosizing: true);
					}
					if (flag2)
					{
						AutoResizeColumnInternal(column.Index, (DataGridViewAutoSizeColumnCriteriaInternal)inheritedAutoSizeMode, blnFixedHeight: true);
					}
				}
				else
				{
					Invalidate();
				}
				break;
			}
			}
			this.ColumnStateChanged?.Invoke(this, e);
			if (e.StateChanged == DataGridViewElementStates.ReadOnly && column.Index == mobjCurrentCellPoint.X && !mobjDataGridViewOper[16384] && !column.ReadOnly && ColumnEditable(mobjCurrentCellPoint.X) && (Rows.GetRowState(mobjCurrentCellPoint.Y) & DataGridViewElementStates.ReadOnly) == 0 && !IsCurrentCellInEditMode && (EditMode == DataGridViewEditMode.EditOnEnter || (EditMode != DataGridViewEditMode.EditProgrammatically && CurrentCellInternal.EditType == null)))
			{
				BeginEditInternal(blnSelectAll: true);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnToolTipTextChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains information about the column.</param>
		/// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnColumnToolTipTextChanged(DataGridViewColumnEventArgs e)
		{
		}

		internal void OnColumnToolTipTextChanged(DataGridViewColumn objDataGridViewColumn)
		{
			OnColumnToolTipTextChanged(new DataGridViewColumnEventArgs(objDataGridViewColumn));
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnWidthChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The column indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs.Column"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnColumnWidthChanged(DataGridViewColumnEventArgs e)
		{
			if (GetHandler(EVENT_DATAGRIDVIEWCOLUMNWIDTHCHANGED) is DataGridViewColumnEventHandler dataGridViewColumnEventHandler)
			{
				dataGridViewColumnEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CurrentCellChanged"></see> event. </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnCurrentCellChanged(EventArgs e)
		{
			EventHandler currentCellChangedHandler = CurrentCellChangedHandler;
			if (currentCellChangedHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				currentCellChangedHandler(this, e);
			}
		}

		/// 
		/// Raises the <see cref="E:CurrentCellDirtyStateChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnCurrentCellDirtyStateChanged(EventArgs e)
		{
			OnCurrentCellDirtyStateChanged(e, blnClientSource: false);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CurrentCellDirtyStateChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		private void OnCurrentCellDirtyStateChanged(EventArgs e, bool blnClientSource)
		{
			if (!blnClientSource && RowHeadersVisible && ShowEditingIcon)
			{
				InvalidateCellPrivate(mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
			}
			if (IsCurrentCellDirty && NewRowIndex == mobjCurrentCellPoint.Y)
			{
				NewRowIndex = -1;
				AddNewRow(blnCreatedByEditing: true);
			}
			this.CurrentCellDirtyStateChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.CursorChanged"></see> event and updates the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.UserSetCursor"></see> property if the cursor was changed in user code.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected override void OnCursorChanged(EventArgs e)
		{
		}

		/// 
		/// Called when [data binding complete].
		/// </summary>
		/// <param name="enmListChangedType">Type of the list changed.</param>
		internal void OnDataBindingComplete(ListChangedType enmListChangedType)
		{
			OnDataBindingComplete(new DataGridViewBindingCompleteEventArgs(enmListChangedType));
			if (enmListChangedType == ListChangedType.Reset && ShowFilterRow && !mblnSuspendFilterInitialization)
			{
				SwitchPreRenderUpdate(PreRenderUpdateType.FilterRow);
			}
			SwitchPreRenderUpdate(PreRenderUpdateType.GroupHeaders);
		}

		/// 
		/// Gets the column header info.
		/// </summary>
		/// <param name="objDataGridViewColumn">The obj data grid view column.</param>
		/// </returns>
		internal HeaderFilterInfo GetColumnHeaderInfo(DataGridViewColumn objDataGridViewColumn)
		{
			List<object> list = mobjHeadersFilterInfo;
			if (list != null)
			{
				foreach (HeaderFilterInfo item in list)
				{
					if (item.DataPropertyName == objDataGridViewColumn.DataPropertyName)
					{
						return item;
					}
				}
			}
			return null;
		}

		/// 
		/// Initializes the grouping data.
		/// </summary>
		private void PreRenderGroupingData()
		{
			if (DataSource is BindingSource { SupportsSorting: not false } && GroupingColumns.Count > 0)
			{
				string text = GroupingColumns[0];
				string realDataMemberForProposedMember = Columns.GetRealDataMemberForProposedMember(text);
				if (!string.IsNullOrEmpty(realDataMemberForProposedMember) && !string.IsNullOrEmpty(text))
				{
					DataGridViewColumn dataGridViewColumn = Columns[realDataMemberForProposedMember];
					if (!dataGridViewColumn.CanGroupBy)
					{
						throw new InvalidOperationException(SR.GetString("DataGridView_CannotGroupByThisColumn", dataGridViewColumn.HeaderText));
					}
					if (dataGridViewColumn == null)
					{
						throw new Exception(SR.GetString("DataGridView_InvalidGroupingColumnName", text));
					}
					if (SortedColumn != dataGridViewColumn || SortOrder != SortOrder.Ascending)
					{
						Sort(dataGridViewColumn, ListSortDirection.Ascending);
					}
					int columnCount = Columns.GetColumnCount(DataGridViewElementStates.Visible);
					if (columnCount > 0)
					{
						DataGridViewRow dataGridViewRow = null;
						int num = Rows.GetFirstRow(DataGridViewElementStates.None);
						DataGridViewColumn firstColumn = Columns.GetFirstColumn(DataGridViewElementStates.Visible);
						if (firstColumn != null)
						{
							bool flag = false;
							int index = firstColumn.Index;
							if (mintPrevGroupHeaderCellPanelIndex >= 0 && index != mintPrevGroupHeaderCellPanelIndex)
							{
								flag = true;
							}
							while (num >= 0)
							{
								DataGridViewRow dataGridViewRow2 = Rows[num];
								if (dataGridViewRow2 == null)
								{
									continue;
								}
								if (flag)
								{
									dataGridViewRow2.Cells[mintPrevGroupHeaderCellPanelIndex].Panel = null;
								}
								object value = dataGridViewRow2.Cells[realDataMemberForProposedMember].Value;
								if (dataGridViewRow != null && object.Equals(dataGridViewRow.Cells[realDataMemberForProposedMember].Value, value))
								{
									if (dataGridViewRow2.Visible)
									{
										dataGridViewRow2.Visible = false;
									}
									dataGridViewRow2.Cells[0].Rowspan = 0;
									dataGridViewRow2.Cells[0].Colspan = 0;
								}
								else
								{
									if (SystemHierarchicInfos.Count > 0)
									{
										if (!dataGridViewRow2.IsNewRow)
										{
											CreateGroupHeader(text, index, columnCount, dataGridViewRow2.Cells[realDataMemberForProposedMember].Value, dataGridViewRow2);
										}
										else
										{
											CreateGroupHeader("New Row", index, columnCount, "Empty", dataGridViewRow2);
										}
									}
									dataGridViewRow = dataGridViewRow2;
								}
								num = Rows.GetNextRow(num, DataGridViewElementStates.None);
							}
							mintPrevGroupHeaderCellPanelIndex = index;
						}
					}
				}
			}
			SwitchPreRenderUpdate((PreRenderUpdateType)(-5));
		}

		/// 
		/// Creates the group header.
		/// </summary>
		/// <param name="strColumnDataPropertyName">Name of the STR column data property.</param>
		/// <param name="intFirstVisibleColumnIndex">Index of the int first visible column.</param>
		/// <param name="intVisibleColumnsCount">The int visible columns count.</param>
		/// <param name="objCurrentValue">The obj current value.</param>
		/// <param name="objCurrentRow">The obj current row.</param>
		private void CreateGroupHeader(string strColumnDataPropertyName, int intFirstVisibleColumnIndex, int intVisibleColumnsCount, object objCurrentValue, DataGridViewRow objCurrentRow)
		{
			if (!objCurrentRow.Visible)
			{
				objCurrentRow.Visible = true;
			}
			BindingSource objRowBindingSource = null;
			if (mblnSupportGroupCount && !objCurrentRow.IsNewRow)
			{
				objRowBindingSource = GetClonedBindingSourceWithFilterForNextLevel(objCurrentRow);
			}
			DataGridViewCell dataGridViewCell = objCurrentRow.Cells[intFirstVisibleColumnIndex];
			if (dataGridViewCell != null)
			{
				string strCurrentValue = string.Empty;
				if (objCurrentValue != null)
				{
					strCurrentValue = objCurrentValue.ToString();
				}
				FormatGroupHeader(dataGridViewCell, intVisibleColumnsCount, strColumnDataPropertyName, strCurrentValue, objRowBindingSource);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataBindingComplete"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBindingCompleteEventArgs"></see> that contains the event data.</param>
		protected virtual void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
		{
			DataGridViewBindingCompleteEventHandler dataGridViewBindingCompleteEventHandler = this.DataBindingComplete;
			if (dataGridViewBindingCompleteEventHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				dataGridViewBindingCompleteEventHandler(this, e);
			}
		}

		internal void OnDataErrorInternal(DataGridViewDataErrorEventArgs e)
		{
			OnDataError(!base.DesignMode, e);
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.CellContentClick"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains information regarding the cell whose content was clicked.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellContentClick(DataGridViewCellEventArgs e)
		{
			if (GetHandler(EVENT_DATAGRIDVIEWCELLCONTENTCLICK) is DataGridViewCellEventHandler dataGridViewCellEventHandler)
			{
				dataGridViewCellEventHandler(this, e);
			}
		}

		internal void OnCellContentClickInternal(DataGridViewCellEventArgs e)
		{
			OnCellContentClick(e);
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.CellContentDoubleClick"></see> event. </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellContentDoubleClick(DataGridViewCellEventArgs e)
		{
			if (GetHandler(EVENT_DATAGRIDVIEWCELLCONTENTDOUBLECLICK) is DataGridViewCellEventHandler dataGridViewCellEventHandler)
			{
				dataGridViewCellEventHandler(this, e);
			}
		}

		internal void OnCellContentDoubleClickInternal(DataGridViewCellEventArgs e)
		{
			OnCellContentDoubleClick(e);
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.CellClick"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellClick(DataGridViewCellEventArgs e)
		{
			if (GetHandler(EVENT_DATAGRIDVIEWCELLCLICK) is DataGridViewCellEventHandler dataGridViewCellEventHandler)
			{
				dataGridViewCellEventHandler(this, e);
			}
		}

		internal void OnCellClickInternal(DataGridViewCellEventArgs e)
		{
			OnCellClick(e);
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.CellMouseClick"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellMouseClick(DataGridViewCellMouseEventArgs e)
		{
			if (GetHandler(EVENT_DATAGRIDVIEWCELLMOUSECLICK) is DataGridViewCellMouseEventHandler dataGridViewCellMouseEventHandler)
			{
				dataGridViewCellMouseEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.CellMouseDoubleClick"></see> event. </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellMouseDoubleClick(DataGridViewCellMouseEventArgs e)
		{
			if (GetHandler(EVENT_DATAGRIDVIEWCELLMOUSEDOUBLECLICK) is DataGridViewCellMouseEventHandler dataGridViewCellMouseEventHandler)
			{
				dataGridViewCellMouseEventHandler(this, e);
			}
		}

		/// 
		/// Fires the click events.
		/// </summary>
		/// <param name="objMouseEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs" /> instance containing the event data.</param>
		/// <param name="objDataGridViewCellEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs" /> instance containing the event data.</param>
		/// <param name="objDataGridViewCellMouseEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs" /> instance containing the event data.</param>
		internal void FireClickEvents(MouseEventArgs objMouseEventArgs, DataGridViewCellEventArgs objDataGridViewCellEventArgs, DataGridViewCellMouseEventArgs objDataGridViewCellMouseEventArgs)
		{
			bool flag = objMouseEventArgs.Button == MouseButtons.Right;
			if (!flag)
			{
				OnCellContentClick(objDataGridViewCellEventArgs);
			}
			OnCellMouseDown(objDataGridViewCellMouseEventArgs);
			OnCellMouseUp(objDataGridViewCellMouseEventArgs);
			if (!flag)
			{
				OnCellClick(objDataGridViewCellEventArgs);
			}
			OnClick(objMouseEventArgs);
		}

		/// 
		/// Fires the double click events.
		/// </summary>
		/// <param name="objDataGridViewCellEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs" /> instance containing the event data.</param>
		internal void FireDoubleClickEvents(DataGridViewCellEventArgs objDataGridViewCellEventArgs)
		{
			OnCellContentDoubleClick(objDataGridViewCellEventArgs);
			OnCellDoubleClick(objDataGridViewCellEventArgs);
			OnDoubleClick(EventArgs.Empty);
		}

		/// 
		///
		/// </summary>
		/// <param name="objDataGridViewCell"></param>
		/// <param name="intColumnIndex"></param>
		/// <param name="intRowIndex"></param>
		internal void OnCellEnter(ref DataGridViewCell objDataGridViewCell, int intColumnIndex, int intRowIndex)
		{
			OnCellEnter(new DataGridViewCellEventArgs(intColumnIndex, intRowIndex));
			if (objDataGridViewCell != null)
			{
				if (IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
				{
					objDataGridViewCell = null;
				}
				else
				{
					objDataGridViewCell = Rows.SharedRow(intRowIndex).Cells[intColumnIndex];
				}
			}
		}

		/// 
		/// Columns the editable.
		/// </summary>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// </returns>
		private bool ColumnEditable(int intColumnIndex)
		{
			if (Columns[intColumnIndex].IsDataBound && DataConnection != null && !DataConnection.AllowEdit)
			{
				return false;
			}
			return true;
		}

		/// 
		/// Begins the edit internal.
		/// </summary>
		/// <param name="blnSelectAll">if set to true</c> [BLN select all].</param>
		/// </returns>
		private bool BeginEditInternal(bool blnSelectAll)
		{
			return BeginEditInternal(blnSelectAll, blnClientSource: false);
		}

		/// 
		/// Begins the edit internal.
		/// </summary>
		/// <param name="blnSelectAll">if set to true</c> [select all].</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		/// </returns>
		private bool BeginEditInternal(bool blnSelectAll, bool blnClientSource)
		{
			Control editingControl = EditingControl;
			Control latestEditingControl = LatestEditingControl;
			if (mobjDataGridViewOper[2097152])
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_BeginEditNotReentrant"));
			}
			bool result;
			try
			{
				mobjDataGridViewOper[2097152] = true;
				DataGridViewCell currentCellInternal = CurrentCellInternal;
				if (IsSharedCellReadOnly(currentCellInternal, mobjCurrentCellPoint.Y) || !ColumnEditable(mobjCurrentCellPoint.X))
				{
					goto IL_0114;
				}
				Type editType = currentCellInternal.EditType;
				if (!(editType != null) && !(currentCellInternal.GetType().GetInterface("Gizmox.WebGUI.Forms.IDataGridViewEditingCell") != null))
				{
					goto IL_0114;
				}
				DataGridViewCellCancelEventArgs e = new DataGridViewCellCancelEventArgs(mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
				OnCellBeginEdit(e);
				if (e.Cancel)
				{
					return false;
				}
				if (mobjCurrentCellPoint.X <= -1)
				{
					goto IL_0114;
				}
				currentCellInternal = CurrentCellInternal;
				DataGridViewCellStyle objDataGridViewCellStyle = currentCellInternal.GetInheritedStyle(null, mobjCurrentCellPoint.Y, blnIncludeColors: true);
				if (editType == null)
				{
					mobjDataGridViewState1[32768] = true;
					InitializeEditingCellValue(ref objDataGridViewCellStyle, ref currentCellInternal);
					((IDataGridViewEditingCell)currentCellInternal).PrepareEditingCellForEdit(blnSelectAll);
					return true;
				}
				Type type = editType.GetInterface("Gizmox.WebGUI.Forms.IDataGridViewEditingControl");
				if (!editType.IsSubclassOf(Type.GetType("Gizmox.WebGUI.Forms.Control")) || type == null)
				{
					throw new InvalidCastException(SR.GetString("DataGridView_InvalidEditingControl"));
				}
				if (latestEditingControl != null && editType.IsInstanceOfType(latestEditingControl) && !latestEditingControl.GetType().IsSubclassOf(editType))
				{
					editingControl = (EditingControl = latestEditingControl);
				}
				else
				{
					editingControl = (EditingControl = (Control)SecurityUtils.SecureCreateInstance(editType));
					((IDataGridViewEditingControl)editingControl).EditingControlDataGridView = this;
					if (latestEditingControl != null)
					{
						latestEditingControl.Dispose();
						latestEditingControl = null;
					}
				}
				((IDataGridViewEditingControl)editingControl).EditingControlRowIndex = mobjCurrentCellPoint.Y;
				InitializeEditingControlValue(ref objDataGridViewCellStyle, currentCellInternal);
				DataGridViewEditingControlShowingEventArgs e2 = new DataGridViewEditingControlShowingEventArgs(editingControl, objDataGridViewCellStyle);
				OnEditingControlShowing(e2);
				if (editingControl == null)
				{
					return false;
				}
				((IDataGridViewEditingControl)editingControl).ApplyCellStyleToEditingControl(e2.CellStyle);
				if (editingControl == null)
				{
					return false;
				}
				((IDataGridViewEditingControl)editingControl).PrepareEditingControlForEdit(blnSelectAll);
				if (!blnClientSource)
				{
					InvalidateCellPrivate(mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
				}
				result = true;
				goto end_IL_0035;
				IL_0114:
				return false;
				end_IL_0035:;
			}
			finally
			{
				mobjDataGridViewOper[2097152] = false;
			}
			return result;
		}

		/// 
		///
		/// </summary>
		/// <param name="e"></param>
		protected override void OnEnter(EventArgs e)
		{
			if (EditingControl != null && EditingControl.ContainsFocus)
			{
				return;
			}
			base.OnEnter(e);
			if (base.DesignMode)
			{
				return;
			}
			mobjDataGridViewState1[64] = false;
			if (mobjCurrentCellPoint.X > -1)
			{
				DataGridViewCell objDataGridViewCell = null;
				OnRowEnter(ref objDataGridViewCell, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y, blnCanCreateNewRow: false, blnValidationFailureOccurred: false);
				if (mobjCurrentCellPoint.X != -1)
				{
					OnCellEnter(ref objDataGridViewCell, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
				}
			}
			else if (!mobjDataGridViewOper[8192])
			{
				MakeFirstDisplayedCellCurrentCell(blnIncludeNewRow: true);
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="objDataGridViewCell"></param>
		/// <param name="intColumnIndex"></param>
		/// <param name="intRowIndex"></param>
		/// <param name="blnCanCreateNewRow"></param>
		/// <param name="blnValidationFailureOccurred"></param>
		internal void OnRowEnter(ref DataGridViewCell objDataGridViewCell, int intColumnIndex, int intRowIndex, bool blnCanCreateNewRow, bool blnValidationFailureOccurred)
		{
			if (!blnValidationFailureOccurred)
			{
				mobjDataGridViewState1[524288] = false;
			}
			DataGridViewRowCollection rows = Rows;
			if (intRowIndex >= rows.Count || intColumnIndex >= Columns.Count)
			{
				return;
			}
			bool flag = false;
			if (!blnValidationFailureOccurred && AllowUserToAddRowsInternal && NewRowIndex == intRowIndex)
			{
				mobjDataGridViewState1[524288] = true;
				if (blnCanCreateNewRow)
				{
					DataGridViewRowEventArgs e = new DataGridViewRowEventArgs(rows[NewRowIndex]);
					if (VirtualMode || DataSource != null)
					{
						if (DataConnection != null && DataConnection.InterestedInRowEvents)
						{
							DataConnection.OnNewRowNeeded();
							flag = true;
						}
						if (VirtualMode)
						{
							OnNewRowNeeded(e);
						}
					}
					if (AllowUserToAddRowsInternal)
					{
						OnDefaultValuesNeeded(e);
						InvalidateRowPrivate(NewRowIndex);
					}
				}
			}
			if (flag && intRowIndex > rows.Count - 1)
			{
				intRowIndex = Math.Min(intRowIndex, rows.Count - 1);
			}
			DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(intColumnIndex, intRowIndex);
			OnRowEnter(e2);
			if (DataConnection != null && DataConnection.InterestedInRowEvents && !DataConnection.PositionChangingOutsideDataGridView && !DataConnection.ListWasReset && (!flag || DataConnection.List.Count > 0))
			{
				DataConnection.OnRowEnter(e2);
			}
			if (objDataGridViewCell != null)
			{
				if (IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
				{
					objDataGridViewCell = null;
				}
				else
				{
					objDataGridViewCell = rows.SharedRow(intRowIndex).Cells[intColumnIndex];
				}
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="e"></param>
		protected void OnCellEnter(DataGridViewCellEventArgs e)
		{
			this.CellEnter?.Invoke(this, e);
		}

		/// 
		///
		/// </summary>
		/// <param name="e"></param>
		protected void OnCellLeave(DataGridViewCellEventArgs e)
		{
			this.CellLeave?.Invoke(this, e);
		}

		/// 
		/// Called when [cell leave].
		/// </summary>
		/// <param name="objDataGridViewCell">The data grid view cell.</param>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		internal void OnCellLeave(ref DataGridViewCell objDataGridViewCell, int intColumnIndex, int intRowIndex)
		{
			OnCellLeave(new DataGridViewCellEventArgs(intColumnIndex, intRowIndex));
			if (objDataGridViewCell != null)
			{
				if (IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
				{
					objDataGridViewCell = null;
				}
				else
				{
					objDataGridViewCell = Rows.SharedRow(intRowIndex).Cells[intColumnIndex];
				}
			}
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.CellDoubleClick"></see> event. </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellDoubleClick(DataGridViewCellEventArgs e)
		{
			if (GetHandler(EVENT_DATAGRIDVIEWCELLDOUBLECLICK) is DataGridViewCellEventHandler dataGridViewCellEventHandler)
			{
				dataGridViewCellEventHandler(this, e);
			}
		}

		internal void OnColumnMinimumWidthChanging(DataGridViewColumn objDataGridViewColumn, int intMinimumWidth)
		{
			if (objDataGridViewColumn.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill && objDataGridViewColumn.Width < intMinimumWidth)
			{
				try
				{
					mobjDataGridViewState2[67108864] = true;
					objDataGridViewColumn.DesiredMinimumWidth = intMinimumWidth;
				}
				finally
				{
					objDataGridViewColumn.DesiredMinimumWidth = 0;
				}
			}
		}

		internal void OnMouseWheelInternal(MouseEventArgs e)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs"></see> that contains the event data. </param>
		/// <param name="blnDisplayErrorDialogIfNoHandler">true to display an error dialog box if there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event.</param>
		protected virtual void OnDataError(bool blnDisplayErrorDialogIfNoHandler, DataGridViewDataErrorEventArgs e)
		{
			if (mobjDataGridViewOper[1048576] || base.IsDisposed)
			{
				return;
			}
			DataGridViewDataErrorEventHandler dataGridViewDataErrorEventHandler = this.DataError;
			if (dataGridViewDataErrorEventHandler == null)
			{
				if (blnDisplayErrorDialogIfNoHandler)
				{
					string strText = ((e.Exception != null) ? SR.GetString("DataGridView_ErrorMessageText_WithException", e.Exception) : SR.GetString("DataGridView_ErrorMessageText_NoException"));
					bool flag = true;
					if (ConfigHelper.ModalDialogEmulationMode.ToLower() == "onthread")
					{
						RequestProcessingState requestProcessingState = Context.RequestProcessingState;
						flag = requestProcessingState != RequestProcessingState.PreRenderResponse && requestProcessingState != RequestProcessingState.RenderResponse && requestProcessingState != RequestProcessingState.PostRrenderResponse;
					}
					if (flag)
					{
						MessageBox.Show(strText, SR.GetString("DataGridView_ErrorMessageCaption"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
			else
			{
				dataGridViewDataErrorEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataMemberChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnDataMemberChanged(EventArgs e)
		{
			RefreshColumnsAndRows();
			InvalidateRowHeights();
			this.DataMemberChanged?.Invoke(this, e);
			if (DataConnection != null && DataConnection.CurrencyManager != null)
			{
				OnDataBindingComplete(ListChangedType.Reset);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataSourceChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnDataSourceChanged(EventArgs e)
		{
			RefreshColumnsAndRows();
			InvalidateRowHeights();
			this.DataSourceChanged?.Invoke(this, e);
			if (DataConnection != null && DataConnection.CurrencyManager != null)
			{
				OnDataBindingComplete(ListChangedType.Reset);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DefaultCellStyleChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnDefaultCellStyleChanged(EventArgs e)
		{
			if (e is DataGridViewCellStyleChangedEventArgs { ChangeAffectsPreferredSize: false })
			{
				Invalidate();
			}
			else
			{
				OnGlobalAutoSize();
			}
			this.DefaultCellStyleChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DefaultValuesNeeded"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
		protected virtual void OnDefaultValuesNeeded(DataGridViewRowEventArgs e)
		{
			this.DefaultValuesNeeded?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.EditingControlShowing"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewEditingControlShowingEventArgs"></see> that contains information about the editing control.</param>
		protected virtual void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
		{
			this.EditingControlShowing?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.EditModeChanged"></see> event. </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.InvalidCastException">When entering edit mode, the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		protected virtual void OnEditModeChanged(EventArgs e)
		{
			this.EditModeChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.FontChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			Font font = base.Font;
			if (mobjDataGridViewState1[67108864] && ColumnHeadersDefaultCellStyle.Font != font)
			{
				ColumnHeadersDefaultCellStyle.Font = font;
				mobjDataGridViewState1[67108864] = true;
				CellStyleChangedEventArgs.ChangeAffectsPreferredSize = true;
				OnColumnHeadersDefaultCellStyleChanged(CellStyleChangedEventArgs);
			}
			if (mobjDataGridViewState1[134217728] && RowHeadersDefaultCellStyle.Font != font)
			{
				RowHeadersDefaultCellStyle.Font = font;
				mobjDataGridViewState1[134217728] = true;
				CellStyleChangedEventArgs.ChangeAffectsPreferredSize = true;
				OnRowHeadersDefaultCellStyleChanged(CellStyleChangedEventArgs);
			}
			if (mobjDataGridViewState1[33554432] && DefaultCellStyle.Font != font)
			{
				DefaultCellStyle.Font = font;
				mobjDataGridViewState1[33554432] = true;
				CellStyleChangedEventArgs.ChangeAffectsPreferredSize = true;
				OnDefaultCellStyleChanged(CellStyleChangedEventArgs);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ForeColorChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected override void OnForeColorChanged(EventArgs e)
		{
			base.OnForeColorChanged(e);
			Color foreColor = base.ForeColor;
			if (mobjDataGridViewState1[1024] && DefaultCellStyle.ForeColor != foreColor)
			{
				DefaultCellStyle.ForeColor = foreColor;
				mobjDataGridViewState1[1024] = true;
				CellStyleChangedEventArgs.ChangeAffectsPreferredSize = false;
				OnDefaultCellStyleChanged(CellStyleChangedEventArgs);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.GridColorChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnGridColorChanged(EventArgs e)
		{
			this.GridColorChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyDown"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.Exception">This action would cause the control to enter edit mode but initialization of the editing cell value failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.KeyUp"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Obsolete("Implemented by design as KeyPress (Use KeyPress instead).")]
		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
		}

		/// 
		/// Raises the <see cref="E:LostFocus" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseClick"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.Exception">The control is configured to enter edit mode when it receives focus, but initialization of the editing cell value failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseDoubleClick"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data.</param>
		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			base.OnMouseDoubleClick(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseDown"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.Exception">The control is configured to enter edit mode when it receives focus, but initialization of the editing cell value failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
		[Obsolete("Implemented by design as Click (Use Click instead).")]
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseUp"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
		[Obsolete("Implemented by design as Click (Use Click instead).")]
		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.MultiSelectChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnMultiSelectChanged(EventArgs e)
		{
			EventHandler eventHandler = this.MultiSelectChanged;
			if (eventHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				eventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.NewRowNeeded"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnNewRowNeeded(DataGridViewRowEventArgs e)
		{
			this.NewRowNeeded?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ReadOnlyChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.InvalidCastException">The control changed from read-only to read/write, enabling the current cell to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		protected virtual void OnReadOnlyChanged(EventArgs e)
		{
			this.ReadOnlyChanged?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:Layout" /> event.
		/// </summary>
		/// <param name="objEventArgs"></param>
		protected override void OnLayout(LayoutEventArgs objEventArgs)
		{
			base.OnLayout(objEventArgs);
			if (NeedToAdjustFillingColumns)
			{
				ResetUIState(blnUseRowShortcut: false, blnComputeVisibleRows: false);
			}
		}

		internal void OnReplacingCell(DataGridViewRow objDataGridViewRow, int intColumnIndex)
		{
		}

		internal void OnReplacedCell(DataGridViewRow objDataGridViewRow, int intColumnIndex)
		{
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowContextMenuStripChanged"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnRowContextMenuStripChanged(DataGridViewRowEventArgs e)
		{
			this.RowContextMenuStripChanged?.Invoke(this, e);
		}

		/// 
		/// Called when [row context menu strip needed].
		/// </summary>
		/// <param name="rowIndex">Index of the row.</param>
		/// <param name="contextMenuStrip">The context menu strip.</param>
		/// </returns>
		internal ContextMenuStrip OnRowContextMenuStripNeeded(int rowIndex, ContextMenuStrip contextMenuStrip)
		{
			DataGridViewRowContextMenuStripNeededEventArgs e = new DataGridViewRowContextMenuStripNeededEventArgs(rowIndex, contextMenuStrip);
			OnRowContextMenuStripNeeded(e);
			return e.ContextMenuStrip;
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowContextMenuStripNeeded"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowContextMenuStripNeededEventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowContextMenuStripNeeded(DataGridViewRowContextMenuStripNeededEventArgs e)
		{
			this.RowContextMenuStripNeeded?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowDefaultCellStyleChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnRowDefaultCellStyleChanged(DataGridViewRowEventArgs e)
		{
			this.RowDefaultCellStyleChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowDirtyStateNeeded"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.QuestionEventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowDirtyStateNeeded(QuestionEventArgs e)
		{
			QuestionEventHandler questionEventHandler = this.RowDirtyStateNeeded;
			if (questionEventHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				questionEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowDividerDoubleClick"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowDividerDoubleClickEventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowDividerDoubleClick(DataGridViewRowDividerDoubleClickEventArgs e)
		{
			this.RowDividerDoubleClick?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowDividerHeightChanged"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnRowDividerHeightChanged(DataGridViewRowEventArgs e)
		{
			this.RowDividerHeightChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowEnter"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowEnter(DataGridViewCellEventArgs e)
		{
			this.RowEnter?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowErrorTextChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnRowErrorTextChanged(DataGridViewRowEventArgs e)
		{
			this.RowErrorTextChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowErrorTextNeeded"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowErrorTextNeededEventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowErrorTextNeeded(DataGridViewRowErrorTextNeededEventArgs e)
		{
			this.RowErrorTextNeeded?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeaderCellChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnRowHeaderCellChanged(DataGridViewRowEventArgs e)
		{
			this.RowHeaderCellChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.RowHeaderMouseClick"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains information about the mouse and the header cell that was clicked.</param>
		protected virtual void OnRowHeaderMouseClick(DataGridViewCellMouseEventArgs e)
		{
			if (GetHandler(EVENT_DATAGRIDVIEWROWHEADERMOUSECLICK) is DataGridViewCellMouseEventHandler dataGridViewCellMouseEventHandler)
			{
				dataGridViewCellMouseEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeaderMouseDoubleClick"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains information about the mouse and the header cell that was double-clicked.</param>
		protected virtual void OnRowHeaderMouseDoubleClick(DataGridViewCellMouseEventArgs e)
		{
			if (GetHandler(EVENT_DATAGRIDVIEWROWHEADERMOUSEDOUBLECLICK) is DataGridViewCellMouseEventHandler dataGridViewCellMouseEventHandler)
			{
				dataGridViewCellMouseEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeadersBorderStyleChanged"></see> event. </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowHeadersBorderStyleChanged(EventArgs e)
		{
			EventHandler eventHandler = this.RowHeadersBorderStyleChanged;
			if (eventHandler != null && !mobjDataGridViewOper[1048576] && !base.IsDisposed)
			{
				eventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeadersDefaultCellStyleChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowHeadersDefaultCellStyleChanged(EventArgs e)
		{
			this.RowHeadersDefaultCellStyleChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowHeadersWidthChanged(EventArgs e)
		{
			if (NeedToAdjustFillingColumns)
			{
				ResetUIState(blnUseRowShortcut: false, blnComputeVisibleRows: false);
			}
			this.RowHeadersWidthChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthSizeModeChanged"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeModeEventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowHeadersWidthSizeModeChanged(DataGridViewAutoSizeModeEventArgs e)
		{
			this.RowHeadersWidthSizeModeChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeightChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnRowHeightChanged(DataGridViewRowEventArgs e)
		{
			if (EnforceEqualRowSize)
			{
				int thicknessInternal = e.Row.ThicknessInternal;
				foreach (DataGridViewRow item in (IEnumerable)Rows)
				{
					if (item.ThicknessInternal != thicknessInternal)
					{
						item.SetThicknessInternal(thicknessInternal);
					}
				}
			}
			if (GetHandler(EVENT_DATAGRIDVIEWROWHEIGHTCHANGED) is DataGridViewRowEventHandler dataGridViewRowEventHandler)
			{
				if (NeedToAdjustFillingColumns)
				{
					ResetUIState(blnUseRowShortcut: false, blnComputeVisibleRows: false);
				}
				dataGridViewRowEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeightInfoNeeded"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeightInfoNeededEventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowHeightInfoNeeded(DataGridViewRowHeightInfoNeededEventArgs e)
		{
			this.RowHeightInfoNeeded?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeightInfoPushed"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeightInfoPushedEventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowHeightInfoPushed(DataGridViewRowHeightInfoPushedEventArgs e)
		{
			this.RowHeightInfoPushed?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowLeave"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowLeave(DataGridViewCellEventArgs e)
		{
			this.RowLeave?.Invoke(this, e);
		}

		/// 
		/// Called when [row leave].
		/// </summary>
		/// <param name="objDataGridViewCell">The data grid view cell.</param>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		private void OnRowLeave(ref DataGridViewCell objDataGridViewCell, int intColumnIndex, int intRowIndex)
		{
			DataGridViewRowCollection rows = Rows;
			if (intRowIndex >= rows.Count || intColumnIndex >= Columns.Count)
			{
				return;
			}
			DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(intColumnIndex, intRowIndex);
			OnRowLeave(e);
			if (objDataGridViewCell != null)
			{
				if (IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
				{
					objDataGridViewCell = null;
				}
				else
				{
					objDataGridViewCell = rows.SharedRow(intRowIndex).Cells[intColumnIndex];
				}
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowMinimumHeightChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnRowMinimumHeightChanged(DataGridViewRowEventArgs e)
		{
			this.RowMinimumHeightChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowsAdded"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowsAddedEventArgs"></see> that contains information about the added rows. </param>
		protected virtual void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
		{
			this.RowsAdded?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowsDefaultCellStyleChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowsDefaultCellStyleChanged(EventArgs e)
		{
			this.RowsDefaultCellStyleChanged?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowsRemoved"></see> event. </summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowsRemovedEventArgs"></see> that contains information about the deleted rows. </param>
		protected virtual void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e)
		{
			this.RowsRemoved?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowStateChanged"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowStateChangedEventArgs"></see> that contains the event data. </param>
		/// <param name="intRowIndex">The index of the row that is changing state.</param>
		/// <exception cref="T:System.InvalidCastException">The row changed from read-only to read/write, enabling the current cell to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		protected virtual void OnRowStateChanged(int intRowIndex, DataGridViewRowStateChangedEventArgs e)
		{
			DataGridViewRow dataGridViewRow = e.Row;
			DataGridViewElementStates dataGridViewElementStates = DataGridViewElementStates.None;
			bool flag = false;
			DataGridViewRowCollection rows = Rows;
			if (intRowIndex >= 0)
			{
				dataGridViewElementStates = rows.GetRowState(intRowIndex);
				flag = (dataGridViewElementStates & DataGridViewElementStates.Visible) != 0;
			}
			switch (e.StateChanged)
			{
			case DataGridViewElementStates.Selected:
				if (flag && BulkPaintCount == 0)
				{
					InvalidateRowPrivate(intRowIndex);
				}
				break;
			case DataGridViewElementStates.Frozen:
				if (flag)
				{
					PerformLayoutPrivate(blnInvalidInAdjustFillingColumns: true);
					Invalidate();
				}
				break;
			case DataGridViewElementStates.Visible:
			{
				if (!flag && (dataGridViewElementStates & DataGridViewElementStates.Displayed) != DataGridViewElementStates.None)
				{
					rows.SetRowState(intRowIndex, DataGridViewElementStates.Displayed, blnValue: false);
				}
				PerformLayoutPrivate(blnInvalidInAdjustFillingColumns: true);
				Invalidate();
				bool flag2 = (rows.GetRowState(intRowIndex) & DataGridViewElementStates.Displayed) != 0;
				DataGridViewAutoSizeRowsMode autoSizeRowsMode = AutoSizeRowsMode;
				DataGridViewAutoSizeRowsModeInternal dataGridViewAutoSizeRowsModeInternal = (DataGridViewAutoSizeRowsModeInternal)autoSizeRowsMode;
				bool flag3 = false;
				if (dataGridViewAutoSizeRowsModeInternal != DataGridViewAutoSizeRowsModeInternal.None)
				{
					int thicknessInternal = dataGridViewRow.ThicknessInternal;
					if (flag)
					{
						dataGridViewRow.CachedThickness = thicknessInternal;
						if ((dataGridViewAutoSizeRowsModeInternal & DataGridViewAutoSizeRowsModeInternal.DisplayedRows) == 0 || flag2)
						{
							AutoResizeRowInternal(intRowIndex, MapAutoSizeRowsModeToRowMode(autoSizeRowsMode), blnFixedWidth: false, blnInternalAutosizing: true);
							flag3 = true;
						}
					}
					else if (thicknessInternal != dataGridViewRow.CachedThickness)
					{
						if (dataGridViewRow.Index == -1)
						{
							dataGridViewRow = rows[intRowIndex];
						}
						dataGridViewRow.ThicknessInternal = Math.Max(dataGridViewRow.MinimumHeight, dataGridViewRow.CachedThickness);
					}
				}
				DataGridViewAutoSizeColumnCriteriaInternal dataGridViewAutoSizeColumnCriteriaInternal = DataGridViewAutoSizeColumnCriteriaInternal.AllRows;
				if (flag2)
				{
					dataGridViewAutoSizeColumnCriteriaInternal |= DataGridViewAutoSizeColumnCriteriaInternal.DisplayedRows;
				}
				if (flag && rows.GetRowCount(DataGridViewElementStates.Visible) > 1)
				{
					AdjustExpandingColumns(dataGridViewAutoSizeColumnCriteriaInternal, intRowIndex);
				}
				else
				{
					AutoResizeAllVisibleColumnsInternal(dataGridViewAutoSizeColumnCriteriaInternal, blnFixedHeight: true);
				}
				if (flag3)
				{
					AutoResizeRowInternal(intRowIndex, MapAutoSizeRowsModeToRowMode(autoSizeRowsMode), blnFixedWidth: true, blnInternalAutosizing: true);
				}
				break;
			}
			}
			this.RowStateChanged?.Invoke(this, e);
			if (e.StateChanged == DataGridViewElementStates.ReadOnly && intRowIndex == mobjCurrentCellPoint.Y && !mobjDataGridViewOper[16384] && (dataGridViewElementStates & DataGridViewElementStates.ReadOnly) == 0 && !ReadOnly && !Columns[mobjCurrentCellPoint.X].ReadOnly && ColumnEditable(mobjCurrentCellPoint.X) && !IsCurrentCellInEditMode && (EditMode == DataGridViewEditMode.EditOnEnter || (EditMode != DataGridViewEditMode.EditProgrammatically && CurrentCellInternal.EditType == null)))
			{
				BeginEditInternal(blnSelectAll: true);
			}
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowUnshared"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnRowUnshared(DataGridViewRowEventArgs e)
		{
			this.RowUnshared?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidated"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowValidated(DataGridViewCellEventArgs e)
		{
			this.RowValidated?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCancelEventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowValidating(DataGridViewCellCancelEventArgs e)
		{
			this.RowValidating?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.SortCompare"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSortCompareEventArgs"></see> that contains the event data. </param>
		protected virtual void OnSortCompare(DataGridViewSortCompareEventArgs e)
		{
			this.SortCompare?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.Sorted"></see> event. </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected virtual void OnSorted(EventArgs e)
		{
			this.Sorted?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.UserAddedRow"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnUserAddedRow(DataGridViewRowEventArgs e)
		{
			this.UserAddedRow?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.UserDeletedRow"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
		protected virtual void OnUserDeletedRow(DataGridViewRowEventArgs e)
		{
			this.UserDeletedRow?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.UserDeletingRow"></see> event.</summary>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCancelEventArgs"></see> that contains the event data. </param>
		protected virtual void OnUserDeletingRow(DataGridViewRowCancelEventArgs e)
		{
			this.UserDeletingRow?.Invoke(this, e);
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Validating"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.ComponentModel.CancelEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.Exception">Validation failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
		protected override void OnValidating(CancelEventArgs e)
		{
			Control editingControl = EditingControl;
			if (!base.BecomingActiveControl && (editingControl == null || !editingControl.BecomingActiveControl))
			{
				if (!mobjDataGridViewState1[64] && !EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.LeaveControl | DataGridViewDataErrorContexts.Parsing, DataGridViewValidateCellInternal.Always, blnFireCellLeave: false, blnFireCellEnter: false, blnFireRowLeave: false, blnFireRowEnter: false, blnFireLeave: false, blnKeepFocus: false, blnResetCurrentCell: false, blnResetAnchorCell: false))
				{
					e.Cancel = true;
					return;
				}
				if (mobjCurrentCellPoint.X >= 0)
				{
					DataGridViewCell objDataGridViewCell = null;
					if (OnRowValidating(ref objDataGridViewCell, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y))
					{
						e.Cancel = true;
						return;
					}
					if (mobjCurrentCellPoint.X == -1)
					{
						return;
					}
					OnRowValidated(ref objDataGridViewCell, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
					if (DataSource != null && mobjCurrentCellPoint.X >= 0 && AllowUserToAddRowsInternal && NewRowIndex == mobjCurrentCellPoint.Y)
					{
						int previousRow = Rows.GetPreviousRow(mobjCurrentCellPoint.Y, DataGridViewElementStates.Visible);
						if (previousRow > -1)
						{
							SetAndSelectCurrentCellAddress(mobjCurrentCellPoint.X, previousRow, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false, blnClearSelection: false, blnForceCurrentCellSelection: false);
						}
						else
						{
							SetCurrentCellAddressCore(-1, -1, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false);
						}
					}
				}
			}
			base.OnValidating(e);
		}

		/// 
		///
		/// </summary>
		/// <param name="e"></param>
		protected override void OnVisibleChanged(EventArgs e)
		{
			base.OnVisibleChanged(e);
			if (NeedToAdjustFillingColumns)
			{
				ResetUIState(blnUseRowShortcut: false, blnComputeVisibleRows: false);
			}
		}

		/// Paints the background of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to paint the background.</param>
		/// <param name="objClipBounds">A <see cref="T:System.Drawing.Rectangle"></see> that represents the area of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that needs to be painted.</param>
		/// <param name="objGridBounds">A <see cref="T:System.Drawing.Rectangle"></see> that represents the area in which cells are drawn.</param>
		protected virtual void PaintBackground(Graphics objGraphics, Rectangle objClipBounds, Rectangle objGridBounds)
		{
		}

		/// Processes the A key.</summary>
		/// true if the key was processed; otherwise, false.</returns>
		/// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
		protected bool ProcessAKey(Keys enmKeyData)
		{
			return false;
		}

		/// Processes keys used for navigating in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// true if the key was processed; otherwise, false.</returns>
		/// <param name="e">Contains information about the key that was pressed.</param>
		/// <exception cref="T:System.InvalidCastException">The key pressed would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		/// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true.-or-The DELETE key would delete one or more rows, but an error in the data source prevents the deletion and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		protected virtual bool ProcessDataGridViewKey(KeyEventArgs e)
		{
			return false;
		}

		/// Processes the DELETE key.</summary>
		/// true if the key was processed; otherwise, false.</returns>
		/// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
		/// <exception cref="T:System.Exception">The DELETE key would delete one or more rows, but an error in the data source prevents the deletion and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		protected bool ProcessDeleteKey(Keys enmKeyData)
		{
			if (AllowUserToDeleteRowsInternal)
			{
				DataGridViewSelectionMode selectionMode = SelectionMode;
				if (selectionMode == DataGridViewSelectionMode.FullRowSelect || selectionMode == DataGridViewSelectionMode.RowHeaderSelect)
				{
					int num = 0;
					try
					{
						SelectedBandSnapshotIndexes = new DataGridViewIntLinkedList(SelectedBandIndexes);
						while (SelectedBandSnapshotIndexes.Count > num)
						{
							int num2 = SelectedBandSnapshotIndexes[num];
							if (num2 == NewRowIndex || num2 >= Rows.Count)
							{
								num++;
								continue;
							}
							DataGridViewRowCancelEventArgs e = new DataGridViewRowCancelEventArgs(Rows[num2]);
							OnUserDeletingRow(e);
							if (!e.Cancel)
							{
								DataGridViewRow objDataGridViewRow = Rows[num2];
								if (DataSource != null)
								{
									int count = Rows.Count;
									DataGridViewDataErrorEventArgs e2 = null;
									try
									{
										DataConnection.DeleteRow(num2);
									}
									catch (Exception objException)
									{
										if (ClientUtils.IsCriticalException(objException))
										{
											throw;
										}
										e2 = new DataGridViewDataErrorEventArgs(objException, -1, num2, DataGridViewDataErrorContexts.RowDeletion);
										OnDataErrorInternal(e2);
										if (e2.ThrowException)
										{
											throw e2.Exception;
										}
										num++;
									}
									if (count != Rows.Count)
									{
										DataGridViewRowEventArgs e3 = new DataGridViewRowEventArgs(objDataGridViewRow);
										OnUserDeletedRow(e3);
									}
									else if (e2 == null)
									{
										num++;
									}
								}
								else
								{
									Rows.RemoveAtInternal(num2, blnForce: false);
									DataGridViewRowEventArgs e4 = new DataGridViewRowEventArgs(objDataGridViewRow);
									OnUserDeletedRow(e4);
								}
							}
							else
							{
								num++;
							}
						}
					}
					finally
					{
						SelectedBandSnapshotIndexes = null;
					}
					return true;
				}
			}
			return false;
		}

		/// Processes the DOWN ARROW key.</summary>
		/// true if the key was processed; otherwise, false.</returns>
		/// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
		/// <exception cref="T:System.InvalidCastException">The DOWN ARROW key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		/// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		protected bool ProcessDownKey(Keys enmKeyData)
		{
			return false;
		}

		/// Processes the END key.</summary>
		/// true if the key was processed; otherwise, false.</returns>
		/// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
		/// <exception cref="T:System.InvalidCastException">The END key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		/// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		protected bool ProcessEndKey(Keys enmKeyData)
		{
			return false;
		}

		/// Processes the ENTER key.</summary>
		/// true if the key was processed; otherwise, false.</returns>
		/// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
		/// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		/// <exception cref="T:System.InvalidCastException">The ENTER key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		protected bool ProcessEnterKey(Keys enmKeyData)
		{
			return false;
		}

		/// Processes the ESC key.</summary>
		/// true if the key was processed; otherwise, false. </returns>
		/// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
		protected bool ProcessEscapeKey(Keys enmKeyData)
		{
			return false;
		}

		/// Processes the F2 key.</summary>
		/// true if the key was processed; otherwise, false. </returns>
		/// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
		/// <exception cref="T:System.Exception">The F2 key would cause the control to enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		/// <exception cref="T:System.InvalidCastException">The F2 key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		protected bool ProcessF2Key(Keys enmKeyData)
		{
			return false;
		}

		/// Processes the HOME key.</summary>
		/// true if the key was processed; otherwise, false.</returns>
		/// <param name="enmKeyData">The key that was pressed.</param>
		/// <exception cref="T:System.InvalidCastException">The HOME key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		/// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		protected bool ProcessHomeKey(Keys enmKeyData)
		{
			return false;
		}

		/// Processes the INSERT key.</summary>
		/// true if the key was processed; otherwise, false.</returns>
		/// <param name="enmKeyData">One of the <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key to process.</param>
		protected bool ProcessInsertKey(Keys enmKeyData)
		{
			return false;
		}

		/// Processes the LEFT ARROW key.</summary>
		/// true if the key was processed; otherwise, false.</returns>
		/// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
		/// <exception cref="T:System.InvalidCastException">The LEFT ARROW key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		/// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		protected bool ProcessLeftKey(Keys enmKeyData)
		{
			return false;
		}

		/// Processes the PAGE DOWN key.</summary>
		/// true if the key was processed; otherwise, false.</returns>
		/// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
		/// <exception cref="T:System.InvalidCastException">The PAGE DOWN key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		/// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		protected bool ProcessNextKey(Keys enmKeyData)
		{
			return false;
		}

		/// Processes the PAGE UP key.</summary>
		/// true if the key was processed; otherwise, false.</returns>
		/// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
		/// <exception cref="T:System.InvalidCastException">The PAGE UP key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		/// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		protected bool ProcessPriorKey(Keys enmKeyData)
		{
			return false;
		}

		/// Processes the RIGHT ARROW key.</summary>
		/// true if the key was processed; otherwise, false.</returns>
		/// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
		/// <exception cref="T:System.InvalidCastException">The RIGHT ARROW key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		/// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		protected bool ProcessRightKey(Keys enmKeyData)
		{
			return false;
		}

		/// Processes the SPACEBAR.</summary>
		/// true if the key was processed; otherwise, false.</returns>
		/// <param name="enmKeyData">One of the <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key to process.</param>
		protected bool ProcessSpaceKey(Keys enmKeyData)
		{
			return false;
		}

		/// Processes the TAB key.</summary>
		/// true if the key was processed; otherwise, false. </returns>
		/// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
		/// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		/// <exception cref="T:System.InvalidCastException">The TAB key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		protected bool ProcessTabKey(Keys enmKeyData)
		{
			return false;
		}

		/// Processes the UP ARROW key.</summary>
		/// true if the key was processed; otherwise, false.</returns>
		/// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
		/// <exception cref="T:System.InvalidCastException">The UP ARROW key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the new current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		/// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		protected bool ProcessUpKey(Keys enmKeyData)
		{
			return false;
		}

		/// Processes the 0 key.</summary>
		/// true if the key was processed; otherwise, false.</returns>
		/// <param name="enmKeyData">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.Keys"></see> values that represents the key or keys to process.</param>
		/// <exception cref="T:System.InvalidCastException">The 0 key would cause the control to enter edit mode, but the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.EditType"></see> property of the current cell does not indicate a class that derives from <see cref="T:Gizmox.WebGUI.Forms.Control"></see> and implements <see cref="T:Gizmox.WebGUI.Forms.IDataGridViewEditingControl"></see>.</exception>
		/// <exception cref="T:System.Exception">This action would cause the control to enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		protected bool ProcessZeroKey(Keys enmKeyData)
		{
			return false;
		}

		/// Refreshes the value of the current cell with the underlying cell value when the cell is in edit mode, discarding any previous value.</summary>
		/// true if successful; false if a <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event occurred.</returns>
		/// 1</filterpriority>
		public bool RefreshEdit()
		{
			if (mobjCurrentCellPoint.X == -1 || !IsCurrentCellInEditMode)
			{
				return true;
			}
			DataGridViewCell objDataGridViewCell = CurrentCellInternal;
			DataGridViewCellStyle objDataGridViewCellStyle = objDataGridViewCell.GetInheritedStyle(null, mobjCurrentCellPoint.Y, blnIncludeColors: true);
			if (EditingControl != null)
			{
				if (!InitializeEditingControlValue(ref objDataGridViewCellStyle, objDataGridViewCell))
				{
					return false;
				}
				((IDataGridViewEditingControl)EditingControl).PrepareEditingControlForEdit(blnSelectAll: true);
				((IDataGridViewEditingControl)EditingControl).EditingControlValueChanged = false;
				IsCurrentCellDirtyInternal = false;
				return true;
			}
			if (InitializeEditingCellValue(ref objDataGridViewCellStyle, ref objDataGridViewCell))
			{
				IDataGridViewEditingCell dataGridViewEditingCell = objDataGridViewCell as IDataGridViewEditingCell;
				dataGridViewEditingCell.PrepareEditingCellForEdit(blnSelectAll: true);
				dataGridViewEditingCell.EditingCellValueChanged = false;
				IsCurrentCellDirtyInternal = false;
				return true;
			}
			return false;
		}

		/// Resets the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.Text"></see> property to its default value.</summary>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void ResetText()
		{
		}

		/// 
		/// Resets the color of the background.
		/// </summary>
		private void ResetBackgroundColor()
		{
			BackgroundColor = DefaultBackgroundBrush.Color;
		}

		private bool InitializeEditingCellValue(ref DataGridViewCellStyle objDataGridViewCellStyle, ref DataGridViewCell objDataGridViewCell)
		{
			DataGridViewDataErrorEventArgs e = null;
			object formattedValue = objDataGridViewCell.GetFormattedValue(mobjCurrentCellPoint.Y, ref objDataGridViewCellStyle, DataGridViewDataErrorContexts.Formatting);
			UneditedFormattedValue = objDataGridViewCell.GetFormattedValue(mobjCurrentCellPoint.Y, ref objDataGridViewCellStyle, DataGridViewDataErrorContexts.Formatting);
			mobjDataGridViewState1[512] = true;
			try
			{
				object editingCellFormattedValue = (objDataGridViewCell as IDataGridViewEditingCell).GetEditingCellFormattedValue(DataGridViewDataErrorContexts.Formatting);
				if ((editingCellFormattedValue == null && formattedValue != null) || (editingCellFormattedValue != null && formattedValue == null) || (editingCellFormattedValue != null && !formattedValue.Equals(editingCellFormattedValue)))
				{
					objDataGridViewCell = Rows[mobjCurrentCellPoint.Y].Cells[mobjCurrentCellPoint.X];
					IDataGridViewEditingCell dataGridViewEditingCell = objDataGridViewCell as IDataGridViewEditingCell;
					dataGridViewEditingCell.EditingCellFormattedValue = formattedValue;
					dataGridViewEditingCell.EditingCellValueChanged = false;
				}
			}
			catch (Exception objException)
			{
				if (ClientUtils.IsCriticalException(objException))
				{
					throw;
				}
				e = new DataGridViewDataErrorEventArgs(objException, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y, DataGridViewDataErrorContexts.InitialValueRestoration);
				OnDataErrorInternal(e);
			}
			finally
			{
				mobjDataGridViewState1[512] = false;
			}
			if (e == null)
			{
				return true;
			}
			if (e.ThrowException)
			{
				throw e.Exception;
			}
			return !e.Cancel;
		}

		private bool InitializeEditingControlValue(ref DataGridViewCellStyle objDataGridViewCellStyle, DataGridViewCell objDataGridViewCell)
		{
			DataGridViewDataErrorEventArgs e = null;
			object formattedValue = objDataGridViewCell.GetFormattedValue(mobjCurrentCellPoint.Y, ref objDataGridViewCellStyle, DataGridViewDataErrorContexts.Formatting);
			mobjDataGridViewState1[16384] = true;
			mobjDataGridViewState1[512] = true;
			try
			{
				objDataGridViewCell.InitializeEditingControl(mobjCurrentCellPoint.Y, formattedValue, objDataGridViewCellStyle);
				((IDataGridViewEditingControl)EditingControl).EditingControlValueChanged = false;
			}
			catch (Exception objException)
			{
				if (ClientUtils.IsCriticalException(objException))
				{
					throw;
				}
				e = new DataGridViewDataErrorEventArgs(objException, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y, DataGridViewDataErrorContexts.InitialValueRestoration);
				OnDataErrorInternal(e);
			}
			finally
			{
				mobjDataGridViewState1[16384] = false;
				mobjDataGridViewState1[512] = false;
			}
			if (e != null)
			{
				if (e.ThrowException)
				{
					throw e.Exception;
				}
				return !e.Cancel;
			}
			UneditedFormattedValue = formattedValue;
			return true;
		}

		private void PushAllowUserToAddRows()
		{
			if (AllowUserToAddRowsInternal)
			{
				if (Columns.Count > 0 && NewRowIndex == -1)
				{
					AddNewRow(blnCreatedByEditing: false);
				}
			}
			else if (NewRowIndex != -1)
			{
				Rows.RemoveAtInternal(NewRowIndex, blnForce: false);
			}
		}

		internal void AddNewRow(bool blnCreatedByEditing)
		{
			DataGridViewRowCollection rows = Rows;
			rows.AddInternal(blnNewRow: true, null);
			NewRowIndex = rows.Count - 1;
			mobjDataGridViewState1[2097152] = blnCreatedByEditing;
			if (blnCreatedByEditing)
			{
				OnUserAddedRow(new DataGridViewRowEventArgs(rows[NewRowIndex]));
			}
			Update();
		}

		private void InvalidateRows(int intLow, int intHigh)
		{
		}

		private void PopulateNewRowWithDefaultValues()
		{
			if (NewRowIndex == -1)
			{
				return;
			}
			DataGridViewRowCollection rows = Rows;
			DataGridViewRow dataGridViewRow = rows.SharedRow(NewRowIndex);
			DataGridViewCellCollection cells = dataGridViewRow.Cells;
			foreach (DataGridViewCell item in cells)
			{
				if (item.DefaultNewRowValue != null)
				{
					dataGridViewRow = rows[NewRowIndex];
					cells = dataGridViewRow.Cells;
					break;
				}
			}
			foreach (DataGridViewCell item2 in cells)
			{
				item2.SetValueInternal(NewRowIndex, item2.DefaultNewRowValue);
			}
		}

		/// Selects all the cells in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
		/// 1</filterpriority>
		public void SelectAll()
		{
		}

		/// 
		/// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.Control"></see> and its child controls and optionally releases the managed resources.
		/// </summary>
		/// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool blnDisposing)
		{
			if (blnDisposing)
			{
				mobjDataGridViewOper[1048576] = true;
				try
				{
					for (int i = 0; i < Columns.Count; i++)
					{
						Columns[i].Dispose();
					}
					Columns.Clear();
					Control latestEditingControl = LatestEditingControl;
					if (latestEditingControl != null)
					{
						latestEditingControl.Dispose();
						LatestEditingControl = null;
					}
					Control editingControl = EditingControl;
					if (editingControl != null)
					{
						editingControl.Dispose();
						EditingControl = null;
					}
					DataConnection?.Dispose();
				}
				finally
				{
					mobjDataGridViewOper[1048576] = false;
				}
			}
			base.Dispose(blnDisposing);
		}

		/// Sets the currently active cell.</summary>
		/// true if the current cell was successfully set; otherwise, false.</returns>
		/// <param name="blnValidateCurrentCell">true to validate the value in the old current cell and cancel the change if validation fails; otherwise, false.</param>
		/// <param name="intColumnIndex">The index of the column containing the cell.</param>
		/// <param name="blnThroughMouseClick">true if the current cell is being set as a result of a mouse click; otherwise, false.</param>
		/// <param name="intRowIndex">The index of the row containing the cell.</param>
		/// <param name="blnSetAnchorCellAddress">true to make the new current cell the anchor cell for a subsequent multicell selection using the SHIFT key; otherwise, false.</param>
		/// <exception cref="T:System.InvalidCastException">The new current cell tried to enter edit mode, but its <see cref="P:System.Windows.Forms.DataGridViewCell.EditType"></see> property does not indicate a class that derives from <see cref="T:System.Windows.Forms.Control"></see> and implements <see cref="T:System.Windows.Forms.IDataGridViewEditingControl"></see>.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than 0 or greater than the number of columns in the control minus 1, and rowIndex is not -1.-or-rowIndex is less than 0 or greater than the number of rows in the control minus 1, and columnIndex is not -1.</exception>
		/// <exception cref="T:System.InvalidOperationException">The specified cell has a <see cref="P:System.Windows.Forms.DataGridViewCell.Visible"></see> property value of false.-or-This method was called for a reason other than the underlying data source being reset, and another thread is currently executing this method.</exception>
		protected virtual bool SetCurrentCellAddressCore(int intColumnIndex, int intRowIndex, bool blnSetAnchorCellAddress, bool blnValidateCurrentCell, bool blnThroughMouseClick)
		{
			return SetCurrentCellAddressCore(intColumnIndex, intRowIndex, blnSetAnchorCellAddress, blnValidateCurrentCell, blnThroughMouseClick, blnClientSource: false);
		}

		/// 
		/// Sets the currently active cell.
		/// </summary>
		/// <param name="intColumnIndex">The index of the column containing the cell.</param>
		/// <param name="intRowIndex">The index of the row containing the cell.</param>
		/// <param name="blnSetAnchorCellAddress">true to make the new current cell the anchor cell for a subsequent multicell selection using the SHIFT key; otherwise, false.</param>
		/// <param name="blnValidateCurrentCell">true to validate the value in the old current cell and cancel the change if validation fails; otherwise, false.</param>
		/// <param name="blnThroughMouseClick">true if the current cell is being set as a result of a mouse click; otherwise, false.</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		/// 
		/// true if the current cell was successfully set; otherwise, false.
		/// </returns>
		/// <exception cref="T:System.InvalidCastException">The new current cell tried to enter edit mode, but its <see cref="P:System.Windows.Forms.DataGridViewCell.EditType"></see> property does not indicate a class that derives from <see cref="T:System.Windows.Forms.Control"></see> and implements <see cref="T:System.Windows.Forms.IDataGridViewEditingControl"></see>.</exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than 0 or greater than the number of columns in the control minus 1, and rowIndex is not -1.-or-rowIndex is less than 0 or greater than the number of rows in the control minus 1, and columnIndex is not -1.</exception>
		/// <exception cref="T:System.InvalidOperationException">The specified cell has a <see cref="P:System.Windows.Forms.DataGridViewCell.Visible"></see> property value of false.-or-This method was called for a reason other than the underlying data source being reset, and another thread is currently executing this method.</exception>
		private bool SetCurrentCellAddressCore(int intColumnIndex, int intRowIndex, bool blnSetAnchorCellAddress, bool blnValidateCurrentCell, bool blnThroughMouseClick, bool blnClientSource)
		{
			DataGridViewRowCollection rows = Rows;
			if (intColumnIndex < -1 || (intColumnIndex >= 0 && intRowIndex == -1) || intColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("columnIndex");
			}
			if (intRowIndex < -1 || (intColumnIndex == -1 && intRowIndex >= 0) || intRowIndex >= rows.Count)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			if (intColumnIndex > -1 && intRowIndex > -1 && !IsSharedCellVisible(rows.SharedRow(intRowIndex).Cells[intColumnIndex], intRowIndex))
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CurrentCellCannotBeInvisible"));
			}
			DataGridViewDataConnection dataConnection = DataConnection;
			Control editingControl = EditingControl;
			Control cachedEditingControl = CachedEditingControl;
			if (mobjDataGridViewOper[131072] && (dataConnection == null || !dataConnection.ProcessingListChangedEvent))
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_SetCurrentCellAddressCoreNotReentrant"));
			}
			mobjDataGridViewOper[131072] = true;
			try
			{
				DataGridViewCell objDataGridViewCell = null;
				if (intColumnIndex > -1)
				{
					if (mobjCurrentCellPoint.X != intColumnIndex || mobjCurrentCellPoint.Y != intRowIndex)
					{
						if (mobjDataGridViewState1[4194304])
						{
							mobjDataGridViewState1[4194304] = false;
							mobjCurrentCellPoint.X = intColumnIndex;
							mobjCurrentCellPoint.Y = intRowIndex;
							if (!blnClientSource)
							{
								UpdateParams(AttributeType.Visual);
							}
							if (cachedEditingControl != null)
							{
								Control control = (EditingControl = cachedEditingControl);
								editingControl = control;
								((IDataGridViewEditingControl)editingControl).EditingControlRowIndex = intRowIndex;
								control = (CachedEditingControl = null);
								cachedEditingControl = control;
							}
							OnCurrentCellChanged(EventArgs.Empty);
							return true;
						}
						int x = mobjCurrentCellPoint.X;
						int y = mobjCurrentCellPoint.Y;
						if (x >= 0)
						{
							DataGridViewCell dataGridViewCell = CurrentCellInternal;
							if (!EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.CurrentCellChange | DataGridViewDataErrorContexts.Parsing, blnValidateCurrentCell ? DataGridViewValidateCellInternal.Always : DataGridViewValidateCellInternal.Never, blnValidateCurrentCell, blnFireCellEnter: false, blnValidateCurrentCell && y != intRowIndex, blnFireRowEnter: false, blnFireLeave: false, EditMode != DataGridViewEditMode.EditOnEnter, blnResetCurrentCell: false, blnResetAnchorCell: false, blnClientSource))
							{
								return false;
							}
							if (!IsInnerCellOutOfBounds(x, y))
							{
								dataGridViewCell = rows.SharedRow(y).Cells[x];
								if (dataGridViewCell.LeaveUnsharesRowInternal(y, blnThroughMouseClick))
								{
									dataGridViewCell = rows[y].Cells[x];
								}
								dataGridViewCell.OnLeaveInternal(y, blnThroughMouseClick);
							}
							if (IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
							{
								return false;
							}
							if (y != intRowIndex && blnValidateCurrentCell)
							{
								if (OnRowValidating(ref objDataGridViewCell, x, y))
								{
									if (!IsInnerCellOutOfBounds(x, y))
									{
										OnRowEnter(ref objDataGridViewCell, x, y, blnCanCreateNewRow: true, blnValidationFailureOccurred: true);
										if (!IsInnerCellOutOfBounds(x, y))
										{
											dataGridViewCell.OnEnterInternal(y, blnThroughMouseClick);
											OnCellEnter(ref objDataGridViewCell, x, y);
										}
									}
									return false;
								}
								if (!IsInnerCellOutOfBounds(x, y))
								{
									OnRowValidated(ref objDataGridViewCell, x, y, blnClientSource);
								}
							}
						}
						mobjDataGridViewState2[4194304] = false;
						try
						{
							if (y != intRowIndex && !IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
							{
								OnRowEnter(ref objDataGridViewCell, intColumnIndex, intRowIndex, blnCanCreateNewRow: true, blnValidationFailureOccurred: false);
							}
							if (mobjDataGridViewState2[4194304] && intRowIndex >= rows.Count)
							{
								return false;
							}
							if (IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
							{
								return false;
							}
							mobjCurrentCellPoint.X = intColumnIndex;
							mobjCurrentCellPoint.Y = intRowIndex;
							if (!blnClientSource)
							{
								UpdateParams(AttributeType.Visual);
							}
							if (editingControl != null)
							{
								((IDataGridViewEditingControl)editingControl).EditingControlRowIndex = intRowIndex;
							}
							OnCurrentCellChanged(EventArgs.Empty);
							DataGridViewCell dataGridViewCell = CurrentCellInternal;
							if (dataGridViewCell.EnterUnsharesRowInternal(intRowIndex, blnThroughMouseClick))
							{
								dataGridViewCell = rows[intRowIndex].Cells[intColumnIndex];
							}
							dataGridViewCell.OnEnterInternal(intRowIndex, blnThroughMouseClick);
							OnCellEnter(ref objDataGridViewCell, mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
							if (x >= 0)
							{
								if (x < Columns.Count && y < rows.Count && (this[x, y].ClientState | DataGridViewElementClientStates.CurrentCell) != DataGridViewElementClientStates.CurrentCell)
								{
									InvalidateCellPrivate(x, y);
								}
								if (y != mobjCurrentCellPoint.Y && RowHeadersVisible && y < rows.Count)
								{
									InvalidateCellPrivate(-1, y);
								}
							}
							if ((this[mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y].ClientState | DataGridViewElementClientStates.CurrentCell) != DataGridViewElementClientStates.CurrentCell)
							{
								InvalidateCellPrivate(mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
							}
							if (RowHeadersVisible && y != mobjCurrentCellPoint.Y)
							{
								InvalidateCellPrivate(-1, mobjCurrentCellPoint.Y);
							}
							if (Focused && mobjCurrentCellPoint.X != -1 && !IsCurrentCellInEditMode && !mobjDataGridViewState2[4194304] && (EditMode == DataGridViewEditMode.EditOnEnter || (EditMode != DataGridViewEditMode.EditProgrammatically && dataGridViewCell.EditType == null)))
							{
								BeginEditInternal(blnSelectAll: true, blnClientSource);
							}
						}
						finally
						{
							mobjDataGridViewState2[4194304] = false;
						}
						if (mobjCurrentCellPoint.X != -1)
						{
							AccessibilityNotifyCurrentCellChanged(new Point(mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y));
						}
					}
					else if (Focused && !IsCurrentCellInEditMode && (EditMode == DataGridViewEditMode.EditOnEnter || (EditMode != DataGridViewEditMode.EditProgrammatically && CurrentCellInternal.EditType == null)))
					{
						BeginEditInternal(blnSelectAll: true, blnClientSource);
					}
				}
				else
				{
					int x2 = mobjCurrentCellPoint.X;
					int y2 = mobjCurrentCellPoint.Y;
					if (x2 >= 0 && !mobjDataGridViewState1[4194304] && !mobjDataGridViewOper[1048576])
					{
						DataGridViewCell dataGridViewCell2 = CurrentCellInternal;
						if (!EndEdit(DataGridViewDataErrorContexts.Commit | DataGridViewDataErrorContexts.CurrentCellChange | DataGridViewDataErrorContexts.Parsing, blnValidateCurrentCell ? DataGridViewValidateCellInternal.Always : DataGridViewValidateCellInternal.Never, blnValidateCurrentCell, blnFireCellEnter: false, blnValidateCurrentCell, blnFireRowEnter: false, blnFireLeave: false, EditMode != DataGridViewEditMode.EditOnEnter, blnResetCurrentCell: false, blnResetAnchorCell: false))
						{
							return false;
						}
						if (!IsInnerCellOutOfBounds(x2, y2))
						{
							dataGridViewCell2 = rows.SharedRow(y2).Cells[x2];
							if (dataGridViewCell2.LeaveUnsharesRowInternal(y2, blnThroughMouseClick))
							{
								dataGridViewCell2 = rows[y2].Cells[x2];
							}
							dataGridViewCell2.OnLeaveInternal(y2, blnThroughMouseClick);
						}
						if (blnValidateCurrentCell)
						{
							if (OnRowValidating(ref objDataGridViewCell, x2, y2))
							{
								if (!IsInnerCellOutOfBounds(x2, y2))
								{
									OnRowEnter(ref objDataGridViewCell, x2, y2, blnCanCreateNewRow: true, blnValidationFailureOccurred: true);
									if (!IsInnerCellOutOfBounds(x2, y2))
									{
										dataGridViewCell2.OnEnterInternal(y2, blnThroughMouseClick);
										OnCellEnter(ref objDataGridViewCell, x2, y2);
									}
								}
								return false;
							}
							if (!IsInnerCellOutOfBounds(x2, y2))
							{
								OnRowValidated(ref objDataGridViewCell, x2, y2);
							}
						}
					}
					if (mobjCurrentCellPoint.X != -1)
					{
						mobjCurrentCellPoint.X = -1;
						mobjCurrentCellPoint.Y = -1;
						if (!blnClientSource)
						{
							UpdateParams(AttributeType.Visual);
						}
						OnCurrentCellChanged(EventArgs.Empty);
					}
					if (mobjDataGridViewState1[4194304])
					{
						if (editingControl != null)
						{
							Control control;
							if (mobjDataGridViewState2[536870912])
							{
								mobjDataGridViewState2[536870912] = false;
							}
							else
							{
								control = (CachedEditingControl = editingControl);
								cachedEditingControl = control;
							}
							control = (EditingControl = null);
							editingControl = control;
						}
					}
					else if (x2 >= 0 && !mobjDataGridViewOper[1048576])
					{
						if (x2 < Columns.Count && y2 < rows.Count && (this[x2, y2].ClientState | DataGridViewElementClientStates.CurrentCell) != DataGridViewElementClientStates.CurrentCell)
						{
							InvalidateCellPrivate(x2, y2);
						}
						if (RowHeadersVisible && y2 < rows.Count)
						{
							InvalidateCellPrivate(-1, y2);
						}
					}
				}
			}
			finally
			{
				mobjDataGridViewOper[131072] = false;
			}
			return true;
		}

		/// 
		/// Determines whether [is shared cell visible] [the specified data grid view cell].
		/// </summary>
		/// <param name="objDataGridViewCell">The data grid view cell.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// 
		/// 	true</c> if [is shared cell visible] [the specified data grid view cell]; otherwise, false</c>.
		/// </returns>
		internal bool IsSharedCellVisible(DataGridViewCell objDataGridViewCell, int intRowIndex)
		{
			if ((Rows.GetRowState(intRowIndex) & DataGridViewElementStates.Visible) == 0)
			{
				return false;
			}
			return objDataGridViewCell.OwningColumn != null && objDataGridViewCell.OwningColumn.Visible;
		}

		/// 
		/// Called when [row validated].
		/// </summary>
		/// <param name="objDataGridViewCell">The obj data grid view cell.</param>
		/// <param name="intColumnIndex">Index of the int column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		private void OnRowValidated(ref DataGridViewCell objDataGridViewCell, int intColumnIndex, int intRowIndex)
		{
			OnRowValidated(ref objDataGridViewCell, intColumnIndex, intRowIndex, blnClientSource: false);
		}

		/// 
		/// Called when [row validated].
		/// </summary>
		/// <param name="objDataGridViewCell">The obj data grid view cell.</param>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		private void OnRowValidated(ref DataGridViewCell objDataGridViewCell, int intColumnIndex, int intRowIndex, bool blnClientSource)
		{
			SetIsCurrentRowDirtyInternal(blnDirty: false, blnClientSource);
			mobjDataGridViewState1[2097152] = false;
			if (intRowIndex == NewRowIndex)
			{
				InvalidateRowPrivate(intRowIndex);
			}
			DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(intColumnIndex, intRowIndex);
			OnRowValidated(e);
			if (objDataGridViewCell != null)
			{
				if (IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
				{
					objDataGridViewCell = null;
				}
				else
				{
					objDataGridViewCell = Rows.SharedRow(intRowIndex).Cells[intColumnIndex];
				}
			}
		}

		/// 
		/// Called when [row validating].
		/// </summary>
		/// <param name="objDataGridViewCell">The data grid view cell.</param>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// </returns>
		private bool OnRowValidating(ref DataGridViewCell objDataGridViewCell, int intColumnIndex, int intRowIndex)
		{
			DataGridViewCellCancelEventArgs e = new DataGridViewCellCancelEventArgs(intColumnIndex, intRowIndex);
			OnRowValidating(e);
			if (!e.Cancel && DataConnection != null && DataConnection.InterestedInRowEvents && !DataConnection.PositionChangingOutsideDataGridView && !DataConnection.ListWasReset)
			{
				DataConnection.OnRowValidating(e);
			}
			DataGridViewRowCollection rows = Rows;
			if (objDataGridViewCell != null && intRowIndex < rows.Count && intColumnIndex < Columns.Count)
			{
				objDataGridViewCell = rows.SharedRow(intRowIndex).Cells[intColumnIndex];
			}
			return e.Cancel;
		}

		/// 
		/// Exits the bulk paint.
		/// </summary>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		private void ExitBulkPaint(int intColumnIndex, int intRowIndex)
		{
			if (BulkPaintCount <= 0)
			{
				return;
			}
			BulkPaintCount--;
			if (BulkPaintCount == 0)
			{
				if (intColumnIndex >= 0)
				{
					InvalidateColumnInternal(intColumnIndex);
				}
				else if (intRowIndex >= 0)
				{
					InvalidateRowPrivate(intRowIndex);
				}
				else
				{
					Invalidate();
				}
			}
		}

		/// 
		/// Invalidates the column internal.
		/// </summary>
		/// <param name="intColumnIndex">Index of the column.</param>
		internal void InvalidateColumnInternal(int intColumnIndex)
		{
			if (base.IsHandleCreated)
			{
				Update();
			}
		}

		/// 
		/// Invalidates the row private.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		private void InvalidateRowPrivate(int intRowIndex)
		{
		}

		/// 
		/// Sets the selected column core.
		/// </summary>
		/// <param name="intColumnIndex">The index of the column.</param>
		/// <param name="blnSelected">true to select the column; false to cancel the selection of the column.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than 0 or greater than the number of columns in the control minus 1.</exception>
		protected virtual void SetSelectedColumnCore(int intColumnIndex, bool blnSelected)
		{
			if (intColumnIndex < 0 || intColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("columnIndex");
			}
			SelectionChangeCount++;
			try
			{
				if (Columns[intColumnIndex].Selected != blnSelected)
				{
					if (blnSelected)
					{
						RemoveIndividuallySelectedCellsInColumn(intColumnIndex);
						Columns[intColumnIndex].SelectedInternal = true;
						SelectedBandIndexes.Add(intColumnIndex);
					}
					else
					{
						Columns[intColumnIndex].SelectedInternal = false;
						SelectedBandIndexes.Remove(intColumnIndex);
					}
				}
				else if (!blnSelected)
				{
					RemoveIndividuallySelectedCellsInColumn(intColumnIndex);
				}
			}
			finally
			{
				NoSelectionChangeCount--;
			}
		}

		/// 
		/// Removes the individually selected cells in column.
		/// </summary>
		/// <param name="intColumnIndex">Index of the column.</param>
		private void RemoveIndividuallySelectedCellsInColumn(int intColumnIndex)
		{
			int num = 0;
			int num2 = 0;
			bool flag = false;
			DataGridViewCellLinkedList individualSelectedCells = IndividualSelectedCells;
			while (num < individualSelectedCells.Count)
			{
				DataGridViewCell dataGridViewCell = individualSelectedCells[num];
				if (dataGridViewCell.ColumnIndex == intColumnIndex)
				{
					SetSelectedCellCore(dataGridViewCell.ColumnIndex, dataGridViewCell.RowIndex, blnSelected: false);
					num2++;
					if (num2 > 8)
					{
						flag = true;
						break;
					}
				}
				else
				{
					num++;
				}
			}
			if (!flag)
			{
				return;
			}
			BulkPaintCount++;
			try
			{
				while (num < individualSelectedCells.Count)
				{
					DataGridViewCell dataGridViewCell = individualSelectedCells[num];
					if (dataGridViewCell.ColumnIndex == intColumnIndex)
					{
						SetSelectedCellCore(dataGridViewCell.ColumnIndex, dataGridViewCell.RowIndex, blnSelected: false);
					}
					else
					{
						num++;
					}
				}
			}
			finally
			{
				ExitBulkPaint(intColumnIndex, -1);
			}
		}

		/// 
		/// Sets the selected row core.
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="blnSelected">if set to true</c> [selected].</param>
		protected virtual void SetSelectedRowCore(int intRowIndex, bool blnSelected)
		{
			SetSelectedRowCore(intRowIndex, blnSelected, blnClientSource: false);
		}

		private void SetSelectedRowCore(int intRowIndex, bool blnSelected, bool blnClientSource)
		{
			DataGridViewRowCollection rows = Rows;
			if (intRowIndex < 0 || intRowIndex >= rows.Count)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			SelectionChangeCount++;
			try
			{
				if ((rows.GetRowState(intRowIndex) & DataGridViewElementStates.Selected) != 0 != blnSelected)
				{
					if (blnSelected)
					{
						RemoveIndividuallySelectedCellsInRow(intRowIndex, blnClientSource);
						SelectedBandIndexes.Add(intRowIndex);
						rows.SetRowState(intRowIndex, DataGridViewElementStates.Selected, blnValue: true);
					}
					else
					{
						SelectedBandIndexes.Remove(intRowIndex);
						rows.SetRowState(intRowIndex, DataGridViewElementStates.Selected, blnValue: false);
					}
					if (!blnClientSource)
					{
						rows[intRowIndex].UpdateParams(AttributeType.Visual);
					}
				}
				else if (!blnSelected)
				{
					RemoveIndividuallySelectedCellsInRow(intRowIndex, blnClientSource);
				}
			}
			finally
			{
				NoSelectionChangeCount--;
			}
		}

		/// 
		/// Flushes the selection changed.
		/// </summary>
		private void FlushSelectionChanged()
		{
			if (mobjDataGridViewState2[262144])
			{
				OnSelectionChanged(EventArgs.Empty);
			}
		}

		private void RemoveIndividuallySelectedCellsInRow(int intRowIndex, bool blnClientSource)
		{
			int num = 0;
			DataGridViewCellLinkedList individualSelectedCells = IndividualSelectedCells;
			while (num < individualSelectedCells.Count)
			{
				DataGridViewCell dataGridViewCell = individualSelectedCells[num];
				if (dataGridViewCell.RowIndex == intRowIndex)
				{
					SetSelectedCellCore(dataGridViewCell.ColumnIndex, dataGridViewCell.RowIndex, blnSelected: false, blnClientSource);
				}
				else
				{
					num++;
				}
			}
		}

		/// Sorts the contents of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control using an implementation of the <see cref="T:System.Collections.IComparer"></see> interface.</summary>
		/// <param name="objComparer">An implementation of <see cref="T:System.Collections.IComparer"></see> that performs the custom sorting operation. </param>
		/// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> is set to true.-or- <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> is not null.</exception>
		/// <exception cref="T:System.ArgumentNullException">comparer is null.</exception>
		/// 1</filterpriority>
		public virtual void Sort(IComparer objComparer)
		{
			if (objComparer == null)
			{
				throw new ArgumentNullException("comparer");
			}
			if (VirtualMode)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_OperationDisabledInVirtualMode"));
			}
			if (DataSource != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotUseAComparerToSortDataGridViewWhenDataBound"));
			}
			SortInternal(objComparer, null, ListSortDirection.Ascending);
		}

		private void SortInternal(IComparer objComparer, DataGridViewColumn objDataGridViewColumn, ListSortDirection enmDirection)
		{
			DisplayedBandsData displayedBandsInfo = DisplayedBandsInfo;
			mobjCurrentCellCache.X = mobjCurrentCellPoint.X;
			mobjCurrentCellCache.Y = mobjCurrentCellPoint.Y;
			mobjDataGridViewOper[64] = true;
			try
			{
				if (!SetCurrentCellAddressCore(-1, -1, blnSetAnchorCellAddress: true, blnValidateCurrentCell: true, blnThroughMouseClick: false))
				{
					return;
				}
				int firstDisplayedScrollingRow = displayedBandsInfo.FirstDisplayedScrollingRow;
				DataGridViewRowCollection rows = Rows;
				int num = rows.GetRowCount(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
				if (num > 0 && DataSource == null)
				{
					int firstRow = rows.GetFirstRow(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
					rows.SetRowState(firstRow, DataGridViewElementStates.Frozen, blnValue: false);
				}
				if (SortedColumn != null && SortedColumn.SortMode == DataGridViewColumnSortMode.Automatic && SortedColumn.HasHeaderCell)
				{
					SortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
				}
				if (objComparer == null)
				{
					SortedColumn = objDataGridViewColumn;
					SortOrder = ((enmDirection == ListSortDirection.Ascending) ? SortOrder.Ascending : SortOrder.Descending);
					if (objDataGridViewColumn.SortMode == DataGridViewColumnSortMode.Automatic && objDataGridViewColumn.HasHeaderCell)
					{
						objDataGridViewColumn.HeaderCell.SortGlyphDirection = SortOrder;
					}
				}
				else
				{
					SortedColumn = null;
					SortOrder = SortOrder.None;
				}
				if (DataSource == null)
				{
					UpdateRowsDisplayedState(blnDisplayed: false);
					rows.Sort(objComparer, enmDirection == ListSortDirection.Ascending);
				}
				else
				{
					SortDataBoundDataGridView_PerformCheck(objDataGridViewColumn);
					DataConnection.Sort(objDataGridViewColumn, enmDirection);
				}
				if (mobjCurrentCellCache.X != -1 && !IsInnerCellOutOfBounds(mobjCurrentCellCache.X, mobjCurrentCellCache.Y))
				{
					SetAndSelectCurrentCellAddress(mobjCurrentCellCache.X, mobjCurrentCellCache.Y, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false, blnClearSelection: false, blnForceCurrentCellSelection: false);
				}
				if (num > 0)
				{
					int num2 = rows.GetFirstRow(DataGridViewElementStates.Visible);
					while (num > 1)
					{
						num2 = rows.GetNextRow(num2, DataGridViewElementStates.Visible);
						num--;
					}
					rows.SetRowState(num2, DataGridViewElementStates.Frozen, blnValue: true);
				}
				displayedBandsInfo.FirstDisplayedScrollingRow = firstDisplayedScrollingRow;
			}
			finally
			{
				mobjDataGridViewOper[64] = false;
			}
			OnGlobalAutoSize();
			if (DataSource == null)
			{
				displayedBandsInfo.EnsureDirtyState();
			}
			ResetUIState(blnUseRowShortcut: false, blnComputeVisibleRows: false);
			OnSorted(EventArgs.Empty);
		}

		/// Sorts the contents of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control in ascending or descending order based on the contents of the specified column.</summary>
		/// <param name="enmDirection">One of the <see cref="T:System.ComponentModel.ListSortDirection"></see> values. </param>
		/// <param name="objDataGridViewColumn">The column by which to sort the contents of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </param>
		/// <exception cref="T:System.ArgumentException">The specified column is not part of this <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property has been set and the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.IsDataBound"></see> property of the specified column returns false.</exception>
		/// <exception cref="T:System.ArgumentNullException">dataGridViewColumn is null.</exception>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.VirtualMode"></see> property is set to true and the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.IsDataBound"></see> property of the specified column returns false.-or-The object specified by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property does not implement the <see cref="T:System.ComponentModel.IBindingList"></see> interface.-or-The object specified by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DataSource"></see> property has a <see cref="P:System.ComponentModel.IBindingList.SupportsSorting"></see> property value of false.</exception>
		/// 1</filterpriority>
		public virtual void Sort(DataGridViewColumn objDataGridViewColumn, ListSortDirection enmDirection)
		{
			if (objDataGridViewColumn == null)
			{
				throw new ArgumentNullException("dataGridViewColumn");
			}
			if (enmDirection != ListSortDirection.Ascending && enmDirection != ListSortDirection.Descending)
			{
				throw new InvalidEnumArgumentException("direction", (int)enmDirection, typeof(ListSortDirection));
			}
			if (objDataGridViewColumn.DataGridView != this)
			{
				throw new ArgumentException(SR.GetString("DataGridView_ColumnDoesNotBelongToDataGridView"));
			}
			if (VirtualMode && !objDataGridViewColumn.IsDataBound)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_OperationDisabledInVirtualMode"));
			}
			mblnSuspendFilterInitialization = true;
			SortInternal(null, objDataGridViewColumn, enmDirection);
			mblnSuspendFilterInitialization = false;
		}

		/// Forces the cell at the specified location to update its error text.</summary>
		/// <param name="intColumnIndex">The column index of the cell to update, or -1 to indicate a row header cell.</param>
		/// <param name="intRowIndex">The row index of the cell to update, or -1 to indicate a column header cell.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1 or greater than the number of columns in the control minus 1.- or -rowIndex is less than -1 or greater than the number of rows in the control minus 1.</exception>
		public void UpdateCellErrorText(int intColumnIndex, int intRowIndex)
		{
		}

		/// Forces the control to update its display of the cell at the specified location based on its new value, applying any automatic sizing modes currently in effect. </summary>
		/// <param name="intColumnIndex">The zero-based column index of the cell with the new value.</param>
		/// <param name="intRowIndex">The zero-based row index of the cell with the new value.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than zero or greater than the number of columns in the control minus one.-or-rowIndex is less than zero or greater than the number of rows in the control minus one.</exception>
		public void UpdateCellValue(int intColumnIndex, int intRowIndex)
		{
		}

		/// Forces the row at the given row index to update its error text.</summary>
		/// <param name="intRowIndex">The zero-based index of the row to update.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not in the valid range of 0 to the number of rows in the control minus 1.</exception>
		public void UpdateRowErrorText(int intRowIndex)
		{
		}

		/// Forces the rows in the given range to update their error text.</summary>
		/// <param name="intRowIndexStart">The zero-based index of the first row in the set of rows to update.</param>
		/// <param name="intRowIndexEnd">The zero-based index of the last row in the set of rows to update.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndexStart is not in the valid range of 0 to the number of rows in the control minus 1.-or-rowIndexEnd is not in the valid range of 0 to the number of rows in the control minus 1.-or-rowIndexEnd is less than rowIndexStart.</exception>
		public void UpdateRowErrorText(int intRowIndexStart, int intRowIndexEnd)
		{
		}

		/// Forces the specified row or rows to update their height information.</summary>
		/// <param name="intRowIndex">The zero-based index of the first row to update.</param>
		/// <param name="blnUpdateToEnd">true to update the specified row and all subsequent rows.</param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 and updateToEnd is true.- or -rowIndex is less than -1 and updateToEnd is false.- or -rowIndex is greater than the highest row index in the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.Rows"></see> collection.</exception>
		public void UpdateRowHeightInfo(int intRowIndex, bool blnUpdateToEnd)
		{
			UpdateRowHeightInfoPrivate(intRowIndex, blnUpdateToEnd, blnInvalidInAdjustFillingColumns: true);
		}

		private void UpdateRowHeightInfoPrivate(int intRowIndex, bool blnUpdateToEnd, bool blnInvalidInAdjustFillingColumns)
		{
		}

		/// 
		/// Determines whether the datagridview is hierarchic, according to selector.
		/// </summary>
		/// <param name="enmHierarchicInfoSelector">The hierarchicinfo selector.</param>
		/// 
		///   true</c> if the datagridview is hierarchic; otherwise, false</c>.
		/// </returns>
		internal bool IsHierarchic(HierarchicInfoSelector enmHierarchicInfoSelector)
		{
			return enmHierarchicInfoSelector switch
			{
				HierarchicInfoSelector.Public => mobjHierarchicInfos != null && mobjHierarchicInfos.Count > 0, 
				HierarchicInfoSelector.System => mobjSystemHierarchicInfos != null && mobjSystemHierarchicInfos.Count > 0, 
				HierarchicInfoSelector.Bounded => (mobjHierarchicInfos != null && mobjHierarchicInfos.Count > 0) || (mobjSystemHierarchicInfos != null && mobjSystemHierarchicInfos.Count > 0), 
				HierarchicInfoSelector.Any => (mobjHierarchicInfos != null && mobjHierarchicInfos.Count > 0) || (mobjSystemHierarchicInfos != null && mobjSystemHierarchicInfos.Count > 0) || mblnShowExpansionIndicator, 
				_ => throw new NotImplementedException(), 
			};
		}

		/// 
		/// Gets the relevant hierarchic infos.
		/// </summary>
		/// </returns>
		public ObservableCollection<object> GetRelevantHierarchicInfos()
		{
			if (SystemHierarchicInfos.Count > 0)
			{
				return SystemHierarchicInfos;
			}
			return HierarchicInfos;
		}

		/// 
		/// API for rows to notify that they have created a child grid view
		/// </summary>
		/// <param name="objCreatedGrid">The obj created grid.</param>
		internal void NotifyHierarchicGridCreated(HierarchicDataGridView objCreatedGrid)
		{
			OnHierarchicGridCreated(objCreatedGrid);
		}

		/// 
		/// Called when [hierarchic grid created].
		/// </summary>
		/// <param name="objCreatedGrid">The obj created grid.</param>
		private void OnHierarchicGridCreated(HierarchicDataGridView objCreatedGrid)
		{
			if (GetHandler(EVENT_HIERARCHICGRIDCREATED) is HierarchicDataGridViewCreatedEventHandler hierarchicDataGridViewCreatedEventHandler)
			{
				hierarchicDataGridViewCreatedEventHandler(this, new HierarchicDataGridViewCreatedEventArgs(objCreatedGrid));
			}
		}

		/// 
		/// Called when [column chooser columns visibility changed].
		/// </summary>
		/// <param name="objChangedColumnsVisibility">The obj changed columns visibility.</param>
		internal void OnColumnChooserColumnsVisibilityChanged(List<object> objChangedColumnsVisibility)
		{
			if (objChangedColumnsVisibility.Count > 0 && GetHandler(EVENT_COLUMNCHOOSERCOLUMNSVISIBILITYCHANGED) is ColumnChooserColumnsVisibilityChangedHandler columnChooserColumnsVisibilityChangedHandler)
			{
				columnChooserColumnsVisibilityChangedHandler(this, new ColumnChooserColumnsVisibilityChangedEventArgs(objChangedColumnsVisibility));
			}
		}

		/// 
		/// Raises the <see cref="E:RowExpanding" /> event.
		/// </summary>
		/// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Forms.RowExpandingEventArgs" /> instance containing the event data.</param>
		internal void OnRowExpanding(RowExpandingEventArgs objArgs)
		{
			if (GetHandler(EVENT_ROWEXPANDING) is RowExpandingEventHandler rowExpandingEventHandler)
			{
				rowExpandingEventHandler(this, objArgs);
			}
		}

		/// 
		/// Raises the <see cref="E:RowExpanded" /> event.
		/// </summary>
		/// <param name="objArgs">The <see cref="T:Gizmox.WebGUI.Forms.RowExpandedEventArgs" /> instance containing the event data.</param>
		internal void OnRowExpanded(RowExpandedEventArgs objArgs)
		{
			if (GetHandler(EVENT_ROWEXPANDED) is RowExpandedEventHandler rowExpandedEventHandler)
			{
				rowExpandedEventHandler(this, objArgs);
			}
		}

		/// 
		/// Called when [row collapsed].
		/// </summary>
		/// <param name="objRow">The obj row.</param>
		internal void OnRowCollapsed(DataGridViewRow objRow)
		{
			if (GetHandler(EVENT_ROWCOLLAPSED) is RowCollapsedEventHandler rowCollapsedEventHandler)
			{
				rowCollapsedEventHandler(objRow, new RowCollapsedEventArgs(objRow));
			}
		}

		/// 
		/// Called when [row collapsing].
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:Gizmox.WebGUI.Forms.RowCollapsingEventArgs" /> instance containing the event data.</param>
		internal void OnRowCollapsing(RowCollapsingEventArgs objEventArgs)
		{
			if (GetHandler(EVENT_ROWCOLLAPSING) is RowCollapsingEventHandler rowCollapsingEventHandler)
			{
				rowCollapsingEventHandler(objEventArgs.CollapsingRow, objEventArgs);
			}
		}

		/// 
		/// Gets the cloned binding source with filter for next level.
		/// </summary>
		/// <param name="objRow">The obj row.</param>
		/// </returns>
		internal BindingSource GetClonedBindingSourceWithFilterForNextLevel(DataGridViewRow objRow)
		{
			ObservableCollection<object> relevantHierarchicInfos = GetRelevantHierarchicInfos();
			if (relevantHierarchicInfos.Count > 0)
			{
				HierarchicInfo objNextInfoLevel = relevantHierarchicInfos[0];
				BindingSource bindingSource = CloneBindingSource(objNextInfoLevel);
				string filterForRowChildGrid = GetFilterForRowChildGrid(objRow);
				if (!string.IsNullOrEmpty(filterForRowChildGrid))
				{
					bindingSource.Filter = filterForRowChildGrid;
					return bindingSource;
				}
			}
			return null;
		}

		/// 
		/// Clones the binding source.
		/// </summary>
		/// <param name="objNextInfoLevel">The obj next info level.</param>
		/// </returns>
		private static BindingSource CloneBindingSource(HierarchicInfo objNextInfoLevel)
		{
			BindingSource bindingSource = ((ICloneable)objNextInfoLevel.BindedSource).Clone() as BindingSource;
			BindingSource bindingSource2 = bindingSource;
			for (BindingSource bindingSource3 = bindingSource.DataSource as BindingSource; bindingSource3 != null; bindingSource3 = bindingSource3.DataSource as BindingSource)
			{
				bindingSource2 = bindingSource3;
			}
			if (bindingSource2.DataSource is DataTable table)
			{
				bindingSource2.DataSource = new DataView(table);
			}
			return bindingSource;
		}

		/// 
		/// Gets the filter for row child grid.
		/// </summary>
		/// <param name="objRow">The obj row.</param>
		/// </returns>
		internal string GetFilterForRowChildGrid(DataGridViewRow objRow)
		{
			ObservableCollection<object> relevantHierarchicInfos = GetRelevantHierarchicInfos();
			if (relevantHierarchicInfos.Count > 0)
			{
				HierarchicInfo hierarchicInfo = relevantHierarchicInfos[0];
				if (string.IsNullOrEmpty(mstrFilterTemplate))
				{
					mstrFilterTemplate = GetFilterTemplate(hierarchicInfo);
				}
				return string.Format(mstrFilterTemplate, CreateRowFilterValueList(objRow, hierarchicInfo.Keys));
			}
			return string.Empty;
		}

		/// 
		/// Creates the row filter value list.
		/// </summary>
		/// <param name="objRow">The obj row.</param>
		/// <param name="objFilteringDataMembers">The obj filtering data members.</param>
		/// </returns>
		private string[] CreateRowFilterValueList(DataGridViewRow objRow, IList objFilteringDataMembers)
		{
			int num = 0;
			string[] array = new string[objFilteringDataMembers.Count];
			foreach (string objFilteringDataMember in objFilteringDataMembers)
			{
				if (!RealFilteringDataMemberIndexByProposedFilteringDataMember.ContainsKey(objFilteringDataMember))
				{
					CreateRealDataMemberForProposedMember(objFilteringDataMember);
				}
				object value = objRow.Cells[RealFilteringDataMemberIndexByProposedFilteringDataMember[objFilteringDataMember]].Value;
				string text;
				if (value == null || value is DBNull)
				{
					text = "IS NULL";
				}
				else
				{
					text = value.ToString();
					text = $"= {GetQueryComparisionValue(value.GetType(), text)}";
				}
				array[num++] = text;
			}
			return array;
		}

		/// 
		/// Creates the real data member from the proposed member.
		/// </summary>
		/// <param name="strFilteringDataMember">The STR filtering data member.</param>
		private void CreateRealDataMemberForProposedMember(string strFilteringDataMember)
		{
			string realDataMemberForProposedMember = Columns.GetRealDataMemberForProposedMember(strFilteringDataMember);
			if (!string.IsNullOrEmpty(realDataMemberForProposedMember))
			{
				RealFilteringDataMemberIndexByProposedFilteringDataMember.Add(strFilteringDataMember, realDataMemberForProposedMember);
				return;
			}
			throw new Exception("The grid does not contain a columns with the given filter data member name: Given name - '" + strFilteringDataMember + "'");
		}

		/// 
		/// Creates a template for the filter field
		/// </summary>
		/// <param name="objCurrentInfoLevel">The obj current info level.</param>
		/// <param name="objNextInfoLevel">The obj next info level.</param>
		/// </returns>
		private string GetFilterTemplate(HierarchicInfo objNextInfoLevel)
		{
			int num = 0;
			string value = string.Empty;
			StringBuilder stringBuilder = new StringBuilder();
			foreach (FilterRelation filteringDataMember in objNextInfoLevel.FilteringDataMembers)
			{
				stringBuilder.Append(value);
				stringBuilder.Append("[");
				stringBuilder.Append(filteringDataMember.TargetColumnDataName);
				stringBuilder.Append("]");
				stringBuilder.Append(" ");
				stringBuilder.Append("{");
				stringBuilder.Append(num++);
				stringBuilder.Append("}");
				value = " AND ";
			}
			return stringBuilder.ToString();
		}

		/// 
		/// Removes the grouping column.
		/// </summary>
		/// <param name="strColumnDataPropertyName">Name of the STR column data property.</param>
		private void RemoveGroupingColumn(string strColumnDataPropertyName)
		{
			GroupingColumns.Remove(strColumnDataPropertyName);
		}

		/// 
		/// Inserts the grouping column.
		/// </summary>
		/// <param name="strTargetDataPropertyName">Name of the STR target data property.</param>
		/// <param name="strDraggedDataPropertyName">Name of the STR dragged data property.</param>
		internal void InsertGroupingColumn(string strTargetDataPropertyName, string strDraggedDataPropertyName)
		{
			if (!string.IsNullOrEmpty(strTargetDataPropertyName))
			{
				if (!GroupingColumns.Contains(strDraggedDataPropertyName) && GroupingColumns.Contains(strTargetDataPropertyName))
				{
					GroupingColumns.Insert(GroupingColumns.IndexOf(strTargetDataPropertyName) + 1, strDraggedDataPropertyName);
				}
			}
			else if (!GroupingColumns.Contains(strDraggedDataPropertyName))
			{
				GroupingColumns.Insert(0, strDraggedDataPropertyName);
			}
		}

		/// 
		/// Adds or removes datagroups events.
		/// </summary>
		/// <param name="blnIsAdd">if set to true</c> [BLN is add].</param>
		private void AddRemoveGroupingColumnEvents(bool blnIsAdd)
		{
			if (blnIsAdd)
			{
				mobjGroupingColumns.CollectionChanged += OnGroupingColumnsCollectionChanged;
			}
			else
			{
				mobjGroupingColumns.CollectionChanged -= OnGroupingColumnsCollectionChanged;
			}
		}

		/// 
		/// Called when [grouping columns collection changed].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="!:Gizmox.WebGUI.Forms.NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
		private void OnGroupingColumnsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			Update();
			if (e.Action == NotifyCollectionChangedAction.Remove && !AutoGenerateColumns && HideGroupedColumns)
			{
				string text = e.OldItems[0] as string;
				if (!string.IsNullOrEmpty(text))
				{
					DataGridViewColumnCollection columns = Columns;
					string realDataMemberForProposedMember = columns.GetRealDataMemberForProposedMember(text);
					if (!string.IsNullOrEmpty(realDataMemberForProposedMember) && columns[realDataMemberForProposedMember] != null)
					{
						columns[realDataMemberForProposedMember].Visible = true;
					}
				}
			}
			SwitchPreRenderUpdate(PreRenderUpdateType.GroupingData);
		}

		/// 
		/// Switches the prerender update flag.
		/// </summary>
		/// <param name="enmPreRenderUpdateType">The enm update params.</param>
		internal void SwitchPreRenderUpdate(PreRenderUpdateType enmPreRenderUpdateType)
		{
			if (enmPreRenderUpdateType > PreRenderUpdateType.None)
			{
				menmPreRenderUpdateTypes |= enmPreRenderUpdateType;
			}
			else
			{
				menmPreRenderUpdateTypes &= enmPreRenderUpdateType;
			}
		}

		/// 
		/// Determines whether the specified prerender update type is dirty.
		/// </summary>
		/// <param name="enmPreRenderUpdateType">The prerender update type.</param>
		/// 
		///   true</c> if the specified prerender update type dirty; otherwise, false</c>.
		/// </returns>
		private bool ShouldPreRenderUpdate(PreRenderUpdateType enmPreRenderUpdateType)
		{
			return (menmPreRenderUpdateTypes & enmPreRenderUpdateType) != 0;
		}

		/// 
		/// Initializes the system hierarchic infos.
		/// </summary>
		private void InitializeSystemHierarchicInfos()
		{
			if (!(DataSource is BindingSource bindedSource))
			{
				return;
			}
			SystemHierarchicInfos.Clear();
			for (int i = 0; i < GroupingColumns.Count; i++)
			{
				HierarchicInfo hierarchicInfo = new HierarchicInfo();
				hierarchicInfo.BindedSource = bindedSource;
				for (int j = 0; j <= i; j++)
				{
					FilterRelation filterRelation = new FilterRelation();
					filterRelation.SourceColumnDataName = GroupingColumns[j];
					filterRelation.TargetColumnDataName = GroupingColumns[j];
					hierarchicInfo.FilteringDataMembers.Add(filterRelation);
				}
				SystemHierarchicInfos.Add(hierarchicInfo);
			}
		}

		/// 
		/// Called when [group header formatting].
		/// </summary>
		/// <param name="objCurrentCell">The obj current cell.</param>
		/// <param name="strDataPropertyName">Name of the STR data property.</param>
		/// <param name="strCurrentValue">The STR current value.</param>
		/// <param name="intCount">The int count.</param>
		/// </returns>
		internal GroupHeaderFormattingEventArgs OnGroupHeaderFormatting(Label objHeaderLabel, string strDataPropertyName, string strCurrentValue, int intCount, DataGridViewRow objOwningRow)
		{
			GroupHeaderFormattingEventArgs e = new GroupHeaderFormattingEventArgs(objHeaderLabel, strDataPropertyName, intCount, strCurrentValue, objOwningRow);
			OnGroupHeaderFormatting(this, e);
			return e;
		}

		/// 
		/// Raises the <see cref="E:GroupHeaderFormatting" /> event.
		/// </summary>
		/// <param name="objCell">The obj cell.</param>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.GroupHeaderFormattingEventArgs" /> instance containing the event data.</param>
		private void OnGroupHeaderFormatting(DataGridView objDataGridView, GroupHeaderFormattingEventArgs e)
		{
			if (GroupHeaderFormattingHandler != null)
			{
				GroupHeaderFormattingHandler(objDataGridView, e);
			}
		}

		/// 
		/// Formats the group header.
		/// </summary>
		/// <param name="objCurrentCell">The obj current cell.</param>
		/// <param name="strDataPropertyName">Name of the STR data property.</param>
		/// <param name="strCurrentValue">The STR current value.</param>
		/// <param name="intCount">The int count.</param>
		private void FormatGroupHeader(DataGridViewCell objCurrentCell, int intVisibleColumnsCount, string strDataPropertyName, string strCurrentValue, BindingSource objRowBindingSource)
		{
			DataGridViewRow owningRow = objCurrentCell.OwningRow;
			if (owningRow != null)
			{
				objCurrentCell.Panel.Controls.Clear();
				objCurrentCell.Rowspan = 1;
				objCurrentCell.Colspan = intVisibleColumnsCount;
				DataGridViewGroupingHeader dataGridViewGroupingHeader = new DataGridViewGroupingHeader(strDataPropertyName, strCurrentValue, objRowBindingSource, owningRow);
				dataGridViewGroupingHeader.Dock = DockStyle.Fill;
				objCurrentCell.Panel.Controls.Add(dataGridViewGroupingHeader);
			}
		}

		/// 
		/// Called when [cell context menu needed].
		/// </summary>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="objContextMenu">The context menu.</param>
		/// </returns>
		internal ContextMenu OnCellContextMenuNeeded(int intColumnIndex, int intRowIndex, ContextMenu objContextMenu)
		{
			DataGridViewCellContextMenuNeededEventArgs e = new DataGridViewCellContextMenuNeededEventArgs(intColumnIndex, intRowIndex, objContextMenu);
			OnCellContextMenuNeeded(e);
			return e.ContextMenu;
		}

		/// 
		/// Called when [cell context menu strip needed].
		/// </summary>
		/// <param name="columnIndex">Index of the column.</param>
		/// <param name="rowIndex">Index of the row.</param>
		/// <param name="contextMenuStrip">The context menu strip.</param>
		/// </returns>
		internal ContextMenuStrip OnCellContextMenuStripNeeded(int columnIndex, int rowIndex, ContextMenuStrip contextMenuStrip)
		{
			DataGridViewCellContextMenuStripNeededEventArgs e = new DataGridViewCellContextMenuStripNeededEventArgs(columnIndex, rowIndex, contextMenuStrip);
			OnCellContextMenuStripNeeded(e);
			return e.ContextMenuStrip;
		}

		/// 
		/// Raises the <see cref="E:CellContextMenuStripNeeded" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellContextMenuStripNeededEventArgs" /> instance containing the event data.</param>
		internal virtual void OnCellContextMenuStripNeeded(DataGridViewCellContextMenuStripNeededEventArgs e)
		{
			if (e.ColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("e.ColumnIndex");
			}
			if (e.RowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("e.RowIndex");
			}
			if (GetHandler(EVENT_DATAGRIDVIEWCELLCONTEXTMENUSTRIPNEEDED) is DataGridViewCellContextMenuStripNeededEventHandler dataGridViewCellContextMenuStripNeededEventHandler && !base.IsDisposed)
			{
				dataGridViewCellContextMenuStripNeededEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.CellContextMenuStripNeeded"></see> event. </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellContextMenuNeeded(DataGridViewCellContextMenuNeededEventArgs e)
		{
			if (e.ColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("e.ColumnIndex");
			}
			if (e.RowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("e.RowIndex");
			}
			if (GetHandler(EVENT_DATAGRIDVIEWCELLCONTEXTMENUNEEDED) is DataGridViewCellContextMenuNeededEventHandler dataGridViewCellContextMenuNeededEventHandler && !base.IsDisposed)
			{
				dataGridViewCellContextMenuNeededEventHandler(this, e);
			}
		}

		/// 
		/// Called when [row context menu needed].
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="objContextMenu">The context menu.</param>
		/// </returns>
		internal ContextMenu OnRowContextMenuNeeded(int intRowIndex, ContextMenu objContextMenu)
		{
			DataGridViewRowContextMenuNeededEventArgs e = new DataGridViewRowContextMenuNeededEventArgs(intRowIndex, objContextMenu);
			OnRowContextMenuNeeded(e);
			return e.ContextMenu;
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.RowContextMenuStripNeeded"></see> event. </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewRowContextMenuStripNeededEventArgs"></see> that contains the event data. </param>
		protected virtual void OnRowContextMenuNeeded(DataGridViewRowContextMenuNeededEventArgs e)
		{
			if (GetHandler(EVENT_DATAGRIDVIEWROWCONTEXTMENUNEEDED) is DataGridViewRowContextMenuNeededEventHandler dataGridViewRowContextMenuNeededEventHandler && !base.IsDisposed)
			{
				dataGridViewRowContextMenuNeededEventHandler(this, e);
			}
		}

		/// 
		/// Called when [band context menu strip changed].
		/// </summary>
		/// <param name="objDataGridViewBand">The data grid view band.</param>
		internal void OnBandContextMenuChanged(DataGridViewBand objDataGridViewBand)
		{
			if (objDataGridViewBand is DataGridViewColumn objDataGridViewColumn)
			{
				DataGridViewColumnEventArgs e = new DataGridViewColumnEventArgs(objDataGridViewColumn);
				OnColumnContextMenuStripChanged(e);
			}
			else
			{
				DataGridViewRowEventArgs e2 = new DataGridViewRowEventArgs((DataGridViewRow)objDataGridViewBand);
				OnRowContextMenuChanged(e2);
			}
		}

		/// 
		/// Called when [band context menu strip changed].
		/// </summary>
		/// <param name="dataGridViewBand">The data grid view band.</param>
		internal void OnBandContextMenuStripChanged(DataGridViewBand dataGridViewBand)
		{
			if (dataGridViewBand is DataGridViewColumn objDataGridViewColumn)
			{
				DataGridViewColumnEventArgs e = new DataGridViewColumnEventArgs(objDataGridViewColumn);
				OnColumnContextMenuStripChanged(e);
			}
			else
			{
				DataGridViewRowEventArgs e2 = new DataGridViewRowEventArgs((DataGridViewRow)dataGridViewBand);
				OnRowContextMenuStripChanged(e2);
			}
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.RowContextMenuStripChanged"></see> event. </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewRowEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentException">The row indicated by the <see cref="P:System.Windows.Forms.DataGridViewRowEventArgs.Row"></see> property of e does not belong to this <see cref="T:System.Windows.Forms.DataGridView"></see> control.</exception>
		protected virtual void OnRowContextMenuChanged(DataGridViewRowEventArgs e)
		{
			if (e.Row.DataGridView != this)
			{
				throw new ArgumentException(SR.GetString("DataGridView_RowDoesNotBelongToDataGridView"), "e.Row");
			}
			if (GetHandler(EVENT_DATAGRIDVIEWROWCONTEXTMENUCHANGED) is DataGridViewRowEventHandler dataGridViewRowEventHandler && !base.IsDisposed)
			{
				dataGridViewRowEventHandler(this, e);
			}
		}

		internal void OnAddingColumn(DataGridViewColumn objDataGridViewColumn)
		{
			if (objDataGridViewColumn == null)
			{
				throw new ArgumentNullException("dataGridViewColumn");
			}
			if (objDataGridViewColumn.DataGridView != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ColumnAlreadyBelongsToDataGridView"));
			}
			if (!InInitialization && objDataGridViewColumn.SortMode == DataGridViewColumnSortMode.Automatic && (SelectionMode == DataGridViewSelectionMode.FullColumnSelect || SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect))
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewColumn_SortModeAndSelectionModeClash", DataGridViewColumnSortMode.Automatic.ToString(), SelectionMode.ToString()));
			}
			if (objDataGridViewColumn.Visible)
			{
				if (!ColumnHeadersVisible && (objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.ColumnHeader || (objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet && AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.ColumnHeader)))
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddAutoSizedColumn"));
				}
				if (objDataGridViewColumn.Frozen && (objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.Fill || (objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet && AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)))
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddAutoFillColumn"));
				}
				mobjDataGridViewState2[67108864] = true;
			}
			float num = Columns.GetColumnsFillWeight(DataGridViewElementStates.None) + objDataGridViewColumn.FillWeight;
			if (num > 65535f)
			{
				object[] arrArgs = new object[1] { 65535.ToString(CultureInfo.CurrentCulture) };
				throw new InvalidOperationException(SR.GetString("DataGridView_WeightSumCannotExceedLongMaxValue", arrArgs));
			}
			CorrectColumnFrozenState(objDataGridViewColumn, Columns.Count);
			DataGridViewRowCollection rows = Rows;
			if (rows.Count <= 0)
			{
				return;
			}
			if (objDataGridViewColumn.CellType == null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddUntypedColumn"));
			}
			if (objDataGridViewColumn.CellTemplate.DefaultNewRowValue != null && NewRowIndex != -1)
			{
				DataGridViewRow dataGridViewRow = rows[NewRowIndex];
			}
			int num2 = Columns.Count + 1;
			try
			{
				for (int i = 0; i < rows.Count; i++)
				{
					DataGridViewRow dataGridViewRow2 = rows.SharedRow(i);
					if (dataGridViewRow2.Cells.Count < num2)
					{
						DataGridViewCell dataGridViewCell = (DataGridViewCell)objDataGridViewColumn.CellTemplate.Clone();
						dataGridViewRow2.Cells.AddInternal(dataGridViewCell);
						if (i == NewRowIndex)
						{
							dataGridViewCell.SetValueInternal(i, dataGridViewCell.DefaultNewRowValue);
						}
						dataGridViewCell.DataGridViewInternal = this;
						dataGridViewCell.OwningRowInternal = dataGridViewRow2;
						dataGridViewCell.OwningColumnInternal = objDataGridViewColumn;
					}
				}
			}
			catch
			{
				for (int j = 0; j < rows.Count; j++)
				{
					DataGridViewRow dataGridViewRow3 = rows.SharedRow(j);
					if (dataGridViewRow3.Cells.Count != num2)
					{
						break;
					}
					dataGridViewRow3.Cells.RemoveAtInternal(num2 - 1);
				}
				throw;
			}
		}

		private void CorrectColumnFrozenState(DataGridViewColumn objDataGridViewColumn, int intAnticipatedColumnIndex)
		{
			int num = ((objDataGridViewColumn.DisplayIndex != -1 && objDataGridViewColumn.DisplayIndex <= Columns.Count) ? objDataGridViewColumn.DisplayIndex : intAnticipatedColumnIndex);
			int num2 = num - 1;
			DataGridViewColumn columnAtDisplayIndex;
			do
			{
				columnAtDisplayIndex = Columns.GetColumnAtDisplayIndex(num2);
				num2--;
			}
			while (num2 >= 0 && (columnAtDisplayIndex == null || !columnAtDisplayIndex.Visible));
			if (columnAtDisplayIndex != null && !columnAtDisplayIndex.Frozen && objDataGridViewColumn.Frozen)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddFrozenColumn"));
			}
			num2 = num;
			DataGridViewColumn columnAtDisplayIndex2;
			do
			{
				columnAtDisplayIndex2 = Columns.GetColumnAtDisplayIndex(num2);
				num2++;
			}
			while (num2 < Columns.Count && (columnAtDisplayIndex2 == null || !columnAtDisplayIndex2.Visible));
			if (columnAtDisplayIndex2 != null && columnAtDisplayIndex2.Frozen && !objDataGridViewColumn.Frozen)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddNonFrozenColumn"));
			}
		}

		private void CorrectColumnFrozenStates(DataGridViewColumn[] arrDataGridViewColumns)
		{
			DataGridView dataGridView = new DataGridView();
			foreach (DataGridViewColumn column in Columns)
			{
				DataGridViewColumn dataGridViewColumn2 = (DataGridViewColumn)column.Clone();
				dataGridViewColumn2.DisplayIndex = column.DisplayIndex;
				dataGridView.Columns.Add(dataGridViewColumn2);
			}
			foreach (DataGridViewColumn dataGridViewColumn3 in arrDataGridViewColumns)
			{
				DataGridViewColumn dataGridViewColumn2 = (DataGridViewColumn)dataGridViewColumn3.Clone();
				dataGridViewColumn2.DisplayIndex = dataGridViewColumn3.DisplayIndex;
				dataGridView.Columns.Add(dataGridViewColumn2);
			}
		}

		private void CorrectRowFrozenState(DataGridViewRow objDataGridViewRow, DataGridViewElementStates enmRowState, int intAnticipatedRowIndex)
		{
			DataGridViewRowCollection rows = Rows;
			int previousRow = rows.GetPreviousRow(intAnticipatedRowIndex, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
			if (previousRow != -1 && (rows.GetRowState(previousRow) & DataGridViewElementStates.Frozen) == 0 && (enmRowState & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddFrozenRow"));
			}
			int nextRow = rows.GetNextRow((previousRow == -1) ? (intAnticipatedRowIndex - 1) : previousRow, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
			if (nextRow != -1 && (rows.GetRowState(nextRow) & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None && (enmRowState & DataGridViewElementStates.Frozen) == 0)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddNonFrozenRow"));
			}
		}

		internal void OnAddingColumns(DataGridViewColumn[] arrDataGridViewColumns)
		{
			float num = Columns.GetColumnsFillWeight(DataGridViewElementStates.None);
			DataGridViewRowCollection rows = Rows;
			foreach (DataGridViewColumn dataGridViewColumn in arrDataGridViewColumns)
			{
				if (dataGridViewColumn == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_AtLeastOneColumnIsNull"));
				}
				if (dataGridViewColumn.DataGridView != null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_ColumnAlreadyBelongsToDataGridView"));
				}
				if (rows.Count > 0 && dataGridViewColumn.CellType == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddUntypedColumn"));
				}
				if (!InInitialization && dataGridViewColumn.SortMode == DataGridViewColumnSortMode.Automatic && (SelectionMode == DataGridViewSelectionMode.FullColumnSelect || SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect))
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_SortModeAndSelectionModeClash", DataGridViewColumnSortMode.Automatic.ToString(), SelectionMode.ToString()));
				}
				if (dataGridViewColumn.Visible)
				{
					if (!ColumnHeadersVisible && (dataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.ColumnHeader || (dataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet && AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.ColumnHeader)))
					{
						throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddAutoSizedColumn"));
					}
					if (dataGridViewColumn.Frozen && (dataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.Fill || (dataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet && AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)))
					{
						throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddAutoFillColumn"));
					}
					mobjDataGridViewState2[67108864] = true;
				}
				num += dataGridViewColumn.FillWeight;
				if (num > 65535f)
				{
					object[] arrArgs = new object[1] { 65535.ToString(CultureInfo.CurrentCulture) };
					throw new InvalidOperationException(SR.GetString("DataGridView_WeightSumCannotExceedLongMaxValue", arrArgs));
				}
			}
			int num2 = arrDataGridViewColumns.Length;
			for (int j = 0; j < num2 - 1; j++)
			{
				for (int k = j + 1; k < num2; k++)
				{
					if (arrDataGridViewColumns[j] == arrDataGridViewColumns[k])
					{
						throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddIdenticalColumns"));
					}
				}
			}
			CorrectColumnFrozenStates(arrDataGridViewColumns);
			if (rows.Count <= 0)
			{
				return;
			}
			foreach (DataGridViewColumn dataGridViewColumn2 in arrDataGridViewColumns)
			{
				if (dataGridViewColumn2.CellTemplate.DefaultNewRowValue != null && NewRowIndex != -1)
				{
					DataGridViewRow dataGridViewRow = rows[NewRowIndex];
					break;
				}
			}
			int count = Columns.Count;
			int num3 = 0;
			try
			{
				foreach (DataGridViewColumn dataGridViewColumn3 in arrDataGridViewColumns)
				{
					num3++;
					for (int n = 0; n < rows.Count; n++)
					{
						DataGridViewRow dataGridViewRow2 = rows.SharedRow(n);
						if (dataGridViewRow2.Cells.Count < count + num3)
						{
							DataGridViewCell dataGridViewCell = (DataGridViewCell)dataGridViewColumn3.CellTemplate.Clone();
							dataGridViewRow2.Cells.AddInternal(dataGridViewCell);
							if (n == NewRowIndex)
							{
								dataGridViewCell.Value = dataGridViewCell.DefaultNewRowValue;
							}
							dataGridViewCell.DataGridViewInternal = this;
							dataGridViewCell.OwningRowInternal = dataGridViewRow2;
							dataGridViewCell.OwningColumnInternal = dataGridViewColumn3;
						}
					}
				}
			}
			catch
			{
				for (int num4 = 0; num4 < rows.Count; num4++)
				{
					DataGridViewRow dataGridViewRow3 = rows.SharedRow(num4);
					while (dataGridViewRow3.Cells.Count > count)
					{
						dataGridViewRow3.Cells.RemoveAtInternal(dataGridViewRow3.Cells.Count - 1);
					}
				}
				throw;
			}
		}

		/// 
		/// Called when [clearing columns].
		/// </summary>
		internal void OnClearingColumns()
		{
			CurrentCell = null;
			Rows.ClearInternal(blnRecreateNewRow: false);
			SortedColumn = null;
			SortOrder = SortOrder.None;
		}

		/// 
		/// Called when [column hidden].
		/// </summary>
		/// <param name="objDataGridViewColumn">The data grid view column.</param>
		internal void OnColumnHidden(DataGridViewColumn objDataGridViewColumn)
		{
			if (objDataGridViewColumn.Displayed)
			{
				objDataGridViewColumn.DisplayedInternal = false;
				DataGridViewColumnStateChangedEventArgs e = new DataGridViewColumnStateChangedEventArgs(objDataGridViewColumn, DataGridViewElementStates.Displayed);
				OnColumnStateChanged(e);
			}
		}

		/// 
		/// Called when [inserted column_ pre notification].
		/// </summary>
		/// <param name="objDataGridViewColumn">The data grid view column.</param>
		internal void OnInsertedColumn_PreNotification(DataGridViewColumn objDataGridViewColumn)
		{
			DisplayedBandsInfo.CorrectColumnIndexAfterInsertion(objDataGridViewColumn.Index, 1);
			CorrectColumnIndexesAfterInsertion(objDataGridViewColumn, 1);
			OnAddedColumn(objDataGridViewColumn);
		}

		/// 
		/// Called when [inserted column_ post notification].
		/// </summary>
		/// <param name="objNewCurrentCell">The new current cell.</param>
		internal void OnInsertedColumn_PostNotification(Point objNewCurrentCell)
		{
			if (objNewCurrentCell.X != -1)
			{
				SetAndSelectCurrentCellAddress(objNewCurrentCell.X, objNewCurrentCell.Y, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false, blnClearSelection: false, Columns.GetColumnCount(DataGridViewElementStates.Visible) == 1);
			}
		}

		/// 
		/// Corrects the column indexes after insertion.
		/// </summary>
		/// <param name="objDataGridViewColumn">The data grid view column.</param>
		/// <param name="intInsertionCount">The insertion count.</param>
		private void CorrectColumnIndexesAfterInsertion(DataGridViewColumn objDataGridViewColumn, int intInsertionCount)
		{
			for (int i = objDataGridViewColumn.Index + intInsertionCount; i < Columns.Count; i++)
			{
				Columns[i].IndexInternal = i;
			}
		}

		/// 
		/// Called when [removed column_ post notification].
		/// </summary>
		/// <param name="objDataGridViewColumn">The data grid view column.</param>
		/// <param name="objNewCurrentCell">The new current cell.</param>
		internal void OnRemovedColumn_PostNotification(DataGridViewColumn objDataGridViewColumn, Point objNewCurrentCell)
		{
			if (objNewCurrentCell.X != -1)
			{
				SetAndSelectCurrentCellAddress(objNewCurrentCell.X, objNewCurrentCell.Y, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false, blnClearSelection: false, blnForceCurrentCellSelection: false);
			}
			FlushSelectionChanged();
			OnColumnHidden(objDataGridViewColumn);
		}

		/// 
		/// Called when [column collection changed_ post notification].
		/// </summary>
		/// <param name="objDataGridViewColumn">The data grid view column.</param>
		internal void OnColumnCollectionChanged_PostNotification(DataGridViewColumn objDataGridViewColumn)
		{
			if (Columns.Count != 0 && Rows.Count == 0)
			{
				if (DataSource != null && !mobjDataGridViewOper[1024])
				{
					RefreshRows(blnScrollIntoView: true);
				}
				else if (AllowUserToAddRowsInternal)
				{
					AddNewRow(blnCreatedByEditing: false);
				}
			}
		}

		/// 
		/// Initializes the filter row.
		/// </summary>
		private void InitializeFilterRow()
		{
			BindingSource bindingSource = DataSource as BindingSource;
			if (mobjDataGridViewFilterRow == null)
			{
				mobjDataGridViewFilterRow = new DataGridViewFilterRow();
				mobjDataGridViewFilterRow.IndexInternal = 0;
				mobjDataGridViewFilterRow.Height = 24;
			}
			mobjDataGridViewFilterRow.DataGridViewInternal = null;
			mobjDataGridViewFilterRow.HeaderCell.DataGridViewInternal = this;
			List<object> list = new List<object>();
			if (mobjDataGridViewFilterRow.Cells != null)
			{
				if (bindingSource != null)
				{
					foreach (DataGridViewFilterCell cell in mobjDataGridViewFilterRow.Cells)
					{
						if (!cell.AllowRowFiltering)
						{
							list.Add(cell.DataPropertyName);
						}
					}
				}
				mobjDataGridViewFilterRow.Cells.Clear();
			}
			foreach (DataGridViewColumn column in Columns)
			{
				if (list.Contains(column.DataPropertyName))
				{
					column.AllowRowFilteringInternal = false;
				}
				DataGridViewFilterCell dataGridViewFilterCell2 = new DataGridViewFilterCell(this, column, bindingSource != null);
				mobjDataGridViewFilterRow.Cells.Add(dataGridViewFilterCell2);
				if (bindingSource != null)
				{
					dataGridViewFilterCell2.FilterChanged += OnFilterCellChanged;
				}
			}
			mobjDataGridViewFilterRow.DataGridViewInternal = this;
		}

		/// 
		/// Called when [filter cell changed].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void OnFilterCellChanged(object sender, EventArgs e)
		{
			ApplyDataGridViewFilter();
		}

		/// 
		/// Applies the data grid view filter.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		internal void ApplyDataGridViewFilter()
		{
			if (DataSource is BindingSource bindingSource)
			{
				bindingSource.Filter = ConstructFullFilterExpression();
			}
		}

		/// 
		/// Constructs the full filter expression from every FilterRow cell and column header expressions.
		/// </summary>
		/// </returns>
		internal string ConstructFullFilterExpression()
		{
			string text = ((this is HierarchicDataGridView hierarchicDataGridView) ? hierarchicDataGridView.ContainingRow.DataGridView.GetFilterForRowChildGrid(hierarchicDataGridView.ContainingRow) : string.Empty);
			if (mobjDataGridViewFilterRow != null)
			{
				foreach (DataGridViewFilterCell cell in mobjDataGridViewFilterRow.Cells)
				{
					DataGridViewColumn owningColumn = cell.OwningColumn;
					string text2 = owningColumn.CustomFilterExpression;
					if (string.IsNullOrEmpty(text2))
					{
						text2 = GetFilterStatement(cell.ComparisonOperator, cell.DataPropertyName, cell.ValueType, cell.ComparisionValue, cell.ComparisionItem);
					}
					if (string.IsNullOrEmpty(text2))
					{
						DataGridViewColumnHeaderCell headerCell = owningColumn.HeaderCell;
						if (headerCell != null)
						{
							text2 = GetFilterStatement(FilterComparisonOperator.Equals, owningColumn.DataPropertyName, owningColumn.ValueType, headerCell.FilterComboBox.Text, headerCell.FilterComboBox.SelectedItem);
						}
					}
					if (!string.IsNullOrEmpty(text2))
					{
						if (!string.IsNullOrEmpty(text))
						{
							text = $"{text} AND ";
						}
						text = $"{text}{text2}";
					}
				}
			}
			else
			{
				for (DataGridViewColumn dataGridViewColumn = Columns.GetFirstColumn(DataGridViewElementStates.Visible); dataGridViewColumn != null; dataGridViewColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
				{
					string text3 = dataGridViewColumn.CustomFilterExpression;
					if (string.IsNullOrEmpty(text3) && dataGridViewColumn.HeaderCell != null && dataGridViewColumn.ShowHeaderFilter)
					{
						DataGridViewColumnHeaderCell headerCell2 = dataGridViewColumn.HeaderCell;
						if (headerCell2 != null && string.IsNullOrEmpty(dataGridViewColumn.CustomFilterExpression))
						{
							text3 = GetFilterStatement(FilterComparisonOperator.Equals, dataGridViewColumn.DataPropertyName, dataGridViewColumn.ValueType, headerCell2.FilterComboBox.Text, headerCell2.FilterComboBox.SelectedItem);
						}
					}
					if (!string.IsNullOrEmpty(text3))
					{
						if (!string.IsNullOrEmpty(text))
						{
							text = $"{text} AND ";
						}
						text = $"{text}{text3}";
					}
				}
			}
			return text;
		}

		/// 
		/// Gets the filter statement according to operator.
		/// </summary>
		/// <param name="enmComparisionOperator">The comparision operator.</param>
		/// <param name="strDataPropertyName">Name of the data property.</param>
		/// <param name="objComparisionValueType">Type of the value.</param>
		/// <param name="strComparisionValue">The comparision value.</param>
		/// </returns>
		private string GetFilterStatement(FilterComparisonOperator enmComparisionOperator, string strDataPropertyName, Type objComparisionValueType, string strComparisionValue, object objComparisionItem)
		{
			string text = null;
			if (!string.IsNullOrEmpty(strDataPropertyName) && !string.IsNullOrEmpty(strComparisionValue) && objComparisionValueType != null)
			{
				text = GetSystemFilterStatement(strDataPropertyName, objComparisionItem);
				if (text == null)
				{
					switch (enmComparisionOperator)
					{
					case FilterComparisonOperator.Equals:
						text = $"[{strDataPropertyName}]={GetQueryComparisionValue(objComparisionValueType, strComparisionValue)}";
						break;
					case FilterComparisonOperator.NotEquals:
						text = $"[{strDataPropertyName}]<>{GetQueryComparisionValue(objComparisionValueType, strComparisionValue)}";
						break;
					case FilterComparisonOperator.GreaterThan:
						text = $"[{strDataPropertyName}]>{GetQueryComparisionValue(objComparisionValueType, strComparisionValue)}";
						break;
					case FilterComparisonOperator.GreaterThanOrEqualTo:
						text = $"[{strDataPropertyName}]>={GetQueryComparisionValue(objComparisionValueType, strComparisionValue)}";
						break;
					case FilterComparisonOperator.LessThan:
						text = $"[{strDataPropertyName}]<{GetQueryComparisionValue(objComparisionValueType, strComparisionValue)}";
						break;
					case FilterComparisonOperator.LessThanOrEqualTo:
						text = $"[{strDataPropertyName}]<={GetQueryComparisionValue(objComparisionValueType, strComparisionValue)}";
						break;
					case FilterComparisonOperator.StartsWith:
						text = $"[{strDataPropertyName}] LIKE {GetQueryComparisionValue(objComparisionValueType, $"{strComparisionValue}%")}";
						break;
					case FilterComparisonOperator.Like:
					case FilterComparisonOperator.Contains:
						text = $"[{strDataPropertyName}] LIKE {GetQueryComparisionValue(objComparisionValueType, $"%{strComparisionValue}%")}";
						break;
					case FilterComparisonOperator.EndsWith:
						text = $"[{strDataPropertyName}] LIKE {GetQueryComparisionValue(objComparisionValueType, $"%{strComparisionValue}")}";
						break;
					case FilterComparisonOperator.DoesNotStartWith:
						text = $"[{strDataPropertyName}] NOT LIKE {GetQueryComparisionValue(objComparisionValueType, $"{strComparisionValue}%")}";
						break;
					case FilterComparisonOperator.DoesNotEndWith:
						text = $"[{strDataPropertyName}] NOT LIKE {GetQueryComparisionValue(objComparisionValueType, $"%{strComparisionValue}")}";
						break;
					case FilterComparisonOperator.NotLike:
					case FilterComparisonOperator.DoesNotContain:
						text = $"[{strDataPropertyName}] NOT LIKE {GetQueryComparisionValue(objComparisionValueType, $"%{strComparisionValue}%")}";
						break;
					default:
						text = string.Empty;
						break;
					}
				}
			}
			return text;
		}

		/// 
		/// Gets the system filter statement.
		/// </summary>
		/// <param name="strDataPropertyName">Name of the STR data property.</param>
		/// <param name="strComparisionValue">The STR comparision value.</param>
		/// </returns>
		private string GetSystemFilterStatement(string strDataPropertyName, object objComparisionItem)
		{
			if (objComparisionItem is DataGridViewSystemFilterOption dataGridViewSystemFilterOption)
			{
				if (dataGridViewSystemFilterOption.Option == SystemFilterOptions.All)
				{
					return string.Empty;
				}
				if (dataGridViewSystemFilterOption.Option == SystemFilterOptions.Blanks)
				{
					return $"[{strDataPropertyName}] IS NULL";
				}
				if (dataGridViewSystemFilterOption.Option == SystemFilterOptions.NonBlanks)
				{
					return $"[{strDataPropertyName}] IS NOT NULL";
				}
			}
			return null;
		}

		/// 
		/// Called while initializing filter values.
		/// </summary>
		/// <param name="objFilterValuesComboBox">The filter values combo box.</param>
		/// <param name="objCurrentColumn">The current column.</param>
		protected internal virtual void FilterValuesInitializing(ComboBox objFilterValuesComboBox, DataGridViewColumn objCurrentColumn)
		{
		}

		/// 
		/// Gets the query comparision value according to its type.
		/// </summary>
		/// <param name="objComparisionValueType">Type of the comparision value.</param>
		/// <param name="strComparisionValue">The STR comparision value.</param>
		/// </returns>
		protected virtual string GetQueryComparisionValue(Type objComparisionValueType, string strComparisionValue)
		{
			if (strComparisionValue != null)
			{
				strComparisionValue = strComparisionValue.Replace("'", "''");
				if (objComparisionValueType == typeof(DateTime))
				{
					try
					{
						strComparisionValue = $"'{Convert.ToDateTime(strComparisionValue, VWGContext.Current.CurrentUICulture).ToString(VWGContext.Current.CurrentUICulture.DateTimeFormat.UniversalSortableDateTimePattern)}'";
					}
					catch (Exception)
					{
						strComparisionValue = $"#{strComparisionValue}#";
					}
				}
				else if (objComparisionValueType == typeof(decimal) || objComparisionValueType == typeof(float) || objComparisionValueType == typeof(double))
				{
					try
					{
						strComparisionValue = $"{Convert.ToDouble(strComparisionValue, VWGContext.Current.CurrentUICulture).ToString(CultureInfo.InvariantCulture)}";
					}
					catch (Exception)
					{
						strComparisionValue = $"{strComparisionValue}";
					}
				}
				else if (objComparisionValueType != typeof(sbyte) && objComparisionValueType != typeof(short) && objComparisionValueType != typeof(int) && objComparisionValueType != typeof(long) && objComparisionValueType != typeof(byte) && objComparisionValueType != typeof(ushort) && objComparisionValueType != typeof(uint) && objComparisionValueType != typeof(long) && objComparisionValueType != typeof(bool) && objComparisionValueType != typeof(char))
				{
					strComparisionValue = $"'{strComparisionValue}'";
				}
				else if (objComparisionValueType == typeof(bool))
				{
					strComparisionValue = string.Format("{0}", (strComparisionValue.ToLower() == "true") ? "1" : "0");
				}
			}
			return strComparisionValue;
		}

		/// 
		/// Raises the <see cref="E:ColumnCollectionChanged_PreNotification" /> event.
		/// </summary>
		/// <param name="objCcEventArgs">The <see cref="T:System.ComponentModel.CollectionChangeEventArgs" /> instance containing the event data.</param>
		internal void OnColumnCollectionChanged_PreNotification(CollectionChangeEventArgs objCcEventArgs)
		{
			if (DataSource != null && !mobjDataGridViewOper[1024])
			{
				if (objCcEventArgs.Action == CollectionChangeAction.Add)
				{
					DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)objCcEventArgs.Element;
					if (dataGridViewColumn.DataPropertyName.Length != 0)
					{
						MapDataGridViewColumnToDataBoundField(dataGridViewColumn);
					}
				}
				else if (objCcEventArgs.Action == CollectionChangeAction.Refresh)
				{
					for (int i = 0; i < Columns.Count; i++)
					{
						if (Columns[i].DataPropertyName.Length != 0)
						{
							MapDataGridViewColumnToDataBoundField(Columns[i]);
						}
					}
				}
			}
			ResetUIState(blnUseRowShortcut: false, blnComputeVisibleRows: false);
		}

		private void InvalidateScrollBars()
		{
		}

		internal void ResetUIState(bool blnUseRowShortcut, bool blnComputeVisibleRows)
		{
			PerformLayoutPrivate(blnInvalidInAdjustFillingColumns: true);
			if (!blnUseRowShortcut)
			{
				Invalidate();
				InvalidateScrollBars();
			}
		}

		internal void OnRemovingColumn(DataGridViewColumn objDataGridViewColumn, out Point objNewCurrentCell, bool blnForce)
		{
			mobjDataGridViewState1[4194304] = false;
			int index = objDataGridViewColumn.Index;
			if (mobjCurrentCellPoint.X != -1)
			{
				int num = mobjCurrentCellPoint.X;
				if (index == mobjCurrentCellPoint.X)
				{
					DataGridViewColumn nextColumn = Columns.GetNextColumn(Columns[index], DataGridViewElementStates.Visible, DataGridViewElementStates.None);
					if (nextColumn != null)
					{
						num = ((nextColumn.Index <= index) ? nextColumn.Index : (nextColumn.Index - 1));
					}
					else
					{
						DataGridViewColumn previousColumn = Columns.GetPreviousColumn(Columns[index], DataGridViewElementStates.Visible, DataGridViewElementStates.None);
						num = ((previousColumn == null) ? (-1) : ((previousColumn.Index <= index) ? previousColumn.Index : (previousColumn.Index - 1)));
					}
				}
				else if (index < mobjCurrentCellPoint.X)
				{
					num = mobjCurrentCellPoint.X - 1;
				}
				objNewCurrentCell = new Point(num, (num == -1) ? (-1) : mobjCurrentCellPoint.Y);
				if (index == mobjCurrentCellPoint.X)
				{
					SetCurrentCellAddressCore(-1, -1, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false);
				}
				else if (blnForce)
				{
					mobjDataGridViewState1[4194304] = true;
					SetCurrentCellAddressCore(-1, -1, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false);
				}
			}
			else
			{
				objNewCurrentCell = new Point(-1, -1);
			}
			DataGridViewRowCollection rows = Rows;
			if (Columns.Count == 1)
			{
				rows.ClearInternal(blnRecreateNewRow: false);
			}
			int num2 = Columns.Count - 1;
			for (int i = 0; i < rows.Count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Cells.Count > num2)
				{
					dataGridViewRow.Cells.RemoveAtInternal(index);
				}
			}
			if (objDataGridViewColumn.HasHeaderCell)
			{
				objDataGridViewColumn.HeaderCell.DataGridViewInternal = null;
			}
			if (objDataGridViewColumn == SortedColumn)
			{
				SortedColumn = null;
				SortOrder = SortOrder.None;
				if (objDataGridViewColumn.IsDataBound)
				{
					for (int j = 0; j < Columns.Count; j++)
					{
						if (objDataGridViewColumn != Columns[j] && Columns[j].SortMode != DataGridViewColumnSortMode.NotSortable && string.Compare(objDataGridViewColumn.DataPropertyName, Columns[j].DataPropertyName, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
						{
							SortedColumn = Columns[j];
							SortOrder = Columns[j].HeaderCell.SortGlyphDirection;
							break;
						}
					}
				}
			}
			DataGridViewSelectionMode selectionMode = SelectionMode;
			if (selectionMode == DataGridViewSelectionMode.FullColumnSelect || selectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
			{
				DataGridViewIntLinkedList selectedBandIndexes = SelectedBandIndexes;
				int num3 = selectedBandIndexes.Count;
				int num4 = 0;
				while (num4 < num3)
				{
					int num5 = selectedBandIndexes[num4];
					if (index == num5)
					{
						selectedBandIndexes.RemoveAt(num4);
						num3--;
						continue;
					}
					if (index < num5)
					{
						selectedBandIndexes[num4] = num5 - 1;
					}
					num4++;
				}
			}
			IndividualSelectedCells.RemoveAllCellsAtBand(blnColumn: true, index);
			IndividualReadOnlyCells.RemoveAllCellsAtBand(blnColumn: true, index);
		}

		internal void OnRemovedColumn_PreNotification(DataGridViewColumn objDataGridViewColumn)
		{
			if (objDataGridViewColumn.HasHeaderCell)
			{
				objDataGridViewColumn.HeaderCell.SortGlyphDirectionInternal = SortOrder.None;
			}
			CorrectColumnIndexesAfterDeletion(objDataGridViewColumn);
			CorrectColumnDisplayIndexesAfterDeletion(objDataGridViewColumn);
			OnColumnRemoved(objDataGridViewColumn);
		}

		private void CorrectColumnIndexesAfterDeletion(DataGridViewColumn objDataGridViewColumn)
		{
			for (int i = objDataGridViewColumn.Index; i < Columns.Count; i++)
			{
				Columns[i].IndexInternal = Columns[i].Index - 1;
			}
		}

		internal void OnColumnRemoved(DataGridViewColumn objDataGridViewColumn)
		{
			OnColumnRemoved(new DataGridViewColumnEventArgs(objDataGridViewColumn));
		}

		internal void OnAddedColumn(DataGridViewColumn objDataGridViewColumn)
		{
			if (objDataGridViewColumn.DisplayIndex == -1 || objDataGridViewColumn.DisplayIndex >= Columns.Count)
			{
				objDataGridViewColumn.DisplayIndexInternal = objDataGridViewColumn.Index;
			}
			CorrectColumnDisplayIndexesAfterInsertion(objDataGridViewColumn);
			if (objDataGridViewColumn.HasHeaderCell)
			{
				objDataGridViewColumn.HeaderCell.DataGridViewInternal = this;
			}
			AdjustExpandingRows(objDataGridViewColumn.Index, blnFixedWidth: false);
			DataGridViewAutoSizeColumnMode inheritedAutoSizeMode = objDataGridViewColumn.InheritedAutoSizeMode;
			bool flag = inheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.None || inheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill;
			if (ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
			{
				AutoResizeColumnHeadersHeight(objDataGridViewColumn.Index, blnFixedRowHeadersWidth: true, flag);
			}
			if (!flag)
			{
				AutoResizeColumnInternal(objDataGridViewColumn.Index, (DataGridViewAutoSizeColumnCriteriaInternal)inheritedAutoSizeMode, blnFixedHeight: true);
				if (ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.AutoSize)
				{
					AutoResizeColumnHeadersHeight(objDataGridViewColumn.Index, blnFixedRowHeadersWidth: true, blnFixedColumnWidth: true);
				}
			}
			OnColumnAdded(new DataGridViewColumnEventArgs(objDataGridViewColumn));
		}

		private void CorrectColumnDisplayIndexesAfterInsertion(DataGridViewColumn objDataGridViewColumn)
		{
			try
			{
				mobjDataGridViewOper[2048] = true;
				foreach (DataGridViewColumn column in Columns)
				{
					if (column != objDataGridViewColumn && column.DisplayIndex >= objDataGridViewColumn.DisplayIndex)
					{
						column.DisplayIndexInternal = column.DisplayIndex + 1;
						column.DisplayIndexHasChanged = true;
					}
				}
				FlushDisplayIndexChanged(blnRaiseEvent: true);
			}
			finally
			{
				mobjDataGridViewOper[2048] = false;
				FlushDisplayIndexChanged(blnRaiseEvent: false);
			}
		}

		private bool AutoResizeColumnInternal(int intColumnIndex, DataGridViewAutoSizeColumnCriteriaInternal autoSizeColumnCriteriaInternal, bool blnFixedHeight)
		{
			bool result = false;
			try
			{
				AutoSizeCount++;
				DataGridViewColumn dataGridViewColumn = Columns[intColumnIndex];
				int num = dataGridViewColumn.GetPreferredWidth((DataGridViewAutoSizeColumnMode)autoSizeColumnCriteriaInternal, blnFixedHeight);
				if (num < dataGridViewColumn.MinimumThickness)
				{
					num = dataGridViewColumn.MinimumThickness;
				}
				if (num > 65536)
				{
					num = 65536;
				}
				if (num == dataGridViewColumn.Thickness)
				{
					return result;
				}
				if (dataGridViewColumn.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
				{
					AdjustFillingColumn(dataGridViewColumn, num);
				}
				else
				{
					Columns[intColumnIndex].ThicknessInternal = num;
				}
				result = true;
			}
			finally
			{
				AutoSizeCount--;
			}
			return result;
		}

		private void AdjustExpandingRows(int intColumnIndex, bool blnFixedWidth)
		{
		}

		private int AdjustExpandingRow(int intRowIndex, int intColumnIndex, bool blnFixedWidth)
		{
			int intWidth = 0;
			DataGridViewRowCollection rows = Rows;
			DataGridViewCell dataGridViewCell;
			if (intColumnIndex > -1 && (AutoSizeRowsMode & (DataGridViewAutoSizeRowsMode)2) != DataGridViewAutoSizeRowsMode.None)
			{
				dataGridViewCell = rows.SharedRow(intRowIndex).Cells[intColumnIndex];
				if (blnFixedWidth)
				{
					intWidth = Columns[intColumnIndex].Thickness;
				}
			}
			else
			{
				dataGridViewCell = rows.SharedRow(intRowIndex).HeaderCell;
				if (blnFixedWidth)
				{
					intWidth = RowHeadersWidth;
				}
			}
			int num = ((!blnFixedWidth) ? dataGridViewCell.GetPreferredSize(intRowIndex).Height : dataGridViewCell.GetPreferredHeight(intRowIndex, intWidth));
			rows.SharedRow(intRowIndex).GetHeightInfo(intRowIndex, out var intHeight, out var _);
			if (num < intHeight)
			{
				num = intHeight;
			}
			if (num > 65536)
			{
				num = 65536;
			}
			if (intHeight != num)
			{
				rows[intRowIndex].Thickness = num;
			}
			return num;
		}

		/// 
		/// Computes the height of fitting trailing scrolling rows.
		/// </summary>
		/// <param name="totalVisibleFrozenHeight">Total height of the visible frozen.</param>
		/// </returns>
		private int ComputeHeightOfFittingTrailingScrollingRows(int totalVisibleFrozenHeight)
		{
			int num = 0;
			int num2 = mobjLayoutInfo.Data.Height - totalVisibleFrozenHeight;
			int num3 = 0;
			int num4 = 0;
			int count = Rows.Count;
			if (count == 0 || num2 <= 0)
			{
				return 0;
			}
			count--;
			DataGridViewElementStates rowState = Rows.GetRowState(count);
			if ((rowState & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None)
			{
				return 0;
			}
			if ((rowState & DataGridViewElementStates.Visible) == 0)
			{
				count = Rows.GetPreviousRow(count, DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen);
			}
			if (count != -1)
			{
				num3 = Rows.SharedRow(count).GetHeight(count);
				if (num3 > num2)
				{
					return num3;
				}
			}
			while (count != -1 && num4 + num3 <= num2)
			{
				num4 += num3;
				count = Rows.GetPreviousRow(count, DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen);
				if (count != -1)
				{
					num3 = Rows.SharedRow(count).GetHeight(count);
				}
			}
			return num4;
		}

		/// 
		/// Adjusts the filling columns.
		/// </summary>
		/// </returns>
		internal bool AdjustFillingColumns()
		{
			int num = 0;
			if (mobjDataGridViewOper[262144])
			{
				return false;
			}
			mobjDataGridViewOper[262144] = true;
			bool result = false;
			try
			{
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				float num5 = 0f;
				ArrayList arrayList = null;
				foreach (DataGridViewColumn column in Columns)
				{
					if (!column.Visible)
					{
						continue;
					}
					if (column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
					{
						num2++;
						num4 += ((column.DesiredMinimumWidth > 0) ? column.DesiredMinimumWidth : column.MinimumWidth);
						num5 += column.FillWeight;
						if (arrayList == null)
						{
							arrayList = new ArrayList(Columns.Count);
						}
						arrayList.Add(column);
					}
					else
					{
						num3 += column.Width;
					}
				}
				if (num2 <= 0)
				{
					return result;
				}
				int num6 = 0;
				if (ExpansionIndicator != ShowExpansionIndicator.Never && IsHierarchic(HierarchicInfoSelector.Any) && base.Skin is DataGridViewSkin dataGridViewSkin)
				{
					num6 = dataGridViewSkin.ExpandCollapseColumnWidth;
				}
				int num7 = mobjLayoutInfo.Data.Width - num3 - num6;
				if (menmScrollBars == ScrollBars.Both || menmScrollBars == ScrollBars.Vertical)
				{
					int rowCount = Rows.GetRowCount(DataGridViewElementStates.Visible);
					int num8 = 0;
					int rowsHeight = Rows.GetRowsHeight(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible);
					if (UseInternalPaging)
					{
						foreach (DataGridViewRow pageRow in PageRows)
						{
							num8 += pageRow.Height;
						}
					}
					else
					{
						num8 = Rows.GetRowsHeight(DataGridViewElementStates.Visible);
					}
					if (DisplayedBandsInfo.NumTotallyDisplayedFrozenRows == Rows.GetRowCount(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible) && DisplayedBandsInfo.NumTotallyDisplayedScrollingRows != rowCount - Rows.GetRowCount(DataGridViewElementStates.Frozen | DataGridViewElementStates.Visible) && num8 - rowsHeight > ComputeHeightOfFittingTrailingScrollingRows(rowsHeight) && mobjLayoutInfo.Data.Height > rowsHeight && 17 <= mobjLayoutInfo.Data.Width)
					{
						num7 -= 17;
					}
				}
				if (num7 <= num4)
				{
					num7 = 0;
					for (int i = 0; i < arrayList.Count; i++)
					{
						DataGridViewColumn dataGridViewColumn2 = (DataGridViewColumn)arrayList[i];
						int num9 = ((dataGridViewColumn2.DesiredMinimumWidth > 0) ? dataGridViewColumn2.DesiredMinimumWidth : dataGridViewColumn2.MinimumWidth);
						if (dataGridViewColumn2.Thickness != num9)
						{
							result = true;
							dataGridViewColumn2.ThicknessInternal = num9;
						}
						num7 += dataGridViewColumn2.Thickness;
					}
					for (int i = 0; i < arrayList.Count; i++)
					{
						DataGridViewColumn dataGridViewColumn3 = (DataGridViewColumn)arrayList[i];
						dataGridViewColumn3.UsedFillWeight = (float)dataGridViewColumn3.Width * num5 / (float)num7;
					}
					mobjDataGridViewState2[67108864] = false;
					num = num7;
					return result;
				}
				int num10 = 0;
				if (mobjDataGridViewState2[67108864])
				{
					bool flag = false;
					for (int i = 0; i < arrayList.Count; i++)
					{
						DataGridViewColumn dataGridViewColumn4 = (DataGridViewColumn)arrayList[i];
						if (i == arrayList.Count - 1)
						{
							dataGridViewColumn4.DesiredFillWidth = num7 - num10;
						}
						else
						{
							float num11 = dataGridViewColumn4.FillWeight / num5 * (float)num7;
							dataGridViewColumn4.DesiredFillWidth = (int)Math.Round(num11, MidpointRounding.AwayFromZero);
							num10 += dataGridViewColumn4.DesiredFillWidth;
						}
						int num12 = ((dataGridViewColumn4.DesiredMinimumWidth > 0) ? dataGridViewColumn4.DesiredMinimumWidth : dataGridViewColumn4.MinimumWidth);
						if (dataGridViewColumn4.DesiredFillWidth < num12)
						{
							flag = true;
							dataGridViewColumn4.DesiredFillWidth = -1;
						}
					}
					if (flag)
					{
						float num13 = num5;
						float num14 = num5;
						for (int i = 0; i < arrayList.Count; i++)
						{
							DataGridViewColumn dataGridViewColumn5 = (DataGridViewColumn)arrayList[i];
							if (dataGridViewColumn5.DesiredFillWidth == -1)
							{
								int num15 = ((dataGridViewColumn5.DesiredMinimumWidth > 0) ? dataGridViewColumn5.DesiredMinimumWidth : dataGridViewColumn5.MinimumWidth);
								dataGridViewColumn5.UsedFillWeight = num5 * (float)num15 / (float)num7;
								num13 -= dataGridViewColumn5.UsedFillWeight;
								num14 -= dataGridViewColumn5.FillWeight;
							}
						}
						for (int i = 0; i < arrayList.Count; i++)
						{
							DataGridViewColumn dataGridViewColumn6 = (DataGridViewColumn)arrayList[i];
							if (dataGridViewColumn6.DesiredFillWidth != -1)
							{
								dataGridViewColumn6.UsedFillWeight = dataGridViewColumn6.FillWeight * num13 / num14;
							}
						}
					}
					else
					{
						for (int i = 0; i < arrayList.Count; i++)
						{
							DataGridViewColumn dataGridViewColumn7 = (DataGridViewColumn)arrayList[i];
							dataGridViewColumn7.UsedFillWeight = dataGridViewColumn7.FillWeight;
						}
					}
					mobjDataGridViewState2[67108864] = false;
					num = num7;
				}
				else if (num7 != num)
				{
					if (num7 > num)
					{
						int num16 = num7 - num;
						for (int i = 0; i < arrayList.Count; i++)
						{
							DataGridViewColumn dataGridViewColumn8 = (DataGridViewColumn)arrayList[i];
							dataGridViewColumn8.DesiredFillWidth = dataGridViewColumn8.Width;
						}
						float[] array = new float[arrayList.Count];
						for (int j = 0; j < num16; j++)
						{
							float num17 = 0f;
							bool flag2 = false;
							for (int i = 0; i < arrayList.Count; i++)
							{
								DataGridViewColumn dataGridViewColumn9 = (DataGridViewColumn)arrayList[i];
								num17 += dataGridViewColumn9.FillWeight / dataGridViewColumn9.UsedFillWeight;
								if (dataGridViewColumn9.DesiredFillWidth <= dataGridViewColumn9.MinimumWidth)
								{
									flag2 = true;
								}
							}
							for (int i = 0; i < arrayList.Count; i++)
							{
								DataGridViewColumn dataGridViewColumn10 = (DataGridViewColumn)arrayList[i];
								if (j == 0)
								{
									array[i] = (float)num * dataGridViewColumn10.UsedFillWeight / num5;
								}
								if (flag2)
								{
									array[i] += dataGridViewColumn10.FillWeight / dataGridViewColumn10.UsedFillWeight / num17;
								}
								else
								{
									array[i] += dataGridViewColumn10.FillWeight / num5;
								}
							}
						}
						for (int i = 0; i < arrayList.Count; i++)
						{
							DataGridViewColumn dataGridViewColumn11 = (DataGridViewColumn)arrayList[i];
							dataGridViewColumn11.UsedFillWeight = num5 / (float)num7 * array[i];
						}
					}
					else
					{
						int num18 = num - num7;
						int num19 = 0;
						for (int i = 0; i < arrayList.Count; i++)
						{
							DataGridViewColumn dataGridViewColumn12 = (DataGridViewColumn)arrayList[i];
							dataGridViewColumn12.DesiredFillWidth = dataGridViewColumn12.Width;
						}
						do
						{
							int num20 = num - num19;
							int num21 = Math.Min(num20 - num7, Math.Max(1, (int)((float)num20 * 0.1f)));
							num19 += num21;
							bool flag3;
							do
							{
								flag3 = false;
								float num22 = 0f;
								float num23 = 0f;
								DataGridViewColumn dataGridViewColumn13 = null;
								for (int i = 0; i < arrayList.Count; i++)
								{
									DataGridViewColumn dataGridViewColumn14 = (DataGridViewColumn)arrayList[i];
									if (dataGridViewColumn14.DesiredFillWidth > dataGridViewColumn14.MinimumWidth)
									{
										float num24 = dataGridViewColumn14.UsedFillWeight / dataGridViewColumn14.FillWeight;
										num23 += num24;
										if (num24 > num22)
										{
											dataGridViewColumn13 = dataGridViewColumn14;
											num22 = num24;
										}
									}
								}
								if (dataGridViewColumn13 == null)
								{
									continue;
								}
								float num25 = (float)num20 * dataGridViewColumn13.UsedFillWeight / num5 - (float)num21 * dataGridViewColumn13.UsedFillWeight / dataGridViewColumn13.FillWeight / num23;
								if (num25 < (float)dataGridViewColumn13.MinimumWidth)
								{
									num25 = dataGridViewColumn13.MinimumWidth;
								}
								int desiredFillWidth = dataGridViewColumn13.DesiredFillWidth;
								dataGridViewColumn13.DesiredFillWidth = Math.Min(desiredFillWidth, (int)Math.Round(num25, MidpointRounding.AwayFromZero));
								flag3 = desiredFillWidth != dataGridViewColumn13.DesiredFillWidth;
								if (!flag3 && num21 == 1 && desiredFillWidth > dataGridViewColumn13.MinimumWidth)
								{
									dataGridViewColumn13.DesiredFillWidth--;
									flag3 = true;
								}
								num21 -= desiredFillWidth - dataGridViewColumn13.DesiredFillWidth;
								if (flag3)
								{
									num20 -= desiredFillWidth - dataGridViewColumn13.DesiredFillWidth;
									for (int i = 0; i < arrayList.Count; i++)
									{
										DataGridViewColumn dataGridViewColumn15 = (DataGridViewColumn)arrayList[i];
										dataGridViewColumn15.UsedFillWeight = num5 / (float)num20 * (float)dataGridViewColumn15.DesiredFillWidth;
									}
								}
							}
							while (flag3 && num21 > 0);
						}
						while (num19 < num18);
					}
					num = num7;
				}
				try
				{
					mobjDataGridViewState2[33554432] = false;
					num10 = 0;
					float num26 = 0f;
					while (arrayList.Count > 0)
					{
						DataGridViewColumn dataGridViewColumn16 = null;
						if (arrayList.Count == 1)
						{
							dataGridViewColumn16 = (DataGridViewColumn)arrayList[0];
							dataGridViewColumn16.DesiredFillWidth = Math.Max(num7 - num10, dataGridViewColumn16.MinimumWidth);
							arrayList.Clear();
						}
						else
						{
							float num27 = 0f;
							for (int i = 0; i < arrayList.Count; i++)
							{
								DataGridViewColumn dataGridViewColumn17 = (DataGridViewColumn)arrayList[i];
								float num28 = Math.Abs(dataGridViewColumn17.UsedFillWeight - dataGridViewColumn17.FillWeight) / dataGridViewColumn17.FillWeight;
								if (num28 > num27 || dataGridViewColumn16 == null)
								{
									dataGridViewColumn16 = dataGridViewColumn17;
									num27 = num28;
								}
							}
							float num29 = dataGridViewColumn16.UsedFillWeight * (float)num7 / num5 + num26;
							dataGridViewColumn16.DesiredFillWidth = Math.Max(dataGridViewColumn16.MinimumWidth, (int)Math.Round(num29, MidpointRounding.AwayFromZero));
							num26 = num29 - (float)dataGridViewColumn16.DesiredFillWidth;
							num10 += dataGridViewColumn16.DesiredFillWidth;
							arrayList.Remove(dataGridViewColumn16);
						}
						if (dataGridViewColumn16.DesiredFillWidth != dataGridViewColumn16.Thickness)
						{
							result = true;
							dataGridViewColumn16.ThicknessInternal = dataGridViewColumn16.DesiredFillWidth;
						}
					}
				}
				finally
				{
					mobjDataGridViewState2[33554432] = true;
				}
			}
			finally
			{
				mobjDataGridViewOper[262144] = false;
			}
			return result;
		}

		/// 
		/// Adjusts the filling column.
		/// </summary>
		/// <param name="objDataGridViewColumn">The obj data grid view column.</param>
		/// <param name="intWidth">Width of the int.</param>
		internal void AdjustFillingColumn(DataGridViewColumn objDataGridViewColumn, int intWidth)
		{
			if (InAdjustFillingColumns)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterAutoFillColumnParameter"));
			}
			mobjDataGridViewOper[524288] = true;
			try
			{
				LayoutData layoutInfo = LayoutInfo;
				if (Columns.GetColumnsWidth(DataGridViewElementStates.Visible) > layoutInfo.Data.Width)
				{
					return;
				}
				int num = layoutInfo.Data.Width;
				if (base.DesignMode || objDataGridViewColumn == Columns.GetFirstColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen) || objDataGridViewColumn == Columns.GetLastColumn(DataGridViewElementStates.Visible, DataGridViewElementStates.Frozen))
				{
					float num2 = 0f;
					int num3 = 0;
					int num4 = 0;
					bool flag = false;
					foreach (DataGridViewColumn column in Columns)
					{
						if (!column.Visible)
						{
							continue;
						}
						if (column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
						{
							num3 += column.Width;
							if (column.Index != objDataGridViewColumn.Index)
							{
								num4 += column.MinimumWidth;
								flag = true;
							}
							num2 += column.FillWeight;
						}
						else
						{
							num4 += column.Width;
							num -= column.Width;
						}
					}
					if (!flag)
					{
						return;
					}
					int num5 = layoutInfo.Data.Width - num4;
					if (intWidth > num5)
					{
						intWidth = num5;
					}
					float fillWeight = objDataGridViewColumn.FillWeight;
					float num6 = (float)intWidth * num2 / (float)num3;
					bool flag2 = false;
					foreach (DataGridViewColumn column2 in Columns)
					{
						if (column2.Index != objDataGridViewColumn.Index && column2.Visible && column2.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
						{
							column2.FillWeightInternal = (num2 - num6) * column2.FillWeight / (num2 - fillWeight);
							if (column2.FillWeight < (float)column2.MinimumWidth * num2 / (float)num3)
							{
								flag2 = true;
								column2.DesiredFillWidth = -1;
							}
							else
							{
								column2.DesiredFillWidth = 0;
							}
						}
					}
					objDataGridViewColumn.FillWeightInternal = num6;
					if (flag2)
					{
						float num7 = num2;
						float num8 = num2;
						float num9 = 0f;
						foreach (DataGridViewColumn column3 in Columns)
						{
							if (column3.Visible && column3.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
							{
								if (column3.Index == objDataGridViewColumn.Index)
								{
									column3.UsedFillWeight = column3.FillWeight;
									num7 -= column3.UsedFillWeight;
									num8 -= column3.FillWeight;
									num9 += column3.UsedFillWeight;
								}
								else if (column3.DesiredFillWidth == -1)
								{
									column3.UsedFillWeight = num2 * (float)column3.MinimumWidth / (float)num3;
									num7 -= column3.UsedFillWeight;
									num8 -= column3.FillWeight;
									num9 += column3.UsedFillWeight;
								}
							}
						}
						foreach (DataGridViewColumn column4 in Columns)
						{
							if (column4.Index != objDataGridViewColumn.Index && column4.Visible && column4.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill && column4.DesiredFillWidth != -1)
							{
								column4.UsedFillWeight = Math.Max(column4.FillWeight * num7 / num8, num2 * (float)column4.MinimumWidth / (float)num3);
								num9 += column4.UsedFillWeight;
							}
						}
						objDataGridViewColumn.UsedFillWeight += num2 - num9;
					}
					else
					{
						foreach (DataGridViewColumn column5 in Columns)
						{
							if (column5.Visible && column5.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
							{
								column5.UsedFillWeight = column5.FillWeight;
							}
						}
					}
				}
				else
				{
					int num10 = 0;
					float num11 = 0f;
					float num12 = 0f;
					bool flag3 = false;
					foreach (DataGridViewColumn column6 in Columns)
					{
						if (!column6.Visible)
						{
							continue;
						}
						if (column6.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
						{
							if (column6.Index != objDataGridViewColumn.Index)
							{
								if (Columns.DisplayInOrder(objDataGridViewColumn.Index, column6.Index))
								{
									num10 += column6.MinimumWidth;
									num12 += column6.FillWeight;
								}
								else
								{
									num10 += column6.Width;
								}
								flag3 = true;
							}
							num11 += column6.FillWeight;
						}
						else
						{
							num10 += column6.Width;
							num -= column6.Width;
						}
					}
					if (!flag3)
					{
						return;
					}
					int num13 = layoutInfo.Data.Width - num10;
					if (intWidth > num13)
					{
						intWidth = num13;
					}
					float fillWeight2 = objDataGridViewColumn.FillWeight;
					float num14 = num11 * (float)intWidth / (float)num;
					float num15 = num12 + fillWeight2 - num14;
					foreach (DataGridViewColumn column7 in Columns)
					{
						if (column7.Index != objDataGridViewColumn.Index && column7.Visible && column7.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill && Columns.DisplayInOrder(objDataGridViewColumn.Index, column7.Index))
						{
							column7.FillWeightInternal = column7.FillWeight * num15 / num12;
						}
					}
					objDataGridViewColumn.FillWeightInternal = num14;
					bool flag4 = false;
					foreach (DataGridViewColumn column8 in Columns)
					{
						if (column8.Visible && column8.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
						{
							if (column8.FillWeight < (float)column8.MinimumWidth * num11 / (float)num)
							{
								flag4 = true;
								column8.DesiredFillWidth = -1;
							}
							else
							{
								column8.DesiredFillWidth = 0;
							}
						}
					}
					if (flag4)
					{
						float num16 = num11;
						float num17 = num11;
						float num18 = 0f;
						foreach (DataGridViewColumn column9 in Columns)
						{
							if (!column9.Visible || column9.InheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.Fill)
							{
								continue;
							}
							if (column9.Index == objDataGridViewColumn.Index || Columns.DisplayInOrder(column9.Index, objDataGridViewColumn.Index))
							{
								if (column9.Index == objDataGridViewColumn.Index)
								{
									column9.UsedFillWeight = column9.FillWeight;
								}
								else
								{
									column9.UsedFillWeight = num11 * (float)column9.Width / (float)num;
								}
								num16 -= column9.UsedFillWeight;
								num17 -= column9.FillWeight;
								num18 += column9.UsedFillWeight;
							}
							else if (column9.DesiredFillWidth == -1)
							{
								column9.UsedFillWeight = num11 * (float)column9.MinimumWidth / (float)num;
								num16 -= column9.UsedFillWeight;
								num17 -= column9.FillWeight;
								num18 += column9.UsedFillWeight;
							}
						}
						foreach (DataGridViewColumn column10 in Columns)
						{
							if (Columns.DisplayInOrder(objDataGridViewColumn.Index, column10.Index) && column10.Visible && column10.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill && column10.DesiredFillWidth != -1)
							{
								column10.UsedFillWeight = Math.Max(column10.FillWeight * num16 / num17, num11 * (float)column10.MinimumWidth / (float)num);
								num18 += column10.UsedFillWeight;
							}
						}
						objDataGridViewColumn.UsedFillWeight += num11 - num18;
					}
					else
					{
						foreach (DataGridViewColumn column11 in Columns)
						{
							if (column11.Visible && column11.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
							{
								column11.UsedFillWeight = column11.FillWeight;
							}
						}
					}
				}
				mobjDataGridViewState2[67108864] = false;
				PerformLayoutPrivate(blnInvalidInAdjustFillingColumns: false);
			}
			finally
			{
				mobjDataGridViewOper[524288] = false;
			}
		}

		private void CorrectColumnDisplayIndexesAfterDeletion(DataGridViewColumn objDataGridViewColumn)
		{
			try
			{
				mobjDataGridViewOper[2048] = true;
				foreach (DataGridViewColumn column in Columns)
				{
					if (column.DisplayIndex > objDataGridViewColumn.DisplayIndex)
					{
						column.DisplayIndexInternal = column.DisplayIndex - 1;
						column.DisplayIndexHasChanged = true;
					}
				}
				FlushDisplayIndexChanged(blnRaiseEvent: true);
			}
			finally
			{
				mobjDataGridViewOper[2048] = false;
				FlushDisplayIndexChanged(blnRaiseEvent: false);
			}
		}

		private void FlushDisplayIndexChanged(bool blnRaiseEvent)
		{
			foreach (DataGridViewColumn column in Columns)
			{
				if (column.DisplayIndexHasChanged)
				{
					column.DisplayIndexHasChanged = false;
					if (blnRaiseEvent)
					{
						OnColumnDisplayIndexChanged(column);
					}
				}
			}
		}

		internal void OnInsertingColumn(int intColumnIndexInserted, DataGridViewColumn objDataGridViewColumn, out Point objNewCurrentCell)
		{
			if (objDataGridViewColumn.DataGridView != null)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_ColumnAlreadyBelongsToDataGridView"));
			}
			if (!InInitialization && objDataGridViewColumn.SortMode == DataGridViewColumnSortMode.Automatic && (SelectionMode == DataGridViewSelectionMode.FullColumnSelect || SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect))
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewColumn_SortModeAndSelectionModeClash", DataGridViewColumnSortMode.Automatic.ToString(), SelectionMode.ToString()));
			}
			if (objDataGridViewColumn.Visible)
			{
				if (!ColumnHeadersVisible && (objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.ColumnHeader || (objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet && AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.ColumnHeader)))
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddAutoSizedColumn"));
				}
				if (objDataGridViewColumn.Frozen && (objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.Fill || (objDataGridViewColumn.AutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet && AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill)))
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddAutoFillColumn"));
				}
			}
			CorrectColumnFrozenState(objDataGridViewColumn, intColumnIndexInserted);
			if (mobjCurrentCellPoint.X != -1)
			{
				objNewCurrentCell = new Point((intColumnIndexInserted <= mobjCurrentCellPoint.X) ? (mobjCurrentCellPoint.X + 1) : mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
				ResetCurrentCell();
			}
			else
			{
				objNewCurrentCell = new Point(-1, -1);
			}
			DataGridViewRowCollection rows = Rows;
			if (rows.Count > 0)
			{
				if (objDataGridViewColumn.CellType == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddUntypedColumn"));
				}
				if (objDataGridViewColumn.CellTemplate.DefaultNewRowValue != null && NewRowIndex != -1)
				{
					DataGridViewRow dataGridViewRow = rows[NewRowIndex];
				}
				int num = Columns.Count + 1;
				try
				{
					for (int i = 0; i < rows.Count; i++)
					{
						DataGridViewRow dataGridViewRow2 = rows.SharedRow(i);
						if (dataGridViewRow2.Cells.Count < num)
						{
							DataGridViewCell dataGridViewCell = (DataGridViewCell)objDataGridViewColumn.CellTemplate.Clone();
							dataGridViewRow2.Cells.InsertInternal(intColumnIndexInserted, dataGridViewCell);
							if (i == NewRowIndex)
							{
								dataGridViewCell.Value = dataGridViewCell.DefaultNewRowValue;
							}
							dataGridViewCell.DataGridViewInternal = this;
							dataGridViewCell.OwningRowInternal = dataGridViewRow2;
							dataGridViewCell.OwningColumnInternal = objDataGridViewColumn;
						}
					}
				}
				catch
				{
					for (int j = 0; j < rows.Count; j++)
					{
						DataGridViewRow dataGridViewRow3 = rows.SharedRow(j);
						if (dataGridViewRow3.Cells.Count != num)
						{
							break;
						}
						dataGridViewRow3.Cells.RemoveAtInternal(intColumnIndexInserted);
					}
					throw;
				}
			}
			switch (SelectionMode)
			{
			case DataGridViewSelectionMode.FullColumnSelect:
			case DataGridViewSelectionMode.ColumnHeaderSelect:
			{
				DataGridViewIntLinkedList selectedBandIndexes = SelectedBandIndexes;
				int count = selectedBandIndexes.Count;
				for (int k = 0; k < count; k++)
				{
					int num2 = selectedBandIndexes[k];
					if (intColumnIndexInserted <= num2)
					{
						selectedBandIndexes[k] = num2 + 1;
					}
				}
				DataGridViewIntLinkedList selectedBandSnapshotIndexes = SelectedBandSnapshotIndexes;
				if (selectedBandSnapshotIndexes == null)
				{
					break;
				}
				count = selectedBandSnapshotIndexes.Count;
				for (int k = 0; k < count; k++)
				{
					int num3 = selectedBandSnapshotIndexes[k];
					if (intColumnIndexInserted <= num3)
					{
						selectedBandSnapshotIndexes[k] = num3 + 1;
					}
				}
				break;
			}
			}
		}

		internal void OnSortGlyphDirectionChanged(DataGridViewColumnHeaderCell dataGridViewColumnHeaderCell)
		{
			if (dataGridViewColumnHeaderCell.OwningColumn == SortedColumn)
			{
				if (dataGridViewColumnHeaderCell.SortGlyphDirection == SortOrder.None)
				{
					SortedColumn = null;
					DataGridViewColumn owningColumn = dataGridViewColumnHeaderCell.OwningColumn;
					if (owningColumn.IsDataBound)
					{
						for (int i = 0; i < Columns.Count; i++)
						{
							if (owningColumn != Columns[i] && Columns[i].SortMode != DataGridViewColumnSortMode.NotSortable && string.Compare(owningColumn.DataPropertyName, Columns[i].DataPropertyName, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
							{
								SortedColumn = Columns[i];
								break;
							}
						}
					}
				}
				SortOrder = ((SortedColumn != null) ? SortedColumn.HeaderCell.SortGlyphDirection : SortOrder.None);
			}
			InvalidateCellPrivate(dataGridViewColumnHeaderCell);
		}

		internal string OnRowErrorTextNeeded(int intRowIndex, string strErrorText)
		{
			DataGridViewRowErrorTextNeededEventArgs e = new DataGridViewRowErrorTextNeededEventArgs(intRowIndex, strErrorText);
			OnRowErrorTextNeeded(e);
			return e.ErrorText;
		}

		internal void OnAddingRow(DataGridViewRow objDataGridViewRow, DataGridViewElementStates enmRowState, bool blnCheckFrozenState)
		{
			if (objDataGridViewRow == null)
			{
				throw new ArgumentNullException("dataGridViewRow");
			}
			if (blnCheckFrozenState)
			{
				CorrectRowFrozenState(objDataGridViewRow, enmRowState, Rows.Count);
			}
			if (ReadOnly && objDataGridViewRow.DataGridView == null && objDataGridViewRow.ReadOnly)
			{
				objDataGridViewRow.ReadOnly = false;
			}
			int num = 0;
			foreach (DataGridViewColumn column in Columns)
			{
				DataGridViewCell dataGridViewCell = objDataGridViewRow.Cells[num];
				if ((ReadOnly || column.ReadOnly) && dataGridViewCell.StateIncludes(DataGridViewElementStates.ReadOnly))
				{
					dataGridViewCell.ReadOnlyInternal = false;
				}
				num++;
			}
		}

		internal void OnAddedRow_PreNotification(int intRowIndex)
		{
			if (AllowUserToAddRowsInternal && NewRowIndex == -1)
			{
				NewRowIndex = intRowIndex;
			}
			DataGridViewRowCollection rows = Rows;
			DataGridViewElementStates rowState = rows.GetRowState(intRowIndex);
			if ((rowState & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None || ReadOnly)
			{
				return;
			}
			DataGridViewRow dataGridViewRow = rows.SharedRow(intRowIndex);
			foreach (DataGridViewCell cell in dataGridViewRow.Cells)
			{
				if (!cell.OwningColumn.ReadOnly && IsSharedCellReadOnly(cell, intRowIndex))
				{
					IndividualReadOnlyCells.Add(cell);
				}
			}
		}

		private bool IsSharedCellReadOnly(DataGridViewCell objDataGridViewCell, int intRowIndex)
		{
			DataGridViewElementStates rowState = Rows.GetRowState(intRowIndex);
			if (ReadOnly || (rowState & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None || (objDataGridViewCell.OwningColumn != null && objDataGridViewCell.OwningColumn.ReadOnly))
			{
				return true;
			}
			return objDataGridViewCell.StateIncludes(DataGridViewElementStates.ReadOnly);
		}

		internal void OnAddedRow_PostNotification(int intRowIndex)
		{
			DataGridViewRowCollection rows = Rows;
			DataGridViewElementStates rowState = rows.GetRowState(intRowIndex);
			if ((rowState & DataGridViewElementStates.Visible) != DataGridViewElementStates.None)
			{
				bool flag = (rowState & DataGridViewElementStates.Displayed) != 0;
				DataGridViewAutoSizeRowsMode autoSizeRowsMode = AutoSizeRowsMode;
				DataGridViewAutoSizeRowsModeInternal dataGridViewAutoSizeRowsModeInternal = (DataGridViewAutoSizeRowsModeInternal)autoSizeRowsMode;
				bool flag2 = false;
				if (dataGridViewAutoSizeRowsModeInternal != DataGridViewAutoSizeRowsModeInternal.None && ((dataGridViewAutoSizeRowsModeInternal & DataGridViewAutoSizeRowsModeInternal.DisplayedRows) == 0 || flag))
				{
					int height = rows.SharedRow(intRowIndex).GetHeight(intRowIndex);
					rows.SharedRow(intRowIndex).CachedThickness = height;
					AutoResizeRowInternal(intRowIndex, MapAutoSizeRowsModeToRowMode(autoSizeRowsMode), blnFixedWidth: false, blnInternalAutosizing: true);
					flag2 = true;
				}
				DataGridViewAutoSizeColumnCriteriaInternal dataGridViewAutoSizeColumnCriteriaInternal = DataGridViewAutoSizeColumnCriteriaInternal.AllRows;
				if (flag)
				{
					dataGridViewAutoSizeColumnCriteriaInternal |= DataGridViewAutoSizeColumnCriteriaInternal.DisplayedRows;
				}
				bool flag3 = ((rows.GetRowCount(DataGridViewElementStates.Visible) <= 1) ? AutoResizeAllVisibleColumnsInternal(dataGridViewAutoSizeColumnCriteriaInternal, blnFixedHeight: true) : AdjustExpandingColumns(dataGridViewAutoSizeColumnCriteriaInternal, intRowIndex));
				bool flag4 = ColumnHeadersHeightSizeMode != DataGridViewColumnHeadersHeightSizeMode.AutoSize;
				DataGridViewRowHeadersWidthSizeMode rowHeadersWidthSizeMode = RowHeadersWidthSizeMode;
				bool flag5 = rowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.EnableResizing && rowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.DisableResizing;
				if (!flag5 && !flag3)
				{
					flag4 = true;
				}
				if (flag5)
				{
					AutoResizeRowHeadersWidth(intRowIndex, rowHeadersWidthSizeMode, flag4, blnFixedRowHeight: true);
				}
				if (!flag4)
				{
					AutoResizeColumnHeadersHeight(blnFixedRowHeadersWidth: true, blnFixedColumnsWidth: true);
				}
				if (flag2)
				{
					AutoResizeRowInternal(intRowIndex, MapAutoSizeRowsModeToRowMode(autoSizeRowsMode), blnFixedWidth: true, blnInternalAutosizing: true);
				}
				if (flag5 && !flag4)
				{
					AutoResizeRowHeadersWidth(intRowIndex, rowHeadersWidthSizeMode, blnFixedColumnHeadersHeight: true, blnFixedRowHeight: true);
				}
			}
		}

		private static DataGridViewAutoSizeRowMode MapAutoSizeRowsModeToRowMode(DataGridViewAutoSizeRowsMode enmAutoSizeRowsMode)
		{
			return enmAutoSizeRowsMode switch
			{
				DataGridViewAutoSizeRowsMode.AllHeaders => DataGridViewAutoSizeRowMode.RowHeader, 
				DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders => DataGridViewAutoSizeRowMode.AllCellsExceptHeader, 
				DataGridViewAutoSizeRowsMode.AllCells => DataGridViewAutoSizeRowMode.AllCells, 
				DataGridViewAutoSizeRowsMode.DisplayedHeaders => DataGridViewAutoSizeRowMode.RowHeader, 
				DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders => DataGridViewAutoSizeRowMode.AllCellsExceptHeader, 
				DataGridViewAutoSizeRowsMode.DisplayedCells => DataGridViewAutoSizeRowMode.AllCells, 
				_ => DataGridViewAutoSizeRowMode.RowHeader, 
			};
		}

		private bool AutoResizeAllVisibleColumnsInternal(DataGridViewAutoSizeColumnCriteriaInternal autoSizeColumnCriteriaFilter, bool blnFixedHeight)
		{
			bool flag = false;
			for (DataGridViewColumn dataGridViewColumn = Columns.GetFirstColumn(DataGridViewElementStates.Visible); dataGridViewColumn != null; dataGridViewColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
			{
				DataGridViewAutoSizeColumnCriteriaInternal inheritedAutoSizeMode = (DataGridViewAutoSizeColumnCriteriaInternal)dataGridViewColumn.InheritedAutoSizeMode;
				if ((inheritedAutoSizeMode & autoSizeColumnCriteriaFilter) != DataGridViewAutoSizeColumnCriteriaInternal.NotSet)
				{
					flag |= AutoResizeColumnInternal(dataGridViewColumn.Index, inheritedAutoSizeMode, blnFixedHeight);
				}
			}
			return flag;
		}

		private bool AdjustExpandingColumns(DataGridViewAutoSizeColumnCriteriaInternal autoSizeColumnCriteriaFilter, int intRowIndex)
		{
			bool flag = false;
			for (DataGridViewColumn dataGridViewColumn = Columns.GetFirstColumn(DataGridViewElementStates.Visible); dataGridViewColumn != null; dataGridViewColumn = Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None))
			{
				DataGridViewAutoSizeColumnCriteriaInternal inheritedAutoSizeMode = (DataGridViewAutoSizeColumnCriteriaInternal)dataGridViewColumn.InheritedAutoSizeMode;
				if ((inheritedAutoSizeMode & autoSizeColumnCriteriaFilter) != DataGridViewAutoSizeColumnCriteriaInternal.NotSet)
				{
					flag |= AdjustExpandingColumn(dataGridViewColumn, inheritedAutoSizeMode, intRowIndex);
				}
			}
			return flag;
		}

		private bool AdjustExpandingColumn(DataGridViewColumn objDataGridViewColumn, DataGridViewAutoSizeColumnCriteriaInternal autoSizeColumnCriteriaInternal, int intRowIndex)
		{
			bool result = false;
			try
			{
				AutoSizeCount++;
				DataGridViewRow dataGridViewRow = Rows.SharedRow(intRowIndex);
				int num = dataGridViewRow.Cells[objDataGridViewColumn.Index].GetPreferredWidth(intRowIndex, dataGridViewRow.GetHeight(intRowIndex));
				if (num > 65536)
				{
					num = 65536;
				}
				if (objDataGridViewColumn.Width < num)
				{
					objDataGridViewColumn.ThicknessInternal = num;
					result = true;
				}
			}
			finally
			{
				AutoSizeCount--;
			}
			return result;
		}

		/// 
		/// Called when [row height info pushed].
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="intHeight">The height.</param>
		/// <param name="intMinimumHeight">The minimum height.</param>
		/// </returns>
		private bool OnRowHeightInfoPushed(int intRowIndex, int intHeight, int intMinimumHeight)
		{
			if (VirtualMode || DataSource != null)
			{
				DataGridViewRowHeightInfoPushedEventArgs e = new DataGridViewRowHeightInfoPushedEventArgs(intRowIndex, intHeight, intMinimumHeight);
				OnRowHeightInfoPushed(e);
				if (e.Handled)
				{
					UpdateRowHeightInfo(intRowIndex, blnUpdateToEnd: false);
					return true;
				}
			}
			return false;
		}

		private void AutoResizeRowInternal(int intRowIndex, DataGridViewAutoSizeRowMode enmAutoSizeRowMode, bool blnFixedWidth, bool blnInternalAutosizing)
		{
			try
			{
				AutoSizeCount++;
				DataGridViewRowCollection rows = Rows;
				DataGridViewRow dataGridViewRow = rows.SharedRow(intRowIndex);
				dataGridViewRow.GetHeightInfo(intRowIndex, out var intHeight, out var intMinimumHeight);
				int num = dataGridViewRow.GetPreferredHeight(intRowIndex, enmAutoSizeRowMode, blnFixedWidth);
				if (num < intMinimumHeight)
				{
					num = intMinimumHeight;
				}
				if (num > 65536)
				{
					num = 65536;
				}
				if (intHeight == num)
				{
					return;
				}
				if (AutoSizeRowsMode == DataGridViewAutoSizeRowsMode.None)
				{
					if (!OnRowHeightInfoPushed(intRowIndex, num, intMinimumHeight))
					{
						rows[intRowIndex].ThicknessInternal = num;
					}
				}
				else if (blnInternalAutosizing)
				{
					rows[intRowIndex].ThicknessInternal = num;
				}
				else
				{
					rows[intRowIndex].Thickness = num;
				}
			}
			finally
			{
				AutoSizeCount--;
			}
		}

		internal void OnAddedRows_PreNotification(DataGridViewRow[] arrDataGridViewRows)
		{
			foreach (DataGridViewRow dataGridViewRow in arrDataGridViewRows)
			{
				OnAddedRow_PreNotification(dataGridViewRow.Index);
			}
		}

		internal void OnAddedRows_PostNotification(DataGridViewRow[] arrDataGridViewRows)
		{
			foreach (DataGridViewRow dataGridViewRow in arrDataGridViewRows)
			{
				OnAddedRow_PostNotification(dataGridViewRow.Index);
			}
		}

		internal void OnClearingRows()
		{
			CurrentPage = 1;
			CurrentCell = null;
			NewRowIndex = -1;
			DataGridViewIntLinkedList selectedBandIndexes = SelectedBandIndexes;
			DataGridViewCellLinkedList individualSelectedCells = IndividualSelectedCells;
			mobjDataGridViewState2[262144] = selectedBandIndexes.Count > 0 || individualSelectedCells.Count > 0;
			selectedBandIndexes.Clear();
			SelectedBandSnapshotIndexes?.Clear();
			individualSelectedCells.Clear();
			IndividualReadOnlyCells.Clear();
		}

		/// 
		/// Called when [inserting row].
		/// </summary>
		/// <param name="intRowIndexInserted">The row index inserted.</param>
		/// <param name="objDataGridViewRow">The data grid view row.</param>
		/// <param name="enmRowState">State of the row.</param>
		/// <param name="objNewCurrentCell">The new current cell.</param>
		/// <param name="blnFirstInsertion">if set to true</c> [first insertion].</param>
		/// <param name="intInsertionCount">The insertion count.</param>
		/// <param name="blnForce">if set to true</c> [force].</param>
		internal void OnInsertingRow(int intRowIndexInserted, DataGridViewRow objDataGridViewRow, DataGridViewElementStates enmRowState, ref Point objNewCurrentCell, bool blnFirstInsertion, int intInsertionCount, bool blnForce)
		{
			if (blnFirstInsertion)
			{
				if (mobjCurrentCellPoint.Y != -1 && intRowIndexInserted <= mobjCurrentCellPoint.Y)
				{
					objNewCurrentCell = new Point(mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y + intInsertionCount);
					if (blnForce)
					{
						mobjDataGridViewState1[4194304] = true;
						SetCurrentCellAddressCore(-1, -1, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false);
					}
					else
					{
						ResetCurrentCell();
					}
				}
				else
				{
					objNewCurrentCell = new Point(-1, -1);
				}
			}
			else if (objNewCurrentCell.Y != -1)
			{
				objNewCurrentCell.Y += intInsertionCount;
			}
			OnAddingRow(objDataGridViewRow, enmRowState, blnCheckFrozenState: false);
			CorrectRowFrozenState(objDataGridViewRow, enmRowState, intRowIndexInserted);
			switch (SelectionMode)
			{
			case DataGridViewSelectionMode.FullRowSelect:
			case DataGridViewSelectionMode.RowHeaderSelect:
			{
				int count = SelectedBandIndexes.Count;
				for (int i = 0; i < count; i++)
				{
					int num = SelectedBandIndexes[i];
					if (intRowIndexInserted <= num)
					{
						SelectedBandIndexes[i] = num + intInsertionCount;
					}
				}
				if (SelectedBandSnapshotIndexes == null)
				{
					break;
				}
				count = SelectedBandSnapshotIndexes.Count;
				for (int i = 0; i < count; i++)
				{
					int num2 = SelectedBandSnapshotIndexes[i];
					if (intRowIndexInserted <= num2)
					{
						SelectedBandSnapshotIndexes[i] = num2 + intInsertionCount;
					}
				}
				break;
			}
			}
		}

		internal void OnInsertedRow_PreNotification(int intRowIndex, int insertionCount)
		{
			DisplayedBandsInfo.CorrectRowIndexAfterInsertion(intRowIndex, insertionCount);
			CorrectRowIndexesAfterInsertion(intRowIndex, insertionCount);
			OnAddedRow_PreNotification(intRowIndex);
		}

		internal void OnInsertedRow_PostNotification(int intRowIndex, Point objNewCurrentCell, bool blnLastInsertion)
		{
			OnAddedRow_PostNotification(intRowIndex);
			if (blnLastInsertion && objNewCurrentCell.Y != -1)
			{
				SetAndSelectCurrentCellAddress(objNewCurrentCell.X, objNewCurrentCell.Y, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false, blnClearSelection: false, Rows.GetRowCount(DataGridViewElementStates.Visible) == 1);
			}
		}

		private void ResetCurrentCell()
		{
			if (mobjCurrentCellPoint.X != -1 && !SetCurrentCellAddressCore(-1, -1, blnSetAnchorCellAddress: true, blnValidateCurrentCell: true, blnThroughMouseClick: false))
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CellChangeCannotBeCommittedOrAborted"));
			}
		}

		/// 
		/// Called when [inserting rows].
		/// </summary>
		/// <param name="intRowIndexInserted">The row index inserted.</param>
		/// <param name="arrDataGridViewRows">The data grid view rows.</param>
		/// <param name="objNewCurrentCell">The new current cell.</param>
		internal void OnInsertingRows(int intRowIndexInserted, DataGridViewRow[] arrDataGridViewRows, ref Point objNewCurrentCell)
		{
			if (mobjCurrentCellPoint.Y != -1 && intRowIndexInserted <= mobjCurrentCellPoint.Y)
			{
				objNewCurrentCell = new Point(mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y + arrDataGridViewRows.Length);
				ResetCurrentCell();
			}
			else
			{
				objNewCurrentCell = new Point(-1, -1);
			}
			OnAddingRows(arrDataGridViewRows, blnCheckFrozenStates: false);
			CorrectRowFrozenStates(arrDataGridViewRows, intRowIndexInserted);
			switch (SelectionMode)
			{
			case DataGridViewSelectionMode.FullRowSelect:
			case DataGridViewSelectionMode.RowHeaderSelect:
			{
				int count = SelectedBandIndexes.Count;
				for (int i = 0; i < count; i++)
				{
					int num = SelectedBandIndexes[i];
					if (intRowIndexInserted <= num)
					{
						SelectedBandIndexes[i] = num + arrDataGridViewRows.Length;
					}
				}
				if (SelectedBandSnapshotIndexes == null)
				{
					break;
				}
				count = SelectedBandSnapshotIndexes.Count;
				for (int i = 0; i < count; i++)
				{
					int num2 = SelectedBandSnapshotIndexes[i];
					if (intRowIndexInserted <= num2)
					{
						SelectedBandSnapshotIndexes[i] = num2 + arrDataGridViewRows.Length;
					}
				}
				break;
			}
			}
		}

		/// 
		/// Called when [inserted rows_ pre notification].
		/// </summary>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="arrDataGridViewRows">The data grid view rows.</param>
		internal void OnInsertedRows_PreNotification(int intRowIndex, DataGridViewRow[] arrDataGridViewRows)
		{
			DisplayedBandsInfo.CorrectRowIndexAfterInsertion(intRowIndex, arrDataGridViewRows.Length);
			CorrectRowIndexesAfterInsertion(intRowIndex, arrDataGridViewRows.Length);
			OnAddedRows_PreNotification(arrDataGridViewRows);
		}

		internal void OnInsertedRows_PostNotification(DataGridViewRow[] arrDataGridViewRows, Point objNewCurrentCell)
		{
			OnAddedRows_PostNotification(arrDataGridViewRows);
			if (objNewCurrentCell.Y != -1)
			{
				SetAndSelectCurrentCellAddress(objNewCurrentCell.X, objNewCurrentCell.Y, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false, blnClearSelection: false, blnForceCurrentCellSelection: false);
			}
		}

		internal void CompleteCellsCollection(DataGridViewRow objDataGridViewRow)
		{
			int count = objDataGridViewRow.Cells.Count;
			if (Columns.Count <= count)
			{
				return;
			}
			int num = 0;
			DataGridViewCell[] array = new DataGridViewCell[Columns.Count - count];
			for (int i = count; i < Columns.Count; i++)
			{
				if (Columns[i].CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_AColumnHasNoCellTemplate"));
				}
				DataGridViewCell dataGridViewCell = (DataGridViewCell)Columns[i].CellTemplate.Clone();
				array[num] = dataGridViewCell;
				num++;
			}
			objDataGridViewRow.Cells.AddRange(array);
		}

		internal void OnRowsRemovedInternal(int intRowIndex, int intRowCount)
		{
			if (UseInternalPaging && CurrentPage > TotalPages)
			{
				CurrentPage = TotalPages;
			}
			OnRowsRemoved(new DataGridViewRowsRemovedEventArgs(intRowIndex, intRowCount));
		}

		internal void OnRowsAddedInternal(int intRowIndex, int intRowCount)
		{
			OnRowsAdded(new DataGridViewRowsAddedEventArgs(intRowIndex, intRowCount));
		}

		internal void OnRemovedRow_PreNotification(int intRowIndexDeleted)
		{
			CorrectRowIndexesAfterDeletion(intRowIndexDeleted);
		}

		internal void OnClearedRows()
		{
			CurrentCell = null;
			NewRowIndex = -1;
			DataGridViewIntLinkedList selectedBandIndexes = SelectedBandIndexes;
			DataGridViewCellLinkedList individualSelectedCells = IndividualSelectedCells;
			mobjDataGridViewState2[262144] = selectedBandIndexes.Count > 0 || individualSelectedCells.Count > 0;
			selectedBandIndexes.Clear();
			individualSelectedCells.Clear();
			IndividualReadOnlyCells.Clear();
		}

		internal void OnRemovingRow(int intRowIndexDeleted, out Point objNewCurrentCell, bool blnForce)
		{
			DataGridViewRowCollection rows = Rows;
			Debug.Assert(intRowIndexDeleted >= 0 && intRowIndexDeleted < rows.Count);
			mobjDataGridViewState1[4194304] = false;
			objNewCurrentCell = new Point(-1, -1);
			if (mobjCurrentCellPoint.Y != -1 && intRowIndexDeleted <= mobjCurrentCellPoint.Y)
			{
				int y;
				if (intRowIndexDeleted == mobjCurrentCellPoint.Y)
				{
					int previousRow = rows.GetPreviousRow(intRowIndexDeleted, DataGridViewElementStates.Visible);
					int nextRow = rows.GetNextRow(intRowIndexDeleted, DataGridViewElementStates.Visible);
					if (previousRow <= -1 || !AllowUserToAddRowsInternal)
					{
						y = ((nextRow <= -1) ? previousRow : (nextRow - 1));
					}
					else
					{
						Debug.Assert(NewRowIndex != -1);
						Debug.Assert(NewRowIndex == rows.Count - 1);
						y = ((nextRow <= -1 || nextRow >= rows.Count - 1) ? previousRow : (nextRow - 1));
					}
					IsCurrentCellDirtyInternal = false;
					IsCurrentRowDirtyInternal = false;
				}
				else
				{
					Debug.Assert(intRowIndexDeleted < mobjCurrentCellPoint.Y);
					y = mobjCurrentCellPoint.Y - 1;
				}
				objNewCurrentCell = new Point(mobjCurrentCellPoint.X, y);
				if (intRowIndexDeleted == mobjCurrentCellPoint.Y)
				{
					bool condition = SetCurrentCellAddressCore(-1, -1, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false);
					Debug.Assert(condition);
				}
				else if (blnForce)
				{
					mobjDataGridViewState1[4194304] = true;
					bool condition2 = SetCurrentCellAddressCore(-1, -1, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false);
					Debug.Assert(condition2);
				}
				else
				{
					ResetCurrentCell();
				}
			}
			bool flag = false;
			DataGridViewSelectionMode selectionMode = SelectionMode;
			if (selectionMode == DataGridViewSelectionMode.FullRowSelect || selectionMode == DataGridViewSelectionMode.RowHeaderSelect)
			{
				DataGridViewIntLinkedList selectedBandIndexes = SelectedBandIndexes;
				int num = selectedBandIndexes.Count;
				int num2 = 0;
				while (num2 < num)
				{
					int num3 = selectedBandIndexes[num2];
					if (intRowIndexDeleted == num3)
					{
						flag = true;
						selectedBandIndexes.RemoveAt(num2);
						num--;
						continue;
					}
					if (intRowIndexDeleted < num3)
					{
						selectedBandIndexes[num2] = num3 - 1;
					}
					num2++;
				}
				DataGridViewIntLinkedList selectedBandSnapshotIndexes = SelectedBandSnapshotIndexes;
				if (selectedBandSnapshotIndexes != null)
				{
					num = selectedBandSnapshotIndexes.Count;
					num2 = 0;
					while (num2 < num)
					{
						int num4 = selectedBandSnapshotIndexes[num2];
						if (intRowIndexDeleted == num4)
						{
							selectedBandSnapshotIndexes.RemoveAt(num2);
							num--;
							continue;
						}
						if (intRowIndexDeleted < num4)
						{
							selectedBandSnapshotIndexes[num2] = num4 - 1;
						}
						num2++;
					}
				}
			}
			mobjDataGridViewState2[262144] = mobjDataGridViewState2[262144] || IndividualSelectedCells.RemoveAllCellsAtBand(blnColumn: false, intRowIndexDeleted) > 0 || flag;
			IndividualReadOnlyCells.RemoveAllCellsAtBand(blnColumn: false, intRowIndexDeleted);
		}

		internal void OnRemovedRow_PostNotification(DataGridViewRow objDataGridViewRow, Point objNewCurrentCell)
		{
			if (objNewCurrentCell.Y != -1)
			{
				SetAndSelectCurrentCellAddress(objNewCurrentCell.X, objNewCurrentCell.Y, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false, blnClearSelection: false, blnForceCurrentCellSelection: false);
			}
			FlushSelectionChanged();
			bool flag = objDataGridViewRow.DataGridView == null && objDataGridViewRow.Displayed;
			if (flag)
			{
				objDataGridViewRow.DisplayedInternal = false;
				DataGridViewRowStateChangedEventArgs e = new DataGridViewRowStateChangedEventArgs(objDataGridViewRow, DataGridViewElementStates.Displayed);
				OnRowStateChanged(-1, e);
			}
			if (AutoSizeRowsMode != DataGridViewAutoSizeRowsMode.None && objDataGridViewRow.ThicknessInternal != objDataGridViewRow.CachedThickness)
			{
				objDataGridViewRow.ThicknessInternal = Math.Max(objDataGridViewRow.MinimumHeight, objDataGridViewRow.CachedThickness);
			}
			DataGridViewAutoSizeColumnCriteriaInternal dataGridViewAutoSizeColumnCriteriaInternal = DataGridViewAutoSizeColumnCriteriaInternal.AllRows;
			if (flag)
			{
				dataGridViewAutoSizeColumnCriteriaInternal |= DataGridViewAutoSizeColumnCriteriaInternal.DisplayedRows;
			}
			bool flag2 = AutoResizeAllVisibleColumnsInternal(dataGridViewAutoSizeColumnCriteriaInternal, blnFixedHeight: true);
			bool flag3 = ColumnHeadersHeightSizeMode != DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridViewRowHeadersWidthSizeMode rowHeadersWidthSizeMode = RowHeadersWidthSizeMode;
			bool flag4 = rowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing || rowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			if (flag4 && !flag2)
			{
				flag3 = true;
			}
			if (!flag3)
			{
				AutoResizeColumnHeadersHeight(flag4, blnFixedColumnsWidth: true);
			}
			if (!flag4)
			{
				AutoResizeRowHeadersWidth(rowHeadersWidthSizeMode, blnFixedColumnHeadersHeight: true, blnFixedRowsHeight: true);
			}
			if (!flag3 && !flag4)
			{
				AutoResizeColumnHeadersHeight(blnFixedRowHeadersWidth: true, blnFixedColumnsWidth: true);
			}
		}

		private void CorrectRowIndexesAfterDeletion(int intRowIndexDeleted)
		{
			DataGridViewRowCollection rows = Rows;
			int count = rows.Count;
			for (int i = intRowIndexDeleted; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Index >= 0)
				{
					dataGridViewRow.IndexInternal = dataGridViewRow.Index - 1;
				}
			}
			if (NewRowIndex == intRowIndexDeleted)
			{
				NewRowIndex = -1;
			}
			else if (NewRowIndex != -1)
			{
				NewRowIndex--;
			}
		}

		private void CorrectRowIndexesAfterInsertion(int intRowIndexInserted, int insertionCount)
		{
			DataGridViewRowCollection rows = Rows;
			int count = rows.Count;
			for (int i = intRowIndexInserted + insertionCount; i < count; i++)
			{
				DataGridViewRow dataGridViewRow = rows.SharedRow(i);
				if (dataGridViewRow.Index >= 0)
				{
					dataGridViewRow.IndexInternal = dataGridViewRow.Index + insertionCount;
				}
			}
			if (NewRowIndex != -1)
			{
				NewRowIndex += insertionCount;
			}
		}

		private void SetSelectedElementCore(int intColumnIndex, int intRowIndex, bool blnSelected)
		{
			SetSelectedElementCore(intColumnIndex, intRowIndex, blnSelected, blnClientSource: false);
		}

		private void SetSelectedElementCore(int intColumnIndex, int intRowIndex, bool blnSelected, bool blnClientSource)
		{
			switch (SelectionMode)
			{
			case DataGridViewSelectionMode.CellSelect:
				SetSelectedCellCore(intColumnIndex, intRowIndex, blnSelected);
				break;
			case DataGridViewSelectionMode.FullRowSelect:
				SetSelectedRowCore(intRowIndex, blnSelected, blnClientSource);
				break;
			case DataGridViewSelectionMode.FullColumnSelect:
				SetSelectedColumnCore(intColumnIndex, blnSelected);
				break;
			case DataGridViewSelectionMode.RowHeaderSelect:
				if (intColumnIndex != -1)
				{
					SetSelectedCellCore(intColumnIndex, intRowIndex, blnSelected, blnClientSource);
				}
				else
				{
					SetSelectedRowCore(intRowIndex, blnSelected);
				}
				break;
			case DataGridViewSelectionMode.ColumnHeaderSelect:
				if (intRowIndex != -1)
				{
					SetSelectedCellCore(intColumnIndex, intRowIndex, blnSelected);
				}
				else
				{
					SetSelectedColumnCore(intColumnIndex, blnSelected);
				}
				break;
			}
		}

		private bool SetAndSelectCurrentCellAddress(int intColumnIndex, int intRowIndex, bool blnSetAnchorCellAddress, bool blnValidateCurrentCell, bool blnThroughMouseClick, bool blnClearSelection, bool blnForceCurrentCellSelection)
		{
			if (!SetCurrentCellAddressCore(intColumnIndex, intRowIndex, blnSetAnchorCellAddress, blnValidateCurrentCell, blnThroughMouseClick))
			{
				return false;
			}
			if (IsInnerCellOutOfBounds(intColumnIndex, intRowIndex))
			{
				return false;
			}
			DataGridViewIntLinkedList selectedBandIndexes = SelectedBandIndexes;
			DataGridViewCellLinkedList individualSelectedCells = IndividualSelectedCells;
			if (blnClearSelection)
			{
				ClearSelection(intColumnIndex, intRowIndex, blnSelectExceptionElement: true);
			}
			else if (blnForceCurrentCellSelection)
			{
				SetSelectedElementCore(intColumnIndex, intRowIndex, blnSelected: true);
			}
			else
			{
				if (MultiSelect && individualSelectedCells.Count + selectedBandIndexes.Count > 1)
				{
					return true;
				}
				if (individualSelectedCells.Count == 1)
				{
					DataGridViewCell headCell = individualSelectedCells.HeadCell;
					if (headCell.ColumnIndex != intColumnIndex || headCell.RowIndex != intRowIndex)
					{
						return true;
					}
				}
				else if (selectedBandIndexes.Count == 1)
				{
					switch (SelectionMode)
					{
					case DataGridViewSelectionMode.FullRowSelect:
					case DataGridViewSelectionMode.RowHeaderSelect:
						if (selectedBandIndexes.HeadInt == intRowIndex)
						{
							break;
						}
						return true;
					case DataGridViewSelectionMode.FullColumnSelect:
					case DataGridViewSelectionMode.ColumnHeaderSelect:
						if (selectedBandIndexes.HeadInt == intColumnIndex)
						{
							break;
						}
						return true;
					}
				}
				SetSelectedElementCore(intColumnIndex, intRowIndex, blnSelected: true);
			}
			return true;
		}

		private void MakeFirstDisplayedCellCurrentCell(bool blnIncludeNewRow)
		{
			Point firstDisplayedCellAddress = FirstDisplayedCellAddress;
			if (firstDisplayedCellAddress.X != -1 && (blnIncludeNewRow || !AllowUserToAddRowsInternal || firstDisplayedCellAddress.Y != Rows.Count - 1))
			{
				SetAndSelectCurrentCellAddress(firstDisplayedCellAddress.X, firstDisplayedCellAddress.Y, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false, blnClearSelection: true, blnForceCurrentCellSelection: false);
			}
		}

		internal void OnRowCollectionChanged_PostNotification(bool blnRecreateNewRow, bool blnAllowSettingCurrentCell, CollectionChangeAction enmCca, DataGridViewRow objDataGridViewRow, int intRowIndex)
		{
			if (blnRecreateNewRow && enmCca == CollectionChangeAction.Refresh && Columns.Count != 0 && Rows.Count == 0 && AllowUserToAddRowsInternal)
			{
				AddNewRow(blnCreatedByEditing: false);
			}
			if (enmCca == CollectionChangeAction.Refresh)
			{
				FlushSelectionChanged();
			}
			if ((enmCca == CollectionChangeAction.Refresh || enmCca == CollectionChangeAction.Add) && mobjCurrentCellPoint.X == -1 && blnAllowSettingCurrentCell && !InSortOperation)
			{
				MakeFirstDisplayedCellCurrentCell(blnIncludeNewRow: false);
			}
			if (AutoSize)
			{
				bool flag = true;
				switch (enmCca)
				{
				case CollectionChangeAction.Add:
					flag = (Rows.GetRowState(intRowIndex) & DataGridViewElementStates.Visible) != 0;
					break;
				case CollectionChangeAction.Remove:
					flag = objDataGridViewRow.DataGridView == null && objDataGridViewRow.Visible;
					break;
				}
			}
		}

		internal void OnAddingRows(DataGridViewRow[] arrDataGridViewRows, bool blnCheckFrozenStates)
		{
			foreach (DataGridViewRow dataGridViewRow in arrDataGridViewRows)
			{
				if (dataGridViewRow == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_AtLeastOneRowIsNull"));
				}
				if (dataGridViewRow.DataGridView != null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_RowAlreadyBelongsToDataGridView"));
				}
				if (dataGridViewRow.Selected)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_CannotAddOrInsertSelectedRow"));
				}
				if (dataGridViewRow.Cells.Count > Columns.Count)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewRowCollection_TooManyCells"));
				}
			}
			int num = arrDataGridViewRows.Length;
			for (int j = 0; j < num - 1; j++)
			{
				for (int k = j + 1; k < num; k++)
				{
					if (arrDataGridViewRows[j] == arrDataGridViewRows[k])
					{
						throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddIdenticalRows"));
					}
				}
			}
			if (blnCheckFrozenStates)
			{
				CorrectRowFrozenStates(arrDataGridViewRows, Rows.Count);
			}
			foreach (DataGridViewRow dataGridViewRow2 in arrDataGridViewRows)
			{
				CompleteCellsCollection(dataGridViewRow2);
				OnAddingRow(dataGridViewRow2, dataGridViewRow2.State, blnCheckFrozenState: false);
			}
		}

		private void CorrectRowFrozenStates(DataGridViewRow[] arrDataGridViewRows, int intRowIndexInserted)
		{
			bool flag = false;
			bool flag2 = true;
			bool flag3 = false;
			DataGridViewRowCollection rows = Rows;
			int previousRow = rows.GetPreviousRow(intRowIndexInserted, DataGridViewElementStates.Visible);
			if (previousRow != -1)
			{
				flag2 = (rows.GetRowState(previousRow) & DataGridViewElementStates.Frozen) == DataGridViewElementStates.Frozen;
			}
			previousRow = rows.GetNextRow(intRowIndexInserted - 1, DataGridViewElementStates.Visible);
			if (previousRow != -1)
			{
				flag = true;
				flag3 = (rows.GetRowState(previousRow) & DataGridViewElementStates.Frozen) == DataGridViewElementStates.Frozen;
			}
			for (int i = 0; i < arrDataGridViewRows.Length; i++)
			{
				bool frozen = arrDataGridViewRows[i].Frozen;
				if (!flag2 && frozen)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddFrozenRow"));
				}
				flag2 = frozen;
				if (i == arrDataGridViewRows.Length - 1 && !frozen && flag && flag3)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CannotAddNonFrozenRow"));
				}
			}
		}

		internal bool OnSortCompare(DataGridViewColumn objDataGridViewSortedColumn, object objValue1, object objValue2, int intRowIndex1, int intRowIndex2, out int intSortResult)
		{
			DataGridViewSortCompareEventArgs e = new DataGridViewSortCompareEventArgs(objDataGridViewSortedColumn, objValue1, objValue2, intRowIndex1, intRowIndex2);
			OnSortCompare(e);
			intSortResult = e.SortResult;
			return e.Handled;
		}

		internal void OnRowUnshared(DataGridViewRow objDataGridViewRow2)
		{
		}

		internal void SwapSortedRows(int intRowIndex1, int intRowIndex2)
		{
			if (intRowIndex1 == intRowIndex2)
			{
				return;
			}
			if (intRowIndex1 == mobjCurrentCellCache.Y)
			{
				mobjCurrentCellCache.Y = intRowIndex2;
			}
			else if (intRowIndex2 == mobjCurrentCellCache.Y)
			{
				mobjCurrentCellCache.Y = intRowIndex1;
			}
			switch (SelectionMode)
			{
			case DataGridViewSelectionMode.FullRowSelect:
			case DataGridViewSelectionMode.RowHeaderSelect:
			{
				DataGridViewIntLinkedList selectedBandIndexes = SelectedBandIndexes;
				int num = selectedBandIndexes.IndexOf(intRowIndex1);
				int num2 = selectedBandIndexes.IndexOf(intRowIndex2);
				if (num == -1 || num2 != -1)
				{
					if (num == -1 && num2 != -1)
					{
						selectedBandIndexes[num2] = intRowIndex1;
					}
				}
				else
				{
					selectedBandIndexes[num] = intRowIndex2;
				}
				DataGridViewIntLinkedList selectedBandSnapshotIndexes = SelectedBandSnapshotIndexes;
				if (selectedBandSnapshotIndexes != null)
				{
					num = selectedBandSnapshotIndexes.IndexOf(intRowIndex1);
					num2 = selectedBandSnapshotIndexes.IndexOf(intRowIndex2);
					if (num != -1 && num2 == -1)
					{
						selectedBandSnapshotIndexes[num] = intRowIndex2;
					}
					else if (num == -1 && num2 != -1)
					{
						selectedBandSnapshotIndexes[num2] = intRowIndex1;
					}
				}
				break;
			}
			}
		}

		internal void OnBandMinimumThicknessChanged(DataGridViewBand objDataGridViewBand)
		{
			if (objDataGridViewBand is DataGridViewColumn objDataGridViewColumn)
			{
				DataGridViewColumnEventArgs e = new DataGridViewColumnEventArgs(objDataGridViewColumn);
				OnColumnMinimumWidthChanged(e);
			}
			else
			{
				DataGridViewRowEventArgs e2 = new DataGridViewRowEventArgs((DataGridViewRow)objDataGridViewBand);
				OnRowMinimumHeightChanged(e2);
			}
		}

		internal void OnBandThicknessChanged(DataGridViewBand objDataGridViewBand)
		{
			if (objDataGridViewBand is DataGridViewColumn objDataGridViewColumn)
			{
				DataGridViewColumnEventArgs e = new DataGridViewColumnEventArgs(objDataGridViewColumn);
				OnColumnWidthChanged(e);
			}
			else
			{
				DataGridViewRowEventArgs e2 = new DataGridViewRowEventArgs((DataGridViewRow)objDataGridViewBand);
				OnRowHeightChanged(e2);
			}
		}

		internal void OnBandThicknessChanging()
		{
			if (InAdjustFillingColumns)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterAutoFillColumnParameter"));
			}
		}

		internal void OnBandHeaderCellChanged(DataGridViewBand objDataGridViewBand)
		{
			if (objDataGridViewBand is DataGridViewColumn objDataGridViewColumn)
			{
				DataGridViewColumnEventArgs e = new DataGridViewColumnEventArgs(objDataGridViewColumn);
				OnColumnHeaderCellChanged(e);
			}
			else
			{
				DataGridViewRowEventArgs e2 = new DataGridViewRowEventArgs((DataGridViewRow)objDataGridViewBand);
				OnRowHeaderCellChanged(e2);
			}
		}

		internal void OnCellValueChangedInternal(DataGridViewCellEventArgs e, bool blnClientSource)
		{
			OnCellValueChanged(e, blnClientSource);
		}

		internal void OnBandDefaultCellStyleChanged(DataGridViewBand objDataGridViewBand)
		{
			if (objDataGridViewBand is DataGridViewColumn objDataGridViewColumn)
			{
				DataGridViewColumnEventArgs e = new DataGridViewColumnEventArgs(objDataGridViewColumn);
				OnColumnDefaultCellStyleChanged(e);
			}
			else
			{
				DataGridViewRowEventArgs e2 = new DataGridViewRowEventArgs((DataGridViewRow)objDataGridViewBand);
				OnRowDefaultCellStyleChanged(e2);
			}
		}

		internal void OnColumnFillWeightChanging(DataGridViewColumn objDataGridViewColumn, float fillWeight)
		{
			if (InAdjustFillingColumns)
			{
				throw new InvalidOperationException(SR.GetString("DataGridView_CannotAlterAutoFillColumnParameter"));
			}
			float num = Columns.GetColumnsFillWeight(DataGridViewElementStates.None) - objDataGridViewColumn.FillWeight + fillWeight;
			if (num > 65535f)
			{
				object[] arrArgs = new object[1] { 65535.ToString(CultureInfo.CurrentCulture) };
				throw new InvalidOperationException(SR.GetString("DataGridView_WeightSumCannotExceedLongMaxValue", arrArgs));
			}
		}

		internal void OnColumnFillWeightChanged(DataGridViewColumn objDataGridViewColumn)
		{
			if (objDataGridViewColumn.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
			{
				mobjDataGridViewState2[67108864] = true;
				PerformLayoutPrivate(blnInvalidInAdjustFillingColumns: false);
			}
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.CellContextMenuChanged"></see> event. </summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellContextMenuChanged(DataGridViewCellEventArgs e)
		{
			this.CellContextMenuChanged?.Invoke(this, e);
		}

		/// 
		/// Raises the <see cref="E:CellContextMenuStripChanged" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs" /> instance containing the event data.</param>
		protected virtual void OnCellContextMenuStripChanged(DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("e.ColumnIndex");
			}
			if (e.RowIndex >= Rows.Count)
			{
				throw new ArgumentOutOfRangeException("e.RowIndex");
			}
			this.CellContextMenuStripChanged?.Invoke(this, e);
		}

		/// 
		/// Called when [cell context menu changed].
		/// </summary>
		/// <param name="objDataGridViewCell">The data grid view cell.</param>
		internal void OnCellContextMenuChanged(DataGridViewCell objDataGridViewCell)
		{
			DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(objDataGridViewCell);
			OnCellContextMenuChanged(e);
		}

		/// 
		/// Called when [cell context menu strip changed].
		/// </summary>
		/// <param name="dataGridViewCell">The data grid view cell.</param>
		internal void OnCellContextMenuStripChanged(DataGridViewCell dataGridViewCell)
		{
			DataGridViewCellEventArgs e = new DataGridViewCellEventArgs(dataGridViewCell);
			OnCellContextMenuStripChanged(e);
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.CellMouseDown"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		/// <exception cref="T:System.Exception">This action would commit a cell value or enter edit mode, but an error in the data source prevents the action and either there is no handler for the <see cref="E:System.Windows.Forms.DataGridView.DataError"></see> event or the handler has set the <see cref="P:System.Windows.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. </exception>
		protected virtual void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
		{
			if (GetHandler(EVENT_DATAGRIDVIEWCELLMOUSEDOWN) is DataGridViewCellMouseEventHandler dataGridViewCellMouseEventHandler)
			{
				dataGridViewCellMouseEventHandler(this, e);
			}
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.CellMouseEnter"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellMouseEnter(DataGridViewCellEventArgs e)
		{
			this.CellMouseEnter?.Invoke(this, e);
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.CellMouseLeave"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellMouseLeave(DataGridViewCellEventArgs e)
		{
			this.CellMouseLeave?.Invoke(this, e);
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.CellMouseMove"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellMouseMove(DataGridViewCellMouseEventArgs e)
		{
			this.CellMouseMove?.Invoke(this, e);
		}

		/// Raises the <see cref="E:System.Windows.Forms.DataGridView.CellMouseUp"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.ColumnIndex"></see> property of e is greater than the number of columns in the control minus one.-or-The value of the <see cref="P:System.Windows.Forms.DataGridViewCellMouseEventArgs.RowIndex"></see> property of e is greater than the number of rows in the control minus one.</exception>
		protected virtual void OnCellMouseUp(DataGridViewCellMouseEventArgs e)
		{
			if (GetHandler(EVENT_DATAGRIDVIEWCELLMOUSEUP) is DataGridViewCellMouseEventHandler dataGridViewCellMouseEventHandler)
			{
				dataGridViewCellMouseEventHandler(this, e);
			}
		}

		private bool ShouldSerializeAlternatingRowsDefaultCellStyle()
		{
			DataGridViewCellStyle obj = new DataGridViewCellStyle();
			return !AlternatingRowsDefaultCellStyle.Equals(obj);
		}

		private bool ShouldSerializeBackgroundColor()
		{
			return !BackgroundColor.Equals(DefaultBackgroundBrush.Color);
		}

		private bool ShouldSerializeColumnHeadersDefaultCellStyle()
		{
			return !ColumnHeadersDefaultCellStyle.Equals(DefaultColumnHeadersDefaultCellStyle);
		}

		private bool ShouldSerializeColumnHeadersHeight()
		{
			if (ColumnHeadersHeightSizeMode != DataGridViewColumnHeadersHeightSizeMode.AutoSize)
			{
				return 23 != ColumnHeadersHeight;
			}
			return false;
		}

		private bool ShouldSerializeDefaultCellStyle()
		{
			return !DefaultCellStyle.Equals(DefaultDefaultCellStyle);
		}

		private bool ShouldSerializeGridColor()
		{
			return false;
		}

		private bool ShouldSerializeRowHeadersDefaultCellStyle()
		{
			return !RowHeadersDefaultCellStyle.Equals(DefaultRowHeadersDefaultCellStyle);
		}

		private bool ShouldSerializeRowHeadersWidth()
		{
			DataGridViewRowHeadersWidthSizeMode rowHeadersWidthSizeMode = RowHeadersWidthSizeMode;
			if (rowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.EnableResizing && rowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.DisableResizing)
			{
				return false;
			}
			return 41 != RowHeadersWidth;
		}

		private bool ShouldSerializeRowsDefaultCellStyle()
		{
			DataGridViewCellStyle obj = new DataGridViewCellStyle();
			return !RowsDefaultCellStyle.Equals(obj);
		}

		private bool ShouldSerializeRowTemplate()
		{
			return mobjRowTemplate != null;
		}

		private void SetColumnHeadersHeightInternal(int columnHeadersHeight, bool blnInvalidInAdjustFillingColumns)
		{
			mintColumnHeadersHeight = columnHeadersHeight;
			if (AutoSize)
			{
				Invalidate();
			}
			else if (LayoutInfo.ColumnHeadersVisible)
			{
				PerformLayoutPrivate(blnInvalidInAdjustFillingColumns);
				Invalidate();
			}
			OnColumnHeadersHeightChanged(EventArgs.Empty);
		}

		/// 
		/// Sets the current cell.
		/// </summary>
		/// <param name="objValue">The obj value.</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		internal void SetCurrentCell(DataGridViewCell objValue, bool blnClientSource)
		{
			if ((objValue == null || (objValue.RowIndex == mobjCurrentCellPoint.Y && objValue.ColumnIndex == mobjCurrentCellPoint.X)) && (objValue != null || mobjCurrentCellPoint.X == -1))
			{
				return;
			}
			if (objValue == null)
			{
				ClearSelection();
				if (!SetCurrentCellAddressCore(-1, -1, blnSetAnchorCellAddress: true, blnValidateCurrentCell: true, blnThroughMouseClick: false))
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CellChangeCannotBeCommittedOrAborted"));
				}
			}
			else
			{
				if (objValue.DataGridView != this)
				{
					throw new ArgumentException(SR.GetString("DataGridView_CellDoesNotBelongToDataGridView"));
				}
				if (!Columns[objValue.ColumnIndex].Visible || (Rows.GetRowState(objValue.RowIndex) & DataGridViewElementStates.Visible) == 0)
				{
					throw new InvalidOperationException(SR.GetString("DataGridView_CurrentCellCannotBeInvisible"));
				}
				if (!IsInnerCellOutOfBounds(objValue.ColumnIndex, objValue.RowIndex))
				{
					ClearSelection(objValue.ColumnIndex, objValue.RowIndex, blnSelectExceptionElement: true, blnClientSource);
					if (!SetCurrentCellAddressCore(objValue.ColumnIndex, objValue.RowIndex, blnSetAnchorCellAddress: true, blnValidateCurrentCell: false, blnThroughMouseClick: false, blnClientSource))
					{
						throw new InvalidOperationException(SR.GetString("DataGridView_CellChangeCannotBeCommittedOrAborted"));
					}
				}
				if (!blnClientSource)
				{
					PerformScrollIntoView(objValue, blnHidePopups: false);
					if (UseInternalPaging)
					{
						CurrentPage = GetCellPageNumber(objValue);
					}
				}
			}
			if (!blnClientSource)
			{
				UpdateParams(AttributeType.Visual);
			}
		}

		/// 
		/// Scrolls cell into view.
		/// </summary>
		/// <param name="objDataGridViewCell">The data grid view cell.</param>
		public virtual void ScrollIntoView(DataGridViewCell objDataGridViewCell)
		{
			if (objDataGridViewCell == null || objDataGridViewCell.DataGridView == null || objDataGridViewCell.DataGridView != this)
			{
				return;
			}
			if (UseInternalPaging)
			{
				int num = objDataGridViewCell.RowIndex / ItemsPerPage + 1;
				if (num > 0 && num <= TotalPages)
				{
					CurrentPage = num;
				}
			}
			PerformScrollIntoView(objDataGridViewCell, blnHidePopups: false);
		}

		/// 
		/// Performs scroll into view.
		/// </summary>
		/// <param name="objDataGridViewCell">The data grid view cell.</param>
		/// <param name="blnHidePopups">if set to true</c> [BLN hide popups].</param>
		internal void PerformScrollIntoView(DataGridViewCell objDataGridViewCell, bool blnHidePopups)
		{
			if (objDataGridViewCell != null && Context is IContextMethodInvoker contextMethodInvoker)
			{
				contextMethodInvoker.InvokeMethod(this, InvokationUniqueness.Component, "DataGridView_PerformScrollIntoView", ID, objDataGridViewCell.MemberIDInternal.ToString(), blnHidePopups ? "1" : "0");
			}
		}

		/// 
		/// Gets the cell page number.
		/// </summary>
		/// <param name="objDataGridViewCell">The obj data grid view cell.</param>
		/// </returns>
		private int GetCellPageNumber(DataGridViewCell objDataGridViewCell)
		{
			return objDataGridViewCell.RowIndex / ItemsPerPage + 1;
		}

		/// 
		/// Gets the paged rows.
		/// </summary>
		/// <param name="blnPageContainsFrozenRows">if set to true</c> [BLN page contains frozen rows].</param>
		/// </returns>
		private IList GetPagedRows(out bool blnPageContainsFrozenRows)
		{
			blnPageContainsFrozenRows = false;
			DataGridViewRowCollection rows = Rows;
			if (UseInternalPaging)
			{
				List<object> list = new List<object>();
				int num = (CurrentPage - 1) * ItemsPerPage;
				int i = 0;
				int num2 = -1;
				for (int count = rows.Count; i < count; i++)
				{
					if (list.Count >= ItemsPerPage)
					{
						break;
					}
					if (!rows[i].Visible)
					{
						continue;
					}
					num2++;
					if (num2 < num)
					{
						continue;
					}
					DataGridViewRow dataGridViewRow = rows[i];
					if (dataGridViewRow != null)
					{
						if (dataGridViewRow.Frozen)
						{
							blnPageContainsFrozenRows = true;
						}
						list.Add(dataGridViewRow);
					}
				}
				return list;
			}
			return rows;
		}

		/// 
		/// Determines whether [is inner cell out of bounds] [the specified column index].
		/// </summary>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// 
		/// 	true</c> if [is inner cell out of bounds] [the specified column index]; otherwise, false</c>.
		/// </returns>
		private bool IsInnerCellOutOfBounds(int intColumnIndex, int intRowIndex)
		{
			if (intColumnIndex < Columns.Count && intRowIndex < Rows.Count && intColumnIndex != -1)
			{
				return intRowIndex == -1;
			}
			return true;
		}

		/// 
		/// Resets the color of the grid.
		/// </summary>
		private void ResetGridColor()
		{
			if (SkinFactory.GetSkin(this) is DataGridViewSkin dataGridViewSkin)
			{
				GridColor = dataGridViewSkin.GridLinesColor;
			}
			else
			{
				GridColor = SystemColors.ControlDark;
			}
		}

		/// 
		/// Sets the is current cell dirty internal.
		/// </summary>
		/// <param name="blnDirty">if set to true</c> [BLN dirty].</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		private void SetIsCurrentCellDirtyInternal(bool blnDirty, bool blnClientSource)
		{
			if (blnDirty != mobjDataGridViewState1[131072])
			{
				mobjDataGridViewState1[131072] = blnDirty;
				OnCurrentCellDirtyStateChanged(EventArgs.Empty, blnClientSource);
			}
		}

		internal void SetReadOnlyColumnCore(int intColumnIndex, bool blnReadOnly)
		{
			if (Columns[intColumnIndex].ReadOnly != blnReadOnly)
			{
				if (blnReadOnly)
				{
					try
					{
						mobjDataGridViewOper[16384] = true;
						RemoveIndividualReadOnlyCellsInColumn(intColumnIndex);
					}
					finally
					{
						mobjDataGridViewOper[16384] = false;
					}
					Columns[intColumnIndex].ReadOnlyInternal = true;
				}
				else
				{
					Columns[intColumnIndex].ReadOnlyInternal = false;
				}
			}
			else if (!blnReadOnly)
			{
				RemoveIndividualReadOnlyCellsInColumn(intColumnIndex);
			}
		}

		private void RemoveIndividualReadOnlyCellsInColumn(int intColumnIndex)
		{
			DataGridViewCellLinkedList individualReadOnlyCells = IndividualReadOnlyCells;
			int num = 0;
			while (num < individualReadOnlyCells.Count)
			{
				DataGridViewCell dataGridViewCell = individualReadOnlyCells[num];
				if (dataGridViewCell.ColumnIndex == intColumnIndex)
				{
					SetReadOnlyCellCore(dataGridViewCell.ColumnIndex, dataGridViewCell.RowIndex, blnReadOnly: false);
				}
				else
				{
					num++;
				}
			}
		}

		internal void SetReadOnlyRowCore(int intRowIndex, bool blnReadOnly)
		{
			DataGridViewRowCollection rows = Rows;
			DataGridViewElementStates rowState = rows.GetRowState(intRowIndex);
			if ((rowState & DataGridViewElementStates.ReadOnly) != 0 != blnReadOnly)
			{
				if (blnReadOnly)
				{
					try
					{
						mobjDataGridViewOper[16384] = true;
						RemoveIndividualReadOnlyCellsInRow(intRowIndex);
					}
					finally
					{
						mobjDataGridViewOper[16384] = false;
					}
					rows.SetRowState(intRowIndex, DataGridViewElementStates.ReadOnly, blnValue: true);
				}
				else
				{
					rows.SetRowState(intRowIndex, DataGridViewElementStates.ReadOnly, blnValue: false);
				}
			}
			else if (!blnReadOnly)
			{
				RemoveIndividualReadOnlyCellsInRow(intRowIndex);
			}
		}

		private void RemoveIndividualReadOnlyCellsInRow(int intRowIndex)
		{
			DataGridViewCellLinkedList individualReadOnlyCells = IndividualReadOnlyCells;
			int num = 0;
			while (num < individualReadOnlyCells.Count)
			{
				DataGridViewCell dataGridViewCell = individualReadOnlyCells[num];
				if (dataGridViewCell.RowIndex == intRowIndex)
				{
					SetReadOnlyCellCore(dataGridViewCell.ColumnIndex, intRowIndex, blnReadOnly: false);
				}
				else
				{
					num++;
				}
			}
		}

		internal void SetReadOnlyCellCore(int intColumnIndex, int intRowIndex, bool blnReadOnly)
		{
			DataGridViewRowCollection rows = Rows;
			DataGridViewRow dataGridViewRow = rows.SharedRow(intRowIndex);
			DataGridViewElementStates rowState = rows.GetRowState(intRowIndex);
			DataGridViewCellLinkedList individualReadOnlyCells = IndividualReadOnlyCells;
			if (IsSharedCellReadOnly(dataGridViewRow.Cells[intColumnIndex], intRowIndex) != blnReadOnly)
			{
				DataGridViewCell dataGridViewCell = rows[intRowIndex].Cells[intColumnIndex];
				if (blnReadOnly)
				{
					if ((rowState & DataGridViewElementStates.ReadOnly) == 0 && !Columns[intColumnIndex].ReadOnly)
					{
						individualReadOnlyCells.Add(dataGridViewCell);
						dataGridViewCell.ReadOnlyInternal = true;
					}
				}
				else
				{
					if (individualReadOnlyCells.Contains(dataGridViewCell))
					{
						individualReadOnlyCells.Remove(dataGridViewCell);
					}
					else
					{
						if (Columns[intColumnIndex].ReadOnly)
						{
							Columns[intColumnIndex].ReadOnlyInternal = false;
							for (int i = 0; i < intRowIndex; i++)
							{
								DataGridViewCell dataGridViewCell2 = rows[i].Cells[intColumnIndex];
								dataGridViewCell2.ReadOnlyInternal = true;
								individualReadOnlyCells.Add(dataGridViewCell2);
							}
							for (int j = intRowIndex + 1; j < rows.Count; j++)
							{
								DataGridViewCell dataGridViewCell2 = rows[j].Cells[intColumnIndex];
								dataGridViewCell2.ReadOnlyInternal = true;
								individualReadOnlyCells.Add(dataGridViewCell2);
							}
						}
						if ((rowState & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None)
						{
							rows.SetRowState(intRowIndex, DataGridViewElementStates.ReadOnly, blnValue: false);
							for (int k = 0; k < intColumnIndex; k++)
							{
								DataGridViewCell dataGridViewCell2 = rows[intRowIndex].Cells[k];
								dataGridViewCell2.ReadOnlyInternal = true;
								individualReadOnlyCells.Add(dataGridViewCell2);
							}
							for (int l = intColumnIndex + 1; l < Columns.Count; l++)
							{
								DataGridViewCell dataGridViewCell2 = rows[intRowIndex].Cells[l];
								dataGridViewCell2.ReadOnlyInternal = true;
								individualReadOnlyCells.Add(dataGridViewCell2);
							}
						}
					}
					if (dataGridViewCell.ReadOnly)
					{
						dataGridViewCell.ReadOnlyInternal = false;
					}
				}
			}
			IndividualReadOnlyCells = individualReadOnlyCells;
		}

		/// 
		/// Clears the paging parameters
		/// </summary>
		internal void ClearPaging()
		{
			CurrentPageInternal = 1;
			TotalPagesInternal = 1;
		}

		/// 
		/// Sets the is current row dirty internal.
		/// </summary>
		/// <param name="blnDirty">if set to true</c> [BLN dirty].</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		internal void SetIsCurrentRowDirtyInternal(bool blnDirty, bool blnClientSource)
		{
			if (blnDirty != mobjDataGridViewState1[262144])
			{
				mobjDataGridViewState1[262144] = blnDirty;
				if (!blnClientSource && RowHeadersVisible && ShowEditingIcon && mobjCurrentCellPoint.Y >= 0)
				{
					InvalidateCellPrivate(mobjCurrentCellPoint.X, mobjCurrentCellPoint.Y);
				}
			}
		}

		/// 
		/// Invalidates the cell private.
		/// </summary>
		/// <param name="objDataGridViewCell">The data grid view cell.</param>
		private void InvalidateCellPrivate(DataGridViewCell objDataGridViewCell)
		{
			InvalidateCell(objDataGridViewCell.ColumnIndex, objDataGridViewCell.RowIndex);
		}

		/// 
		/// Invalidates the cell private.
		/// </summary>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		private void InvalidateCellPrivate(int intColumnIndex, int intRowIndex)
		{
			if (intColumnIndex != -1 && intRowIndex != -1)
			{
				this[intColumnIndex, intRowIndex]?.Update();
			}
		}

		/// 
		/// Add or remove hierarchic infos events.
		/// </summary>
		/// <param name="blnIsAdd">if set to true</c> [BLN is add].</param>
		private void AddRemoveHierarchicInfosEvents(bool blnIsAdd)
		{
			if (blnIsAdd)
			{
				mobjHierarchicInfos.CollectionChanged += mobjHierarchicInfos_CollectionChanged;
				if (mobjHierarchicInfos.Count > 0)
				{
					mobjHierarchicInfos[0].PropertyChanged += objHierarchicInfo_PropertyChanged;
				}
			}
			else
			{
				mobjHierarchicInfos.CollectionChanged -= mobjHierarchicInfos_CollectionChanged;
				if (mobjHierarchicInfos.Count > 0)
				{
					mobjHierarchicInfos[0].PropertyChanged -= objHierarchicInfo_PropertyChanged;
				}
			}
		}

		/// 
		/// Handles the PropertyChanged event of the objHierarchicInfo control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.ComponentModel.PropertyChangedEventArgs" /> instance containing the event data.</param>
		private void objHierarchicInfo_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			ResetDataBinding();
		}

		/// 
		/// Handles the CollectionChanged event of the mobjHierarchicInfos control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.Collections.Specialized.NotifyCollectionChangedEventArgs" /> instance containing the event data.</param>
		private void mobjHierarchicInfos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
			case NotifyCollectionChangedAction.Add:
				if (mobjHierarchicInfos.Count == e.NewItems.Count)
				{
					foreach (DataGridViewColumn column in Columns)
					{
						if (column.Frozen)
						{
							throw new Exception("DataGridView does not support hierarchies with frozen columns");
						}
					}
				}
				foreach (HierarchicInfo newItem in e.NewItems)
				{
					if (e.NewStartingIndex == 0)
					{
						newItem.PropertyChanged += objHierarchicInfo_PropertyChanged;
					}
				}
				break;
			case NotifyCollectionChangedAction.Remove:
				foreach (HierarchicInfo oldItem in e.OldItems)
				{
					if (e.OldStartingIndex == 0)
					{
						oldItem.PropertyChanged -= objHierarchicInfo_PropertyChanged;
					}
				}
				break;
			}
			ResetDataBinding();
		}

		/// 
		/// Resets the data binding.
		/// </summary>
		internal void ResetDataBinding()
		{
			if (!base.IsLayoutSuspended)
			{
				mstrFilterTemplate = null;
				mobjRealFilteringDataMemberIndexByProposedFilteringDataMember = null;
				if (DataSource != null && DataSource is BindingSource)
				{
					(DataSource as BindingSource).ResetBindings(blnMetadataChanged: true);
				}
				InitializeSystemHierarchicInfos();
			}
		}

		/// 
		/// Creates the cell panel.
		/// </summary>
		/// <param name="objCell">The obj cell.</param>
		/// </returns>
		protected internal virtual DataGridViewCellPanel CreateCellPanel(DataGridViewCell objCell)
		{
			return new DataGridViewCellPanel(objCell);
		}

		private void OnColumnHeadersGlobalAutoSize()
		{
		}

		void ISupportInitialize.BeginInit()
		{
			if (mobjDataGridViewState2[524288])
			{
				throw new InvalidOperationException(SR.GetString("DataGridViewBeginInit"));
			}
			mobjDataGridViewState2[524288] = true;
		}

		void ISupportInitialize.EndInit()
		{
			mobjDataGridViewState2[524288] = false;
			foreach (DataGridViewColumn column in Columns)
			{
				if (column.Frozen && column.Visible && column.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill)
				{
					column.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
				}
			}
			DataGridViewSelectionMode selectionMode = SelectionMode;
			DataGridViewSelectionMode dataGridViewSelectionMode = selectionMode;
			if (dataGridViewSelectionMode == DataGridViewSelectionMode.FullColumnSelect || dataGridViewSelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
			{
				foreach (DataGridViewColumn column2 in Columns)
				{
					if (column2.SortMode == DataGridViewColumnSortMode.Automatic)
					{
						SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
						throw new InvalidOperationException(SR.GetString("DataGridView_SelectionModeReset", SR.GetString("DataGridView_SelectionModeAndSortModeClash", selectionMode.ToString()), DataGridViewSelectionMode.RowHeaderSelect.ToString()));
					}
				}
			}
			ResetDataBinding();
		}

		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.SelectionChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains information about the event.</param>
		protected virtual void OnSelectionChanged(EventArgs e)
		{
			mobjDataGridViewState2[262144] = false;
			SelectionChangedHandler?.Invoke(this, e);
			this.SelectionChangedQueued?.Invoke(this, e);
		}

		/// 
		/// Sets the selected cell core internal.
		/// </summary>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="blnSelected">if set to true</c> [selected].</param>
		internal void SetSelectedCellCoreInternal(int intColumnIndex, int intRowIndex, bool blnSelected)
		{
			if (intColumnIndex < 0 || intColumnIndex >= Columns.Count)
			{
				throw new ArgumentOutOfRangeException("columnIndex");
			}
			DataGridViewRowCollection rows = Rows;
			if (intRowIndex < 0 || intRowIndex >= rows.Count)
			{
				throw new ArgumentOutOfRangeException("rowIndex");
			}
			DataGridViewRow dataGridViewRow = rows.SharedRow(intRowIndex);
			DataGridViewElementStates rowState = rows.GetRowState(intRowIndex);
			if (IsSharedCellSelected(dataGridViewRow.Cells[intColumnIndex], intRowIndex) == blnSelected)
			{
				return;
			}
			DataGridViewCellLinkedList individualSelectedCells = IndividualSelectedCells;
			DataGridViewCell dataGridViewCell = rows[intRowIndex].Cells[intColumnIndex];
			DataGridViewIntLinkedList dataGridViewIntLinkedList = null;
			if (blnSelected)
			{
				if ((rowState & DataGridViewElementStates.Selected) == 0 && !Columns[intColumnIndex].Selected)
				{
					individualSelectedCells.Add(dataGridViewCell);
					SetSelectedCellCore(dataGridViewCell, blnValue: true, blnClientSource: false);
				}
				return;
			}
			if ((dataGridViewCell.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.None)
			{
				individualSelectedCells.Remove(dataGridViewCell);
			}
			else
			{
				bool flag = false;
				if (SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
				{
					if (rows.Count > 8)
					{
						BulkPaintCount++;
						flag = true;
					}
					try
					{
						dataGridViewIntLinkedList = SelectedBandIndexes;
						dataGridViewIntLinkedList.Remove(intColumnIndex);
						Columns[intColumnIndex].SelectedInternal = false;
						for (int i = 0; i < intRowIndex; i++)
						{
							DataGridViewCell objDataGridViewCell = rows[i].Cells[intColumnIndex];
							SetSelectedCellCore(objDataGridViewCell, blnValue: true, blnClientSource: false);
							individualSelectedCells.Add(objDataGridViewCell);
						}
						for (int j = intRowIndex + 1; j < rows.Count; j++)
						{
							DataGridViewCell objDataGridViewCell = rows[j].Cells[intColumnIndex];
							SetSelectedCellCore(objDataGridViewCell, blnValue: true, blnClientSource: false);
							individualSelectedCells.Add(objDataGridViewCell);
						}
						if (dataGridViewCell.Selected)
						{
							SetSelectedCellCore(dataGridViewCell, blnValue: false, blnClientSource: false);
						}
						return;
					}
					finally
					{
						if (flag)
						{
							ExitBulkPaint(intColumnIndex, -1);
						}
					}
				}
				if (SelectionMode == DataGridViewSelectionMode.RowHeaderSelect)
				{
					if (Columns.Count > 8)
					{
						BulkPaintCount++;
						flag = true;
					}
					try
					{
						if (dataGridViewIntLinkedList == null)
						{
							dataGridViewIntLinkedList = SelectedBandIndexes;
						}
						dataGridViewIntLinkedList.Remove(intRowIndex);
						rows.SetRowState(intRowIndex, DataGridViewElementStates.Selected, blnValue: false);
						for (int k = 0; k < intColumnIndex; k++)
						{
							DataGridViewCell objDataGridViewCell = rows[intRowIndex].Cells[k];
							SetSelectedCellCore(objDataGridViewCell, blnValue: true, blnClientSource: false);
							individualSelectedCells.Add(objDataGridViewCell);
						}
						for (int l = intColumnIndex + 1; l < Columns.Count; l++)
						{
							DataGridViewCell objDataGridViewCell = rows[intRowIndex].Cells[l];
							SetSelectedCellCore(objDataGridViewCell, blnValue: true, blnClientSource: false);
							individualSelectedCells.Add(objDataGridViewCell);
						}
					}
					finally
					{
						if (flag)
						{
							ExitBulkPaint(-1, intRowIndex);
						}
					}
				}
			}
			if (dataGridViewCell.Selected)
			{
				SetSelectedCellCore(dataGridViewCell, blnValue: false, blnClientSource: false);
			}
		}

		/// 
		/// Sets the selected cell core.
		/// </summary>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// <param name="blnSelected">if set to true</c> [selected].</param>
		protected virtual void SetSelectedCellCore(int intColumnIndex, int intRowIndex, bool blnSelected)
		{
			SetSelectedCellCore(intColumnIndex, intRowIndex, blnSelected, blnClientSource: false);
		}

		/// 
		/// Determines whether [is shared cell selected] [the specified data grid view cell].
		/// </summary>
		/// <param name="objDataGridViewCell">The data grid view cell.</param>
		/// <param name="intRowIndex">Index of the row.</param>
		/// 
		/// 	true</c> if [is shared cell selected] [the specified data grid view cell]; otherwise, false</c>.
		/// </returns>
		internal bool IsSharedCellSelected(DataGridViewCell objDataGridViewCell, int intRowIndex)
		{
			return (Rows.GetRowState(intRowIndex) & DataGridViewElementStates.Selected) != DataGridViewElementStates.None || (objDataGridViewCell.OwningColumn != null && objDataGridViewCell.OwningColumn.Selected) || objDataGridViewCell.StateIncludes(DataGridViewElementStates.Selected);
		}

		/// 
		/// Sets the selected column core internal.
		/// </summary>
		/// <param name="intColumnIndex">Index of the column.</param>
		/// <param name="blnSelected">if set to true</c> [selected].</param>
		internal void SetSelectedColumnCoreInternal(int intColumnIndex, bool blnSelected)
		{
			SelectionChangeCount++;
			try
			{
				DataGridViewIntLinkedList selectedBandIndexes = SelectedBandIndexes;
				if (!MultiSelect && selectedBandIndexes.Count > 0)
				{
					int headInt = selectedBandIndexes.HeadInt;
					if (headInt != intColumnIndex)
					{
						SetSelectedColumnCore(headInt, blnSelected: false);
					}
				}
				SetSelectedColumnCore(intColumnIndex, blnSelected);
			}
			finally
			{
				NoSelectionChangeCount--;
			}
		}

		internal void SetSelectedRowCoreInternal(int intRowIndex, bool blnSelected)
		{
			SelectionChangeCount++;
			try
			{
				DataGridViewIntLinkedList selectedBandIndexes = SelectedBandIndexes;
				if (!MultiSelect && selectedBandIndexes.Count > 0)
				{
					int headInt = selectedBandIndexes.HeadInt;
					if (headInt != intRowIndex)
					{
						SetSelectedRowCore(headInt, blnSelected: false);
					}
				}
				SetSelectedRowCore(intRowIndex, blnSelected);
			}
			finally
			{
				NoSelectionChangeCount--;
			}
		}

		/// 
		/// Opens the custom filter dialog.
		/// </summary>
		/// <param name="objDataGridViewCell">The obj data grid view cell.</param>
		internal void OpenCustomFilterDialog(DataGridViewCell objDataGridViewCell)
		{
			DataGridViewCustomFilterDialog dataGridViewCustomFilterDialog = new DataGridViewCustomFilterDialog(objDataGridViewCell);
			dataGridViewCustomFilterDialog.Closed += objCustomFilterDialog_Closed;
			dataGridViewCustomFilterDialog.ShowDialog();
		}

		/// 
		/// Handles the Closed event of the objCustomFilterDialog control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void objCustomFilterDialog_Closed(object sender, EventArgs e)
		{
			if (!(sender is DataGridViewCustomFilterDialog dataGridViewCustomFilterDialog))
			{
				return;
			}
			if (dataGridViewCustomFilterDialog.DialogResult == DialogResult.OK)
			{
				DataGridViewColumn column = dataGridViewCustomFilterDialog.Column;
				string filterStatement = GetFilterStatement(dataGridViewCustomFilterDialog.OperatorA, column.DataPropertyName, column.ValueType, dataGridViewCustomFilterDialog.ValueA, null);
				string text = string.Empty;
				if (dataGridViewCustomFilterDialog.OperatorB != FilterComparisonOperator.None && dataGridViewCustomFilterDialog.ValueB != string.Empty)
				{
					text = GetFilterStatement(dataGridViewCustomFilterDialog.OperatorB, column.DataPropertyName, column.ValueType, dataGridViewCustomFilterDialog.ValueB, null);
				}
				if (text != string.Empty)
				{
					column.CustomFilterExpression = $"(({filterStatement}) {dataGridViewCustomFilterDialog.FiltersRelation} ({text}))";
				}
				else
				{
					column.CustomFilterExpression = $"({filterStatement})";
				}
			}
			else if (dataGridViewCustomFilterDialog.Cell is DataGridViewColumnHeaderCell dataGridViewColumnHeaderCell)
			{
				dataGridViewColumnHeaderCell.FilterComboBox.SelectedIndex = -1;
			}
			else
			{
				dataGridViewCustomFilterDialog.Column?.ClearFilter(blnClearHeaderFilter: false);
			}
		}

		static DataGridView()
		{
			ColumnDividerDoubleClick = SerializableEvent.Register("ColumnDividerDoubleClick", typeof(DataGridViewColumnDividerDoubleClickEventHandler), typeof(DataGridView));
			CurrentCellChanged = SerializableEvent.Register("CurrentCellChanged", typeof(EventHandler), typeof(DataGridView));
			GroupHeaderFormatting = SerializableEvent.Register("GroupHeaderFormatting", typeof(GroupHeaderFormattingEventHandler), typeof(DataGridView));
			GroupingChanged = SerializableEvent.Register("GroupingChangedEvent", typeof(GroupingChangedEventHandler), typeof(DataGridView));
			SelectionChanged = SerializableEvent.Register("SelectionChanged", typeof(EventHandler), typeof(DataGridView));
			CustomHeaderFilterClicked = SerializableEvent.Register("CustomHeaderFilterClickedEvent", typeof(CustomFilterApplyingEventHandler), typeof(DataGridView));
			PagingChanged = SerializableEvent.Register("PagingChanged", typeof(EventHandler), typeof(DataGridView));
		}
	}
}
