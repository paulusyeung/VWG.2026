#region Using

using System;
using System.Xml;
using System.Data;
using System.Drawing;
using System.Collections;
using Gizmox.WebGUI.Forms;

#endregion Using

namespace Gizmox.WebGUI.Forms.Controls
{
	#region ItemChooser Class
	
	/// <summary>
	///
	/// </summary>
    [System.ComponentModel.ToolboxItem(false), Serializable()]
	
	public class ItemChooser : UserControl
	{
		#region Class Members
		
		#region Designer Members
		
		private Button mobjButtonMoveUp;
		
		private Button mobjButtonMoveDown;
		
		private Button mobjButtonShow;
		
		private Panel mobjPanelButtons;
		
		private Button mobjButtonHide;
		
		private CheckedListBox mobjListItems;
		
		
		#endregion Designer Members
		
		/// <summary>
		/// Occurs when an item is selected
		/// </summary>
		public event EventHandler ItemSelected;
		
		/// <summary>
		/// Occurs when an item is checked
		/// </summary>
		public event ItemCheckHandler ItemCheck;
		
		
		#endregion Class Members
		
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
			this.mobjListItems.ItemCheck+=new ItemCheckHandler(mobjListItems_ItemCheck);
			
			#endregion
			
			this.mobjButtonHide.Text = WGLabels.Hide;
			this.mobjButtonMoveDown.Text = WGLabels.MoveDown;
			this.mobjButtonMoveUp.Text = WGLabels.MoveUp;
			this.mobjButtonShow.Text = WGLabels.Show;
			this.mobjListItems.DisplayMember = "Text";
		}
		
		
		#endregion C'Tor\D'Tor
		
		#region Methods
		
		#region Component Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mobjListItems = new CheckedListBox();
			this.mobjPanelButtons = new Panel();
			this.mobjButtonMoveUp = new Button();
			this.mobjButtonMoveDown = new Button();
			this.mobjButtonShow = new Button();
			this.mobjButtonHide = new Button();
            this.mobjPanelButtons.SuspendLayout();
			this.SuspendLayout();
			//
			// mobjListItems
			//
            this.mobjListItems.Dock = DockStyle.Fill;
            this.mobjListItems.Location = new System.Drawing.Point(0, 0);
			this.mobjListItems.Name = "mobjListItems";
            this.mobjListItems.Size = new System.Drawing.Size(821, 454);
			this.mobjListItems.TabIndex = 0;
			//
            // mobjPanelButtons
			//
            this.mobjPanelButtons.Controls.Add(this.mobjButtonHide);
            this.mobjPanelButtons.Controls.Add(this.mobjButtonShow);
            this.mobjPanelButtons.Controls.Add(this.mobjButtonMoveDown);
            this.mobjPanelButtons.Controls.Add(this.mobjButtonMoveUp);
            this.mobjPanelButtons.Dock = DockStyle.Right;
            this.mobjPanelButtons.Location = new System.Drawing.Point(710, 0);
            this.mobjPanelButtons.Name = "mobjPanelButtons";
            this.mobjPanelButtons.Size = new System.Drawing.Size(111, 454);
            this.mobjPanelButtons.TabIndex = 1;
            // 
            // mobjButtonHide
            // 
            this.mobjButtonHide.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this.mobjButtonHide.Location = new System.Drawing.Point(4, 87);
            this.mobjButtonHide.Name = "mobjButtonHide";
            this.mobjButtonHide.Size = new System.Drawing.Size(103, 23);
            this.mobjButtonHide.TabIndex = 3;
            this.mobjButtonHide.Text = "Hide";
            // 
            // mobjButtonShow
            // 
            this.mobjButtonShow.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this.mobjButtonShow.Location = new System.Drawing.Point(4, 58);
            this.mobjButtonShow.Name = "mobjButtonShow";
            this.mobjButtonShow.Size = new System.Drawing.Size(103, 23);
            this.mobjButtonShow.TabIndex = 2;
            this.mobjButtonShow.Text = "Show";
            // 
            // mobjButtonMoveDown
            // 
            this.mobjButtonMoveDown.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this.mobjButtonMoveDown.Location = new System.Drawing.Point(4, 29);
            this.mobjButtonMoveDown.Name = "mobjButtonMoveDown";
            this.mobjButtonMoveDown.Size = new System.Drawing.Size(103, 23);
            this.mobjButtonMoveDown.TabIndex = 1;
            this.mobjButtonMoveDown.Text = "Move Down";
            // 
            // mobjButtonMoveUp
            // 
            this.mobjButtonMoveUp.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            this.mobjButtonMoveUp.Location = new System.Drawing.Point(4, 0);
            this.mobjButtonMoveUp.Name = "mobjButtonMoveUp";
            this.mobjButtonMoveUp.Size = new System.Drawing.Size(103, 23);
            this.mobjButtonMoveUp.TabIndex = 0;
            this.mobjButtonMoveUp.Text = "Move Up";
			//
			// ItemChooser
			//
            this.Controls.Add(this.mobjListItems);
            this.Controls.Add(this.mobjPanelButtons);
            this.Name = "ItemChooser";
			this.Size = new System.Drawing.Size(320, 190);
            this.mobjPanelButtons.ResumeLayout(false);
			this.ResumeLayout(false);			
		}
		
		
		#endregion Component Designer generated code
		
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
				this.mobjListItems.SwapItems(mobjListItems.SelectedIndex,mobjListItems.SelectedIndex-1);
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
				this.mobjListItems.SwapItems(mobjListItems.SelectedIndex,mobjListItems.SelectedIndex+1);
			}
			
			UpdateButtonsState();
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
		private void mobjListItems_ItemCheck(object objSender, ItemCheckEventArgs objArgs)
		{
			if(ItemCheck!=null) ItemCheck(objSender,objArgs);
			
			UpdateButtonsState();
		}
		
		
		#endregion Events
		
		#endregion Methods
		
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
				this.mobjListItems.Items.AddRange(value);
				if(this.mobjListItems.Items.Count>0)
				{
					this.mobjListItems.SelectedIndex=0;
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
				foreach(object objObject in this.mobjListItems.Items)
				{
					// Get item index
					int intIndex = this.mobjListItems.Items.IndexOf(objObject);
					if(intIndex!=-1)
					{
						// If item checked state
						if(this.mobjListItems.GetItemChecked(intIndex))
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
				foreach(object objObject in value)
				{
					// Get item index
					int intIndex = this.mobjListItems.Items.IndexOf(objObject);
					if(intIndex!=-1)
					{
						// Set item checked state
						this.mobjListItems.SetItemChecked(intIndex,true);
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
	
	#endregion ItemChooser Class
	
}
