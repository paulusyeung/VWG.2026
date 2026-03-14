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
	/// ToolBar control.
	/// </summary>
	[Serializable]
	[ToolboxBitmap(typeof(ToolBar), "ToolBar_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[ToolboxItem(true)]
	[ToolboxItemCategory("Menus & Toolbars")]
	[MetadataTag("T1")]
	[DefaultEvent("ButtonClick")]
	[Skin(typeof(ToolBarSkin))]
	[ProxyComponent(typeof(ProxyToolBar))]
	public class ToolBar : Control
	{
		/// 
		/// Provides a property reference to MenuHandle property.
		/// </summary>
		private static SerializableProperty MenuHandleProperty = SerializableProperty.Register("MenuHandle", typeof(bool), typeof(ToolBar));

		/// 
		/// Provides a property reference to DragHandle property.
		/// </summary>
		private static SerializableProperty DragHandleProperty = SerializableProperty.Register("DragHandle", typeof(bool), typeof(ToolBar));

		/// 
		/// Provides a property reference to TextAlign property.
		/// </summary>
		private static SerializableProperty TextAlignProperty = SerializableProperty.Register("TextAlign", typeof(ToolBarTextAlign), typeof(ToolBar));

		/// 
		/// Provides a property reference to Appearance property.
		/// </summary>
		private static SerializableProperty AppearanceProperty = SerializableProperty.Register("Appearance", typeof(ToolBarAppearance), typeof(ToolBar));

		/// 
		/// Provides a property reference to RightToLeft property.
		/// </summary>
		private static SerializableProperty RightToLeftProperty = SerializableProperty.Register("RightToLeft", typeof(bool), typeof(ToolBar));

		/// 
		/// Provides a property reference to ButtonSize property.
		/// </summary>
		private static SerializableProperty ButtonSizeProperty = SerializableProperty.Register("ButtonSize", typeof(Size), typeof(ToolBar));

		/// 
		/// Provides a property reference to ImageSize property.
		/// </summary>
		private static SerializableProperty ImageSizeProperty = SerializableProperty.Register("ImageSize", typeof(Size), typeof(ToolBar));

		/// 
		/// Provides a property reference to ImageList property.
		/// </summary>
		private static SerializableProperty ImageListProperty = SerializableProperty.Register("ImageList", typeof(ImageList), typeof(ToolBar));

		/// 
		/// Provides a property reference to ButtonsSizeAttribute property.
		/// </summary>
		private static SerializableProperty ButtonsSizeAttributeProperty = SerializableProperty.Register("ButtonsSizeAttribute", typeof(string), typeof(ToolBar));

		/// 
		/// Provides a property reference to ButtonsDock property.
		/// </summary>
		private static SerializableProperty ButtonsDockProperty = SerializableProperty.Register("ButtonsDock", typeof(string), typeof(ToolBar));

		/// 
		/// Provides a property reference to Buttons property.
		/// </summary>
		private static SerializableProperty ButtonsProperty = SerializableProperty.Register("Buttons", typeof(ToolBarItemCollection), typeof(ToolBar));

		/// 
		/// The ButtonClick event registration.
		/// </summary>
		private static readonly SerializableEvent ButtonClickEvent;

		/// 
		/// Gets the hanlder for the ButtonClick event.
		/// </summary>
		internal ToolBarButtonClickEventHandler ButtonClickHandler => (ToolBarButtonClickEventHandler)GetHandler(ButtonClick);

		/// 
		/// Gets the list of tags that client events are propogated to.
		/// </summary>
		/// 
		/// The client event propogated tags.
		/// </value>
		protected override string ClientEventsPropogationTags => string.Format("WC:{0}", "T2");

		/// 
		/// Gets the tool bar button skin.
		/// </summary>
		/// The tool bar button skin.</value>
		private ToolBarButtonSkin ToolBarButtonSkin
		{
			get
			{
				ToolBarButtonSkin result = null;
				if (Buttons.Count > 0)
				{
					result = SkinFactory.GetSkin(Buttons[0], typeof(ToolBarButtonSkin)) as ToolBarButtonSkin;
				}
				return result;
			}
		}

		/// 
		/// This property is not relevant for this class.
		/// </summary>
		/// </value>
		/// true if enabled; otherwise, false.</returns>
		[SRDescription("ToolBarAutoSizeDescr")]
		[Localizable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[SRCategory("CatBehavior")]
		[DefaultValue(true)]
		public override bool AutoSize
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
		/// Gets or sets the background image displayed in the control.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
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
		/// Gets or sets the background color.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		/// 
		///
		/// </summary>
		internal string ButtonsDock
		{
			get
			{
				return GetValue(ButtonsDockProperty, "L");
			}
			private set
			{
				if (ButtonsDock != value)
				{
					if (value != "L")
					{
						SetValue(ButtonsDockProperty, value);
					}
					else
					{
						RemoveValue(ButtonsDockProperty);
					}
				}
			}
		}

		/// 
		///
		/// </summary>
		internal string ButtonsSizeAttribute
		{
			get
			{
				return GetValue(ButtonsSizeAttributeProperty, "W");
			}
			private set
			{
				if (ButtonsSizeAttribute != value)
				{
					if (value != "W")
					{
						SetValue(ButtonsSizeAttributeProperty, value);
					}
					else
					{
						RemoveValue(ButtonsSizeAttributeProperty);
					}
				}
			}
		}

		/// 
		/// Gets or sets the toolbar image list.
		/// </summary>
		/// </value>
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
					Update();
					if (value != null)
					{
						SetValue(ImageListProperty, value);
					}
					else
					{
						RemoveValue(ImageListProperty);
					}
				}
			}
		}

		/// Gets the size of the images in the image list assigned to the toolbar.</summary>
		/// A <see cref="T:System.Drawing.Size"></see> that represents the size of the images (in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see>) assigned to the <see cref="T:Gizmox.WebGUI.Forms.ToolBar"></see>.</returns>
		/// 1</filterpriority>
		[SRDescription("ToolBarImageSizeDescr")]
		[SRCategory("CatBehavior")]
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public Size ImageSize
		{
			get
			{
				if (ImageList != null)
				{
					return ImageList.ImageSize;
				}
				Size value = GetValue(ImageSizeProperty, Size.Empty);
				if (value != Size.Empty)
				{
					return value;
				}
				return new Size(16, 16);
			}
			set
			{
				if (ImageList != null)
				{
					throw new ArgumentException("Cannot set image size when an ImageList is assigned.", "ImageSize");
				}
				if (GetValue(ImageSizeProperty, Size.Empty) != value)
				{
					if (value != Size.Empty)
					{
						SetValue(ImageSizeProperty, value);
					}
					else
					{
						RemoveValue(ImageSizeProperty);
					}
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the size of the buttons.
		/// </summary>
		/// </value>
		public Size ButtonSize
		{
			get
			{
				Size buttonSizeInternal = ButtonSizeInternal;
				if (!buttonSizeInternal.IsEmpty)
				{
					return buttonSizeInternal;
				}
				if (Buttons != null && Buttons.Count > 0)
				{
					return CalculateSize();
				}
				if (TextAlign == ToolBarTextAlign.Underneath)
				{
					return new Size(39, 36);
				}
				return new Size(23, 22);
			}
			set
			{
				Size buttonSizeInternal = ButtonSizeInternal;
				if (buttonSizeInternal != value)
				{
					ButtonSizeInternal = value;
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					Update();
				}
			}
		}

		internal Size ButtonSizeInternal
		{
			get
			{
				return GetValue(ButtonSizeProperty, Size.Empty);
			}
			set
			{
				if (value != Size.Empty)
				{
					SetValue(ButtonSizeProperty, value);
				}
				else
				{
					RemoveValue(ButtonSizeProperty);
				}
			}
		}

		/// 
		/// Gets the toolbar button collecction
		/// </summary>
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public virtual ToolBarItemCollection Buttons => GetValue(ButtonsProperty, null);

		/// 
		/// Gets or sets a value indicating whether control's elements are aligned to support locales using right-to-left fonts.
		/// </summary>
		/// </value>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.RightToLeft.Inherit"></see>.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The assigned value is not one of the <see cref="T:Gizmox.WebGUI.Forms.RightToLeft"></see> values. </exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override RightToLeft RightToLeft
		{
			get
			{
				return base.RightToLeft;
			}
			set
			{
				base.RightToLeft = value;
			}
		}

		/// 
		/// Gets or sets the toolbar appearance.
		/// </summary>
		/// </value>
		[DefaultValue(ToolBarAppearance.Normal)]
		public ToolBarAppearance Appearance
		{
			get
			{
				return GetValue(AppearanceProperty, ToolBarAppearance.Normal);
			}
			set
			{
				if (Appearance != value)
				{
					Update();
					if (value != ToolBarAppearance.Normal)
					{
						SetValue(AppearanceProperty, value);
					}
					else
					{
						RemoveValue(AppearanceProperty);
					}
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether to show tooltips.
		/// </summary>
		/// 
		/// 	true</c> if to show tooltips; otherwise, false</c>.
		/// </value>
		public bool ShowToolTips
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets a value indicating whether to display dropdown arrows.
		/// </summary>
		/// 
		/// 	true</c> if to display dropdown arrows; otherwise, false</c>.
		/// </value>
		public bool DropDownArrows
		{
			get
			{
				return true;
			}
			set
			{
			}
		}

		/// 
		/// Gets or sets a value indicating whether tab stop is enabled.
		/// </summary>
		/// true</c> if tab stop is enabled; otherwise, false</c>.</value>
		[DefaultValue(false)]
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
		/// Gets the default text align.
		/// </summary>
		/// The default text align.</value>
		protected virtual ToolBarTextAlign DefaultTextAlign => ToolBarTextAlign.Underneath;

		/// Specifies the alignment of text on the toolbar button control.</summary>
		/// </value>        
		public ToolBarTextAlign TextAlign
		{
			get
			{
				return GetValue(TextAlignProperty, DefaultTextAlign);
			}
			set
			{
				if (TextAlign != value)
				{
					if (value != DefaultTextAlign)
					{
						SetValue(TextAlignProperty, value, DefaultTextAlign);
					}
					else
					{
						RemoveValue(TextAlignProperty);
					}
					InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether to display drag handle.
		/// </summary>
		/// 
		/// 	true</c> if to display drag handle; otherwise, false</c>.
		/// </value>
		public bool DragHandle
		{
			get
			{
				return GetValue(DragHandleProperty, objDefault: true);
			}
			set
			{
				if (DragHandle != value)
				{
					Update();
					if (!value)
					{
						SetValue(DragHandleProperty, value);
					}
					else
					{
						RemoveValue(DragHandleProperty);
					}
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether to display menu handle.
		/// </summary>
		/// 
		/// 	true</c> if to display menu handle; otherwise, false</c>.
		/// </value>
		public bool MenuHandle
		{
			get
			{
				return GetValue(MenuHandleProperty, objDefault: true);
			}
			set
			{
				if (MenuHandle != value)
				{
					Update();
					if (!value)
					{
						SetValue(MenuHandleProperty, value);
					}
					else
					{
						RemoveValue(MenuHandleProperty);
					}
				}
			}
		}

		/// 
		/// Gets the height of the tool bar.
		/// </summary>
		/// The height of the tool bar.</value>
		internal int ToolBarHeight
		{
			get
			{
				if (!(base.Skin is ToolBarSkin { Height: var height }))
				{
					return 25;
				}
				return height;
			}
		}

		/// 
		/// Gets or sets the text associated with this control.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Bindable(false)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		/// 
		/// Gets/Sets the controls docking style
		/// </summary>
		/// </value>
		[DefaultValue(DockStyle.Top)]
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				base.Dock = value;
			}
		}

		/// 
		/// Gets the default size.
		/// </summary>
		/// 
		/// The default size.
		/// </value>
		protected override Size DefaultSize => new Size(100, 22);

		/// 
		/// Gets the win forms compatibility.
		/// </summary>
		/// 
		/// The win forms compatibility.
		/// </value>
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public new ToolBarWinFormsCompatibility WinFormsCompatibility => base.WinFormsCompatibility as ToolBarWinFormsCompatibility;

		/// 
		/// Occurs when a user clicks on a button
		/// </summary>
		public event ToolBarButtonClickEventHandler ButtonClick
		{
			add
			{
				AddCriticalHandler(ButtonClickEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ButtonClickEvent, value);
			}
		}

		/// 
		/// Creates a new <see cref="T:Gizmox.WebGUI.Forms.ToolBar" /> instance.
		/// </summary>
		public ToolBar()
		{
			SetValue(ButtonsProperty, CreateButtonCollection());
			Dock = DockStyle.Top;
			AutoSize = true;
			SetStyle(ControlStyles.UserPaint, blnValue: false);
			SetStyle(ControlStyles.FixedHeight, AutoSize);
			SetStyle(ControlStyles.FixedWidth, blnValue: false);
			TabStop = false;
		}

		/// 
		/// Fires an contained event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		/// <param name="objButton">The obj button.</param>
		internal void FireEvent(IEvent objEvent, ToolBarButton objButton)
		{
			string type = objEvent.Type;
			if (type == "Click")
			{
				if (objButton != null)
				{
					OnButtonClick(new ToolBarButtonClickEventArgs(objButton));
				}
				OnClick(EventArgs.Empty);
			}
		}

		/// Raises the <see cref="E:System.Windows.Forms.ToolBar.ButtonClick"></see> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.ToolBarButtonClickEventArgs"></see> that contains the event data. </param>
		protected virtual void OnButtonClick(ToolBarButtonClickEventArgs e)
		{
			ButtonClickHandler?.Invoke(this, e);
		}

		/// 
		/// Determines if image size serialization is required.
		/// </summary>
		private bool ShouldSerializeImageSize()
		{
			return ImageList == null && ImageSize != Size.Empty;
		}

		/// 
		/// Resets the size of the image.
		/// </summary>
		private void ResetImageSize()
		{
			if (ImageList != null)
			{
				ImageSize = ImageList.ImageSize;
			}
			else
			{
				ImageSize = Size.Empty;
			}
		}

		/// 
		/// Resets the text align.
		/// </summary>
		private void ResetTextAlign()
		{
			TextAlign = DefaultTextAlign;
		}

		/// 
		/// Gets a value indicating whether this instance is horizontal.
		/// </summary>
		/// 
		/// 	true</c> if this instance is horizontal; otherwise, false</c>.
		/// </value>
		internal new bool IsHorizontalDocked(DockStyle enmDock)
		{
			return !IsLeftDocked(enmDock) && !IsRightDocked(enmDock);
		}

		/// 
		/// Indicates if to render padding attribute
		/// </summary>
		/// </returns>
		protected override bool ShouldRenderPaddingAttribute(Padding objPadding)
		{
			return PaddingValue.Empty != objPadding;
		}

		/// 
		/// Resets the size of the button.
		/// </summary>
		private void ResetButtonSize()
		{
			ButtonSize = Size.Empty;
		}

		/// 
		///
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected internal override void RenderControl(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			base.RenderControl(objContext, objWriter, lngRequestID);
		}

		/// 
		/// ToolBar render implementation
		/// </summary>
		protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			RegisterBatch(Buttons);
			ToolBarAppearance appearance = Appearance;
			if (Appearance == ToolBarAppearance.Flat)
			{
				objWriter.WriteAttributeString("S", "F");
			}
			objWriter.WriteAttributeString("IH", ImageSize.Height.ToString());
			objWriter.WriteAttributeString("IW", ImageSize.Width.ToString());
			if (TextAlign == ToolBarTextAlign.Underneath)
			{
				objWriter.WriteAttributeString("TIR", 1.ToString());
			}
			else
			{
				objWriter.WriteAttributeString("TIR", 4.ToString());
			}
			RenderControls(objContext, objWriter, lngRequestID);
		}

		/// 
		/// Render buttons
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter">The response writer object.</param>
		/// <param name="lngRequestID">Request ID.</param>
		protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			foreach (ToolBarButton item in (IEnumerable)Buttons)
			{
				item.RenderButton(objContext, objWriter, lngRequestID);
			}
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objWriter">The obj writer.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			objWriter.WriteAttributeString("TBIASPP", WinFormsCompatibility.IsToolBarItemAutoSizePreservedPlaceholders ? "1" : "0");
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
				objWriter.WriteAttributeString("TBIASPP", WinFormsCompatibility.IsToolBarItemAutoSizePreservedPlaceholders ? "1" : "0");
			}
		}

		/// 
		/// Creates the button collection.
		/// </summary>
		/// </returns>
		[Browsable(false)]
		protected virtual ToolBarItemCollection CreateButtonCollection()
		{
			return new ToolBarItemCollection(this);
		}

		/// 
		/// Gets the preferred size.
		/// </summary>
		/// <param name="objProposedSize">Size of the proposed.</param>
		/// </returns>
		public override Size GetPreferredSize(Size objProposedSize)
		{
			Size result = objProposedSize;
			if (Buttons == null || Buttons.Count == 0)
			{
				result = ButtonSize;
			}
			else if (AutoSize)
			{
				result = CalculateSize();
			}
			return result;
		}

		/// 
		/// Layout the internal controls to reflect parent changes
		/// </summary>
		/// <param name="objEventArgs">The layout arguments.</param>
		/// <param name="objNewSize">The new parent size.</param>
		/// <param name="objOldSize">The old parent size.</param>
		protected override void OnLayoutControls(LayoutEventArgs objEventArgs, ref Size objNewSize, ref Size objOldSize)
		{
		}

		/// 
		/// Calculates the size.
		/// </summary>
		/// </returns>
		private Size CalculateSize()
		{
			Size empty = Size.Empty;
			Size size = new Size(ImageSize.Width, ImageSize.Height);
			ToolBarButtonSkin toolBarButtonSkin = ToolBarButtonSkin;
			if (base.Skin is ToolBarSkin toolBarSkin)
			{
				bool flag = false;
				int num = 0;
				int num2 = 0;
				foreach (ToolBarButton item in (IEnumerable)Buttons)
				{
					int num3 = 0;
					int num4 = 0;
					if (item.Text != string.Empty)
					{
						flag = true;
						num3 = CommonUtils.GetStringMeasurements(item.Text, item.Font).Width;
						if (num3 > num)
						{
							num = num3;
						}
						num4 = CommonUtils.GetFontHeight(item.Font);
						if (num4 > num2)
						{
							num2 = num4;
						}
					}
				}
				if (TextAlign == ToolBarTextAlign.Underneath)
				{
					empty.Height = size.Height;
					if (flag)
					{
						empty.Height += num2;
					}
					empty.Width = Math.Max(num, size.Width);
				}
				else
				{
					empty.Height = Math.Max(CommonUtils.GetFontHeight(toolBarSkin.Font), size.Height);
					empty.Width = num + size.Width;
				}
				empty.Height += toolBarSkin.Padding.Vertical;
				empty.Width += toolBarSkin.Padding.Horizontal;
				empty.Height += toolBarSkin.TopFrameHeight + toolBarSkin.BottomFrameHeight;
				empty.Width += toolBarSkin.LeftFrameWidth + toolBarSkin.RightFrameWidth;
				if (toolBarButtonSkin != null)
				{
					DockStyle dock = Dock;
					if (dock == DockStyle.Top || dock == DockStyle.Bottom || dock == DockStyle.Fill)
					{
						empty.Height += toolBarButtonSkin.TopFrameHeight + toolBarButtonSkin.BottomFrameHeight;
						empty.Height += toolBarButtonSkin.Padding.Vertical + toolBarButtonSkin.Margin.Vertical;
					}
					else if (dock == DockStyle.Right || dock == DockStyle.Left || dock == DockStyle.Fill)
					{
						empty.Width += toolBarButtonSkin.LeftFrameWidth + toolBarButtonSkin.RightFrameWidth;
						empty.Width += toolBarButtonSkin.Padding.Horizontal + toolBarButtonSkin.Margin.Horizontal;
					}
				}
			}
			return empty;
		}

		internal void InternalRemove(ToolBarButton objToolBarButton)
		{
			UnRegisterComponent(objToolBarButton);
		}

		internal void InternalClear(ICollection objToolBarButtons)
		{
			UnRegisterBatch(objToolBarButtons);
			InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
			Update();
		}

		/// 
		/// Called when [register components].
		/// </summary>
		protected override void OnRegisterComponents()
		{
			base.OnRegisterComponents();
			ToolBarItemCollection buttons = Buttons;
			if (buttons != null)
			{
				RegisterBatch(buttons);
			}
		}

		/// 
		/// Called when [unregister components].
		/// </summary>
		protected override void OnUnregisterComponents()
		{
			base.OnUnregisterComponents();
			ToolBarItemCollection buttons = Buttons;
			if (buttons != null)
			{
				UnRegisterBatch(buttons);
			}
		}

		/// 
		/// Do not serialize the size on docked mode
		/// </summary>
		/// </returns>
		protected override bool ShouldSerializeClientSize()
		{
			return Dock == DockStyle.None;
		}

		/// 
		/// Do not serialize the button size if is empty
		/// </summary>
		/// </returns>
		private bool ShouldSerializeButtonSize()
		{
			return !ButtonSizeInternal.IsEmpty;
		}

		/// 
		/// Shoulds the text align serialize.
		/// </summary>
		/// </returns>
		private bool ShouldSerializeTextAlign()
		{
			return TextAlign != DefaultTextAlign;
		}

		/// 
		/// Gets the component offsprings.
		/// </summary>
		/// <param name="strOffspringTypeName">The offspring type.</param>
		/// </returns>
		protected internal override IList GetComponentOffsprings(string strOffspringTypeName)
		{
			return Buttons;
		}

		/// 
		/// Gets the win forms compatibility.
		/// </summary>
		/// </returns>
		protected override WinFormsCompatibility GetWinFormsCompatibility()
		{
			return new ToolBarWinFormsCompatibility();
		}

		/// 
		/// Called when WinFormsCompatibility option value is changed.
		/// </summary>
		protected override void OnWinFormsCompatibilityOptionValueChanged(string strChangedOptionName)
		{
			if (strChangedOptionName == "ToolBarItemAutoSizePreservedPlaceholders")
			{
				Update();
			}
			base.OnWinFormsCompatibilityOptionValueChanged(strChangedOptionName);
		}

		static ToolBar()
		{
			ButtonClickEvent = SerializableEvent.Register("ButtonClick", typeof(ToolBarButtonClickEventHandler), typeof(ToolBar));
		}
	}
}
