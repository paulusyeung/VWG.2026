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

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Programming
{
    public partial class BindingToEventsForm : Form
    {
        public BindingToEventsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles FireEvent event of Form
        /// </summary>
        protected override void FireEvent(Gizmox.WebGUI.Common.Interfaces.IEvent objEvent)
        {
            // Call base method
            base.FireEvent(objEvent);

            // Search for custom event types
            switch (objEvent.Type)
            {
                case "AddListBoxItem":
                    // Check if key exists
                    if (objEvent["ItemName"] != null && !String.IsNullOrEmpty(objEvent["ItemName"]))
                    {
                        // Add item to ListBox
                        this.listBox.Items.Insert(0, objEvent["ItemName"]);
                    }
                    // Update Form to display all changes
                    this.Update();
                    break;
            }
        }
    }
}