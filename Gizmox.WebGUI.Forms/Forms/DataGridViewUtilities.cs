// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.DataGridViewUtilities
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  [Serializable]
  internal class DataGridViewUtilities
  {
    private const byte DATAGRIDVIEWROWHEADERCELL_contentMarginHeight = 3;
    private const byte DATAGRIDVIEWROWHEADERCELL_contentMarginWidth = 3;
    private const byte DATAGRIDVIEWROWHEADERCELL_horizontalTextMarginLeft = 1;
    private const byte DATAGRIDVIEWROWHEADERCELL_horizontalTextMarginRight = 2;
    private const byte DATAGRIDVIEWROWHEADERCELL_iconMarginHeight = 2;
    private const byte DATAGRIDVIEWROWHEADERCELL_iconMarginWidth = 3;
    private const byte DATAGRIDVIEWROWHEADERCELL_iconsHeight = 11;
    private const byte DATAGRIDVIEWROWHEADERCELL_iconsWidth = 12;
    private const byte DATAGRIDVIEWROWHEADERCELL_verticalTextMargin = 1;

    internal static ContentAlignment ComputeDrawingContentAlignmentForCellStyleAlignment(
      DataGridViewContentAlignment enmAlignment)
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
        default:
          return ContentAlignment.MiddleCenter;
      }
    }

    internal static TextFormatFlags ComputeTextFormatFlagsForCellStyleAlignment(
      bool blnRightToLeft,
      DataGridViewContentAlignment enmAlignment,
      DataGridViewTriState enmWrapMode)
    {
      TextFormatFlags textFormatFlags;
      switch (enmAlignment)
      {
        case DataGridViewContentAlignment.TopLeft:
          textFormatFlags = TextFormatFlags.Default;
          if (blnRightToLeft)
          {
            textFormatFlags |= TextFormatFlags.Right;
            break;
          }
          break;
        case DataGridViewContentAlignment.TopCenter:
          textFormatFlags = TextFormatFlags.HorizontalCenter;
          break;
        case DataGridViewContentAlignment.TopRight:
          textFormatFlags = TextFormatFlags.Default;
          if (!blnRightToLeft)
          {
            textFormatFlags |= TextFormatFlags.Right;
            break;
          }
          break;
        case DataGridViewContentAlignment.MiddleLeft:
          textFormatFlags = TextFormatFlags.VerticalCenter;
          if (blnRightToLeft)
          {
            textFormatFlags |= TextFormatFlags.Right;
            break;
          }
          break;
        case DataGridViewContentAlignment.MiddleCenter:
          textFormatFlags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
          break;
        case DataGridViewContentAlignment.MiddleRight:
          textFormatFlags = TextFormatFlags.VerticalCenter;
          if (!blnRightToLeft)
          {
            textFormatFlags |= TextFormatFlags.Right;
            break;
          }
          break;
        case DataGridViewContentAlignment.BottomLeft:
          textFormatFlags = TextFormatFlags.Bottom;
          if (blnRightToLeft)
          {
            textFormatFlags |= TextFormatFlags.Right;
            break;
          }
          break;
        case DataGridViewContentAlignment.BottomCenter:
          textFormatFlags = TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
          break;
        case DataGridViewContentAlignment.BottomRight:
          textFormatFlags = TextFormatFlags.Bottom;
          if (!blnRightToLeft)
          {
            textFormatFlags |= TextFormatFlags.Right;
            break;
          }
          break;
        default:
          textFormatFlags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
          break;
      }
      TextFormatFlags cellStyleAlignment = (enmWrapMode != DataGridViewTriState.False ? textFormatFlags | TextFormatFlags.WordBreak : textFormatFlags | TextFormatFlags.SingleLine) | TextFormatFlags.NoPrefix | TextFormatFlags.PreserveGraphicsClipping;
      if (blnRightToLeft)
        cellStyleAlignment |= TextFormatFlags.RightToLeft;
      return cellStyleAlignment;
    }

    internal static Point GetTextLocation(
      Rectangle objCellBounds,
      Size objSizeText,
      TextFormatFlags enmFlags,
      DataGridViewCellStyle objCellStyle)
    {
      Point textLocation = new Point(0, 0);
      DataGridViewContentAlignment contentAlignment = objCellStyle.Alignment;
      if ((enmFlags & TextFormatFlags.RightToLeft) != TextFormatFlags.Default)
      {
        switch (contentAlignment)
        {
          case DataGridViewContentAlignment.TopLeft:
            contentAlignment = DataGridViewContentAlignment.TopRight;
            break;
          case DataGridViewContentAlignment.TopRight:
            contentAlignment = DataGridViewContentAlignment.TopLeft;
            break;
          case DataGridViewContentAlignment.MiddleLeft:
            contentAlignment = DataGridViewContentAlignment.MiddleRight;
            break;
          case DataGridViewContentAlignment.MiddleRight:
            contentAlignment = DataGridViewContentAlignment.MiddleLeft;
            break;
          case DataGridViewContentAlignment.BottomLeft:
            contentAlignment = DataGridViewContentAlignment.BottomRight;
            break;
          case DataGridViewContentAlignment.BottomRight:
            contentAlignment = DataGridViewContentAlignment.BottomLeft;
            break;
        }
      }
      switch (contentAlignment)
      {
        case DataGridViewContentAlignment.TopLeft:
          textLocation.X = objCellBounds.X;
          textLocation.Y = objCellBounds.Y;
          return textLocation;
        case DataGridViewContentAlignment.TopCenter:
          textLocation.X = objCellBounds.X + (objCellBounds.Width - objSizeText.Width) / 2;
          textLocation.Y = objCellBounds.Y;
          return textLocation;
        case DataGridViewContentAlignment.TopCenter | DataGridViewContentAlignment.TopLeft:
          return textLocation;
        case DataGridViewContentAlignment.TopRight:
          textLocation.X = objCellBounds.Right - objSizeText.Width;
          textLocation.Y = objCellBounds.Y;
          return textLocation;
        case DataGridViewContentAlignment.MiddleLeft:
          textLocation.X = objCellBounds.X;
          textLocation.Y = objCellBounds.Y + (objCellBounds.Height - objSizeText.Height) / 2;
          return textLocation;
        case DataGridViewContentAlignment.MiddleCenter:
          textLocation.X = objCellBounds.X + (objCellBounds.Width - objSizeText.Width) / 2;
          textLocation.Y = objCellBounds.Y + (objCellBounds.Height - objSizeText.Height) / 2;
          return textLocation;
        case DataGridViewContentAlignment.MiddleRight:
          textLocation.X = objCellBounds.Right - objSizeText.Width;
          textLocation.Y = objCellBounds.Y + (objCellBounds.Height - objSizeText.Height) / 2;
          return textLocation;
        case DataGridViewContentAlignment.BottomLeft:
          textLocation.X = objCellBounds.X;
          textLocation.Y = objCellBounds.Bottom - objSizeText.Height;
          return textLocation;
        case DataGridViewContentAlignment.BottomCenter:
          textLocation.X = objCellBounds.X + (objCellBounds.Width - objSizeText.Width) / 2;
          textLocation.Y = objCellBounds.Bottom - objSizeText.Height;
          return textLocation;
        case DataGridViewContentAlignment.BottomRight:
          textLocation.X = objCellBounds.Right - objSizeText.Width;
          textLocation.Y = objCellBounds.Bottom - objSizeText.Height;
          return textLocation;
        default:
          return textLocation;
      }
    }

    internal static bool ValidTextFormatFlags(TextFormatFlags enmFlags) => (enmFlags & ~(TextFormatFlags.Bottom | TextFormatFlags.EndEllipsis | TextFormatFlags.ExpandTabs | TextFormatFlags.ExternalLeading | TextFormatFlags.HidePrefix | TextFormatFlags.HorizontalCenter | TextFormatFlags.Internal | TextFormatFlags.ModifyString | TextFormatFlags.NoClipping | TextFormatFlags.NoFullWidthCharacterBreak | TextFormatFlags.NoPrefix | TextFormatFlags.PathEllipsis | TextFormatFlags.PrefixOnly | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.PreserveGraphicsTranslateTransform | TextFormatFlags.Right | TextFormatFlags.RightToLeft | TextFormatFlags.SingleLine | TextFormatFlags.TextBoxControl | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis)) == TextFormatFlags.Default;
  }
}
