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
/// Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.SortCompare"></see> event.</summary>
	[Serializable]
	public class DataGridViewSortCompareEventArgs : HandledEventArgs
	{
		private object mobjCellValue1;

		private object mobjCellValue2;

		private DataGridViewColumn mobjDataGridViewColumn;

		private int mintRowIndex1;

		private int mintRowIndex2;

		private int mintSortResult;

		/// Gets the value of the first cell to compare.</summary>
		/// The value of the first cell.</returns>
		public object CellValue1 => mobjCellValue1;

		/// Gets the value of the second cell to compare.</summary>
		/// The value of the second cell.</returns>
		public object CellValue2 => mobjCellValue2;

		/// Gets the column being sorted. </summary>
		/// The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to sort.</returns>
		public DataGridViewColumn Column => mobjDataGridViewColumn;

		/// Gets the index of the row containing the first cell to compare.</summary>
		/// The index of the row containing the second cell.</returns>
		public int RowIndex1 => mintRowIndex1;

		/// Gets the index of the row containing the second cell to compare.</summary>
		/// The index of the row containing the second cell.</returns>
		public int RowIndex2 => mintRowIndex2;

		/// Gets or sets a value indicating the order in which the compared cells will be sorted.</summary>
		/// Less than zero if the first cell will be sorted before the second cell; zero if the first cell and second cell have equivalent values; greater than zero if the second cell will be sorted before the first cell.</returns>
		public int SortResult
		{
			get
			{
				return mintSortResult;
			}
			set
			{
				mintSortResult = value;
			}
		}

		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSortCompareEventArgs"></see> class.</summary>
		/// <param name="objCellValue2">The value of the second cell to compare.</param>
		/// <param name="objDataGridViewColumn">The column to sort.</param>
		/// <param name="intRowIndex2">The index of the row containing the second cell.</param>
		/// <param name="objCellValue1">The value of the first cell to compare.</param>
		/// <param name="intRowIndex1">The index of the row containing the first cell.</param>
		public DataGridViewSortCompareEventArgs(DataGridViewColumn objDataGridViewColumn, object objCellValue1, object objCellValue2, int intRowIndex1, int intRowIndex2)
		{
			mobjDataGridViewColumn = objDataGridViewColumn;
			mobjCellValue1 = objCellValue1;
			mobjCellValue2 = objCellValue2;
			mintRowIndex1 = intRowIndex1;
			mintRowIndex2 = intRowIndex2;
		}
	}
}
