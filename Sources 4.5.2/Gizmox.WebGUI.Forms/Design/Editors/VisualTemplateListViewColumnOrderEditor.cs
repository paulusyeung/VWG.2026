using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;
using Gizmox.WebGUI.Forms.Controls;

namespace Gizmox.WebGUI.Forms.Design.Editors
{
    /// <summary>
    /// The editor to set the order of the listview columns when using the VisualTemplate.
    /// </summary>
    [Serializable()]
    public class VisualTemplateListViewColumnOrderEditor : WebUITypeEditor
    {
        /// <summary>
        /// The handler
        /// </summary>
        private WebUITypeEditorHandler mobjHandler = null;


        /// <summary>
        /// Initializes a new instance of the <see cref="VisualTemplateListViewColumnOrderEditor"/> class.
        /// </summary>
        /// <param name="objType">Type of the object.</param>
        public VisualTemplateListViewColumnOrderEditor(Type objType)
            : base()
        {

        }

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <param name="objProvider">An <see cref="T:System.IServiceProvider"></see> that this editor can use to obtain services.</param>
        /// <param name="objValue">The object to edit.</param>
        /// <param name="objHandler">The obj handler.</param>
        public override void EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue, WebUITypeEditorHandler objHandler)
        {
            // Get the type of the element
            VisualTemplate objVisualTemplate = objContext.Instance as VisualTemplate;

            PropertyGridInternal.GridEntry objGridEntry = objProvider as PropertyGridInternal.GridEntry;
            PropertyGrid objGrid = null;

            // The grid will have the ListView related to the objects.
            if (objGridEntry != null)
            {
                objGrid = objGridEntry.OwnerGrid;
            }            

            if (objVisualTemplate != null && objGrid != null)
            {
                ListView objListView = objGrid.Tag as ListView;

                string strCurrentColumnOrderAppearance = objValue as string;

                // Create the visualappearnce column dialog
                VisualTemplateListViewColumnControlDialog objVisualizerControlDialog = new VisualTemplateListViewColumnControlDialog(objListView, strCurrentColumnOrderAppearance);
                objVisualizerControlDialog.Closed += new EventHandler(objVisualTemplateListViewColumnControlDialog_Closed);

                // Store handler
                mobjHandler = objHandler;

                // Show dialog
                IWebUIEditorService objEditorService = objProvider.GetService(typeof(IWebUIEditorService)) as IWebUIEditorService;
                if (objEditorService != null)
                {
                    objEditorService.ShowDialog(objVisualizerControlDialog);
                }
            }
        }


        /// <summary>
        /// Handles the Closed event of the objVisualTemplateListViewColumnControlDialog control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void objVisualTemplateListViewColumnControlDialog_Closed(object sender, EventArgs e)
        {
            VisualTemplateListViewColumnControlDialog objVisualizerControlDialog = (VisualTemplateListViewColumnControlDialog)sender;
            if (objVisualizerControlDialog.DialogResult == DialogResult.OK)
            {
                if (mobjHandler != null)
                {
                    mobjHandler(this.GetPropertyValueFromEditorValue(objVisualizerControlDialog.ListViewColumnOrder));
                }
            }
        }


        /// <summary>
        /// Gets the editor style used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that can be used to gain additional context information.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"></see> value that indicates the style of editor used by the <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.EditValue(System.IServiceProvider,System.Object)"></see> method. If the <see cref="T:Gizmox.WebGUI.Forms.Design.WebUITypeEditor"></see> does not support this method, then <see cref="M:Gizmox.WebGUI.Forms.Design.WebUITypeEditor.GetEditStyle"></see> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"></see>.
        /// </returns>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext objContext)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }


    /// <summary>
    /// The dialog form for column ordter.
    /// </summary>
    [Serializable]
    public class VisualTemplateListViewColumnControlDialog : CommonDialog
    {
        private ListView mobjListView;
        private string mstrCurrentColumnOrderAppearance;

        /// <summary>
        /// Initializes a new instance of the <see cref="VisualTemplateListViewColumnControlDialog"/> class.
        /// </summary>
        /// <param name="objListView">The object ListView.</param>
        /// <param name="strCurrentColumnOrderAppearance">The string current column order appearance.</param>
        public VisualTemplateListViewColumnControlDialog(ListView objListView, string strCurrentColumnOrderAppearance)
        {
            mobjListView = objListView;
            mstrCurrentColumnOrderAppearance = strCurrentColumnOrderAppearance;
        }

        [Serializable()]
        protected class VisualTemplateListViewColumnControlForm : CommonDialogForm
        {
            #region Class Members

            private Label mobjLabelHelp;
            private Button mobjButtonCancel;
            private Button mobjButtonOK;
            private Panel mobjPanelButtons;
            private ItemChooser mobjItemChooser;
            private ListView.ColumnHeaderCollection mobjColumns;
            private ListView mobjListView;
            private string mstrColumnOrder;


            #endregion Class Members

            #region C'Tor\D'Tor

            /// <summary>
            /// Creates a new <see cref="ListViewColumnOptions"/> instance.
            /// </summary>
            /// <param name="objListView">List view.</param>
            public VisualTemplateListViewColumnControlForm(VisualTemplateListViewColumnControlDialog objVisualizerControlDialog)
                : base(objVisualizerControlDialog)
            {
                // Set local references.
                mobjListView = objVisualizerControlDialog.mobjListView;
                mstrColumnOrder = objVisualizerControlDialog.mstrCurrentColumnOrderAppearance;

                // Initialize components
                InitializeComponent();

                this.AcceptButton = mobjButtonOK;
                this.CancelButton = mobjButtonCancel;

                if (mobjListView != null)
                {
                    // Set local references
                    mobjColumns = mobjListView.Columns;

                    ArrayList objCheckedArrayList = new ArrayList();

                    // If there is an existing order for the columns, restore the lists.
                    if (mstrColumnOrder != null)
                    {
                        string[] arrCurrentDisplayedColumns = mstrColumnOrder.Split('|');

                        foreach (string strColumnIndex in arrCurrentDisplayedColumns)
                        {
                            int intColumnIndex;
                            if (int.TryParse(strColumnIndex, out intColumnIndex))
                            {
                                objCheckedArrayList.Add(mobjColumns[intColumnIndex]);
                            }
                        }
                    }

                    ArrayList objSortedArrayList = new ArrayList(objCheckedArrayList);

                    // Display all the other columns not checked.
                    foreach (ColumnHeader objColumn in mobjColumns)
                    {
                        if (!objSortedArrayList.Contains(objColumn))
                        {
                            objSortedArrayList.Add(objColumn);
                        }
                    }

                    // Add all columns
                    mobjItemChooser.Items = objSortedArrayList;

                    // Set selected items
                    mobjItemChooser.Checked = objCheckedArrayList;
                }
                #region Attach Events

                // Attach selection event
                this.mobjButtonOK.Click += new EventHandler(mobjButtonOK_Click);

                #endregion

                this.mobjItemChooser.CheckLabel = WGLabels.Show;
                this.mobjItemChooser.UncheckLabel = WGLabels.Hide;
                this.mobjItemChooser.MoveDownLabel = WGLabels.MoveDown;
                this.mobjItemChooser.MoveUpLabel = WGLabels.MoveUp;


                this.mobjButtonOK.Text = WGLabels.Ok;
                this.mobjButtonCancel.Text = WGLabels.Cancel;
                this.Text = SR.GetString(Context.CurrentUICulture, "WGLablesColumnOptions");
                this.mobjLabelHelp.Text = SR.GetString(Context.CurrentUICulture, "WGLablesColumnsInstructions");

            }

           
            #endregion C'Tor\D'Tor

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
                this.mobjItemChooser = new ItemChooser();
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
                // mobjItemChooser
                //
                this.mobjItemChooser.Dock = DockStyle.Fill;
                this.mobjItemChooser.Location = new System.Drawing.Point(15, 64);
                this.mobjItemChooser.Name = "mobjItemChooser";
                this.mobjItemChooser.Size = new System.Drawing.Size(320, 191);
                this.mobjItemChooser.TabIndex = 3;
                //
                // ListViewColumnOptions
                //			
                this.ClientSize = new System.Drawing.Size(342, 350);

                this.Controls.Add(this.mobjItemChooser);
                this.Controls.Add(this.mobjPanelButtons);
                this.Controls.Add(this.mobjLabelHelp);
                this.DockPadding.All = 15;
                this.Name = "ListViewColumnOptions";
                this.Text = "ListViewColumnOptions";
                this.mobjPanelButtons.ResumeLayout(false);
                this.mobjPanelButtons.ResumeLayout(false);
                this.ResumeLayout(false);

            }


            #endregion Initialize Component
                       
            /// <summary>
            /// Handle OK button click
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void mobjButtonOK_Click(object sender, EventArgs e)
            {
                ArrayList objChecked = new ArrayList(mobjItemChooser.Checked);

                StringBuilder objStringBuilder = new StringBuilder();

                // Loop all headers
                foreach (ColumnHeader objColumn in mobjItemChooser.Items)
                {
                    if (objChecked.Contains(objColumn))
                    {
                        objStringBuilder.Append(string.Format("{0}|", objColumn.Index));
                    }
                }

                ((VisualTemplateListViewColumnControlDialog)this.CommonDialogOwner).mstrCurrentColumnOrderAppearance = objStringBuilder.ToString().Trim('|');

                this.DialogResult = DialogResult.OK;                
            }
        }


        /// <summary>
        /// When overridden in a derived class, resets the properties of a common dialog box to their default values.
        /// </summary>
        public override void Reset()
        {

        }

        /// <summary>
        /// Creates a dialog for instance for the current common dialog
        /// </summary>
        /// <returns></returns>
        protected override CommonDialog.CommonDialogForm CreateForm()
        {
            return new VisualTemplateListViewColumnControlForm(this);
        }

        /// <summary>
        /// Gets or sets the ListView column order.
        /// </summary>
        /// <value>
        /// The ListView column order.
        /// </value>
        public string ListViewColumnOrder
        {
            get
            {
                return mstrCurrentColumnOrderAppearance;
            }
            set
            {
                mstrCurrentColumnOrderAppearance = value;
            }
        }

       
    }
}
