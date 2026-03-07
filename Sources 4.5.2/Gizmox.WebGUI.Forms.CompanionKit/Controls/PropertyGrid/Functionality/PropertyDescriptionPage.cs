using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.PropertyGrid.Functionality
{
    public partial class PropertyDescriptionPage : UserControl
    {
        /// <summary>
        /// Represents DemoObject that is used for demonstrating how to edit it with PropertyGrid
        /// </summary>
        DemoObject objDemoObject = null;

        public PropertyDescriptionPage()
        {
            InitializeComponent();

            // Initialize and present the object
            objDemoObject = new DemoObject();
            lblDemoObject.Text = objDemoObject.ToString();
        }

        /// <summary>
        ///  Init the PropertyGrid to inspect and edit the demoobject
        /// </summary>
        private void PropertyDescriptionPage_Load(object sender, EventArgs e)
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