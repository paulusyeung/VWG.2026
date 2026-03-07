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

namespace CompanionKit.Controls.Timer.Features
{
    public partial class IntervalActionPage : UserControl
    {
		public const string FORMAT = "hh:mm:ss tt";

        public IntervalActionPage()
        {
            InitializeComponent();
            this.label1.Text = DateTime.Now.ToString(FORMAT);
        }

        /// <summary>
        /// Handles Tick event of the Timer.
        /// Updates text of the Label with current time.
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString(FORMAT);

			// Disable the Timer when the UserControl removed from the container
			if (this.Parent == null)
			{
				this.timer1.Enabled = false;
			}
        }
    }
}