using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using PrintingDrawing = System.Drawing.Printing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [SRDescription("DescriptionPrintDialog"),  DefaultProperty("Document")]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(PrintDialog), "PrintDialog_45.bmp")]
#else
    [ToolboxBitmap(typeof(PrintDialog), "PrintDialog.bmp")]
#endif
    [ToolboxItem(true)]
    [Serializable()]
    public sealed class PrintDialog : CommonDialog
    {
		#region Members

        private PrintDialogForm mobjPrintDialogForm = null;
        private PrintDocument mobjPrintDocument = null;
        private bool mblnPrintToFile = false;

		#endregion

		#region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PrintDialog"/> class.
        /// </summary>
        public PrintDialog()
        {
            this.Reset();
        }

		#endregion Constructors 

		#region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [allow current page].
        /// </summary>
        /// <value><c>true</c> if [allow current page]; otherwise, <c>false</c>.</value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AllowCurrentPage
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow print to file].
        /// </summary>
        /// <value><c>true</c> if [allow print to file]; otherwise, <c>false</c>.</value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AllowPrintToFile
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow selection].
        /// </summary>
        /// <value><c>true</c> if [allow selection]; otherwise, <c>false</c>.</value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AllowSelection
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allow some pages].
        /// </summary>
        /// <value><c>true</c> if [allow some pages]; otherwise, <c>false</c>.</value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AllowSomePages
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        /// <value>The document.</value>
        [DefaultValue((string)null), SRDescription("PDdocumentDescr"), SRCategory("CatData")]
        public PrintDocument Document
        {
            get
            {
                return this.mobjPrintDocument;
            }
            set
            {
                this.mobjPrintDocument = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [print to file].
        /// </summary>
        /// <value><c>true</c> if [print to file]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), SRDescription("PDprintToFileDescr"), SRCategory("CatBehavior")]
        public bool PrintToFile
        {
            get
            {
                return this.mblnPrintToFile;
            }
            set
            {
                this.mblnPrintToFile = value;
            }
        }
 
        /// <summary>
        /// Gets or sets a value indicating whether [show help].
        /// </summary>
        /// <value><c>true</c> if [show help]; otherwise, <c>false</c>.</value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowHelp
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show network].
        /// </summary>
        /// <value><c>true</c> if [show network]; otherwise, <c>false</c>.</value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowNetwork
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use EX dialog].
        /// </summary>
        /// <value><c>true</c> if [use EX dialog]; otherwise, <c>false</c>.</value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UseEXDialog
        {
            get
            {
                return false;
            }
            set
            {
            }
        }

		#endregion Properties 

		#region Methods

        /// <summary>
        /// Creates a dialog for instance for the current common dialog
        /// </summary>
        /// <returns></returns>
        protected override CommonDialog.CommonDialogForm CreateForm()
        {
            PrintDocument objPrintDocument = this.Document;
            if (objPrintDocument != null)
            {
                // Create a print dialog form - if needed.
                if (mobjPrintDialogForm == null)
                {
                    mobjPrintDialogForm = new PrintDialogForm(this);
                }

                // Create link parameters.
                LinkParameters objLinkParameters = new LinkParameters(LinkWindowStyle.Normal, new Size(50, 50));
                objLinkParameters.Target = "_blank";

                // Open link for print dialog form.
                Link.Open(new GatewayReference(mobjPrintDialogForm, "print"), objLinkParameters);
            }

            return null;
        }

        /// <summary>
        /// When overridden in a derived class, resets the properties of a common dialog box to their default values.
        /// </summary>
        public override void Reset()
        {
            this.mobjPrintDocument = null;
            this.mblnPrintToFile = false;
        }

        #endregion Methods 

        #region Classes

        #region SaveFileDialogForm Class

        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        protected sealed class PrintDialogForm : CommonDialogForm
        {
            #region C'Tor\D'Tor

            /// <summary>
            /// Initializes a new instance of the <see cref="SaveFileDialogForm"/> class.
            /// </summary>
            /// <param name="objCommonDialog"></param>
            public PrintDialogForm(CommonDialog objCommonDialog) : base(objCommonDialog)
            {
                this.RegisterSelf();
            }

            #endregion

            #region Methods

            /// <summary>
            /// Provides a way to handle gateway requests.
            /// </summary>
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
            protected override IGatewayHandler ProcessGatewayRequest(Gizmox.WebGUI.Hosting.HostContext objHostContext, string strAction)
            {
                // Get save file dialog.
                PrintDialog objPrintDialog = this.CommonDialogOwner as PrintDialog;
                if (objPrintDialog != null)
                {
                    // Get print document from dialog.
                    PrintDocument objPrintDocument = objPrintDialog.Document;
                    if (objPrintDocument != null)
                    {
                        // Get bitmaps list.
                        List<Bitmap> objBitmapsList = objPrintDocument.BitmapsList;
                        if (objBitmapsList != null)
                        {
                            // Validate bitmap list count.
                            if (objBitmapsList.Count > 0)
                            {
                                // Check action.
                                if (strAction == "print")
                                {
                                    // Process print request.
                                    ProcessPrintRequest(objHostContext, objPrintDocument, objBitmapsList);
                                }
                                else if (strAction.StartsWith("page"))
                                {
                                    // Process page request.
                                    ProcessPageRequest(objHostContext, strAction, objBitmapsList);
                                }
                            }
                        }
                    }

                    return null;
                }
                else
                {
                    return base.ProcessGatewayRequest(objHostContext, strAction);
                }
            }

            /// <summary>
            /// Processes the page request.
            /// </summary>
            /// <param name="objHostContext">The obj host context.</param>
            /// <param name="strAction">The STR action.</param>
            /// <param name="objBitmapsList">The obj bitmaps list.</param>
            private static void ProcessPageRequest(Gizmox.WebGUI.Hosting.HostContext objHostContext, string strAction, List<Bitmap> objBitmapsList)
            {
                int intPageNumber = -1;

                // try parse a page number out of action string.
                if (int.TryParse(strAction.Substring(4), out intPageNumber))
                {
                    // Validate page number.
                    if (intPageNumber < objBitmapsList.Count)
                    {
                        // Get proper bitmap out of list.
                        Bitmap objBitmap = objBitmapsList[intPageNumber];
                        if (objBitmap != null)
                        {
                            // Write content type header to response.
                            objHostContext.Response.ContentType = CommonUtils.GetMimeType(ImageFormat.Png);

                            // Create a new memory stream.
                            MemoryStream objMemoryStream = new MemoryStream();

                            // Save image to stream.
                            objBitmap.Save(objMemoryStream, ImageFormat.Png);

                            // Write stream from memory stream to response.
                            objMemoryStream.WriteTo(objHostContext.Response.OutputStream);
                        }
                    }
                }
            }

            /// <summary>
            /// Processes the print request.
            /// </summary>
            /// <param name="objHostContext">The obj host context.</param>
            /// <param name="objPrintDocument">The obj print document.</param>
            /// <param name="objBitmapsList">The obj bitmaps list.</param>
            private static void ProcessPrintRequest(Gizmox.WebGUI.Hosting.HostContext objHostContext, PrintDocument objPrintDocument, List<Bitmap> objBitmapsList)
            {
                // Write content type header to response.
                objHostContext.Response.ContentType = "text/html";

                // Eliminate page caching.
                objHostContext.Response.Expires = -1;

                // Create xml text writer 
                HtmlTextWriter objHtmlTextWriter = new HtmlTextWriter(new StreamWriter(objHostContext.Response.OutputStream, Encoding.UTF8));
                if (objHtmlTextWriter != null)
                {
                    // Write doc type and html header.
                    objHtmlTextWriter.WriteLine("<!DOCTYPE html>");
                    objHtmlTextWriter.WriteFullBeginTag("html");
                    objHtmlTextWriter.WriteFullBeginTag("head");
                    objHtmlTextWriter.WriteFullBeginTag("title");
                    objHtmlTextWriter.Write(objPrintDocument.DocumentName);
                    objHtmlTextWriter.WriteEndTag("title");
                    objHtmlTextWriter.WriteEndTag("head");

                    // Write body element.
                    objHtmlTextWriter.WriteBeginTag("body");
                    objHtmlTextWriter.WriteAttribute("onload", "window.print(); window.close();");

                    // Write table element.
                    objHtmlTextWriter.WriteFullBeginTag("table");

                    // Get url local path.
                    string strImageSource = objHostContext.Request.Url.LocalPath.TrimStart('/');

                    // Loop all bitmaps.
                    foreach (Bitmap objBitmap in objBitmapsList)
                    {

                        // Write row and cell elements.
                        objHtmlTextWriter.WriteFullBeginTag("tr");
                        objHtmlTextWriter.WriteFullBeginTag("td");

                        // Write image element.
                        objHtmlTextWriter.WriteBeginTag("img");
                        objHtmlTextWriter.WriteAttribute("src", strImageSource.Replace(".print.", string.Format(".page{0}.", objBitmapsList.IndexOf(objBitmap).ToString())));
                        objHtmlTextWriter.WriteEndTag("img");

                        objHtmlTextWriter.WriteEndTag("td");
                        objHtmlTextWriter.WriteEndTag("tr");
                    }

                    objHtmlTextWriter.WriteEndTag("table");

                    objHtmlTextWriter.WriteEndTag("body");
                    objHtmlTextWriter.WriteEndTag("html");

                    // Flush all writer's text.
                    objHtmlTextWriter.Flush();
                }
            }

            #endregion
        }

        #endregion

        #endregion
    }
}
