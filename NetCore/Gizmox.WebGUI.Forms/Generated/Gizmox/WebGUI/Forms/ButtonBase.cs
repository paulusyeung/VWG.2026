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
	/// Implements the basic functionality common to button controls.
	/// </summary>
	[Serializable]
	public abstract class ButtonBase : Control
	{
		/// 
		/// Provides a property reference to TextImageRelation property.
		/// </summary>
		private static SerializableProperty TextImageRelationProperty = SerializableProperty.Register("TextImageRelation", typeof(TextImageRelation), typeof(ButtonBase), new SerializablePropertyMetadata(TextImageRelation.Overlay));

		/// 
		/// Provides a property reference to TextAlign property.
		/// </summary>
		private static SerializableProperty TextAlignProperty = SerializableProperty.Register("TextAlign", typeof(ContentAlignment), typeof(ButtonBase), new SerializablePropertyMetadata(ContentAlignment.MiddleCenter));

		/// 
		/// Provides a property reference to ImageAlign property.
		/// </summary>
		private static SerializableProperty ImageAlignProperty = SerializableProperty.Register("ImageAlign", typeof(ContentAlignment), typeof(ButtonBase), new SerializablePropertyMetadata(ContentAlignment.MiddleCenter));

		/// 
		/// Provides a property reference to ImageListItem property.
		/// </summary>
		private static SerializableProperty ImageListItemProperty = SerializableProperty.Register("ImageListItem", typeof(ImageList), typeof(ButtonBase), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to ImageKey property.
		/// </summary>
		private static SerializableProperty ImageKeyProperty = SerializableProperty.Register("ImageKey", typeof(string), typeof(ButtonBase), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// Provides a property reference to ImageIndex property.
		/// </summary>
		private static SerializableProperty ImageIndexProperty = SerializableProperty.Register("ImageIndex", typeof(int), typeof(ButtonBase), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to Image property.
		/// </summary>
		private static SerializableProperty ImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(ButtonBase), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to FlatStyle property.
		/// </summary>
		private static SerializableProperty FlatStyleProperty = SerializableProperty.Register("FlatStyle", typeof(FlatStyle), typeof(ButtonBase), new SerializablePropertyMetadata(FlatStyle.Standard));

		/// 
		/// The UseCompatibleTextRendering property registration.
		/// </summary>
		private static readonly SerializableProperty UseCompatibleTextRenderingProperty = SerializableProperty.Register("UseCompatibleTextRendering", typeof(bool), typeof(ButtonBase), new SerializablePropertyMetadata(false));

		/// 
		/// The UseVisualStyleBackColor property registration.
		/// </summary>
		private static readonly SerializableProperty UseVisualStyleBackColorProperty = SerializableProperty.Register("UseVisualStyleBackColor", typeof(bool), typeof(ButtonBase), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to ImageSize property.
		/// </summary>
		private static SerializableProperty ImageSizeProperty = SerializableProperty.Register("ImageSize", typeof(Size), typeof(ButtonBase), new SerializablePropertyMetadata(new Size(16, 16)));

		/// 
		/// Provides a property reference to UseMnemonic property.
		/// </summary>
		private static SerializableProperty UseMnemonicProperty = SerializableProperty.Register("UseMnemonic", typeof(bool), typeof(ButtonBase), new SerializablePropertyMetadata(true));

		public override bool CanEditControl => true;

		/// 
		/// Gets or sets the image that is displayed on a button control.
		/// </summary>
		[SRDescription("ButtonImageDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(null)]
		[ProxyBrowsable(true)]
		public ResourceHandle Image
		{
			get
			{
				return GetImage(ImageProperty, ImageList, ImageIndex, ImageKey, -1, string.Empty);
			}
			set
			{
				InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
				SetImage(ImageProperty, value, ImageList);
			}
		}

		/// 
		/// Gets or sets the alignment of the image on the button control.
		/// </summary>
		[DefaultValue(ContentAlignment.MiddleCenter)]
		[ProxyBrowsable(true)]
		public ContentAlignment ImageAlign
		{
			get
			{
				return GetValue(ImageAlignProperty);
			}
			set
			{
				if (SetValue(ImageAlignProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the text align.
		/// </summary>
		/// </value>
		[DefaultValue(ContentAlignment.MiddleCenter)]
		[ProxyBrowsable(true)]
		public virtual ContentAlignment TextAlign
		{
			get
			{
				return GetValue(TextAlignProperty);
			}
			set
			{
				if (SetValue(TextAlignProperty, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets the position of text and image relative to each other.</summary>
		/// One of the values of <see cref="T:Gizmox.WebGUI.Forms.TextImageRelation"></see>. The default is <see cref="F:Gizmox.WebGUI.Forms.TextImageRelation.Overlay"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value is not one of the <see cref="T:Gizmox.WebGUI.Forms.TextImageRelation"></see> values.</exception>
		[Localizable(false)]
		[SRCategory("CatAppearance")]
		[DefaultValue(TextImageRelation.Overlay)]
		[SRDescription("ButtonTextImageRelationDescr")]
		[ProxyBrowsable(true)]
		public TextImageRelation TextImageRelation
		{
			get
			{
				return GetValue(TextImageRelationProperty);
			}
			set
			{
				if (SetValue(TextImageRelationProperty, value))
				{
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					Update();
				}
			}
		}

		/// Gets or sets the index of the image that is displayed for the item.</summary>
		/// The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
		/// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.NoneExcludedImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[DefaultValue(-1)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRDescription("ListViewItemImageIndexDescr")]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		public int ImageIndex
		{
			get
			{
				return ImageIndexInternal;
			}
			set
			{
				if (ImageIndexInternal != value)
				{
					ImageKeyInternal = string.Empty;
					ImageIndexInternal = value;
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the image index internal.
		/// </summary>
		/// The image index internal.</value>
		internal int ImageIndexInternal
		{
			get
			{
				return GetValue(ImageIndexProperty);
			}
			set
			{
				SetValue(ImageIndexProperty, value);
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to use when displaying items as small icons in the control.</summary>
		/// An <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains the icons to use when the <see cref="P:Gizmox.WebGUI.Forms.ListView.View"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.View.SmallIcon"></see>. The default is null.</returns>
		/// 2</filterpriority>
		[SRDescription("ButtonImageListDescr")]
		[SRCategory("CatAppearance")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[DefaultValue(null)]
		public ImageList ImageList
		{
			get
			{
				return GetValue(ImageListItemProperty);
			}
			set
			{
				if (SetValue(ImageListItemProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the size of the image.
		/// </summary>
		/// 
		/// The size of the image.
		/// </value>
		public Size ImageSize
		{
			get
			{
				return ImageList?.ImageSize ?? GetValue(ImageSizeProperty);
			}
			set
			{
				if (ImageList != null)
				{
					throw new ArgumentException("Cannot set image size when an ImageList is assigned.", "ImageSize");
				}
				if (SetValue(ImageSizeProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets a value indicating whether this instance has image size.
		/// </summary>
		/// 
		/// 	true</c> if this instance has image size; otherwise, false</c>.
		/// </value>
		protected bool HasImageSize => ImageList != null || ContainsValue(ImageSizeProperty);

		/// Gets or sets the key for the image that is displayed for the item.</summary>
		/// The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Localizable(true)]
		[DefaultValue("")]
		public string ImageKey
		{
			get
			{
				return ImageKeyInternal;
			}
			set
			{
				if (ImageKeyInternal != value)
				{
					ImageIndexInternal = -1;
					ImageKeyInternal = value;
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the image key internal.
		/// </summary>
		/// The image key internal.</value>
		internal string ImageKeyInternal
		{
			get
			{
				return GetValue(ImageKeyProperty);
			}
			set
			{
				SetValue(ImageKeyProperty, value);
			}
		}

		/// 
		/// Gets or sets the text associated with this control.
		/// </summary>
		/// </value>
		[Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[SettingsBindable(true)]
		public override string Text
		{
			get
			{
				if (UseMnemonic)
				{
					return GetCommandText(base.Text);
				}
				return base.Text;
			}
			set
			{
				if (base.Text != value)
				{
					base.Text = value;
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the flat style.
		/// </summary>
		/// </value>
		[DefaultValue(FlatStyle.Standard)]
		public FlatStyle FlatStyle
		{
			get
			{
				return GetValue(FlatStyleProperty);
			}
			set
			{
				if (SetValue(FlatStyleProperty, value))
				{
					if (value == FlatStyle.Flat)
					{
						CustomStyle = "F";
					}
					else
					{
						CustomStyle = string.Empty;
					}
					Update();
				}
			}
		}

		/// Gets or sets a value indicating whether the ellipsis character (...) appears at the right edge of the control, denoting that the control text extends beyond the specified length of the control.</summary>
		/// true if the additional label text is to be indicated by an ellipsis; otherwise, false. The default is true.</returns>
		[SRDescription("ButtonAutoEllipsisDescr")]
		[SRCategory("CatBehavior")]
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DefaultValue(false)]
		public bool AutoEllipsis
		{
			get
			{
				return GetState(ComponentState.AutoEllipsis);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.AutoEllipsis, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets a value that indicates whether the control resizes based on its contents.</summary>
		/// true if the control automatically resizes based on its contents; otherwise, false. The default is true.</returns>
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public override bool AutoSize
		{
			get
			{
				return base.AutoSize;
			}
			set
			{
				base.AutoSize = value;
				if (value)
				{
					AutoEllipsis = false;
				}
			}
		}

		/// 
		/// Gets the default size.
		/// </summary>
		/// The default size.</value>
		protected override Size DefaultSize => new Size(75, 23);

		/// Gets the appearance of the border and the colors used to indicate check state and mouse state.</summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.FlatButtonAppearance"></see> values.</returns>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRCategory("CatAppearance")]
		[SRDescription("ButtonFlatAppearance")]
		public FlatButtonAppearance FlatAppearance => new FlatButtonAppearance(this);

		/// Gets or sets a value that determines whether to use the compatible text rendering engine (GDI+) or not (GDI).</summary>
		/// true if the compatible text rendering engine (GDI+) is used; otherwise, false.</returns>
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		[SRDescription("UseCompatibleTextRenderingDescr")]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public bool UseCompatibleTextRendering
		{
			get
			{
				return GetValue(UseCompatibleTextRenderingProperty);
			}
			set
			{
				SetValue(UseCompatibleTextRenderingProperty, value);
			}
		}

		/// Gets or sets a value indicating whether an ampersand (&amp;) is included in the text of the control.</summary>
		/// true if an ampersand is shown; otherwise, false. The default is true.</returns>
		[DefaultValue(true)]
		[SRCategory("CatAppearance")]
		[SRDescription("ButtonUseMnemonicDescr")]
		public bool UseMnemonic
		{
			get
			{
				return GetValue(UseMnemonicProperty);
			}
			set
			{
				if (SetValue(UseMnemonicProperty, value))
				{
					Update();
				}
			}
		}

		/// Gets or sets a value that determines if the background is drawn using visual styles, if supported.</summary>
		/// true if the background is drawn using visual styles; otherwise, false.</returns>
		[SRDescription("ButtonUseVisualStyleBackColorDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(false)]
		public bool UseVisualStyleBackColor
		{
			get
			{
				return GetValue(UseVisualStyleBackColorProperty);
			}
			set
			{
				if (SetValue(UseVisualStyleBackColorProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.Control" /> is focusable.
		/// </summary>
		/// true</c> if focusable; otherwise, false</c>.</value>
		protected override bool Focusable => true;

		/// 
		/// Gets or sets the background color.
		/// </summary>
		/// </value>
		[SRDescription("ControlBackColorDescr")]
		[SRCategory("CatAppearance")]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				if (base.DesignMode)
				{
					if (value != Color.Empty)
					{
						UseVisualStyleBackColor = false;
					}
				}
				else
				{
					UseVisualStyleBackColor = false;
				}
				base.BackColor = value;
			}
		}

		/// 
		/// Gets a value indicating whether raise click event on mouse down.
		/// </summary>
		/// 
		/// 	true</c> if should raise click event on mouse down; otherwise, false</c>.
		/// </value>
		protected override bool ShouldRaiseClickOnRightMouseDown => false;

		/// 
		/// Gets a value indicating whether [supports key navigation].
		/// </summary>
		/// 
		/// true</c> if [supports key navigation]; otherwise, false</c>.
		/// </value>
		protected override bool SupportsKeyNavigation => false;

		/// 
		/// Occurs when the value of the <see cref="P:Gizmox.WebGUI.Forms.ButtonBase.AutoSize">
		/// </see> property changes.
		/// </summary>
		[Browsable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[SRDescription("ControlOnAutoSizeChangedDescr")]
		[SRCategory("CatPropertyChanged")]
		public new event EventHandler AutoSizeChanged
		{
			add
			{
				base.AutoSizeChanged += value;
			}
			remove
			{
				base.AutoSizeChanged -= value;
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ButtonBase"></see> 
		/// class.
		/// </summary>
		protected ButtonBase()
		{
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			objWriter.WriteAttributeText("TX", Text);
			objWriter.WriteAttributeString("TA", GetProxyPropertyValue("TextAlign", TextAlign).ToString());
			if (AutoEllipsis)
			{
				objWriter.WriteAttributeString("AE", "1");
			}
			ResourceHandle proxyPropertyValue = GetProxyPropertyValue("Image", Image);
			if (proxyPropertyValue != null)
			{
				objWriter.WriteAttributeString("IM", proxyPropertyValue.ToString());
				objWriter.WriteAttributeString("IA", GetProxyPropertyValue("ImageAlign", GetProxyPropertyValue("ImageAlign", ImageAlign)).ToString());
				objWriter.WriteAttributeString("TIR", ((int)GetProxyPropertyValue("TextImageRelation", GetProxyPropertyValue("TextImageRelation", TextImageRelation))).ToString());
			}
			else
			{
				objWriter.WriteAttributeString("TIR", "0");
			}
		}

		/// 
		/// An abstract param attribute rendering
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				objWriter.WriteAttributeText("TX", Text);
			}
		}

		/// 
		/// Shoulds the serialize image.
		/// </summary>
		/// </returns>
		protected bool ShouldSerializeImage()
		{
			return Image != null;
		}

		/// 
		/// Shoulds the size of the serialize image.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeImageSize()
		{
			return ContainsValue(ImageSizeProperty);
		}

		/// 
		/// Shoulds serialize the use visual style back color.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeUseVisualStyleBackColor()
		{
			return UseVisualStyleBackColor;
		}

		/// 
		/// Retrieves the size of a rectangular area into which a control can be fitted.
		/// </summary>
		/// <param name="objProposedSize">The custom-sized area for a control.</param>
		/// </returns>
		public override Size GetPreferredSize(Size objProposedSize)
		{
			Size result = base.GetPreferredSize(objProposedSize);
			if (AutoSize)
			{
				result = GetStringMeasurements(Text, Font);
			}
			return result;
		}

		/// 
		/// Gets the string measurements.
		/// </summary>
		/// <param name="strText">The STR text.</param>
		/// <param name="objFont">The obj font.</param>
		/// </returns>
		protected virtual Size GetStringMeasurements(string strText, Font objFont)
		{
			return CommonUtils.GetStringMeasurements(strText, objFont);
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new ButtonBaseRenderer(this);
		}

		/// 
		/// Commits the value editing.
		/// </summary>
		/// <param name="objFormattedValue">The object formatted value.</param>
		protected override void CommitValueEditing(object objFormattedValue)
		{
			if (objFormattedValue != null && objFormattedValue is string)
			{
				Text = objFormattedValue.ToString();
			}
		}

		/// 
		/// Resets the size of the image.
		/// </summary>
		protected virtual void ResetImageSize()
		{
			RemoveValue(ImageSizeProperty);
		}
	}
}
