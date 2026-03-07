using System;
using System.Collections.Generic;

using System.Web;
using Gizmox.WebGUI.Forms;
using System.ComponentModel;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Forms.Skins;
using System.ComponentModel.Design.Serialization;
using System.Reflection;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// Enumaration for Cell Type of Extended Header, mostly by its position
    /// </summary>
    public enum ExtendedHeaderCellType
    {
        /// <summary>
        /// 
        /// </summary>
        Headers = 0,
        /// <summary>
        /// 
        /// </summary>
        Corner = 1,
        /// <summary>
        /// 
        /// </summary>
        Expand = 2,
    }

    
    /// <summary>
    /// Base User Control contained by the Exptended Header Cell
    /// </summary>
    [Serializable]
    [ToolboxItem(false)]
    [TypeConverter(typeof(ExtendedHeaderUserControlTypeConverter))]
    public class ExtendedHeaderUserControl : UserControl
    {
        private int mintColSpan = 1;
        private int mintColIndex;
        private int mintRowSpan = 1;
        private int mintRowIndex;
        private DataGridView mobjParentDataGrid;
        private ExtendedHeaderCellType menmExtendedHeaderCellType;

        /// <summary>
        /// Gets or sets the type of the extended panel.
        /// </summary>
        /// <value>
        /// The type of the extended panel.
        /// </value>
        [DefaultValue(ExtendedHeaderCellType.Headers)]
        [Category("Header layout")]
        public ExtendedHeaderCellType ExtendedHeaderCellType
        {
            get 
            {
                return menmExtendedHeaderCellType; 
            }
            set 
            {
                if (menmExtendedHeaderCellType != value)
                {
                    menmExtendedHeaderCellType = value;

                    UpdateGrid();
                }
            }
        }

        /// <summary>
        /// Gets or sets the index of the row.
        /// </summary>
        /// <value>
        /// The index of the row.
        /// </value>
        [Category("Header layout")]
        [DefaultValue(0)]
        public int RowIndex
        {
            get { return mintRowIndex; }
            set { mintRowIndex = value; }
        }

        /// <summary>
        /// Gets or sets the row span.
        /// </summary>
        /// <value>
        /// The row span.
        /// </value>
        [Category("Header layout")]
        [DefaultValue(1)]
        public int RowSpan
        {
            get { return mintRowSpan; }
            set
            {
                if (mintRowSpan != value)
                {
                    mintRowSpan = value;
                    UpdateGrid();

                }
            }
        }

        /// <summary>
        /// Gets or sets the index of the column.
        /// </summary>
        /// <value>
        /// The index of the col.
        /// </value>
        [Category("Header layout")]
        [DefaultValue(0)]
        public int ColIndex
        {
            get { return mintColIndex; }
            set
            {
                mintColIndex = value;
            }
        }

        /// <summary>
        /// Gets or sets the col span.
        /// </summary>
        /// <value>
        /// The col span.
        /// </value>
        [Category("Header layout")]
        [DefaultValue(1)]
        public int ColSpan
        {
            get { return mintColSpan; }
            set
            {
                if (mintColSpan != value)
                {
                    mintColSpan = value;
                    UpdateGrid();
                }
            }
        }

        /// <summary>
        /// Gets controls docking style as Fill 
        /// </summary>
        public override DockStyle Dock
        {
            get
            {
                return DockStyle.Fill;
            }
            set
            { }
        }
        
        /// <summary>
        /// Gets or sets the parent grid.
        /// </summary>
        /// <value>
        /// The parent grid.
        /// </value>
        [Browsable(false)]
        internal DataGridView ParentGrid
        {
            get { return mobjParentDataGrid; }
            set { mobjParentDataGrid = value; }
        }

 

        /// <summary>
        /// Checks if the current control needs rendering and
        /// continues to process sub tree/
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        /// <param name="lngRequestID"></param>
        protected internal override void RenderControl(IContext objContext, IResponseWriter objWriter, long lngRequestID)
        {
            //Get the number of unvisible columns inside extended header span range
            int intHiddenContainingColumns = UnvisibleContainingColumnsCount();

            //Only if current user control is set on span bigger than invisible col num, it will be shown on grid and should be rendered.
            //Also if current user control is set on Corner or Expand columns, it should be rendered.
            if (mintColSpan > intHiddenContainingColumns || this.ExtendedHeaderCellType != Forms.ExtendedHeaderCellType.Headers)
            {
                base.RenderControl(objContext, objWriter, lngRequestID);
            }
        }

        /// <summary>
        /// Get the number of unvisible columns position in the column range of the user control's extended header
        /// </summary>
        /// <returns></returns>
        private int UnvisibleContainingColumnsCount()
        {
            //Inilialize counter
            int intHiddenContainingColumnsCount = 0;

            //Go thrught all columns from the usercontrol's col index till the index of the end of its span
            for (int i = ColIndex; i < ColIndex + mintColSpan; i++)
            {
                //If a column in the range is not visible, add it to the counter
                if (!ParentGrid.Columns[i].Visible)
                {
                    intHiddenContainingColumnsCount++;
                }
            }

            return intHiddenContainingColumnsCount;
        }

        /// <summary>
        /// Get the number of unvisible columns position before the user control's column index.
        /// </summary>
        /// <returns></returns>
        private int UnvisiblePrecedingColumnsCount()
        {
            //Inilialize counter
            int intHiddenContainingColumnsCount = 0;

            //Go thrught all columns from the start of the grid till the usercontrol's col index
            for (int i = 0; i < ColIndex; i++)
            {
                //If a column in the range is not visible, add it to the counter
                if (!ParentGrid.Columns[i].Visible)
                {
                    intHiddenContainingColumnsCount++;
                }
            }

            return intHiddenContainingColumnsCount;
        }

        /// <summary>
        /// Renders the attributes.
        /// </summary>
        /// <param name="objContext">The obj context.</param>
        /// <param name="objWriter">The obj writer.</param>
        protected override void RenderAttributes(IContext objContext, IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            //Render Header Cell Type for user controls for all unique types, such as Corner, Expand etc (and in single cmd = different than Headers
            if (this.ExtendedHeaderCellType != Forms.ExtendedHeaderCellType.Headers)
            {
                objWriter.WriteAttributeString(WGAttributes.ExtendedPanelType, ((int)ExtendedHeaderCellType).ToString());
            }

            else //For all header's user control in general columns area
            {
                //Get counts of invisible columns, before current column index and in span range
                int intHiddenPrecedingColumns = UnvisiblePrecedingColumnsCount();
                int intHiddenContainingColumns = UnvisibleContainingColumnsCount();

                //Render column span, reducing number of invisible columns inside span range
                if (mintColSpan > 1)
                {
                    objWriter.WriteAttributeString(WGAttributes.Colspan, (mintColSpan - intHiddenContainingColumns).ToString());
                }

                //Render column index value, calculatedafter reducing number of invisible columns preceding current index
                objWriter.WriteAttributeString(WGAttributes.ColumnIndex, (ColIndex - intHiddenPrecedingColumns).ToString());
            }

            //Render row span (only if different than default 1 value)
            if (mintRowSpan > 1)
            {
                objWriter.WriteAttributeString(WGAttributes.Rowspan, mintRowSpan.ToString());
            }

            //Render row index value
            objWriter.WriteAttributeString(WGAttributes.RowIndex, mintRowIndex.ToString());
        }

        /// <summary>
        /// Updates the grid.
        /// </summary>
        protected void UpdateGrid()
        {
            if (mobjParentDataGrid != null)
            {
                mobjParentDataGrid.Update();
            }
        }
    }
}