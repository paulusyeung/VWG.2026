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
	/// Hosts a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCell"></see> objects.</summary>
	/// 2</filterpriority>
	[Serializable]
	[ToolboxBitmap(typeof(DataGridViewImageColumn), "DataGridViewImageColumn.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewImageColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewImageColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	public class DataGridViewImageColumn : DataGridViewColumn
	{
		private ResourceHandle mobjIcon;

		private ResourceHandle mobjImage;

		private static Type mobjColumnType;

		/// 
		/// Gets the name of the type.
		/// </summary>
		/// The name of the type.</value>
		protected override string TypeName => "3";

		/// Gets or sets the template used to create new cells.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after.</returns>
		/// <exception cref="T:System.InvalidCastException">The set type is not compatible with type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCell"></see>. </exception>
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
				if (value != null && !(value is DataGridViewImageCell))
				{
					throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", "Gizmox.WebGUI.Forms.DataGridViewImageCell"));
				}
				base.CellTemplate = value;
			}
		}

		/// Gets or sets the column's default cell style.</summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be applied as the default style.</returns>
		[SRCategory("CatAppearance")]
		[Browsable(true)]
		[SRDescription("DataGridView_ColumnDefaultCellStyleDescr")]
		public override DataGridViewCellStyle DefaultCellStyle
		{
			get
			{
				return base.DefaultCellStyle;
			}
			set
			{
				base.DefaultCellStyle = value;
			}
		}

		/// Gets or sets a string that describes the column's image. </summary>
		/// The textual description of the column image. The default is <see cref="F:System.String.Empty"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewImageColumn.CellTemplate"></see> property is null.</exception>
		/// 1</filterpriority>
		[SRDescription("DataGridViewImageColumn_DescriptionDescr")]
		[Browsable(true)]
		[DefaultValue("")]
		[SRCategory("CatAppearance")]
		public string Description
		{
			get
			{
				if (CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ImageCellTemplate.Description;
			}
			set
			{
				if (CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				ImageCellTemplate.Description = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewImageCell dataGridViewImageCell)
					{
						dataGridViewImageCell.Description = value;
					}
				}
			}
		}

		/// Gets or sets the icon displayed in the cells of this column when the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Value"></see> property is not set and the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewImageCell.ValueIsIcon"></see> property is set to true.</summary>
		/// The <see cref="T:System.Drawing.Icon"></see> to display. The default is null.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ResourceHandle Icon
		{
			get
			{
				return mobjIcon;
			}
			set
			{
				if (mobjIcon != value)
				{
					mobjIcon = value;
					if (base.DataGridView != null)
					{
						base.DataGridView.OnColumnCommonChange(base.Index);
					}
				}
			}
		}

		/// 
		/// Gets or sets the image.
		/// </summary>
		/// The image.</value>
		[SRCategory("CatAppearance")]
		[DefaultValue(null)]
		[SRDescription("DataGridViewImageColumn_ImageDescr")]
		public ResourceHandle Image
		{
			get
			{
				return mobjImage;
			}
			set
			{
				if (mobjImage != value)
				{
					mobjImage = value;
					if (base.DataGridView != null)
					{
						base.DataGridView.OnColumnCommonChange(base.Index);
					}
				}
			}
		}

		private DataGridViewImageCell ImageCellTemplate => (DataGridViewImageCell)CellTemplate;

		/// Gets or sets the image layout in the cells for this column.</summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCellLayout"></see> that specifies the cell layout. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewImageCellLayout.Normal"></see>.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewImageColumn.CellTemplate"></see> property is null. </exception>
		/// 1</filterpriority>
		[SRDescription("DataGridViewImageColumn_ImageLayoutDescr")]
		[DefaultValue(1)]
		[SRCategory("CatAppearance")]
		public DataGridViewImageCellLayout ImageLayout
		{
			get
			{
				if (CellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				DataGridViewImageCellLayout dataGridViewImageCellLayout = ImageCellTemplate.ImageLayout;
				if (dataGridViewImageCellLayout == DataGridViewImageCellLayout.NotSet)
				{
					dataGridViewImageCellLayout = DataGridViewImageCellLayout.Normal;
				}
				return dataGridViewImageCellLayout;
			}
			set
			{
				if (ImageLayout == value)
				{
					return;
				}
				ImageCellTemplate.ImageLayout = value;
				if (base.DataGridView == null)
				{
					return;
				}
				DataGridViewRowCollection rows = base.DataGridView.Rows;
				int count = rows.Count;
				for (int i = 0; i < count; i++)
				{
					DataGridViewRow dataGridViewRow = rows.SharedRow(i);
					if (dataGridViewRow.Cells[base.Index] is DataGridViewImageCell dataGridViewImageCell)
					{
						dataGridViewImageCell.ImageLayoutInternal = value;
					}
				}
				base.DataGridView.OnColumnCommonChange(base.Index);
			}
		}

		/// Gets or sets a value indicating whether cells in this column display <see cref="T:System.Drawing.Icon"></see> values.</summary>
		/// true if cells display values of type <see cref="T:System.Drawing.Icon"></see>; false if cells display values of type <see cref="T:System.Drawing.Image"></see>. The default is false.</returns>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewImageColumn.CellTemplate"></see> property is null.</exception>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool ValuesAreIcons
		{
			get
			{
				if (ImageCellTemplate == null)
				{
					throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
				}
				return ImageCellTemplate.ValueIsIcon;
			}
			set
			{
				if (ValuesAreIcons == value)
				{
					return;
				}
				ImageCellTemplate.ValueIsIconInternal = value;
				if (base.DataGridView != null)
				{
					DataGridViewRowCollection rows = base.DataGridView.Rows;
					int count = rows.Count;
					for (int i = 0; i < count; i++)
					{
						DataGridViewRow dataGridViewRow = rows.SharedRow(i);
						if (dataGridViewRow.Cells[base.Index] is DataGridViewImageCell dataGridViewImageCell)
						{
							dataGridViewImageCell.ValueIsIconInternal = value;
						}
					}
					base.DataGridView.OnColumnCommonChange(base.Index);
				}
				if (value && DefaultCellStyle.NullValue is Bitmap && (ResourceHandle)DefaultCellStyle.NullValue == DataGridViewImageCell.ErrorBitmap)
				{
					DefaultCellStyle.NullValue = DataGridViewImageCell.ErrorIcon;
				}
				else if (!value && DefaultCellStyle.NullValue is Icon && (Icon)DefaultCellStyle.NullValue == DataGridViewImageCell.ErrorIcon)
				{
					DefaultCellStyle.NullValue = DataGridViewImageCell.ErrorBitmap;
				}
			}
		}

		static DataGridViewImageColumn()
		{
			mobjColumnType = typeof(DataGridViewImageColumn);
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageColumn"></see> class, configuring it for use with cell values of type <see cref="T:System.Drawing.Image"></see>.</summary>
		public DataGridViewImageColumn()
			: this(blnValuesAreIcons: true)
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageColumn"></see> class, optionally configuring it for use with <see cref="T:System.Drawing.Icon"></see> cell values.</summary>
		/// <param name="blnValuesAreIcons">true to indicate that the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Value"></see> property of cells in this column will be set to values of type <see cref="T:System.Drawing.Icon"></see>; false to indicate that they will be set to values of type <see cref="T:System.Drawing.Image"></see>.</param>
		public DataGridViewImageColumn(bool blnValuesAreIcons)
			: this(blnValuesAreIcons, new DataGridViewImageCell(blnValuesAreIcons))
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageColumn" /> class.
		/// </summary>
		/// <param name="blnValuesAreIcons">if set to true</c> [BLN values are icons].</param>
		/// <param name="objCellTemplate">The obj cell template.</param>
		protected DataGridViewImageColumn(bool blnValuesAreIcons, DataGridViewImageCell objCellTemplate)
			: base(objCellTemplate)
		{
			DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle
			{
				AlignmentInternal = DataGridViewContentAlignment.MiddleCenter
			};
			if (blnValuesAreIcons)
			{
				dataGridViewCellStyle.NullValue = DataGridViewImageCell.ErrorIcon;
			}
			else
			{
				dataGridViewCellStyle.NullValue = DataGridViewImageCell.ErrorBitmap;
			}
			DefaultCellStyle = dataGridViewCellStyle;
		}

		/// 1</filterpriority>
		public override object Clone()
		{
			Type type = GetType();
			DataGridViewImageColumn dataGridViewImageColumn = ((!(type == mobjColumnType)) ? ((DataGridViewImageColumn)Activator.CreateInstance(type)) : new DataGridViewImageColumn());
			if (dataGridViewImageColumn != null)
			{
				dataGridViewImageColumn.Icon = Icon;
				dataGridViewImageColumn.Image = Image;
			}
			return dataGridViewImageColumn;
		}

		private bool ShouldSerializeDefaultCellStyle()
		{
			if (CellTemplate is DataGridViewImageCell dataGridViewImageCell)
			{
				if (!base.HasDefaultCellStyle)
				{
					return false;
				}
				object obj = ((!dataGridViewImageCell.ValueIsIcon) ? ((IDisposable)DataGridViewImageCell.ErrorBitmap) : ((IDisposable)DataGridViewImageCell.ErrorIcon));
				DataGridViewCellStyle defaultCellStyle = DefaultCellStyle;
				if (defaultCellStyle.BackColor.IsEmpty && defaultCellStyle.ForeColor.IsEmpty && defaultCellStyle.SelectionBackColor.IsEmpty && defaultCellStyle.SelectionForeColor.IsEmpty && defaultCellStyle.Font == null && obj == defaultCellStyle.NullValue && defaultCellStyle.IsDataSourceNullValueDefault && CommonUtils.IsNullOrEmpty(defaultCellStyle.Format) && defaultCellStyle.FormatProvider.Equals(CultureInfo.CurrentCulture) && defaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter && defaultCellStyle.WrapMode == DataGridViewTriState.NotSet && defaultCellStyle.Tag == null)
				{
					return !defaultCellStyle.Padding.Equals(Padding.Empty);
				}
			}
			return true;
		}

		/// 1</filterpriority>
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			stringBuilder.Append("DataGridViewImageColumn { Name=");
			stringBuilder.Append(base.Name);
			stringBuilder.Append(", Index=");
			stringBuilder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
			stringBuilder.Append(" }");
			return stringBuilder.ToString();
		}
	}
}
