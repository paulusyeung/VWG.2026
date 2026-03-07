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
	/// Represents the base functionality for all menus. 
	/// </summary>
	[Serializable]
	[ListBindable(false)]
	[DesignTimeVisible(false)]
	[ToolboxItemFilter("Gizmox.WebGUI.Forms", ToolboxItemFilterType.Require)]
	[ToolboxItemCategory("Menus & Toolbars")]
	[Skin(typeof(MenuSkin))]
	public class Menu : Component, IMenu, ISkinable
	{
		/// 
		///
		/// </summary>
		[Serializable]
		internal class MenuForm : Form
		{
			/// 
			/// The PreferdMenuItemIconWidthProperty property registration.
			/// </summary>
			private static readonly SerializableProperty PreferdMenuItemIconWidthProperty = SerializableProperty.Register("PreferdMenuItemIconWidth", typeof(int), typeof(MenuForm));

			private static readonly SerializableProperty PreferdMenuItemLabelWidthProperty = SerializableProperty.Register("PreferdMenuItemLabelWidth", typeof(int), typeof(MenuForm));

			private static readonly SerializableProperty PreferdMenuItemShortCutWidthProperty = SerializableProperty.Register("PreferdMenuItemShortCutWidth", typeof(int), typeof(MenuForm));

			private static readonly SerializableProperty PreferdMenuItemArrowWidthProperty = SerializableProperty.Register("PreferdMenuItemArrowWidth", typeof(int), typeof(MenuForm));

			private static readonly SerializableProperty ShareFocusProperty = SerializableProperty.Register("ShareFocus", typeof(bool), typeof(MenuForm));

			/// 
			///
			/// </summary>
			private Menu mobjMenu = null;

			/// 
			/// Gets a value indicating whether animation is enabled by default.
			/// </summary>
			/// true</c> if animation is enabled by default; otherwise, false</c>.</value>
			protected override bool DefaultAnimation => base.AnimationEnabled;

			/// 
			/// Gets or sets the width of the mint preferd menu item icon.
			/// </summary>
			/// The width of the mint preferd menu item icon.</value>
			internal int PreferdMenuItemIconWidthInternal
			{
				get
				{
					return GetValue(PreferdMenuItemIconWidthProperty);
				}
				set
				{
					SetValue(PreferdMenuItemIconWidthProperty, value);
				}
			}

			/// 
			/// Gets or sets a value indicating whether [share focus].
			/// </summary>
			/// true</c> if [share focus]; otherwise, false</c>.</value>
			internal bool ShareFocus
			{
				get
				{
					return GetValue(ShareFocusProperty);
				}
				set
				{
					SetValue(ShareFocusProperty, value);
				}
			}

			/// 
			/// Gets or sets the width of the mint preferd menu item label.
			/// </summary>
			/// The width of the mint preferd menu item label.</value>
			internal int PreferdMenuItemLabelWidthInternal
			{
				get
				{
					return GetValue(PreferdMenuItemLabelWidthProperty);
				}
				set
				{
					SetValue(PreferdMenuItemLabelWidthProperty, value);
				}
			}

			/// 
			/// Gets or sets the width of the mint preferd menu item shotr cut.
			/// </summary>
			/// The width of the mint preferd menu item shotr cut.</value>
			internal int PreferdMenuItemShortCutWidthInternal
			{
				get
				{
					return GetValue(PreferdMenuItemShortCutWidthProperty);
				}
				set
				{
					SetValue(PreferdMenuItemShortCutWidthProperty, value);
				}
			}

			/// 
			/// Gets or sets the width of the mint preferd menu item arrow.
			/// </summary>
			/// The width of the mint preferd menu item arrow.</value>
			internal int PreferdMenuItemArrowWidthInternal
			{
				get
				{
					return GetValue(PreferdMenuItemArrowWidthProperty);
				}
				set
				{
					SetValue(PreferdMenuItemArrowWidthProperty, value);
				}
			}

			/// 
			/// Gets or sets the owning menu.
			/// </summary>
			/// The owning menu.</value>
			public Menu OwningMenu => mobjMenu;

			/// 
			/// Gets a value indicating whether to reverse control rendering.
			/// </summary>
			/// 
			/// 	true</c> if to reverse control rendering; otherwise, false</c>.
			/// </value>
			protected override bool ReverseControls => true;

			/// 
			/// Renders the forms attribute
			/// </summary>
			/// <param name="objContext"></param>
			/// <param name="objWriter"></param>
			protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
			{
				if (OwningMenu != null && OwningMenu is MenuItem && OwningMenu.Owner != null)
				{
					objWriter.WriteAttributeString("oId", OwningMenu.Owner.ID);
				}
				if (ShareFocus)
				{
					objWriter.WriteAttributeString("SF", "1");
				}
				objWriter.WriteAttributeString("MILW", PreferdMenuItemLabelWidthInternal);
				if (PreferdMenuItemShortCutWidthInternal > 0)
				{
					objWriter.WriteAttributeString("MISW", PreferdMenuItemShortCutWidthInternal);
				}
				if (PreferdMenuItemArrowWidthInternal > 0)
				{
					objWriter.WriteAttributeString("MIAW", PreferdMenuItemArrowWidthInternal);
				}
				base.RenderAttributes(objContext, objWriter);
			}

			/// 
			/// Initializes a new instance of the <see cref="!:MenuControl" /> class.
			/// </summary>
			/// <param name="objMenu">The owner menu.</param>
			internal MenuForm(Menu objMenu)
			{
				CustomStyle = "Menu";
				mobjMenu = objMenu;
				base.Size = new Size(200, 400);
			}

			/// 
			/// Shows the menu.
			/// </summary>
			/// <param name="objComponent">The obj component.</param>
			/// <param name="objPoint">The obj point.</param>
			/// <param name="enmDialogAlignment">The enm dialog alignment.</param>
			internal void ShowMenu(Component objComponent, Point objPoint, DialogAlignment enmDialogAlignment)
			{
				if (OwningMenu != null && OwningMenu.MenuItems.Count > 0)
				{
					InitializeMenu(objPoint);
					ShowPopup(objComponent, enmDialogAlignment);
				}
			}

			/// 
			/// Shows the menu.
			/// </summary>
			/// <param name="objClientComponent">The obj client component.</param>
			/// <param name="objPoint">The obj point.</param>
			/// <param name="enmDialogAlignment">The enm dialog alignment.</param>
			internal void ShowMenu(Component objSourceComponent, IIdentifiedComponent objMemberComponent, Point objPoint, DialogAlignment enmDialogAlignment)
			{
				if (OwningMenu != null && OwningMenu.MenuItems.Count > 0)
				{
					InitializeMenu(objPoint);
					ShowPopup(objSourceComponent, objMemberComponent, enmDialogAlignment);
				}
			}

			/// 
			/// Shows the menu internal.
			/// </summary>
			/// <param name="objPoint">The obj point.</param>
			/// </returns>
			private void InitializeMenu(Point objPoint)
			{
				base.Controls.Clear();
				bool flag = true;
				bool flag2 = false;
				int num = 0;
				int num2 = 0;
				MenuItemControl menuItemControl = null;
				MenuItemControl menuItemControl2 = null;
				foreach (MenuItem menuItem in OwningMenu.MenuItems)
				{
					if (!menuItem.Visible)
					{
						continue;
					}
					MenuItemControl menuItemControl3 = new MenuItemControl(menuItem);
					base.Controls.Add(menuItemControl3);
					if (menuItemControl == null && !menuItem.Enabled)
					{
						menuItemControl = menuItemControl3;
					}
					if (!menuItemControl3.IsSeperator)
					{
						if (flag)
						{
							menuItemControl2 = menuItemControl3;
							PreferdMenuItemIconWidthInternal = menuItemControl3.GetPreferdIconColumnWidth();
							PreferdMenuItemArrowWidthInternal = menuItemControl3.GetPreferdArrowWidth();
							flag = false;
						}
						if (!flag2 && menuItemControl3.HasSubItems)
						{
							flag2 = true;
						}
						PreferdMenuItemLabelWidthInternal = Math.Max(PreferdMenuItemLabelWidthInternal, menuItemControl3.GetPreferdLableWidth());
						PreferdMenuItemShortCutWidthInternal = Math.Max(PreferdMenuItemShortCutWidthInternal, menuItemControl3.GetPreferdShortCutWidth());
					}
					num += menuItemControl3.Height;
				}
				num2 = PreferdMenuItemLabelWidthInternal + PreferdMenuItemShortCutWidthInternal + PreferdMenuItemIconWidthInternal;
				if (OwningMenu.AutoScrollItemCount >= 0 && OwningMenu.MenuItems.Count > OwningMenu.AutoScrollItemCount)
				{
					AutoScroll = true;
					base.ScrollerType = ScrollerType.Arrows;
				}
				if (SkinFactory.GetSkin(mobjMenu) is MenuSkin menuSkin)
				{
					num += menuSkin.PopupWindowOffsetHeight;
					num2 += menuSkin.PopupWindowOffsetWidth;
				}
				if (menuItemControl2 != null && SkinFactory.GetSkin(menuItemControl2) is MenuItemSkin menuItemSkin)
				{
					num2 += (Context.RightToLeft ? (menuItemSkin.MenuItemIconPaddingLTR.Left + menuItemSkin.MenuItemIconPaddingLTR.Right) : (menuItemSkin.MenuItemIconPaddingRTL.Left + menuItemSkin.MenuItemIconPaddingRTL.Right));
				}
				if (flag2)
				{
					num2 += PreferdMenuItemArrowWidthInternal;
				}
				if (num2 % 2 != 0)
				{
					num2++;
				}
				if (menuItemControl != null && SkinFactory.GetSkin(menuItemControl) is MenuItemSkin { ControlDisabledStyle: { BorderStyle: not BorderStyle.None } controlDisabledStyle })
				{
					num2 += controlDisabledStyle.BorderWidth.Left + controlDisabledStyle.BorderWidth.Right;
				}
				base.Size = new Size(num2, num);
				if (objPoint != Point.Empty)
				{
					base.Location = objPoint;
					base.StartPosition = FormStartPosition.Manual;
				}
			}

			/// 
			/// Gets the critical events.
			/// </summary>
			/// </returns>
			protected override CriticalEventsData GetCriticalEventsData()
			{
				CriticalEventsData criticalEventsData = base.GetCriticalEventsData();
				if (OwningMenu != null && OwningMenu is ContextMenu && ((ContextMenu)OwningMenu).RegisteredCollapseEvent)
				{
					criticalEventsData.Set("CLO");
				}
				return criticalEventsData;
			}

			/// 
			/// Closes all hierarchic forms.
			/// </summary>
			internal void CloseAll()
			{
				Close();
				if (base.Owner is MenuForm menuForm)
				{
					menuForm.CloseAll();
				}
			}
		}

		/// 
		///
		/// </summary>
		[Serializable]
		[MetadataTag("I")]
		[Skin(typeof(MenuItemSkin))]
		internal class MenuItemControl : Control
		{
			private static readonly SerializableProperty ShortcutProperty = SerializableProperty.Register("Shortcut", typeof(Shortcut), typeof(MenuItemControl));

			/// 
			///
			/// </summary>
			private MenuItem mobjMenuItem = null;

			/// 
			/// Gets/Sets the controls docking style
			/// </summary>
			/// </value>
			public override DockStyle Dock
			{
				get
				{
					return DockStyle.Top;
				}
				set
				{
					base.Dock = value;
				}
			}

			/// 
			/// Gets a value indicating whether this instance is seperator.
			/// </summary>
			/// 
			/// 	true</c> if this instance is seperator; otherwise, false</c>.
			/// </value>
			internal bool IsSeperator
			{
				get
				{
					if (mobjMenuItem.Text == "-")
					{
						return true;
					}
					return false;
				}
			}

			/// 
			/// Gets a value indicating whether this instance has sub items.
			/// </summary>
			/// 
			/// 	true</c> if this instance has sub items; otherwise, false</c>.
			/// </value>
			internal bool HasSubItems
			{
				get
				{
					if (mobjMenuItem != null && mobjMenuItem.MenuItems.Count > 0)
					{
						return true;
					}
					return false;
				}
			}

			public Shortcut Shortcut
			{
				get
				{
					return GetValue(ShortcutProperty);
				}
				set
				{
					if (Shortcut != value)
					{
						SetValue(ShortcutProperty, value);
					}
				}
			}

			/// 
			/// Gets the font of the text displayed by the control.
			/// </summary>
			/// </value>
			public override Font Font
			{
				get
				{
					MenuItemSkin menuItemSkin = base.Skin as MenuItemSkin;
					Font font = base.Font;
					if (menuItemSkin != null)
					{
						StyleValue styleValue = (StyleValue)((BidirectionalSkinValue<object>)menuItemSkin.MenuItemNormalCenter).GetObject(Context);
						if (styleValue != null)
						{
							font = styleValue.Font;
						}
					}
					return font;
				}
			}

			/// 
			/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.Menu.MenuItemControl" /> class.
			/// </summary>
			/// <param name="objMenuItem">The obj menu item.</param>
			internal MenuItemControl(MenuItem objMenuItem)
			{
				mobjMenuItem = objMenuItem;
				Text = objMenuItem.Text;
				base.Tag = objMenuItem;
				base.VisualEffect = objMenuItem.VisualEffect;
				int num = 0;
				num = ((!IsSeperator) ? ((MenuItemSkin)base.Skin).Height : ((MenuItemSkin)base.Skin).SeperatorHeight);
				if (!objMenuItem.Enabled && base.Skin is MenuItemSkin { ControlDisabledStyle: { BorderStyle: not BorderStyle.None } controlDisabledStyle })
				{
					num += controlDisabledStyle.BorderWidth.Top + controlDisabledStyle.BorderWidth.Bottom;
				}
				base.Height = num;
				if (!HasSubItems)
				{
					base.Click += MenuItemControl_Click;
				}
			}

			/// 
			/// Fires an event.
			/// </summary>
			/// <param name="objEvent">event.</param>
			protected override void FireEvent(IEvent objEvent)
			{
				string type = objEvent.Type;
				if (type == "Enter")
				{
					OnEnter();
				}
				base.FireEvent(objEvent);
			}

			/// 
			/// </summary>
			/// <param name="objContext"></param>
			/// <param name="objWriter"></param>
			protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
			{
				if (mobjMenuItem != null)
				{
					if (!string.IsNullOrEmpty(mobjMenuItem.Text))
					{
						objWriter.WriteAttributeText("TX", mobjMenuItem.Text, (TextFilter)5);
					}
					if (HasSubItems)
					{
						objWriter.WriteAttributeString("HN", "1");
					}
					if (!mobjMenuItem.Enabled)
					{
						objWriter.WriteAttributeString("En", "0");
					}
					if (mobjMenuItem.Checked)
					{
						if (mobjMenuItem.RadioCheck)
						{
							objWriter.WriteAttributeString("RC", "1");
						}
						else
						{
							objWriter.WriteAttributeString("C", "1");
						}
					}
					if (mobjMenuItem.Icon != null)
					{
						objWriter.WriteAttributeString("I", mobjMenuItem.Icon.ToString());
					}
					if (IsSeperator)
					{
						objWriter.WriteAttributeString("ISS", "1");
					}
					if (mobjMenuItem.Shortcut != Shortcut.None)
					{
						objWriter.WriteAttributeString("SC", GetShortcutString());
					}
					mobjMenuItem.ClientAction?.RenderAttributes((IContextMethodInvoker)objContext, objWriter);
					mobjMenuItem.RenderExtendedComponentAttributes(objContext, objWriter);
				}
				base.RenderAttributes(objContext, objWriter);
			}

			/// 
			/// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click" />
			/// event.
			/// </summary>
			/// <param name="objEventArgs">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			protected override void OnClick(EventArgs objEventArgs)
			{
				if (mobjMenuItem == null || mobjMenuItem.MenuItems.Count == 0)
				{
					if (Form is MenuForm menuForm)
					{
						menuForm.CloseAll();
					}
					mobjMenuItem.FireClick();
				}
				base.OnClick(objEventArgs);
			}

			/// 
			/// Raises the <see cref="E:TransitionVisualEffectEnd" /> event.
			/// </summary>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			protected override void OnTransitionVisualEffectEnd(EventArgs e)
			{
				if (mobjMenuItem != null)
				{
					mobjMenuItem.OnTransitionVisualEffectEnd(new EventArgs());
				}
			}

			/// 
			/// Handles the Enter event of the MenuItemControl control.
			/// </summary>
			private void OnEnter()
			{
				ShowSubMenu(base.Tag as MenuItem);
			}

			/// 
			/// Handles the Click event of the MenuItemControl control.
			/// </summary>
			/// <param name="sender">The source of the event.</param>
			/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
			private void MenuItemControl_Click(object sender, EventArgs e)
			{
				if (sender is Button button && Form != null && button.Tag is MenuItem objMenuItem)
				{
					if (HasSubItems)
					{
						ShowSubMenu(objMenuItem);
					}
					else
					{
						OnClick(new EventArgs());
					}
				}
			}

			/// 
			/// Shows the sub menu.
			/// </summary>
			/// <param name="objMenuItem">The obj menu item.</param>
			private void ShowSubMenu(MenuItem objMenuItem)
			{
				if (HasSubItems)
				{
					objMenuItem.Show(this, Point.Empty, Context.RightToLeft ? DialogAlignment.Left : DialogAlignment.Right, blnShareFocus: true);
				}
			}

			/// 
			/// Fires the click.
			/// </summary>
			/// <param name="objMenuItem">The obj menu item.</param>
			internal void FireClick(MenuItem objMenuItem)
			{
				if (mobjMenuItem != null)
				{
					Menu parent = mobjMenuItem.Parent;
					if (parent != null)
					{
						parent.FireClick(objMenuItem);
					}
					else
					{
						mobjMenuItem.InternalParent?.FireMenuClick(objMenuItem);
					}
				}
			}

			/// 
			/// Gets the shortcut string.
			/// </summary>
			/// </returns>
			private string GetShortcutString()
			{
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(Keys));
				if (converter != null)
				{
					return converter.ConvertToString((Keys)mobjMenuItem.Shortcut);
				}
				return Shortcut.ToString();
			}

			/// 
			/// Gets the width of the preferd lable.
			/// </summary>
			/// </returns>
			internal int GetPreferdLableWidth()
			{
				if (string.IsNullOrEmpty(Text))
				{
					return 0;
				}
				if (base.Skin is MenuItemSkin menuItemSkin && Font != null)
				{
					StyleValue styleValue = (StyleValue)menuItemSkin.MenuItemLabelNormalStyle.GetObject(Context);
					int num = 0;
					if (styleValue != null)
					{
						num = styleValue.Padding.Left + styleValue.Padding.Right;
					}
					return CommonUtils.GetStringMeasurements(Text, Font, blnIgnoreNewLines: true).Width + num;
				}
				return Text.Length * 10;
			}

			/// 
			/// Gets the width of the preferd short cut.
			/// </summary>
			/// </returns>
			internal int GetPreferdShortCutWidth()
			{
				if (mobjMenuItem.Shortcut == Shortcut.None)
				{
					return 0;
				}
				string shortcutString = GetShortcutString();
				if (base.Skin is MenuItemSkin menuItemSkin && Font != null)
				{
					StyleValue styleValue = (StyleValue)menuItemSkin.MenuItemLabelNormalStyle.GetObject(Context);
					int num = 0;
					if (styleValue != null)
					{
						num = styleValue.Padding.Left + styleValue.Padding.Right;
					}
					return CommonUtils.GetStringMeasurements(shortcutString, Font, blnIgnoreNewLines: true).Width + num;
				}
				return shortcutString.Length * 10;
			}

			/// 
			/// Gets the width of the preferd arrow.
			/// </summary>
			/// </returns>
			internal int GetPreferdArrowWidth()
			{
				if (base.Skin is MenuItemSkin menuItemSkin)
				{
					PaddingValue paddingValue = (PaddingValue)menuItemSkin.MenuItemArrowPadding.GetObject(Context);
					int num = 0;
					if (paddingValue != null)
					{
						num = paddingValue.Left + paddingValue.Right;
					}
					string value = ((BidirectionalSkinValue<object>)menuItemSkin.ArrowImageWidth).GetValue(Context);
					return int.Parse(value) + num;
				}
				return 0;
			}

			/// 
			/// Gets the width of the preferd icon column.
			/// </summary>
			/// </returns>
			internal int GetPreferdIconColumnWidth()
			{
				if (!(base.Skin is MenuItemSkin { MenuItemIconsColumnWidth: var menuItemIconsColumnWidth }))
				{
					return 0;
				}
				return menuItemIconsColumnWidth;
			}
		}

		/// 
		/// The Collapse event registration.
		/// </summary>
		private static readonly SerializableEvent CollapseEvent;

		/// 
		/// The Popup event registration.
		/// </summary>
		private static readonly SerializableEvent PopupEvent;

		/// 
		/// The ItemsInternal property registration.
		/// </summary>
		private static readonly SerializableProperty ItemsProperty;

		/// 
		/// The IsRegisteredInternal property registration.
		/// </summary>
		private static readonly SerializableProperty IsRegisteredProperty;

		/// 
		/// The ReferenceCountInteranl property registration.
		/// </summary>
		private static readonly SerializableProperty ReferenceCountProperty;

		/// 
		/// The Owner property registration.
		/// </summary>
		private static readonly SerializableProperty OwnerProperty;

		/// 
		/// The Member property registration.
		/// </summary>
		private static readonly SerializableProperty MemberProperty;

		/// 
		/// The ScrollerForItemcountExceedin property registration.
		/// </summary>
		private static readonly SerializableProperty AutoScrollItemCountProperty;

		/// 
		/// The skin of the current menu
		/// </summary>
		[NonSerialized]
		private MenuSkin mobjSkin = null;

		/// 
		/// Gets the hanlder for the Collapse event.
		/// </summary>
		private EventHandler CollapseHandler => (EventHandler)GetHandler(Collapse);

		/// 
		/// Gets the hanlder for the Popup event.
		/// </summary>
		private EventHandler PopupHandler => (EventHandler)GetHandler(Popup);

		/// 
		/// Gets the menu items.
		/// </summary>
		/// The menu items.</value>
		ICollection IMenu.MenuItems => MenuItems;

		/// 
		/// Gets the parent.
		/// </summary>
		/// The parent.</value>
		IComponent IMenu.Parent => InternalParent;

		/// 
		/// Gets the skin of the current menu.
		/// </summary>
		/// The skin of the current menu.</value>
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[Browsable(false)]
		protected MenuSkin Skin
		{
			get
			{
				if (mobjSkin == null)
				{
					mobjSkin = (MenuSkin)SkinFactory.GetSkin(this);
				}
				return mobjSkin;
			}
		}

		/// 
		/// Gets the theme related to the skinable component.
		/// </summary>
		/// The theme related to the skinable component.</value>
		string ISkinable.Theme => Context.CurrentTheme;

		/// 
		/// Gets or sets the context menu code.
		/// </summary>
		/// </value>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override ContextMenu ContextMenu
		{
			get
			{
				return base.ContextMenu;
			}
			set
			{
				base.ContextMenu = value;
			}
		}

		/// 
		/// Number of items required in a single menu to activate scrollers (0 if always activate, -1 if never)
		/// </summary>
		/// Number of items required in a single menu to activate scrollers (0 if always activate, -1 if never).</value>
		[DefaultValue(10)]
		[SRDescription("Number of items required in a single menu to activate scrollers (0 if always activate, -1 if never)")]
		[Localizable(true)]
		[SRCategory("Misc")]
		public int AutoScrollItemCount
		{
			get
			{
				return GetValue(AutoScrollItemCountProperty, 10);
			}
			set
			{
				SetValue(AutoScrollItemCountProperty, value);
			}
		}

		/// 
		/// Gets the menu items.
		/// </summary>
		/// The menu items.</value>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[ListBindable(false)]
		[Browsable(false)]
		public MenuItemCollection MenuItems
		{
			get
			{
				MenuItemCollection menuItemCollection = GetValue(ItemsProperty, null);
				if (menuItemCollection == null)
				{
					menuItemCollection = new MenuItemCollection(this);
					SetValue(ItemsProperty, menuItemCollection);
				}
				return menuItemCollection;
			}
		}

		/// 
		/// Gets the mapped menu form.
		/// </summary>
		/// The mapped menu form.</value>
		private MenuForm MappedMenuForm
		{
			get
			{
				MenuForm menuForm = new MenuForm(this);
				if (this is ContextMenu && ((ContextMenu)this).RegisteredCollapseEvent)
				{
					menuForm.Closed += objMenuControl_Closed;
				}
				return menuForm;
			}
		}

		/// 
		/// Gets or sets the owner control.
		/// </summary>
		/// The owner control.</value>
		internal Component Owner
		{
			get
			{
				return GetValue(OwnerProperty, null);
			}
			set
			{
				if (value != Owner)
				{
					SetValue(OwnerProperty, value);
				}
			}
		}

		/// 
		/// Gets or sets the member.
		/// </summary>
		/// The member.</value>
		internal IIdentifiedComponent Member
		{
			get
			{
				return GetValue(MemberProperty, null);
			}
			set
			{
				if (value != Member)
				{
					SetValue(MemberProperty, value);
				}
			}
		}

		/// Occurs when the shortcut menu collapses.</summary>
		/// 1</filterpriority>
		[SRDescription("ContextMenuCollapseDescr")]
		public event EventHandler Collapse
		{
			add
			{
				AddHandler(CollapseEvent, value);
			}
			remove
			{
				RemoveHandler(CollapseEvent, value);
			}
		}

		/// Occurs before the shortcut menu is displayed.</summary>
		/// 1</filterpriority>
		[SRDescription("MenuItemOnInitDescr")]
		public event EventHandler Popup
		{
			add
			{
				AddHandler(PopupEvent, value);
			}
			remove
			{
				RemoveHandler(PopupEvent, value);
			}
		}

		/// 
		/// Invokes when a menu item was clicked
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This event is obsolete")]
		public override event MenuEventHandler MenuClick
		{
			add
			{
				base.MenuClick += value;
			}
			remove
			{
				base.MenuClick -= value;
			}
		}

		/// 
		/// Occurs when a drag-and-drop operation is completed.</summary>
		/// </summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This event is obsolete")]
		public override event DragEventHandler DragDrop
		{
			add
			{
				base.DragDrop += value;
			}
			remove
			{
				base.DragDrop -= value;
			}
		}

		/// 
		/// Displays the shortcut menu at the specified position and with the specified alignment.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		/// <param name="objPoint">The obj point.</param>
		/// <param name="enmDialogAlignment">The enm dialog alignment.</param>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Show(Component objComponent, Point objPoint, DialogAlignment enmDialogAlignment)
		{
			ShowInternal(objComponent, null, objPoint, enmDialogAlignment, null);
		}

		/// 
		/// Shows the specified obj component.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		/// <param name="objPoint">The obj point.</param>
		/// <param name="enmDialogAlignment">The enm dialog alignment.</param>
		/// <param name="blnShareFocus">if set to true</c> [BLN share focus].</param>
		public void Show(Component objComponent, Point objPoint, DialogAlignment enmDialogAlignment, bool blnShareFocus)
		{
			ShowInternal(objComponent, null, objPoint, enmDialogAlignment, blnShareFocus);
		}

		/// 
		/// Displays the shortcut menu at the specified position and with the specified alignment.
		/// </summary>
		/// <param name="objSourceComponent">The obj source component.</param>
		/// <param name="objMemberComponent">The obj member component.</param>
		/// <param name="objPoint">The obj point.</param>
		/// <param name="enmDialogAlignment">The enm dialog alignment.</param>
		/// <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
		public void Show(Component objSourceComponent, IIdentifiedComponent objMemberComponent, Point objPoint, DialogAlignment enmDialogAlignment)
		{
			ShowInternal(objSourceComponent, objMemberComponent, objPoint, enmDialogAlignment, null);
		}

		/// 
		/// Displays the shortcut menu at the specified position.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		/// <param name="objPoint">The obj point.</param>
		public void Show(Component objComponent, Point objPoint)
		{
			Show(objComponent, objPoint, DialogAlignment.Custom);
		}

		/// 
		/// Displays the shortcut menu at the specified position and with the specified alignment.
		/// </summary>
		/// <param name="objComponent">The obj component.</param>
		/// <param name="objPoint">The obj point.</param>
		/// <param name="enmLeftRightAlignment">The enm left right alignment.</param>
		[Obsolete("LeftRightAlignment is not suported yet")]
		public void Show(Component objComponent, Point objPoint, LeftRightAlignment enmLeftRightAlignment)
		{
			Show(objComponent, objPoint, DialogAlignment.Custom);
		}

		/// 
		/// Shows the specified obj source component.
		/// </summary>
		/// <param name="objSourceComponent">The obj source component.</param>
		/// <param name="objMemberComponent">The obj member component.</param>
		/// <param name="objPoint">The obj point.</param>
		/// <param name="enmLeftRightAlignment">The enm left right alignment.</param>
		[Obsolete("LeftRightAlignment is not suported yet")]
		public void Show(Component objSourceComponent, IIdentifiedComponent objMemberComponent, Point objPoint, LeftRightAlignment enmLeftRightAlignment)
		{
			ShowInternal(objSourceComponent, objMemberComponent, objPoint, DialogAlignment.Custom, null);
		}

		/// 
		/// private function to deal with all the common code of the Show function.
		/// </summary>
		/// <param name="objComponent">&gt;The obj component.</param>
		/// <param name="objMemberComponent"></param>
		/// <param name="objPoint">The obj point.</param>
		/// <param name="enmDialogAlignment">The enm dialog alignment.</param>
		private void ShowInternal(Component objComponent, IIdentifiedComponent objMemberComponent, Point objPoint, DialogAlignment enmDialogAlignment, bool? blnShareFocus)
		{
			MenuForm mappedMenuForm = MappedMenuForm;
			if (objComponent != null)
			{
				Owner = objComponent;
			}
			if (objMemberComponent != null)
			{
				Member = objMemberComponent;
			}
			if (blnShareFocus.HasValue)
			{
				mappedMenuForm.ShareFocus = blnShareFocus.Value;
			}
			OnPopup(EventArgs.Empty);
			if (objMemberComponent != null)
			{
				mappedMenuForm.ShowMenu(objComponent, objMemberComponent, objPoint, enmDialogAlignment);
			}
			else
			{
				mappedMenuForm.ShowMenu(objComponent, objPoint, enmDialogAlignment);
			}
		}

		/// 
		/// Raises the <see cref="E:Popup" /> event.
		/// </summary>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		protected virtual void OnPopup(EventArgs e)
		{
			PopupHandler?.Invoke(this, e);
		}

		/// 
		/// Adds a child object.
		/// </summary>
		/// <param name="objValue">The child object to add.</param>
		protected override void AddChild(object objValue)
		{
			if (objValue is MenuItem)
			{
				MenuItems.Add((MenuItem)objValue);
			}
			else
			{
				base.AddChild(objValue);
			}
		}

		/// 
		/// Handles the Closed event of the objMenuControl control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="T:System.EventArgs" /> instance containing the event data.</param>
		private void objMenuControl_Closed(object sender, EventArgs e)
		{
			if (this is ContextMenu)
			{
				((ContextMenu)this).OnCollapse(new EventArgs());
			}
		}

		/// 
		/// Fires the click.
		/// </summary>
		/// <param name="objMenuItem">The menu item.</param>
		protected internal void FireClick(MenuItem objMenuItem)
		{
			if (Owner is MenuItemControl menuItemControl)
			{
				if (menuItemControl.Form is MenuForm)
				{
					menuItemControl.Form.Close();
				}
				menuItemControl.FireClick(objMenuItem);
			}
			else
			{
				Owner?.FireMenuClick(objMenuItem, Member);
			}
		}

		static Menu()
		{
			Collapse = SerializableEvent.Register("Collapse", typeof(EventHandler), typeof(Menu));
			Popup = SerializableEvent.Register("Popup", typeof(EventHandler), typeof(Menu));
			ItemsProperty = SerializableProperty.Register("Items", typeof(MenuItemCollection), typeof(Menu));
			IsRegisteredProperty = SerializableProperty.Register("IsRegistered", typeof(bool), typeof(Menu));
			ReferenceCountProperty = SerializableProperty.Register("ReferenceCount", typeof(int), typeof(Menu));
			OwnerProperty = SerializableProperty.Register("Owner", typeof(Component), typeof(Menu));
			MemberProperty = SerializableProperty.Register("Member", typeof(IIdentifiedComponent), typeof(Menu));
			AutoScrollItemCountProperty = SerializableProperty.Register("AutoScrollItemCount", typeof(int), typeof(Menu));
		}
	}
}
