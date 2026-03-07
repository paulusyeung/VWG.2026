// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProfessionalColors
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides <see cref="T:System.Drawing.Color"></see> structures that are colors of a Windows display element. This class cannot be inherited. </summary>
  [Serializable]
  public sealed class ProfessionalColors
  {
    private static string mstrColorScheme;
    private static ProfessionalColorTable professionalColorTable;

    static ProfessionalColors() => ProfessionalColors.SetScheme();

    private ProfessionalColors()
    {
    }

    private static void SetScheme() => ProfessionalColors.mstrColorScheme = (string) null;

    /// <summary>Gets the starting color of the gradient used when the button is checked.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the gradient used when the button is checked.</returns>
    [SRDescription("ProfessionalColorsButtonCheckedGradientBeginDescr")]
    public static Color ButtonCheckedGradientBegin => ProfessionalColors.ColorTable.ButtonCheckedGradientBegin;

    /// <summary>Gets the end color of the gradient used when the button is checked.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the button is checked.</returns>
    [SRDescription("ProfessionalColorsButtonCheckedGradientEndDescr")]
    public static Color ButtonCheckedGradientEnd => ProfessionalColors.ColorTable.ButtonCheckedGradientEnd;

    /// <summary>Gets the middle color of the gradient used when the button is checked.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when the button is checked.</returns>
    [SRDescription("ProfessionalColorsButtonCheckedGradientMiddleDescr")]
    public static Color ButtonCheckedGradientMiddle => ProfessionalColors.ColorTable.ButtonCheckedGradientMiddle;

    /// <summary>Gets the solid color used when the button is checked.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color used when the button is checked.</returns>
    [SRDescription("ProfessionalColorsButtonCheckedHighlightDescr")]
    public static Color ButtonCheckedHighlight => ProfessionalColors.ColorTable.ButtonCheckedHighlight;

    /// <summary>Gets the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonCheckedHighlight"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonCheckedHighlight"></see>.</returns>
    [SRDescription("ProfessionalColorsButtonCheckedHighlightBorderDescr")]
    public static Color ButtonCheckedHighlightBorder => ProfessionalColors.ColorTable.ButtonCheckedHighlightBorder;

    /// <summary>Gets the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientEnd"></see> colors.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientEnd"></see> colors.</returns>
    [SRDescription("ProfessionalColorsButtonPressedBorderDescr")]
    public static Color ButtonPressedBorder => ProfessionalColors.ColorTable.ButtonPressedBorder;

    /// <summary>Gets the starting color of the gradient used when the button is pressed down.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the button is pressed down.</returns>
    [SRDescription("ProfessionalColorsButtonPressedGradientBeginDescr")]
    public static Color ButtonPressedGradientBegin => ProfessionalColors.ColorTable.ButtonPressedGradientBegin;

    /// <summary>Gets the end color of the gradient used when the button is pressed down.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the button is pressed down.</returns>
    [SRDescription("ProfessionalColorsButtonPressedGradientEndDescr")]
    public static Color ButtonPressedGradientEnd => ProfessionalColors.ColorTable.ButtonPressedGradientEnd;

    /// <summary>Gets the middle color of the gradient used when the button is pressed down.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when the button is pressed.</returns>
    [SRDescription("ProfessionalColorsButtonPressedGradientMiddleDescr")]
    public static Color ButtonPressedGradientMiddle => ProfessionalColors.ColorTable.ButtonPressedGradientMiddle;

    /// <summary>Gets the solid color used when the button is pressed down.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color used when the button is pressed down.</returns>
    [SRDescription("ProfessionalColorsButtonPressedHighlightDescr")]
    public static Color ButtonPressedHighlight => ProfessionalColors.ColorTable.ButtonPressedHighlight;

    /// <summary>Gets the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedHighlight"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedHighlight"></see>.</returns>
    [SRDescription("ProfessionalColorsButtonPressedHighlightBorderDescr")]
    public static Color ButtonPressedHighlightBorder => ProfessionalColors.ColorTable.ButtonPressedHighlightBorder;

    /// <summary>Gets the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientEnd"></see> colors.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientEnd"></see> colors.</returns>
    [SRDescription("ProfessionalColorsButtonSelectedBorderDescr")]
    public static Color ButtonSelectedBorder => ProfessionalColors.ColorTable.ButtonCheckedGradientBegin;

    /// <summary>Gets the starting color of the gradient used when the button is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the button is selected.</returns>
    [SRDescription("ProfessionalColorsButtonSelectedGradientBeginDescr")]
    public static Color ButtonSelectedGradientBegin => ProfessionalColors.ColorTable.ButtonSelectedGradientBegin;

    /// <summary>Gets the end color of the gradient used when the button is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the button is selected.</returns>
    [SRDescription("ProfessionalColorsButtonSelectedGradientEndDescr")]
    public static Color ButtonSelectedGradientEnd => ProfessionalColors.ColorTable.ButtonSelectedGradientEnd;

    /// <summary>Gets the middle color of the gradient used when the button is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when the button is selected.</returns>
    [SRDescription("ProfessionalColorsButtonSelectedGradientMiddleDescr")]
    public static Color ButtonSelectedGradientMiddle => ProfessionalColors.ColorTable.ButtonSelectedGradientMiddle;

    /// <summary>Gets the solid color used when the button is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color used when the button is selected.</returns>
    [SRDescription("ProfessionalColorsButtonSelectedHighlightDescr")]
    public static Color ButtonSelectedHighlight => ProfessionalColors.ColorTable.ButtonSelectedHighlight;

    /// <summary>Gets the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedHighlight"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedHighlight"></see>.</returns>
    [SRDescription("ProfessionalColorsButtonSelectedHighlightBorderDescr")]
    public static Color ButtonSelectedHighlightBorder => ProfessionalColors.ColorTable.ButtonSelectedHighlightBorder;

    /// <summary>Gets the solid color to use when the check box is selected and gradients are being used.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when the check box is selected and gradients are being used.</returns>
    [SRDescription("ProfessionalColorsCheckBackgroundDescr")]
    public static Color CheckBackground => ProfessionalColors.ColorTable.CheckBackground;

    /// <summary>Gets the solid color to use when the check box is selected and gradients are being used.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when the check box is selected and gradients are being used.</returns>
    [SRDescription("ProfessionalColorsCheckPressedBackgroundDescr")]
    public static Color CheckPressedBackground => ProfessionalColors.ColorTable.CheckPressedBackground;

    /// <summary>Gets the solid color to use when the check box is selected and gradients are being used.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when the check box is selected and gradients are being used.</returns>
    [SRDescription("ProfessionalColorsCheckSelectedBackgroundDescr")]
    public static Color CheckSelectedBackground => ProfessionalColors.ColorTable.CheckSelectedBackground;

    internal static string ColorScheme => ProfessionalColors.mstrColorScheme;

    internal static ProfessionalColorTable ColorTable
    {
      get
      {
        if (ProfessionalColors.professionalColorTable == null)
          ProfessionalColors.professionalColorTable = new ProfessionalColorTable();
        return ProfessionalColors.professionalColorTable;
      }
    }

    /// <summary>Gets the color to use for shadow effects on the grip or move handle.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the color to use for shadow effects on the grip or move handle.</returns>
    [SRDescription("ProfessionalColorsGripDarkDescr")]
    public static Color GripDark => ProfessionalColors.ColorTable.GripDark;

    /// <summary>Gets the color to use for highlight effects on the grip or move handle.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the color to use for highlight effects on the grip or move handle.</returns>
    [SRDescription("ProfessionalColorsGripLightDescr")]
    public static Color GripLight => ProfessionalColors.ColorTable.GripLight;

    /// <summary>Gets the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</returns>
    [SRDescription("ProfessionalColorsImageMarginGradientBeginDescr")]
    public static Color ImageMarginGradientBegin => ProfessionalColors.ColorTable.ImageMarginGradientBegin;

    /// <summary>Gets the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</returns>
    [SRDescription("ProfessionalColorsImageMarginGradientEndDescr")]
    public static Color ImageMarginGradientEnd => ProfessionalColors.ColorTable.ImageMarginGradientEnd;

    /// <summary>Gets the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</returns>
    [SRDescription("ProfessionalColorsImageMarginGradientMiddleDescr")]
    public static Color ImageMarginGradientMiddle => ProfessionalColors.ColorTable.ImageMarginGradientMiddle;

    /// <summary>Gets the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</returns>
    [SRDescription("ProfessionalColorsImageMarginRevealedGradientBeginDescr")]
    public static Color ImageMarginRevealedGradientBegin => ProfessionalColors.ColorTable.ImageMarginRevealedGradientBegin;

    /// <summary>Gets the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</returns>
    [SRDescription("ProfessionalColorsImageMarginRevealedGradientEndDescr")]
    public static Color ImageMarginRevealedGradientEnd => ProfessionalColors.ColorTable.ImageMarginRevealedGradientEnd;

    /// <summary>Gets the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</returns>
    [SRDescription("ProfessionalColorsImageMarginRevealedGradientMiddleDescr")]
    public static Color ImageMarginRevealedGradientMiddle => ProfessionalColors.ColorTable.ImageMarginRevealedGradientMiddle;

    /// <summary>Gets the border color or a <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color or a <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</returns>
    [SRDescription("ProfessionalColorsMenuBorderDescr")]
    public static Color MenuBorder => ProfessionalColors.ColorTable.MenuBorder;

    /// <summary>Gets the border color to use with a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</returns>
    [SRDescription("ProfessionalColorsMenuItemBorderDescr")]
    public static Color MenuItemBorder => ProfessionalColors.ColorTable.MenuItemBorder;

    /// <summary>Gets the starting color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</returns>
    [SRDescription("ProfessionalColorsMenuItemPressedGradientBeginDescr")]
    public static Color MenuItemPressedGradientBegin => ProfessionalColors.ColorTable.MenuItemPressedGradientBegin;

    /// <summary>Gets the end color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</returns>
    [SRDescription("ProfessionalColorsMenuItemPressedGradientEndDescr")]
    public static Color MenuItemPressedGradientEnd => ProfessionalColors.ColorTable.MenuItemPressedGradientEnd;

    /// <summary>Gets the middle color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</returns>
    [SRDescription("ProfessionalColorsMenuItemPressedGradientMiddleDescr")]
    public static Color MenuItemPressedGradientMiddle => ProfessionalColors.ColorTable.MenuItemPressedGradientMiddle;

    /// <summary>Gets the solid color to use when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> other than the top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> other than the top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</returns>
    [SRDescription("ProfessionalColorsMenuItemSelectedDescr")]
    public static Color MenuItemSelected => ProfessionalColors.ColorTable.MenuItemBorder;

    /// <summary>Gets the starting color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</returns>
    [SRDescription("ProfessionalColorsMenuItemSelectedGradientBeginDescr")]
    public static Color MenuItemSelectedGradientBegin => ProfessionalColors.ColorTable.MenuItemSelectedGradientBegin;

    /// <summary>Gets the end color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</returns>
    [SRDescription("ProfessionalColorsMenuItemSelectedGradientEndDescr")]
    public static Color MenuItemSelectedGradientEnd => ProfessionalColors.ColorTable.MenuItemSelectedGradientEnd;

    /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</returns>
    [SRDescription("ProfessionalColorsMenuStripGradientBeginDescr")]
    public static Color MenuStripGradientBegin => ProfessionalColors.ColorTable.MenuStripGradientBegin;

    /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</returns>
    [SRDescription("ProfessionalColorsMenuStripGradientEndDescr")]
    public static Color MenuStripGradientEnd => ProfessionalColors.ColorTable.MenuStripGradientEnd;

    /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</returns>
    [SRDescription("ProfessionalColorsOverflowButtonGradientBeginDescr")]
    public static Color OverflowButtonGradientBegin => ProfessionalColors.ColorTable.OverflowButtonGradientBegin;

    /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</returns>
    [SRDescription("ProfessionalColorsOverflowButtonGradientEndDescr")]
    public static Color OverflowButtonGradientEnd => ProfessionalColors.ColorTable.OverflowButtonGradientEnd;

    /// <summary>Gets the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</returns>
    [SRDescription("ProfessionalColorsOverflowButtonGradientMiddleDescr")]
    public static Color OverflowButtonGradientMiddle => ProfessionalColors.ColorTable.OverflowButtonGradientMiddle;

    /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</returns>
    [SRDescription("ProfessionalColorsRaftingContainerGradientBeginDescr")]
    public static Color RaftingContainerGradientBegin => ProfessionalColors.ColorTable.RaftingContainerGradientBegin;

    /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</returns>
    [SRDescription("ProfessionalColorsRaftingContainerGradientEndDescr")]
    public static Color RaftingContainerGradientEnd => ProfessionalColors.ColorTable.RaftingContainerGradientEnd;

    /// <summary>Gets the color to use to for shadow effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the color to use to for shadow effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</returns>
    [SRDescription("ProfessionalColorsSeparatorDarkDescr")]
    public static Color SeparatorDark => ProfessionalColors.ColorTable.SeparatorDark;

    /// <summary>Gets the color to use to for highlight effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the color to use to create highlight effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</returns>
    [SRDescription("ProfessionalColorsSeparatorLightDescr")]
    public static Color SeparatorLight => ProfessionalColors.ColorTable.SeparatorLight;

    /// <summary>Gets the starting color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</returns>
    [SRDescription("ProfessionalColorsStatusStripGradientBeginDescr")]
    public static Color StatusStripGradientBegin => ProfessionalColors.ColorTable.StatusStripGradientBegin;

    /// <summary>Gets the end color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</returns>
    [SRDescription("ProfessionalColorsStatusStripGradientEndDescr")]
    public static Color StatusStripGradientEnd => ProfessionalColors.ColorTable.StatusStripGradientEnd;

    /// <summary>Gets the border color to use on the bottom edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use on the bottom edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
    [SRDescription("ProfessionalColorsToolStripBorderDescr")]
    public static Color ToolStripBorder => ProfessionalColors.ColorTable.ToolStripBorder;

    /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</returns>
    [SRDescription("ProfessionalColorsToolStripContentPanelGradientBeginDescr")]
    public static Color ToolStripContentPanelGradientBegin => ProfessionalColors.ColorTable.ToolStripContentPanelGradientBegin;

    /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</returns>
    [SRDescription("ProfessionalColorsToolStripContentPanelGradientEndDescr")]
    public static Color ToolStripContentPanelGradientEnd => ProfessionalColors.ColorTable.ToolStripContentPanelGradientEnd;

    /// <summary>Gets the solid background color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid background color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.</returns>
    [SRDescription("ProfessionalColorsToolStripDropDownBackgroundDescr")]
    public static Color ToolStripDropDownBackground => ProfessionalColors.ColorTable.ToolStripDropDownBackground;

    /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</returns>
    [SRDescription("ProfessionalColorsToolStripGradientBeginDescr")]
    public static Color ToolStripGradientBegin => ProfessionalColors.ColorTable.ToolStripGradientBegin;

    /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</returns>
    [SRDescription("ProfessionalColorsToolStripGradientEndDescr")]
    public static Color ToolStripGradientEnd => ProfessionalColors.ColorTable.ToolStripGradientEnd;

    /// <summary>Gets the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</returns>
    [SRDescription("ProfessionalColorsToolStripGradientMiddleDescr")]
    public static Color ToolStripGradientMiddle => ProfessionalColors.ColorTable.ToolStripGradientMiddle;

    /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</returns>
    [SRDescription("ProfessionalColorsToolStripPanelGradientBeginDescr")]
    public static Color ToolStripPanelGradientBegin => ProfessionalColors.ColorTable.ToolStripPanelGradientBegin;

    /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</returns>
    [SRDescription("ProfessionalColorsToolStripPanelGradientEndDescr")]
    public static Color ToolStripPanelGradientEnd => ProfessionalColors.ColorTable.ToolStripPanelGradientEnd;
  }
}
