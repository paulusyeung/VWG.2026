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
	/// Base User Control contained by the Exptended Header Cell
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	[TypeConverter(typeof(ExtendedHeaderUserControlTypeConverter))]
	public class ExtendedHeaderUserControl : UserControl
	{
		private int mintColSpan = 1;

		private int mintColIndex;

		private int mintRowSpan = 1;

		private int mintRowIndex;

		private DataGridView mobjParentDataGrid;

		private ExtendedHeaderCellType menmExtendedHeaderCellType;

		/// 
		/// Gets or sets the type of the extended panel.
		/// </summary>
		/// 
		/// The type of the extended panel.
		/// </value>
		[DefaultValue(ExtendedHeaderCellType.Headers)]
		[Category("Header layout")]
		public ExtendedHeaderCellType ExtendedHeaderCellType
		{
			get
			{
				return menmExtendedHeaderCellType;
			}
			set
			{
				if (menmExtendedHeaderCellType != value)
				{
					menmExtendedHeaderCellType = value;
					UpdateGrid();
				}
			}
		}

		/// 
		/// Gets or sets the index of the row.
		/// </summary>
		/// 
		/// The index of the row.
		/// </value>
		[Category("Header layout")]
		[DefaultValue(0)]
		public int RowIndex
		{
			get
			{
				return mintRowIndex;
			}
			set
			{
				mintRowIndex = value;
			}
		}

		/// 
		/// Gets or sets the row span.
		/// </summary>
		/// 
		/// The row span.
		/// </value>
		[Category("Header layout")]
		[DefaultValue(1)]
		public int RowSpan
		{
			get
			{
				return mintRowSpan;
			}
			set
			{
				if (mintRowSpan != value)
				{
					mintRowSpan = value;
					UpdateGrid();
				}
			}
		}

		/// 
		/// Gets or sets the index of the column.
		/// </summary>
		/// 
		/// The index of the col.
		/// </value>
		[Category("Header layout")]
		[DefaultValue(0)]
		public int ColIndex
		{
			get
			{
				return mintColIndex;
			}
			set
			{
				mintColIndex = value;
			}
		}

		/// 
		/// Gets or sets the col span.
		/// </summary>
		/// 
		/// The col span.
		/// </value>
		[Category("Header layout")]
		[DefaultValue(1)]
		public int ColSpan
		{
			get
			{
				return mintColSpan;
			}
			set
			{
				if (mintColSpan != value)
				{
					mintColSpan = value;
					UpdateGrid();
				}
			}
		}

		/// 
		/// Gets controls docking style as Fill 
		/// </summary>
		public override DockStyle Dock
		{
			get
			{
				return DockStyle.Fill;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets the parent grid.
		/// </summary>
		/// 
		/// The parent grid.
		/// </value>
		[Browsable(false)]
		internal DataGridView ParentGrid
		{
			get
			{
				return mobjParentDataGrid;
			}
			set
			{
				mobjParentDataGrid = value;
			}
		}

		/// 
		/// Checks if the current control needs rendering and
		/// continues to process sub tree/
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected internal override void RenderControl(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			int num = UnvisibleContainingColumnsCount();
			if (mintColSpan > num || ExtendedHeaderCellType != ExtendedHeaderCellType.Headers)
			{
				base.RenderControl(objContext, objWriter, lngRequestID);
			}
		}

		/// 
		/// Get the number of unvisible columns position in the column range of the user control's extended header
		/// </summary>
		/// </returns>
		private int UnvisibleContainingColumnsCount()
		{
			int num = 0;
			for (int i = ColIndex; i < ColIndex + mintColSpan; i++)
			{
				if (!ParentGrid.Columns[i].Visible)
				{
					num++;
				}
			}
			return num;
		}

		/// 
		/// Get the number of unvisible columns position before the user control's column index.
		/// </summary>
		/// </returns>
		private int UnvisiblePrecedingColumnsCount()
		{
			int num = 0;
			for (int i = 0; i < ColIndex; i++)
			{
				if (!ParentGrid.Columns[i].Visible)
				{
					num++;
				}
			}
			return num;
		}

		/// 
		/// Renders the attributes.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			if (ExtendedHeaderCellType != ExtendedHeaderCellType.Headers)
			{
				objWriter.WriteAttributeString("EPT", ((int)ExtendedHeaderCellType).ToString());
			}
			else
			{
				int num = UnvisiblePrecedingColumnsCount();
				int num2 = UnvisibleContainingColumnsCount();
				if (mintColSpan > 1)
				{
					objWriter.WriteAttributeString("CSP", (mintColSpan - num2).ToString());
				}
				objWriter.WriteAttributeString("CIX", (ColIndex - num).ToString());
			}
			if (mintRowSpan > 1)
			{
				objWriter.WriteAttributeString("RSP", mintRowSpan.ToString());
			}
			objWriter.WriteAttributeString("RIX", mintRowIndex.ToString());
		}

		/// 
		/// Updates the grid.
		/// </summary>
		protected void UpdateGrid()
		{
			if (mobjParentDataGrid != null)
			{
				mobjParentDataGrid.Update();
			}
		}
	}
}
