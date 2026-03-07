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
    public partial class FormPropertyForm1 : Form
    {
        public FormPropertyForm1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles Load event of the Form
        /// </summary>
        private void FormPropertyForm1_Load(object sender, EventArgs e)
        {
            ShowFormType();
        }

        /// <summary>
        /// Handles Click event of Button 
        /// </summary>
        private void btnShowFormType_Click(object sender, EventArgs e)
        {
            ShowFormType();
        }

        private void ShowFormType()
        {
            // Call MessageBox to show the Form type
            MessageBox.Show(string.Format("Form type: {0}", this.GetType()));
        }
    }
}