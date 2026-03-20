using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using Gizmox.WebGUI.Forms;
using System.Text;
using Gizmox.WebGUI.Common.Resources;
using System.Collections.Specialized;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Hosting;
using System.IO;

namespace Gizmox.WebGUI.Forms.Catalog.Categories.Behaviors
{
	/// <summary>
	/// Summary description for UploadBehavior.
	/// </summary>

    [Serializable()]
    public class UploadBehavior : UserControl
	{
		private Gizmox.WebGUI.Forms.Button mobjButtonUpload;
        private Gizmox.WebGUI.Forms.Panel mobjFilesPanel;



		/// <summary> 
		/// Required designer variable.
		/// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null;

		public UploadBehavior()
		{
			// This call is required by the WebGUI Form Designer.
			InitializeComponent();


		}

		


		#region Component Designer generated code
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}

				
			}

			base.Dispose( disposing );
		}


		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mobjButtonUpload = new Gizmox.WebGUI.Forms.Button();
            this.mobjFilesPanel = new Gizmox.WebGUI.Forms.Panel();
			this.SuspendLayout();
			// 
			// mobjButtonUpload
			// 
			this.mobjButtonUpload.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.mobjButtonUpload.ClientSize = new System.Drawing.Size(112, 23);
			this.mobjButtonUpload.Location = new System.Drawing.Point(8, 16);
			this.mobjButtonUpload.Name = "mobjButtonUpload";
			this.mobjButtonUpload.Size = new System.Drawing.Size(112, 23);
			this.mobjButtonUpload.TabIndex = 0;
			this.mobjButtonUpload.Text = "Upload";
			this.mobjButtonUpload.Click += new System.EventHandler(this.mobjButtonUpload_Click);
			// 
			// mobjLabelFile
			// 
			this.mobjFilesPanel.BackgroundImageLayout = Gizmox.WebGUI.Forms.ImageLayout.Tile;
			this.mobjFilesPanel.Location = new System.Drawing.Point(8, 48);
			this.mobjFilesPanel.Name = "mobjLabelFile";
            this.mobjFilesPanel.Size = new System.Drawing.Size(544, 544);
			this.mobjFilesPanel.TabIndex = 1;
            this.mobjFilesPanel.AutoScroll = true;
			// 
			// UploadBehavior
			// 
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(632, 560);
			this.Controls.Add(this.mobjFilesPanel);
			this.Controls.Add(this.mobjButtonUpload);
			this.Size = new System.Drawing.Size(632, 560);
			this.ResumeLayout(false);

		}
		#endregion

		private void mobjButtonUpload_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog objFile = new OpenFileDialog();
			objFile.FileOk+=new CancelEventHandler(objFile_FileOk);
            objFile.MaxFileSize = 1000000;
            //objFile.Filter = "Image files(*.bmp;*.gif;*.jpg)|*.bmp;*.gif;*.jpg";
            objFile.Multiselect = true ;
			objFile.ShowDialog();
		}

		private void objFile_FileOk(object sender, CancelEventArgs e)
		{
			OpenFileDialog objFileDialog = (OpenFileDialog)sender;

            mobjFilesPanel.Controls.Clear();

            foreach (string strFile in objFileDialog.Files)
            {
                FileHandle objFile = objFileDialog.Files[strFile];
                if (objFile != null)
                {
                    LinkLabel objFileLink = new LinkLabel();
                    objFileLink.Dock = DockStyle.Top;
                    objFileLink.Text = Path.GetFileName(objFile.OriginalFileName);
                    objFileLink.Tag = objFile;

                    objFileLink.Click += new EventHandler(objFileLink_Click);
                    mobjFilesPanel.Controls.Add(objFileLink);
                }
            }
            
		}

        void objFileLink_Click(object sender, EventArgs e)
        {
            LinkLabel objFileLink = (LinkLabel)sender;

            FileHandle objFile = objFileLink.Tag as FileHandle;
            if (objFile != null)
            {
                NameValueCollection objArgs = new NameValueCollection();
                objArgs["file"] = objFileLink.Parent.Controls.IndexOf(objFileLink).ToString();
                Link.Download(new GatewayResourceHandle(this, "download", objArgs), Path.GetFileName(objFile.OriginalFileName));
            }
        }

        protected override IGatewayHandler ProcessGatewayRequest(HostContext objHostContext, string strAction)
        {
            if (strAction == "download")
            {
                string strFile = objHostContext.Request.QueryString["file"];
                if (!string.IsNullOrEmpty(strFile))
                {
                    int intFile = 0;
                    if (int.TryParse(strFile, out intFile))
                    {
                        if (mobjFilesPanel.Controls.Count > intFile)
                        {
                            FileHandle objFile = mobjFilesPanel.Controls[intFile].Tag as FileHandle;
                            if (objFile != null)
                            {
                                objHostContext.Response.ContentType =  objFile.ContentType;

                                objHostContext.Response.WriteFile(objFile.FileName);
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
	}
}
