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

namespace Gizmox.WebGUI.Forms.CompanionKit.Controls.FormBox.Features
{
    public partial class ArgumentsPropertyForm : Form
    {
        public ArgumentsPropertyForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of Form
        /// </summary>
        private void ArgumentsPropertyForm_Load(object sender, EventArgs e)
        {
            // Check if argument with key needed exists and 
            // set its value to apropriate Label as a text

            if (Context.Arguments["Color"] != null)
                lblColor.Text = string.Format("Color: {0}", Context.Arguments["Color"]);

            if (Context.Arguments["Size"] != null)
                lblSize.Text = string.Format("Size: {0}", Context.Arguments["Size"]);
        }
    }
}