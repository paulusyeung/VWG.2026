using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Gizmox.WebGUI.Forms.Design
{
    public class ContextualTabGroupCollectionEditor : System.ComponentModel.Design.CollectionEditor
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="ContextualTabGroupCollectionEditor"/> class.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        public ContextualTabGroupCollectionEditor(Type objType)
            : base(objType)
        {
        }

        /// <summary>
        /// Edits the value of the specified object using the specified service provider and context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
        /// <param name="provider">A service provider object through which editing services can be obtained.</param>
        /// <param name="value">The object to edit the value of.</param>
        /// <returns>
        /// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.Design.CheckoutException">An attempt to check out a file that is checked into a source code management program did not succeed.</exception>
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            // Get base return value
            object objReturn = base.EditValue(context, provider, value);

            // Checks that context has valid values.
            if (context != null &&
                context.Instance != null &&
                context.Container != null)
            {
                if (provider != null)
                {
                    // Get tab control
                    TabControl objTabControl = context.Instance as TabControl;

                    // Check if tabcontrol is valid
                    if (objTabControl != null)
                    {
                        // Get tabcontrol's ContextualTabGroups
                        ContextualTabGroupCollection objContextualTabGroups = objTabControl.ContextualTabGroups;

                        // Check valid ContextualTabGroups
                        if (objContextualTabGroups != null)
                        {
                            // Loop on all tab pages and check if ContextualTabGroup stil valid
                            foreach (TabPage objTabPage in objTabControl.TabPages)
                            {
                                ContextualTabGroup objContextualTabGroup = objTabPage.ContextualTabGroup;
                                if (objContextualTabGroup != null)
                                {
                                    if(!objContextualTabGroups.Contains(objContextualTabGroup))
                                    {
                                        objTabPage.ContextualTabGroup = null;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // return base return value
            return objReturn;
        }

        /// <summary>
        /// Sets the specified array as the items of the collection.
        /// </summary>
        /// <param name="objEditValue">The collection to edit.</param>
        /// <param name="objValue">An array of objects to set as the collection items.</param>
        /// <returns>
        /// The newly created collection object or, otherwise, the collection indicated by the <paramref name="objEditValue"/> parameter.
        /// </returns>
        protected override object SetItems(object objEditValue, object[] objValue)
        {
            // Check vaild editValue
            if ((objEditValue != null) && (objEditValue is ContextualTabGroupCollection))
            {
                ContextualTabGroupCollection objContextualTabGroupCollection = (ContextualTabGroupCollection)objEditValue;
                // Clear old values without clearing contextualTabGroup references
                objContextualTabGroupCollection.ClearInternal();

                // Add new values
                for (int i = 0; i < objValue.Length; i++)
                {
                    ContextualTabGroup objGroup = objValue[i] as ContextualTabGroup;
                    if (objGroup != null)
                    {
                        objContextualTabGroupCollection.Add(objGroup);
                    }
                }
            }
            return objEditValue;

        }
    }
}
