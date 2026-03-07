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
	/// The visual appearnce object of the ListView
	/// </summary>
	[Serializable]
	[VisualTemplate(typeof(ListView), "Visually adjusts the ListView control to an appearance more suitable for the customized device.")]
	[Skin(typeof(ListViewVisualTemplateSkin))]
	public class ListViewVisualTemplate : VisualTemplate
	{
		private ListViewVisualTemplateGroupingStyleEnum menmListViewVisualTemplateGroupingStyleEnum = ListViewVisualTemplateGroupingStyleEnum.Original;

		private ListViewVisualTemplateRowTemplateEnum menmListViewVisualTemplateRowTemplateEnum = ListViewVisualTemplateRowTemplateEnum.None;

		private string mstrColumnNumberNewOrder;

		private string mstrListViewVisualTemplateRowCustomStyleName;

		/// 
		/// Gets or sets the proxy ListView groups visualizer style.
		/// </summary>
		/// 
		/// The proxy ListView groups visualizer style.
		/// </value>
		[DisplayName("Grouping style")]
		[Description("The grouping option of the ListViewItems.")]
		public ListViewVisualTemplateGroupingStyleEnum ListViewVisualTemplateGroupingStyle
		{
			get
			{
				return menmListViewVisualTemplateGroupingStyleEnum;
			}
			set
			{
				menmListViewVisualTemplateGroupingStyleEnum = value;
			}
		}

		/// 
		/// Gets or sets the proxy ListView groups visualizer style.
		/// </summary>
		/// 
		/// The proxy ListView groups visualizer style.
		/// </value>        
		[DisplayName("Row template")]
		[Description("The template of a row in the ListView. To insert a custom template, choose \"Custom\".")]
		public ListViewVisualTemplateRowTemplateEnum ListViewVisualTemplateRowTemplate
		{
			get
			{
				return menmListViewVisualTemplateRowTemplateEnum;
			}
			set
			{
				menmListViewVisualTemplateRowTemplateEnum = value;
			}
		}

		/// 
		/// Gets or sets the column number new order.
		/// </summary>
		/// 
		/// The column number new order.
		/// </value>
		[WebEditor(typeof(VisualTemplateListViewColumnOrderEditor), typeof(WebUITypeEditor))]
		[Editor(typeof(VisualTemplateListViewColumnOrderEditor), typeof(WebUITypeEditor))]
		[Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateListViewColumnOrderEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[DisplayName("Columns order")]
		[Description("The order of the columns. Used together with row templates to determine the items position.")]
		public string ColumnNumberNewOrder
		{
			get
			{
				return mstrColumnNumberNewOrder;
			}
			set
			{
				mstrColumnNumberNewOrder = value;
			}
		}

		/// 
		/// Gets the name of the visual template.
		/// </summary>
		/// 
		/// The name of the visual template.
		/// </value>
		public override string VisualTemplateName => "ListViewVisualTemplate";

		/// 
		/// Gets the visualizer image.
		/// </summary>
		/// 
		/// The visualizer image.
		/// </value>
		public override ResourceHandle VisualizerImage => new SkinResourceHandle(typeof(ListViewVisualTemplateSkin), "ContactListWithGrouping.png");

		/// 
		/// Gets or sets the name of the ListView visual template row custom style.
		/// </summary>
		/// 
		/// The name of the ListView visual template row custom style.
		/// </value>
		[DisplayName("Custom template")]
		[Description("The name of a custom row template. To insert a custom template, choose \"Custom\" under \"Row template\". Don't forget to set the columns order as well.")]
		public virtual string ListViewVisualTemplateRowCustomStyleName
		{
			get
			{
				return mstrListViewVisualTemplateRowCustomStyleName;
			}
			set
			{
				mstrListViewVisualTemplateRowCustomStyleName = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewVisualTemplate" /> class.
		/// </summary>
		public ListViewVisualTemplate()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewVisualTemplate" /> class.
		/// </summary>
		/// <param name="enmProxyListViewGroupsVisualizerStyle">The enm proxy ListView groups visualizer style.</param>
		/// <param name="strColumnNumberNewOrder">The string column number new order.</param>
		public ListViewVisualTemplate(ListViewVisualTemplateGroupingStyleEnum enmProxyListViewGroupsVisualizerStyle, ListViewVisualTemplateRowTemplateEnum enmListViewVisualTemplateRowTemplateEnum, string strColumnNumberNewOrder, string strListViewVisualTemplateRowCustomStyleName)
		{
			menmListViewVisualTemplateGroupingStyleEnum = enmProxyListViewGroupsVisualizerStyle;
			menmListViewVisualTemplateRowTemplateEnum = enmListViewVisualTemplateRowTemplateEnum;
			mstrColumnNumberNewOrder = strColumnNumberNewOrder;
			mstrListViewVisualTemplateRowCustomStyleName = strListViewVisualTemplateRowCustomStyleName;
		}

		/// 
		/// Gets the constroctor arguments. (For TypeContevert)
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override object[] GetConsturctorArguments()
		{
			return new object[4] { menmListViewVisualTemplateGroupingStyleEnum, menmListViewVisualTemplateRowTemplateEnum, mstrColumnNumberNewOrder, mstrListViewVisualTemplateRowCustomStyleName };
		}

		/// 
		/// Gets the constroctor types. (For TypeContevert)
		/// </summary>
		public override Type[] GetConstructorTypes()
		{
			return new Type[4]
			{
				typeof(ListViewVisualTemplateGroupingStyleEnum),
				typeof(ListViewVisualTemplateRowTemplateEnum),
				typeof(string),
				typeof(string)
			};
		}

		/// 
		/// Renders the specified object context.
		/// </summary>
		/// <param name="objContext">The object context.</param>
		/// <param name="objWriter">The object writer.</param>
		public override void Render(IContext objContext, IAttributeWriter objWriter)
		{
			base.Render(objContext, objWriter);
			objWriter.WriteAttributeString("VIS_LV_GR", menmListViewVisualTemplateGroupingStyleEnum.ToString());
			if (!string.IsNullOrEmpty(mstrColumnNumberNewOrder))
			{
				objWriter.WriteAttributeString("VIS_LV_CO", mstrColumnNumberNewOrder);
			}
			if (menmListViewVisualTemplateRowTemplateEnum == ListViewVisualTemplateRowTemplateEnum.Custom)
			{
				objWriter.WriteAttributeString("VIS_LVI_TPL", ListViewVisualTemplateRowCustomStyleName);
			}
			else
			{
				objWriter.WriteAttributeString("VIS_LVI_TPL", menmListViewVisualTemplateRowTemplateEnum.ToString());
			}
		}

		/// 
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return "Customizable Display";
		}

		/// 
		/// Gets the default visual template for a given control.
		/// </summary>
		/// <param name="objControl">The object control.</param>
		/// </returns>
		public override VisualTemplate GetDefault(Control objControl)
		{
			if (objControl is ListView listView)
			{
				ListViewVisualTemplate listViewVisualTemplate = new ListViewVisualTemplate();
				listViewVisualTemplate.ListViewVisualTemplateGroupingStyle = ListViewVisualTemplateGroupingStyleEnum.AlphabetGrouping;
				StringBuilder stringBuilder = new StringBuilder();
				List<object> list = new List<object>();
				foreach (ColumnHeader sortingColumn in listView.SortingColumns)
				{
					if (sortingColumn.Type == ListViewColumnType.Number || sortingColumn.Type == ListViewColumnType.Text || sortingColumn.Type == ListViewColumnType.Date)
					{
						stringBuilder.Append($"{sortingColumn.Index}|");
						list.Add(sortingColumn);
					}
				}
				foreach (ColumnHeader column in listView.Columns)
				{
					if (!list.Contains(column) && (column.Type == ListViewColumnType.Number || column.Type == ListViewColumnType.Text || column.Type == ListViewColumnType.Date))
					{
						stringBuilder.Append($"{column.Index}|");
					}
				}
				listViewVisualTemplate.ColumnNumberNewOrder = stringBuilder.ToString().Trim('|');
				listViewVisualTemplate.ListViewVisualTemplateRowTemplate = ListViewVisualTemplateRowTemplateEnum.ContactList;
				return listViewVisualTemplate;
			}
			return null;
		}

		/// 
		/// Converts to string.
		/// </summary>
		/// </returns>
		internal override string ConvertToString()
		{
			string text = ((mstrColumnNumberNewOrder == null) ? string.Empty : mstrColumnNumberNewOrder.Replace('|', '~'));
			string text2 = ((mstrListViewVisualTemplateRowCustomStyleName == null) ? string.Empty : mstrListViewVisualTemplateRowCustomStyleName);
			return $"{base.ConvertToString()}|{(int)menmListViewVisualTemplateGroupingStyleEnum}|{(int)menmListViewVisualTemplateRowTemplateEnum}|{text2}|{text}";
		}

		/// 
		/// Converts from string.
		/// </summary>
		/// <param name="objVisualTemplateValues">The object visual template values.</param>
		internal override void ConvertFromString(List<object> objVisualTemplateValues)
		{
			int result = 0;
			int result2 = 0;
			if (objVisualTemplateValues.Count == 4 && int.TryParse(objVisualTemplateValues[0], out result) && int.TryParse(objVisualTemplateValues[1], out result2))
			{
				if (Enum.IsDefined(typeof(ListViewVisualTemplateGroupingStyleEnum), result))
				{
					menmListViewVisualTemplateGroupingStyleEnum = (ListViewVisualTemplateGroupingStyleEnum)result;
				}
				if (Enum.IsDefined(typeof(ListViewVisualTemplateRowTemplateEnum), result2))
				{
					menmListViewVisualTemplateRowTemplateEnum = (ListViewVisualTemplateRowTemplateEnum)result2;
				}
				if (!string.IsNullOrEmpty(objVisualTemplateValues[2]))
				{
					mstrListViewVisualTemplateRowCustomStyleName = objVisualTemplateValues[2];
				}
				else
				{
					mstrListViewVisualTemplateRowCustomStyleName = string.Empty;
				}
				if (!string.IsNullOrEmpty(objVisualTemplateValues[3]))
				{
					mstrColumnNumberNewOrder = objVisualTemplateValues[3].Replace('~', '|');
				}
				else
				{
					mstrColumnNumberNewOrder = string.Empty;
				}
			}
		}
	}
}
