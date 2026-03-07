namespace Gizmox.WebGUI.Forms.Design
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Security.Permissions;

    /// <summary>Provides a base class for property tabs.</summary>
    [Serializable]
	public abstract class PropertyTab : IExtenderProvider
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> class.</summary>
        protected PropertyTab()
        {
        }

        /// <summary>Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> can display properties for the specified component.</summary>
        /// <returns>true if the object can be extended; otherwise, false.</returns>
        /// <param name="objExtendee">The object to test. </param>
        public virtual bool CanExtend(object objExtendee)
        {
            return true;
        }

        /// <summary>Releases all the resources used by the <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see>.</summary>
        public virtual void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> and optionally releases the managed resources.</summary>
        /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources. </param>
        protected virtual void Dispose(bool blnDisposing)
        {
            if (blnDisposing && (this.mobjBitmap != null))
            {
                this.mobjBitmap.Dispose();
                this.mobjBitmap = null;
            }
        }

        /// <summary>Allows a <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> to attempt to free resources and perform other cleanup operations before the <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see> is reclaimed by garbage collection.</summary>
        ~PropertyTab()
        {
            this.Dispose(false);
        }

        /// <summary>Gets the default property of the specified component.</summary>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptor"></see> that represents the default property.</returns>
        /// <param name="objComponent">The component to retrieve the default property of. </param>
        public virtual PropertyDescriptor GetDefaultProperty(object objComponent)
        {
            return TypeDescriptor.GetDefaultProperty(objComponent);
        }

        /// <summary>Gets the properties of the specified component.</summary>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that contains the properties of the component.</returns>
        /// <param name="objComponent">The component to retrieve the properties of. </param>
        public virtual PropertyDescriptorCollection GetProperties(object objComponent)
        {
            return this.GetProperties(objComponent, null);
        }

        /// <summary>Gets the properties of the specified component that match the specified attributes.</summary>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that contains the properties.</returns>
        /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that indicates the attributes of the properties to retrieve. </param>
        /// <param name="objComponent">The component to retrieve properties from. </param>
        public abstract PropertyDescriptorCollection GetProperties(object objComponent, Attribute[] arrAttributes);
        /// <summary>Gets the properties of the specified component that match the specified attributes and context.</summary>
        /// <returns>A <see cref="T:System.ComponentModel.PropertyDescriptorCollection"></see> that contains the properties matching the specified context and attributes.</returns>
        /// <param name="objContext">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"></see> that indicates the context to retrieve properties from. </param>
        /// <param name="arrAttributes">An array of type <see cref="T:System.Attribute"></see> that indicates the attributes of the properties to retrieve. </param>
        /// <param name="objComponent">The component to retrieve properties from. </param>
        public virtual PropertyDescriptorCollection GetProperties(ITypeDescriptorContext objContext, object objComponent, Attribute[] arrAttributes)
        {
            return this.GetProperties(objComponent, arrAttributes);
        }


        /// <summary>Gets the bitmap that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see>.</summary>
        /// <returns>The <see cref="T:System.Drawing.Bitmap"></see> to display for the <see cref="T:Gizmox.WebGUI.Forms.Design.PropertyTab"></see>.</returns>

        public virtual System.Drawing.Bitmap Bitmap
        {
            get
            {
                if (!this.mblnCheckedBmp && (this.mobjBitmap == null))
                {
                    string strText1 = base.GetType().Name + ".bmp";
                    try
                    {
                        this.mobjBitmap = new System.Drawing.Bitmap(base.GetType(), strText1);
                    }
                    catch (Exception)
                    {
                    }
                    this.mblnCheckedBmp = true;
                }
                return this.mobjBitmap;
            }
        }

        /// <summary>Gets or sets the array of components the property tab is associated with.</summary>
        /// <returns>The array of components the property tab is associated with.</returns>
        public virtual object[] Components
        {
            get
            {
                return this.marrComponents;
            }
            set
            {
                this.marrComponents = value;
            }
        }

        /// <summary>Gets the Help keyword that is to be associated with this tab.</summary>
        /// <returns>The Help keyword to be associated with this tab.</returns>
        public virtual string HelpKeyword
        {
            get
            {
                return this.TabName;
            }
        }

        /// <summary>Gets the name for the property tab.</summary>
        /// <returns>The name for the property tab.</returns>
        public abstract string TabName { get; }


        private System.Drawing.Bitmap mobjBitmap;
        private bool mblnCheckedBmp;
        private object[] marrComponents;
    }
}

