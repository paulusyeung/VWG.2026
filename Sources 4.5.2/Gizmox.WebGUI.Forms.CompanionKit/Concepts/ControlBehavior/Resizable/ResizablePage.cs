using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Concepts.ControlBehavior.Resizable
{
    public partial class ResizablePage : UserControl
    {
        
        public ResizableOptions objResizeOptions = new ResizableOptions(true, new Gizmox.WebGUI.Forms.Component[0], false, 500, false, false, Gizmox.WebGUI.Forms.ContainmentMode.None, false, 0, 0);
        public ResizablePage()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjAspectRatio control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjAspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            
            //Change AspectRatio value
            objResizeOptions.AspectRatio = mobjAspectRatio.Checked;
            mobjPanel.Resizable = objResizeOptions;
            mobjPanel.Update();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjIsGhost control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjIsGhost_CheckedChanged(object sender, EventArgs e)
        {
            //Change Ghost value
            objResizeOptions.Ghost = mobjIsGhost.Checked;
            mobjPanel.Resizable = objResizeOptions;
            mobjPanel.Update();
            //Disable Grid NumericUpDown if Ghost = true or Animate = true
            mobjGridNUD.Enabled = !(mobjIsAnimated.Checked || mobjIsGhost.Checked);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the mobjIsAnimated control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjIsAnimated_CheckedChanged(object sender, EventArgs e)
        {
            //Change Animate value
            objResizeOptions.Animate = mobjIsAnimated.Checked;
            mobjPanel.Resizable = objResizeOptions;
            mobjPanel.Update();
            //Disable Grid NumericUpDown if Ghost = true or Animate = true
            mobjGridNUD.Enabled = !(mobjIsAnimated.Checked || mobjIsGhost.Checked);
        }


        /// <summary>
        /// Handles the Resize event of the mobjPanel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjPanel_Resize(object sender, EventArgs e)
        {
            //Update text of Label representing current panel size
            mobjLabelSize.Text = "Size: {" + mobjPanel.Width + ", " + mobjPanel.Height + "}";
        }

        /// <summary>
        /// Handles the Click event of the mobjResetButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjResetButton_Click(object sender, EventArgs e)
        {
            //Reset panel size
            mobjPanel.Size = new Size(100, 100);
        }

        /// <summary>
        /// Handles the ValueChanged event of the mobjDurationNUD control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjDurationNUD_ValueChanged(object sender, EventArgs e)
        {
            //Change AnimateDuration value
            objResizeOptions.AnimateDuration = (int)mobjDurationNUD.Value;
            mobjPanel.Resizable = objResizeOptions;
            mobjPanel.Update();
        }

        /// <summary>
        /// Handles the ValueChanged event of the mobjXgridNUD control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void mobjGridNUD_ValueChanged(object sender, EventArgs e)
        {
            //Change Xgrid and Ygrid values
            int intGrid = (int)mobjGridNUD.Value;
            objResizeOptions.Xgrid = intGrid;
            objResizeOptions.Ygrid = intGrid;
            mobjPanel.Resizable = objResizeOptions;
            mobjPanel.Update();
        }

    }
}