// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.ProfessionalColorTable
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using System;
using System.Collections;
using System.Drawing;

namespace Gizmox.WebGUI.Forms
{
  /// <summary>Provides colors used for Microsoft Office display elements.</summary>
  [Serializable]
  public class ProfessionalColorTable
  {
    private const string mcntAeroFileName = "aero.msstyles";
    private object mobjColorFreshnessKey;
    private string mstrLastKnownColorScheme = string.Empty;
    private const string mcntLunaFileName = "luna.msstyles";
    private const string mcntNormalColorScheme = "NormalColor";
    private const string mcntOliveColorScheme = "HomeStead";
    private Hashtable mobjProfessionalRGB;
    private const string mcntRoyaleColorScheme = "Royale";
    private const string mcntRoyaleFileName = "royale.msstyles";
    private const string mcntSilverColorScheme = "Metallic";
    private bool mblnUseSystemColors;
    private bool mblnUsingSystemColors;

    internal Color FromKnownColor(ProfessionalColorTable.KnownColors color) => (Color) this.ColorTable[(object) color];

    internal void InitBlueLunaColors(ref Hashtable rgbTable)
    {
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBdrOuterDocked] = (object) Color.FromArgb(196, 205, 218);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBdrOuterDocked] = (object) Color.FromArgb(196, 205, 218);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBdrOuterFloating] = (object) Color.FromArgb(42, 102, 201);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBkgd] = (object) Color.FromArgb(196, 219, 249);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrMouseDown] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrMouseOver] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrSelected] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrSelectedMouseOver] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgd] = (object) Color.FromArgb(196, 219, 249);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdLight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdMouseDown] = (object) Color.FromArgb(254, 128, 62);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdSelected] = (object) Color.FromArgb((int) byte.MaxValue, 192, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdSelectedMouseOver] = (object) Color.FromArgb(254, 128, 62);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextDisabled] = (object) Color.FromArgb(141, 141, 141);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextLight] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextMouseDown] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDockSeparatorLine] = (object) Color.FromArgb(0, 53, 145);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDragHandle] = (object) Color.FromArgb(39, 65, 118);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDragHandleShadow] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDropDownArrow] = (object) Color.FromArgb(236, 233, 216);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzBegin] = (object) Color.FromArgb(158, 190, 245);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzEnd] = (object) Color.FromArgb(196, 218, 250);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedBegin] = (object) Color.FromArgb(203, 221, 246);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedEnd] = (object) Color.FromArgb(114, 155, 215);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedMiddle] = (object) Color.FromArgb(161, 197, 249);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuTitleBkgdBegin] = (object) Color.FromArgb(227, 239, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuTitleBkgdEnd] = (object) Color.FromArgb(123, 164, 224);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownBegin] = (object) Color.FromArgb(254, 128, 62);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownEnd] = (object) Color.FromArgb((int) byte.MaxValue, 223, 154);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownMiddle] = (object) Color.FromArgb((int) byte.MaxValue, 177, 109);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverBegin] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 222);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverEnd] = (object) Color.FromArgb((int) byte.MaxValue, 203, 136);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverMiddle] = (object) Color.FromArgb((int) byte.MaxValue, 225, 172);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsBegin] = (object) Color.FromArgb((int) sbyte.MaxValue, 177, 250);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsEnd] = (object) Color.FromArgb(0, 53, 145);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMiddle] = (object) Color.FromArgb(82, (int) sbyte.MaxValue, 208);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMouseOverBegin] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 222);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMouseOverEnd] = (object) Color.FromArgb((int) byte.MaxValue, 193, 118);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMouseOverMiddle] = (object) Color.FromArgb((int) byte.MaxValue, 225, 172);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsSelectedBegin] = (object) Color.FromArgb(254, 140, 73);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsSelectedEnd] = (object) Color.FromArgb((int) byte.MaxValue, 221, 152);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsSelectedMiddle] = (object) Color.FromArgb((int) byte.MaxValue, 184, 116);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedBegin] = (object) Color.FromArgb((int) byte.MaxValue, 223, 154);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedEnd] = (object) Color.FromArgb((int) byte.MaxValue, 166, 76);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedMiddle] = (object) Color.FromArgb((int) byte.MaxValue, 195, 116);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradVertBegin] = (object) Color.FromArgb(227, 239, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradVertEnd] = (object) Color.FromArgb(123, 164, 224);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradVertMiddle] = (object) Color.FromArgb(203, 225, 252);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBIconDisabledDark] = (object) Color.FromArgb(97, 122, 172);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBIconDisabledLight] = (object) Color.FromArgb(233, 236, 242);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBLabelBkgnd] = (object) Color.FromArgb(186, 211, 245);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBLabelBkgnd] = (object) Color.FromArgb(186, 211, 245);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBLowColorIconDisabled] = (object) Color.FromArgb(109, 150, 208);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMainMenuBkgd] = (object) Color.FromArgb(153, 204, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuBdrOuter] = (object) Color.FromArgb(0, 45, 150);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuBkgd] = (object) Color.FromArgb(246, 246, 246);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuCtlText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuCtlTextDisabled] = (object) Color.FromArgb(141, 141, 141);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuIconBkgd] = (object) Color.FromArgb(203, 225, 252);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuIconBkgdDropped] = (object) Color.FromArgb(172, 183, 201);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuIconBkgdDropped] = (object) Color.FromArgb(172, 183, 201);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuShadow] = (object) Color.FromArgb(95, 130, 234);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuSplitArrow] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBOptionsButtonShadow] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBShadow] = (object) Color.FromArgb(59, 97, 156);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBSplitterLine] = (object) Color.FromArgb(106, 140, 203);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBSplitterLineLight] = (object) Color.FromArgb(241, 249, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTearOffHandle] = (object) Color.FromArgb(169, 199, 240);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTearOffHandleMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTitleBkgd] = (object) Color.FromArgb(42, 102, 201);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTitleText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDisabledFocuslessHighlightedText] = (object) Color.FromArgb(172, 168, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDisabledHighlightedText] = (object) Color.FromArgb(187, 206, 236);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDlgGroupBoxText] = (object) Color.FromArgb(0, 70, 213);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdr] = (object) Color.FromArgb(0, 53, 154);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDark] = (object) Color.FromArgb(117, 166, 241);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseDown] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseOver] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseOver] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseOver] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseDown] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseOver] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseOver] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseOver] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseDown] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseOver] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseOver] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseOver] = (object) Color.FromArgb(0, 0, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrSelected] = (object) Color.FromArgb(59, 97, 156);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgd] = (object) Color.FromArgb(186, 211, 245);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdMouseDown] = (object) Color.FromArgb(254, 128, 62);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdSelected] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseDown] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextSelected] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabBkgd] = (object) Color.FromArgb(186, 211, 245);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabBkgd] = (object) Color.FromArgb(186, 211, 245);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabTextDisabled] = (object) Color.FromArgb(94, 94, 94);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabTextDisabled] = (object) Color.FromArgb(94, 94, 94);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabBkgd] = (object) Color.FromArgb(129, 169, 226);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabBkgd] = (object) Color.FromArgb(129, 169, 226);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabBkgdMouseDown] = (object) Color.FromArgb(254, 128, 62);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabBkgdMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabTextMouseDown] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedBkgd] = (object) Color.FromArgb(236, 233, 216);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedBkgd] = (object) Color.FromArgb(236, 233, 216);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderBdr] = (object) Color.FromArgb(89, 89, 172);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderBkgd] = (object) Color.FromArgb(239, 235, 222);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderCellBdr] = (object) Color.FromArgb(126, 125, 104);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderCellBkgd] = (object) Color.FromArgb(239, 235, 222);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderCellBkgdSelected] = (object) Color.FromArgb((int) byte.MaxValue, 192, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderSeeThroughSelection] = (object) Color.FromArgb(191, 191, 223);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPDarkBkgd] = (object) Color.FromArgb(74, 122, 201);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPDarkBkgd] = (object) Color.FromArgb(74, 122, 201);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentDarkBkgd] = (object) Color.FromArgb(185, 208, 241);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentLightBkgd] = (object) Color.FromArgb(221, 236, 254);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentTextDisabled] = (object) Color.FromArgb(150, 145, 133);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderDarkBkgd] = (object) Color.FromArgb(101, 143, 224);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderLightBkgd] = (object) Color.FromArgb(196, 219, 249);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderText] = (object) Color.FromArgb(0, 45, 134);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderText] = (object) Color.FromArgb(0, 45, 134);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupline] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupline] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPHyperlink] = (object) Color.FromArgb(0, 61, 178);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPLightBkgd] = (object) Color.FromArgb(221, 236, 254);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrHyperlink] = (object) Color.FromArgb(0, 61, 178);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrHyperlinkFollowed] = (object) Color.FromArgb(170, 0, 170);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIBdr] = (object) Color.FromArgb(59, 97, 156);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIBdr] = (object) Color.FromArgb(59, 97, 156);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradBegin] = (object) Color.FromArgb(158, 190, 245);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradBegin] = (object) Color.FromArgb(158, 190, 245);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradEnd] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradMiddle] = (object) Color.FromArgb(196, 218, 250);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradMiddle] = (object) Color.FromArgb(196, 218, 250);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrListHeaderArrow] = (object) Color.FromArgb(172, 168, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrNetLookBkgnd] = (object) Color.FromArgb(227, 239, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOABBkgd] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOBBkgdBdr] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOBBkgdBdrContrast] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGMDIParentWorkspaceBkgd] = (object) Color.FromArgb(144, 153, 174);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerActiveBkgd] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerBdr] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerBkgd] = (object) Color.FromArgb(216, 231, 252);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerInactiveBkgd] = (object) Color.FromArgb(158, 190, 245);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerTabBoxBdr] = (object) Color.FromArgb(75, 120, 202);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerTabBoxBdrHighlight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerTabStopTicks] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGTaskPaneGroupBoxHeaderBkgd] = (object) Color.FromArgb(186, 211, 245);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGWorkspaceBkgd] = (object) Color.FromArgb(144, 153, 174);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFlagNone] = (object) Color.FromArgb(242, 240, 228);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFolderbarDark] = (object) Color.FromArgb(0, 53, 145);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFolderbarLight] = (object) Color.FromArgb(89, 135, 214);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFolderbarText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGridlines] = (object) Color.FromArgb(234, 233, 225);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupLine] = (object) Color.FromArgb(123, 164, 224);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupNested] = (object) Color.FromArgb(253, 238, 201);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupShaded] = (object) Color.FromArgb(190, 218, 251);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupText] = (object) Color.FromArgb(55, 104, 185);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKIconBar] = (object) Color.FromArgb(253, 247, 233);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKInfoBarBkgd] = (object) Color.FromArgb(144, 153, 174);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKInfoBarText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKPreviewPaneLabelText] = (object) Color.FromArgb(144, 153, 174);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKTodayIndicatorDark] = (object) Color.FromArgb(187, 85, 3);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKTodayIndicatorLight] = (object) Color.FromArgb(251, 200, 79);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBActionDividerLine] = (object) Color.FromArgb(215, 228, 251);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBButtonDark] = (object) Color.FromArgb(123, 164, 224);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBButtonLight] = (object) Color.FromArgb(203, 225, 252);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBButtonLight] = (object) Color.FromArgb(203, 225, 252);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBDarkOutline] = (object) Color.FromArgb(0, 45, 150);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBFoldersBackground] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBHoverButtonDark] = (object) Color.FromArgb(247, 190, 87);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBHoverButtonLight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 220);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBLabelText] = (object) Color.FromArgb(50, 69, 105);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBPressedButtonDark] = (object) Color.FromArgb(248, 222, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBPressedButtonLight] = (object) Color.FromArgb(232, (int) sbyte.MaxValue, 8);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSelectedButtonDark] = (object) Color.FromArgb(238, 147, 17);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSelectedButtonLight] = (object) Color.FromArgb(251, 230, 148);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSplitterDark] = (object) Color.FromArgb(0, 53, 145);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSplitterLight] = (object) Color.FromArgb(89, 135, 214);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSplitterLight] = (object) Color.FromArgb(89, 135, 214);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPlacesBarBkgd] = (object) Color.FromArgb(236, 233, 216);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabAreaBkgd] = (object) Color.FromArgb(195, 218, 249);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabBdr] = (object) Color.FromArgb(59, 97, 156);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabInactiveBkgd] = (object) Color.FromArgb(158, 190, 245);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrActiveSelected] = (object) Color.FromArgb(61, 108, 192);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrActiveSelectedMouseOver] = (object) Color.FromArgb(61, 108, 192);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrInactiveSelected] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrMouseOver] = (object) Color.FromArgb(61, 108, 192);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPubPrintDocScratchPageBkgd] = (object) Color.FromArgb(144, 153, 174);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPubWebDocScratchPageBkgd] = (object) Color.FromArgb(189, 194, 207);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrSBBdr] = (object) Color.FromArgb(211, 211, 211);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrScrollbarBkgd] = (object) Color.FromArgb(251, 251, 248);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrToastGradBegin] = (object) Color.FromArgb(220, 236, 254);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrToastGradEnd] = (object) Color.FromArgb(167, 197, 238);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBdrInnerDocked] = (object) Color.FromArgb(185, 212, 249);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBdrOuterDocked] = (object) Color.FromArgb(196, 218, 250);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBdrOuterFloating] = (object) Color.FromArgb(42, 102, 201);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBkgd] = (object) Color.FromArgb(221, 236, 254);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdr] = (object) Color.FromArgb((int) sbyte.MaxValue, 157, 185);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdrDefault] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdrDefault] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdrDisabled] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBkgd] = (object) Color.FromArgb(169, 199, 240);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBkgdDisabled] = (object) Color.FromArgb(222, 222, 222);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlTextDisabled] = (object) Color.FromArgb(172, 168, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlTextMouseDown] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPGroupline] = (object) Color.FromArgb(123, 164, 224);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPInfoTipBkgd] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 204);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPInfoTipText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPNavBarBkgnd] = (object) Color.FromArgb(74, 122, 201);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTextDisabled] = (object) Color.FromArgb(172, 168, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleBkgdActive] = (object) Color.FromArgb(123, 164, 224);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleBkgdInactive] = (object) Color.FromArgb(148, 187, 239);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleTextActive] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleTextInactive] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrXLFormulaBarBkgd] = (object) Color.FromArgb(158, 190, 245);
    }

    private void InitCommonColors(ref Hashtable rgbTable)
    {
      rgbTable[(object) ProfessionalColorTable.KnownColors.ButtonPressedHighlight] = (object) SystemColors.Highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.ButtonCheckedHighlight] = (object) SystemColors.ControlLight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.ButtonSelectedHighlight] = (object) SystemColors.ControlLight;
    }

    internal void InitOliveLunaColors(ref Hashtable rgbTable)
    {
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBdrOuterDocked] = (object) Color.FromArgb(81, 94, 51);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBdrOuterDocked] = (object) Color.FromArgb(81, 94, 51);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBdrOuterFloating] = (object) Color.FromArgb(116, 134, 94);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBkgd] = (object) Color.FromArgb(209, 222, 173);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrMouseDown] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrMouseOver] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrSelected] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrSelectedMouseOver] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgd] = (object) Color.FromArgb(209, 222, 173);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdLight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdMouseDown] = (object) Color.FromArgb(254, 128, 62);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdSelected] = (object) Color.FromArgb((int) byte.MaxValue, 192, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdSelectedMouseOver] = (object) Color.FromArgb(254, 128, 62);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextDisabled] = (object) Color.FromArgb(141, 141, 141);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextLight] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextMouseDown] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDockSeparatorLine] = (object) Color.FromArgb(96, 119, 66);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDragHandle] = (object) Color.FromArgb(81, 94, 51);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDragHandleShadow] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDropDownArrow] = (object) Color.FromArgb(236, 233, 216);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzBegin] = (object) Color.FromArgb(217, 217, 167);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzEnd] = (object) Color.FromArgb(242, 241, 228);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedBegin] = (object) Color.FromArgb(230, 230, 209);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedEnd] = (object) Color.FromArgb(160, 177, 116);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedMiddle] = (object) Color.FromArgb(186, 201, 143);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuTitleBkgdBegin] = (object) Color.FromArgb(237, 240, 214);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuTitleBkgdEnd] = (object) Color.FromArgb(181, 196, 143);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownBegin] = (object) Color.FromArgb(254, 128, 62);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownEnd] = (object) Color.FromArgb((int) byte.MaxValue, 223, 154);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownMiddle] = (object) Color.FromArgb((int) byte.MaxValue, 177, 109);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverBegin] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 222);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverEnd] = (object) Color.FromArgb((int) byte.MaxValue, 203, 136);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverMiddle] = (object) Color.FromArgb((int) byte.MaxValue, 225, 172);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsBegin] = (object) Color.FromArgb(186, 204, 150);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsEnd] = (object) Color.FromArgb(96, 119, 107);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMiddle] = (object) Color.FromArgb(141, 160, 107);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMouseOverBegin] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 222);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMouseOverEnd] = (object) Color.FromArgb((int) byte.MaxValue, 193, 118);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMouseOverMiddle] = (object) Color.FromArgb((int) byte.MaxValue, 225, 172);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsSelectedBegin] = (object) Color.FromArgb(254, 140, 73);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsSelectedEnd] = (object) Color.FromArgb((int) byte.MaxValue, 221, 152);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsSelectedMiddle] = (object) Color.FromArgb((int) byte.MaxValue, 184, 116);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedBegin] = (object) Color.FromArgb((int) byte.MaxValue, 223, 154);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedEnd] = (object) Color.FromArgb((int) byte.MaxValue, 166, 76);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedMiddle] = (object) Color.FromArgb((int) byte.MaxValue, 195, 116);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradVertBegin] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 237);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradVertEnd] = (object) Color.FromArgb(181, 196, 143);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradVertMiddle] = (object) Color.FromArgb(206, 220, 167);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBIconDisabledDark] = (object) Color.FromArgb(131, 144, 113);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBIconDisabledLight] = (object) Color.FromArgb(243, 244, 240);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBLabelBkgnd] = (object) Color.FromArgb(218, 227, 187);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBLabelBkgnd] = (object) Color.FromArgb(218, 227, 187);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBLowColorIconDisabled] = (object) Color.FromArgb(159, 174, 122);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMainMenuBkgd] = (object) Color.FromArgb(236, 233, 216);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuBdrOuter] = (object) Color.FromArgb(117, 141, 94);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuBkgd] = (object) Color.FromArgb(244, 244, 238);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuCtlText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuCtlTextDisabled] = (object) Color.FromArgb(141, 141, 141);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuIconBkgd] = (object) Color.FromArgb(216, 227, 182);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuIconBkgdDropped] = (object) Color.FromArgb(173, 181, 157);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuIconBkgdDropped] = (object) Color.FromArgb(173, 181, 157);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuShadow] = (object) Color.FromArgb(134, 148, 108);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuSplitArrow] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBOptionsButtonShadow] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBShadow] = (object) Color.FromArgb(96, 128, 88);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBSplitterLine] = (object) Color.FromArgb(96, 128, 88);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBSplitterLineLight] = (object) Color.FromArgb(244, 247, 222);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTearOffHandle] = (object) Color.FromArgb(197, 212, 159);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTearOffHandleMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTitleBkgd] = (object) Color.FromArgb(116, 134, 94);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTitleText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDisabledFocuslessHighlightedText] = (object) Color.FromArgb(172, 168, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDisabledHighlightedText] = (object) Color.FromArgb(220, 224, 208);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDlgGroupBoxText] = (object) Color.FromArgb(153, 84, 10);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdr] = (object) Color.FromArgb(96, 119, 107);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDark] = (object) Color.FromArgb(176, 194, 140);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseDown] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseOver] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseOver] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseOver] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseDown] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseOver] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseOver] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseOver] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseDown] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseOver] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseOver] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseOver] = (object) Color.FromArgb(63, 93, 56);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrSelected] = (object) Color.FromArgb(96, 128, 88);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgd] = (object) Color.FromArgb(218, 227, 187);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdMouseDown] = (object) Color.FromArgb(254, 128, 62);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdSelected] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseDown] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextSelected] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabBkgd] = (object) Color.FromArgb(218, 227, 187);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabBkgd] = (object) Color.FromArgb(218, 227, 187);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabTextDisabled] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabTextDisabled] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabBkgd] = (object) Color.FromArgb(183, 198, 145);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabBkgd] = (object) Color.FromArgb(183, 198, 145);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabBkgdMouseDown] = (object) Color.FromArgb(254, 128, 62);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabBkgdMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabTextMouseDown] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedBkgd] = (object) Color.FromArgb(236, 233, 216);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedBkgd] = (object) Color.FromArgb(236, 233, 216);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderBdr] = (object) Color.FromArgb(191, 191, 223);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderBkgd] = (object) Color.FromArgb(239, 235, 222);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderCellBdr] = (object) Color.FromArgb(126, 125, 104);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderCellBkgd] = (object) Color.FromArgb(239, 235, 222);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderCellBkgdSelected] = (object) Color.FromArgb((int) byte.MaxValue, 192, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderSeeThroughSelection] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPDarkBkgd] = (object) Color.FromArgb(159, 171, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPDarkBkgd] = (object) Color.FromArgb(159, 171, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentDarkBkgd] = (object) Color.FromArgb(217, 227, 187);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentLightBkgd] = (object) Color.FromArgb(230, 234, 208);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentTextDisabled] = (object) Color.FromArgb(150, 145, 133);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderDarkBkgd] = (object) Color.FromArgb(161, 176, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderLightBkgd] = (object) Color.FromArgb(210, 223, 174);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderText] = (object) Color.FromArgb(90, 107, 70);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderText] = (object) Color.FromArgb(90, 107, 70);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupline] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupline] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPHyperlink] = (object) Color.FromArgb(0, 61, 178);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPLightBkgd] = (object) Color.FromArgb(243, 242, 231);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrHyperlink] = (object) Color.FromArgb(0, 61, 178);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrHyperlinkFollowed] = (object) Color.FromArgb(170, 0, 170);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIBdr] = (object) Color.FromArgb(96, 128, 88);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIBdr] = (object) Color.FromArgb(96, 128, 88);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradBegin] = (object) Color.FromArgb(217, 217, 167);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradBegin] = (object) Color.FromArgb(217, 217, 167);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradEnd] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradMiddle] = (object) Color.FromArgb(242, 241, 228);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradMiddle] = (object) Color.FromArgb(242, 241, 228);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrListHeaderArrow] = (object) Color.FromArgb(172, 168, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrNetLookBkgnd] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 237);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOABBkgd] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOBBkgdBdr] = (object) Color.FromArgb(211, 211, 211);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOBBkgdBdrContrast] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGMDIParentWorkspaceBkgd] = (object) Color.FromArgb(151, 160, 123);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerActiveBkgd] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerBdr] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerBkgd] = (object) Color.FromArgb(226, 231, 191);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerInactiveBkgd] = (object) Color.FromArgb(171, 192, 138);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerTabBoxBdr] = (object) Color.FromArgb(117, 141, 94);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerTabBoxBdrHighlight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerTabStopTicks] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGTaskPaneGroupBoxHeaderBkgd] = (object) Color.FromArgb(218, 227, 187);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGWorkspaceBkgd] = (object) Color.FromArgb(151, 160, 123);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFlagNone] = (object) Color.FromArgb(242, 240, 228);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFolderbarDark] = (object) Color.FromArgb(96, 119, 66);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFolderbarLight] = (object) Color.FromArgb(175, 192, 130);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFolderbarText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGridlines] = (object) Color.FromArgb(234, 233, 225);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupLine] = (object) Color.FromArgb(181, 196, 143);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupNested] = (object) Color.FromArgb(253, 238, 201);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupShaded] = (object) Color.FromArgb(175, 186, 145);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupText] = (object) Color.FromArgb(115, 137, 84);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKIconBar] = (object) Color.FromArgb(253, 247, 233);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKInfoBarBkgd] = (object) Color.FromArgb(151, 160, 123);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKInfoBarText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKPreviewPaneLabelText] = (object) Color.FromArgb(151, 160, 123);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKTodayIndicatorDark] = (object) Color.FromArgb(187, 85, 3);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKTodayIndicatorLight] = (object) Color.FromArgb(251, 200, 79);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBActionDividerLine] = (object) Color.FromArgb(200, 212, 172);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBButtonDark] = (object) Color.FromArgb(176, 191, 138);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBButtonLight] = (object) Color.FromArgb(234, 240, 207);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBButtonLight] = (object) Color.FromArgb(234, 240, 207);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBDarkOutline] = (object) Color.FromArgb(96, 128, 88);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBFoldersBackground] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBHoverButtonDark] = (object) Color.FromArgb(247, 190, 87);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBHoverButtonLight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 220);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBLabelText] = (object) Color.FromArgb(50, 69, 105);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBPressedButtonDark] = (object) Color.FromArgb(248, 222, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBPressedButtonLight] = (object) Color.FromArgb(232, (int) sbyte.MaxValue, 8);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSelectedButtonDark] = (object) Color.FromArgb(238, 147, 17);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSelectedButtonLight] = (object) Color.FromArgb(251, 230, 148);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSplitterDark] = (object) Color.FromArgb(64, 81, 59);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSplitterLight] = (object) Color.FromArgb(120, 142, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSplitterLight] = (object) Color.FromArgb(120, 142, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPlacesBarBkgd] = (object) Color.FromArgb(236, 233, 216);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabAreaBkgd] = (object) Color.FromArgb(242, 240, 228);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabBdr] = (object) Color.FromArgb(96, 128, 88);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabInactiveBkgd] = (object) Color.FromArgb(206, 220, 167);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrActiveSelected] = (object) Color.FromArgb(107, 129, 107);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrActiveSelectedMouseOver] = (object) Color.FromArgb(107, 129, 107);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrInactiveSelected] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrMouseOver] = (object) Color.FromArgb(107, 129, 107);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPubPrintDocScratchPageBkgd] = (object) Color.FromArgb(151, 160, 123);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPubWebDocScratchPageBkgd] = (object) Color.FromArgb(193, 198, 176);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrSBBdr] = (object) Color.FromArgb(211, 211, 211);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrScrollbarBkgd] = (object) Color.FromArgb(249, 249, 247);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrToastGradBegin] = (object) Color.FromArgb(237, 242, 212);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrToastGradEnd] = (object) Color.FromArgb(191, 206, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBdrInnerDocked] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBdrOuterDocked] = (object) Color.FromArgb(242, 241, 228);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBdrOuterFloating] = (object) Color.FromArgb(116, 134, 94);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBkgd] = (object) Color.FromArgb(243, 242, 231);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdr] = (object) Color.FromArgb(164, 185, (int) sbyte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdrDefault] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdrDefault] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdrDisabled] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBkgd] = (object) Color.FromArgb(197, 212, 159);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBkgdDisabled] = (object) Color.FromArgb(222, 222, 222);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlTextDisabled] = (object) Color.FromArgb(172, 168, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlTextMouseDown] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPGroupline] = (object) Color.FromArgb(188, 187, 177);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPInfoTipBkgd] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 204);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPInfoTipText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPNavBarBkgnd] = (object) Color.FromArgb(116, 134, 94);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTextDisabled] = (object) Color.FromArgb(172, 168, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleBkgdActive] = (object) Color.FromArgb(216, 227, 182);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleBkgdInactive] = (object) Color.FromArgb(188, 205, 131);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleTextActive] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleTextInactive] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrXLFormulaBarBkgd] = (object) Color.FromArgb(217, 217, 167);
    }

    private void InitRoyaleColors(ref Hashtable rgbTable)
    {
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBkgd] = (object) Color.FromArgb(238, 237, 240);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDragHandle] = (object) Color.FromArgb(189, 188, 191);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBSplitterLine] = (object) Color.FromArgb(193, 193, 196);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTitleBkgd] = (object) Color.FromArgb(167, 166, 170);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTitleText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBdrOuterFloating] = (object) Color.FromArgb(142, 141, 145);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBdrOuterDocked] = (object) Color.FromArgb(235, 233, 237);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTearOffHandle] = (object) Color.FromArgb(238, 237, 240);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTearOffHandleMouseOver] = (object) Color.FromArgb(194, 207, 229);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgd] = (object) Color.FromArgb(238, 237, 240);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextDisabled] = (object) Color.FromArgb(176, 175, 179);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdMouseOver] = (object) Color.FromArgb(194, 207, 229);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrMouseOver] = (object) Color.FromArgb(51, 94, 168);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdMouseDown] = (object) Color.FromArgb(153, 175, 212);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrMouseDown] = (object) Color.FromArgb(51, 94, 168);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextMouseDown] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdSelected] = (object) Color.FromArgb(226, 229, 238);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrSelected] = (object) Color.FromArgb(51, 94, 168);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdSelectedMouseOver] = (object) Color.FromArgb(51, 94, 168);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrSelectedMouseOver] = (object) Color.FromArgb(51, 94, 168);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdLight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextLight] = (object) Color.FromArgb(167, 166, 170);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMainMenuBkgd] = (object) Color.FromArgb(235, 233, 237);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuBkgd] = (object) Color.FromArgb(252, 252, 252);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuCtlText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuCtlTextDisabled] = (object) Color.FromArgb(193, 193, 196);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuBdrOuter] = (object) Color.FromArgb(134, 133, 136);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuIconBkgd] = (object) Color.FromArgb(238, 237, 240);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuIconBkgdDropped] = (object) Color.FromArgb(228, 226, 230);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuSplitArrow] = (object) Color.FromArgb(167, 166, 170);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBkgd] = (object) Color.FromArgb(245, 244, 246);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPText] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleBkgdActive] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleBkgdInactive] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleTextActive] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleTextInactive] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBdrOuterFloating] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBdrOuterDocked] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdr] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlText] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdrDisabled] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlTextDisabled] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBkgdDisabled] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdrDefault] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPGroupline] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrSBBdr] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOBBkgdBdr] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOBBkgdBdrContrast] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOABBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderBdr] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderCellBdr] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderSeeThroughSelection] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderCellBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderCellBkgdSelected] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBSplitterLineLight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBShadow] = (object) Color.FromArgb(238, 237, 240);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBOptionsButtonShadow] = (object) Color.FromArgb(245, 244, 246);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPNavBarBkgnd] = (object) Color.FromArgb(193, 193, 196);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBdrInnerDocked] = (object) Color.FromArgb(245, 244, 246);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBLabelBkgnd] = (object) Color.FromArgb(235, 233, 237);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBIconDisabledLight] = (object) Color.FromArgb(235, 233, 237);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBIconDisabledDark] = (object) Color.FromArgb(167, 166, 170);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBLowColorIconDisabled] = (object) Color.FromArgb(176, 175, 179);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzBegin] = (object) Color.FromArgb(235, 233, 237);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzEnd] = (object) Color.FromArgb(251, 250, 251);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradVertBegin] = (object) Color.FromArgb(252, 252, 252);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradVertMiddle] = (object) Color.FromArgb(245, 244, 246);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradVertEnd] = (object) Color.FromArgb(235, 233, 237);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsBegin] = (object) Color.FromArgb(242, 242, 242);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMiddle] = (object) Color.FromArgb(224, 224, 225);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsEnd] = (object) Color.FromArgb(167, 166, 170);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuTitleBkgdBegin] = (object) Color.FromArgb(252, 252, 252);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuTitleBkgdEnd] = (object) Color.FromArgb(245, 244, 246);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedBegin] = (object) Color.FromArgb(247, 246, 248);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedMiddle] = (object) Color.FromArgb(241, 240, 242);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedEnd] = (object) Color.FromArgb(228, 226, 230);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsSelectedBegin] = (object) Color.FromArgb(226, 229, 238);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsSelectedMiddle] = (object) Color.FromArgb(226, 229, 238);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsSelectedEnd] = (object) Color.FromArgb(226, 229, 238);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMouseOverBegin] = (object) Color.FromArgb(194, 207, 229);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMouseOverMiddle] = (object) Color.FromArgb(194, 207, 229);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMouseOverEnd] = (object) Color.FromArgb(194, 207, 229);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedBegin] = (object) Color.FromArgb(226, 229, 238);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedMiddle] = (object) Color.FromArgb(226, 229, 238);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedEnd] = (object) Color.FromArgb(226, 229, 238);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverBegin] = (object) Color.FromArgb(194, 207, 229);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverMiddle] = (object) Color.FromArgb(194, 207, 229);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverEnd] = (object) Color.FromArgb(194, 207, 229);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownBegin] = (object) Color.FromArgb(153, 175, 212);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownMiddle] = (object) Color.FromArgb(153, 175, 212);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownEnd] = (object) Color.FromArgb(153, 175, 212);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrNetLookBkgnd] = (object) Color.FromArgb(235, 233, 237);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuShadow] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDockSeparatorLine] = (object) Color.FromArgb(51, 94, 168);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDropDownArrow] = (object) Color.FromArgb(235, 233, 237);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGridlines] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupText] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupLine] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupShaded] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupNested] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKIconBar] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFlagNone] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFolderbarLight] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFolderbarDark] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFolderbarText] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBButtonLight] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBButtonDark] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSelectedButtonLight] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSelectedButtonDark] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBHoverButtonLight] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBHoverButtonDark] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBPressedButtonLight] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBPressedButtonDark] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBDarkOutline] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSplitterLight] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSplitterDark] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBActionDividerLine] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBLabelText] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBFoldersBackground] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKTodayIndicatorLight] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKTodayIndicatorDark] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKInfoBarBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKInfoBarText] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKPreviewPaneLabelText] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrHyperlink] = (object) Color.FromArgb(0, 61, 178);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrHyperlinkFollowed] = (object) Color.FromArgb(170, 0, 170);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGWorkspaceBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGMDIParentWorkspaceBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerActiveBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerInactiveBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerText] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerTabStopTicks] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerBdr] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerTabBoxBdr] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerTabBoxBdrHighlight] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrXLFormulaBarBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDragHandleShadow] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGTaskPaneGroupBoxHeaderBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabAreaBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabInactiveBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabBdr] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabText] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrActiveSelected] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrInactiveSelected] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrActiveSelectedMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDlgGroupBoxText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrScrollbarBkgd] = (object) Color.FromArgb(237, 235, 239);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrListHeaderArrow] = (object) Color.FromArgb(155, 154, 156);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDisabledHighlightedText] = (object) Color.FromArgb(188, 202, 226);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedBkgd] = (object) Color.FromArgb(235, 233, 237);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDisabledFocuslessHighlightedText] = (object) Color.FromArgb(167, 166, 170);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlTextMouseDown] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTextDisabled] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPInfoTipBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPInfoTipText] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabText] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabTextDisabled] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabText] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabBkgdMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabTextMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabBkgdMouseDown] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabTextMouseDown] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPLightBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPDarkBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderLightBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderDarkBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderText] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentLightBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentDarkBkgd] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentText] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentTextDisabled] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupline] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPHyperlink] = (object) Color.FromArgb((int) byte.MaxValue, 51, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgd] = (object) Color.FromArgb(212, 212, 226);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdr] = (object) Color.FromArgb(118, 116, 146);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDark] = (object) Color.FromArgb(186, 185, 206);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdSelected] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextSelected] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrSelected] = (object) Color.FromArgb(124, 124, 148);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdMouseOver] = (object) Color.FromArgb(193, 210, 238);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseOver] = (object) Color.FromArgb(49, 106, 197);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseOver] = (object) Color.FromArgb(49, 106, 197);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseOver] = (object) Color.FromArgb(49, 106, 197);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseOver] = (object) Color.FromArgb(49, 106, 197);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdMouseDown] = (object) Color.FromArgb(154, 183, 228);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseDown] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseDown] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseDown] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseDown] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrToastGradBegin] = (object) Color.FromArgb(246, 244, 236);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrToastGradEnd] = (object) Color.FromArgb(179, 178, 204);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradBegin] = (object) Color.FromArgb(236, 233, 216);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradMiddle] = (object) Color.FromArgb(236, 233, 216);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradEnd] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIBdr] = (object) Color.FromArgb(172, 168, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPlacesBarBkgd] = (object) Color.FromArgb(224, 223, 227);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPubPrintDocScratchPageBkgd] = (object) Color.FromArgb(152, 181, 226);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPubWebDocScratchPageBkgd] = (object) Color.FromArgb(193, 210, 238);
    }

    internal void InitSilverLunaColors(ref Hashtable rgbTable)
    {
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBdrOuterDocked] = (object) Color.FromArgb(173, 174, 193);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBdrOuterFloating] = (object) Color.FromArgb(122, 121, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBkgd] = (object) Color.FromArgb(219, 218, 228);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrMouseDown] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrMouseOver] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrSelected] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrSelectedMouseOver] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgd] = (object) Color.FromArgb(219, 218, 228);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdLight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdMouseDown] = (object) Color.FromArgb(254, 128, 62);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdSelected] = (object) Color.FromArgb((int) byte.MaxValue, 192, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdSelectedMouseOver] = (object) Color.FromArgb(254, 128, 62);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextDisabled] = (object) Color.FromArgb(141, 141, 141);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextLight] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextMouseDown] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDockSeparatorLine] = (object) Color.FromArgb(110, 109, 143);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDragHandle] = (object) Color.FromArgb(84, 84, 117);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDragHandleShadow] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDropDownArrow] = (object) Color.FromArgb(224, 223, 227);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzBegin] = (object) Color.FromArgb(215, 215, 229);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzEnd] = (object) Color.FromArgb(243, 243, 247);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedBegin] = (object) Color.FromArgb(215, 215, 226);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedEnd] = (object) Color.FromArgb(118, 116, 151);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedMiddle] = (object) Color.FromArgb(184, 185, 202);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuTitleBkgdBegin] = (object) Color.FromArgb(232, 233, 242);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuTitleBkgdEnd] = (object) Color.FromArgb(172, 170, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownBegin] = (object) Color.FromArgb(254, 128, 62);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownEnd] = (object) Color.FromArgb((int) byte.MaxValue, 223, 154);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownMiddle] = (object) Color.FromArgb((int) byte.MaxValue, 177, 109);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverBegin] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 222);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverEnd] = (object) Color.FromArgb((int) byte.MaxValue, 203, 136);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverMiddle] = (object) Color.FromArgb((int) byte.MaxValue, 225, 172);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsBegin] = (object) Color.FromArgb(186, 185, 206);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsEnd] = (object) Color.FromArgb(118, 116, 146);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMiddle] = (object) Color.FromArgb(156, 155, 180);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMouseOverBegin] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 222);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMouseOverEnd] = (object) Color.FromArgb((int) byte.MaxValue, 193, 118);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMouseOverMiddle] = (object) Color.FromArgb((int) byte.MaxValue, 225, 172);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsSelectedBegin] = (object) Color.FromArgb(254, 140, 73);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsSelectedEnd] = (object) Color.FromArgb((int) byte.MaxValue, 221, 152);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsSelectedMiddle] = (object) Color.FromArgb((int) byte.MaxValue, 184, 116);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedBegin] = (object) Color.FromArgb((int) byte.MaxValue, 223, 154);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedEnd] = (object) Color.FromArgb((int) byte.MaxValue, 166, 76);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedMiddle] = (object) Color.FromArgb((int) byte.MaxValue, 195, 116);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradVertBegin] = (object) Color.FromArgb(249, 249, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradVertEnd] = (object) Color.FromArgb(147, 145, 176);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradVertMiddle] = (object) Color.FromArgb(225, 226, 236);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBIconDisabledDark] = (object) Color.FromArgb(122, 121, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBIconDisabledLight] = (object) Color.FromArgb(247, 245, 249);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBLabelBkgnd] = (object) Color.FromArgb(212, 212, 226);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBLabelBkgnd] = (object) Color.FromArgb(212, 212, 226);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBLowColorIconDisabled] = (object) Color.FromArgb(168, 167, 190);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMainMenuBkgd] = (object) Color.FromArgb(198, 200, 215);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuBdrOuter] = (object) Color.FromArgb(124, 124, 148);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuBkgd] = (object) Color.FromArgb(253, 250, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuCtlText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuCtlTextDisabled] = (object) Color.FromArgb(141, 141, 141);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuIconBkgd] = (object) Color.FromArgb(214, 211, 231);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuIconBkgdDropped] = (object) Color.FromArgb(185, 187, 200);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuIconBkgdDropped] = (object) Color.FromArgb(185, 187, 200);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuShadow] = (object) Color.FromArgb(154, 140, 176);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuSplitArrow] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBOptionsButtonShadow] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBShadow] = (object) Color.FromArgb(124, 124, 148);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBSplitterLine] = (object) Color.FromArgb(110, 109, 143);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBSplitterLineLight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTearOffHandle] = (object) Color.FromArgb(192, 192, 211);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTearOffHandleMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTitleBkgd] = (object) Color.FromArgb(122, 121, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTitleText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDisabledFocuslessHighlightedText] = (object) Color.FromArgb(172, 168, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDisabledHighlightedText] = (object) Color.FromArgb(59, 59, 63);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDlgGroupBoxText] = (object) Color.FromArgb(7, 70, 213);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdr] = (object) Color.FromArgb(118, 116, 146);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDark] = (object) Color.FromArgb(186, 185, 206);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseDown] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseOver] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseOver] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseOver] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseDown] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseOver] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseOver] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseOver] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseDown] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseOver] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseOver] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseOver] = (object) Color.FromArgb(75, 75, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrSelected] = (object) Color.FromArgb(124, 124, 148);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgd] = (object) Color.FromArgb(212, 212, 226);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdMouseDown] = (object) Color.FromArgb(254, 128, 62);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdSelected] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseDown] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextSelected] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabBkgd] = (object) Color.FromArgb(212, 212, 226);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabBkgd] = (object) Color.FromArgb(212, 212, 226);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabTextDisabled] = (object) Color.FromArgb(148, 148, 148);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabTextDisabled] = (object) Color.FromArgb(148, 148, 148);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabBkgd] = (object) Color.FromArgb(171, 169, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabBkgd] = (object) Color.FromArgb(171, 169, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabBkgdMouseDown] = (object) Color.FromArgb(254, 128, 62);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabBkgdMouseOver] = (object) Color.FromArgb((int) byte.MaxValue, 238, 194);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabTextMouseDown] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabTextMouseOver] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedBkgd] = (object) Color.FromArgb(224, 223, 227);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedBkgd] = (object) Color.FromArgb(224, 223, 227);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderBdr] = (object) Color.FromArgb(191, 191, 223);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderBkgd] = (object) Color.FromArgb(239, 235, 222);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderCellBdr] = (object) Color.FromArgb(126, 125, 104);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderCellBkgd] = (object) Color.FromArgb(223, 223, 234);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderCellBkgdSelected] = (object) Color.FromArgb((int) byte.MaxValue, 192, 111);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderSeeThroughSelection] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPDarkBkgd] = (object) Color.FromArgb(162, 162, 181);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPDarkBkgd] = (object) Color.FromArgb(162, 162, 181);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentDarkBkgd] = (object) Color.FromArgb(212, 213, 229);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentLightBkgd] = (object) Color.FromArgb(227, 227, 236);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentTextDisabled] = (object) Color.FromArgb(150, 145, 133);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderDarkBkgd] = (object) Color.FromArgb(169, 168, 191);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderLightBkgd] = (object) Color.FromArgb(208, 208, 223);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderText] = (object) Color.FromArgb(92, 91, 121);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderText] = (object) Color.FromArgb(92, 91, 121);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupline] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupline] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPHyperlink] = (object) Color.FromArgb(0, 61, 178);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPLightBkgd] = (object) Color.FromArgb(238, 238, 244);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrHyperlink] = (object) Color.FromArgb(0, 61, 178);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrHyperlinkFollowed] = (object) Color.FromArgb(170, 0, 170);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIBdr] = (object) Color.FromArgb(124, 124, 148);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIBdr] = (object) Color.FromArgb(124, 124, 148);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradBegin] = (object) Color.FromArgb(215, 215, 229);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradBegin] = (object) Color.FromArgb(215, 215, 229);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradEnd] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradMiddle] = (object) Color.FromArgb(243, 243, 247);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradMiddle] = (object) Color.FromArgb(243, 243, 247);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrListHeaderArrow] = (object) Color.FromArgb(172, 168, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrNetLookBkgnd] = (object) Color.FromArgb(249, 249, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOABBkgd] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOBBkgdBdr] = (object) Color.FromArgb(211, 211, 211);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOBBkgdBdrContrast] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGMDIParentWorkspaceBkgd] = (object) Color.FromArgb(155, 154, 179);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerActiveBkgd] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerBdr] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerBkgd] = (object) Color.FromArgb(223, 223, 234);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerInactiveBkgd] = (object) Color.FromArgb(177, 176, 195);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerTabBoxBdr] = (object) Color.FromArgb(124, 124, 148);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerTabBoxBdrHighlight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerTabStopTicks] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGTaskPaneGroupBoxHeaderBkgd] = (object) Color.FromArgb(212, 212, 226);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGWorkspaceBkgd] = (object) Color.FromArgb(155, 154, 179);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFlagNone] = (object) Color.FromArgb(239, 239, 244);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFolderbarDark] = (object) Color.FromArgb(110, 109, 143);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFolderbarLight] = (object) Color.FromArgb(168, 167, 191);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFolderbarText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGridlines] = (object) Color.FromArgb(234, 233, 225);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupLine] = (object) Color.FromArgb(165, 164, 189);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupNested] = (object) Color.FromArgb(253, 238, 201);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupShaded] = (object) Color.FromArgb(229, 229, 235);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupText] = (object) Color.FromArgb(112, 111, 145);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKIconBar] = (object) Color.FromArgb(253, 247, 233);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKInfoBarBkgd] = (object) Color.FromArgb(155, 154, 179);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKInfoBarText] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKPreviewPaneLabelText] = (object) Color.FromArgb(155, 154, 179);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKTodayIndicatorDark] = (object) Color.FromArgb(187, 85, 3);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKTodayIndicatorLight] = (object) Color.FromArgb(251, 200, 79);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBActionDividerLine] = (object) Color.FromArgb(204, 206, 219);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBButtonDark] = (object) Color.FromArgb(147, 145, 176);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBButtonLight] = (object) Color.FromArgb(225, 226, 236);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBButtonLight] = (object) Color.FromArgb(225, 226, 236);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBDarkOutline] = (object) Color.FromArgb(124, 124, 148);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBFoldersBackground] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBHoverButtonDark] = (object) Color.FromArgb(247, 190, 87);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBHoverButtonLight] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 220);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBLabelText] = (object) Color.FromArgb(50, 69, 105);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBPressedButtonDark] = (object) Color.FromArgb(248, 222, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBPressedButtonLight] = (object) Color.FromArgb(232, (int) sbyte.MaxValue, 8);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSelectedButtonDark] = (object) Color.FromArgb(238, 147, 17);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSelectedButtonLight] = (object) Color.FromArgb(251, 230, 148);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSplitterDark] = (object) Color.FromArgb(110, 109, 143);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSplitterLight] = (object) Color.FromArgb(168, 167, 191);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSplitterLight] = (object) Color.FromArgb(168, 167, 191);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPlacesBarBkgd] = (object) Color.FromArgb(224, 223, 227);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabAreaBkgd] = (object) Color.FromArgb(243, 243, 247);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabBdr] = (object) Color.FromArgb(124, 124, 148);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabInactiveBkgd] = (object) Color.FromArgb(215, 215, 229);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrActiveSelected] = (object) Color.FromArgb(142, 142, 170);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrActiveSelectedMouseOver] = (object) Color.FromArgb(142, 142, 170);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrInactiveSelected] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrMouseOver] = (object) Color.FromArgb(142, 142, 170);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPubPrintDocScratchPageBkgd] = (object) Color.FromArgb(155, 154, 179);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPubWebDocScratchPageBkgd] = (object) Color.FromArgb(195, 195, 210);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrSBBdr] = (object) Color.FromArgb(236, 234, 218);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrScrollbarBkgd] = (object) Color.FromArgb(247, 247, 249);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrToastGradBegin] = (object) Color.FromArgb(239, 239, 247);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrToastGradEnd] = (object) Color.FromArgb(179, 178, 204);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBdrInnerDocked] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBdrOuterDocked] = (object) Color.FromArgb(243, 243, 247);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBdrOuterFloating] = (object) Color.FromArgb(122, 121, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBkgd] = (object) Color.FromArgb(238, 238, 244);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdr] = (object) Color.FromArgb(165, 172, 178);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdrDefault] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdrDefault] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdrDisabled] = (object) Color.FromArgb(128, 128, 128);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBkgd] = (object) Color.FromArgb(192, 192, 211);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBkgdDisabled] = (object) Color.FromArgb(222, 222, 222);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlTextDisabled] = (object) Color.FromArgb(172, 168, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlTextMouseDown] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPGroupline] = (object) Color.FromArgb(161, 160, 187);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPInfoTipBkgd] = (object) Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, 204);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPInfoTipText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPNavBarBkgnd] = (object) Color.FromArgb(122, 121, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPText] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTextDisabled] = (object) Color.FromArgb(172, 168, 153);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleBkgdActive] = (object) Color.FromArgb(184, 188, 234);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleBkgdInactive] = (object) Color.FromArgb(198, 198, 217);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleTextActive] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleTextInactive] = (object) Color.FromArgb(0, 0, 0);
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrXLFormulaBarBkgd] = (object) Color.FromArgb(215, 215, 229);
    }

    internal void InitSystemColors(ref Hashtable rgbTable)
    {
      this.mblnUsingSystemColors = true;
      this.InitCommonColors(ref rgbTable);
      Color buttonFace = SystemColors.ButtonFace;
      Color buttonShadow = SystemColors.ButtonShadow;
      Color highlight = SystemColors.Highlight;
      Color window = SystemColors.Window;
      Color empty = Color.Empty;
      Color controlText = SystemColors.ControlText;
      Color buttonHighlight = SystemColors.ButtonHighlight;
      Color grayText = SystemColors.GrayText;
      Color highlightText = SystemColors.HighlightText;
      Color windowText = SystemColors.WindowText;
      Color color1 = buttonFace;
      Color color2 = buttonFace;
      Color color3 = buttonFace;
      Color color4 = highlight;
      Color color5 = window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdSelectedMouseOver] = (object) SystemColors.ControlLight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDragHandle] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzEnd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsBegin] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMiddle] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedBegin] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedMiddle] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedEnd] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuBdrOuter] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuBkgd] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBSplitterLine] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdSelected] = (object) SystemColors.ControlLight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBdrOuterDocked] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBdrOuterDocked] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBdrOuterFloating] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrMouseDown] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrMouseOver] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrSelected] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrSelectedMouseOver] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgd] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdLight] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdMouseDown] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdMouseOver] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlText] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextDisabled] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextLight] = (object) grayText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextMouseDown] = (object) highlightText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBCtlTextMouseOver] = (object) windowText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDockSeparatorLine] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDragHandleShadow] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBDropDownArrow] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzBegin] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverEnd] = (object) color5;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverBegin] = (object) color5;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverMiddle] = (object) color5;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsEnd] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMouseOverBegin] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMouseOverEnd] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMouseOverMiddle] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsSelectedBegin] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsSelectedEnd] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsSelectedMiddle] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedBegin] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedEnd] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedMiddle] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradVertBegin] = (object) color1;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradVertMiddle] = (object) color2;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradVertEnd] = (object) color3;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownBegin] = (object) color4;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownMiddle] = (object) color4;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownEnd] = (object) color4;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuTitleBkgdBegin] = (object) color1;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuTitleBkgdEnd] = (object) color2;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBIconDisabledDark] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBIconDisabledLight] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBLabelBkgnd] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBLowColorIconDisabled] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMainMenuBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuCtlText] = (object) windowText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuCtlTextDisabled] = (object) grayText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuIconBkgd] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuIconBkgdDropped] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuShadow] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBMenuSplitArrow] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBOptionsButtonShadow] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBShadow] = rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBBkgd];
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBSplitterLineLight] = (object) buttonHighlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTearOffHandle] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTearOffHandleMouseOver] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTitleBkgd] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrCBTitleText] = (object) buttonHighlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDisabledFocuslessHighlightedText] = (object) grayText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDisabledHighlightedText] = (object) grayText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDlgGroupBoxText] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdr] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDark] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseDown] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrDarkMouseOver] = (object) SystemColors.MenuText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLight] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseDown] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrLightMouseOver] = (object) SystemColors.MenuText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseDown] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrMouseOver] = (object) SystemColors.MenuText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBdrSelected] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdMouseDown] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdMouseOver] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabBkgdSelected] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabText] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseDown] = (object) highlightText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextMouseOver] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDocTabTextSelected] = (object) windowText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabBkgd] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabText] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabText] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabTextDisabled] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWActiveTabTextDisabled] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabBkgd] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabText] = (object) buttonHighlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWInactiveTabText] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabBkgdMouseDown] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabBkgdMouseOver] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabTextMouseDown] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrDWTabTextMouseOver] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedBkgd] = (object) SystemColors.InactiveCaption;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedText] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrFocuslessHighlightedText] = (object) SystemColors.InactiveCaptionText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderBdr] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderBkgd] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderCellBdr] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderCellBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderCellBkgdSelected] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGDHeaderSeeThroughSelection] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPDarkBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPDarkBkgd] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentDarkBkgd] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentLightBkgd] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentText] = (object) windowText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupContentTextDisabled] = (object) grayText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderDarkBkgd] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderLightBkgd] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderText] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupHeaderText] = (object) windowText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupline] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPGroupline] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPHyperlink] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrGSPLightBkgd] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrHyperlink] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrHyperlinkFollowed] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIBdr] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIBdr] = (object) windowText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradBegin] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradBegin] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradEnd] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradMiddle] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIGradMiddle] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrJotNavUIText] = (object) windowText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrListHeaderArrow] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrNetLookBkgnd] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOABBkgd] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOBBkgdBdr] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOBBkgdBdrContrast] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGMDIParentWorkspaceBkgd] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerActiveBkgd] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerBdr] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerInactiveBkgd] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerTabBoxBdr] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerTabBoxBdrHighlight] = (object) buttonHighlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerTabStopTicks] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGRulerText] = (object) windowText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGTaskPaneGroupBoxHeaderBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOGWorkspaceBkgd] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFlagNone] = (object) buttonHighlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFolderbarDark] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFolderbarLight] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKFolderbarText] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGridlines] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupLine] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupNested] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupShaded] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKGroupText] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKIconBar] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKInfoBarBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKInfoBarText] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKPreviewPaneLabelText] = (object) windowText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKTodayIndicatorDark] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKTodayIndicatorLight] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBActionDividerLine] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBButtonDark] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBButtonLight] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBButtonLight] = (object) buttonHighlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBDarkOutline] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBFoldersBackground] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBHoverButtonDark] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBHoverButtonLight] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBLabelText] = (object) windowText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBPressedButtonDark] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBPressedButtonLight] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSelectedButtonDark] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSelectedButtonLight] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSplitterDark] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSplitterLight] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrOLKWBSplitterLight] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPlacesBarBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabAreaBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabBdr] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabInactiveBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPOutlineThumbnailsPaneTabText] = (object) windowText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrActiveSelected] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrActiveSelectedMouseOver] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrInactiveSelected] = (object) grayText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPPSlideBdrMouseOver] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPubPrintDocScratchPageBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrPubWebDocScratchPageBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrSBBdr] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrScrollbarBkgd] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrToastGradBegin] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrToastGradEnd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBdrInnerDocked] = (object) empty;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBdrOuterDocked] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBdrOuterFloating] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPBkgd] = (object) window;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdr] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdrDefault] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdrDefault] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBdrDisabled] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBkgd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlBkgdDisabled] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlText] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlTextDisabled] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPCtlTextMouseDown] = (object) highlightText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPGroupline] = (object) buttonShadow;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPInfoTipBkgd] = (object) SystemColors.Info;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPInfoTipText] = (object) SystemColors.InfoText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPNavBarBkgnd] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPText] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPText] = (object) windowText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTextDisabled] = (object) grayText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleBkgdActive] = (object) highlight;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleBkgdInactive] = (object) buttonFace;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleTextActive] = (object) highlightText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrWPTitleTextInactive] = (object) controlText;
      rgbTable[(object) ProfessionalColorTable.KnownColors.msocbvcrXLFormulaBarBkgd] = (object) buttonFace;
    }

    internal void InitThemedColors(ref Hashtable rgbTable)
    {
      this.InitSystemColors(ref rgbTable);
      this.mblnUsingSystemColors = true;
      this.InitCommonColors(ref rgbTable);
    }

    private void ResetRGBTable()
    {
      if (this.mobjProfessionalRGB != null)
        this.mobjProfessionalRGB.Clear();
      this.mobjProfessionalRGB = (Hashtable) null;
    }

    /// <summary>Gets the starting color of the gradient used when the button is checked.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the button is checked.</returns>
    [SRDescription("ProfessionalColorsButtonCheckedGradientBeginDescr")]
    public virtual Color ButtonCheckedGradientBegin => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedBegin);

    /// <summary>Gets the end color of the gradient used when the button is checked.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the button is checked.</returns>
    [SRDescription("ProfessionalColorsButtonCheckedGradientEndDescr")]
    public virtual Color ButtonCheckedGradientEnd => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedEnd);

    /// <summary>Gets the middle color of the gradient used when the button is checked.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when the button is checked.</returns>
    [SRDescription("ProfessionalColorsButtonCheckedGradientMiddleDescr")]
    public virtual Color ButtonCheckedGradientMiddle => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradSelectedMiddle);

    /// <summary>Gets the solid color used when the button is checked.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color used when the button is checked.</returns>
    [SRDescription("ProfessionalColorsButtonCheckedHighlightDescr")]
    public virtual Color ButtonCheckedHighlight => this.FromKnownColor(ProfessionalColorTable.KnownColors.ButtonCheckedHighlight);

    /// <summary>Gets the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonCheckedHighlight"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonCheckedHighlight"></see>.</returns>
    [SRDescription("ProfessionalColorsButtonCheckedHighlightBorderDescr")]
    public virtual Color ButtonCheckedHighlightBorder => SystemColors.Highlight;

    /// <summary>Gets the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedGradientEnd"></see> colors.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedGradientEnd"></see> colors.</returns>
    [SRDescription("ProfessionalColorsButtonPressedBorderDescr")]
    public virtual Color ButtonPressedBorder => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrMouseOver);

    /// <summary>Gets the starting color of the gradient used when the button is pressed.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the button is pressed.</returns>
    [SRDescription("ProfessionalColorsButtonPressedGradientBeginDescr")]
    public virtual Color ButtonPressedGradientBegin => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownBegin);

    /// <summary>Gets the end color of the gradient used when the button is pressed.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the button is pressed.</returns>
    [SRDescription("ProfessionalColorsButtonPressedGradientEndDescr")]
    public virtual Color ButtonPressedGradientEnd => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownEnd);

    /// <summary>Gets the middle color of the gradient used when the button is pressed.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when the button is pressed.</returns>
    [SRDescription("ProfessionalColorsButtonPressedGradientMiddleDescr")]
    public virtual Color ButtonPressedGradientMiddle => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseDownMiddle);

    /// <summary>Gets the solid color used when the button is pressed.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color used when the button is pressed.</returns>
    [SRDescription("ProfessionalColorsButtonPressedHighlightDescr")]
    public virtual Color ButtonPressedHighlight => this.FromKnownColor(ProfessionalColorTable.KnownColors.ButtonPressedHighlight);

    /// <summary>Gets the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedHighlight"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedHighlight"></see>.</returns>
    [SRDescription("ProfessionalColorsButtonPressedHighlightBorderDescr")]
    public virtual Color ButtonPressedHighlightBorder => SystemColors.Highlight;

    /// <summary>Gets the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedGradientEnd"></see> colors.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedGradientEnd"></see> colors.</returns>
    [SRDescription("ProfessionalColorsButtonSelectedBorderDescr")]
    public virtual Color ButtonSelectedBorder => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrMouseOver);

    /// <summary>Gets the starting color of the gradient used when the button is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the button is selected.</returns>
    [SRDescription("ProfessionalColorsButtonSelectedGradientBeginDescr")]
    public virtual Color ButtonSelectedGradientBegin => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverBegin);

    /// <summary>Gets the end color of the gradient used when the button is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the button is selected.</returns>
    [SRDescription("ProfessionalColorsButtonSelectedGradientEndDescr")]
    public virtual Color ButtonSelectedGradientEnd => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverEnd);

    /// <summary>Gets the middle color of the gradient used when the button is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when the button is selected.</returns>
    [SRDescription("ProfessionalColorsButtonSelectedGradientMiddleDescr")]
    public virtual Color ButtonSelectedGradientMiddle => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverMiddle);

    /// <summary>Gets the solid color used when the button is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color used when the button is selected.</returns>
    [SRDescription("ProfessionalColorsButtonSelectedHighlightDescr")]
    public virtual Color ButtonSelectedHighlight => this.FromKnownColor(ProfessionalColorTable.KnownColors.ButtonSelectedHighlight);

    /// <summary>Gets the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedHighlight"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedHighlight"></see>.</returns>
    [SRDescription("ProfessionalColorsButtonSelectedHighlightBorderDescr")]
    public virtual Color ButtonSelectedHighlightBorder => this.ButtonPressedBorder;

    /// <summary>Gets the solid color to use when the button is checked and gradients are being used.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when the button is checked and gradients are being used.</returns>
    [SRDescription("ProfessionalColorsCheckBackgroundDescr")]
    public virtual Color CheckBackground => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdSelected);

    /// <summary>Gets the solid color to use when the button is checked and selected and gradients are being used.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when the button is checked and selected and gradients are being used.</returns>
    [SRDescription("ProfessionalColorsCheckPressedBackgroundDescr")]
    public virtual Color CheckPressedBackground => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdSelectedMouseOver);

    /// <summary>Gets the solid color to use when the button is checked and selected and gradients are being used.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when the button is checked and selected and gradients are being used.</returns>
    [SRDescription("ProfessionalColorsCheckSelectedBackgroundDescr")]
    public virtual Color CheckSelectedBackground => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdSelectedMouseOver);

    private Hashtable ColorTable
    {
      get
      {
        if (this.mobjProfessionalRGB == null)
        {
          this.mobjProfessionalRGB = new Hashtable(212);
          this.InitSystemColors(ref this.mobjProfessionalRGB);
        }
        return this.mobjProfessionalRGB;
      }
    }

    internal Color ComboBoxBorder => this.ButtonSelectedHighlightBorder;

    internal Color ComboBoxButtonGradientBegin => this.MenuItemPressedGradientBegin;

    internal Color ComboBoxButtonGradientEnd => this.MenuItemPressedGradientEnd;

    internal Color ComboBoxButtonOnOverflow => this.ToolStripDropDownBackground;

    internal Color ComboBoxButtonPressedGradientBegin => this.ButtonPressedGradientBegin;

    internal Color ComboBoxButtonPressedGradientEnd => this.ButtonPressedGradientEnd;

    internal Color ComboBoxButtonSelectedGradientBegin => this.MenuItemSelectedGradientBegin;

    internal Color ComboBoxButtonSelectedGradientEnd => this.MenuItemSelectedGradientEnd;

    /// <summary>Gets the color to use for shadow effects on the grip (move handle).</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the color to use for shadow effects on the grip (move handle).</returns>
    [SRDescription("ProfessionalColorsGripDarkDescr")]
    public virtual Color GripDark => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBDragHandle);

    /// <summary>Gets the color to use for highlight effects on the grip (move handle).</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the color to use for highlight effects on the grip (move handle).</returns>
    [SRDescription("ProfessionalColorsGripLightDescr")]
    public virtual Color GripLight => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBDragHandleShadow);

    /// <summary>Gets the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</returns>
    [SRDescription("ProfessionalColorsImageMarginGradientBeginDescr")]
    public virtual Color ImageMarginGradientBegin => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradVertBegin);

    /// <summary>Gets the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</returns>
    [SRDescription("ProfessionalColorsImageMarginGradientEndDescr")]
    public virtual Color ImageMarginGradientEnd => !this.mblnUsingSystemColors ? this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradVertEnd) : SystemColors.Control;

    /// <summary>Gets the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</returns>
    [SRDescription("ProfessionalColorsImageMarginGradientMiddleDescr")]
    public virtual Color ImageMarginGradientMiddle => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradVertMiddle);

    /// <summary>Gets the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</returns>
    [SRDescription("ProfessionalColorsImageMarginRevealedGradientBeginDescr")]
    public virtual Color ImageMarginRevealedGradientBegin => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedBegin);

    /// <summary>Gets the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</returns>
    [SRDescription("ProfessionalColorsImageMarginRevealedGradientEndDescr")]
    public virtual Color ImageMarginRevealedGradientEnd => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedEnd);

    /// <summary>Gets the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</returns>
    [SRDescription("ProfessionalColorsImageMarginRevealedGradientMiddleDescr")]
    public virtual Color ImageMarginRevealedGradientMiddle => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedMiddle);

    /// <summary>Gets the color that is the border color to use on a <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use on a <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</returns>
    [SRDescription("ProfessionalColorsMenuBorderDescr")]
    public virtual Color MenuBorder => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBMenuBdrOuter);

    /// <summary>Gets the border color to use with a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use with a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</returns>
    [SRDescription("ProfessionalColorsMenuItemBorderDescr")]
    public virtual Color MenuItemBorder => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBCtlBdrSelected);

    /// <summary>Gets the starting color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed.</returns>
    [SRDescription("ProfessionalColorsMenuItemPressedGradientBeginDescr")]
    public virtual Color MenuItemPressedGradientBegin => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuTitleBkgdBegin);

    /// <summary>Gets the end color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed.</returns>
    [SRDescription("ProfessionalColorsMenuItemPressedGradientEndDescr")]
    public virtual Color MenuItemPressedGradientEnd => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuTitleBkgdEnd);

    /// <summary>Gets the middle color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed.</returns>
    [SRDescription("ProfessionalColorsMenuItemPressedGradientMiddleDescr")]
    public virtual Color MenuItemPressedGradientMiddle => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMenuIconBkgdDroppedMiddle);

    /// <summary>Gets the solid color to use when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> other than the top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> other than the top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</returns>
    [SRDescription("ProfessionalColorsMenuItemSelectedDescr")]
    public virtual Color MenuItemSelected => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBCtlBkgdMouseOver);

    /// <summary>Gets the starting color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</returns>
    [SRDescription("ProfessionalColorsMenuItemSelectedGradientBeginDescr")]
    public virtual Color MenuItemSelectedGradientBegin => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverBegin);

    /// <summary>Gets the end color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</returns>
    [SRDescription("ProfessionalColorsMenuItemSelectedGradientEndDescr")]
    public virtual Color MenuItemSelectedGradientEnd => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMouseOverEnd);

    /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</returns>
    [SRDescription("ProfessionalColorsMenuStripGradientBeginDescr")]
    public virtual Color MenuStripGradientBegin => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzBegin);

    /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</returns>
    [SRDescription("ProfessionalColorsMenuStripGradientEndDescr")]
    public virtual Color MenuStripGradientEnd => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzEnd);

    /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</returns>
    [SRDescription("ProfessionalColorsOverflowButtonGradientBeginDescr")]
    public virtual Color OverflowButtonGradientBegin => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsBegin);

    /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</returns>
    [SRDescription("ProfessionalColorsOverflowButtonGradientEndDescr")]
    public virtual Color OverflowButtonGradientEnd => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsEnd);

    /// <summary>Gets the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</returns>
    [SRDescription("ProfessionalColorsOverflowButtonGradientMiddleDescr")]
    public virtual Color OverflowButtonGradientMiddle => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradOptionsMiddle);

    /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</returns>
    [SRDescription("ProfessionalColorsRaftingContainerGradientBeginDescr")]
    public virtual Color RaftingContainerGradientBegin => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzBegin);

    /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</returns>
    [SRDescription("ProfessionalColorsRaftingContainerGradientEndDescr")]
    public virtual Color RaftingContainerGradientEnd => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzEnd);

    /// <summary>Gets the color to use to for shadow effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the color to use to for shadow effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</returns>
    [SRDescription("ProfessionalColorsSeparatorDarkDescr")]
    public virtual Color SeparatorDark => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBSplitterLine);

    /// <summary>Gets the color to use to for highlight effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the color to use to for highlight effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</returns>
    [SRDescription("ProfessionalColorsSeparatorLightDescr")]
    public virtual Color SeparatorLight => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBSplitterLineLight);

    /// <summary>Gets the starting color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</returns>
    [SRDescription("ProfessionalColorsStatusStripGradientBeginDescr")]
    public virtual Color StatusStripGradientBegin => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzBegin);

    /// <summary>Gets the end color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</returns>
    [SRDescription("ProfessionalColorsStatusStripGradientEndDescr")]
    public virtual Color StatusStripGradientEnd => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzEnd);

    internal Color TextBoxBorder => this.ButtonSelectedHighlightBorder;

    /// <summary>Gets the border color to use on the bottom edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the border color to use on the bottom edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
    [SRDescription("ProfessionalColorsToolStripBorderDescr")]
    public virtual Color ToolStripBorder => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBShadow);

    /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</returns>
    [SRDescription("ProfessionalColorsToolStripContentPanelGradientBeginDescr")]
    public virtual Color ToolStripContentPanelGradientBegin => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzBegin);

    /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</returns>
    [SRDescription("ProfessionalColorsToolStripContentPanelGradientEndDescr")]
    public virtual Color ToolStripContentPanelGradientEnd => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzEnd);

    /// <summary>Gets the solid background color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the solid background color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.</returns>
    [SRDescription("ProfessionalColorsToolStripDropDownBackgroundDescr")]
    public virtual Color ToolStripDropDownBackground => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBMenuBkgd);

    /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</returns>
    [SRDescription("ProfessionalColorsToolStripGradientBeginDescr")]
    public virtual Color ToolStripGradientBegin => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradVertBegin);

    /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</returns>
    [SRDescription("ProfessionalColorsToolStripGradientEndDescr")]
    public virtual Color ToolStripGradientEnd => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradVertEnd);

    /// <summary>Gets the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</returns>
    [SRDescription("ProfessionalColorsToolStripGradientMiddleDescr")]
    public virtual Color ToolStripGradientMiddle => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradVertMiddle);

    /// <summary>Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</returns>
    [SRDescription("ProfessionalColorsToolStripPanelGradientBeginDescr")]
    public virtual Color ToolStripPanelGradientBegin => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzBegin);

    /// <summary>Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
    /// <returns>A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</returns>
    [SRDescription("ProfessionalColorsToolStripPanelGradientEndDescr")]
    public virtual Color ToolStripPanelGradientEnd => this.FromKnownColor(ProfessionalColorTable.KnownColors.msocbvcrCBGradMainMenuHorzEnd);

    /// <summary>Gets or sets a value indicating whether to use <see cref="T:System.Drawing.SystemColors"></see> rather than colors that match the current visual style. </summary>
    /// <returns>true to use <see cref="T:System.Drawing.SystemColors"></see>; otherwise, false. The default is false.</returns>
    public bool UseSystemColors
    {
      get => this.mblnUseSystemColors;
      set
      {
        if (this.mblnUseSystemColors == value)
          return;
        this.mblnUseSystemColors = value;
        this.ResetRGBTable();
      }
    }

    internal enum KnownColors
    {
      msocbvcrCBBdrOuterDocked = 0,
      msocbvcrCBBdrOuterFloating = 1,
      msocbvcrCBBkgd = 2,
      msocbvcrCBCtlBdrMouseDown = 3,
      msocbvcrCBCtlBdrMouseOver = 4,
      msocbvcrCBCtlBdrSelected = 5,
      msocbvcrCBCtlBdrSelectedMouseOver = 6,
      msocbvcrCBCtlBkgd = 7,
      msocbvcrCBCtlBkgdLight = 8,
      msocbvcrCBCtlBkgdMouseDown = 9,
      msocbvcrCBCtlBkgdMouseOver = 10, // 0x0000000A
      msocbvcrCBCtlBkgdSelected = 11, // 0x0000000B
      msocbvcrCBCtlBkgdSelectedMouseOver = 12, // 0x0000000C
      msocbvcrCBCtlText = 13, // 0x0000000D
      msocbvcrCBCtlTextDisabled = 14, // 0x0000000E
      msocbvcrCBCtlTextLight = 15, // 0x0000000F
      msocbvcrCBCtlTextMouseDown = 16, // 0x00000010
      msocbvcrCBCtlTextMouseOver = 17, // 0x00000011
      msocbvcrCBDockSeparatorLine = 18, // 0x00000012
      msocbvcrCBDragHandle = 19, // 0x00000013
      msocbvcrCBDragHandleShadow = 20, // 0x00000014
      msocbvcrCBDropDownArrow = 21, // 0x00000015
      msocbvcrCBGradMainMenuHorzBegin = 22, // 0x00000016
      msocbvcrCBGradMainMenuHorzEnd = 23, // 0x00000017
      msocbvcrCBGradMenuIconBkgdDroppedBegin = 24, // 0x00000018
      msocbvcrCBGradMenuIconBkgdDroppedEnd = 25, // 0x00000019
      msocbvcrCBGradMenuIconBkgdDroppedMiddle = 26, // 0x0000001A
      msocbvcrCBGradMenuTitleBkgdBegin = 27, // 0x0000001B
      msocbvcrCBGradMenuTitleBkgdEnd = 28, // 0x0000001C
      msocbvcrCBGradMouseDownBegin = 29, // 0x0000001D
      msocbvcrCBGradMouseDownEnd = 30, // 0x0000001E
      msocbvcrCBGradMouseDownMiddle = 31, // 0x0000001F
      msocbvcrCBGradMouseOverBegin = 32, // 0x00000020
      msocbvcrCBGradMouseOverEnd = 33, // 0x00000021
      msocbvcrCBGradMouseOverMiddle = 34, // 0x00000022
      msocbvcrCBGradOptionsBegin = 35, // 0x00000023
      msocbvcrCBGradOptionsEnd = 36, // 0x00000024
      msocbvcrCBGradOptionsMiddle = 37, // 0x00000025
      msocbvcrCBGradOptionsMouseOverBegin = 38, // 0x00000026
      msocbvcrCBGradOptionsMouseOverEnd = 39, // 0x00000027
      msocbvcrCBGradOptionsMouseOverMiddle = 40, // 0x00000028
      msocbvcrCBGradOptionsSelectedBegin = 41, // 0x00000029
      msocbvcrCBGradOptionsSelectedEnd = 42, // 0x0000002A
      msocbvcrCBGradOptionsSelectedMiddle = 43, // 0x0000002B
      msocbvcrCBGradSelectedBegin = 44, // 0x0000002C
      msocbvcrCBGradSelectedEnd = 45, // 0x0000002D
      msocbvcrCBGradSelectedMiddle = 46, // 0x0000002E
      msocbvcrCBGradVertBegin = 47, // 0x0000002F
      msocbvcrCBGradVertEnd = 48, // 0x00000030
      msocbvcrCBGradVertMiddle = 49, // 0x00000031
      msocbvcrCBIconDisabledDark = 50, // 0x00000032
      msocbvcrCBIconDisabledLight = 51, // 0x00000033
      msocbvcrCBLabelBkgnd = 52, // 0x00000034
      msocbvcrCBLowColorIconDisabled = 53, // 0x00000035
      msocbvcrCBMainMenuBkgd = 54, // 0x00000036
      msocbvcrCBMenuBdrOuter = 55, // 0x00000037
      msocbvcrCBMenuBkgd = 56, // 0x00000038
      msocbvcrCBMenuCtlText = 57, // 0x00000039
      msocbvcrCBMenuCtlTextDisabled = 58, // 0x0000003A
      msocbvcrCBMenuIconBkgd = 59, // 0x0000003B
      msocbvcrCBMenuIconBkgdDropped = 60, // 0x0000003C
      msocbvcrCBMenuShadow = 61, // 0x0000003D
      msocbvcrCBMenuSplitArrow = 62, // 0x0000003E
      msocbvcrCBOptionsButtonShadow = 63, // 0x0000003F
      msocbvcrCBShadow = 64, // 0x00000040
      msocbvcrCBSplitterLine = 65, // 0x00000041
      msocbvcrCBSplitterLineLight = 66, // 0x00000042
      msocbvcrCBTearOffHandle = 67, // 0x00000043
      msocbvcrCBTearOffHandleMouseOver = 68, // 0x00000044
      msocbvcrCBTitleBkgd = 69, // 0x00000045
      msocbvcrCBTitleText = 70, // 0x00000046
      msocbvcrDisabledFocuslessHighlightedText = 71, // 0x00000047
      msocbvcrDisabledHighlightedText = 72, // 0x00000048
      msocbvcrDlgGroupBoxText = 73, // 0x00000049
      msocbvcrDocTabBdr = 74, // 0x0000004A
      msocbvcrDocTabBdrDark = 75, // 0x0000004B
      msocbvcrDocTabBdrDarkMouseDown = 76, // 0x0000004C
      msocbvcrDocTabBdrDarkMouseOver = 77, // 0x0000004D
      msocbvcrDocTabBdrLight = 78, // 0x0000004E
      msocbvcrDocTabBdrLightMouseDown = 79, // 0x0000004F
      msocbvcrDocTabBdrLightMouseOver = 80, // 0x00000050
      msocbvcrDocTabBdrMouseDown = 81, // 0x00000051
      msocbvcrDocTabBdrMouseOver = 82, // 0x00000052
      msocbvcrDocTabBdrSelected = 83, // 0x00000053
      msocbvcrDocTabBkgd = 84, // 0x00000054
      msocbvcrDocTabBkgdMouseDown = 85, // 0x00000055
      msocbvcrDocTabBkgdMouseOver = 86, // 0x00000056
      msocbvcrDocTabBkgdSelected = 87, // 0x00000057
      msocbvcrDocTabText = 88, // 0x00000058
      msocbvcrDocTabTextMouseDown = 89, // 0x00000059
      msocbvcrDocTabTextMouseOver = 90, // 0x0000005A
      msocbvcrDocTabTextSelected = 91, // 0x0000005B
      msocbvcrDWActiveTabBkgd = 92, // 0x0000005C
      msocbvcrDWActiveTabText = 93, // 0x0000005D
      msocbvcrDWActiveTabTextDisabled = 94, // 0x0000005E
      msocbvcrDWInactiveTabBkgd = 95, // 0x0000005F
      msocbvcrDWInactiveTabText = 96, // 0x00000060
      msocbvcrDWTabBkgdMouseDown = 97, // 0x00000061
      msocbvcrDWTabBkgdMouseOver = 98, // 0x00000062
      msocbvcrDWTabTextMouseDown = 99, // 0x00000063
      msocbvcrDWTabTextMouseOver = 100, // 0x00000064
      msocbvcrFocuslessHighlightedBkgd = 101, // 0x00000065
      msocbvcrFocuslessHighlightedText = 102, // 0x00000066
      msocbvcrGDHeaderBdr = 103, // 0x00000067
      msocbvcrGDHeaderBkgd = 104, // 0x00000068
      msocbvcrGDHeaderCellBdr = 105, // 0x00000069
      msocbvcrGDHeaderCellBkgd = 106, // 0x0000006A
      msocbvcrGDHeaderCellBkgdSelected = 107, // 0x0000006B
      msocbvcrGDHeaderSeeThroughSelection = 108, // 0x0000006C
      msocbvcrGSPDarkBkgd = 109, // 0x0000006D
      msocbvcrGSPGroupContentDarkBkgd = 110, // 0x0000006E
      msocbvcrGSPGroupContentLightBkgd = 111, // 0x0000006F
      msocbvcrGSPGroupContentText = 112, // 0x00000070
      msocbvcrGSPGroupContentTextDisabled = 113, // 0x00000071
      msocbvcrGSPGroupHeaderDarkBkgd = 114, // 0x00000072
      msocbvcrGSPGroupHeaderLightBkgd = 115, // 0x00000073
      msocbvcrGSPGroupHeaderText = 116, // 0x00000074
      msocbvcrGSPGroupline = 117, // 0x00000075
      msocbvcrGSPHyperlink = 118, // 0x00000076
      msocbvcrGSPLightBkgd = 119, // 0x00000077
      msocbvcrHyperlink = 120, // 0x00000078
      msocbvcrHyperlinkFollowed = 121, // 0x00000079
      msocbvcrJotNavUIBdr = 122, // 0x0000007A
      msocbvcrJotNavUIGradBegin = 123, // 0x0000007B
      msocbvcrJotNavUIGradEnd = 124, // 0x0000007C
      msocbvcrJotNavUIGradMiddle = 125, // 0x0000007D
      msocbvcrJotNavUIText = 126, // 0x0000007E
      msocbvcrListHeaderArrow = 127, // 0x0000007F
      msocbvcrNetLookBkgnd = 128, // 0x00000080
      msocbvcrOABBkgd = 129, // 0x00000081
      msocbvcrOBBkgdBdr = 130, // 0x00000082
      msocbvcrOBBkgdBdrContrast = 131, // 0x00000083
      msocbvcrOGMDIParentWorkspaceBkgd = 132, // 0x00000084
      msocbvcrOGRulerActiveBkgd = 133, // 0x00000085
      msocbvcrOGRulerBdr = 134, // 0x00000086
      msocbvcrOGRulerBkgd = 135, // 0x00000087
      msocbvcrOGRulerInactiveBkgd = 136, // 0x00000088
      msocbvcrOGRulerTabBoxBdr = 137, // 0x00000089
      msocbvcrOGRulerTabBoxBdrHighlight = 138, // 0x0000008A
      msocbvcrOGRulerTabStopTicks = 139, // 0x0000008B
      msocbvcrOGRulerText = 140, // 0x0000008C
      msocbvcrOGTaskPaneGroupBoxHeaderBkgd = 141, // 0x0000008D
      msocbvcrOGWorkspaceBkgd = 142, // 0x0000008E
      msocbvcrOLKFlagNone = 143, // 0x0000008F
      msocbvcrOLKFolderbarDark = 144, // 0x00000090
      msocbvcrOLKFolderbarLight = 145, // 0x00000091
      msocbvcrOLKFolderbarText = 146, // 0x00000092
      msocbvcrOLKGridlines = 147, // 0x00000093
      msocbvcrOLKGroupLine = 148, // 0x00000094
      msocbvcrOLKGroupNested = 149, // 0x00000095
      msocbvcrOLKGroupShaded = 150, // 0x00000096
      msocbvcrOLKGroupText = 151, // 0x00000097
      msocbvcrOLKIconBar = 152, // 0x00000098
      msocbvcrOLKInfoBarBkgd = 153, // 0x00000099
      msocbvcrOLKInfoBarText = 154, // 0x0000009A
      msocbvcrOLKPreviewPaneLabelText = 155, // 0x0000009B
      msocbvcrOLKTodayIndicatorDark = 156, // 0x0000009C
      msocbvcrOLKTodayIndicatorLight = 157, // 0x0000009D
      msocbvcrOLKWBActionDividerLine = 158, // 0x0000009E
      msocbvcrOLKWBButtonDark = 159, // 0x0000009F
      msocbvcrOLKWBButtonLight = 160, // 0x000000A0
      msocbvcrOLKWBDarkOutline = 161, // 0x000000A1
      msocbvcrOLKWBFoldersBackground = 162, // 0x000000A2
      msocbvcrOLKWBHoverButtonDark = 163, // 0x000000A3
      msocbvcrOLKWBHoverButtonLight = 164, // 0x000000A4
      msocbvcrOLKWBLabelText = 165, // 0x000000A5
      msocbvcrOLKWBPressedButtonDark = 166, // 0x000000A6
      msocbvcrOLKWBPressedButtonLight = 167, // 0x000000A7
      msocbvcrOLKWBSelectedButtonDark = 168, // 0x000000A8
      msocbvcrOLKWBSelectedButtonLight = 169, // 0x000000A9
      msocbvcrOLKWBSplitterDark = 170, // 0x000000AA
      msocbvcrOLKWBSplitterLight = 171, // 0x000000AB
      msocbvcrPlacesBarBkgd = 172, // 0x000000AC
      msocbvcrPPOutlineThumbnailsPaneTabAreaBkgd = 173, // 0x000000AD
      msocbvcrPPOutlineThumbnailsPaneTabBdr = 174, // 0x000000AE
      msocbvcrPPOutlineThumbnailsPaneTabInactiveBkgd = 175, // 0x000000AF
      msocbvcrPPOutlineThumbnailsPaneTabText = 176, // 0x000000B0
      msocbvcrPPSlideBdrActiveSelected = 177, // 0x000000B1
      msocbvcrPPSlideBdrActiveSelectedMouseOver = 178, // 0x000000B2
      msocbvcrPPSlideBdrInactiveSelected = 179, // 0x000000B3
      msocbvcrPPSlideBdrMouseOver = 180, // 0x000000B4
      msocbvcrPubPrintDocScratchPageBkgd = 181, // 0x000000B5
      msocbvcrPubWebDocScratchPageBkgd = 182, // 0x000000B6
      msocbvcrSBBdr = 183, // 0x000000B7
      msocbvcrScrollbarBkgd = 184, // 0x000000B8
      msocbvcrToastGradBegin = 185, // 0x000000B9
      msocbvcrToastGradEnd = 186, // 0x000000BA
      msocbvcrWPBdrInnerDocked = 187, // 0x000000BB
      msocbvcrWPBdrOuterDocked = 188, // 0x000000BC
      msocbvcrWPBdrOuterFloating = 189, // 0x000000BD
      msocbvcrWPBkgd = 190, // 0x000000BE
      msocbvcrWPCtlBdr = 191, // 0x000000BF
      msocbvcrWPCtlBdrDefault = 192, // 0x000000C0
      msocbvcrWPCtlBdrDisabled = 193, // 0x000000C1
      msocbvcrWPCtlBkgd = 194, // 0x000000C2
      msocbvcrWPCtlBkgdDisabled = 195, // 0x000000C3
      msocbvcrWPCtlText = 196, // 0x000000C4
      msocbvcrWPCtlTextDisabled = 197, // 0x000000C5
      msocbvcrWPCtlTextMouseDown = 198, // 0x000000C6
      msocbvcrWPGroupline = 199, // 0x000000C7
      msocbvcrWPInfoTipBkgd = 200, // 0x000000C8
      msocbvcrWPInfoTipText = 201, // 0x000000C9
      msocbvcrWPNavBarBkgnd = 202, // 0x000000CA
      msocbvcrWPText = 203, // 0x000000CB
      msocbvcrWPTextDisabled = 204, // 0x000000CC
      msocbvcrWPTitleBkgdActive = 205, // 0x000000CD
      msocbvcrWPTitleBkgdInactive = 206, // 0x000000CE
      msocbvcrWPTitleTextActive = 207, // 0x000000CF
      msocbvcrWPTitleTextInactive = 208, // 0x000000D0
      msocbvcrXLFormulaBarBkgd = 209, // 0x000000D1
      ButtonSelectedHighlight = 210, // 0x000000D2
      ButtonPressedHighlight = 211, // 0x000000D3
      ButtonCheckedHighlight = 212, // 0x000000D4
      lastKnownColor = 212, // 0x000000D4
    }
  }
}
