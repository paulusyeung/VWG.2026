#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.SEO;

#endregion

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    public partial class InspectorFieldEditForm : Form
    {
        private SEOPageInspectorField mobjField = null;



        public InspectorFieldEditForm() 
        {
            InitializeComponent();
        }

        public InspectorFieldEditForm(SEOPageInspectorField objField)
        {
            InitializeComponent();
            
            mobjField = objField;

            InitializeForm();
        }

        private void InitializeForm()
        {
            mobjComboType.DataSource = Enum.GetValues(typeof(SEOPageInspectorFieldType));
            mobjComboType.SelectedItem = mobjField.Type;
            mobjTextLabel.Text = mobjField.Label;
            mobjTextProperty.Text = mobjField.PropertyName;
            mobjTextTarget.Text = mobjField.TargetName;
            mobjNumericColumn.Value = mobjField.Column;
            mobjNumericOrder.Value = mobjField.Order;
        }

        private void mobjButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void mobjButtonOk_Click(object sender, EventArgs e)
        {
            mobjField.Type = (SEOPageInspectorFieldType)mobjComboType.SelectedItem;
            mobjField.Label = mobjTextLabel.Text;
            mobjField.PropertyName = mobjTextProperty.Text;
            mobjField.TargetName = mobjTextTarget.Text;
            mobjField.Column = (int)mobjNumericColumn.Value;
            mobjField.Order = (int)mobjNumericOrder.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Gets the dialog field.
        /// </summary>
        /// <value>The dialog field.</value>
        public SEOPageInspectorField DialogField
        {
            get { return mobjField; }
        }


    }
}