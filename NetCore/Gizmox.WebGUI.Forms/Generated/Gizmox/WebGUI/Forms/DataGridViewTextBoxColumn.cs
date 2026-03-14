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
/// Hosts a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxCell"></see> cells.</summary>
	/// 2</filterpriority>
	[Serializable]
	[ToolboxBitmap(typeof(DataGridViewTextBoxColumn), "DataGridViewTextBoxColumn.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class DataGridViewTextBoxColumn : DataGridViewColumn
	{
		private const int DATAGRIDVIEWTEXTBOXCOLUMN_maxInputLength = 32767;

		/// 
		/// Gets the name of the type.
		/// </summary>
		/// The name of the type.</value>
		protected override string TypeName => "1";

		/// Gets or sets the template used to model cell appearance.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after.</returns>
		/// <exception cref="T:System.InvalidCastException">The set type is not compatible with type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxCell"></see>. </exception>
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
				if (value != null && !(value is DataGridViewTextBoxCell))
				{
					throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", "Gizmox.WebGUI.Forms.DataGridViewTextBoxCell"));
				}
				base.CellTemplate = value;
			}
		}

		/// Gets or sets the maximum number of characters that can be entered into the text box.</summary>
		/// The maximum number of characters that can be entered into the text box; the default value is 32767.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn.CellTemplate"></see> property is null.</exception>
		[SRDescription("DataGridView_TextBoxColumnMaxInputLengthDescr")]
		[DefaultValue(32767)]
		[SRCategory("CatBehavior")]
		public int MaxInputLength
		{
			get
			{
				if (TextBoxCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return TextBoxCellTemplate.MaxInputLength;
			}
			set
			{
				if (MaxInputLength == value)
				{
					return;
				}
				TextBoxCellTemplate.MaxInputLength = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewTextBoxCell dataGridViewTextBoxCell)
					{
						dataGridViewTextBoxCell.MaxInputLength = value;
					}
				}
			}
		}

		/// Gets or sets the sort mode for the column.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode"></see> that specifies the criteria used to order the rows based on the cell values in a column.</returns>
		/// 1</filterpriority>
		[DefaultValue(DataGridViewColumnSortMode.Automatic)]
		public new DataGridViewColumnSortMode SortMode
		{
			get
			{
				return base.SortMode;
			}
			set
			{
				base.SortMode = value;
			}
		}

		private DataGridViewTextBoxCell TextBoxCellTemplate => (DataGridViewTextBoxCell)CellTemplate;

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn"></see> class to the default state.</summary>
		public DataGridViewTextBoxColumn()
			: this(new DataGridViewTextBoxCell())
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn" /> class.
		/// </summary>
		/// <param name="objCellTemplate">The obj cell template.</param>
		protected DataGridViewTextBoxColumn(DataGridViewTextBoxCell objCellTemplate)
			: base(objCellTemplate)
		{
			SortMode = DataGridViewColumnSortMode.Automatic;
		}

		/// 1</filterpriority>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.Append("DataGridViewTextBoxColumn { Name=");
			stringBuilder.Append(base.Name);
			stringBuilder.Append(", Index=");
			stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}
}
