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

namespace CompanionKit.Controls.PropertyGrid.ApplicationScenarios
{
    /// <summary>
    /// This class represents options of the selection object
    /// </summary>
    public partial class OptionsDialog : Gizmox.WebGUI.Forms.Form
    {
        private OptionsDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates dialog to change option of the specific object. 
        /// </summary>
        /// <param name="optionObject">selected object</param>
        public OptionsDialog(object optionObject): this()
        {
            this.optionsPropertyGrid.SelectedObject = optionObject;
        }
    }
}