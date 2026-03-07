#region Using

using System;
using System.Drawing;
using Gizmox.WebGUI.Common.Interfaces;
using WebForms = Gizmox.WebGUI.Forms;
using WinForms = System.Windows.Forms;
using Gizmox.WebGUI.Client.Design;
using System.ComponentModel;
using System.Collections.Generic;

#endregion Using

namespace Gizmox.WebGUI.Client.Controllers
{
	#region DataGridViewController Class
	
	/// <summary>
	/// Controls the relations between a webgui control and a winforms control
	/// </summary>
	
	public class DataGridViewController : ControlController
	{
		#region Class Members
#if (WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46)
        private DataGidViewColumnCollectionController mobjDataGidViewColumnCollectionController = null;
#endif
        #endregion Class Members

        #region C'Tor/D'Tor

        /// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public DataGridViewController(IContext objContext,object objWebObject,object objWinObject) :base(objContext,objWebObject,objWinObject)
        {
#if (WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46)
            mobjDataGidViewColumnCollectionController = new DataGidViewColumnCollectionController(objContext, this.WebDataGridView, this.WebDataGridView.Columns, this.WinDataGridView, this.WinDataGridView.Columns);
#endif
		}
		
		/// <summary>
		///
		/// </summary>
		/// <param name="objWebTreeView"></param>
		/// <param name="objWinTreeView"></param>
		public DataGridViewController(IContext objContext,object objWebObject) :base(objContext,objWebObject)
        {
#if (WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46)
            mobjDataGidViewColumnCollectionController = new DataGidViewColumnCollectionController(objContext, this.WebDataGridView, this.WebDataGridView.Columns, this.WinDataGridView, this.WinDataGridView.Columns);
#endif
		}
		
		
		#endregion C'Tor/D'Tor
		
		#region Methods

        /// <summary>
        /// 
        /// </summary>
        public override void Terminate()
        {
            base.Terminate();

#if (WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46)
            if (this.mobjDataGidViewColumnCollectionController != null)
            {
                mobjDataGidViewColumnCollectionController.Terminate();
            }
#endif
        }

        /// <summary>
        /// Clears the controller internal collection
        /// </summary>
        public override void Clear()
        {
            base.Clear();

#if (WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46)
            if (this.mobjDataGidViewColumnCollectionController != null)
            {
                mobjDataGidViewColumnCollectionController.Clear();
            }
#endif
        }
		
		/// <summary>
		///
		/// </summary>
		protected override void InitializeController()
		{
			base.InitializeController();

            SetWinDataGridViewColumns();
            
            SetWinDataGridViewDefaultCellStyle();
            SetWinColumnHeadersDefaultCellStyle();
            SetWinRowHeadersDefaultCellStyle();
            SetWinRowsDefaultCellStyle();
            SetWinAlternatingRowsDefaultCellStyle();
            SetWinDataGridViewRowHeaderWidth();
            SetWinDataGridViewColumnHeadersVisible();
            SetWinDataGridViewColumnHeadersHeight();
            SetWinDataGridViewAutoSizeColumns();
            SetWinDataGridViewColumnHeadersHeightSizeMode();
            SetWinDataGridViewAllowUserToAddRows();
		}


        /// <summary>
        /// Sets the win data grid view cell style.
        /// </summary>
        /// <param name="objWinDataGridViewCellStyle">The win object data grid view cell style.</param>
        /// <param name="objWebDataGridViewCellStyle">The web object data grid view cell style.</param>
        private void SetWinDataGridViewCellStyle(WinForms.DataGridViewCellStyle objWinDataGridViewCellStyle, WebForms.DataGridViewCellStyle objWebDataGridViewCellStyle)
        {
            // Get all of the WinForms DataGridViewCellStyle data out of the WebGUI DataGridViewCellStyle.
            objWinDataGridViewCellStyle.Alignment = (WinForms.DataGridViewContentAlignment)Enum.Parse(typeof(WinForms.DataGridViewContentAlignment), objWebDataGridViewCellStyle.Alignment.ToString());
            objWinDataGridViewCellStyle.BackColor = objWebDataGridViewCellStyle.BackColor;
            objWinDataGridViewCellStyle.DataSourceNullValue = objWebDataGridViewCellStyle.DataSourceNullValue;
            if (objWebDataGridViewCellStyle.Font == null)
            {
                objWinDataGridViewCellStyle.Font = null;
            }
            else
            {
                objWinDataGridViewCellStyle.Font = new Font(objWebDataGridViewCellStyle.Font.FontFamily, objWebDataGridViewCellStyle.Font.Size * TargetVerticalScaleFactor);
            }
            objWinDataGridViewCellStyle.ForeColor = objWebDataGridViewCellStyle.ForeColor;
            objWinDataGridViewCellStyle.Format = objWebDataGridViewCellStyle.Format;
            objWinDataGridViewCellStyle.FormatProvider = objWebDataGridViewCellStyle.FormatProvider;
            objWinDataGridViewCellStyle.NullValue = objWebDataGridViewCellStyle.NullValue;
            objWinDataGridViewCellStyle.Padding = new System.Windows.Forms.Padding(objWebDataGridViewCellStyle.Padding.Left, objWebDataGridViewCellStyle.Padding.Top, objWebDataGridViewCellStyle.Padding.Right, objWebDataGridViewCellStyle.Padding.Bottom);
            objWinDataGridViewCellStyle.SelectionBackColor = objWebDataGridViewCellStyle.SelectionBackColor;
            objWinDataGridViewCellStyle.SelectionForeColor = objWebDataGridViewCellStyle.SelectionForeColor;
            objWinDataGridViewCellStyle.Tag = objWebDataGridViewCellStyle.Tag;
            objWinDataGridViewCellStyle.WrapMode = (WinForms.DataGridViewTriState)Enum.Parse(typeof(WinForms.DataGridViewTriState), objWebDataGridViewCellStyle.WrapMode.ToString());
        }

        /// <summary>
        /// Sets the win data grid view default cell style.
        /// </summary>
        protected void SetWinDataGridViewDefaultCellStyle()
        {
            // Check that the grid's default cell style is not null.
            if (this.WebDataGridView.DefaultCellStyle != null)
            {
                // Check if the winforms cell style is null and create a new one.
                if (this.WinDataGridView.DefaultCellStyle == null)
                {
                    this.WinDataGridView.DefaultCellStyle = new WinForms.DataGridViewCellStyle();
                }
                SetWinDataGridViewCellStyle(this.WinDataGridView.DefaultCellStyle, this.WebDataGridView.DefaultCellStyle);
            }
        }

        /// <summary>
        /// Sets the win alternating rows default cell style.
        /// </summary>
        protected void SetWinAlternatingRowsDefaultCellStyle()
        {
            // Check that the grid's Alternating Rows default cell style is not null.
            if (this.WebDataGridView.AlternatingRowsDefaultCellStyle != null)
            {
                // Check if the winforms Alternating Rows default cell style is null and create a new one.
                if (this.WinDataGridView.AlternatingRowsDefaultCellStyle == null)
                {
                    this.WinDataGridView.AlternatingRowsDefaultCellStyle = new WinForms.DataGridViewCellStyle();
                }
                SetWinDataGridViewCellStyle(this.WinDataGridView.AlternatingRowsDefaultCellStyle, this.WebDataGridView.AlternatingRowsDefaultCellStyle);
            }
        }

        /// <summary>
        /// Sets the win column headers default cell style.
        /// </summary>
        protected void SetWinColumnHeadersDefaultCellStyle()
        {
            // Check that the grid's column header default cell style is not null.
            if (this.WebDataGridView.ColumnHeadersDefaultCellStyle != null)
            {
                // Check if the winforms column header default cell style is null and create a new one.
                if (this.WinDataGridView.ColumnHeadersDefaultCellStyle== null)
                {
                    this.WinDataGridView.ColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
                }
                SetWinDataGridViewCellStyle(this.WinDataGridView.ColumnHeadersDefaultCellStyle, this.WebDataGridView.ColumnHeadersDefaultCellStyle);
            }
        }
        
        /// <summary>
        /// Sets the win row headers default cell style.
        /// </summary>
        protected void SetWinRowHeadersDefaultCellStyle()
        {
            // Check that the grid's row header default cell style is not null.
            if (this.WebDataGridView.RowHeadersDefaultCellStyle!= null)
            {
                // Check if the winforms row header default cell style is null and create a new one.
                if (this.WinDataGridView.RowHeadersDefaultCellStyle == null)
                {
                    this.WinDataGridView.RowHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
                }
                SetWinDataGridViewCellStyle(this.WinDataGridView.RowHeadersDefaultCellStyle, this.WebDataGridView.RowHeadersDefaultCellStyle);
            }
        }

        /// <summary>
        /// Sets the win rows default cell style.
        /// </summary>
        protected void SetWinRowsDefaultCellStyle()
        {
            // Check that the grid's rows default cell style is not null.
            if (this.WebDataGridView.RowsDefaultCellStyle != null)
            {
                // Check if the winforms rows default cell style is null and create a new one.
                if (this.WinDataGridView.RowsDefaultCellStyle == null)
                {
                    this.WinDataGridView.RowsDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
                }
                SetWinDataGridViewCellStyle(this.WinDataGridView.RowsDefaultCellStyle, this.WebDataGridView.RowsDefaultCellStyle);
            }
        }

        /// <summary>
		///
		/// </summary>
		protected virtual void SetWinDataGridViewDataSource()
        {
#if WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46
            // Get web binding source if posible
            WebForms.BindingSource objWebBindingSource = this.WebDataGridView.DataSource as WebForms.BindingSource;

            if (objWebBindingSource != null)
            {
                WinForms.BindingSource objWinBindingSource = this.WinDataGridView.DataSource as WinForms.BindingSource;

                if (objWinBindingSource == null ||
                    objWinBindingSource.DataSource != objWebBindingSource.DataSource ||
                    objWinBindingSource.DataMember != objWebBindingSource.DataMember)
                {
                    this.WinDataGridView.DataSource = new WinForms.BindingSource(objWebBindingSource.DataSource, objWebBindingSource.DataMember);
                    this.RefreshDesigner();
                }
            }
            else if (this.WinDataGridView.DataSource != this.WebDataGridView.DataSource)
            {
                this.WinDataGridView.DataSource = this.WebDataGridView.DataSource;
                this.RefreshDesigner();
            }
#else
            if (this.WinDataGridView.DataSource != this.WebDataGridView.DataSource)
            {
                this.WinDataGridView.DataSource = this.WebDataGridView.DataSource;
                this.RefreshDesigner();
            }
#endif
        }
		
		/// <summary>
		/// Create the winforms object
		/// </summary>
		/// <returns></returns>
        protected override object CreateTargetObject(object objWebObject)
        {
            return new DataGridView();
        }
		
		#region Events
		
		/// <summary>
		///
		/// </summary>
		protected override void WireEvents()
		{
			base.WireEvents ();

            if (this.WinDataGridView != null)
            {
                this.WinDataGridView.DataSourceChanged += new EventHandler(WinDataGridView_DataSourceChanged);
                this.WinDataGridView.AutoGenerateColumnsChanged += new EventHandler(WinDataGridView_AutoGenerateColumnsChanged);
                this.WinDataGridView.ColumnHeadersHeightSizeModeChanged += new System.Windows.Forms.DataGridViewAutoSizeModeEventHandler(WinDataGridView_ColumnHeadersHeightSizeModeChanged);
            }
		}

        /// <summary>
        /// Handles the ColumnHeadersHeightSizeModeChanged event of the WinDataGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewAutoSizeModeEventArgs"/> instance containing the event data.</param>
        private void WinDataGridView_ColumnHeadersHeightSizeModeChanged(object sender, System.Windows.Forms.DataGridViewAutoSizeModeEventArgs e)
        {
            //in win designer the ColumnHeadersHeightSizeMode set to autosize.
            SetWebDataGridViewColumnHeadersHeightSizeMode();
        }

        /// <summary>
        /// Handles the AutoGenerateColumnsChanged event of the WinDataGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void WinDataGridView_AutoGenerateColumnsChanged(object sender, EventArgs e)
        {
            SetWebDataGridViewAutoGenerateColumns();
        }

        /// <summary>
        /// Handles the DataSourceChanged event of the WinDataGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void WinDataGridView_DataSourceChanged(object sender, EventArgs e)
        {
            SetWebDataGridViewColumns();
        }

        /// <summary>
		///
		/// </summary>
		protected override void UnwireEvents()
		{
			base.UnwireEvents ();

            if (this.WinDataGridView != null)
            {
                this.WinDataGridView.DataSourceChanged -= new EventHandler(WinDataGridView_DataSourceChanged);
                this.WinDataGridView.AutoGenerateColumnsChanged -= new EventHandler(WinDataGridView_AutoGenerateColumnsChanged);
                this.WinDataGridView.ColumnHeadersHeightSizeModeChanged -= new System.Windows.Forms.DataGridViewAutoSizeModeEventHandler(WinDataGridView_ColumnHeadersHeightSizeModeChanged);
            }
		}

        /// <summary>
        ///
        /// </summary>
        protected override void InitializedContained()
        {
#if (WG_NET2 || WG_NET35 || WG_NET40 || WG_NET45 || WG_NET451 || WG_NET452 || WG_NET46)
            mobjDataGidViewColumnCollectionController.Initialize();
#endif
        }

        /// <summary>
        /// </summary>
        /// <param name="objPropertyChangeArgs"></param>
        protected override void OnTargetObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
        {
            base.OnTargetObjectPropertyChange(objPropertyChangeArgs);

            switch (objPropertyChangeArgs.Property)
            {
                case "Columns":
                    SetWebDataGridViewColumns();
                    break;
            }
        }

        /// <summary>
        /// Sets the web data grid view auto generate columns.
        /// </summary>
        private void SetWebDataGridViewAutoGenerateColumns()
        {
            if (this.WinDataGridView != null && this.WebDataGridView != null)
            {
                this.WebDataGridView.AutoGenerateColumns = this.WinDataGridView.AutoGenerateColumns;
            }
        }

        /// <summary>
        /// Sets the web data grid view columns.
        /// </summary>
        private void SetWebDataGridViewColumns()
        {
            if (mobjDataGidViewColumnCollectionController != null)
            {
                mobjDataGidViewColumnCollectionController.SetWebObjectObjects();
            }
        }
		
		/// <summary>
		///
		/// </summary>
		/// <param name="strProperty"></param>
		protected override void OnSourceObjectPropertyChange(ObservableItemPropertyChangedArgs objPropertyChangeArgs)
		{
			base.OnSourceObjectPropertyChange (objPropertyChangeArgs);
			
			switch(objPropertyChangeArgs.Property)
			{
				case "DataSource":
				    SetWinDataGridViewDataSource();
                    break;
                case "DefaultCellStyle":
                    SetWinDataGridViewDefaultCellStyle();
                    break;
                case "ColumnHeadersDefaultCellStyle":
                    SetWinColumnHeadersDefaultCellStyle();
                    break;
                case "RowHeadersDefaultCellStyle":
                    SetWinRowHeadersDefaultCellStyle();
                    break;
                case "RowsDefaultCellStyle":
                    SetWinRowsDefaultCellStyle();
                    break;
                case "AlternatingRowsDefaultCellStyle":
                    SetWinAlternatingRowsDefaultCellStyle();
                    break;
                case "Columns":
                    SetWinDataGridViewColumns();
                    break;
                case "RowHeadersWidth":
                    SetWinDataGridViewRowHeaderWidth();
                    break;
                case "ColumnHeadersVisible":
                    SetWinDataGridViewColumnHeadersVisible();
                    break;
                case "ColumnHeadersHeight":
                    SetWinDataGridViewColumnHeadersHeight();
                    break;
                case "AutoSizeColumnsMode":
                    SetWinDataGridViewAutoSizeColumns();
                    break;
                case "ColumnHeadersHeightSizeMode":
                    SetWinDataGridViewColumnHeadersHeightSizeMode();
                    break;
                case "AllowUserToAddRows":
                    SetWinDataGridViewAllowUserToAddRows();
                    break;
			}
		}

        /// <summary>
        /// Sets the win data grid view allow user to add rows.
        /// </summary>
        private void SetWinDataGridViewAllowUserToAddRows()
        {
            if (this.WinDataGridView != null)
            {
                this.WinDataGridView.AllowUserToAddRows = this.WebDataGridView.AllowUserToAddRows;
            }
        }

        /// <summary>
        /// Sets the win data grid view columns.
        /// </summary>
        private void SetWinDataGridViewColumns()
        {
            if (mobjDataGidViewColumnCollectionController != null)
            {
                mobjDataGidViewColumnCollectionController.SetWinObjectObjects();
            }
        }

        
        /// <summary>
        /// Sets the width of the win data grid view row header.
        /// </summary>
        private void SetWinDataGridViewRowHeaderWidth()
        {
            if (this.WinDataGridView != null)
            {
                this.WinDataGridView.RowHeadersWidth = this.WebDataGridView.RowHeadersWidth;
            }
        }

        /// <summary>
        /// Sets the height of the win data grid view column headers.
        /// </summary>
        private void SetWinDataGridViewColumnHeadersHeight()
        {
            if (this.WinDataGridView != null)
            {
                this.WinDataGridView.ColumnHeadersHeight = this.WebDataGridView.ColumnHeadersHeight;
            }
        }


        /// <summary>
        /// Sets the win data grid view column headers visible.
        /// </summary>
        private void SetWinDataGridViewColumnHeadersVisible()
        {
            if (this.WinDataGridView != null)
            {
                this.WinDataGridView.ColumnHeadersVisible = this.WebDataGridView.ColumnHeadersVisible;
            }
        }

        /// <summary>
        /// Sets the win data grid view auto size columns.
        /// </summary>
        private void SetWinDataGridViewAutoSizeColumns()
        {
            if (this.WinDataGridView != null)
            {
                this.WinDataGridView.AutoSizeColumnsMode = (WinForms.DataGridViewAutoSizeColumnsMode)GetConvertedEnum(typeof(WinForms.DataGridViewAutoSizeColumnsMode), this.WebDataGridView.AutoSizeColumnsMode, this.WinDataGridView.AutoSizeColumnsMode);
            }
        }

        /// <summary>
        /// Sets the win data grid view column headers height size mode.
        /// </summary>
        private void SetWinDataGridViewColumnHeadersHeightSizeMode()
        {
            if (this.WinDataGridView != null)
            {
                WinForms.DataGridViewColumnHeadersHeightSizeMode objMode = (WinForms.DataGridViewColumnHeadersHeightSizeMode)GetConvertedEnum(typeof(WinForms.DataGridViewColumnHeadersHeightSizeMode), this.WebDataGridView.ColumnHeadersHeightSizeMode, this.WinDataGridView.ColumnHeadersHeightSizeMode);
                if(this.WinDataGridView.ColumnHeadersHeightSizeMode != objMode)
                {
                    this.WinDataGridView.ColumnHeadersHeightSizeMode = objMode;
                }
            }
        }

        /// <summary>
        /// Sets the web data grid view column headers height size mode.
        /// </summary>
        private void SetWebDataGridViewColumnHeadersHeightSizeMode()
        {
            if (this.WebDataGridView != null)
            {
                WebForms.DataGridViewColumnHeadersHeightSizeMode objMode = (WebForms.DataGridViewColumnHeadersHeightSizeMode)GetConvertedEnum(typeof(WebForms.DataGridViewColumnHeadersHeightSizeMode), this.WinDataGridView.ColumnHeadersHeightSizeMode, this.WebDataGridView.ColumnHeadersHeightSizeMode);
                if (this.WebDataGridView.ColumnHeadersHeightSizeMode != objMode)
                {
                    this.WebDataGridView.ColumnHeadersHeightSizeMode = objMode;
                }
            }
        }
		
		#endregion Events
		
		#endregion Methods
		
		#region Properties
		
		/// <summary>
		///
		/// </summary>
		public WebForms.DataGridView WebDataGridView
		{
			get
			{
				return base.SourceObject as WebForms.DataGridView;
			}
		}
		
		/// <summary>
		///
		/// </summary>
		public WinForms.DataGridView WinDataGridView
		{
			get
			{
				return base.TargetObject as WinForms.DataGridView;
			}
		}
		
		#endregion Properties
	}

    #region DataGridView Class

    /// <summary>
    /// 
    /// </summary>
    [Designer(typeof(System.Windows.Forms.Design.ControlDesigner))]
    internal class DataGridView : WinForms.DataGridView
    {
    }

    #endregion DataGridView Class
	
	#endregion DataGridViewController Class	
}
