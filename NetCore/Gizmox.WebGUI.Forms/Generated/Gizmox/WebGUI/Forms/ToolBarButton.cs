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
	/// Summary description for ToolBarButton.
	/// </summary>
	[Serializable]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.ToolBarButtonController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.ToolBarButtonController, Gizmox, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DesignTimeVisible(false)]
	[DefaultEvent("Click")]
	[Skin(typeof(ToolBarButtonSkin))]
	public class ToolBarButton : Component, ISkinable
	{
		private static SerializableProperty NameProperty = SerializableProperty.Register("Name", typeof(string), typeof(ToolBarButton));

		private static SerializableProperty LabelProperty = SerializableProperty.Register("Label", typeof(string), typeof(ToolBarButton));

		private static SerializableProperty FontProperty = SerializableProperty.Register("Font", typeof(Font), typeof(ToolBarButton));

		private static SerializableProperty ForeColorProperty = SerializableProperty.Register("ForeColor", typeof(Color), typeof(ToolBarButton));

		private static SerializableProperty ToolTipTextProperty = SerializableProperty.Register("ToolTipText", typeof(string), typeof(ToolBarButton));

		private static SerializableProperty SizeProperty = SerializableProperty.Register("Size", typeof(int), typeof(ToolBarButton));

		private static SerializableProperty ImageIndexProperty = SerializableProperty.Register("ImageIndex", typeof(int), typeof(ToolBarButton));

		private static SerializableProperty ImageKeyProperty = SerializableProperty.Register("ImageKey", typeof(string), typeof(ToolBarButton));

		private static SerializableProperty StyleProperty = SerializableProperty.Register("Style", typeof(ToolBarButtonStyle), typeof(ToolBarButton));

		private static SerializableProperty DropDownProperty = SerializableProperty.Register("DropDown", typeof(ContextMenu), typeof(ToolBarButton));

		private static SerializableProperty CustomStyleProperty = SerializableProperty.Register("CustomStyle", typeof(string), typeof(ToolBarButton));

		/// 
		///
		/// </summary>
		public static readonly SerializableProperty ImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(ToolBarButton));

		/// 
		/// The Click event registration.
		/// </summary>
		private static readonly SerializableEvent ClickEvent;

		/// 
		/// The parent toolbar
		/// </summary>
		private ToolBar mobjToolBar = null;

		/// 
		/// Gets the hanlder for the Click event.
		/// </summary>
		private EventHandler ClickHandler => (EventHandler)GetHandler(ClickEvent);

		/// 
		/// This is a recursive function that loop through a control and all of its parents
		/// cheching if one of the controls(and control containers) is hidden or
		/// disabled.
		/// </summary>
		/// 
		/// 	true</c> if this instance is events enabled; otherwise, false</c>.
		/// </value>        
		/// false if one of the controls is hidden or disabled.</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool IsEventsEnabled
		{
			get
			{
				if (!Enabled || !Visible)
				{
					return false;
				}
				return base.IsEventsEnabled;
			}
		}

		/// 
		///             Gets or sets the text that appears as a ToolTip for the button.
		/// </summary>
		[Localizable(true)]
		[SRDescription("ToolBarButtonToolTipTextDescr")]
		public string ToolTipText
		{
			get
			{
				return GetValue(ToolTipTextProperty, string.Empty);
			}
			set
			{
				if (ToolTipText != value)
				{
					if (value != string.Empty)
					{
						SetValue(ToolTipTextProperty, value);
					}
					else
					{
						RemoveValue(ToolTipTextProperty);
					}
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the button style.
		/// </summary>
		/// </value>
		[DefaultValue(ToolBarButtonStyle.PushButton)]
		public ToolBarButtonStyle Style
		{
			get
			{
				return GetValue(StyleProperty, ToolBarButtonStyle.PushButton);
			}
			set
			{
				ToolBarButtonStyle style = Style;
				if (style != value)
				{
					if (style == ToolBarButtonStyle.ToggleButton)
					{
						Click -= PushButton_Click;
					}
					if (value != ToolBarButtonStyle.PushButton)
					{
						SetValue(StyleProperty, value);
					}
					else
					{
						RemoveValue(StyleProperty);
					}
					style = value;
					if (style == ToolBarButtonStyle.ToggleButton)
					{
						Click += PushButton_Click;
					}
					Update();
				}
			}
		}

		/// 
		/// Sets the current button fore color
		/// </summary>
		public Color ForeColor
		{
			get
			{
				return GetValue(ForeColorProperty, Color.Empty);
			}
			set
			{
				if (ForeColor != value)
				{
					if (value != Color.Empty)
					{
						SetValue(ForeColorProperty, value);
					}
					else
					{
						RemoveValue(ForeColorProperty);
					}
					Update();
				}
			}
		}

		/// 
		/// Sets the current toolbar button font
		/// </summary>
		[DefaultValue(null)]
		public Font Font
		{
			get
			{
				Font value = GetValue(FontProperty, null);
				if (value != null)
				{
					return value;
				}
				return GetOwnerFont();
			}
			set
			{
				if (Font != value)
				{
					if (value != null)
					{
						SetValue(FontProperty, value);
					}
					else
					{
						RemoveValue(FontProperty);
					}
					Update();
				}
			}
		}

		/// 
		///
		/// </summary>
		public virtual string CustomStyle
		{
			get
			{
				return GetValue(CustomStyleProperty, string.Empty);
			}
			set
			{
				if (CustomStyle != value)
				{
					if (value != string.Empty)
					{
						SetValue(CustomStyleProperty, value);
					}
					else
					{
						RemoveValue(CustomStyleProperty);
					}
					Update();
				}
			}
		}

		/// Gets or sets the index of the image that is displayed for the item.</summary>
		/// The zero-based index of the image in the <see cref="T:Gizmox.WebGUI.Forms.ImageList"></see> that is displayed for the item. The default is -1.</returns>
		/// <exception cref="T:System.ArgumentException">The value specified is less than -1. </exception>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.ImageIndexConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[DefaultValue(-1)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[RelatedImageList("ToolBar.ImageList")]
		[SRDescription("ToolBarButtonImageIndexDescr")]
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
					SetValue(ImageIndexProperty, value, -1);
					RemoveValue(ImageKeyProperty);
					InvalidateToolBarLayout();
					Update();
				}
			}
		}

		/// Gets or sets the key for the image that is displayed for the item.</summary>
		/// The key for the image that is displayed for the <see cref="T:Gizmox.WebGUI.Forms.ListViewItem"></see>.</returns>
		[Editor("Gizmox.WebGUI.Forms.Design.ImageIndexEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
		[TypeConverter("Gizmox.WebGUI.Forms.Design.ImageKeyConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
		[DefaultValue("")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[RelatedImageList("ToolBar.ImageList")]
		[SRDescription("ToolBarButtonImageIndexDescr")]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
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
					InvalidateToolBarLayout();
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the toolbar.
		/// </summary>
		/// </value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public ToolBar ToolBar
		{
			get
			{
				return mobjToolBar;
			}
			set
			{
				mobjToolBar = value;
			}
		}

		/// 
		///
		/// </summary>
		[Browsable(false)]
		[DefaultValue("")]
		public string Name
		{
			get
			{
				if (Site != null)
				{
					return Site.Name;
				}
				return GetValue(NameProperty, string.Empty);
			}
			set
			{
				if (Name != value)
				{
					Update();
					if (value != string.Empty)
					{
						SetValue(NameProperty, value);
					}
					else
					{
						RemoveValue(NameProperty);
					}
				}
			}
		}

		/// 
		/// Gets or sets the size.
		/// </summary>
		/// The size.</value>
		[DefaultValue(30)]
		public int Size
		{
			get
			{
				return GetValue(SizeProperty, 24);
			}
			set
			{
				if (Size != value)
				{
					if (value != 24)
					{
						SetValue(SizeProperty, value);
					}
					else
					{
						RemoveValue(SizeProperty);
					}
					Update();
				}
			}
		}

		private ImageList ImageList
		{
			get
			{
				if (ToolBar != null && ToolBar.ImageList != null)
				{
					return ToolBar.ImageList;
				}
				return null;
			}
		}

		/// 
		/// Gets a value indicating whether this instance is a seperator.
		/// </summary>
		/// 
		/// 	true</c> if this instance is a seperator; otherwise, false</c>.
		/// </value>
		private bool IsSeperator => Style == ToolBarButtonStyle.Separator;

		/// Gets or sets the small image that is displayed for the item.</summary>
		/// The small image that is displayed for the <see cref="T:System.Windows.Forms.ListViewItem"></see>.</returns>
		/// This property does not work and throws an exception if the owning listview has a ImageList set.</remarks>
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
		///
		/// </summary>
		[DefaultValue("")]
		[SRDescription("ToolBarButtonTextDescr")]
		[Localizable(true)]
		public string Text
		{
			get
			{
				return GetValue(LabelProperty, string.Empty);
			}
			set
			{
				if (Text != value)
				{
					if (value != string.Empty)
					{
						SetValue(LabelProperty, value);
					}
					else
					{
						RemoveValue(LabelProperty);
					}
					if (value == "-")
					{
						Style = ToolBarButtonStyle.Separator;
					}
					InvalidateToolBarLayout();
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.ToolBarButton" /> is pushed.
		/// </summary>
		/// true</c> if pushed; otherwise, false</c>.</value>
		[DefaultValue(false)]
		public bool Pushed
		{
			get
			{
				return GetState(ComponentState.Selected);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.Selected, value))
				{
					Update();
				}
			}
		}

		/// 
		///
		/// </summary>
		[DefaultValue(true)]
		public bool Visible
		{
			get
			{
				return GetState(ComponentState.Visible);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.Visible, value))
				{
					if (ToolBar != null)
					{
						ToolBar.Update();
					}
					else
					{
						Update();
					}
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.MenuItem" /> is enabled.
		/// </summary>
		/// 
		/// 	true</c> if enabled; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		public bool Enabled
		{
			get
			{
				return GetState(ComponentState.Enabled);
			}
			set
			{
				if (SetStateWithCheck(ComponentState.Enabled, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets the drop down menu.
		/// </summary>
		/// The drop down menu.</value>
		[DefaultValue(null)]
		public ContextMenu DropDownMenu
		{
			get
			{
				return GetValue(DropDownProperty, null);
			}
			set
			{
				ContextMenu contextMenu = DropDownMenu;
				if (contextMenu != value)
				{
					if (value != null)
					{
						contextMenu = value;
						SetValue(DropDownProperty, contextMenu);
					}
					else
					{
						RemoveValue(DropDownProperty);
					}
					Update();
				}
				if (contextMenu != null && contextMenu.InternalParent == null)
				{
					contextMenu.InternalParent = this;
				}
			}
		}

		/// 
		/// Gets the width of the seperator.
		/// </summary>
		/// The width of the seperator.</value>
		private int SeperatorWidth
		{
			get
			{
				if (SkinFactory.GetSkin(this) is ToolBarButtonSkin toolBarButtonSkin)
				{
					return toolBarButtonSkin.SeperatorWidth + toolBarButtonSkin.SeperatorStyle.Padding.Horizontal;
				}
				return 3;
			}
		}

		string ISkinable.Theme
		{
			get
			{
				ISkinable toolBar = ToolBar;
				if (toolBar != null)
				{
					return toolBar.Theme;
				}
				return string.Empty;
			}
		}

		/// 
		/// Occurs on clicking the button.
		/// </summary>
		public event EventHandler Click
		{
			add
			{
				AddCriticalHandler(ClickEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ClickEvent, value);
			}
		}

		/// 
		///
		/// </summary>
		public ToolBarButton()
		{
			InitializeButton();
		}

		/// 
		///
		/// </summary>
		/// <param name="strName"></param>
		/// <param name="strLabel"></param>
		public ToolBarButton(string strName, string strLabel)
		{
			Name = strName;
			SetValue(LabelProperty, strLabel);
			InitializeButton();
		}

		/// 
		/// Initializes the button.
		/// </summary>
		private void InitializeButton()
		{
			SetState(ComponentState.Visible | ComponentState.Enabled, blnValue: true);
		}

		/// 
		/// Invalidates the tool bar layout.
		/// </summary>
		private void InvalidateToolBarLayout()
		{
			ToolBar?.InvalidateLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			base.FireEvent(objEvent);
			string type = objEvent.Type;
			if (!(type == "Click"))
			{
				return;
			}
			MouseEventArgs e = new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, GetEventValue(objEvent, "X", 0), GetEventValue(objEvent, "Y", 0), 0);
			if (e.Button != MouseButtons.Right)
			{
				ToolBarButton objButton = this;
				if (DropDownMenu != null)
				{
					DropDownMenu.Show(this, Point.Empty, DialogAlignment.Below);
					objButton = null;
				}
				else
				{
					OnClick();
				}
				if (ToolBar != null)
				{
					ToolBar.FireEvent(objEvent, objButton);
				}
			}
		}

		/// 
		///
		/// </summary>
		private void OnClick()
		{
			if (ClickHandler != null)
			{
				ClickHandler(this, new EventArgs());
			}
		}

		/// 
		/// Shoulds the color of the serialize fore.
		/// </summary>
		/// </returns>
		protected virtual bool ShouldSerializeForeColor()
		{
			return ForeColor != Color.Empty;
		}

		/// 
		/// Gets the owner font.
		/// </summary>
		/// </returns>
		private Font GetOwnerFont()
		{
			if (ToolBar != null)
			{
				return ToolBar.Font;
			}
			return null;
		}

		/// 
		/// Shoulds the serialize image.
		/// </summary>
		/// </returns>
		protected bool ShouldSerializeImage()
		{
			if (ToolBar != null && ToolBar.ImageList != null)
			{
				return false;
			}
			return GetValue(ImageProperty, null) != null;
		}

		/// 
		///
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PushButton_Click(object sender, EventArgs e)
		{
			Pushed = !Pushed;
		}

		/// 
		/// Called when [register components].
		/// </summary>
		protected override void OnRegisterComponents()
		{
			base.OnRegisterComponents();
			ContextMenu dropDownMenu = DropDownMenu;
			if (dropDownMenu != null)
			{
				RegisterComponent(dropDownMenu);
			}
		}

		/// 
		/// Called when [unregister components].
		/// </summary>
		protected override void OnUnregisterComponents()
		{
			base.OnUnregisterComponents();
			ContextMenu dropDownMenu = DropDownMenu;
			if (dropDownMenu != null)
			{
				UnRegisterComponent(dropDownMenu);
			}
		}

		/// 
		/// Renders the button.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter">The response writer object.</param>
		/// <param name="lngRequestID">Request ID.</param>
		internal void RenderButton(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			if (!IsDirty(lngRequestID))
			{
				return;
			}
			ToolBar toolBar = ToolBar;
			if (toolBar != null)
			{
				objWriter.WriteStartElement(WGConst.ControlsPrefix, "T2", WGConst.ControlsNamespace);
				RenderComponentAttributes(objContext, (IAttributeWriter)objWriter);
				Size size = GetSize();
				if (toolBar.IsHorizontalDocked(toolBar.Dock))
				{
					objWriter.WriteAttributeString("D", GetHorizontalDocking(objContext, toolBar));
					objWriter.WriteAttributeString("W", size.Width.ToString());
				}
				else
				{
					objWriter.WriteAttributeString("D", "T");
					objWriter.WriteAttributeString("H", size.Height.ToString());
				}
				if (!Visible)
				{
					objWriter.WriteAttributeString("V", "0");
				}
				if (!Enabled)
				{
					objWriter.WriteAttributeString("En", "0");
				}
				string customStyle = CustomStyle;
				if (customStyle != string.Empty)
				{
					objWriter.WriteAttributeString("ES", customStyle);
				}
				string toolTipText = ToolTipText;
				if (toolTipText != string.Empty)
				{
					objWriter.WriteAttributeText("TT", toolTipText);
				}
				ToolBarButtonStyle style = Style;
				if (style != ToolBarButtonStyle.PushButton)
				{
					int num = (int)style;
					objWriter.WriteAttributeString("S", num.ToString());
				}
				if (style == ToolBarButtonStyle.ToggleButton)
				{
					objWriter.WriteAttributeString("PU", Pushed ? "1" : "0");
				}
				Color foreColor = ForeColor;
				if (foreColor != Color.Empty)
				{
					objWriter.WriteAttributeString("FR", CommonUtils.GetHtmlColor(foreColor));
				}
				objWriter.WriteAttributeString("FN", ClientUtils.GetWebFont(Font));
				ResourceHandle resourceHandle = Image;
				if (resourceHandle == null && CustomStyle != "Label" && ToolBar != null && ToolBar.WinFormsCompatibility.IsToolBarItemAutoSizePreservedPlaceholders)
				{
					resourceHandle = Component.EmptyGif;
				}
				if (resourceHandle != null)
				{
					objWriter.WriteAttributeString("IM", resourceHandle.ToString());
				}
				if (Text != string.Empty)
				{
					objWriter.WriteAttributeText("TX", Text);
				}
				if (DropDownMenu != null)
				{
					objWriter.WriteAttributeString("DD", "1");
					objWriter.WriteStartElement("B");
					objWriter.WriteAttributeString("mId", "1");
					objWriter.WriteEndElement();
				}
				objWriter.WriteEndElement();
			}
		}

		/// 
		/// Gets the size.
		/// </summary>
		/// </returns>
		protected virtual Size GetSize()
		{
			ToolBarButtonSkin toolBarButtonSkin = (ToolBarButtonSkin)SkinFactory.GetSkin(this);
			Size result = default(Size);
			if (toolBarButtonSkin != null)
			{
				if (IsSeperator)
				{
					result.Width = SeperatorWidth;
				}
				else
				{
					Size imageSize = ToolBar.ImageSize;
					result.Height = Math.Max((CustomStyle != "Label" || Image != null) ? imageSize.Height : 0, result.Height);
					if ((CustomStyle != "Label" && ToolBar != null && ToolBar.WinFormsCompatibility.IsToolBarItemAutoSizePreservedPlaceholders) || Image != null)
					{
						result.Width += imageSize.Width;
					}
					Size empty = System.Drawing.Size.Empty;
					empty = ((!string.IsNullOrEmpty(Text)) ? CommonUtils.GetStringMeasurements(Text, Font, blnIgnoreNewLines: true) : new Size(0, CommonUtils.GetFontHeight(Font)));
					if (ToolBar.TextAlign == ToolBarTextAlign.Right)
					{
						result.Height = Math.Max(result.Height, empty.Height);
						result.Width += empty.Width;
					}
					else
					{
						result.Width = Math.Max(result.Width, empty.Width);
						result.Height += empty.Height;
					}
					if (DropDownMenu != null)
					{
						Size dropDownImageSize = toolBarButtonSkin.DropDownImageSize;
						bool flag = true;
						result.Width += dropDownImageSize.Width;
						result.Height += dropDownImageSize.Height;
					}
					MarginValue margin = toolBarButtonSkin.Margin;
					PaddingValue padding = toolBarButtonSkin.Padding;
					result.Height += padding.Vertical + margin.Vertical;
					result.Height += toolBarButtonSkin.TopFrameHeight + toolBarButtonSkin.BottomFrameHeight;
					result.Width += padding.Horizontal + margin.Horizontal;
					result.Width += toolBarButtonSkin.LeftFrameWidth + toolBarButtonSkin.RightFrameWidth;
				}
			}
			else
			{
				result.Width = ToolBar.ToolBarHeight;
				result.Height = ToolBar.ToolBarHeight;
			}
			return result;
		}

		/// 
		/// Gets the button docking.
		/// </summary>
		/// <param name="strDocking">The STR docking.</param>
		/// </returns>
		protected virtual string GetButtonDocking(string strDocking)
		{
			return strDocking;
		}

		/// 
		///
		/// </summary>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (ClickHandler != null || DropDownMenu != null || (ToolBar != null && ToolBar.ButtonClickHandler != null))
			{
				criticalEventsData.Set("CL");
			}
			return criticalEventsData;
		}

		/// 
		/// Gets the critical client events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			if (HasClientHandler("Click"))
			{
				criticalClientEventsData.Set("CL");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Gets the horizontal docking.
		/// </summary>
		/// <param name="objContext">The obj context.</param>
		/// <param name="objToolbar">The obj toolbar.</param>
		/// </returns>
		private string GetHorizontalDocking(IContext objContext, ToolBar objToolbar)
		{
			string strDocking = "L";
			if (objToolbar.HasRightToLeft)
			{
				if (ToolBar.RightToLeft == RightToLeft.Yes)
				{
					strDocking = "R";
				}
			}
			else if (objContext.RightToLeft)
			{
				strDocking = "R";
			}
			return GetButtonDocking(strDocking);
		}

		static ToolBarButton()
		{
			ClickEvent = SerializableEvent.Register("Click", typeof(EventHandler), typeof(ToolBarButton));
		}
	}
}
