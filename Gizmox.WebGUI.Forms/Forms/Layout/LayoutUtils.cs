// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Layout.LayoutUtils
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.Drawing;

namespace Gizmox.WebGUI.Forms.Layout
{
  [Serializable]
  internal class LayoutUtils
  {
    public const ContentAlignment AnyBottom = ContentAlignment.BottomLeft | ContentAlignment.BottomCenter | ContentAlignment.BottomRight;
    public const ContentAlignment AnyCenter = ContentAlignment.TopCenter | ContentAlignment.MiddleCenter | ContentAlignment.BottomCenter;
    public const ContentAlignment AnyLeft = ContentAlignment.TopLeft | ContentAlignment.MiddleLeft | ContentAlignment.BottomLeft;
    public const ContentAlignment AnyMiddle = ContentAlignment.MiddleLeft | ContentAlignment.MiddleCenter | ContentAlignment.MiddleRight;
    public const ContentAlignment AnyRight = ContentAlignment.TopRight | ContentAlignment.MiddleRight | ContentAlignment.BottomRight;
    public const ContentAlignment AnyTop = ContentAlignment.TopLeft | ContentAlignment.TopCenter | ContentAlignment.TopRight;
    private static readonly AnchorStyles[] marrDockingToAnchor = new AnchorStyles[6]
    {
      AnchorStyles.Left | AnchorStyles.Top,
      AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
      AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
      AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top,
      AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top,
      AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
    };
    public const AnchorStyles HorizontalAnchorStyles = AnchorStyles.Left | AnchorStyles.Right;
    public static readonly Size InvalidSize = new Size(int.MinValue, int.MinValue);
    public static readonly Rectangle MaxRectangle = new Rectangle(0, 0, int.MaxValue, int.MaxValue);
    public static readonly Size MaxSize = new Size(int.MaxValue, int.MaxValue);
    public static readonly string TestString = "j^";
    public const AnchorStyles VerticalAnchorStyles = AnchorStyles.Bottom | AnchorStyles.Top;

    public static Size AddAlignedRegion(
      Size objTextSize,
      Size objImageSize,
      TextImageRelation enmRelation)
    {
      return LayoutUtils.AddAlignedRegionCore(objTextSize, objImageSize, LayoutUtils.IsVerticalRelation(enmRelation));
    }

    public static Size AddAlignedRegionCore(
      Size objCurrentSize,
      Size objContentSize,
      bool blnVertical)
    {
      if (blnVertical)
      {
        objCurrentSize.Width = Math.Max(objCurrentSize.Width, objContentSize.Width);
        objCurrentSize.Height += objContentSize.Height;
        return objCurrentSize;
      }
      objCurrentSize.Width += objContentSize.Width;
      objCurrentSize.Height = Math.Max(objCurrentSize.Height, objContentSize.Height);
      return objCurrentSize;
    }

    public static Rectangle Align(
      Size objAlignThis,
      Rectangle objWithinThis,
      ContentAlignment enmAlign)
    {
      return LayoutUtils.VAlign(objAlignThis, LayoutUtils.HAlign(objAlignThis, objWithinThis, enmAlign), enmAlign);
    }

    public static Rectangle Align(
      Size objAlignThis,
      Rectangle objWithinThis,
      AnchorStyles enmAnchorStyles)
    {
      return LayoutUtils.VAlign(objAlignThis, LayoutUtils.HAlign(objAlignThis, objWithinThis, enmAnchorStyles), enmAnchorStyles);
    }

    public static Rectangle AlignAndStretch(
      Size objFitThis,
      Rectangle objWithinThis,
      AnchorStyles enmAnchorStyles)
    {
      return LayoutUtils.Align(LayoutUtils.Stretch(objFitThis, objWithinThis.Size, enmAnchorStyles), objWithinThis, enmAnchorStyles);
    }

    public static bool AreWidthAndHeightLarger(Size objSize1, Size objSize2) => objSize1.Width >= objSize2.Width && objSize1.Height >= objSize2.Height;

    public static Padding ClampNegativePaddingToZero(Padding objPadding)
    {
      if (objPadding.All < 0)
      {
        objPadding.Left = Math.Max(0, objPadding.Left);
        objPadding.Top = Math.Max(0, objPadding.Top);
        objPadding.Right = Math.Max(0, objPadding.Right);
        objPadding.Bottom = Math.Max(0, objPadding.Bottom);
      }
      return objPadding;
    }

    public static int ContentAlignmentToIndex(ContentAlignment enmAlignment)
    {
      int index1 = (int) LayoutUtils.xContentAlignmentToIndex((int) (enmAlignment & (ContentAlignment) 15));
      int index2 = (int) LayoutUtils.xContentAlignmentToIndex((int) enmAlignment >> 4 & 15);
      int index3 = (int) LayoutUtils.xContentAlignmentToIndex((int) enmAlignment >> 8 & 15);
      return ((index2 != 0 ? 4 : 0) | (index3 != 0 ? 8 : 0) | index1 | index2 | index3) - 1;
    }

    public static Size ConvertZeroToUnbounded(Size objSize)
    {
      if (objSize.Width == 0)
        objSize.Width = int.MaxValue;
      if (objSize.Height == 0)
        objSize.Height = int.MaxValue;
      return objSize;
    }

    public static Rectangle DeflateRect(Rectangle objRect, Padding objPadding)
    {
      objRect.X += objPadding.Left;
      objRect.Y += objPadding.Top;
      objRect.Width -= objPadding.Horizontal;
      objRect.Height -= objPadding.Vertical;
      return objRect;
    }

    public static void ExpandRegionsToFillBounds(
      Rectangle objBounds,
      AnchorStyles enmRegion1Align,
      ref Rectangle objRegion1,
      ref Rectangle objRegion2)
    {
      switch (enmRegion1Align)
      {
        case AnchorStyles.Top:
          objRegion1 = LayoutUtils.SubstituteSpecifiedBounds(objBounds, objRegion1, AnchorStyles.Bottom);
          objRegion2 = LayoutUtils.SubstituteSpecifiedBounds(objBounds, objRegion2, AnchorStyles.Top);
          break;
        case AnchorStyles.Bottom:
          objRegion1 = LayoutUtils.SubstituteSpecifiedBounds(objBounds, objRegion1, AnchorStyles.Top);
          objRegion2 = LayoutUtils.SubstituteSpecifiedBounds(objBounds, objRegion2, AnchorStyles.Bottom);
          break;
        case AnchorStyles.Left:
          objRegion1 = LayoutUtils.SubstituteSpecifiedBounds(objBounds, objRegion1, AnchorStyles.Right);
          objRegion2 = LayoutUtils.SubstituteSpecifiedBounds(objBounds, objRegion2, AnchorStyles.Left);
          break;
        case AnchorStyles.Right:
          objRegion1 = LayoutUtils.SubstituteSpecifiedBounds(objBounds, objRegion1, AnchorStyles.Left);
          objRegion2 = LayoutUtils.SubstituteSpecifiedBounds(objBounds, objRegion2, AnchorStyles.Right);
          break;
      }
    }

    public static Padding FlipPadding(Padding objPadding)
    {
      if (objPadding.All == -1)
      {
        int top = objPadding.Top;
        ref Padding local1 = ref objPadding;
        local1.Top = local1.Left;
        objPadding.Left = top;
        int bottom = objPadding.Bottom;
        ref Padding local2 = ref objPadding;
        local2.Bottom = local2.Right;
        objPadding.Right = bottom;
      }
      return objPadding;
    }

    public static Point FlipPoint(Point objPoint)
    {
      int x = objPoint.X;
      ref Point local = ref objPoint;
      local.X = local.Y;
      objPoint.Y = x;
      return objPoint;
    }

    public static Rectangle FlipRectangle(Rectangle objRect)
    {
      objRect.Location = LayoutUtils.FlipPoint(objRect.Location);
      objRect.Size = LayoutUtils.FlipSize(objRect.Size);
      return objRect;
    }

    public static Rectangle FlipRectangleIf(bool blnCondition, Rectangle objRect) => !blnCondition ? objRect : LayoutUtils.FlipRectangle(objRect);

    public static Size FlipSize(Size objSize)
    {
      int width = objSize.Width;
      ref Size local = ref objSize;
      local.Width = local.Height;
      objSize.Height = width;
      return objSize;
    }

    public static Size FlipSizeIf(bool blnCondition, Size objSize) => !blnCondition ? objSize : LayoutUtils.FlipSize(objSize);

    private static AnchorStyles GetOppositeAnchor(AnchorStyles enmAnchor) => AnchorStyles.None;

    public static TextImageRelation GetOppositeTextImageRelation(TextImageRelation enmRelation) => TextImageRelation.Overlay;

    internal static AnchorStyles GetUnifiedAnchor(IArrangedElement objElement) => AnchorStyles.Left | AnchorStyles.Top;

    private static Rectangle HAlign(
      Size objAlignThis,
      Rectangle objWithinThis,
      ContentAlignment enmAlign)
    {
      if ((enmAlign & (ContentAlignment.TopRight | ContentAlignment.MiddleRight | ContentAlignment.BottomRight)) != (ContentAlignment) 0)
        objWithinThis.X += objWithinThis.Width - objAlignThis.Width;
      else if ((enmAlign & (ContentAlignment.TopCenter | ContentAlignment.MiddleCenter | ContentAlignment.BottomCenter)) != (ContentAlignment) 0)
        objWithinThis.X += (objWithinThis.Width - objAlignThis.Width) / 2;
      objWithinThis.Width = objAlignThis.Width;
      return objWithinThis;
    }

    public static Rectangle HAlign(
      Size objAlignThis,
      Rectangle objWithinThis,
      AnchorStyles enmAnchorStyles)
    {
      if ((enmAnchorStyles & AnchorStyles.Right) != AnchorStyles.None)
        objWithinThis.X += objWithinThis.Width - objAlignThis.Width;
      else if (enmAnchorStyles == AnchorStyles.None || (enmAnchorStyles & (AnchorStyles.Left | AnchorStyles.Right)) == AnchorStyles.None)
        objWithinThis.X += (objWithinThis.Width - objAlignThis.Width) / 2;
      objWithinThis.Width = objAlignThis.Width;
      return objWithinThis;
    }

    public static Rectangle InflateRect(Rectangle objRect, Padding objPadding)
    {
      objRect.X -= objPadding.Left;
      objRect.Y -= objPadding.Top;
      objRect.Width += objPadding.Horizontal;
      objRect.Height += objPadding.Vertical;
      return objRect;
    }

    public static Size IntersectSizes(Size objA, Size objB) => new Size(Math.Min(objA.Width, objB.Width), Math.Min(objA.Height, objB.Height));

    public static bool IsHorizontalAlignment(ContentAlignment enmAlign) => !LayoutUtils.IsVerticalAlignment(enmAlign);

    public static bool IsHorizontalRelation(TextImageRelation enmRelation) => (enmRelation & (TextImageRelation.ImageBeforeText | TextImageRelation.TextBeforeImage)) != 0;

    public static bool IsIntersectHorizontally(Rectangle objRect1, Rectangle objRect2)
    {
      if (!objRect1.IntersectsWith(objRect2))
        return false;
      if (objRect1.X <= objRect2.X && objRect1.X + objRect1.Width >= objRect2.X + objRect2.Width)
        return true;
      return objRect2.X <= objRect1.X && objRect2.X + objRect2.Width >= objRect1.X + objRect1.Width;
    }

    public static bool IsIntersectVertically(Rectangle objRect1, Rectangle objRect2)
    {
      if (!objRect1.IntersectsWith(objRect2))
        return false;
      if (objRect1.Y <= objRect2.Y && objRect1.Y + objRect1.Width >= objRect2.Y + objRect2.Width)
        return true;
      return objRect2.Y <= objRect1.Y && objRect2.Y + objRect2.Width >= objRect1.Y + objRect1.Width;
    }

    public static bool IsVerticalAlignment(ContentAlignment enmAlign) => (enmAlign & (ContentAlignment.TopCenter | ContentAlignment.BottomCenter)) != 0;

    public static bool IsVerticalRelation(TextImageRelation enmRelation) => (enmRelation & (TextImageRelation.ImageAboveText | TextImageRelation.TextAboveImage)) != 0;

    public static bool IsZeroWidthOrHeight(Rectangle objRectangle) => objRectangle.Width == 0 || objRectangle.Height == 0;

    public static bool IsZeroWidthOrHeight(Size objSize) => objSize.Width == 0 || objSize.Height == 0;

    public static Size OldGetLargestStringSizeInCollection(Font objFont, ICollection objCollection)
    {
      Size empty = Size.Empty;
      if (objCollection != null)
      {
        foreach (object obj in (IEnumerable) objCollection)
        {
          Size stringMeasurements = CommonUtils.GetStringMeasurements(obj.ToString(), objFont);
          empty.Width = Math.Max(empty.Width, stringMeasurements.Width);
          empty.Height = Math.Max(empty.Height, stringMeasurements.Height);
        }
      }
      return empty;
    }

    public static Rectangle RTLTranslate(Rectangle objBounds, Rectangle objWithinBounds)
    {
      objBounds.X = objWithinBounds.Width - objBounds.Right;
      return objBounds;
    }

    public static void SplitRegion(
      Rectangle objBounds,
      Size objSpecifiedContent,
      AnchorStyles enmRegion1Align,
      out Rectangle objRegion1,
      out Rectangle objRegion2)
    {
      objRegion1 = objRegion2 = objBounds;
      switch (enmRegion1Align)
      {
        case AnchorStyles.Top:
          objRegion1.Height = objSpecifiedContent.Height;
          objRegion2.Y += objSpecifiedContent.Height;
          objRegion2.Height -= objSpecifiedContent.Height;
          break;
        case AnchorStyles.Bottom:
          objRegion1.Y += objBounds.Height - objSpecifiedContent.Height;
          objRegion1.Height = objSpecifiedContent.Height;
          objRegion2.Height -= objSpecifiedContent.Height;
          break;
        case AnchorStyles.Left:
          objRegion1.Width = objSpecifiedContent.Width;
          objRegion2.X += objSpecifiedContent.Width;
          objRegion2.Width -= objSpecifiedContent.Width;
          break;
        case AnchorStyles.Right:
          objRegion1.X += objBounds.Width - objSpecifiedContent.Width;
          objRegion1.Width = objSpecifiedContent.Width;
          objRegion2.Width -= objSpecifiedContent.Width;
          break;
      }
    }

    public static Size Stretch(
      Size objStretchThis,
      Size objWithinThis,
      AnchorStyles enmAnchorStyles)
    {
      Size size = new Size((enmAnchorStyles & (AnchorStyles.Left | AnchorStyles.Right)) == (AnchorStyles.Left | AnchorStyles.Right) ? objWithinThis.Width : objStretchThis.Width, (enmAnchorStyles & (AnchorStyles.Bottom | AnchorStyles.Top)) == (AnchorStyles.Bottom | AnchorStyles.Top) ? objWithinThis.Height : objStretchThis.Height);
      if (size.Width > objWithinThis.Width)
        size.Width = objWithinThis.Width;
      if (size.Height > objWithinThis.Height)
        size.Height = objWithinThis.Height;
      return size;
    }

    public static Size SubAlignedRegion(
      Size objCurrentSize,
      Size objContentSize,
      TextImageRelation enmRelation)
    {
      return LayoutUtils.SubAlignedRegionCore(objCurrentSize, objContentSize, LayoutUtils.IsVerticalRelation(enmRelation));
    }

    public static Size SubAlignedRegionCore(
      Size objCurrentSize,
      Size objContentSize,
      bool blnVertical)
    {
      if (blnVertical)
      {
        objCurrentSize.Height -= objContentSize.Height;
        return objCurrentSize;
      }
      objCurrentSize.Width -= objContentSize.Width;
      return objCurrentSize;
    }

    private static Rectangle SubstituteSpecifiedBounds(
      Rectangle objOriginalBounds,
      Rectangle objSubstitutionBounds,
      AnchorStyles enmSpecified)
    {
      int left = (enmSpecified & AnchorStyles.Left) != AnchorStyles.None ? objSubstitutionBounds.Left : objOriginalBounds.Left;
      int num1 = (enmSpecified & AnchorStyles.Top) != AnchorStyles.None ? objSubstitutionBounds.Top : objOriginalBounds.Top;
      int num2 = (enmSpecified & AnchorStyles.Right) != AnchorStyles.None ? objSubstitutionBounds.Right : objOriginalBounds.Right;
      int num3 = (enmSpecified & AnchorStyles.Bottom) != AnchorStyles.None ? objSubstitutionBounds.Bottom : objOriginalBounds.Bottom;
      int top = num1;
      int right = num2;
      int bottom = num3;
      return Rectangle.FromLTRB(left, top, right, bottom);
    }

    public static Size UnionSizes(Size objA, Size objB) => new Size(Math.Max(objA.Width, objB.Width), Math.Max(objA.Height, objB.Height));

    public static Rectangle VAlign(
      Size objAlignThis,
      Rectangle objWithinThis,
      ContentAlignment enmAlign)
    {
      if ((enmAlign & (ContentAlignment.BottomLeft | ContentAlignment.BottomCenter | ContentAlignment.BottomRight)) != (ContentAlignment) 0)
        objWithinThis.Y += objWithinThis.Height - objAlignThis.Height;
      else if ((enmAlign & (ContentAlignment.MiddleLeft | ContentAlignment.MiddleCenter | ContentAlignment.MiddleRight)) != (ContentAlignment) 0)
        objWithinThis.Y += (objWithinThis.Height - objAlignThis.Height) / 2;
      objWithinThis.Height = objAlignThis.Height;
      return objWithinThis;
    }

    public static Rectangle VAlign(
      Size objAlignThis,
      Rectangle objWithinThis,
      AnchorStyles enmAnchorStyles)
    {
      if ((enmAnchorStyles & AnchorStyles.Bottom) != AnchorStyles.None)
        objWithinThis.Y += objWithinThis.Height - objAlignThis.Height;
      else if (enmAnchorStyles == AnchorStyles.None || (enmAnchorStyles & (AnchorStyles.Bottom | AnchorStyles.Top)) == AnchorStyles.None)
        objWithinThis.Y += (objWithinThis.Height - objAlignThis.Height) / 2;
      objWithinThis.Height = objAlignThis.Height;
      return objWithinThis;
    }

    private static byte xContentAlignmentToIndex(int intThreeBitFlag) => intThreeBitFlag != 4 ? (byte) intThreeBitFlag : (byte) 3;

    [Serializable]
    public sealed class MeasureTextCache
    {
      private const int mcntMaxCacheSize = 6;
      private int mintNextCacheEntry = -1;
      private LayoutUtils.MeasureTextCache.PreferredSizeCache[] marrSizeCacheList;
      private Size mobjUnconstrainedPreferredSize = LayoutUtils.InvalidSize;

      public Size GetTextSize(
        string strText,
        Font objFont,
        Size objProposedConstraints,
        TextFormatFlags enmFlags)
      {
        if (!this.TextRequiresWordBreak(strText, objFont, objProposedConstraints, enmFlags))
          return this.mobjUnconstrainedPreferredSize;
        if (this.marrSizeCacheList == null)
          this.marrSizeCacheList = new LayoutUtils.MeasureTextCache.PreferredSizeCache[6];
        foreach (LayoutUtils.MeasureTextCache.PreferredSizeCache marrSizeCache in this.marrSizeCacheList)
        {
          if (marrSizeCache.mobjConstrainingSize == objProposedConstraints || marrSizeCache.mobjConstrainingSize.Width == objProposedConstraints.Width && marrSizeCache.mobjPreferredSize.Height <= objProposedConstraints.Height)
            return marrSizeCache.mobjPreferredSize;
        }
        Size stringMeasurements = CommonUtils.GetStringMeasurements(strText, objFont);
        this.mintNextCacheEntry = (this.mintNextCacheEntry + 1) % 6;
        this.marrSizeCacheList[this.mintNextCacheEntry] = new LayoutUtils.MeasureTextCache.PreferredSizeCache(objProposedConstraints, stringMeasurements);
        return stringMeasurements;
      }

      private Size GetUnconstrainedSize(string strText, Font objFont, TextFormatFlags enmFlags)
      {
        if (this.mobjUnconstrainedPreferredSize == LayoutUtils.InvalidSize)
        {
          enmFlags &= ~TextFormatFlags.WordBreak;
          this.mobjUnconstrainedPreferredSize = CommonUtils.GetStringMeasurements(strText, objFont);
        }
        return this.mobjUnconstrainedPreferredSize;
      }

      public void InvalidateCache()
      {
        this.mobjUnconstrainedPreferredSize = LayoutUtils.InvalidSize;
        this.marrSizeCacheList = (LayoutUtils.MeasureTextCache.PreferredSizeCache[]) null;
      }

      public bool TextRequiresWordBreak(
        string strText,
        Font objFont,
        Size objSize,
        TextFormatFlags enmFlags)
      {
        return this.GetUnconstrainedSize(strText, objFont, enmFlags).Width > objSize.Width;
      }

      [Serializable]
      private struct PreferredSizeCache
      {
        public Size mobjConstrainingSize;
        public Size mobjPreferredSize;

        public PreferredSizeCache(Size objConstrainingSize, Size objPreferredSize)
        {
          this.mobjConstrainingSize = objConstrainingSize;
          this.mobjPreferredSize = objPreferredSize;
        }
      }
    }
  }
}
