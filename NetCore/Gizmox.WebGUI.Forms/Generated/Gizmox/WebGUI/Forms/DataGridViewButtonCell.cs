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
/// Displays a button-like user interface (UI) for use in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
	/// 2</filterpriority>
	[Serializable]
	[Skin(typeof(DataGridViewButtonCellSkin))]
	public class DataGridViewButtonCell : DataGridViewCell
	{
		private const byte DATAGRIDVIEWBUTTONCELL_horizontalTextMargin = 2;

		private const byte DATAGRIDVIEWBUTTONCELL_textPadding = 5;

		private const byte DATAGRIDVIEWBUTTONCELL_themeMargin = 100;

		private const byte DATAGRIDVIEWBUTTONCELL_verticalTextMargin = 1;

		private static Type mobjDefaultFormattedValueType;

		private static Type mobjDefaultValueType;

		private static Type mobjCellType;

		private static Rectangle mobjRectangleThemeMargins;

		private int mintUseColumnTextForButtonValue = 0;

		/// Gets the type of the cell's hosted editing control.</summary>
		/// The <see cref="T:System.Type"></see> of the underlying editing control.</returns>
		/// 1</filterpriority>
		public override Type EditType => null;

		/// Gets or sets the style determining the button's appearance.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> value. </exception>
		/// 1</filterpriority>
		[DefaultValue(2)]
		public FlatStyle FlatStyle
		{
			get
			{
				return FlatStyle.Standard;
			}
			set
			{
			}
		}

		/// Gets or sets a value indicating whether the owning column's text will appear on the button displayed by the cell.</summary>
		/// true if the value of the <see cref="P:System.Windows.Forms.DataGridViewCell.Value"></see> property will automatically match the value of the <see cref="P:System.Windows.Forms.DataGridViewButtonColumn.Text"></see> property of the owning column; otherwise, false. The default is false.</returns>
		[DefaultValue(false)]
		public bool UseColumnTextForButtonValue
		{
			get
			{
				return mintUseColumnTextForButtonValue != 0;
			}
			set
			{
				if (value != UseColumnTextForButtonValue)
				{
					mintUseColumnTextForButtonValue = (value ? 1 : 0);
					OnCommonChange();
				}
			}
		}

		internal bool UseColumnTextForButtonValueInternal
		{
			set
			{
				if (value != UseColumnTextForButtonValue)
				{
					mintUseColumnTextForButtonValue = (value ? 1 : 0);
				}
			}
		}

		/// 
		/// Gets the type of the formatted value associated with the cell.
		/// </summary>
		/// </value>
		/// A <see cref="T:System.Type"></see> representing the type of the cell's formatted value.</returns>
		public override Type FormattedValueType => mobjDefaultFormattedValueType;

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
				return null;
			}
		}

		static DataGridViewButtonCell()
		{
			mobjRectangleThemeMargins = new Rectangle(-1, -1, 0, 0);
			mobjDefaultFormattedValueType = typeof(string);
			mobjDefaultValueType = typeof(object);
			mobjCellType = typeof(DataGridViewButtonCell);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonCell" /> class.
		/// </summary>
		public DataGridViewButtonCell()
		{
		}

		/// Indicates whether a row is unshared if a key is pressed while the focus is on a cell in the row.</summary>
		/// true if the user pressed the SPACE key without modifier keys; otherwise, false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		protected override bool KeyDownUnsharesRow(KeyEventArgs e, int intRowIndex)
		{
			if (e.KeyCode == Keys.Space && !e.Alt && !e.Control)
			{
				return !e.Shift;
			}
			return false;
		}

		/// Indicates whether a row is unshared when a key is released while the focus is on a cell in the row.</summary>
		/// true if the user released the SPACE key; otherwise, false.</returns>
		/// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
		/// <param name="intRowIndex">The index of the cell's parent row. </param>
		protected override bool KeyUpUnsharesRow(KeyEventArgs e, int intRowIndex)
		{
			return e.KeyCode == Keys.Space;
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
			if (objFormatedValue != null && objFormatedValue.ToString() != string.Empty)
			{
				objWriter.WriteAttributeText("TX", objFormatedValue.ToString());
			}
		}

		/// 
		/// Renders the cell style attributes.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="objCellStyle">The cell style.</param>
		protected override void RenderCellStyleAttributes(IAttributeWriter objWriter, DataGridViewCellStyle objCellStyle)
		{
			base.RenderCellStyleAttributes(objWriter, objCellStyle);
			if (objCellStyle != null)
			{
				objWriter.WriteAttributeString("TA", objCellStyle.Alignment.ToString());
			}
		}

		/// Retrieves the text associated with the button.</summary>
		/// The value of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonCell"></see> or the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewButtonColumn.Text"></see> value of the owning column if <see cref="P:Gizmox.WebGUI.Forms.DataGridViewButtonCell.UseColumnTextForButtonValue"></see> is true. </returns>
		/// <param name="intRowIndex">The index of the cell's parent row.</param>
		protected override object GetValue(int intRowIndex)
		{
			if (UseColumnTextForButtonValue && base.DataGridView != null && base.DataGridView.NewRowIndex != intRowIndex && base.OwningColumn != null && base.OwningColumn is DataGridViewButtonColumn)
			{
				return ((DataGridViewButtonColumn)base.OwningColumn).Text;
			}
			return base.GetValue(intRowIndex);
		}

		/// Creates an exact copy of this cell.</summary>
		/// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:System.Windows.Forms.DataGridViewButtonCell"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public override object Clone()
		{
			Type type = GetType();
			DataGridViewButtonCell dataGridViewButtonCell = ((!(type == mobjCellType)) ? ((DataGridViewButtonCell)Activator.CreateInstance(type)) : new DataGridViewButtonCell());
			CloneInternal(dataGridViewButtonCell);
			dataGridViewButtonCell.UseColumnTextForButtonValueInternal = UseColumnTextForButtonValue;
			return dataGridViewButtonCell;
		}

		/// Calculates the preferred size, in pixels, of the cell.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
		/// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
		/// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
		/// <param name="objConstraintSize">The cell's maximum allowable size.</param>
		/// <param name="intRowIndex">The zero-based row index of the cell.</param>
		protected override Size GetPreferredSize(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex, Size objConstraintSize)
		{
			Size preferredSize = base.GetPreferredSize(Convert.ToString(GetValue(intRowIndex)), objCellStyle);
			return new Size(preferredSize.Width + 8, preferredSize.Height + 5);
		}

		/// Returns the string representation of the cell.</summary>
		/// A <see cref="T:System.String"></see> that represents the current cell.</returns>
		/// 1</filterpriority>
		public override string ToString()
		{
			return "DataGridViewButtonCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + base.RowIndex.ToString(CultureInfo.CurrentCulture) + " }";
		}
	}
}
