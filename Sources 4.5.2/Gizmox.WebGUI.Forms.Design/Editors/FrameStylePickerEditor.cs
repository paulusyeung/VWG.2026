using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using WinForms = System.Windows.Forms;
using WebForms = Gizmox.WebGUI.Forms;
using System.ComponentModel;
using Gizmox.WebGUI.Forms.Skins;
using System.Reflection;
using System.ComponentModel.Design;
using System.Collections;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// 
    /// </summary>
    public class FrameStylePickerEditor : UITypeEditor
    {
		#region Fields (1) 

        IWindowsFormsEditorService mobjEditorService = null;

		#endregion Fields 

		#region Properties (1) 

        /// <summary>
        /// Gets a value indicating whether drop-down editors should be resizable by the user.
        /// </summary>
        /// <returns>true if drop-down editors are resizable; otherwise, false. </returns>
        public override bool IsDropDownResizable
        {
            get
            {
                return true;
            }
        }

		#endregion Properties 

		#region Methods (3) 

		// Public Methods (2) 

        /// <summary>
        /// Edits the specified object's value using the editor style indicated by the <see cref="M:System.Drawing.Design.UITypeEditor.GetEditStyle"/> method.
        /// </summary>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
        /// <param name="objProvider">An <see cref="T:System.IServiceProvider"/> that this editor can use to obtain services.</param>
        /// <param name="objValue">The object to edit.</param>
        /// <returns>
        /// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
        /// </returns>
        public override object EditValue(ITypeDescriptorContext objContext, IServiceProvider objProvider, object objValue)
        {
            // Checks that context has valid values.
            if (objContext != null &&
                objContext.Instance != null &&
                objProvider != null)
            {
                Skin objSkin = this.GetOwnerSkin(objProvider);
                if (objSkin != null)
                {
                    Type objSkinType = objSkin.GetType();
                    if (objSkinType != null)
                    {
                        List<string> arrFrameStylePropertyNames = new List<string>();

                        PropertyInfo[] arrProperties = objSkinType.GetProperties();

                        // Loop and fetch all FrameStyleValue properties.
                        foreach (PropertyInfo objProperty in arrProperties)
                        {
                            if (objProperty.PropertyType.Name == "FrameStyleValue")
                            {
                                arrFrameStylePropertyNames.Add(objProperty.Name);
                            }
                        }

                        if (arrFrameStylePropertyNames.Count > 0)
                        {
                            mobjEditorService = (IWindowsFormsEditorService)objProvider.GetService(typeof(IWindowsFormsEditorService));
                            if (mobjEditorService != null)
                            {
                                // Create listbox
                                WinForms.ListBox objListBox = new WinForms.ListBox();

                                // Eliminate list box's border.
                                objListBox.BorderStyle = WinForms.BorderStyle.None;

                                // Add the none item.
                                objListBox.Items.Add("None");

                                // Add all property names to listbox.
                                objListBox.Items.AddRange(arrFrameStylePropertyNames.ToArray());

                                if (objValue != null)
                                {
                                    // Try getting the exist item's index in the list.
                                    int intExistItemIndex = objListBox.Items.IndexOf(objValue);
                                    if (intExistItemIndex >= 0)
                                    {
                                        objListBox.SelectedIndex = intExistItemIndex;
                                    }
                                }

                                // Register listbox SelectedIndexChanged event 
                                objListBox.SelectedIndexChanged += new EventHandler(OnListBoxSelectedIndexChanged);

                                // Send new listbox to the editor service
                                mobjEditorService.DropDownControl(objListBox);

                                if (objListBox.SelectedItem != null)
                                {
                                    if (objListBox.SelectedItem == "None")
                                    {
                                        objValue = null;
                                    }
                                    else
                                    {
                                        // Convert selected item to string value.
                                        string strSelectedValue = Convert.ToString(objListBox.SelectedItem);
                                        if (!string.IsNullOrEmpty(strSelectedValue))
                                        {
                                            // Update new value
                                            objValue = string.Format("{0}@{1}, {2}", strSelectedValue, objSkinType.FullName, objSkinType.Assembly.FullName);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return objValue;
        }

        /// <summary>
        /// Get an owner skin
        /// </summary>
        /// <param name="objProvider"></param>
        /// <returns></returns>
        private Skin GetOwnerSkin(IServiceProvider objProvider)
        {
            IContainer objContainer = objProvider.GetService(typeof(IContainer)) as IContainer;
            if (objContainer != null)
            {
                if (objContainer.Components.Count > 0)
                {
                    Skin objSkin = objContainer.Components[0] as Skin;
                    if (objSkin != null)
                    {
                        return objSkin;
                    }
                    else
                    {
                        ISelectionService objSelectionService = objProvider.GetService(typeof(ISelectionService)) as ISelectionService;
                        if (objSelectionService != null)
                        {
                            ICollection objSelectedComponents = objSelectionService.GetSelectedComponents();

                            foreach (object objSelectedComponent in objSelectedComponents)
                            {
                                if (objSelectedComponent is Skin)
                                {
                                    return objSelectedComponent as Skin;
                                }
                            }
                        }
                    }
                }
            }

            return null;
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
		// Private Methods (1) 

        /// <summary>
        /// Handles the SelectedIndexChanged event of the objListBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void OnListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            mobjEditorService.CloseDropDown();
        }

		#endregion Methods 
    }
}
