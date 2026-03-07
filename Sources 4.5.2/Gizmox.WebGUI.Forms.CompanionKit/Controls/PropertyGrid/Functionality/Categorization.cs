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
    public partial class Categorization : UserControl
    {
        /// <summary>
        /// Represents DemoObject that is used for demonstrating how to edit it with PropertyGrid
        /// </summary>
        DemoObject objDemoObject = null;

        public Categorization()
        {
            InitializeComponent();
            
            // Initialize and present the object
            objDemoObject = new DemoObject();
            lblDemoObject.Text = objDemoObject.ToString();
        }

        /// <summary>
        ///  Init the PropertyGrid to inspect and edit the demoobject
        /// </summary>
        private void Categorization_Load(object sender, EventArgs e)
        {
            objPropGrid.SelectedObject = objDemoObject;
        }

        /// <summary>
        /// Update the object presentation after been changed
        /// </summary>
        private void objPropGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            lblDemoObject.Text = objDemoObject.ToString();
        }
    }
}