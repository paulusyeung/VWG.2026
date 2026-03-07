using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.VisualEffects.TextShadow
{
    public partial class TextShadowPage : UserControl
    {
        //Constants of TextShadow's parameters
        const int mintHorizontalShadow = 5;
        const int mintVerticalShadow = 5;
        const int mintBlurDistance = 2;

        public TextShadowPage()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Handles the Closed event of the mobjColorDialog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjColorDialog_Closed(object sender, EventArgs e)
        {
            //Applies selected color to preview panel
            mobjColorPanel.BackColor = mobjColorDialog.Color;
            //Updates Label's TextShadow visual effect, if such already exists
            if (mobjTextLabel.VisualEffect != null)
            {
                mobjTextLabel.VisualEffect = new Gizmox.WebGUI.Forms.VisualEffects.TextShadowVisualEffect(mintHorizontalShadow, mintVerticalShadow, mintBlurDistance, mobjColorPanel.BackColor);
                mobjTextLabel.Update();
            }
                
        }


        /// <summary>
        /// Handles the Click event of the mobjToggleButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjToggleButton_Click(object sender, EventArgs e)
        {
            //If Label doesn't have effect -- applies TextShadow visual effect, otherwise -- remove it
            mobjTextLabel.VisualEffect = mobjTextLabel.VisualEffect != null ? null : new Gizmox.WebGUI.Forms.VisualEffects.TextShadowVisualEffect(mintHorizontalShadow, mintVerticalShadow, mintBlurDistance, mobjColorPanel.BackColor);
            mobjTextLabel.Update();

            //Toggles button's text
            mobjToggleButton.Text = mobjTextLabel.VisualEffect == null ? "Show TextShadow" : "Hide TextShadow";
        }

        /// <summary>
        /// Handles the Click event of the mobjShadowColorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjShadowColorButton_Click(object sender, EventArgs e)
        {
            //Opens dialog
            mobjColorDialog.ShowDialog();
        }
    }
}