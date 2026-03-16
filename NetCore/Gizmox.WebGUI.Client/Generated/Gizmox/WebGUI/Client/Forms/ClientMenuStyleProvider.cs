using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Text;
using System.Threading;
using System.Web;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
using Gizmox.WebGUI.Client.Controllers;
using Gizmox.WebGUI.Client.Design;
using Gizmox.WebGUI.Client.Forms;
using Gizmox.WebGUI.Client.Providers;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Configuration;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Interfaces.Device;
using Gizmox.WebGUI.Common.Interfaces.Emulation;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.WebSockets;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Hosting;

namespace Gizmox.WebGUI.Client.Forms
{
	[ProvideProperty("NewStyleActive", typeof(System.Windows.Forms.MenuItem))]
	[ProvideProperty("MenuGlyph", typeof(System.Windows.Forms.MenuItem))]
	[ToolboxBitmap(typeof(ClientMenuStyleProvider), "images.ClientMenuStyleProvider.bmp")]
	internal class ClientMenuStyleProvider : System.ComponentModel.Component, IExtenderProvider
	{
		internal class MenuItemInfo
		{
			public bool NewStyle;

			public Image Glyph;

			public MenuItemInfo(bool newstyle, Image glyph)
			{
				NewStyle = newstyle;
				Glyph = glyph;
			}
		}

		internal class DrawItemInfo
		{
			public Image Glyph;

			public bool HotLight;

			public bool Selected;

			public bool Disabled;

			public bool Checked;

			public Rectangle Rct;

			public System.Windows.Forms.MenuItem Item;

			public bool IsTopItem => Item.Parent == Item.Parent.GetMainMenu();

			public System.Windows.Forms.MainMenu MainMenu => Item.Parent.GetMainMenu();

			public DrawItemInfo(object sender, DrawItemEventArgs e, Image glyph)
			{
				Item = (System.Windows.Forms.MenuItem)sender;
				Glyph = glyph;
				Disabled = (e.State & DrawItemState.Disabled) == DrawItemState.Disabled;
				Selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
				Checked = (e.State & DrawItemState.Checked) == DrawItemState.Checked;
				HotLight = (e.State & DrawItemState.HotLight) == DrawItemState.HotLight;
				Rct = e.Bounds;
			}
		}

		private Container components;

		private Hashtable _menuitems;

		private System.Windows.Forms.Form _owner = null;

		private IntPtr _hook = IntPtr.Zero;

		private Win32.HookProc _hookprc = null;

		private MenuHook lastHook = null;

		private StringFormat fmt = new StringFormat();

		private Size _marginSize = new Size(23, 22);

		private int _lastwidth = 0;

		private LinearGradientBrush lnbrs = new LinearGradientBrush(new Point(0, 0), new Point(1, 0), Color.Black, Color.White);

		private Pen border = new Pen(Color.Black);

		private SolidBrush hotbrs = new SolidBrush(Color.White);

		private Color[][] _cols = new Color[4][]
		{
			new Color[3]
			{
				Color.FromArgb(227, 239, 255),
				Color.FromArgb(203, 225, 252),
				Color.FromArgb(135, 173, 228)
			},
			new Color[2]
			{
				Color.FromArgb(195, 218, 249),
				Color.FromArgb(158, 190, 245)
			},
			new Color[2]
			{
				Color.FromArgb(255, 238, 194),
				Color.FromArgb(255, 214, 154)
			},
			new Color[2]
			{
				Color.FromArgb(246, 246, 246),
				Color.FromArgb(0, 0, 128)
			}
		};

		private ColorBlend[] _blends = new ColorBlend[2];

		public override ISite Site
		{
			get
			{
				return base.Site;
			}
			set
			{
				base.Site = value;
				if (Site != null)
				{
					IDesignerHost designerHost = (IDesignerHost)Site.GetService(typeof(IDesignerHost));
					if (designerHost != null && designerHost.RootComponent is System.Windows.Forms.Form)
					{
						OwnerForm = (System.Windows.Forms.Form)designerHost.RootComponent;
					}
				}
			}
		}

		[Browsable(false)]
		public System.Windows.Forms.Form OwnerForm
		{
			get
			{
				return _owner;
			}
			set
			{
				if (_hook != IntPtr.Zero)
				{
					Win32.UnhookWindowsHookEx(_hook);
					_hook = IntPtr.Zero;
				}
				_owner = value;
				if (_owner != null)
				{
					if (_hookprc == null)
					{
						_hookprc = OnHookProc;
					}
					_hook = Win32.SetWindowsHookEx(4, _hookprc, IntPtr.Zero, Win32.GetWindowThreadProcessId(_owner.Handle, 0));
				}
			}
		}

		[Browsable(false)]
		public LinearGradientBrush MarginBrush
		{
			get
			{
				_blends[1].Colors = _cols[0];
				lnbrs.InterpolationColors = _blends[1];
				lnbrs.Transform = new Matrix(_marginSize.Width, 0f, 0f, 1f, 1f, 0f);
				return lnbrs;
			}
		}

		[Browsable(false)]
		public int MarginWidth => _marginSize.Width;

		[Browsable(false)]
		public Pen BorderPen
		{
			get
			{
				border.Color = _cols[3][1];
				return border;
			}
		}

		[Browsable(false)]
		public Pen BackgroundPen
		{
			get
			{
				border.Color = _cols[3][0];
				return border;
			}
		}

		[Browsable(false)]
		public SolidBrush BackGroundBrush
		{
			get
			{
				hotbrs.Color = _cols[3][0];
				return hotbrs;
			}
		}

		[DefaultValue(typeof(Color), "0,0,128")]
		[Category("Colors")]
		[Description("the color of the border of the selection frame and the popup menu itself")]
		public Color BorderColor
		{
			get
			{
				return _cols[3][1];
			}
			set
			{
				_cols[3][1] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "255,238,194")]
		[Category("Colors")]
		[Description("specifies the lighter color of a preselected menuitem")]
		public Color HotLightGradientLight
		{
			get
			{
				return _cols[2][0];
			}
			set
			{
				_cols[2][0] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "255,214,154")]
		[Category("Colors")]
		[Description("specifies the darker color of a preselected menuitem")]
		public Color HotLightGradientDark
		{
			get
			{
				return _cols[2][1];
			}
			set
			{
				_cols[2][1] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "195,218,249")]
		[Category("Colors")]
		[Description("the color on the right side of a mainmenu")]
		public Color BandGradientLight
		{
			get
			{
				return _cols[1][0];
			}
			set
			{
				_cols[1][0] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "158,190,245")]
		[Category("Colors")]
		[Description("the color on the left side of a mainmenu")]
		public Color BandGradientDark
		{
			get
			{
				return _cols[1][1];
			}
			set
			{
				_cols[1][1] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "227,239,255")]
		[Category("Colors")]
		[Description("sets or gets the lighter color of the image-band next to each menuitem")]
		public Color ItemGradientLight
		{
			get
			{
				return _cols[0][0];
			}
			set
			{
				_cols[0][0] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "203,225,252")]
		[Category("Colors")]
		[Description("sets or gets the middle color of the image-band next to each menuitem")]
		public Color ItemGradientMiddle
		{
			get
			{
				return _cols[0][1];
			}
			set
			{
				_cols[0][1] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "135,173,228")]
		[Category("Colors")]
		[Description("sets or gets the darker color of the image-band next to each menuitem")]
		public Color ItemGradientDark
		{
			get
			{
				return _cols[0][2];
			}
			set
			{
				_cols[0][2] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Color), "246,246,246")]
		[Category("Colors")]
		[Description("sets or gets the background color of each contextmenu")]
		public Color MenuBackground
		{
			get
			{
				return _cols[3][0];
			}
			set
			{
				_cols[3][0] = Color.FromArgb(255, value);
			}
		}

		[DefaultValue(typeof(Size), "23,22")]
		[Category("Appearance")]
		[Description("sets or gets the size of the image band next to each contextmenu item")]
		public Size BandSize
		{
			get
			{
				return _marginSize;
			}
			set
			{
				if (value.Height < 16)
				{
					value.Height = 16;
				}
				if (value.Width < 16)
				{
					value.Width = 16;
				}
				_marginSize = value;
			}
		}

		public ClientMenuStyleProvider()
		{
			components = new Container();
			_menuitems = new Hashtable();
			fmt.HotkeyPrefix = HotkeyPrefix.Show;
			_blends[0] = new ColorBlend();
			_blends[0].Positions = new float[2] { 0f, 1f };
			_blends[0].Colors = _cols[1];
			_blends[1] = new ColorBlend();
			_blends[1].Positions = new float[3] { 0f, 0.5f, 1f };
			_blends[1].Colors = _cols[0];
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		bool IExtenderProvider.CanExtend(object target)
		{
			return target is System.Windows.Forms.MenuItem;
		}

		private void control_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			System.Windows.Forms.MenuItem menuItem = (System.Windows.Forms.MenuItem)sender;
			if (menuItem.Text == "-")
			{
				e.ItemHeight = 3;
				return;
			}
			string text = menuItem.Text.Replace("&", "");
			if (menuItem.Shortcut != System.Windows.Forms.Shortcut.None && menuItem.ShowShortcut)
			{
				text += GetShortcutString((System.Windows.Forms.Keys)menuItem.Shortcut);
			}
			int num = (int)e.Graphics.MeasureString(text, menuItem.DefaultItem ? new Font(SystemInformation.MenuFont, FontStyle.Bold) : SystemInformation.MenuFont, PointF.Empty, fmt).Width;
			if (menuItem.Parent == menuItem.Parent.GetMainMenu())
			{
				e.ItemHeight = 16;
				e.ItemWidth = num + 2;
			}
			else
			{
				e.ItemHeight = _marginSize.Height;
				e.ItemWidth = num + 45 + _marginSize.Width;
			}
		}

		private void control_DrawItem(object sender, DrawItemEventArgs e)
		{
			DrawItemInfo drawItemInfo = new DrawItemInfo(sender, e, GetMenuGlyph((System.Windows.Forms.MenuItem)sender));
			border.Color = _cols[3][1];
			if (drawItemInfo.IsTopItem)
			{
				System.Windows.Forms.Form form = drawItemInfo.MainMenu.GetForm();
				int num = form.ClientSize.Width + (form.Width - form.ClientSize.Width) / 2;
				_blends[0].Colors = _cols[1];
				lnbrs.InterpolationColors = _blends[0];
				lnbrs.Transform = new Matrix(0f - (float)num, 0f, 0f, 1f, 0f, 0f);
				if (e.Index >= drawItemInfo.MainMenu.MenuItems.Count - 1 || drawItemInfo.MainMenu.MenuItems[e.Index + 1].BarBreak)
				{
					e.Graphics.FillRectangle(lnbrs, drawItemInfo.Rct.X, drawItemInfo.Rct.Y, num - drawItemInfo.Rct.X, drawItemInfo.Rct.Height);
				}
				else
				{
					e.Graphics.FillRectangle(lnbrs, drawItemInfo.Rct);
				}
				_lastwidth = 0;
				if (drawItemInfo.Selected)
				{
					_lastwidth = e.Bounds.Width;
				}
				drawItemInfo.Rct.Width--;
				drawItemInfo.Rct.Height--;
				lnbrs.Transform = new Matrix(0f, drawItemInfo.Rct.Height + 1, 1f, 0f, 0f, drawItemInfo.Rct.Y);
				if (drawItemInfo.Selected && !drawItemInfo.Item.IsParent)
				{
					drawItemInfo.HotLight = true;
				}
				if (drawItemInfo.HotLight && !drawItemInfo.Disabled)
				{
					_blends[0].Colors = _cols[2];
					lnbrs.InterpolationColors = _blends[0];
					e.Graphics.FillRectangle(lnbrs, drawItemInfo.Rct);
					e.Graphics.DrawRectangle(border, drawItemInfo.Rct);
				}
				else if (drawItemInfo.Selected && !drawItemInfo.Disabled)
				{
					_blends[1].Colors = _cols[0];
					lnbrs.InterpolationColors = _blends[1];
					e.Graphics.FillRectangle(lnbrs, drawItemInfo.Rct);
					e.Graphics.DrawLines(border, new Point[4]
					{
						new Point(drawItemInfo.Rct.X, drawItemInfo.Rct.Bottom),
						new Point(drawItemInfo.Rct.X, drawItemInfo.Rct.Y),
						new Point(drawItemInfo.Rct.Right, drawItemInfo.Rct.Y),
						new Point(drawItemInfo.Rct.Right, drawItemInfo.Rct.Bottom)
					});
				}
				if (drawItemInfo.Item.Text != "")
				{
					SizeF sizeF = e.Graphics.MeasureString(drawItemInfo.Item.Text.Replace("&", ""), e.Font);
					e.Graphics.DrawString(drawItemInfo.Item.Text, e.Font, drawItemInfo.Disabled ? Brushes.Gray : Brushes.Black, drawItemInfo.Rct.X + (drawItemInfo.Rct.Width - (int)sizeF.Width) / 2, drawItemInfo.Rct.Y + (drawItemInfo.Rct.Height - (int)sizeF.Height) / 2, fmt);
				}
				return;
			}
			_blends[1].Colors = _cols[0];
			lnbrs.InterpolationColors = _blends[1];
			lnbrs.Transform = new Matrix(_marginSize.Width, 0f, 0f, 1f, (float)drawItemInfo.Rct.X - 1f, 0f);
			e.Graphics.FillRectangle(lnbrs, drawItemInfo.Rct.X, drawItemInfo.Rct.Y, _marginSize.Width, drawItemInfo.Rct.Height);
			hotbrs.Color = _cols[3][0];
			e.Graphics.FillRectangle(hotbrs, drawItemInfo.Rct.X + _marginSize.Width, drawItemInfo.Rct.Y, drawItemInfo.Rct.Width - _marginSize.Width, drawItemInfo.Rct.Height);
			if (drawItemInfo.Item.Text == "-")
			{
				border.Color = _cols[0][2];
				e.Graphics.DrawLine(border, drawItemInfo.Rct.X + _marginSize.Width + 2, drawItemInfo.Rct.Y + drawItemInfo.Rct.Height / 2, drawItemInfo.Rct.Right, drawItemInfo.Rct.Y + drawItemInfo.Rct.Height / 2);
				return;
			}
			if (drawItemInfo.Selected && !drawItemInfo.Disabled)
			{
				hotbrs.Color = _cols[2][0];
				e.Graphics.FillRectangle(hotbrs, drawItemInfo.Rct.X, drawItemInfo.Rct.Y, drawItemInfo.Rct.Width - 1, drawItemInfo.Rct.Height - 1);
				e.Graphics.DrawRectangle(border, drawItemInfo.Rct.X, drawItemInfo.Rct.Y, drawItemInfo.Rct.Width - 1, drawItemInfo.Rct.Height - 1);
			}
			if (drawItemInfo.Checked)
			{
				int num2 = _marginSize.Width / 2;
				int num3 = _marginSize.Height / 2;
				hotbrs.Color = _cols[2][1];
				e.Graphics.FillRectangle(hotbrs, drawItemInfo.Rct.X + 1, drawItemInfo.Rct.Y + 1, _marginSize.Width - 4, _marginSize.Height - 3);
				e.Graphics.DrawRectangle(border, drawItemInfo.Rct.X + 1, drawItemInfo.Rct.Y + 1, _marginSize.Width - 4, _marginSize.Height - 3);
				if (drawItemInfo.Glyph == null)
				{
					e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
					if (!drawItemInfo.Item.RadioCheck)
					{
						e.Graphics.FillPolygon(Brushes.Black, new Point[6]
						{
							new Point(drawItemInfo.Rct.X + num2 - 4, drawItemInfo.Rct.Y + num3 + 1),
							new Point(drawItemInfo.Rct.X + num2 - 1, drawItemInfo.Rct.Y + num3 + 3),
							new Point(drawItemInfo.Rct.X + num2 + 3, drawItemInfo.Rct.Y + num3 - 1),
							new Point(drawItemInfo.Rct.X + num2 + 3, drawItemInfo.Rct.Y + num3 - 3),
							new Point(drawItemInfo.Rct.X + num2 - 1, drawItemInfo.Rct.Y + num3 + 1),
							new Point(drawItemInfo.Rct.X + num2 - 4, drawItemInfo.Rct.Y + num3 - 1)
						});
					}
					else
					{
						e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
						e.Graphics.FillEllipse(Brushes.Black, drawItemInfo.Rct.X + num2 - 4, drawItemInfo.Rct.Y + num3 - 4, 7, 7);
					}
					e.Graphics.SmoothingMode = SmoothingMode.Default;
				}
			}
			if (drawItemInfo.Glyph != null)
			{
				if (!drawItemInfo.Disabled)
				{
					e.Graphics.DrawImageUnscaled(drawItemInfo.Glyph, drawItemInfo.Rct.X + (_marginSize.Width - drawItemInfo.Glyph.Width) / 2, drawItemInfo.Rct.Y + (_marginSize.Height - drawItemInfo.Glyph.Height) / 2);
				}
				else
				{
					ControlPaint.DrawImageDisabled(e.Graphics, drawItemInfo.Glyph, drawItemInfo.Rct.X + (_marginSize.Width - drawItemInfo.Glyph.Width) / 2, drawItemInfo.Rct.Y + (_marginSize.Height - drawItemInfo.Glyph.Height) / 2, Color.Transparent);
				}
			}
			Font font = (drawItemInfo.Item.DefaultItem ? new Font(e.Font, FontStyle.Bold) : SystemInformation.MenuFont);
			if (drawItemInfo.Item.Text != "")
			{
				SizeF sizeF2 = e.Graphics.MeasureString(drawItemInfo.Item.Text, font);
				e.Graphics.DrawString(drawItemInfo.Item.Text, font, drawItemInfo.Disabled ? Brushes.Gray : Brushes.Black, drawItemInfo.Rct.X + _marginSize.Width + 5, drawItemInfo.Rct.Y + (drawItemInfo.Rct.Height - (int)sizeF2.Height) / 2, fmt);
			}
			if (drawItemInfo.Item.Shortcut != System.Windows.Forms.Shortcut.None && drawItemInfo.Item.ShowShortcut)
			{
				string shortcutString = GetShortcutString((System.Windows.Forms.Keys)drawItemInfo.Item.Shortcut);
				SizeF sizeF2 = e.Graphics.MeasureString(shortcutString, font);
				e.Graphics.DrawString(shortcutString, font, drawItemInfo.Disabled ? Brushes.Gray : Brushes.Black, drawItemInfo.Rct.Right - (int)sizeF2.Width - 16, drawItemInfo.Rct.Y + (drawItemInfo.Rct.Height - (int)sizeF2.Height) / 2);
			}
		}

		[Description("Specifies wheter NewStyle-Drawing is enabled or not")]
		[Browsable(false)]
		public bool GetNewStyleActive(System.Windows.Forms.MenuItem control)
		{
			return true;
		}

		public void SetNewStyleActive(System.Windows.Forms.MenuItem control, bool value)
		{
			if (!value)
			{
				if (_menuitems.Contains(control))
				{
					_menuitems.Remove(control);
				}
				control.OwnerDraw = false;
				control.MeasureItem -= control_MeasureItem;
				control.DrawItem -= control_DrawItem;
			}
			else
			{
				if (!_menuitems.Contains(control))
				{
					_menuitems.Add(control, new MenuItemInfo(newstyle: true, null));
				}
				else
				{
					((MenuItemInfo)_menuitems[control]).NewStyle = true;
				}
				control.OwnerDraw = true;
				control.MeasureItem += control_MeasureItem;
				control.DrawItem += control_DrawItem;
			}
		}

		[Description("Specifies the image displayed next to the MenuItem")]
		[DefaultValue(null)]
		public Image GetMenuGlyph(System.Windows.Forms.MenuItem control)
		{
			return ((MenuItemInfo)_menuitems[control])?.Glyph;
		}

		public void SetMenuGlyph(System.Windows.Forms.MenuItem control, Image value)
		{
			if (value == null)
			{
				if (_menuitems.Contains(control))
				{
					((MenuItemInfo)_menuitems[control]).Glyph = null;
					if (!((MenuItemInfo)_menuitems[control]).NewStyle)
					{
						_menuitems.Remove(control);
					}
				}
			}
			else if (!_menuitems.Contains(control))
			{
				_menuitems.Add(control, new MenuItemInfo(newstyle: true, value));
				control.OwnerDraw = true;
				control.MeasureItem += control_MeasureItem;
				control.DrawItem += control_DrawItem;
			}
			else
			{
				((MenuItemInfo)_menuitems[control]).Glyph = value;
			}
		}

		private int OnHookProc(int code, IntPtr wparam, ref Win32.CWPSTRUCT cwp)
		{
			if (code == 0)
			{
				switch (cwp.message)
				{
				case 1:
				{
					StringBuilder stringBuilder = new StringBuilder(64);
					int className = Win32.GetClassName(cwp.hwnd, stringBuilder, stringBuilder.Capacity);
					string strA = stringBuilder.ToString();
					if (string.Compare(strA, "#32768", ignoreCase: false) == 0)
					{
						lastHook = new MenuHook(this, _lastwidth);
						lastHook.AssignHandle(cwp.hwnd);
						_lastwidth = 0;
					}
					break;
				}
				case 2:
					if (cwp.hwnd == _owner.Handle && _hook != IntPtr.Zero)
					{
						Win32.UnhookWindowsHookEx(_hook);
						_hook = IntPtr.Zero;
					}
					break;
				}
			}
			return Win32.CallNextHookEx(_hook, code, wparam, ref cwp);
		}

		private string GetShortcutString(System.Windows.Forms.Keys shortcut)
		{
			return TypeDescriptor.GetConverter(typeof(System.Windows.Forms.Keys)).ConvertToString(shortcut);
		}
	}
}


