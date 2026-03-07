using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using WinForms = System.Windows.Forms;
using System.Windows.Forms;

namespace Gizmox.WebGUI.Forms.Design
{
    internal static class ImageListUtils
    {

        #region Static Methods

        /// <summary>
        /// Gets the image list property.
        /// </summary>
        /// <param name="currentComponent">The current component.</param>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        public static PropertyDescriptor GetImageListProperty(PropertyDescriptor currentComponent, ref object instance)
        {
            if (instance is object[])
            {
                return null;
            }
            PropertyDescriptor descriptor = null;
            object component = instance;
            RelatedImageListAttribute attribute = currentComponent.Attributes[typeof(RelatedImageListAttribute)] as RelatedImageListAttribute;
            if (attribute != null)
            {
                string[] strArray = attribute.RelatedImageList.Split(new char[] { '.' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (component == null)
                    {
                        return descriptor;
                    }
                    PropertyDescriptor descriptor2 = TypeDescriptor.GetProperties(component)[strArray[i]];
                    if (descriptor2 == null)
                    {
                        return descriptor;
                    }
                    if (i == (strArray.Length - 1))
                    {
                        if (typeof(ImageList).IsAssignableFrom(descriptor2.PropertyType))
                        {
                            instance = component;
                            return descriptor2;
                        }
                    }
                    else
                    {
                        component = descriptor2.GetValue(component);
                    }
                }
            }
            return descriptor;
        }

        #endregion
    }


}
