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
/// Represents a column of cells that contain links in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
	/// 2</filterpriority>
	[Serializable]
	[ToolboxBitmap(typeof(DataGridViewLinkColumn), "DataGridViewLinkColumn.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewLinkColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewLinkColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class DataGridViewLinkColumn : DataGridViewColumn
	{
		private string mstrText;

		private static Type mobjColumnType;

		/// 
		/// Gets the name of the type.
		/// </summary>
		/// The name of the type.</value>
		protected override string TypeName => "4";

		/// Gets or sets the color used to display an active link within cells in the column. </summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the color used to display a link that is being selected. The default value is the user's Internet Explorer setting for the color of links in the hover state.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
		[SRDescription("DataGridView_LinkColumnActiveLinkColorDescr")]
		[SRCategory("CatAppearance")]
		public Color ActiveLinkColor
		{
			get
			{
				if (CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ((DataGridViewLinkCell)CellTemplate).ActiveLinkColor;
			}
			set
			{
				if (ActiveLinkColor.Equals(value))
				{
					return;
				}
				((DataGridViewLinkCell)CellTemplate).ActiveLinkColorInternal = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					if (rows.SharedRow(i).Cells[base.Index] is DataGridViewLinkCell dataGridViewLinkCell)
					{
						dataGridViewLinkCell.ActiveLinkColorInternal = value;
					}
				}
				base.DataGridView.InvalidateColumn(base.Index);
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkCell" /> is URL.
		/// </summary>
		/// true</c> if URL; otherwise, false</c>.</value>
		[SRDescription("DataGridView_LinkColumnUrlDescr")]
		[SRCategory("CatData")]
		public string Url
		{
			get
			{
				if (CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ((DataGridViewLinkCell)CellTemplate).Url;
			}
			set
			{
				if (!(Url != value))
				{
					return;
				}
				if (CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				((DataGridViewLinkCell)CellTemplate).Url = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					if (rows.SharedRow(i).Cells[base.Index] is DataGridViewLinkCell dataGridViewLinkCell)
					{
						dataGridViewLinkCell.Url = value;
					}
				}
			}
		}

		/// Gets or sets the template used to create new cells.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after. The default value is a new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkCell"></see> instance.</returns>
		/// <exception cref="T:System.InvalidCastException">When setting this property to a value that is not of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkCell"></see>.</exception>
		/// 1</filterpriority>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public override DataGridViewCell CellTemplate
		{
			get
			{
				return base.CellTemplate;
			}
			set
			{
				if (value != null && !(value is DataGridViewLinkCell))
				{
					throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", "Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"));
				}
				base.CellTemplate = value;
			}
		}

		/// Gets or sets a value that represents the behavior of links within cells in the column.</summary>
		/// A <see cref="T:System.Windows.Forms.LinkBehavior"></see> value indicating the link behavior. The default is <see cref="F:System.Windows.Forms.LinkBehavior.SystemDefault"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
		/// 1</filterpriority>
		[SRCategory("CatBehavior")]
		[DefaultValue(0)]
		[SRDescription("DataGridView_LinkColumnLinkBehaviorDescr")]
		public LinkBehavior LinkBehavior
		{
			get
			{
				if (CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ((DataGridViewLinkCell)CellTemplate).LinkBehavior;
			}
			set
			{
				if (LinkBehavior.Equals(value))
				{
					return;
				}
				((DataGridViewLinkCell)CellTemplate).LinkBehavior = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					if (rows.SharedRow(i).Cells[base.Index] is DataGridViewLinkCell dataGridViewLinkCell)
					{
						dataGridViewLinkCell.LinkBehaviorInternal = value;
					}
				}
				base.DataGridView.InvalidateColumn(base.Index);
			}
		}

		/// 
		/// Gets or sets the ClientMode value of it's cell template.
		/// Setter sets the value to it's cell template as well as to all cells in the column. 
		/// </summary>
		/// true</c> if [client mode]; otherwise, false</c>.</value>
		[SRDescription("DataGridView_LinkColumnClientModeDescr")]
		[SRCategory("CatBehavior")]
		public bool ClientMode
		{
			get
			{
				if (CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ((DataGridViewLinkCell)CellTemplate).ClientMode;
			}
			set
			{
				if (ClientMode == value)
				{
					return;
				}
				if (CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				((DataGridViewLinkCell)CellTemplate).ClientMode = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					if (rows.SharedRow(i).Cells[base.Index] is DataGridViewLinkCell dataGridViewLinkCell)
					{
						dataGridViewLinkCell.ClientMode = value;
					}
				}
			}
		}

		/// Gets or sets the color used to display an unselected link within cells in the column.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the color used to initially display a link. The default value is the user's Internet Explorer setting for the link color. </returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridView_LinkColumnLinkColorDescr")]
		public Color LinkColor
		{
			get
			{
				if (CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ((DataGridViewLinkCell)CellTemplate).LinkColor;
			}
			set
			{
				if (LinkColor.Equals(value))
				{
					return;
				}
				((DataGridViewLinkCell)CellTemplate).LinkColorInternal = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					if (rows.SharedRow(i).Cells[base.Index] is DataGridViewLinkCell dataGridViewLinkCell)
					{
						dataGridViewLinkCell.LinkColorInternal = value;
					}
				}
				base.DataGridView.InvalidateColumn(base.Index);
			}
		}

		/// Gets or sets the link text displayed in a column's cells if <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.UseColumnTextForLinkValue"></see> is true.</summary>
		/// A <see cref="T:System.String"></see> containing the link text.</returns>
		/// <exception cref="T:System.InvalidOperationException">When setting this property, the value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
		/// 1</filterpriority>
		[SRCategory("CatAppearance")]
		[SRDescription("DataGridView_LinkColumnTextDescr")]
		[DefaultValue(null)]
		public string Text
		{
			get
			{
				return mstrText;
			}
			set
			{
				if (string.Equals(value, Text, StringComparison.Ordinal))
				{
					return;
				}
				mstrText = value;
				if (base.DataGridView == null)
				{
					return;
				}
				if (UseColumnTextForLinkValue)
				{
					base.DataGridView.OnColumnCommonChange(base.Index);
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					if (rows.SharedRow(i).Cells[base.Index] is DataGridViewLinkCell { UseColumnTextForLinkValue: not false })
					{
						base.DataGridView.OnColumnCommonChange(base.Index);
						return;
					}
				}
				base.DataGridView.InvalidateColumn(base.Index);
			}
		}

		/// Gets or sets a value indicating whether the link changes color if it has been visited.</summary>
		/// true if the link changes color when it is selected; otherwise, false. The default is true.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
		/// 1</filterpriority>
		[SRDescription("DataGridView_LinkColumnTrackVisitedStateDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		public bool TrackVisitedState
		{
			get
			{
				if (CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ((DataGridViewLinkCell)CellTemplate).TrackVisitedState;
			}
			set
			{
				if (TrackVisitedState == value)
				{
					return;
				}
				((DataGridViewLinkCell)CellTemplate).TrackVisitedStateInternal = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					if (rows.SharedRow(i).Cells[base.Index] is DataGridViewLinkCell dataGridViewLinkCell)
					{
						dataGridViewLinkCell.TrackVisitedStateInternal = value;
					}
				}
				base.DataGridView.InvalidateColumn(base.Index);
			}
		}

		/// Gets or sets a value indicating whether the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.Text"></see> property value is displayed as the link text.</summary>
		/// true if the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.Text"></see> property value is displayed as the link text; false if the cell <see cref="P:System.Windows.Forms.DataGridViewCell.FormattedValue"></see> property value is displayed as the link text. The default is false.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
		[DefaultValue(false)]
		[SRDescription("DataGridView_LinkColumnUseColumnTextForLinkValueDescr")]
		[SRCategory("CatAppearance")]
		public bool UseColumnTextForLinkValue
		{
			get
			{
				if (CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ((DataGridViewLinkCell)CellTemplate).UseColumnTextForLinkValue;
			}
			set
			{
				if (UseColumnTextForLinkValue == value)
				{
					return;
				}
				((DataGridViewLinkCell)CellTemplate).UseColumnTextForLinkValueInternal = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					if (rows.SharedRow(i).Cells[base.Index] is DataGridViewLinkCell dataGridViewLinkCell)
					{
						dataGridViewLinkCell.UseColumnTextForLinkValueInternal = value;
					}
				}
				base.DataGridView.OnColumnCommonChange(base.Index);
			}
		}

		/// Gets or sets the color used to display a link that has been previously visited.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that represents the color used to display a link that has been visited. The default value is the user's Internet Explorer setting for the visited link color. </returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
		[SRDescription("DataGridView_LinkColumnVisitedLinkColorDescr")]
		[SRCategory("CatAppearance")]
		public Color VisitedLinkColor
		{
			get
			{
				if (CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ((DataGridViewLinkCell)CellTemplate).VisitedLinkColor;
			}
			set
			{
				if (VisitedLinkColor.Equals(value))
				{
					return;
				}
				((DataGridViewLinkCell)CellTemplate).VisitedLinkColorInternal = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					if (rows.SharedRow(i).Cells[base.Index] is DataGridViewLinkCell dataGridViewLinkCell)
					{
						dataGridViewLinkCell.VisitedLinkColorInternal = value;
					}
				}
				base.DataGridView.InvalidateColumn(base.Index);
			}
		}

		static DataGridViewLinkColumn()
		{
			mobjColumnType = typeof(DataGridViewLinkColumn);
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkColumn"></see> class. </summary>
		public DataGridViewLinkColumn()
			: this(new DataGridViewLinkCell())
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkColumn" /> class.
		/// </summary>
		/// <param name="objCellTemplate">The obj cell template.</param>
		protected DataGridViewLinkColumn(DataGridViewLinkCell objCellTemplate)
			: base(objCellTemplate)
		{
		}

		/// Creates an exact copy of this column.</summary>
		/// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkColumn"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null. </exception>
		public override object Clone()
		{
			return base.Clone();
		}

		private bool ShouldSerializeActiveLinkColor()
		{
			return !ActiveLinkColor.Equals(LinkUtilities.IEActiveLinkColor);
		}

		private bool ShouldSerializeLinkColor()
		{
			return !LinkColor.Equals(LinkUtilities.IELinkColor);
		}

		private bool ShouldSerializeVisitedLinkColor()
		{
			return !VisitedLinkColor.Equals(LinkUtilities.IEVisitedLinkColor);
		}

		/// 1</filterpriority>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.Append("DataGridViewLinkColumn { Name=");
			stringBuilder.Append(base.Name);
			stringBuilder.Append(", Index=");
			stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}
}
