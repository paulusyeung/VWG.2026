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

namespace Gizmox.WebGUI.Forms.Layout
{
	[Serializable]
	internal class LayoutUtils
	{
		[Serializable]
		public sealed class MeasureTextCache
		{
			[Serializable]
			private struct PreferredSizeCache
			{
				public Size mobjConstrainingSize;

				public Size mobjPreferredSize;

				public PreferredSizeCache(Size objConstrainingSize, Size objPreferredSize)
				{
					mobjConstrainingSize = objConstrainingSize;
					mobjPreferredSize = objPreferredSize;
				}
			}

			private const int mcntMaxCacheSize = 6;

			private int mintNextCacheEntry = -1;

			private PreferredSizeCache[] marrSizeCacheList;

			private Size mobjUnconstrainedPreferredSize = InvalidSize;

			public Size GetTextSize(string strText, Font objFont, Size objProposedConstraints, TextFormatFlags enmFlags)
			{
				if (!TextRequiresWordBreak(strText, objFont, objProposedConstraints, enmFlags))
				{
					return mobjUnconstrainedPreferredSize;
				}
				if (marrSizeCacheList == null)
				{
					marrSizeCacheList = new PreferredSizeCache[6];
				}
				PreferredSizeCache[] array = marrSizeCacheList;
				for (int i = 0; i < array.Length; i++)
				{
					PreferredSizeCache preferredSizeCache = array[i];
					if (preferredSizeCache.mobjConstrainingSize == objProposedConstraints)
					{
						return preferredSizeCache.mobjPreferredSize;
					}
					Size mobjConstrainingSize = preferredSizeCache.mobjConstrainingSize;
					if (mobjConstrainingSize.Width == objProposedConstraints.Width)
					{
						mobjConstrainingSize = preferredSizeCache.mobjPreferredSize;
						if (mobjConstrainingSize.Height <= objProposedConstraints.Height)
						{
							return preferredSizeCache.mobjPreferredSize;
						}
					}
				}
				Size stringMeasurements = CommonUtils.GetStringMeasurements(strText, objFont);
				mintNextCacheEntry = (mintNextCacheEntry + 1) % 6;
				marrSizeCacheList[mintNextCacheEntry] = new PreferredSizeCache(objProposedConstraints, stringMeasurements);
				return stringMeasurements;
			}

			private Size GetUnconstrainedSize(string strText, Font objFont, TextFormatFlags enmFlags)
			{
				if (mobjUnconstrainedPreferredSize == InvalidSize)
				{
					enmFlags &= ~TextFormatFlags.WordBreak;
					mobjUnconstrainedPreferredSize = CommonUtils.GetStringMeasurements(strText, objFont);
				}
				return mobjUnconstrainedPreferredSize;
			}

			public void InvalidateCache()
			{
				mobjUnconstrainedPreferredSize = InvalidSize;
				marrSizeCacheList = null;
			}

			public bool TextRequiresWordBreak(string strText, Font objFont, Size objSize, TextFormatFlags enmFlags)
			{
				return GetUnconstrainedSize(strText, objFont, enmFlags).Width > objSize.Width;
			}
		}

		public const ContentAlignment AnyBottom = (ContentAlignment)1792;

		public const ContentAlignment AnyCenter = (ContentAlignment)546;

		public const ContentAlignment AnyLeft = (ContentAlignment)273;

		public const ContentAlignment AnyMiddle = (ContentAlignment)112;

		public const ContentAlignment AnyRight = (ContentAlignment)1092;

		public const ContentAlignment AnyTop = (ContentAlignment)7;

		private static readonly AnchorStyles[] marrDockingToAnchor = new AnchorStyles[6]
		{
			AnchorStyles.Left | AnchorStyles.Top,
			AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
			AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
			AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top,
			AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top,
			AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top
		};

		public const AnchorStyles HorizontalAnchorStyles = AnchorStyles.Left | AnchorStyles.Right;

		public static readonly Size InvalidSize = new Size(int.MinValue, int.MinValue);

		public static readonly Rectangle MaxRectangle = new Rectangle(0, 0, int.MaxValue, int.MaxValue);

		public static readonly Size MaxSize = new Size(int.MaxValue, int.MaxValue);

		public static readonly string TestString = "j^";

		public const AnchorStyles VerticalAnchorStyles = AnchorStyles.Bottom | AnchorStyles.Top;

		public static Size AddAlignedRegion(Size objTextSize, Size objImageSize, TextImageRelation enmRelation)
		{
			return AddAlignedRegionCore(objTextSize, objImageSize, IsVerticalRelation(enmRelation));
		}

		public static Size AddAlignedRegionCore(Size objCurrentSize, Size objContentSize, bool blnVertical)
		{
			if (blnVertical)
			{
				objCurrentSize.Width = Math.Max(objCurrentSize.Width, objContentSize.Width);
				objCurrentSize.Height += objContentSize.Height;
				return objCurrentSize;
			}
			objCurrentSize.Width += objContentSize.Width;
			objCurrentSize.Height = Math.Max(objCurrentSize.Height, objContentSize.Height);
			return objCurrentSize;
		}

		public static Rectangle Align(Size objAlignThis, Rectangle objWithinThis, ContentAlignment enmAlign)
		{
			return VAlign(objAlignThis, HAlign(objAlignThis, objWithinThis, enmAlign), enmAlign);
		}

		public static Rectangle Align(Size objAlignThis, Rectangle objWithinThis, AnchorStyles enmAnchorStyles)
		{
			return VAlign(objAlignThis, HAlign(objAlignThis, objWithinThis, enmAnchorStyles), enmAnchorStyles);
		}

		public static Rectangle AlignAndStretch(Size objFitThis, Rectangle objWithinThis, AnchorStyles enmAnchorStyles)
		{
			return Align(Stretch(objFitThis, objWithinThis.Size, enmAnchorStyles), objWithinThis, enmAnchorStyles);
		}

		public static bool AreWidthAndHeightLarger(Size objSize1, Size objSize2)
		{
			if (objSize1.Width >= objSize2.Width)
			{
				return objSize1.Height >= objSize2.Height;
			}
			return false;
		}

		public static Padding ClampNegativePaddingToZero(Padding objPadding)
		{
			if (objPadding.All < 0)
			{
				objPadding.Left = Math.Max(0, objPadding.Left);
				objPadding.Top = Math.Max(0, objPadding.Top);
				objPadding.Right = Math.Max(0, objPadding.Right);
				objPadding.Bottom = Math.Max(0, objPadding.Bottom);
			}
			return objPadding;
		}

		public static int ContentAlignmentToIndex(ContentAlignment enmAlignment)
		{
			int num = xContentAlignmentToIndex((int)(enmAlignment & (ContentAlignment)15));
			int num2 = xContentAlignmentToIndex(((int)enmAlignment >> 4) & 0xF);
			int num3 = xContentAlignmentToIndex(((int)enmAlignment >> 8) & 0xF);
			int num4 = ((num2 != 0) ? 4 : 0) | ((num3 != 0) ? 8 : 0) | num | num2 | num3;
			return num4 - 1;
		}

		public static Size ConvertZeroToUnbounded(Size objSize)
		{
			if (objSize.Width == 0)
			{
				objSize.Width = int.MaxValue;
			}
			if (objSize.Height == 0)
			{
				objSize.Height = int.MaxValue;
			}
			return objSize;
		}

		public static Rectangle DeflateRect(Rectangle objRect, Padding objPadding)
		{
			objRect.X += objPadding.Left;
			objRect.Y += objPadding.Top;
			objRect.Width -= objPadding.Horizontal;
			objRect.Height -= objPadding.Vertical;
			return objRect;
		}

		public static void ExpandRegionsToFillBounds(Rectangle objBounds, AnchorStyles enmRegion1Align, ref Rectangle objRegion1, ref Rectangle objRegion2)
		{
			switch (enmRegion1Align)
			{
			case AnchorStyles.Top:
				objRegion1 = SubstituteSpecifiedBounds(objBounds, objRegion1, AnchorStyles.Bottom);
				objRegion2 = SubstituteSpecifiedBounds(objBounds, objRegion2, AnchorStyles.Top);
				break;
			case AnchorStyles.Bottom:
				objRegion1 = SubstituteSpecifiedBounds(objBounds, objRegion1, AnchorStyles.Top);
				objRegion2 = SubstituteSpecifiedBounds(objBounds, objRegion2, AnchorStyles.Bottom);
				break;
			case AnchorStyles.Bottom | AnchorStyles.Top:
				break;
			case AnchorStyles.Left:
				objRegion1 = SubstituteSpecifiedBounds(objBounds, objRegion1, AnchorStyles.Right);
				objRegion2 = SubstituteSpecifiedBounds(objBounds, objRegion2, AnchorStyles.Left);
				break;
			case AnchorStyles.Right:
				objRegion1 = SubstituteSpecifiedBounds(objBounds, objRegion1, AnchorStyles.Left);
				objRegion2 = SubstituteSpecifiedBounds(objBounds, objRegion2, AnchorStyles.Right);
				break;
			case AnchorStyles.Left | AnchorStyles.Top:
			case AnchorStyles.Bottom | AnchorStyles.Left:
			case AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top:
				break;
			}
		}

		public static Padding FlipPadding(Padding objPadding)
		{
			if (objPadding.All == -1)
			{
				int top = objPadding.Top;
				objPadding.Top = objPadding.Left;
				objPadding.Left = top;
				top = objPadding.Bottom;
				objPadding.Bottom = objPadding.Right;
				objPadding.Right = top;
			}
			return objPadding;
		}

		public static Point FlipPoint(Point objPoint)
		{
			int x = objPoint.X;
			objPoint.X = objPoint.Y;
			objPoint.Y = x;
			return objPoint;
		}

		public static Rectangle FlipRectangle(Rectangle objRect)
		{
			objRect.Location = FlipPoint(objRect.Location);
			objRect.Size = FlipSize(objRect.Size);
			return objRect;
		}

		public static Rectangle FlipRectangleIf(bool blnCondition, Rectangle objRect)
		{
			if (!blnCondition)
			{
				return objRect;
			}
			return FlipRectangle(objRect);
		}

		public static Size FlipSize(Size objSize)
		{
			int width = objSize.Width;
			objSize.Width = objSize.Height;
			objSize.Height = width;
			return objSize;
		}

		public static Size FlipSizeIf(bool blnCondition, Size objSize)
		{
			if (!blnCondition)
			{
				return objSize;
			}
			return FlipSize(objSize);
		}

		private static AnchorStyles GetOppositeAnchor(AnchorStyles enmAnchor)
		{
			return AnchorStyles.None;
		}

		public static TextImageRelation GetOppositeTextImageRelation(TextImageRelation enmRelation)
		{
			return TextImageRelation.Overlay;
		}

		internal static AnchorStyles GetUnifiedAnchor(IArrangedElement objElement)
		{
			return AnchorStyles.Left | AnchorStyles.Top;
		}

		private static Rectangle HAlign(Size objAlignThis, Rectangle objWithinThis, ContentAlignment enmAlign)
		{
			if ((enmAlign & (ContentAlignment)1092) != 0)
			{
				objWithinThis.X += objWithinThis.Width - objAlignThis.Width;
			}
			else if ((enmAlign & (ContentAlignment)546) != 0)
			{
				objWithinThis.X += (objWithinThis.Width - objAlignThis.Width) / 2;
			}
			objWithinThis.Width = objAlignThis.Width;
			return objWithinThis;
		}

		public static Rectangle HAlign(Size objAlignThis, Rectangle objWithinThis, AnchorStyles enmAnchorStyles)
		{
			if ((enmAnchorStyles & AnchorStyles.Right) != AnchorStyles.None)
			{
				objWithinThis.X += objWithinThis.Width - objAlignThis.Width;
			}
			else if (enmAnchorStyles == AnchorStyles.None || (enmAnchorStyles & (AnchorStyles.Left | AnchorStyles.Right)) == 0)
			{
				objWithinThis.X += (objWithinThis.Width - objAlignThis.Width) / 2;
			}
			objWithinThis.Width = objAlignThis.Width;
			return objWithinThis;
		}

		public static Rectangle InflateRect(Rectangle objRect, Padding objPadding)
		{
			objRect.X -= objPadding.Left;
			objRect.Y -= objPadding.Top;
			objRect.Width += objPadding.Horizontal;
			objRect.Height += objPadding.Vertical;
			return objRect;
		}

		public static Size IntersectSizes(Size objA, Size objB)
		{
			return new Size(Math.Min(objA.Width, objB.Width), Math.Min(objA.Height, objB.Height));
		}

		public static bool IsHorizontalAlignment(ContentAlignment enmAlign)
		{
			return !IsVerticalAlignment(enmAlign);
		}

		public static bool IsHorizontalRelation(TextImageRelation enmRelation)
		{
			return (enmRelation & (TextImageRelation)12) != 0;
		}

		public static bool IsIntersectHorizontally(Rectangle objRect1, Rectangle objRect2)
		{
			if (!objRect1.IntersectsWith(objRect2))
			{
				return false;
			}
			return (objRect1.X <= objRect2.X && objRect1.X + objRect1.Width >= objRect2.X + objRect2.Width) || (objRect2.X <= objRect1.X && objRect2.X + objRect2.Width >= objRect1.X + objRect1.Width);
		}

		public static bool IsIntersectVertically(Rectangle objRect1, Rectangle objRect2)
		{
			if (!objRect1.IntersectsWith(objRect2))
			{
				return false;
			}
			return (objRect1.Y <= objRect2.Y && objRect1.Y + objRect1.Width >= objRect2.Y + objRect2.Width) || (objRect2.Y <= objRect1.Y && objRect2.Y + objRect2.Width >= objRect1.Y + objRect1.Width);
		}

		public static bool IsVerticalAlignment(ContentAlignment enmAlign)
		{
			return (enmAlign & (ContentAlignment)514) != 0;
		}

		public static bool IsVerticalRelation(TextImageRelation enmRelation)
		{
			return (enmRelation & (TextImageRelation)3) != 0;
		}

		public static bool IsZeroWidthOrHeight(Rectangle objRectangle)
		{
			if (objRectangle.Width != 0)
			{
				return objRectangle.Height == 0;
			}
			return true;
		}

		public static bool IsZeroWidthOrHeight(Size objSize)
		{
			if (objSize.Width != 0)
			{
				return objSize.Height == 0;
			}
			return true;
		}

		public static Size OldGetLargestStringSizeInCollection(Font objFont, ICollection objCollection)
		{
			Size empty = Size.Empty;
			if (objCollection != null)
			{
				foreach (object item in objCollection)
				{
					Size stringMeasurements = CommonUtils.GetStringMeasurements(item.ToString(), objFont);
					empty.Width = Math.Max(empty.Width, stringMeasurements.Width);
					empty.Height = Math.Max(empty.Height, stringMeasurements.Height);
				}
			}
			return empty;
		}

		public static Rectangle RTLTranslate(Rectangle objBounds, Rectangle objWithinBounds)
		{
			objBounds.X = objWithinBounds.Width - objBounds.Right;
			return objBounds;
		}

		public static void SplitRegion(Rectangle objBounds, Size objSpecifiedContent, AnchorStyles enmRegion1Align, out Rectangle objRegion1, out Rectangle objRegion2)
		{
			objRegion1 = (objRegion2 = objBounds);
			switch (enmRegion1Align)
			{
			case AnchorStyles.Top:
				objRegion1.Height = objSpecifiedContent.Height;
				objRegion2.Y += objSpecifiedContent.Height;
				objRegion2.Height -= objSpecifiedContent.Height;
				break;
			case AnchorStyles.Bottom:
				objRegion1.Y += objBounds.Height - objSpecifiedContent.Height;
				objRegion1.Height = objSpecifiedContent.Height;
				objRegion2.Height -= objSpecifiedContent.Height;
				break;
			case AnchorStyles.Bottom | AnchorStyles.Top:
				break;
			case AnchorStyles.Left:
				objRegion1.Width = objSpecifiedContent.Width;
				objRegion2.X += objSpecifiedContent.Width;
				objRegion2.Width -= objSpecifiedContent.Width;
				break;
			case AnchorStyles.Right:
				objRegion1.X += objBounds.Width - objSpecifiedContent.Width;
				objRegion1.Width = objSpecifiedContent.Width;
				objRegion2.Width -= objSpecifiedContent.Width;
				break;
			case AnchorStyles.Left | AnchorStyles.Top:
			case AnchorStyles.Bottom | AnchorStyles.Left:
			case AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top:
				break;
			}
		}

		public static Size Stretch(Size objStretchThis, Size objWithinThis, AnchorStyles enmAnchorStyles)
		{
			Size result = new Size(((enmAnchorStyles & (AnchorStyles.Left | AnchorStyles.Right)) == (AnchorStyles.Left | AnchorStyles.Right)) ? objWithinThis.Width : objStretchThis.Width, ((enmAnchorStyles & (AnchorStyles.Bottom | AnchorStyles.Top)) == (AnchorStyles.Bottom | AnchorStyles.Top)) ? objWithinThis.Height : objStretchThis.Height);
			if (result.Width > objWithinThis.Width)
			{
				result.Width = objWithinThis.Width;
			}
			if (result.Height > objWithinThis.Height)
			{
				result.Height = objWithinThis.Height;
			}
			return result;
		}

		public static Size SubAlignedRegion(Size objCurrentSize, Size objContentSize, TextImageRelation enmRelation)
		{
			return SubAlignedRegionCore(objCurrentSize, objContentSize, IsVerticalRelation(enmRelation));
		}

		public static Size SubAlignedRegionCore(Size objCurrentSize, Size objContentSize, bool blnVertical)
		{
			if (blnVertical)
			{
				objCurrentSize.Height -= objContentSize.Height;
				return objCurrentSize;
			}
			objCurrentSize.Width -= objContentSize.Width;
			return objCurrentSize;
		}

		private static Rectangle SubstituteSpecifiedBounds(Rectangle objOriginalBounds, Rectangle objSubstitutionBounds, AnchorStyles enmSpecified)
		{
			int left = (((enmSpecified & AnchorStyles.Left) != AnchorStyles.None) ? objSubstitutionBounds.Left : objOriginalBounds.Left);
			int top = (((enmSpecified & AnchorStyles.Top) != AnchorStyles.None) ? objSubstitutionBounds.Top : objOriginalBounds.Top);
			int right = (((enmSpecified & AnchorStyles.Right) != AnchorStyles.None) ? objSubstitutionBounds.Right : objOriginalBounds.Right);
			int bottom = (((enmSpecified & AnchorStyles.Bottom) != AnchorStyles.None) ? objSubstitutionBounds.Bottom : objOriginalBounds.Bottom);
			return Rectangle.FromLTRB(left, top, right, bottom);
		}

		public static Size UnionSizes(Size objA, Size objB)
		{
			return new Size(Math.Max(objA.Width, objB.Width), Math.Max(objA.Height, objB.Height));
		}

		public static Rectangle VAlign(Size objAlignThis, Rectangle objWithinThis, ContentAlignment enmAlign)
		{
			if ((enmAlign & (ContentAlignment)1792) != 0)
			{
				objWithinThis.Y += objWithinThis.Height - objAlignThis.Height;
			}
			else if ((enmAlign & (ContentAlignment)112) != 0)
			{
				objWithinThis.Y += (objWithinThis.Height - objAlignThis.Height) / 2;
			}
			objWithinThis.Height = objAlignThis.Height;
			return objWithinThis;
		}

		public static Rectangle VAlign(Size objAlignThis, Rectangle objWithinThis, AnchorStyles enmAnchorStyles)
		{
			if ((enmAnchorStyles & AnchorStyles.Bottom) != AnchorStyles.None)
			{
				objWithinThis.Y += objWithinThis.Height - objAlignThis.Height;
			}
			else if (enmAnchorStyles == AnchorStyles.None || (enmAnchorStyles & (AnchorStyles.Bottom | AnchorStyles.Top)) == 0)
			{
				objWithinThis.Y += (objWithinThis.Height - objAlignThis.Height) / 2;
			}
			objWithinThis.Height = objAlignThis.Height;
			return objWithinThis;
		}

		private static byte xContentAlignmentToIndex(int intThreeBitFlag)
		{
			return (byte)((intThreeBitFlag == 4) ? 3 : ((byte)intThreeBitFlag));
		}
	}
}
