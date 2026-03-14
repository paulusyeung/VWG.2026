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
[Serializable]
	[Editor("Gizmox.WebGUI.Forms.Design.VisualTemplateEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[WebEditor(typeof(VisualTemplateEditor), typeof(WebUITypeEditor))]
	[TypeConverter(typeof(VisualTemplatesTypeConverter))]
	public abstract class VisualTemplate : ISkinable
	{
		/// 
		/// Gets the name of the visual template.
		/// </summary>
		/// 
		/// The name of the visual template.
		/// </value>
		[Browsable(false)]
		public abstract string VisualTemplateName { get; }

		/// 
		/// Gets the visualizer image.
		/// </summary>
		/// 
		/// The visualizer image.
		/// </value>
		[Browsable(false)]
		public virtual ResourceHandle VisualizerImage => null;

		/// 
		/// Gets the visualizer default image.
		/// </summary>
		/// 
		/// The visualizer default image.
		/// </value>
		internal static ResourceHandle VisualizerDefaultImage => new SkinResourceHandle(typeof(Gizmox.WebGUI.Forms.Skins.ControlSkin), "VisualTemplate_None.png");

		/// 
		/// Gets the theme related to the skinable component.
		/// </summary>
		/// 
		/// The theme related to the skinable component.
		/// </value>
		[Browsable(false)]
		public string Theme
		{
			get
			{
				if (CommonUtils.IsDesignMode && !ConfigHelper.ApplySelectedThemeInDesignTime)
				{
					return "Default";
				}
				if (VWGContext.Current != null)
				{
					return VWGContext.Current.CurrentTheme;
				}
				return ConfigHelper.SelectedTheme;
			}
		}

		/// 
		/// Renders the specified object context.
		/// </summary>
		/// <param name="objContext">The object context.</param>
		/// <param name="objWriter">The object writer.</param>
		public virtual void Render(IContext objContext, IAttributeWriter objWriter)
		{
			objWriter.WriteAttributeString("VS", VisualTemplateName);
		}

		/// 
		/// Gets the constroctor arguments. (For TypeConverter)
		/// </summary>
		/// </returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual object[] GetConsturctorArguments()
		{
			return new object[0];
		}

		/// 
		/// Gets the constroctor types. (For TypeConverter)
		/// </summary>
		public virtual Type[] GetConstructorTypes()
		{
			return new Type[0];
		}

		public virtual VisualTemplate GetDefault(Control objControl)
		{
			return null;
		}

		/// 
		/// Converts to string.
		/// </summary>
		/// </returns>
		internal virtual string ConvertToString()
		{
			return $"{GetType().FullName}, {GetType().Assembly.GetName().Name}";
		}

		/// 
		/// Converts from string.
		/// </summary>
		/// <param name="objVisualTemplateValues">The object visual template values.</param>
		internal virtual void ConvertFromString(List<object> objVisualTemplateValues)
		{
		}

		/// 
		/// Fires the event.
		/// </summary>
		/// <param name="objEvent">The object event.</param>
		protected internal virtual void FireEvent(Control objControl, IEvent objEvent)
		{
		}
	}
}
