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
	[VisualTemplate(typeof(DateTimePicker), "Visually adjusts the DateTimePicker control to appear identical to a native DateTimePicker on the customized device.")]
	[Skin(typeof(NativeDateTimePickerVisualTemplateSkin))]
	public class NativeDateTimePickerVisualTemplate : VisualTemplate
	{
		private NativeDateTimePickerVisualTemplateFormat menmNativeDateTimePickerVisualTemplateFormat = NativeDateTimePickerVisualTemplateFormat.Date;

		/// 
		/// Gets or sets the format.
		/// </summary>
		/// 
		/// The format.
		/// </value>
		public NativeDateTimePickerVisualTemplateFormat Format
		{
			get
			{
				return menmNativeDateTimePickerVisualTemplateFormat;
			}
			set
			{
				menmNativeDateTimePickerVisualTemplateFormat = value;
			}
		}

		/// 
		/// Gets the name of the visual template.
		/// </summary>
		/// 
		/// The name of the visual template.
		/// </value>
		public override string VisualTemplateName => "NativeDateTimePickerVisualTemplate";

		/// 
		/// Gets the visualizer image.
		/// </summary>
		/// 
		/// The visualizer image.
		/// </value>
		public override ResourceHandle VisualizerImage => new SkinResourceHandle(typeof(NativeDateTimePickerVisualTemplateSkin), "NativeDateTimePicker.png");

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.NativeDateTimePickerVisualTemplate" /> class.
		/// </summary>
		public NativeDateTimePickerVisualTemplate()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.NativeDateTimePickerVisualTemplate" /> class.
		/// </summary>
		/// <param name="enmNativeDateTimePickerVisualTemplateFormat">The enm native date time picker visual template format.</param>
		public NativeDateTimePickerVisualTemplate(NativeDateTimePickerVisualTemplateFormat enmNativeDateTimePickerVisualTemplateFormat)
		{
			menmNativeDateTimePickerVisualTemplateFormat = enmNativeDateTimePickerVisualTemplateFormat;
		}

		/// 
		/// Renders the specified object context.
		/// </summary>
		/// <param name="objContext">The object context.</param>
		/// <param name="objWriter">The object writer.</param>
		public override void Render(IContext objContext, IAttributeWriter objWriter)
		{
			base.Render(objContext, objWriter);
			objWriter.WriteAttributeString("VIS_DP_F", menmNativeDateTimePickerVisualTemplateFormat.ToString().Replace("_", "-").ToLower());
		}

		/// 
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// 
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return "Native DateTimePicker";
		}

		/// 
		/// Gets the constroctor arguments. (For TypeConverter)
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override object[] GetConsturctorArguments()
		{
			return new object[1] { menmNativeDateTimePickerVisualTemplateFormat };
		}

		/// 
		/// Gets the constroctor types. (For TypeConverter)
		/// </summary>
		public override Type[] GetConstructorTypes()
		{
			return new Type[1] { typeof(NativeDateTimePickerVisualTemplateFormat) };
		}

		/// 
		/// Converts to string.
		/// </summary>
		/// </returns>
		internal override string ConvertToString()
		{
			return $"{base.ConvertToString()}|{(int)menmNativeDateTimePickerVisualTemplateFormat}";
		}

		/// 
		/// Converts from string.
		/// </summary>
		/// <param name="objVisualTemplateValues">The object visual template values.</param>
		internal override void ConvertFromString(List<object> objVisualTemplateValues)
		{
			int result = 0;
			if (objVisualTemplateValues.Count == 1 && int.TryParse(objVisualTemplateValues[0] as string, out result) && Enum.IsDefined(typeof(NativeDateTimePickerVisualTemplateFormat), result))
			{
				menmNativeDateTimePickerVisualTemplateFormat = (NativeDateTimePickerVisualTemplateFormat)result;
			}
		}
	}
}
