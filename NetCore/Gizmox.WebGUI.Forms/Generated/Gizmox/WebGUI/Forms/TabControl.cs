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
	/// Manages a related set of tab pages.
	/// </summary>
	[Serializable]
	[ToolboxItem(true)]
	[ToolboxBitmap(typeof(TabControl), "TabControl_45.bmp")]
	[DesignTimeController("Gizmox.WebGUI.Forms.Design.TabControlController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
	[ClientController("Gizmox.WebGUI.Client.Controllers.TabControlController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
	[DefaultProperty("TabPages")]
	[SRDescription("DescriptionTabControl")]
	[DefaultEvent("SelectedIndexChanged")]
	[ToolboxItemCategory("Containers")]
	[MetadataTag("TC")]
	[Skin(typeof(TabControlSkin))]
	[ProxyComponent(typeof(ProxyTabControl))]
	public class TabControl : Control, ISupportInitialize, INavigationControl
	{
		/// 
		/// Contains a collection of <see cref="T:Gizmox.WebGUI.Forms.Control"></see> objects.
		/// </summary>
		[Serializable]
		public new class ControlCollection : Control.ControlCollection
		{
			private TabControl mobjOwner;

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ControlCollection"></see> class.
			/// </summary>
			/// <param name="owner">The <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> that this collection belongs to. </param>
			public ControlCollection(TabControl objOwner)
				: base(objOwner)
			{
				mobjOwner = objOwner;
			}

			/// 
			/// Adds a <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to the collection.
			/// </summary>
			/// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to add. </param>
			/// <exception cref="T:System.Exception">The specified <see cref="T:Gizmox.WebGUI.Forms.Control"></see> is a <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see>. </exception>
			public override void Add(Control objControl)
			{
				if (!(objControl is TabPage))
				{
					throw new ArgumentException(SR.GetString("TabControlInvalidTabPageType", objControl.GetType().Name));
				}
				if (objControl is TabPage objValue)
				{
					base.Add(objValue);
				}
			}

			/// 
			/// Removes a <see cref="T:Gizmox.WebGUI.Forms.Control"></see> from the collection.
			/// </summary>
			/// <param name="objControl">The <see cref="T:Gizmox.WebGUI.Forms.Control"></see> to remove. </param>
			public override void Remove(Control objControl)
			{
				int num = IndexOf(objControl);
				base.Remove(objControl);
				if (mobjOwner == null || !(objControl is TabPage) || num == -1)
				{
					return;
				}
				int num2 = 0;
				int selectedIndex = mobjOwner.SelectedIndex;
				if (base.Count == 0)
				{
					num2 = -1;
				}
				else
				{
					num2 = selectedIndex;
					if (num == num2)
					{
						num2 = 0;
					}
					else if (num < num2)
					{
						num2--;
					}
				}
				if (selectedIndex != num2)
				{
					mobjOwner.SelectedIndex = num2;
				}
			}

			/// 
			/// Updates the owner.
			/// </summary>
			protected override void UpdateOwner()
			{
				if (mobjOwner != null)
				{
					if (mobjOwner.ShouldUseClientUpdateHandler)
					{
						mobjOwner.Update(blnRedrawOnly: false, blnUseClientUpdateHandler: true);
					}
					else
					{
						base.UpdateOwner();
					}
				}
			}
		}

		/// 
		/// Provides a property reference to Multiline property.
		/// </summary>
		private static SerializableProperty MultilineProperty = SerializableProperty.Register("Multiline", typeof(bool), typeof(TabControl), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to SelectOnRightClick property.
		/// </summary>        
		private static SerializableProperty SelectOnRightClickProperty = SerializableProperty.Register("SelectOnRightClick", typeof(bool), typeof(TabControl), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to TabAppearance property.
		/// </summary>
		private static SerializableProperty TabAppearanceProperty = SerializableProperty.Register("TabAppearance", typeof(TabAppearance), typeof(TabControl), new SerializablePropertyMetadata(TabAppearance.Normal));

		/// 
		/// Provides a property reference to SelectedIndex property.
		/// </summary>
		private static SerializableProperty SelectedIndexProperty = SerializableProperty.Register("SelectedIndex", typeof(int), typeof(TabControl), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to ClientBehavior property.
		/// </summary>
		private static SerializableProperty ClientBehaviorProperty = SerializableProperty.Register("ClientBehavior", typeof(TabControlClientBehavior), typeof(TabControl), new SerializablePropertyMetadata(TabControlClientBehavior.MemoryOptimized));

		/// 
		/// Provides a property reference to ShowCloseButton property.
		/// </summary>
		private static SerializableProperty ShowCloseButtonProperty = SerializableProperty.Register("ShowCloseButton", typeof(bool), typeof(TabControl), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to ShowExpandButton property.
		/// </summary>
		private static SerializableProperty ShowExpandButtonProperty = SerializableProperty.Register("ShowExpandButton", typeof(bool), typeof(TabControl), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to IsExpandedProperty property.
		/// </summary>
		private static SerializableProperty IsExpandedProperty = SerializableProperty.Register("IsExpandedProperty", typeof(bool), typeof(TabControl), new SerializablePropertyMetadata(true));

		/// 
		/// Provides a property reference to ImageList property.
		/// </summary>
		private static SerializableProperty ImageListProperty = SerializableProperty.Register("ImageList", typeof(ImageList), typeof(TabControl), new SerializablePropertyMetadata(null));

		/// 
		/// The menmAlignment property registration.
		/// </summary>
		private static readonly SerializableProperty AlignmentProperty = SerializableProperty.Register("menmAlignment", typeof(TabAlignment), typeof(TabControl), new SerializablePropertyMetadata(TabAlignment.Top));

		/// 
		/// The ItemSize property registration. 
		/// </summary>
		private static SerializableProperty ItemSizeProperty = SerializableProperty.Register("ItemSize", typeof(Size), typeof(TabControl));

		/// 
		/// Provides a property reference to IsExpanding property.
		/// </summary>
		private static SerializableProperty IsExpandingProperty = SerializableProperty.Register("IsExpandingProperty", typeof(bool), typeof(TabControl), new SerializablePropertyMetadata(false));

		/// 
		/// Provides a property reference to HeaderHeight property.
		/// </summary>
		private static SerializableProperty HeaderHeightProperty = SerializableProperty.Register("HeaderHeightProperty", typeof(int), typeof(TabControl), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to RestoredHeight property.
		/// </summary>
		private static SerializableProperty RestoredHeightProperty = SerializableProperty.Register("RestoredHeightProperty", typeof(int), typeof(TabControl), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to HeadersOffset property.
		/// </summary>
		private static SerializableProperty HeadersOffsetProperty = SerializableProperty.Register("HeadersOffsetProperty", typeof(int), typeof(TabControl), new SerializablePropertyMetadata(-1));

		/// 
		/// Provides a property reference to ContextualTabGroupCollection property.
		/// </summary>
		private static SerializableProperty ContextualTabGroupCollectionProperty = SerializableProperty.Register("ContextualTabGroupCollectionProperty", typeof(ContextualTabGroupCollection), typeof(TabControl), new SerializablePropertyMetadata(null));

		/// 
		/// Provides a property reference to MaxTabPageHeaders property.
		/// </summary>   
		private static SerializableProperty MaxTabPageHeadersProperty = SerializableProperty.Register("MaxTabPageHeadersProperty", typeof(int), typeof(TabControl), new SerializablePropertyMetadata(0));

		/// 
		/// The CloseClick event registration.
		/// </summary>
		private static readonly SerializableEvent CloseClickEvent;

		/// 
		/// The SelectedIndexChanged event registration.
		/// </summary>
		private static readonly SerializableEvent SelectedIndexChangedEvent;

		/// 
		/// The SelectedIndexChanging event registration.
		/// </summary>
		private static readonly SerializableEvent SelectedIndexChangingEvent;

		/// 
		/// The control tabs collection
		/// </summary>
		private TabPageCollection mobjTabs = null;

		/// 
		/// The Collapse event registration.
		/// </summary>
		private static readonly SerializableEvent CollapseEvent;

		/// 
		/// The Expand event registration.
		/// </summary>
		private static readonly SerializableEvent ExpandEvent;

		/// 
		/// Gets the tab control current skin.
		/// </summary>
		/// The tab control current skin.</value>
		internal TabControlSkin TabControlCurrentSkin => (TabControlSkin)base.Skin;

		/// 
		/// Gets the hanlder for the CloseClick event.
		/// </summary>
		private EventHandler CloseClickHandler => (EventHandler)GetHandler(CloseClick);

		/// 
		/// Gets the hanlder for the SelectedIndexChanged event.
		/// </summary>
		private EventHandler SelectedIndexChangedHandler => (EventHandler)GetHandler(SelectedIndexChanged);

		/// 
		/// Gets the hanlder for the SelectedIndexChanging event.
		/// </summary>
		private TabControlCancelEventHandler SelectedIndexChangingHandler => (TabControlCancelEventHandler)GetHandler(SelectedIndexChanging);

		/// 
		/// Gets or Sets value indication if the close button (when Appearance==TabAppearance.Workspace) 
		/// should be shown
		/// </summary>
		[DefaultValue(false)]
		public virtual bool ShowCloseButton
		{
			get
			{
				return GetValue(ShowCloseButtonProperty);
			}
			set
			{
				if (SetValue(ShowCloseButtonProperty, value))
				{
					UpdateParams(AttributeType.Control, blnUseClientUpdateHandler: false);
				}
			}
		}

		/// 
		/// Gets the hanlder for the Collapse event.
		/// </summary>
		private EventHandler CollapseHandler => (EventHandler)GetHandler(Collapse);

		/// 
		/// Gets the hanlder for the Expand event.
		/// </summary>
		private EventHandler ExpandHandler => (EventHandler)GetHandler(Expand);

		/// 
		/// Gets or sets the select on right click.
		/// </summary>
		/// The select on right click.</value>
		[SRCategory("CatAppearance")]
		[SRDescription("SelectOnRightClickDescr")]
		[DefaultValue(false)]
		public bool SelectOnRightClick
		{
			get
			{
				return GetValue(SelectOnRightClickProperty);
			}
			set
			{
				if (SetValue(SelectOnRightClickProperty, value))
				{
					UpdateParams(AttributeType.Control);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether this instance is expanding.
		/// </summary>
		/// 
		/// 	true</c> if this instance is expanding; otherwise, false</c>.
		/// </value>
		private bool IsExpanding
		{
			get
			{
				return GetValue(IsExpandingProperty);
			}
			set
			{
				SetValue(IsExpandingProperty, value);
			}
		}

		/// 
		/// Gets or sets the height of the header.
		/// </summary>
		/// 
		/// The height of the header.
		/// </value>
		private int HeaderHeight
		{
			get
			{
				return GetValue(HeaderHeightProperty);
			}
			set
			{
				SetValue(HeaderHeightProperty, value);
			}
		}

		/// 
		/// Gets or sets the height of the restored.
		/// </summary>
		/// 
		/// The height of the restored.
		/// </value>
		internal int RestoredHeight
		{
			get
			{
				return GetValue(RestoredHeightProperty);
			}
			set
			{
				if (SetValue(RestoredHeightProperty, value))
				{
					UpdateParams(AttributeType.Visual);
				}
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
		/// Gets or sets the client drawing mode behavior
		/// </summary>
		[DefaultValue(TabControlClientBehavior.MemoryOptimized)]
		public virtual TabControlClientBehavior ClientBehavior
		{
			get
			{
				if (Context is IContextParams && (base.ForceContentAvailabilityOnClient || ConfigHelper.ForceContentAvailabilityOnClient))
				{
					return TabControlClientBehavior.NoOptimizations;
				}
				return GetValue(ClientBehaviorProperty);
			}
			set
			{
				if (SetValue(ClientBehaviorProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets the collection of tab pages in this tab control.
		/// </summary>
		/// A <see cref="T:Gizmox.WebGUI.Forms.TabPageCollection"></see> that contains the <see cref="T:Gizmox.WebGUI.Forms.TabPage"></see> objects in this <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see>.</returns>
		[SRCategory("CatBehavior")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[MergableProperty(false)]
		[SRDescription("TabControlTabsDescr")]
		public TabPageCollection TabPages => mobjTabs;

		/// 
		/// Gets the control contained area offset.
		/// </summary>
		protected override PaddingValue ContainedAreaOffset
		{
			get
			{
				if ((Appearance == TabAppearance.Normal || Appearance == TabAppearance.Workspace) && SkinFactory.GetSkin(this) is TabControlSkin tabControlSkin)
				{
					Padding padding = new Padding
					{
						Bottom = tabControlSkin.BottomFrameHeight,
						Top = tabControlSkin.TopFrameHeight,
						Left = tabControlSkin.LeftFrameWidth,
						Right = tabControlSkin.RightFrameWidth
					};
					int skinHeaderHeight = SkinHeaderHeight;
					switch (Alignment)
					{
					case TabAlignment.Bottom:
						padding.Bottom += skinHeaderHeight;
						break;
					case TabAlignment.Left:
						padding.Left += skinHeaderHeight;
						break;
					case TabAlignment.Right:
						padding.Right += skinHeaderHeight;
						break;
					case TabAlignment.Top:
						padding.Top += skinHeaderHeight;
						break;
					}
					return new PaddingValue(padding + base.ContainedAreaOffset);
				}
				return base.ContainedAreaOffset;
			}
		}

		/// 
		/// Gets or sets the index of the currently selected tab page.
		/// </summary>
		/// The zero-based index of the currently selected tab page. The default is -1, which is also the value if no tab page is selected.</returns>
		/// <exception cref="T:System.ArgumentOutOfRangeException">The value is less than -1. </exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Browsable(false)]
		[SRDescription("selectedIndexDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(-1)]
		public int SelectedIndex
		{
			get
			{
				int num = GetValue(SelectedIndexProperty);
				TabPageCollection tabPages = TabPages;
				if (num == -1 && tabPages != null && tabPages.Count > 0)
				{
					num = 0;
					SetValue(SelectedIndexProperty, num);
				}
				return num;
			}
			set
			{
				if (value < -1)
				{
					object[] arrArgs = new object[3]
					{
						"SelectedIndex",
						value.ToString(CultureInfo.CurrentCulture),
						(-1).ToString(CultureInfo.CurrentCulture)
					};
					throw new ArgumentOutOfRangeException("SelectedIndex", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
				}
				if (value < -1 || value >= TabPages.Count || SelectedIndex == value)
				{
					return;
				}
				if (SelectedIndexChangingHandler != null)
				{
					TabControlCancelEventArgs e = null;
					e = ((value != -1 && TabPages.Count != 0) ? new TabControlCancelEventArgs(TabPages[value], blnCancel: false) : new TabControlCancelEventArgs(null, blnCancel: false));
					SelectedIndexChangingHandler(this, e);
					if (e.Cancel)
					{
						UpdateParams(AttributeType.Control);
						return;
					}
				}
				if (SetValue(SelectedIndexProperty, value))
				{
					UpdateParams(AttributeType.Control);
					if (SelectedItem != null && !SelectedItem.Loaded)
					{
						SelectedItem.Update();
					}
					FireObservableItemPropertyChanged("SelectedIndex");
					OnSelectedIndexChanged(new EventArgs());
				}
			}
		}

		/// 
		/// Gets the update handler.
		/// </summary>
		/// The update handler.</value>
		protected override string ClientUpdateHandler => (ClientBehavior == TabControlClientBehavior.DrawingOptimized) ? "TabControl_UpdateHandler" : string.Empty;

		/// 
		/// Gets or sets the image list.
		/// </summary>
		/// The image list.</value>
		[RefreshProperties(RefreshProperties.Repaint)]
		[SRDescription("TabBaseImageListDescr")]
		[SRCategory("CatAppearance")]
		[DefaultValue(null)]
		public ImageList ImageList
		{
			get
			{
				return GetValue(ImageListProperty);
			}
			set
			{
				if (SetValue(ImageListProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets the selected item.
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public TabPage SelectedItem
		{
			get
			{
				TabPageCollection tabPages = TabPages;
				if (SelectedIndex > -1 && SelectedIndex < tabPages.Count)
				{
					return tabPages[SelectedIndex];
				}
				return null;
			}
			set
			{
				if (value != null)
				{
					SelectedIndex = TabPages.IndexOf(value);
				}
			}
		}

		/// 
		/// Gets or sets the area of the control (for example, along the top) where the tabs are aligned.
		/// </summary>
		/// 
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.TabAlignment"></see> values. The default is Top.
		/// </returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">
		/// The property value is not a valid <see cref="T:Gizmox.WebGUI.Forms.TabAlignment"></see> value. 
		/// </exception>
		[DefaultValue(0)]
		[RefreshProperties(RefreshProperties.All)]
		[SRDescription("TabBaseAlignmentDescr")]
		[Localizable(true)]
		[SRCategory("CatBehavior")]
		[ProxyBrowsable(true)]
		public virtual TabAlignment Alignment
		{
			get
			{
				return GetValue(AlignmentProperty);
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(TabAlignment));
				}
				if (value == TabAlignment.Left || value == TabAlignment.Right)
				{
					throw new NotSupportedException("Tab alignment left and right are currently unsupported.");
				}
				if (SetValue(AlignmentProperty, value))
				{
					if (value == TabAlignment.Left || value == TabAlignment.Right)
					{
						Multiline = true;
					}
					Update();
				}
			}
		}

		/// 
		/// Gets the default alignment.
		/// </summary>
		/// The default alignment.</value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected virtual TabAlignment DefaultAlignment => TabAlignment.Top;

		/// 
		/// Gets or sets the visual appearance of the control's tabs.
		/// </summary>
		/// One of the <see cref="T:Gizmox.WebGUI.Forms.TabAppearance"></see> values. The default is Normal.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property value is not a valid <see cref="T:Gizmox.WebGUI.Forms.TabAppearance"></see> value. </exception>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[DefaultValue(TabAppearance.Normal)]
		[Localizable(true)]
		[SRDescription("TabBaseAppearanceDescr")]
		[SRCategory("CatBehavior")]
		[ProxyBrowsable(true)]
		public virtual TabAppearance Appearance
		{
			get
			{
				return GetValue(TabAppearanceProperty);
			}
			set
			{
				if (SetValue(TabAppearanceProperty, value))
				{
					Update();
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether more than one row of tabs can be displayed.
		/// </summary>
		/// true if more than one row of tabs can be displayed; otherwise, false. The default is true.</returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[SRDescription("TabBaseMultilineDescr")]
		[SRCategory("CatBehavior")]
		[DefaultValue(false)]
		public virtual bool Multiline
		{
			get
			{
				return GetValue(MultilineProperty);
			}
			set
			{
				ValidateExpandAndMultiLine(IsExpanded, value, ShowExpandButton);
				if (SetValue(MultilineProperty, value))
				{
					FireObservableItemPropertyChanged("Multiline");
					if (CustomStyle == string.Empty)
					{
						Update();
					}
				}
			}
		}

		/// 
		/// Gets or sets the control enabled state.
		/// </summary>
		public override bool Enabled
		{
			get
			{
				return base.Enabled;
			}
			set
			{
				SetEnabled(value, AttributeType.Enabled, blnUseClientUpdateHandler: false);
			}
		}

		/// 
		/// Gets or sets the control padding.
		/// </summary>
		/// </value>
		[Localizable(true)]
		[SRDescription("TabBasePaddingDescr")]
		[SRCategory("CatBehavior")]
		public override Padding Padding
		{
			get
			{
				return base.Padding;
			}
			set
			{
				base.Padding = value;
			}
		}

		/// 
		/// Gets or sets the fore color.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		/// 
		/// Gets or sets the background image displayed in the control.
		/// </summary>
		/// </value>
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
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
		/// Gets or sets the size of the item.
		/// </summary>
		/// 
		/// The size of the item.
		/// </value>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public Size ItemSize
		{
			get
			{
				return GetValue(ItemSizeProperty);
			}
			set
			{
				SetValue(ItemSizeProperty, value);
			}
		}

		/// 
		/// Gets or sets the selected tab.
		/// </summary>
		/// 
		/// The selected tab.
		/// </value>
		[SRDescription("TabControlSelectedTabDescr")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[SRCategory("CatAppearance")]
		[Browsable(false)]
		public TabPage SelectedTab
		{
			get
			{
				return SelectedItem;
			}
			set
			{
				SelectedItem = value;
			}
		}

		/// 
		/// Gets or sets the max page headers.
		/// </summary>
		/// 
		/// The max page headers.
		/// </value>
		[SRCategory("CatAppearance")]
		[SRDescription("MaxTabPageHeadersDescr")]
		[DefaultValue(0)]
		public virtual int MaxTabPageHeaders
		{
			get
			{
				return GetValue(MaxTabPageHeadersProperty);
			}
			set
			{
				if (SetValue(MaxTabPageHeadersProperty, value))
				{
					UpdateParams(AttributeType.Visual);
				}
			}
		}

		/// Gets or sets the way that the control's tabs are sized.</summary>
		/// One of the <see cref="T:System.Windows.Forms.TabSizeMode"></see> values. The default is Normal.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property value is not a valid <see cref="T:System.Windows.Forms.TabSizeMode"></see> value. </exception>
		/// 1</filterpriority>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		[Obsolete("Not implemented. Added for migration compatibility")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[SRDescription("TabBaseSizeModeDescr")]
		[SRCategory("CatBehavior")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[DefaultValue(TabSizeMode.Normal)]
		public TabSizeMode SizeMode
		{
			get
			{
				return TabSizeMode.Normal;
			}
			set
			{
			}
		}

		/// 
		/// Gets or Sets value indication if the close button should be shown
		/// </summary>
		/// 
		///   true</c> if [show expand button]; otherwise, false</c>.
		/// </value>
		[DefaultValue(false)]
		public virtual bool ShowExpandButton
		{
			get
			{
				return GetValue(ShowExpandButtonProperty);
			}
			set
			{
				bool isExpanded = IsExpanded;
				ValidateExpandAndMultiLine(isExpanded, Multiline, value);
				ValidateExpandAndDock(isExpanded, Dock, value);
				if (SetValue(ShowExpandButtonProperty, value))
				{
					UpdateParams(AttributeType.Visual, blnUseClientUpdateHandler: false);
				}
			}
		}

		/// 
		/// Gets or sets a value indicating whether tab control is expanded.
		/// </summary>
		/// 
		/// 	true</c> if this tab control is expanded; otherwise, false</c>.
		/// </value>
		[DefaultValue(true)]
		public virtual bool IsExpanded
		{
			get
			{
				return GetValue(IsExpandedProperty);
			}
			set
			{
				SetIsExpanded(value, blnClientSource: false);
			}
		}

		/// 
		/// Gets the height of the header.
		/// </summary>
		/// 
		/// The height of the header.
		/// </value>
		internal int SkinHeaderHeight
		{
			get
			{
				int num = HeaderHeight;
				if (num == -1 && base.Skin is TabControlSkin tabControlSkin)
				{
					int num2 = ((Appearance == TabAppearance.Spread) ? tabControlSkin.TabSpreadHeight : tabControlSkin.TabHeight);
					int num3 = (HeaderHeight = ((ContextualTabGroupsInternal != null && ContextualTabGroupsInternal.Count > 0) ? (tabControlSkin.ContextualTabGroupHeight + num2) : num2) + tabControlSkin.Padding.Top);
					num = num3;
				}
				return num;
			}
		}

		/// 
		/// Gets or sets the headers offset.
		/// </summary>
		/// 
		/// The headers offset.
		/// </value>
		[DefaultValue(-1)]
		public int HeadersOffset
		{
			get
			{
				return GetValue(HeadersOffsetProperty);
			}
			set
			{
				if (SetValue(HeadersOffsetProperty, value))
				{
					UpdateParams(AttributeType.Visual, blnUseClientUpdateHandler: false);
				}
			}
		}

		/// 
		/// Gets the contextual tab groups.
		/// </summary>
		/// 
		/// The contextual tab groups.
		/// </value>
		[Editor("Gizmox.WebGUI.Forms.Design.ContextualTabGroupCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
		[WebEditor(typeof(ContextualTabGroupCollectionEditor), typeof(WebUITypeEditor))]
		[MergableProperty(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Localizable(true)]
		public virtual ContextualTabGroupCollection ContextualTabGroups
		{
			get
			{
				ContextualTabGroupCollection contextualTabGroupCollection = ContextualTabGroupsInternal;
				if (contextualTabGroupCollection == null)
				{
					contextualTabGroupCollection = (ContextualTabGroupsInternal = new ContextualTabGroupCollection(this));
				}
				return contextualTabGroupCollection;
			}
		}

		/// 
		/// Gets or sets the contextual tab groups internal.
		/// </summary>
		/// 
		/// The contextual tab groups internal.
		/// </value>
		internal ContextualTabGroupCollection ContextualTabGroupsInternal
		{
			get
			{
				return GetValue(ContextualTabGroupCollectionProperty);
			}
			set
			{
				SetValue(ContextualTabGroupCollectionProperty, value);
			}
		}

		/// 
		/// Gets/Sets the controls docking style
		/// </summary>
		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				ValidateExpandAndDock(IsExpanded, value, ShowExpandButton);
				base.Dock = value;
			}
		}

		/// 
		/// Gets a value indicating whether [should use client update handler].
		/// </summary>
		/// 
		/// 	true</c> if [should use client update handler]; otherwise, false</c>.
		/// </value>
		internal virtual bool ShouldUseClientUpdateHandler => ClientBehavior == TabControlClientBehavior.DrawingOptimized;

		/// 
		/// Gets the number of views.
		/// </summary>
		int INavigationControl.Count => TabPages.Count;

		/// 
		/// Gets the selected index.
		/// </summary>
		int INavigationControl.SelectedIndex => SelectedIndex;

		/// 
		/// Occurs when the user clicks the tab control close button
		/// </summary>
		public virtual event EventHandler CloseClick
		{
			add
			{
				AddHandler(CloseClickEvent, value);
			}
			remove
			{
				RemoveHandler(CloseClickEvent, value);
			}
		}

		/// 
		/// Occurs when the SelectedIndex property is changed.
		/// </summary>
		[SRDescription("selectedIndexChangedEventDescr")]
		[SRCategory("CatBehavior")]
		public event EventHandler SelectedIndexChanged
		{
			add
			{
				AddCriticalHandler(SelectedIndexChangedEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(SelectedIndexChangedEvent, value);
			}
		}

		/// 
		/// Occurs when the SelectedIndex property is about to change.
		/// </summary>
		public event TabControlCancelEventHandler SelectedIndexChanging
		{
			add
			{
				AddCriticalHandler(SelectedIndexChangingEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(SelectedIndexChangingEvent, value);
			}
		}

		/// 
		/// Occurs when [client close click].
		/// </summary>
		[SRDescription("Occurs when control's tab closed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientCloseClick
		{
			add
			{
				AddClientHandler("TabClose", value);
			}
			remove
			{
				RemoveClientHandler("TabClose", value);
			}
		}

		/// 
		/// Occurs when [client expand].
		/// </summary>
		[SRDescription("Occurs when control's tab expanded in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientExpandedChanged
		{
			add
			{
				AddClientHandler("Expand", value);
			}
			remove
			{
				RemoveClientHandler("Expand", value);
			}
		}

		/// 
		/// Occurs when [client selected index changing].
		/// </summary>
		[SRDescription("Occurs when control's selected index changed in client mode.")]
		[Category("Client")]
		public event ClientEventHandler ClientSelectedIndexChanged
		{
			add
			{
				AddClientHandler("ValueChange", value);
			}
			remove
			{
				RemoveClientHandler("ValueChange", value);
			}
		}

		/// 
		/// Occurs when [Collapseed].
		/// </summary>
		public event EventHandler Collapse
		{
			add
			{
				AddCriticalHandler(CollapseEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(CollapseEvent, value);
			}
		}

		/// 
		/// Occurs when [expanded].
		/// </summary>
		public event EventHandler Expand
		{
			add
			{
				AddCriticalHandler(ExpandEvent, value);
			}
			remove
			{
				RemoveCriticalHandler(ExpandEvent, value);
			}
		}

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.TabControl"></see> class.
		/// </summary>
		public TabControl()
		{
			mobjTabs = CreateTabPageCollection();
			RestoredHeight = base.Height;
		}

		/// 
		/// Renders the max tab page headers attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderMaxTabPageHeadersAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (blnForceRender || (ContainsValue(MaxTabPageHeadersProperty) && Appearance == TabAppearance.Spread))
			{
				objWriter.WriteAttributeText("MTH", MaxTabPageHeaders.ToString());
			}
		}

		/// 
		/// Renders the controls meta attributes
		/// </summary>
		/// <param name="objContext"></param>
		/// <param name="objWriter"></param>
		protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
		{
			base.RenderAttributes(objContext, objWriter);
			RenderMaxTabPageHeadersAttribute(objWriter, blnForceRender: false);
			if (Multiline)
			{
				objWriter.WriteAttributeString("MLT", "1");
			}
			objWriter.WriteAttributeString("TBL", GetTabLayoutId(GetProxyPropertyValue("Alignment", Alignment)));
			TabPage selectedItem = SelectedItem;
			if (selectedItem != null)
			{
				objWriter.WriteAttributeString("SE", ((selectedItem.ProxyComponent != null) ? selectedItem.GetProxyPropertyValue("ID", selectedItem.ID) : selectedItem.ID).ToString());
			}
			RenderSelectOnRightClick(objWriter, blnForceRender: false);
			RenderShowCloseButtonAttribute(objWriter, blnForceRender: false);
			RenderShowExpandAttribute(objWriter, blnForceRender: false);
			RenderExpandedAttribute(objWriter, blnForceRender: false);
			RenderRestoredHeightAttribute(objWriter);
			RenderHeaderOffsetAttribute(objWriter, blnForceRender: false);
			RenderAppearanceAttribute(objWriter, blnForceRender: false);
		}

		/// 
		/// Renders the appearance attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderAppearanceAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			TabAppearance proxyPropertyValue = GetProxyPropertyValue("Appearance", Appearance);
			if (proxyPropertyValue != TabAppearance.Normal || blnForceRender)
			{
				objWriter.WriteAttributeString("AP", (int)proxyPropertyValue);
			}
		}

		/// 
		/// Renders the controls.
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter">writer.</param>
		/// <param name="lngRequestID">Request ID.</param>
		protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
		{
			if (IsDirty(lngRequestID))
			{
				RenderContextualTabGroups(objContext, objWriter);
			}
			ICollection proxyPropertyValue = GetProxyPropertyValue("TabPages", (ICollection)TabPages);
			foreach (TabPage item in proxyPropertyValue)
			{
				if (item.Visible)
				{
					if (ClientBehavior == TabControlClientBehavior.NoOptimizations)
					{
						item.InternalLoaded = true;
					}
					else if (lngRequestID == 0 && !ShouldUseClientUpdateHandler)
					{
						item.InternalLoaded = false;
					}
					((IRenderableComponent)item).RenderComponent(objContext, objWriter, lngRequestID);
				}
			}
		}

		/// 
		/// An abstract param attribute rendering
		/// </summary>
		/// <param name="objContext">Request context.</param>
		/// <param name="objWriter"></param>
		/// <param name="lngRequestID"></param>
		protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID)
		{
			base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID);
			if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
			{
				TabPage selectedItem = SelectedItem;
				if (selectedItem != null)
				{
					objWriter.WriteAttributeString("SE", ((selectedItem.ProxyComponent != null) ? selectedItem.GetProxyPropertyValue("ID", selectedItem.ID) : selectedItem.ID).ToString());
				}
				RenderSelectOnRightClick(objWriter, blnForceRender: true);
				RenderShowCloseButtonAttribute(objWriter, blnForceRender: true);
			}
			if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
			{
				RenderShowExpandAttribute(objWriter, blnForceRender: true);
				RenderMaxTabPageHeadersAttribute(objWriter, blnForceRender: true);
				RenderExpandedAttribute(objWriter, blnForceRender: true);
				RenderRestoredHeightAttribute(objWriter);
				RenderHeaderOffsetAttribute(objWriter, blnForceRender: true);
				RenderAppearanceAttribute(objWriter, blnForceRender: true);
			}
		}

		/// 
		/// Renders the select on right click.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderSelectOnRightClick(IAttributeWriter objWriter, bool blnForceRender)
		{
			if (SelectOnRightClick)
			{
				objWriter.WriteAttributeString("SOR", "1");
			}
			else if (blnForceRender)
			{
				objWriter.WriteAttributeString("SOR", "0");
			}
		}

		/// 
		/// Renders the restored height attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		private void RenderRestoredHeightAttribute(IAttributeWriter objWriter)
		{
			if (!IsExpanded || ShowExpandButton)
			{
				objWriter.WriteAttributeString("RH", RestoredHeight.ToString());
			}
		}

		/// 
		/// Renders the expanded attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderExpandedAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			bool isExpanded = IsExpanded;
			if (!isExpanded || blnForceRender)
			{
				objWriter.WriteAttributeString("EX", isExpanded ? "1" : "0");
			}
		}

		/// 
		/// Renders the show expand button attribute.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderShowExpandAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			bool showExpandButton = ShowExpandButton;
			if (showExpandButton || blnForceRender)
			{
				objWriter.WriteAttributeString("EIN", showExpandButton ? "1" : "0");
			}
		}

		/// 
		/// Renders the show expand button attribute.
		/// </summary>
		/// <param name="objWriter">The writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderShowCloseButtonAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			bool showCloseButton = ShowCloseButton;
			if (showCloseButton || blnForceRender)
			{
				objWriter.WriteAttributeString("SCB", showCloseButton ? "1" : "0");
			}
		}

		/// 
		/// Renders the header offset attribute.
		/// </summary>
		/// <param name="objWriter">The obj writer.</param>
		/// <param name="blnForceRender">if set to true</c> [BLN force render].</param>
		private void RenderHeaderOffsetAttribute(IAttributeWriter objWriter, bool blnForceRender)
		{
			int headersOffset = HeadersOffset;
			if (headersOffset >= 0 || blnForceRender)
			{
				objWriter.WriteAttributeString("HO", headersOffset.ToString());
			}
		}

		/// 
		/// Renders the contextual tab groups.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objWriter">The writer.</param>
		private void RenderContextualTabGroups(IContext objContext, IResponseWriter objWriter)
		{
			ContextualTabGroupCollection contextualTabGroupsInternal = ContextualTabGroupsInternal;
			if (contextualTabGroupsInternal == null)
			{
				return;
			}
			int num = 0;
			foreach (ContextualTabGroup item in contextualTabGroupsInternal)
			{
				objWriter.WriteStartElement("G");
				objWriter.WriteAttributeText("IX", num.ToString());
				objWriter.WriteAttributeText("TX", item.Text, (TextFilter)5);
				objWriter.WriteEndElement();
				num++;
			}
		}

		/// 
		/// Gets the control renderer.
		/// </summary>
		/// </returns>
		protected override ControlRenderer GetControlRenderer()
		{
			return new TabControlRenderer(this);
		}

		/// 
		/// Adds a child object.
		/// </summary>
		/// <param name="objValue">The child object to add.</param>
		protected override void AddChild(object objValue)
		{
			if (objValue is TabPage)
			{
				TabPages.Add((TabPage)objValue);
			}
			else
			{
				base.AddChild(objValue);
			}
		}

		/// 
		/// Creates the tab page collection.
		/// </summary>
		/// </returns>
		protected virtual TabPageCollection CreateTabPageCollection()
		{
			return new TabPageCollection(this);
		}

		/// 
		/// This member overrides <see cref="M:Gizmox.WebGUI.Forms.Control.CreateControlsInstance"></see>.
		/// </summary>
		/// A new instance of <see cref="T:Gizmox.WebGUI.Forms.Control.ControlCollection"></see> assigned to the control.</returns>
		protected override Control.ControlCollection CreateControlsInstance()
		{
			return new ControlCollection(this);
		}

		/// 
		/// Gets the tab layout id.
		/// </summary>
		/// <param name="enmTabAlignment">The tab layout id.</param>
		/// </returns>
		protected virtual int GetTabLayoutId(TabAlignment enmTabAlignment)
		{
			if (GetProxyPropertyValue("Appearance", Appearance) == TabAppearance.Logical)
			{
				return -1;
			}
			return (int)enmTabAlignment;
		}

		/// 
		/// Gets the critical events.
		/// </summary>
		/// </returns>
		protected override CriticalEventsData GetCriticalEventsData()
		{
			CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
			if (SelectedIndexChangedHandler != null || SelectedIndexChangingHandler != null)
			{
				criticalEventsData.Set("VC");
			}
			if (ExpandHandler != null)
			{
				criticalEventsData.Set("EXP");
			}
			if (CollapseHandler != null)
			{
				criticalEventsData.Set("COL");
			}
			return criticalEventsData;
		}

		protected override CriticalEventsData GetCriticalClientEventsData()
		{
			CriticalEventsData criticalClientEventsData = base.GetCriticalClientEventsData();
			if (HasClientHandler("ValueChange"))
			{
				criticalClientEventsData.Set("VC");
			}
			if (HasClientHandler("Expand"))
			{
				criticalClientEventsData.Set("EXP");
				criticalClientEventsData.Set("COL");
			}
			return criticalClientEventsData;
		}

		/// 
		/// Called when [collapse].
		/// </summary>
		protected virtual void OnCollapse(bool blnClientSource)
		{
			if (CollapseHandler != null)
			{
				CollapseHandler(this, EventArgs.Empty);
			}
		}

		/// 
		/// Called when [expand].
		/// </summary>
		protected virtual void OnExpand(bool blnClientSource)
		{
			if (ExpandHandler != null)
			{
				ExpandHandler(this, EventArgs.Empty);
			}
		}

		/// 
		/// Sets the specified bounds of the control to the specified location and size.
		/// </summary>
		/// <param name="intLeft">The int left.</param>
		/// <param name="intTop">The int top.</param>
		/// <param name="intWidth">Width of the int layout.</param>
		/// <param name="intHeight">Height of the int layout.</param>
		/// <param name="enmSpecified">A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.BoundsSpecified"></see> values. For any parameter not specified, the current value will be used.</param>
		/// <param name="blnIsClientSource">if set to true</c> [BLN is client source].</param>
		/// </returns>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public override bool SetBounds(int intLeft, int intTop, int intWidth, int intHeight, BoundsSpecified enmSpecified, bool blnIsClientSource)
		{
			if (!base.DesignMode && (enmSpecified & BoundsSpecified.Height) != BoundsSpecified.None && !IsExpanding)
			{
				if (!IsExpanded)
				{
					enmSpecified &= (BoundsSpecified)(-9);
				}
				RestoredHeight = intHeight;
			}
			return base.SetBounds(intLeft, intTop, intWidth, intHeight, enmSpecified, blnIsClientSource);
		}

		/// 
		/// Sets the IsExpanded.
		/// </summary>
		/// <param name="blnIsExpanded">if set to true</c> [BLN is expanded].</param>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		private bool SetIsExpanded(bool blnIsExpanded, bool blnClientSource)
		{
			bool showExpandButton = ShowExpandButton;
			ValidateExpandAndMultiLine(blnIsExpanded, Multiline, showExpandButton);
			ValidateExpandAndDock(blnIsExpanded, Dock, showExpandButton);
			bool flag = SetValue(IsExpandedProperty, blnIsExpanded);
			if (flag && !base.DesignMode && !base.IsLayoutSuspended)
			{
				ApplyHeight(blnClientSource);
				if (!blnClientSource)
				{
					UpdateParams((AttributeType)6, blnUseClientUpdateHandler: false);
				}
			}
			if (flag || blnClientSource)
			{
				if (blnIsExpanded)
				{
					OnExpand(blnClientSource);
				}
				else
				{
					OnCollapse(blnClientSource);
				}
			}
			return flag;
		}

		/// 
		/// Applies the height.
		/// </summary>
		/// <param name="blnClientSource">if set to true</c> [BLN client source].</param>
		private void ApplyHeight(bool blnClientSource)
		{
			if (!blnClientSource)
			{
				UpdateParams(AttributeType.Visual);
			}
			IsExpanding = true;
			int intHeight = (IsExpanded ? RestoredHeight : SkinHeaderHeight);
			if (SetBounds(0, 0, 0, intHeight, BoundsSpecified.Height, blnClientSource))
			{
				InvalidateParentLayout(new LayoutEventArgs(blnIsClientSource: false, blnShouldUpdateSiblings: true, blnShouldUpdateParent: true));
			}
			IsExpanding = false;
		}

		/// 
		/// Validates the expand and multi line.
		/// </summary>
		/// <param name="blnIsExpanded">if set to true</c> [BLN is expanded].</param>
		/// <param name="blnMultiline">if set to true</c> [BLN multiline].</param>
		/// <param name="blnShowExpandButton">if set to true</c> [BLN show expand button].</param>
		private void ValidateExpandAndMultiLine(bool blnIsExpanded, bool blnMultiline, bool blnShowExpandButton)
		{
			if ((!blnIsExpanded || blnShowExpandButton) && blnMultiline)
			{
				throw new NotSupportedException();
			}
		}

		/// 
		/// Validates the expand and dock.
		/// </summary>
		/// <param name="blnIsExpanded">if set to true</c> [BLN is expanded].</param>
		/// <param name="enmDockStyle">The enm dock style.</param>
		/// <param name="blnShowExpandButton">if set to true</c> [BLN show expand button].</param>
		internal virtual void ValidateExpandAndDock(bool blnIsExpanded, DockStyle enmDockStyle, bool blnShowExpandButton)
		{
			if ((!blnIsExpanded || blnShowExpandButton) && (enmDockStyle == DockStyle.Fill || enmDockStyle == DockStyle.Left || enmDockStyle == DockStyle.Right))
			{
				throw new NotSupportedException(SR.GetString("TabControlValidateExpandAndDock", enmDockStyle));
			}
		}

		/// 
		/// Fires an event.
		/// </summary>
		/// <param name="objEvent">event.</param>
		protected override void FireEvent(IEvent objEvent)
		{
			switch (objEvent.Type)
			{
			case "TabClose":
				if (base.Controls.Count > 0 && CloseClickHandler != null)
				{
					CloseClickHandler(this, new EventArgs());
				}
				break;
			case "ValueChange":
			{
				long lngComponentId = long.Parse(objEvent["Value"]);
				if (Context is ISessionRegistry sessionRegistry)
				{
					TabPage tabPage = null;
					IRegisteredComponent registeredComponent = sessionRegistry.GetRegisteredComponent(lngComponentId);
					tabPage = ((!(registeredComponent is ProxyComponent proxyComponent)) ? (registeredComponent as TabPage) : (proxyComponent.SourceComponent as TabPage));
					if (tabPage != null && tabPage.TabControl == this)
					{
						ChangeSelectedTab(tabPage);
					}
				}
				break;
			}
			case "Expand":
			{
				bool result = false;
				if (bool.TryParse(objEvent["EX"], out result))
				{
					SetIsExpanded(result, blnClientSource: true);
				}
				break;
			}
			default:
				base.FireEvent(objEvent);
				break;
			}
		}

		/// 
		/// Changes the selected tab.
		/// </summary>
		/// <param name="objTabPage">tab page.</param>
		internal void ChangeSelectedTab(TabPage objTabPage)
		{
			if (objTabPage == null)
			{
				return;
			}
			int num = TabPages.IndexOf(objTabPage);
			if (SelectedIndex != num)
			{
				SelectedIndex = num;
				if (SelectedIndex == num)
				{
					if (!objTabPage.Loaded)
					{
						SelectedItem.Update();
					}
					UpdateParams(AttributeType.Control);
				}
			}
			else
			{
				UpdateParams(AttributeType.Redraw);
			}
		}

		/// Raises the <see cref="E:System.Windows.Forms.TabControl.SelectedIndexChanged"></see> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
		protected virtual void OnSelectedIndexChanged(EventArgs e)
		{
			SelectedIndexChangedHandler?.Invoke(this, e);
		}

		/// 
		/// Provides controls with the ability to handle size changed
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		/// <param name="objNewSize">The control new size.</param>
		/// <param name="objOldSize">The control old size.</param>
		internal override void OnLayoutInternal(LayoutEventArgs e, Size objNewSize, Size objOldSize)
		{
			base.OnLayoutInternal(e, objNewSize, objOldSize);
			int num = objNewSize.Width - objOldSize.Width;
			int num2 = objNewSize.Height - objOldSize.Height;
			foreach (TabPage tabPage in TabPages)
			{
				DockStyle dock = tabPage.Dock;
				if (num != 0 || num2 != 0)
				{
					tabPage.OnResizeInternal(e.Clone(blnShouldUpdateSiblings: false, blnShouldUpdateParent: false));
				}
			}
		}

		/// 
		/// Signals the object that initialization is starting.
		/// </summary>
		void ISupportInitialize.BeginInit()
		{
		}

		/// 
		/// Signals the object that initialization is complete.
		/// </summary>
		void ISupportInitialize.EndInit()
		{
			if (!base.DesignMode)
			{
				ApplyHeight(blnClientSource: false);
			}
		}

		/// 
		/// Navigate to first view.
		/// </summary>
		/// </returns>
		bool INavigationControl.MoveFirst()
		{
			if (TabPages.Count > 0)
			{
				SelectedIndex = 0;
				return true;
			}
			return false;
		}

		/// 
		/// Navigate to last view.
		/// </summary>
		/// </returns>
		bool INavigationControl.MoveLast()
		{
			if (TabPages.Count > 0)
			{
				SelectedIndex = TabPages.Count - 1;
				return true;
			}
			return false;
		}

		/// 
		/// Navigate to next view.
		/// </summary>
		/// </returns>
		bool INavigationControl.MoveNext()
		{
			if (TabPages.Count > 0 && SelectedIndex < TabPages.Count)
			{
				SelectedIndex++;
				return true;
			}
			return false;
		}

		/// 
		/// Navigate to Previous view.
		/// </summary>
		/// </returns>
		bool INavigationControl.MovePrevious()
		{
			if (TabPages.Count > 0 && SelectedIndex > 0)
			{
				SelectedIndex--;
				return true;
			}
			return false;
		}

		/// 
		/// move to specific tab page.
		/// </summary>
		/// </returns>
		void INavigationControl.MoveTo(int intIndex)
		{
			if (intIndex >= 0 && intIndex <= TabPages.Count - 1)
			{
				SelectedIndex = intIndex;
			}
		}

		static TabControl()
		{
			CloseClickEvent = SerializableEvent.Register("CloseClick", typeof(EventHandler), typeof(TabControl));
			SelectedIndexChanged = SerializableEvent.Register("SelectedIndexChanged", typeof(EventHandler), typeof(TabControl));
			SelectedIndexChanging = SerializableEvent.Register("SelectedIndexChanging", typeof(TabControlCancelEventHandler), typeof(TabControl));
			Collapse = SerializableEvent.Register("Collapse", typeof(EventHandler), typeof(TabControl));
			Expand = SerializableEvent.Register("Expand", typeof(EventHandler), typeof(TabControl));
		}
	}
}
