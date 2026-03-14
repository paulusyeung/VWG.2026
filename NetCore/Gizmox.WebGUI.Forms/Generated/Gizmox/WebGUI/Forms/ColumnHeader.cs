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
	/// Summary description for ColumnHeader.
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.ColumnHeaderController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ColumnHeaderController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DesignTimeVisible(false)]
	[TypeConverter(typeof(ColumnHeaderConverter))]
	public class ColumnHeader : Component, IComparable
	{
		/// 
		/// The column header name
		/// </summary>
		[NonSerialized]
		private string mstrName = string.Empty;

		/// 
		/// The column header label
		/// </summary>
		[NonSerialized]
		private string mstrLabel = string.Empty;

		/// 
		/// The column header type
		/// </summary>
		[NonSerialized]
		private ListViewColumnType menmType = ListViewColumnType.Text;

		/// 
		/// The column header width
		/// </summary>
		[NonSerialized]
		private int mintWidth = 150;

		/// 
		/// The column header internal width
		/// </summary>
		[NonSerialized]
		private int mintInternalWidth = 150;

		/// 
		/// The column header text align
		/// </summary>
		[NonSerialized]
		private HorizontalAlignment menmTextAlign = HorizontalAlignment.Left;

		/// 
		/// The coumn header content alignment
		/// </summary>
		[NonSerialized]
		private ExtendedHorizontalAlignment menmContentAlignment = ExtendedHorizontalAlignment.Inherit;

		/// 
		/// The column header index
		/// </summary>
		[NonSerialized]
		private int mintIndex = -1;

		/// 
		/// The column header resource
		/// </summary>
		[NonSerialized]
		private ResourceHandle mobjResourceHandler = null;

		/// 
		/// The column header display index
		/// </summary>
		[NonSerialized]
		private int mintDisplayIndexInternal = -1;

		/// 
		/// Sort direction
		/// </summary>
		[NonSerialized]
		private SortOrder menmSortOrder = SortOrder.None;

		/// 
		/// Sort position
		/// </summary>
		[NonSerialized]
		private int mintSortPosition = 1000;

		/// 
		/// The column header group by flag
		/// </summary>
		[NonSerialized]
		private bool mblnGroupBy = false;

		/// 
		///
		/// </summary>
		[NonSerialized]
		private int mintGroupByPosition = -1;

		/// 
		///
		/// </summary>
		[NonSerialized]
		private int mintPreferedItemHeight = 0;

		/// 
		///
		/// </summary>
		[NonSerialized]
		private int mintImageIndex = -1;

		/// 
		///
		/// </summary>
		[NonSerialized]
		private string mstrImageKey = string.Empty;

		/// 
		/// The amount of fields that the control writes / reads
		/// </summary>
		private const int mcntSerializableDataFieldCount = 15;

		/// 
		/// The size of the initiale serialization data array which is the optmized serialization graph.
		/// </summary>
		/// </value>
		/// 
		/// This value should be the actual size needed so that re-allocations and truncating will not be required.
		/// </remarks>
		protected override int SerializableDataInitialSize => base.SerializableDataInitialSize + 15;

		/// 
		/// Gets or sets the display index.
		/// </summary>
		/// The display index.</value>
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		[SRDescription("ColumnHeaderDisplayIndexDescr")]
		public int DisplayIndex
		{
			get
			{
				return DisplayIndexInternal;
			}
			set
			{
				if (Owner == null)
				{
					DisplayIndexInternal = value;
					return;
				}
				if (value < 0 || value > Owner.Columns.Count - 1)
				{
					throw new ArgumentOutOfRangeException("DisplayIndex", SR.GetString("ColumnHeaderBadDisplayIndex"));
				}
				int num = Math.Min(DisplayIndexInternal, value);
				int num2 = Math.Max(DisplayIndexInternal, value);
				int[] array = new int[Owner.Columns.Count];
				bool flag = value > DisplayIndexInternal;
				ColumnHeader columnHeader = null;
				for (int i = 0; i < Owner.Columns.Count; i++)
				{
					ColumnHeader columnHeader2 = Owner.Columns[i];
					if (columnHeader2.DisplayIndex == DisplayIndexInternal)
					{
						columnHeader = columnHeader2;
					}
					else if (columnHeader2.DisplayIndex >= num && columnHeader2.DisplayIndex <= num2)
					{
						columnHeader2.DisplayIndexInternal -= (flag ? 1 : (-1));
					}
					if (i != Index)
					{
						array[columnHeader2.DisplayIndexInternal] = i;
					}
				}
				columnHeader.DisplayIndexInternal = value;
				Owner.Columns.ClearSortedColumns();
			}
		}

		/// 
		/// Gets or sets the display index internal.
		/// </summary>
		/// The display index internal.</value>
		internal int DisplayIndexInternal
		{
			get
			{
				return mintDisplayIndexInternal;
			}
			set
			{
				mintDisplayIndexInternal = value;
				if (InternalParent != null)
				{
					InternalParent.Update();
				}
			}
		}

		private ListView Owner => InternalParent as ListView;

		/// 
		/// Gets or sets the image displayed in the <see cref="T:System.Windows.Forms.ColumnHeader"></see>. 
		/// </summary>
		/// 
		/// The image displayed in the <see cref="T:System.Windows.Forms.ColumnHeader"></see>.
		/// </returns>
		public ResourceHandle Image
		{
			get
			{
				ResourceHandle resourceHandle = null;
				if (ImageList != null)
				{
					resourceHandle = GetImage(null, ImageList, ImageIndex, ImageKey, -1, string.Empty);
				}
				if (resourceHandle != null)
				{
					return resourceHandle;
				}
				return mobjResourceHandler;
			}
			set
			{
				if (mobjResourceHandler != value)
				{
					mobjResourceHandler = value;
					mintImageIndex = -1;
					mstrImageKey = string.Empty;
					ListView?.Update();
				}
			}
		}

		/// Gets or sets the index of the image that is displayed for the item.</summary>
		/// The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
		/// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[DefaultValue(-1)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRDescription("ListViewItemImageIndexDescr")]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		public int ImageIndex
		{
			get
			{
				return mintImageIndex;
			}
			set
			{
				if (mintImageIndex != value)
				{
					mintImageIndex = value;
					mobjResourceHandler = null;
					mstrImageKey = string.Empty;
					ListView?.Update();
				}
			}
		}

		/// Gets or sets the key for the image that is displayed for the item.</summary>
		/// The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Localizable(true)]
		[DefaultValue("")]
		public string ImageKey
		{
			get
			{
				return mstrImageKey;
			}
			set
			{
				if (!mstrImageKey.Equals(value))
				{
					mstrImageKey = value;
					mobjResourceHandler = null;
					mintImageIndex = -1;
					ListView?.Update();
				}
			}
		}

		/// 
		/// Gets the image list.
		/// </summary>
		[Browsable(false)]
		public ImageList ImageList
		{
			get
			{
				if (ListView != null)
				{
					switch (ListView.View)
					{
					case View.LargeIcon:
						return ListView.LargeImageList;
					case View.Details:
					case View.List:
					case View.SmallIcon:
						return ListView.SmallImageList;
					}
				}
				return null;
			}
		}

		/// 
		/// Gets the list view.
		/// </summary>
		/// </value>
		[Browsable(false)]
		public ListView ListView => InternalParent as ListView;

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ColumnHeader" /> is visible.
		/// </summary>
		/// 
		/// 	true</c> if visible; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		[Browsable(false)]
		public bool Visible
		{
			get
			{
				return GetState(ComponentState.Visible);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.Visible, value) && InternalParent != null)
				{
					InternalParent.Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ColumnHeader" /> is loaded.
		/// </summary>
		/// 
		/// 	true</c> if loaded; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool Loaded
		{
			get
			{
				return GetState(ComponentState.Loaded);
			}
			set
			{
				SetState(ComponentState.Loaded, value);
			}
		}

		/// 
		/// Gets or sets the index.
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int Index => mintIndex;

		/// 
		/// Sets the internal index.
		/// </summary>
		/// </value>
		internal int InternalIndex
		{
			set
			{
				if (InternalParent != null)
				{
					InternalParent.Update();
				}
				mintIndex = value;
			}
		}

		/// 
		/// Gets or sets the name.
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string Name
		{
			get
			{
				return mstrName;
			}
			set
			{
				if (InternalParent != null)
				{
					InternalParent.Update();
				}
				mstrName = value;
			}
		}

		/// Gets or sets the text displayed in the column header.</summary>
		/// The text displayed in the column header.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Localizable(true)]
		[SRDescription("ColumnCaption")]
		public string Text
		{
			get
			{
				return Label;
			}
			set
			{
				Label = value;
				FireObservableItemPropertyChanged("Text");
			}
		}

		/// 
		/// Gets or sets the label.
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public string Label
		{
			get
			{
				return mstrLabel;
			}
			set
			{
				if (InternalParent != null)
				{
					InternalParent.Update();
				}
				mstrLabel = value;
			}
		}

		/// 
		/// Gets or sets the width.
		/// </summary>
		/// </value>
		public int Width
		{
			get
			{
				return mintWidth;
			}
			set
			{
				InternalWidth = value;
				if (InternalWidth > 0)
				{
					mintWidth = InternalWidth;
				}
				else if (Owner != null && Owner.InUpadte <= 0)
				{
					mintWidth = Owner.GetColumnFixedWidth(Index, InternalWidth, blnIsAutoResizeStyle: false);
				}
				if (InternalParent != null)
				{
					InternalParent.Update();
				}
				FireObservableItemPropertyChanged("Width");
			}
		}

		/// 
		/// Gets or sets the internal width.
		/// </summary>
		/// </value>
		internal int InternalWidth
		{
			get
			{
				return mintInternalWidth;
			}
			set
			{
				mintInternalWidth = value;
			}
		}

		/// 
		/// Gets or sets the type.
		/// </summary>
		/// </value>
		[Browsable(true)]
		[DefaultValue(ListViewColumnType.Text)]
		public ListViewColumnType Type
		{
			get
			{
				return menmType;
			}
			set
			{
				menmType = value;
			}
		}

		/// 
		/// Gets or sets the height of the prefered item.
		/// </summary>
		/// The height of the prefered item.</value>
		[Browsable(true)]
		[DefaultValue(0)]
		public int PreferedItemHeight
		{
			get
			{
				if (Type == ListViewColumnType.Control)
				{
					return mintPreferedItemHeight;
				}
				return 0;
			}
			set
			{
				mintPreferedItemHeight = value;
			}
		}

		/// 
		/// Gets or sets the text alignment.
		/// </summary>
		/// </value>
		[Browsable(true)]
		[DefaultValue(HorizontalAlignment.Left)]
		public HorizontalAlignment TextAlign
		{
			get
			{
				return menmTextAlign;
			}
			set
			{
				menmTextAlign = value;
			}
		}

		/// 
		/// Gets or sets the column header alignment.
		/// </summary>
		/// </value>
		[Browsable(true)]
		[DefaultValue(ExtendedHorizontalAlignment.Inherit)]
		public ExtendedHorizontalAlignment ContentAlign
		{
			get
			{
				return menmContentAlignment;
			}
			set
			{
				if (menmContentAlignment != value)
				{
					if (InternalParent != null)
					{
						InternalParent.Update();
					}
					menmContentAlignment = value;
				}
			}
		}

		/// 
		///
		/// </summary>
		internal bool IsValidColumn => Visible && Loaded;

		/// 
		/// Gets or sets the sort order.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public SortOrder SortOrder
		{
			get
			{
				return menmSortOrder;
			}
			set
			{
				menmSortOrder = value;
			}
		}

		/// 
		/// Gets or sets the sort position.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int SortPosition
		{
			get
			{
				return mintSortPosition;
			}
			set
			{
				mintSortPosition = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether to group by column.
		/// </summary>
		/// 
		/// 	true</c> if group by column; otherwise, false</c>.
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool GroupBy
		{
			get
			{
				return mblnGroupBy;
			}
			set
			{
				mblnGroupBy = value;
			}
		}

		/// 
		/// Gets or sets the group by position.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int GroupByPosition
		{
			get
			{
				return mintGroupByPosition;
			}
			set
			{
				mintGroupByPosition = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnHeader" /> class.
		/// </summary>
		public ColumnHeader()
		{
			InitializeState(blnLoaded: true);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ColumnHeader" /> class.
		/// </summary>
		/// <param name="strLabel">The STR label.</param>
		public ColumnHeader(string strLabel)
		{
			mstrLabel = strLabel;
			InitializeState(blnLoaded: true);
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		/// <param name="strLabel"></param>
		public ColumnHeader(string strName, string strLabel)
		{
			mstrName = strName;
			mstrLabel = strLabel;
			InitializeState(blnLoaded: true);
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		/// <param name="strLabel"></param>
		/// <param name="blnLoaded"></param>
		public ColumnHeader(string strName, string strLabel, bool blnLoaded)
		{
			mstrName = strName;
			mstrLabel = strLabel;
			InitializeState(blnLoaded);
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ColumnHeader" /> instance.
		/// </summary>
		/// <param name="strName">Name.</param>
		/// <param name="strLabel">Label.</param>
		/// <param name="intWidth">Width.</param>
		public ColumnHeader(string strName, string strLabel, int intWidth)
		{
			mstrName = strName;
			mstrLabel = strLabel;
			mintWidth = intWidth;
			InternalWidth = intWidth;
			InitializeState(blnLoaded: true);
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ColumnHeader" /> instance.
		/// </summary>
		/// <param name="strName">Name.</param>
		/// <param name="strLabel">Label.</param>
		/// <param name="intWidth">Width.</param>
		/// <param name="blnLoaded"></param>
		public ColumnHeader(string strName, string strLabel, int intWidth, bool blnLoaded)
		{
			mstrName = strName;
			mstrLabel = strLabel;
			mintWidth = intWidth;
			InternalWidth = intWidth;
			InitializeState(blnLoaded);
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		/// <param name="strLabel"></param>
		/// <param name="intWidth"></param>
		/// <param name="enmType"></param>        
		public ColumnHeader(string strName, string strLabel, int intWidth, ListViewColumnType enmType)
		{
			mstrName = strName;
			mstrLabel = strLabel;
			mintWidth = intWidth;
			InternalWidth = intWidth;
			menmType = enmType;
			InitializeState(blnLoaded: true);
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		/// <param name="strLabel"></param>
		/// <param name="intWidth"></param>
		/// <param name="enmType"></param>
		/// <param name="blnLoaded"></param>
		public ColumnHeader(string strName, string strLabel, int intWidth, ListViewColumnType enmType, bool blnLoaded)
		{
			mstrName = strName;
			mstrLabel = strLabel;
			mintWidth = intWidth;
			InternalWidth = intWidth;
			menmType = enmType;
			InitializeState(blnLoaded);
		}

		/// 
		/// Should serialize the display index.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeDisplayIndex()
		{
			return DisplayIndex != Index;
		}

		/// 
		/// Should serialize the name.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeName()
		{
			return !string.IsNullOrEmpty(Name);
		}

		/// 
		/// Should serialize the text.
		/// </summary>
		/// </returns>
		internal bool ShouldSerializeText()
		{
			return Text != null;
		}

		/// 
		/// Shoulds the serialize image.
		/// </summary>
		/// </returns>
		internal bool ShouldSerializeImage()
		{
			return mobjResourceHandler != null;
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			if (Visible)
			{
				ListView listView = null;
				string type = objEvent.Type;
				if (!(type == "ChangeColumnWidth"))
				{
					if (type == "Sort" && InternalParent is ListView listView2)
					{
						listView2.SortBy(this);
					}
				}
				else
				{
					double dblValue = 0.0;
					if (CommonUtils.TryParse(objEvent["Width"], out dblValue))
					{
						mintWidth = Convert.ToInt32(dblValue);
						if (InternalParent is ListView listView3)
						{
							listView3.InternalColumnWidthChanged(Index);
						}
					}
				}
			}
			base.FireEvent(objEvent);
		}

		/// 
		/// Renders the column header.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter">The response writer object.</param>
		/// <param name="lngRequestID">Request ID.</param>
		internal void RenderColumn(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			if (IsDirty(lngRequestID) && IsValidColumn)
			{
				objWriter.WriteStartElement("C");
				objWriter.WriteAttributeString("Id", GetProxyPropertyValue("ID", ID).ToString());
				objWriter.WriteAttributeString("N", "c" + Index);
				objWriter.WriteAttributeText("TX", Label, (TextFilter)5);
				objWriter.WriteAttributeString("W", Math.Max(Width, 1).ToString());
				objWriter.WriteAttributeString("TP", Type.ToString());
				objWriter.WriteAttributeString("TA", GetTextAlign());
				objWriter.WriteAttributeString("CA", GetContentAlign());
				ResourceHandle image = Image;
				if (image != null)
				{
					objWriter.WriteAttributeString("IM", image.ToString());
				}
				if (SortOrder != SortOrder.None)
				{
					objWriter.WriteAttributeString("SRT", (SortOrder == SortOrder.Ascending) ? "1" : "0");
				}
				RenderComponentVisualEffectsAttributes(objContext, (IAttributeWriter)objWriter);
				RenderComponentEventAttributes(objContext, (IAttributeWriter)objWriter, blnForceRender: false);
				RenderClientID((IAttributeWriter)objWriter, blnForceRender: false);
				RenderExtendedComponentAttributes(objContext, (IAttributeWriter)objWriter);
				objWriter.WriteEndElement();
			}
		}

		/// 
		///
		/// </summary>
		/// </returns>
		private string GetTextAlign()
		{
			return TextAlign switch
			{
				HorizontalAlignment.Left => Context.RightToLeft ? "right" : "left", 
				HorizontalAlignment.Right => Context.RightToLeft ? "left" : "right", 
				_ => "center", 
			};
		}

		/// 
		///
		/// </summary>
		/// </returns>
		private string GetContentAlign()
		{
			return ContentAlign switch
			{
				ExtendedHorizontalAlignment.Left => Context.RightToLeft ? "right" : "left", 
				ExtendedHorizontalAlignment.Right => Context.RightToLeft ? "left" : "right", 
				ExtendedHorizontalAlignment.Inherit => GetTextAlign(), 
				_ => "center", 
			};
		}

		/// 
		///
		/// </summary>
		/// </returns>
		public override string ToString()
		{
			return "ColumnHeader: Text: " + Text;
		}

		/// Resizes the width of the column as indicated by the resize style.</summary>
		/// <param name="enmHeaderAutoResize">One of the <see cref="T:System.Windows.Forms.ColumnHeaderAutoResizeStyle"></see>  values.</param>
		/// <exception cref="T:System.InvalidOperationException">A value other than <see cref="F:System.Windows.Forms.ColumnHeaderAutoResizeStyle.None"></see> is passed to the <see cref="M:System.Windows.Forms.ColumnHeader.AutoResize(System.Windows.Forms.ColumnHeaderAutoResizeStyle)"></see> method when the <see cref="P:System.Windows.Forms.ListView.View"></see> property is a value other than <see cref="F:System.Windows.Forms.View.Details"></see>.</exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void AutoResize(ColumnHeaderAutoResizeStyle enmHeaderAutoResize)
		{
			if (enmHeaderAutoResize < ColumnHeaderAutoResizeStyle.None || enmHeaderAutoResize > ColumnHeaderAutoResizeStyle.ColumnContent)
			{
				throw new InvalidEnumArgumentException("headerAutoResize", (int)enmHeaderAutoResize, typeof(ColumnHeaderAutoResizeStyle));
			}
			if (Owner != null)
			{
				Owner.AutoResizeColumn(Index, enmHeaderAutoResize);
			}
		}

		/// 
		/// Called when serializable object is deserialized and we need to extract the optimized
		/// object graph to the working graph.
		/// </summary>
		/// <param name="objReader">The optimized object graph reader.</param>
		protected override void OnSerializableObjectDeserializing(SerializationReader objReader)
		{
			base.OnSerializableObjectDeserializing(objReader);
			mblnGroupBy = objReader.ReadBoolean();
			menmContentAlignment = (ExtendedHorizontalAlignment)objReader.ReadObject();
			menmSortOrder = (SortOrder)objReader.ReadObject();
			menmTextAlign = (HorizontalAlignment)objReader.ReadObject();
			menmType = (ListViewColumnType)objReader.ReadObject();
			mintDisplayIndexInternal = objReader.ReadInt32();
			mintGroupByPosition = objReader.ReadInt32();
			mintIndex = objReader.ReadInt32();
			mintInternalWidth = objReader.ReadInt32();
			mintPreferedItemHeight = objReader.ReadInt32();
			mintSortPosition = objReader.ReadInt32();
			mintWidth = objReader.ReadInt32();
			mobjResourceHandler = (ResourceHandle)objReader.ReadObject();
			mstrLabel = objReader.ReadString();
			mstrName = objReader.ReadString();
			mintImageIndex = objReader.ReadInt32();
			mstrImageKey = objReader.ReadString();
		}

		/// 
		/// Called before serializable object is serialized to optimize the application object graph.
		/// </summary>
		/// <param name="objWriter">The optimized object graph writer.</param>
		protected override void OnSerializableObjectSerializing(SerializationWriter objWriter)
		{
			base.OnSerializableObjectSerializing(objWriter);
			objWriter.WriteObject(mblnGroupBy);
			objWriter.WriteObject(menmContentAlignment);
			objWriter.WriteObject(menmSortOrder);
			objWriter.WriteObject(menmTextAlign);
			objWriter.WriteObject(menmType);
			objWriter.WriteInt32(mintDisplayIndexInternal);
			objWriter.WriteInt32(mintGroupByPosition);
			objWriter.WriteInt32(mintIndex);
			objWriter.WriteInt32(mintInternalWidth);
			objWriter.WriteInt32(mintPreferedItemHeight);
			objWriter.WriteInt32(mintSortPosition);
			objWriter.WriteInt32(mintWidth);
			objWriter.WriteObject(mobjResourceHandler);
			objWriter.WriteString(mstrLabel);
			objWriter.WriteString(mstrName);
			objWriter.WriteObject(mintImageIndex);
			objWriter.WriteObject(mstrImageKey);
		}

		/// 
		/// Initializes the state.
		/// </summary>
		private void InitializeState(bool blnLoaded)
		{
			SetState(ComponentState.Visible, blnValue: true);
			SetState(ComponentState.Loaded, blnLoaded);
		}

		/// 
		/// Should serialize the item prefered height.
		/// </summary>
		/// </returns>
		private bool ShouldSerializePreferedItemHeight()
		{
			return Type == ListViewColumnType.Control && mintPreferedItemHeight > 0;
		}

		/// 
		///
		/// </summary>
		/// <param name="objObject"></param>
		public int CompareTo(object objObject)
		{
			if (objObject is ColumnHeader columnHeader)
			{
				return (columnHeader.DisplayIndex < DisplayIndex) ? 1 : (-1);
			}
			return 0;
		}
	}
}
