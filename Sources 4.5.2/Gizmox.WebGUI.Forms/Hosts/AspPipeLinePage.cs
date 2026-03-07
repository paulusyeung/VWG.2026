using System;
using System.Collections.Generic;
using System.Text;
using HtmlControls = System.Web.UI.HtmlControls;
using WebControls = System.Web.UI.WebControls;
using WebUI = System.Web.UI;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Interfaces;
using System.Xml.XPath;
using System.IO;
using System.Collections;
using System.Web.UI;
using System.Reflection;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using System.Web;
using System.Web.UI.Adapters;
using System.Collections.Specialized;
using System.Web.Hosting;
using System.Web.SessionState;
using System.ComponentModel;


namespace Gizmox.WebGUI.Forms.Hosts
{

    /// <summary>
    /// Provides an System.Web.UI.Page implementation that adds state management and visual webgui pipeline integration
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [Serializable()]
    public class AspPipeLinePage : WebUI.Page, ICallbackEventHandler
    {
        #region Classes

        /// <summary>
        /// 
        /// </summary>
        public class AspPipLineSimpleWorkerRequest : SimpleWorkerRequest
        {
            #region Members

            string mstrUserAgent = string.Empty;

            #endregion

            #region C'tor / D'tor

            /// <summary>
            /// Returns the standard HTTP request header that corresponds to the specified index.
            /// </summary>
            /// <param name="index">The index of the header. For example, the <see cref="F:System.Web.HttpWorkerRequest.HeaderAllow"/> field.</param>
            /// <returns>The HTTP request header.</returns>
            public override string GetKnownRequestHeader(int index)
            {
                return mstrUserAgent;
            }
            
            /// <summary>
            /// Initializes a new instance of the <see cref="AspPipLineSimpleWorkerRequest"/> class.
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

            #endregion
        }

        /// <summary>
        /// Provides view / control state for the asp control box control
        /// </summary>
        [Serializable()]
        protected class AspControlBoxStatePersister : System.Web.UI.PageStatePersister
        {
            /// <summary>
            /// The owning asp control box
            /// </summary>
            private AspControlBoxBase mobjAspControlBox = null;

            /// <summary>
            /// Initializes a new instance of the <see cref="AspControlBoxStatePersister"/> class.
            /// </summary>
            /// <param name="objAspPipeLinePage">The aspnet page.</param>
            /// <param name="objAspControlBox">The hosting Visual WebGui control.</param>
            public AspControlBoxStatePersister(AspPipeLinePage objAspPipeLinePage, AspControlBoxBase objAspControlBox)
                : base(objAspPipeLinePage)
            {
                mobjAspControlBox = objAspControlBox;
            }

            /// <summary>
            /// Overridden by derived classes to deserialize and load persisted state information when a <see cref="T:System.Web.UI.Page"/> object initializes its control hierarchy.
            /// </summary>
            public override void Load()
            {
                this.ControlState = mobjAspControlBox.GetControlStateInternal();
                this.ViewState = mobjAspControlBox.GetViewStateInternal();
            }

            /// <summary>
            /// Overridden by derived classes to serialize persisted state information when a <see cref="T:System.Web.UI.Page"/> object is unloaded from memory.
            /// </summary>
            public override void Save()
            {
                this.mobjAspControlBox.SetControlStateInternal(this.ControlState);
                this.mobjAspControlBox.SetViewStateInternal(this.ViewState);
            }
        }

        #endregion

        #region Class Members

        internal static string VwgPipelineName = "vwg_pipeline";

        /// <summary>
        /// The vwg control id.
        /// </summary>
        private long mlngVwgControlId;

        /// <summary>
        /// The Visual WebGui asp.net pipeline field
        /// </summary>
        private HiddenField mobjPipeline = null;

        /// <summary>
        /// The Visual WebGui request ID
        /// </summary>
        private long mlngRequestId = 0;

        /// <summary>
        /// The asp pipeline page state persister
        /// </summary>
        private PageStatePersister mobjPageStatePersister = null;

        /// <summary>
        /// The hosted asp.net controls (used from AspControlBoxBase).
        /// </summary>
        private System.Web.UI.Control mobjHostedControl = null;

        /// <summary>
        /// Indicates if the pipeline is header based
        /// </summary>
        private string mstrHeaderPipeline = null;

        private AspControlBoxBase mobjAspControlBox = null;

        public event AspPageEventHandler PageProcessStarting;

        #endregion

        #region C'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="AspPipeLinePage"/> class.
        /// </summary>
        public AspPipeLinePage()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AspPipeLinePage"/> class.
        /// </summary>
        /// <param name="objAspControlBox">The ASP control box.</param>
        internal AspPipeLinePage(AspControlBoxBase objAspControlBox)
        {
            mobjAspControlBox = objAspControlBox;
            mobjPageStatePersister = new AspControlBoxStatePersister(this, objAspControlBox);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a <see cref="T:System.Collections.Specialized.NameValueCollection"/> of data posted back to the page using either a POST or a GET command.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Specialized.NameValueCollection"/> object that contains the form data. If the postback used the POST command, the form information is returned from the <see cref="P:System.Web.UI.Page.Context"/> object. If the postback used the GET command, the query string information is returned. If the page is being requested for the first time, null is returned.
        /// </returns>
        protected override NameValueCollection DeterminePostBackMode()
        {
            if (CompatibilityMode == AspControlBoxBase.VersionCompatibilityMode.Version6)
            {
                return Version6DeterminePostBackMode();
            }

            NameValueCollection objResult = base.DeterminePostBackMode();

            // If mobjAspControlBox is null, it means we are in PageBox and we should return the default value.
            if (mobjAspControlBox == null) { return objResult; }

            if (!IsCallback)
            {
                // NOTE: Here we must "Enforce" post back in case we are NOT in asp request, and we are not in the first vwg request.
                // This is for scenario -> AspRequest performed and set TextBox.Text to "123" -> Vwg request access to TextBox.Text.
                // Without these lines, the ViewState of the control will not be loaded because view state is loaded only when IsPostBack is true.
                // NOTE2: We check the mobjAspControlBox.GetViewStateInternal() != null because in first VWGRequest the GetViewStateInternal 
                // returns null and its ok because we dont want this request to be postback.
                if (objResult == null && !mobjAspControlBox.IsAspRequest && !mobjAspControlBox.IsFirstVwgRequest)
                {
                    objResult = new NameValueCollection();
                }
            }

            return objResult;
        }

        /// <summary>
        /// Gets the compatibility mode.
        /// </summary>
        private AspControlBoxBase.VersionCompatibilityMode CompatibilityMode
        {
            get
            {
                // If mobjAspControlBox is null, it means we are in PageBox and we should return the default value.
                if (mobjAspControlBox == null)
                {
                    return AspControlBoxBase.VersionCompatibilityMode.Version72;
                }

                return mobjAspControlBox.CompatibilityMode;
            }
        }

        /// <summary>
        /// Called when the page is initialized
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (this.Form != null)
            {
                // Try finding the vwg_pipeline control.                
                mobjPipeline = this.Form.FindControl(AspPipeLinePage.VwgPipelineName) as HiddenField;
                if (mobjPipeline == null)
                {
                    // Create pipeline data field.
                    // NOTE: We create here "our" HiddenField that will render the id+name to the client as it is in the ID property of the hidden field. This comes
                    // for scenario that the aspx control of the user contains MasterPage.in this case, the "standard" hidden field is registered with id+name prefix,
                    // and this cases problem to Events_RaiseEventsThroughPipeline client methods that assumes there is element with "vwg_pipeline" id.
                    mobjPipeline = new HiddenField();
                    mobjPipeline.ID = AspPipeLinePage.VwgPipelineName;
                    this.Form.Controls.Add(mobjPipeline);

                    HiddenField objVwgDataId = new HiddenField();
                    objVwgDataId.ID = "vwg_data_id";
                    objVwgDataId.Value = VwgControlId.ToString();
                    this.Form.Controls.Add(objVwgDataId);

                    string strDynamicExtension = string.Empty;

                    Config objConfig = Config.GetInstance();
                    if (objConfig != null)
                    {
                        strDynamicExtension = objConfig.DynamicExtension;
                    }
                    // Get the path of the pipe line script resource
                    string strPipeLineScriptResource = "Resources.Gizmox.WebGUI.Forms.Skins.CommonSkin.PipeLine.js" + strDynamicExtension;

                    // Register custom scripts and styles from the asp control.
                    if (mobjAspControlBox != null)
                    {
                        foreach (string strScript in mobjAspControlBox.Scripts)
                        {
                            this.ClientScript.RegisterClientScriptInclude(this.GetType(), strScript, strScript);
                        }

                        foreach (string strStyle in mobjAspControlBox.Styles)
                        {
                            string strStyleLink = string.Format("<link href='{0}' rel='stylesheet' type='text/css'/>", strStyle);
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), strStyle, strStyleLink);
                        }                    
                    }

                    // Register custom scripts and styles from the asp control.
                    if (mobjAspControlBox != null)
                    {
                        foreach (string strScript in mobjAspControlBox.Scripts)
                        {
                            this.ClientScript.RegisterClientScriptInclude(this.GetType(), strScript, strScript);
                        }

                        foreach (string strStyle in mobjAspControlBox.Styles)
                        {
                            string strStyleLink = string.Format("<link href='{0}' rel='stylesheet' type='text/css'/>", strStyle);
                            this.ClientScript.RegisterClientScriptBlock(this.GetType(), strStyle, strStyleLink, false);
                        }
                    }

                    // Attach pipeline events and add pipeline code
                    this.ClientScript.RegisterOnSubmitStatement(typeof(AspPipeLinePage), "vwg_pipeline_submit_handler", "vwg_pipeline_onsubmit(document);");
                    this.ClientScript.RegisterClientScriptInclude(typeof(AspPipeLinePage), "vwg_pipeline_code", strPipeLineScriptResource);
                    this.ClientScript.RegisterStartupScript(typeof(AspPipeLinePage), "vwg_set_vwg_form", string.Format("window.vwgForm = document.getElementById('{0}');", Form.ClientID), true);
                    this.ClientScript.RegisterStartupScript(typeof(AspPipeLinePage), "vwg_pipeline_load_handler", "setTimeout('vwg_pipeline_onload(document)',10);", true);
                    this.ClientScript.RegisterClientScriptBlock(typeof(AspPipeLinePage), "vwg_pipeline_submit", "function vwg_pipeline_submit(strArgument) {" + this.ClientScript.GetCallbackEventReference(this, "strArgument", "null", null) + "}", true);
                }
            }

            // Try to get pipeline from header
            mstrHeaderPipeline = this.Request.Headers[AspPipeLinePage.VwgPipelineName];

            // If header pipeline enforce response buffering to add header
            if (!string.IsNullOrEmpty(mstrHeaderPipeline))
            {
                this.Response.Buffer = true;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Unload"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> object that contains event data.</param>
        protected override void OnUnload(EventArgs e)
        {
            base.OnUnload(e);

            // In case of a callback add the vwg_pipeline header.
            if (this.IsCallback)
            {
                if (!string.IsNullOrEmpty(mstrHeaderPipeline))
                {
                    HttpContext objHttpContext = HttpContext.Current;
                    if (objHttpContext != null)
                    {
                        // Get the respose object as Page.Response is not valid here
                        HttpResponse objResponse = objHttpContext.Response;
                        if (objResponse != null)
                        {
                            // Add response as a header
                            objResponse.AddHeader(AspPipeLinePage.VwgPipelineName, GetPipelineResponse());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Called before the page is loaded to get the pipeline events
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreLoad(EventArgs e)
        {
            // If is a header pipeline
            if (!string.IsNullOrEmpty(mstrHeaderPipeline))
            {
                // Get the context pipe line
                IContextPipeline objContext = VWGContext.Current as IContextPipeline;
                if (objContext != null)
                {
                    mlngRequestId = objContext.ProcessRequest(mstrHeaderPipeline);
                }
            }
            else
            {
                // If there is a pipeline field
                if (mobjPipeline != null)
                {
                    // Get pipeline events
                    string strEvents = mobjPipeline.Value;

                    // If valid pipeline events
                    if (!string.IsNullOrEmpty(strEvents))
                    {
                        // Decode pipeline events
                        strEvents = HttpUtility.UrlDecode(strEvents);

                        // Get the context pipe line
                        IContextPipeline objContext = VWGContext.Current as IContextPipeline;
                        if (objContext != null)
                        {
                            mlngRequestId = objContext.ProcessRequest(strEvents);
                        }
                    }
                }
            }

            base.OnPreLoad(e);
        }

        /// <summary>
        /// Generates an update command to the pipeline field
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            // If this is a header pipeline
            if (string.IsNullOrEmpty(mstrHeaderPipeline))
            {
                // If there is a pipeline field
                if (mobjPipeline != null)
                {
                    mobjPipeline.Value = GetPipelineResponse();
                }
            }

            // In case of a none callback add the vwg_pipeline header.
            if (!this.IsCallback)
            {
                if (!string.IsNullOrEmpty(mstrHeaderPipeline))
                {
                    // Get the respose object as Page.Response is not valid here
                    HttpResponse objResponse = HttpContext.Current.Response;
                    if (objResponse != null)
                    {
                        // Add response as a header
                        objResponse.AddHeader(AspPipeLinePage.VwgPipelineName, GetPipelineResponse());
                    }
                }
            }

            base.OnPreRender(e);
        }

        /// <summary>
        /// Gets the pipeline response.
        /// </summary>
        /// <returns></returns>
        private string GetPipelineResponse()
        {
            // If there is a valid request id
            if (mlngRequestId > 0)
            {
                // Create a memory buffer
                StringBuilder objBuffer = new StringBuilder();
                StringWriter objStringWriter = new StringWriter(objBuffer);

                // Get the context pipe line
                IContextPipeline objContext = VWGContext.Current as IContextPipeline;
                if (objContext != null)
                {
                    objContext.GenerateResponse(objStringWriter, mlngRequestId);
                }

                // Get pipeline response
                return objBuffer.ToString();
            }
            else
            {
                return "";
            }
        }

        #endregion

        #region Properties

        /// <summary>
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

        /// <summary>
        /// Gets the <see cref="T:System.Web.UI.PageStatePersister"/> object associated with the page.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:System.Web.UI.PageStatePersister"/> associated with the page.</returns>
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

        /// <summary>
        /// Gets or sets the hosted control.
        /// </summary>
        /// <value>The hosted control.</value>
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

        #endregion

        #region Process Emulation

        /// <summary>
        /// Raises the PageProcessStarting event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPageProcessStarting(AspPageEventArgs e)
        {
            if (PageProcessStarting != null)
            {
                PageProcessStarting(this, e);
            }
        }

        /// <summary>
        /// Processes the main start.
        /// </summary>
        internal void ProcessMainStart()
        {
            // Create a virtual AspPipLineSimpleWorkerRequest.
            AspPipLineSimpleWorkerRequest objAspPipLineSimpleWorkerRequest = new AspPipLineSimpleWorkerRequest("~/Main.wgx", "", new StreamWriter(new MemoryStream()), this.Context.Request.UserAgent);

            // Create a intrinsic context.
            HttpContext objIntrinsicContext = new HttpContext(objAspPipLineSimpleWorkerRequest);

            // Set the Asp session with the VWG session.
            objIntrinsicContext.Items["AspSession"] = this.Context.Session;

            // Execute the SetIntrinsics method.
            InvokeMethod("SetIntrinsics", new object[] { objIntrinsicContext }, new Type[] { typeof(HttpContext) });

            // Raise the HostedPageProcessStarting event here. 
            // NOTE: It is important to raise the event here (After the SetIntrinsics method) because only here the Page.Request can be accessed.
            OnPageProcessStarting(new AspPageEventArgs(this));

            // Define a request value collection.
            NameValueCollection objRequestValueCollection = null;

            if (this.PageAdapter != null)
            {
                // Set the _requestValueCollection member value.
                objRequestValueCollection = this.PageAdapter.DeterminePostBackMode();
            }
            else
            {
                // Set the _requestValueCollection member value.
                objRequestValueCollection = this.DeterminePostBackMode();
            }

            // Set the _requestValueCollection member value.
            SetMemberValue("_requestValueCollection", objRequestValueCollection);

            // Execute the PerformPreInit method.
            InvokeMethod("PerformPreInit");

            // Execute the InitRecursive method.
            InvokeMethod("InitRecursive", new object[] { null });

            // Execute the OnInitComplete method.
            InvokeMethod("OnInitComplete", EventArgs.Empty);

            // Execute the LoadAllState method.
            InvokeMethod("LoadAllState");

            // Execute the ProcessPostData method.
            InvokeMethod("ProcessPostData", objRequestValueCollection, true);

            // Execute the OnPreLoad method.
            InvokeMethod("OnPreLoad", EventArgs.Empty);

            // Execute the LoadRecursive method.
            InvokeMethod("LoadRecursive");

            // Get the leftover data field.
            NameValueCollection objLeftoverPostData = this.GetMemberValue("_leftoverPostData") as NameValueCollection;

            // Execute the ProcessPostData method.
            InvokeMethod("ProcessPostData", objLeftoverPostData, false);

            // Execute the RaiseChangedEvents method.
            InvokeMethod("RaiseChangedEvents");

            // Execute the RaisePostBackEvent method.
            InvokeMethod("RaisePostBackEvent", new object[] { objRequestValueCollection }, new Type[] { typeof(NameValueCollection) });

            // Execute the OnLoadComplete method.
            InvokeMethod("OnLoadComplete", EventArgs.Empty);
        }

        /// <summary>
        /// Processes the main end.
        /// </summary>
        internal void ProcessMainEnd()
        {
            if (CompatibilityMode == AspControlBoxBase.VersionCompatibilityMode.Version6)
            {
                Version6ProcessMainEnd();
                return;
            }

            // Execute the PerformPreRenderComplete method that will raise the PreRender event. 
            if (!this.IsCrossPagePostBack)
            {
                InvokeMethod("PreRenderRecursiveInternal");
            }

            // Execute the PerformPreRenderComplete method.
            InvokeMethod("PerformPreRenderComplete");

            // Execute the SaveAllState method.
            InvokeMethod("SaveAllState");

            // Execute the OnSaveStateComplete method.
            InvokeMethod("OnSaveStateComplete", EventArgs.Empty);
        }

        /// <summary>
        /// Sets the member value.
        /// </summary>
        /// <param name="strMemberName">Name of the STR member.</param>
        /// <param name="objValue">The obj value.</param>
        private void SetMemberValue(string strMemberName, object objValue)
        {
            FieldInfo objField = typeof(System.Web.UI.Page).GetField(strMemberName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField);
            if (objField != null)
            {
                objField.SetValue(this, objValue);
            }
        }

        /// <summary>
        /// Gets the member value.
        /// </summary>
        /// <param name="strMemberName">Name of the STR member.</param>
        /// <returns></returns>
        private object GetMemberValue(string strMemberName)
        {
            FieldInfo objField = typeof(System.Web.UI.Page).GetField(strMemberName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetField);
            if (objField != null)
            {
                return objField.GetValue(this);
            }

            return null;
        }

        /// <summary>
        /// Invokes the method.
        /// </summary>
        /// <param name="strMethodName">Name of the STR method.</param>
        /// <param name="arrArguments">The obj arguments.</param>
        private void InvokeMethod(string strMethodName, params object[] arrArguments)
        {
            // Initialize page and set it to track viewstate changes.
            MethodInfo objMethod = typeof(System.Web.UI.Page).GetMethod(strMethodName, BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance);
            if (objMethod != null)
            {
                // Enable fack postback to ensure recursive action
                objMethod.Invoke(this, arrArguments);
            }
        }

        /// <summary>
        /// Invokes the method.
        /// </summary>
        /// <param name="strMethodName">Name of the STR method.</param>
        /// <param name="objArguments">The obj arguments.</param>
        /// <param name="objTypes">The obj types.</param>
        private void InvokeMethod(string strMethodName, object[] arrArguments, Type[] arrTypes)
        {
            // Initialize page and set it to track viewstate changes.
            MethodInfo objMethod = typeof(System.Web.UI.Page).GetMethod(strMethodName, BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance, null, arrTypes, null);
            if (objMethod != null)
            {
                // Enable fack postback to ensure recursive action
                objMethod.Invoke(this, arrArguments);
            }
        }

        public override WebUI.Control FindControl(string id)
        {
            // Here because the vwg_pipeline hidden field is rendered with static id + name, the find control will not find the control. (When it call LoadPostData of the controls)
            // because it looks for the controls in the INamingContainer hierarchy. In order to solve this we override the FindControl method and for id "vwg_pipeline" we return the 
            // hidden field.
            if (id == AspPipeLinePage.VwgPipelineName)
            {
                return mobjPipeline;
            }

            return base.FindControl(id);
        }

        #endregion

        #region ICallbackEventHandler Members

        /// <summary>
        /// Returns the results of a callback event that targets a control.
        /// </summary>
        /// <returns>The result of the callback.</returns>
        string ICallbackEventHandler.GetCallbackResult()
        {
            return string.Empty;
        }

        /// <summary>
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

        #endregion

        #region HiddenField

        /// <summary>
        /// WebForms hidden field that renders the hidden field with static Id + static name. (The Id+name will be rendered to the client without any changes made by ASPNET infrustructure)
        /// NOTE: In order the hidden field will recieve post data, there needs to be a FindControl implementation in the Page. (For more details look at AspPipeLinePage.FindControl method)
        /// </summary>
        [ToolboxItem("")]
        private class HiddenField : WebControls.HiddenField
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="HiddenField"/> class.
            /// </summary>
            public HiddenField()
            {
            }

            /// <summary>
            /// Renders the Web server control content to the client's browser using the specified <see cref="T:System.Web.UI.HtmlTextWriter" /> object.
            /// </summary>
            /// <param name="writer">The <see cref="T:System.Web.UI.HtmlTextWriter" /> object used to render the server control content on the client's browser.</param>
            protected override void Render(HtmlTextWriter writer)
            {
                writer.Write("<input id='{0}' name='{0}' type='hidden' value='{1}'/>", ID, Value);
            }
        }

        #endregion

        #region Legacy code

        /// <summary>
        /// Returns a <see cref="T:System.Collections.Specialized.NameValueCollection"/> of data posted back to the page using either a POST or a GET command.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Specialized.NameValueCollection"/> object that contains the form data. If the postback used the POST command, the form information is returned from the <see cref="P:System.Web.UI.Page.Context"/> object. If the postback used the GET command, the query string information is returned. If the page is being requested for the first time, null is returned.
        /// </returns>
        private NameValueCollection Version6DeterminePostBackMode()
        {
            // Get base value.
            NameValueCollection objNameValueCollection = base.DeterminePostBackMode();

            if (!this.IsCallback)
            {
                if (objNameValueCollection == null)
                {
                    // Create a new name value collection inorder to fake post back.
                    objNameValueCollection = new NameValueCollection();
                }
            }

            return objNameValueCollection;
        }

        /// <summary>
        /// Processes the main end.
        /// </summary>
        internal void Version6ProcessMainEnd()
        {
            // Execute the PerformPreRenderComplete method.
            InvokeMethod("PerformPreRenderComplete");

            // Execute the SaveAllState method.
            InvokeMethod("SaveAllState");

            // Execute the OnSaveStateComplete method.
            InvokeMethod("OnSaveStateComplete", EventArgs.Empty);
        }

        #endregion
    }
}
