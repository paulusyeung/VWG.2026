using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WebGUIForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using System.Collections;

namespace Gizmox.WebGUI.Forms.Design.Controls
{
	/// <summary>
	///
	/// </summary>
    [System.ComponentModel.ToolboxItem(false)]	
	public partial class ItemChooser : WinForms.UserControl
	{				
		#region C'Tor\D'Tor
		
		/// <summary>
		/// Creates a new <see cref="ItemChooser"/> instance.
		/// </summary>
		public ItemChooser()
		{
			InitializeComponent();
			
			#region Event Attaching
			
			this.mobjButtonMoveUp.Click+=new EventHandler(mobjButtonMoveUp_Click);
			this.mobjButtonMoveDown.Click+=new EventHandler(mobjButtonMoveDown_Click);
			this.mobjButtonShow.Click+=new EventHandler(mobjButtonShow_Click);
			this.mobjButtonHide.Click+=new EventHandler(mobjButtonHide_Click);
			this.mobjListItems.SelectedIndexChanged+=new EventHandler(mobjListItems_SelectedIndexChanged);
			this.mobjListItems.ItemCheck += new WinForms.ItemCheckEventHandler(mobjListItems_ItemCheck);
			
			#endregion
			
			this.mobjButtonHide.Text = WGLabels.Hide;
			this.mobjButtonMoveDown.Text = WGLabels.MoveDown;
			this.mobjButtonMoveUp.Text = WGLabels.MoveUp;
			this.mobjButtonShow.Text = WGLabels.Show;
			this.mobjListItems.DisplayMember = "Text";
		}
		
		
		#endregion C'Tor\D'Tor
		
		#region Methods
				
		/// <summary>
		/// Updates the state of the buttons.
		/// </summary>
		public void UpdateButtonsState()
		{
			int intSelected = mobjListItems.SelectedIndex;
			int intLast		= mobjListItems.Items.Count-1;
			bool blnChecked	=mobjListItems.GetItemChecked(intSelected);
			
			this.mobjButtonMoveUp.Enabled	= intSelected!=0;
			this.mobjButtonMoveDown.Enabled = intSelected!=intLast;
			this.mobjButtonHide.Enabled		= blnChecked;
			this.mobjButtonShow.Enabled		= !blnChecked;
		}
		
		#endregion Methods

		#region Events
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjButtonHide_Click(object sender, EventArgs e)
		{
			mobjListItems.SetItemChecked(mobjListItems.SelectedIndex,false);
            UpdateButtonsState();
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjButtonShow_Click(object sender, EventArgs e)
		{
			mobjListItems.SetItemChecked(mobjListItems.SelectedIndex,true);
            UpdateButtonsState();
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjButtonMoveUp_Click(object sender, EventArgs e)
		{
			if(mobjListItems.SelectedIndex>0)
			{
                SwapSelectedItems(mobjListItems, true);
			}
			
			UpdateButtonsState();
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjButtonMoveDown_Click(object sender, EventArgs e)
		{
			if(mobjListItems.SelectedIndex<mobjListItems.Items.Count-1)
			{
				SwapSelectedItems(mobjListItems, false);
			}
			
			UpdateButtonsState();
		}

        /// <summary>
        /// Swap between selected item and next or previous item.
        /// </summary>
        private void SwapSelectedItems(WinForms.CheckedListBox objCheckedListBox, bool blnUp)
        {
            // Unbind the selected index changed, because we dont need it here.
            this.mobjListItems.SelectedIndexChanged -= new EventHandler(mobjListItems_SelectedIndexChanged);

            bool isSelectdItemChecked = objCheckedListBox.CheckedItems.Contains(objCheckedListBox.SelectedItem);

            // Find the next or previous index.
            int intInsertIndex = objCheckedListBox.SelectedIndex + 1;
            if (blnUp)
            {
                intInsertIndex = objCheckedListBox.SelectedIndex - 1;
            }

            // Get swap items.
            object objItem1 = objCheckedListBox.Items[objCheckedListBox.SelectedIndex];
            object objItem2 = objCheckedListBox.Items[intInsertIndex];
            
            // Replace between swap items.
            objCheckedListBox.Items.Remove(objItem1);
            objCheckedListBox.Items.Insert(intInsertIndex, objItem1);

            // Return the selected index and checked state if needed.
            objCheckedListBox.SetSelected(intInsertIndex, true);
            if (isSelectdItemChecked)
            {
                objCheckedListBox.SetItemChecked(intInsertIndex, true);
            }

            // Bind selected index changed.
            this.mobjListItems.SelectedIndexChanged += new EventHandler(mobjListItems_SelectedIndexChanged);
        }
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjListItems_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateButtonsState();
			
			// Raise event if needed
			if(ItemSelected!=null)
			{
				ItemSelected(this,new EventArgs());
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objSender"></param>
		/// <param name="objArgs"></param>
		private void mobjListItems_ItemCheck(object objSender, WinForms.ItemCheckEventArgs objArgs)
		{
            if (ItemCheck != null) ItemCheck(objSender, objArgs);
			
			UpdateButtonsState();
		}
		
		
		#endregion Events
				
		#region Properties
		
		/// <summary>
		/// Gets the selected item.
		/// </summary>
		/// <value></value>
		public object SelectedItem
		{
			get
			{
				return this.mobjListItems.SelectedItem;
			}
		}

        /// <summary>
        /// Gets or sets the items collection.
        /// </summary>
        /// <value></value>
        public ICollection Items
        {
            get
            {
                return this.mobjListItems.Items;
            }
            set
            {
                foreach(object objItem in value)
                {
                    this.mobjListItems.Items.Add(objItem);
                }

                if (this.mobjListItems.Items.Count > 0)
                {
                    this.mobjListItems.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Gets or sets the checked collection.
        /// </summary>
        /// <value></value>
        public ICollection Checked
        {
            get
            {
                // Create checked collection
                ArrayList objChecked = new ArrayList();

                // Loop all items
                foreach (object objObject in this.mobjListItems.Items)
                {
                    // Get item index
                    int intIndex = this.mobjListItems.Items.IndexOf(objObject);
                    if (intIndex != -1)
                    {
                        // If item checked state
                        if (this.mobjListItems.GetItemChecked(intIndex))
                        {
                            objChecked.Add(objObject);
                        }
                    }
                }

                // return the checked collection
                return objChecked;
            }
            set
            {
                // Loop all items and set checked
                foreach (object objObject in value)
                {
                    // Get item index
                    int intIndex = this.mobjListItems.Items.IndexOf(objObject);
                    if (intIndex != -1)
                    {
                        // Set item checked state
                        this.mobjListItems.SetItemChecked(intIndex, true);
                    }
                }
            }
        }
				
		/// <summary>
		/// Gets or sets the check label.
		/// </summary>
		/// <value></value>
		public string CheckLabel
		{
			get
			{
				return this.mobjButtonShow.Text;
			}
			set
			{
				this.mobjButtonShow.Text = value;
			}
		}
		
		/// <summary>
		/// Gets or sets the uncheck label.
		/// </summary>
		/// <value></value>
		public string UncheckLabel
		{
			get
			{
				return this.mobjButtonHide.Text;
			}
			set
			{
				this.mobjButtonHide.Text = value;
			}
		}

		/// <summary>
		/// Gets or sets the moveup label.
		/// </summary>
		/// <value></value>
		public string MoveUpLabel
		{
			get
			{
				return this.mobjButtonMoveUp.Text;
			}
			set
			{
				this.mobjButtonMoveUp.Text = value;
			}
		}

		/// <summary>
		/// Gets or sets the move down label.
		/// </summary>
		/// <value></value>
		public string MoveDownLabel
		{
			get
			{
				return this.mobjButtonMoveDown.Text;
			}
			set
			{
				this.mobjButtonMoveDown.Text = value;
			}
		}
		
		
		#endregion Properties
		
	}
}
