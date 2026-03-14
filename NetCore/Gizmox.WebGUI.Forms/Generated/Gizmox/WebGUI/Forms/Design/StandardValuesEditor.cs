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

namespace Gizmox.WebGUI.Forms.Design
{
/// 
	///
	/// </summary>
	[Serializable]
	public class StandardValuesEditor : WebUITypeEditor
	{
		[Serializable]
		private class ListBoxForm : Form
		{
			[Serializable]
			[ToolboxItem(false)]
			private class TempListBox : ListBox
			{
				protected override bool IsDelayedDrawing => false;
			}

			private bool mblnIsCompleted = false;

			private ListBox mobjListBox = null;

			public bool IsCompleted => mblnIsCompleted;

			public object Value => mobjListBox.SelectedItem;

			public ListBoxForm(ICollection objCollection)
			{
				mobjListBox = new TempListBox();
				mobjListBox.Dock = DockStyle.Fill;
				mobjListBox.BorderStyle = BorderStyle.FixedSingle;
				mobjListBox.SelectionMode = SelectionMode.One;
				mobjListBox.Items.AddRange(objCollection);
				mobjListBox.SelectedIndexChanged += objListBox_SelectedIndexChanged;
				SuspendLayout();
				BackColor = Color.White;
				int num = 2;
				int num2 = 2;
				int num3 = 0;
				if (base.Skin is FormSkin formSkin && formSkin.CenterPopupWindowStyle.BorderStyle != BorderStyle.None)
				{
					num3 = formSkin.CenterPopupWindowStyle.BorderWidth.Bottom + formSkin.CenterPopupWindowStyle.BorderWidth.Top;
				}
				if (mobjListBox.Skin is ListBoxSkin { BorderWidth: { Top: var top }, BorderWidth: var borderWidth2 })
				{
					num = top + borderWidth2.Bottom;
				}
				base.Height = mobjListBox.GetPreferdItemHeight() * ((objCollection.Count > 15) ? 15 : objCollection.Count) + num + num2 + num3;
				base.Width = 130;
				base.Controls.Add(mobjListBox);
				ResumeLayout(blnPerformLayout: true);
			}

			private void objListBox_SelectedIndexChanged(object sender, EventArgs e)
			{
				mblnIsCompleted = true;
				Close();
			}
		}

		private WebUITypeEditorHandler mobjHandler = null;

		private TypeConverter mobjTypeConvertor = null;

		public StandardValuesEditor()
		{
		}

		public StandardValuesEditor(TypeConverter objTypeConvertor)
		{
			mobjTypeConvertor = objTypeConvertor;
		}

		public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
		{
			ArrayList listValues = GetListValues(objContext);
			if (listValues.Count > 0)
			{
				ListBoxForm listBoxForm = new ListBoxForm(listValues);
				listBoxForm.Closed += objListBoxForm_Closed;
				mobjHandler = objHandler;
				if (objProvider.GetService(typeof(IWebUIEditorService)) is IWebUIEditorService webUIEditorService)
				{
					webUIEditorService.ShowDropDown(listBoxForm);
				}
			}
		}

		protected virtual ArrayList GetListValues(ITypeDescriptorContext objContext)
		{
			TypeConverter.StandardValuesCollection standardValues = mobjTypeConvertor.GetStandardValues(objContext);
			ArrayList arrayList = new ArrayList();
			foreach (object item in standardValues)
			{
				if (item != null)
				{
					arrayList.Add(item);
				}
			}
			return arrayList;
		}

		private void objListBoxForm_Closed(object sender, EventArgs e)
		{
			ListBoxForm listBoxForm = (ListBoxForm)sender;
			if (listBoxForm.IsCompleted && mobjHandler != null)
			{
				mobjHandler(GetPropertyValueFromEditorValue(listBoxForm.Value));
			}
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext)
		{
			return UITypeEditorEditStyle.DropDown;
		}
	}
}
