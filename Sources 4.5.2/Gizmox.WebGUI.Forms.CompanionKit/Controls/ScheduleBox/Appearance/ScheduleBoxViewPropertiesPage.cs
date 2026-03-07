using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ScheduleBox.Appearance
{
    public partial class ScheduleBoxViewPropertiesPage : UserControl
    {
        public ScheduleBoxViewPropertiesPage()
        {
            InitializeComponent();
        }

        private void ScheduleBoxViewPropertiesPage_Load(object sender, EventArgs e)
        {
			this.objAppearance.ScheduleBox = this.demoScheduleBox;

			// Fill the ScheduleBox events
			foreach (ScheduleBoxEvent currEvent in Events.GetEvents())
			{
			    this.demoScheduleBox.Events.Add(currEvent);
			}
			
			// Initialize view settings
			this.objAppearance.SetInitial_1();
        }

		/// <summary>
		/// Show event details on event double click
		/// </summary>
		private void EventDoubleClick(object sender, Gizmox.WebGUI.Forms.ScheduleBox.ScheduleBoxEventArgs e)
		{
			Events.ProcessOpenEvent(demoScheduleBox, e.Event);
		}
    }
}