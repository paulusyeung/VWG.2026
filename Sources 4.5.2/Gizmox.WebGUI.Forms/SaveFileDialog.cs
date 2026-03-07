using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.IO;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// SaveFileDialog class.
    /// </summary>
    [SRDescription("DescriptionSaveFileDialog")]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(SaveFileDialog), "SaveFileDialog_45.bmp")]
#else
    [ToolboxBitmap(typeof(SaveFileDialog), "SaveFileDialog.bmp")]
#endif
    [ToolboxItem(true)]
    [Serializable()]
    public class SaveFileDialog : FileDialog
    {
        #region Members

        private SaveFileDialogForm mobjSaveFileDialogForm = null;

        #endregion

		#region Properties

        /// <summary>
        /// Gets or sets a value indicating whether [create prompt].
        /// </summary>
        /// <value><c>true</c> if [create prompt]; otherwise, <c>false</c>.</value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CreatePrompt
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
        /// Gets or sets a value indicating whether [overwrite prompt].
        /// </summary>
        /// <value><c>true</c> if [overwrite prompt]; otherwise, <c>false</c>.</value>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool OverwritePrompt
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

		#endregion Properties 

		#region Methods

        /// <summary>
        /// Opens a file.
        /// </summary>
        /// <returns></returns>
        public Stream OpenFile()
        {
            if (this.File == null)
            {
                throw new ArgumentNullException();
            }

            return this.File.InputStream;
        }

        /// <summary>
        /// Creates a dialog for instance for the current common dialog
        /// </summary>
        /// <returns></returns>
        protected override CommonDialog.CommonDialogForm CreateForm()
        {
            FileHandle objFileHandle = this.File;
            if (objFileHandle != null)
            {
                if (mobjSaveFileDialogForm == null)
                {
                    mobjSaveFileDialogForm = new SaveFileDialogForm(this);
                }

                Link.Download(new GatewayResourceHandle(mobjSaveFileDialogForm, "download"), objFileHandle.FileName);
            }

            return null;
        }

        /// <summary>
        /// Resets all properties to their default values.
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            base.SetOption(2, true);
        }

		#endregion Methods 

        #region Classes

        #region SaveFileDialogForm Class

        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        protected sealed class SaveFileDialogForm : CommonDialogForm
        {
            #region C'Tor\D'Tor

            /// <summary>
            /// Initializes a new instance of the <see cref="SaveFileDialogForm"/> class.
            /// </summary>
            /// <param name="objCommonDialog"></param>
            public SaveFileDialogForm(CommonDialog objCommonDialog) : base(objCommonDialog)
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
                if (strAction == "download")
                {
                    // Get save file dialog.
                    SaveFileDialog objSaveFileDialog = this.CommonDialogOwner as SaveFileDialog;
                    if (objSaveFileDialog != null)
                    {
                        // Check handled file.
                        FileHandle objFileHandle = objSaveFileDialog.File;
                        if (objFileHandle != null)
                        {
                            // Write content type header.
                            objHostContext.Response.ContentType = objFileHandle.ContentType;

                            // Write file.
                            objHostContext.Response.WriteFile(objFileHandle.FileName);
                        }
                    }

                    return null;
                }
                else
                {
                    return base.ProcessGatewayRequest(objHostContext, strAction);
                }
            } 

            #endregion
        }

        #endregion 

        #endregion
    }
}
