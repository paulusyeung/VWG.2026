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

namespace Gizmox.WebGUI.Forms.PropertyGridInternal
{
	/// 
	///
	/// </summary>
	[Serializable]
	[MetadataTag("PV")]
	[Skin(typeof(PropertyGridSkin))]
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class PropertyGridView : Control, IServiceProvider, IWebUIEditorService
	{
		protected const short ERROR_MSGBOX_UP = 2;

		protected const short ERROR_NONE = 0;

		protected const short ERROR_THROWN = 1;

		protected const int mcntDefaultLablesColumnWidth = 100;

		private const short FlagBtnLaunchedEditor = 256;

		private const short FlagInPropertySet = 16;

		private const short FlagIsNewSelection = 2;

		private const short FlagNeedsRefresh = 1;

		private const short FlagNeedUpdateUIBasedOnFont = 128;

		private const short FlagNoDefault = 512;

		private const short FlagResizableDropDown = 1024;

		internal const int MaxRecurseExpand = 10;

		/// 
		/// The short property registration.
		/// </summary>
		private static readonly SerializableProperty errorStateProperty;

		/// 
		/// The short property registration.
		/// </summary>
		private static readonly SerializableProperty flagsProperty;

		/// 
		/// The Font property registration.
		/// </summary>
		private static readonly SerializableProperty fontBoldProperty;

		/// 
		/// The GridEntryCollection property registration.
		/// </summary>
		private static readonly SerializableProperty mobjAllGridEntriesProperty;

		/// 
		/// The IHelpService property registration.
		/// </summary>
		private static readonly SerializableProperty mobjHelpServiceProperty;

		/// 
		/// The PropertyGrid property registration.
		/// </summary>
		private static readonly SerializableProperty mobjOwnerGridProperty;

		/// 
		/// The GridEntry property registration.
		/// </summary>
		private static readonly SerializableProperty mobjSelectedGridEntryProperty;

		/// 
		/// The int property registration.
		/// </summary>
		private static readonly SerializableProperty mintSelectedRowProperty;

		/// 
		/// The IServiceProvider property registration.
		/// </summary>
		private static readonly SerializableProperty mobjServiceProviderProperty;

		/// 
		/// The int property registration.
		/// </summary>
		private static readonly SerializableProperty mintTipInfoProperty;

		/// 
		/// The IHelpService property registration.
		/// </summary>
		private static readonly SerializableProperty mobjTopHelpServiceProperty;

		/// 
		/// The GridEntryCollection property registration.
		/// </summary>
		private static readonly SerializableProperty mobjTopLevelGridEntriesProperty;

		/// 
		/// The int property registration.
		/// </summary>
		private static readonly SerializableProperty mintTotalPropsProperty;

		/// 
		/// The int property registration.
		/// </summary>
		private static readonly SerializableProperty mintLablesColumnWidthProperty;

		private short errorState
		{
			get
			{
				return GetValue(errorStateProperty);
			}
			set
			{
				SetValue(errorStateProperty, value);
			}
		}

		private short flags
		{
			get
			{
				return GetValue(flagsProperty, (short)131);
			}
			set
			{
				SetValue(flagsProperty, value);
			}
		}

		private Font fontBold
		{
			get
			{
				return GetValue(fontBoldProperty);
			}
			set
			{
				SetValue(fontBoldProperty, value);
			}
		}

		private GridEntryCollection mobjAllGridEntries
		{
			get
			{
				return GetValue(mobjAllGridEntriesProperty);
			}
			set
			{
				SetValue(mobjAllGridEntriesProperty, value);
			}
		}

		private IHelpService mobjHelpService
		{
			get
			{
				return GetValue(mobjHelpServiceProperty);
			}
			set
			{
				SetValue(mobjHelpServiceProperty, value);
			}
		}

		private PropertyGrid mobjOwnerGrid
		{
			get
			{
				return GetValue(mobjOwnerGridProperty);
			}
			set
			{
				SetValue(mobjOwnerGridProperty, value);
			}
		}

		private GridEntry mobjSelectedGridEntry
		{
			get
			{
				return GetValue(mobjSelectedGridEntryProperty);
			}
			set
			{
				SetValue(mobjSelectedGridEntryProperty, value);
			}
		}

		private int mintSelectedRow
		{
			get
			{
				return GetValue(mintSelectedRowProperty, -1);
			}
			set
			{
				SetValue(mintSelectedRowProperty, value);
			}
		}

		private IServiceProvider mobjServiceProvider
		{
			get
			{
				return GetValue(mobjServiceProviderProperty);
			}
			set
			{
				SetValue(mobjServiceProviderProperty, value);
			}
		}

		private int mintTipInfo
		{
			get
			{
				return GetValue(mintTipInfoProperty, -1);
			}
			set
			{
				SetValue(mintTipInfoProperty, value);
			}
		}

		private IHelpService mobjTopHelpService
		{
			get
			{
				return GetValue(mobjTopHelpServiceProperty);
			}
			set
			{
				SetValue(mobjTopHelpServiceProperty, value);
			}
		}

		private GridEntryCollection mobjTopLevelGridEntries
		{
			get
			{
				return GetValue(mobjTopLevelGridEntriesProperty);
			}
			set
			{
				SetValue(mobjTopLevelGridEntriesProperty, value);
			}
		}

		internal int mintTotalProps
		{
			get
			{
				return GetValue(mintTotalPropsProperty, -1);
			}
			set
			{
				SetValue(mintTotalPropsProperty, value);
			}
		}

		private int mintLablesColumnWidth
		{
			get
			{
				return GetValue(mintLablesColumnWidthProperty, 100);
			}
			set
			{
				SetValue(mintLablesColumnWidthProperty, value);
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool CanCopy => false;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		public bool CanCut
		{
			get
			{
				if (CanCopy)
				{
					return mobjSelectedGridEntry.IsTextEditable;
				}
				return false;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool CanPaste
		{
			get
			{
				if (mobjSelectedGridEntry != null)
				{
					return mobjSelectedGridEntry.IsTextEditable;
				}
				return false;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public bool CanUndo => false;

		protected override bool IsDelayedDrawing => true;

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
		/// </summary>
		/// true</c> if focusable; otherwise, false</c>.</value>
		protected override bool Focusable => true;

		private bool HasEntries
		{
			get
			{
				if (mobjTopLevelGridEntries != null)
				{
					return mobjTopLevelGridEntries.Count > 0;
				}
				return false;
			}
		}

		protected bool NeedsCommit => false;

		public PropertyGrid OwnerGrid => mobjOwnerGrid;

		internal GridEntry SelectedGridEntry
		{
			get
			{
				return mobjSelectedGridEntry;
			}
			set
			{
				mobjSelectedGridEntry = value;
				UpdateResetButtonUI(value);
			}
		}

		public IServiceProvider ServiceProvider
		{
			get
			{
				return mobjServiceProvider;
			}
			set
			{
				if (value != mobjServiceProvider)
				{
					mobjServiceProvider = value;
					mobjTopHelpService = null;
					if (mobjHelpService != null && mobjHelpService is IDisposable)
					{
						((IDisposable)mobjHelpService).Dispose();
					}
					mobjHelpService = null;
				}
			}
		}

		private int TipColumn
		{
			get
			{
				return (mintTipInfo & -65536) >> 16;
			}
			set
			{
				mintTipInfo &= 65535;
				mintTipInfo |= (value & 0xFFFF) << 16;
			}
		}

		private int TipRow
		{
			get
			{
				return mintTipInfo & 0xFFFF;
			}
			set
			{
				mintTipInfo &= -65536;
				mintTipInfo |= value & 0xFFFF;
			}
		}

		private int LablesColumnWidth
		{
			get
			{
				return mintLablesColumnWidth;
			}
			set
			{
				if (mintLablesColumnWidth != value)
				{
					mintLablesColumnWidth = value;
				}
			}
		}

		/// 
		///
		/// </summary>
		static PropertyGridView()
		{
			errorStateProperty = SerializableProperty.Register("errorState", typeof(short), typeof(PropertyGridView));
			flagsProperty = SerializableProperty.Register("flags", typeof(short), typeof(PropertyGridView));
			fontBoldProperty = SerializableProperty.Register("fontBold", typeof(Font), typeof(PropertyGridView));
			mobjAllGridEntriesProperty = SerializableProperty.Register("mobjAllGridEntries", typeof(GridEntryCollection), typeof(PropertyGridView));
			mobjHelpServiceProperty = SerializableProperty.Register("mobjHelpService", typeof(IHelpService), typeof(PropertyGridView));
			mobjOwnerGridProperty = SerializableProperty.Register("mobjOwnerGrid", typeof(PropertyGrid), typeof(PropertyGridView));
			mobjSelectedGridEntryProperty = SerializableProperty.Register("mobjSelectedGridEntry", typeof(GridEntry), typeof(PropertyGridView));
			mintSelectedRowProperty = SerializableProperty.Register("mintSelectedRow", typeof(int), typeof(PropertyGridView));
			mobjServiceProviderProperty = SerializableProperty.Register("mobjServiceProvider", typeof(IServiceProvider), typeof(PropertyGridView));
			mintTipInfoProperty = SerializableProperty.Register("mintTipInfo", typeof(int), typeof(PropertyGridView));
			mobjTopHelpServiceProperty = SerializableProperty.Register("mobjTopHelpService", typeof(IHelpService), typeof(PropertyGridView));
			mobjTopLevelGridEntriesProperty = SerializableProperty.Register("mobjTopLevelGridEntries", typeof(GridEntryCollection), typeof(PropertyGridView));
			mintTotalPropsProperty = SerializableProperty.Register("mintTotalProps", typeof(int), typeof(PropertyGridView));
			mintLablesColumnWidthProperty = SerializableProperty.Register("mintLablesColumnWidth", typeof(int), typeof(PropertyGridView));
		}

		/// 
		///
		/// </summary>
		/// <param name="objServiceProvider"></param>
		/// <param name="objPropertyGrid"></param>
		public PropertyGridView(IServiceProvider objServiceProvider, PropertyGrid objPropertyGrid)
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer, blnValue: true);
			SetStyle(ControlStyles.ResizeRedraw, blnValue: false);
			SetStyle(ControlStyles.UserMouse, blnValue: true);
			mobjOwnerGrid = objPropertyGrid;
			mobjServiceProvider = objServiceProvider;
			base.TabStop = true;
			Text = "PropertyGridView";
			CreateUI();
		}

		/// 
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			if (!OwnerGrid.HelpVisible)
			{
				objWriter.WriteAttributeString("HV", "0");
			}
			if (LablesColumnWidth != 100)
			{
				objWriter.WriteAttributeString("LCW", LablesColumnWidth.ToString());
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
		}

		/// 
		/// Renders the controls sub tree
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnFullRedraw)
		{
			if (mobjTopLevelGridEntries == null)
			{
				return;
			}
			foreach (GridEntry mobjTopLevelGridEntry in mobjTopLevelGridEntries)
			{
				((IRenderableComponentMember)mobjTopLevelGridEntry).RenderComponent(objContext, objWriter, lngRequestID, !blnFullRedraw);
			}
		}

		protected override void FireEvent(IEvent objEvent)
		{
			if (objEvent.Member == string.Empty)
			{
				base.FireEvent(objEvent);
				string type = objEvent.Type;
				if (type == "SplitterChange" && objEvent["W"] != null)
				{
					double value = Convert.ToDouble(objEvent["W"], CultureInfo.InvariantCulture);
					LablesColumnWidth = Convert.ToInt32(value);
				}
			}
			else
			{
				int intMemberID = int.Parse(objEvent.Member);
				GetGridEntry(intMemberID)?.FireEvent(objEvent);
			}
		}

		private IRegisteredComponentMember GetGridEntry(int intMemberID)
		{
			return GetGridEntry(intMemberID, mobjTopLevelGridEntries);
		}

		private IRegisteredComponentMember GetGridEntry(int intMemberID, GridEntryCollection objGridEntries)
		{
			if (objGridEntries != null)
			{
				foreach (GridEntry objGridEntry in objGridEntries)
				{
					IRegisteredComponentMember registeredComponentMember = objGridEntry;
					if (registeredComponentMember.MemberID == intMemberID)
					{
						return registeredComponentMember;
					}
					registeredComponentMember = GetGridEntry(intMemberID, objGridEntry.Children);
					if (registeredComponentMember != null)
					{
						return registeredComponentMember;
					}
				}
			}
			return null;
		}

		/// 
		/// Clears all properties
		/// </summary>
		public void ClearProps()
		{
			if (HasEntries)
			{
				mobjTopLevelGridEntries = null;
				mobjAllGridEntries = null;
				mintSelectedRow = -1;
				mintTipInfo = -1;
			}
		}

		/// 
		/// Closes the current opened drop down
		/// </summary>
		public void CloseDropDown()
		{
		}

		/// 
		///
		/// </summary>
		/// </returns>
		private bool Commit()
		{
			return true;
		}

		/// 
		/// Commits the text.
		/// </summary>
		/// <param name="strText">The text.</param>
		/// <param name="objGridEntry">The grid entry.</param>
		/// </returns>
		internal bool CommitText(string strText, GridEntry objGridEntry)
		{
			object obj = null;
			if (objGridEntry == null)
			{
				return true;
			}
			try
			{
				obj = objGridEntry.ConvertTextToValue(strText);
			}
			catch (Exception objException)
			{
				SetCommitError(1);
				ShowInvalidMessage(objGridEntry.PropertyLabel, strText, objException);
				return false;
			}
			SetCommitError(0);
			return CommitValue(objGridEntry, obj);
		}

		/// 
		///
		/// </summary>
		/// <param name="strText"></param>
		/// </returns>
		private bool CommitText(string strText)
		{
			return CommitText(strText, mobjSelectedGridEntry);
		}

		/// 
		///
		/// </summary>
		/// <param name="objValue"></param>
		/// </returns>
		private bool CommitValue(object objValue)
		{
			GridEntry gridEntry = mobjSelectedGridEntry;
			if (gridEntry == null)
			{
				return true;
			}
			PropertyValueChangingEventArgs e = mobjOwnerGrid.OnPropertyValueSetting(gridEntry, objValue);
			objValue = e.NewValue;
			if (e.Cancel)
			{
				gridEntry.Update();
				return false;
			}
			object objOldValue = null;
			try
			{
				objOldValue = gridEntry.PropertyValue;
			}
			catch
			{
			}
			bool result = DoCommitValue(gridEntry, objValue);
			mobjOwnerGrid.OnPropertyValueSet(gridEntry, objOldValue);
			return result;
		}

		/// 
		///
		/// </summary>
		/// <param name="objGridEntry"></param>
		/// <param name="objValue"></param>
		/// </returns>
		private bool DoCommitValue(GridEntry objGridEntry, object objValue)
		{
			return objGridEntry.SetPropertyValue(objValue, blnRequireUpdate: true);
		}

		/// 
		///
		/// </summary>
		/// <param name="objGridEntry"></param>
		/// <param name="objValue"></param>
		/// </returns>
		internal bool CommitValue(GridEntry objGridEntry, object objValue)
		{
			PropertyValueChangingEventArgs e = mobjOwnerGrid.OnPropertyValueSetting(objGridEntry, objValue);
			objValue = e.NewValue;
			if (e.Cancel)
			{
				objGridEntry.Update();
				return false;
			}
			object objOldValue = null;
			try
			{
				objOldValue = objGridEntry.PropertyValue;
			}
			catch
			{
			}
			bool flag = DoCommitValue(objGridEntry, objValue);
			mobjOwnerGrid.OnPropertyValueSet(objGridEntry, objOldValue);
			if (flag)
			{
				UpdateResetButtonUI(objGridEntry);
			}
			return flag;
		}

		/// 
		///
		/// </summary>
		/// <param name="objEntries"></param>
		/// </returns>
		private int CountPropsFromOutline(GridEntryCollection objEntries)
		{
			if (objEntries == null)
			{
				return 0;
			}
			int num = objEntries.Count;
			for (int i = 0; i < objEntries.Count; i++)
			{
				if (((GridEntry)objEntries[i]).InternalExpanded)
				{
					num += CountPropsFromOutline(((GridEntry)objEntries[i]).Children);
				}
			}
			return num;
		}

		private Bitmap CreateDownArrow()
		{
			Bitmap bitmap = null;
			try
			{
				Icon icon = new Icon(typeof(PropertyGrid), "Arrow.ico");
				bitmap = icon.ToBitmap();
				icon.Dispose();
			}
			catch (Exception)
			{
				bitmap = new Bitmap(16, 16);
			}
			return bitmap;
		}

		protected virtual void CreateUI()
		{
		}

		protected override void Dispose(bool blnDisposing)
		{
			if (blnDisposing)
			{
				mobjOwnerGrid = null;
				mobjTopLevelGridEntries = null;
				mobjAllGridEntries = null;
				mobjServiceProvider = null;
				mobjTopHelpService = null;
				if (mobjHelpService != null && mobjHelpService is IDisposable)
				{
					((IDisposable)mobjHelpService).Dispose();
				}
				mobjHelpService = null;
				if (fontBold != null)
				{
					fontBold.Dispose();
					fontBold = null;
				}
			}
			base.Dispose(blnDisposing);
		}

		public void DoCopyCommand()
		{
			if (!CanCopy)
			{
			}
		}

		public void DoCutCommand()
		{
			if (!CanCut)
			{
			}
		}

		public void DoPasteCommand()
		{
			if (!CanPaste)
			{
			}
		}

		public void DoubleClickRow(int intRow, bool blnToggleExpand, int type)
		{
		}

		private GridEntry GetGridEntryFromRow(int intRow)
		{
			return null;
		}

		public void DoUndoCommand()
		{
			if (!CanUndo)
			{
			}
		}

		public virtual void DropDownDone()
		{
			CloseDropDown();
		}

		public virtual void DropDownUpdate()
		{
		}

		public bool EnsurePendingChangesCommitted()
		{
			CloseDropDown();
			return Commit();
		}

		private GridEntry FindEquivalentGridEntry(GridEntryCollection objEntries)
		{
			if (objEntries == null || objEntries.Count == 0)
			{
				return null;
			}
			GridEntryCollection allGridEntries = GetAllGridEntries();
			if (allGridEntries == null || allGridEntries.Count == 0)
			{
				return null;
			}
			GridEntry gridEntry = null;
			int i = 0;
			int num = allGridEntries.Count;
			for (int j = 0; j < objEntries.Count; j++)
			{
				if (objEntries[j] == null)
				{
					continue;
				}
				if (gridEntry != null)
				{
					int count = allGridEntries.Count;
					if (!gridEntry.InternalExpanded)
					{
						allGridEntries = GetAllGridEntries();
					}
					num = gridEntry.VisibleChildCount;
				}
				int num2 = i;
				gridEntry = null;
				for (; i < allGridEntries.Count && i - num2 <= num; i++)
				{
					if (objEntries.GetEntry(j).NonParentEquals(allGridEntries[i]))
					{
						gridEntry = allGridEntries.GetEntry(i);
						i++;
						break;
					}
				}
				if (gridEntry == null)
				{
					return gridEntry;
				}
			}
			return gridEntry;
		}

		public virtual void Flush()
		{
		}

		private GridEntryCollection GetAllGridEntries()
		{
			return GetAllGridEntries(fUpdateCache: false);
		}

		private GridEntryCollection GetAllGridEntries(bool fUpdateCache)
		{
			if (mintTotalProps == -1 || !HasEntries)
			{
				return null;
			}
			if (mobjAllGridEntries == null || fUpdateCache)
			{
				GridEntry[] array = new GridEntry[mintTotalProps];
				try
				{
					GetGridEntriesFromOutline(mobjTopLevelGridEntries, 0, 0, array);
				}
				catch (Exception)
				{
				}
				mobjAllGridEntries = new GridEntryCollection(null, array);
			}
			return mobjAllGridEntries;
		}

		private int GetCurrentValueIndex(GridEntry objGridEntry)
		{
			if (objGridEntry.Enumerable)
			{
				try
				{
					object[] propertyValueList = objGridEntry.GetPropertyValueList();
					object propertyValue = objGridEntry.PropertyValue;
					string strA = objGridEntry.TypeConverter.ConvertToString(objGridEntry, propertyValue);
					if (propertyValueList != null && propertyValueList.Length != 0)
					{
						int num = -1;
						int num2 = -1;
						for (int i = 0; i < propertyValueList.Length; i++)
						{
							object obj = propertyValueList[i];
							string strB = objGridEntry.TypeConverter.ConvertToString(obj);
							if (propertyValue == obj || string.Compare(strA, strB, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
							{
								num = i;
							}
							if (propertyValue != null && obj != null && obj.Equals(propertyValue))
							{
								num2 = i;
							}
							if (num == num2 && num != -1)
							{
								return num;
							}
						}
						if (num != -1)
						{
							return num;
						}
						if (num2 != -1)
						{
							return num2;
						}
					}
				}
				catch (Exception)
				{
				}
			}
			return -1;
		}

		public virtual int GetDefaultOutlineIndent()
		{
			return 10;
		}

		private bool GetFlag(short shortFlag)
		{
			return (flags & shortFlag) != 0;
		}

		private int GetGridEntriesFromOutline(GridEntryCollection objEntries, int cCur, int cTarget, GridEntry[] arrGridEntries)
		{
			if (objEntries != null && objEntries.Count != 0)
			{
				cCur--;
				for (int i = 0; i < objEntries.Count; i++)
				{
					cCur++;
					if (cCur >= cTarget + arrGridEntries.Length)
					{
						return cCur;
					}
					GridEntry entry = objEntries.GetEntry(i);
					if (cCur >= cTarget)
					{
						arrGridEntries[cCur - cTarget] = entry;
					}
					if (entry.InternalExpanded)
					{
						GridEntryCollection children = entry.Children;
						if (children != null && children.Count > 0)
						{
							cCur = GetGridEntriesFromOutline(children, cCur + 1, cTarget, arrGridEntries);
						}
					}
				}
			}
			return cCur;
		}

		private GridEntry GetGridEntryFromOffset(int offset)
		{
			GridEntryCollection allGridEntries = GetAllGridEntries();
			if (allGridEntries != null && offset >= 0 && offset < allGridEntries.Count)
			{
				return allGridEntries.GetEntry(offset);
			}
			return null;
		}

		private GridEntryCollection GetGridEntryHierarchy(GridEntry objGridEntry)
		{
			if (objGridEntry == null)
			{
				return null;
			}
			int propertyDepth = objGridEntry.PropertyDepth;
			if (propertyDepth > 0)
			{
				GridEntry[] array = new GridEntry[propertyDepth + 1];
				while (objGridEntry != null && propertyDepth >= 0)
				{
					array[propertyDepth] = objGridEntry;
					objGridEntry = objGridEntry.ParentGridEntry;
					propertyDepth = objGridEntry.PropertyDepth;
				}
				return new GridEntryCollection(null, array);
			}
			return new GridEntryCollection(null, new GridEntry[1] { objGridEntry });
		}

		private IHelpService GetHelpService()
		{
			if (mobjHelpService == null && ServiceProvider != null)
			{
				mobjTopHelpService = (IHelpService)ServiceProvider.GetService(typeof(IHelpService));
				if (mobjTopHelpService != null)
				{
					IHelpService helpService = mobjTopHelpService.CreateLocalContext(HelpContextType.ToolWindowSelection);
					if (helpService != null)
					{
						mobjHelpService = helpService;
					}
				}
			}
			return mobjHelpService;
		}

		public new object GetService(Type objClassService)
		{
			if (objClassService == typeof(IWebUIEditorService))
			{
				return this;
			}
			if (ServiceProvider != null)
			{
				return mobjServiceProvider.GetService(objClassService);
			}
			return null;
		}

		private int GetRowFromGridEntry(GridEntry objGridEntry)
		{
			return -1;
		}

		protected virtual void OnRecreateChildren(object s, GridEntryRecreateChildrenEventArgs e)
		{
			GridEntry gridEntry = (GridEntry)s;
			if (gridEntry.Expanded)
			{
				GridEntry[] array = new GridEntry[mobjAllGridEntries.Count];
				mobjAllGridEntries.CopyTo(array, 0);
				int num = -1;
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == gridEntry)
					{
						num = i;
						break;
					}
				}
				if (e.OldChildCount != e.NewChildCount)
				{
					int num2 = array.Length + (e.NewChildCount - e.OldChildCount);
					GridEntry[] array2 = new GridEntry[num2];
					Array.Copy(array, 0, array2, 0, num + 1);
					Array.Copy(array, num + e.OldChildCount + 1, array2, num + e.NewChildCount + 1, array.Length - (num + e.OldChildCount + 1));
					array = array2;
				}
				GridEntryCollection children = gridEntry.Children;
				int count = children.Count;
				for (int j = 0; j < count; j++)
				{
					array[num + j + 1] = children.GetEntry(j);
				}
				mobjAllGridEntries.Clear();
				mobjAllGridEntries.AddRange(array);
			}
			if (e.OldChildCount != e.NewChildCount)
			{
				mintTotalProps = CountPropsFromOutline(mobjTopLevelGridEntries);
			}
			Invalidate();
		}

		private void OnSysColorChange(object sender, UserPreferenceChangedEventArgs e)
		{
			if (e.Category == UserPreferenceCategory.Color || e.Category == UserPreferenceCategory.Accessibility)
			{
				SetFlag(128, blnValue: true);
			}
		}

		public virtual void PopupDialog(int intRow)
		{
			GridEntry gridEntryFromRow = GetGridEntryFromRow(intRow);
			if (gridEntryFromRow == null)
			{
			}
		}

		protected virtual void RecalculateProps()
		{
			int num = CountPropsFromOutline(mobjTopLevelGridEntries);
			if (mintTotalProps != num)
			{
				mintTotalProps = num;
				mobjAllGridEntries = null;
			}
		}

		public new void Refresh()
		{
			Refresh(blnFullRefresh: false, -1, -1);
			Invalidate();
		}

		public void Refresh(bool blnFullRefresh)
		{
			Refresh(blnFullRefresh, -1, -1);
		}

		private void Refresh(bool blnFullRefresh, int intRowStart, int intRowEnd)
		{
			SetFlag(1, blnValue: true);
			GridEntry gridEntry = null;
			if (base.IsDisposed)
			{
				return;
			}
			if (intRowStart == -1)
			{
				intRowStart = 0;
			}
			if (blnFullRefresh || mobjOwnerGrid.HavePropEntriesChanged())
			{
				int num = mintTotalProps;
				object obj = ((mobjTopLevelGridEntries == null || mobjTopLevelGridEntries.Count == 0) ? null : ((GridEntry)mobjTopLevelGridEntries[0]).GetValueOwner());
				if (blnFullRefresh)
				{
					mobjOwnerGrid.RefreshProperties(blnClearCached: true);
				}
				UpdateHelpAttributes(mobjSelectedGridEntry, null);
				SetFlag(2, blnValue: true);
				mobjTopLevelGridEntries = mobjOwnerGrid.GetPropEntries();
				mobjAllGridEntries = null;
				RecalculateProps();
				int num2 = mintTotalProps;
				if (num2 > 0)
				{
					if (gridEntry == null)
					{
						gridEntry = mobjOwnerGrid.GetDefaultGridEntry();
						SetFlag(512, gridEntry == null && mintTotalProps > 0);
					}
					if (gridEntry == null)
					{
						mintSelectedRow = 0;
						mobjSelectedGridEntry = GetGridEntryFromRow(mintSelectedRow);
					}
				}
				else if (num == 0)
				{
					return;
				}
			}
			if (!HasEntries)
			{
				mobjOwnerGrid.SetStatusBox(null, null);
				mintSelectedRow = -1;
				Invalidate();
			}
			else
			{
				mobjOwnerGrid.ClearValueCaches();
			}
		}

		internal void RemoveSelectedEntryHelpAttributes()
		{
			UpdateHelpAttributes(mobjSelectedGridEntry, null);
		}

		/// 
		/// Resets this property.
		/// </summary>
		public virtual void Reset()
		{
			GridEntry selectedGridEntry = SelectedGridEntry;
			if (selectedGridEntry != null)
			{
				selectedGridEntry.ResetPropertyValue();
				selectedGridEntry.Update();
				UpdateResetButtonUI(selectedGridEntry);
			}
		}

		protected virtual void ResetOrigin(Graphics objGraphics)
		{
			objGraphics.ResetTransform();
		}

		public virtual void RunDialog(Form objDialog)
		{
			ShowDialog(objDialog);
		}

		private void SetCommitError(short shortError)
		{
			SetCommitError(shortError, shortError == 1);
		}

		private void SetCommitError(short shortError, bool blnCapture)
		{
			errorState = shortError;
		}

		private void SetFlag(short shortFlag, bool blnValue)
		{
			if (blnValue)
			{
				flags = (short)((ushort)flags | (ushort)shortFlag);
			}
			else
			{
				flags = (short)(flags & ~shortFlag);
			}
		}

		/// 
		/// Shows the specified <see cref="T:.Gizmox.WebGUI.Forms.CommonDialog"></see>.
		/// </summary>
		/// <param name="objDialog">The <see cref="T:Gizmox.WebGUI.Forms.CommonDialog"></see> to display.</param>
		public void ShowDialog(CommonDialog objDialog)
		{
			if (objDialog != null)
			{
				DialogTypes dialogTypes = DialogTypes.ModalWindow;
				if (OwnerGrid != null && OwnerGrid.Form != null)
				{
					dialogTypes = OwnerGrid.Form.DialogType;
				}
				if (dialogTypes == DialogTypes.PopupWindow)
				{
					objDialog.ShowPopup(base.TopLevelControl as Form, SelectedGridEntry, null, DialogAlignment.Below, Point.Empty);
				}
				else
				{
					objDialog.ShowDialog();
				}
			}
		}

		/// 
		/// Shows the specified <see cref="T:Gizmox.WebGUI.Forms.Form"></see>.
		/// </summary>
		/// <param name="objDialog">The <see cref="T:Gizmox.WebGUI.Forms.Form"></see> to display.</param>
		public void ShowDialog(Form objDialog)
		{
			if (objDialog != null)
			{
				DialogTypes dialogTypes = DialogTypes.ModalWindow;
				if (OwnerGrid != null && OwnerGrid.Form != null)
				{
					dialogTypes = OwnerGrid.Form.DialogType;
				}
				if (dialogTypes == DialogTypes.PopupWindow)
				{
					objDialog.ShowPopup();
				}
				else
				{
					objDialog.ShowDialog();
				}
			}
		}

		private void ShowInvalidMessage(string strPropName, object objValue, Exception objException)
		{
		}

		public void ShowDropDown(Form objDialog)
		{
			if (objDialog != null)
			{
				if (SelectedGridEntry != null)
				{
					objDialog.Width = base.Width - LablesColumnWidth - 15;
					objDialog.ShowPopup(base.TopLevelControl as Form, SelectedGridEntry, DialogAlignment.Below);
				}
				else
				{
					objDialog.ShowPopup();
				}
			}
		}

		private void UpdateHelpAttributes(GridEntry objOldEntry, GridEntry objNewEntry)
		{
			IHelpService helpService = GetHelpService();
			if (helpService == null || objOldEntry == objNewEntry)
			{
				return;
			}
			GridEntry gridEntry = objOldEntry;
			if (objOldEntry != null && !objNewEntry.Disposed)
			{
				while (gridEntry != null)
				{
					helpService.RemoveContextAttribute("Keyword", gridEntry.HelpKeyword);
					gridEntry = gridEntry.ParentGridEntry;
				}
			}
			if (objNewEntry != null)
			{
				gridEntry = objNewEntry;
				UpdateHelpAttributes(helpService, gridEntry, blnAddAsF1: true);
			}
		}

		private void UpdateHelpAttributes(IHelpService objHelpService, GridEntry objGridEntry, bool blnAddAsF1)
		{
			if (objGridEntry != null)
			{
				UpdateHelpAttributes(objHelpService, objGridEntry.ParentGridEntry, blnAddAsF1: false);
				string helpKeyword = objGridEntry.HelpKeyword;
				if (helpKeyword != null)
				{
					objHelpService.AddContextAttribute("Keyword", helpKeyword, (!blnAddAsF1) ? HelpKeywordType.GeneralKeyword : HelpKeywordType.F1Keyword);
				}
			}
		}

		private void UpdateResetCommand(GridEntry objGridEntry)
		{
		}

		internal void SetActiveGridEntry(GridEntry objGridEntry)
		{
			OwnerGrid.SetActiveGridEntry(objGridEntry);
		}

		/// 
		/// Updates the Reset button UI.
		/// </summary>
		/// <param name="objGridEntry">The value.</param>
		internal void UpdateResetButtonUI(GridEntry objGridEntry)
		{
			PropertyGrid ownerGrid = OwnerGrid;
			if (ownerGrid != null)
			{
				ToolStripButton resetButton = ownerGrid.ResetButton;
				if (resetButton != null)
				{
					bool flag = (resetButton.Enabled = ownerGrid.CanResetPropertyValue(objGridEntry));
					bool flag3 = flag;
					resetButton.Text = (flag3 ? string.Format("{0} {1}", SR.GetString("PBRSToolTipReset"), objGridEntry.PropertyName) : string.Empty);
					resetButton.Update();
				}
			}
		}
	}
}
