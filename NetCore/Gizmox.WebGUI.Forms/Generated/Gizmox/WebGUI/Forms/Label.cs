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
	/// Represents a standard Gizmox.WebGUI label.
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(Label), "Label_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.LabelController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.LabelController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolboxItem("System.Windows.Forms.Design.AutoSizeToolboxItem,System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[SRDescription("DescriptionLabel")]
	[DefaultProperty("Text")]
	[ToolboxItemCategory("Common Controls")]
	[MetadataTag("L")]
	[Skin(typeof(LabelSkin))]
	public class Label : Control
	{
		/// 
		/// Provides a property reference to Image property.
		/// </summary>
		private static SerializableProperty ImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(Label));

		/// 
		/// Provides a property reference to ImageList property.
		/// </summary>
		private static SerializableProperty ImageListProperty = SerializableProperty.Register("ImageList", typeof(ImageList), typeof(Label));

		/// 
		/// Provides a property reference to ImageKey property.
		/// </summary>
		private static SerializableProperty ImageKeyProperty = SerializableProperty.Register("ImageKey", typeof(string), typeof(Label));

		/// 
		/// Provides a property reference to ImageIndex property.
		/// </summary>
		private static SerializableProperty ImageIndexProperty = SerializableProperty.Register("ImageIndex", typeof(int), typeof(Label), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to ImageAlign property.
		/// </summary>
		private static SerializableProperty ImageAlignProperty = SerializableProperty.Register("ImageAlign", typeof(ContentAlignment), typeof(Label));

		/// 
		/// Provides a property reference to TextAlign property.
		/// </summary>
		private static SerializableProperty TextAlignProperty = SerializableProperty.Register("TextAlign", typeof(ContentAlignment), typeof(Label));

		/// 
		/// Provides a property reference to UseMnemonic property.
		/// </summary>
		private static SerializableProperty UseMnemonicProperty = SerializableProperty.Register("UseMnemonic", typeof(bool), typeof(Label), new SerializablePropertyMetadata(true));

		/// 
		/// Gets a value indicating whether [can edit control].
		/// </summary>
		/// 
		///   true</c> if [can edit control]; otherwise, false</c>.
		/// </value>
		public override bool CanEditControl => true;

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// </value>
		public override Padding Padding
		{
			get
			{
				return base.Padding;
			}
			set
			{
				if (base.Padding != value)
				{
					base.Padding = value;
					if (AutoSize)
					{
						PerformLayout(blnForceLayout: true);
					}
				}
			}
		}

		/// 
		/// Gets or sets the alignment of text in the label.
		/// </summary>
		/// One of the <see cref="T:System.Drawing.ContentAlignment"></see> values. The default is <see cref="F:System.Drawing.ContentAlignment.TopLeft"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:System.Drawing.ContentAlignment"></see> values. </exception>
		[SRCategory("CatAppearance")]
		[DefaultValue(ContentAlignment.TopLeft)]
		[SRDescription("LabelTextAlignDescr")]
		[Localizable(true)]
		[ProxyBrowsable(true)]
		public ContentAlignment TextAlign
		{
			get
			{
				return GetValue(TextAlignProperty, ContentAlignment.TopLeft);
			}
			set
			{
				if (TextAlign != value)
				{
					Update();
					if (value != ContentAlignment.TopLeft)
					{
						SetValue(TextAlignProperty, value);
					}
					else
					{
						RemoveValue(TextAlignProperty);
					}
					FireObservableItemPropertyChanged("TextAlign");
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether the control is automatically resized to display its entire contents.
		/// </summary>
		/// true if the control adjusts its width to closely fit its contents; otherwise, false. The default is true.</returns>
		[DefaultValue(false)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[SRDescription("LabelAutoSizeDescr")]
		[SRCategory("CatLayout")]
		[RefreshProperties(RefreshProperties.All)]
		[Localizable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(true)]
		public new bool AutoSize
		{
			get
			{
				return base.AutoSize;
			}
			set
			{
				base.AutoSize = value;
			}
		}

		/// 
		/// Gets or sets a value indicating whether tab stop is enabled.
		/// </summary>
		/// true</c> if tab stop is enabled; otherwise, false</c>.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DefaultValue(false)]
		[Browsable(false)]
		public new bool TabStop
		{
			get
			{
				return base.TabStop;
			}
			set
			{
				base.TabStop = value;
			}
		}

		/// 
		/// Gets or sets the text associated with this control.
		/// </summary>
		/// The text associated with this control.</returns>
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
				string text = ((value == null) ? "" : value);
				if (base.Text != text)
				{
					base.Text = text;
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the background image displayed in the control.
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[SRDescription("LabelBackgroundImageDescr")]
		[SRCategory("CatAppearance")]
		public override ResourceHandle BackgroundImage
		{
			get
			{
				return base.BackgroundImage;
			}
			set
			{
				base.BackgroundImage = value;
			}
		}

		/// 
		/// Gets or sets the background image layout as defined in the <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> enumeration.
		/// </summary>
		/// </value>
		/// One of the values of <see cref="T:Gizmox.WebGUI.Forms.ImageLayout"></see> (<see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Center"></see> , <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.None"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Stretch"></see>, <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see>, or <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Zoom"></see>). <see cref="F:Gizmox.WebGUI.Forms.ImageLayout.Tile"></see> is the default value.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override ImageLayout BackgroundImageLayout
		{
			get
			{
				return base.BackgroundImageLayout;
			}
			set
			{
				base.BackgroundImageLayout = value;
			}
		}

		/// 
		///  Gets or sets the flat style appearance of the label control.
		///  </summary>
		///  One of the <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> values. The default value is Standard.</returns>
		/// 	<exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The value assigned is not one of the <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> values. </exception>
		[SRCategory("CatAppearance")]
		[DefaultValue(FlatStyle.Standard)]
		[SRDescription("ButtonFlatStyleDescr")]
		public FlatStyle FlatStyle
		{
			get
			{
				return FlatStyle.Standard;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets the alignment of the image on the button control.
		/// </summary>
		[DefaultValue(ContentAlignment.MiddleCenter)]
		public ContentAlignment ImageAlign
		{
			get
			{
				return GetValue(ImageAlignProperty, ContentAlignment.MiddleCenter);
			}
			set
			{
				if (ImageAlign != value)
				{
					Update();
					if (value != ContentAlignment.MiddleCenter)
					{
						SetValue(ImageAlignProperty, value);
					}
					else
					{
						RemoveValue(ImageAlignProperty);
					}
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
				return GetValue(ImageIndexProperty, -1);
			}
			set
			{
				if (ImageIndex != value)
				{
					if (value != -1)
					{
						SetValue(ImageIndexProperty, value);
					}
					else
					{
						RemoveValue(ImageIndexProperty);
					}
					RemoveValue(ImageKeyProperty);
					Update();
				}
			}
		}

		/// Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> to use when displaying items as small icons in the control.</summary>
		/// An <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that contains the icons to use when the <see cref="P:Gizmox.WebGUI.Forms.ListView.View"></see> property is set to <see cref="F:Gizmox.WebGUI.Forms.View.SmallIcon"></see>. The default is null.</returns>
		/// 2</filterpriority>
		[SRDescription("ListViewSmallImageListDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(null)]
		public ImageList ImageList
		{
			get
			{
				return GetValue(ImageListProperty, null);
			}
			set
			{
				if (ImageList != value)
				{
					if (value != null)
					{
						SetValue(ImageListProperty, value);
					}
					else
					{
						RemoveValue(ImageListProperty);
					}
					Update();
				}
			}
		}

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
				return GetValue(ImageKeyProperty, string.Empty);
			}
			set
			{
				if (ImageKey != value)
				{
					if (value != string.Empty)
					{
						SetValue(ImageKeyProperty, value);
					}
					else
					{
						RemoveValue(ImageKeyProperty);
					}
					RemoveValue(ImageIndexProperty);
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the image that is displayed on a button control.
		/// </summary>
		[SRCategory("CatAppearance")]
		[SRDescription("ButtonImageDescr")]
		[ProxyBrowsable(true)]
		public ResourceHandle Image
		{
			get
			{
				return GetImage(ImageProperty, ImageList, ImageIndex, ImageKey, -1, string.Empty);
			}
			set
			{
				SetImage(ImageProperty, value, ImageList);
			}
		}

		/// 
		/// Gets the default size.
		/// </summary>
		/// The default size.</value>
		protected override Size DefaultSize => new Size(100, 23);

		/// 
		/// Gets or sets the value that indicating how a control will behave when its <see cref="P:Gizmox.WebGUI.Forms.Control.AutoSize"></see> property is enabled.
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.AutoSizeMode"></see> values.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override AutoSizeMode AutoSizeMode => AutoSizeMode.GrowAndShrink;

		/// Gets or sets a value indicating whether the control interprets an ampersand character (&amp;) in the control's <see cref="P:System.Windows.Forms.Control.Text"></see> property to be an access key prefix character.</summary>
		/// true if the label doesn't display the ampersand character and underlines the character after the ampersand in its displayed text and treats the underlined character as an access key; otherwise, false if the ampersand character is displayed in the text of the control. The default is true.</returns>
		/// 2</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRCategory("CatAppearance")]
		[DefaultValue(true)]
		[SRDescription("LabelUseMnemonicDescr")]
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
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					Update();
				}
			}
		}

		/// Gets or sets a value that specifies whether text rendering should be compatible with previous releases of Windows Forms.</summary>
		/// true if text rendering should be compatible with previous releases of Windows Forms; otherwise, false. The default is false.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		[SRDescription("UseCompatibleTextRenderingDescr")]
		public bool UseCompatibleTextRendering
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// Gets or sets a value indicating whether the ellipsis character (...) appears at the right edge of the <see cref="T:System.Windows.Forms.Label"></see>, denoting that the <see cref="T:System.Windows.Forms.Label"></see> text extends beyond the specified length of the <see cref="T:System.Windows.Forms.Label"></see>.</summary>
		/// true if the additional label text is to be indicated by an ellipsis; otherwise, false. The default is false.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("LabelAutoEllipsisDescr")]
		[DefaultValue(false)]
		[SRCategory("CatBehavior")]
		public bool AutoEllipsis
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Label"></see> class.
		/// </summary>
		public Label()
		{
			SetState(ControlState.TabStop, blnValue: false);
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, IsOwnerDraw());
			SetStyle(ControlStyles.FixedHeight | ControlStyles.Selectable, blnValue: false);
			SetStyle(ControlStyles.ResizeRedraw, blnValue: true);
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Label"></see> class.
		/// </summary>
		/// <param name="strText">The label text.</param>
		public Label(string strText)
			: this()
		{
			Text = strText;
		}

		/// 
		/// Determines whether is owner draw.
		/// </summary>
		/// 
		/// 	true</c> if is owner draw; otherwise, false</c>.
		/// </returns>
		internal bool IsOwnerDraw()
		{
			return FlatStyle != FlatStyle.System;
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
				Padding padding = Padding;
				int intWidth = -1;
				Size maximumSize = MaximumSize;
				if (!maximumSize.IsEmpty)
				{
					intWidth = maximumSize.Width - padding.Horizontal;
				}
				result = CommonUtils.GetStringMeasurements(Text, Font, intWidth);
				if (AutoSizeMode == AutoSizeMode.GrowOnly)
				{
					result.Width = Math.Max(result.Width, objProposedSize.Width);
					result.Height = Math.Max(result.Height, objProposedSize.Height);
				}
				result.Width += padding.Horizontal;
				result.Height += padding.Vertical;
			}
			return result;
		}

		/// 
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			objWriter.WriteAttributeText("TX", Text);
			objWriter.WriteAttributeString("TA", GetProxyPropertyValue("TextAlign", TextAlign).ToString());
			if (AutoSize)
			{
				objWriter.WriteAttributeString("AS", "1");
			}
			ResourceHandle proxyPropertyValue = GetProxyPropertyValue("Image", Image);
			if (proxyPropertyValue != null)
			{
				objWriter.WriteAttributeString("IM", proxyPropertyValue.ToString());
				objWriter.WriteAttributeString("IA", ImageAlign.ToString());
			}
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new LabelRenderer(this);
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
		/// Shoulds the serialize image.
		/// </summary>
		/// </returns>
		protected bool ShouldSerializeImage()
		{
			return Image != null;
		}
	}
}
