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
    /// <summary>
    /// 
    /// </summary>
    public partial class InspectorEditView : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        private SEOPageInspector mobjInspector = null;
        /// <summary>
        /// Initializes a new instance of the <see cref="InspectorEditView"/> class.
        /// </summary>
        public InspectorEditView()
        {
            InitializeComponent();
        }

        private void mobjButtonAdd_Click(object sender, EventArgs e)
        {
            InspectorFieldEditForm objAddForm = new InspectorFieldEditForm(new SEOPageInspectorField());
            objAddForm.FormClosed += new Form.FormClosedEventHandler(objAddForm_FormClosed);
            objAddForm.ShowDialog();
        }

        void objAddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            InspectorFieldEditForm objAddForm = sender as InspectorFieldEditForm;
            if (objAddForm != null)
            {
                mobjListFields.Items.Add(CreateItem(objAddForm.DialogField));
            }
        }

        private void mobjButtonEdit_Click(object sender, EventArgs e)
        {
            EditField();
        }

        private void EditField()
        {
            if (mobjListFields.SelectedItem != null)
            {
                SEOPageInspectorField objField = mobjListFields.SelectedItem.Tag as SEOPageInspectorField;
                if (objField != null)
                {
                    InspectorFieldEditForm objEditForm = new InspectorFieldEditForm(objField);
                    objEditForm.FormClosed += new Form.FormClosedEventHandler(objEditForm_FormClosed);
                    objEditForm.ShowDialog();
                }
            }
        }

        private void mobjListFields_DoubleClick(object sender, EventArgs e)
        {
            EditField();
        }


        void objEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            InspectorFieldEditForm objEditForm = sender as InspectorFieldEditForm;
            if (objEditForm != null)
            {
                UpdateItem(objEditForm.DialogField);
            }
        }



        private void mobjButtonRemove_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Delete selected properties?","Confirm delete", MessageBoxButtons.OKCancel, 
                new EventHandler(mobjButtonRemove_confirmed));
        }

        /// <summary>
        /// Complete deletion of selected properties if confirmed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="objEventArgs"></param>
        private void mobjButtonRemove_confirmed(object sender, EventArgs objEventArgs)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                if (mobjListFields.SelectedItem != null)
                {
                    mobjListFields.Items.Remove(mobjListFields.SelectedItem);
                }
            }
        }


        private ListViewItem CreateItem(SEOPageInspectorField objField)
        {
            ListViewItem objItem = new ListViewItem(objField.Label);
            objItem.SubItems.Add(objField.Type.ToString());
            objItem.SubItems.Add(objField.TargetName);
            objItem.SubItems.Add(objField.PropertyName);
            objItem.SubItems.Add(objField.Column.ToString());
            objItem.SubItems.Add(objField.Order.ToString());
            objItem.Tag = objField;
            return objItem;
        }

        private void UpdateItem(SEOPageInspectorField objField)
        {
            foreach (ListViewItem objItem in mobjListFields.Items)
            {
                if (objItem.Tag == objField)
                {
                    objItem.Text = objField.Label;
                    objItem.SubItems[1].Text = objField.Type.ToString();
                    objItem.SubItems[2].Text = objField.TargetName;
                    objItem.SubItems[3].Text = objField.PropertyName;
                    objItem.SubItems[4].Text = objField.Column.ToString();
                    objItem.SubItems[5].Text = objField.Order.ToString();
                    break;
                }
            }
        }

        /// <summary>
        /// Gets or sets the inspector.
        /// </summary>
        /// <value>The inspector.</value>
		[DesignerSerializationVisibility(0)]
        public SEOPageInspector Inspector
        {
            get
            {
                if (mobjInspector != null)
                {
                    mobjInspector.IsVisible = mobjCheckShowInspector.Checked;
                    mobjInspector.ShowAdvanced = mobjCheckShowAdvanced.Checked;

                    List<SEOPageInspectorField> objFields = new List<SEOPageInspectorField>();
                    foreach (ListViewItem objItem in mobjListFields.Items)
                    {
                        objFields.Add((SEOPageInspectorField)objItem.Tag);
                    }

                    mobjInspector.Fields = objFields.ToArray();
                    mobjInspector.Columns = GetColumns(mobjTextColumns.Text, mobjInspector);
                    mobjInspector.Docking = (SEOPageInspectorDocking)mobjComboDocking.SelectedItem;
                }
                return mobjInspector;
            }
            set
            {
                if (value != null)
                {
                    mobjInspector = (SEOPageInspector)value.Clone();
                }
                else
                {
                    mobjInspector = new SEOPageInspector();
                }
                Bind();
            }
        }





        private void Bind()
        {
            mobjListFields.Items.Clear();

            if (mobjInspector != null)
            {
                mobjCheckShowAdvanced.Checked = mobjInspector.ShowAdvanced;
                mobjCheckShowInspector.Checked = mobjInspector.IsVisible;

                foreach (SEOPageInspectorField objField in mobjInspector.Fields)
                {
                    mobjListFields.Items.Add(CreateItem(objField));
                }

                mobjTextColumns.Text = GetColumns(mobjInspector.Columns);
                mobjComboDocking.DataSource = Enum.GetValues(typeof(SEOPageInspectorDocking));
                mobjComboDocking.SelectedItem = mobjInspector.Docking;
            }
        }


        private int[] GetColumns(string strNewValue, SEOPageInspector mobjInspector)
        {
            List<int> objColumns = new List<int>();
            foreach (string strColumn in strNewValue.Split(';'))
            {
                int intValue = 200;
                int.TryParse(strColumn, out intValue);
                objColumns.Add(intValue);
            }

            return objColumns.ToArray();
        }

        private string GetColumns(int[] arrColumns)
        {
            List<string> objColumns = new List<string>();
            foreach (int intColumn in arrColumns)
            {
                objColumns.Add(intColumn.ToString());
            }
            return string.Join(";", objColumns.ToArray());
        }




    }
}