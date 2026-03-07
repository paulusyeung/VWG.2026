#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// This class provieds a collection editor to the ObjectBox parameters
    /// </summary>
    public class ObjectBoxParameterCollectionEditor : System.ComponentModel.Design.CollectionEditor
    {
        public ObjectBoxParameterCollectionEditor()
            : base(typeof(Hosts.ObjectBox.ObjectBoxParameterCollection))
        {
            
        }


        /// <summary>
        /// Creates a new instance of the specified collection item type.
        /// </summary>
        /// <param name="itemType">The type of item to create.</param>
        /// <returns>A new instance of the specified object.</returns>
        protected override object CreateInstance(Type itemType)
        {
            return new Hosts.ObjectBox.ObjectBoxParameter();
        }

        /// <summary>
        /// Gets the data type that this collection contains.
        /// </summary>
        /// <returns>
        /// The data type of the items in the collection, or an <see cref="T:System.Object"/> if no Item property can be located on the collection.
        /// </returns>
        protected override Type CreateCollectionItemType()
        {
            return typeof(Hosts.ObjectBox.ObjectBoxParameter);
        }
    }
}