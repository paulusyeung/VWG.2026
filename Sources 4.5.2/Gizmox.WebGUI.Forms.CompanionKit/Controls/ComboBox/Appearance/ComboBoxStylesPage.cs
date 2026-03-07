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

namespace CompanionKit.Controls.ComboBox.Appearance
{
    public partial class ComboBoxStylesPage : UserControl
    {
        public ComboBoxStylesPage()
        {
            InitializeComponent();

            this.mobjDropDownComboBox.SelectedIndex = 0;
            this.mobjSimpleComboBox.SelectedIndex = 0;
            this.mobjDropDownListComboBox.SelectedIndex = 0;
        }
    }
}