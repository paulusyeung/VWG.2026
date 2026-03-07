#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using System.Web;

#endregion

namespace CompanionKit.Controls.CommonDialogs.OpenFileDialog.ApplicationScenarios
{
    public partial class DisplayPicturePage : UserControl
    {
        /// <summary>
        /// Represents full name of user selected file
        /// </summary>
        private string _selectedFile;

        public DisplayPicturePage()
        {
            InitializeComponent();
        }

        private void DisplayPicturePage_Load(object sender, EventArgs e)
        {
            //Set initial image for PictureBox
            this.mobjRepresentedPictureBox.BackgroundImage = new ImageResourceHandle("View.jpg");
			this.mobjRepresentedPictureBox.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void mobjOpenFileButton_Click(object sender, EventArgs e)
        {
            //Set images file Filter for Open File Dialog .
            this.mobjDemoOpenFileDialog.Filter = "Image Files (JPEG,GIF,BMP)|*.jpg;*.jpeg;*.gif;*.bmp|JPEG Files(*.jpg;*.jpeg)|*.jpg;*.jpeg|GIF Files(*.gif)|*.gif|BMP Files(*.bmp)|*.bmp";
            //Show OpenFile Dialog
            this.mobjDemoOpenFileDialog.ShowDialog();
        }

        private void demoOpenFileDialog_Closed(object sender, EventArgs e)
        {
            //Load image file in PictureBox if user click on OK Button
            if (this.mobjDemoOpenFileDialog.DialogResult == DialogResult.OK)            
            {
                //Set full name of selected file
                _selectedFile = this.mobjDemoOpenFileDialog.File.FileName;
                //Set ResourceHandle with selected image file for Picturebox Image.
                this.mobjRepresentedPictureBox.BackgroundImage = new GatewayResourceHandle(new GatewayReference(this, "image"));
				this.mobjRepresentedPictureBox.Update();
            }
        }

		protected override IGatewayHandler ProcessGatewayRequest(HttpContext objHttpContext, string strAction)
		{
            IGatewayHandler handler = null;
            
			switch (strAction)
            {
                case "image":
                    handler = new FileHandler(_selectedFile);
                    break;
				default:
					handler = base.ProcessGatewayRequest(objHttpContext, strAction);
					break;
			}			

			return handler;
		}

        /// <summary>
        /// Summary description for FileHandler.
        /// </summary>
        public class FileHandler : IGatewayHandler
        {
            private string _fileName;

            public FileHandler(string fileName)
            {
                _fileName = fileName;
            }

            public void ProcessGatewayRequest(IContext objContext, IRegisteredComponent objComponent)
            {
                HttpContext.Current.Response.WriteFile(_fileName);
            }
        }

       
    }
}