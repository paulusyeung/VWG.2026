using System;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.OleDb;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;


namespace Gizmox.WebGUI.Forms.Catalog.Categories.DataControls
{
	/// <summary>
	/// Summary description for DataGridViewControl.
	/// </summary>

    [Serializable()]
    public class CustomDataGridViewControl : UserControl, IHostedApplication
	{
        #region Classes

        #region DataGridViewCustomComboBoxForm

        /// <summary>
        /// 
        /// </summary>
        public class DataGridViewCustomComboBoxForm : Form
        {
            private int mintIndex = 1;

            private RandomData mobjRandomData = null;

            private DataGridViewCustomComboBoxCell mobjHandledDataGridViewCell = null;

            /// <summary>
            /// Gets or sets the handled data grid view cell.
            /// </summary>
            /// <value>The handled data grid view cell.</value>
            public DataGridViewCustomComboBoxCell HandledDataGridViewCell
            {
                get
                {
                    return mobjHandledDataGridViewCell;
                }
                set
                {
                    mobjHandledDataGridViewCell = value;
                }
            }

            /// <summary>
            /// Gets the critical events.
            /// </summary>
            /// <returns></returns>
            protected override CriticalEventsData GetCriticalEventsData()
            {
                // Set closed event critical
                CriticalEventsData objEvents = base.GetCriticalEventsData();
                objEvents.Set(WGEvents.Closed);
                return objEvents;
            }

            /// <summary>
            /// Raises the <see cref="E:Closed"/> event.
            /// </summary>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            protected override void OnClosed(EventArgs e)
            {
                base.OnClosed(e);

                // Check cell is not null
                if (this.HandledDataGridViewCell != null)
                {
                    // Update cell
                    this.HandledDataGridViewCell.Update();
                    
                    // Get gridview
                    DataGridView objDataGridView = this.HandledDataGridViewCell.DataGridView;
                    if (objDataGridView != null)
                    {
                        // Get row
                        DataGridViewRow objDataGridViewRow = this.HandledDataGridViewCell.OwningRow;
                        if (objDataGridViewRow != null)
                        {
                            // Get grid id
                            string strGridId = objDataGridView.ID.ToString();

                            // Redraw row (remove edit mode indicator)
                            this.InvokeMethod("DataGridView_RedrawRowHeaderByID", strGridId, string.Format("{0}_R{1}", strGridId, objDataGridViewRow.Index));
                        }
                    }
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="DataGridViewCustomComboBoxForm"/> class.
            /// </summary>
            /// <param name="objHandledDataGridViewCell">The obj handled data grid view cell.</param>
            public DataGridViewCustomComboBoxForm(DataGridViewCustomComboBoxCell objHandledDataGridViewCell)
            {
                mobjHandledDataGridViewCell = objHandledDataGridViewCell;

                mobjRandomData = new RandomData();

                TreeView objTreeView = new TreeView();
                objTreeView.Dock = DockStyle.Fill;

                AddNodes(objTreeView.Nodes, 5);

                this.Controls.Add(objTreeView);

                objTreeView.AfterSelect += new TreeViewEventHandler(objTreeView_AfterSelect);
            }

            /// <summary>
            /// Handles the AfterSelect event of the objTreeView control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
            private void objTreeView_AfterSelect(object sender, TreeViewEventArgs e)
            {
                if (this.HandledDataGridViewCell != null)
                {
                    TreeView objTreeView = sender as TreeView;
                    if (objTreeView != null && objTreeView.SelectedNode != null)
                    {
                        this.HandledDataGridViewCell.SetDropDownValue(objTreeView.SelectedNode.Text);
                    }
                }

                this.Close();
            }

            /// <summary>
            /// Adds the nodes.
            /// </summary>
            /// <param name="objNodes">The obj nodes.</param>
            /// <param name="intCount">The int count.</param>
            private void AddNodes(TreeNodeCollection objNodes, int intCount)
            {
                for (int intIndex = 0; intIndex < intCount; intIndex++)
                {
                    this.AddNode(objNodes, intCount);
                }
            }

            /// <summary>
            /// Adds the node.
            /// </summary>
            /// <param name="objNodes">The obj nodes.</param>
            /// <param name="intCount">The int count.</param>
            private void AddNode(TreeNodeCollection objNodes, int intCount)
            {
                TreeNode objTreeNode = new TreeNode();
                objTreeNode.Label = "Node " + mintIndex.ToString();
                objTreeNode.Image = new IconResourceHandle("Folder.gif");
                objTreeNode.IsExpanded = false;
                objNodes.Add(objTreeNode);
                mintIndex++;

                if (intCount > 1)
                {
                    this.AddNodes(objTreeNode.Nodes, this.mobjRandomData.GetInteger(0, intCount - 1));
                }
            }

            /// <summary>
            /// Renders the forms attribute
            /// </summary>
            /// <param name="objContext"></param>
            /// <param name="objWriter"></param>
            protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
            {
                base.RenderAttributes(objContext, objWriter);

                // Render share focus
                objWriter.WriteAttributeString(WGAttributes.ShareFocus, "1");

            }
        }

         #endregion

        #region DataGridViewCustomComboBoxCell

        /// <summary>
        /// 
        /// </summary>
        public class DataGridViewCustomComboBoxCell : DataGridViewComboBoxCell
        {
            /// <summary>
            /// Gets a value indicating whether this instance has a custom drop down.
            /// </summary>
            /// <value>
            /// 	<c>true</c> if this instance has a custom drop down; otherwise, <c>false</c>.
            /// </value>
            protected override bool IsCustomDropDown
            {
                get
                {
                    return true;
                }
            }

            /// <summary>
            /// Gets the custom form to display as drop down
            /// </summary>
            /// <returns></returns>
            protected override Form GetCustomDropDown()
            {
                Form objCustomDropDown = null;

                if (this.OwningColumn != null && this.OwningColumn is DataGridViewCustomComboBoxColumn)
                {
                    objCustomDropDown = ((DataGridViewCustomComboBoxColumn)this.OwningColumn).GetCustomDropDown(this.RowIndex);
                }

                return objCustomDropDown;
            }

            /// <summary>
            /// Render the control Attributes
            /// </summary>
            /// <param name="objContext"></param>
            /// <param name="objWriter"></param>
            /// <param name="blnRenderOwner"></param>
            protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
            {
                base.RenderAttributes(objContext, objWriter, blnRenderOwner);

                if (this.Value != null)
                {
                    objWriter.WriteAttributeString(WGAttributes.Text, this.Value.ToString());
                }
            }

            /// <summary>
            /// Sets the drop down value.
            /// </summary>
            /// <param name="objValue">The obj value.</param>
            public void SetDropDownValue(object objValue)
            {
                this.Value = objValue;
            }

            /// <summary>
            /// Gets the formatted value of the cell's data.
            /// </summary>
            /// <param name="value">The value to be formatted.</param>
            /// <param name="rowIndex">The index of the cell's parent row.</param>
            /// <param name="cellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell.</param>
            /// <param name="valueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the value type that provides custom conversion to the formatted value type, or null if no such custom conversion is needed.</param>
            /// <param name="formattedValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the formatted value type that provides custom conversion from the value type, or null if no such custom conversion is needed.</param>
            /// <param name="context">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values describing the context in which the formatted value is needed.</param>
            /// <returns>
            /// The value of the cell's data after formatting has been applied or null if the cell is not part of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.
            /// </returns>
            /// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see> for type conversion errors or to type <see cref="T:System.ArgumentException"></see> if value cannot be found in the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> or the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.Items"></see> collection. </exception>
            protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
            {
                return value;
            }
        }

        #endregion

        #region DataGridViewCustomComboBoxColumn

        /// <summary>
        /// 
        /// </summary>
        [Serializable()]
        public class DataGridViewCustomComboBoxColumn : DataGridViewComboBoxColumn
        {
            #region C'tor / D'tor

            /// <summary>
            /// Initializes a new instance of the <see cref="DataGridViewCustomComboBoxColumn"/> class.
            /// </summary>
            public DataGridViewCustomComboBoxColumn() : base(new DataGridViewCustomComboBoxCell())
            {
            }

            #endregion

            #region Properties

            #endregion Properties

            #region Delegates and Events

            /// <summary>
            /// 
            /// </summary>
            public delegate void RetrieveCustomDropDownHandler(object objSender, CustomDropDownArgs objArgs);

            /// <summary>
            /// Occurs when [retrieve custom drop down].
            /// </summary>
            public event RetrieveCustomDropDownHandler RetrieveCustomDropDown;


            #endregion Delegates and Events

            #region Methods

            /// <summary>
            /// Gets the custom drop down.
            /// </summary>
            /// <returns></returns>
            internal Form GetCustomDropDown(int intRowIndex)
            {
                // check if event is registered.
                if (this.RetrieveCustomDropDown != null)
                {
                    // Create a new event arguments.
                    CustomDropDownArgs objCustomDropDownArgs = new CustomDropDownArgs(intRowIndex);

                    // Raise the RetrieveCustomDropDown event.
                    this.RetrieveCustomDropDown(this, objCustomDropDownArgs);

                    // Return the retrieved custom drop down form.
                    return objCustomDropDownArgs.CustomDropDownForm;
                }

                return null;
            }


            #endregion Methods

            #region Nested Classes


            /// <summary>
            /// 
            /// </summary>
            public class CustomDropDownArgs : EventArgs
            {

                #region Fields

                private Form mobjCustomDropDownForm = null;
                private int mintRowIndex = -1;

                #endregion Fields

                #region Properties

                /// <summary>
                /// Gets or sets the index of the row.
                /// </summary>
                /// <value>The index of the row.</value>
                public int RowIndex
                {
                    get
                    {
                        return mintRowIndex;
                    }
                    set
                    {
                        mintRowIndex = value;
                    }
                }

                /// <summary>
                /// Gets or sets the custom drop down form.
                /// </summary>
                /// <value>The custom drop down form.</value>
                public Form CustomDropDownForm
                {
                    get
                    {
                        return mobjCustomDropDownForm;
                    }
                    set
                    {
                        mobjCustomDropDownForm = value;
                    }
                }

                #endregion Properties

                #region C'tor / D'tor

                /// <summary>
                /// Initializes a new instance of the <see cref="CustomDropDownArgs"/> class.
                /// </summary>
                /// <param name="intRowIndex">Index of the int row.</param>
                public CustomDropDownArgs(int intRowIndex)
                {
                    mintRowIndex = intRowIndex;
                }

                #endregion

            }

            #endregion Nested Classes

        }

        #endregion

        #endregion

        #region Members

        private DataGridView dataGridView1;
        private DataGridViewButtonColumn Column1;
        private DataGridViewCheckBoxColumn Column2;
        private DataGridViewComboBoxColumn Column3;
        private DataGridViewImageColumn Column4;
        private DataGridViewLinkColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewLinkColumn Column7;
        private DataGridViewCustomComboBoxColumn Column8;
        private bool mblnCellContentClickEnabled = false;


        /// <summary> 
        /// Required designer variable.
        /// </summary>
        [NonSerialized]
        private System.ComponentModel.Container components = null; 

        #endregion

        #region C'tor / D'tor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomDataGridViewControl"/> class.
        /// </summary>
        public CustomDataGridViewControl()
        {
            // This call is required by the WebGUI Form Designer.
            InitializeComponent();

            // Add rows to dataGridView1.
            this.dataGridView1.Rows.Add("My Button1", true, "aaa1", new ImageResourceHandle("Background.jpg"), "My Link1", "My Text1", "Contact support", null);
            this.dataGridView1.Rows.Add("My Button2", false, "aaa2", new ImageResourceHandle("Background.jpg"), "My Link2", "My Text2", "www.visualwebgui.com", null);
            this.dataGridView1.Rows.Add("My Button3", true, "aaa3", new ImageResourceHandle("Background.jpg"), "My Link3", "My Text3", "Contact support", null);
            this.dataGridView1.Rows.Add("My Button4", false, "aaa1", new ImageResourceHandle("Background.jpg"), "My Link4", "My Text4", "www.visualwebgui.com", null);
            this.dataGridView1.Rows.Add("My Button5", true, "aaa2", new ImageResourceHandle("Background.jpg"), "My Link5", "My Text5", "Contact support", null);

            // Change url's to rows 1 and 3.
            ((DataGridViewLinkCell)this.dataGridView1.Rows[1].Cells["Column7"]).Url = "http://www.visualwebgui.com";
            ((DataGridViewLinkCell)this.dataGridView1.Rows[3].Cells["Column7"]).Url = "http://www.visualwebgui.com";
            ((DataGridViewLinkCell)this.dataGridView1.Rows[1].Cells["Column7"]).ClientMode = true;
            ((DataGridViewLinkCell)this.dataGridView1.Rows[3].Cells["Column7"]).ClientMode = true;

            //dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        } 

        #endregion

		#region Component Designer generated code
		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.dataGridView1 = new Gizmox.WebGUI.Forms.DataGridView();
            this.Column1 = new Gizmox.WebGUI.Forms.DataGridViewButtonColumn();
            this.Column2 = new Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn();
            this.Column3 = new Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn();
            this.Column4 = new Gizmox.WebGUI.Forms.DataGridViewImageColumn();
            this.Column5 = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.Column6 = new Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new Gizmox.WebGUI.Forms.DataGridViewLinkColumn();
            this.Column8 = new DataGridViewCustomComboBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new Gizmox.WebGUI.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridView1.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(575, 200);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.Swipe += new SwipeEventHandler(dataGridView1_Swipe);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Buttons";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Check Boxes";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Combo Boxes";
            this.Column3.Items.AddRange(new object[] {
            "aaa1",
            "aaa2",
            "aaa3",
            "aaa4",
            "aaa5",
            "aaa6",
            "aaa7",
            "aaa8",
            "aaa9",
            "aaa10"});
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Images";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Server Links";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Text Boxes";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Client Links";
            this.Column7.Name = "Column7";
            this.Column7.Url = "mailto:support@gizmox.com";
            this.Column7.Width = 140;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Custom ComboBox";
            this.Column8.Name = "Column8";
            this.Column8.RetrieveCustomDropDown += new DataGridViewCustomComboBoxColumn.RetrieveCustomDropDownHandler(Column8_RetrieveCustomDropDown);
			// 
			// DataGridViewControl
			// 
			this.ClientSize = new System.Drawing.Size(640, 600);
			this.Controls.Add(this.dataGridView1);
			this.DockPadding.All = 0;
			this.DockPadding.Bottom = 0;
			this.DockPadding.Left = 0;
			this.DockPadding.Right = 0;
			this.DockPadding.Top = 0;
			this.Size = new System.Drawing.Size(640, 600);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);

		}

        void dataGridView1_Swipe(Component objSource, SwipeDirection enmSwipeDirection)
        {
            if (dataGridView1.CurrentRow != null)
            {
                MessageBox.Show(string.Format("{0} swipe on row number {1}", enmSwipeDirection.ToString(), dataGridView1.CurrentRow.Index));
            }
        }

        /// <summary>
        /// Handles the CellContentClick event of the dataGridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
        void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                Link.Open(@"http://www.visualwebgui.com");
            }
        }

        /// <summary>
        /// Column8_s the retrieve custom drop down.
        /// </summary>
        /// <param name="objSender">The obj sender.</param>
        /// <param name="objArgs">The obj args.</param>
        void Column8_RetrieveCustomDropDown(object objSender, DataGridViewCustomComboBoxColumn.CustomDropDownArgs objArgs)
        {
            objArgs.CustomDropDownForm = new DataGridViewCustomComboBoxForm( this.dataGridView1[Column8.Index, objArgs.RowIndex] as DataGridViewCustomComboBoxCell);
            objArgs.CustomDropDownForm.Height = 200;
        }

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (this.IsRegistered)
            {
                MessageBox.Show(e.ColumnIndex.ToString() + " , " + e.RowIndex.ToString());
            }
        }

		#endregion

		#region IHostedApplication Members

		public void InitializeApplication()
		{
			// TODO:  Add DataGridViewControl.InitializeApplication implementation
		}

		public HostedToolBarElement[] GetToolBarElements()
		{
			ArrayList objElements = new ArrayList();
            objElements.Add(new HostedToolBarButton("Enable/Disable content click event", new IconResourceHandle("Event.gif"), "EnableContentClick"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Copy", new IconResourceHandle("Copy.gif"), "Copy"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Properties", new IconResourceHandle("Properties.gif"), "Properties"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("Help", new IconResourceHandle("Help.gif"), "Help"));
            objElements.Add(new HostedToolBarSeperator());
            objElements.Add(new HostedToolBarButton("ReadOnly", new IconResourceHandle("ImportantMail.gif"), "ReadOnly"));

			return (HostedToolBarElement[])objElements.ToArray(typeof(HostedToolBarElement));
		}

		public void OnToolBarButtonClick(HostedToolBarButton objButton, EventArgs objEvent)
		{
			string strAction = (string)objButton.Tag;
			switch(strAction)
			{
                case "ReadOnly":
                    foreach (DataGridViewColumn objCol in dataGridView1.Columns)
                    {
                        objCol.ReadOnly = !objCol.ReadOnly;
                    }
                    break;
                case "EnableContentClick":
                    if (mblnCellContentClickEnabled)
                    {
                        this.dataGridView1.CellContentClick -= new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
                    }
                    else
                    {
                        this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
                    }
                    this.dataGridView1.Update();

                    mblnCellContentClickEnabled = !mblnCellContentClickEnabled;
                    break;
				case "Copy":
                    // Copy the clipboard content to the clipboard
                    Clipboard.SetDataObject(this.dataGridView1.GetClipboardContent(TextDataFormat.Html));
                    // Send to client and clear clipboard
                    Clipboard.Update(TextDataFormat.Html);
                    break;
                case "Properties":
                    InspectorForm objInspectorForm = new InspectorForm();
                    objInspectorForm.SetControls(this.dataGridView1);
                    objInspectorForm.ShowDialog();
                    break;
                case "Help":
                    Help.ShowHelp(this, CatalogSettings.ProjectCHM, HelpNavigator.KeywordIndex, "DataGridView class");
                    break;
			}
		}

		#endregion
	}
}
