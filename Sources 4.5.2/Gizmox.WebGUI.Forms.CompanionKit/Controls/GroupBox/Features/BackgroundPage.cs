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
	public partial class BackgroundPage : UserControl
	{
		public BackgroundPage()
		{
			InitializeComponent();
		}

        /// <summary>
        /// Handles CheckedChanged event of the RadioButton controls
        /// Changes GroupBox background color according to RadioButton
        /// value that raised the event
        /// </summary>
		private void Color_Changed(object sender, EventArgs e)
		{
            if (sender == mobjMoccasin)
				mobjGroupColor.BackColor = Color.Moccasin;
			else if(sender == mobjSnow)
				mobjGroupColor.BackColor = Color.Snow;
			else if(sender == mobjTransparent)
				mobjGroupColor.BackColor = Color.Transparent;
		}
	}
}