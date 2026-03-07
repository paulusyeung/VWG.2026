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

namespace CompanionKit.Controls.PropertyGrid.Functionality
{
    public partial class ObjectInspection : UserControl
    {
        public ObjectInspection()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Select the label to inspection
        /// Change the Text property, Border style, Border Width
        /// </summary>
        private void objButton01_Click(object sender, EventArgs e)
        {
            objPropGrid.SelectedObject = objInitial;
        }

        /// <summary>
        /// Select the other label to change
        /// </summary>
        private void objButton02_Click(object sender, EventArgs e)
        {
            objPropGrid.SelectedObject = objAnotherLabel;
        }

        /// <summary>
        /// Select the link label and change the URL property
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void objButton03_Click(object sender, EventArgs e)
        {
            objPropGrid.SelectedObject = objVWGLinkLabel; 
        }

        /// <summary>
        /// Select the initial and another label to inspection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void objMultiple_Click(object sender, EventArgs e)
        {
            objPropGrid.SelectedObjects = 
                new object[]
                {
                    objInitial,
                    objAnotherLabel
                };
        }
    }
}