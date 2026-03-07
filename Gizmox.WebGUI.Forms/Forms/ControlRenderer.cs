// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ControlRenderer
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms.Layout;
using Gizmox.WebGUI.Forms.Skins;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides support for rendering a control</summary>
  [EditorBrowsable(EditorBrowsableState.Never)]
  public class ControlRenderer
  {
    /// <summary>
    /// 
    /// </summary>
    private readonly Control mobjControl;

    /// <summary>
    /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.ControlRenderer" /> class.
    /// </summary>
    /// <param name="objControl">The control.</param>
    public ControlRenderer(Control objControl) => this.mobjControl = objControl;

    /// <summary>Renders the control to the specified graphics.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    protected internal virtual void Render(ControlRenderingContext objContext, Graphics objGraphics)
    {
      this.RenderBackground(objContext, objGraphics);
      this.RenderBorder(objContext, objGraphics);
      this.RenderContent(objContext, objGraphics);
    }

    /// <summary>Gets the content region.</summary>
    /// <returns></returns>
    protected static Rectangle GetContentRegion(Control objControl) => ControlRenderer.GetContentRegion(objControl, true, true);

    /// <summary>Gets the content region.</summary>
    /// <returns></returns>
    protected static Rectangle GetContentRegion(
      Control objControl,
      bool blnApplyPadding,
      bool blnApplyBorder)
    {
      int x = 0;
      int y = 0;
      int width = 0;
      int height = 0;
      if (objControl != null)
      {
        width = objControl.Width;
        height = objControl.Height;
        if (blnApplyPadding)
        {
          Padding padding = objControl.Padding;
          x += padding.Left;
          y += padding.Top;
          width -= padding.Horizontal;
          height -= padding.Vertical;
        }
        if (blnApplyBorder && objControl.BorderStyle != BorderStyle.None)
        {
          BorderWidth borderWidth = objControl.BorderWidth;
          x += borderWidth.Left;
          y += borderWidth.Top;
          width -= borderWidth.Right + borderWidth.Left;
          height -= borderWidth.Bottom + borderWidth.Top;
        }
        if (width < 0)
          width = 0;
        if (height < 0)
          height = 0;
      }
      return new Rectangle(x, y, width, height);
    }

    /// <summary>Renders the content.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    protected virtual void RenderContent(ControlRenderingContext objContext, Graphics objGraphics)
    {
    }

    /// <summary>Renders the text.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="strText">The text.</param>
    /// <param name="objFont">The font.</param>
    /// <param name="objForeColor">The fore color.</param>
    /// <param name="objRegionSize">The region size.</param>
    /// <param name="enmAlignemnt">The alignemnt.</param>
    /// <param name="blnWrapText">if set to <c>true</c> wrap text.</param>
    protected static RectangleF RenderText(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      string strText,
      Font objFont,
      Color objForeColor,
      Size objRegionSize,
      HorizontalAlignment enmAlignemnt,
      bool blnWrapText)
    {
      return ControlRenderer.RenderText(objContext, objGraphics, strText, objFont, objForeColor, new Rectangle(new Point(0, 0), objRegionSize), enmAlignemnt, blnWrapText);
    }

    /// <summary>Renders the text.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="strText">The text.</param>
    /// <param name="objFont">The font.</param>
    /// <param name="objForeColor">The fore color.</param>
    /// <param name="objRegionSize">The region size.</param>
    /// <param name="enmAlignemnt">The alignemnt.</param>
    /// <param name="blnWrapText">if set to <c>true</c> wrap text.</param>
    protected static RectangleF RenderText(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      string strText,
      Font objFont,
      Color objForeColor,
      Size objRegionSize,
      ContentAlignment enmAlignemnt,
      bool blnWrapText)
    {
      return ControlRenderer.RenderText(objContext, objGraphics, strText, objFont, objForeColor, new Rectangle(new Point(0, 0), objRegionSize), enmAlignemnt, blnWrapText);
    }

    /// <summary>Renders the text.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="strText">The text.</param>
    /// <param name="objFont">The font.</param>
    /// <param name="objForeColor">The fore color.</param>
    /// <param name="objRegion">The region.</param>
    /// <param name="enmAlignemnt">The alignemnt.</param>
    protected static RectangleF RenderText(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      string strText,
      Font objFont,
      Color objForeColor,
      Rectangle objRegion,
      HorizontalAlignment enmAlignemnt,
      bool blnWrapText)
    {
      ContentAlignment enmAlignemnt1 = ContentAlignment.MiddleCenter;
      switch (enmAlignemnt)
      {
        case HorizontalAlignment.Left:
          enmAlignemnt1 = ContentAlignment.MiddleLeft;
          break;
        case HorizontalAlignment.Right:
          enmAlignemnt1 = ContentAlignment.MiddleRight;
          break;
        case HorizontalAlignment.Center:
          enmAlignemnt1 = ContentAlignment.MiddleCenter;
          break;
      }
      return ControlRenderer.RenderText(objContext, objGraphics, strText, objFont, objForeColor, objRegion, enmAlignemnt1, blnWrapText);
    }

    /// <summary>Renders the text.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="strText">The text.</param>
    /// <param name="objFont">The font.</param>
    /// <param name="objForeColor">The fore color.</param>
    /// <param name="objLocation">The location.</param>
    /// <returns></returns>
    protected static RectangleF RenderText(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      string strText,
      Font objFont,
      Color objForeColor,
      Point objLocation)
    {
      return ControlRenderer.RenderText(objContext, objGraphics, strText, objFont, objForeColor, new Rectangle(objLocation, new Size(10, 10)), ContentAlignment.TopLeft, false);
    }

    /// <summary>Renders the text.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="strText">The text.</param>
    /// <param name="objFont">The font.</param>
    /// <param name="objForeColor">The fore color.</param>
    /// <param name="objRegion">The region.</param>
    /// <param name="enmAlignemnt">The alignemnt.</param>
    protected static RectangleF RenderText(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      string strText,
      Font objFont,
      Color objForeColor,
      Rectangle objRegion,
      ContentAlignment enmAlignemnt,
      bool blnWrapText)
    {
      return ControlRenderer.RenderText(objContext, objGraphics, strText, objFont, (Brush) new SolidBrush(objForeColor), objRegion, enmAlignemnt, blnWrapText);
    }

    /// <summary>Renders the text.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="strText">The text.</param>
    /// <param name="objFont">The font.</param>
    /// <param name="objBrush">The brush.</param>
    /// <param name="objLocation">The location.</param>
    /// <returns></returns>
    protected static RectangleF RenderText(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      string strText,
      Font objFont,
      Brush objBrush,
      Point objLocation)
    {
      return ControlRenderer.RenderText(objContext, objGraphics, strText, objFont, objBrush, new Rectangle(objLocation, new Size(10, 10)), ContentAlignment.TopLeft, false);
    }

    /// <summary>Gets a flag indicating if the region is visible</summary>
    /// <param name="objRegion"></param>
    /// <returns></returns>
    protected static bool IsVisibleRegion(Rectangle objRegion) => objRegion.Width > 0 && objRegion.Height > 0;

    /// <summary>Renders the text.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="strText">The text.</param>
    /// <param name="objFont">The font.</param>
    /// <param name="objBrush">The brush.</param>
    /// <param name="objRegion">The region.</param>
    /// <param name="enmAlignemnt">The alignemnt.</param>
    protected static RectangleF RenderText(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      string strText,
      Font objFont,
      Brush objBrush,
      Rectangle objCurrentRegion,
      ContentAlignment enmAlignemnt,
      bool blnWrapText)
    {
      if (objFont == null)
        objFont = SystemFonts.DefaultFont;
      SizeF sizeF = !blnWrapText ? objGraphics.MeasureString(strText, objFont) : objGraphics.MeasureString(strText, objFont, objCurrentRegion.Width);
      PointF contentLocation = ControlRenderer.GetContentLocation(sizeF, objCurrentRegion, enmAlignemnt);
      Region clip = objGraphics.Clip;
      objGraphics.Clip = new Region(objCurrentRegion);
      objGraphics.DrawString(strText, objFont, objBrush, contentLocation);
      objGraphics.Clip = clip;
      return new RectangleF(contentLocation, sizeF);
    }

    /// <summary>Renders the image.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objResourceHandle">The resource handle.</param>
    /// <param name="objLocation">The location.</param>
    protected static RectangleF RenderImage(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      ResourceHandle objResourceHandle,
      Point objLocation)
    {
      return ControlRenderer.RenderImage(objContext, objGraphics, objResourceHandle, new Rectangle(objLocation, new Size(10, 10)), ContentAlignment.TopLeft);
    }

    /// <summary>Renders the image.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objResourceHandle">The resource handle.</param>
    /// <param name="objRegion">The region.</param>
    /// <param name="enmAlignemnt">The alignemnt.</param>
    protected static RectangleF RenderImage(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      ResourceHandle objResourceHandle,
      Rectangle objRegion,
      ContentAlignment enmAlignemnt)
    {
      if (objResourceHandle != null)
      {
        try
        {
          if (objResourceHandle.CanGetImage)
          {
            Image image = objResourceHandle.ToImage();
            if (image != null)
              return ControlRenderer.RenderImage(objContext, objGraphics, image, objRegion, enmAlignemnt);
          }
        }
        catch
        {
        }
      }
      return RectangleF.Empty;
    }

    /// <summary>Renders the image.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objImage">The image.</param>
    /// <param name="objLocation">The location.</param>
    /// <returns></returns>
    protected static RectangleF RenderImage(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      Image objImage,
      Point objLocation)
    {
      return ControlRenderer.RenderImage(objContext, objGraphics, objImage, new Rectangle(objLocation, new Size(10, 10)), ContentAlignment.TopLeft);
    }

    /// <summary>Renders the image.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objImage">The image.</param>
    /// <param name="objRegion">The region.</param>
    /// <param name="enmAlignemnt">The alignemnt.</param>
    protected static RectangleF RenderImage(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      Image objImage,
      Rectangle objRegion,
      ContentAlignment enmAlignemnt)
    {
      if (objImage == null)
        return RectangleF.Empty;
      PointF contentLocation = ControlRenderer.GetContentLocation((SizeF) objImage.Size, objRegion, enmAlignemnt);
      objGraphics.DrawImage(objImage, contentLocation);
      return new RectangleF(contentLocation, (SizeF) objImage.Size);
    }

    /// <summary>Gets the vertical alignment.</summary>
    /// <param name="enmAlignment">The alignment.</param>
    /// <param name="blnIsLeft">if set to <c>true</c> is left.</param>
    /// <returns></returns>
    protected static ContentAlignment GetVerticalAlignment(
      ContentAlignment enmAlignment,
      bool blnIsLeft)
    {
      if (blnIsLeft)
      {
        switch (enmAlignment)
        {
          case ContentAlignment.TopLeft:
          case ContentAlignment.TopCenter:
          case ContentAlignment.TopRight:
            return ContentAlignment.TopLeft;
          case ContentAlignment.MiddleLeft:
          case ContentAlignment.MiddleCenter:
          case ContentAlignment.MiddleRight:
            return ContentAlignment.MiddleLeft;
          case ContentAlignment.BottomLeft:
          case ContentAlignment.BottomCenter:
          case ContentAlignment.BottomRight:
            return ContentAlignment.BottomLeft;
        }
      }
      else
      {
        switch (enmAlignment)
        {
          case ContentAlignment.TopLeft:
          case ContentAlignment.TopCenter:
          case ContentAlignment.TopRight:
            return ContentAlignment.TopRight;
          case ContentAlignment.MiddleLeft:
          case ContentAlignment.MiddleCenter:
          case ContentAlignment.MiddleRight:
            return ContentAlignment.MiddleRight;
          case ContentAlignment.BottomLeft:
          case ContentAlignment.BottomCenter:
          case ContentAlignment.BottomRight:
            return ContentAlignment.BottomRight;
        }
      }
      return enmAlignment;
    }

    /// <summary>Gets the horizontal alignment.</summary>
    /// <param name="enmAlignment">The alignment.</param>
    /// <param name="blnIsTop">if set to <c>true</c> is top.</param>
    /// <returns></returns>
    protected static ContentAlignment GetHorizontalAlignment(
      ContentAlignment enmAlignment,
      bool blnIsTop)
    {
      if (blnIsTop)
      {
        switch (enmAlignment)
        {
          case ContentAlignment.TopLeft:
          case ContentAlignment.MiddleLeft:
          case ContentAlignment.BottomLeft:
            return ContentAlignment.TopLeft;
          case ContentAlignment.TopCenter:
          case ContentAlignment.MiddleCenter:
          case ContentAlignment.BottomCenter:
            return ContentAlignment.TopCenter;
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
          case ContentAlignment.TopLeft:
          case ContentAlignment.MiddleLeft:
          case ContentAlignment.BottomLeft:
            return ContentAlignment.BottomLeft;
          case ContentAlignment.TopCenter:
          case ContentAlignment.MiddleCenter:
          case ContentAlignment.BottomCenter:
            return ContentAlignment.BottomCenter;
          case ContentAlignment.TopRight:
          case ContentAlignment.MiddleRight:
          case ContentAlignment.BottomRight:
            return ContentAlignment.BottomRight;
        }
      }
      return enmAlignment;
    }

    /// <summary>Gets the content location.</summary>
    /// <param name="objContentSize">The content size.</param>
    /// <param name="objRegion">The region size.</param>
    /// <param name="enmAlignemnt">The content alignemnt.</param>
    /// <returns></returns>
    private static PointF GetContentLocation(
      SizeF objContentSize,
      Rectangle objRegion,
      ContentAlignment enmAlignemnt)
    {
      float x = 0.0f;
      float y = 0.0f;
      if (enmAlignemnt <= ContentAlignment.MiddleCenter)
      {
        switch (enmAlignemnt - 1)
        {
          case (ContentAlignment) 0:
            goto label_10;
          case ContentAlignment.TopLeft:
            goto label_11;
          case ContentAlignment.TopCenter:
            goto label_12;
          case ContentAlignment.TopLeft | ContentAlignment.TopCenter:
            break;
          default:
            if (enmAlignemnt != ContentAlignment.MiddleLeft)
            {
              if (enmAlignemnt == ContentAlignment.MiddleCenter)
                goto label_11;
              else
                goto label_12;
            }
            else
              goto label_10;
        }
      }
      else if (enmAlignemnt <= ContentAlignment.BottomLeft)
      {
        if (enmAlignemnt != ContentAlignment.MiddleRight)
        {
          if (enmAlignemnt == ContentAlignment.BottomLeft)
            goto label_10;
          else
            goto label_12;
        }
      }
      else if (enmAlignemnt != ContentAlignment.BottomCenter)
      {
        if (enmAlignemnt != ContentAlignment.BottomRight)
          goto label_12;
      }
      else
        goto label_11;
      x = (float) objRegion.Right - objContentSize.Width;
      goto label_12;
label_10:
      x = (float) objRegion.Left;
      goto label_12;
label_11:
      x = (float) (objRegion.Left + objRegion.Width / 2) - objContentSize.Width / 2f;
label_12:
      if (enmAlignemnt <= ContentAlignment.MiddleCenter)
      {
        switch (enmAlignemnt - 1)
        {
          case (ContentAlignment) 0:
          case ContentAlignment.TopLeft:
          case ContentAlignment.TopLeft | ContentAlignment.TopCenter:
            y = (float) objRegion.Top;
            goto label_22;
          case ContentAlignment.TopCenter:
            goto label_22;
          default:
            if (enmAlignemnt == ContentAlignment.MiddleLeft || enmAlignemnt == ContentAlignment.MiddleCenter)
              break;
            goto label_22;
        }
      }
      else
      {
        if (enmAlignemnt <= ContentAlignment.BottomLeft)
        {
          if (enmAlignemnt != ContentAlignment.MiddleRight)
          {
            if (enmAlignemnt != ContentAlignment.BottomLeft)
              goto label_22;
          }
          else
            goto label_21;
        }
        else if (enmAlignemnt != ContentAlignment.BottomCenter && enmAlignemnt != ContentAlignment.BottomRight)
          goto label_22;
        y = (float) objRegion.Bottom - objContentSize.Height;
        goto label_22;
      }
label_21:
      y = (float) (objRegion.Top + objRegion.Height / 2) - objContentSize.Height / 2f;
label_22:
      return new PointF(x, y);
    }

    /// <summary>Docks the in region.</summary>
    /// <param name="objRegion">The region.</param>
    /// <param name="enmDock">The dock.</param>
    /// <param name="objRectangleF">The docked rectangle.</param>
    /// <returns></returns>
    protected static Rectangle DockInRegion(
      Rectangle objRegion,
      DockStyle enmDock,
      RectangleF objRectangleF)
    {
      return ControlRenderer.DockInRegion(objRegion, enmDock, Rectangle.Truncate(objRectangleF));
    }

    /// <summary>Docks the in region.</summary>
    /// <param name="objRegion">The region.</param>
    /// <param name="enmDock">The dock.</param>
    /// <param name="objRectangle">The docked rectangle.</param>
    /// <returns></returns>
    protected static Rectangle DockInRegion(
      Rectangle objRegion,
      DockStyle enmDock,
      Rectangle objRectangle)
    {
      return ControlRenderer.DockInRegion(objRegion, enmDock, objRectangle.Size);
    }

    /// <summary>Docks the in region.</summary>
    /// <param name="objRegion">The region.</param>
    /// <param name="enmDock">The dock.</param>
    /// <param name="objSize">The docked size.</param>
    /// <returns></returns>
    protected static Rectangle DockInRegion(Rectangle objRegion, DockStyle enmDock, SizeF objSize) => ControlRenderer.DockInRegion(objRegion, enmDock, Size.Truncate(objSize));

    /// <summary>Docks the in region.</summary>
    /// <param name="objRegion">The region.</param>
    /// <param name="enmDock">The dock.</param>
    /// <param name="objSize">The docked size.</param>
    /// <returns></returns>
    protected static Rectangle DockInRegion(Rectangle objRegion, DockStyle enmDock, Size objSize)
    {
      int x = objRegion.X;
      int y = objRegion.Y;
      int height = objRegion.Height;
      int width = objRegion.Width;
      switch (enmDock)
      {
        case DockStyle.Top:
          y += objSize.Height;
          height -= objSize.Height;
          break;
        case DockStyle.Right:
          width -= objSize.Width;
          break;
        case DockStyle.Bottom:
          height -= objSize.Height;
          break;
        case DockStyle.Left:
          x += objSize.Width;
          width -= objSize.Width;
          break;
      }
      if (height < 0)
        height = 0;
      if (width < 0)
        width = 0;
      return new Rectangle(x, y, width, height);
    }

    /// <summary>Renders the border.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    protected virtual void RenderBorder(ControlRenderingContext objContext, Graphics objGraphics)
    {
      switch (this.mobjControl.BorderStyle)
      {
        case BorderStyle.None:
          break;
        case BorderStyle.Clear:
          break;
        default:
          int height = this.mobjControl.Height;
          int width = this.mobjControl.Width;
          if (height <= 2 || width <= 2)
            break;
          objGraphics.DrawRectangle(new Pen((Color) this.mobjControl.BorderColor, 1f), new Rectangle(0, 0, width - 2, height - 2));
          break;
      }
    }

    /// <summary>Renders the background.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    protected virtual void RenderBackground(
      ControlRenderingContext objContext,
      Graphics objGraphics)
    {
      this.RenderBackgroundColor(objContext, objGraphics);
      this.RenderBackgroundImage(objContext, objGraphics);
    }

    /// <summary>Renders the background image.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    protected virtual void RenderBackgroundImage(
      ControlRenderingContext objContext,
      Graphics objGraphics)
    {
    }

    /// <summary>Renders the background color.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    protected virtual void RenderBackgroundColor(
      ControlRenderingContext objContext,
      Graphics objGraphics)
    {
      objGraphics.DrawRectangle(new Pen(this.mobjControl.BackColor), new Rectangle(new Point(0, 0), this.mobjControl.Size));
    }

    /// <summary>Renders the controls.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    protected virtual void RenderControls(ControlRenderingContext objContext, Graphics objGraphics)
    {
      foreach (Control control in (ArrangedElementCollection) this.mobjControl.Controls)
      {
        Bitmap bitmap = control.DrawControl(objContext, control.Width, control.Height);
        if (bitmap != null)
          objGraphics.DrawImage((Image) bitmap, control.Location);
      }
    }

    /// <summary>Renders the frame.</summary>
    /// <param name="objGraphics">The obj graphics.</param>
    /// <param name="objFrameStyle">The frame style.</param>
    /// <param name="objRegion">The region.</param>
    protected static void RenderFrame(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      Skin objSkin,
      FrameStyleValue objFrameStyle,
      Rectangle objRegion)
    {
      ResourceHandle handleFromReference1 = objSkin.GetResourceHandleFromReference((SkinResourceReference) objFrameStyle.LeftTopStyle.BackgroundImage);
      ResourceHandle handleFromReference2 = objSkin.GetResourceHandleFromReference((SkinResourceReference) objFrameStyle.RightTopStyle.BackgroundImage);
      ResourceHandle handleFromReference3 = objSkin.GetResourceHandleFromReference((SkinResourceReference) objFrameStyle.LeftBottomStyle.BackgroundImage);
      ResourceHandle handleFromReference4 = objSkin.GetResourceHandleFromReference((SkinResourceReference) objFrameStyle.RightBottomStyle.BackgroundImage);
      Rectangle rectangle1 = Rectangle.Truncate(ControlRenderer.RenderImage(objContext, objGraphics, handleFromReference1, objRegion, ContentAlignment.TopLeft));
      Rectangle rectangle2 = Rectangle.Truncate(ControlRenderer.RenderImage(objContext, objGraphics, handleFromReference2, objRegion, ContentAlignment.TopRight));
      Rectangle rectangle3 = Rectangle.Truncate(ControlRenderer.RenderImage(objContext, objGraphics, handleFromReference3, objRegion, ContentAlignment.BottomLeft));
      Rectangle.Truncate(ControlRenderer.RenderImage(objContext, objGraphics, handleFromReference4, objRegion, ContentAlignment.BottomRight));
      ResourceHandle handleFromReference5 = objSkin.GetResourceHandleFromReference((SkinResourceReference) objFrameStyle.LeftStyle.BackgroundImage);
      ResourceHandle handleFromReference6 = objSkin.GetResourceHandleFromReference((SkinResourceReference) objFrameStyle.RightStyle.BackgroundImage);
      ResourceHandle handleFromReference7 = objSkin.GetResourceHandleFromReference((SkinResourceReference) objFrameStyle.TopStyle.BackgroundImage);
      ResourceHandle handleFromReference8 = objSkin.GetResourceHandleFromReference((SkinResourceReference) objFrameStyle.BottomStyle.BackgroundImage);
      int width1 = rectangle1.Width;
      int width2 = rectangle2.Width;
      int height1 = rectangle1.Height;
      int height2 = rectangle3.Height;
      Rectangle objRegion1 = new Rectangle(objRegion.Left, objRegion.Top + height1, width1, Math.Max(objRegion.Height - height1 - height2, 0));
      Rectangle objRegion2 = new Rectangle(objRegion.Right - width2, objRegion.Top + height1, width2, Math.Max(objRegion.Height - height1 - height2, 0));
      Rectangle objRegion3 = new Rectangle(objRegion.Left + width1, objRegion.Top, Math.Max(objRegion.Width - width1 - width2, 0), height1);
      Rectangle objRegion4 = new Rectangle(objRegion.Left + width1, objRegion.Bottom - height2, Math.Max(objRegion.Width - width1 - width2, 0), height2);
      ControlRenderer.RenderStyle(objContext, objGraphics, objSkin, objFrameStyle.CenterStyle, new Rectangle(objRegion.Left + width1, objRegion.Top + height1, Math.Max(objRegion.Width - width1 - width2, 0), Math.Max(objRegion.Height - height1 - height2, 0)));
      ControlRenderer.RenderRepeatedImage(objContext, objGraphics, handleFromReference5, objRegion1, BackgroundImageRepeat.RepeatY, BackgroundImagePosition.TopLeft);
      ControlRenderer.RenderRepeatedImage(objContext, objGraphics, handleFromReference6, objRegion2, BackgroundImageRepeat.RepeatY, BackgroundImagePosition.TopRight);
      ControlRenderer.RenderRepeatedImage(objContext, objGraphics, handleFromReference7, objRegion3, BackgroundImageRepeat.RepeatX, BackgroundImagePosition.TopLeft);
      ControlRenderer.RenderRepeatedImage(objContext, objGraphics, handleFromReference8, objRegion4, BackgroundImageRepeat.RepeatX, BackgroundImagePosition.BottomLeft);
    }

    /// <summary>Renders the style.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objSkin">The skin.</param>
    /// <param name="objStyle">The style.</param>
    /// <param name="objRegion">The region.</param>
    protected static void RenderStyle(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      Skin objSkin,
      StyleValue objStyle,
      Rectangle objRegion)
    {
      try
      {
        ResourceHandle handleFromReference = objSkin.GetResourceHandleFromReference((SkinResourceReference) objStyle.BackgroundImage);
        if (handleFromReference == null)
          return;
        ControlRenderer.RenderRepeatedImage(objContext, objGraphics, handleFromReference, objRegion, objStyle.BackgroundImageRepeat, objStyle.BackgroundImagePosition);
      }
      catch
      {
      }
    }

    /// <summary>Renders the repeated image.</summary>
    /// <param name="objContext">The context.</param>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objResourceHandle">The resource handle.</param>
    /// <param name="objRegion">The region.</param>
    /// <param name="enmImageRepeat">The image repeat.</param>
    /// <param name="enmImagePosition">The image position.</param>
    protected static void RenderRepeatedImage(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      ResourceHandle objResourceHandle,
      Rectangle objRegion,
      BackgroundImageRepeat enmImageRepeat,
      BackgroundImagePosition enmImagePosition)
    {
      if (objResourceHandle == null)
        return;
      Image resourceImage = objContext.GetResourceImage(objResourceHandle);
      if (resourceImage == null)
        return;
      ControlRenderer.RenderRepeatedImage(objContext, objGraphics, resourceImage, objRegion, enmImageRepeat, enmImagePosition);
    }

    /// <summary>Renders the repeated image.</summary>
    /// <param name="objGraphics">The graphics.</param>
    /// <param name="objImage">The image.</param>
    /// <param name="objRegion">The region.</param>
    /// <param name="enmImageRepeat">The image repeat.</param>
    /// <param name="enmImagePosition">The image position.</param>
    protected static void RenderRepeatedImage(
      ControlRenderingContext objContext,
      Graphics objGraphics,
      Image objImage,
      Rectangle objRegion,
      BackgroundImageRepeat enmImageRepeat,
      BackgroundImagePosition enmImagePosition)
    {
      if (objImage == null)
        return;
      TextureBrush textureBrush1;
      TextureBrush textureBrush2 = textureBrush1 = new TextureBrush(objImage, WrapMode.Tile);
      switch (enmImageRepeat)
      {
        case BackgroundImageRepeat.RepeatX:
          switch (enmImagePosition)
          {
            case BackgroundImagePosition.BottomCenter:
            case BackgroundImagePosition.BottomLeft:
            case BackgroundImagePosition.BottomRight:
              ref Rectangle local1 = ref objRegion;
              local1.Y = local1.Bottom - objImage.Height;
              objRegion.Height = Math.Min(objRegion.Height, objImage.Height);
              break;
            case BackgroundImagePosition.MiddleCenter:
            case BackgroundImagePosition.MiddleLeft:
            case BackgroundImagePosition.MiddleRight:
              objRegion.Y += objRegion.Height / 2 - objRegion.Height / 2;
              objRegion.Height = Math.Min(objRegion.Height, objImage.Height);
              break;
            case BackgroundImagePosition.TopCenter:
            case BackgroundImagePosition.TopLeft:
            case BackgroundImagePosition.TopRight:
              objRegion.Height = Math.Min(objRegion.Height, objImage.Height);
              break;
          }
          break;
        case BackgroundImageRepeat.RepeatY:
          switch (enmImagePosition)
          {
            case BackgroundImagePosition.BottomCenter:
            case BackgroundImagePosition.MiddleCenter:
            case BackgroundImagePosition.TopCenter:
              objRegion.X += objRegion.Width / 2 - objRegion.Width / 2;
              objRegion.Width = Math.Min(objRegion.Width, objImage.Width);
              break;
            case BackgroundImagePosition.BottomLeft:
            case BackgroundImagePosition.MiddleLeft:
            case BackgroundImagePosition.TopLeft:
              objRegion.Width = Math.Min(objRegion.Width, objImage.Width);
              break;
            case BackgroundImagePosition.BottomRight:
            case BackgroundImagePosition.MiddleRight:
            case BackgroundImagePosition.TopRight:
              ref Rectangle local2 = ref objRegion;
              local2.X = local2.Right - objImage.Width;
              objRegion.Width = Math.Min(objRegion.Width, objImage.Width);
              break;
          }
          break;
      }
      objGraphics.FillRectangle((Brush) textureBrush2, objRegion);
    }

    /// <summary>Gets the control.</summary>
    public Control Control => this.mobjControl;
  }
}
