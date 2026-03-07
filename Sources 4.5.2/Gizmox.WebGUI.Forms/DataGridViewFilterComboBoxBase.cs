using System;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

namespace Gizmox.WebGUI.Forms
{
    #region DataGridViewFilterComboBoxBase class

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    [ToolboxItem(false)]
    public class DataGridViewFilterComboBoxBase : ComboBox
    {
        #region Members

        private DataGridView mobjOwningDataGridView;
        private DataGridViewColumn mobjOwningColumn;
        private DataGridViewCell mobjOwningCell;
        [NonSerialized]
        private TypeConverter mobjTypeConverter = null;

        #endregion Members

        #region Properties

        /// <summary>
        /// Gets or sets the owning cell.
        /// </summary>
        /// <value>
        /// The owning cell.
        /// </value>
        public DataGridViewCell OwningCell
        {
            get
            {
                return mobjOwningCell;
            }
            set
            {
                mobjOwningCell = value;
            }
        }

        /// <summary>
        /// Gets or sets the owning column.
        /// </summary>
        /// <value>
        /// The owning column.
        /// </value>
        public DataGridViewColumn OwningColumn
        {
            get
            {
                return mobjOwningColumn;
            }

            set
            {
                mobjOwningColumn = value;
            }
        }

        /// <summary>
        /// Gets or sets the owning data grid view.
        /// </summary>
        /// <value>
        /// The owning data grid view.
        /// </value>
        public DataGridView OwningDataGridView
        {
            get
            {
                return mobjOwningDataGridView;
            }

            set
            {
                mobjOwningDataGridView = value;
            }
        }

        #endregion Properties

        #region C'tors



        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewFilterComboBoxBase"/> class.
        /// </summary>
        /// <param name="objDataGridView">The obj data grid view.</param>
        /// <param name="objColumn">The obj column.</param>
        /// <param name="objFilterCell">The obj filter cell.</param>
        public DataGridViewFilterComboBoxBase(DataGridView objDataGridView, DataGridViewColumn objColumn, DataGridViewCell objFilterCell)
        {
            this.mobjOwningDataGridView = objDataGridView;
            this.mobjOwningColumn = objColumn;
            this.mobjOwningCell = objFilterCell;
        }

        #endregion C'tors

        #region Methods

        /// <summary>
        /// Initializes the filter values.
        /// </summary>
        /// <param name="blnAddSystemFilterOptions">if set to <c>true</c> [BLN add system filter options].</param>
        /// <param name="blnCalculateDropDownWidth">if set to <c>true</c> [BLN set drop down width].</param>
        /// <param name="blnClearBindingSourceFilter">if set to <c>true</c> [BLN clear binding source filter].</param>
        public virtual void InitializeFilterValues(bool blnAddSystemFilterOptions, bool blnCalculateDropDownWidth, bool blnClearBindingSourceFilter)
        {
            if (mobjOwningDataGridView != null && mobjOwningColumn != null)
            {
                mobjOwningDataGridView.mblnSuspendFilterInitialization = true;

                // Clear items
                this.Items.Clear();

                // Get current BindingSource.
                BindingSource objBindingSource = mobjOwningDataGridView.DataSource as BindingSource;

                if (objBindingSource != null)
                {
                    if (blnClearBindingSourceFilter)
                    {
                        // Check filter 
                        if (!string.IsNullOrEmpty(objBindingSource.Filter))
                        {
                            objBindingSource = (BindingSource)objBindingSource.Clone();
                            objBindingSource.RemoveFilter();
                        }
                    }

                    // Get data property name
                    string strDataPropertyName = mobjOwningColumn.DataPropertyName;

                    Font objFont = this.Font;
                    Size objSize;
                    int intCounter = 0;
                    int intMaxWidth = 0;

                    // Get currency manager
                    CurrencyManager objCurrencyManager = objBindingSource.CurrencyManager;

                    // Loop on BindingSource list items
                    foreach (object objListItem in objBindingSource.List)
                    {
                        object objComboItem = ListControl.FilterItemOnProperty(objCurrencyManager, objListItem, strDataPropertyName);
                        if (objComboItem != null)
                        {
                            string strItemText = objComboItem.ToString();
                            if (!string.IsNullOrEmpty(strItemText) && !this.Items.Contains(strItemText))
                            {
                                this.Items.Add(strItemText);

                                // Increase items counter
                                intCounter++;

                                if (blnCalculateDropDownWidth)
                                {
                                    // Update max size
                                    objSize = CommonUtils.GetStringMeasurements(strItemText, objFont);
                                    if (intMaxWidth < objSize.Width)
                                    {
                                        // Get new max width
                                        intMaxWidth = objSize.Width;
                                    }
                                }

                                // Validate max filter options
                                if (mobjOwningDataGridView.MaxFilterOptions > 0 && intCounter == mobjOwningDataGridView.MaxFilterOptions)
                                {
                                    break;
                                }
                            }
                        }
                    }

                    // Add system items if needed
                    if (blnAddSystemFilterOptions)
                    {
                        int intIndex = 0;
                        // Add system filtering options before actual items.
                        foreach (SystemFilterOptions enmValue in Enum.GetValues(typeof(SystemFilterOptions)))
                        {
                            // Create option representation.
                            DataGridViewSystemFilterOption objOption = new DataGridViewSystemFilterOption(enmValue);

                            // Add option to items.
                            this.Items.Insert(intIndex, objOption);

                            if (blnCalculateDropDownWidth)
                            {
                                // Update max size
                                objSize = CommonUtils.GetStringMeasurements(objOption.ToString(), objFont);
                                if (intMaxWidth < objSize.Width)
                                {
                                    // Get new max width
                                    intMaxWidth = objSize.Width;
                                }
                            }

                            intIndex++;
                        }
                    }

                    if (blnCalculateDropDownWidth)
                    {
                        // Set DropDownWidth
                        UpdateDropDownWidth(intMaxWidth);
                    }

                    // Let user manage combobox items.
                    mobjOwningDataGridView.FilterValuesInitializing(this, mobjOwningColumn);
                }

                mobjOwningDataGridView.mblnSuspendFilterInitialization = false;
            }
        }

        /// <summary>
        /// Updates the width of the drop down.
        /// </summary>
        /// <param name="intMaxWidth">Width of the int max.</param>
        protected virtual void UpdateDropDownWidth(int intMaxWidth)
        {
            this.DropDownWidth = intMaxWidth;
        }

        /// <summary>
        /// Determines whether [value is valid ].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if [is valid value]; otherwise, <c>false</c>.
        /// </returns>
        protected internal virtual bool IsValidValue()
        {
            // Get combobox text
            string strText = this.Text;

            if (!string.IsNullOrEmpty(strText))
            {
                int intNum = this.FindStringIgnoreCase(strText);

                // text is not on of the combobox items
                if (intNum == -1)
                {
                    if (mobjTypeConverter == null && this.mobjOwningColumn != null)
                    {
                        mobjTypeConverter = TypeDescriptor.GetConverter(mobjOwningColumn.ValueType);
                    }
                    if (mobjTypeConverter != null)
                    {
                        // Check if value is valid
                        if (!mobjTypeConverter.IsValid(strText))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        #endregion Methods
    }

    #endregion
}