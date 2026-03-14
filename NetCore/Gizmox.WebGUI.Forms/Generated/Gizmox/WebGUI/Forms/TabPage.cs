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
	/// Represents a single tab page in a <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see>.
	/// </summary>
	[Serializable]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.TabPageController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.TabPageController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DesignTimeVisible(false)]
	[ToolboxItem(false)]
	[DefaultProperty("Text")]
	[MetadataTag("TP")]
	[Skin(typeof(TabPageSkin))]
	[ProxyComponent(typeof(ProxyTabPage))]
	public class TabPage : Panel, IComparable
	{
		/// 
		/// Provides a property reference to TabAppearance property.
		/// </summary>
		private static SerializableProperty TabAppearanceProperty = SerializableProperty.Register("TabAppearance", typeof(TabAppearance), typeof(TabPage), new SerializablePropertyMetadata(TabAppearance.Normal));

		/// 
		/// Provides a property reference to Loaded property.
		/// </summary>
		private static SerializableProperty LoadedProperty = SerializableProperty.Register("Loaded", typeof(bool), typeof(TabPage), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to Visible property.
		/// </summary>
		private static SerializableProperty VisibleProperty = SerializableProperty.Register("Visible", typeof(bool), typeof(TabPage), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to Image property.
		/// </summary>
		private static SerializableProperty ImageProperty = SerializableProperty.Register("Image", typeof(ResourceHandle), typeof(TabPage), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to ImageKey property.
		/// </summary>
		private static SerializableProperty ImageKeyProperty = SerializableProperty.Register("ImageKey", typeof(string), typeof(TabPage), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// Provides a property reference to ImageKey property.
		/// </summary>
		private static SerializableProperty HeaderToolTipProperty = SerializableProperty.Register("HeaderToolTip", typeof(string), typeof(TabPage), new SerializablePropertyMetadata(string.Empty));

		/// 
		/// Provides a property reference to ImageIndex property.
		/// </summary>
		private static SerializableProperty ImageIndexProperty = SerializableProperty.Register("ImageIndex", typeof(int), typeof(TabPage), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to ContextualTabGroup property.
		/// </summary>
		private static SerializableProperty ContextualTabGroupProperty = SerializableProperty.Register("ContextualTabGroupProperty", typeof(ContextualTabGroup), typeof(TabPage), new SerializablePropertyMetadata(null));

		/// 
		/// Represents Image of the tab if exists
		/// </summary>
		internal ResourceHandle ImageInternal
		{
			get
			{
				return GetValue(ImageProperty);
			}
			set
			{
				SetValue(ImageProperty, value);
			}
		}

		/// 
		/// Gets a value indicating whether this instance is redrawing its contained controls.
		/// </summary>
		/// 
		/// 	true</c> if this instance is redrawing; otherwise, false</c>.
		/// </value>
		internal override bool Redraws => true;

		/// 
		/// Gets or sets the header tool tip.
		/// </summary>
		/// 
		/// The header tool tip.
		/// </value>
		[DefaultValue("")]
		public string HeaderToolTip
		{
			get
			{
				return GetValue(HeaderToolTipProperty, string.Empty);
			}
			set
			{
				if (SetValue(HeaderToolTipProperty, value))
				{
					UpdateParams(AttributeType.ToolTip);
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
		/// Gets or sets the appearance.
		/// </summary>
		/// 
		/// The appearance.
		/// </value>
		protected internal virtual TabAppearance Appearance
		{
			get
			{
				return GetValue(TabAppearanceProperty);
			}
			set
			{
				if (SetValue(TabAppearanceProperty, value))
				{
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// 
		/// Gets or sets the image.
		/// </summary>
		/// The image.</value>
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
		/// Gets the image list.
		/// </summary>
		/// The image list.</value>
		private ImageList ImageList
		{
			get
			{
				if (TabControl != null)
				{
					return TabControl.ImageList;
				}
				return null;
			}
		}

		/// 
		/// Gets the <see cref="T:Gizmox.WebGUI.Forms.TabControl" /> control.
		/// </summary>
		[Browsable(false)]
		public TabControl TabControl => (TabControl)InternalParent;

		/// 
		/// Gets or sets a value indicating whether tab stop is enabled.
		/// </summary>
		/// true</c> if tab stop is enabled; otherwise, false</c>.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
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
		/// Gets or sets the panel type.
		/// </summary>
		[Browsable(false)]
		public new PanelType PanelType
		{
			get
			{
				return base.PanelType;
			}
			set
			{
				base.PanelType = value;
			}
		}

		/// 
		/// Gets or sets the tab index.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new int TabIndex
		{
			get
			{
				return base.TabIndex;
			}
			set
			{
				base.TabIndex = value;
			}
		}

		/// 
		/// Gets a value indicating whether this <see cref="T:Gizmox.WebGUI.Forms.TabPage" /> is loaded.
		/// </summary>
		/// true</c> if loaded; otherwise, false</c>.</value>
		[Browsable(false)]
		public bool Loaded => InternalLoaded;

		/// 
		/// Gets or sets a value indicating whether the tabpage was loaded.
		/// </summary>
		/// 
		/// 	true</c> if the tabpage was loaded; otherwise, false</c>.
		/// </value>
		internal bool InternalLoaded
		{
			get
			{
				return GetValue(LoadedProperty);
			}
			set
			{
				SetValue(LoadedProperty, value);
			}
		}

		/// 
		/// Gets or sets the text to display on the tab.
		/// </summary>
		/// The text to display on the tab.</returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Localizable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[ProxyBrowsable(true)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				if (base.Text != value)
				{
					base.Text = value;
				}
			}
		}

		/// 
		/// Gets or sets the tab visability.
		/// </summary>
		/// </value>
		[DefaultValue(true)]
		[SRDescription("ControlVisibleDescr")]
		[SRCategory("CatBehavior")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public new bool Visible
		{
			get
			{
				return base.Visible;
			}
			set
			{
				base.Visible = value;
			}
		}

		/// This member is not meaningful for this control.</summary>
		/// A <see cref="T:GizmoxWebGUI.DockStyle"></see> value.</returns>
		/// 1</filterpriority>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public override DockStyle Dock
		{
			get
			{
				return DockStyle.Fill;
			}
			set
			{
				base.Dock = value;
			}
		}

		/// 
		/// This property is not relevant for this class.
		/// </summary>
		/// </value>
		/// true if enabled; otherwise, false.</returns>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
		/// Indicates the automatic sizing behavior of the control.
		/// </summary>
		/// </value>
		/// One of the <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.AutoSizeMode"></see> values.</exception>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[Localizable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override AutoSizeMode AutoSizeMode
		{
			get
			{
				return AutoSizeMode.GrowOnly;
			}
			set
			{
			}
		}

		/// 
		/// Gets a value indicating whether [use preferred size].
		/// </summary>
		/// true</c> if [use preferred size]; otherwise, false</c>.</value>
		protected internal override bool UsePreferredSize => false;

		/// Gets or sets a value indicating whether the <see cref="T:System.Windows.Forms.TabPage"></see> background renders using the current visual style when visual styles are enabled.</summary>
		/// true to render the background using the current visual style; otherwise, false. The default is false.</returns>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("TabItemUseVisualStyleBackColorDescr")]
		[DefaultValue(false)]
		[SRCategory("CatAppearance")]
		public bool UseVisualStyleBackColor
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
		/// Gets or sets the contextual tab group key.
		/// </summary>
		/// 
		/// The contextual tab group key.
		/// </value>
		[Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[DefaultValue(null)]
		[MergableProperty(false)]
		public virtual ContextualTabGroup ContextualTabGroup
		{
			get
			{
				return GetValue(ContextualTabGroupProperty);
			}
			set
			{
				TabControl tabControl = TabControl;
				if (value != null && tabControl != null)
				{
					ContextualTabGroupCollection contextualTabGroupsInternal = tabControl.ContextualTabGroupsInternal;
					if (contextualTabGroupsInternal == null || !contextualTabGroupsInternal.Contains(value))
					{
						throw new ArgumentException("ContextualTabGroup");
					}
				}
				if (SetValue(ContextualTabGroupProperty, value))
				{
					UpdateParams(AttributeType.Control);
					tabControl?.Update(blnRedrawOnly: true);
				}
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> class.
		/// </summary>
		public TabPage()
		{
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> class and specifies the text for the tab.
		/// </summary>
		/// <param name="strText">The text for the tab. </param>
		public TabPage(string strText)
		{
			Text = strText;
		}

		/// 
		/// Shows the serialize image.
		/// </summary>
		protected bool ShouldSerializeImage()
		{
			if (TabControl != null && TabControl.ImageList != null)
			{
				return false;
			}
			return ImageInternal != null;
		}

		/// 
		/// Sets the visible internal.
		/// </summary>
		/// <param name="blnValue">if set to true</c> set visibility true.</param>
		internal override void SetVisibleInternal(bool blnValue)
		{
			if (!base.DesignMode && SetValue(VisibleProperty, blnValue))
			{
				OnVisibleChanged(EventArgs.Empty);
				Update();
			}
		}

		/// 
		/// Create a control.
		/// </summary>
		/// <param name="blnVisible">if set to true</c> [BLN visible].</param>
		protected override void DoCreateControl(bool blnVisible)
		{
			TabControl tabControl = TabControl;
			if (tabControl != null)
			{
				tabControl.Update(blnRedrawOnly: false, tabControl.ShouldUseClientUpdateHandler);
				if (blnVisible && tabControl.Created)
				{
					CreateControl();
				}
			}
		}

		/// 
		/// Returns the visibility internally
		/// </summary>
		/// </returns>
		internal override bool GetVisibleCore()
		{
			return GetValue(VisibleProperty);
		}

		/// 
		/// Shoulds the content of the control.
		/// </summary>
		/// </returns>
		protected override bool ShouldRenderContent()
		{
			if (TabControl.SelectedItem != this && !Loaded)
			{
				return false;
			}
			return ParentInternal?.ShouldRenderContentInternal() ?? true;
		}

		/// 
		/// Render control attributes
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter">The response writer object.</param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			if (TabControl.SelectedItem == this)
			{
				InternalLoaded = true;
			}
			objWriter.WriteAttributeString("LO", InternalLoaded ? "1" : "0");
			int fontHeight = CommonUtils.GetFontHeight(Font);
			if (Image == null && fontHeight < TabControl.TabControlCurrentSkin.TabHeight)
			{
				objWriter.WriteAttributeString("TFH", fontHeight);
			}
			ResourceHandle image = Image;
			if (image != null)
			{
				objWriter.WriteAttributeString("IM", image.ToString());
			}
			RenderContextualTabGroup(objWriter, blnForceRender: false);
			RenderHeaderToolTip(objWriter, blnForceRender: false);
			RenderAppearanceAttribute(objWriter, blnForceRender: false);
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
				RenderContextualTabGroup(objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.ToolTip))
			{
				RenderHeaderToolTip(objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderAppearanceAttribute(objWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the header tool tip.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderHeaderToolTip(IAttributeWriter objWriter, bool blnForceRender)
		{
			string headerToolTip = HeaderToolTip;
			if (!string.IsNullOrEmpty(headerToolTip) || blnForceRender)
			{
				objWriter.WriteAttributeString("HTT", (headerToolTip != null) ? headerToolTip : string.Empty);
			}
		}

		/// 
		/// Renders the appearance attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderAppearanceAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			TabAppearance appearance = Appearance;
			if (appearance != TabAppearance.Normal || blnForceRender)
			{
				objWriter.WriteAttributeString("AP", (int)appearance);
			}
		}

		/// 
		/// Renders the contextual tab group.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderContextualTabGroup(IAttributeWriter objWriter, bool blnForceRender)
		{
			string text = string.Empty;
			ContextualTabGroup contextualTabGroup = ContextualTabGroup;
			if (contextualTabGroup != null)
			{
				ContextualTabGroupCollection contextualTabGroupsInternal = TabControl.ContextualTabGroupsInternal;
				if (contextualTabGroupsInternal != null)
				{
					int num = contextualTabGroupsInternal.IndexOf(contextualTabGroup);
					if (num != -1)
					{
						text = num.ToString();
					}
				}
			}
			if (!string.IsNullOrEmpty(text) || blnForceRender)
			{
				objWriter.WriteAttributeString("CTG", text.ToString());
			}
		}

		/// 
		/// Returns a string containing the value of the <see cref="P:Gizmox.WebGUI.Forms.TabPage.Text"></see> property.
		/// </summary>
		/// A string containing the value of the <see cref="P:Gizmox.WebGUI.Forms.TabPage.Text"></see> property.</returns>
		public override string ToString()
		{
			return "TabPage: {" + Text + "}";
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new TabPageRenderer(this);
		}

		/// 
		/// Compares the current instance with another object of the same type.
		/// </summary>
		/// <param name="obj">An object to compare with this instance.</param>
		/// 
		/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than <paramref name="obj" />. Zero This instance is equal to <paramref name="obj" />. Greater than zero This instance is greater than <paramref name="obj" />.
		/// </returns>
		/// <exception cref="T:System.ArgumentException">
		/// 	<paramref name="obj" /> is not the same type as this instance. </exception>
		public int CompareTo(object obj)
		{
			if (!(obj is TabPage tabPage))
			{
				throw new ArgumentException();
			}
			return TabIndex.CompareTo(tabPage.TabIndex);
		}

		/// 
		/// Applies the pre release dock fill compatibility.
		/// </summary>
		protected internal override void ApplyPreReleaseDockFillCompatibility()
		{
		}

		/// 
		/// Full updates of this instance.
		/// </summary>
		public override void Update()
		{
			base.Update();
			UpdateTabControl();
		}

		/// 
		/// Redraw only
		/// </summary>
		/// <param name="blnRedrawOnly"></param>
		public override void Update(bool blnRedrawOnly)
		{
			base.Update(blnRedrawOnly);
			UpdateTabControl();
		}

		/// 
		/// Updates the tab control.
		/// </summary>
		private void UpdateTabControl()
		{
			if (base.Parent is TabControl tabControl)
			{
				tabControl.Update(blnRedrawOnly: true, tabControl.ShouldUseClientUpdateHandler);
			}
		}

		/// 
		/// Updates only the parameters of this instance.
		/// </summary>
		public override void UpdateParams()
		{
			base.UpdateParams();
			UpdateTabControl();
		}

		/// 
		/// Updates the params.
		/// </summary>
		/// <param name="enmParams">The enm params.</param>
		public override void UpdateParams(AttributeType enmParams)
		{
			base.UpdateParams(enmParams);
			UpdateTabControl();
		}
	}
}
