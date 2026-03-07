#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace CompanionKit.Controls.ComboBox.Features
{
    public partial class TreeViewComboBoxForm : Gizmox.WebGUI.Forms.Form
    {
        public TreeViewComboBoxForm()
        {
            InitializeComponent();
            this.mobjTreeView.CollapseAll();
        }

        private void mobjTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Sets successful results for form.
            this.DialogResult = DialogResult.OK;
            //Close form.
            this.Close();
        }

        /// <summary>
        /// Gets the tree.
        /// </summary>
        /// <value>The tree.</value>
        public Gizmox.WebGUI.Forms.TreeView Tree
        {
            get 
            { 
                return this.mobjTreeView; 
            }
        }
    }
}