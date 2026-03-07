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

#endregion

namespace CompanionKit.Controls.StatusBar.Appearance
{
    public partial class DifferentAppearancePage : UserControl
    {
        public DifferentAppearancePage()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Handles Click event of the 'Set text to StatusBar' button.
        /// Sets text of the TextBox in the text for the StatusBar.
        /// </summary>
        private void mobjSetTextButton_Click(object sender, EventArgs e)
        {
            this.mobjTestStatusBar.Text = this.mobjStatusBarTextBox.Text;
        }

        /// <summary>
        /// Handles Click event of the 'Change Font of StatusBar text' button.
        /// Opens a FontDialog for the change font for the text of the StatusBar.
        /// </summary>
        private void mobjChangeFontButton_Click(object sender, EventArgs e)
        {
            this.mobjChangeStatusBarFontDialog.Font = this.mobjTestStatusBar.Font;
            this.mobjChangeStatusBarFontDialog.ShowDialog();
        }

        /// <summary>
        /// Handles Apply action for FontDialog.
        /// Changes font of the StatusBar text.
        /// </summary>
        private void mobjChangeStatusBarFontDialog_Apply(object sender, EventArgs e)
        {
            FontDialog mobjFontDialog = sender as FontDialog;
            SetFontForStatusBar(mobjFontDialog.Font);
        }

        /// <summary>
        /// Handles Closed event for FontDialog.
        /// Changes font of the StatusBar text.
        /// </summary>
        private void mobjChangeStatusBarFontDialog_Closed(object sender, EventArgs e)
        {
            FontDialog mobjFontDialog = sender as FontDialog;
            SetFontForStatusBar(mobjFontDialog.Font);
        }

        /// <summary>
        /// Changes font of the StatusBar text to passed Font.
        /// </summary>
        /// <param name="newFont">a new font of the StatusBar text.</param>
        private void SetFontForStatusBar(Font newFont)
        {
            this.mobjTestStatusBar.Font = newFont;
            UpdateFontLabel(newFont);
        }

        /// <summary>
        /// Updates the label text, that indicates what font is of the StatusBar text.
        /// </summary>
        /// <param name="newFont">the font of the StatusBar text.</param>
        private void UpdateFontLabel(Font newFont)
        {
            if (newFont != null)
            {
                this.mobjFontStatusBarLabel.Text = string.Format("Font: {0}, {1}pt", newFont.Name, newFont.Size);
            }
        }

        /// <summary>
        /// Handles Load event for example UserControl.
        /// </summary>
        private void DifferentAppearancePage_Load(object sender, EventArgs e)
        {
            this.mobjStatusBarTextBox.Text = this.mobjTestStatusBar.Text;
            UpdateFontLabel(this.mobjTestStatusBar.Font);
            this.mobjTestStatusBar.BackgroundImage = new ImageResourceHandle("StatusBarImg.jpg");
        }
    }
}