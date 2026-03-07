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
	/// A DataGridViewHeaderFilterComboBox control
	/// </summary>
	[Serializable]
	[Skin(typeof(DataGridViewHeaderFilterComboBoxSkin))]
	[ToolboxItem(false)]
	public class DataGridViewHeaderFilterComboBox : DataGridViewFilterComboBoxBase
	{
		private bool mblnIsCustomFilter = false;

		/// 
		/// Gets or sets a value indicating whether this instance is custom filter.
		/// </summary>
		/// 
		/// 	true</c> if this instance is custom filter; otherwise, false</c>.
		/// </value>
		public bool IsCustomFilter
		{
			get
			{
				return mblnIsCustomFilter;
			}
			set
			{
				if (mblnIsCustomFilter != value)
				{
					mblnIsCustomFilter = value;
					Update();
				}
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
				if (base.OwningCell is DataGridViewColumnHeaderCell { DataGridView: { RootGrid: var rootGrid } dataGridView })
				{
					if (rootGrid != null)
					{
						return rootGrid.BindingContext;
					}
					return dataGridView.BindingContext;
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
		public override Form Form
		{
			get
			{
				if (base.OwningDataGridView != null)
				{
					return base.OwningDataGridView.Form;
				}
				return base.Form;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderFilterComboBox" /> class.
		/// </summary>
		/// <param name="objOwnerCell">The obj owner cell.</param>
		public DataGridViewHeaderFilterComboBox(DataGridViewColumnHeaderCell objOwnerCell)
			: base(objOwnerCell.DataGridView, objOwnerCell.OwningColumn, objOwnerCell)
		{
			CustomStyle = "DataGridViewHeaderFilterComboBoxSkin";
			base.DropDownWidth = base.OwningColumn.Width;
		}

		/// 
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			RenderIsCustomFilterAttribute(objWriter);
		}

		/// 
		/// Renders the options.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnUseCode">if set to true</c> [BLN use code].</param>
		/// <param name="blnShouldRenderItemImage">if set to true</c> [BLN should render item image].</param>
		/// <param name="blnShouldRenderItemColor">if set to true</c> [BLN should render item color].</param>
		/// <param name="blnUseIndexCode">if set to true</c> [BLN use index code].</param>
		/// <param name="objUseCodeProp">The obj use code prop.</param>
		protected override void RenderOptions(IResponseWriter objWriter, bool blnUseCode, bool blnShouldRenderItemImage, bool blnShouldRenderItemColor, bool blnUseIndexCode, PropertyInfo objUseCodeProp)
		{
			if (!mblnIsCustomFilter)
			{
				base.RenderOptions(objWriter, blnUseCode, blnShouldRenderItemImage, blnShouldRenderItemColor, blnUseIndexCode, objUseCodeProp);
			}
		}

		/// 
		/// Renders the is custom filter attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderIsCustomFilterAttribute(IAttributeWriter objWriter)
		{
			if (IsCustomFilter)
			{
				objWriter.WriteAttributeString("ICF", "1");
			}
		}

		/// 
		/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click" />
		/// event.
		/// </summary>
		/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected override void OnClick(EventArgs objEventArgs)
		{
			base.OnClick(objEventArgs);
			OnCustomHeaderFilterClicked();
		}

		/// 
		/// Called when [custom header filter clicked].
		/// </summary>
		private void OnCustomHeaderFilterClicked()
		{
			if (mblnIsCustomFilter)
			{
				base.OwningDataGridView.OnCustomHeaderFilterClicked(new CustomFilterApplyingEventArgs(base.OwningColumn));
			}
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (mblnIsCustomFilter)
			{
				criticalEventsData.Set("CL");
			}
			return criticalEventsData;
		}

		/// 
		/// Initializes the filter values.
		/// </summary>
		/// <param name="blnAddSystemFilterOptions">if set to true</c> [BLN add system filter options].</param>
		/// <param name="blnCalculateDropDownWidth">if set to true</c> [BLN set drop down width].</param>
		/// <param name="blnClearBindingSourceFilter">if set to true</c> [BLN clear binding source filter].</param>
		public override void InitializeFilterValues(bool blnAddSystemFilterOptions, bool blnCalculateDropDownWidth, bool blnClearBindingSourceFilter)
		{
			base.InitializeFilterValues(blnAddSystemFilterOptions, blnCalculateDropDownWidth && !IsCustomFilter, blnClearBindingSourceFilter);
		}

		/// 
		/// Updates the width of the drop down.
		/// </summary>
		/// <param name="intMaxWidth">Width of the int max.</param>
		protected override void UpdateDropDownWidth(int intMaxWidth)
		{
			if (base.Skin is DataGridViewHeaderFilterComboBoxSkin dataGridViewHeaderFilterComboBoxSkin)
			{
				intMaxWidth += dataGridViewHeaderFilterComboBoxSkin.DropDownWidthSpacer;
			}
			base.UpdateDropDownWidth(intMaxWidth);
		}
	}
}
