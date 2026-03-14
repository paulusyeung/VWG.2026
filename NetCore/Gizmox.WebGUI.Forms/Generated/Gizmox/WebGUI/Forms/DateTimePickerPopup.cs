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
	[Skin(typeof(DateTimePickerPopupSkin))]
	public class DateTimePickerPopup : Form
	{
		protected MonthCalendar mobjMonthCalendar = null;

		protected DateTime mobjDate;

		protected DateTimePicker mobjDateTimePicker = null;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DateTimePickerPopup" /> class.
		/// </summary>
		public DateTimePickerPopup()
		{
			InitializeComponent();
		}

		/// 
		///
		/// </summary>
		/// <param name="objDateTimePicker"></param>
		public DateTimePickerPopup(DateTimePicker objDateTimePicker)
			: this()
		{
			mobjDateTimePicker = objDateTimePicker;
			if (mobjDateTimePicker != null)
			{
				mobjMonthCalendar.Value = mobjDateTimePicker.Value;
				mobjMonthCalendar.FirstDayOfWeek = mobjDateTimePicker.CalendarFirstDayOfWeek;
				mobjMonthCalendar.VisualEffect = mobjDateTimePicker.VisualEffect;
				if (mobjDateTimePicker.CloseUpHandler != null)
				{
					base.Closed += DateTimePickerPopup_Closed;
				}
				if (mobjDateTimePicker.Skin is DateTimePickerSkin dateTimePickerSkin)
				{
					base.Size = dateTimePickerSkin.DropDownSize;
				}
			}
		}

		/// 
		///
		/// </summary>
		private void InitializeComponent()
		{
			mobjMonthCalendar = new MonthCalendar(mobjDateTimePicker, this);
			SuspendLayout();
			mobjMonthCalendar.Dock = DockStyle.Fill;
			mobjMonthCalendar.BorderStyle = BorderStyle.None;
			mobjMonthCalendar.BorderWidth = 0;
			base.Controls.Add(mobjMonthCalendar);
			base.Size = new Size(177, 154);
			base.ClientSize = new Size(177, 154);
			Text = WGLabels.DatePicker;
			ResumeLayout(blnPerformLayout: false);
		}

		/// 
		/// Called when [month calander value changed].
		/// </summary>
		/// <param name="blnClosePopUp">if set to true</c> [BLN close pop up].</param>
		internal void OnMonthCalanderValueChanged(bool blnClosePopUp)
		{
			TimeSpan zero = TimeSpan.Zero;
			if (mobjDateTimePicker != null)
			{
				zero = mobjDateTimePicker.Value.TimeOfDay;
				DateTime dateTime = mobjMonthCalendar.Value.Add(zero);
				if (dateTime >= mobjDateTimePicker.MinDate && dateTime <= mobjDateTimePicker.MaxDate)
				{
					mobjDateTimePicker.Value = dateTime;
				}
				mobjDateTimePicker.Focus();
			}
			if (blnClosePopUp)
			{
				Close();
			}
		}

		private void DateTimePickerPopup_Closed(object sender, EventArgs e)
		{
			mobjDateTimePicker.OnCloseUp(new EventArgs());
		}
	}
}
