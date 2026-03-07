using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ControlBehavior.Droppable
{
    public partial class DroppablePage : UserControl
    {
        //Define bool value indicating whether Label already exists on panel
        public bool blnLabelExists;
        //Define Labels array
        public Label[] mobjLabelsArray; 
        public DroppablePage()
        {
            InitializeComponent();
            //Fill Labels array
            mobjLabelsArray = new Label[] { mobjRedLbl1, mobjYellowLbl1, mobjYellowLbl2, mobjBlueLbl, mobjRedLbl2 };
        }
        /// <summary>
        /// Handles the ControlDropped event of the mobjPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ControlEventArgs"/> instance containing the event data.</param>
        private void mobjPanel_ControlDropped(object sender, ControlEventArgs e)
        {
            blnLabelExists = false;
            //For each Label on Panel
            foreach (Control mobjLabel in mobjPanel.Controls)
            {
                //If label with this name is already on panel
                if (mobjLabel.Text == e.Control.Text)
                {
                    //Show warning message
                    MessageBox.Show(e.Control.Text + " already exists");
                    //Change blnLabelExists value
                    blnLabelExists = true;
                    //Change the Text property of the same label on panel
                    mobjLabel.Text += "(2)";
                    //Hide duplicated Label
                    e.Control.Hide();
                }
            }

            //If dropped Label doesn't exist on Panel
            if (!blnLabelExists)
            {
                //Add dropped Label to Panel
                mobjPanel.Controls.Add(e.Control);
                e.Control.Dock = DockStyle.Top;
                e.Control.BringToFront();
            }

        }

        /// <summary>
        /// Handles the Click event of the mobjClearButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjClearButton_Click(object sender, EventArgs e)
        {
            //Define Labels counter
            int i = 0;
            //For each Label in array
            for (int j = 0; j < mobjLabelsArray.Length; j++)
            {
                //Bring the Label back on its default location with default Text
                mobjLabelsArray[i].Show();
                mobjLabelsArray[i].Text = mobjLabelsArray[i].Text.Replace("(2)", "");
                mobjLabelsArray[i].Parent = this;
                mobjLabelsArray[i].Dock = DockStyle.None;
                mobjLabelsArray[i].Location = new Point(10, 70 + 45 * i);
                i++;
            }
        }

    }
}