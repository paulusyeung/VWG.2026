// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.PrintDialog
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web.UI;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>
  /// 
  /// </summary>
  [SRDescription("DescriptionPrintDialog")]
  [DefaultProperty("Document")]
  [ToolboxBitmap(typeof (PrintDialog), "PrintDialog_45.bmp")]
  [ToolboxItem(true)]
  [Serializable]
  public sealed class PrintDialog : CommonDialog
  {
    private PrintDialog.PrintDialogForm mobjPrintDialogForm;
    private PrintDocument mobjPrintDocument;
    private bool mblnPrintToFile;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PrintDialog" /> class.
    /// </summary>
    public PrintDialog() => this.Reset();

    /// <summary>
    /// Gets or sets a value indicating whether [allow current page].
    /// </summary>
    /// <value><c>true</c> if [allow current page]; otherwise, <c>false</c>.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool AllowCurrentPage
    {
      get => false;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [allow print to file].
    /// </summary>
    /// <value><c>true</c> if [allow print to file]; otherwise, <c>false</c>.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool AllowPrintToFile
    {
      get => true;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [allow selection].
    /// </summary>
    /// <value><c>true</c> if [allow selection]; otherwise, <c>false</c>.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool AllowSelection
    {
      get => false;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [allow some pages].
    /// </summary>
    /// <value><c>true</c> if [allow some pages]; otherwise, <c>false</c>.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool AllowSomePages
    {
      get => false;
      set
      {
      }
    }

    /// <summary>Gets or sets the document.</summary>
    /// <value>The document.</value>
    [DefaultValue(null)]
    [SRDescription("PDdocumentDescr")]
    [SRCategory("CatData")]
    public PrintDocument Document
    {
      get => this.mobjPrintDocument;
      set => this.mobjPrintDocument = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether [print to file].
    /// </summary>
    /// <value><c>true</c> if [print to file]; otherwise, <c>false</c>.</value>
    [DefaultValue(false)]
    [SRDescription("PDprintToFileDescr")]
    [SRCategory("CatBehavior")]
    public bool PrintToFile
    {
      get => this.mblnPrintToFile;
      set => this.mblnPrintToFile = value;
    }

    /// <summary>Gets or sets a value indicating whether [show help].</summary>
    /// <value><c>true</c> if [show help]; otherwise, <c>false</c>.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ShowHelp
    {
      get => false;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [show network].
    /// </summary>
    /// <value><c>true</c> if [show network]; otherwise, <c>false</c>.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool ShowNetwork
    {
      get => true;
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets a value indicating whether [use EX dialog].
    /// </summary>
    /// <value><c>true</c> if [use EX dialog]; otherwise, <c>false</c>.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool UseEXDialog
    {
      get => false;
      set
      {
      }
    }

    /// <summary>
    /// Creates a dialog for instance for the current common dialog
    /// </summary>
    /// <returns></returns>
    protected override CommonDialog.CommonDialogForm CreateForm()
    {
      if (this.Document != null)
      {
        if (this.mobjPrintDialogForm == null)
          this.mobjPrintDialogForm = new PrintDialog.PrintDialogForm((CommonDialog) this);
        Link.Open(new GatewayReference((IRegisteredComponent) this.mobjPrintDialogForm, "print"), new LinkParameters(LinkWindowStyle.Normal, new Size(50, 50))
        {
          Target = "_blank"
        });
      }
      return (CommonDialog.CommonDialogForm) null;
    }

    /// <summary>
    /// When overridden in a derived class, resets the properties of a common dialog box to their default values.
    /// </summary>
    public override void Reset()
    {
      this.mobjPrintDocument = (PrintDocument) null;
      this.mblnPrintToFile = false;
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    protected sealed class PrintDialogForm : CommonDialog.CommonDialogForm
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="!:SaveFileDialogForm" /> class.
      /// </summary>
      /// <param name="objCommonDialog"></param>
      public PrintDialogForm(CommonDialog objCommonDialog)
        : base(objCommonDialog)
      {
        this.RegisterSelf();
      }

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
        if (!(this.CommonDialogOwner is PrintDialog commonDialogOwner))
          return base.ProcessGatewayRequest(objHostContext, strAction);
        PrintDocument document = commonDialogOwner.Document;
        if (document != null)
        {
          List<Bitmap> bitmapsList = document.BitmapsList;
          if (bitmapsList != null && bitmapsList.Count > 0)
          {
            if (strAction == "print")
              PrintDialog.PrintDialogForm.ProcessPrintRequest(objHostContext, document, bitmapsList);
            else if (strAction.StartsWith("page"))
              PrintDialog.PrintDialogForm.ProcessPageRequest(objHostContext, strAction, bitmapsList);
          }
        }
        return (IGatewayHandler) null;
      }

      /// <summary>Processes the page request.</summary>
      /// <param name="objHostContext">The obj host context.</param>
      /// <param name="strAction">The STR action.</param>
      /// <param name="objBitmapsList">The obj bitmaps list.</param>
      private static void ProcessPageRequest(
        HostContext objHostContext,
        string strAction,
        List<Bitmap> objBitmapsList)
      {
        int result = -1;
        if (!int.TryParse(strAction.Substring(4), out result) || result >= objBitmapsList.Count)
          return;
        Bitmap objBitmaps = objBitmapsList[result];
        if (objBitmaps == null)
          return;
        objHostContext.Response.ContentType = CommonUtils.GetMimeType(ImageFormat.Png);
        MemoryStream memoryStream = new MemoryStream();
        objBitmaps.Save((Stream) memoryStream, ImageFormat.Png);
        memoryStream.WriteTo(objHostContext.Response.OutputStream);
      }

      /// <summary>Processes the print request.</summary>
      /// <param name="objHostContext">The obj host context.</param>
      /// <param name="objPrintDocument">The obj print document.</param>
      /// <param name="objBitmapsList">The obj bitmaps list.</param>
      private static void ProcessPrintRequest(
        HostContext objHostContext,
        PrintDocument objPrintDocument,
        List<Bitmap> objBitmapsList)
      {
        objHostContext.Response.ContentType = "text/html";
        objHostContext.Response.Expires = -1;
        HtmlTextWriter htmlTextWriter = new HtmlTextWriter((TextWriter) new StreamWriter(objHostContext.Response.OutputStream, Encoding.UTF8));
        if (htmlTextWriter == null)
          return;
        htmlTextWriter.WriteLine("<!DOCTYPE html>");
        htmlTextWriter.WriteFullBeginTag("html");
        htmlTextWriter.WriteFullBeginTag("head");
        htmlTextWriter.WriteFullBeginTag("title");
        htmlTextWriter.Write(objPrintDocument.DocumentName);
        htmlTextWriter.WriteEndTag("title");
        htmlTextWriter.WriteEndTag("head");
        htmlTextWriter.WriteBeginTag("body");
        htmlTextWriter.WriteAttribute("onload", "window.print(); window.close();");
        htmlTextWriter.WriteFullBeginTag("table");
        string str = objHostContext.Request.Url.LocalPath.TrimStart('/');
        foreach (Bitmap objBitmaps in objBitmapsList)
        {
          htmlTextWriter.WriteFullBeginTag("tr");
          htmlTextWriter.WriteFullBeginTag("td");
          htmlTextWriter.WriteBeginTag("img");
          htmlTextWriter.WriteAttribute("src", str.Replace(".print.", string.Format(".page{0}.", (object) objBitmapsList.IndexOf(objBitmaps).ToString())));
          htmlTextWriter.WriteEndTag("img");
          htmlTextWriter.WriteEndTag("td");
          htmlTextWriter.WriteEndTag("tr");
        }
        htmlTextWriter.WriteEndTag("table");
        htmlTextWriter.WriteEndTag("body");
        htmlTextWriter.WriteEndTag("html");
        htmlTextWriter.Flush();
      }
    }
  }
}
