using System;
using System.Drawing;
using System.Drawing.Design;
using System.ComponentModel;
using System.ComponentModel.Design;

using Gizmox.WebGUI.Common.Resources;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Gizmox.WebGUI.Forms.Design
{
    /// <summary>
    /// 
    /// </summary>
	public class ImageCollectionEditor : System.ComponentModel.Design.CollectionEditor
	{
		#region Fields 

		private ImageListImageCollection mobjImageListImageCollection = null;

		#endregion 

		#region Constructors 

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageCollectionEditor"/> class.
        /// </summary>
        /// <param name="type">The type of the collection for this editor to edit.</param>
		public ImageCollectionEditor(Type type) : base(type)
		{
		}
		
		#endregion 

		#region Methods 

        /// <summary>
        /// Edits the value of the specified object using the specified service provider and context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that can be used to gain additional context information.</param>
        /// <param name="provider">A service provider object through which editing services can be obtained.</param>
        /// <param name="value">The object to edit the value of.</param>
        /// <returns>
        /// The new value of the object. If the value of the object has not changed, this should return the same object it was passed.
        /// </returns>
        /// <exception cref="T:System.ComponentModel.Design.CheckoutException">An attempt to check out a file that is checked into a source code management program did not succeed.</exception>
		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            mobjImageListImageCollection = new ImageListImageCollection();

            mobjImageListImageCollection.Load((ImageList.ImageCollection)value);

            base.EditValue(context, provider, mobjImageListImageCollection);

            mobjImageListImageCollection.Save((ImageList.ImageCollection)value);

            return (ImageList.ImageCollection)value;

        }

        /// <summary>
        /// Creates a new instance of the specified collection item type.
        /// </summary>
        /// <param name="itemType">The type of item to create.</param>
        /// <returns>A new instance of the specified object.</returns>
		protected override object CreateInstance(Type itemType)
        {
            ResourceHandleEditor objResourceHandleEditor = new ResourceHandleEditor();
            ImageListImage objImageListImage = null;

            ResourceHandle objResourceHandle = objResourceHandleEditor.EditValue(this.Context, this.Context.Container as IServiceProvider, null) as ResourceHandle;

            if (objResourceHandle != null)
            {
                string strName = objResourceHandle.File;

                if (mobjImageListImageCollection != null && mobjImageListImageCollection.Count > 0)
                {
                    List<string> arrNames = new List<string>();

                    foreach (ImageListImage objChildImageListImage in mobjImageListImageCollection)
                    {
                        arrNames.Add(objChildImageListImage.Name);
                    }

                    if (arrNames.Contains(strName))
                    {
                        int intNameCounter = 1;

                        while (arrNames.Contains(string.Format("{0}{1}", strName, intNameCounter.ToString())))
                        {
                            intNameCounter += 1;
                        }

                        strName = string.Format("{0}{1}", strName, intNameCounter.ToString());
                    }
                }

                objImageListImage = new ImageListImage(mobjImageListImageCollection, objResourceHandle, strName);
            }

            return objImageListImage;
        }


        /// <summary>
        /// Returns a list containing the given object
        /// </summary>
        /// <param name="instance">An <see cref="T:System.Collections.ArrayList"/> returned as an object.</param>
        /// <returns>
        /// An <see cref="T:System.Collections.ArrayList"/> which contains the individual objects to be created.
        /// </returns>
        protected override System.Collections.IList GetObjectsFromInstance(object instance)
        {
            if (instance != null)
            {
                return base.GetObjectsFromInstance(instance);
            }
            return null;
        }

		#endregion 

		#region Nested Classes 

        #region ImageListImage Class

        /// <summary>
        /// 
        /// </summary>
        internal class ImageListImage
        {
            #region Fields

            private Bitmap mobjImage = null;
            private ImageListImageCollection mobjOwner = null;
            private ResourceHandle mobjResourceHandler = null;
            private static Bitmap mobjStaticImage = null;
            private string mstrName = null;

            #endregion

            #region Constructors

            /// <summary>
            /// Initializes a new instance of the <see cref="ImageListImage"/> class.
            /// </summary>
            /// <param name="objOwner">The obj owner.</param>
            /// <param name="resourceHandler">The resource handler.</param>
            /// <param name="name">The name.</param>
            public ImageListImage(ImageListImageCollection objOwner, ResourceHandle resourceHandler, string name)
                : this(objOwner, resourceHandler)
            {
                this.Name = name;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ImageListImage"/> class.
            /// </summary>
            /// <param name="objOwner">The obj owner.</param>
            /// <param name="resourceHandler">The resource handler.</param>
            public ImageListImage(ImageListImageCollection objOwner, ResourceHandle resourceHandler)
            {
                this.mobjResourceHandler = resourceHandler;
                this.mobjImage = mobjStaticImage;
                this.mobjOwner = objOwner;
            }

            /// <summary>
            /// Initializes the <see cref="ImageListImage"/> class.
            /// </summary>
            static ImageListImage()
            {
                mobjStaticImage = new Bitmap(16, 16);
            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets the horizontal resolution.
            /// </summary>
            /// <value>The horizontal resolution.</value>
            public float HorizontalResolution
            {
                get
                {
                    return this.mobjImage.HorizontalResolution;
                }
            }

            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name
            {
                get
                {
                    if (this.mstrName != null)
                    {
                        return this.mstrName;
                    }              
                    return string.Empty;
                }
                set
                {
                    if (this.mstrName != value)
                    {
                        if (mobjOwner != null)
                        {
                            foreach (ImageListImage objImageListImage in mobjOwner)
                            {
                                if (objImageListImage != this &&
                                    objImageListImage.Name == value)
                                {
                                    throw new Exception(string.Format("Image name '{0}' already exist in list.", value));
                                }
                            }
                        }

                        this.mstrName = value;

                        this.mobjOwner.IsDirty = true;
                    }
                }
            }

            /// <summary>
            /// Gets the physical dimension.
            /// </summary>
            /// <value>The physical dimension.</value>
            public SizeF PhysicalDimension
            {
                get
                {
                    return (SizeF)this.mobjImage.Size;
                }
            }

            /// <summary>
            /// Gets the pixel format.
            /// </summary>
            /// <value>The pixel format.</value>
            public PixelFormat PixelFormat
            {
                get
                {
                    return this.mobjImage.PixelFormat;
                }
            }

            /// <summary>
            /// Gets the raw format.
            /// </summary>
            /// <value>The raw format.</value>
            public ImageFormat RawFormat
            {
                get
                {
                    return this.mobjImage.RawFormat;
                }
            }

            /// <summary>
            /// Gets the resource.
            /// </summary>
            /// <value>The resource.</value>
            [Browsable(false)]
            public ResourceHandle Resource
            {
                get { return mobjResourceHandler; }
            }

            /// <summary>
            /// Gets the size.
            /// </summary>
            /// <value>The size.</value>
            public Size Size
            {
                get
                {
                    return this.mobjImage.Size;
                }
            }

            /// <summary>
            /// Gets the vertical resolution.
            /// </summary>
            /// <value>The vertical resolution.</value>
            public float VerticalResolution
            {
                get
                {
                    return this.mobjImage.VerticalResolution;
                }
            }

            #endregion

            #region Methods

            /// <summary>
            /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
            /// </returns>
            public override string ToString()
            {
                return this.Name;
            }

            #endregion
        } 

        #endregion

        #region ImageListImageCollection Class

        /// <summary>
        /// 
        /// </summary>
        internal class ImageListImageCollection : Collection<ImageListImage>
        {
            #region Fields

            private bool mblnIsDirty = false;

            #endregion

            #region Methods

            /// <summary>
            /// Removes all elements from the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
            /// </summary>
            protected override void ClearItems()
            {
                base.ClearItems();

                // Flag "Dirty" for save action.
                this.IsDirty = true;
            }

            /// <summary>
            /// Inserts the item.
            /// </summary>
            /// <param name="intIndex">Index of the int.</param>
            /// <param name="objItem">The obj item.</param>
            protected override void InsertItem(int intIndex, ImageListImage objItem)
            {
                base.InsertItem(intIndex, objItem);

                // Flag "Dirty" for save action.
                this.IsDirty = true;
            }

            /// <summary>
            /// Sets the item.
            /// </summary>
            /// <param name="intIndex">Index of the int.</param>
            /// <param name="objItem">The obj item.</param>
            protected override void SetItem(int intIndex, ImageListImage objItem)
            {
                base.SetItem(intIndex, objItem);

                // Flag "Dirty" for save action.
                this.IsDirty = true;
            }

            /// <summary>
            /// Removes the element at the specified index of the <see cref="T:System.Collections.ObjectModel.Collection`1"/>.
            /// </summary>
            /// <param name="index">The zero-based index of the element to remove.</param>
            /// <exception cref="T:System.ArgumentOutOfRangeException">
            /// 	<paramref name="index"/> is less than zero.-or-<paramref name="index"/> is equal to or greater than <see cref="P:System.Collections.ObjectModel.Collection`1.Count"/>.</exception>
            protected override void RemoveItem(int index)
            {
                base.RemoveItem(index);

                // Flag "Dirty" for save action.
                this.IsDirty = true;
            }

            /// <summary>
            /// Loads the specified obj image collection.
            /// </summary>
            /// <param name="objImageCollection">The obj image collection.</param>
            internal void Load(ImageList.ImageCollection objImageCollection)
            {
                for(int i=0; i<objImageCollection.Count; i++)
                {
                    this.Add(new ImageListImage(this, objImageCollection[i], objImageCollection.KeyOfIndex(i)));
                }

                // Flag "Dirty" for save action.
                this.IsDirty = false;
            }

            /// <summary>
            /// Saves the specified obj image collection.
            /// </summary>
            /// <param name="objImageCollection">The obj image collection.</param>
            internal void Save(ImageList.ImageCollection objImageCollection)
            {
                if (IsDirty)
                {
                    objImageCollection.Clear();
                    foreach (ImageListImage objImage in this)
                    {
                        objImageCollection.Add(objImage.Name, objImage.Resource);
                    }

                    // Flag "Dirty" for save action.
                    this.IsDirty = false;
                }
            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets or sets a value indicating whether this instance is dirty.
            /// </summary>
            /// <value><c>true</c> if this instance is dirty; otherwise, <c>false</c>.</value>
            public bool IsDirty
            {
                get
                {
                    return mblnIsDirty;
                }
                set
                {
                    mblnIsDirty = value;
                }
            }

            #endregion
        } 

        #endregion

		#endregion 
	}
}
