using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
namespace Gizmox.WebGUI.Forms
{
    public delegate void RowExpandingEventHandler(object sender, RowExpandingEventArgs e);
    public delegate void RowCollapsingEventHandler(object sender, RowCollapsingEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class RowCollapsingEventArgs : CancelEventArgs
    {
        private DataGridViewRow mobjCollapsingRow;

        /// <summary>
        /// Initializes a new instance of the <see cref="RowCollapsingEventArgs"/> class.
        /// </summary>
        /// <param name="objCollapsingRow">The obj expanding row.</param>
        public RowCollapsingEventArgs(DataGridViewRow objCollapsingRow)
        {
            this.mobjCollapsingRow = objCollapsingRow;
        }

        /// <summary>
        /// Gets the expanding row.
        /// </summary>
        public DataGridViewRow CollapsingRow
        {
            get { return mobjCollapsingRow; }
        }
    }
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class RowExpandingEventArgs : EventArgs
    {
        private bool mblnCancel;
        private DataGridViewRow mobjExpandingRow;

        /// <summary>
        /// Initializes a new instance of the <see cref="RowExpandingEventArgs"/> class.
        /// </summary>
        /// <param name="objExpandingRow">The obj expanding row.</param>
        public RowExpandingEventArgs(DataGridViewRow objExpandingRow)
        {
            this.mobjExpandingRow = objExpandingRow;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="RowExpandingEventArgs"/> is cancel.
        /// </summary>
        /// <value>
        ///   <c>true</c> if cancel; otherwise, <c>false</c>.
        /// </value>
        public bool Cancel
        {
            get { return mblnCancel; }
            set { mblnCancel = value; }
        }

        /// <summary>
        /// Gets the expanding row.
        /// </summary>
        public DataGridViewRow ExpandingRow
        {
            get { return mobjExpandingRow; }
        }
    }

    public delegate void RowExpandedEventHandler(object sender, RowExpandedEventArgs e);
    public delegate void RowCollapsedEventHandler(object sender, RowCollapsedEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class RowCollapsedEventArgs : EventArgs
    {
        private DataGridViewRow mobjRow;

        /// <summary>
        /// Initializes a new instance of the <see cref="RowCollapsedEventArgs"/> class.
        /// </summary>
        /// <param name="objRow">The obj row.</param>
        public RowCollapsedEventArgs(DataGridViewRow objRow)
        {
            mobjRow = objRow;
        }

        /// <summary>
        /// Gets or sets the collapsed row.
        /// </summary>
        /// <value>
        /// The collapsed row.
        /// </value>
        public DataGridViewRow CollapsedRow
        {
            get { return mobjRow; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class RowExpandedEventArgs : EventArgs
    {
        private DataGridViewRow mobjExpandedRow;

        /// <summary>
        /// Initializes a new instance of the <see cref="RowExpandedEventArgs"/> class.
        /// </summary>
        /// <param name="objExpandingRow">The obj expanding row.</param>
        public RowExpandedEventArgs(DataGridViewRow objExpandingRow)
        {
            this.mobjExpandedRow = objExpandingRow;
        }

        /// <summary>
        /// Gets the expanding row.
        /// </summary>
        public DataGridViewRow ExpandedRow
        {
            get { return mobjExpandedRow; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.HierarchicDataGridViewCreatedEventArgs"/> instance containing the event data.</param>
    public delegate void HierarchicDataGridViewCreatedEventHandler(object sender, HierarchicDataGridViewCreatedEventArgs e);

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class HierarchicDataGridViewCreatedEventArgs : EventArgs
    {
        private HierarchicDataGridView objNewlyCreatedGrid;

        /// <summary>
        /// Gets the newly created grid.
        /// </summary>
        public HierarchicDataGridView NewlyCreatedGrid
        {
            get
            {
                return objNewlyCreatedGrid;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HierarchicDataGridViewCreatedEventArgs"/> class.
        /// </summary>
        /// <param name="objNewGrid">The obj new grid.</param>
        public HierarchicDataGridViewCreatedEventArgs(HierarchicDataGridView objNewGrid)
        {
            objNewlyCreatedGrid = objNewGrid;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [ToolboxItem(false)]
    public class HierarchicDataGridView : DataGridView
    {
        #region Private Members

        private DataGridViewRow objContainingRow;

        #endregion

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="HierarchicDataGridView"/> class.
        /// </summary>
        public HierarchicDataGridView()
        { }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the columns visibility according to the column chooser.
        /// </summary>
        /// <param name="objDialog">The obj dialog.</param>
        internal override void UpdateColumnsVisibility(ColumnChooserDialog objDialog)
        {
            UpdateSingleHierarchyColumnsVisibility(this.ContainingRow.RelatedHierarchyInfo, objDialog.ChosenRootColumns);

            UpdateChildGridColumnsVisibility(objDialog);
        }

        #endregion Methods

        #region Properties

        /// <summary>
        /// Gets or sets the containing row.
        /// </summary>
        /// <value>
        /// The containing row.
        /// </value>
        public DataGridViewRow ContainingRow
        {
            get
            {
                return this.objContainingRow;
            }
            internal set
            {
                this.objContainingRow = value;
            }
        }

        #endregion

        #region Rendering
        protected override void RenderAttributes(Common.Interfaces.IContext objContext, Common.Interfaces.IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            // Render Margins for Hierarchic (child) grid
            Padding objMargin = this.GetProxyPropertyValue<Padding>("Margin", this.Margin);
            // If the margin property has content.
            if (objMargin != this.DefaultMargin)
            {
                if (objMargin.IsAll)
                {
                    if (objMargin.All != 0) objWriter.WriteAttributeString(WGAttributes.MarginAll, objMargin.All.ToString());
                }
                else
                {
                    objWriter.WriteAttributeString(WGAttributes.MarginTop, objMargin.Top.ToString());
                    if (objMargin.Right != 0) objWriter.WriteAttributeString(WGAttributes.MarginRight, objMargin.Right.ToString());
                    if (objMargin.Bottom != 0) objWriter.WriteAttributeString(WGAttributes.MarginBottom, objMargin.Bottom.ToString());
                    if (objMargin.Left != 0) objWriter.WriteAttributeString(WGAttributes.MarginLeft, objMargin.Left.ToString());
                }
            }
        }
        #endregion
    }
}
