using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms
{

    /// <summary>
    /// Represents the method that will handle the GroupingChanged event
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.GroupingChangedEventArgs"/> instance containing the event data.</param>
    public delegate void GroupingChangedEventHandler(object sender, GroupingChangedEventArgs e);

    [Serializable()]
    public class GroupingChangedEventArgs : EventArgs
    {
        #region Members

        private DataGridViewGroupingAction menmAction;
        private DataGridViewColumn mobjColumn;

        #endregion Members

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupingChangedEventArgs"/> class.
        /// </summary>
        /// <param name="enmAction">The enm action.</param>
        /// <param name="objColumn">The obj column.</param>
        public GroupingChangedEventArgs(DataGridViewGroupingAction enmAction, DataGridViewColumn objColumn)
        {
            this.menmAction = enmAction;
            this.mobjColumn = objColumn;
        }

        #endregion C'tors

        /// <summary>
        /// Gets the action.
        /// </summary>
        public DataGridViewGroupingAction Action
        {
            get
            {
                return menmAction;
            }
        }

        /// <summary>
        /// Gets the column being added or removed.
        /// </summary>
        public DataGridViewColumn Column
        {
            get
            {
                return mobjColumn;
            }
        }

    }


    #region GroupHeaderFormattingEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.GroupHeaderFormatting"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    public delegate void GroupHeaderFormattingEventHandler(object sender, GroupHeaderFormattingEventArgs e);

    [Serializable()]
    public class GroupHeaderFormattingEventArgs
    {
        #region Members

        private string mstrDataPropertyName;
        private string mstrValue;
        private int mintValueCount;
        private bool mblnFormattingApplied;
        private Label mobjHeaderLabel;
        private DataGridViewRow mobjOwningRow;

        #endregion

        #region Properties


        /// <summary>
        /// Gets the header label.
        /// </summary>
        public Label HeaderLabel
        {
            get
            {
                return mobjHeaderLabel;
            }
        }

        /// <summary>
        /// Gets the owning row.
        /// </summary>
        public DataGridViewRow OwningRow
        {
            get
            {
                return mobjOwningRow;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [formatting applied].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [formatting applied]; otherwise, <c>false</c>.
        /// </value>
        public bool FormattingApplied
        {
            get
            {
                return mblnFormattingApplied;
            }
            set
            {
                if (mblnFormattingApplied != value)
                {
                    mblnFormattingApplied = value;
                }
            }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value
        {
            get
            {
                return mstrValue;
            }
        }

        /// <summary>
        /// Gets the name of the data property.
        /// </summary>
        /// <value>
        /// The name of the data property.
        /// </value>
        public string DataPropertyName
        {
            get
            {
                return mstrDataPropertyName;
            }
        }

        /// <summary>
        /// Gets or sets the value count.
        /// </summary>
        /// <value>
        /// The value count.
        /// </value>
        public int ValueCount
        {
            get
            {
                return mintValueCount;
            }
        }

        #endregion

        #region C'tor


        /// <summary>
        /// Initializes a new instance of the <see cref="GroupHeaderFormattingEventArgs"/> class.
        /// </summary>
        /// <param name="objHeaderLabel">The obj header label.</param>
        /// <param name="strDataPropertyName">Name of the STR data property.</param>
        /// <param name="intValueCount">The int value count.</param>
        /// <param name="strValue">The STR value.</param>
        /// <param name="objOwningRow">The obj owning row.</param>
        internal GroupHeaderFormattingEventArgs(Label objHeaderLabel, string strDataPropertyName, int intValueCount, string strValue, DataGridViewRow objOwningRow)
        {
            this.mintValueCount = intValueCount;
            this.mstrDataPropertyName = strDataPropertyName;
            this.mstrValue = strValue;
            this.mblnFormattingApplied = false;
            this.mobjHeaderLabel = objHeaderLabel;
            this.mobjOwningRow = objOwningRow;
        }

        #endregion
    }

    #endregion

    #region QuestionEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CancelRowEdit"></see> event or the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowDirtyStateNeeded"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void QuestionEventHandler(object sender, QuestionEventArgs e);

    /// <summary>Provides data for events that need a true or false answer to a question.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class QuestionEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.QuestionEventArgs"></see> class using a default <see cref="P:Gizmox.WebGUI.Forms.QuestionEventArgs.Response"></see> property value of false.</summary>
        public QuestionEventArgs()
        {
            this.mblnResponse = false;
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.QuestionEventArgs"></see> class using the specified default value for the <see cref="P:Gizmox.WebGUI.Forms.QuestionEventArgs.Response"></see> property.</summary>
        /// <param name="blnResponse">The default value of the <see cref="P:Gizmox.WebGUI.Forms.QuestionEventArgs.Response"></see> property.</param>
        public QuestionEventArgs(bool blnResponse)
        {
            this.mblnResponse = blnResponse;
        }


        /// <summary>Gets or sets a value indicating the response to a question represented by the event.</summary>
        /// <returns>true for an affirmative response; otherwise, false. </returns>
        /// <filterpriority>1</filterpriority>
        public bool Response
        {
            get
            {
                return this.mblnResponse;
            }
            set
            {
                this.mblnResponse = value;
            }
        }


        private bool mblnResponse;
    }
    #endregion

    #region DataGridViewCellStyleChangedEvent


    [Serializable()]
    internal class DataGridViewCellStyleChangedEventArgs : EventArgs
    {
        internal DataGridViewCellStyleChangedEventArgs()
        {
        }


        internal bool ChangeAffectsPreferredSize
        {
            get
            {
                return this.mblnChangeAffectsPreferredSize;
            }
            set
            {
                this.mblnChangeAffectsPreferredSize = value;
            }
        }


        private bool mblnChangeAffectsPreferredSize;
    }
    #endregion

    #region DataGridViewRowHeightInfoPushedEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeightInfoPushed"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    public delegate void DataGridViewRowHeightInfoPushedEventHandler(object sender, DataGridViewRowHeightInfoPushedEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeightInfoPushed"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>

    [Serializable()]
    public class DataGridViewRowHeightInfoPushedEventArgs : HandledEventArgs
    {
        internal DataGridViewRowHeightInfoPushedEventArgs(int intRowIndex, int intHeight, int intMinimumHeight)
            : base(false)
        {
            this.mintRowIndex = intRowIndex;
            this.mintHeight = intHeight;
            this.mintMinimumHeight = intMinimumHeight;
        }


        /// <summary>Gets the height of the row the event occurred for.</summary>
        /// <returns>The row height, in pixels.</returns>
        public int Height
        {
            get
            {
                return this.mintHeight;
            }
        }

        /// <summary>Gets the minimum height of the row the event occurred for.</summary>
        /// <returns>The minimum row height, in pixels.</returns>
        public int MinimumHeight
        {
            get
            {
                return this.mintMinimumHeight;
            }
        }

        /// <summary>Gets the index of the row the event occurred for.</summary>
        /// <returns>The zero-based index of the row.</returns>
        public int RowIndex
        {
            get
            {
                return this.mintRowIndex;
            }
        }

        private int mintHeight;
        private int mintMinimumHeight;
        private int mintRowIndex;
    }
    #endregion

    #region DataGridViewRowHeightInfoNeededEvent

    /// <summary>Represents the method that will handle an <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeightInfoNeeded"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
    public delegate void DataGridViewRowHeightInfoNeededEventHandler(object sender, DataGridViewRowHeightInfoNeededEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeightInfoNeeded"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>

    [Serializable()]
    public class DataGridViewRowHeightInfoNeededEventArgs : EventArgs
    {
        internal DataGridViewRowHeightInfoNeededEventArgs()
        {
            this.mintRowIndex = -1;
            this.mintHeight = -1;
            this.mintMinimumHeight = -1;
        }

        internal void SetProperties(int intRowIndex, int intHeight, int intMinimumHeight)
        {
            this.mintRowIndex = intRowIndex;
            this.mintHeight = intHeight;
            this.mintMinimumHeight = intMinimumHeight;
        }


        /// <summary>Gets or sets the height of the row the event occurred for.</summary>
        /// <returns>The row height. </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is greater than 65,536. </exception>
        public int Height
        {
            get
            {
                return this.mintHeight;
            }
            set
            {
                if (value < this.mintMinimumHeight)
                {
                    value = this.mintMinimumHeight;
                }
                if (value > 0x10000)
                {
                    //TODO: DATAGGRID
                    throw new ArgumentOutOfRangeException();
                    //  object[] objArray1 = new object[] { "Height", value.ToString(CultureInfo.CurrentCulture), 0x10000.ToString(CultureInfo.CurrentCulture) };
                    // throw new ArgumentOutOfRangeException("Height", SR.GetString("InvalidHighBoundArgumentEx", objArray1));
                }
                this.mintHeight = value;
            }
        }

        /// <summary>Gets or sets the minimum height of the row the event occurred for. </summary>
        /// <returns>The minimum row height.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than 2.</exception>
        public int MinimumHeight
        {
            get
            {
                return this.mintMinimumHeight;
            }
            set
            {
                if (value < 2)
                {
                    // TODO:DATAGRID
                    throw new ArgumentOutOfRangeException();
                    //object[] objArray1 = new object[] { 2.ToString(CultureInfo.CurrentCulture) };
                    //throw new ArgumentOutOfRangeException("MinimumHeight", value, SR.GetString("DataGridViewBand_MinimumHeightSmallerThanOne", objArray1));

                }
                if (this.mintHeight < value)
                {
                    this.mintHeight = value;
                }
                this.mintMinimumHeight = value;
            }
        }

        /// <summary>Gets the index of the row associated with this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeightInfoNeededEventArgs"></see>.</summary>
        /// <returns>The zero-based index of the row the event occurred for.</returns>
        public int RowIndex
        {
            get
            {
                return this.mintRowIndex;
            }
        }

        private int mintHeight;
        private int mintMinimumHeight;
        private int mintRowIndex;
    }
    #endregion

    #region DataGridViewRowErrorTextNeededEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowErrorTextNeeded"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    public delegate void DataGridViewRowErrorTextNeededEventHandler(object sender, DataGridViewRowErrorTextNeededEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowErrorTextNeeded"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>

    [Serializable()]
    public class DataGridViewRowErrorTextNeededEventArgs : EventArgs
    {
        internal DataGridViewRowErrorTextNeededEventArgs(int intRowIndex, string strErrorText)
        {
            this.mintRowIndex = intRowIndex;
            this.mstrErrorText = strErrorText;
        }


        /// <summary>Gets or sets the error text for the row.</summary>
        /// <returns>A string that represents the error text for the row.</returns>
        public string ErrorText
        {
            get
            {
                return this.mstrErrorText;
            }
            set
            {
                this.mstrErrorText = value;
            }
        }

        /// <summary>Gets the row that raised the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowErrorTextNeeded"></see> event.</summary>
        /// <returns>The zero based row index for the row.</returns>
        public int RowIndex
        {
            get
            {
                return this.mintRowIndex;
            }
        }


        private string mstrErrorText;
        private int mintRowIndex;
    }
    #endregion

    #region DataGridViewRowDividerDoubleClickEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowDividerDoubleClick"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    public delegate void DataGridViewRowDividerDoubleClickEventHandler(object sender, DataGridViewRowDividerDoubleClickEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowDividerDoubleClick"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>

    [Serializable()]
    public class DataGridViewRowDividerDoubleClickEventArgs : HandledMouseEventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowDividerDoubleClickEventArgs"></see> class. </summary>
        /// <param name="e">A new <see cref="T:Gizmox.WebGUI.Forms.HandledMouseEventArgs"></see> containing the inherited event data.</param>
        /// <param name="intRowIndex">The index of the row above the row divider that was double-clicked.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than -1.</exception>
        public DataGridViewRowDividerDoubleClickEventArgs(int intRowIndex, HandledMouseEventArgs e)
            : base(e.Button, e.Clicks, e.X, e.Y, e.Delta, e.Handled)
        {
            if (intRowIndex < -1)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            this.mintRowIndex = intRowIndex;
        }


        /// <summary>The index of the row above the row divider that was double-clicked.</summary>
        /// <returns>The index of the row above the divider.</returns>
        public int RowIndex
        {
            get
            {
                return this.mintRowIndex;
            }
        }

        private int mintRowIndex;
    }

    #endregion

    #region DataGridViewRowsAddedEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowsAdded"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    public delegate void DataGridViewRowsAddedEventHandler(object sender, DataGridViewRowsAddedEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowsAdded"></see> event. </summary>

    [Serializable()]
    public class DataGridViewRowsAddedEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowsAddedEventArgs"></see> class. </summary>
        /// <param name="intRowCount">The number of rows that have been added.</param>
        /// <param name="intRowIndex">The index of the first added row.</param>
        public DataGridViewRowsAddedEventArgs(int intRowIndex, int intRowCount)
        {
            this.mintRowIndex = intRowIndex;
            this.mintRowCount = intRowCount;
        }


        /// <summary>Gets the number of rows that have been added.</summary>
        /// <returns>The number of rows that have been added.</returns>
        public int RowCount
        {
            get
            {
                return this.mintRowCount;
            }
        }

        /// <summary>Gets the index of the first added row.</summary>
        /// <returns>The index of the first added row.</returns>
        public int RowIndex
        {
            get
            {
                return this.mintRowIndex;
            }
        }

        private int mintRowCount;
        private int mintRowIndex;
    }
    #endregion

    #region DataGridViewRowsRemovedEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowsRemoved"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    public delegate void DataGridViewRowsRemovedEventHandler(object sender, DataGridViewRowsRemovedEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowsRemoved"></see> event.</summary>

    [Serializable()]
    public class DataGridViewRowsRemovedEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowsRemovedEventArgs"></see> class.</summary>
        /// <param name="intRowCount">The number of rows that were deleted.</param>
        /// <param name="intRowIndex">The zero-based index of the row that was deleted, or the first deleted row if multiple rows were deleted. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0.-or-rowCount is less than 1.</exception>
        public DataGridViewRowsRemovedEventArgs(int intRowIndex, int intRowCount)
        {
            if (intRowIndex < 0)
            {
                // TODO:DATAGRID
                throw new ArgumentOutOfRangeException();
                //object[] objArray1 = new object[] { "rowIndex", rowIndex.ToString(CultureInfo.CurrentCulture), 0.ToString(CultureInfo.CurrentCulture) };
                //throw new ArgumentOutOfRangeException("rowIndex", SR.GetString("InvalidLowBoundArgumentEx", objArray1));
            }
            if (intRowCount < 1)
            {
                // TODO:DATAGRID
                throw new ArgumentOutOfRangeException();
                //object[] objArray2 = new object[] { "rowCount", rowCount.ToString(CultureInfo.CurrentCulture), 1.ToString(CultureInfo.CurrentCulture) };
                //throw new ArgumentOutOfRangeException("rowCount", SR.GetString("InvalidLowBoundArgumentEx", objArray2));
            }
            this.mintRowIndex = intRowIndex;
            this.mintRowCount = intRowCount;
        }


        /// <summary>Gets the number of rows that were deleted.</summary>
        /// <returns>The number of deleted rows.</returns>
        public int RowCount
        {
            get
            {
                return this.mintRowCount;
            }
        }

        /// <summary>Gets the zero-based index of the row deleted, or the first deleted row if multiple rows were deleted.</summary>
        /// <returns>The zero-based index of the row that was deleted, or the first deleted row if multiple rows were deleted.</returns>
        public int RowIndex
        {
            get
            {
                return this.mintRowIndex;
            }
        }

        private int mintRowCount;
        private int mintRowIndex;
    }

    #endregion

    #region DataGridViewRowStateChangedEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowStateChanged"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewRowStateChangedEventHandler(object sender, DataGridViewRowStateChangedEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowStateChanged"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewRowStateChangedEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowStateChangedEventArgs"></see> class. </summary>
        /// <param name="enmElementStateChanged">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the state that has changed on the row.</param>
        /// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has a changed state.</param>
        public DataGridViewRowStateChangedEventArgs(DataGridViewRow objDataGridViewRow, DataGridViewElementStates enmElementStateChanged)
        {
            this.mobjDataGridViewRow = objDataGridViewRow;
            this.menmElementStateChanged = enmElementStateChanged;
        }


        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has a changed state.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that has a changed state.</returns>
        /// <filterpriority>1</filterpriority>
        public DataGridViewRow Row
        {
            get
            {
                return this.mobjDataGridViewRow;
            }
        }

        /// <summary>Gets the state that has changed on the row.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the state that has changed on the row.</returns>
        public DataGridViewElementStates StateChanged
        {
            get
            {
                return this.menmElementStateChanged;
            }
        }


        private DataGridViewRow mobjDataGridViewRow;
        private DataGridViewElementStates menmElementStateChanged;
    }
    #endregion

    #region DataGridViewSortCompareEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.SortCompare"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    public delegate void DataGridViewSortCompareEventHandler(object sender, DataGridViewSortCompareEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.SortCompare"></see> event.</summary>

    [Serializable()]
    public class DataGridViewSortCompareEventArgs : HandledEventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewSortCompareEventArgs"></see> class.</summary>
        /// <param name="objCellValue2">The value of the second cell to compare.</param>
        /// <param name="objDataGridViewColumn">The column to sort.</param>
        /// <param name="intRowIndex2">The index of the row containing the second cell.</param>
        /// <param name="objCellValue1">The value of the first cell to compare.</param>
        /// <param name="intRowIndex1">The index of the row containing the first cell.</param>
        public DataGridViewSortCompareEventArgs(DataGridViewColumn objDataGridViewColumn, object objCellValue1, object objCellValue2, int intRowIndex1, int intRowIndex2)
        {
            this.mobjDataGridViewColumn = objDataGridViewColumn;
            this.mobjCellValue1 = objCellValue1;
            this.mobjCellValue2 = objCellValue2;
            this.mintRowIndex1 = intRowIndex1;
            this.mintRowIndex2 = intRowIndex2;
        }


        /// <summary>Gets the value of the first cell to compare.</summary>
        /// <returns>The value of the first cell.</returns>
        public object CellValue1
        {
            get
            {
                return this.mobjCellValue1;
            }
        }

        /// <summary>Gets the value of the second cell to compare.</summary>
        /// <returns>The value of the second cell.</returns>
        public object CellValue2
        {
            get
            {
                return this.mobjCellValue2;
            }
        }

        /// <summary>Gets the column being sorted. </summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> to sort.</returns>
        public DataGridViewColumn Column
        {
            get
            {
                return this.mobjDataGridViewColumn;
            }
        }

        /// <summary>Gets the index of the row containing the first cell to compare.</summary>
        /// <returns>The index of the row containing the second cell.</returns>
        public int RowIndex1
        {
            get
            {
                return this.mintRowIndex1;
            }
        }

        /// <summary>Gets the index of the row containing the second cell to compare.</summary>
        /// <returns>The index of the row containing the second cell.</returns>
        public int RowIndex2
        {
            get
            {
                return this.mintRowIndex2;
            }
        }

        /// <summary>Gets or sets a value indicating the order in which the compared cells will be sorted.</summary>
        /// <returns>Less than zero if the first cell will be sorted before the second cell; zero if the first cell and second cell have equivalent values; greater than zero if the second cell will be sorted before the first cell.</returns>
        public int SortResult
        {
            get
            {
                return this.mintSortResult;
            }
            set
            {
                this.mintSortResult = value;
            }
        }


        private object mobjCellValue1;
        private object mobjCellValue2;
        private DataGridViewColumn mobjDataGridViewColumn;
        private int mintRowIndex1;
        private int mintRowIndex2;
        private int mintSortResult;
    }

    #endregion

    #region DataGridViewCellToolTipTextNeededEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellToolTipTextNeeded"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    public delegate void DataGridViewCellToolTipTextNeededEventHandler(object sender, DataGridViewCellToolTipTextNeededEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellToolTipTextNeeded"></see> event. </summary>

    [Serializable()]
    public class DataGridViewCellToolTipTextNeededEventArgs : DataGridViewCellEventArgs
    {
        internal DataGridViewCellToolTipTextNeededEventArgs(int intColumnIndex, int intRowIndex, string strToolTipText)
            : base(intColumnIndex, intRowIndex)
        {
            this.mstrToolTipText = strToolTipText;
        }


        /// <summary>Gets or sets the ToolTip text.</summary>
        /// <returns>The current ToolTip text.</returns>
        public string ToolTipText
        {
            get
            {
                return this.mstrToolTipText;
            }
            set
            {
                this.mstrToolTipText = value;
            }
        }


        private string mstrToolTipText;
    }

    #endregion

    #region DataGridViewCellErrorTextNeededEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellErrorTextNeeded"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    public delegate void DataGridViewCellErrorTextNeededEventHandler(object sender, DataGridViewCellErrorTextNeededEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellErrorTextNeeded"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>

    [Serializable()]
    public class DataGridViewCellErrorTextNeededEventArgs : DataGridViewCellEventArgs
    {
        internal DataGridViewCellErrorTextNeededEventArgs(int intColumnIndex, int intRowIndex, string strErrorText)
            : base(intColumnIndex, intRowIndex)
        {
            this.mstrErrorText = strErrorText;
        }


        /// <summary>Gets or sets the message that is displayed when the cell is selected.</summary>
        /// <returns>The error message.</returns>
        public string ErrorText
        {
            get
            {
                return this.mstrErrorText;
            }
            set
            {
                this.mstrErrorText = value;
            }
        }


        private string mstrErrorText;
    }
    #endregion

    #region DataGridViewCellValueEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValueNeeded"></see> event or <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValuePushed"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewCellValueEventHandler(object sender, DataGridViewCellValueEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValueNeeded"></see> and <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValuePushed"></see> events of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewCellValueEventArgs : EventArgs
    {
        internal DataGridViewCellValueEventArgs()
        {
            this.mintColumnIndex = this.mintRowIndex = -1;
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellValueEventArgs"></see> class. </summary>
        /// <param name="intColumnIndex">The index of the column containing the cell that the event occurs for.</param>
        /// <param name="intRowIndex">The index of the row containing the cell that the event occurs for.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than 0.-or-rowIndex is less than 0.</exception>
        public DataGridViewCellValueEventArgs(int intColumnIndex, int intRowIndex)
        {
            if (intColumnIndex < 0)
            {
                throw new ArgumentOutOfRangeException("columnIndex");
            }
            if (intRowIndex < 0)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            this.mintRowIndex = intRowIndex;
            this.mintColumnIndex = intColumnIndex;
        }

        internal void SetProperties(int intColumnIndex, int intRowIndex, object objValue)
        {
            this.mintColumnIndex = intColumnIndex;
            this.mintRowIndex = intRowIndex;
            this.mobjValue = objValue;
        }


        /// <summary>Gets a value indicating the column index of the cell that the event occurs for.</summary>
        /// <returns>The index of the column containing the cell that the event occurs for.</returns>
        /// <filterpriority>1</filterpriority>
        public int ColumnIndex
        {
            get
            {
                return this.mintColumnIndex;
            }
        }

        /// <summary>Gets a value indicating the row index of the cell that the event occurs for.</summary>
        /// <returns>The index of the row containing the cell that the event occurs for.</returns>
        /// <filterpriority>1</filterpriority>
        public int RowIndex
        {
            get
            {
                return this.mintRowIndex;
            }
        }

        /// <summary>Gets or sets the value of the cell that the event occurs for.</summary>
        /// <returns>An <see cref="T:System.Object"></see> representing the cell's value.</returns>
        /// <filterpriority>1</filterpriority>
        public object Value
        {
            get
            {
                return this.mobjValue;
            }
            set
            {
                this.mobjValue = value;
            }
        }


        private int mintColumnIndex;
        private int mintRowIndex;
        private object mobjValue;
    }

    #endregion

    #region DataGridViewCellEvent

    /// <summary>Represents the method that will handle <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events related to cell and row operations.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewCellEventHandler(object sender, DataGridViewCellEventArgs e);

    /// <summary>Provides data for <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events related to cell and row operations.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewCellEventArgs : EventArgs
    {
        internal DataGridViewCellEventArgs(DataGridViewCell objDataGridViewCell)
            : this(objDataGridViewCell.ColumnIndex, objDataGridViewCell.RowIndex)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> class. </summary>
        /// <param name="intColumnIndex">The index of the column containing the cell that the event occurs for.</param>
        /// <param name="intRowIndex">The index of the row containing the cell that the event occurs for.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1.-or-rowIndex is less than -1.</exception>
        public DataGridViewCellEventArgs(int intColumnIndex, int intRowIndex)
        {
            if (intColumnIndex < -1)
            {
                throw new ArgumentOutOfRangeException("columnIndex");
            }
            if (intRowIndex < -1)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            this.mintColumnIndex = intColumnIndex;
            this.mintRowIndex = intRowIndex;
        }


        /// <summary>Gets a value indicating the column index of the cell that the event occurs for.</summary>
        /// <returns>The index of the column containing the cell that the event occurs for.</returns>
        /// <filterpriority>1</filterpriority>
        public int ColumnIndex
        {
            get
            {
                return this.mintColumnIndex;
            }
        }

        /// <summary>Gets a value indicating the row index of the cell that the event occurs for.</summary>
        /// <returns>The index of the row containing the cell that the event occurs for.</returns>
        /// <filterpriority>1</filterpriority>
        public int RowIndex
        {
            get
            {
                return this.mintRowIndex;
            }
        }


        private int mintColumnIndex;
        private int mintRowIndex;
    }

    #endregion

    #region DataGridViewCellContextMenuStripNeededEvent

    /// <summary>Represents the method that will handle a <see cref="E:System.Windows.Forms.DataGridView.CellContextMenuStripNeeded"></see> event of a <see cref="T:System.Windows.Forms.DataGridView"></see>. </summary>
    public delegate void DataGridViewCellContextMenuStripNeededEventHandler(object sender, DataGridViewCellContextMenuStripNeededEventArgs e);

    /// <summary>Provides data for the <see cref="E:System.Windows.Forms.DataGridView.CellContextMenuNeeded"></see> event. </summary>
    [Serializable()]
    public class DataGridViewCellContextMenuStripNeededEventArgs : DataGridViewCellEventArgs
    {
        private ContextMenuStrip mobjContextMenuStrip;

        /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventArgs"></see> class. </summary>
        /// <param name="intColumnIndex">The column index of cell that the event occurred for.</param>
        /// <param name="intRowIndex">The row index of the cell that the event occurred for.</param>
        public DataGridViewCellContextMenuStripNeededEventArgs(int intColumnIndex, int intRowIndex)
            : base(intColumnIndex, intRowIndex)
        {
        }

        internal DataGridViewCellContextMenuStripNeededEventArgs(int intColumnIndex, int intRowIndex, ContextMenuStrip objContextMenuStrip)
            : base(intColumnIndex, intRowIndex)
        {
            this.mobjContextMenuStrip = objContextMenuStrip;
        }

        /// <summary>Gets or sets the shortcut menu for the cell that raised the <see cref="E:System.Windows.Forms.DataGridView.CellContextMenuStripNeeded"></see> event.</summary>
        /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> for the cell. </returns>
        public ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return this.mobjContextMenuStrip;
            }
            set
            {
                this.mobjContextMenuStrip = value;
            }
        }
    }

    #endregion

    #region DataGridViewCellContextMenuNeededEvent

    /// <summary>Represents the method that will handle a <see cref="E:System.Windows.Forms.DataGridView.CellContextMenuNeeded"></see> event of a <see cref="T:System.Windows.Forms.DataGridView"></see>. </summary>
    public delegate void DataGridViewCellContextMenuNeededEventHandler(object sender, DataGridViewCellContextMenuNeededEventArgs e);

    /// <summary>Provides data for the <see cref="E:System.Windows.Forms.DataGridView.CellContextMenuNeeded"></see> event. </summary>
    [Serializable()]
    public class DataGridViewCellContextMenuNeededEventArgs : DataGridViewCellEventArgs
    {
        private ContextMenu mobjContextMenu;

        /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.DataGridViewCellContextMenuNeededEventArgs"></see> class. </summary>
        /// <param name="intColumnIndex">The column index of cell that the event occurred for.</param>
        /// <param name="intRowIndex">The row index of the cell that the event occurred for.</param>
        public DataGridViewCellContextMenuNeededEventArgs(int intColumnIndex, int intRowIndex)
            : base(intColumnIndex, intRowIndex)
        {
        }

        internal DataGridViewCellContextMenuNeededEventArgs(int intColumnIndex, int intRowIndex, ContextMenu objContextMenu)
            : base(intColumnIndex, intRowIndex)
        {
            this.mobjContextMenu = objContextMenu;
        }

        /// <summary>Gets or sets the shortcut menu for the cell that raised the <see cref="E:System.Windows.Forms.DataGridView.CellContextMenuNeeded"></see> event.</summary>
        /// <returns>The <see cref="T:System.Windows.Forms.ContextMenu"></see> for the cell. </returns>
        public ContextMenu ContextMenu
        {
            get
            {
                return this.mobjContextMenu;
            }
            set
            {
                this.mobjContextMenu = value;
            }
        }
    }

    #endregion

    #region DataGridViewCellParsingEvent

    /// <summary>Represents the method that will handle a <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellParsing"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewCellParsingEventHandler(object sender, DataGridViewCellParsingEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellParsing"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewCellParsingEventArgs : ConvertEventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellParsingEventArgs"></see> class. </summary>
        /// <param name="objInheritedCellStyle">The style applied to the cell that was changed.</param>
        /// <param name="intColumnIndex">The column index of the cell that was changed.</param>
        /// <param name="intRowIndex">The row index of the cell that was changed.</param>
        /// <param name="objDesiredType">The type of the new value.</param>
        /// <param name="objValue">The new value.</param>
        public DataGridViewCellParsingEventArgs(int intRowIndex, int intColumnIndex, object objValue, Type objDesiredType, DataGridViewCellStyle objInheritedCellStyle)
            : base(objValue, objDesiredType)
        {
            this.mintRowIndex = intRowIndex;
            this.mintColumnIndex = intColumnIndex;
            this.mobjInheritedCellStyle = objInheritedCellStyle;
        }


        /// <summary>Gets the column index of the cell data that requires parsing.</summary>
        /// <returns>The column index of the cell that was changed.</returns>
        /// <filterpriority>1</filterpriority>
        public int ColumnIndex
        {
            get
            {
                return this.mintColumnIndex;
            }
        }

        /// <summary>Gets or sets the style applied to the edited cell.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the current style of the cell being edited. The default value is the value of the cell <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.InheritedStyle"></see> property.</returns>
        public DataGridViewCellStyle InheritedCellStyle
        {
            get
            {
                return this.mobjInheritedCellStyle;
            }
            set
            {
                this.mobjInheritedCellStyle = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether a cell's value has been successfully parsed.</summary>
        /// <returns>true if the cell's value has been successfully parsed; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        public bool ParsingApplied
        {
            get
            {
                return this.mblnParsingApplied;
            }
            set
            {
                this.mblnParsingApplied = value;
            }
        }

        /// <summary>Gets the row index of the cell that requires parsing.</summary>
        /// <returns>The row index of the cell that was changed.</returns>
        /// <filterpriority>1</filterpriority>
        public int RowIndex
        {
            get
            {
                return this.mintRowIndex;
            }
        }


        private int mintColumnIndex;
        private DataGridViewCellStyle mobjInheritedCellStyle;
        private bool mblnParsingApplied;
        private int mintRowIndex;
    }
    #endregion

    #region DataGridViewCellValidatingEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    public delegate void DataGridViewCellValidatingEventHandler(object sender, DataGridViewCellValidatingEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValidating"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>

    [Serializable()]
    public class DataGridViewCellValidatingEventArgs : CancelEventArgs
    {
        internal DataGridViewCellValidatingEventArgs(int intColumnIndex, int intRowIndex, object objFormattedValue)
        {
            this.mintRowIndex = intRowIndex;
            this.mintColumnIndex = intColumnIndex;
            this.mobjFormattedValue = objFormattedValue;
        }


        /// <summary>Gets the column index of the cell that needs to be validated.</summary>
        /// <returns>A zero-based integer that specifies the column index of the cell that needs to be validated.</returns>
        public int ColumnIndex
        {
            get
            {
                return this.mintColumnIndex;
            }
        }

        /// <summary>Gets the formatted contents of the cell that needs to be validated.</summary>
        /// <returns>A reference to the formatted value.</returns>
        public object FormattedValue
        {
            get
            {
                return this.mobjFormattedValue;
            }
        }

        /// <summary>Gets the row index of the cell that needs to be validated.</summary>
        /// <returns>A zero-based integer that specifies the row index of the cell that needs to be validated.</returns>
        public int RowIndex
        {
            get
            {
                return this.mintRowIndex;
            }
        }

        private int mintColumnIndex;
        private object mobjFormattedValue;
        private int mintRowIndex;
    }
    #endregion

    #region DataGridViewCellFormattingEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellFormatting"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewCellFormattingEventHandler(object sender, DataGridViewCellFormattingEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellFormatting"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewCellFormattingEventArgs : ConvertEventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellFormattingEventArgs"></see> class.</summary>
        /// <param name="objCellStyle">The style of the cell that caused the event.</param>
        /// <param name="intColumnIndex">The column index of the cell that caused the event.</param>
        /// <param name="intRowIndex">The row index of the cell that caused the event.</param>
        /// <param name="objDesiredType">The type to convert value to. </param>
        /// <param name="objValue">The cell's contents.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1-or-rowIndex is less than -1.</exception>
        public DataGridViewCellFormattingEventArgs(int intColumnIndex, int intRowIndex, object objValue, Type objDesiredType, DataGridViewCellStyle objCellStyle)
            : base(objValue, objDesiredType)
        {
            if (intColumnIndex < -1)
            {
                throw new ArgumentOutOfRangeException("columnIndex");
            }
            if (intRowIndex < -1)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            this.mintColumnIndex = intColumnIndex;
            this.mintRowIndex = intRowIndex;
            this.mobjCellStyle = objCellStyle;
        }


        /// <summary>Gets or sets the style of the cell that is being formatted.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the display style of the cell being formatted. The default is the value of the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.InheritedStyle"></see> property. </returns>
        /// <filterpriority>1</filterpriority>
        public DataGridViewCellStyle CellStyle
        {
            get
            {
                return this.mobjCellStyle;
            }
            set
            {
                this.mobjCellStyle = value;
            }
        }

        /// <summary>Gets the column index of the cell that is being formatted.</summary>
        /// <returns>The column index of the cell that is being formatted.</returns>
        /// <filterpriority>1</filterpriority>
        public int ColumnIndex
        {
            get
            {
                return this.mintColumnIndex;
            }
        }

        /// <summary>Gets or sets a value indicating whether the cell value has been successfully formatted.</summary>
        /// <returns>true if the formatting for the cell value has been handled; otherwise, false. The default value is false.</returns>
        /// <filterpriority>1</filterpriority>
        public bool FormattingApplied
        {
            get
            {
                return this.mblnFormattingApplied;
            }
            set
            {
                this.mblnFormattingApplied = value;
            }
        }

        /// <summary>Gets the row index of the cell that is being formatted.</summary>
        /// <returns>The row index of the cell that is being formatted.</returns>
        /// <filterpriority>1</filterpriority>
        public int RowIndex
        {
            get
            {
                return this.mintRowIndex;
            }
        }


        private DataGridViewCellStyle mobjCellStyle;
        private int mintColumnIndex;
        private bool mblnFormattingApplied;
        private int mintRowIndex;
    }
    #endregion

    #region DataGridViewCellCancelEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellBeginEdit"></see> and <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see> events of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewCellCancelEventHandler(object sender, DataGridViewCellCancelEventArgs e);

    [Serializable()]
    public class DataGridViewCellCancelEventArgs : CancelEventArgs
    {
        internal DataGridViewCellCancelEventArgs(DataGridViewCell objDataGridViewCell)
            : this(objDataGridViewCell.ColumnIndex, objDataGridViewCell.RowIndex)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCancelEventArgs"></see> class. </summary>
        /// <param name="intColumnIndex">The index of the column containing the cell that the event occurs for.</param>
        /// <param name="intRowIndex">The index of the row containing the cell that the event occurs for.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1.-or-rowIndex is less than -1.</exception>
        public DataGridViewCellCancelEventArgs(int intColumnIndex, int intRowIndex)
        {
            if (intColumnIndex < -1)
            {
                throw new ArgumentOutOfRangeException("columnIndex");
            }
            if (intRowIndex < -1)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            this.mintColumnIndex = intColumnIndex;
            this.mintRowIndex = intRowIndex;
        }


        /// <summary>Gets the column index of the cell that the event occurs for.</summary>
        /// <returns>The column index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that the event occurs for.</returns>
        /// <filterpriority>1</filterpriority>
        public int ColumnIndex
        {
            get
            {
                return this.mintColumnIndex;
            }
        }

        /// <summary>Gets the row index of the cell that the event occurs for.</summary>
        /// <returns>The row index of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that the event occurs for.</returns>
        /// <filterpriority>1</filterpriority>
        public int RowIndex
        {
            get
            {
                return this.mintRowIndex;
            }
        }

        private int mintColumnIndex;
        private int mintRowIndex;
    }
    #endregion

    #region DataGridViewAutoSizeModeEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeRowsModeChanged"></see> or <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthSizeModeChanged"></see> events of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewAutoSizeModeEventHandler(object sender, DataGridViewAutoSizeModeEventArgs e);

    /// <summary>Provides data for the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see><see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeRowsModeChanged"></see> and <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthSizeModeChanged"></see> events.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewAutoSizeModeEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeModeEventArgs"></see> class.</summary>
        /// <param name="blnPreviousModeAutoSized">true if the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AutoSizeRowsMode"></see> property was previously set to any <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> value other than <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.None"></see> or the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthSizeMode"></see> property was previously set to any <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value other than <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see>; otherwise, false.</param>
        public DataGridViewAutoSizeModeEventArgs(bool blnPreviousModeAutoSized)
        {
            this.mblnPreviousModeAutoSized = blnPreviousModeAutoSized;
        }


        /// <summary>Gets a value specifying whether the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> was previously set to automatically resize.</summary>
        /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AutoSizeRowsMode"></see> property was previously set to any <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode"></see> value other than <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowsMode.None"></see> or the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersWidthSizeMode"></see> property was previously set to any <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode"></see> value other than <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewRowHeadersWidthSizeMode.EnableResizing"></see>; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        public bool PreviousModeAutoSized
        {
            get
            {
                return this.mblnPreviousModeAutoSized;
            }
        }


        private bool mblnPreviousModeAutoSized;
    }

    #endregion

    #region DataGridViewCellMouseEvent

    /// <summary>Represents the method that will handle mouse-related events raised by a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewCellMouseEventHandler(object sender, DataGridViewCellMouseEventArgs e);

    /// <summary>Provides data for mouse events raised by a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> whenever the mouse is moved within a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>. </summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewCellMouseEventArgs : MouseEventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> class.</summary>
        /// <param name="intLocalY">The y-coordinate of the mouse, in pixels.</param>
        /// <param name="intColumnIndex">The cell's zero-based column index.</param>
        /// <param name="e">The originating <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see>.</param>
        /// <param name="intRowIndex">The cell's zero-based row index.</param>
        /// <param name="intLocalX">The x-coordinate of the mouse, in pixels.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1.-or-rowIndex is less than -1.</exception>
        public DataGridViewCellMouseEventArgs(int intColumnIndex, int intRowIndex, int intLocalX, int intLocalY, MouseEventArgs e)
            : base(e.Button, e.Clicks, intLocalX, intLocalY, e.Delta)
        {
            if (intColumnIndex < -1)
            {
                throw new ArgumentOutOfRangeException("columnIndex");
            }
            if (intRowIndex < -1)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            this.mintColumnIndex = intColumnIndex;
            this.mintRowIndex = intRowIndex;
        }


        /// <summary>Gets the zero-based column index of the cell.</summary>
        /// <returns>An integer specifying the column index.</returns>
        /// <filterpriority>1</filterpriority>
        public int ColumnIndex
        {
            get
            {
                return this.mintColumnIndex;
            }
        }

        /// <summary>Gets the zero-based row index of the cell.</summary>
        /// <returns>An integer specifying the row index.</returns>
        /// <filterpriority>1</filterpriority>
        public int RowIndex
        {
            get
            {
                return this.mintRowIndex;
            }
        }

        private int mintColumnIndex;
        private int mintRowIndex;
    }

    #endregion

    #region DataGridViewColumnStateChangedEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnStateChanged"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewColumnStateChangedEventHandler(object sender, DataGridViewColumnStateChangedEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnStateChanged"></see> event. </summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewColumnStateChangedEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnStateChangedEventArgs"></see> class. </summary>
        /// <param name="enmElementStateChanged">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</param>
        /// <param name="objDataGridViewColumn">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> whose state has changed.</param>
        public DataGridViewColumnStateChangedEventArgs(DataGridViewColumn objDataGridViewColumn, DataGridViewElementStates enmElementStateChanged)
        {
            this.mobjDataGridViewColumn = objDataGridViewColumn;
            this.menmElementStateChanged = enmElementStateChanged;
        }


        /// <summary>Gets the column whose state changed.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> whose state changed.</returns>
        /// <filterpriority>1</filterpriority>
        public DataGridViewColumn Column
        {
            get
            {
                return this.mobjDataGridViewColumn;
            }
        }

        /// <summary>Gets the new column state.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values.</returns>
        public DataGridViewElementStates StateChanged
        {
            get
            {
                return this.menmElementStateChanged;
            }
        }


        private DataGridViewColumn mobjDataGridViewColumn;
        private DataGridViewElementStates menmElementStateChanged;
    }

    #endregion

    #region DataGridViewRowContextMenuNeededEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowContextMenuStripNeeded"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    public delegate void DataGridViewRowContextMenuNeededEventHandler(object sender, DataGridViewRowContextMenuNeededEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowContextMenuStripNeeded"></see> event. </summary>

    [Serializable()]
    public class DataGridViewRowContextMenuNeededEventArgs : EventArgs
    {
        private ContextMenu mobjContextMenu;
        private int mintRowIndex;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewRowContextMenuNeededEventArgs"/> class.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        public DataGridViewRowContextMenuNeededEventArgs(int intRowIndex)
        {
            if (intRowIndex < -1)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            this.mintRowIndex = intRowIndex;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewRowContextMenuNeededEventArgs"/> class.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <param name="objContextMenu">The context menu.</param>
        internal DataGridViewRowContextMenuNeededEventArgs(int intRowIndex, ContextMenu objContextMenu)
            : this(intRowIndex)
        {
            this.mobjContextMenu = objContextMenu;
        }

        /// <summary>Gets or sets the shortcut menu for the row that raised the <see cref="E:System.Windows.Forms.DataGridView.RowContextMenuStripNeeded"></see> event.</summary>
        /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> in use.</returns>
        public ContextMenu ContextMenu
        {
            get
            {
                return this.mobjContextMenu;
            }
            set
            {
                this.mobjContextMenu = value;
            }
        }

        /// <summary>Gets the index of the row that is requesting a shortcut menu.</summary>
        /// <returns>The zero-based index of the row that is requesting a shortcut menu.</returns>
        public int RowIndex
        {
            get
            {
                return this.mintRowIndex;
            }
        }

    }

    #endregion

    #region DataGridViewRowContextMenuStripNeededEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowContextMenuStripNeeded"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("DataGridViewRowContextMenuStripNeededEventHandler is obsilete use DataGridViewRowContextMenuNeededEventHandler instead")]
    public delegate void DataGridViewRowContextMenuStripNeededEventHandler(object sender, DataGridViewRowContextMenuStripNeededEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowContextMenuStripNeeded"></see> event. </summary>
    //[Serializable()]
    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("DataGridViewRowContextMenuStripNeededEventArgs  is obsilete use DataGridViewRowContextMenuNeededEventArgs instead")]
    [Serializable()]
    public class DataGridViewRowContextMenuStripNeededEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowContextMenuStripNeededEventArgs"></see> class. </summary>
        /// <param name="intRowIndex">The index of the row.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than -1.</exception>
        public DataGridViewRowContextMenuStripNeededEventArgs(int intRowIndex)
        {
            if (intRowIndex < -1)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            this.mintRowIndex = intRowIndex;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewRowContextMenuStripNeededEventArgs"/> class.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="contextMenuStrip">The context menu strip.</param>
        internal DataGridViewRowContextMenuStripNeededEventArgs(int rowIndex, ContextMenuStrip contextMenuStrip)
            : this(rowIndex)
        {
            this.mobjContextMenuStrip = contextMenuStrip;
        }

        /// <summary>
        /// Gets or sets the context menu strip.
        /// </summary>
        /// <value>The context menu strip.</value>
        public ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return this.mobjContextMenuStrip;
            }
            set
            {
                this.mobjContextMenuStrip = value;
            }
        }

        /// <summary>Gets the index of the row that is requesting a shortcut menu.</summary>
        /// <returns>The zero-based index of the row that is requesting a shortcut menu.</returns>
        public int RowIndex
        {
            get
            {
                return this.mintRowIndex;
            }
        }

        private int mintRowIndex;
        private ContextMenuStrip mobjContextMenuStrip;
    }

    #endregion

    #region DataGridViewRowCancelEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.UserDeletingRow"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewRowCancelEventHandler(object sender, DataGridViewRowCancelEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.UserDeletingRow"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewRowCancelEventArgs : CancelEventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCancelEventArgs"></see> class. </summary>
        /// <param name="objDataGridViewRow">The row the user is deleting.</param>
        public DataGridViewRowCancelEventArgs(DataGridViewRow objDataGridViewRow)
        {
            this.mobjDataGridViewRow = objDataGridViewRow;
        }


        /// <summary>Gets the row that the user is deleting.</summary>
        /// <returns>The row that the user deleted.</returns>
        /// <filterpriority>1</filterpriority>
        public DataGridViewRow Row
        {
            get
            {
                return this.mobjDataGridViewRow;
            }
        }


        private DataGridViewRow mobjDataGridViewRow;
    }
    #endregion

    #region DataGridViewEditingControlShowingEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.EditingControlShowing"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewEditingControlShowingEventHandler(object sender, DataGridViewEditingControlShowingEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.EditingControlShowing"></see> event.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewEditingControlShowingEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewEditingControlShowingEventArgs"></see> class.</summary>
        /// <param name="objCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> representing the style of the cell being edited.</param>
        /// <param name="objControl">A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> in which the user will edit the selected cell's contents.</param>
        public DataGridViewEditingControlShowingEventArgs(Control objControl, DataGridViewCellStyle objCellStyle)
        {
            this.mobjControl = objControl;
            this.mobjCellStyle = objCellStyle;
        }


        /// <summary>Gets or sets the cell style of the edited cell.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> representing the style of the cell being edited.</returns>
        /// <exception cref="T:System.ArgumentNullException">The specified value when setting this property is null.</exception>
        public DataGridViewCellStyle CellStyle
        {
            get
            {
                return this.mobjCellStyle;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                this.mobjCellStyle = value;
            }
        }

        /// <summary>The control shown to the user for editing the selected cell's value.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Control"></see> that displays an area for the user to enter or change the selected cell's value.</returns>
        /// <filterpriority>1</filterpriority>
        public Control Control
        {
            get
            {
                return this.mobjControl;
            }
        }


        private DataGridViewCellStyle mobjCellStyle;
        private Control mobjControl;
    }
    #endregion

    #region DataGridViewRowEvent

    /// <summary>Represents the method that will handle row-related events of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewRowEventHandler(object sender, DataGridViewRowEventArgs e);


    /// <summary>Provides data for row-related <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> events. </summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewRowEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowEventArgs"></see> class. </summary>
        /// <param name="objDataGridViewRow">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that the event occurred for.</param>
        /// <exception cref="T:System.ArgumentNullException">dataGridViewRow is null.</exception>
        public DataGridViewRowEventArgs(DataGridViewRow objDataGridViewRow)
        {
            if (objDataGridViewRow == null)
            {
                throw new ArgumentNullException("dataGridViewRow");
            }
            this.mobjDataGridViewRow = objDataGridViewRow;
        }


        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> associated with the event.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> associated with the event.</returns>
        /// <filterpriority>1</filterpriority>
        public DataGridViewRow Row
        {
            get
            {
                return this.mobjDataGridViewRow;
            }
        }


        private DataGridViewRow mobjDataGridViewRow;
    }

    #endregion

    #region DataGridViewDataErrorEvent


    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewDataErrorEventHandler(object sender, DataGridViewDataErrorEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewDataErrorEventArgs : DataGridViewCellCancelEventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs"></see> class.</summary>
        /// <param name="objException">The exception that occurred.</param>
        /// <param name="intColumnIndex">The column index of the cell that raised the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see>.</param>
        /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values indicating the context in which the error occurred. </param>
        /// <param name="intRowIndex">The row index of the cell that raised the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see>.</param>
        public DataGridViewDataErrorEventArgs(Exception objException, int intColumnIndex, int intRowIndex, DataGridViewDataErrorContexts enmContext)
            : base(intColumnIndex, intRowIndex)
        {
            this.mobjException = objException;
            this.menmContext = enmContext;
        }


        /// <summary>Gets details about the state of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> when the error occurred.</summary>
        /// <returns>A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values that specifies the context in which the error occurred.</returns>
        /// <filterpriority>1</filterpriority>
        public DataGridViewDataErrorContexts Context
        {
            get
            {
                return this.menmContext;
            }
        }

        /// <summary>Gets the exception that represents the error.</summary>
        /// <returns>An <see cref="T:System.Exception"></see> that represents the error.</returns>
        /// <filterpriority>1</filterpriority>
        public Exception Exception
        {
            get
            {
                return this.mobjException;
            }
        }

        /// <summary>Gets or sets a value indicating whether to throw the exception after the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventHandler"></see> delegate is finished with it.</summary>
        /// <returns>true if the exception should be thrown; otherwise, false. The default is false.</returns>
        /// <exception cref="T:System.ArgumentException">When setting this property to true, the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.Exception"></see> property value is null.</exception>
        /// <filterpriority>1</filterpriority>
        public bool ThrowException
        {
            get
            {
                return this.mblnThrowException;
            }
            set
            {
                if (value && (this.mobjException == null))
                {
                    throw new ArgumentException(SR.GetString("DataGridView_CannotThrowNullException"));
                }
                this.mblnThrowException = value;
            }
        }


        private DataGridViewDataErrorContexts menmContext;
        private Exception mobjException;
        private bool mblnThrowException;
    }


    #endregion

    #region DataGridViewColumnEvent

    /// <summary>Represents the method that will handle column-related events of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewColumnEventHandler(object sender, DataGridViewColumnEventArgs e);


    /// <summary>Provides data for column-related events of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewColumnEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnEventArgs"></see> class. </summary>
        /// <param name="objDataGridViewColumn">The column that the event occurs for.</param>
        /// <exception cref="T:System.ArgumentNullException">dataGridViewColumn is null.</exception>
        public DataGridViewColumnEventArgs(DataGridViewColumn objDataGridViewColumn)
        {
            if (objDataGridViewColumn == null)
            {
                throw new ArgumentNullException("dataGridViewColumn");
            }
            this.mobjDataGridViewColumn = objDataGridViewColumn;
        }


        /// <summary>Gets the column that the event occurs for.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> that the event occurs for.</returns>
        /// <filterpriority>1</filterpriority>
        public DataGridViewColumn Column
        {
            get
            {
                return this.mobjDataGridViewColumn;
            }
        }


        private DataGridViewColumn mobjDataGridViewColumn;
    }
    #endregion

    #region DataGridViewColumnDividerDoubleClickEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnDividerDoubleClick"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>
    public delegate void DataGridViewColumnDividerDoubleClickEventHandler(object sender, DataGridViewColumnDividerDoubleClickEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.ColumnDividerDoubleClick"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>. </summary>

    [Serializable()]
    public class DataGridViewColumnDividerDoubleClickEventArgs : HandledMouseEventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDividerDoubleClickEventArgs"></see> class. </summary>
        /// <param name="intColumnIndex">The index of the column next to the column divider that was double-clicked. </param>
        /// <param name="e">A new <see cref="T:Gizmox.WebGUI.Forms.HandledMouseEventArgs"></see> containing the inherited event data. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">columnIndex is less than -1.</exception>
        public DataGridViewColumnDividerDoubleClickEventArgs(int intColumnIndex, HandledMouseEventArgs e)
            : base(e.Button, e.Clicks, e.X, e.Y, e.Delta, e.Handled)
        {
            if (intColumnIndex < -1)
            {
                throw new ArgumentOutOfRangeException("columnIndex");
            }
            this.mintColumnIndex = intColumnIndex;
        }


        /// <summary>The index of the column next to the column divider that was double-clicked.</summary>
        /// <returns>The index of the column next to the divider. </returns>
        public int ColumnIndex
        {
            get
            {
                return this.mintColumnIndex;
            }
        }


        private int mintColumnIndex;
    }
    #endregion

    #region DataGridViewCellStyleContentChangedEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellStyleContentChanged"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewCellStyleContentChangedEventHandler(object sender, DataGridViewCellStyleContentChangedEventArgs e);


    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellStyleContentChanged"></see> event. </summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewCellStyleContentChangedEventArgs : EventArgs
    {
        internal DataGridViewCellStyleContentChangedEventArgs(DataGridViewCellStyle objDataGridViewCellStyle, bool blnChangeAffectsPreferredSize)
        {
            this.mobjDataGridViewCellStyle = objDataGridViewCellStyle;
            this.mblnChangeAffectsPreferredSize = blnChangeAffectsPreferredSize;
        }


        /// <summary>Gets the changed <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
        /// <returns>The changed <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public DataGridViewCellStyle CellStyle
        {
            get
            {
                return this.mobjDataGridViewCellStyle;
            }
        }

        /// <summary>Gets the scope that is affected by the changed cell style.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyleScopes"></see> that indicates which <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> entity owns the cell style that changed.</returns>
        /// <filterpriority>1</filterpriority>
        public DataGridViewCellStyleScopes CellStyleScope
        {
            get
            {
                return this.mobjDataGridViewCellStyle.Scope;
            }
        }

        internal bool ChangeAffectsPreferredSize
        {
            get
            {
                return this.mblnChangeAffectsPreferredSize;
            }
        }


        private bool mblnChangeAffectsPreferredSize;
        private DataGridViewCellStyle mobjDataGridViewCellStyle;
    }


    #endregion

    #region DataGridViewCellStateChangedEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellStateChanged"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewCellStateChangedEventHandler(object sender, DataGridViewCellStateChangedEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellStateChanged"></see> event. </summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewCellStateChangedEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStateChangedEventArgs"></see> class. </summary>
        /// <param name="enmElementStateChanged">One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the state that has changed on the cell.</param>
        /// <param name="objDataGridViewCell">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that has a changed state.</param>
        /// <exception cref="T:System.ArgumentNullException">dataGridViewCell is null.</exception>
        public DataGridViewCellStateChangedEventArgs(DataGridViewCell objDataGridViewCell, DataGridViewElementStates enmElementStateChanged)
        {
            if (objDataGridViewCell == null)
            {
                throw new ArgumentNullException("dataGridViewCell");
            }
            this.mobjDataGridViewCell = objDataGridViewCell;
            this.menmElementStateChanged = enmElementStateChanged;
        }


        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that has a changed state.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> whose state has changed.</returns>
        /// <filterpriority>1</filterpriority>
        public DataGridViewCell Cell
        {
            get
            {
                return this.mobjDataGridViewCell;
            }
        }

        /// <summary>Gets the state that has changed on the cell.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the state that has changed on the cell.</returns>
        public DataGridViewElementStates StateChanged
        {
            get
            {
                return this.menmElementStateChanged;
            }
        }


        private DataGridViewCell mobjDataGridViewCell;
        private DataGridViewElementStates menmElementStateChanged;
    }


    #endregion

    #region DataGridViewAutoSizeColumnsModeEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeColumnsModeChanged"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
    public delegate void DataGridViewAutoSizeColumnsModeEventHandler(object sender, DataGridViewAutoSizeColumnsModeEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeColumnsModeChanged"></see> event. </summary>

    [Serializable()]
    public class DataGridViewAutoSizeColumnsModeEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnsModeEventArgs"></see> class. </summary>
        /// <param name="arrPreviousModes">An array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> values representing the previous <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property values of each column. </param>
        public DataGridViewAutoSizeColumnsModeEventArgs(DataGridViewAutoSizeColumnMode[] arrPreviousModes)
        {
            this.marrPreviousModes = arrPreviousModes;
        }


        /// <summary>Gets an array of the previous values of the column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> properties.</summary>
        /// <returns>An array of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> values representing the previous values of the column <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> properties.</returns>
        public DataGridViewAutoSizeColumnMode[] PreviousModes
        {
            get
            {
                return this.marrPreviousModes;
            }
        }


        private DataGridViewAutoSizeColumnMode[] marrPreviousModes;
    }

    #endregion

    #region DataGridViewAutoSizeColumnModeEventArgs

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeColumnModeChanged"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
    public delegate void DataGridViewAutoSizeColumnModeEventHandler(object sender, DataGridViewAutoSizeColumnModeEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.AutoSizeColumnModeChanged"></see> event. </summary>

    [Serializable()]
    public class DataGridViewAutoSizeColumnModeEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnModeEventArgs"></see> class. </summary>
        /// <param name="enmPreviousMode">The previous <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value of the column's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property. </param>
        /// <param name="objDataGridViewColumn">The column with the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property that changed.</param>
        public DataGridViewAutoSizeColumnModeEventArgs(DataGridViewColumn objDataGridViewColumn, DataGridViewAutoSizeColumnMode enmPreviousMode)
        {
            this.mobjDataGridViewColumn = objDataGridViewColumn;
            this.menmPreviousMode = enmPreviousMode;
        }


        /// <summary>Gets the column with the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property that changed.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> with the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property that changed.</returns>
        public DataGridViewColumn Column
        {
            get
            {
                return this.mobjDataGridViewColumn;
            }
        }

        /// <summary>Gets the previous value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property of the column.</summary>
        /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value representing the previous value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.AutoSizeMode"></see> property of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnModeEventArgs.Column"></see>.</returns>
        public DataGridViewAutoSizeColumnMode PreviousMode
        {
            get
            {
                return this.menmPreviousMode;
            }
        }


        private DataGridViewColumn mobjDataGridViewColumn;
        private DataGridViewAutoSizeColumnMode menmPreviousMode;
    }
    #endregion

    #region DataGridViewBindingCompleteEvent

    /// <summary>Represents the method that will handle the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataBindingComplete"></see> event of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    public delegate void DataGridViewBindingCompleteEventHandler(object sender, DataGridViewBindingCompleteEventArgs e);

    /// <summary>Provides data for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataBindingComplete"></see> event.</summary>
    /// <filterpriority>2</filterpriority>

    [Serializable()]
    public class DataGridViewBindingCompleteEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBindingCompleteEventArgs"></see> class.</summary>
        /// <param name="enmListChangedType">One of the <see cref="T:System.ComponentModel.ListChangedType"></see> values.</param>
        public DataGridViewBindingCompleteEventArgs(ListChangedType enmListChangedType)
        {
            this.menmListChangedType = enmListChangedType;
        }


        /// <summary>Gets a value specifying how the list changed.</summary>
        /// <returns>One of the <see cref="T:System.ComponentModel.ListChangedType"></see> values.</returns>
        /// <filterpriority>1</filterpriority>
        public System.ComponentModel.ListChangedType ListChangedType
        {
            get
            {
                return this.menmListChangedType;
            }
        }


        private ListChangedType menmListChangedType;
    }

    #endregion

    #region DataGridViewColumnChooserEvents

    public delegate void ColumnChooserColumnsVisibilityChangedHandler(object sender, ColumnChooserColumnsVisibilityChangedEventArgs e);

    /// <summary>
    /// Provides data for <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellBeginEdit"></see> and <see cref="E:Gizmox.WebGUI.Forms.DataGridView.RowValidating"></see> events.
    /// </summary>
    [Serializable()]
    public class ColumnChooserColumnsVisibilityChangedEventArgs : EventArgs
    {
        private List<DataGridViewColumn> mobjChangedColumnsVisibility;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnChooserColumnsVisibilityChangedEventArgs"/> class.
        /// </summary>
        /// <param name="objChangedColumnsVisibility">The obj changed columns visibility.</param>
        public ColumnChooserColumnsVisibilityChangedEventArgs(List<DataGridViewColumn> objChangedColumnsVisibility)
        {
            mobjChangedColumnsVisibility = objChangedColumnsVisibility;
        }

        /// <summary>
        /// Gets the changed columns visibility.
        /// </summary>
        public List<DataGridViewColumn> ChangedColumnsVisibility
        {
            get { return mobjChangedColumnsVisibility; }
        }
    }

    #endregion DataGridViewColumnChooserEvents
}
