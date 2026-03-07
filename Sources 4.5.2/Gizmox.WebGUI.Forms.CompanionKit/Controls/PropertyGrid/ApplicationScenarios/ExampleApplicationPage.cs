using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.PropertyGrid.ApplicationScenarios
{
    public partial class ExampleApplicationPage : UserControl
    {
        public ExampleApplicationPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles click event of the Buttons that creates event.
        /// </summary>
        private void createEventsButton_Click(object sender, EventArgs e)
        {
            string eventSummary = this.eventSummaryTextBox.Text;
            if (string.IsNullOrEmpty(eventSummary))
            {
                MessageBox.Show("Please enter summary event!");
                return;
            }


            // Add event to ListView
            ListViewItem newItem = new ListViewItem(
                new string[]{this.demoDateTimePicker.Value.ToString("dddd, MMMM dd, yyyy HH:mm:ss"),
                                eventSummary});
            this.mobjEventsListView.Items.Add(newItem);
            this.mobjEventsListView.SelectedItem = newItem;
            
        }

        /// <summary>
        /// Handles click event of the menu item, that opens Options dialog for source control.
        /// </summary>
        private void optionsMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem objMenuItem = sender as MenuItem;
            // object ownerControl = ((Gizmox.WebGUI.Forms.ContextMenu)optionsmenu.Parent).SourceControl;
            object ownerControl = this.ActiveControl;
            
            // Shows Options dialog for source control.
            OptionsDialog optionsDialog = new OptionsDialog(ownerControl);
            optionsDialog.ShowDialog();
        }

        /// <summary>
        /// Handles Load event for example's UserControl
        /// </summary>
        private void ExampleApplicationPage_Load(object sender, EventArgs e)
        {
            // Fill up ListView with events
            for (int i = 0; i < 3; ++i)
            {
                this.mobjEventsListView.Items.Add(new ListViewItem(
                                   new string[]{DateTime.Now.ToString("dddd, MMMM dd, yyyy HH:mm:ss"),
                                                    string.Format("Event {0}", i)}));
            }
        }
    }
}
