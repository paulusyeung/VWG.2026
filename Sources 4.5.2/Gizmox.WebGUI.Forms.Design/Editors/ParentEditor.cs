using System;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.ComponentModel;
using WinForms = System.Windows.Forms;
using WebForms = Gizmox.WebGUI.Forms;
using System.Collections.Generic;
using Gizmox.WebGUI.Common.Interfaces;

namespace Gizmox.WebGUI.Forms.Design
{

    #region ParentEditor Class

    /// <summary>
    /// 
    /// </summary>
    public class ParentEditor : UITypeEditor
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
                context.Instance != null &&
                context.Container != null)
            {
                if (provider != null)
                {
                    // Get the WindowsFormsEditorService.
                    mobjEditorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                    if (mobjEditorService != null)
                    {
                        // Create listbox
                        WinForms.ListBox objListBox = new WinForms.ListBox();

                        // Get all available components
                        ComponentCollection objComponents = context.Container.Components;
                        if (objComponents != null)
                        {
                            // Loop on all components
                            foreach (IComponent objIComponent in objComponents)
                            {
                                // Ensure the component is not the component we edit
                                if (objIComponent != context.Instance)
                                {
                                    // Ensure component implement IControl
                                    IControl objIControl = objIComponent as IControl;                                    
                                    if (objIControl != null)
                                    {
                                        // Add component to listbox
                                        objListBox.Items.Add(new ParentEditorListItem(objIControl));

                                        // If the looped component is the current selected one, set it as selected
                                        if (value == objIComponent)
                                        {
                                            objListBox.SelectedItem = value;
                                        }
                                    }
                                }
                            }

                            // Register listbox SelectedIndexChanged event 
                            objListBox.SelectedIndexChanged += new EventHandler(objListBox_SelectedIndexChanged);

                            // Send new listbox to the editor service
                            mobjEditorService.DropDownControl(objListBox);

                            // Update new value
                            ParentEditorListItem objSelectedItem = objListBox.SelectedItem as ParentEditorListItem;

                            if (objSelectedItem != null)
                            {
                                value = objSelectedItem.IControl;
                            }
                        }
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

        #region Properties

        /// <summary>
        /// Gets a value indicating whether drop-down editors should be resizable by the user.
        /// </summary>
        /// <value></value>
        /// <returns>true if drop-down editors are resizable; otherwise, false. </returns>
        public override bool IsDropDownResizable
        {
            get
            {
                return true;
            }
        }

        #endregion Properties
    }

    #region ParentEditorListItem Class

    /// <summary>
    /// ParentEditor list item wrraper to display only its site name on the list
    /// </summary>
    public class ParentEditorListItem
    {
        private IControl mobjIControl;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParentEditorListItem"/> class.
        /// </summary>
        /// <param name="objIControl">The obj I control.</param>
        public ParentEditorListItem(IControl objIControl)
        {
            mobjIControl = objIControl;
        }

        /// <summary>
        /// Gets the I control.
        /// </summary>
        public IControl IControl
        {
            get
            {
                return mobjIControl;
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(mobjIControl.Name))
            {
                return mobjIControl.Name;
            }
            else
            {
                return mobjIControl.ToString();
            }
        }
    }

    #endregion ParentEditorListItem Class

    #endregion ParentEditor Class
}
