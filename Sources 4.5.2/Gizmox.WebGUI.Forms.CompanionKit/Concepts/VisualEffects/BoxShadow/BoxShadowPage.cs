using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.VisualEffects.BoxShadow
{
    public partial class BoxShadowPage : UserControl
    {
        //Constants of BoxShadow's parameters
        const int mintHorizontalShadow = 15;
        const int mintVericalShadow = 15;
        const int mintBlurDistance = 5;
        const int mintSpreadDistance = 5;

        //Global variables
        bool mblnInset;
        Color mobjColorShadow = Color.Black;

        public BoxShadowPage()
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
        }


        /// <summary>
        /// Handles the Click event of the mobjToggleButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjToggleButton_Click(object sender, EventArgs e)
        {
            //Applies/removes BoxShadow visual effect to/from MonthCalendar control
            mobjColorShadow = mobjColorDialog.Color;
            mobjMonthCalendar.VisualEffect = mobjMonthCalendar.VisualEffect != null ? null : new Gizmox.WebGUI.Forms.VisualEffects.BoxShadowVisualEffect(mintHorizontalShadow, mintVericalShadow, mintBlurDistance, mintSpreadDistance, mobjColorShadow, mblnInset);
            mobjMonthCalendar.Update();

            //Toggles button's text
            mobjToggleButton.Text = mobjMonthCalendar.VisualEffect == null ? "Show BoxShadow" : "Hide BoxShadow";
        }


        /// <summary>
        /// Handles the CheckedChanged event of the mobjShadowInsetCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjShadowInsetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Updates boolean inset value
            mblnInset = mobjShadowInsetCheckBox.Checked;
            //Updates BoxShadow visual effect
            UpdateBoxShadowVisualEffect();
        }


        /// <summary>
        /// Handles the BackColorChanged event of the mobjColorPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjColorPanel_BackColorChanged(object sender, EventArgs e)
        {
            //Updates shadow color value
            mobjColorShadow = mobjColorPanel.BackColor;
            //Updates BoxShadow visual effect
            UpdateBoxShadowVisualEffect();
        }

        /// <summary>
        /// Updates the box shadow visual effect.
        /// </summary>
        void UpdateBoxShadowVisualEffect()
        {
            //If MonthCalendar already has visual effect, then update it
            if (mobjMonthCalendar.VisualEffect != null)
            {
                mobjMonthCalendar.VisualEffect = new Gizmox.WebGUI.Forms.VisualEffects.BoxShadowVisualEffect(mintHorizontalShadow, mintVericalShadow, mintBlurDistance, mintSpreadDistance, mobjColorShadow, mblnInset);
            }
        }

        /// <summary>
        /// Handles the Click event of the mobjChooseColorButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjChooseColorButton_Click(object sender, EventArgs e)
        {
            //Opens dialog
            mobjColorDialog.ShowDialog();
        }

    }
}