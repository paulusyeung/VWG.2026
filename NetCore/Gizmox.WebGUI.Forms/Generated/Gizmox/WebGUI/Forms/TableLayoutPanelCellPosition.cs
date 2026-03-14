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
	/// Represents a cell in a TableLayoutPanel.
	/// </summary>
	[Serializable]
	[TypeConverter(typeof(TableLayoutPanelCellPositionTypeConverter))]
	public struct TableLayoutPanelCellPosition
	{
		private int mintRow;

		private int mintColumn;

		/// 
		/// Gets or sets the row number of the current TableLayoutPanelCellPosition.
		/// </summary>
		/// The row.</value>
		public int Row
		{
			get
			{
				return mintRow;
			}
			set
			{
				mintRow = value;
			}
		}

		/// 
		/// Gets or sets the column number of the current TableLayoutPanelCellPosition.
		/// </summary>
		/// The column.</value>
		public int Column
		{
			get
			{
				return mintColumn;
			}
			set
			{
				mintColumn = value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TableLayoutPanelCellPosition" /> struct.
		/// </summary>
		/// <param name="intColumn">The column.</param>
		/// <param name="intRow">The row.</param>
		public TableLayoutPanelCellPosition(int intColumn, int intRow)
		{
			if (intRow < -1)
			{
				throw new ArgumentOutOfRangeException("row", SR.GetString("InvalidArgument", "row", intRow.ToString(CultureInfo.CurrentCulture)));
			}
			if (intColumn < -1)
			{
				throw new ArgumentOutOfRangeException("column", SR.GetString("InvalidArgument", "column", intColumn.ToString(CultureInfo.CurrentCulture)));
			}
			mintRow = intRow;
			mintColumn = intColumn;
		}

		/// 
		/// Specifies whether this TableLayoutPanelCellPosition contains the same row and column as the specified TableLayoutPanelCellPosition.
		/// </summary>
		/// <param name="objOther">The other.</param>
		/// </returns>
		public override bool Equals(object objOther)
		{
			if (objOther is TableLayoutPanelCellPosition tableLayoutPanelCellPosition && tableLayoutPanelCellPosition.mintRow == mintRow)
			{
				return tableLayoutPanelCellPosition.mintColumn == mintColumn;
			}
			return false;
		}

		/// 
		/// Implements the operator ==.
		/// </summary>
		/// <param name="objPos1">The p1.</param>
		/// <param name="objPos2">The p2.</param>
		/// The result of the operator.</returns>
		public static bool operator ==(TableLayoutPanelCellPosition objPos1, TableLayoutPanelCellPosition objPos2)
		{
			if (objPos1.Row == objPos2.Row)
			{
				return objPos1.Column == objPos2.Column;
			}
			return false;
		}

		/// 
		/// Implements the operator !=.
		/// </summary>
		/// <param name="objPos1">The p1.</param>
		/// <param name="objPos2">The p2.</param>
		/// The result of the operator.</returns>
		public static bool operator !=(TableLayoutPanelCellPosition objPos1, TableLayoutPanelCellPosition objPos2)
		{
			return objPos1 != objPos2;
		}

		/// 
		/// Returns the fully qualified type name of this instance.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> containing a fully qualified type name.
		/// </returns>
		public override string ToString()
		{
			return Column.ToString(CultureInfo.CurrentCulture) + "," + Row.ToString(CultureInfo.CurrentCulture);
		}

		/// 
		/// Returns the hash code for this instance.
		/// </summary>
		/// 
		/// A 32-bit signed integer that is the hash code for this instance.
		/// </returns>
		public override int GetHashCode()
		{
			return CommonUtils.GetCombinedHashCodes(mintRow, mintColumn);
		}
	}
}
