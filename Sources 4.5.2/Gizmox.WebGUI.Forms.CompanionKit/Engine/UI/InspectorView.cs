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
using System.Reflection;

#endregion

namespace Gizmox.WebGUI.Forms.CompanionKit.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class InspectorView : UserControl
    {
        private const int mcntDefaultColumnWidth = 150;

        private const int mcntDefaultRowHeight = 30;

        private const int mcntDefaultTopPadding = 10;

        private const int mcntDefaultLeftPadding = 10;

        /// <summary>
        /// Initializes a new instance of the <see cref="InspectorView"/> class.
        /// </summary>
        public InspectorView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objPageInspector"></param>
        /// <param name="objInspected"></param>
        public void Initialize(SEOPageInspector objInspector, Control objInspectorTarget)
        {
            // current position
            Dictionary<int, int> objColumnTop = new Dictionary<int, int>();

            // Loop all fields
            foreach (SEOPageInspectorField objField in objInspector.Fields)
            {                
                // Get target name
                string strTargetName = objField.TargetName;

                // If there is a valid target name
                if (!string.IsNullOrEmpty(strTargetName))
                {
                    // Try to get the target control
                    Control objFieldControlTarget = GetFieldControlTarget(objInspectorTarget, strTargetName);

                    // If there is a valid field target
                    if (objFieldControlTarget != null)
                    {
                        // Get property name
                        string strPropertyName = objField.PropertyName;

                        // If there is a valid property name
                        if (!string.IsNullOrEmpty(strPropertyName))
                        {
                            // Get target property info
                            PropertyInfo objFieldPropertyTarget = GetPropertyFieldTarget(objFieldControlTarget, strPropertyName);
                            if (objFieldPropertyTarget != null)
                            {
                                // Get the inspector control
                                Control objInspectorControl = CreateFieldControl(objField,objFieldControlTarget,  objFieldPropertyTarget);
                                if (objInspectorControl != null)
                                {
                                    // Get the control label
                                    Label objInspctorControlLabel = CreateFieldLabel(objField);
                                    if (objInspctorControlLabel != null)
                                    {
                                        objInspctorControlLabel.Width = GetLabelWidth(objInspector, objField);
                                        objInspctorControlLabel.Location = GetLabelLocation(objInspector, objField, objColumnTop);
                                        this.Controls.Add(objInspctorControlLabel);
                                    }

                                    objInspectorControl.Width = GetControlWidth(objInspector, objField);
                                    objInspectorControl.Location = GetControlLocation(objInspector, objField, objColumnTop);
                                    this.Controls.Add(objInspectorControl);    

                                    IncrementTop(objColumnTop, objField);
                                }
                            }
                        }
                    }
                }
            }

            // Set the height of the control
            this.Height = GetMaxColumnTop(objColumnTop) + mcntDefaultRowHeight;
            this.Width = GetInspectorWidth(objInspector);
        }

        private int GetInspectorWidth(SEOPageInspector objInspector)
        {
            int[] intColumns = objInspector.Columns;
            int intWidth = mcntDefaultLeftPadding * 2;
            foreach (int intColumn in intColumns)
            {

                    intWidth += intColumn;
            }

            return intWidth + mcntDefaultLeftPadding;
        }

        private int GetMaxColumnTop(Dictionary<int, int> objColumnTop)
        {
            int intMaxTop = 0;
            foreach (int intValue in objColumnTop.Values)
            {
                intMaxTop = Math.Max(intValue, intMaxTop);
            }
            return intMaxTop;
        }

        private void IncrementTop(Dictionary<int, int> objColumnTop, SEOPageInspectorField objField)
        {
            int intLabelColumn = objField.Column*2;
            int intControlColumn = objField.Column*2 +1;

            if (objColumnTop.ContainsKey(intLabelColumn))
            {
                objColumnTop[intLabelColumn] += mcntDefaultRowHeight;
            }
            else
            {
                objColumnTop[intLabelColumn] = mcntDefaultRowHeight;
            }

            if (objColumnTop.ContainsKey(intControlColumn))
            {
                objColumnTop[intControlColumn] += mcntDefaultRowHeight;
            }
            else
            {
                objColumnTop[intControlColumn] = mcntDefaultRowHeight;
            }
        }

        private Point GetControlLocation(SEOPageInspector objInspector, SEOPageInspectorField objField, Dictionary<int, int> objColumnTop)
        {
            int intLeft = GetColumnLeft(objInspector.Columns, objField.Column * 2 + 1);
            int intTop = GetColumnTop(objColumnTop, objField.Column);
            return new Point(intLeft, intTop);
        }

        private int GetColumnTop(Dictionary<int, int> objColumnTop, int intColumn)
        {
            if (objColumnTop.ContainsKey(intColumn))
            {
                return objColumnTop[intColumn];
            }
            else
            {
                return objColumnTop[intColumn] = mcntDefaultTopPadding;
            }
        }

        private Point GetLabelLocation(SEOPageInspector objInspector, SEOPageInspectorField objField, Dictionary<int, int> objColumnTop)
        {
            int intLeft = GetColumnLeft(objInspector.Columns, objField.Column * 2);
            int intTop = GetColumnTop(objColumnTop, objField.Column);
            return new Point(intLeft, intTop);
        }

        

        private int GetControlWidth(SEOPageInspector objInspector, SEOPageInspectorField objField)
        {
            return GetColumnWidth(objInspector.Columns, objField.Column * 2 + 1);
        }

        private int GetLabelWidth(SEOPageInspector objInspector, SEOPageInspectorField objField)
        {
            return GetColumnWidth(objInspector.Columns, objField.Column * 2);
        }

        private int GetColumnWidth(int[] intColumns, int intColumn)
        {
            if (intColumns.Length > intColumn)
            {
                return intColumns[intColumn];
            }
            else
            {
                return mcntDefaultColumnWidth;
            }
        }

        private int GetColumnLeft(int[] intColumns, int intColumn)
        {
            int intLeft = mcntDefaultLeftPadding;

            for (int intIndex = 0; intIndex < intColumn; intIndex++)
            {
                intLeft += GetColumnWidth(intColumns, intIndex);
            }
            return intLeft;
        }


        /// <summary>
        /// Create the label control
        /// </summary>
        /// <param name="objField"></param>
        /// <returns></returns>
        private Label CreateFieldLabel(SEOPageInspectorField objField)
        {
            if (objField.Type != SEOPageInspectorFieldType.CheckBox)
            {
                return new Label(objField.Label);
            }
            return null;
        }


        /// <summary>
        /// Create field control
        /// </summary>
        /// <param name="objField"></param>
        /// <returns></returns>
        private Control CreateFieldControl(SEOPageInspectorField objField, Control objFieldControlTarget, PropertyInfo objFieldPropertyTarget)
        {
            Control objControl = null;

            switch (objField.Type)
            {
                case SEOPageInspectorFieldType.CheckBox:
                    objControl = CreateCheckBoxFieldControl(objField, objFieldControlTarget, objFieldPropertyTarget);
                    break;
                case SEOPageInspectorFieldType.TextBox:
                    objControl = CreateTextBoxFieldControl(objField, objFieldControlTarget, objFieldPropertyTarget);
                    break;
                case SEOPageInspectorFieldType.NumericUpDown:
                    objControl = CreateNumericUpDownFieldControl(objField, objFieldControlTarget, objFieldPropertyTarget);
                    break;
                case SEOPageInspectorFieldType.ComboBox:
                    objControl = CreateComboBoxFieldControl(objField, objFieldControlTarget, objFieldPropertyTarget);
                    break;
                case SEOPageInspectorFieldType.Editor:
                    objControl = CreateEditorFieldControl(objField, objFieldControlTarget, objFieldPropertyTarget);
                    break;
            }

            return objControl;
        }

        private Control CreateEditorFieldControl(SEOPageInspectorField objField, Control objFieldControlTarget, PropertyInfo objFieldPropertyTarget)
        {
            return null;
        }

        private Control CreateComboBoxFieldControl(SEOPageInspectorField objField, Control objFieldControlTarget, PropertyInfo objFieldPropertyTarget)
        {
            ComboBox objComboBox = null;

            // If is boolean property
            if (objFieldPropertyTarget.PropertyType.IsEnum)
            {
                objComboBox = new ComboBox();
                objComboBox.Height = 20;
                objComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                objComboBox.DataSource = Enum.GetValues(objFieldPropertyTarget.PropertyType);
                objComboBox.SelectedItem = objFieldPropertyTarget.GetValue(objFieldControlTarget, new object[] { });
                objComboBox.DataBindings.Add(GetControlFieldBinding("SelectedItem", objFieldControlTarget, objFieldPropertyTarget));
            }

            return objComboBox;
        }

        private Control CreateNumericUpDownFieldControl(SEOPageInspectorField objField, Control objFieldControlTarget, PropertyInfo objFieldPropertyTarget)
        {
            NumericUpDown objNumericUpDown = null;

            // If is boolean property
            if (IsNumericType(objFieldPropertyTarget.PropertyType))
            {
                objNumericUpDown = new NumericUpDown();
                objNumericUpDown.Value = Convert.ToDecimal(objFieldPropertyTarget.GetValue(objFieldControlTarget, new object[] { }));
                objNumericUpDown.DataBindings.Add(GetControlFieldBinding("Value", objFieldControlTarget, objFieldPropertyTarget));
            }

            return objNumericUpDown;
        }

        private Binding GetControlFieldBinding(string strProperty, Control objFieldControlTarget, PropertyInfo objFieldPropertyTarget)
        {
            Binding objBinding = new Binding(strProperty, objFieldControlTarget, objFieldPropertyTarget.Name, false, DataSourceUpdateMode.OnPropertyChanged);
            objBinding.FormattingEnabled = true;
            objBinding.BindingComplete += new BindingCompleteEventHandler(OnControlBindingComplete);
            return objBinding;
        }

        private void OnControlBindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.Exception != null)
            {
                this.mobjErrorProvider.SetError(e.Binding.Control, e.ErrorText);
            }
            else
            {
                this.mobjErrorProvider.SetError(e.Binding.Control, string.Empty);
            }
        }

        /// <summary>
        /// Indicates if a type is numeric
        /// </summary>
        /// <param name="objType"></param>
        /// <returns></returns>
        private bool IsNumericType(Type objType)
        {
            if (objType == typeof(decimal))
            {
                return true;
            }
            else
            {
                return typeof(IConvertible).IsAssignableFrom(objType);
            }
        }

        private Control CreateTextBoxFieldControl(SEOPageInspectorField objField, Control objFieldControlTarget, PropertyInfo objFieldPropertyTarget)
        {
            TextBox objTextBox = null;

            // If is boolean property
            if (IsStringValue(objFieldPropertyTarget.PropertyType))
            {
                objTextBox = new TextBox();
                objTextBox.Text = Convert.ToString(objFieldPropertyTarget.GetValue(objFieldControlTarget, new object[] { }));
                objTextBox.DataBindings.Add(GetControlFieldBinding("Text", objFieldControlTarget, objFieldPropertyTarget));

            }

            return objTextBox;
        }

        private bool IsStringValue(Type objType)
        {
            if (objType == typeof(string))
            {
                return true;
            }
            else
            {
                return typeof(IConvertible).IsAssignableFrom(objType);
            }

        }

        private Control CreateCheckBoxFieldControl(SEOPageInspectorField objField, Control objFieldControlTarget,  PropertyInfo objFieldPropertyTarget)
        {
            CheckBox objCheckBox = null;

            // If is boolean property
            if (IsBooleanValue(objFieldPropertyTarget.PropertyType))
            {
                objCheckBox = new CheckBox();
                objCheckBox.Text = objField.Label;
                objCheckBox.Checked = Convert.ToBoolean(objFieldPropertyTarget.GetValue(objFieldControlTarget, new object[] { }));
                objCheckBox.DataBindings.Add(GetControlFieldBinding("Checked", objFieldControlTarget, objFieldPropertyTarget));
            }

            return objCheckBox;
        }

        private bool IsBooleanValue(Type objType)
        {
            if (objType == typeof(bool))
            {
                return true;
            }
            else
            {
                return typeof(IConvertible).IsAssignableFrom(objType);
            }

        }

        /// <summary>
        /// Gets the property field target.
        /// </summary>
        /// <param name="objFieldControlTarget">The field control target.</param>
        /// <param name="strPropertyName">The control target property name.</param>
        /// <returns></returns>
        private PropertyInfo GetPropertyFieldTarget(Control objFieldControlTarget, string strPropertyName)
        {
             return objFieldControlTarget.GetType().GetProperty(strPropertyName);
        }

        /// <summary>
        /// Gets the field target.
        /// </summary>
        /// <param name="objInspectorTarget">The inspector target.</param>
        /// <param name="strTargetName">The name of the field target control.</param>
        /// <returns></returns>
        private Control GetFieldControlTarget(Control objInspectorTarget, string strTargetName)
        {
            Control[] objControls = objInspectorTarget.Controls.Find(strTargetName, true);
            if (objControls.Length > 0)
            {
                return objControls[0];
            }
            return null;
        }

    }
}