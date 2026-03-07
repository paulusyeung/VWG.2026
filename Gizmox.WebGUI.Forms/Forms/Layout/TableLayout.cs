// Decompiled with JetBrains decompiler
// Type: Gizmox.WebGUI.Forms.Layout.TableLayout
// Assembly: Gizmox.WebGUI.Forms, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=c508b41386c60f1d
// MVID: D9031956-0D2D-4DB7-BDA0-E996D0722B6C
// Assembly location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.dll
// XML documentation location: C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.xml

using Gizmox.WebGUI.Forms.Serialization;
using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;

namespace Gizmox.WebGUI.Forms.Layout
{
  [Serializable]
  internal class TableLayout : LayoutEngine
  {
    private static string[] marrPropertiesWhichInvalidateCache;
    internal static readonly TableLayout Instance = new TableLayout();
    private bool mblnIsAutoSize = true;
    private Padding mobjMargins = new Padding(0);
    private Size mobjSpecifiedBoundsSize = new Size(50, 50);

    static TableLayout() => TableLayout.marrPropertiesWhichInvalidateCache = new string[9]
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

    private void AdvanceUntilFits(
      int intMaxColumns,
      TableLayout.ReservationGrid objReservationGrid,
      TableLayout.LayoutInfo objLayoutInfo,
      out int colStop)
    {
      int rowStart = objLayoutInfo.RowStart;
      do
      {
        this.GetColStartAndStop(intMaxColumns, objReservationGrid, objLayoutInfo, out colStop);
      }
      while (this.ScanRowForOverlap(intMaxColumns, objReservationGrid, objLayoutInfo, colStop, objLayoutInfo.RowStart - rowStart));
    }

    private Size ApplyStyles(
      TableLayout.ContainerInfo objContainerInfo,
      Size objProposedConstraints,
      bool blnMeasureOnly)
    {
      Size empty = Size.Empty;
      this.InitializeStrips(objContainerInfo.Columns, (IList) objContainerInfo.ColumnStyles);
      this.InitializeStrips(objContainerInfo.Rows, (IList) objContainerInfo.RowStyles);
      objContainerInfo.ChildHasColumnSpan = false;
      objContainerInfo.ChildHasRowSpan = false;
      foreach (TableLayout.LayoutInfo layoutInfo in objContainerInfo.ChildrenInfo)
      {
        objContainerInfo.Columns[layoutInfo.ColumnStart].IsStart = true;
        objContainerInfo.Rows[layoutInfo.RowStart].IsStart = true;
        if (layoutInfo.ColumnSpan > 1)
          objContainerInfo.ChildHasColumnSpan = true;
        if (layoutInfo.RowSpan > 1)
          objContainerInfo.ChildHasRowSpan = true;
      }
      empty.Width = this.InflateColumns(objContainerInfo, objProposedConstraints, blnMeasureOnly);
      int intExpandLastElementWidth = Math.Max(0, objProposedConstraints.Width - empty.Width);
      empty.Height = this.InflateRows(objContainerInfo, objProposedConstraints, intExpandLastElementWidth, blnMeasureOnly);
      return empty;
    }

    internal void AssignRowsAndColumns(TableLayout.ContainerInfo objContainerInfo)
    {
      int num1 = objContainerInfo.MaxColumns;
      int num2 = objContainerInfo.MaxRows;
      TableLayout.LayoutInfo[] childrenInfo = objContainerInfo.ChildrenInfo;
      int minRowsAndColumns = objContainerInfo.MinRowsAndColumns;
      int minColumns = objContainerInfo.MinColumns;
      int minRows = objContainerInfo.MinRows;
      TableLayoutPanelGrowStyle growStyle = objContainerInfo.GrowStyle;
      switch (growStyle)
      {
        case TableLayoutPanelGrowStyle.FixedSize:
          if (objContainerInfo.MinRowsAndColumns > num1 * num2)
            throw new ArgumentException(Gizmox.WebGUI.Forms.SR.GetString("TableLayoutPanelFullDesc"));
          if (minColumns > num1 || minRows > num2)
            throw new ArgumentException(Gizmox.WebGUI.Forms.SR.GetString("TableLayoutPanelSpanDesc"));
          num2 = Math.Max(1, num2);
          num1 = Math.Max(1, num1);
          break;
        case TableLayoutPanelGrowStyle.AddRows:
          num2 = 0;
          break;
        default:
          num1 = 0;
          break;
      }
      if (num1 > 0)
        this.xAssignRowsAndColumns(objContainerInfo, childrenInfo, num1, num2 == 0 ? int.MaxValue : num2, growStyle);
      else if (num2 > 0)
      {
        int intMaxColumns = Math.Max(Math.Max((int) Math.Ceiling((double) minRowsAndColumns / (double) num2), minColumns), 1);
        while (!this.xAssignRowsAndColumns(objContainerInfo, childrenInfo, intMaxColumns, num2, growStyle))
          ++intMaxColumns;
      }
      else
        this.xAssignRowsAndColumns(objContainerInfo, childrenInfo, Math.Max(minColumns, 1), int.MaxValue, growStyle);
    }

    [Conditional("DEBUG_LAYOUT")]
    private void Debug_VerifyAssignmentsAreCurrent(
      IArrangedElement objContainer,
      TableLayout.ContainerInfo objContainerInfo)
    {
    }

    [Conditional("DEBUG_LAYOUT")]
    private void Debug_VerifyNoOverlapping(IArrangedElement objContainer)
    {
      ArrayList arrayList = new ArrayList(objContainer.Children.Count);
      TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(objContainer);
      TableLayout.Strip[] rows = containerInfo.Rows;
      TableLayout.Strip[] columns = containerInfo.Columns;
      foreach (IArrangedElement child in objContainer.Children)
      {
        if (TableLayout.ElementParticipatesInLayout(child))
          arrayList.Add((object) TableLayout.GetLayoutInfo(child));
      }
      for (int index1 = 0; index1 < arrayList.Count; ++index1)
      {
        TableLayout.LayoutInfo layoutInfo1 = (TableLayout.LayoutInfo) arrayList[index1];
        Rectangle elementBounds1 = this.GetElementBounds(layoutInfo1.Element);
        Rectangle rectangle1 = new Rectangle(layoutInfo1.ColumnStart, layoutInfo1.RowStart, layoutInfo1.ColumnSpan, layoutInfo1.RowSpan);
        for (int index2 = index1 + 1; index2 < arrayList.Count; ++index2)
        {
          TableLayout.LayoutInfo layoutInfo2 = (TableLayout.LayoutInfo) arrayList[index2];
          Rectangle elementBounds2 = this.GetElementBounds(layoutInfo2.Element);
          Rectangle rectangle2 = new Rectangle(layoutInfo2.ColumnStart, layoutInfo2.RowStart, layoutInfo2.ColumnSpan, layoutInfo2.RowSpan);
          if (LayoutUtils.IsIntersectHorizontally(elementBounds1, elementBounds2))
          {
            int columnStart1 = layoutInfo1.ColumnStart;
            while (columnStart1 < layoutInfo1.ColumnStart + layoutInfo1.ColumnSpan)
              ++columnStart1;
            int columnStart2 = layoutInfo2.ColumnStart;
            while (columnStart2 < layoutInfo2.ColumnStart + layoutInfo2.ColumnSpan)
              ++columnStart2;
          }
          if (LayoutUtils.IsIntersectVertically(elementBounds1, elementBounds2))
          {
            int rowStart1 = layoutInfo1.RowStart;
            while (rowStart1 < layoutInfo1.RowStart + layoutInfo1.RowSpan)
              ++rowStart1;
            int rowStart2 = layoutInfo2.RowStart;
            while (rowStart2 < layoutInfo2.RowStart + layoutInfo2.RowSpan)
              ++rowStart2;
          }
        }
      }
    }

    private void DistributeSize(
      IList objStyles,
      TableLayout.Strip[] arrStrips,
      int intStart,
      int intStop,
      int intMin,
      int intMax,
      int cellBorderWidth)
    {
      this.xDistributeSize(objStyles, arrStrips, intStart, intStop, intMin, (TableLayout.SizeProxy) TableLayout.MinSizeProxy.GetInstance, cellBorderWidth);
      this.xDistributeSize(objStyles, arrStrips, intStart, intStop, intMax, (TableLayout.SizeProxy) TableLayout.MaxSizeProxy.GetInstance, cellBorderWidth);
    }

    private int DistributeStyles(
      int cellBorderWidth,
      IList objStyles,
      TableLayout.Strip[] arrStrips,
      int intMaxSize,
      bool blnDontHonorConstraint)
    {
      int num1 = 0;
      float a = 0.0f;
      float num2 = 0.0f;
      float num3 = 0.0f;
      float num4 = 0.0f;
      bool flag = false;
      for (int index = 0; index < arrStrips.Length; ++index)
      {
        TableLayout.Strip arrStrip = arrStrips[index];
        if (index < objStyles.Count)
        {
          TableLayoutStyle objStyle = (TableLayoutStyle) objStyles[index];
          switch (objStyle.SizeType)
          {
            case SizeType.Absolute:
              num4 += (float) arrStrip.MinSize;
              break;
            case SizeType.Percent:
              num2 += objStyle.Size;
              num3 += (float) arrStrip.MinSize;
              break;
            default:
              num4 += (float) arrStrip.MinSize;
              flag = true;
              break;
          }
        }
        else
          flag = true;
        arrStrip.MaxSize += cellBorderWidth;
        arrStrip.MinSize += cellBorderWidth;
        arrStrips[index] = arrStrip;
        num1 += arrStrip.MinSize;
      }
      int num5 = intMaxSize - num1;
      if ((double) num2 > 0.0)
      {
        if (!blnDontHonorConstraint)
        {
          if ((double) num3 > (double) intMaxSize - (double) num4)
            num3 = Math.Max(0.0f, (float) intMaxSize - num4);
          if (num5 > 0)
            num3 += (float) num5;
          else if (num5 < 0)
            num3 = (float) intMaxSize - num4 - (float) (arrStrips.Length * cellBorderWidth);
          for (int index = 0; index < arrStrips.Length; ++index)
          {
            TableLayout.Strip arrStrip = arrStrips[index];
            if ((index < objStyles.Count ? (int) ((TableLayoutStyle) objStyles[index]).SizeType : 0) == 2)
            {
              int num6 = (int) ((double) ((TableLayoutStyle) objStyles[index]).Size * (double) num3 / (double) num2);
              num1 = num1 - arrStrip.MinSize + (num6 + cellBorderWidth);
              arrStrip.MinSize = num6 + cellBorderWidth;
              arrStrips[index] = arrStrip;
            }
          }
        }
        else
        {
          int val1 = 0;
          for (int index = 0; index < arrStrips.Length; ++index)
          {
            TableLayout.Strip arrStrip = arrStrips[index];
            if ((index < objStyles.Count ? (int) ((TableLayoutStyle) objStyles[index]).SizeType : 0) == 2)
            {
              TableLayoutStyle objStyle = (TableLayoutStyle) objStyles[index];
              int val2 = (int) Math.Round((double) arrStrip.MinSize * (double) num2 / (double) objStyle.Size);
              val1 = Math.Max(val1, val2);
              num1 -= arrStrip.MinSize;
            }
          }
          num1 += val1;
        }
      }
      int num7 = intMaxSize - num1;
      if (flag && num7 > 0)
      {
        if ((double) num7 < (double) a)
        {
          double num8 = (double) num7 / (double) a;
        }
        int val2 = num7 - (int) Math.Ceiling((double) a);
        for (int index = 0; index < arrStrips.Length; ++index)
        {
          TableLayout.Strip arrStrip = arrStrips[index];
          if ((index < objStyles.Count ? (int) ((TableLayoutStyle) objStyles[index]).SizeType : 0) == 0)
          {
            int num9 = Math.Min(arrStrip.MaxSize - arrStrip.MinSize, val2);
            if (num9 > 0)
            {
              num1 += num9;
              val2 -= num9;
              arrStrip.MinSize += num9;
              arrStrips[index] = arrStrip;
            }
          }
        }
      }
      return num1;
    }

    private static bool ElementParticipatesInLayout(IArrangedElement objElement)
    {
      bool flag = false;
      if (objElement != null && objElement is Control)
        flag = ((Control) objElement).Visible;
      return flag;
    }

    private void EnsureRowAndColumnAssignments(
      IArrangedElement objContainer,
      TableLayout.ContainerInfo objContainerInfo,
      bool blnDoNotCache)
    {
      if (!(!TableLayout.HasCachedAssignments(objContainerInfo) | blnDoNotCache))
        return;
      this.AssignRowsAndColumns(objContainerInfo);
    }

    private void ExpandLastElement(
      TableLayout.ContainerInfo objContainerInfo,
      Size objUsedSpace,
      Size objTotalSpace)
    {
      TableLayout.Strip[] rows = objContainerInfo.Rows;
      TableLayout.Strip[] columns = objContainerInfo.Columns;
      if (columns.Length != 0 && objTotalSpace.Width > objUsedSpace.Width)
      {
        TableLayout.Strip[] stripArray = columns;
        stripArray[stripArray.Length - 1].MinSize += objTotalSpace.Width - objUsedSpace.Width;
      }
      if (rows.Length == 0 || objTotalSpace.Height <= objUsedSpace.Height)
        return;
      TableLayout.Strip[] stripArray1 = rows;
      stripArray1[stripArray1.Length - 1].MinSize += objTotalSpace.Height - objUsedSpace.Height;
    }

    private void GetColStartAndStop(
      int intMaxColumns,
      TableLayout.ReservationGrid objReservationGrid,
      TableLayout.LayoutInfo objLayoutInfo,
      out int colStop)
    {
      colStop = objLayoutInfo.ColumnStart + objLayoutInfo.ColumnSpan;
      if (colStop <= intMaxColumns)
        return;
      if (objLayoutInfo.ColumnStart != 0)
      {
        objLayoutInfo.ColumnStart = 0;
        ++objLayoutInfo.RowStart;
      }
      colStop = Math.Min(objLayoutInfo.ColumnSpan, intMaxColumns);
    }

    private Rectangle GetElementBounds(IArrangedElement objArrangedElement)
    {
      Rectangle elementBounds = new Rectangle();
      if (objArrangedElement != null && objArrangedElement is Control)
        elementBounds = new Rectangle(((Control) objArrangedElement).Location, ((Control) objArrangedElement).Size);
      return elementBounds;
    }

    private Size GetElementSize(IArrangedElement objElement, Size objProposedConstraints) => this.mblnIsAutoSize && objElement != null && objElement is Control ? ((Control) objElement).Size : this.mobjSpecifiedBoundsSize;

    private static TableLayout.LayoutInfo GetNextLayoutInfo(
      TableLayout.LayoutInfo[] arrLayoutInfo,
      ref int index,
      bool blnAbsolutelyPositioned)
    {
      for (int index1 = ++index; index1 < arrLayoutInfo.Length; ++index1)
      {
        if (blnAbsolutelyPositioned == arrLayoutInfo[index1].IsAbsolutelyPositioned)
        {
          index = index1;
          return arrLayoutInfo[index1];
        }
      }
      index = arrLayoutInfo.Length;
      return (TableLayout.LayoutInfo) null;
    }

    private int InflateColumns(
      TableLayout.ContainerInfo objContainerInfo,
      Size objProposedConstraints,
      bool blnMeasureOnly)
    {
      bool blnDontHonorConstraint = blnMeasureOnly;
      TableLayout.LayoutInfo[] childrenInfo = objContainerInfo.ChildrenInfo;
      if (objContainerInfo.ChildHasColumnSpan)
        Array.Sort((Array) childrenInfo, (IComparer) TableLayout.ColumnSpanComparer.GetInstance);
      if (blnDontHonorConstraint && objProposedConstraints.Width < (int) short.MaxValue && objContainerInfo.Container is TableLayoutPanel container && container.ParentInternal != null)
      {
        if (container.Dock == DockStyle.Top || container.Dock == DockStyle.Bottom || container.Dock == DockStyle.Fill)
          blnDontHonorConstraint = false;
        if ((container.Anchor & (AnchorStyles.Left | AnchorStyles.Right)) == (AnchorStyles.Left | AnchorStyles.Right))
          blnDontHonorConstraint = false;
      }
      foreach (TableLayout.LayoutInfo layoutInfo in childrenInfo)
      {
        IArrangedElement element = layoutInfo.Element;
        int columnSpan = layoutInfo.ColumnSpan;
        if (columnSpan > 1 || !this.IsAbsolutelySized(layoutInfo.ColumnStart, (IList) objContainerInfo.ColumnStyles))
        {
          Size elementSize;
          int width;
          int num;
          if (columnSpan == 1 && layoutInfo.RowSpan == 1 && this.IsAbsolutelySized(layoutInfo.RowStart, (IList) objContainerInfo.RowStyles))
          {
            int size = (int) objContainerInfo.RowStyles[layoutInfo.RowStart].Size;
            elementSize = this.GetElementSize(element, new Size(0, size));
            width = elementSize.Width;
            num = width;
          }
          else
          {
            elementSize = this.GetElementSize(element, new Size(1, 0));
            width = elementSize.Width;
            elementSize = this.GetElementSize(element, Size.Empty);
            num = elementSize.Width;
          }
          Padding mobjMargins = this.mobjMargins;
          int intMin = width + mobjMargins.Horizontal;
          int intMax = num + mobjMargins.Horizontal;
          int intStop = Math.Min(layoutInfo.ColumnStart + layoutInfo.ColumnSpan, objContainerInfo.Columns.Length);
          this.DistributeSize((IList) objContainerInfo.ColumnStyles, objContainerInfo.Columns, layoutInfo.ColumnStart, intStop, intMin, intMax, objContainerInfo.CellBorderWidth);
        }
      }
      int num1 = this.DistributeStyles(objContainerInfo.CellBorderWidth, (IList) objContainerInfo.ColumnStyles, objContainerInfo.Columns, objProposedConstraints.Width, blnDontHonorConstraint);
      if (!blnDontHonorConstraint || num1 <= objProposedConstraints.Width || objProposedConstraints.Width <= 1)
        return num1;
      TableLayout.Strip[] columns = objContainerInfo.Columns;
      float num2 = 0.0f;
      int val2 = 0;
      TableLayoutStyleCollection columnStyles = (TableLayoutStyleCollection) objContainerInfo.ColumnStyles;
      for (int index = 0; index < columns.Length; ++index)
      {
        TableLayout.Strip strip = columns[index];
        if (index < columnStyles.Count)
        {
          TableLayoutStyle tableLayoutStyle = columnStyles[index];
          if (tableLayoutStyle.SizeType == SizeType.Percent)
          {
            num2 += tableLayoutStyle.Size;
            val2 += strip.MinSize;
          }
        }
      }
      int num3 = Math.Min(num1 - objProposedConstraints.Width, val2);
      for (int index = 0; index < columns.Length; ++index)
      {
        if (index < columnStyles.Count)
        {
          TableLayoutStyle tableLayoutStyle = columnStyles[index];
          if (tableLayoutStyle.SizeType == SizeType.Percent)
          {
            float num4 = tableLayoutStyle.Size / num2;
            columns[index].MinSize -= (int) ((double) num4 * (double) num3);
          }
        }
      }
      return num1 - num3;
    }

    private int InflateRows(
      TableLayout.ContainerInfo objContainerInfo,
      Size objProposedConstraints,
      int intExpandLastElementWidth,
      bool blnMeasureOnly)
    {
      bool blnDontHonorConstraint = blnMeasureOnly;
      TableLayout.LayoutInfo[] childrenInfo = objContainerInfo.ChildrenInfo;
      if (objContainerInfo.ChildHasRowSpan)
        Array.Sort((Array) childrenInfo, (IComparer) TableLayout.RowSpanComparer.GetInstance);
      bool multiplePercentColumns = objContainerInfo.HasMultiplePercentColumns;
      if (blnDontHonorConstraint && objProposedConstraints.Height < (int) short.MaxValue && objContainerInfo.Container is TableLayoutPanel container && container.ParentInternal != null)
      {
        if (container.Dock == DockStyle.Left || container.Dock == DockStyle.Right || container.Dock == DockStyle.Fill)
          blnDontHonorConstraint = false;
        if ((container.Anchor & (AnchorStyles.Bottom | AnchorStyles.Top)) == (AnchorStyles.Bottom | AnchorStyles.Top))
          blnDontHonorConstraint = false;
      }
      foreach (TableLayout.LayoutInfo layoutInfo in childrenInfo)
      {
        IArrangedElement element = layoutInfo.Element;
        if (layoutInfo.RowSpan > 1 || !this.IsAbsolutelySized(layoutInfo.RowStart, (IList) objContainerInfo.RowStyles))
        {
          int num = this.SumStrips(objContainerInfo.Columns, layoutInfo.ColumnStart, layoutInfo.ColumnSpan);
          if (!blnDontHonorConstraint && layoutInfo.ColumnStart + layoutInfo.ColumnSpan >= objContainerInfo.MaxColumns && !multiplePercentColumns)
            num += intExpandLastElementWidth;
          Padding mobjMargins = this.mobjMargins;
          int intMin = this.GetElementSize(element, new Size(num - mobjMargins.Horizontal, 0)).Height + mobjMargins.Vertical;
          int intMax = intMin;
          int intStop = Math.Min(layoutInfo.RowStart + layoutInfo.RowSpan, objContainerInfo.Rows.Length);
          this.DistributeSize((IList) objContainerInfo.RowStyles, objContainerInfo.Rows, layoutInfo.RowStart, intStop, intMin, intMax, objContainerInfo.CellBorderWidth);
        }
      }
      return this.DistributeStyles(objContainerInfo.CellBorderWidth, (IList) objContainerInfo.RowStyles, objContainerInfo.Rows, objProposedConstraints.Height, blnDontHonorConstraint);
    }

    private void InitializeStrips(TableLayout.Strip[] arrStrips, IList objStyles)
    {
      for (int index = 0; index < arrStrips.Length; ++index)
      {
        TableLayoutStyle objStyle = index < objStyles.Count ? (TableLayoutStyle) objStyles[index] : (TableLayoutStyle) null;
        TableLayout.Strip arrStrip = arrStrips[index];
        if (objStyle != null && objStyle.SizeType == SizeType.Absolute)
        {
          arrStrip.MinSize = (int) Math.Round((double) ((TableLayoutStyle) objStyles[index]).Size);
          ref TableLayout.Strip local = ref arrStrip;
          local.MaxSize = local.MinSize;
        }
        else
        {
          arrStrip.MinSize = 0;
          arrStrip.MaxSize = 0;
        }
        arrStrip.IsStart = false;
        arrStrips[index] = arrStrip;
      }
    }

    private bool IsAbsolutelySized(int index, IList objStyles) => index < objStyles.Count && ((TableLayoutStyle) objStyles[index]).SizeType == SizeType.Absolute;

    private bool IsCursorPastInsertionPoint(
      TableLayout.LayoutInfo fixedLayoutInfo,
      int insertionRow,
      int insertionCol)
    {
      if (fixedLayoutInfo.RowPosition < insertionRow)
        return true;
      return fixedLayoutInfo.RowPosition == insertionRow && fixedLayoutInfo.ColumnPosition < insertionCol;
    }

    private bool IsOverlappingWithReservationGrid(
      TableLayout.LayoutInfo fixedLayoutInfo,
      TableLayout.ReservationGrid objReservationGrid,
      int intCurrentRow)
    {
      if (fixedLayoutInfo.RowPosition < intCurrentRow)
        return true;
      for (int intRowOffset = fixedLayoutInfo.RowPosition - intCurrentRow; intRowOffset < fixedLayoutInfo.RowPosition - intCurrentRow + fixedLayoutInfo.RowSpan; ++intRowOffset)
      {
        for (int columnPosition = fixedLayoutInfo.ColumnPosition; columnPosition < fixedLayoutInfo.ColumnPosition + fixedLayoutInfo.ColumnSpan; ++columnPosition)
        {
          if (objReservationGrid.IsReserved(columnPosition, intRowOffset))
            return true;
        }
      }
      return false;
    }

    private bool ScanRowForOverlap(
      int intMaxColumns,
      TableLayout.ReservationGrid objReservationGrid,
      TableLayout.LayoutInfo layoutInfo,
      int intStopCol,
      int intRowOffset)
    {
      for (int columnStart = layoutInfo.ColumnStart; columnStart < intStopCol; ++columnStart)
      {
        if (objReservationGrid.IsReserved(columnStart, intRowOffset))
        {
          layoutInfo.ColumnStart = columnStart + 1;
          while (layoutInfo.ColumnStart < intMaxColumns && objReservationGrid.IsReserved(layoutInfo.ColumnStart, intRowOffset))
            ++layoutInfo.ColumnStart;
          return true;
        }
      }
      return false;
    }

    private Rectangle SetElementBounds(IArrangedElement objArrangedElement, Rectangle objRectangle)
    {
      if (objArrangedElement != null && objArrangedElement is Control)
      {
        ((Control) objArrangedElement).Location = objRectangle.Location;
        ((Control) objArrangedElement).Size = objRectangle.Size;
      }
      return objRectangle;
    }

    private void SetElementBounds(
      TableLayout.ContainerInfo objContainerInfo,
      RectangleF displayRectF)
    {
      int cellBorderWidth = objContainerInfo.CellBorderWidth;
      float y = displayRectF.Y;
      int index1 = 0;
      int index2 = 0;
      bool flag = false;
      Rectangle.Truncate(displayRectF);
      if (objContainerInfo.Container is Control)
        flag = (objContainerInfo.Container as Control).RightToLeft == RightToLeft.Yes;
      TableLayout.LayoutInfo[] childrenInfo = objContainerInfo.ChildrenInfo;
      float num1 = flag ? displayRectF.Right : displayRectF.X;
      Array.Sort((Array) childrenInfo, (IComparer) TableLayout.PostAssignedPositionComparer.GetInstance);
      for (int index3 = 0; index3 < childrenInfo.Length; ++index3)
      {
        TableLayout.LayoutInfo layoutInfo = childrenInfo[index3];
        IArrangedElement element = layoutInfo.Element;
        if (index2 != layoutInfo.RowStart)
        {
          for (; index2 < layoutInfo.RowStart; ++index2)
            y += (float) objContainerInfo.Rows[index2].MinSize;
          num1 = flag ? displayRectF.Right : displayRectF.X;
          index1 = 0;
        }
        for (; index1 < layoutInfo.ColumnStart; ++index1)
        {
          if (flag)
            num1 -= (float) objContainerInfo.Columns[index1].MinSize;
          else
            num1 += (float) objContainerInfo.Columns[index1].MinSize;
        }
        int num2 = index1 + layoutInfo.ColumnSpan;
        int num3 = 0;
        for (; index1 < num2 && index1 < objContainerInfo.Columns.Length; ++index1)
          num3 += objContainerInfo.Columns[index1].MinSize;
        if (flag)
          num1 -= (float) num3;
        int num4 = index2 + layoutInfo.RowSpan;
        int num5 = 0;
        for (int index4 = index2; index4 < num4 && index4 < objContainerInfo.Rows.Length; ++index4)
          num5 += objContainerInfo.Rows[index4].MinSize;
        Rectangle rectangle = new Rectangle((int) ((double) num1 + (double) cellBorderWidth / 2.0), (int) ((double) y + (double) cellBorderWidth / 2.0), num3 - cellBorderWidth, num5 - cellBorderWidth);
        Padding mobjMargins = this.mobjMargins;
        if (flag)
        {
          int right = mobjMargins.Right;
          ref Padding local = ref mobjMargins;
          local.Right = local.Left;
          mobjMargins.Left = right;
        }
        rectangle = LayoutUtils.DeflateRect(rectangle, mobjMargins);
        rectangle.Width = Math.Max(rectangle.Width, 1);
        rectangle.Height = Math.Max(rectangle.Height, 1);
        AnchorStyles enmAnchorStyles = AnchorStyles.Left | AnchorStyles.Top;
        if (element is Control)
          enmAnchorStyles = ((Control) element).Anchor;
        Rectangle objRectangle = LayoutUtils.AlignAndStretch(this.GetElementSize(element, rectangle.Size), rectangle, enmAnchorStyles);
        objRectangle.Width = Math.Min(rectangle.Width, objRectangle.Width);
        objRectangle.Height = Math.Min(rectangle.Height, objRectangle.Height);
        if (flag)
          objRectangle.X = rectangle.X + (rectangle.Right - objRectangle.Right);
        this.SetElementBounds(element, objRectangle);
        if (!flag)
          num1 += (float) num3;
      }
    }

    private bool xAssignRowsAndColumns(
      TableLayout.ContainerInfo objContainerInfo,
      TableLayout.LayoutInfo[] arrChildrenInfo,
      int intMaxColumns,
      int intMaxRows,
      TableLayoutPanelGrowStyle enmGrowStyle)
    {
      int num1 = 0;
      int num2 = 0;
      TableLayout.ReservationGrid objReservationGrid = new TableLayout.ReservationGrid();
      int num3 = 0;
      int val2 = 0;
      int index1 = -1;
      int index2 = -1;
      TableLayout.LayoutInfo[] fixedChildrenInfo = objContainerInfo.FixedChildrenInfo;
      TableLayout.LayoutInfo nextLayoutInfo1 = TableLayout.GetNextLayoutInfo(fixedChildrenInfo, ref index1, true);
      TableLayout.LayoutInfo nextLayoutInfo2 = TableLayout.GetNextLayoutInfo(arrChildrenInfo, ref index2, false);
      while (nextLayoutInfo1 != null || nextLayoutInfo2 != null)
      {
        int colStop = val2;
        if (nextLayoutInfo2 != null)
        {
          nextLayoutInfo2.RowStart = num3;
          nextLayoutInfo2.ColumnStart = val2;
          this.AdvanceUntilFits(intMaxColumns, objReservationGrid, nextLayoutInfo2, out colStop);
          if (nextLayoutInfo2.RowStart >= intMaxRows)
            return false;
        }
        int num4;
        if (nextLayoutInfo2 != null && (nextLayoutInfo1 == null || !this.IsCursorPastInsertionPoint(nextLayoutInfo1, nextLayoutInfo2.RowStart, colStop) && !this.IsOverlappingWithReservationGrid(nextLayoutInfo1, objReservationGrid, num3)))
        {
          for (int index3 = 0; index3 < nextLayoutInfo2.RowStart - num3; ++index3)
            objReservationGrid.AdvanceRow();
          num3 = nextLayoutInfo2.RowStart;
          num4 = Math.Min(num3 + nextLayoutInfo2.RowSpan, intMaxRows);
          objReservationGrid.ReserveAll(nextLayoutInfo2, num4, colStop);
          nextLayoutInfo2 = TableLayout.GetNextLayoutInfo(arrChildrenInfo, ref index2, false);
        }
        else
        {
          if (val2 >= intMaxColumns)
          {
            val2 = 0;
            ++num3;
            objReservationGrid.AdvanceRow();
          }
          nextLayoutInfo1.RowStart = Math.Min(nextLayoutInfo1.RowPosition, intMaxRows - 1);
          nextLayoutInfo1.ColumnStart = Math.Min(nextLayoutInfo1.ColumnPosition, intMaxColumns - 1);
          if (num3 > nextLayoutInfo1.RowStart)
            nextLayoutInfo1.ColumnStart = val2;
          else if (num3 == nextLayoutInfo1.RowStart)
            nextLayoutInfo1.ColumnStart = Math.Max(nextLayoutInfo1.ColumnStart, val2);
          nextLayoutInfo1.RowStart = Math.Max(nextLayoutInfo1.RowStart, num3);
          int num5;
          for (num5 = 0; num5 < nextLayoutInfo1.RowStart - num3; ++num5)
            objReservationGrid.AdvanceRow();
          this.AdvanceUntilFits(intMaxColumns, objReservationGrid, nextLayoutInfo1, out colStop);
          if (nextLayoutInfo1.RowStart >= intMaxRows)
            return false;
          for (; num5 < nextLayoutInfo1.RowStart - num3; ++num5)
            objReservationGrid.AdvanceRow();
          num3 = nextLayoutInfo1.RowStart;
          colStop = Math.Min(nextLayoutInfo1.ColumnStart + nextLayoutInfo1.ColumnSpan, intMaxColumns);
          num4 = Math.Min(nextLayoutInfo1.RowStart + nextLayoutInfo1.RowSpan, intMaxRows);
          objReservationGrid.ReserveAll(nextLayoutInfo1, num4, colStop);
          nextLayoutInfo1 = TableLayout.GetNextLayoutInfo(fixedChildrenInfo, ref index1, true);
        }
        val2 = colStop;
        num2 = num2 == int.MaxValue ? num4 : Math.Max(num2, num4);
        num1 = num1 == int.MaxValue ? colStop : Math.Max(num1, colStop);
      }
      int length1;
      int length2;
      switch (enmGrowStyle)
      {
        case TableLayoutPanelGrowStyle.FixedSize:
          length1 = intMaxColumns;
          length2 = intMaxRows;
          break;
        case TableLayoutPanelGrowStyle.AddRows:
          length1 = intMaxColumns;
          length2 = Math.Max(objContainerInfo.MaxRows, num2);
          break;
        default:
          length2 = intMaxRows == int.MaxValue ? num2 : intMaxRows;
          length1 = Math.Max(objContainerInfo.MaxColumns, num1);
          break;
      }
      if (objContainerInfo.Rows == null || objContainerInfo.Rows.Length != length2)
        objContainerInfo.Rows = new TableLayout.Strip[length2];
      if (objContainerInfo.Columns == null || objContainerInfo.Columns.Length != length1)
        objContainerInfo.Columns = new TableLayout.Strip[length1];
      objContainerInfo.Valid = true;
      return true;
    }

    private void xDistributeSize(
      IList objStyles,
      TableLayout.Strip[] arrStrips,
      int intStart,
      int intStop,
      int intDesiredLength,
      TableLayout.SizeProxy sizeProxy,
      int cellBorderWidth)
    {
      int num1 = 0;
      int num2 = 0;
      intDesiredLength -= cellBorderWidth * (intStop - intStart - 1);
      intDesiredLength = Math.Max(0, intDesiredLength);
      for (int index = intStart; index < intStop; ++index)
      {
        sizeProxy.Strip = arrStrips[index];
        if (!this.IsAbsolutelySized(index, objStyles) && sizeProxy.Size == 0)
          ++num2;
        num1 += sizeProxy.Size;
      }
      int val2 = intDesiredLength - num1;
      if (val2 <= 0)
        return;
      if (num2 != 0)
      {
        int num3 = val2 / num2;
        int num4 = 0;
        for (int index = intStart; index < intStop; ++index)
        {
          sizeProxy.Strip = arrStrips[index];
          if (!this.IsAbsolutelySized(index, objStyles) && sizeProxy.Size == 0)
          {
            ++num4;
            if (num4 == num2)
              num3 = val2 - num3 * (num2 - 1);
            sizeProxy.Size += num3;
            arrStrips[index] = sizeProxy.Strip;
          }
        }
      }
      else
      {
        int index1 = intStop - 1;
        while (index1 >= intStart && (index1 >= objStyles.Count || ((TableLayoutStyle) objStyles[index1]).SizeType != SizeType.Percent))
          --index1;
        if (index1 != intStart - 1)
          intStop = index1 + 1;
        for (int index2 = intStop - 1; index2 >= intStart; --index2)
        {
          if (!this.IsAbsolutelySized(index2, objStyles))
          {
            sizeProxy.Strip = arrStrips[index2];
            if (index2 != arrStrips.Length - 1 && !arrStrips[index2 + 1].IsStart && !this.IsAbsolutelySized(index2 + 1, objStyles))
            {
              sizeProxy.Strip = arrStrips[index2 + 1];
              int num5 = Math.Min(sizeProxy.Size, val2);
              sizeProxy.Size -= num5;
              arrStrips[index2 + 1] = sizeProxy.Strip;
              sizeProxy.Strip = arrStrips[index2];
            }
            sizeProxy.Size += val2;
            arrStrips[index2] = sizeProxy.Strip;
            break;
          }
        }
      }
    }

    internal static void ClearCachedAssignments(TableLayout.ContainerInfo objContainerInfo) => objContainerInfo.Valid = false;

    internal static TableLayoutSettings CreateSettings(IArrangedElement objOwner) => new TableLayoutSettings(objOwner);

    internal static TableLayout.ContainerInfo GetContainerInfo(IArrangedElement objContainer)
    {
      TableLayout.ContainerInfo objValue = objContainer.GetValue<TableLayout.ContainerInfo>(Control.ContainerInfoProperty);
      if (objValue == null)
      {
        objValue = new TableLayout.ContainerInfo(objContainer);
        objContainer.SetValue<TableLayout.ContainerInfo>(Control.ContainerInfoProperty, objValue);
      }
      return objValue;
    }

    internal IArrangedElement GetControlFromPosition(
      IArrangedElement objContainer,
      int intColumn,
      int intRow)
    {
      if (intRow < 0)
        throw new ArgumentException(Gizmox.WebGUI.Forms.SR.GetString("InvalidArgument", (object) "RowPosition", (object) intRow.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      if (intColumn < 0)
        throw new ArgumentException(Gizmox.WebGUI.Forms.SR.GetString("InvalidArgument", (object) "ColumnPosition", (object) intColumn.ToString((IFormatProvider) CultureInfo.CurrentCulture)));
      ArrangedElementCollection children = objContainer.Children;
      TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(objContainer);
      if (children != null && children.Count != 0)
      {
        if (!containerInfo.Valid)
          this.EnsureRowAndColumnAssignments(objContainer, containerInfo, true);
        for (int index = 0; index < children.Count; ++index)
        {
          TableLayout.LayoutInfo layoutInfo = TableLayout.GetLayoutInfo(children[index]);
          if (layoutInfo.ColumnStart <= intColumn && layoutInfo.ColumnStart + layoutInfo.ColumnSpan - 1 >= intColumn && layoutInfo.RowStart <= intRow && layoutInfo.RowStart + layoutInfo.RowSpan - 1 >= intRow)
            return layoutInfo.Element;
        }
      }
      return (IArrangedElement) null;
    }

    internal static TableLayout.LayoutInfo GetLayoutInfo(IArrangedElement objElement)
    {
      TableLayout.LayoutInfo objValue = objElement.GetValue<TableLayout.LayoutInfo>(Control.LayoutInfoProperty);
      if (objValue == null)
      {
        objValue = new TableLayout.LayoutInfo(objElement);
        TableLayout.SetLayoutInfo(objElement, objValue);
      }
      return objValue;
    }

    internal TableLayoutPanelCellPosition GetPositionFromControl(
      IArrangedElement objContainer,
      IArrangedElement objChild)
    {
      if (objContainer == null || objChild == null)
        return new TableLayoutPanelCellPosition(-1, -1);
      ArrangedElementCollection children = objContainer.Children;
      TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(objContainer);
      if (children == null || children.Count == 0)
        return new TableLayoutPanelCellPosition(-1, -1);
      if (!containerInfo.Valid)
        this.EnsureRowAndColumnAssignments(objContainer, containerInfo, true);
      TableLayout.LayoutInfo layoutInfo = TableLayout.GetLayoutInfo(objChild);
      return new TableLayoutPanelCellPosition(layoutInfo.ColumnStart, layoutInfo.RowStart);
    }

    internal override Size GetPreferredSize(
      IArrangedElement objContainer,
      Size objProposedConstraints)
    {
      TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(objContainer);
      bool blnIsValid = false;
      float num1 = -1f;
      Size cachedPreferredSize = containerInfo.GetCachedPreferredSize(objProposedConstraints, out blnIsValid);
      if (blnIsValid)
        return cachedPreferredSize;
      TableLayout.ContainerInfo objContainerInfo = new TableLayout.ContainerInfo(containerInfo);
      int cellBorderWidth = containerInfo.CellBorderWidth;
      if (containerInfo.MaxColumns == 1 && containerInfo.ColumnStyles.Count > 0 && containerInfo.ColumnStyles[0].SizeType == SizeType.Absolute)
      {
        Size size = this.GetElementBounds(objContainer).Size - new Size(cellBorderWidth * 2, cellBorderWidth * 2);
        size.Width = Math.Max(size.Width, 1);
        size.Height = Math.Max(size.Height, 1);
        num1 = containerInfo.ColumnStyles[0].Size;
        containerInfo.ColumnStyles[0].SetSize(Math.Max(num1, (float) Math.Min(objProposedConstraints.Width, size.Width)));
      }
      this.EnsureRowAndColumnAssignments(objContainer, objContainerInfo, true);
      Size size1;
      ref Size local = ref size1;
      int num2 = cellBorderWidth;
      local = new Size(num2, num2);
      objProposedConstraints -= size1;
      objProposedConstraints.Width = Math.Max(objProposedConstraints.Width, 1);
      objProposedConstraints.Height = Math.Max(objProposedConstraints.Height, 1);
      if (objContainerInfo.Columns != null && containerInfo.Columns != null && objContainerInfo.Columns.Length != containerInfo.Columns.Length)
        TableLayout.ClearCachedAssignments(containerInfo);
      if (objContainerInfo.Rows != null && containerInfo.Rows != null && objContainerInfo.Rows.Length != containerInfo.Rows.Length)
        TableLayout.ClearCachedAssignments(containerInfo);
      Size size2 = this.ApplyStyles(objContainerInfo, objProposedConstraints, true);
      if ((double) num1 >= 0.0)
        containerInfo.ColumnStyles[0].SetSize(num1);
      return size2 + size1;
    }

    internal static bool HasCachedAssignments(TableLayout.ContainerInfo objContainerInfo) => objContainerInfo.Valid;

    internal override bool LayoutCore(IArrangedElement objContainer, LayoutEventArgs objArgs)
    {
      this.ProcessSuspendedLayoutEventArgs(objContainer, objArgs);
      TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(objContainer);
      this.EnsureRowAndColumnAssignments(objContainer, containerInfo, false);
      int cellBorderWidth = containerInfo.CellBorderWidth;
      Size size1 = this.GetElementBounds(objContainer).Size;
      int num = cellBorderWidth;
      Size size2 = new Size(num, num);
      Size size3 = size1 - size2;
      size3.Width = Math.Max(size3.Width, 1);
      size3.Height = Math.Max(size3.Height, 1);
      Size objUsedSpace = this.ApplyStyles(containerInfo, size3, false);
      this.ExpandLastElement(containerInfo, objUsedSpace, size3);
      RectangleF elementBounds = (RectangleF) this.GetElementBounds(objContainer);
      elementBounds.Inflate((float) -((double) cellBorderWidth / 2.0), (float) -cellBorderWidth / 2f);
      this.SetElementBounds(containerInfo, elementBounds);
      this.mobjSpecifiedBoundsSize = new Size(this.SumStrips(containerInfo.Columns, 0, containerInfo.Columns.Length), this.SumStrips(containerInfo.Rows, 0, containerInfo.Rows.Length));
      return this.mblnIsAutoSize;
    }

    internal override void ProcessSuspendedLayoutEventArgs(
      IArrangedElement objContainer,
      LayoutEventArgs objArgs)
    {
      TableLayout.ContainerInfo containerInfo = TableLayout.GetContainerInfo(objContainer);
      foreach (string str in TableLayout.marrPropertiesWhichInvalidateCache)
      {
        if ((object) objArgs.AffectedProperty == (object) str)
        {
          TableLayout.ClearCachedAssignments(containerInfo);
          break;
        }
      }
    }

    internal static void SetLayoutInfo(IArrangedElement objElement, TableLayout.LayoutInfo objValue) => objElement.SetValue<TableLayout.LayoutInfo>(Control.LayoutInfoProperty, objValue);

    internal int SumStrips(TableLayout.Strip[] arrStrips, int intStart, int intSpan)
    {
      int num = 0;
      for (int index = intStart; index < Math.Min(intStart + intSpan, arrStrips.Length); ++index)
      {
        TableLayout.Strip arrStrip = arrStrips[index];
        num += arrStrip.MinSize;
      }
      return num;
    }

    [Serializable]
    private class ColumnSpanComparer : TableLayout.SpanComparer
    {
      private static readonly TableLayout.ColumnSpanComparer mobjInstance = new TableLayout.ColumnSpanComparer();

      public static TableLayout.ColumnSpanComparer GetInstance => TableLayout.ColumnSpanComparer.mobjInstance;

      public override int GetSpan(TableLayout.LayoutInfo objLayoutInfo) => objLayoutInfo.ColumnSpan;
    }

    [Serializable]
    internal sealed class ContainerInfo : SerializableObject
    {
      private static readonly int mintStateChildHasColumnSpan = SerializableBitVector32.CreateMask(TableLayout.ContainerInfo.mintStateChildInfoValid);
      private static readonly int mintStateChildHasRowSpan = SerializableBitVector32.CreateMask(TableLayout.ContainerInfo.mintStateChildHasColumnSpan);
      private static readonly int mintStateChildInfoValid = SerializableBitVector32.CreateMask(TableLayout.ContainerInfo.mintStateValid);
      private static readonly int mintStateValid = SerializableBitVector32.CreateMask();
      private int mintCellBorderWidth;
      private TableLayout.LayoutInfo[] marrChildInfo;
      private TableLayout.Strip[] marrCols;
      private TableLayoutColumnStyleCollection mobjColStyles;
      private IArrangedElement mobjContainer;
      private int mintCountFixedChildren;
      private TableLayoutPanelGrowStyle menmGrowStyle;
      private int mintMaxColumns;
      private int mintMaxRows;
      private int mintMinColumns;
      private int mintMinRows;
      private int mintMinRowsAndColumns;
      private TableLayout.Strip[] marrRows;
      private TableLayoutRowStyleCollection mobjRowStyles;
      private static TableLayout.Strip[] marrEmptyStrip = new TableLayout.Strip[0];
      private Size mobjPreferredSizeCache = new Size(50, 50);
      private SerializableBitVector32 mobjState;

      public ContainerInfo(IArrangedElement objContainer)
      {
        this.marrCols = TableLayout.ContainerInfo.marrEmptyStrip;
        this.marrRows = TableLayout.ContainerInfo.marrEmptyStrip;
        this.mobjContainer = objContainer;
        this.menmGrowStyle = TableLayoutPanelGrowStyle.AddRows;
      }

      public ContainerInfo(TableLayout.ContainerInfo objContainerInfo)
      {
        this.marrCols = TableLayout.ContainerInfo.marrEmptyStrip;
        this.marrRows = TableLayout.ContainerInfo.marrEmptyStrip;
        this.mintCellBorderWidth = objContainerInfo.CellBorderWidth;
        this.mintMaxRows = objContainerInfo.MaxRows;
        this.mintMaxColumns = objContainerInfo.MaxColumns;
        this.menmGrowStyle = objContainerInfo.GrowStyle;
        this.mobjContainer = objContainerInfo.Container;
        this.mobjRowStyles = objContainerInfo.RowStyles;
        this.mobjColStyles = objContainerInfo.ColumnStyles;
      }

      public int CellBorderWidth
      {
        get => this.mintCellBorderWidth;
        set => this.mintCellBorderWidth = value;
      }

      public bool ChildHasColumnSpan
      {
        get => this.mobjState[TableLayout.ContainerInfo.mintStateChildHasColumnSpan];
        set => this.mobjState[TableLayout.ContainerInfo.mintStateChildHasColumnSpan] = value;
      }

      public bool ChildHasRowSpan
      {
        get => this.mobjState[TableLayout.ContainerInfo.mintStateChildHasRowSpan];
        set => this.mobjState[TableLayout.ContainerInfo.mintStateChildHasRowSpan] = value;
      }

      public bool ChildInfoValid => this.mobjState[TableLayout.ContainerInfo.mintStateChildInfoValid];

      public TableLayout.LayoutInfo[] ChildrenInfo
      {
        get
        {
          if (!this.mobjState[TableLayout.ContainerInfo.mintStateChildInfoValid])
          {
            this.mintCountFixedChildren = 0;
            this.mintMinRowsAndColumns = 0;
            this.mintMinColumns = 0;
            this.mintMinRows = 0;
            ArrangedElementCollection children = this.Container.Children;
            TableLayout.LayoutInfo[] sourceArray = new TableLayout.LayoutInfo[children.Count];
            int num1 = 0;
            int num2 = 0;
            for (int index = 0; index < children.Count; ++index)
            {
              IArrangedElement objElement = children[index];
              if (!TableLayout.ElementParticipatesInLayout(objElement))
              {
                ++num1;
              }
              else
              {
                TableLayout.LayoutInfo layoutInfo = TableLayout.GetLayoutInfo(objElement);
                if (layoutInfo.IsAbsolutelyPositioned)
                  ++this.mintCountFixedChildren;
                sourceArray[num2++] = layoutInfo;
                this.mintMinRowsAndColumns += layoutInfo.RowSpan * layoutInfo.ColumnSpan;
                if (layoutInfo.IsAbsolutelyPositioned)
                {
                  this.mintMinColumns = Math.Max(this.mintMinColumns, layoutInfo.ColumnPosition + layoutInfo.ColumnSpan);
                  this.mintMinRows = Math.Max(this.mintMinRows, layoutInfo.RowPosition + layoutInfo.RowSpan);
                }
              }
            }
            if (num1 > 0)
            {
              TableLayout.LayoutInfo[] destinationArray = new TableLayout.LayoutInfo[sourceArray.Length - num1];
              Array.Copy((Array) sourceArray, (Array) destinationArray, destinationArray.Length);
              this.marrChildInfo = destinationArray;
            }
            else
              this.marrChildInfo = sourceArray;
            this.mobjState[TableLayout.ContainerInfo.mintStateChildInfoValid] = true;
          }
          return this.marrChildInfo != null ? this.marrChildInfo : new TableLayout.LayoutInfo[0];
        }
      }

      public TableLayout.Strip[] Columns
      {
        get => this.marrCols;
        set => this.marrCols = value;
      }

      public TableLayoutColumnStyleCollection ColumnStyles
      {
        get
        {
          if (this.mobjColStyles == null)
            this.mobjColStyles = new TableLayoutColumnStyleCollection(this.mobjContainer);
          return this.mobjColStyles;
        }
        set
        {
          this.mobjColStyles = value;
          if (this.mobjColStyles == null)
            return;
          this.mobjColStyles.EnsureOwnership(this.mobjContainer);
        }
      }

      public IArrangedElement Container => this.mobjContainer;

      public TableLayout.LayoutInfo[] FixedChildrenInfo
      {
        get
        {
          TableLayout.LayoutInfo[] fixedChildrenInfo = new TableLayout.LayoutInfo[this.mintCountFixedChildren];
          if (this.HasChildWithAbsolutePositioning)
          {
            int num = 0;
            for (int index = 0; index < this.marrChildInfo.Length; ++index)
            {
              if (this.marrChildInfo[index].IsAbsolutelyPositioned)
                fixedChildrenInfo[num++] = this.marrChildInfo[index];
            }
            Array.Sort((Array) fixedChildrenInfo, (IComparer) TableLayout.PreAssignedPositionComparer.GetInstance);
          }
          return fixedChildrenInfo;
        }
      }

      public TableLayoutPanelGrowStyle GrowStyle
      {
        get => this.menmGrowStyle;
        set
        {
          if (this.menmGrowStyle == value)
            return;
          this.menmGrowStyle = value;
          this.Valid = false;
        }
      }

      public bool HasChildWithAbsolutePositioning => this.mintCountFixedChildren > 0;

      public bool HasMultiplePercentColumns
      {
        get
        {
          if (this.mobjColStyles != null)
          {
            bool flag = false;
            foreach (TableLayoutStyle mobjColStyle in (IEnumerable) this.mobjColStyles)
            {
              if (mobjColStyle.SizeType == SizeType.Percent)
              {
                if (flag)
                  return true;
                flag = true;
              }
            }
          }
          return false;
        }
      }

      public int MaxColumns
      {
        get => this.mintMaxColumns;
        set
        {
          if (this.mintMaxColumns == value)
            return;
          this.mintMaxColumns = value;
          this.Valid = false;
        }
      }

      public int MaxRows
      {
        get => this.mintMaxRows;
        set
        {
          if (this.mintMaxRows == value)
            return;
          this.mintMaxRows = value;
          this.Valid = false;
        }
      }

      public int MinColumns => this.mintMinColumns;

      public int MinRows => this.mintMinRows;

      public int MinRowsAndColumns => this.mintMinRowsAndColumns;

      public TableLayout.Strip[] Rows
      {
        get => this.marrRows;
        set => this.marrRows = value;
      }

      public TableLayoutRowStyleCollection RowStyles
      {
        get
        {
          if (this.mobjRowStyles == null)
            this.mobjRowStyles = new TableLayoutRowStyleCollection(this.mobjContainer);
          return this.mobjRowStyles;
        }
        set
        {
          this.mobjRowStyles = value;
          if (this.mobjRowStyles == null)
            return;
          this.mobjRowStyles.EnsureOwnership(this.mobjContainer);
        }
      }

      public bool Valid
      {
        get => this.mobjState[TableLayout.ContainerInfo.mintStateValid];
        set
        {
          this.mobjState[TableLayout.ContainerInfo.mintStateValid] = value;
          if (this.mobjState[TableLayout.ContainerInfo.mintStateValid])
            return;
          this.mobjState[TableLayout.ContainerInfo.mintStateChildInfoValid] = false;
        }
      }

      public Size GetCachedPreferredSize(Size objProposedContstraints, out bool blnIsValid)
      {
        blnIsValid = false;
        if (objProposedContstraints.Height == 0 || objProposedContstraints.Width == 0)
        {
          Size preferredSizeCache = this.mobjPreferredSizeCache;
          if (!preferredSizeCache.IsEmpty)
          {
            blnIsValid = true;
            return preferredSizeCache;
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

      public LayoutInfo(IArrangedElement objElement) => this.mobjElement = objElement;

      internal int ColumnPosition
      {
        get => this.mintColPos;
        set => this.mintColPos = value;
      }

      internal int ColumnSpan
      {
        get => this.mintColumnSpan;
        set => this.mintColumnSpan = value;
      }

      internal int ColumnStart
      {
        get => this.mintColumnStart;
        set => this.mintColumnStart = value;
      }

      internal IArrangedElement Element => this.mobjElement;

      internal bool IsAbsolutelyPositioned => this.mintRowPos >= 0 && this.mintColPos >= 0;

      internal int RowPosition
      {
        get => this.mintRowPos;
        set => this.mintRowPos = value;
      }

      internal int RowSpan
      {
        get => this.mintRowSpan;
        set => this.mintRowSpan = value;
      }

      internal int RowStart
      {
        get => this.mintRowStart;
        set => this.mintRowStart = value;
      }
    }

    [Serializable]
    private class MaxSizeProxy : TableLayout.SizeProxy
    {
      private static readonly TableLayout.MaxSizeProxy mobjInstance = new TableLayout.MaxSizeProxy();

      public static TableLayout.MaxSizeProxy GetInstance => TableLayout.MaxSizeProxy.mobjInstance;

      public override int Size
      {
        get => this.mobjStrip.MaxSize;
        set => this.mobjStrip.MaxSize = value;
      }
    }

    [Serializable]
    private class MinSizeProxy : TableLayout.SizeProxy
    {
      private static readonly TableLayout.MinSizeProxy mobjInstance = new TableLayout.MinSizeProxy();

      public static TableLayout.MinSizeProxy GetInstance => TableLayout.MinSizeProxy.mobjInstance;

      public override int Size
      {
        get => this.mobjStrip.MinSize;
        set => this.mobjStrip.MinSize = value;
      }
    }

    [Serializable]
    private class PostAssignedPositionComparer : IComparer
    {
      private static readonly TableLayout.PostAssignedPositionComparer mobjInstance = new TableLayout.PostAssignedPositionComparer();

      public static TableLayout.PostAssignedPositionComparer GetInstance => TableLayout.PostAssignedPositionComparer.mobjInstance;

      public int Compare(object objX, object objY)
      {
        TableLayout.LayoutInfo layoutInfo1 = (TableLayout.LayoutInfo) objX;
        TableLayout.LayoutInfo layoutInfo2 = (TableLayout.LayoutInfo) objY;
        if (layoutInfo1.RowStart < layoutInfo2.RowStart)
          return -1;
        if (layoutInfo1.RowStart > layoutInfo2.RowStart)
          return 1;
        if (layoutInfo1.ColumnStart < layoutInfo2.ColumnStart)
          return -1;
        return layoutInfo1.ColumnStart > layoutInfo2.ColumnStart ? 1 : 0;
      }
    }

    [Serializable]
    private class PreAssignedPositionComparer : IComparer
    {
      private static readonly TableLayout.PreAssignedPositionComparer mobjInstance = new TableLayout.PreAssignedPositionComparer();

      public static TableLayout.PreAssignedPositionComparer GetInstance => TableLayout.PreAssignedPositionComparer.mobjInstance;

      public int Compare(object objX, object objY)
      {
        TableLayout.LayoutInfo layoutInfo1 = (TableLayout.LayoutInfo) objX;
        TableLayout.LayoutInfo layoutInfo2 = (TableLayout.LayoutInfo) objY;
        if (layoutInfo1.RowPosition < layoutInfo2.RowPosition)
          return -1;
        if (layoutInfo1.RowPosition > layoutInfo2.RowPosition)
          return 1;
        if (layoutInfo1.ColumnPosition < layoutInfo2.ColumnPosition)
          return -1;
        return layoutInfo1.ColumnPosition > layoutInfo2.ColumnPosition ? 1 : 0;
      }
    }

    [Serializable]
    private sealed class ReservationGrid
    {
      private int mintNumColumns = 1;
      private ArrayList mobjRows = new ArrayList();

      public void AdvanceRow()
      {
        if (this.mobjRows.Count <= 0)
          return;
        this.mobjRows.RemoveAt(0);
      }

      public bool IsReserved(int intColumn, int intRowOffset) => intRowOffset < this.mobjRows.Count && intColumn < ((BitArray) this.mobjRows[intRowOffset]).Length && ((BitArray) this.mobjRows[intRowOffset])[intColumn];

      public void Reserve(int intColumn, int intRowOffset)
      {
        while (intRowOffset >= this.mobjRows.Count)
          this.mobjRows.Add((object) new BitArray(this.mintNumColumns));
        if (intColumn >= ((BitArray) this.mobjRows[intRowOffset]).Length)
        {
          ((BitArray) this.mobjRows[intRowOffset]).Length = intColumn + 1;
          if (intColumn >= this.mintNumColumns)
            this.mintNumColumns = intColumn + 1;
        }
        ((BitArray) this.mobjRows[intRowOffset])[intColumn] = true;
      }

      public void ReserveAll(TableLayout.LayoutInfo layoutInfo, int intRowStop, int intColStop)
      {
        for (int intRowOffset = 1; intRowOffset < intRowStop - layoutInfo.RowStart; ++intRowOffset)
        {
          for (int columnStart = layoutInfo.ColumnStart; columnStart < intColStop; ++columnStart)
            this.Reserve(columnStart, intRowOffset);
        }
      }
    }

    [Serializable]
    private class RowSpanComparer : TableLayout.SpanComparer
    {
      private static readonly TableLayout.RowSpanComparer mobjInstance = new TableLayout.RowSpanComparer();

      public static TableLayout.RowSpanComparer GetInstance => TableLayout.RowSpanComparer.mobjInstance;

      public override int GetSpan(TableLayout.LayoutInfo objLayoutInfo) => objLayoutInfo.RowSpan;
    }

    [Serializable]
    private abstract class SizeProxy
    {
      protected TableLayout.Strip mobjStrip;

      public abstract int Size { get; set; }

      public TableLayout.Strip Strip
      {
        get => this.mobjStrip;
        set => this.mobjStrip = value;
      }
    }

    [Serializable]
    private abstract class SpanComparer : IComparer
    {
      public int Compare(object ojbX, object objY)
      {
        TableLayout.LayoutInfo layoutInfo1 = (TableLayout.LayoutInfo) ojbX;
        TableLayout.LayoutInfo layoutInfo2 = (TableLayout.LayoutInfo) objY;
        return this.GetSpan(layoutInfo1) - this.GetSpan(layoutInfo2);
      }

      public abstract int GetSpan(TableLayout.LayoutInfo layoutInfo);
    }

    [Serializable]
    internal struct Strip
    {
      private int mintMaxSize;
      private int mintMinSize;
      private bool mblnIsStart;

      public int MinSize
      {
        get => this.mintMinSize;
        set => this.mintMinSize = value;
      }

      public int MaxSize
      {
        get => this.mintMaxSize;
        set => this.mintMaxSize = value;
      }

      public bool IsStart
      {
        get => this.mblnIsStart;
        set => this.mblnIsStart = value;
      }
    }
  }
}
