using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using WinForms = System.Windows.Forms;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.VisualEffects;

namespace Gizmox.WebGUI.Forms.Design.Editors
{
    public class GradientToPositionEditor : UITypeEditor
    {
        IWindowsFormsEditorService mobjEditorService;

        #region Methods

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
        /// <param name="provider">An <see cref="T:System.IServiceProvider"/> that this editor can use to obtain services.</param>
        /// <param name="value">The object to edit.</param>
        /// <returns>
        /// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
        /// </returns>
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            // Checks that context has valid values.
            if (context != null &&
                context.Instance != null)
            {
                if (provider != null)
                {
                    // Get the WindowsFormsEditorService.
                    mobjEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                    if (mobjEditorService != null)
                    {
                        // Create listbox
                        WinForms.ListBox objListBox = new WinForms.ListBox();

                        // Add direction values to the  listbox
                        if (context.PropertyDescriptor.PropertyType == typeof(HorizontalDirection))
                        {
                            objListBox.Items.Add(HorizontalDirection.Left);
                            objListBox.Items.Add(HorizontalDirection.Right);
                            objListBox.Items.Add(HorizontalDirection.None);
                        }
                        else
                        {
                            objListBox.Items.Add(VerticalDirection.Top);
                            objListBox.Items.Add(VerticalDirection.Bottom);
                            objListBox.Items.Add(VerticalDirection.None);
                        }
                        if(objListBox.Items.Contains(value))
                        {
                            objListBox.SelectedItem = value;
                        }
                    
                        // Register listbox SelectedIndexChanged event 
                        objListBox.SelectedIndexChanged += new EventHandler(objListBox_SelectedIndexChanged);

                        // Send new listbox to the editor service
                        mobjEditorService.DropDownControl(objListBox);

                        value = objListBox.SelectedItem;
                    }
                }
            }
            return value;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the objListBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void objListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            mobjEditorService.CloseDropDown();
        }

        /// <summary>
        /// Gets the editor style used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"/> method.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Design.UITypeEditorEditStyle"/> value that indicates the style of editor used by the <see cref="M:System.Drawing.Design.UITypeEditor.EditValue(System.IServiceProvider,System.Object)"/> method. If the <see cref="T:System.Drawing.Design.UITypeEditor"/> does not support this method, then <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> will return <see cref="F:System.Drawing.Design.UITypeEditorEditStyle.None"/>.
        /// </returns>
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        #endregion

    }
}
