#region Using

using System;
using System.Xml;
using System.Data;
using System.Drawing;
using System.Collections;
using Gizmox.WebGUI.Forms.Controls;

#endregion Using

namespace Gizmox.WebGUI.Forms.Dialogs
{
	#region ListViewSortingOptions Class
	
	/// <summary>
	///
	/// </summary>

    [Serializable()]
    public class ListViewSortingOptions : Form
	{
		#region Class Members
		
		#region Designer Members
		
		private Label mobjLabelHelp;
		
		private Panel mobjPanelButtons;
		
		private Button mobjButtonCancel;
		
		private Button mobjButtonOK;
		
		private Panel mobjPanelSortingDirection;
		
		private ItemChooser mobjItemChooser;
		
		private RadioButton mobjRadioAscending;
		
		private RadioButton mobjRadioDecsending;
		
		
		#endregion Designer Members
		
		private ListView						mobjListView;
		
		private ColumnHeaderSortingData		mobjSortedColumns;
		
		private Hashtable						mobjChecked;
		
		
		#endregion Class Members
		
		#region C'Tor\D'Tor
		
		/// <summary>
		/// Creates a new <see cref="ListViewSortingOptions"/> instance.
		/// </summary>
		public ListViewSortingOptions(ListView objListView)
		{
			// Set local references.
			mobjListView = objListView;
			
			// Initialize components
			InitializeComponent();
			
			
			// Get sorted columns
			mobjSortedColumns = new ColumnHeaderSortingData(mobjListView);
			
			// Add all columns
			this.mobjItemChooser.Items = mobjSortedColumns.SortedColumns;
			
			// Set selected items
			this.mobjItemChooser.Checked = mobjSortedColumns.SortingColumns;
			
			// Disable the direction panel until item is selected
			this.mobjPanelSortingDirection.Enabled = false;
			
			// Preper the checked hash
			mobjChecked = new Hashtable();
			
			#region Attach Events
			
			// Attach selection event
			this.mobjItemChooser.ItemSelected		+=new EventHandler(mobjItemChooser_ItemSelected);
			this.mobjRadioAscending.CheckedChanged	+=new EventHandler(mobjRadioAscending_CheckedChanged);
			this.mobjRadioDecsending.CheckedChanged	+=new EventHandler(mobjRadioDecsending_CheckedChanged);
			this.mobjButtonCancel.Click				+=new EventHandler(mobjButtonCancel_Click);
			this.mobjButtonOK.Click					+=new EventHandler(mobjButtonOK_Click);
			
			#endregion
			
			this.mobjItemChooser.CheckLabel		= WGLabels.Show;
			this.mobjItemChooser.UncheckLabel	= WGLabels.Hide;

			this.mobjButtonOK.Text = WGLabels.Ok;
			this.mobjButtonCancel.Text = WGLabels.Cancel;
			
			this.mobjButtonOK.Text = WGLabels.Ok;
			this.mobjButtonCancel.Text = WGLabels.Cancel;
            this.Text = SR.GetString(Context.CurrentUICulture, "WGLablesSortingOptions");
            this.mobjLabelHelp.Text = SR.GetString(Context.CurrentUICulture, "WGLablesSortingInstructions");
			
			this.mobjRadioAscending.Text=WGLabels.Ascending;
			this.mobjRadioDecsending.Text=WGLabels.Decsending;

			// Force first updating of sorting direction
			if(this.mobjItemChooser.SelectedItem!=null)
			{
				mobjItemChooser_ItemSelected(this.mobjItemChooser,EventArgs.Empty);
			}
		}
		
		
		#endregion C'Tor\D'Tor
		
		#region Methods
		
		#region Windows Form Designer generated code
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mobjLabelHelp = new Label();
			this.mobjPanelButtons = new Panel();
			this.mobjButtonOK = new Button();
			this.mobjButtonCancel = new Button();
			this.mobjPanelSortingDirection = new Panel();
			this.mobjRadioDecsending = new RadioButton();
			this.mobjRadioAscending = new RadioButton();
			this.mobjItemChooser = new ItemChooser();
			this.mobjPanelButtons.SuspendLayout();
			this.mobjPanelSortingDirection.SuspendLayout();
			this.SuspendLayout();
			//
			// mobjLabelHelp
			//
			this.mobjLabelHelp.Dock = DockStyle.Top;
			this.mobjLabelHelp.Location = new System.Drawing.Point(15, 15);
			this.mobjLabelHelp.Name = "mobjLabelHelp";
			this.mobjLabelHelp.Size = new System.Drawing.Size(312, 49);
			this.mobjLabelHelp.TabIndex = 0;
			this.mobjLabelHelp.Text = "Check the columns that you would like to sort by. Use the Move  Up and Move Down " +
			"buttons to reorder sorting.";
			//
			// mobjPanelButtons
			//
			this.mobjPanelButtons.Controls.Add(this.mobjButtonOK);
			this.mobjPanelButtons.Controls.Add(this.mobjButtonCancel);
			this.mobjPanelButtons.Dock = DockStyle.Bottom;
			this.mobjPanelButtons.Location = new System.Drawing.Point(15, 300);
			this.mobjPanelButtons.Name = "mobjPanelButtons";
			this.mobjPanelButtons.Size = new System.Drawing.Size(312, 35);
			this.mobjPanelButtons.TabIndex = 1;
			//
			// mobjButtonOK
			//
			this.mobjButtonOK.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
			this.mobjButtonOK.Location = new System.Drawing.Point(156, 11);
			this.mobjButtonOK.Name = "mobjButtonOK";
			this.mobjButtonOK.TabIndex = 1;
			this.mobjButtonOK.Text = "OK";
			//
			// mobjButtonCancel
			//
			this.mobjButtonCancel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
			this.mobjButtonCancel.Location = new System.Drawing.Point(236, 11);
			this.mobjButtonCancel.Name = "mobjButtonCancel";
			this.mobjButtonCancel.TabIndex = 0;
			this.mobjButtonCancel.Text = "Cancel";
			//
			// mobjPanelSortingDirection
			//
			this.mobjPanelSortingDirection.Controls.Add(this.mobjRadioDecsending);
			this.mobjPanelSortingDirection.Controls.Add(this.mobjRadioAscending);
			this.mobjPanelSortingDirection.Dock = DockStyle.Bottom;
			this.mobjPanelSortingDirection.Location = new System.Drawing.Point(15, 255);
			this.mobjPanelSortingDirection.Name = "mobjPanelSortingDirection";
			this.mobjPanelSortingDirection.Size = new System.Drawing.Size(312, 45);
			this.mobjPanelSortingDirection.TabIndex = 2;
			//
			// mobjRadioDecsending
			//
			this.mobjRadioDecsending.Location = new System.Drawing.Point(104, 10);
			this.mobjRadioDecsending.Name = "mobjRadioDecsending";
            this.mobjRadioDecsending.Size = new System.Drawing.Size(104, 24);
			this.mobjRadioDecsending.TabIndex = 1;
			this.mobjRadioDecsending.Text = "Decsending";
			//
			// mobjRadioAscending
			//
			this.mobjRadioAscending.Location = new System.Drawing.Point(0, 10);
			this.mobjRadioAscending.Name = "mobjRadioAscending";
            this.mobjRadioAscending.Size = new System.Drawing.Size(104, 24);
			this.mobjRadioAscending.TabIndex = 0;
			this.mobjRadioAscending.Text = "Acsending";
			//
			// mobjItemChooser
			//
			this.mobjItemChooser.Dock = DockStyle.Fill;
			this.mobjItemChooser.Location = new System.Drawing.Point(15, 64);
			this.mobjItemChooser.Name = "mobjItemChooser";
			this.mobjItemChooser.Size = new System.Drawing.Size(320, 191);
			this.mobjItemChooser.TabIndex = 3;
			//
			// ListViewSortingOptions
			//			
			this.ClientSize = new System.Drawing.Size(342, 350);
			this.Controls.Add(this.mobjItemChooser);
			this.Controls.Add(this.mobjPanelSortingDirection);
			this.Controls.Add(this.mobjPanelButtons);
			this.Controls.Add(this.mobjLabelHelp);
			this.DockPadding.All = 15;
			this.Name = "ListViewSortingOptions";
			this.Text = "Sorting Options";
			this.mobjPanelButtons.ResumeLayout(false);
			this.mobjPanelSortingDirection.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		
		
		#endregion Windows Form Designer generated code
		
		#region Events
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjItemChooser_ItemSelected(object sender, EventArgs e)
		{
			ColumnHeader objColumnHeader = this.mobjItemChooser.SelectedItem as ColumnHeader;
			if(objColumnHeader!=null)
			{
				// Enable sorting panel
				this.mobjPanelSortingDirection.Enabled = true;
				
				// Create sort order variable
				SortOrder enmSortOrder = SortOrder.None;
				
				// Get sort order
				if(mobjChecked[objColumnHeader]==null)
				{
					enmSortOrder = objColumnHeader.SortOrder;
				}
				else
				{
					enmSortOrder = (SortOrder)mobjChecked[objColumnHeader];
				}
				
				if(enmSortOrder==SortOrder.None)
				{
					enmSortOrder = SortOrder.Ascending;
				}
				
				// Set radio buttons state
				this.mobjRadioAscending.Checked = (enmSortOrder == SortOrder.Ascending);
				this.mobjRadioDecsending.Checked = (enmSortOrder == SortOrder.Descending);
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjRadioAscending_CheckedChanged(object sender, EventArgs e)
		{
			ColumnHeader objColumnHeader = this.mobjItemChooser.SelectedItem as ColumnHeader;
			if(objColumnHeader!=null)
			{
				if(mobjRadioAscending.Checked)
				{
					mobjChecked[objColumnHeader] = SortOrder.Ascending;
				}
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjRadioDecsending_CheckedChanged(object sender, EventArgs e)
		{
			ColumnHeader objColumnHeader = this.mobjItemChooser.SelectedItem as ColumnHeader;
			if(objColumnHeader!=null)
			{
				if(mobjRadioDecsending.Checked)
				{
					mobjChecked[objColumnHeader] = SortOrder.Descending;
				}
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjButtonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjButtonOK_Click(object sender, EventArgs e)
		{
			
			foreach(ColumnHeader objColumnHeader in this.mobjItemChooser.Items)
			{
				objColumnHeader.SortPosition = 1000;
				
			}
			
			int intIndex = 0;
			foreach(ColumnHeader objColumnHeader in this.mobjItemChooser.Checked)
			{
				// Get sort order
				if(mobjChecked[objColumnHeader]!=null)
				{
					objColumnHeader.SortOrder = (SortOrder)mobjChecked[objColumnHeader];
					
					
				}
				
				if(objColumnHeader.SortOrder==SortOrder.None)
				{
					objColumnHeader.SortOrder = SortOrder.Ascending;
				}
				
				objColumnHeader.SortPosition = intIndex;
				intIndex++;
			}
			
			foreach(ColumnHeader objColumnHeader in this.mobjItemChooser.Items)
			{
				if(objColumnHeader.SortPosition == 1000)
				{
					objColumnHeader.SortOrder = SortOrder.None;
					objColumnHeader.SortPosition = intIndex;
				}
				intIndex++;
			}
			
			this.Close();
			
			
			mobjListView.Sort();
		}
		
		
		#endregion Events
		
		#endregion Methods
		
	}
	
	#endregion ListViewSortingOptions Class
	
}
