using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.VisualEffects.BorderRadius
{
    public partial class BorderRadiusPage : UserControl
    {
        //Define RadiusAll value
        public int intRadius=20;
        //Define BorderRadius Visual Effect
        public Gizmox.WebGUI.Forms.VisualEffects.BorderRadiusVisualEffect mobjVE;
        public BorderRadiusPage()
        {
            InitializeComponent();
            //Set default Visual Effect for TextBox
            mobjVE = new Gizmox.WebGUI.Forms.VisualEffects.BorderRadiusVisualEffect(intRadius);
            mobjTextBox.VisualEffect = mobjVE;
        }


        /// <summary>
        /// Handles the Click event of the mobjMinusButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjMinusButton_Click(object sender, EventArgs e)
        {
            //Decrease RadiusAll value
            intRadius = intRadius >= 5 ? intRadius - 5 : intRadius;
            mobjVE.BorderRadiusAll = intRadius;
            mobjTextBox.Update();
        }

        /// <summary>
        /// Handles the Click event of the mobjPlusButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjPlusButton_Click(object sender, EventArgs e)
        {
            //Increase RadiusAll value
            intRadius = intRadius <= 70 ? intRadius + 5 : intRadius;
            mobjVE.BorderRadiusAll = intRadius;
            mobjTextBox.Update();
        }

    }
}