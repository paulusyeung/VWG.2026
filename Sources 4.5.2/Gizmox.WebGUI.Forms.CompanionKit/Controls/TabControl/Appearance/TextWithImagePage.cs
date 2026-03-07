#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace CompanionKit.Controls.TabControl.Appearance
{
    public partial class TextWithImagePage : UserControl
    {
        public TextWithImagePage()
        {
            InitializeComponent();
            this.mobjTextBox.Text = 
			@"Visual WebGui is a platform for rapid development, simple deployment and easy migration of desktop applications & abilities to the web, enabling secure and responsive desktop-like RIAs (Rich Internet Applications)." + 
            "This area explores the technological aspect of those and other features, benefits and usage scenarios of Visual WebGui.";
        }

        /// <summary>
        ///  Handles Load event of the example's UserControl
        /// </summary>
        private void TextWithImagePage_Load(object sender, EventArgs e)
        {
            // Fill up images list for th demonstrated TabControl
            ImageList mobjTabImages = new ImageList();
            mobjTabImages.Images.Add(new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.About.png"));
            mobjTabImages.Images.Add(new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.Sea.png"));
            mobjTabImages.Images.Add(new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.Stone.png"));
            mobjTabImages.Images.Add(new Gizmox.WebGUI.Common.Resources.ImageResourceHandle("16x16.View.png"));
            
            this.mobjDemoTabControl.ImageList = mobjTabImages;

            // Sets image indices for Tab
            this.mobjVWGTabPage.ImageIndex = 0;
            this.mobjSeaTabPage.ImageIndex = 1;
            this.mobjStoneTabPage.ImageIndex = 2;
            this.mobjViewTabPage.ImageIndex = 3;
        }
    }
}