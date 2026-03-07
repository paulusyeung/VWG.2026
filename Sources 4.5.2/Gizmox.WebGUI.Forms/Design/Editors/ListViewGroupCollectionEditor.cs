using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms.Design
{
    [Serializable()]
    public class ListViewGroupCollectionEditor : CollectionEditor
    {
        #region C'Tor

        /// <summary>
        /// Initializes a new instance of the <see cref="ContextualTabGroupCollectionEditor"/> class.
        /// </summary>
        /// <param name="objType">The type of the collection for this editor to edit.</param>
        public ListViewGroupCollectionEditor(Type objType)
            : base(objType)
        {
            
        }

        #endregion C'Tor

        #region Methods

        /// <summary>
        /// Sets the specified array as the items of the collection.
        /// </summary>
        /// <param name="objEditValue">The collection to edit.</param>
        /// <param name="arrValues">An array of objects to set as the collection items.</param>
        /// <returns>
        /// The newly created collection object or, otherwise, the collection indicated by the editValue parameter.
        /// </returns>
        protected override object SetItems(object objEditValue, object[] arrValues)
        {
            // Check vaild objEditValue
            if ((objEditValue != null) && (objEditValue is ListViewGroupCollection))
            {
                ListViewGroupCollection objListViewGroupCollection = (ListViewGroupCollection)objEditValue;

                // Clear old values without clearing ListViewGroup references
                objListViewGroupCollection.ClearInternal();

                // Add new values
                for (int i = 0; i < arrValues.Length; i++)
                {
                    ListViewGroup objGroup = arrValues[i] as ListViewGroup;
                    if (objGroup != null)
                    {
                        objListViewGroupCollection.Add(objGroup);
                    }
                }
            }
            return objEditValue;
        }

        /// <summary>
        /// Creates a new form to display and edit the current collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.Design.CollectionEditor.CollectionForm"></see> to provide as the user interface for editing the collection.
        /// </returns>
        protected override CollectionForm CreateCollectionForm()
        {
            CollectionForm objForm = base.CreateCollectionForm();

            // Register form close event
            objForm.Closed += new EventHandler(objForm_Closed);

            return objForm;
        }

        /// <summary>
        /// Handles the Closed event of the objForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void objForm_Closed(object sender, EventArgs e)
        {
            Form objForm = sender as Form;

            if (objForm != null)
            {
                ITypeDescriptorContext objContext = this.Context;
                if (objContext != null)
                {
                    ListView objListView = objContext.Instance as ListView;

                    // Check if listview is valid
                    if (objListView != null)
                    {
                        // Get listview's groups
                        ListViewGroupCollection objListviewGroups = objListView.Groups;

                        // Check valid Groups
                        if (objListviewGroups != null)
                        {
                            // Loop on all listview items and check if Group stil valid
                            foreach (ListViewItem objItem in objListView.Items)
                            {
                                ListViewGroup objListViewGroup = objItem.Group;
                                if (objListViewGroup != null)
                                {
                                    if (!objListviewGroups.Contains(objListViewGroup))
                                    {
                                        objItem.Group = null;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        #endregion Methods
    }
}