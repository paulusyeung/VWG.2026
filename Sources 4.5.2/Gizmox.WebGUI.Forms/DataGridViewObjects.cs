#region Using

using System;
using System.Collections;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Security.Permissions;
using System.Drawing.Design;

using Gizmox.WebGUI.Common.Interfaces;
using Microsoft.Win32;
using System.Security;
using Gizmox.WebGUI.Forms.Serialization;
using Gizmox.WebGUI.Forms.Skins;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Reflection;
using System.Collections.Specialized;
using System.Collections.ObjectModel;


#endregion

namespace Gizmox.WebGUI.Forms
{
    #region DataGridViewBand Class

    /// <summary>Represents a linear collection of elements in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public class DataGridViewBand : DataGridViewElement, ICloneable, IDisposable
    {

        #region Members

        #region Private Members

        private int mintMinimumThickness;
        private int mintBandIndex;
        private int mintThickness;
        private int mintCachedThickness;
        private bool mblnBandIsRow;
        private DataGridViewCellStyle mobjDefaultCellStyle;
        private object mobjTag = null;
        private DataGridViewHeaderCell mobjHeaderCell = null;
        private Type mobjDefaultHeaderCellType = null;
        private ContextMenu mobjContextMenu = null;
        private ContextMenuStrip mobjContextMenuStrip = null;

        #endregion Private Members

        #endregion Members

        #region C'tors / D'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewBand"/> class.
        /// </summary>
        internal DataGridViewBand()
        {
            this.IndexInternal = -1;
        }

        #endregion C'tors / D'tors

        #region Methods

        #region Events

        /// <summary>Called when the band is associated with a different <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
        protected override void OnDataGridViewChanged()
        {
            if (this.HasDefaultCellStyle)
            {
                bool blnIsRow = this.IsRow;

                // Get Base DataGridView
                DataGridView objDataGridView = base.DataGridView;

                if (objDataGridView == null)
                {
                    this.DefaultCellStyle.RemoveScope(blnIsRow ? DataGridViewCellStyleScopes.Row : DataGridViewCellStyleScopes.Column);
                }
                else
                {
                    this.DefaultCellStyle.AddScope(objDataGridView, blnIsRow ? DataGridViewCellStyleScopes.Row : DataGridViewCellStyleScopes.Column);
                }
            }
            base.OnDataGridViewChanged();
        }

        /// <summary>
        /// Called when [state changed].
        /// </summary>
        /// <param name="elementState">State of the element.</param>
        internal void OnStateChanged(DataGridViewElementStates elementState)
        {
            // Get Base DataGridView
            DataGridView objDataGridView = base.DataGridView;

            if (objDataGridView != null)
            {
                if (this.IsRow)
                {
                    DataGridViewRowCollection objDataGridViewRowCollection = objDataGridView.Rows;
                    objDataGridViewRowCollection.InvalidateCachedRowCount(elementState);
                    objDataGridViewRowCollection.InvalidateCachedRowsHeight(elementState);
                    if (this.Index != -1)
                    {
                        objDataGridView.OnDataGridViewElementStateChanged(this, -1, elementState);
                    }
                }
                else
                {
                    DataGridViewColumnCollection objDataGridViewColumnCollection = objDataGridView.Columns;
                    objDataGridViewColumnCollection.InvalidateCachedColumnCount(elementState);
                    objDataGridViewColumnCollection.InvalidateCachedColumnsWidth(elementState);
                    objDataGridView.OnDataGridViewElementStateChanged(this, -1, elementState);
                }
            }

        }

        /// <summary>
        /// Called when [state changing].
        /// </summary>
        /// <param name="elementState">State of the element.</param>
        private void OnStateChanging(DataGridViewElementStates elementState)
        {
            // Get Base DataGridView
            DataGridView objDataGridView = base.DataGridView;

            if (objDataGridView != null)
            {
                if (this.IsRow)
                {
                    if (this.Index != -1)
                    {
                        objDataGridView.OnDataGridViewElementStateChanging(this, -1, elementState);
                    }
                }
                else
                {
                    objDataGridView.OnDataGridViewElementStateChanging(this, -1, elementState);
                }
            }

        }

        /// <summary>
        /// Raises the <see cref="E:RightClick"/> event.
        /// </summary>
        /// <param name="objMouseEventArgs">The <see cref="Gizmox.WebGUI.Forms.MouseEventArgs"/> instance containing the event data.</param>
        internal void OnRightClick(MouseEventArgs objMouseEventArgs)
        {
            ContextMenu objContextMenu = this.ContextMenu;

            if (this is DataGridViewRow)
            {
                objContextMenu = ((DataGridViewRow)this).HeaderCell.GetInheritedContextMenu(this.Index);
            }
            else if (this is DataGridViewColumn)
            {
                objContextMenu = ((DataGridViewColumn)this).HeaderCell.GetInheritedContextMenu(this.Index);
            }
            if (objContextMenu != null)
            {
                objContextMenu.Show(this.DataGridView, this, new Point(objMouseEventArgs.X, objMouseEventArgs.Y), DialogAlignment.Custom);
            }
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected internal override void FireEvent(IEvent objEvent)
        {
            switch (objEvent.Type)
            {
                case "Click":

                    // Get x and coordinates.
                    int intX = GetEventValue(objEvent, "X", 0);
                    int intY = GetEventValue(objEvent, "Y", 0);

                    //Get mouse event args from the objevent
                    MouseEventArgs objMouseEventArgs = new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, intX, intY, 0);

                    //If Mouse event args where found test if this is a right click event
                    if (objMouseEventArgs != null && objMouseEventArgs.Button == MouseButtons.Right)
                    {
                        //Fire the right click event
                        OnRightClick(objMouseEventArgs);
                    }
                    break;
            }
        }

        #endregion Events

        #region Render

        /// <summary>
        /// Renders the band attributes
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter, bool blnRenderOwner)
        {
            base.RenderAttributes(objContext, objWriter, blnRenderOwner);

            if (this.Index >= 0 && this.Frozen)
            {
                objWriter.WriteAttributeString(WGAttributes.Frozen, "1");
            }

            // If element can have context menu..
            if (ShouldRender(this.RenderMask, Renderable.ContextMenuAttribute))
            {
                // render context menu if needed
                ContextMenu objContextMenu = this.ContextMenu;

                //If this is a DataGridViewRow
                if (this is DataGridViewRow)
                {
                    objContextMenu = ((DataGridViewRow)this).HeaderCell.ContextMenu;
                }
                //if this is a DataGridViewColumn
                else if (this is DataGridViewColumn)
                {
                    objContextMenu = ((DataGridViewColumn)this).HeaderCell.ContextMenu;
                }

                if (objContextMenu != null)
                {
                    // Write context id attribute which will enable the client to call the context menu
                    objWriter.WriteAttributeString(WGAttributes.Menu, objContextMenu.ID.ToString());
                }
            }

            // Render ReadOnly attribute if the value is true
            if (this.ElementReadOnly == ElementReadOnlyType.True)
            {
                objWriter.WriteAttributeString(WGAttributes.ReadOnly, "1");
            }
        }

        #endregion Render

        /// <summary>
        /// Gets the height info.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <param name="intHeight">The height.</param>
        /// <param name="intMinimumHeight">The minimum height.</param>
        internal void GetHeightInfo(int intRowIndex, out int intHeight, out int intMinimumHeight)
        {
            intHeight = this.mintThickness;
            intMinimumHeight = this.mintMinimumThickness;
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
        /// Clones the internal.
        /// </summary>
        /// <param name="objDataGridViewBand">The data grid view band.</param>
        internal void CloneInternal(DataGridViewBand objDataGridViewBand)
        {
            objDataGridViewBand.IndexInternal = -1;
            bool blnIsRow = this.IsRow;

            objDataGridViewBand.BandIsRow = blnIsRow;
            if ((!blnIsRow || (this.Index >= 0)) || (base.DataGridView == null))
            {
                objDataGridViewBand.StateInternal = this.State & ~(DataGridViewElementStates.Selected | DataGridViewElementStates.Displayed);
            }

            objDataGridViewBand.Thickness = this.Thickness;
            objDataGridViewBand.MinimumThickness = this.MinimumThickness;
            objDataGridViewBand.CachedThickness = this.CachedThickness;
            objDataGridViewBand.Tag = this.Tag;
            objDataGridViewBand.LastModified = this.LastModified;
            objDataGridViewBand.LastModifiedParams = this.LastModifiedParams;

            if (this.HasDefaultCellStyle)
            {
                objDataGridViewBand.DefaultCellStyle = new DataGridViewCellStyle(this.DefaultCellStyle);
            }
            if (this.HasDefaultHeaderCellType)
            {
                objDataGridViewBand.DefaultHeaderCellType = this.DefaultHeaderCellType;
            }
        }

        /// <summary>Creates an exact copy of this band.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public virtual object Clone()
        {
            DataGridViewBand objDataGridViewBand = (DataGridViewBand)Activator.CreateInstance(base.GetType());
            if (objDataGridViewBand != null)
            {
                this.CloneInternal(objDataGridViewBand);
            }
            return objDataGridViewBand;

        }

        /// <summary>Releases all resources used by the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.  </summary>
        /// <filterpriority>1</filterpriority>
        public void Dispose()
        {
        }

        /// <summary>Releases the unmanaged resources used by the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see> and optionally releases the managed resources.  </summary>
        /// <param name="blnDisposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected virtual void Dispose(bool blnDisposing)
        {
        }

        /// <summary>Returns a string that represents the current band.</summary>
        /// <returns>A <see cref="T:System.String"></see> that represents the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(0x24);
            builder.Append("DataGridViewBand { Index=");
            builder.Append(this.Index.ToString(CultureInfo.CurrentCulture));
            builder.Append(" }");
            return builder.ToString();

        }

        /// <summary>
        /// Shoulds serialize DefaultHeaderCellType value.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeDefaultHeaderCellType()
        {
            return mobjDefaultHeaderCellType != null;
        }

        /// <summary>
        /// Shoulds serialize resizable value.
        /// </summary>
        /// <returns></returns>
        internal bool ShouldSerializeResizable()
        {
            return this.StateIncludes(DataGridViewElementStates.ResizableSet);
        }


        #endregion Methods

        #region Properties

        /// <summary>Gets or sets the default cell style of the band.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> associated with the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public virtual DataGridViewCellStyle DefaultCellStyle
        {
            get
            {
                if (mobjDefaultCellStyle == null)
                {
                    mobjDefaultCellStyle = new DataGridViewCellStyle();
                    mobjDefaultCellStyle.AddScope(base.DataGridView, this.IsRow ? DataGridViewCellStyleScopes.Row : DataGridViewCellStyleScopes.Column);
                }
                return mobjDefaultCellStyle;
            }
            set
            {
                DataGridViewCellStyle objDataGridViewCellStyle = null;
                bool blnIsRow = this.IsRow;

                if (this.HasDefaultCellStyle)
                {
                    objDataGridViewCellStyle = this.DefaultCellStyle;
                    objDataGridViewCellStyle.RemoveScope(blnIsRow ? DataGridViewCellStyleScopes.Row : DataGridViewCellStyleScopes.Column);
                }

                // Get Base DataGridView
                DataGridView objDataGridView = base.DataGridView;

                if ((value != null) || mobjDefaultCellStyle != null)
                {
                    if (value != null)
                    {
                        value.AddScope(objDataGridView, blnIsRow ? DataGridViewCellStyleScopes.Row : DataGridViewCellStyleScopes.Column);
                    }
                    mobjDefaultCellStyle = value;
                }
                if (((((objDataGridViewCellStyle != null) && (value == null)) || ((objDataGridViewCellStyle == null) && (value != null))) || (((objDataGridViewCellStyle != null) && (value != null)) && !objDataGridViewCellStyle.Equals(this.DefaultCellStyle))) && (objDataGridView != null))
                {
                    objDataGridView.OnBandDefaultCellStyleChanged(this);
                }
            }

        }

        /// <summary>
        /// Gets or sets the run-time type of the default header cell.
        /// </summary>
        /// <value>The type of the default header cell.</value>
        /// <returns>A <see cref="T:System.Type"></see> that describes the run-time class of the object used as the default header cell.</returns>
        /// <exception cref="T:System.ArgumentException">The specified value when setting this property is not a <see cref="T:System.Type"></see> representing <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see> or a derived type. </exception>
        [Browsable(false)]
        public Type DefaultHeaderCellType
        {
            get
            {
                Type objType1 = mobjDefaultHeaderCellType;
                if (objType1 != null)
                {
                    return objType1;
                }
                if (this.IsRow)
                {
                    return typeof(DataGridViewRowHeaderCell);
                }
                return typeof(DataGridViewColumnHeaderCell);
            }
            set
            {
                if ((value != null) || mobjDefaultHeaderCellType != null)
                {
                    if (!Type.GetType("Gizmox.WebGUI.Forms.DataGridViewHeaderCell").IsAssignableFrom(value))
                    {
                        throw new ArgumentException(SR.GetString("DataGridView_WrongType", new object[] { "DefaultHeaderCellType", "Gizmox.WebGUI.Forms.DataGridViewHeaderCell" }));
                    }
                    mobjDefaultHeaderCellType = value;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has header cell.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has header cell; otherwise, <c>false</c>.
        /// </value>
        internal virtual bool HasHeaderCell
        {
            get
            {
                return (mobjHeaderCell != null);
            }
        }

        /// <summary>
        /// Gets or sets the cached thickness.
        /// </summary>
        /// <value>The cached thickness.</value>
        internal int CachedThickness
        {
            get
            {
                return this.mintCachedThickness;
            }
            set
            {
                this.mintCachedThickness = value;
            }
        }

        /// <summary>Gets a value indicating whether the band is currently displayed onscreen. </summary>
        /// <returns>true if the band is currently onscreen; otherwise, false.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool Displayed
        {
            get
            {
                return ((this.State & DataGridViewElementStates.Displayed) != DataGridViewElementStates.None);
            }
        }

        /// <summary>Gets or sets a value indicating whether the band will move when a user scrolls through the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
        /// <returns>true if the band cannot be scrolled from view; otherwise, false. The default is false.</returns>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(false)]
        public virtual bool Frozen
        {
            get
            {
                return ((this.State & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None);
            }
            set
            {
                if (((this.State & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None) != value)
                {
                    this.OnStateChanging(DataGridViewElementStates.Frozen);
                    if (value)
                    {
                        base.StateInternal = this.State | DataGridViewElementStates.Frozen;
                    }
                    else
                    {
                        base.StateInternal = this.State & ~DataGridViewElementStates.Frozen;
                    }
                    this.OnStateChanged(DataGridViewElementStates.Frozen);
                }
            }

        }

        /// <summary>Gets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.DefaultCellStyle"></see> property has been set. </summary>
        /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.DefaultCellStyle"></see> property has been set; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public bool HasDefaultCellStyle
        {
            get
            {
                return mobjDefaultCellStyle != null;
            }
        }

        /// <summary>Gets or sets the header cell of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewHeaderCell"></see> representing the header cell of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>.</returns>
        /// <exception cref="T:System.ArgumentException">The specified value when setting this property is not a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell"></see> and this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see> instance is of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.-or-The specified value when setting this property is not a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see> and this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see> instance is of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see>.</exception>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        protected DataGridViewHeaderCell HeaderCellCore
        {
            get
            {
                DataGridViewHeaderCell cell1 = mobjHeaderCell;
                if (cell1 == null)
                {
                    // Get Base DataGridView
                    DataGridView objDataGridView = base.DataGridView;

                    cell1 = (DataGridViewHeaderCell)Activator.CreateInstance(this.DefaultHeaderCellType);
                    cell1.DataGridViewInternal = objDataGridView;
                    if (this.IsRow)
                    {
                        cell1.OwningRowInternal = (DataGridViewRow)this;
                        mobjHeaderCell = cell1;
                        return cell1;
                    }
                    DataGridViewColumn objColumn1 = this as DataGridViewColumn;
                    cell1.OwningColumnInternal = objColumn1;
                    mobjHeaderCell = cell1;
                    if ((objDataGridView != null) && (objDataGridView.SortedColumn == objColumn1))
                    {
                        DataGridViewColumnHeaderCell cell2 = cell1 as DataGridViewColumnHeaderCell;
                        cell2.SortGlyphDirection = objDataGridView.SortOrder;
                    }
                }
                return cell1;
            }
            set
            {
                // Get Base DataGridView
                DataGridView objDataGridView = base.DataGridView;

                DataGridViewHeaderCell cell1 = mobjHeaderCell;
                bool blnIsRow = this.IsRow;

                if ((value != null) || cell1 != null)
                {
                    if (cell1 != null)
                    {
                        cell1.DataGridViewInternal = null;
                        if (blnIsRow)
                        {
                            cell1.OwningRowInternal = null;
                        }
                        else
                        {
                            cell1.OwningColumnInternal = null;
                            ((DataGridViewColumnHeaderCell)cell1).SortGlyphDirectionInternal = SortOrder.None;
                        }
                    }
                    if (value != null)
                    {
                        if (blnIsRow)
                        {
                            if (!(value is DataGridViewRowHeaderCell))
                            {
                                throw new ArgumentException(SR.GetString("DataGridView_WrongType", new object[] { "HeaderCell", "Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell" }));
                            }
                            if (value.OwningRow != null)
                            {
                                value.OwningRow.HeaderCell = null;
                            }
                            value.OwningRowInternal = (DataGridViewRow)this;
                        }
                        else
                        {
                            if (!(value is DataGridViewColumnHeaderCell))
                            {
                                throw new ArgumentException(SR.GetString("DataGridView_WrongType", new object[] { "HeaderCell", "Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell" }));
                            }
                            if (value.OwningColumn != null)
                            {
                                value.OwningColumn.HeaderCell = null;
                            }
                            value.OwningColumnInternal = (DataGridViewColumn)this;
                        }
                        value.DataGridViewInternal = objDataGridView;
                    }
                    mobjHeaderCell = value;
                }
                if (((((value == null) && (cell1 != null)) || ((value != null) && (cell1 == null))) || (((value != null) && (cell1 != null)) && !cell1.Equals(value))) && (objDataGridView != null))
                {
                    objDataGridView.OnBandHeaderCellChanged(this);
                }
            }

        }

        /// <summary>Gets the relative position of the band within the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
        /// <returns>The zero-based position of the band in the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowCollection"></see> or <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnCollection"></see> that it is contained within. The default is -1, indicating that there is no associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public int Index
        {
            get
            {
                return this.mintBandIndex;
            }
        }

        /// <summary>
        /// Sets the index internal.
        /// </summary>
        /// <value>The index internal.</value>
        internal int IndexInternal
        {
            set
            {
                this.mintBandIndex = value;
            }
        }

        /// <summary>
        /// Sets a value indicating whether [displayed internal].
        /// </summary>
        /// <value><c>true</c> if [displayed internal]; otherwise, <c>false</c>.</value>
        internal bool DisplayedInternal
        {
            set
            {
                if (value)
                {
                    base.StateInternal = this.State | DataGridViewElementStates.Displayed;
                }
                else
                {
                    base.StateInternal = this.State & ~DataGridViewElementStates.Displayed;
                }
                if (base.DataGridView != null)
                {
                    this.OnStateChanged(DataGridViewElementStates.Displayed);
                }

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
                this.OnStateChanged(DataGridViewElementStates.ReadOnly);
            }
        }

        /// <summary>
        /// Sets a value indicating whether [selected internal].
        /// </summary>
        /// <value><c>true</c> if [selected internal]; otherwise, <c>false</c>.</value>
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
                    this.OnStateChanged(DataGridViewElementStates.Selected);
                }
            }
        }

        /// <summary>Gets the cell style in effect for the current band, taking into account style inheritance.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> associated with the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see>. The default is null.</returns>
        [Browsable(false)]
        public virtual DataGridViewCellStyle InheritedStyle
        {
            get
            {
                return null;
            }
        }

        /// <summary>Gets a value indicating whether the band represents a row.</summary>
        /// <returns>true if the band represents a <see cref="T:System.Windows.Forms.DataGridViewRow"></see>; otherwise, false.</returns>
        protected bool IsRow
        {
            get
            {
                return this.BandIsRow;
            }
        }

        /// <summary>Gets a value indicating whether the band represents a row.</summary>
        /// <returns>true if the band represents a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>; otherwise, false.</returns>
        protected bool BandIsRow
        {
            get
            {
                return this.mblnBandIsRow;
            }
            set
            {
                this.mblnBandIsRow = value;
            }
        }

        /// <summary>
        /// Gets or sets the thickness internal.
        /// </summary>
        /// <value>The thickness internal.</value>
        internal int ThicknessInternal
        {
            get
            {
                return this.mintThickness;
            }
            set
            {
                this.mintThickness = value;

                // Get Base DataGridView
                DataGridView objDataGridView = base.DataGridView;

                if (objDataGridView != null)
                {
                    this.UpdateParams(AttributeType.Layout);
                    objDataGridView.Update(true);

                    objDataGridView.OnBandThicknessChanged(this);
                }
            }
        }

        /// <summary>
        /// Sets the thickness internally without invoking the OnRowHeightChanged event.
        /// </summary>
        /// <param name="value">The value.</param>
        internal void SetThicknessInternal(int value)
        {
            this.mintThickness = value;
        }

        /// <summary>
        /// Gets or sets the thickness.
        /// </summary>
        /// <value>The thickness.</value>
        internal int Thickness
        {
            get
            {
                int intIndex = this.Index;

                if (this.IsRow && (intIndex > -1))
                {
                    int intHeight;
                    int intMinimumHeight;
                    this.GetHeightInfo(intIndex, out intHeight, out intMinimumHeight);
                    return intHeight;
                }
                return this.mintThickness;
            }
            set
            {
                // Get Base DataGridView
                DataGridView objDataGridView = base.DataGridView;

                int intMinimumThickness = this.MinimumThickness;
                bool blnIsRow = this.IsRow;

                if (value < intMinimumThickness)
                {
                    value = intMinimumThickness;
                }
                if (value > 0x10000)
                {
                    if (blnIsRow)
                    {
                        object[] arrArgs = new object[] { "Height", value.ToString(CultureInfo.CurrentCulture), 0x10000.ToString(CultureInfo.CurrentCulture) };
                        throw new ArgumentOutOfRangeException("Height", SR.GetString("InvalidHighBoundArgumentEx", arrArgs));
                    }
                    object[] arrObjects2 = new object[] { "Width", value.ToString(CultureInfo.CurrentCulture), 0x10000.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("Width", SR.GetString("InvalidHighBoundArgumentEx", arrObjects2));
                }
                bool blnFlag = true;
                if (blnIsRow)
                {
                    if ((objDataGridView != null) && (objDataGridView.AutoSizeRowsMode != DataGridViewAutoSizeRowsMode.None))
                    {
                        this.CachedThickness = value;
                        blnFlag = false;
                    }
                }
                else
                {
                    DataGridViewColumn objDataGridViewColumn = (DataGridViewColumn)this;
                    DataGridViewAutoSizeColumnMode enmInheritedAutoSizeMode = objDataGridViewColumn.InheritedAutoSizeMode;
                    if (((enmInheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.Fill) && (enmInheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.None)) && (enmInheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.NotSet))
                    {
                        this.CachedThickness = value;
                        blnFlag = false;
                    }
                    else if (((enmInheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill) && (objDataGridView != null)) && objDataGridViewColumn.Visible)
                    {
                        IntPtr handle = objDataGridView.Handle;
                        objDataGridView.AdjustFillingColumn(objDataGridViewColumn, value);
                        blnFlag = false;
                    }
                }
                if (blnFlag && (this.mintThickness != value))
                {
                    if (objDataGridView != null)
                    {
                        objDataGridView.OnBandThicknessChanging();
                    }
                    this.ThicknessInternal = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the minimum thickness.
        /// </summary>
        /// <value>The minimum thickness.</value>
        internal int MinimumThickness
        {
            get
            {
                int intIndex = this.Index;

                if (this.IsRow && (intIndex > -1))
                {
                    int intHeight;
                    int intMinimumHeight;
                    this.GetHeightInfo(intIndex, out intHeight, out intMinimumHeight);
                    return intMinimumHeight;
                }
                return this.mintMinimumThickness;
            }
            set
            {
                if (this.mintMinimumThickness != value)
                {
                    // Get Base DataGridView
                    DataGridView objDataGridView = base.DataGridView;

                    bool blnIsRow = this.IsRow;
                    if (value < 2)
                    {
                        if (blnIsRow)
                        {
                            object[] args = new object[] { 2.ToString(CultureInfo.CurrentCulture) };
                            throw new ArgumentOutOfRangeException("MinimumHeight", value, SR.GetString("DataGridViewBand_MinimumHeightSmallerThanOne", args));
                        }
                        object[] arrObjects2 = new object[] { 2.ToString(CultureInfo.CurrentCulture) };
                        throw new ArgumentOutOfRangeException("MinimumWidth", value, SR.GetString("DataGridViewBand_MinimumWidthSmallerThanOne", arrObjects2));
                    }
                    if (this.Thickness < value)
                    {
                        if ((objDataGridView != null) && !blnIsRow)
                        {
                            objDataGridView.OnColumnMinimumWidthChanging((DataGridViewColumn)this, value);
                        }
                        this.Thickness = value;
                    }
                    this.mintMinimumThickness = value;
                    if (objDataGridView != null)
                    {
                        objDataGridView.OnBandMinimumThicknessChanged(this);
                    }
                }
            }
        }




        /// <summary>Gets or sets a value indicating whether the user can edit the band's cells.</summary>
        /// <returns>true if the user cannot edit the band's cells; otherwise, false. The default is false.</returns>
        /// <exception cref="T:System.InvalidOperationException">When setting this property, this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBand"></see> instance is a shared <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(false)]
        public virtual bool ReadOnly
        {
            get
            {
                // Get Base DataGridView
                DataGridView objDataGridView = base.DataGridView;

                return (((this.State & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None) || ((objDataGridView != null) && objDataGridView.ReadOnly));
            }
            set
            {
                // Get Base DataGridView
                DataGridView objDataGridView = base.DataGridView;

                if (objDataGridView != null)
                {
                    if (objDataGridView.ReadOnly)
                    {
                        return;
                    }
                    if (this.BandIsRow)
                    {
                        if (this.Index == -1)
                        {
                            throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", new object[] { "ReadOnly" }));
                        }
                        this.OnStateChanging(DataGridViewElementStates.ReadOnly);
                        objDataGridView.SetReadOnlyRowCore(this.Index, value);
                    }
                    else
                    {
                        this.OnStateChanging(DataGridViewElementStates.ReadOnly);
                        objDataGridView.SetReadOnlyColumnCore(this.Index, value);
                    }
                }
                else if (((this.State & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None) != value)
                {
                    if (value)
                    {
                        if (this.BandIsRow)
                        {
                            foreach (DataGridViewCell objDataGridViewCell in ((DataGridViewRow)this).Cells)
                            {
                                if (objDataGridViewCell.ReadOnly)
                                {
                                    objDataGridViewCell.ReadOnlyInternal = false;
                                }
                            }
                        }
                        base.StateInternal = this.State | DataGridViewElementStates.ReadOnly;
                    }
                    else
                    {
                        base.StateInternal = this.State & ~DataGridViewElementStates.ReadOnly;
                    }
                }

                // Update element readonly value
                this.ElementReadOnly = value ? ElementReadOnlyType.True : ElementReadOnlyType.False;
            }
        }

        /// <summary>
        /// Gets or sets the element read only.
        /// </summary>
        /// <value>The element read only.</value>
        protected internal override ElementReadOnlyType ElementReadOnly
        {
            get
            {
                return base.ElementReadOnly;
            }
            set
            {
                base.ElementReadOnly = value;

                // check if band is row
                if (this.BandIsRow)
                {
                    // go over all cells and remove the readonly value from property store
                    foreach (DataGridViewCell objDataGridViewCell in ((DataGridViewRow)this).Cells)
                    {
                        objDataGridViewCell.ClearElementReadOnly();
                    }
                }
                else
                {
                    // get DataGridView 
                    DataGridView objDataGridView = base.DataGridView;
                    if (objDataGridView != null)
                    {
                        // get column index
                        int intColumnIndex = this.Index;

                        // check that the column index is in range
                        if (intColumnIndex >= 0 && intColumnIndex < objDataGridView.Columns.Count)
                        {
                            // get rows collection
                            DataGridViewRowCollection objDataGridViewRowCollection = objDataGridView.Rows;

                            foreach (DataGridViewRow objDataGridViewRow in objDataGridViewRowCollection)
                            {
                                // remove the readonly value from property store 
                                // in the column position of the row
                                objDataGridViewRow.Cells[intColumnIndex].ClearElementReadOnly();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the band can be resized in the user interface (UI).</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewTriState.True"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(true)]
        public virtual DataGridViewTriState Resizable
        {
            get
            {
                if ((this.State & DataGridViewElementStates.ResizableSet) != DataGridViewElementStates.None)
                {
                    if ((this.State & DataGridViewElementStates.Resizable) == DataGridViewElementStates.None)
                    {
                        return DataGridViewTriState.False;
                    }
                    return DataGridViewTriState.True;
                }

                // Get Base DataGridView
                DataGridView objDataGridView = base.DataGridView;

                if (objDataGridView == null)
                {
                    return DataGridViewTriState.NotSet;
                }
                if (!objDataGridView.AllowUserToResizeColumns)
                {
                    return DataGridViewTriState.False;
                }
                return DataGridViewTriState.True;
            }
            set
            {
                DataGridViewTriState resizable = this.Resizable;
                if (value == DataGridViewTriState.NotSet)
                {
                    base.StateInternal = this.State & ~DataGridViewElementStates.ResizableSet;
                }
                else
                {
                    base.StateInternal = this.State | DataGridViewElementStates.ResizableSet;
                    if (((this.State & DataGridViewElementStates.Resizable) != DataGridViewElementStates.None) != (value == DataGridViewTriState.True))
                    {
                        if (value == DataGridViewTriState.True)
                        {
                            base.StateInternal = this.State | DataGridViewElementStates.Resizable;
                        }
                        else
                        {
                            base.StateInternal = this.State & ~DataGridViewElementStates.Resizable;
                        }
                    }
                }
                if (resizable != this.Resizable)
                {
                    this.OnStateChanged(DataGridViewElementStates.Resizable);
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the band is in a selected user interface (UI) state.</summary>
        /// <returns>true if the band is selected; otherwise, false.</returns>
        /// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is true, but the band has not been added to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. -or-This property is being set on a shared <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</exception>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual bool Selected
        {
            get
            {
                return ((this.State & DataGridViewElementStates.Selected) != DataGridViewElementStates.None);
            }
            set
            {
                // Get Base DataGridView
                DataGridView objDataGridView = base.DataGridView;

                if (objDataGridView != null)
                {
                    int intIndex = this.Index;

                    if (!this.IsRow)
                    {
                        if ((objDataGridView.SelectionMode == DataGridViewSelectionMode.FullColumnSelect) || (objDataGridView.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect))
                        {
                            objDataGridView.SetSelectedColumnCoreInternal(intIndex, value);
                        }
                    }
                    else
                    {
                        if (intIndex == -1)
                        {
                            throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", new object[] { "Selected" }));
                        }
                        if ((objDataGridView.SelectionMode == DataGridViewSelectionMode.FullRowSelect) || (objDataGridView.SelectionMode == DataGridViewSelectionMode.RowHeaderSelect))
                        {
                            objDataGridView.SetSelectedRowCoreInternal(intIndex, value);
                        }
                    }
                }
                else if (value)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewBand_CannotSelect"));
                }
            }
        }

        /// <summary>Gets or sets the object that contains data to associate with the band.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that contains information associated with the band. The default is null.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Tag
        {
            get
            {
                return mobjTag;
            }
            set
            {
                mobjTag = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the band is visible to the user.
        /// </summary>
        /// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
        /// <returns>true if the band is visible; otherwise, false. The default is true.</returns>
        /// <exception cref="T:System.InvalidOperationException">The specified value when setting this property is false and the band is the row for new records.</exception>
        [DefaultValue(true)]
        public virtual bool Visible
        {
            get
            {
                return ((this.State & DataGridViewElementStates.Visible) != DataGridViewElementStates.None);
            }
            set
            {
                if (((this.State & DataGridViewElementStates.Visible) != DataGridViewElementStates.None) != value)
                {
                    // Get Base DataGridView
                    DataGridView objDataGridView = base.DataGridView;

                    if ((((objDataGridView != null) && this.IsRow) && ((objDataGridView.NewRowIndex != -1) && (objDataGridView.NewRowIndex == this.Index))) && !value)
                    {
                        throw new InvalidOperationException(SR.GetString("DataGridViewBand_NewRowCannotBeInvisible"));
                    }
                    this.OnStateChanging(DataGridViewElementStates.Visible);
                    SetVisibleInternal(value);
                    this.OnStateChanged(DataGridViewElementStates.Visible);
                }
            }
        }

        /// <summary>
        /// Sets the visible internal.
        /// </summary>
        /// <param name="blnValue">if set to <c>true</c> [BLN value].</param>
        internal void SetVisibleInternal(bool blnValue)
        {
            if (blnValue)
            {
                base.StateInternal = this.State | DataGridViewElementStates.Visible;
            }
            else
            {
                base.StateInternal = this.State & ~DataGridViewElementStates.Visible;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has default header cell type.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has default header cell type; otherwise, <c>false</c>.
        /// </value>
        internal bool HasDefaultHeaderCellType
        {
            get
            {
                return mobjDefaultHeaderCellType != null;
            }
        }

        /// <summary>
        /// Gets or sets the context menu code.  
        /// </summary>
        [System.ComponentModel.Browsable(true)]
        [System.ComponentModel.DefaultValue(null)]
        public virtual ContextMenu ContextMenu
        {
            get
            {
                if (this.IsRow)
                {
                    return ((DataGridViewRow)this).GetContextMenu(this.Index);
                }
                return this.ContextMenuInternal;
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
                if (this.BandIsRow)
                {
                    return ((DataGridViewRow)this).GetContextMenuStrip(this.Index);
                }
                return this.ContextMenuStripInternal;
            }
            set
            {
                this.ContextMenuStripInternal = value;
            }
        }

        /// <summary>
        /// Gets or sets the context menu internal.
        /// </summary>
        /// <value>The context menu internal.</value>
        internal ContextMenu ContextMenuInternal
        {
            get
            {
                return mobjContextMenu;
            }
            set
            {
                ContextMenu objStrip = mobjContextMenu;
                if (objStrip != value)
                {
                    EventHandler objEventHandler = new EventHandler(this.DetachContextMenu);
                    if (objStrip != null)
                    {
                        objStrip.Disposed -= objEventHandler;
                    }
                    mobjContextMenu = value;
                    if (value != null)
                    {
                        value.Disposed += objEventHandler;
                    }

                    // Get Base DataGridView
                    DataGridView objDataGridView = base.DataGridView;

                    if (objDataGridView != null)
                    {
                        objDataGridView.OnBandContextMenuChanged(this);
                    }
                }
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
                return mobjContextMenuStrip;
            }
            set
            {
                ContextMenuStrip objStrip = mobjContextMenuStrip;
                if (objStrip != value)
                {
                    EventHandler objEventHandler = new EventHandler(this.DetachContextMenuStrip);
                    if (objStrip != null)
                    {
                        objStrip.Disposed -= objEventHandler;
                    }
                    mobjContextMenuStrip = value;
                    if (value != null)
                    {
                        value.Disposed += objEventHandler;
                    }

                    // Get Base DataGridView
                    DataGridView objDataGridView = base.DataGridView;

                    if (objDataGridView != null)
                    {
                        objDataGridView.OnBandContextMenuStripChanged(this);
                    }
                }
            }
        }

        #endregion Properties
    }

    #endregion

    #region DataGridViewElement Class

    /// <summary>Provides the base class for elements of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public class DataGridViewElement : SerializableObject, IRenderableComponentMember, IIdentifiedComponent
    {
        /// <summary>
        /// Renderable enumeration.
        /// </summary>
        [Serializable()]
        internal enum Renderable
        {
            /// <summary>
            /// Represents ContextMenu attribute.
            /// </summary>
            ContextMenuAttribute = 1,

            /// <summary>
            /// Represents Selected attribute.
            /// </summary>
            SelectedAttribute = 2,

            /// <summary>
            /// Represents ErrorText attribute.
            /// </summary>
            ErrorTextAttribute = 4,

        }

        /// <summary>
        /// PreRenderable enumeration.
        /// </summary>
        [Serializable()]
        internal enum PreRenderable
        {
            /// <summary>
            /// Represents DataGridViewCellStyle.
            /// </summary>
            CellStyle = 1,

        }

        /// <summary>
        /// Determines whether element should render provided renderable.
        /// </summary>
        /// <param name="intRenderMask">The render mask.</param>
        /// <param name="enmRenderableToCheck">The attribute to check.</param>
        /// <returns></returns>
        internal static bool ShouldRender(int intRenderMask, Renderable enmRenderableToCheck)
        {
            // If (mask AND attr == attr) => (mask bit[attr] == 1) => do not render.
            return (intRenderMask & (int)enmRenderableToCheck) != (int)enmRenderableToCheck;
        }

        /// <summary>
        /// Determines whether element should prerender provided prerenderable.
        /// </summary>
        /// <param name="intPreRenderMask">The int pre render mask.</param>
        /// <param name="enmPreRenderableToCheck">The enm pre renderable to check.</param>
        /// <returns></returns>
        internal static bool ShouldPreRender(int intPreRenderMask, PreRenderable enmPreRenderableToCheck)
        {
            // If (mask AND attr == attr) => (mask bit[attr] == 1) => do not prerender.
            return (intPreRenderMask & (int)enmPreRenderableToCheck) != (int)enmPreRenderableToCheck;
        }

        /// <summary>
        /// ElementReadOnly Type
        /// </summary>
        [Serializable()]
        protected internal enum ElementReadOnlyType
        {
            /// <summary>
            /// value not set
            /// </summary>
            NotSet = 0,
            /// <summary>
            /// element is not read only
            /// </summary>
            False = 1,
            /// <summary>
            /// element is read only
            /// </summary>
            True = 2

        }

        #region Class Members

        #region Private Members

        private string mstrTagName;
        private ElementReadOnlyType menmElementReadOnly = ElementReadOnlyType.NotSet;
        private DataGridViewElementStates menmState;
        private DataGridViewElementClientStates menmClientState = DataGridViewElementClientStates.None;
        private DataGridView mobjDataGridView = null;

        #endregion Private Members

        #region Serializable Properties

        #endregion Serializable Properties

        #endregion

        #region C'Tor / D'Tor

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElement"></see> class.</summary>
        public DataGridViewElement()
        {
            this.State = DataGridViewElementStates.Visible;
            InitializeCompoent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objDGVTemplate"></param>
        internal DataGridViewElement(DataGridViewElement objDGVTemplate)
        {
            InitializeCompoent();
            this.State = objDGVTemplate.State & (DataGridViewElementStates.Visible | DataGridViewElementStates.ResizableSet | DataGridViewElementStates.Resizable | DataGridViewElementStates.ReadOnly | DataGridViewElementStates.Frozen);
        }

        /// <summary>
        /// Initializes the compoent.
        /// </summary>
        private void InitializeCompoent()
        {
            // Initialize a sure rendered time stamp
            this.LastModifiedParams = this.LastModified = GetCurrentTicks(true);
        }

        #endregion

        #region Methods

        #region Render Related

        /// <summary>
        /// Gets the member ID.
        /// </summary>
        /// <value>The member ID.</value>
        protected virtual string MemberID
        {
            get
            {
                return "0";
            }
        }

        /// <summary>
        /// Gets the location.
        /// </summary>
        /// <value>The location.</value>
        protected internal virtual Point Location
        {
            get
            {
                return Point.Empty;
            }
        }

        /// <summary>
        /// Gets the member ID internal.
        /// </summary>
        /// <value>The member ID internal.</value>
        internal string MemberIDInternal
        {
            get
            {
                return this.MemberID;
            }
        }

        /// <summary>
        /// Gets or sets the last modified params.
        /// </summary>
        /// <value>The last modified params.</value>
        internal long LastModifiedParams;

        /// <summary>
        /// Gets the owner ID.
        /// </summary>
        /// <value>The owner ID.</value>
        private string OwnerID
        {
            get
            {
                DataGridView objDataGridView = this.DataGridView;
                return objDataGridView.GetProxyPropertyValue<long>("ID", objDataGridView.ID).ToString();
            }
        }

        /// <summary>
        /// Gets or sets the type of the last modified params.
        /// </summary>
        /// <value>The type of the last modified params.</value>
        internal AttributeType LastModifiedParamsType = AttributeType.None;

        /// <summary>
        /// Gets or sets the name of the tag.
        /// </summary>
        /// <value>The name of the tag.</value>
        protected string TagName
        {
            get
            {
                return this.mstrTagName;
            }
            set
            {
                this.mstrTagName = value;
            }
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        [Obsolete("Use GetCriticalEventsData instead")]
        protected virtual EventTypes GetCriticalEvents()
        {
            return EventTypes.None;
        }

        /// <summary>
        /// Gets the critical event name.
        /// </summary>
        protected virtual CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = new CriticalEventsData();
            EventTypes objObseleteEvents = GetCriticalEvents();
            RegisteredComponent.MergeCriticalEventsWithObselete(ref objEvents, objObseleteEvents);

            return objEvents;
        }

        /// <summary>
        /// Clears the element read only from property store.
        /// </summary>
        protected internal void ClearElementReadOnly()
        {
            this.menmElementReadOnly = ElementReadOnlyType.NotSet;
        }

        /// <summary>
        /// Gets the element read only.
        /// </summary>
        /// <param name="blnElementReadOnlyValue">if set to <c>true</c> [BLN element read only value].</param>
        /// <returns><c>true</c> if the property store have value, <c>false</c> if proprty store is empty</returns>
        protected internal bool GetElementReadOnly(out bool blnElementReadOnlyValue)
        {
            bool blnFound = (menmElementReadOnly != ElementReadOnlyType.NotSet);

            //get value from property store
            blnElementReadOnlyValue = (this.menmElementReadOnly == ElementReadOnlyType.True);

            return blnFound;
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected internal virtual void FireEvent(IEvent objEvent)
        {

        }

        /// <summary>
        /// Renders the element's event attributes.
        /// </summary>
        /// <param name="objContext">context.</param>
        /// <param name="objWriter">writer.</param>       
        protected virtual void RenderElementEventAttributes(IContext objContext, IAttributeWriter objWriter, bool blnForceRender)
        {
            // Render critical events.
            CriticalEventsData objCriticalEventsData = GetCriticalEventsData();
            if (objCriticalEventsData.HasEvents || blnForceRender)
            {
                string strCriticalEvents = objCriticalEventsData.ToClientString();
                objWriter.WriteAttributeString(WGAttributes.Events, strCriticalEvents);
            }
        }

        /// <summary>
        /// Renders the element's meta attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        protected virtual void RenderElementAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
        {
            // Render control identifier
            objWriter.WriteAttributeString(WGAttributes.MemberID, this.MemberID);

            // Render owner id
            if (blnRenderOwner)
            {
                objWriter.WriteAttributeString(WGAttributes.OwnerID, this.OwnerID);
            }

            // render event attributes
            RenderElementEventAttributes(objContext, objWriter, false);
        }

        /// <summary>
        /// Renders the element update attributes.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        protected virtual void RenderElementUpdateAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            // Render control identifier
            objWriter.WriteAttributeString(WGAttributes.MemberID, this.MemberID);

            // Render owner id
            if (blnRenderOwner)
            {
                objWriter.WriteAttributeString(WGAttributes.OwnerID, this.OwnerID);
            }

            // Render event attributes
            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Events))
            {
                RenderElementEventAttributes(objContext, objWriter, true);
            }
        }

        /// <summary>
        /// Renders the controls meta attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        protected virtual void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
        {
            // render component attributes
            RenderElementAttributes(objContext, objWriter, blnRenderOwner);
        }

        /// <summary>
        /// Renders the updated attributes
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        protected virtual void RenderUpdatedAttributes(IContext objContext, IAttributeWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            // render component attributes
            RenderElementUpdateAttributes(objContext, objWriter, lngRequestID, blnRenderOwner);
        }

        /// <summary>
        /// Adds a critical event delegate to the list.
        /// </summary>
        /// <param name="objSerializableEvent">The serializable event.</param>
        /// <param name="objValue">The delegate to add to the list.</param>
        protected void AddCriticalHandler(SerializableEvent objSerializableEvent, Delegate objValue)
        {
            if (base.AddHandler(objSerializableEvent, objValue))
            {
                //flag that the events attribute should be rerendered
                this.UpdateParams(AttributeType.Events);
            }
        }

        /// <summary>
        /// Removes a critical event delegate from the list.
        /// </summary>
        /// <param name="objSerializableEvent">The serializable event.</param>
        /// <param name="objValue">The delegate to remove from the list.</param>
        protected void RemoveCriticalHandler(SerializableEvent objSerializableEvent, Delegate objValue)
        {
            if (base.RemoveHandler(objSerializableEvent, objValue))
            {
                //flag that the events attribute should be rerendered
                this.UpdateParams(AttributeType.Events);
            }
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        protected virtual void RenderComponents(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {


        }

        void IRenderableComponentMember.RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            this.RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
        }

        /// <summary>
        /// Pres the render component.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="lngRequestID">The request ID.</param>
        /// <param name="blnForcePreRender">if set to <c>true</c> [BLN force pre render].</param>
        internal virtual void PreRenderComponent(IContext objContext, long lngRequestID, bool blnForcePreRender)
        {
        }

        /// <summary>
        /// Posts the render component.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="blnForcePostRender">if set to <c>true</c> [BLN force post render].</param>
        internal virtual void PostRenderComponent(IContext objContext, long lngRequestID, bool blnForcePostRender)
        {
            // Reset  params.
            this.ResetParams();
        }

        /// <summary>
        /// Checks if the current control needs rendering and
        /// continues to process sub tree/
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        protected virtual void RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            // if control is dirty
            if (IsDirty(lngRequestID))
            {
                // write control element tags
                objWriter.WriteStartElement(WGConst.Prefix, this.TagName, WGConst.Namespace);

                // add generic attributes
                RenderAttributes(objContext, (IAttributeWriter)objWriter, blnRenderOwner);

                // render control
                RenderComponents(objContext, objWriter, 0, blnRenderOwner);

                // close control element tag
                objWriter.WriteEndElement();
            }
            else
            {
                // if only control params are dirty
                if (IsDirtyAttributes(lngRequestID))
                {
                    // write control element tags
                    objWriter.WriteStartElement(WGConst.Prefix, WGTags.UpdateParams, WGConst.Namespace);

                    // render control
                    RenderUpdatedAttributes(objContext, (IAttributeWriter)objWriter, lngRequestID, blnRenderOwner);

                    // render control
                    RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);

                    // close control element tag
                    objWriter.WriteEndElement();
                }
                else
                {
                    // render control
                    RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);
                }
            }

        }

        /// <summary>
        /// Gets the event buttons value.
        /// </summary>
        /// <param name="objEvent">The event.</param>
        /// <param name="enmDefault">The default value.</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected MouseButtons GetEventButtonsValue(IEvent objEvent, MouseButtons enmDefault)
        {
            // Get the button property of the event
            string strButton = objEvent["BTN"];
            switch (strButton)
            {
                case "L":
                    return MouseButtons.Left;
                case "R":
                    return MouseButtons.Right;
                case "M":
                    return MouseButtons.Middle;
                default:
                    return enmDefault;
            }
        }

        /// <summary>
        /// Gets the event integer attribute value.
        /// </summary>
        /// <param name="objEvent">The event.</param>
        /// <param name="strAttribute">The attribute name.</param>
        /// <param name="intDefault">The default integer value.</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        #endregion

        #region Dirty Management

        /// <summary>
        /// Full updates of this instance.
        /// </summary>
        public virtual void Update()
        {
            this.LastModified = GetCurrentTicks();
            this.LastModifiedParamsType = AttributeType.None;
        }

        /// <summary>
        /// Redraw only
        /// </summary>
        /// <param name="blnRedrawOnly">if set to <c>true</c> [BLN redraw only].</param>
        public virtual void Update(bool blnRedrawOnly)
        {
            if (blnRedrawOnly) UpdateParams(AttributeType.Redraw);
            else Update();
        }

        /// <summary>
        /// Redraw only
        /// </summary>
        /// <param name="enmParams">The enm params.</param>
        internal virtual void Update(AttributeType enmParams)
        {
            UpdateParams(enmParams);
        }

        /// <summary>
        /// Updates only the parameters of this instance.
        /// </summary>
        protected virtual void UpdateParams()
        {
            this.LastModifiedParams = GetCurrentTicks();
            this.LastModifiedParamsType = AttributeType.All;
        }

        /// <summary>
        /// Updates the params.
        /// </summary>
        /// <param name="enmParams">The enm params.</param>
        protected virtual internal void UpdateParams(AttributeType enmParams)
        {
            this.LastModifiedParams = GetCurrentTicks();
            this.LastModifiedParamsType |= enmParams;
        }

        /// <summary>
        /// Determines whether the specified component is dirty.
        /// </summary>
        /// <param name="lngRequestID">Request ID.</param>
        /// <returns>
        /// 	<c>true</c> if the specified component is dirty; otherwise, <c>false</c>.
        /// </returns>
        internal bool IsDirty(long lngRequestID)
        {
            return this.LastModified > lngRequestID;
        }

        /// <summary>
        /// Resets the params.
        /// </summary>
        protected void ResetParams()
        {
            this.LastModifiedParamsType = AttributeType.None;
        }

        /// <summary>
        /// Determines whether the specified component is dirty.
        /// </summary>
        /// <param name="lngRequestID">Request ID.</param>
        /// <returns>
        /// 	<c>true</c> if the specified component is dirty; otherwise, <c>false</c>.
        /// </returns>
        protected bool IsDirtyAttributes(long lngRequestID)
        {
            return this.LastModifiedParams > lngRequestID;
        }

        /// <summary>
        /// Determines whether [is dirty attributes] [the specified LNG request ID].
        /// </summary>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="enmParams">The enm params.</param>
        /// <returns>
        /// 	<c>true</c> if [is dirty attributes] [the specified LNG request ID]; otherwise, <c>false</c>.
        /// </returns>
        protected bool IsDirtyAttributes(long lngRequestID, AttributeType enmParams)
        {
            return this.LastModifiedParams > lngRequestID && (((int)this.LastModifiedParamsType & (int)enmParams) > 0);
        }

        #endregion

        #region Event Raising Methods

        /// <summary>Called when the element is associated with a different <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>.</summary>
        protected virtual void OnDataGridViewChanged()
        {
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellClick"></see> event. </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
        protected void RaiseCellClick(DataGridViewCellEventArgs e)
        {
            DataGridView objDataGridView = this.DataGridView;

            if (objDataGridView != null)
            {
                objDataGridView.OnCellClickInternal(e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellContentClick"></see> event. </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
        protected void RaiseCellContentClick(DataGridViewCellEventArgs e)
        {
            DataGridView objDataGridView = this.DataGridView;

            if (objDataGridView != null)
            {
                objDataGridView.OnCellContentClickInternal(e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellContentDoubleClick"></see> event. </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
        protected void RaiseCellContentDoubleClick(DataGridViewCellEventArgs e)
        {
            DataGridView objDataGridView = this.DataGridView;

            if (objDataGridView != null)
            {
                objDataGridView.OnCellContentDoubleClickInternal(e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValueChanged"></see> event. </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data. </param>
        protected void RaiseCellValueChanged(DataGridViewCellEventArgs e)
        {
            this.RaiseCellValueChanged(e, false);
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.CellValueChanged"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellEventArgs"></see> that contains the event data.</param>
        /// <param name="blnClientSource">if set to <c>true</c> [BLN client source].</param>
        protected internal void RaiseCellValueChanged(DataGridViewCellEventArgs e, bool blnClientSource)
        {
            DataGridView objDataGridView = this.DataGridView;

            if (objDataGridView != null)
            {
                objDataGridView.OnCellValueChangedInternal(e, blnClientSource);
            }

        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataError"></see> event. </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewDataErrorEventArgs"></see> that contains the event data. </param>
        protected void RaiseDataError(DataGridViewDataErrorEventArgs e)
        {
            DataGridView objDataGridView = this.DataGridView;

            if (objDataGridView != null)
            {
                objDataGridView.OnDataErrorInternal(e);
            }
        }

        /// <summary>Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.MouseWheel"></see> event. </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.MouseEventArgs"></see> that contains the event data. </param>
        protected void RaiseMouseWheel(MouseEventArgs e)
        {
            DataGridView objDataGridView = this.DataGridView;

            if (objDataGridView != null)
            {
                objDataGridView.OnMouseWheelInternal(e);
            }
        }

        #endregion

        #region State Related

        internal bool StateExcludes(DataGridViewElementStates elementState)
        {
            return ((this.State & elementState) == DataGridViewElementStates.None);
        }

        internal bool StateIncludes(DataGridViewElementStates elementState)
        {
            return ((this.State & elementState) == elementState);
        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the element read only.
        /// </summary>
        /// <value>The element read only.</value>
        protected internal virtual ElementReadOnlyType ElementReadOnly
        {
            get
            {
                return this.menmElementReadOnly;
            }
            set
            {
                this.menmElementReadOnly = value;
            }
        }

        /// <summary>
        /// This is a recursive function that loop through a control and all of its parents
        /// cheching if one of the controls(and control containers) is hidden or
        /// disabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is events enabled; otherwise, <c>false</c>.
        /// </value>        
        /// <returns>false if one of the controls is hidden or disabled.</returns>
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public virtual bool IsEventsEnabled
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the default render mask. Initialized to render all.
        /// </summary>
        internal virtual int RenderMask
        {
            get
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the default prerender mask. Initialized to prerender all.
        /// </summary>
        internal virtual int PreRenderMask
        {
            get
            {
                return 0;
            }
        }

        /// <summary>Gets the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control associated with this element.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control that contains this element. The default is null.</returns>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public DataGridView DataGridView
        {
            get
            {
                return this.mobjDataGridView;
            }
            private set
            {
                this.mobjDataGridView = value;
            }
        }

        internal DataGridView DataGridViewInternal
        {
            set
            {
                DataGridView objDataGridView = this.DataGridView;

                if (objDataGridView != value)
                {
                    this.DataGridView = value;
                    this.OnDataGridViewChanged();
                }
            }
        }

        /// <summary>Gets the user interface (UI) state of the element.</summary>
        /// <returns>A bitwise combination of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values representing the state.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual DataGridViewElementStates State
        {
            get
            {
                return this.menmState;
            }
            private set
            {
                this.menmState = value;
            }
        }

        /// <summary>
        /// Gets or sets the state of the client.
        /// </summary>
        /// <value>The state of the client.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        internal DataGridViewElementClientStates ClientState
        {
            get
            {
                return this.menmClientState;
            }
            set
            {
                this.menmClientState = value;
            }
        }

        /// <summary>
        /// Gets or sets the last modified.
        /// </summary>
        /// <value>The last modified.</value>
        internal long LastModified;

        internal DataGridViewElementStates StateInternal
        {
            set
            {
                this.State = value;
            }
        }

        #endregion

        #region IIdentifiedComponent Members

        string IIdentifiedComponent.ID
        {
            get
            {
                return this.MemberID;
            }
        }

        #endregion
    }

    #endregion

    #region DataGridViewFilterRow Class

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class DataGridViewFilterRow : DataGridViewRow
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the row is frozen.
        /// </summary>
        /// <returns>true if the row is frozen; otherwise, false.</returns>
        ///   
        /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Frozen
        {
            get
            {
                return true;
            }
            set
            {
                base.Frozen = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether users can resize the row or indicating that the behavior is inherited from the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeRows"></see> property.
        /// </summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> value that indicates whether the row can be resized or whether it can be resized only when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeRows"></see> property is set to true.</returns>
        ///   
        /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        public override DataGridViewTriState Resizable
        {
            get
            {
                return DataGridViewTriState.False;
            }
        }

        /// <summary>
        /// Gets the render attribute validator.
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
        /// Gets a value indicating whether this instance is filter row.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is filter row; otherwise, <c>false</c>.
        /// </value>       
        public override bool IsFilterRow
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the row is visible.
        /// </summary>
        /// <returns>true if the row is visible; otherwise, false.</returns>
        ///   
        /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        public override bool Visible
        {
            get
            {
                return true;
            }
            set
            {

            }
        }

        #endregion

        /// <summary>
        /// Renders the band attributes
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
        {
            base.RenderAttributes(objContext, objWriter, blnRenderOwner);

            // Render "Filter Row" attribute.
            objWriter.WriteAttributeText(WGAttributes.FilterRow, "1");
        }
    }

    #endregion

    #region DataGridViewRow Class

    /// <summary>
    /// 
    /// </summary>
    public enum RowExpansionType
    {
        Inherit = 0,
        Show = 1,
        Hide = 2,
    }

    /// <summary>Represents a row in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [TypeConverter("Gizmox.WebGUI.Forms.DataGridViewRowConverter, Gizmox.WebGUI.Forms")]
    [Serializable()]
    public class DataGridViewRow : DataGridViewBand
    {

        #region Members

        #region Serializable Events

        #endregion Serializable Events

        #region Private Members

        private string mstrErrorText = null;
        private static Type objRowType = typeof(DataGridViewRow);
        private DataGridViewCellCollection mobjCells = null;
        private HierarchicDataGridView mobjChildGrid = null;
        private HierarchicInfo mobjRelatedHierarchyInfo;
        private DataGridViewRowStyle mobjStyle = null;
        private RowExpansionType menmRowExpansionType;

        /// <summary>
        /// Gets or sets the type of the row expansion.
        /// </summary>
        /// <value>
        /// The type of the row expansion.
        /// </value>
        [DefaultValue(Gizmox.WebGUI.Forms.RowExpansionType.Inherit)]
        public RowExpansionType RowExpansionIndicatorVisibility
        {
            get { return menmRowExpansionType; }
            set
            {
                if (menmRowExpansionType != value)
                {
                    menmRowExpansionType = value;

                    UpdateParams(AttributeType.Control);
                }
            }
        }
        private bool mblnIsExpanded;

        #endregion Private Members

        #endregion Members

        #region C'tors / D'tors

        static DataGridViewRow()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> class without using a template.</summary>
        public DataGridViewRow()
        {
            base.BandIsRow = true;
            base.MinimumThickness = 3;

            base.Thickness = GetDefaultRowHeight();

            // Create a new local empty DataGridViewRowStyle.
            this.mobjStyle = new DataGridViewRowStyle(this);

            this.TagName = WGTags.DataGridViewRow;
        }


        #endregion C'tors / D'tors

        #region Methods

        #region Events

        /// <summary>
        /// Called when [shared state changed].
        /// </summary>
        /// <param name="intSharedRowIndex">Index of the shared row.</param>
        /// <param name="enmElementState">State of the element.</param>
        internal void OnSharedStateChanged(int intSharedRowIndex, DataGridViewElementStates enmElementState)
        {
            // Get Base DataGridView
            DataGridView objDataGridView = base.DataGridView;

            if (objDataGridView != null)
            {
                DataGridViewRowCollection objDataGridViewRowCollection = objDataGridView.Rows;
                objDataGridView.Rows.InvalidateCachedRowCount(enmElementState);
                objDataGridView.Rows.InvalidateCachedRowsHeight(enmElementState);
                objDataGridView.OnDataGridViewElementStateChanged(this, intSharedRowIndex, enmElementState);
            }
        }

        /// <summary>
        /// Called when [shared state changing].
        /// </summary>
        /// <param name="intSharedRowIndex">Index of the shared row.</param>
        /// <param name="enmElementState">State of the element.</param>
        internal void OnSharedStateChanging(int intSharedRowIndex, DataGridViewElementStates enmElementState)
        {
            base.DataGridView.OnDataGridViewElementStateChanging(this, intSharedRowIndex, enmElementState);
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
                case "Resize":
                    int intValue = int.Parse(objEvent[WGAttributes.Value]);
                    if (intValue > 5)
                    {
                        this.ThicknessInternal = intValue;
                    }
                    break;

                case "Click":
                    if (this.DataGridView != null)
                    {
                        // Get x and coordinates.
                        int intX = GetEventValue(objEvent, "X", 0);
                        int intY = GetEventValue(objEvent, "Y", 0);

                        //Get mouse event args from the objevent
                        MouseEventArgs objMouseEventArgs = new MouseEventArgs(GetEventButtonsValue(objEvent, MouseButtons.Left), 1, intX, intY, 0);

                        // Create event arguments variables.
                        DataGridViewCellMouseEventArgs objDataGridViewCellMouseEventArgs = new DataGridViewCellMouseEventArgs(-1, this.Index, intX, intY, objMouseEventArgs);

                        // Raise row header mouse click.
                        this.DataGridView.OnRowHeaderMouseClickInternal(objDataGridViewCellMouseEventArgs);
                    }
                    break;

                case "DoubleClick":
                    if (this.DataGridView != null)
                    {
                        // Get x and coordinates.
                        int intX = GetEventValue(objEvent, "X", 0);
                        int intY = GetEventValue(objEvent, "Y", 0);

                        // Create event arguments variables.
                        DataGridViewCellMouseEventArgs objDataGridViewCellMouseEventArgs = new DataGridViewCellMouseEventArgs(-1, this.Index, intX, intY, new MouseEventArgs(MouseButtons.Left, 1, intX, intY, 0));

                        // Raise cell content double click event.
                        this.DataGridView.OnRowHeaderMouseDoubleClickInternal(objDataGridViewCellMouseEventArgs);
                    }
                    break;
                case "Expand":
                    this.ExpandInternal(true);
                    break;
                case "Collapse":
                    this.Collapse();
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
                if (this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWROWHEIGHTCHANGED))
                {
                    objEvents.Set(WGEvents.SizeChange);
                }
            }

            return objEvents;
        }

        #endregion Events

        #region Render

        /// <summary>
        /// Checks if the current control needs rendering and
        /// continues to process sub tree/
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="blnRenderOwner">if set to <c>true</c> [BLN render owner].</param>
        protected override void RenderComponent(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            base.RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
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

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Visual))
            {
                // Render selected attribute.
                RenderSelectedAttribute(objWriter, true);
            }

            if (this.IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                // Renders the number of child rows.
                RenderNumberOfChildRows(objWriter, true);

                RenderRowExpansionType(objWriter, true);
            }


            if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
            {
                if (this.Visible)
                {
                    objWriter.WriteAttributeString(WGAttributes.Height, this.Height.ToString());
                }
            }
        }

        /// <summary>
        /// Renders the band attributes
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter, bool blnRenderOwner)
        {
            base.RenderAttributes(objContext, objWriter, blnRenderOwner);

            if (this.DataGridView != null)
            {
                // Check visibility.
                if (this.Visible)
                {
                    // Render the is new row attribute.
                    if (this.IsNewRow)
                    {
                        objWriter.WriteAttributeString(WGAttributes.IsNew, "1");
                    }

                    // If element can be selected..
                    if (ShouldRender(this.RenderMask, Renderable.SelectedAttribute))
                    {
                        // Render selected attribute.
                        RenderSelectedAttribute(objWriter, false);
                    }

                    // Render the height attribute.
                    objWriter.WriteAttributeString(WGAttributes.Height, this.Height.ToString());

                    // Render the resize attribute.
                    if (this.Resizable == DataGridViewTriState.False)
                    {
                        objWriter.WriteAttributeString(WGAttributes.Resize, "0");
                    }

                    // If element can have error text.
                    if (ShouldRender(this.RenderMask, Renderable.ErrorTextAttribute))
                    {
                        // Render the error message attribute.
                        string strErrorText = this.ErrorText;
                        if (!string.IsNullOrEmpty(strErrorText))
                        {
                            objWriter.WriteAttributeText(WGAttributes.ErrorMessage, strErrorText);
                        }
                    }

                    // Render the following attributes only if this row is hierarchic (has a child grid)
                    if (this.DataGridView != null && this.DataGridView.IsHierarchic(HierarchicInfoSelector.Any) && !this.IsNewRow)
                    {
                        // Render the following attributes only if this row is expanded
                        if (this.Expanded)
                        {
                            objWriter.WriteAttributeString(WGAttributes.IsExpanded, "1");
                        }

                        // Render the child grid's height for all expanded rows
                        if (this.DataGridView.IsHierarchic(HierarchicInfoSelector.Bounded) && this.mobjChildGrid != null)
                        {
                            objWriter.WriteAttributeString(WGAttributes.ChildGridHeight, this.ChildGrid.Height.ToString());
                        }

                        if (this.DataGridView.IsHierarchic(HierarchicInfoSelector.Bounded))
                        {
                            // Renders the number of child rows.
                            RenderNumberOfChildRows(objWriter, false);
                        }

                        RenderRowExpansionType(objWriter, false);
                    }


                    // Get Local row style.
                    DataGridViewRowStyle objStyle = this.Style;
                    if (objStyle != null)
                    {
                        // Check if boder value should be rendered.
                        if (objStyle.BorderWidth != 0 &&
                            objStyle.BorderColor != Color.Empty &&
                            objStyle.BorderStyle != BorderStyle.None)
                        {
                            objWriter.WriteAttributeString(WGAttributes.BorderStyle, BorderValue.GetBorderName(objStyle.BorderStyle));
                            objWriter.WriteAttributeString(WGAttributes.BorderColor, BorderValue.GetBorderColor(objStyle.BorderColor).ToString());
                            objWriter.WriteAttributeString(WGAttributes.BorderWidth, objStyle.BorderWidth.ToString());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Renders the type of the row expansion.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderRowExpansionType(IAttributeWriter objWriter, bool blnForceRender)
        {
            RowExpansionType enmType = this.RowExpansionIndicatorVisibility;

            if (enmType != Forms.RowExpansionType.Inherit || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.ExpansionIndicator, ((int)enmType).ToString());
            }
        }

        /// <summary>
        /// Renders the number of child rows.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderNumberOfChildRows(IAttributeWriter objWriter, bool blnForceRender)
        {
            if (this.ContainedInBindedHierarchicGrid)
            {
                // check if this row already has a 'live' child grid instance
                if (this.mobjChildGrid != null)
                {
                    // Get the child grid's row count
                    int intNumberOfRealRows = this.mobjChildGrid.AllowUserToAddRows ? this.mobjChildGrid.Rows.Count - 1 : this.mobjChildGrid.Rows.Count;

                    // Render the row count
                    objWriter.WriteAttributeString(WGAttributes.NumberOfChildRows, intNumberOfRealRows);
                }
            }
        }

        /// <summary>
        /// Renders the selected attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderSelectedAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            // Render the selected attribute.
            if (this.Selected &&
                (this.DataGridView.SelectionMode == DataGridViewSelectionMode.FullRowSelect ||
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
        /// Pres the render component.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The request ID.</param>
        /// <param name="blnForcePreRender">if set to <c>true</c> [BLN force pre render].</param>
        private void PreRenderHeaderCell(IContext objContext, long lngRequestID, bool blnForcePreRender)
        {
            // Get header cell.
            DataGridViewRowHeaderCell objDataGridViewRowHeaderCell = this.HeaderCell;
            if (objDataGridViewRowHeaderCell != null)
            {
                // Pre render header cell.
                objDataGridViewRowHeaderCell.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
            }
        }

        /// <summary>
        /// Posts the render header cell.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="blnForcePostRender">if set to <c>true</c> [BLN force post render].</param>
        private void PostRenderHeaderCell(IContext objContext, long lngRequestID, bool blnForcePostRender)
        {
            // Get header cell.
            DataGridViewRowHeaderCell objDataGridViewRowHeaderCell = this.HeaderCell;
            if (objDataGridViewRowHeaderCell != null)
            {
                // Post render header cell.
                objDataGridViewRowHeaderCell.PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
            }
        }

        /// <summary>
        /// Pres the render component.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The request ID.</param>
        /// <param name="blnForcePreRender">if set to <c>true</c> [BLN force pre render].</param>
        internal override void PreRenderComponent(IContext objContext, long lngRequestID, bool blnForcePreRender)
        {
            base.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);

            // Prerender header cell.
            PreRenderHeaderCell(objContext, lngRequestID, blnForcePreRender);

            if (this.DataGridView != null)
            {
                // Get first column.
                DataGridViewColumn objDataGridViewColumn = this.DataGridView.Columns.GetFirstColumn(DataGridViewElementStates.Visible);

                // Loops while having a valid column.
                while (objDataGridViewColumn != null &&
                        objDataGridViewColumn.Index >= 0 &&
                        objDataGridViewColumn.Index < this.Cells.Count)
                {
                    // Render current cell.
                    (this.Cells[objDataGridViewColumn.Index]).PreRenderComponent(objContext, lngRequestID, blnForcePreRender);

                    // Get next column.
                    objDataGridViewColumn = this.DataGridView.Columns.GetNextColumn(objDataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                }
            }

            if (this.Expanded)
            {
                if (this.ContainedInBindedHierarchicGrid)
                {
                    // Don't check if ChildGrid != null here!  if ContainedInBindedHierarchicGrid == true && Expanded == true then ChildGrid must not be null (if it is then this is a bug)
                    this.ChildGrid.PreRenderControlInternal(objContext, lngRequestID);
                }
            }
        }

        /// <summary>
        /// Posts the render component.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="lngRequestID">The LNG request ID.</param>
        /// <param name="blnForcePostRender">if set to <c>true</c> [BLN force post render].</param>
        internal override void PostRenderComponent(IContext objContext, long lngRequestID, bool blnForcePostRender)
        {
            base.PostRenderComponent(objContext, lngRequestID, blnForcePostRender);

            // Postrender header cell.
            PostRenderHeaderCell(objContext, lngRequestID, blnForcePostRender);

            if (this.DataGridView != null)
            {
                // Get first column.
                DataGridViewColumn objDataGridViewColumn = this.DataGridView.Columns.GetFirstColumn(DataGridViewElementStates.Visible);

                // Loops while having a valid column.
                while (objDataGridViewColumn != null &&
                        objDataGridViewColumn.Index >= 0 &&
                        objDataGridViewColumn.Index < this.Cells.Count)
                {
                    // Render current cell.
                    (this.Cells[objDataGridViewColumn.Index]).PostRenderComponent(objContext, lngRequestID, blnForcePostRender);

                    // Get next column.
                    objDataGridViewColumn = this.DataGridView.Columns.GetNextColumn(objDataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                }
            }

            if (this.Expanded)
            {
                if (this.ContainedInBindedHierarchicGrid)
                {
                    // Don't check if ChildGrid != null here!  if ContainedInBindedHierarchicGrid == true && Expanded == true then ChildGrid must not be null (if it is then this is a bug)
                    this.ChildGrid.PostRenderControlInternal(objContext, lngRequestID);
                }
            }
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderComponents(IContext objContext, IResponseWriter objWriter, long lngRequestID, bool blnRenderOwner)
        {
            base.RenderComponents(objContext, objWriter, lngRequestID, blnRenderOwner);

            if (this.HeaderCell != null)
            {
                ((IRenderableComponentMember)this.HeaderCell).RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);
            }

            if (this.DataGridView != null)
            {
                // Get first column.
                DataGridViewColumn objDataGridViewColumn = this.DataGridView.Columns.GetFirstColumn(DataGridViewElementStates.Visible);

                // Loops while having a valid column.
                while (objDataGridViewColumn != null &&
                        objDataGridViewColumn.Index >= 0 &&
                        objDataGridViewColumn.Index < this.Cells.Count)
                {
                    // Render current cell.
                    ((IRenderableComponentMember)this.Cells[objDataGridViewColumn.Index]).RenderComponent(objContext, objWriter, lngRequestID, blnRenderOwner);

                    // Get next column.
                    objDataGridViewColumn = this.DataGridView.Columns.GetNextColumn(objDataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                }

                if (this.Expanded)
                {
                    if (this.ContainedInBindedHierarchicGrid)
                    {
                        // Don't check if ChildGrid != null here!  if ContainedInBindedHierarchicGrid == true && Expanded == true then ChildGrid must not be null (if it is then this is a bug)
                        this.ChildGrid.RenderControl(objContext, objWriter, lngRequestID);
                    }
                }
            }
        }

        #endregion Render

        /// <summary>
        /// Gets the default height of the row.
        /// </summary>
        /// <returns></returns>
        public static int GetDefaultRowHeight()
        {
            int intFontHeight = 0;

            intFontHeight = CommonUtils.GetFontHeight(Control.DefaultFont);

            return intFontHeight + 9;
        }

        /// <summary>
        /// Resets the child grid.
        /// </summary>
        internal void ResetChildGrid()
        {
            if (this.mobjChildGrid != null)
            {
                this.Collapse();

                this.mobjChildGrid = null;
            }
        }

        /// <summary>
        /// Expands this instance.
        /// </summary>
        public void Expand()
        {
            ExpandInternal(false);
        }

        /// <summary>
        /// Expands this instance.
        /// </summary>
        /// <param name="blnIsClientSource">True - if the user expanded the row from the row's expantion button, False - if row was expanded from an external invokation (like a Button.Click event)</param>
        private void ExpandInternal(bool blnIsClientSource)
        {
            // Check that this is not the NewRow/FilterRow and that thid grid contains children
            if (!this.IsFilterRow && !this.IsNewRow)
            {
                if (this.ContainedInBindedHierarchicGrid)
                {
                    if (!(this.mobjChildGrid != null))
                    {
                        this.mobjChildGrid = CreateAndBindChildDataGrid();
                    }

                    // Indicate that this row is expanded
                    this.mblnIsExpanded = true;

                    // True - if the user expanded the row from the row's expantion button, 
                    // False - if row was expanded from an external invokation (like a Button.Click event)
                    if (blnIsClientSource)
                    {
                        switch (this.DataGridView.RootGrid.ExpansionIndicator)
                        {
                            case ShowExpansionIndicator.Never:
                                // Cancel the operation
                                this.Collapse();
                                break;
                            case ShowExpansionIndicator.Empty:
                            case ShowExpansionIndicator.CheckOnDisplay:
                            case ShowExpansionIndicator.CheckOnExpand:
                                // If the child grid has no rows, cancel the operation
                                if (!this.mobjChildGrid.HasRows())
                                {
                                    this.Collapse();

                                    this.UpdateParams(AttributeType.Control);
                                }
                                break;
                            case ShowExpansionIndicator.Always:
                                break;
                            default:
                                throw new NotImplementedException("The expanstion indicator of type: " + this.DataGridView.RootGrid.ExpansionIndicator.ToString() + " is not supported");
                        }
                    }
                }
                else if (this.IsHierarchic) // Might not be bounded
                {
                    // Indicate that this row is expanded
                    this.mblnIsExpanded = true;
                }

                // If the client did not handle the operation, an update is required to render the new grid
                if (this.mblnIsExpanded)
                {
                    // Fire the OnRowExpanding event
                    RowExpandingEventArgs objArgs = new RowExpandingEventArgs(this);
                    this.DataGridView.OnRowExpanding(objArgs);

                    // Check wheather the user cancelled the operation
                    if (!objArgs.Cancel)
                    {
                        // Fire the OnRowExpanded event
                        this.DataGridView.OnRowExpanded(new RowExpandedEventArgs(this));
                        this.Update();
                    }
                    else
                    {
                        // If user canceled the expansion, set is expanded to false
                        mblnIsExpanded = false;
                    }
                }
            }
        }

        /// <summary>
        /// Ensures the columns visibility.
        /// </summary>
        internal void EnsureColumnsVisibility(DataGridView objDataGridView, HierarchicInfo objInfo)
        {
            if (objDataGridView != null && objInfo != null)
            {
                DataGridView objRootGrid = objDataGridView.RootGrid;

                List<DataGridViewColumn> objChangedColumns = new List<DataGridViewColumn>();
                // Go through each of the child grid columns
                foreach (DataGridViewColumn objColumn in objDataGridView.Columns)
                {
                    string strDataPropertyName = objColumn.DataPropertyName;

                    // The column's visibility depends on whether the column's name is inside the HiddenColumns dictionary, or whether it should be hidden on grouping.
                    bool blnIsVisible = objInfo.HiddenColumns.IndexOf(strDataPropertyName) == -1;
                    if (blnIsVisible && objRootGrid.HideGroupedColumns)
                    {
                        blnIsVisible = objRootGrid.GroupingColumns.IndexOf(strDataPropertyName) == -1;
                    }

                    if (objColumn.Visible != blnIsVisible)
                    {
                        objColumn.Visible = blnIsVisible;
                        objChangedColumns.Add(objColumn);
                    }
                }

                objDataGridView.OnColumnChooserColumnsVisibilityChanged(objChangedColumns);
            }
        }

        /// <summary>
        /// Collapses this instance.
        /// </summary>
        public void Collapse()
        {
            if (this.mblnIsExpanded)
            {
                RowCollapsingEventArgs objArgs = new RowCollapsingEventArgs(this);

                this.DataGridView.OnRowCollapsing(objArgs);

                if (!objArgs.Cancel)
                {
                    this.mblnIsExpanded = false;

                    this.DataGridView.OnRowCollapsed(this);
                }

                this.Update();
            }
        }

        /// <summary>
        /// Gets the grouping columns without root.
        /// </summary>
        /// <param name="objDataGridViewColumns">The obj data grid view columns.</param>
        /// <returns></returns>
        private UniqueObservableCollection<string> GetGroupingColumnsWithoutRoot(UniqueObservableCollection<string> objDataGridViewColumns)
        {
            UniqueObservableCollection<string> objNewDataGridViewColumns = new UniqueObservableCollection<string>();

            for (int i = 1; i < objDataGridViewColumns.Count; i++)
            {
                objNewDataGridViewColumns.Add(objDataGridViewColumns[i]);
            }

            return objNewDataGridViewColumns;
        }

        /// <summary>
        /// Binds the child data grid.
        /// </summary>
        private HierarchicDataGridView CreateAndBindChildDataGrid()
        {
            // Create the Grid
            HierarchicDataGridView objChildGrid = CreateGridView();

            DataGridView objOwnerDataGridView = this.DataGridView;

            objChildGrid.VisualTemplate = objOwnerDataGridView.VisualTemplate;

            // Set the grid's hierarchyLevel
            objChildGrid.HierarchyLevel = objOwnerDataGridView.HierarchyLevel + 1;

            // Set the containing row
            objChildGrid.ContainingRow = this;

            // Notify the root grid that a child grid node has been created
            objOwnerDataGridView.RootGrid.NotifyHierarchicGridCreated(objChildGrid);

            // Set the Root grid 
            objChildGrid.RootGrid = objOwnerDataGridView.RootGrid;

            // Pass parent GroupingColumns collection.
            objChildGrid.GroupingColumns = this.GetGroupingColumnsWithoutRoot(objOwnerDataGridView.GroupingColumns);

            // Set System hierarchic infos without the root in order to pass it to the next hierarchy level 
            objChildGrid.SystemHierarchicInfos = HierarchicInfo.GetClonedInfos(objOwnerDataGridView.SystemHierarchicInfos, false);

            // The layout has to be suspended here, since the initial access to HierarchicInfos resets the data binding.
            objOwnerDataGridView.SuspendLayout();

            // Get owner HierarchicInfos.
            ObservableCollection<HierarchicInfo> objOwnerGridHierarchies = objOwnerDataGridView.HierarchicInfos;

            objOwnerDataGridView.ResumeLayout();

            // If hierarchy is still at system level.
            if (objOwnerDataGridView.RootGrid.SystemHierarchicInfos.Count > objOwnerDataGridView.HierarchyLevel)
            {
                // Clone the hierarchy infos 
                objChildGrid.HierarchicInfos = HierarchicInfo.GetClonedInfos(objOwnerGridHierarchies, true);
            }
            // If hierarchy level below system hierarchies..            
            else
            {
                // Clone the hierarchy infos without the root in order to pass it to the next hierarchy level
                objChildGrid.HierarchicInfos = HierarchicInfo.GetClonedInfos(objOwnerGridHierarchies, false);
            }

            // Get relevant info collection.
            ObservableCollection<HierarchicInfo> objHierarchicInfos = this.DataGridView.GetRelevantHierarchicInfos();

            // Pass binding context to the row for future binding (When the row is expanded for the first time)
            objChildGrid.BindingContext = objOwnerDataGridView.BindingContext;

            // Get the data source with the relevant filter
            objChildGrid.DataSource = objOwnerDataGridView.GetClonedBindingSourceWithFilterForNextLevel(this);

            if (objHierarchicInfos.Count > 0)
            {
                // Get referance to the related hierarchy info
                this.mobjRelatedHierarchyInfo = objHierarchicInfos[0];

                // Change the columns visibility according to the hierarchy's visibility configuration
                EnsureColumnsVisibility(objChildGrid, this.mobjRelatedHierarchyInfo);

                // If realted hierarchy is not a system hierearchy.
                if (objChildGrid.SystemHierarchicInfos.Count == 0)
                {
                    // Register the hidden columns collection changed event to update the child grid's columns visibility
                    this.mobjRelatedHierarchyInfo.HiddenColumns.CollectionChanged += new NotifyCollectionChangedEventHandler(HiddenColumns_CollectionChanged);
                }
            }

            return objChildGrid;
        }

        /// <summary>
        /// Handles the CollectionChanged event of the HiddenColumns control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        void HiddenColumns_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            EnsureColumnsVisibility(this.mobjChildGrid, this.mobjRelatedHierarchyInfo);
        }

        /// <summary>
        /// Creates the grid view.
        /// </summary>
        /// <returns></returns>
        private HierarchicDataGridView CreateGridView()
        {
            HierarchicDataGridView objNewChildGrid = null;

            // Get parent Grid reference.
            DataGridView objOwnerDataGridView = this.DataGridView;
            if (objOwnerDataGridView != null)
            {
                // Create instance of child grid.
                Type objChildGridType = objOwnerDataGridView.GetChildGridType(this);
                if (objChildGridType != null)
                {
                    objNewChildGrid = Activator.CreateInstance(objChildGridType) as HierarchicDataGridView;
                }

                if (objNewChildGrid != null)
                {
                    // Properties that are auto generated from the designer
                    objNewChildGrid.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.FixedSingle;
                    objNewChildGrid.ColumnHeadersHeightSizeMode = Gizmox.WebGUI.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    objNewChildGrid.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;

                    // Inherit from parent.
                    objNewChildGrid.CustomStyle = objOwnerDataGridView.CustomStyle;
                    objNewChildGrid.UseInternalPaging = objOwnerDataGridView.UseInternalPaging;
                    objNewChildGrid.SupportGroupCount = objOwnerDataGridView.SupportGroupCount;
                    objNewChildGrid.ExpansionIndicator = objOwnerDataGridView.ExpansionIndicator;
                }
            }

            return objNewChildGrid;
        }

        /// <summary>
        /// Sets the read only cell core.
        /// </summary>
        /// <param name="objDataGridViewCell">The data grid view cell.</param>
        /// <param name="blnReadOnly">if set to <c>true</c> [read only].</param>
        internal void SetReadOnlyCellCore(DataGridViewCell objDataGridViewCell, bool blnReadOnly)
        {
            if (this.ReadOnly && !blnReadOnly)
            {
                foreach (DataGridViewCell objCell in this.Cells)
                {
                    objCell.ReadOnlyInternal = true;
                }
                objDataGridViewCell.ReadOnlyInternal = false;
                this.ReadOnly = false;
            }
            else if (!this.ReadOnly && blnReadOnly)
            {
                objDataGridViewCell.ReadOnlyInternal = true;
            }
        }

        /// <summary>Sets the values of the row's cells.</summary>
        /// <returns>true if all values have been set; otherwise, false.</returns>
        /// <param name="arrValues">One or more objects that represent the cell values in the row.-or-An <see cref="T:System.Array"></see> of <see cref="T:System.Object"></see> values. </param>
        /// <exception cref="T:System.ArgumentNullException">values is null. </exception>
        /// <exception cref="T:System.InvalidOperationException">This method is called when the associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> is operating in virtual mode. -or-This row is a shared row.</exception>
        /// <filterpriority>1</filterpriority>
        public bool SetValues(params object[] arrValues)
        {
            if (arrValues == null)
            {
                throw new ArgumentNullException("values");
            }

            // Get Base DataGridView
            DataGridView objDataGridView = base.DataGridView;

            if (objDataGridView != null)
            {
                if (objDataGridView.VirtualMode)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationInVirtualMode"));
                }
                if (base.Index == -1)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedRow"));
                }
            }
            return this.SetValuesInternal(arrValues);
        }

        /// <summary>
        /// Sets the values internal.
        /// </summary>
        /// <param name="arrValues">The values.</param>
        /// <returns></returns>
        internal bool SetValuesInternal(params object[] arrValues)
        {
            bool blnFlag = true;
            DataGridViewCellCollection objCells = this.Cells;
            int intCount = objCells.Count;
            for (int i = 0; i < objCells.Count; i++)
            {
                if (i == arrValues.Length)
                {
                    break;
                }
                if (!objCells[i].SetValueInternal(base.Index, arrValues[i]))
                {
                    blnFlag = false;
                }
            }
            if (blnFlag)
            {
                return (arrValues.Length <= intCount);
            }
            return false;

        }

        /// <summary>Gets a human-readable string that describes the row.</summary>
        /// <returns>A <see cref="T:System.String"></see> that describes this row.</returns>
        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(0x24);
            builder.Append("DataGridViewRow { Index=");
            builder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
            builder.Append(" }");
            return builder.ToString();
        }

        /// <summary>
        /// Full updates of this instance.
        /// </summary>
        public override void Update()
        {
            base.Update();

            if (this.DataGridView != null)
            {
                this.DataGridView.Update(true);
            }
        }

        /// <summary>
        /// Updates only the parameters of this instance.
        /// </summary>
        protected override void UpdateParams()
        {
            base.UpdateParams();

            if (this.DataGridView != null)
            {
                this.DataGridView.Update(true);
            }
        }

        /// <summary>
        /// Updates the params.
        /// </summary>
        /// <param name="enmParams">The enm params.</param>
        protected internal override void UpdateParams(AttributeType enmParams)
        {
            base.UpdateParams(enmParams);

            if (this.DataGridView != null)
            {
                this.DataGridView.Update(true);
            }
        }

        /// <summary>
        /// Redraw only
        /// </summary>
        /// <param name="blnRedrawOnly">if set to <c>true</c> [BLN redraw only].</param>
        public override void Update(bool blnRedrawOnly)
        {
            base.Update(blnRedrawOnly);

            if (this.DataGridView != null)
            {
                this.DataGridView.Update(true);
            }
        }

        /// <summary>
        /// Redraw only
        /// </summary>
        /// <param name="enmParams">The enm params.</param>
        internal override void Update(AttributeType enmParams)
        {
            base.Update(enmParams);

            if (this.DataGridView != null)
            {
                this.DataGridView.Update(true);
            }
        }

        /// <summary>Modifies an input row header border style according to the specified criteria.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the new border style used.</returns>
        /// <param name="objDataGridViewAdvancedBorderStylePlaceholder">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that is used to store intermediate changes to the row header border style.</param>
        /// <param name="objDataGridViewAdvancedBorderStyleInput">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> that represents the row header border style to modify. </param>
        /// <param name="blnSingleVerticalBorderAdded">true to add a single vertical border to the result; otherwise, false. </param>
        /// <param name="blnIsLastVisibleRow">true if the row is the last row in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that has its <see cref="P:Gizmox.WebGUI.Forms.DataGridViewRow.Visible"></see> property set to true; otherwise, false. </param>
        /// <param name="blnSingleHorizontalBorderAdded">true to add a single horizontal border to the result; otherwise, false. </param>
        /// <param name="blnIsFirstDisplayedRow">true if the row is the first row displayed in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>; otherwise, false. </param>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual DataGridViewAdvancedBorderStyle AdjustRowHeaderBorderStyle(DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStyleInput, DataGridViewAdvancedBorderStyle objDataGridViewAdvancedBorderStylePlaceholder, bool blnSingleVerticalBorderAdded, bool blnSingleHorizontalBorderAdded, bool blnIsFirstDisplayedRow, bool blnIsLastVisibleRow)
        {
            return null;
        }

        /// <summary>
        /// Builds the inherited row header cell style.
        /// </summary>
        /// <param name="objInheritedCellStyle">The inherited cell style.</param>
        private void BuildInheritedRowHeaderCellStyle(DataGridViewCellStyle objInheritedCellStyle)
        {
        }

        /// <summary>
        /// Builds the inherited row style.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <param name="objInheritedRowStyle">The inherited row style.</param>
        private void BuildInheritedRowStyle(int intRowIndex, DataGridViewCellStyle ObjInheritedRowStyle)
        {
        }

        /// <summary>Creates an exact copy of this row.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override object Clone()
        {
            DataGridViewRow objDataGridViewRow1;
            Type objType1 = base.GetType();
            if (objType1 == DataGridViewRow.objRowType)
            {
                objDataGridViewRow1 = new DataGridViewRow();
            }
            else
            {
                objDataGridViewRow1 = (DataGridViewRow)Activator.CreateInstance(objType1);
            }
            if (objDataGridViewRow1 != null)
            {
                base.CloneInternal(objDataGridViewRow1);
                if (this.HasErrorText)
                {
                    objDataGridViewRow1.ErrorText = this.ErrorTextInternal;
                }
                if (base.HasHeaderCell)
                {
                    objDataGridViewRow1.HeaderCell = (DataGridViewRowHeaderCell)this.HeaderCell.Clone();
                }

                objDataGridViewRow1.CloneCells(this);
            }
            return objDataGridViewRow1;

        }

        /// <summary>
        /// Clones the cells.
        /// </summary>
        /// <param name="objRowTemplate">The row template.</param>
        private void CloneCells(DataGridViewRow objRowTemplate)
        {
            int num1 = objRowTemplate.Cells.Count;
            if (num1 > 0)
            {
                DataGridViewCell[] arrCells = new DataGridViewCell[num1];
                for (int num2 = 0; num2 < num1; num2++)
                {
                    DataGridViewCell objCell1 = objRowTemplate.Cells[num2];
                    DataGridViewCell objCell2 = (DataGridViewCell)objCell1.Clone();
                    arrCells[num2] = objCell2;
                }
                this.Cells.AddRange(arrCells);
            }
        }

        /// <summary>Clears the existing cells and sets their template according to the supplied <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> template.</summary>
        /// <param name="objDataGridView">A <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that acts as a template for cell styles. </param>
        /// <exception cref="T:System.InvalidOperationException">A row that already belongs to the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> was added. -or-A column that has no cell template was added.</exception>
        /// <exception cref="T:System.ArgumentNullException">dataGridView is null. </exception>
        /// <filterpriority>1</filterpriority>
        public void CreateCells(DataGridView objDataGridView)
        {
        }

        /// <summary>Clears the existing cells and sets their template and values.</summary>
        /// <param name="objDataGridView">A <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that acts as a template for cell styles. </param>
        /// <param name="arrValues">An array of objects that initialize the reset cells. </param>
        /// <exception cref="T:System.ArgumentNullException">Either of the parameters is null. </exception>
        /// <exception cref="T:System.InvalidOperationException">A row that already belongs to the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> was added. -or-A column that has no cell template was added.</exception>
        /// <filterpriority>1</filterpriority>
        public void CreateCells(DataGridView objDataGridView, params object[] arrValues)
        {
        }

        /// <summary>Constructs a new collection of cells based on this row.</summary>
        /// <returns>The newly created <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see>.</returns>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual DataGridViewCellCollection CreateCellsInstance()
        {
            return new DataGridViewCellCollection(this);

        }

        /// <summary>
        /// Detaches from data grid view.
        /// </summary>
        internal void DetachFromDataGridView()
        {
            if (base.DataGridView != null)
            {
                base.DataGridViewInternal = null;
                base.IndexInternal = -1;
                if (base.HasHeaderCell)
                {
                    this.HeaderCell.DataGridViewInternal = null;
                }
                foreach (DataGridViewCell objCell in this.Cells)
                {
                    objCell.DataGridViewInternal = null;
                    if (objCell.Selected)
                    {
                        objCell.SelectedInternal = false;
                    }
                }
                if (this.Selected)
                {
                    base.SelectedInternal = false;
                }
            }
        }

        /// <summary>Draws a focus rectangle around the specified bounds.</summary>
        /// <param name="objCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> used to paint the focus rectangle.</param>
        /// <param name="enmRowState">A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values that specifies the state of the row.</param>
        /// <param name="objBounds">A <see cref="T:System.Drawing.Rectangle"></see> that contains the bounds of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see> that is being painted.</param>
        /// <param name="objGraphics">The <see cref="T:System.Drawing.Graphics"></see> used to paint the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRow"></see>.</param>
        /// <param name="intRowIndex">The row index of the cell that is being painted.</param>
        /// <param name="objClipBounds">A <see cref="T:System.Drawing.Rectangle"></see> that represents the area of the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> that needs to be painted.</param>
        /// <param name="blnCellsPaintSelectionBackground">true to use the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.SelectionBackColor"></see> property of cellStyle as the color of the focus rectangle; false to use the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.BackColor"></see> property of cellStyle as the color of the focus rectangle.</param>
        /// <exception cref="T:System.InvalidOperationException">The row has not been added to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
        /// <exception cref="T:System.ArgumentNullException">graphics is null.-or-cellStyle is null.</exception>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected internal virtual void DrawFocus(Graphics objGraphics, Rectangle objClipBounds, Rectangle objBounds, int intRowIndex, DataGridViewElementStates enmRowState, DataGridViewCellStyle objCellStyle, bool blnCellsPaintSelectionBackground)
        {
        }

        /// <summary>
        /// Gets the displayed.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        internal bool GetDisplayed(int intRowIndex)
        {
            return ((this.GetState(intRowIndex) & DataGridViewElementStates.Displayed) != DataGridViewElementStates.None);
        }

        /// <summary>Gets the error text for the row at the specified index.</summary>
        /// <returns>A string that describes the error of the row at the specified index.</returns>
        /// <param name="intRowIndex">The index of the row that contains the error.</param>
        /// <exception cref="T:System.InvalidOperationException">The row belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The row belongs to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and rowIndex is less than zero or greater than the number of rows in the control minus one. </exception>
        public string GetErrorText(int intRowIndex)
        {
            string strErrorText = this.ErrorTextInternal;

            // Get Base DataGridView
            DataGridView objDataGridView = base.DataGridView;

            if (objDataGridView == null)
            {
                return strErrorText;
            }
            if (intRowIndex == -1)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedRow"));
            }
            if ((intRowIndex < 0) || (intRowIndex >= objDataGridView.Rows.Count))
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            if ((CommonUtils.IsNullOrEmpty(strErrorText) && (objDataGridView.DataSource != null)) && (intRowIndex != objDataGridView.NewRowIndex))
            {
                strErrorText = objDataGridView.DataConnection.GetError(intRowIndex);
            }
            if ((objDataGridView.DataSource == null) && !objDataGridView.VirtualMode)
            {
                return strErrorText;
            }
            return objDataGridView.OnRowErrorTextNeeded(intRowIndex, strErrorText);
        }

        /// <summary>
        /// Gets the frozen.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        internal bool GetFrozen(int intRowIndex)
        {
            return ((this.GetState(intRowIndex) & DataGridViewElementStates.Frozen) != DataGridViewElementStates.None);
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

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        internal int GetHeight(int intRowIndex)
        {
            int num;
            int num2;
            base.GetHeightInfo(intRowIndex, out num, out num2);
            return num;
        }

        /// <summary>
        /// Gets the minimum height.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        internal int GetMinimumHeight(int intRowIndex)
        {
            int num;
            int num2;
            base.GetHeightInfo(intRowIndex, out num, out num2);
            return num2;
        }

        /// <summary>Calculates the ideal height of the specified row based on the specified criteria.</summary>
        /// <returns>The ideal height of the row, in pixels.</returns>
        /// <param name="enmAutoSizeRowMode">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> that specifies an automatic sizing mode.</param>
        /// <param name="intRowIndex">The index of the row whose preferred height is calculated.</param>
        /// <param name="blnFixedWidth">true to calculate the preferred height for a fixed cell width; otherwise, false.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The rowIndex is not in the valid range of 0 to the number of rows in the control minus 1. </exception>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeRowMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeRowMode"></see> value. </exception>
        public virtual int GetPreferredHeight(int intRowIndex, DataGridViewAutoSizeRowMode enmAutoSizeRowMode, bool blnFixedWidth)
        {
            // Get Base DataGridView
            DataGridView objDataGridView = base.DataGridView;

            if ((enmAutoSizeRowMode & ~DataGridViewAutoSizeRowMode.AllCells) != ((DataGridViewAutoSizeRowMode)0))
            {
                throw new InvalidEnumArgumentException("autoSizeRowMode", (int)enmAutoSizeRowMode, typeof(DataGridViewAutoSizeRowMode));
            }
            if ((objDataGridView != null) && ((intRowIndex < 0) || (intRowIndex >= objDataGridView.Rows.Count)))
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            if (objDataGridView == null)
            {
                return -1;
            }
            int num = 0;
            if (objDataGridView.RowHeadersVisible && ((enmAutoSizeRowMode & DataGridViewAutoSizeRowMode.RowHeader) != ((DataGridViewAutoSizeRowMode)0)))
            {
                if ((blnFixedWidth || (objDataGridView.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.EnableResizing)) || (objDataGridView.RowHeadersWidthSizeMode == DataGridViewRowHeadersWidthSizeMode.DisableResizing))
                {
                    num = Math.Max(num, this.HeaderCell.GetPreferredHeight(intRowIndex, objDataGridView.RowHeadersWidth));
                }
                else
                {
                    num = Math.Max(num, this.HeaderCell.GetPreferredSize(intRowIndex).Height);
                }
            }
            if ((enmAutoSizeRowMode & DataGridViewAutoSizeRowMode.AllCellsExceptHeader) != ((DataGridViewAutoSizeRowMode)0))
            {
                foreach (DataGridViewCell objCell in this.Cells)
                {
                    DataGridViewColumn objColumn = objDataGridView.Columns[objCell.ColumnIndex];
                    if (objColumn.Visible)
                    {
                        int intPreferredHeight;
                        if (blnFixedWidth || ((objColumn.InheritedAutoSizeMode & (DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader | DataGridViewAutoSizeColumnMode.AllCellsExceptHeader)) == DataGridViewAutoSizeColumnMode.NotSet))
                        {
                            intPreferredHeight = objCell.GetPreferredHeight(intRowIndex, objColumn.Width);
                        }
                        else
                        {
                            intPreferredHeight = objCell.GetPreferredSize(intRowIndex).Height;
                        }
                        if (num < intPreferredHeight)
                        {
                            num = intPreferredHeight;
                        }
                    }
                }
            }
            return num;
        }

        /// <summary>
        /// Gets the read only.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        internal bool GetReadOnly(int intRowIndex)
        {
            if ((this.GetState(intRowIndex) & DataGridViewElementStates.ReadOnly) != DataGridViewElementStates.None)
            {
                return true;
            }

            // Get Base DataGridView
            DataGridView objDataGridView = base.DataGridView;

            if (objDataGridView != null)
            {
                return objDataGridView.ReadOnly;
            }
            return false;

        }

        /// <summary>
        /// Gets the resizable.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        internal DataGridViewTriState GetResizable(int intRowIndex)
        {
            if ((this.GetState(intRowIndex) & DataGridViewElementStates.ResizableSet) != DataGridViewElementStates.None)
            {
                if ((this.GetState(intRowIndex) & DataGridViewElementStates.Resizable) == DataGridViewElementStates.None)
                {
                    return DataGridViewTriState.False;
                }
                return DataGridViewTriState.True;
            }

            // Get Base DataGridView
            DataGridView objDataGridView = base.DataGridView;

            if (objDataGridView == null)
            {
                return DataGridViewTriState.NotSet;
            }
            if (!objDataGridView.AllowUserToResizeRows)
            {
                return DataGridViewTriState.False;
            }
            return DataGridViewTriState.True;
        }

        /// <summary>
        /// Gets the selected.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        internal bool GetSelected(int intRowIndex)
        {
            return ((this.GetState(intRowIndex) & DataGridViewElementStates.Selected) != DataGridViewElementStates.None);
        }

        /// <summary>Returns a value indicating the current state of the row.</summary>
        /// <returns>A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the row state.</returns>
        /// <param name="intRowIndex">The index of the row.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The row has been added to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control, but the rowIndex value is not in the valid range of 0 to the number of rows in the control minus 1.</exception>
        /// <exception cref="T:System.ArgumentException">The row is not a shared row, but the rowIndex value does not match the row's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.Index"></see> property value.-or-The row has not been added to a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control, but the rowIndex value does not match the row's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewBand.Index"></see> property value.</exception>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual DataGridViewElementStates GetState(int intRowIndex)
        {
            // Get Base DataGridView
            DataGridView objDataGridView = base.DataGridView;

            if (objDataGridView != null)
            {
                DataGridViewRowCollection objDataGridViewRowCollection = null;
                objDataGridViewRowCollection = objDataGridView.Rows;

                if ((intRowIndex < 0) || (intRowIndex >= objDataGridViewRowCollection.Count))
                {
                    throw new ArgumentOutOfRangeException("rowIndex");
                }
                if (objDataGridViewRowCollection.SharedRow(intRowIndex).Index == -1)
                {
                    return objDataGridViewRowCollection.GetRowState(intRowIndex);
                }
            }
            if (intRowIndex != base.Index)
            {
                throw new ArgumentException(SR.GetString("InvalidArgument", new object[] { "rowIndex", intRowIndex.ToString(CultureInfo.CurrentCulture) }));
            }
            return base.State;
        }

        /// <summary>
        /// Gets the visible.
        /// </summary>
        /// <param name="intRowIndex">Index of the row.</param>
        /// <returns></returns>
        internal bool GetVisible(int intRowIndex)
        {
            return ((this.GetState(intRowIndex) & DataGridViewElementStates.Visible) != DataGridViewElementStates.None);
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DataGridViewRow"/> is expanded.
        /// </summary>
        /// <value>
        ///   <c>true</c> if expanded; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        public bool Expanded
        {
            get
            {
                return this.mblnIsExpanded;
            }
            set
            {
                if (value)
                {
                    this.Expand();
                }
                else
                {
                    this.Collapse();
                }
            }
        }

        /// <summary>
        /// Gets the child grid.
        /// </summary>
        /// <value>
        /// The child grid.
        /// </value>
        public HierarchicDataGridView ChildGrid
        {
            get
            {
                if (this.mobjChildGrid == null && this.ContainedInBindedHierarchicGrid && !this.IsNewRow)
                {
                    this.mobjChildGrid = CreateAndBindChildDataGrid();
                }

                return this.mobjChildGrid;
            }
        }

        /// <summary>
        /// Gets the related hierarchy info.
        /// </summary>
        internal HierarchicInfo RelatedHierarchyInfo
        {
            get { return mobjRelatedHierarchyInfo; }
        }

        /// <summary>
        /// Gets the member ID.
        /// </summary>
        /// <value>The member ID.</value>
        protected override string MemberID
        {
            get
            {
                return "R" + (this.IsFilterRow ? 0 : this.Index + (this.DataGridView.ShowFilterRow ? 1 : 0)).ToString();
            }
        }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>
        /// The style.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public DataGridViewRowStyle Style
        {
            get
            {
                return mobjStyle;
            }
        }

        /// <summary>
        /// This is a recursive function that loop through a control and all of its parents
        /// cheching if one of the controls(and control containers) is hidden or
        /// disabled.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is events enabled; otherwise, <c>false</c>.
        /// </value>        
        /// <returns>false if one of the controls is hidden or disabled.</returns>
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

        /// <summary>Gets the collection of cells that populate the row.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellCollection"></see> that contains all of the cells in the row.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DataGridViewCellCollection Cells
        {
            get
            {
                if (mobjCells == null)
                {
                    mobjCells = this.CreateCellsInstance();
                }
                return mobjCells;
            }
        }

        /// <summary>Gets the data-bound object that populated the row.</summary>
        /// <returns>The data-bound <see cref="T:System.Object"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public object DataBoundItem
        {
            get
            {
                // Get Base DataGridView
                DataGridView objDataGridView = base.DataGridView;

                if (((objDataGridView != null) && (objDataGridView.DataConnection != null)) && ((base.Index > -1) && (base.Index != objDataGridView.NewRowIndex)))
                {
                    return objDataGridView.DataConnection.CurrencyManager[base.Index];
                }
                return null;
            }
        }

        /// <summary>Gets or sets the default styles for the row, which are used to render cells in the row unless the styles are overridden. </summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be applied as the default style.</returns>
        /// <exception cref="T:System.InvalidOperationException">When setting this property, the row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        /// <filterpriority>1</filterpriority>
        [Browsable(true), SRDescription("DataGridView_RowDefaultCellStyleDescr"), NotifyParentProperty(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Content), SRCategory("CatAppearance")]
        public override DataGridViewCellStyle DefaultCellStyle
        {
            get
            {
                return base.DefaultCellStyle;
            }
            set
            {
                if ((base.DataGridView != null) && (base.Index == -1))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", new object[] { "DefaultCellStyle" }));
                }
                base.DefaultCellStyle = value;
            }
        }

        /// <summary>Gets a value indicating whether this row is displayed on the screen.</summary>
        /// <returns>true if the row is currently displayed on the screen; otherwise, false.</returns>
        /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        [Browsable(false)]
        public override bool Displayed
        {
            get
            {
                if ((base.DataGridView != null) && (base.Index == -1))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", new object[] { "Displayed" }));
                }
                return this.GetDisplayed(base.Index);
            }
        }

        /// <summary>Gets or sets the height, in pixels, of the row divider.</summary>
        /// <returns>The height, in pixels, of the divider (the row's bottom margin). </returns>
        /// <exception cref="T:System.InvalidOperationException">When setting this property, the row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        [NotifyParentProperty(true), SRCategory("CatAppearance"), SRDescription("DataGridView_RowDividerHeightDescr"), DefaultValue(0)]
        public int DividerHeight
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        /// <summary>Gets or sets the error message text for row-level errors.</summary>
        /// <returns>A <see cref="T:System.String"></see> containing the error message.</returns>
        /// <exception cref="T:System.InvalidOperationException">When getting the value of this property, the row is a shared row in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</exception>
        /// <filterpriority>1</filterpriority>
        [NotifyParentProperty(true), SRCategory("CatAppearance"), DefaultValue(""), SRDescription("DataGridView_RowErrorTextDescr")]
        public string ErrorText
        {
            get
            {
                return this.GetErrorText(base.Index);
            }
            set
            {
                this.ErrorTextInternal = value;
            }
        }

        /// <summary>
        /// Gets or sets the error text internal.
        /// </summary>
        /// <value>The error text internal.</value>
        private string ErrorTextInternal
        {
            get
            {
                if (mstrErrorText != null)
                {
                    return mstrErrorText;
                }
                return string.Empty;
            }
            set
            {
                string strErrorTextInternal = this.ErrorTextInternal;
                string strErrorText = mstrErrorText;

                // Get Base DataGridView
                DataGridView objDataGridView = base.DataGridView;

                if (!CommonUtils.IsNullOrEmpty(value) || strErrorText != null)
                {
                    if (strErrorText != value)
                    {
                        mstrErrorText = value;
                        if (objDataGridView != null)
                        {
                            // Essentially for returning focus to grid, after response properly will be rendered                            
                            objDataGridView.FocusInternal();
                            objDataGridView.Update();
                        }
                    }
                }

                if ((objDataGridView != null) && !strErrorTextInternal.Equals(this.ErrorTextInternal))
                {
                    objDataGridView.OnRowErrorTextChanged(this);
                }
            }

        }

        /// <summary>Gets or sets a value indicating whether the row is frozen. </summary>
        /// <returns>true if the row is frozen; otherwise, false.</returns>
        /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public override bool Frozen
        {
            get
            {
                if ((base.DataGridView != null) && (base.Index == -1))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", new object[] { "Frozen" }));
                }
                return this.GetFrozen(base.Index);
            }
            set
            {
                if ((base.DataGridView != null) && (base.Index == -1))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", new object[] { "Frozen" }));
                }
                base.Frozen = value;
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

                if (this.DataGridView != null)
                {
                    // Add grid's padding and margin to location.
                    objLocation.X += (this.DataGridView.Padding.Left + this.DataGridView.Margin.Left);
                    objLocation.Y += (this.DataGridView.Padding.Top + this.DataGridView.Margin.Top);

                    // Add grid's colum header height.
                    if (this.DataGridView.ColumnHeadersVisible)
                    {
                        objLocation.Y += (this.DataGridView.ColumnHeadersHeight);
                    }

                    // Add grid's row header width.
                    if (this.DataGridView.RowHeadersVisible)
                    {
                        objLocation.X += (this.DataGridView.RowHeadersWidth);
                    }

                    IList objPageRows = this.DataGridView.PageRows;
                    if (objPageRows.Count > 0)
                    {
                        // Loop all rows in page.
                        foreach (DataGridViewRow objDataGridViewRow in objPageRows)
                        {
                            // check if current row is this row.
                            if (objDataGridViewRow == this)
                            {
                                break;
                            }
                            // Check if row is visible.
                            else if (objDataGridViewRow.Visible)
                            {
                                // Add current row's height to location.
                                objLocation.Y += objDataGridViewRow.Height;
                            }
                        }
                    }

                    // Decrease grid's scrolling position.
                    objLocation.Y -= this.DataGridView.ScrollPoisition.Y;
                }

                return objLocation;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance has error text.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has error text; otherwise, <c>false</c>.
        /// </value>
        internal bool HasErrorText
        {
            get
            {
                string strErrorText = mstrErrorText;

                if (strErrorText != null && strErrorText != string.Empty)
                {
                    return true;
                }
                return false;

            }
        }

        /// <summary>Gets or sets the row's header cell.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewRowHeaderCell"></see> that represents the header cell of row.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewRowHeaderCell HeaderCell
        {
            get
            {
                return (DataGridViewRowHeaderCell)base.HeaderCellCore;
            }
            set
            {
                base.HeaderCellCore = value;
            }
        }

        /// <summary>Gets or sets the current height of the row.</summary>
        /// <returns>The height, in pixels, of the row. The default is the height of the default font plus 9 pixels.</returns>
        /// <exception cref="T:System.InvalidOperationException">When setting this property, the row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatAppearance"), NotifyParentProperty(true), SRDescription("DataGridView_RowHeightDescr"), DefaultValue(0x16)]
        public int Height
        {
            get
            {
                return base.Thickness;
            }
            set
            {
                if ((base.DataGridView != null) && (base.Index == -1))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", new object[] { "Height" }));
                }
                base.Thickness = value;
            }
        }

        /// <summary>Gets the cell style in effect for the row.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that specifies the formatting and style information for the cells in the row.</returns>
        /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        public override DataGridViewCellStyle InheritedStyle
        {
            get
            {
                if (base.Index == -1)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", new object[] { "InheritedStyle" }));
                }
                DataGridViewCellStyle objInheritedRowStyle = new DataGridViewCellStyle();
                this.BuildInheritedRowStyle(base.Index, objInheritedRowStyle);
                return objInheritedRowStyle;

            }
        }

        /// <summary>Gets a value indicating whether the row is the row for new records.</summary>
        /// <returns>true if the row is the last row in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>, 
        /// which is used for the entry of a new row of data; otherwise, false.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsNewRow
        {
            get
            {
                // Get Base DataGridView
                DataGridView objDataGridView = base.DataGridView;

                if (objDataGridView != null)
                {
                    return (objDataGridView.NewRowIndex == base.Index);
                }
                return false;
            }
        }


        /// <summary>
        /// Gets a value indicating whether this instance is filter row.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is filter row; otherwise, <c>false</c>.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsFilterRow
        {
            get
            {
                return false;
            }
        }

        /// <summary>Gets or sets the minimum height of the row.</summary>
        /// <returns>The minimum row height in pixels, ranging from 2 to <see cref="F:System.Int32.MaxValue"></see>. The default is 3.</returns>
        /// <exception cref="T:System.InvalidOperationException">When setting this property, the row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than 2.</exception>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public int MinimumHeight
        {
            get
            {
                return base.MinimumThickness;
            }
            set
            {
                if ((base.DataGridView != null) && (base.Index == -1))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", new object[] { "MinimumHeight" }));
                }
                base.MinimumThickness = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether the row is read-only.</summary>
        /// <returns>true if the row is read-only; otherwise, false.</returns>
        /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        /// <filterpriority>1</filterpriority>
        [NotifyParentProperty(true), SRDescription("DataGridView_RowReadOnlyDescr"), DefaultValue(false), Browsable(true), SRCategory("CatBehavior")]
        public override bool ReadOnly
        {
            get
            {
                if ((base.DataGridView != null) && (base.Index == -1))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", new object[] { "ReadOnly" }));
                }
                return this.GetReadOnly(base.Index);
            }
            set
            {
                if (value != this.ReadOnly)
                {
                    if (this.DataGridView != null)
                    {
                        this.DataGridView.Update();
                    }
                }

                base.ReadOnly = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether users can resize the row or indicating that the behavior is inherited from the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeRows"></see> property.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> value that indicates whether the row can be resized or whether it can be resized only when the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AllowUserToResizeRows"></see> property is set to true.</returns>
        /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        [SRDescription("DataGridView_RowResizableDescr"), SRCategory("CatBehavior"), NotifyParentProperty(true), DefaultValue(DataGridViewTriState.NotSet)]
        public override DataGridViewTriState Resizable
        {
            get
            {
                if ((base.DataGridView != null) && (base.Index == -1))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", new object[] { "Resizable" }));
                }
                return this.GetResizable(base.Index);
            }
            set
            {
                base.Resizable = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether the row is selected. </summary>
        /// <returns>true if the row is selected; otherwise, false.</returns>
        /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        public override bool Selected
        {
            get
            {
                if ((base.DataGridView != null) && (base.Index == -1))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", new object[] { "Selected" }));
                }
                return this.GetSelected(base.Index);
            }
            set
            {
                base.Selected = value;
            }
        }

        /// <summary>Gets the current state of the row.</summary>
        /// <returns>A bitwise combination of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewElementStates"></see> values indicating the row state.</returns>
        /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        public override DataGridViewElementStates State
        {
            get
            {
                if ((base.DataGridView != null) && (base.Index == -1))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", new object[] { "State" }));
                }
                return this.GetState(base.Index);
            }
        }

        /// <summary>Gets or sets a value indicating whether the row is visible. </summary>
        /// <returns>true if the row is visible; otherwise, false.</returns>
        /// <exception cref="T:System.InvalidOperationException">The row is in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control and is a shared row.</exception>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public override bool Visible
        {
            get
            {
                if ((base.DataGridView != null) && (base.Index == -1))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertyGetOnSharedRow", new object[] { "Visible" }));
                }
                return this.GetVisible(base.Index);
            }
            set
            {
                if ((base.DataGridView != null) && (base.Index == -1))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_InvalidPropertySetOnSharedRow", new object[] { "Visible" }));
                }
                base.Visible = value;
            }
        }

        /// <summary>Gets or sets the shortcut menu for the row.</summary>
        /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with the current <see cref="T:System.Windows.Forms.DataGridViewRow"></see>. The default is null.</returns>
        /// <exception cref="T:System.InvalidOperationException">When getting the value of this property, the row is in a <see cref="T:System.Windows.Forms.DataGridView"></see> control and is a shared row.</exception>
        [SRDescription("DataGridView_RowContextMenuStripDescr"), DefaultValue((string)null), SRCategory("CatBehavior")]
        public override ContextMenu ContextMenu
        {
            get
            {
                return base.ContextMenu;
            }
            set
            {
                base.ContextMenu = value;
            }
        }

        /// <summary>Gets the shortcut menu for the row.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> that belongs to the <see cref="T:System.Windows.Forms.DataGridViewRow"></see> at the specified index.</returns>
        /// <param name="intRowIndex">The index of the current row.</param>
        /// <exception cref="T:System.InvalidOperationException">rowIndex is -1.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">rowIndex is less than zero or greater than or equal to the number of rows in the control minus one.</exception>
        public ContextMenu GetContextMenu(int intRowIndex)
        {
            ContextMenu objContextMenuInternal = base.ContextMenuInternal;

            // Get Base DataGridView
            DataGridView objDataGridView = base.DataGridView;

            if (objDataGridView == null)
            {
                return objContextMenuInternal;
            }
            if (intRowIndex == -1)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedRow"));
            }
            if ((intRowIndex < 0) || (intRowIndex >= objDataGridView.Rows.Count))
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            if (!objDataGridView.VirtualMode && (objDataGridView.DataSource == null))
            {
                return objContextMenuInternal;
            }
            return objDataGridView.OnRowContextMenuNeeded(intRowIndex, objContextMenuInternal);
        }

        /// <summary>
        /// Gets the context menu strip.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        /// <returns></returns>
        public ContextMenuStrip GetContextMenuStrip(int rowIndex)
        {
            ContextMenuStrip contextMenuStripInternal = base.ContextMenuStripInternal;
            if (base.DataGridView == null)
            {
                return contextMenuStripInternal;
            }
            if (rowIndex == -1)
            {
                throw new InvalidOperationException(SR.GetString("DataGridView_InvalidOperationOnSharedRow"));
            }
            if ((rowIndex < 0) || (rowIndex >= base.DataGridView.Rows.Count))
            {
                throw new ArgumentOutOfRangeException("rowIndex");
            }
            if (!base.DataGridView.VirtualMode && (base.DataGridView.DataSource == null))
            {
                return contextMenuStripInternal;
            }
            return base.DataGridView.OnRowContextMenuStripNeeded(rowIndex, contextMenuStripInternal);
        }

        #endregion Properties

        /// <summary>
        /// Gets a value indicating whether [contained in hierarchic grid].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [contained in hierarchic grid]; otherwise, <c>false</c>.
        /// </value>
        public bool ContainedInBindedHierarchicGrid
        {
            get
            {
                return this.DataGridView != null && this.DataGridView.IsHierarchic(HierarchicInfoSelector.Bounded);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is hierarchic.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is hierarchic; otherwise, <c>false</c>.
        /// </value>
        public bool IsHierarchic
        {
            get
            {
                return this.DataGridView != null && this.DataGridView.IsHierarchic(HierarchicInfoSelector.Any);
            }
        }
    }

    #endregion

    #region Linkd Lists

    #region DataGridViewCellLinkedList Class

    [Serializable()]
    internal class DataGridViewCellLinkedList : IEnumerable
    {
        #region Members

        private int mintCount;
        private DataGridViewCellLinkedListElement headElement;
        private DataGridViewCellLinkedListElement lastAccessedElement;
        private int mintLastAccessedIndex;

        #endregion Members

        #region Methods

        public DataGridViewCellLinkedList()
        {
            this.mintLastAccessedIndex = -1;
        }

        public void Add(DataGridViewCell objDataGridViewCell)
        {
            DataGridViewCellLinkedListElement objElement = new DataGridViewCellLinkedListElement(objDataGridViewCell);
            if (this.headElement != null)
            {
                objElement.Next = this.headElement;
            }
            this.headElement = objElement;
            this.mintCount++;
            this.lastAccessedElement = null;
            this.mintLastAccessedIndex = -1;
        }

        public void Clear()
        {
            this.lastAccessedElement = null;
            this.mintLastAccessedIndex = -1;
            this.headElement = null;
            this.mintCount = 0;
        }

        public bool Contains(DataGridViewCell objDataGridViewCell)
        {
            int num1 = 0;
            DataGridViewCellLinkedListElement objElement = this.headElement;
            while (objElement != null)
            {
                if (objElement.DataGridViewCell == objDataGridViewCell)
                {
                    this.lastAccessedElement = objElement;
                    this.mintLastAccessedIndex = num1;
                    return true;
                }
                objElement = objElement.Next;
                num1++;
            }
            return false;
        }

        public bool Remove(DataGridViewCell objDataGridViewCell)
        {
            DataGridViewCellLinkedListElement objElement1 = null;
            DataGridViewCellLinkedListElement objElement2 = this.headElement;
            while (objElement2 != null)
            {
                if (objElement2.DataGridViewCell == objDataGridViewCell)
                {
                    break;
                }
                objElement1 = objElement2;
                objElement2 = objElement2.Next;
            }
            if (objElement2.DataGridViewCell != objDataGridViewCell)
            {
                return false;
            }
            DataGridViewCellLinkedListElement objElement3 = objElement2.Next;
            if (objElement1 == null)
            {
                this.headElement = objElement3;
            }
            else
            {
                objElement1.Next = objElement3;
            }
            this.mintCount--;
            this.lastAccessedElement = null;
            this.mintLastAccessedIndex = -1;
            return true;
        }

        public int RemoveAllCellsAtBand(bool blnColumn, int intBandIndex)
        {
            int num1 = 0;
            DataGridViewCellLinkedListElement objElement1 = null;
            DataGridViewCellLinkedListElement objElement2 = this.headElement;
            while (objElement2 != null)
            {
                if ((blnColumn && (objElement2.DataGridViewCell.ColumnIndex == intBandIndex)) || (!blnColumn && (objElement2.DataGridViewCell.RowIndex == intBandIndex)))
                {
                    DataGridViewCellLinkedListElement objElement3 = objElement2.Next;
                    if (objElement1 == null)
                    {
                        this.headElement = objElement3;
                    }
                    else
                    {
                        objElement1.Next = objElement3;
                    }
                    objElement2 = objElement3;
                    this.mintCount--;
                    this.lastAccessedElement = null;
                    this.mintLastAccessedIndex = -1;
                    num1++;
                }
                else
                {
                    objElement1 = objElement2;
                    objElement2 = objElement2.Next;
                }
            }
            return num1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new DataGridViewCellLinkedListEnumerator(this.headElement);
        }

        #endregion Methods

        #region Properties

        public int Count
        {
            get
            {
                return this.mintCount;
            }
        }

        public DataGridViewCell HeadCell
        {
            get
            {
                return this.headElement.DataGridViewCell;
            }
        }

        public DataGridViewCell this[int index]
        {
            get
            {
                if ((this.mintLastAccessedIndex == -1) || (index < this.mintLastAccessedIndex))
                {
                    DataGridViewCellLinkedListElement objElement = this.headElement;
                    for (int num1 = index; num1 > 0; num1--)
                    {
                        objElement = objElement.Next;
                    }
                    this.lastAccessedElement = objElement;
                    this.mintLastAccessedIndex = index;
                    return objElement.DataGridViewCell;
                }
                while (this.mintLastAccessedIndex < index)
                {
                    this.lastAccessedElement = this.lastAccessedElement.Next;
                    this.mintLastAccessedIndex++;
                }
                return this.lastAccessedElement.DataGridViewCell;
            }
        }

        #endregion Properties
    }

    #endregion

    #region DataGridViewCellLinkedListElement Class

    [Serializable()]
    internal class DataGridViewCellLinkedListElement
    {
        public DataGridViewCellLinkedListElement(DataGridViewCell objDataGridViewCell)
        {
            this.mobjDataGridViewCell = objDataGridViewCell;
        }

        public DataGridViewCell DataGridViewCell
        {
            get
            {
                return this.mobjDataGridViewCell;
            }
        }

        public DataGridViewCellLinkedListElement Next
        {
            get
            {
                return this.mobjNext;
            }
            set
            {
                this.mobjNext = value;
            }
        }

        private DataGridViewCell mobjDataGridViewCell;

        private DataGridViewCellLinkedListElement mobjNext;
    }

    #endregion

    #region DataGridViewCellLinkedListEnumerator Class

    [Serializable()]
    internal class DataGridViewCellLinkedListEnumerator : IEnumerator
    {
        private DataGridViewCellLinkedListElement current;
        private DataGridViewCellLinkedListElement headElement;
        private bool mblnReset;

        public DataGridViewCellLinkedListEnumerator(DataGridViewCellLinkedListElement headElement)
        {
            this.headElement = headElement;
            this.mblnReset = true;
        }

        bool IEnumerator.MoveNext()
        {
            if (this.mblnReset)
            {
                this.current = this.headElement;
                this.mblnReset = false;
            }
            else
            {
                this.current = this.current.Next;
            }
            return (this.current != null);
        }

        void IEnumerator.Reset()
        {
            this.mblnReset = true;
            this.current = null;
        }

        object IEnumerator.Current
        {
            get
            {
                return this.current.DataGridViewCell;
            }
        }
    }

    #endregion

    #region DataGridViewIntLinkedList

    [Serializable()]
    internal class DataGridViewIntLinkedList : IEnumerable
    {
        #region Members

        private int mintCount;
        private DataGridViewIntLinkedListElement headElement;
        private DataGridViewIntLinkedListElement lastAccessedElement;
        private int mintLastAccessedIndex;

        #endregion Members

        #region C'tors / D'tors

        public DataGridViewIntLinkedList()
        {
            this.mintLastAccessedIndex = -1;
        }

        public DataGridViewIntLinkedList(DataGridViewIntLinkedList source)
        {
            int num1 = source.Count;
            for (int num2 = 0; num2 < num1; num2++)
            {
                this.Add(source[num2]);
            }
        }

        #endregion C'tors / D'tors

        #region Methods

        public void Add(int integer)
        {
            DataGridViewIntLinkedListElement objElement = new DataGridViewIntLinkedListElement(integer);
            if (this.headElement != null)
            {
                objElement.Next = this.headElement;
            }
            this.headElement = objElement;
            this.mintCount++;
            this.lastAccessedElement = null;
            this.mintLastAccessedIndex = -1;
        }

        public void Clear()
        {
            this.lastAccessedElement = null;
            this.mintLastAccessedIndex = -1;
            this.headElement = null;
            this.mintCount = 0;
        }

        public bool Contains(int integer)
        {
            int num1 = 0;
            DataGridViewIntLinkedListElement objElement = this.headElement;
            while (objElement != null)
            {
                if (objElement.Int == integer)
                {
                    this.lastAccessedElement = objElement;
                    this.mintLastAccessedIndex = num1;
                    return true;
                }
                objElement = objElement.Next;
                num1++;
            }
            return false;
        }

        public int IndexOf(int integer)
        {
            if (this.Contains(integer))
            {
                return this.mintLastAccessedIndex;
            }
            return -1;
        }

        public bool Remove(int integer)
        {
            DataGridViewIntLinkedListElement objElement1 = null;
            DataGridViewIntLinkedListElement objElement2 = this.headElement;
            while (objElement2 != null)
            {
                if (objElement2.Int == integer)
                {
                    break;
                }
                objElement1 = objElement2;
                objElement2 = objElement2.Next;
            }
            if (objElement2.Int != integer)
            {
                return false;
            }
            DataGridViewIntLinkedListElement objElement3 = objElement2.Next;
            if (objElement1 == null)
            {
                this.headElement = objElement3;
            }
            else
            {
                objElement1.Next = objElement3;
            }
            this.mintCount--;
            this.lastAccessedElement = null;
            this.mintLastAccessedIndex = -1;
            return true;
        }

        public void RemoveAt(int index)
        {
            DataGridViewIntLinkedListElement objElement1 = null;
            DataGridViewIntLinkedListElement objElement2 = this.headElement;
            while (index > 0)
            {
                objElement1 = objElement2;
                objElement2 = objElement2.Next;
                index--;
            }
            DataGridViewIntLinkedListElement objElement3 = objElement2.Next;
            if (objElement1 == null)
            {
                this.headElement = objElement3;
            }
            else
            {
                objElement1.Next = objElement3;
            }
            this.mintCount--;
            this.lastAccessedElement = null;
            this.mintLastAccessedIndex = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new DataGridViewIntLinkedListEnumerator(this.headElement);
        }

        #endregion Methods

        #region Properties


        public int Count
        {
            get
            {
                return this.mintCount;
            }
        }

        public int HeadInt
        {
            get
            {
                return this.headElement.Int;
            }
        }

        public int this[int index]
        {
            get
            {
                if ((this.mintLastAccessedIndex == -1) || (index < this.mintLastAccessedIndex))
                {
                    DataGridViewIntLinkedListElement objElement = this.headElement;
                    for (int num1 = index; num1 > 0; num1--)
                    {
                        objElement = objElement.Next;
                    }
                    this.lastAccessedElement = objElement;
                    this.mintLastAccessedIndex = index;
                    return objElement.Int;
                }
                while (this.mintLastAccessedIndex < index)
                {
                    this.lastAccessedElement = this.lastAccessedElement.Next;
                    this.mintLastAccessedIndex++;
                }
                return this.lastAccessedElement.Int;
            }
            set
            {
                if (index != this.mintLastAccessedIndex)
                {
                    int num1 = this[index];
                }
                this.lastAccessedElement.Int = value;
            }
        }

        #endregion Properties
    }

    #endregion

    #region DataGridViewIntLinkedListElement Class

    [Serializable()]
    internal class DataGridViewIntLinkedListElement
    {
        #region Members

        private int mintInteger;
        private DataGridViewIntLinkedListElement mobjNext;

        #endregion Members

        #region C'tors / D'tors

        public DataGridViewIntLinkedListElement(int integer)
        {
            this.mintInteger = integer;
        }

        #endregion C'tors / D'tors

        #region Properties

        public int Int
        {
            get
            {
                return this.mintInteger;
            }
            set
            {
                this.mintInteger = value;
            }
        }

        public DataGridViewIntLinkedListElement Next
        {
            get
            {
                return this.mobjNext;
            }
            set
            {
                this.mobjNext = value;
            }
        }

        #endregion Properties
    }

    #endregion

    #region DataGridViewIntLinkedListEnumerator Class

    [Serializable()]
    internal class DataGridViewIntLinkedListEnumerator : IEnumerator
    {
        #region Members

        private DataGridViewIntLinkedListElement mobjCurrent;
        private DataGridViewIntLinkedListElement mobjHeadElement;
        private bool mblnReset;

        #endregion Members

        #region C'tors / D'tors

        public DataGridViewIntLinkedListEnumerator(DataGridViewIntLinkedListElement headElement)
        {
            this.mobjHeadElement = headElement;
            this.mblnReset = true;
        }

        #endregion C'tors / D'tors

        #region Methods

        bool IEnumerator.MoveNext()
        {
            if (this.mblnReset)
            {
                this.mobjCurrent = this.mobjHeadElement;
                this.mblnReset = false;
            }
            else
            {
                this.mobjCurrent = this.mobjCurrent.Next;
            }
            return (this.mobjCurrent != null);
        }

        void IEnumerator.Reset()
        {
            this.mblnReset = true;
            this.mobjCurrent = null;
        }

        #endregion Methods

        #region Properties

        object IEnumerator.Current
        {
            get
            {
                return this.mobjCurrent.Int;
            }
        }

        #endregion Properties
    }

    #endregion

    #endregion

    #region Style Related

    #region DataGridViewCellStyle Class

    /// <summary>Represents the formatting and style information applied to individual cells within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>

#if WG_NET46
    [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewCellStyleEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), TypeConverter(typeof(DataGridViewCellStyleConverter))]
#elif WG_NET452
    [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewCellStyleEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), TypeConverter(typeof(DataGridViewCellStyleConverter))]
#elif WG_NET451
    [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewCellStyleEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), TypeConverter(typeof(DataGridViewCellStyleConverter))]
#elif WG_NET45
    [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewCellStyleEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), TypeConverter(typeof(DataGridViewCellStyleConverter))]
#elif WG_NET40
    [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewCellStyleEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), TypeConverter(typeof(DataGridViewCellStyleConverter))]
#elif WG_NET35
    [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewCellStyleEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), TypeConverter(typeof(DataGridViewCellStyleConverter))]
#elif WG_NET2
    [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewCellStyleEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), TypeConverter(typeof(DataGridViewCellStyleConverter))]
#else
    [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewCellStyleEditor, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor)), TypeConverter(typeof(DataGridViewCellStyleConverter))]
#endif

    [Serializable()]
    public class DataGridViewCellStyle : SerializableObject, ICloneable
    {
        #region Members

        #region Serializable Events

        #endregion Serializable Events

        #region Private Members

        // Consts
        private const string DATAGRIDVIEWCELLSTYLE_nullText = "";

        private DataGridViewCellStyleScopes menmScope;
        private DataGridView mobjDataGridView = null;
        private DataGridViewTriState menmWrapMode = DataGridViewTriState.NotSet;
        private object mobjTag = null;
        private Padding mobjPadding = Padding.Empty;
        private object mobjNullValue = string.Empty;
        private object mobjFormat = null;
        private DataGridViewContentAlignment menmAlignment = DataGridViewContentAlignment.NotSet;
        private Color mobjSelectionForeColor = Color.Empty;
        private Color mobjSelectionBackColor = Color.Empty;
        private object mobjFormatProvider = null;
        private Color mobjForeColor = Color.Empty;
        private SerializableFont mobjFont = null;
        private Color mobjBackColor = Color.Empty;
        private object mobjDataSourceNullValue = DBNull.Value;

        #endregion Private Members

        #endregion Members

        #region C'tors / D'tors

        // C'tor
        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewCellStyle"/> class.
        /// </summary>
        public DataGridViewCellStyle()
        {
            this.Scope = DataGridViewCellStyleScopes.None;
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> class using the property values of the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
        /// <param name="objDataGridViewCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> used as a template to provide initial property values. </param>
        /// <exception cref="T:System.ArgumentNullException">dataGridViewCellStyle is null.</exception>
        public DataGridViewCellStyle(DataGridViewCellStyle objDataGridViewCellStyle)
        {
            if (objDataGridViewCellStyle == null)
            {
                throw new ArgumentNullException("dataGridViewCellStyle");
            }

            this.Scope = DataGridViewCellStyleScopes.None;
            this.BackColor = objDataGridViewCellStyle.BackColor;
            this.ForeColor = objDataGridViewCellStyle.ForeColor;
            this.SelectionBackColor = objDataGridViewCellStyle.SelectionBackColor;
            this.SelectionForeColor = objDataGridViewCellStyle.SelectionForeColor;
            this.Font = objDataGridViewCellStyle.Font;
            this.NullValue = objDataGridViewCellStyle.NullValue;
            this.DataSourceNullValue = objDataGridViewCellStyle.DataSourceNullValue;
            this.Format = objDataGridViewCellStyle.Format;
            if (!objDataGridViewCellStyle.IsFormatProviderDefault)
            {
                this.FormatProvider = objDataGridViewCellStyle.FormatProvider;
            }
            this.AlignmentInternal = objDataGridViewCellStyle.Alignment;
            this.WrapModeInternal = objDataGridViewCellStyle.WrapMode;
            this.Tag = objDataGridViewCellStyle.Tag;
            this.PaddingInternal = objDataGridViewCellStyle.Padding;
        }

        #endregion C'tors / D'tors

        #region Methods

        #region Events

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="enmProperty">The property.</param>
        private void OnPropertyChanged(DataGridViewCellStylePropertyInternal enmProperty)
        {
            DataGridView objDataGridView = this.DataGridView;

            if ((objDataGridView != null) && (this.Scope != DataGridViewCellStyleScopes.None))
            {
                objDataGridView.OnCellStyleContentChanged(this, enmProperty);
            }
        }

        #endregion Events

        #region Render

        #endregion Render

        internal void AddScope(DataGridView objDataGridView, DataGridViewCellStyleScopes enmScope)
        {
            this.Scope |= enmScope;
            this.DataGridView = objDataGridView;
        }

        /// <summary>Applies the specified <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
        /// <param name="objDataGridViewCellStyle">The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to apply to the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</param>
        /// <exception cref="T:System.ArgumentNullException">dataGridViewCellStyle is null.</exception>
        /// <filterpriority>1</filterpriority>
        public virtual void ApplyStyle(DataGridViewCellStyle objDataGridViewCellStyle)
        {
            if (objDataGridViewCellStyle == null)
            {
                throw new ArgumentNullException("dataGridViewCellStyle");
            }
            if (!objDataGridViewCellStyle.BackColor.IsEmpty)
            {
                this.BackColor = objDataGridViewCellStyle.BackColor;
            }
            if (!objDataGridViewCellStyle.ForeColor.IsEmpty)
            {
                this.ForeColor = objDataGridViewCellStyle.ForeColor;
            }
            if (!objDataGridViewCellStyle.SelectionBackColor.IsEmpty)
            {
                this.SelectionBackColor = objDataGridViewCellStyle.SelectionBackColor;
            }
            if (!objDataGridViewCellStyle.SelectionForeColor.IsEmpty)
            {
                this.SelectionForeColor = objDataGridViewCellStyle.SelectionForeColor;
            }
            if (objDataGridViewCellStyle.Font != null)
            {
                this.Font = objDataGridViewCellStyle.Font;
            }
            if (!objDataGridViewCellStyle.IsNullValueDefault)
            {
                this.NullValue = objDataGridViewCellStyle.NullValue;
            }
            if (!objDataGridViewCellStyle.IsDataSourceNullValueDefault)
            {
                this.DataSourceNullValue = objDataGridViewCellStyle.DataSourceNullValue;
            }
            if (objDataGridViewCellStyle.Format.Length != 0)
            {
                this.Format = objDataGridViewCellStyle.Format;
            }
            if (!objDataGridViewCellStyle.IsFormatProviderDefault)
            {
                this.FormatProvider = objDataGridViewCellStyle.FormatProvider;
            }
            if (objDataGridViewCellStyle.Alignment != DataGridViewContentAlignment.NotSet)
            {
                this.AlignmentInternal = objDataGridViewCellStyle.Alignment;
            }
            if (objDataGridViewCellStyle.WrapMode != DataGridViewTriState.NotSet)
            {
                this.WrapModeInternal = objDataGridViewCellStyle.WrapMode;
            }
            if (objDataGridViewCellStyle.Tag != null)
            {
                this.Tag = objDataGridViewCellStyle.Tag;
            }
            if (objDataGridViewCellStyle.Padding != Padding.Empty)
            {
                this.PaddingInternal = objDataGridViewCellStyle.Padding;
            }
        }

        /// <summary>Creates an exact copy of this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents an exact copy of this cell style.</returns>
        public virtual DataGridViewCellStyle Clone()
        {
            return new DataGridViewCellStyle(this);
        }

        /// <summary>Returns a value indicating whether this instance is equivalent to the specified object.</summary>
        /// <returns>true if o is a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> and has the same property values as this instance; otherwise, false.</returns>
        /// <param name="o">An object to compare with this instance, or null. </param>
        /// <filterpriority>1</filterpriority>
        public override bool Equals(object obj)
        {
            DataGridViewCellStyle objDataGridViewCellStyle = obj as DataGridViewCellStyle;
            return ((objDataGridViewCellStyle != null) && (this.GetDifferencesFrom(objDataGridViewCellStyle) == DataGridViewCellStyleDifferences.None));
        }

        /// <summary>
        /// Gets the differences from.
        /// </summary>
        /// <param name="objDataGridViewCellStyle">The data grid view cell style.</param>
        /// <returns></returns>
        internal DataGridViewCellStyleDifferences GetDifferencesFrom(DataGridViewCellStyle objDataGridViewCellStyle)
        {
            bool blnFlag = ((((objDataGridViewCellStyle.Alignment != this.Alignment) || (objDataGridViewCellStyle.DataSourceNullValue != this.DataSourceNullValue)) || ((objDataGridViewCellStyle.Font != this.Font) || (objDataGridViewCellStyle.Format != this.Format))) || (((objDataGridViewCellStyle.FormatProvider != this.FormatProvider) || (objDataGridViewCellStyle.NullValue != this.NullValue)) || ((objDataGridViewCellStyle.Padding != this.Padding) || (objDataGridViewCellStyle.Tag != this.Tag)))) || (objDataGridViewCellStyle.WrapMode != this.WrapMode);
            bool blnFlag2 = (((objDataGridViewCellStyle.BackColor != this.BackColor) || (objDataGridViewCellStyle.ForeColor != this.ForeColor)) || (objDataGridViewCellStyle.SelectionBackColor != this.SelectionBackColor)) || (objDataGridViewCellStyle.SelectionForeColor != this.SelectionForeColor);
            if (blnFlag)
            {
                return DataGridViewCellStyleDifferences.AffectPreferredSize;
            }
            if (blnFlag2)
            {
                return DataGridViewCellStyleDifferences.DoNotAffectPreferredSize;
            }
            return DataGridViewCellStyleDifferences.None;
        }

        /// <summary>
        /// Removes the scope.
        /// </summary>
        /// <param name="scope">The scope.</param>
        internal void RemoveScope(DataGridViewCellStyleScopes scope)
        {
            this.Scope &= ~scope;
            if (this.Scope == DataGridViewCellStyleScopes.None)
            {
                this.DataGridView = null;
            }
        }

        internal bool ShouldSerializeBackColor()
        {
            return mobjBackColor != Color.Empty;
        }

        internal bool ShouldSerializeFont()
        {
            return (mobjFont != null);
        }

        internal bool ShouldSerializeForeColor()
        {
            return mobjForeColor != Color.Empty;
        }

        internal bool ShouldSerializeFormatProvider()
        {
            return (mobjFormatProvider != null);
        }

        internal bool ShouldSerializePadding()
        {
            return (this.Padding != Padding.Empty);
        }

        internal bool ShouldSerializeSelectionBackColor()
        {
            return mobjSelectionBackColor != Color.Empty;
        }

        internal bool ShouldSerializeSelectionForeColor()
        {
            return mobjSelectionForeColor != Color.Empty;
        }

        internal bool ShouldSerializeAlignment()
        {
            return menmAlignment != DataGridViewContentAlignment.NotSet;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        /// <summary>Returns a string indicating the current property settings of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
        /// <returns>A string indicating the current property settings of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(0x80);
            builder.Append("DataGridViewCellStyle {");
            bool blnFlag = true;
            if (this.BackColor != Color.Empty)
            {
                builder.Append(" BackColor=" + this.BackColor.ToString());
                blnFlag = false;
            }
            if (this.ForeColor != Color.Empty)
            {
                if (!blnFlag)
                {
                    builder.Append(",");
                }
                builder.Append(" ForeColor=" + this.ForeColor.ToString());
                blnFlag = false;
            }
            if (this.SelectionBackColor != Color.Empty)
            {
                if (!blnFlag)
                {
                    builder.Append(",");
                }
                builder.Append(" SelectionBackColor=" + this.SelectionBackColor.ToString());
                blnFlag = false;
            }
            if (this.SelectionForeColor != Color.Empty)
            {
                if (!blnFlag)
                {
                    builder.Append(",");
                }
                builder.Append(" SelectionForeColor=" + this.SelectionForeColor.ToString());
                blnFlag = false;
            }
            if (this.Font != null)
            {
                if (!blnFlag)
                {
                    builder.Append(",");
                }
                builder.Append(" Font=" + this.Font.ToString());
                blnFlag = false;
            }
            if (!this.IsNullValueDefault && (this.NullValue != null))
            {
                if (!blnFlag)
                {
                    builder.Append(",");
                }
                builder.Append(" NullValue=" + this.NullValue.ToString());
                blnFlag = false;
            }
            if (!this.IsDataSourceNullValueDefault && (this.DataSourceNullValue != null))
            {
                if (!blnFlag)
                {
                    builder.Append(",");
                }
                builder.Append(" DataSourceNullValue=" + this.DataSourceNullValue.ToString());
                blnFlag = false;
            }
            if (!CommonUtils.IsNullOrEmpty(this.Format))
            {
                if (!blnFlag)
                {
                    builder.Append(",");
                }
                builder.Append(" Format=" + this.Format);
                blnFlag = false;
            }
            if (this.WrapMode != DataGridViewTriState.NotSet)
            {
                if (!blnFlag)
                {
                    builder.Append(",");
                }
                builder.Append(" WrapMode=" + this.WrapMode.ToString());
                blnFlag = false;
            }
            if (this.Alignment != DataGridViewContentAlignment.NotSet)
            {
                if (!blnFlag)
                {
                    builder.Append(",");
                }
                builder.Append(" Alignment=" + this.Alignment.ToString());
                blnFlag = false;
            }
            if (this.Padding != Padding.Empty)
            {
                if (!blnFlag)
                {
                    builder.Append(",");
                }
                builder.Append(" Padding=" + this.Padding.ToString());
                blnFlag = false;
            }
            if (this.Tag != null)
            {
                if (!blnFlag)
                {
                    builder.Append(",");
                }
                builder.Append(" Tag=" + this.Tag.ToString());
                blnFlag = false;
            }
            builder.Append(" }");
            return builder.ToString();
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets the data grid view.
        /// </summary>
        /// <value>The data grid view.</value>
        private DataGridView DataGridView
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

        /// <summary>Gets or sets a value indicating the position of the cell content within a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewContentAlignment"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewContentAlignment.NotSet"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property value is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewContentAlignment"></see> value. </exception>
        /// <filterpriority>1</filterpriority>
        [SRDescription("DataGridViewCellStyleAlignmentDescr"), DefaultValue(DataGridViewContentAlignment.NotSet), SRCategory("CatLayout")]
        public DataGridViewContentAlignment Alignment
        {
            get
            {
                return menmAlignment;
            }
            set
            {
                switch (value)
                {
                    case DataGridViewContentAlignment.NotSet:
                    case DataGridViewContentAlignment.TopLeft:
                    case DataGridViewContentAlignment.TopCenter:
                    case DataGridViewContentAlignment.TopRight:
                    case DataGridViewContentAlignment.MiddleLeft:
                    case DataGridViewContentAlignment.MiddleCenter:
                    case DataGridViewContentAlignment.MiddleRight:
                    case DataGridViewContentAlignment.BottomLeft:
                    case DataGridViewContentAlignment.BottomCenter:
                    case DataGridViewContentAlignment.BottomRight:
                        this.AlignmentInternal = value;
                        return;
                }
                throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewContentAlignment));
            }
        }

        internal DataGridViewContentAlignment AlignmentInternal
        {
            set
            {
                if (this.Alignment != value)
                {
                    menmAlignment = value;
                    this.OnPropertyChanged(DataGridViewCellStylePropertyInternal.Other);
                }
            }
        }

        /// <summary>Gets or sets the background color of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the background color of a cell. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatAppearance")]
        public Color BackColor
        {
            get
            {
                return mobjBackColor;
            }
            set
            {
                if ((mobjBackColor == null && value != null) || (mobjBackColor != null && !mobjBackColor.Equals(value)))
                {
                    mobjBackColor = value;
                    this.OnPropertyChanged(DataGridViewCellStylePropertyInternal.Color);
                }
            }
        }

        /// <summary>Gets or sets the value saved to the data source when the user enters a null value into a cell.</summary>
        /// <returns>The value saved to the data source when the user specifies a null cell value. The default is <see cref="F:System.DBNull.Value"></see>.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object DataSourceNullValue
        {
            get
            {
                return mobjDataSourceNullValue;
            }
            set
            {
                object objDataSourceNullValue = this.DataSourceNullValue;
                if ((objDataSourceNullValue != value) && ((objDataSourceNullValue == null) || !objDataSourceNullValue.Equals(value)))
                {
                    mobjDataSourceNullValue = value;

                    this.OnPropertyChanged(DataGridViewCellStylePropertyInternal.Other);
                }
            }
        }

        /// <summary>Gets or sets the font applied to the textual content of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
        /// <returns>The <see cref="T:System.Drawing.Font"></see> applied to the cell text. The default is null.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatAppearance")]
        public Font Font
        {
            get
            {
                return mobjFont;
            }
            set
            {
                if ((mobjFont == null && value != null) || (mobjFont != null && !mobjFont.Equals((SerializableFont)value)))
                {
                    mobjFont = (SerializableFont)value;
                    this.OnPropertyChanged(DataGridViewCellStylePropertyInternal.Font);
                }
            }
        }

        /// <summary>Gets or sets the foreground color of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the foreground color of a cell. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatAppearance")]
        public Color ForeColor
        {
            get
            {
                return mobjForeColor;
            }
            set
            {
                if ((mobjForeColor == null && value != null) || (mobjForeColor != null && !mobjForeColor.Equals(value)))
                {
                    mobjForeColor = value;
                    this.OnPropertyChanged(DataGridViewCellStylePropertyInternal.ForeColor);
                }
            }
        }

        /// <summary>Gets or sets the format string applied to the textual content of a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell.</summary>
        /// <returns>A string that indicates the format of the cell value. The default is <see cref="F:System.String.Empty"></see>.</returns>
        /// <filterpriority>1</filterpriority>
#if WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
        [Editor("System.Windows.Forms.Design.FormatStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), DefaultValue(""), SRCategory("CatBehavior"), EditorBrowsable(EditorBrowsableState.Advanced)]
#else
        [Editor("System.Windows.Forms.Design.FormatStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), DefaultValue(""), SRCategory("CatBehavior"), EditorBrowsable(EditorBrowsableState.Advanced)]
#endif
        public string Format
        {
            get
            {
                object obj2 = mobjFormat;
                if (obj2 == null)
                {
                    return string.Empty;
                }
                return (string)obj2;
            }
            set
            {
                string strFormat = this.Format;

                mobjFormat = value;

                if (!strFormat.Equals(this.Format))
                {
                    this.OnPropertyChanged(DataGridViewCellStylePropertyInternal.Other);
                }
            }
        }

        /// <summary>Gets or sets the object used to provide culture-specific formatting of <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell values.</summary>
        /// <returns>An <see cref="T:System.IFormatProvider"></see> used for cell formatting. The default is <see cref="P:System.Globalization.CultureInfo.CurrentUICulture"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public IFormatProvider FormatProvider
        {
            get
            {
                if (mobjFormatProvider == null)
                {
                    IContext objContext = VWGContext.Current;
                    if (objContext != null)
                    {
                        return objContext.CurrentUICulture;
                    }
                }

                return mobjFormatProvider as IFormatProvider;
            }
            set
            {
                if (value != mobjFormatProvider)
                {
                    mobjFormatProvider = value;
                    this.OnPropertyChanged(DataGridViewCellStylePropertyInternal.Other);
                }
            }
        }

        /// <summary>Gets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.DataSourceNullValue"></see> property has been set.</summary>
        /// <returns>true if the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.DataSourceNullValue"></see> property is the default value; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public bool IsDataSourceNullValueDefault
        {
            get
            {
                return (mobjDataSourceNullValue == DBNull.Value);
            }
        }

        /// <summary>Gets a value that indicates whether the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.FormatProvider"></see> property has been set.</summary>
        /// <returns>true if the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.FormatProvider"></see> property is the default value; otherwise, false.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool IsFormatProviderDefault
        {
            get
            {
                return (mobjFormatProvider == null);
            }
        }

        /// <summary>Gets a value indicating whether the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.NullValue"></see> property has been set.</summary>
        /// <returns>true if the value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCellStyle.NullValue"></see> property is the default value; otherwise, false.</returns>
        [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false)]
        public bool IsNullValueDefault
        {
            get
            {
                return ((mobjNullValue is string) && mobjNullValue.Equals(""));
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell display value corresponding to a cell value of <see cref="F:System.DBNull.Value"></see> or null.</summary>
        /// <returns>The object used to indicate a null value in a cell. The default is <see cref="F:System.String.Empty"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatData"), DefaultValue(""), TypeConverter(typeof(StringConverter))]
        public object NullValue
        {
            get
            {
                return mobjNullValue;
            }
            set
            {
                object objNullValue = this.NullValue;
                if (mobjNullValue != value)
                {
                    mobjNullValue = value;

                    this.OnPropertyChanged(DataGridViewCellStylePropertyInternal.Other);
                }
            }
        }

        /// <summary>Gets or sets the space between the edge of a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> and its content.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.Padding"></see> that represents the space between the edge of a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> and its content.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatLayout")]
        public Padding Padding
        {
            get
            {
                return mobjPadding;
            }
            set
            {
                if (((value.Left < 0) || (value.Right < 0)) || ((value.Top < 0) || (value.Bottom < 0)))
                {
                    if (value.All != -1)
                    {
                        value.All = 0;
                    }
                    else
                    {
                        value.Left = Math.Max(0, value.Left);
                        value.Right = Math.Max(0, value.Right);
                        value.Top = Math.Max(0, value.Top);
                        value.Bottom = Math.Max(0, value.Bottom);
                    }
                }
                this.PaddingInternal = value;
            }
        }

        internal Padding PaddingInternal
        {
            set
            {
                if (mobjPadding != value)
                {
                    mobjPadding = value;
                    this.OnPropertyChanged(DataGridViewCellStylePropertyInternal.Other);
                }
            }
        }

        /// <summary>
        /// Gets or sets the scope.
        /// </summary>
        /// <value>The scope.</value>
        internal DataGridViewCellStyleScopes Scope
        {
            get
            {
                return this.menmScope;
            }
            set
            {
                this.menmScope = value;
            }
        }

        /// <summary>Gets or sets the background color used by a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell when it is selected.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the background color of a selected cell. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatAppearance")]
        public Color SelectionBackColor
        {
            get
            {
                return mobjSelectionBackColor;
            }
            set
            {
                if ((mobjSelectionBackColor == null && value != null) || (mobjSelectionBackColor != null && !mobjSelectionBackColor.Equals(value)))
                {
                    mobjSelectionBackColor = value;
                    this.OnPropertyChanged(DataGridViewCellStylePropertyInternal.Color);
                }
            }
        }

        /// <summary>Gets or sets the foreground color used by a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell when it is selected.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the foreground color of a selected cell. The default is <see cref="F:System.Drawing.Color.Empty"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatAppearance")]
        public Color SelectionForeColor
        {
            get
            {
                return mobjSelectionForeColor;
            }
            set
            {
                if ((mobjSelectionForeColor == null && value != null) || (mobjSelectionForeColor != null && !mobjSelectionForeColor.Equals(value)))
                {
                    mobjSelectionForeColor = value;

                    this.OnPropertyChanged(DataGridViewCellStylePropertyInternal.Color);
                }
            }
        }


        /// <summary>Gets or sets an object that contains additional data related to the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see>.</summary>
        /// <returns>An object that contains additional data. The default is null.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object Tag
        {
            get
            {
                return mobjTag;
            }
            set
            {
                mobjTag = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether textual content in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> cell is wrapped to subsequent lines or truncated when it is too long to fit on a single line.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewTriState.NotSet"></see>.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property value is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> value. </exception>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(DataGridViewTriState.NotSet), SRCategory("CatLayout")]
        public DataGridViewTriState WrapMode
        {
            get
            {
                return menmWrapMode;
            }
            set
            {
                if (!ClientUtils.IsEnumValid(value, (int)value, 0, 2))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewTriState));
                }
                this.WrapModeInternal = value;
            }
        }

        internal DataGridViewTriState WrapModeInternal
        {
            set
            {
                if (this.WrapMode != value)
                {
                    menmWrapMode = value;
                    this.OnPropertyChanged(DataGridViewCellStylePropertyInternal.Other);
                }
            }
        }

        #endregion Properties

        #region Nested Types

        [Serializable()]
        internal enum DataGridViewCellStylePropertyInternal
        {
            Color,
            Other,
            Font,
            ForeColor
        }

        #endregion Nested Types
    }

    #endregion

    #region DataGridViewRowStyle Class

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class DataGridViewRowStyle : SerializableObject
    {
        #region Members

        /// <summary>
        /// Provides a property reference to BorderColor property.
        /// </summary>
        private static SerializableProperty BorderColorProperty = SerializableProperty.Register("BorderColor", typeof(Color), typeof(DataGridViewRowStyle), new SerializablePropertyMetadata());
        /// <summary>
        /// Provides a property reference to BorderStyle property.
        /// </summary>
        private static SerializableProperty BorderStyleProperty = SerializableProperty.Register("BorderStyle", typeof(BorderStyle), typeof(DataGridViewRowStyle), new SerializablePropertyMetadata());
        /// <summary>
        /// Provides a property reference to BorderWidth property.
        /// </summary>
        private static SerializableProperty BorderWidthProperty = SerializableProperty.Register("BorderWidth", typeof(int), typeof(DataGridViewRowStyle), new SerializablePropertyMetadata());

        private DataGridViewRow mobjOwnerDataGridViewRow = null;

        #endregion Members

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewRowStyle"/> class.
        /// </summary>
        /// <param name="objDataGridViewRow">The obj data grid view row.</param>
        public DataGridViewRowStyle(DataGridViewRow objDataGridViewRow)
        {
            mobjOwnerDataGridViewRow = objDataGridViewRow;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the border color.
        /// </summary>
        /// <value></value>
        [SRCategory("CatAppearance")]
        [SRDescription("ControlBorderColorDescr")]
        public virtual Color BorderColor
        {
            get
            {
                return this.GetValue<Color>(DataGridViewRowStyle.BorderColorProperty, this.DefaultBorderColor);

            }
            set
            {
                // Set border color and if value changed update control and raise events             
                if (this.SetValue<Color>(DataGridViewRowStyle.BorderColorProperty, value, this.DefaultBorderColor))
                {
                    // Update owner row.
                    if (mobjOwnerDataGridViewRow != null)
                    {
                        mobjOwnerDataGridViewRow.Update();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the border style.
        /// </summary>
        /// <value></value>
        [SRCategory("CatAppearance")]
        [SRDescription("ControlBorderStyleDescr")]
        public virtual BorderStyle BorderStyle
        {
            get
            {
                // Return border style
                return this.GetValue<BorderStyle>(DataGridViewRowStyle.BorderStyleProperty, this.DefaultBorderStyle);
            }
            set
            {
                // If border style is diffrent from what is in the property store
                if (this.SetValue<BorderStyle>(DataGridViewRowStyle.BorderStyleProperty, value, this.DefaultBorderStyle))
                {
                    // Update owner row.
                    if (mobjOwnerDataGridViewRow != null)
                    {
                        mobjOwnerDataGridViewRow.Update();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the thickness of the border.
        /// </summary>
        /// <value>Gets or sets a border thickness.</value>
        /// <remarks>The thinkness struct can be automaticly casted to and from int for backwords compatibility.</remarks>
        [SRCategory("CatAppearance")]
        [SRDescription("ControlBorderWidthDescr")]
        public virtual int BorderWidth
        {
            get
            {
                // Return border width
                return this.GetValue<int>(DataGridViewRowStyle.BorderWidthProperty, this.DefaultBorderWidth);
            }
            set
            {
                // Set the border width and if value updated update the control
                if (this.SetValue<int>(DataGridViewRowStyle.BorderWidthProperty, value, this.DefaultBorderWidth))
                {
                    // Update owner row.
                    if (mobjOwnerDataGridViewRow != null)
                    {
                        mobjOwnerDataGridViewRow.Update();
                    }
                }
            }
        }

        /// <summary>
        /// Gets the default color of the border.
        /// </summary>
        /// <value>The default color of the border.</value>
        protected virtual Color DefaultBorderColor
        {
            get
            {
                return Color.Empty;
            }
        }

        /// <summary>
        /// Gets the default border style.
        /// </summary>
        /// <value>The default border style.</value>
        protected virtual BorderStyle DefaultBorderStyle
        {
            get
            {
                return BorderStyle.None;
            }
        }

        /// <summary>
        /// Gets the default width of the border.
        /// </summary>
        /// <value>The default width of the border.</value>
        protected virtual int DefaultBorderWidth
        {
            get
            {
                return 0;
            }
        }

        #endregion Properties
    }

    #endregion

    #region DataGridViewAdvancedBorderStyle Class

    /// <summary>Contains border styles for the cells in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [Serializable()]
    public sealed class DataGridViewAdvancedBorderStyle : ICloneable
    {
        #region Members

        private bool mblnAll;
        private DataGridViewAdvancedCellBorderStyle menmBanned1;
        private DataGridViewAdvancedCellBorderStyle menmBanned2;
        private DataGridViewAdvancedCellBorderStyle menmBanned3;
        private DataGridViewAdvancedCellBorderStyle menmBottom;
        private DataGridViewAdvancedCellBorderStyle menmLeft;
        private DataGridView mobjOwner;
        private DataGridViewAdvancedCellBorderStyle menmRight;
        private DataGridViewAdvancedCellBorderStyle menmTop;

        #endregion Members

        #region C'tors / D'tors

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> class. </summary>
        public DataGridViewAdvancedBorderStyle()
            : this(null, DataGridViewAdvancedCellBorderStyle.NotSet, DataGridViewAdvancedCellBorderStyle.NotSet, DataGridViewAdvancedCellBorderStyle.NotSet)
        {
        }

        internal DataGridViewAdvancedBorderStyle(DataGridView objOwner)
            : this(objOwner, DataGridViewAdvancedCellBorderStyle.NotSet, DataGridViewAdvancedCellBorderStyle.NotSet, DataGridViewAdvancedCellBorderStyle.NotSet)
        {
        }

        internal DataGridViewAdvancedBorderStyle(DataGridView objOwner, DataGridViewAdvancedCellBorderStyle enmBanned1, DataGridViewAdvancedCellBorderStyle enmBanned2, DataGridViewAdvancedCellBorderStyle enmBanned3)
        {
            this.mblnAll = true;
            this.menmTop = DataGridViewAdvancedCellBorderStyle.None;
            this.menmLeft = DataGridViewAdvancedCellBorderStyle.None;
            this.menmRight = DataGridViewAdvancedCellBorderStyle.None;
            this.menmBottom = DataGridViewAdvancedCellBorderStyle.None;
            this.mobjOwner = objOwner;
            this.menmBanned1 = enmBanned1;
            this.menmBanned2 = enmBanned2;
            this.menmBanned3 = enmBanned3;
        }

        #endregion C'tors / D'tors

        #region Methods

        /// <summary>Determines whether the specified object is equal to the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see>.</summary>
        /// <returns>true if other is a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> and the values for the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle.Top"></see>, <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle.Bottom"></see>, <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle.Left"></see>, and <see cref="P:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle.Right"></see> properties are equal to their counterpart in the current <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see>; otherwise, false.</returns>
        /// <param name="other">An <see cref="T:System.Object"></see> to be compared.</param>
        /// <filterpriority>1</filterpriority>
        public override bool Equals(object other)
        {
            DataGridViewAdvancedBorderStyle objStyle = other as DataGridViewAdvancedBorderStyle;
            if ((objStyle != null) && (((objStyle.mblnAll == this.mblnAll) && (objStyle.menmTop == this.menmTop)) && ((objStyle.menmLeft == this.menmLeft) && (objStyle.menmBottom == this.menmBottom))))
            {
                return (objStyle.menmRight == this.menmRight);
            }
            return false;
        }

        /// <filterpriority>1</filterpriority>
        public override int GetHashCode()
        {
            return ClientUtils.GetCombinedHashCodes(new int[] { (int)this.menmTop, (int)this.menmLeft, (int)this.menmBottom, (int)this.menmRight });
        }

        object ICloneable.Clone()
        {
            DataGridViewAdvancedBorderStyle objStyle = new DataGridViewAdvancedBorderStyle(this.mobjOwner, this.menmBanned1, this.menmBanned2, this.menmBanned3);
            objStyle.mblnAll = this.mblnAll;
            objStyle.menmTop = this.menmTop;
            objStyle.menmRight = this.menmRight;
            objStyle.menmBottom = this.menmBottom;
            objStyle.menmLeft = this.menmLeft;
            return objStyle;
        }

        /// <summary>Returns a string that represents the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see>.</summary>
        /// <returns>A string that represents the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            return ("DataGridViewAdvancedBorderStyle { All=" + this.All.ToString() + ", Left=" + this.Left.ToString() + ", Right=" + this.Right.ToString() + ", Top=" + this.Top.ToString() + ", Bottom=" + this.Bottom.ToString() + " }");
        }

        #endregion Methods

        #region Properties

        /// <summary>Gets or sets the border style for all of the borders of a cell.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</exception>
        /// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.NotSet"></see>.-or-The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.OutsetDouble"></see>, <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.OutsetPartial"></see>, or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.InsetDouble"></see> and this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> instance was retrieved through the <see cref="P:Gizmox.WebGUI.Forms.DataGridView.AdvancedCellBorderStyle"></see> property.</exception>
        /// <filterpriority>1</filterpriority>
        public DataGridViewAdvancedCellBorderStyle All
        {
            get
            {
                if (!this.mblnAll)
                {
                    return DataGridViewAdvancedCellBorderStyle.NotSet;
                }
                return this.menmTop;
            }
            set
            {
                if (!Gizmox.WebGUI.Forms.ClientUtils.IsEnumValid(value, (int)value, 0, 7))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewAdvancedCellBorderStyle));
                }
                if (((value == DataGridViewAdvancedCellBorderStyle.NotSet) || (value == this.menmBanned1)) || ((value == this.menmBanned2) || (value == this.menmBanned3)))
                {
                    throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", new object[] { "All" }));
                }
                if (!this.mblnAll || (this.menmTop != value))
                {
                    this.mblnAll = true;
                    this.menmTop = this.menmLeft = this.menmRight = this.menmBottom = value;
                    if (this.mobjOwner != null)
                    {
                        // TODO:DATAGRID
                        // this.owner.OnAdvancedBorderStyleChanged(this);
                    }
                }
            }
        }

        /// <summary>Gets or sets the style for the bottom border of a cell.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</exception>
        /// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.NotSet"></see>.</exception>
        /// <filterpriority>1</filterpriority>
        public DataGridViewAdvancedCellBorderStyle Bottom
        {
            get
            {
                if (this.mblnAll)
                {
                    return this.menmTop;
                }
                return this.menmBottom;
            }
            set
            {
                if (!Gizmox.WebGUI.Forms.ClientUtils.IsEnumValid(value, (int)value, 0, 7))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewAdvancedCellBorderStyle));
                }
                if (value == DataGridViewAdvancedCellBorderStyle.NotSet)
                {
                    throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", new object[] { "Bottom" }));
                }
                this.BottomInternal = value;
            }
        }

        internal DataGridViewAdvancedCellBorderStyle BottomInternal
        {
            set
            {
                if ((this.mblnAll && (this.menmTop != value)) || (!this.mblnAll && (this.menmBottom != value)))
                {
                    if (this.mblnAll && (this.menmRight == DataGridViewAdvancedCellBorderStyle.OutsetDouble))
                    {
                        this.menmRight = DataGridViewAdvancedCellBorderStyle.Outset;
                    }
                    this.mblnAll = false;
                    this.menmBottom = value;
                    if (this.mobjOwner != null)
                    {
                        // TODO:DATAGRID
                        //this.owner.OnAdvancedBorderStyleChanged(this);
                    }
                }
            }
        }

        /// <summary>Gets the style for the left border of a cell.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see>.</exception>
        /// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.NotSet"></see>.-or-The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.InsetDouble"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.OutsetDouble"></see> and this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> instance has an associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control with a <see cref="P:Gizmox.WebGUI.Forms.Control.RightToLeft"></see> property value of true.</exception>
        /// <filterpriority>1</filterpriority>
        public DataGridViewAdvancedCellBorderStyle Left
        {
            get
            {
                if (this.mblnAll)
                {
                    return this.menmTop;
                }
                return this.menmLeft;
            }
            set
            {
                if (!Gizmox.WebGUI.Forms.ClientUtils.IsEnumValid(value, (int)value, 0, 7))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewAdvancedCellBorderStyle));
                }
                if (value == DataGridViewAdvancedCellBorderStyle.NotSet)
                {
                    throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", new object[] { "Left" }));
                }
                this.LeftInternal = value;
            }
        }

        internal DataGridViewAdvancedCellBorderStyle LeftInternal
        {
            set
            {
                if ((this.mblnAll && (this.menmTop != value)) || (!this.mblnAll && (this.menmLeft != value)))
                {
                    // TODO:DATAGRID
                    if (((this.mobjOwner != null) && false/*this.owner.RightToLeftInternal*/) && ((value == DataGridViewAdvancedCellBorderStyle.InsetDouble) || (value == DataGridViewAdvancedCellBorderStyle.OutsetDouble)))
                    {
                        throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", new object[] { "Left" }));
                    }
                    if (this.mblnAll)
                    {
                        if (this.menmRight == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
                        {
                            this.menmRight = DataGridViewAdvancedCellBorderStyle.Outset;
                        }
                        if (this.menmBottom == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
                        {
                            this.menmBottom = DataGridViewAdvancedCellBorderStyle.Outset;
                        }
                    }
                    this.mblnAll = false;
                    this.menmLeft = value;
                    if (this.mobjOwner != null)
                    {
                        // TODO:DATAGRId
                        // this.owner.OnAdvancedBorderStyleChanged(this);
                    }
                }
            }
        }

        /// <summary>Gets the style for the right border of a cell.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see>.</exception>
        /// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.NotSet"></see>.-or-The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.InsetDouble"></see> or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.OutsetDouble"></see> and this <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedBorderStyle"></see> instance has an associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control with a <see cref="P:Gizmox.WebGUI.Forms.Control.RightToLeft"></see> property value of false.</exception>
        /// <filterpriority>1</filterpriority>
        public DataGridViewAdvancedCellBorderStyle Right
        {
            get
            {
                if (this.mblnAll)
                {
                    return this.menmTop;
                }
                return this.menmRight;
            }
            set
            {
                if (!Gizmox.WebGUI.Forms.ClientUtils.IsEnumValid(value, (int)value, 0, 7))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewAdvancedCellBorderStyle));
                }
                if (value == DataGridViewAdvancedCellBorderStyle.NotSet)
                {
                    throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", new object[] { "Right" }));
                }
                this.RightInternal = value;
            }
        }

        internal DataGridViewAdvancedCellBorderStyle RightInternal
        {
            set
            {
                if ((this.mblnAll && (this.menmTop != value)) || (!this.mblnAll && (this.menmRight != value)))
                {
                    // TODO:DATAGRID
                    if (((this.mobjOwner != null) && !true/*this.owner.RightToLeftInternal*/) && ((value == DataGridViewAdvancedCellBorderStyle.InsetDouble) || (value == DataGridViewAdvancedCellBorderStyle.OutsetDouble)))
                    {
                        throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", new object[] { "Right" }));
                    }
                    if (this.mblnAll && (this.menmBottom == DataGridViewAdvancedCellBorderStyle.OutsetDouble))
                    {
                        this.menmBottom = DataGridViewAdvancedCellBorderStyle.Outset;
                    }
                    this.mblnAll = false;
                    this.menmRight = value;
                    if (this.mobjOwner != null)
                    {
                        // TODO:DATAGRID
                        // this.owner.OnAdvancedBorderStyleChanged(this);
                    }
                }
            }
        }

        /// <summary>Gets the style for the top border of a cell.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see> values.</returns>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle"></see>.</exception>
        /// <exception cref="T:System.ArgumentException">The specified value when setting this property is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAdvancedCellBorderStyle.NotSet"></see>.</exception>
        /// <filterpriority>1</filterpriority>
        public DataGridViewAdvancedCellBorderStyle Top
        {
            get
            {
                return this.menmTop;
            }
            set
            {
                if (!Gizmox.WebGUI.Forms.ClientUtils.IsEnumValid(value, (int)value, 0, 7))
                {
                    throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewAdvancedCellBorderStyle));
                }
                if (value == DataGridViewAdvancedCellBorderStyle.NotSet)
                {
                    throw new ArgumentException(SR.GetString("DataGridView_AdvancedCellBorderStyleInvalid", new object[] { "Top" }));
                }
                this.TopInternal = value;
            }
        }

        internal DataGridViewAdvancedCellBorderStyle TopInternal
        {
            set
            {
                if ((this.mblnAll && (this.menmTop != value)) || (!this.mblnAll && (this.menmTop != value)))
                {
                    if (this.mblnAll)
                    {
                        if (this.menmRight == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
                        {
                            this.menmRight = DataGridViewAdvancedCellBorderStyle.Outset;
                        }
                        if (this.menmBottom == DataGridViewAdvancedCellBorderStyle.OutsetDouble)
                        {
                            this.menmBottom = DataGridViewAdvancedCellBorderStyle.Outset;
                        }
                    }
                    this.mblnAll = false;
                    this.menmTop = value;
                    if (this.mobjOwner != null)
                    {
                        // TODO:DATAGRID
                        //this.owner.OnAdvancedBorderStyleChanged(this);
                    }
                }
            }
        }

        #endregion Properties
    }

    #endregion

    #endregion

    #region DataGridViewColumnDesignTimeVisibleAttribute Class

    /// <summary>Specifies whether a column type is visible in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> designer. This class cannot be inherited. </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [Serializable()]
    public sealed class DataGridViewColumnDesignTimeVisibleAttribute : Attribute
    {
        #region Members

        /// <summary>The default <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute"></see> value, which is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute.Yes"></see>, indicating that the column is visible in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> designer. </summary>
        public static readonly DataGridViewColumnDesignTimeVisibleAttribute Default;
        /// <summary>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute"></see> value indicating that the column is not visible in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> designer. </summary>
        public static readonly DataGridViewColumnDesignTimeVisibleAttribute No;
        private bool mblnVisible;
        /// <summary>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute"></see> value indicating that the column is visible in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> designer. </summary>
        public static readonly DataGridViewColumnDesignTimeVisibleAttribute Yes;

        #endregion Members

        #region C'tors / D'tors

        static DataGridViewColumnDesignTimeVisibleAttribute()
        {
            DataGridViewColumnDesignTimeVisibleAttribute.Yes = new DataGridViewColumnDesignTimeVisibleAttribute(true);
            DataGridViewColumnDesignTimeVisibleAttribute.No = new DataGridViewColumnDesignTimeVisibleAttribute(false);
            DataGridViewColumnDesignTimeVisibleAttribute.Default = DataGridViewColumnDesignTimeVisibleAttribute.Yes;
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute"></see> class using the default <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute.Visible"></see> property value of true. </summary>
        public DataGridViewColumnDesignTimeVisibleAttribute()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute"></see> class using the specified value to initialize the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute.Visible"></see> property. </summary>
        /// <param name="blnVisible">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute.Visible"></see> property.</param>
        public DataGridViewColumnDesignTimeVisibleAttribute(bool blnVisible)
        {
            this.mblnVisible = blnVisible;
        }

        #endregion C'tors / D'tors

        #region Methods

        /// <summary>Gets a value indicating whether this object is equivalent to the specified object.</summary>
        /// <returns>true to indicate that the specified object is a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute"></see> instance with the same <see cref="P:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute.Visible"></see> property value as this instance; otherwise, false.</returns>
        /// <param name="obj">The <see cref="T:System.Object"></see> to compare with the current <see cref="T:System.Object"></see>.</param>
        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            DataGridViewColumnDesignTimeVisibleAttribute attribute1 = obj as DataGridViewColumnDesignTimeVisibleAttribute;
            if (attribute1 != null)
            {
                return (attribute1.Visible == this.mblnVisible);
            }
            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return (typeof(DataGridViewColumnDesignTimeVisibleAttribute).GetHashCode() ^ (this.mblnVisible ? -1 : 0));
        }

        /// <summary>Gets a value indicating whether this attribute instance is equal to the <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute.Default"></see> attribute value.</summary>
        /// <returns>true to indicate that this instance is equal to the <see cref="F:Gizmox.WebGUI.Forms.DataGridViewColumnDesignTimeVisibleAttribute.Default"></see> instance; otherwise, false.</returns>
        public override bool IsDefaultAttribute()
        {
            return (this.Visible == DataGridViewColumnDesignTimeVisibleAttribute.Default.Visible);
        }


        #endregion Methods

        #region Properties

        /// <summary>Gets a value indicating whether the column type is visible in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> designer.</summary>
        /// <returns>true to indicate that the column type is visible in the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> designer; otherwise, false.</returns>
        public bool Visible
        {
            get
            {
                return this.mblnVisible;
            }
        }

        #endregion Properties
    }

    #endregion

    #region LinkUtilities

    [Serializable()]
    internal class LinkUtilities
    {
        #region Members

        private static Color ieactiveLinkColor = Color.Empty;
        private const string IEAnchorColor = "Anchor Color";
        private const string IEAnchorColorHover = "Anchor Color Hover";
        private const string IEAnchorColorVisited = "Anchor Color Visited";
        private static Color ielinkColor = Color.Empty;
        public const string IEMainRegPath = @"Software\Microsoft\Internet Explorer\Main";
        private const string IESettingsRegPath = @"Software\Microsoft\Internet Explorer\Settings";
        private static Color ievisitedLinkColor = Color.Empty;

        #endregion Members

        #region Methods

        public static void EnsureLinkFonts(Font baseFont, LinkBehavior link, ref Font linkFont, ref Font hoverLinkFont)
        {
            if ((linkFont == null) || (hoverLinkFont == null))
            {
                bool blnFlag = true;
                bool blnFlag2 = true;
                if (link == LinkBehavior.SystemDefault)
                {
                    link = GetIELinkBehavior();
                }
                switch (link)
                {
                    case LinkBehavior.AlwaysUnderline:
                        blnFlag = true;
                        blnFlag2 = true;
                        break;

                    case LinkBehavior.HoverUnderline:
                        blnFlag = false;
                        blnFlag2 = true;
                        break;

                    case LinkBehavior.NeverUnderline:
                        blnFlag = false;
                        blnFlag2 = false;
                        break;
                }
                Font prototype = baseFont;
                if (blnFlag2 == blnFlag)
                {
                    FontStyle enmNewStyle = prototype.Style;
                    if (blnFlag2)
                    {
                        enmNewStyle |= FontStyle.Underline;
                    }
                    else
                    {
                        enmNewStyle &= ~FontStyle.Underline;
                    }
                    hoverLinkFont = new Font(prototype, enmNewStyle);
                    linkFont = hoverLinkFont;
                }
                else
                {
                    FontStyle enmStyle = prototype.Style;
                    if (blnFlag2)
                    {
                        enmStyle |= FontStyle.Underline;
                    }
                    else
                    {
                        enmStyle &= ~FontStyle.Underline;
                    }
                    hoverLinkFont = new Font(prototype, enmStyle);
                    FontStyle enmStyle3 = prototype.Style;
                    if (blnFlag)
                    {
                        enmStyle3 |= FontStyle.Underline;
                    }
                    else
                    {
                        enmStyle3 &= ~FontStyle.Underline;
                    }
                    linkFont = new Font(prototype, enmStyle3);
                }
            }
        }

        private static Color GetIEColor(string strName)
        {
            return Color.Red;
        }

        public static LinkBehavior GetIELinkBehavior()
        {
            return LinkBehavior.AlwaysUnderline;
        }

        #endregion Methods

        #region Properties

        public static Color IEActiveLinkColor
        {
            get
            {
                if (ieactiveLinkColor.IsEmpty)
                {
                    ieactiveLinkColor = GetIEColor("Anchor Color Hover");
                }
                return ieactiveLinkColor;
            }
        }

        public static Color IELinkColor
        {
            get
            {
                if (ielinkColor.IsEmpty)
                {
                    ielinkColor = GetIEColor("Anchor Color");
                }
                return ielinkColor;
            }
        }

        public static Color IEVisitedLinkColor
        {
            get
            {
                if (ievisitedLinkColor.IsEmpty)
                {
                    ievisitedLinkColor = GetIEColor("Anchor Color Visited");
                }
                return ievisitedLinkColor;
            }
        }

        #endregion Properties
    }

    #endregion

    #region DataGridViewCellPanel Class

    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    [Skin(typeof(DataGridViewCellPanelSkin))]
    [Serializable()]
    public class DataGridViewCellPanel : Panel
    {
        #region Members

        private int mintColspan = 0;
        private int mintRowspan = 0;
        private DataGridViewCell mobjOwnerCell;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewCellPanel"/> class.
        /// </summary>
        /// <param name="objOwner">The obj owner.</param>
        public DataGridViewCellPanel(DataGridViewCell objOwner)
        {
            mobjOwnerCell = objOwner;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets the control custom style.
        /// </summary>
        /// <value>The custom style.</value>
        /// <remarks></remarks>
        public override string CustomStyle
        {
            get
            {
                return "DataGridViewCellPanel";
            }
            set
            {
                base.CustomStyle = value;
            }
        }

        /// <summary>
        /// Gets or sets the collection of currency managers for the <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.
        /// </summary>
        /// <returns>The collection of <see cref="T:Gizmox.WebGUI.Forms.BindingManagerBase"></see> objects for this <see cref="T:Gizmox.WebGUI.Forms.IBindableComponent"></see>.</returns>
        public override BindingContext BindingContext
        {
            get
            {
                // Try getting owner cell.
                DataGridViewCell objOwnerCell = this.OwnerCell;
                if (objOwnerCell != null)
                {
                    // Try getting owner grid.
                    DataGridView objDataGridView = objOwnerCell.DataGridView;
                    if (objDataGridView != null)
                    {
                        // Get root grid
                        DataGridView objRootGrid = objDataGridView.RootGrid;
                        if (objRootGrid != null)
                        {
                            // Return root grid's BindingContext.
                            return objRootGrid.BindingContext;
                        }
                        else
                        {
                            // Return grid's BindingContext.
                            return objDataGridView.BindingContext;
                        }
                    }
                }

                return base.BindingContext;
            }
            set
            {

            }
        }

        /// <summary>
        /// Gets the owner form.
        /// </summary>
        /// <value></value>
        public override Form Form
        {
            get
            {
                // Try getting owner cell.
                DataGridViewCell objOwnerCell = this.OwnerCell;
                if (objOwnerCell != null)
                {
                    // Try getting owner grid.
                    DataGridView objDataGridView = objOwnerCell.DataGridView;
                    if (objDataGridView != null)
                    {
                        // Return grid's form.
                        return objDataGridView.Form;
                    }
                }

                return base.Form;
            }
        }
        /// <summary>
        /// Gets or sets the coll span.
        /// </summary>
        /// <value>The coll span.</value>
        internal int Colspan
        {
            get
            {
                return mintColspan;
            }
            set
            {
                if (mintColspan != value)
                {
                    mintColspan = value;

                    this.UpdateDataGridView();
                }
            }
        }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>The owner.</value>
        public DataGridViewCell OwnerCell
        {
            get
            {
                return mobjOwnerCell;
            }
        }

        /// <summary>
        /// Gets or sets the row span.
        /// </summary>
        /// <value>The row span.</value>
        internal int Rowspan
        {
            get
            {
                return mintRowspan;
            }
            set
            {
                if (mintRowspan != value)
                {
                    mintRowspan = value;

                    this.UpdateDataGridView();
                }
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Updates the data grid view.
        /// </summary>
        private void UpdateDataGridView()
        {
            // Get owner cell.
            DataGridViewCell objOwnerCell = this.OwnerCell;
            if (objOwnerCell != null)
            {
                // Validates the panel layout.
                this.ValidatePanelLayout(objOwnerCell);

                // Get owner grid
                DataGridView objDataGridView = objOwnerCell.DataGridView;
                if (objDataGridView != null)
                {
                    // Update grid.
                    objDataGridView.Update();
                }
            }
        }

        /// <summary>
        /// Validates the panel layout.
        /// </summary>
        /// <param name="objOwnerCell">The owner cell.</param>
        private void ValidatePanelLayout(DataGridViewCell objOwnerCell)
        {
            // Validate recieved arguments.
            if (objOwnerCell != null)
            {
                // Get owner grid
                DataGridView objDataGridView = objOwnerCell.DataGridView;
                if (objDataGridView != null)
                {
                    // Get row span.
                    int intRowspan = this.Rowspan;
                    if (intRowspan > 1)
                    {
                        // Get owning row.
                        DataGridViewRow objOwningRow = objOwnerCell.OwningRow;
                        if (objOwningRow != null)
                        {
                            // Check if owning row is frozen.
                            bool blnOwnedInFrozenRow = objOwningRow.Frozen;

                            // Get owning row index.
                            int intCurrentRowIndex = objOwningRow.Index;

                            // Check if paging is in use.
                            bool blnUseInternalPaging = objDataGridView.UseInternalPaging;

                            // Define an empty page rows collection.
                            IList arrPageRows = null;

                            // Loop while have rows left to validate.
                            while (intCurrentRowIndex >= 0 && intRowspan > 1)
                            {
                                // Get next visible row index.
                                intCurrentRowIndex = objDataGridView.Rows.GetNextRow(intCurrentRowIndex, DataGridViewElementStates.Visible);
                                if (intCurrentRowIndex >= 0)
                                {
                                    // Get current row.
                                    DataGridViewRow objCurrentRow = objDataGridView.Rows[intCurrentRowIndex];
                                    if (objCurrentRow != null)
                                    {
                                        // Check if paging is in use.
                                        if (blnUseInternalPaging)
                                        {
                                            // Check if page rows collection is empty.
                                            if (arrPageRows == null)
                                            {
                                                // Fill page rows collection.
                                                arrPageRows = objDataGridView.PageRows;
                                            }

                                            // Check if current row is in current page.
                                            if (!arrPageRows.Contains(objCurrentRow))
                                            {
                                                // Throw a proper exception.
                                                throw new InvalidOperationException("Cell's panel cannot be spread over several pages.");
                                            }
                                        }

                                        // Check if forzen value of owning row is different from current row.
                                        if (objCurrentRow.Frozen != blnOwnedInFrozenRow)
                                        {
                                            // Throw a proper exception.
                                            throw new InvalidOperationException("Cell's panel cannot be partially frozen.");
                                        }
                                    }
                                    else
                                    {
                                        // Throw a proper exception.
                                        throw new ArgumentOutOfRangeException("Rowspan");
                                    }
                                }

                                // Decrease row span.
                                intRowspan--;
                            }
                        }
                    }

                    // Get column span.
                    int intColspan = this.Colspan;
                    if (intColspan > 1)
                    {
                        // Get owning column.
                        DataGridViewColumn objOwningColumn = objOwnerCell.OwningColumn;
                        if (objOwningColumn != null)
                        {
                            // Check if owning column is frozen.
                            bool blnOwnedInFrozenColumn = objOwningColumn.Frozen;

                            // Get owning column index.
                            DataGridViewColumn objCurrentColumn = objOwningColumn;

                            // Loop while have column left to validate.
                            while (objCurrentColumn != null && intColspan > 1)
                            {
                                // Get next visible column.
                                objCurrentColumn = objDataGridView.Columns.GetNextColumn(objCurrentColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                                if (objCurrentColumn != null)
                                {
                                    // Check if forzen value of owning column is different from current column.
                                    if (objCurrentColumn.Frozen != blnOwnedInFrozenColumn)
                                    {
                                        // Throw a proper exception.
                                        throw new InvalidOperationException("Cell's panel cannot be partially frozen.");
                                    }
                                }
                                else
                                {
                                    // Throw a proper exception.
                                    throw new ArgumentOutOfRangeException("Colpan");
                                }

                                // Decrease column span.
                                intColspan--;
                            }
                        }
                    }
                }
            }
        }

        #region Render

        /// <summary>
        /// An abstract control method rendering
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void Render(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            this.ValidatePanelLayout(this.OwnerCell);

            base.Render(objContext, objWriter, lngRequestID);
        }

        /// <summary>
        /// Renders the docking.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="enmDockStyle">The dock style.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        protected override void RenderDocking(IContext objContext, IAttributeWriter objWriter, DockStyle enmDockStyle, bool blnForceRender)
        {
            objWriter.WriteAttributeString(WGAttributes.Docking, "F");
        }

        /// <summary>
        /// Renders the anchoring.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="objWriter">The writer.</param>
        /// <param name="enmAnchorStyle">The anchor style.</param>
        /// <param name="blnForceEmptyRender">if set to <c>true</c> [BLN force empty render].</param>
        protected override void RenderAnchoring(IContext objContext, IAttributeWriter objWriter, AnchorStyles enmAnchorStyle, bool blnForceEmptyRender)
        {
        }

        /// <summary>
        /// Renders the scrollable attribute
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Render colspan attribute - if needed.
            int intColspan = this.Colspan;
            if (intColspan > 0)
            {
                objWriter.WriteAttributeString(WGAttributes.Colspan, intColspan.ToString());
            }

            // Render rowspan attribute - if needed.
            int intRowspan = this.Rowspan;
            if (intRowspan > 0)
            {
                objWriter.WriteAttributeString(WGAttributes.Rowspan, intRowspan.ToString());
            }
        }

        /// <summary>
        /// Gets the key event captures for DataGridViewCellPanel.
        /// The DataGridViewCellPanel is a "stopper" for all key events to prevent the DataGrid from handling these events
        /// </summary>
        /// <returns></returns>
        protected override KeyCaptures GetKeyEventCaptures()
        {
            return Gizmox.WebGUI.Forms.KeyCaptures.All;
        }

        #endregion

        #endregion Methods

        /// <summary>
        /// Prerender component.
        /// </summary>
        /// <param name="objContext">The context.</param>
        /// <param name="lngRequestID">The request ID.</param>
        internal void PreRenderComponent(IContext objContext, long lngRequestID)
        {
            this.PreRenderControl(objContext, lngRequestID);
        }
    }

    #endregion

    #region DataGridViewFilterButton class

    /// <summary>
    /// 
    /// </summary>
    [ToolboxItem(false)]
    [Serializable(), Skin(typeof(DataGridViewFilterButtonSkin))]
    public class DataGridViewFilterButton : Button
    {
        /// <summary>
        /// Gets or sets the control custom style.
        /// </summary>
        public override string CustomStyle
        {
            get
            {
                return "DataGridViewFilterButton";
            }
            set
            {
                base.CustomStyle = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [supports key navigation].
        /// </summary>
        /// <value>
        /// <c>true</c> if [supports key navigation]; otherwise, <c>false</c>.
        /// </value>
        protected override bool SupportsKeyNavigation
        {
            get
            {
                return true;
            }
        }
    }

    #endregion

    #region DataGridViewGroupingTreeView class

    /// <summary>
    /// Summary description for GroupingTreeView
    /// </summary>
    [Serializable()]
    [Skin(typeof(DataGridViewGroupingTreeViewSkin))]
    [ToolboxItem(false)]
    internal class DataGridViewGroupingTreeView : TreeView
    {

        #region Members

        private DataGridView mobjOwningDataGridView;

        #endregion Members

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewGroupingTreeView"/> class.
        /// </summary>
        internal DataGridViewGroupingTreeView(DataGridView objOwningDataGridView)
        {
            // Initialize members.
            this.mobjOwningDataGridView = objOwningDataGridView;

            // Set properties.
            this.CustomStyle = "GroupingTreeView";
            this.Dock = DockStyle.Fill;
            this.AllowDrop = true;
            this.Scrollable = true;

            // Create nodes hierarchy.
            InitializeGroupingNodes();
        }

        #endregion C'tors

        #region Methods

        /// <summary>
        /// Initializes the grouping nodes.
        /// </summary>
        internal void InitializeGroupingNodes()
        {
            if (this.mobjOwningDataGridView != null)
            {
                // Clear nodes.
                this.Nodes.Clear();

                // Build nodes hierarchy from grouping columns.
                AttachChildNode(0, null);

                // Always expand nodes.
                this.ExpandAll();

                this.Update();
            }
        }

        /// <summary>
        /// Fires an event.
        /// </summary>
        /// <param name="objEvent">event.</param>
        protected override void FireEvent(IEvent objEvent)
        {
            switch (objEvent.Type)
            {
                case "CloseGroup":
                    // Get column name.
                    string strColumnDataPropertyName = objEvent[WGAttributes.Name];

                    if (!string.IsNullOrEmpty(strColumnDataPropertyName))
                    {
                        // Remove from GroupingColumns.
                        this.mobjOwningDataGridView.GroupingColumns.Remove(strColumnDataPropertyName);

                        // Fire GroupingChanged of owner grid.
                        this.mobjOwningDataGridView.OnGroupingChanged(DataGridViewGroupingAction.Remove, strColumnDataPropertyName);
                    }
                    break;
            }
            base.FireEvent(objEvent);
        }

        /// <summary>
        /// Attaches the child node to the parent -- builds treeview nodes hierearchy recursively.
        /// </summary>
        /// <param name="intGroupingColumnIndex">Index of the int grouping column.</param>
        /// <param name="objParentNode">The obj parent node.</param>
        private void AttachChildNode(int intGroupingColumnIndex, DataGridViewGroupingTreeNode objParentNode)
        {
            if (this.mobjOwningDataGridView.GroupingColumns.Count > 0)
            {
                // Get current grouping column data property name and its ID.
                string strCurrentColumnDataPropertyName = this.mobjOwningDataGridView.GroupingColumns[intGroupingColumnIndex];
                string strColumnName = this.mobjOwningDataGridView.Columns.GetRealDataMemberForProposedMember(strCurrentColumnDataPropertyName);
                string strHeaderText = null;

                if (this.mobjOwningDataGridView.Columns[strColumnName] != null)
                {
                    strHeaderText = this.mobjOwningDataGridView.Columns[strColumnName].HeaderText;
                }

                if (!string.IsNullOrEmpty(strColumnName) && !string.IsNullOrEmpty(strHeaderText))
                {
                    // Create new child node.
                    DataGridViewGroupingTreeNode objNewChildNode = new DataGridViewGroupingTreeNode(strHeaderText);
                    objNewChildNode.Tag = strCurrentColumnDataPropertyName;

                    // Attach it to parent node, if exists.
                    if (objParentNode != null)
                    {
                        objParentNode.Nodes.Add(objNewChildNode);
                    }

                    // Otherwise, attach it to the treeview (root node).
                    else
                    {
                        this.Nodes.Add(objNewChildNode);
                    }

                    // If there are more grouping columns, attach more nodes, recursively.
                    if (intGroupingColumnIndex + 1 < this.mobjOwningDataGridView.GroupingColumns.Count)
                    {
                        AttachChildNode(intGroupingColumnIndex + 1, objNewChildNode);
                    }
                }
            }
        }

        /// <summary>
        /// Renders the controls sub tree
        /// </summary>
        /// <param name="objContext">Request context.</param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected override void RenderControls(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            // add all child nodes
            foreach (DataGridViewGroupingTreeNode objNode in Nodes)
            {
                // Render the node
                objNode.RenderNode(objContext, objWriter, lngRequestID, this.CheckBoxes ? CheckBoxVisibility.True : CheckBoxVisibility.False);
            }
        }


        #endregion Methods
    }

    #endregion DataGridViewGroupingTreeView class

    #region DataGridViewGroupingTreeNode class

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    internal class DataGridViewGroupingTreeNode : TreeNode
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewGroupingTreeNode"/> class.
        /// </summary>
        /// <param name="strColumnDataPropertyName">The data property name of column represented by node.</param>
        public DataGridViewGroupingTreeNode(string strColumnDataPropertyName)
            : base(strColumnDataPropertyName)
        {
        }

        /// <summary>
        /// Renders the node attributes.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderNodeAttributes(IContext objContext, IResponseWriter objWriter)
        {
            base.RenderNodeAttributes(objContext, objWriter);

            // Render column data property name represented by node.
            if (this.Tag != null && !string.IsNullOrEmpty(this.Tag.ToString()))
            {
                objWriter.WriteAttributeString(WGAttributes.Name, this.Tag.ToString());
            }
        }
    }

    #endregion

    #region DataGridViewSystemFilterOption class

    /// <summary>
    /// Represents DataGridView filter ComboBox system option entry as "(All)", "(Blanks)", etc.
    /// </summary>
    [Serializable]
    public class DataGridViewSystemFilterOption
    {
        private SystemFilterOptions menmOption;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewSystemFilterOption"/> class.
        /// </summary>
        /// <param name="enmOption">The enm option.</param>
        public DataGridViewSystemFilterOption(SystemFilterOptions enmOption)
        {
            menmOption = enmOption;
        }

        /// <summary>
        /// Gets the option.
        /// </summary>
        public SystemFilterOptions Option
        {
            get
            {
                return menmOption;
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return SR.GetString(string.Format("DataGridViewFilterComboBoxOption_" + menmOption));
        }
    }

    #endregion

    #region CustomFilterAppliedEventArgs class

    /// <summary>
    /// Represents CustomFilterApplied event arguments.
    /// </summary>
    [Serializable()]
    public class CustomFilterApplyingEventArgs : EventArgs
    {
        #region Members

        private DataGridViewColumn mobjFilteredColumn;

        #endregion Members

        #region Properties

        /// <summary>
        /// Gets the owning column.
        /// </summary>
        public DataGridViewColumn FilteredColumn
        {
            get
            {
                return mobjFilteredColumn;
            }
        }

        #endregion Properties

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFilterApplyingEventArgs"/> class.
        /// </summary>
        /// <param name="objOwningColumn">The obj owning column.</param>
        public CustomFilterApplyingEventArgs(DataGridViewColumn objOwningColumn)
        {
            mobjFilteredColumn = objOwningColumn;
        }

        #endregion C'tors
    }

    #endregion


    /// <summary>
    /// 
    /// </summary>
    /// <param name="objSender">The obj sender.</param>
    /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.CustomFilterApplyingEventArgs"/> instance containing the event data.</param>
    public delegate void CustomFilterApplyingEventHandler(object objSender, CustomFilterApplyingEventArgs objArgs);

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public enum ShowExpansionIndicator
    {
        /// <summary>
        /// Always display
        /// </summary>
        Always = 1,
        /// <summary>
        /// Never display
        /// </summary>
        Never = 2,
        /// <summary>
        /// Check before display
        /// </summary>
        [Obsolete("Not implemented. Added for migration compatibility"), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        CheckOnDisplay = 3,
        /// <summary>
        /// Check before expand (default)
        /// </summary>
        CheckOnExpand = 4,

        /// <summary>
        /// Show empty
        /// </summary>
        Empty = 5,
    }

    /// <summary>
    /// Represents DataGridView filter ComboBox system options
    /// </summary>
    public enum SystemFilterOptions
    {
        /// <summary>
        /// No filter applied.
        /// </summary>
        All,

        /// <summary>
        /// Show only blank values.
        /// </summary>
        Blanks,

        /// <summary>
        /// Show only non-blank values.
        /// </summary>
        NonBlanks,

        /// <summary>
        /// Custom filter provided.
        /// </summary>
        Custom
    }

    #region DataGridViewCustomFilterDialog class

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public class DataGridViewCustomFilterDialog : Form
    {
        #region Members

        private Label mobjLabelFilterMessage;
        private ComboBox mobjComboBoxOperatorA;
        private DataGridViewFilterComboBoxBase mobjComboBoxValueA;
        private RadioButton mobjRadioButtonAnd;
        private RadioButton mobjRadioButtonOr;
        private ComboBox mobjComboBoxOperatorB;
        private DataGridViewFilterComboBoxBase mobjComboBoxValueB;
        private Button mobjButtonCancel;
        private Button mobjButtonOK;

        private DataGridViewColumn mobjDataGridViewColumn = null;
        private DataGridViewCell mobjDataGridViewCell = null;
        private DataGridView mobjDataGridView = null;

        #endregion Members

        #region C'tors / D'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewCustomFilterDialog"/> class.
        /// </summary>
        public DataGridViewCustomFilterDialog(DataGridViewCell objDataGridViewCell)
        {
            if (objDataGridViewCell == null)
            {
                throw new ArgumentNullException("objDataGridViewCell");
            }

            mobjDataGridViewCell = objDataGridViewCell;
            mobjDataGridViewColumn = objDataGridViewCell.OwningColumn;
            mobjDataGridView = mobjDataGridViewColumn.DataGridView;

            InitializeComponent();

            this.mobjLabelFilterMessage.Text = SR.GetString("FilterMessage", new object[] { mobjDataGridViewColumn.HeaderText });
            this.Text = SR.GetString("CustomFilterColon");
            this.mobjButtonCancel.Text = WGLabels.Cancel;
            this.mobjButtonOK.Text = WGLabels.Ok;
            this.mobjRadioButtonAnd.Text = SR.GetString("And");
            this.mobjRadioButtonOr.Text = SR.GetString("Or");


            mobjComboBoxValueA.InitializeFilterValues(false, false, true);
            mobjComboBoxValueB.InitializeFilterValues(false, false, true);

            // Add empty item
            mobjComboBoxOperatorB.Items.Add("");

            // Add comparision operator
            List<FilterComparisonOperator> arrFilterComparisionOperator = DataGridViewFilterCell.DataGridViewFilterControl.GetFilterComparisonOperator(mobjDataGridViewColumn.ValueType);
            foreach (FilterComparisonOperator enmFilterComparisionOperator in arrFilterComparisionOperator)
            {
                string strOperator = SR.GetString(string.Format("FilterComparisionOperator_{0}", enmFilterComparisionOperator.ToString()));
                mobjComboBoxOperatorA.Items.Add(new FilterOperatorItem(enmFilterComparisionOperator, strOperator));
                mobjComboBoxOperatorB.Items.Add(new FilterOperatorItem(enmFilterComparisionOperator, strOperator));
            }

            if (mobjComboBoxOperatorA.Items.Count > 0)
            {
                mobjComboBoxOperatorA.SelectedIndex = 0;
            }
        }

        #endregion C'tors / D'tors

        #region Methods

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mobjLabelFilterMessage = new Gizmox.WebGUI.Forms.Label();
            this.mobjComboBoxOperatorA = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjComboBoxValueA = new Gizmox.WebGUI.Forms.DataGridViewFilterComboBoxBase(mobjDataGridView, mobjDataGridViewColumn, mobjDataGridViewCell);
            this.mobjRadioButtonAnd = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjRadioButtonOr = new Gizmox.WebGUI.Forms.RadioButton();
            this.mobjComboBoxOperatorB = new Gizmox.WebGUI.Forms.ComboBox();
            this.mobjComboBoxValueB = new Gizmox.WebGUI.Forms.DataGridViewFilterComboBoxBase(mobjDataGridView, mobjDataGridViewColumn, mobjDataGridViewCell);
            this.mobjButtonCancel = new Gizmox.WebGUI.Forms.Button();
            this.mobjButtonOK = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // mobjLabelFilterMessage
            // 
            this.mobjLabelFilterMessage.AutoSize = true;
            this.mobjLabelFilterMessage.Location = new System.Drawing.Point(6, 8);
            this.mobjLabelFilterMessage.Name = "mobjLabelFilterMessage";
            this.mobjLabelFilterMessage.Size = new System.Drawing.Size(35, 13);
            this.mobjLabelFilterMessage.TabIndex = 0;
            this.mobjLabelFilterMessage.Text = "Show rows where \'{0}\' :";
            // 
            // mobjComboBoxOperatorA
            // 
            this.mobjComboBoxOperatorA.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjComboBoxOperatorA.FormattingEnabled = true;
            this.mobjComboBoxOperatorA.Location = new System.Drawing.Point(9, 34);
            this.mobjComboBoxOperatorA.Name = "mobjComboBoxOperatorA";
            this.mobjComboBoxOperatorA.Size = new System.Drawing.Size(153, 21);
            this.mobjComboBoxOperatorA.TabIndex = 1;
            // 
            // mobjComboBoxValueA
            // 
            this.mobjComboBoxValueA.FormattingEnabled = true;
            this.mobjComboBoxValueA.Location = new System.Drawing.Point(208, 34);
            this.mobjComboBoxValueA.Name = "mobjComboBoxValueA";
            this.mobjComboBoxValueA.Size = new System.Drawing.Size(153, 21);
            this.mobjComboBoxValueA.TabIndex = 2;
            // 
            // mobjRadioButtonAnd
            // 
            this.mobjRadioButtonAnd.AutoSize = true;
            this.mobjRadioButtonAnd.Location = new System.Drawing.Point(9, 67);
            this.mobjRadioButtonAnd.Name = "mobjRadioButtonAnd";
            this.mobjRadioButtonAnd.Size = new System.Drawing.Size(44, 17);
            this.mobjRadioButtonAnd.TabIndex = 3;
            this.mobjRadioButtonAnd.Checked = true;
            this.mobjRadioButtonAnd.Text = "And";
            // 
            // mobjRadioButtonOr
            // 
            this.mobjRadioButtonOr.AutoSize = true;
            this.mobjRadioButtonOr.Location = new System.Drawing.Point(91, 67);
            this.mobjRadioButtonOr.Name = "mobjRadioButtonOr";
            this.mobjRadioButtonOr.Size = new System.Drawing.Size(37, 17);
            this.mobjRadioButtonOr.TabIndex = 4;
            this.mobjRadioButtonOr.Text = "Or";
            // 
            // mobjComboBoxOperatorB
            // 
            this.mobjComboBoxOperatorB.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.mobjComboBoxOperatorB.FormattingEnabled = true;
            this.mobjComboBoxOperatorB.Location = new System.Drawing.Point(9, 96);
            this.mobjComboBoxOperatorB.Name = "mobjComboBoxOperatorB";
            this.mobjComboBoxOperatorB.Size = new System.Drawing.Size(153, 21);
            this.mobjComboBoxOperatorB.TabIndex = 5;
            // 
            // mobjComboBoxValueB
            // 
            this.mobjComboBoxValueB.FormattingEnabled = true;
            this.mobjComboBoxValueB.Location = new System.Drawing.Point(208, 96);
            this.mobjComboBoxValueB.Name = "mobjComboBoxValueB";
            this.mobjComboBoxValueB.Size = new System.Drawing.Size(153, 21);
            this.mobjComboBoxValueB.TabIndex = 6;
            // 
            // mobjButtonCancel
            // 
            this.mobjButtonCancel.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Cancel;
            this.mobjButtonCancel.Location = new System.Drawing.Point(286, 143);
            this.mobjButtonCancel.Name = "mobjButtonCancel";
            this.mobjButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.mobjButtonCancel.TabIndex = 7;
            this.mobjButtonCancel.Text = "Cancel";
            this.mobjButtonCancel.Click += new System.EventHandler(this.mobjButtonCancel_Click);
            // 
            // mobjButtonOK
            // 
            this.mobjButtonOK.Location = new System.Drawing.Point(186, 143);
            this.mobjButtonOK.Name = "mobjButtonOK";
            this.mobjButtonOK.Size = new System.Drawing.Size(75, 23);
            this.mobjButtonOK.TabIndex = 8;
            this.mobjButtonOK.Text = "OK";
            this.mobjButtonOK.Click += new System.EventHandler(this.mobjButtonOK_Click);
            // 
            // DataGridViewCustomFilter
            // 
            this.AcceptButton = this.mobjButtonOK;
            this.CancelButton = this.mobjButtonCancel;
            this.Controls.Add(this.mobjButtonOK);
            this.Controls.Add(this.mobjButtonCancel);
            this.Controls.Add(this.mobjComboBoxValueB);
            this.Controls.Add(this.mobjComboBoxOperatorB);
            this.Controls.Add(this.mobjRadioButtonAnd);
            this.Controls.Add(this.mobjRadioButtonOr);
            this.Controls.Add(this.mobjComboBoxValueA);
            this.Controls.Add(this.mobjComboBoxOperatorA);
            this.Controls.Add(this.mobjLabelFilterMessage);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedToolWindow;
            this.Size = new System.Drawing.Size(376, 176);
            this.Text = "Custom Filter:";
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// Handles the Click event of the mobjButtonCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the mobjButtonOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mobjButtonOK_Click(object sender, EventArgs e)
        {
            if (ValidateValues())
            {
                this.DialogResult = Gizmox.WebGUI.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(SR.GetString("InvalidFilterMessage"), SR.GetString("CustomFilter"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Validates the values.
        /// </summary>
        /// <returns></returns>
        private bool ValidateValues()
        {
            // Filter A values should be filled
            if ((mobjComboBoxOperatorA.SelectedIndex < 0 || string.IsNullOrEmpty(mobjComboBoxValueA.Text)) || (mobjComboBoxOperatorB.SelectedIndex > 0 && string.IsNullOrEmpty(mobjComboBoxValueB.Text)))
            {
                return false;
            }

            // Validate values
            if (!mobjComboBoxValueA.IsValidValue() || (mobjComboBoxOperatorB.SelectedIndex > 0 && !mobjComboBoxValueB.IsValidValue()))
            {
                return false;
            }

            return true;
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets the column.
        /// </summary>
        internal DataGridViewColumn Column
        {
            get
            {
                return mobjDataGridViewColumn;
            }
        }

        /// <summary>
        /// Gets the cell.
        /// </summary>
        internal DataGridViewCell Cell
        {
            get
            {
                return mobjDataGridViewCell;
            }
        }

        /// <summary>
        /// Gets the value A.
        /// </summary>
        internal string ValueA
        {
            get
            {
                return mobjComboBoxValueA.Text;
            }
        }


        /// <summary>
        /// Gets the value B.
        /// </summary>
        internal string ValueB
        {
            get
            {
                return mobjComboBoxValueB.Text;
            }
        }

        /// <summary>
        /// Gets the operator A.
        /// </summary>
        internal FilterComparisonOperator OperatorA
        {
            get
            {
                FilterOperatorItem objItem = mobjComboBoxOperatorA.SelectedItem as FilterOperatorItem;

                if (objItem != null)
                {
                    return objItem.Operator;
                }

                return FilterComparisonOperator.None;
            }
        }

        /// <summary>
        /// Gets the operator B.
        /// </summary>
        internal FilterComparisonOperator OperatorB
        {
            get
            {
                FilterOperatorItem objItem = mobjComboBoxOperatorB.SelectedItem as FilterOperatorItem;

                if (objItem != null)
                {
                    return objItem.Operator;
                }

                return FilterComparisonOperator.None;
            }
        }

        /// <summary>
        /// Gets the filters relation.
        /// </summary>
        internal string FiltersRelation
        {
            get
            {
                if (mobjRadioButtonAnd.Checked)
                {
                    return "AND";
                }
                else
                {
                    return "OR";
                }
            }
        }

        #endregion Properties

        #region FilterOperatorItem

        [Serializable()]
        private class FilterOperatorItem
        {
            private string mstrText = string.Empty;
            private FilterComparisonOperator menmFilterComparisionOperator;
            public FilterOperatorItem(FilterComparisonOperator enmFilterComparisionOperator, string strText)
            {
                menmFilterComparisionOperator = enmFilterComparisionOperator;
                mstrText = strText;
            }

            /// <summary>
            /// Gets the text.
            /// </summary>
            public string Text
            {
                get
                {
                    return mstrText;
                }
            }

            /// <summary>
            /// Gets the operator.
            /// </summary>
            public FilterComparisonOperator Operator
            {
                get
                {
                    return menmFilterComparisionOperator;
                }
            }


            /// <summary>
            /// Returns a <see cref="System.String"/> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String"/> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return mstrText;
            }
        }

        #endregion FilterOperatorItem
    }

    #endregion DataGridViewCustomFilterDialog class

    #region HeaderFilterInfo class

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [TypeConverter(typeof(HeaderFilterInfoConverter))]
    public class HeaderFilterInfo
    {

        #region Members

        private string mstrDataPropertyName = string.Empty;
        private bool mblnIsCustomFilter = false;

        #endregion Members

        #region C'tors / D'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderFilterInfo"/> class.
        /// </summary>
        public HeaderFilterInfo()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderFilterInfo"/> class.
        /// </summary>
        /// <param name="strDataPropertyName">Name of the STR data property.</param>
        /// <param name="blnIsCustomFilter">if set to <c>true</c> [BLN is custom filter].</param>
        public HeaderFilterInfo(string strDataPropertyName, bool blnIsCustomFilter)
        {
            if (string.IsNullOrEmpty(strDataPropertyName))
            {
                throw new ArgumentNullException("DataPropertyName");
            }
            mstrDataPropertyName = strDataPropertyName;
            mblnIsCustomFilter = blnIsCustomFilter;
        }

        #endregion C'tors / D'tors

        #region Properties


        /// <summary>
        /// Gets or sets the name of the data property.
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
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("DataPropertyName");
                }
                mstrDataPropertyName = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is custom filter.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is custom filter; otherwise, <c>false</c>.
        /// </value>
        public bool IsCustomFilter
        {
            get
            {
                return mblnIsCustomFilter;
            }
            set
            {
                mblnIsCustomFilter = value;
            }
        }

        #endregion Properties
    }

    #endregion HeaderFilterInfo class

    #region HeaderFilterInfoConverter class

    /// <summary>
    /// 
    /// </summary>
    public class HeaderFilterInfoConverter : TypeConverter
    {
        /// <summary>
        /// Returns whether this converter can convert the object to the specified type, using the specified context.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="destinationType">A <see cref="T:System.Type"/> that represents the type you want to convert to.</param>
        /// <returns>
        /// true if this converter can perform the conversion; otherwise, false.
        /// </returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                return true;
            }

            return base.CanConvertTo(context, destinationType);
        }

        /// <summary>
        /// Converts the given value object to the specified type, using the specified context and culture information.
        /// </summary>
        /// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext"/> that provides a format context.</param>
        /// <param name="culture">A <see cref="T:System.Globalization.CultureInfo"/>. If null is passed, the current culture is assumed.</param>
        /// <param name="value">The <see cref="T:System.Object"/> to convert.</param>
        /// <param name="destinationType">The <see cref="T:System.Type"/> to convert the <paramref name="value"/> parameter to.</param>
        /// <returns>
        /// An <see cref="T:System.Object"/> that represents the converted value.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">
        /// The <paramref name="destinationType"/> parameter is null.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// The conversion cannot be performed.
        /// </exception>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor) && value is HeaderFilterInfo)
            {
                HeaderFilterInfo objHeaderFilterInfo = (HeaderFilterInfo)value;

                ConstructorInfo objConstructorInfo = objHeaderFilterInfo.GetType().GetConstructor(new Type[] { typeof(string), typeof(bool) });
                if (objConstructorInfo != null)
                {
                    return new InstanceDescriptor(objConstructorInfo, new object[] { objHeaderFilterInfo.DataPropertyName, objHeaderFilterInfo.IsCustomFilter });
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    #endregion HeaderFilterInfoConverter class

}
