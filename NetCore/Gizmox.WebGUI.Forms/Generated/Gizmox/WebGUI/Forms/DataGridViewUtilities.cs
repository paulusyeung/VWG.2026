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

		internal static ContentAlignment ComputeDrawingContentAlignmentForCellStyleAlignment(DataGridViewContentAlignment enmAlignment)
		{
			return enmAlignment switch
			{
				DataGridViewContentAlignment.TopLeft => ContentAlignment.TopLeft, 
				DataGridViewContentAlignment.TopCenter => ContentAlignment.TopCenter, 
				DataGridViewContentAlignment.TopRight => ContentAlignment.TopRight, 
				DataGridViewContentAlignment.MiddleLeft => ContentAlignment.MiddleLeft, 
				DataGridViewContentAlignment.MiddleCenter => ContentAlignment.MiddleCenter, 
				DataGridViewContentAlignment.MiddleRight => ContentAlignment.MiddleRight, 
				DataGridViewContentAlignment.BottomLeft => ContentAlignment.BottomLeft, 
				DataGridViewContentAlignment.BottomCenter => ContentAlignment.BottomCenter, 
				DataGridViewContentAlignment.BottomRight => ContentAlignment.BottomRight, 
				_ => ContentAlignment.MiddleCenter, 
			};
		}

		internal static TextFormatFlags ComputeTextFormatFlagsForCellStyleAlignment(bool blnRightToLeft, DataGridViewContentAlignment enmAlignment, DataGridViewTriState enmWrapMode)
		{
			TextFormatFlags textFormatFlags;
			switch (enmAlignment)
			{
			case DataGridViewContentAlignment.BottomCenter:
				textFormatFlags = TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
				break;
			case DataGridViewContentAlignment.BottomRight:
				textFormatFlags = TextFormatFlags.Bottom;
				if (!blnRightToLeft)
				{
					textFormatFlags |= TextFormatFlags.Right;
				}
				break;
			case DataGridViewContentAlignment.MiddleRight:
				textFormatFlags = TextFormatFlags.VerticalCenter;
				if (!blnRightToLeft)
				{
					textFormatFlags |= TextFormatFlags.Right;
				}
				break;
			case DataGridViewContentAlignment.BottomLeft:
				textFormatFlags = TextFormatFlags.Bottom;
				if (blnRightToLeft)
				{
					textFormatFlags |= TextFormatFlags.Right;
				}
				break;
			case DataGridViewContentAlignment.TopLeft:
				textFormatFlags = TextFormatFlags.Default;
				if (blnRightToLeft)
				{
					textFormatFlags |= TextFormatFlags.Right;
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
				}
				break;
			case DataGridViewContentAlignment.MiddleLeft:
				textFormatFlags = TextFormatFlags.VerticalCenter;
				if (blnRightToLeft)
				{
					textFormatFlags |= TextFormatFlags.Right;
				}
				break;
			case DataGridViewContentAlignment.MiddleCenter:
				textFormatFlags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
				break;
			default:
				textFormatFlags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
				break;
			}
			textFormatFlags = ((enmWrapMode != DataGridViewTriState.False) ? (textFormatFlags | TextFormatFlags.WordBreak) : (textFormatFlags | TextFormatFlags.SingleLine));
			textFormatFlags |= TextFormatFlags.NoPrefix;
			textFormatFlags |= TextFormatFlags.PreserveGraphicsClipping;
			if (blnRightToLeft)
			{
				textFormatFlags |= TextFormatFlags.RightToLeft;
			}
			return textFormatFlags;
		}

		internal static Point GetTextLocation(Rectangle objCellBounds, Size objSizeText, TextFormatFlags enmFlags, DataGridViewCellStyle objCellStyle)
		{
			Point result = new Point(0, 0);
			DataGridViewContentAlignment dataGridViewContentAlignment = objCellStyle.Alignment;
			if ((enmFlags & TextFormatFlags.RightToLeft) != TextFormatFlags.Default)
			{
				switch (dataGridViewContentAlignment)
				{
				case DataGridViewContentAlignment.MiddleRight:
					dataGridViewContentAlignment = DataGridViewContentAlignment.MiddleLeft;
					break;
				case DataGridViewContentAlignment.BottomLeft:
					dataGridViewContentAlignment = DataGridViewContentAlignment.BottomRight;
					break;
				case DataGridViewContentAlignment.BottomRight:
					dataGridViewContentAlignment = DataGridViewContentAlignment.BottomLeft;
					break;
				case DataGridViewContentAlignment.TopLeft:
					dataGridViewContentAlignment = DataGridViewContentAlignment.TopRight;
					break;
				case DataGridViewContentAlignment.TopRight:
					dataGridViewContentAlignment = DataGridViewContentAlignment.TopLeft;
					break;
				case DataGridViewContentAlignment.MiddleLeft:
					dataGridViewContentAlignment = DataGridViewContentAlignment.MiddleRight;
					break;
				}
			}
			DataGridViewContentAlignment dataGridViewContentAlignment2 = dataGridViewContentAlignment;
			if (dataGridViewContentAlignment2 <= DataGridViewContentAlignment.MiddleCenter)
			{
				switch (dataGridViewContentAlignment2)
				{
				case DataGridViewContentAlignment.TopLeft:
					result.X = objCellBounds.X;
					result.Y = objCellBounds.Y;
					return result;
				case DataGridViewContentAlignment.TopCenter:
					result.X = objCellBounds.X + (objCellBounds.Width - objSizeText.Width) / 2;
					result.Y = objCellBounds.Y;
					return result;
				case (DataGridViewContentAlignment)3:
					return result;
				case DataGridViewContentAlignment.TopRight:
					result.X = objCellBounds.Right - objSizeText.Width;
					result.Y = objCellBounds.Y;
					return result;
				case DataGridViewContentAlignment.MiddleLeft:
					result.X = objCellBounds.X;
					result.Y = objCellBounds.Y + (objCellBounds.Height - objSizeText.Height) / 2;
					return result;
				case DataGridViewContentAlignment.MiddleCenter:
					result.X = objCellBounds.X + (objCellBounds.Width - objSizeText.Width) / 2;
					result.Y = objCellBounds.Y + (objCellBounds.Height - objSizeText.Height) / 2;
					return result;
				default:
					return result;
				}
			}
			if (dataGridViewContentAlignment2 <= DataGridViewContentAlignment.BottomLeft)
			{
				switch (dataGridViewContentAlignment2)
				{
				case DataGridViewContentAlignment.MiddleRight:
					result.X = objCellBounds.Right - objSizeText.Width;
					result.Y = objCellBounds.Y + (objCellBounds.Height - objSizeText.Height) / 2;
					return result;
				case DataGridViewContentAlignment.BottomLeft:
					result.X = objCellBounds.X;
					result.Y = objCellBounds.Bottom - objSizeText.Height;
					return result;
				default:
					return result;
				}
			}
			switch (dataGridViewContentAlignment2)
			{
			case DataGridViewContentAlignment.BottomCenter:
				result.X = objCellBounds.X + (objCellBounds.Width - objSizeText.Width) / 2;
				result.Y = objCellBounds.Bottom - objSizeText.Height;
				return result;
			case DataGridViewContentAlignment.BottomRight:
				result.X = objCellBounds.Right - objSizeText.Width;
				result.Y = objCellBounds.Bottom - objSizeText.Height;
				return result;
			default:
				return result;
			}
		}

		internal static bool ValidTextFormatFlags(TextFormatFlags enmFlags)
		{
			return (enmFlags & ~(TextFormatFlags.Bottom | TextFormatFlags.EndEllipsis | TextFormatFlags.ExpandTabs | TextFormatFlags.ExternalLeading | TextFormatFlags.HidePrefix | TextFormatFlags.HorizontalCenter | TextFormatFlags.Internal | TextFormatFlags.ModifyString | TextFormatFlags.NoClipping | TextFormatFlags.NoFullWidthCharacterBreak | TextFormatFlags.NoPrefix | TextFormatFlags.PathEllipsis | TextFormatFlags.PrefixOnly | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.PreserveGraphicsTranslateTransform | TextFormatFlags.Right | TextFormatFlags.RightToLeft | TextFormatFlags.SingleLine | TextFormatFlags.TextBoxControl | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak | TextFormatFlags.WordEllipsis)) == 0;
		}
	}
}
