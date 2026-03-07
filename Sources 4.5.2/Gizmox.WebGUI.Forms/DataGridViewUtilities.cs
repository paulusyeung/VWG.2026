namespace Gizmox.WebGUI.Forms
{
    using System;
    using System.Drawing;

    [Serializable()]
    internal class DataGridViewUtilities
    {
        internal static ContentAlignment ComputeDrawingContentAlignmentForCellStyleAlignment(DataGridViewContentAlignment enmAlignment)
        {
            switch (enmAlignment)
            {
                case DataGridViewContentAlignment.TopLeft:
                    return ContentAlignment.TopLeft;

                case DataGridViewContentAlignment.TopCenter:
                    return ContentAlignment.TopCenter;

                case DataGridViewContentAlignment.TopRight:
                    return ContentAlignment.TopRight;

                case DataGridViewContentAlignment.MiddleLeft:
                    return ContentAlignment.MiddleLeft;

                case DataGridViewContentAlignment.MiddleCenter:
                    return ContentAlignment.MiddleCenter;

                case DataGridViewContentAlignment.MiddleRight:
                    return ContentAlignment.MiddleRight;

                case DataGridViewContentAlignment.BottomLeft:
                    return ContentAlignment.BottomLeft;

                case DataGridViewContentAlignment.BottomCenter:
                    return ContentAlignment.BottomCenter;

                case DataGridViewContentAlignment.BottomRight:
                    return ContentAlignment.BottomRight;
            }
            return ContentAlignment.MiddleCenter;
        }

        internal static TextFormatFlags ComputeTextFormatFlagsForCellStyleAlignment(bool blnRightToLeft, DataGridViewContentAlignment enmAlignment, DataGridViewTriState enmWrapMode)
        {
            TextFormatFlags enmFlags;
            switch (enmAlignment)
            {
                case DataGridViewContentAlignment.BottomCenter:
                    enmFlags = TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    break;

                case DataGridViewContentAlignment.BottomRight:
                    enmFlags = TextFormatFlags.Bottom;
                    if (blnRightToLeft)
                    {
                        break;
                    }
                    enmFlags |= TextFormatFlags.Right;
                    break;

                case DataGridViewContentAlignment.MiddleRight:
                    enmFlags = TextFormatFlags.VerticalCenter;
                    if (blnRightToLeft)
                    {
                        break;
                    }
                    enmFlags |= TextFormatFlags.Right;
                    break;

                case DataGridViewContentAlignment.BottomLeft:
                    enmFlags = TextFormatFlags.Bottom;
                    if (blnRightToLeft)
                    {
                        enmFlags |= TextFormatFlags.Right;
                        break;
                    }
                    break;

                case DataGridViewContentAlignment.TopLeft:
                    enmFlags = TextFormatFlags.GlyphOverhangPadding;
                    if (!blnRightToLeft)
                    {
                        break;
                    }
                    enmFlags |= TextFormatFlags.Right;
                    break;

                case DataGridViewContentAlignment.TopCenter:
                    enmFlags = TextFormatFlags.HorizontalCenter;
                    break;

                case DataGridViewContentAlignment.TopRight:
                    enmFlags = TextFormatFlags.GlyphOverhangPadding;
                    if (!blnRightToLeft)
                    {
                        enmFlags |= TextFormatFlags.Right;
                        break;
                    }
                    break;

                case DataGridViewContentAlignment.MiddleLeft:
                    enmFlags = TextFormatFlags.VerticalCenter;
                    if (blnRightToLeft)
                    {
                        enmFlags |= TextFormatFlags.Right;
                        break;
                    }
                    break;

                case DataGridViewContentAlignment.MiddleCenter:
                    enmFlags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
                    break;

                default:
                    enmFlags = TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter;
                    break;
            }
            if (enmWrapMode == DataGridViewTriState.False)
            {
                enmFlags |= TextFormatFlags.SingleLine;
            }
            else
            {
                enmFlags |= TextFormatFlags.WordBreak;
            }
            enmFlags |= TextFormatFlags.NoPrefix;
            enmFlags |= TextFormatFlags.PreserveGraphicsClipping;
            if (blnRightToLeft)
            {
                enmFlags |= TextFormatFlags.RightToLeft;
            }
            return enmFlags;
        }

        internal static Point GetTextLocation(Rectangle objCellBounds, Size objSizeText, TextFormatFlags enmFlags, DataGridViewCellStyle objCellStyle)
        {
            Point objPoint = new Point(0, 0);
            DataGridViewContentAlignment enmAlignment = objCellStyle.Alignment;
            if ((enmFlags & TextFormatFlags.RightToLeft) != TextFormatFlags.GlyphOverhangPadding)
            {
                switch (enmAlignment)
                {
                    case DataGridViewContentAlignment.MiddleRight:
                        enmAlignment = DataGridViewContentAlignment.MiddleLeft;
                        break;

                    case DataGridViewContentAlignment.BottomLeft:
                        enmAlignment = DataGridViewContentAlignment.BottomRight;
                        break;

                    case DataGridViewContentAlignment.BottomRight:
                        enmAlignment = DataGridViewContentAlignment.BottomLeft;
                        break;

                    case DataGridViewContentAlignment.TopLeft:
                        enmAlignment = DataGridViewContentAlignment.TopRight;
                        break;

                    case DataGridViewContentAlignment.TopRight:
                        enmAlignment = DataGridViewContentAlignment.TopLeft;
                        break;

                    case DataGridViewContentAlignment.MiddleLeft:
                        enmAlignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                }
            }
            DataGridViewContentAlignment enmAlignment2 = enmAlignment;
            if (enmAlignment2 <= DataGridViewContentAlignment.MiddleCenter)
            {
                switch (enmAlignment2)
                {
                    case DataGridViewContentAlignment.TopLeft:
                        objPoint.X = objCellBounds.X;
                        objPoint.Y = objCellBounds.Y;
                        return objPoint;

                    case DataGridViewContentAlignment.TopCenter:
                        objPoint.X = objCellBounds.X + ((objCellBounds.Width - objSizeText.Width) / 2);
                        objPoint.Y = objCellBounds.Y;
                        return objPoint;

                    case (DataGridViewContentAlignment.TopCenter | DataGridViewContentAlignment.TopLeft):
                        return objPoint;

                    case DataGridViewContentAlignment.TopRight:
                        objPoint.X = objCellBounds.Right - objSizeText.Width;
                        objPoint.Y = objCellBounds.Y;
                        return objPoint;

                    case DataGridViewContentAlignment.MiddleLeft:
                        objPoint.X = objCellBounds.X;
                        objPoint.Y = objCellBounds.Y + ((objCellBounds.Height - objSizeText.Height) / 2);
                        return objPoint;

                    case DataGridViewContentAlignment.MiddleCenter:
                        objPoint.X = objCellBounds.X + ((objCellBounds.Width - objSizeText.Width) / 2);
                        objPoint.Y = objCellBounds.Y + ((objCellBounds.Height - objSizeText.Height) / 2);
                        return objPoint;
                }
                return objPoint;
            }
            if (enmAlignment2 <= DataGridViewContentAlignment.BottomLeft)
            {
                switch (enmAlignment2)
                {
                    case DataGridViewContentAlignment.MiddleRight:
                        objPoint.X = objCellBounds.Right - objSizeText.Width;
                        objPoint.Y = objCellBounds.Y + ((objCellBounds.Height - objSizeText.Height) / 2);
                        return objPoint;

                    case DataGridViewContentAlignment.BottomLeft:
                        objPoint.X = objCellBounds.X;
                        objPoint.Y = objCellBounds.Bottom - objSizeText.Height;
                        return objPoint;
                }
                return objPoint;
            }
            switch (enmAlignment2)
            {
                case DataGridViewContentAlignment.BottomCenter:
                    objPoint.X = objCellBounds.X + ((objCellBounds.Width - objSizeText.Width) / 2);
                    objPoint.Y = objCellBounds.Bottom - objSizeText.Height;
                    return objPoint;

                case DataGridViewContentAlignment.BottomRight:
                    objPoint.X = objCellBounds.Right - objSizeText.Width;
                    objPoint.Y = objCellBounds.Bottom - objSizeText.Height;
                    return objPoint;
            }
            return objPoint;
        }

        internal static bool ValidTextFormatFlags(TextFormatFlags enmFlags)
        {
            return ((enmFlags & ~(TextFormatFlags.PreserveGraphicsTranslateTransform | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.PrefixOnly | TextFormatFlags.HidePrefix | TextFormatFlags.NoFullWidthCharacterBreak | TextFormatFlags.WordEllipsis | TextFormatFlags.RightToLeft | TextFormatFlags.ModifyString | TextFormatFlags.EndEllipsis | TextFormatFlags.PathEllipsis | TextFormatFlags.TextBoxControl | TextFormatFlags.Internal | TextFormatFlags.NoPrefix | TextFormatFlags.ExternalLeading | TextFormatFlags.NoClipping | TextFormatFlags.ExpandTabs | TextFormatFlags.SingleLine | TextFormatFlags.WordBreak | TextFormatFlags.Bottom | TextFormatFlags.VerticalCenter | TextFormatFlags.Right | TextFormatFlags.HorizontalCenter)) == TextFormatFlags.GlyphOverhangPadding);
        }

        private const byte DATAGRIDVIEWROWHEADERCELL_contentMarginHeight = 3;
        private const byte DATAGRIDVIEWROWHEADERCELL_contentMarginWidth = 3;
        private const byte DATAGRIDVIEWROWHEADERCELL_horizontalTextMarginLeft = 1;
        private const byte DATAGRIDVIEWROWHEADERCELL_horizontalTextMarginRight = 2;
        private const byte DATAGRIDVIEWROWHEADERCELL_iconMarginHeight = 2;
        private const byte DATAGRIDVIEWROWHEADERCELL_iconMarginWidth = 3;
        private const byte DATAGRIDVIEWROWHEADERCELL_iconsHeight = 11;
        private const byte DATAGRIDVIEWROWHEADERCELL_iconsWidth = 12;
        private const byte DATAGRIDVIEWROWHEADERCELL_verticalTextMargin = 1;
    }
}