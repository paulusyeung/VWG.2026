using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms.Design;
using WinForms = System.Windows.Forms;
using WebForms = Gizmox.WebGUI.Forms;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Design.Editors
{
    /// <summary>
    /// 
    /// </summary>
    public class JQueryUIControlsSelectionsEditor : UITypeEditor
    {
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
                context.Instance is WebForms.ResizableOptions &&
                context.Container != null)
            {
                if (provider != null)
                {
                    // Get the WindowsFormsEditorService.
                    IWindowsFormsEditorService editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

                    if (editorService != null)
                    {                       
                        // Create a new DragTargetsCheckedListBox
                        WebForms.ResizableOptions objHandledResizableOptions = context.Instance as ResizableOptions;
                        JQueryUIOptionsCheckedListBox objResizableOptionsCheckedListBox = new JQueryUIOptionsCheckedListBox(objHandledResizableOptions.Owner, context.Container.Components, (Component[])context.PropertyDescriptor.GetValue(objHandledResizableOptions));

                        // Drop the new DragTargetsCheckedListBox down.
                        editorService.DropDownControl(objResizableOptionsCheckedListBox);

                        // Update the drag target value as for the new DragTargetsCheckedListBox.
                        value = objResizableOptionsCheckedListBox.JQueryUIControls;
                    }
                }
            }

            return value;
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
        #endregion

        #region Classes

        #region DragTargetsCheckedListBox Class

        /// <summary>
        /// 
        /// </summary>
        class JQueryUIOptionsCheckedListBox : WinForms.CheckedListBox
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DragTargetsCheckedListBox"/> class.
            /// </summary>
            /// <param name="objAllComponents">The obj all components.</param>
            /// <param name="arrSelectedComponents">The arr selected components.</param>
            public JQueryUIOptionsCheckedListBox(Component objCurrentComponent, ComponentCollection objAllComponents, WebForms.Component[] arrSelectedComponents)
            {
                // Initialize the checked list box.
                this.CheckOnClick = true;
                this.SelectionMode = System.Windows.Forms.SelectionMode.One;

                if (objAllComponents != null)
                {
                    // Run over all the received components.
                    foreach (IComponent objComponent in objAllComponents)
                    {
                        WebForms.Control objWebFormComponent = objComponent as WebForms.Control;
                        // Checks that the current somponent allow drop.
                        if (objWebFormComponent != null && objWebFormComponent.Resizable != null && objWebFormComponent != objCurrentComponent)
                        {                            
                            bool blnChecked = false;

                            // Run over all selected components.
                            foreach (Component objSelectedComponent in arrSelectedComponents)
                            {
                                // Checks if the current component suppose to be selected.
                                if (objSelectedComponent == objComponent)
                                {
                                    blnChecked = true;
                                    break;
                                }
                            }

                            // Add the new component to inner items collection.
                            this.Items.Add(new JQueryUIControl(objComponent), blnChecked);
                        }
                    }
                }
            }

            /// <summary>
            /// Gets the drag targets.
            /// </summary>
            /// <value>The drag targets.</value>
            public WebForms.Component[] JQueryUIControls
            {
                get
                {
                    // Initialize the drag target index.
                    int intJQueryUIIndex = 0;

                    // Initialize the drag targets array as for inner checked items.
                    WebForms.Component[] arrJQueryUIControls = new WebForms.Component[this.CheckedItems.Count];

                    // Run over all checked items.
                    foreach (object objCheckedItem in this.CheckedItems)
                    {
                        // Get the current checked DragTargetComponent.
                        JQueryUIControl objJQueryUIControl = objCheckedItem as JQueryUIControl;

                        if (objJQueryUIControl != null &&
                            objJQueryUIControl.Component is WebForms.Component)
                        {
                            // Add the checked component to the returning array.
                            arrJQueryUIControls[intJQueryUIIndex] = objJQueryUIControl.Component as WebForms.Component;
                            intJQueryUIIndex += 1;
                        }
                    }

                    // Return the new array.
                    return arrJQueryUIControls;
                }
            }
        }

        #endregion

        #region DragTargetComponent Class

        /// <summary>
        /// 
        /// </summary>
        class JQueryUIControl : IComponent
        {
            #region Members

            private IComponent mobjComponent = null;

            #endregion

            #region C'tor / D'tor

            public JQueryUIControl(IComponent objComponent)
            {
                mobjComponent = objComponent;
            }

            #endregion

            public override string ToString()
            {
                if (mobjComponent != null)
                {
                    if (mobjComponent is WebForms.Control)
                    {
                        // Returns the control's name.
                        return ((WebForms.Control)mobjComponent).Name;
                    }
                    else if (mobjComponent.Site != null)
                    {
                        // Returns the component's name from site.
                        return mobjComponent.Site.Name;
                    }
                    else
                    {
                        // Returns the component's type name.
                        return mobjComponent.GetType().Name;
                    }
                }
                else
                {
                    // Returns base functionallity.
                    return base.ToString();
                }
            }

            #region IComponent Members

            public event EventHandler Disposed;

            public ISite Site
            {
                get
                {
                    return mobjComponent.Site;
                }
                set
                {
                    mobjComponent.Site = value;
                }
            }

            #endregion

            #region IDisposable Members

            public void Dispose()
            {
                mobjComponent.Dispose();
            }

            #endregion

            /// <summary>
            /// Gets the component.
            /// </summary>
            /// <value>The component.</value>
            public IComponent Component
            {
                get
                {
                    return mobjComponent;
                }
            }
        }

        #endregion

        #endregion
    }
}
