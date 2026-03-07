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
	#region ListViewGroupingOptions Class
	
	/// <summary>
	///
	/// </summary>

    [Serializable()]
    public class ListViewGroupingOptions : Form
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
		
		private Hashtable						mobjChecked;
		
		private ColumnHeaderGroupingData		mobjGroupedColumns;
		
		
		#endregion Class Members
		
		#region C'Tor\D'Tor
		
		/// <summary>
		/// Creates a new <see cref="ListViewGroupingOptions"/> instance.
		/// </summary>
		public ListViewGroupingOptions(ListView objListView)
		{
			// Set local references.
			mobjListView = objListView;
			
			// Initialize components
			InitializeComponent();
			
			
			
			// Get grouped columns
			mobjGroupedColumns = new ColumnHeaderGroupingData(mobjListView);
			
			// Add all columns
			this.mobjItemChooser.Items = mobjGroupedColumns.SortedColumns;
			
			// Set selected items
			this.mobjItemChooser.Checked = mobjGroupedColumns.GroupingColumns;
			
			// Preper the checked hash
			mobjChecked = new Hashtable();
			
			#region Attach Events
			
			// Attach selection event
			this.mobjButtonCancel.Click				+=new EventHandler(mobjButtonCancel_Click);
			this.mobjButtonOK.Click					+=new EventHandler(mobjButtonOK_Click);
			
			#endregion
			
			this.mobjItemChooser.CheckLabel		= WGLabels.Show;
			this.mobjItemChooser.UncheckLabel	= WGLabels.Hide;
			this.mobjItemChooser.MoveDownLabel	= WGLabels.MoveDown;
			this.mobjItemChooser.MoveUpLabel	= WGLabels.MoveUp;
			this.mobjButtonOK.Text = WGLabels.Ok;
			this.mobjButtonCancel.Text = WGLabels.Cancel;
            this.mobjLabelHelp.Text = SR.GetString(Context.CurrentUICulture, "WGLablesGroupingInstructions");
            this.Text = SR.GetString(Context.CurrentUICulture, "WGLablesGroupingOptions");
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
			this.mobjLabelHelp.Text = "Check the columns that you would like to group by. Use the Move  Up and Move Down" +
			" buttons to reorder grouping order.";
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
			// mobjItemChooser
			//
			this.mobjItemChooser.Dock = DockStyle.Fill;
			this.mobjItemChooser.Location = new System.Drawing.Point(15, 64);
			this.mobjItemChooser.Name = "mobjItemChooser";
			this.mobjItemChooser.Size = new System.Drawing.Size(320, 191);
			this.mobjItemChooser.TabIndex = 3;
			//
			// ListViewGroupingOptions
			//			
			this.ClientSize = new System.Drawing.Size(342, 350);
			this.Controls.Add(this.mobjItemChooser);
			this.Controls.Add(this.mobjPanelButtons);
			this.Controls.Add(this.mobjLabelHelp);
			this.DockPadding.All = 15;
			this.Name = "ListViewGroupingOptions";
			this.Text = "Grouping Options";
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
				objColumnHeader.GroupByPosition = 1000;
				
			}
			
			int intIndex = 0;
			foreach(ColumnHeader objColumnHeader in this.mobjItemChooser.Checked)
			{
				
				objColumnHeader.GroupBy = true;
				objColumnHeader.GroupByPosition = intIndex;
				intIndex++;
			}
			
			foreach(ColumnHeader objColumnHeader in this.mobjItemChooser.Items)
			{
				if(objColumnHeader.GroupByPosition == 1000)
				{
					objColumnHeader.GroupBy = false;
					objColumnHeader.GroupByPosition = intIndex;
				}
				intIndex++;
			}
			
			this.Close();
			
			mobjListView.FireGroup();
			
		}
		
		
		#endregion Events
		
		#endregion Methods
		
	}
	
	#endregion ListViewGroupingOptions Class
	
}
