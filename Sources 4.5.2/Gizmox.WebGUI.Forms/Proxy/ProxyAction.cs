using System;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using Gizmox.WebGUI.Forms.Design;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms
{

    #region ProxyAction Class

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public abstract class ProxyAction : ICustomTypeDescriptor
    {
        #region Members

        private ProxyComponent mobjActionOwner = null;

        #endregion Members

        #region C'Tor


        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyAction"/> class.
        /// </summary>
        public ProxyAction()
        {
        }

        #endregion C'Tor

        #region Properties

        /// <summary>
        /// Gets or sets the action owner.
        /// </summary>
        /// <value>
        /// The action owner.
        /// </value>
        public ProxyComponent ActionOwner
        {
            get
            {
                return mobjActionOwner;
            }
            set
            {
                mobjActionOwner = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Executes action.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Gets the filtered custom properties.
        /// </summary>
        /// <param name="objPropertyDescriptorCollection">The object property descriptor collection.</param>
        /// <returns></returns>
        protected virtual PropertyDescriptorCollection GetFilteredCustomProperties(PropertyDescriptorCollection objPropertyDescriptorCollection)
        {
            return objPropertyDescriptorCollection;
        }

        /// <summary>
        /// Gets the custom properties.
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        private PropertyDescriptorCollection GetCustomProperties(Attribute[] attributes)
        {
            PropertyDescriptorCollection arrPropertyDescriptors = TypeDescriptor.GetProperties(this, attributes, true);
            List<PropertyDescriptor> arrFiltredDescriptors = new List<PropertyDescriptor>();

            foreach (PropertyDescriptor objPropertyDescriptor in arrPropertyDescriptors)
            {
                bool blnAddProperty = true;

                BrowsableAttribute objBrowsableAttribute = objPropertyDescriptor.Attributes[typeof(BrowsableAttribute)] as BrowsableAttribute;
                if (objBrowsableAttribute != null)
                {
                    blnAddProperty = objBrowsableAttribute.Browsable;
                }

                if (blnAddProperty)
                {
                    switch (objPropertyDescriptor.Name)
                    {
                        case "ActionOwner":
                            blnAddProperty = false;
                            break;
                    }
                }

                if (blnAddProperty)
                {
                    arrFiltredDescriptors.Add(objPropertyDescriptor);
                }
            }

            return GetFilteredCustomProperties(new PropertyDescriptorCollection(arrFiltredDescriptors.ToArray()));
        }

        #endregion Methods

        #region ICustomTypeDescriptor

        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        string ICustomTypeDescriptor.GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        string ICustomTypeDescriptor.GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            return GetCustomProperties(attributes);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return this.GetCustomProperties(null);
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        #endregion ICustomTypeDescriptor
    }

    #endregion ProxyAction Class
}