// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.TextFormatFlags
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Specifies the display and layout information for text strings.</summary>
  [Flags]
  public enum TextFormatFlags
  {
    /// <summary>Aligns the text on the bottom of the bounding rectangle. Applied only when the text is a single line.</summary>
    Bottom = 8,
    /// <summary>Applies the default formatting, which is left-aligned.</summary>
    Default = 0,
    /// <summary>Removes the end of trimmed lines, and replaces them with an ellipsis.</summary>
    EndEllipsis = 32768, // 0x00008000
    /// <summary>Expands tab characters. The default number of characters per tab is eight. The <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.WordEllipsis"></see>, <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.PathEllipsis"></see>, and <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.EndEllipsis"></see> values cannot be used with <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.ExpandTabs"></see>.</summary>
    ExpandTabs = 64, // 0x00000040
    /// <summary>Includes the font external leading in line height. Typically, external leading is not included in the height of a line of text.</summary>
    ExternalLeading = 512, // 0x00000200
    /// <summary>Adds padding to the bounding rectangle to accommodate overhanging glyphs. </summary>
    GlyphOverhangPadding = 0,
    /// <summary>Applies to Windows 2000 and Windows XP only: </summary>
    HidePrefix = 1048576, // 0x00100000
    /// <summary>Centers the text horizontally within the bounding rectangle.</summary>
    HorizontalCenter = 1,
    /// <summary>Uses the system font to calculate text metrics.</summary>
    Internal = 4096, // 0x00001000
    /// <summary>Aligns the text on the left side of the clipping area.</summary>
    Left = 0,
    /// <summary>Adds padding to both sides of the bounding rectangle.</summary>
    LeftAndRightPadding = 536870912, // 0x20000000
    /// <summary>Modifies the specified string to match the displayed text. This value has no effect unless <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.EndEllipsis"></see> or <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.PathEllipsis"></see> is also specified.</summary>
    ModifyString = 65536, // 0x00010000
    /// <summary>Allows the overhanging parts of glyphs and unwrapped text reaching outside the formatting rectangle to show.</summary>
    NoClipping = 256, // 0x00000100
    /// <summary>Applies to Windows 98, Windows Me, Windows 2000, or Windows XP only:</summary>
    NoFullWidthCharacterBreak = 524288, // 0x00080000
    /// <summary>Does not add padding to the bounding rectangle.</summary>
    NoPadding = 268435456, // 0x10000000
    /// <summary>Turns off processing of prefix characters. Typically, the ampersand (&amp;) mnemonic-prefix character is interpreted as a directive to underscore the character that follows, and the double-ampersand (&amp;&amp;) mnemonic-prefix characters as a directive to print a single ampersand. By specifying <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.NoPrefix"></see>, this processing is turned off. For example, an input string of "A&amp;bc&amp;&amp;d" with <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.NoPrefix"></see> applied would result in output of "A&amp;bc&amp;&amp;d".</summary>
    NoPrefix = 2048, // 0x00000800
    /// <summary>Removes the center of trimmed lines and replaces it with an ellipsis. </summary>
    PathEllipsis = 16384, // 0x00004000
    /// <summary>Applies to Windows 2000 or Windows XP only: </summary>
    PrefixOnly = 2097152, // 0x00200000
    /// <summary>Preserves the clipping specified by a <see cref="T:System.Drawing.Graphics"></see> object. Applies only to methods receiving an <see cref="T:System.Drawing.IDeviceContext"></see> that is a <see cref="T:System.Drawing.Graphics"></see>.</summary>
    PreserveGraphicsClipping = 16777216, // 0x01000000
    /// <summary>Preserves the transformation specified by a <see cref="T:System.Drawing.Graphics"></see>. Applies only to methods receiving an <see cref="T:System.Drawing.IDeviceContext"></see> that is a <see cref="T:System.Drawing.Graphics"></see>.</summary>
    PreserveGraphicsTranslateTransform = 33554432, // 0x02000000
    /// <summary>Aligns the text on the right side of the clipping area.</summary>
    Right = 2,
    /// <summary>Displays the text from right to left.</summary>
    RightToLeft = 131072, // 0x00020000
    /// <summary>Displays the text in a single line.</summary>
    SingleLine = 32, // 0x00000020
    /// <summary>Specifies the text should be formatted for display on a <see cref="T:Gizmox.WebGUI.Forms.TextBox"></see> control.</summary>
    TextBoxControl = 8192, // 0x00002000
    /// <summary>Aligns the text on the top of the bounding rectangle.</summary>
    Top = 0,
    /// <summary>Centers the text vertically, within the bounding rectangle.</summary>
    VerticalCenter = 4,
    /// <summary>Breaks the text at the end of a word.</summary>
    WordBreak = 16, // 0x00000010
    /// <summary>Trims the line to the nearest word and an ellipsis is placed at the end of a trimmed line.</summary>
    WordEllipsis = 262144, // 0x00040000
  }
}
