using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Design;
using System.Drawing;
using System.ComponentModel;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using Gizmox.WebGUI.Common.Resources;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageIndexEditor : UITypeEditor
    {        
		#region Fields 

        protected WebForms.ImageList currentImageList;
		protected PropertyDescriptor currentImageListProp;
		protected object currentInstance;
		protected UITypeEditor imageEditor = ((UITypeEditor)TypeDescriptor.GetEditor(typeof(Image), typeof(UITypeEditor)));
		protected string imageListPropertyName;
		protected string parentImageListProperty = "Parent";

		#endregion 

		#region Properties 

        /// <summary>
        /// Gets the image editor.
        /// </summary>
        /// <value>The image editor.</value>
		internal UITypeEditor ImageEditor
        {
            get
            {
                return this.imageEditor;
            }
        }

        /// <summary>
        /// Gets the parent image list property.
        /// </summary>
        /// <value>The parent image list property.</value>
		internal string ParentImageListProperty
        {
            get
            {
                return this.parentImageListProperty;
            }
        }
		
		#endregion 

		#region Methods 


        /// <summary>
        /// Indicates whether the specified context supports painting a representation of an object's value within the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
        /// <returns>
        /// true if <see cref="M:System.Drawing.Design.UITypeEditor.PaintValue(System.Object,System.Drawing.Graphics,System.Drawing.Rectangle)"/> is implemented; otherwise, false.
        /// </returns>
		public override bool GetPaintValueSupported(ITypeDescriptorContext context)
        {
            return ((this.imageEditor != null) && this.imageEditor.GetPaintValueSupported(context));
        }

        /// <summary>
        /// Paints a representation of the value of an object using the specified <see cref="T:System.Drawing.Design.PaintValueEventArgs"/>.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Drawing.Design.PaintValueEventArgs"/> that indicates what to paint and where to paint it.</param>
		public override void PaintValue(PaintValueEventArgs e)
        {
            if (this.ImageEditor != null)
            {
                ResourceHandle objResourceHandle = null;
                if (e.Value is int)
                {
                    objResourceHandle = this.GetImage(e.Context, (int)e.Value, null, true);
                }
                else if (e.Value is string)
                {
                    objResourceHandle = this.GetImage(e.Context, -1, (string)e.Value, false);
                }
                if (objResourceHandle != null)
                {
                    this.ImageEditor.PaintValue(new PaintValueEventArgs(e.Context, objResourceHandle, e.Graphics, e.Bounds));
                }
            }
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="index">The index.</param>
        /// <param name="key">The key.</param>
        /// <param name="useIntIndex">if set to <c>true</c> [use int index].</param>
        /// <returns></returns>
        protected virtual ResourceHandle GetImage(ITypeDescriptorContext context, int index, string key, bool useIntIndex)
        {
            ResourceHandle objResourceHandle = null;
            object instance = context.Instance;
            if (!(instance is object[]))
            {
                if ((index < 0) && (key == null))
                {
                    return objResourceHandle;
                }
                if (((this.currentImageList == null) || (instance != this.currentInstance)) || ((this.currentImageListProp != null) && (((WebForms.ImageList)this.currentImageListProp.GetValue(this.currentInstance)) != this.currentImageList)))
                {
                    this.currentInstance = instance;
                    PropertyDescriptor imageListProperty = ImageListUtils.GetImageListProperty(context.PropertyDescriptor, ref instance);
                    while ((instance != null) && (imageListProperty == null))
                    {
                        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(instance);
                        foreach (PropertyDescriptor descriptor2 in properties)
                        {
                            if (typeof(WebForms.ImageList).IsAssignableFrom(descriptor2.PropertyType))
                            {
                                imageListProperty = descriptor2;
                                break;
                            }
                        }
                        if (imageListProperty == null)
                        {
                            PropertyDescriptor descriptor3 = properties[this.ParentImageListProperty];
                            if (descriptor3 != null)
                            {
                                instance = descriptor3.GetValue(instance);
                                continue;
                            }
                            instance = null;
                        }
                    }
                    if (imageListProperty != null)
                    {
                        this.currentImageList = (WebForms.ImageList)imageListProperty.GetValue(instance);
                        this.currentImageListProp = imageListProperty;
                        this.currentInstance = instance;
                    }
                }
                if (this.currentImageList != null)
                {
                    if (useIntIndex)
                    {
                        if ((this.currentImageList != null) && (index < this.currentImageList.Images.Count))
                        {
                            index = (index > 0) ? index : 0;
                            objResourceHandle = this.currentImageList.Images[index];
                        }
                        return objResourceHandle;
                    }
                    return this.currentImageList.Images[key];
                }
            }
            return null;
        }
		
		#endregion 
    }
}
