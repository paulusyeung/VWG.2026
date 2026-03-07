using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using WinForms = System.Windows.Forms;
using System.ComponentModel;


namespace Gizmox.WebGUI.Client.Forms
{

    /// <summary>
    /// 
    /// </summary>
    public class ClientHtmlBox : WinForms.WebBrowser
    {
        #region Fields

        private string mstrHtml = "";
        private string mstrTempDir = null;

        #endregion Fields 

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientHtmlBox"/> class.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">
        /// The <see cref="T:System.Windows.Forms.WebBrowser"/> control is hosted inside Internet Explorer.
        /// </exception>
        public ClientHtmlBox()
        {

        }

        #endregion Constructors 

        #region Properties

        /// <summary>
        /// This property is not supported by this control.
        /// </summary>
        /// <value></value>
        /// <returns>true in all cases.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        /// This property is being set.
        /// </exception>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool Enabled
        {
            get
            {
                return base.Enabled;
            }
            set
            {
            }
        }

        /// <summary>
        /// This property is not supported by this control.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// 	<see cref="F:System.String.Empty"/>.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        /// This property is being set.
        /// </exception>
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
            }
        }

        /// <summary>
        /// This property is not supported by this control.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The value of this property is not meaningful for this control.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        /// This property is being set.
        /// </exception>
        public override System.Windows.Forms.RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
            }
        }


        /// <summary>
        /// This property is not supported by this control.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// The value of this property is not meaningful for this control.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        /// This property is being set.
        /// </exception>
        public override System.Windows.Forms.Cursor Cursor
        {
            get
            {
                return base.Cursor;
            }
            set
            {
            }
        }

        /// <summary>
        /// This property is not supported by this control.
        /// </summary>
        /// <value></value>
        /// <returns>null.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        /// This property is being set.
        /// </exception>
        public override System.Drawing.Image BackgroundImage
        {
            get
            {
                return base.BackgroundImage;
            }
            set
            {
            }
        }

        /// <summary>
        /// This property is not supported by this control.
        /// </summary>
        /// <value></value>
        /// <returns>false in all cases.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        /// This property is being set.
        /// </exception>
        public override bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }
            set
            {
            }
        }

        /// <summary>
        /// This property is not supported by this control.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// An <see cref="T:System.Windows.Forms.ImageLayout"/>.
        /// </returns>
        /// <exception cref="T:System.NotSupportedException">
        /// This property is being set.
        /// </exception>
        public override System.Windows.Forms.ImageLayout BackgroundImageLayout
        {
            get
            {
                return base.BackgroundImageLayout;
            }
            set
            {
            }
        }

        /// <summary>
        /// Gets or sets the HTML.
        /// </summary>
        /// <value>The HTML.</value>
        public string Html
        {
            get
            {
                return mstrHtml;
            }
            set
            {
                if (mstrHtml != value)
                {
                    mstrHtml = value;

                    File.WriteAllText(TempFile, mstrHtml);

                    this.Url = new Uri(string.Format("file://{0}", this.TempFile));
                }
            }
        }

        /// <summary>
        /// Gets the temp directory.
        /// </summary>
        /// <value>The temp directory.</value>
        private string TempDirectory
        {
            get
            {
                if (mstrTempDir == null)
                {
                    mstrTempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                    Directory.CreateDirectory(mstrTempDir);
                }
                return mstrTempDir;
            }
       }

        /// <summary>
        /// Gets the temp file.
        /// </summary>
        /// <value>The temp file.</value>
        private string TempFile
        {
            get
            {
                return Path.Combine(this.TempDirectory, "Index.htm");
            }
        }

        #endregion Properties 

        #region Methods


       /// <summary>
       /// Releases unmanaged and - optionally - managed resources
       /// </summary>
       /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose managed resources
            }

            // Dispose unmanaged resources
            try
            {
                if (mstrTempDir!=null && Directory.Exists(mstrTempDir))
                {
                    Directory.Delete(mstrTempDir,true);
                    mstrTempDir = null;
                }
            }
            catch (Exception)
            {
            }
        
            base.Dispose(disposing);
        }


        #endregion Methods 
    }
}
