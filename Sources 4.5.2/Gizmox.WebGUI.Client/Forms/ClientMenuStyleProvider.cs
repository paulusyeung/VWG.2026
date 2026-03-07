using System;
using System.ComponentModel;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Gizmox.WebGUI.Client.Forms
{
	


		/// <summary>
		/// Provides all MenuItems the appearance of Office 2003 MenuItems
		/// </summary>
		[ProvideProperty("NewStyleActive",typeof(MenuItem))]
		[ProvideProperty("MenuGlyph",typeof(MenuItem))]
		[ToolboxBitmap(typeof(ClientMenuStyleProvider),"images.ClientMenuStyleProvider.bmp")]
		
	internal class ClientMenuStyleProvider : Component,IExtenderProvider 
		{
			#region types
			/// <summary>
			/// Used to store the provided properties in the Hashtable
			/// </summary>
			
	internal class MenuItemInfo
			{
				/// <summary>
				/// Creates a new MenuItemInfo struct
				/// </summary>
				/// <param name="newstyle">specifies if the MenuItem should be painted using Office 2003 style or not</param>
				/// <param name="glyph">the image to draw next to the MenuItem</param>
				public MenuItemInfo(bool newstyle, Image glyph)
				{
					this.NewStyle=newstyle;
					this.Glyph=glyph;
				}
				//Fields
				public bool NewStyle;
				public Image Glyph;
			}
			/// <summary>
			/// Used to collect the information for drawing an Item
			/// </summary>
			
	internal class DrawItemInfo
			{
				/// <summary>
				/// Creates a new DawItemInfo struct
				/// </summary>
				/// <param name="sender">reference to the MenuItem to be painted</param>
				/// <param name="e">the DrawItemEventArgs with additional information</param>
				/// <param name="glyph">the image to draw next to the item</param>
				public DrawItemInfo(object sender, DrawItemEventArgs e, Image glyph)
				{
					this.Item=(MenuItem)sender;
					this.Glyph=glyph;

					this.Disabled=(e.State&DrawItemState.Disabled)==DrawItemState.Disabled;
					this.Selected=(e.State&DrawItemState.Selected)==DrawItemState.Selected;
					this.Checked=(e.State&DrawItemState.Checked)==DrawItemState.Checked;
					this.HotLight=(e.State&DrawItemState.HotLight)==DrawItemState.HotLight;
					this.Rct=e.Bounds;
				}
				/// <summary>
				/// Evaluates, whether the currently drawn
				/// item is an Item in the Top-band of a MainMenu, or not
				/// </summary>
				public bool IsTopItem
				{
					get{return Item.Parent==Item.Parent.GetMainMenu();}
				}
				/// <summary>
				/// Gets the associated MainMenu, if possible
				/// </summary>
				public MainMenu MainMenu
				{
					get{return Item.Parent.GetMainMenu();}
				}
				//Fields
				public Image Glyph;
				public bool HotLight, Selected, Disabled, Checked;
				public Rectangle Rct;
				public MenuItem Item;
			}
			#endregion
			#region variables
			private Container components;//required for designer
			private Hashtable _menuitems;//stores the associated menuitems
			private Form _owner=null;//the owning form, used for hooking
			private IntPtr _hook=IntPtr.Zero;//hook handle
			private Win32.HookProc _hookprc=null;//hook delegate
			private MenuHook lastHook=null;//reference to last MenuHook

			private StringFormat fmt=new StringFormat();//used for painting
			private Size _marginSize=new Size(23,22);//size of the image-band next to each item
			private int _lastwidth=0;//width of the last TopItem
			private LinearGradientBrush 
				lnbrs=new LinearGradientBrush(new Point(0,0),new Point(1,0),
				Color.Black,Color.White);//used for every kind of gradient filling

			private Pen border=new Pen(Color.Black);//used for boder/selectionframe painting
			private SolidBrush hotbrs=new SolidBrush(Color.White);//used for every kind of plain filling

			private Color[][] _cols=new Color[][]//color collection
		{
			new Color[]{Color.FromArgb(227,239,255),Color.FromArgb(203,225,252), Color.FromArgb(135,173,228)},//image band
			new Color[]{Color.FromArgb(195,218,249),Color.FromArgb(158,190,245)},//mainmenu band
			new Color[]{Color.FromArgb(255,238,194),Color.FromArgb(255,214,154)},//selection/hotlight
			new Color[]{Color.FromArgb(246,246,246),Color.FromArgb(0  ,0  ,128)}//menu background/border
		};
			private ColorBlend[] _blends=new ColorBlend[2];
			#endregion
			/// <summary>
			/// ctor
			/// </summary>
			public ClientMenuStyleProvider() 
			{
				this.components = new System.ComponentModel.Container ();
				_menuitems = new Hashtable();
				fmt.HotkeyPrefix=System.Drawing.Text.HotkeyPrefix.Show;
				#region colorblends
				_blends[0] = new ColorBlend();
				_blends[0].Positions=new float[]{0f,1f};
				_blends[0].Colors=_cols[1];
				_blends[1]=new ColorBlend();
				_blends[1].Positions = new float[]{0F,0.5F,1F};
				_blends[1].Colors = _cols[0];
				#endregion
			}
			/// <summary>
			/// Free all used resources
			/// </summary>
			/// <param name="disposing">specifies, if managed resources are destroyed</param>
			protected override void Dispose(bool disposing) 
			{
				if (disposing) 
				{
					if (components != null) 
					{
						components.Dispose();
					}
				}
				base.Dispose(disposing);
			}
			#region controller
			/// <summary>
			/// Can only extend MenuItems
			/// </summary>
			bool IExtenderProvider.CanExtend(object target) 
			{
				return target is MenuItem;
			}
			/// <summary>
			/// Used for making sure, the owning form is hooked
			/// </summary>
			public override ISite Site
			{
				get{return base.Site;}
				set
				{
					base.Site = value;
					if (this.Site != null)
					{
						IDesignerHost host1 = (IDesignerHost) this.Site.GetService(typeof(IDesignerHost));
						if ((host1 != null) && (host1.RootComponent is Form))
						{
							this.OwnerForm = (Form) host1.RootComponent;
						}
					}
				}
			}
			/// <summary>
			/// Measures the item
			/// </summary>
			private void control_MeasureItem(object sender, MeasureItemEventArgs e)
			{
				MenuItem mnu=(MenuItem)sender;

				if (mnu.Text=="-"){e.ItemHeight=3; return;}//MenuItem is Separator

				string txt=mnu.Text.Replace(@"&","");//dont measure '&' because it is replaced by an underline segment
			
				if (mnu.Shortcut!=Shortcut.None && mnu.ShowShortcut)
					txt+=GetShortcutString((Keys)mnu.Shortcut);//Get MenuShortcut, if visible

				int twidth=(int)e.Graphics.MeasureString(txt,mnu.DefaultItem?//Measure the string
					new Font(SystemInformation.MenuFont,FontStyle.Bold)//if the item is the DefaultItem, BOLD Font is used
					:SystemInformation.MenuFont
					,PointF.Empty,fmt).Width;

				if(mnu.Parent==mnu.Parent.GetMainMenu())//Item is in Top-Band of a MainMenu
				{
					e.ItemHeight=16;
					e.ItemWidth=twidth+2;
				}
				else//item is in a context/popup menu
				{
					e.ItemHeight=_marginSize.Height;
					e.ItemWidth=twidth+45+_marginSize.Width;
				}
			}
			/// <summary>
			/// Draw The Item
			/// </summary>
			private void control_DrawItem(object sender, DrawItemEventArgs e)
			{
				//collect the information used for drawing
				DrawItemInfo inf=new DrawItemInfo(sender,e,
					GetMenuGlyph((MenuItem)sender));
				border.Color=_cols[3][1];//use border color

				if (inf.IsTopItem)//draw TopItem
				{
					#region draw Band
					Form frm=inf.MainMenu.GetForm();//owning form

					int width=frm.ClientSize.Width+//width of the MainMenu + Width of one Form Border
						(frm.Width-frm.ClientSize.Width)/2;
					_blends[0].Colors=_cols[1];//use Band colors
					lnbrs.InterpolationColors=_blends[0];

					lnbrs.Transform=new Matrix(-(float)width,0f,0f,1f,0f,0f);//scale the brush to the band

					if (e.Index>=inf.MainMenu.MenuItems.Count-1 ||
						inf.MainMenu.MenuItems[e.Index+1].BarBreak)//item is last in line, draw the rest, too
						e.Graphics.FillRectangle(lnbrs,
							inf.Rct.X,inf.Rct.Y,width-inf.Rct.X,inf.Rct.Height);
					else//item is in line, just draw itself
						e.Graphics.FillRectangle(lnbrs,inf.Rct);
					#endregion
					#region layout
					//set the lastwidth field
					_lastwidth=0; if (inf.Selected) _lastwidth=e.Bounds.Width;
					#endregion
					#region draw TopItem
					inf.Rct.Width--;inf.Rct.Height--;//resize bounds

					lnbrs.Transform=new Matrix(0f,inf.Rct.Height+1,1f,0f,0f,inf.Rct.Y);//scale brush
				
					if (inf.Selected && !inf.Item.IsParent)//if the item has no subitems,
						inf.HotLight=true;//unfolding tab appearance is wrong, use hotlight appearance instead
				
					if (inf.HotLight && !inf.Disabled)//hot light appearance
					{
						_blends[0].Colors=_cols[2];
						lnbrs.InterpolationColors=_blends[0];//use hotlight colors

						e.Graphics.FillRectangle(lnbrs,inf.Rct);//draw the background

						e.Graphics.DrawRectangle(border,inf.Rct);//draw the border
					}
					else if (inf.Selected && !inf.Disabled)//unfolding tab appearance
					{
						_blends[1].Colors=_cols[0];
						lnbrs.InterpolationColors=_blends[1];//use band colors

						e.Graphics.FillRectangle(lnbrs,inf.Rct);//draw the background

						e.Graphics.DrawLines(border, new Point[]//draw a bottom-open rectangle
						{
							new Point(inf.Rct.X,inf.Rct.Bottom),
							new Point(inf.Rct.X,inf.Rct.Y),
							new Point(inf.Rct.Right,inf.Rct.Y),
							new Point(inf.Rct.Right,inf.Rct.Bottom)
						});
					}
					if (inf.Item.Text!="")//draw the text, no shortcut
					{
						SizeF sz;
						sz=e.Graphics.MeasureString(inf.Item.Text.Replace(@"&",""),//use no DefaultItem property
							e.Font);

						e.Graphics.DrawString(inf.Item.Text,e.Font,//draw the text
							inf.Disabled?Brushes.Gray:Brushes.Black,//grayed if the Item is disabled
							inf.Rct.X+(inf.Rct.Width-(int)sz.Width)/2,
							inf.Rct.Y+(inf.Rct.Height-(int)sz.Height)/2,fmt);
					}
					#endregion
				}
				else
				{
					#region draw background, margin and selection
					_blends[1].Colors=_cols[0];//use band colors
					lnbrs.InterpolationColors=_blends[1];

					lnbrs.Transform=new Matrix(_marginSize.Width,0f,0f,1f,inf.Rct.X-1f,0f);//scale the brush

					e.Graphics.FillRectangle(lnbrs,
						inf.Rct.X,inf.Rct.Y,
						_marginSize.Width,inf.Rct.Height);//draw the band

					hotbrs.Color=_cols[3][0];
					e.Graphics.FillRectangle(hotbrs,
						inf.Rct.X+_marginSize.Width,inf.Rct.Y,//fill the backspace white
						inf.Rct.Width-_marginSize.Width,inf.Rct.Height);
				
					if (inf.Item.Text=="-")//Item is a Separator
					{
						border.Color=_cols[0][2];
						e.Graphics.DrawLine(border,//use the dark band color
							inf.Rct.X+_marginSize.Width+2,inf.Rct.Y+inf.Rct.Height/2,
							inf.Rct.Right,inf.Rct.Y+inf.Rct.Height/2);
						return;
					}
					if (inf.Selected && !inf.Disabled)//item is hotlighted
					{
						hotbrs.Color=_cols[2][0];//use hotlight color

						e.Graphics.FillRectangle(hotbrs,//fill the background
							inf.Rct.X,inf.Rct.Y,inf.Rct.Width-1,inf.Rct.Height-1);

						e.Graphics.DrawRectangle(border,//draw the border
							inf.Rct.X,inf.Rct.Y,inf.Rct.Width-1,inf.Rct.Height-1);
					}
					#endregion
					#region draw chevron
					if (inf.Checked)//item is checked
					{
						int mx=_marginSize.Width/2,
							my=_marginSize.Height/2;
						hotbrs.Color=_cols[2][1];//use dark hot color

						e.Graphics.FillRectangle(hotbrs,//fill the background rect
							inf.Rct.X+1,inf.Rct.Y+1,_marginSize.Width-4,_marginSize.Height-3);
						e.Graphics.DrawRectangle(border,//draw the border
							inf.Rct.X+1,inf.Rct.Y+1,_marginSize.Width-4,_marginSize.Height-3);

						if (inf.Glyph==null)//if there is an image, no chevron will be drawed
						{
							e.Graphics.PixelOffsetMode=PixelOffsetMode.HighQuality;
							if (!inf.Item.RadioCheck)//draw an check arrow
							{
								e.Graphics.FillPolygon(Brushes.Black,new Point[]
								{
									new Point(inf.Rct.X+mx-4,inf.Rct.Y+my+1),
									new Point(inf.Rct.X+mx-1,inf.Rct.Y+my+3),
									new Point(inf.Rct.X+mx+3,inf.Rct.Y+my-1),

									new Point(inf.Rct.X+mx+3,inf.Rct.Y+my-3),
									new Point(inf.Rct.X+mx-1,inf.Rct.Y+my+1),
									new Point(inf.Rct.X+mx-4,inf.Rct.Y+my-1)

								});
							}
							else//draw a circle
							{
								e.Graphics.SmoothingMode=SmoothingMode.AntiAlias;//for a smooth form
								e.Graphics.FillEllipse(Brushes.Black,
									inf.Rct.X+mx-4,inf.Rct.Y+my-4,7,7);
							}
							e.Graphics.SmoothingMode=SmoothingMode.Default;
						}
					}
					#endregion
					#region draw image
					if (inf.Glyph!=null)
					{
						if (!inf.Disabled)//draw image grayed
							e.Graphics.DrawImageUnscaled(inf.Glyph,
								inf.Rct.X+(_marginSize.Width-inf.Glyph.Width)/2,
								inf.Rct.Y+(_marginSize.Height-inf.Glyph.Height)/2);
						else
							ControlPaint.DrawImageDisabled(e.Graphics,inf.Glyph,
								inf.Rct.X+(_marginSize.Width-inf.Glyph.Width)/2,
								inf.Rct.Y+(_marginSize.Height-inf.Glyph.Height)/2,
								Color.Transparent);
					}
					#endregion
					#region draw text & shortcut
					SizeF sz;
					Font fnt=
						inf.Item.DefaultItem?new Font(e.Font,FontStyle.Bold):
						SystemInformation.MenuFont;//set font to BOLD if Item is a DefaultItem
					if (inf.Item.Text!="")
					{
						sz=e.Graphics.MeasureString(inf.Item.Text,fnt);//draw text
						e.Graphics.DrawString(inf.Item.Text,fnt,
							inf.Disabled?Brushes.Gray:Brushes.Black,
							inf.Rct.X+_marginSize.Width+5,
							inf.Rct.Y+(inf.Rct.Height-(int)sz.Height)/2,fmt);
					}	
					if (inf.Item.Shortcut!=Shortcut.None && inf.Item.ShowShortcut)
					{
						string shc=GetShortcutString((Keys)inf.Item.Shortcut);

						sz=e.Graphics.MeasureString(shc,fnt);//draw shortcut
						e.Graphics.DrawString(shc,fnt,
							inf.Disabled?Brushes.Gray:Brushes.Black,
							inf.Rct.Right-(int)sz.Width-16,
							inf.Rct.Y+(inf.Rct.Height-(int)sz.Height)/2);
					}
					#endregion
				}
			}
			#endregion
			#region provideproperty::NewStyleActive
			/// <summary>
			/// Specifies wheter NewStyle-Drawing is enabled or not
			/// </summary>
			[Description("Specifies wheter NewStyle-Drawing is enabled or not")]
			[Browsable(false)]
			public bool GetNewStyleActive(MenuItem control) 
			{
				return true;//make sure every new item is selected
			}
			/// <summary>
			/// Specifies wheter NewStyle-Drawing is enabled or not
			/// </summary>
			public void SetNewStyleActive(MenuItem control, bool value) 
			{
				if (!value) 
				{
					if (_menuitems.Contains(control))//remove it from the collection
					{
						_menuitems.Remove(control);
					}
					//reset to system drawing
					control.OwnerDraw=false;
					control.MeasureItem-=new MeasureItemEventHandler(control_MeasureItem);
					control.DrawItem-=new DrawItemEventHandler(control_DrawItem);
				}
				else 
				{
					//add it or change the value
					if (!_menuitems.Contains(control))
						_menuitems.Add(control,new MenuItemInfo(true,null));
					else
						((MenuItemInfo)_menuitems[control]).NewStyle=true;
					//set to owner drawing
					control.OwnerDraw=true;
					control.MeasureItem+=new MeasureItemEventHandler(control_MeasureItem);
					control.DrawItem+=new DrawItemEventHandler(control_DrawItem);
				}
			}
			#endregion
			#region provideproperty::MenuGlyph
			/// <summary>
			/// Specifies the image displayed next to the MenuItem
			/// </summary>
			[Description("Specifies the image displayed next to the MenuItem")]
			[DefaultValue(null)]
			public Image GetMenuGlyph(MenuItem control) 
			{
				MenuItemInfo ret=(MenuItemInfo)_menuitems[control];
				if (ret==null) return null;
				return ret.Glyph;
			}
			/// <summary>
			/// Specifies the image displayed next to the MenuItem
			/// </summary>
			public void SetMenuGlyph(MenuItem control, Image value) 
			{
				if (value==null) 
				{
					if (_menuitems.Contains(control))//set the image property in the collection to NULL
					{
						((MenuItemInfo)_menuitems[control]).Glyph=null;
						if(((MenuItemInfo)_menuitems[control]).NewStyle==false)
							_menuitems.Remove(control);
					}			
				}
				else 
				{
					//add the MenuItem to the collection or change the image value
					if (!_menuitems.Contains(control))
					{
						_menuitems.Add(control,new MenuItemInfo(true,value));
						control.OwnerDraw=true;
						control.MeasureItem+=new MeasureItemEventHandler(control_MeasureItem);
						control.DrawItem+=new DrawItemEventHandler(control_DrawItem);
					}
					else
						((MenuItemInfo)_menuitems[control]).Glyph=value;
					
				}
			}
			#endregion

			#region hooker
			[Browsable(false)]
			public Form OwnerForm
			{
				get{return _owner;}
				set
				{
					if (_hook!=IntPtr.Zero)//uninstall hook
					{
						Win32.UnhookWindowsHookEx(_hook);
						_hook=IntPtr.Zero;
					}
					_owner = value;
					if (_owner != null)
					{
						if (_hookprc == null)
						{
							_hookprc = new Win32.HookProc(OnHookProc);
						}
						_hook = Win32.SetWindowsHookEx(Win32.WH_CALLWNDPROC,//install hook
							_hookprc, IntPtr.Zero, Win32.GetWindowThreadProcessId(_owner.Handle, 0));
					}
				}
			}
			/// <summary>
			/// process all message posted to the application
			/// </summary>
			private int OnHookProc(int code, IntPtr wparam, ref Win32.CWPSTRUCT cwp)
			{
				if (code == 0)
				{
					switch (cwp.message)
					{
						case Win32.WM_CREATE://a window is created
						{
							StringBuilder builder1 = new StringBuilder(0x40);
							int num2 = Win32.GetClassName(cwp.hwnd, builder1, builder1.Capacity);
							string text1 = builder1.ToString();
							if (string.Compare(text1,"#32768",false) == 0)//test if the class name
								//identifies the control as a MenuItem
							{
								this.lastHook = new MenuHook(this,_lastwidth);
								this.lastHook.AssignHandle(cwp.hwnd);
								_lastwidth=0;
								/*
								 * We don't use a local variable, because the GC
								 * would destroy it immediately afte leaving the
								 * function. Instead we use one private variable
								 * ,because there's always only  one ContextMenu
								 * on the  Desktop and  the Hooker is  destroyed
								 * when another ContextMenu lights up.
								 */
							}
							break;
						}
						case Win32.WM_DESTROY://owner is destroyed, unhook all
						{
							if ((cwp.hwnd == _owner.Handle) && _hook!=IntPtr.Zero)
							{
								Win32.UnhookWindowsHookEx(_hook);
								_hook = IntPtr.Zero;
							}
							break;
						}
					}
				}
				return Win32.CallNextHookEx(_hook, code, wparam, ref cwp);
			}
			#endregion
			#region helper
			/// <summary>
			/// gets the brush to draw the image-band next to each menuitem
			/// </summary>
			[Browsable(false)]
			public LinearGradientBrush MarginBrush
			{
				get
				{
					_blends[1].Colors=_cols[0];
					lnbrs.InterpolationColors=_blends[1];
					lnbrs.Transform=new Matrix(_marginSize.Width,0f,0f,1f,1f,0f);
					return lnbrs;
				}
			}
			/// <summary>
			/// gets the width of the image-band next to each menuitem
			/// </summary>
			[Browsable(false)]
			public int MarginWidth
			{
				get{return _marginSize.Width;}
			}
			/// <summary>
			/// returns the Pen used to paint the border of a menuitem
			/// </summary>
			[Browsable(false)]
			public Pen BorderPen
			{
				get
				{
					border.Color=_cols[3][1];
					return border;
				}
			}
			[Browsable(false)]
			public Pen BackgroundPen
			{
				get
				{
					border.Color=_cols[3][0];
					return border;
				}
			}
			[Browsable(false)]
			public SolidBrush BackGroundBrush
			{
				get
				{
					hotbrs.Color=_cols[3][0];
					return hotbrs;
				}
			}
			private string GetShortcutString(Keys shortcut)
			{
				return TypeDescriptor.GetConverter(typeof(Keys))
					.ConvertToString(shortcut);
			}
			#endregion
			#region public properties
			/// <summary>
			/// the color of the border of the selection frame and the popup menu itself
			/// </summary>
			[DefaultValue(typeof(Color),"0,0,128")]
			[Category("Colors")]
			[Description("the color of the border of the selection frame and the popup menu itself")]
			public Color BorderColor
			{
				get{return _cols[3][1];}
				set{_cols[3][1]=Color.FromArgb(255,value);}
			}
			/// <summary>
			/// specifies the lighter color of a preselected menuitem
			/// </summary>
			[DefaultValue(typeof(Color),"255,238,194")]
			[Category("Colors")]
			[Description("specifies the lighter color of a preselected menuitem")]
			public Color HotLightGradientLight
			{
				get{return _cols[2][0];}
				set{_cols[2][0]=Color.FromArgb(255,value);}
			}
			/// <summary>
			/// specifies the darker color of a preselected menuitem
			/// </summary>
			[DefaultValue(typeof(Color),"255,214,154")]
			[Category("Colors")]
			[Description("specifies the darker color of a preselected menuitem")]
			public Color HotLightGradientDark
			{
				get{return _cols[2][1];}
				set{_cols[2][1]=Color.FromArgb(255,value);}
			}
			/// <summary>
			/// the color on the right side of a mainmenu
			/// </summary>
			[DefaultValue(typeof(Color),"195,218,249")]
			[Category("Colors")]
			[Description("the color on the right side of a mainmenu")]
			public Color BandGradientLight
			{
				get{return _cols[1][0];}
				set{_cols[1][0]=Color.FromArgb(255,value);}
			}
			/// <summary>
			/// the color on the left side of a mainmenu
			/// </summary>
			[DefaultValue(typeof(Color),"158,190,245")]
			[Category("Colors")]
			[Description("the color on the left side of a mainmenu")]
			public Color BandGradientDark
			{
				get{return _cols[1][1];}
				set{_cols[1][1]=Color.FromArgb(255,value);}
			}
			/// <summary>
			/// sets or gets the lighter color of the image-band next to each menuitem
			/// </summary>
			[DefaultValue(typeof(Color),"227,239,255")]
			[Category("Colors")]
			[Description("sets or gets the lighter color of the image-band next to each menuitem")]
			public Color ItemGradientLight
			{
				get{return _cols[0][0];}
				set{_cols[0][0]=Color.FromArgb(255,value);}
			}
			/// <summary>
			/// sets or gets the middle color of the image-band next to each menuitem
			/// </summary>
			[DefaultValue(typeof(Color),"203,225,252")]
			[Category("Colors")]
			[Description("sets or gets the middle color of the image-band next to each menuitem")]
			public Color ItemGradientMiddle
			{
				get{return _cols[0][1];}
				set{_cols[0][1]=Color.FromArgb(255,value);}
			}
			/// <summary>
			/// sets or gets the darker color of the image-band next to each menuitem
			/// </summary>
			[DefaultValue(typeof(Color),"135,173,228")]
			[Category("Colors")]
			[Description("sets or gets the darker color of the image-band next to each menuitem")]
			public Color ItemGradientDark
			{
				get{return _cols[0][2];}
				set{_cols[0][2]=Color.FromArgb(255,value);}
			}
			/// <summary>
			/// sets or gets the background color of each contextmenu
			/// </summary>
			[DefaultValue(typeof(Color),"246,246,246")]
			[Category("Colors")]
			[Description("sets or gets the background color of each contextmenu")]
			public Color MenuBackground
			{
				get{return _cols[3][0];}
				set{_cols[3][0]=Color.FromArgb(255,value);}
			}
			/// <summary>
			/// sets or gets the size of the image band next to each contextmenu item
			/// </summary>
			[DefaultValue(typeof(Size),"23,22")]
			[Category("Appearance")]
			[Description("sets or gets the size of the image band next to each contextmenu item")]
			public Size BandSize
			{
				get{return _marginSize;}
				set
				{
					if (value.Height<16) value.Height=16;
					if(value.Width<16) value.Width=16;
					_marginSize=value;
				}
			}
			#endregion
		}
		/// <summary>
		/// This class is used to hook the events posted to a context/popup menu
		/// </summary>
		
	internal class MenuHook:NativeWindow
		{
			#region variablen
			private ClientMenuStyleProvider _parent=null;
			private int _lastwidth=0;
			#endregion
			public MenuHook(ClientMenuStyleProvider parent, int lastwidth)
			{
				if (parent==null)
					throw new ArgumentNullException();//parent property mustn't be NULL
				_parent=parent;//MenuExtender with drawing paramenters
				_lastwidth=lastwidth;//width of the topItem unfolding the Menu or 0
			}
			#region controller
			/// <summary>
			/// Hook window messages of a context/popup menu
			/// </summary>
			/// <param name="m">windows message</param>
			protected override void WndProc(ref Message m)
			{
				switch(m.Msg)
				{
					case Win32.WM_WINDOWPOSCHANGING:
					{
						Win32.WINDOWPOS pos = (Win32.WINDOWPOS)
							Marshal.PtrToStructure(m.LParam,typeof(Win32.WINDOWPOS));
						if( (pos.flags & Win32.SWP_NOSIZE) == 0 ) 
						{
							pos.cx -= 2;
							pos.cy -= 2;
						}
						System.Runtime.InteropServices.Marshal.StructureToPtr( pos, m.LParam, true );
						m.Result=IntPtr.Zero;
						break;
					}
					case Win32.WM_NCPAINT://menu unfolding
					{
						IntPtr windc = Win32.GetWindowDC(m.HWnd);
						Graphics gr = Graphics.FromHdc(windc);
						this.DrawBorder(gr);
						Win32.ReleaseDC(m.HWnd, windc);
						gr.Dispose();
						m.Result = IntPtr.Zero;
						break;
					}
					case Win32.WM_NCCALCSIZE:
					{
						Win32.NCCALCSIZE_PARAMS calc = (Win32.NCCALCSIZE_PARAMS)
							Marshal.PtrToStructure(m.LParam,typeof
							(Win32.NCCALCSIZE_PARAMS));
						calc.r1.Left += 2;
						calc.r1.Top += 2;
						calc.r1.Right -= 2;
						calc.r1.Bottom -= 2;
						System.Runtime.InteropServices.Marshal.StructureToPtr( calc, m.LParam, true );
						m.Result=new IntPtr(Win32.WVR_REDRAW);
						break;
					}
					default:
					{
						base.WndProc(ref m);
						break;
					}
				}
			}
			#endregion
			/// <summary>
			/// This draws the missing parts in the margin of a menuitem
			/// </summary>
			/// <param name="gr">the graphics surface to draw on</param>
			private void DrawBorder(Graphics gr)
			{
				//calculate the space of the context/popup menu
				Rectangle clip=Rectangle.Round(gr.VisibleClipBounds);
				clip.Width--; clip.Height--;

				int margin=_parent.MarginWidth;
				//fill the missing gradient parts using extender's brush
				gr.FillRectangle(_parent.MarginBrush,clip.X+1,clip.Y+1,1,clip.Height-1);
				//fill the other edges white, so using old windows style will not change the appearance
				gr.FillRectangle(_parent.BackGroundBrush,clip.X+1,clip.Y+1,clip.Width-1,1);
				gr.FillRectangle(_parent.BackGroundBrush,clip.X+1,clip.Bottom-1,clip.Width-1,1);
				gr.FillRectangle(_parent.BackGroundBrush,clip.Right-1,clip.Y+1,1,clip.Height);

				//draw the border with a little white line on the top,
				//then it looks like a tab unfolding.
				//in contextmenus: _lastwidth==0
				gr.DrawLine(_parent.BackgroundPen,clip.X+1,clip.Y,clip.X+_lastwidth-2,clip.Y);
				gr.DrawLine(_parent.BorderPen,clip.X,clip.Y,clip.X,clip.Bottom);
				gr.DrawLine(_parent.BorderPen,clip.X,clip.Bottom,clip.Right,clip.Bottom);
				gr.DrawLine(_parent.BorderPen,clip.Right,clip.Bottom,clip.Right,clip.Y);
				gr.DrawLine(_parent.BorderPen,clip.Right,clip.Y,clip.X+_lastwidth-1,clip.Y);
			}
		}
		/// <summary>
		/// This class provides static access to some Win32 API
		/// </summary>
        
        internal abstract class Win32
		{
			[DllImport("user32.dll", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
			public static extern int CallNextHookEx(IntPtr hookHandle, int code, IntPtr wparam, ref CWPSTRUCT cwp);
			[DllImport("user32.dll", EntryPoint="GetClassNameA", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
			public static extern int GetClassName(IntPtr hwnd, StringBuilder className, int maxCount);
			[DllImport("user32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
			public static extern IntPtr GetWindowDC(IntPtr hwnd);
			[DllImport("user32.dll", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
			public static extern int GetWindowThreadProcessId(IntPtr hwnd, int ID);
			[DllImport("user32", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
			public static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hdc);
			[DllImport("user32.dll", EntryPoint="SetWindowsHookExA", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
			public static extern IntPtr SetWindowsHookEx(int type, HookProc hook, IntPtr instance, int threadID);
			[DllImport("user32.dll", CharSet=CharSet.Ansi, SetLastError=true, ExactSpelling=true)]
			public static extern bool UnhookWindowsHookEx(IntPtr hookHandle);

			public const int WH_CALLWNDPROC = 4;
			public const int WM_CREATE = 1;
			public const int WM_DESTROY = 2;
			public const int WM_NCPAINT = 0x85;
			public const int WM_PRINT = 0x317;
			public const int WM_WINDOWPOSCHANGING = 0x46;
			public const int SWP_NOSIZE = 0x1;
			public const int WM_NCCALCSIZE = 0x83;
			public const int WVR_REDRAW = (WVR_HREDRAW | WVR_VREDRAW);
			public const int WVR_HREDRAW = 0x100;
			public const int WVR_VREDRAW = 0x200;
			public const int SWP_NOMOVE = 0x2;

			[StructLayout(LayoutKind.Sequential)]
            
			public struct NCCALCSIZE_PARAMS
			{
				public RECT r1,r2,r3;
				public IntPtr lppos;
			}
			[StructLayout(LayoutKind.Sequential)]
            
			public struct RECT
			{
				internal int Left;
				internal int Top;
				internal int Right;
				internal int Bottom;
			}
			[StructLayout(LayoutKind.Sequential)]
            
            public struct CWPSTRUCT
			{
				public IntPtr lparam;
				public IntPtr wparam;
				public int message;
				public IntPtr hwnd;
			}
			[StructLayout(LayoutKind.Sequential)]
            
            public struct WINDOWPOS
			{
				internal int hwnd;
				internal int hWndInsertAfter;
				internal int x;
				internal int y;
				internal int cx;
				internal int cy;
				internal int flags;
			}


			public delegate int HookProc(int code, IntPtr wparam, ref Win32.CWPSTRUCT cwp);
		}


}
