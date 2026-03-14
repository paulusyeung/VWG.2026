#define DEBUG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Convertions;
using Gizmox.WebGUI.Common.Device;
using Gizmox.WebGUI.Common.Device.Accelerometer;
using Gizmox.WebGUI.Common.Device.Camera;
using Gizmox.WebGUI.Common.Device.Capture;
using Gizmox.WebGUI.Common.Device.Common;
using Gizmox.WebGUI.Common.Device.Compass;
using Gizmox.WebGUI.Common.Device.Connection;
using Gizmox.WebGUI.Common.Device.Contacts;
using Gizmox.WebGUI.Common.Device.DeviceInfo;
using Gizmox.WebGUI.Common.Device.FileManagement;
using Gizmox.WebGUI.Common.Device.Geolocation;
using Gizmox.WebGUI.Common.Device.Globalization;
using Gizmox.WebGUI.Common.Device.Media;
using Gizmox.WebGUI.Common.Device.Notifications;
using Gizmox.WebGUI.Common.Device.Storage;
using Gizmox.WebGUI.Common.DeviceRepository;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Gateways;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Device.Capture;
using Gizmox.WebGUI.Common.Interfaces.Device.ContactsData;
using Gizmox.WebGUI.Common.Interfaces.Device.FileManagement;
using Gizmox.WebGUI.Common.Interfaces.Device.Media;
using Gizmox.WebGUI.Common.Interfaces.Device.Storage;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Trace;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Administration;
using Gizmox.WebGUI.Forms.Administration.Abstract;
using Gizmox.WebGUI.Forms.Administration.CustomComponents;
using Gizmox.WebGUI.Forms.Client;
using Gizmox.WebGUI.Forms.ContextualToolbar;
using Gizmox.WebGUI.Forms.Controls;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Design.Editors;
using Gizmox.WebGUI.Forms.DeviceIntegration.Abstract;
using Gizmox.WebGUI.Forms.DeviceIntegration.CaptureComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.ContactsData;
using Gizmox.WebGUI.Forms.DeviceIntegration.DeviceCommon;
using Gizmox.WebGUI.Forms.DeviceIntegration.FileManagement;
using Gizmox.WebGUI.Forms.DeviceIntegration.MediaComponents;
using Gizmox.WebGUI.Forms.DeviceIntegration.StorageComponents;
using Gizmox.WebGUI.Forms.Hosts.Skins;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.PropertyGridInternal;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Forms.VisualEffects;
using Gizmox.WebGUI.Hosting;
using Gizmox.WebGUI.Virtualization.IO;
using Gizmox.WebGUI.Virtualization.Management;
using Gizmox.WebGUI.Virtualization.Win32;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gizmox.WebGUI.Forms
{
/// 
	/// Summary description for ImageList.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[DesignTimeVisible(true)]
	[ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
	[ToolboxItemCategory("Components")]
	[ToolboxBitmap(typeof(ImageList), "ImageList_45.bmp")]
	[DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ImageListCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public class ImageList : ComponentBase
	{
		/// Encapsulates the collection of <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> objects in an <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</summary>
		[Serializable]
		[Editor("Gizmox.WebGUI.Forms.Design.ImageCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		public sealed class ImageCollection : IList, ICollection, IEnumerable
		{
			private ArrayList mobjItems;

			private Hashtable mobjKeys;

			/// Gets the number of images currently in the list.</summary>
			/// The number of images in the list. The default is 0.</returns>
			[Browsable(false)]
			public int Count => mobjItems.Count;

			/// Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> has any images.</summary>
			/// true if there are no images in the list; otherwise, false. The default is false.</returns>
			public bool Empty => mobjItems.Count == 0;

			/// Gets a value indicating whether the list is read-only.</summary>
			/// Always false.</returns>
			public bool IsReadOnly => false;

			/// Gets an <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> with the specified key from the collection.</summary>
			/// The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> with the specified key.</returns>
			/// <param name="strKey">The name of the image to retrieve from the collection.</param>
			public ResourceHandle this[string strKey] => mobjKeys[strKey] as ResourceHandle;

			/// Gets or sets an <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> at the specified index within the collection.</summary>
			/// The image in the list specified by index. </returns>
			/// <param name="index">The index of the image to get or set. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index is less than 0 or greater than or equal to <see cref="P:Gizmox.WebGUI.Forms.ImageList.ImageCollection.Count"></see>. </exception>
			/// <exception cref="T:System.InvalidOperationException">The image cannot be added to the list.</exception>
			/// <exception cref="T:System.ArgumentException">image is not a<see cref="T:System.Drawing.Bitmap"></see>.</exception>
			/// <exception cref="T:System.ArgumentNullException">The image to be assigned is null or not a <see cref="T:System.Drawing.Bitmap"></see>. </exception>
			public ResourceHandle this[int index]
			{
				get
				{
					return mobjItems[index] as ResourceHandle;
				}
				set
				{
					mobjItems[index] = value;
				}
			}

			/// Gets the collection of keys associated with the images in the <see cref="T:Gizmox.WebGUI.Forms.ImageList.ImageCollection"></see>.</summary>
			/// A <see cref="T:System.Collections.Specialized.StringCollection"></see> containing the names of the images in the <see cref="T:Gizmox.WebGUI.Forms.ImageList.ImageCollection"></see>.</returns>
			public StringCollection Keys
			{
				get
				{
					StringCollection stringCollection = new StringCollection();
					if (mobjItems != null && mobjItems.Count > 0)
					{
						for (int i = 0; i < mobjItems.Count; i++)
						{
							stringCollection.Add(KeyOfIndex(i));
						}
					}
					return stringCollection;
				}
			}

			object IList.this[int index]
			{
				get
				{
					return this[index];
				}
				set
				{
					this[index] = (ResourceHandle)value;
				}
			}

			bool IList.IsFixedSize => false;

			bool ICollection.IsSynchronized => false;

			object ICollection.SyncRoot => mobjItems.SyncRoot;

			internal ImageCollection(ImageList objOwnerList)
			{
				mobjItems = new ArrayList();
				mobjKeys = new Hashtable();
			}

			/// Adds the specified image to the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</summary>
			/// <param name="objValue">A <see cref="T:System.Drawing.Bitmap"></see> of the image to add to the list. </param>
			/// <exception cref="T:System.Exception">The image could not be added.  </exception>
			/// <exception cref="T:System.ArgumentException">The image being added is not a <see cref="T:System.Drawing.Bitmap"></see>. </exception>
			/// <exception cref="T:System.ArgumentNullException">The image being added is null. </exception>
			public void Add(ResourceHandle objValue)
			{
				mobjItems.Add(objValue);
			}

			/// Adds an image with the specified key to the end of the collection.</summary>
			/// <param name="objImage">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to add to the collection.</param>
			/// <param name="strKey">The name of the image.</param>
			/// <exception cref="T:System.ArgumentNullException">image is null. </exception>
			public void Add(string strKey, ResourceHandle objImage)
			{
				mobjItems.Add(objImage);
				mobjKeys.Add(strKey, objImage);
			}

			/// 
			/// Adds a new icon using a key
			/// </summary>
			/// <param name="strKey"></param>
			/// <param name="strIcon"></param>
			public void AddIcon(string strKey, string strIcon)
			{
				Add(strKey, new IconResourceHandle(strIcon));
			}

			/// 
			/// Adds a new icon
			/// </summary>
			/// <param name="strIcon"></param>
			public void AddIcon(string strIcon)
			{
				Add(new IconResourceHandle(strIcon));
			}

			/// 
			/// Adds a new image using a key
			/// </summary>
			/// <param name="strKey"></param>
			/// <param name="strImage"></param>
			public void AddImage(string strKey, string strImage)
			{
				Add(strKey, new ImageResourceHandle(strImage));
			}

			/// 
			/// Adds a new image
			/// </summary>
			/// <param name="strImage"></param>
			public void AddImage(string strImage)
			{
				Add(new ImageResourceHandle(strImage));
			}

			/// Adds an array of images to the collection.</summary>
			/// <param name="arrImages">The array of <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> objects to add to the collection.</param>
			/// <exception cref="T:System.ArgumentNullException">images is null.</exception>
			public void AddRange(ResourceHandle[] arrImages)
			{
				mobjItems.AddRange(arrImages);
			}

			/// Removes all the images and masks from the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</summary>
			public void Clear()
			{
				mobjItems.Clear();
				mobjKeys.Clear();
			}

			/// Not supported. The <see cref="M:System.Collections.IList.Contains(System.Object)"></see> method indicates whether a specified object is contained in the list.</summary>
			/// true if the image is found in the list; otherwise, false.</returns>
			/// <param name="objImage">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to find in the list. </param>
			/// <exception cref="T:System.NotSupportedException">This method is not supported. </exception>
			[EditorBrowsable(EditorBrowsableState.Never)]
			public bool Contains(ResourceHandle objImage)
			{
				return mobjItems.Contains(objImage);
			}

			/// Determines if the collection contains an image with the specified key.</summary>
			/// true to indicate an image with the specified key is contained in the collection; otherwise, false. </returns>
			/// <param name="strKey">The key of the image to search for.</param>
			public bool ContainsKey(string strKey)
			{
				return mobjKeys.Contains(strKey);
			}

			/// Returns an enumerator that can be used to iterate through the item collection.</summary>
			/// An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
			public IEnumerator GetEnumerator()
			{
				return mobjItems.GetEnumerator();
			}

			/// Not supported. The <see cref="M:System.Collections.IList.IndexOf(System.Object)"></see> method returns the index of a specified object in the list.</summary>
			/// The index of the image in the list.</returns>
			/// <param name="objImage">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to find in the list. </param>
			/// <exception cref="T:System.NotSupportedException">This method is not supported. </exception>
			[EditorBrowsable(EditorBrowsableState.Never)]
			public int IndexOf(ResourceHandle objImage)
			{
				return mobjItems.IndexOf(objImage);
			}

			/// Determines the index of the first occurrence of an image with the specified key in the collection.</summary>
			/// The zero-based index of the first occurrence of an image with the specified key in the collection, if found; otherwise, -1.</returns>
			/// <param name="strKey">The key of the image to retrieve the index for.</param>
			public int IndexOfKey(string strKey)
			{
				if (mobjKeys[strKey] is ResourceHandle objImage)
				{
					return IndexOf(objImage);
				}
				return -1;
			}

			/// Determines the key of the image with the specified index.</summary>
			/// The key that was found for the index or null if key was not found.</returns>
			/// <param name="intIndex">The index of the image to retrieve the key for.</param>
			public string KeyOfIndex(int intIndex)
			{
				ResourceHandle resourceHandle = this[intIndex];
				if (resourceHandle != null)
				{
					foreach (string key in mobjKeys.Keys)
					{
						if (mobjKeys[key] == resourceHandle)
						{
							return key;
						}
					}
				}
				return null;
			}

			/// Not supported. The <see cref="M:System.Collections.IList.Remove(System.Object)"></see> method removes a specified object from the list.</summary>
			/// <param name="objImage">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to remove from the list. </param>
			/// <exception cref="T:System.NotSupportedException">This method is not supported. </exception>
			[EditorBrowsable(EditorBrowsableState.Never)]
			public void Remove(ResourceHandle objImage)
			{
				if (mobjItems.Contains(objImage))
				{
					mobjItems.Remove(objImage);
				}
				if (!mobjKeys.ContainsValue(objImage))
				{
					return;
				}
				foreach (object key in mobjKeys.Keys)
				{
					if (mobjKeys[key] == objImage)
					{
						mobjKeys.Remove(key);
						break;
					}
				}
			}

			/// Removes an image from the list.</summary>
			/// <param name="index">The index of the image to remove. </param>
			/// <exception cref="T:System.ArgumentOutOfRangeException">The index value was less than 0.-or- The index value is greater than or equal to the <see cref="P:Gizmox.WebGUI.Forms.ImageList.ImageCollection.Count"></see> of images. </exception>
			/// <exception cref="T:System.InvalidOperationException">The image cannot be removed. </exception>
			public void RemoveAt(int index)
			{
				if (mobjItems[index] is ResourceHandle objImage)
				{
					Remove(objImage);
				}
			}

			/// Removes the image with the specified key from the collection.</summary>
			/// <param name="strKey">The key of the image to remove from the collection.</param>
			public void RemoveByKey(string strKey)
			{
				if (mobjKeys[strKey] is ResourceHandle objImage)
				{
					Remove(objImage);
				}
			}

			/// Sets the key for an image in the collection.</summary>
			/// <param name="strName">The name of the image to be set as the image key.</param>
			/// <param name="index">The zero-based index of an image in the collection.</param>
			/// <exception cref="T:System.IndexOutOfRangeException">The specified index is less than 0 or greater than or equal to <see cref="P:Gizmox.WebGUI.Forms.ImageList.ImageCollection.Count"></see>.</exception>
			public void SetKeyName(int index, string strName)
			{
				mobjKeys[strName] = mobjItems[index];
			}

			void IList.RemoveAt(int index)
			{
				RemoveAt(index);
			}

			void IList.Insert(int index, object objValue)
			{
				this[index] = (ResourceHandle)objValue;
			}

			void IList.Remove(object objValue)
			{
				Remove((ResourceHandle)objValue);
			}

			bool IList.Contains(object objValue)
			{
				return Contains((ResourceHandle)objValue);
			}

			void IList.Clear()
			{
				Clear();
			}

			int IList.IndexOf(object objValue)
			{
				return IndexOf((ResourceHandle)objValue);
			}

			int IList.Add(object objValue)
			{
				Add((ResourceHandle)objValue);
				return IndexOf((ResourceHandle)objValue);
			}

			void ICollection.CopyTo(Array objArray, int index)
			{
				mobjItems.CopyTo(objArray, index);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return mobjItems.GetEnumerator();
			}
		}

		/// 
		/// Image collection
		/// </summary>
		private ImageCollection mobjImageCollection = null;

		private Size mobjImageSize;

		private object mobjTag = null;

		/// 
		/// The TransparentColor property registration.
		/// </summary>
		private static readonly SerializableProperty TransparentColorProperty;

		/// 
		/// The ImageStream property registration.
		/// </summary>
		private static readonly SerializableProperty ImageStreamProperty;

		/// 
		/// The ImageStream property registration.
		/// </summary>
		private static readonly SerializableProperty ColorDepthProperty;

		/// Gets a value indicating whether the underlying Win32 handle has been created.</summary>
		/// true if the <see cref="P:Gizmox.WebGUI.Forms.ImageList.Handle"></see> has been created; otherwise, false. The default is false.</returns>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		[SRDescription("ImageListHandleCreatedDescr")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool HandleCreated => true;

		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.ImageList.ImageCollection"></see> for this image list.</summary>
		/// The collection of images.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatAppearance")]
		[SRDescription("ImageListImagesDescr")]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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

		/// Gets or sets the size of the images in the image list.</summary>
		/// The <see cref="T:System.Drawing.Size"></see> that defines the height and width, in pixels, of the images in the list. The default size is 16 by 16. The maximum size is 256 by 256.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The new size has a dimension less than 0 or greater than 256.</exception>
		/// <exception cref="T:System.ArgumentException">The value assigned is equal to <see cref="P:System.Drawing.Size.IsEmpty"></see>.-or- The value of the height or width is less than or equal to 0.-or- The value of the height or width is greater than 256. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("ImageListSizeDescr")]
		[SRCategory("CatBehavior")]
		[Localizable(true)]
		[Browsable(true)]
		public Size ImageSize
		{
			get
			{
				return mobjImageSize;
			}
			set
			{
				mobjImageSize = value;
			}
		}

		/// Gets or sets an object that contains additional data about the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</summary>
		/// An <see cref="T:System.Object"></see> that contains additional data about the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</returns>
		/// 1</filterpriority>
		[TypeConverter(typeof(StringConverter))]
		[Localizable(false)]
		[Bindable(true)]
		[SRDescription("ControlTagDescr")]
		[SRCategory("CatData")]
		[DefaultValue(null)]
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

		/// 
		/// Gets or sets the color of the transparent.
		/// </summary>
		/// 
		/// The color of the transparent.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Color TransparentColor
		{
			get
			{
				return GetValue(TransparentColorProperty);
			}
			set
			{
				SetValue(TransparentColorProperty, value);
			}
		}

		/// Gets the handle to the <see cref="T:System.Windows.Forms.ImageListStreamer"></see> associated with this image list.</summary>
		/// null if the image list is empty; otherwise, a handle to the <see cref="T:System.Windows.Forms.ImageListStreamer"></see> for this <see cref="T:System.Windows.Forms.ImageList"></see>.</returns>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		[DefaultValue(null)]
		[SRDescription("ImageListImageStreamDescr")]
		public ImageListStreamer ImageStream
		{
			get
			{
				return GetValue(ImageStreamProperty);
			}
			set
			{
				if (!SetValue(ImageStreamProperty, value))
				{
					return;
				}
				Images.Clear();
				string text = Convert.ToString(value.Images);
				Type ownerType = value.OwnerType;
				if (string.IsNullOrEmpty(text) || !(ownerType != null))
				{
					return;
				}
				string[] array = text.Split(';');
				if (array.Length != 0)
				{
					string[] array2 = array;
					foreach (string strFile in array2)
					{
						Images.Add(new TypeResourceHandle(ownerType, strFile));
					}
				}
			}
		}

		/// 
		/// Gets or sets the color depth.
		/// </summary>
		/// 
		/// The color depth.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public ColorDepth ColorDepth
		{
			get
			{
				return GetValue(ColorDepthProperty);
			}
			set
			{
				SetValue(ColorDepthProperty, value);
			}
		}

		/// 
		///
		/// </summary>
		static ImageList()
		{
			TransparentColorProperty = SerializableProperty.Register("TransparentColor", typeof(Color), typeof(ImageList));
			ImageStreamProperty = SerializableProperty.Register("ImageStream", typeof(ImageListStreamer), typeof(ImageList));
			ColorDepthProperty = SerializableProperty.Register("ColorDepth", typeof(ColorDepth), typeof(ImageList), new SerializablePropertyMetadata(ColorDepth.Depth32Bit));
		}

		/// 
		///
		/// </summary>
		public ImageList()
		{
			mobjImageSize = new Size(16, 16);
		}

		/// 
		///
		/// </summary>
		/// <param name="objContainer"></param>
		public ImageList(IContainer objContainer)
		{
			objContainer.Add(this);
		}

		/// 
		///
		/// </summary>
		public override string ToString()
		{
			string text = base.ToString();
			if (Images != null)
			{
				string[] array = new string[5]
				{
					text,
					" Images.Count: ",
					Images.Count.ToString(),
					", ImageSize: ",
					ImageSize.ToString()
				};
				return string.Concat(array);
			}
			return text;
		}

		/// Draws the image indicated by the specified index on the specified <see cref="T:System.Drawing.Graphics"></see> at the given location.</summary>
		/// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> to draw on. </param>
		/// <param name="objPoint">The location defined by a <see cref="T:System.Drawing.Point"></see> at which to draw the image. </param>
		/// <param name="index">The index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to draw. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The index is less than 0.-or- The index is greater than or equal to the count of images in the image list. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Draw(Graphics objGraphics, Point objPoint, int index)
		{
		}

		/// Draws the image indicated by the given index on the specified <see cref="T:System.Drawing.Graphics"></see> at the specified location.</summary>
		/// <param name="intY">The vertical position at which to draw the image. </param>
		/// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> to draw on. </param>
		/// <param name="index">The index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to draw. </param>
		/// <param name="intX">The horizontal position at which to draw the image. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The index is less than 0.-or- The index is greater than or equal to the count of images in the image list. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Draw(Graphics objGraphics, int intX, int intY, int index)
		{
		}

		/// Draws the image indicated by the given index on the specified <see cref="T:System.Drawing.Graphics"></see> using the specified location and size.</summary>
		/// <param name="intY">The vertical position at which to draw the image. </param>
		/// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> to draw on. </param>
		/// <param name="intWidth">The width, in pixels, of the destination image. </param>
		/// <param name="intHeight">The height, in pixels, of the destination image. </param>
		/// <param name="intIndex">The index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to draw. </param>
		/// <param name="intX">The horizontal position at which to draw the image. </param>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The index is less than 0.-or- The index is greater than or equal to the count of images in the image list. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Draw(Graphics objGraphics, int intX, int intY, int intWidth, int intHeight, int intIndex)
		{
		}
	}
}
