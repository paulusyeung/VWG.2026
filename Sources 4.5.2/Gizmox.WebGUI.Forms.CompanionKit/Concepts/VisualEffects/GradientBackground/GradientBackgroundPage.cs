using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.VisualEffects.GradientBackground
{
    public partial class GradientBackgroundPage : UserControl
    {
        //Global variables: color1, color2, enmGradienType 
        Color mobjColor1 = Color.Black;
        Color mobjColor2 = Color.White;
        Gizmox.WebGUI.Forms.VisualEffects.GradientType mobjGradientType = Gizmox.WebGUI.Forms.VisualEffects.GradientType.Linear;


        public GradientBackgroundPage()
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
            //If ListBox doesn't have effect -- applies GradientBackground visual effect, otherwise -- remove it
            mobjListBox.VisualEffect = mobjListBox.VisualEffect != null ? null : new Gizmox.WebGUI.Forms.VisualEffects.GradientBackgroundVisualEffect(mobjGradientType, null, Gizmox.WebGUI.Forms.VisualEffects.HorizontalDirection.None, Gizmox.WebGUI.Forms.VisualEffects.VerticalDirection.None, new Gizmox.WebGUI.Forms.VisualEffects.GradientStop[] {
            new Gizmox.WebGUI.Forms.VisualEffects.GradientStop(null, mobjColor1, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Percent),
            new Gizmox.WebGUI.Forms.VisualEffects.GradientStop(null, mobjColor2, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Percent)}, Gizmox.WebGUI.Forms.VisualEffects.RadialShape.Circle, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.ExtentKeyword.FarthestCorner, null, null);
            mobjListBox.Update();

            //Toggles button's text
            mobjToggleButton.Text = mobjListBox.VisualEffect == null ? "Show GradientBackground" : "Hide GradientBackground";
        }


        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjGradientTypeComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjGradientTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Defines enmGradientType variable according to selected comboBox item
            switch (mobjGradientTypeComboBox.SelectedIndex)
            {
                case 0:
                    mobjGradientType = Gizmox.WebGUI.Forms.VisualEffects.GradientType.Linear;
                    break;
                case 1:
                    mobjGradientType = Gizmox.WebGUI.Forms.VisualEffects.GradientType.Radial;
                    break;
                case 2:
                    mobjGradientType = Gizmox.WebGUI.Forms.VisualEffects.GradientType.RepeatingLinearGradient;
                    break;
                case 3:
                    mobjGradientType = Gizmox.WebGUI.Forms.VisualEffects.GradientType.RepeatingRadialGradient;
                    break;
            }
            //Updates GradientBackground visual effect
            UpdateGradientBackgroundVisualEffect();
        }

        /// <summary>
        /// Handles the Closed event of the mobjColorDialog1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjColorDialog1_Closed(object sender, EventArgs e)
        {
            mobjColor1 = mobjColor1Dialog.Color;
            mobjColor1Panel.BackColor = mobjColor1;
        }

        /// <summary>
        /// Handles the Closed event of the mobjColorDialog2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjColorDialog2_Closed(object sender, EventArgs e)
        {
            mobjColor2 = mobjColor2Dialog.Color;
            mobjColor2Panel.BackColor = mobjColor2;
        }

        /// <summary>
        /// Updates the gradient background visual effect.
        /// </summary>
        void UpdateGradientBackgroundVisualEffect()
        {
            //Updates GradientBackground visual effect, if such effect already exists
            if (mobjListBox.VisualEffect != null)
            {
                mobjListBox.VisualEffect = new Gizmox.WebGUI.Forms.VisualEffects.GradientBackgroundVisualEffect(mobjGradientType, null, Gizmox.WebGUI.Forms.VisualEffects.HorizontalDirection.None, Gizmox.WebGUI.Forms.VisualEffects.VerticalDirection.None, new Gizmox.WebGUI.Forms.VisualEffects.GradientStop[] {
            new Gizmox.WebGUI.Forms.VisualEffects.GradientStop(null, mobjColor1, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Percent),
            new Gizmox.WebGUI.Forms.VisualEffects.GradientStop(null, mobjColor2, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Percent)}, Gizmox.WebGUI.Forms.VisualEffects.RadialShape.Circle, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.LengthUnits.Pixel, Gizmox.WebGUI.Forms.VisualEffects.ExtentKeyword.FarthestCorner, null, null);
                mobjListBox.Update();
            }
        }

        /// <summary>
        /// Handles the BackColorChanged event of the panel controls
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ColorPanelBackColorChanged(object sender, EventArgs e)
        {
            UpdateGradientBackgroundVisualEffect();
        }

        /// <summary>
        /// Handles the Click event of the mobjColor1ChooseButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjColor1ChooseButton_Click(object sender, EventArgs e)
        {
            mobjColor1Dialog.ShowDialog();
        }

        /// <summary>
        /// Handles the Click event of the mobjColor2ChooseButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjColor2ChooseButton_Click(object sender, EventArgs e)
        {
            mobjColor2Dialog.ShowDialog();
        }
    }
}