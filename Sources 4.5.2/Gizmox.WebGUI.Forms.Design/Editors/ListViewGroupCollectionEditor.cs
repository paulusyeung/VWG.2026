using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Gizmox.WebGUI.Forms.Design
{
    public class ListViewGroupCollectionEditor : System.ComponentModel.Design.CollectionEditor
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContextualTabGroupCollectionEditor"/> class.
        /// </summary>
        /// <param name="objType">Type of the obj.</param>
        public ListViewGroupCollectionEditor(Type objType)
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
                    ListView objListView = context.Instance as ListView;

                    // Check if tabcontrol is valid
                    if (objListView != null)
                    {
                        // Get objListView's ListViewGroupCollection
                        ListViewGroupCollection objListViewGroupCollection = objListView.Groups;

                        // Check valid ListViewGroupCollection
                        if (objListViewGroupCollection != null)
                        {
                            // Loop on all listview items and check if Group stil valid
                            foreach (ListViewItem objListViewItem in objListView.Items)
                            {
                                ListViewGroup objListViewGroup = objListViewItem.Group;
                                if (objListViewGroup != null)
                                {
                                    if (!objListViewGroupCollection.Contains(objListViewGroup))
                                    {
                                        objListViewItem.Group = null;
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
            if ((objEditValue != null) && (objEditValue is ListViewGroupCollection))
            {
                ListViewGroupCollection objListViewGroupCollection = (ListViewGroupCollection)objEditValue;

                // Clear old values without clearing group references
                objListViewGroupCollection.ClearInternal();

                // Add new values
                for (int i = 0; i < objValue.Length; i++)
                {
                    ListViewGroup objGroup = objValue[i] as ListViewGroup;
                    if (objGroup != null)
                    {
                        objListViewGroupCollection.Add(objGroup);
                    }
                }
            }
            return objEditValue;
        }
    }
}
