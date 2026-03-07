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
	internal class TableLayout : LayoutEngine
	{
		[Serializable]
		private class ColumnSpanComparer : SpanComparer
		{
			private static readonly ColumnSpanComparer mobjInstance = new ColumnSpanComparer();

			public static ColumnSpanComparer GetInstance => mobjInstance;

			public override int GetSpan(LayoutInfo objLayoutInfo)
			{
				return objLayoutInfo.ColumnSpan;
			}
		}

		[Serializable]
		internal sealed class ContainerInfo : SerializableObject
		{
			private static readonly int mintStateChildHasColumnSpan = SerializableBitVector32.CreateMask(mintStateChildInfoValid);

			private static readonly int mintStateChildHasRowSpan = SerializableBitVector32.CreateMask(mintStateChildHasColumnSpan);

			private static readonly int mintStateChildInfoValid = SerializableBitVector32.CreateMask(mintStateValid);

			private static readonly int mintStateValid = SerializableBitVector32.CreateMask();

			private int mintCellBorderWidth;

			private LayoutInfo[] marrChildInfo;

			private Strip[] marrCols;

			private TableLayoutColumnStyleCollection mobjColStyles;

			private IArrangedElement mobjContainer;

			private int mintCountFixedChildren;

			private TableLayoutPanelGrowStyle menmGrowStyle;

			private int mintMaxColumns;

			private int mintMaxRows;

			private int mintMinColumns;

			private int mintMinRows;

			private int mintMinRowsAndColumns;

			private Strip[] marrRows;

			private TableLayoutRowStyleCollection mobjRowStyles;

			private static Strip[] marrEmptyStrip = new Strip[0];

			private Size mobjPreferredSizeCache = new Size(50, 50);

			private SerializableBitVector32 mobjState = default(SerializableBitVector32);

			public int CellBorderWidth
			{
				get
				{
					return mintCellBorderWidth;
				}
				set
				{
					mintCellBorderWidth = value;
				}
			}

			public bool ChildHasColumnSpan
			{
				get
				{
					return mobjState[mintStateChildHasColumnSpan];
				}
				set
				{
					mobjState[mintStateChildHasColumnSpan] = value;
				}
			}

			public bool ChildHasRowSpan
			{
				get
				{
					return mobjState[mintStateChildHasRowSpan];
				}
				set
				{
					mobjState[mintStateChildHasRowSpan] = value;
				}
			}

			public bool ChildInfoValid => mobjState[mintStateChildInfoValid];

			public LayoutInfo[] ChildrenInfo
			{
				get
				{
					if (!mobjState[mintStateChildInfoValid])
					{
						mintCountFixedChildren = 0;
						mintMinRowsAndColumns = 0;
						mintMinColumns = 0;
						mintMinRows = 0;
						ArrangedElementCollection children = Container.Children;
						LayoutInfo[] array = new LayoutInfo[children.Count];
						int num = 0;
						int num2 = 0;
						for (int i = 0; i < children.Count; i++)
						{
							IArrangedElement objElement = children[i];
							if (!ElementParticipatesInLayout(objElement))
							{
								num++;
								continue;
							}
							LayoutInfo layoutInfo = GetLayoutInfo(objElement);
							if (layoutInfo.IsAbsolutelyPositioned)
							{
								mintCountFixedChildren++;
							}
							array[num2++] = layoutInfo;
							mintMinRowsAndColumns += layoutInfo.RowSpan * layoutInfo.ColumnSpan;
							if (layoutInfo.IsAbsolutelyPositioned)
							{
								mintMinColumns = Math.Max(mintMinColumns, layoutInfo.ColumnPosition + layoutInfo.ColumnSpan);
								mintMinRows = Math.Max(mintMinRows, layoutInfo.RowPosition + layoutInfo.RowSpan);
							}
						}
						if (num > 0)
						{
							LayoutInfo[] array2 = new LayoutInfo[array.Length - num];
							Array.Copy(array, array2, array2.Length);
							marrChildInfo = array2;
						}
						else
						{
							marrChildInfo = array;
						}
						mobjState[mintStateChildInfoValid] = true;
					}
					if (marrChildInfo != null)
					{
						return marrChildInfo;
					}
					return new LayoutInfo[0];
				}
			}

			public Strip[] Columns
			{
				get
				{
					return marrCols;
				}
				set
				{
					marrCols = value;
				}
			}

			public TableLayoutColumnStyleCollection ColumnStyles
			{
				get
				{
					if (mobjColStyles == null)
					{
						mobjColStyles = new TableLayoutColumnStyleCollection(mobjContainer);
					}
					return mobjColStyles;
				}
				set
				{
					mobjColStyles = value;
					if (mobjColStyles != null)
					{
						mobjColStyles.EnsureOwnership(mobjContainer);
					}
				}
			}

			public IArrangedElement Container => mobjContainer;

			public LayoutInfo[] FixedChildrenInfo
			{
				get
				{
					LayoutInfo[] array = new LayoutInfo[mintCountFixedChildren];
					if (HasChildWithAbsolutePositioning)
					{
						int num = 0;
						for (int i = 0; i < marrChildInfo.Length; i++)
						{
							if (marrChildInfo[i].IsAbsolutelyPositioned)
							{
								array[num++] = marrChildInfo[i];
							}
						}
						Array.Sort(array, PreAssignedPositionComparer.GetInstance);
					}
					return array;
				}
			}

			public TableLayoutPanelGrowStyle GrowStyle
			{
				get
				{
					return menmGrowStyle;
				}
				set
				{
					if (menmGrowStyle != value)
					{
						menmGrowStyle = value;
						Valid = false;
					}
				}
			}

			public bool HasChildWithAbsolutePositioning => mintCountFixedChildren > 0;

			public bool HasMultiplePercentColumns
			{
				get
				{
					if (mobjColStyles != null)
					{
						bool flag = false;
						foreach (ColumnStyle item in (IEnumerable)mobjColStyles)
						{
							if (item.SizeType == SizeType.Percent)
							{
								if (flag)
								{
									return true;
								}
								flag = true;
							}
						}
					}
					return false;
				}
			}

			public int MaxColumns
			{
				get
				{
					return mintMaxColumns;
				}
				set
				{
					if (mintMaxColumns != value)
					{
						mintMaxColumns = value;
						Valid = false;
					}
				}
			}

			public int MaxRows
			{
				get
				{
					return mintMaxRows;
				}
				set
				{
					if (mintMaxRows != value)
					{
						mintMaxRows = value;
						Valid = false;
					}
				}
			}

			public int MinColumns => mintMinColumns;

			public int MinRows => mintMinRows;

			public int MinRowsAndColumns => mintMinRowsAndColumns;

			public Strip[] Rows
			{
				get
				{
					return marrRows;
				}
				set
				{
					marrRows = value;
				}
			}

			public TableLayoutRowStyleCollection RowStyles
			{
				get
				{
					if (mobjRowStyles == null)
					{
						mobjRowStyles = new TableLayoutRowStyleCollection(mobjContainer);
					}
					return mobjRowStyles;
				}
				set
				{
					mobjRowStyles = value;
					if (mobjRowStyles != null)
					{
						mobjRowStyles.EnsureOwnership(mobjContainer);
					}
				}
			}

			public bool Valid
			{
				get
				{
					return mobjState[mintStateValid];
				}
				set
				{
					mobjState[mintStateValid] = value;
					if (!mobjState[mintStateValid])
					{
						mobjState[mintStateChildInfoValid] = false;
					}
				}
			}

			public ContainerInfo(IArrangedElement objContainer)
			{
				marrCols = marrEmptyStrip;
				marrRows = marrEmptyStrip;
				mobjContainer = objContainer;
				menmGrowStyle = TableLayoutPanelGrowStyle.AddRows;
			}

			public ContainerInfo(ContainerInfo objContainerInfo)
			{
				marrCols = marrEmptyStrip;
				marrRows = marrEmptyStrip;
				mintCellBorderWidth = objContainerInfo.CellBorderWidth;
				mintMaxRows = objContainerInfo.MaxRows;
				mintMaxColumns = objContainerInfo.MaxColumns;
				menmGrowStyle = objContainerInfo.GrowStyle;
				mobjContainer = objContainerInfo.Container;
				mobjRowStyles = objContainerInfo.RowStyles;
				mobjColStyles = objContainerInfo.ColumnStyles;
			}

			public Size GetCachedPreferredSize(Size objProposedContstraints, out bool blnIsValid)
			{
				blnIsValid = false;
				if (objProposedContstraints.Height == 0 || objProposedContstraints.Width == 0)
				{
					Size result = mobjPreferredSizeCache;
					if (!result.IsEmpty)
					{
						blnIsValid = true;
						return result;
					}
				}
				return Size.Empty;
			}
		}

		[Serializable]
		internal sealed class LayoutInfo
		{
			private int mintColPos = -1;

			private int mintColumnSpan = 1;

			private int mintColumnStart = -1;

			private IArrangedElement mobjElement;

			private int mintRowPos = -1;

			private int mintRowSpan = 1;

			private int mintRowStart = -1;

			internal int ColumnPosition
			{
				get
				{
					return mintColPos;
				}
				set
				{
					mintColPos = value;
				}
			}

			internal int ColumnSpan
			{
				get
				{
					return mintColumnSpan;
				}
				set
				{
					mintColumnSpan = value;
				}
			}

			internal int ColumnStart
			{
				get
				{
					return mintColumnStart;
				}
				set
				{
					mintColumnStart = value;
				}
			}

			internal IArrangedElement Element => mobjElement;

			internal bool IsAbsolutelyPositioned
			{
				get
				{
					if (mintRowPos >= 0)
					{
						return mintColPos >= 0;
					}
					return false;
				}
			}

			internal int RowPosition
			{
				get
				{
					return mintRowPos;
				}
				set
				{
					mintRowPos = value;
				}
			}

			internal int RowSpan
			{
				get
				{
					return mintRowSpan;
				}
				set
				{
					mintRowSpan = value;
				}
			}

			internal int RowStart
			{
				get
				{
					return mintRowStart;
				}
				set
				{
					mintRowStart = value;
				}
			}

			public LayoutInfo(IArrangedElement objElement)
			{
				mobjElement = objElement;
			}
		}

		[Serializable]
		private class MaxSizeProxy : SizeProxy
		{
			private static readonly MaxSizeProxy mobjInstance = new MaxSizeProxy();

			public static MaxSizeProxy GetInstance => mobjInstance;

			public override int Size
			{
				get
				{
					return mobjStrip.MaxSize;
				}
				set
				{
					mobjStrip.MaxSize = value;
				}
			}
		}

		[Serializable]
		private class MinSizeProxy : SizeProxy
		{
			private static readonly MinSizeProxy mobjInstance = new MinSizeProxy();

			public static MinSizeProxy GetInstance => mobjInstance;

			public override int Size
			{
				get
				{
					return mobjStrip.MinSize;
				}
				set
				{
					mobjStrip.MinSize = value;
				}
			}
		}

		[Serializable]
		private class PostAssignedPositionComparer : IComparer
		{
			private static readonly PostAssignedPositionComparer mobjInstance = new PostAssignedPositionComparer();

			public static PostAssignedPositionComparer GetInstance => mobjInstance;

			public int Compare(object objX, object objY)
			{
				LayoutInfo layoutInfo = (LayoutInfo)objX;
				LayoutInfo layoutInfo2 = (LayoutInfo)objY;
				if (layoutInfo.RowStart < layoutInfo2.RowStart)
				{
					return -1;
				}
				if (layoutInfo.RowStart > layoutInfo2.RowStart)
				{
					return 1;
				}
				if (layoutInfo.ColumnStart < layoutInfo2.ColumnStart)
				{
					return -1;
				}
				if (layoutInfo.ColumnStart > layoutInfo2.ColumnStart)
				{
					return 1;
				}
				return 0;
			}
		}

		[Serializable]
		private class PreAssignedPositionComparer : IComparer
		{
			private static readonly PreAssignedPositionComparer mobjInstance = new PreAssignedPositionComparer();

			public static PreAssignedPositionComparer GetInstance => mobjInstance;

			public int Compare(object objX, object objY)
			{
				LayoutInfo layoutInfo = (LayoutInfo)objX;
				LayoutInfo layoutInfo2 = (LayoutInfo)objY;
				if (layoutInfo.RowPosition < layoutInfo2.RowPosition)
				{
					return -1;
				}
				if (layoutInfo.RowPosition > layoutInfo2.RowPosition)
				{
					return 1;
				}
				if (layoutInfo.ColumnPosition < layoutInfo2.ColumnPosition)
				{
					return -1;
				}
				if (layoutInfo.ColumnPosition > layoutInfo2.ColumnPosition)
				{
					return 1;
				}
				return 0;
			}
		}

		[Serializable]
		private sealed class ReservationGrid
		{
			private int mintNumColumns = 1;

			private ArrayList mobjRows = new ArrayList();

			public void AdvanceRow()
			{
				if (mobjRows.Count > 0)
				{
					mobjRows.RemoveAt(0);
				}
			}

			public bool IsReserved(int intColumn, int intRowOffset)
			{
				if (intRowOffset >= mobjRows.Count)
				{
					return false;
				}
				if (intColumn >= ((BitArray)mobjRows[intRowOffset]).Length)
				{
					return false;
				}
				return ((BitArray)mobjRows[intRowOffset])[intColumn];
			}

			public void Reserve(int intColumn, int intRowOffset)
			{
				while (intRowOffset >= mobjRows.Count)
				{
					mobjRows.Add(new BitArray(mintNumColumns));
				}
				if (intColumn >= ((BitArray)mobjRows[intRowOffset]).Length)
				{
					((BitArray)mobjRows[intRowOffset]).Length = intColumn + 1;
					if (intColumn >= mintNumColumns)
					{
						mintNumColumns = intColumn + 1;
					}
				}
				((BitArray)mobjRows[intRowOffset])[intColumn] = true;
			}

			public void ReserveAll(LayoutInfo layoutInfo, int intRowStop, int intColStop)
			{
				for (int i = 1; i < intRowStop - layoutInfo.RowStart; i++)
				{
					for (int j = layoutInfo.ColumnStart; j < intColStop; j++)
					{
						Reserve(j, i);
					}
				}
			}
		}

		[Serializable]
		private class RowSpanComparer : SpanComparer
		{
			private static readonly RowSpanComparer mobjInstance = new RowSpanComparer();

			public static RowSpanComparer GetInstance => mobjInstance;

			public override int GetSpan(LayoutInfo objLayoutInfo)
			{
				return objLayoutInfo.RowSpan;
			}
		}

		[Serializable]
		private abstract class SizeProxy
		{
			protected Strip mobjStrip;

			public abstract int Size { get; set; }

			public Strip Strip
			{
				get
				{
					return mobjStrip;
				}
				set
				{
					mobjStrip = value;
				}
			}
		}

		[Serializable]
		private abstract class SpanComparer : IComparer
		{
			public int Compare(object ojbX, object objY)
			{
				LayoutInfo layoutInfo = (LayoutInfo)ojbX;
				LayoutInfo layoutInfo2 = (LayoutInfo)objY;
				return GetSpan(layoutInfo) - GetSpan(layoutInfo2);
			}

			public abstract int GetSpan(LayoutInfo layoutInfo);
		}

		[Serializable]
		internal struct Strip
		{
			private int mintMaxSize;

			private int mintMinSize;

			private bool mblnIsStart;

			public int MinSize
			{
				get
				{
					return mintMinSize;
				}
				set
				{
					mintMinSize = value;
				}
			}

			public int MaxSize
			{
				get
				{
					return mintMaxSize;
				}
				set
				{
					mintMaxSize = value;
				}
			}

			public bool IsStart
			{
				get
				{
					return mblnIsStart;
				}
				set
				{
					mblnIsStart = value;
				}
			}
		}

		private static string[] marrPropertiesWhichInvalidateCache;

		internal static readonly TableLayout Instance;

		private bool mblnIsAutoSize = true;

		private Padding mobjMargins = new Padding(0);

		private Size mobjSpecifiedBoundsSize = new Size(50, 50);

		static TableLayout()
		{
			Instance = new TableLayout();
			marrPropertiesWhichInvalidateCache = new string[9]
			{
				null,
				PropertyNames.ChildIndex,
				PropertyNames.Parent,
				PropertyNames.Visible,
				PropertyNames.Items,
				PropertyNames.Rows,
				PropertyNames.Columns,
				PropertyNames.RowStyles,
				PropertyNames.ColumnStyles
			};
		}

		private void AdvanceUntilFits(int intMaxColumns, ReservationGrid objReservationGrid, LayoutInfo objLayoutInfo, out int colStop)
		{
			int rowStart = objLayoutInfo.RowStart;
			do
			{
				GetColStartAndStop(intMaxColumns, objReservationGrid, objLayoutInfo, out colStop);
			}
			while (ScanRowForOverlap(intMaxColumns, objReservationGrid, objLayoutInfo, colStop, objLayoutInfo.RowStart - rowStart));
		}

		private Size ApplyStyles(ContainerInfo objContainerInfo, Size objProposedConstraints, bool blnMeasureOnly)
		{
			Size empty = Size.Empty;
			InitializeStrips(objContainerInfo.Columns, objContainerInfo.ColumnStyles);
			InitializeStrips(objContainerInfo.Rows, objContainerInfo.RowStyles);
			objContainerInfo.ChildHasColumnSpan = false;
			objContainerInfo.ChildHasRowSpan = false;
			LayoutInfo[] childrenInfo = objContainerInfo.ChildrenInfo;
			foreach (LayoutInfo layoutInfo in childrenInfo)
			{
				objContainerInfo.Columns[layoutInfo.ColumnStart].IsStart = true;
				objContainerInfo.Rows[layoutInfo.RowStart].IsStart = true;
				if (layoutInfo.ColumnSpan > 1)
				{
					objContainerInfo.ChildHasColumnSpan = true;
				}
				if (layoutInfo.RowSpan > 1)
				{
					objContainerInfo.ChildHasRowSpan = true;
				}
			}
			empty.Width = InflateColumns(objContainerInfo, objProposedConstraints, blnMeasureOnly);
			int intExpandLastElementWidth = Math.Max(0, objProposedConstraints.Width - empty.Width);
			empty.Height = InflateRows(objContainerInfo, objProposedConstraints, intExpandLastElementWidth, blnMeasureOnly);
			return empty;
		}

		internal void AssignRowsAndColumns(ContainerInfo objContainerInfo)
		{
			int num = objContainerInfo.MaxColumns;
			int num2 = objContainerInfo.MaxRows;
			LayoutInfo[] childrenInfo = objContainerInfo.ChildrenInfo;
			int minRowsAndColumns = objContainerInfo.MinRowsAndColumns;
			int minColumns = objContainerInfo.MinColumns;
			int minRows = objContainerInfo.MinRows;
			TableLayoutPanelGrowStyle growStyle = objContainerInfo.GrowStyle;
			switch (growStyle)
			{
			case TableLayoutPanelGrowStyle.FixedSize:
				if (objContainerInfo.MinRowsAndColumns > num * num2)
				{
					throw new ArgumentException(SR.GetString("TableLayoutPanelFullDesc"));
				}
				if (minColumns > num || minRows > num2)
				{
					throw new ArgumentException(SR.GetString("TableLayoutPanelSpanDesc"));
				}
				num2 = Math.Max(1, num2);
				num = Math.Max(1, num);
				break;
			case TableLayoutPanelGrowStyle.AddRows:
				num2 = 0;
				break;
			default:
				num = 0;
				break;
			}
			if (num > 0)
			{
				xAssignRowsAndColumns(objContainerInfo, childrenInfo, num, (num2 == 0) ? int.MaxValue : num2, growStyle);
			}
			else if (num2 > 0)
			{
				for (int i = Math.Max(Math.Max((int)Math.Ceiling((float)minRowsAndColumns / (float)num2), minColumns), 1); !xAssignRowsAndColumns(objContainerInfo, childrenInfo, i, num2, growStyle); i++)
				{
				}
			}
			else
			{
				xAssignRowsAndColumns(objContainerInfo, childrenInfo, Math.Max(minColumns, 1), int.MaxValue, growStyle);
			}
		}

		[Conditional("DEBUG_LAYOUT")]
		private void Debug_VerifyAssignmentsAreCurrent(IArrangedElement objContainer, ContainerInfo objContainerInfo)
		{
		}

		[Conditional("DEBUG_LAYOUT")]
		private void Debug_VerifyNoOverlapping(IArrangedElement objContainer)
		{
			ArrayList arrayList = new ArrayList(objContainer.Children.Count);
			ContainerInfo containerInfo = GetContainerInfo(objContainer);
			Strip[] rows = containerInfo.Rows;
			Strip[] columns = containerInfo.Columns;
			foreach (IArrangedElement child in objContainer.Children)
			{
				if (ElementParticipatesInLayout(child))
				{
					arrayList.Add(GetLayoutInfo(child));
				}
			}
			for (int i = 0; i < arrayList.Count; i++)
			{
				LayoutInfo layoutInfo = (LayoutInfo)arrayList[i];
				Rectangle elementBounds = GetElementBounds(layoutInfo.Element);
				new Rectangle(layoutInfo.ColumnStart, layoutInfo.RowStart, layoutInfo.ColumnSpan, layoutInfo.RowSpan);
				for (int j = i + 1; j < arrayList.Count; j++)
				{
					LayoutInfo layoutInfo2 = (LayoutInfo)arrayList[j];
					Rectangle elementBounds2 = GetElementBounds(layoutInfo2.Element);
					new Rectangle(layoutInfo2.ColumnStart, layoutInfo2.RowStart, layoutInfo2.ColumnSpan, layoutInfo2.RowSpan);
					if (LayoutUtils.IsIntersectHorizontally(elementBounds, elementBounds2))
					{
						for (int k = layoutInfo.ColumnStart; k < layoutInfo.ColumnStart + layoutInfo.ColumnSpan; k++)
						{
						}
						for (int k = layoutInfo2.ColumnStart; k < layoutInfo2.ColumnStart + layoutInfo2.ColumnSpan; k++)
						{
						}
					}
					if (LayoutUtils.IsIntersectVertically(elementBounds, elementBounds2))
					{
						for (int l = layoutInfo.RowStart; l < layoutInfo.RowStart + layoutInfo.RowSpan; l++)
						{
						}
						for (int l = layoutInfo2.RowStart; l < layoutInfo2.RowStart + layoutInfo2.RowSpan; l++)
						{
						}
					}
				}
			}
		}

		private void DistributeSize(IList objStyles, Strip[] arrStrips, int intStart, int intStop, int intMin, int intMax, int cellBorderWidth)
		{
			xDistributeSize(objStyles, arrStrips, intStart, intStop, intMin, MinSizeProxy.GetInstance, cellBorderWidth);
			xDistributeSize(objStyles, arrStrips, intStart, intStop, intMax, MaxSizeProxy.GetInstance, cellBorderWidth);
		}

		private int DistributeStyles(int cellBorderWidth, IList objStyles, Strip[] arrStrips, int intMaxSize, bool blnDontHonorConstraint)
		{
			int num = 0;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			bool flag = false;
			for (int i = 0; i < arrStrips.Length; i++)
			{
				Strip strip = arrStrips[i];
				if (i < objStyles.Count)
				{
					TableLayoutStyle tableLayoutStyle = (TableLayoutStyle)objStyles[i];
					switch (tableLayoutStyle.SizeType)
					{
					case SizeType.Absolute:
						num5 += (float)strip.MinSize;
						break;
					case SizeType.Percent:
						num3 += tableLayoutStyle.Size;
						num4 += (float)strip.MinSize;
						break;
					default:
						num5 += (float)strip.MinSize;
						flag = true;
						break;
					}
				}
				else
				{
					flag = true;
				}
				strip.MaxSize += cellBorderWidth;
				strip.MinSize += cellBorderWidth;
				arrStrips[i] = strip;
				num += strip.MinSize;
			}
			int num6 = intMaxSize - num;
			if (num3 > 0f)
			{
				if (!blnDontHonorConstraint)
				{
					if (num4 > (float)intMaxSize - num5)
					{
						num4 = Math.Max(0f, (float)intMaxSize - num5);
					}
					if (num6 > 0)
					{
						num4 += (float)num6;
					}
					else if (num6 < 0)
					{
						num4 = (float)intMaxSize - num5 - (float)(arrStrips.Length * cellBorderWidth);
						num6 = 0;
					}
					for (int j = 0; j < arrStrips.Length; j++)
					{
						Strip strip2 = arrStrips[j];
						SizeType sizeType = ((j < objStyles.Count) ? ((TableLayoutStyle)objStyles[j]).SizeType : SizeType.AutoSize);
						if (sizeType == SizeType.Percent)
						{
							TableLayoutStyle tableLayoutStyle2 = (TableLayoutStyle)objStyles[j];
							int num7 = (int)(tableLayoutStyle2.Size * num4 / num3);
							num -= strip2.MinSize;
							num += num7 + cellBorderWidth;
							strip2.MinSize = num7 + cellBorderWidth;
							arrStrips[j] = strip2;
						}
					}
				}
				else
				{
					int num8 = 0;
					for (int k = 0; k < arrStrips.Length; k++)
					{
						Strip strip3 = arrStrips[k];
						SizeType sizeType2 = ((k < objStyles.Count) ? ((TableLayoutStyle)objStyles[k]).SizeType : SizeType.AutoSize);
						if (sizeType2 == SizeType.Percent)
						{
							TableLayoutStyle tableLayoutStyle3 = (TableLayoutStyle)objStyles[k];
							int val = (int)Math.Round((float)strip3.MinSize * num3 / tableLayoutStyle3.Size);
							num8 = Math.Max(num8, val);
							num -= strip3.MinSize;
						}
					}
					num += num8;
				}
			}
			num6 = intMaxSize - num;
			if (flag && num6 > 0)
			{
				if ((float)num6 < num2)
				{
					float num9 = (float)num6 / num2;
				}
				num6 -= (int)Math.Ceiling(num2);
				for (int l = 0; l < arrStrips.Length; l++)
				{
					Strip strip4 = arrStrips[l];
					if (l >= objStyles.Count || ((TableLayoutStyle)objStyles[l]).SizeType == SizeType.AutoSize)
					{
						int num10 = Math.Min(strip4.MaxSize - strip4.MinSize, num6);
						if (num10 > 0)
						{
							num += num10;
							num6 -= num10;
							strip4.MinSize += num10;
							arrStrips[l] = strip4;
						}
					}
				}
			}
			return num;
		}

		private static bool ElementParticipatesInLayout(IArrangedElement objElement)
		{
			bool result = false;
			if (objElement != null && objElement is Control)
			{
				result = ((Control)objElement).Visible;
			}
			return result;
		}

		private void EnsureRowAndColumnAssignments(IArrangedElement objContainer, ContainerInfo objContainerInfo, bool blnDoNotCache)
		{
			if (!HasCachedAssignments(objContainerInfo) || blnDoNotCache)
			{
				AssignRowsAndColumns(objContainerInfo);
			}
		}

		private void ExpandLastElement(ContainerInfo objContainerInfo, Size objUsedSpace, Size objTotalSpace)
		{
			Strip[] rows = objContainerInfo.Rows;
			Strip[] columns = objContainerInfo.Columns;
			if (columns.Length != 0 && objTotalSpace.Width > objUsedSpace.Width)
			{
				columns[columns.Length - 1].MinSize += objTotalSpace.Width - objUsedSpace.Width;
			}
			if (rows.Length != 0 && objTotalSpace.Height > objUsedSpace.Height)
			{
				rows[rows.Length - 1].MinSize += objTotalSpace.Height - objUsedSpace.Height;
			}
		}

		private void GetColStartAndStop(int intMaxColumns, ReservationGrid objReservationGrid, LayoutInfo objLayoutInfo, out int colStop)
		{
			colStop = objLayoutInfo.ColumnStart + objLayoutInfo.ColumnSpan;
			if (colStop > intMaxColumns)
			{
				if (objLayoutInfo.ColumnStart != 0)
				{
					objLayoutInfo.ColumnStart = 0;
					objLayoutInfo.RowStart++;
				}
				colStop = Math.Min(objLayoutInfo.ColumnSpan, intMaxColumns);
			}
		}

		private Rectangle GetElementBounds(IArrangedElement objArrangedElement)
		{
			Rectangle result = default(Rectangle);
			if (objArrangedElement != null && objArrangedElement is Control)
			{
				result = new Rectangle(((Control)objArrangedElement).Location, ((Control)objArrangedElement).Size);
			}
			return result;
		}

		private Size GetElementSize(IArrangedElement objElement, Size objProposedConstraints)
		{
			if (mblnIsAutoSize && objElement != null && objElement is Control)
			{
				return ((Control)objElement).Size;
			}
			return mobjSpecifiedBoundsSize;
		}

		private static LayoutInfo GetNextLayoutInfo(LayoutInfo[] arrLayoutInfo, ref int index, bool blnAbsolutelyPositioned)
		{
			for (int i = ++index; i < arrLayoutInfo.Length; i++)
			{
				if (blnAbsolutelyPositioned == arrLayoutInfo[i].IsAbsolutelyPositioned)
				{
					index = i;
					return arrLayoutInfo[i];
				}
			}
			index = arrLayoutInfo.Length;
			return null;
		}

		private int InflateColumns(ContainerInfo objContainerInfo, Size objProposedConstraints, bool blnMeasureOnly)
		{
			bool flag = blnMeasureOnly;
			LayoutInfo[] childrenInfo = objContainerInfo.ChildrenInfo;
			if (objContainerInfo.ChildHasColumnSpan)
			{
				Array.Sort(childrenInfo, ColumnSpanComparer.GetInstance);
			}
			if (flag && objProposedConstraints.Width < 32767 && objContainerInfo.Container is TableLayoutPanel { ParentInternal: not null } tableLayoutPanel)
			{
				if (tableLayoutPanel.Dock == DockStyle.Top || tableLayoutPanel.Dock == DockStyle.Bottom || tableLayoutPanel.Dock == DockStyle.Fill)
				{
					flag = false;
				}
				if ((tableLayoutPanel.Anchor & (AnchorStyles.Left | AnchorStyles.Right)) == (AnchorStyles.Left | AnchorStyles.Right))
				{
					flag = false;
				}
			}
			LayoutInfo[] array = childrenInfo;
			foreach (LayoutInfo layoutInfo in array)
			{
				IArrangedElement element = layoutInfo.Element;
				int columnSpan = layoutInfo.ColumnSpan;
				if (columnSpan > 1 || !IsAbsolutelySized(layoutInfo.ColumnStart, objContainerInfo.ColumnStyles))
				{
					int num = 0;
					int num2 = 0;
					if (columnSpan == 1 && layoutInfo.RowSpan == 1 && IsAbsolutelySized(layoutInfo.RowStart, objContainerInfo.RowStyles))
					{
						int height = (int)objContainerInfo.RowStyles[layoutInfo.RowStart].Size;
						num = GetElementSize(element, new Size(0, height)).Width;
						num2 = num;
					}
					else
					{
						num = GetElementSize(element, new Size(1, 0)).Width;
						num2 = GetElementSize(element, Size.Empty).Width;
					}
					Padding padding = mobjMargins;
					num += padding.Horizontal;
					num2 += padding.Horizontal;
					int intStop = Math.Min(layoutInfo.ColumnStart + layoutInfo.ColumnSpan, objContainerInfo.Columns.Length);
					DistributeSize(objContainerInfo.ColumnStyles, objContainerInfo.Columns, layoutInfo.ColumnStart, intStop, num, num2, objContainerInfo.CellBorderWidth);
				}
			}
			int num3 = DistributeStyles(objContainerInfo.CellBorderWidth, objContainerInfo.ColumnStyles, objContainerInfo.Columns, objProposedConstraints.Width, flag);
			if (!flag || num3 <= objProposedConstraints.Width || objProposedConstraints.Width <= 1)
			{
				return num3;
			}
			Strip[] columns = objContainerInfo.Columns;
			float num4 = 0f;
			int num5 = 0;
			TableLayoutStyleCollection columnStyles = objContainerInfo.ColumnStyles;
			for (int j = 0; j < columns.Length; j++)
			{
				Strip strip = columns[j];
				if (j < columnStyles.Count)
				{
					TableLayoutStyle tableLayoutStyle = columnStyles[j];
					if (tableLayoutStyle.SizeType == SizeType.Percent)
					{
						num4 += tableLayoutStyle.Size;
						num5 += strip.MinSize;
					}
				}
			}
			int val = num3 - objProposedConstraints.Width;
			int num6 = Math.Min(val, num5);
			for (int k = 0; k < columns.Length; k++)
			{
				if (k < columnStyles.Count)
				{
					TableLayoutStyle tableLayoutStyle2 = columnStyles[k];
					if (tableLayoutStyle2.SizeType == SizeType.Percent)
					{
						float num7 = tableLayoutStyle2.Size / num4;
						columns[k].MinSize -= (int)(num7 * (float)num6);
					}
				}
			}
			return num3 - num6;
		}

		private int InflateRows(ContainerInfo objContainerInfo, Size objProposedConstraints, int intExpandLastElementWidth, bool blnMeasureOnly)
		{
			bool flag = blnMeasureOnly;
			LayoutInfo[] childrenInfo = objContainerInfo.ChildrenInfo;
			if (objContainerInfo.ChildHasRowSpan)
			{
				Array.Sort(childrenInfo, RowSpanComparer.GetInstance);
			}
			bool hasMultiplePercentColumns = objContainerInfo.HasMultiplePercentColumns;
			if (flag && objProposedConstraints.Height < 32767 && objContainerInfo.Container is TableLayoutPanel { ParentInternal: not null } tableLayoutPanel)
			{
				if (tableLayoutPanel.Dock == DockStyle.Left || tableLayoutPanel.Dock == DockStyle.Right || tableLayoutPanel.Dock == DockStyle.Fill)
				{
					flag = false;
				}
				if ((tableLayoutPanel.Anchor & (AnchorStyles.Bottom | AnchorStyles.Top)) == (AnchorStyles.Bottom | AnchorStyles.Top))
				{
					flag = false;
				}
			}
			LayoutInfo[] array = childrenInfo;
			foreach (LayoutInfo layoutInfo in array)
			{
				IArrangedElement element = layoutInfo.Element;
				if (layoutInfo.RowSpan > 1 || !IsAbsolutelySized(layoutInfo.RowStart, objContainerInfo.RowStyles))
				{
					int num = SumStrips(objContainerInfo.Columns, layoutInfo.ColumnStart, layoutInfo.ColumnSpan);
					if (!flag && layoutInfo.ColumnStart + layoutInfo.ColumnSpan >= objContainerInfo.MaxColumns && !hasMultiplePercentColumns)
					{
						num += intExpandLastElementWidth;
					}
					Padding padding = mobjMargins;
					int num2 = GetElementSize(element, new Size(num - padding.Horizontal, 0)).Height + padding.Vertical;
					int intMax = num2;
					int intStop = Math.Min(layoutInfo.RowStart + layoutInfo.RowSpan, objContainerInfo.Rows.Length);
					DistributeSize(objContainerInfo.RowStyles, objContainerInfo.Rows, layoutInfo.RowStart, intStop, num2, intMax, objContainerInfo.CellBorderWidth);
				}
			}
			return DistributeStyles(objContainerInfo.CellBorderWidth, objContainerInfo.RowStyles, objContainerInfo.Rows, objProposedConstraints.Height, flag);
		}

		private void InitializeStrips(Strip[] arrStrips, IList objStyles)
		{
			for (int i = 0; i < arrStrips.Length; i++)
			{
				TableLayoutStyle tableLayoutStyle = ((i < objStyles.Count) ? ((TableLayoutStyle)objStyles[i]) : null);
				Strip strip = arrStrips[i];
				if (tableLayoutStyle != null && tableLayoutStyle.SizeType == SizeType.Absolute)
				{
					strip.MinSize = (int)Math.Round(((TableLayoutStyle)objStyles[i]).Size);
					strip.MaxSize = strip.MinSize;
				}
				else
				{
					strip.MinSize = 0;
					strip.MaxSize = 0;
				}
				strip.IsStart = false;
				arrStrips[i] = strip;
			}
		}

		private bool IsAbsolutelySized(int index, IList objStyles)
		{
			if (index < objStyles.Count)
			{
				return ((TableLayoutStyle)objStyles[index]).SizeType == SizeType.Absolute;
			}
			return false;
		}

		private bool IsCursorPastInsertionPoint(LayoutInfo fixedLayoutInfo, int insertionRow, int insertionCol)
		{
			return fixedLayoutInfo.RowPosition < insertionRow || (fixedLayoutInfo.RowPosition == insertionRow && fixedLayoutInfo.ColumnPosition < insertionCol);
		}

		private bool IsOverlappingWithReservationGrid(LayoutInfo fixedLayoutInfo, ReservationGrid objReservationGrid, int intCurrentRow)
		{
			if (fixedLayoutInfo.RowPosition < intCurrentRow)
			{
				return true;
			}
			for (int i = fixedLayoutInfo.RowPosition - intCurrentRow; i < fixedLayoutInfo.RowPosition - intCurrentRow + fixedLayoutInfo.RowSpan; i++)
			{
				for (int j = fixedLayoutInfo.ColumnPosition; j < fixedLayoutInfo.ColumnPosition + fixedLayoutInfo.ColumnSpan; j++)
				{
					if (objReservationGrid.IsReserved(j, i))
					{
						return true;
					}
				}
			}
			return false;
		}

		private bool ScanRowForOverlap(int intMaxColumns, ReservationGrid objReservationGrid, LayoutInfo layoutInfo, int intStopCol, int intRowOffset)
		{
			for (int i = layoutInfo.ColumnStart; i < intStopCol; i++)
			{
				if (objReservationGrid.IsReserved(i, intRowOffset))
				{
					layoutInfo.ColumnStart = i + 1;
					while (layoutInfo.ColumnStart < intMaxColumns && objReservationGrid.IsReserved(layoutInfo.ColumnStart, intRowOffset))
					{
						layoutInfo.ColumnStart++;
					}
					return true;
				}
			}
			return false;
		}

		private Rectangle SetElementBounds(IArrangedElement objArrangedElement, Rectangle objRectangle)
		{
			if (objArrangedElement != null && objArrangedElement is Control)
			{
				((Control)objArrangedElement).Location = objRectangle.Location;
				((Control)objArrangedElement).Size = objRectangle.Size;
			}
			return objRectangle;
		}

		private void SetElementBounds(ContainerInfo objContainerInfo, RectangleF displayRectF)
		{
			int cellBorderWidth = objContainerInfo.CellBorderWidth;
			float num = displayRectF.Y;
			int i = 0;
			int j = 0;
			bool flag = false;
			Rectangle.Truncate(displayRectF);
			if (objContainerInfo.Container is Control)
			{
				Control control = objContainerInfo.Container as Control;
				flag = control.RightToLeft == RightToLeft.Yes;
			}
			LayoutInfo[] childrenInfo = objContainerInfo.ChildrenInfo;
			float num2 = (flag ? displayRectF.Right : displayRectF.X);
			Array.Sort(childrenInfo, PostAssignedPositionComparer.GetInstance);
			foreach (LayoutInfo layoutInfo in childrenInfo)
			{
				IArrangedElement element = layoutInfo.Element;
				if (j != layoutInfo.RowStart)
				{
					for (; j < layoutInfo.RowStart; j++)
					{
						num += (float)objContainerInfo.Rows[j].MinSize;
					}
					num2 = (flag ? displayRectF.Right : displayRectF.X);
					i = 0;
				}
				for (; i < layoutInfo.ColumnStart; i++)
				{
					num2 = ((!flag) ? (num2 + (float)objContainerInfo.Columns[i].MinSize) : (num2 - (float)objContainerInfo.Columns[i].MinSize));
				}
				int num3 = i + layoutInfo.ColumnSpan;
				int num4 = 0;
				for (; i < num3 && i < objContainerInfo.Columns.Length; i++)
				{
					num4 += objContainerInfo.Columns[i].MinSize;
				}
				if (flag)
				{
					num2 -= (float)num4;
				}
				int num5 = j + layoutInfo.RowSpan;
				int num6 = 0;
				for (int l = j; l < num5 && l < objContainerInfo.Rows.Length; l++)
				{
					num6 += objContainerInfo.Rows[l].MinSize;
				}
				Rectangle objRect = new Rectangle((int)(num2 + (float)cellBorderWidth / 2f), (int)(num + (float)cellBorderWidth / 2f), num4 - cellBorderWidth, num6 - cellBorderWidth);
				Padding objPadding = mobjMargins;
				if (flag)
				{
					int right = objPadding.Right;
					objPadding.Right = objPadding.Left;
					objPadding.Left = right;
				}
				objRect = LayoutUtils.DeflateRect(objRect, objPadding);
				objRect.Width = Math.Max(objRect.Width, 1);
				objRect.Height = Math.Max(objRect.Height, 1);
				AnchorStyles enmAnchorStyles = AnchorStyles.Left | AnchorStyles.Top;
				if (element is Control)
				{
					enmAnchorStyles = ((Control)element).Anchor;
				}
				Rectangle objRectangle = LayoutUtils.AlignAndStretch(GetElementSize(element, objRect.Size), objRect, enmAnchorStyles);
				objRectangle.Width = Math.Min(objRect.Width, objRectangle.Width);
				objRectangle.Height = Math.Min(objRect.Height, objRectangle.Height);
				if (flag)
				{
					objRectangle.X = objRect.X + (objRect.Right - objRectangle.Right);
				}
				SetElementBounds(element, objRectangle);
				if (!flag)
				{
					num2 += (float)num4;
				}
			}
		}

		private bool xAssignRowsAndColumns(ContainerInfo objContainerInfo, LayoutInfo[] arrChildrenInfo, int intMaxColumns, int intMaxRows, TableLayoutPanelGrowStyle enmGrowStyle)
		{
			int num = 0;
			int num2 = 0;
			ReservationGrid reservationGrid = new ReservationGrid();
			int num3 = 0;
			int num4 = 0;
			int index = -1;
			int index2 = -1;
			LayoutInfo[] fixedChildrenInfo = objContainerInfo.FixedChildrenInfo;
			LayoutInfo nextLayoutInfo = GetNextLayoutInfo(fixedChildrenInfo, ref index, blnAbsolutelyPositioned: true);
			LayoutInfo nextLayoutInfo2 = GetNextLayoutInfo(arrChildrenInfo, ref index2, blnAbsolutelyPositioned: false);
			while (nextLayoutInfo != null || nextLayoutInfo2 != null)
			{
				int colStop = num4;
				if (nextLayoutInfo2 != null)
				{
					nextLayoutInfo2.RowStart = num3;
					nextLayoutInfo2.ColumnStart = num4;
					AdvanceUntilFits(intMaxColumns, reservationGrid, nextLayoutInfo2, out colStop);
					if (nextLayoutInfo2.RowStart >= intMaxRows)
					{
						return false;
					}
				}
				int num5;
				if (nextLayoutInfo2 != null && (nextLayoutInfo == null || (!IsCursorPastInsertionPoint(nextLayoutInfo, nextLayoutInfo2.RowStart, colStop) && !IsOverlappingWithReservationGrid(nextLayoutInfo, reservationGrid, num3))))
				{
					for (int i = 0; i < nextLayoutInfo2.RowStart - num3; i++)
					{
						reservationGrid.AdvanceRow();
					}
					num3 = nextLayoutInfo2.RowStart;
					num5 = Math.Min(num3 + nextLayoutInfo2.RowSpan, intMaxRows);
					reservationGrid.ReserveAll(nextLayoutInfo2, num5, colStop);
					nextLayoutInfo2 = GetNextLayoutInfo(arrChildrenInfo, ref index2, blnAbsolutelyPositioned: false);
				}
				else
				{
					if (num4 >= intMaxColumns)
					{
						num4 = 0;
						num3++;
						reservationGrid.AdvanceRow();
					}
					nextLayoutInfo.RowStart = Math.Min(nextLayoutInfo.RowPosition, intMaxRows - 1);
					nextLayoutInfo.ColumnStart = Math.Min(nextLayoutInfo.ColumnPosition, intMaxColumns - 1);
					if (num3 > nextLayoutInfo.RowStart)
					{
						nextLayoutInfo.ColumnStart = num4;
					}
					else if (num3 == nextLayoutInfo.RowStart)
					{
						nextLayoutInfo.ColumnStart = Math.Max(nextLayoutInfo.ColumnStart, num4);
					}
					nextLayoutInfo.RowStart = Math.Max(nextLayoutInfo.RowStart, num3);
					int j;
					for (j = 0; j < nextLayoutInfo.RowStart - num3; j++)
					{
						reservationGrid.AdvanceRow();
					}
					AdvanceUntilFits(intMaxColumns, reservationGrid, nextLayoutInfo, out colStop);
					if (nextLayoutInfo.RowStart >= intMaxRows)
					{
						return false;
					}
					for (; j < nextLayoutInfo.RowStart - num3; j++)
					{
						reservationGrid.AdvanceRow();
					}
					num3 = nextLayoutInfo.RowStart;
					colStop = Math.Min(nextLayoutInfo.ColumnStart + nextLayoutInfo.ColumnSpan, intMaxColumns);
					num5 = Math.Min(nextLayoutInfo.RowStart + nextLayoutInfo.RowSpan, intMaxRows);
					reservationGrid.ReserveAll(nextLayoutInfo, num5, colStop);
					nextLayoutInfo = GetNextLayoutInfo(fixedChildrenInfo, ref index, blnAbsolutelyPositioned: true);
				}
				num4 = colStop;
				num2 = ((num2 == int.MaxValue) ? num5 : Math.Max(num2, num5));
				num = ((num == int.MaxValue) ? colStop : Math.Max(num, colStop));
			}
			switch (enmGrowStyle)
			{
			case TableLayoutPanelGrowStyle.FixedSize:
				num = intMaxColumns;
				num2 = intMaxRows;
				break;
			case TableLayoutPanelGrowStyle.AddRows:
				num = intMaxColumns;
				num2 = Math.Max(objContainerInfo.MaxRows, num2);
				break;
			default:
				num2 = ((intMaxRows == int.MaxValue) ? num2 : intMaxRows);
				num = Math.Max(objContainerInfo.MaxColumns, num);
				break;
			}
			if (objContainerInfo.Rows == null || objContainerInfo.Rows.Length != num2)
			{
				objContainerInfo.Rows = new Strip[num2];
			}
			if (objContainerInfo.Columns == null || objContainerInfo.Columns.Length != num)
			{
				objContainerInfo.Columns = new Strip[num];
			}
			objContainerInfo.Valid = true;
			return true;
		}

		private void xDistributeSize(IList objStyles, Strip[] arrStrips, int intStart, int intStop, int intDesiredLength, SizeProxy sizeProxy, int cellBorderWidth)
		{
			int num = 0;
			int num2 = 0;
			intDesiredLength -= cellBorderWidth * (intStop - intStart - 1);
			intDesiredLength = Math.Max(0, intDesiredLength);
			for (int i = intStart; i < intStop; i++)
			{
				sizeProxy.Strip = arrStrips[i];
				if (!IsAbsolutelySized(i, objStyles) && sizeProxy.Size == 0)
				{
					num2++;
				}
				num += sizeProxy.Size;
			}
			int num3 = intDesiredLength - num;
			if (num3 <= 0)
			{
				return;
			}
			if (num2 != 0)
			{
				int num4 = num3 / num2;
				int num5 = 0;
				for (int j = intStart; j < intStop; j++)
				{
					sizeProxy.Strip = arrStrips[j];
					if (!IsAbsolutelySized(j, objStyles) && sizeProxy.Size == 0)
					{
						num5++;
						if (num5 == num2)
						{
							num4 = num3 - num4 * (num2 - 1);
						}
						sizeProxy.Size += num4;
						arrStrips[j] = sizeProxy.Strip;
					}
				}
				return;
			}
			int num6 = intStop - 1;
			while (num6 >= intStart && (num6 >= objStyles.Count || ((TableLayoutStyle)objStyles[num6]).SizeType != SizeType.Percent))
			{
				num6--;
			}
			if (num6 != intStart - 1)
			{
				intStop = num6 + 1;
			}
			for (int num7 = intStop - 1; num7 >= intStart; num7--)
			{
				if (!IsAbsolutelySized(num7, objStyles))
				{
					sizeProxy.Strip = arrStrips[num7];
					if (num7 != arrStrips.Length - 1 && !arrStrips[num7 + 1].IsStart && !IsAbsolutelySized(num7 + 1, objStyles))
					{
						sizeProxy.Strip = arrStrips[num7 + 1];
						int num8 = Math.Min(sizeProxy.Size, num3);
						sizeProxy.Size -= num8;
						arrStrips[num7 + 1] = sizeProxy.Strip;
						sizeProxy.Strip = arrStrips[num7];
					}
					sizeProxy.Size += num3;
					arrStrips[num7] = sizeProxy.Strip;
					break;
				}
			}
		}

		internal static void ClearCachedAssignments(ContainerInfo objContainerInfo)
		{
			objContainerInfo.Valid = false;
		}

		internal static TableLayoutSettings CreateSettings(IArrangedElement objOwner)
		{
			return new TableLayoutSettings(objOwner);
		}

		internal static ContainerInfo GetContainerInfo(IArrangedElement objContainer)
		{
			ContainerInfo containerInfo = objContainer.GetValue(Control.ContainerInfoProperty);
			if (containerInfo == null)
			{
				containerInfo = new ContainerInfo(objContainer);
				objContainer.SetValue(Control.ContainerInfoProperty, containerInfo);
			}
			return containerInfo;
		}

		internal IArrangedElement GetControlFromPosition(IArrangedElement objContainer, int intColumn, int intRow)
		{
			if (intRow < 0)
			{
				throw new ArgumentException(SR.GetString("InvalidArgument", "RowPosition", intRow.ToString(CultureInfo.CurrentCulture)));
			}
			if (intColumn < 0)
			{
				throw new ArgumentException(SR.GetString("InvalidArgument", "ColumnPosition", intColumn.ToString(CultureInfo.CurrentCulture)));
			}
			ArrangedElementCollection children = objContainer.Children;
			ContainerInfo containerInfo = GetContainerInfo(objContainer);
			if (children != null && children.Count != 0)
			{
				if (!containerInfo.Valid)
				{
					EnsureRowAndColumnAssignments(objContainer, containerInfo, blnDoNotCache: true);
				}
				for (int i = 0; i < children.Count; i++)
				{
					LayoutInfo layoutInfo = GetLayoutInfo(children[i]);
					if (layoutInfo.ColumnStart <= intColumn && layoutInfo.ColumnStart + layoutInfo.ColumnSpan - 1 >= intColumn && layoutInfo.RowStart <= intRow && layoutInfo.RowStart + layoutInfo.RowSpan - 1 >= intRow)
					{
						return layoutInfo.Element;
					}
				}
			}
			return null;
		}

		internal static LayoutInfo GetLayoutInfo(IArrangedElement objElement)
		{
			LayoutInfo layoutInfo = objElement.GetValue(Control.LayoutInfoProperty);
			if (layoutInfo == null)
			{
				layoutInfo = new LayoutInfo(objElement);
				SetLayoutInfo(objElement, layoutInfo);
			}
			return layoutInfo;
		}

		internal TableLayoutPanelCellPosition GetPositionFromControl(IArrangedElement objContainer, IArrangedElement objChild)
		{
			if (objContainer == null || objChild == null)
			{
				return new TableLayoutPanelCellPosition(-1, -1);
			}
			ArrangedElementCollection children = objContainer.Children;
			ContainerInfo containerInfo = GetContainerInfo(objContainer);
			if (children == null || children.Count == 0)
			{
				return new TableLayoutPanelCellPosition(-1, -1);
			}
			if (!containerInfo.Valid)
			{
				EnsureRowAndColumnAssignments(objContainer, containerInfo, blnDoNotCache: true);
			}
			LayoutInfo layoutInfo = GetLayoutInfo(objChild);
			return new TableLayoutPanelCellPosition(layoutInfo.ColumnStart, layoutInfo.RowStart);
		}

		internal override Size GetPreferredSize(IArrangedElement objContainer, Size objProposedConstraints)
		{
			ContainerInfo containerInfo = GetContainerInfo(objContainer);
			bool blnIsValid = false;
			float num = -1f;
			Size cachedPreferredSize = containerInfo.GetCachedPreferredSize(objProposedConstraints, out blnIsValid);
			if (blnIsValid)
			{
				return cachedPreferredSize;
			}
			ContainerInfo containerInfo2 = new ContainerInfo(containerInfo);
			int cellBorderWidth = containerInfo.CellBorderWidth;
			if (containerInfo.MaxColumns == 1 && containerInfo.ColumnStyles.Count > 0 && containerInfo.ColumnStyles[0].SizeType == SizeType.Absolute)
			{
				Size size = GetElementBounds(objContainer).Size - new Size(cellBorderWidth * 2, cellBorderWidth * 2);
				size.Width = Math.Max(size.Width, 1);
				size.Height = Math.Max(size.Height, 1);
				num = containerInfo.ColumnStyles[0].Size;
				containerInfo.ColumnStyles[0].SetSize(Math.Max(num, Math.Min(objProposedConstraints.Width, size.Width)));
			}
			EnsureRowAndColumnAssignments(objContainer, containerInfo2, blnDoNotCache: true);
			Size size2 = new Size(cellBorderWidth, cellBorderWidth);
			objProposedConstraints -= size2;
			objProposedConstraints.Width = Math.Max(objProposedConstraints.Width, 1);
			objProposedConstraints.Height = Math.Max(objProposedConstraints.Height, 1);
			if (containerInfo2.Columns != null && containerInfo.Columns != null && containerInfo2.Columns.Length != containerInfo.Columns.Length)
			{
				ClearCachedAssignments(containerInfo);
			}
			if (containerInfo2.Rows != null && containerInfo.Rows != null && containerInfo2.Rows.Length != containerInfo.Rows.Length)
			{
				ClearCachedAssignments(containerInfo);
			}
			cachedPreferredSize = ApplyStyles(containerInfo2, objProposedConstraints, blnMeasureOnly: true);
			if (num >= 0f)
			{
				containerInfo.ColumnStyles[0].SetSize(num);
			}
			return cachedPreferredSize + size2;
		}

		internal static bool HasCachedAssignments(ContainerInfo objContainerInfo)
		{
			return objContainerInfo.Valid;
		}

		internal override bool LayoutCore(IArrangedElement objContainer, LayoutEventArgs objArgs)
		{
			ProcessSuspendedLayoutEventArgs(objContainer, objArgs);
			ContainerInfo containerInfo = GetContainerInfo(objContainer);
			EnsureRowAndColumnAssignments(objContainer, containerInfo, blnDoNotCache: false);
			int cellBorderWidth = containerInfo.CellBorderWidth;
			Size size = GetElementBounds(objContainer).Size - new Size(cellBorderWidth, cellBorderWidth);
			size.Width = Math.Max(size.Width, 1);
			size.Height = Math.Max(size.Height, 1);
			Size objUsedSpace = ApplyStyles(containerInfo, size, blnMeasureOnly: false);
			ExpandLastElement(containerInfo, objUsedSpace, size);
			RectangleF displayRectF = GetElementBounds(objContainer);
			displayRectF.Inflate(0f - (float)cellBorderWidth / 2f, (float)(-cellBorderWidth) / 2f);
			SetElementBounds(containerInfo, displayRectF);
			mobjSpecifiedBoundsSize = new Size(SumStrips(containerInfo.Columns, 0, containerInfo.Columns.Length), SumStrips(containerInfo.Rows, 0, containerInfo.Rows.Length));
			return mblnIsAutoSize;
		}

		internal override void ProcessSuspendedLayoutEventArgs(IArrangedElement objContainer, LayoutEventArgs objArgs)
		{
			ContainerInfo containerInfo = GetContainerInfo(objContainer);
			string[] array = marrPropertiesWhichInvalidateCache;
			foreach (string text in array)
			{
				if ((object)objArgs.AffectedProperty == text)
				{
					ClearCachedAssignments(containerInfo);
					break;
				}
			}
		}

		internal static void SetLayoutInfo(IArrangedElement objElement, LayoutInfo objValue)
		{
			objElement.SetValue(Control.LayoutInfoProperty, objValue);
		}

		internal int SumStrips(Strip[] arrStrips, int intStart, int intSpan)
		{
			int num = 0;
			for (int i = intStart; i < Math.Min(intStart + intSpan, arrStrips.Length); i++)
			{
				Strip strip = arrStrips[i];
				num += strip.MinSize;
			}
			return num;
		}
	}
}
