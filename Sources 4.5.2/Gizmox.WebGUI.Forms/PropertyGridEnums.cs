#region Using

using System;
using System.Collections;
using System.Text; 

#endregion

namespace Gizmox.WebGUI.Forms
{
    #region GridItemType Enum
    
    /// <summary>
    /// Specifies the valid grid item types for a <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.
    /// </summary>
    
	public enum GridItemType
    {
        /// <summary>
        /// A grid entry that corresponds to a property.
        /// </summary>
        Property,
        /// <summary>
        /// A grid entry that is a category name. A category is a descriptive grouping for groups of <see cref="T:System.Windows.Forms.GridItem"></see> rows. Typical categories include the following Behavior, Layout, Data, and Appearance.
        /// </summary>
        Category,
        /// <summary>
        /// The <see cref="T:Gizmox.WebGUI.Forms.GridItem"></see> is an element of an array.
        /// </summary>
        ArrayValue,
        /// <summary>
        /// A root item in the grid hierarchy.
        /// </summary>
        Root
    } 

    #endregion

    #region PropertySort Enum
    
    /// <summary>
    /// Specifies how properties are sorted in the <see cref="T:Gizmox.WebGUI.Forms.PropertyGrid"></see>.
    /// </summary>
    
	public enum PropertySort
    {
        /// <summary>
        /// Properties are displayed in the order in which they are retrieved from the <see cref="T:System.ComponentModel.TypeDescriptor"></see>.
        /// </summary>
        NoSort,
        /// <summary>
        /// Properties are sorted in an alphabetical list.
        /// </summary>
        Alphabetical,
        /// <summary>
        /// Properties are displayed according to their category in a group. The categories are defined by the properties themselves.
        /// </summary>
        Categorized,
        /// <summary>
        /// Properties are displayed according to their category in a group. The properties are further sorted alphabetically within the group. The categories are defined by the properties themselves.
        /// </summary>
        CategorizedAlphabetical
    } 

    #endregion
}
