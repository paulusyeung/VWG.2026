using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class EmptyExpandableObjectConverter : ExpandableObjectConverter
    {
        #region C'Tor

        /// <summary>
        ///
        /// </summary>
        public EmptyExpandableObjectConverter()
        {

        }

        #endregion C'Tor

        #region Methods

        /// <summary>
        /// Gets a collection of properties for the type of object specified by the value parameter.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
        /// <param name="value">An <see cref="T:System.Object" /> that specifies the type of object to get the properties for.</param>
        /// <param name="attributes">An array of type <see cref="T:System.Attribute" /> that will be used as a filter.</param>
        /// <returns>
        /// A <see cref="T:System.ComponentModel.PropertyDescriptorCollection" /> with the properties that are exposed for the component, or null if there are no properties.
        /// </returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return null;
        }

        #endregion Methods
    }
}
