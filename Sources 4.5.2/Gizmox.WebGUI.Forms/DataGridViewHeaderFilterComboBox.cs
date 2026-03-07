#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;

#endregion Using

namespace Gizmox.WebGUI.Forms
{
    #region DataGridViewHeaderFilterComboBox Class

    /// <summary>
    /// A DataGridViewHeaderFilterComboBox control
    /// </summary>
    [Skin(typeof(DataGridViewHeaderFilterComboBoxSkin))]
    [Serializable()]
    [ToolboxItem(false)]
    public class DataGridViewHeaderFilterComboBox : DataGridViewFilterComboBoxBase
    {

        #region Members

        private bool mblnIsCustomFilter = false;

        #endregion Members

        #region C'tor/D'tor

        /// <summary>
        /// Initializes a new instance of the <see cref="DataGridViewHeaderFilterComboBox"/> class.
        /// </summary>
        /// <param name="objOwnerCell">The obj owner cell.</param>
        public DataGridViewHeaderFilterComboBox(DataGridViewColumnHeaderCell objOwnerCell)
            : base(objOwnerCell.DataGridView, objOwnerCell.OwningColumn, objOwnerCell)
        {
            this.CustomStyle = "DataGridViewHeaderFilterComboBoxSkin";
            this.DropDownWidth = this.OwningColumn.Width;
        }

        #endregion C'tor/D'tor

        #region Methods

        /// <summary>
        /// </summary>
        /// <param name="objContext"></param>
        /// <param name="objWriter"></param>
        protected override void RenderAttributes(Common.Interfaces.IContext objContext, Common.Interfaces.IAttributeWriter objWriter)
        {
            base.RenderAttributes(objContext, objWriter);

            RenderIsCustomFilterAttribute(objWriter);
        }


        /// <summary>
        /// Renders the options.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnUseCode">if set to <c>true</c> [BLN use code].</param>
        /// <param name="blnShouldRenderItemImage">if set to <c>true</c> [BLN should render item image].</param>
        /// <param name="blnShouldRenderItemColor">if set to <c>true</c> [BLN should render item color].</param>
        /// <param name="blnUseIndexCode">if set to <c>true</c> [BLN use index code].</param>
        /// <param name="objUseCodeProp">The obj use code prop.</param>
        protected override void RenderOptions(Common.Interfaces.IResponseWriter objWriter, bool blnUseCode, bool blnShouldRenderItemImage, bool blnShouldRenderItemColor, bool blnUseIndexCode, System.Reflection.PropertyInfo objUseCodeProp)
        {
            if(!this.mblnIsCustomFilter)
            {
                base.RenderOptions(objWriter, blnUseCode, blnShouldRenderItemImage, blnShouldRenderItemColor, blnUseIndexCode, objUseCodeProp);
            }
        }

        /// <summary>
        /// Renders the is custom filter attribute.
        /// </summary>
        /// <param name="objWriter">The obj writer.</param>
        /// <param name="blnForceRender">if set to <c>true</c> [BLN force render].</param>
        private void RenderIsCustomFilterAttribute(Common.Interfaces.IAttributeWriter objWriter)
        {
            if (this.IsCustomFilter)
            {
                objWriter.WriteAttributeString(WGAttributes.IsCustomFilter, "1");
            }
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Control.Click"/>
        /// event.
        /// </summary>
        /// <param name="objEventArgs">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnClick(EventArgs objEventArgs)
        {
            base.OnClick(objEventArgs);
            this.OnCustomHeaderFilterClicked();
        }


        /// <summary>
        /// Called when [custom header filter clicked].
        /// </summary>
        private void OnCustomHeaderFilterClicked()
        {
            if (this.mblnIsCustomFilter)
            {
                this.OwningDataGridView.OnCustomHeaderFilterClicked(new CustomFilterApplyingEventArgs(this.OwningColumn));
            }
        }

        /// <summary>
        /// Gets the critical events.
        /// </summary>
        /// <returns></returns>
        protected override CriticalEventsData GetCriticalEventsData()
        {
            CriticalEventsData objEvents = base.GetCriticalEventsData();

            if (this.mblnIsCustomFilter)
            {
                objEvents.Set(WGEvents.Click);
            }

            return objEvents;
        }

        /// <summary>
        /// Initializes the filter values.
        /// </summary>
        /// <param name="blnAddSystemFilterOptions">if set to <c>true</c> [BLN add system filter options].</param>
        /// <param name="blnCalculateDropDownWidth">if set to <c>true</c> [BLN set drop down width].</param>
        /// <param name="blnClearBindingSourceFilter">if set to <c>true</c> [BLN clear binding source filter].</param>
        public override void InitializeFilterValues(bool blnAddSystemFilterOptions, bool blnCalculateDropDownWidth, bool blnClearBindingSourceFilter)
        {
            base.InitializeFilterValues(blnAddSystemFilterOptions, blnCalculateDropDownWidth && !this.IsCustomFilter, blnClearBindingSourceFilter);
        }

        /// <summary>
        /// Updates the width of the drop down.
        /// </summary>
        /// <param name="intMaxWidth">Width of the int max.</param>
        protected override void UpdateDropDownWidth(int intMaxWidth)
        {
            DataGridViewHeaderFilterComboBoxSkin objSkin = this.Skin as DataGridViewHeaderFilterComboBoxSkin;
            if (objSkin != null)
            {
                intMaxWidth += objSkin.DropDownWidthSpacer;
            }
            base.UpdateDropDownWidth(intMaxWidth);
        }

        #endregion Methods

        #region Properties

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
                if (mblnIsCustomFilter != value)
                {
                    mblnIsCustomFilter = value;
                    this.Update();
                }
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
                DataGridViewColumnHeaderCell objOwnerCell = this.OwningCell as DataGridViewColumnHeaderCell;
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
        public override Form Form
        {
            get
            {
                if (this.OwningDataGridView != null)
                {
                    return this.OwningDataGridView.Form;
                }

                return base.Form;
            }
        }

        #endregion Properties
    }

    #endregion DataGridViewHeaderFilterComboBox Class
}
