using Gizmox.WebGUI.Forms.Design.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Text;
using WebGUIForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// The editor to set the order of the listview columns when using the VisualTemplate.
    /// </summary>
    [Serializable()]
    public class VisualTemplateListViewColumnOrderEditor : UITypeEditor
    {
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
        public override object EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue)
        {
            // Get the type of the element
            VisualTemplate objVisualTemplate = objContext.Instance as VisualTemplate;

            WebGUIForms.ListView objEditingListView = VisualTemplateEditor.EditingComponent as WebGUIForms.ListView;

            string strColumnOrder = objValue as string;

            // Create the visualappearnce column dialog
            VisualTemplateListViewColumnControlForm objDialog = new VisualTemplateListViewColumnControlForm(objEditingListView, strColumnOrder);
            objDialog.StartPosition = WinForms.FormStartPosition.CenterScreen;

            WinForms.DialogResult objResult = objDialog.ShowDialog();
            if (objResult == WinForms.DialogResult.Cancel)
            {
                return objValue;
            }

            return objDialog.ColumnOrder;
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

        private class VisualTemplateListViewColumnControlForm : WinForms.Form
        {
            #region Class Members

            private WinForms.Label mobjLabelHelp;
            private WinForms.Button mobjButtonCancel;
            private WinForms.Button mobjButtonOK;
            private WinForms.Panel mobjPanelButtons;
            private Gizmox.WebGUI.Forms.Design.Controls.ItemChooser mobjItemChooser;
            private WebGUIForms.ListView mobjEditingListView;
            private string mstrColumnOrder;

            #endregion Class Members

            #region C'Tor\D'Tor

            /// <summary>
            /// Creates a new <see cref="ListViewColumnOptions"/> instance.
            /// </summary>
            /// <param name="objEditiingListView">List view.</param>
            public VisualTemplateListViewColumnControlForm(WebGUIForms.ListView objEditiingListView, string strColumnOrder)
            {
                // Initialize components
                InitializeComponent();

                this.AcceptButton = mobjButtonOK;
                this.CancelButton = mobjButtonCancel;

                mstrColumnOrder = strColumnOrder;
                mobjEditingListView = objEditiingListView;

                // Set local references
                WebGUIForms.ListView.ColumnHeaderCollection objEditingColumns = mobjEditingListView.Columns;
                List<ColumnHeaderText> objColumnTexts = new List<ColumnHeaderText>();
                foreach(WebGUIForms.ColumnHeader objColumnHeader in objEditingColumns)
                {
                    ColumnHeaderText objColumnHeaderText = new ColumnHeaderText(objColumnHeader.Text, objColumnHeader.Index);
                    objColumnTexts.Add(objColumnHeaderText);
                }

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
                            objCheckedArrayList.Add(objColumnTexts[intColumnIndex]);
                        }
                    }
                }

                ArrayList objSortedArrayList = new ArrayList(objCheckedArrayList);

                // Display all the other columns not checked.
                foreach (ColumnHeaderText objColumnText in objColumnTexts)
                {
                    if (!objSortedArrayList.Contains(objColumnText))
                    {
                        objSortedArrayList.Add(objColumnText);
                    }
                }

                // Add all columns
                mobjItemChooser.Items = objSortedArrayList;

                // Set selected items
                mobjItemChooser.Checked = objCheckedArrayList;

                // Attach selection event
                this.mobjButtonOK.Click += new EventHandler(mobjButtonOK_Click);

                this.mobjButtonOK.Text = WGLabels.Ok;
                this.mobjButtonCancel.Text = WGLabels.Cancel;
                this.Text = "Column Options";
                this.mobjLabelHelp.Text = "Check the columns that you would like to make visible. Use the Move Up and Move Down buttons to reorder the columns.";
            }


            #endregion C'Tor\D'Tor

            #region Initialize Component

            /// <summary>
            /// Initializes the component.
            /// </summary>
            private void InitializeComponent()
            {                                
                this.mobjLabelHelp = new WinForms.Label();
                this.mobjPanelButtons = new WinForms.Panel();
                this.mobjButtonCancel = new WinForms.Button();
                this.mobjButtonOK = new WinForms.Button();
                this.mobjItemChooser = new Gizmox.WebGUI.Forms.Design.Controls.ItemChooser();
                this.mobjPanelButtons.SuspendLayout();
                this.SuspendLayout();

                //
                // mobjPanelButtons
                //
                this.mobjPanelButtons.Controls.Add(this.mobjButtonOK);
                this.mobjPanelButtons.Controls.Add(this.mobjButtonCancel);
                this.mobjPanelButtons.Dock = WinForms.DockStyle.Bottom;
                this.mobjPanelButtons.Location = new System.Drawing.Point(15, 300);
                this.mobjPanelButtons.Name = "mobjPanelButtons";
                this.mobjPanelButtons.Size = new System.Drawing.Size(312, 35);
                this.mobjPanelButtons.TabIndex = 1;

                //
                // mobjLabelHelp
                //

                this.mobjLabelHelp.Dock = WinForms.DockStyle.Top;
                this.mobjLabelHelp.Location = new System.Drawing.Point(15, 15);
                this.mobjLabelHelp.Name = "mobjLabelHelp";
                this.mobjLabelHelp.Size = new System.Drawing.Size(312, 49);
                this.mobjLabelHelp.TabIndex = 0;
                this.mobjLabelHelp.Text = "Check the columns that you would like to make visible. Use the Move  Up and Move " +
                "Down buttons to reorder the columns.";

                //
                // mobjButtonCancel
                //
                this.mobjButtonCancel.Anchor = ((WinForms.AnchorStyles)((WinForms.AnchorStyles.Bottom | WinForms.AnchorStyles.Right)));
                this.mobjButtonCancel.Location = new System.Drawing.Point(236, 11);
                this.mobjButtonCancel.Name = "mobjButtonCancel";
                this.mobjButtonCancel.TabIndex = 0;
                this.mobjButtonCancel.Text = "Cancel";
                //
                // mobjButtonOK
                //
                this.mobjButtonOK.Anchor = ((WinForms.AnchorStyles)((WinForms.AnchorStyles.Bottom | WinForms.AnchorStyles.Right)));
                this.mobjButtonOK.Location = new System.Drawing.Point(156, 11);
                this.mobjButtonOK.Name = "mobjButtonOK";
                this.mobjButtonOK.TabIndex = 1;
                this.mobjButtonOK.Text = "OK";
                //
                // mobjItemChooser
                //
                this.mobjItemChooser.Dock = WinForms.DockStyle.Fill;
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
            /// Gets the column order chosen.
            /// </summary>
            public string ColumnOrder
            {
                get
                {
                    return mstrColumnOrder;
                }
            }

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
                foreach (ColumnHeaderText objColumnText in mobjItemChooser.Items)
                {
                    if (objChecked.Contains(objColumnText))
                    {
                        objStringBuilder.Append(string.Format("{0}|", objColumnText.Index));
                    }
                }

                mstrColumnOrder = objStringBuilder.ToString().Trim('|');

                DialogResult = WinForms.DialogResult.OK;
                Close();
            }

            private class ColumnHeaderText
            {
                private string mstrText;
                private int mintIndex;

                public ColumnHeaderText(string strText, int intIndex)
                {
                    mstrText = strText;
                    mintIndex = intIndex;
                }

                /// <summary>
                /// Gets the index of the column.
                /// </summary>
                public int Index
                {
                    get
                    {
                        return mintIndex;
                    }
                }

                /// <summary>
                /// Gets the text of the column.
                /// </summary>
                public string Text
                {
                    get
                    {
                        return mstrText;
                    }
                }

                public override string ToString()
                {
                    return Text;
                }
            }
        }
    }
}
