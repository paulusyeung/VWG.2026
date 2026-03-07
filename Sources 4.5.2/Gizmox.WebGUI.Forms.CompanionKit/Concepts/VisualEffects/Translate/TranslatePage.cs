using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.VisualEffects.Translate
{
    public partial class TranslatePage : UserControl
    {
        //Duration constant
        const int mintDuration = 3;

        //Declares global variables: Horizontal and Vertical length 
        float? mfltHorizontalLength;
        float? mfltVerticalLength;

        public TranslatePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the mobjToggleButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjToggleButton_Click(object sender, EventArgs e)
        {
            //Clears all visual effects
            mobjPanel.VisualEffect = null;
            //Applies Translate visual effect to panel control
            mobjPanel.VisualEffect = new Gizmox.WebGUI.Forms.VisualEffects.TranslateVisualEffect(new Gizmox.WebGUI.Forms.VisualEffects.AxisLengthAndUnits(Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, null, null, null), new Gizmox.WebGUI.Forms.VisualEffects.AxisLengthAndUnits(Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, mfltHorizontalLength, mfltVerticalLength , null), new decimal(new int[] {
                mintDuration,
                0,
                0,
                0}), new decimal(new int[] {
                0,
                0,
                0,
                0}), Gizmox.WebGUI.Forms.VisualEffects.TransitionTimingFunction.Ease);
        }


        /// <summary>
        /// Handles the CheckedChanged event of the mobjHorizontalCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjHorizontalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if mobjHorizontalCheckBox checked -- calculate and set horizontal length, otherwise -- set null
            mfltHorizontalLength = mobjHorizontalCheckBox.Checked ? (float?)(mobjBottomPanel.Size.Width * (1.9f / 3.0f)) : null;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjVerticalCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjVerticalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if mobjVerticalCheckBox checked -- calculate and set vertical length, otherwise -- set null
            mfltVerticalLength = mobjVerticalCheckBox.Checked ? (float?)(mobjBottomPanel.Size.Height * (1.7f / 3.0f)) : null;
        }

        /// <summary>
        /// Handles the Load event of the TranslatePage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TranslatePage_Load(object sender, EventArgs e)
        {
            //Changes checkBoxes's state to "true" 
            mobjVerticalCheckBox.Checked = true;
            mobjHorizontalCheckBox.Checked = true;
        }
    }
}