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
	#region ListViewColumnOptions Class
	
	/// <summary>
	/// The columens options dialog
	/// </summary>

    [Serializable()]
    public class ListViewColumnOptions : Form
	{
		#region Class Members
		
		private Label mobjLabelHelp;
		
		private Button mobjButtonCancel;
		
		private Button mobjButtonOK;
		
		private Panel mobjPanelButtons;
		
		private Panel mobjPanelColumnWidth;
		
		private Button mobjButtonMoveUp;
		
		private Button mobjButtonMoveDown;
		
		private Button mobjButtonShow;
		
		private Button mobjButtonHide;
		
		private Label mobjLabelWidth1;
		
		private TextBox mobjTextColumnWidth;
		
		private Label mobjLabelWidth2;
		
		private ItemChooser mobjItemChooser;
		
		private ListView.ColumnHeaderCollection mobjColumns;
		
		private ListView						mobjListView;
		
		private Hashtable						mobjColumnWidth;
		
		
		#endregion Class Members
		
		#region C'Tor\D'Tor
		
		/// <summary>
		/// Creates a new <see cref="ListViewColumnOptions"/> instance.
		/// </summary>
		/// <param name="objListView">List view.</param>
		public ListViewColumnOptions(ListView objListView)
		{
			// Set local references.
			mobjListView = objListView;
			
			// Initialize components
			InitializeComponent();
			
			// Set local references
			mobjListView	= objListView;
			mobjColumns		= objListView.Columns;
			mobjColumnWidth = new Hashtable();
			
			
			
			// Add all columns
			mobjItemChooser.Items = mobjColumns.SortedColumns;
			
			// Set selected items
			mobjItemChooser.Checked = mobjColumns.VisibleColumns;
			
			try
			{
				mobjTextColumnWidth.Text = GetColumnWidth((ColumnHeader)mobjItemChooser.SelectedItem);
			}
			catch(Exception)
			{
			}
			
			
			
			#region Attach Events
			
			// Attach selection event
			this.mobjItemChooser.ItemSelected		+=new EventHandler(mobjItemChooser_ItemSelected);
			
			this.mobjButtonCancel.Click				+=new EventHandler(mobjButtonCancel_Click);
			this.mobjButtonOK.Click					+=new EventHandler(mobjButtonOK_Click);
			
			#endregion
			
			this.mobjItemChooser.CheckLabel		= WGLabels.Show;
			this.mobjItemChooser.UncheckLabel	= WGLabels.Hide;
			this.mobjItemChooser.MoveDownLabel	= WGLabels.MoveDown;
			this.mobjItemChooser.MoveUpLabel	= WGLabels.MoveUp;
			
			
			this.mobjButtonOK.Text = WGLabels.Ok;
			this.mobjButtonCancel.Text = WGLabels.Cancel;
            this.Text = SR.GetString(Context.CurrentUICulture, "WGLablesColumnOptions");
			this.mobjLabelHelp.Text = SR.GetString(Context.CurrentUICulture, "WGLablesColumnsInstructions");
            this.mobjLabelWidth1.Text = SR.GetString(Context.CurrentUICulture, "WGLablesColumnsStringA");
			this.mobjLabelWidth2.Text = SR.GetString(Context.CurrentUICulture, "WGLablesColumnsStringB");
			
			
			this.mobjTextColumnWidth.TextChanged		+= new EventHandler(mobjTextColumnWidth_TextChanged);
			
			
			
		}
		
		
		#endregion C'Tor\D'Tor
		
		#region Methods
		
		#region Initialize Component
		
		/// <summary>
		/// Initializes the component.
		/// </summary>
		private void InitializeComponent()
		{
			this.mobjLabelHelp = new Label();
			this.mobjPanelButtons = new Panel();
			this.mobjButtonCancel = new Button();
			this.mobjButtonOK = new Button();
			this.mobjPanelColumnWidth = new Panel();
			this.mobjLabelWidth1 = new Label();
			this.mobjTextColumnWidth = new TextBox();
			this.mobjLabelWidth2 = new Label();
			this.mobjItemChooser = new ItemChooser();
			this.mobjPanelColumnWidth.SuspendLayout();
			this.mobjPanelButtons.SuspendLayout();
			this.SuspendLayout();
			
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
			// mobjLabelHelp
			//
			
			this.mobjLabelHelp.Dock = DockStyle.Top;
			this.mobjLabelHelp.Location = new System.Drawing.Point(15, 15);
			this.mobjLabelHelp.Name = "mobjLabelHelp";
			this.mobjLabelHelp.Size = new System.Drawing.Size(312, 49);
			this.mobjLabelHelp.TabIndex = 0;
			this.mobjLabelHelp.Text = "Check the columns that you would like to make visible. Use the Move  Up and Move " +
			"Down buttons to reorder the columns.";
			
			//
			// mobjButtonCancel
			//
			this.mobjButtonCancel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
			this.mobjButtonCancel.Location = new System.Drawing.Point(236, 11);
			this.mobjButtonCancel.Name = "mobjButtonCancel";
			this.mobjButtonCancel.TabIndex = 0;
			this.mobjButtonCancel.Text = "Cancel";
			//
			// mobjButtonOK
			//
			this.mobjButtonOK.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
			this.mobjButtonOK.Location = new System.Drawing.Point(156, 11);
			this.mobjButtonOK.Name = "mobjButtonOK";
			this.mobjButtonOK.TabIndex = 1;
			this.mobjButtonOK.Text = "OK";
			//
			// mobjPanelColumnWidth
			//
			this.mobjPanelColumnWidth.Controls.Add(this.mobjLabelWidth2);
			this.mobjPanelColumnWidth.Controls.Add(this.mobjTextColumnWidth);
			this.mobjPanelColumnWidth.Controls.Add(this.mobjLabelWidth1);
			this.mobjPanelColumnWidth.Dock = DockStyle.Bottom;
			this.mobjPanelColumnWidth.Location = new System.Drawing.Point(15, 255);
			this.mobjPanelColumnWidth.Name = "mobjPanelColumnWidth";
			this.mobjPanelColumnWidth.Size = new System.Drawing.Size(312, 45);
			this.mobjPanelColumnWidth.TabIndex = 2;
			//
			// mobjItemChooser
			//
			this.mobjItemChooser.Dock = DockStyle.Fill;
			this.mobjItemChooser.Location = new System.Drawing.Point(15, 64);
			this.mobjItemChooser.Name = "mobjItemChooser";
			this.mobjItemChooser.Size = new System.Drawing.Size(320, 191);
			this.mobjItemChooser.TabIndex = 3;
			//
			// mobjLabelWidth1
			//
			this.mobjLabelWidth1.Location = new System.Drawing.Point(8, 16);
			this.mobjLabelWidth1.Name = "mobjLabelWidth1";
			this.mobjLabelWidth1.Size = new System.Drawing.Size(168, 16);
			this.mobjLabelWidth1.TabIndex = 0;
			this.mobjLabelWidth1.Text = "The selected column should be";
			//
			// mobjTextColumnWidth
			//
			this.mobjTextColumnWidth.Location = new System.Drawing.Point(166, 13);
			this.mobjTextColumnWidth.Name = "mobjTextColumnWidth";
			this.mobjTextColumnWidth.Size = new System.Drawing.Size(32, 20);
			this.mobjTextColumnWidth.TabIndex = 1;
			this.mobjTextColumnWidth.Text = "";
			//
			// mobjLabelWidth2
			//
			this.mobjLabelWidth2.Location = new System.Drawing.Point(208, 16);
			this.mobjLabelWidth2.Name = "mobjLabelWidth2";
			this.mobjLabelWidth2.Size = new System.Drawing.Size(100, 16);
			this.mobjLabelWidth2.TabIndex = 2;
			this.mobjLabelWidth2.Text = "pixels wide.";
			//
			// ListViewColumnOptions
			//			
			this.ClientSize = new System.Drawing.Size(342, 350);
			
			this.Controls.Add(this.mobjItemChooser);
			this.Controls.Add(this.mobjPanelColumnWidth);
			this.Controls.Add(this.mobjPanelButtons);
			this.Controls.Add(this.mobjLabelHelp);
			this.DockPadding.All = 15;
			this.Name = "ListViewColumnOptions";
			this.Text = "ListViewColumnOptions";
			this.mobjPanelButtons.ResumeLayout(false);
			this.mobjPanelColumnWidth.ResumeLayout(false);
			this.mobjPanelButtons.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		
		
		#endregion Initialize Component
		
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
		/// Handle OK button click
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjButtonOK_Click(object sender, EventArgs e)
		{
			int intIndex = 0;
			
			ArrayList objChecked = new ArrayList(mobjItemChooser.Checked);
			
			// Loop all headers
			foreach(ColumnHeader objColumn in mobjItemChooser.Items)
			{
				// if width was changed
				if(mobjColumnWidth[objColumn]!=null)
				{
					objColumn.Width = int.Parse((string)mobjColumnWidth[objColumn]);
				}
				
				
				// Set column visibility
				objColumn.Visible = objChecked.Contains(objColumn);
				
				// Reorder column header
				objColumn.DisplayIndexInternal = intIndex;
				
				// increment index
				intIndex++;
			}
			
			mobjColumns.UpdateColumns();
			
			this.Close();
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjItemChooser_ItemSelected(object sender, EventArgs e)
		{
			mobjTextColumnWidth.Text = GetColumnWidth((ColumnHeader)mobjItemChooser.SelectedItem);
			
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mobjTextColumnWidth_TextChanged(object sender, EventArgs e)
		{
			ColumnHeader objColumnHeader = (ColumnHeader)mobjItemChooser.SelectedItem;
			
			string strColumnWidth = mobjTextColumnWidth.Text;
			try
			{
				int intColumnWidth = int.Parse(strColumnWidth);
				mobjColumnWidth[objColumnHeader] = intColumnWidth.ToString();
			}
			catch(Exception)
			{
				mobjTextColumnWidth.Text = GetColumnWidth(objColumnHeader);
			}
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objColumnHeader"></param>
		private string GetColumnWidth(ColumnHeader objColumnHeader)
		{
			if(mobjColumnWidth[objColumnHeader]!=null)
			{
				return (string)mobjColumnWidth[objColumnHeader];
			}
			else
			{
				return objColumnHeader.Width.ToString();
			}
		}
		
		
		#endregion Events
		
		#endregion Methods
		
	}
	
	#endregion ListViewColumnOptions Class
	
}
