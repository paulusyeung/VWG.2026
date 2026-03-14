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
	///
	/// </summary>
	[Serializable]
	[ToolboxItem(false)]
	[Skin(typeof(DataGridViewCellPanelSkin))]
	public class DataGridViewCellPanel : Panel
	{
		private int mintColspan = 0;

		private int mintRowspan = 0;

		private DataGridViewCell mobjOwnerCell;

		/// 
		/// Gets or sets the control custom style.
		/// </summary>
		/// The custom style.</value>
		/// </remarks>
		public override string CustomStyle
		{
			get
			{
				return "DataGridViewCellPanel";
			}
			set
			{
				base.CustomStyle = value;
			}
		}

		/// 
		/// Gets or sets the collection of currency managers for the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.
		/// </summary>
		/// The collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</returns>
		public override BindingContext BindingContext
		{
			get
			{
				DataGridViewCell ownerCell = OwnerCell;
				if (ownerCell != null)
				{
					DataGridView dataGridView = ownerCell.DataGridView;
					if (dataGridView != null)
					{
						DataGridView rootGrid = dataGridView.RootGrid;
						if (rootGrid != null)
						{
							return rootGrid.BindingContext;
						}
						return dataGridView.BindingContext;
					}
				}
				return base.BindingContext;
			}
			set
			{
			}
		}

		/// 
		/// Gets the owner form.
		/// </summary>
		/// </value>
		public override Form Form
		{
			get
			{
				DataGridViewCell ownerCell = OwnerCell;
				if (ownerCell != null)
				{
					DataGridView dataGridView = ownerCell.DataGridView;
					if (dataGridView != null)
					{
						return dataGridView.Form;
					}
				}
				return base.Form;
			}
		}

		/// 
		/// Gets or sets the coll span.
		/// </summary>
		/// The coll span.</value>
		internal int Colspan
		{
			get
			{
				return mintColspan;
			}
			set
			{
				if (mintColspan != value)
				{
					mintColspan = value;
					UpdateDataGridView();
				}
			}
		}

		/// 
		/// Gets or sets the owner.
		/// </summary>
		/// The owner.</value>
		public DataGridViewCell OwnerCell => mobjOwnerCell;

		/// 
		/// Gets or sets the row span.
		/// </summary>
		/// The row span.</value>
		internal int Rowspan
		{
			get
			{
				return mintRowspan;
			}
			set
			{
				if (mintRowspan != value)
				{
					mintRowspan = value;
					UpdateDataGridView();
				}
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellPanel" /> class.
		/// </summary>
		/// <param name="objOwner">The obj owner.</param>
		public DataGridViewCellPanel(DataGridViewCell objOwner)
		{
			mobjOwnerCell = objOwner;
		}

		/// 
		/// Updates the data grid view.
		/// </summary>
		private void UpdateDataGridView()
		{
			DataGridViewCell ownerCell = OwnerCell;
			if (ownerCell != null)
			{
				ValidatePanelLayout(ownerCell);
				ownerCell.DataGridView?.Update();
			}
		}

		/// 
		/// Validates the panel layout.
		/// </summary>
		/// <param name="objOwnerCell">The owner cell.</param>
		private void ValidatePanelLayout(DataGridViewCell objOwnerCell)
		{
			if (objOwnerCell == null)
			{
				return;
			}
			DataGridView dataGridView = objOwnerCell.DataGridView;
			if (dataGridView == null)
			{
				return;
			}
			int num = Rowspan;
			if (num > 1)
			{
				DataGridViewRow owningRow = objOwnerCell.OwningRow;
				if (owningRow != null)
				{
					bool frozen = owningRow.Frozen;
					int num2 = owningRow.Index;
					bool useInternalPaging = dataGridView.UseInternalPaging;
					IList list = null;
					while (num2 >= 0 && num > 1)
					{
						num2 = dataGridView.Rows.GetNextRow(num2, DataGridViewElementStates.Visible);
						if (num2 >= 0)
						{
							DataGridViewRow dataGridViewRow = dataGridView.Rows[num2];
							if (dataGridViewRow == null)
							{
								throw new ArgumentOutOfRangeException("Rowspan");
							}
							if (useInternalPaging)
							{
								if (list == null)
								{
									list = dataGridView.PageRows;
								}
								if (!list.Contains(dataGridViewRow))
								{
									throw new InvalidOperationException("Cell's panel cannot be spread over several pages.");
								}
							}
							if (dataGridViewRow.Frozen != frozen)
							{
								throw new InvalidOperationException("Cell's panel cannot be partially frozen.");
							}
						}
						num--;
					}
				}
			}
			int num3 = Colspan;
			if (num3 <= 1)
			{
				return;
			}
			DataGridViewColumn owningColumn = objOwnerCell.OwningColumn;
			if (owningColumn == null)
			{
				return;
			}
			bool frozen2 = owningColumn.Frozen;
			DataGridViewColumn dataGridViewColumn = owningColumn;
			while (dataGridViewColumn != null && num3 > 1)
			{
				dataGridViewColumn = dataGridView.Columns.GetNextColumn(dataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
				if (dataGridViewColumn != null)
				{
					if (dataGridViewColumn.Frozen != frozen2)
					{
						throw new InvalidOperationException("Cell's panel cannot be partially frozen.");
					}
					num3--;
					continue;
				}
				throw new ArgumentOutOfRangeException("Colpan");
			}
		}

		/// 
		/// An abstract control method rendering
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			ValidatePanelLayout(OwnerCell);
			base.Render(objContext, objWriter, lngRequestID);
		}

		/// 
		/// Renders the docking.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="enmDockStyle">The dock style.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		protected override void RenderDocking(IContext objContext, IAttributeWriter objWriter, DockStyle enmDockStyle, bool blnForceRender)
		{
			objWriter.WriteAttributeString("D", "F");
		}

		/// 
		/// Renders the anchoring.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		/// <param name="enmAnchorStyle">The anchor style.</param>
		/// <param name="blnForceEmptyRender">if set to true</c> [BLN force empty render].</param>
		protected override void RenderAnchoring(IContext objContext, IAttributeWriter objWriter, AnchorStyles enmAnchorStyle, bool blnForceEmptyRender)
		{
		}

		/// 
		/// Renders the scrollable attribute
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			int colspan = Colspan;
			if (colspan > 0)
			{
				objWriter.WriteAttributeString("CSP", colspan.ToString());
			}
			int rowspan = Rowspan;
			if (rowspan > 0)
			{
				objWriter.WriteAttributeString("RSP", rowspan.ToString());
			}
		}

		/// 
		/// Gets the key event captures for DataGridViewCellPanel.
		/// The DataGridViewCellPanel is a "stopper" for all key events to prevent the DataGrid from handling these events
		/// </summary>
		/// </returns>
		protected override KeyCaptures GetKeyEventCaptures()
		{
			return KeyCaptures.All;
		}

		/// 
		/// Prerender component.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="lngRequestID">The request ID.</param>
		internal void PreRenderComponent(IContext objContext, long lngRequestID)
		{
			PreRenderControl(objContext, lngRequestID);
		}
	}
}
