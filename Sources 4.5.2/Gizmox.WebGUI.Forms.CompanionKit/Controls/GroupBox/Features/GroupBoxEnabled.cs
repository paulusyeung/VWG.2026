#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace CompanionKit.Controls.GroupBox.Features
{
	public partial class GroupBoxEnabled : UserControl
	{
		public GroupBoxEnabled()
		{
			InitializeComponent();
		}

        /// <summary>
        /// Handles CheckedChanged event of the CheckBox control
        /// </summary>
		private void Enable_CheckedChanged(object sender, EventArgs e)
		{
            //Switch GroupBox Enable property according to the CheckBox state
			mobjGrpControls.Enabled = mobjChkEnable.Checked;
		}
	}
}