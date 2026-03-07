using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace CompanionKit.Controls.ComboBox.Features
{
    public class TreeViewComboBox : Gizmox.WebGUI.Forms.ComboBox
    {
        /// <summary>
        /// The form is used as custom DropDown control.
        /// </summary>
        private TreeViewComboBoxForm _treeViewForm = null;

        /// <summary>
        /// Occurs when selected item changed.
        /// </summary>
        public new event EventHandler SelectedItemChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeViewComboBox"/> class.
        /// </summary>
        public TreeViewComboBox()
        {
            _treeViewForm = new TreeViewComboBoxForm();
            _treeViewForm.Closed += new EventHandler(OnFormClosed);
            this.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDown;
        }

        /// <summary>
        /// Called when form is closed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnFormClosed(object sender, EventArgs e)
        {
            if (((Gizmox.WebGUI.Forms.Form)sender).DialogResult == Gizmox.WebGUI.Forms.DialogResult.OK)
            {
                if (this.SelectedItem != null)
                {
                    this.Text = this.SelectedItem.Text;
                }

                if (SelectedItemChanged != null)
                {
                    SelectedItemChanged(this, EventArgs.Empty);
                }
            }
        }

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
        protected override global::Gizmox.WebGUI.Forms.Form GetCustomDropDown()
        {
            _treeViewForm.DialogResult = Gizmox.WebGUI.Forms.DialogResult.None;
            _treeViewForm.Width = Math.Max(this.Width, _treeViewForm.Width);
            return _treeViewForm;
        }


        /// <summary>
        ///  Gets the collection of parent node contained within the TreeView.
        /// </summary>
        public new Gizmox.WebGUI.Forms.TreeNodeCollection Items
        {
            get
            {
                return this._treeViewForm.Tree.Nodes;
            }
        }

        /// <summary>
        /// Gets the currently selected item index.
        /// </summary>
        /// <value></value        
        public new Gizmox.WebGUI.Forms.TreeNode SelectedItem
        {
            get
            {
                return this._treeViewForm.Tree.SelectedNode;
            }
            set
            {
                this._treeViewForm.Tree.SelectedNode = value;
            }
        }
    }
}
