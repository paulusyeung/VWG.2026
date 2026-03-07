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
	/// Provides an System.Web.UI.Page implementation that adds state management and visual webgui pipeline integration
	/// </summary>
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AspPipeLinePage : Page, ICallbackEventHandler
	{
		/// 
		///
		/// </summary>
		public class AspPipLineSimpleWorkerRequest : SimpleWorkerRequest
		{
			private string mstrUserAgent = string.Empty;

			/// 
			/// Returns the standard HTTP request header that corresponds to the specified index.
			/// </summary>
			/// <param name="index">The index of the header. For example, the <see cref="F:System.Web.HttpWorkerRequest.HeaderAllow" /> field.</param>
			/// The HTTP request header.</returns>
			public override string GetKnownRequestHeader(int index)
			{
				return mstrUserAgent;
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspPipeLinePage.AspPipLineSimpleWorkerRequest" /> class.
			/// </summary>
			/// <param name="strPage">The page.</param>
			/// <param name="strQuery">The query.</param>
			/// <param name="objOutput">The output.</param>
			/// <param name="strUserAgent">The user agent.</param>
			public AspPipLineSimpleWorkerRequest(string strPage, string strQuery, TextWriter objOutput, string strUserAgent)
				: base(strPage, strQuery, objOutput)
			{
				mstrUserAgent = strUserAgent;
			}
		}

		/// 
		/// Provides view / control state for the asp control box control
		/// </summary>
		[Serializable]
		protected class AspControlBoxStatePersister : PageStatePersister
		{
			/// 
			/// The owning asp control box
			/// </summary>
			private AspControlBoxBase mobjAspControlBox = null;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspPipeLinePage.AspControlBoxStatePersister" /> class.
			/// </summary>
			/// <param name="objAspPipeLinePage">The aspnet page.</param>
			/// <param name="objAspControlBox">The hosting Visual WebGui control.</param>
			public AspControlBoxStatePersister(AspPipeLinePage objAspPipeLinePage, AspControlBoxBase objAspControlBox)
				: base(objAspPipeLinePage)
			{
				mobjAspControlBox = objAspControlBox;
			}

			/// 
			/// Overridden by derived classes to deserialize and load persisted state information when a <see cref="T:System.Web.UI.Page" /> object initializes its control hierarchy.
			/// </summary>
			public override void Load()
			{
				base.ControlState = mobjAspControlBox.GetControlStateInternal();
				base.ViewState = mobjAspControlBox.GetViewStateInternal();
			}

			/// 
			/// Overridden by derived classes to serialize persisted state information when a <see cref="T:System.Web.UI.Page" /> object is unloaded from memory.
			/// </summary>
			public override void Save()
			{
				mobjAspControlBox.SetControlStateInternal(base.ControlState);
				mobjAspControlBox.SetViewStateInternal(base.ViewState);
			}
		}

		/// 
		/// WebForms hidden field that renders the hidden field with static Id + static name. (The Id+name will be rendered to the client without any changes made by ASPNET infrustructure)
		/// NOTE: In order the hidden field will recieve post data, there needs to be a FindControl implementation in the Page. (For more details look at AspPipeLinePage.FindControl method)
		/// </summary>
		[ToolboxItem("")]
		private class HiddenField : System.Web.UI.WebControls.HiddenField
		{
			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspPipeLinePage.HiddenField" /> class.
			/// </summary>
			public HiddenField()
			{
			}

			/// 
			/// Renders the Web server control content to the client's browser using the specified <see cref="T:System.Web.UI.HtmlTextWriter" /> object.
			/// </summary>
			/// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object used to render the server control content on the client's browser.</param>
			protected override void Render(HtmlTextWriter writer)
			{
				writer.Write("<input id='{0}' name='{0}' type='hidden' value='{1}'/>", ID, Value);
			}
		}

		internal static string VwgPipelineName = "vwg_pipeline";

		/// 
		/// The vwg control id.
		/// </summary>
		private long mlngVwgControlId;

		/// 
		/// The Visual WebGui asp.net pipeline field
		/// </summary>
		private HiddenField mobjPipeline = null;

		/// 
		/// The Visual WebGui request ID
		/// </summary>
		private long mlngRequestId = 0L;

		/// 
		/// The asp pipeline page state persister
		/// </summary>
		private PageStatePersister mobjPageStatePersister = null;

		/// 
		/// The hosted asp.net controls (used from AspControlBoxBase).
		/// </summary>
		private System.Web.UI.Control mobjHostedControl = null;

		/// 
		/// Indicates if the pipeline is header based
		/// </summary>
		private string mstrHeaderPipeline = null;

		private AspControlBoxBase mobjAspControlBox = null;

		/// 
		/// Gets the compatibility mode.
		/// </summary>
		private AspControlBoxBase.VersionCompatibilityMode CompatibilityMode
		{
			get
			{
				if (mobjAspControlBox == null)
				{
					return AspControlBoxBase.VersionCompatibilityMode.Version72;
				}
				return mobjAspControlBox.CompatibilityMode;
			}
		}

		/// 
		/// Gets and sets the id of the vwg control that wraps the page.
		/// </summary>
		public long VwgControlId
		{
			get
			{
				return mlngVwgControlId;
			}
			set
			{
				mlngVwgControlId = value;
			}
		}

		/// 
		/// Gets the <see cref="T:System.Web.UI.PageStatePersister" /> object associated with the page.
		/// </summary>
		/// </value>
		/// A <see cref="T:System.Web.UI.PageStatePersister" /> associated with the page.</returns>
		protected override PageStatePersister PageStatePersister
		{
			get
			{
				if (mobjPageStatePersister != null)
				{
					return mobjPageStatePersister;
				}
				return base.PageStatePersister;
			}
		}

		/// 
		/// Gets or sets the hosted control.
		/// </summary>
		/// The hosted control.</value>
		internal System.Web.UI.Control HostedControl
		{
			get
			{
				return mobjHostedControl;
			}
			set
			{
				mobjHostedControl = value;
			}
		}

		public event AspPageEventHandler PageProcessStarting;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspPipeLinePage" /> class.
		/// </summary>
		public AspPipeLinePage()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspPipeLinePage" /> class.
		/// </summary>
		/// <param name="objAspControlBox">The ASP control box.</param>
		internal AspPipeLinePage(AspControlBoxBase objAspControlBox)
		{
			mobjAspControlBox = objAspControlBox;
			mobjPageStatePersister = new AspControlBoxStatePersister(this, objAspControlBox);
		}

		/// 
		/// Returns a <see cref="T:System.Collections.Specialized.NameValueCollection" /> of data posted back to the page using either a POST or a GET command.
		/// </summary>
		/// 
		/// A <see cref="T:System.Collections.Specialized.NameValueCollection" /> object that contains the form data. If the postback used the POST command, the form information is returned from the <see cref="P:System.Web.UI.Page.Context" /> object. If the postback used the GET command, the query string information is returned. If the page is being requested for the first time, null is returned.
		/// </returns>
		protected override NameValueCollection DeterminePostBackMode()
		{
			if (CompatibilityMode == AspControlBoxBase.VersionCompatibilityMode.Version6)
			{
				return Version6DeterminePostBackMode();
			}
			NameValueCollection nameValueCollection = base.DeterminePostBackMode();
			if (mobjAspControlBox == null)
			{
				return nameValueCollection;
			}
			if (!base.IsCallback && nameValueCollection == null && !mobjAspControlBox.IsAspRequest && !mobjAspControlBox.IsFirstVwgRequest)
			{
				nameValueCollection = new NameValueCollection();
			}
			return nameValueCollection;
		}

		/// 
		/// Called when the page is initialized
		/// </summary>
		/// <param name="e"></param>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			if (base.Form != null)
			{
				mobjPipeline = base.Form.FindControl(VwgPipelineName) as HiddenField;
				if (mobjPipeline == null)
				{
					mobjPipeline = new HiddenField();
					mobjPipeline.ID = VwgPipelineName;
					base.Form.Controls.Add(mobjPipeline);
					HiddenField hiddenField = new HiddenField();
					hiddenField.ID = "vwg_data_id";
					hiddenField.Value = VwgControlId.ToString();
					base.Form.Controls.Add(hiddenField);
					string text = string.Empty;
					Config instance = Config.GetInstance();
					if (instance != null)
					{
						text = instance.DynamicExtension;
					}
					string url = "Resources.Gizmox.WebGUI.Forms.Skins.CommonSkin.PipeLine.js" + text;
					if (mobjAspControlBox != null)
					{
						string[] scripts = mobjAspControlBox.Scripts;
						foreach (string text2 in scripts)
						{
							base.ClientScript.RegisterClientScriptInclude(GetType(), text2, text2);
						}
						string[] styles = mobjAspControlBox.Styles;
						foreach (string text3 in styles)
						{
							string script = $"<link href='{text3}' rel='stylesheet' type='text/css'/>";
							Page.ClientScript.RegisterClientScriptBlock(GetType(), text3, script);
						}
					}
					if (mobjAspControlBox != null)
					{
						string[] scripts2 = mobjAspControlBox.Scripts;
						foreach (string text4 in scripts2)
						{
							base.ClientScript.RegisterClientScriptInclude(GetType(), text4, text4);
						}
						string[] styles2 = mobjAspControlBox.Styles;
						foreach (string text5 in styles2)
						{
							string script2 = $"<link href='{text5}' rel='stylesheet' type='text/css'/>";
							base.ClientScript.RegisterClientScriptBlock(GetType(), text5, script2, addScriptTags: false);
						}
					}
					base.ClientScript.RegisterOnSubmitStatement(typeof(AspPipeLinePage), "vwg_pipeline_submit_handler", "vwg_pipeline_onsubmit(document);");
					base.ClientScript.RegisterClientScriptInclude(typeof(AspPipeLinePage), "vwg_pipeline_code", url);
					base.ClientScript.RegisterStartupScript(typeof(AspPipeLinePage), "vwg_set_vwg_form", $"window.vwgForm = document.getElementById('{base.Form.ClientID}');", addScriptTags: true);
					base.ClientScript.RegisterStartupScript(typeof(AspPipeLinePage), "vwg_pipeline_load_handler", "setTimeout('vwg_pipeline_onload(document)',10);", addScriptTags: true);
					base.ClientScript.RegisterClientScriptBlock(typeof(AspPipeLinePage), "vwg_pipeline_submit", "function vwg_pipeline_submit(strArgument) {" + base.ClientScript.GetCallbackEventReference(this, "strArgument", "null", null) + "}", addScriptTags: true);
				}
			}
			mstrHeaderPipeline = base.Request.Headers[VwgPipelineName];
			if (!string.IsNullOrEmpty(mstrHeaderPipeline))
			{
				base.Response.Buffer = true;
			}
		}

		/// 
		/// Raises the <see cref="E:System.Web.UI.Control.Unload" /> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> object that contains event data.</param>
		protected override void OnUnload(EventArgs e)
		{
			base.OnUnload(e);
			if (base.IsCallback && !string.IsNullOrEmpty(mstrHeaderPipeline))
			{
				HttpContext.Current?.Response?.AddHeader(VwgPipelineName, GetPipelineResponse());
			}
		}

		/// 
		/// Called before the page is loaded to get the pipeline events
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPreLoad(EventArgs e)
		{
			if (!string.IsNullOrEmpty(mstrHeaderPipeline))
			{
				if (VWGContext.Current is IContextPipeline contextPipeline)
				{
					mlngRequestId = contextPipeline.ProcessRequest(mstrHeaderPipeline);
				}
			}
			else if (mobjPipeline != null)
			{
				string value = mobjPipeline.Value;
				if (!string.IsNullOrEmpty(value))
				{
					value = HttpUtility.UrlDecode(value);
					if (VWGContext.Current is IContextPipeline contextPipeline2)
					{
						mlngRequestId = contextPipeline2.ProcessRequest(value);
					}
				}
			}
			base.OnPreLoad(e);
		}

		/// 
		/// Generates an update command to the pipeline field
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPreRender(EventArgs e)
		{
			if (string.IsNullOrEmpty(mstrHeaderPipeline) && mobjPipeline != null)
			{
				mobjPipeline.Value = GetPipelineResponse();
			}
			if (!base.IsCallback && !string.IsNullOrEmpty(mstrHeaderPipeline))
			{
				HttpContext.Current.Response?.AddHeader(VwgPipelineName, GetPipelineResponse());
			}
			base.OnPreRender(e);
		}

		/// 
		/// Gets the pipeline response.
		/// </summary>
		/// </returns>
		private string GetPipelineResponse()
		{
			if (mlngRequestId > 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				StringWriter objOutput = new StringWriter(stringBuilder);
				if (VWGContext.Current is IContextPipeline contextPipeline)
				{
					contextPipeline.GenerateResponse(objOutput, mlngRequestId);
				}
				return stringBuilder.ToString();
			}
			return "";
		}

		/// 
		/// Raises the PageProcessStarting event.
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnPageProcessStarting(AspPageEventArgs e)
		{
			if (this.PageProcessStarting != null)
			{
				this.PageProcessStarting(this, e);
			}
		}

		/// 
		/// Processes the main start.
		/// </summary>
		internal void ProcessMainStart()
		{
			AspPipLineSimpleWorkerRequest wr = new AspPipLineSimpleWorkerRequest("~/Main.wgx", "", new StreamWriter(new MemoryStream()), Context.Request.UserAgent);
			HttpContext httpContext = new HttpContext(wr);
			httpContext.Items["AspSession"] = Context.Session;
			InvokeMethod("SetIntrinsics", new object[1] { httpContext }, new Type[1] { typeof(HttpContext) });
			OnPageProcessStarting(new AspPageEventArgs(this));
			NameValueCollection nameValueCollection = null;
			nameValueCollection = ((base.PageAdapter == null) ? DeterminePostBackMode() : base.PageAdapter.DeterminePostBackMode());
			SetMemberValue("_requestValueCollection", nameValueCollection);
			InvokeMethod("PerformPreInit");
			InvokeMethod("InitRecursive", new object[1]);
			InvokeMethod("OnInitComplete", EventArgs.Empty);
			InvokeMethod("LoadAllState");
			InvokeMethod("ProcessPostData", nameValueCollection, true);
			InvokeMethod("OnPreLoad", EventArgs.Empty);
			InvokeMethod("LoadRecursive");
			NameValueCollection nameValueCollection2 = GetMemberValue("_leftoverPostData") as NameValueCollection;
			InvokeMethod("ProcessPostData", nameValueCollection2, false);
			InvokeMethod("RaiseChangedEvents");
			InvokeMethod("RaisePostBackEvent", new object[1] { nameValueCollection }, new Type[1] { typeof(NameValueCollection) });
			InvokeMethod("OnLoadComplete", EventArgs.Empty);
		}

		/// 
		/// Processes the main end.
		/// </summary>
		internal void ProcessMainEnd()
		{
			if (CompatibilityMode == AspControlBoxBase.VersionCompatibilityMode.Version6)
			{
				Version6ProcessMainEnd();
				return;
			}
			if (!base.IsCrossPagePostBack)
			{
				InvokeMethod("PreRenderRecursiveInternal");
			}
			InvokeMethod("PerformPreRenderComplete");
			InvokeMethod("SaveAllState");
			InvokeMethod("OnSaveStateComplete", EventArgs.Empty);
		}

		/// 
		/// Sets the member value.
		/// </summary>
		/// <param name="strMemberName">Name of the STR member.</param>
		/// <param name="objValue">The obj value.</param>
		private void SetMemberValue(string strMemberName, object objValue)
		{
			FieldInfo field = typeof(Page).GetField(strMemberName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
			if (field != null)
			{
				field.SetValue(this, objValue);
			}
		}

		/// 
		/// Gets the member value.
		/// </summary>
		/// <param name="strMemberName">Name of the STR member.</param>
		/// </returns>
		private object GetMemberValue(string strMemberName)
		{
			FieldInfo field = typeof(Page).GetField(strMemberName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
			if (field != null)
			{
				return field.GetValue(this);
			}
			return null;
		}

		/// 
		/// Invokes the method.
		/// </summary>
		/// <param name="strMethodName">Name of the STR method.</param>
		/// <param name="arrArguments">The obj arguments.</param>
		private void InvokeMethod(string strMethodName, params object[] arrArguments)
		{
			MethodInfo method = typeof(Page).GetMethod(strMethodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
			if (method != null)
			{
				method.Invoke(this, arrArguments);
			}
		}

		/// 
		/// Invokes the method.
		/// </summary>
		/// <param name="strMethodName">Name of the STR method.</param>
		/// <param name="objArguments">The obj arguments.</param>
		/// <param name="objTypes">The obj types.</param>
		private void InvokeMethod(string strMethodName, object[] arrArguments, Type[] arrTypes)
		{
			MethodInfo method = typeof(Page).GetMethod(strMethodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, null, arrTypes, null);
			if (method != null)
			{
				method.Invoke(this, arrArguments);
			}
		}

		public override System.Web.UI.Control FindControl(string id)
		{
			if (id == VwgPipelineName)
			{
				return mobjPipeline;
			}
			return base.FindControl(id);
		}

		/// 
		/// Returns the results of a callback event that targets a control.
		/// </summary>
		/// The result of the callback.</returns>
		string ICallbackEventHandler.GetCallbackResult()
		{
			return string.Empty;
		}

		/// 
		/// Raises the callback event.
		/// </summary>
		/// <param name="strEventArgument">The event argument.</param>
		void ICallbackEventHandler.RaiseCallbackEvent(string strEventArgument)
		{
			if (mobjAspControlBox != null)
			{
				mobjAspControlBox.OnSubmit(mobjAspControlBox, new AspSubmitArgs(strEventArgument));
			}
		}

		/// 
		/// Returns a <see cref="T:System.Collections.Specialized.NameValueCollection" /> of data posted back to the page using either a POST or a GET command.
		/// </summary>
		/// 
		/// A <see cref="T:System.Collections.Specialized.NameValueCollection" /> object that contains the form data. If the postback used the POST command, the form information is returned from the <see cref="P:System.Web.UI.Page.Context" /> object. If the postback used the GET command, the query string information is returned. If the page is being requested for the first time, null is returned.
		/// </returns>
		private NameValueCollection Version6DeterminePostBackMode()
		{
			NameValueCollection nameValueCollection = base.DeterminePostBackMode();
			if (!base.IsCallback && nameValueCollection == null)
			{
				nameValueCollection = new NameValueCollection();
			}
			return nameValueCollection;
		}

		/// 
		/// Processes the main end.
		/// </summary>
		internal void Version6ProcessMainEnd()
		{
			InvokeMethod("PerformPreRenderComplete");
			InvokeMethod("SaveAllState");
			InvokeMethod("OnSaveStateComplete", EventArgs.Empty);
		}
	}
}
