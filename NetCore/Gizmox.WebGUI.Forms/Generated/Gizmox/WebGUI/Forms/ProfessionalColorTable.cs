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
	/// Provides colors used for Microsoft Office display elements.</summary>
	[Serializable]
	public class ProfessionalColorTable
	{
		internal enum KnownColors
		{
			ButtonCheckedHighlight = 212,
			ButtonPressedHighlight = 211,
			ButtonSelectedHighlight = 210,
			lastKnownColor = 212,
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
			msocbvcrCBCtlBkgdMouseOver = 10,
			msocbvcrCBCtlBkgdSelected = 11,
			msocbvcrCBCtlBkgdSelectedMouseOver = 12,
			msocbvcrCBCtlText = 13,
			msocbvcrCBCtlTextDisabled = 14,
			msocbvcrCBCtlTextLight = 15,
			msocbvcrCBCtlTextMouseDown = 16,
			msocbvcrCBCtlTextMouseOver = 17,
			msocbvcrCBDockSeparatorLine = 18,
			msocbvcrCBDragHandle = 19,
			msocbvcrCBDragHandleShadow = 20,
			msocbvcrCBDropDownArrow = 21,
			msocbvcrCBGradMainMenuHorzBegin = 22,
			msocbvcrCBGradMainMenuHorzEnd = 23,
			msocbvcrCBGradMenuIconBkgdDroppedBegin = 24,
			msocbvcrCBGradMenuIconBkgdDroppedEnd = 25,
			msocbvcrCBGradMenuIconBkgdDroppedMiddle = 26,
			msocbvcrCBGradMenuTitleBkgdBegin = 27,
			msocbvcrCBGradMenuTitleBkgdEnd = 28,
			msocbvcrCBGradMouseDownBegin = 29,
			msocbvcrCBGradMouseDownEnd = 30,
			msocbvcrCBGradMouseDownMiddle = 31,
			msocbvcrCBGradMouseOverBegin = 32,
			msocbvcrCBGradMouseOverEnd = 33,
			msocbvcrCBGradMouseOverMiddle = 34,
			msocbvcrCBGradOptionsBegin = 35,
			msocbvcrCBGradOptionsEnd = 36,
			msocbvcrCBGradOptionsMiddle = 37,
			msocbvcrCBGradOptionsMouseOverBegin = 38,
			msocbvcrCBGradOptionsMouseOverEnd = 39,
			msocbvcrCBGradOptionsMouseOverMiddle = 40,
			msocbvcrCBGradOptionsSelectedBegin = 41,
			msocbvcrCBGradOptionsSelectedEnd = 42,
			msocbvcrCBGradOptionsSelectedMiddle = 43,
			msocbvcrCBGradSelectedBegin = 44,
			msocbvcrCBGradSelectedEnd = 45,
			msocbvcrCBGradSelectedMiddle = 46,
			msocbvcrCBGradVertBegin = 47,
			msocbvcrCBGradVertEnd = 48,
			msocbvcrCBGradVertMiddle = 49,
			msocbvcrCBIconDisabledDark = 50,
			msocbvcrCBIconDisabledLight = 51,
			msocbvcrCBLabelBkgnd = 52,
			msocbvcrCBLowColorIconDisabled = 53,
			msocbvcrCBMainMenuBkgd = 54,
			msocbvcrCBMenuBdrOuter = 55,
			msocbvcrCBMenuBkgd = 56,
			msocbvcrCBMenuCtlText = 57,
			msocbvcrCBMenuCtlTextDisabled = 58,
			msocbvcrCBMenuIconBkgd = 59,
			msocbvcrCBMenuIconBkgdDropped = 60,
			msocbvcrCBMenuShadow = 61,
			msocbvcrCBMenuSplitArrow = 62,
			msocbvcrCBOptionsButtonShadow = 63,
			msocbvcrCBShadow = 64,
			msocbvcrCBSplitterLine = 65,
			msocbvcrCBSplitterLineLight = 66,
			msocbvcrCBTearOffHandle = 67,
			msocbvcrCBTearOffHandleMouseOver = 68,
			msocbvcrCBTitleBkgd = 69,
			msocbvcrCBTitleText = 70,
			msocbvcrDisabledFocuslessHighlightedText = 71,
			msocbvcrDisabledHighlightedText = 72,
			msocbvcrDlgGroupBoxText = 73,
			msocbvcrDocTabBdr = 74,
			msocbvcrDocTabBdrDark = 75,
			msocbvcrDocTabBdrDarkMouseDown = 76,
			msocbvcrDocTabBdrDarkMouseOver = 77,
			msocbvcrDocTabBdrLight = 78,
			msocbvcrDocTabBdrLightMouseDown = 79,
			msocbvcrDocTabBdrLightMouseOver = 80,
			msocbvcrDocTabBdrMouseDown = 81,
			msocbvcrDocTabBdrMouseOver = 82,
			msocbvcrDocTabBdrSelected = 83,
			msocbvcrDocTabBkgd = 84,
			msocbvcrDocTabBkgdMouseDown = 85,
			msocbvcrDocTabBkgdMouseOver = 86,
			msocbvcrDocTabBkgdSelected = 87,
			msocbvcrDocTabText = 88,
			msocbvcrDocTabTextMouseDown = 89,
			msocbvcrDocTabTextMouseOver = 90,
			msocbvcrDocTabTextSelected = 91,
			msocbvcrDWActiveTabBkgd = 92,
			msocbvcrDWActiveTabText = 93,
			msocbvcrDWActiveTabTextDisabled = 94,
			msocbvcrDWInactiveTabBkgd = 95,
			msocbvcrDWInactiveTabText = 96,
			msocbvcrDWTabBkgdMouseDown = 97,
			msocbvcrDWTabBkgdMouseOver = 98,
			msocbvcrDWTabTextMouseDown = 99,
			msocbvcrDWTabTextMouseOver = 100,
			msocbvcrFocuslessHighlightedBkgd = 101,
			msocbvcrFocuslessHighlightedText = 102,
			msocbvcrGDHeaderBdr = 103,
			msocbvcrGDHeaderBkgd = 104,
			msocbvcrGDHeaderCellBdr = 105,
			msocbvcrGDHeaderCellBkgd = 106,
			msocbvcrGDHeaderCellBkgdSelected = 107,
			msocbvcrGDHeaderSeeThroughSelection = 108,
			msocbvcrGSPDarkBkgd = 109,
			msocbvcrGSPGroupContentDarkBkgd = 110,
			msocbvcrGSPGroupContentLightBkgd = 111,
			msocbvcrGSPGroupContentText = 112,
			msocbvcrGSPGroupContentTextDisabled = 113,
			msocbvcrGSPGroupHeaderDarkBkgd = 114,
			msocbvcrGSPGroupHeaderLightBkgd = 115,
			msocbvcrGSPGroupHeaderText = 116,
			msocbvcrGSPGroupline = 117,
			msocbvcrGSPHyperlink = 118,
			msocbvcrGSPLightBkgd = 119,
			msocbvcrHyperlink = 120,
			msocbvcrHyperlinkFollowed = 121,
			msocbvcrJotNavUIBdr = 122,
			msocbvcrJotNavUIGradBegin = 123,
			msocbvcrJotNavUIGradEnd = 124,
			msocbvcrJotNavUIGradMiddle = 125,
			msocbvcrJotNavUIText = 126,
			msocbvcrListHeaderArrow = 127,
			msocbvcrNetLookBkgnd = 128,
			msocbvcrOABBkgd = 129,
			msocbvcrOBBkgdBdr = 130,
			msocbvcrOBBkgdBdrContrast = 131,
			msocbvcrOGMDIParentWorkspaceBkgd = 132,
			msocbvcrOGRulerActiveBkgd = 133,
			msocbvcrOGRulerBdr = 134,
			msocbvcrOGRulerBkgd = 135,
			msocbvcrOGRulerInactiveBkgd = 136,
			msocbvcrOGRulerTabBoxBdr = 137,
			msocbvcrOGRulerTabBoxBdrHighlight = 138,
			msocbvcrOGRulerTabStopTicks = 139,
			msocbvcrOGRulerText = 140,
			msocbvcrOGTaskPaneGroupBoxHeaderBkgd = 141,
			msocbvcrOGWorkspaceBkgd = 142,
			msocbvcrOLKFlagNone = 143,
			msocbvcrOLKFolderbarDark = 144,
			msocbvcrOLKFolderbarLight = 145,
			msocbvcrOLKFolderbarText = 146,
			msocbvcrOLKGridlines = 147,
			msocbvcrOLKGroupLine = 148,
			msocbvcrOLKGroupNested = 149,
			msocbvcrOLKGroupShaded = 150,
			msocbvcrOLKGroupText = 151,
			msocbvcrOLKIconBar = 152,
			msocbvcrOLKInfoBarBkgd = 153,
			msocbvcrOLKInfoBarText = 154,
			msocbvcrOLKPreviewPaneLabelText = 155,
			msocbvcrOLKTodayIndicatorDark = 156,
			msocbvcrOLKTodayIndicatorLight = 157,
			msocbvcrOLKWBActionDividerLine = 158,
			msocbvcrOLKWBButtonDark = 159,
			msocbvcrOLKWBButtonLight = 160,
			msocbvcrOLKWBDarkOutline = 161,
			msocbvcrOLKWBFoldersBackground = 162,
			msocbvcrOLKWBHoverButtonDark = 163,
			msocbvcrOLKWBHoverButtonLight = 164,
			msocbvcrOLKWBLabelText = 165,
			msocbvcrOLKWBPressedButtonDark = 166,
			msocbvcrOLKWBPressedButtonLight = 167,
			msocbvcrOLKWBSelectedButtonDark = 168,
			msocbvcrOLKWBSelectedButtonLight = 169,
			msocbvcrOLKWBSplitterDark = 170,
			msocbvcrOLKWBSplitterLight = 171,
			msocbvcrPlacesBarBkgd = 172,
			msocbvcrPPOutlineThumbnailsPaneTabAreaBkgd = 173,
			msocbvcrPPOutlineThumbnailsPaneTabBdr = 174,
			msocbvcrPPOutlineThumbnailsPaneTabInactiveBkgd = 175,
			msocbvcrPPOutlineThumbnailsPaneTabText = 176,
			msocbvcrPPSlideBdrActiveSelected = 177,
			msocbvcrPPSlideBdrActiveSelectedMouseOver = 178,
			msocbvcrPPSlideBdrInactiveSelected = 179,
			msocbvcrPPSlideBdrMouseOver = 180,
			msocbvcrPubPrintDocScratchPageBkgd = 181,
			msocbvcrPubWebDocScratchPageBkgd = 182,
			msocbvcrSBBdr = 183,
			msocbvcrScrollbarBkgd = 184,
			msocbvcrToastGradBegin = 185,
			msocbvcrToastGradEnd = 186,
			msocbvcrWPBdrInnerDocked = 187,
			msocbvcrWPBdrOuterDocked = 188,
			msocbvcrWPBdrOuterFloating = 189,
			msocbvcrWPBkgd = 190,
			msocbvcrWPCtlBdr = 191,
			msocbvcrWPCtlBdrDefault = 192,
			msocbvcrWPCtlBdrDisabled = 193,
			msocbvcrWPCtlBkgd = 194,
			msocbvcrWPCtlBkgdDisabled = 195,
			msocbvcrWPCtlText = 196,
			msocbvcrWPCtlTextDisabled = 197,
			msocbvcrWPCtlTextMouseDown = 198,
			msocbvcrWPGroupline = 199,
			msocbvcrWPInfoTipBkgd = 200,
			msocbvcrWPInfoTipText = 201,
			msocbvcrWPNavBarBkgnd = 202,
			msocbvcrWPText = 203,
			msocbvcrWPTextDisabled = 204,
			msocbvcrWPTitleBkgdActive = 205,
			msocbvcrWPTitleBkgdInactive = 206,
			msocbvcrWPTitleTextActive = 207,
			msocbvcrWPTitleTextInactive = 208,
			msocbvcrXLFormulaBarBkgd = 209
		}

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

		/// Gets the starting color of the gradient used when the button is checked.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the button is checked.</returns>
		[SRDescription("ProfessionalColorsButtonCheckedGradientBeginDescr")]
		public virtual Color ButtonCheckedGradientBegin => FromKnownColor(KnownColors.msocbvcrCBGradSelectedBegin);

		/// Gets the end color of the gradient used when the button is checked.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the button is checked.</returns>
		[SRDescription("ProfessionalColorsButtonCheckedGradientEndDescr")]
		public virtual Color ButtonCheckedGradientEnd => FromKnownColor(KnownColors.msocbvcrCBGradSelectedEnd);

		/// Gets the middle color of the gradient used when the button is checked.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when the button is checked.</returns>
		[SRDescription("ProfessionalColorsButtonCheckedGradientMiddleDescr")]
		public virtual Color ButtonCheckedGradientMiddle => FromKnownColor(KnownColors.msocbvcrCBGradSelectedMiddle);

		/// Gets the solid color used when the button is checked.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid color used when the button is checked.</returns>
		[SRDescription("ProfessionalColorsButtonCheckedHighlightDescr")]
		public virtual Color ButtonCheckedHighlight => FromKnownColor(KnownColors.ButtonCheckedHighlight);

		/// Gets the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonCheckedHighlight"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonCheckedHighlight"></see>.</returns>
		[SRDescription("ProfessionalColorsButtonCheckedHighlightBorderDescr")]
		public virtual Color ButtonCheckedHighlightBorder => SystemColors.Highlight;

		/// Gets the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedGradientEnd"></see> colors.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedGradientEnd"></see> colors.</returns>
		[SRDescription("ProfessionalColorsButtonPressedBorderDescr")]
		public virtual Color ButtonPressedBorder => FromKnownColor(KnownColors.msocbvcrCBCtlBdrMouseOver);

		/// Gets the starting color of the gradient used when the button is pressed.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the button is pressed.</returns>
		[SRDescription("ProfessionalColorsButtonPressedGradientBeginDescr")]
		public virtual Color ButtonPressedGradientBegin => FromKnownColor(KnownColors.msocbvcrCBGradMouseDownBegin);

		/// Gets the end color of the gradient used when the button is pressed.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the button is pressed.</returns>
		[SRDescription("ProfessionalColorsButtonPressedGradientEndDescr")]
		public virtual Color ButtonPressedGradientEnd => FromKnownColor(KnownColors.msocbvcrCBGradMouseDownEnd);

		/// Gets the middle color of the gradient used when the button is pressed.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when the button is pressed.</returns>
		[SRDescription("ProfessionalColorsButtonPressedGradientMiddleDescr")]
		public virtual Color ButtonPressedGradientMiddle => FromKnownColor(KnownColors.msocbvcrCBGradMouseDownMiddle);

		/// Gets the solid color used when the button is pressed.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid color used when the button is pressed.</returns>
		[SRDescription("ProfessionalColorsButtonPressedHighlightDescr")]
		public virtual Color ButtonPressedHighlight => FromKnownColor(KnownColors.ButtonPressedHighlight);

		/// Gets the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedHighlight"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonPressedHighlight"></see>.</returns>
		[SRDescription("ProfessionalColorsButtonPressedHighlightBorderDescr")]
		public virtual Color ButtonPressedHighlightBorder => SystemColors.Highlight;

		/// Gets the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedGradientEnd"></see> colors.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedGradientEnd"></see> colors.</returns>
		[SRDescription("ProfessionalColorsButtonSelectedBorderDescr")]
		public virtual Color ButtonSelectedBorder => FromKnownColor(KnownColors.msocbvcrCBCtlBdrMouseOver);

		/// Gets the starting color of the gradient used when the button is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the button is selected.</returns>
		[SRDescription("ProfessionalColorsButtonSelectedGradientBeginDescr")]
		public virtual Color ButtonSelectedGradientBegin => FromKnownColor(KnownColors.msocbvcrCBGradMouseOverBegin);

		/// Gets the end color of the gradient used when the button is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the button is selected.</returns>
		[SRDescription("ProfessionalColorsButtonSelectedGradientEndDescr")]
		public virtual Color ButtonSelectedGradientEnd => FromKnownColor(KnownColors.msocbvcrCBGradMouseOverEnd);

		/// Gets the middle color of the gradient used when the button is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when the button is selected.</returns>
		[SRDescription("ProfessionalColorsButtonSelectedGradientMiddleDescr")]
		public virtual Color ButtonSelectedGradientMiddle => FromKnownColor(KnownColors.msocbvcrCBGradMouseOverMiddle);

		/// Gets the solid color used when the button is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid color used when the button is selected.</returns>
		[SRDescription("ProfessionalColorsButtonSelectedHighlightDescr")]
		public virtual Color ButtonSelectedHighlight => FromKnownColor(KnownColors.ButtonSelectedHighlight);

		/// Gets the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedHighlight"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColorTable.ButtonSelectedHighlight"></see>.</returns>
		[SRDescription("ProfessionalColorsButtonSelectedHighlightBorderDescr")]
		public virtual Color ButtonSelectedHighlightBorder => ButtonPressedBorder;

		/// Gets the solid color to use when the button is checked and gradients are being used.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when the button is checked and gradients are being used.</returns>
		[SRDescription("ProfessionalColorsCheckBackgroundDescr")]
		public virtual Color CheckBackground => FromKnownColor(KnownColors.msocbvcrCBCtlBkgdSelected);

		/// Gets the solid color to use when the button is checked and selected and gradients are being used.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when the button is checked and selected and gradients are being used.</returns>
		[SRDescription("ProfessionalColorsCheckPressedBackgroundDescr")]
		public virtual Color CheckPressedBackground => FromKnownColor(KnownColors.msocbvcrCBCtlBkgdSelectedMouseOver);

		/// Gets the solid color to use when the button is checked and selected and gradients are being used.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when the button is checked and selected and gradients are being used.</returns>
		[SRDescription("ProfessionalColorsCheckSelectedBackgroundDescr")]
		public virtual Color CheckSelectedBackground => FromKnownColor(KnownColors.msocbvcrCBCtlBkgdSelectedMouseOver);

		private Hashtable ColorTable
		{
			get
			{
				if (mobjProfessionalRGB == null)
				{
					mobjProfessionalRGB = new Hashtable(212);
					InitSystemColors(ref mobjProfessionalRGB);
				}
				return mobjProfessionalRGB;
			}
		}

		internal Color ComboBoxBorder => ButtonSelectedHighlightBorder;

		internal Color ComboBoxButtonGradientBegin => MenuItemPressedGradientBegin;

		internal Color ComboBoxButtonGradientEnd => MenuItemPressedGradientEnd;

		internal Color ComboBoxButtonOnOverflow => ToolStripDropDownBackground;

		internal Color ComboBoxButtonPressedGradientBegin => ButtonPressedGradientBegin;

		internal Color ComboBoxButtonPressedGradientEnd => ButtonPressedGradientEnd;

		internal Color ComboBoxButtonSelectedGradientBegin => MenuItemSelectedGradientBegin;

		internal Color ComboBoxButtonSelectedGradientEnd => MenuItemSelectedGradientEnd;

		/// Gets the color to use for shadow effects on the grip (move handle).</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the color to use for shadow effects on the grip (move handle).</returns>
		[SRDescription("ProfessionalColorsGripDarkDescr")]
		public virtual Color GripDark => FromKnownColor(KnownColors.msocbvcrCBDragHandle);

		/// Gets the color to use for highlight effects on the grip (move handle).</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the color to use for highlight effects on the grip (move handle).</returns>
		[SRDescription("ProfessionalColorsGripLightDescr")]
		public virtual Color GripLight => FromKnownColor(KnownColors.msocbvcrCBDragHandleShadow);

		/// Gets the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</returns>
		[SRDescription("ProfessionalColorsImageMarginGradientBeginDescr")]
		public virtual Color ImageMarginGradientBegin => FromKnownColor(KnownColors.msocbvcrCBGradVertBegin);

		/// Gets the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</returns>
		[SRDescription("ProfessionalColorsImageMarginGradientEndDescr")]
		public virtual Color ImageMarginGradientEnd
		{
			get
			{
				if (!mblnUsingSystemColors)
				{
					return FromKnownColor(KnownColors.msocbvcrCBGradVertEnd);
				}
				return SystemColors.Control;
			}
		}

		/// Gets the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</returns>
		[SRDescription("ProfessionalColorsImageMarginGradientMiddleDescr")]
		public virtual Color ImageMarginGradientMiddle => FromKnownColor(KnownColors.msocbvcrCBGradVertMiddle);

		/// Gets the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</returns>
		[SRDescription("ProfessionalColorsImageMarginRevealedGradientBeginDescr")]
		public virtual Color ImageMarginRevealedGradientBegin => FromKnownColor(KnownColors.msocbvcrCBGradMenuIconBkgdDroppedBegin);

		/// Gets the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</returns>
		[SRDescription("ProfessionalColorsImageMarginRevealedGradientEndDescr")]
		public virtual Color ImageMarginRevealedGradientEnd => FromKnownColor(KnownColors.msocbvcrCBGradMenuIconBkgdDroppedEnd);

		/// Gets the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</returns>
		[SRDescription("ProfessionalColorsImageMarginRevealedGradientMiddleDescr")]
		public virtual Color ImageMarginRevealedGradientMiddle => FromKnownColor(KnownColors.msocbvcrCBGradMenuIconBkgdDroppedMiddle);

		/// Gets the color that is the border color to use on a <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color to use on a <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</returns>
		[SRDescription("ProfessionalColorsMenuBorderDescr")]
		public virtual Color MenuBorder => FromKnownColor(KnownColors.msocbvcrCBMenuBdrOuter);

		/// Gets the border color to use with a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color to use with a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</returns>
		[SRDescription("ProfessionalColorsMenuItemBorderDescr")]
		public virtual Color MenuItemBorder => FromKnownColor(KnownColors.msocbvcrCBCtlBdrSelected);

		/// Gets the starting color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed.</returns>
		[SRDescription("ProfessionalColorsMenuItemPressedGradientBeginDescr")]
		public virtual Color MenuItemPressedGradientBegin => FromKnownColor(KnownColors.msocbvcrCBGradMenuTitleBkgdBegin);

		/// Gets the end color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed.</returns>
		[SRDescription("ProfessionalColorsMenuItemPressedGradientEndDescr")]
		public virtual Color MenuItemPressedGradientEnd => FromKnownColor(KnownColors.msocbvcrCBGradMenuTitleBkgdEnd);

		/// Gets the middle color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed.</returns>
		[SRDescription("ProfessionalColorsMenuItemPressedGradientMiddleDescr")]
		public virtual Color MenuItemPressedGradientMiddle => FromKnownColor(KnownColors.msocbvcrCBGradMenuIconBkgdDroppedMiddle);

		/// Gets the solid color to use when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> other than the top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> other than the top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</returns>
		[SRDescription("ProfessionalColorsMenuItemSelectedDescr")]
		public virtual Color MenuItemSelected => FromKnownColor(KnownColors.msocbvcrCBCtlBkgdMouseOver);

		/// Gets the starting color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</returns>
		[SRDescription("ProfessionalColorsMenuItemSelectedGradientBeginDescr")]
		public virtual Color MenuItemSelectedGradientBegin => FromKnownColor(KnownColors.msocbvcrCBGradMouseOverBegin);

		/// Gets the end color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</returns>
		[SRDescription("ProfessionalColorsMenuItemSelectedGradientEndDescr")]
		public virtual Color MenuItemSelectedGradientEnd => FromKnownColor(KnownColors.msocbvcrCBGradMouseOverEnd);

		/// Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</returns>
		[SRDescription("ProfessionalColorsMenuStripGradientBeginDescr")]
		public virtual Color MenuStripGradientBegin => FromKnownColor(KnownColors.msocbvcrCBGradMainMenuHorzBegin);

		/// Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</returns>
		[SRDescription("ProfessionalColorsMenuStripGradientEndDescr")]
		public virtual Color MenuStripGradientEnd => FromKnownColor(KnownColors.msocbvcrCBGradMainMenuHorzEnd);

		/// Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</returns>
		[SRDescription("ProfessionalColorsOverflowButtonGradientBeginDescr")]
		public virtual Color OverflowButtonGradientBegin => FromKnownColor(KnownColors.msocbvcrCBGradOptionsBegin);

		/// Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</returns>
		[SRDescription("ProfessionalColorsOverflowButtonGradientEndDescr")]
		public virtual Color OverflowButtonGradientEnd => FromKnownColor(KnownColors.msocbvcrCBGradOptionsEnd);

		/// Gets the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</returns>
		[SRDescription("ProfessionalColorsOverflowButtonGradientMiddleDescr")]
		public virtual Color OverflowButtonGradientMiddle => FromKnownColor(KnownColors.msocbvcrCBGradOptionsMiddle);

		/// Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</returns>
		[SRDescription("ProfessionalColorsRaftingContainerGradientBeginDescr")]
		public virtual Color RaftingContainerGradientBegin => FromKnownColor(KnownColors.msocbvcrCBGradMainMenuHorzBegin);

		/// Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</returns>
		[SRDescription("ProfessionalColorsRaftingContainerGradientEndDescr")]
		public virtual Color RaftingContainerGradientEnd => FromKnownColor(KnownColors.msocbvcrCBGradMainMenuHorzEnd);

		/// Gets the color to use to for shadow effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the color to use to for shadow effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</returns>
		[SRDescription("ProfessionalColorsSeparatorDarkDescr")]
		public virtual Color SeparatorDark => FromKnownColor(KnownColors.msocbvcrCBSplitterLine);

		/// Gets the color to use to for highlight effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the color to use to for highlight effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</returns>
		[SRDescription("ProfessionalColorsSeparatorLightDescr")]
		public virtual Color SeparatorLight => FromKnownColor(KnownColors.msocbvcrCBSplitterLineLight);

		/// Gets the starting color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</returns>
		[SRDescription("ProfessionalColorsStatusStripGradientBeginDescr")]
		public virtual Color StatusStripGradientBegin => FromKnownColor(KnownColors.msocbvcrCBGradMainMenuHorzBegin);

		/// Gets the end color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</returns>
		[SRDescription("ProfessionalColorsStatusStripGradientEndDescr")]
		public virtual Color StatusStripGradientEnd => FromKnownColor(KnownColors.msocbvcrCBGradMainMenuHorzEnd);

		internal Color TextBoxBorder => ButtonSelectedHighlightBorder;

		/// Gets the border color to use on the bottom edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color to use on the bottom edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
		[SRDescription("ProfessionalColorsToolStripBorderDescr")]
		public virtual Color ToolStripBorder => FromKnownColor(KnownColors.msocbvcrCBShadow);

		/// Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</returns>
		[SRDescription("ProfessionalColorsToolStripContentPanelGradientBeginDescr")]
		public virtual Color ToolStripContentPanelGradientBegin => FromKnownColor(KnownColors.msocbvcrCBGradMainMenuHorzBegin);

		/// Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</returns>
		[SRDescription("ProfessionalColorsToolStripContentPanelGradientEndDescr")]
		public virtual Color ToolStripContentPanelGradientEnd => FromKnownColor(KnownColors.msocbvcrCBGradMainMenuHorzEnd);

		/// Gets the solid background color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid background color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.</returns>
		[SRDescription("ProfessionalColorsToolStripDropDownBackgroundDescr")]
		public virtual Color ToolStripDropDownBackground => FromKnownColor(KnownColors.msocbvcrCBMenuBkgd);

		/// Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</returns>
		[SRDescription("ProfessionalColorsToolStripGradientBeginDescr")]
		public virtual Color ToolStripGradientBegin => FromKnownColor(KnownColors.msocbvcrCBGradVertBegin);

		/// Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</returns>
		[SRDescription("ProfessionalColorsToolStripGradientEndDescr")]
		public virtual Color ToolStripGradientEnd => FromKnownColor(KnownColors.msocbvcrCBGradVertEnd);

		/// Gets the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</returns>
		[SRDescription("ProfessionalColorsToolStripGradientMiddleDescr")]
		public virtual Color ToolStripGradientMiddle => FromKnownColor(KnownColors.msocbvcrCBGradVertMiddle);

		/// Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</returns>
		[SRDescription("ProfessionalColorsToolStripPanelGradientBeginDescr")]
		public virtual Color ToolStripPanelGradientBegin => FromKnownColor(KnownColors.msocbvcrCBGradMainMenuHorzBegin);

		/// Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</returns>
		[SRDescription("ProfessionalColorsToolStripPanelGradientEndDescr")]
		public virtual Color ToolStripPanelGradientEnd => FromKnownColor(KnownColors.msocbvcrCBGradMainMenuHorzEnd);

		/// Gets or sets a value indicating whether to use <see cref="T:System.Drawing.SystemColors"></see> rather than colors that match the current visual style. </summary>
		/// true to use <see cref="T:System.Drawing.SystemColors"></see>; otherwise, false. The default is false.</returns>
		public bool UseSystemColors
		{
			get
			{
				return mblnUseSystemColors;
			}
			set
			{
				if (mblnUseSystemColors != value)
				{
					mblnUseSystemColors = value;
					ResetRGBTable();
				}
			}
		}

		internal Color FromKnownColor(KnownColors color)
		{
			return (Color)ColorTable[color];
		}

		internal void InitBlueLunaColors(ref Hashtable rgbTable)
		{
			rgbTable[KnownColors.msocbvcrCBBdrOuterDocked] = Color.FromArgb(196, 205, 218);
			rgbTable[KnownColors.msocbvcrCBBdrOuterDocked] = Color.FromArgb(196, 205, 218);
			rgbTable[KnownColors.msocbvcrCBBdrOuterFloating] = Color.FromArgb(42, 102, 201);
			rgbTable[KnownColors.msocbvcrCBBkgd] = Color.FromArgb(196, 219, 249);
			rgbTable[KnownColors.msocbvcrCBCtlBdrMouseDown] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrCBCtlBdrMouseOver] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrCBCtlBdrSelected] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrCBCtlBdrSelectedMouseOver] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrCBCtlBkgd] = Color.FromArgb(196, 219, 249);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdLight] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdMouseDown] = Color.FromArgb(254, 128, 62);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdSelected] = Color.FromArgb(255, 192, 111);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdSelectedMouseOver] = Color.FromArgb(254, 128, 62);
			rgbTable[KnownColors.msocbvcrCBCtlText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBCtlTextDisabled] = Color.FromArgb(141, 141, 141);
			rgbTable[KnownColors.msocbvcrCBCtlTextLight] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrCBCtlTextMouseDown] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBCtlTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBCtlTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBCtlTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBDockSeparatorLine] = Color.FromArgb(0, 53, 145);
			rgbTable[KnownColors.msocbvcrCBDragHandle] = Color.FromArgb(39, 65, 118);
			rgbTable[KnownColors.msocbvcrCBDragHandleShadow] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrCBDropDownArrow] = Color.FromArgb(236, 233, 216);
			rgbTable[KnownColors.msocbvcrCBGradMainMenuHorzBegin] = Color.FromArgb(158, 190, 245);
			rgbTable[KnownColors.msocbvcrCBGradMainMenuHorzEnd] = Color.FromArgb(196, 218, 250);
			rgbTable[KnownColors.msocbvcrCBGradMenuIconBkgdDroppedBegin] = Color.FromArgb(203, 221, 246);
			rgbTable[KnownColors.msocbvcrCBGradMenuIconBkgdDroppedEnd] = Color.FromArgb(114, 155, 215);
			rgbTable[KnownColors.msocbvcrCBGradMenuIconBkgdDroppedMiddle] = Color.FromArgb(161, 197, 249);
			rgbTable[KnownColors.msocbvcrCBGradMenuTitleBkgdBegin] = Color.FromArgb(227, 239, 255);
			rgbTable[KnownColors.msocbvcrCBGradMenuTitleBkgdEnd] = Color.FromArgb(123, 164, 224);
			rgbTable[KnownColors.msocbvcrCBGradMouseDownBegin] = Color.FromArgb(254, 128, 62);
			rgbTable[KnownColors.msocbvcrCBGradMouseDownEnd] = Color.FromArgb(255, 223, 154);
			rgbTable[KnownColors.msocbvcrCBGradMouseDownMiddle] = Color.FromArgb(255, 177, 109);
			rgbTable[KnownColors.msocbvcrCBGradMouseOverBegin] = Color.FromArgb(255, 255, 222);
			rgbTable[KnownColors.msocbvcrCBGradMouseOverEnd] = Color.FromArgb(255, 203, 136);
			rgbTable[KnownColors.msocbvcrCBGradMouseOverMiddle] = Color.FromArgb(255, 225, 172);
			rgbTable[KnownColors.msocbvcrCBGradOptionsBegin] = Color.FromArgb(127, 177, 250);
			rgbTable[KnownColors.msocbvcrCBGradOptionsEnd] = Color.FromArgb(0, 53, 145);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMiddle] = Color.FromArgb(82, 127, 208);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMouseOverBegin] = Color.FromArgb(255, 255, 222);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMouseOverEnd] = Color.FromArgb(255, 193, 118);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMouseOverMiddle] = Color.FromArgb(255, 225, 172);
			rgbTable[KnownColors.msocbvcrCBGradOptionsSelectedBegin] = Color.FromArgb(254, 140, 73);
			rgbTable[KnownColors.msocbvcrCBGradOptionsSelectedEnd] = Color.FromArgb(255, 221, 152);
			rgbTable[KnownColors.msocbvcrCBGradOptionsSelectedMiddle] = Color.FromArgb(255, 184, 116);
			rgbTable[KnownColors.msocbvcrCBGradSelectedBegin] = Color.FromArgb(255, 223, 154);
			rgbTable[KnownColors.msocbvcrCBGradSelectedEnd] = Color.FromArgb(255, 166, 76);
			rgbTable[KnownColors.msocbvcrCBGradSelectedMiddle] = Color.FromArgb(255, 195, 116);
			rgbTable[KnownColors.msocbvcrCBGradVertBegin] = Color.FromArgb(227, 239, 255);
			rgbTable[KnownColors.msocbvcrCBGradVertEnd] = Color.FromArgb(123, 164, 224);
			rgbTable[KnownColors.msocbvcrCBGradVertMiddle] = Color.FromArgb(203, 225, 252);
			rgbTable[KnownColors.msocbvcrCBIconDisabledDark] = Color.FromArgb(97, 122, 172);
			rgbTable[KnownColors.msocbvcrCBIconDisabledLight] = Color.FromArgb(233, 236, 242);
			rgbTable[KnownColors.msocbvcrCBLabelBkgnd] = Color.FromArgb(186, 211, 245);
			rgbTable[KnownColors.msocbvcrCBLabelBkgnd] = Color.FromArgb(186, 211, 245);
			rgbTable[KnownColors.msocbvcrCBLowColorIconDisabled] = Color.FromArgb(109, 150, 208);
			rgbTable[KnownColors.msocbvcrCBMainMenuBkgd] = Color.FromArgb(153, 204, 255);
			rgbTable[KnownColors.msocbvcrCBMenuBdrOuter] = Color.FromArgb(0, 45, 150);
			rgbTable[KnownColors.msocbvcrCBMenuBkgd] = Color.FromArgb(246, 246, 246);
			rgbTable[KnownColors.msocbvcrCBMenuCtlText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBMenuCtlTextDisabled] = Color.FromArgb(141, 141, 141);
			rgbTable[KnownColors.msocbvcrCBMenuIconBkgd] = Color.FromArgb(203, 225, 252);
			rgbTable[KnownColors.msocbvcrCBMenuIconBkgdDropped] = Color.FromArgb(172, 183, 201);
			rgbTable[KnownColors.msocbvcrCBMenuIconBkgdDropped] = Color.FromArgb(172, 183, 201);
			rgbTable[KnownColors.msocbvcrCBMenuShadow] = Color.FromArgb(95, 130, 234);
			rgbTable[KnownColors.msocbvcrCBMenuSplitArrow] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrCBOptionsButtonShadow] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrCBShadow] = Color.FromArgb(59, 97, 156);
			rgbTable[KnownColors.msocbvcrCBSplitterLine] = Color.FromArgb(106, 140, 203);
			rgbTable[KnownColors.msocbvcrCBSplitterLineLight] = Color.FromArgb(241, 249, 255);
			rgbTable[KnownColors.msocbvcrCBTearOffHandle] = Color.FromArgb(169, 199, 240);
			rgbTable[KnownColors.msocbvcrCBTearOffHandleMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrCBTitleBkgd] = Color.FromArgb(42, 102, 201);
			rgbTable[KnownColors.msocbvcrCBTitleText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDisabledFocuslessHighlightedText] = Color.FromArgb(172, 168, 153);
			rgbTable[KnownColors.msocbvcrDisabledHighlightedText] = Color.FromArgb(187, 206, 236);
			rgbTable[KnownColors.msocbvcrDlgGroupBoxText] = Color.FromArgb(0, 70, 213);
			rgbTable[KnownColors.msocbvcrDocTabBdr] = Color.FromArgb(0, 53, 154);
			rgbTable[KnownColors.msocbvcrDocTabBdrDark] = Color.FromArgb(117, 166, 241);
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseDown] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseOver] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseOver] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseOver] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrDocTabBdrLight] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseDown] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseOver] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseOver] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseOver] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseDown] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseOver] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseOver] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseOver] = Color.FromArgb(0, 0, 128);
			rgbTable[KnownColors.msocbvcrDocTabBdrSelected] = Color.FromArgb(59, 97, 156);
			rgbTable[KnownColors.msocbvcrDocTabBkgd] = Color.FromArgb(186, 211, 245);
			rgbTable[KnownColors.msocbvcrDocTabBkgdMouseDown] = Color.FromArgb(254, 128, 62);
			rgbTable[KnownColors.msocbvcrDocTabBkgdMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrDocTabBkgdMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrDocTabBkgdSelected] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDocTabText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabTextMouseDown] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabTextSelected] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDWActiveTabBkgd] = Color.FromArgb(186, 211, 245);
			rgbTable[KnownColors.msocbvcrDWActiveTabBkgd] = Color.FromArgb(186, 211, 245);
			rgbTable[KnownColors.msocbvcrDWActiveTabText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDWActiveTabText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDWActiveTabTextDisabled] = Color.FromArgb(94, 94, 94);
			rgbTable[KnownColors.msocbvcrDWActiveTabTextDisabled] = Color.FromArgb(94, 94, 94);
			rgbTable[KnownColors.msocbvcrDWInactiveTabBkgd] = Color.FromArgb(129, 169, 226);
			rgbTable[KnownColors.msocbvcrDWInactiveTabBkgd] = Color.FromArgb(129, 169, 226);
			rgbTable[KnownColors.msocbvcrDWInactiveTabText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDWInactiveTabText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDWTabBkgdMouseDown] = Color.FromArgb(254, 128, 62);
			rgbTable[KnownColors.msocbvcrDWTabBkgdMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrDWTabTextMouseDown] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDWTabTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedBkgd] = Color.FromArgb(236, 233, 216);
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedBkgd] = Color.FromArgb(236, 233, 216);
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrGDHeaderBdr] = Color.FromArgb(89, 89, 172);
			rgbTable[KnownColors.msocbvcrGDHeaderBkgd] = Color.FromArgb(239, 235, 222);
			rgbTable[KnownColors.msocbvcrGDHeaderCellBdr] = Color.FromArgb(126, 125, 104);
			rgbTable[KnownColors.msocbvcrGDHeaderCellBkgd] = Color.FromArgb(239, 235, 222);
			rgbTable[KnownColors.msocbvcrGDHeaderCellBkgdSelected] = Color.FromArgb(255, 192, 111);
			rgbTable[KnownColors.msocbvcrGDHeaderSeeThroughSelection] = Color.FromArgb(191, 191, 223);
			rgbTable[KnownColors.msocbvcrGSPDarkBkgd] = Color.FromArgb(74, 122, 201);
			rgbTable[KnownColors.msocbvcrGSPDarkBkgd] = Color.FromArgb(74, 122, 201);
			rgbTable[KnownColors.msocbvcrGSPGroupContentDarkBkgd] = Color.FromArgb(185, 208, 241);
			rgbTable[KnownColors.msocbvcrGSPGroupContentLightBkgd] = Color.FromArgb(221, 236, 254);
			rgbTable[KnownColors.msocbvcrGSPGroupContentText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrGSPGroupContentTextDisabled] = Color.FromArgb(150, 145, 133);
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderDarkBkgd] = Color.FromArgb(101, 143, 224);
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderLightBkgd] = Color.FromArgb(196, 219, 249);
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderText] = Color.FromArgb(0, 45, 134);
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderText] = Color.FromArgb(0, 45, 134);
			rgbTable[KnownColors.msocbvcrGSPGroupline] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrGSPGroupline] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrGSPHyperlink] = Color.FromArgb(0, 61, 178);
			rgbTable[KnownColors.msocbvcrGSPLightBkgd] = Color.FromArgb(221, 236, 254);
			rgbTable[KnownColors.msocbvcrHyperlink] = Color.FromArgb(0, 61, 178);
			rgbTable[KnownColors.msocbvcrHyperlinkFollowed] = Color.FromArgb(170, 0, 170);
			rgbTable[KnownColors.msocbvcrJotNavUIBdr] = Color.FromArgb(59, 97, 156);
			rgbTable[KnownColors.msocbvcrJotNavUIBdr] = Color.FromArgb(59, 97, 156);
			rgbTable[KnownColors.msocbvcrJotNavUIGradBegin] = Color.FromArgb(158, 190, 245);
			rgbTable[KnownColors.msocbvcrJotNavUIGradBegin] = Color.FromArgb(158, 190, 245);
			rgbTable[KnownColors.msocbvcrJotNavUIGradEnd] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrJotNavUIGradMiddle] = Color.FromArgb(196, 218, 250);
			rgbTable[KnownColors.msocbvcrJotNavUIGradMiddle] = Color.FromArgb(196, 218, 250);
			rgbTable[KnownColors.msocbvcrJotNavUIText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrListHeaderArrow] = Color.FromArgb(172, 168, 153);
			rgbTable[KnownColors.msocbvcrNetLookBkgnd] = Color.FromArgb(227, 239, 255);
			rgbTable[KnownColors.msocbvcrOABBkgd] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrOBBkgdBdr] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrOBBkgdBdrContrast] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOGMDIParentWorkspaceBkgd] = Color.FromArgb(144, 153, 174);
			rgbTable[KnownColors.msocbvcrOGRulerActiveBkgd] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOGRulerBdr] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrOGRulerBkgd] = Color.FromArgb(216, 231, 252);
			rgbTable[KnownColors.msocbvcrOGRulerInactiveBkgd] = Color.FromArgb(158, 190, 245);
			rgbTable[KnownColors.msocbvcrOGRulerTabBoxBdr] = Color.FromArgb(75, 120, 202);
			rgbTable[KnownColors.msocbvcrOGRulerTabBoxBdrHighlight] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOGRulerTabStopTicks] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrOGRulerText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrOGTaskPaneGroupBoxHeaderBkgd] = Color.FromArgb(186, 211, 245);
			rgbTable[KnownColors.msocbvcrOGWorkspaceBkgd] = Color.FromArgb(144, 153, 174);
			rgbTable[KnownColors.msocbvcrOLKFlagNone] = Color.FromArgb(242, 240, 228);
			rgbTable[KnownColors.msocbvcrOLKFolderbarDark] = Color.FromArgb(0, 53, 145);
			rgbTable[KnownColors.msocbvcrOLKFolderbarLight] = Color.FromArgb(89, 135, 214);
			rgbTable[KnownColors.msocbvcrOLKFolderbarText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOLKGridlines] = Color.FromArgb(234, 233, 225);
			rgbTable[KnownColors.msocbvcrOLKGroupLine] = Color.FromArgb(123, 164, 224);
			rgbTable[KnownColors.msocbvcrOLKGroupNested] = Color.FromArgb(253, 238, 201);
			rgbTable[KnownColors.msocbvcrOLKGroupShaded] = Color.FromArgb(190, 218, 251);
			rgbTable[KnownColors.msocbvcrOLKGroupText] = Color.FromArgb(55, 104, 185);
			rgbTable[KnownColors.msocbvcrOLKIconBar] = Color.FromArgb(253, 247, 233);
			rgbTable[KnownColors.msocbvcrOLKInfoBarBkgd] = Color.FromArgb(144, 153, 174);
			rgbTable[KnownColors.msocbvcrOLKInfoBarText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOLKPreviewPaneLabelText] = Color.FromArgb(144, 153, 174);
			rgbTable[KnownColors.msocbvcrOLKTodayIndicatorDark] = Color.FromArgb(187, 85, 3);
			rgbTable[KnownColors.msocbvcrOLKTodayIndicatorLight] = Color.FromArgb(251, 200, 79);
			rgbTable[KnownColors.msocbvcrOLKWBActionDividerLine] = Color.FromArgb(215, 228, 251);
			rgbTable[KnownColors.msocbvcrOLKWBButtonDark] = Color.FromArgb(123, 164, 224);
			rgbTable[KnownColors.msocbvcrOLKWBButtonLight] = Color.FromArgb(203, 225, 252);
			rgbTable[KnownColors.msocbvcrOLKWBButtonLight] = Color.FromArgb(203, 225, 252);
			rgbTable[KnownColors.msocbvcrOLKWBDarkOutline] = Color.FromArgb(0, 45, 150);
			rgbTable[KnownColors.msocbvcrOLKWBFoldersBackground] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOLKWBHoverButtonDark] = Color.FromArgb(247, 190, 87);
			rgbTable[KnownColors.msocbvcrOLKWBHoverButtonLight] = Color.FromArgb(255, 255, 220);
			rgbTable[KnownColors.msocbvcrOLKWBLabelText] = Color.FromArgb(50, 69, 105);
			rgbTable[KnownColors.msocbvcrOLKWBPressedButtonDark] = Color.FromArgb(248, 222, 128);
			rgbTable[KnownColors.msocbvcrOLKWBPressedButtonLight] = Color.FromArgb(232, 127, 8);
			rgbTable[KnownColors.msocbvcrOLKWBSelectedButtonDark] = Color.FromArgb(238, 147, 17);
			rgbTable[KnownColors.msocbvcrOLKWBSelectedButtonLight] = Color.FromArgb(251, 230, 148);
			rgbTable[KnownColors.msocbvcrOLKWBSplitterDark] = Color.FromArgb(0, 53, 145);
			rgbTable[KnownColors.msocbvcrOLKWBSplitterLight] = Color.FromArgb(89, 135, 214);
			rgbTable[KnownColors.msocbvcrOLKWBSplitterLight] = Color.FromArgb(89, 135, 214);
			rgbTable[KnownColors.msocbvcrPlacesBarBkgd] = Color.FromArgb(236, 233, 216);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabAreaBkgd] = Color.FromArgb(195, 218, 249);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabBdr] = Color.FromArgb(59, 97, 156);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabInactiveBkgd] = Color.FromArgb(158, 190, 245);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrPPSlideBdrActiveSelected] = Color.FromArgb(61, 108, 192);
			rgbTable[KnownColors.msocbvcrPPSlideBdrActiveSelectedMouseOver] = Color.FromArgb(61, 108, 192);
			rgbTable[KnownColors.msocbvcrPPSlideBdrInactiveSelected] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrPPSlideBdrMouseOver] = Color.FromArgb(61, 108, 192);
			rgbTable[KnownColors.msocbvcrPubPrintDocScratchPageBkgd] = Color.FromArgb(144, 153, 174);
			rgbTable[KnownColors.msocbvcrPubWebDocScratchPageBkgd] = Color.FromArgb(189, 194, 207);
			rgbTable[KnownColors.msocbvcrSBBdr] = Color.FromArgb(211, 211, 211);
			rgbTable[KnownColors.msocbvcrScrollbarBkgd] = Color.FromArgb(251, 251, 248);
			rgbTable[KnownColors.msocbvcrToastGradBegin] = Color.FromArgb(220, 236, 254);
			rgbTable[KnownColors.msocbvcrToastGradEnd] = Color.FromArgb(167, 197, 238);
			rgbTable[KnownColors.msocbvcrWPBdrInnerDocked] = Color.FromArgb(185, 212, 249);
			rgbTable[KnownColors.msocbvcrWPBdrOuterDocked] = Color.FromArgb(196, 218, 250);
			rgbTable[KnownColors.msocbvcrWPBdrOuterFloating] = Color.FromArgb(42, 102, 201);
			rgbTable[KnownColors.msocbvcrWPBkgd] = Color.FromArgb(221, 236, 254);
			rgbTable[KnownColors.msocbvcrWPCtlBdr] = Color.FromArgb(127, 157, 185);
			rgbTable[KnownColors.msocbvcrWPCtlBdrDefault] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPCtlBdrDefault] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPCtlBdrDisabled] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrWPCtlBkgd] = Color.FromArgb(169, 199, 240);
			rgbTable[KnownColors.msocbvcrWPCtlBkgdDisabled] = Color.FromArgb(222, 222, 222);
			rgbTable[KnownColors.msocbvcrWPCtlText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPCtlTextDisabled] = Color.FromArgb(172, 168, 153);
			rgbTable[KnownColors.msocbvcrWPCtlTextMouseDown] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPGroupline] = Color.FromArgb(123, 164, 224);
			rgbTable[KnownColors.msocbvcrWPInfoTipBkgd] = Color.FromArgb(255, 255, 204);
			rgbTable[KnownColors.msocbvcrWPInfoTipText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPNavBarBkgnd] = Color.FromArgb(74, 122, 201);
			rgbTable[KnownColors.msocbvcrWPText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPTextDisabled] = Color.FromArgb(172, 168, 153);
			rgbTable[KnownColors.msocbvcrWPTitleBkgdActive] = Color.FromArgb(123, 164, 224);
			rgbTable[KnownColors.msocbvcrWPTitleBkgdInactive] = Color.FromArgb(148, 187, 239);
			rgbTable[KnownColors.msocbvcrWPTitleTextActive] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPTitleTextInactive] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrXLFormulaBarBkgd] = Color.FromArgb(158, 190, 245);
		}

		private void InitCommonColors(ref Hashtable rgbTable)
		{
			rgbTable[KnownColors.ButtonPressedHighlight] = SystemColors.Highlight;
			rgbTable[KnownColors.ButtonCheckedHighlight] = SystemColors.ControlLight;
			rgbTable[KnownColors.ButtonSelectedHighlight] = SystemColors.ControlLight;
		}

		internal void InitOliveLunaColors(ref Hashtable rgbTable)
		{
			rgbTable[KnownColors.msocbvcrCBBdrOuterDocked] = Color.FromArgb(81, 94, 51);
			rgbTable[KnownColors.msocbvcrCBBdrOuterDocked] = Color.FromArgb(81, 94, 51);
			rgbTable[KnownColors.msocbvcrCBBdrOuterFloating] = Color.FromArgb(116, 134, 94);
			rgbTable[KnownColors.msocbvcrCBBkgd] = Color.FromArgb(209, 222, 173);
			rgbTable[KnownColors.msocbvcrCBCtlBdrMouseDown] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrCBCtlBdrMouseOver] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrCBCtlBdrSelected] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrCBCtlBdrSelectedMouseOver] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrCBCtlBkgd] = Color.FromArgb(209, 222, 173);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdLight] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdMouseDown] = Color.FromArgb(254, 128, 62);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdSelected] = Color.FromArgb(255, 192, 111);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdSelectedMouseOver] = Color.FromArgb(254, 128, 62);
			rgbTable[KnownColors.msocbvcrCBCtlText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBCtlTextDisabled] = Color.FromArgb(141, 141, 141);
			rgbTable[KnownColors.msocbvcrCBCtlTextLight] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrCBCtlTextMouseDown] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBCtlTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBCtlTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBCtlTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBDockSeparatorLine] = Color.FromArgb(96, 119, 66);
			rgbTable[KnownColors.msocbvcrCBDragHandle] = Color.FromArgb(81, 94, 51);
			rgbTable[KnownColors.msocbvcrCBDragHandleShadow] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrCBDropDownArrow] = Color.FromArgb(236, 233, 216);
			rgbTable[KnownColors.msocbvcrCBGradMainMenuHorzBegin] = Color.FromArgb(217, 217, 167);
			rgbTable[KnownColors.msocbvcrCBGradMainMenuHorzEnd] = Color.FromArgb(242, 241, 228);
			rgbTable[KnownColors.msocbvcrCBGradMenuIconBkgdDroppedBegin] = Color.FromArgb(230, 230, 209);
			rgbTable[KnownColors.msocbvcrCBGradMenuIconBkgdDroppedEnd] = Color.FromArgb(160, 177, 116);
			rgbTable[KnownColors.msocbvcrCBGradMenuIconBkgdDroppedMiddle] = Color.FromArgb(186, 201, 143);
			rgbTable[KnownColors.msocbvcrCBGradMenuTitleBkgdBegin] = Color.FromArgb(237, 240, 214);
			rgbTable[KnownColors.msocbvcrCBGradMenuTitleBkgdEnd] = Color.FromArgb(181, 196, 143);
			rgbTable[KnownColors.msocbvcrCBGradMouseDownBegin] = Color.FromArgb(254, 128, 62);
			rgbTable[KnownColors.msocbvcrCBGradMouseDownEnd] = Color.FromArgb(255, 223, 154);
			rgbTable[KnownColors.msocbvcrCBGradMouseDownMiddle] = Color.FromArgb(255, 177, 109);
			rgbTable[KnownColors.msocbvcrCBGradMouseOverBegin] = Color.FromArgb(255, 255, 222);
			rgbTable[KnownColors.msocbvcrCBGradMouseOverEnd] = Color.FromArgb(255, 203, 136);
			rgbTable[KnownColors.msocbvcrCBGradMouseOverMiddle] = Color.FromArgb(255, 225, 172);
			rgbTable[KnownColors.msocbvcrCBGradOptionsBegin] = Color.FromArgb(186, 204, 150);
			rgbTable[KnownColors.msocbvcrCBGradOptionsEnd] = Color.FromArgb(96, 119, 107);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMiddle] = Color.FromArgb(141, 160, 107);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMouseOverBegin] = Color.FromArgb(255, 255, 222);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMouseOverEnd] = Color.FromArgb(255, 193, 118);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMouseOverMiddle] = Color.FromArgb(255, 225, 172);
			rgbTable[KnownColors.msocbvcrCBGradOptionsSelectedBegin] = Color.FromArgb(254, 140, 73);
			rgbTable[KnownColors.msocbvcrCBGradOptionsSelectedEnd] = Color.FromArgb(255, 221, 152);
			rgbTable[KnownColors.msocbvcrCBGradOptionsSelectedMiddle] = Color.FromArgb(255, 184, 116);
			rgbTable[KnownColors.msocbvcrCBGradSelectedBegin] = Color.FromArgb(255, 223, 154);
			rgbTable[KnownColors.msocbvcrCBGradSelectedEnd] = Color.FromArgb(255, 166, 76);
			rgbTable[KnownColors.msocbvcrCBGradSelectedMiddle] = Color.FromArgb(255, 195, 116);
			rgbTable[KnownColors.msocbvcrCBGradVertBegin] = Color.FromArgb(255, 255, 237);
			rgbTable[KnownColors.msocbvcrCBGradVertEnd] = Color.FromArgb(181, 196, 143);
			rgbTable[KnownColors.msocbvcrCBGradVertMiddle] = Color.FromArgb(206, 220, 167);
			rgbTable[KnownColors.msocbvcrCBIconDisabledDark] = Color.FromArgb(131, 144, 113);
			rgbTable[KnownColors.msocbvcrCBIconDisabledLight] = Color.FromArgb(243, 244, 240);
			rgbTable[KnownColors.msocbvcrCBLabelBkgnd] = Color.FromArgb(218, 227, 187);
			rgbTable[KnownColors.msocbvcrCBLabelBkgnd] = Color.FromArgb(218, 227, 187);
			rgbTable[KnownColors.msocbvcrCBLowColorIconDisabled] = Color.FromArgb(159, 174, 122);
			rgbTable[KnownColors.msocbvcrCBMainMenuBkgd] = Color.FromArgb(236, 233, 216);
			rgbTable[KnownColors.msocbvcrCBMenuBdrOuter] = Color.FromArgb(117, 141, 94);
			rgbTable[KnownColors.msocbvcrCBMenuBkgd] = Color.FromArgb(244, 244, 238);
			rgbTable[KnownColors.msocbvcrCBMenuCtlText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBMenuCtlTextDisabled] = Color.FromArgb(141, 141, 141);
			rgbTable[KnownColors.msocbvcrCBMenuIconBkgd] = Color.FromArgb(216, 227, 182);
			rgbTable[KnownColors.msocbvcrCBMenuIconBkgdDropped] = Color.FromArgb(173, 181, 157);
			rgbTable[KnownColors.msocbvcrCBMenuIconBkgdDropped] = Color.FromArgb(173, 181, 157);
			rgbTable[KnownColors.msocbvcrCBMenuShadow] = Color.FromArgb(134, 148, 108);
			rgbTable[KnownColors.msocbvcrCBMenuSplitArrow] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBOptionsButtonShadow] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrCBShadow] = Color.FromArgb(96, 128, 88);
			rgbTable[KnownColors.msocbvcrCBSplitterLine] = Color.FromArgb(96, 128, 88);
			rgbTable[KnownColors.msocbvcrCBSplitterLineLight] = Color.FromArgb(244, 247, 222);
			rgbTable[KnownColors.msocbvcrCBTearOffHandle] = Color.FromArgb(197, 212, 159);
			rgbTable[KnownColors.msocbvcrCBTearOffHandleMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrCBTitleBkgd] = Color.FromArgb(116, 134, 94);
			rgbTable[KnownColors.msocbvcrCBTitleText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDisabledFocuslessHighlightedText] = Color.FromArgb(172, 168, 153);
			rgbTable[KnownColors.msocbvcrDisabledHighlightedText] = Color.FromArgb(220, 224, 208);
			rgbTable[KnownColors.msocbvcrDlgGroupBoxText] = Color.FromArgb(153, 84, 10);
			rgbTable[KnownColors.msocbvcrDocTabBdr] = Color.FromArgb(96, 119, 107);
			rgbTable[KnownColors.msocbvcrDocTabBdrDark] = Color.FromArgb(176, 194, 140);
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseDown] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseOver] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseOver] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseOver] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrDocTabBdrLight] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseDown] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseOver] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseOver] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseOver] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseDown] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseOver] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseOver] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseOver] = Color.FromArgb(63, 93, 56);
			rgbTable[KnownColors.msocbvcrDocTabBdrSelected] = Color.FromArgb(96, 128, 88);
			rgbTable[KnownColors.msocbvcrDocTabBkgd] = Color.FromArgb(218, 227, 187);
			rgbTable[KnownColors.msocbvcrDocTabBkgdMouseDown] = Color.FromArgb(254, 128, 62);
			rgbTable[KnownColors.msocbvcrDocTabBkgdMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrDocTabBkgdMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrDocTabBkgdSelected] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDocTabText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabTextMouseDown] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabTextSelected] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDWActiveTabBkgd] = Color.FromArgb(218, 227, 187);
			rgbTable[KnownColors.msocbvcrDWActiveTabBkgd] = Color.FromArgb(218, 227, 187);
			rgbTable[KnownColors.msocbvcrDWActiveTabText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDWActiveTabText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDWActiveTabTextDisabled] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrDWActiveTabTextDisabled] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrDWInactiveTabBkgd] = Color.FromArgb(183, 198, 145);
			rgbTable[KnownColors.msocbvcrDWInactiveTabBkgd] = Color.FromArgb(183, 198, 145);
			rgbTable[KnownColors.msocbvcrDWInactiveTabText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDWInactiveTabText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDWTabBkgdMouseDown] = Color.FromArgb(254, 128, 62);
			rgbTable[KnownColors.msocbvcrDWTabBkgdMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrDWTabTextMouseDown] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDWTabTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedBkgd] = Color.FromArgb(236, 233, 216);
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedBkgd] = Color.FromArgb(236, 233, 216);
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrGDHeaderBdr] = Color.FromArgb(191, 191, 223);
			rgbTable[KnownColors.msocbvcrGDHeaderBkgd] = Color.FromArgb(239, 235, 222);
			rgbTable[KnownColors.msocbvcrGDHeaderCellBdr] = Color.FromArgb(126, 125, 104);
			rgbTable[KnownColors.msocbvcrGDHeaderCellBkgd] = Color.FromArgb(239, 235, 222);
			rgbTable[KnownColors.msocbvcrGDHeaderCellBkgdSelected] = Color.FromArgb(255, 192, 111);
			rgbTable[KnownColors.msocbvcrGDHeaderSeeThroughSelection] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrGSPDarkBkgd] = Color.FromArgb(159, 171, 128);
			rgbTable[KnownColors.msocbvcrGSPDarkBkgd] = Color.FromArgb(159, 171, 128);
			rgbTable[KnownColors.msocbvcrGSPGroupContentDarkBkgd] = Color.FromArgb(217, 227, 187);
			rgbTable[KnownColors.msocbvcrGSPGroupContentLightBkgd] = Color.FromArgb(230, 234, 208);
			rgbTable[KnownColors.msocbvcrGSPGroupContentText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrGSPGroupContentTextDisabled] = Color.FromArgb(150, 145, 133);
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderDarkBkgd] = Color.FromArgb(161, 176, 128);
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderLightBkgd] = Color.FromArgb(210, 223, 174);
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderText] = Color.FromArgb(90, 107, 70);
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderText] = Color.FromArgb(90, 107, 70);
			rgbTable[KnownColors.msocbvcrGSPGroupline] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrGSPGroupline] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrGSPHyperlink] = Color.FromArgb(0, 61, 178);
			rgbTable[KnownColors.msocbvcrGSPLightBkgd] = Color.FromArgb(243, 242, 231);
			rgbTable[KnownColors.msocbvcrHyperlink] = Color.FromArgb(0, 61, 178);
			rgbTable[KnownColors.msocbvcrHyperlinkFollowed] = Color.FromArgb(170, 0, 170);
			rgbTable[KnownColors.msocbvcrJotNavUIBdr] = Color.FromArgb(96, 128, 88);
			rgbTable[KnownColors.msocbvcrJotNavUIBdr] = Color.FromArgb(96, 128, 88);
			rgbTable[KnownColors.msocbvcrJotNavUIGradBegin] = Color.FromArgb(217, 217, 167);
			rgbTable[KnownColors.msocbvcrJotNavUIGradBegin] = Color.FromArgb(217, 217, 167);
			rgbTable[KnownColors.msocbvcrJotNavUIGradEnd] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrJotNavUIGradMiddle] = Color.FromArgb(242, 241, 228);
			rgbTable[KnownColors.msocbvcrJotNavUIGradMiddle] = Color.FromArgb(242, 241, 228);
			rgbTable[KnownColors.msocbvcrJotNavUIText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrListHeaderArrow] = Color.FromArgb(172, 168, 153);
			rgbTable[KnownColors.msocbvcrNetLookBkgnd] = Color.FromArgb(255, 255, 237);
			rgbTable[KnownColors.msocbvcrOABBkgd] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOBBkgdBdr] = Color.FromArgb(211, 211, 211);
			rgbTable[KnownColors.msocbvcrOBBkgdBdrContrast] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrOGMDIParentWorkspaceBkgd] = Color.FromArgb(151, 160, 123);
			rgbTable[KnownColors.msocbvcrOGRulerActiveBkgd] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOGRulerBdr] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrOGRulerBkgd] = Color.FromArgb(226, 231, 191);
			rgbTable[KnownColors.msocbvcrOGRulerInactiveBkgd] = Color.FromArgb(171, 192, 138);
			rgbTable[KnownColors.msocbvcrOGRulerTabBoxBdr] = Color.FromArgb(117, 141, 94);
			rgbTable[KnownColors.msocbvcrOGRulerTabBoxBdrHighlight] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOGRulerTabStopTicks] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrOGRulerText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrOGTaskPaneGroupBoxHeaderBkgd] = Color.FromArgb(218, 227, 187);
			rgbTable[KnownColors.msocbvcrOGWorkspaceBkgd] = Color.FromArgb(151, 160, 123);
			rgbTable[KnownColors.msocbvcrOLKFlagNone] = Color.FromArgb(242, 240, 228);
			rgbTable[KnownColors.msocbvcrOLKFolderbarDark] = Color.FromArgb(96, 119, 66);
			rgbTable[KnownColors.msocbvcrOLKFolderbarLight] = Color.FromArgb(175, 192, 130);
			rgbTable[KnownColors.msocbvcrOLKFolderbarText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOLKGridlines] = Color.FromArgb(234, 233, 225);
			rgbTable[KnownColors.msocbvcrOLKGroupLine] = Color.FromArgb(181, 196, 143);
			rgbTable[KnownColors.msocbvcrOLKGroupNested] = Color.FromArgb(253, 238, 201);
			rgbTable[KnownColors.msocbvcrOLKGroupShaded] = Color.FromArgb(175, 186, 145);
			rgbTable[KnownColors.msocbvcrOLKGroupText] = Color.FromArgb(115, 137, 84);
			rgbTable[KnownColors.msocbvcrOLKIconBar] = Color.FromArgb(253, 247, 233);
			rgbTable[KnownColors.msocbvcrOLKInfoBarBkgd] = Color.FromArgb(151, 160, 123);
			rgbTable[KnownColors.msocbvcrOLKInfoBarText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOLKPreviewPaneLabelText] = Color.FromArgb(151, 160, 123);
			rgbTable[KnownColors.msocbvcrOLKTodayIndicatorDark] = Color.FromArgb(187, 85, 3);
			rgbTable[KnownColors.msocbvcrOLKTodayIndicatorLight] = Color.FromArgb(251, 200, 79);
			rgbTable[KnownColors.msocbvcrOLKWBActionDividerLine] = Color.FromArgb(200, 212, 172);
			rgbTable[KnownColors.msocbvcrOLKWBButtonDark] = Color.FromArgb(176, 191, 138);
			rgbTable[KnownColors.msocbvcrOLKWBButtonLight] = Color.FromArgb(234, 240, 207);
			rgbTable[KnownColors.msocbvcrOLKWBButtonLight] = Color.FromArgb(234, 240, 207);
			rgbTable[KnownColors.msocbvcrOLKWBDarkOutline] = Color.FromArgb(96, 128, 88);
			rgbTable[KnownColors.msocbvcrOLKWBFoldersBackground] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOLKWBHoverButtonDark] = Color.FromArgb(247, 190, 87);
			rgbTable[KnownColors.msocbvcrOLKWBHoverButtonLight] = Color.FromArgb(255, 255, 220);
			rgbTable[KnownColors.msocbvcrOLKWBLabelText] = Color.FromArgb(50, 69, 105);
			rgbTable[KnownColors.msocbvcrOLKWBPressedButtonDark] = Color.FromArgb(248, 222, 128);
			rgbTable[KnownColors.msocbvcrOLKWBPressedButtonLight] = Color.FromArgb(232, 127, 8);
			rgbTable[KnownColors.msocbvcrOLKWBSelectedButtonDark] = Color.FromArgb(238, 147, 17);
			rgbTable[KnownColors.msocbvcrOLKWBSelectedButtonLight] = Color.FromArgb(251, 230, 148);
			rgbTable[KnownColors.msocbvcrOLKWBSplitterDark] = Color.FromArgb(64, 81, 59);
			rgbTable[KnownColors.msocbvcrOLKWBSplitterLight] = Color.FromArgb(120, 142, 111);
			rgbTable[KnownColors.msocbvcrOLKWBSplitterLight] = Color.FromArgb(120, 142, 111);
			rgbTable[KnownColors.msocbvcrPlacesBarBkgd] = Color.FromArgb(236, 233, 216);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabAreaBkgd] = Color.FromArgb(242, 240, 228);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabBdr] = Color.FromArgb(96, 128, 88);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabInactiveBkgd] = Color.FromArgb(206, 220, 167);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrPPSlideBdrActiveSelected] = Color.FromArgb(107, 129, 107);
			rgbTable[KnownColors.msocbvcrPPSlideBdrActiveSelectedMouseOver] = Color.FromArgb(107, 129, 107);
			rgbTable[KnownColors.msocbvcrPPSlideBdrInactiveSelected] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrPPSlideBdrMouseOver] = Color.FromArgb(107, 129, 107);
			rgbTable[KnownColors.msocbvcrPubPrintDocScratchPageBkgd] = Color.FromArgb(151, 160, 123);
			rgbTable[KnownColors.msocbvcrPubWebDocScratchPageBkgd] = Color.FromArgb(193, 198, 176);
			rgbTable[KnownColors.msocbvcrSBBdr] = Color.FromArgb(211, 211, 211);
			rgbTable[KnownColors.msocbvcrScrollbarBkgd] = Color.FromArgb(249, 249, 247);
			rgbTable[KnownColors.msocbvcrToastGradBegin] = Color.FromArgb(237, 242, 212);
			rgbTable[KnownColors.msocbvcrToastGradEnd] = Color.FromArgb(191, 206, 153);
			rgbTable[KnownColors.msocbvcrWPBdrInnerDocked] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrWPBdrOuterDocked] = Color.FromArgb(242, 241, 228);
			rgbTable[KnownColors.msocbvcrWPBdrOuterFloating] = Color.FromArgb(116, 134, 94);
			rgbTable[KnownColors.msocbvcrWPBkgd] = Color.FromArgb(243, 242, 231);
			rgbTable[KnownColors.msocbvcrWPCtlBdr] = Color.FromArgb(164, 185, 127);
			rgbTable[KnownColors.msocbvcrWPCtlBdrDefault] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPCtlBdrDefault] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPCtlBdrDisabled] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrWPCtlBkgd] = Color.FromArgb(197, 212, 159);
			rgbTable[KnownColors.msocbvcrWPCtlBkgdDisabled] = Color.FromArgb(222, 222, 222);
			rgbTable[KnownColors.msocbvcrWPCtlText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPCtlTextDisabled] = Color.FromArgb(172, 168, 153);
			rgbTable[KnownColors.msocbvcrWPCtlTextMouseDown] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPGroupline] = Color.FromArgb(188, 187, 177);
			rgbTable[KnownColors.msocbvcrWPInfoTipBkgd] = Color.FromArgb(255, 255, 204);
			rgbTable[KnownColors.msocbvcrWPInfoTipText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPNavBarBkgnd] = Color.FromArgb(116, 134, 94);
			rgbTable[KnownColors.msocbvcrWPText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPTextDisabled] = Color.FromArgb(172, 168, 153);
			rgbTable[KnownColors.msocbvcrWPTitleBkgdActive] = Color.FromArgb(216, 227, 182);
			rgbTable[KnownColors.msocbvcrWPTitleBkgdInactive] = Color.FromArgb(188, 205, 131);
			rgbTable[KnownColors.msocbvcrWPTitleTextActive] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPTitleTextInactive] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrXLFormulaBarBkgd] = Color.FromArgb(217, 217, 167);
		}

		private void InitRoyaleColors(ref Hashtable rgbTable)
		{
			rgbTable[KnownColors.msocbvcrCBBkgd] = Color.FromArgb(238, 237, 240);
			rgbTable[KnownColors.msocbvcrCBDragHandle] = Color.FromArgb(189, 188, 191);
			rgbTable[KnownColors.msocbvcrCBSplitterLine] = Color.FromArgb(193, 193, 196);
			rgbTable[KnownColors.msocbvcrCBTitleBkgd] = Color.FromArgb(167, 166, 170);
			rgbTable[KnownColors.msocbvcrCBTitleText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrCBBdrOuterFloating] = Color.FromArgb(142, 141, 145);
			rgbTable[KnownColors.msocbvcrCBBdrOuterDocked] = Color.FromArgb(235, 233, 237);
			rgbTable[KnownColors.msocbvcrCBTearOffHandle] = Color.FromArgb(238, 237, 240);
			rgbTable[KnownColors.msocbvcrCBTearOffHandleMouseOver] = Color.FromArgb(194, 207, 229);
			rgbTable[KnownColors.msocbvcrCBCtlBkgd] = Color.FromArgb(238, 237, 240);
			rgbTable[KnownColors.msocbvcrCBCtlText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBCtlTextDisabled] = Color.FromArgb(176, 175, 179);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdMouseOver] = Color.FromArgb(194, 207, 229);
			rgbTable[KnownColors.msocbvcrCBCtlBdrMouseOver] = Color.FromArgb(51, 94, 168);
			rgbTable[KnownColors.msocbvcrCBCtlTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdMouseDown] = Color.FromArgb(153, 175, 212);
			rgbTable[KnownColors.msocbvcrCBCtlBdrMouseDown] = Color.FromArgb(51, 94, 168);
			rgbTable[KnownColors.msocbvcrCBCtlTextMouseDown] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdSelected] = Color.FromArgb(226, 229, 238);
			rgbTable[KnownColors.msocbvcrCBCtlBdrSelected] = Color.FromArgb(51, 94, 168);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdSelectedMouseOver] = Color.FromArgb(51, 94, 168);
			rgbTable[KnownColors.msocbvcrCBCtlBdrSelectedMouseOver] = Color.FromArgb(51, 94, 168);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdLight] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrCBCtlTextLight] = Color.FromArgb(167, 166, 170);
			rgbTable[KnownColors.msocbvcrCBMainMenuBkgd] = Color.FromArgb(235, 233, 237);
			rgbTable[KnownColors.msocbvcrCBMenuBkgd] = Color.FromArgb(252, 252, 252);
			rgbTable[KnownColors.msocbvcrCBMenuCtlText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBMenuCtlTextDisabled] = Color.FromArgb(193, 193, 196);
			rgbTable[KnownColors.msocbvcrCBMenuBdrOuter] = Color.FromArgb(134, 133, 136);
			rgbTable[KnownColors.msocbvcrCBMenuIconBkgd] = Color.FromArgb(238, 237, 240);
			rgbTable[KnownColors.msocbvcrCBMenuIconBkgdDropped] = Color.FromArgb(228, 226, 230);
			rgbTable[KnownColors.msocbvcrCBMenuSplitArrow] = Color.FromArgb(167, 166, 170);
			rgbTable[KnownColors.msocbvcrWPBkgd] = Color.FromArgb(245, 244, 246);
			rgbTable[KnownColors.msocbvcrWPText] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPTitleBkgdActive] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPTitleBkgdInactive] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPTitleTextActive] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPTitleTextInactive] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPBdrOuterFloating] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPBdrOuterDocked] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPCtlBdr] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPCtlText] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPCtlBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPCtlBdrDisabled] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPCtlTextDisabled] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPCtlBkgdDisabled] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPCtlBdrDefault] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPGroupline] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrSBBdr] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOBBkgdBdr] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOBBkgdBdrContrast] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOABBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGDHeaderBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGDHeaderBdr] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGDHeaderCellBdr] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGDHeaderSeeThroughSelection] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGDHeaderCellBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGDHeaderCellBkgdSelected] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrCBSplitterLineLight] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrCBShadow] = Color.FromArgb(238, 237, 240);
			rgbTable[KnownColors.msocbvcrCBOptionsButtonShadow] = Color.FromArgb(245, 244, 246);
			rgbTable[KnownColors.msocbvcrWPNavBarBkgnd] = Color.FromArgb(193, 193, 196);
			rgbTable[KnownColors.msocbvcrWPBdrInnerDocked] = Color.FromArgb(245, 244, 246);
			rgbTable[KnownColors.msocbvcrCBLabelBkgnd] = Color.FromArgb(235, 233, 237);
			rgbTable[KnownColors.msocbvcrCBIconDisabledLight] = Color.FromArgb(235, 233, 237);
			rgbTable[KnownColors.msocbvcrCBIconDisabledDark] = Color.FromArgb(167, 166, 170);
			rgbTable[KnownColors.msocbvcrCBLowColorIconDisabled] = Color.FromArgb(176, 175, 179);
			rgbTable[KnownColors.msocbvcrCBGradMainMenuHorzBegin] = Color.FromArgb(235, 233, 237);
			rgbTable[KnownColors.msocbvcrCBGradMainMenuHorzEnd] = Color.FromArgb(251, 250, 251);
			rgbTable[KnownColors.msocbvcrCBGradVertBegin] = Color.FromArgb(252, 252, 252);
			rgbTable[KnownColors.msocbvcrCBGradVertMiddle] = Color.FromArgb(245, 244, 246);
			rgbTable[KnownColors.msocbvcrCBGradVertEnd] = Color.FromArgb(235, 233, 237);
			rgbTable[KnownColors.msocbvcrCBGradOptionsBegin] = Color.FromArgb(242, 242, 242);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMiddle] = Color.FromArgb(224, 224, 225);
			rgbTable[KnownColors.msocbvcrCBGradOptionsEnd] = Color.FromArgb(167, 166, 170);
			rgbTable[KnownColors.msocbvcrCBGradMenuTitleBkgdBegin] = Color.FromArgb(252, 252, 252);
			rgbTable[KnownColors.msocbvcrCBGradMenuTitleBkgdEnd] = Color.FromArgb(245, 244, 246);
			rgbTable[KnownColors.msocbvcrCBGradMenuIconBkgdDroppedBegin] = Color.FromArgb(247, 246, 248);
			rgbTable[KnownColors.msocbvcrCBGradMenuIconBkgdDroppedMiddle] = Color.FromArgb(241, 240, 242);
			rgbTable[KnownColors.msocbvcrCBGradMenuIconBkgdDroppedEnd] = Color.FromArgb(228, 226, 230);
			rgbTable[KnownColors.msocbvcrCBGradOptionsSelectedBegin] = Color.FromArgb(226, 229, 238);
			rgbTable[KnownColors.msocbvcrCBGradOptionsSelectedMiddle] = Color.FromArgb(226, 229, 238);
			rgbTable[KnownColors.msocbvcrCBGradOptionsSelectedEnd] = Color.FromArgb(226, 229, 238);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMouseOverBegin] = Color.FromArgb(194, 207, 229);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMouseOverMiddle] = Color.FromArgb(194, 207, 229);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMouseOverEnd] = Color.FromArgb(194, 207, 229);
			rgbTable[KnownColors.msocbvcrCBGradSelectedBegin] = Color.FromArgb(226, 229, 238);
			rgbTable[KnownColors.msocbvcrCBGradSelectedMiddle] = Color.FromArgb(226, 229, 238);
			rgbTable[KnownColors.msocbvcrCBGradSelectedEnd] = Color.FromArgb(226, 229, 238);
			rgbTable[KnownColors.msocbvcrCBGradMouseOverBegin] = Color.FromArgb(194, 207, 229);
			rgbTable[KnownColors.msocbvcrCBGradMouseOverMiddle] = Color.FromArgb(194, 207, 229);
			rgbTable[KnownColors.msocbvcrCBGradMouseOverEnd] = Color.FromArgb(194, 207, 229);
			rgbTable[KnownColors.msocbvcrCBGradMouseDownBegin] = Color.FromArgb(153, 175, 212);
			rgbTable[KnownColors.msocbvcrCBGradMouseDownMiddle] = Color.FromArgb(153, 175, 212);
			rgbTable[KnownColors.msocbvcrCBGradMouseDownEnd] = Color.FromArgb(153, 175, 212);
			rgbTable[KnownColors.msocbvcrNetLookBkgnd] = Color.FromArgb(235, 233, 237);
			rgbTable[KnownColors.msocbvcrCBMenuShadow] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBDockSeparatorLine] = Color.FromArgb(51, 94, 168);
			rgbTable[KnownColors.msocbvcrCBDropDownArrow] = Color.FromArgb(235, 233, 237);
			rgbTable[KnownColors.msocbvcrOLKGridlines] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKGroupText] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKGroupLine] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKGroupShaded] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKGroupNested] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKIconBar] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKFlagNone] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKFolderbarLight] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKFolderbarDark] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKFolderbarText] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKWBButtonLight] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKWBButtonDark] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKWBSelectedButtonLight] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKWBSelectedButtonDark] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKWBHoverButtonLight] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKWBHoverButtonDark] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKWBPressedButtonLight] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKWBPressedButtonDark] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKWBDarkOutline] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKWBSplitterLight] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKWBSplitterDark] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKWBActionDividerLine] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKWBLabelText] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKWBFoldersBackground] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKTodayIndicatorLight] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKTodayIndicatorDark] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKInfoBarBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKInfoBarText] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOLKPreviewPaneLabelText] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrHyperlink] = Color.FromArgb(0, 61, 178);
			rgbTable[KnownColors.msocbvcrHyperlinkFollowed] = Color.FromArgb(170, 0, 170);
			rgbTable[KnownColors.msocbvcrOGWorkspaceBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOGMDIParentWorkspaceBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOGRulerBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOGRulerActiveBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOGRulerInactiveBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOGRulerText] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOGRulerTabStopTicks] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOGRulerBdr] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOGRulerTabBoxBdr] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrOGRulerTabBoxBdrHighlight] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrXLFormulaBarBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrCBDragHandleShadow] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOGTaskPaneGroupBoxHeaderBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabAreaBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabInactiveBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabBdr] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabText] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrPPSlideBdrActiveSelected] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrPPSlideBdrInactiveSelected] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrPPSlideBdrMouseOver] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrPPSlideBdrActiveSelectedMouseOver] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrDlgGroupBoxText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrScrollbarBkgd] = Color.FromArgb(237, 235, 239);
			rgbTable[KnownColors.msocbvcrListHeaderArrow] = Color.FromArgb(155, 154, 156);
			rgbTable[KnownColors.msocbvcrDisabledHighlightedText] = Color.FromArgb(188, 202, 226);
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedBkgd] = Color.FromArgb(235, 233, 237);
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDisabledFocuslessHighlightedText] = Color.FromArgb(167, 166, 170);
			rgbTable[KnownColors.msocbvcrWPCtlTextMouseDown] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPTextDisabled] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPInfoTipBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrWPInfoTipText] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrDWActiveTabBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrDWActiveTabText] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrDWActiveTabTextDisabled] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrDWInactiveTabBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrDWInactiveTabText] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrDWTabBkgdMouseOver] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrDWTabTextMouseOver] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrDWTabBkgdMouseDown] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrDWTabTextMouseDown] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGSPLightBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGSPDarkBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderLightBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderDarkBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderText] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGSPGroupContentLightBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGSPGroupContentDarkBkgd] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGSPGroupContentText] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGSPGroupContentTextDisabled] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGSPGroupline] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrGSPHyperlink] = Color.FromArgb(255, 51, 153);
			rgbTable[KnownColors.msocbvcrDocTabBkgd] = Color.FromArgb(212, 212, 226);
			rgbTable[KnownColors.msocbvcrDocTabText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabBdr] = Color.FromArgb(118, 116, 146);
			rgbTable[KnownColors.msocbvcrDocTabBdrLight] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDocTabBdrDark] = Color.FromArgb(186, 185, 206);
			rgbTable[KnownColors.msocbvcrDocTabBkgdSelected] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDocTabTextSelected] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabBdrSelected] = Color.FromArgb(124, 124, 148);
			rgbTable[KnownColors.msocbvcrDocTabBkgdMouseOver] = Color.FromArgb(193, 210, 238);
			rgbTable[KnownColors.msocbvcrDocTabTextMouseOver] = Color.FromArgb(49, 106, 197);
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseOver] = Color.FromArgb(49, 106, 197);
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseOver] = Color.FromArgb(49, 106, 197);
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseOver] = Color.FromArgb(49, 106, 197);
			rgbTable[KnownColors.msocbvcrDocTabBkgdMouseDown] = Color.FromArgb(154, 183, 228);
			rgbTable[KnownColors.msocbvcrDocTabTextMouseDown] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseDown] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseDown] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseDown] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrToastGradBegin] = Color.FromArgb(246, 244, 236);
			rgbTable[KnownColors.msocbvcrToastGradEnd] = Color.FromArgb(179, 178, 204);
			rgbTable[KnownColors.msocbvcrJotNavUIGradBegin] = Color.FromArgb(236, 233, 216);
			rgbTable[KnownColors.msocbvcrJotNavUIGradMiddle] = Color.FromArgb(236, 233, 216);
			rgbTable[KnownColors.msocbvcrJotNavUIGradEnd] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrJotNavUIText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrJotNavUIBdr] = Color.FromArgb(172, 168, 153);
			rgbTable[KnownColors.msocbvcrPlacesBarBkgd] = Color.FromArgb(224, 223, 227);
			rgbTable[KnownColors.msocbvcrPubPrintDocScratchPageBkgd] = Color.FromArgb(152, 181, 226);
			rgbTable[KnownColors.msocbvcrPubWebDocScratchPageBkgd] = Color.FromArgb(193, 210, 238);
		}

		internal void InitSilverLunaColors(ref Hashtable rgbTable)
		{
			rgbTable[KnownColors.msocbvcrCBBdrOuterDocked] = Color.FromArgb(173, 174, 193);
			rgbTable[KnownColors.msocbvcrCBBdrOuterFloating] = Color.FromArgb(122, 121, 153);
			rgbTable[KnownColors.msocbvcrCBBkgd] = Color.FromArgb(219, 218, 228);
			rgbTable[KnownColors.msocbvcrCBCtlBdrMouseDown] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrCBCtlBdrMouseOver] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrCBCtlBdrSelected] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrCBCtlBdrSelectedMouseOver] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrCBCtlBkgd] = Color.FromArgb(219, 218, 228);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdLight] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdMouseDown] = Color.FromArgb(254, 128, 62);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdSelected] = Color.FromArgb(255, 192, 111);
			rgbTable[KnownColors.msocbvcrCBCtlBkgdSelectedMouseOver] = Color.FromArgb(254, 128, 62);
			rgbTable[KnownColors.msocbvcrCBCtlText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBCtlTextDisabled] = Color.FromArgb(141, 141, 141);
			rgbTable[KnownColors.msocbvcrCBCtlTextLight] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrCBCtlTextMouseDown] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBCtlTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBDockSeparatorLine] = Color.FromArgb(110, 109, 143);
			rgbTable[KnownColors.msocbvcrCBDragHandle] = Color.FromArgb(84, 84, 117);
			rgbTable[KnownColors.msocbvcrCBDragHandleShadow] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrCBDropDownArrow] = Color.FromArgb(224, 223, 227);
			rgbTable[KnownColors.msocbvcrCBGradMainMenuHorzBegin] = Color.FromArgb(215, 215, 229);
			rgbTable[KnownColors.msocbvcrCBGradMainMenuHorzEnd] = Color.FromArgb(243, 243, 247);
			rgbTable[KnownColors.msocbvcrCBGradMenuIconBkgdDroppedBegin] = Color.FromArgb(215, 215, 226);
			rgbTable[KnownColors.msocbvcrCBGradMenuIconBkgdDroppedEnd] = Color.FromArgb(118, 116, 151);
			rgbTable[KnownColors.msocbvcrCBGradMenuIconBkgdDroppedMiddle] = Color.FromArgb(184, 185, 202);
			rgbTable[KnownColors.msocbvcrCBGradMenuTitleBkgdBegin] = Color.FromArgb(232, 233, 242);
			rgbTable[KnownColors.msocbvcrCBGradMenuTitleBkgdEnd] = Color.FromArgb(172, 170, 194);
			rgbTable[KnownColors.msocbvcrCBGradMouseDownBegin] = Color.FromArgb(254, 128, 62);
			rgbTable[KnownColors.msocbvcrCBGradMouseDownEnd] = Color.FromArgb(255, 223, 154);
			rgbTable[KnownColors.msocbvcrCBGradMouseDownMiddle] = Color.FromArgb(255, 177, 109);
			rgbTable[KnownColors.msocbvcrCBGradMouseOverBegin] = Color.FromArgb(255, 255, 222);
			rgbTable[KnownColors.msocbvcrCBGradMouseOverEnd] = Color.FromArgb(255, 203, 136);
			rgbTable[KnownColors.msocbvcrCBGradMouseOverMiddle] = Color.FromArgb(255, 225, 172);
			rgbTable[KnownColors.msocbvcrCBGradOptionsBegin] = Color.FromArgb(186, 185, 206);
			rgbTable[KnownColors.msocbvcrCBGradOptionsEnd] = Color.FromArgb(118, 116, 146);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMiddle] = Color.FromArgb(156, 155, 180);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMouseOverBegin] = Color.FromArgb(255, 255, 222);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMouseOverEnd] = Color.FromArgb(255, 193, 118);
			rgbTable[KnownColors.msocbvcrCBGradOptionsMouseOverMiddle] = Color.FromArgb(255, 225, 172);
			rgbTable[KnownColors.msocbvcrCBGradOptionsSelectedBegin] = Color.FromArgb(254, 140, 73);
			rgbTable[KnownColors.msocbvcrCBGradOptionsSelectedEnd] = Color.FromArgb(255, 221, 152);
			rgbTable[KnownColors.msocbvcrCBGradOptionsSelectedMiddle] = Color.FromArgb(255, 184, 116);
			rgbTable[KnownColors.msocbvcrCBGradSelectedBegin] = Color.FromArgb(255, 223, 154);
			rgbTable[KnownColors.msocbvcrCBGradSelectedEnd] = Color.FromArgb(255, 166, 76);
			rgbTable[KnownColors.msocbvcrCBGradSelectedMiddle] = Color.FromArgb(255, 195, 116);
			rgbTable[KnownColors.msocbvcrCBGradVertBegin] = Color.FromArgb(249, 249, 255);
			rgbTable[KnownColors.msocbvcrCBGradVertEnd] = Color.FromArgb(147, 145, 176);
			rgbTable[KnownColors.msocbvcrCBGradVertMiddle] = Color.FromArgb(225, 226, 236);
			rgbTable[KnownColors.msocbvcrCBIconDisabledDark] = Color.FromArgb(122, 121, 153);
			rgbTable[KnownColors.msocbvcrCBIconDisabledLight] = Color.FromArgb(247, 245, 249);
			rgbTable[KnownColors.msocbvcrCBLabelBkgnd] = Color.FromArgb(212, 212, 226);
			rgbTable[KnownColors.msocbvcrCBLabelBkgnd] = Color.FromArgb(212, 212, 226);
			rgbTable[KnownColors.msocbvcrCBLowColorIconDisabled] = Color.FromArgb(168, 167, 190);
			rgbTable[KnownColors.msocbvcrCBMainMenuBkgd] = Color.FromArgb(198, 200, 215);
			rgbTable[KnownColors.msocbvcrCBMenuBdrOuter] = Color.FromArgb(124, 124, 148);
			rgbTable[KnownColors.msocbvcrCBMenuBkgd] = Color.FromArgb(253, 250, 255);
			rgbTable[KnownColors.msocbvcrCBMenuCtlText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBMenuCtlTextDisabled] = Color.FromArgb(141, 141, 141);
			rgbTable[KnownColors.msocbvcrCBMenuIconBkgd] = Color.FromArgb(214, 211, 231);
			rgbTable[KnownColors.msocbvcrCBMenuIconBkgdDropped] = Color.FromArgb(185, 187, 200);
			rgbTable[KnownColors.msocbvcrCBMenuIconBkgdDropped] = Color.FromArgb(185, 187, 200);
			rgbTable[KnownColors.msocbvcrCBMenuShadow] = Color.FromArgb(154, 140, 176);
			rgbTable[KnownColors.msocbvcrCBMenuSplitArrow] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrCBOptionsButtonShadow] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrCBShadow] = Color.FromArgb(124, 124, 148);
			rgbTable[KnownColors.msocbvcrCBSplitterLine] = Color.FromArgb(110, 109, 143);
			rgbTable[KnownColors.msocbvcrCBSplitterLineLight] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrCBTearOffHandle] = Color.FromArgb(192, 192, 211);
			rgbTable[KnownColors.msocbvcrCBTearOffHandleMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrCBTitleBkgd] = Color.FromArgb(122, 121, 153);
			rgbTable[KnownColors.msocbvcrCBTitleText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDisabledFocuslessHighlightedText] = Color.FromArgb(172, 168, 153);
			rgbTable[KnownColors.msocbvcrDisabledHighlightedText] = Color.FromArgb(59, 59, 63);
			rgbTable[KnownColors.msocbvcrDlgGroupBoxText] = Color.FromArgb(7, 70, 213);
			rgbTable[KnownColors.msocbvcrDocTabBdr] = Color.FromArgb(118, 116, 146);
			rgbTable[KnownColors.msocbvcrDocTabBdrDark] = Color.FromArgb(186, 185, 206);
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseDown] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseOver] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseOver] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseOver] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrDocTabBdrLight] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseDown] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseOver] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseOver] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseOver] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseDown] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseOver] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseOver] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseOver] = Color.FromArgb(75, 75, 111);
			rgbTable[KnownColors.msocbvcrDocTabBdrSelected] = Color.FromArgb(124, 124, 148);
			rgbTable[KnownColors.msocbvcrDocTabBkgd] = Color.FromArgb(212, 212, 226);
			rgbTable[KnownColors.msocbvcrDocTabBkgdMouseDown] = Color.FromArgb(254, 128, 62);
			rgbTable[KnownColors.msocbvcrDocTabBkgdMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrDocTabBkgdMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrDocTabBkgdSelected] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDocTabText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabTextMouseDown] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDocTabTextSelected] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDWActiveTabBkgd] = Color.FromArgb(212, 212, 226);
			rgbTable[KnownColors.msocbvcrDWActiveTabBkgd] = Color.FromArgb(212, 212, 226);
			rgbTable[KnownColors.msocbvcrDWActiveTabText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDWActiveTabText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDWActiveTabTextDisabled] = Color.FromArgb(148, 148, 148);
			rgbTable[KnownColors.msocbvcrDWActiveTabTextDisabled] = Color.FromArgb(148, 148, 148);
			rgbTable[KnownColors.msocbvcrDWInactiveTabBkgd] = Color.FromArgb(171, 169, 194);
			rgbTable[KnownColors.msocbvcrDWInactiveTabBkgd] = Color.FromArgb(171, 169, 194);
			rgbTable[KnownColors.msocbvcrDWInactiveTabText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDWInactiveTabText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrDWTabBkgdMouseDown] = Color.FromArgb(254, 128, 62);
			rgbTable[KnownColors.msocbvcrDWTabBkgdMouseOver] = Color.FromArgb(255, 238, 194);
			rgbTable[KnownColors.msocbvcrDWTabTextMouseDown] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrDWTabTextMouseOver] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedBkgd] = Color.FromArgb(224, 223, 227);
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedBkgd] = Color.FromArgb(224, 223, 227);
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrGDHeaderBdr] = Color.FromArgb(191, 191, 223);
			rgbTable[KnownColors.msocbvcrGDHeaderBkgd] = Color.FromArgb(239, 235, 222);
			rgbTable[KnownColors.msocbvcrGDHeaderCellBdr] = Color.FromArgb(126, 125, 104);
			rgbTable[KnownColors.msocbvcrGDHeaderCellBkgd] = Color.FromArgb(223, 223, 234);
			rgbTable[KnownColors.msocbvcrGDHeaderCellBkgdSelected] = Color.FromArgb(255, 192, 111);
			rgbTable[KnownColors.msocbvcrGDHeaderSeeThroughSelection] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrGSPDarkBkgd] = Color.FromArgb(162, 162, 181);
			rgbTable[KnownColors.msocbvcrGSPDarkBkgd] = Color.FromArgb(162, 162, 181);
			rgbTable[KnownColors.msocbvcrGSPGroupContentDarkBkgd] = Color.FromArgb(212, 213, 229);
			rgbTable[KnownColors.msocbvcrGSPGroupContentLightBkgd] = Color.FromArgb(227, 227, 236);
			rgbTable[KnownColors.msocbvcrGSPGroupContentText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrGSPGroupContentTextDisabled] = Color.FromArgb(150, 145, 133);
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderDarkBkgd] = Color.FromArgb(169, 168, 191);
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderLightBkgd] = Color.FromArgb(208, 208, 223);
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderText] = Color.FromArgb(92, 91, 121);
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderText] = Color.FromArgb(92, 91, 121);
			rgbTable[KnownColors.msocbvcrGSPGroupline] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrGSPGroupline] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrGSPHyperlink] = Color.FromArgb(0, 61, 178);
			rgbTable[KnownColors.msocbvcrGSPLightBkgd] = Color.FromArgb(238, 238, 244);
			rgbTable[KnownColors.msocbvcrHyperlink] = Color.FromArgb(0, 61, 178);
			rgbTable[KnownColors.msocbvcrHyperlinkFollowed] = Color.FromArgb(170, 0, 170);
			rgbTable[KnownColors.msocbvcrJotNavUIBdr] = Color.FromArgb(124, 124, 148);
			rgbTable[KnownColors.msocbvcrJotNavUIBdr] = Color.FromArgb(124, 124, 148);
			rgbTable[KnownColors.msocbvcrJotNavUIGradBegin] = Color.FromArgb(215, 215, 229);
			rgbTable[KnownColors.msocbvcrJotNavUIGradBegin] = Color.FromArgb(215, 215, 229);
			rgbTable[KnownColors.msocbvcrJotNavUIGradEnd] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrJotNavUIGradMiddle] = Color.FromArgb(243, 243, 247);
			rgbTable[KnownColors.msocbvcrJotNavUIGradMiddle] = Color.FromArgb(243, 243, 247);
			rgbTable[KnownColors.msocbvcrJotNavUIText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrListHeaderArrow] = Color.FromArgb(172, 168, 153);
			rgbTable[KnownColors.msocbvcrNetLookBkgnd] = Color.FromArgb(249, 249, 255);
			rgbTable[KnownColors.msocbvcrOABBkgd] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOBBkgdBdr] = Color.FromArgb(211, 211, 211);
			rgbTable[KnownColors.msocbvcrOBBkgdBdrContrast] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrOGMDIParentWorkspaceBkgd] = Color.FromArgb(155, 154, 179);
			rgbTable[KnownColors.msocbvcrOGRulerActiveBkgd] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOGRulerBdr] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrOGRulerBkgd] = Color.FromArgb(223, 223, 234);
			rgbTable[KnownColors.msocbvcrOGRulerInactiveBkgd] = Color.FromArgb(177, 176, 195);
			rgbTable[KnownColors.msocbvcrOGRulerTabBoxBdr] = Color.FromArgb(124, 124, 148);
			rgbTable[KnownColors.msocbvcrOGRulerTabBoxBdrHighlight] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOGRulerTabStopTicks] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrOGRulerText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrOGTaskPaneGroupBoxHeaderBkgd] = Color.FromArgb(212, 212, 226);
			rgbTable[KnownColors.msocbvcrOGWorkspaceBkgd] = Color.FromArgb(155, 154, 179);
			rgbTable[KnownColors.msocbvcrOLKFlagNone] = Color.FromArgb(239, 239, 244);
			rgbTable[KnownColors.msocbvcrOLKFolderbarDark] = Color.FromArgb(110, 109, 143);
			rgbTable[KnownColors.msocbvcrOLKFolderbarLight] = Color.FromArgb(168, 167, 191);
			rgbTable[KnownColors.msocbvcrOLKFolderbarText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOLKGridlines] = Color.FromArgb(234, 233, 225);
			rgbTable[KnownColors.msocbvcrOLKGroupLine] = Color.FromArgb(165, 164, 189);
			rgbTable[KnownColors.msocbvcrOLKGroupNested] = Color.FromArgb(253, 238, 201);
			rgbTable[KnownColors.msocbvcrOLKGroupShaded] = Color.FromArgb(229, 229, 235);
			rgbTable[KnownColors.msocbvcrOLKGroupText] = Color.FromArgb(112, 111, 145);
			rgbTable[KnownColors.msocbvcrOLKIconBar] = Color.FromArgb(253, 247, 233);
			rgbTable[KnownColors.msocbvcrOLKInfoBarBkgd] = Color.FromArgb(155, 154, 179);
			rgbTable[KnownColors.msocbvcrOLKInfoBarText] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOLKPreviewPaneLabelText] = Color.FromArgb(155, 154, 179);
			rgbTable[KnownColors.msocbvcrOLKTodayIndicatorDark] = Color.FromArgb(187, 85, 3);
			rgbTable[KnownColors.msocbvcrOLKTodayIndicatorLight] = Color.FromArgb(251, 200, 79);
			rgbTable[KnownColors.msocbvcrOLKWBActionDividerLine] = Color.FromArgb(204, 206, 219);
			rgbTable[KnownColors.msocbvcrOLKWBButtonDark] = Color.FromArgb(147, 145, 176);
			rgbTable[KnownColors.msocbvcrOLKWBButtonLight] = Color.FromArgb(225, 226, 236);
			rgbTable[KnownColors.msocbvcrOLKWBButtonLight] = Color.FromArgb(225, 226, 236);
			rgbTable[KnownColors.msocbvcrOLKWBDarkOutline] = Color.FromArgb(124, 124, 148);
			rgbTable[KnownColors.msocbvcrOLKWBFoldersBackground] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrOLKWBHoverButtonDark] = Color.FromArgb(247, 190, 87);
			rgbTable[KnownColors.msocbvcrOLKWBHoverButtonLight] = Color.FromArgb(255, 255, 220);
			rgbTable[KnownColors.msocbvcrOLKWBLabelText] = Color.FromArgb(50, 69, 105);
			rgbTable[KnownColors.msocbvcrOLKWBPressedButtonDark] = Color.FromArgb(248, 222, 128);
			rgbTable[KnownColors.msocbvcrOLKWBPressedButtonLight] = Color.FromArgb(232, 127, 8);
			rgbTable[KnownColors.msocbvcrOLKWBSelectedButtonDark] = Color.FromArgb(238, 147, 17);
			rgbTable[KnownColors.msocbvcrOLKWBSelectedButtonLight] = Color.FromArgb(251, 230, 148);
			rgbTable[KnownColors.msocbvcrOLKWBSplitterDark] = Color.FromArgb(110, 109, 143);
			rgbTable[KnownColors.msocbvcrOLKWBSplitterLight] = Color.FromArgb(168, 167, 191);
			rgbTable[KnownColors.msocbvcrOLKWBSplitterLight] = Color.FromArgb(168, 167, 191);
			rgbTable[KnownColors.msocbvcrPlacesBarBkgd] = Color.FromArgb(224, 223, 227);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabAreaBkgd] = Color.FromArgb(243, 243, 247);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabBdr] = Color.FromArgb(124, 124, 148);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabInactiveBkgd] = Color.FromArgb(215, 215, 229);
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrPPSlideBdrActiveSelected] = Color.FromArgb(142, 142, 170);
			rgbTable[KnownColors.msocbvcrPPSlideBdrActiveSelectedMouseOver] = Color.FromArgb(142, 142, 170);
			rgbTable[KnownColors.msocbvcrPPSlideBdrInactiveSelected] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrPPSlideBdrMouseOver] = Color.FromArgb(142, 142, 170);
			rgbTable[KnownColors.msocbvcrPubPrintDocScratchPageBkgd] = Color.FromArgb(155, 154, 179);
			rgbTable[KnownColors.msocbvcrPubWebDocScratchPageBkgd] = Color.FromArgb(195, 195, 210);
			rgbTable[KnownColors.msocbvcrSBBdr] = Color.FromArgb(236, 234, 218);
			rgbTable[KnownColors.msocbvcrScrollbarBkgd] = Color.FromArgb(247, 247, 249);
			rgbTable[KnownColors.msocbvcrToastGradBegin] = Color.FromArgb(239, 239, 247);
			rgbTable[KnownColors.msocbvcrToastGradEnd] = Color.FromArgb(179, 178, 204);
			rgbTable[KnownColors.msocbvcrWPBdrInnerDocked] = Color.FromArgb(255, 255, 255);
			rgbTable[KnownColors.msocbvcrWPBdrOuterDocked] = Color.FromArgb(243, 243, 247);
			rgbTable[KnownColors.msocbvcrWPBdrOuterFloating] = Color.FromArgb(122, 121, 153);
			rgbTable[KnownColors.msocbvcrWPBkgd] = Color.FromArgb(238, 238, 244);
			rgbTable[KnownColors.msocbvcrWPCtlBdr] = Color.FromArgb(165, 172, 178);
			rgbTable[KnownColors.msocbvcrWPCtlBdrDefault] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPCtlBdrDefault] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPCtlBdrDisabled] = Color.FromArgb(128, 128, 128);
			rgbTable[KnownColors.msocbvcrWPCtlBkgd] = Color.FromArgb(192, 192, 211);
			rgbTable[KnownColors.msocbvcrWPCtlBkgdDisabled] = Color.FromArgb(222, 222, 222);
			rgbTable[KnownColors.msocbvcrWPCtlText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPCtlTextDisabled] = Color.FromArgb(172, 168, 153);
			rgbTable[KnownColors.msocbvcrWPCtlTextMouseDown] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPGroupline] = Color.FromArgb(161, 160, 187);
			rgbTable[KnownColors.msocbvcrWPInfoTipBkgd] = Color.FromArgb(255, 255, 204);
			rgbTable[KnownColors.msocbvcrWPInfoTipText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPNavBarBkgnd] = Color.FromArgb(122, 121, 153);
			rgbTable[KnownColors.msocbvcrWPText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPText] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPTextDisabled] = Color.FromArgb(172, 168, 153);
			rgbTable[KnownColors.msocbvcrWPTitleBkgdActive] = Color.FromArgb(184, 188, 234);
			rgbTable[KnownColors.msocbvcrWPTitleBkgdInactive] = Color.FromArgb(198, 198, 217);
			rgbTable[KnownColors.msocbvcrWPTitleTextActive] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrWPTitleTextInactive] = Color.FromArgb(0, 0, 0);
			rgbTable[KnownColors.msocbvcrXLFormulaBarBkgd] = Color.FromArgb(215, 215, 229);
		}

		internal void InitSystemColors(ref Hashtable rgbTable)
		{
			mblnUsingSystemColors = true;
			InitCommonColors(ref rgbTable);
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
			Color color = buttonFace;
			Color color2 = buttonFace;
			Color color3 = buttonFace;
			Color color4 = highlight;
			Color color5 = highlight;
			color4 = window;
			rgbTable[KnownColors.msocbvcrCBBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrCBCtlBkgdSelectedMouseOver] = SystemColors.ControlLight;
			rgbTable[KnownColors.msocbvcrCBDragHandle] = controlText;
			rgbTable[KnownColors.msocbvcrCBGradMainMenuHorzEnd] = buttonFace;
			rgbTable[KnownColors.msocbvcrCBGradOptionsBegin] = buttonShadow;
			rgbTable[KnownColors.msocbvcrCBGradOptionsMiddle] = buttonShadow;
			rgbTable[KnownColors.msocbvcrCBGradMenuIconBkgdDroppedBegin] = buttonShadow;
			rgbTable[KnownColors.msocbvcrCBGradMenuIconBkgdDroppedMiddle] = buttonShadow;
			rgbTable[KnownColors.msocbvcrCBGradMenuIconBkgdDroppedEnd] = buttonShadow;
			rgbTable[KnownColors.msocbvcrCBMenuBdrOuter] = controlText;
			rgbTable[KnownColors.msocbvcrCBMenuBkgd] = window;
			rgbTable[KnownColors.msocbvcrCBSplitterLine] = buttonShadow;
			rgbTable[KnownColors.msocbvcrCBCtlBkgdSelected] = SystemColors.ControlLight;
			rgbTable[KnownColors.msocbvcrCBBdrOuterDocked] = buttonFace;
			rgbTable[KnownColors.msocbvcrCBBdrOuterDocked] = buttonShadow;
			rgbTable[KnownColors.msocbvcrCBBdrOuterFloating] = buttonShadow;
			rgbTable[KnownColors.msocbvcrCBCtlBdrMouseDown] = highlight;
			rgbTable[KnownColors.msocbvcrCBCtlBdrMouseOver] = highlight;
			rgbTable[KnownColors.msocbvcrCBCtlBdrSelected] = highlight;
			rgbTable[KnownColors.msocbvcrCBCtlBdrSelectedMouseOver] = highlight;
			rgbTable[KnownColors.msocbvcrCBCtlBkgd] = empty;
			rgbTable[KnownColors.msocbvcrCBCtlBkgdLight] = window;
			rgbTable[KnownColors.msocbvcrCBCtlBkgdMouseDown] = highlight;
			rgbTable[KnownColors.msocbvcrCBCtlBkgdMouseOver] = window;
			rgbTable[KnownColors.msocbvcrCBCtlText] = controlText;
			rgbTable[KnownColors.msocbvcrCBCtlTextDisabled] = buttonShadow;
			rgbTable[KnownColors.msocbvcrCBCtlTextLight] = grayText;
			rgbTable[KnownColors.msocbvcrCBCtlTextMouseDown] = highlightText;
			rgbTable[KnownColors.msocbvcrCBCtlTextMouseOver] = windowText;
			rgbTable[KnownColors.msocbvcrCBDockSeparatorLine] = empty;
			rgbTable[KnownColors.msocbvcrCBDragHandleShadow] = window;
			rgbTable[KnownColors.msocbvcrCBDropDownArrow] = empty;
			rgbTable[KnownColors.msocbvcrCBGradMainMenuHorzBegin] = buttonFace;
			rgbTable[KnownColors.msocbvcrCBGradMouseOverEnd] = color4;
			rgbTable[KnownColors.msocbvcrCBGradMouseOverBegin] = color4;
			rgbTable[KnownColors.msocbvcrCBGradMouseOverMiddle] = color4;
			rgbTable[KnownColors.msocbvcrCBGradOptionsEnd] = buttonShadow;
			rgbTable[KnownColors.msocbvcrCBGradOptionsMouseOverBegin] = empty;
			rgbTable[KnownColors.msocbvcrCBGradOptionsMouseOverEnd] = empty;
			rgbTable[KnownColors.msocbvcrCBGradOptionsMouseOverMiddle] = empty;
			rgbTable[KnownColors.msocbvcrCBGradOptionsSelectedBegin] = empty;
			rgbTable[KnownColors.msocbvcrCBGradOptionsSelectedEnd] = empty;
			rgbTable[KnownColors.msocbvcrCBGradOptionsSelectedMiddle] = empty;
			rgbTable[KnownColors.msocbvcrCBGradSelectedBegin] = empty;
			rgbTable[KnownColors.msocbvcrCBGradSelectedEnd] = empty;
			rgbTable[KnownColors.msocbvcrCBGradSelectedMiddle] = empty;
			rgbTable[KnownColors.msocbvcrCBGradVertBegin] = color;
			rgbTable[KnownColors.msocbvcrCBGradVertMiddle] = color2;
			rgbTable[KnownColors.msocbvcrCBGradVertEnd] = color3;
			rgbTable[KnownColors.msocbvcrCBGradMouseDownBegin] = color5;
			rgbTable[KnownColors.msocbvcrCBGradMouseDownMiddle] = color5;
			rgbTable[KnownColors.msocbvcrCBGradMouseDownEnd] = color5;
			rgbTable[KnownColors.msocbvcrCBGradMenuTitleBkgdBegin] = color;
			rgbTable[KnownColors.msocbvcrCBGradMenuTitleBkgdEnd] = color2;
			rgbTable[KnownColors.msocbvcrCBIconDisabledDark] = buttonShadow;
			rgbTable[KnownColors.msocbvcrCBIconDisabledLight] = buttonFace;
			rgbTable[KnownColors.msocbvcrCBLabelBkgnd] = buttonShadow;
			rgbTable[KnownColors.msocbvcrCBLowColorIconDisabled] = empty;
			rgbTable[KnownColors.msocbvcrCBMainMenuBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrCBMenuCtlText] = windowText;
			rgbTable[KnownColors.msocbvcrCBMenuCtlTextDisabled] = grayText;
			rgbTable[KnownColors.msocbvcrCBMenuIconBkgd] = empty;
			rgbTable[KnownColors.msocbvcrCBMenuIconBkgdDropped] = buttonShadow;
			rgbTable[KnownColors.msocbvcrCBMenuShadow] = empty;
			rgbTable[KnownColors.msocbvcrCBMenuSplitArrow] = buttonShadow;
			rgbTable[KnownColors.msocbvcrCBOptionsButtonShadow] = empty;
			rgbTable[KnownColors.msocbvcrCBShadow] = rgbTable[KnownColors.msocbvcrCBBkgd];
			rgbTable[KnownColors.msocbvcrCBSplitterLineLight] = buttonHighlight;
			rgbTable[KnownColors.msocbvcrCBTearOffHandle] = empty;
			rgbTable[KnownColors.msocbvcrCBTearOffHandleMouseOver] = empty;
			rgbTable[KnownColors.msocbvcrCBTitleBkgd] = buttonShadow;
			rgbTable[KnownColors.msocbvcrCBTitleText] = buttonHighlight;
			rgbTable[KnownColors.msocbvcrDisabledFocuslessHighlightedText] = grayText;
			rgbTable[KnownColors.msocbvcrDisabledHighlightedText] = grayText;
			rgbTable[KnownColors.msocbvcrDlgGroupBoxText] = controlText;
			rgbTable[KnownColors.msocbvcrDocTabBdr] = buttonShadow;
			rgbTable[KnownColors.msocbvcrDocTabBdrDark] = buttonFace;
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseDown] = highlight;
			rgbTable[KnownColors.msocbvcrDocTabBdrDarkMouseOver] = SystemColors.MenuText;
			rgbTable[KnownColors.msocbvcrDocTabBdrLight] = buttonFace;
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseDown] = highlight;
			rgbTable[KnownColors.msocbvcrDocTabBdrLightMouseOver] = SystemColors.MenuText;
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseDown] = highlight;
			rgbTable[KnownColors.msocbvcrDocTabBdrMouseOver] = SystemColors.MenuText;
			rgbTable[KnownColors.msocbvcrDocTabBdrSelected] = buttonShadow;
			rgbTable[KnownColors.msocbvcrDocTabBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrDocTabBkgdMouseDown] = highlight;
			rgbTable[KnownColors.msocbvcrDocTabBkgdMouseOver] = highlight;
			rgbTable[KnownColors.msocbvcrDocTabBkgdSelected] = window;
			rgbTable[KnownColors.msocbvcrDocTabText] = controlText;
			rgbTable[KnownColors.msocbvcrDocTabTextMouseDown] = highlightText;
			rgbTable[KnownColors.msocbvcrDocTabTextMouseOver] = highlight;
			rgbTable[KnownColors.msocbvcrDocTabTextSelected] = windowText;
			rgbTable[KnownColors.msocbvcrDWActiveTabBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrDWActiveTabBkgd] = buttonShadow;
			rgbTable[KnownColors.msocbvcrDWActiveTabText] = buttonFace;
			rgbTable[KnownColors.msocbvcrDWActiveTabText] = controlText;
			rgbTable[KnownColors.msocbvcrDWActiveTabTextDisabled] = buttonShadow;
			rgbTable[KnownColors.msocbvcrDWActiveTabTextDisabled] = controlText;
			rgbTable[KnownColors.msocbvcrDWInactiveTabBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrDWInactiveTabBkgd] = buttonShadow;
			rgbTable[KnownColors.msocbvcrDWInactiveTabText] = buttonHighlight;
			rgbTable[KnownColors.msocbvcrDWInactiveTabText] = controlText;
			rgbTable[KnownColors.msocbvcrDWTabBkgdMouseDown] = buttonFace;
			rgbTable[KnownColors.msocbvcrDWTabBkgdMouseOver] = buttonFace;
			rgbTable[KnownColors.msocbvcrDWTabTextMouseDown] = controlText;
			rgbTable[KnownColors.msocbvcrDWTabTextMouseOver] = controlText;
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedBkgd] = SystemColors.InactiveCaption;
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedText] = controlText;
			rgbTable[KnownColors.msocbvcrFocuslessHighlightedText] = SystemColors.InactiveCaptionText;
			rgbTable[KnownColors.msocbvcrGDHeaderBdr] = highlight;
			rgbTable[KnownColors.msocbvcrGDHeaderBkgd] = window;
			rgbTable[KnownColors.msocbvcrGDHeaderCellBdr] = buttonShadow;
			rgbTable[KnownColors.msocbvcrGDHeaderCellBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrGDHeaderCellBkgdSelected] = empty;
			rgbTable[KnownColors.msocbvcrGDHeaderSeeThroughSelection] = highlight;
			rgbTable[KnownColors.msocbvcrGSPDarkBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrGSPDarkBkgd] = window;
			rgbTable[KnownColors.msocbvcrGSPGroupContentDarkBkgd] = window;
			rgbTable[KnownColors.msocbvcrGSPGroupContentLightBkgd] = window;
			rgbTable[KnownColors.msocbvcrGSPGroupContentText] = windowText;
			rgbTable[KnownColors.msocbvcrGSPGroupContentTextDisabled] = grayText;
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderDarkBkgd] = window;
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderLightBkgd] = window;
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderText] = controlText;
			rgbTable[KnownColors.msocbvcrGSPGroupHeaderText] = windowText;
			rgbTable[KnownColors.msocbvcrGSPGroupline] = buttonShadow;
			rgbTable[KnownColors.msocbvcrGSPGroupline] = window;
			rgbTable[KnownColors.msocbvcrGSPHyperlink] = empty;
			rgbTable[KnownColors.msocbvcrGSPLightBkgd] = window;
			rgbTable[KnownColors.msocbvcrHyperlink] = empty;
			rgbTable[KnownColors.msocbvcrHyperlinkFollowed] = empty;
			rgbTable[KnownColors.msocbvcrJotNavUIBdr] = buttonShadow;
			rgbTable[KnownColors.msocbvcrJotNavUIBdr] = windowText;
			rgbTable[KnownColors.msocbvcrJotNavUIGradBegin] = buttonFace;
			rgbTable[KnownColors.msocbvcrJotNavUIGradBegin] = window;
			rgbTable[KnownColors.msocbvcrJotNavUIGradEnd] = window;
			rgbTable[KnownColors.msocbvcrJotNavUIGradMiddle] = buttonFace;
			rgbTable[KnownColors.msocbvcrJotNavUIGradMiddle] = window;
			rgbTable[KnownColors.msocbvcrJotNavUIText] = windowText;
			rgbTable[KnownColors.msocbvcrListHeaderArrow] = controlText;
			rgbTable[KnownColors.msocbvcrNetLookBkgnd] = empty;
			rgbTable[KnownColors.msocbvcrOABBkgd] = buttonShadow;
			rgbTable[KnownColors.msocbvcrOBBkgdBdr] = buttonShadow;
			rgbTable[KnownColors.msocbvcrOBBkgdBdrContrast] = window;
			rgbTable[KnownColors.msocbvcrOGMDIParentWorkspaceBkgd] = buttonShadow;
			rgbTable[KnownColors.msocbvcrOGRulerActiveBkgd] = window;
			rgbTable[KnownColors.msocbvcrOGRulerBdr] = controlText;
			rgbTable[KnownColors.msocbvcrOGRulerBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrOGRulerInactiveBkgd] = buttonShadow;
			rgbTable[KnownColors.msocbvcrOGRulerTabBoxBdr] = buttonShadow;
			rgbTable[KnownColors.msocbvcrOGRulerTabBoxBdrHighlight] = buttonHighlight;
			rgbTable[KnownColors.msocbvcrOGRulerTabStopTicks] = buttonShadow;
			rgbTable[KnownColors.msocbvcrOGRulerText] = windowText;
			rgbTable[KnownColors.msocbvcrOGTaskPaneGroupBoxHeaderBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrOGWorkspaceBkgd] = buttonShadow;
			rgbTable[KnownColors.msocbvcrOLKFlagNone] = buttonHighlight;
			rgbTable[KnownColors.msocbvcrOLKFolderbarDark] = buttonShadow;
			rgbTable[KnownColors.msocbvcrOLKFolderbarLight] = buttonShadow;
			rgbTable[KnownColors.msocbvcrOLKFolderbarText] = window;
			rgbTable[KnownColors.msocbvcrOLKGridlines] = buttonShadow;
			rgbTable[KnownColors.msocbvcrOLKGroupLine] = buttonShadow;
			rgbTable[KnownColors.msocbvcrOLKGroupNested] = buttonFace;
			rgbTable[KnownColors.msocbvcrOLKGroupShaded] = buttonFace;
			rgbTable[KnownColors.msocbvcrOLKGroupText] = buttonShadow;
			rgbTable[KnownColors.msocbvcrOLKIconBar] = buttonFace;
			rgbTable[KnownColors.msocbvcrOLKInfoBarBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrOLKInfoBarText] = controlText;
			rgbTable[KnownColors.msocbvcrOLKPreviewPaneLabelText] = windowText;
			rgbTable[KnownColors.msocbvcrOLKTodayIndicatorDark] = highlight;
			rgbTable[KnownColors.msocbvcrOLKTodayIndicatorLight] = buttonFace;
			rgbTable[KnownColors.msocbvcrOLKWBActionDividerLine] = buttonShadow;
			rgbTable[KnownColors.msocbvcrOLKWBButtonDark] = buttonFace;
			rgbTable[KnownColors.msocbvcrOLKWBButtonLight] = buttonFace;
			rgbTable[KnownColors.msocbvcrOLKWBButtonLight] = buttonHighlight;
			rgbTable[KnownColors.msocbvcrOLKWBDarkOutline] = buttonShadow;
			rgbTable[KnownColors.msocbvcrOLKWBFoldersBackground] = window;
			rgbTable[KnownColors.msocbvcrOLKWBHoverButtonDark] = empty;
			rgbTable[KnownColors.msocbvcrOLKWBHoverButtonLight] = empty;
			rgbTable[KnownColors.msocbvcrOLKWBLabelText] = windowText;
			rgbTable[KnownColors.msocbvcrOLKWBPressedButtonDark] = empty;
			rgbTable[KnownColors.msocbvcrOLKWBPressedButtonLight] = empty;
			rgbTable[KnownColors.msocbvcrOLKWBSelectedButtonDark] = empty;
			rgbTable[KnownColors.msocbvcrOLKWBSelectedButtonLight] = empty;
			rgbTable[KnownColors.msocbvcrOLKWBSplitterDark] = buttonShadow;
			rgbTable[KnownColors.msocbvcrOLKWBSplitterLight] = buttonFace;
			rgbTable[KnownColors.msocbvcrOLKWBSplitterLight] = buttonShadow;
			rgbTable[KnownColors.msocbvcrPlacesBarBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabAreaBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabBdr] = buttonShadow;
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabInactiveBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrPPOutlineThumbnailsPaneTabText] = windowText;
			rgbTable[KnownColors.msocbvcrPPSlideBdrActiveSelected] = highlight;
			rgbTable[KnownColors.msocbvcrPPSlideBdrActiveSelectedMouseOver] = highlight;
			rgbTable[KnownColors.msocbvcrPPSlideBdrInactiveSelected] = grayText;
			rgbTable[KnownColors.msocbvcrPPSlideBdrMouseOver] = highlight;
			rgbTable[KnownColors.msocbvcrPubPrintDocScratchPageBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrPubWebDocScratchPageBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrSBBdr] = buttonShadow;
			rgbTable[KnownColors.msocbvcrScrollbarBkgd] = buttonShadow;
			rgbTable[KnownColors.msocbvcrToastGradBegin] = buttonFace;
			rgbTable[KnownColors.msocbvcrToastGradEnd] = buttonFace;
			rgbTable[KnownColors.msocbvcrWPBdrInnerDocked] = empty;
			rgbTable[KnownColors.msocbvcrWPBdrOuterDocked] = buttonFace;
			rgbTable[KnownColors.msocbvcrWPBdrOuterFloating] = buttonShadow;
			rgbTable[KnownColors.msocbvcrWPBkgd] = window;
			rgbTable[KnownColors.msocbvcrWPCtlBdr] = buttonShadow;
			rgbTable[KnownColors.msocbvcrWPCtlBdrDefault] = buttonShadow;
			rgbTable[KnownColors.msocbvcrWPCtlBdrDefault] = controlText;
			rgbTable[KnownColors.msocbvcrWPCtlBdrDisabled] = buttonShadow;
			rgbTable[KnownColors.msocbvcrWPCtlBkgd] = buttonFace;
			rgbTable[KnownColors.msocbvcrWPCtlBkgdDisabled] = buttonFace;
			rgbTable[KnownColors.msocbvcrWPCtlText] = controlText;
			rgbTable[KnownColors.msocbvcrWPCtlTextDisabled] = buttonShadow;
			rgbTable[KnownColors.msocbvcrWPCtlTextMouseDown] = highlightText;
			rgbTable[KnownColors.msocbvcrWPGroupline] = buttonShadow;
			rgbTable[KnownColors.msocbvcrWPInfoTipBkgd] = SystemColors.Info;
			rgbTable[KnownColors.msocbvcrWPInfoTipText] = SystemColors.InfoText;
			rgbTable[KnownColors.msocbvcrWPNavBarBkgnd] = buttonFace;
			rgbTable[KnownColors.msocbvcrWPText] = controlText;
			rgbTable[KnownColors.msocbvcrWPText] = windowText;
			rgbTable[KnownColors.msocbvcrWPTextDisabled] = grayText;
			rgbTable[KnownColors.msocbvcrWPTitleBkgdActive] = highlight;
			rgbTable[KnownColors.msocbvcrWPTitleBkgdInactive] = buttonFace;
			rgbTable[KnownColors.msocbvcrWPTitleTextActive] = highlightText;
			rgbTable[KnownColors.msocbvcrWPTitleTextInactive] = controlText;
			rgbTable[KnownColors.msocbvcrXLFormulaBarBkgd] = buttonFace;
		}

		internal void InitThemedColors(ref Hashtable rgbTable)
		{
			InitSystemColors(ref rgbTable);
			mblnUsingSystemColors = true;
			InitCommonColors(ref rgbTable);
		}

		private void ResetRGBTable()
		{
			if (mobjProfessionalRGB != null)
			{
				mobjProfessionalRGB.Clear();
			}
			mobjProfessionalRGB = null;
		}
	}
}
