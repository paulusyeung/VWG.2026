#region Using

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Globalization;
using System.Text;
using Gizmox.WebGUI.Common.Interfaces;
using System.ComponentModel.Design;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.Common.Resources;
using System.Reflection;

#endregion

namespace Gizmox.WebGUI.Forms
{
    #region DataGridViewColumn Class

    /// <summary>Represents a column in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control.</summary>
    /// <filterpriority>2</filterpriority>
    [TypeConverter(typeof(Gizmox.WebGUI.Forms.DataGridViewColumnConverter)), ToolboxItem(false), DesignTimeVisible(false)]

#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewColumnController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewColumnController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [Serializable()]
    public class DataGridViewColumn : DataGridViewBand, IComponent, IDisposable
    {
        private Type mobjValueType = null;

        private ISite mobjSite;


        private string mstrName;


        private byte mobjFlags;
        private string mstrDataPropertyName;
        private int mintDesiredMinimumWidth;
        private int mintDesiredFillWidth;
        private DataGridViewCell mobjCellTemplate;
        private int mintBoundColumnIndex;
        private DataGridViewAutoSizeColumnMode menmAutoSizeMode;
        private float mfltFillWeight;
        private float mfltUsedFillWeight;
        private int mintDisplayIndex;
        private bool mblnIsExcludedFromColumnChooser;
        private string mstrClientId = string.Empty;
        private bool mblnCanGroupBy = true;
        private bool mblnShowHeaderFilter = false;
        internal string mstrCustomFilterExpression = string.Empty;

        #region Members

        [NonSerialized]
        private TypeConverter mobjBoundColumnConverter;

        private bool mblnAllowRowFiltering = true;

        #region Events

        /// <summary>Occurs when the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> is disposed.</summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public event EventHandler Disposed;

        /// <summary>
        /// Occurs when [allow row filtering changed].
        /// </summary>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public event EventHandler AllowRowFilteringChanged;

        #endregion

        #region Constants

        private const byte DATAGRIDVIEWCOLUMN_automaticSort = 1;
        private const float DATAGRIDVIEWCOLUMN_defaultFillWeight = 100f;
        private const int DATAGRIDVIEWCOLUMN_defaultMinColumnThickness = 5;
        private const int DATAGRIDVIEWCOLUMN_defaultWidth = 100;
        private const byte DATAGRIDVIEWCOLUMN_displayIndexHasChangedInternal = 0x10;
        private const byte DATAGRIDVIEWCOLUMN_isBrowsableInternal = 8;
        private const byte DATAGRIDVIEWCOLUMN_isDataBound = 4;
        private const byte DATAGRIDVIEWCOLUMN_programmaticSort = 2;

        protected const string TextTypeName = "1";
        protected const string CheckBoxTypeName = "2";
        protected const string ImageTypeName = "3";
        protected const string LinkTypeName = "4";
        protected const string ButtonTypeName = "5";
        protected const string ComboBoxTypeName = "6";

        #endregion

        #endregion

        /// <summary>
        /// Initializes the <see cref="DataGridViewColumn"/> class.
        /// </summary>
        static DataGridViewColumn()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> class to the default state.
        /// </summary>
        public DataGridViewColumn()
            : this(null)
        {
            this.TagName = WGTags.DataGridViewColumn;
        }

        /// <summary>
        /// Gets or sets a value indicating whether [allowed row filtering].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allowed row filtering]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        public virtual bool AllowRowFiltering
        {
            get
            {
                return mblnAllowRowFiltering;
            }

            set
            {
                if (this.AllowRowFilteringInternal != value)
                {
                    this.AllowRowFilteringInternal = value;

                    if (AllowRowFilteringChanged != null)
                    {
                        AllowRowFilteringChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        /// <summary>
        /// Sets a value indicating whether [row filtering is allowed internally].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [row filtering is allowed internally]; otherwise, <c>false</c>.
        /// </value>
        internal bool AllowRowFilteringInternal
        {
            get
            {
                return this.mblnAllowRowFiltering;
            }
            set
            {
                this.mblnAllowRowFiltering = value;
            }
        }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        protected virtual string TypeName
        {
            get
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the type name internal.
        /// </summary>
        /// <value>The type name internal.</value>
        internal string TypeNameInternal
        {
            get
            {
                return this.TypeName;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is excluded from column chooser.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is excluded from column chooser; otherwise, <c>false</c>.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsExcludedFromColumnChooser
        {
            get 
            {
                return mblnIsExcludedFromColumnChooser; 
            }
            set 
            {
                mblnIsExcludedFromColumnChooser = value; 
            }
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> class using an existing <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> as a template.</summary>
        /// <param name="objCellTemplate">An existing <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> to use as a template. </param>
        public DataGridViewColumn(DataGridViewCell objCellTemplate)
        {
            this.TagName = WGTags.DataGridViewColumn;

            this.BoundColumnIndex = -1;
            this.DataPropertyName = string.Empty;
            this.mfltFillWeight = 100f;
            this.mfltUsedFillWeight = 100f;
            base.Thickness = 100;
            base.MinimumThickness = 5;
            base.BandIsRow = false;
            this.mstrName = string.Empty;
            this.mintDisplayIndex = -1;
            this.CellTemplate = objCellTemplate;
            this.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;

            //create heder cell for future rendering
            DataGridViewColumnHeaderCell objDataGridViewColumnHeaderCell = this.HeaderCell;
        }

        /// <summary>
        /// Gets the member ID.
        /// </summary>
        /// <value>The member ID.</value>
        protected override string MemberID
        {
            get
            {
                return "C" + this.Index.ToString();
            }
        }

        /// <summary>
        /// Gets the member ID internal.
        /// </summary>
        /// <value>The member ID internal.</value>
        new internal string MemberIDInternal
        {
            get
            {
                return this.MemberID;
            }
        }

        /// <summary>
        /// Sets the fill weight internal.
        /// </summary>
        /// <value>The fill weight internal.</value>
        internal float FillWeightInternal
        {
            set
            {
                this.mfltFillWeight = value;
            }
        }

        /// <summary>
        /// Renders the column's inner components
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

            // Try to get column's HeaderFilterInfo
            HeaderFilterInfo objHeaderFilterInfo = this.DataGridView.GetColumnHeaderInfo(this);

            // If we didnt find HeaderFilterInfo, set ShowHeaderFilter to false.
            if (objHeaderFilterInfo == null)
            {
                this.ShowHeaderFilter = false;
            }
            else
            {
                // Set ShowHeaderFilter to true.
                this.ShowHeaderFilter = true;

                // Update IsCustomFilter value
                this.IsCustomFilter = objHeaderFilterInfo.IsCustomFilter;
            }

            // Get header cell.
            DataGridViewColumnHeaderCell objDataGridViewColumnHeaderCell = this.HeaderCell;
            if (objDataGridViewColumnHeaderCell != null)
            {
                // Pre render header cell.
                objDataGridViewColumnHeaderCell.PreRenderComponent(objContext, lngRequestID, blnForcePreRender);
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
            base.PreRenderComponent(objContext, lngRequestID, blnForcePostRender);

            // Get header cell.
            DataGridViewColumnHeaderCell objDataGridViewColumnHeaderCell = this.HeaderCell;
            if (objDataGridViewColumnHeaderCell != null)
            {
                // Post render header cell.
                objDataGridViewColumnHeaderCell.PostRenderComponent(objContext, lngRequestID, blnForcePostRender);
            }
        }

        /// <summary>
        /// Renders the DataGridViewColumn attributes
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="blnRenderOwner"></param>
        protected override void RenderAttributes(Gizmox.WebGUI.Common.Interfaces.IContext objContext, Gizmox.WebGUI.Common.Interfaces.IAttributeWriter objWriter, bool blnRenderOwner)
        {
            base.RenderAttributes(objContext, objWriter, blnRenderOwner);

            // Render the name of the data property.
            RenderDataPropertyName(objWriter);

            objWriter.WriteAttributeString(WGAttributes.Width, this.Width.ToString());

            if (this.DataGridView.ShowCellToolTips &&
                this.ToolTipText != null &&
                this.ToolTipText != string.Empty)
            {
                objWriter.WriteAttributeText(WGAttributes.ToolTip, this.ToolTipText);
            }

            objWriter.WriteAttributeString(WGAttributes.Type, this.TypeName);

            if (this.Resizable == DataGridViewTriState.False
                || (this.AutoSizeMode != DataGridViewAutoSizeColumnMode.None 
                    && this.DataGridView.AutoSizeColumnsMode != DataGridViewAutoSizeColumnsMode.Fill 
                    && this.DataGridView.AutoSizeColumnsMode != DataGridViewAutoSizeColumnsMode.None))
            {
                objWriter.WriteAttributeString(WGAttributes.Resize, "0");
            }
            string strClientId = this.ClientId;

            if (!string.IsNullOrEmpty(strClientId))
            {
                objWriter.WriteAttributeString(WGAttributes.ClientId, strClientId);
            }

            // Renders the can group by attribute.
            RenderCanGroupByAttribute(objWriter, false);
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

            if (IsDirtyAttributes(lngRequestID, AttributeType.Control))
            {
                // Render the name of the data property.
                RenderDataPropertyName(objWriter);

                // Renders the can group by attribute.
                RenderCanGroupByAttribute(objWriter, true);
            }

            if (IsDirtyAttributes(lngRequestID, AttributeType.Layout))
            {
                objWriter.WriteAttributeString(WGAttributes.Width, this.Width.ToString());
            }
        }

        /// <summary>
        /// Renders the can group by attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderCanGroupByAttribute(IAttributeWriter objWriter, bool blnForceRender)
        {
            if (!mblnCanGroupBy || blnForceRender)
            {
                objWriter.WriteAttributeString(WGAttributes.CanGroupBy, mblnCanGroupBy ? "1" : "0");
            }
        }

        /// <summary>
        /// Renders the name of the data property.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [p].</param>
        private void RenderDataPropertyName(IAttributeWriter objWriter)
        {
            if (!string.IsNullOrEmpty(this.DataPropertyName))
            {
                objWriter.WriteAttributeText(WGAttributes.Name, this.DataPropertyName);
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
                if (this.DataGridView.IsCriticalEvent(DataGridView.EVENT_DATAGRIDVIEWCOLUMNWIDTHCHANGED))
                {
                    objEvents.Set(WGEvents.SizeChange);
                }
            }
            return objEvents;
        }

        /// <summary>
        /// Gets the inherited auto size mode.
        /// </summary>
        /// <param name="objDataGridView">The data grid view.</param>
        /// <returns></returns>
        internal DataGridViewAutoSizeColumnMode GetInheritedAutoSizeMode(DataGridView objDataGridView)
        {
            DataGridViewAutoSizeColumnMode enmAutoSizeMode = this.AutoSizeMode;

            if ((objDataGridView == null) || (enmAutoSizeMode != DataGridViewAutoSizeColumnMode.NotSet))
            {
                return enmAutoSizeMode;
            }
            switch (objDataGridView.AutoSizeColumnsMode)
            {
                case DataGridViewAutoSizeColumnsMode.ColumnHeader:
                    return DataGridViewAutoSizeColumnMode.ColumnHeader;

                case DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader:
                    return DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

                case DataGridViewAutoSizeColumnsMode.AllCells:
                    return DataGridViewAutoSizeColumnMode.AllCells;

                case DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader:
                    return DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;

                case DataGridViewAutoSizeColumnsMode.DisplayedCells:
                    return DataGridViewAutoSizeColumnMode.DisplayedCells;

                case DataGridViewAutoSizeColumnsMode.Fill:
                    return DataGridViewAutoSizeColumnMode.Fill;
            }
            return DataGridViewAutoSizeColumnMode.None;
        }

        /// <summary>Calculates the ideal width of the column based on the specified criteria.</summary>
        /// <returns>The ideal width, in pixels, of the column.</returns>
        /// <param name="enmAutoSizeColumnMode">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value that specifies an automatic sizing mode. </param>
        /// <param name="blnFixedHeight">true to calculate the width of the column based on the current row heights; false to calculate the width with the expectation that the row heights will be adjusted.</param>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">autoSizeColumnMode is not a valid <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value. </exception>
        /// <exception cref="T:System.ArgumentException">autoSizeColumnMode is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.NotSet"></see>, <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.None"></see>, or <see cref="F:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode.Fill"></see>. </exception>
        public virtual int GetPreferredWidth(DataGridViewAutoSizeColumnMode enmAutoSizeColumnMode, bool blnFixedHeight)
        {
            if (((enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.NotSet) || (enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.None)) || (enmAutoSizeColumnMode == DataGridViewAutoSizeColumnMode.Fill))
            {
                throw new ArgumentException(SR.GetString("DataGridView_NeedColumnAutoSizingCriteria", new object[] { "autoSizeColumnMode" }));
            }
            switch (enmAutoSizeColumnMode)
            {
                case DataGridViewAutoSizeColumnMode.NotSet:
                case DataGridViewAutoSizeColumnMode.None:
                case DataGridViewAutoSizeColumnMode.ColumnHeader:
                case DataGridViewAutoSizeColumnMode.AllCellsExceptHeader:
                case DataGridViewAutoSizeColumnMode.AllCells:
                case DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader:
                case DataGridViewAutoSizeColumnMode.DisplayedCells:
                case DataGridViewAutoSizeColumnMode.Fill:
                    {
                        int intPreferredWidth;
                        int num3;
                        DataGridViewRow objDataGridViewRow;
                        DataGridView objDataGridView = base.DataGridView;
                        if (objDataGridView == null)
                        {
                            return -1;
                        }
                        DataGridViewAutoSizeColumnCriteriaInternal internal2 = (DataGridViewAutoSizeColumnCriteriaInternal)enmAutoSizeColumnMode;
                        int num = 0;
                        if (objDataGridView.ColumnHeadersVisible && ((internal2 & DataGridViewAutoSizeColumnCriteriaInternal.Header) != DataGridViewAutoSizeColumnCriteriaInternal.NotSet))
                        {
                            if (blnFixedHeight)
                            {
                                intPreferredWidth = this.HeaderCell.GetPreferredWidth(-1, objDataGridView.ColumnHeadersHeight);
                            }
                            else
                            {
                                intPreferredWidth = this.HeaderCell.GetPreferredSize(-1).Width;
                            }
                            if (num < intPreferredWidth)
                            {
                                num = intPreferredWidth;
                            }
                        }
                        if ((internal2 & DataGridViewAutoSizeColumnCriteriaInternal.AllRows) != DataGridViewAutoSizeColumnCriteriaInternal.NotSet)
                        {
                            for (num3 = objDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Visible); num3 != -1; num3 = objDataGridView.Rows.GetNextRow(num3, DataGridViewElementStates.Visible))
                            {
                                objDataGridViewRow = objDataGridView.Rows.SharedRow(num3);
                                if (blnFixedHeight)
                                {
                                    intPreferredWidth = objDataGridViewRow.Cells[base.Index].GetPreferredWidth(num3, objDataGridViewRow.Thickness);
                                }
                                else
                                {
                                    intPreferredWidth = objDataGridViewRow.Cells[base.Index].GetPreferredSize(num3).Width;
                                }
                                if (num < intPreferredWidth)
                                {
                                    num = intPreferredWidth;
                                }
                            }
                            return num;
                        }
                        if ((internal2 & DataGridViewAutoSizeColumnCriteriaInternal.DisplayedRows) != DataGridViewAutoSizeColumnCriteriaInternal.NotSet)
                        {
                            int intHeight = objDataGridView.LayoutInfo.Data.Height;
                            int num5 = 0;
                            for (num3 = objDataGridView.Rows.GetFirstRow(DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen); (num3 != -1) && (num5 < intHeight); num3 = objDataGridView.Rows.GetNextRow(num3, DataGridViewElementStates.Visible | DataGridViewElementStates.Frozen))
                            {
                                objDataGridViewRow = objDataGridView.Rows.SharedRow(num3);
                                if (blnFixedHeight)
                                {
                                    intPreferredWidth = objDataGridViewRow.Cells[base.Index].GetPreferredWidth(num3, objDataGridViewRow.Thickness);
                                }
                                else
                                {
                                    intPreferredWidth = objDataGridViewRow.Cells[base.Index].GetPreferredSize(num3).Width;
                                }
                                if (num < intPreferredWidth)
                                {
                                    num = intPreferredWidth;
                                }
                                num5 += objDataGridViewRow.Thickness;
                            }
                            if (num5 >= intHeight)
                            {
                                return num;
                            }
                            for (num3 = objDataGridView.FirstDisplayedScrollingRowIndex; (num3 != -1) && (num5 < intHeight); num3 = objDataGridView.Rows.GetNextRow(num3, DataGridViewElementStates.Visible))
                            {
                                objDataGridViewRow = objDataGridView.Rows.SharedRow(num3);
                                if (blnFixedHeight)
                                {
                                    intPreferredWidth = objDataGridViewRow.Cells[base.Index].GetPreferredWidth(num3, objDataGridViewRow.Thickness);
                                }
                                else
                                {
                                    intPreferredWidth = objDataGridViewRow.Cells[base.Index].GetPreferredSize(num3).Width;
                                }
                                if (num < intPreferredWidth)
                                {
                                    num = intPreferredWidth;
                                }
                                num5 += objDataGridViewRow.Thickness;
                            }
                        }
                        return num;
                    }
            }
            throw new InvalidEnumArgumentException("value", (int)enmAutoSizeColumnMode, typeof(DataGridViewAutoSizeColumnMode));
        }

        /// <summary>
        /// Shoulds the serialize default cell style.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeDefaultCellStyle()
        {
            if (!base.HasDefaultCellStyle)
            {
                return false;
            }
            DataGridViewCellStyle objDataGridViewCellStyle = this.DefaultCellStyle;
            if ((((objDataGridViewCellStyle.BackColor.IsEmpty && objDataGridViewCellStyle.ForeColor.IsEmpty) && (objDataGridViewCellStyle.SelectionBackColor.IsEmpty && objDataGridViewCellStyle.SelectionForeColor.IsEmpty)) && (((objDataGridViewCellStyle.Font == null) && objDataGridViewCellStyle.IsNullValueDefault) && (objDataGridViewCellStyle.IsDataSourceNullValueDefault && CommonUtils.IsNullOrEmpty(objDataGridViewCellStyle.Format)))) && ((objDataGridViewCellStyle.FormatProvider != null && objDataGridViewCellStyle.FormatProvider.Equals(CultureInfo.CurrentCulture) && (objDataGridViewCellStyle.Alignment == DataGridViewContentAlignment.NotSet)) && ((objDataGridViewCellStyle.WrapMode == DataGridViewTriState.NotSet) && (objDataGridViewCellStyle.Tag == null))))
            {
                return !objDataGridViewCellStyle.Padding.Equals(Padding.Empty);
            }
            return true;
        }

        /// <summary>
        /// Shoulds the serialize header text.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeHeaderText()
        {
            if (base.HasHeaderCell)
            {
                return this.HeaderCell.ContainsLocalValue;
            }
            return false;
        }


        /// <summary>
        /// Shoulds serialize the column width.
        /// </summary>
        /// <returns></returns>
        private bool ShouldSerializeWidth()
        {
            return ((this.InheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.Fill) && (this.Width != 100));
        }



        /// <summary>Gets a string that describes the column.</summary>
        /// <returns>A <see cref="T:System.String"></see> that describes the column.</returns>
        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            StringBuilder builder1 = new StringBuilder(0x40);
            builder1.Append("DataGridViewColumn { Name=");
            builder1.Append(this.Name);
            builder1.Append(", Index=");
            builder1.Append(base.Index.ToString(CultureInfo.CurrentCulture));
            builder1.Append(" }");
            return builder1.ToString();
        }

        /// <summary>
        /// This is a recursive function that loop through a control and all of its parents
        /// cheching if one of the controls(and control containers) is hidden or
        /// disabled.
        /// </summary>
        /// <value></value> 
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
                case "Resize":
                    double dblValue = Convert.ToDouble(objEvent[WGAttributes.Value],System.Globalization.CultureInfo.InvariantCulture);
                    if (dblValue > 5)
                    {
                        this.ThicknessInternal = Convert.ToInt32(dblValue);

                        if (this.DataGridView.NeedToAdjustFillingColumns)
                        {
                            this.DataGridView.ResetUIState(false, false);
                        }
                    }
                    break;

                case "DividerDoubleClick":
                    // Get owner grid.
                    DataGridView objOwningDataGridView = this.DataGridView;
                    if (objOwningDataGridView != null)
                    {
                        // Get cursor position.
                        Point objCursorPosition = objEvent.CursorPosition;
                        if (objCursorPosition != null)
                        {
                            // Raise column divider double click.
                            objOwningDataGridView.RaiseColumnDividerDoubleClick(new DataGridViewColumnDividerDoubleClickEventArgs(this.Index, new HandledMouseEventArgs(MouseButtons.Left, 2, objCursorPosition.X, objCursorPosition.X, 280)));
                        }
                    }
                    break;
            }
        }


        /// <summary>
        /// Clears the filter of this column.
        /// </summary>
        /// <param name="blnClearHeaderFilter">if set to <c>true</c> [BLN clear header filter].</param>
        public void ClearFilter(bool blnClearHeaderFilter)
        {
            // Clear filterRow's appropriate filter cell.
            DataGridView objDataGridView = this.DataGridView;
            if (objDataGridView != null && objDataGridView.ShowFilterRow && objDataGridView.FilterRow != null && objDataGridView.FilterRow.Cells.Count > 0 && objDataGridView.FilterRow.Cells.Count > this.Index)
            {
                (objDataGridView.FilterRow.Cells[this.Index] as DataGridViewFilterCell).ClearFilter(blnClearHeaderFilter);
            }
            else
            {
                // Clear ColumnHeader filter.
                if (this.HasHeaderCell && this.ShowHeaderFilter)
                {
                    this.HeaderCell.FilterComboBox.SelectedIndex = -1;
                    this.HeaderCell.FilterComboBox.Text = string.Empty;
                }

                // Clear custom filter
                this.CustomFilterExpression = string.Empty;
            }
        }

        /// <summary>Gets or sets the mode by which the column automatically adjusts its width.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.DataGridViewAutoSizeColumnMode"></see> value that determines whether the column will automatically adjust its width and how it will determine its preferred width. The default is <see cref="F:System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet"></see>.</returns>
        /// <exception cref="T:System.InvalidOperationException">The specified value when setting this property results in an <see cref="P:System.Windows.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> value of <see cref="F:System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader"></see> for a visible column when column headers are hidden.-or-The specified value when setting this property results in an <see cref="P:System.Windows.Forms.DataGridViewColumn.InheritedAutoSizeMode"></see> value of <see cref="F:System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill"></see> for a visible column that is frozen.</exception>
        /// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The specified value when setting this property is a <see cref="T:System.Windows.Forms.DataGridViewAutoSizeColumnMode"></see> that is not valid. </exception>
        [RefreshProperties(RefreshProperties.Repaint), SRDescription("DataGridViewColumn_AutoSizeModeDescr"), SRCategory("CatLayout"), DefaultValue(DataGridViewAutoSizeColumnMode.NotSet)]
        public DataGridViewAutoSizeColumnMode AutoSizeMode
        {
            get
            {
                return this.menmAutoSizeMode;
            }
            set
            {
                switch (value)
                {
                    case DataGridViewAutoSizeColumnMode.NotSet:
                    case DataGridViewAutoSizeColumnMode.None:
                    case DataGridViewAutoSizeColumnMode.ColumnHeader:
                    case DataGridViewAutoSizeColumnMode.AllCellsExceptHeader:
                    case DataGridViewAutoSizeColumnMode.AllCells:
                    case DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader:
                    case DataGridViewAutoSizeColumnMode.DisplayedCells:
                    case DataGridViewAutoSizeColumnMode.Fill:
                        if (menmAutoSizeMode != value)
                        {
                            if (this.Visible && (base.DataGridView != null))
                            {
                                if (!base.DataGridView.ColumnHeadersVisible && ((value == DataGridViewAutoSizeColumnMode.ColumnHeader) || ((value == DataGridViewAutoSizeColumnMode.NotSet) && (base.DataGridView.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.ColumnHeader))))
                                {
                                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_AutoSizeCriteriaCannotUseInvisibleHeaders"));
                                }
                                if (this.Frozen && ((value == DataGridViewAutoSizeColumnMode.Fill) || ((value == DataGridViewAutoSizeColumnMode.NotSet) && (base.DataGridView.AutoSizeColumnsMode == DataGridViewAutoSizeColumnsMode.Fill))))
                                {
                                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_FrozenColumnCannotAutoFill"));
                                }
                            }
                            DataGridViewAutoSizeColumnMode enmInheritedAutoSizeMode = this.InheritedAutoSizeMode;
                            bool blnFlag = ((enmInheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.Fill) && (enmInheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.None)) && (enmInheritedAutoSizeMode != DataGridViewAutoSizeColumnMode.NotSet);

                            this.menmAutoSizeMode = value;

                            if (base.DataGridView == null)
                            {
                                if (((this.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.Fill) || (this.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.None)) || (this.InheritedAutoSizeMode == DataGridViewAutoSizeColumnMode.NotSet))
                                {
                                    if ((base.Thickness != base.CachedThickness) && blnFlag)
                                    {
                                        base.ThicknessInternal = base.CachedThickness;
                                        return;
                                    }
                                }
                                else if (!blnFlag)
                                {
                                    base.CachedThickness = base.Thickness;
                                    return;
                                }
                            }
                            else
                            {
                                base.DataGridView.OnAutoSizeColumnModeChanged(this, enmInheritedAutoSizeMode);
                            }
                        }
                        return;
                }
                throw new InvalidEnumArgumentException("value", (int)value, typeof(DataGridViewAutoSizeColumnMode));
            }
        }

        /// <summary>
        /// Gets or sets the bound column converter.
        /// </summary>
        /// <value>The bound column converter.</value>
        internal TypeConverter BoundColumnConverter
        {
            get
            {
                return this.mobjBoundColumnConverter;
            }
            set
            {
                this.mobjBoundColumnConverter = value;
            }
        }

        /// <summary>
        /// Gets or sets the index of the bound column.
        /// </summary>
        /// <value>The index of the bound column.</value>
        internal int BoundColumnIndex
        {
            get
            {
                return this.mintBoundColumnIndex;
            }
            set
            {
                this.mintBoundColumnIndex = value;
            }
        }

        /// <summary>Gets or sets the template used to create new cells.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after. The default is null.</returns>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual DataGridViewCell CellTemplate
        {
            get
            {
                return this.mobjCellTemplate;
            }
            set
            {
                this.mobjCellTemplate = value;
            }
        }

        /// <summary>Gets the run-time type of the cell template.</summary>
        /// <returns>The <see cref="T:System.Type"></see> of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> used as a template for this column. The default is null.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced)]
        public Type CellType
        {
            get
            {
                DataGridViewCell objCellTemplate = this.CellTemplate;

                if (objCellTemplate != null)
                {
                    return objCellTemplate.GetType();
                }
                return null;
            }
        }


        /// <summary>Gets or sets the name of the data source property or database column to which the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see> is bound.</summary>
        /// <returns>The name of the property or database column associated with the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumn"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(true)]
        [DefaultValue("")]
#if WG_NET46
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnDataPropertyNameEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnDataPropertyNameEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnDataPropertyNameEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnDataPropertyNameEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnDataPropertyNameEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnDataPropertyNameEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
        [TypeConverter("Gizmox.WebGUI.Forms.Design.DataMemberFieldConverter, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
        [Editor("Gizmox.WebGUI.Forms.Design.DataGridViewColumnDataPropertyNameEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif
        public string DataPropertyName
        {
            get
            {
                return this.mstrDataPropertyName;
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                if (value != this.DataPropertyName)
                {
                    this.mstrDataPropertyName = value;
                    if (base.DataGridView != null)
                    {
                        base.DataGridView.OnColumnDataPropertyNameChanged(this);
                    }

                    UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>Gets or sets the column's default cell style.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the default style of the cells in the column.</returns>
        /// <filterpriority>1</filterpriority>

        [Gizmox.WebGUI.Forms.SRDescription("DataGridView_ColumnDefaultCellStyleDescr"), Browsable(true), Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
        public override DataGridViewCellStyle DefaultCellStyle
        {
            get
            {
                return base.DefaultCellStyle;
            }
            set
            {
                if (base.DefaultCellStyle != value)
                {
                    base.DefaultCellStyle = value;
                    DataGridView objDataGridView = this.DataGridView;
                    if (objDataGridView != null)
                    {
                        objDataGridView.Update();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the width of the desired fill.
        /// </summary>
        /// <value>The width of the desired fill.</value>
        internal int DesiredFillWidth
        {
            get
            {
                return this.mintDesiredFillWidth;
            }
            set
            {
                this.mintDesiredFillWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets the minimum width of the desired.
        /// </summary>
        /// <value>The minimum width of the desired.</value>
        internal int DesiredMinimumWidth
        {
            get
            {
                return this.mintDesiredMinimumWidth;
            }
            set
            {
                this.mintDesiredMinimumWidth = value;
            }
        }

        /// <summary>Gets or sets the display order of the column relative to the currently displayed columns.</summary>
        /// <returns>The zero-based position of the column as it is displayed in the associated <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see>, or -1 if the band is not contained within a control. </returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> is not null and the specified value when setting this property is less than 0 or greater than or equal to the number of columns in the control.-or-<see cref="P:Gizmox.WebGUI.Forms.DataGridViewElement.DataGridView"></see> is null and the specified value when setting this property is less than -1.-or-The specified value when setting this property is equal to <see cref="F:System.Int32.MaxValue"></see>. </exception>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int DisplayIndex
        {
            get
            {
                return this.mintDisplayIndex;
            }
            set
            {
                if (this.DisplayIndex != value)
                {
                    if (value == 0x7fffffff)
                    {
                        object[] arrArgs = new object[] { 0x7fffffff.ToString(CultureInfo.CurrentCulture) };
                        throw new ArgumentOutOfRangeException("DisplayIndex", value, SR.GetString("DataGridViewColumn_DisplayIndexTooLarge", arrArgs));
                    }
                    if (base.DataGridView != null)
                    {
                        if (value < 0)
                        {
                            throw new ArgumentOutOfRangeException("DisplayIndex", value, SR.GetString("DataGridViewColumn_DisplayIndexNegative"));
                        }
                        if (value >= base.DataGridView.Columns.Count)
                        {
                            throw new ArgumentOutOfRangeException("DisplayIndex", value, SR.GetString("DataGridViewColumn_DisplayIndexExceedsColumnCount"));
                        }
                        base.DataGridView.OnColumnDisplayIndexChanging(this, value);
                        this.mintDisplayIndex = value;
                        try
                        {
                            base.DataGridView.InDisplayIndexAdjustments = true;
                            base.DataGridView.OnColumnDisplayIndexChanged_PreNotification();
                            base.DataGridView.OnColumnDisplayIndexChanged(this);
                            base.DataGridView.OnColumnDisplayIndexChanged_PostNotification();
                            return;
                        }
                        finally
                        {
                            base.DataGridView.InDisplayIndexAdjustments = false;
                        }
                    }
                    if (value < -1)
                    {
                        throw new ArgumentOutOfRangeException("DisplayIndex", value, SR.GetString("DataGridViewColumn_DisplayIndexTooNegative"));
                    }
                    this.mintDisplayIndex = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [display index has changed].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [display index has changed]; otherwise, <c>false</c>.
        /// </value>
        internal bool DisplayIndexHasChanged
        {
            get
            {
                return ((this.Flags & 0x10) != 0);
            }
            set
            {
                if (value)
                {
                    this.Flags = (byte)(this.Flags | 0x10);
                }
                else
                {
                    this.Flags = (byte)(this.Flags & -17);
                }
            }
        }

        /// <summary>
        /// Sets the display index internal.
        /// </summary>
        /// <value>The display index internal.</value>
        internal int DisplayIndexInternal
        {
            set
            {
                this.mintDisplayIndex = value;
            }
        }

        /// <summary>Gets or sets the width, in pixels, of the column divider.</summary>
        /// <returns>The thickness, in pixels, of the divider (the column's right margin). </returns>
        [DefaultValue(0), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ColumnDividerWidthDescr"), Gizmox.WebGUI.Forms.SRCategory("CatLayout")]
        public int DividerWidth
        {
            get
            {
                return 0;
            }
            set
            {

            }
        }

        /// <summary>Gets or sets a value that represents the width of the column when it is in fill mode relative to the widths of other fill-mode columns in the control.</summary>
        /// <returns>A <see cref="T:System.Single"></see> representing the width of the column when it is in fill mode relative to the widths of other fill-mode columns. The default is 100.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is less than or equal to 0. </exception>
        [Gizmox.WebGUI.Forms.SRCategory("CatLayout"), Gizmox.WebGUI.Forms.SRDescription("DataGridViewColumn_FillWeightDescr"), DefaultValue((float)100f)]
        public float FillWeight
        {
            get
            {
                return this.mfltFillWeight;
            }
            set
            {
                if (value <= 0f)
                {
                    object[] arrArgs = new object[] { "FillWeight", value.ToString(CultureInfo.CurrentCulture), 0.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("FillWeight", SR.GetString("InvalidLowBoundArgument", arrArgs));
                }
                if (value > 65535f)
                {
                    object[] arrObjects2 = new object[] { "FillWeight", value.ToString(CultureInfo.CurrentCulture), 0xffff.ToString(CultureInfo.CurrentCulture) };
                    throw new ArgumentOutOfRangeException("FillWeight", SR.GetString("InvalidHighBoundArgumentEx", arrObjects2));
                }
                if (base.DataGridView != null)
                {
                    base.DataGridView.OnColumnFillWeightChanging(this, value);
                    this.mfltFillWeight = value;
                    base.DataGridView.OnColumnFillWeightChanged(this);
                }
                else
                {
                    this.mfltFillWeight = value;
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether a column will move when a user scrolls the <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control horizontally.</summary>
        /// <returns>true to freeze the column; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>
        [Gizmox.WebGUI.Forms.SRCategory("CatLayout"), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ColumnFrozenDescr"), DefaultValue(false), RefreshProperties(RefreshProperties.All)]
        public override bool Frozen
        {
            get
            {
                return base.Frozen;
            }
            set
            {
                // A column cannot be frozen if the grid is hierarchic
                if (value && this.DataGridView != null && this.DataGridView.IsHierarchic(HierarchicInfoSelector.Any))
                {
                    throw new Exception("DataGridView does not support hierarchies with frozen columns");
                }

                base.Frozen = value;
            }
        }

        /// <summary>Gets or sets the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see> that represents the column header.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnHeaderCell"></see> that represents the header cell for the column.</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewColumnHeaderCell HeaderCell
        {
            get
            {
                return (DataGridViewColumnHeaderCell)base.HeaderCellCore;
            }
            set
            {
                base.HeaderCellCore = value;
            }
        }

        /// <summary>Gets or sets the caption text on the column's header cell.</summary>
        /// <returns>A <see cref="T:System.String"></see> with the desired text. The default is an empty string ("").</returns>
        /// <filterpriority>1</filterpriority>

        [RefreshProperties(RefreshProperties.Repaint), Localizable(true), Gizmox.WebGUI.Forms.SRCategory("CatAppearance"), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ColumnHeaderTextDescr")]
        public string HeaderText
        {
            get
            {
                if (base.HasHeaderCell)
                {
                    string strText1 = this.HeaderCell.Value as string;
                    if (strText1 != null)
                    {
                        return strText1;
                    }
                }
                return string.Empty;
            }
            set
            {
                if (((value != null) || base.HasHeaderCell) && ((this.HeaderCell.ValueType != null) && this.HeaderCell.ValueType.IsAssignableFrom(typeof(string))))
                {
                    this.HeaderCell.Value = value;
                }
            }
        }

        /// <summary>Gets the sizing mode in effect for the column.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewAutoSizeColumnMode"></see> value in effect for the column.</returns>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Advanced), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewAutoSizeColumnMode InheritedAutoSizeMode
        {
            get
            {
                return this.GetInheritedAutoSizeMode(base.DataGridView);
            }
        }

        /// <summary>Gets the cell style currently applied to the column.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> that represents the cell style used to display the column.</returns>
        [Browsable(false)]
        public override DataGridViewCellStyle InheritedStyle
        {
            get
            {
                DataGridViewCellStyle objDataGridViewCellStyle1 = null;
                if (base.HasDefaultCellStyle)
                {
                    objDataGridViewCellStyle1 = this.DefaultCellStyle;
                }
                if (base.DataGridView == null)
                {
                    return objDataGridViewCellStyle1;
                }
                DataGridViewCellStyle objDataGridViewCellStyle2 = new DataGridViewCellStyle();
                DataGridViewCellStyle objDataGridViewCellStyle3 = base.DataGridView.DefaultCellStyle;
                if ((objDataGridViewCellStyle1 != null) && !objDataGridViewCellStyle1.BackColor.IsEmpty)
                {
                    objDataGridViewCellStyle2.BackColor = objDataGridViewCellStyle1.BackColor;
                }
                else
                {
                    objDataGridViewCellStyle2.BackColor = objDataGridViewCellStyle3.BackColor;
                }
                if ((objDataGridViewCellStyle1 != null) && !objDataGridViewCellStyle1.ForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle2.ForeColor = objDataGridViewCellStyle1.ForeColor;
                }
                else
                {
                    objDataGridViewCellStyle2.ForeColor = objDataGridViewCellStyle3.ForeColor;
                }
                if ((objDataGridViewCellStyle1 != null) && !objDataGridViewCellStyle1.SelectionBackColor.IsEmpty)
                {
                    objDataGridViewCellStyle2.SelectionBackColor = objDataGridViewCellStyle1.SelectionBackColor;
                }
                else
                {
                    objDataGridViewCellStyle2.SelectionBackColor = objDataGridViewCellStyle3.SelectionBackColor;
                }
                if ((objDataGridViewCellStyle1 != null) && !objDataGridViewCellStyle1.SelectionForeColor.IsEmpty)
                {
                    objDataGridViewCellStyle2.SelectionForeColor = objDataGridViewCellStyle1.SelectionForeColor;
                }
                else
                {
                    objDataGridViewCellStyle2.SelectionForeColor = objDataGridViewCellStyle3.SelectionForeColor;
                }
                if ((objDataGridViewCellStyle1 != null) && (objDataGridViewCellStyle1.Font != null))
                {
                    objDataGridViewCellStyle2.Font = objDataGridViewCellStyle1.Font;
                }
                else
                {
                    objDataGridViewCellStyle2.Font = objDataGridViewCellStyle3.Font;
                }
                if ((objDataGridViewCellStyle1 != null) && !objDataGridViewCellStyle1.IsNullValueDefault)
                {
                    objDataGridViewCellStyle2.NullValue = objDataGridViewCellStyle1.NullValue;
                }
                else
                {
                    objDataGridViewCellStyle2.NullValue = objDataGridViewCellStyle3.NullValue;
                }
                if ((objDataGridViewCellStyle1 != null) && !objDataGridViewCellStyle1.IsDataSourceNullValueDefault)
                {
                    objDataGridViewCellStyle2.DataSourceNullValue = objDataGridViewCellStyle1.DataSourceNullValue;
                }
                else
                {
                    objDataGridViewCellStyle2.DataSourceNullValue = objDataGridViewCellStyle3.DataSourceNullValue;
                }
                if ((objDataGridViewCellStyle1 != null) && (objDataGridViewCellStyle1.Format.Length != 0))
                {
                    objDataGridViewCellStyle2.Format = objDataGridViewCellStyle1.Format;
                }
                else
                {
                    objDataGridViewCellStyle2.Format = objDataGridViewCellStyle3.Format;
                }
                if ((objDataGridViewCellStyle1 != null) && !objDataGridViewCellStyle1.IsFormatProviderDefault)
                {
                    objDataGridViewCellStyle2.FormatProvider = objDataGridViewCellStyle1.FormatProvider;
                }
                else
                {
                    objDataGridViewCellStyle2.FormatProvider = objDataGridViewCellStyle3.FormatProvider;
                }
                if ((objDataGridViewCellStyle1 != null) && (objDataGridViewCellStyle1.Alignment != DataGridViewContentAlignment.NotSet))
                {
                    objDataGridViewCellStyle2.AlignmentInternal = objDataGridViewCellStyle1.Alignment;
                }
                else
                {
                    objDataGridViewCellStyle2.AlignmentInternal = objDataGridViewCellStyle3.Alignment;
                }
                if ((objDataGridViewCellStyle1 != null) && (objDataGridViewCellStyle1.WrapMode != DataGridViewTriState.NotSet))
                {
                    objDataGridViewCellStyle2.WrapModeInternal = objDataGridViewCellStyle1.WrapMode;
                }
                else
                {
                    objDataGridViewCellStyle2.WrapModeInternal = objDataGridViewCellStyle3.WrapMode;
                }
                if ((objDataGridViewCellStyle1 != null) && (objDataGridViewCellStyle1.Tag != null))
                {
                    objDataGridViewCellStyle2.Tag = objDataGridViewCellStyle1.Tag;
                }
                else
                {
                    objDataGridViewCellStyle2.Tag = objDataGridViewCellStyle3.Tag;
                }
                if ((objDataGridViewCellStyle1 != null) && (objDataGridViewCellStyle1.Padding != Padding.Empty))
                {
                    objDataGridViewCellStyle2.PaddingInternal = objDataGridViewCellStyle1.Padding;
                    return objDataGridViewCellStyle2;
                }
                objDataGridViewCellStyle2.PaddingInternal = objDataGridViewCellStyle3.Padding;
                return objDataGridViewCellStyle2;
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
        /// Gets or sets a value indicating whether this instance is browsable internal.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is browsable internal; otherwise, <c>false</c>.
        /// </value>
        internal bool IsBrowsableInternal
        {
            get
            {
                return ((this.Flags & 8) != 0);
            }
            set
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

        /// <summary>Gets a value indicating whether the column is bound to a data source.</summary>
        /// <returns>true if the column is connected to a data source; otherwise, false.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsDataBound
        {
            get
            {
                return this.IsDataBoundInternal;
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

                    if (this.DataGridView.Columns.Count > 0)
                    {
                        // Get first column.
                        DataGridViewColumn objDataGridViewColumn = this.DataGridView.Columns.GetFirstColumn(DataGridViewElementStates.Visible);

                        // Loops while having a valid column.
                        while (objDataGridViewColumn != null && objDataGridViewColumn != this)
                        {
                            // Add current column width to x position.
                            objLocation.X += objDataGridViewColumn.Width;

                            // Get next column.
                            objDataGridViewColumn = this.DataGridView.Columns.GetNextColumn(objDataGridViewColumn, DataGridViewElementStates.Visible, DataGridViewElementStates.None);
                        }
                    }

                    // Decrease grid's scrolling position.
                    objLocation.X -= this.DataGridView.ScrollPoisition.X;
                }

                return objLocation;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is data bound internal.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is data bound internal; otherwise, <c>false</c>.
        /// </value>
        internal bool IsDataBoundInternal
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

        /// <summary>Gets or sets the minimum width, in pixels, of the column.</summary>
        /// <returns>The number of pixels, from 2 to <see cref="F:System.Int32.MaxValue"></see>, that specifies the minimum width of the column. The default is 5.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The value is less than 2 or greater than <see cref="F:System.Int32.MaxValue"></see>.</exception>
        /// <filterpriority>1</filterpriority>

        [DefaultValue(5), RefreshProperties(RefreshProperties.Repaint), Localizable(true), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ColumnMinimumWidthDescr"), Gizmox.WebGUI.Forms.SRCategory("CatLayout")]
        public int MinimumWidth
        {
            get
            {
                return base.MinimumThickness;
            }
            set
            {
                base.MinimumThickness = value;
            }
        }

        /// <summary>Gets or sets the name of the column.</summary>
        /// <returns>A <see cref="T:System.String"></see> that contains the name of the column. The default is an empty string ("").</returns>
        /// <filterpriority>1</filterpriority>
        [Browsable(false)]
        public string Name
        {
            get
            {
                if ((this.Site != null) && !CommonUtils.IsNullOrEmpty(this.Site.Name))
                {
                    this.mstrName = this.Site.Name;
                }
                return this.mstrName;
            }
            set
            {
                if (CommonUtils.IsNullOrEmpty(value))
                {
                    this.mstrName = string.Empty;
                }
                else
                {
                    this.mstrName = value;
                }
                if ((base.DataGridView != null) && !ClientUtils.IsEquals(this.Name, this.mstrName, StringComparison.Ordinal))
                {
                    base.DataGridView.OnColumnNameChanged(this);

                    base.DataGridView.Update();
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the user can edit the column's cells.</summary>
        /// <returns>true if the user cannot edit the column's cells; otherwise, false.</returns>
        /// <exception cref="T:System.InvalidOperationException">This property is set to false for a column that is bound to a read-only data source. </exception>
        /// <filterpriority>1</filterpriority>
        [Gizmox.WebGUI.Forms.SRDescription("DataGridView_ColumnReadOnlyDescr"), Gizmox.WebGUI.Forms.SRCategory("CatBehavior")]
        public override bool ReadOnly
        {
            get
            {
                return base.ReadOnly;
            }
            set
            {
                int intBoundColumnIndex = this.BoundColumnIndex;

                if (((this.IsDataBound && (base.DataGridView != null)) && ((base.DataGridView.DataConnection != null) && (intBoundColumnIndex != -1))) && (base.DataGridView.DataConnection.DataFieldIsReadOnly(intBoundColumnIndex) && !value))
                {
                    throw new InvalidOperationException(SR.GetString("DataGridView_ColumnBoundToAReadOnlyFieldMustRemainReadOnly"));
                }

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

        /// <summary>Gets or sets a value indicating whether the column is resizable.</summary>
        /// <returns>One of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTriState"></see> values. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewTriState.True"></see>.</returns>
        /// <filterpriority>1</filterpriority>
        [Gizmox.WebGUI.Forms.SRDescription("DataGridView_ColumnResizableDescr"), Gizmox.WebGUI.Forms.SRCategory("CatBehavior")]
        public override DataGridViewTriState Resizable
        {
            get
            {
                return base.Resizable;
            }
            set
            {
                base.Resizable = value;
            }
        }

        /// <summary>Gets or sets the site of the column.</summary>
        /// <returns>The <see cref="T:System.ComponentModel.ISite"></see> associated with the column, if any.</returns>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public ISite Site
        {
            get
            {
                return this.mobjSite;
            }
            set
            {
                this.mobjSite = value;
            }
        }

        /// <summary>
        /// Gets or sets the client id.
        /// </summary>
        /// <value>
        /// The client id.
        /// </value>
        [DefaultValue("")]
        public string ClientId
        {
            get
            {
                return mstrClientId;
            }
            set
            {
                mstrClientId = value;
            }
        }

        /// <summary>Gets or sets the sort mode for the column.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode"></see> that specifies the criteria used to order the rows based on the cell values in a column.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value assigned to the property conflicts with <see cref="P:Gizmox.WebGUI.Forms.DataGridView.SelectionMode"></see>. </exception>
        /// <filterpriority>1</filterpriority>

        [DefaultValue(DataGridViewColumnSortMode.NotSortable), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ColumnSortModeDescr"), Gizmox.WebGUI.Forms.SRCategory("CatBehavior")]
        public DataGridViewColumnSortMode SortMode
        {
            get
            {
                byte bytFlags = this.Flags;

                if ((bytFlags & 1) != 0)
                {
                    return DataGridViewColumnSortMode.Automatic;
                }
                if ((bytFlags & 2) != 0)
                {
                    return DataGridViewColumnSortMode.Programmatic;
                }
                return DataGridViewColumnSortMode.NotSortable;
            }
            set
            {
                if (value != this.SortMode)
                {
                    if (value != DataGridViewColumnSortMode.NotSortable)
                    {
                        if ((((base.DataGridView != null) && !base.DataGridView.InInitialization) && (value == DataGridViewColumnSortMode.Automatic)) && ((base.DataGridView.SelectionMode == DataGridViewSelectionMode.FullColumnSelect) || (base.DataGridView.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)))
                        {
                            throw new InvalidOperationException(SR.GetString("DataGridViewColumn_SortModeAndSelectionModeClash", new object[] { value.ToString(), base.DataGridView.SelectionMode.ToString() }));
                        }
                        if (value == DataGridViewColumnSortMode.Automatic)
                        {
                            this.Flags = (byte)(this.Flags & -3);
                            this.Flags = (byte)(this.Flags | 1);
                        }
                        else
                        {
                            this.Flags = (byte)(this.Flags & -2);
                            this.Flags = (byte)(this.Flags | 2);
                        }
                    }
                    else
                    {
                        this.Flags = (byte)(this.Flags & -2);
                        this.Flags = (byte)(this.Flags & -3);
                    }
                    if (base.DataGridView != null)
                    {
                        base.DataGridView.OnColumnSortModeChanged(this);
                    }
                }
            }
        }

        /// <summary>Gets or sets the text used for ToolTips.</summary>
        /// <returns>The text to display as a ToolTip for the column.</returns>
        /// <filterpriority>1</filterpriority>
        [Gizmox.WebGUI.Forms.SRCategory("CatAppearance"), Localizable(true), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ColumnToolTipTextDescr"), DefaultValue("")]
        public string ToolTipText
        {
            get
            {
                return this.HeaderCell.ToolTipText;
            }
            set
            {
                if (string.Compare(this.ToolTipText, value, false, CultureInfo.InvariantCulture) != 0)
                {
                    this.HeaderCell.ToolTipText = value;
                    if (base.DataGridView != null)
                    {
                        base.DataGridView.OnColumnToolTipTextChanged(this);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the used fill weight.
        /// </summary>
        /// <value>The used fill weight.</value>
        internal float UsedFillWeight
        {
            get
            {
                return this.mfltUsedFillWeight;
            }
            set
            {
                this.mfltUsedFillWeight = value;
            }
        }

        /// <summary>Gets or sets the data type of the values in the column's cells.</summary>
        /// <returns>A <see cref="T:System.Type"></see> that describes the run-time class of the values stored in the column's cells.</returns>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false), DefaultValue((string)null)]
        public Type ValueType
        {
            get
            {
                return this.mobjValueType;
            }
            set
            {
                this.mobjValueType = value;
            }
        }

        /// <summary>Gets or sets a value indicating whether the column is visible.</summary>
        /// <returns>true if the column is visible; otherwise, false.</returns>
        /// <filterpriority>1</filterpriority>

        [Localizable(true), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ColumnVisibleDescr"), Gizmox.WebGUI.Forms.SRCategory("CatAppearance"), DefaultValue(true)]
        public override bool Visible
        {
            get
            {
                return base.Visible;
            }
            set
            {
                if (base.Visible != value)
                {
                    base.Visible = value;

                    // Clear filter of hidden column.
                    if (!value)
                    {
                        this.ClearFilter(true);
                    }

                    DataGridView objDataGridView = this.DataGridView;
                    if (objDataGridView != null)
                    {
                        objDataGridView.SwitchPreRenderUpdate(Forms.DataGridView.PreRenderUpdateType.GroupHeaders);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the custom filter expression.
        /// </summary>
        /// <value>
        /// The custom filter expression.
        /// </value>
        [DefaultValue("")]
        public string CustomFilterExpression
        {
            get
            {
                return mstrCustomFilterExpression;
            }
            set
            {
                if (mstrCustomFilterExpression != value)
                {
                    mstrCustomFilterExpression = value;

                    DataGridView objDataGridView = this.DataGridView;

                    if (objDataGridView != null)
                    {
                        if (!objDataGridView.mblnSuspendFilterInitialization)
                        {
                            objDataGridView.ApplyDataGridViewFilter();
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets the current width of the column.</summary>
        /// <returns>The width, in pixels, of the column. The default is 100.</returns>
        /// <exception cref="T:System.ArgumentOutOfRangeException">The specified value when setting this property is greater than 65536.</exception>
        /// <filterpriority>1</filterpriority>
        [RefreshProperties(RefreshProperties.Repaint), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ColumnWidthDescr"), Gizmox.WebGUI.Forms.SRCategory("CatLayout"), Localizable(true)]
        public int Width
        {
            get
            {
                return base.Thickness;
            }
            set
            {
                base.Thickness = value;
            }
        }

        /// <summary>
        /// Clones the internal.
        /// </summary>
        /// <param name="objDataGridViewColumn">The data grid view column.</param>
        protected void CloneInternal(DataGridViewComboBoxColumn objDataGridViewColumn)
        {
            base.CloneInternal(objDataGridViewColumn);
            objDataGridViewColumn.Name = this.Name;
            this.mintDisplayIndex = -1;
            objDataGridViewColumn.HeaderText = this.HeaderText;
            objDataGridViewColumn.DataPropertyName = this.DataPropertyName;
            if (objDataGridViewColumn.CellTemplate != null)
            {
                objDataGridViewColumn.CellTemplate = (DataGridViewCell)this.CellTemplate.Clone();
            }
            else
            {
                objDataGridViewColumn.CellTemplate = null;
            }
            if (base.HasHeaderCell)
            {
                objDataGridViewColumn.HeaderCell = (DataGridViewColumnHeaderCell)this.HeaderCell.Clone();
            }
            objDataGridViewColumn.AutoSizeMode = this.AutoSizeMode;
            objDataGridViewColumn.SortMode = this.SortMode;


        }

        /// <summary>Gets or sets the shortcut menu for the column.</summary>
        /// <returns>The <see cref="T:System.Windows.Forms.ContextMenuStrip"></see> associated with the current <see cref="T:System.Windows.Forms.DataGridViewColumn"></see>. The default is null.</returns>
        [SRDescription("DataGridView_ColumnContextMenuStripDescr"), DefaultValue((string)null), SRCategory("CatBehavior")]
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

        /// <summary>
        /// Gets or sets a value indicating whether the user can group by this column.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if the user can group by this column; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true), SRCategory("CatBehavior")]
        public bool CanGroupBy
        {
            get
            {
                return mblnCanGroupBy;
    }
            set
            {
                if (mblnCanGroupBy != value)
                {
                    mblnCanGroupBy = value;
                    this.UpdateParams(AttributeType.Control);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show header filter].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show header filter]; otherwise, <c>false</c>.
        /// </value>
        internal bool ShowHeaderFilter
        {
            get
            {
                return mblnShowHeaderFilter;
            }
            set
            {
                if (mblnShowHeaderFilter != value)
                {
                    // Update value
                    mblnShowHeaderFilter = value;

                    // Get header cell
                    DataGridViewColumnHeaderCell objHeaderCell = this.HeaderCell;
                    if (objHeaderCell != null)
                    {
                        // Update cell
                        objHeaderCell.ShouldPreRenderHeaderFilter = mblnShowHeaderFilter;
                        objHeaderCell.Update();
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is custom filter.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is custom filter; otherwise, <c>false</c>.
        /// </value>
        internal bool IsCustomFilter
        {
            get
            {
                DataGridViewColumnHeaderCell objHeaderCell = this.HeaderCell;
                if (objHeaderCell != null)
                {
                    return objHeaderCell.FilterComboBox.IsCustomFilter;
                }

                return false;
            }
            set
            {
                DataGridViewColumnHeaderCell objHeaderCell = this.HeaderCell;
                if (objHeaderCell != null)
                {
                    objHeaderCell.FilterComboBox.IsCustomFilter = value;
                }
            }
        }

        /// <summary>
        /// Determines whether [has filter info].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [has filter info]; otherwise, <c>false</c>.
        /// </returns>
        internal bool HasFilterInfo()
        {
            DataGridView objDataGridView = this.DataGridView;

            if (objDataGridView != null)
            {
                return objDataGridView.GetColumnHeaderInfo(this) != null;
            }

            return false;
        }
    }

    #endregion

    #region DataGridViewComboBoxColumn Class

    /// <summary>Represents a column of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see> objects.</summary>
    /// <filterpriority>2</filterpriority>
    [ToolboxBitmap(typeof(DataGridViewComboBoxColumn), "DataGridViewComboBoxColumn.bmp")]
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewComboBoxColumnController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [Serializable()]
    public class DataGridViewComboBoxColumn : DataGridViewColumn
    {
        static DataGridViewComboBoxColumn()
        {
            DataGridViewComboBoxColumn.mobjColumnType = typeof(DataGridViewComboBoxColumn);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewComboBoxColumn"/> class.
        /// </summary>
        public DataGridViewComboBoxColumn()
            : this(new DataGridViewComboBoxCell())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewComboBoxColumn"/> class.
        /// </summary>
        /// <param name="objDataGridViewCellTemplate">The obj data grid view cell template.</param>
        protected DataGridViewComboBoxColumn(DataGridViewComboBoxCell objDataGridViewCellTemplate)
            : base(objDataGridViewCellTemplate)
        {
            ((DataGridViewComboBoxCell)base.CellTemplate).TemplateComboBoxColumn = this;
        }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        protected override string TypeName
        {
            get
            {
                return ComboBoxTypeName;
            }
        }


        /// <filterpriority>1</filterpriority>

        public override object Clone()
        {
            DataGridViewComboBoxColumn objColumn1;
            Type objType1 = base.GetType();
            if (objType1 == DataGridViewComboBoxColumn.mobjColumnType)
            {
                objColumn1 = new DataGridViewComboBoxColumn();
            }
            else
            {
                objColumn1 = (DataGridViewComboBoxColumn)Activator.CreateInstance(objType1);
            }
            if (objColumn1 != null)
            {
                base.CloneInternal(objColumn1);
                ((DataGridViewComboBoxCell)objColumn1.CellTemplate).TemplateComboBoxColumn = objColumn1;
            }
            return objColumn1;
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

            if (this.CellTemplate != null &&
                this.CellTemplate is DataGridViewComboBoxCell)
            {
                ((DataGridViewComboBoxCell)this.CellTemplate).RenderComboboxItems(objContext, objWriter, lngRequestID, blnRenderOwner);
            }
        }

        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <param name="objSource">The source.</param>
        /// <param name="strPropertyName">Name of the property.</param>
        /// <param name="strDefaultValue">The default value.</param>
        /// <returns></returns>
        private string GetPropertyValue(object objSource, string strPropertyName, string strDefaultValue)
        {
            string strReturnValue = strDefaultValue;

            if (objSource != null && strPropertyName != string.Empty)
            {
                PropertyInfo objPropertyInfo = objSource.GetType().GetProperty(strPropertyName);

                if (objPropertyInfo != null)
                {
                    object objValue = objPropertyInfo.GetValue(objSource, null);

                    if (objValue != null)
                    {
                        strReturnValue = Convert.ToString(objValue);
                    }
                }
            }

            return strReturnValue;
        }

        internal void OnItemsCollectionChanged()
        {
            if (base.DataGridView != null)
            {
                DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                int num1 = objCollection1.Count;
                object[] arrItems = ((DataGridViewComboBoxCell)this.CellTemplate).Items.InnerArray.ToArray();
                for (int num2 = 0; num2 < num1; num2++)
                {
                    DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                    DataGridViewComboBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewComboBoxCell;
                    if (objCell != null)
                    {
                        objCell.Items.ClearInternal();
                        objCell.Items.AddRangeInternal(arrItems);
                    }
                }
                base.DataGridView.OnColumnCommonChange(base.Index);
            }
        }

        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            StringBuilder builder1 = new StringBuilder(0x40);
            builder1.Append("DataGridViewComboBoxColumn { Name=");
            builder1.Append(base.Name);
            builder1.Append(", Index=");
            builder1.Append(base.Index.ToString(CultureInfo.CurrentCulture));
            builder1.Append(" }");
            return builder1.ToString();
        }


        /// <summary>Gets or sets a value indicating whether cells in the column will match the characters being entered in the cell with one from the possible selections. </summary>
        /// <returns>true if auto completion is activated; otherwise, false. The default is true.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null.</exception>
        /// <filterpriority>1</filterpriority>
        [Gizmox.WebGUI.Forms.SRDescription("DataGridView_ComboBoxColumnAutoCompleteDescr"), DefaultValue(true), Gizmox.WebGUI.Forms.SRCategory("CatBehavior"), Browsable(true)]
        public bool AutoComplete
        {
            get
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.ComboBoxCellTemplate.AutoComplete;
            }
            set
            {
                if (this.AutoComplete != value)
                {
                    this.ComboBoxCellTemplate.AutoComplete = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewComboBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewComboBoxCell;
                            if (objCell != null)
                            {
                                objCell.AutoComplete = value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets the template used to create cells.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after. The default value is a new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>.</returns>
        /// <exception cref="T:System.InvalidCastException">When setting this property to a value that is not of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell"></see>. </exception>
        /// <filterpriority>1</filterpriority>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                DataGridViewComboBoxCell objCell = value as DataGridViewComboBoxCell;
                if ((value != null) && (objCell == null))
                {
                    throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", new object[] { "Gizmox.WebGUI.Forms.DataGridViewComboBoxCell" }));
                }
                base.CellTemplate = value;
                if (value != null)
                {
                    objCell.TemplateComboBoxColumn = this;
                }
            }
        }

        private DataGridViewComboBoxCell ComboBoxCellTemplate
        {
            get
            {
                return (DataGridViewComboBoxCell)this.CellTemplate;
            }
        }

        /// <summary>Gets or sets the data source that populates the selections for the combo boxes.</summary>
        /// <returns>An object that represents a data source. The default is null.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
        /// <filterpriority>1</filterpriority>
        [SRDescription("DataGridViewDataSourceDescr"), RefreshProperties(RefreshProperties.Repaint), SRCategory("CatData"), DefaultValue((string)null), AttributeProvider(typeof(Binding.IDataSourceAttributeProvider))]
        public object DataSource
        {
            get
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.ComboBoxCellTemplate.DataSource;
            }
            set
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                this.ComboBoxCellTemplate.DataSource = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                    int num1 = objCollection1.Count;
                    for (int num2 = 0; num2 < num1; num2++)
                    {
                        DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                        DataGridViewComboBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewComboBoxCell;
                        if (objCell != null)
                        {
                            objCell.DataSource = value;
                        }
                    }
                    base.DataGridView.OnColumnCommonChange(base.Index);
                }
            }
        }

        /// <summary>Gets or sets a string that specifies the property or column from which to retrieve strings for display in the combo boxes.</summary>
        /// <returns>A <see cref="T:System.String"></see> that specifies the name of a property or column in the data source specified in the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.DataSource"></see> property. The default is <see cref="F:System.String.Empty"></see>.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(""), TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ComboBoxColumnDisplayMemberDescr"), Gizmox.WebGUI.Forms.SRCategory("CatData")]
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif
        public string DisplayMember
        {
            get
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.ComboBoxCellTemplate.DisplayMember;
            }
            set
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                this.ComboBoxCellTemplate.DisplayMember = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                    int num1 = objCollection1.Count;
                    for (int num2 = 0; num2 < num1; num2++)
                    {
                        DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                        DataGridViewComboBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewComboBoxCell;
                        if (objCell != null)
                        {
                            objCell.DisplayMember = value;
                        }
                    }
                    base.DataGridView.OnColumnCommonChange(base.Index);
                }
            }
        }

        /// <summary>Gets or sets a value that determines how the combo box is displayed when not editing.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxDisplayStyle"></see> value indicating the combo box appearance. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewComboBoxDisplayStyle.DropDownButton"></see>.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null.</exception>
        [Gizmox.WebGUI.Forms.SRDescription("DataGridView_ComboBoxColumnDisplayStyleDescr"), DefaultValue(1), Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
        public DataGridViewComboBoxDisplayStyle DisplayStyle
        {
            get
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.ComboBoxCellTemplate.DisplayStyle;
            }
            set
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                this.ComboBoxCellTemplate.DisplayStyle = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                    int num1 = objCollection1.Count;
                    for (int num2 = 0; num2 < num1; num2++)
                    {
                        DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                        DataGridViewComboBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewComboBoxCell;
                        if (objCell != null)
                        {
                            objCell.DisplayStyleInternal = value;
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        /// <summary>Gets or sets a value that determines if the display style only applies to the current cell.</summary>
        /// <returns>true if the display style applies only to the current cell; otherwise false. The default is false.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null.</exception>
        [DefaultValue(false), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ComboBoxColumnDisplayStyleForCurrentCellOnlyDescr"), Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
        public bool DisplayStyleForCurrentCellOnly
        {
            get
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.ComboBoxCellTemplate.DisplayStyleForCurrentCellOnly;
            }
            set
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                this.ComboBoxCellTemplate.DisplayStyleForCurrentCellOnly = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                    int num1 = objCollection1.Count;
                    for (int num2 = 0; num2 < num1; num2++)
                    {
                        DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                        DataGridViewComboBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewComboBoxCell;
                        if (objCell != null)
                        {
                            objCell.DisplayStyleForCurrentCellOnlyInternal = value;
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        /// <summary>
        /// Gets or sets the drop down style.
        /// </summary>
        /// <value></value>
        [System.ComponentModel.DefaultValue(ComboBoxStyle.DropDownList)]
        public virtual ComboBoxStyle DropDownStyle
        {
            get
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.ComboBoxCellTemplate.DropDownStyle;
            }
            set
            {
                if (this.ComboBoxCellTemplate.DropDownStyle != value)
                {
                    this.ComboBoxCellTemplate.DropDownStyle = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewComboBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewComboBoxCell;
                            if (objCell != null)
                            {
                                objCell.DropDownStyle= value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets the width of the drop-down lists of the combo boxes.</summary>
        /// <returns>The width, in pixels, of the drop-down lists. The default is 1.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(1), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ComboBoxColumnDropDownWidthDescr"), Gizmox.WebGUI.Forms.SRCategory("CatBehavior")]
        public int DropDownWidth
        {
            get
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.ComboBoxCellTemplate.DropDownWidth;
            }
            set
            {
                if (this.DropDownWidth != value)
                {
                    this.ComboBoxCellTemplate.DropDownWidth = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewComboBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewComboBoxCell;
                            if (objCell != null)
                            {
                                objCell.DropDownWidth = value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets the flat style appearance of the column's cells.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> value indicating the cell appearance. The default is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Standard"></see>.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null.</exception>
        /// <filterpriority>1</filterpriority>
        [Gizmox.WebGUI.Forms.SRCategory("CatAppearance"), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ComboBoxColumnFlatStyleDescr"), DefaultValue(2)]
        public FlatStyle FlatStyle
        {
            get
            {
                if (this.CellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return ((DataGridViewComboBoxCell)this.CellTemplate).FlatStyle;
            }
            set
            {
                if (this.FlatStyle != value)
                {
                    ((DataGridViewComboBoxCell)this.CellTemplate).FlatStyle = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewComboBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewComboBoxCell;
                            if (objCell != null)
                            {
                                objCell.FlatStyleInternal = value;
                            }
                        }
                        base.DataGridView.OnColumnCommonChange(base.Index);
                    }
                }
            }
        }

        /// <summary>Gets the collection of objects used as selections in the combo boxes.</summary>
        /// <returns>An <see cref="T:Gizmox.WebGUI.Forms.DataGridViewComboBoxCell.ObjectCollection"></see> that represents the selections in the combo boxes. </returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
        /// <filterpriority>1</filterpriority>
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        [SRCategory("CatData"), SRDescription("DataGridView_ComboBoxColumnItemsDescr"), Localizable(true)]
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.StringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.StringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.StringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.StringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.StringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.StringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.StringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#else
        [Editor("Gizmox.WebGUI.Forms.Design.StringCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(UITypeEditor))]
#endif
        public DataGridViewComboBoxCell.ObjectCollection Items
        {
            get
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.ComboBoxCellTemplate.GetItems(base.DataGridView);
            }
        }

        /// <summary>Gets or sets the maximum number of items in the drop-down list of the cells in the column.</summary>
        /// <returns>The maximum number of drop-down list items, from 1 to 100. The default is 8.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
        /// <filterpriority>1</filterpriority>
        [Gizmox.WebGUI.Forms.SRCategory("CatBehavior"), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ComboBoxColumnMaxDropDownItemsDescr"), DefaultValue(8)]
        public int MaxDropDownItems
        {
            get
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.ComboBoxCellTemplate.MaxDropDownItems;
            }
            set
            {
                if (this.MaxDropDownItems != value)
                {
                    this.ComboBoxCellTemplate.MaxDropDownItems = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewComboBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewComboBoxCell;
                            if (objCell != null)
                            {
                                objCell.MaxDropDownItems = value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the items in the combo box are sorted.</summary>
        /// <returns>true if the combo box is sorted; otherwise, false. The default is false.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
        /// <filterpriority>1</filterpriority>

        [DefaultValue(false), Gizmox.WebGUI.Forms.SRCategory("CatBehavior"), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ComboBoxColumnSortedDescr")]
        public bool Sorted
        {
            get
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.ComboBoxCellTemplate.Sorted;
            }
            set
            {
                if (this.Sorted != value)
                {
                    this.ComboBoxCellTemplate.Sorted = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewComboBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewComboBoxCell;
                            if (objCell != null)
                            {
                                objCell.Sorted = value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets a string that specifies the property or column from which to get values that correspond to the selections in the drop-down list.</summary>
        /// <returns>A <see cref="T:System.String"></see> that specifies the name of a property or column used in the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.DataSource"></see> property. The default is <see cref="F:System.String.Empty"></see>.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewComboBoxColumn.CellTemplate"></see> property is null. </exception>
        /// <filterpriority>1</filterpriority>
        [TypeConverter("System.Windows.Forms.Design.DataMemberFieldConverter, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), DefaultValue(""), Gizmox.WebGUI.Forms.SRCategory("CatData"), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ComboBoxColumnValueMemberDescr")]
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.DataMemberFieldEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
#endif
        public string ValueMember
        {
            get
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.ComboBoxCellTemplate.ValueMember;
            }
            set
            {
                if (this.ComboBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                this.ComboBoxCellTemplate.ValueMember = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                    int num1 = objCollection1.Count;
                    for (int num2 = 0; num2 < num1; num2++)
                    {
                        DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                        DataGridViewComboBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewComboBoxCell;
                        if (objCell != null)
                        {
                            objCell.ValueMember = value;
                        }
                    }
                    base.DataGridView.OnColumnCommonChange(base.Index);
                }
            }
        }

        private static Type mobjColumnType;
    }

    #endregion

    #region DataGridViewImageColumn Class

    /// <summary>Hosts a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCell"></see> objects.</summary>
    /// <filterpriority>2</filterpriority>
    [ToolboxBitmap(typeof(DataGridViewImageColumn), "DataGridViewImageColumn.bmp")]
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewImageColumnController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewImageColumnController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewImageColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewImageColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewImageColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewImageColumnController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewImageColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewImageColumnController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewImageColumnController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewImageColumnController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewImageColumnController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewImageColumnController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewImageColumnController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewImageColumnController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewImageColumnController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewImageColumnController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [Serializable()]
    public class DataGridViewImageColumn : DataGridViewColumn
    {


        private ResourceHandle mobjIcon;
        private ResourceHandle mobjImage;
        private static Type mobjColumnType;

        static DataGridViewImageColumn()
        {
            DataGridViewImageColumn.mobjColumnType = typeof(DataGridViewImageColumn);
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageColumn"></see> class, configuring it for use with cell values of type <see cref="T:System.Drawing.Image"></see>.</summary>
        public DataGridViewImageColumn()
            : this(true)
        {
        }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        protected override string TypeName
        {
            get
            {
                return ImageTypeName;
            }
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageColumn"></see> class, optionally configuring it for use with <see cref="T:System.Drawing.Icon"></see> cell values.</summary>
        /// <param name="blnValuesAreIcons">true to indicate that the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Value"></see> property of cells in this column will be set to values of type <see cref="T:System.Drawing.Icon"></see>; false to indicate that they will be set to values of type <see cref="T:System.Drawing.Image"></see>.</param>
        public DataGridViewImageColumn(bool blnValuesAreIcons)
            : this(blnValuesAreIcons, new DataGridViewImageCell(blnValuesAreIcons))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewImageColumn"/> class.
        /// </summary>
        /// <param name="blnValuesAreIcons">if set to <c>true</c> [BLN values are icons].</param>
        /// <param name="objCellTemplate">The obj cell template.</param>
        protected DataGridViewImageColumn(bool blnValuesAreIcons, DataGridViewImageCell objCellTemplate)
            : base(objCellTemplate)
        {
            DataGridViewCellStyle objDataGridViewCellStyle = new DataGridViewCellStyle();
            objDataGridViewCellStyle.AlignmentInternal = DataGridViewContentAlignment.MiddleCenter;
            if (blnValuesAreIcons)
            {
                objDataGridViewCellStyle.NullValue = DataGridViewImageCell.ErrorIcon;
            }
            else
            {
                objDataGridViewCellStyle.NullValue = DataGridViewImageCell.ErrorBitmap;
            }
            this.DefaultCellStyle = objDataGridViewCellStyle;
        }

        /// <filterpriority>1</filterpriority>

        public override object Clone()
        {
            DataGridViewImageColumn objColumn1;
            Type objType1 = base.GetType();
            if (objType1 == DataGridViewImageColumn.mobjColumnType)
            {
                objColumn1 = new DataGridViewImageColumn();
            }
            else
            {
                objColumn1 = (DataGridViewImageColumn)Activator.CreateInstance(objType1);
            }
            if (objColumn1 != null)
            {
                objColumn1.Icon = this.Icon;
                objColumn1.Image = this.Image;
            }
            return objColumn1;
        }

        private bool ShouldSerializeDefaultCellStyle()
        {
            DataGridViewImageCell objCell = this.CellTemplate as DataGridViewImageCell;
            if (objCell != null)
            {
                object obj1;
                if (!base.HasDefaultCellStyle)
                {
                    return false;
                }
                if (objCell.ValueIsIcon)
                {
                    obj1 = DataGridViewImageCell.ErrorIcon;
                }
                else
                {
                    obj1 = DataGridViewImageCell.ErrorBitmap;
                }
                DataGridViewCellStyle objDataGridViewCellStyle = this.DefaultCellStyle;
                if ((((objDataGridViewCellStyle.BackColor.IsEmpty && objDataGridViewCellStyle.ForeColor.IsEmpty) && (objDataGridViewCellStyle.SelectionBackColor.IsEmpty && objDataGridViewCellStyle.SelectionForeColor.IsEmpty)) && (((objDataGridViewCellStyle.Font == null) && obj1 == objDataGridViewCellStyle.NullValue) && (objDataGridViewCellStyle.IsDataSourceNullValueDefault && CommonUtils.IsNullOrEmpty(objDataGridViewCellStyle.Format)))) && ((objDataGridViewCellStyle.FormatProvider.Equals(CultureInfo.CurrentCulture) && (objDataGridViewCellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)) && ((objDataGridViewCellStyle.WrapMode == DataGridViewTriState.NotSet) && (objDataGridViewCellStyle.Tag == null))))
                {
                    return !objDataGridViewCellStyle.Padding.Equals(Padding.Empty);
                }
            }
            return true;
        }

        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            StringBuilder builder1 = new StringBuilder(0x40);
            builder1.Append("DataGridViewImageColumn { Name=");
            builder1.Append(base.Name);
            builder1.Append(", Index=");
            builder1.Append(base.Index.ToString(CultureInfo.CurrentCulture));
            builder1.Append(" }");
            return builder1.ToString();
        }


        /// <summary>Gets or sets the template used to create new cells.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after.</returns>
        /// <exception cref="T:System.InvalidCastException">The set type is not compatible with type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCell"></see>. </exception>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if ((value != null) && !(value is DataGridViewImageCell))
                {
                    throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", new object[] { "Gizmox.WebGUI.Forms.DataGridViewImageCell" }));
                }
                base.CellTemplate = value;
            }
        }

        /// <summary>Gets or sets the column's default cell style.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be applied as the default style.</returns>
        [Gizmox.WebGUI.Forms.SRCategory("CatAppearance"), Browsable(true), Gizmox.WebGUI.Forms.SRDescription("DataGridView_ColumnDefaultCellStyleDescr")]
        public override DataGridViewCellStyle DefaultCellStyle
        {
            get
            {
                return base.DefaultCellStyle;
            }
            set
            {
                base.DefaultCellStyle = value;
            }
        }

        /// <summary>Gets or sets a string that describes the column's image. </summary>
        /// <returns>The textual description of the column image. The default is <see cref="F:System.String.Empty"></see>.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewImageColumn.CellTemplate"></see> property is null.</exception>
        /// <filterpriority>1</filterpriority>
        [Gizmox.WebGUI.Forms.SRDescription("DataGridViewImageColumn_DescriptionDescr"), Browsable(true), DefaultValue(""), Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
        public string Description
        {
            get
            {
                if (this.CellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.ImageCellTemplate.Description;
            }
            set
            {
                if (this.CellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                this.ImageCellTemplate.Description = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                    int num1 = objCollection1.Count;
                    for (int num2 = 0; num2 < num1; num2++)
                    {
                        DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                        DataGridViewImageCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewImageCell;
                        if (objCell != null)
                        {
                            objCell.Description = value;
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets the icon displayed in the cells of this column when the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCell.Value"></see> property is not set and the cell's <see cref="P:Gizmox.WebGUI.Forms.DataGridViewImageCell.ValueIsIcon"></see> property is set to true.</summary>
        /// <returns>The <see cref="T:System.Drawing.Icon"></see> to display. The default is null.</returns>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ResourceHandle Icon
        {
            get
            {
                return this.mobjIcon;
            }
            set
            {
                if (mobjIcon != value)
                {
                    mobjIcon = value;
                    if (base.DataGridView != null)
                    {
                        base.DataGridView.OnColumnCommonChange(base.Index);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>The image.</value>
        [Gizmox.WebGUI.Forms.SRCategory("CatAppearance"), DefaultValue((string)null), Gizmox.WebGUI.Forms.SRDescription("DataGridViewImageColumn_ImageDescr")]
        public ResourceHandle Image
        {
            get
            {
                return this.mobjImage;
            }
            set
            {
                if (mobjImage != value)
                {
                    mobjImage = value;
                    if (base.DataGridView != null)
                    {
                        base.DataGridView.OnColumnCommonChange(base.Index);
                    }
                }
            }
        }


        private DataGridViewImageCell ImageCellTemplate
        {
            get
            {
                return (DataGridViewImageCell)this.CellTemplate;
            }
        }

        /// <summary>Gets or sets the image layout in the cells for this column.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewImageCellLayout"></see> that specifies the cell layout. The default is <see cref="F:Gizmox.WebGUI.Forms.DataGridViewImageCellLayout.Normal"></see>.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewImageColumn.CellTemplate"></see> property is null. </exception>
        /// <filterpriority>1</filterpriority>
        [Gizmox.WebGUI.Forms.SRDescription("DataGridViewImageColumn_ImageLayoutDescr"), DefaultValue(1), Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
        public DataGridViewImageCellLayout ImageLayout
        {
            get
            {
                if (this.CellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                DataGridViewImageCellLayout layout1 = this.ImageCellTemplate.ImageLayout;
                if (layout1 == DataGridViewImageCellLayout.NotSet)
                {
                    layout1 = DataGridViewImageCellLayout.Normal;
                }
                return layout1;
            }
            set
            {
                if (this.ImageLayout != value)
                {
                    this.ImageCellTemplate.ImageLayout = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewImageCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewImageCell;
                            if (objCell != null)
                            {
                                objCell.ImageLayoutInternal = value;
                            }
                        }
                        base.DataGridView.OnColumnCommonChange(base.Index);
                    }
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether cells in this column display <see cref="T:System.Drawing.Icon"></see> values.</summary>
        /// <returns>true if cells display values of type <see cref="T:System.Drawing.Icon"></see>; false if cells display values of type <see cref="T:System.Drawing.Image"></see>. The default is false.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewImageColumn.CellTemplate"></see> property is null.</exception>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public bool ValuesAreIcons
        {
            get
            {
                if (this.ImageCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.ImageCellTemplate.ValueIsIcon;
            }
            set
            {
                if (this.ValuesAreIcons != value)
                {
                    this.ImageCellTemplate.ValueIsIconInternal = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewImageCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewImageCell;
                            if (objCell != null)
                            {
                                objCell.ValueIsIconInternal = value;
                            }
                        }
                        base.DataGridView.OnColumnCommonChange(base.Index);
                    }
                    if ((value && (this.DefaultCellStyle.NullValue is Bitmap)) && (((ResourceHandle)this.DefaultCellStyle.NullValue) == DataGridViewImageCell.ErrorBitmap))
                    {
                        this.DefaultCellStyle.NullValue = DataGridViewImageCell.ErrorIcon;
                    }
                    else if ((!value && (this.DefaultCellStyle.NullValue is System.Drawing.Icon)) && (((System.Drawing.Icon)this.DefaultCellStyle.NullValue) == DataGridViewImageCell.ErrorIcon))
                    {
                        this.DefaultCellStyle.NullValue = DataGridViewImageCell.ErrorBitmap;
                    }
                }
            }
        }



    }

    #endregion

    #region DataGridViewTextBoxColumn Class

    /// <summary>Hosts a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxCell"></see> cells.</summary>
    /// <filterpriority>2</filterpriority>
    [ToolboxBitmap(typeof(DataGridViewTextBoxColumn), "DataGridViewTextBoxColumn.bmp")]
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewTextBoxColumnController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [Serializable()]
    public class DataGridViewTextBoxColumn : DataGridViewColumn
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn"></see> class to the default state.</summary>
        public DataGridViewTextBoxColumn()
            : this(new DataGridViewTextBoxCell())
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewTextBoxColumn"/> class.
        /// </summary>
        /// <param name="objCellTemplate">The obj cell template.</param>
        protected DataGridViewTextBoxColumn(DataGridViewTextBoxCell objCellTemplate)
            : base(objCellTemplate)
        {
            this.SortMode = DataGridViewColumnSortMode.Automatic;
        }

        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            StringBuilder builder1 = new StringBuilder(0x40);
            builder1.Append("DataGridViewTextBoxColumn { Name=");
            builder1.Append(base.Name);
            builder1.Append(", Index=");
            builder1.Append(base.Index.ToString(CultureInfo.CurrentCulture));
            builder1.Append(" }");
            return builder1.ToString();
        }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        protected override string TypeName
        {
            get
            {
                return TextTypeName;
            }
        }

        /// <summary>Gets or sets the template used to model cell appearance.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after.</returns>
        /// <exception cref="T:System.InvalidCastException">The set type is not compatible with type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewTextBoxCell"></see>. </exception>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if ((value != null) && !(value is DataGridViewTextBoxCell))
                {
                    throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", new object[] { "Gizmox.WebGUI.Forms.DataGridViewTextBoxCell" }));
                }
                base.CellTemplate = value;
            }
        }

        /// <summary>Gets or sets the maximum number of characters that can be entered into the text box.</summary>
        /// <returns>The maximum number of characters that can be entered into the text box; the default value is 32767.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewTextBoxColumn.CellTemplate"></see> property is null.</exception>
        [Gizmox.WebGUI.Forms.SRDescription("DataGridView_TextBoxColumnMaxInputLengthDescr"), DefaultValue(0x7fff), Gizmox.WebGUI.Forms.SRCategory("CatBehavior")]
        public int MaxInputLength
        {
            get
            {
                if (this.TextBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.TextBoxCellTemplate.MaxInputLength;
            }
            set
            {
                if (this.MaxInputLength != value)
                {
                    this.TextBoxCellTemplate.MaxInputLength = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewTextBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewTextBoxCell;
                            if (objCell != null)
                            {
                                objCell.MaxInputLength = value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets the sort mode for the column.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewColumnSortMode"></see> that specifies the criteria used to order the rows based on the cell values in a column.</returns>
        /// <filterpriority>1</filterpriority>

        [DefaultValue(DataGridViewColumnSortMode.Automatic)]
        new public DataGridViewColumnSortMode SortMode
        {
            get
            {
                return base.SortMode;
            }
            set
            {
                base.SortMode = value;
            }
        }

        private DataGridViewTextBoxCell TextBoxCellTemplate
        {
            get
            {
                return (DataGridViewTextBoxCell)this.CellTemplate;
            }
        }


        private const int DATAGRIDVIEWTEXTBOXCOLUMN_maxInputLength = 0x7fff;
    }

    #endregion

    #region DataGridViewButtonColumn Class

    /// <summary>Hosts a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonCell"></see> objects.</summary>
    /// <filterpriority>2</filterpriority>
    [ToolboxBitmap(typeof(DataGridViewButtonColumn), "DataGridViewButtonColumn.bmp")]
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewButtonColumnController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewButtonColumnController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewButtonColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewButtonColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewButtonColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewButtonColumnController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewButtonColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewButtonColumnController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewButtonColumnController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewButtonColumnController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewButtonColumnController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewButtonColumnController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewButtonColumnController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewButtonColumnController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewButtonColumnController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewButtonColumnController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [Serializable()]
    public class DataGridViewButtonColumn : DataGridViewColumn
    {
        private string mstrText;

        private static Type mobjColumnType;

        static DataGridViewButtonColumn()
        {
            DataGridViewButtonColumn.mobjColumnType = typeof(DataGridViewButtonColumn);
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonColumn"></see> class to the default state.</summary>
        public DataGridViewButtonColumn()
            : this(new DataGridViewButtonCell())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewButtonColumn"/> class.
        /// </summary>
        /// <param name="objCellTemplate">The obj cell template.</param>
        protected DataGridViewButtonColumn(DataGridViewButtonCell objCellTemplate)
            : base(objCellTemplate)
        {
            DataGridViewCellStyle objDataGridViewCellStyle = new DataGridViewCellStyle();
            objDataGridViewCellStyle.AlignmentInternal = DataGridViewContentAlignment.MiddleCenter;
            this.DefaultCellStyle = objDataGridViewCellStyle;
        }



        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        protected override string TypeName
        {
            get
            {
                return ButtonTypeName;
            }
        }


        /// <summary>Creates an exact copy of this column.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonColumn"></see>.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewButtonColumn.CellTemplate"></see> property is null. </exception>
        /// <filterpriority>1</filterpriority>

        public override object Clone()
        {
            return base.Clone();
        }

        private bool ShouldSerializeDefaultCellStyle()
        {
            return false;
        }

        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            return base.ToString();
        }


        /// <summary>Gets or sets the template used to create new cells.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after.</returns>
        /// <exception cref="T:System.InvalidCastException">The specified value when setting this property could not be cast to a <see cref="T:Gizmox.WebGUI.Forms.DataGridViewButtonCell"></see>. </exception>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if ((value != null) && !(value is DataGridViewButtonCell))
                {
                    throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", new object[] { "Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell" }));
                }
                base.CellTemplate = value;
            }
        }

        /// <summary>Gets or sets the column's default cell style.</summary>
        /// <returns>The <see cref="T:System.Windows.Forms.DataGridViewCellStyle"></see> to be applied as the default style.</returns>
        [SRCategory("CatAppearance"), SRDescription("DataGridView_ColumnDefaultCellStyleDescr"), Browsable(true)]
        public override DataGridViewCellStyle DefaultCellStyle
        {
            get
            {
                return base.DefaultCellStyle;
            }
            set
            {
                base.DefaultCellStyle = value;
            }
        }

        /// <summary>Gets or sets the flat-style appearance of the button cells in the column.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> value indicating the appearance of the buttons in the column. The default is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Standard"></see>.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewButtonColumn.CellTemplate"></see> property is null. </exception>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatAppearance"), SRDescription("DataGridView_ButtonColumnFlatStyleDescr"), DefaultValue(2)]
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

        /// <summary>Gets or sets the default text displayed on the button cell.</summary>
        /// <returns>A <see cref="T:System.String"></see> that contains the text. The default is <see cref="F:System.String.Empty"></see>.</returns>
        /// <exception cref="T:System.InvalidOperationException">When setting this property, the value of the <see cref="P:System.Windows.Forms.DataGridViewButtonColumn.CellTemplate"></see> property is null. </exception>
        /// <filterpriority>1</filterpriority>
        [SRDescription("DataGridView_ButtonColumnTextDescr"), SRCategory("CatAppearance"), DefaultValue((string)null)]
        public string Text
        {
            get
            {
                return this.mstrText;
            }
            set
            {
                if (!string.Equals(value, this.Text))
                {
                    this.mstrText = value;

                    if (base.DataGridView != null)
                    {
                        if (this.UseColumnTextForButtonValue)
                        {
                            base.DataGridView.OnColumnCommonChange(base.Index);
                        }
                        else
                        {
                            DataGridViewRowCollection objRows = base.DataGridView.Rows;
                            int intCount = objRows.Count;
                            for (int i = 0; i < intCount; i++)
                            {
                                DataGridViewButtonCell objCell = objRows.SharedRow(i).Cells[base.Index] as DataGridViewButtonCell;
                                if ((objCell != null) && objCell.UseColumnTextForButtonValue)
                                {
                                    base.DataGridView.OnColumnCommonChange(base.Index);
                                    return;
                                }
                            }
                            base.DataGridView.InvalidateColumn(base.Index);
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the <see cref="P:System.Windows.Forms.DataGridViewButtonColumn.Text"></see> property value is displayed as the button text for cells in this column.</summary>
        /// <returns>true if the <see cref="P:System.Windows.Forms.DataGridViewButtonColumn.Text"></see> property value is displayed on buttons in the column; false if the <see cref="P:System.Windows.Forms.DataGridViewCell.FormattedValue"></see> property value of each cell is displayed on its button. The default is false.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewButtonColumn.CellTemplate"></see> property is null.</exception>
        [DefaultValue(false), SRCategory("CatAppearance"), SRDescription("DataGridView_ButtonColumnUseColumnTextForButtonValueDescr")]
        public bool UseColumnTextForButtonValue
        {
            get
            {
                if (this.CellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return ((DataGridViewButtonCell)this.CellTemplate).UseColumnTextForButtonValue;
            }
            set
            {
                if (this.UseColumnTextForButtonValue != value)
                {
                    ((DataGridViewButtonCell)this.CellTemplate).UseColumnTextForButtonValueInternal = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objRows = base.DataGridView.Rows;
                        int intCount = objRows.Count;
                        for (int i = 0; i < intCount; i++)
                        {
                            DataGridViewButtonCell objCell = objRows.SharedRow(i).Cells[base.Index] as DataGridViewButtonCell;
                            if (objCell != null)
                            {
                                objCell.UseColumnTextForButtonValueInternal = value;
                            }
                        }
                        base.DataGridView.OnColumnCommonChange(base.Index);
                    }
                }
            }
        }
    }

    #endregion

    #region DataGridViewCheckBoxColumn Class

    /// <summary>Hosts a collection of <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see> objects.</summary>
    /// <filterpriority>2</filterpriority>
    [ToolboxBitmap(typeof(DataGridViewCheckBoxColumn), "DataGridViewCheckBoxColumn.bmp")]
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewCheckBoxColumnController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif
    [Serializable()]
    public class DataGridViewCheckBoxColumn : DataGridViewColumn
    {
        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn"></see> class to the default state.</summary>
        public DataGridViewCheckBoxColumn()
            : this(false)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn"></see> and configures it to display check boxes with two or three states. </summary>
        /// <param name="blnThreeState">true to display check boxes with three states; false to display check boxes with two states. </param>
        public DataGridViewCheckBoxColumn(bool blnThreeState)
            : this(blnThreeState, new DataGridViewCheckBoxCell(blnThreeState))
        {

        }


        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewCheckBoxColumn"/> class.
        /// </summary>
        /// <param name="blnThreeState">if set to <c>true</c> [BLN three state].</param>
        /// <param name="objCellTemplate">The obj cell template.</param>
        protected DataGridViewCheckBoxColumn(bool blnThreeState, DataGridViewCheckBoxCell objCellTemplate)
            : base(objCellTemplate)
        {
            DataGridViewCellStyle objDataGridViewCellStyle = new DataGridViewCellStyle();
            objDataGridViewCellStyle.AlignmentInternal = DataGridViewContentAlignment.MiddleCenter;
            if (blnThreeState)
            {
                objDataGridViewCellStyle.NullValue = CheckState.Indeterminate;
            }
            else
            {
                objDataGridViewCellStyle.NullValue = false;
            }
            this.DefaultCellStyle = objDataGridViewCellStyle;
        }


        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        protected override string TypeName
        {
            get
            {
                return CheckBoxTypeName;
            }
        }

        private bool ShouldSerializeDefaultCellStyle()
        {
            DataGridViewCheckBoxCell objCell = this.CellTemplate as DataGridViewCheckBoxCell;
            if (objCell != null)
            {
                object obj1;
                if (objCell.ThreeState)
                {
                    obj1 = CheckState.Indeterminate;
                }
                else
                {
                    obj1 = false;
                }
                if (!base.HasDefaultCellStyle)
                {
                    return false;
                }
                DataGridViewCellStyle objDataGridViewCellStyle = this.DefaultCellStyle;
                if ((((objDataGridViewCellStyle.BackColor.IsEmpty && objDataGridViewCellStyle.ForeColor.IsEmpty) && (objDataGridViewCellStyle.SelectionBackColor.IsEmpty && objDataGridViewCellStyle.SelectionForeColor.IsEmpty)) && (((objDataGridViewCellStyle.Font == null) && objDataGridViewCellStyle.NullValue.Equals(obj1)) && (objDataGridViewCellStyle.IsDataSourceNullValueDefault && CommonUtils.IsNullOrEmpty(objDataGridViewCellStyle.Format)))) && ((objDataGridViewCellStyle.FormatProvider.Equals(CultureInfo.CurrentCulture) && (objDataGridViewCellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)) && ((objDataGridViewCellStyle.WrapMode == DataGridViewTriState.NotSet) && (objDataGridViewCellStyle.Tag == null))))
                {
                    return !objDataGridViewCellStyle.Padding.Equals(Padding.Empty);
                }
            }
            return true;
        }

        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            StringBuilder builder1 = new StringBuilder(0x40);
            builder1.Append("DataGridViewCheckBoxColumn { Name=");
            builder1.Append(base.Name);
            builder1.Append(", Index=");
            builder1.Append(base.Index.ToString(CultureInfo.CurrentCulture));
            builder1.Append(" }");
            return builder1.ToString();
        }


        /// <summary>Gets or sets the template used to create new cells.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after. The default value is a new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see> instance.</returns>
        /// <exception cref="T:System.InvalidCastException">The property is set to a value that is not of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see>. </exception>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if ((value != null) && !(value is DataGridViewCheckBoxCell))
                {
                    throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", new object[] { "Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell" }));
                }
                base.CellTemplate = value;
            }
        }

        private DataGridViewCheckBoxCell CheckBoxCellTemplate
        {
            get
            {
                return (DataGridViewCheckBoxCell)this.CellTemplate;
            }
        }

        /// <summary>Gets or sets the column's default cell style.</summary>
        /// <returns>The <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCellStyle"></see> to be applied as the default style.</returns>
        [Gizmox.WebGUI.Forms.SRDescription("DataGridView_ColumnDefaultCellStyleDescr"), Gizmox.WebGUI.Forms.SRCategory("CatAppearance"), Browsable(true)]
        public override DataGridViewCellStyle DefaultCellStyle
        {
            get
            {
                return base.DefaultCellStyle;
            }
            set
            {
                base.DefaultCellStyle = value;
            }
        }

        /// <summary>Gets or sets the underlying value corresponding to a cell value of false, which appears as an unchecked box.</summary>
        /// <returns>An <see cref="T:System.Object"></see> representing a value that the cells in this column will treat as a false value. The default is null.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn.CellTemplate"></see> property is null. </exception>
        /// <filterpriority>1</filterpriority>
        [TypeConverter(typeof(StringConverter)), Gizmox.WebGUI.Forms.SRDescription("DataGridView_CheckBoxColumnFalseValueDescr"), DefaultValue((string)null), Gizmox.WebGUI.Forms.SRCategory("CatData")]
        public object FalseValue
        {
            get
            {
                if (this.CheckBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.CheckBoxCellTemplate.FalseValue;
            }
            set
            {
                if (this.FalseValue != value)
                {
                    this.CheckBoxCellTemplate.FalseValueInternal = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewCheckBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewCheckBoxCell;
                            if (objCell != null)
                            {
                                objCell.FalseValueInternal = value;
                            }
                        }
                        base.DataGridView.InvalidateColumn(base.Index);
                    }
                }
            }
        }

        /// <summary>Gets or sets the flat style appearance of the check box cells.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.FlatStyle"></see> value indicating the appearance of cells in the column. The default is <see cref="F:Gizmox.WebGUI.Forms.FlatStyle.Standard"></see>.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn.CellTemplate"></see> property is null. </exception>
        /// <filterpriority>1</filterpriority>
        [Gizmox.WebGUI.Forms.SRDescription("DataGridView_CheckBoxColumnFlatStyleDescr"), DefaultValue(2), Gizmox.WebGUI.Forms.SRCategory("CatAppearance")]
        public FlatStyle FlatStyle
        {
            get
            {
                if (this.CheckBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.CheckBoxCellTemplate.FlatStyle;
            }
            set
            {
                if (this.FlatStyle != value)
                {
                    this.CheckBoxCellTemplate.FlatStyle = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewCheckBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewCheckBoxCell;
                            if (objCell != null)
                            {
                                objCell.FlatStyleInternal = value;
                            }
                        }
                        base.DataGridView.OnColumnCommonChange(base.Index);
                    }
                }
            }
        }

        /// <summary>Gets or sets the underlying value corresponding to an indeterminate or null cell value, which appears as a disabled checkbox.</summary>
        /// <returns>An <see cref="T:System.Object"></see> representing a value that the cells in this column will treat as an indeterminate value. The default is null.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn.CellTemplate"></see> property is null. </exception>
        /// <filterpriority>1</filterpriority>
        [Gizmox.WebGUI.Forms.SRDescription("DataGridView_CheckBoxColumnIndeterminateValueDescr"), Gizmox.WebGUI.Forms.SRCategory("CatData"), TypeConverter(typeof(StringConverter)), DefaultValue((string)null)]
        public object IndeterminateValue
        {
            get
            {
                if (this.CheckBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.CheckBoxCellTemplate.IndeterminateValue;
            }
            set
            {
                if (this.IndeterminateValue != value)
                {
                    this.CheckBoxCellTemplate.IndeterminateValueInternal = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewCheckBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewCheckBoxCell;
                            if (objCell != null)
                            {
                                objCell.IndeterminateValueInternal = value;
                            }
                        }
                        base.DataGridView.InvalidateColumn(base.Index);
                    }
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the hosted check box cells will allow three check states rather than two.</summary>
        /// <returns>true if the hosted <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell"></see> objects are able to have a third, indeterminate, state; otherwise, false. The default is false.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn.CellTemplate"></see> property is null.</exception>
        /// <filterpriority>1</filterpriority>
        [DefaultValue(false), Gizmox.WebGUI.Forms.SRCategory("CatBehavior"), Gizmox.WebGUI.Forms.SRDescription("DataGridView_CheckBoxColumnThreeStateDescr")]
        public bool ThreeState
        {
            get
            {
                if (this.CheckBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.CheckBoxCellTemplate.ThreeState;
            }
            set
            {
                if (this.ThreeState != value)
                {
                    this.CheckBoxCellTemplate.ThreeStateInternal = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewCheckBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewCheckBoxCell;
                            if (objCell != null)
                            {
                                objCell.ThreeStateInternal = value;
                            }
                        }
                        base.DataGridView.InvalidateColumn(base.Index);
                    }
                    if ((value && (this.DefaultCellStyle.NullValue is bool)) && !((bool)this.DefaultCellStyle.NullValue))
                    {
                        this.DefaultCellStyle.NullValue = CheckState.Indeterminate;
                    }
                    else if ((!value && (this.DefaultCellStyle.NullValue is CheckState)) && (((CheckState)this.DefaultCellStyle.NullValue) == CheckState.Indeterminate))
                    {
                        this.DefaultCellStyle.NullValue = false;
                    }
                }
            }
        }

        /// <summary>Gets or sets the underlying value corresponding to a cell value of true, which appears as a checked box.</summary>
        /// <returns>An <see cref="T:System.Object"></see> representing a value that the cell will treat as a true value. The default is null.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewCheckBoxColumn.CellTemplate"></see> property is null.</exception>
        /// <filterpriority>1</filterpriority>
        [Gizmox.WebGUI.Forms.SRDescription("DataGridView_CheckBoxColumnTrueValueDescr"), Gizmox.WebGUI.Forms.SRCategory("CatData"), TypeConverter(typeof(StringConverter)), DefaultValue((string)null)]
        public object TrueValue
        {
            get
            {
                if (this.CheckBoxCellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return this.CheckBoxCellTemplate.TrueValue;
            }
            set
            {
                if (this.TrueValue != value)
                {
                    this.CheckBoxCellTemplate.TrueValueInternal = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objCollection1 = base.DataGridView.Rows;
                        int num1 = objCollection1.Count;
                        for (int num2 = 0; num2 < num1; num2++)
                        {
                            DataGridViewRow objDataGridViewRow1 = objCollection1.SharedRow(num2);
                            DataGridViewCheckBoxCell objCell = objDataGridViewRow1.Cells[base.Index] as DataGridViewCheckBoxCell;
                            if (objCell != null)
                            {
                                objCell.TrueValueInternal = value;
                            }
                        }
                        base.DataGridView.InvalidateColumn(base.Index);
                    }
                }
            }
        }

    }

    #endregion

    #region DataGridViewLinkColumn Class

    /// <summary>Represents a column of cells that contain links in a <see cref="T:Gizmox.WebGUI.Forms.DataGridView"></see> control. </summary>
    /// <filterpriority>2</filterpriority>
    [ToolboxBitmap(typeof(DataGridViewLinkColumn), "DataGridViewLinkColumn.bmp")]
#if WG_NET46
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewLinkColumnController, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewLinkColumnController, Gizmox.WebGUI.Client, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET452
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewLinkColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewLinkColumnController, Gizmox.WebGUI.Client, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET451
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewLinkColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewLinkColumnController, Gizmox.WebGUI.Client, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET45
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewLinkColumnController, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewLinkColumnController, Gizmox.WebGUI.Client, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET40
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewLinkColumnController, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewLinkColumnController, Gizmox.WebGUI.Client, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET35
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewLinkColumnController, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewLinkColumnController, Gizmox.WebGUI.Client, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#elif WG_NET2
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewLinkColumnController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewLinkColumnController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#else
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.DataGidViewLinkColumnController, Gizmox.WebGUI.Forms.Design, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.DataGidViewLinkColumnController, Gizmox.WebGUI.Client, Version=1.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
#endif

    [Serializable()]
    public class DataGridViewLinkColumn : DataGridViewColumn
    {
        private string mstrText;

        private static Type mobjColumnType;

        static DataGridViewLinkColumn()
        {
            DataGridViewLinkColumn.mobjColumnType = typeof(DataGridViewLinkColumn);
        }

        /// <summary>Initializes a new instance of the <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkColumn"></see> class. </summary>
        public DataGridViewLinkColumn()
            : this(new DataGridViewLinkCell())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewLinkColumn"/> class.
        /// </summary>
        /// <param name="objCellTemplate">The obj cell template.</param>
        protected DataGridViewLinkColumn(DataGridViewLinkCell objCellTemplate)
            : base(objCellTemplate)
        {
        }


        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>The name of the type.</value>
        protected override string TypeName
        {
            get
            {
                return LinkTypeName;
            }
        }

        /// <summary>Creates an exact copy of this column.</summary>
        /// <returns>An <see cref="T:System.Object"></see> that represents the cloned <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkColumn"></see>.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:Gizmox.WebGUI.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null. </exception>
        public override object Clone()
        {
            return base.Clone();
        }

        private bool ShouldSerializeActiveLinkColor()
        {
            return !this.ActiveLinkColor.Equals(LinkUtilities.IEActiveLinkColor);
        }

        private bool ShouldSerializeLinkColor()
        {
            return !this.LinkColor.Equals(LinkUtilities.IELinkColor);
        }

        private bool ShouldSerializeVisitedLinkColor()
        {
            return !this.VisitedLinkColor.Equals(LinkUtilities.IEVisitedLinkColor);
        }

        /// <filterpriority>1</filterpriority>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(0x40);
            builder.Append("DataGridViewLinkColumn { Name=");
            builder.Append(base.Name);
            builder.Append(", Index=");
            builder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
            builder.Append(" }");
            return builder.ToString();
        }

        /// <summary>Gets or sets the color used to display an active link within cells in the column. </summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to display a link that is being selected. The default value is the user's Internet Explorer setting for the color of links in the hover state.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
        [SRDescription("DataGridView_LinkColumnActiveLinkColorDescr"), SRCategory("CatAppearance")]
        public Color ActiveLinkColor
        {
            get
            {
                if (this.CellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return ((DataGridViewLinkCell)this.CellTemplate).ActiveLinkColor;
            }
            set
            {
                if (!this.ActiveLinkColor.Equals(value))
                {
                    ((DataGridViewLinkCell)this.CellTemplate).ActiveLinkColorInternal = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objRows = base.DataGridView.Rows;
                        int intCount = objRows.Count;
                        for (int i = 0; i < intCount; i++)
                        {
                            DataGridViewLinkCell objCell = objRows.SharedRow(i).Cells[base.Index] as DataGridViewLinkCell;
                            if (objCell != null)
                            {
                                objCell.ActiveLinkColorInternal = value;
                            }
                        }
                        base.DataGridView.InvalidateColumn(base.Index);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DataGridViewLinkCell"/> is URL.
        /// </summary>
        /// <value><c>true</c> if URL; otherwise, <c>false</c>.</value>
        [SRDescription("DataGridView_LinkColumnUrlDescr"), SRCategory("CatData")]
        public string Url
        {
            get
            {
                if (this.CellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return ((DataGridViewLinkCell)this.CellTemplate).Url;
            }
            set
            {
                //If the value has changed
                if (this.Url != value)
                {
                    // Assign the value to the cell template
                    if (this.CellTemplate == null)
                    {
                        throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                    }
                    ((DataGridViewLinkCell)this.CellTemplate).Url = value;

                    // Assign the new value to the items in the column.
                    if (base.DataGridView != null)
                    {
                        // Create a collection from the corresponding DataGridView.
                        DataGridViewRowCollection objRowCollection = base.DataGridView.Rows;
                        int intRowCount = objRowCollection.Count;
                        // Iterate through the items in the column and assign the new value to them.
                        for (int i = 0; i < intRowCount; i++)
                        {
                            DataGridViewLinkCell objCell = objRowCollection.SharedRow(i).Cells[base.Index] as DataGridViewLinkCell;
                            if (objCell != null)
                            {
                                objCell.Url = value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets the template used to create new cells.</summary>
        /// <returns>A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewCell"></see> that all other cells in the column are modeled after. The default value is a new <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkCell"></see> instance.</returns>
        /// <exception cref="T:System.InvalidCastException">When setting this property to a value that is not of type <see cref="T:Gizmox.WebGUI.Forms.DataGridViewLinkCell"></see>.</exception>
        /// <filterpriority>1</filterpriority>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if ((value != null) && !(value is DataGridViewLinkCell))
                {
                    throw new InvalidCastException(SR.GetString("DataGridViewTypeColumn_WrongCellTemplateType", new object[] { "Gizmox.WebGUI.Forms.DataGridViewCheckBoxCell" }));
                }
                base.CellTemplate = value;
            }
        }

        /// <summary>Gets or sets a value that represents the behavior of links within cells in the column.</summary>
        /// <returns>A <see cref="T:System.Windows.Forms.LinkBehavior"></see> value indicating the link behavior. The default is <see cref="F:System.Windows.Forms.LinkBehavior.SystemDefault"></see>.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatBehavior"), DefaultValue(0), SRDescription("DataGridView_LinkColumnLinkBehaviorDescr")]
        public LinkBehavior LinkBehavior
        {
            get
            {
                if (this.CellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return ((DataGridViewLinkCell)this.CellTemplate).LinkBehavior;
            }
            set
            {
                if (!this.LinkBehavior.Equals(value))
                {
                    ((DataGridViewLinkCell)this.CellTemplate).LinkBehavior = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objRows = base.DataGridView.Rows;
                        int intCount = objRows.Count;
                        for (int i = 0; i < intCount; i++)
                        {
                            DataGridViewLinkCell objCell = objRows.SharedRow(i).Cells[base.Index] as DataGridViewLinkCell;
                            if (objCell != null)
                            {
                                objCell.LinkBehaviorInternal = value;
                            }
                        }
                        base.DataGridView.InvalidateColumn(base.Index);
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the ClientMode value of it's cell template.
        /// Setter sets the value to it's cell template as well as to all cells in the column. 
        /// </summary>
        /// <value><c>true</c> if [client mode]; otherwise, <c>false</c>.</value>
        [SRDescription("DataGridView_LinkColumnClientModeDescr"), SRCategory("CatBehavior")]
        public bool ClientMode
        {
            get
            {
                if (this.CellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return ((DataGridViewLinkCell)this.CellTemplate).ClientMode;
            }
            set
            {
                if (this.ClientMode != value)
                {
                    // Assign the value to the cell template
                    if (this.CellTemplate == null)
                    {
                        throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                    }
                    ((DataGridViewLinkCell)this.CellTemplate).ClientMode = value;

                    // Assign the new value to the items in the column.
                    if (base.DataGridView != null)
                    {
                        // Create a collection from the corresponding DataGridView.
                        DataGridViewRowCollection objRowCollection = base.DataGridView.Rows;
                        int intRowCount = objRowCollection.Count;
                        // Iterate through the items in the column and assign the new value to them.
                        for (int i = 0; i < intRowCount; i++)
                        {
                            DataGridViewLinkCell objCell = objRowCollection.SharedRow(i).Cells[base.Index] as DataGridViewLinkCell;
                            if (objCell != null)
                            {
                                objCell.ClientMode = value;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets the color used to display an unselected link within cells in the column.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to initially display a link. The default value is the user's Internet Explorer setting for the link color. </returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
        [SRCategory("CatAppearance"), SRDescription("DataGridView_LinkColumnLinkColorDescr")]
        public Color LinkColor
        {
            get
            {
                if (this.CellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return ((DataGridViewLinkCell)this.CellTemplate).LinkColor;
            }
            set
            {
                if (!this.LinkColor.Equals(value))
                {
                    ((DataGridViewLinkCell)this.CellTemplate).LinkColorInternal = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objRows = base.DataGridView.Rows;
                        int intCount = objRows.Count;
                        for (int i = 0; i < intCount; i++)
                        {
                            DataGridViewLinkCell objCell = objRows.SharedRow(i).Cells[base.Index] as DataGridViewLinkCell;
                            if (objCell != null)
                            {
                                objCell.LinkColorInternal = value;
                            }
                        }
                        base.DataGridView.InvalidateColumn(base.Index);
                    }
                }
            }
        }

        /// <summary>Gets or sets the link text displayed in a column's cells if <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.UseColumnTextForLinkValue"></see> is true.</summary>
        /// <returns>A <see cref="T:System.String"></see> containing the link text.</returns>
        /// <exception cref="T:System.InvalidOperationException">When setting this property, the value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
        /// <filterpriority>1</filterpriority>
        [SRCategory("CatAppearance"), SRDescription("DataGridView_LinkColumnTextDescr"), DefaultValue((string)null)]
        public string Text
        {
            get
            {
                return this.mstrText;
            }
            set
            {
                //TODO:SHLOMI
                if (!string.Equals(value, this.Text, StringComparison.Ordinal))
                {
                    this.mstrText = value;
                    if (base.DataGridView != null)
                    {
                        if (this.UseColumnTextForLinkValue)
                        {
                            base.DataGridView.OnColumnCommonChange(base.Index);
                        }
                        else
                        {
                            DataGridViewRowCollection objRows = base.DataGridView.Rows;
                            int intCount = objRows.Count;
                            for (int i = 0; i < intCount; i++)
                            {
                                DataGridViewLinkCell objCell = objRows.SharedRow(i).Cells[base.Index] as DataGridViewLinkCell;
                                if ((objCell != null) && objCell.UseColumnTextForLinkValue)
                                {
                                    base.DataGridView.OnColumnCommonChange(base.Index);
                                    return;
                                }
                            }
                            base.DataGridView.InvalidateColumn(base.Index);
                        }
                    }
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the link changes color if it has been visited.</summary>
        /// <returns>true if the link changes color when it is selected; otherwise, false. The default is true.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
        /// <filterpriority>1</filterpriority>
        [SRDescription("DataGridView_LinkColumnTrackVisitedStateDescr"), SRCategory("CatBehavior"), DefaultValue(true)]
        public bool TrackVisitedState
        {
            get
            {
                if (this.CellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return ((DataGridViewLinkCell)this.CellTemplate).TrackVisitedState;
            }
            set
            {
                if (this.TrackVisitedState != value)
                {
                    ((DataGridViewLinkCell)this.CellTemplate).TrackVisitedStateInternal = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objRows = base.DataGridView.Rows;
                        int intCount = objRows.Count;
                        for (int i = 0; i < intCount; i++)
                        {
                            DataGridViewLinkCell objCell = objRows.SharedRow(i).Cells[base.Index] as DataGridViewLinkCell;
                            if (objCell != null)
                            {
                                objCell.TrackVisitedStateInternal = value;
                            }
                        }
                        base.DataGridView.InvalidateColumn(base.Index);
                    }
                }
            }
        }

        /// <summary>Gets or sets a value indicating whether the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.Text"></see> property value is displayed as the link text.</summary>
        /// <returns>true if the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.Text"></see> property value is displayed as the link text; false if the cell <see cref="P:System.Windows.Forms.DataGridViewCell.FormattedValue"></see> property value is displayed as the link text. The default is false.</returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
        [DefaultValue(false), SRDescription("DataGridView_LinkColumnUseColumnTextForLinkValueDescr"), SRCategory("CatAppearance")]
        public bool UseColumnTextForLinkValue
        {
            get
            {
                if (this.CellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return ((DataGridViewLinkCell)this.CellTemplate).UseColumnTextForLinkValue;
            }
            set
            {
                if (this.UseColumnTextForLinkValue != value)
                {
                    ((DataGridViewLinkCell)this.CellTemplate).UseColumnTextForLinkValueInternal = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objRows = base.DataGridView.Rows;
                        int intCount = objRows.Count;
                        for (int i = 0; i < intCount; i++)
                        {
                            DataGridViewLinkCell objCell = objRows.SharedRow(i).Cells[base.Index] as DataGridViewLinkCell;
                            if (objCell != null)
                            {
                                objCell.UseColumnTextForLinkValueInternal = value;
                            }
                        }
                        base.DataGridView.OnColumnCommonChange(base.Index);
                    }
                }
            }
        }

        /// <summary>Gets or sets the color used to display a link that has been previously visited.</summary>
        /// <returns>A <see cref="T:System.Drawing.Color"></see> that represents the color used to display a link that has been visited. The default value is the user's Internet Explorer setting for the visited link color. </returns>
        /// <exception cref="T:System.InvalidOperationException">The value of the <see cref="P:System.Windows.Forms.DataGridViewLinkColumn.CellTemplate"></see> property is null.</exception>
        /// <filterpriority>1</filterpriority>
        /// <PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode" /></PermissionSet>
        [SRDescription("DataGridView_LinkColumnVisitedLinkColorDescr"), SRCategory("CatAppearance")]
        public Color VisitedLinkColor
        {
            get
            {
                if (this.CellTemplate == null)
                {
                    throw new InvalidOperationException(SR.GetString("DataGridViewColumn_CellTemplateRequired"));
                }
                return ((DataGridViewLinkCell)this.CellTemplate).VisitedLinkColor;
            }
            set
            {
                if (!this.VisitedLinkColor.Equals(value))
                {
                    ((DataGridViewLinkCell)this.CellTemplate).VisitedLinkColorInternal = value;
                    if (base.DataGridView != null)
                    {
                        DataGridViewRowCollection objRows = base.DataGridView.Rows;
                        int intCount = objRows.Count;
                        for (int i = 0; i < intCount; i++)
                        {
                            DataGridViewLinkCell objCell = objRows.SharedRow(i).Cells[base.Index] as DataGridViewLinkCell;
                            if (objCell != null)
                            {
                                objCell.VisitedLinkColorInternal = value;
                            }
                        }
                        base.DataGridView.InvalidateColumn(base.Index);
                    }
                }
            }
        }
    }
    #endregion
}
