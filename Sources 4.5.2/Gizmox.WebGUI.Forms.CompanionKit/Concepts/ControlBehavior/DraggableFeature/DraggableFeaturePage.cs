using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ControlBehavior.DraggableFeature
{
    public partial class DraggableFeaturePage : UserControl
    {
        public DraggableFeaturePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the LocationChanged event of the mobjButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjButton_LocationChanged(object sender, EventArgs e)
        {
            mobjTargetPanel.BorderColor = IsInBounds(mobjButton, mobjTargetPanel) ? Color.Green : Color.Red;
        }

        /// <summary>
        /// Determines whether [is in bounds] [the specified obj source control].
        /// </summary>
        /// <param name="objDraggedControl">The obj source control.</param>
        /// <param name="objDropTargetControl">The obj comparative control.</param>
        /// <returns>
        ///   <c>true</c> if [is in bounds] [the specified obj source control]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsInBounds(Control objDraggedControl, Control objDropTargetControl)
        {
            //Defines as half of button's height(width)
            int mintDeltaDistance = mobjButton.Size.Height / 2;
            //Point, which located into center of source control(button)
            Point mobjMiddlePointLocation = new Point(objDraggedControl.Location.X + mintDeltaDistance, objDraggedControl.Location.Y + mintDeltaDistance);
            //If "middle point" is located inside of comparative control -- place source control fully inside and return true
            if (mobjMiddlePointLocation.X > objDropTargetControl.Location.X &&
                mobjMiddlePointLocation.X < objDropTargetControl.Location.X + objDropTargetControl.Size.Width &&
                mobjMiddlePointLocation.Y > objDropTargetControl.Location.Y &&
                mobjMiddlePointLocation.Y < objDropTargetControl.Location.Y + objDropTargetControl.Size.Height)
            {
                objDraggedControl.Location = new Point(objDropTargetControl.Location.X + 1, objDropTargetControl.Location.Y + 1);
                return true;
            }
            //otherwise -- return false
            else { return false; }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjCheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //Changes button's text
            mobjButton.Text = mobjCheckBox.Checked ? "Draggable Button" : "Non-Draggable Button";
            //Toggles IsDraggable property's state
            mobjButton.Draggable.IsDraggable = mobjCheckBox.Checked;
            mobjButton.Update();
        }

        private void mobjRevertModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Defines RevertMode property
            switch (mobjRevertModeComboBox.SelectedIndex)
            {
                //None(default)
                case 0:
                    mobjButton.Draggable.RevertMode = RevertMode.None;
                    break;
                //Always
                case 1:
                    mobjButton.Draggable.RevertMode = RevertMode.Always;
                    break;
                //Invalid
                case 2:
                    mobjButton.Draggable.RevertMode = RevertMode.Invalid;
                    break;
                //Valid
                case 3:
                    mobjButton.Draggable.RevertMode = RevertMode.Valid;
                    break;

            }
            //Updates control
            mobjButton.Update();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjSnapModeComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjSnapModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Defines SnapMode property
            switch (mobjSnapModeComboBox.SelectedIndex)
            {
                //Both(default)
                case 0:
                    mobjButton.Draggable.SnapMode = SnapMode.Both;
                    break;
                //Inner
                case 1:
                    mobjButton.Draggable.SnapMode = SnapMode.Inner;
                    break;
                //Outer
                case 2:
                    mobjButton.Draggable.SnapMode = SnapMode.Outer;
                    break;

            }
            //Updates control
            mobjButton.Update();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the mobjSnapToComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjSnapToComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Defines SnapTo property
            switch (mobjSnapToComboBox.SelectedIndex)
            {
                //None(default)
                case 0:
                    mobjButton.Draggable.SnapTo = SnapTo.None;
                    break;
                //All
                case 1:
                    mobjButton.Draggable.SnapTo = SnapTo.All;
                    break;
                //Siblings
                case 2:
                    mobjButton.Draggable.SnapTo = SnapTo.Siblings;
                    break;
            }
            //Updates control
            mobjButton.Update();
        }

        /// <summary>
        /// Handles the Load event of the DraggableFeaturePage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void DraggableFeaturePage_Load(object sender, EventArgs e)
        {
            //Calculating and placing button and panel controls
            mobjButton.Location = new Point((int)(mobjContainerPanel.Size.Width * 0.1f), mobjButton.Location.Y);
            mobjTargetPanel.Location = new Point((int)(mobjContainerPanel.Size.Width - (mobjContainerPanel.Size.Width * 0.1f) - mobjButton.Size.Width), mobjTargetPanel.Location.Y); 
        }
    }
}