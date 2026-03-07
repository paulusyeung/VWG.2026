using System;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using System.ComponentModel;
using WinForms = System.Windows.Forms;
using WebForms = Gizmox.WebGUI.Forms;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms.Design
{
    public class ContextualTabGroupEditor : UITypeEditor
    {

        IWindowsFormsEditorService mobjEditorService;

        protected System.ComponentModel.ITypeDescriptorContext mobjContext;
        

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
                        mobjContext = context;

                        // Get tab page
                        WebForms.TabPage objHandledComponent = this.TabPage;

                        // Create listbox
                        WinForms.ListBox objListBox = new WinForms.ListBox();

                        // Get tab control ContextualTabGroups
                        ContextualTabGroupCollection objContextualTabGroupCollection = objHandledComponent.TabControl.ContextualTabGroups;
                        ContextualTabGroup[] objContextualTabGroups = new ContextualTabGroup[objContextualTabGroupCollection.Count];
                        objContextualTabGroupCollection.CopyTo(objContextualTabGroups, 0);

                        // Add none item
                        objListBox.Items.Add(SR.GetString("None"));

                        // Add ContextualTabGroups to listbox
                        objListBox.Items.AddRange(objContextualTabGroups);

                        // Check if there is a ContextualTabGroup attached to this tabpage 
                        if (objHandledComponent.ContextualTabGroup != null)
                        {
                            // Get ContextualTabGroup index in the collection ( + 1 of the none item)
                            int intCurrentSelectedItem = objContextualTabGroupCollection.IndexOf(objHandledComponent.ContextualTabGroup) + 1;

                            // Set listbox selected index
                            objListBox.SelectedIndex = intCurrentSelectedItem;
                            
                        }

                        // Register listbox SelectedIndexChanged event 
                        objListBox.SelectedIndexChanged += new EventHandler(objListBox_SelectedIndexChanged);

                        // Send new listbox to the editor service
                        mobjEditorService.DropDownControl(objListBox);

                        // Get listbox selected item
                        ContextualTabGroup objSelectedItem = objListBox.SelectedItem as ContextualTabGroup;
                        
                        // Update new value
                        value = objSelectedItem;
                    }
                }
            }

            return value;
        }

        /// <summary>
        /// Gets the tab page.
        /// </summary>
        protected virtual TabPage TabPage
        {
            get
            {
                return mobjContext.Instance as TabPage;
            }
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

#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
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
#endif

        #endregion
    }
}
