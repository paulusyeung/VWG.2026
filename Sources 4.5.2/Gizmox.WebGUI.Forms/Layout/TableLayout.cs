#region Using

using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Collections;
using System.Drawing;
using System.Collections.Specialized;
using System.Globalization;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Forms.Serialization;

#endregion

namespace Gizmox.WebGUI.Forms.Layout
{
    #region TableLayout Class

    [Serializable()]
    internal class TableLayout : LayoutEngine
    {

        #region Classes

        #region ColumnSpanComparer Class


        [Serializable()]
        private class ColumnSpanComparer : TableLayout.SpanComparer
        {

            #region Class Members

            private static readonly TableLayout.ColumnSpanComparer mobjInstance = new TableLayout.ColumnSpanComparer();

            #endregion

            #region Properties

            public static TableLayout.ColumnSpanComparer GetInstance
            {
                get
                {
                    return mobjInstance;
                }
            }

            #endregion

            #region Methods

            #region Public Methods

            public override int GetSpan(TableLayout.LayoutInfo objLayoutInfo)
            {
                return objLayoutInfo.ColumnSpan;
            }

            #endregion

            #endregion

        }


        #endregion

        #region ContainerInfo Class


        [Serializable()]
        internal sealed class ContainerInfo : SerializableObject
        {
            #region Class Members

            private static readonly int mintStateChildHasColumnSpan = SerializableBitVector32.CreateMask(mintStateChildInfoValid);
            private static readonly int mintStateChildHasRowSpan = SerializableBitVector32.CreateMask(mintStateChildHasColumnSpan);
            private static readonly int mintStateChildInfoValid = SerializableBitVector32.CreateMask(mintStateValid);
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

            private SerializableBitVector32 mobjState = new SerializableBitVector32();


            #endregion

            #region C'Tors \ D'Tors

            public ContainerInfo(IArrangedElement objContainer)
            {
                this.marrCols = marrEmptyStrip;
                this.marrRows = marrEmptyStrip;
                this.mobjContainer = objContainer;
                this.menmGrowStyle = TableLayoutPanelGrowStyle.AddRows;
            }

            public ContainerInfo(TableLayout.ContainerInfo objContainerInfo)
            {
                this.marrCols = marrEmptyStrip;
                this.marrRows = marrEmptyStrip;
                this.mintCellBorderWidth = objContainerInfo.CellBorderWidth;
                this.mintMaxRows = objContainerInfo.MaxRows;
                this.mintMaxColumns = objContainerInfo.MaxColumns;
                this.menmGrowStyle = objContainerInfo.GrowStyle;
                this.mobjContainer = objContainerInfo.Container;
                this.mobjRowStyles = objContainerInfo.RowStyles;
                this.mobjColStyles = objContainerInfo.ColumnStyles;
            }

            #endregion

            #region Properties

            public int CellBorderWidth
            {
                get
                {
                    return this.mintCellBorderWidth;
                }
                set
                {
                    this.mintCellBorderWidth = value;
                }
            }

            public bool ChildHasColumnSpan
            {
                get
                {
                    return this.mobjState[mintStateChildHasColumnSpan];
                }
                set
                {
                    this.mobjState[mintStateChildHasColumnSpan] = value;
                }
            }

            public bool ChildHasRowSpan
            {
                get
                {
                    return this.mobjState[mintStateChildHasRowSpan];
                }
                set
                {
                    this.mobjState[mintStateChildHasRowSpan] = value;
                }
            }

            public bool ChildInfoValid
            {
                get
                {
                    return this.mobjState[mintStateChildInfoValid];
                }
            }

            public TableLayout.LayoutInfo[] ChildrenInfo
            {
                get
                {
                    if (!this.mobjState[mintStateChildInfoValid])
                    {
                        this.mintCountFixedChildren = 0;
                        this.mintMinRowsAndColumns = 0;
                        this.mintMinColumns = 0;
                        this.mintMinRows = 0;
                        ArrangedElementCollection objChildren = this.Container.Children;
                        TableLayout.LayoutInfo[] arrSourceArray = new TableLayout.LayoutInfo[objChildren.Count];
                        int intNum = 0;
                        int intNum2 = 0;
                        for (int i = 0; i < objChildren.Count; i++)
                        {
                            IArrangedElement objElement = objChildren[i];
                            if (!ElementParticipatesInLayout(objElement))
                            {
                                intNum++;
                            }
                            else
                            {
                                TableLayout.LayoutInfo layoutInfo = TableLayout.GetLayoutInfo(objElement);
                                if (layoutInfo.IsAbsolutelyPositioned)
                                {
                                    this.mintCountFixedChildren++;
                                }
                                arrSourceArray[intNum2++] = layoutInfo;
                                this.mintMinRowsAndColumns += layoutInfo.RowSpan * layoutInfo.ColumnSpan;
                                if (layoutInfo.IsAbsolutelyPositioned)
                                {
                                    this.mintMinColumns = Math.Max(this.mintMinColumns, layoutInfo.ColumnPosition + layoutInfo.ColumnSpan);
                                    this.mintMinRows = Math.Max(this.mintMinRows, layoutInfo.RowPosition + layoutInfo.RowSpan);
                                }
                            }
                        }
                        if (intNum > 0)
                        {
                            TableLayout.LayoutInfo[] arrDestinationArray = new TableLayout.LayoutInfo[arrSourceArray.Length - intNum];
                            Array.Copy(arrSourceArray, arrDestinationArray, arrDestinationArray.Length);
                            this.marrChildInfo = arrDestinationArray;
                        }
                        else
                        {
                            this.marrChildInfo = arrSourceArray;
                        }
                        this.mobjState[mintStateChildInfoValid] = true;
                    }
                    if (this.marrChildInfo != null)
                    {
                        return this.marrChildInfo;
                    }
                    return new TableLayout.LayoutInfo[0];
                }
            }

            public TableLayout.Strip[] Columns
            {
                get
                {
                    return this.marrCols;
                }
                set
                {
                    this.marrCols = value;
                }
            }

            public TableLayoutColumnStyleCollection ColumnStyles
            {
                get
                {
                    if (this.mobjColStyles == null)
                    {
                        this.mobjColStyles = new TableLayoutColumnStyleCollection(this.mobjContainer);
                    }
                    return this.mobjColStyles;
                }
                set
                {
                    this.mobjColStyles = value;
                    if (this.mobjColStyles != null)
                    {
                        this.mobjColStyles.EnsureOwnership(this.mobjContainer);
                    }
                }
            }

            public IArrangedElement Container
            {
                get
                {
                    return this.mobjContainer;
                }
            }

            public TableLayout.LayoutInfo[] FixedChildrenInfo
            {
                get
                {
                    TableLayout.LayoutInfo[] arrLayoutInfos = new TableLayout.LayoutInfo[this.mintCountFixedChildren];
                    if (this.HasChildWithAbsolutePositioning)
                    {
                        int intNum = 0;
                        for (int i = 0; i < this.marrChildInfo.Length; i++)
                        {
                            if (this.marrChildInfo[i].IsAbsolutelyPositioned)
                            {
                                arrLayoutInfos[intNum++] = this.marrChildInfo[i];
                            }
                        }
                        Array.Sort(arrLayoutInfos, TableLayout.PreAssignedPositionComparer.GetInstance);
                    }
                    return arrLayoutInfos;
                }
            }

            public TableLayoutPanelGrowStyle GrowStyle
            {
                get
                {
                    return this.menmGrowStyle;
                }
                set
                {
                    if (this.menmGrowStyle != value)
                    {
                        this.menmGrowStyle = value;
                        this.Valid = false;
                    }
                }
            }

            public bool HasChildWithAbsolutePositioning
            {
                get
                {
                    return (this.mintCountFixedChildren > 0);
                }
            }

            public bool HasMultiplePercentColumns
            {
                get
                {
                    if (this.mobjColStyles != null)
                    {
                        bool blnFlag = false;
                        foreach (ColumnStyle objStyle in (IEnumerable)this.mobjColStyles)
                        {
                            if (objStyle.SizeType != SizeType.Percent)
                            {
                                continue;
                            }
                            if (blnFlag)
                            {
                                return true;
                            }
                            blnFlag = true;
                        }
                    }
                    return false;
                }
            }

            public int MaxColumns
            {
                get
                {
                    return this.mintMaxColumns;
                }
                set
                {
                    if (this.mintMaxColumns != value)
                    {
                        this.mintMaxColumns = value;
                        this.Valid = false;
                    }
                }
            }

            public int MaxRows
            {
                get
                {
                    return this.mintMaxRows;
                }
                set
                {
                    if (this.mintMaxRows != value)
                    {
                        this.mintMaxRows = value;
                        this.Valid = false;
                    }
                }
            }

            public int MinColumns
            {
                get
                {
                    return this.mintMinColumns;
                }
            }

            public int MinRows
            {
                get
                {
                    return this.mintMinRows;
                }
            }

            public int MinRowsAndColumns
            {
                get
                {
                    return this.mintMinRowsAndColumns;
                }
            }

            public TableLayout.Strip[] Rows
            {
                get
                {
                    return this.marrRows;
                }
                set
                {
                    this.marrRows = value;
                }
            }

            public TableLayoutRowStyleCollection RowStyles
            {
                get
                {
                    if (this.mobjRowStyles == null)
                    {
                        this.mobjRowStyles = new TableLayoutRowStyleCollection(this.mobjContainer);
                    }
                    return this.mobjRowStyles;
                }
                set
                {
                    this.mobjRowStyles = value;
                    if (this.mobjRowStyles != null)
                    {
                        this.mobjRowStyles.EnsureOwnership(this.mobjContainer);
                    }
                }
            }

            public bool Valid
            {
                get
                {
                    return this.mobjState[mintStateValid];
                }
                set
                {
                    this.mobjState[mintStateValid] = value;
                    if (!this.mobjState[mintStateValid])
                    {
                        this.mobjState[mintStateChildInfoValid] = false;
                    }
                }
            }

            #endregion

            #region Methods

            #region Public Methods

            public Size GetCachedPreferredSize(Size objProposedContstraints, out bool blnIsValid)
            {
                blnIsValid = false;
                if ((objProposedContstraints.Height == 0) || (objProposedContstraints.Width == 0))
                {
                    Size objSize = mobjPreferredSizeCache;
                    if (!objSize.IsEmpty)
                    {
                        blnIsValid = true;
                        return objSize;
                    }
                }
                return Size.Empty;
            }

            #endregion

            #endregion

        }

        #endregion

        #region LayoutInfo Class

        [Serializable()]
        internal sealed class LayoutInfo
        {
            #region Class Members

            private int mintColPos = -1;
            private int mintColumnSpan = 1;
            private int mintColumnStart = -1;
            private IArrangedElement mobjElement;
            private int mintRowPos = -1;
            private int mintRowSpan = 1;
            private int mintRowStart = -1;

            #endregion

            #region C'Tors \ D'Tors

            public LayoutInfo(IArrangedElement objElement)
            {
                this.mobjElement = objElement;
            }

            #endregion

            #region Properties

            internal int ColumnPosition
            {
                get
                {
                    return this.mintColPos;
                }
                set
                {
                    this.mintColPos = value;
                }
            }

            internal int ColumnSpan
            {
                get
                {
                    return this.mintColumnSpan;
                }
                set
                {
                    this.mintColumnSpan = value;
                }
            }

            internal int ColumnStart
            {
                get
                {
                    return this.mintColumnStart;
                }
                set
                {
                    this.mintColumnStart = value;
                }
            }

            internal IArrangedElement Element
            {
                get
                {
                    return this.mobjElement;
                }
            }

            internal bool IsAbsolutelyPositioned
            {
                get
                {
                    if (this.mintRowPos >= 0)
                    {
                        return (this.mintColPos >= 0);
                    }
                    return false;
                }
            }

            internal int RowPosition
            {
                get
                {
                    return this.mintRowPos;
                }
                set
                {
                    this.mintRowPos = value;
                }
            }

            internal int RowSpan
            {
                get
                {
                    return this.mintRowSpan;
                }
                set
                {
                    this.mintRowSpan = value;
                }
            }

            internal int RowStart
            {
                get
                {
                    return this.mintRowStart;
                }
                set
                {
                    this.mintRowStart = value;
                }
            }

            #endregion

        }

        #endregion

        #region MaxSizeProxy Class



        [Serializable()]
        private class MaxSizeProxy : TableLayout.SizeProxy
        {
            #region Class Members

            private static readonly TableLayout.MaxSizeProxy mobjInstance = new TableLayout.MaxSizeProxy();

            #endregion

            #region Properties

            public static TableLayout.MaxSizeProxy GetInstance
            {
                get
                {
                    return mobjInstance;
                }
            }

            public override int Size
            {
                get
                {
                    return this.mobjStrip.MaxSize;
                }
                set
                {
                    this.mobjStrip.MaxSize = value;
                }
            }

            #endregion

        }

        #endregion

        #region MinSizeProxy Class


        [Serializable()]
        private class MinSizeProxy : TableLayout.SizeProxy
        {
            #region Class Members

            private static readonly TableLayout.MinSizeProxy mobjInstance = new TableLayout.MinSizeProxy();

            #endregion

            #region Properties

            public static TableLayout.MinSizeProxy GetInstance
            {
                get
                {
                    return mobjInstance;
                }
            }

            public override int Size
            {
                get
                {
                    return this.mobjStrip.MinSize;
                }
                set
                {
                    this.mobjStrip.MinSize = value;
                }
            }

            #endregion
        }


        #endregion

        #region PostAssignedPositionComparer Class


        [Serializable()]
        private class PostAssignedPositionComparer : IComparer
        {

            #region Class Members

            private static readonly TableLayout.PostAssignedPositionComparer mobjInstance = new TableLayout.PostAssignedPositionComparer();

            #endregion

            #region Properties

            public static TableLayout.PostAssignedPositionComparer GetInstance
            {
                get
                {
                    return mobjInstance;
                }
            }

            #endregion

            #region Methods

            #region Public Methods

            public int Compare(object objX, object objY)
            {
                TableLayout.LayoutInfo objInfo = (TableLayout.LayoutInfo)objX;
                TableLayout.LayoutInfo objInfo2 = (TableLayout.LayoutInfo)objY;
                if (objInfo.RowStart < objInfo2.RowStart)
                {
                    return -1;
                }
                if (objInfo.RowStart > objInfo2.RowStart)
                {
                    return 1;
                }
                if (objInfo.ColumnStart < objInfo2.ColumnStart)
                {
                    return -1;
                }
                if (objInfo.ColumnStart > objInfo2.ColumnStart)
                {
                    return 1;
                }
                return 0;
            }

            #endregion

            #endregion

        }

        #endregion

        #region PreAssignedPositionComparer Class


        [Serializable()]
        private class PreAssignedPositionComparer : IComparer
        {

            #region Class Members

            private static readonly TableLayout.PreAssignedPositionComparer mobjInstance = new TableLayout.PreAssignedPositionComparer();

            #endregion

            #region Properties

            public static TableLayout.PreAssignedPositionComparer GetInstance
            {
                get
                {
                    return mobjInstance;
                }
            }

            #endregion

            #region Methods

            #region Public Methods

            public int Compare(object objX, object objY)
            {
                TableLayout.LayoutInfo objInfo = (TableLayout.LayoutInfo)objX;
                TableLayout.LayoutInfo objInfo2 = (TableLayout.LayoutInfo)objY;
                if (objInfo.RowPosition < objInfo2.RowPosition)
                {
                    return -1;
                }
                if (objInfo.RowPosition > objInfo2.RowPosition)
                {
                    return 1;
                }
                if (objInfo.ColumnPosition < objInfo2.ColumnPosition)
                {
                    return -1;
                }
                if (objInfo.ColumnPosition > objInfo2.ColumnPosition)
                {
                    return 1;
                }
                return 0;
            }

            #endregion

            #endregion

        }

        #endregion

        #region ReservationGrid Class


        [Serializable()]
        private sealed class ReservationGrid
        {

            #region Class Members

            private int mintNumColumns = 1;
            private ArrayList mobjRows = new ArrayList();

            #endregion

            #region Methods

            #region Public Methods

            public void AdvanceRow()
            {
                if (this.mobjRows.Count > 0)
                {
                    this.mobjRows.RemoveAt(0);
                }
            }

            public bool IsReserved(int intColumn, int intRowOffset)
            {
                if (intRowOffset >= this.mobjRows.Count)
                {
                    return false;
                }
                if (intColumn >= ((BitArray)this.mobjRows[intRowOffset]).Length)
                {
                    return false;
                }
                return ((BitArray)this.mobjRows[intRowOffset])[intColumn];
            }

            public void Reserve(int intColumn, int intRowOffset)
            {
                while (intRowOffset >= this.mobjRows.Count)
                {
                    this.mobjRows.Add(new BitArray(this.mintNumColumns));
                }
                if (intColumn >= ((BitArray)this.mobjRows[intRowOffset]).Length)
                {
                    ((BitArray)this.mobjRows[intRowOffset]).Length = intColumn + 1;
                    if (intColumn >= this.mintNumColumns)
                    {
                        this.mintNumColumns = intColumn + 1;
                    }
                }
                ((BitArray)this.mobjRows[intRowOffset])[intColumn] = true;
            }

            public void ReserveAll(TableLayout.LayoutInfo layoutInfo, int intRowStop, int intColStop)
            {
                for (int i = 1; i < (intRowStop - layoutInfo.RowStart); i++)
                {
                    for (int j = layoutInfo.ColumnStart; j < intColStop; j++)
                    {
                        this.Reserve(j, i);
                    }
                }
            }

            #endregion

            #endregion

        }

        #endregion

        #region RowSpanComparer Class


        [Serializable()]
        private class RowSpanComparer : TableLayout.SpanComparer
        {

            #region Class Members

            private static readonly TableLayout.RowSpanComparer mobjInstance = new TableLayout.RowSpanComparer();

            #endregion

            #region Properties

            public static TableLayout.RowSpanComparer GetInstance
            {
                get
                {
                    return mobjInstance;
                }
            }

            #endregion

            #region Methods

            #region Public Methods

            public override int GetSpan(TableLayout.LayoutInfo objLayoutInfo)
            {
                return objLayoutInfo.RowSpan;
            }

            #endregion

            #endregion

        }

        #endregion

        #region SizeProxy Class


        [Serializable()]
        private abstract class SizeProxy
        {
            #region Class Members

            protected TableLayout.Strip mobjStrip;

            #endregion

            #region C'Tors \ D'Tors

            protected SizeProxy()
            {
            }

            #endregion

            #region Properties

            public abstract int Size { get; set; }

            public TableLayout.Strip Strip
            {
                get
                {
                    return this.mobjStrip;
                }
                set
                {
                    this.mobjStrip = value;
                }
            }

            #endregion

        }


        #endregion

        #region SpanComparer Class


        [Serializable()]
        private abstract class SpanComparer : IComparer
        {
            #region C'Tors \ D'Tors

            protected SpanComparer()
            {
            }

            #endregion

            #region Methods

            #region Public Methods

            public int Compare(object ojbX, object objY)
            {
                TableLayout.LayoutInfo objLayoutInfo = (TableLayout.LayoutInfo)ojbX;
                TableLayout.LayoutInfo objInfo2 = (TableLayout.LayoutInfo)objY;
                return (this.GetSpan(objLayoutInfo) - this.GetSpan(objInfo2));
            }

            public abstract int GetSpan(TableLayout.LayoutInfo layoutInfo);

            #endregion

            #endregion
        }

        #endregion

        #endregion

        #region Class Members

        private static string[] marrPropertiesWhichInvalidateCache;
        internal static readonly TableLayout Instance = new TableLayout();
        private bool mblnIsAutoSize = true;
        private Padding mobjMargins = new Padding(0);
        private Size mobjSpecifiedBoundsSize = new Size(50, 50);

        #endregion

        #region C'Tors \ D'Tors

        static TableLayout()
        {
            string[] arrStringArray = new string[9];
            arrStringArray[1] = PropertyNames.ChildIndex;
            arrStringArray[2] = PropertyNames.Parent;
            arrStringArray[3] = PropertyNames.Visible;
            arrStringArray[4] = PropertyNames.Items;
            arrStringArray[5] = PropertyNames.Rows;
            arrStringArray[6] = PropertyNames.Columns;
            arrStringArray[7] = PropertyNames.RowStyles;
            arrStringArray[8] = PropertyNames.ColumnStyles;
            marrPropertiesWhichInvalidateCache = arrStringArray;
        }

        #endregion

        #region Methods

        #region Private Methods

        private void AdvanceUntilFits(int intMaxColumns, ReservationGrid objReservationGrid, LayoutInfo objLayoutInfo, out int colStop)
        {
            int intRowStart = objLayoutInfo.RowStart;
            do
            {
                this.GetColStartAndStop(intMaxColumns, objReservationGrid, objLayoutInfo, out colStop);
            }
            while (this.ScanRowForOverlap(intMaxColumns, objReservationGrid, objLayoutInfo, colStop, objLayoutInfo.RowStart - intRowStart));
        }

        private Size ApplyStyles(ContainerInfo objContainerInfo, Size objProposedConstraints, bool blnMeasureOnly)
        {
            Size objEmpty = Size.Empty;
            this.InitializeStrips(objContainerInfo.Columns, objContainerInfo.ColumnStyles);
            this.InitializeStrips(objContainerInfo.Rows, objContainerInfo.RowStyles);
            objContainerInfo.ChildHasColumnSpan = false;
            objContainerInfo.ChildHasRowSpan = false;
            foreach (LayoutInfo objInfo in objContainerInfo.ChildrenInfo)
            {
                objContainerInfo.Columns[objInfo.ColumnStart].IsStart = true;
                objContainerInfo.Rows[objInfo.RowStart].IsStart = true;
                if (objInfo.ColumnSpan > 1)
                {
                    objContainerInfo.ChildHasColumnSpan = true;
                }
                if (objInfo.RowSpan > 1)
                {
                    objContainerInfo.ChildHasRowSpan = true;
                }
            }
            objEmpty.Width = this.InflateColumns(objContainerInfo, objProposedConstraints, blnMeasureOnly);
            int intExpandLastElementWidth = Math.Max(0, objProposedConstraints.Width - objEmpty.Width);
            objEmpty.Height = this.InflateRows(objContainerInfo, objProposedConstraints, intExpandLastElementWidth, blnMeasureOnly);
            return objEmpty;
        }

        internal void AssignRowsAndColumns(ContainerInfo objContainerInfo)
        {
            int intMaxColumns = objContainerInfo.MaxColumns;
            int intMaxRows = objContainerInfo.MaxRows;
            LayoutInfo[] arrChildrenInfo = objContainerInfo.ChildrenInfo;
            int intMinRowsAndColumns = objContainerInfo.MinRowsAndColumns;
            int intMinColumns = objContainerInfo.MinColumns;
            int intMinRows = objContainerInfo.MinRows;
            TableLayoutPanelGrowStyle enmGrowStyle = objContainerInfo.GrowStyle;
            if (enmGrowStyle == TableLayoutPanelGrowStyle.FixedSize)
            {
                if (objContainerInfo.MinRowsAndColumns > (intMaxColumns * intMaxRows))
                {
                    throw new ArgumentException(SR.GetString("TableLayoutPanelFullDesc"));
                }
                if ((intMinColumns > intMaxColumns) || (intMinRows > intMaxRows))
                {
                    throw new ArgumentException(SR.GetString("TableLayoutPanelSpanDesc"));
                }
                intMaxRows = Math.Max(1, intMaxRows);
                intMaxColumns = Math.Max(1, intMaxColumns);
            }
            else if (enmGrowStyle == TableLayoutPanelGrowStyle.AddRows)
            {
                intMaxRows = 0;
            }
            else
            {
                intMaxColumns = 0;
            }
            if (intMaxColumns > 0)
            {
                this.xAssignRowsAndColumns(objContainerInfo, arrChildrenInfo, intMaxColumns, (intMaxRows == 0) ? 0x7fffffff : intMaxRows, enmGrowStyle);
            }
            else if (intMaxRows > 0)
            {
                for (int i = Math.Max(Math.Max((int)Math.Ceiling((double)(((float)intMinRowsAndColumns) / ((float)intMaxRows))), intMinColumns), 1); !this.xAssignRowsAndColumns(objContainerInfo, arrChildrenInfo, i, intMaxRows, enmGrowStyle); i++)
                {
                }
            }
            else
            {
                this.xAssignRowsAndColumns(objContainerInfo, arrChildrenInfo, Math.Max(intMinColumns, 1), 0x7fffffff, enmGrowStyle);
            }
        }

        [Conditional("DEBUG_LAYOUT")]
        private void Debug_VerifyAssignmentsAreCurrent(IArrangedElement objContainer, ContainerInfo objContainerInfo)
        {
        }

        [Conditional("DEBUG_LAYOUT")]
        private void Debug_VerifyNoOverlapping(IArrangedElement objContainer)
        {
            ArrayList objList = new ArrayList(objContainer.Children.Count);
            ContainerInfo objContainerInfo = GetContainerInfo(objContainer);
            Strip[] arrRows = objContainerInfo.Rows;
            Strip[] arrColumns = objContainerInfo.Columns;
            foreach (IArrangedElement objElement in objContainer.Children)
            {
                if (ElementParticipatesInLayout(objElement))
                {
                    objList.Add(GetLayoutInfo(objElement));
                }
            }
            for (int i = 0; i < objList.Count; i++)
            {
                LayoutInfo objInfo2 = (LayoutInfo)objList[i];
                Rectangle objBounds = GetElementBounds(objInfo2.Element);
                new Rectangle(objInfo2.ColumnStart, objInfo2.RowStart, objInfo2.ColumnSpan, objInfo2.RowSpan);
                for (int j = i + 1; j < objList.Count; j++)
                {
                    LayoutInfo objInfo3 = (LayoutInfo)objList[j];
                    Rectangle objRectangle2 = GetElementBounds(objInfo3.Element);
                    new Rectangle(objInfo3.ColumnStart, objInfo3.RowStart, objInfo3.ColumnSpan, objInfo3.RowSpan);
                    if (LayoutUtils.IsIntersectHorizontally(objBounds, objRectangle2))
                    {
                        int intNum3;
                        for (intNum3 = objInfo2.ColumnStart; intNum3 < (objInfo2.ColumnStart + objInfo2.ColumnSpan); intNum3++)
                        {
                        }
                        for (intNum3 = objInfo3.ColumnStart; intNum3 < (objInfo3.ColumnStart + objInfo3.ColumnSpan); intNum3++)
                        {
                        }
                    }
                    if (LayoutUtils.IsIntersectVertically(objBounds, objRectangle2))
                    {
                        int intNum4;
                        for (intNum4 = objInfo2.RowStart; intNum4 < (objInfo2.RowStart + objInfo2.RowSpan); intNum4++)
                        {
                        }
                        for (intNum4 = objInfo3.RowStart; intNum4 < (objInfo3.RowStart + objInfo3.RowSpan); intNum4++)
                        {
                        }
                    }
                }
            }
        }

        private void DistributeSize(IList objStyles, Strip[] arrStrips, int intStart, int intStop, int intMin, int intMax, int cellBorderWidth)
        {
            this.xDistributeSize(objStyles, arrStrips, intStart, intStop, intMin, MinSizeProxy.GetInstance, cellBorderWidth);
            this.xDistributeSize(objStyles, arrStrips, intStart, intStop, intMax, MaxSizeProxy.GetInstance, cellBorderWidth);
        }

        private int DistributeStyles(int cellBorderWidth, IList objStyles, Strip[] arrStrips, int intMaxSize, bool blnDontHonorConstraint)
        {
            int intNum = 0;
            float fltNum2 = 0f;
            float fltNum3 = 0f;
            float fltNum4 = 0f;
            float fltNum5 = 0f;
            bool blnFlag = false;
            for (int i = 0; i < arrStrips.Length; i++)
            {
                Strip objStrip = arrStrips[i];
                if (i < objStyles.Count)
                {
                    TableLayoutStyle objStyle = (TableLayoutStyle)objStyles[i];
                    switch (objStyle.SizeType)
                    {
                        case SizeType.Absolute:
                            fltNum5 += objStrip.MinSize;
                            goto Label_00A5;

                        case SizeType.Percent:
                            fltNum3 += objStyle.Size;
                            fltNum4 += objStrip.MinSize;
                            goto Label_00A5;
                    }
                    fltNum5 += objStrip.MinSize;
                    blnFlag = true;
                }
                else
                {
                    blnFlag = true;
                }
            Label_00A5:
                objStrip.MaxSize += cellBorderWidth;
                objStrip.MinSize += cellBorderWidth;
                arrStrips[i] = objStrip;
                intNum += objStrip.MinSize;
            }
            int intNum7 = intMaxSize - intNum;
            if (fltNum3 > 0f)
            {
                if (!blnDontHonorConstraint)
                {
                    if (fltNum4 > (intMaxSize - fltNum5))
                    {
                        fltNum4 = Math.Max((float)0f, (float)(intMaxSize - fltNum5));
                    }
                    if (intNum7 > 0)
                    {
                        fltNum4 += intNum7;
                    }
                    else if (intNum7 < 0)
                    {
                        fltNum4 = (intMaxSize - fltNum5) - (arrStrips.Length * cellBorderWidth);
                        intNum7 = 0;
                    }
                    for (int j = 0; j < arrStrips.Length; j++)
                    {
                        Strip objStrip2 = arrStrips[j];
                        SizeType objType = (j < objStyles.Count) ? ((TableLayoutStyle)objStyles[j]).SizeType : SizeType.AutoSize;
                        if (objType == SizeType.Percent)
                        {
                            TableLayoutStyle objStyle2 = (TableLayoutStyle)objStyles[j];
                            int intNum9 = (int)((objStyle2.Size * fltNum4) / fltNum3);
                            intNum -= objStrip2.MinSize;
                            intNum += intNum9 + cellBorderWidth;
                            objStrip2.MinSize = intNum9 + cellBorderWidth;
                            arrStrips[j] = objStrip2;
                        }
                    }
                }
                else
                {
                    int intNum10 = 0;
                    for (int k = 0; k < arrStrips.Length; k++)
                    {
                        Strip objStrip3 = arrStrips[k];
                        SizeType objType2 = (k < objStyles.Count) ? ((TableLayoutStyle)objStyles[k]).SizeType : SizeType.AutoSize;
                        if (objType2 == SizeType.Percent)
                        {
                            TableLayoutStyle objStyle3 = (TableLayoutStyle)objStyles[k];
                            int intNum12 = (int)Math.Round((double)((objStrip3.MinSize * fltNum3) / objStyle3.Size));
                            intNum10 = Math.Max(intNum10, intNum12);
                            intNum -= objStrip3.MinSize;
                        }
                    }
                    intNum += intNum10;
                }
            }
            intNum7 = intMaxSize - intNum;
            if (blnFlag && (intNum7 > 0))
            {
                if (intNum7 < fltNum2)
                {
                    float fltSingle1 = ((float)intNum7) / fltNum2;
                }
                intNum7 -= (int)Math.Ceiling((double)fltNum2);
                for (int m = 0; m < arrStrips.Length; m++)
                {
                    Strip objStrip4 = arrStrips[m];
                    if (((m < objStyles.Count) ? ((TableLayoutStyle)objStyles[m]).SizeType : SizeType.AutoSize) == SizeType.AutoSize)
                    {
                        int intNum14 = Math.Min(objStrip4.MaxSize - objStrip4.MinSize, intNum7);
                        if (intNum14 > 0)
                        {
                            intNum += intNum14;
                            intNum7 -= intNum14;
                            objStrip4.MinSize += intNum14;
                            arrStrips[m] = objStrip4;
                        }
                    }
                }
            }
            return intNum;
        }

        private static bool ElementParticipatesInLayout(IArrangedElement objElement)
        {
            bool blnReturnValue = false;

            if (objElement != null &&
                objElement is Control)
            {
                blnReturnValue = ((Control)objElement).Visible;
            }

            return blnReturnValue;
        }

        private void EnsureRowAndColumnAssignments(IArrangedElement objContainer, ContainerInfo objContainerInfo, bool blnDoNotCache)
        {
            if (!HasCachedAssignments(objContainerInfo) || blnDoNotCache)
            {
                this.AssignRowsAndColumns(objContainerInfo);
            }
        }

        private void ExpandLastElement(ContainerInfo objContainerInfo, Size objUsedSpace, Size objTotalSpace)
        {
            Strip[] arrRows = objContainerInfo.Rows;
            Strip[] arrColumns = objContainerInfo.Columns;
            if ((arrColumns.Length != 0) && (objTotalSpace.Width > objUsedSpace.Width))
            {
                arrColumns[arrColumns.Length - 1].MinSize += objTotalSpace.Width - objUsedSpace.Width;
            }
            if ((arrRows.Length != 0) && (objTotalSpace.Height > objUsedSpace.Height))
            {
                arrRows[arrRows.Length - 1].MinSize += objTotalSpace.Height - objUsedSpace.Height;
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
            Rectangle objRectangle = new Rectangle();

            if (objArrangedElement != null &&
               objArrangedElement is Control)
            {
                objRectangle = new Rectangle(((Control)objArrangedElement).Location, ((Control)objArrangedElement).Size);
            }

            return objRectangle;
        }

        private Size GetElementSize(IArrangedElement objElement, Size objProposedConstraints)
        {
            if (mblnIsAutoSize)
            {
                if (objElement != null &&
                    objElement is Control)
                {
                    return ((Control)objElement).Size;
                }
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
            bool blnDontHonorConstraint = blnMeasureOnly;
            LayoutInfo[] arrChildrenInfo = objContainerInfo.ChildrenInfo;
            if (objContainerInfo.ChildHasColumnSpan)
            {
                Array.Sort(arrChildrenInfo, ColumnSpanComparer.GetInstance);
            }
            if (blnDontHonorConstraint && (objProposedConstraints.Width < 0x7fff))
            {
                TableLayoutPanel objContainer = objContainerInfo.Container as TableLayoutPanel;
                if (((objContainer != null) && (objContainer.ParentInternal != null)))// && (objContainer.ParentInternal.LayoutEngine == DefaultLayout.Instance))
                {
                    if (((objContainer.Dock == DockStyle.Top) || (objContainer.Dock == DockStyle.Bottom)) || (objContainer.Dock == DockStyle.Fill))
                    {
                        blnDontHonorConstraint = false;
                    }
                    if ((objContainer.Anchor & (AnchorStyles.Right | AnchorStyles.Left)) == (AnchorStyles.Right | AnchorStyles.Left))
                    {
                        blnDontHonorConstraint = false;
                    }
                }
            }
            foreach (LayoutInfo objInfo in arrChildrenInfo)
            {
                IArrangedElement objElement = objInfo.Element;
                int intColumnSpan = objInfo.ColumnSpan;
                if ((intColumnSpan > 1) || !this.IsAbsolutelySized(objInfo.ColumnStart, objContainerInfo.ColumnStyles))
                {
                    int intMmin = 0;
                    int intMax = 0;
                    if (((intColumnSpan == 1) && (objInfo.RowSpan == 1)) && this.IsAbsolutelySized(objInfo.RowStart, objContainerInfo.RowStyles))
                    {
                        int intSize = (int)objContainerInfo.RowStyles[objInfo.RowStart].Size;
                        intMmin = this.GetElementSize(objElement, new Size(0, intSize)).Width;
                        intMax = intMmin;
                    }
                    else
                    {
                        intMmin = this.GetElementSize(objElement, new Size(1, 0)).Width;
                        intMax = this.GetElementSize(objElement, Size.Empty).Width;
                    }
                    Padding objMargin = mobjMargins;
                    intMmin += objMargin.Horizontal;
                    intMax += objMargin.Horizontal;
                    int intStop = Math.Min(objInfo.ColumnStart + objInfo.ColumnSpan, objContainerInfo.Columns.Length);
                    this.DistributeSize(objContainerInfo.ColumnStyles, objContainerInfo.Columns, objInfo.ColumnStart, intStop, intMmin, intMax, objContainerInfo.CellBorderWidth);
                }
            }
            int intNum6 = this.DistributeStyles(objContainerInfo.CellBorderWidth, objContainerInfo.ColumnStyles, objContainerInfo.Columns, objProposedConstraints.Width, blnDontHonorConstraint);
            if ((!blnDontHonorConstraint || (intNum6 <= objProposedConstraints.Width)) || (objProposedConstraints.Width <= 1))
            {
                return intNum6;
            }
            Strip[] arrColumns = objContainerInfo.Columns;
            float fltNum7 = 0f;
            int intNum8 = 0;
            TableLayoutStyleCollection objColumnStyles = objContainerInfo.ColumnStyles;
            for (int i = 0; i < arrColumns.Length; i++)
            {
                Strip objStrip = arrColumns[i];
                if (i < objColumnStyles.Count)
                {
                    TableLayoutStyle objStyle = objColumnStyles[i];
                    if (objStyle.SizeType == SizeType.Percent)
                    {
                        fltNum7 += objStyle.Size;
                        intNum8 += objStrip.MinSize;
                    }
                }
            }
            int intNum10 = intNum6 - objProposedConstraints.Width;
            int intNum11 = Math.Min(intNum10, intNum8);
            for (int j = 0; j < arrColumns.Length; j++)
            {
                if (j < objColumnStyles.Count)
                {
                    TableLayoutStyle objStyle2 = objColumnStyles[j];
                    if (objStyle2.SizeType == SizeType.Percent)
                    {
                        float fltNum13 = objStyle2.Size / fltNum7;
                        arrColumns[j].MinSize -= (int)(fltNum13 * intNum11);
                    }
                }
            }
            return (intNum6 - intNum11);
        }

        private int InflateRows(ContainerInfo objContainerInfo, Size objProposedConstraints, int intExpandLastElementWidth, bool blnMeasureOnly)
        {
            bool blnDontHonorConstraint = blnMeasureOnly;
            LayoutInfo[] arrChildrenInfo = objContainerInfo.ChildrenInfo;
            if (objContainerInfo.ChildHasRowSpan)
            {
                Array.Sort(arrChildrenInfo, RowSpanComparer.GetInstance);
            }
            bool blnHasMultiplePercentColumns = objContainerInfo.HasMultiplePercentColumns;
            if (blnDontHonorConstraint && (objProposedConstraints.Height < 0x7fff))
            {
                TableLayoutPanel objContainer = objContainerInfo.Container as TableLayoutPanel;
                if (((objContainer != null) && (objContainer.ParentInternal != null))) // && (objContainer.ParentInternal.LayoutEngine == DefaultLayout.Instance))
                {
                    if (((objContainer.Dock == DockStyle.Left) || (objContainer.Dock == DockStyle.Right)) || (objContainer.Dock == DockStyle.Fill))
                    {
                        blnDontHonorConstraint = false;
                    }
                    if ((objContainer.Anchor & (AnchorStyles.Bottom | AnchorStyles.Top)) == (AnchorStyles.Bottom | AnchorStyles.Top))
                    {
                        blnDontHonorConstraint = false;
                    }
                }
            }
            foreach (LayoutInfo objInfo in arrChildrenInfo)
            {
                IArrangedElement objElement = objInfo.Element;
                if ((objInfo.RowSpan > 1) || !this.IsAbsolutelySized(objInfo.RowStart, objContainerInfo.RowStyles))
                {
                    int intNum2 = this.SumStrips(objContainerInfo.Columns, objInfo.ColumnStart, objInfo.ColumnSpan);
                    if ((!blnDontHonorConstraint && ((objInfo.ColumnStart + objInfo.ColumnSpan) >= objContainerInfo.MaxColumns)) && !blnHasMultiplePercentColumns)
                    {
                        intNum2 += intExpandLastElementWidth;
                    }
                    Padding objMargin = mobjMargins;
                    int intMin = this.GetElementSize(objElement, new Size(intNum2 - objMargin.Horizontal, 0)).Height + objMargin.Vertical;
                    int intMax = intMin;
                    int intStop = Math.Min(objInfo.RowStart + objInfo.RowSpan, objContainerInfo.Rows.Length);
                    this.DistributeSize(objContainerInfo.RowStyles, objContainerInfo.Rows, objInfo.RowStart, intStop, intMin, intMax, objContainerInfo.CellBorderWidth);
                }
            }
            return this.DistributeStyles(objContainerInfo.CellBorderWidth, objContainerInfo.RowStyles, objContainerInfo.Rows, objProposedConstraints.Height, blnDontHonorConstraint);
        }

        private void InitializeStrips(Strip[] arrStrips, IList objStyles)
        {
            for (int i = 0; i < arrStrips.Length; i++)
            {
                TableLayoutStyle objStyle = (i < objStyles.Count) ? ((TableLayoutStyle)objStyles[i]) : null;
                Strip objStrip = arrStrips[i];
                if ((objStyle != null) && (objStyle.SizeType == SizeType.Absolute))
                {
                    objStrip.MinSize = (int)Math.Round((double)((TableLayoutStyle)objStyles[i]).Size);
                    objStrip.MaxSize = objStrip.MinSize;
                }
                else
                {
                    objStrip.MinSize = 0;
                    objStrip.MaxSize = 0;
                }
                objStrip.IsStart = false;
                arrStrips[i] = objStrip;
            }
        }

        private bool IsAbsolutelySized(int index, IList objStyles)
        {
            if (index < objStyles.Count)
            {
                return (((TableLayoutStyle)objStyles[index]).SizeType == SizeType.Absolute);
            }
            return false;
        }

        private bool IsCursorPastInsertionPoint(LayoutInfo fixedLayoutInfo, int insertionRow, int insertionCol)
        {
            return ((fixedLayoutInfo.RowPosition < insertionRow) || ((fixedLayoutInfo.RowPosition == insertionRow) && (fixedLayoutInfo.ColumnPosition < insertionCol)));
        }

        private bool IsOverlappingWithReservationGrid(LayoutInfo fixedLayoutInfo, ReservationGrid objReservationGrid, int intCurrentRow)
        {
            if (fixedLayoutInfo.RowPosition < intCurrentRow)
            {
                return true;
            }
            for (int i = fixedLayoutInfo.RowPosition - intCurrentRow; i < ((fixedLayoutInfo.RowPosition - intCurrentRow) + fixedLayoutInfo.RowSpan); i++)
            {
                for (int j = fixedLayoutInfo.ColumnPosition; j < (fixedLayoutInfo.ColumnPosition + fixedLayoutInfo.ColumnSpan); j++)
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
                    while ((layoutInfo.ColumnStart < intMaxColumns) && objReservationGrid.IsReserved(layoutInfo.ColumnStart, intRowOffset))
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
            if (objArrangedElement != null &&
               objArrangedElement is Control &&
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
 objRectangle != null)
#else
 objRectangle != Rectangle.Empty)
#endif
            {
                ((Control)objArrangedElement).Location = objRectangle.Location;
                ((Control)objArrangedElement).Size = objRectangle.Size;
            }

            return objRectangle;
        }

        private void SetElementBounds(ContainerInfo objContainerInfo, RectangleF displayRectF)
        {
            int cellBorderWidth = objContainerInfo.CellBorderWidth;
            float fltY = displayRectF.Y;
            int index = 0;
            int intNum4 = 0;
            bool blnFlag = false;
            Rectangle.Truncate(displayRectF);
            if (objContainerInfo.Container is Control)
            {
                Control objContainer = objContainerInfo.Container as Control;
                blnFlag = objContainer.RightToLeft == RightToLeft.Yes;
            }
            LayoutInfo[] arrChildrenInfo = objContainerInfo.ChildrenInfo;
            float fltNum5 = blnFlag ? displayRectF.Right : displayRectF.X;
            Array.Sort(arrChildrenInfo, PostAssignedPositionComparer.GetInstance);
            for (int i = 0; i < arrChildrenInfo.Length; i++)
            {
                LayoutInfo info = arrChildrenInfo[i];
                IArrangedElement objElement = info.Element;
                if (intNum4 != info.RowStart)
                {
                    while (intNum4 < info.RowStart)
                    {
                        fltY += objContainerInfo.Rows[intNum4].MinSize;
                        intNum4++;
                    }
                    fltNum5 = blnFlag ? displayRectF.Right : displayRectF.X;
                    index = 0;
                }
                while (index < info.ColumnStart)
                {
                    if (blnFlag)
                    {
                        fltNum5 -= objContainerInfo.Columns[index].MinSize;
                    }
                    else
                    {
                        fltNum5 += objContainerInfo.Columns[index].MinSize;
                    }
                    index++;
                }
                int intNum7 = index + info.ColumnSpan;
                int intNum8 = 0;
                while ((index < intNum7) && (index < objContainerInfo.Columns.Length))
                {
                    intNum8 += objContainerInfo.Columns[index].MinSize;
                    index++;
                }
                if (blnFlag)
                {
                    fltNum5 -= intNum8;
                }
                int intNum9 = intNum4 + info.RowSpan;
                int intNum10 = 0;
                for (int j = intNum4; (j < intNum9) && (j < objContainerInfo.Rows.Length); j++)
                {
                    intNum10 += objContainerInfo.Rows[j].MinSize;
                }
                Rectangle objRectangle = new Rectangle((int)(fltNum5 + (((float)cellBorderWidth) / 2f)), (int)(fltY + (((float)cellBorderWidth) / 2f)), intNum8 - cellBorderWidth, intNum10 - cellBorderWidth);
                Padding objMargin = mobjMargins;
                if (blnFlag)
                {
                    int intRight = objMargin.Right;
                    objMargin.Right = objMargin.Left;
                    objMargin.Left = intRight;
                }
                objRectangle = LayoutUtils.DeflateRect(objRectangle, objMargin);
                objRectangle.Width = Math.Max(objRectangle.Width, 1);
                objRectangle.Height = Math.Max(objRectangle.Height, 1);
                AnchorStyles unifiedAnchor = (AnchorStyles.Top | AnchorStyles.Left);
                if (objElement is Control)
                {
                    unifiedAnchor = ((Control)objElement).Anchor;
                }
                Rectangle objBounds = LayoutUtils.AlignAndStretch(this.GetElementSize(objElement, objRectangle.Size), objRectangle, unifiedAnchor);
                objBounds.Width = Math.Min(objRectangle.Width, objBounds.Width);
                objBounds.Height = Math.Min(objRectangle.Height, objBounds.Height);
                if (blnFlag)
                {
                    objBounds.X = objRectangle.X + (objRectangle.Right - objBounds.Right);
                }
                SetElementBounds(objElement, objBounds);
                if (!blnFlag)
                {
                    fltNum5 += intNum8;
                }
            }
        }

        private bool xAssignRowsAndColumns(ContainerInfo objContainerInfo, LayoutInfo[] arrChildrenInfo, int intMaxColumns, int intMaxRows, TableLayoutPanelGrowStyle enmGrowStyle)
        {
            int intNum = 0;
            int intNum2 = 0;
            ReservationGrid objReservationGrid = new ReservationGrid();
            int intCurrentRow = 0;
            int intNum4 = 0;
            int index = -1;
            int intNum6 = -1;
            LayoutInfo[] arrFixedChildrenInfo = objContainerInfo.FixedChildrenInfo;
            LayoutInfo fixedLayoutInfo = GetNextLayoutInfo(arrFixedChildrenInfo, ref index, true);
            LayoutInfo layoutInfo = GetNextLayoutInfo(arrChildrenInfo, ref intNum6, false);
            while ((fixedLayoutInfo != null) || (layoutInfo != null))
            {
                int intNum8;
                int colStop = intNum4;
                if (layoutInfo != null)
                {
                    layoutInfo.RowStart = intCurrentRow;
                    layoutInfo.ColumnStart = intNum4;
                    this.AdvanceUntilFits(intMaxColumns, objReservationGrid, layoutInfo, out colStop);
                    if (layoutInfo.RowStart >= intMaxRows)
                    {
                        return false;
                    }
                }
                if ((layoutInfo != null) && ((fixedLayoutInfo == null) || (!this.IsCursorPastInsertionPoint(fixedLayoutInfo, layoutInfo.RowStart, colStop) && !this.IsOverlappingWithReservationGrid(fixedLayoutInfo, objReservationGrid, intCurrentRow))))
                {
                    for (int i = 0; i < (layoutInfo.RowStart - intCurrentRow); i++)
                    {
                        objReservationGrid.AdvanceRow();
                    }
                    intCurrentRow = layoutInfo.RowStart;
                    intNum8 = Math.Min(intCurrentRow + layoutInfo.RowSpan, intMaxRows);
                    objReservationGrid.ReserveAll(layoutInfo, intNum8, colStop);
                    layoutInfo = GetNextLayoutInfo(arrChildrenInfo, ref intNum6, false);
                    goto Label_020C;
                }
                if (intNum4 >= intMaxColumns)
                {
                    intNum4 = 0;
                    intCurrentRow++;
                    objReservationGrid.AdvanceRow();
                }
                fixedLayoutInfo.RowStart = Math.Min(fixedLayoutInfo.RowPosition, intMaxRows - 1);
                fixedLayoutInfo.ColumnStart = Math.Min(fixedLayoutInfo.ColumnPosition, intMaxColumns - 1);
                if (intCurrentRow > fixedLayoutInfo.RowStart)
                {
                    fixedLayoutInfo.ColumnStart = intNum4;
                }
                else if (intCurrentRow == fixedLayoutInfo.RowStart)
                {
                    fixedLayoutInfo.ColumnStart = Math.Max(fixedLayoutInfo.ColumnStart, intNum4);
                }
                fixedLayoutInfo.RowStart = Math.Max(fixedLayoutInfo.RowStart, intCurrentRow);
                int intNum10 = 0;
                while (intNum10 < (fixedLayoutInfo.RowStart - intCurrentRow))
                {
                    objReservationGrid.AdvanceRow();
                    intNum10++;
                }
                this.AdvanceUntilFits(intMaxColumns, objReservationGrid, fixedLayoutInfo, out colStop);
                if (fixedLayoutInfo.RowStart < intMaxRows)
                {
                    goto Label_01B0;
                }
                return false;
            Label_01A4:
                objReservationGrid.AdvanceRow();
                intNum10++;
            Label_01B0:
                if (intNum10 < (fixedLayoutInfo.RowStart - intCurrentRow))
                {
                    goto Label_01A4;
                }
                intCurrentRow = fixedLayoutInfo.RowStart;
                colStop = Math.Min(fixedLayoutInfo.ColumnStart + fixedLayoutInfo.ColumnSpan, intMaxColumns);
                intNum8 = Math.Min(fixedLayoutInfo.RowStart + fixedLayoutInfo.RowSpan, intMaxRows);
                objReservationGrid.ReserveAll(fixedLayoutInfo, intNum8, colStop);
                fixedLayoutInfo = GetNextLayoutInfo(arrFixedChildrenInfo, ref index, true);
            Label_020C:
                intNum4 = colStop;
                intNum2 = (intNum2 == 0x7fffffff) ? intNum8 : Math.Max(intNum2, intNum8);
                intNum = (intNum == 0x7fffffff) ? colStop : Math.Max(intNum, colStop);
            }
            if (enmGrowStyle == TableLayoutPanelGrowStyle.FixedSize)
            {
                intNum = intMaxColumns;
                intNum2 = intMaxRows;
            }
            else if (enmGrowStyle == TableLayoutPanelGrowStyle.AddRows)
            {
                intNum = intMaxColumns;
                intNum2 = Math.Max(objContainerInfo.MaxRows, intNum2);
            }
            else
            {
                intNum2 = (intMaxRows == 0x7fffffff) ? intNum2 : intMaxRows;
                intNum = Math.Max(objContainerInfo.MaxColumns, intNum);
            }
            if ((objContainerInfo.Rows == null) || (objContainerInfo.Rows.Length != intNum2))
            {
                objContainerInfo.Rows = new Strip[intNum2];
            }
            if ((objContainerInfo.Columns == null) || (objContainerInfo.Columns.Length != intNum))
            {
                objContainerInfo.Columns = new Strip[intNum];
            }
            objContainerInfo.Valid = true;
            return true;
        }

        private void xDistributeSize(IList objStyles, Strip[] arrStrips, int intStart, int intStop, int intDesiredLength, SizeProxy sizeProxy, int cellBorderWidth)
        {
            int intNum = 0;
            int intNum2 = 0;
            intDesiredLength -= cellBorderWidth * ((intStop - intStart) - 1);
            intDesiredLength = Math.Max(0, intDesiredLength);
            for (int i = intStart; i < intStop; i++)
            {
                sizeProxy.Strip = arrStrips[i];
                if (!this.IsAbsolutelySized(i, objStyles) && (sizeProxy.Size == 0))
                {
                    intNum2++;
                }
                intNum += sizeProxy.Size;
            }
            int intNum4 = intDesiredLength - intNum;
            if (intNum4 > 0)
            {
                if (intNum2 != 0)
                {
                    int intNum8 = intNum4 / intNum2;
                    int intNum9 = 0;
                    for (int j = intStart; j < intStop; j++)
                    {
                        sizeProxy.Strip = arrStrips[j];
                        if (!this.IsAbsolutelySized(j, objStyles) && (sizeProxy.Size == 0))
                        {
                            intNum9++;
                            if (intNum9 == intNum2)
                            {
                                intNum8 = intNum4 - (intNum8 * (intNum2 - 1));
                            }
                            sizeProxy.Size += intNum8;
                            arrStrips[j] = sizeProxy.Strip;
                        }
                    }
                }
                else
                {
                    int intNum5 = intStop - 1;
                    while (intNum5 >= intStart)
                    {
                        if ((intNum5 < objStyles.Count) && (((TableLayoutStyle)objStyles[intNum5]).SizeType == SizeType.Percent))
                        {
                            break;
                        }
                        intNum5--;
                    }
                    if (intNum5 != (intStart - 1))
                    {
                        intStop = intNum5 + 1;
                    }
                    for (int k = intStop - 1; k >= intStart; k--)
                    {
                        if (!this.IsAbsolutelySized(k, objStyles))
                        {
                            sizeProxy.Strip = arrStrips[k];
                            if (((k != (arrStrips.Length - 1)) && !arrStrips[k + 1].IsStart) && !this.IsAbsolutelySized(k + 1, objStyles))
                            {
                                sizeProxy.Strip = arrStrips[k + 1];
                                int intNum7 = Math.Min(sizeProxy.Size, intNum4);
                                sizeProxy.Size -= intNum7;
                                arrStrips[k + 1] = sizeProxy.Strip;
                                sizeProxy.Strip = arrStrips[k];
                            }
                            sizeProxy.Size += intNum4;
                            arrStrips[k] = sizeProxy.Strip;
                            return;
                        }
                    }
                }
            }
        }

        #endregion

        #region Internal Methods

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
            ContainerInfo info = objContainer.GetValue<ContainerInfo>(Control.ContainerInfoProperty);
            if (info == null)
            {
                info = new ContainerInfo(objContainer);
                objContainer.SetValue<ContainerInfo>(Control.ContainerInfoProperty, info);
            }
            return info;
        }

        internal IArrangedElement GetControlFromPosition(IArrangedElement objContainer, int intColumn, int intRow)
        {
            if (intRow < 0)
            {
                throw new ArgumentException(SR.GetString("InvalidArgument", new object[] { "RowPosition", intRow.ToString(CultureInfo.CurrentCulture) }));
            }
            if (intColumn < 0)
            {
                throw new ArgumentException(SR.GetString("InvalidArgument", new object[] { "ColumnPosition", intColumn.ToString(CultureInfo.CurrentCulture) }));
            }
            ArrangedElementCollection objChildren = objContainer.Children;
            ContainerInfo objContainerInfo = GetContainerInfo(objContainer);
            if ((objChildren != null) && (objChildren.Count != 0))
            {
                if (!objContainerInfo.Valid)
                {
                    this.EnsureRowAndColumnAssignments(objContainer, objContainerInfo, true);
                }
                for (int i = 0; i < objChildren.Count; i++)
                {
                    LayoutInfo objLayoutInfo = GetLayoutInfo(objChildren[i]);
                    if (((objLayoutInfo.ColumnStart <= intColumn) && (((objLayoutInfo.ColumnStart + objLayoutInfo.ColumnSpan) - 1) >= intColumn)) && ((objLayoutInfo.RowStart <= intRow) && (((objLayoutInfo.RowStart + objLayoutInfo.RowSpan) - 1) >= intRow)))
                    {
                        return objLayoutInfo.Element;
                    }
                }
            }
            return null;
        }

        internal static LayoutInfo GetLayoutInfo(IArrangedElement objElement)
        {
            LayoutInfo info = objElement.GetValue<LayoutInfo>(Control.LayoutInfoProperty);
            if (info == null)
            {
                info = new LayoutInfo(objElement);
                SetLayoutInfo(objElement, info);
            }
            return info;
        }

        internal TableLayoutPanelCellPosition GetPositionFromControl(IArrangedElement objContainer, IArrangedElement objChild)
        {
            if ((objContainer == null) || (objChild == null))
            {
                return new TableLayoutPanelCellPosition(-1, -1);
            }
            ArrangedElementCollection objChildren = objContainer.Children;
            ContainerInfo objContainerInfo = GetContainerInfo(objContainer);
            if ((objChildren == null) || (objChildren.Count == 0))
            {
                return new TableLayoutPanelCellPosition(-1, -1);
            }
            if (!objContainerInfo.Valid)
            {
                this.EnsureRowAndColumnAssignments(objContainer, objContainerInfo, true);
            }
            LayoutInfo layoutInfo = GetLayoutInfo(objChild);
            return new TableLayoutPanelCellPosition(layoutInfo.ColumnStart, layoutInfo.RowStart);
        }

        internal override Size GetPreferredSize(IArrangedElement objContainer, Size objProposedConstraints)
        {
            ContainerInfo objContainerInfo = GetContainerInfo(objContainer);
            bool blnIsValid = false;
            float fltSize = -1f;
            Size objCachedPreferredSize = objContainerInfo.GetCachedPreferredSize(objProposedConstraints, out blnIsValid);
            if (blnIsValid)
            {
                return objCachedPreferredSize;
            }
            ContainerInfo objContainerInfo2 = new ContainerInfo(objContainerInfo);
            int intCellBorderWidth = objContainerInfo.CellBorderWidth;
            if (((objContainerInfo.MaxColumns == 1) && (objContainerInfo.ColumnStyles.Count > 0)) && (objContainerInfo.ColumnStyles[0].SizeType == SizeType.Absolute))
            {
                Size objSize2 = GetElementBounds(objContainer).Size - new Size(intCellBorderWidth * 2, intCellBorderWidth * 2);
                objSize2.Width = Math.Max(objSize2.Width, 1);
                objSize2.Height = Math.Max(objSize2.Height, 1);
                fltSize = objContainerInfo.ColumnStyles[0].Size;
                objContainerInfo.ColumnStyles[0].SetSize(Math.Max(fltSize, (float)Math.Min(objProposedConstraints.Width, objSize2.Width)));
            }
            this.EnsureRowAndColumnAssignments(objContainer, objContainerInfo2, true);
            Size objSize3 = new Size(intCellBorderWidth, intCellBorderWidth);
            objProposedConstraints -= objSize3;
            objProposedConstraints.Width = Math.Max(objProposedConstraints.Width, 1);
            objProposedConstraints.Height = Math.Max(objProposedConstraints.Height, 1);
            if (((objContainerInfo2.Columns != null) && (objContainerInfo.Columns != null)) && (objContainerInfo2.Columns.Length != objContainerInfo.Columns.Length))
            {
                ClearCachedAssignments(objContainerInfo);
            }
            if (((objContainerInfo2.Rows != null) && (objContainerInfo.Rows != null)) && (objContainerInfo2.Rows.Length != objContainerInfo.Rows.Length))
            {
                ClearCachedAssignments(objContainerInfo);
            }
            objCachedPreferredSize = this.ApplyStyles(objContainerInfo2, objProposedConstraints, true);
            if (fltSize >= 0f)
            {
                objContainerInfo.ColumnStyles[0].SetSize(fltSize);
            }
            return (objCachedPreferredSize + objSize3);
        }

        internal static bool HasCachedAssignments(ContainerInfo objContainerInfo)
        {
            return objContainerInfo.Valid;
        }

        internal override bool LayoutCore(IArrangedElement objContainer, LayoutEventArgs objArgs)
        {
            this.ProcessSuspendedLayoutEventArgs(objContainer, objArgs);
            ContainerInfo objContainerInfo = GetContainerInfo(objContainer);
            this.EnsureRowAndColumnAssignments(objContainer, objContainerInfo, false);
            int cellBorderWidth = objContainerInfo.CellBorderWidth;
            Size objProposedConstraints = GetElementBounds(objContainer).Size - new Size(cellBorderWidth, cellBorderWidth);
            objProposedConstraints.Width = Math.Max(objProposedConstraints.Width, 1);
            objProposedConstraints.Height = Math.Max(objProposedConstraints.Height, 1);
            Size objUsedSpace = this.ApplyStyles(objContainerInfo, objProposedConstraints, false);
            this.ExpandLastElement(objContainerInfo, objUsedSpace, objProposedConstraints);
            RectangleF displayRectangle = GetElementBounds(objContainer);
            displayRectangle.Inflate(-(((float)cellBorderWidth) / 2f), ((float)-cellBorderWidth) / 2f);
            this.SetElementBounds(objContainerInfo, displayRectangle);
            mobjSpecifiedBoundsSize = new Size(this.SumStrips(objContainerInfo.Columns, 0, objContainerInfo.Columns.Length), this.SumStrips(objContainerInfo.Rows, 0, objContainerInfo.Rows.Length));
            return mblnIsAutoSize;
        }

        internal override void ProcessSuspendedLayoutEventArgs(IArrangedElement objContainer, LayoutEventArgs objArgs)
        {
            ContainerInfo objContainerInfo = GetContainerInfo(objContainer);
            foreach (string str in marrPropertiesWhichInvalidateCache)
            {
                if (object.ReferenceEquals(objArgs.AffectedProperty, str))
                {
                    ClearCachedAssignments(objContainerInfo);
                    return;
                }
            }
        }

        internal static void SetLayoutInfo(IArrangedElement objElement, LayoutInfo objValue)
        {
            objElement.SetValue<LayoutInfo>(Control.LayoutInfoProperty, objValue);
        }

        internal int SumStrips(Strip[] arrStrips, int intStart, int intSpan)
        {
            int intNum = 0;
            for (int i = intStart; i < Math.Min(intStart + intSpan, arrStrips.Length); i++)
            {
                Strip objStrip = arrStrips[i];
                intNum += objStrip.MinSize;
            }
            return intNum;
        }

        #endregion

        #endregion

        #region Strip Structure

        [StructLayout(LayoutKind.Sequential), Serializable()]

        internal struct Strip
        {
            private int mintMaxSize;
            private int mintMinSize;
            private bool mblnIsStart;

            public int MinSize
            {
                get
                {
                    return this.mintMinSize;
                }
                set
                {
                    this.mintMinSize = value;
                }
            }

            public int MaxSize
            {
                get
                {
                    return this.mintMaxSize;
                }
                set
                {
                    this.mintMaxSize = value;
                }
            }

            public bool IsStart
            {
                get
                {
                    return this.mblnIsStart;
                }
                set
                {
                    this.mblnIsStart = value;
                }
            }
        }

        #endregion
    }

    #endregion
}
