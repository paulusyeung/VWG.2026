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

namespace Gizmox.WebGUI.Forms.Hosts
{
/// 
	/// 	AspControlBoxBase
	///     provides a base class for creating ASP.NET wrapped controls that can be integrated
	///     into VWG as a native control.</para>
	/// 	The class provides
	///     services for ASP.NET VWG communication and using ASP.NET markup code to
	///     initialize the ASP.NET control.</para>
	/// </summary>
	/// 
	/// 	<font size="2">The following example illustrates the basic use of
	///     AspControlBoxBase.</font></para>
	/// 	<code lang="CS">
	/// 		<![CDATA[
	/// [System.ComponentModel.ToolboxItem(true)]
	///  public class MyWrappedWebControl : Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase
	///  {
	///     /// 
	///     /// Get the hosted control type
	///     /// </SUMMARY>
	///     protected override Type HostedControlType
	///     {
	///         get
	///         {
	///             return typeof(WebControl);
	///         }   
	///     }
	///
	///     /// 
	///     /// Get hosted control typed instance
	///     /// </SUMMARY>
	///     protected WebControl HostedASPxTreeList
	///     {
	///         get
	///         {
	///             return (WebControl)this.HostedControl;
	///         }
	///     }
	///
	/// }]]>
	/// 	</code>
	/// 	<code lang="VB">
	/// 		<![CDATA[
	/// <SYSTEM.COMPONENTMODEL.TOOLBOXITEM(TRUE)> _
	///  Partial Class MyWrappedWebControl 
	/// Inherits Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase
	///
	///     ''' 
	///     ''' Get the hosted control type
	///     ''' </SUMMARY>
	///     Protected Overrides Readonly Property HostedControlType() As Type
	///         Get
	///             Return GetType(System.Web.UI.Control)
	///         End Get
	///     End Property
	///
	///     ''' 
	///     ''' Get hosted control typed instance
	///     ''' </SUMMARY>
	///     Protected Readonly Property HostedControl As WebControl
	///         Get
	///             Return CType(Me.HostedControl, WebControl)
	///         End Get
	///     End Property
	///
	/// End Class]]>
	/// 	</code>
	/// </example>
	[Serializable]
	[ToolboxItem(false)]
	[ToolboxBitmap(typeof(AspControlBoxBase), "Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.AspControlBoxCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[Skin(typeof(AspControlBoxBaseSkin))]
	public abstract class AspControlBoxBase : FrameControl
	{
		/// 
		/// Provides an implementation of a virtual file that can compile a code at runtime from a string or an embeded resource
		/// </summary>
		[Serializable]
		internal class ResourceFile : System.Web.Hosting.VirtualFile
		{
			/// 
			/// The relative path produced from the virtual path
			/// </summary>
			private string mstrRelativePath;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase.ResourceFile" /> class.
			/// </summary>
			/// <param name="strVirtualPath">The virtual path.</param>
			internal ResourceFile(string strVirtualPath)
				: base(strVirtualPath)
			{
				mstrRelativePath = VirtualPathUtility.ToAppRelative(strVirtualPath);
			}

			/// 
			/// Opens this instance.
			/// </summary>
			/// </returns>
			public override Stream Open()
			{
				string[] array = mstrRelativePath.Split('/');
				string text = ((array.Length > 1) ? array[1] : "");
				string text2 = ((array.Length > 2) ? array[2] : "");
				string g = text.Substring("VWG_AspResource".Length + 1).Replace(".ascx", "");
				Guid objBuildGuid = new Guid(g);
				return ResourceProvider.GetBuildCode(objBuildGuid);
			}

			private Stream GetDisconectedStream(Assembly objAssembly, string strResourceName)
			{
				Stream manifestResourceStream = objAssembly.GetManifestResourceStream(strResourceName);
				if (manifestResourceStream != null)
				{
					MemoryStream memoryStream = new MemoryStream();
					StreamReader streamReader = new StreamReader(manifestResourceStream);
					StreamWriter streamWriter = new StreamWriter(memoryStream);
					streamWriter.Write(streamReader.ReadToEnd());
					streamWriter.Flush();
					memoryStream.Position = 0L;
					manifestResourceStream.Close();
					return memoryStream;
				}
				return null;
			}
		}

		/// 
		/// Provides a custom resource provider to help build types from string or an embeded resource
		/// </summary>
		[Serializable]
		internal class ResourceProvider : VirtualPathProvider
		{
			internal const string VwgResourcePrefix = "VWG_AspResource";

			/// 
			/// Temporary stored code strings
			/// </summary>
			private static Dictionary<Guid, string> mobjTemporaryStoredCode;

			/// 
			/// Initializes the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase.ResourceProvider" /> class.
			/// </summary>
			static ResourceProvider()
			{
				mobjTemporaryStoredCode = new Dictionary<Guid, string>();
				HostingEnvironment.RegisterVirtualPathProvider(new ResourceProvider());
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase.ResourceProvider" /> class.
			/// </summary>
			internal ResourceProvider()
			{
			}

			/// 
			/// Determines whether virtual path is a resource path.
			/// </summary>
			/// <param name="strVirtualPath">The virtual path.</param>
			/// 
			/// 	true</c> if virtual path is a resource path; otherwise, false</c>.
			/// </returns>
			private bool IsAppResourcePath(string strVirtualPath)
			{
				string text = VirtualPathUtility.ToAppRelative(strVirtualPath);
				return text.Contains("VWG_AspResource");
			}

			/// 
			/// Gets a value that indicates whether a file exists in the virtual file system.
			/// </summary>
			/// <param name="strVirtualPath">The path to the virtual file.</param>
			/// 
			/// true if the file exists in the virtual file system; otherwise, false.
			/// </returns>
			public override bool FileExists(string strVirtualPath)
			{
				return IsAppResourcePath(strVirtualPath) || base.FileExists(strVirtualPath);
			}

			/// 
			/// Gets the file.
			/// </summary>
			/// <param name="strVirtualPath">The virtual path.</param>
			/// </returns>
			public override System.Web.Hosting.VirtualFile GetFile(string strVirtualPath)
			{
				if (IsAppResourcePath(strVirtualPath))
				{
					return new ResourceFile(strVirtualPath);
				}
				return base.GetFile(strVirtualPath);
			}

			/// 
			/// Creates a cache dependency based on the specified virtual paths.
			/// </summary>
			/// <param name="strVirtualPath">The path to the primary virtual resource.</param>
			/// <param name="objVirtualPathDependencies">An array of paths to other resources required by the primary virtual resource.</param>
			/// <param name="utcStart">The UTC time at which the virtual resources were read.</param>
			/// 
			/// A <see cref="T:System.Web.Caching.CacheDependency" /> object for the specified virtual resources.
			/// </returns>
			public override CacheDependency GetCacheDependency(string strVirtualPath, IEnumerable objVirtualPathDependencies, DateTime objUtcStart)
			{
				if (IsAppResourcePath(strVirtualPath))
				{
					return null;
				}
				return base.GetCacheDependency(strVirtualPath, objVirtualPathDependencies, objUtcStart);
			}

			/// 
			/// Gets the type of the virtual path.
			/// </summary>
			/// <param name="strVirtualPath">The control virtual path.</param>
			internal static Type GetVirtualPathType(string strVirtualPath)
			{
				return BuildManager.GetCompiledType(strVirtualPath);
			}

			/// 
			/// Gets the type of the compiled.
			/// </summary>
			/// <param name="strAspCode">The ASP code.</param>
			/// </returns>
			public static Type GetCompiledType(string strAspCode)
			{
				Guid key = Guid.NewGuid();
				Type result = null;
				mobjTemporaryStoredCode[key] = strAspCode;
				try
				{
					string virtualPath = string.Format("~/{0}_{1}.ascx", "VWG_AspResource", key.ToString("N"));
					result = BuildManager.GetCompiledType(virtualPath);
				}
				finally
				{
					mobjTemporaryStoredCode.Remove(key);
				}
				return result;
			}

			/// 
			/// Gets the build code.
			/// </summary>
			/// <param name="objBuildGuid">The obj build GUID.</param>
			/// </returns>
			internal static Stream GetBuildCode(Guid objBuildGuid)
			{
				MemoryStream memoryStream = new MemoryStream();
				if (mobjTemporaryStoredCode.ContainsKey(objBuildGuid))
				{
					StreamWriter streamWriter = new StreamWriter(memoryStream);
					streamWriter.Write(mobjTemporaryStoredCode[objBuildGuid]);
					streamWriter.Flush();
					memoryStream.Position = 0L;
				}
				return memoryStream;
			}
		}

		protected internal enum VersionCompatibilityMode
		{
			Version6,
			Version72
		}

		/// 
		/// Provides a property reference to ControlState property.
		/// </summary>
		private static SerializableProperty ControlStateProperty = SerializableProperty.Register("ControlState", typeof(object), typeof(AspControlBoxBase));

		/// 
		/// Provides a property reference to ViewState property.
		/// </summary>
		private static SerializableProperty ViewStateProperty = SerializableProperty.Register("ViewState", typeof(object), typeof(AspControlBoxBase));

		/// 
		/// Provides a property reference to DefaultDesignValues property.
		/// </summary>
		private static SerializableProperty DefaultDesignValuesProperty = SerializableProperty.Register("DefaultDesignValues", typeof(Dictionary<string, object>), typeof(AspControlBoxBase));

		/// 
		/// Provides a property reference to DesignTimeProperties property.
		/// </summary>
		private static SerializableProperty DesignTimePropertiesProperty = SerializableProperty.Register("DesignTimeProperties", typeof(Dictionary<string, object>), typeof(AspControlBoxBase));

		/// 
		/// Provides a property reference to DesignTimeProperties property.
		/// </summary>
		private static SerializableProperty DesignTimeEventHandlersProperty = SerializableProperty.Register("DesignTimeEventHandlers", typeof(Dictionary<string, List<object>>), typeof(AspControlBoxBase), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to Properties property.
		/// </summary>
		private static SerializableProperty PropertiesProperty = SerializableProperty.Register("Properties", typeof(Dictionary<string, PropertyInfo>), typeof(AspControlBoxBase));

		/// 
		/// Provides a property reference to AspPipeLinePage property.
		/// </summary>
		private static SerializableProperty AspPipeLinePageProperty = SerializableProperty.Register("AspPipeLinePage", typeof(AspPipeLinePage), typeof(AspControlBoxBase));

		/// 
		/// Provides a property reference to EventHandlers property.
		/// </summary>
		private static SerializableProperty EventHandlersProperty = SerializableProperty.Register("EventHandlers", typeof(Dictionary<string, List<object>>), typeof(AspControlBoxBase), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to Events property.
		/// </summary>
		private static SerializableProperty EventsProperty = SerializableProperty.Register("Events", typeof(Dictionary<string, EventInfo>), typeof(AspControlBoxBase));

		/// 
		/// Provides a property reference to IsAspRequest property.
		/// </summary>
		private static SerializableProperty IsAspRequestProperty = SerializableProperty.Register("IsAspRequest", typeof(bool), typeof(AspControlBoxBase));

		/// 
		/// Provides a property reference to AutoScroll property.
		/// </summary>
		private static SerializableProperty AutoScrollProperty = SerializableProperty.Register("AutoScroll", typeof(bool), typeof(AspControlBoxBase));

		/// 
		/// Provides a property reference to ControlCodeType property.
		/// </summary>
		private static SerializableProperty ControlCodeTypeProperty = SerializableProperty.Register("ControlCodeType", typeof(Type), typeof(AspControlBoxBase));

		/// 
		/// Provides a property reference to ControlCode property.
		/// </summary>
		private static SerializableProperty ControlCodeProperty = SerializableProperty.Register("ControlCode", typeof(string), typeof(AspControlBoxBase));

		/// 
		/// Provides a property reference to ControlID property.
		/// </summary>
		private static SerializableProperty ControlIDProperty = SerializableProperty.Register("ControlID", typeof(string), typeof(AspControlBoxBase));

		/// 
		/// Provides a property reference to SyncPostDataChangesMode property.
		/// </summary>
		private static SerializableProperty SyncChangesOnVwgPostBackProperty = SerializableProperty.Register("SyncChangesOnVwgPostBack", typeof(SyncPostDataChangesMode), typeof(AspControlBoxBase), new SerializablePropertyMetadata(SyncPostDataChangesMode.None));

		/// 
		/// Provides a property reference to SyncPostDataChangesMode property.
		/// </summary>
		private static SerializableProperty ScriptsProperty = SerializableProperty.Register("Scripts", typeof(string[]), typeof(AspControlBoxBase));

		/// 
		/// Provides a property reference to SyncPostDataChangesMode property.
		/// </summary>
		private static SerializableProperty StylesProperty = SerializableProperty.Register("Styles", typeof(string[]), typeof(AspControlBoxBase));

		/// 
		/// Provides a property reference to SyncPostData property.
		/// </summary>
		private static SerializableProperty SyncPostDataProperty = SerializableProperty.Register("SyncPostData", typeof(NameValueCollection), typeof(AspControlBoxBase));

		[NonSerialized]
		private bool mblnProcessMainEndRequired = false;

		[NonSerialized]
		private bool mblnAspUpdate = false;

		[NonSerialized]
		private System.Web.UI.Control mobjHostedControlForAspUpdate;

		[NonSerialized]
		private AspPipeLinePage mobjHostedPage;

		/// 
		/// Gets the source.
		/// </summary>
		/// The source.</value>
		protected override string Source
		{
			get
			{
				string baseUrl = CommonUtils.GetBaseUrl(VWGContext.Current.HostContext.Request);
				string text = new GatewayReference(this, "ASCXHost", null).ToString();
				if (VWGContext.Current.HostContext.HttpContext.Session.IsCookieless)
				{
					text = VWGContext.Current.HostContext.HttpContext.Response.ApplyAppPathModifier(text);
				}
				return baseUrl + text;
			}
		}

		/// 
		/// Gets a value indicating whether this instance is fixed size.
		/// </summary>
		/// 
		/// 	true</c> if this instance is fixed size; otherwise, false</c>.
		/// </value>
		protected virtual bool IsFixedSize => false;

		/// 
		/// Gets a value indicating whether this instance is parent valid.
		/// </summary>
		/// 
		/// 	true</c> if this instance is parent valid; otherwise, false</c>.
		/// </value>
		private bool IsParentValid => base.Parent != null;

		/// 
		/// Gets a value indicating whether control code is valid.
		/// </summary>
		/// 
		/// 	true</c> if control code is valid; otherwise, false</c>.
		/// </value>
		private bool IsCodeControlValid => !string.IsNullOrEmpty(ControlCode);

		/// 
		/// Gets a value indicating whether running in design mode.
		/// </summary>
		/// true</c> if in design mode; otherwise, false</c>.</value>
		private bool InDesignMode
		{
			get
			{
				if (!base.DesignMode)
				{
					return HostContext.Current == null;
				}
				return true;
			}
		}

		/// 
		/// Gets or sets the hosted control, that will be saved when in the vwg request there is AspUpdate,
		/// this AspUpdateHostedControl will be set instead of the HostedControl created in the AspRequest in the LoadCompleted stage.
		/// </summary>
		private System.Web.UI.Control HostedControlForAspUpdate
		{
			get
			{
				return mobjHostedControlForAspUpdate;
			}
			set
			{
				mobjHostedControlForAspUpdate = value;
			}
		}

		/// 
		/// Gets or sets the last sync post data.
		/// </summary>
		private NameValueCollection SyncPostData
		{
			get
			{
				return GetValue(SyncPostDataProperty, null);
			}
			set
			{
				SetValue(SyncPostDataProperty, value);
			}
		}

		/// 
		/// Gets and sets a value indicating whether to synchronize changes of input fields of the asp control in vwg raise events.
		/// In case the value is null, it will synchornize changes only if there are input fields in the control.
		/// </summary>
		[DefaultValue(SyncPostDataChangesMode.None)]
		[Category("Behavior")]
		[Description("Synchronize changes of input fields of the asp control in vwg raise events. In case the value is null, it will synchornize changes only if there are input fields in the control.")]
		public virtual SyncPostDataChangesMode SyncChangesOnVwgPostBack
		{
			get
			{
				return GetValue(SyncChangesOnVwgPostBackProperty, SyncPostDataChangesMode.None);
			}
			set
			{
				if (SetValue(SyncChangesOnVwgPostBackProperty, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets and sets a  
		/// </summary>
		[Category("Behavior")]
		[Description("Urls to scripts js that will be registered in the asp page.")]
		public string[] Scripts
		{
			get
			{
				string[] array = GetValue<string[]>(ScriptsProperty);
				if (array == null)
				{
					array = (Scripts = new string[0]);
				}
				return array;
			}
			set
			{
				if (SetValue(ScriptsProperty, value))
				{
					AspUpdate();
				}
			}
		}

		/// 
		/// Gets and sets a  
		/// </summary>
		[Category("Behavior")]
		[Description("Urls to styles js that will be registered in the asp page.")]
		public string[] Styles
		{
			get
			{
				string[] array = GetValue<string[]>(StylesProperty);
				if (array == null)
				{
					array = (Styles = new string[0]);
				}
				return array;
			}
			set
			{
				if (SetValue(StylesProperty, value))
				{
					AspUpdate();
				}
			}
		}

		/// 
		/// Gets or sets the control ID, which indicates the id of the hosted control with in the control code.
		/// </summary>
		/// The control ID.</value>
		[Category("Behavior")]
		[Description("The control ID of the hosted control in the markup code.")]
		[DefaultValue("hosted_control_id")]
		public string ControlID
		{
			get
			{
				return GetValue(ControlIDProperty, "hosted_control_id");
			}
			set
			{
				if (ControlID != value)
				{
					if (string.IsNullOrEmpty(value) || value == "hosted_control_id")
					{
						RemoveValue(ControlIDProperty);
					}
					else
					{
						SetValue(ControlIDProperty, value);
					}
				}
			}
		}

		/// Gets or sets the control code.</summary>
		/// The control code.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Editor("Gizmox.WebGUI.Forms.Design.AspCodeEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[Category("Behavior")]
		[Description("Provides a way to initialize the control using ASP.NET markup.")]
		public string ControlCode
		{
			get
			{
				string text = GetValue(ControlCodeProperty, string.Empty);
				if (string.IsNullOrEmpty(text))
				{
					string arg = "ctrl";
					string fullName = HostedControlType.Assembly.FullName;
					string arg2 = HostedControlType.Namespace;
					string name = HostedControlType.Name;
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append("<%@ Control Language=\"C#\"%>");
					stringBuilder.AppendLine();
					stringBuilder.AppendFormat("<%@ Register TagPrefix=\"{0}\" Assembly=\"{1}\" Namespace=\"{2}\" %>", arg, fullName, arg2);
					stringBuilder.AppendLine();
					stringBuilder.AppendFormat("<{0}:{1} ID=\"{2}\" runat=\"server\" />", arg, name, ControlID);
					stringBuilder.AppendLine();
					text = stringBuilder.ToString();
				}
				return text;
			}
			set
			{
				if (ControlCode != value)
				{
					if (string.IsNullOrEmpty(value))
					{
						RemoveValue(ControlCodeProperty);
						return;
					}
					SetValue(ControlCodeProperty, value);
					ControlCodeType = null;
				}
			}
		}

		/// 
		/// Gets the type of the control container.
		/// </summary>
		/// The type of the control container.</value>
		private Type ControlCodeType
		{
			get
			{
				Type type = GetValue(ControlCodeTypeProperty, null);
				if (type == null && !DesignModeExtended)
				{
					string controlCode = ControlCode;
					type = ((controlCode.IndexOf("<%@") <= -1) ? ResourceProvider.GetVirtualPathType(controlCode) : ResourceProvider.GetCompiledType(ControlCode));
					SetValue(ControlCodeTypeProperty, type);
				}
				return type;
			}
			set
			{
				if (ControlCodeType != value)
				{
					if (value == null)
					{
						RemoveValue(ControlCodeTypeProperty);
					}
					else
					{
						SetValue(ControlCodeTypeProperty, value);
					}
				}
			}
		}

		private bool DesignModeExtended => base.DesignMode || HostContext.Current == null;

		/// 
		/// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
		/// </summary>
		/// true if the container enables auto-scrolling; otherwise, false. The default value is true.</value>
		[SRCategory("CatLayout")]
		[SRDescription("FormAutoScrollDescr")]
		[DefaultValue(true)]
		public virtual bool AutoScroll
		{
			get
			{
				return GetValue(AutoScrollProperty, objDefault: true);
			}
			set
			{
				if (AutoScroll != value)
				{
					if (value)
					{
						RemoveValue(AutoScrollProperty);
					}
					else
					{
						SetValue(AutoScrollProperty, value);
					}
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets a value that specifies the wrap control behavior.
		/// </summary>
		protected internal virtual VersionCompatibilityMode CompatibilityMode => VersionCompatibilityMode.Version6;

		/// 
		/// Gets a value indicating whether this is ASP request.
		/// </summary>
		/// 
		/// 	true</c> if this is ASP request; otherwise, false</c>.
		/// </value>
		[Browsable(false)]
		public bool IsAspRequest
		{
			get
			{
				return GetValue(IsAspRequestProperty, objDefault: false);
			}
			private set
			{
				if (IsAspRequest != value)
				{
					if (!value)
					{
						RemoveValue(IsAspRequestProperty);
					}
					else
					{
						SetValue(IsAspRequestProperty, value);
					}
				}
			}
		}

		/// 
		/// Gets a value indicating whether the hosted control accessing is allowed.
		/// </summary>
		private bool CanAccessHostControl
		{
			get
			{
				if (CompatibilityMode == VersionCompatibilityMode.Version6)
				{
					return Version6CanAccessHostControl;
				}
				if (InDesignMode || !IsCodeControlValid || IsFirstVwgRequest)
				{
					return false;
				}
				return true;
			}
		}

		/// 
		/// Gets a value indicating whether we are in the first vwg request. (ProcessGateway was not called yet.
		/// </summary>
		internal bool IsFirstVwgRequest
		{
			get
			{
				object viewStateInternal = GetViewStateInternal();
				if (!IsAspRequest && viewStateInternal == null)
				{
					return true;
				}
				return false;
			}
		}

		/// 
		/// Get the currently hosted control
		/// </summary>
		protected System.Web.UI.Control HostedControl
		{
			get
			{
				if (CompatibilityMode == VersionCompatibilityMode.Version6)
				{
					return Version6HostedControl;
				}
				if (InDesignMode)
				{
					throw new Exception("Hosted control can not be used in design mode.");
				}
				if (HostedPage == null)
				{
					HostedPage = CreateHostPage();
					if (!IsAspRequest)
					{
						HostedPage.ProcessMainStart();
					}
				}
				return HostedPage.HostedControl;
			}
		}

		/// 
		/// The hosted ASP.NET control type
		/// </summary>
		protected virtual Type HostedControlType => typeof(System.Web.UI.Control);

		/// 
		/// Gets the name of the form.
		/// </summary>
		/// The name of the form.</value>
		private string FormName => $"ctrl1_{base.Name}";

		/// 
		/// Gets the name of the script manager.
		/// </summary>
		/// The name of the script manager.</value>
		private string ScriptManagerName => $"ctrl0_{base.Name}";

		/// 
		/// Gets the control properties.
		/// </summary>
		/// The control properties.</value>
		private Dictionary<string, PropertyInfo> Properties
		{
			get
			{
				return GetValue<Dictionary<string, PropertyInfo>>(PropertiesProperty, null);
			}
			set
			{
				if (Properties != value)
				{
					if (value == null)
					{
						RemoveValue<Dictionary<string, PropertyInfo>>(PropertiesProperty);
					}
					else
					{
						SetValue(PropertiesProperty, value);
					}
				}
			}
		}

		/// 
		/// Gets or sets the design time properties.
		/// </summary>
		/// The design time properties.</value>
		private Dictionary<string, object> DesignTimeProperties
		{
			get
			{
				return GetValue<Dictionary<string, object>>(DesignTimePropertiesProperty, null);
			}
			set
			{
				if (DesignTimeProperties != value)
				{
					if (value == null)
					{
						RemoveValue<Dictionary<string, object>>(DesignTimePropertiesProperty);
					}
					else
					{
						SetValue(DesignTimePropertiesProperty, value);
					}
				}
			}
		}

		/// 
		/// Gets or sets the design time events.
		/// </summary>
		/// The design time events.</value>
		private Dictionary<string, List<object>> DesignTimeEventHandlers
		{
			get
			{
				return GetValue<Dictionary<string, List<object>>>(DesignTimeEventHandlersProperty, null);
			}
			set
			{
				if (DesignTimeEventHandlers != value)
				{
					SetValue(DesignTimeEventHandlersProperty, value);
				}
			}
		}

		/// 
		/// Gets or sets the default design values.
		/// </summary>
		/// The default design values.</value>
		private Dictionary<string, object> DefaultDesignValues
		{
			get
			{
				return GetValue<Dictionary<string, object>>(DefaultDesignValuesProperty, null);
			}
			set
			{
				if (DefaultDesignValues != value)
				{
					if (value == null)
					{
						RemoveValue<Dictionary<string, object>>(DefaultDesignValuesProperty);
					}
					else
					{
						SetValue(DefaultDesignValuesProperty, value);
					}
				}
			}
		}

		/// 
		/// Gets or sets the events.
		/// </summary>
		/// The events.</value>
		private Dictionary<string, EventInfo> EventsList
		{
			get
			{
				return GetValue<Dictionary<string, EventInfo>>(EventsProperty, null);
			}
			set
			{
				if (EventsList != value)
				{
					if (value == null)
					{
						RemoveValue<Dictionary<string, EventInfo>>(EventsProperty);
					}
					else
					{
						SetValue(EventsProperty, value);
					}
				}
			}
		}

		/// 
		/// Gets the events.
		/// </summary>
		/// The events.</value>
		protected Dictionary<string, List<object>> Events => EventHandlers;

		/// 
		/// Gets or sets the event handlers.
		/// </summary>
		/// The event handlers.</value>
		private Dictionary<string, List<object>> EventHandlers
		{
			get
			{
				return GetValue<Dictionary<string, List<object>>>(EventHandlersProperty, null);
			}
			set
			{
				if (EventHandlers != value)
				{
					SetValue(EventHandlersProperty, value);
				}
			}
		}

		/// 
		/// Gets or sets the hosted page.
		/// </summary>
		/// The hosted page.</value>
		private AspPipeLinePage HostedPage
		{
			get
			{
				if (CompatibilityMode == VersionCompatibilityMode.Version6)
				{
					return Version6HostedPage;
				}
				return mobjHostedPage;
			}
			set
			{
				if (CompatibilityMode == VersionCompatibilityMode.Version6)
				{
					Version6HostedPage = value;
				}
				else
				{
					mobjHostedPage = value;
				}
			}
		}

		/// 
		/// Gets or sets the state of the view.
		/// </summary>
		/// The state of the view.</value>
		private object ViewState
		{
			get
			{
				return GetValue(ViewStateProperty, null);
			}
			set
			{
				if (ViewState != value)
				{
					if (value == null)
					{
						RemoveValue(ViewStateProperty);
					}
					else
					{
						SetValue(ViewStateProperty, value);
					}
				}
			}
		}

		/// 
		/// Gets or sets the state of the control.
		/// </summary>
		/// The state of the control.</value>
		private new object ControlState
		{
			get
			{
				return GetValue(ControlStateProperty, null);
			}
			set
			{
				if (ControlState != value)
				{
					if (value == null)
					{
						RemoveValue(ControlStateProperty);
					}
					else
					{
						SetValue(ControlStateProperty, value);
					}
				}
			}
		}

		private bool Version6CanAccessHostControl
		{
			get
			{
				if (InDesignMode || !IsCodeControlValid || !IsParentValid)
				{
					return false;
				}
				return true;
			}
		}

		private System.Web.UI.Control Version6HostedControl
		{
			get
			{
				if (InDesignMode)
				{
					throw new Exception("Hosted control can not be used in design mode.");
				}
				AspPipeLinePage aspPipeLinePage = HostedPage;
				if (aspPipeLinePage == null)
				{
					aspPipeLinePage = CreateHostPage();
					if (!IsAspRequest && !InDesignMode && aspPipeLinePage != null)
					{
						HostedPage = aspPipeLinePage;
						aspPipeLinePage.ProcessMainStart();
					}
				}
				return aspPipeLinePage.HostedControl;
			}
		}

		/// 
		/// Gets or sets the hosted page.
		/// </summary>
		/// The hosted page.</value>
		private AspPipeLinePage Version6HostedPage
		{
			get
			{
				return GetValue(AspPipeLinePageProperty, null);
			}
			set
			{
				if (Version6HostedPage != value)
				{
					if (value == null)
					{
						RemoveValue(AspPipeLinePageProperty);
					}
					else
					{
						SetValue(AspPipeLinePageProperty, value);
					}
				}
			}
		}

		public event AspSubmitHandler Submit;

		/// 
		/// Occurs when the hosted control page loads
		/// </summary>
		public event AspPageEventHandler HostedPageLoad;

		/// 
		///
		/// </summary>
		public event AspPageEventHandler HostedPageError;

		/// 
		///
		/// </summary>
		public event AspPageEventHandler HostedPageLoadComplete;

		/// 
		///
		/// </summary>
		public event AspPageEventHandler HostedPageInitComplete;

		/// 
		///
		/// </summary>
		public event AspPageEventHandler HostedPagePageInit;

		/// 
		///
		/// </summary>
		public event AspPageEventHandler HostedPagePreRenderComplete;

		/// 
		///
		/// </summary>
		public event AspPageEventHandler HostedPagePreRender;

		/// 
		///
		/// </summary>
		public event AspPageEventHandler HostedPagePreLoad;

		/// 
		///
		/// </summary>
		public event AspPageEventHandler HostedPagePreInit;

		/// 
		///
		/// </summary>
		public event AspControlEventHandler HostedControlDisposed;

		/// 
		///
		/// </summary>
		public event AspPageEventHandler HostedPageDisposed;

		/// 
		///
		/// </summary>
		public event AspPageEventHandler HostedHostedPageDataBinding;

		/// 
		///
		/// </summary>
		public event AspControlEventHandler HostedControlDataBinding;

		/// 
		///
		/// </summary>
		public event AspControlEventHandler HostedControlUnload;

		/// 
		///
		/// </summary>
		public event AspControlEventHandler HostedControlPreRender;

		/// 
		///
		/// </summary>
		public event AspControlEventHandler HostedControlLoad;

		/// 
		///
		/// </summary>
		public event AspControlEventHandler HostedControlInit;

		/// Create asp.net control box</summary>
		public AspControlBoxBase()
		{
			Properties = new Dictionary<string, PropertyInfo>();
			EventsList = new Dictionary<string, EventInfo>();
			EventHandlers = new Dictionary<string, List<object>>();
		}

		/// 
		/// Handle the HostedPageProcessStarting event.
		/// </summary>
		private void AspControlBoxBase_HostedPageProcessStarting(object sender, AspPageEventArgs e)
		{
			if (SyncPostData != null)
			{
				EmulatePost(e.Page.Request, SyncPostData);
			}
			mblnProcessMainEndRequired = true;
		}

		/// 
		/// Recieves request and post data collection, and emulates the request as post request.
		/// </summary>
		private void EmulatePost(HttpRequest objRequest, NameValueCollection arrPostData)
		{
			Type systemWebFullTypeName = GetSystemWebFullTypeName("System.Web.HttpValueCollection");
			ConstructorInfo constructorInfo = systemWebFullTypeName.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0];
			NameValueCollection nameValueCollection = constructorInfo.Invoke(new object[0]) as NameValueCollection;
			PropertyInfo property = nameValueCollection.GetType().GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
			property.SetValue(nameValueCollection, false, null);
			for (int i = 0; i < arrPostData.Count; i++)
			{
				nameValueCollection.Add(arrPostData.GetKey(i), arrPostData.Get(i));
			}
			property.SetValue(nameValueCollection, true, null);
			FieldInfo field = typeof(HttpRequest).GetField("_form", BindingFlags.Instance | BindingFlags.NonPublic);
			field.SetValue(objRequest, nameValueCollection);
			FieldInfo field2 = typeof(HttpRequest).GetField("_httpMethod", BindingFlags.Instance | BindingFlags.NonPublic);
			field2.SetValue(objRequest, "POST");
			FieldInfo field3 = typeof(HttpRequest).GetField("_httpVerb", BindingFlags.Instance | BindingFlags.NonPublic);
			Type systemWebFullTypeName2 = GetSystemWebFullTypeName("System.Web.HttpVerb");
			object value = Enum.Parse(systemWebFullTypeName2, "POST");
			field3.SetValue(objRequest, value);
		}

		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			if (objEvent.Type == "SyncVwgChanges" && !IsAspRequest)
			{
				string str = objEvent["PostData"];
				str = HttpUtility.UrlDecode(str);
				str = HttpUtility.HtmlDecode(str);
				NameValueCollection nameValueCollection = new NameValueCollection();
				string[] array = str.Split('&');
				SyncPostData = new NameValueCollection();
				string[] array2 = array;
				foreach (string text in array2)
				{
					string[] array3 = text.Split(new char[1] { '=' }, 2);
					SyncPostData.Add(array3[0], array3[1]);
				}
			}
		}

		/// 
		/// Creates the host page head control.
		/// </summary>
		/// </returns>
		protected virtual HtmlHead CreateHostPageHead()
		{
			HtmlHead htmlHead = new HtmlHead();
			HtmlTitle child = new HtmlTitle();
			htmlHead.Controls.Add(child);
			return htmlHead;
		}

		/// 
		/// Creates the host page form control.
		/// </summary>
		/// </returns>
		protected virtual HtmlForm CreateHostPageForm()
		{
			HtmlForm htmlForm = new HtmlForm();
			htmlForm.ID = FormName;
			return htmlForm;
		}

		/// 
		/// Creates the host page body control.
		/// </summary>
		/// </returns>
		protected virtual HtmlControl CreateHostPageBody()
		{
			HtmlControl htmlControl = new HtmlGenericControl("body");
			htmlControl.Style.Add("margin", "0px");
			if (AutoScroll)
			{
				htmlControl.Style.Add("overflow", "auto");
			}
			else
			{
				htmlControl.Style.Add("overflow", "hidden");
			}
			return htmlControl;
		}

		/// 
		/// Get ASP.NET page
		/// </summary>
		/// </returns>
		private AspPipeLinePage CreateHostPage()
		{
			AspPipeLinePage aspPipeLinePage = new AspPipeLinePage(this);
			aspPipeLinePage.VwgControlId = ID;
			aspPipeLinePage.EnableViewState = true;
			aspPipeLinePage.Load += OnHostedPageLoad;
			aspPipeLinePage.PreInit += OnHostedPagePreInit;
			aspPipeLinePage.PreLoad += OnHostedPagePreLoadInternal;
			aspPipeLinePage.PreRender += OnHostedPagePreRender;
			aspPipeLinePage.PreRenderComplete += OnHostedPagePreRenderComplete;
			aspPipeLinePage.Init += OnHostedPageInit;
			aspPipeLinePage.InitComplete += OnHostedPageInitComplete;
			aspPipeLinePage.LoadComplete += OnHostedPageLoadComplete;
			aspPipeLinePage.Error += OnHostedPageError;
			aspPipeLinePage.DataBinding += OnHostedPageDataBinding;
			aspPipeLinePage.Disposed += OnHostedPageDisposed;
			aspPipeLinePage.PageProcessStarting += AspControlBoxBase_HostedPageProcessStarting;
			HtmlControl htmlControl = new HtmlGenericControl("html");
			aspPipeLinePage.Controls.Add(htmlControl);
			HtmlHead htmlHead = CreateHostPageHead();
			if (htmlHead != null)
			{
				htmlControl.Controls.Add(htmlHead);
			}
			HtmlControl htmlControl2 = CreateHostPageBody();
			if (htmlControl2 == null)
			{
				throw new Exception("CreateHostPageBody method should not return a null value.");
			}
			htmlControl.Controls.Add(htmlControl2);
			HtmlForm htmlForm = CreateHostPageForm();
			if (htmlForm == null)
			{
				throw new Exception("CreateHostPageForm method should not return a null value.");
			}
			htmlControl2.Controls.Add(htmlForm);
			System.Web.UI.Control control = CreateHostedControlContainer(aspPipeLinePage);
			if (control != null)
			{
				htmlForm.Controls.Add(control);
				System.Web.UI.Control control2 = null;
				control2 = control.FindControl(ControlID);
				if (control2 == null)
				{
					throw new Exception($"Could not resolve the hosted control using '{ControlID}' control ID.");
				}
				if (!HostedControlType.IsAssignableFrom(control2.GetType()))
				{
					throw new Exception($"Cannot convert hosted control found using '{ControlID}' control ID to '{HostedControlType.FullName}' type.");
				}
				if (control2 != null)
				{
					control2.Init += OnHostedControlInit;
					control2.Load += OnHostedControlLoad;
					control2.PreRender += OnHostedControlPreRender;
					control2.Unload += OnHostedControlUnload;
					control2.DataBinding += OnHostedControlDataBinding;
					control2.Disposed += OnHostedControlDisposed;
					RestoreControlDesignEvents(control2);
					control2.EnableViewState = true;
					aspPipeLinePage.HostedControl = control2;
				}
			}
			return aspPipeLinePage;
		}

		protected virtual void RestoreControlSize(System.Web.UI.Control objHostedControl)
		{
			if (objHostedControl is WebControl webControl)
			{
				if (!IsFixedSize)
				{
					webControl.Height = new Unit("100%");
					webControl.Width = new Unit("100%");
				}
				else
				{
					webControl.Height = new Unit(base.Height - Padding.Vertical);
					webControl.Width = new Unit(base.Width - Padding.Horizontal);
				}
			}
		}

		/// 
		/// Raises the <see cref="E:Resize" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (IsFixedSize)
			{
				Update(blnRedrawOnly: true);
			}
		}

		/// 
		/// Occurs when the hosting page is loaded.
		/// </summary>
		protected virtual void OnHostedPageLoad(object sender, EventArgs e)
		{
			if (HostedControlForAspUpdate == null)
			{
				this.HostedPageLoad?.Invoke(this, new AspPageEventArgs((Page)sender));
			}
		}

		/// 
		/// Called when hosted page throws error.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnHostedPageError(object sender, EventArgs e)
		{
			this.HostedPageError?.Invoke(this, new AspPageEventArgs((Page)sender));
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnHostedPageLoadComplete(object sender, EventArgs e)
		{
			if (HostedControlForAspUpdate == null)
			{
				this.HostedPageLoadComplete?.Invoke(this, new AspPageEventArgs((Page)sender));
			}
			if (HostedControlForAspUpdate != null)
			{
				System.Web.UI.Control parent = HostedControl.Parent;
				parent.Controls.Clear();
				parent.Controls.Add(HostedControlForAspUpdate);
				HostedPage.HostedControl = HostedControlForAspUpdate;
				HostedControlForAspUpdate = null;
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnHostedPageInitComplete(object sender, EventArgs e)
		{
			if (HostedControlForAspUpdate == null)
			{
				this.HostedPageInitComplete?.Invoke(this, new AspPageEventArgs((Page)sender));
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnHostedPageInit(object sender, EventArgs e)
		{
			if (HostedControlForAspUpdate == null)
			{
				this.HostedPagePageInit?.Invoke(this, new AspPageEventArgs((Page)sender));
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnHostedPagePreRenderComplete(object sender, EventArgs e)
		{
			this.HostedPagePreRenderComplete?.Invoke(this, new AspPageEventArgs((Page)sender));
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnHostedPagePreRender(object sender, EventArgs e)
		{
			this.HostedPagePreRender?.Invoke(this, new AspPageEventArgs((Page)sender));
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHostedPagePreLoadInternal(object sender, EventArgs e)
		{
			RestoreControlSize(HostedControl);
			TryRestoreControlDesignProperties(HostedControl);
			OnHostedPagePreLoad(sender, e);
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnHostedPagePreLoad(object sender, EventArgs e)
		{
			if (HostedControlForAspUpdate == null && this.HostedPagePreLoad != null)
			{
				this.HostedPagePreLoad(this, new AspPageEventArgs((Page)sender));
			}
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnHostedPagePreInit(object sender, EventArgs e)
		{
			this.HostedPagePreInit?.Invoke(this, new AspPageEventArgs((Page)sender));
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnHostedControlDisposed(object sender, EventArgs e)
		{
			this.HostedControlDisposed?.Invoke(this, new AspControlEventArgs((System.Web.UI.Control)sender));
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnHostedPageDisposed(object sender, EventArgs e)
		{
			this.HostedPageDisposed?.Invoke(this, new AspPageEventArgs((Page)sender));
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnHostedPageDataBinding(object sender, EventArgs e)
		{
			this.HostedHostedPageDataBinding?.Invoke(this, new AspPageEventArgs((Page)sender));
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected internal virtual void OnSubmit(object sender, AspSubmitArgs e)
		{
			this.Submit?.Invoke(sender, e);
		}

		/// 
		/// Does the submit.
		/// </summary>
		/// <param name="strEventArgument">The STR event argument.</param>
		public void DoSubmit(string strEventArgument)
		{
			InvokeMethodWithId("Web_SubmitHostedForm", strEventArgument);
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnHostedControlDataBinding(object sender, EventArgs e)
		{
			this.HostedControlDataBinding?.Invoke(this, new AspControlEventArgs((System.Web.UI.Control)sender));
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnHostedControlUnload(object sender, EventArgs e)
		{
			this.HostedControlUnload?.Invoke(this, new AspControlEventArgs((System.Web.UI.Control)sender));
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnHostedControlPreRender(object sender, EventArgs e)
		{
			this.HostedControlPreRender?.Invoke(this, new AspControlEventArgs((System.Web.UI.Control)sender));
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnHostedControlLoad(object sender, EventArgs e)
		{
			this.HostedControlLoad?.Invoke(this, new AspControlEventArgs((System.Web.UI.Control)sender));
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void OnHostedControlInit(object sender, EventArgs e)
		{
			this.HostedControlInit?.Invoke(this, new AspControlEventArgs((System.Web.UI.Control)sender));
		}

		/// 
		/// Creates the hosted control.
		/// </summary>
		/// </returns>
		private System.Web.UI.Control CreateHostedControlContainer(AspPipeLinePage objHostedPage)
		{
			System.Web.UI.UserControl userControl = Activator.CreateInstance(ControlCodeType) as System.Web.UI.UserControl;
			userControl?.InitializeAsUserControl(objHostedPage);
			return userControl;
		}

		/// 
		/// Provides a way to handle gateway requests.
		/// </summary>
		/// <param name="objHttpContext">The gateway request HTTP context.</param>
		/// <param name="strAction">The gateway request action.</param>
		/// 
		/// By default this method returns a instance of a class which implements the IGatewayHandler and
		/// throws a non implemented HttpException.
		/// </returns>
		/// 
		/// This method is called from the implementation of IGatewayComponent which replaces the
		/// IGatewayControl interface. The IGatewayCompoenent is implemented by default in the
		/// RegisteredComponent class which is the base class of most of the Visual WebGui
		/// components.
		/// Referencing a RegisterComponent that overrides this method is done the same way that
		/// a control implementing IGatewayControl, which is by using the GatewayReference class.
		/// </remarks>
		protected override IGatewayHandler ProcessGatewayRequest(HttpContext objHttpContext, string strAction)
		{
			if (objHttpContext == null)
			{
				throw new HttpException("ASP.NET runtime is unavailable.");
			}
			IsAspRequest = true;
			objHttpContext.Response.Buffer = true;
			try
			{
				AspPipeLinePage aspPipeLinePage = HostedPage;
				if (aspPipeLinePage == null)
				{
					aspPipeLinePage = (HostedPage = CreateHostPage());
				}
				if (aspPipeLinePage != null)
				{
					if (CompatibilityMode != VersionCompatibilityMode.Version6)
					{
						if (objHttpContext.Request.HttpMethod == "GET")
						{
							if (SyncPostData != null)
							{
								EmulatePost(objHttpContext.Request, SyncPostData);
							}
						}
						else
						{
							SyncPostData = new NameValueCollection();
							foreach (string item in objHttpContext.Request.Form)
							{
								if (!(item == AspPipeLinePage.VwgPipelineName))
								{
									SyncPostData.Add(item, objHttpContext.Request.Form[item]);
								}
							}
						}
					}
					aspPipeLinePage.ProcessRequest(objHttpContext);
				}
			}
			finally
			{
				IsAspRequest = false;
				HostedPage = null;
			}
			return null;
		}

		/// 
		/// Gets the view state.
		/// </summary>
		/// </returns>
		internal object GetViewStateInternal()
		{
			return ViewState;
		}

		/// 
		/// Sets the view state.
		/// </summary>
		/// <param name="objState">The current view state to set.</param>
		internal void SetViewStateInternal(object objState)
		{
			ViewState = objState;
		}

		/// 
		/// Gets the control state.
		/// </summary>
		/// </returns>
		internal object GetControlStateInternal()
		{
			return ControlState;
		}

		/// 
		/// Sets the control state.
		/// </summary>
		/// <param name="objState">The current control state to set.</param>
		internal void SetControlStateInternal(object objState)
		{
			ControlState = objState;
		}

		/// 
		/// Sets a hosted control property value
		/// </summary>
		/// <param name="strName"></param>
		/// <param name="objValue"></param>
		protected void SetProperty(string strName, object objValue)
		{
			PropertyInfo propertyInfo = GetPropertyInfo(strName);
			if (!(propertyInfo != null) || !propertyInfo.CanWrite)
			{
				return;
			}
			if (!CanAccessHostControl)
			{
				Dictionary<string, object> dictionary = DesignTimeProperties;
				if (dictionary == null)
				{
					dictionary = (DesignTimeProperties = new Dictionary<string, object>());
				}
				dictionary[strName] = objValue;
			}
			else
			{
				propertyInfo.SetValue(HostedControl, objValue, null);
				AspUpdate();
			}
		}

		/// 
		/// Gets a hosted control boolean property value
		/// </summary>
		/// <param name="strName"></param>
		/// </returns>
		protected bool GetBoolProperty(string strName)
		{
			return (bool)GetProperty(strName);
		}

		/// 
		/// Gets a hosted control integer property value
		/// </summary>
		/// <param name="strName"></param>
		/// </returns>
		protected int GetIntProperty(string strName)
		{
			return (int)GetProperty(strName);
		}

		/// 
		/// Gets a hosted control color property value
		/// </summary>
		/// <param name="strName"></param>
		/// </returns>
		protected Color GetColorProperty(string strName)
		{
			return (Color)GetProperty(strName);
		}

		/// 
		/// Resets the specified property.
		/// </summary>
		/// <param name="strPropertyName">The property name.</param>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected void Reset(string strPropertyName)
		{
			PropertyInfo propertyInfo = GetPropertyInfo(strPropertyName);
			if (propertyInfo != null)
			{
				SetProperty(strPropertyName, GetPropertyDefaultValue(propertyInfo));
			}
		}

		/// 
		/// General purpose should serialize method for evaluating property should serialize methods.
		/// </summary>
		/// <param name="strPropertyName">The property name.</param>
		/// </returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected bool ShouldSerialize(string strPropertyName)
		{
			object property = GetProperty(strPropertyName);
			Dictionary<string, object> dictionary = DefaultDesignValues;
			if (dictionary == null)
			{
				dictionary = (DefaultDesignValues = new Dictionary<string, object>());
			}
			if (!dictionary.ContainsKey(strPropertyName))
			{
				PropertyInfo propertyInfo = GetPropertyInfo(strPropertyName);
				if (propertyInfo != null)
				{
					dictionary[strPropertyName] = GetPropertyDefaultValue(propertyInfo);
				}
				else
				{
					dictionary[strPropertyName] = null;
				}
			}
			object obj = dictionary[strPropertyName];
			if (obj == null && property == null)
			{
				return false;
			}
			if ((obj == null && property != null) || (obj != null && property == null))
			{
				return true;
			}
			return !property.Equals(obj);
		}

		/// 
		/// Gets a hosted control property value
		/// </summary>
		/// <param name="strName"></param>
		/// </returns>
		protected object GetProperty(string strName)
		{
			PropertyInfo propertyInfo = GetPropertyInfo(strName);
			if (propertyInfo != null)
			{
				if (!CanAccessHostControl)
				{
					Dictionary<string, object> designTimeProperties = DesignTimeProperties;
					if (designTimeProperties != null && designTimeProperties.ContainsKey(strName))
					{
						return designTimeProperties[strName];
					}
					return GetPropertyDefaultValue(propertyInfo);
				}
				return propertyInfo.GetValue(HostedControl, null);
			}
			return null;
		}

		/// 
		/// Add an event handler to one of the control's event infos.
		/// </summary>
		/// <param name="strName"></param>
		/// <param name="objEventHandler"></param>
		protected void AddEventHandler(string strName, Delegate objEventHandler)
		{
			if (CompatibilityMode == VersionCompatibilityMode.Version6)
			{
				Version6AddEventHandler(strName, objEventHandler);
				return;
			}
			if (CanAccessHostControl)
			{
				AddEventHandler(strName, objEventHandler, HostedControl);
				return;
			}
			Dictionary<string, List<object>> dictionary = DesignTimeEventHandlers;
			if (dictionary == null)
			{
				dictionary = (DesignTimeEventHandlers = new Dictionary<string, List<object>>());
			}
			if (!dictionary.TryGetValue(strName, out var value))
			{
				value = new List<object>();
				dictionary.Add(strName, value);
			}
			value.Add(objEventHandler);
		}

		/// 
		/// Add an event handler to one of the control's event infos.
		/// </summary>
		/// <param name="strName"></param>
		/// <param name="objEventHandler"></param>
		private void AddEventHandler(string strName, Delegate objEventHandler, System.Web.UI.Control objHostedControl)
		{
			EventInfo eventInfo = GetEventInfo(strName);
			if (eventInfo != null)
			{
				GetEventHandlers(strName, blnCreate: true)?.Add(objEventHandler);
				eventInfo.AddEventHandler(objHostedControl, objEventHandler);
			}
		}

		/// 
		/// Removes an event handler from one of the control's event infos.
		/// </summary>
		/// <param name="strName"></param>
		/// <param name="objEventHandler"></param>
		protected void RemoveEventHandler(string strName, Delegate objEventHandler)
		{
			if (CompatibilityMode == VersionCompatibilityMode.Version6)
			{
				Version6RemoveEventHandler(strName, objEventHandler);
			}
			else if (CanAccessHostControl)
			{
				EventInfo eventInfo = GetEventInfo(strName);
				if (eventInfo != null)
				{
					List<object> eventHandlers = GetEventHandlers(strName, blnCreate: false);
					if (eventHandlers != null && eventHandlers.Contains(objEventHandler))
					{
						eventHandlers.Remove(objEventHandler);
					}
				}
			}
			else
			{
				Dictionary<string, List<object>> designTimeEventHandlers = DesignTimeEventHandlers;
				if (designTimeEventHandlers != null && designTimeEventHandlers.TryGetValue(strName, out var value))
				{
					value.Remove(objEventHandler);
				}
			}
		}

		/// 
		/// Gets the event handlers for a given event.
		/// </summary>
		/// <param name="strName">Name of the STR.</param>
		/// </returns>
		private List<object> GetEventHandlers(string strName)
		{
			return GetEventHandlers(strName, blnCreate: false);
		}

		/// 
		/// Gets the event handlers for a given event.
		/// </summary>
		/// <param name="strName">Name of the STR.</param>
		/// <param name="blnCreate">if set to true</c> [BLN create].</param>
		/// </returns>
		private List<object> GetEventHandlers(string strName, bool blnCreate)
		{
			List<object> list = null;
			Dictionary<string, List<object>> eventHandlers = EventHandlers;
			if (eventHandlers.ContainsKey(strName) && eventHandlers[strName] != null)
			{
				list = eventHandlers[strName];
			}
			if (list == null && blnCreate)
			{
				list = new List<object>();
				eventHandlers.Add(strName, list);
			}
			return list;
		}

		/// 
		/// Recieve system.web type name (Without assembly) and return its type.
		/// </summary>
		private Type GetSystemWebFullTypeName(string typeName)
		{
			string typeName2 = typeName + ", " + CommonUtils.GetFullAssemblyName("System.Web");
			return Type.GetType(typeName2);
		}

		/// 
		/// Gets the property default value.
		/// </summary>
		/// <param name="objPropertyInfo">The property info.</param>
		/// </returns>
		private object GetPropertyDefaultValue(PropertyInfo objPropertyInfo)
		{
			object obj = null;
			Type propertyType = objPropertyInfo.PropertyType;
			object[] array = new object[0];
			while (array.Length == 0 && objPropertyInfo.ReflectedType.BaseType != null)
			{
				array = objPropertyInfo.GetCustomAttributes(typeof(DefaultValueAttribute), inherit: true);
				if (objPropertyInfo.ReflectedType.BaseType.GetProperty(objPropertyInfo.Name) != null)
				{
					objPropertyInfo = objPropertyInfo.ReflectedType.BaseType.GetProperty(objPropertyInfo.Name);
					continue;
				}
				break;
			}
			if (array.Length != 0 && ((DefaultValueAttribute)array[0]).Value != null && objPropertyInfo.PropertyType == ((DefaultValueAttribute)array[0]).Value.GetType())
			{
				return ((DefaultValueAttribute)array[0]).Value;
			}
			return CommonUtils.GetTypeDefaultValue(propertyType);
		}

		/// 
		/// Get an event information object.
		/// </summary>
		/// <param name="strName"></param>
		/// </returns>
		protected EventInfo GetEventInfo(string strName)
		{
			EventInfo eventInfo = null;
			Dictionary<string, EventInfo> eventsList = EventsList;
			if (eventsList.ContainsKey(strName))
			{
				eventInfo = eventsList[strName];
			}
			if (eventInfo == null)
			{
				eventInfo = (eventsList[strName] = HostedControlType.GetEvent(strName));
			}
			return eventInfo;
		}

		/// 
		/// Get property info
		/// </summary>
		/// <param name="strName"></param>
		/// </returns>
		protected PropertyInfo GetPropertyInfo(string strName)
		{
			PropertyInfo propertyInfo = null;
			Dictionary<string, PropertyInfo> properties = Properties;
			if (properties.ContainsKey(strName))
			{
				propertyInfo = properties[strName];
			}
			else if (propertyInfo == null)
			{
				propertyInfo = (properties[strName] = HostedControlType.GetProperty(strName));
			}
			return propertyInfo;
		}

		/// 
		/// Restores hosted control events
		/// </summary>
		private void RestoreControlDesignEvents(System.Web.UI.Control objHostedControl)
		{
			if (objHostedControl == null)
			{
				return;
			}
			if (CompatibilityMode != VersionCompatibilityMode.Version6)
			{
				Dictionary<string, List<object>> designTimeEventHandlers = DesignTimeEventHandlers;
				if (designTimeEventHandlers != null)
				{
					string[] array = new string[designTimeEventHandlers.Keys.Count];
					designTimeEventHandlers.Keys.CopyTo(array, 0);
					string[] array2 = array;
					foreach (string text in array2)
					{
						List<object> list = designTimeEventHandlers[text];
						foreach (Delegate item in list)
						{
							AddEventHandler(text, item, objHostedControl);
						}
					}
					DesignTimeEventHandlers = null;
				}
			}
			Dictionary<string, EventInfo> eventsList = EventsList;
			foreach (EventInfo value in eventsList.Values)
			{
				List<object> eventHandlers = GetEventHandlers(value.Name, blnCreate: false);
				if (eventHandlers == null)
				{
					continue;
				}
				foreach (Delegate item2 in eventHandlers)
				{
					value.AddEventHandler(objHostedControl, item2);
				}
			}
		}

		/// 
		/// Restores hosted control properties
		/// </summary>
		private void TryRestoreControlDesignProperties(System.Web.UI.Control objHostedControl)
		{
			if (objHostedControl == null)
			{
				return;
			}
			Dictionary<string, object> designTimeProperties = DesignTimeProperties;
			if (designTimeProperties != null)
			{
				string[] array = new string[designTimeProperties.Keys.Count];
				designTimeProperties.Keys.CopyTo(array, 0);
				string[] array2 = array;
				foreach (string text in array2)
				{
					SetProperty(text, designTimeProperties[text]);
				}
				DesignTimeProperties = null;
			}
		}

		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			RenderSyncChangesOnVwgPostBack(objWriter, blnForce: false);
		}

		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				RenderSyncChangesOnVwgPostBack(objWriter, blnForce: true);
			}
		}

		private void RenderSyncChangesOnVwgPostBack(IAttributeWriter objWriter, bool blnForce)
		{
			if (CompatibilityMode == VersionCompatibilityMode.Version6)
			{
				objWriter.WriteAttributeString("SCV", "0");
			}
			else if (SyncChangesOnVwgPostBack != SyncPostDataChangesMode.None)
			{
				string strValue = ((SyncChangesOnVwgPostBack == SyncPostDataChangesMode.On) ? "1" : "0");
				objWriter.WriteAttributeString("SCV", strValue);
			}
			else if (blnForce)
			{
				objWriter.WriteAttributeString("SCV", "");
			}
		}

		public void AspUpdate()
		{
			if (CompatibilityMode != VersionCompatibilityMode.Version6 && !IsAspRequest && !IsFirstVwgRequest)
			{
				mblnAspUpdate = true;
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
			base.Render(objContext, objWriter, lngRequestID);
			if (CompatibilityMode == VersionCompatibilityMode.Version6)
			{
				Version6Render(objContext, objWriter, lngRequestID);
			}
		}

		protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
		{
			base.PreRenderControl(objContext, lngRequestID);
			if (mblnAspUpdate)
			{
				VWGClientContext.Current.Invoke(this, "AspControlBoxBase_UpdateAspControl", ID);
				HostedControlForAspUpdate = HostedControl;
				mblnProcessMainEndRequired = false;
			}
			else if (mblnProcessMainEndRequired)
			{
				HostedPage.ProcessMainEnd();
				mblnProcessMainEndRequired = false;
			}
			if (!IsAspRequest)
			{
				HostedPage = null;
			}
			mblnAspUpdate = false;
		}

		private bool ShouldSerializeScripts()
		{
			if (Scripts.Length == 0)
			{
				return false;
			}
			return true;
		}

		private bool ShouldSerializeStyles()
		{
			if (Styles.Length == 0)
			{
				return false;
			}
			return true;
		}

		private void Version6AddEventHandler(string strName, Delegate objEventHandler)
		{
			EventInfo eventInfo = GetEventInfo(strName);
			if (eventInfo != null)
			{
				GetEventHandlers(strName, blnCreate: true)?.Add(objEventHandler);
				if (!InDesignMode && HostedControl != null)
				{
					eventInfo.AddEventHandler(HostedControl, objEventHandler);
				}
			}
		}

		protected void Version6RemoveEventHandler(string strName, Delegate objEventHandler)
		{
			EventInfo eventInfo = GetEventInfo(strName);
			if (eventInfo != null)
			{
				List<object> eventHandlers = GetEventHandlers(strName, blnCreate: false);
				if (eventHandlers != null && eventHandlers.Contains(objEventHandler))
				{
					eventHandlers.Remove(objEventHandler);
				}
				if (!InDesignMode)
				{
					eventInfo.RemoveEventHandler(HostedControl, objEventHandler);
				}
			}
		}

		private void Version6Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			AspPipeLinePage hostedPage = HostedPage;
			if (hostedPage != null && !IsAspRequest)
			{
				hostedPage.ProcessMainEnd();
				HostedPage = null;
			}
		}
	}
}
