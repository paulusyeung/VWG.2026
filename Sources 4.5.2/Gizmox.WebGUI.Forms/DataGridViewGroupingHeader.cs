#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace Gizmox.WebGUI.Forms
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [ToolboxItem(false)]
    public partial class DataGridViewGroupingHeader : UserControl
    {
        #region Members

        private string mstrDataPropertyName = string.Empty;
        private string mstrCurrentValue = string.Empty;
        private BindingSource mobjRowBindingSource = null;
        private DataGridViewRow mobjOwnerRow = null;

        #endregion Members

        #region C'tors

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewGroupingHeader"/> class.
        /// </summary>
        public DataGridViewGroupingHeader()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewGroupingHeader"/> class.
        /// </summary>
        /// <param name="strDataPropertyName">Name of the STR data property.</param>
        /// <param name="strCurrentValue">The STR current value.</param>
        /// <param name="objRowBindingSource">The obj row binding source.</param>
        public DataGridViewGroupingHeader(string strDataPropertyName, string strCurrentValue, BindingSource objRowBindingSource, DataGridViewRow objRow)
            : this()
        {
            this.mobjOwnerRow = objRow;
            this.InitializeHeader(strDataPropertyName, strCurrentValue, objRowBindingSource);
        }

        #endregion C'tors

        #region Methods

        /// <summary>
        /// Initializes the header.
        /// </summary>
        /// <param name="strDataPropertyName">Name of the STR data property.</param>
        /// <param name="strCurrentValue">The STR current value.</param>
        /// <param name="objRowBindingSource">The obj row binding source.</param>
        private void InitializeHeader(string strDataPropertyName, string strCurrentValue, BindingSource objRowBindingSource)
        {
            mstrDataPropertyName = strDataPropertyName;
            mstrCurrentValue = strCurrentValue;
            mobjRowBindingSource = objRowBindingSource;

            UpdateHeader();

            if (mobjRowBindingSource != null)
            {
                mobjRowBindingSource.ListChanged += new ListChangedEventHandler(OnListChanged);
            }

        }

        /// <summary>
        /// Handles the ListChanged event of the objRowBindingSource control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.ListChangedEventArgs"/> instance containing the event data.</param>
        void OnListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateHeader();
        }

        /// <summary>
        /// Updates the header.
        /// </summary>
        private void UpdateHeader()
        {

            int intCount = mobjRowBindingSource != null ? mobjRowBindingSource.Count : -1;

            if (mobjOwnerRow.DataGridView != null)
            {
                // Hide empty group.
                if (intCount == 0)
                {
                    mobjOwnerRow.DataGridView.CurrentCell = null;
                    mobjOwnerRow.SetVisibleInternal(false);
                }

                else
                {
                    // Format header (default if no one listens to event)
                    GroupHeaderFormattingEventArgs objEventArgs = mobjOwnerRow.DataGridView.OnGroupHeaderFormatting(mobjHeaderLabel, mstrDataPropertyName, mstrCurrentValue, intCount, mobjOwnerRow);

                    if (!objEventArgs.FormattingApplied)
                    {
                        FormatLabelByDefault(mobjHeaderLabel, mstrDataPropertyName, mstrCurrentValue, intCount);
                    }
                }
            }
        }

        /// <summary>
        /// Formats the label by default.
        /// </summary>
        /// <param name="objHeaderLabel">The obj header label.</param>
        /// <param name="strDataPropertyName">Name of the STR data property.</param>
        /// <param name="strValue">The STR value.</param>
        /// <param name="intCount">The int count.</param>
        private void FormatLabelByDefault(Label objHeaderLabel, string strDataPropertyName, string strValue, int intCount)
        {
            // Set label appearance.
            objHeaderLabel.BackColor = System.Drawing.Color.Gray;
            objHeaderLabel.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            objHeaderLabel.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            objHeaderLabel.Location = new System.Drawing.Point(0, 0);
            objHeaderLabel.TabIndex = 0;

            // Format label text.
            if (intCount >= 0)
            {
                objHeaderLabel.Text = string.Format("{0}: {1} ({2} item{3})", mstrDataPropertyName, (!string.IsNullOrEmpty(mstrCurrentValue) ? "'" + mstrCurrentValue + "'" : "NULL"), intCount.ToString(), (intCount > 1 ? "s" : string.Empty));
            }

            else
            {
                objHeaderLabel.Text = string.Format("{0}: {1}", mstrDataPropertyName, (!string.IsNullOrEmpty(mstrCurrentValue) ? "'" + mstrCurrentValue + "'" : "NULL"));
            }
        }

        #endregion Methods

        internal event GroupHeaderFormattingEventHandler GroupHeaderFormatting;
    }
}