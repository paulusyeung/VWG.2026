using System;
using System.Collections.Generic;

using System.Web;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [ToolboxItem(false)]
    public class ExtendedColumnHeaders
    {
        private bool mblnExtendedColumnHeaderVisible = false;
        private ObservableCollection<ExtendedHeaderRowData> mobjExtendedHeaderRows;
        private DataGridView mobjDataGridView;
        private ObservableCollection<ExtendedHeaderUserControl> mobjHeaderControls;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtendedColumnHeaders"/> class.
        /// </summary>
        /// <param name="objDataGridView">The obj data grid view.</param>
        public ExtendedColumnHeaders(DataGridView objDataGridView)
        {
            mobjDataGridView = objDataGridView;
            InitRowsData();
        }

        /// <summary>
        /// Inits the rows data.
        /// </summary>
        private void InitRowsData()
        {
            mobjExtendedHeaderRows = new ObservableCollection<ExtendedHeaderRowData>();
            mobjExtendedHeaderRows.CollectionChanged += new NotifyCollectionChangedEventHandler(mobjExtendedHeaderRows_CollectionChanged);
        }

        /// <summary>
        /// Handles the CollectionChanged event of the mobjExtendedHeaderRows control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        void mobjExtendedHeaderRows_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (mobjDataGridView != null)
            {
                mobjDataGridView.Update();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [extended column header visible].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [extended column header visible]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        public bool ShowExtendedColumnHeader
        {
            get
            {
                return mblnExtendedColumnHeaderVisible;
            }
            set
            {
                if (mblnExtendedColumnHeaderVisible != value)
                {
                    mblnExtendedColumnHeaderVisible = value;
                    mobjDataGridView.Update();
                }
            }
        }

        /// <summary>
        /// Gets or sets the extended header rows data and number.
        /// </summary>
        /// <value>
        /// The extended header rows.
        /// </value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ObservableCollection<ExtendedHeaderRowData> Rows
        {
            get 
            { 
                return mobjExtendedHeaderRows; 
            }
            set
            {
                mobjExtendedHeaderRows = value;
            }
        }


        /// <summary>
        /// Gets or sets the extended column header cell panels main collection.
        /// </summary>
        /// <value>
        /// The extended column header cell panels.
        /// </value>
        [DefaultValue(null), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
#if WG_NET46
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExtendedHeaderUserControlCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.6.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET452
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExtendedHeaderUserControlCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET451
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExtendedHeaderUserControlCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.15701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET45
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExtendedHeaderUserControlCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.5.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET40
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExtendedHeaderUserControlCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=4.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET35
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExtendedHeaderUserControlCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=3.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#elif WG_NET2
        [Editor("Gizmox.WebGUI.Forms.Design.Editors.ExtendedHeaderUserControlCollectionEditor, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769", typeof(System.Drawing.Design.UITypeEditor))]
#endif
        public ObservableCollection<ExtendedHeaderUserControl> HeaderControls
        {
            get 
            {
                if (mobjHeaderControls == null)
                {
                    mobjHeaderControls = new ObservableCollection<ExtendedHeaderUserControl>();
                    mobjHeaderControls.CollectionChanged += new NotifyCollectionChangedEventHandler(mobjHeaderControls_CollectionChanged);
                }

                return mobjHeaderControls;
            }
        }

        /// <summary>
        /// Handles the CollectionChanged event of the mobjHeaderControls control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        void mobjHeaderControls_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            DataGridView objGridViewReference = null;
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                objGridViewReference = this.mobjDataGridView;
            }

            if (e.NewItems != null)
            {
                foreach (ExtendedHeaderUserControl objExtendedHeaderControl in e.NewItems)
                {
                    objExtendedHeaderControl.ParentGrid = objGridViewReference;
                }
            }
        }
    }
}