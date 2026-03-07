#region Using

using System;
using System.Drawing;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using System.ComponentModel.Design.Serialization;
using System.Runtime.Serialization;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
	#region ImageList Class
	
	/// <summary>
	/// Summary description for ImageList.
	/// </summary>
	[ToolboxItem(true)]
    [System.ComponentModel.DesignTimeVisible(true)]
	[ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
    [ToolboxItemCategory("Components")]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmapAttribute(typeof(ImageList), "ImageList_45.bmp")]
#else
    [ToolboxBitmapAttribute(typeof(ImageList), "ImageList.bmp")]
#endif
#if WG_NET46
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ImageListCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ImageListCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ImageListCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ImageListCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ImageListCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ImageListCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ImageListCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#else
    [System.ComponentModel.Design.Serialization.DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ImageListCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif
    [Serializable]
    public class ImageList : ComponentBase
	{
		#region Classes
		
		#region ImageCollection Class
		
		/// <summary>Encapsulates the collection of <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> objects in an <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</summary>
#if WG_NET46
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.ImageCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.ImageCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.ImageCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.ImageCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.ImageCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.ImageCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
        [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.ImageCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#else
    [System.ComponentModel.Editor("Gizmox.WebGUI.Forms.Design.ImageCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=1.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif

        [Serializable()]
        public sealed class ImageCollection : IList, IEnumerable, ICollection
		{

			private ArrayList mobjItems;
			private Hashtable mobjKeys;

            internal ImageCollection(ImageList objOwnerList)
			{
				this.mobjItems = new ArrayList();
				this.mobjKeys = new Hashtable();
			}

			/// <summary>Adds the specified image to the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</summary>
            /// <param name="objValue">A <see cref="T:System.Drawing.Bitmap"></see> of the image to add to the list. </param>
			/// <exception cref="T:System.Exception">The image could not be added.  </exception>
			/// <exception cref="T:System.ArgumentException">The image being added is not a <see cref="T:System.Drawing.Bitmap"></see>. </exception>
			/// <exception cref="T:System.ArgumentNullException">The image being added is null. </exception>
			public void Add(ResourceHandle objValue)
			{
				this.mobjItems.Add(objValue);
			}

			/// <summary>Adds an image with the specified key to the end of the collection.</summary>
            /// <param name="objImage">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to add to the collection.</param>
			/// <param name="strKey">The name of the image.</param>
			/// <exception cref="T:System.ArgumentNullException">image is null. </exception>
            public void Add(string strKey, ResourceHandle objImage)
			{
                this.mobjItems.Add(objImage);
                this.mobjKeys.Add(strKey, objImage);
			}

			/// <summary>
			/// Adds a new icon using a key
			/// </summary>
			/// <param name="strKey"></param>
            /// <param name="strIcon"></param>
            public void AddIcon(string strKey, string strIcon)
			{
                this.Add(strKey, new IconResourceHandle(strIcon));
			}

			/// <summary>
			/// Adds a new icon
			/// </summary>
            /// <param name="strIcon"></param>
			public void AddIcon(string strIcon)
			{
                this.Add(new IconResourceHandle(strIcon));
			}

			/// <summary>
			/// Adds a new image using a key
			/// </summary>
			/// <param name="strKey"></param>
            /// <param name="strImage"></param>
			public void AddImage(string strKey, string strImage)
			{
                this.Add(strKey, new ImageResourceHandle(strImage));
			}

			/// <summary>
			/// Adds a new image
			/// </summary>
            /// <param name="strImage"></param>
			public void AddImage(string strImage)
			{
                this.Add(new ImageResourceHandle(strImage));
			}

			/// <summary>Adds an array of images to the collection.</summary>
            /// <param name="arrImages">The array of <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> objects to add to the collection.</param>
			/// <exception cref="T:System.ArgumentNullException">images is null.</exception>
			public void AddRange(ResourceHandle[] arrImages)
			{
				this.mobjItems.AddRange(arrImages);
			}

			/// <summary>Removes all the images and masks from the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</summary>
			public void Clear()
			{
				this.mobjItems.Clear();
				this.mobjKeys.Clear();
			}

			/// <summary>Not supported. The <see cref="M:System.Collections.IList.Contains(System.Object)"></see> method indicates whether a specified object is contained in the list.</summary>
			/// <returns>true if the image is found in the list; otherwise, false.</returns>
            /// <param name="objImage">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to find in the list. </param>
			/// <exception cref="T:System.NotSupportedException">This method is not supported. </exception>
			[EditorBrowsable(EditorBrowsableState.Never)]
            public bool Contains(ResourceHandle objImage)
			{
                return this.mobjItems.Contains(objImage);
			}

			/// <summary>Determines if the collection contains an image with the specified key.</summary>
			/// <returns>true to indicate an image with the specified key is contained in the collection; otherwise, false. </returns>
			/// <param name="strKey">The key of the image to search for.</param>
			public bool ContainsKey(string strKey)
			{
                return this.mobjKeys.Contains(strKey);
			}

			/// <summary>Returns an enumerator that can be used to iterate through the item collection.</summary>
			/// <returns>An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
			public IEnumerator GetEnumerator()
			{
				return this.mobjItems.GetEnumerator();
			}

			/// <summary>Not supported. The <see cref="M:System.Collections.IList.IndexOf(System.Object)"></see> method returns the index of a specified object in the list.</summary>
			/// <returns>The index of the image in the list.</returns>
            /// <param name="objImage">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to find in the list. </param>
			/// <exception cref="T:System.NotSupportedException">This method is not supported. </exception>
			[EditorBrowsable(EditorBrowsableState.Never)]
			public int IndexOf(ResourceHandle objImage)
			{
				return this.mobjItems.IndexOf(objImage);
			}

			/// <summary>Determines the index of the first occurrence of an image with the specified key in the collection.</summary>
			/// <returns>The zero-based index of the first occurrence of an image with the specified key in the collection, if found; otherwise, -1.</returns>
			/// <param name="strKey">The key of the image to retrieve the index for.</param>
			public int IndexOfKey(string strKey)
			{
                ResourceHandle objResource = this.mobjKeys[strKey] as ResourceHandle;
				if(objResource!=null)
				{
					return this.IndexOf(objResource);
				}
				else
				{
					return -1;
				}
			}

            /// <summary>Determines the key of the image with the specified index.</summary>
            /// <returns>The key that was found for the index or null if key was not found.</returns>
            /// <param name="intIndex">The index of the image to retrieve the key for.</param>
            public string KeyOfIndex(int intIndex)
            {
                ResourceHandle objResource = this[intIndex];
                if (objResource != null)
                {
                    foreach (string strKey in mobjKeys.Keys)
                    {
                        if (mobjKeys[strKey] == objResource)
                        {
                            return strKey;
                        }
                    }
                }
                return null;
            }

			/// <summary>Not supported. The <see cref="M:System.Collections.IList.Remove(System.Object)"></see> method removes a specified object from the list.</summary>
            /// <param name="objImage">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to remove from the list. </param>
			/// <exception cref="T:System.NotSupportedException">This method is not supported. </exception>
			[EditorBrowsable(EditorBrowsableState.Never)]
            public void Remove(ResourceHandle objImage)
			{
                if (this.mobjItems.Contains(objImage)) this.mobjItems.Remove(objImage);
                if (this.mobjKeys.ContainsValue(objImage)) 
				{
					foreach(object objKey in this.mobjKeys.Keys)
					{
                        if (this.mobjKeys[objKey] == objImage)
						{
							this.mobjKeys.Remove(objKey);
							break;
						}
					}
				}
			}

			/// <summary>Removes an image from the list.</summary>
			/// <param name="index">The index of the image to remove. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index value was less than 0.-or- The index value is greater than or equal to the <see cref="P:Gizmox.WebGUI.Forms.ImageList.ImageCollection.Count"></see> of images. </exception>
			/// <exception cref="T:System.InvalidOperationException">The image cannot be removed. </exception>
			public void RemoveAt(int index)
			{
                ResourceHandle objImage = this.mobjItems[index] as ResourceHandle;
                if (objImage != null)
				{
                    this.Remove(objImage);
				}
			}

			/// <summary>Removes the image with the specified key from the collection.</summary>
			/// <param name="strKey">The key of the image to remove from the collection.</param>
			public void RemoveByKey(string strKey)
			{
                ResourceHandle objImage = this.mobjKeys[strKey] as ResourceHandle;
                if (objImage != null)
				{
                    this.Remove(objImage);
				}
			}

			/// <summary>Sets the key for an image in the collection.</summary>
			/// <param name="strName">The name of the image to be set as the image key.</param>
			/// <param name="index">The zero-based index of an image in the collection.</param>
			/// <exception cref="T:System.IndexOutOfRangeException">The specified index is less than 0 or greater than or equal to <see cref="P:Gizmox.WebGUI.Forms.ImageList.ImageCollection.Count"></see>.</exception>
			public void SetKeyName(int index, string strName)
			{
				this.mobjKeys[strName] = this.mobjItems[index];
			}

			/// <summary>Gets the number of images currently in the list.</summary>
			/// <returns>The number of images in the list. The default is 0.</returns>
			[Browsable(false)]
			public int Count 
			{
				get
				{
					return this.mobjItems.Count;
				}
			}

			/// <summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> has any images.</summary>
			/// <returns>true if there are no images in the list; otherwise, false. The default is false.</returns>
			public bool Empty 
			{
				get
				{
					return this.mobjItems.Count==0;
				}
			}

			/// <summary>Gets a value indicating whether the list is read-only.</summary>
			/// <returns>Always false.</returns>
			public bool IsReadOnly 
			{
				get
				{
					return false;
				}
			}

			/// <summary>Gets an <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> with the specified key from the collection.</summary>
			/// <returns>The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> with the specified key.</returns>
			/// <param name="strKey">The name of the image to retrieve from the collection.</param>
            public ResourceHandle this[string strKey] 
			{
				get
				{
                    return this.mobjKeys[strKey] as ResourceHandle;
				}
			}

			/// <summary>Gets or sets an <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> at the specified index within the collection.</summary>
			/// <returns>The image in the list specified by index. </returns>
			/// <param name="index">The index of the image to get or set. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index is less than 0 or greater than or equal to <see cref="P:Gizmox.WebGUI.Forms.ImageList.ImageCollection.Count"></see>. </exception>
			/// <exception cref="T:System.InvalidOperationException">The image cannot be added to the list.</exception>
			/// <exception cref="T:System.ArgumentException">image is not a<see cref="T:System.Drawing.Bitmap"></see>.</exception>
			/// <exception cref="T:System.ArgumentNullException">The image to be assigned is null or not a <see cref="T:System.Drawing.Bitmap"></see>. </exception>
			//[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
			public ResourceHandle this[int index] 
			{
				get
				{
					return this.mobjItems[index] as ResourceHandle;
				}
				set
				{
					this.mobjItems[index] = value;
				}
			}

			/// <summary>Gets the collection of keys associated with the images in the <see cref="T:Gizmox.WebGUI.Forms.ImageList.ImageCollection"></see>.</summary>
			/// <returns>A <see cref="T:System.Collections.Specialized.StringCollection"></see> containing the names of the images in the <see cref="T:Gizmox.WebGUI.Forms.ImageList.ImageCollection"></see>.</returns>
			public StringCollection Keys 
			{
				get
				{
					StringCollection objStrings = new StringCollection();

                    if (this.mobjItems != null && this.mobjItems.Count > 0)
                    {
                        for (int i = 0; i < this.mobjItems.Count; i++)
                        {
                            objStrings.Add(this.KeyOfIndex(i));
                        }
                    }

					return objStrings;
				}
			}
		
            #region IList Members

			object System.Collections.IList.this[int index]
			{
				get
				{
					return this[index];
				}
				set
				{
					this[index]=(ResourceHandle)value;
				}
			}

			void System.Collections.IList.RemoveAt(int index)
			{
				this.RemoveAt(index);
			}

			void System.Collections.IList.Insert(int index, object objValue)
			{
                this[index] = (ResourceHandle)objValue;
			}

			void System.Collections.IList.Remove(object objValue)
			{
                this.Remove((ResourceHandle)objValue);
			}

			bool System.Collections.IList.Contains(object objValue)
			{
                return this.Contains((ResourceHandle)objValue);
			}

			void System.Collections.IList.Clear()
			{
				this.Clear();
			}

			int System.Collections.IList.IndexOf(object objValue)
			{
                return this.IndexOf((ResourceHandle)objValue);
			}

			int System.Collections.IList.Add(object objValue)
			{
                this.Add((ResourceHandle)objValue);
                return this.IndexOf((ResourceHandle)objValue);
			}

			bool System.Collections.IList.IsFixedSize
			{
				get
				{
					return false;
				}
			}

			#endregion

			#region ICollection Members

			bool ICollection.IsSynchronized
			{
				get
				{
					return false;
				}
			}

            void ICollection.CopyTo(Array objArray, int index)
			{
                this.mobjItems.CopyTo(objArray, index);
			}

			object ICollection.SyncRoot
			{
				get
				{
					return this.mobjItems.SyncRoot;
				}
			}

			#endregion

			#region IEnumerable Members

			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.mobjItems.GetEnumerator();
			}

			#endregion
		}

		#endregion ImageCollection Class
		
		#endregion Classes
		
		#region Class Members
		
		/// <summary>
		/// Image collection
		/// </summary>
		private ImageCollection		mobjImageCollection		= null;
		
		private Size				mobjImageSize;
		
		private object				mobjTag = null;

        /// <summary>
        /// The TransparentColor property registration.
        /// </summary>
        private static readonly SerializableProperty TransparentColorProperty = SerializableProperty.Register("TransparentColor", typeof(Color), typeof(ImageList));

        /// <summary>
        /// The ImageStream property registration.
        /// </summary>
        private static readonly SerializableProperty ImageStreamProperty = SerializableProperty.Register("ImageStream", typeof(ImageListStreamer), typeof(ImageList));

        /// <summary>
        /// The ImageStream property registration.
        /// </summary>
        private static readonly SerializableProperty ColorDepthProperty = SerializableProperty.Register("ColorDepth", typeof(ColorDepth), typeof(ImageList),new SerializablePropertyMetadata(ColorDepth.Depth32Bit));                                    

		
		#endregion Class Members
		
		#region C'Tor / D'Tor
		
		/// <summary>
		///
		/// </summary>
		static ImageList()
		{
			
		}
		
		/// <summary>
		///
		/// </summary>
		public ImageList()
		{
			mobjImageSize = new Size(0x10,0x10);
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objContainer"></param>
		public ImageList(IContainer objContainer)
		{
            objContainer.Add(this);
		}
		
		#endregion C'Tor / D'Tor

		#region Properties

		/// <summary>Gets a value indicating whether the underlying Win32 handle has been created.</summary>
		/// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.ImageList.Handle"></see> has been created; otherwise, false. The default is false.</returns>
		/// <filterpriority>1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false), SRDescription("ImageListHandleCreatedDescr"), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool HandleCreated 
		{
			get
			{
				return true;
			}
		}

		/// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ImageList.ImageCollection"></see> for this image list.</summary>
		/// <returns>The collection of images.</returns>
		/// <filterpriority>1</filterpriority>
		/// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatAppearance"), SRDescription("ImageListImagesDescr")]
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
		public ImageCollection Images 
		{
			get
			{
				if (mobjImageCollection == null)
				{
					mobjImageCollection = new ImageCollection(this);
				}
				return mobjImageCollection;
			}
		}

		/// <summary>Gets or sets the size of the images in the image list.</summary>
		/// <returns>The <see cref="T:System.Drawing.Size"></see> that defines the height and width, in pixels, of the images in the list. The default size is 16 by 16. The maximum size is 256 by 256.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The new size has a dimension less than 0 or greater than 256.</exception>
		/// <exception cref="T:System.ArgumentException">The value assigned is equal to <see cref="P:System.Drawing.Size.IsEmpty"></see>.-or- The value of the height or width is less than or equal to 0.-or- The value of the height or width is greater than 256. </exception>
		/// <filterpriority>1</filterpriority>
		/// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("ImageListSizeDescr"), SRCategory("CatBehavior"), Localizable(true),Browsable(true)]
		public Size ImageSize 
		{
			get
			{
				return this.mobjImageSize;
			}
			set
			{
				this.mobjImageSize = value;
			}
		}

		/// <summary>Gets or sets an object that contains additional data about the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</summary>
		/// <returns>An <see cref="T:System.Object"></see> that contains additional data about the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</returns>
		/// <filterpriority>1</filterpriority>
		[TypeConverter(typeof(StringConverter)), Localizable(false), Bindable(true), SRDescription("ControlTagDescr"), SRCategory("CatData"), DefaultValue((string) null)]
		public object Tag 
		{
			get
			{
				return mobjTag;
			}
			set
			{
				mobjTag = value;
			}
		}

        /// <summary>
        /// Gets or sets the color of the transparent.
        /// </summary>
        /// <value>
        /// The color of the transparent.
        /// </value>
		[Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public Color TransparentColor
        {
            get
            {
                return this.GetValue<Color>(ImageList.TransparentColorProperty);
            }
            set
            {
                this.SetValue<Color>(ImageList.TransparentColorProperty, value);
            }
        }

        /// <summary>Gets the handle to the <see cref="T:System.Windows.Forms.ImageListStreamer"></see> associated with this image list.</summary>
        /// <returns>null if the image list is empty; otherwise, a handle to the <see cref="T:System.Windows.Forms.ImageListStreamer"></see> for this <see cref="T:System.Windows.Forms.ImageList"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false), DefaultValue((string)null), SRDescription("ImageListImageStreamDescr")]
        public ImageListStreamer ImageStream
        {
            get
            {
                return this.GetValue<ImageListStreamer>(ImageList.ImageStreamProperty);
            }
            set
            {
                // Set new value.
                if (this.SetValue<ImageListStreamer>(ImageList.ImageStreamProperty, value))
                {
                    // Clear previous images.
                    this.Images.Clear();

                    // Get streamer's images.
                    string strImages = Convert.ToString(value.Images);

                    // Get streamer's owner type.
                    Type objOwnerType = value.OwnerType;

                    // Validate streamer's images and owner type.
                    if (!string.IsNullOrEmpty(strImages) && objOwnerType != null)
                    {
                        // Split images into an array.
                        string[] arrImages = strImages.Split(';');
                        if (arrImages.Length > 0)
                        {
                            // Loop all images.
                            foreach (string strImage in arrImages)
                            {
                                // Add a new type resource handle.
                                this.Images.Add(new TypeResourceHandle(objOwnerType, strImage));
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the color depth.
        /// </summary>
        /// <value>
        /// The color depth.
        /// </value>
   		[Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public ColorDepth ColorDepth
        {
            get
            {
                return this.GetValue<ColorDepth>(ImageList.ColorDepthProperty);
            }
            set
            {
                this.SetValue<ColorDepth>(ImageList.ColorDepthProperty, value);
            }
        }
       
        

		#endregion Properties
		
		#region Methods
		
		/// <summary>
		///
		/// </summary>
		public override string ToString()
		{
			string strText = base.ToString();
			if (this.Images != null)
			{
				string[] arrTextArray = new string[5] { strText, " Images.Count: ", this.Images.Count.ToString(), ", ImageSize: ", this.ImageSize.ToString() } ;
				return string.Concat(arrTextArray);
			}
			return strText;
		}
		
		/// <summary>Draws the image indicated by the specified index on the specified <see cref="T:System.Drawing.Graphics"></see> at the given location.</summary>
        /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> to draw on. </param>
        /// <param name="objPoint">The location defined by a <see cref="T:System.Drawing.Point"></see> at which to draw the image. </param>
		/// <param name="index">The index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to draw. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The index is less than 0.-or- The index is greater than or equal to the count of images in the image list. </exception>
		/// <filterpriority>1</filterpriority>
		/// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Draw(Graphics objGraphics, Point objPoint, int index)
		{
		}

		/// <summary>Draws the image indicated by the given index on the specified <see cref="T:System.Drawing.Graphics"></see> at the specified location.</summary>
        /// <param name="intY">The vertical position at which to draw the image. </param>
        /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> to draw on. </param>
		/// <param name="index">The index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to draw. </param>
        /// <param name="intX">The horizontal position at which to draw the image. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The index is less than 0.-or- The index is greater than or equal to the count of images in the image list. </exception>
		/// <filterpriority>1</filterpriority>
		/// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Draw(Graphics objGraphics, int intX, int intY, int index)
		{
		}

		/// <summary>Draws the image indicated by the given index on the specified <see cref="T:System.Drawing.Graphics"></see> using the specified location and size.</summary>
        /// <param name="intY">The vertical position at which to draw the image. </param>
        /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> to draw on. </param>
        /// <param name="intWidth">The width, in pixels, of the destination image. </param>
        /// <param name="intHeight">The height, in pixels, of the destination image. </param>
        /// <param name="intIndex">The index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to draw. </param>
        /// <param name="intX">The horizontal position at which to draw the image. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The index is less than 0.-or- The index is greater than or equal to the count of images in the image list. </exception>
		/// <filterpriority>1</filterpriority>
		/// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public void Draw(Graphics objGraphics, int intX, int intY, int intWidth, int intHeight, int intIndex)
		{
		}

		#endregion Methods
		
	}
	
	#endregion ImageList Class

    #region ImageListStreamer Class

    /// <summary>Provides the data portion of an <see cref="T:System.Windows.Forms.ImageList"></see>.</summary>
    [Serializable]
    public sealed class ImageListStreamer
    {
        #region Members

        Type mobjOwnerType = null;
        object mobjImages = null; 

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the type of the owner.
        /// </summary>
        /// <value>The type of the owner.</value>
        internal Type OwnerType
        {
            get
            {
                return mobjOwnerType;
            }
        }


        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        /// <value>The images.</value>
        internal object Images
        {
            get
            {
                return mobjImages;
            }
        } 

        #endregion

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageListStreamer"/> class.
        /// </summary>
        public ImageListStreamer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageListStreamer"/> class.
        /// </summary>
        /// <param name="strImages">The images.</param>
        /// <param name="objOwnerType">Type of the owner.</param>
        public ImageListStreamer(object objImages, Type objOwnerType)
        {
            mobjImages = objImages;
            mobjOwnerType = objOwnerType;
        } 

        #endregion
    } 

    #endregion
}
