using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ListView.Features
{
    public partial class ItemPositionPage : UserControl
    {
        public ItemPositionPage()
        {
            InitializeComponent();

            //Fill ComboBox with values of ListView.View property
            foreach (View obj in Enum.GetValues(typeof(View)))
            {
                //Ignore View.Tile because it's not implemented
                if (obj != View.Tile)
                    mobjViewCB.Items.Add(obj);
            }
            //Define default selected item
            mobjListView.SelectedIndex = 0;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjViewCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjViewCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set ListView.View to selected value
            mobjListView.View = (View)mobjViewCB.SelectedItem;

            //Update NumericUpDowns values
            mobjXNumeric.Value = mobjListView.SelectedItem.Position.X;
            mobjYNumeric.Value = mobjListView.SelectedItem.Position.Y;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Update NumericUpDowns values
            mobjXNumeric.Value = mobjListView.SelectedItem.Position.X;
            mobjYNumeric.Value = mobjListView.SelectedItem.Position.Y;
        }

        /// <summary>
        /// Handles the ValueChanged event of the mobjXNumeric control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjXNumeric_ValueChanged(object sender, EventArgs e)
        {
            mobjListView.SelectedItem.Position = new Point(Convert.ToInt32(mobjXNumeric.Value), Convert.ToInt32(mobjYNumeric.Value));
        }

        /// <summary>
        /// Handles the ValueChanged event of the mobjYNumeric control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjYNumeric_ValueChanged(object sender, EventArgs e)
        {
            mobjListView.SelectedItem.Position = new Point(Convert.ToInt32(mobjXNumeric.Value), Convert.ToInt32(mobjYNumeric.Value));
        }
    }
}