using System;
using System.Collections;
using System.Text;
using System.ComponentModel.Design;
using System.ComponentModel;


namespace Gizmox.WebGUI.Forms.Design
{

    public class ToolStripItemCollectionEditor : System.ComponentModel.Design.CollectionEditor
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolStripItemCollectionEditor"/> class.
        /// </summary>
        public ToolStripItemCollectionEditor() : base(typeof(ToolStripItemCollection))
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
                    foreach (Type objType in DesignerUtils.FilterGenericTypes(service.GetTypes(typeof(ToolStripItem), false)))
                    {
                        if (!objTypes.Contains(objType))
                        {
                            if (this.ShouldAddNewItemType(objType))
                            {
                                objTypes.Add(objType);
                            }
                        }
                    }
                }
            }

            return (Type[])objTypes.ToArray(typeof(Type));

        }

        /// <summary>
        /// Shoulds the type of the add new item.
        /// </summary>
        /// <param name="objItemType">Type of the obj item.</param>
        /// <returns></returns>
        private bool ShouldAddNewItemType(Type objItemType)
        {
            if (!objItemType.IsAbstract)
            {
                if (this.Context != null)
                {
                    ToolStripItemDesignerAvailabilityAttribute objToolStripItemDesignerAvailabilityAttribute = TypeDescriptor.GetAttributes(objItemType)[typeof(ToolStripItemDesignerAvailabilityAttribute)] as ToolStripItemDesignerAvailabilityAttribute;
                    if (objToolStripItemDesignerAvailabilityAttribute != null)
                    {                        
                        return (objToolStripItemDesignerAvailabilityAttribute.ItemAdditionVisibility & this.DesignerAvailability) != ToolStripItemDesignerAvailability.None;
                    }
                }
            }

            return false;
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
            if (value != null)
            {
                return value.GetType().Name;
            }
            else
            {
                return base.GetDisplayText(value);
            }
        }

        /// <summary>
        /// Gets the designer availability.
        /// </summary>
        /// <value>The designer availability.</value>
        protected virtual ToolStripItemDesignerAvailability DesignerAvailability
        {
            get
            {
                return ToolStripItemDesignerAvailability.ToolStrip;
            }
        }
    }
}
