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
/// Displays a graphic in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
	/// 2</filterpriority>
	[Serializable]
	[Skin(typeof(DataGridViewImageCellSkin))]
	public class DataGridViewImageCell : DataGridViewCell
	{
		private const byte DATAGRIDVIEWIMAGECELL_valueIsIcon = 1;

		private bool mblnValueIsIcon;

		private byte mobjFlags;

		private DataGridViewImageCellLayout menmImageLayout;

		private static Type mobjCellType;

		private static Type mobjDefaultTypeIcon;

		private static Type mobjDefaultTypeImage;

		private static ResourceHandle mobjErrorBmp;

		private string mstrDescription = string.Empty;

		/// 
		/// Gets or sets the flags.
		/// </summary>
		/// The flags.</value>
		private byte Flags
		{
			get
			{
				return mobjFlags;
			}
			set
			{
				mobjFlags = value;
			}
		}

		/// Gets the default value that is used when creating a new row.</summary>
		/// An object containing a default image placeholder, or null to display an empty cell.</returns>
		/// 1</filterpriority>
		public override object DefaultNewRowValue => null;

		/// Gets or sets the text associated with the image.</summary>
		/// The text associated with the image displayed in the cell.</returns>
		/// 1</filterpriority>
		[DefaultValue("")]
		public string Description
		{
			get
			{
				return mstrDescription;
			}
			set
			{
				mstrDescription = value;
			}
		}

		/// Gets the type of the cell's hosted editing control. </summary>
		/// The <see cref="T:System.Type"></see> of the underlying editing control. As implemented in this class, this property is always null.</returns>
		/// 1</filterpriority>
		public override Type EditType => null;

		/// 
		/// Gets the error bitmap.
		/// </summary>
		/// The error bitmap.</value>
		internal static ResourceHandle ErrorBitmap
		{
			get
			{
				if (mobjErrorBmp == null)
				{
					mobjErrorBmp = new SkinResourceHandle(typeof(DataGridView), "ErrorProvider.gif");
				}
				return mobjErrorBmp;
			}
		}

		/// 
		/// Gets the error icon.
		/// </summary>
		/// The error icon.</value>
		internal static Icon ErrorIcon => null;

		/// Gets the type of the formatted value associated with the cell.</summary>
		/// A <see cref="T:System.Type"></see> object representing display value type of the cell, which is the <see cref="T:System.Drawing.Image"></see> type if the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewImageCell.ValueIsIcon"></see> property is set to false or the <see cref="T:System.Drawing.Icon"></see> type otherwise.</returns>
		/// 1</filterpriority>
		public override Type FormattedValueType
		{
			get
			{
				if (ValueIsIcon)
				{
					return mobjDefaultTypeIcon;
				}
				return mobjDefaultTypeImage;
			}
		}

		/// Gets or sets the graphics layout for the cell. </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCellLayout"></see> for this cell. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewImageCellLayout.NotSet"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The supplied <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCellLayout"></see> value is invalid. </exception>
		/// 1</filterpriority>
		[DefaultValue(0)]
		public DataGridViewImageCellLayout ImageLayout
		{
			get
			{
				return menmImageLayout;
			}
			set
			{
				ImageLayoutInternal = value;
			}
		}

		/// 
		/// Sets the image layout internal.
		/// </summary>
		/// The image layout internal.</value>
		internal DataGridViewImageCellLayout ImageLayoutInternal
		{
			set
			{
				menmImageLayout = value;
			}
		}

		/// Gets or sets a value indicating whether this cell displays an <see cref="T:System.Drawing.Icon"></see> value.</summary>
		/// true if this cell displays an <see cref="T:System.Drawing.Icon"></see> value; otherwise, false.</returns>
		[DefaultValue(false)]
		public bool ValueIsIcon
		{
			get
			{
				return mblnValueIsIcon;
			}
			set
			{
				ValueIsIconInternal = value;
			}
		}

		/// 
		/// Sets a value indicating whether [value is icon internal].
		/// </summary>
		/// 
		/// 	true</c> if [value is icon internal]; otherwise, false</c>.
		/// </value>
		internal bool ValueIsIconInternal
		{
			set
			{
				mblnValueIsIcon = value;
			}
		}

		/// Gets or sets the data type of the values in the cell. </summary>
		/// The <see cref="T:System.Type"></see> of the cell's value.</returns>
		/// 1</filterpriority>
		public override Type ValueType
		{
			get
			{
				Type valueType = base.ValueType;
				if (valueType != null)
				{
					return valueType;
				}
				return typeof(ResourceHandle);
			}
			set
			{
				base.ValueType = value;
			}
		}

		static DataGridViewImageCell()
		{
			mobjDefaultTypeIcon = typeof(ResourceHandle);
			mobjDefaultTypeImage = typeof(ResourceHandle);
			mobjCellType = typeof(DataGridViewImageCell);
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCell"></see> class, configuring it for use with cell values other than <see cref="T:System.Drawing.Icon"></see> objects.</summary>
		public DataGridViewImageCell()
		{
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCell"></see> class, optionally configuring it for use with <see cref="T:System.Drawing.Icon"></see> cell values.</summary>
		/// <param name="blnValueIsIcon">The cell will display an <see cref="T:System.Drawing.Icon"></see> value.</param>
		public DataGridViewImageCell(bool blnValueIsIcon)
			: this()
		{
			ValueIsIcon = blnValueIsIcon;
		}

		/// 
		/// Renders the cell text/value.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="objFormatedValue">The formated value.</param>
		protected override void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
		{
			base.RenderCellValue(objContext, objWriter, objFormatedValue);
			if (objFormatedValue == null)
			{
				return;
			}
			if (objFormatedValue is byte[])
			{
				GatewayReference gatewayReference = new GatewayReference(base.DataGridView, string.Format("cell{0}x{1}x{2}", base.ColumnIndex, base.RowIndex, "image"));
				objWriter.WriteAttributeString("IM", gatewayReference.ToString());
			}
			else if (objFormatedValue is ResourceHandle)
			{
				if (objFormatedValue is ResourceHandle resourceHandle)
				{
					objWriter.WriteAttributeString("IM", resourceHandle.ToString());
				}
			}
			else if (objFormatedValue is string && objFormatedValue != null && objFormatedValue.ToString() != string.Empty)
			{
				objWriter.WriteAttributeString("IM", objFormatedValue.ToString());
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="blnRenderOwner"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
		{
			base.RenderAttributes(objContext, objWriter, blnRenderOwner);
			switch (ImageLayout)
			{
			case DataGridViewImageCellLayout.Normal:
				objWriter.WriteAttributeString("IMS", Convert.ToInt32(PictureBoxSizeMode.Normal).ToString());
				break;
			case DataGridViewImageCellLayout.Stretch:
				objWriter.WriteAttributeString("IMS", Convert.ToInt32(PictureBoxSizeMode.StretchImage).ToString());
				break;
			}
		}

		/// Creates an exact copy of this cell.</summary>
		/// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCell"></see>.</returns>
		/// 1</filterpriority>
		public override object Clone()
		{
			Type type = GetType();
			DataGridViewImageCell dataGridViewImageCell = ((!(type == mobjCellType)) ? ((DataGridViewImageCell)Activator.CreateInstance(type)) : new DataGridViewImageCell());
			CloneInternal(dataGridViewImageCell);
			dataGridViewImageCell.Description = Description;
			dataGridViewImageCell.ImageLayout = ImageLayout;
			return dataGridViewImageCell;
		}

		/// Calculates the preferred size, in pixels, of the cell.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
		/// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
		/// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
		/// <param name="objConstraintSize">The cell's maximum allowable size.</param>
		/// <param name="intRowIndex">The zero-based row index of the cell.</param>
		protected override Size GetPreferredSize(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex, Size objConstraintSize)
		{
			return new Size(19, 20);
		}

		/// Returns a graphic as it would be displayed in the cell.</summary>
		/// An object that represents the formatted image.</returns>
		/// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell. </param>
		/// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values describing the context in which the formatted value is needed. </param>
		/// <param name="objValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the value type that provides custom conversion to the formatted value type, or null if no such custom conversion is needed.</param>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		/// <param name="objValue">The value to be formatted. </param>
		/// <param name="objFormattedValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the formatted value type that provides custom conversion from the value type, or null if no such custom conversion is needed.</param>
		protected override object GetFormattedValue(object objValue, int intRowIndex, ref DataGridViewCellStyle objCellStyle, TypeConverter objValueTypeConverter, TypeConverter objFormattedValueTypeConverter, DataGridViewDataErrorContexts enmContext)
		{
			object obj = null;
			if (objValue == null)
			{
				object obj2 = 1;
			}
			if ((enmContext & DataGridViewDataErrorContexts.ClipboardContent) != 0)
			{
				obj = Description;
			}
			else
			{
				object formattedValue = base.GetFormattedValue(objValue, intRowIndex, ref objCellStyle, objValueTypeConverter, objFormattedValueTypeConverter, enmContext);
				if (formattedValue == null && objCellStyle.NullValue == null)
				{
					obj = null;
				}
				else if (formattedValue is Icon)
				{
					obj = formattedValue as Icon;
					if (obj == null)
					{
						obj = ErrorIcon;
					}
				}
				else if (formattedValue is ResourceHandle)
				{
					obj = formattedValue as ResourceHandle;
					if (obj == null)
					{
						obj = ErrorBitmap;
					}
				}
				else if (formattedValue is string && formattedValue != null && formattedValue.ToString() != string.Empty)
				{
					obj = formattedValue.ToString();
				}
			}
			return obj;
		}

		/// 
		/// Gets the value of the cell.
		/// </summary>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		/// 
		/// The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.
		/// </returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
		/// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> property is less than 0, indicating that the cell is a row header cell.</exception>
		protected override object GetValue(int intRowIndex)
		{
			object value = base.GetValue(intRowIndex);
			if (value == null)
			{
				if (!(base.OwningColumn is DataGridViewImageColumn dataGridViewImageColumn))
				{
					return value;
				}
				if (mobjDefaultTypeImage.IsAssignableFrom(ValueType))
				{
					ResourceHandle image = dataGridViewImageColumn.Image;
					if (image != null)
					{
						return image;
					}
					return value;
				}
				if (mobjDefaultTypeIcon.IsAssignableFrom(ValueType))
				{
					ResourceHandle icon = dataGridViewImageColumn.Icon;
					if (icon != null)
					{
						return icon;
					}
				}
			}
			return value;
		}

		/// 
		/// Returns a string that describes the current object.
		/// </summary>
		/// 
		/// A string that represents the current object.
		/// </returns>
		public override string ToString()
		{
			return null;
		}
	}
}
