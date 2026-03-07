
using System;
using System.Collections.Generic;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class ProxySet : List<ProxyComponent>, ICustomTypeDescriptor
    {
		#region Fields

        private string mstrName = SR.GetString("ProxySet_NewSet");

		#endregion Fields 

		#region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ProxySet"/> class.
        /// </summary>
        public ProxySet()
        {
        }

		#endregion Constructors 

		#region Properties

        /// <summary>
        /// Gets or sets the name of the set.
        /// </summary>
        /// <value>
        /// The name of the set.
        /// </value>
        public string Name
        {
            get
            {
                return mstrName;
            }
            set
            {
                mstrName = value;
            }
        }

		#endregion Properties 

		#region Methods

        /// <summary>
        /// Renders the set.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        public void RenderSet(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            int intComponentsCount = this.Count;

            // Loop all controls.
            for (int intIndex = intComponentsCount - 1; intIndex > -1; intIndex -= 1)
            {
                ProxyComponent objProxyComponent = this[intIndex];
                if (objProxyComponent != null)
                {
                    objProxyComponent.Render(objContext, objWriter, lngRequestID);
                }
            }
        }

        /// <summary>
        /// Pres the render set.
        /// </summary>
        /// <param name="objContext">The object context.</param>
        /// <param name="lngRequestID">The LNG request identifier.</param>
        public void PreRenderSet(IContext objContext, long lngRequestID)
        {
            int intComponentsCount = this.Count;

            // Loop all controls.
            for (int intIndex = intComponentsCount - 1; intIndex > -1; intIndex -= 1)
            {
                ProxyComponent objProxyComponent = this[intIndex];
                if (objProxyComponent != null)
                {
                    objProxyComponent.PreRender(objContext, lngRequestID);
                }
            }
        }

        /// <summary>
        /// Posts the render set.
        /// </summary>
        /// <param name="objContext">The object context.</param>
        /// <param name="lngRequestID">The LNG request identifier.</param>
        public virtual void PostRenderSet(IContext objContext, long lngRequestID)
        {
            int intComponentsCount = this.Count;

            // Loop all controls.
            for (int intIndex = intComponentsCount - 1; intIndex > -1; intIndex -= 1)
            {
                ProxyComponent objProxyComponent = this[intIndex];
                if (objProxyComponent != null)
                {
                    objProxyComponent.PostRender(objContext, lngRequestID);
                }
            }
        }

        #endregion Methods

        #region ICustomTypeDescriptor Members

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

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] arrAttributes)
        {
            List<PropertyDescriptor> arrFiltredDescriptors = new List<PropertyDescriptor>();

            PropertyDescriptorCollection arrPropertyDescriptors = TypeDescriptor.GetProperties(this, arrAttributes, true);

            // Checking if a property is a proxybrowsable to show in emulator.
            foreach (PropertyDescriptor objPropertyDescriptor in arrPropertyDescriptors)
            {
                if (objPropertyDescriptor.Name == "Name")
                {
                    arrFiltredDescriptors.Add(objPropertyDescriptor);
                }
            }
            
            return new PropertyDescriptorCollection(arrFiltredDescriptors.ToArray());
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(null);
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor objPropertyDescriptor)
        {
            return this;
        }

        #endregion
    }
}
