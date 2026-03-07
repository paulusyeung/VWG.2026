// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Gizmox.WebGUI.Forms.Hosts
{
  /// <summary>
  /// 	<para>AspControlBoxBase
  ///     provides a base class for creating ASP.NET wrapped controls that can be integrated
  ///     into VWG as a native control.</para>
  /// 	<para>The class provides
  ///     services for ASP.NET VWG communication and using ASP.NET markup code to
  ///     initialize the ASP.NET control.</para>
  /// </summary>
  /// <example>
  /// 	<para><font size="2">The following example illustrates the basic use of
  ///     AspControlBoxBase.</font></para>
  /// 	<code lang="CS">
  /// 		<![CDATA[
  /// [System.ComponentModel.ToolboxItem(true)]
  ///  public class MyWrappedWebControl : Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase
  ///  {
  ///     /// <SUMMARY>
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
  ///     /// <SUMMARY>
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
  ///     ''' <SUMMARY>
  ///     ''' Get the hosted control type
  ///     ''' </SUMMARY>
  ///     Protected Overrides Readonly Property HostedControlType() As Type
  ///         Get
  ///             Return GetType(System.Web.UI.Control)
  ///         End Get
  ///     End Property
  /// 
  ///     ''' <SUMMARY>
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
  [ToolboxItem(false)]
  [ToolboxBitmap(typeof (AspControlBoxBase), "Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase.bmp")]
  [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
  [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
  [DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.AspControlBoxCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (AspControlBoxBaseSkin))]
  [Serializable]
  public abstract class AspControlBoxBase : FrameControl
  {
    /// <summary>
    /// Provides a property reference to ControlState property.
    /// </summary>
    private static SerializableProperty ControlStateProperty = SerializableProperty.Register(nameof (ControlState), typeof (object), typeof (AspControlBoxBase));
    /// <summary>Provides a property reference to ViewState property.</summary>
    private static SerializableProperty ViewStateProperty = SerializableProperty.Register(nameof (ViewState), typeof (object), typeof (AspControlBoxBase));
    /// <summary>
    /// Provides a property reference to DefaultDesignValues property.
    /// </summary>
    private static SerializableProperty DefaultDesignValuesProperty = SerializableProperty.Register(nameof (DefaultDesignValues), typeof (Dictionary<string, object>), typeof (AspControlBoxBase));
    /// <summary>
    /// Provides a property reference to DesignTimeProperties property.
    /// </summary>
    private static SerializableProperty DesignTimePropertiesProperty = SerializableProperty.Register(nameof (DesignTimeProperties), typeof (Dictionary<string, object>), typeof (AspControlBoxBase));
    /// <summary>
    /// Provides a property reference to DesignTimeProperties property.
    /// </summary>
    private static SerializableProperty DesignTimeEventHandlersProperty = SerializableProperty.Register(nameof (DesignTimeEventHandlers), typeof (Dictionary<string, List<Delegate>>), typeof (AspControlBoxBase), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to Properties property.</summary>
    private static SerializableProperty PropertiesProperty = SerializableProperty.Register(nameof (Properties), typeof (Dictionary<string, PropertyInfo>), typeof (AspControlBoxBase));
    /// <summary>
    /// Provides a property reference to AspPipeLinePage property.
    /// </summary>
    private static SerializableProperty AspPipeLinePageProperty = SerializableProperty.Register("AspPipeLinePage", typeof (AspPipeLinePage), typeof (AspControlBoxBase));
    /// <summary>
    /// Provides a property reference to EventHandlers property.
    /// </summary>
    private static SerializableProperty EventHandlersProperty = SerializableProperty.Register(nameof (EventHandlers), typeof (Dictionary<string, List<Delegate>>), typeof (AspControlBoxBase), new SerializablePropertyMetadata((object) null));
    /// <summary>Provides a property reference to Events property.</summary>
    private static SerializableProperty EventsProperty = SerializableProperty.Register(nameof (Events), typeof (Dictionary<string, EventInfo>), typeof (AspControlBoxBase));
    /// <summary>
    /// Provides a property reference to IsAspRequest property.
    /// </summary>
    private static SerializableProperty IsAspRequestProperty = SerializableProperty.Register(nameof (IsAspRequest), typeof (bool), typeof (AspControlBoxBase));
    /// <summary>Provides a property reference to AutoScroll property.</summary>
    private static SerializableProperty AutoScrollProperty = SerializableProperty.Register(nameof (AutoScroll), typeof (bool), typeof (AspControlBoxBase));
    /// <summary>
    /// Provides a property reference to ControlCodeType property.
    /// </summary>
    private static SerializableProperty ControlCodeTypeProperty = SerializableProperty.Register(nameof (ControlCodeType), typeof (Type), typeof (AspControlBoxBase));
    /// <summary>
    /// Provides a property reference to ControlCode property.
    /// </summary>
    private static SerializableProperty ControlCodeProperty = SerializableProperty.Register(nameof (ControlCode), typeof (string), typeof (AspControlBoxBase));
    /// <summary>Provides a property reference to ControlID property.</summary>
    private static SerializableProperty ControlIDProperty = SerializableProperty.Register(nameof (ControlID), typeof (string), typeof (AspControlBoxBase));
    /// <summary>
    /// Provides a property reference to SyncPostDataChangesMode property.
    /// </summary>
    private static SerializableProperty SyncChangesOnVwgPostBackProperty = SerializableProperty.Register(nameof (SyncChangesOnVwgPostBack), typeof (SyncPostDataChangesMode), typeof (AspControlBoxBase), new SerializablePropertyMetadata((object) SyncPostDataChangesMode.None));
    /// <summary>
    /// Provides a property reference to SyncPostDataChangesMode property.
    /// </summary>
    private static SerializableProperty ScriptsProperty = SerializableProperty.Register(nameof (Scripts), typeof (string[]), typeof (AspControlBoxBase));
    /// <summary>
    /// Provides a property reference to SyncPostDataChangesMode property.
    /// </summary>
    private static SerializableProperty StylesProperty = SerializableProperty.Register(nameof (Styles), typeof (string[]), typeof (AspControlBoxBase));
    /// <summary>
    /// Provides a property reference to SyncPostData property.
    /// </summary>
    private static SerializableProperty SyncPostDataProperty = SerializableProperty.Register(nameof (SyncPostData), typeof (NameValueCollection), typeof (AspControlBoxBase));
    [NonSerialized]
    private bool mblnProcessMainEndRequired;
    [NonSerialized]
    private bool mblnAspUpdate;
    [NonSerialized]
    private System.Web.UI.Control mobjHostedControlForAspUpdate;
    [NonSerialized]
    private AspPipeLinePage mobjHostedPage;

    public event AspSubmitHandler Submit;

    /// <summary>Create asp.net control box</summary>
    public AspControlBoxBase()
    {
      this.Properties = new Dictionary<string, PropertyInfo>();
      this.EventsList = new Dictionary<string, EventInfo>();
      this.EventHandlers = new Dictionary<string, List<Delegate>>();
    }

    /// <summary>Gets the source.</summary>
    /// <value>The source.</value>
    protected override string Source
    {
      get
      {
        string baseUrl = CommonUtils.GetBaseUrl(VWGContext.Current.HostContext.Request);
        string virtualPath = new GatewayReference((IRegisteredComponent) this, "ASCXHost", (NameValueCollection) null).ToString();
        if (VWGContext.Current.HostContext.HttpContext.Session.IsCookieless)
          virtualPath = VWGContext.Current.HostContext.HttpContext.Response.ApplyAppPathModifier(virtualPath);
        string str = virtualPath;
        return baseUrl + str;
      }
    }

    /// <summary>Handle the HostedPageProcessStarting event.</summary>
    private void AspControlBoxBase_HostedPageProcessStarting(object sender, AspPageEventArgs e)
    {
      if (this.SyncPostData != null)
        this.EmulatePost(e.Page.Request, this.SyncPostData);
      this.mblnProcessMainEndRequired = true;
    }

    /// <summary>
    /// Recieves request and post data collection, and emulates the request as post request.
    /// </summary>
    private void EmulatePost(HttpRequest objRequest, NameValueCollection arrPostData)
    {
      NameValueCollection nameValueCollection = this.GetSystemWebFullTypeName("System.Web.HttpValueCollection").GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0].Invoke(new object[0]) as NameValueCollection;
      PropertyInfo property = nameValueCollection.GetType().GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
      property.SetValue((object) nameValueCollection, (object) false, (object[]) null);
      for (int index = 0; index < arrPostData.Count; ++index)
        nameValueCollection.Add(arrPostData.GetKey(index), arrPostData.Get(index));
      property.SetValue((object) nameValueCollection, (object) true, (object[]) null);
      typeof (HttpRequest).GetField("_form", BindingFlags.Instance | BindingFlags.NonPublic).SetValue((object) objRequest, (object) nameValueCollection);
      typeof (HttpRequest).GetField("_httpMethod", BindingFlags.Instance | BindingFlags.NonPublic).SetValue((object) objRequest, (object) "POST");
      FieldInfo field = typeof (HttpRequest).GetField("_httpVerb", BindingFlags.Instance | BindingFlags.NonPublic);
      object obj1 = Enum.Parse(this.GetSystemWebFullTypeName("System.Web.HttpVerb"), "POST");
      HttpRequest httpRequest = objRequest;
      object obj2 = obj1;
      field.SetValue((object) httpRequest, obj2);
    }

    protected override void FireEvent(IEvent objEvent)
    {
      base.FireEvent(objEvent);
      if (!(objEvent.Type == "SyncVwgChanges") || this.IsAspRequest)
        return;
      string str1 = HttpUtility.HtmlDecode(HttpUtility.UrlDecode(objEvent["PostData"]));
      NameValueCollection nameValueCollection = new NameValueCollection();
      char[] chArray = new char[1]{ '&' };
      string[] strArray1 = str1.Split(chArray);
      this.SyncPostData = new NameValueCollection();
      foreach (string str2 in strArray1)
      {
        char[] separator = new char[1]{ '=' };
        string[] strArray2 = str2.Split(separator, 2);
        this.SyncPostData.Add(strArray2[0], strArray2[1]);
      }
    }

    /// <summary>Creates the host page head control.</summary>
    /// <returns></returns>
    protected virtual HtmlHead CreateHostPageHead()
    {
      HtmlHead hostPageHead = new HtmlHead();
      hostPageHead.Controls.Add((System.Web.UI.Control) new HtmlTitle());
      return hostPageHead;
    }

    /// <summary>Creates the host page form control.</summary>
    /// <returns></returns>
    protected virtual HtmlForm CreateHostPageForm()
    {
      HtmlForm hostPageForm = new HtmlForm();
      hostPageForm.ID = this.FormName;
      return hostPageForm;
    }

    /// <summary>Creates the host page body control.</summary>
    /// <returns></returns>
    protected virtual HtmlControl CreateHostPageBody()
    {
      HtmlControl hostPageBody = (HtmlControl) new HtmlGenericControl("body");
      hostPageBody.Style.Add("margin", "0px");
      if (this.AutoScroll)
        hostPageBody.Style.Add("overflow", "auto");
      else
        hostPageBody.Style.Add("overflow", "hidden");
      return hostPageBody;
    }

    /// <summary>Get ASP.NET page</summary>
    /// <returns></returns>
    private AspPipeLinePage CreateHostPage()
    {
      AspPipeLinePage objHostedPage = new AspPipeLinePage(this);
      objHostedPage.VwgControlId = this.ID;
      objHostedPage.EnableViewState = true;
      objHostedPage.Load += new EventHandler(this.OnHostedPageLoad);
      objHostedPage.PreInit += new EventHandler(this.OnHostedPagePreInit);
      objHostedPage.PreLoad += new EventHandler(this.OnHostedPagePreLoadInternal);
      objHostedPage.PreRender += new EventHandler(this.OnHostedPagePreRender);
      objHostedPage.PreRenderComplete += new EventHandler(this.OnHostedPagePreRenderComplete);
      objHostedPage.Init += new EventHandler(this.OnHostedPageInit);
      objHostedPage.InitComplete += new EventHandler(this.OnHostedPageInitComplete);
      objHostedPage.LoadComplete += new EventHandler(this.OnHostedPageLoadComplete);
      objHostedPage.Error += new EventHandler(this.OnHostedPageError);
      objHostedPage.DataBinding += new EventHandler(this.OnHostedPageDataBinding);
      objHostedPage.Disposed += new EventHandler(this.OnHostedPageDisposed);
      objHostedPage.PageProcessStarting += new AspPageEventHandler(this.AspControlBoxBase_HostedPageProcessStarting);
      HtmlControl child = (HtmlControl) new HtmlGenericControl("html");
      objHostedPage.Controls.Add((System.Web.UI.Control) child);
      HtmlHead hostPageHead = this.CreateHostPageHead();
      if (hostPageHead != null)
        child.Controls.Add((System.Web.UI.Control) hostPageHead);
      HtmlControl hostPageBody = this.CreateHostPageBody();
      if (hostPageBody == null)
        throw new Exception("CreateHostPageBody method should not return a null value.");
      child.Controls.Add((System.Web.UI.Control) hostPageBody);
      HtmlForm hostPageForm = this.CreateHostPageForm();
      if (hostPageForm == null)
        throw new Exception("CreateHostPageForm method should not return a null value.");
      hostPageBody.Controls.Add((System.Web.UI.Control) hostPageForm);
      System.Web.UI.Control controlContainer = this.CreateHostedControlContainer(objHostedPage);
      if (controlContainer != null)
      {
        hostPageForm.Controls.Add(controlContainer);
        System.Web.UI.Control control = controlContainer.FindControl(this.ControlID);
        if (control == null)
          throw new Exception(string.Format("Could not resolve the hosted control using '{0}' control ID.", (object) this.ControlID));
        if (!this.HostedControlType.IsAssignableFrom(control.GetType()))
          throw new Exception(string.Format("Cannot convert hosted control found using '{0}' control ID to '{1}' type.", (object) this.ControlID, (object) this.HostedControlType.FullName));
        if (control != null)
        {
          control.Init += new EventHandler(this.OnHostedControlInit);
          control.Load += new EventHandler(this.OnHostedControlLoad);
          control.PreRender += new EventHandler(this.OnHostedControlPreRender);
          control.Unload += new EventHandler(this.OnHostedControlUnload);
          control.DataBinding += new EventHandler(this.OnHostedControlDataBinding);
          control.Disposed += new EventHandler(this.OnHostedControlDisposed);
          this.RestoreControlDesignEvents(control);
          control.EnableViewState = true;
          objHostedPage.HostedControl = control;
        }
      }
      return objHostedPage;
    }

    protected virtual void RestoreControlSize(System.Web.UI.Control objHostedControl)
    {
      if (!(objHostedControl is WebControl webControl))
        return;
      if (!this.IsFixedSize)
      {
        webControl.Height = new Unit("100%");
        webControl.Width = new Unit("100%");
      }
      else
      {
        webControl.Height = new Unit(this.Height - this.Padding.Vertical);
        webControl.Width = new Unit(this.Width - this.Padding.Horizontal);
      }
    }

    /// <summary>
    /// Raises the <see cref="E:Resize" /> event.
    /// </summary>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      if (!this.IsFixedSize)
        return;
      this.Update(true);
    }

    /// <summary>
    /// Gets a value indicating whether this instance is fixed size.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is fixed size; otherwise, <c>false</c>.
    /// </value>
    protected virtual bool IsFixedSize => false;

    /// <summary>Occurs when the hosted control page loads</summary>
    public event AspPageEventHandler HostedPageLoad;

    /// <summary>Occurs when the hosting page is loaded.</summary>
    protected virtual void OnHostedPageLoad(object sender, EventArgs e)
    {
      if (this.HostedControlForAspUpdate != null)
        return;
      AspPageEventHandler hostedPageLoad = this.HostedPageLoad;
      if (hostedPageLoad == null)
        return;
      hostedPageLoad((object) this, new AspPageEventArgs((Page) sender));
    }

    /// <summary>
    /// 
    /// </summary>
    public event AspPageEventHandler HostedPageError;

    /// <summary>Called when hosted page throws error.</summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
    protected virtual void OnHostedPageError(object sender, EventArgs e)
    {
      AspPageEventHandler hostedPageError = this.HostedPageError;
      if (hostedPageError == null)
        return;
      hostedPageError((object) this, new AspPageEventArgs((Page) sender));
    }

    /// <summary>
    /// 
    /// </summary>
    public event AspPageEventHandler HostedPageLoadComplete;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnHostedPageLoadComplete(object sender, EventArgs e)
    {
      if (this.HostedControlForAspUpdate == null)
      {
        AspPageEventHandler pageLoadComplete = this.HostedPageLoadComplete;
        if (pageLoadComplete != null)
          pageLoadComplete((object) this, new AspPageEventArgs((Page) sender));
      }
      if (this.HostedControlForAspUpdate == null)
        return;
      System.Web.UI.Control parent = this.HostedControl.Parent;
      parent.Controls.Clear();
      parent.Controls.Add(this.HostedControlForAspUpdate);
      this.HostedPage.HostedControl = this.HostedControlForAspUpdate;
      this.HostedControlForAspUpdate = (System.Web.UI.Control) null;
    }

    /// <summary>
    /// 
    /// </summary>
    public event AspPageEventHandler HostedPageInitComplete;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnHostedPageInitComplete(object sender, EventArgs e)
    {
      if (this.HostedControlForAspUpdate != null)
        return;
      AspPageEventHandler pageInitComplete = this.HostedPageInitComplete;
      if (pageInitComplete == null)
        return;
      pageInitComplete((object) this, new AspPageEventArgs((Page) sender));
    }

    /// <summary>
    /// 
    /// </summary>
    public event AspPageEventHandler HostedPagePageInit;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnHostedPageInit(object sender, EventArgs e)
    {
      if (this.HostedControlForAspUpdate != null)
        return;
      AspPageEventHandler hostedPagePageInit = this.HostedPagePageInit;
      if (hostedPagePageInit == null)
        return;
      hostedPagePageInit((object) this, new AspPageEventArgs((Page) sender));
    }

    /// <summary>
    /// 
    /// </summary>
    public event AspPageEventHandler HostedPagePreRenderComplete;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnHostedPagePreRenderComplete(object sender, EventArgs e)
    {
      AspPageEventHandler preRenderComplete = this.HostedPagePreRenderComplete;
      if (preRenderComplete == null)
        return;
      preRenderComplete((object) this, new AspPageEventArgs((Page) sender));
    }

    /// <summary>
    /// 
    /// </summary>
    public event AspPageEventHandler HostedPagePreRender;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnHostedPagePreRender(object sender, EventArgs e)
    {
      AspPageEventHandler hostedPagePreRender = this.HostedPagePreRender;
      if (hostedPagePreRender == null)
        return;
      hostedPagePreRender((object) this, new AspPageEventArgs((Page) sender));
    }

    /// <summary>
    /// 
    /// </summary>
    public event AspPageEventHandler HostedPagePreLoad;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnHostedPagePreLoadInternal(object sender, EventArgs e)
    {
      this.RestoreControlSize(this.HostedControl);
      this.TryRestoreControlDesignProperties(this.HostedControl);
      this.OnHostedPagePreLoad(sender, e);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnHostedPagePreLoad(object sender, EventArgs e)
    {
      if (this.HostedControlForAspUpdate != null || this.HostedPagePreLoad == null)
        return;
      this.HostedPagePreLoad((object) this, new AspPageEventArgs((Page) sender));
    }

    /// <summary>
    /// 
    /// </summary>
    public event AspPageEventHandler HostedPagePreInit;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnHostedPagePreInit(object sender, EventArgs e)
    {
      AspPageEventHandler hostedPagePreInit = this.HostedPagePreInit;
      if (hostedPagePreInit == null)
        return;
      hostedPagePreInit((object) this, new AspPageEventArgs((Page) sender));
    }

    /// <summary>
    /// 
    /// </summary>
    public event AspControlEventHandler HostedControlDisposed;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnHostedControlDisposed(object sender, EventArgs e)
    {
      AspControlEventHandler hostedControlDisposed = this.HostedControlDisposed;
      if (hostedControlDisposed == null)
        return;
      hostedControlDisposed((object) this, new AspControlEventArgs((System.Web.UI.Control) sender));
    }

    /// <summary>
    /// 
    /// </summary>
    public event AspPageEventHandler HostedPageDisposed;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnHostedPageDisposed(object sender, EventArgs e)
    {
      AspPageEventHandler hostedPageDisposed = this.HostedPageDisposed;
      if (hostedPageDisposed == null)
        return;
      hostedPageDisposed((object) this, new AspPageEventArgs((Page) sender));
    }

    /// <summary>
    /// 
    /// </summary>
    public event AspPageEventHandler HostedHostedPageDataBinding;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnHostedPageDataBinding(object sender, EventArgs e)
    {
      AspPageEventHandler hostedPageDataBinding = this.HostedHostedPageDataBinding;
      if (hostedPageDataBinding == null)
        return;
      hostedPageDataBinding((object) this, new AspPageEventArgs((Page) sender));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected internal virtual void OnSubmit(object sender, AspSubmitArgs e)
    {
      AspSubmitHandler submit = this.Submit;
      if (submit == null)
        return;
      submit(sender, e);
    }

    /// <summary>Does the submit.</summary>
    /// <param name="strEventArgument">The STR event argument.</param>
    public void DoSubmit(string strEventArgument) => this.InvokeMethodWithId("Web_SubmitHostedForm", (object) strEventArgument);

    /// <summary>
    /// 
    /// </summary>
    public event AspControlEventHandler HostedControlDataBinding;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnHostedControlDataBinding(object sender, EventArgs e)
    {
      AspControlEventHandler controlDataBinding = this.HostedControlDataBinding;
      if (controlDataBinding == null)
        return;
      controlDataBinding((object) this, new AspControlEventArgs((System.Web.UI.Control) sender));
    }

    /// <summary>
    /// 
    /// </summary>
    public event AspControlEventHandler HostedControlUnload;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnHostedControlUnload(object sender, EventArgs e)
    {
      AspControlEventHandler hostedControlUnload = this.HostedControlUnload;
      if (hostedControlUnload == null)
        return;
      hostedControlUnload((object) this, new AspControlEventArgs((System.Web.UI.Control) sender));
    }

    /// <summary>
    /// 
    /// </summary>
    public event AspControlEventHandler HostedControlPreRender;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnHostedControlPreRender(object sender, EventArgs e)
    {
      AspControlEventHandler controlPreRender = this.HostedControlPreRender;
      if (controlPreRender == null)
        return;
      controlPreRender((object) this, new AspControlEventArgs((System.Web.UI.Control) sender));
    }

    /// <summary>
    /// 
    /// </summary>
    public event AspControlEventHandler HostedControlLoad;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnHostedControlLoad(object sender, EventArgs e)
    {
      AspControlEventHandler hostedControlLoad = this.HostedControlLoad;
      if (hostedControlLoad == null)
        return;
      hostedControlLoad((object) this, new AspControlEventArgs((System.Web.UI.Control) sender));
    }

    /// <summary>
    /// 
    /// </summary>
    public event AspControlEventHandler HostedControlInit;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void OnHostedControlInit(object sender, EventArgs e)
    {
      AspControlEventHandler hostedControlInit = this.HostedControlInit;
      if (hostedControlInit == null)
        return;
      hostedControlInit((object) this, new AspControlEventArgs((System.Web.UI.Control) sender));
    }

    /// <summary>Creates the hosted control.</summary>
    /// <returns></returns>
    private System.Web.UI.Control CreateHostedControlContainer(AspPipeLinePage objHostedPage)
    {
      if (Activator.CreateInstance(this.ControlCodeType) is System.Web.UI.UserControl instance)
        instance.InitializeAsUserControl((Page) objHostedPage);
      return (System.Web.UI.Control) instance;
    }

    /// <summary>Provides a way to handle gateway requests.</summary>
    /// <param name="objHttpContext">The gateway request HTTP context.</param>
    /// <param name="strAction">The gateway request action.</param>
    /// <returns>
    /// By default this method returns a instance of a class which implements the IGatewayHandler and
    /// throws a non implemented HttpException.
    /// </returns>
    /// <remarks>
    /// This method is called from the implementation of IGatewayComponent which replaces the
    /// IGatewayControl interface. The IGatewayCompoenent is implemented by default in the
    /// RegisteredComponent class which is the base class of most of the Visual WebGui
    /// components.
    /// Referencing a RegisterComponent that overrides this method is done the same way that
    /// a control implementing IGatewayControl, which is by using the GatewayReference class.
    /// </remarks>
    protected override IGatewayHandler ProcessGatewayRequest(
      HttpContext objHttpContext,
      string strAction)
    {
      if (objHttpContext == null)
        throw new HttpException("ASP.NET runtime is unavailable.");
      this.IsAspRequest = true;
      objHttpContext.Response.Buffer = true;
      try
      {
        AspPipeLinePage aspPipeLinePage = this.HostedPage;
        if (aspPipeLinePage == null)
          this.HostedPage = aspPipeLinePage = this.CreateHostPage();
        if (aspPipeLinePage != null)
        {
          if (this.CompatibilityMode != AspControlBoxBase.VersionCompatibilityMode.Version6)
          {
            if (objHttpContext.Request.HttpMethod == "GET")
            {
              if (this.SyncPostData != null)
                this.EmulatePost(objHttpContext.Request, this.SyncPostData);
            }
            else
            {
              this.SyncPostData = new NameValueCollection();
              foreach (string name in (NameObjectCollectionBase) objHttpContext.Request.Form)
              {
                if (!(name == AspPipeLinePage.VwgPipelineName))
                  this.SyncPostData.Add(name, objHttpContext.Request.Form[name]);
              }
            }
          }
          aspPipeLinePage.ProcessRequest(objHttpContext);
        }
      }
      finally
      {
        this.IsAspRequest = false;
        this.HostedPage = (AspPipeLinePage) null;
      }
      return (IGatewayHandler) null;
    }

    /// <summary>Gets the view state.</summary>
    /// <returns></returns>
    internal object GetViewStateInternal() => this.ViewState;

    /// <summary>Sets the view state.</summary>
    /// <param name="objState">The current view state to set.</param>
    internal void SetViewStateInternal(object objState) => this.ViewState = objState;

    /// <summary>Gets the control state.</summary>
    /// <returns></returns>
    internal object GetControlStateInternal() => this.ControlState;

    /// <summary>Sets the control state.</summary>
    /// <param name="objState">The current control state to set.</param>
    internal void SetControlStateInternal(object objState) => this.ControlState = objState;

    /// <summary>Sets a hosted control property value</summary>
    /// <param name="strName"></param>
    /// <param name="objValue"></param>
    protected void SetProperty(string strName, object objValue)
    {
      PropertyInfo propertyInfo = this.GetPropertyInfo(strName);
      if (!(propertyInfo != (PropertyInfo) null) || !propertyInfo.CanWrite)
        return;
      if (!this.CanAccessHostControl)
      {
        Dictionary<string, object> dictionary = this.DesignTimeProperties;
        if (dictionary == null)
        {
          dictionary = new Dictionary<string, object>();
          this.DesignTimeProperties = dictionary;
        }
        dictionary[strName] = objValue;
      }
      else
      {
        propertyInfo.SetValue((object) this.HostedControl, objValue, (object[]) null);
        this.AspUpdate();
      }
    }

    /// <summary>
    /// Gets a value indicating whether this instance is parent valid.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is parent valid; otherwise, <c>false</c>.
    /// </value>
    private bool IsParentValid => this.Parent != null;

    /// <summary>
    /// Gets a value indicating whether control code is valid.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if control code is valid; otherwise, <c>false</c>.
    /// </value>
    private bool IsCodeControlValid => !string.IsNullOrEmpty(this.ControlCode);

    /// <summary>Gets a hosted control boolean property value</summary>
    /// <param name="strName"></param>
    /// <returns></returns>
    protected bool GetBoolProperty(string strName) => (bool) this.GetProperty(strName);

    /// <summary>Gets a hosted control integer property value</summary>
    /// <param name="strName"></param>
    /// <returns></returns>
    protected int GetIntProperty(string strName) => (int) this.GetProperty(strName);

    /// <summary>Gets a hosted control color property value</summary>
    /// <param name="strName"></param>
    /// <returns></returns>
    protected Color GetColorProperty(string strName) => (Color) this.GetProperty(strName);

    /// <summary>Resets the specified property.</summary>
    /// <param name="strPropertyName">The property name.</param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected void Reset(string strPropertyName)
    {
      PropertyInfo propertyInfo = this.GetPropertyInfo(strPropertyName);
      if (!(propertyInfo != (PropertyInfo) null))
        return;
      this.SetProperty(strPropertyName, this.GetPropertyDefaultValue(propertyInfo));
    }

    /// <summary>
    /// General purpose should serialize method for evaluating property should serialize methods.
    /// </summary>
    /// <param name="strPropertyName">The property name.</param>
    /// <returns></returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    protected bool ShouldSerialize(string strPropertyName)
    {
      object property = this.GetProperty(strPropertyName);
      Dictionary<string, object> dictionary = this.DefaultDesignValues;
      if (dictionary == null)
      {
        dictionary = new Dictionary<string, object>();
        this.DefaultDesignValues = dictionary;
      }
      if (!dictionary.ContainsKey(strPropertyName))
      {
        PropertyInfo propertyInfo = this.GetPropertyInfo(strPropertyName);
        dictionary[strPropertyName] = !(propertyInfo != (PropertyInfo) null) ? (object) null : this.GetPropertyDefaultValue(propertyInfo);
      }
      object obj = dictionary[strPropertyName];
      if (obj == null && property == null)
        return false;
      return obj == null && property != null || obj != null && property == null || !property.Equals(obj);
    }

    /// <summary>Gets a hosted control property value</summary>
    /// <param name="strName"></param>
    /// <returns></returns>
    protected object GetProperty(string strName)
    {
      PropertyInfo propertyInfo = this.GetPropertyInfo(strName);
      if (!(propertyInfo != (PropertyInfo) null))
        return (object) null;
      if (this.CanAccessHostControl)
        return propertyInfo.GetValue((object) this.HostedControl, (object[]) null);
      Dictionary<string, object> designTimeProperties = this.DesignTimeProperties;
      return designTimeProperties != null && designTimeProperties.ContainsKey(strName) ? designTimeProperties[strName] : this.GetPropertyDefaultValue(propertyInfo);
    }

    /// <summary>
    /// Gets a value indicating whether running in design mode.
    /// </summary>
    /// <value><c>true</c> if in design mode; otherwise, <c>false</c>.</value>
    private bool InDesignMode => this.DesignMode || HostContext.Current == null;

    /// <summary>
    /// Add an event handler to one of the control's event infos.
    /// </summary>
    /// <param name="strName"></param>
    /// <param name="objEventHandler"></param>
    protected void AddEventHandler(string strName, Delegate objEventHandler)
    {
      if (this.CompatibilityMode == AspControlBoxBase.VersionCompatibilityMode.Version6)
        this.Version6AddEventHandler(strName, objEventHandler);
      else if (this.CanAccessHostControl)
      {
        this.AddEventHandler(strName, objEventHandler, this.HostedControl);
      }
      else
      {
        Dictionary<string, List<Delegate>> dictionary = this.DesignTimeEventHandlers;
        if (dictionary == null)
        {
          dictionary = new Dictionary<string, List<Delegate>>();
          this.DesignTimeEventHandlers = dictionary;
        }
        List<Delegate> delegateList;
        if (!dictionary.TryGetValue(strName, out delegateList))
        {
          delegateList = new List<Delegate>();
          dictionary.Add(strName, delegateList);
        }
        delegateList.Add(objEventHandler);
      }
    }

    /// <summary>
    /// Add an event handler to one of the control's event infos.
    /// </summary>
    /// <param name="strName"></param>
    /// <param name="objEventHandler"></param>
    private void AddEventHandler(
      string strName,
      Delegate objEventHandler,
      System.Web.UI.Control objHostedControl)
    {
      EventInfo eventInfo = this.GetEventInfo(strName);
      if (!(eventInfo != (EventInfo) null))
        return;
      this.GetEventHandlers(strName, true)?.Add(objEventHandler);
      eventInfo.AddEventHandler((object) objHostedControl, objEventHandler);
    }

    /// <summary>
    /// Removes an event handler from one of the control's event infos.
    /// </summary>
    /// <param name="strName"></param>
    /// <param name="objEventHandler"></param>
    protected void RemoveEventHandler(string strName, Delegate objEventHandler)
    {
      if (this.CompatibilityMode == AspControlBoxBase.VersionCompatibilityMode.Version6)
        this.Version6RemoveEventHandler(strName, objEventHandler);
      else if (this.CanAccessHostControl)
      {
        if (!(this.GetEventInfo(strName) != (EventInfo) null))
          return;
        List<Delegate> eventHandlers = this.GetEventHandlers(strName, false);
        if (eventHandlers == null || !eventHandlers.Contains(objEventHandler))
          return;
        eventHandlers.Remove(objEventHandler);
      }
      else
      {
        Dictionary<string, List<Delegate>> timeEventHandlers = this.DesignTimeEventHandlers;
        List<Delegate> delegateList;
        if (timeEventHandlers == null || !timeEventHandlers.TryGetValue(strName, out delegateList))
          return;
        delegateList.Remove(objEventHandler);
      }
    }

    /// <summary>Gets the event handlers for a given event.</summary>
    /// <param name="strName">Name of the STR.</param>
    /// <returns></returns>
    private List<Delegate> GetEventHandlers(string strName) => this.GetEventHandlers(strName, false);

    /// <summary>Gets the event handlers for a given event.</summary>
    /// <param name="strName">Name of the STR.</param>
    /// <param name="blnCreate">if set to <c>true</c> [BLN create].</param>
    /// <returns></returns>
    private List<Delegate> GetEventHandlers(string strName, bool blnCreate)
    {
      List<Delegate> eventHandlers1 = (List<Delegate>) null;
      Dictionary<string, List<Delegate>> eventHandlers2 = this.EventHandlers;
      if (eventHandlers2.ContainsKey(strName) && eventHandlers2[strName] != null)
        eventHandlers1 = eventHandlers2[strName];
      if (eventHandlers1 == null && blnCreate)
      {
        eventHandlers1 = new List<Delegate>();
        eventHandlers2.Add(strName, eventHandlers1);
      }
      return eventHandlers1;
    }

    /// <summary>
    /// Recieve system.web type name (Without assembly) and return its type.
    /// </summary>
    private Type GetSystemWebFullTypeName(string typeName) => Type.GetType(typeName + ", " + CommonUtils.GetFullAssemblyName("System.Web"));

    /// <summary>Gets the property default value.</summary>
    /// <param name="objPropertyInfo">The property info.</param>
    /// <returns></returns>
    private object GetPropertyDefaultValue(PropertyInfo objPropertyInfo)
    {
      Type propertyType = objPropertyInfo.PropertyType;
      object[] objArray;
      for (objArray = new object[0]; objArray.Length == 0 && objPropertyInfo.ReflectedType.BaseType != (Type) null; objPropertyInfo = objPropertyInfo.ReflectedType.BaseType.GetProperty(objPropertyInfo.Name))
      {
        objArray = objPropertyInfo.GetCustomAttributes(typeof (DefaultValueAttribute), true);
        if (!(objPropertyInfo.ReflectedType.BaseType.GetProperty(objPropertyInfo.Name) != (PropertyInfo) null))
          break;
      }
      return objArray.Length != 0 && ((DefaultValueAttribute) objArray[0]).Value != null && objPropertyInfo.PropertyType == ((DefaultValueAttribute) objArray[0]).Value.GetType() ? ((DefaultValueAttribute) objArray[0]).Value : CommonUtils.GetTypeDefaultValue(propertyType);
    }

    /// <summary>Get an event information object.</summary>
    /// <param name="strName"></param>
    /// <returns></returns>
    protected EventInfo GetEventInfo(string strName)
    {
      EventInfo eventInfo = (EventInfo) null;
      Dictionary<string, EventInfo> eventsList = this.EventsList;
      if (eventsList.ContainsKey(strName))
        eventInfo = eventsList[strName];
      if (eventInfo == (EventInfo) null)
        eventsList[strName] = eventInfo = this.HostedControlType.GetEvent(strName);
      return eventInfo;
    }

    /// <summary>Get property info</summary>
    /// <param name="strName"></param>
    /// <returns></returns>
    protected PropertyInfo GetPropertyInfo(string strName)
    {
      PropertyInfo propertyInfo = (PropertyInfo) null;
      Dictionary<string, PropertyInfo> properties = this.Properties;
      if (properties.ContainsKey(strName))
        propertyInfo = properties[strName];
      else if (propertyInfo == (PropertyInfo) null)
        properties[strName] = propertyInfo = this.HostedControlType.GetProperty(strName);
      return propertyInfo;
    }

    /// <summary>Restores hosted control events</summary>
    private void RestoreControlDesignEvents(System.Web.UI.Control objHostedControl)
    {
      if (objHostedControl == null)
        return;
      if (this.CompatibilityMode != AspControlBoxBase.VersionCompatibilityMode.Version6)
      {
        Dictionary<string, List<Delegate>> timeEventHandlers = this.DesignTimeEventHandlers;
        if (timeEventHandlers != null)
        {
          string[] array = new string[timeEventHandlers.Keys.Count];
          timeEventHandlers.Keys.CopyTo(array, 0);
          foreach (string str in array)
          {
            foreach (Delegate objEventHandler in timeEventHandlers[str])
              this.AddEventHandler(str, objEventHandler, objHostedControl);
          }
          this.DesignTimeEventHandlers = (Dictionary<string, List<Delegate>>) null;
        }
      }
      foreach (EventInfo eventInfo in this.EventsList.Values)
      {
        List<Delegate> eventHandlers = this.GetEventHandlers(eventInfo.Name, false);
        if (eventHandlers != null)
        {
          foreach (Delegate handler in eventHandlers)
            eventInfo.AddEventHandler((object) objHostedControl, handler);
        }
      }
    }

    /// <summary>Restores hosted control properties</summary>
    private void TryRestoreControlDesignProperties(System.Web.UI.Control objHostedControl)
    {
      if (objHostedControl == null)
        return;
      Dictionary<string, object> designTimeProperties = this.DesignTimeProperties;
      if (designTimeProperties == null)
        return;
      string[] array = new string[designTimeProperties.Keys.Count];
      designTimeProperties.Keys.CopyTo(array, 0);
      foreach (string str in array)
        this.SetProperty(str, designTimeProperties[str]);
      this.DesignTimeProperties = (Dictionary<string, object>) null;
    }

    protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
    {
      base.RenderAttributes(objContext, objWriter);
      this.RenderSyncChangesOnVwgPostBack(objWriter, false);
    }

    protected override void RenderUpdatedAttributes(
      IContext objContext,
      IAttributeWriter objWriter,
      long lngRequestID)
    {
      base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
      if (!this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
        return;
      this.RenderSyncChangesOnVwgPostBack(objWriter, true);
    }

    private void RenderSyncChangesOnVwgPostBack(IAttributeWriter objWriter, bool blnForce)
    {
      if (this.CompatibilityMode == AspControlBoxBase.VersionCompatibilityMode.Version6)
        objWriter.WriteAttributeString("SCV", "0");
      else if (this.SyncChangesOnVwgPostBack != SyncPostDataChangesMode.None)
      {
        string strValue = this.SyncChangesOnVwgPostBack == SyncPostDataChangesMode.On ? "1" : "0";
        objWriter.WriteAttributeString("SCV", strValue);
      }
      else
      {
        if (!blnForce)
          return;
        objWriter.WriteAttributeString("SCV", "");
      }
    }

    public void AspUpdate()
    {
      if (this.CompatibilityMode == AspControlBoxBase.VersionCompatibilityMode.Version6 || this.IsAspRequest || this.IsFirstVwgRequest)
        return;
      this.mblnAspUpdate = true;
    }

    /// <summary>
    /// Gets or sets the hosted control, that will be saved when in the vwg request there is AspUpdate,
    /// this AspUpdateHostedControl will be set instead of the HostedControl created in the AspRequest in the LoadCompleted stage.
    /// </summary>
    private System.Web.UI.Control HostedControlForAspUpdate
    {
      get => this.mobjHostedControlForAspUpdate;
      set => this.mobjHostedControlForAspUpdate = value;
    }

    /// <summary>An abstract control method rendering</summary>
    /// <param name="objContext"></param>
    /// <param name="objWriter"></param>
    /// <param name="lngRequestID"></param>
    protected override void Render(
      IContext objContext,
      IResponseWriter objWriter,
      long lngRequestID)
    {
      base.Render(objContext, objWriter, lngRequestID);
      if (this.CompatibilityMode != AspControlBoxBase.VersionCompatibilityMode.Version6)
        return;
      this.Version6Render(objContext, objWriter, lngRequestID);
    }

    protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
    {
      base.PreRenderControl(objContext, lngRequestID);
      if (this.mblnAspUpdate)
      {
        VWGClientContext.Current.Invoke((ISkinable) this, "AspControlBoxBase_UpdateAspControl", (object) this.ID);
        this.HostedControlForAspUpdate = this.HostedControl;
        this.mblnProcessMainEndRequired = false;
      }
      else if (this.mblnProcessMainEndRequired)
      {
        this.HostedPage.ProcessMainEnd();
        this.mblnProcessMainEndRequired = false;
      }
      if (!this.IsAspRequest)
        this.HostedPage = (AspPipeLinePage) null;
      this.mblnAspUpdate = false;
    }

    /// <summary>Gets or sets the last sync post data.</summary>
    private NameValueCollection SyncPostData
    {
      get => this.GetValue<NameValueCollection>(AspControlBoxBase.SyncPostDataProperty, (NameValueCollection) null);
      set => this.SetValue<NameValueCollection>(AspControlBoxBase.SyncPostDataProperty, value);
    }

    /// <summary>
    /// Gets and sets a value indicating whether to synchronize changes of input fields of the asp control in vwg raise events.
    /// In case the value is null, it will synchornize changes only if there are input fields in the control.
    /// </summary>
    [DefaultValue(SyncPostDataChangesMode.None)]
    [Category("Behavior")]
    [Description("Synchronize changes of input fields of the asp control in vwg raise events. In case the value is null, it will synchornize changes only if there are input fields in the control.")]
    public virtual SyncPostDataChangesMode SyncChangesOnVwgPostBack
    {
      get => this.GetValue<SyncPostDataChangesMode>(AspControlBoxBase.SyncChangesOnVwgPostBackProperty, SyncPostDataChangesMode.None);
      set
      {
        if (!this.SetValue<SyncPostDataChangesMode>(AspControlBoxBase.SyncChangesOnVwgPostBackProperty, value))
          return;
        this.UpdateParams(AttributeType.Control);
      }
    }

    /// <summary>Gets and sets a</summary>
    [Category("Behavior")]
    [Description("Urls to scripts js that will be registered in the asp page.")]
    public string[] Scripts
    {
      get
      {
        string[] scripts = this.GetValue<string[]>(AspControlBoxBase.ScriptsProperty);
        if (scripts == null)
        {
          scripts = new string[0];
          this.Scripts = scripts;
        }
        return scripts;
      }
      set
      {
        if (!this.SetValue<string[]>(AspControlBoxBase.ScriptsProperty, value))
          return;
        this.AspUpdate();
      }
    }

    private bool ShouldSerializeScripts() => this.Scripts.Length != 0;

    /// <summary>Gets and sets a</summary>
    [Category("Behavior")]
    [Description("Urls to styles js that will be registered in the asp page.")]
    public string[] Styles
    {
      get
      {
        string[] styles = this.GetValue<string[]>(AspControlBoxBase.StylesProperty);
        if (styles == null)
        {
          styles = new string[0];
          this.Styles = styles;
        }
        return styles;
      }
      set
      {
        if (!this.SetValue<string[]>(AspControlBoxBase.StylesProperty, value))
          return;
        this.AspUpdate();
      }
    }

    private bool ShouldSerializeStyles() => this.Styles.Length != 0;

    /// <summary>
    /// Gets or sets the control ID, which indicates the id of the hosted control with in the control code.
    /// </summary>
    /// <value>The control ID.</value>
    [Category("Behavior")]
    [Description("The control ID of the hosted control in the markup code.")]
    [DefaultValue("hosted_control_id")]
    public string ControlID
    {
      get => this.GetValue<string>(AspControlBoxBase.ControlIDProperty, "hosted_control_id");
      set
      {
        if (!(this.ControlID != value))
          return;
        if (string.IsNullOrEmpty(value) || value == "hosted_control_id")
          this.RemoveValue<string>(AspControlBoxBase.ControlIDProperty);
        else
          this.SetValue<string>(AspControlBoxBase.ControlIDProperty, value);
      }
    }

    /// <summary>Gets or sets the control code.</summary>
    /// <value>The control code.</value>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    [Editor("Gizmox.WebGUI.Forms.Design.AspCodeEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [Category("Behavior")]
    [Description("Provides a way to initialize the control using ASP.NET markup.")]
    public string ControlCode
    {
      get
      {
        string controlCode = this.GetValue<string>(AspControlBoxBase.ControlCodeProperty, string.Empty);
        if (string.IsNullOrEmpty(controlCode))
        {
          string str1 = "ctrl";
          string fullName = this.HostedControlType.Assembly.FullName;
          string str2 = this.HostedControlType.Namespace;
          string name = this.HostedControlType.Name;
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.Append("<%@ Control Language=\"C#\"%>");
          stringBuilder.AppendLine();
          stringBuilder.AppendFormat("<%@ Register TagPrefix=\"{0}\" Assembly=\"{1}\" Namespace=\"{2}\" %>", (object) str1, (object) fullName, (object) str2);
          stringBuilder.AppendLine();
          stringBuilder.AppendFormat("<{0}:{1} ID=\"{2}\" runat=\"server\" />", (object) str1, (object) name, (object) this.ControlID);
          stringBuilder.AppendLine();
          controlCode = stringBuilder.ToString();
        }
        return controlCode;
      }
      set
      {
        if (!(this.ControlCode != value))
          return;
        if (string.IsNullOrEmpty(value))
        {
          this.RemoveValue<string>(AspControlBoxBase.ControlCodeProperty);
        }
        else
        {
          this.SetValue<string>(AspControlBoxBase.ControlCodeProperty, value);
          this.ControlCodeType = (Type) null;
        }
      }
    }

    /// <summary>Gets the type of the control container.</summary>
    /// <value>The type of the control container.</value>
    private Type ControlCodeType
    {
      get
      {
        Type objValue = this.GetValue<Type>(AspControlBoxBase.ControlCodeTypeProperty, (Type) null);
        if (objValue == (Type) null && !this.DesignModeExtended)
        {
          string controlCode = this.ControlCode;
          objValue = controlCode.IndexOf("<%@") <= -1 ? AspControlBoxBase.ResourceProvider.GetVirtualPathType(controlCode) : AspControlBoxBase.ResourceProvider.GetCompiledType(this.ControlCode);
          this.SetValue<Type>(AspControlBoxBase.ControlCodeTypeProperty, objValue);
        }
        return objValue;
      }
      set
      {
        if (!(this.ControlCodeType != value))
          return;
        if (value == (Type) null)
          this.RemoveValue<Type>(AspControlBoxBase.ControlCodeTypeProperty);
        else
          this.SetValue<Type>(AspControlBoxBase.ControlCodeTypeProperty, value);
      }
    }

    private bool DesignModeExtended => this.DesignMode || HostContext.Current == null;

    /// <summary>
    /// Gets or sets a value indicating whether the container enables the user to scroll to any controls placed outside of its visible boundaries.
    /// </summary>
    /// <value>true if the container enables auto-scrolling; otherwise, false. The default value is true.</value>
    [Gizmox.WebGUI.Forms.SRCategory("CatLayout")]
    [Gizmox.WebGUI.Forms.SRDescription("FormAutoScrollDescr")]
    [DefaultValue(true)]
    public virtual bool AutoScroll
    {
      get => this.GetValue<bool>(AspControlBoxBase.AutoScrollProperty, true);
      set
      {
        if (this.AutoScroll == value)
          return;
        if (value)
          this.RemoveValue<bool>(AspControlBoxBase.AutoScrollProperty);
        else
          this.SetValue<bool>(AspControlBoxBase.AutoScrollProperty, value);
        this.UpdateParams(AttributeType.Visual);
      }
    }

    /// <summary>
    /// Gets or sets a value that specifies the wrap control behavior.
    /// </summary>
    protected internal virtual AspControlBoxBase.VersionCompatibilityMode CompatibilityMode => AspControlBoxBase.VersionCompatibilityMode.Version6;

    /// <summary>Gets a value indicating whether this is ASP request.</summary>
    /// <value>
    /// 	<c>true</c> if this is ASP request; otherwise, <c>false</c>.
    /// </value>
    [Browsable(false)]
    public bool IsAspRequest
    {
      get => this.GetValue<bool>(AspControlBoxBase.IsAspRequestProperty, false);
      private set
      {
        if (this.IsAspRequest == value)
          return;
        if (!value)
          this.RemoveValue<bool>(AspControlBoxBase.IsAspRequestProperty);
        else
          this.SetValue<bool>(AspControlBoxBase.IsAspRequestProperty, value);
      }
    }

    /// <summary>
    /// Gets a value indicating whether the hosted control accessing is allowed.
    /// </summary>
    private bool CanAccessHostControl
    {
      get
      {
        if (this.CompatibilityMode == AspControlBoxBase.VersionCompatibilityMode.Version6)
          return this.Version6CanAccessHostControl;
        return !this.InDesignMode && this.IsCodeControlValid && !this.IsFirstVwgRequest;
      }
    }

    /// <summary>
    /// Gets a value indicating whether we are in the first vwg request. (ProcessGateway was not called yet.
    /// </summary>
    internal bool IsFirstVwgRequest
    {
      get
      {
        object viewStateInternal = this.GetViewStateInternal();
        return !this.IsAspRequest && viewStateInternal == null;
      }
    }

    /// <summary>Get the currently hosted control</summary>
    protected System.Web.UI.Control HostedControl
    {
      get
      {
        if (this.CompatibilityMode == AspControlBoxBase.VersionCompatibilityMode.Version6)
          return this.Version6HostedControl;
        if (this.InDesignMode)
          throw new Exception("Hosted control can not be used in design mode.");
        if (this.HostedPage == null)
        {
          this.HostedPage = this.CreateHostPage();
          if (!this.IsAspRequest)
            this.HostedPage.ProcessMainStart();
        }
        return this.HostedPage.HostedControl;
      }
    }

    /// <summary>The hosted ASP.NET control type</summary>
    protected virtual Type HostedControlType => typeof (System.Web.UI.Control);

    /// <summary>Gets the name of the form.</summary>
    /// <value>The name of the form.</value>
    private string FormName => string.Format("ctrl1_{0}", (object) this.Name);

    /// <summary>Gets the name of the script manager.</summary>
    /// <value>The name of the script manager.</value>
    private string ScriptManagerName => string.Format("ctrl0_{0}", (object) this.Name);

    /// <summary>Gets the control properties.</summary>
    /// <value>The control properties.</value>
    private Dictionary<string, PropertyInfo> Properties
    {
      get => this.GetValue<Dictionary<string, PropertyInfo>>(AspControlBoxBase.PropertiesProperty, (Dictionary<string, PropertyInfo>) null);
      set
      {
        if (this.Properties == value)
          return;
        if (value == null)
          this.RemoveValue<Dictionary<string, PropertyInfo>>(AspControlBoxBase.PropertiesProperty);
        else
          this.SetValue<Dictionary<string, PropertyInfo>>(AspControlBoxBase.PropertiesProperty, value);
      }
    }

    /// <summary>Gets or sets the design time properties.</summary>
    /// <value>The design time properties.</value>
    private Dictionary<string, object> DesignTimeProperties
    {
      get => this.GetValue<Dictionary<string, object>>(AspControlBoxBase.DesignTimePropertiesProperty, (Dictionary<string, object>) null);
      set
      {
        if (this.DesignTimeProperties == value)
          return;
        if (value == null)
          this.RemoveValue<Dictionary<string, object>>(AspControlBoxBase.DesignTimePropertiesProperty);
        else
          this.SetValue<Dictionary<string, object>>(AspControlBoxBase.DesignTimePropertiesProperty, value);
      }
    }

    /// <summary>Gets or sets the design time events.</summary>
    /// <value>The design time events.</value>
    private Dictionary<string, List<Delegate>> DesignTimeEventHandlers
    {
      get => this.GetValue<Dictionary<string, List<Delegate>>>(AspControlBoxBase.DesignTimeEventHandlersProperty, (Dictionary<string, List<Delegate>>) null);
      set
      {
        if (this.DesignTimeEventHandlers == value)
          return;
        this.SetValue<Dictionary<string, List<Delegate>>>(AspControlBoxBase.DesignTimeEventHandlersProperty, value);
      }
    }

    /// <summary>Gets or sets the default design values.</summary>
    /// <value>The default design values.</value>
    private Dictionary<string, object> DefaultDesignValues
    {
      get => this.GetValue<Dictionary<string, object>>(AspControlBoxBase.DefaultDesignValuesProperty, (Dictionary<string, object>) null);
      set
      {
        if (this.DefaultDesignValues == value)
          return;
        if (value == null)
          this.RemoveValue<Dictionary<string, object>>(AspControlBoxBase.DefaultDesignValuesProperty);
        else
          this.SetValue<Dictionary<string, object>>(AspControlBoxBase.DefaultDesignValuesProperty, value);
      }
    }

    /// <summary>Gets or sets the events.</summary>
    /// <value>The events.</value>
    private Dictionary<string, EventInfo> EventsList
    {
      get => this.GetValue<Dictionary<string, EventInfo>>(AspControlBoxBase.EventsProperty, (Dictionary<string, EventInfo>) null);
      set
      {
        if (this.EventsList == value)
          return;
        if (value == null)
          this.RemoveValue<Dictionary<string, EventInfo>>(AspControlBoxBase.EventsProperty);
        else
          this.SetValue<Dictionary<string, EventInfo>>(AspControlBoxBase.EventsProperty, value);
      }
    }

    /// <summary>Gets the events.</summary>
    /// <value>The events.</value>
    protected Dictionary<string, List<Delegate>> Events => this.EventHandlers;

    /// <summary>Gets or sets the event handlers.</summary>
    /// <value>The event handlers.</value>
    private Dictionary<string, List<Delegate>> EventHandlers
    {
      get => this.GetValue<Dictionary<string, List<Delegate>>>(AspControlBoxBase.EventHandlersProperty, (Dictionary<string, List<Delegate>>) null);
      set
      {
        if (this.EventHandlers == value)
          return;
        this.SetValue<Dictionary<string, List<Delegate>>>(AspControlBoxBase.EventHandlersProperty, value);
      }
    }

    /// <summary>Gets or sets the hosted page.</summary>
    /// <value>The hosted page.</value>
    private AspPipeLinePage HostedPage
    {
      get => this.CompatibilityMode == AspControlBoxBase.VersionCompatibilityMode.Version6 ? this.Version6HostedPage : this.mobjHostedPage;
      set
      {
        if (this.CompatibilityMode == AspControlBoxBase.VersionCompatibilityMode.Version6)
          this.Version6HostedPage = value;
        else
          this.mobjHostedPage = value;
      }
    }

    /// <summary>Gets or sets the state of the view.</summary>
    /// <value>The state of the view.</value>
    private object ViewState
    {
      get => this.GetValue<object>(AspControlBoxBase.ViewStateProperty, (object) null);
      set
      {
        if (this.ViewState == value)
          return;
        if (value == null)
          this.RemoveValue<object>(AspControlBoxBase.ViewStateProperty);
        else
          this.SetValue<object>(AspControlBoxBase.ViewStateProperty, value);
      }
    }

    /// <summary>Gets or sets the state of the control.</summary>
    /// <value>The state of the control.</value>
    private object ControlState
    {
      get => this.GetValue<object>(AspControlBoxBase.ControlStateProperty, (object) null);
      set
      {
        if (this.ControlState == value)
          return;
        if (value == null)
          this.RemoveValue<object>(AspControlBoxBase.ControlStateProperty);
        else
          this.SetValue<object>(AspControlBoxBase.ControlStateProperty, value);
      }
    }

    private void Version6AddEventHandler(string strName, Delegate objEventHandler)
    {
      EventInfo eventInfo = this.GetEventInfo(strName);
      if (!(eventInfo != (EventInfo) null))
        return;
      this.GetEventHandlers(strName, true)?.Add(objEventHandler);
      if (this.InDesignMode || this.HostedControl == null)
        return;
      eventInfo.AddEventHandler((object) this.HostedControl, objEventHandler);
    }

    protected void Version6RemoveEventHandler(string strName, Delegate objEventHandler)
    {
      EventInfo eventInfo = this.GetEventInfo(strName);
      if (!(eventInfo != (EventInfo) null))
        return;
      List<Delegate> eventHandlers = this.GetEventHandlers(strName, false);
      if (eventHandlers != null && eventHandlers.Contains(objEventHandler))
        eventHandlers.Remove(objEventHandler);
      if (this.InDesignMode)
        return;
      eventInfo.RemoveEventHandler((object) this.HostedControl, objEventHandler);
    }

    private void Version6Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
    {
      AspPipeLinePage hostedPage = this.HostedPage;
      if (hostedPage == null || this.IsAspRequest)
        return;
      hostedPage.ProcessMainEnd();
      this.HostedPage = (AspPipeLinePage) null;
    }

    private bool Version6CanAccessHostControl => !this.InDesignMode && this.IsCodeControlValid && this.IsParentValid;

    private System.Web.UI.Control Version6HostedControl
    {
      get
      {
        if (this.InDesignMode)
          throw new Exception("Hosted control can not be used in design mode.");
        AspPipeLinePage aspPipeLinePage = this.HostedPage;
        if (aspPipeLinePage == null)
        {
          aspPipeLinePage = this.CreateHostPage();
          if (!this.IsAspRequest && !this.InDesignMode && aspPipeLinePage != null)
          {
            this.HostedPage = aspPipeLinePage;
            aspPipeLinePage.ProcessMainStart();
          }
        }
        return aspPipeLinePage.HostedControl;
      }
    }

    /// <summary>Gets or sets the hosted page.</summary>
    /// <value>The hosted page.</value>
    private AspPipeLinePage Version6HostedPage
    {
      get => this.GetValue<AspPipeLinePage>(AspControlBoxBase.AspPipeLinePageProperty, (AspPipeLinePage) null);
      set
      {
        if (this.Version6HostedPage == value)
          return;
        if (value == null)
          this.RemoveValue<AspPipeLinePage>(AspControlBoxBase.AspPipeLinePageProperty);
        else
          this.SetValue<AspPipeLinePage>(AspControlBoxBase.AspPipeLinePageProperty, value);
      }
    }

    /// <summary>
    /// Provides an implementation of a virtual file that can compile a code at runtime from a string or an embeded resource
    /// </summary>
    [Serializable]
    internal class ResourceFile : VirtualFile
    {
      /// <summary>The relative path produced from the virtual path</summary>
      private string mstrRelativePath;

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase.ResourceFile" /> class.
      /// </summary>
      /// <param name="strVirtualPath">The virtual path.</param>
      internal ResourceFile(string strVirtualPath)
        : base(strVirtualPath)
      {
        this.mstrRelativePath = VirtualPathUtility.ToAppRelative(strVirtualPath);
      }

      /// <summary>Opens this instance.</summary>
      /// <returns></returns>
      public override Stream Open()
      {
        string[] strArray = this.mstrRelativePath.Split('/');
        string str1 = strArray.Length > 1 ? strArray[1] : "";
        if (strArray.Length > 2)
        {
          string str2 = strArray[2];
        }
        int startIndex = "VWG_AspResource".Length + 1;
        return AspControlBoxBase.ResourceProvider.GetBuildCode(new Guid(str1.Substring(startIndex).Replace(".ascx", "")));
      }

      private Stream GetDisconectedStream(Assembly objAssembly, string strResourceName)
      {
        Stream manifestResourceStream = objAssembly.GetManifestResourceStream(strResourceName);
        if (manifestResourceStream == null)
          return (Stream) null;
        MemoryStream disconectedStream = new MemoryStream();
        StreamReader streamReader = new StreamReader(manifestResourceStream);
        StreamWriter streamWriter = new StreamWriter((Stream) disconectedStream);
        streamWriter.Write(streamReader.ReadToEnd());
        streamWriter.Flush();
        disconectedStream.Position = 0L;
        manifestResourceStream.Close();
        return (Stream) disconectedStream;
      }
    }

    /// <summary>
    /// Provides a custom resource provider to help build types from string or an embeded resource
    /// </summary>
    [Serializable]
    internal class ResourceProvider : VirtualPathProvider
    {
      internal const string VwgResourcePrefix = "VWG_AspResource";
      /// <summary>Temporary stored code strings</summary>
      private static Dictionary<Guid, string> mobjTemporaryStoredCode = new Dictionary<Guid, string>();

      /// <summary>
      /// Initializes the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase.ResourceProvider" /> class.
      /// </summary>
      static ResourceProvider() => HostingEnvironment.RegisterVirtualPathProvider((VirtualPathProvider) new AspControlBoxBase.ResourceProvider());

      /// <summary>
      /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase.ResourceProvider" /> class.
      /// </summary>
      internal ResourceProvider()
      {
      }

      /// <summary>Determines whether virtual path is a resource path.</summary>
      /// <param name="strVirtualPath">The virtual path.</param>
      /// <returns>
      /// 	<c>true</c> if virtual path is a resource path; otherwise, <c>false</c>.
      /// </returns>
      private bool IsAppResourcePath(string strVirtualPath) => VirtualPathUtility.ToAppRelative(strVirtualPath).Contains("VWG_AspResource");

      /// <summary>
      /// Gets a value that indicates whether a file exists in the virtual file system.
      /// </summary>
      /// <param name="strVirtualPath">The path to the virtual file.</param>
      /// <returns>
      /// true if the file exists in the virtual file system; otherwise, false.
      /// </returns>
      public override bool FileExists(string strVirtualPath) => this.IsAppResourcePath(strVirtualPath) || base.FileExists(strVirtualPath);

      /// <summary>Gets the file.</summary>
      /// <param name="strVirtualPath">The virtual path.</param>
      /// <returns></returns>
      public override VirtualFile GetFile(string strVirtualPath) => this.IsAppResourcePath(strVirtualPath) ? (VirtualFile) new AspControlBoxBase.ResourceFile(strVirtualPath) : base.GetFile(strVirtualPath);

      /// <summary>
      /// Creates a cache dependency based on the specified virtual paths.
      /// </summary>
      /// <param name="strVirtualPath">The path to the primary virtual resource.</param>
      /// <param name="objVirtualPathDependencies">An array of paths to other resources required by the primary virtual resource.</param>
      /// <param name="utcStart">The UTC time at which the virtual resources were read.</param>
      /// <returns>
      /// A <see cref="T:System.Web.Caching.CacheDependency" /> object for the specified virtual resources.
      /// </returns>
      public override CacheDependency GetCacheDependency(
        string strVirtualPath,
        IEnumerable objVirtualPathDependencies,
        DateTime objUtcStart)
      {
        return this.IsAppResourcePath(strVirtualPath) ? (CacheDependency) null : base.GetCacheDependency(strVirtualPath, objVirtualPathDependencies, objUtcStart);
      }

      /// <summary>Gets the type of the virtual path.</summary>
      /// <param name="strVirtualPath">The control virtual path.</param>
      internal static Type GetVirtualPathType(string strVirtualPath) => BuildManager.GetCompiledType(strVirtualPath);

      /// <summary>Gets the type of the compiled.</summary>
      /// <param name="strAspCode">The ASP code.</param>
      /// <returns></returns>
      public static Type GetCompiledType(string strAspCode)
      {
        Guid key = Guid.NewGuid();
        AspControlBoxBase.ResourceProvider.mobjTemporaryStoredCode[key] = strAspCode;
        try
        {
          return BuildManager.GetCompiledType(string.Format("~/{0}_{1}.ascx", (object) "VWG_AspResource", (object) key.ToString("N")));
        }
        finally
        {
          AspControlBoxBase.ResourceProvider.mobjTemporaryStoredCode.Remove(key);
        }
      }

      /// <summary>Gets the build code.</summary>
      /// <param name="objBuildGuid">The obj build GUID.</param>
      /// <returns></returns>
      internal static Stream GetBuildCode(Guid objBuildGuid)
      {
        MemoryStream buildCode = new MemoryStream();
        if (AspControlBoxBase.ResourceProvider.mobjTemporaryStoredCode.ContainsKey(objBuildGuid))
        {
          StreamWriter streamWriter = new StreamWriter((Stream) buildCode);
          streamWriter.Write(AspControlBoxBase.ResourceProvider.mobjTemporaryStoredCode[objBuildGuid]);
          streamWriter.Flush();
          buildCode.Position = 0L;
        }
        return (Stream) buildCode;
      }
    }

    protected internal enum VersionCompatibilityMode
    {
      Version6,
      Version72,
    }
  }
}
