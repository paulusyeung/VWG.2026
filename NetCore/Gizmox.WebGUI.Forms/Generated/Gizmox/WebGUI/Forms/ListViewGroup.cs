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
	/// Represents a group of items displayed within a <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</summary>
	/// 2</filterpriority>
	[Serializable]
	[DefaultProperty("Header")]
	[DesignTimeVisible(false)]
	[TypeConverter(typeof(ListViewGroupConverter))]
	[ToolboxItem(false)]
	public sealed class ListViewGroup : SerializableObject
	{
		private string mstrHeader;

		private HorizontalAlignment menmHeaderAlignment;

		private ListView.ListViewItemCollection mobjItems;

		private ListView listView;

		private string mstrName;

		private static int mintNextHeader = 1;

		private object mobjUserData;

		/// 
		/// The group property registration.
		/// </summary>
		private static readonly SerializableProperty GroupProperty = SerializableProperty.Register("Group", typeof(ListViewGroup), typeof(ListViewGroup), new SerializablePropertyMetadata(null));

		/// 
		/// The groups collection
		/// </summary>
		private static readonly SerializableProperty GroupsProperty = SerializableProperty.Register("Groups", typeof(ListViewGroupCollection), typeof(ListViewGroup), new SerializablePropertyMetadata(null));

		/// Gets or sets the header text for the group.</summary>
		/// The text to display for the group header. The default is "ListViewGroup".</returns>
		[SRCategory("CatAppearance")]
		public string Header
		{
			get
			{
				if (mstrHeader != null)
				{
					return mstrHeader;
				}
				return "";
			}
			set
			{
				if (mstrHeader != value)
				{
					mstrHeader = value;
				}
			}
		}

		/// Gets or sets the alignment of the group header text.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> values that specifies the alignment of the header text. The default is <see cref="F:Gizmox.WebGUI.Forms.HorizontalAlignment.Left"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> value.</exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatAppearance")]
		[DefaultValue(0)]
		public HorizontalAlignment HeaderAlignment
		{
			get
			{
				return menmHeaderAlignment;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(HorizontalAlignment));
				}
				if (menmHeaderAlignment != value)
				{
					menmHeaderAlignment = value;
					UpdateListView();
				}
			}
		}

		/// Gets or sets the group to which the item is assigned.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> to which the item is assigned.</returns>
		[Localizable(true)]
		[DefaultValue(null)]
		[SRCategory("CatBehavior")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ListViewGroup Group
		{
			get
			{
				return GetValue(GroupProperty);
			}
			set
			{
				ListViewGroup listViewGroup = Group;
				if (listViewGroup != value)
				{
					if (value != null)
					{
						value.Groups.Add(this);
					}
					else
					{
						listViewGroup?.Groups.Remove(this);
					}
				}
			}
		}

		/// Gets the collection of <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> objects assigned to the control.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ListViewGroupCollection"></see> that contains all the groups in the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control.</returns>
		[MergableProperty(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRCategory("CatBehavior")]
		[Localizable(true)]
		[SRDescription("ListViewGroupsDescr")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ListViewGroupCollection Groups
		{
			get
			{
				ListViewGroupCollection listViewGroupCollection = GetValue(GroupsProperty);
				if (listViewGroupCollection == null)
				{
					listViewGroupCollection = new ListViewGroupCollection(this);
					SetValue(GroupsProperty, listViewGroupCollection);
				}
				return listViewGroupCollection;
			}
		}

		/// Gets a collection containing all items associated with this group.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see> that contains all the items in the group. If there are no items in the group, an empty <see cref="T:Gizmox.WebGUI.Forms.ListView.ListViewItemCollection"></see> object is returned.</returns>
		/// 1</filterpriority>
		[Browsable(false)]
		public ListView.ListViewItemCollection Items
		{
			get
			{
				if (mobjItems == null)
				{
					mobjItems = new ListView.ListViewItemCollection(this);
				}
				return mobjItems;
			}
		}

		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control that contains this group. </summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.ListView"></see> control that contains this group.</returns>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public ListView ListView => listView;

		internal ListView ListViewInternal
		{
			get
			{
				return listView;
			}
			set
			{
				if (listView != value)
				{
					listView = value;
				}
			}
		}

		/// Gets or sets the name of the group.</summary>
		/// The name of the group.</returns>
		[SRCategory("CatBehavior")]
		[Browsable(true)]
		[DefaultValue("")]
		[SRDescription("ListViewGroupNameDescr")]
		public string Name
		{
			get
			{
				return mstrName;
			}
			set
			{
				mstrName = value;
			}
		}

		/// Gets or sets the object that contains data about the group.</summary>
		/// An <see cref="T:System.Object"></see> for storing the additional data. </returns>
		/// 1</filterpriority>
		[Localizable(false)]
		[DefaultValue(null)]
		[TypeConverter(typeof(StringConverter))]
		[SRCategory("CatData")]
		[SRDescription("ControlTagDescr")]
		[Bindable(true)]
		public object Tag
		{
			get
			{
				return mobjUserData;
			}
			set
			{
				mobjUserData = value;
			}
		}

		/// 1</filterpriority>
		public override string ToString()
		{
			return Header;
		}

		private void UpdateListView()
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> class using the default header text of "ListViewGroup" and the default left header alignment.</summary>
		public ListViewGroup()
			: this(SR.GetString("ListViewGroupDefaultHeader", mintNextHeader++))
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> class using the specified value to initialize the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Header"></see> property and using the default left header alignment.</summary>
		/// <param name="strHeader">The text to display for the group header. </param>
		public ListViewGroup(string strHeader)
		{
			mstrHeader = strHeader;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> class using the specified values to initialize the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Name"></see> and <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Header"></see> properties. </summary>
		/// <param name="strHeaderText">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Header"></see> property.</param>
		/// <param name="strKey">The initial value of the <see cref="P:Gizmox.WebGUI.Forms.ListViewGroup.Name"></see> property.</param>
		public ListViewGroup(string strKey, string strHeaderText)
			: this()
		{
			mstrName = strKey;
			mstrHeader = strHeaderText;
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewGroup"></see> class using the specified header text and the specified header alignment.</summary>
		/// <param name="strHeader">The text to display for the group header. </param>
		/// <param name="enmHeaderAlignment">One of the <see cref="T:Gizmox.WebGUI.Forms.HorizontalAlignment"></see> values that specifies the alignment of the header text. </param>
		public ListViewGroup(string strHeader, HorizontalAlignment enmHeaderAlignment)
			: this(strHeader)
		{
			menmHeaderAlignment = enmHeaderAlignment;
		}
	}
}
