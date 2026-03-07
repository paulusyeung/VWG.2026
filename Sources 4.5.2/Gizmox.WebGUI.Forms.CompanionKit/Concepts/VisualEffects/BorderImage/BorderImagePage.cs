using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;

namespace CompanionKit.Concepts.VisualEffects.BorderImage
{
    public partial class BorderImagePage : UserControl
    {
        //Constants of BorderImage's parameters
        const int mintBorderOffset = 5;
        const int mintBorderSize = 15;

        public BorderImagePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the objBorderRepeatComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjBorderRepeatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mobjBorderRepeatComboBox.SelectedIndex > 0)
            {
                //Applies parameter of BorderRepeat to BorderImage visual effect, if such effect already exists
                mobjVisualButton.VisualEffect = new Gizmox.WebGUI.Common.Forms.VisualEffects.BorderImageVisualEffect(new ImageResourceHandle("border.png"), mintBorderOffset, mintBorderOffset, mintBorderOffset, mintBorderOffset, (mobjBorderRepeatComboBox.SelectedIndex-1), (mobjBorderRepeatComboBox.SelectedIndex-1), mintBorderSize, mintBorderSize, mintBorderSize, mintBorderSize);
                mobjVisualButton.Update();
            }
            else { mobjVisualButton.VisualEffect = null; mobjVisualButton.Update(); }
        }
    }
}