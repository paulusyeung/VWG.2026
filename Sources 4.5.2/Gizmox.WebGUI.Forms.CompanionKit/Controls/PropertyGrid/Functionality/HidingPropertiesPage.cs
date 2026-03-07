using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;

using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace CompanionKit.Controls.PropertyGrid.Functionality
{
    public partial class HidingPropertiesPage : UserControl
    {
        private bool isVisible = false;
        /// <summary>
        /// Indicates whether the property should be displayed in the PropertyGrid.
        /// </summary>
        Dictionary<string, bool> browsableProperties = new Dictionary<string, bool>();


        /// <summary>
        /// Represents DemoObject that is used for demonstrating how to edit it with PropertyGrid
        /// </summary>
        DemoObject objDemoObject = null;

        public HidingPropertiesPage()
        {
            InitializeComponent();

            // Initialize and present the object
            objDemoObject = new DemoObject();
            lblDemoObject.Text = objDemoObject.ToString();
        }

        /// <summary>
        ///  Init the PropertyGrid to inspect and edit the demoobject
        /// </summary>
        private void HidingPropertiesPage_Load(object sender, EventArgs e)
        {
            
            //Fill up ComboBox with peoperties of demo object
            foreach(System.Reflection.MemberInfo member in this.objDemoObject.GetType().GetMembers())
            {
                if (System.Reflection.MemberTypes.Property == member.MemberType)
                {
                    bool browsable = true;

                    foreach (BrowsableAttribute attribute in member.GetCustomAttributes(typeof(BrowsableAttribute), false))
                    {
                        if(!attribute.Browsable) {
                            browsable = false;
                            break;
                        }
                    }
                    browsableProperties.Add(member.Name, browsable);
                    this.objPropertiesComboBox.Items.Add(member.Name);
                }
            }
     
            // Set which properties shoul be displayed in the PropertyGrid control.
            DemoObjectConverter.browsableProperties = browsableProperties;
            
            // Set demo object for the PropertyGrid
            objPropGrid.SelectedObject = objDemoObject;
            this.objPropertiesComboBox.SelectedIndex = 0;

         }

        /// <summary>
        /// Update the object presentation after been changed
        /// </summary>
        private void objPropGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            lblDemoObject.Text = objDemoObject.ToString();
        }

        /// <summary>
        /// Handles SelectedIndexChanged event of the ComboBox with demo object properties.
        /// </summary>
        private void objPropertiesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectPropertyName = (string)this.objPropertiesComboBox.SelectedItem;
            this.showPropertyCheckBox.Checked = browsableProperties[selectPropertyName];
        }

        /// <summary>
        /// Handles click event of the CheckBox that indicates whether 
        /// selected property should be displayed in the PropertyGrid
        /// </summary>
        private void showPropertyCheckBox_Click(object sender, EventArgs e)
        {
            string selectPropertyName = (string)this.objPropertiesComboBox.SelectedItem;
            if(browsableProperties[selectPropertyName] == this.showPropertyCheckBox.Checked)
            {
                return;
            }

            browsableProperties[selectPropertyName] = this.showPropertyCheckBox.Checked;

            // Update dictionary of the demo object type converter for PropertyGrid.
            // The dictionary indicates whether the property should be displayed in the PropertyGrid.
            if (DemoObjectConverter.browsableProperties != null && 
                (DemoObjectConverter.browsableProperties.Count == browsableProperties.Count))
            {
                if (DemoObjectConverter.browsableProperties.ContainsKey(selectPropertyName))
                {
                    DemoObjectConverter.browsableProperties[selectPropertyName] = this.showPropertyCheckBox.Checked;
                }
                else
                {
                    DemoObjectConverter.browsableProperties.Add(selectPropertyName, this.showPropertyCheckBox.Checked);
                }
            }
            else
            {
                DemoObjectConverter.browsableProperties = browsableProperties;
            }

            // Update PropertyGrid
            objPropGrid.SelectedObject = objDemoObject;
            objPropGrid.Update();
        }

        private void HidingPropertiesPage_VisibleChanged(object sender, EventArgs e)
        {
            isVisible = !isVisible;
            if (!isVisible)
            {
                DemoObjectConverter.browsableProperties.Clear();
            }
        }

       
    }
}