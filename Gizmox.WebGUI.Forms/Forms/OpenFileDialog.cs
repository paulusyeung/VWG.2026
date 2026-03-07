// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.OpenFileDialog
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Hosting;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Web;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Prompts the user to open a file. This class cannot be inherited.</summary>
  /// <filterpriority>2</filterpriority>
  [SRDescription("DescriptionOpenFileDialog")]
  [ToolboxBitmap(typeof (OpenFileDialog), "OpenFileDialog_45.bmp")]
  [ToolboxItem(true)]
  [Gizmox.WebGUI.Forms.Skins.Skin(typeof (OpenFileDialogSkin))]
  [Serializable]
  public sealed class OpenFileDialog : FileDialog
  {
    /// <summary>Opens the file selected by the user, with read-only permission. The file is specified by the <see cref="P:Gizmox.WebGUI.Forms.FileDialog.FileName"></see> property. </summary>
    /// <returns>A <see cref="T:System.IO.Stream"></see> that specifies the read-only file selected by the user.</returns>
    /// <exception cref="T:System.ArgumentNullException">The file name is null. </exception>
    /// <filterpriority>1</filterpriority>
    public Stream OpenFile() => this.File != null ? this.File.InputStream : throw new ArgumentNullException();

    /// <summary>Resets all properties to their default values. </summary>
    public override void Reset()
    {
      base.Reset();
      this.SetOption(4096, true);
    }

    /// <summary>Gets or sets a value indicating whether the dialog box displays a warning if the user specifies a file name that does not exist. </summary>
    /// <returns>true if the dialog box displays a warning when the user specifies a file name that does not exist; otherwise, false. The default value is true.</returns>
    [DefaultValue(true)]
    [SRDescription("OFDcheckFileExistsDescr")]
    public override bool CheckFileExists
    {
      get => base.CheckFileExists;
      set => base.CheckFileExists = value;
    }

    /// <summary>Gets or sets a value indicating whether the dialog box allows multiple files to be selected. </summary>
    /// <returns>true if the dialog box allows multiple files to be selected together or concurrently; otherwise, false. The default value is false.</returns>
    [DefaultValue(false)]
    [SRCategory("CatBehavior")]
    [SRDescription("OFDmultiSelectDescr")]
    public bool Multiselect
    {
      get => this.GetOption(512);
      set => this.SetOption(512, value);
    }

    /// <summary>Gets or sets a value indicating whether the read-only check box is selected. </summary>
    /// <returns>true if the read-only check box is selected; otherwise, false. The default value is false.</returns>
    [SRCategory("CatBehavior")]
    [SRDescription("OFDreadOnlyCheckedDescr")]
    [DefaultValue(false)]
    public bool ReadOnlyChecked
    {
      get => this.GetOption(1);
      set => this.SetOption(1, value);
    }

    /// <summary>Gets or sets a value indicating whether the dialog box contains a read-only check box. </summary>
    /// <returns>true if the dialog box contains a read-only check box; otherwise, false. The default value is false.</returns>
    [SRDescription("OFDshowReadOnlyDescr")]
    [SRCategory("CatBehavior")]
    [DefaultValue(false)]
    public bool ShowReadOnly
    {
      get => !this.GetOption(4);
      set => this.SetOption(4, !value);
    }

    /// <summary>Create the open file dialog form</summary>
    /// <returns></returns>
    protected override CommonDialog.CommonDialogForm CreateForm() => (CommonDialog.CommonDialogForm) new OpenFileDialog.OpenFileDialogForm((CommonDialog) this);

    /// <summary>Summary description for OpenFileDialog.</summary>
    [Serializable]
    protected sealed class OpenFileDialogForm : CommonDialog.CommonDialogForm
    {
      /// <summary>
      /// Provides a property reference to HtmlBoxHost property.
      /// </summary>
      private static SerializableProperty HtmlBoxHostProperty = SerializableProperty.Register("HtmlBoxHost", typeof (CommonDialog.HtmlBoxHost), typeof (OpenFileDialog.OpenFileDialogForm));
      /// <summary>
      /// Provides a property reference to IsFirstFile property.
      /// </summary>
      private static SerializableProperty IsFirstFileProperty = SerializableProperty.Register("IsFirstFile", typeof (bool), typeof (OpenFileDialog.OpenFileDialogForm), new SerializablePropertyMetadata((object) true));
      private const string mstrDefaultFilter = "All files(*.*)|*.*";
      private Control mobjProgressPanel;
      private CommonDialog.HtmlBoxHost mobjHtmlBoxHost;

      /// <summary>
      /// Creates a new <see cref="T:Gizmox.WebGUI.Forms.OpenFileDialog" /> instance.
      /// </summary>
      public OpenFileDialogForm(CommonDialog objCommonDialog)
        : base(objCommonDialog)
      {
        this.InitializeComponent();
      }

      private void InitializeComponent()
      {
        this.mobjHtmlBoxHost = new CommonDialog.HtmlBoxHost();
        this.mobjProgressPanel = (Control) new OpenFileDialogProgressPanel((IRegisteredComponent) this);
        this.SuspendLayout();
        this.mobjProgressPanel.Size = new Size(0, 0);
        this.mobjHtmlBoxHost.Dock = DockStyle.Fill;
        this.SetValue<CommonDialog.HtmlBoxHost>(OpenFileDialog.OpenFileDialogForm.HtmlBoxHostProperty, this.mobjHtmlBoxHost);
        this.Controls.Add((Control) this.mobjHtmlBoxHost);
        this.Controls.Add(this.mobjProgressPanel);
        this.ClientSize = new Size(350, 215);
        this.ResumeLayout(false);
      }

      protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
      {
        base.PreRenderControl(objContext, lngRequestID);
        this.mobjProgressPanel.ClientId = "VWGOpenFileDialogPanel" + (object) this.ID;
      }

      /// <summary>
      /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
      /// </summary>
      /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
      protected override void OnLoad(EventArgs e)
      {
        base.OnLoad(e);
        CommonDialog.HtmlBoxHost htmlBoxHost = this.GetValue<CommonDialog.HtmlBoxHost>(OpenFileDialog.OpenFileDialogForm.HtmlBoxHostProperty);
        htmlBoxHost.Url = string.Format("Resources.Gizmox.WebGUI.Forms.Skins.OpenFileDialogSkin.OpenFileDialog.htm{0}", (object) this.DynamicExtension);
        this.Text = this.Title;
        htmlBoxHost.SetProperty("UseFlash", this.UseFlash ? "1" : "0");
        htmlBoxHost.SetProperty("MaxFileSize", this.MaxFileSize.ToString());
        htmlBoxHost.SetProperty("Filter", this.Filter);
        htmlBoxHost.SetProperty("SessionId", this.SessionId);
        htmlBoxHost.SetProperty("Multiselect", this.Multiselect ? "1" : "0");
        htmlBoxHost.SetProperty("GatewayId", this.ID.ToString());
        if (!this.UseFlash)
          return;
        if (CommonUtils.IsNullOrEmpty(this.Filter))
          return;
        string[] strArray = this.Filter.Split('|');
        htmlBoxHost.SetProperty("AllowedFileTypesDescription", strArray[0]);
        htmlBoxHost.SetProperty("AllowedFileTypes", strArray[1]);
      }

      /// <summary>Gets a flag indiacating if to use flash uploading</summary>
      private string DynamicExtension => this.Context.Config.DynamicExtension;

      /// <summary>Gets a flag indiacating if to use flash uploading</summary>
      private bool UseFlash => this.Context.Config.IsFeatureEnabled("UseFlashForUpload", true);

      /// <summary>Gets the dialog title</summary>
      private string Title => this.OpenFileDialogOwner.Title;

      /// <summary>Renders the forms attribute</summary>
      /// <param name="objContext"></param>
      /// <param name="objWriter"></param>
      protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
      {
        base.RenderAttributes(objContext, objWriter);
        objWriter.WriteAttributeString("IsOpenFileDialog", "1");
      }

      /// <summary>Gets the dialog filter</summary>
      private string Filter => this.OpenFileDialogOwner.Filter;

      /// <summary>Gets a flag indicating if multiselet is valid</summary>
      private bool Multiselect => this.OpenFileDialogOwner.Multiselect;

      /// <summary>Gets the current session id</summary>
      private string SessionId => this.Context.HostContext.Session.SessionID;

      /// <summary>Gets the max file size</summary>
      private int MaxFileSize => this.OpenFileDialogOwner.MaxFileSize;

      /// <summary>Gest the file handle</summary>
      private FileHandle File => this.OpenFileDialogOwner.File;

      /// <summary>Gets the file collection</summary>
      private FileHandleCollection Files => this.OpenFileDialogOwner.Files;

      /// <summary>Returns the open file dialog owner</summary>
      private OpenFileDialog OpenFileDialogOwner => (OpenFileDialog) this.CommonDialogOwner;

      /// <summary>Provides a way to handle gateway requests.</summary>
      /// <param name="objHostContext">The gateway request HOST context.</param>
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
        HostContext objHostContext,
        string strAction)
      {
        if (this.GetValue<bool>(OpenFileDialog.OpenFileDialogForm.IsFirstFileProperty, true))
        {
          this.Files.Clear();
          this.DialogResult = DialogResult.OK;
          this.SetValue<bool>(OpenFileDialog.OpenFileDialogForm.IsFirstFileProperty, false);
        }
        try
        {
          for (int index = 0; index < objHostContext.Request.Files.Count; ++index)
          {
            HttpPostedFileHandle file = HttpPostedFileHandle.Create(objHostContext.Request.Files[index]);
            if (file.ContentLength > 0L && !string.IsNullOrEmpty(file.FileName))
              this.Files.Add(file.FileName, (FileHandle) file);
          }
          if (strAction != "UploadFlash")
          {
            string str = "Upload_CloseWindow";
            if (this.Context != null && this.Context is IContextMethodInvoker)
              str = ((IContextMethodInvoker) this.Context).GetMethodName((ISkinable) this.CommonDialogOwner, "Upload_CloseWindow");
            objHostContext.Response.Write(string.Format("<HTML><SCRIPT language='javascript'>parent.{0}();</SCRIPT></HTML>", (object) str));
          }
          else
            objHostContext.Response.Write("<HTML></HTML>");
        }
        catch (Exception ex)
        {
          string str = "Upload_DisplayError";
          if (this.Context != null && this.Context is IContextMethodInvoker)
            str = ((IContextMethodInvoker) this.Context).GetMethodName((ISkinable) this.CommonDialogOwner, "Upload_DisplayError");
          objHostContext.Response.Write(string.Format("<HTML><BODY onload=\"parent.{0}(document.body.innerText);\">" + HttpUtility.HtmlEncode(ex.Message) + "</BODY></HTML>", (object) str));
        }
        return (IGatewayHandler) null;
      }
    }
  }
}
