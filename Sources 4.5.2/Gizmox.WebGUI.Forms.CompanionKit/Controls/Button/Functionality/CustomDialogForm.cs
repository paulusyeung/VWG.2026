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

namespace CompanionKit.Controls.Button.Functionality
{
    public partial class CustomDialogForm : global::Gizmox.WebGUI.Forms.Form
    {
        public CustomDialogForm()
        {
            InitializeComponent();
            //Applying DialogResult property for "Yes" and "No" buttons
            this.mobjNoButton.DialogResult = Gizmox.WebGUI.Forms.DialogResult.No;
            this.mobjYesButton.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Yes;
        }
    }
}