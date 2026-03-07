#region Using

using System;
using System.Runtime.InteropServices;
using Gizmox.WebGUI.Forms.Design;
using System.ComponentModel; 

#endregion

namespace Gizmox.WebGUI.Forms
{
    #region GridEntryRecreateChildrenEventArgs Class
    
    internal delegate void GridEntryRecreateChildrenEventHandler(object sender, GridEntryRecreateChildrenEventArgs rce);

    [Serializable()]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class GridEntryRecreateChildrenEventArgs : EventArgs
    {
        public GridEntryRecreateChildrenEventArgs(int oldCount, int intNewCount)
        {
            this.OldChildCount = oldCount;
            this.NewChildCount = intNewCount;
        }


        public readonly int NewChildCount;
        public readonly int OldChildCount;
    } 

    #endregion

    #region SelectedGridItemChangedEventArgs Class
   
    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.PropertyGrid.SelectedGridItemChanged"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void SelectedGridItemChangedEventHandler(object sender, SelectedGridItemChangedEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.PropertyGrid.SelectedGridItemChanged"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public class SelectedGridItemChangedEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.SelectedGridItemChangedEventArgs"></see> class.</summary>
        /// <param name="objOldSel">The previously selected grid item. </param>
        /// <param name="objNewSel">The newly selected grid item. </param>
        public SelectedGridItemChangedEventArgs(GridItem objOldSel, GridItem objNewSel)
        {
            this.oldSelection = objOldSel;
            this.newSelection = objNewSel;
        }


        /// <summary>Gets the newly selected <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.</summary>
        /// <returns>The new <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public GridItem NewSelection
        {
            get
            {
                return this.newSelection;
            }
        }

        /// <summary>Gets the previously selected <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>.</summary>
        /// <returns>The old <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see>. This can be null.</returns>
        /// <filterpriority>1</filterpriority>
        public GridItem OldSelection
        {
            get
            {
                return this.oldSelection;
            }
        }


        private GridItem newSelection;
        private GridItem oldSelection;
    }
    
    #endregion

    #region PropertyValueChangedEventArgs Class

    /// <summary>The event handler class that is invoked when a property in the grid is modified by the user.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void PropertyValueChangedEventHandler(object s, PropertyValueChangedEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.PropertyGrid.PropertyValueChanged"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    [ComVisible(true), Serializable()]
	public class PropertyValueChangedEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PropertyValueChangedEventArgs"></see> class.</summary>
        /// <param name="objOldValue">The old property value. </param>
        /// <param name="objChangedItem">The item in the grid that changed. </param>
        public PropertyValueChangedEventArgs(GridItem objChangedItem, object objOldValue)
        {
            this.mobjChangedItem = objChangedItem;
            this.mobjOldValue = objOldValue;
        }


        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> that was changed.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> in the <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public GridItem ChangedItem
        {
            get
            {
                return this.mobjChangedItem;
            }
        }

        /// <summary>The value of the grid item before it was changed.</summary>
        /// <returns>A object representing the old value of the property.</returns>
        /// <filterpriority>1</filterpriority>
        public object OldValue
        {
            get
            {
                return this.mobjOldValue;
            }
        }


        private readonly GridItem mobjChangedItem;
        private object mobjOldValue;
    }
    
    #endregion

    #region PropertyValueChangingEventArgs Class

    /// <summary>The event handler class that is invoked when a property in the grid is modified by the user before the change occurs.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void PropertyValueChangingEventHandler(object s, PropertyValueChangingEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.PropertyGrid.PropertyValueChanging"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    [ComVisible(true), Serializable()]
    public class PropertyValueChangingEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PropertyValueChangingEventArgs"></see> class.</summary>
        /// <param name="objNewValue">The new property value. </param>
        /// <param name="objChangingItem">The item in the grid that is changing. </param>
        public PropertyValueChangingEventArgs(GridItem objChangingItem, object objNewValue)
        {
            this.mobjChangingItem = objChangingItem;
            this.mobjNewValue = objNewValue;
        }


        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> that is changing.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> in the <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public GridItem ChangingItem
        {
            get
            {
                return this.mobjChangingItem;
            }
        }

        /// <summary>The value that the grid item will be changed to.</summary>
        /// <returns>A object representing the new value of the property.</returns>
        /// <filterpriority>1</filterpriority>
        public object NewValue
        {
            get
            {
                return this.mobjNewValue;
            }
            set
            {
                this.mobjNewValue = value;
            }
        }


        /// <summary>Used to select whether the property change action should be cancelled.</summary>
        /// <returns>True if the change action will be cancelled, otherwise false.</returns>
        /// <filterpriority>1</filterpriority>
        public bool Cancel
        {
            get
            {
                return this.mblnCancel;
            }
            set
            {
                this.mblnCancel = value;
            }
        }


        private readonly GridItem mobjChangingItem;
        private object mobjNewValue;
        private bool mblnCancel = false;
    }

    #endregion

    #region PropertyTabChangedEventArgs Class
   
    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.PropertyGrid.PropertyTabChanged"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void PropertyTabChangedEventHandler(object s, PropertyTabChangedEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.PropertyGrid.PropertyTabChanged"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    [ComVisible(true), Serializable()]
	public class PropertyTabChangedEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.PropertyTabChangedEventArgs"></see> class.</summary>
        /// <param name="objNewTab">The newly selected property tab. </param>
        /// <param name="objOldTab">The Previously selected property tab. </param>
        public PropertyTabChangedEventArgs(PropertyTab objOldTab, PropertyTab objNewTab)
        {
            this.oldTab = objOldTab;
            this.newTab = objNewTab;
        }


        /// <summary>Gets the new <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> selected.</summary>
        /// <returns>The newly selected <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public PropertyTab NewTab
        {
            get
            {
                return this.newTab;
            }
        }

        /// <summary>Gets the old <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> selected.</summary>
        /// <returns>The old <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> that was selected.</returns>
        /// <filterpriority>1</filterpriority>
        public PropertyTab OldTab
        {
            get
            {
                return this.oldTab;
            }
        }


        private PropertyTab newTab;
        private PropertyTab oldTab;
    } 
    #endregion


    #region ShowingTypeEdorOpenEventArgs Class


    /// <summary>
    /// represents the methods to be called before openning any event dialog
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="e">The <see cref="PropertyTabChangedEventArgs"/> instance containing the event data.</param>
    public delegate void ShowingTypeEditorEventHandler(object s, ShowingTypeEditorEventArgs e);

    /// <summary>
    /// The data class for the EventArgs
    /// </summary>
    [Serializable()]
    public class ShowingTypeEditorEventArgs : EventArgs
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ShowingTypeEditorEventArgs"/> class.
        /// </summary>
        /// <param name="objCurrentItem">The obj current item.</param>
        public ShowingTypeEditorEventArgs(GridItem objCurrentItem)
        {
            this.mobjCurrentGridItem = objCurrentItem;
        }
        
        /// <summary>
        /// Gets the current grid item.
        /// </summary>
        /// <value>
        /// The current grid item.
        /// </value>
        public GridItem CurrentGridItem
        {
            get
            {
                return this.mobjCurrentGridItem;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is cancelled.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is cancelled; otherwise, <c>false</c>.
        /// </value>
        public bool IsCancelled
        {
            get
            {
                return this.mblnIsCancelled;
            }
        }

        private GridItem mobjCurrentGridItem;
        private bool mblnIsCancelled;
    }
    #endregion

}
