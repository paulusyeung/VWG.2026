using System;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Specifies the grouping action
    /// </summary>
    [Serializable()]
    public enum DataGridViewGroupingAction
    {
        /// <summary>
        /// Column added to grouping area
        /// </summary>
        Add,
        /// <summary>
        /// Column Removed from grouping area
        /// </summary>
        Remove
    }

    [Serializable()]
    internal enum DataGridViewHitTestTypeCloseEdge
    {
        None,
        Left,
        Right,
        Top,
        Bottom
    }

    /// <summary>Specifies the border style that can be applied to the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersBorderStyle"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersBorderStyle"></see> properties of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public enum DataGridViewHeaderBorderStyle
    {
        /// <summary>
        /// Custom
        /// </summary>
        Custom,
        /// <summary>
        /// Single
        /// </summary>
        Single,
        /// <summary>
        /// Raised
        /// </summary>
        Raised,
        /// <summary>
        /// Sunken
        /// </summary>
        Sunken,
        /// <summary>
        /// None
        /// </summary>
        None
    }

    /// <summary>Specifies the border styles that can be applied to the cells of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public enum DataGridViewCellBorderStyle
    {
        /// <summary>
        /// Custom
        /// </summary>
        Custom,
        /// <summary>
        /// Single
        /// </summary>
        Single,
        /// <summary>
        /// Raised
        /// </summary>
        Raised,
        /// <summary>
        /// Sunken
        /// </summary>
        Sunken,
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// SingleVertical
        /// </summary>
        SingleVertical,
        /// <summary>
        /// RaisedVertical
        /// </summary>
        RaisedVertical,
        /// <summary>
        /// 
        /// </summary>
        SunkenVertical,
        /// <summary>
        /// SingleHorizontal
        /// </summary>
        SingleHorizontal,
        /// <summary>
        /// RaisedHorizontal
        /// </summary>
        RaisedHorizontal,
        /// <summary>
        /// SunkenHorizontal
        /// </summary>
        SunkenHorizontal,
        /// <summary>
        /// Dotted
        /// </summary>
        Dotted
    }

    /// <summary>Defines values for specifying how the height of the column headers is adjusted. </summary>
    [Serializable()]
    public enum DataGridViewColumnHeadersHeightSizeMode
    {
        /// <summary>
        /// EnableResizing
        /// </summary>
        EnableResizing,
        /// <summary>
        /// DisableResizing
        /// </summary>
        DisableResizing,
        /// <summary>
        /// AutoSize
        /// </summary>
        AutoSize
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    internal enum DataGridViewFreeDimension
    {
        /// <summary>
        /// Both
        /// </summary>
        Both,
        /// <summary>
        /// Height
        /// </summary>
        Height,
        /// <summary>
        /// Width
        /// </summary>
        Width
    }

    /// <summary>
    /// DataGridViewAutoSizeColumnCriteriaInternal
    /// </summary>
    [Flags]
    [Serializable()]
    internal enum DataGridViewAutoSizeColumnCriteriaInternal
    {
        /// <summary>
        /// AllRows
        /// </summary>
        AllRows = 4,
        /// <summary>
        /// DisplayedRows
        /// </summary>
        DisplayedRows = 8,
        /// <summary>
        /// Fill
        /// </summary>
        Fill = 0x10,
        /// <summary>
        /// Header
        /// </summary>
        Header = 2,
        /// <summary>
        /// None
        /// </summary>
        None = 1,
        /// <summary>
        /// NotSet
        /// </summary>
        NotSet = 0
    }

    [Flags]
    [Serializable()]
    internal enum DataGridViewAutoSizeRowCriteriaInternal
    {
        AllColumns = 2,
        Header = 1
    }

    [Flags]
    [Serializable()]
    internal enum DataGridViewAutoSizeRowsModeInternal
    {
        AllColumns = 2,
        AllRows = 4,
        DisplayedRows = 8,
        Header = 1,
        None = 0
    }

    /// <summary>Specifies the border styles that can be applied to the cells of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public enum DataGridViewAdvancedCellBorderStyle
    {
        /// <summary>
        /// NotSet
        /// </summary>
        NotSet,
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// Single
        /// </summary>
        Single,
        /// <summary>
        /// Inset
        /// </summary>
        Inset,
        /// <summary>
        /// InsetDouble
        /// </summary>
        InsetDouble,
        /// <summary>
        /// Outset
        /// </summary>
        Outset,
        /// <summary>
        /// OutsetDouble
        /// </summary>
        OutsetDouble,
        /// <summary>
        /// OutsetPartial
        /// </summary>
        OutsetPartial,
        /// <summary>
        /// Dotted
        /// </summary>
        Dotted
    }

    /// <summary>Defines values for specifying how the row header width is adjusted. </summary>
    [Serializable()]
    public enum DataGridViewRowHeadersWidthSizeMode
    {
        /// <summary>
        /// EnableResizing
        /// </summary>
        EnableResizing,
        /// <summary>
        /// DisableResizing
        /// </summary>
        DisableResizing,
        /// <summary>
        /// AutoSizeToAllHeaders
        /// </summary>
        AutoSizeToAllHeaders,
        /// <summary>
        /// AutoSizeToDisplayedHeaders
        /// </summary>
        AutoSizeToDisplayedHeaders,
        /// <summary>
        /// AutoSizeToFirstHeader
        /// </summary>
        AutoSizeToFirstHeader
    }

    /// <summary>Defines values for specifying one of three possible states.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public enum DataGridViewTriState
    {
        /// <summary>
        /// NotSet
        /// </summary>
        NotSet,
        /// <summary>
        /// True
        /// </summary>
        True,
        /// <summary>
        /// False
        /// </summary>
        False
    }

    /// <summary>Describes how cells of a DataGridView control can be selected.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public enum DataGridViewSelectionMode
    {
        /// <summary>
        /// CellSelect
        /// </summary>
        CellSelect = 1,
        /// <summary>
        /// FullRowSelect
        /// </summary>
        FullRowSelect = 2,
        /// <summary>
        /// FullColumnSelect
        /// </summary>
        FullColumnSelect = 4,
        /// <summary>
        /// RowHeaderSelect
        /// </summary>
        RowHeaderSelect = 8,
        /// <summary>
        /// ColumnHeaderSelect
        /// </summary>
        ColumnHeaderSelect = 16
    }

    /// <summary>Defines values for specifying the parts of a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that are to be painted.</summary>
    [Flags]
    [Serializable()]
    public enum DataGridViewPaintParts
    {
        /// <summary>All parts of the cell should be painted.</summary>
        All = 0x7f,
        /// <summary>The background of the cell should be painted.</summary>
        Background = 1,
        /// <summary>The border of the cell should be painted.</summary>
        Border = 2,
        /// <summary>The background of the cell content should be painted.</summary>
        ContentBackground = 4,
        /// <summary>The foreground of the cell content should be painted.</summary>
        ContentForeground = 8,
        /// <summary>The cell error icon should be painted.</summary>
        ErrorIcon = 0x10,
        /// <summary>The focus rectangle should be painted around the cell.</summary>
        Focus = 0x20,
        /// <summary>Nothing should be painted.</summary>
        None = 0,
        /// <summary>The background of the cell should be painted when the cell is selected.</summary>
        SelectionBackground = 0x40
    }

    [Serializable()]
    internal enum DataGridViewCellStyleDifferences
    {
        None,
        AffectPreferredSize,
        DoNotAffectPreferredSize
    }

    /// <summary>Defines constants that indicate the alignment of content within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public enum DataGridViewContentAlignment
    {
        /// <summary>The content is aligned vertically at the bottom and horizontally at the center of a cell.</summary>
        /// <filterpriority>1</filterpriority>
        BottomCenter = 0x200,
        /// <summary>The content is aligned vertically at the bottom and horizontally at the left of a cell.</summary>
        /// <filterpriority>1</filterpriority>
        BottomLeft = 0x100,
        /// <summary>The content is aligned vertically at the bottom and horizontally at the right of a cell.</summary>
        /// <filterpriority>1</filterpriority>
        BottomRight = 0x400,
        /// <summary>The content is aligned at the vertical and horizontal center of a cell.</summary>
        /// <filterpriority>1</filterpriority>
        MiddleCenter = 0x20,
        /// <summary>The content is aligned vertically at the middle and horizontally at the left of a cell.</summary>
        /// <filterpriority>1</filterpriority>
        MiddleLeft = 0x10,
        /// <summary>The content is aligned vertically at the middle and horizontally at the right of a cell.</summary>
        /// <filterpriority>1</filterpriority>
        MiddleRight = 0x40,
        /// <summary>The alignment is not set.</summary>
        /// <filterpriority>1</filterpriority>
        NotSet = 0,
        /// <summary>The content is aligned vertically at the top and horizontally at the center of a cell.</summary>
        /// <filterpriority>1</filterpriority>
        TopCenter = 2,
        /// <summary>The content is aligned vertically at the top and horizontally at the left of a cell.</summary>
        /// <filterpriority>1</filterpriority>
        TopLeft = 1,
        /// <summary>The content is aligned vertically at the top and horizontally at the right of a cell.</summary>
        /// <filterpriority>1</filterpriority>
        TopRight = 4
    }

    /// <summary>Specifies the layout for an image contained in a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public enum DataGridViewImageCellLayout
    {
        /// <summary>
        /// NotSet
        /// </summary>
        NotSet,
        /// <summary>
        /// Normal
        /// </summary>
        Normal,
        /// <summary>
        /// Stretch
        /// </summary>
        Stretch,
        /// <summary>
        /// Zoom
        /// </summary>
        Zoom
    }


    /// <summary>Specifies a location in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public enum DataGridViewHitTestType
    {
        /// <summary>
        /// None
        /// </summary>
        None,
        /// <summary>
        /// Cell
        /// </summary>
        Cell,
        /// <summary>
        /// ColumnHeader
        /// </summary>
        ColumnHeader,
        /// <summary>
        /// RowHeader
        /// </summary>
        RowHeader,
        /// <summary>
        /// TopLeftHeader
        /// </summary>
        TopLeftHeader,
        /// <summary>
        /// HorizontalScrollBar
        /// </summary>
        HorizontalScrollBar,
        /// <summary>
        /// VerticalScrollBar
        /// </summary>
        VerticalScrollBar
    }

    /// <summary>Defines values for specifying how the height of a row is adjusted. </summary>
    [Serializable()]
    public enum DataGridViewAutoSizeRowMode
    {
        /// <summary>The row height adjusts to fit the contents of all cells in the row, including the header cell. </summary>
        AllCells = 3,
        /// <summary>The row height adjusts to fit the contents of all cells in the row, excluding the header cell. </summary>
        AllCellsExceptHeader = 2,
        /// <summary>The row height adjusts to fit the contents of the row header. </summary>
        RowHeader = 1
    }

    /// <summary>Defines values for specifying how the heights of rows are adjusted. </summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public enum DataGridViewAutoSizeRowsMode
    {
        /// <summary>The row heights do not automatically adjust.</summary>
        /// <filterpriority>1</filterpriority>
        None = 0,
        /// <summary>The row heights adjust to fit the contents of all cells in the rows, including header cells. </summary>
        AllCells = 7,
        /// <summary>The row heights adjust to fit the contents of all cells in the rows, excluding header cells. </summary>
        AllCellsExceptHeaders = 6,
        /// <summary>The row heights adjust to fit the contents of the row header. </summary>
        AllHeaders = 5,
        /// <summary>The row heights adjust to fit the contents of all cells in rows currently displayed onscreen, including header cells. </summary>
        DisplayedCells = 11,
        /// <summary>The row heights adjust to fit the contents of all cells in rows currently displayed onscreen, excluding header cells. </summary>
        DisplayedCellsExceptHeaders = 10,
        /// <summary>The row heights adjust to fit the contents of the row headers currently displayed onscreen.</summary>
        DisplayedHeaders = 9

    }

    /// <summary>Specifies the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> entity that owns the cell style that was changed.</summary>
    [Flags]
    [Serializable()]
    public enum DataGridViewCellStyleScopes
    {
        /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AlternatingRowsDefaultCellStyle"></see> property changed.</summary>
        AlternatingRows = 0x80,
        /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Style"></see> property changed.</summary>
        Cell = 1,
        /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.DefaultCellStyle"></see> property changed.</summary>
        Column = 2,
        /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.ColumnHeadersDefaultCellStyle"></see> property changed.</summary>
        ColumnHeaders = 0x10,
        /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.DefaultCellStyle"></see> property changed.</summary>
        DataGridView = 8,
        /// <summary>The owning entity is unspecified.</summary>
        None = 0,
        /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.DefaultCellStyle"></see> property changed.</summary>
        Row = 4,
        /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowHeadersDefaultCellStyle"></see> property changed.</summary>
        RowHeaders = 0x20,
        /// <summary>One or more values of the object returned by the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.RowsDefaultCellStyle"></see> property changed.</summary>
        Rows = 0x40
    }

    /// <summary>Defines constants that indicate whether content is copied from a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control to the Clipboard.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public enum DataGridViewClipboardCopyMode
    {
        /// <summary>
        /// Disable
        /// </summary>
        Disable,
        /// <summary>
        /// EnableWithAutoHeaderText
        /// </summary>
        EnableWithAutoHeaderText,
        /// <summary>
        /// EnableWithoutHeaderText
        /// </summary>
        EnableWithoutHeaderText,
        /// <summary>
        /// EnableAlwaysIncludeHeaderText
        /// </summary>
        EnableAlwaysIncludeHeaderText
    }

    /// <summary>Defines how a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> column can be sorted by the user.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public enum DataGridViewColumnSortMode
    {
        /// <summary>
        /// NotSortable
        /// </summary>
        NotSortable,
        /// <summary>
        /// Automatic
        /// </summary>
        Automatic,
        /// <summary>
        /// Programmatic
        /// </summary>
        Programmatic
    }

    /// <summary>Defines constants that indicate how a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see> is displayed.</summary>
    [Serializable()]
    public enum DataGridViewComboBoxDisplayStyle
    {
        /// <summary>
        /// ComboBox
        /// </summary>
        ComboBox,
        /// <summary>
        /// DropDownButton
        /// </summary>
        DropDownButton,
        /// <summary>
        /// Nothing
        /// </summary>
        Nothing
    }

    /// <summary>Represents the state of a data-bound <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control when a data error occurred.</summary>
    [Flags]
    [Serializable()]
    public enum DataGridViewDataErrorContexts
    {
        /// <summary>A data error occurred when copying content to the Clipboard. This value indicates that the cell value could not be converted to a string.</summary>
        ClipboardContent = 0x4000,
        /// <summary>A data error occurred when committing changes to the data store. This value indicates that data entered in a cell could not be committed to the underlying data store.</summary>
        Commit = 0x200,
        /// <summary>A data error occurred when the selection cursor moved to another cell. This value indicates that a user selected a cell when the previously selected cell had an error condition.</summary>
        CurrentCellChange = 0x1000,
        /// <summary>A data error occurred when displaying a cell that was populated by a data source. This value indicates that the value from the data source cannot be displayed by the cell, or a mapping that translates the value from the data source to the cell is missing.</summary>
        Display = 2,
        /// <summary>A data error occurred when trying to format data that is either being sent to a data store, or being loaded from a data store. This value indicates that a change to a cell failed to format correctly. Either the new cell value needs to be corrected or the cell's formatting needs to change.</summary>
        Formatting = 1,
        /// <summary>A data error occurred when restoring a cell to its previous value. This value indicates that a cell tried to cancel an edit and the rollback to the initial value failed. This can occur if the cell formatting changed so that it is incompatible with the initial value.</summary>
        InitialValueRestoration = 0x400,
        /// <summary>A data error occurred when the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> lost focus. This value indicates that the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> could not commit user changes after losing focus.</summary>
        LeaveControl = 0x800,
        /// <summary>A data error occurred when parsing new data. This value indicates that the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> could not parse new data that was entered by the user or loaded from the underlying data store.</summary>
        Parsing = 0x100,
        /// <summary>A data error occurred when calculating the preferred size of a cell. This value indicates that the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> failed to calculate the preferred width or height of a cell when programmatically resizing a column or row. This can occur if the cell failed to format its value.</summary>
        PreferredSize = 4,
        /// <summary>A data error occurred when deleting a row. This value indicates that the underlying data store threw an exception when a data-bound <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> deleted a row.</summary>
        RowDeletion = 8,
        /// <summary>A data error occurred when scrolling a new region into view. This value indicates that a cell with data errors scrolled into view programmatically or with the scroll bar.</summary>
        Scroll = 0x2000
    }

    /// <summary>Specifies the user interface (UI) state of a element within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    [Flags]
    [Serializable()]
    public enum DataGridViewElementStates
    {
        /// <summary>Indicates the an element is currently displayed onscreen.</summary>
        Displayed = 1,
        /// <summary>Indicates that an element cannot be scrolled through the UI.</summary>
        Frozen = 2,
        /// <summary>Indicates that an element is in its default state.</summary>
        None = 0,
        /// <summary>Indicates that an element will not accept user input to change its value.</summary>
        ReadOnly = 4,
        /// <summary>Indicates that an element can be resized through the UI. This value is ignored except when combined with the <see cref="F:Gizmox.WebGUI.Forms.DataGridViewElementStates.ResizableSet"></see> value.</summary>
        Resizable = 8,
        /// <summary>Indicates that an element does not inherit the resizable state of its parent.</summary>
        ResizableSet = 0x10,
        /// <summary>Indicates that an element is in a selected (highlighted) UI state.</summary>
        Selected = 0x20,
        /// <summary>Indicates that an element is visible (displayable).</summary>
        Visible = 0x40
    }

    /// <summary>
    /// 
    /// </summary>
    [Flags]
    [Serializable()]
    public enum DataGridViewElementClientStates
    {
        /// <summary>
        /// 
        /// </summary>
        None = 0,
        /// <summary>
        /// 
        /// </summary>
        Selected = 2,
        /// <summary>
        /// 
        /// </summary>
        CurrentCell = 4
    }

    /// <summary>Specifies how a user starts cell editing in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public enum DataGridViewEditMode
    {
        /// <summary>
        /// EditOnEnter
        /// </summary>
        EditOnEnter,
        /// <summary>
        /// EditOnKeystroke
        /// </summary>
        EditOnKeystroke,
        /// <summary>
        /// EditOnKeystrokeOrF2
        /// </summary>
        EditOnKeystrokeOrF2,
        /// <summary>
        /// EditOnF2
        /// </summary>
        EditOnF2,
        /// <summary>
        /// EditProgrammatically
        /// </summary>
        EditProgrammatically
    }

    /// <summary>Defines values for specifying how the width of a column is adjusted. </summary>
    [Serializable()]
    public enum DataGridViewAutoSizeColumnMode
    {
        /// <summary>The column width adjusts to fit the contents of all cells in the column, including the header cell. </summary>
        AllCells = 6,
        /// <summary>The column width adjusts to fit the contents of all cells in the column, excluding the header cell. </summary>
        AllCellsExceptHeader = 4,
        /// <summary>The column width adjusts to fit the contents of the column header cell. </summary>
        ColumnHeader = 2,
        /// <summary>The column width adjusts to fit the contents of all cells in the column that are in rows currently displayed onscreen, including the header cell. </summary>
        DisplayedCells = 10,
        /// <summary>The column width adjusts to fit the contents of all cells in the column that are in rows currently displayed onscreen, excluding the header cell. </summary>
        DisplayedCellsExceptHeader = 8,
        /// <summary>The column width adjusts so that the widths of all columns exactly fills the display area of the control, requiring horizontal scrolling only to keep column widths above the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.MinimumWidth"></see> property values. Relative column widths are determined by the relative <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> property values.</summary>
        Fill = 0x10,
        /// <summary>The column width does not automatically adjust.</summary>
        None = 1,
        /// <summary>The sizing behavior of the column is inherited from the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AutoSizeColumnsMode"></see> property.</summary>
        NotSet = 0
    }

    /// <summary>Defines values for specifying how the widths of columns are adjusted. </summary>
    [Serializable()]
    public enum DataGridViewAutoSizeColumnsMode
    {
        /// <summary>The column widths adjust to fit the contents of all cells in the columns, including header cells. </summary>
        AllCells = 6,
        /// <summary>The column widths do not automatically adjust. </summary>
        None = 1,
        /// <summary>The column widths adjust to fit the contents of all cells in the columns, excluding header cells. </summary>
        AllCellsExceptHeader = 4,
        /// <summary>The column widths adjust to fit the contents of the column header cells. </summary>
        ColumnHeader = 2,
        /// <summary>The column widths adjust to fit the contents of all cells in the columns that are in rows currently displayed onscreen, including header cells. </summary>
        DisplayedCells = 10,
        /// <summary>The column widths adjust to fit the contents of all cells in the columns that are in rows currently displayed onscreen, excluding header cells. </summary>
        DisplayedCellsExceptHeader = 8,
        /// <summary>The column widths adjust so that the widths of all columns exactly fill the display area of the control, requiring horizontal scrolling only to keep column widths above the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.MinimumWidth"></see> property values. Relative column widths are determined by the relative <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.FillWeight"></see> property values.</summary>
        Fill = 0x10

    }

    /// <summary>
    /// Navigation Key Filter
    /// </summary>
    [Flags]
    public enum NavigationKeyFilter
    {
        /// <summary>
        /// No filter
        /// </summary>
        None = 0,

        /// <summary>
        /// Arrow down key
        /// </summary>
        Down = 1,

        /// <summary>
        /// Arrow up key
        /// </summary>
        Up = 2,

        /// <summary>
        /// Arrow left key
        /// </summary>
        Left = 4,

        /// <summary>
        /// Arrow right key
        /// </summary>
        Right = 8,

        /// <summary>
        /// Page down key
        /// </summary>
        PageDown = 16,

        /// <summary>
        /// Page up key
        /// </summary>
        PageUp = 32,

        /// <summary>
        /// Home key
        /// </summary>
        Home = 64,

        /// <summary>
        /// End key
        /// </summary>
        End = 128,

        /// <summary>
        /// Enter key
        /// </summary>
        Enter = 256,

        /// <summary>
        /// Tab key
        /// </summary>
        Tab = 512,

        /// <summary>
        /// Filter all navigation keys
        /// </summary>
        All = 1023
    }
}
