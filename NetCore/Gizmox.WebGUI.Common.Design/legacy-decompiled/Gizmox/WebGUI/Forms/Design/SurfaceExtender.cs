using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Gizmox.WebGUI.Client.Design;

namespace Gizmox.WebGUI.Forms.Design;

public class SurfaceExtender : IWindowTarget
{
	public static class NativeMethods
	{
		[StructLayout(LayoutKind.Sequential)]
		public class POINT
		{
			public int x;

			public int y;

			public POINT()
			{
			}

			public POINT(int x, int y)
			{
				this.x = x;
				this.y = y;
			}
		}

		public struct RECT
		{
			public int left;

			public int top;

			public int right;

			public int bottom;

			public Rectangle Rect => new Rectangle(left, top, right - left, bottom - top);

			public RECT(int left, int top, int right, int bottom)
			{
				this.left = left;
				this.top = top;
				this.right = right;
				this.bottom = bottom;
			}

			public static RECT FromXYWH(int x, int y, int width, int height)
			{
				return new RECT(x, y, x + width, y + height);
			}

			public static RECT FromRectangle(Rectangle rect)
			{
				return new RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
			}
		}

		public struct NCCALCSIZE_PARAMS
		{
			public RECT rectProposed;

			public RECT rectBeforeMove;

			public RECT rectClientBeforeMove;

			public WINDOWPOS lpPos;
		}

		public struct WINDOWPOS
		{
			internal IntPtr cd3a9f1de12f221cebf218efd197d2d05;

			internal IntPtr c89385c3df0261ed5842aae312c722d0a;

			internal int ccb866b63ee966525354d6a5258a40799;

			internal int ccac20cfea3f86635ffe12f727a8f6f46;

			internal int cbc5c1c9d536443a090cb29ec095ca59d;

			internal int c3f08bbf5a5e621a886f9801cd47bfd12;

			internal uint c538799f988a954356bece863942f8da9;
		}

		public enum TernaryRasterOperations
		{
			SRCCOPY = 13369376,
			SRCPAINT = 15597702,
			SRCAND = 8913094,
			SRCINVERT = 6684742,
			SRCERASE = 4457256,
			NOTSRCCOPY = 3342344,
			NOTSRCERASE = 1114278,
			MERGECOPY = 12583114,
			MERGEPAINT = 12255782,
			PATCOPY = 15728673,
			PATPAINT = 16452105,
			PATINVERT = 5898313,
			DSTINVERT = 5570569,
			BLACKNESS = 66,
			WHITENESS = 16711778
		}

		[Flags]
		public enum SetWindowPosOptions
		{
			SWP_NOSIZE = 1,
			SWP_NOMOVE = 2,
			SWP_NOZORDER = 4,
			SWP_NOACTIVATE = 0x10,
			SWP_FRAMECHANGED = 0x20,
			SWP_SHOWWINDOW = 0x40,
			SWP_HIDEWINDOW = 0x80,
			SWP_NOCOPYBITS = 0x100,
			SWP_NOOWNERZORDER = 0x200,
			SWP_NOSENDCHANGING = 0x400
		}

		[Flags]
		public enum RedrawWindowOptions
		{
			RDW_INVALIDATE = 1,
			RDW_INTERNALPAINT = 2,
			RDW_ERASE = 4,
			RDW_VALIDATE = 8,
			RDW_NOINTERNALPAINT = 0x10,
			RDW_NOERASE = 0x20,
			RDW_NOCHILDREN = 0x40,
			RDW_ALLCHILDREN = 0x80,
			RDW_UPDATENOW = 0x100,
			RDW_ERASENOW = 0x200,
			RDW_FRAME = 0x400,
			RDW_NOFRAME = 0x800
		}

		[Flags]
		public enum DCX
		{
			DCX_CACHE = 2,
			DCX_CLIPCHILDREN = 8,
			DCX_CLIPSIBLINGS = 0x10,
			DCX_EXCLUDERGN = 0x40,
			DCX_EXCLUDEUPDATE = 0x100,
			DCX_INTERSECTRGN = 0x80,
			DCX_INTERSECTUPDATE = 0x200,
			DCX_LOCKWINDOWUPDATE = 0x400,
			DCX_NORECOMPUTE = 0x100000,
			DCX_NORESETATTRS = 4,
			DCX_PARENTCLIP = 0x20,
			DCX_VALIDATE = 0x200000,
			DCX_WINDOW = 1
		}

		public const int WM_NCCALCSIZE = 131;

		public const int WM_NCPAINT = 133;

		public const int WM_PAINT = 15;

		public const int WM_SIZE = 5;

		public static readonly IntPtr FALSE = new IntPtr(0);

		public static readonly IntPtr TRUE = new IntPtr(1);

		[DllImport("user32.dll")]
		public static extern int GetWindowRect(IntPtr hwnd, ref RECT lpRect);

		[DllImport("user32.dll")]
		public static extern IntPtr GetDCEx(IntPtr hwnd, IntPtr hrgnclip, uint fdwOptions);

		[DllImport("user32.dll")]
		public static extern int ReleaseDC(IntPtr hwnd, IntPtr hDC);

		[DllImport("gdi32.dll")]
		public static extern bool OffsetWindowOrgEx(IntPtr hdc, int nXOffset, int nYOffset, IntPtr lpPoint);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
		public static extern bool SetViewportOrgEx(HandleRef hDC, int x, int y, [In][Out] POINT point);

		[DllImport("user32.dll")]
		public static extern int MapWindowPoints(IntPtr hWndFrom, IntPtr hWndTo, [In][Out] POINT pt, int cPoints);

		[DllImport("user32.dll")]
		public static extern bool RedrawWindow(IntPtr hWnd, IntPtr rectUpdate, IntPtr hrgnUpdate, uint flags);

		[DllImport("user32.dll")]
		public static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndAfter, int x, int y, int cx, int cy, uint uFlags);

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

		[DllImport("user32.dll")]
		public static extern bool PeekMessage(ref Message msg, IntPtr hwnd, int msgMin, int msgMax, int remove);

		[DllImport("user32.dll")]
		public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, int flags);

		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);

		[DllImport("gdi32.dll")]
		public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

		[DllImport("gdi32.dll")]
		public static extern bool BitBlt(IntPtr hObject, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hObjSource, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);

		[DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hObject);

		[DllImport("gdi32.dll")]
		public static extern bool DeleteDC(IntPtr hDC);
	}

	private ScrollableControl cc4425a0b43bba2e65075d89f8a6b270f;

	private Control ce43da2e2e34fd2b2a905334b5dd271cf;

	private IWindowTarget c5b5e0874ed3fe092b899281ef15f6ab7;

	private Padding c4a66fbb37507d324bd131174bae6c17c = new Padding(23, 23, 0, 0);

	private Padding c8deaa54d610688d8ba37088ec1fef70e = new Padding(0);

	private const int cc433f75620ba606b508db6c9a6596d8d = 5;

	private const int c57c761093875899cd1dd9797990004bb = 100;

	private const int c9542915794a7f40c6a043b7605288a03 = 50;

	private const int c60549fb50661538560c2b65561b85b41 = 10;

	private const int c77b15b53345370d1f242ac192b6fbbbe = 4;

	private Pen cdf0f2163474f26b573ff8134f041a52c;

	private Pen c5cc4eeec92d9de1e8ac8cece1fe346cc;

	private Brush c2e481392a27cab900717454b92c83e41;

	private Brush c8aa3f59eb4ebc38b2f5bc391d8b305b7;

	private Brush c1ba5035dccc82f943995f3a3175f4477;

	private Pen cc010fdf9ae4a81d759596cfefc0e64ff;

	private Brush cd41022480c008eecab4b13bc533ba407;

	private Size cff5db691aca51c61d59fcf6372ea4f47;

	private Image cf599f7f66c4c9ed92764c11b4d5dc40d;

	private Image cc1d2732e2c269fa1ee892750fe8a4632;

	private Brush cc49414cbcc6a8045926be8cd25fed2c1;

	private Point c1c4917c50b6787f266cbe4f16d9112a2;

	private string c453984d5f9e430cda21f055a95cd6761;

	private SizeF c87b72ba73ce2ae5ef970ba1bc324345f;

	public Pen TickPen
	{
		get
		{
			if (cdf0f2163474f26b573ff8134f041a52c != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				cdf0f2163474f26b573ff8134f041a52c = new Pen(ColorTranslator.FromHtml("#e9a56f"));
			}
			return cdf0f2163474f26b573ff8134f041a52c;
		}
		set
		{
			if (value != null)
			{
				cdf0f2163474f26b573ff8134f041a52c = value;
			}
		}
	}

	public Pen BordersPen
	{
		get
		{
			if (c5cc4eeec92d9de1e8ac8cece1fe346cc != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c5cc4eeec92d9de1e8ac8cece1fe346cc = new Pen(ColorTranslator.FromHtml("#c1cbd7"));
			}
			return c5cc4eeec92d9de1e8ac8cece1fe346cc;
		}
		set
		{
			if (value == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c5cc4eeec92d9de1e8ac8cece1fe346cc = value;
			}
		}
	}

	public Brush LabelsBrush
	{
		get
		{
			if (c2e481392a27cab900717454b92c83e41 == null)
			{
				c2e481392a27cab900717454b92c83e41 = new SolidBrush(ColorTranslator.FromHtml("#b2662f"));
			}
			return c2e481392a27cab900717454b92c83e41;
		}
		set
		{
			if (value != null)
			{
				c2e481392a27cab900717454b92c83e41 = value;
			}
		}
	}

	public Brush TicksBackgroundBrush
	{
		get
		{
			if (c8aa3f59eb4ebc38b2f5bc391d8b305b7 != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c8aa3f59eb4ebc38b2f5bc391d8b305b7 = new SolidBrush(ColorTranslator.FromHtml("#ffe9d9"));
			}
			return c8aa3f59eb4ebc38b2f5bc391d8b305b7;
		}
		set
		{
			if (value == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c8aa3f59eb4ebc38b2f5bc391d8b305b7 = value;
			}
		}
	}

	public Brush BackgroundBrush
	{
		get
		{
			if (cd41022480c008eecab4b13bc533ba407 == null)
			{
				cd41022480c008eecab4b13bc533ba407 = new SolidBrush(ColorTranslator.FromHtml("#ffe9d9"));
			}
			return cd41022480c008eecab4b13bc533ba407;
		}
		set
		{
			if (value == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				cd41022480c008eecab4b13bc533ba407 = value;
			}
		}
	}

	public Font Font => cc4425a0b43bba2e65075d89f8a6b270f.Font;

	public Brush TickLineBackgroundBrush
	{
		get
		{
			if (c1ba5035dccc82f943995f3a3175f4477 != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c1ba5035dccc82f943995f3a3175f4477 = new SolidBrush(ColorTranslator.FromHtml("#dce5ef"));
			}
			return c1ba5035dccc82f943995f3a3175f4477;
		}
		set
		{
			if (value == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				c1ba5035dccc82f943995f3a3175f4477 = value;
			}
		}
	}

	public Brush DeviceBorderBrush
	{
		get
		{
			if (cc49414cbcc6a8045926be8cd25fed2c1 != null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				cc49414cbcc6a8045926be8cd25fed2c1 = new HatchBrush(HatchStyle.ForwardDiagonal, Color.DarkSlateGray, SystemColors.AppWorkspace);
			}
			return cc49414cbcc6a8045926be8cd25fed2c1;
		}
		set
		{
			if (value == null)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				cc49414cbcc6a8045926be8cd25fed2c1 = value;
			}
		}
	}

	public Pen TickLinePen
	{
		get
		{
			if (cc010fdf9ae4a81d759596cfefc0e64ff == null)
			{
				cc010fdf9ae4a81d759596cfefc0e64ff = new Pen(ColorTranslator.FromHtml("#fbd0ae"));
			}
			return cc010fdf9ae4a81d759596cfefc0e64ff;
		}
		set
		{
			if (value != null)
			{
				cc010fdf9ae4a81d759596cfefc0e64ff = value;
			}
		}
	}

	public IntPtr RulerHandle => ce43da2e2e34fd2b2a905334b5dd271cf.Handle;

	public bool IsDisposed
	{
		get
		{
			if (cc4425a0b43bba2e65075d89f8a6b270f.IsDisposed)
			{
				/*OpCode not supported: LdMemberToken*/;
				return true;
			}
			return ce43da2e2e34fd2b2a905334b5dd271cf.IsDisposed;
		}
	}

	public bool IsHandleCreated => cc4425a0b43bba2e65075d89f8a6b270f.IsHandleCreated;

	public SurfaceExtender(Control objRulerControl, ScrollableControl objCanvasControl, IClientDesignServices objClientDesignServices)
	{
		c5b5e0874ed3fe092b899281ef15f6ab7 = objRulerControl.WindowTarget;
		cc4425a0b43bba2e65075d89f8a6b270f = objCanvasControl;
		cc4425a0b43bba2e65075d89f8a6b270f.Scroll += OnCanvasControlScroll;
		cc4425a0b43bba2e65075d89f8a6b270f.Resize += OnCanvasControlResize;
		cc4425a0b43bba2e65075d89f8a6b270f.VisibleChanged += OnCanvasControlVisibleChanged;
		cc4425a0b43bba2e65075d89f8a6b270f.MouseWheel += mobjCanvasControl_MouseWheel;
		ce43da2e2e34fd2b2a905334b5dd271cf = objRulerControl;
		ce43da2e2e34fd2b2a905334b5dd271cf.Paint += mobjRulerControl_Paint;
		if (objClientDesignServices is DocumentDesigner documentDesigner)
		{
			_ = documentDesigner.WebDesingerHost;
			c453984d5f9e430cda21f055a95cd6761 = objClientDesignServices.GetBrowserId(null);
			if (c453984d5f9e430cda21f055a95cd6761 != null)
			{
				cff5db691aca51c61d59fcf6372ea4f47 = objClientDesignServices.DesignTimeDeviceRepository.GetDesignerSize(objClientDesignServices, c453984d5f9e430cda21f055a95cd6761);
				c87b72ba73ce2ae5ef970ba1bc324345f = objClientDesignServices.GetFormScaleFactor(c453984d5f9e430cda21f055a95cd6761);
				cf599f7f66c4c9ed92764c11b4d5dc40d = objClientDesignServices.DesignTimeDeviceRepository.GetBackgroundImage(objClientDesignServices, c453984d5f9e430cda21f055a95cd6761);
				cc4425a0b43bba2e65075d89f8a6b270f.Paint += objControlSurfaceExtender_Paint;
				objClientDesignServices.DesignTimeDeviceRepository.GetMargin(objClientDesignServices, c453984d5f9e430cda21f055a95cd6761, out var Left, out var Top, out var Right, out var Bottom);
				if (cc4425a0b43bba2e65075d89f8a6b270f.Controls.Count <= 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					if (cf599f7f66c4c9ed92764c11b4d5dc40d != null)
					{
						if (Left > 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (Right > 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (Top > 0)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else if (Bottom <= 0)
						{
							/*OpCode not supported: LdMemberToken*/;
							goto IL_0302;
						}
						c1c4917c50b6787f266cbe4f16d9112a2 = new Point(Left, Top);
						if (c1c4917c50b6787f266cbe4f16d9112a2.IsEmpty)
						{
							/*OpCode not supported: LdMemberToken*/;
						}
						else
						{
							cc4425a0b43bba2e65075d89f8a6b270f.Controls[0].Location = c1c4917c50b6787f266cbe4f16d9112a2;
						}
						Size newSize = new Size(Left + Right + cff5db691aca51c61d59fcf6372ea4f47.Width, Top + Bottom + cff5db691aca51c61d59fcf6372ea4f47.Height);
						Bitmap bitmap = null;
						if (!newSize.IsEmpty)
						{
							/*OpCode not supported: LdMemberToken*/;
							bitmap = new Bitmap(cf599f7f66c4c9ed92764c11b4d5dc40d, newSize);
						}
						else
						{
							bitmap = new Bitmap(cf599f7f66c4c9ed92764c11b4d5dc40d);
							newSize = bitmap.Size;
						}
						Rectangle rect = new Rectangle(c1c4917c50b6787f266cbe4f16d9112a2.X, c1c4917c50b6787f266cbe4f16d9112a2.Y, cff5db691aca51c61d59fcf6372ea4f47.Width, cff5db691aca51c61d59fcf6372ea4f47.Height);
						Graphics.FromImage(bitmap).FillRectangle(new SolidBrush(Color.FromArgb(0, 255, 0)), rect);
						bitmap.MakeTransparent(Color.FromArgb(0, 255, 0));
						cf599f7f66c4c9ed92764c11b4d5dc40d = bitmap;
						goto IL_0309;
					}
					/*OpCode not supported: LdMemberToken*/;
				}
				goto IL_0302;
			}
			/*OpCode not supported: LdMemberToken*/;
		}
		goto IL_0309;
		IL_0309:
		InvalidateNonClientArea(blnForceResize: true);
		return;
		IL_0302:
		cf599f7f66c4c9ed92764c11b4d5dc40d = null;
		goto IL_0309;
	}

	private void objControlSurfaceExtender_Paint(object sender, PaintEventArgs e)
	{
		InvalidateNonClientArea(blnForceResize: false);
	}

	private void mobjCanvasControl_MouseWheel(object sender, MouseEventArgs e)
	{
		InvalidateNonClientArea(blnForceResize: false);
	}

	private void mobjRulerControl_Paint(object sender, PaintEventArgs e)
	{
		InvalidateNonClientArea(blnForceResize: false);
	}

	private void OnCanvasControlVisibleChanged(object sender, EventArgs e)
	{
		InvalidateNonClientArea(blnForceResize: false);
	}

	private void InvalidateNonClientArea(bool blnForceResize)
	{
		if (IsDisposed)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else if (IsHandleCreated)
		{
			if (!cc4425a0b43bba2e65075d89f8a6b270f.Visible)
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				NativeMethods.SetWindowPos(RulerHandle, IntPtr.Zero, 0, 0, 0, 0, 567);
			}
		}
	}

	private void OnCanvasControlScroll(object sender, ScrollEventArgs e)
	{
		InvalidateNonClientArea(blnForceResize: false);
	}

	private void OnCanvasControlResize(object sender, EventArgs e)
	{
		InvalidateNonClientArea(blnForceResize: false);
	}

	private void DrawSide(Graphics objGraphics, Rectangle objRectangle)
	{
		DrawRuler(objGraphics, objRectangle, Orientation.Vertical, cc4425a0b43bba2e65075d89f8a6b270f.VerticalScroll.Value);
	}

	private void DrawTop(Graphics objGraphics, Rectangle objRectangle)
	{
		DrawRuler(objGraphics, objRectangle, Orientation.Horizontal, cc4425a0b43bba2e65075d89f8a6b270f.HorizontalScroll.Value);
	}

	private void DrawCorner(Graphics objGraphics, Rectangle objRectangle)
	{
		objGraphics.FillRectangle(new SolidBrush(Color.Red), objRectangle);
		int width = objRectangle.Width;
		int height = objRectangle.Height;
		int left = objRectangle.Left;
		int top = objRectangle.Top;
		objGraphics.FillRectangle(BackgroundBrush, left, top, width, height);
		objGraphics.DrawLine(TickPen, width - 1, top, width - 1, height - 1);
		objGraphics.DrawLine(TickPen, left, height - 1, width - 1, height - 1);
		if (cc1d2732e2c269fa1ee892750fe8a4632 != null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			cc1d2732e2c269fa1ee892750fe8a4632 = Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("Gizmox.WebGUI.Common.Design.Resources.Images.VWGFormLogo.png"));
		}
		objGraphics.DrawImage(cc1d2732e2c269fa1ee892750fe8a4632, 0, 0, 23, 23);
	}

	private void DrawRuler(Graphics objGraphics, Rectangle objRectangle, Orientation enmOrientation, int intOffset)
	{
		int width = objRectangle.Width;
		int height = objRectangle.Height;
		int left = objRectangle.Left;
		int right = objRectangle.Right;
		int top = objRectangle.Top;
		int bottom = objRectangle.Bottom;
		if (enmOrientation != Orientation.Horizontal)
		{
			/*OpCode not supported: LdMemberToken*/;
			objGraphics.FillRectangle(TicksBackgroundBrush, left, top, width - 4, height);
			objGraphics.FillRectangle(TickLineBackgroundBrush, width - 4, top, width, height);
			int num = ((!c1c4917c50b6787f266cbe4f16d9112a2.IsEmpty) ? c1c4917c50b6787f266cbe4f16d9112a2.Y : 0);
			for (int i = Math.Max(1, num - intOffset); i < height; i++)
			{
				/*OpCode not supported: LdMemberToken*/;
				int num2 = intOffset + i - num;
				if (num2 % 100 == 0)
				{
					objGraphics.DrawLine(TickPen, new Point(0, i + top), new Point(width - 4, i + top));
				}
				else if (num2 % 50 != 0)
				{
					/*OpCode not supported: LdMemberToken*/;
					if (num2 % 10 != 0)
					{
						/*OpCode not supported: LdMemberToken*/;
					}
					else
					{
						objGraphics.DrawLine(TickPen, new Point(width - 4 - 4, i + top), new Point(width - 4, i + top));
					}
				}
				else
				{
					objGraphics.DrawLine(TickPen, new Point(width - 10 - 4, i + top), new Point(width - 4, i + top));
				}
			}
			float num3;
			if (c87b72ba73ce2ae5ef970ba1bc324345f.IsEmpty)
			{
				/*OpCode not supported: LdMemberToken*/;
				num3 = 1f;
			}
			else
			{
				num3 = c87b72ba73ce2ae5ef970ba1bc324345f.Height;
			}
			int num4 = (int)(100f / num3);
			for (int j = num; j < height + 100; j += 100)
			{
				/*OpCode not supported: LdMemberToken*/;
				float num5 = intOffset + j - num;
				float num6;
				if (c87b72ba73ce2ae5ef970ba1bc324345f.IsEmpty)
				{
					/*OpCode not supported: LdMemberToken*/;
					num6 = 1f;
				}
				else
				{
					num6 = c87b72ba73ce2ae5ef970ba1bc324345f.Height;
				}
				int num7 = (int)(num5 / num6);
				StringFormat stringFormat = new StringFormat();
				stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
				objGraphics.DrawString((num7 / num4 * num4).ToString(), Font, LabelsBrush, new PointF(-2f, j + top + 2 - intOffset % 100), stringFormat);
			}
			objGraphics.DrawLine(TickLinePen, new Point(width - 4, top), new Point(width - 4, bottom));
			objGraphics.DrawLine(BordersPen, new Point(width - 1, objRectangle.Top), new Point(width - 1, bottom));
			return;
		}
		objGraphics.FillRectangle(TicksBackgroundBrush, left, 0, width, height - 4);
		objGraphics.FillRectangle(TickLineBackgroundBrush, left, height - 4, width, height);
		int num8 = ((!c1c4917c50b6787f266cbe4f16d9112a2.IsEmpty) ? c1c4917c50b6787f266cbe4f16d9112a2.X : 0);
		for (int k = Math.Max(1, num8 - intOffset); k < width; k++)
		{
			/*OpCode not supported: LdMemberToken*/;
			int num9 = intOffset + k - num8;
			if (num9 % 100 != 0)
			{
				/*OpCode not supported: LdMemberToken*/;
				if (num9 % 50 == 0)
				{
					objGraphics.DrawLine(TickPen, new Point(k + left, height - 10 - 4), new Point(k + left, height - 4));
				}
				else if (num9 % 10 != 0)
				{
					/*OpCode not supported: LdMemberToken*/;
				}
				else
				{
					objGraphics.DrawLine(TickPen, new Point(k + left, height - 4 - 4), new Point(k + left, height - 4));
				}
			}
			else
			{
				objGraphics.DrawLine(TickPen, new Point(k + left, 0), new Point(k + left, height - 4));
			}
		}
		int num10 = (int)(100f / (c87b72ba73ce2ae5ef970ba1bc324345f.IsEmpty ? 1f : c87b72ba73ce2ae5ef970ba1bc324345f.Width));
		for (int l = num8; l < width + 100; l += 100)
		{
			/*OpCode not supported: LdMemberToken*/;
			int num11 = (int)((float)(intOffset + l - num8) / (c87b72ba73ce2ae5ef970ba1bc324345f.IsEmpty ? 1f : c87b72ba73ce2ae5ef970ba1bc324345f.Width));
			objGraphics.DrawString((num11 / num10 * num10).ToString(), Font, LabelsBrush, new PointF(l + left + 2 - intOffset % 100, 2f));
		}
		objGraphics.DrawLine(TickLinePen, new Point(left, height - 4), new Point(right, height - 4));
		objGraphics.DrawLine(BordersPen, new Point(objRectangle.Left, height - 1), new Point(right, height - 1));
	}

	private void DrawDeviceSizeMark(Graphics objGraphics, Rectangle objRectangle)
	{
		if (!cff5db691aca51c61d59fcf6372ea4f47.IsEmpty)
		{
			int num = -cc4425a0b43bba2e65075d89f8a6b270f.HorizontalScroll.Value;
			int num2 = -cc4425a0b43bba2e65075d89f8a6b270f.VerticalScroll.Value;
			objGraphics.DrawLine(new Pen(DeviceBorderBrush, 3f), new Point(0, cff5db691aca51c61d59fcf6372ea4f47.Height + num2), new Point(cff5db691aca51c61d59fcf6372ea4f47.Width + num, cff5db691aca51c61d59fcf6372ea4f47.Height + num2));
			objGraphics.DrawLine(new Pen(DeviceBorderBrush, 3f), new Point(cff5db691aca51c61d59fcf6372ea4f47.Width + num, 0), new Point(cff5db691aca51c61d59fcf6372ea4f47.Width + num, cff5db691aca51c61d59fcf6372ea4f47.Height + num2));
			objGraphics.DrawString(c453984d5f9e430cda21f055a95cd6761, Font, LabelsBrush, new Point(num + 3, cff5db691aca51c61d59fcf6372ea4f47.Height + num2 + 3));
		}
	}

	private void DrawDeviceBackgroundImage(Graphics objGraphics, Rectangle objRectangle)
	{
		if (cf599f7f66c4c9ed92764c11b4d5dc40d == null)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		int x = -cc4425a0b43bba2e65075d89f8a6b270f.HorizontalScroll.Value;
		int y = -cc4425a0b43bba2e65075d89f8a6b270f.VerticalScroll.Value;
		objGraphics.DrawImage(cf599f7f66c4c9ed92764c11b4d5dc40d, new Point(x, y));
	}

	private void AdjustNonClientArea(ref Rectangle objProposedRect)
	{
		objProposedRect = new Rectangle(objProposedRect.X + c4a66fbb37507d324bd131174bae6c17c.Left, objProposedRect.Y + c4a66fbb37507d324bd131174bae6c17c.Top, Math.Max(0, objProposedRect.Width - c4a66fbb37507d324bd131174bae6c17c.Left - c4a66fbb37507d324bd131174bae6c17c.Right), Math.Max(0, objProposedRect.Height - c4a66fbb37507d324bd131174bae6c17c.Top - c4a66fbb37507d324bd131174bae6c17c.Bottom));
	}

	private void DrawNonClientAreaPaint(Graphics objGraphics, Padding objPadding, Size objSize)
	{
		DrawTop(objGraphics, new Rectangle(objPadding.Left + c4a66fbb37507d324bd131174bae6c17c.Left, objPadding.Top, Math.Max(0, objSize.Width - c4a66fbb37507d324bd131174bae6c17c.Left - objPadding.Left * 2), c4a66fbb37507d324bd131174bae6c17c.Top));
		DrawSide(objGraphics, new Rectangle(objPadding.Left, objPadding.Top + c4a66fbb37507d324bd131174bae6c17c.Top, c4a66fbb37507d324bd131174bae6c17c.Left, Math.Max(0, objSize.Height - c4a66fbb37507d324bd131174bae6c17c.Top - objPadding.Top * 2)));
		DrawCorner(objGraphics, new Rectangle(objPadding.Left, objPadding.Top, c4a66fbb37507d324bd131174bae6c17c.Left, c4a66fbb37507d324bd131174bae6c17c.Top));
	}

	private void DrawDeviceArea(Graphics objGraphics, Padding objPadding, Size objSize)
	{
		if (cf599f7f66c4c9ed92764c11b4d5dc40d != null)
		{
			/*OpCode not supported: LdMemberToken*/;
			DrawDeviceBackgroundImage(objGraphics, new Rectangle(0, 0, objSize.Width, objSize.Height));
		}
		else
		{
			DrawDeviceSizeMark(objGraphics, new Rectangle(0, 0, objSize.Width, objSize.Height));
		}
	}

	void IWindowTarget.OnHandleChange(IntPtr newHandle)
	{
		c5b5e0874ed3fe092b899281ef15f6ab7.OnHandleChange(newHandle);
	}

	void IWindowTarget.OnMessage(ref Message m)
	{
		WndProc(ref m);
	}

	protected virtual void WndProc(ref Message m)
	{
		if (m.Msg != 131)
		{
			/*OpCode not supported: LdMemberToken*/;
			if (m.Msg != 133)
			{
				/*OpCode not supported: LdMemberToken*/;
				c5b5e0874ed3fe092b899281ef15f6ab7.OnMessage(ref m);
			}
			else
			{
				WmNCPaint(ref m);
				c5b5e0874ed3fe092b899281ef15f6ab7.OnMessage(ref m);
			}
		}
		else
		{
			WmNCCalcSize(ref m);
			Rectangle rectangle = WmNCGetSize(ref m);
			c5b5e0874ed3fe092b899281ef15f6ab7.OnMessage(ref m);
			Rectangle rectangle2 = WmNCGetSize(ref m);
			c8deaa54d610688d8ba37088ec1fef70e = new Padding(rectangle2.Left - rectangle.Left, rectangle2.Top - rectangle.Top, rectangle.Right - rectangle2.Right, rectangle.Bottom - rectangle2.Bottom);
			IntPtr zero = IntPtr.Zero;
			NativeMethods.OffsetWindowOrgEx(m.HWnd, 23, 23, zero);
		}
	}

	private void WmNCPaint(ref Message msg)
	{
		PaintNonClientArea(msg.HWnd, msg.WParam);
		if (c453984d5f9e430cda21f055a95cd6761 == null)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			PaintDeviceArea(msg.HWnd, msg.WParam);
		}
		msg.Result = NativeMethods.TRUE;
	}

	private void PaintNonClientArea(IntPtr hWnd, IntPtr hRgn)
	{
		if (!IsHandleCreated)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		NativeMethods.RECT lpRect = default(NativeMethods.RECT);
		if (NativeMethods.GetWindowRect(hWnd, ref lpRect) == 0)
		{
			return;
		}
		Rectangle rectangle = new Rectangle(0, 0, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top);
		if (rectangle.Width == 0)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			if (rectangle.Height == 0)
			{
				return;
			}
			if (!(hRgn != (IntPtr)1))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Region.FromHrgn(hRgn);
			}
			IntPtr dCEx = NativeMethods.GetDCEx(hWnd, hRgn, 147u);
			if (dCEx != IntPtr.Zero)
			{
				try
				{
					IntPtr intPtr = NativeMethods.CreateCompatibleDC(dCEx);
					IntPtr hObject = NativeMethods.CreateCompatibleBitmap(dCEx, rectangle.Width, rectangle.Height);
					try
					{
						NativeMethods.SelectObject(intPtr, hObject);
						NativeMethods.BitBlt(intPtr, 0, 0, rectangle.Width, rectangle.Height, dCEx, 0, 0, NativeMethods.TernaryRasterOperations.SRCCOPY);
						Graphics graphics = Graphics.FromHdc(intPtr);
						try
						{
							DrawNonClientAreaPaint(graphics, c8deaa54d610688d8ba37088ec1fef70e, rectangle.Size);
						}
						finally
						{
							if (graphics == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								((IDisposable)graphics).Dispose();
							}
						}
						NativeMethods.BitBlt(dCEx, 0, 0, rectangle.Width, rectangle.Height, intPtr, 0, 0, NativeMethods.TernaryRasterOperations.SRCCOPY);
						return;
					}
					finally
					{
						NativeMethods.DeleteObject(hObject);
						NativeMethods.DeleteDC(intPtr);
					}
				}
				catch
				{
					return;
				}
			}
			/*OpCode not supported: LdMemberToken*/;
		}
	}

	private void PaintDeviceArea(IntPtr hWnd, IntPtr hRgn)
	{
		if (!IsHandleCreated)
		{
			/*OpCode not supported: LdMemberToken*/;
			return;
		}
		NativeMethods.RECT lpRect = default(NativeMethods.RECT);
		if (NativeMethods.GetWindowRect(hWnd, ref lpRect) == 0)
		{
			return;
		}
		/*OpCode not supported: LdMemberToken*/;
		Rectangle rectangle = new Rectangle(0, 0, lpRect.right - lpRect.left, lpRect.bottom - lpRect.top);
		if (rectangle.Width == 0)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			if (rectangle.Height == 0)
			{
				return;
			}
			/*OpCode not supported: LdMemberToken*/;
			if (!(hRgn != (IntPtr)1))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				Region.FromHrgn(hRgn);
			}
			IntPtr dCEx = NativeMethods.GetDCEx(hWnd, hRgn, 18u);
			if (dCEx != IntPtr.Zero)
			{
				try
				{
					IntPtr intPtr = NativeMethods.CreateCompatibleDC(dCEx);
					IntPtr hObject = NativeMethods.CreateCompatibleBitmap(dCEx, rectangle.Width, rectangle.Height);
					try
					{
						NativeMethods.SelectObject(intPtr, hObject);
						NativeMethods.BitBlt(intPtr, 0, 0, rectangle.Width, rectangle.Height, dCEx, 0, 0, NativeMethods.TernaryRasterOperations.SRCCOPY);
						Graphics graphics = Graphics.FromHdc(intPtr);
						try
						{
							DrawDeviceArea(graphics, c8deaa54d610688d8ba37088ec1fef70e, rectangle.Size);
						}
						finally
						{
							if (graphics == null)
							{
								/*OpCode not supported: LdMemberToken*/;
							}
							else
							{
								((IDisposable)graphics).Dispose();
							}
						}
						NativeMethods.BitBlt(dCEx, 0, 0, rectangle.Width, rectangle.Height, intPtr, 0, 0, NativeMethods.TernaryRasterOperations.SRCCOPY);
						return;
					}
					finally
					{
						NativeMethods.DeleteObject(hObject);
						NativeMethods.DeleteDC(intPtr);
					}
				}
				catch
				{
					return;
				}
			}
			/*OpCode not supported: LdMemberToken*/;
		}
	}

	private Rectangle WmNCGetSize(ref Message m)
	{
		if (!(m.WParam == NativeMethods.FALSE))
		{
			/*OpCode not supported: LdMemberToken*/;
			if (!(m.WParam == NativeMethods.TRUE))
			{
				/*OpCode not supported: LdMemberToken*/;
				return Rectangle.Empty;
			}
			return ((NativeMethods.NCCALCSIZE_PARAMS)m.GetLParam(typeof(NativeMethods.NCCALCSIZE_PARAMS))).rectProposed.Rect;
		}
		return ((NativeMethods.RECT)m.GetLParam(typeof(NativeMethods.RECT))).Rect;
	}

	private void WmNCCalcSize(ref Message m)
	{
		if (!(m.WParam == NativeMethods.FALSE))
		{
			/*OpCode not supported: LdMemberToken*/;
			if (!(m.WParam == NativeMethods.TRUE))
			{
				/*OpCode not supported: LdMemberToken*/;
			}
			else
			{
				NativeMethods.NCCALCSIZE_PARAMS structure = (NativeMethods.NCCALCSIZE_PARAMS)m.GetLParam(typeof(NativeMethods.NCCALCSIZE_PARAMS));
				Rectangle objProposedRect = structure.rectProposed.Rect;
				AdjustNonClientArea(ref objProposedRect);
				structure.rectProposed = NativeMethods.RECT.FromRectangle(objProposedRect);
				Marshal.StructureToPtr(structure, m.LParam, fDeleteOld: false);
			}
		}
		else
		{
			Rectangle objProposedRect2 = ((NativeMethods.RECT)m.GetLParam(typeof(NativeMethods.RECT))).Rect;
			AdjustNonClientArea(ref objProposedRect2);
			NativeMethods.RECT structure2 = NativeMethods.RECT.FromRectangle(objProposedRect2);
			Marshal.StructureToPtr(structure2, m.LParam, fDeleteOld: false);
		}
		m.Result = IntPtr.Zero;
	}

	internal static Control AddSurface(Control objDesignerFrame, IClientDesignServices objContext)
	{
		ScrollableControl scrollableControl = GetOverlayFromSurface(objDesignerFrame) as ScrollableControl;
		if (scrollableControl.Controls.Count <= 0)
		{
			/*OpCode not supported: LdMemberToken*/;
		}
		else
		{
			scrollableControl.Controls[0].Location = new Point(0, 0);
		}
		objDesignerFrame.WindowTarget = new SurfaceExtender(objDesignerFrame, scrollableControl, objContext);
		scrollableControl.BackColor = ColorTranslator.FromHtml("#fff6f0");
		return objDesignerFrame;
	}

	private static Control GetOverlayFromSurface(Control objDesignerFrame)
	{
		return objDesignerFrame.Controls[0];
	}
}
