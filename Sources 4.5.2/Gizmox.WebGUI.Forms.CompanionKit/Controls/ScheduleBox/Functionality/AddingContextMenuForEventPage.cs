using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.ScheduleBox.Functionality
{
    public partial class AddingContextMenuForEventPage : UserControl
    {
        public AddingContextMenuForEventPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initialize on load
        /// </summary>
        private void AddingContextMenuForEventPage_Load(object sender, EventArgs e)
        {
			//Prepare menu item for control with an image
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddingContextMenuForEventPage));
			// Create a context menu for ScheduleBox
			Gizmox.WebGUI.Forms.ContextMenu parentMenu = new Gizmox.WebGUI.Forms.ContextMenu();
			Gizmox.WebGUI.Forms.MenuItem newItem = new Gizmox.WebGUI.Forms.MenuItem("Add new ...");
			newItem.Tag = "new";
			newItem.Icon = new Gizmox.WebGUI.Common.Resources.ImageResourceHandle(resources.GetString("menuNew.Icon"));
			parentMenu.MenuItems.Add(newItem);

			this.objAppearance.ScheduleBox = this.demoScheduleBox;
			this.objAppearance.ScheduleBox.ContextMenu = parentMenu;

			// Assign handler for box Context menu of an event and control
			this.demoScheduleBox.MenuClick += new MenuEventHandler(EventMenuClick);

			// Fill the ScheduleBox events
			foreach (ScheduleBoxEvent currEvent in Events.GetEvents())
			{
				currEvent.ContextMenu = objEventMenu;
			    this.demoScheduleBox.Events.Add(currEvent);
			}

			// Initialize view settings
			this.objAppearance.SetInitial_2();
		}

		/// <summary>
		/// Call to menu open
		/// </summary>
		private void EventDoubleClick(object sender, Gizmox.WebGUI.Forms.ScheduleBox.ScheduleBoxEventArgs e)
		{
			Events.ProcessOpenEvent(demoScheduleBox, e.Event);
		}

        /// <summary>
        /// Handles Click event for an event context menu
        /// </summary>
		private void EventMenuClick(object sender, MenuItemEventArgs objArgs)
		{
            MenuItem			menuitem	= objArgs.MenuItem;
			ScheduleBoxEvent	objEvent	= (ScheduleBoxEvent)objArgs.Member;

			switch (menuitem.Tag.ToString())
			{
				case "new":
					// Opens an editing form and adds new event to demoScheduleBox if user confirmed. 
					Events.ProcessAddEvent(demoScheduleBox, objEventMenu, false, null);
					break;
				
				case "open":
					// Opens an editing form
					Events.ProcessOpenEvent(demoScheduleBox, objEvent);
					break;
				
				case "recreate":
					// Adds new event cloned from given to demoScheduleBox if user confirmed.
					Events.ProcessAddEvent(demoScheduleBox, objEventMenu, true, objEvent);
					break;

				case "delete":
					// Asks for confirmation and deletes the event
					Events.ProcessDeleteEvent(demoScheduleBox, objEvent);
					break;

				default:
					break;
			}

		}
    }
}
