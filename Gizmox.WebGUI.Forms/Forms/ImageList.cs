// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ImageList
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Design;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Summary description for ImageList.</summary>
  [ToolboxItem(true)]
  [DesignTimeVisible(true)]
  [ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
  [ToolboxItemCategory("Components")]
  [ToolboxBitmap(typeof (ImageList), "ImageList_45.bmp")]
  [DesignerSerializer("Gizmox.WebGUI.Common.Design.Serialization.ImageListCodeDomSerializer, Gizmox.WebGUI.Common.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=ea5dfe57c8eb7edd", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.5000.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
  [Serializable]
  public class ImageList : ComponentBase
  {
    /// <summary>Image collection</summary>
    private ImageList.ImageCollection mobjImageCollection;
    private Size mobjImageSize;
    private object mobjTag;
    /// <summary>The TransparentColor property registration.</summary>
    private static readonly SerializableProperty TransparentColorProperty = SerializableProperty.Register(nameof (TransparentColor), typeof (Color), typeof (ImageList));
    /// <summary>The ImageStream property registration.</summary>
    private static readonly SerializableProperty ImageStreamProperty = SerializableProperty.Register(nameof (ImageStream), typeof (ImageListStreamer), typeof (ImageList));
    /// <summary>The ImageStream property registration.</summary>
    private static readonly SerializableProperty ColorDepthProperty = SerializableProperty.Register(nameof (ColorDepth), typeof (ColorDepth), typeof (ImageList), new SerializablePropertyMetadata((object) ColorDepth.Depth32Bit));

    /// <summary>
    /// 
    /// </summary>
    public ImageList() => this.mobjImageSize = new Size(16, 16);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objContainer"></param>
    public ImageList(IContainer objContainer) => objContainer.Add((IComponent) this);

    /// <summary>Gets a value indicating whether the underlying Win32 handle has been created.</summary>
    /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.ImageList.Handle"></see> has been created; otherwise, false. The default is false.</returns>
    /// <filterpriority>1</filterpriority>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    [SRDescription("ImageListHandleCreatedDescr")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool HandleCreated => true;

    /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.ImageList.ImageCollection"></see> for this image list.</summary>
    /// <returns>The collection of images.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRCategory("CatAppearance")]
    [SRDescription("ImageListImagesDescr")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ImageList.ImageCollection Images
    {
      get
      {
        if (this.mobjImageCollection == null)
          this.mobjImageCollection = new ImageList.ImageCollection(this);
        return this.mobjImageCollection;
      }
    }

    /// <summary>Gets or sets the size of the images in the image list.</summary>
    /// <returns>The <see cref="T:System.Drawing.Size"></see> that defines the height and width, in pixels, of the images in the list. The default size is 16 by 16. The maximum size is 256 by 256.</returns>
    /// <exception cref="T:System.ArgumentOutOfRangeException">The new size has a dimension less than 0 or greater than 256.</exception>
    /// <exception cref="T:System.ArgumentException">The value assigned is equal to <see cref="P:System.Drawing.Size.IsEmpty"></see>.-or- The value of the height or width is less than or equal to 0.-or- The value of the height or width is greater than 256. </exception>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [SRDescription("ImageListSizeDescr")]
    [SRCategory("CatBehavior")]
    [Localizable(true)]
    [Browsable(true)]
    public Size ImageSize
    {
      get => this.mobjImageSize;
      set => this.mobjImageSize = value;
    }

    /// <summary>Gets or sets an object that contains additional data about the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</summary>
    /// <returns>An <see cref="T:System.Object"></see> that contains additional data about the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    [TypeConverter(typeof (StringConverter))]
    [Localizable(false)]
    [Bindable(true)]
    [SRDescription("ControlTagDescr")]
    [SRCategory("CatData")]
    [DefaultValue(null)]
    public object Tag
    {
      get => this.mobjTag;
      set => this.mobjTag = value;
    }

    /// <summary>Gets or sets the color of the transparent.</summary>
    /// <value>The color of the transparent.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public Color TransparentColor
    {
      get => this.GetValue<Color>(ImageList.TransparentColorProperty);
      set => this.SetValue<Color>(ImageList.TransparentColorProperty, value);
    }

    /// <summary>Gets the handle to the <see cref="T:System.Windows.Forms.ImageListStreamer"></see> associated with this image list.</summary>
    /// <returns>null if the image list is empty; otherwise, a handle to the <see cref="T:System.Windows.Forms.ImageListStreamer"></see> for this <see cref="T:System.Windows.Forms.ImageList"></see>.</returns>
    /// <filterpriority>1</filterpriority>
    /// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [Browsable(false)]
    [DefaultValue(null)]
    [SRDescription("ImageListImageStreamDescr")]
    public ImageListStreamer ImageStream
    {
      get => this.GetValue<ImageListStreamer>(ImageList.ImageStreamProperty);
      set
      {
        if (!this.SetValue<ImageListStreamer>(ImageList.ImageStreamProperty, value))
          return;
        this.Images.Clear();
        string str = Convert.ToString(value.Images);
        Type ownerType = value.OwnerType;
        if (string.IsNullOrEmpty(str) || !(ownerType != (Type) null))
          return;
        string[] strArray = str.Split(';');
        if (strArray.Length == 0)
          return;
        foreach (string strFile in strArray)
          this.Images.Add((ResourceHandle) new TypeResourceHandle(ownerType, strFile));
      }
    }

    /// <summary>Gets or sets the color depth.</summary>
    /// <value>The color depth.</value>
    [Obsolete("Not implemented. Added for migration compatibility")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public ColorDepth ColorDepth
    {
      get => this.GetValue<ColorDepth>(ImageList.ColorDepthProperty);
      set => this.SetValue<ColorDepth>(ImageList.ColorDepthProperty, value);
    }

    /// <summary>
    /// 
    /// </summary>
    public override string ToString()
    {
      string str = base.ToString();
      if (this.Images == null)
        return str;
      return str + " Images.Count: " + this.Images.Count.ToString() + ", ImageSize: " + this.ImageSize.ToString();
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
    public void Draw(
      Graphics objGraphics,
      int intX,
      int intY,
      int intWidth,
      int intHeight,
      int intIndex)
    {
    }

    /// <summary>Encapsulates the collection of <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> objects in an <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>.</summary>
    [Editor("Gizmox.WebGUI.Forms.Design.ImageCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
    [Serializable]
    public sealed class ImageCollection : IList, ICollection, IEnumerable
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
      public void Add(ResourceHandle objValue) => this.mobjItems.Add((object) objValue);

      /// <summary>Adds an image with the specified key to the end of the collection.</summary>
      /// <param name="objImage">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to add to the collection.</param>
      /// <param name="strKey">The name of the image.</param>
      /// <exception cref="T:System.ArgumentNullException">image is null. </exception>
      public void Add(string strKey, ResourceHandle objImage)
      {
        this.mobjItems.Add((object) objImage);
        this.mobjKeys.Add((object) strKey, (object) objImage);
      }

      /// <summary>Adds a new icon using a key</summary>
      /// <param name="strKey"></param>
      /// <param name="strIcon"></param>
      public void AddIcon(string strKey, string strIcon) => this.Add(strKey, (ResourceHandle) new IconResourceHandle(strIcon));

      /// <summary>Adds a new icon</summary>
      /// <param name="strIcon"></param>
      public void AddIcon(string strIcon) => this.Add((ResourceHandle) new IconResourceHandle(strIcon));

      /// <summary>Adds a new image using a key</summary>
      /// <param name="strKey"></param>
      /// <param name="strImage"></param>
      public void AddImage(string strKey, string strImage) => this.Add(strKey, (ResourceHandle) new ImageResourceHandle(strImage));

      /// <summary>Adds a new image</summary>
      /// <param name="strImage"></param>
      public void AddImage(string strImage) => this.Add((ResourceHandle) new ImageResourceHandle(strImage));

      /// <summary>Adds an array of images to the collection.</summary>
      /// <param name="arrImages">The array of <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> objects to add to the collection.</param>
      /// <exception cref="T:System.ArgumentNullException">images is null.</exception>
      public void AddRange(ResourceHandle[] arrImages) => this.mobjItems.AddRange((ICollection) arrImages);

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
      public bool Contains(ResourceHandle objImage) => this.mobjItems.Contains((object) objImage);

      /// <summary>Determines if the collection contains an image with the specified key.</summary>
      /// <returns>true to indicate an image with the specified key is contained in the collection; otherwise, false. </returns>
      /// <param name="strKey">The key of the image to search for.</param>
      public bool ContainsKey(string strKey) => this.mobjKeys.Contains((object) strKey);

      /// <summary>Returns an enumerator that can be used to iterate through the item collection.</summary>
      /// <returns>An <see cref="T:System.Collections.IEnumerator"></see> that represents the item collection.</returns>
      public IEnumerator GetEnumerator() => this.mobjItems.GetEnumerator();

      /// <summary>Not supported. The <see cref="M:System.Collections.IList.IndexOf(System.Object)"></see> method returns the index of a specified object in the list.</summary>
      /// <returns>The index of the image in the list.</returns>
      /// <param name="objImage">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to find in the list. </param>
      /// <exception cref="T:System.NotSupportedException">This method is not supported. </exception>
      [EditorBrowsable(EditorBrowsableState.Never)]
      public int IndexOf(ResourceHandle objImage) => this.mobjItems.IndexOf((object) objImage);

      /// <summary>Determines the index of the first occurrence of an image with the specified key in the collection.</summary>
      /// <returns>The zero-based index of the first occurrence of an image with the specified key in the collection, if found; otherwise, -1.</returns>
      /// <param name="strKey">The key of the image to retrieve the index for.</param>
      public int IndexOfKey(string strKey) => this.mobjKeys[(object) strKey] is ResourceHandle mobjKey ? this.IndexOf(mobjKey) : -1;

      /// <summary>Determines the key of the image with the specified index.</summary>
      /// <returns>The key that was found for the index or null if key was not found.</returns>
      /// <param name="intIndex">The index of the image to retrieve the key for.</param>
      public string KeyOfIndex(int intIndex)
      {
        ResourceHandle resourceHandle = this[intIndex];
        if (resourceHandle != null)
        {
          foreach (string key in (IEnumerable) this.mobjKeys.Keys)
          {
            if (this.mobjKeys[(object) key] == resourceHandle)
              return key;
          }
        }
        return (string) null;
      }

      /// <summary>Not supported. The <see cref="M:System.Collections.IList.Remove(System.Object)"></see> method removes a specified object from the list.</summary>
      /// <param name="objImage">The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> to remove from the list. </param>
      /// <exception cref="T:System.NotSupportedException">This method is not supported. </exception>
      [EditorBrowsable(EditorBrowsableState.Never)]
      public void Remove(ResourceHandle objImage)
      {
        if (this.mobjItems.Contains((object) objImage))
          this.mobjItems.Remove((object) objImage);
        if (!this.mobjKeys.ContainsValue((object) objImage))
          return;
        foreach (object key in (IEnumerable) this.mobjKeys.Keys)
        {
          if (this.mobjKeys[key] == objImage)
          {
            this.mobjKeys.Remove(key);
            break;
          }
        }
      }

      /// <summary>Removes an image from the list.</summary>
      /// <param name="index">The index of the image to remove. </param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index value was less than 0.-or- The index value is greater than or equal to the <see cref="P:Gizmox.WebGUI.Forms.ImageList.ImageCollection.Count"></see> of images. </exception>
      /// <exception cref="T:System.InvalidOperationException">The image cannot be removed. </exception>
      public void RemoveAt(int index)
      {
        if (!(this.mobjItems[index] is ResourceHandle mobjItem))
          return;
        this.Remove(mobjItem);
      }

      /// <summary>Removes the image with the specified key from the collection.</summary>
      /// <param name="strKey">The key of the image to remove from the collection.</param>
      public void RemoveByKey(string strKey)
      {
        if (!(this.mobjKeys[(object) strKey] is ResourceHandle mobjKey))
          return;
        this.Remove(mobjKey);
      }

      /// <summary>Sets the key for an image in the collection.</summary>
      /// <param name="strName">The name of the image to be set as the image key.</param>
      /// <param name="index">The zero-based index of an image in the collection.</param>
      /// <exception cref="T:System.IndexOutOfRangeException">The specified index is less than 0 or greater than or equal to <see cref="P:Gizmox.WebGUI.Forms.ImageList.ImageCollection.Count"></see>.</exception>
      public void SetKeyName(int index, string strName) => this.mobjKeys[(object) strName] = this.mobjItems[index];

      /// <summary>Gets the number of images currently in the list.</summary>
      /// <returns>The number of images in the list. The default is 0.</returns>
      [Browsable(false)]
      public int Count => this.mobjItems.Count;

      /// <summary>Gets a value indicating whether the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> has any images.</summary>
      /// <returns>true if there are no images in the list; otherwise, false. The default is false.</returns>
      public bool Empty => this.mobjItems.Count == 0;

      /// <summary>Gets a value indicating whether the list is read-only.</summary>
      /// <returns>Always false.</returns>
      public bool IsReadOnly => false;

      /// <summary>Gets an <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> with the specified key from the collection.</summary>
      /// <returns>The <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> with the specified key.</returns>
      /// <param name="strKey">The name of the image to retrieve from the collection.</param>
      public ResourceHandle this[string strKey] => this.mobjKeys[(object) strKey] as ResourceHandle;

      /// <summary>Gets or sets an <see cref="T:Gizmox.WebGUI.Common.Resources.ResourceHandle"></see> at the specified index within the collection.</summary>
      /// <returns>The image in the list specified by index. </returns>
      /// <param name="index">The index of the image to get or set. </param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">The index is less than 0 or greater than or equal to <see cref="P:Gizmox.WebGUI.Forms.ImageList.ImageCollection.Count"></see>. </exception>
      /// <exception cref="T:System.InvalidOperationException">The image cannot be added to the list.</exception>
      /// <exception cref="T:System.ArgumentException">image is not a<see cref="T:System.Drawing.Bitmap"></see>.</exception>
      /// <exception cref="T:System.ArgumentNullException">The image to be assigned is null or not a <see cref="T:System.Drawing.Bitmap"></see>. </exception>
      public ResourceHandle this[int index]
      {
        get => this.mobjItems[index] as ResourceHandle;
        set => this.mobjItems[index] = (object) value;
      }

      /// <summary>Gets the collection of keys associated with the images in the <see cref="T:Gizmox.WebGUI.Forms.ImageList.ImageCollection"></see>.</summary>
      /// <returns>A <see cref="T:System.Collections.Specialized.StringCollection"></see> containing the names of the images in the <see cref="T:Gizmox.WebGUI.Forms.ImageList.ImageCollection"></see>.</returns>
      public StringCollection Keys
      {
        get
        {
          StringCollection keys = new StringCollection();
          if (this.mobjItems != null && this.mobjItems.Count > 0)
          {
            for (int intIndex = 0; intIndex < this.mobjItems.Count; ++intIndex)
              keys.Add(this.KeyOfIndex(intIndex));
          }
          return keys;
        }
      }

      object IList.this[int index]
      {
        get => (object) this[index];
        set => this[index] = (ResourceHandle) value;
      }

      void IList.RemoveAt(int index) => this.RemoveAt(index);

      void IList.Insert(int index, object objValue) => this[index] = (ResourceHandle) objValue;

      void IList.Remove(object objValue) => this.Remove((ResourceHandle) objValue);

      bool IList.Contains(object objValue) => this.Contains((ResourceHandle) objValue);

      void IList.Clear() => this.Clear();

      int IList.IndexOf(object objValue) => this.IndexOf((ResourceHandle) objValue);

      int IList.Add(object objValue)
      {
        this.Add((ResourceHandle) objValue);
        return this.IndexOf((ResourceHandle) objValue);
      }

      bool IList.IsFixedSize => false;

      bool ICollection.IsSynchronized => false;

      void ICollection.CopyTo(Array objArray, int index) => this.mobjItems.CopyTo(objArray, index);

      object ICollection.SyncRoot => this.mobjItems.SyncRoot;

      IEnumerator IEnumerable.GetEnumerator() => this.mobjItems.GetEnumerator();
    }
  }
}
