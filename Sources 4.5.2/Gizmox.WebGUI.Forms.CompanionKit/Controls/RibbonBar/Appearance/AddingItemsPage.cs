using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.RibbonBar.Appearance
{
    public partial class AddingItemsPage : UserControl
    {
        public AddingItemsPage()
        {
            InitializeComponent();

			PostInitialize();
		}

		/// <summary>
		/// Post initialize actions and tweaking appearance of underlying controls
		/// </summary>
		private void PostInitialize()
		{
			// Work around for VWG-8391
			// remove and add from/to collection to cause width recalculate
			rbGroupIntelliSence.Items.Remove(rbIntelliSense);
			rbGroupIntelliSence.Items.Add(rbIntelliSense);

			// Expand the group (to ensure visibility when width will be changed)
			(rbGroupIntelliSence.Control as Gizmox.WebGUI.Forms.GroupBox).Width = 520;
			
			// Align checkbox with other controls
			(rbSItemCase.Control as Gizmox.WebGUI.Forms.CheckBox).Margin = new Padding(3,3,0,0);

			// set initial state
			demoRibbonBar.SelectedIndex = 0;
			SelectedIndexChanged(demoRibbonBar, new EventArgs());

			// Set combo to disable text editing, select first Item, add space between
			Gizmox.WebGUI.Forms.ComboBox objCombo = (Gizmox.WebGUI.Forms.ComboBox)rbSItemCmb.Control;
			objCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			objCombo.SelectedIndex = 0;
			// Preserve initial margin (bottom) and add space to the right side
			objCombo.Margin = new Padding(0,0,3,7);
			objCombo.SelectedIndexChanged += new EventHandler(Combo_SelectedIndexChanged);
		}

		/// <summary>
		/// Provide logic for Where to search selection.
		/// "All" item drops all other checks
		/// </summary>
		private void menuWhere_Click(object sender, EventArgs e)
		{
			if (sender == menuWhereAll)
			{
				menuWhereAll.Checked = true;
				menuWhereCode.Checked = menuWhereDocs.Checked = menuWhereImages.Checked = false;
			}
			else
			{
				menuWhereAll.Checked = false;
				((MenuItem)sender).Checked = true;
			}
		}

		/// <summary>
		/// Set value to the width of RibbonBarFlowItem
		/// </summary>		
		private void Width_ValueChanged(object sender, EventArgs e)
		{
			rbIntelliSense.Width = mobjTrackWidth.Value;
			lblWidth.Text = string.Format("RibbonBarFlowItem width: {0}", mobjTrackWidth.Value); 

			// Add a thin border to visualize the boudaries
			rbIntelliSense.Control.BorderColor = Color.LightSteelBlue;
			rbIntelliSense.Control.BorderStyle = BorderStyle.FixedSingle;
			rbIntelliSense.Control.BorderWidth = 1;

		}

		/// <summary>
		/// Set initial value to the width of RibbonBarFlowItem
		/// </summary>
		private void Width_SetInitial(object sender, EventArgs e)
		{
			rbIntelliSense.Width = mobjTrackWidth.Value = 230;

			// hide the border
			rbIntelliSense.Control.BorderStyle = BorderStyle.None;
		}
		
		/// <summary>
		/// Display text in the label with event handler message
		/// </summary>
		private void MessageEventHandler(string text)
		{
			lblEventHandler.Text = string.Format("Event handler: {0}", text);
		}

		#region 1) RibbonBar control Event Handlers
		
		/// <summary>
		/// Reflect the active page switch
		/// </summary>
		private void SelectedIndexChanged(object sender, EventArgs e)
		{
			if (demoRibbonBar.SelectedIndex > -1)
			{
				RibbonBarPage objPage = demoRibbonBar.Pages[demoRibbonBar.SelectedIndex];
				if (objPage != null)
				{
					lblStatus.Text = string.Format("The active page: {0}", objPage.Text);
				}

				mobjGrpWidth.Visible = objPage == rbEdit;
			}
		}
		
		#endregion

		#region 2) RibbonBar Aggregating Event Handlers

		/// <summary>
		/// RibbonBar "advanced" anchor clicked aggregating event handler
		/// </summary>
		private void AdvancedClicked(object sender, RibbonBarGroupArgs e)
		{
			if (e != null && e.Group != null)
			{
				lblEventHandler.Visible = true;
				MessageEventHandler(string.Format("The advanced anchor: {0}", e.Group.Text));
			}
		}
		
		/// <summary>
		/// RibbonBar ButtonClick aggregating event handler of any RibbonBarButtonItem inherited item
		/// </summary>
		private void rb_ButtonClick(object sender, RibbonBarButtonItemArgs e)
		{
			MessageEventHandler(string.Format("The button clicked {0}", 
				
				e.Button.Control.Text.Length >0 ? 
				": " + e.Button.Control.Text :
				": " + (!String.IsNullOrEmpty(e.Button.Tag as string) ? e.Button.Tag.ToString() : "")  ));
		}
		
		/// <summary>
		/// RibbonBar CheckedChanged aggregating event handler of any RibbonBarCheckBoxItem
		/// </summary>		
		private void rb_CheckedChanged(object sender, RibbonBarCheckBoxItemArgs e)
		{
			bool blnChecked = ((Gizmox.WebGUI.Forms.CheckBox)e.CheckBox.Control).Checked;

			MessageEventHandler(string.Format("The check changed: {0}", 
				blnChecked ? "checked" : "not checked"));
		}

		/// <summary>
		/// RibbonBar TextChanged aggregating event handler of any RibbonBarTextBoxItem
		/// </summary>		
		private void rb_TextChanged(object sender, RibbonBarTextBoxItemArgs e)
		{
			MessageEventHandler(string.Format("The text changed: {0}", e.TextBox.Control.Text));
		}

		#endregion

		#region 3) Item and SubItem objects events
		
		/// <summary>
		/// SubItem specific RibbonBarDropDownButtonItem MenuClick event handler
		/// </summary>	
		private void rb_MenuClick(object objSource, MenuItemEventArgs objArgs)
		{
			MessageEventHandler(
				string.Format("The menu item clicked: {0}", objArgs.MenuItem.Text));
		}
    	
		#endregion

		#region 4) Item and SubItem underlying control events (like Button, CheckBox, TextBox, ComboBox)
		
		/// <summary>
		/// SubItem event handler of underlying Combobox
		/// </summary>	
		private void Combo_SelectedIndexChanged(object sender, EventArgs e)
		{
			Gizmox.WebGUI.Forms.ComboBox objCombo = (Gizmox.WebGUI.Forms.ComboBox)rbSItemCmb.Control;

			MessageEventHandler(string.Format("The index changed: {0} - {1}", 
				objCombo.SelectedIndex, objCombo.SelectedItem));
		}		
		
		#endregion

	}
}