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
/// Provides <see cref="T:System.Drawing.Color"></see> structures that are colors of a Windows display element. This class cannot be inherited. </summary>
	[Serializable]
	public sealed class ProfessionalColors
	{
		private static string mstrColorScheme;

		private static ProfessionalColorTable professionalColorTable;

		/// Gets the starting color of the gradient used when the button is checked.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the gradient used when the button is checked.</returns>
		[SRDescription("ProfessionalColorsButtonCheckedGradientBeginDescr")]
		public static Color ButtonCheckedGradientBegin => ColorTable.ButtonCheckedGradientBegin;

		/// Gets the end color of the gradient used when the button is checked.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the button is checked.</returns>
		[SRDescription("ProfessionalColorsButtonCheckedGradientEndDescr")]
		public static Color ButtonCheckedGradientEnd => ColorTable.ButtonCheckedGradientEnd;

		/// Gets the middle color of the gradient used when the button is checked.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when the button is checked.</returns>
		[SRDescription("ProfessionalColorsButtonCheckedGradientMiddleDescr")]
		public static Color ButtonCheckedGradientMiddle => ColorTable.ButtonCheckedGradientMiddle;

		/// Gets the solid color used when the button is checked.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid color used when the button is checked.</returns>
		[SRDescription("ProfessionalColorsButtonCheckedHighlightDescr")]
		public static Color ButtonCheckedHighlight => ColorTable.ButtonCheckedHighlight;

		/// Gets the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonCheckedHighlight"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonCheckedHighlight"></see>.</returns>
		[SRDescription("ProfessionalColorsButtonCheckedHighlightBorderDescr")]
		public static Color ButtonCheckedHighlightBorder => ColorTable.ButtonCheckedHighlightBorder;

		/// Gets the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientEnd"></see> colors.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedGradientEnd"></see> colors.</returns>
		[SRDescription("ProfessionalColorsButtonPressedBorderDescr")]
		public static Color ButtonPressedBorder => ColorTable.ButtonPressedBorder;

		/// Gets the starting color of the gradient used when the button is pressed down.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the button is pressed down.</returns>
		[SRDescription("ProfessionalColorsButtonPressedGradientBeginDescr")]
		public static Color ButtonPressedGradientBegin => ColorTable.ButtonPressedGradientBegin;

		/// Gets the end color of the gradient used when the button is pressed down.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the button is pressed down.</returns>
		[SRDescription("ProfessionalColorsButtonPressedGradientEndDescr")]
		public static Color ButtonPressedGradientEnd => ColorTable.ButtonPressedGradientEnd;

		/// Gets the middle color of the gradient used when the button is pressed down.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when the button is pressed.</returns>
		[SRDescription("ProfessionalColorsButtonPressedGradientMiddleDescr")]
		public static Color ButtonPressedGradientMiddle => ColorTable.ButtonPressedGradientMiddle;

		/// Gets the solid color used when the button is pressed down.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid color used when the button is pressed down.</returns>
		[SRDescription("ProfessionalColorsButtonPressedHighlightDescr")]
		public static Color ButtonPressedHighlight => ColorTable.ButtonPressedHighlight;

		/// Gets the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedHighlight"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonPressedHighlight"></see>.</returns>
		[SRDescription("ProfessionalColorsButtonPressedHighlightBorderDescr")]
		public static Color ButtonPressedHighlightBorder => ColorTable.ButtonPressedHighlightBorder;

		/// Gets the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientEnd"></see> colors.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color to use with the <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientBegin"></see>, <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientMiddle"></see>, and <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedGradientEnd"></see> colors.</returns>
		[SRDescription("ProfessionalColorsButtonSelectedBorderDescr")]
		public static Color ButtonSelectedBorder => ColorTable.ButtonCheckedGradientBegin;

		/// Gets the starting color of the gradient used when the button is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the button is selected.</returns>
		[SRDescription("ProfessionalColorsButtonSelectedGradientBeginDescr")]
		public static Color ButtonSelectedGradientBegin => ColorTable.ButtonSelectedGradientBegin;

		/// Gets the end color of the gradient used when the button is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the button is selected.</returns>
		[SRDescription("ProfessionalColorsButtonSelectedGradientEndDescr")]
		public static Color ButtonSelectedGradientEnd => ColorTable.ButtonSelectedGradientEnd;

		/// Gets the middle color of the gradient used when the button is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when the button is selected.</returns>
		[SRDescription("ProfessionalColorsButtonSelectedGradientMiddleDescr")]
		public static Color ButtonSelectedGradientMiddle => ColorTable.ButtonSelectedGradientMiddle;

		/// Gets the solid color used when the button is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid color used when the button is selected.</returns>
		[SRDescription("ProfessionalColorsButtonSelectedHighlightDescr")]
		public static Color ButtonSelectedHighlight => ColorTable.ButtonSelectedHighlight;

		/// Gets the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedHighlight"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color to use with <see cref="P:Gizmox.WebGUI.Forms.ProfessionalColors.ButtonSelectedHighlight"></see>.</returns>
		[SRDescription("ProfessionalColorsButtonSelectedHighlightBorderDescr")]
		public static Color ButtonSelectedHighlightBorder => ColorTable.ButtonSelectedHighlightBorder;

		/// Gets the solid color to use when the check box is selected and gradients are being used.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when the check box is selected and gradients are being used.</returns>
		[SRDescription("ProfessionalColorsCheckBackgroundDescr")]
		public static Color CheckBackground => ColorTable.CheckBackground;

		/// Gets the solid color to use when the check box is selected and gradients are being used.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when the check box is selected and gradients are being used.</returns>
		[SRDescription("ProfessionalColorsCheckPressedBackgroundDescr")]
		public static Color CheckPressedBackground => ColorTable.CheckPressedBackground;

		/// Gets the solid color to use when the check box is selected and gradients are being used.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when the check box is selected and gradients are being used.</returns>
		[SRDescription("ProfessionalColorsCheckSelectedBackgroundDescr")]
		public static Color CheckSelectedBackground => ColorTable.CheckSelectedBackground;

		internal static string ColorScheme => mstrColorScheme;

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

		/// Gets the color to use for shadow effects on the grip or move handle.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the color to use for shadow effects on the grip or move handle.</returns>
		[SRDescription("ProfessionalColorsGripDarkDescr")]
		public static Color GripDark => ColorTable.GripDark;

		/// Gets the color to use for highlight effects on the grip or move handle.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the color to use for highlight effects on the grip or move handle.</returns>
		[SRDescription("ProfessionalColorsGripLightDescr")]
		public static Color GripLight => ColorTable.GripLight;

		/// Gets the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</returns>
		[SRDescription("ProfessionalColorsImageMarginGradientBeginDescr")]
		public static Color ImageMarginGradientBegin => ColorTable.ImageMarginGradientBegin;

		/// Gets the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</returns>
		[SRDescription("ProfessionalColorsImageMarginGradientEndDescr")]
		public static Color ImageMarginGradientEnd => ColorTable.ImageMarginGradientEnd;

		/// Gets the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see>.</returns>
		[SRDescription("ProfessionalColorsImageMarginGradientMiddleDescr")]
		public static Color ImageMarginGradientMiddle => ColorTable.ImageMarginGradientMiddle;

		/// Gets the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</returns>
		[SRDescription("ProfessionalColorsImageMarginRevealedGradientBeginDescr")]
		public static Color ImageMarginRevealedGradientBegin => ColorTable.ImageMarginRevealedGradientBegin;

		/// Gets the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</returns>
		[SRDescription("ProfessionalColorsImageMarginRevealedGradientEndDescr")]
		public static Color ImageMarginRevealedGradientEnd => ColorTable.ImageMarginRevealedGradientEnd;

		/// Gets the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the image margin of a <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDownMenu"></see> when an item is revealed.</returns>
		[SRDescription("ProfessionalColorsImageMarginRevealedGradientMiddleDescr")]
		public static Color ImageMarginRevealedGradientMiddle => ColorTable.ImageMarginRevealedGradientMiddle;

		/// Gets the border color or a <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color or a <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</returns>
		[SRDescription("ProfessionalColorsMenuBorderDescr")]
		public static Color MenuBorder => ColorTable.MenuBorder;

		/// Gets the border color to use with a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color to use with a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see>.</returns>
		[SRDescription("ProfessionalColorsMenuItemBorderDescr")]
		public static Color MenuItemBorder => ColorTable.MenuItemBorder;

		/// Gets the starting color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</returns>
		[SRDescription("ProfessionalColorsMenuItemPressedGradientBeginDescr")]
		public static Color MenuItemPressedGradientBegin => ColorTable.MenuItemPressedGradientBegin;

		/// Gets the end color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</returns>
		[SRDescription("ProfessionalColorsMenuItemPressedGradientEndDescr")]
		public static Color MenuItemPressedGradientEnd => ColorTable.MenuItemPressedGradientEnd;

		/// Gets the middle color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used when a top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is pressed down.</returns>
		[SRDescription("ProfessionalColorsMenuItemPressedGradientMiddleDescr")]
		public static Color MenuItemPressedGradientMiddle => ColorTable.MenuItemPressedGradientMiddle;

		/// Gets the solid color to use when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> other than the top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid color to use when a <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> other than the top-level <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</returns>
		[SRDescription("ProfessionalColorsMenuItemSelectedDescr")]
		public static Color MenuItemSelected => ColorTable.MenuItemBorder;

		/// Gets the starting color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</returns>
		[SRDescription("ProfessionalColorsMenuItemSelectedGradientBeginDescr")]
		public static Color MenuItemSelectedGradientBegin => ColorTable.MenuItemSelectedGradientBegin;

		/// Gets the end color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used when the <see cref="T:Gizmox.WebGUI.Forms.ToolStripMenuItem"></see> is selected.</returns>
		[SRDescription("ProfessionalColorsMenuItemSelectedGradientEndDescr")]
		public static Color MenuItemSelectedGradientEnd => ColorTable.MenuItemSelectedGradientEnd;

		/// Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</returns>
		[SRDescription("ProfessionalColorsMenuStripGradientBeginDescr")]
		public static Color MenuStripGradientBegin => ColorTable.MenuStripGradientBegin;

		/// Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.MenuStrip"></see>.</returns>
		[SRDescription("ProfessionalColorsMenuStripGradientEndDescr")]
		public static Color MenuStripGradientEnd => ColorTable.MenuStripGradientEnd;

		/// Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</returns>
		[SRDescription("ProfessionalColorsOverflowButtonGradientBeginDescr")]
		public static Color OverflowButtonGradientBegin => ColorTable.OverflowButtonGradientBegin;

		/// Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</returns>
		[SRDescription("ProfessionalColorsOverflowButtonGradientEndDescr")]
		public static Color OverflowButtonGradientEnd => ColorTable.OverflowButtonGradientEnd;

		/// Gets the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripOverflowButton"></see>.</returns>
		[SRDescription("ProfessionalColorsOverflowButtonGradientMiddleDescr")]
		public static Color OverflowButtonGradientMiddle => ColorTable.OverflowButtonGradientMiddle;

		/// Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</returns>
		[SRDescription("ProfessionalColorsRaftingContainerGradientBeginDescr")]
		public static Color RaftingContainerGradientBegin => ColorTable.RaftingContainerGradientBegin;

		/// Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContainer"></see>.</returns>
		[SRDescription("ProfessionalColorsRaftingContainerGradientEndDescr")]
		public static Color RaftingContainerGradientEnd => ColorTable.RaftingContainerGradientEnd;

		/// Gets the color to use to for shadow effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the color to use to for shadow effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</returns>
		[SRDescription("ProfessionalColorsSeparatorDarkDescr")]
		public static Color SeparatorDark => ColorTable.SeparatorDark;

		/// Gets the color to use to for highlight effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the color to use to create highlight effects on the <see cref="T:Gizmox.WebGUI.Forms.ToolStripSeparator"></see>.</returns>
		[SRDescription("ProfessionalColorsSeparatorLightDescr")]
		public static Color SeparatorLight => ColorTable.SeparatorLight;

		/// Gets the starting color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</returns>
		[SRDescription("ProfessionalColorsStatusStripGradientBeginDescr")]
		public static Color StatusStripGradientBegin => ColorTable.StatusStripGradientBegin;

		/// Gets the end color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used on the <see cref="T:Gizmox.WebGUI.Forms.StatusStrip"></see>.</returns>
		[SRDescription("ProfessionalColorsStatusStripGradientEndDescr")]
		public static Color StatusStripGradientEnd => ColorTable.StatusStripGradientEnd;

		/// Gets the border color to use on the bottom edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the border color to use on the bottom edge of the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see>.</returns>
		[SRDescription("ProfessionalColorsToolStripBorderDescr")]
		public static Color ToolStripBorder => ColorTable.ToolStripBorder;

		/// Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</returns>
		[SRDescription("ProfessionalColorsToolStripContentPanelGradientBeginDescr")]
		public static Color ToolStripContentPanelGradientBegin => ColorTable.ToolStripContentPanelGradientBegin;

		/// Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripContentPanel"></see>.</returns>
		[SRDescription("ProfessionalColorsToolStripContentPanelGradientEndDescr")]
		public static Color ToolStripContentPanelGradientEnd => ColorTable.ToolStripContentPanelGradientEnd;

		/// Gets the solid background color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the solid background color of the <see cref="T:Gizmox.WebGUI.Forms.ToolStripDropDown"></see>.</returns>
		[SRDescription("ProfessionalColorsToolStripDropDownBackgroundDescr")]
		public static Color ToolStripDropDownBackground => ColorTable.ToolStripDropDownBackground;

		/// Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</returns>
		[SRDescription("ProfessionalColorsToolStripGradientBeginDescr")]
		public static Color ToolStripGradientBegin => ColorTable.ToolStripGradientBegin;

		/// Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</returns>
		[SRDescription("ProfessionalColorsToolStripGradientEndDescr")]
		public static Color ToolStripGradientEnd => ColorTable.ToolStripGradientEnd;

		/// Gets the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the middle color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStrip"></see> background.</returns>
		[SRDescription("ProfessionalColorsToolStripGradientMiddleDescr")]
		public static Color ToolStripGradientMiddle => ColorTable.ToolStripGradientMiddle;

		/// Gets the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the starting color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</returns>
		[SRDescription("ProfessionalColorsToolStripPanelGradientBeginDescr")]
		public static Color ToolStripPanelGradientBegin => ColorTable.ToolStripPanelGradientBegin;

		/// Gets the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</summary>
		/// A <see cref="T:System.Drawing.Color"></see> that is the end color of the gradient used in the <see cref="T:Gizmox.WebGUI.Forms.ToolStripPanel"></see>.</returns>
		[SRDescription("ProfessionalColorsToolStripPanelGradientEndDescr")]
		public static Color ToolStripPanelGradientEnd => ColorTable.ToolStripPanelGradientEnd;

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
	}
}
