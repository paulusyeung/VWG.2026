using System;
using System.Collections;
using System.Text;
using System.ComponentModel.Design;
using System.ComponentModel;


namespace Gizmox.WebGUI.Forms.Design
{
    
	public class DataGridViewColumnCollectionEditor : System.ComponentModel.Design.CollectionEditor
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewColumnCollectionEditor"/> class.
        /// </summary>
        public DataGridViewColumnCollectionEditor()
            : base(typeof(DataGridViewColumnCollection))
        {
        }

        /// <summary>
        /// Gets the data types that this collection editor can contain.
        /// </summary>
        /// <returns>
        /// An array of data types that this collection can contain.
        /// </returns>
        protected override Type[] CreateNewItemTypes()
        {
            ArrayList objTypes = new ArrayList();

            IDesignerHost host = (IDesignerHost)this.GetService(typeof(IDesignerHost));
            if (host != null)
            {
                ITypeDiscoveryService service = (ITypeDiscoveryService)host.GetService(typeof(ITypeDiscoveryService));
                if (service != null)
                {
                    // Add the DataGridViewTextBoxColumn class first.
                    objTypes.Add(typeof(DataGridViewTextBoxColumn));

                    foreach (Type type in DesignerUtils.FilterGenericTypes(service.GetTypes(typeof(DataGridViewColumn), false)))
                    {
                        if (((type == typeof(DataGridViewColumn)) || type.IsAbstract) || (!type.IsPublic && !type.IsNestedPublic))
                        {
                            continue;
                        }
                        DataGridViewColumnDesignTimeVisibleAttribute attribute = TypeDescriptor.GetAttributes(type)[typeof(DataGridViewColumnDesignTimeVisibleAttribute)] as DataGridViewColumnDesignTimeVisibleAttribute;
                        if (!objTypes.Contains(type) &&
                            (attribute == null || attribute.Visible))
                        {
                            objTypes.Add(type);
                        }
                    }                    
                }
            }

            return (Type[])objTypes.ToArray(typeof(Type));

        }

        /// <summary>
        /// Retrieves the display text for the given list item.
        /// Set the display text(Columns on the list box) to be as the header text
        /// </summary>
        /// <param name="value">The list item for which to retrieve display text.</param>
        /// <returns>
        /// The display text for <paramref name="value"/>.
        /// </returns>
        protected override string GetDisplayText(object value)
        {
            if (value != null &&
                value is DataGridViewColumn &&
                !string.IsNullOrEmpty(((DataGridViewColumn)(value)).HeaderText))
            {
                return ((DataGridViewColumn)(value)).HeaderText;
            }
            else
            {
                return base.GetDisplayText(value);
            }
        }

    }
}
