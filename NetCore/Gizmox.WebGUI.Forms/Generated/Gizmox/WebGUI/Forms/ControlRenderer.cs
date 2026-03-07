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
	/// Provides support for rendering a control
	/// </summary>
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class ControlRenderer
	{
		/// 
		///
		/// </summary>
		private readonly Control mobjControl = null;

		/// 
		/// Gets the control.
		/// </summary>
		public Control Control => mobjControl;

		/// 
		/// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ControlRenderer" /> class.
		/// </summary>
		/// <param name="objControl">The control.</param>
		public ControlRenderer(Control objControl)
		{
			mobjControl = objControl;
		}

		/// 
		/// Renders the control to the specified graphics.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objGraphics">The graphics.</param>
		protected internal virtual void Render(ControlRenderingContext objContext, Graphics objGraphics)
		{
			RenderBackground(objContext, objGraphics);
			RenderBorder(objContext, objGraphics);
			RenderContent(objContext, objGraphics);
		}

		/// 
		/// Gets the content region.
		/// </summary>
		/// </returns>
		protected static Rectangle GetContentRegion(Control objControl)
		{
			return GetContentRegion(objControl, blnApplyPadding: true, blnApplyBorder: true);
		}

		/// 
		/// Gets the content region.
		/// </summary>
		/// </returns>
		protected static Rectangle GetContentRegion(Control objControl, bool blnApplyPadding, bool blnApplyBorder)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			if (objControl != null)
			{
				num3 = objControl.Width;
				num4 = objControl.Height;
				if (blnApplyPadding)
				{
					Padding padding = objControl.Padding;
					num += padding.Left;
					num2 += padding.Top;
					num3 -= padding.Horizontal;
					num4 -= padding.Vertical;
				}
				if (blnApplyBorder && objControl.BorderStyle != BorderStyle.None)
				{
					BorderWidth borderWidth = objControl.BorderWidth;
					num += borderWidth.Left;
					num2 += borderWidth.Top;
					num3 -= borderWidth.Right + borderWidth.Left;
					num4 -= borderWidth.Bottom + borderWidth.Top;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (num4 < 0)
				{
					num4 = 0;
				}
			}
			return new Rectangle(num, num2, num3, num4);
		}

		/// 
		/// Renders the content.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objGraphics">The graphics.</param>
		protected virtual void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
		{
		}

		/// 
		/// Renders the text.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="strText">The text.</param>
		/// <param name="objFont">The font.</param>
		/// <param name="objForeColor">The fore color.</param>
		/// <param name="objRegionSize">The region size.</param>
		/// <param name="enmAlignemnt">The alignemnt.</param>
		/// <param name="blnWrapText">if set to true</c> wrap text.</param>
		protected static RectangleF RenderText(ControlRenderingContext objContext, Graphics objGraphics, string strText, Font objFont, Color objForeColor, Size objRegionSize, HorizontalAlignment enmAlignemnt, bool blnWrapText)
		{
			return RenderText(objContext, objGraphics, strText, objFont, objForeColor, new Rectangle(new Point(0, 0), objRegionSize), enmAlignemnt, blnWrapText);
		}

		/// 
		/// Renders the text.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="strText">The text.</param>
		/// <param name="objFont">The font.</param>
		/// <param name="objForeColor">The fore color.</param>
		/// <param name="objRegionSize">The region size.</param>
		/// <param name="enmAlignemnt">The alignemnt.</param>
		/// <param name="blnWrapText">if set to true</c> wrap text.</param>
		protected static RectangleF RenderText(ControlRenderingContext objContext, Graphics objGraphics, string strText, Font objFont, Color objForeColor, Size objRegionSize, ContentAlignment enmAlignemnt, bool blnWrapText)
		{
			return RenderText(objContext, objGraphics, strText, objFont, objForeColor, new Rectangle(new Point(0, 0), objRegionSize), enmAlignemnt, blnWrapText);
		}

		/// 
		/// Renders the text.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="strText">The text.</param>
		/// <param name="objFont">The font.</param>
		/// <param name="objForeColor">The fore color.</param>
		/// <param name="objRegion">The region.</param>
		/// <param name="enmAlignemnt">The alignemnt.</param>
		protected static RectangleF RenderText(ControlRenderingContext objContext, Graphics objGraphics, string strText, Font objFont, Color objForeColor, Rectangle objRegion, HorizontalAlignment enmAlignemnt, bool blnWrapText)
		{
			ContentAlignment enmAlignemnt2 = ContentAlignment.MiddleCenter;
			switch (enmAlignemnt)
			{
			case HorizontalAlignment.Center:
				enmAlignemnt2 = ContentAlignment.MiddleCenter;
				break;
			case HorizontalAlignment.Right:
				enmAlignemnt2 = ContentAlignment.MiddleRight;
				break;
			case HorizontalAlignment.Left:
				enmAlignemnt2 = ContentAlignment.MiddleLeft;
				break;
			}
			return RenderText(objContext, objGraphics, strText, objFont, objForeColor, objRegion, enmAlignemnt2, blnWrapText);
		}

		/// 
		/// Renders the text.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="strText">The text.</param>
		/// <param name="objFont">The font.</param>
		/// <param name="objForeColor">The fore color.</param>
		/// <param name="objLocation">The location.</param>
		/// </returns>
		protected static RectangleF RenderText(ControlRenderingContext objContext, Graphics objGraphics, string strText, Font objFont, Color objForeColor, Point objLocation)
		{
			return RenderText(objContext, objGraphics, strText, objFont, objForeColor, new Rectangle(objLocation, new Size(10, 10)), ContentAlignment.TopLeft, blnWrapText: false);
		}

		/// 
		/// Renders the text.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="strText">The text.</param>
		/// <param name="objFont">The font.</param>
		/// <param name="objForeColor">The fore color.</param>
		/// <param name="objRegion">The region.</param>
		/// <param name="enmAlignemnt">The alignemnt.</param>
		protected static RectangleF RenderText(ControlRenderingContext objContext, Graphics objGraphics, string strText, Font objFont, Color objForeColor, Rectangle objRegion, ContentAlignment enmAlignemnt, bool blnWrapText)
		{
			return RenderText(objContext, objGraphics, strText, objFont, new SolidBrush(objForeColor), objRegion, enmAlignemnt, blnWrapText);
		}

		/// 
		/// Renders the text.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="strText">The text.</param>
		/// <param name="objFont">The font.</param>
		/// <param name="objBrush">The brush.</param>
		/// <param name="objLocation">The location.</param>
		/// </returns>
		protected static RectangleF RenderText(ControlRenderingContext objContext, Graphics objGraphics, string strText, Font objFont, Brush objBrush, Point objLocation)
		{
			return RenderText(objContext, objGraphics, strText, objFont, objBrush, new Rectangle(objLocation, new Size(10, 10)), ContentAlignment.TopLeft, blnWrapText: false);
		}

		/// 
		/// Gets a flag indicating if the region is visible
		/// </summary>
		/// <param name="objRegion"></param>
		/// </returns>
		protected static bool IsVisibleRegion(Rectangle objRegion)
		{
			return objRegion.Width > 0 && objRegion.Height > 0;
		}

		/// 
		/// Renders the text.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="strText">The text.</param>
		/// <param name="objFont">The font.</param>
		/// <param name="objBrush">The brush.</param>
		/// <param name="objRegion">The region.</param>
		/// <param name="enmAlignemnt">The alignemnt.</param>
		protected static RectangleF RenderText(ControlRenderingContext objContext, Graphics objGraphics, string strText, Font objFont, Brush objBrush, Rectangle objCurrentRegion, ContentAlignment enmAlignemnt, bool blnWrapText)
		{
			if (objFont == null)
			{
				objFont = SystemFonts.DefaultFont;
			}
			SizeF sizeF = ((!blnWrapText) ? objGraphics.MeasureString(strText, objFont) : objGraphics.MeasureString(strText, objFont, objCurrentRegion.Width));
			PointF contentLocation = GetContentLocation(sizeF, objCurrentRegion, enmAlignemnt);
			Region clip = objGraphics.Clip;
			objGraphics.Clip = new Region(objCurrentRegion);
			objGraphics.DrawString(strText, objFont, objBrush, contentLocation);
			objGraphics.Clip = clip;
			return new RectangleF(contentLocation, sizeF);
		}

		/// 
		/// Renders the image.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objResourceHandle">The resource handle.</param>
		/// <param name="objLocation">The location.</param>
		protected static RectangleF RenderImage(ControlRenderingContext objContext, Graphics objGraphics, ResourceHandle objResourceHandle, Point objLocation)
		{
			return RenderImage(objContext, objGraphics, objResourceHandle, new Rectangle(objLocation, new Size(10, 10)), ContentAlignment.TopLeft);
		}

		/// 
		/// Renders the image.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objResourceHandle">The resource handle.</param>
		/// <param name="objRegion">The region.</param>
		/// <param name="enmAlignemnt">The alignemnt.</param>
		protected static RectangleF RenderImage(ControlRenderingContext objContext, Graphics objGraphics, ResourceHandle objResourceHandle, Rectangle objRegion, ContentAlignment enmAlignemnt)
		{
			if (objResourceHandle != null)
			{
				try
				{
					if (objResourceHandle.CanGetImage)
					{
						System.Drawing.Image image = objResourceHandle.ToImage();
						if (image != null)
						{
							return RenderImage(objContext, objGraphics, image, objRegion, enmAlignemnt);
						}
					}
				}
				catch
				{
				}
			}
			return RectangleF.Empty;
		}

		/// 
		/// Renders the image.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objImage">The image.</param>
		/// <param name="objLocation">The location.</param>
		/// </returns>
		protected static RectangleF RenderImage(ControlRenderingContext objContext, Graphics objGraphics, System.Drawing.Image objImage, Point objLocation)
		{
			return RenderImage(objContext, objGraphics, objImage, new Rectangle(objLocation, new Size(10, 10)), ContentAlignment.TopLeft);
		}

		/// 
		/// Renders the image.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objImage">The image.</param>
		/// <param name="objRegion">The region.</param>
		/// <param name="enmAlignemnt">The alignemnt.</param>
		protected static RectangleF RenderImage(ControlRenderingContext objContext, Graphics objGraphics, System.Drawing.Image objImage, Rectangle objRegion, ContentAlignment enmAlignemnt)
		{
			if (objImage != null)
			{
				PointF contentLocation = GetContentLocation(objImage.Size, objRegion, enmAlignemnt);
				objGraphics.DrawImage(objImage, contentLocation);
				return new RectangleF(contentLocation, objImage.Size);
			}
			return RectangleF.Empty;
		}

		/// 
		/// Gets the vertical alignment.
		/// </summary>
		/// <param name="enmAlignment">The alignment.</param>
		/// <param name="blnIsLeft">if set to true</c> is left.</param>
		/// </returns>
		protected static ContentAlignment GetVerticalAlignment(ContentAlignment enmAlignment, bool blnIsLeft)
		{
			if (blnIsLeft)
			{
				switch (enmAlignment)
				{
				case ContentAlignment.BottomLeft:
				case ContentAlignment.BottomCenter:
				case ContentAlignment.BottomRight:
					return ContentAlignment.BottomLeft;
				case ContentAlignment.MiddleLeft:
				case ContentAlignment.MiddleCenter:
				case ContentAlignment.MiddleRight:
					return ContentAlignment.MiddleLeft;
				case ContentAlignment.TopLeft:
				case ContentAlignment.TopCenter:
				case ContentAlignment.TopRight:
					return ContentAlignment.TopLeft;
				}
			}
			else
			{
				switch (enmAlignment)
				{
				case ContentAlignment.BottomLeft:
				case ContentAlignment.BottomCenter:
				case ContentAlignment.BottomRight:
					return ContentAlignment.BottomRight;
				case ContentAlignment.MiddleLeft:
				case ContentAlignment.MiddleCenter:
				case ContentAlignment.MiddleRight:
					return ContentAlignment.MiddleRight;
				case ContentAlignment.TopLeft:
				case ContentAlignment.TopCenter:
				case ContentAlignment.TopRight:
					return ContentAlignment.TopRight;
				}
			}
			return enmAlignment;
		}

		/// 
		/// Gets the horizontal alignment.
		/// </summary>
		/// <param name="enmAlignment">The alignment.</param>
		/// <param name="blnIsTop">if set to true</c> is top.</param>
		/// </returns>
		protected static ContentAlignment GetHorizontalAlignment(ContentAlignment enmAlignment, bool blnIsTop)
		{
			if (blnIsTop)
			{
				switch (enmAlignment)
				{
				case ContentAlignment.TopCenter:
				case ContentAlignment.MiddleCenter:
				case ContentAlignment.BottomCenter:
					return ContentAlignment.TopCenter;
				case ContentAlignment.TopLeft:
				case ContentAlignment.MiddleLeft:
				case ContentAlignment.BottomLeft:
					return ContentAlignment.TopLeft;
				case ContentAlignment.TopRight:
				case ContentAlignment.MiddleRight:
				case ContentAlignment.BottomRight:
					return ContentAlignment.TopRight;
				}
			}
			else
			{
				switch (enmAlignment)
				{
				case ContentAlignment.TopCenter:
				case ContentAlignment.MiddleCenter:
				case ContentAlignment.BottomCenter:
					return ContentAlignment.BottomCenter;
				case ContentAlignment.TopLeft:
				case ContentAlignment.MiddleLeft:
				case ContentAlignment.BottomLeft:
					return ContentAlignment.BottomLeft;
				case ContentAlignment.TopRight:
				case ContentAlignment.MiddleRight:
				case ContentAlignment.BottomRight:
					return ContentAlignment.BottomRight;
				}
			}
			return enmAlignment;
		}

		/// 
		/// Gets the content location.
		/// </summary>
		/// <param name="objContentSize">The content size.</param>
		/// <param name="objRegion">The region size.</param>
		/// <param name="enmAlignemnt">The content alignemnt.</param>
		/// </returns>
		private static PointF GetContentLocation(SizeF objContentSize, Rectangle objRegion, ContentAlignment enmAlignemnt)
		{
			float x = 0f;
			float y = 0f;
			switch (enmAlignemnt)
			{
			case ContentAlignment.TopRight:
			case ContentAlignment.MiddleRight:
			case ContentAlignment.BottomRight:
				x = (float)objRegion.Right - objContentSize.Width;
				break;
			case ContentAlignment.TopLeft:
			case ContentAlignment.MiddleLeft:
			case ContentAlignment.BottomLeft:
				x = objRegion.Left;
				break;
			case ContentAlignment.TopCenter:
			case ContentAlignment.MiddleCenter:
			case ContentAlignment.BottomCenter:
				x = (float)(objRegion.Left + objRegion.Width / 2) - objContentSize.Width / 2f;
				break;
			}
			switch (enmAlignemnt)
			{
			case ContentAlignment.BottomLeft:
			case ContentAlignment.BottomCenter:
			case ContentAlignment.BottomRight:
				y = (float)objRegion.Bottom - objContentSize.Height;
				break;
			case ContentAlignment.TopLeft:
			case ContentAlignment.TopCenter:
			case ContentAlignment.TopRight:
				y = objRegion.Top;
				break;
			case ContentAlignment.MiddleLeft:
			case ContentAlignment.MiddleCenter:
			case ContentAlignment.MiddleRight:
				y = (float)(objRegion.Top + objRegion.Height / 2) - objContentSize.Height / 2f;
				break;
			}
			return new PointF(x, y);
		}

		/// 
		/// Docks the in region.
		/// </summary>
		/// <param name="objRegion">The region.</param>
		/// <param name="enmDock">The dock.</param>
		/// <param name="objRectangleF">The docked rectangle.</param>
		/// </returns>
		protected static Rectangle DockInRegion(Rectangle objRegion, DockStyle enmDock, RectangleF objRectangleF)
		{
			return DockInRegion(objRegion, enmDock, Rectangle.Truncate(objRectangleF));
		}

		/// 
		/// Docks the in region.
		/// </summary>
		/// <param name="objRegion">The region.</param>
		/// <param name="enmDock">The dock.</param>
		/// <param name="objRectangle">The docked rectangle.</param>
		/// </returns>
		protected static Rectangle DockInRegion(Rectangle objRegion, DockStyle enmDock, Rectangle objRectangle)
		{
			return DockInRegion(objRegion, enmDock, objRectangle.Size);
		}

		/// 
		/// Docks the in region.
		/// </summary>
		/// <param name="objRegion">The region.</param>
		/// <param name="enmDock">The dock.</param>
		/// <param name="objSize">The docked size.</param>
		/// </returns>
		protected static Rectangle DockInRegion(Rectangle objRegion, DockStyle enmDock, SizeF objSize)
		{
			return DockInRegion(objRegion, enmDock, Size.Truncate(objSize));
		}

		/// 
		/// Docks the in region.
		/// </summary>
		/// <param name="objRegion">The region.</param>
		/// <param name="enmDock">The dock.</param>
		/// <param name="objSize">The docked size.</param>
		/// </returns>
		protected static Rectangle DockInRegion(Rectangle objRegion, DockStyle enmDock, Size objSize)
		{
			int num = objRegion.X;
			int num2 = objRegion.Y;
			int num3 = objRegion.Height;
			int num4 = objRegion.Width;
			switch (enmDock)
			{
			case DockStyle.Left:
				num += objSize.Width;
				num4 -= objSize.Width;
				break;
			case DockStyle.Right:
				num4 -= objSize.Width;
				break;
			case DockStyle.Top:
				num2 += objSize.Height;
				num3 -= objSize.Height;
				break;
			case DockStyle.Bottom:
				num3 -= objSize.Height;
				break;
			}
			if (num3 < 0)
			{
				num3 = 0;
			}
			if (num4 < 0)
			{
				num4 = 0;
			}
			return new Rectangle(num, num2, num4, num3);
		}

		/// 
		/// Renders the border.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objGraphics">The graphics.</param>
		protected virtual void RenderBorder(ControlRenderingContext objContext, Graphics objGraphics)
		{
			BorderStyle borderStyle = mobjControl.BorderStyle;
			if (borderStyle != BorderStyle.None && borderStyle != BorderStyle.Clear)
			{
				int height = mobjControl.Height;
				int width = mobjControl.Width;
				if (height > 2 && width > 2)
				{
					objGraphics.DrawRectangle(new Pen(mobjControl.BorderColor, 1f), new Rectangle(0, 0, width - 2, height - 2));
				}
			}
		}

		/// 
		/// Renders the background.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objGraphics">The graphics.</param>
		protected virtual void RenderBackground(ControlRenderingContext objContext, Graphics objGraphics)
		{
			RenderBackgroundColor(objContext, objGraphics);
			RenderBackgroundImage(objContext, objGraphics);
		}

		/// 
		/// Renders the background image.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objGraphics">The graphics.</param>
		protected virtual void RenderBackgroundImage(ControlRenderingContext objContext, Graphics objGraphics)
		{
		}

		/// 
		/// Renders the background color.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objGraphics">The graphics.</param>
		protected virtual void RenderBackgroundColor(ControlRenderingContext objContext, Graphics objGraphics)
		{
			objGraphics.DrawRectangle(new Pen(mobjControl.BackColor), new Rectangle(new Point(0, 0), mobjControl.Size));
		}

		/// 
		/// Renders the controls.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objGraphics">The graphics.</param>
		protected virtual void RenderControls(ControlRenderingContext objContext, Graphics objGraphics)
		{
			foreach (Control control in mobjControl.Controls)
			{
				Bitmap bitmap = control.DrawControl(objContext, control.Width, control.Height);
				if (bitmap != null)
				{
					objGraphics.DrawImage(bitmap, control.Location);
				}
			}
		}

		/// 
		/// Renders the frame.
		/// </summary>
		/// <param name="objGraphics">The obj graphics.</param>
		/// <param name="objFrameStyle">The frame style.</param>
		/// <param name="objRegion">The region.</param>
		protected static void RenderFrame(ControlRenderingContext objContext, Graphics objGraphics, Skin objSkin, FrameStyleValue objFrameStyle, Rectangle objRegion)
		{
			ResourceHandle resourceHandleFromReference = objSkin.GetResourceHandleFromReference(objFrameStyle.LeftTopStyle.BackgroundImage);
			ResourceHandle resourceHandleFromReference2 = objSkin.GetResourceHandleFromReference(objFrameStyle.RightTopStyle.BackgroundImage);
			ResourceHandle resourceHandleFromReference3 = objSkin.GetResourceHandleFromReference(objFrameStyle.LeftBottomStyle.BackgroundImage);
			ResourceHandle resourceHandleFromReference4 = objSkin.GetResourceHandleFromReference(objFrameStyle.RightBottomStyle.BackgroundImage);
			Rectangle rectangle = Rectangle.Truncate(RenderImage(objContext, objGraphics, resourceHandleFromReference, objRegion, ContentAlignment.TopLeft));
			Rectangle rectangle2 = Rectangle.Truncate(RenderImage(objContext, objGraphics, resourceHandleFromReference2, objRegion, ContentAlignment.TopRight));
			Rectangle rectangle3 = Rectangle.Truncate(RenderImage(objContext, objGraphics, resourceHandleFromReference3, objRegion, ContentAlignment.BottomLeft));
			Rectangle rectangle4 = Rectangle.Truncate(RenderImage(objContext, objGraphics, resourceHandleFromReference4, objRegion, ContentAlignment.BottomRight));
			ResourceHandle resourceHandleFromReference5 = objSkin.GetResourceHandleFromReference(objFrameStyle.LeftStyle.BackgroundImage);
			ResourceHandle resourceHandleFromReference6 = objSkin.GetResourceHandleFromReference(objFrameStyle.RightStyle.BackgroundImage);
			ResourceHandle resourceHandleFromReference7 = objSkin.GetResourceHandleFromReference(objFrameStyle.TopStyle.BackgroundImage);
			ResourceHandle resourceHandleFromReference8 = objSkin.GetResourceHandleFromReference(objFrameStyle.BottomStyle.BackgroundImage);
			int width = rectangle.Width;
			int width2 = rectangle2.Width;
			int height = rectangle.Height;
			int height2 = rectangle3.Height;
			Rectangle objRegion2 = new Rectangle(objRegion.Left, objRegion.Top + height, width, Math.Max(objRegion.Height - height - height2, 0));
			Rectangle objRegion3 = new Rectangle(objRegion.Right - width2, objRegion.Top + height, width2, Math.Max(objRegion.Height - height - height2, 0));
			Rectangle objRegion4 = new Rectangle(objRegion.Left + width, objRegion.Top, Math.Max(objRegion.Width - width - width2, 0), height);
			Rectangle objRegion5 = new Rectangle(objRegion.Left + width, objRegion.Bottom - height2, Math.Max(objRegion.Width - width - width2, 0), height2);
			RenderStyle(objContext, objGraphics, objSkin, objFrameStyle.CenterStyle, new Rectangle(objRegion.Left + width, objRegion.Top + height, Math.Max(objRegion.Width - width - width2, 0), Math.Max(objRegion.Height - height - height2, 0)));
			RenderRepeatedImage(objContext, objGraphics, resourceHandleFromReference5, objRegion2, BackgroundImageRepeat.RepeatY, BackgroundImagePosition.TopLeft);
			RenderRepeatedImage(objContext, objGraphics, resourceHandleFromReference6, objRegion3, BackgroundImageRepeat.RepeatY, BackgroundImagePosition.TopRight);
			RenderRepeatedImage(objContext, objGraphics, resourceHandleFromReference7, objRegion4, BackgroundImageRepeat.RepeatX, BackgroundImagePosition.TopLeft);
			RenderRepeatedImage(objContext, objGraphics, resourceHandleFromReference8, objRegion5, BackgroundImageRepeat.RepeatX, BackgroundImagePosition.BottomLeft);
		}

		/// 
		/// Renders the style.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objSkin">The skin.</param>
		/// <param name="objStyle">The style.</param>
		/// <param name="objRegion">The region.</param>
		protected static void RenderStyle(ControlRenderingContext objContext, Graphics objGraphics, Skin objSkin, StyleValue objStyle, Rectangle objRegion)
		{
			try
			{
				ResourceHandle resourceHandleFromReference = objSkin.GetResourceHandleFromReference(objStyle.BackgroundImage);
				if (resourceHandleFromReference != null)
				{
					RenderRepeatedImage(objContext, objGraphics, resourceHandleFromReference, objRegion, objStyle.BackgroundImageRepeat, objStyle.BackgroundImagePosition);
				}
			}
			catch
			{
			}
		}

		/// 
		/// Renders the repeated image.
		/// </summary>
		/// <param name="objContext">The context.</param>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objResourceHandle">The resource handle.</param>
		/// <param name="objRegion">The region.</param>
		/// <param name="enmImageRepeat">The image repeat.</param>
		/// <param name="enmImagePosition">The image position.</param>
		protected static void RenderRepeatedImage(ControlRenderingContext objContext, Graphics objGraphics, ResourceHandle objResourceHandle, Rectangle objRegion, BackgroundImageRepeat enmImageRepeat, BackgroundImagePosition enmImagePosition)
		{
			if (objResourceHandle != null)
			{
				System.Drawing.Image resourceImage = objContext.GetResourceImage(objResourceHandle);
				if (resourceImage != null)
				{
					RenderRepeatedImage(objContext, objGraphics, resourceImage, objRegion, enmImageRepeat, enmImagePosition);
				}
			}
		}

		/// 
		/// Renders the repeated image.
		/// </summary>
		/// <param name="objGraphics">The graphics.</param>
		/// <param name="objImage">The image.</param>
		/// <param name="objRegion">The region.</param>
		/// <param name="enmImageRepeat">The image repeat.</param>
		/// <param name="enmImagePosition">The image position.</param>
		protected static void RenderRepeatedImage(ControlRenderingContext objContext, Graphics objGraphics, System.Drawing.Image objImage, Rectangle objRegion, BackgroundImageRepeat enmImageRepeat, BackgroundImagePosition enmImagePosition)
		{
			if (objImage == null)
			{
				return;
			}
			TextureBrush brush = (brush = new TextureBrush(objImage, WrapMode.Tile));
			switch (enmImageRepeat)
			{
			case BackgroundImageRepeat.RepeatX:
				switch (enmImagePosition)
				{
				case BackgroundImagePosition.TopCenter:
				case BackgroundImagePosition.TopLeft:
				case BackgroundImagePosition.TopRight:
					objRegion.Height = Math.Min(objRegion.Height, objImage.Height);
					break;
				case BackgroundImagePosition.BottomCenter:
				case BackgroundImagePosition.BottomLeft:
				case BackgroundImagePosition.BottomRight:
					objRegion.Y = objRegion.Bottom - objImage.Height;
					objRegion.Height = Math.Min(objRegion.Height, objImage.Height);
					break;
				case BackgroundImagePosition.MiddleCenter:
				case BackgroundImagePosition.MiddleLeft:
				case BackgroundImagePosition.MiddleRight:
					objRegion.Y += objRegion.Height / 2 - objRegion.Height / 2;
					objRegion.Height = Math.Min(objRegion.Height, objImage.Height);
					break;
				}
				break;
			case BackgroundImageRepeat.RepeatY:
				switch (enmImagePosition)
				{
				case BackgroundImagePosition.BottomLeft:
				case BackgroundImagePosition.MiddleLeft:
				case BackgroundImagePosition.TopLeft:
					objRegion.Width = Math.Min(objRegion.Width, objImage.Width);
					break;
				case BackgroundImagePosition.BottomRight:
				case BackgroundImagePosition.MiddleRight:
				case BackgroundImagePosition.TopRight:
					objRegion.X = objRegion.Right - objImage.Width;
					objRegion.Width = Math.Min(objRegion.Width, objImage.Width);
					break;
				case BackgroundImagePosition.BottomCenter:
				case BackgroundImagePosition.MiddleCenter:
				case BackgroundImagePosition.TopCenter:
					objRegion.X += objRegion.Width / 2 - objRegion.Width / 2;
					objRegion.Width = Math.Min(objRegion.Width, objImage.Width);
					break;
				}
				break;
			}
			objGraphics.FillRectangle(brush, objRegion);
		}
	}
}
