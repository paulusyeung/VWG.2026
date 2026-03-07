#region Using

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Collections;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Gateways;
using System.Web;
using System.Data;
using System.Text.RegularExpressions;
using Gizmox.WebGUI.Forms.Skins;
using System.Collections.Generic;

#endregion

namespace Gizmox.WebGUI.Forms
{
    # region DataGridViewCells

    #region DataGridViewCell Class

    /// <summary>Represents an individual cell in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
    /// <filterpriority>2</filterpriority>
    [TypeConverter(typeof(Gizmox.WebGUI.Forms.DataGridViewCellConverter)), Serializable()]
    public abstract class DataGridViewCell : DataGridViewElement, ICloneable, IDisposable, ISkinable
    {

        #region Members

        #region Private Members

        private byte mobjFlags;
        private object mobjEditingProposedValue;
        private DataGridViewRow mobjOwningRow = null;
        private DataGridViewColumn mobjOwningColumn = null;
        private DataGridViewCellStyle mobjStyle = null;
        private object mojValue = null;
        private object mobjToolTipText = null;
        private object mobjTag = null;
        private object mobjValueType = null;
        private object mobjErrorText = null;
        private ContextMenu mobjCellContextMenu = null;
        private ContextMenuStrip mobjCellContextMenuStrip = null;
        private DataGridViewCellPanel mobjPanel = null;

        #endregion Private Members

        #region Constants

        // Fields
        private const int DATAGRIDVIEWCELL_constrastThreshold = 0x3e8;
        private const byte DATAGRIDVIEWCELL_flagAreaNotSet = 0;
        private const byte DATAGRIDVIEWCELL_flagDataArea = 1;
        private const byte DATAGRIDVIEWCELL_flagErrorArea = 2;
        private const int DATAGRIDVIEWCELL_highConstrastThreshold = 0x7d0;
        internal const byte DATAGRIDVIEWCELL_iconMarginHeight = 4;
        internal const byte DATAGRIDVIEWCELL_iconMarginWidth = 4;
        internal const byte DATAGRIDVIEWCELL_iconsHeight = 11;
        internal const byte DATAGRIDVIEWCELL_iconsWidth = 12;
        private const int DATAGRIDVIEWCELL_maxToolTipCutOff = 0x100;
        private const int DATAGRIDVIEWCELL_maxToolTipLength = 0x120;
        private const string DATAGRIDVIEWCELL_toolTipEllipsis = "...";
        private const int DATAGRIDVIEWCELL_toolTipEllipsisLength = 3;
        private const TextFormatFlags textFormatSupportedFlags = (TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine | TextFormatFlags.WordBreak);
        protected const int DefaultHorizontalPadding = 3;
        protected const int DefaultVerticalPadding = 4;

        #endregion

        #region Statics

        private static Bitmap mobjErrorBmp = null;
        private static Type mobjStringType = typeof(string);

        #endregion

        /// <summary>
        /// This memeber holds the formatted value as the user defined it through the pre-rendering procces.
        /// </summary>        
        private object mobjFormattedValue = null;

        /// <summary>
        /// This memeber holds the formatted cell style as the user defined it through the pre-rendering procces.
        /// </summary>
        private DataGridViewCellStyle mobjFormattedCellStyle = null;

        #endregion

        #region C'tors / D'tors

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class. </summary>
        // Methods
        protected DataGridViewCell()
        {
            this.TagName = WGTags.DataGridViewCell;
            base.StateInternal = DataGridViewElementStates.None;
        }

        #endregion C'tors / D'tors

        #region Methods

        #region Events

        internal bool MouseClickUnsharesRowInternal(DataGridViewCellMouseEventArgs e)
        {
            return this.MouseClickUnsharesRow(e);
        }

        internal bool MouseDoubleClickUnsharesRowInternal(DataGridViewCellMouseEventArgs e)
        {
            return this.MouseDoubleClickUnsharesRow(e);
        }

        internal bool MouseDownUnsharesRowInternal(DataGridViewCellMouseEventArgs e)
        {
            return this.MouseDownUnsharesRow(e);
        }

        internal bool MouseEnterUnsharesRowInternal(int intRowIndex)
        {
            return this.MouseEnterUnsharesRow(intRowIndex);
        }

        internal bool MouseLeaveUnsharesRowInternal(int intRowIndex)
        {
            return this.MouseLeaveUnsharesRow(intRowIndex);
        }

        internal bool MouseMoveUnsharesRowInternal(DataGridViewCellMouseEventArgs e)
        {
            return this.MouseMoveUnsharesRow(e);
        }

        internal bool MouseUpUnsharesRowInternal(DataGridViewCellMouseEventArgs e)
        {
            return this.MouseUpUnsharesRow(e);
        }

        internal void OnClickInternal(DataGridViewCellEventArgs e)
        {
            this.OnClick(e);
        }

        internal void OnContentClickInternal(DataGridViewCellEventArgs e)
        {
            this.OnContentClick(e);
        }

        internal void OnContentDoubleClickInternal(DataGridViewCellEventArgs e)
        {
            this.OnContentDoubleClick(e);
        }

        internal void OnDoubleClickInternal(DataGridViewCellEventArgs e)
        {
            this.OnDoubleClick(e);
        }

        internal void OnEnterInternal(int intRowIndex, bool blnThroughMouseClick)
        {
            this.OnEnter(intRowIndex, blnThroughMouseClick);
        }

        internal void OnKeyDownInternal(KeyEventArgs e, int intRowIndex)
        {
            this.OnKeyDown(e, intRowIndex);
        }

        internal void OnKeyPressInternal(KeyPressEventArgs e, int intRowIndex)
        {
            this.OnKeyPress(e, intRowIndex);
        }

        internal void OnKeyUpInternal(KeyEventArgs e, int intRowIndex)
        {
            this.OnKeyUp(e, intRowIndex);
        }

        internal void OnLeaveInternal(int intRowIndex, bool blnThroughMouseClick)
        {
            this.OnLeave(intRowIndex, blnThroughMouseClick);
        }

        internal void OnMouseClickInternal(DataGridViewCellMouseEventArgs e)
        {
            this.OnMouseClick(e);
        }

        internal void OnMouseDoubleClickInternal(DataGridViewCellMouseEventArgs e)
        {
            this.OnMouseDoubleClick(e);
        }

        internal void OnMouseEnterInternal(int intRowIndex)
        {
            this.OnMouseEnter(intRowIndex);
        }

        /// <summary>
        /// Keys the down unshares row internal.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.KeyEventArgs"/> instance containing the event data.</param>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        internal bool KeyDownUnsharesRowInternal(KeyEventArgs e, int intRowIndex)
        {
            return this.KeyDownUnsharesRow(e, intRowIndex);
        }

        /// <summary>
        /// Keys the press unshares row internal.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.KeyPressEventArgs"/> instance containing the event data.</param>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        internal bool KeyPressUnsharesRowInternal(KeyPressEventArgs e, int intRowIndex)
        {
            return this.KeyPressUnsharesRow(e, intRowIndex);
        }

        /// <summary>
        /// Keys the up unshares row internal.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.KeyEventArgs"/> instance containing the event data.</param>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        internal bool KeyUpUnsharesRowInternal(KeyEventArgs e, int intRowIndex)
        {
            return this.KeyUpUnsharesRow(e, intRowIndex);
        }

        /// <summary>Indicates whether the parent row is unshared if the user presses a key while the focus is on the cell.</summary>
        /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        protected virtual bool KeyDownUnsharesRow(KeyEventArgs e, int intRowIndex)
        {
            return false;
        }

        /// <summary>Determines if edit mode should be started based on the given key.</summary>
        /// <returns>true if edit mode should be started; otherwise, false. The default is false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that represents the key that was pressed.</param>
        /// <filterpriority>1</filterpriority>
        public virtual bool KeyEntersEditMode(KeyEventArgs e)
        {
            return false;
        }

        /// <summary>Indicates whether a row will be unshared if a key is pressed while a cell in the row has focus.</summary>
        /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs"></see> that contains the event data. </param>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        protected virtual bool KeyPressUnsharesRow(KeyPressEventArgs e, int intRowIndex)
        {
            return false;
        }

        /// <summary>Indicates whether the parent row is unshared when the user releases a key while the focus is on the cell.</summary>
        /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        protected virtual bool KeyUpUnsharesRow(KeyEventArgs e, int intRowIndex)
        {
            return false;
        }

        /// <summary>Indicates whether a row will be unshared when the focus leaves a cell in the row.</summary>
        /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="blnThroughMouseClick">true if a user action moved focus to the cell; false if a programmatic operation moved focus to the cell.</param>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        protected virtual bool LeaveUnsharesRow(int intRowIndex, bool blnThroughMouseClick)
        {
            return false;
        }

        /// <summary>Indicates whether a row will be unshared if the user clicks a mouse button while the pointer is on a cell in the row.</summary>
        /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
        protected virtual bool MouseClickUnsharesRow(DataGridViewCellMouseEventArgs e)
        {
            return false;
        }

        /// <summary>Indicates whether a row will be unshared if the user double-clicks a cell in the row.</summary>
        /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data.</param>
        protected virtual bool MouseDoubleClickUnsharesRow(DataGridViewCellMouseEventArgs e)
        {
            return false;
        }

        /// <summary>Indicates whether a row will be unshared when the user holds down a mouse button while the pointer is on a cell in the row.</summary>
        /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
        protected virtual bool MouseDownUnsharesRow(DataGridViewCellMouseEventArgs e)
        {
            return false;
        }

        /// <summary>Indicates whether a row will be unshared when the mouse pointer moves over a cell in the row.</summary>
        /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        protected virtual bool MouseEnterUnsharesRow(int intRowIndex)
        {
            return false;
        }

        /// <summary>Indicates whether a row will be unshared when the mouse pointer leaves the row.</summary>
        /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        protected virtual bool MouseLeaveUnsharesRow(int intRowIndex)
        {
            return false;
        }

        /// <summary>Indicates whether a row will be unshared when the mouse pointer moves over a cell in the row.</summary>
        /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
        protected virtual bool MouseMoveUnsharesRow(DataGridViewCellMouseEventArgs e)
        {
            return false;
        }

        /// <summary>Indicates whether a row will be unshared when the user releases a mouse button while the pointer is on a cell in the row.</summary>
        /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
        protected virtual bool MouseUpUnsharesRow(DataGridViewCellMouseEventArgs e)
        {
            return false;
        }

        /// <summary>Called when the cell is clicked.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
        protected virtual void OnClick(DataGridViewCellEventArgs e)
        {
        }

        /// <summary>Called when the cell's contents are clicked.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
        protected virtual void OnContentClick(DataGridViewCellEventArgs e)
        {
        }

        /// <summary>Called when the cell's contents are double-clicked.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
        protected virtual void OnContentDoubleClick(DataGridViewCellEventArgs e)
        {
        }

        /// <summary>Called when the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell changes.</summary>
        protected override void OnDataGridViewChanged()
        {
        }

        /// <summary>Called when the cell is double-clicked.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
        protected virtual void OnDoubleClick(DataGridViewCellEventArgs e)
        {
        }

        /// <summary>Called when the focus moves to a cell.</summary>
        /// <param name="blnThroughMouseClick">true if a user action moved focus to the cell; false if a programmatic operation moved focus to the cell.</param>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        protected virtual void OnEnter(int intRowIndex, bool blnThroughMouseClick)
        {
        }

        /// <summary>Called when a character key is pressed while the focus is on a cell.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        protected virtual void OnKeyDown(KeyEventArgs e, int intRowIndex)
        {
        }

        /// <summary>Called when a key is pressed while the focus is on a cell.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyPressEventArgs"></see> that contains the event data. </param>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        protected virtual void OnKeyPress(KeyPressEventArgs e, int intRowIndex)
        {
        }

        /// <summary>Called when a character key is released while the focus is on a cell.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        protected virtual void OnKeyUp(KeyEventArgs e, int intRowIndex)
        {
        }

        /// <summary>Called when the focus moves from a cell.</summary>
        /// <param name="blnThroughMouseClick">true if a user action moved focus from the cell; false if a programmatic operation moved focus from the cell.</param>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        protected virtual void OnLeave(int intRowIndex, bool blnThroughMouseClick)
        {
        }

        /// <summary>Called when the user clicks a mouse button while the pointer is on a cell.  </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
        protected virtual void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
        }

        /// <summary>Called when the user double-clicks a mouse button while the pointer is on a cell.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
        protected virtual void OnMouseDoubleClick(DataGridViewCellMouseEventArgs e)
        {
        }

        /// <summary>Called when the user holds down a mouse button while the pointer is on a cell.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
        protected virtual void OnMouseDown(DataGridViewCellMouseEventArgs e)
        {
        }

        /// <summary>Called when the mouse pointer moves over a cell.</summary>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        protected virtual void OnMouseEnter(int intRowIndex)
        {
        }

        /// <summary>Called when the mouse pointer leaves the cell.</summary>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        protected virtual void OnMouseLeave(int intRowIndex)
        {
        }

        /// <summary>Called when the mouse pointer moves within a cell.</summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
        protected virtual void OnMouseMove(DataGridViewCellMouseEventArgs e)
        {
        }

        /// <summary>Called when the user releases a mouse button while the pointer is on a cell. </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data. </param>
        protected virtual void OnMouseUp(DataGridViewCellMouseEventArgs e)
        {
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (this.DataGridView != null)
            {
                bool blnCellClickCritical = this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSEDOWN) ||
                                            this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLMOUSEUP) ||
                                            this.DataGridView.IsCriticalEvent(Control.ClickEvent) ||
                                            this.DataGridView.IsCriticalEvent(Control.MouseClickEvent) ||
                                            this.DataGridView.IsCriticalEvent(Control.MouseDownEvent) ||
                                            this.DataGridView.IsCriticalEvent(Control.MouseUpEvent);

                if (blnCellClickCritical ||
                    this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLCLICK) ||
                    this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLCONTENTCLICK))
                {
                    objEvents.Set(WGEvents.Click);
                }

                if (this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLDOUBLECLICK) ||
                    this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLCONTENTDOUBLECLICK) ||
                    this.DataGridView.IsCriticalEvent(Control.DoubleClickEvent))
                {
                    objEvents.Set(WGEvents.DoubleClick);
                }

                if (this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLBEGINEDIT))
                {
                    objEvents.Set(WGEvents.BeginEdit);
                }

                if (this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCELLENDEDIT))
                {
                    objEvents.Set(WGEvents.EndEdit);
                }

                //Get the inherited context menu (from the row / Column/ Grid), if header cell has no owning row (top left header), or it is not a filter row.
                if ((this.OwningRow == null || !this.OwningRow.IsFilterRow) && (blnCellClickCritical ||
                    this.GetInheritedContextMenu(this.RowIndex) != null ||
                    this.GetInheritedContextMenuStrip(this.RowIndex) != null))
                {
                    //Set the Right click event critical if a context menu was found
                    objEvents.Set(WGEvents.RightClick);
                }

            }

            return objEvents;
        }

        /// <summary>
        /// Gets the mouse event captures.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual MouseCaptures GetMouseEventCaptures()
        {
            return MouseCaptures.None;
        }

        /// <summary>
        /// Gets the key event captures.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual KeyCaptures GetKeyEventCaptures()
        {
            return KeyCaptures.None;
        }

        internal void OnCommonChange()
        {
            if (((base.DataGridView != null) && !base.DataGridView.IsDisposed) && !base.DataGridView.Disposing)
            {
                if (this.RowIndex == -1)
                {
                    base.DataGridView.OnColumnCommonChange(this.ColumnIndex);
                }
                else
                {
                    base.DataGridView.OnCellCommonChange(this.ColumnIndex, this.RowIndex);
                }
            }
        }

        /// <summary>
        /// This is a recursive function that loop through a control and all of its parents 
        /// cheching if one of the controls(and control containers) is hidden or
        /// disabled.
        /// </summary>        
        /// <returns>false if one of the controls is hidden or disabled.</returns>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool IsEventsEnabled
        {
            get
            {
                if (!this.Visible)
                {
                    return false;
                }
                else
                {
                    return base.IsEventsEnabled;
                }
            }
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected internal override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            switch (objEvent.Type)
            {
                case "Click":
                    if (this.DataGridView != null)
                    {
                        // Get x and coordinates.
                        int intX = GetEventValue(objEvent, "X", 0);
                        int intY = GetEventValue(objEvent, "Y", 0);

                        // Get relative mouse event args from the event
                        MouseEventArgs objRelativeMouseEventArgs = new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, intX, intY, 0);

                        // If Mouse event args where found test if this is a right click event
                        if (objRelativeMouseEventArgs.Button == MouseButtons.Right)
                        {
                            // Fire the right click event
                            OnRightClick(objRelativeMouseEventArgs);
                        }

                        if (this.DataGridView != null)
                        {
                            // Get absolute mouse event args from the event
                            MouseEventArgs objAbsoluteMouseEventArgs = new MouseEventArgs(objRelativeMouseEventArgs.Button, 1, this.Location.X + intX, this.Location.Y + intY, 0);

                            // Create event arguments variables.
                            DataGridViewCellEventArgs objDataGridViewCellEventArgs = new DataGridViewCellEventArgs(this);
                            DataGridViewCellMouseEventArgs objDataGridViewCellMouseEventArgs = new DataGridViewCellMouseEventArgs(this.ColumnIndex, this.RowIndex, intX, intY, new MouseEventArgs(objRelativeMouseEventArgs.Button, 1, intX, intY, 0));

                            // Raise click events.
                            this.DataGridView.FireClickEvents(objAbsoluteMouseEventArgs, objDataGridViewCellEventArgs, objDataGridViewCellMouseEventArgs);
                        }
                    }
                    break;
                case "DoubleClick":
                    if (this.DataGridView != null)
                    {
                        // Raise double click events.
                        this.DataGridView.FireDoubleClickEvents(new DataGridViewCellEventArgs(this));
                    }
                    break;
                case "BeginEdit":
                    if (this.DataGridView != null)
                    {
                        // Create a DataGridViewCellCancelEventArgs.
                        DataGridViewCellCancelEventArgs objDataGridViewCellCancelEventArgs = new DataGridViewCellCancelEventArgs(this);

                        // Fire the CellBeginEdit event.
                        this.DataGridView.OnCellBeginEdit(objDataGridViewCellCancelEventArgs);

                        // Check if cancelation has been done.
                        if (objDataGridViewCellCancelEventArgs.Cancel)
                        {
                            // Redraw the cell
                            this.Update();
                        }

                    }
                    break;
                case "EndEdit":
                    if (this.DataGridView != null)
                    {
                        // Create event arguments variables.
                        DataGridViewCellEventArgs objDataGridViewCellEventArgs = new DataGridViewCellEventArgs(this);

                        // Fire the CellEndEdit event.
                        this.DataGridView.OnCellEndEdit(objDataGridViewCellEventArgs);
                    }
                    break;
            }
        }

        /// <summary>
        /// Raises the <see cref="E:RightClick"/> event.
        /// </summary>
        /// <param name="objMouseEventArgs">The <see cref="Gizmox.WebGUI.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void OnRightClick(MouseEventArgs objMouseEventArgs)
        {
            ContextMenu objContextMenu = this.GetInheritedContextMenu(this.RowIndex);
            if (objContextMenu != null)
            {
                objContextMenu.Show(this.DataGridView, this, new Point(objMouseEventArgs.X, objMouseEventArgs.Y), DialogAlignment.Custom);
            }
            else
            {
                ContextMenuStrip objContextMenuStrip = this.GetInheritedContextMenuStrip(this.RowIndex);
                if (objContextMenuStrip != null)
                {
                    objContextMenuStrip.Show(this.DataGridView, this, new Point(objMouseEventArgs.X, objMouseEventArgs.Y));
                }
            }
        }

        /// <summary>
        /// Gets the event integer attribute value.
        /// </summary>
        /// <param name="objEvent">The event.</param>
        /// <param name="strAttribute">The attribute name.</param>
        /// <param name="intDefault">The default integer value.</param>
        /// <returns></returns>
        protected int GetEventValue(IEvent objEvent, string strAttribute, int intDefault)
        {
            string strValue = objEvent[strAttribute];
            if (CommonUtils.IsNullOrEmpty(strValue))
            {
                return intDefault;
            }
            else
            {
                return int.Parse(strValue);
            }
        }

        #endregion Events

        #region Render

        /// <summary>
        /// Renders the component event attributes.
        /// </summary>
        /// <param name="objContext">context.</param>
        /// <param name="objWriter">writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderCaptureAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            // The accumalated event captures
            long lngEventCaptures = 0;

            // Get mouse captures
            MouseCaptures enmMouseCaptures = GetMouseEventCaptures();

            //If there are mouse captures
            if (enmMouseCaptures != MouseCaptures.None)
            {
                // Add the mouse captures and turn on the mouse capture flag
                lngEventCaptures = ((long)enmMouseCaptures) + 2;
            }

            // Get the key captures
            KeyCaptures enmKeyCaptures = GetKeyEventCaptures();

            // If there are key captures
            if (enmKeyCaptures != KeyCaptures.None)
            {
                // Add the mouse captures and turn on the mouse capture flag
                lngEventCaptures |= ((long)enmKeyCaptures) + 1;
            }

            // If there are event captures
            if (lngEventCaptures > 0 || blnForceRender)
            {
                // Render event captures
                objWriter.WriteAttributeString(WGAttributes.Captures, lngEventCaptures.ToString());
            }
        }

        /// <summary>
        /// Renders the cell text/value.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objFormatedValue">The formated value.</param>
        protected virtual void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter, bool blnRenderOwner)
        {
            // Renders the cell text/value attributes and retrives a cell style to render.
            RenderCellValue(objContext, objWriter, mobjFormattedValue);

            // Renders the cell style attributes.
            RenderCellStyleAttributes(objWriter, mobjFormattedCellStyle);

            //Render memberID && OwnerID
            base.RenderAttributes(objContext, objWriter, blnRenderOwner);

            // Redner the capture attribute.
            this.RenderCaptureAttribute(objContext, objWriter, false);

            // Serialize type name if needed
            objWriter.WriteAttributeString(WGAttributes.Type, this.TypeName);

            // Renders the read only attribute.
            RenderReadOnlyAttribute(objWriter);

            if (ShouldRender(this.RenderMask, Renderable.SelectedAttribute))
            {
                //render the selected attribute
                RenderSelectedAttribute(objContext, objWriter, false);
            }

            // Render the support active mode attribute
            if (this.SupportActiveMode)
            {
                objWriter.WriteAttributeText(WGAttributes.SupportActiveMode, "1");
            }

            // Check that cell is editable and has no content panel attached/rendered
            if (this.SupportEditMode && (!this.HasPanel || this.DataGridView.CustomStyle == "V"))
            {
                // Render the support edit mode attribute
                objWriter.WriteAttributeText(WGAttributes.SupportEditMode, "1");
            }

            if (this.DataGridView.ShowCellToolTips)
            {
                if (this.HasToolTipText)
                {
                    objWriter.WriteAttributeText(WGAttributes.ToolTip, this.ToolTipText);
                }
                else if (this is DataGridViewTextBoxCell || this is DataGridViewLinkCell)
                {
                    int intPreferredSize = this.DataGridView.Columns[this.ColumnIndex].Width;
                    if (mobjFormattedCellStyle != null)
                    {
                        intPreferredSize = this.GetPreferredSize(this.ValueText, mobjFormattedCellStyle).Width;
                    }

                    if (this.ValueText != string.Empty &&
                        intPreferredSize > this.DataGridView.Columns[this.ColumnIndex].Width &&
                        this.InheritedStyle.WrapMode != DataGridViewTriState.True)
                    {
                        object objFormattedValue = this.FormattedValue;
                        objWriter.WriteAttributeText(WGAttributes.ToolTip, objFormattedValue != null ? objFormattedValue.ToString() : this.ValueText);
                    }
                }

                else if (this.ColumnIndex >= 0 &&
                     this.ColumnIndex < this.DataGridView.Columns.Count &&
                     DataGridView.Columns[this.ColumnIndex].CellTemplate != null &&
                     DataGridView.Columns[this.ColumnIndex].CellTemplate.HasToolTipText
                    )
                {
                    objWriter.WriteAttributeText(WGAttributes.ToolTip, DataGridView.Columns[this.ColumnIndex].CellTemplate.ToolTipText);
                }
            }
        }

        /// <summary>
        /// Renders the cell style attributes.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objCellStyle">The cell style.</param>
        protected virtual void RenderCellStyleAttributes(IAttributeWriter objWriter, DataGridViewCellStyle objCellStyle)
        {
            // Write the Font attribute.
            if (objCellStyle != null)
            {
                if (objCellStyle.Font != null)
                {
                    if (objCellStyle.Font != this.DataGridView.DefaultDefaultCellStyleInternal.Font)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Font, ClientUtils.GetWebFont(objCellStyle.Font));
                    }
                }

                // Render TextImageRelation.
                objWriter.WriteAttributeString(WGAttributes.TextImageRelation, ((int)(TextImageRelation.Overlay)).ToString());

                // Renders the back color attribute.
                RenderBackColorAttribute(objWriter, objCellStyle);

                // Serialize Padding if needed
                if (objCellStyle.Padding != this.DataGridView.DefaultDefaultCellStyleInternal.Padding)
                {
                    if (objCellStyle.Padding.Top != 0)
                    {
                        objWriter.WriteAttributeString(WGAttributes.PaddingTop, Convert.ToString(objCellStyle.Padding.Top));
                    }

                    if (objCellStyle.Padding.Right != 0)
                    {
                        objWriter.WriteAttributeString(WGAttributes.PaddingRight, Convert.ToString(objCellStyle.Padding.Right));
                    }

                    if (objCellStyle.Padding.Bottom != 0)
                    {
                        objWriter.WriteAttributeString(WGAttributes.PaddingBottom, Convert.ToString(objCellStyle.Padding.Bottom));
                    }

                    if (objCellStyle.Padding.Left != 0)
                    {
                        objWriter.WriteAttributeString(WGAttributes.PaddingLeft, Convert.ToString(objCellStyle.Padding.Left));
                    }
                }

                // Renders the wrap mode attribute.
                RenderWrapModeAttribute(objWriter, objCellStyle);

                // Serialize Selection Back Color if needed
                if (objCellStyle.SelectionBackColor != this.DataGridView.DefaultDefaultCellStyleInternal.SelectionBackColor)
                {
                    objWriter.WriteAttributeString(WGAttributes.SelectionBackColor, CommonUtils.GetHtmlColor(objCellStyle.SelectionBackColor));
                }

                // Renders the fore color attribute.
                RenderForeColorAttribute(objWriter, objCellStyle);

                // Serialize Selection Fore color if neeeded
                if (objCellStyle.SelectionForeColor != this.DataGridView.DefaultDefaultCellStyleInternal.SelectionForeColor)
                {
                    objWriter.WriteAttributeString(WGAttributes.SelectionForeColor, CommonUtils.GetHtmlColor(objCellStyle.SelectionForeColor));
                }
            }
        }

        /// <summary>
        /// Renders the updated attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        protected override void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID, blnRenderOwner);

            if (IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                RenderSelectedAttribute(objContext, objWriter, true);

                // Renders the read only attribute.
                RenderReadOnlyAttribute(objWriter);
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Events))
            {
                this.RenderCaptureAttribute(objContext, objWriter, true);
            }
        }

        /// <summary>
        /// Renders the selected attribute.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderSelectedAttribute(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            if (this.Selected && (this.OwningRow != null && !this.OwningRow.Selected) &&
                (this.DataGridView.SelectionMode == DataGridViewSelectionMode.CellSelect ||
                 this.DataGridView.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect))
            {
                objWriter.WriteAttributeString(WGAttributes.Selected, "1");
            }
            else if (blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.Selected, "0");
            }
        }

        /// <summary>
        /// Renders the wrap mode attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
        protected virtual void RenderWrapModeAttribute(IAttributeWriter objWriter, DataGridViewCellStyle objInheritedCellStyle)
        {
            // Serialize WrapMode if needed
            if (objInheritedCellStyle.WrapMode == DataGridViewTriState.True)
            {
                objWriter.WriteAttributeString(WGAttributes.WrapContents, "1");
            }
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        protected override void RenderComponents(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            base.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);

            // Check contained panel.
            if (this.mobjPanel != null)
            {
                // Validate a normal span avlues.
                if (mobjPanel.Colspan > 0 && mobjPanel.Rowspan > 0)
                {
                    // Render contained panel.
                    mobjPanel.RenderControl(objContext, objWriter, lngRequestID);
                }
            }
        }

        /// <summary>
        /// Renders the read only attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        protected virtual void RenderReadOnlyAttribute(IAttributeWriter objWriter)
        {
            //check that grid is not read only
            if (!this.DataGridView.ReadOnly)
            {
                bool blnElementReadOnly;

                //check if the readonly have value
                if (this.GetElementReadOnly(out blnElementReadOnly))
                {
                    //if the readonly value is false and the column or row are readonly then render 0
                    if (!blnElementReadOnly &&
                        (this.OwningColumn.ElementReadOnly == ElementReadOnlyType.True || this.OwningRow.ElementReadOnly == ElementReadOnlyType.True))
                    {
                        objWriter.WriteAttributeString(WGAttributes.ReadOnly, "0");
                    }
                    //if the readonly value is true and and the column and row are not read only then render 1 
                    else if (blnElementReadOnly &&
                            this.OwningColumn.ElementReadOnly != ElementReadOnlyType.True && this.OwningRow.ElementReadOnly != ElementReadOnlyType.True)
                    {
                        objWriter.WriteAttributeString(WGAttributes.ReadOnly, "1");
                    }
                }
            }
        }

        /// <summary>
        /// Renders the fore color attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
        protected virtual void RenderForeColorAttribute(IAttributeWriter objWriter, DataGridViewCellStyle objInheritedCellStyle)
        {
            // Serialize Fore color if neeeded
            if (objInheritedCellStyle.ForeColor != this.DataGridView.DefaultDefaultCellStyleInternal.ForeColor)
            {
                objWriter.WriteAttributeString(WGAttributes.Fore, CommonUtils.GetHtmlColor(objInheritedCellStyle.ForeColor));
            }
        }

        /// <summary>
        /// Renders the back color attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
        protected virtual void RenderBackColorAttribute(IAttributeWriter objWriter, DataGridViewCellStyle objInheritedCellStyle)
        {
            // Serialize back color if needed
            if (objInheritedCellStyle.BackColor != this.DataGridView.DefaultDefaultCellStyleInternal.BackColor)
            {
                objWriter.WriteAttributeString(WGAttributes.Background, CommonUtils.GetHtmlColor(objInheritedCellStyle.BackColor));
            }
        }

        #endregion Render

        #region Paint

        /// <summary>
        /// Paints the current DataGridViewCell.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objClipBounds">The clip bounds.</param>
        /// <param name="objCellBounds">The cell bounds.</param>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <param name="enmCellState">State of the cell.</param>
        /// <param name="objValue">The value.</param>
        /// <param name="objFormattedValue">The formatted value.</param>
        /// <param name="strErrorText">The error text.</param>
        /// <param name="objCellStyle">The cell style.</param>
        /// <param name="objAdvancedBorderStyle">The advanced border style.</param>
        /// <param name="enmPaintParts">The paint parts.</param>
        protected virtual void Paint(Graphics objGraphics, Rectangle objClipBounds, Rectangle objCellBounds, int intRowIndex, DataGridViewElementStates enmCellState, object objValue, object objFormattedValue, string strErrorText, DataGridViewCellStyle objCellStyle, DataGridViewAdvancedBorderStyle objAdvancedBorderStyle, DataGridViewPaintParts enmPaintParts)
        {
        }

        internal static bool PaintBackground(DataGridViewPaintParts paintParts)
        {
            return ((paintParts & DataGridViewPaintParts.Background) != DataGridViewPaintParts.None);
        }

        internal static bool PaintBorder(DataGridViewPaintParts paintParts)
        {
            return ((paintParts & DataGridViewPaintParts.Border) != DataGridViewPaintParts.None);
        }

        internal static bool PaintContentBackground(DataGridViewPaintParts paintParts)
        {
            return ((paintParts & DataGridViewPaintParts.ContentBackground) != DataGridViewPaintParts.None);
        }

        internal static bool PaintContentForeground(DataGridViewPaintParts paintParts)
        {
            return ((paintParts & DataGridViewPaintParts.ContentForeground) != DataGridViewPaintParts.None);
        }

        internal static bool PaintErrorIcon(DataGridViewPaintParts paintParts)
        {
            return ((paintParts & DataGridViewPaintParts.ErrorIcon) != DataGridViewPaintParts.None);
        }

        private static void PaintErrorIcon(Graphics objGraphics, Rectangle objIconBounds)
        {
            Bitmap errorBitmap = ErrorBitmap;
            if (errorBitmap != null)
            {
                lock (errorBitmap)
                {
                    objGraphics.DrawImage(errorBitmap, objIconBounds, 0, 0, 12, 11, GraphicsUnit.Pixel);
                }
            }
        }

        /// <summary>
        /// Paints the error icon of the current DataGridViewCell.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objClipBounds">The clip bounds.</param>
        /// <param name="objCellValueBounds">The cell value bounds.</param>
        /// <param name="strErrorText">The error text.</param>
        protected virtual void PaintErrorIcon(Graphics objGraphics, Rectangle objClipBounds, Rectangle objCellValueBounds, string strErrorText)
        {
            if ((!CommonUtils.IsNullOrEmpty(strErrorText) && (objCellValueBounds.Width >= 20)) && (objCellValueBounds.Height >= 0x13))
            {
                PaintErrorIcon(objGraphics, this.ComputeErrorIconBounds(objCellValueBounds));
            }
        }

        internal void PaintErrorIcon(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex, Rectangle objCellBounds, Rectangle objCellValueBounds, string strErrorText)
        {
            if ((!CommonUtils.IsNullOrEmpty(strErrorText) && (objCellValueBounds.Width >= 20)) && (objCellValueBounds.Height >= 0x13))
            {
                Rectangle objIconBounds = this.GetErrorIconBounds(objGraphics, objCellStyle, intRowIndex);
                if ((objIconBounds.Width >= 4) && (objIconBounds.Height >= 11))
                {
                    objIconBounds.X += objCellBounds.X;
                    objIconBounds.Y += objCellBounds.Y;
                    PaintErrorIcon(objGraphics, objIconBounds);
                }
            }
        }

        internal static bool PaintFocus(DataGridViewPaintParts paintParts)
        {
            return ((paintParts & DataGridViewPaintParts.Focus) != DataGridViewPaintParts.None);
        }

        internal void PaintInternal(Graphics objGraphics, Rectangle objClipBounds, Rectangle objCellBounds, int intRowIndex, DataGridViewElementStates enmCellState, object objValue, object objFormattedValue, string strErrorText, DataGridViewCellStyle objCellStyle, DataGridViewAdvancedBorderStyle objAdvancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            this.Paint(objGraphics, objClipBounds, objCellBounds, intRowIndex, enmCellState, objValue, objFormattedValue, strErrorText, objCellStyle, objAdvancedBorderStyle, paintParts);
        }

        internal static void PaintPadding(Graphics objGraphics, Rectangle objBounds, DataGridViewCellStyle objCellStyle, Brush objBrush, bool blnRightToLeft)
        {
            Rectangle objRectangle;
            if (blnRightToLeft)
            {
                objRectangle = new Rectangle(objBounds.X, objBounds.Y, objCellStyle.Padding.Right, objBounds.Height);
                objGraphics.FillRectangle(objBrush, objRectangle);
                objRectangle.X = objBounds.Right - objCellStyle.Padding.Left;
                objRectangle.Width = objCellStyle.Padding.Left;
                objGraphics.FillRectangle(objBrush, objRectangle);
                objRectangle.X = objBounds.Left + objCellStyle.Padding.Right;
            }
            else
            {
                objRectangle = new Rectangle(objBounds.X, objBounds.Y, objCellStyle.Padding.Left, objBounds.Height);
                objGraphics.FillRectangle(objBrush, objRectangle);
                objRectangle.X = objBounds.Right - objCellStyle.Padding.Right;
                objRectangle.Width = objCellStyle.Padding.Right;
                objGraphics.FillRectangle(objBrush, objRectangle);
                objRectangle.X = objBounds.Left + objCellStyle.Padding.Left;
            }
            objRectangle.Y = objBounds.Y;
            objRectangle.Width = objBounds.Width - objCellStyle.Padding.Horizontal;
            objRectangle.Height = objCellStyle.Padding.Top;
            objGraphics.FillRectangle(objBrush, objRectangle);
            objRectangle.Y = objBounds.Bottom - objCellStyle.Padding.Bottom;
            objRectangle.Height = objCellStyle.Padding.Bottom;
            objGraphics.FillRectangle(objBrush, objRectangle);
        }

        internal static bool PaintSelectionBackground(DataGridViewPaintParts paintParts)
        {
            return ((paintParts & DataGridViewPaintParts.SelectionBackground) != DataGridViewPaintParts.None);
        }

        #endregion Paint

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objCellBounds"></param>
        /// <param name="objCellClip"></param>
        /// <param name="objCellStyle"></param>
        /// <param name="blnSingleVerticalBorderAdded"></param>
        /// <param name="blnSingleHorizontalBorderAdded"></param>
        /// <param name="blnIsFirstDisplayedColumn"></param>
        /// <param name="blnIsFirstDisplayedRow"></param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual Rectangle PositionEditingPanel(Rectangle objCellBounds, Rectangle objCellClip, DataGridViewCellStyle objCellStyle, bool blnSingleVerticalBorderAdded, bool blnSingleHorizontalBorderAdded, bool blnIsFirstDisplayedColumn, bool blnIsFirstDisplayedRow)
        {
            int num;
            int num5;
            if (base.DataGridView == null)
            {
                throw new InvalidOperationException();
            }
            DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStylePlaceholder = new DataGridViewAdvancedBorderStyle();
            DataGridViewAdvancedBorderStyle objAdvancedBorderStyle = this.AdjustCellBorderStyle(base.DataGridView.AdvancedCellBorderStyle, objDataGridViewAdvancedBorderStylePlaceholder, blnSingleVerticalBorderAdded, blnSingleHorizontalBorderAdded, blnIsFirstDisplayedColumn, blnIsFirstDisplayedRow);
            Rectangle objRectangle = this.BorderWidths(objAdvancedBorderStyle);
            objRectangle.X += objCellStyle.Padding.Left;
            objRectangle.Y += objCellStyle.Padding.Top;
            objRectangle.Width += objCellStyle.Padding.Right;
            objRectangle.Height += objCellStyle.Padding.Bottom;
            int intWidth = objCellBounds.Width;
            int intHeight = objCellBounds.Height;
            if ((objCellClip.X - objCellBounds.X) >= objRectangle.X)
            {
                num = objCellClip.X;
                intWidth -= objCellClip.X - objCellBounds.X;
            }
            else
            {
                num = objCellBounds.X + objRectangle.X;
                intWidth -= objRectangle.X;
            }
            if (objCellClip.Right <= (objCellBounds.Right - objRectangle.Width))
            {
                intWidth -= objCellBounds.Right - objCellClip.Right;
            }
            else
            {
                intWidth -= objRectangle.Width;
            }
            int intX = objCellBounds.X - objCellClip.X;
            int num4 = (objCellBounds.Width - objRectangle.X) - objRectangle.Width;
            if ((objCellClip.Y - objCellBounds.Y) >= objRectangle.Y)
            {
                num5 = objCellClip.Y;
                intHeight -= objCellClip.Y - objCellBounds.Y;
            }
            else
            {
                num5 = objCellBounds.Y + objRectangle.Y;
                intHeight -= objRectangle.Y;
            }
            if (objCellClip.Bottom <= (objCellBounds.Bottom - objRectangle.Height))
            {
                intHeight -= objCellBounds.Bottom - objCellClip.Bottom;
            }
            else
            {
                intHeight -= objRectangle.Height;
            }
            int intY = objCellBounds.Y - objCellClip.Y;
            int num8 = (objCellBounds.Height - objRectangle.Y) - objRectangle.Height;
            base.DataGridView.EditingPanel.Location = new Point(num, num5);
            base.DataGridView.EditingPanel.Size = new Size(intWidth, intHeight);
            return new Rectangle(intX, intY, num4, num8);
        }


        private static string TruncateToolTipText(string strToolTipText)
        {
            if (strToolTipText.Length > 0x120)
            {
                StringBuilder builder = new StringBuilder(strToolTipText.Substring(0, 0x100), 0x103);
                builder.Append("...");
                return builder.ToString();
            }
            return strToolTipText;
        }

        private void UpdateCurrentMouseLocation(DataGridViewCellMouseEventArgs e)
        {
            if (this.GetErrorIconBounds(e.RowIndex).Contains(e.X, e.Y))
            {
                this.CurrentMouseLocation = 2;
            }
            else
            {
                this.CurrentMouseLocation = 1;
            }
        }

        private string GetToolTipText(int intRowIndex)
        {
            string strToolTipTextInternal = this.ToolTipTextInternal;
            if ((base.DataGridView == null) || (!base.DataGridView.VirtualMode && (base.DataGridView.DataSource == null)))
            {
                return strToolTipTextInternal;
            }
            return base.DataGridView.OnCellToolTipTextNeeded(this.ColumnIndex, intRowIndex, strToolTipTextInternal);
        }

        /// <summary>
        /// Gets the context menu.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        internal ContextMenu GetContextMenu(int intRowIndex)
        {
            ContextMenu objContextMenuInternal = this.ContextMenuInternal;
            if ((base.DataGridView == null) || (!base.DataGridView.VirtualMode && (base.DataGridView.DataSource == null)))
            {
                return objContextMenuInternal;
            }
            return base.DataGridView.OnCellContextMenuNeeded(this.ColumnIndex, intRowIndex, objContextMenuInternal);
        }

        /// <summary>
        /// Gets the context menu strip.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <returns></returns>
        public ContextMenuStrip GetContextMenuStrip(int rowIndex)
        {
            ContextMenuStrip contextMenuStripInternal = this.ContextMenuStripInternal;
            if ((base.DataGridView == null) || (!base.DataGridView.VirtualMode && (base.DataGridView.DataSource == null)))
            {
                return contextMenuStripInternal;
            }
            return base.DataGridView.OnCellContextMenuStripNeeded(this.ColumnIndex, rowIndex, contextMenuStripInternal);
        }

        /// <summary>
        /// Detaches the context menu.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DetachContextMenu(object sender, EventArgs e)
        {
            this.ContextMenuInternal = null;
        }

        /// <summary>
        /// Detaches the context menu strip.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DetachContextMenuStrip(object sender, EventArgs e)
        {
            this.ContextMenuStripInternal = null;
        }

        /// <summary>
        /// Gets the inherited context menu strip.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <returns></returns>
        public virtual ContextMenuStrip GetInheritedContextMenuStrip(int rowIndex)
        {
            if (base.DataGridView != null)
            {
                if ((rowIndex < 0) || (rowIndex >= base.DataGridView.Rows.Count))
                {
                    throw new ArgumentOutOfRangeException("rowIndex");
                }
                if (this.ColumnIndex < 0)
                {
                    throw new InvalidOperationException();
                }
            }
            ContextMenuStrip contextMenuStrip = this.GetContextMenuStrip(rowIndex);
            if (contextMenuStrip != null)
            {
                return contextMenuStrip;
            }
            if (this.OwningRow != null)
            {
                contextMenuStrip = this.OwningRow.GetContextMenuStrip(rowIndex);
                if (contextMenuStrip != null)
                {
                    return contextMenuStrip;
                }
            }
            if (this.OwningColumn != null)
            {
                contextMenuStrip = this.OwningColumn.ContextMenuStrip;
                if (contextMenuStrip != null)
                {
                    return contextMenuStrip;
                }
            }
            if (base.DataGridView != null)
            {
                return base.DataGridView.ContextMenuStrip;
            }
            return null;
        }

        /// <summary>Gets the inherited shortcut menu for the current cell.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.ContextMenuStrip"></see> if the parent <see cref="T:System.Windows.Forms.DataGridView"></see>, <see cref="T:System.Windows.Forms.DataGridViewRow"></see>, or <see cref="T:System.Windows.Forms.DataGridViewColumn"></see> has a <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> assigned; otherwise, null.</returns>
        /// <param name="intRowIndex">The row index of the current cell.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:System.Windows.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and the specified rowIndex is less than 0 or greater than the number of rows in the control minus 1. </exception>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:System.Windows.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
        public virtual ContextMenu GetInheritedContextMenu(int intRowIndex)
        {
            if (base.DataGridView != null)
            {
                if ((intRowIndex < 0) || (intRowIndex >= base.DataGridView.Rows.Count))
                {
                    throw new ArgumentOutOfRangeException("rowIndex");
                }
                if (this.ColumnIndex < 0)
                {
                    throw new InvalidOperationException();
                }
            }
            ContextMenu objContextMenu = this.GetContextMenu(intRowIndex);
            if (objContextMenu != null)
            {
                return objContextMenu;
            }
            if (this.OwningRow != null)
            {
                objContextMenu = this.OwningRow.GetContextMenu(intRowIndex);
                if (objContextMenu != null)
                {
                    return objContextMenu;
                }
            }
            if (this.OwningColumn != null)
            {
                objContextMenu = this.OwningColumn.ContextMenu;
                if (objContextMenu != null)
                {
                    return objContextMenu;
                }
            }
            if (base.DataGridView != null)
            {
                return base.DataGridView.ContextMenu;
            }
            return null;
        }

        /// <summary>Modifies the input cell border style according to the specified criteria. </summary>
        /// <returns>The modified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see>.</returns>
        /// <param name="objDataGridViewAdvancedBorderStylePlaceholder">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that is used to store intermediate changes to the cell border style. </param>
        /// <param name="blnIsFirstDisplayedColumn">true if the hosting cell is in the first visible column; otherwise, false. </param>
        /// <param name="objDataGridViewAdvancedBorderStyleInput">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the cell border style to modify.</param>
        /// <param name="blnSingleVerticalBorderAdded">true to add a vertical border to the cell; otherwise, false. </param>
        /// <param name="blnSingleHorizontalBorderAdded">true to add a horizontal border to the cell; otherwise, false. </param>
        /// <param name="blnIsFirstDisplayedRow">true if the hosting cell is in the first visible row; otherwise, false. </param>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual DataGridViewAdvancedBorderStyle AdjustCellBorderStyle(DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStyleInput, DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStylePlaceholder, bool blnSingleVerticalBorderAdded, bool blnSingleHorizontalBorderAdded, bool blnIsFirstDisplayedColumn, bool blnIsFirstDisplayedRow)
        {
            return null;
        }

        /// <summary>Indicates whether the cell's row will be unshared when the cell is clicked.</summary>
        /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> containing the data passed to the <see cref="M:Gizmox.WebGUI.Forms.DataGridViewCell.OnClick(Gizmox.WebGUI.Forms.DataGridViewCellEventArgs)"></see> method.</param>
        protected virtual bool ClickUnsharesRow(DataGridViewCellEventArgs e)
        {
            return false;
        }

        /// <summary>Creates an exact copy of this cell.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public virtual object Clone()
        {
            DataGridViewCell objCell1 = (DataGridViewCell)Activator.CreateInstance(base.GetType());
            this.CloneInternal(objCell1);
            return objCell1;

        }

        /// <summary>Indicates whether the cell's row will be unshared when the cell's content is clicked.</summary>
        /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> containing the data passed to the <see cref="M:Gizmox.WebGUI.Forms.DataGridViewCell.OnContentClick(Gizmox.WebGUI.Forms.DataGridViewCellEventArgs)"></see> method.</param>
        protected virtual bool ContentClickUnsharesRow(DataGridViewCellEventArgs e)
        {
            return false;
        }

        /// <summary>Indicates whether the cell's row will be unshared when the cell's content is double-clicked.</summary>
        /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> containing the data passed to the <see cref="M:Gizmox.WebGUI.Forms.DataGridViewCell.OnContentDoubleClick(Gizmox.WebGUI.Forms.DataGridViewCellEventArgs)"></see> method.</param>
        protected virtual bool ContentDoubleClickUnsharesRow(DataGridViewCellEventArgs e)
        {
            return false;
        }

        /// <summary>Removes the cell's editing control from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
        /// <exception cref="T:System.InvalidOperationException">This cell is not associated with a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditingControl"></see> property of the associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has a value of null. This is the case, for example, when the control is not in edit mode.</exception>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual void DetachEditingControl()
        {
        }

        /// <summary>Releases all resources used by the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>. </summary>
        /// <filterpriority>1</filterpriority>
        public void Dispose()
        {
        }

        /// <summary>Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> and optionally releases the managed resources. </summary>
        /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool blnDisposing)
        {
        }

        /// <summary>Indicates whether the cell's row will be unshared when the cell is double-clicked.</summary>
        /// <returns>true if the row will be unshared, otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="e">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> containing the data passed to the <see cref="M:Gizmox.WebGUI.Forms.DataGridViewCell.OnDoubleClick(Gizmox.WebGUI.Forms.DataGridViewCellEventArgs)"></see> method.</param>
        protected virtual bool DoubleClickUnsharesRow(DataGridViewCellEventArgs e)
        {
            return false;
        }

        /// <summary>Indicates whether the parent row will be unshared when the focus moves to the cell.</summary>
        /// <returns>true if the row will be unshared; otherwise, false. The base <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> class always returns false.</returns>
        /// <param name="blnThroughMouseClick">true if a user action moved focus to the cell; false if a programmatic operation moved focus to the cell.</param>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        protected virtual bool EnterUnsharesRow(int intRowIndex, bool blnThroughMouseClick)
        {
            return false;
        }

        /// <summary>Retrieves the formatted value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</returns>
        /// <param name="blnInLastRow">true to indicate that the cell is in the last row of the region defined by the selected cells; otherwise, false.</param>
        /// <param name="blnInFirstRow">true to indicate that the cell is in the first row of the region defined by the selected cells; otherwise, false.</param>
        /// <param name="blnLastCell">true to indicate that the cell is the last column of the region defined by the selected cells; otherwise, false.</param>
        /// <param name="strFormat">The current format string of the cell.</param>
        /// <param name="blnFirstCell">true to indicate that the cell is in the first column of the region defined by the selected cells; otherwise, false.</param>
        /// <param name="intRowIndex">The zero-based index of the row containing the cell.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 or greater than or equal to the number of rows in the control.</exception>
        /// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
        /// <exception cref="T:System.InvalidOperationException">The value of the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property is null.-or-<see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
        protected virtual object GetClipboardContent(int intRowIndex, bool blnFirstCell, bool blnLastCell, bool blnInFirstRow, bool blnInLastRow, string strFormat)
        {
            if (base.DataGridView == null)
            {
                return null;
            }
            if ((intRowIndex < 0) || (intRowIndex >= base.DataGridView.Rows.Count))
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            DataGridViewCellStyle objDataGridViewCellStyle = this.GetInheritedStyle(null, intRowIndex, false);
            object obj2 = null;
            if (base.DataGridView.IsSharedCellSelected(this, intRowIndex))
            {
                obj2 = this.GetEditedFormattedValue(this.GetValue(intRowIndex), intRowIndex, ref objDataGridViewCellStyle, DataGridViewDataErrorContexts.ClipboardContent | DataGridViewDataErrorContexts.Formatting);
            }
            StringBuilder sb = new StringBuilder(0x40);
            if (strFormat == DataFormats.Html)
            {
                if (blnFirstCell)
                {
                    if (blnInFirstRow)
                    {
                        sb.Append("<TABLE>");
                    }
                    sb.Append("<TR>");
                }
                sb.Append("<TD>");
                if (obj2 != null)
                {
                    FormatPlainTextAsHtml(obj2.ToString(), new StringWriter(sb, CultureInfo.CurrentCulture));
                }
                else
                {
                    sb.Append("&nbsp;");
                }
                sb.Append("</TD>");
                if (blnLastCell)
                {
                    sb.Append("</TR>");
                    if (blnInLastRow)
                    {
                        sb.Append("</TABLE>");
                    }
                }
                return sb.ToString();
            }
            bool blnCsv = strFormat == "CommaSeparatedValue";
            if ((!blnCsv && !(strFormat == DataFormats.Text)) && !(strFormat == DataFormats.UnicodeText))
            {
                return null;
            }
            if (obj2 != null)
            {
                if ((blnFirstCell && blnLastCell) && (blnInFirstRow && blnInLastRow))
                {
                    sb.Append(obj2.ToString());
                }
                else
                {
                    bool blnEscapeApplied = false;
                    int index = sb.Length;
                    FormatPlainText(obj2.ToString(), blnCsv, new StringWriter(sb, CultureInfo.CurrentCulture), ref blnEscapeApplied);
                    if (blnEscapeApplied)
                    {
                        sb.Insert(index, '"');
                    }
                }
            }
            if (blnLastCell)
            {
                if (!blnInLastRow)
                {
                    sb.Append('\r');
                    sb.Append('\n');
                }
            }
            else
            {
                sb.Append(blnCsv ? ',' : '\t');
            }
            return sb.ToString();

        }

        /// <summary>
        /// Gets the clipboard content internal.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <param name="blnFirstCell">if set to <c>true</c> [first cell].</param>
        /// <param name="blnLastCell">if set to <c>true</c> [last cell].</param>
        /// <param name="blnInFirstRow">if set to <c>true</c> [in first row].</param>
        /// <param name="blnInLastRow">if set to <c>true</c> [in last row].</param>
        /// <param name="strFormat">The format.</param>
        /// <returns></returns>
        internal object GetClipboardContentInternal(int intRowIndex, bool blnFirstCell, bool blnLastCell, bool blnInFirstRow, bool blnInLastRow, string strFormat)
        {
            return this.GetClipboardContent(intRowIndex, blnFirstCell, blnLastCell, blnInFirstRow, blnInLastRow, strFormat);
        }

        /// <summary>Returns the current, formatted value of the cell, regardless of whether the cell is in edit mode and the value has not been committed.</summary>
        /// <returns>The current, formatted value of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
        /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values that specifies the data error context.</param>
        /// <param name="intRowIndex">The row index of the cell.</param>
        /// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The specified rowIndex is less than 0 or greater than the number of rows in the control minus 1. </exception>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
        public object GetEditedFormattedValue(int intRowIndex, DataGridViewDataErrorContexts enmContext)
        {
            if (base.DataGridView == null)
            {
                return null;
            }
            DataGridViewCellStyle objDataGridViewCellStyle = this.GetInheritedStyle(null, intRowIndex, false);
            return this.GetEditedFormattedValue(this.GetValue(intRowIndex), intRowIndex, ref objDataGridViewCellStyle, enmContext);


        }

        /// <summary>
        /// Gets the edited formatted value.
        /// </summary>
        /// <param name="objValue">The value.</param>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <param name="objDataGridViewCellStyle">The data grid view cell style.</param>
        /// <param name="enmContext">The context.</param>
        /// <returns></returns>
        internal object GetEditedFormattedValue(object objValue, int intRowIndex, ref DataGridViewCellStyle objDataGridViewCellStyle, DataGridViewDataErrorContexts enmContext)
        {
            return this.GetFormattedValue(objValue, intRowIndex, ref objDataGridViewCellStyle, null, null, enmContext);
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="objValue">The obj value.</param>
        /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
        protected void SetValue(object objValue, bool blnClientSource)
        {
            DataGridView objDataGridView = this.DataGridView;

            if (objDataGridView != null)
            {
                // Make sure that this cell is defined as current cell before setting value.
                if (objDataGridView.CurrentCell != this)
                {
                    // Sets the current cell.
                    objDataGridView.SetCurrentCell(this, blnClientSource);
                }

                // Preserve the new editing proposed value.
                this.EditingProposedValue = objValue;

                // Execute begin edit.
                objDataGridView.BeginEdit(false, blnClientSource);

                // Check if current cell contained in a new row.
                bool blnIsNewRow = (objDataGridView.NewRowIndex == objDataGridView.CurrentCellPoint.Y);

                // Notify current cell is dirty.
                objDataGridView.NotifyCurrentCellDirty(true, blnClientSource);

                // Execute commit edit for operation.
                if (!objDataGridView.CommitEditForOperation(this.ColumnIndex, this.RowIndex, true, blnClientSource))
                {
                    // If edit is not validated - update current cell so it will draw its previous value.
                    this.Update();
                }

                // Notify current cell is not dirty.
                objDataGridView.NotifyCurrentCellDirty(false);

                // Check if paging is enabled and if the new row index currently handled.
                if (objDataGridView.UseInternalPaging && blnIsNewRow)
                {
                    // Check if the current page is deifferent from the last page.
                    if (objDataGridView.CurrentPage != objDataGridView.TotalPages)
                    {
                        // Update current page.
                        objDataGridView.CurrentPage = objDataGridView.TotalPages;

                        // Scrolls into view and hide owned popup windows that might exist from previous page.
                        objDataGridView.PerformScrollIntoView(this, true);
                    }
                }
            }
        }

        /// <summary>
        /// Pres the render component.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="lngRequestID">The request ID.</param>
        /// <param name="blnForcePreRender">if set to <c>true</c> [BLN force pre render].</param>
        internal override void PreRenderComponent(IContext objContext, long lngRequestID, bool blnForcePreRender)
        {
            base.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);

            if (mobjPanel != null)
            {
                mobjPanel.PreRenderComponent(objContext, lngRequestID);
            }

            if (this.IsDirty(lngRequestID) || blnForcePreRender)
            {
                //// Get cell's row index.
                int intRowIndex = this.RowIndex;

                if (ShouldPreRender(this.PreRenderMask, PreRenderable.CellStyle))
                {
                    // Get inherited cell style.
                    DataGridViewCellStyle objDataGridViewCellStyle = this.GetInheritedStyle(null, intRowIndex, true);
                    if (objDataGridViewCellStyle != null)
                    {
                        // Clone inhrited style to a local member.
                        mobjFormattedCellStyle = objDataGridViewCellStyle.Clone();

                        if (this.OwningRow == null || !this.OwningRow.IsFilterRow)
                        {
                            // Execute value and style formating (this proccess will presereve value and style on local members).
                            mobjFormattedValue = GetEditedFormattedValue(this.GetValue(intRowIndex), intRowIndex, ref mobjFormattedCellStyle, DataGridViewDataErrorContexts.Formatting | DataGridViewDataErrorContexts.Display);
                        }
                    }
                }
            }
        }

        /// <summary>Gets the value of the cell as formatted for display. </summary>
        /// <returns>The formatted value of the cell or null if the cell does not belong to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</returns>
        /// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell.</param>
        /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values describing the context in which the formatted value is needed.</param>
        /// <param name="objValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the value type that provides custom conversion to the formatted value type, or null if no such custom conversion is needed.</param>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        /// <param name="objValue">The value to be formatted. </param>
        /// <param name="objFormattedValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the formatted value type that provides custom conversion from the value type, or null if no such custom conversion is needed.</param>
        /// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
        protected virtual object GetFormattedValue(object objValue, int intRowIndex, ref DataGridViewCellStyle objCellStyle, TypeConverter objValueTypeConverter, TypeConverter objFormattedValueTypeConverter, DataGridViewDataErrorContexts enmContext)
        {
            // Filter Cell has no value.
            if (base.DataGridView == null || this is DataGridViewFilterCell)
            {
                return null;
            }

            DataGridViewCellFormattingEventArgs args1 = base.DataGridView.OnCellFormatting(this.ColumnIndex, intRowIndex, objValue, this.FormattedValueType, objCellStyle);
            objCellStyle = args1.CellStyle;
            bool blnFlag1 = args1.FormattingApplied;
            object obj1 = args1.Value;
            bool blnFlag2 = true;
            if ((!blnFlag1 && (this.FormattedValueType != null)) && ((obj1 == null) || !this.FormattedValueType.IsAssignableFrom(obj1.GetType())))
            {
                try
                {
                    obj1 = ClientUtils.FormatObject(obj1, this.FormattedValueType, (objValueTypeConverter == null) ? this.ValueTypeConverter : objValueTypeConverter, (objFormattedValueTypeConverter == null) ? this.FormattedValueTypeConverter : objFormattedValueTypeConverter, objCellStyle.Format, objCellStyle.FormatProvider, objCellStyle.NullValue, objCellStyle.DataSourceNullValue);
                }
                catch (Exception objException1)
                {
                    if (ClientUtils.IsCriticalException(objException1))
                    {
                        throw;
                    }
                    DataGridViewDataErrorEventArgs args2 = new DataGridViewDataErrorEventArgs(objException1, this.ColumnIndex, intRowIndex, enmContext);
                    base.RaiseDataError(args2);
                    if (args2.ThrowException)
                    {
                        throw args2.Exception;
                    }
                    blnFlag2 = false;
                }
            }
            if (blnFlag2 && (((obj1 == null) || (this.FormattedValueType == null)) || !this.FormattedValueType.IsAssignableFrom(obj1.GetType())))
            {
                if (((obj1 == null) && (objCellStyle.NullValue == null)) && ((this.FormattedValueType != null) && !typeof(ValueType).IsAssignableFrom(this.FormattedValueType)))
                {
                    return null;
                }
                Exception objException2 = null;
                if (this.FormattedValueType == null)
                {
                    objException2 = new FormatException(SR.GetString("DataGridViewCell_FormattedValueTypeNull"));
                }
                else
                {
                    objException2 = new FormatException(SR.GetString("DataGridViewCell_FormattedValueHasWrongType"));
                }
                DataGridViewDataErrorEventArgs args3 = new DataGridViewDataErrorEventArgs(objException2, this.ColumnIndex, intRowIndex, enmContext);
                base.RaiseDataError(args3);
                if (args3.ThrowException)
                {
                    throw args3.Exception;
                }
            }
            return obj1;

        }

        internal object GetFormattedValue(int intRowIndex, ref DataGridViewCellStyle objCellStyle, DataGridViewDataErrorContexts enmContext)
        {
            if (base.DataGridView == null)
            {
                return null;
            }
            return this.GetFormattedValue(this.GetValue(intRowIndex), intRowIndex, ref objCellStyle, null, null, enmContext);
        }

        /// <summary>Returns a value indicating the current state of the cell as inherited from the state of its row and column.</summary>
        /// <returns>A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values representing the current state of the cell.</returns>
        /// <param name="intRowIndex">The index of the row containing the cell.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The cell is contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and rowIndex is outside the valid range of 0 to the number of rows in the control minus 1.</exception>
        /// <exception cref="T:System.ArgumentException">The cell is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and rowIndex is not -1.-or-rowIndex is not the index of the row containing this cell.</exception>
        public virtual DataGridViewElementStates GetInheritedState(int intRowIndex)
        {
            DataGridViewElementStates enmElementState = this.State | DataGridViewElementStates.ResizableSet;
            DataGridViewRow objOwningRow = this.OwningRow;

            if (base.DataGridView == null)
            {
                if (intRowIndex != -1)
                {
                    throw new ArgumentException(SR.GetString("InvalidArgument", new object[] { "rowIndex", intRowIndex.ToString(CultureInfo.CurrentCulture) }));
                }
                if (objOwningRow != null)
                {
                    enmElementState |= objOwningRow.GetState(-1) & (DataGridViewElementStates.Visible | DataGridViewElementStates.Selected | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen);
                    if (objOwningRow.GetResizable(intRowIndex) == DataGridViewTriState.True)
                    {
                        enmElementState |= DataGridViewElementStates.Resizable;
                    }
                }
                return enmElementState;
            }
            if ((intRowIndex < 0) || (intRowIndex >= base.DataGridView.Rows.Count))
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            if (base.DataGridView.Rows.SharedRow(intRowIndex) != objOwningRow)
            {
                throw new ArgumentException(SR.GetString("InvalidArgument", new object[] { "rowIndex", intRowIndex.ToString(CultureInfo.CurrentCulture) }));
            }
            DataGridViewElementStates enmRowState = base.DataGridView.Rows.GetRowState(intRowIndex);
            DataGridViewColumn objOwningColumn = this.OwningColumn;
            enmElementState |= enmRowState & (DataGridViewElementStates.Selected | DataGridViewElementStates.ReadOnly);
            enmElementState |= objOwningColumn.State & (DataGridViewElementStates.Selected | DataGridViewElementStates.ReadOnly);
            if ((objOwningRow.GetResizable(intRowIndex) == DataGridViewTriState.True) || (objOwningColumn.Resizable == DataGridViewTriState.True))
            {
                enmElementState |= DataGridViewElementStates.Resizable;
            }
            if (objOwningColumn.Visible && objOwningRow.GetVisible(intRowIndex))
            {
                enmElementState |= DataGridViewElementStates.Visible;
                if (objOwningColumn.Displayed && objOwningRow.GetDisplayed(intRowIndex))
                {
                    enmElementState |= DataGridViewElementStates.Displayed;
                }
            }
            if (objOwningColumn.Frozen && objOwningRow.GetFrozen(intRowIndex))
            {
                enmElementState |= DataGridViewElementStates.Frozen;
            }
            return enmElementState;
        }

        /// <summary>Gets the style applied to the cell. </summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that includes the style settings of the cell inherited from the cell's parent row, column, and <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
        /// <param name="objInheritedCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be populated with the inherited cell style. </param>
        /// <param name="blnIncludeColors">true to include inherited colors in the returned cell style; otherwise, false. </param>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0, or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
        /// <exception cref="T:System.InvalidOperationException">The cell has no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-<see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
        public virtual DataGridViewCellStyle GetInheritedStyle(DataGridViewCellStyle objInheritedCellStyle, int intRowIndex, bool blnIncludeColors)
        {
            DataGridViewCellStyle objDataGridViewCellStyle1;
            DataGridView objDataGridView = base.DataGridView;

            if (objDataGridView == null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_CellNeedsDataGridViewForInheritedStyle"));
            }
            if (((intRowIndex < 0) || (intRowIndex >= objDataGridView.Rows.Count)) && !this.OwningRow.IsFilterRow)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            if (this.ColumnIndex < 0)
            {
                throw new InvalidOperationException();
            }
            if (objInheritedCellStyle == null)
            {
                objDataGridViewCellStyle1 = objDataGridView.PlaceholderCellStyle;
                if (!blnIncludeColors)
                {
                    objDataGridViewCellStyle1.BackColor = Color.Empty;
                    objDataGridViewCellStyle1.ForeColor = Color.Empty;
                    objDataGridViewCellStyle1.SelectionBackColor = Color.Empty;
                    objDataGridViewCellStyle1.SelectionForeColor = Color.Empty;
                }
            }
            else
            {
                objDataGridViewCellStyle1 = objInheritedCellStyle;
            }
            DataGridViewCellStyle objDataGridViewCellStyle2 = null;
            if (this.HasStyle)
            {
                objDataGridViewCellStyle2 = this.Style;
            }
            DataGridViewCellStyle objDataGridViewCellStyle3 = null;
            if (objDataGridView.Rows.SharedRow(intRowIndex).HasDefaultCellStyle)
            {
                objDataGridViewCellStyle3 = objDataGridView.Rows.SharedRow(intRowIndex).DefaultCellStyle;
            }
            DataGridViewCellStyle objDataGridViewCellStyle4 = null;
            DataGridViewColumn objOwningColumn = this.OwningColumn;
            if (objOwningColumn.HasDefaultCellStyle)
            {
                objDataGridViewCellStyle4 = objOwningColumn.DefaultCellStyle;
            }
            DataGridViewCellStyle objRowsDefaultCellStyle = objDataGridView.RowsDefaultCellStyle;
            DataGridViewCellStyle objAlternatingRowsDefaultCellStyle = objDataGridView.AlternatingRowsDefaultCellStyle;
            DataGridViewCellStyle objDataGridViewCellStyle5 = objDataGridView.DefaultCellStyle;
            if (blnIncludeColors)
            {
                if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.BackColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.BackColor = objDataGridViewCellStyle2.BackColor;
                }
                else if ((objDataGridViewCellStyle3 != null) && !objDataGridViewCellStyle3.BackColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.BackColor = objDataGridViewCellStyle3.BackColor;
                }
                else if (!objRowsDefaultCellStyle.BackColor.IsEmpty && (((intRowIndex % 2) == 0) || objAlternatingRowsDefaultCellStyle.BackColor.IsEmpty))
                {
                    objDataGridViewCellStyle1.BackColor = objRowsDefaultCellStyle.BackColor;
                }
                else if (((intRowIndex % 2) == 1) && !objAlternatingRowsDefaultCellStyle.BackColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.BackColor = objAlternatingRowsDefaultCellStyle.BackColor;
                }
                else if ((objDataGridViewCellStyle4 != null) && !objDataGridViewCellStyle4.BackColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.BackColor = objDataGridViewCellStyle4.BackColor;
                }
                else
                {
                    objDataGridViewCellStyle1.BackColor = objDataGridViewCellStyle5.BackColor;
                }
                if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.ForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.ForeColor = objDataGridViewCellStyle2.ForeColor;
                }
                else if ((objDataGridViewCellStyle3 != null) && !objDataGridViewCellStyle3.ForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.ForeColor = objDataGridViewCellStyle3.ForeColor;
                }
                else if (!objRowsDefaultCellStyle.ForeColor.IsEmpty && (((intRowIndex % 2) == 0) || objAlternatingRowsDefaultCellStyle.ForeColor.IsEmpty))
                {
                    objDataGridViewCellStyle1.ForeColor = objRowsDefaultCellStyle.ForeColor;
                }
                else if (((intRowIndex % 2) == 1) && !objAlternatingRowsDefaultCellStyle.ForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.ForeColor = objAlternatingRowsDefaultCellStyle.ForeColor;
                }
                else if ((objDataGridViewCellStyle4 != null) && !objDataGridViewCellStyle4.ForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.ForeColor = objDataGridViewCellStyle4.ForeColor;
                }
                else
                {
                    objDataGridViewCellStyle1.ForeColor = objDataGridViewCellStyle5.ForeColor;
                }
                if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.SelectionBackColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.SelectionBackColor = objDataGridViewCellStyle2.SelectionBackColor;
                }
                else if ((objDataGridViewCellStyle3 != null) && !objDataGridViewCellStyle3.SelectionBackColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.SelectionBackColor = objDataGridViewCellStyle3.SelectionBackColor;
                }
                else if (!objRowsDefaultCellStyle.SelectionBackColor.IsEmpty && (((intRowIndex % 2) == 0) || objAlternatingRowsDefaultCellStyle.SelectionBackColor.IsEmpty))
                {
                    objDataGridViewCellStyle1.SelectionBackColor = objRowsDefaultCellStyle.SelectionBackColor;
                }
                else if (((intRowIndex % 2) == 1) && !objAlternatingRowsDefaultCellStyle.SelectionBackColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.SelectionBackColor = objAlternatingRowsDefaultCellStyle.SelectionBackColor;
                }
                else if ((objDataGridViewCellStyle4 != null) && !objDataGridViewCellStyle4.SelectionBackColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.SelectionBackColor = objDataGridViewCellStyle4.SelectionBackColor;
                }
                else
                {
                    objDataGridViewCellStyle1.SelectionBackColor = objDataGridViewCellStyle5.SelectionBackColor;
                }
                if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.SelectionForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.SelectionForeColor = objDataGridViewCellStyle2.SelectionForeColor;
                }
                else if ((objDataGridViewCellStyle3 != null) && !objDataGridViewCellStyle3.SelectionForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.SelectionForeColor = objDataGridViewCellStyle3.SelectionForeColor;
                }
                else if (!objRowsDefaultCellStyle.SelectionForeColor.IsEmpty && (((intRowIndex % 2) == 0) || objAlternatingRowsDefaultCellStyle.SelectionForeColor.IsEmpty))
                {
                    objDataGridViewCellStyle1.SelectionForeColor = objRowsDefaultCellStyle.SelectionForeColor;
                }
                else if (((intRowIndex % 2) == 1) && !objAlternatingRowsDefaultCellStyle.SelectionForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.SelectionForeColor = objAlternatingRowsDefaultCellStyle.SelectionForeColor;
                }
                else if ((objDataGridViewCellStyle4 != null) && !objDataGridViewCellStyle4.SelectionForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.SelectionForeColor = objDataGridViewCellStyle4.SelectionForeColor;
                }
                else
                {
                    objDataGridViewCellStyle1.SelectionForeColor = objDataGridViewCellStyle5.SelectionForeColor;
                }
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.Font != null))
            {
                objDataGridViewCellStyle1.Font = objDataGridViewCellStyle2.Font;
            }
            else if ((objDataGridViewCellStyle3 != null) && (objDataGridViewCellStyle3.Font != null))
            {
                objDataGridViewCellStyle1.Font = objDataGridViewCellStyle3.Font;
            }
            else if ((objRowsDefaultCellStyle.Font != null) && (((intRowIndex % 2) == 0) || (objAlternatingRowsDefaultCellStyle.Font == null)))
            {
                objDataGridViewCellStyle1.Font = objRowsDefaultCellStyle.Font;
            }
            else if (((intRowIndex % 2) == 1) && (objAlternatingRowsDefaultCellStyle.Font != null))
            {
                objDataGridViewCellStyle1.Font = objAlternatingRowsDefaultCellStyle.Font;
            }
            else if ((objDataGridViewCellStyle4 != null) && (objDataGridViewCellStyle4.Font != null))
            {
                objDataGridViewCellStyle1.Font = objDataGridViewCellStyle4.Font;
            }
            else
            {
                objDataGridViewCellStyle1.Font = objDataGridViewCellStyle5.Font;
            }

            bool blnIsNullValueDefault = objAlternatingRowsDefaultCellStyle.IsNullValueDefault;

            if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.IsNullValueDefault)
            {
                objDataGridViewCellStyle1.NullValue = objDataGridViewCellStyle2.NullValue;
            }
            else if ((objDataGridViewCellStyle3 != null) && !objDataGridViewCellStyle3.IsNullValueDefault)
            {
                objDataGridViewCellStyle1.NullValue = objDataGridViewCellStyle3.NullValue;
            }
            else if (!objRowsDefaultCellStyle.IsNullValueDefault && (((intRowIndex % 2) == 0) || blnIsNullValueDefault))
            {
                objDataGridViewCellStyle1.NullValue = objRowsDefaultCellStyle.NullValue;
            }
            else if (((intRowIndex % 2) == 1) && !blnIsNullValueDefault)
            {
                objDataGridViewCellStyle1.NullValue = objAlternatingRowsDefaultCellStyle.NullValue;
            }
            else if ((objDataGridViewCellStyle4 != null) && !objDataGridViewCellStyle4.IsNullValueDefault)
            {
                objDataGridViewCellStyle1.NullValue = objDataGridViewCellStyle4.NullValue;
            }
            else
            {
                objDataGridViewCellStyle1.NullValue = objDataGridViewCellStyle5.NullValue;
            }
            if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.IsDataSourceNullValueDefault)
            {
                objDataGridViewCellStyle1.DataSourceNullValue = objDataGridViewCellStyle2.DataSourceNullValue;
            }
            else if ((objDataGridViewCellStyle3 != null) && !objDataGridViewCellStyle3.IsDataSourceNullValueDefault)
            {
                objDataGridViewCellStyle1.DataSourceNullValue = objDataGridViewCellStyle3.DataSourceNullValue;
            }
            else if (!objRowsDefaultCellStyle.IsDataSourceNullValueDefault && (((intRowIndex % 2) == 0) || objAlternatingRowsDefaultCellStyle.IsDataSourceNullValueDefault))
            {
                objDataGridViewCellStyle1.DataSourceNullValue = objRowsDefaultCellStyle.DataSourceNullValue;
            }
            else if (((intRowIndex % 2) == 1) && !objAlternatingRowsDefaultCellStyle.IsDataSourceNullValueDefault)
            {
                objDataGridViewCellStyle1.DataSourceNullValue = objAlternatingRowsDefaultCellStyle.DataSourceNullValue;
            }
            else if ((objDataGridViewCellStyle4 != null) && !objDataGridViewCellStyle4.IsDataSourceNullValueDefault)
            {
                objDataGridViewCellStyle1.DataSourceNullValue = objDataGridViewCellStyle4.DataSourceNullValue;
            }
            else
            {
                objDataGridViewCellStyle1.DataSourceNullValue = objDataGridViewCellStyle5.DataSourceNullValue;
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.Format.Length != 0))
            {
                objDataGridViewCellStyle1.Format = objDataGridViewCellStyle2.Format;
            }
            else if ((objDataGridViewCellStyle3 != null) && (objDataGridViewCellStyle3.Format.Length != 0))
            {
                objDataGridViewCellStyle1.Format = objDataGridViewCellStyle3.Format;
            }
            else if ((objRowsDefaultCellStyle.Format.Length != 0) && (((intRowIndex % 2) == 0) || (objAlternatingRowsDefaultCellStyle.Format.Length == 0)))
            {
                objDataGridViewCellStyle1.Format = objRowsDefaultCellStyle.Format;
            }
            else if (((intRowIndex % 2) == 1) && (objAlternatingRowsDefaultCellStyle.Format.Length != 0))
            {
                objDataGridViewCellStyle1.Format = objAlternatingRowsDefaultCellStyle.Format;
            }
            else if ((objDataGridViewCellStyle4 != null) && (objDataGridViewCellStyle4.Format.Length != 0))
            {
                objDataGridViewCellStyle1.Format = objDataGridViewCellStyle4.Format;
            }
            else
            {
                objDataGridViewCellStyle1.Format = objDataGridViewCellStyle5.Format;
            }
            if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.IsFormatProviderDefault)
            {
                objDataGridViewCellStyle1.FormatProvider = objDataGridViewCellStyle2.FormatProvider;
            }
            else if ((objDataGridViewCellStyle3 != null) && !objDataGridViewCellStyle3.IsFormatProviderDefault)
            {
                objDataGridViewCellStyle1.FormatProvider = objDataGridViewCellStyle3.FormatProvider;
            }
            else if (!objRowsDefaultCellStyle.IsFormatProviderDefault && (((intRowIndex % 2) == 0) || objAlternatingRowsDefaultCellStyle.IsFormatProviderDefault))
            {
                objDataGridViewCellStyle1.FormatProvider = objRowsDefaultCellStyle.FormatProvider;
            }
            else if (((intRowIndex % 2) == 1) && !objAlternatingRowsDefaultCellStyle.IsFormatProviderDefault)
            {
                objDataGridViewCellStyle1.FormatProvider = objAlternatingRowsDefaultCellStyle.FormatProvider;
            }
            else if ((objDataGridViewCellStyle4 != null) && !objDataGridViewCellStyle4.IsFormatProviderDefault)
            {
                objDataGridViewCellStyle1.FormatProvider = objDataGridViewCellStyle4.FormatProvider;
            }
            else
            {
                objDataGridViewCellStyle1.FormatProvider = objDataGridViewCellStyle5.FormatProvider;
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.Alignment != DataGridViewContentAlignment.NotSet))
            {
                objDataGridViewCellStyle1.AlignmentInternal = objDataGridViewCellStyle2.Alignment;
            }
            else if ((objDataGridViewCellStyle3 != null) && (objDataGridViewCellStyle3.Alignment != DataGridViewContentAlignment.NotSet))
            {
                objDataGridViewCellStyle1.AlignmentInternal = objDataGridViewCellStyle3.Alignment;
            }
            else if ((objRowsDefaultCellStyle.Alignment != DataGridViewContentAlignment.NotSet) && (((intRowIndex % 2) == 0) || (objAlternatingRowsDefaultCellStyle.Alignment == DataGridViewContentAlignment.NotSet)))
            {
                objDataGridViewCellStyle1.AlignmentInternal = objRowsDefaultCellStyle.Alignment;
            }
            else if (((intRowIndex % 2) == 1) && (objAlternatingRowsDefaultCellStyle.Alignment != DataGridViewContentAlignment.NotSet))
            {
                objDataGridViewCellStyle1.AlignmentInternal = objAlternatingRowsDefaultCellStyle.Alignment;
            }
            else if ((objDataGridViewCellStyle4 != null) && (objDataGridViewCellStyle4.Alignment != DataGridViewContentAlignment.NotSet))
            {
                objDataGridViewCellStyle1.AlignmentInternal = objDataGridViewCellStyle4.Alignment;
            }
            else
            {
                objDataGridViewCellStyle1.AlignmentInternal = objDataGridViewCellStyle5.Alignment;
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.WrapMode != DataGridViewTriState.NotSet))
            {
                objDataGridViewCellStyle1.WrapModeInternal = objDataGridViewCellStyle2.WrapMode;
            }
            else if ((objDataGridViewCellStyle3 != null) && (objDataGridViewCellStyle3.WrapMode != DataGridViewTriState.NotSet))
            {
                objDataGridViewCellStyle1.WrapModeInternal = objDataGridViewCellStyle3.WrapMode;
            }
            else if ((objRowsDefaultCellStyle.WrapMode != DataGridViewTriState.NotSet) && (((intRowIndex % 2) == 0) || (objAlternatingRowsDefaultCellStyle.WrapMode == DataGridViewTriState.NotSet)))
            {
                objDataGridViewCellStyle1.WrapModeInternal = objRowsDefaultCellStyle.WrapMode;
            }
            else if (((intRowIndex % 2) == 1) && (objAlternatingRowsDefaultCellStyle.WrapMode != DataGridViewTriState.NotSet))
            {
                objDataGridViewCellStyle1.WrapModeInternal = objAlternatingRowsDefaultCellStyle.WrapMode;
            }
            else if ((objDataGridViewCellStyle4 != null) && (objDataGridViewCellStyle4.WrapMode != DataGridViewTriState.NotSet))
            {
                objDataGridViewCellStyle1.WrapModeInternal = objDataGridViewCellStyle4.WrapMode;
            }
            else
            {
                objDataGridViewCellStyle1.WrapModeInternal = objDataGridViewCellStyle5.WrapMode;
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.Tag != null))
            {
                objDataGridViewCellStyle1.Tag = objDataGridViewCellStyle2.Tag;
            }
            else if ((objDataGridViewCellStyle3 != null) && (objDataGridViewCellStyle3.Tag != null))
            {
                objDataGridViewCellStyle1.Tag = objDataGridViewCellStyle3.Tag;
            }
            else if ((objRowsDefaultCellStyle.Tag != null) && (((intRowIndex % 2) == 0) || (objAlternatingRowsDefaultCellStyle.Tag == null)))
            {
                objDataGridViewCellStyle1.Tag = objRowsDefaultCellStyle.Tag;
            }
            else if (((intRowIndex % 2) == 1) && (objAlternatingRowsDefaultCellStyle.Tag != null))
            {
                objDataGridViewCellStyle1.Tag = objAlternatingRowsDefaultCellStyle.Tag;
            }
            else if ((objDataGridViewCellStyle4 != null) && (objDataGridViewCellStyle4.Tag != null))
            {
                objDataGridViewCellStyle1.Tag = objDataGridViewCellStyle4.Tag;
            }
            else
            {
                objDataGridViewCellStyle1.Tag = objDataGridViewCellStyle5.Tag;
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.Padding != Padding.Empty))
            {
                objDataGridViewCellStyle1.PaddingInternal = objDataGridViewCellStyle2.Padding;
                return objDataGridViewCellStyle1;
            }
            if ((objDataGridViewCellStyle3 != null) && (objDataGridViewCellStyle3.Padding != Padding.Empty))
            {
                objDataGridViewCellStyle1.PaddingInternal = objDataGridViewCellStyle3.Padding;
                return objDataGridViewCellStyle1;
            }

            bool blnIsAlternatingRowsDefaultCellStylePaddingEmpty = (objAlternatingRowsDefaultCellStyle.Padding == Padding.Empty);

            if ((objRowsDefaultCellStyle.Padding != Padding.Empty) && (((intRowIndex % 2) == 0) || blnIsAlternatingRowsDefaultCellStylePaddingEmpty))
            {
                objDataGridViewCellStyle1.PaddingInternal = objRowsDefaultCellStyle.Padding;
                return objDataGridViewCellStyle1;
            }
            if (((intRowIndex % 2) == 1) && !blnIsAlternatingRowsDefaultCellStylePaddingEmpty)
            {
                objDataGridViewCellStyle1.PaddingInternal = objAlternatingRowsDefaultCellStyle.Padding;
                return objDataGridViewCellStyle1;
            }
            if ((objDataGridViewCellStyle4 != null) && (objDataGridViewCellStyle4.Padding != Padding.Empty))
            {
                objDataGridViewCellStyle1.PaddingInternal = objDataGridViewCellStyle4.Padding;
                return objDataGridViewCellStyle1;
            }
            objDataGridViewCellStyle1.PaddingInternal = objDataGridViewCellStyle5.Padding;
            return objDataGridViewCellStyle1;

        }

        /// <summary>Gets the size of the cell.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> representing the cell's dimensions.</returns>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        /// <exception cref="T:System.InvalidOperationException">rowIndex is -1</exception>
        protected virtual Size GetSize(int intRowIndex)
        {
            if (base.DataGridView == null)
            {
                return new Size(-1, -1);
            }
            if (intRowIndex == -1)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedCell", new object[] { "Size" }));
            }
            return new Size(this.OwningColumn.Thickness, this.OwningRow.GetHeight(intRowIndex));
        }

        /// <summary>Gets the value of the cell. </summary>
        /// <returns>The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> property is less than 0, indicating that the cell is a row header cell.</exception>
        protected virtual object GetValue(int intRowIndex)
        {
            DataGridView objDataGridView = base.DataGridView;
            if (objDataGridView != null)
            {
                if ((intRowIndex < 0) || (intRowIndex >= objDataGridView.Rows.Count))
                {
                    throw new ArgumentOutOfRangeException("rowIndex");
                }
                if (this.ColumnIndex < 0)
                {
                    throw new InvalidOperationException();
                }
            }
            if ((((objDataGridView == null) || ((objDataGridView.AllowUserToAddRowsInternal && (intRowIndex > -1)) && ((intRowIndex == objDataGridView.NewRowIndex) && (intRowIndex != objDataGridView.CurrentCellAddress.Y)))) || ((!objDataGridView.VirtualMode && (this.OwningColumn != null)) && !this.OwningColumn.IsDataBound)) || ((intRowIndex == -1) || (this.ColumnIndex == -1)))
            {
                return mojValue;
            }
            if ((this.OwningColumn == null) || !this.OwningColumn.IsDataBound)
            {
                return objDataGridView.OnCellValueNeeded(this.ColumnIndex, intRowIndex);
            }
            DataGridView.DataGridViewDataConnection dataConnection = objDataGridView.DataConnection;
            if (dataConnection == null)
            {
                return null;
            }
            if (dataConnection.CurrencyManager.Count <= intRowIndex)
            {
                return mojValue;
            }
            return dataConnection.GetValue(this.OwningColumn.BoundColumnIndex, this.ColumnIndex, intRowIndex);
        }

        /// <summary>Initializes the control used to edit the cell.</summary>
        /// <param name="objInitialFormattedValue">An <see cref="T:System.Object"></see> that represents the value displayed by the cell when editing is started.</param>
        /// <param name="intRowIndex">The zero-based row index of the cell's location.</param>
        /// <param name="objDataGridViewCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
        /// <exception cref="T:System.InvalidOperationException">There is no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> or if one is present, it does not have an associated editing control. </exception>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual void InitializeEditingControl(int intRowIndex, object objInitialFormattedValue, DataGridViewCellStyle objDataGridViewCellStyle)
        {
        }

        /// <summary>
        /// Returns a Rectangle that represents the widths of all the cell margins.
        /// </summary>
        /// <param name="objAdvancedBorderStyle">The advanced border style.</param>
        /// <returns></returns>
        protected virtual Rectangle BorderWidths(DataGridViewAdvancedBorderStyle objAdvancedBorderStyle)
        {

            Rectangle objRectangle = new Rectangle();
            objRectangle.X = (objAdvancedBorderStyle.Left == DataGridViewAdvancedCellBorderStyle.None) ? 0 : 1;
            if ((objAdvancedBorderStyle.Left == DataGridViewAdvancedCellBorderStyle.OutsetDouble) || (objAdvancedBorderStyle.Left == DataGridViewAdvancedCellBorderStyle.InsetDouble))
            {
                objRectangle.X++;
            }
            objRectangle.Y = (objAdvancedBorderStyle.Top == DataGridViewAdvancedCellBorderStyle.None) ? 0 : 1;
            if ((objAdvancedBorderStyle.Top == DataGridViewAdvancedCellBorderStyle.OutsetDouble) || (objAdvancedBorderStyle.Top == DataGridViewAdvancedCellBorderStyle.InsetDouble))
            {
                objRectangle.Y++;
            }
            objRectangle.Width = (objAdvancedBorderStyle.Right == DataGridViewAdvancedCellBorderStyle.None) ? 0 : 1;
            if ((objAdvancedBorderStyle.Right == DataGridViewAdvancedCellBorderStyle.OutsetDouble) || (objAdvancedBorderStyle.Right == DataGridViewAdvancedCellBorderStyle.InsetDouble))
            {
                objRectangle.Width++;
            }
            objRectangle.Height = (objAdvancedBorderStyle.Bottom == DataGridViewAdvancedCellBorderStyle.None) ? 0 : 1;
            if ((objAdvancedBorderStyle.Bottom == DataGridViewAdvancedCellBorderStyle.OutsetDouble) || (objAdvancedBorderStyle.Bottom == DataGridViewAdvancedCellBorderStyle.InsetDouble))
            {
                objRectangle.Height++;
            }
            DataGridViewColumn objOwningColumn = this.OwningColumn;
            if (objOwningColumn != null)
            {
                if ((base.DataGridView != null) && base.DataGridView.RightToLeftInternal)
                {
                    objRectangle.X += objOwningColumn.DividerWidth;
                }
                else
                {
                    objRectangle.Width += objOwningColumn.DividerWidth;
                }
            }
            DataGridViewRow objOwningRow = this.OwningRow;

            if (objOwningRow != null)
            {
                objRectangle.Height += objOwningRow.DividerHeight;
            }
            return objRectangle;
        }

        /// <summary>
        /// Caches the editing control.
        /// </summary>
        internal virtual void CacheEditingControl()
        {
        }

        /// <summary>
        /// Cells the state from column row states.
        /// </summary>
        /// <param name="enmRowState">State of the row.</param>
        /// <returns></returns>
        internal DataGridViewElementStates CellStateFromColumnRowStates(DataGridViewElementStates enmRowState)
        {
            DataGridViewElementStates enmElementState = DataGridViewElementStates.Selected | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly;
            DataGridViewElementStates enmElementState2 = DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen | DataGridViewElementStates.Displayed;
            DataGridViewColumn objOwningColumn = this.OwningColumn;
            DataGridViewElementStates enmElementState3 = objOwningColumn.State & enmElementState;
            enmElementState3 |= enmRowState & enmElementState;
            return (enmElementState3 | ((objOwningColumn.State & enmElementState2) & (enmRowState & enmElementState2)));
        }

        /// <summary>
        /// Clicks the unshares row internal.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        internal bool ClickUnsharesRowInternal(DataGridViewCellEventArgs e)
        {
            return this.ClickUnsharesRow(e);
        }

        /// <summary>
        /// Colors the distance.
        /// </summary>
        /// <param name="objColor1">The color1.</param>
        /// <param name="objColor2">The color2.</param>
        /// <returns></returns>
        internal static int ColorDistance(Color objColor1, Color objColor2)
        {
            int num = objColor1.R - objColor2.R;
            int num2 = objColor1.G - objColor2.G;
            int num3 = objColor1.B - objColor2.B;
            return (((num * num) + (num2 * num2)) + (num3 * num3));
        }

        /// <summary>
        /// Computes the error icon bounds.
        /// </summary>
        /// <param name="objCellValueBounds">The cell value bounds.</param>
        /// <returns></returns>
        internal Rectangle ComputeErrorIconBounds(Rectangle objCellValueBounds)
        {
            if ((objCellValueBounds.Width >= 20) && (objCellValueBounds.Height >= 0x13))
            {
                return new Rectangle(base.DataGridView.RightToLeftInternal ? (objCellValueBounds.Left + 4) : ((objCellValueBounds.Right - 4) - 12), objCellValueBounds.Y + ((objCellValueBounds.Height - 11) / 2), 12, 11);
            }
            return Rectangle.Empty;
        }

        /// <summary>
        /// Contents the click unshares row internal.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        internal bool ContentClickUnsharesRowInternal(DataGridViewCellEventArgs e)
        {
            return this.ContentClickUnsharesRow(e);
        }

        /// <summary>
        /// Contents the double click unshares row internal.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        internal bool ContentDoubleClickUnsharesRowInternal(DataGridViewCellEventArgs e)
        {
            return this.ContentDoubleClickUnsharesRow(e);
        }

        /// <summary>
        /// Doubles the click unshares row internal.
        /// </summary>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
        /// <returns></returns>
        internal bool DoubleClickUnsharesRowInternal(DataGridViewCellEventArgs e)
        {
            return this.DoubleClickUnsharesRow(e);
        }

        /// <summary>
        /// Enters the unshares row internal.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <param name="blnThroughMouseClick">if set to <c>true</c> [through mouse click].</param>
        /// <returns></returns>
        internal bool EnterUnsharesRowInternal(int intRowIndex, bool blnThroughMouseClick)
        {
            return this.EnterUnsharesRow(intRowIndex, blnThroughMouseClick);
        }

        /// <summary>
        /// Returns the bounding rectangle that encloses the cell's content area using a default Graphics and cell style currently in effect for the cell.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        public Rectangle GetContentBounds(int intRowIndex)
        {
            if (base.DataGridView == null)
            {
                return Rectangle.Empty;
            }
            DataGridViewCellStyle objCellStyle = this.GetInheritedStyle(null, intRowIndex, false);
            return this.GetContentBounds(base.DataGridView.CachedGraphics, objCellStyle, intRowIndex);
        }

        /// <summary>
        /// Returns the bounding rectangle that encloses the cell's content area using a default Graphics and cell style currently in effect for the cell.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objCellStyle">The cell style.</param>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        protected virtual Rectangle GetContentBounds(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex)
        {
            return Rectangle.Empty;
        }

        /// <summary>
        /// Returns the bounding rectangle that encloses the cell's error icon, if one is displayed.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        internal Rectangle GetErrorIconBounds(int intRowIndex)
        {
            DataGridViewCellStyle objCellStyle = this.GetInheritedStyle(null, intRowIndex, false);
            return this.GetErrorIconBounds(base.DataGridView.CachedGraphics, objCellStyle, intRowIndex);
        }

        /// <summary>
        /// Returns the bounding rectangle that encloses the cell's error icon, if one is displayed.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objCellStyle">The cell style.</param>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        protected virtual Rectangle GetErrorIconBounds(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex)
        {
            return Rectangle.Empty;
        }

        internal static DataGridViewFreeDimension GetFreeDimensionFromConstraint(Size objConstraintSize)
        {
            if ((objConstraintSize.Width < 0) || (objConstraintSize.Height < 0))
            {
                throw new ArgumentException(SR.GetString("InvalidArgument", new object[] { "constraintSize", objConstraintSize.ToString() }));
            }
            if (objConstraintSize.Width == 0)
            {
                if (objConstraintSize.Height == 0)
                {
                    return DataGridViewFreeDimension.Both;
                }
                return DataGridViewFreeDimension.Width;
            }
            if (objConstraintSize.Height != 0)
            {
                throw new ArgumentException(SR.GetString("InvalidArgument", new object[] { "constraintSize", objConstraintSize.ToString() }));
            }
            return DataGridViewFreeDimension.Height;
        }

        internal int GetHeight(int intRowIndex)
        {
            if (base.DataGridView == null)
            {
                return -1;
            }
            return this.OwningRow.GetHeight(intRowIndex);
        }

        /// <summary>
        /// Leaves the unshares row internal.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <param name="blnThroughMouseClick">if set to <c>true</c> [through mouse click].</param>
        /// <returns></returns>
        internal bool LeaveUnsharesRowInternal(int intRowIndex, bool blnThroughMouseClick)
        {
            return this.LeaveUnsharesRow(intRowIndex, blnThroughMouseClick);
        }

        /// <summary>
        /// Converts a value formatted for display to an actual cell value.
        /// </summary>
        /// <param name="objFormattedValue">The formatted value.</param>
        /// <param name="objCellStyle">The cell style.</param>
        /// <param name="objFormattedValueTypeConverter">The formatted value type converter.</param>
        /// <param name="objValueTypeConverter">The value type converter.</param>
        /// <returns></returns>
        public virtual object ParseFormattedValue(object objFormattedValue, DataGridViewCellStyle objCellStyle, TypeConverter objFormattedValueTypeConverter, TypeConverter objValueTypeConverter)
        {
            return this.ParseFormattedValueInternal(this.ValueType, objFormattedValue, objCellStyle, objFormattedValueTypeConverter, objValueTypeConverter);
        }

        internal object ParseFormattedValueInternal(Type objValueType, object objFormattedValue, DataGridViewCellStyle objCellStyle, TypeConverter objFormattedValueTypeConverter, TypeConverter objValueTypeConverter)
        {
            if (objCellStyle == null)
            {
                throw new ArgumentNullException("cellStyle");
            }
            if (this.FormattedValueType == null)
            {
                throw new FormatException(SR.GetString("DataGridViewCell_FormattedValueTypeNull"));
            }
            if (objValueType == null)
            {
                throw new FormatException(SR.GetString("DataGridViewCell_ValueTypeNull"));
            }
            if ((objFormattedValue == null) || !this.FormattedValueType.IsAssignableFrom(objFormattedValue.GetType()))
            {
                throw new ArgumentException(SR.GetString("DataGridViewCell_FormattedValueHasWrongType"), "formattedValue");
            }
            return ClientUtils.ParseObject(objFormattedValue, objValueType, this.FormattedValueType, (objValueTypeConverter == null) ? this.ValueTypeConverter : objValueTypeConverter, (objFormattedValueTypeConverter == null) ? this.FormattedValueTypeConverter : objFormattedValueTypeConverter, objCellStyle.FormatProvider, objCellStyle.NullValue, objCellStyle.IsDataSourceNullValueDefault ? ClientUtils.GetDefaultDataSourceNullValue(objValueType) : objCellStyle.DataSourceNullValue);
        }

        /// <summary>Sets the location and size of the editing control hosted by a cell in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
        /// <param name="objCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the style of the cell being edited.</param>
        /// <param name="blnIsFirstDisplayedColumn">true if the hosting cell is in the first visible column; otherwise, false.</param>
        /// <param name="blnSingleVerticalBorderAdded">true to add a vertical border to the cell; otherwise, false.</param>
        /// <param name="blnSetSize">true to specify the size; false to allow the control to size itself. </param>
        /// <param name="blnSetLocation">true to have the control placed as specified by the other arguments; false to allow the control to place itself.</param>
        /// <param name="objCellClip">The area that will be used to paint the editing control.</param>
        /// <param name="blnSingleHorizontalBorderAdded">true to add a horizontal border to the cell; otherwise, false.</param>
        /// <param name="objCellBounds">A <see cref="T:System.Drawing.Rectangle"></see> that defines the cell bounds. </param>
        /// <param name="blnIsFirstDisplayedRow">true if the hosting cell is in the first visible row; otherwise, false.</param>
        /// <exception cref="T:System.InvalidOperationException">The cell is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual void PositionEditingControl(bool blnSetLocation, bool blnSetSize, Rectangle objCellBounds, Rectangle objCellClip, DataGridViewCellStyle objCellStyle, bool blnSingleVerticalBorderAdded, bool blnSingleHorizontalBorderAdded, bool blnIsFirstDisplayedColumn, bool blnIsFirstDisplayedRow)
        {
            Rectangle objRectangle = this.PositionEditingPanel(objCellBounds, objCellClip, objCellStyle, blnSingleVerticalBorderAdded, blnSingleHorizontalBorderAdded, blnIsFirstDisplayedColumn, blnIsFirstDisplayedRow);
            if (blnSetLocation)
            {
                base.DataGridView.EditingControl.Location = new Point(objRectangle.X, objRectangle.Y);
            }
            if (blnSetSize)
            {
                base.DataGridView.EditingControl.Size = new Size(objRectangle.Width, objRectangle.Height);
            }
        }

        /// <summary>Sets the value of the cell. </summary>
        /// <returns>true if the value has been set; otherwise, false.</returns>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        /// <param name="objValue">The cell value to set. </param>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
        protected virtual bool SetValue(int intRowIndex, object objValue)
        {
            return this.SetValue(intRowIndex, objValue, false);
        }

        /// <summary>Sets the value of the cell. </summary>
        /// <returns>true if the value has been set; otherwise, false.</returns>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        /// <param name="objValue">The cell value to set. </param>
        /// <param name="blnClientSource">Client source. </param>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
        private bool SetValue(int intRowIndex, object objValue, bool blnClientSource)
        {
            object obj2 = null;
            DataGridView objDataGridView = base.DataGridView;
            if ((objDataGridView != null) && !objDataGridView.InSortOperation)
            {
                obj2 = this.GetValue(intRowIndex);
            }
            if (((objDataGridView != null) && (this.OwningColumn != null)) && this.OwningColumn.IsDataBound)
            {
                DataGridView.DataGridViewDataConnection dataConnection = objDataGridView.DataConnection;
                if (dataConnection == null)
                {
                    return false;
                }
                if (dataConnection.CurrencyManager.Count <= intRowIndex)
                {
                    if (objValue != null || mojValue != null)
                    {
                        mojValue = objValue;
                    }
                }
                else
                {
                    if (!dataConnection.PushValue(this.OwningColumn.BoundColumnIndex, this.ColumnIndex, intRowIndex, objValue))
                    {
                        return false;
                    }
                    if (((base.DataGridView == null) || (this.OwningRow == null)) || (this.OwningRow.DataGridView == null))
                    {
                        return true;
                    }
                    if (this.OwningRow.Index == base.DataGridView.CurrentCellAddress.Y)
                    {
                        base.DataGridView.SetIsCurrentRowDirtyInternal(true, blnClientSource);
                    }
                }
            }
            else if (((objDataGridView == null) || !objDataGridView.VirtualMode) || ((intRowIndex == -1) || (this.ColumnIndex == -1)))
            {
                if (objValue != null || mojValue != null)
                {
                    mojValue = objValue;
                }
            }
            else
            {
                objDataGridView.OnCellValuePushed(this.ColumnIndex, intRowIndex, objValue);
            }
            if (((objDataGridView != null) && !objDataGridView.InSortOperation) && ((((obj2 == null) && (objValue != null)) || ((obj2 != null) && (objValue == null))) || ((obj2 != null) && !objValue.Equals(obj2))))
            {
                base.RaiseCellValueChanged(new DataGridViewCellEventArgs(this.ColumnIndex, intRowIndex), blnClientSource);
            }
            return true;

        }

        /// <summary>
        /// Sets the value internal.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <param name="objValue">The value.</param>
        /// <returns></returns>
        internal bool SetValueInternal(int intRowIndex, object objValue)
        {
            return this.SetValueInternal(intRowIndex, objValue, false);
        }


        /// <summary>
        /// Sets the value internal.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <param name="objValue">The value.</param>
        /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
        /// <returns></returns>
        internal bool SetValueInternal(int intRowIndex, object objValue, bool blnClientSource)
        {
            return this.SetValue(intRowIndex, objValue, blnClientSource);
        }

        /// <summary>Returns a string that describes the current object. </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            return ("DataGridViewCell { ColumnIndex=" + this.ColumnIndex.ToString() + ", RowIndex=" + this.RowIndex.ToString() + " }");
        }

        /// <summary>
        /// Clones the internal.
        /// </summary>
        /// <param name="objDataGridViewCell">The data grid view cell.</param>
        protected void CloneInternal(DataGridViewCell objDataGridViewCell)
        {
            if (this.HasValueType)
            {
                objDataGridViewCell.ValueType = this.ValueType;
            }
            if (this.HasStyle)
            {
                objDataGridViewCell.Style = new DataGridViewCellStyle(this.Style);
            }
            if (this.HasErrorText)
            {
                objDataGridViewCell.ErrorText = this.ErrorTextInternal;
            }

            objDataGridViewCell.StateInternal = this.State & ~DataGridViewElementStates.Selected;
            objDataGridViewCell.Tag = this.Tag;
            objDataGridViewCell.LastModified = this.LastModified;
            objDataGridViewCell.LastModifiedParams = this.LastModifiedParams;
            objDataGridViewCell.LastModifiedParamsType = this.LastModifiedParamsType;
        }

        /// <summary>
        /// Formats the plain text as HTML.
        /// </summary>
        /// <param name="str">The s.</param>
        /// <param name="objOutput">The output.</param>
        internal static void FormatPlainTextAsHtml(string str, TextWriter objOutput)
        {
            if (str != null)
            {
                int intLength = str.Length;
                char ch = '\0';
                for (int i = 0; i < intLength; i++)
                {
                    char ch2 = str[i];
                    switch (ch2)
                    {
                        case '\n':
                            objOutput.Write("<br>");
                            goto Label_0113;

                        case '\r':
                            goto Label_0113;

                        case ' ':
                            if (ch != ' ')
                            {
                                break;
                            }
                            objOutput.Write("&nbsp;");
                            goto Label_0113;

                        case '"':
                            objOutput.Write("&quot;");
                            goto Label_0113;

                        case '&':
                            objOutput.Write("&amp;");
                            goto Label_0113;

                        case '<':
                            objOutput.Write("&lt;");
                            goto Label_0113;

                        case '>':
                            objOutput.Write("&gt;");
                            goto Label_0113;

                        default:
                            if ((ch2 >= '\x00a0') && (ch2 < 'Ā'))
                            {
                                objOutput.Write("&#");
                                objOutput.Write(((int)ch2).ToString(NumberFormatInfo.InvariantInfo));
                                objOutput.Write(';');
                            }
                            else
                            {
                                objOutput.Write(ch2);
                            }
                            goto Label_0113;
                    }
                    objOutput.Write(ch2);
                Label_0113:
                    ch = ch2;
                }
            }
        }

        /// <summary>
        /// Formats the plain text.
        /// </summary>
        /// <param name="str">The s.</param>
        /// <param name="blnCsv">if set to <c>true</c> [CSV].</param>
        /// <param name="objOutput">The output.</param>
        /// <param name="blnEscapeApplied">if set to <c>true</c> [escape applied].</param>
        internal static void FormatPlainText(string str, bool blnCsv, TextWriter objOutput, ref bool blnEscapeApplied)
        {
            if (str != null)
            {
                int intLength = str.Length;
                for (int i = 0; i < intLength; i++)
                {
                    char ch = str[i];
                    switch (ch)
                    {
                        case '\t':
                            if (!blnCsv)
                            {
                                objOutput.Write(' ');
                            }
                            else
                            {
                                objOutput.Write('\t');
                            }
                            break;

                        case '"':
                            if (blnCsv)
                            {
                                objOutput.Write("\"\"");
                                blnEscapeApplied = true;
                            }
                            else
                            {
                                objOutput.Write('"');
                            }
                            break;

                        case ',':
                            if (blnCsv)
                            {
                                blnEscapeApplied = true;
                            }
                            objOutput.Write(',');
                            break;

                        default:
                            objOutput.Write(ch);
                            break;
                    }
                }
                if (blnEscapeApplied)
                {
                    objOutput.Write('"');
                }
            }
        }

        private static Bitmap GetBitmap(string strBitmapName)
        {
            Bitmap bitmap = new Bitmap(typeof(DataGridViewCell), strBitmapName);
            bitmap.MakeTransparent();
            return bitmap;
        }

        internal object GetValueInternal(int intRowIndex)
        {
            return this.GetValue(intRowIndex);
        }

        internal int GetPreferredWidth(int intRowIndex, int intHeight)
        {
            if (base.DataGridView == null)
            {
                return -1;
            }
            DataGridViewCellStyle objCellStyle = this.GetInheritedStyle(null, intRowIndex, false);
            return this.GetPreferredSize(base.DataGridView.CachedGraphics, objCellStyle, intRowIndex, new Size(0, intHeight)).Width;
        }

        internal DataGridViewCellStyle GetInheritedStyleInternal(int intRowIndex)
        {
            return this.GetInheritedStyle(null, intRowIndex, true);
        }

        /// <summary>Returns a string that represents the error for the cell.</summary>
        /// <returns>A string that describes the error for the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
        /// <param name="intRowIndex">The row index of the cell.</param>
        protected internal virtual string GetErrorText(int intRowIndex)
        {
            string strErrorText = string.Empty;
            object obj2 = mobjErrorText;
            if (obj2 != null)
            {
                strErrorText = (string)obj2;
            }
            else if ((((base.DataGridView != null) && (intRowIndex != -1)) && ((intRowIndex != base.DataGridView.NewRowIndex) && (this.OwningColumn != null))) && (this.OwningColumn.IsDataBound && (base.DataGridView.DataConnection != null)))
            {
                strErrorText = base.DataGridView.DataConnection.GetError(this.OwningColumn.BoundColumnIndex, this.ColumnIndex, intRowIndex);
            }
            if (((base.DataGridView != null) && (base.DataGridView.VirtualMode || (base.DataGridView.DataSource != null))) && ((this.ColumnIndex >= 0) && (intRowIndex >= 0)))
            {
                strErrorText = base.DataGridView.OnCellErrorTextNeeded(this.ColumnIndex, intRowIndex, strErrorText);
            }
            return strErrorText;
        }

        /// <summary>Calculates the preferred size with constraints, in pixels, of the cell.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
        /// <param name="strText">The text to be measured.</param>
        /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
        protected virtual Size GetPreferredSize(string strText, DataGridViewCellStyle objCellStyle, Size objConstraintSize)
        {
            Font objFont = null;

            int intWidthPadding = DefaultHorizontalPadding;
            int intHeightPadding = DefaultVerticalPadding;

            bool blnWrapMode = false;

            if (objCellStyle != null)
            {
                Padding objPadding = objCellStyle.Padding;

#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
                if (objPadding != null)
#else
                if (objPadding != Padding.Empty)
#endif
                {
                    intWidthPadding += objPadding.Horizontal;
                    intHeightPadding += objPadding.Vertical;
                }

                objFont = objCellStyle.Font;

                blnWrapMode = HasWrapMode(objCellStyle);
            }

            Size objSize = Size.Empty;

            // Width constraints will be the constraints parameter, or the owning column if no constraints.
            // be aware of state when owning column is not initialized
            int intCellWidth = -1;
            if (objConstraintSize.Width > 0)
                intCellWidth = objConstraintSize.Width;
            else if (null != this.OwningColumn)
            {
                intCellWidth = this.OwningColumn.Thickness;
            }

            if (blnWrapMode)
            {
                objSize = CommonUtils.GetStringMeasurements(strText, objFont, intCellWidth - intWidthPadding);
                return new Size(intCellWidth, objSize.Height + intHeightPadding);
            }
            else
            {
                objSize = CommonUtils.GetStringMeasurements(strText, objFont, true);
                return new Size(objSize.Width + intWidthPadding, objSize.Height + intHeightPadding);
            }

        }

        /// <summary>Calculates the preferred size, in pixels, of the cell.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
        /// <param name="strText">The text to be measured.</param>
        /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
        protected virtual Size GetPreferredSize(string strText, DataGridViewCellStyle objCellStyle)
        {

            Size objSize = Size.Empty;

            // be aware of state when owning column is not initialized
            int intCellWidth = -1;
            if (null != this.OwningColumn)
            {
                intCellWidth = this.OwningColumn.Thickness;
            }
            objSize.Width = intCellWidth;
            return this.GetPreferredSize(strText, objCellStyle, objSize);

        }

        /// <summary>
        /// Determines whether [has wrap mode] [the specified obj cell style].
        /// </summary>
        /// <param name="objCellStyle">The obj cell style.</param>
        /// <returns>
        ///   <c>true</c> if [has wrap mode] [the specified obj cell style]; otherwise, <c>false</c>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool HasWrapMode(DataGridViewCellStyle objCellStyle)
        {
            return objCellStyle != null && objCellStyle.WrapMode == DataGridViewTriState.True;
        }

        /// <summary>Calculates the preferred size, in pixels, of the cell.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
        /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
        /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
        /// <param name="objConstraintSize">The cell's maximum allowable size.</param>
        /// <param name="intRowIndex">The zero-based row index of the cell.</param>
        protected virtual Size GetPreferredSize(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex, Size objConstraintSize)
        {
            string strFormattedValue = this.GetFormattedValue(intRowIndex, ref objCellStyle, DataGridViewDataErrorContexts.PreferredSize | DataGridViewDataErrorContexts.Formatting) as string;
            return this.GetPreferredSize(strFormattedValue, objCellStyle, objConstraintSize);
        }

        internal Size GetPreferredSize(int intRowIndex)
        {
            if (base.DataGridView == null)
            {
                return new Size(-1, -1);
            }
            DataGridViewCellStyle objCellStyle = this.GetInheritedStyle(null, intRowIndex, false);
            return this.GetPreferredSize(base.DataGridView.CachedGraphics, objCellStyle, intRowIndex, Size.Empty);
        }

        internal int GetPreferredHeight(int intRowIndex, int intWidth)
        {
            if (base.DataGridView == null)
            {
                return -1;
            }
            DataGridViewCellStyle objCellStyle = this.GetInheritedStyle(null, intRowIndex, false);
            return this.GetPreferredSize(base.DataGridView.CachedGraphics, objCellStyle, intRowIndex, new Size(intWidth, 0)).Height;
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets a value indicating whether [support edit mode].
        /// </summary>
        /// <value><c>true</c> if [support edit mode]; otherwise, <c>false</c>.</value>
        protected virtual bool SupportEditMode
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [support active mode]. Whethre this cell would be redrawn with defferent skin.
        /// </summary>
        /// <value><c>true</c> if [support active mode]; otherwise, <c>false</c>.</value>
        protected virtual bool SupportActiveMode
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the value type converter.
        /// </summary>
        /// <value>The value type converter.</value>
        private TypeConverter ValueTypeConverter
        {
            get
            {
                TypeConverter objConverter1 = null;
                if (this.OwningColumn != null)
                {
                    objConverter1 = this.OwningColumn.BoundColumnConverter;
                }
                if ((objConverter1 != null) || (this.ValueType == null))
                {
                    return objConverter1;
                }
                if (base.DataGridView != null)
                {
                    return base.DataGridView.GetCachedTypeConverter(this.ValueType);
                }
                return TypeDescriptor.GetConverter(this.ValueType);
            }
        }

        /// <summary>
        /// Gets the formatted value type converter.
        /// </summary>
        /// <value>The formatted value type converter.</value>
        private TypeConverter FormattedValueTypeConverter
        {
            get
            {
                TypeConverter objConverter1 = null;
                if (this.FormattedValueType == null)
                {
                    return objConverter1;
                }
                if (base.DataGridView != null)
                {
                    return base.DataGridView.GetCachedTypeConverter(this.FormattedValueType);
                }
                return TypeDescriptor.GetConverter(this.FormattedValueType);
            }
        }

        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        /// <value>The flags.</value>
        private byte Flags
        {
            get
            {
                return this.mobjFlags;
            }
            set
            {
                this.mobjFlags = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal virtual string TypeName
        {
            get
            {
                if (this.DataGridView != null)
                {
                    DataGridViewColumn objColumn = this.DataGridView.Columns[this.ColumnIndex];
                    if (objColumn != null)
                    {
                        return objColumn.TypeNameInternal;
                    }
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string MemberID
        {
            get
            {
                // Calculate cell's row index.
                int intRowIndex = this.OwningRow.IsFilterRow ? 0 : this.RowIndex + (this.DataGridView.ShowFilterRow ? 1 : 0);

                // Build cell's member id.
                return "D" + ((this.DataGridView.ColumnCount * intRowIndex) + this.ColumnIndex);
            }
        }

        /// <summary>Gets the column index for this cell. </summary>
        /// <returns>The index of the column that contains the cell; -1 if the cell is not contained within a column.</returns>
        /// <filterpriority>1</filterpriority>
        public int ColumnIndex
        {
            get
            {
                DataGridViewColumn objOwningColumn = this.OwningColumn;
                if (objOwningColumn == null)
                {
                    return -1;
                }
                return objOwningColumn.Index;
            }
        }

        /// <summary>Gets the default value for a cell in the row for new records.</summary>
        /// <returns>An <see cref="T:System.Object"></see> representing the default value.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public virtual object DefaultNewRowValue
        {
            get
            {
                return null;
            }
        }

        /// <summary>Gets a value that indicates whether the cell is currently displayed on-screen. </summary>
        /// <returns>true if the cell is on-screen or partially on-screen; otherwise, false.</returns>
        [Browsable(false)]
        public virtual bool Displayed
        {
            get
            {
                if (base.DataGridView != null)
                {
                    if (((base.DataGridView == null) || (this.RowIndex < 0)) || (this.ColumnIndex < 0))
                    {
                        return false;
                    }
                    if (this.OwningColumn.Displayed)
                    {
                        return this.OwningRow.Displayed;
                    }
                }
                return false;
            }
        }

        /// <summary>Gets the current, formatted value of the cell, regardless of whether the cell is in edit mode and the value has not been committed. </summary>
        /// <returns>The current, formatted value of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The row containing the cell is a shared row.-or-The cell is a column header cell.</exception>
        /// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell. </exception>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public object EditedFormattedValue
        {
            get
            {
                if (base.DataGridView == null)
                {
                    return null;
                }
                DataGridViewCellStyle objDataGridViewCellStyle = this.GetInheritedStyle(null, this.RowIndex, false);
                return this.GetEditedFormattedValue(this.GetValue(this.RowIndex), this.RowIndex, ref objDataGridViewCellStyle, DataGridViewDataErrorContexts.Formatting);

            }
        }

        /// <summary>Gets the type of the cell's hosted editing control. </summary>
        /// <returns>A <see cref="T:System.Type"></see> representing the <see cref="T:System.Windows.Forms.DataGridViewTextBoxEditingControl"></see> type.</returns>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public virtual Type EditType
        {
            get
            {
                return typeof(DataGridViewTextBoxEditingControl);
            }
        }

        /// <summary>Gets or sets the text describing an error condition associated with the cell. </summary>
        /// <returns>The text that describes an error condition associated with the cell.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public string ErrorText
        {
            get
            {
                return this.GetErrorText(this.RowIndex);
            }
            set
            {
                this.ErrorTextInternal = value;
            }

        }

        private string ErrorTextInternal
        {
            get
            {
                if (mobjErrorText != null)
                {
                    return (string)mobjErrorText;
                }
                return string.Empty;
            }
            set
            {
                string strErrorTextInternal = this.ErrorTextInternal;
                if (!CommonUtils.IsNullOrEmpty(value) || mobjErrorText != null)
                {
                    mobjErrorText = value;
                }
                if ((base.DataGridView != null) && !strErrorTextInternal.Equals(this.ErrorTextInternal))
                {
                    base.DataGridView.OnCellErrorTextChanged(this);
                }
            }
        }

        /// <summary>Gets the value of the cell as formatted for display.</summary>
        /// <returns>The formatted value of the cell or null if the cell does not belong to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The row containing the cell is a shared row.-or-The cell is a column header cell.</exception>
        /// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see>.</exception>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public object FormattedValue
        {
            get
            {
                if (base.DataGridView == null)
                {
                    return null;
                }
                DataGridViewCellStyle objDataGridViewCellStyle = this.GetInheritedStyle(null, this.RowIndex, false);
                return this.GetFormattedValue(this.RowIndex, ref objDataGridViewCellStyle, DataGridViewDataErrorContexts.Formatting);
            }
        }

        /// <summary>Gets the type of the formatted value associated with the cell. </summary>
        /// <returns>A <see cref="T:System.Type"></see> representing the type of the cell's formatted value.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public virtual Type FormattedValueType
        {
            get
            {
                return this.ValueType;
            }
        }

        /// <summary>Gets a value indicating whether the cell is frozen. </summary>
        /// <returns>true if the cell is frozen; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public virtual bool Frozen
        {
            get
            {
                DataGridViewRow objOwningRow = this.OwningRow;

                if (((base.DataGridView != null) && (this.RowIndex >= 0)) && (this.ColumnIndex >= 0))
                {
                    return (this.OwningColumn.Frozen && objOwningRow.Frozen);
                }
                if ((objOwningRow == null) || ((objOwningRow.DataGridView != null) && (this.RowIndex < 0)))
                {
                    return false;
                }
                return objOwningRow.Frozen;
            }

        }

        /// <summary>Gets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Style"></see> property has been set.</summary>
        /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Style"></see> property has been set; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public bool HasStyle
        {
            get
            {
                return (mobjStyle != null);
            }
        }

        /// <summary>Gets the current state of the cell as inherited from the state of its row and column.</summary>
        /// <returns>A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values representing the current state of the cell.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The cell is contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and the value of its <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.RowIndex"></see> property is -1.</exception>
        /// <exception cref="T:System.ArgumentException">The cell is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and the value of its <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.RowIndex"></see> property is not -1.</exception>
        [Browsable(false)]
        public DataGridViewElementStates InheritedState
        {
            get
            {
                return this.GetInheritedState(this.RowIndex);
            }
        }

        /// <summary>Gets the style currently applied to the cell. </summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> currently applied to the cell.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The row containing the cell is a shared row.-or-The cell is a column header cell.</exception>
        /// <exception cref="T:System.InvalidOperationException">The cell does not belong to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.-or- <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
        [Browsable(false)]
        public DataGridViewCellStyle InheritedStyle
        {

            get
            {
                return this.GetInheritedStyleInternal(this.RowIndex);
            }

        }

        /// <summary>Gets a value indicating whether this cell is currently being edited.</summary>
        /// <returns>true if the cell is in edit mode; otherwise, false.</returns>
        /// <exception cref="T:System.InvalidOperationException">The row containing the cell is a shared row.</exception>
        [Browsable(false)]
        public bool IsInEditMode
        {
            get
            {
                if (base.DataGridView == null)
                {
                    return false;
                }
                if (this.RowIndex == -1)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedCell"));
                }
                Point objCurrentCellAddress = base.DataGridView.CurrentCellAddress;
                return ((((objCurrentCellAddress.X != -1) && (objCurrentCellAddress.X == this.ColumnIndex)) && (objCurrentCellAddress.Y == this.RowIndex)) && base.DataGridView.IsCurrentCellInEditMode);
            }
        }

        /// <summary>Gets the column that contains this cell.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> that contains the cell, or null if the cell is not in a column.</returns>
        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public DataGridViewColumn OwningColumn
        {
            get
            {
                return this.mobjOwningColumn;
            }
        }

        /// <summary>
        /// Sets the owning column internal.
        /// </summary>
        /// <value>The owning column internal.</value>
        internal DataGridViewColumn OwningColumnInternal
        {
            set
            {
                this.mobjOwningColumn = value;
            }
        }

        /// <summary>Gets the row that contains this cell. </summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that contains the cell, or null if the cell is not in a row.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public DataGridViewRow OwningRow
        {
            get
            {
                return mobjOwningRow;
            }
        }

        /// <summary>
        /// Gets or sets the formatted cell style.
        /// </summary>
        /// <value>The formatted cell style.</value>
        protected DataGridViewCellStyle FormattedCellStyle
        {
            get
            {
                return mobjFormattedCellStyle;
            }
        }

        /// <summary>
        /// Sets the owning row internal.
        /// </summary>
        /// <value>The owning row internal.</value>
        internal DataGridViewRow OwningRowInternal
        {
            set
            {
                mobjOwningRow = value;
            }
        }

        /// <summary>Gets the size, in pixels, of a rectangular area into which the cell can fit. </summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> containing the height and width, in pixels.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The row containing the cell is a shared row.-or-The cell is a column header cell.</exception>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public Size PreferredSize
        {
            get
            {
                return this.GetPreferredSize(this.RowIndex);
            }
        }

        /// <summary>Gets or sets a value indicating whether the cell's data can be edited. </summary>
        /// <returns>true if the cell's data can be edited; otherwise, false.</returns>
        /// <exception cref="T:System.InvalidOperationException">There is no owning row when setting this property. -or-The owning row is shared when setting this property.</exception>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool ReadOnly
        {
            get
            {
                if ((this.State & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None)
                {
                    return true;
                }
                DataGridViewRow objOwningRow = this.OwningRow;

                if (((objOwningRow != null) && ((objOwningRow.DataGridView == null) || (this.RowIndex >= 0))) && objOwningRow.ReadOnly)
                {
                    return true;
                }
                if (((base.DataGridView != null) && (this.RowIndex >= 0)) && (this.ColumnIndex >= 0))
                {
                    return this.OwningColumn.ReadOnly;
                }
                return false;
            }
            set
            {
                DataGridViewRow objOwningRow = this.OwningRow;

                if (base.DataGridView != null)
                {
                    if (this.RowIndex == -1)
                    {
                        throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedCell"));
                    }
                    if ((value != this.ReadOnly) && !base.DataGridView.ReadOnly)
                    {
                        base.DataGridView.OnDataGridViewElementStateChanging(this, -1, DataGridViewElementStates.ReadOnly);
                        base.DataGridView.SetReadOnlyCellCore(this.ColumnIndex, this.RowIndex, value);

                        // Update cell visual attributes
                        this.UpdateParams(AttributeType.Visual);
                    }
                }
                else if (objOwningRow == null)
                {
                    if (value != this.ReadOnly)
                    {
                        throw new InvalidOperationException(SR.GetString("DataGridViewCell_CannotSetReadOnlyState"));
                    }
                }
                else
                {
                    objOwningRow.SetReadOnlyCellCore(this, value);
                }

                // Update element readonly value
                this.ElementReadOnly = value ? ElementReadOnlyType.True : ElementReadOnlyType.False;
            }
        }

        /// <summary>
        /// Sets a value indicating whether [read only internal].
        /// </summary>
        /// <value><c>true</c> if [read only internal]; otherwise, <c>false</c>.</value>
        internal bool ReadOnlyInternal
        {
            set
            {
                if (value)
                {
                    base.StateInternal = this.State | DataGridViewElementStates.ReadOnly;
                }
                else
                {
                    base.StateInternal = this.State & ~DataGridViewElementStates.ReadOnly;
                }
                if (base.DataGridView != null)
                {
                    base.DataGridView.OnDataGridViewElementStateChanged(this, -1, DataGridViewElementStates.ReadOnly);
                }

            }
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>The location.</value>
        protected internal override Point Location
        {
            get
            {
                Point objLocation = Point.Empty;

                if (this.OwningRow != null)
                {
                    objLocation.Y = this.OwningRow.Location.Y;
                }

                if (this.OwningColumn != null)
                {
                    objLocation.X = this.OwningColumn.Location.X;
                }

                return objLocation;
            }
        }

        /// <summary>Gets a value indicating whether the cell can be resized. </summary>
        /// <returns>true if the cell can be resized; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public virtual bool Resizable
        {
            get
            {
                DataGridViewRow objOwningRow = this.OwningRow;

                if (((objOwningRow != null) && ((objOwningRow.DataGridView == null) || (this.RowIndex >= 0))) && (objOwningRow.Resizable == DataGridViewTriState.True))
                {
                    return true;
                }
                if (((base.DataGridView != null) && (this.RowIndex >= 0)) && (this.ColumnIndex >= 0))
                {
                    return (this.OwningColumn.Resizable == DataGridViewTriState.True);
                }
                return false;
            }
        }

        /// <summary>Gets the index of the cell's parent row. </summary>
        /// <returns>The index of the row that contains the cell; -1 if there is no owning row.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public int RowIndex
        {
            get
            {
                DataGridViewRow objOwningRow = this.OwningRow;

                if (objOwningRow == null)
                {
                    return -1;
                }
                return objOwningRow.Index;
            }
        }

        /// <summary>Gets or sets a value indicating whether the cell has been selected. </summary>
        /// <returns>true if the cell has been selected; otherwise, false.</returns>
        /// <exception cref="T:System.InvalidOperationException">There is no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> when setting this property. -or-The owning row is shared when setting this property.</exception>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual bool Selected
        {
            get
            {
                if ((this.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.None)
                {
                    return true;
                }
                DataGridViewRow objOwningRow = this.OwningRow;

                if (((objOwningRow != null) && ((objOwningRow.DataGridView == null) || (this.RowIndex >= 0))) && objOwningRow.Selected)
                {
                    return true;
                }
                if (((base.DataGridView != null) && (this.RowIndex >= 0)) && (this.ColumnIndex >= 0))
                {
                    return this.OwningColumn.Selected;
                }
                return false;
            }
            set
            {
                if (base.DataGridView != null)
                {
                    if (this.RowIndex == -1)
                    {
                        throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedCell"));
                    }
                    base.DataGridView.SetSelectedCellCoreInternal(this.ColumnIndex, this.RowIndex, value);
                }
                else if (value)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewCell_CannotSetSelectedState"));
                }
            }

        }

        internal bool SelectedInternal
        {
            set
            {
                if (value)
                {
                    base.StateInternal = this.State | DataGridViewElementStates.Selected;
                }
                else
                {
                    base.StateInternal = this.State & ~DataGridViewElementStates.Selected;
                }

                if (base.DataGridView != null)
                {
                    base.DataGridView.OnDataGridViewElementStateChanged(this, -1, DataGridViewElementStates.Selected);
                }
            }
        }

        internal bool HasValue
        {
            get
            {
                return (mojValue != null);
            }
        }

        internal bool HasToolTipText
        {
            get
            {
                return (mobjToolTipText != null);
            }
        }

        /// <summary>Gets the size of the cell.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> set to the owning row's height and the owning column's width. </returns>
        /// <exception cref="T:System.InvalidOperationException">The row containing the cell is a shared row.-or-The cell is a column header cell.</exception>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public Size Size
        {
            get
            {
                return this.GetSize(this.RowIndex);
            }
        }

        /// <summary>Gets or sets the style for the cell. </summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</returns>
        /// <filterpriority>1</filterpriority>

        [Browsable(true)]
        public DataGridViewCellStyle Style
        {
            get
            {
                if (mobjStyle == null)
                {
                    mobjStyle = new DataGridViewCellStyle();
                    mobjStyle.AddScope(base.DataGridView, DataGridViewCellStyleScopes.Cell);
                }
                return mobjStyle;
            }
            set
            {
                DataGridViewCellStyle objDataGridViewCellStyle = null;
                if (this.HasStyle)
                {
                    objDataGridViewCellStyle = this.Style;
                    objDataGridViewCellStyle.RemoveScope(DataGridViewCellStyleScopes.Cell);
                }
                if (value != null || mobjStyle != null)
                {
                    if (value != null)
                    {
                        value.AddScope(base.DataGridView, DataGridViewCellStyleScopes.Cell);
                    }

                    mobjStyle = value;
                }
                if (((((objDataGridViewCellStyle != null) && (value == null)) || ((objDataGridViewCellStyle == null) && (value != null))) || (((objDataGridViewCellStyle != null) && (value != null)) && !objDataGridViewCellStyle.Equals(this.Style))) && (base.DataGridView != null))
                {
                    base.DataGridView.OnCellStyleChanged(this);
                }
            }
        }

        /// <summary>Gets or sets the object that contains supplemental data about the cell. </summary>
        /// <returns>An <see cref="T:System.Object"></see> that contains data about the cell. The default is null.</returns>
        /// <filterpriority>1</filterpriority>
        [SRDescription("ControlTagDescr"), TypeConverter(typeof(StringConverter)), SRCategory("CatData"), Localizable(false), Bindable(true), DefaultValue((string)null)]
        public object Tag
        {
            get
            {
                return mobjTag;
            }
            set
            {
                if (value != null || mobjTag != null)
                {
                    mobjTag = value;
                }
            }
        }

        /// <summary>Gets or sets the ToolTip text associated with this cell.</summary>
        /// <returns>The ToolTip text associated with the cell. The default is <see cref="F:System.String.Empty"></see>. </returns>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public string ToolTipText
        {
            get
            {
                return this.GetToolTipText(this.RowIndex);
            }
            set
            {
                this.ToolTipTextInternal = value;
            }
        }

        /// <summary>Gets or sets the value associated with this cell. </summary>
        /// <returns>Gets or sets the data to be displayed by the cell. The default is null.</returns>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.RowIndex"></see> is outside the valid range of 0 to the number of rows in the control minus 1.</exception>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public object Value
        {
            get
            {
                return this.GetValue(this.RowIndex);
            }
            set
            {
                if (this.GetValue(this.RowIndex) != value)
                {
                    this.SetValue(this.RowIndex, value);
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the editing proposed value.
        /// </summary>
        /// <value>The editing proposed value.</value>
        [Browsable(false)]
        internal object EditingProposedValue
        {
            get
            {
                return this.mobjEditingProposedValue;
            }
            set
            {
                this.mobjEditingProposedValue = value;
            }
        }

        protected string ValueText
        {
            get
            {
                object objValue = this.Value;
                if (objValue != null)
                {
                    return objValue.ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>Gets or sets the data type of the values in the cell. </summary>
        /// <returns>A <see cref="T:System.Type"></see> representing the data type of the value in the cell.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public virtual Type ValueType
        {
            get
            {
                if ((mobjValueType == null) && (this.OwningColumn != null))
                {
                    mobjValueType = this.OwningColumn.ValueType;
                }
                return mobjValueType as Type;
            }
            set
            {
                if (value != null || mobjValueType != null)
                {
                    mobjValueType = value;
                }
            }
        }

        /// <summary>Gets a value indicating whether the cell is in a row or column that has been hidden. </summary>
        /// <returns>true if the cell is visible; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public virtual bool Visible
        {
            get
            {
                DataGridViewRow objOwningRow = this.OwningRow;

                if (((base.DataGridView != null) && (this.RowIndex >= 0)) && (this.ColumnIndex >= 0))
                {
                    if (this.OwningColumn.Visible)
                    {
                        return objOwningRow.Visible;
                    }
                    return false;
                }
                if ((objOwningRow == null) || ((objOwningRow.DataGridView != null) && (this.RowIndex < 0)))
                {
                    return false;
                }
                return objOwningRow.Visible;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has value type.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has value type; otherwise, <c>false</c>.
        /// </value>
        internal virtual bool HasValueType
        {
            get
            {
                return (mobjValueType != null);
            }
        }

        /// <summary>
        /// Gets the bounding rectangle that encloses the cell's content area.
        /// </summary>
        /// <value>The content bounds.</value>
        [Browsable(false)]
        public Rectangle ContentBounds
        {
            get
            {
                return this.GetContentBounds(this.RowIndex);
            }
        }

        private byte CurrentMouseLocation
        {
            get
            {
                return (byte)(this.Flags & 3);
            }
            set
            {
                this.Flags = (byte)(this.Flags & -4);
                this.Flags = (byte)(this.Flags | value);
            }
        }

        private static Bitmap ErrorBitmap
        {
            get
            {
                if (mobjErrorBmp == null)
                {
                    mobjErrorBmp = GetBitmap("DataGridViewRow.error.bmp");
                }
                return mobjErrorBmp;
            }
        }

        /// <summary>
        /// Gets the bounds of the error icon for the cell.
        /// </summary>
        /// <value>The error icon bounds.</value>
        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public Rectangle ErrorIconBounds
        {
            get
            {
                return this.GetErrorIconBounds(this.RowIndex);
            }
        }

        internal bool HasErrorText
        {
            get
            {
                return (mobjErrorText != null);
            }
        }

        internal Rectangle StdBorderWidths
        {
            get
            {
                if (base.DataGridView != null)
                {
                    DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStylePlaceholder = new DataGridViewAdvancedBorderStyle();
                    DataGridViewAdvancedBorderStyle objAdvancedBorderStyle = this.AdjustCellBorderStyle(base.DataGridView.AdvancedCellBorderStyle, objDataGridViewAdvancedBorderStylePlaceholder, false, false, false, false);
                    return this.BorderWidths(objAdvancedBorderStyle);
                }
                return Rectangle.Empty;
            }
        }

        private string ToolTipTextInternal
        {
            get
            {
                if (mobjToolTipText != null)
                {
                    return (string)mobjToolTipText;
                }
                return string.Empty;
            }
            set
            {
                if (!CommonUtils.IsNullOrEmpty(value) || mobjToolTipText != null)
                {
                    mobjToolTipText = value;
                }
            }
        }

        /// <summary>Gets or sets the shortcut menu associated with the cell. </summary>
        /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with the cell.</returns>
        [DefaultValue((string)null)]
        public virtual ContextMenu ContextMenu
        {
            get
            {
                return this.GetContextMenu(this.RowIndex);
            }
            set
            {
                this.ContextMenuInternal = value;
            }
        }

        /// <summary>
        /// Gets or sets the context menu strip.
        /// </summary>
        /// <value>The context menu strip.</value>
        [DefaultValue((string)null)]
        public virtual ContextMenuStrip ContextMenuStrip
        {
            get
            {
                return this.GetContextMenuStrip(this.RowIndex);
            }
            set
            {
                this.ContextMenuStripInternal = value;
            }
        }

        /// <summary>
        /// Gets or sets the context menu strip internal.
        /// </summary>
        /// <value>The context menu strip internal.</value>
        internal ContextMenuStrip ContextMenuStripInternal
        {
            get
            {
                return mobjCellContextMenuStrip;
            }
            set
            {
                if (mobjCellContextMenuStrip != value)
                {
                    EventHandler objEventHandler = new EventHandler(this.DetachContextMenuStrip);
                    if (mobjCellContextMenuStrip != null)
                    {
                        mobjCellContextMenuStrip.Disposed -= objEventHandler;
                    }

                    mobjCellContextMenuStrip = value;

                    if (value != null)
                    {
                        value.Disposed += objEventHandler;
                    }
                    if (base.DataGridView != null)
                    {
                        base.DataGridView.OnCellContextMenuStripChanged(this);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the context menu internal.
        /// </summary>
        /// <value>The context menu internal.</value>
        private ContextMenu ContextMenuInternal
        {
            get
            {
                return mobjCellContextMenu;
            }
            set
            {
                if (mobjCellContextMenu != value)
                {
                    EventHandler objEventHandler = new EventHandler(this.DetachContextMenu);
                    if (mobjCellContextMenu != null)
                    {
                        mobjCellContextMenu.Disposed -= objEventHandler;
                    }
                    mobjCellContextMenu = value;
                    if (value != null)
                    {
                        value.Disposed += objEventHandler;
                    }
                    if (base.DataGridView != null)
                    {
                        base.DataGridView.OnCellContextMenuChanged(this);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the cell's panel.
        /// </summary>
        /// <value>The panel.</value>
        public DataGridViewCellPanel Panel
        {
            get
            {
                if (mobjPanel == null)
                {
                    if (this.DataGridView != null)
                    {
                        // Creates the cell panel.
                        mobjPanel = this.DataGridView.CreateCellPanel(this);
                    }

                    else
                    {
                        mobjPanel = new DataGridViewCellPanel(this);
                    }

                    mobjPanel.CreateControl();
                }

                return mobjPanel;
            }
            internal set
            {
                mobjPanel = value;
            }
        }


        /// <summary>
        /// Gets a value indicating whether this instance has panel.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has panel; otherwise, <c>false</c>.
        /// </value>
        protected bool HasPanel
        {
            get
            {
                return mobjPanel != null;
            }
        }

        /// <summary>
        /// Gets or sets the coll span.
        /// </summary>
        /// <value>The coll span.</value>
        public virtual int Colspan
        {
            get
            {
                return this.Panel.Colspan;
            }
            set
            {
                this.Panel.Colspan = value;
            }
        }

        /// <summary>
        /// Gets or sets the row span.
        /// </summary>
        /// <value>The row span.</value>
        public virtual int Rowspan
        {
            get
            {
                return this.Panel.Rowspan;
            }
            set
            {
                this.Panel.Rowspan = value;
            }
        }

        #endregion Properties

        #region ISkinable Members

        /// <summary>
        /// The skin of the current control
        /// </summary>
        [NonSerialized()]
        private ControlSkin mobjSkin = null;

        /// <summary>
        /// Gets the skin of the current control.
        /// </summary>
        /// <value>The skin of the current control.</value>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Browsable(false)]
        protected ControlSkin Skin
        {
            get
            {
                // If skin was not yet registered
                if (mobjSkin == null)
                {
                    // Register control for skinning
                    mobjSkin = (ControlSkin)SkinFactory.GetSkin(this);
                }
                return mobjSkin;
            }
        }

        /// <summary>
        /// Gets the theme related to the skinable component.
        /// </summary>
        /// <value>The theme related to the skinable component.</value>
        string ISkinable.Theme
        {
            get
            {
                if (this.DataGridView != null && this.DataGridView.Context != null)
                {
                    return this.DataGridView.Context.CurrentTheme;
                }
                return string.Empty;
            }
        }

        #endregion
    }

    #endregion

    #region DataGridViewTextBoxCell Class

    /// <summary>Displays editable text information in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.DataGridViewTextBoxCellSkin)), Serializable()]
    public class DataGridViewTextBoxCell : DataGridViewCell
    {
        #region Members

        #region Private Members

        private static Type mobjDefaultFormattedValueType;
        private static Type mobjDefaultValueType;
        private static Type mobjCellType;

        private int mintTextBoxCellMaxInputLength = 0x7fff;

        #endregion Private Members

        #region Constants

        private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextMarginLeft = 0;
        private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextMarginRight = 0;
        private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextOffsetLeft = 3;
        private const byte DATAGRIDVIEWTEXTBOXCELL_horizontalTextOffsetRight = 4;
        private const byte DATAGRIDVIEWTEXTBOXCELL_ignoreNextMouseClick = 1;
        private const int DATAGRIDVIEWTEXTBOXCELL_maxInputLength = 0x7fff;
        private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextMarginBottom = 1;
        private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextMarginTopWithoutWrapping = 2;
        private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextMarginTopWithWrapping = 1;
        private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextOffsetBottom = 1;
        private const byte DATAGRIDVIEWTEXTBOXCELL_verticalTextOffsetTop = 2;

        #endregion Constants

        #endregion Members

        #region C'tors / D'tors

        /// <summary>
        /// Initializes the <see cref="DataGridViewTextBoxCell"/> class.
        /// </summary>
        static DataGridViewTextBoxCell()
        {
            DataGridViewTextBoxCell.mobjDefaultFormattedValueType = typeof(string);
            DataGridViewTextBoxCell.mobjDefaultValueType = typeof(object);
            DataGridViewTextBoxCell.mobjCellType = typeof(DataGridViewTextBoxCell);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxCell"></see> class.
        /// </summary>
        public DataGridViewTextBoxCell()
        {
        }

        #endregion C'tors / D'tors

        #region Methods

        #region Events

        /// <summary>Determines if edit mode should be started based on the given key.</summary>
        /// <returns>true if edit mode should be started; otherwise, false. </returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that represents the key that was pressed.</param>
        /// <filterpriority>1</filterpriority>
        public override bool KeyEntersEditMode(KeyEventArgs e)
        {
            return false;
        }

        /// <summary>Called by <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> when the selection cursor moves onto a cell.</summary>
        /// <param name="blnThroughMouseClick">true if the cell was entered as a result of a mouse click; otherwise, false.</param>
        /// <param name="intRowIndex">The index of the row entered by the mouse.</param>
        protected override void OnEnter(int intRowIndex, bool blnThroughMouseClick)
        {
        }

        /// <summary>Called by the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> when the mouse leaves a cell.</summary>
        /// <param name="blnThroughMouseClick">true if the cell was left as a result of a mouse click; otherwise, false.</param>
        /// <param name="intRowIndex">The index of the row the mouse has left.</param>
        protected override void OnLeave(int intRowIndex, bool blnThroughMouseClick)
        {
        }

        /// <summary>Called by <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> when the mouse leaves a cell.</summary>
        /// <param name="e">An <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
        }

        /// <summary>
        /// Ownses the editing text box.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        private bool OwnsEditingTextBox(int intRowIndex)
        {
            return false;
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            objEvents.Set(WGEvents.ValueChange);

            return objEvents;
        }

        /// <summary>
        /// Gets the key event captures.
        /// </summary>
        /// <returns></returns>
        protected override KeyCaptures GetKeyEventCaptures()
        {
            KeyCaptures enmKeyCaptures = base.GetKeyEventCaptures();

            enmKeyCaptures |= KeyCaptures.RightKeyCapture;
            enmKeyCaptures |= KeyCaptures.LeftKeyCapture;
            enmKeyCaptures |= KeyCaptures.EndKeyCapture;
            enmKeyCaptures |= KeyCaptures.HomeKeyCapture;
            enmKeyCaptures |= KeyCaptures.BackspaceKeyCapture;
            enmKeyCaptures |= KeyCaptures.DeleteKeyCapture;

            return enmKeyCaptures;
        }

        /// <summary>
        /// Fires the event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        protected internal override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            switch (objEvent.Type)
            {
                case "ValueChange":
                    // Do not exept changes in read only mode
                    if (!this.ReadOnly)
                    {
                        // Set current cell's value.
                        this.SetValue(CommonUtils.DecodeText(objEvent[WGAttributes.Text]), true);
                    }
                    break;
            }
        }

        #endregion Events

        #region Render

        /// <summary>
        /// Renders the cell text/value.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objFormatedValue">The formated value.</param>
        protected override void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
        {
            base.RenderCellValue(objContext, objWriter, objFormatedValue);

            if (objFormatedValue != null && objFormatedValue.ToString() != string.Empty)
            {
                objWriter.WriteAttributeText(WGAttributes.Value, objFormatedValue.ToString());
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter, bool blnRenderOwner)
        {
            base.RenderAttributes(objContext, objWriter, blnRenderOwner);

            if (this.MaxInputLength != 0x7fff)
            {
                objWriter.WriteAttributeString(WGAttributes.MaxLength, this.MaxInputLength.ToString());
            }
        }

        /// <summary>
        /// Renders the cell style attributes.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objCellStyle">The cell style.</param>
        protected override void RenderCellStyleAttributes(IAttributeWriter objWriter, DataGridViewCellStyle objCellStyle)
        {
            base.RenderCellStyleAttributes(objWriter, objCellStyle);

            if (objCellStyle != null)
            {
                // Render Text-Align.
                objWriter.WriteAttributeString(WGAttributes.TextAlign, objCellStyle.Alignment.ToString());
            }
        }

        #endregion Render

        /// <summary>
        /// Calculates the preferred size, in pixels, of the cell.
        /// </summary>
        /// <param name="strText">The text to be measured.</param>
        /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.
        /// </returns>
        protected override Size GetPreferredSize(string strText, DataGridViewCellStyle objCellStyle)
        {
            if (string.IsNullOrEmpty(strText))
            {
                strText = " ";
            }
            return base.GetPreferredSize(strText, objCellStyle);
        }

        /// <summary>Creates an exact copy of this cell.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxCell"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override object Clone()
        {
            DataGridViewTextBoxCell objCell;
            Type objType = base.GetType();
            if (objType == DataGridViewTextBoxCell.mobjCellType)
            {
                objCell = new DataGridViewTextBoxCell();
            }
            else
            {
                objCell = (DataGridViewTextBoxCell)Activator.CreateInstance(objType);
            }
            this.CloneInternal(objCell);
            return objCell;

        }

        /// <summary>
        /// Clones TextBox Cell 
        /// </summary>
        /// <param name="objTextBoxCell">The obj text box cell.</param>
        protected void CloneInternal(DataGridViewTextBoxCell objTextBoxCell)
        {
            base.CloneInternal(objTextBoxCell);
            objTextBoxCell.MaxInputLength = this.MaxInputLength;
        }

        /// <summary>
        /// Removes the cell's editing control from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">This cell is not associated with a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditingControl"></see> property of the associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has a value of null. This is the case, for example, when the control is not in edit mode.</exception>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public override void DetachEditingControl()
        {
        }

        /// <summary>Attaches and initializes the hosted editing control.</summary>
        /// <param name="objInitialFormattedValue">The initial value to be displayed in the control.</param>
        /// <param name="intRowIndex">The index of the row being edited.</param>
        /// <param name="objDataGridViewCellStyle">A cell style that is used to determine the appearance of the hosted control.</param>
        /// <filterpriority>1</filterpriority>
        public override void InitializeEditingControl(int intRowIndex, object objInitialFormattedValue, DataGridViewCellStyle objDataGridViewCellStyle)
        {
        }

        /// <summary>
        /// Sets the location and size of the editing control hosted by a cell in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.
        /// </summary>
        /// <param name="blnSetLocation">true to have the control placed as specified by the other arguments; false to allow the control to place itself.</param>
        /// <param name="blnSetSize">true to specify the size; false to allow the control to size itself.</param>
        /// <param name="objCellBounds">A <see cref="T:System.Drawing.Rectangle"></see> that defines the cell bounds.</param>
        /// <param name="objCellClip">The area that will be used to paint the editing control.</param>
        /// <param name="objCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the style of the cell being edited.</param>
        /// <param name="blnSingleVerticalBorderAdded">true to add a vertical border to the cell; otherwise, false.</param>
        /// <param name="blnSingleHorizontalBorderAdded">true to add a horizontal border to the cell; otherwise, false.</param>
        /// <param name="blnIsFirstDisplayedColumn">true if the hosting cell is in the first visible column; otherwise, false.</param>
        /// <param name="blnIsFirstDisplayedRow">true if the hosting cell is in the first visible row; otherwise, false.</param>
        /// <exception cref="T:System.InvalidOperationException">The cell is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
        public override void PositionEditingControl(bool blnSetLocation, bool blnSetSize, Rectangle objCellBounds, Rectangle objCellClip, DataGridViewCellStyle objCellStyle, bool blnSingleVerticalBorderAdded, bool blnSingleHorizontalBorderAdded, bool blnIsFirstDisplayedColumn, bool blnIsFirstDisplayedRow)
        {
        }

        /// <summary>
        /// Returns a string that describes the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return ("DataGridViewTextBoxCell { ColumnIndex=" + base.ColumnIndex.ToString() + ", RowIndex=" + base.RowIndex.ToString() + " }");
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets a value indicating whether [support edit mode].
        /// </summary>
        /// <value><c>true</c> if [support edit mode]; otherwise, <c>false</c>.</value>
        protected override bool SupportEditMode
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [support active mode]. Whethre this cell would be redrawn with defferent skin.
        /// </summary>
        /// <value><c>true</c> if [support active mode]; otherwise, <c>false</c>.</value>
        protected override bool SupportActiveMode
        {
            get
            {
                return true;
            }
        }

        /// <summary>Gets the type of the formatted value associated with the cell.</summary>
        /// <returns>A <see cref="T:System.Type"></see> representing the <see cref="T:System.String"></see> type in all cases.</returns>
        /// <filterpriority>1</filterpriority>
        public override Type FormattedValueType
        {
            get
            {
                return DataGridViewTextBoxCell.mobjDefaultFormattedValueType;
            }
        }

        /// <summary>Gets or sets the maximum number of characters that can be entered into the text box.</summary>
        /// <returns>The maximum number of characters that can be entered into the text box; the default value is 32767.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value is less than 0.</exception>
        [DefaultValue(0x7fff)]
        public virtual int MaxInputLength
        {
            get
            {
                return mintTextBoxCellMaxInputLength;
            }
            set
            {
                if (value < 0)
                {
                    object[] arrArgs = new object[] { "MaxInputLength", value.ToString(CultureInfo.CurrentCulture), 0.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("MaxInputLength", SR.GetString("InvalidLowBoundArgumentEx", arrArgs));
                }
                mintTextBoxCellMaxInputLength = value;
            }
        }

        /// <summary>
        /// Gets or sets the data type of the values in the cell.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:System.Type"></see> representing the data type of the value in the cell.</returns>
        public override Type ValueType
        {
            get
            {
                Type objType1 = base.ValueType;
                if (objType1 != null)
                {
                    return objType1;
                }
                return DataGridViewTextBoxCell.mobjDefaultValueType;
            }
        }

        #endregion Properties

    }

    #endregion

    #region DataGridViewCheckBoxCell Class

    /// <summary>Displays a check box user interface (UI) to use in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.DataGridViewCheckBoxCellSkin)), Serializable()]
    public class DataGridViewCheckBoxCell : DataGridViewCell, IDataGridViewEditingCell
    {
        #region Members

        #region Static

        #region Private Members

        private byte mobjFlags;

        #endregion Private Members

        private static Type mobjDefaultBooleanType;
        private static Type mobjefaultCheckStateType;
        private static Type mobjCellType;

        #endregion Static

        #region Constants

        private const byte DATAGRIDVIEWCHECKBOXCELL_checked = 0x10;
        private const byte DATAGRIDVIEWCHECKBOXCELL_indeterminate = 0x20;
        private const byte DATAGRIDVIEWCHECKBOXCELL_margin = 2;
        private const byte DATAGRIDVIEWCHECKBOXCELL_threeState = 1;
        private const byte DATAGRIDVIEWCHECKBOXCELL_valueChanged = 2;

        #endregion Constants

        #endregion Members

        #region C'tors / D'tors

        /// <summary>
        /// Initializes the <see cref="DataGridViewCheckBoxCell"/> class.
        /// </summary>
        static DataGridViewCheckBoxCell()
        {
            DataGridViewCheckBoxCell.mobjefaultCheckStateType = typeof(CheckState);
            DataGridViewCheckBoxCell.mobjDefaultBooleanType = typeof(bool);
            DataGridViewCheckBoxCell.mobjCellType = typeof(DataGridViewCheckBoxCell);
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see> class to its default state.</summary>
        public DataGridViewCheckBoxCell()
        {

        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see> class, enabling binary or ternary state.</summary>
        /// <param name="blnThreeState">true to enable ternary state; false to enable binary state.</param>
        public DataGridViewCheckBoxCell(bool blnThreeState)
            : this()
        {
        }

        #endregion C'tors / D'tors

        #region Methods

        #region Events

        /// <summary>
        /// Called when the cell's contents are clicked.
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data.</param>
        protected override void OnContentClick(DataGridViewCellEventArgs e)
        {
        }

        /// <summary>
        /// Called when the cell's contents are double-clicked.
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data.</param>
        protected override void OnContentDoubleClick(DataGridViewCellEventArgs e)
        {
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();
            objEvents.Set(WGEvents.ValueChange);

            return objEvents;
        }

        /// <summary>
        /// Fires the event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        protected internal override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            switch (objEvent.Type)
            {
                case "ValueChange":
                    string strCheckState = objEvent[WGAttributes.Checked] as string;

                    if (!string.IsNullOrEmpty(strCheckState))
                    {
                        object objValue = null;

                        if (this.ThreeState)
                        {
                            switch (strCheckState)
                            {
                                case "0":
                                    objValue = CheckState.Unchecked;
                                    break;
                                case "1":
                                    objValue = CheckState.Checked;
                                    break;
                                case "2":
                                    objValue = CheckState.Indeterminate;
                                    break;
                            }
                        }
                        else
                        {
                            switch (strCheckState)
                            {
                                case "0":
                                    objValue = false;
                                    break;
                                case "1":
                                case "2":
                                    objValue = true;
                                    break;
                            }
                        }

                        // Set current cell's value.
                        this.SetValue(objValue, true);
                    }
                    break;
            }
        }

        private bool CommonContentClickUnsharesRow(DataGridViewCellEventArgs e)
        {
            return false;
        }

        /// <summary>Indicates whether the row containing the cell will be unshared when the cell content is clicked.</summary>
        /// <returns>true if the cell is in edit mode; otherwise, false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains data about the mouse click.</param>
        protected override bool ContentClickUnsharesRow(DataGridViewCellEventArgs e)
        {
            return false;
        }

        /// <summary>Indicates whether the row containing the cell will be unshared when the cell content is double-clicked.</summary>
        /// <returns>true if the cell is in edit mode; otherwise, false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains data about the double-click.</param>
        protected override bool ContentDoubleClickUnsharesRow(DataGridViewCellEventArgs e)
        {
            return false;
        }

        /// <summary>Calculates the preferred size, in pixels, of the cell.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
        /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
        /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
        /// <param name="objConstraintSize">The cell's maximum allowable size.</param>
        /// <param name="intRowIndex">The zero-based row index of the cell.</param>
        protected override Size GetPreferredSize(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex, Size objConstraintSize)
        {
            Size objPreferredSize = Size.Empty;

            // Try getting the checkbox cell skin.
            DataGridViewCheckBoxCellSkin objDataGridViewCheckBoxCellSkin = this.Skin as DataGridViewCheckBoxCellSkin;
            if (objDataGridViewCheckBoxCellSkin != null)
            {
                // Check owning datagridview.
                if (this.DataGridView != null)
                {
                    // Try getting the datagridview skin.
                    DataGridViewSkin objDataGridViewSkin = SkinFactory.GetSkin(this.DataGridView, typeof(DataGridViewSkin)) as DataGridViewSkin;
                    if (objDataGridViewSkin != null)
                    {
                        // Add padding sizes to preferred size.
                        objPreferredSize.Height = objDataGridViewSkin.CellNormalStyle.Padding.Vertical;
                        objPreferredSize.Width = objDataGridViewSkin.CellNormalStyle.Padding.Horizontal;
                    }
                }

                // Add image sizes to preferred size.
                objPreferredSize.Height += objDataGridViewCheckBoxCellSkin.CheckBoxImageHeight;
                objPreferredSize.Width += objDataGridViewCheckBoxCellSkin.CheckBoxImageWidth;
            }

            return objPreferredSize;
        }


        /// <summary>Gets the formatted value of the cell while it is in edit mode.</summary>
        /// <returns>An <see cref="T:System.Object"></see> representing the formatted value of the editing cell. </returns>
        /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values that describes the context in which any formatting error occurs. </param>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell.FormattedValueType"></see> property value is null.</exception>
        public virtual object GetEditingCellFormattedValue(DataGridViewDataErrorContexts enmContext)
        {
            if (this.FormattedValueType == null)
            {
                throw new InvalidOperationException(SR.GetString("DataGridViewCell_FormattedValueTypeNull"));
            }
            byte bytFlags = this.Flags;

            if (this.FormattedValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjefaultCheckStateType))
            {
                if ((bytFlags & 0x10) != 0)
                {
                    if ((enmContext & DataGridViewDataErrorContexts.ClipboardContent) != ((DataGridViewDataErrorContexts)0))
                    {
                        return SR.GetString("DataGridViewCheckBoxCell_ClipboardChecked");
                    }
                    return CheckState.Checked;
                }
                if ((bytFlags & 0x20) != 0)
                {
                    if ((enmContext & DataGridViewDataErrorContexts.ClipboardContent) != ((DataGridViewDataErrorContexts)0))
                    {
                        return SR.GetString("DataGridViewCheckBoxCell_ClipboardIndeterminate");
                    }
                    return CheckState.Indeterminate;
                }
                if ((enmContext & DataGridViewDataErrorContexts.ClipboardContent) != ((DataGridViewDataErrorContexts)0))
                {
                    return SR.GetString("DataGridViewCheckBoxCell_ClipboardUnchecked");
                }
                return CheckState.Unchecked;
            }
            if (!this.FormattedValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjDefaultBooleanType))
            {
                return null;
            }
            bool blnFlag1 = (bytFlags & 0x10) != 0;
            if ((enmContext & DataGridViewDataErrorContexts.ClipboardContent) != ((DataGridViewDataErrorContexts)0))
            {
                return SR.GetString(blnFlag1 ? "DataGridViewCheckBoxCell_ClipboardTrue" : "DataGridViewCheckBoxCell_ClipboardFalse");
            }
            return blnFlag1;

        }

        #endregion Events

        #region Render

        /// <summary>
        /// Renders the cell text/value.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objFormatedValue">The formated value.</param>
        protected override void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
        {
            base.RenderCellValue(objContext, objWriter, objFormatedValue);

            if (objFormatedValue != null)
            {
                string strChecked = string.Empty;

                if (this.ThreeState && objFormatedValue is CheckState)
                {
                    switch ((CheckState)objFormatedValue)
                    {
                        case CheckState.Unchecked:
                            strChecked = "0";
                            break;
                        case CheckState.Checked:
                            strChecked = "1";
                            break;
                        case CheckState.Indeterminate:
                            strChecked = "2";
                            break;
                    }
                }
                else if (objFormatedValue is bool)
                {
                    strChecked = Convert.ToBoolean(objFormatedValue) ? "1" : "0";
                }

                if (!string.IsNullOrEmpty(strChecked))
                {
                    objWriter.WriteAttributeString(WGAttributes.Checked, strChecked);
                }
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter, bool blnRenderOwner)
        {
            base.RenderAttributes(objContext, objWriter, blnRenderOwner);

            if (this.ThreeState)
            {
                objWriter.WriteAttributeString(WGAttributes.Mode, "3");
            }
        }

        /// <summary>
        /// Renders the cell style attributes.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objCellStyle">The cell style.</param>
        protected override void RenderCellStyleAttributes(IAttributeWriter objWriter, DataGridViewCellStyle objCellStyle)
        {
            base.RenderCellStyleAttributes(objWriter, objCellStyle);

            if (objCellStyle != null)
            {
                // Render content alignment.
                objWriter.WriteAttributeString(WGAttributes.ContentAlign, objCellStyle.Alignment.ToString());
            }
        }

        /// <summary>
        /// Renders the updated attributes
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderUpdatedAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            base.RenderUpdatedAttributes(objContext, objWriter, lngRequestID, blnRenderOwner);

            if (this.Value is bool)
            {
                bool blnValue = (bool)this.Value;
                objWriter.WriteAttributeString(WGAttributes.Value, !blnValue ? "1" : "0");
            }
        }

        #endregion Render

        /// <summary>Creates an exact copy of this cell.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override object Clone()
        {
            DataGridViewCheckBoxCell objCell;
            Type objType = base.GetType();
            if (objType == DataGridViewCheckBoxCell.mobjCellType)
            {
                objCell = new DataGridViewCheckBoxCell();
            }
            else
            {
                objCell = (DataGridViewCheckBoxCell)Activator.CreateInstance(objType);
            }
            base.CloneInternal(objCell);
            objCell.ThreeStateInternal = this.ThreeState;
            objCell.TrueValueInternal = this.TrueValue;
            objCell.FalseValueInternal = this.FalseValue;
            objCell.IndeterminateValueInternal = this.IndeterminateValue;
            objCell.FlatStyleInternal = this.FlatStyle;
            return objCell;

        }

        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        /// <value>The flags.</value>
        private byte Flags
        {
            get
            {
                return this.mobjFlags;
            }
            set
            {
                this.mobjFlags = value;
            }
        }

        /// <summary>Gets the formatted value of the cell's data. </summary>
        /// <returns>The value of the cell's data after formatting has been applied or null if the cell is not part of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</returns>
        /// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell.</param>
        /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values describing the context in which the formatted value is needed.</param>
        /// <param name="objValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the value type that provides custom conversion to the formatted value type, or null if no such custom conversion is needed.</param>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        /// <param name="objValue">The value to be formatted. </param>
        /// <param name="objFormattedValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the formatted value type that provides custom conversion from the value type, or null if no such custom conversion is needed.</param>
        protected override object GetFormattedValue(object objValue, int intRowIndex, ref DataGridViewCellStyle objCellStyle, TypeConverter objValueTypeConverter, TypeConverter objFormattedValueTypeConverter, DataGridViewDataErrorContexts enmContext)
        {
            if (objValue != null)
            {
                if (this.ThreeState)
                {
                    if (objValue.Equals(this.TrueValue) || ((objValue is int) && (((int)objValue) == 1)))
                    {
                        objValue = CheckState.Checked;
                    }
                    else if (objValue.Equals(this.FalseValue) || ((objValue is int) && (((int)objValue) == 0)))
                    {
                        objValue = CheckState.Unchecked;
                    }
                    else if (objValue.Equals(this.IndeterminateValue) || ((objValue is int) && (((int)objValue) == 2)))
                    {
                        objValue = CheckState.Indeterminate;
                    }
                }
                else if (objValue.Equals(this.TrueValue) || ((objValue is int) && (((int)objValue) != 0)))
                {
                    objValue = true;
                }
                else if (objValue.Equals(this.FalseValue) || ((objValue is int) && (((int)objValue) == 0)))
                {
                    objValue = false;
                }
            }
            object obj1 = base.GetFormattedValue(objValue, intRowIndex, ref objCellStyle, objValueTypeConverter, objFormattedValueTypeConverter, enmContext);
            if ((obj1 == null) || ((enmContext & DataGridViewDataErrorContexts.ClipboardContent) == ((DataGridViewDataErrorContexts)0)))
            {
                return obj1;
            }
            if (obj1 is bool)
            {
                if ((bool)obj1)
                {
                    return SR.GetString(this.ThreeState ? "DataGridViewCheckBoxCell_ClipboardChecked" : "DataGridViewCheckBoxCell_ClipboardTrue");
                }
                return SR.GetString(this.ThreeState ? "DataGridViewCheckBoxCell_ClipboardUnchecked" : "DataGridViewCheckBoxCell_ClipboardFalse");
            }
            if (!(obj1 is CheckState))
            {
                return obj1;
            }
            switch (((CheckState)obj1))
            {
                case CheckState.Checked:
                    return SR.GetString(this.ThreeState ? "DataGridViewCheckBoxCell_ClipboardChecked" : "DataGridViewCheckBoxCell_ClipboardTrue");

                case CheckState.Unchecked:
                    return SR.GetString(this.ThreeState ? "DataGridViewCheckBoxCell_ClipboardUnchecked" : "DataGridViewCheckBoxCell_ClipboardFalse");
            }
            return SR.GetString("DataGridViewCheckBoxCell_ClipboardIndeterminate");
        }

        /// <summary>Converts a value formatted for display to an actual cell value.</summary>
        /// <returns>The cell value.</returns>
        /// <param name="objFormattedValue">The display value of the cell.</param>
        /// <param name="objFormattedValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> for the display value type, or null to use the default converter.</param>
        /// <param name="objValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> for the cell value type, or null to use the default converter.</param>
        /// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell.</param>
        /// <exception cref="T:System.FormatException">The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.FormattedValueType"></see> property value is null.</exception>
        /// <exception cref="T:System.ArgumentNullException">cellStyle is null.</exception>
        /// <exception cref="T:System.ArgumentException">formattedValue is null.- or -The type of formattedValue does not match the type indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.FormattedValueType"></see> property. </exception>
        public override object ParseFormattedValue(object objFormattedValue, DataGridViewCellStyle objCellStyle, TypeConverter objFormattedValueTypeConverter, TypeConverter objValueTypeConverter)
        {
            if (objFormattedValue != null)
            {
                if (objFormattedValue is bool)
                {
                    if ((bool)objFormattedValue)
                    {
                        if (this.TrueValue != null)
                        {
                            return this.TrueValue;
                        }
                        if ((this.ValueType != null) && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjDefaultBooleanType))
                        {
                            return true;
                        }
                        if ((this.ValueType != null) && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjefaultCheckStateType))
                        {
                            return CheckState.Checked;
                        }
                    }
                    else
                    {
                        if (this.FalseValue != null)
                        {
                            return this.FalseValue;
                        }
                        if ((this.ValueType != null) && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjDefaultBooleanType))
                        {
                            return false;
                        }
                        if ((this.ValueType != null) && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjefaultCheckStateType))
                        {
                            return CheckState.Unchecked;
                        }
                    }
                }
                else if (objFormattedValue is CheckState)
                {
                    switch (((CheckState)objFormattedValue))
                    {
                        case CheckState.Unchecked:
                            if (this.FalseValue != null)
                            {
                                return this.FalseValue;
                            }
                            if ((this.ValueType != null) && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjDefaultBooleanType))
                            {
                                return false;
                            }
                            if ((this.ValueType != null) && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjefaultCheckStateType))
                            {
                                return CheckState.Unchecked;
                            }
                            break;

                        case CheckState.Checked:
                            if (this.TrueValue != null)
                            {
                                return this.TrueValue;
                            }
                            if ((this.ValueType != null) && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjDefaultBooleanType))
                            {
                                return true;
                            }
                            if ((this.ValueType != null) && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjefaultCheckStateType))
                            {
                                return CheckState.Checked;
                            }
                            break;

                        case CheckState.Indeterminate:
                            if (this.IndeterminateValue != null)
                            {
                                return this.IndeterminateValue;
                            }
                            if ((this.ValueType != null) && this.ValueType.IsAssignableFrom(DataGridViewCheckBoxCell.mobjefaultCheckStateType))
                            {
                                return CheckState.Indeterminate;
                            }
                            break;
                    }
                }
            }

            return base.ParseFormattedValue(objFormattedValue, objCellStyle, objFormattedValueTypeConverter, objValueTypeConverter);

        }

        /// <summary>This method is not meaningful for this type.</summary>
        /// <param name="blnSelectAll">This parameter is ignored.</param>
        public virtual void PrepareEditingCellForEdit(bool blnSelectAll)
        {
        }

        private bool SwitchFormattedValue()
        {
            return false;
        }

        /// <summary>Returns the string representation of the cell.</summary>
        /// <returns>A <see cref="T:System.String"></see> that represents the current cell.</returns>
        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            return ("DataGridViewCheckBoxCell { ColumnIndex=" + base.ColumnIndex.ToString() + ", RowIndex=" + base.RowIndex.ToString() + " }");
        }

        private void UpdateButtonState(ButtonState newButtonState, int intRowIndex)
        {
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets a value indicating whether [support edit mode].
        /// </summary>
        /// <value><c>true</c> if [support edit mode]; otherwise, <c>false</c>.</value>
        protected override bool SupportEditMode
        {
            get
            {
                return true;
            }
        }

        /// <summary>Gets or sets the formatted value of the control hosted by the cell when it is in edit mode.</summary>
        /// <returns>An <see cref="T:System.Object"></see> representing the cell's value.</returns>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell.FormattedValueType"></see> property value is null.</exception>
        /// <exception cref="T:System.ArgumentException">The <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell.FormattedValueType"></see> property value is null.-or-The assigned value is null or is not of the type indicated by the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell.FormattedValueType"></see> property.-or- The assigned value is not of type <see cref="T:System.Boolean"></see> nor of type <see cref="T:Gizmox.WebGUI.Forms.CheckState"></see>.</exception>
        public virtual object EditingCellFormattedValue
        {
            get
            {
                return this.GetEditingCellFormattedValue(DataGridViewDataErrorContexts.Formatting);
            }
            set
            {
                if (this.FormattedValueType == null)
                {
                    throw new ArgumentException(SR.GetString("DataGridViewCell_FormattedValueTypeNull"));
                }
                if ((value == null) || !this.FormattedValueType.IsAssignableFrom(value.GetType()))
                {
                    throw new ArgumentException(SR.GetString("DataGridViewCheckBoxCell_InvalidValueType"));
                }
                if (value is CheckState)
                {
                    if (((CheckState)value) == CheckState.Checked)
                    {
                        this.Flags = (byte)(this.Flags | 0x10);
                        this.Flags = (byte)(this.Flags & -33);
                    }
                    else if (((CheckState)value) == CheckState.Indeterminate)
                    {
                        this.Flags = (byte)(this.Flags | 0x20);
                        this.Flags = (byte)(this.Flags & -17);
                    }
                    else
                    {
                        this.Flags = (byte)(this.Flags & -17);
                        this.Flags = (byte)(this.Flags & -33);
                    }
                }
                else
                {
                    if (!(value is bool))
                    {
                        throw new ArgumentException(SR.GetString("DataGridViewCheckBoxCell_InvalidValueType"));
                    }
                    if ((bool)value)
                    {
                        this.Flags = (byte)(this.Flags | 0x10);
                    }
                    else
                    {
                        this.Flags = (byte)(this.Flags & -17);
                    }
                    this.Flags = (byte)(this.Flags & -33);
                }
            }

        }

        /// <summary>Gets or sets a flag indicating that the value has been changed for this cell.</summary>
        /// <returns>true if the cell's value has changed; otherwise, false.</returns>
        public virtual bool EditingCellValueChanged
        {
            get
            {
                return ((this.Flags & 2) != 0);
            }
            set
            {
                if (value)
                {
                    this.Flags = (byte)(this.Flags | 2);
                }
                else
                {
                    this.Flags = (byte)(this.Flags & -3);
                }
            }
        }

        /// <summary>Gets or sets the underlying value corresponding to a cell value of false.</summary>
        /// <returns>An <see cref="T:System.Object"></see> corresponding to a cell value of false. The default is null.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue((string)null)]
        public object FalseValue
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        internal object FalseValueInternal
        {
            set
            {
            }
        }

        /// <summary>Gets or sets the flat style appearance of the check box user interface (UI).</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Standard"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> value.</exception>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(2)]
        public FlatStyle FlatStyle
        {
            get
            {
                return FlatStyle.Standard;
            }
            set
            {
            }
        }

        internal FlatStyle FlatStyleInternal
        {
            set
            {
            }
        }

        /// <summary>Gets the type of the cell display value. </summary>
        /// <returns>A <see cref="T:System.Type"></see> representing the display type of the cell.</returns>
        /// <filterpriority>1</filterpriority>
        public override Type FormattedValueType
        {
            get
            {
                if (this.ThreeState)
                {
                    return mobjefaultCheckStateType;
                }
                return mobjDefaultBooleanType;
            }
        }

        /// <summary>Gets or sets the underlying value corresponding to an indeterminate or null cell value.</summary>
        /// <returns>An <see cref="T:System.Object"></see> corresponding to an indeterminate or null cell value. The default is null.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue((string)null)]
        public object IndeterminateValue
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        internal object IndeterminateValueInternal
        {
            set
            {
            }
        }

        /// <summary>Gets or sets a value indicating whether ternary mode has been enabled for the hosted check box control.</summary>
        /// <returns>true if ternary mode is enabled; false if binary mode is enabled. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(false)]
        public bool ThreeState
        {
            get
            {
                return ((this.Flags & 1) != 0);
            }
            set
            {
                if (this.ThreeState != value)
                {
                    this.ThreeStateInternal = value;
                    if (base.DataGridView != null)
                    {
                        if (base.RowIndex != -1)
                        {
                            base.DataGridView.InvalidateCell(this);
                        }
                        else
                        {
                            base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
                        }
                    }
                }
            }

        }

        internal bool ThreeStateInternal
        {
            set
            {
                if (this.ThreeState != value)
                {
                    if (value)
                    {
                        this.Flags = (byte)(this.Flags | 1);
                    }
                    else
                    {
                        this.Flags = (byte)(this.Flags & -2);
                    }
                }
            }
        }

        /// <summary>Gets or sets the underlying value corresponding to a cell value of true.</summary>
        /// <returns>An <see cref="T:System.Object"></see> corresponding to a cell value of true. The default is null.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue((string)null)]
        public object TrueValue
        {
            get
            {
                return null;
            }
            set
            {
            }
        }

        internal object TrueValueInternal
        {
            set
            {
            }
        }

        /// <summary>Gets the data type of the values in the cell.</summary>
        /// <returns>The <see cref="T:System.Type"></see> of the underlying value of the cell.</returns>
        /// <filterpriority>1</filterpriority>
        public override Type ValueType
        {
            get
            {
                Type objType1 = base.ValueType;
                if (objType1 != null)
                {
                    return objType1;
                }
                if (this.ThreeState)
                {
                    return DataGridViewCheckBoxCell.mobjefaultCheckStateType;
                }
                return DataGridViewCheckBoxCell.mobjDefaultBooleanType;
            }
            set
            {
                base.ValueType = value;
                this.ThreeState = (value != null) && DataGridViewCheckBoxCell.mobjefaultCheckStateType.IsAssignableFrom(value);
            }

        }

        #endregion Properties

    }

    #endregion

    #region DataGridViewComboBoxCell Class

    /// <summary>Displays a combo box in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.DataGridViewComboBoxCellSkin)), Serializable()]
    public class DataGridViewComboBoxCell : DataGridViewCell
    {

        #region Members

        #region Static

        #region Private Members

        private byte mobjFlags = 8;
        private static Type mobjDefaultEditType;
        private static Type mobjDefaultFormattedValueType;
        private static Type mobjDefaultValueType;
        private static Type mobjCellType = typeof(DataGridViewComboBoxCell);
        [NonSerialized()]
        private PropertyDescriptor mobjValueMember = null;
        private object mobjInternalValueMember = null;
        private int mintMaxDropDownItems = 8;
        private ObjectCollection mobjItems = null;
        private FlatStyle menmFlatStyle = FlatStyle.Standard;
        private int mintDropDownWidth = 1;
        private int mintDisplayStyleForCurrentCellOnly = -1;
        private object mobjInternalDisplayMember = null;
        [NonSerialized()]
        private PropertyDescriptor mobjDisplayMember = null;
        private object mobjDataSource = null;
        private object mobjDataManager = null;
        private DataGridViewComboBoxEditingControl menmComboBoxCellEditingComboBox = null;
        private DataGridViewComboBoxColumn mobjTemplateComboBoxColumn;
        private ComboBoxStyle menmDropDownStyle = ComboBoxStyle.DropDownList;

        #endregion Private Members

        #endregion Static

        private static bool mblnMouseInDropDownButtonBounds = false;
        private static int mintCachedDropDownWidth = -1;

        #region Constants

        private const byte DATAGRIDVIEWCOMBOBOXCELL_autoComplete = 8;
        private const byte DATAGRIDVIEWCOMBOBOXCELL_createItemsFromDataSource = 4;
        private const byte DATAGRIDVIEWCOMBOBOXCELL_dataSourceInitializedHookedUp = 0x10;
        internal const int DATAGRIDVIEWCOMBOBOXCELL_defaultMaxDropDownItems = 8;
        private const byte DATAGRIDVIEWCOMBOBOXCELL_dropDownHookedUp = 0x20;
        private const byte DATAGRIDVIEWCOMBOBOXCELL_horizontalTextMarginLeft = 0;
        private const byte DATAGRIDVIEWCOMBOBOXCELL_ignoreNextMouseClick = 1;
        private const byte DATAGRIDVIEWCOMBOBOXCELL_margin = 3;
        private const byte DATAGRIDVIEWCOMBOBOXCELL_nonXPTriangleHeight = 4;
        private const byte DATAGRIDVIEWCOMBOBOXCELL_nonXPTriangleWidth = 7;
        private const byte DATAGRIDVIEWCOMBOBOXCELL_sorted = 2;
        private const byte DATAGRIDVIEWCOMBOBOXCELL_verticalTextMarginTopWithoutWrapping = 1;
        private const byte DATAGRIDVIEWCOMBOBOXCELL_verticalTextMarginTopWithWrapping = 0;

        #endregion Constants

        #endregion Members

        #region C'tors / D'tors

        /// <summary>
        /// Initializes the <see cref="DataGridViewComboBoxCell"/> class.
        /// </summary>
        static DataGridViewComboBoxCell()
        {
            mobjDefaultFormattedValueType = typeof(string);
            mobjDefaultEditType = typeof(DataGridViewComboBoxEditingControl);
            mobjDefaultValueType = typeof(object);
            mobjCellType = typeof(DataGridViewComboBoxCell);
            mblnMouseInDropDownButtonBounds = false;
            mintCachedDropDownWidth = -1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see> class.
        /// </summary>
        public DataGridViewComboBoxCell()
        {
        }

        #endregion C'tors / D'tors

        #region Methods

        #region Events

        /// <summary>Called when the <see cref="P:System.Windows.Forms.DataGridViewElement.DataGridView"></see> property of the cell changes.</summary>
        /// <exception cref="T:System.ArgumentException">The <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DataSource"></see> property is not null and the value of either the <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DisplayMember"></see> property or the <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.ValueMember"></see> property is not null or <see cref="F:System.String.Empty"></see> and does not name a valid property or column in the data source.</exception>
        protected override void OnDataGridViewChanged()
        {
            if (base.DataGridView != null)
            {
                this.InitializeDisplayMemberPropertyDescriptor(this.DisplayMember);
                this.InitializeValueMemberPropertyDescriptor(this.ValueMember);
            }
            base.OnDataGridViewChanged();
        }

        /// <summary>
        /// Called when the focus moves to a cell.
        /// </summary>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        /// <param name="blnThroughMouseClick">true if a user action moved focus to the cell; false if a programmatic operation moved focus to the cell.</param>
        protected override void OnEnter(int intRowIndex, bool blnThroughMouseClick)
        {
            if ((base.DataGridView != null) && (blnThroughMouseClick && (base.DataGridView.EditMode != DataGridViewEditMode.EditOnEnter)))
            {
                this.Flags = (byte)(this.Flags | 1);
            }
        }

        /// <summary>
        /// Called when [items collection changed].
        /// </summary>
        private void OnItemsCollectionChanged()
        {
            if (this.TemplateComboBoxColumn != null)
            {
                this.TemplateComboBoxColumn.OnItemsCollectionChanged();
            }
            mintCachedDropDownWidth = -1;
            if (this.OwnsEditingComboBox(base.RowIndex))
            {
                this.InitializeComboBoxText();
            }
            else
            {
                base.OnCommonChange();
            }
        }

        /// <summary>
        /// Called when the focus moves from a cell.
        /// </summary>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        /// <param name="blnThroughMouseClick">true if a user action moved focus from the cell; false if a programmatic operation moved focus from the cell.</param>
        protected override void OnLeave(int intRowIndex, bool blnThroughMouseClick)
        {
            if (base.DataGridView != null)
            {
                this.Flags = (byte)(this.Flags & -2);
            }
        }

        /// <summary>Determines if edit mode should be started based on the given key.</summary>
        /// <returns>true if edit mode should be started; otherwise, false. </returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that represents the key that was pressed.</param>
        /// <filterpriority>1</filterpriority>
        public override bool KeyEntersEditMode(KeyEventArgs e)
        {
            return false;
        }

        /// <summary>
        /// Called when the user clicks a mouse button while the pointer is on a cell.
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseClick(DataGridViewCellMouseEventArgs e)
        {
        }

        /// <summary>
        /// Called when the mouse pointer moves over a cell.
        /// </summary>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        protected override void OnMouseEnter(int intRowIndex)
        {
            if (base.DataGridView != null)
            {
                if ((this.DisplayStyle == DataGridViewComboBoxDisplayStyle.ComboBox) && (this.FlatStyle == FlatStyle.Popup))
                {
                    base.DataGridView.InvalidateCell(base.ColumnIndex, intRowIndex);
                }
                base.OnMouseEnter(intRowIndex);
            }
        }

        /// <summary>
        /// Called when the mouse pointer leaves the cell.
        /// </summary>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        protected override void OnMouseLeave(int intRowIndex)
        {
        }

        /// <summary>
        /// Called when the mouse pointer moves within a cell.
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains the event data.</param>
        protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
        {
        }

        /// <summary>
        /// Ownses the editing combo box.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        private bool OwnsEditingComboBox(int intRowIndex)
        {
            return false;
        }

        /// <summary>
        /// Handles the DropDown event of the ComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ComboBox_DropDown(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the Disposed event of the DataSource control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DataSource_Disposed(object sender, EventArgs e)
        {
            this.DataSource = null;
        }

        /// <summary>
        /// Handles the Initialized event of the DataSource control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DataSource_Initialized(object sender, EventArgs e)
        {
            ISupportInitializeNotification dataSource = this.DataSource as ISupportInitializeNotification;
            if (dataSource != null)
            {
                dataSource.Initialized -= new EventHandler(this.DataSource_Initialized);
            }
            this.Flags = (byte)(this.Flags & -17);
            this.InitializeDisplayMemberPropertyDescriptor(this.DisplayMember);
            this.InitializeValueMemberPropertyDescriptor(this.ValueMember);
        }

        /// <summary>
        /// Fires the event.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        protected internal override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            switch (objEvent.Type)
            {
                case "ValueChange":
                    if (objEvent.Contains(WGAttributes.Value))
                    {
                        int intIndex = Convert.ToInt32(objEvent[WGAttributes.Value]);

                        if (intIndex >= 0 && intIndex < this.Items.Count)
                        {
                            // Set current cell's value.
                            object objItem = this.Items[intIndex];
                            string strDisplayValue = GetItemDisplayText(objItem);
                            this.SetValue(strDisplayValue, true);
                        }
                    }
                    break;

                case "TextChange":
                    if (objEvent.Contains(WGAttributes.Value))
                    {
                        // Validate text value.
                        string strText = CommonUtils.DecodeText(objEvent[WGAttributes.Value]);
                        if (!string.IsNullOrEmpty(strText))
                        {
                            // Set current cell's value.
                            this.SetValue(strText, true);
                        }
                    }
                    break;

                case "DropDownWindow":
                    Form objDropDown = this.GetCustomDropDown();
                    if (objDropDown != null)
                    {
                        objDropDown.ShowPopup(this.DataGridView, this, DialogAlignment.Below);
                    }
                    break;
            }
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            objEvents.Set(WGEvents.ValueChange);

            return objEvents;
        }

        /// <summary>
        /// Gets the key event captures.
        /// </summary>
        /// <returns></returns>
        protected override KeyCaptures GetKeyEventCaptures()
        {
            KeyCaptures enmKeyCaptures = base.GetKeyEventCaptures();

            enmKeyCaptures |= KeyCaptures.UpKeyCapture;
            enmKeyCaptures |= KeyCaptures.DownKeyCapture;
            enmKeyCaptures |= KeyCaptures.LeftKeyCapture;
            enmKeyCaptures |= KeyCaptures.RightKeyCapture;
            enmKeyCaptures |= KeyCaptures.EndKeyCapture;
            enmKeyCaptures |= KeyCaptures.HomeKeyCapture;
            enmKeyCaptures |= KeyCaptures.PageDownKeyCapture;
            enmKeyCaptures |= KeyCaptures.PageUpKeyCapture;
            enmKeyCaptures |= KeyCaptures.EnterKeyCapture;

            return enmKeyCaptures;
        }

        #endregion Events

        #region Render

        /// <summary>
        /// Renders the animation.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        private void RenderAnimationAttributes(IAttributeWriter objWriter)
        {
            if (this.DataGridView != null)
            {
                // Indicates if to render animation support
                if (this.DataGridView.DefaultAnimationEnabled)
                {
                    objWriter.WriteAttributeString(WGAttributes.Animation, "1");
                }
            }
        }

        /// <summary>
        /// Renders the cell style attributes.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objCellStyle">The cell style.</param>
        protected override void RenderCellStyleAttributes(IAttributeWriter objWriter, DataGridViewCellStyle objCellStyle)
        {
            base.RenderCellStyleAttributes(objWriter, objCellStyle);

            if (objCellStyle != null)
            {
                // Render Text-Align.
                objWriter.WriteAttributeString(WGAttributes.TextAlign, objCellStyle.Alignment.ToString());
            }
        }

        /// <summary>
        /// Renders the cell text/value.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objFormatedValue">The formated value.</param>
        protected override void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
        {
            base.RenderCellValue(objContext, objWriter, objFormatedValue);

            object objItem = null;

            object objValue = this.Value;

            //if the value exist
            if (objValue != null && objValue.ToString() != string.Empty)
            {
                //Get the current item
                objItem = GetComboBoxItem(objValue);
                if (objItem != null)
                {
                    //Get the index of the selected item
                    int intValue = this.Items.IndexOf(objItem);

                    //render the value
                    objWriter.WriteAttributeString(WGAttributes.Value, intValue.ToString());
                    
                    //render the formatted text
                    objWriter.WriteAttributeString(WGAttributes.FormattedText, objFormatedValue.ToString());
                }
            }
        }

        /// <summary>
        /// Render the control Attributes
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter, bool blnRenderOwner)
        {
            base.RenderAttributes(objContext, objWriter, blnRenderOwner);

            // Render to restrain valueChange fire event in case of navigation keys.
            objWriter.WriteAttributeString(WGAttributes.CancelSelectOnDropDownNaviagation, "1");

            // Render to disable auto complete in combo.
            objWriter.WriteAttributeString(WGAttributes.SupportKeydownAccumulating, "0");

            // Render the maximum items attribute.
            objWriter.WriteAttributeString(WGAttributes.Maximum, Math.Min(this.MaxDropDownItems, this.Items.Count).ToString());

            // Set drop-down-width 
            if (this.DropDownWidth != 1)
            {
                objWriter.WriteAttributeString(WGAttributes.DropDownWidth, this.DropDownWidth.ToString());
            }

            // Set auto complete mode attribute.
            objWriter.WriteAttributeString(WGAttributes.AutoCompleteMode, this.AutoComplete ? "S" : "N");
            objWriter.WriteAttributeString(WGAttributes.IsAutoComplete, this.AutoComplete ? "1" : "0");

            if (this.IsCustomDropDown)
            {
                objWriter.WriteAttributeString(WGAttributes.CustomDropDown, "1");

                RenderCustomComboboxTextValue(objWriter);
            }

            switch (this.DropDownStyle)
            {
                case ComboBoxStyle.DropDown:
                    objWriter.WriteAttributeString(WGAttributes.Style, "DD");
                    break;
                case ComboBoxStyle.DropDownList:
                    objWriter.WriteAttributeString(WGAttributes.Style, "DDL");
                    break;
                case ComboBoxStyle.Simple:
                    objWriter.WriteAttributeString(WGAttributes.Style, "S");
                    break;
            }

            // Render control id.
            objWriter.WriteAttributeString(WGAttributes.Id, string.Format("{0}_{1}", this.DataGridView.GetProxyPropertyValue<long>("ID", this.DataGridView.ID).ToString(), this.MemberID));

            // In case that current cell does not have any local items and its owning column has items.
            if (!this.SholudRenderComboboxItems && this.OwningColumnHasItems)
            {
                objWriter.WriteAttributeString(WGAttributes.OptionsComponent, string.Format("{0}_{1}", this.DataGridView.GetProxyPropertyValue<long>("ID", this.DataGridView.ID).ToString(), this.DataGridView.Columns[this.ColumnIndex].MemberIDInternal));
            }

            //Render combo box item height
            objWriter.WriteAttributeString(WGAttributes.ItemHeight, this.GetPreferdItemHeight().ToString());

            // Render animation support
            RenderAnimationAttributes(objWriter);
        }

        /// <summary>
        /// Renders the custom combobox text value.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        protected virtual void RenderCustomComboboxTextValue(IAttributeWriter objWriter)
        {
            if (this.Value != null)
            {
                objWriter.WriteAttributeText(WGAttributes.Text, this.Value.ToString());
            }
        }

        /// <summary>
        /// Gets the text from value.
        /// </summary>
        /// <param name="objValue">The obj value.</param>
        /// <returns></returns>
        protected virtual string GetRenderedTextFromValue(object objValue)
        {
            return this.Value.ToString();
        }

        /// <summary>
        /// Renders the combobox items.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        public void RenderComboboxItems(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            if (IsDirty(lngRequestID))
            {
                // Check if local combobox items sholud be rendered.
                if (this.SholudRenderComboboxItems)
                {
                    // Get local items collection.
                    ObjectCollection objItems = this.Items;

                    // If local items collection is null - try retrieving it.
                    if (objItems == null &&
                        this.TemplateComboBoxColumn != null)
                    {
                        objItems = this.GetItems(this.TemplateComboBoxColumn.DataGridView);
                    }

                    // Start the options tag.
                    objWriter.WriteStartElement(WGTags.Options);

                    // Render the IsDelayedDrawing attribute.
                    objWriter.WriteAttributeString(WGAttributes.IsDelayedDrawing, "0");

                    // Loops all items.
                    for (int intIndex = 0; intIndex < objItems.Count; intIndex++)
                    {
                        // Write openning Option element.
                        objWriter.WriteStartElement(WGTags.Option);
                        objWriter.WriteAttributeString(WGAttributes.Index, intIndex.ToString());

                        // Get current item as object.
                        object objObject = objItems[intIndex];

                        //Get the disply text
                        string strItemText = GetItemDisplayText(objObject);

                        //set the text attribute
                        objWriter.WriteAttributeText(WGAttributes.Text, strItemText, TextFilter.NewLine | TextFilter.CarriageReturn);

                        objWriter.WriteEndElement();
                    }

                    // Write ending Option element.
                    objWriter.WriteEndElement();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderComponents(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            base.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);

            // Render combobox items.
            RenderComboboxItems(objContext, objWriter, lngRequestID, blnRenderOwner);
        }

        #endregion Render

        /// <summary>
        /// Gets the custom form to display as drop down
        /// </summary>
        /// <returns></returns>
        protected virtual Form GetCustomDropDown()
        {
            return null;
        }

        /// <summary>
        /// Checks the drop down list.
        /// </summary>
        /// <param name="intX">The x.</param>
        /// <param name="intY">The y.</param>
        /// <param name="intRowIndex">Index of the row.</param>
        private void CheckDropDownList(int intX, int intY, int intRowIndex)
        {
        }

        /// <summary>
        /// Checks the no data source.
        /// </summary>
        private void CheckNoDataSource()
        {
            if (this.DataSource != null)
            {
                throw new ArgumentException(SR.GetString("DataSourceLocksItems"));
            }
        }

        /// <summary>
        /// Gets the height of the preferd item font.        
        /// </summary>
        /// <returns></returns>
        internal int GetPreferdItemHeight()
        {
            //Get the current skin
            ComboBoxSkin objComboBoxSkin = this.Skin as ComboBoxSkin;

            //If skin exists
            if (objComboBoxSkin != null)
            {
                // Get the arrow icon padding value
                PaddingValue objPaddingValue = (objComboBoxSkin.PopupItemStyle).Padding as PaddingValue;

                //Set the default padding
                int intPaddingOffset = 0;

                //If we go an objPaddingValue sum the offset height of the item
                if (objPaddingValue != null)
                {
                    intPaddingOffset = objPaddingValue.Top + objPaddingValue.Bottom;
                }

                // Get font from skin.
                Font objCellFont = objComboBoxSkin.Font;

                // Validate formatted style.
                if (this.FormattedCellStyle != null)
                {
                    // Validate formatted font.
                    Font objFormattedFont = this.FormattedCellStyle.Font;
                    if (objFormattedFont != null)
                    {
                        objCellFont = objFormattedFont;
                    }
                }

                //Return the calculated max height
                return CommonUtils.GetFontHeight(objCellFont) + intPaddingOffset;
            }
            return 0;
        }
        /// <summary>
        /// Determines whether [is collections equals] [the specified obj collection1].
        /// </summary>
        /// <param name="objCollection1">The obj collection1.</param>
        /// <param name="objCollection2">The obj collection2.</param>
        /// <returns>
        /// 	<c>true</c> if [is collections equals] [the specified obj collection1]; otherwise, <c>false</c>.
        /// </returns>
        protected bool CollectionsEquals(ObjectCollection objCollection1, ObjectCollection objCollection2)
        {
            bool blnCollectionsEquals = ((objCollection1 == null && objCollection2 == null) || (objCollection1 != null && objCollection2 != null));

            if (blnCollectionsEquals &&
                objCollection1 != null)
            {
                blnCollectionsEquals = (objCollection1.Count == objCollection2.Count);

                if (blnCollectionsEquals)
                {
                    foreach (object objItem in objCollection1)
                    {
                        if (!objCollection2.Contains(objItem))
                        {
                            blnCollectionsEquals = false;
                            break;
                        }
                    }
                }
            }

            return blnCollectionsEquals;
        }

        /// <summary>Calculates the preferred size, in pixels, of the cell.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
        /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
        /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
        /// <param name="objConstraintSize">The cell's maximum allowable size.</param>
        /// <param name="intRowIndex">The zero-based row index of the cell.</param>
        protected override Size GetPreferredSize(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex, Size objConstraintSize)
        {
            string strText = Convert.ToString(this.GetValue(intRowIndex));
            // Try get current cell's value. Will throw exception on certain scenario for headers where grid is being disposed, catch it and use retrieved value
            try
            {
                if (this.Value != null)
                {
                    strText = this.GetFormattedValue(this.Value, this.RowIndex, ref objCellStyle, null, null, new DataGridViewDataErrorContexts()).ToString();
                }
            }
            catch (Exception ex)
            {
            }

            if (string.IsNullOrEmpty(strText))
            {
                strText = " ";
            }

            Size objSize = base.GetPreferredSize(strText, objCellStyle);
            return new Size(Math.Max(objSize.Width, 16), objSize.Height);
        }

        /// <summary>Creates an exact copy of this cell.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override object Clone()
        {
            DataGridViewComboBoxCell objCell;
            Type objType = base.GetType();
            if (objType == DataGridViewComboBoxCell.mobjCellType)
            {
                objCell = new DataGridViewComboBoxCell();
            }
            else
            {
                objCell = (DataGridViewComboBoxCell)Activator.CreateInstance(objType);
            }
            base.CloneInternal(objCell);
            objCell.DropDownWidth = this.DropDownWidth;
            objCell.DropDownStyle = this.DropDownStyle;
            objCell.MaxDropDownItems = this.MaxDropDownItems;
            objCell.CreateItemsFromDataSource = false;
            objCell.DataSource = this.DataSource;
            objCell.DisplayMember = this.DisplayMember;
            objCell.ValueMember = this.ValueMember;
            if ((this.HasItems && (this.DataSource == null)) && (this.Items.Count > 0))
            {
                objCell.Items.AddRangeInternal(this.Items.InnerArray.ToArray());
            }
            objCell.AutoComplete = this.AutoComplete;
            objCell.Sorted = this.Sorted;
            objCell.FlatStyleInternal = this.FlatStyle;
            objCell.DisplayStyleInternal = this.DisplayStyle;
            objCell.DisplayStyleForCurrentCellOnlyInternal = this.DisplayStyleForCurrentCellOnly;
            return objCell;

        }

        /// <summary>
        /// Removes the cell's editing control from the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.
        /// </summary>
        /// <exception cref="T:System.InvalidOperationException">This cell is not associated with a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-The <see cref="P:Gizmox.WebGUI.Forms.DataGridView.EditingControl"></see> property of the associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> has a value of null. This is the case, for example, when the control is not in edit mode.</exception>
        public override void DetachEditingControl()
        {
        }

        private CurrencyManager GetDataManager(DataGridView objDataGridView)
        {
            CurrencyManager manager = (CurrencyManager)mobjDataManager;
            if ((((manager == null) && (this.DataSource != null)) && ((objDataGridView != null) && (objDataGridView.BindingContext != null))) && (this.DataSource != Convert.DBNull))
            {
                ISupportInitializeNotification dataSource = this.DataSource as ISupportInitializeNotification;
                if (dataSource != null && !dataSource.IsInitialized)
                {
                    if ((this.Flags & 0x10) == 0)
                    {
                        dataSource.Initialized += new EventHandler(this.DataSource_Initialized);
                        this.Flags = (byte)(this.Flags | 0x10);
                    }
                    return manager;
                }
                manager = (CurrencyManager)objDataGridView.BindingContext[this.DataSource];
                this.DataManager = manager;
            }
            return manager;
        }

        /// <summary>
        /// Gets the height of the drop down button.
        /// </summary>
        /// <param name="objGraphics">The graphics.</param>
        /// <param name="objCellStyle">The cell style.</param>
        /// <returns></returns>
        private int GetDropDownButtonHeight(Graphics objGraphics, DataGridViewCellStyle objCellStyle)
        {
            return -1;
        }

        /// <summary>
        /// Gets the formatted value of the cell's data.
        /// </summary>
        /// <param name="objValue">The value to be formatted.</param>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        /// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell.</param>
        /// <param name="objValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the value type that provides custom conversion to the formatted value type, or null if no such custom conversion is needed.</param>
        /// <param name="objFormattedValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the formatted value type that provides custom conversion from the value type, or null if no such custom conversion is needed.</param>
        /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values describing the context in which the formatted value is needed.</param>
        /// <returns>
        /// The value of the cell's data after formatting has been applied or null if the cell is not part of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.
        /// </returns>
        /// <exception cref="T:System.Exception">Formatting failed and either there is no handler for the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control or the handler set the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs.ThrowException"></see> property to true. The exception object can typically be cast to type <see cref="T:System.FormatException"></see> for type conversion errors or to type <see cref="T:System.ArgumentException"></see> if value cannot be found in the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> or the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.Items"></see> collection. </exception>
        protected override object GetFormattedValue(object objValue, int intRowIndex, ref DataGridViewCellStyle objCellStyle, TypeConverter objValueTypeConverter, TypeConverter objFormattedValueTypeConverter, DataGridViewDataErrorContexts enmContext)
        {
            if (objValueTypeConverter == null)
            {
                if (this.ValueMemberProperty != null)
                {
                    objValueTypeConverter = this.ValueMemberProperty.Converter;
                }
                else if (this.DisplayMemberProperty != null)
                {
                    objValueTypeConverter = this.DisplayMemberProperty.Converter;
                }
            }
            if ((objValue == null) || (((this.ValueType != null) && !this.ValueType.IsAssignableFrom(objValue.GetType())) && (objValue != DBNull.Value)))
            {
                if (objValue == null)
                {
                    return base.GetFormattedValue(null, intRowIndex, ref objCellStyle, objValueTypeConverter, objFormattedValueTypeConverter, enmContext);
                }
                if (base.DataGridView != null)
                {
                    DataGridViewDataErrorEventArgs e = new DataGridViewDataErrorEventArgs(new FormatException(SR.GetString("DataGridViewComboBoxCell_InvalidValue")), base.ColumnIndex, intRowIndex, enmContext);
                    base.RaiseDataError(e);
                    if (e.ThrowException)
                    {
                        throw e.Exception;
                    }
                }
                return base.GetFormattedValue(objValue, intRowIndex, ref objCellStyle, objValueTypeConverter, objFormattedValueTypeConverter, enmContext);
            }
            string str = objValue as string;
            if (((this.DataManager != null) && ((this.ValueMemberProperty != null) || (this.DisplayMemberProperty != null))) || (!string.IsNullOrEmpty(this.ValueMember) || !string.IsNullOrEmpty(this.DisplayMember)))
            {
                object obj2;
                if (!this.LookupDisplayValue(intRowIndex, objValue, out obj2))
                {
                    if (objValue == DBNull.Value)
                    {
                        obj2 = DBNull.Value;
                    }
                    else if (((str != null) && string.IsNullOrEmpty(str)) && (this.DisplayType == typeof(string)))
                    {
                        obj2 = string.Empty;
                    }
                    else if (base.DataGridView != null)
                    {
                        DataGridViewDataErrorEventArgs args2 = new DataGridViewDataErrorEventArgs(new ArgumentException(SR.GetString("DataGridViewComboBoxCell_InvalidValue")), base.ColumnIndex, intRowIndex, enmContext);
                        base.RaiseDataError(args2);
                        if (args2.ThrowException)
                        {
                            throw args2.Exception;
                        }
                        if (this.OwnsEditingComboBox(intRowIndex))
                        {
                            base.DataGridView.NotifyCurrentCellDirty(true);
                        }
                    }
                }
                return base.GetFormattedValue(obj2, intRowIndex, ref objCellStyle, this.DisplayTypeConverter, objFormattedValueTypeConverter, enmContext);
            }
            if ((!this.Items.Contains(objValue) && (objValue != DBNull.Value)) && (!(objValue is string) || !string.IsNullOrEmpty(str)) && !this.IsCustomDropDown)
            {
                if (base.DataGridView != null)
                {
                    DataGridViewDataErrorEventArgs args3 = new DataGridViewDataErrorEventArgs(new ArgumentException(SR.GetString("DataGridViewComboBoxCell_InvalidValue")), base.ColumnIndex, intRowIndex, enmContext);
                    base.RaiseDataError(args3);
                    if (args3.ThrowException)
                    {
                        throw args3.Exception;
                    }
                }
                if (this.Items.Count > 0)
                {
                    objValue = this.Items[0];
                }
                else
                {
                    objValue = string.Empty;
                }
            }
            return base.GetFormattedValue(objValue, intRowIndex, ref objCellStyle, objValueTypeConverter, objFormattedValueTypeConverter, enmContext);
        }

        /// <summary>
        /// Lookups the display value.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <param name="objValue">The value.</param>
        /// <param name="objDisplayValue">The display value.</param>
        /// <returns></returns>
        private bool LookupDisplayValue(int intRowIndex, object objValue, out object objDisplayValue)
        {
            object objItem = null;
            if ((this.DisplayMemberProperty != null) || (this.ValueMemberProperty != null))
            {
                objItem = this.ItemFromComboBoxDataSource((this.ValueMemberProperty != null) ? this.ValueMemberProperty : this.DisplayMemberProperty, objValue);
            }
            else
            {
                objItem = this.ItemFromComboBoxItems(intRowIndex, string.IsNullOrEmpty(this.ValueMember) ? this.DisplayMember : this.ValueMember, objValue);
            }


            if (objItem == null)
            {
                objDisplayValue = null;
                return false;
            }
            objDisplayValue = this.GetItemDisplayValue(objItem);
            return true;
        }

        /// <summary>
        /// Gets the item display text.
        /// </summary>
        /// <param name="objItem">The item.</param>
        /// <returns></returns>
        internal string GetItemDisplayText(object objItem)
        {
            object objItemDisplayValue = this.GetItemDisplayValue(objItem);
            if (objItemDisplayValue == null)
            {
                return string.Empty;
            }
            return Convert.ToString(objItemDisplayValue, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Gets the item display value.
        /// </summary>
        /// <param name="objItem">The item.</param>
        /// <returns></returns>
        internal object GetItemDisplayValue(object objItem)
        {
            bool blnFlag = false;
            object obj2 = null;
            if (this.DisplayMemberProperty != null)
            {
                obj2 = this.DisplayMemberProperty.GetValue(objItem);
                blnFlag = true;
            }
            else if (this.ValueMemberProperty != null)
            {
                obj2 = this.ValueMemberProperty.GetValue(objItem);
                blnFlag = true;
            }
            else if (!Gizmox.WebGUI.CommonUtils.IsNullOrEmpty(this.DisplayMember))
            {
                PropertyDescriptor objPropertyDescriptor = TypeDescriptor.GetProperties(objItem).Find(this.DisplayMember, true);
                if (objPropertyDescriptor != null)
                {
                    obj2 = objPropertyDescriptor.GetValue(objItem);
                    blnFlag = true;
                }
            }
            else if (!Gizmox.WebGUI.CommonUtils.IsNullOrEmpty(this.ValueMember))
            {
                PropertyDescriptor objPropertyDescriptor2 = TypeDescriptor.GetProperties(objItem).Find(this.ValueMember, true);
                if (objPropertyDescriptor2 != null)
                {
                    obj2 = objPropertyDescriptor2.GetValue(objItem);
                    blnFlag = true;
                }
            }
            if (!blnFlag)
            {
                obj2 = objItem;
            }
            return obj2;
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <param name="objDataGridView">The data grid view.</param>
        /// <returns></returns>
        internal ObjectCollection GetItems(DataGridView objDataGridView)
        {
            ObjectCollection objItems = this.LocalItems;

            if (objItems == null)
            {
                objItems = CreateObjectCollection();
                this.LocalItems = objItems;
            }

            if (this.CreateItemsFromDataSource)
            {
                objItems.ClearInternal();
                CurrencyManager dataManager = this.GetDataManager(objDataGridView);
                if ((dataManager != null) && (dataManager.Count != -1))
                {
                    object[] arrItems = new object[dataManager.Count];
                    for (int i = 0; i < arrItems.Length; i++)
                    {
                        arrItems[i] = dataManager[i];
                    }
                    objItems.AddRangeInternal(arrItems);
                }
                if ((dataManager == null) && ((this.Flags & 0x10) != 0))
                {
                    return objItems;
                }
                this.CreateItemsFromDataSource = false;
            }
            return objItems;
        }

        /// <summary>
        /// Creates the object collection.
        /// </summary>
        /// <returns></returns>
        protected virtual ObjectCollection CreateObjectCollection()
        {
            return new ObjectCollection(this);
        }

        /// <summary>
        /// Gets the combo box item.
        /// </summary>
        /// <param name="objValue">The obj value.</param>
        /// <returns></returns>
        private object GetComboBoxItem(object objValue)
        {
            object objComboBoxItem = null;

            // Check if value member property exist.
            if (this.ValueMemberProperty != null)
            {
                // Get combobo box item as for value member property.
                objComboBoxItem = this.ItemFromComboBoxDataSource(this.ValueMemberProperty, objValue);
            }
            // Check if display member property exist.
            else if (this.DisplayMemberProperty != null)
            {
                // Get combobo box item as for display member property.
                objComboBoxItem = this.ItemFromComboBoxDataSource(this.DisplayMemberProperty, objValue);
            }
            else
            {
                // Check if value member exist.
                if (!string.IsNullOrEmpty(this.ValueMember))
                {
                    // Get combobo box item as for value member.
                    objComboBoxItem = this.ItemFromComboBoxItems(this.RowIndex, this.ValueMember, objValue);
                }

                // Check if combobox item was not found.
                if (objComboBoxItem == null)
                {
                    // Get combobo box item as for display member.
                    objComboBoxItem = this.ItemFromComboBoxItems(this.RowIndex, this.DisplayMember, objValue);
                }
            }

            return objComboBoxItem;
        }

        /// <summary>
        /// Gets the item value.
        /// </summary>
        /// <param name="objItem">The item.</param>
        /// <returns></returns>
        internal object GetItemValue(object objItem)
        {
            bool blnFlag = false;
            object obj2 = null;
            if (this.ValueMemberProperty != null)
            {
                obj2 = this.ValueMemberProperty.GetValue(objItem);
                blnFlag = true;
            }
            else if (this.DisplayMemberProperty != null)
            {
                obj2 = this.DisplayMemberProperty.GetValue(objItem);
                blnFlag = true;
            }
            else if (!Gizmox.WebGUI.CommonUtils.IsNullOrEmpty(this.ValueMember))
            {
                PropertyDescriptor objPropertyDescriptor = TypeDescriptor.GetProperties(objItem).Find(this.ValueMember, true);
                if (objPropertyDescriptor != null)
                {
                    obj2 = objPropertyDescriptor.GetValue(objItem);
                    blnFlag = true;
                }
            }
            if (!blnFlag && !Gizmox.WebGUI.CommonUtils.IsNullOrEmpty(this.DisplayMember))
            {
                PropertyDescriptor objPropertyDescriptor2 = TypeDescriptor.GetProperties(objItem).Find(this.DisplayMember, true);
                if (objPropertyDescriptor2 != null)
                {
                    obj2 = objPropertyDescriptor2.GetValue(objItem);
                    blnFlag = true;
                }
            }
            if (!blnFlag)
            {
                obj2 = objItem;
            }
            return obj2;
        }


        /// <summary>
        /// Initializes the combo box text.
        /// </summary>
        private void InitializeComboBoxText()
        {
        }

        /// <summary>
        /// Initializes the display member property descriptor.
        /// </summary>
        /// <param name="strDisplayMember">The display member.</param>
        private void InitializeDisplayMemberPropertyDescriptor(string strDisplayMember)
        {
            if (this.DataManager != null)
            {
                if (Gizmox.WebGUI.CommonUtils.IsNullOrEmpty(strDisplayMember))
                {
                    this.DisplayMemberProperty = null;
                }
                else
                {
                    //This line doesn't exist in the Luts
                    //It fixes a bug in a bonded ComboBox DisplayMember editor(designer)
                    //We need it probably because of a different functions calling order in design time
                    if (base.DataGridView != null)
                    {
                        BindingMemberInfo BindingMemberInfo = new BindingMemberInfo(strDisplayMember);
                        this.DataManager = base.DataGridView.BindingContext[this.DataSource, BindingMemberInfo.BindingPath] as CurrencyManager;
                        PropertyDescriptor objPropertyDescriptor = this.DataManager.GetItemProperties().Find(BindingMemberInfo.BindingField, true);
                        if (objPropertyDescriptor == null)
                        {
                            throw new ArgumentException(SR.GetString("DataGridViewComboBoxCell_FieldNotFound", new object[] { strDisplayMember }));
                        }
                        this.DisplayMemberProperty = objPropertyDescriptor;
                    }
                }
            }
        }

        /// <summary>Attaches and initializes the hosted editing control.</summary>
        /// <param name="objInitialFormattedValue">The initial value to be displayed in the control.</param>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        /// <param name="objDataGridViewCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that determines the appearance of the hosted control.</param>
        /// <filterpriority>1</filterpriority>
        public override void InitializeEditingControl(int intRowIndex, object objInitialFormattedValue, DataGridViewCellStyle objDataGridViewCellStyle)
        {
        }

        /// <summary>
        /// Initializes the value member property descriptor.
        /// </summary>
        /// <param name="strValueMember">The value member.</param>
        private void InitializeValueMemberPropertyDescriptor(string strValueMember)
        {
            if (this.DataManager != null)
            {
                if (Gizmox.WebGUI.CommonUtils.IsNullOrEmpty(strValueMember))
                {
                    this.ValueMemberProperty = null;
                }
                else
                {
                    //This line doesn't exist in the Luts
                    //It fixes a bug in a bonded ComboBox ValueMember editor(designer)
                    //We need it probably because of a different functions calling order in design time
                    if (base.DataGridView != null)
                    {
                        BindingMemberInfo BindingMemberInfo = new BindingMemberInfo(strValueMember);
                        this.DataManager = base.DataGridView.BindingContext[this.DataSource, BindingMemberInfo.BindingPath] as CurrencyManager;
                        PropertyDescriptor objPropertyDescriptor = this.DataManager.GetItemProperties().Find(BindingMemberInfo.BindingField, true);
                        if (objPropertyDescriptor == null)
                        {
                            throw new ArgumentException(SR.GetString("DataGridViewComboBoxCell_FieldNotFound", new object[] { strValueMember }));
                        }
                        this.ValueMemberProperty = objPropertyDescriptor;
                    }
                }
            }
        }

        /// <summary>
        /// Items from combo box data source.
        /// </summary>
        /// <param name="objPropertyDescriptor">The property.</param>
        /// <param name="objKey">The key.</param>
        /// <returns></returns>
        private object ItemFromComboBoxDataSource(PropertyDescriptor objPropertyDescriptor, object objKey)
        {
            if (objKey == null)
            {
                throw new ArgumentNullException("key");
            }
            object obj2 = null;
            if ((this.DataManager.List is IBindingList) && ((IBindingList)this.DataManager.List).SupportsSearching)
            {
                int num = ((IBindingList)this.DataManager.List).Find(objPropertyDescriptor, objKey);
                if (num != -1)
                {
                    obj2 = this.DataManager.List[num];
                }
                return obj2;
            }
            for (int i = 0; i < this.DataManager.List.Count; i++)
            {
                object objComponent = this.DataManager.List[i];
                object obj4 = objPropertyDescriptor.GetValue(objComponent);
                if (objKey.Equals(obj4))
                {
                    return objComponent;
                }
            }
            return obj2;
        }

        /// <summary>
        /// Items from combo box items.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <param name="strField">The field.</param>
        /// <param name="objKey">The key.</param>
        /// <returns></returns>
        private object ItemFromComboBoxItems(int intRowIndex, string strField, object objKey)
        {

            object objComponent = null;
            if (this.OwnsEditingComboBox(intRowIndex))
            {
                objComponent = this.EditingComboBox.SelectedItem;
                object obj3 = null;
                PropertyDescriptor objPropertyDescriptor = TypeDescriptor.GetProperties(objComponent).Find(strField, true);
                if (objPropertyDescriptor != null)
                {
                    obj3 = objPropertyDescriptor.GetValue(objComponent);
                }
                if ((obj3 == null) || !obj3.Equals(objKey))
                {
                    objComponent = null;
                }
            }
            if (objComponent == null)
            {
                foreach (object obj4 in this.Items)
                {
                    object obj5 = null;
                    PropertyDescriptor objPropertyDescriptor2 = TypeDescriptor.GetProperties(obj4).Find(strField, true);
                    if (objPropertyDescriptor2 != null)
                    {
                        obj5 = objPropertyDescriptor2.GetValue(obj4);
                    }
                    if ((obj5 != null) && obj5.Equals(objKey))
                    {
                        objComponent = obj4;
                        break;
                    }
                }
            }
            if (objComponent == null)
            {
                if (this.OwnsEditingComboBox(intRowIndex))
                {
                    objComponent = this.EditingComboBox.SelectedItem;
                    if ((objComponent == null) || !objComponent.Equals(objKey))
                    {
                        objComponent = null;
                    }
                }
                if ((objComponent == null) && this.Items.Contains(objKey))
                {
                    objComponent = objKey;
                }
            }
            return objComponent;
        }

        /// <summary>
        /// Lookups the value.
        /// </summary>
        /// <param name="objFormattedValue">The formatted value.</param>
        /// <param name="objValue">The value.</param>
        /// <returns></returns>
        private bool LookupValue(object objFormattedValue, out object objValue)
        {
            if (objFormattedValue == null)
            {
                objValue = null;
                return true;
            }
            object objItem = null;
            if ((this.DisplayMemberProperty != null) || (this.ValueMemberProperty != null))
            {
                objItem = this.ItemFromComboBoxDataSource((this.DisplayMemberProperty != null) ? this.DisplayMemberProperty : this.ValueMemberProperty, objFormattedValue);
            }
            else
            {
                objItem = this.ItemFromComboBoxItems(base.RowIndex, string.IsNullOrEmpty(this.DisplayMember) ? this.ValueMember : this.DisplayMember, objFormattedValue);
            }
            if (objItem == null)
            {
                objValue = null;
                return false;
            }
            objValue = this.GetItemValue(objItem);
            return true;
        }

        /// <summary>
        /// Converts a value formatted for display to an actual cell value.
        /// </summary>
        /// <param name="objFormattedValue">The formatted value.</param>
        /// <param name="objCellStyle">The cell style.</param>
        /// <param name="objFormattedValueTypeConverter">The formatted value type converter.</param>
        /// <param name="objValueTypeConverter">The value type converter.</param>
        /// <returns></returns>
        public override object ParseFormattedValue(object objFormattedValue, DataGridViewCellStyle objCellStyle, TypeConverter objFormattedValueTypeConverter, TypeConverter objValueTypeConverter)
        {
            if (objValueTypeConverter == null)
            {
                if (this.ValueMemberProperty != null)
                {
                    objValueTypeConverter = this.ValueMemberProperty.Converter;
                }
                else if (this.DisplayMemberProperty != null)
                {
                    objValueTypeConverter = this.DisplayMemberProperty.Converter;
                }
            }
            if (((this.DataManager == null) || ((this.DisplayMemberProperty == null) && (this.ValueMemberProperty == null))) && (CommonUtils.IsNullOrEmpty(this.DisplayMember) && CommonUtils.IsNullOrEmpty(this.ValueMember)))
            {
                return base.ParseFormattedValueInternal(this.ValueType, objFormattedValue, objCellStyle, objFormattedValueTypeConverter, objValueTypeConverter);
            }
            object obj2 = base.ParseFormattedValueInternal(this.DisplayType, objFormattedValue, objCellStyle, objFormattedValueTypeConverter, this.DisplayTypeConverter);
            object obj3 = obj2;
            if (this.LookupValue(obj3, out obj2))
            {
                return obj2;
            }
            if (obj3 != DBNull.Value)
            {
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, SR.GetString("Formatter_CantConvert"), new object[] { obj2, this.DisplayType }));
            }
            return DBNull.Value;
        }

        /// <summary>
        /// Returns a string that describes the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return ("DataGridViewComboBoxCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + base.RowIndex.ToString(CultureInfo.CurrentCulture) + " }");
        }

        /// <summary>
        /// Unwires the data source.
        /// </summary>
        private void UnwireDataSource()
        {
            IComponent dataSource = this.DataSource as IComponent;
            if (dataSource != null)
            {
                dataSource.Disposed -= new EventHandler(this.DataSource_Disposed);
            }
            ISupportInitializeNotification notification = this.DataSource as ISupportInitializeNotification;
            if ((notification != null) && ((this.Flags & 0x10) != 0))
            {
                notification.Initialized -= new EventHandler(this.DataSource_Initialized);
                this.Flags = (byte)(this.Flags & -17);
            }
        }

        /// <summary>
        /// Wires the data source.
        /// </summary>
        /// <param name="objDataSource">The data source.</param>
        private void WireDataSource(object objDataSource)
        {
            IComponent component = objDataSource as IComponent;
            if (component != null)
            {
                component.Disposed += new EventHandler(this.DataSource_Disposed);
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets the drop down style.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue(ComboBoxStyle.DropDownList)]
        public virtual ComboBoxStyle DropDownStyle
        {
            get
            {
                ComboBoxStyle enmDropDownStyle = menmDropDownStyle;

                if (enmDropDownStyle == ComboBoxStyle.DropDownList) // Check if value is the default one
                {
                    if (DataGridView != null &&
                        ColumnIndex < DataGridView.Columns.Count &&
                        ColumnIndex >= 0 &&
                        DataGridView.Columns[this.ColumnIndex].CellTemplate != null)
                    {
                        enmDropDownStyle = ((DataGridViewComboBoxCell)DataGridView.Columns[this.ColumnIndex].CellTemplate).DropDownStyle;
                    }
                }

                return enmDropDownStyle;
            }
            set
            {
                // Set the new dropdown style and update the control if value had changed
                if (menmDropDownStyle != value)
                {
                    menmDropDownStyle = value;

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [support edit mode].
        /// </summary>
        /// <value><c>true</c> if [support edit mode]; otherwise, <c>false</c>.</value>
        protected override bool SupportEditMode
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets the editing combo box.
        /// </summary>
        /// <value>The editing combo box.</value>
        private DataGridViewComboBoxEditingControl EditingComboBox
        {
            get
            {
                return menmComboBoxCellEditingComboBox;
            }
            set
            {
                if ((value != null) || menmComboBoxCellEditingComboBox != null)
                {
                    menmComboBoxCellEditingComboBox = value;
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the cell will match the characters being entered in the cell with a selection from the drop-down list. </summary>
        /// <returns>true if automatic completion is activated; otherwise, false. The default is true.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(true)]
        public virtual bool AutoComplete
        {
            get
            {
                return ((this.Flags & 8) != 0);
            }
            set
            {
                if (value != this.AutoComplete)
                {
                    if (value)
                    {
                        this.Flags = (byte)(this.Flags | 8);
                    }
                    else
                    {
                        this.Flags = (byte)(this.Flags & -9);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [create items from data source].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [create items from data source]; otherwise, <c>false</c>.
        /// </value>
        private bool CreateItemsFromDataSource
        {
            get
            {
                return ((this.Flags & 4) != 0);
            }
            set
            {
                if (value)
                {
                    this.Flags = (byte)(this.Flags | 4);
                }
                else
                {
                    this.Flags = (byte)(this.Flags & -5);
                }
            }
        }

        /// <summary>
        /// Gets or sets the data manager.
        /// </summary>
        /// <value>The data manager.</value>
        private CurrencyManager DataManager
        {
            get
            {
                return this.GetDataManager(base.DataGridView);
            }
            set
            {
                if ((value != null) || mobjDataManager != null)
                {
                    mobjDataManager = value;
                }
            }
        }

        /// <summary>Gets or sets the data source whose data contains the possible selections shown in the drop-down list.</summary>
        /// <returns>An <see cref="T:System.Collections.IList"></see> or <see cref="T:System.ComponentModel.IListSource"></see> that contains a collection of values used to supply data to the drop-down list. The default value is null.</returns>
        /// <exception cref="T:System.ArgumentException">The specified value when setting this property is not null and is not of type <see cref="T:System.Collections.IList"></see> nor <see cref="T:System.ComponentModel.IListSource"></see>.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public virtual object DataSource
        {
            get
            {
                return mobjDataSource;
            }
            set
            {
                if (((value != null) && !(value is IList)) && !(value is IListSource))
                {
                    throw new ArgumentException(SR.GetString("BadDataSourceForComplexBinding"));
                }
                if (this.DataSource != value)
                {
                    this.DataManager = null;
                    this.UnwireDataSource();
                    mobjDataSource = value;
                    this.WireDataSource(value);
                    this.CreateItemsFromDataSource = true;
                    mintCachedDropDownWidth = -1;
                    try
                    {
                        this.InitializeDisplayMemberPropertyDescriptor(this.DisplayMember);
                    }
                    catch (Exception objException)
                    {
                        if (ClientUtils.IsCriticalException(objException))
                        {
                            throw;
                        }
                        this.DisplayMemberInternal = null;
                    }
                    try
                    {
                        this.InitializeValueMemberPropertyDescriptor(this.ValueMember);
                    }
                    catch (Exception objException2)
                    {
                        if (ClientUtils.IsCriticalException(objException2))
                        {
                            throw;
                        }
                        this.ValueMemberInternal = null;
                    }
                    if (value == null)
                    {
                        this.DisplayMemberInternal = null;
                        this.ValueMemberInternal = null;
                    }
                    if (this.OwnsEditingComboBox(base.RowIndex))
                    {
                        this.InitializeComboBoxText();
                    }
                    else
                    {
                        base.OnCommonChange();
                    }
                }
            }
        }

        /// <summary>Gets or sets a string that specifies where to gather selections to display in the drop-down list.</summary>
        /// <returns>A string specifying the name of a property or column in the data source specified in the <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DataSource"></see> property. The default value is <see cref="F:System.String.Empty"></see>, which indicates that the <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DisplayMember"></see> property will not be used.</returns>
        /// <exception cref="T:System.ArgumentException">The <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DataSource"></see> property is not null and the specified value when setting this property is not null or <see cref="F:System.String.Empty"></see> and does not name a valid property or column in the data source.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue("")]
        public virtual string DisplayMember
        {
            get
            {
                if (mobjInternalDisplayMember == null)
                {
                    return string.Empty;
                }
                return (string)mobjInternalDisplayMember;
            }
            set
            {
                this.DisplayMemberInternal = value;
                if (this.OwnsEditingComboBox(base.RowIndex))
                {
                    this.InitializeComboBoxText();
                }
                else
                {
                    base.OnCommonChange();
                }
            }
        }

        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        /// <value>The flags.</value>
        private byte Flags
        {
            get
            {
                return this.mobjFlags;
            }
            set
            {
                this.mobjFlags = value;
            }
        }

        /// <summary>
        /// Sets the display member internal.
        /// </summary>
        /// <value>The display member internal.</value>
        private string DisplayMemberInternal
        {
            set
            {
                this.InitializeDisplayMemberPropertyDescriptor(value);
                if (((value != null) && (value.Length > 0)) || mobjInternalDisplayMember != null)
                {
                    mobjInternalDisplayMember = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the display member property.
        /// </summary>
        /// <value>The display member property.</value>
        private PropertyDescriptor DisplayMemberProperty
        {
            get
            {
                if (mobjDisplayMember==null)
                {
                    this.InitializeDisplayMemberPropertyDescriptor(this.DisplayMember);
                }
                return mobjDisplayMember;
            }
            set
            {
                if ((value != null) || mobjDisplayMember != null)
                {
                    mobjDisplayMember = value;
                }
            }
        }

        /// <summary>Gets or sets a value that determines how the combo box is displayed when it is not in edit mode.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.DataGridViewComboBoxDisplayStyle"></see> values. The default is <see cref="F:System.Windows.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.DataGridViewComboBoxDisplayStyle"></see> value.</exception>
        [DefaultValue(1)]
        public DataGridViewComboBoxDisplayStyle DisplayStyle
        {
            get
            {
                if (mintDisplayStyleForCurrentCellOnly >= 0)
                {
                    return (DataGridViewComboBoxDisplayStyle)mintDisplayStyleForCurrentCellOnly;
                }
                return DataGridViewComboBoxDisplayStyle.DropDownButton;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewComboBoxDisplayStyle));
                }
                if (value != this.DisplayStyle)
                {
                    mintDisplayStyleForCurrentCellOnly = (int)value;
                    if (base.DataGridView != null)
                    {
                        if (base.RowIndex != -1)
                        {
                            base.DataGridView.InvalidateCell(this);
                        }
                        else
                        {
                            base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets a value that determines if the display style only applies to the current cell.</summary>
        /// <returns>true if the display style applies only to the current cell; otherwise false. The default is false.</returns>
        [DefaultValue(false)]
        public bool DisplayStyleForCurrentCellOnly
        {
            get
            {
                return (mintDisplayStyleForCurrentCellOnly != 0);
            }
            set
            {
                if (value != this.DisplayStyleForCurrentCellOnly)
                {
                    mintDisplayStyleForCurrentCellOnly = value ? 1 : 0;
                    if (base.DataGridView != null)
                    {
                        if (base.RowIndex != -1)
                        {
                            base.DataGridView.InvalidateCell(this);
                        }
                        else
                        {
                            base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets a value indicating whether [display style for current cell only internal].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [display style for current cell only internal]; otherwise, <c>false</c>.
        /// </value>
        internal bool DisplayStyleForCurrentCellOnlyInternal
        {
            set
            {
                if (value != this.DisplayStyleForCurrentCellOnly)
                {
                    mintDisplayStyleForCurrentCellOnly = value ? 1 : 0;
                }
            }
        }

        /// <summary>
        /// Sets the display style internal.
        /// </summary>
        /// <value>The display style internal.</value>
        internal DataGridViewComboBoxDisplayStyle DisplayStyleInternal
        {
            set
            {
                if (value != this.DisplayStyle)
                {
                    mintDisplayStyleForCurrentCellOnly = (int)value;
                }
            }
        }

        /// <summary>
        /// Gets the display type.
        /// </summary>
        /// <value>The display type.</value>
        private Type DisplayType
        {
            get
            {
                if (this.DisplayMemberProperty != null)
                {
                    return this.DisplayMemberProperty.PropertyType;
                }
                if (this.ValueMemberProperty != null)
                {
                    return this.ValueMemberProperty.PropertyType;
                }
                return mobjDefaultFormattedValueType;
            }
        }

        /// <summary>
        /// Gets the display type converter.
        /// </summary>
        /// <value>The display type converter.</value>
        private TypeConverter DisplayTypeConverter
        {
            get
            {
                if (base.DataGridView != null)
                {
                    return base.DataGridView.GetCachedTypeConverter(this.DisplayType);
                }
                return TypeDescriptor.GetConverter(this.DisplayType);
            }
        }

        /// <summary>Gets or sets the width of the of the drop-down list portion of a combo box.</summary>
        /// <returns>The width, in pixels, of the drop-down list. The default is 1.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value is less than one.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue(1)]
        public virtual int DropDownWidth
        {
            get
            {
                return mintDropDownWidth;
            }
            set
            {
                if (value < 1)
                {
                    object[] arrArgs = new object[] { 1.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("DropDownWidth", value, SR.GetString("DataGridViewComboBoxCell_DropDownWidthOutOfRange", arrArgs));
                }
                mintDropDownWidth = value;
            }
        }

        /// <summary>Gets the type of the cell's hosted editing control.</summary>
        /// <returns>The <see cref="T:System.Type"></see> of the underlying editing control. This property always returns <see cref="T:System.Windows.Forms.DataGridViewComboBoxEditingControl"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override Type EditType
        {
            get
            {
                return mobjDefaultEditType;
            }
        }

        /// <summary>Gets or sets the flat style appearance of the cell.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.FlatStyle"></see> values. The default value is <see cref="F:System.Windows.Forms.FlatStyle.Standard"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value is not a valid <see cref="T:System.Windows.Forms.FlatStyle"></see> value.</exception>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(2)]
        public FlatStyle FlatStyle
        {
            get
            {
                return menmFlatStyle;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(FlatStyle));
                }
                if (value != this.FlatStyle)
                {
                    menmFlatStyle = value;
                    base.OnCommonChange();
                }
            }
        }

        /// <summary>
        /// Sets the flat style internal.
        /// </summary>
        /// <value>The flat style internal.</value>
        internal FlatStyle FlatStyleInternal
        {
            set
            {
                if (value != this.FlatStyle)
                {
                    menmFlatStyle = value;
                }
            }
        }

        /// <summary>Gets the class type of the formatted value associated with the cell.</summary>
        /// <returns>The type of the cell's formatted value. This property always returns <see cref="T:System.String"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override Type FormattedValueType
        {
            get
            {
                return mobjDefaultFormattedValueType;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has items.
        /// </summary>
        /// <value><c>true</c> if this instance has items; otherwise, <c>false</c>.</value>
        internal bool HasItems
        {
            get
            {
                return (this.LocalItems != null);
            }
        }

        /// <summary>Gets the objects that represent the selection displayed in the drop-down list. </summary>
        /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> containing the selection. </returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public virtual ObjectCollection Items
        {
            get
            {
                return this.GetItems(base.DataGridView);
            }
        }

        /// <summary>
        /// Gets or sets the local items.
        /// </summary>
        /// <value>The local items.</value>
        private ObjectCollection LocalItems
        {
            get
            {
                return mobjItems;
            }
            set
            {
                mobjItems = value;
            }
        }

        /// <summary>Gets or sets the maximum number of items shown in the drop-down list.</summary>
        /// <returns>The number of drop-down list items to allow. The minimum is 1 and the maximum is 100; the default is 8.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value is less than 1 or greater than 100 when setting this property.</exception>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(8)]
        public virtual int MaxDropDownItems
        {
            get
            {
                int intMaxDropDownItems = mintMaxDropDownItems;

                if (intMaxDropDownItems == -1)
                {
                    if (DataGridView != null &&
                        ColumnIndex < DataGridView.Columns.Count &&
                        ColumnIndex >= 0 &&
                        DataGridView.Columns[this.ColumnIndex].CellTemplate != null)
                    {
                        intMaxDropDownItems = ((DataGridViewComboBoxCell)DataGridView.Columns[this.ColumnIndex].CellTemplate).MaxDropDownItems;
                        mintMaxDropDownItems = intMaxDropDownItems;
                    }

                    if (intMaxDropDownItems == -1)
                    {
                        intMaxDropDownItems = 8;
                        mintMaxDropDownItems = intMaxDropDownItems;
                    }
                }

                return intMaxDropDownItems;
            }
            set
            {
                if ((value < 1) || (value > 100))
                {
                    object[] arrArgs = new object[] { 1.ToString(CultureInfo.CurrentCulture), 100.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("MaxDropDownItems", value, SR.GetString("DataGridViewComboBoxCell_MaxDropDownItemsOutOfRange", arrArgs));
                }
                mintMaxDropDownItems = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [paint XP themes].
        /// </summary>
        /// <value><c>true</c> if [paint XP themes]; otherwise, <c>false</c>.</value>
        private bool PaintXPThemes
        {
            get
            {
                return (((this.FlatStyle != FlatStyle.Flat) && (this.FlatStyle != FlatStyle.Popup)));
            }
        }

        /// <summary>Gets or sets a value indicating whether the items in the combo box are automatically sorted.</summary>
        /// <returns>true if the combo box is sorted; otherwise, false. The default is false.</returns>
        /// <exception cref="T:System.ArgumentException">An attempt was made to sort a cell that is attached to a data source.</exception>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(false)]
        public virtual bool Sorted
        {
            get
            {
                return ((this.Flags & 2) != 0);
            }
            set
            {
                if (value != this.Sorted)
                {
                    if (value)
                    {
                        if (this.DataSource != null)
                        {
                            throw new ArgumentException(SR.GetString("ComboBoxSortWithDataSource"));
                        }
                        this.Items.SortInternal();
                        this.Flags = (byte)(this.Flags | 2);
                    }
                    else
                    {
                        this.Flags = (byte)(this.Flags & -3);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the template combo box column.
        /// </summary>
        /// <value>The template combo box column.</value>
        internal DataGridViewComboBoxColumn TemplateComboBoxColumn
        {
            get
            {
                return this.mobjTemplateComboBoxColumn;
            }
            set
            {
                this.mobjTemplateComboBoxColumn = value;
            }
        }

        /// <summary>Gets or sets a string that specifies where to gather the underlying values used in the drop-down list.</summary>
        /// <returns>A string specifying the name of a property or column. The default value is <see cref="F:System.String.Empty"></see>, which indicates that this property is ignored.</returns>
        /// <exception cref="T:System.ArgumentException">The <see cref="P:System.Windows.Forms.DataGridViewComboBoxCell.DataSource"></see> property is not null and the specified value when setting this property is not null or <see cref="F:System.String.Empty"></see> and does not name a valid property or column in the data source.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        [DefaultValue("")]
        public virtual string ValueMember
        {
            get
            {
                if (mobjInternalValueMember == null)
                {
                    return string.Empty;
                }
                return mobjInternalValueMember as string;
            }
            set
            {
                this.ValueMemberInternal = value;
                if (this.OwnsEditingComboBox(base.RowIndex))
                {
                    this.InitializeComboBoxText();
                }
                else
                {
                    base.OnCommonChange();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has a custom drop down.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has a custom drop down; otherwise, <c>false</c>.
        /// </value>
        protected virtual bool IsCustomDropDown
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [owning column has items].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [owning column has items]; otherwise, <c>false</c>.
        /// </value>
        private bool OwningColumnHasItems
        {
            get
            {
                return this.ColumnIndex != -1 &&
                        this.DataGridView != null &&
                        this.DataGridView.Columns[this.ColumnIndex] != null &&
                        this.DataGridView.Columns[this.ColumnIndex] is DataGridViewComboBoxColumn &&
                        ((DataGridViewComboBoxColumn)this.DataGridView.Columns[this.ColumnIndex]).Items.Count > 0;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [sholud render combobox items].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [sholud render combobox items]; otherwise, <c>false</c>.
        /// </value>
        private bool SholudRenderComboboxItems
        {
            get
            {
                // Get local items collection.
                ObjectCollection objItems = this.LocalItems;

                // Check if cell has valid cells.
                bool blnHasValidItems = (objItems != null && objItems.Count > 0);

                // If local items collection is null - try retrieving it.
                if (!blnHasValidItems && this.TemplateComboBoxColumn != null)
                {
                    // Get items from containing column.
                    objItems = this.GetItems(this.TemplateComboBoxColumn.DataGridView);

                    // Re-check if cell has valid cells.
                    blnHasValidItems = (objItems != null && objItems.Count > 0);
                }

                // Rendering should be done only if:
                // 1. Cell has valid items.
                // 2. Cell is a column template or its items collection is different from its containing column's item.
                return (blnHasValidItems &&
                        (this.ColumnIndex == -1 ||
                        !CollectionsEquals(objItems, ((DataGridViewComboBoxColumn)this.DataGridView.Columns[this.ColumnIndex]).Items))
                        && !this.IsCustomDropDown);
            }
        }

        /// <summary>
        /// Sets the value member internal.
        /// </summary>
        /// <value>The value member internal.</value>
        private string ValueMemberInternal
        {
            set
            {
                this.InitializeValueMemberPropertyDescriptor(value);
                if (((value != null) && (value.Length > 0)) || mobjInternalValueMember != null)
                {
                    mobjInternalValueMember = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the value member property.
        /// </summary>
        /// <value>The value member property.</value>
        private PropertyDescriptor ValueMemberProperty
        {
            get
            {
                if (mobjValueMember == null)
                {
                    this.InitializeValueMemberPropertyDescriptor(this.ValueMember);
                }
                return mobjValueMember;
            }
            set
            {
                if (value != null || mobjValueMember != null)
                {
                    mobjValueMember = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the data type of the values in the cell.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:System.Type"></see> representing the data type of the value in the cell.</returns>
        public override Type ValueType
        {
            get
            {
                if (this.ValueMemberProperty != null)
                {
                    return this.ValueMemberProperty.PropertyType;
                }
                if (this.DisplayMemberProperty != null)
                {
                    return this.DisplayMemberProperty.PropertyType;
                }
                Type objValueType = base.ValueType;
                if (objValueType != null)
                {
                    return objValueType;
                }
                return mobjDefaultValueType;
            }
        }

        #endregion Properties

        #region Nested Types

        [Serializable()]
        private sealed class ItemComparer : IComparer
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ItemComparer"/> class.
            /// </summary>
            /// <param name="objDataGridViewComboBoxCell">The data grid view combo box cell.</param>
            public ItemComparer(DataGridViewComboBoxCell objDataGridViewComboBoxCell)
            {
                this.dataGridViewComboBoxCell = objDataGridViewComboBoxCell;
            }

            public int Compare(object objItem1, object objItem2)
            {
                if (objItem1 == null)
                {
                    if (objItem2 == null)
                    {
                        return 0;
                    }
                    return -1;
                }
                if (objItem2 == null)
                {
                    return 1;
                }
                string strItemDisplayText = this.dataGridViewComboBoxCell.GetItemDisplayText(objItem1);
                string strText2 = this.dataGridViewComboBoxCell.GetItemDisplayText(objItem2);
                return Application.CurrentCulture.CompareInfo.Compare(strItemDisplayText, strText2, CompareOptions.StringSort);
            }


            private DataGridViewComboBoxCell dataGridViewComboBoxCell;
        }

        /// <summary>Represents the collection of selection choices in a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</summary>
        [ListBindable(false), Serializable()]
        public class ObjectCollection : IList, ICollection, IEnumerable
        {

            #region Members

            private IComparer mobjComparer;
            private ArrayList mobjItems;
            private DataGridViewComboBoxCell mobjOwner;

            #endregion Members

            #region C'tors / D'tors

            /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> class.</summary>
            /// <param name="owner">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see> that owns the collection.</param>
            public ObjectCollection(DataGridViewComboBoxCell objOwner)
            {
                this.mobjOwner = objOwner;
            }

            #endregion C'tors / D'tors

            #region Methods

            /// <summary>Adds an item to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</summary>
            /// <returns>The position into which the new element was inserted.</returns>
            /// <param name="objItem">An object representing the item to add to the collection.</param>
            /// <exception cref="T:System.ArgumentNullException">item is null.</exception>
            /// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
            /// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
            public virtual int Add(object objItem)
            {
                this.mobjOwner.CheckNoDataSource();
                if (objItem == null)
                {
                    throw new ArgumentNullException("item");
                }
                int index = this.InnerArray.Add(objItem);
                bool blnFlag = false;
                if (this.mobjOwner.Sorted)
                {
                    try
                    {
                        this.InnerArray.Sort(this.Comparer);
                        index = this.InnerArray.IndexOf(objItem);
                        blnFlag = true;
                    }
                    finally
                    {
                        if (!blnFlag)
                        {
                            this.InnerArray.Remove(objItem);
                        }
                    }
                }
                this.mobjOwner.OnItemsCollectionChanged();
                return index;

            }

            /// <summary>Adds one or more items to the list of items for a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</summary>
            /// <param name="arrItems">One or more objects that represent items for the drop-down list.-or-An <see cref="T:System.Array"></see> of <see cref="T:System.Object"></see> values. </param>
            /// <exception cref="T:System.InvalidOperationException">One or more of the items in the items array is null.</exception>
            /// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
            /// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
            /// <exception cref="T:System.ArgumentNullException">items is null.</exception>
            public virtual void AddRange(params object[] arrItems)
            {
                this.mobjOwner.CheckNoDataSource();
                this.AddRangeInternal(arrItems);
                this.mobjOwner.OnItemsCollectionChanged();
            }

            /// <summary>Adds the items of an existing <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> to the list of items in a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</summary>
            /// <param name="objValues">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> to load into this collection.</param>
            /// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
            /// <exception cref="T:System.InvalidOperationException">One or more of the items in the value collection is null.</exception>
            /// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
            /// <exception cref="T:System.ArgumentNullException">value is null.</exception>
            public void AddRange(DataGridViewComboBoxCell.ObjectCollection objValues)
            {
                this.mobjOwner.CheckNoDataSource();
                this.AddRangeInternal(objValues);
                this.mobjOwner.OnItemsCollectionChanged();
            }

            internal void AddRangeInternal(ICollection objItems)
            {
                if (objItems == null)
                {
                    throw new ArgumentNullException("items");
                }
                IEnumerator enumerator = objItems.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current == null)
                        {
                            throw new InvalidOperationException(SR.GetString("InvalidNullItemInCollection"));
                        }
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null)
                    {
                        disposable.Dispose();
                    }
                }
                this.InnerArray.AddRange(objItems);
                if (this.mobjOwner.Sorted)
                {
                    this.InnerArray.Sort(this.Comparer);
                }
            }

            /// <summary>Clears all items from the collection.</summary>
            /// <exception cref="T:System.InvalidOperationException">The collection contains at least one item and the cell is in a shared row.</exception>
            /// <exception cref="T:System.ArgumentException">The collection contains at least one item and the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
            public void Clear()
            {
                if (this.InnerArray.Count > 0)
                {
                    this.mobjOwner.CheckNoDataSource();
                    this.InnerArray.Clear();
                    this.mobjOwner.OnItemsCollectionChanged();
                }
            }

            internal void ClearInternal()
            {
                this.InnerArray.Clear();
            }

            /// <summary>Determines whether the specified item is contained in the collection.</summary>
            /// <returns>true if the item is in the collection; otherwise, false.</returns>
            /// <param name="objValue">An object representing the item to locate in the collection.</param>
            /// <exception cref="T:System.ArgumentNullException">value is null.</exception>
            public bool Contains(object objValue)
            {
                return (this.IndexOf(objValue) != -1);
            }

            /// <summary>Copies the entire collection into an existing array of objects at a specified location within the array.</summary>
            /// <param name="intArrayIndex">The index of the element in dest at which to start copying.</param>
            /// <param name="arrDestination">The destination array to which the contents will be copied.</param>
            /// <exception cref="T:System.ArgumentNullException">destination is null.</exception>
            /// <exception cref="T:System.ArgumentOutOfRangeException">arrayIndex is less than 0 or equal to or greater than the length of destination.-or-The number of elements in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> is greater than the available space from arrayIndex to the end of destination.</exception>
            /// <exception cref="T:System.ArgumentException">destination is multidimensional.</exception>
            public void CopyTo(object[] arrDestination, int intArrayIndex)
            {
                int intCount = this.InnerArray.Count;
                for (int i = 0; i < intCount; i++)
                {
                    arrDestination[i + intArrayIndex] = this.InnerArray[i];
                }
            }

            /// <summary>Returns an enumerator that can iterate through a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see>.</summary>
            /// <returns>An enumerator of type <see cref="T:System.Collections.IEnumerator"></see>.</returns>
            public IEnumerator GetEnumerator()
            {
                return this.InnerArray.GetEnumerator();
            }

            /// <summary>Returns the index of the specified item in the collection.</summary>
            /// <returns>The zero-based index of the value parameter if it is found in the collection; otherwise, -1.</returns>
            /// <param name="objValue">An object representing the item to locate in the collection.</param>
            /// <exception cref="T:System.ArgumentNullException">value is null.</exception>
            public int IndexOf(object objValue)
            {
                if (objValue == null)
                {
                    throw new ArgumentNullException("value");
                }
                return this.InnerArray.IndexOf(objValue);
            }

            /// <summary>Inserts an item into the collection at the specified index. </summary>
            /// <param name="objItem">An object representing the item to insert.</param>
            /// <param name="index">The zero-based index at which to place item within an unsorted <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</param>
            /// <exception cref="T:System.ArgumentNullException">item is null.</exception>
            /// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
            /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than 0 or greater than the number of items in the collection. </exception>
            /// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
            public void Insert(int index, object objItem)
            {
                this.mobjOwner.CheckNoDataSource();
                if (objItem == null)
                {
                    throw new ArgumentNullException("item");
                }
                if ((index < 0) || (index > this.InnerArray.Count))
                {
                    throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", new object[] { "index", index.ToString(CultureInfo.CurrentCulture) }));
                }
                if (this.mobjOwner.Sorted)
                {
                    this.Add(objItem);
                }
                else
                {
                    this.InnerArray.Insert(index, objItem);
                    this.mobjOwner.OnItemsCollectionChanged();
                }

            }

            /// <summary>Removes the specified object from the collection.</summary>
            /// <param name="objValue">An object representing the item to remove from the collection.</param>
            /// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
            /// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
            public void Remove(object objValue)
            {
                int index = this.InnerArray.IndexOf(objValue);
                if (index != -1)
                {
                    this.RemoveAt(index);
                }
            }

            /// <summary>Removes the object at the specified index.</summary>
            /// <param name="index">The zero-based index of the object to be removed.</param>
            /// <exception cref="T:System.ArgumentException">The cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
            /// <exception cref="T:System.InvalidOperationException">The cell is in a shared row.</exception>
            /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than 0 or greater than the number of items in the collection minus one. </exception>
            public void RemoveAt(int index)
            {
                this.mobjOwner.CheckNoDataSource();
                if ((index < 0) || (index >= this.InnerArray.Count))
                {
                    throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", new object[] { "index", index.ToString(CultureInfo.CurrentCulture) }));
                }
                this.InnerArray.RemoveAt(index);
                this.mobjOwner.OnItemsCollectionChanged();
            }

            internal void SortInternal()
            {
                this.InnerArray.Sort(this.Comparer);
            }

            void ICollection.CopyTo(Array objDestinationArray, int index)
            {
                int intCount = this.InnerArray.Count;
                for (int i = 0; i < intCount; i++)
                {
                    objDestinationArray.SetValue(this.InnerArray[i], (int)(i + index));
                }
            }

            int IList.Add(object objItem)
            {
                this.mobjOwner.CheckNoDataSource();
                if (objItem == null)
                {
                    throw new ArgumentNullException("item");
                }
                int index = this.InnerArray.Add(objItem);
                bool blnFlag = false;
                if (this.mobjOwner.Sorted)
                {
                    try
                    {
                        this.InnerArray.Sort(this.Comparer);
                        index = this.InnerArray.IndexOf(objItem);
                        blnFlag = true;
                    }
                    finally
                    {
                        if (!blnFlag)
                        {
                            this.InnerArray.Remove(objItem);
                        }
                    }
                }
                this.mobjOwner.OnItemsCollectionChanged();
                return index;
            }

            #endregion Methods

            #region Properties

            private IComparer Comparer
            {
                get
                {
                    if (this.mobjComparer == null)
                    {
                        this.mobjComparer = new DataGridViewComboBoxCell.ItemComparer(this.mobjOwner);
                    }
                    return this.mobjComparer;
                }
            }

            /// <summary>Gets the number of items in the collection.</summary>
            /// <returns>The number of items in the collection.</returns>
            public int Count
            {
                get
                {
                    return this.InnerArray.Count;
                }
            }

            internal ArrayList InnerArray
            {
                get
                {
                    if (this.mobjItems == null)
                    {
                        this.mobjItems = new ArrayList();
                    }
                    return this.mobjItems;
                }
            }

            /// <summary>Gets a value indicating whether the collection is read-only.</summary>
            /// <returns>true if the collection is read-only; otherwise, false.</returns>
            public bool IsReadOnly
            {
                get
                {
                    return false;
                }
            }

            /// <summary>Gets or sets the item at the current index location. In C#, this property is the indexer for the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> class.</summary>
            /// <returns>The <see cref="T:System.Object"></see> stored at the given index.</returns>
            /// <param name="index">The zero-based index of the element to get or set.</param>
            /// <exception cref="T:System.ArgumentException">When setting this property, the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.DataSource"></see> property value is not null.</exception>
            /// <exception cref="T:System.ArgumentNullException">The specified value when setting this property is null.</exception>
            /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than 0 or greater than the number of items in the collection minus one. </exception>
            /// <exception cref="T:System.InvalidOperationException">When setting this property, the cell is in a shared row.</exception>
            public virtual object this[int index]
            {
                get
                {
                    if ((index < 0) || (index >= this.InnerArray.Count))
                    {
                        throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", new object[] { "index", index.ToString(CultureInfo.CurrentCulture) }));
                    }
                    return this.InnerArray[index];
                }
                set
                {
                    this.mobjOwner.CheckNoDataSource();
                    if (value == null)
                    {
                        throw new ArgumentNullException("value");
                    }
                    if ((index < 0) || (index >= this.InnerArray.Count))
                    {
                        throw new ArgumentOutOfRangeException("index", SR.GetString("InvalidArgument", new object[] { "index", index.ToString(CultureInfo.CurrentCulture) }));
                    }
                    this.InnerArray[index] = value;
                    this.mobjOwner.OnItemsCollectionChanged();
                }
            }

            bool ICollection.IsSynchronized
            {
                get
                {
                    return false;
                }
            }

            object ICollection.SyncRoot
            {
                get
                {
                    return this;
                }
            }

            bool IList.IsFixedSize
            {
                get
                {
                    return false;
                }
            }

            #endregion Properties

        }

        #endregion Nested Types

    }

    #endregion

    #region DataGridViewImageCell Class

    /// <summary>Displays a graphic in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
    /// <filterpriority>2</filterpriority>
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.DataGridViewImageCellSkin)), Serializable()]
    public class DataGridViewImageCell : DataGridViewCell
    {
        #region Members

        #region Private Members

        private const byte DATAGRIDVIEWIMAGECELL_valueIsIcon = 1;
        private bool mblnValueIsIcon;
        private byte mobjFlags;

        private DataGridViewImageCellLayout menmImageLayout;
        private static Type mobjCellType;
        private static Type mobjDefaultTypeIcon = typeof(ResourceHandle);
        private static Type mobjDefaultTypeImage = typeof(ResourceHandle);
        private static ResourceHandle mobjErrorBmp;
        private string mstrDescription = string.Empty;

        #endregion Private Members

        #endregion Members

        #region C'tors / D'tors

        static DataGridViewImageCell()
        {
            DataGridViewImageCell.mobjCellType = typeof(DataGridViewImageCell);
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCell"></see> class, configuring it for use with cell values other than <see cref="T:System.Drawing.Icon"></see> objects.</summary>
        public DataGridViewImageCell()
        {

        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCell"></see> class, optionally configuring it for use with <see cref="T:System.Drawing.Icon"></see> cell values.</summary>
        /// <param name="blnValueIsIcon">The cell will display an <see cref="T:System.Drawing.Icon"></see> value.</param>
        public DataGridViewImageCell(bool blnValueIsIcon)
            : this()
        {
            ValueIsIcon = blnValueIsIcon;
        }

        #endregion C'tors / D'tors

        #region Methods

        #region Events

        #endregion Events

        #region Render


        /// <summary>
        /// Renders the cell text/value.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objFormatedValue">The formated value.</param>
        protected override void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
        {
            base.RenderCellValue(objContext, objWriter, objFormatedValue);

            if (objFormatedValue != null)
            {
                if (objFormatedValue is byte[])
                {
                    GatewayReference objGatewayReference = new GatewayReference(this.DataGridView, string.Format("cell{0}x{1}x{2}", this.ColumnIndex, this.RowIndex, "image"));

                    objWriter.WriteAttributeString(WGAttributes.Image, objGatewayReference.ToString());
                }
                else if (objFormatedValue is ResourceHandle)
                {
                    ResourceHandle objResourceHandle = objFormatedValue as ResourceHandle;

                    if (objResourceHandle != null)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Image, objResourceHandle.ToString());
                    }
                }
                else if (objFormatedValue is string)
                {
                    if (objFormatedValue != null &&
                        objFormatedValue.ToString() != string.Empty)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Image, objFormatedValue.ToString());
                    }
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter, bool blnRenderOwner)
        {
            base.RenderAttributes(objContext, objWriter, blnRenderOwner);

            switch (this.ImageLayout)
            {
                case DataGridViewImageCellLayout.Normal:
                    objWriter.WriteAttributeString(WGAttributes.ImageSize, Convert.ToInt32(PictureBoxSizeMode.Normal).ToString());
                    break;
                case DataGridViewImageCellLayout.Stretch:
                    objWriter.WriteAttributeString(WGAttributes.ImageSize, Convert.ToInt32(PictureBoxSizeMode.StretchImage).ToString());
                    break;
                default:
                    break;
            }
        }

        #endregion Render

        /// <summary>
        /// Gets or sets the flags.
        /// </summary>
        /// <value>The flags.</value>
        private byte Flags
        {
            get
            {
                return this.mobjFlags;
            }
            set
            {
                this.mobjFlags = value;
            }
        }

        /// <summary>Creates an exact copy of this cell.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCell"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override object Clone()
        {
            DataGridViewImageCell objCell;
            Type objType = base.GetType();
            if (objType == DataGridViewImageCell.mobjCellType)
            {
                objCell = new DataGridViewImageCell();
            }
            else
            {
                objCell = (DataGridViewImageCell)Activator.CreateInstance(objType);
            }

            base.CloneInternal(objCell);
            objCell.Description = this.Description;
            objCell.ImageLayout = this.ImageLayout;

            return objCell;
        }

        /// <summary>Calculates the preferred size, in pixels, of the cell.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
        /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
        /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
        /// <param name="objConstraintSize">The cell's maximum allowable size.</param>
        /// <param name="intRowIndex">The zero-based row index of the cell.</param>
        protected override Size GetPreferredSize(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex, Size objConstraintSize)
        {
            return new Size(DefaultHorizontalPadding + 16, DefaultVerticalPadding + 16);
        }

        /// <summary>Returns a graphic as it would be displayed in the cell.</summary>
        /// <returns>An object that represents the formatted image.</returns>
        /// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> in effect for the cell. </param>
        /// <param name="enmContext">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorContexts"></see> values describing the context in which the formatted value is needed. </param>
        /// <param name="objValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the value type that provides custom conversion to the formatted value type, or null if no such custom conversion is needed.</param>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        /// <param name="objValue">The value to be formatted. </param>
        /// <param name="objFormattedValueTypeConverter">A <see cref="T:System.ComponentModel.TypeConverter"></see> associated with the formatted value type that provides custom conversion from the value type, or null if no such custom conversion is needed.</param>
        protected override object GetFormattedValue(object objValue, int intRowIndex, ref DataGridViewCellStyle objCellStyle, TypeConverter objValueTypeConverter, TypeConverter objFormattedValueTypeConverter, DataGridViewDataErrorContexts enmContext)
        {
            object objFormattedValue = null;

            if (objValue == null)
            {
                object obj = 1;
            }

            if ((enmContext & DataGridViewDataErrorContexts.ClipboardContent) != 0)
            {
                objFormattedValue = this.Description;
            }
            else
            {
                // Get formated value
                object obj2 = base.GetFormattedValue(objValue, intRowIndex, ref objCellStyle, objValueTypeConverter, objFormattedValueTypeConverter, enmContext);

                // Check for null value.
                if ((obj2 == null) && (objCellStyle.NullValue == null))
                {
                    objFormattedValue = null;
                }
                // Check for icon value.
                else if (obj2 is Icon)
                {
                    objFormattedValue = obj2 as Icon;

                    if (objFormattedValue == null)
                    {
                        objFormattedValue = ErrorIcon;
                    }
                }
                // Check for resoure handle value.
                else if (obj2 is ResourceHandle)
                {
                    objFormattedValue = obj2 as ResourceHandle;

                    if (objFormattedValue == null)
                    {
                        objFormattedValue = ErrorBitmap;
                    }
                }
                // Check for string value.
                else if (obj2 is string)
                {
                    if (obj2 != null && obj2.ToString() != string.Empty)
                    {
                        objFormattedValue = obj2.ToString();
                    }
                }
            }

            return objFormattedValue;
        }

        /// <summary>
        /// Gets the value of the cell.
        /// </summary>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        /// <returns>
        /// The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> property is less than 0, indicating that the cell is a row header cell.</exception>
        protected override object GetValue(int intRowIndex)
        {
            object objValue = base.GetValue(intRowIndex);
            if (objValue == null)
            {
                DataGridViewImageColumn objOwningColumn = base.OwningColumn as DataGridViewImageColumn;
                if (objOwningColumn == null)
                {
                    return objValue;
                }
                if (mobjDefaultTypeImage.IsAssignableFrom(this.ValueType))
                {
                    ResourceHandle objImage = objOwningColumn.Image;
                    if (objImage != null)
                    {
                        return objImage;
                    }
                    return objValue;
                }
                if (mobjDefaultTypeIcon.IsAssignableFrom(this.ValueType))
                {
                    ResourceHandle objIcon = objOwningColumn.Icon;
                    if (objIcon != null)
                    {
                        return objIcon;
                    }
                }
            }
            return objValue;
        }

        /// <summary>
        /// Returns a string that describes the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return null;
        }

        #endregion Methods

        #region Properties

        /// <summary>Gets the default value that is used when creating a new row.</summary>
        /// <returns>An object containing a default image placeholder, or null to display an empty cell.</returns>
        /// <filterpriority>1</filterpriority>
        public override object DefaultNewRowValue
        {
            get
            {
                return null;
            }
        }

        /// <summary>Gets or sets the text associated with the image.</summary>
        /// <returns>The text associated with the image displayed in the cell.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue("")]
        public string Description
        {
            get
            {
                return mstrDescription;
            }
            set
            {
                mstrDescription = value;
            }
        }

        /// <summary>Gets the type of the cell's hosted editing control. </summary>
        /// <returns>The <see cref="T:System.Type"></see> of the underlying editing control. As implemented in this class, this property is always null.</returns>
        /// <filterpriority>1</filterpriority>
        public override Type EditType
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the error bitmap.
        /// </summary>
        /// <value>The error bitmap.</value>
        internal static ResourceHandle ErrorBitmap
        {
            get
            {
                if (mobjErrorBmp == null)
                {
                    mobjErrorBmp = new SkinResourceHandle(typeof(DataGridView), "ErrorProvider.gif");
                }
                return mobjErrorBmp;
            }
        }

        /// <summary>
        /// Gets the error icon.
        /// </summary>
        /// <value>The error icon.</value>
        internal static Icon ErrorIcon
        {
            get
            {
                return null;
            }
        }

        /// <summary>Gets the type of the formatted value associated with the cell.</summary>
        /// <returns>A <see cref="T:System.Type"></see> object representing display value type of the cell, which is the <see cref="T:System.Drawing.Image"></see> type if the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewImageCell.ValueIsIcon"></see> property is set to false or the <see cref="T:System.Drawing.Icon"></see> type otherwise.</returns>
        /// <filterpriority>1</filterpriority>
        public override Type FormattedValueType
        {
            get
            {
                if (this.ValueIsIcon)
                {
                    return mobjDefaultTypeIcon;
                }
                return mobjDefaultTypeImage;
            }
        }

        /// <summary>Gets or sets the graphics layout for the cell. </summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCellLayout"></see> for this cell. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewImageCellLayout.NotSet"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The supplied <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCellLayout"></see> value is invalid. </exception>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(0)]
        public DataGridViewImageCellLayout ImageLayout
        {
            get
            {
                return this.menmImageLayout;
            }
            set
            {
                ImageLayoutInternal = value;
            }
        }

        /// <summary>
        /// Sets the image layout internal.
        /// </summary>
        /// <value>The image layout internal.</value>
        internal DataGridViewImageCellLayout ImageLayoutInternal
        {
            set
            {
                this.menmImageLayout = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether this cell displays an <see cref="T:System.Drawing.Icon"></see> value.</summary>
        /// <returns>true if this cell displays an <see cref="T:System.Drawing.Icon"></see> value; otherwise, false.</returns>
        [DefaultValue(false)]
        public bool ValueIsIcon
        {
            get
            {
                return this.mblnValueIsIcon;
            }
            set
            {
                this.ValueIsIconInternal = value;
            }
        }

        /// <summary>
        /// Sets a value indicating whether [value is icon internal].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [value is icon internal]; otherwise, <c>false</c>.
        /// </value>
        internal bool ValueIsIconInternal
        {
            set
            {
                this.mblnValueIsIcon = value;
            }
        }

        /// <summary>Gets or sets the data type of the values in the cell. </summary>
        /// <returns>The <see cref="T:System.Type"></see> of the cell's value.</returns>
        /// <filterpriority>1</filterpriority>
        public override Type ValueType
        {
            get
            {
                Type objValueType = base.ValueType;
                if (objValueType != null)
                {
                    return objValueType;
                }

                return typeof(ResourceHandle);
            }
            set
            {
                base.ValueType = value;
            }
        }

        #endregion Properties

    }
    #endregion

    #region DataGridViewButtonCell Class

    /// <summary>Displays a button-like user interface (UI) for use in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.DataGridViewButtonCellSkin)), Serializable()]
    public class DataGridViewButtonCell : DataGridViewCell
    {
        #region Members

        #region Constants

        private const byte DATAGRIDVIEWBUTTONCELL_horizontalTextMargin = 2;
        private const byte DATAGRIDVIEWBUTTONCELL_textPadding = 5;
        private const byte DATAGRIDVIEWBUTTONCELL_themeMargin = 100;
        private const byte DATAGRIDVIEWBUTTONCELL_verticalTextMargin = 1;

        #endregion

        #region Statics

        #endregion

        #region Private Members

        private static Type mobjDefaultFormattedValueType;
        private static Type mobjDefaultValueType;
        private static Type mobjCellType;
        private static Rectangle mobjRectangleThemeMargins = new Rectangle(-1, -1, 0, 0);

        private int mintUseColumnTextForButtonValue = 0;

        #endregion Private Members

        #region Serializable Events

        #endregion Serializable Events

        #endregion Members

        #region C'tors / D'tors

        static DataGridViewButtonCell()
        {
            mobjDefaultFormattedValueType = typeof(string);
            mobjDefaultValueType = typeof(object);
            mobjCellType = typeof(DataGridViewButtonCell);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewButtonCell"/> class.
        /// </summary>
        public DataGridViewButtonCell()
        {

        }

        #endregion C'tors / D'tors

        #region Methods

        #region Events

        /// <summary>Indicates whether a row is unshared if a key is pressed while the focus is on a cell in the row.</summary>
        /// <returns>true if the user pressed the SPACE key without modifier keys; otherwise, false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        protected override bool KeyDownUnsharesRow(KeyEventArgs e, int intRowIndex)
        {
            if (((e.KeyCode == Keys.Space) && !e.Alt) && !e.Control)
            {
                return !e.Shift;
            }
            return false;
        }

        /// <summary>Indicates whether a row is unshared when a key is released while the focus is on a cell in the row.</summary>
        /// <returns>true if the user released the SPACE key; otherwise, false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains the event data. </param>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        protected override bool KeyUpUnsharesRow(KeyEventArgs e, int intRowIndex)
        {
            return (e.KeyCode == Keys.Space);
        }

        #endregion Events

        #region Render


        /// <summary>
        /// Renders the cell text/value.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objFormatedValue">The formated value.</param>
        protected override void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
        {
            base.RenderCellValue(objContext, objWriter, objFormatedValue);

            if (objFormatedValue != null && objFormatedValue.ToString() != string.Empty)
            {
                objWriter.WriteAttributeText(WGAttributes.Text, objFormatedValue.ToString());
            }
        }

        /// <summary>
        /// Renders the cell style attributes.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objCellStyle">The cell style.</param>
        protected override void RenderCellStyleAttributes(IAttributeWriter objWriter, DataGridViewCellStyle objCellStyle)
        {
            base.RenderCellStyleAttributes(objWriter, objCellStyle);

            if (objCellStyle != null)
            {
                // Render Text-Align.
                objWriter.WriteAttributeString(WGAttributes.TextAlign, objCellStyle.Alignment.ToString());
            }
        }

        #endregion Render

        /// <summary>Retrieves the text associated with the button.</summary>
        /// <returns>The value of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonCell"></see> or the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewButtonColumn.Text"></see> value of the owning column if <see cref="P:Gizmox.WebGUI.Forms.DataGridViewButtonCell.UseColumnTextForButtonValue"></see> is true. </returns>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        protected override object GetValue(int intRowIndex)
        {
            if (((this.UseColumnTextForButtonValue && (base.DataGridView != null)) && ((base.DataGridView.NewRowIndex != intRowIndex) && (base.OwningColumn != null))) && (base.OwningColumn is DataGridViewButtonColumn))
            {
                return ((DataGridViewButtonColumn)base.OwningColumn).Text;
            }
            return base.GetValue(intRowIndex);
        }

        /// <summary>Creates an exact copy of this cell.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:System.Windows.Forms.DataGridViewButtonCell"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public override object Clone()
        {
            DataGridViewButtonCell objCell;
            Type objType = base.GetType();
            if (objType == mobjCellType)
            {
                objCell = new DataGridViewButtonCell();
            }
            else
            {
                objCell = (DataGridViewButtonCell)Activator.CreateInstance(objType);
            }
            base.CloneInternal(objCell);
            objCell.UseColumnTextForButtonValueInternal = this.UseColumnTextForButtonValue;
            return objCell;
        }

        /// <summary>Calculates the preferred size, in pixels, of the cell.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.</returns>
        /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
        /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
        /// <param name="objConstraintSize">The cell's maximum allowable size.</param>
        /// <param name="intRowIndex">The zero-based row index of the cell.</param>
        protected override Size GetPreferredSize(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex, Size objConstraintSize)
        {
            Size objSize = base.GetPreferredSize(Convert.ToString(this.GetValue(intRowIndex)), objCellStyle);
            return new Size(objSize.Width + 8, objSize.Height + 5);
        }

        /// <summary>Returns the string representation of the cell.</summary>
        /// <returns>A <see cref="T:System.String"></see> that represents the current cell.</returns>
        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            return ("DataGridViewButtonCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + base.RowIndex.ToString(CultureInfo.CurrentCulture) + " }");
        }

        #endregion Methods

        #region Properties

        /// <summary>Gets the type of the cell's hosted editing control.</summary>
        /// <returns>The <see cref="T:System.Type"></see> of the underlying editing control.</returns>
        /// <filterpriority>1</filterpriority>
        public override Type EditType
        {
            get
            {
                return null;
            }
        }

        /// <summary>Gets or sets the style determining the button's appearance.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> values.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> value. </exception>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(2)]
        public FlatStyle FlatStyle
        {
            get
            {
                return FlatStyle.Standard;
            }
            set
            {

            }
        }

        /// <summary>Gets or sets a value indicating whether the owning column's text will appear on the button displayed by the cell.</summary>
        /// <returns>true if the value of the <see cref="P:System.Windows.Forms.DataGridViewCell.Value"></see> property will automatically match the value of the <see cref="P:System.Windows.Forms.DataGridViewButtonColumn.Text"></see> property of the owning column; otherwise, false. The default is false.</returns>
        [DefaultValue(false)]
        public bool UseColumnTextForButtonValue
        {
            get
            {
                return (mintUseColumnTextForButtonValue != 0);
            }
            set
            {
                if (value != this.UseColumnTextForButtonValue)
                {
                    mintUseColumnTextForButtonValue = value ? 1 : 0;
                    base.OnCommonChange();
                }
            }
        }

        internal bool UseColumnTextForButtonValueInternal
        {
            set
            {
                if (value != this.UseColumnTextForButtonValue)
                {
                    mintUseColumnTextForButtonValue = value ? 1 : 0;
                }
            }
        }

        /// <summary>
        /// Gets the type of the formatted value associated with the cell.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:System.Type"></see> representing the type of the cell's formatted value.</returns>
        public override Type FormattedValueType
        {
            get
            {
                return mobjDefaultFormattedValueType;
            }
        }

        /// <filterpriority>1</filterpriority>
        public override Type ValueType
        {
            get
            {
                Type objType1 = base.ValueType;
                if (objType1 != null)
                {
                    return objType1;
                }
                return null;
            }
        }

        #endregion Properties

    }

    #endregion

    #region DataGridViewLinkCell Class

    /// <summary>Represents a cell that contains a link. </summary>
    /// <filterpriority>2</filterpriority>
    [Gizmox.WebGUI.Forms.Skins.Skin(typeof(Gizmox.WebGUI.Forms.Skins.DataGridViewLinkCellSkin)), Serializable()]
    public class DataGridViewLinkCell : DataGridViewCell
    {
        #region Members

        #region Static

        #region constants

        private const byte DATAGRIDVIEWLINKCELL_horizontalTextMarginLeft = 1;
        private const byte DATAGRIDVIEWLINKCELL_horizontalTextMarginRight = 2;
        private const byte DATAGRIDVIEWLINKCELL_verticalTextMarginBottom = 1;
        private const byte DATAGRIDVIEWLINKCELL_verticalTextMarginTop = 1;

        #endregion

        #endregion

        #region Private Members

        private bool mblnClientMode;
        private bool mblnLinkVisited;
        private bool mblnLinkVisitedSet;
        private string mstrUrl = string.Empty;
        private LinkState menmLinkState = LinkState.Normal;
        private Color mobjLinkVisitedLinkColor = Color.Empty;
        private int mintLinkTrackVisitedState = 0;
        private Color mobjLinkColor = Color.Empty;
        private LinkBehavior menmLinkBehavior = LinkBehavior.SystemDefault;
        private int mintLinkUseColumnTextForLinkValue = 0;
        private Color mobjLinkActiveColor = Color.Empty;

        private static Type mobjCellType;
        private static Type mobjDefaultFormattedValueType;
        private static Type mobjDefaultValueType;

        #endregion Private Members

        #region Serializable Events

        #endregion Serializable Events

        #endregion Members

        #region C'tors / D'tors

        static DataGridViewLinkCell()
        {
            DataGridViewLinkCell.mobjDefaultFormattedValueType = typeof(string);
            DataGridViewLinkCell.mobjDefaultValueType = typeof(object);
            DataGridViewLinkCell.mobjCellType = typeof(DataGridViewLinkCell);
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkCell"></see> class.</summary>
        public DataGridViewLinkCell()
        {

        }

        #endregion C'tors / D'tors

        #region Methods

        #region Events

        /// <summary>Indicates whether the row containing the cell will be unshared when a key is released and the cell has focus.</summary>
        /// <returns>true if the SPACE key was released, the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewLinkCell.TrackVisitedState"></see> property is true, the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewLinkCell.LinkVisited"></see> property is false, and the CTRL, ALT, and SHIFT keys are not pressed; otherwise, false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.KeyEventArgs"></see> that contains data about the key press.</param>
        /// <param name="intRowIndex">The index of the row containing the cell.</param>
        protected override bool KeyUpUnsharesRow(KeyEventArgs e, int intRowIndex)
        {
            return false;
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            // If not in Client mode
            if (!this.ClientMode && !string.IsNullOrEmpty(this.Url) && !this.ReadOnly)
            {
                // add click event type
                objEvents.Set(WGEvents.Click);
            }

            return objEvents;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objEvent"></param>
        protected internal override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            switch (objEvent.Type)
            {
                case "LinkStateChange":
                    this.LinkState = (LinkState)Enum.Parse(typeof(LinkState), objEvent[WGAttributes.LinkState]);
                    break;
                case "Click":
                    if (!this.ReadOnly)
                    {
                        this.OpenLink();
                    }
                    break;
            }
        }

        /// <summary>Indicates whether the row containing the cell will be unshared when the mouse button is pressed while the pointer is over the cell.</summary>
        /// <returns>true if the mouse pointer is over the link; otherwise, false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains data about the mouse click.</param>
        protected override bool MouseDownUnsharesRow(DataGridViewCellMouseEventArgs e)
        {
            return false;
        }

        /// <summary>Indicates whether the row containing the cell will be unshared when the mouse pointer leaves the cell.</summary>
        /// <returns>true if the link displayed by the cell is not in the normal state; otherwise, false.</returns>
        /// <param name="intRowIndex">The index of the row containing the cell.</param>
        protected override bool MouseLeaveUnsharesRow(int intRowIndex)
        {
            return false;
        }

        /// <summary>Indicates whether the row containing the cell will be unshared when the mouse pointer moves over the cell.</summary>
        /// <returns>true if the mouse pointer is over the link and the link is has not yet changed color to reflect the hover state; otherwise, false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains data about the mouse click.</param>
        protected override bool MouseMoveUnsharesRow(DataGridViewCellMouseEventArgs e)
        {
            return false;
        }

        /// <summary>Indicates whether the row containing the cell will be unshared when the mouse button is released while the pointer is over the cell. </summary>
        /// <returns>true if the mouse pointer is over the link; otherwise, false.</returns>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellMouseEventArgs"></see> that contains data about the mouse click.</param>
        protected override bool MouseUpUnsharesRow(DataGridViewCellMouseEventArgs e)
        {
            return false;
        }

        #endregion Events

        #region Render

        /// <summary>
        /// Renders the cell text/value.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objFormatedValue">The formated value.</param>
        protected override void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
        {
            base.RenderCellValue(objContext, objWriter, objFormatedValue);

            if (objFormatedValue != null && objFormatedValue.ToString() != string.Empty)
            {
                objWriter.WriteAttributeText(WGAttributes.Text, objFormatedValue.ToString());
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter, bool blnRenderOwner)
        {
            base.RenderAttributes(objContext, objWriter, blnRenderOwner);

            // Render link color.
            if (this.InheritedLinkColor != LinkUtilities.IELinkColor)
            {
                objWriter.WriteAttributeString(WGAttributes.LinkColor, CommonUtils.GetHtmlColor(this.InheritedLinkColor));
            }

            // Render active link color.
            if (this.InheritedActiveLinkColor != LinkUtilities.IEActiveLinkColor)
            {
                objWriter.WriteAttributeString(WGAttributes.ActiveLinkColor, CommonUtils.GetHtmlColor(this.InheritedActiveLinkColor));
            }

            // Render visited link color.
            if (this.InheritedVisitedLinkColor != LinkUtilities.IEVisitedLinkColor)
            {
                objWriter.WriteAttributeString(WGAttributes.VisitedLinkColor, CommonUtils.GetHtmlColor(this.InheritedVisitedLinkColor));
            }

            // Render link state.
            if (this.LinkState == LinkState.Visited)
            {
                objWriter.WriteAttributeString(WGAttributes.LinkState, Convert.ToInt32(this.LinkState).ToString());
            }

            // Render url value.
            if (this.ClientMode && !string.IsNullOrEmpty(this.Url))
            {
                objWriter.WriteAttributeString(WGAttributes.Value, this.Url);
            }
        }

        /// <summary>
        /// Renders the cell style attributes.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objCellStyle">The cell style.</param>
        protected override void RenderCellStyleAttributes(IAttributeWriter objWriter, DataGridViewCellStyle objCellStyle)
        {
            base.RenderCellStyleAttributes(objWriter, objCellStyle);

            if (objCellStyle != null)
            {
                // Render Text-Align.
                objWriter.WriteAttributeString(WGAttributes.TextAlign, objCellStyle.Alignment.ToString());
            }
        }

        #endregion Render

        /// <summary>Creates an exact copy of this cell.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:System.Windows.Forms.DataGridViewLinkCell"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public override object Clone()
        {
            DataGridViewLinkCell objCell;
            Type objType = base.GetType();
            if (objType == mobjCellType)
            {
                objCell = new DataGridViewLinkCell();
            }
            else
            {
                objCell = (DataGridViewLinkCell)Activator.CreateInstance(objType);
            }
            base.CloneInternal(objCell);
            if (mobjLinkActiveColor != Color.Empty)
            {
                objCell.ActiveLinkColorInternal = this.ActiveLinkColor;
            }
            if (mintLinkUseColumnTextForLinkValue != 0)
            {
                objCell.UseColumnTextForLinkValueInternal = this.UseColumnTextForLinkValue;
            }
            if (menmLinkBehavior != LinkBehavior.SystemDefault)
            {
                objCell.LinkBehaviorInternal = this.LinkBehavior;
            }
            if (mobjLinkColor != Color.Empty)
            {
                objCell.LinkColorInternal = this.LinkColor;
            }
            if (mintLinkTrackVisitedState != 0)
            {
                objCell.TrackVisitedStateInternal = this.TrackVisitedState;
            }
            if (mobjLinkVisitedLinkColor != Color.Empty)
            {
                objCell.VisitedLinkColorInternal = this.VisitedLinkColor;
            }
            if (this.mblnLinkVisitedSet)
            {
                objCell.LinkVisited = this.LinkVisited;
            }
            if (this.Url != string.Empty)
            {
                objCell.Url = this.Url;
            }
            objCell.ClientMode = this.ClientMode;
            return objCell;
        }

        /// <summary>
        /// Gets the value of the cell.
        /// </summary>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        /// <returns>
        /// The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> property is less than 0, indicating that the cell is a row header cell.</exception>
        protected override object GetValue(int intRowIndex)
        {
            if (((this.UseColumnTextForLinkValue && (base.DataGridView != null)) && ((base.DataGridView.NewRowIndex != intRowIndex) && (base.OwningColumn != null))) && (base.OwningColumn is DataGridViewLinkColumn))
            {
                return ((DataGridViewLinkColumn)base.OwningColumn).Text;
            }
            return base.GetValue(intRowIndex);
        }

        private bool LinkBoundsContainPoint(int intX, int intY, int intRowIndex)
        {
            return false;
        }

        /// <summary>
        /// Shoulds the color of the serialize active link.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeActiveLinkColor()
        {
            return !this.ActiveLinkColor.Equals(LinkUtilities.IEActiveLinkColor);
        }

        /// <summary>
        /// Shoulds the color of the serialize link.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeLinkColor()
        {
            return !this.LinkColor.Equals(LinkUtilities.IELinkColor);
        }

        /// <summary>
        /// Shoulds the color of the serialize visited link.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeVisitedLinkColor()
        {
            return !this.VisitedLinkColor.Equals(LinkUtilities.IEVisitedLinkColor);
        }

        /// <summary>
        /// Returns a string that describes the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return ("DataGridViewLinkCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + base.RowIndex.ToString(CultureInfo.CurrentCulture) + " }");
        }

        /// <summary>
        /// Open the Link in the URL in a new window
        /// </summary>
        protected void OpenLink()
        {
            // if the URL exists
            if (!this.ClientMode && !String.IsNullOrEmpty(this.Url))
            {
                //Create a link from the URL
                LinkLabel.Link objLink = new LinkLabel.Link(this.Url);

                // If not in Client mode and Link is not null
                if (objLink != null)
                {
                    LinkLabel.Link.Open(objLink);
                }
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>Gets or sets the color used to display an active link.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to display a link that is being selected. The default value is the user's Internet Explorer setting for the color of links in the hover state. </returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
        public Color ActiveLinkColor
        {
            get
            {
                if (mobjLinkActiveColor != null)
                {
                    return mobjLinkActiveColor;
                }
                return LinkUtilities.IEActiveLinkColor;
            }
            set
            {
                if (!value.Equals(this.ActiveLinkColor))
                {
                    mobjLinkActiveColor = value;
                    if (base.DataGridView != null)
                    {
                        if (base.RowIndex != -1)
                        {
                            base.DataGridView.InvalidateCell(this);
                        }
                        else
                        {
                            base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the active link color internal.
        /// </summary>
        /// <value>The active link color internal.</value>
        internal Color ActiveLinkColorInternal
        {
            set
            {
                if (!value.Equals(this.ActiveLinkColor))
                {
                    mobjLinkActiveColor = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url
        {
            get
            {
                return this.mstrUrl;
            }
            set
            {
                // If the value has changed
                if (this.mstrUrl != value)
                {
                    this.mstrUrl = value;
                    this.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [client mode].
        /// Setting a value to the cell does not change the ClientMode property of the containing column.
        /// </summary>
        /// <value><c>true</c> if [client mode]; otherwise, <c>false</c>.</value>
        [SRDescription("DataGridView_LinkCellClientModeDescr"), SRCategory("CatBehavior"), DefaultValue(false)]
        public bool ClientMode
        {
            get
            {
                return this.mblnClientMode;
            }
            set
            {
                //If the value has changed
                if (this.mblnClientMode != value)
                {
                    this.mblnClientMode = value;
                    this.Update();
                }
            }
        }

        /// <summary>Gets the type of the cell's hosted editing control.</summary>
        /// <returns>Always null. </returns>
        /// <filterpriority>1</filterpriority>
        public override Type EditType
        {
            get
            {
                return null;
            }
        }

        /// <summary>Gets the display <see cref="T:System.Type"></see> of the cell value.</summary>
        /// <returns>Always <see cref="T:System.String"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override Type FormattedValueType
        {
            get
            {
                return mobjDefaultFormattedValueType;
            }
        }

        /// <summary>Gets or sets a value that represents the behavior of a link.</summary>
        /// <returns>One of the <see cref="T:System.Windows.Forms.LinkBehavior"></see> values. The default is <see cref="F:System.Windows.Forms.LinkBehavior.SystemDefault"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:System.Windows.Forms.LinkBehavior"></see> value.</exception>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(0)]
        public LinkBehavior LinkBehavior
        {
            get
            {
                return menmLinkBehavior;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(LinkBehavior));
                }
                if (value != this.LinkBehavior)
                {
                    menmLinkBehavior = value;
                    if (base.DataGridView != null)
                    {
                        if (base.RowIndex != -1)
                        {
                            base.DataGridView.InvalidateCell(this);
                        }
                        else
                        {
                            base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the link behavior internal.
        /// </summary>
        /// <value>The link behavior internal.</value>
        internal LinkBehavior LinkBehaviorInternal
        {
            set
            {
                if (value != this.LinkBehavior)
                {
                    menmLinkBehavior = value;
                }
            }
        }

        /// <summary>Gets or sets the color used to display an inactive and unvisited link.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to initially display a link. The default value is the user's Internet Explorer setting for the link color.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
        public Color LinkColor
        {
            get
            {
                if (mobjLinkColor != null)
                {
                    return mobjLinkColor;
                }
                return LinkUtilities.IELinkColor;
            }
            set
            {
                if (!value.Equals(this.LinkColor))
                {
                    mobjLinkColor = value;
                    if (base.DataGridView != null)
                    {
                        if (base.RowIndex != -1)
                        {
                            base.DataGridView.InvalidateCell(this);
                        }
                        else
                        {
                            base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the link color internal.
        /// </summary>
        /// <value>The link color internal.</value>
        internal Color LinkColorInternal
        {
            set
            {
                if (!value.Equals(this.LinkColor))
                {
                    mobjLinkColor = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the state of the link.
        /// </summary>
        /// <value>The state of the link.</value>
        private LinkState LinkState
        {
            get
            {
                return menmLinkState;
            }
            set
            {
                if (this.LinkState != value)
                {
                    menmLinkState = value;
                }
            }
        }


        /// <summary>Gets or sets a value indicating whether the link was visited.</summary>
        /// <returns>true if the link has been visited; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        public bool LinkVisited
        {
            get
            {
                return this.mblnLinkVisitedSet && this.mblnLinkVisited;
            }
            set
            {
                this.mblnLinkVisitedSet = true;
                if (value != this.LinkVisited)
                {
                    this.mblnLinkVisited = value; ;
                    if (base.DataGridView != null)
                    {
                        if (base.RowIndex != -1)
                        {
                            base.DataGridView.InvalidateCell(this);
                        }
                        else
                        {
                            base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the link changes color when it is visited.</summary>
        /// <returns>true if the link changes color when it is selected; otherwise, false. The default is true.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(true)]
        public bool TrackVisitedState
        {
            get
            {
                return (mintLinkTrackVisitedState != 0);
            }
            set
            {
                if (value != this.TrackVisitedState)
                {
                    mintLinkTrackVisitedState = value ? 1 : 0;
                    if (base.DataGridView != null)
                    {
                        if (base.RowIndex != -1)
                        {
                            base.DataGridView.InvalidateCell(this);
                        }
                        else
                        {
                            base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets a value indicating whether [track visited state internal].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [track visited state internal]; otherwise, <c>false</c>.
        /// </value>
        internal bool TrackVisitedStateInternal
        {
            set
            {
                if (value != this.TrackVisitedState)
                {
                    mintLinkTrackVisitedState = value ? 1 : 0;
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the column <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.Text"></see> property value is displayed as the link text.</summary>
        /// <returns>true if the column <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.Text"></see> property value is displayed as the link text; false if the cell <see cref="P:System.Windows.Forms.DataGridViewCell.FormattedValue"></see> property value is displayed as the link text. The default is false.</returns>
        [DefaultValue(false)]
        public bool UseColumnTextForLinkValue
        {
            get
            {
                return (mintLinkUseColumnTextForLinkValue != 0);
            }
            set
            {
                if (value != this.UseColumnTextForLinkValue)
                {
                    mintLinkUseColumnTextForLinkValue = value ? 1 : 0;
                    base.OnCommonChange();
                }
            }
        }

        /// <summary>
        /// Sets a value indicating whether [use column text for link value internal].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [use column text for link value internal]; otherwise, <c>false</c>.
        /// </value>
        internal bool UseColumnTextForLinkValueInternal
        {
            set
            {
                if (value != this.UseColumnTextForLinkValue)
                {
                    mintLinkUseColumnTextForLinkValue = value ? 1 : 0;
                }
            }
        }

        /// <summary>
        /// Gets or sets the data type of the values in the cell.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:System.Type"></see> representing the data type of the value in the cell.</returns>
        public override Type ValueType
        {
            get
            {
                Type objValueType = base.ValueType;
                if (objValueType != null)
                {
                    return objValueType;
                }
                return mobjDefaultValueType;
            }
        }

        /// <summary>Gets or sets the color used to display a link that has been previously visited.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to display a link that has been visited. The default value is the user's Internet Explorer setting for the visited link color.</returns>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
        public Color VisitedLinkColor
        {
            get
            {
                if (mobjLinkVisitedLinkColor != null)
                {
                    return mobjLinkVisitedLinkColor;
                }
                return LinkUtilities.IEVisitedLinkColor;
            }
            set
            {
                if (!value.Equals(this.VisitedLinkColor))
                {
                    mobjLinkVisitedLinkColor = value;
                    if (base.DataGridView != null)
                    {
                        if (base.RowIndex != -1)
                        {
                            base.DataGridView.InvalidateCell(this);
                        }
                        else
                        {
                            base.DataGridView.InvalidateColumnInternal(base.ColumnIndex);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the visited link color internal.
        /// </summary>
        /// <value>The visited link color internal.</value>
        internal Color VisitedLinkColorInternal
        {
            set
            {
                if (!value.Equals(this.VisitedLinkColor))
                {
                    mobjLinkVisitedLinkColor = value;
                }
            }
        }

        /// <summary>
        /// Gets the color of the inherited link.
        /// </summary>
        /// <value>The color of the inherited link.</value>
        private Color InheritedLinkColor
        {
            get
            {
                Color objColor = this.LinkColor;

                if (objColor == LinkUtilities.IELinkColor &&
                    this.OwningColumn != null &&
                    this.OwningColumn is DataGridViewLinkColumn)
                {
                    objColor = ((DataGridViewLinkColumn)this.OwningColumn).LinkColor;

                }

                return objColor;
            }
        }

        /// <summary>
        /// Gets the color of the inherited active link.
        /// </summary>
        /// <value>The color of the inherited active link.</value>
        private Color InheritedActiveLinkColor
        {
            get
            {
                Color objColor = this.ActiveLinkColor;

                if (objColor == LinkUtilities.IEActiveLinkColor &&
                    this.OwningColumn != null &&
                    this.OwningColumn is DataGridViewLinkColumn)
                {
                    objColor = ((DataGridViewLinkColumn)this.OwningColumn).ActiveLinkColor;

                }

                return objColor;
            }
        }

        /// <summary>
        /// Gets the color of the inherited visited link.
        /// </summary>
        /// <value>The color of the inherited visited link.</value>
        private Color InheritedVisitedLinkColor
        {
            get
            {
                Color objColor = this.VisitedLinkColor;

                if (objColor == LinkUtilities.IEVisitedLinkColor &&
                    this.OwningColumn != null &&
                    this.OwningColumn is DataGridViewLinkColumn)
                {
                    objColor = ((DataGridViewLinkColumn)this.OwningColumn).VisitedLinkColor;

                }

                return objColor;
            }
        }

        #endregion Properties

    }

    #endregion

    #region DataGridViewHeaderCells

    #region DataGridViewColumnHeaderCell Class

    /// <summary>Represents a column header in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public class DataGridViewColumnHeaderCell : DataGridViewHeaderCell
    {
        #region Members

        #region Static

        #region Serializable Properties


        #endregion Serializable Properties

        #endregion Static

        #region Private Members

        private SortOrder menmSortGlyphDirection;

        private DataGridViewHeaderFilterComboBox mobjFilterComboBox;

        private bool mblnShouldPreRenderHeaderFilter = false;

        new private static Type mobjCellType;

        #endregion Private Members

        #region Constants

        private const byte DATAGRIDVIEWCOLUMNHEADERCELL_horizontalTextMarginLeft = 2;
        private const byte DATAGRIDVIEWCOLUMNHEADERCELL_horizontalTextMarginRight = 2;
        private const byte DATAGRIDVIEWCOLUMNHEADERCELL_sortGlyphHeight = 7;
        private const byte DATAGRIDVIEWCOLUMNHEADERCELL_sortGlyphHorizontalMargin = 4;
        private const byte DATAGRIDVIEWCOLUMNHEADERCELL_sortGlyphSeparatorWidth = 2;
        private const byte DATAGRIDVIEWCOLUMNHEADERCELL_sortGlyphWidth = 9;
        private const byte DATAGRIDVIEWCOLUMNHEADERCELL_verticalMargin = 1;

        #endregion Constants

        #endregion Members

        #region C'tors / D'tors

        static DataGridViewColumnHeaderCell()
        {
            DataGridViewColumnHeaderCell.mobjCellType = typeof(DataGridViewColumnHeaderCell);
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see> class.</summary>
        public DataGridViewColumnHeaderCell()
        {
            this.SortGlyphDirectionInternal = SortOrder.None;
        }

        #endregion C'tors / D'tors

        #region Methods

        #region Render

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected internal override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            switch (objEvent.Type)
            {
                case "Click":
                    FireColumnHeaderMouseClick(objEvent);
                    break;

                case "DoubleClick":
                    FireColumnHeaderMouseClick(objEvent);
                    FireColumnHeaderMouseDoubleClick(objEvent);
                    break;
            }
        }


        /// <summary>
        /// Fires the column header mouse click.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        protected virtual void FireColumnHeaderMouseClick(IEvent objEvent)
        {
            if (this.DataGridView != null)
            {
                // Get x and coordinates.
                int intX = GetEventValue(objEvent, "X", 0);
                int intY = GetEventValue(objEvent, "Y", 0);

                this.DataGridView.FireColumnHeaderMouseClick(new DataGridViewCellMouseEventArgs(this.ColumnIndex, this.RowIndex, 0, 0, new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, intX, intY, 0)));

                if (this.DataGridView != null)
                {
                    this.DataGridView.Update();
                }
            }
        }

        /// <summary>
        /// Fires the column header mouse double click.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        protected virtual void FireColumnHeaderMouseDoubleClick(IEvent objEvent)
        {
            if (this.DataGridView != null)
            {
                // Get x and coordinates.
                int intX = GetEventValue(objEvent, "X", 0);
                int intY = GetEventValue(objEvent, "Y", 0);

                this.DataGridView.FireColumnHeaderMouseDoubleClick(new DataGridViewCellMouseEventArgs(this.ColumnIndex, this.RowIndex, 0, 0, new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, intX, intY, 0)));
            }
        }

        /// <summary>
        /// Renders a header- cell's attributes
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
        {
            base.RenderAttributes(objContext, objWriter, blnRenderOwner);

            if (this.SortGlyphDirection != SortOrder.None)
            {
                objWriter.WriteAttributeString(WGAttributes.SortOrder, (this.SortGlyphDirection == SortOrder.Descending) ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the cell style attributes.
        /// </summary>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objCellStyle">The cell style.</param>
        protected override void RenderCellStyleAttributes(IAttributeWriter objWriter, DataGridViewCellStyle objCellStyle)
        {
            base.RenderCellStyleAttributes(objWriter, objCellStyle);

                    if (objCellStyle != null)
                    {
                // Render Text-Align.
                objWriter.WriteAttributeString(WGAttributes.TextAlign, objCellStyle.Alignment.ToString());
            }
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="lngRequestID">The request ID.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        protected override void RenderComponents(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            base.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);

            DataGridViewColumn objCol = this.OwningColumn;
            if (objCol != null && this.OwningColumn.ShowHeaderFilter)
            {
                // Check contained filter combo.
                if (mobjFilterComboBox != null)
                {
                    // Render contained filter combo.
                    mobjFilterComboBox.RenderControl(objContext, objWriter, lngRequestID);
                }
            }
        }

        /// <summary>
        /// Prerenders component.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="lngRequestID">The request ID.</param>
        /// <param name="blnForcePreRender">if set to <c>true</c> [BLN force pre render].</param>
        internal override void PreRenderComponent(IContext objContext, long lngRequestID, bool blnForcePreRender)
        {
            base.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);

            // Initialize filter ComboBox values
            if (this.ShouldPreRenderHeaderFilter)
            {
                this.FilterComboBox.InitializeFilterValues(true, true,false);
                this.ShouldPreRenderHeaderFilter = false;
            }
        }

        /// <summary>
        /// Selected index changed event handler of the filter combo box.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FilterComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            // Get datagridview
            DataGridView objDataGridView = this.DataGridView;
            if (objDataGridView != null)
            {
                // Validate DataGridView is not in suspend mode
                if (!objDataGridView.mblnSuspendFilterInitialization)
                {
                    // Get selected item
                    DataGridViewSystemFilterOption objSelectedItem = this.FilterComboBox.SelectedItem as DataGridViewSystemFilterOption;

                    // Check if selected item is 'custom' item
                    if (objSelectedItem != null && objSelectedItem.Option == SystemFilterOptions.Custom)
                    {
                        // Inform grid to open custm filter dialog
                        objDataGridView.OpenCustomFilterDialog(this);
                    }
                    else
                    {
                        // Set filter initialization suspension.
                        objDataGridView.mblnSuspendFilterInitialization = true;

                        // Clear filter row cell filter.
                        if (objDataGridView.ShowFilterRow && objDataGridView.FilterRow != null && objDataGridView.FilterRow.Cells.Count > 0)
                        {
                            (objDataGridView.FilterRow.Cells[this.OwningColumn.Index] as DataGridViewFilterCell).ClearFilter(false);
                        }

                        // Clear column's custom filter value
                        this.OwningColumn.mstrCustomFilterExpression = string.Empty;

                        // Fire DataGridView FilterCellFilterChanged.
                        objDataGridView.ApplyDataGridViewFilter();

                        // Set filter initialization suspension.
                        objDataGridView.mblnSuspendFilterInitialization = false;
                    }
                }
            }
        }


        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (this.DataGridView != null)
            {
                // Register the column header click event if:
                // 1. Sort mode is other then NotSortable.
                // 2. Column header mouse click is registered on the data grid view.
                if ((this.OwningColumn != null && this.OwningColumn.SortMode != DataGridViewColumnSortMode.NotSortable) || this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSECLICK))
                {
                    objEvents.Set(WGEvents.Click);
                    objEvents.Set(WGEvents.RightClick);
                }
                if (this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCOLUMNHEADERMOUSEDOUBLECLICK))
                {
                    objEvents.Set(WGEvents.DoubleClick);
                }
            }
            return objEvents;
        }

        #endregion Render

        /// <summary>
        /// Determines whether [has wrap mode] [the specified obj cell style].
        /// </summary>
        /// <param name="objCellStyle">The obj cell style.</param>
        /// <returns>
        ///   <c>true</c> if [has wrap mode] [the specified obj cell style]; otherwise, <c>false</c>.
        /// </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool HasWrapMode(DataGridViewCellStyle objCellStyle)
        {
            DataGridViewColumn objCol = this.OwningColumn;
            if (objCol != null)
            {
                if (objCol.AutoSizeMode != DataGridViewAutoSizeColumnMode.NotSet)
                {
                    switch (objCol.AutoSizeMode)
                    {
                        case DataGridViewAutoSizeColumnMode.AllCellsExceptHeader:
                        case DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader:
                        case DataGridViewAutoSizeColumnMode.Fill:
                        case DataGridViewAutoSizeColumnMode.None:
                            if (objCellStyle != null && objCellStyle.WrapMode == DataGridViewTriState.True)
                                return true;
                            else
                                return false;
                        default:
                            return false;
                    }
                }
            }


            DataGridView objDataGridView = this.DataGridView;
            if (objDataGridView != null)
            {
                switch (objDataGridView.AutoSizeColumnsMode)
                {
                    case DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader:
                    case DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader:
                    case DataGridViewAutoSizeColumnsMode.Fill:
                    case DataGridViewAutoSizeColumnsMode.None:
                        if (objCellStyle != null && objCellStyle.WrapMode == DataGridViewTriState.True)
                            return true;
                        else
                            return false;
                }
            }

            return false;
        }


        /// <summary>
        /// Creates an exact copy of this cell.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see>.
        /// </returns>
        public override object Clone()
        {
            DataGridViewColumnHeaderCell objCell;
            Type objType = base.GetType();
            if (objType == DataGridViewColumnHeaderCell.mobjCellType)
            {
                objCell = new DataGridViewColumnHeaderCell();
            }
            else
            {
                objCell = (DataGridViewColumnHeaderCell)Activator.CreateInstance(objType);
            }
            base.CloneInternal(objCell);
            objCell.Value = base.Value;
            return objCell;
        }

        /// <summary>Retrieves the formatted value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</summary>
        /// <returns>A <see cref="T:System.Object"></see> that represents the value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</returns>
        /// <param name="blnInLastRow">true to indicate that the cell is in the last row of the region defined by the selected cells; otherwise, false.</param>
        /// <param name="blnInFirstRow">true to indicate that the cell is in the first row of the region defined by the selected cells; otherwise, false.</param>
        /// <param name="blnLastCell">true to indicate that the cell is the last column of the region defined by the selected cells; otherwise, false.</param>
        /// <param name="strFormat">The current format string of the cell.</param>
        /// <param name="blnFirstCell">true to indicate that the cell is in the first column of the region defined by the selected cells; otherwise, false.</param>
        /// <param name="intRowIndex">The zero-based index of the row containing the cell.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
        protected override object GetClipboardContent(int intRowIndex, bool blnFirstCell, bool blnLastCell, bool blnInFirstRow, bool blnInLastRow, string strFormat)
        {
            if (intRowIndex != -1)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            if (base.DataGridView == null)
            {
                return null;
            }
            object obj1 = this.GetValue(intRowIndex);
            StringBuilder builder1 = new StringBuilder(0x40);
            if (ClientUtils.IsEquals(strFormat, DataFormats.Html, StringComparison.OrdinalIgnoreCase))
            {
                if (blnFirstCell)
                {
                    builder1.Append("<TABLE>");
                    builder1.Append("<THEAD>");
                }
                builder1.Append("<TH>");
                if (obj1 != null)
                {
                    DataGridViewCell.FormatPlainTextAsHtml(obj1.ToString(), new StringWriter(builder1, CultureInfo.CurrentCulture));
                }
                else
                {
                    builder1.Append("&nbsp;");
                }
                builder1.Append("</TH>");
                if (blnLastCell)
                {
                    builder1.Append("</THEAD>");
                    if (blnInLastRow)
                    {
                        builder1.Append("</TABLE>");
                    }
                }
                return builder1.ToString();
            }
            bool blnFlag1 = ClientUtils.IsEquals(strFormat, DataFormats.CommaSeparatedValue, StringComparison.OrdinalIgnoreCase);
            if ((!blnFlag1 && !ClientUtils.IsEquals(strFormat, DataFormats.Text, StringComparison.OrdinalIgnoreCase)) && !ClientUtils.IsEquals(strFormat, DataFormats.UnicodeText, StringComparison.OrdinalIgnoreCase))
            {
                return null;
            }
            if (obj1 != null)
            {
                bool blnFlag2 = false;
                int num1 = builder1.Length;
                DataGridViewCell.FormatPlainText(obj1.ToString(), blnFlag1, new StringWriter(builder1, CultureInfo.CurrentCulture), ref blnFlag2);
                if (blnFlag2)
                {
                    builder1.Insert(num1, '"');
                }
            }
            if (blnLastCell)
            {
                if (!blnInLastRow)
                {
                    builder1.Append('\r');
                    builder1.Append('\n');
                }
            }
            else
            {
                builder1.Append(blnFlag1 ? ',' : '\t');
            }
            return builder1.ToString();
        }

        /// <summary>Gets the style applied to the cell. </summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that includes the style settings of the cell inherited from the cell's parent row, column, and <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
        /// <param name="objInheritedCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be populated with the inherited cell style. </param>
        /// <param name="blnIncludeColors">true to include inherited colors in the returned cell style; otherwise, false. </param>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
        public override DataGridViewCellStyle GetInheritedStyle(DataGridViewCellStyle objInheritedCellStyle, int intRowIndex, bool blnIncludeColors)
        {
            if (intRowIndex != -1)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            DataGridViewCellStyle objDataGridViewCellStyle1 = (objInheritedCellStyle == null) ? new DataGridViewCellStyle() : objInheritedCellStyle;
            DataGridViewCellStyle objDataGridViewCellStyle2 = null;
            if (base.HasStyle)
            {
                objDataGridViewCellStyle2 = base.Style;
            }
            DataGridViewCellStyle objDataGridViewCellStyle3 = base.DataGridView.ColumnHeadersDefaultCellStyle;
            DataGridViewCellStyle objDataGridViewCellStyle4 = base.DataGridView.DefaultCellStyle;
            if (blnIncludeColors)
            {
                if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.BackColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.BackColor = objDataGridViewCellStyle2.BackColor;
                }
                else if (!objDataGridViewCellStyle3.BackColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.BackColor = objDataGridViewCellStyle3.BackColor;
                }
                else
                {
                    objDataGridViewCellStyle1.BackColor = objDataGridViewCellStyle4.BackColor;
                }
                if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.ForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.ForeColor = objDataGridViewCellStyle2.ForeColor;
                }
                else if (!objDataGridViewCellStyle3.ForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.ForeColor = objDataGridViewCellStyle3.ForeColor;
                }
                else
                {
                    objDataGridViewCellStyle1.ForeColor = objDataGridViewCellStyle4.ForeColor;
                }
                if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.SelectionBackColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.SelectionBackColor = objDataGridViewCellStyle2.SelectionBackColor;
                }
                else if (!objDataGridViewCellStyle3.SelectionBackColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.SelectionBackColor = objDataGridViewCellStyle3.SelectionBackColor;
                }
                else
                {
                    objDataGridViewCellStyle1.SelectionBackColor = objDataGridViewCellStyle4.SelectionBackColor;
                }
                if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.SelectionForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.SelectionForeColor = objDataGridViewCellStyle2.SelectionForeColor;
                }
                else if (!objDataGridViewCellStyle3.SelectionForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle1.SelectionForeColor = objDataGridViewCellStyle3.SelectionForeColor;
                }
                else
                {
                    objDataGridViewCellStyle1.SelectionForeColor = objDataGridViewCellStyle4.SelectionForeColor;
                }
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.Font != null))
            {
                objDataGridViewCellStyle1.Font = objDataGridViewCellStyle2.Font;
            }
            else if (objDataGridViewCellStyle3.Font != null)
            {
                objDataGridViewCellStyle1.Font = objDataGridViewCellStyle3.Font;
            }
            else
            {
                objDataGridViewCellStyle1.Font = objDataGridViewCellStyle4.Font;
            }
            if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.IsNullValueDefault)
            {
                objDataGridViewCellStyle1.NullValue = objDataGridViewCellStyle2.NullValue;
            }
            else if (!objDataGridViewCellStyle3.IsNullValueDefault)
            {
                objDataGridViewCellStyle1.NullValue = objDataGridViewCellStyle3.NullValue;
            }
            else
            {
                objDataGridViewCellStyle1.NullValue = objDataGridViewCellStyle4.NullValue;
            }
            if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.IsDataSourceNullValueDefault)
            {
                objDataGridViewCellStyle1.DataSourceNullValue = objDataGridViewCellStyle2.DataSourceNullValue;
            }
            else if (!objDataGridViewCellStyle3.IsDataSourceNullValueDefault)
            {
                objDataGridViewCellStyle1.DataSourceNullValue = objDataGridViewCellStyle3.DataSourceNullValue;
            }
            else
            {
                objDataGridViewCellStyle1.DataSourceNullValue = objDataGridViewCellStyle4.DataSourceNullValue;
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.Format.Length != 0))
            {
                objDataGridViewCellStyle1.Format = objDataGridViewCellStyle2.Format;
            }
            else if (objDataGridViewCellStyle3.Format.Length != 0)
            {
                objDataGridViewCellStyle1.Format = objDataGridViewCellStyle3.Format;
            }
            else
            {
                objDataGridViewCellStyle1.Format = objDataGridViewCellStyle4.Format;
            }
            if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.IsFormatProviderDefault)
            {
                objDataGridViewCellStyle1.FormatProvider = objDataGridViewCellStyle2.FormatProvider;
            }
            else if (!objDataGridViewCellStyle3.IsFormatProviderDefault)
            {
                objDataGridViewCellStyle1.FormatProvider = objDataGridViewCellStyle3.FormatProvider;
            }
            else
            {
                objDataGridViewCellStyle1.FormatProvider = objDataGridViewCellStyle4.FormatProvider;
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.Alignment != DataGridViewContentAlignment.NotSet))
            {
                objDataGridViewCellStyle1.AlignmentInternal = objDataGridViewCellStyle2.Alignment;
            }
            else if (objDataGridViewCellStyle3.Alignment != DataGridViewContentAlignment.NotSet)
            {
                objDataGridViewCellStyle1.AlignmentInternal = objDataGridViewCellStyle3.Alignment;
            }
            else
            {
                objDataGridViewCellStyle1.AlignmentInternal = objDataGridViewCellStyle4.Alignment;
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.WrapMode != DataGridViewTriState.NotSet))
            {
                objDataGridViewCellStyle1.WrapModeInternal = objDataGridViewCellStyle2.WrapMode;
            }
            else if (objDataGridViewCellStyle3.WrapMode != DataGridViewTriState.NotSet)
            {
                objDataGridViewCellStyle1.WrapModeInternal = objDataGridViewCellStyle3.WrapMode;
            }
            else
            {
                objDataGridViewCellStyle1.WrapModeInternal = objDataGridViewCellStyle4.WrapMode;
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.Tag != null))
            {
                objDataGridViewCellStyle1.Tag = objDataGridViewCellStyle2.Tag;
            }
            else if (objDataGridViewCellStyle3.Tag != null)
            {
                objDataGridViewCellStyle1.Tag = objDataGridViewCellStyle3.Tag;
            }
            else
            {
                objDataGridViewCellStyle1.Tag = objDataGridViewCellStyle4.Tag;
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.Padding != Padding.Empty))
            {
                objDataGridViewCellStyle1.PaddingInternal = objDataGridViewCellStyle2.Padding;
                return objDataGridViewCellStyle1;
            }
            if (objDataGridViewCellStyle3.Padding != Padding.Empty)
            {
                objDataGridViewCellStyle1.PaddingInternal = objDataGridViewCellStyle3.Padding;
                return objDataGridViewCellStyle1;
            }
            objDataGridViewCellStyle1.PaddingInternal = objDataGridViewCellStyle4.Padding;
            return objDataGridViewCellStyle1;
        }

        /// <summary>Gets the value of the cell. </summary>
        /// <returns>The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see>.</returns>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
        protected override object GetValue(int intRowIndex)
        {
            if (intRowIndex != -1)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            if (this.ContainsLocalValue)
            {
                return this.LocalValue;
            }
            if (base.OwningColumn != null)
            {
                return base.OwningColumn.Name;
            }
            return null;
        }

        /// <summary>
        /// Calculates the preferred size, in pixels, of the cell.
        /// </summary>
        /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to draw the cell.</param>
        /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
        /// <param name="intRowIndex">The zero-based row index of the cell.</param>
        /// <param name="objConstraintSize">The cell's maximum allowable size.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.
        /// </returns>
        protected override Size GetPreferredSize(Graphics objGraphics, DataGridViewCellStyle objCellStyle, int intRowIndex, Size objConstraintSize)
        {
            // When constrained by width, must subtract width of 'control' items before calculating preferred width of contaned items.
            // After calculating width of contained items, add to calculated width of contained items, both when constrained by height and width
            int intExtraObjectsWidth = 0;

            // Get owning grid.
            DataGridView objDataGridView = this.DataGridView;

            if (objDataGridView != null)
            {
                DataGridViewColumn objOwningColumn = this.OwningColumn;
                DataGridViewSkin objDataGridViewSkin = DataGridView.Skin as DataGridViewSkin;

                if (objDataGridViewSkin != null && objOwningColumn != null)
                {
                    // Check that owning column allows sorting
                    if (objOwningColumn.SortMode != DataGridViewColumnSortMode.NotSortable)
                    {
                        // Add arrow image width to preffered size.
                        intExtraObjectsWidth += Math.Max(objDataGridViewSkin.SortAscendingIndicatorImageSize.Width, objDataGridViewSkin.SortDescendingIndicatorImageSize.Width);
                    }

                    // When there's a filtering row, the column headers have this little icon beside them - so we need to calculate that too.
                    if (objOwningColumn.HasFilterInfo())
                    {
                        int intWidth;

                        if (int.TryParse(objDataGridViewSkin.HeaderFilterComboBoxImageWidth.GetValue(VWGContext.Current), out intWidth))
                        {
                            intExtraObjectsWidth += intWidth;
                        }
                    }
                }
            }

            // Default to constrained size
            Size objSize = objConstraintSize;

            // If constrained by Width, deduct extra controls width before calculating content preferred width
            if (objConstraintSize.Height == 0)
            {
                objSize = new Size(Math.Max(0, objConstraintSize.Width - intExtraObjectsWidth), objSize.Height);
            }

            // Try get base value. Will throw exception on certain scenarios for headers where grid is being disposed, catch it and use constrained size.
            try
            {
                Size objRealSize = base.GetPreferredSize(objGraphics, objCellStyle, intRowIndex, objSize);
                objSize = objRealSize;
            }
            catch (Exception ex)
            {
            }

            // Add width of extra objects to calculated content preferred width
            return new Size(objSize.Width + intExtraObjectsWidth, objSize.Height + DefaultVerticalPadding);
        }

        /// <summary>Sets the value of the cell. </summary>
        /// <returns>true if the value has been set; otherwise false.</returns>
        /// <param name="intRowIndex">The index of the cell's parent row. </param>
        /// <param name="objValue">The cell value to set. </param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
        protected override bool SetValue(int intRowIndex, object objValue)
        {
            if (intRowIndex != -1)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            object obj1 = this.GetValue(intRowIndex);

            this.LocalValue = objValue;

            if ((base.DataGridView != null) && (obj1 != objValue))
            {
                base.RaiseCellValueChanged(new DataGridViewCellEventArgs(base.ColumnIndex, -1));
            }

            return true;
        }

        public override string ToString()
        {
            return ("DataGridViewColumnHeaderCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + " }");
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets the coll span.
        /// </summary>
        /// <value>
        /// The coll span.
        /// </value>
        public override int Colspan
        {
            get
            {
                return base.Colspan;
            }
            set
            {
                if (value > 1)
                {
                    throw new NotSupportedException("Header cell does not support col span");
                }
                base.Colspan = value;
            }
        }

        /// <summary>
        /// Gets or sets the row span.
        /// </summary>
        /// <value>
        /// The row span.
        /// </value>
        public override int Rowspan
        {
            get
            {
                return base.Rowspan;
            }
            set
            {
                if (value > 1)
                {
                    throw new NotSupportedException("Header cell does not support row span");
                }
                base.Rowspan = value;
            }
        }

        /// <summary>
        /// Gets the filter combo box.
        /// </summary>
        [Browsable(false)]
        public DataGridViewHeaderFilterComboBox FilterComboBox
        {
            get
            {
                if (mobjFilterComboBox == null)
                {
                    mobjFilterComboBox = new DataGridViewHeaderFilterComboBox(this);
                    mobjFilterComboBox.SelectedIndexChanged += new EventHandler(FilterComboBoxSelectedIndexChanged);
                }
                return mobjFilterComboBox;
            }
        }

        /// <summary>Gets or sets a value indicating which sort glyph is displayed.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.SortOrder"></see> value representing the current glyph. The default is <see cref="F:Gizmox.WebGUI.Forms.SortOrder.None"></see>. </returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.SortOrder"></see> value.</exception>
        /// <exception cref="T:System.InvalidOperationException">When setting this property, the value of either the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningColumn"></see> property or the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is null.-or-When changing the value of this property, the specified value is not <see cref="F:Gizmox.WebGUI.Forms.SortOrder.None"></see> and the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumn.SortMode"></see> property of the owning column is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode.NotSortable"></see>.</exception>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public SortOrder SortGlyphDirection
        {
            get
            {
                return this.menmSortGlyphDirection;
            }
            set
            {
                if (!Gizmox.WebGUI.Forms.ClientUtils.IsEnumValid(value, (int)value, 0, 2))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(SortOrder));
                }
                if ((base.OwningColumn == null) || (base.DataGridView == null))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_CellDoesNotYetBelongToDataGridView"));
                }
                if (value != this.SortGlyphDirection)
                {
                    if ((base.OwningColumn.SortMode == DataGridViewColumnSortMode.NotSortable) && (value != SortOrder.None))
                    {
                        throw new InvalidOperationException(SR.GetString("DataGridViewColumnHeaderCell_SortModeAndSortGlyphDirectionClash", new object[] { value.ToString() }));
                    }
                    this.SortGlyphDirectionInternal = value;
                    base.DataGridView.OnSortGlyphDirectionChanged(this);

                    this.Update();
                }
            }
        }

        /// <summary>
        /// Sets the sort glyph direction internal.
        /// </summary>
        /// <value>The sort glyph direction internal.</value>
        internal SortOrder SortGlyphDirectionInternal
        {
            set
            {
                this.menmSortGlyphDirection = value;
            }
        }

        /// <summary>Retrieves the inherited shortcut menu for the specified row.</summary>
        /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> of the column headers if one exists; otherwise, the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> inherited from <see cref="T:System.Windows.Forms.DataGridView"></see>.</returns>
        /// <param name="intRowIndex">The index of the row to get the <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> of. The index must be -1 to indicate the row of column headers.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
        public override ContextMenu GetInheritedContextMenu(int intRowIndex)
        {
            if (intRowIndex != -1)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            ContextMenu objContextMenu = base.GetContextMenu(-1);
            if (objContextMenu != null)
            {
                return objContextMenu;
            }
            if (base.DataGridView != null)
            {
                return base.DataGridView.ContextMenu;
            }
            return null;
        }

        /// <summary>
        /// Gets the inherited context menu strip.
        /// </summary>
        /// <param name="intRowIndex">Index of the int row.</param>
        /// <returns></returns>
        public override ContextMenuStrip GetInheritedContextMenuStrip(int intRowIndex)
        {
            if (intRowIndex != -1)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            ContextMenuStrip objContextMenuStrip = base.GetContextMenuStrip(-1);
            if (objContextMenuStrip != null)
            {
                return objContextMenuStrip;
            }
            if (base.DataGridView != null)
            {
                return base.DataGridView.ContextMenuStrip;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string MemberID
        {
            get
            {
                return "CHC" + this.ColumnIndex;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [should pre render header filter].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [should pre render header filter]; otherwise, <c>false</c>.
        /// </value>
        internal bool ShouldPreRenderHeaderFilter
        {
            get
            {
                return mblnShouldPreRenderHeaderFilter;
            }
            set
            {
                mblnShouldPreRenderHeaderFilter = value;
            }
        }

        #endregion Properties

    }

    #endregion

    #region DataGridViewRowHeaderCell Class

    /// <summary>
    /// Represents a row header of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.
    /// </summary>
    [Serializable()]
    public class DataGridViewRowHeaderCell : DataGridViewHeaderCell
    {
        #region Members

        #region Constants

        private const byte DATAGRIDVIEWROWHEADERCELL_contentMarginHeight = 3;
        private const byte DATAGRIDVIEWROWHEADERCELL_contentMarginWidth = 3;
        private const byte DATAGRIDVIEWROWHEADERCELL_horizontalTextMarginLeft = 1;
        private const byte DATAGRIDVIEWROWHEADERCELL_horizontalTextMarginRight = 2;
        private const byte DATAGRIDVIEWROWHEADERCELL_iconMarginHeight = 2;
        private const byte DATAGRIDVIEWROWHEADERCELL_iconMarginWidth = 3;
        private const byte DATAGRIDVIEWROWHEADERCELL_iconsHeight = 11;
        private const byte DATAGRIDVIEWROWHEADERCELL_iconsWidth = 12;
        private const byte DATAGRIDVIEWROWHEADERCELL_verticalTextMargin = 1;

        #endregion Constants

        #endregion Members

        #region C'tors / D'tors

        /// <summary>
        /// Initializes the <see cref="DataGridViewRowHeaderCell"/> class.
        /// </summary>
        static DataGridViewRowHeaderCell()
        {
        }

        #endregion C'tors / D'tors

        #region Methods

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected internal override void FireEvent(IEvent objEvent)
        {
            base.FireEvent(objEvent);

            switch (objEvent.Type)
            {
                case "Click":
                    if (this.DataGridView != null)
                    {
                        // Get x and coordinates.
                        int intX = GetEventValue(objEvent, "X", 0);
                        int intY = GetEventValue(objEvent, "Y", 0);

                        this.DataGridView.FireRowHeaderMouseClick(new DataGridViewCellMouseEventArgs(this.ColumnIndex, this.RowIndex, 0, 0, new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, intX, intY, 0)));

                        if (this.DataGridView != null)
                        {
                            this.DataGridView.Update();
                        }
                    }
                    break;
                case "DoubleClick":
                    if (this.DataGridView != null)
                    {
                        // Get x and coordinates.
                        int intX = GetEventValue(objEvent, "X", 0);
                        int intY = GetEventValue(objEvent, "Y", 0);

                        // Create event arguments variables.
                        DataGridViewCellMouseEventArgs objDataGridViewCellMouseEventArgs = new DataGridViewCellMouseEventArgs(-1, this.RowIndex, intX, intY, new MouseEventArgs(MouseButtons.Left, 1, intX, intY, 0));

                        // Raise cell content double click event.
                        this.DataGridView.OnRowHeaderMouseDoubleClickInternal(objDataGridViewCellMouseEventArgs);
                    }
                    break;
            }
        }


        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (this.DataGridView != null)
            {
                if (this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWROWHEADERMOUSECLICK))
                {
                    objEvents.Set(WGEvents.Click);
                    objEvents.Set(WGEvents.RightClick);
                }

                if (this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWROWHEADERMOUSEDOUBLECLICK))
                {
                    objEvents.Set(WGEvents.DoubleClick);
                }
            }

            return objEvents;
        }

        /// <summary>
        /// Gets the shortcut menu of the header cell.
        /// </summary>
        /// <param name="intRowIndex">Ignored by this implementation.</param>
        /// <returns>
        /// A <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> if the <see cref="T:System.Windows.Forms.DataGridViewHeaderCell"></see> or <see cref="T:System.Windows.Forms.DataGridView"></see> has a shortcut menu assigned; otherwise, null.
        /// </returns>
        public override ContextMenu GetInheritedContextMenu(int intRowIndex)
        {
            if ((base.DataGridView != null) && ((intRowIndex < 0) || (intRowIndex >= base.DataGridView.Rows.Count)))
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            ContextMenu objContextMenu = base.GetContextMenu(intRowIndex);
            if (objContextMenu != null)
            {
                return objContextMenu;
            }
            if (base.DataGridView != null)
            {
                return base.DataGridView.ContextMenu;
            }
            return null;
        }

        /// <summary>
        /// Calculates the preferred size, in pixels, of the cell.
        /// </summary>
        /// <param name="strText">The text to be measured.</param>
        /// <param name="objCellStyle">A <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> that represents the style of the cell.</param>
        /// <returns>
        /// A <see cref="T:System.Drawing.Size"></see> that represents the preferred size, in pixels, of the cell.
        /// </returns>
        protected override Size GetPreferredSize(string strText, DataGridViewCellStyle objCellStyle)
        {
            // Get base value.
            Size objPreferredSize = base.GetPreferredSize(strText, objCellStyle);

            // Try getting owning row.
            DataGridViewRow objOwningRow = this.OwningRow;
            if (objOwningRow != null)
            {
                // Try getting owning grid.
                DataGridView objOwningDataGridView = this.DataGridView;
                if (objOwningDataGridView != null)
                {
                    // Try getting owning grid's skin.
                    DataGridViewSkin objDataGridViewSkin = objOwningDataGridView.Skin as DataGridViewSkin;
                    if (objDataGridViewSkin != null)
                    {
                        // Calculate direction string.
                        string strDirection = objOwningDataGridView.Context.RightToLeft ? "RTL" : "LTR";

                        // Get edit mode image size.
                        Size objEditModeImageSize = objDataGridViewSkin.GetImageSize(string.Format("DGVEditedMode{0}.gif", strDirection));

                        // Get arrow image size.
                        Size objArrowImageSize = objDataGridViewSkin.GetImageSize(string.Format("Arrow{0}.gif", strDirection));

                        // Calculate maximal height between image sizes.
                        objPreferredSize.Height = Math.Max(objPreferredSize.Height, Math.Max(objArrowImageSize.Height, objEditModeImageSize.Height));

                        // Check if owning row is the new row.
                        if (objOwningRow.IsNewRow)
                        {
                            // Get new row image size.
                            Size objNewRowImageSize = objDataGridViewSkin.GetImageSize("DGVNewRowMode.gif");

                            // Calculate maximal height between image sizes.
                            objPreferredSize.Height = Math.Max(objPreferredSize.Height, objNewRowImageSize.Height);
                        }
                    }
                }
            }

            return objPreferredSize;
        }

        /// <summary>
        /// Gets the inherited context menu strip.
        /// </summary>
        /// <param name="intRowIndex">Index of the int row.</param>
        /// <returns></returns>
        public override ContextMenuStrip GetInheritedContextMenuStrip(int intRowIndex)
        {
            if ((base.DataGridView != null) && ((intRowIndex < 0) || (intRowIndex >= base.DataGridView.Rows.Count)))
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            ContextMenuStrip objContextMenuStrip = base.GetContextMenuStrip(intRowIndex);
            if (objContextMenuStrip != null)
            {
                return objContextMenuStrip;
            }
            if (base.DataGridView != null)
            {
                return base.DataGridView.ContextMenuStrip;
            }
            return null;
        }

        /// <summary>
        /// Creates an exact copy of this cell.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see>.
        /// </returns>
        public override object Clone()
        {
            return null;
        }

        /// <summary>Retrieves the formatted value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</summary>
        /// <returns>A <see cref="T:System.Object"></see> that represents the value of the cell to copy to the <see cref="T:Gizmox.WebGUI.Forms.Clipboard"></see>.</returns>
        /// <param name="blnInLastRow">true to indicate that the cell is in the last row of the region defined by the selected cells; otherwise, false.</param>
        /// <param name="blnInFirstRow">true to indicate that the cell is in the first row of the region defined by the selected cells; otherwise, false.</param>
        /// <param name="blnLastCell">true to indicate that the cell is the last column of the region defined by the selected cells; otherwise, false.</param>
        /// <param name="strFormat">The current format string of the cell.</param>
        /// <param name="blnFirstCell">true to indicate that the cell is in the first column of the region defined by the selected cells; otherwise, false.</param>
        /// <param name="intRowIndex">The zero-based index of the row containing the cell.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero or greater than or equal to the number of rows in the control.</exception>
        protected override object GetClipboardContent(int intRowIndex, bool blnFirstCell, bool blnLastCell, bool blnInFirstRow, bool blnInLastRow, string strFormat)
        {
            return null;
        }

        /// <summary>
        /// Gets the style applied to the cell.
        /// </summary>
        /// <param name="objInheritedCellStyle">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be populated with the inherited cell style.</param>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        /// <param name="blnIncludeColors">true to include inherited colors in the returned cell style; otherwise, false.</param>
        /// <returns>
        /// A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that includes the style settings of the cell inherited from the cell's parent row, column, and <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.
        /// </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0, or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
        /// <exception cref="T:System.InvalidOperationException">The cell has no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.-or-<see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0, indicating that the cell is a row header cell.</exception>
        public override DataGridViewCellStyle GetInheritedStyle(DataGridViewCellStyle objInheritedCellStyle, int intRowIndex, bool blnIncludeColors)
        {
            DataGridViewCellStyle objDataGridViewCellStyle = (objInheritedCellStyle == null) ? new DataGridViewCellStyle() : objInheritedCellStyle;
            DataGridViewCellStyle objDataGridViewCellStyle2 = null;
            if (base.HasStyle)
            {
                objDataGridViewCellStyle2 = base.Style;
            }
            DataGridViewCellStyle objRowHeadersDefaultCellStyle = base.DataGridView.RowHeadersDefaultCellStyle;
            DataGridViewCellStyle objDefaultCellStyle = base.DataGridView.DefaultCellStyle;
            if (blnIncludeColors)
            {
                if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.BackColor.IsEmpty)
                {
                    objDataGridViewCellStyle.BackColor = objDataGridViewCellStyle2.BackColor;
                }
                else if (!objRowHeadersDefaultCellStyle.BackColor.IsEmpty)
                {
                    objDataGridViewCellStyle.BackColor = objRowHeadersDefaultCellStyle.BackColor;
                }
                else
                {
                    objDataGridViewCellStyle.BackColor = objDefaultCellStyle.BackColor;
                }
                if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.ForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle.ForeColor = objDataGridViewCellStyle2.ForeColor;
                }
                else if (!objRowHeadersDefaultCellStyle.ForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle.ForeColor = objRowHeadersDefaultCellStyle.ForeColor;
                }
                else
                {
                    objDataGridViewCellStyle.ForeColor = objDefaultCellStyle.ForeColor;
                }
                if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.SelectionBackColor.IsEmpty)
                {
                    objDataGridViewCellStyle.SelectionBackColor = objDataGridViewCellStyle2.SelectionBackColor;
                }
                else if (!objRowHeadersDefaultCellStyle.SelectionBackColor.IsEmpty)
                {
                    objDataGridViewCellStyle.SelectionBackColor = objRowHeadersDefaultCellStyle.SelectionBackColor;
                }
                else
                {
                    objDataGridViewCellStyle.SelectionBackColor = objDefaultCellStyle.SelectionBackColor;
                }
                if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.SelectionForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle.SelectionForeColor = objDataGridViewCellStyle2.SelectionForeColor;
                }
                else if (!objRowHeadersDefaultCellStyle.SelectionForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle.SelectionForeColor = objRowHeadersDefaultCellStyle.SelectionForeColor;
                }
                else
                {
                    objDataGridViewCellStyle.SelectionForeColor = objDefaultCellStyle.SelectionForeColor;
                }
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.Font != null))
            {
                objDataGridViewCellStyle.Font = objDataGridViewCellStyle2.Font;
            }
            else if (objRowHeadersDefaultCellStyle.Font != null)
            {
                objDataGridViewCellStyle.Font = objRowHeadersDefaultCellStyle.Font;
            }
            else
            {
                objDataGridViewCellStyle.Font = objDefaultCellStyle.Font;
            }
            if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.IsNullValueDefault)
            {
                objDataGridViewCellStyle.NullValue = objDataGridViewCellStyle2.NullValue;
            }
            else if (!objRowHeadersDefaultCellStyle.IsNullValueDefault)
            {
                objDataGridViewCellStyle.NullValue = objRowHeadersDefaultCellStyle.NullValue;
            }
            else
            {
                objDataGridViewCellStyle.NullValue = objDefaultCellStyle.NullValue;
            }
            if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.IsDataSourceNullValueDefault)
            {
                objDataGridViewCellStyle.DataSourceNullValue = objDataGridViewCellStyle2.DataSourceNullValue;
            }
            else if (!objRowHeadersDefaultCellStyle.IsDataSourceNullValueDefault)
            {
                objDataGridViewCellStyle.DataSourceNullValue = objRowHeadersDefaultCellStyle.DataSourceNullValue;
            }
            else
            {
                objDataGridViewCellStyle.DataSourceNullValue = objDefaultCellStyle.DataSourceNullValue;
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.Format.Length != 0))
            {
                objDataGridViewCellStyle.Format = objDataGridViewCellStyle2.Format;
            }
            else if (objRowHeadersDefaultCellStyle.Format.Length != 0)
            {
                objDataGridViewCellStyle.Format = objRowHeadersDefaultCellStyle.Format;
            }
            else
            {
                objDataGridViewCellStyle.Format = objDefaultCellStyle.Format;
            }
            if ((objDataGridViewCellStyle2 != null) && !objDataGridViewCellStyle2.IsFormatProviderDefault)
            {
                objDataGridViewCellStyle.FormatProvider = objDataGridViewCellStyle2.FormatProvider;
            }
            else if (!objRowHeadersDefaultCellStyle.IsFormatProviderDefault)
            {
                objDataGridViewCellStyle.FormatProvider = objRowHeadersDefaultCellStyle.FormatProvider;
            }
            else
            {
                objDataGridViewCellStyle.FormatProvider = objDefaultCellStyle.FormatProvider;
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.Alignment != DataGridViewContentAlignment.NotSet))
            {
                objDataGridViewCellStyle.AlignmentInternal = objDataGridViewCellStyle2.Alignment;
            }
            else if (objRowHeadersDefaultCellStyle.Alignment != DataGridViewContentAlignment.NotSet)
            {
                objDataGridViewCellStyle.AlignmentInternal = objRowHeadersDefaultCellStyle.Alignment;
            }
            else
            {
                objDataGridViewCellStyle.AlignmentInternal = objDefaultCellStyle.Alignment;
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.WrapMode != DataGridViewTriState.NotSet))
            {
                objDataGridViewCellStyle.WrapModeInternal = objDataGridViewCellStyle2.WrapMode;
            }
            else if (objRowHeadersDefaultCellStyle.WrapMode != DataGridViewTriState.NotSet)
            {
                objDataGridViewCellStyle.WrapModeInternal = objRowHeadersDefaultCellStyle.WrapMode;
            }
            else
            {
                objDataGridViewCellStyle.WrapModeInternal = objDefaultCellStyle.WrapMode;
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.Tag != null))
            {
                objDataGridViewCellStyle.Tag = objDataGridViewCellStyle2.Tag;
            }
            else if (objRowHeadersDefaultCellStyle.Tag != null)
            {
                objDataGridViewCellStyle.Tag = objRowHeadersDefaultCellStyle.Tag;
            }
            else
            {
                objDataGridViewCellStyle.Tag = objDefaultCellStyle.Tag;
            }
            if ((objDataGridViewCellStyle2 != null) && (objDataGridViewCellStyle2.Padding != Padding.Empty))
            {
                objDataGridViewCellStyle.PaddingInternal = objDataGridViewCellStyle2.Padding;
                return objDataGridViewCellStyle;
            }
            if (objRowHeadersDefaultCellStyle.Padding != Padding.Empty)
            {
                objDataGridViewCellStyle.PaddingInternal = objRowHeadersDefaultCellStyle.Padding;
                return objDataGridViewCellStyle;
            }
            objDataGridViewCellStyle.PaddingInternal = objDefaultCellStyle.Padding;
            return objDataGridViewCellStyle;
        }

        /// <summary>Gets the value of the cell. </summary>
        /// <returns>The value contained in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell"></see>.</returns>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property of the cell is not null and rowIndex is less than -1 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
        protected override object GetValue(int intRowIndex)
        {
            if ((base.DataGridView != null) && ((intRowIndex < -1) || (intRowIndex >= base.DataGridView.Rows.Count)))
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }

            if (this.ContainsLocalValue)
            {
                return this.LocalValue;
            }

            return null;
        }

        /// <summary>
        /// Sets the value of the cell.
        /// </summary>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        /// <param name="objValue">The cell value to set.</param>
        /// <returns>
        /// true if the value has been set; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.ColumnIndex"></see> is less than 0.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than 0 or greater than or equal to the number of rows in the parent <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</exception>
        protected override bool SetValue(int intRowIndex, object objValue)
        {
            object objCurrentValue = this.GetValue(intRowIndex);

            if ((objValue != null) || this.ContainsLocalValue)
            {
                this.LocalValue = objValue;
            }

            if ((base.DataGridView != null) && (objCurrentValue != objValue))
            {
                base.RaiseCellValueChanged(new DataGridViewCellEventArgs(-1, intRowIndex));
            }

            return true;
        }

        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            return null;
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets the left arrow bitmap.
        /// </summary>
        /// <value>The left arrow bitmap.</value>
        private static Bitmap LeftArrowBitmap
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the left arrow star bitmap.
        /// </summary>
        /// <value>The left arrow star bitmap.</value>
        private static Bitmap LeftArrowStarBitmap
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the pencil LTR bitmap.
        /// </summary>
        /// <value>The pencil LTR bitmap.</value>
        private static Bitmap PencilLTRBitmap
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the pencil RTL bitmap.
        /// </summary>
        /// <value>The pencil RTL bitmap.</value>
        private static Bitmap PencilRTLBitmap
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the right arrow bitmap.
        /// </summary>
        /// <value>The right arrow bitmap.</value>
        private static Bitmap RightArrowBitmap
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the right arrow star bitmap.
        /// </summary>
        /// <value>The right arrow star bitmap.</value>
        private static Bitmap RightArrowStarBitmap
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the star bitmap.
        /// </summary>
        /// <value>The star bitmap.</value>
        private static Bitmap StarBitmap
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Renders the Row header cell member ID
        /// </summary>
        protected override string MemberID
        {
            get
            {
                return "RHC" + this.RowIndex;
            }
        }

        #endregion Properties

    }

    #endregion

    #region DataGridViewTopLeftHeaderCell Class

    /// <summary>Represents the cell in the top left corner of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that sits above the row headers and to the left of the column headers.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public class DataGridViewTopLeftHeaderCell : DataGridViewColumnHeaderCell
    {
        private const byte DATAGRIDVIEWTOPLEFTHEADERCELL_horizontalTextMarginLeft = 1;
        private const byte DATAGRIDVIEWTOPLEFTHEADERCELL_horizontalTextMarginRight = 2;
        private const byte DATAGRIDVIEWTOPLEFTHEADERCELL_verticalTextMargin = 1;

        static DataGridViewTopLeftHeaderCell()
        {
        }

        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            return "DataGridViewTopLeftHeaderCell";
        }

        /// <summary>
        /// Fires the column header mouse click.
        /// </summary>
        /// <param name="objEvent">The obj event.</param>
        protected override void FireColumnHeaderMouseClick(IEvent objEvent)
        {
            // do nothing
        }

        /// <summary>
        /// </summary>
        /// <value></value>
        protected override string MemberID
        {
            get
            {
                return "GHC0";
            }
        }
    }

    #endregion

    #region DataGridViewHeaderCell Class

    /// <summary>Contains functionality common to row header cells and column header cells.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public class DataGridViewHeaderCell : DataGridViewCell
    {
        #region Members

        #region Static

        protected static Type cellType;
        protected static Type defaultFormattedValueType;
        protected static Type defaultValueType;
        protected static readonly int PropButtonState;
        protected static readonly int PropFlipXPThemesBitmap;
        protected static readonly int PropValueType;
        protected static Rectangle rectThemeMargins;

        #endregion Static

        #region Constants

        protected const byte DATAGRIDVIEWHEADERCELL_themeMargin = 100;
        protected const string HeaderTypeName = "7";

        #endregion Constants

        private object mobjLocalValue;

        #endregion Members

        #region C'tors / D'tors

        static DataGridViewHeaderCell()
        {
            DataGridViewHeaderCell.defaultFormattedValueType = typeof(string);
            DataGridViewHeaderCell.defaultValueType = typeof(object);
            DataGridViewHeaderCell.cellType = typeof(DataGridViewHeaderCell);
            DataGridViewHeaderCell.rectThemeMargins = new Rectangle(-1, -1, 0, 0);

        }

        #endregion C'tors / D'tors

        #region Methods

        #region Render

        /// <summary>
        /// Renders the wrap mode attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
        protected override void RenderWrapModeAttribute(IAttributeWriter objWriter, DataGridViewCellStyle objInheritedCellStyle)
        {
            // Serialize WrapMode if needed
            if (objInheritedCellStyle.WrapMode != DataGridViewTriState.True)
            {
                objWriter.WriteAttributeString(WGAttributes.WrapContents, "0");
            }
        }

        /// <summary>
        /// Renders the read only attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderReadOnlyAttribute(IAttributeWriter objWriter)
        {
        }

        /// <summary>
        /// Renders the back-color attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
        protected override void RenderBackColorAttribute(IAttributeWriter objWriter, DataGridViewCellStyle objInheritedCellStyle)
        {
            if (objInheritedCellStyle.BackColor != this.DataGridView.DefaultColumnHeadersDefaultCellStyleInternal.BackColor)
            {
                objWriter.WriteAttributeString(WGAttributes.Background, CommonUtils.GetHtmlColor(objInheritedCellStyle.BackColor));
            }
        }

        /// <summary>
        /// Renders the fore color attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="objInheritedCellStyle">The obj inherited cell style.</param>
        protected override void RenderForeColorAttribute(IAttributeWriter objWriter, DataGridViewCellStyle objInheritedCellStyle)
        {
            if (objInheritedCellStyle.ForeColor != this.DataGridView.DefaultColumnHeadersDefaultCellStyleInternal.ForeColor)
            {
                objWriter.WriteAttributeString(WGAttributes.Fore, CommonUtils.GetHtmlColor(objInheritedCellStyle.ForeColor));
            }
        }

        /// <summary>
        /// Renders the cell text/value.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="objFormatedValue">The formated value.</param>
        protected override void RenderCellValue(IContext objContext, IAttributeWriter objWriter, object objFormatedValue)
        {
            base.RenderCellValue(objContext, objWriter, objFormatedValue);

            //If no value dont render the text
            if (objFormatedValue != null)
            {
                objWriter.WriteAttributeText(WGAttributes.Value, objFormatedValue.ToString());
            }

        }

        #endregion Render

        /// <summary>Gets the shortcut menu of the header cell.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> if the <see cref="T:System.Windows.Forms.DataGridViewHeaderCell"></see> or <see cref="T:System.Windows.Forms.DataGridView"></see> has a shortcut menu assigned; otherwise, null.</returns>
        /// <param name="intRowIndex">Ignored by this implementation.</param>
        public override ContextMenu GetInheritedContextMenu(int intRowIndex)
        {
            ContextMenu objContextMenu = base.GetContextMenu(intRowIndex);
            if (objContextMenu != null)
            {
                return objContextMenu;
            }
            if (base.DataGridView != null)
            {
                return base.DataGridView.ContextMenu;
            }
            return null;
        }

        /// <summary>
        /// Gets the inherited context menu strip.
        /// </summary>
        /// <param name="intRowIndex">Index of the int row.</param>
        /// <returns></returns>
        public override ContextMenuStrip GetInheritedContextMenuStrip(int intRowIndex)
        {
            ContextMenuStrip objContextMenuStrip = base.GetContextMenuStrip(intRowIndex);
            if (objContextMenuStrip != null)
            {
                return objContextMenuStrip;
            }
            if (base.DataGridView != null)
            {
                return base.DataGridView.ContextMenuStrip;
            }
            return null;
        }

        /// <summary>Creates an exact copy of this cell.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override object Clone()
        {
            DataGridViewHeaderCell objCell;
            Type objType = base.GetType();
            if (objType == DataGridViewHeaderCell.cellType)
            {
                objCell = new DataGridViewHeaderCell();
            }
            else
            {
                objCell = (DataGridViewHeaderCell)Activator.CreateInstance(objType);
            }
            base.CloneInternal(objCell);
            objCell.Value = base.Value;
            return objCell;
        }

        /// <summary>Returns a value indicating the current state of the cell as inherited from the state of its row or column.</summary>
        /// <returns>A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values representing the current state of the cell.</returns>
        /// <param name="intRowIndex">The index of the row containing the cell or -1 if the cell is not a row header cell or is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</param>
        /// <exception cref="T:System.ArgumentException">The cell is a row header cell, the cell is not contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control, and rowIndex is not -1.- or -The cell is a row header cell, the cell is contained within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control, and rowIndex is outside the valid range of 0 to the number of rows in the control minus 1.- or -The cell is a row header cell and rowIndex is not the index of the row containing this cell.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The cell is a column header cell or the control's <see cref="P:Gizmox.WebGUI.Forms.DataGridView.TopLeftHeaderCell"></see>  and rowIndex is not -1.</exception>
        public override DataGridViewElementStates GetInheritedState(int intRowIndex)
        {
            DataGridViewElementStates enmElementState = DataGridViewElementStates.ResizableSet | DataGridViewElementStates.ReadOnly;
            if (base.OwningRow != null)
            {
                if (((base.DataGridView == null) && (intRowIndex != -1)) || ((base.DataGridView != null) && ((intRowIndex < 0) || (intRowIndex >= base.DataGridView.Rows.Count))))
                {
                    throw new ArgumentException(SR.GetString("InvalidArgument", new object[] { "rowIndex", intRowIndex.ToString(CultureInfo.CurrentCulture) }));
                }
                if ((base.DataGridView != null) && (base.DataGridView.Rows.SharedRow(intRowIndex) != base.OwningRow))
                {
                    throw new ArgumentException(SR.GetString("InvalidArgument", new object[] { "rowIndex", intRowIndex.ToString(CultureInfo.CurrentCulture) }));
                }
                enmElementState |= base.OwningRow.GetState(intRowIndex) & DataGridViewElementStates.Frozen;
                if ((base.OwningRow.GetResizable(intRowIndex) == DataGridViewTriState.True) || ((base.DataGridView != null) && (base.DataGridView.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing)))
                {
                    enmElementState |= DataGridViewElementStates.Resizable;
                }
                if (base.OwningRow.GetVisible(intRowIndex) && ((base.DataGridView == null) || base.DataGridView.RowHeadersVisible))
                {
                    enmElementState |= DataGridViewElementStates.Visible;
                    if (base.OwningRow.GetDisplayed(intRowIndex))
                    {
                        enmElementState |= DataGridViewElementStates.Displayed;
                    }
                }
                return enmElementState;
            }
            if (base.OwningColumn != null)
            {
                if (intRowIndex != -1)
                {
                    throw new ArgumentOutOfRangeException("rowIndex");
                }
                enmElementState |= base.OwningColumn.State & DataGridViewElementStates.Frozen;
                if ((base.OwningColumn.Resizable == DataGridViewTriState.True) || ((base.DataGridView != null) && (base.DataGridView.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.EnableResizing)))
                {
                    enmElementState |= DataGridViewElementStates.Resizable;
                }
                if (base.OwningColumn.Visible && ((base.DataGridView == null) || base.DataGridView.ColumnHeadersVisible))
                {
                    enmElementState |= DataGridViewElementStates.Visible;
                    if (base.OwningColumn.Displayed)
                    {
                        enmElementState |= DataGridViewElementStates.Displayed;
                    }
                }
                return enmElementState;
            }
            if (base.DataGridView != null)
            {
                if (intRowIndex != -1)
                {
                    throw new ArgumentOutOfRangeException("rowIndex");
                }
                enmElementState |= DataGridViewElementStates.Frozen;
                if ((base.DataGridView.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing) || (base.DataGridView.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.EnableResizing))
                {
                    enmElementState |= DataGridViewElementStates.Resizable;
                }

            }
            return enmElementState;
        }

        /// <summary>Gets the size of the cell.</summary>
        /// <returns>A <see cref="T:System.Drawing.Size"></see> that represents the size of the header cell.</returns>
        /// <param name="intRowIndex">The row index of the header cell.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> property for this cell is null and rowIndex does not equal -1. -or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningColumn"></see> property for this cell is not null and rowIndex does not equal -1. -or-The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningRow"></see> property for this cell is not null and rowIndex is less than zero or greater than or equal to the number of rows in the control.-or-The values of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningColumn"></see> and <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningRow"></see> properties of this cell are both null and rowIndex does not equal -1.</exception>
        /// <exception cref="T:System.ArgumentException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningRow"></see> property for this cell is not null and rowIndex indicates a row other than the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.OwningRow"></see>.</exception>
        protected override Size GetSize(int intRowIndex)
        {
            if (base.DataGridView == null)
            {
                if (intRowIndex != -1)
                {
                    throw new ArgumentOutOfRangeException("rowIndex");
                }
                return new Size(-1, -1);
            }

            if (base.OwningRow != null)
            {
                if ((intRowIndex < 0) || (intRowIndex >= base.DataGridView.Rows.Count))
                {
                    throw new ArgumentOutOfRangeException("rowIndex");
                }
                if (base.DataGridView.Rows.SharedRow(intRowIndex) != base.OwningRow)
                {
                    throw new ArgumentException(SR.GetString("InvalidArgument", new object[] { "rowIndex", intRowIndex.ToString(CultureInfo.CurrentCulture) }));
                }
                return new Size(base.DataGridView.RowHeadersWidth, base.OwningRow.GetHeight(intRowIndex));
            }
            if (intRowIndex != -1)
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            return new Size(base.DataGridView.RowHeadersWidth, base.DataGridView.ColumnHeadersHeight);
        }

        /// <summary>Gets the value of the cell. </summary>
        /// <returns>The value of the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see>.</returns>
        /// <param name="intRowIndex">The index of the cell's parent row.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is not -1.</exception>
        protected override object GetValue(int intRowIndex)
        {
            return null;
        }

        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            return ("DataGridViewHeaderCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + base.RowIndex.ToString(CultureInfo.CurrentCulture) + " }");
        }

        private void UpdateButtonState(Gizmox.WebGUI.Forms.ButtonState newButtonState, int intRowIndex)
        {

            base.DataGridView.InvalidateCell(base.ColumnIndex, intRowIndex);
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets a value indicating whether [contains local value].
        /// </summary>
        /// <value><c>true</c> if [contains local value]; otherwise, <c>false</c>.</value>
        internal bool ContainsLocalValue
        {
            get
            {
                string strValue = System.Convert.ToString( this.LocalValue);
                return strValue != null && strValue != "";
            }
        }

        /// <summary>
        /// Gets or sets the local value.
        /// </summary>
        /// <value>The local value.</value>
        protected object LocalValue
        {
            get
            {
                return this.mobjLocalValue;
            }
            set
            {
                this.mobjLocalValue = value;
            }
        }

        /// <summary>Gets the buttonlike visual state of the header cell.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.ButtonState"></see> values; the default is <see cref="F:Gizmox.WebGUI.Forms.ButtonState.Normal"></see>.</returns>
        protected Gizmox.WebGUI.Forms.ButtonState ButtonState
        {
            get
            {
                return ButtonState.Normal;
            }
        }

        /// <summary>
        /// </summary>
        /// <value></value>
        internal override string TypeName
        {
            get
            {
                return DataGridViewHeaderCell.HeaderTypeName;
            }
        }

        /// <summary>
        /// Gets a value that indicates whether the cell is currently displayed on-screen.
        /// </summary>
        /// <value></value>
        /// <returns>true if the cell is on-screen or partially on-screen; otherwise, false.</returns>
        [Browsable(false)]
        public override bool Displayed
        {
            get
            {
                if ((base.DataGridView != null) && base.DataGridView.Visible)
                {
                    if (base.OwningRow != null)
                    {
                        if (base.DataGridView.RowHeadersVisible)
                        {
                            return base.OwningRow.Displayed;
                        }
                        return false;
                    }
                    if (base.DataGridView.ColumnHeadersVisible)
                    {
                        return base.OwningColumn.Displayed;
                    }
                }
                return false;
            }
        }

        /// <summary>Gets the type of the formatted value of the cell.</summary>
        /// <returns>A <see cref="T:System.Type"></see> object representing the <see cref="T:System.String"></see> type.</returns>
        public override Type FormattedValueType
        {
            get
            {
                return DataGridViewHeaderCell.defaultFormattedValueType;
            }
        }

        /// <summary>Gets a value indicating whether the cell is frozen. </summary>
        /// <returns>true if the cell is frozen; otherwise, false. The default is false if the cell is detached from a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public override bool Frozen
        {
            get
            {
                if (base.OwningRow != null)
                {
                    return base.OwningRow.Frozen;
                }
                if (base.OwningColumn != null)
                {
                    return base.OwningColumn.Frozen;
                }
                if (base.DataGridView != null)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>Gets a value indicating whether the header cell is read-only.</summary>
        /// <returns>true in all cases.</returns>
        /// <exception cref="T:System.InvalidOperationException">An operation tries to set this property.</exception>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override bool ReadOnly
        {
            get
            {
                return true;
            }
            set
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_HeaderCellReadOnlyProperty", new object[] { "ReadOnly" }));
            }
        }

        /// <summary>Gets a value indicating whether the cell is resizable.</summary>
        /// <returns>true if this cell can be resized; otherwise, false. The default is false if the cell is not attached to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public override bool Resizable
        {
            get
            {
                if (base.OwningRow != null)
                {
                    if (base.OwningRow.Resizable == DataGridViewTriState.True)
                    {
                        return true;
                    }
                    if (base.DataGridView != null)
                    {
                        return (base.DataGridView.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing);
                    }
                    return false;
                }
                if (base.OwningColumn != null)
                {
                    if (base.OwningColumn.Resizable == DataGridViewTriState.True)
                    {
                        return true;
                    }
                    if (base.DataGridView != null)
                    {
                        return (base.DataGridView.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.EnableResizing);
                    }
                    return false;
                }
                if (base.DataGridView == null)
                {
                    return false;
                }
                if (base.DataGridView.RowHeadersWidthSizeMode != DataGridViewRowHeadersWidthSizeMode.EnableResizing)
                {
                    return (base.DataGridView.ColumnHeadersHeightSizeMode == DataGridViewColumnHeadersHeightSizeMode.EnableResizing);
                }
                return true;
            }
        }

        /// <summary>Gets or sets a value indicating whether the cell is selected.</summary>
        /// <returns>false in all cases.</returns>
        /// <exception cref="T:System.InvalidOperationException">This property is being set.</exception>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override bool Selected
        {
            get
            {
                return false;
            }
            set
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_HeaderCellReadOnlyProperty", new object[] { "Selected" }));
            }
        }

        /// <summary>Gets the type of the value stored in the cell.</summary>
        /// <returns>A <see cref="T:System.Type"></see> object representing the <see cref="T:System.String"></see> type.</returns>
        /// <filterpriority>1</filterpriority>
        public override Type ValueType
        {
            get
            {
                return DataGridViewHeaderCell.defaultValueType;
            }
            set
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override string MemberID
        {
            get
            {
                return "HC" + ((this.DataGridView.ColumnCount * this.RowIndex) + this.ColumnIndex);
            }
        }

        /// <summary>Gets a value indicating whether or not the cell is visible.</summary>
        /// <returns>true if the cell is visible; otherwise, false. The default is false if the cell is detached from a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see></returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public override bool Visible
        {
            get
            {
                if (base.OwningRow != null)
                {
                    if (!base.OwningRow.Visible)
                    {
                        return false;
                    }
                    if (base.DataGridView != null)
                    {
                        return base.DataGridView.RowHeadersVisible;
                    }
                    return true;
                }
                if (base.OwningColumn != null)
                {
                    if (!base.OwningColumn.Visible)
                    {
                        return false;
                    }
                    if (base.DataGridView != null)
                    {
                        return base.DataGridView.ColumnHeadersVisible;
                    }
                    return true;
                }
                if ((base.DataGridView != null) && base.DataGridView.RowHeadersVisible)
                {
                    return base.DataGridView.ColumnHeadersVisible;
                }
                return false;
            }
        }

        #endregion Properties

    }

    #endregion

    #endregion

    #region DataGridViewFilterCell Class

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [ToolboxItem(false)]
    public class DataGridViewFilterCell : DataGridViewCell
    {
        #region Events

        /// <summary>
        /// Occurs when [filter changed].
        /// </summary>
        public event EventHandler FilterChanged;

        #endregion

        #region Members

        private DataGridViewColumn mobjOwningColumn = null;
        private DataGridViewFilterControl mobjDataGridViewFilterControl = null;
        private DataGridView mobjOwningDataGridView = null;

        /// <summary>
        /// Filter cell type identificator.
        /// </summary>
        protected const string FilterTypeName = "8";

        #endregion

        #region Properties

        /// <summary>
        /// Gets TypeName of FilterCell
        /// </summary>
        internal override string TypeName
        {
            get
            {
                return DataGridViewFilterCell.FilterTypeName;
            }
        }

        /// <summary>
        /// Gets the render mask.
        /// </summary>
        internal override int RenderMask
        {
            get
            {
                // Do not render ContextMenu, Selected, ErrorText
                return base.RenderMask |
                    (int)Renderable.ContextMenuAttribute |
                    (int)Renderable.ErrorTextAttribute |
                    (int)Renderable.SelectedAttribute;
            }
        }

        /// <summary>
        /// Gets the prerender mask.
        /// </summary>
        internal override int PreRenderMask
        {
            get
            {
                // Do not prerender CellStyle
                return base.PreRenderMask |
                    (int)PreRenderable.CellStyle;
            }
        }

        /// <summary>
        /// Gets the comparision operator.
        /// </summary>
        internal FilterComparisonOperator ComparisonOperator
        {
            get
            {
                if (mobjDataGridViewFilterControl != null)
                {
                    return mobjDataGridViewFilterControl.ComparisionOperator;
                }

                return FilterComparisonOperator.None;
            }
        }

        /// <summary>
        /// Gets the comparision value.
        /// </summary>
        internal string ComparisionValue
        {
            get
            {
                if (mobjDataGridViewFilterControl != null)
                {
                    return mobjDataGridViewFilterControl.ComparisionValue;
                }

                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the comparision item.
        /// </summary>
        internal object ComparisionItem
        {
            get
            {
                if (mobjDataGridViewFilterControl != null)
                {
                    return mobjDataGridViewFilterControl.ComparisionItem;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the name of the data property.
        /// </summary>
        /// <value>
        /// The name of the data property.
        /// </value>
        internal string DataPropertyName
        {
            get
            {
                if (mobjOwningColumn != null)
                {
                    return mobjOwningColumn.DataPropertyName;
                }

                return string.Empty;
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether [allow row filtering].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow row filtering]; otherwise, <c>false</c>.
        /// </value>
        internal bool AllowRowFiltering
        {
            get
            {
                if (mobjOwningColumn != null)
                {
                    return mobjOwningColumn.AllowRowFiltering;
                }

                return true;
            }

            set
            {
                if (mobjOwningColumn != null)
                {
                    mobjOwningColumn.AllowRowFiltering = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the data type of the values in the cell.
        /// </summary>
        /// <returns>A <see cref="T:System.Type"></see> representing the data type of the value in the cell.</returns>
        internal Type ValueType
        {
            get
            {
                if (mobjOwningColumn != null)
                {
                    return mobjOwningColumn.ValueType;
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the data grid view filter control.
        /// </summary>
        /// <value>
        /// The data grid view filter control.
        /// </value>
        internal DataGridViewFilterControl DataGridViewFilterControlObject
        {
            get
            {
                return mobjDataGridViewFilterControl;
            }
        }

        #endregion

        #region C'tor

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewFilterCell"/> class.
        /// </summary>
        public DataGridViewFilterCell(DataGridView objOwningDataGridView, DataGridViewColumn objOwningColumn, bool blnFilteringEnabled)
        {
            // Initialize filter cell.
            InitializeDataGridViewFilterCell(objOwningDataGridView, objOwningColumn, blnFilteringEnabled);

            // Add control to cell panel.
            this.Panel.Controls.Add(mobjDataGridViewFilterControl);

            // Set default col and row spans.
            this.Colspan = 1;
            this.Rowspan = 1;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Clears the filter.
        /// </summary>
        /// <param name="blnClearHeaderFilter">if set to <c>true</c> [BLN clear header filter].</param>
        public void ClearFilter(bool blnClearHeaderFilter)
        {
            this.mobjDataGridViewFilterControl.ClearFilter(blnClearHeaderFilter);
        }

        /// <summary>
        /// Initializes the data grid view filter cell.
        /// </summary>
        /// <param name="objOwningDataGridView">The obj owning data grid view.</param>
        /// <param name="objOwningColumn">The obj owning column.</param>
        /// <param name="blnFilteringEnabled">if set to <c>true</c> [BLN filtering enabled].</param>
        private void InitializeDataGridViewFilterCell(DataGridView objOwningDataGridView, DataGridViewColumn objOwningColumn, bool blnFilteringEnabled)
        {
            // Init members.
            mobjOwningColumn = objOwningColumn;
            mobjOwningDataGridView = objOwningDataGridView;

            if (mobjDataGridViewFilterControl == null)
            {
                // Create filter control.
                mobjDataGridViewFilterControl = new DataGridViewFilterControl(objOwningDataGridView, objOwningColumn, this, blnFilteringEnabled);
            }

            // If control exists, refresh it.
            else
            {
                objOwningDataGridView.mblnSuspendFilterInitialization = true;

                mobjDataGridViewFilterControl.RefreshFilterComboBox();

                objOwningDataGridView.mblnSuspendFilterInitialization = false;
            }

            // Register events if filtering is ON.
            if (blnFilteringEnabled)
            {
                // Listen to "filter changed" event.
                mobjDataGridViewFilterControl.FilterChanged += new EventHandler(OnDataGridViewFilterControlFilterChanged);

                // Listen to "allow row filter changed" event. 
                mobjOwningColumn.AllowRowFilteringChanged += new EventHandler(OnAllowRowFilteringChanged);
            }

            // Cell filter Enabled set by its column and filtering availability.
            this.AllowRowFiltering = mobjOwningColumn.AllowRowFiltering && blnFilteringEnabled;

            // Initializes the cell panel availablity.
            InitializeCellPanelAvailablity();

            // Connect cell to datagridview and column.
            this.DataGridViewInternal = objOwningDataGridView;
            this.OwningColumnInternal = objOwningColumn;
        }

        /// <summary>
        /// Refreshes the filter cell.
        /// </summary>
        internal void RefreshFilterCell()
        {
            // Refresh with default values.
            this.RefreshFilterCell(this.mobjOwningDataGridView, this.mobjOwningColumn, this.AllowRowFiltering);
        }


        /// <summary>
        /// Refreshes the filter cell.
        /// </summary>
        /// <param name="objOwningDataGridView">The owning data grid view.</param>
        /// <param name="objOwningColumn">The obj owning column.</param>
        /// <param name="blnFilteringEnabled">if set to <c>true</c> [BLN filtering enabled].</param>
        private void RefreshFilterCell(DataGridView objOwningDataGridView, DataGridViewColumn objOwningColumn, bool blnFilteringEnabled)
        {
            // Initialize filter cell.
            InitializeDataGridViewFilterCell(objOwningDataGridView, objOwningColumn, blnFilteringEnabled);
        }

        /// <summary>
        /// Called when [allow row filtering changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void OnAllowRowFilteringChanged(object sender, EventArgs e)
        {
            // Initializes the cell panel availablity.
            InitializeCellPanelAvailablity();
        }

        /// <summary>
        /// Initializes the cell panel availablity.
        /// </summary>
        private void InitializeCellPanelAvailablity()
        {
            // Toggle row filter            
            this.Panel.Enabled = this.AllowRowFiltering;
        }

        /// <summary>
        /// Updates the filter combo box.
        /// </summary>
        internal void UpdateFilterComboBox()
        {
            if (mobjDataGridViewFilterControl.mobjValuesComboBox != null)
            {
                mobjDataGridViewFilterControl.mobjValuesComboBox.Update();
            }
        }

        /// <summary>
        /// Called when [data grid view filter control filter changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnDataGridViewFilterControlFilterChanged(object sender, EventArgs e)
        {
            if (FilterChanged != null)
            {
                FilterChanged(this, e);
            }
        }

        #endregion

        #region DataGridViewFilterControl Class

        /// <summary>
        /// 
        /// </summary>
        [Serializable(),ToolboxItem(false)]
        internal class DataGridViewFilterControl : UserControl
        {
            #region Members

            private DataGridViewColumn mobjOwningColumn = null;
            private DataGridView mobjOwningDataGridView = null;

            private Panel mobjLeftPanel;
            private DataGridViewFilterButton mobjOperatorsButton;
            private Panel mobjRightPanel;
            private DataGridViewFilterButton mobjClearButton;
            internal DataGridViewFilterComboBox mobjValuesComboBox;
            private ContextMenu mobjOperatorsContextMenu;
            private DataGridViewFilterCell mobjOwningCell;

            #endregion

            #region Events

            /// <summary>
            /// Occurs when [filter changed].
            /// </summary>
            public event EventHandler FilterChanged;

            #endregion

            #region C'tor

            /// <summary>
            /// Initializes a new instance of the <see cref="DataGridViewFilterControl"/> class.
            /// </summary>
            /// <param name="objOwningDataGridView">The obj owning data grid view.</param>
            /// <param name="objOwningColumn">The obj owning column.</param>
            /// <param name="objOwningCell">The obj owning cell.</param>
            /// <param name="blnFilteringEnabled">if set to <c>true</c> [BLN filtering enabled].</param>
            public DataGridViewFilterControl(DataGridView objOwningDataGridView, DataGridViewColumn objOwningColumn, DataGridViewFilterCell objOwningCell, bool blnFilteringEnabled)
            {
                objOwningDataGridView.mblnSuspendFilterInitialization = true;

                mobjOwningCell = objOwningCell;

                // Place controls on panel.
                this.InitializeComponent();

                // Initialize controls if filtering is ON.
                if (blnFilteringEnabled)
                {
                    // Preserve owning grid and column.
                    mobjOwningDataGridView = objOwningDataGridView;
                    mobjOwningColumn = objOwningColumn;

                    // Initializes the values combo box.
                    this.InitializeValuesComboBox();

                    // Initialize the operators context menu.
                    this.InitializeOperatorsContextMenu();

                    // Initialize the operators button.
                    this.InitializeOperatorsButton();

                    // Initialize the clear button.
                    this.InitializeClearButton();
                }

                objOwningDataGridView.mblnSuspendFilterInitialization = false;
            }

            /// <summary>
            /// Initializes the operators button.
            /// </summary>
            private void InitializeOperatorsButton()
            {
                if (mobjOwningDataGridView != null)
                {
                    // Get owning data grid view skin.
                    DataGridViewSkin objDataGridViewSkin = mobjOwningDataGridView.Skin as DataGridViewSkin;
                    if (objDataGridViewSkin != null)
                    {
                        mobjOperatorsButton.Image = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.InitialOperatorImage);
                    }
                }
            }

            #endregion

            #region Methods

            #region Events related

            /// <summary>
            /// Handles context menu click.
            /// </summary>
            /// <param name="objSource">The obj source.</param>
            /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.MenuItemEventArgs"/> instance containing the event data.</param>
            private void OperatorsContextMenuClick(object objSource, MenuItemEventArgs objArgs)
            {
                MenuItem objMenuItem = objArgs.MenuItem;
                if (objMenuItem != null)
                {
                    // Set operator as for selected menu item.
                    this.SetOperator(objMenuItem.Tag, objMenuItem.Icon);

                    // Fire filter changed event.
                    this.FireFilterChanged(false);
                }
            }

            /// <summary>
            /// Occurs when the values combobox's text changed.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            private void ValuesComboBoxTextChanged(object sender, EventArgs e)
            {
                // Get selected item
                DataGridViewSystemFilterOption objSelectedItem = mobjValuesComboBox.SelectedItem as DataGridViewSystemFilterOption;

                // Check if selected item is 'Custom' item
                if (objSelectedItem != null && objSelectedItem.Option == SystemFilterOptions.Custom)
                {
                    // Clear header filter if exist
                    if (mobjOwningColumn.ShowHeaderFilter)
                    {
                        if (mobjOwningColumn.HeaderCell != null)
                        {
                            mobjOwningColumn.HeaderCell.FilterComboBox.SelectedIndex = -1;
                            mobjOwningColumn.HeaderCell.FilterComboBox.Text = string.Empty;
                        }
                    }

                    // Inform datagridview to open custom filter dialog
                    this.mobjOwningDataGridView.OpenCustomFilterDialog(this.mobjOwningCell);
                }
                else
                {
                    // Validate value
                    if (!mobjValuesComboBox.IsValidValue())
                    {
                        this.mobjValuesComboBox.TextChanged -= new EventHandler(ValuesComboBoxTextChanged);

                        // Clear text
                        mobjValuesComboBox.Text = string.Empty;

                        this.mobjValuesComboBox.TextChanged += new EventHandler(ValuesComboBoxTextChanged);

                        MessageBox.Show(SR.GetString("InvalidFilterMessage"), string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    // Fire filter changed event.
                    FireFilterChanged(false);
                }
            }

            /// <summary>
            /// Fire filter changed event.
            /// </summary>
            internal void FireFilterChanged(bool blnForceFilterChanged)
            {
                EventHandler objFilterChanged = FilterChanged;

                // If someone listens, filter is not applying, and filter creation is complete.
                if (objFilterChanged != null && !this.mobjOwningDataGridView.mblnSuspendFilterInitialization && (!this.InValidFilterCriteria() || this.IsSystemFilter() || blnForceFilterChanged))
                {
                    // Signal on filter applying.
                    this.mobjOwningDataGridView.mblnSuspendFilterInitialization = true;

                    // Clear column header filter if needed.
                    if (mobjOwningColumn.ShowHeaderFilter && mobjOwningColumn.HasHeaderCell)
                    {
                        mobjOwningColumn.HeaderCell.FilterComboBox.SelectedIndex = -1;
                        mobjOwningColumn.HeaderCell.FilterComboBox.Text = string.Empty;
                    }

                    mobjOwningColumn.mstrCustomFilterExpression = string.Empty;

                    // Fire filter changed event.
                    objFilterChanged(this, EventArgs.Empty);

                    this.mobjOwningDataGridView.mblnSuspendFilterInitialization = false;
                }
            }


            /// <summary>
            /// Determines whether [is system filter].
            /// </summary>
            /// <returns>
            ///   <c>true</c> if [is system filter]; otherwise, <c>false</c>.
            /// </returns>
            private bool IsSystemFilter()
            {
                return this.mobjValuesComboBox.SelectedItem is DataGridViewSystemFilterOption;
            }


            /// <summary>
            /// Determines whether the filter is being created: either only an operator, or only value presents.
            /// </summary>
            /// <returns></returns>
            private bool InValidFilterCriteria()
            {
                return ((this.mobjValuesComboBox.SelectedItem != null || !string.IsNullOrEmpty(this.mobjValuesComboBox.Text)) && this.ComparisionOperator == FilterComparisonOperator.None) ||
                        ((this.mobjValuesComboBox.SelectedItem == null && string.IsNullOrEmpty(this.mobjValuesComboBox.Text)) && this.ComparisionOperator != FilterComparisonOperator.None);
            }

            #endregion

            /// <summary>
            /// Clears the filter.
            /// </summary>
            /// <param name="blnClearHeaderFilter">if set to <c>true</c> [BLN clear header filter].</param>
            internal void ClearFilter(bool blnClearHeaderFilter)
            {
                ClearCriteria(blnClearHeaderFilter);
            }

            /// <summary>
            /// Clears the criteria.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
            private void ClearCriteria(object sender, EventArgs e)
            {
                ClearCriteria(true);
            }

            /// <summary>
            /// Clears criteria.
            /// </summary>
            /// <param name="blnClearHeaderFilter">if set to <c>true</c> [BLN clear header filter].</param>
            private void ClearCriteria(bool blnClearHeaderFilter)
            {
                // Get current datagridview SuspendFilterInitialization value;
                bool blnSuspendFilterInitialization = this.mobjOwningDataGridView.mblnSuspendFilterInitialization;

                // Get current filter control values
                string strValue = mobjValuesComboBox.Text;
                object objOperator = mobjOperatorsButton.Tag;
                string strCustomFilter = mobjOwningColumn.mstrCustomFilterExpression;
                bool blnHeaderFilterChanged = false;

                // Set datagridview to suspend filter initialization mode
                this.mobjOwningDataGridView.mblnSuspendFilterInitialization = true;

                // Clears the operator.
                SetOperator(null, null);

                // Clear custom filter
                mobjOwningColumn.mstrCustomFilterExpression = string.Empty;

                // Clear header FilterComboBox
                if (blnClearHeaderFilter && mobjOwningColumn.ShowHeaderFilter)
                {
                    if (mobjOwningColumn.HeaderCell != null)
                    {
                        if (mobjOwningColumn.HeaderCell.FilterComboBox.SelectedIndex != -1)
                        {
                            blnHeaderFilterChanged = true;
                            mobjOwningColumn.HeaderCell.FilterComboBox.SelectedIndex = -1;
                            mobjOwningColumn.HeaderCell.FilterComboBox.Text = string.Empty;
                        }
                    }
                }

                // Clear value
                this.mobjValuesComboBox.SelectedIndex = -1;
                this.mobjValuesComboBox.Text = string.Empty;

                // Reset operators button
                InitializeOperatorsButton();

                // Set datagridview suspend filter initialization mode to it's previous value
                this.mobjOwningDataGridView.mblnSuspendFilterInitialization = blnSuspendFilterInitialization;

                // Compare current filter control values to previous values and fire filter chenged if values was different
                if ((strValue != mobjValuesComboBox.Text && objOperator != mobjOperatorsButton.Tag) || blnHeaderFilterChanged || strCustomFilter != mobjOwningColumn.mstrCustomFilterExpression)
                {
                    this.FireFilterChanged(true);
                }
            }

            /// <summary>
            /// Sets the operator.
            /// </summary>
            /// <param name="objOperator">The operator.</param>
            /// <param name="objResourceHandle">The resource handle.</param>
            internal void SetOperator(object objOperator, ResourceHandle objResourceHandle)
            {
                // Set tag and image properties value.
                this.mobjOperatorsButton.Tag = objOperator;
                this.mobjOperatorsButton.Image = objResourceHandle;
            }

            /// <summary>
            /// Initializes the clear button.
            /// </summary>
            private void InitializeClearButton()
            {
                if (mobjOwningDataGridView != null)
                {
                    // Get owning data grid view skin.
                    DataGridViewSkin objDataGridViewSkin = mobjOwningDataGridView.Skin as DataGridViewSkin;
                    if (objDataGridViewSkin != null)
                    {
                        mobjClearButton.Image = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.FilterCellClearButtonImage);
                    }
                }
            }

            /// <summary>
            /// Initializes the operators context menu.
            /// </summary>
            private void InitializeOperatorsContextMenu()
            {
                // Load operators only if DataGridView is bound to BindingSource
                BindingSource objOwningDataGridViewBindingSource = mobjOwningDataGridView.DataSource as BindingSource;

                if (mobjOwningColumn != null && objOwningDataGridViewBindingSource != null)
                {
                    List<FilterComparisonOperator> arrFilterComparisionOperator = DataGridViewFilterControl.GetFilterComparisonOperator(mobjOwningColumn.ValueType);
                    foreach (FilterComparisonOperator enmFilterComparisionOperator in arrFilterComparisionOperator)
                    {
                        // Create a new menu item with proper text value.
                        MenuItem objMenuItem = new MenuItem(SR.GetString(string.Format("FilterComparisionOperator_{0}", enmFilterComparisionOperator.ToString())));

                        // Set item's tag.
                        objMenuItem.Tag = enmFilterComparisionOperator;

                        objMenuItem.Icon = this.GetFilterComparisionOperatorImage(enmFilterComparisionOperator);

                        // Add new menu item.
                        mobjOperatorsContextMenu.MenuItems.Add(objMenuItem);
                    }
                }
            }

            /// <summary>
            /// Refreshes this instance.
            /// </summary>
            internal void RefreshFilterComboBox()
            {
                // Preserve filter values.
                object objFilterOperator = mobjOperatorsButton.Tag;
                ResourceHandle objOperatorIcon = mobjOperatorsButton.Image;
                string strFilterValue = mobjValuesComboBox.Text;

                // Rebind combobox.
                InitializeValuesComboBox();

                // Restore filter.
                SetOperator(objFilterOperator, objOperatorIcon);
                mobjValuesComboBox.Text = strFilterValue;

            }


            /// <summary>
            /// Gets the filter comparision operator image.
            /// </summary>
            /// <param name="enmFilterComparisionOperator">The enm filter comparision operator.</param>
            /// <returns></returns>
            private ResourceHandle GetFilterComparisionOperatorImage(FilterComparisonOperator enmFilterComparisionOperator)
            {
                return GetFilterComparisionOperatorImage(mobjOwningDataGridView, enmFilterComparisionOperator);
            }

            /// <summary>
            /// Gets the filter comparision operator image.
            /// </summary>
            /// <param name="mobjOwningDataGridView">The mobj owning data grid view.</param>
            /// <param name="enmFilterComparisionOperator">The enm filter comparision operator.</param>
            /// <returns></returns>
            internal static ResourceHandle GetFilterComparisionOperatorImage(DataGridView objOwningDataGridView, FilterComparisonOperator enmFilterComparisionOperator)
            {
                ResourceHandle objResourceHandle = null;

                if (objOwningDataGridView != null)
                {
                    // Get owning data grid view skin.
                    DataGridViewSkin objDataGridViewSkin = objOwningDataGridView.Skin as DataGridViewSkin;
                    if (objDataGridViewSkin != null)
                    {
                        // Get matching resource handle for filter comparison operator.
                        switch (enmFilterComparisionOperator)
                        {
                            case FilterComparisonOperator.Contains:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.ContainsComparisionOperator);
                                break;
                            case FilterComparisonOperator.Custom:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.CustomComparisionOperator);
                                break;
                            case FilterComparisonOperator.DoesNotContain:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.DoesNotContainComparisionOperator);
                                break;
                            case FilterComparisonOperator.DoesNotEndWith:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.DoesNotEndWithComparisionOperator);
                                break;
                            case FilterComparisonOperator.DoesNotMatch:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.DoesNotMatchComparisionOperator);
                                break;
                            case FilterComparisonOperator.DoesNotStartWith:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.DoesNotStartWithComparisionOperator);
                                break;
                            case FilterComparisonOperator.Equals:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.EqualsComparisionOperator);
                                break;
                            case FilterComparisonOperator.EndsWith:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.EndsWithComparisionOperator);
                                break;
                            case FilterComparisonOperator.GreaterThan:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.GreaterThanComparisionOperator);
                                break;
                            case FilterComparisonOperator.GreaterThanOrEqualTo:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.GreaterThanOrEqualToComparisionOperator);
                                break;
                            case FilterComparisonOperator.LessThan:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.LessThanComparisionOperator);
                                break;
                            case FilterComparisonOperator.LessThanOrEqualTo:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.LessThanOrEqualToComparisionOperator);
                                break;
                            case FilterComparisonOperator.Like:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.LikeComparisionOperator);
                                break;
                            case FilterComparisonOperator.Match:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.MatchComparisionOperator);
                                break;
                            case FilterComparisonOperator.NotEquals:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.NotEqualsComparisionOperator);
                                break;
                            case FilterComparisonOperator.NotLike:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.NotLikeComparisionOperator);
                                break;
                            case FilterComparisonOperator.StartsWith:
                                objResourceHandle = objDataGridViewSkin.GetResourceHandleFromReference(objDataGridViewSkin.StartsWithComparisionOperator);
                                break;
                        }
                    }
                }

                return objResourceHandle;
            }

            /// <summary>
            /// Gets the filter comparison operator.
            /// </summary>
            /// <param name="objColumnType">Type of the column.</param>
            /// <returns></returns>
            internal static List<FilterComparisonOperator> GetFilterComparisonOperator(Type objColumnType)
            {
                List<FilterComparisonOperator> arrFilterComparisionOperator = new List<FilterComparisonOperator>();

                // Add standard operators.
                arrFilterComparisionOperator.Add(FilterComparisonOperator.Equals);
                arrFilterComparisionOperator.Add(FilterComparisonOperator.NotEquals);

                if (objColumnType != typeof(bool))
                {
                    arrFilterComparisionOperator.Add(FilterComparisonOperator.LessThan);
                    arrFilterComparisionOperator.Add(FilterComparisonOperator.LessThanOrEqualTo);
                    arrFilterComparisionOperator.Add(FilterComparisonOperator.GreaterThan);
                    arrFilterComparisionOperator.Add(FilterComparisonOperator.GreaterThanOrEqualTo);
                }


                // Check if not a numeric column type..
                if (objColumnType != typeof(sbyte) &&
                    objColumnType != typeof(short) &&
                    objColumnType != typeof(int) &&
                    objColumnType != typeof(long) &&
                    objColumnType != typeof(byte) &&
                    objColumnType != typeof(ushort) &&
                    objColumnType != typeof(uint) &&
                    objColumnType != typeof(long) &&
                    objColumnType != typeof(float) &&
                    objColumnType != typeof(double) &&
                    objColumnType != typeof(bool) &&
                    objColumnType != typeof(char) &&
                    objColumnType != typeof(decimal))
                {
                    // Add none numeric operators.
                    arrFilterComparisionOperator.Add(FilterComparisonOperator.Like);
                    arrFilterComparisionOperator.Add(FilterComparisonOperator.StartsWith);
                    arrFilterComparisionOperator.Add(FilterComparisonOperator.Contains);
                    arrFilterComparisionOperator.Add(FilterComparisonOperator.EndsWith);
                    arrFilterComparisionOperator.Add(FilterComparisonOperator.DoesNotStartWith);
                    arrFilterComparisionOperator.Add(FilterComparisonOperator.DoesNotEndWith);
                    arrFilterComparisionOperator.Add(FilterComparisonOperator.DoesNotContain);
                    arrFilterComparisionOperator.Add(FilterComparisonOperator.NotLike);
                }

                return arrFilterComparisionOperator;
            }

            /// <summary>
            /// Initializes the values combo box.
            /// </summary>
            private void InitializeValuesComboBox()
            {
                // If filter is not applied...
                if (string.IsNullOrEmpty(mobjValuesComboBox.Text) && mobjOperatorsButton.Tag == null)
                {
                    mobjValuesComboBox.OwningColumn = mobjOwningColumn;
                    mobjValuesComboBox.OwningDataGridView = mobjOwningDataGridView;
                    mobjValuesComboBox.InitializeFilterValues(true, false,false);
                }
            }

            /// <summary>
            /// Initializes the component.
            /// </summary>
            private void InitializeComponent()
            {
                this.mobjLeftPanel = new Gizmox.WebGUI.Forms.Panel();
                this.mobjOperatorsButton = new DataGridViewFilterButton();
                this.mobjRightPanel = new Gizmox.WebGUI.Forms.Panel();
                this.mobjClearButton = new DataGridViewFilterButton();
                this.mobjValuesComboBox = new DataGridViewFilterComboBox(this.mobjOwningDataGridView, this.mobjOwningColumn, this.mobjOwningCell);
                this.mobjOperatorsContextMenu = new Gizmox.WebGUI.Forms.ContextMenu();
                this.mobjLeftPanel.SuspendLayout();
                this.mobjRightPanel.SuspendLayout();
                this.SuspendLayout();
                // 
                // mobjLeftPanel
                // 
                this.mobjLeftPanel.Controls.Add(this.mobjOperatorsButton);
                this.mobjLeftPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
                this.mobjLeftPanel.Location = new System.Drawing.Point(0, 0);
                this.mobjLeftPanel.Name = "mobjLeftPanel";
                this.mobjLeftPanel.Size = new System.Drawing.Size(26, 24);
                this.mobjLeftPanel.TabIndex = 0;
                this.mobjLeftPanel.BackColor = Color.Transparent;
                // 
                // mobjOperatorsButton
                // 
                this.mobjOperatorsButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
                this.mobjOperatorsButton.DropDownMenu = mobjOperatorsContextMenu;
                this.mobjOperatorsButton.Location = new System.Drawing.Point(1, 0);
                this.mobjOperatorsButton.Name = "mobjOperatorsButton";
                this.mobjOperatorsButton.Size = new System.Drawing.Size(24, 24);
                this.mobjOperatorsButton.TabIndex = 1;
                this.mobjOperatorsButton.MenuClick += new MenuEventHandler(OperatorsContextMenuClick);
                this.mobjOperatorsButton.ToolTip = SR.GetString("SelectFilterOperation");
                // 
                // mobjRightPanel
                // 
                this.mobjRightPanel.Controls.Add(this.mobjClearButton);
                this.mobjRightPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
                this.mobjRightPanel.Location = new System.Drawing.Point(269, 0);
                this.mobjRightPanel.Name = "mobjRightPanel";
                this.mobjRightPanel.Size = new System.Drawing.Size(26, 24);
                this.mobjRightPanel.TabIndex = 0;
                this.mobjRightPanel.BackColor = Color.Transparent;
                // 
                // mobjClearButton
                // 
                this.mobjClearButton.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
                this.mobjClearButton.Location = new System.Drawing.Point(1, 0);
                this.mobjClearButton.Name = "mobjClearButton";
                this.mobjClearButton.Size = new System.Drawing.Size(24, 24);
                this.mobjClearButton.TabIndex = 0;
                this.mobjClearButton.Click += new EventHandler(ClearCriteria);
                this.mobjClearButton.ToolTip = SR.GetString("ClearFilterExpression");
                // 
                // mobjValuesComboBox
                // 
                this.mobjValuesComboBox.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Left | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
                this.mobjValuesComboBox.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
                this.mobjValuesComboBox.FormattingEnabled = true;
                this.mobjValuesComboBox.Location = new System.Drawing.Point(25, 2);
                this.mobjValuesComboBox.Name = "mobjValuesComboBox";
                this.mobjValuesComboBox.Size = new System.Drawing.Size(237, 21);
                this.mobjValuesComboBox.TabIndex = 1;
                this.mobjValuesComboBox.TextChanged += new EventHandler(ValuesComboBoxTextChanged);
                // 
                // DataGridViewFilterControl
                // 
                this.BackColor = System.Drawing.Color.Transparent;
                this.Dock = DockStyle.Fill;
                this.Controls.Add(this.mobjValuesComboBox);
                this.Controls.Add(this.mobjRightPanel);
                this.Controls.Add(this.mobjLeftPanel);
                this.Size = new System.Drawing.Size(287, 24);
                this.mobjLeftPanel.ResumeLayout(false);
                this.mobjRightPanel.ResumeLayout(false);
                this.ResumeLayout(false);
            }

            #endregion

            #region Properties

            /// <summary>
            /// Gets the comparision operator.
            /// </summary>
            public FilterComparisonOperator ComparisionOperator
            {
                get
                {
                    // Validate operator button.
                    if (mobjOperatorsButton != null)
                    {
                        // Validate operator button's tag.
                        if (mobjOperatorsButton.Tag != null)
                        {
                            // Return a fliter comparison operator.
                            return (FilterComparisonOperator)this.mobjOperatorsButton.Tag;
                        }
                    }

                    // Return a default value.
                    return FilterComparisonOperator.None;
                }                
            }

            /// <summary>
            /// Gets the comparision value.
            /// </summary>
            public string ComparisionValue
            {
                get
                {
                    // Validate values combo box.
                    if (mobjValuesComboBox != null)
                    {
                        return mobjValuesComboBox.Text;
                    }

                    return string.Empty;
                }
            }

            /// <summary>
            /// Gets the comparision Item.
            /// </summary>
            public object ComparisionItem
            {
                get
                {
                    // Validate values combo box.
                    if (mobjValuesComboBox != null)
                    {
                        return mobjValuesComboBox.SelectedItem;
                    }

                    return null;
                }
            }

            #endregion

        }

        #endregion
    }

    #endregion


    #endregion

    #region DataGridViewEditingControls

    #region DataGridViewTextBoxEditingControl Class

    /// <summary>
    /// Represents a text box control that can be hosted in a <see cref="T:System.Windows.Forms.DataGridViewTextBoxCell"></see>.
    /// </summary>
    [ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch), ToolboxItem(false), Serializable()]
    public class DataGridViewTextBoxEditingControl : TextBox, IDataGridViewEditingControl
    {

        #region Members

        #region Static

        #region Serializable Properties

        #endregion Serializable Properties

        #endregion Static

        #region Private Members

        private bool mblnRepositionEditingControlOnValueChange;
        private bool mblnEditingControlValueChanged;
        private int mintEditingControlRowIndex;

        private DataGridView mobjDataGridView = null;

        private static readonly DataGridViewContentAlignment menmAnyCenter = (DataGridViewContentAlignment.BottomCenter | DataGridViewContentAlignment.MiddleCenter | DataGridViewContentAlignment.TopCenter);
        private static readonly DataGridViewContentAlignment menmAnyRight = (DataGridViewContentAlignment.BottomRight | DataGridViewContentAlignment.MiddleRight | DataGridViewContentAlignment.TopRight);
        private static readonly DataGridViewContentAlignment menmAnyTop = (DataGridViewContentAlignment.TopRight | DataGridViewContentAlignment.TopCenter | DataGridViewContentAlignment.TopLeft);

        #endregion Private Members

        #region Constants

        #endregion Constants

        #region Serializable Events

        #endregion Serializable Events

        #endregion Members

        #region C'tors / D'tors

        /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.DataGridViewTextBoxEditingControl"></see> class.</summary>
        public DataGridViewTextBoxEditingControl()
        {
            base.TabStop = false;
        }

        #endregion C'tors / D'tors

        #region Methods

        #region Events

        /// <summary>
        /// Raises the <see cref="E:TextChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.NotifyDataGridViewOfValueChange();
        }

        #endregion Events

        /// <summary>Changes the control's user interface (UI) to be consistent with the specified cell style.</summary>
        /// <param name="objDataGridViewCellStyle">The <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> to use as the model for the UI.</param>
        public virtual void ApplyCellStyleToEditingControl(DataGridViewCellStyle objDataGridViewCellStyle)
        {
            this.Font = objDataGridViewCellStyle.Font;
            if (objDataGridViewCellStyle.BackColor.A < 0xff)
            {
                Color objColor = Color.FromArgb(0xff, objDataGridViewCellStyle.BackColor);
                this.BackColor = objColor;
                if (this.EditingControlDataGridView.EditingPanel != null)
                {
                    this.EditingControlDataGridView.EditingPanel.BackColor = objColor;
                }
            }
            else
            {
                this.BackColor = objDataGridViewCellStyle.BackColor;
            }
            this.ForeColor = objDataGridViewCellStyle.ForeColor;
            if (objDataGridViewCellStyle.WrapMode == DataGridViewTriState.True)
            {
                base.WordWrap = true;
            }
            base.TextAlign = TranslateAlignment(objDataGridViewCellStyle.Alignment);
            this.RepositionEditingControlOnValueChange = (objDataGridViewCellStyle.WrapMode == DataGridViewTriState.True) && ((objDataGridViewCellStyle.Alignment & menmAnyTop) == DataGridViewContentAlignment.NotSet);
        }

        /// <summary>Determines whether the specified key is a regular input key that the editing control should process or a special key that the <see cref="T:System.Windows.Forms.DataGridView"></see> should process.</summary>
        /// <returns>true if the specified key is a regular input key that should be handled by the editing control; otherwise, false.</returns>
        /// <param name="enmKeyData">A <see cref="T:System.Windows.Forms.Keys"></see> that represents the key that was pressed.</param>
        /// <param name="blnDataGridViewWantsInputKey">true when the <see cref="T:System.Windows.Forms.DataGridView"></see> wants to process the keyData; otherwise, false.</param>
        public virtual bool EditingControlWantsInputKey(Keys enmKeyData, bool blnDataGridViewWantsInputKey)
        {
            switch ((enmKeyData & Keys.KeyCode))
            {
                case Keys.Prior:
                case Keys.Next:
                    if (!this.EditingControlValueChanged)
                    {
                        break;
                    }
                    return true;

                case Keys.End:
                case Keys.Home:
                    if (this.SelectionLength == this.Text.Length)
                    {
                        break;
                    }
                    return true;

                case Keys.Left:
                    if (((this.RightToLeft != RightToLeft.No) || ((this.SelectionLength == 0) && (base.SelectionStart == 0))) && ((this.RightToLeft != RightToLeft.Yes) || ((this.SelectionLength == 0) && (base.SelectionStart == this.Text.Length))))
                    {
                        break;
                    }
                    return true;

                case Keys.Up:
                    if ((this.Text.IndexOf("\r\n") < 0) || ((base.SelectionStart + this.SelectionLength) < this.Text.IndexOf("\r\n")))
                    {
                        break;
                    }
                    return true;

                case Keys.Right:
                    if (((this.RightToLeft != RightToLeft.No) || ((this.SelectionLength == 0) && (base.SelectionStart == this.Text.Length))) && ((this.RightToLeft != RightToLeft.Yes) || ((this.SelectionLength == 0) && (base.SelectionStart == 0))))
                    {
                        break;
                    }
                    return true;

                case Keys.Down:
                    {
                        int intStartIndex = base.SelectionStart + this.SelectionLength;
                        if (this.Text.IndexOf("\r\n", intStartIndex) == -1)
                        {
                            break;
                        }
                        return true;
                    }
                case Keys.Delete:
                    if ((this.SelectionLength <= 0) && (base.SelectionStart >= this.Text.Length))
                    {
                        break;
                    }
                    return true;

                case Keys.Return:
                    if ((((enmKeyData & (Keys.Alt | Keys.Control | Keys.Shift)) == Keys.Shift) && this.Multiline) && base.AcceptsReturn)
                    {
                        return true;
                    }
                    break;
            }
            return !blnDataGridViewWantsInputKey;
        }

        /// <summary>Retrieves the formatted value of the cell.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the formatted version of the cell contents.</returns>
        /// <param name="enmContext">One of the <see cref="T:System.Windows.Forms.DataGridViewDataErrorContexts"></see> values that specifies the data error context.</param>
        public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts enmContext)
        {
            if (this.EditingControlDataGridView != null && this.EditingControlDataGridView.CurrentCell != null)
            {
                return this.EditingControlDataGridView.CurrentCell.EditingProposedValue;
            }
            return null;
        }

        /// <summary>
        /// Notifies the data grid view of value change.
        /// </summary>
        private void NotifyDataGridViewOfValueChange()
        {
            this.EditingControlValueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        }

        /// <summary>Prepares the currently selected cell for editing.</summary>
        /// <param name="blnSelectAll">true to select the cell contents; otherwise, false.</param>
        public virtual void PrepareEditingControlForEdit(bool blnSelectAll)
        {
            if (blnSelectAll)
            {
                base.SelectAll();
            }
            else
            {
                base.SelectionStart = this.Text.Length;
            }
        }

        /// <summary>
        /// Translates the alignment.
        /// </summary>
        /// <param name="enmAlign">The align.</param>
        /// <returns></returns>
        private static HorizontalAlignment TranslateAlignment(DataGridViewContentAlignment enmAlign)
        {
            if ((enmAlign & menmAnyRight) != DataGridViewContentAlignment.NotSet)
            {
                return HorizontalAlignment.Right;
            }
            if ((enmAlign & menmAnyCenter) != DataGridViewContentAlignment.NotSet)
            {
                return HorizontalAlignment.Center;
            }
            return HorizontalAlignment.Left;
        }

        #endregion Methods

        #region Properties

        /// <summary>Gets or sets the <see cref="T:System.Windows.Forms.DataGridView"></see> that contains the text box control.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.DataGridView"></see> that contains the <see cref="T:System.Windows.Forms.DataGridViewTextBoxCell"></see> that contains this control; otherwise, null if there is no associated <see cref="T:System.Windows.Forms.DataGridView"></see>.</returns>
        public virtual DataGridView EditingControlDataGridView
        {
            get
            {
                return this.mobjDataGridView;
            }
            set
            {
                this.mobjDataGridView = value;
            }
        }

        /// <summary>Gets or sets the formatted representation of the current value of the text box control.</summary>
        /// <returns>An object representing the current value of this control.</returns>
        public virtual object EditingControlFormattedValue
        {
            get
            {
                return this.GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
            }
            set
            {
                this.Text = (string)value;
            }
        }

        /// <summary>Gets or sets the index of the owning cell's parent row.</summary>
        /// <returns>The index of the row that contains the owning cell; -1 if there is no owning row.</returns>
        public virtual int EditingControlRowIndex
        {
            get
            {
                return this.mintEditingControlRowIndex;
            }
            set
            {
                this.mintEditingControlRowIndex = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether the current value of the text box control has changed.</summary>
        /// <returns>true if the value of the control has changed; otherwise, false.</returns>
        public virtual bool EditingControlValueChanged
        {
            get
            {
                return this.mblnEditingControlValueChanged;
            }
            set
            {
                this.mblnEditingControlValueChanged = value;
            }
        }

        /// <summary>Gets the cursor used when the mouse pointer is over the <see cref="P:System.Windows.Forms.DataGridView.EditingPanel"></see> but not over the editing control.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.Cursor"></see> that represents the mouse pointer used for the editing panel. </returns>
        public virtual Cursor EditingPanelCursor
        {
            get
            {
                return Cursors.Default;
            }
        }

        /// <summary>Gets a value indicating whether the cell contents need to be repositioned whenever the value changes.</summary>
        /// <returns>true if the cell's <see cref="P:System.Windows.Forms.DataGridViewCellStyle.WrapMode"></see> is set to true and the alignment property is not set to one of the <see cref="T:System.Windows.Forms.DataGridViewContentAlignment"></see> values that aligns the content to the top; otherwise, false.</returns>
        public virtual bool RepositionEditingControlOnValueChange
        {
            get
            {
                return this.mblnRepositionEditingControlOnValueChange;
            }
            private set
            {
                this.mblnRepositionEditingControlOnValueChange = value;
            }
        }

        #endregion Properties

    }

    #endregion

    #region DataGridViewComboBoxEditingControl Class

    /// <summary>Represents the hosted combo box control in a <see cref="T:System.Windows.Forms.DataGridViewComboBoxCell"></see>.</summary>
    /// <filterpriority>2</filterpriority>
    [ClassInterface(ClassInterfaceType.AutoDispatch), ComVisible(true), ToolboxItem(false), Serializable()]
    public class DataGridViewComboBoxEditingControl : ComboBox, IDataGridViewEditingControl
    {

        #region Members

        #region Static

        #region Serializable Properties

        #endregion Serializable Properties

        #endregion Static

        #region Private Members

        private bool mblnEditingControlValueChanged;
        private int mintEditingControlRowIndex;

        #endregion Private Members

        private DataGridView mobjDataGridView = null;

        #endregion Members

        #region C'tors / D'tors

        /// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.DataGridViewComboBoxEditingControl"></see> class.</summary>
        public DataGridViewComboBoxEditingControl()
        {
            base.TabStop = false;
        }

        #endregion C'tors / D'tors

        #region Methods

        #region Events

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            if (this.SelectedIndex != -1)
            {
                this.NotifyDataGridViewOfValueChange();
            }
        }


        #endregion Events

        /// <summary>Changes the control's user interface (UI) to be consistent with the specified cell style.</summary>
        /// <param name="objDataGridViewCellStyle">The <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> to use as a pattern for the UI.</param>
        public virtual void ApplyCellStyleToEditingControl(DataGridViewCellStyle objDataGridViewCellStyle)
        {
            this.Font = objDataGridViewCellStyle.Font;
            if (objDataGridViewCellStyle.BackColor.A < 0xff)
            {
                Color objColor = Color.FromArgb(0xff, objDataGridViewCellStyle.BackColor);
                this.BackColor = objColor;
                if (this.EditingControlDataGridView.EditingPanel != null)
                {
                    this.EditingControlDataGridView.EditingPanel.BackColor = objColor;
                }
            }
            else
            {
                this.BackColor = objDataGridViewCellStyle.BackColor;
            }
            this.ForeColor = objDataGridViewCellStyle.ForeColor;
        }

        /// <summary>Determines whether the specified key is a regular input key that the editing control should process or a special key that the <see cref="T:System.Windows.Forms.DataGridView"></see> should process.</summary>
        /// <returns>true if the specified key is a regular input key that should be handled by the editing control; otherwise, false.</returns>
        /// <param name="enmKeyData">A bitwise combination of <see cref="T:System.Windows.Forms.Keys"></see> values that represents the key that was pressed.</param>
        /// <param name="blnDataGridViewWantsInputKey">true to indicate that the <see cref="T:System.Windows.Forms.DataGridView"></see> control can process the key; otherwise, false.</param>
        public virtual bool EditingControlWantsInputKey(Keys enmKeyData, bool blnDataGridViewWantsInputKey)
        {
            return true;
        }

        /// <summary>Retrieves the formatted value of the cell.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the formatted version of the cell contents.</returns>
        /// <param name="enmContext">A bitwise combination of <see cref="T:System.Windows.Forms.DataGridViewDataErrorContexts"></see> values that specifies the data error context.</param>
        public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts enmContext)
        {
            if (this.EditingControlDataGridView != null && this.EditingControlDataGridView.CurrentCell != null)
            {
                return this.EditingControlDataGridView.CurrentCell.EditingProposedValue;
            }
            return null;
        }

        private void NotifyDataGridViewOfValueChange()
        {
            this.EditingControlValueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        }
        /// <summary>Prepares the currently selected cell for editing.</summary>
        /// <param name="blnSelectAll">true to select all of the cell's content; otherwise, false.</param>
        public virtual void PrepareEditingControlForEdit(bool blnSelectAll)
        {
            if (blnSelectAll)
            {
                base.SelectAll();
            }
        }

        #endregion Methods

        #region Properties

        /// <summary>Gets or sets the <see cref="T:System.Windows.Forms.DataGridView"></see> that contains the combo box control.</summary>
        /// <returns>The <see cref="T:System.Windows.Forms.DataGridView"></see> that contains the <see cref="T:System.Windows.Forms.DataGridViewComboBoxCell"></see> that contains this control; otherwise, null if there is no associated <see cref="T:System.Windows.Forms.DataGridView"></see>.</returns>
        public virtual DataGridView EditingControlDataGridView
        {
            get
            {
                return this.mobjDataGridView;
            }
            set
            {
                this.mobjDataGridView = value;
            }
        }

        /// <summary>Gets or sets the formatted representation of the current value of the control.</summary>
        /// <returns>An object representing the current value of this control.</returns>
        public virtual object EditingControlFormattedValue
        {
            get
            {
                return this.GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
            }
            set
            {
                string strA = value as string;
                if (strA != null)
                {
                    this.Text = strA;
                    if (string.Compare(strA, this.Text, true, CultureInfo.CurrentCulture) != 0)
                    {
                        this.SelectedIndex = -1;
                    }
                }
            }
        }

        /// <summary>Gets or sets the index of the owning cell's parent row.</summary>
        /// <returns>The index of the row that contains the owning cell; -1 if there is no owning row.</returns>
        public virtual int EditingControlRowIndex
        {
            get
            {
                return this.mintEditingControlRowIndex;
            }
            set
            {
                this.mintEditingControlRowIndex = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether the current value of the control has changed.</summary>
        /// <returns>true if the value of the control has changed; otherwise, false.</returns>
        public virtual bool EditingControlValueChanged
        {
            get
            {
                return this.mblnEditingControlValueChanged;
            }
            set
            {
                this.mblnEditingControlValueChanged = value;
            }
        }

        /// <summary>Gets the cursor used during editing.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.Cursor"></see> that represents the cursor image used by the mouse pointer during editing.</returns>
        public virtual Cursor EditingPanelCursor
        {
            get
            {
                return Cursors.Default;
            }
        }

        /// <summary>Gets a value indicating whether the cell contents need to be repositioned whenever the value changes.</summary>
        /// <returns>false in all cases.</returns>
        public virtual bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        #endregion Properties

    }

    #endregion

    #endregion
}
