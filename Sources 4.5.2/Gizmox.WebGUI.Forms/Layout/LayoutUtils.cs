using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections;

namespace Gizmox.WebGUI.Forms.Layout
{
    [Serializable()]
    internal class LayoutUtils
    {
        public const ContentAlignment AnyBottom = (ContentAlignment.BottomRight | ContentAlignment.BottomCenter | ContentAlignment.BottomLeft);
        public const ContentAlignment AnyCenter = (ContentAlignment.BottomCenter | ContentAlignment.MiddleCenter | ContentAlignment.TopCenter);
        public const ContentAlignment AnyLeft = (ContentAlignment.BottomLeft | ContentAlignment.MiddleLeft | ContentAlignment.TopLeft);
        public const ContentAlignment AnyMiddle = (ContentAlignment.MiddleRight | ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft);
        public const ContentAlignment AnyRight = (ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight);
        public const ContentAlignment AnyTop = (ContentAlignment.TopRight | ContentAlignment.TopCenter | ContentAlignment.TopLeft);
        private static readonly AnchorStyles[] marrDockingToAnchor = new AnchorStyles[] { (AnchorStyles.Left | AnchorStyles.Top), (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top), (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom), (AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top), (AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top), (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top) };
        public const AnchorStyles HorizontalAnchorStyles = (AnchorStyles.Right | AnchorStyles.Left);
        public static readonly Size InvalidSize = new Size(-2147483648, -2147483648);
        public static readonly Rectangle MaxRectangle = new Rectangle(0, 0, 0x7fffffff, 0x7fffffff);
        public static readonly Size MaxSize = new Size(0x7fffffff, 0x7fffffff);
        public static readonly string TestString = "j^";
        public const AnchorStyles VerticalAnchorStyles = (AnchorStyles.Bottom | AnchorStyles.Top);

        public static Size AddAlignedRegion(Size objTextSize, Size objImageSize, TextImageRelation enmRelation)
        {
            return AddAlignedRegionCore(objTextSize, objImageSize, IsVerticalRelation(enmRelation));
        }

        public static Size AddAlignedRegionCore(Size objCurrentSize, Size objContentSize, bool blnVertical)
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

        public static Rectangle Align(Size objAlignThis, Rectangle objWithinThis, ContentAlignment enmAlign)
        {
            return VAlign(objAlignThis, HAlign(objAlignThis, objWithinThis, enmAlign), enmAlign);
        }

        public static Rectangle Align(Size objAlignThis, Rectangle objWithinThis, AnchorStyles enmAnchorStyles)
        {
            return VAlign(objAlignThis, HAlign(objAlignThis, objWithinThis, enmAnchorStyles), enmAnchorStyles);
        }

        public static Rectangle AlignAndStretch(Size objFitThis, Rectangle objWithinThis, AnchorStyles enmAnchorStyles)
        {
            return Align(Stretch(objFitThis, objWithinThis.Size, enmAnchorStyles), objWithinThis, enmAnchorStyles);
        }

        public static bool AreWidthAndHeightLarger(Size objSize1, Size objSize2)
        {
            if (objSize1.Width >= objSize2.Width)
            {
                return (objSize1.Height >= objSize2.Height);
            }
            return false;
        }

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
            int intNum = xContentAlignmentToIndex(((int)enmAlignment) & 15);
            int intNum2 = xContentAlignmentToIndex((((int)enmAlignment) >> 4) & 15);
            int intNum3 = xContentAlignmentToIndex((((int)enmAlignment) >> 8) & 15);
            int intNum4 = (((((intNum2 != 0) ? 4 : 0) | ((intNum3 != 0) ? 8 : 0)) | intNum) | intNum2) | intNum3;
            intNum4--;
            return intNum4;
        }

        public static Size ConvertZeroToUnbounded(Size objSize)
        {
            if (objSize.Width == 0)
            {
                objSize.Width = 0x7fffffff;
            }
            if (objSize.Height == 0)
            {
                objSize.Height = 0x7fffffff;
            }
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

        public static void ExpandRegionsToFillBounds(Rectangle objBounds, AnchorStyles enmRegion1Align, ref Rectangle objRegion1, ref Rectangle objRegion2)
        {
            switch (enmRegion1Align)
            {
                case AnchorStyles.Top:
                    objRegion1 = SubstituteSpecifiedBounds(objBounds, objRegion1, AnchorStyles.Bottom);
                    objRegion2 = SubstituteSpecifiedBounds(objBounds, objRegion2, AnchorStyles.Top);
                    return;

                case AnchorStyles.Bottom:
                    objRegion1 = SubstituteSpecifiedBounds(objBounds, objRegion1, AnchorStyles.Top);
                    objRegion2 = SubstituteSpecifiedBounds(objBounds, objRegion2, AnchorStyles.Bottom);
                    break;

                case (AnchorStyles.Bottom | AnchorStyles.Top):
                    break;

                case AnchorStyles.Left:
                    objRegion1 = SubstituteSpecifiedBounds(objBounds, objRegion1, AnchorStyles.Right);
                    objRegion2 = SubstituteSpecifiedBounds(objBounds, objRegion2, AnchorStyles.Left);
                    return;

                case AnchorStyles.Right:
                    objRegion1 = SubstituteSpecifiedBounds(objBounds, objRegion1, AnchorStyles.Left);
                    objRegion2 = SubstituteSpecifiedBounds(objBounds, objRegion2, AnchorStyles.Right);
                    return;

                default:
                    return;
            }
        }

        public static Padding FlipPadding(Padding objPadding)
        {
            if (objPadding.All == -1)
            {
                int top = objPadding.Top;
                objPadding.Top = objPadding.Left;
                objPadding.Left = top;
                top = objPadding.Bottom;
                objPadding.Bottom = objPadding.Right;
                objPadding.Right = top;
            }
            return objPadding;
        }

        public static Point FlipPoint(Point objPoint)
        {
            int intX = objPoint.X;
            objPoint.X = objPoint.Y;
            objPoint.Y = intX;
            return objPoint;
        }

        public static Rectangle FlipRectangle(Rectangle objRect)
        {
            objRect.Location = FlipPoint(objRect.Location);
            objRect.Size = FlipSize(objRect.Size);
            return objRect;
        }

        public static Rectangle FlipRectangleIf(bool blnCondition, Rectangle objRect)
        {
            if (!blnCondition)
            {
                return objRect;
            }
            return FlipRectangle(objRect);
        }

        public static Size FlipSize(Size objSize)
        {
            int intWidth = objSize.Width;
            objSize.Width = objSize.Height;
            objSize.Height = intWidth;
            return objSize;
        }

        public static Size FlipSizeIf(bool blnCondition, Size objSize)
        {
            if (!blnCondition)
            {
                return objSize;
            }
            return FlipSize(objSize);
        }

        private static AnchorStyles GetOppositeAnchor(AnchorStyles enmAnchor)
        {
            AnchorStyles enmNone = AnchorStyles.None;
            //if (anchor != AnchorStyles.None)
            //{
            //    for (int i = 1; i <= 8; i = i << 1)
            //    {
            //        switch ((anchor & i))
            //        {
            //            case AnchorStyles.Top:
            //                none |= AnchorStyles.Bottom;
            //                break;

            //            case AnchorStyles.Bottom:
            //                none |= AnchorStyles.Top;
            //                break;

            //            case AnchorStyles.Left:
            //                none |= AnchorStyles.Right;
            //                break;

            //            case AnchorStyles.Right:
            //                none |= AnchorStyles.Left;
            //                break;
            //        }
            //    }
            //}
            return enmNone;
        }

        public static TextImageRelation GetOppositeTextImageRelation(TextImageRelation enmRelation)
        {
            //return (TextImageRelation)GetOppositeAnchor((AnchorStyles)enmRelation);
            return new TextImageRelation();
        }

        internal static AnchorStyles GetUnifiedAnchor(IArrangedElement objElement)
        {
            //DockStyle dock = DefaultLayout.GetDock(element);
            //if (dock != DockStyle.None)
            //{
            //    return dockingToAnchor[(int)dock];
            //}
            //return DefaultLayout.GetAnchor(element);

            return (AnchorStyles.Top | AnchorStyles.Left);
        }

        private static Rectangle HAlign(Size objAlignThis, Rectangle objWithinThis, ContentAlignment enmAlign)
        {
            if ((enmAlign & (ContentAlignment.BottomRight | ContentAlignment.MiddleRight | ContentAlignment.TopRight)) != ((ContentAlignment)0))
            {
                objWithinThis.X += objWithinThis.Width - objAlignThis.Width;
            }
            else if ((enmAlign & (ContentAlignment.BottomCenter | ContentAlignment.MiddleCenter | ContentAlignment.TopCenter)) != ((ContentAlignment)0))
            {
                objWithinThis.X += (objWithinThis.Width - objAlignThis.Width) / 2;
            }
            objWithinThis.Width = objAlignThis.Width;
            return objWithinThis;
        }

        public static Rectangle HAlign(Size objAlignThis, Rectangle objWithinThis, AnchorStyles enmAnchorStyles)
        {
            if ((enmAnchorStyles & AnchorStyles.Right) != AnchorStyles.None)
            {
                objWithinThis.X += objWithinThis.Width - objAlignThis.Width;
            }
            else if ((enmAnchorStyles == AnchorStyles.None) || ((enmAnchorStyles & (AnchorStyles.Right | AnchorStyles.Left)) == AnchorStyles.None))
            {
                objWithinThis.X += (objWithinThis.Width - objAlignThis.Width) / 2;
            }
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

        public static Size IntersectSizes(Size objA, Size objB)
        {
            return new Size(Math.Min(objA.Width, objB.Width), Math.Min(objA.Height, objB.Height));
        }

        public static bool IsHorizontalAlignment(ContentAlignment enmAlign)
        {
            return !IsVerticalAlignment(enmAlign);
        }

        public static bool IsHorizontalRelation(TextImageRelation enmRelation)
        {
            return ((enmRelation & (TextImageRelation.TextBeforeImage | TextImageRelation.ImageBeforeText)) != TextImageRelation.Overlay);
        }

        public static bool IsIntersectHorizontally(Rectangle objRect1, Rectangle objRect2)
        {
            if (!objRect1.IntersectsWith(objRect2))
            {
                return false;
            }
            return (((objRect1.X <= objRect2.X) && ((objRect1.X + objRect1.Width) >= (objRect2.X + objRect2.Width))) || ((objRect2.X <= objRect1.X) && ((objRect2.X + objRect2.Width) >= (objRect1.X + objRect1.Width))));
        }

        public static bool IsIntersectVertically(Rectangle objRect1, Rectangle objRect2)
        {
            if (!objRect1.IntersectsWith(objRect2))
            {
                return false;
            }
            return (((objRect1.Y <= objRect2.Y) && ((objRect1.Y + objRect1.Width) >= (objRect2.Y + objRect2.Width))) || ((objRect2.Y <= objRect1.Y) && ((objRect2.Y + objRect2.Width) >= (objRect1.Y + objRect1.Width))));
        }

        public static bool IsVerticalAlignment(ContentAlignment enmAlign)
        {
            return ((enmAlign & (ContentAlignment.BottomCenter | ContentAlignment.TopCenter)) != ((ContentAlignment)0));
        }

        public static bool IsVerticalRelation(TextImageRelation enmRelation)
        {
            return ((enmRelation & (TextImageRelation.TextAboveImage | TextImageRelation.ImageAboveText)) != TextImageRelation.Overlay);
        }

        public static bool IsZeroWidthOrHeight(Rectangle objRectangle)
        {
            if (objRectangle.Width != 0)
            {
                return (objRectangle.Height == 0);
            }
            return true;
        }

        public static bool IsZeroWidthOrHeight(Size objSize)
        {
            if (objSize.Width != 0)
            {
                return (objSize.Height == 0);
            }
            return true;
        }

        public static Size OldGetLargestStringSizeInCollection(Font objFont, ICollection objCollection)
        {
            Size objEmpty = Size.Empty;
            if (objCollection != null)
            {
                foreach (object obj2 in objCollection)
                {
                    Size objSize = CommonUtils.GetStringMeasurements(obj2.ToString(), objFont);
                    objEmpty.Width = Math.Max(objEmpty.Width, objSize.Width);
                    objEmpty.Height = Math.Max(objEmpty.Height, objSize.Height);
                }
            }
            return objEmpty;
        }

        public static Rectangle RTLTranslate(Rectangle objBounds, Rectangle objWithinBounds)
        {
            objBounds.X = objWithinBounds.Width - objBounds.Right;
            return objBounds;
        }

        public static void SplitRegion(Rectangle objBounds, Size objSpecifiedContent, AnchorStyles enmRegion1Align, out Rectangle objRegion1, out Rectangle objRegion2)
        {
            objRegion1 = objRegion2 = objBounds;
            switch (enmRegion1Align)
            {
                case AnchorStyles.Top:
                    objRegion1.Height = objSpecifiedContent.Height;
                    objRegion2.Y += objSpecifiedContent.Height;
                    objRegion2.Height -= objSpecifiedContent.Height;
                    return;

                case AnchorStyles.Bottom:
                    objRegion1.Y += objBounds.Height - objSpecifiedContent.Height;
                    objRegion1.Height = objSpecifiedContent.Height;
                    objRegion2.Height -= objSpecifiedContent.Height;
                    break;

                case (AnchorStyles.Bottom | AnchorStyles.Top):
                    break;

                case AnchorStyles.Left:
                    objRegion1.Width = objSpecifiedContent.Width;
                    objRegion2.X += objSpecifiedContent.Width;
                    objRegion2.Width -= objSpecifiedContent.Width;
                    return;

                case AnchorStyles.Right:
                    objRegion1.X += objBounds.Width - objSpecifiedContent.Width;
                    objRegion1.Width = objSpecifiedContent.Width;
                    objRegion2.Width -= objSpecifiedContent.Width;
                    return;

                default:
                    return;
            }
        }

        public static Size Stretch(Size objStretchThis, Size objWithinThis, AnchorStyles enmAnchorStyles)
        {
            Size objSize = new Size(((enmAnchorStyles & (AnchorStyles.Right | AnchorStyles.Left)) == (AnchorStyles.Right | AnchorStyles.Left)) ? objWithinThis.Width : objStretchThis.Width, ((enmAnchorStyles & (AnchorStyles.Bottom | AnchorStyles.Top)) == (AnchorStyles.Bottom | AnchorStyles.Top)) ? objWithinThis.Height : objStretchThis.Height);
            if (objSize.Width > objWithinThis.Width)
            {
                objSize.Width = objWithinThis.Width;
            }
            if (objSize.Height > objWithinThis.Height)
            {
                objSize.Height = objWithinThis.Height;
            }
            return objSize;
        }

        public static Size SubAlignedRegion(Size objCurrentSize, Size objContentSize, TextImageRelation enmRelation)
        {
            return SubAlignedRegionCore(objCurrentSize, objContentSize, IsVerticalRelation(enmRelation));
        }

        public static Size SubAlignedRegionCore(Size objCurrentSize, Size objContentSize, bool blnVertical)
        {
            if (blnVertical)
            {
                objCurrentSize.Height -= objContentSize.Height;
                return objCurrentSize;
            }
            objCurrentSize.Width -= objContentSize.Width;
            return objCurrentSize;
        }

        private static Rectangle SubstituteSpecifiedBounds(Rectangle objOriginalBounds, Rectangle objSubstitutionBounds, AnchorStyles enmSpecified)
        {
            int intLeft = ((enmSpecified & AnchorStyles.Left) != AnchorStyles.None) ? objSubstitutionBounds.Left : objOriginalBounds.Left;
            int intTop = ((enmSpecified & AnchorStyles.Top) != AnchorStyles.None) ? objSubstitutionBounds.Top : objOriginalBounds.Top;
            int intRight = ((enmSpecified & AnchorStyles.Right) != AnchorStyles.None) ? objSubstitutionBounds.Right : objOriginalBounds.Right;
            int intBottom = ((enmSpecified & AnchorStyles.Bottom) != AnchorStyles.None) ? objSubstitutionBounds.Bottom : objOriginalBounds.Bottom;
            return Rectangle.FromLTRB(intLeft, intTop, intRight, intBottom);
        }

        public static Size UnionSizes(Size objA, Size objB)
        {
            return new Size(Math.Max(objA.Width, objB.Width), Math.Max(objA.Height, objB.Height));
        }

        public static Rectangle VAlign(Size objAlignThis, Rectangle objWithinThis, ContentAlignment enmAlign)
        {
            if ((enmAlign & (ContentAlignment.BottomRight | ContentAlignment.BottomCenter | ContentAlignment.BottomLeft)) != ((ContentAlignment)0))
            {
                objWithinThis.Y += objWithinThis.Height - objAlignThis.Height;
            }
            else if ((enmAlign & (ContentAlignment.MiddleRight | ContentAlignment.MiddleCenter | ContentAlignment.MiddleLeft)) != ((ContentAlignment)0))
            {
                objWithinThis.Y += (objWithinThis.Height - objAlignThis.Height) / 2;
            }
            objWithinThis.Height = objAlignThis.Height;
            return objWithinThis;
        }

        public static Rectangle VAlign(Size objAlignThis, Rectangle objWithinThis, AnchorStyles enmAnchorStyles)
        {
            if ((enmAnchorStyles & AnchorStyles.Bottom) != AnchorStyles.None)
            {
                objWithinThis.Y += objWithinThis.Height - objAlignThis.Height;
            }
            else if ((enmAnchorStyles == AnchorStyles.None) || ((enmAnchorStyles & (AnchorStyles.Bottom | AnchorStyles.Top)) == AnchorStyles.None))
            {
                objWithinThis.Y += (objWithinThis.Height - objAlignThis.Height) / 2;
            }
            objWithinThis.Height = objAlignThis.Height;
            return objWithinThis;
        }

        private static byte xContentAlignmentToIndex(int intThreeBitFlag)
        {
            return ((intThreeBitFlag == 4) ? ((byte)3) : ((byte)intThreeBitFlag));
        }

        [Serializable()]
        public sealed class MeasureTextCache
        {
            private const int mcntMaxCacheSize = 6;
            private int mintNextCacheEntry = -1;
            private PreferredSizeCache[] marrSizeCacheList;
            private Size mobjUnconstrainedPreferredSize = LayoutUtils.InvalidSize;

            public Size GetTextSize(string strText, Font objFont, Size objProposedConstraints, TextFormatFlags enmFlags)
            {
                if (!this.TextRequiresWordBreak(strText, objFont, objProposedConstraints, enmFlags))
                {
                    return this.mobjUnconstrainedPreferredSize;
                }
                if (this.marrSizeCacheList == null)
                {
                    this.marrSizeCacheList = new PreferredSizeCache[6];
                }
                foreach (PreferredSizeCache objCache in this.marrSizeCacheList)
                {
                    if (objCache.mobjConstrainingSize == objProposedConstraints)
                    {
                        return objCache.mobjPreferredSize;
                    }
                    if ((objCache.mobjConstrainingSize.Width == objProposedConstraints.Width) && (objCache.mobjPreferredSize.Height <= objProposedConstraints.Height))
                    {
                        return objCache.mobjPreferredSize;
                    }
                }
                Size objPreferredSize = CommonUtils.GetStringMeasurements(strText, objFont);
                this.mintNextCacheEntry = (this.mintNextCacheEntry + 1) % 6;
                this.marrSizeCacheList[this.mintNextCacheEntry] = new PreferredSizeCache(objProposedConstraints, objPreferredSize);
                return objPreferredSize;
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
                this.marrSizeCacheList = null;
            }

            public bool TextRequiresWordBreak(string strText, Font objFont, Size objSize, TextFormatFlags enmFlags)
            {
                return (this.GetUnconstrainedSize(strText, objFont, enmFlags).Width > objSize.Width);
            }

            [StructLayout(LayoutKind.Sequential), Serializable()]

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
