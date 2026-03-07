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
	/// Specifies the display and layout information for text strings.</summary>
	[Flags]
	public enum TextFormatFlags
	{
		/// Aligns the text on the bottom of the bounding rectangle. Applied only when the text is a single line.</summary>
		Bottom = 8,
		/// Applies the default formatting, which is left-aligned.</summary>
		Default = 0,
		/// Removes the end of trimmed lines, and replaces them with an ellipsis.</summary>
		EndEllipsis = 0x8000,
		/// Expands tab characters. The default number of characters per tab is eight. The <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.WordEllipsis"></see>, <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.PathEllipsis"></see>, and <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.EndEllipsis"></see> values cannot be used with <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.ExpandTabs"></see>.</summary>
		ExpandTabs = 0x40,
		/// Includes the font external leading in line height. Typically, external leading is not included in the height of a line of text.</summary>
		ExternalLeading = 0x200,
		/// Adds padding to the bounding rectangle to accommodate overhanging glyphs. </summary>
		GlyphOverhangPadding = 0,
		/// Applies to Windows 2000 and Windows XP only: </summary>
		HidePrefix = 0x100000,
		/// Centers the text horizontally within the bounding rectangle.</summary>
		HorizontalCenter = 1,
		/// Uses the system font to calculate text metrics.</summary>
		Internal = 0x1000,
		/// Aligns the text on the left side of the clipping area.</summary>
		Left = 0,
		/// Adds padding to both sides of the bounding rectangle.</summary>
		LeftAndRightPadding = 0x20000000,
		/// Modifies the specified string to match the displayed text. This value has no effect unless <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.EndEllipsis"></see> or <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.PathEllipsis"></see> is also specified.</summary>
		ModifyString = 0x10000,
		/// Allows the overhanging parts of glyphs and unwrapped text reaching outside the formatting rectangle to show.</summary>
		NoClipping = 0x100,
		/// Applies to Windows 98, Windows Me, Windows 2000, or Windows XP only:</summary>
		NoFullWidthCharacterBreak = 0x80000,
		/// Does not add padding to the bounding rectangle.</summary>
		NoPadding = 0x10000000,
		/// Turns off processing of prefix characters. Typically, the ampersand (&amp;) mnemonic-prefix character is interpreted as a directive to underscore the character that follows, and the double-ampersand (&amp;&amp;) mnemonic-prefix characters as a directive to print a single ampersand. By specifying <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.NoPrefix"></see>, this processing is turned off. For example, an input string of "A&amp;bc&amp;&amp;d" with <see cref="F:Gizmox.WebGUI.Forms.TextFormatFlags.NoPrefix"></see> applied would result in output of "A&amp;bc&amp;&amp;d".</summary>
		NoPrefix = 0x800,
		/// Removes the center of trimmed lines and replaces it with an ellipsis. </summary>
		PathEllipsis = 0x4000,
		/// Applies to Windows 2000 or Windows XP only: </summary>
		PrefixOnly = 0x200000,
		/// Preserves the clipping specified by a <see cref="T:System.Drawing.Graphics"></see> object. Applies only to methods receiving an <see cref="T:System.Drawing.IDeviceContext"></see> that is a <see cref="T:System.Drawing.Graphics"></see>.</summary>
		PreserveGraphicsClipping = 0x1000000,
		/// Preserves the transformation specified by a <see cref="T:System.Drawing.Graphics"></see>. Applies only to methods receiving an <see cref="T:System.Drawing.IDeviceContext"></see> that is a <see cref="T:System.Drawing.Graphics"></see>.</summary>
		PreserveGraphicsTranslateTransform = 0x2000000,
		/// Aligns the text on the right side of the clipping area.</summary>
		Right = 2,
		/// Displays the text from right to left.</summary>
		RightToLeft = 0x20000,
		/// Displays the text in a single line.</summary>
		SingleLine = 0x20,
		/// Specifies the text should be formatted for display on a <see cref="T:Gizmox.WebGUI.Forms.TextBox"></see> control.</summary>
		TextBoxControl = 0x2000,
		/// Aligns the text on the top of the bounding rectangle.</summary>
		Top = 0,
		/// Centers the text vertically, within the bounding rectangle.</summary>
		VerticalCenter = 4,
		/// Breaks the text at the end of a word.</summary>
		WordBreak = 0x10,
		/// Trims the line to the nearest word and an ellipsis is placed at the end of a trimmed line.</summary>
		WordEllipsis = 0x40000
	}
}
