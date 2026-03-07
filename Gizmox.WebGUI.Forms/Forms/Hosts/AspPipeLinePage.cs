// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Hosts.AspPipeLinePage
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Interfaces;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>
  /// Provides an System.Web.UI.Page implementation that adds state management and visual webgui pipeline integration
  /// </summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  [Serializable]
  public class AspPipeLinePage : Page, ICallbackEventHandler
  {
    internal static string VwgPipelineName = "vwg_pipeline";
    /// <summary>The vwg control id.</summary>
    private long mlngVwgControlId;
    /// <summary>The Visual WebGui asp.net pipeline field</summary>
    private AspPipeLinePage.HiddenField mobjPipeline;
    /// <summary>The Visual WebGui request ID</summary>
    private long mlngRequestId;
    /// <summary>The asp pipeline page state persister</summary>
    private PageStatePersister mobjPageStatePersister;
    /// <summary>
    /// The hosted asp.net controls (used from AspControlBoxBase).
    /// </summary>
    private System.Web.UI.Control mobjHostedControl;
    /// <summary>Indicates if the pipeline is header based</summary>
    private string mstrHeaderPipeline;
    private AspControlBoxBase mobjAspControlBox;

    public event AspPageEventHandler PageProcessStarting;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspPipeLinePage" /> class.
    /// </summary>
    public AspPipeLinePage()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspPipeLinePage" /> class.
    /// </summary>
    /// <param name="objAspControlBox">The ASP control box.</param>
    internal AspPipeLinePage(AspControlBoxBase objAspControlBox)
    {
      this.mobjAspControlBox = objAspControlBox;
      this.mobjPageStatePersister = (PageStatePersister) new AspPipeLinePage.AspControlBoxStatePersister(this, objAspControlBox);
    }

    /// <summary>
    /// Returns a <see cref="T:System.Collections.Specialized.NameValueCollection" /> of data posted back to the page using either a POST or a GET command.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Collections.Specialized.NameValueCollection" /> object that contains the form data. If the postback used the POST command, the form information is returned from the <see cref="P:System.Web.UI.Page.Context" /> object. If the postback used the GET command, the query string information is returned. If the page is being requested for the first time, null is returned.
    /// </returns>
    protected override NameValueCollection DeterminePostBackMode()
    {
      if (this.CompatibilityMode == AspControlBoxBase.VersionCompatibilityMode.Version6)
        return this.Version6DeterminePostBackMode();
      NameValueCollection postBackMode = base.DeterminePostBackMode();
      if (this.mobjAspControlBox == null || this.IsCallback || postBackMode != null || this.mobjAspControlBox.IsAspRequest || this.mobjAspControlBox.IsFirstVwgRequest)
        return postBackMode;
      postBackMode = new NameValueCollection();
      return postBackMode;
    }

    /// <summary>Gets the compatibility mode.</summary>
    private AspControlBoxBase.VersionCompatibilityMode CompatibilityMode => this.mobjAspControlBox == null ? AspControlBoxBase.VersionCompatibilityMode.Version72 : this.mobjAspControlBox.CompatibilityMode;

    /// <summary>Called when the page is initialized</summary>
    /// <param name="e"></param>
    protected override void OnInit(EventArgs e)
    {
      base.OnInit(e);
      if (this.Form != null)
      {
        this.mobjPipeline = this.Form.FindControl(AspPipeLinePage.VwgPipelineName) as AspPipeLinePage.HiddenField;
        if (this.mobjPipeline == null)
        {
          this.mobjPipeline = new AspPipeLinePage.HiddenField();
          this.mobjPipeline.ID = AspPipeLinePage.VwgPipelineName;
          this.Form.Controls.Add((System.Web.UI.Control) this.mobjPipeline);
          AspPipeLinePage.HiddenField child = new AspPipeLinePage.HiddenField();
          child.ID = "vwg_data_id";
          child.Value = this.VwgControlId.ToString();
          this.Form.Controls.Add((System.Web.UI.Control) child);
          string str1 = string.Empty;
          Config instance = Config.GetInstance();
          if (instance != null)
            str1 = instance.DynamicExtension;
          string url = "Resources.Gizmox.WebGUI.Forms.Skins.CommonSkin.PipeLine.js" + str1;
          if (this.mobjAspControlBox != null)
          {
            foreach (string script in this.mobjAspControlBox.Scripts)
            {
              ClientScriptManager clientScript = this.ClientScript;
              Type type = this.GetType();
              string str2 = script;
              clientScript.RegisterClientScriptInclude(type, str2, str2);
            }
            foreach (string style in this.mobjAspControlBox.Styles)
            {
              string script = string.Format("<link href='{0}' rel='stylesheet' type='text/css'/>", (object) style);
              this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), style, script);
            }
          }
          if (this.mobjAspControlBox != null)
          {
            foreach (string script in this.mobjAspControlBox.Scripts)
            {
              ClientScriptManager clientScript = this.ClientScript;
              Type type = this.GetType();
              string str3 = script;
              clientScript.RegisterClientScriptInclude(type, str3, str3);
            }
            foreach (string style in this.mobjAspControlBox.Styles)
            {
              string script = string.Format("<link href='{0}' rel='stylesheet' type='text/css'/>", (object) style);
              this.ClientScript.RegisterClientScriptBlock(this.GetType(), style, script, false);
            }
          }
          this.ClientScript.RegisterOnSubmitStatement(typeof (AspPipeLinePage), "vwg_pipeline_submit_handler", "vwg_pipeline_onsubmit(document);");
          this.ClientScript.RegisterClientScriptInclude(typeof (AspPipeLinePage), "vwg_pipeline_code", url);
          this.ClientScript.RegisterStartupScript(typeof (AspPipeLinePage), "vwg_set_vwg_form", string.Format("window.vwgForm = document.getElementById('{0}');", (object) this.Form.ClientID), true);
          this.ClientScript.RegisterStartupScript(typeof (AspPipeLinePage), "vwg_pipeline_load_handler", "setTimeout('vwg_pipeline_onload(document)',10);", true);
          this.ClientScript.RegisterClientScriptBlock(typeof (AspPipeLinePage), "vwg_pipeline_submit", "function vwg_pipeline_submit(strArgument) {" + this.ClientScript.GetCallbackEventReference((System.Web.UI.Control) this, "strArgument", "null", (string) null) + "}", true);
        }
      }
      this.mstrHeaderPipeline = this.Request.Headers[AspPipeLinePage.VwgPipelineName];
      if (string.IsNullOrEmpty(this.mstrHeaderPipeline))
        return;
      this.Response.Buffer = true;
    }

    /// <summary>
    /// Raises the <see cref="E:System.Web.UI.Control.Unload" /> event.
    /// </summary>
    /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains event data.</param>
    protected override void OnUnload(EventArgs e)
    {
      base.OnUnload(e);
      if (!this.IsCallback || string.IsNullOrEmpty(this.mstrHeaderPipeline))
        return;
      HttpContext.Current?.Response?.AddHeader(AspPipeLinePage.VwgPipelineName, this.GetPipelineResponse());
    }

    /// <summary>
    /// Called before the page is loaded to get the pipeline events
    /// </summary>
    /// <param name="e"></param>
    protected override void OnPreLoad(EventArgs e)
    {
      if (!string.IsNullOrEmpty(this.mstrHeaderPipeline))
      {
        if (VWGContext.Current is IContextPipeline current1)
          this.mlngRequestId = current1.ProcessRequest(this.mstrHeaderPipeline);
      }
      else if (this.mobjPipeline != null)
      {
        string str = this.mobjPipeline.Value;
        if (!string.IsNullOrEmpty(str))
        {
          string strEvents = HttpUtility.UrlDecode(str);
          if (VWGContext.Current is IContextPipeline current2)
            this.mlngRequestId = current2.ProcessRequest(strEvents);
        }
      }
      base.OnPreLoad(e);
    }

    /// <summary>Generates an update command to the pipeline field</summary>
    /// <param name="e"></param>
    protected override void OnPreRender(EventArgs e)
    {
      if (string.IsNullOrEmpty(this.mstrHeaderPipeline) && this.mobjPipeline != null)
        this.mobjPipeline.Value = this.GetPipelineResponse();
      if (!this.IsCallback && !string.IsNullOrEmpty(this.mstrHeaderPipeline))
        HttpContext.Current.Response?.AddHeader(AspPipeLinePage.VwgPipelineName, this.GetPipelineResponse());
      base.OnPreRender(e);
    }

    /// <summary>Gets the pipeline response.</summary>
    /// <returns></returns>
    private string GetPipelineResponse()
    {
      if (this.mlngRequestId <= 0L)
        return "";
      StringBuilder sb = new StringBuilder();
      StringWriter objOutput = new StringWriter(sb);
      if (VWGContext.Current is IContextPipeline current)
        current.GenerateResponse((TextWriter) objOutput, this.mlngRequestId);
      return sb.ToString();
    }

    /// <summary>
    /// Gets and sets the id of the vwg control that wraps the page.
    /// </summary>
    public long VwgControlId
    {
      get => this.mlngVwgControlId;
      set => this.mlngVwgControlId = value;
    }

    /// <summary>
    /// Gets the <see cref="T:System.Web.UI.PageStatePersister" /> object associated with the page.
    /// </summary>
    /// <value></value>
    /// <returns>A <see cref="T:System.Web.UI.PageStatePersister" /> associated with the page.</returns>
    protected override PageStatePersister PageStatePersister => this.mobjPageStatePersister != null ? this.mobjPageStatePersister : base.PageStatePersister;

    /// <summary>Gets or sets the hosted control.</summary>
    /// <value>The hosted control.</value>
    internal System.Web.UI.Control HostedControl
    {
      get => this.mobjHostedControl;
      set => this.mobjHostedControl = value;
    }

    /// <summary>Raises the PageProcessStarting event.</summary>
    /// <param name="e"></param>
    protected virtual void OnPageProcessStarting(AspPageEventArgs e)
    {
      if (this.PageProcessStarting == null)
        return;
      this.PageProcessStarting((object) this, e);
    }

    /// <summary>Processes the main start.</summary>
    internal void ProcessMainStart()
    {
      this.InvokeMethod("SetIntrinsics", new object[1]
      {
        (object) new HttpContext((HttpWorkerRequest) new AspPipeLinePage.AspPipLineSimpleWorkerRequest("~/Main.wgx", "", (TextWriter) new StreamWriter((Stream) new MemoryStream()), this.Context.Request.UserAgent))
        {
          Items = {
            [(object) "AspSession"] = (object) this.Context.Session
          }
        }
      }, new Type[1]{ typeof (HttpContext) });
      this.OnPageProcessStarting(new AspPageEventArgs((Page) this));
      NameValueCollection objValue = this.PageAdapter == null ? this.DeterminePostBackMode() : this.PageAdapter.DeterminePostBackMode();
      this.SetMemberValue("_requestValueCollection", (object) objValue);
      this.InvokeMethod("PerformPreInit");
      this.InvokeMethod("InitRecursive", new object[1]);
      this.InvokeMethod("OnInitComplete", (object) EventArgs.Empty);
      this.InvokeMethod("LoadAllState");
      this.InvokeMethod("ProcessPostData", (object) objValue, (object) true);
      this.InvokeMethod("OnPreLoad", (object) EventArgs.Empty);
      this.InvokeMethod("LoadRecursive");
      this.InvokeMethod("ProcessPostData", (object) (this.GetMemberValue("_leftoverPostData") as NameValueCollection), (object) false);
      this.InvokeMethod("RaiseChangedEvents");
      this.InvokeMethod("RaisePostBackEvent", new object[1]
      {
        (object) objValue
      }, new Type[1]{ typeof (NameValueCollection) });
      this.InvokeMethod("OnLoadComplete", (object) EventArgs.Empty);
    }

    /// <summary>Processes the main end.</summary>
    internal void ProcessMainEnd()
    {
      if (this.CompatibilityMode == AspControlBoxBase.VersionCompatibilityMode.Version6)
      {
        this.Version6ProcessMainEnd();
      }
      else
      {
        if (!this.IsCrossPagePostBack)
          this.InvokeMethod("PreRenderRecursiveInternal");
        this.InvokeMethod("PerformPreRenderComplete");
        this.InvokeMethod("SaveAllState");
        this.InvokeMethod("OnSaveStateComplete", (object) EventArgs.Empty);
      }
    }

    /// <summary>Sets the member value.</summary>
    /// <param name="strMemberName">Name of the STR member.</param>
    /// <param name="objValue">The obj value.</param>
    private void SetMemberValue(string strMemberName, object objValue)
    {
      FieldInfo field = typeof (Page).GetField(strMemberName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
      if (!(field != (FieldInfo) null))
        return;
      field.SetValue((object) this, objValue);
    }

    /// <summary>Gets the member value.</summary>
    /// <param name="strMemberName">Name of the STR member.</param>
    /// <returns></returns>
    private object GetMemberValue(string strMemberName)
    {
      FieldInfo field = typeof (Page).GetField(strMemberName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField);
      return field != (FieldInfo) null ? field.GetValue((object) this) : (object) null;
    }

    /// <summary>Invokes the method.</summary>
    /// <param name="strMethodName">Name of the STR method.</param>
    /// <param name="arrArguments">The obj arguments.</param>
    private void InvokeMethod(string strMethodName, params object[] arrArguments)
    {
      MethodInfo method = typeof (Page).GetMethod(strMethodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod);
      if (!(method != (MethodInfo) null))
        return;
      method.Invoke((object) this, arrArguments);
    }

    /// <summary>Invokes the method.</summary>
    /// <param name="strMethodName">Name of the STR method.</param>
    /// <param name="objArguments">The obj arguments.</param>
    /// <param name="objTypes">The obj types.</param>
    private void InvokeMethod(string strMethodName, object[] arrArguments, Type[] arrTypes)
    {
      MethodInfo method = typeof (Page).GetMethod(strMethodName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.InvokeMethod, (Binder) null, arrTypes, (ParameterModifier[]) null);
      if (!(method != (MethodInfo) null))
        return;
      method.Invoke((object) this, arrArguments);
    }

    public override System.Web.UI.Control FindControl(string id) => id == AspPipeLinePage.VwgPipelineName ? (System.Web.UI.Control) this.mobjPipeline : base.FindControl(id);

    /// <summary>
    /// Returns the results of a callback event that targets a control.
    /// </summary>
    /// <returns>The result of the callback.</returns>
    string ICallbackEventHandler.GetCallbackResult() => string.Empty;

    /// <summary>Raises the callback event.</summary>
    /// <param name="strEventArgument">The event argument.</param>
    void ICallbackEventHandler.RaiseCallbackEvent(string strEventArgument)
    {
      if (this.mobjAspControlBox == null)
        return;
      this.mobjAspControlBox.OnSubmit((object) this.mobjAspControlBox, new AspSubmitArgs(strEventArgument));
    }

    /// <summary>
    /// Returns a <see cref="T:System.Collections.Specialized.NameValueCollection" /> of data posted back to the page using either a POST or a GET command.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.Collections.Specialized.NameValueCollection" /> object that contains the form data. If the postback used the POST command, the form information is returned from the <see cref="P:System.Web.UI.Page.Context" /> object. If the postback used the GET command, the query string information is returned. If the page is being requested for the first time, null is returned.
    /// </returns>
    private NameValueCollection Version6DeterminePostBackMode()
    {
      NameValueCollection postBackMode = base.DeterminePostBackMode();
      if (!this.IsCallback && postBackMode == null)
        postBackMode = new NameValueCollection();
      return postBackMode;
    }

    /// <summary>Processes the main end.</summary>
    internal void Version6ProcessMainEnd()
    {
      this.InvokeMethod("PerformPreRenderComplete");
      this.InvokeMethod("SaveAllState");
      this.InvokeMethod("OnSaveStateComplete", (object) EventArgs.Empty);
    }

    /// <summary>
    /// 
    /// </summary>
    public class AspPipLineSimpleWorkerRequest : SimpleWorkerRequest
    {
      private string mstrUserAgent = string.Empty;

      /// <summary>
      /// Returns the standard HTTP request header that corresponds to the specified index.
      /// </summary>
      /// <param name="index">The index of the header. For example, the <see cref="F:System.Web.HttpWorkerRequest.HeaderAllow" /> field.</param>
      /// <returns>The HTTP request header.</returns>
      public override string GetKnownRequestHeader(int index) => this.mstrUserAgent;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspPipeLinePage.AspPipLineSimpleWorkerRequest" /> class.
      /// </summary>
      /// <param name="strPage">The page.</param>
      /// <param name="strQuery">The query.</param>
      /// <param name="objOutput">The output.</param>
      /// <param name="strUserAgent">The user agent.</param>
      public AspPipLineSimpleWorkerRequest(
        string strPage,
        string strQuery,
        TextWriter objOutput,
        string strUserAgent)
        : base(strPage, strQuery, objOutput)
      {
        this.mstrUserAgent = strUserAgent;
      }
    }

    /// <summary>
    /// Provides view / control state for the asp control box control
    /// </summary>
    [Serializable]
    protected class AspControlBoxStatePersister : PageStatePersister
    {
      /// <summary>The owning asp control box</summary>
      private AspControlBoxBase mobjAspControlBox;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspPipeLinePage.AspControlBoxStatePersister" /> class.
      /// </summary>
      /// <param name="objAspPipeLinePage">The aspnet page.</param>
      /// <param name="objAspControlBox">The hosting Visual WebGui control.</param>
      public AspControlBoxStatePersister(
        AspPipeLinePage objAspPipeLinePage,
        AspControlBoxBase objAspControlBox)
        : base((Page) objAspPipeLinePage)
      {
        this.mobjAspControlBox = objAspControlBox;
      }

      /// <summary>
      /// Overridden by derived classes to deserialize and load persisted state information when a <see cref="T:System.Web.UI.Page" /> object initializes its control hierarchy.
      /// </summary>
      public override void Load()
      {
        this.ControlState = this.mobjAspControlBox.GetControlStateInternal();
        this.ViewState = this.mobjAspControlBox.GetViewStateInternal();
      }

      /// <summary>
      /// Overridden by derived classes to serialize persisted state information when a <see cref="T:System.Web.UI.Page" /> object is unloaded from memory.
      /// </summary>
      public override void Save()
      {
        this.mobjAspControlBox.SetControlStateInternal(this.ControlState);
        this.mobjAspControlBox.SetViewStateInternal(this.ViewState);
      }
    }

    /// <summary>
    /// WebForms hidden field that renders the hidden field with static Id + static name. (The Id+name will be rendered to the client without any changes made by ASPNET infrustructure)
    /// NOTE: In order the hidden field will recieve post data, there needs to be a FindControl implementation in the Page. (For more details look at AspPipeLinePage.FindControl method)
    /// </summary>
    [ToolboxItem("")]
    private class HiddenField : System.Web.UI.WebControls.HiddenField
    {
      /// <summary>
      /// Renders the Web server control content to the client's browser using the specified <see cref="T:System.Web.UI.HtmlTextWriter" /> object.
      /// </summary>
      /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object used to render the server control content on the client's browser.</param>
      protected override void Render(HtmlTextWriter writer) => writer.Write("<input id='{0}' name='{0}' type='hidden' value='{1}'/>", (object) this.ID, (object) this.Value);
    }
  }
}
