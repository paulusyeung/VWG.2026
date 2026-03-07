#region Using

using System;
using System.Web;
using System.Xml;
using System.Drawing;
using System.ComponentModel;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Resources;
using System.IO;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Forms.Skins;

#endregion

namespace Gizmox.WebGUI.Forms
{
    /// <summary>Prompts the user to open a file. This class cannot be inherited.</summary>
    /// <filterpriority>2</filterpriority>
    [SRDescription("DescriptionOpenFileDialog")]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(OpenFileDialog), "OpenFileDialog_45.bmp")]
#else
    [ToolboxBitmap(typeof(OpenFileDialog), "OpenFileDialog.bmp")]
#endif
    [ToolboxItem(true), Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.OpenFileDialogSkin))]
    [Serializable()]
    public sealed class OpenFileDialog : FileDialog
    {

        #region Classes
        
        /// <summary>
        /// Summary description for OpenFileDialog.
        /// </summary>
        [Serializable()]
        protected sealed class OpenFileDialogForm : CommonDialogForm
        {
            /// <summary>
            /// Provides a property reference to HtmlBoxHost property.
            /// </summary>
            private static SerializableProperty HtmlBoxHostProperty = SerializableProperty.Register("HtmlBoxHost", typeof(HtmlBoxHost), typeof(OpenFileDialogForm));

            /// <summary>
            /// Provides a property reference to IsFirstFile property.
            /// </summary>
            private static SerializableProperty IsFirstFileProperty = SerializableProperty.Register("IsFirstFile", typeof(bool), typeof(OpenFileDialogForm), new SerializablePropertyMetadata(true));
 
            private const string mstrDefaultFilter = "All files(*.*)|*.*";

            #region C'Tor\D'Tor

            /// <summary>
            /// Creates a new <see cref="OpenFileDialog"/> instance.
            /// </summary>
            public OpenFileDialogForm(CommonDialog objCommonDialog)
                : base(objCommonDialog)
            {
                InitializeComponent();
            }

            #endregion

            #region Methods

            #region Initialize Component

            private void InitializeComponent()
            {
                mobjHtmlBoxHost = new HtmlBoxHost();
                mobjProgressPanel = new OpenFileDialogProgressPanel(this);
                this.SuspendLayout();
                //
                // mobjProgressPanel
                //
                mobjProgressPanel.Size = new System.Drawing.Size(0, 0);
                //
                // mobjHtmlBoxHost
                //
                mobjHtmlBoxHost.Dock = DockStyle.Fill;
                //
                // this
                //
                this.SetValue<HtmlBoxHost>(OpenFileDialogForm.HtmlBoxHostProperty, mobjHtmlBoxHost);
                this.Controls.Add(mobjHtmlBoxHost);
                this.Controls.Add(mobjProgressPanel);
                this.ClientSize = new Size(350, 215);
                this.ResumeLayout(false);
            }

            private Control mobjProgressPanel;
            private HtmlBoxHost mobjHtmlBoxHost;

            protected internal override void PreRenderControl(IContext objContext, long lngRequestID)
            {
                base.PreRenderControl(objContext, lngRequestID);
                mobjProgressPanel.ClientId = "VWGOpenFileDialogPanel" + this.ID;
            }

            /// <summary>
            /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
            /// </summary>
            /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                HtmlBoxHost objHtmlBoxHost = this.GetValue<HtmlBoxHost>(OpenFileDialogForm.HtmlBoxHostProperty);

                objHtmlBoxHost.Url = string.Format("Resources.Gizmox.WebGUI.Forms.Skins.OpenFileDialogSkin.OpenFileDialog.htm{0}", this.DynamicExtension);

                // Get the dialog's title from this form's owner
                this.Text = this.Title;

                objHtmlBoxHost.SetProperty("UseFlash", this.UseFlash ? "1" : "0");
                objHtmlBoxHost.SetProperty("MaxFileSize", this.MaxFileSize.ToString());
                objHtmlBoxHost.SetProperty("Filter", this.Filter);
                objHtmlBoxHost.SetProperty("SessionId", this.SessionId);
                objHtmlBoxHost.SetProperty("Multiselect", this.Multiselect ? "1" : "0");
                objHtmlBoxHost.SetProperty("GatewayId", this.ID.ToString());
                if (this.UseFlash && !CommonUtils.IsNullOrEmpty(this.Filter))
                {
                    string[] arrFilter = this.Filter.Split('|');
                    objHtmlBoxHost.SetProperty("AllowedFileTypesDescription", arrFilter[0]);
                    objHtmlBoxHost.SetProperty("AllowedFileTypes", arrFilter[1]);
                }
            }
            #endregion

            #endregion

            #region Properties


            /// <summary>
            /// Gets a flag indiacating if to use flash uploading
            /// </summary>
            private string DynamicExtension
            {
                get
                {
                    return this.Context.Config.DynamicExtension;
                }
            }

            /// <summary>
            /// Gets a flag indiacating if to use flash uploading
            /// </summary>
            private bool UseFlash
            {
                get
                {
                    return this.Context.Config.IsFeatureEnabled("UseFlashForUpload", true);
                }
            }

            /// <summary>
            /// Gets the dialog title
            /// </summary>
            private string Title
            {
                get
                {
                    return this.OpenFileDialogOwner.Title;
                }
            }

            /// <summary>
            /// Renders the forms attribute
            /// </summary>
            /// <param name="objContext"></param>
            /// <param name="objWriter"></param>
            protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
            {
                base.RenderAttributes(objContext, objWriter);

                objWriter.WriteAttributeString("IsOpenFileDialog", "1");
            }
            /// <summary>
            /// Gets the dialog filter
            /// </summary>
            private string Filter
            {
                get
                {
                    return this.OpenFileDialogOwner.Filter;
                }
            }

            /// <summary>
            /// Gets a flag indicating if multiselet is valid
            /// </summary>
            private bool Multiselect
            {
                get
                {
                    return this.OpenFileDialogOwner.Multiselect;
                }
            }

            /// <summary>
            /// Gets the current session id
            /// </summary>
            private string SessionId
            {
                get
                {
                    return this.Context.HostContext.Session.SessionID;
                }
            }

            /// <summary>
            /// Gets the max file size
            /// </summary>
            private int MaxFileSize
            {
                get
                {
                    return this.OpenFileDialogOwner.MaxFileSize;
                }
            }

            /// <summary>
            /// Gest the file handle
            /// </summary>
            private FileHandle File
            {
                get
                {
                    return this.OpenFileDialogOwner.File;
                }
            }

            /// <summary>
            /// Gets the file collection
            /// </summary>
            private FileHandleCollection Files
            {
                get
                {
                    return this.OpenFileDialogOwner.Files;
                }
            }

            /// <summary>
            /// Returns the open file dialog owner
            /// </summary>
            private OpenFileDialog OpenFileDialogOwner
            {
                get
                {
                    return (OpenFileDialog)this.CommonDialogOwner;
                }
            }

            #endregion

            #region IGatewayControl Members

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
            protected override IGatewayHandler ProcessGatewayRequest(HostContext objHostContext, string strAction)
            {
                // If is first file upload
                if (this.GetValue<bool>(OpenFileDialogForm.IsFirstFileProperty, true))
                {
                    // Clear the files collection on starting upload
                    this.Files.Clear();

                    // Set dialog result to OK 
                    this.DialogResult = DialogResult.OK;

                    // Mark 
                    this.SetValue<bool>(OpenFileDialogForm.IsFirstFileProperty, false);
                }


                try
                {
                    // Load all uploaded files
                    for (int index = 0; index < objHostContext.Request.Files.Count; index++)
                    {
                        // Create a posted file handle
                        HttpPostedFileHandle fileHandle = HttpPostedFileHandle.Create(objHostContext.Request.Files[index]);

                        if (fileHandle.ContentLength > 0 && !string.IsNullOrEmpty(fileHandle.FileName))
                        {
                            // Add posted file handle to file list
                            this.Files.Add(fileHandle.FileName, fileHandle);
                        }
                    }

                    // If is not flash uploading
                    if (strAction != "UploadFlash")
                    {
                        // Define a close window method name.
                        string strCloseWindowMethodName = "Upload_CloseWindow";
                        if (this.Context != null && this.Context is IContextMethodInvoker)
                        {
                            // Get compiled method name.
                            strCloseWindowMethodName = ((IContextMethodInvoker)this.Context).GetMethodName(this.CommonDialogOwner, "Upload_CloseWindow");
                        }

                        // Close the parent window
                        objHostContext.Response.Write(string.Format("<HTML><SCRIPT language='javascript'>parent.{0}();</SCRIPT></HTML>", strCloseWindowMethodName));
                    }
                    else
                    {
                        // return a valid respose
                        objHostContext.Response.Write("<HTML></HTML>");
                    }
                }
                catch (Exception objException)
                {
                    // Define a display error method name.
                    string strDisplayErrorMethodName = "Upload_DisplayError";
                    if (this.Context != null && this.Context is IContextMethodInvoker)
                    {
                        // Get compiled method name.
                        strDisplayErrorMethodName = ((IContextMethodInvoker)this.Context).GetMethodName(this.CommonDialogOwner, "Upload_DisplayError");
                    }

                    // Return a display error message
                    objHostContext.Response.Write(string.Format("<HTML><BODY onload=\"parent.{0}(document.body.innerText);\">" + System.Web.HttpUtility.HtmlEncode(objException.Message) + "</BODY></HTML>", strDisplayErrorMethodName));

                }

                return null;
            }

            #endregion
        } 

        #endregion

        #region C'Tor
        
        /// <summary>Initializes an instance of the <see cref="T:Gizmox.WebGUI.Forms.OpenFileDialog"></see> class.</summary>
        public OpenFileDialog()
        {
        }
        
        #endregion

        #region Methods

        /// <summary>Opens the file selected by the user, with read-only permission. The file is specified by the <see cref="P:Gizmox.WebGUI.Forms.FileDialog.FileName"></see> property. </summary>
        /// <returns>A <see cref="T:System.IO.Stream"></see> that specifies the read-only file selected by the user.</returns>
        /// <exception cref="T:System.ArgumentNullException">The file name is null. </exception>
        /// <filterpriority>1</filterpriority>
        public Stream OpenFile()
        {
            if (this.File == null)
            {
                throw new ArgumentNullException();
            }
            return this.File.InputStream;
        }

        /// <summary>Resets all properties to their default values. </summary>
        public override void Reset()
        {
            base.Reset();
            base.SetOption(0x1000, true);
        } 

        #endregion


        /// <summary>Gets or sets a value indicating whether the dialog box displays a warning if the user specifies a file name that does not exist. </summary>
        /// <returns>true if the dialog box displays a warning when the user specifies a file name that does not exist; otherwise, false. The default value is true.</returns>
        [DefaultValue(true), SRDescription("OFDcheckFileExistsDescr")]
        public override bool CheckFileExists
        {
            get
            {
                return base.CheckFileExists;
            }
            set
            {
                base.CheckFileExists = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether the dialog box allows multiple files to be selected. </summary>
        /// <returns>true if the dialog box allows multiple files to be selected together or concurrently; otherwise, false. The default value is false.</returns>
        [DefaultValue(false), SRCategory("CatBehavior"), SRDescription("OFDmultiSelectDescr")]
        public bool Multiselect
        {
            get
            {
                return base.GetOption(0x200);
            }
            set
            {
                base.SetOption(0x200, value);
            }
        }

        /// <summary>Gets or sets a value indicating whether the read-only check box is selected. </summary>
        /// <returns>true if the read-only check box is selected; otherwise, false. The default value is false.</returns>
        [SRCategory("CatBehavior"), SRDescription("OFDreadOnlyCheckedDescr"), DefaultValue(false)]
        public bool ReadOnlyChecked
        {
            get
            {
                return base.GetOption(1);
            }
            set
            {
                base.SetOption(1, value);
            }
        }

        /// <summary>Gets or sets a value indicating whether the dialog box contains a read-only check box. </summary>
        /// <returns>true if the dialog box contains a read-only check box; otherwise, false. The default value is false.</returns>
        [SRDescription("OFDshowReadOnlyDescr"), SRCategory("CatBehavior"), DefaultValue(false)]
        public bool ShowReadOnly
        {
            get
            {
                return !base.GetOption(4);
            }
            set
            {
                base.SetOption(4, !value);
            }
        }

        /// <summary>
        /// Create the open file dialog form
        /// </summary>
        /// <returns></returns>
        protected override CommonDialogForm CreateForm()
        {
            return new OpenFileDialogForm(this);
        }

    }




}
