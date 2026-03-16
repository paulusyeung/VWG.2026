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
	[VisualTemplate(typeof(DataGridView), "Visually adjusts the DataGridView control to an appearance more suitable for the customized device.")]
	[Skin(typeof(DataGridViewMobileVisualTemplateSkin))]
	public class DataGridViewMobileVisualTemplate : VisualTemplate
	{
		private int mintNumberOfDisplayedColumns = 3;

		private string mstrNewColumnOrder = null;

		private int mintCaptionHeight = 0;

		private int? mintCalculatedCaptionHeight = null;

		private int mintBottomMenuHeight = 0;

		private int? mintCalculatedBottomMenuHeight = null;

		private List<string> mobjFilterOperators = null;

		/// 
		/// Gets or sets the new column order.
		/// </summary>
		/// 
		/// The new column order.
		/// </value>
		public string NewColumnOrder
		{
			get
			{
				return mstrNewColumnOrder;
			}
			set
			{
				mstrNewColumnOrder = value;
			}
		}

		/// 
		/// Gets the name of the visual template.
		/// </summary>
		/// 
		/// The name of the visual template.
		/// </value>
		public override string VisualTemplateName => "DataGridViewVisualTemplateForMobile";

		/// 
		/// Gets the visualizer image.
		/// </summary>
		/// 
		/// The visualizer image.
		/// </value>
		public override ResourceHandle VisualizerImage => new SkinResourceHandle(typeof(TreeViewVisualTemplateSkin), "DataGridViewVisualTemplate_Mobile.png");

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TreeViewVisualTemplate" /> class.
		/// </summary>
		public DataGridViewMobileVisualTemplate()
		{
		}

		/// 
		/// Renders the specified object context.
		/// </summary>
		/// <param name="objContext">The object context.</param>
		/// <param name="objWriter">The object writer.</param>
		public override void Render(IContext objContext, IAttributeWriter objWriter)
		{
			base.Render(objContext, objWriter);
			objWriter.WriteAttributeString("VIS_DGV_NOC", mintNumberOfDisplayedColumns);
			if (!string.IsNullOrEmpty(mstrNewColumnOrder))
			{
				objWriter.WriteAttributeString("VIS_LV_CO", mstrNewColumnOrder);
			}
			if (mintCaptionHeight > 0)
			{
				objWriter.WriteAttributeString("VIS_DGV_CH", mintCaptionHeight);
			}
			else
			{
				objWriter.WriteAttributeString("VIS_DGV_CH", GetCalculatedCaptionHeight());
			}
			if (mintBottomMenuHeight > 0)
			{
				objWriter.WriteAttributeString("VIS_DGV_BMH", mintBottomMenuHeight);
			}
			else
			{
				objWriter.WriteAttributeString("VIS_DGV_BMH", GetCalculatedBottomMenuHeight());
			}
			if (mobjFilterOperators != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (string mobjFilterOperator in mobjFilterOperators)
				{
					stringBuilder.Append(mobjFilterOperator);
				}
				objWriter.WriteAttributeString("VIS_DGV_FO", stringBuilder.ToString().Trim('|'));
			}
			objWriter.WriteAttributeString("VIS_DGV_DORH", GetCalculatedBottomMenuHeight());
		}

		/// 
		/// Gets the calculated height of the node.
		/// </summary>
		/// </returns>
		private int GetCalculatedCaptionHeight()
		{
			if (!mintCalculatedCaptionHeight.HasValue)
			{
				DataGridViewMobileVisualTemplateSkin dataGridViewMobileVisualTemplateSkin = SkinFactory.GetSkin(this) as DataGridViewMobileVisualTemplateSkin;
				mintCalculatedCaptionHeight = dataGridViewMobileVisualTemplateSkin.CaptionHeight;
			}
			return mintCalculatedCaptionHeight.Value;
		}

		/// 
		/// Gets the calculated height of the node.
		/// </summary>
		/// </returns>
		private int GetCalculatedBottomMenuHeight()
		{
			if (!mintCalculatedBottomMenuHeight.HasValue)
			{
				DataGridViewMobileVisualTemplateSkin dataGridViewMobileVisualTemplateSkin = SkinFactory.GetSkin(this) as DataGridViewMobileVisualTemplateSkin;
				mintCalculatedBottomMenuHeight = dataGridViewMobileVisualTemplateSkin.BottomMenuHeight;
			}
			return mintCalculatedBottomMenuHeight.Value;
		}

		/// 
		/// Fires the event.
		/// </summary>
		/// <param name="objControl"></param>
		/// <param name="objEvent">The object event.</param>
		protected internal override void FireEvent(Control objControl, IEvent objEvent)
		{
			base.FireEvent(objControl, objEvent);
			if (!(objControl is DataGridView dataGridView))
			{
				return;
			}
			string text = objEvent["EventAction"];
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			string member = objEvent.Member;
			Point memberPosition = dataGridView.GetMemberPosition(member);
			switch (text)
			{
			case "ShowFilterOptions":
			{
				if (memberPosition.X == -1)
				{
					break;
				}
				DataGridViewFilterRow filterRow = dataGridView.FilterRow;
				if (!(filterRow.Cells[memberPosition.X] is DataGridViewFilterCell dataGridViewFilterCell))
				{
					break;
				}
				List<FilterComparisonOperator> filterComparisonOperator = DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisonOperator(dataGridViewFilterCell.OwningColumn.ValueType);
				mobjFilterOperators = new List<string>();
				{
					foreach (FilterComparisonOperator item in filterComparisonOperator)
					{
						mobjFilterOperators.Add($"{SR.GetString($"FilterComparisionOperator_{item.ToString()}")}|{DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisionOperatorImage(dataGridView, item)}|");
					}
					break;
				}
			}
			case "SetFilterOption":
				if (memberPosition.X != -1)
				{
					DataGridViewFilterRow filterRow2 = dataGridView.FilterRow;
					DataGridViewFilterCell dataGridViewFilterCell2 = filterRow2.Cells[memberPosition.X] as DataGridViewFilterCell;
					List<FilterComparisonOperator> filterComparisonOperator2 = DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisonOperator(dataGridViewFilterCell2.OwningColumn.ValueType);
					string s = objEvent["VLB"];
					if (int.TryParse(s, out var result) && result < filterComparisonOperator2.Count)
					{
						ResourceHandle filterComparisionOperatorImage = DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisionOperatorImage(dataGridView, filterComparisonOperator2[result]);
						DataGridViewFilterCell.DataGridViewFilterControl dataGridViewFilterControlObject = dataGridViewFilterCell2.DataGridViewFilterControlObject;
						dataGridViewFilterControlObject.SetOperator(filterComparisonOperator2[result], filterComparisionOperatorImage);
						dataGridViewFilterControlObject.FireFilterChanged(blnForceFilterChanged: false);
					}
				}
				break;
			case "AddGroup":
			{
				string text2 = objEvent["N"];
				if (!string.IsNullOrEmpty(text2))
				{
					dataGridView.InsertGroupingColumn(string.Empty, text2);
					dataGridView.OnGroupingChanged(DataGridViewGroupingAction.Add, text2);
				}
				break;
			}
			}
		}

		/// 
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return "Mobile DataGridView";
		}

		/// 
		/// Converts to string.
		/// </summary>
		/// </returns>
		internal override string ConvertToString()
		{
			return string.Empty;
		}

		/// 
		/// Converts from string.
		/// </summary>
		/// <param name="objVisualTemplateValues">The object visual template values.</param>
		internal override void ConvertFromString(List<object> objVisualTemplateValues)
		{
		}

		/// 
		/// Gets the constroctor arguments. (For TypeContevert)
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override object[] GetConsturctorArguments()
		{
			return new object[1];
		}

		/// 
		/// Gets the constroctor types. (For TypeContevert)
		/// </summary>
		public override Type[] GetConstructorTypes()
		{
			return new Type[1];
		}
	}
}
