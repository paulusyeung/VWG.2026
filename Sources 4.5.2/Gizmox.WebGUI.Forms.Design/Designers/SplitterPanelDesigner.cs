using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Design;
using System.ComponentModel;
using System.Collections;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// 
    /// </summary>
    public class SplitterPanelDesigner : ComponentDesigner
    {
        /// <summary>
        /// Allows a designer to add to the set of properties that it exposes through a <see cref="T:System.ComponentModel.TypeDescriptor"/>.
        /// </summary>
        /// <param name="properties">The properties for the class of the component.</param>
        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            base.PreFilterProperties(properties);

            properties.Remove("Modifiers");
            properties.Remove("Locked");
            properties.Remove("GenerateMember");
            foreach (DictionaryEntry entry in properties)
            {
                PropertyDescriptor oldPropertyDescriptor = (PropertyDescriptor)entry.Value;
                if (oldPropertyDescriptor.Name.Equals("Name") && oldPropertyDescriptor.DesignTimeOnly)
                {
                    properties[entry.Key] = TypeDescriptor.CreateProperty(oldPropertyDescriptor.ComponentType, oldPropertyDescriptor, new Attribute[] { BrowsableAttribute.No, DesignerSerializationVisibilityAttribute.Hidden });
                    break;
                }
            }
        }
    }
}
