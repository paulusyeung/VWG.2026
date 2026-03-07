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
	public partial class RadioButtonsPage : UserControl
	{
		public RadioButtonsPage()
		{
			InitializeComponent();
		}

		private void ClassRoom_Changed(object sender, EventArgs e)
		{
            //Set Label visible if it is not
			if(!mobjLblStatusClass.Visible)
				mobjLblStatusClass.Visible = true;

            //Set text to Label using the Text property value of the RadioButton
            //that raised the event
			mobjLblStatusClass.Text = 
				string.Format("Class room: \r\n{0}", ((Control)sender).Text);
		}

		private void Requirement_Changed(object sender, EventArgs e)
		{
            //Set Label visible if it is not
			if(!mobjLblRequrements.Visible)
				mobjLblRequrements.Visible = true;

            //Set text to Label using the Text property value of the RadioButton
            //that raised the event
			mobjLblRequrements.Text = 
				string.Format("Requirements: \r\n{0}", ((Control)sender).Text);
		}
	}
}