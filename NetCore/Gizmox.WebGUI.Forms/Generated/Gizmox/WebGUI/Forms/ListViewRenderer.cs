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
	/// Provides support for rendering a ListView control  
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ListViewRenderer : ControlRenderer
	{
		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ListViewRenderer" /> class.
		/// </summary>
		/// <param name="objListView">The ListView control.</param>
		public ListViewRenderer(ListView objListView)
			: base(objListView)
		{
		}

		/// 
		/// Renders the content.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objGraphics">The graphics.</param>
		protected override void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
		{
			if (base.Control is ListView { View: View.Details } listView)
			{
				RenderDetailsViewContent(objContext, objGraphics, listView);
			}
		}

		/// 
		/// Renders the content of the details view.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objGraphics">The graphics.</param>
		private void RenderDetailsViewContent(ControlRenderingContext objContext, Graphics objGraphics, ListView objListView)
		{
			Rectangle rectangle = ControlRenderer.GetContentRegion(objListView);
			if (!(objListView.Skin is ListViewSkin objListViewSkin))
			{
				return;
			}
			ListView.ColumnHeaderCollection columns = objListView.Columns;
			if (columns == null)
			{
				return;
			}
			if (objListView.HeaderStyle != ColumnHeaderStyle.None)
			{
				rectangle = ControlRenderer.DockInRegion(rectangle, DockStyle.Top, RenderHeaders(objContext, objGraphics, objListViewSkin, objListView, columns, rectangle));
				if (!ControlRenderer.IsVisibleRegion(rectangle))
				{
					return;
				}
			}
			foreach (ListViewItem item in objListView.Items)
			{
				rectangle = ControlRenderer.DockInRegion(rectangle, DockStyle.Top, RenderDetailsItem(objContext, objGraphics, objListViewSkin, objListView, item, columns, rectangle));
				if (!ControlRenderer.IsVisibleRegion(rectangle))
				{
					break;
				}
			}
		}

		/// 
		/// Renders the details item.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objListViewSkin">The list view skin.</param>
		/// <param name="objListView">The list view.</param>
		/// <param name="objListViewItem">The list view item.</param>
		/// <param name="objColumns">The columns.</param>
		/// <param name="objContentRegion">The content region.</param>
		/// </returns>
		private Rectangle RenderDetailsItem(ControlRenderingContext objContext, Graphics objGraphics, ListViewSkin objListViewSkin, ListView objListView, ListViewItem objListViewItem, ListView.ColumnHeaderCollection objColumns, Rectangle objContentRegion)
		{
			int height = 20;
			Rectangle rectangle = new Rectangle(objContentRegion.Location, new Size(objContentRegion.Width, height));
			int num = 0;
			foreach (ListViewItem.ListViewSubItem subItem in objListViewItem.SubItems)
			{
				if (objColumns.Count > num)
				{
					rectangle = ControlRenderer.DockInRegion(rectangle, DockStyle.Left, RenderDetailsSubItem(objContext, objGraphics, objListViewSkin, objListView, objColumns[num], subItem, rectangle));
				}
				num++;
			}
			return new Rectangle(objContentRegion.Location, new Size(objContentRegion.Width, height));
		}

		/// 
		/// Renders the details sub item.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objListViewSkin">The list view skin.</param>
		/// <param name="objListView">The list view.</param>
		/// <param name="objColumnHeader">The column header.</param>
		/// <param name="objSubItem">The sub item.</param>
		/// <param name="objItemsRegion">The items region.</param>
		/// </returns>
		private Rectangle RenderDetailsSubItem(ControlRenderingContext objContext, Graphics objGraphics, ListViewSkin objListViewSkin, ListView objListView, ColumnHeader objColumnHeader, ListViewItem.ListViewSubItem objSubItem, Rectangle objItemsRegion)
		{
			Rectangle rectangle = new Rectangle(objItemsRegion.Location, new Size(objColumnHeader.Width, objItemsRegion.Height));
			StyleValue cellNormalStyle = objListViewSkin.CellNormalStyle;
			ControlRenderer.RenderStyle(objContext, objGraphics, objListViewSkin, cellNormalStyle, rectangle);
			if (objColumnHeader.Type == ListViewColumnType.Text)
			{
				ControlRenderer.RenderText(objContext, objGraphics, objSubItem.Text, cellNormalStyle.Font, cellNormalStyle.ForeColor, rectangle, ContentAlignment.MiddleLeft, blnWrapText: false);
			}
			return rectangle;
		}

		/// 
		/// Renders the headers.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objListViewSkin">The list view skin.</param>
		/// <param name="objListView">The list view.</param>
		/// <param name="objColumns">The columns.</param>
		/// <param name="objContentRegion">The content region.</param>
		/// </returns>
		private Rectangle RenderHeaders(ControlRenderingContext objContext, Graphics objGraphics, ListViewSkin objListViewSkin, ListView objListView, ListView.ColumnHeaderCollection objColumns, Rectangle objContentRegion)
		{
			int headerHeight = objListViewSkin.HeaderHeight;
			Rectangle rectangle = new Rectangle(objContentRegion.Location, new Size(objContentRegion.Width, headerHeight));
			foreach (ColumnHeader objColumn in objColumns)
			{
				rectangle = ControlRenderer.DockInRegion(rectangle, DockStyle.Left, RenderHeader(objContext, objGraphics, objListViewSkin, objListView, objColumn, rectangle));
			}
			return new Rectangle(objContentRegion.Location, new Size(objContentRegion.Width, headerHeight));
		}

		/// 
		/// Renders the headers.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objListViewSkin">The list view skin.</param>
		/// <param name="objListView">The list view.</param>
		/// <param name="objColumnHeader">The column header.</param>
		/// </returns>
		private Rectangle RenderHeader(ControlRenderingContext objContext, Graphics objGraphics, ListViewSkin objListViewSkin, ListView objListView, ColumnHeader objColumnHeader, Rectangle objHeadersRegion)
		{
			Rectangle rectangle = new Rectangle(objHeadersRegion.Location, new Size(objColumnHeader.Width, objHeadersRegion.Height));
			StyleValue headerNormalStyle = objListViewSkin.HeaderNormalStyle;
			ControlRenderer.RenderStyle(objContext, objGraphics, objListViewSkin, headerNormalStyle, rectangle);
			ControlRenderer.RenderText(objContext, objGraphics, objColumnHeader.Text, headerNormalStyle.Font, headerNormalStyle.ForeColor, rectangle, ContentAlignment.MiddleCenter, blnWrapText: false);
			return rectangle;
		}
	}
}
