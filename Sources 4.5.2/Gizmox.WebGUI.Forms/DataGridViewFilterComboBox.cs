#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// A DataGridViewFilterComboBox control
    /// </summary>
    [Skin(typeof(DataGridViewFilterComboBoxSkin))]
    [Serializable(), ToolboxItem(false)]
    public class DataGridViewFilterComboBox : DataGridViewFilterComboBoxBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewFilterComboBox"/> class.
        /// </summary>
        /// <param name="objDataGridView">The obj data grid view.</param>
        /// <param name="objColumn">The obj column.</param>
        /// <param name="objFilterCell">The obj filter cell.</param>
        public DataGridViewFilterComboBox(DataGridView objDataGridView, DataGridViewColumn objColumn, DataGridViewCell objFilterCell)
            : base(objDataGridView, objColumn, objFilterCell)
        {
            this.CustomStyle = "DataGridViewFilterComboBox";
        }
    }
}
