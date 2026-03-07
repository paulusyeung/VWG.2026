using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Forms.Skins;
using Gizmox.WebGUI.Common.Interfaces;
using System.ComponentModel;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Skin(typeof(VirtualDataGridViewSkin))]
#if WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
    [ToolboxBitmap(typeof(VirtualDataGridView), "VirtualDataGridView_45.png")]
#else
    [ToolboxBitmap(typeof(VirtualDataGridView), "VirtualDataGridView.png")]
#endif
    [Serializable]
    public class VirtualDataGridView : DataGridView
    {
        #region Constructors (1)

        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualDataGridView"/> class.
        /// </summary>
        public VirtualDataGridView()
            : base()
        {
            this.UseInternalPaging = false;
        }

        #endregion Constructors

        #region Properties (2)

        /// <summary>
        /// Gets a value indicating whether this instance is virtual.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is virtual; otherwise, <c>false</c>.
        /// </value>
        [EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        protected override bool IsVirtualDataGridView
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Uses internal paging algorithem
        /// </summary>
        [System.ComponentModel.DefaultValue(false)]
        public override bool UseInternalPaging
        {
            get
            {
                return base.UseInternalPaging;
            }
            set
            {
                base.UseInternalPaging = value;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.DataGridView.DataBindingComplete"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:Gizmox.WebGUI.Forms.DataGridViewBindingCompleteEventArgs"></see> that contains the event data.</param>
        protected override void OnDataBindingComplete(DataGridViewBindingCompleteEventArgs e)
        {
            base.OnDataBindingComplete(e);

            if (e.ListChangedType == ListChangedType.Reset)
            {
                // Initialize scroll positions.
                this.SetScrollTop(0);
                this.SetScrollLeft(0);
            }
        }

        /// <summary>
        /// Performs scroll into view.
        /// </summary>
        /// <param name="objDataGridViewCell">The data grid view cell.</param>
        public override void ScrollIntoView(DataGridViewCell objDataGridViewCell)
        {
            // Not implemented for VirtualDataGridView, which needs to ensure the data block is on client before scrolling to it.
            throw new NotImplementedException();
        }

        #endregion
    }
}
