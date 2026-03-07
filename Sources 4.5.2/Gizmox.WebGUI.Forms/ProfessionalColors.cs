using System;
using System.Text;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>Provides <see cref="T:System.Drawing.Color"></see> structures that are colors of a Windows display element. This class cannot be inherited. </summary>
    [Serializable()]
    public sealed class ProfessionalColors
    {


        private static string mstrColorScheme;

        private static ProfessionalColorTable professionalColorTable;

        static ProfessionalColors()
        {
            SetScheme();
        }

        private ProfessionalColors()
        {
        }


        private static void SetScheme()
        {
                mstrColorScheme = null;
        }

        /// <summary>Gets the starting color of the gradient used when the button is checked.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the gradient used when the button is checked.</returns>
        [SRDescription("ProfessionalColorsButtonCheckedGradientBeginDescr")]
        public static Color ButtonCheckedGradientBegin
        {
            get
            {
                return ColorTable.ButtonCheckedGradientBegin;
            }
        }

        /// <summary>Gets the end color of the gradient used when the button is checked.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the button is checked.</returns>
        [SRDescription("ProfessionalColorsButtonCheckedGradientEndDescr")]
        public static Color ButtonCheckedGradientEnd
        {
            get
            {
                return ColorTable.ButtonCheckedGradientEnd;
            }
        }

        /// <summary>Gets the middle color of the gradient used when the button is checked.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when the button is checked.</returns>
        [SRDescription("ProfessionalColorsButtonCheckedGradientMiddleDescr")]
        public static Color ButtonCheckedGradientMiddle
        {
            get
            {
                return ColorTable.ButtonCheckedGradientMiddle;
            }
        }

        /// <summary>Gets the solid color used when the button is checked.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color used when the button is checked.</returns>
        [SRDescription("ProfessionalColorsButtonCheckedHighlightDescr")]
        public static Color ButtonCheckedHighlight
        {
            get
            {
                return ColorTable.ButtonCheckedHighlight;
            }
        }

        /// <summary>Gets the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonCheckedHighlight"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonCheckedHighlight"></see>.</returns>
        [SRDescription("ProfessionalColorsButtonCheckedHighlightBorderDescr")]
        public static Color ButtonCheckedHighlightBorder
        {
            get
            {
                return ColorTable.ButtonCheckedHighlightBorder;
            }
        }

        /// <summary>Gets the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientEnd"></see> colors.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientEnd"></see> colors.</returns>
        [SRDescription("ProfessionalColorsButtonPressedBorderDescr")]
        public static Color ButtonPressedBorder
        {
            get
            {
                return ColorTable.ButtonPressedBorder;
            }
        }

        /// <summary>Gets the starting color of the gradient used when the button is pressed down.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the button is pressed down.</returns>
        [SRDescription("ProfessionalColorsButtonPressedGradientBeginDescr")]
        public static Color ButtonPressedGradientBegin
        {
            get
            {
                return ColorTable.ButtonPressedGradientBegin;
            }
        }

        /// <summary>Gets the end color of the gradient used when the button is pressed down.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the button is pressed down.</returns>
        [SRDescription("ProfessionalColorsButtonPressedGradientEndDescr")]
        public static Color ButtonPressedGradientEnd
        {
            get
            {
                return ColorTable.ButtonPressedGradientEnd;
            }
        }

        /// <summary>Gets the middle color of the gradient used when the button is pressed down.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when the button is pressed.</returns>
        [SRDescription("ProfessionalColorsButtonPressedGradientMiddleDescr")]
        public static Color ButtonPressedGradientMiddle
        {
            get
            {
                return ColorTable.ButtonPressedGradientMiddle;
            }
        }

        /// <summary>Gets the solid color used when the button is pressed down.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color used when the button is pressed down.</returns>
        [SRDescription("ProfessionalColorsButtonPressedHighlightDescr")]
        public static Color ButtonPressedHighlight
        {
            get
            {
                return ColorTable.ButtonPressedHighlight;
            }
        }

        /// <summary>Gets the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedHighlight"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedHighlight"></see>.</returns>
        [SRDescription("ProfessionalColorsButtonPressedHighlightBorderDescr")]
        public static Color ButtonPressedHighlightBorder
        {
            get
            {
                return ColorTable.ButtonPressedHighlightBorder;
            }
        }

        /// <summary>Gets the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientEnd"></see> colors.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientEnd"></see> colors.</returns>
        [SRDescription("ProfessionalColorsButtonSelectedBorderDescr")]
        public static Color ButtonSelectedBorder
        {
            get
            {
                return ColorTable.ButtonCheckedGradientBegin;
            }
        }

        /// <summary>Gets the starting color of the gradient used when the button is selected.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the button is selected.</returns>
        [SRDescription("ProfessionalColorsButtonSelectedGradientBeginDescr")]
        public static Color ButtonSelectedGradientBegin
        {
            get
            {
                return ColorTable.ButtonSelectedGradientBegin;
            }
        }

        /// <summary>Gets the end color of the gradient used when the button is selected.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the button is selected.</returns>
        [SRDescription("ProfessionalColorsButtonSelectedGradientEndDescr")]
        public static Color ButtonSelectedGradientEnd
        {
            get
            {
                return ColorTable.ButtonSelectedGradientEnd;
            }
        }

        /// <summary>Gets the middle color of the gradient used when the button is selected.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when the button is selected.</returns>
        [SRDescription("ProfessionalColorsButtonSelectedGradientMiddleDescr")]
        public static Color ButtonSelectedGradientMiddle
        {
            get
            {
                return ColorTable.ButtonSelectedGradientMiddle;
            }
        }

        /// <summary>Gets the solid color used when the button is selected.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color used when the button is selected.</returns>
        [SRDescription("ProfessionalColorsButtonSelectedHighlightDescr")]
        public static Color ButtonSelectedHighlight
        {
            get
            {
                return ColorTable.ButtonSelectedHighlight;
            }
        }

        /// <summary>Gets the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedHighlight"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedHighlight"></see>.</returns>
        [SRDescription("ProfessionalColorsButtonSelectedHighlightBorderDescr")]
        public static Color ButtonSelectedHighlightBorder
        {
            get
            {
                return ColorTable.ButtonSelectedHighlightBorder;
            }
        }

        /// <summary>Gets the solid color to use when the check box is selected and gradients are being used.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when the check box is selected and gradients are being used.</returns>
        [SRDescription("ProfessionalColorsCheckBackgroundDescr")]
        public static Color CheckBackground
        {
            get
            {
                return ColorTable.CheckBackground;
            }
        }

        /// <summary>Gets the solid color to use when the check box is selected and gradients are being used.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when the check box is selected and gradients are being used.</returns>
        [SRDescription("ProfessionalColorsCheckPressedBackgroundDescr")]
        public static Color CheckPressedBackground
        {
            get
            {
                return ColorTable.CheckPressedBackground;
            }
        }

        /// <summary>Gets the solid color to use when the check box is selected and gradients are being used.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when the check box is selected and gradients are being used.</returns>
        [SRDescription("ProfessionalColorsCheckSelectedBackgroundDescr")]
        public static Color CheckSelectedBackground
        {
            get
            {
                return ColorTable.CheckSelectedBackground;
            }
        }


        internal static string ColorScheme
        {
            get
            {
                return mstrColorScheme;
            }
        }

        internal static ProfessionalColorTable ColorTable
        {
            get
            {
                if (professionalColorTable == null)
                {
                    professionalColorTable = new ProfessionalColorTable();
                }
                return professionalColorTable;
            }
        }

        /// <summary>Gets the color to use for shadow effects on the grip or move handle.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the color to use for shadow effects on the grip or move handle.</returns>
        [SRDescription("ProfessionalColorsGripDarkDescr")]
        public static Color GripDark
        {
            get
            {
                return ColorTable.GripDark;
            }
        }

        /// <summary>Gets the color to use for highlight effects on the grip or move handle.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the color to use for highlight effects on the grip or move handle.</returns>
        [SRDescription("ProfessionalColorsGripLightDescr")]
        public static Color GripLight
        {
            get
            {
                return ColorTable.GripLight;
            }
        }

        /// <summary>Gets the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</returns>
        [SRDescription("ProfessionalColorsImageMarginGradientBeginDescr")]
        public static Color ImageMarginGradientBegin
        {
            get
            {
                return ColorTable.ImageMarginGradientBegin;
            }
        }

        /// <summary>Gets the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</returns>
        [SRDescription("ProfessionalColorsImageMarginGradientEndDescr")]
        public static Color ImageMarginGradientEnd
        {
            get
            {
                return ColorTable.ImageMarginGradientEnd;
            }
        }

        /// <summary>Gets the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</returns>
        [SRDescription("ProfessionalColorsImageMarginGradientMiddleDescr")]
        public static Color ImageMarginGradientMiddle
        {
            get
            {
                return ColorTable.ImageMarginGradientMiddle;
            }
        }

        /// <summary>Gets the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</returns>
        [SRDescription("ProfessionalColorsImageMarginRevealedGradientBeginDescr")]
        public static Color ImageMarginRevealedGradientBegin
        {
            get
            {
                return ColorTable.ImageMarginRevealedGradientBegin;
            }
        }

        /// <summary>Gets the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</returns>
        [SRDescription("ProfessionalColorsImageMarginRevealedGradientEndDescr")]
        public static Color ImageMarginRevealedGradientEnd
        {
            get
            {
                return ColorTable.ImageMarginRevealedGradientEnd;
            }
        }

        /// <summary>Gets the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</returns>
        [SRDescription("ProfessionalColorsImageMarginRevealedGradientMiddleDescr")]
        public static Color ImageMarginRevealedGradientMiddle
        {
            get
            {
                return ColorTable.ImageMarginRevealedGradientMiddle;
            }
        }

        /// <summary>Gets the border color or a <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color or a <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</returns>
        [SRDescription("ProfessionalColorsMenuBorderDescr")]
        public static Color MenuBorder
        {
            get
            {
                return ColorTable.MenuBorder;
            }
        }

        /// <summary>Gets the border color to use with a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</returns>
        [SRDescription("ProfessionalColorsMenuItemBorderDescr")]
        public static Color MenuItemBorder
        {
            get
            {
                return ColorTable.MenuItemBorder;
            }
        }

        /// <summary>Gets the starting color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</returns>
        [SRDescription("ProfessionalColorsMenuItemPressedGradientBeginDescr")]
        public static Color MenuItemPressedGradientBegin
        {
            get
            {
                return ColorTable.MenuItemPressedGradientBegin;
            }
        }

        /// <summary>Gets the end color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</returns>
        [SRDescription("ProfessionalColorsMenuItemPressedGradientEndDescr")]
        public static Color MenuItemPressedGradientEnd
        {
            get
            {
                return ColorTable.MenuItemPressedGradientEnd;
            }
        }

        /// <summary>Gets the middle color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</returns>
        [SRDescription("ProfessionalColorsMenuItemPressedGradientMiddleDescr")]
        public static Color MenuItemPressedGradientMiddle
        {
            get
            {
                return ColorTable.MenuItemPressedGradientMiddle;
            }
        }

        /// <summary>Gets the solid color to use when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> other than the top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> other than the top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</returns>
        [SRDescription("ProfessionalColorsMenuItemSelectedDescr")]
        public static Color MenuItemSelected
        {
            get
            {
                return ColorTable.MenuItemBorder;
            }
        }

        /// <summary>Gets the starting color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</returns>
        [SRDescription("ProfessionalColorsMenuItemSelectedGradientBeginDescr")]
        public static Color MenuItemSelectedGradientBegin
        {
            get
            {
                return ColorTable.MenuItemSelectedGradientBegin;
            }
        }

        /// <summary>Gets the end color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</returns>
        [SRDescription("ProfessionalColorsMenuItemSelectedGradientEndDescr")]
        public static Color MenuItemSelectedGradientEnd
        {
            get
            {
                return ColorTable.MenuItemSelectedGradientEnd;
            }
        }

        /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</returns>
        [SRDescription("ProfessionalColorsMenuStripGradientBeginDescr")]
        public static Color MenuStripGradientBegin
        {
            get
            {
                return ColorTable.MenuStripGradientBegin;
            }
        }

        /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</returns>
        [SRDescription("ProfessionalColorsMenuStripGradientEndDescr")]
        public static Color MenuStripGradientEnd
        {
            get
            {
                return ColorTable.MenuStripGradientEnd;
            }
        }

        /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</returns>
        [SRDescription("ProfessionalColorsOverflowButtonGradientBeginDescr")]
        public static Color OverflowButtonGradientBegin
        {
            get
            {
                return ColorTable.OverflowButtonGradientBegin;
            }
        }

        /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</returns>
        [SRDescription("ProfessionalColorsOverflowButtonGradientEndDescr")]
        public static Color OverflowButtonGradientEnd
        {
            get
            {
                return ColorTable.OverflowButtonGradientEnd;
            }
        }

        /// <summary>Gets the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</returns>
        [SRDescription("ProfessionalColorsOverflowButtonGradientMiddleDescr")]
        public static Color OverflowButtonGradientMiddle
        {
            get
            {
                return ColorTable.OverflowButtonGradientMiddle;
            }
        }

        /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</returns>
        [SRDescription("ProfessionalColorsRaftingContainerGradientBeginDescr")]
        public static Color RaftingContainerGradientBegin
        {
            get
            {
                return ColorTable.RaftingContainerGradientBegin;
            }
        }

        /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</returns>
        [SRDescription("ProfessionalColorsRaftingContainerGradientEndDescr")]
        public static Color RaftingContainerGradientEnd
        {
            get
            {
                return ColorTable.RaftingContainerGradientEnd;
            }
        }

        /// <summary>Gets the color to use to for shadow effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the color to use to for shadow effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</returns>
        [SRDescription("ProfessionalColorsSeparatorDarkDescr")]
        public static Color SeparatorDark
        {
            get
            {
                return ColorTable.SeparatorDark;
            }
        }

        /// <summary>Gets the color to use to for highlight effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the color to use to create highlight effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</returns>
        [SRDescription("ProfessionalColorsSeparatorLightDescr")]
        public static Color SeparatorLight
        {
            get
            {
                return ColorTable.SeparatorLight;
            }
        }

        /// <summary>Gets the starting color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</returns>
        [SRDescription("ProfessionalColorsStatusStripGradientBeginDescr")]
        public static Color StatusStripGradientBegin
        {
            get
            {
                return ColorTable.StatusStripGradientBegin;
            }
        }

        /// <summary>Gets the end color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</returns>
        [SRDescription("ProfessionalColorsStatusStripGradientEndDescr")]
        public static Color StatusStripGradientEnd
        {
            get
            {
                return ColorTable.StatusStripGradientEnd;
            }
        }

        /// <summary>Gets the border color to use on the bottom edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use on the bottom edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
        [SRDescription("ProfessionalColorsToolStripBorderDescr")]
        public static Color ToolStripBorder
        {
            get
            {
                return ColorTable.ToolStripBorder;
            }
        }

        /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</returns>
        [SRDescription("ProfessionalColorsToolStripContentPanelGradientBeginDescr")]
        public static Color ToolStripContentPanelGradientBegin
        {
            get
            {
                return ColorTable.ToolStripContentPanelGradientBegin;
            }
        }

        /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</returns>
        [SRDescription("ProfessionalColorsToolStripContentPanelGradientEndDescr")]
        public static Color ToolStripContentPanelGradientEnd
        {
            get
            {
                return ColorTable.ToolStripContentPanelGradientEnd;
            }
        }

        /// <summary>Gets the solid background color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid background color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.</returns>
        [SRDescription("ProfessionalColorsToolStripDropDownBackgroundDescr")]
        public static Color ToolStripDropDownBackground
        {
            get
            {
                return ColorTable.ToolStripDropDownBackground;
            }
        }

        /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</returns>
        [SRDescription("ProfessionalColorsToolStripGradientBeginDescr")]
        public static Color ToolStripGradientBegin
        {
            get
            {
                return ColorTable.ToolStripGradientBegin;
            }
        }

        /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</returns>
        [SRDescription("ProfessionalColorsToolStripGradientEndDescr")]
        public static Color ToolStripGradientEnd
        {
            get
            {
                return ColorTable.ToolStripGradientEnd;
            }
        }

        /// <summary>Gets the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</returns>
        [SRDescription("ProfessionalColorsToolStripGradientMiddleDescr")]
        public static Color ToolStripGradientMiddle
        {
            get
            {
                return ColorTable.ToolStripGradientMiddle;
            }
        }

        /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</returns>
        [SRDescription("ProfessionalColorsToolStripPanelGradientBeginDescr")]
        public static Color ToolStripPanelGradientBegin
        {
            get
            {
                return ColorTable.ToolStripPanelGradientBegin;
            }
        }

        /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</returns>
        [SRDescription("ProfessionalColorsToolStripPanelGradientEndDescr")]
        public static Color ToolStripPanelGradientEnd
        {
            get
            {
                return ColorTable.ToolStripPanelGradientEnd;
            }
        }
    }

}
