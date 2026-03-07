namespace Gizmox.WebGUI.Forms.CompanionKit.ComponentOneSampleAppsCS
{
	partial class C1GridViewWrapper
	{
		#region Fields
		
        /// <summary>
        /// Required designer variable.
        /// </summary>
		private System.ComponentModel.IContainer components = null;

		#endregion

		#region Visual WebGui Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
		}

		#endregion	
		
		#region Properties
		
		/// <summary>
        /// Get the hosted control type
        /// </summary>
        protected override System.Type HostedControlType
        {
            get
            {
                return typeof(C1.Web.Wijmo.Controls.C1GridView.C1GridView);
            }
        }
        
        /// <summary>
        /// Get hosted control typed instance
        /// </summary>
        protected C1.Web.Wijmo.Controls.C1GridView.C1GridView HostedC1GridView
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1GridView.C1GridView)this.HostedControl;
            }
        }
        
        		
		/// <summary>
		/// A value indicating whether columns can be sized.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("A value indicating whether columns can be sized.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AllowColSizing
        {
            get
            {
                return (System.Boolean)this.GetProperty("AllowColSizing");
            }
            set
            {
                this.SetProperty("AllowColSizing", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value indicating whether columns can be sized. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AllowColSizing property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAllowColSizing()
        {
			return this.ShouldSerialize("AllowColSizing");
        }
        
        
        /// <summary>
		/// Resets the A value indicating whether columns can be sized. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AllowColSizing property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAllowColSizing()
        {
			this.Reset("AllowColSizing");
        }
        
		
		/// <summary>
		/// A value indicating whether columns can be moved.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("A value indicating whether columns can be moved.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AllowColMoving
        {
            get
            {
                return (System.Boolean)this.GetProperty("AllowColMoving");
            }
            set
            {
                this.SetProperty("AllowColMoving", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value indicating whether columns can be moved. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AllowColMoving property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAllowColMoving()
        {
			return this.ShouldSerialize("AllowColMoving");
        }
        
        
        /// <summary>
		/// Resets the A value indicating whether columns can be moved. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AllowColMoving property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAllowColMoving()
        {
			this.Reset("AllowColMoving");
        }
        
		
		/// <summary>
		/// A value indicating whether keyboard navigation is allowed.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("A value indicating whether keyboard navigation is allowed.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AllowKeyboardNavigation
        {
            get
            {
                return (System.Boolean)this.GetProperty("AllowKeyboardNavigation");
            }
            set
            {
                this.SetProperty("AllowKeyboardNavigation", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value indicating whether keyboard navigation is allowed. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AllowKeyboardNavigation property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAllowKeyboardNavigation()
        {
			return this.ShouldSerialize("AllowKeyboardNavigation");
        }
        
        
        /// <summary>
		/// Resets the A value indicating whether keyboard navigation is allowed. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AllowKeyboardNavigation property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAllowKeyboardNavigation()
        {
			this.Reset("AllowKeyboardNavigation");
        }
        
		
		/// <summary>
		/// A value indicating whether the widget can be paged.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("A value indicating whether the widget can be paged.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AllowPaging
        {
            get
            {
                return (System.Boolean)this.GetProperty("AllowPaging");
            }
            set
            {
                this.SetProperty("AllowPaging", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value indicating whether the widget can be paged. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AllowPaging property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAllowPaging()
        {
			return this.ShouldSerialize("AllowPaging");
        }
        
        
        /// <summary>
		/// Resets the A value indicating whether the widget can be paged. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AllowPaging property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAllowPaging()
        {
			this.Reset("AllowPaging");
        }
        
		
		/// <summary>
		/// A value indicating whether the widget can be sorted.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("A value indicating whether the widget can be sorted.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AllowSorting
        {
            get
            {
                return (System.Boolean)this.GetProperty("AllowSorting");
            }
            set
            {
                this.SetProperty("AllowSorting", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value indicating whether the widget can be sorted. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AllowSorting property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAllowSorting()
        {
			return this.ShouldSerialize("AllowSorting");
        }
        
        
        /// <summary>
		/// Resets the A value indicating whether the widget can be sorted. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AllowSorting property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAllowSorting()
        {
			this.Reset("AllowSorting");
        }
        
		
		/// <summary>
		/// A value indicating whether virtual scrolling is enabled.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("A value indicating whether virtual scrolling is enabled.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AllowVirtualScrolling
        {
            get
            {
                return (System.Boolean)this.GetProperty("AllowVirtualScrolling");
            }
            set
            {
                this.SetProperty("AllowVirtualScrolling", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value indicating whether virtual scrolling is enabled. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AllowVirtualScrolling property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAllowVirtualScrolling()
        {
			return this.ShouldSerialize("AllowVirtualScrolling");
        }
        
        
        /// <summary>
		/// Resets the A value indicating whether virtual scrolling is enabled. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AllowVirtualScrolling property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAllowVirtualScrolling()
        {
			this.Reset("AllowVirtualScrolling");
        }
        
		
		/// <summary>
		/// Determines the freezing mode.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Determines the freezing mode.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public C1.Web.Wijmo.Controls.C1GridView.FreezingMode FreezingMode
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1GridView.FreezingMode)this.GetProperty("FreezingMode");
            }
            set
            {
                this.SetProperty("FreezingMode", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the freezing mode. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the FreezingMode property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeFreezingMode()
        {
			return this.ShouldSerialize("FreezingMode");
        }
        
        
        /// <summary>
		/// Resets the Determines the freezing mode. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the FreezingMode property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetFreezingMode()
        {
			this.Reset("FreezingMode");
        }
        
		
		/// <summary>
		/// Determines the caption of the group area.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Determines the caption of the group area.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String GroupAreaCaption
        {
            get
            {
                return (System.String)this.GetProperty("GroupAreaCaption");
            }
            set
            {
                this.SetProperty("GroupAreaCaption", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the caption of the group area. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the GroupAreaCaption property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeGroupAreaCaption()
        {
			return this.ShouldSerialize("GroupAreaCaption");
        }
        
        
        /// <summary>
		/// Resets the Determines the caption of the group area. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the GroupAreaCaption property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetGroupAreaCaption()
        {
			this.Reset("GroupAreaCaption");
        }
        
		
		/// <summary>
		/// Determines the indentation of the groups.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Determines the indentation of the groups.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 GroupIndent
        {
            get
            {
                return (System.Int32)this.GetProperty("GroupIndent");
            }
            set
            {
                this.SetProperty("GroupIndent", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the indentation of the groups. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the GroupIndent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeGroupIndent()
        {
			return this.ShouldSerialize("GroupIndent");
        }
        
        
        /// <summary>
		/// Resets the Determines the indentation of the groups. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the GroupIndent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetGroupIndent()
        {
			this.Reset("GroupIndent");
        }
        
		
		/// <summary>
		/// Determines whether position of the current cell is highlighted or not.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Determines whether position of the current cell is highlighted or not.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean HighlightCurrentCell
        {
            get
            {
                return (System.Boolean)this.GetProperty("HighlightCurrentCell");
            }
            set
            {
                this.SetProperty("HighlightCurrentCell", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines whether position of the current cell is highlighted or not. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the HighlightCurrentCell property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHighlightCurrentCell()
        {
			return this.ShouldSerialize("HighlightCurrentCell");
        }
        
        
        /// <summary>
		/// Resets the Determines whether position of the current cell is highlighted or not. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the HighlightCurrentCell property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHighlightCurrentCell()
        {
			this.Reset("HighlightCurrentCell");
        }
        
		
		/// <summary>
		/// Determines the text that should be shown during callback to provide visual feedback.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Determines the text that should be shown during callback to provide visual feedback.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String LoadingText
        {
            get
            {
                return (System.String)this.GetProperty("LoadingText");
            }
            set
            {
                this.SetProperty("LoadingText", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the text that should be shown during callback to provide visual feedback. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the LoadingText property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeLoadingText()
        {
			return this.ShouldSerialize("LoadingText");
        }
        
        
        /// <summary>
		/// Resets the Determines the text that should be shown during callback to provide visual feedback. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the LoadingText property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetLoadingText()
        {
			this.Reset("LoadingText");
        }
        
		
		/// <summary>
		/// Determines the zero-based index of the current page.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Determines the zero-based index of the current page.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 PageIndex
        {
            get
            {
                return (System.Int32)this.GetProperty("PageIndex");
            }
            set
            {
                this.SetProperty("PageIndex", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the zero-based index of the current page. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the PageIndex property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializePageIndex()
        {
			return this.ShouldSerialize("PageIndex");
        }
        
        
        /// <summary>
		/// Resets the Determines the zero-based index of the current page. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the PageIndex property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetPageIndex()
        {
			this.Reset("PageIndex");
        }
        
		
		/// <summary>
		/// Number of rows to place on a single page.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Number of rows to place on a single page.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 PageSize
        {
            get
            {
                return (System.Int32)this.GetProperty("PageSize");
            }
            set
            {
                this.SetProperty("PageSize", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Number of rows to place on a single page. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the PageSize property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializePageSize()
        {
			return this.ShouldSerialize("PageSize");
        }
        
        
        /// <summary>
		/// Resets the Number of rows to place on a single page. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the PageSize property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetPageSize()
        {
			this.Reset("PageSize");
        }
        
		
		/// <summary>
		/// Pager settings.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Pager settings.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public C1.Web.Wijmo.Controls.C1GridView.PagerSettings PagerSettings
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1GridView.PagerSettings)this.GetProperty("PagerSettings");
            }
        }
        
		
		/// <summary>
		/// Determines the height of a rows when virtual scrolling is used.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Determines the height of a rows when virtual scrolling is used.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 RowHeight
        {
            get
            {
                return (System.Int32)this.GetProperty("RowHeight");
            }
            set
            {
                this.SetProperty("RowHeight", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the height of a rows when virtual scrolling is used. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the RowHeight property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeRowHeight()
        {
			return this.ShouldSerialize("RowHeight");
        }
        
        
        /// <summary>
		/// Resets the Determines the height of a rows when virtual scrolling is used. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the RowHeight property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetRowHeight()
        {
			this.Reset("RowHeight");
        }
        
		
		/// <summary>
		/// Determines the scrolling mode.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Determines the scrolling mode.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public C1.Web.Wijmo.Controls.C1GridView.ScrollMode ScrollMode
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1GridView.ScrollMode)this.GetProperty("ScrollMode");
            }
            set
            {
                this.SetProperty("ScrollMode", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the scrolling mode. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ScrollMode property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeScrollMode()
        {
			return this.ShouldSerialize("ScrollMode");
        }
        
        
        /// <summary>
		/// Resets the Determines the scrolling mode. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ScrollMode property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetScrollMode()
        {
			this.Reset("ScrollMode");
        }
        
		
		/// <summary>
		/// A value indicating whether the row header is visible.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("A value indicating whether the row header is visible.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowRowHeader
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowRowHeader");
            }
            set
            {
                this.SetProperty("ShowRowHeader", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value indicating whether the row header is visible. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowRowHeader property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowRowHeader()
        {
			return this.ShouldSerialize("ShowRowHeader");
        }
        
        
        /// <summary>
		/// Resets the A value indicating whether the row header is visible. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowRowHeader property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowRowHeader()
        {
			this.Reset("ShowRowHeader");
        }
        
		
		/// <summary>
		/// A value indicating whether filter row is visible.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("A value indicating whether filter row is visible.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowFilter
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowFilter");
            }
            set
            {
                this.SetProperty("ShowFilter", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value indicating whether filter row is visible. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowFilter property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowFilter()
        {
			return this.ShouldSerialize("ShowFilter");
        }
        
        
        /// <summary>
		/// Resets the A value indicating whether filter row is visible. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowFilter property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowFilter()
        {
			this.Reset("ShowFilter");
        }
        
		
		/// <summary>
		/// A value indicating whether footer row is visible.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("A value indicating whether footer row is visible.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowFooter
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowFooter");
            }
            set
            {
                this.SetProperty("ShowFooter", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value indicating whether footer row is visible. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowFooter property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowFooter()
        {
			return this.ShouldSerialize("ShowFooter");
        }
        
        
        /// <summary>
		/// Resets the A value indicating whether footer row is visible. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowFooter property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowFooter()
        {
			this.Reset("ShowFooter");
        }
        
		
		/// <summary>
		/// A value indicating whether group area is visible.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("A value indicating whether group area is visible.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowGroupArea
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowGroupArea");
            }
            set
            {
                this.SetProperty("ShowGroupArea", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value indicating whether group area is visible. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowGroupArea property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowGroupArea()
        {
			return this.ShouldSerialize("ShowGroupArea");
        }
        
        
        /// <summary>
		/// Resets the A value indicating whether group area is visible. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowGroupArea property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowGroupArea()
        {
			this.Reset("ShowGroupArea");
        }
        
		
		/// <summary>
		/// Indicates the index of columns that will always be shown on the left when the grid view scrolled horizontally.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Indicates the index of columns that will always be shown on the left when the grid view scrolled horizontally.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 StaticColumnIndex
        {
            get
            {
                return (System.Int32)this.GetProperty("StaticColumnIndex");
            }
            set
            {
                this.SetProperty("StaticColumnIndex", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Indicates the index of columns that will always be shown on the left when the grid view scrolled horizontally. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the StaticColumnIndex property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeStaticColumnIndex()
        {
			return this.ShouldSerialize("StaticColumnIndex");
        }
        
        
        /// <summary>
		/// Resets the Indicates the index of columns that will always be shown on the left when the grid view scrolled horizontally. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the StaticColumnIndex property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetStaticColumnIndex()
        {
			this.Reset("StaticColumnIndex");
        }
        
		
		/// <summary>
		/// Indicates the index of data rows that will always be shown on the top when the wijgrid is scrolled vertically.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Indicates the index of data rows that will always be shown on the top when the wijgrid is scrolled vertically.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 StaticRowIndex
        {
            get
            {
                return (System.Int32)this.GetProperty("StaticRowIndex");
            }
            set
            {
                this.SetProperty("StaticRowIndex", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Indicates the index of data rows that will always be shown on the top when the wijgrid is scrolled vertically. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the StaticRowIndex property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeStaticRowIndex()
        {
			return this.ShouldSerialize("StaticRowIndex");
        }
        
        
        /// <summary>
		/// Resets the Indicates the index of data rows that will always be shown on the top when the wijgrid is scrolled vertically. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the StaticRowIndex property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetStaticRowIndex()
        {
			this.Reset("StaticRowIndex");
        }
        
		
		/// <summary>
		/// C1Grid.TotalRows
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("C1Grid.TotalRows")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public System.Int32 TotalRows
        {
            get
            {
                return (System.Int32)this.GetProperty("TotalRows");
            }
        }
        
		
		/// <summary>
		/// A function called after editing is completed.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called after editing is completed.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientAfterCellEdit
        {
            get
            {
                return (System.String)this.GetProperty("OnClientAfterCellEdit");
            }
            set
            {
                this.SetProperty("OnClientAfterCellEdit", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called after editing is completed. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientAfterCellEdit property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientAfterCellEdit()
        {
			return this.ShouldSerialize("OnClientAfterCellEdit");
        }
        
        
        /// <summary>
		/// Resets the A function called after editing is completed. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientAfterCellEdit property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientAfterCellEdit()
        {
			this.Reset("OnClientAfterCellEdit");
        }
        
		
		/// <summary>
		/// A function called after a cell has been updated.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called after a cell has been updated.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientAfterCellUpdate
        {
            get
            {
                return (System.String)this.GetProperty("OnClientAfterCellUpdate");
            }
            set
            {
                this.SetProperty("OnClientAfterCellUpdate", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called after a cell has been updated. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientAfterCellUpdate property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientAfterCellUpdate()
        {
			return this.ShouldSerialize("OnClientAfterCellUpdate");
        }
        
        
        /// <summary>
		/// Resets the A function called after a cell has been updated. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientAfterCellUpdate property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientAfterCellUpdate()
        {
			this.Reset("OnClientAfterCellUpdate");
        }
        
		
		/// <summary>
		/// A function called before a cell enters edit mode. Cancellable.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called before a cell enters edit mode. Cancellable.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientBeforeCellEdit
        {
            get
            {
                return (System.String)this.GetProperty("OnClientBeforeCellEdit");
            }
            set
            {
                this.SetProperty("OnClientBeforeCellEdit", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called before a cell enters edit mode. Cancellable. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeCellEdit property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientBeforeCellEdit()
        {
			return this.ShouldSerialize("OnClientBeforeCellEdit");
        }
        
        
        /// <summary>
		/// Resets the A function called before a cell enters edit mode. Cancellable. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientBeforeCellEdit property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientBeforeCellEdit()
        {
			this.Reset("OnClientBeforeCellEdit");
        }
        
		
		/// <summary>
		/// A function called before a cell is updated.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called before a cell is updated.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientBeforeCellUpdate
        {
            get
            {
                return (System.String)this.GetProperty("OnClientBeforeCellUpdate");
            }
            set
            {
                this.SetProperty("OnClientBeforeCellUpdate", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called before a cell is updated. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeCellUpdate property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientBeforeCellUpdate()
        {
			return this.ShouldSerialize("OnClientBeforeCellUpdate");
        }
        
        
        /// <summary>
		/// Resets the A function called before a cell is updated. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientBeforeCellUpdate property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientBeforeCellUpdate()
        {
			this.Reset("OnClientBeforeCellUpdate");
        }
        
		
		/// <summary>
		/// A function called when column dragging is started, but before wijgrid handles the operation. Cancellable.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called when column dragging is started, but before wijgrid handles the operation. Cancellable.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientColumnDragging
        {
            get
            {
                return (System.String)this.GetProperty("OnClientColumnDragging");
            }
            set
            {
                this.SetProperty("OnClientColumnDragging", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called when column dragging is started, but before wijgrid handles the operation. Cancellable. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientColumnDragging property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientColumnDragging()
        {
			return this.ShouldSerialize("OnClientColumnDragging");
        }
        
        
        /// <summary>
		/// Resets the A function called when column dragging is started, but before wijgrid handles the operation. Cancellable. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientColumnDragging property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientColumnDragging()
        {
			this.Reset("OnClientColumnDragging");
        }
        
		
		/// <summary>
		/// A function called when column dragging has been started.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called when column dragging has been started.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientColumnDragged
        {
            get
            {
                return (System.String)this.GetProperty("OnClientColumnDragged");
            }
            set
            {
                this.SetProperty("OnClientColumnDragged", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called when column dragging has been started. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientColumnDragged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientColumnDragged()
        {
			return this.ShouldSerialize("OnClientColumnDragged");
        }
        
        
        /// <summary>
		/// Resets the A function called when column dragging has been started. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientColumnDragged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientColumnDragged()
        {
			this.Reset("OnClientColumnDragged");
        }
        
		
		/// <summary>
		/// A function called when column is dropped, but before wijgrid handles the operation. Cancellable.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called when column is dropped, but before wijgrid handles the operation. Cancellable.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientColumnDropping
        {
            get
            {
                return (System.String)this.GetProperty("OnClientColumnDropping");
            }
            set
            {
                this.SetProperty("OnClientColumnDropping", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called when column is dropped, but before wijgrid handles the operation. Cancellable. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientColumnDropping property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientColumnDropping()
        {
			return this.ShouldSerialize("OnClientColumnDropping");
        }
        
        
        /// <summary>
		/// Resets the A function called when column is dropped, but before wijgrid handles the operation. Cancellable. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientColumnDropping property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientColumnDropping()
        {
			this.Reset("OnClientColumnDropping");
        }
        
		
		/// <summary>
		/// A function called when column is dropped into the group area, but before wijgrid handles the operation. Cancellable.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called when column is dropped into the group area, but before wijgrid handles the operation. Cancellable.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientColumnGrouping
        {
            get
            {
                return (System.String)this.GetProperty("OnClientColumnGrouping");
            }
            set
            {
                this.SetProperty("OnClientColumnGrouping", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called when column is dropped into the group area, but before wijgrid handles the operation. Cancellable. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientColumnGrouping property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientColumnGrouping()
        {
			return this.ShouldSerialize("OnClientColumnGrouping");
        }
        
        
        /// <summary>
		/// Resets the A function called when column is dropped into the group area, but before wijgrid handles the operation. Cancellable. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientColumnGrouping property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientColumnGrouping()
        {
			this.Reset("OnClientColumnGrouping");
        }
        
		
		/// <summary>
		/// A function called when column is resized, but before wijgrid handles the operation. Cancellable.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called when column is resized, but before wijgrid handles the operation. Cancellable.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientColumnResizing
        {
            get
            {
                return (System.String)this.GetProperty("OnClientColumnResizing");
            }
            set
            {
                this.SetProperty("OnClientColumnResizing", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called when column is resized, but before wijgrid handles the operation. Cancellable. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientColumnResizing property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientColumnResizing()
        {
			return this.ShouldSerialize("OnClientColumnResizing");
        }
        
        
        /// <summary>
		/// Resets the A function called when column is resized, but before wijgrid handles the operation. Cancellable. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientColumnResizing property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientColumnResizing()
        {
			this.Reset("OnClientColumnResizing");
        }
        
		
		/// <summary>
		/// A function called when column has been resized.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called when column has been resized.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientColumnResized
        {
            get
            {
                return (System.String)this.GetProperty("OnClientColumnResized");
            }
            set
            {
                this.SetProperty("OnClientColumnResized", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called when column has been resized. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientColumnResized property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientColumnResized()
        {
			return this.ShouldSerialize("OnClientColumnResized");
        }
        
        
        /// <summary>
		/// Resets the A function called when column has been resized. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientColumnResized property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientColumnResized()
        {
			this.Reset("OnClientColumnResized");
        }
        
		
		/// <summary>
		/// A function called when column is removed from the group area, but before wijgrid handles the operation. Cancellable.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called when column is removed from the group area, but before wijgrid handles the operation. Cancellable.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientColumnUngrouping
        {
            get
            {
                return (System.String)this.GetProperty("OnClientColumnUngrouping");
            }
            set
            {
                this.SetProperty("OnClientColumnUngrouping", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called when column is removed from the group area, but before wijgrid handles the operation. Cancellable. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientColumnUngrouping property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientColumnUngrouping()
        {
			return this.ShouldSerialize("OnClientColumnUngrouping");
        }
        
        
        /// <summary>
		/// Resets the A function called when column is removed from the group area, but before wijgrid handles the operation. Cancellable. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientColumnUngrouping property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientColumnUngrouping()
        {
			this.Reset("OnClientColumnUngrouping");
        }
        
		
		/// <summary>
		/// A function called before the current cell is changed. Cancellable.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called before the current cell is changed. Cancellable.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientCurrentCellChanging
        {
            get
            {
                return (System.String)this.GetProperty("OnClientCurrentCellChanging");
            }
            set
            {
                this.SetProperty("OnClientCurrentCellChanging", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called before the current cell is changed. Cancellable. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientCurrentCellChanging property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientCurrentCellChanging()
        {
			return this.ShouldSerialize("OnClientCurrentCellChanging");
        }
        
        
        /// <summary>
		/// Resets the A function called before the current cell is changed. Cancellable. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientCurrentCellChanging property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientCurrentCellChanging()
        {
			this.Reset("OnClientCurrentCellChanging");
        }
        
		
		/// <summary>
		/// A function called after the current cell is changed.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called after the current cell is changed.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientCurrentCellChanged
        {
            get
            {
                return (System.String)this.GetProperty("OnClientCurrentCellChanged");
            }
            set
            {
                this.SetProperty("OnClientCurrentCellChanged", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called after the current cell is changed. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientCurrentCellChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientCurrentCellChanged()
        {
			return this.ShouldSerialize("OnClientCurrentCellChanged");
        }
        
        
        /// <summary>
		/// Resets the A function called after the current cell is changed. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientCurrentCellChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientCurrentCellChanged()
        {
			this.Reset("OnClientCurrentCellChanged");
        }
        
		
		/// <summary>
		/// A function called before the filter drop-down list is shown.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called before the filter drop-down list is shown.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientFilterOperatorsListShowing
        {
            get
            {
                return (System.String)this.GetProperty("OnClientFilterOperatorsListShowing");
            }
            set
            {
                this.SetProperty("OnClientFilterOperatorsListShowing", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called before the filter drop-down list is shown. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientFilterOperatorsListShowing property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientFilterOperatorsListShowing()
        {
			return this.ShouldSerialize("OnClientFilterOperatorsListShowing");
        }
        
        
        /// <summary>
		/// Resets the A function called before the filter drop-down list is shown. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientFilterOperatorsListShowing property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientFilterOperatorsListShowing()
        {
			this.Reset("OnClientFilterOperatorsListShowing");
        }
        
		
		/// <summary>
		/// A function called when groups are being created and the "aggregate" option of the column object has been set to "custom".
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called when groups are being created and the \"aggregate\" option of the column object has been set to \"custom\".")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientGroupAggregate
        {
            get
            {
                return (System.String)this.GetProperty("OnClientGroupAggregate");
            }
            set
            {
                this.SetProperty("OnClientGroupAggregate", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called when groups are being created and the "aggregate" option of the column object has been set to "custom". should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientGroupAggregate property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientGroupAggregate()
        {
			return this.ShouldSerialize("OnClientGroupAggregate");
        }
        
        
        /// <summary>
		/// Resets the A function called when groups are being created and the "aggregate" option of the column object has been set to "custom". property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientGroupAggregate property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientGroupAggregate()
        {
			this.Reset("OnClientGroupAggregate");
        }
        
		
		/// <summary>
		/// A function called when groups are being created and the groupInfo.headerText or groupInfo.FooterText of the groupInfo option has been set to "custom".
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called when groups are being created and the groupInfo.headerText or groupInfo.FooterText of the groupInfo option has been set to \"custom\".")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientGroupText
        {
            get
            {
                return (System.String)this.GetProperty("OnClientGroupText");
            }
            set
            {
                this.SetProperty("OnClientGroupText", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called when groups are being created and the groupInfo.headerText or groupInfo.FooterText of the groupInfo option has been set to "custom". should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientGroupText property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientGroupText()
        {
			return this.ShouldSerialize("OnClientGroupText");
        }
        
        
        /// <summary>
		/// Resets the A function called when groups are being created and the groupInfo.headerText or groupInfo.FooterText of the groupInfo option has been set to "custom". property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientGroupText property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientGroupText()
        {
			this.Reset("OnClientGroupText");
        }
        
		
		/// <summary>
		/// A function called when a cell needs to start updating but the cell value is invalid.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called when a cell needs to start updating but the cell value is invalid.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientInvalidCellValue
        {
            get
            {
                return (System.String)this.GetProperty("OnClientInvalidCellValue");
            }
            set
            {
                this.SetProperty("OnClientInvalidCellValue", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called when a cell needs to start updating but the cell value is invalid. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientInvalidCellValue property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientInvalidCellValue()
        {
			return this.ShouldSerialize("OnClientInvalidCellValue");
        }
        
        
        /// <summary>
		/// Resets the A function called when a cell needs to start updating but the cell value is invalid. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientInvalidCellValue property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientInvalidCellValue()
        {
			this.Reset("OnClientInvalidCellValue");
        }
        
		
		/// <summary>
		/// A function called before page index is changed. Cancellable.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called before page index is changed. Cancellable.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientPageIndexChanging
        {
            get
            {
                return (System.String)this.GetProperty("OnClientPageIndexChanging");
            }
            set
            {
                this.SetProperty("OnClientPageIndexChanging", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called before page index is changed. Cancellable. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientPageIndexChanging property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientPageIndexChanging()
        {
			return this.ShouldSerialize("OnClientPageIndexChanging");
        }
        
        
        /// <summary>
		/// Resets the A function called before page index is changed. Cancellable. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientPageIndexChanging property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientPageIndexChanging()
        {
			this.Reset("OnClientPageIndexChanging");
        }
        
		
		/// <summary>
		/// A function called after the selection is changed.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called after the selection is changed.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientSelectionChanged
        {
            get
            {
                return (System.String)this.GetProperty("OnClientSelectionChanged");
            }
            set
            {
                this.SetProperty("OnClientSelectionChanged", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called after the selection is changed. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientSelectionChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientSelectionChanged()
        {
			return this.ShouldSerialize("OnClientSelectionChanged");
        }
        
        
        /// <summary>
		/// Resets the A function called after the selection is changed. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientSelectionChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientSelectionChanged()
        {
			this.Reset("OnClientSelectionChanged");
        }
        
		
		/// <summary>
		/// A function called before the sorting operation is started. Cancellable.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called before the sorting operation is started. Cancellable.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientSorting
        {
            get
            {
                return (System.String)this.GetProperty("OnClientSorting");
            }
            set
            {
                this.SetProperty("OnClientSorting", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called before the sorting operation is started. Cancellable. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientSorting property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientSorting()
        {
			return this.ShouldSerialize("OnClientSorting");
        }
        
        
        /// <summary>
		/// Resets the A function called before the sorting operation is started. Cancellable. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientSorting property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientSorting()
        {
			this.Reset("OnClientSorting");
        }
        
		
		/// <summary>
		/// A function called when wijgrid loads a portion of data from the underlying datasource.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called when wijgrid loads a portion of data from the underlying datasource.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientDataLoading
        {
            get
            {
                return (System.String)this.GetProperty("OnClientDataLoading");
            }
            set
            {
                this.SetProperty("OnClientDataLoading", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called when wijgrid loads a portion of data from the underlying datasource. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientDataLoading property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientDataLoading()
        {
			return this.ShouldSerialize("OnClientDataLoading");
        }
        
        
        /// <summary>
		/// Resets the A function called when wijgrid loads a portion of data from the underlying datasource. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientDataLoading property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientDataLoading()
        {
			this.Reset("OnClientDataLoading");
        }
        
		
		/// <summary>
		/// A function called when data are loaded.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called when data are loaded.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientDataLoaded
        {
            get
            {
                return (System.String)this.GetProperty("OnClientDataLoaded");
            }
            set
            {
                this.SetProperty("OnClientDataLoaded", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called when data are loaded. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientDataLoaded property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientDataLoaded()
        {
			return this.ShouldSerialize("OnClientDataLoaded");
        }
        
        
        /// <summary>
		/// Resets the A function called when data are loaded. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientDataLoaded property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientDataLoaded()
        {
			this.Reset("OnClientDataLoaded");
        }
        
		
		/// <summary>
		/// A function called at the beginning of the wijgrid's lifecycle.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called at the beginning of the wijgrid\u0027s lifecycle.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientLoading
        {
            get
            {
                return (System.String)this.GetProperty("OnClientLoading");
            }
            set
            {
                this.SetProperty("OnClientLoading", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called at the beginning of the wijgrid's lifecycle. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientLoading property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientLoading()
        {
			return this.ShouldSerialize("OnClientLoading");
        }
        
        
        /// <summary>
		/// Resets the A function called at the beginning of the wijgrid's lifecycle. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientLoading property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientLoading()
        {
			this.Reset("OnClientLoading");
        }
        
		
		/// <summary>
		/// A function called at the end the wijgrid's lifecycle when wijgrid is filled with data and rendered.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called at the end the wijgrid\u0027s lifecycle when wijgrid is filled with data and rendered.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientLoaded
        {
            get
            {
                return (System.String)this.GetProperty("OnClientLoaded");
            }
            set
            {
                this.SetProperty("OnClientLoaded", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called at the end the wijgrid's lifecycle when wijgrid is filled with data and rendered. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientLoaded property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientLoaded()
        {
			return this.ShouldSerialize("OnClientLoaded");
        }
        
        
        /// <summary>
		/// Resets the A function called at the end the wijgrid's lifecycle when wijgrid is filled with data and rendered. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientLoaded property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientLoaded()
        {
			this.Reset("OnClientLoaded");
        }
        
		
		/// <summary>
		/// A function called when wijgrid is about to render.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called when wijgrid is about to render.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientRendering
        {
            get
            {
                return (System.String)this.GetProperty("OnClientRendering");
            }
            set
            {
                this.SetProperty("OnClientRendering", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called when wijgrid is about to render. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientRendering property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientRendering()
        {
			return this.ShouldSerialize("OnClientRendering");
        }
        
        
        /// <summary>
		/// Resets the A function called when wijgrid is about to render. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientRendering property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientRendering()
        {
			this.Reset("OnClientRendering");
        }
        
		
		/// <summary>
		/// A function called when wijgrid is rendered.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("A function called when wijgrid is rendered.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientRendered
        {
            get
            {
                return (System.String)this.GetProperty("OnClientRendered");
            }
            set
            {
                this.SetProperty("OnClientRendered", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A function called when wijgrid is rendered. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientRendered property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientRendered()
        {
			return this.ShouldSerialize("OnClientRendered");
        }
        
        
        /// <summary>
		/// Resets the A function called when wijgrid is rendered. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientRendered property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientRendered()
        {
			this.Reset("OnClientRendered");
        }
        
		
		/// <summary>
		/// Gets or sets a value that determines whether automatic sorting is enabled.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Sorting")]
        [System.ComponentModel.Description("Gets or sets a value that determines whether automatic sorting is enabled.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AllowAutoSort
        {
            get
            {
                return (System.Boolean)this.GetProperty("AllowAutoSort");
            }
            set
            {
                this.SetProperty("AllowAutoSort", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets a value that determines whether automatic sorting is enabled. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AllowAutoSort property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAllowAutoSort()
        {
			return this.ShouldSerialize("AllowAutoSort");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets a value that determines whether automatic sorting is enabled. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AllowAutoSort property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAllowAutoSort()
        {
			this.Reset("AllowAutoSort");
        }
        
		
		/// <summary>
		/// A value indicating whether client editing is enabled.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("A value indicating whether client editing is enabled.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AllowClientEditing
        {
            get
            {
                return (System.Boolean)this.GetProperty("AllowClientEditing");
            }
            set
            {
                this.SetProperty("AllowClientEditing", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value indicating whether client editing is enabled. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AllowClientEditing property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAllowClientEditing()
        {
			return this.ShouldSerialize("AllowClientEditing");
        }
        
        
        /// <summary>
		/// Resets the A value indicating whether client editing is enabled. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AllowClientEditing property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAllowClientEditing()
        {
			this.Reset("AllowClientEditing");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AllowCustomContent
        {
            get
            {
                return (System.Boolean)this.GetProperty("AllowCustomContent");
            }
            set
            {
                this.SetProperty("AllowCustomContent", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if  should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AllowCustomContent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAllowCustomContent()
        {
			return this.ShouldSerialize("AllowCustomContent");
        }
        
        
        /// <summary>
		/// Resets the  property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AllowCustomContent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAllowCustomContent()
        {
			this.Reset("AllowCustomContent");
        }
        
		
		/// <summary>
		/// Gets or sets a value that determines whether custom paging is enabled.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Category.Behavior")]
        [System.ComponentModel.Description("Gets or sets a value that determines whether custom paging is enabled.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AllowCustomPaging
        {
            get
            {
                return (System.Boolean)this.GetProperty("AllowCustomPaging");
            }
            set
            {
                this.SetProperty("AllowCustomPaging", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets a value that determines whether custom paging is enabled. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AllowCustomPaging property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAllowCustomPaging()
        {
			return this.ShouldSerialize("AllowCustomPaging");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets a value that determines whether custom paging is enabled. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AllowCustomPaging property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAllowCustomPaging()
        {
			this.Reset("AllowCustomPaging");
        }
        
		
		/// <summary>
		/// Gets or sets a value that determines whether C1BoundField objects are generated and displayed automatically.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Gets or sets a value that determines whether C1BoundField objects are generated and displayed automatically.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AutogenerateColumns
        {
            get
            {
                return (System.Boolean)this.GetProperty("AutogenerateColumns");
            }
            set
            {
                this.SetProperty("AutogenerateColumns", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets a value that determines whether C1BoundField objects are generated and displayed automatically. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AutogenerateColumns property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAutogenerateColumns()
        {
			return this.ShouldSerialize("AutogenerateColumns");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets a value that determines whether C1BoundField objects are generated and displayed automatically. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AutogenerateColumns property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAutogenerateColumns()
        {
			this.Reset("AutogenerateColumns");
        }
        
		
		/// <summary>
		/// Gets or sets a value indicating whether a  C1CommandField field column with a Delete button for each data row is automatically added to a C1GridView control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Gets or sets a value indicating whether a  C1CommandField field column with a Delete button for each data row is automatically added to a C1GridView control.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AutoGenerateDeleteButton
        {
            get
            {
                return (System.Boolean)this.GetProperty("AutoGenerateDeleteButton");
            }
            set
            {
                this.SetProperty("AutoGenerateDeleteButton", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets a value indicating whether a  C1CommandField field column with a Delete button for each data row is automatically added to a C1GridView control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AutoGenerateDeleteButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAutoGenerateDeleteButton()
        {
			return this.ShouldSerialize("AutoGenerateDeleteButton");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets a value indicating whether a  C1CommandField field column with a Delete button for each data row is automatically added to a C1GridView control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AutoGenerateDeleteButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAutoGenerateDeleteButton()
        {
			this.Reset("AutoGenerateDeleteButton");
        }
        
		
		/// <summary>
		/// Gets or sets a value indicating whether a C1CommandField field column with an Edit button for each data row is automatically added to a C1GridView control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Gets or sets a value indicating whether a C1CommandField field column with an Edit button for each data row is automatically added to a C1GridView control.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AutoGenerateEditButton
        {
            get
            {
                return (System.Boolean)this.GetProperty("AutoGenerateEditButton");
            }
            set
            {
                this.SetProperty("AutoGenerateEditButton", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets a value indicating whether a C1CommandField field column with an Edit button for each data row is automatically added to a C1GridView control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AutoGenerateEditButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAutoGenerateEditButton()
        {
			return this.ShouldSerialize("AutoGenerateEditButton");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets a value indicating whether a C1CommandField field column with an Edit button for each data row is automatically added to a C1GridView control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AutoGenerateEditButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAutoGenerateEditButton()
        {
			this.Reset("AutoGenerateEditButton");
        }
        
		
		/// <summary>
		/// Gets or sets a value indicating whether a C1CommandField field column with an Filter button for the filter row is automatically added to a C1GridView control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Gets or sets a value indicating whether a C1CommandField field column with an Filter button for the filter row is automatically added to a C1GridView control.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AutoGenerateFilterButton
        {
            get
            {
                return (System.Boolean)this.GetProperty("AutoGenerateFilterButton");
            }
            set
            {
                this.SetProperty("AutoGenerateFilterButton", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets a value indicating whether a C1CommandField field column with an Filter button for the filter row is automatically added to a C1GridView control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AutoGenerateFilterButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAutoGenerateFilterButton()
        {
			return this.ShouldSerialize("AutoGenerateFilterButton");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets a value indicating whether a C1CommandField field column with an Filter button for the filter row is automatically added to a C1GridView control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AutoGenerateFilterButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAutoGenerateFilterButton()
        {
			this.Reset("AutoGenerateFilterButton");
        }
        
		
		/// <summary>
		/// Gets or sets a value indicating whether a C1CommandField field column with an Select button for each data row is automatically added to a C1GridView control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Gets or sets a value indicating whether a C1CommandField field column with an Select button for each data row is automatically added to a C1GridView control.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AutoGenerateSelectButton
        {
            get
            {
                return (System.Boolean)this.GetProperty("AutoGenerateSelectButton");
            }
            set
            {
                this.SetProperty("AutoGenerateSelectButton", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets a value indicating whether a C1CommandField field column with an Select button for each data row is automatically added to a C1GridView control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AutoGenerateSelectButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAutoGenerateSelectButton()
        {
			return this.ShouldSerialize("AutoGenerateSelectButton");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets a value indicating whether a C1CommandField field column with an Select button for each data row is automatically added to a C1GridView control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AutoGenerateSelectButton property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAutoGenerateSelectButton()
        {
			this.Reset("AutoGenerateSelectButton");
        }
        
		
		/// <summary>
		/// Gets the CallbackSettings object that enables you to determine actions that can be performed by the C1GridView using callbacks mechanism.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Gets the CallbackSettings object that enables you to determine actions that can be performed by the C1GridView using callbacks mechanism.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public C1.Web.Wijmo.Controls.C1GridView.CallbackSettings CallbackSettings
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1GridView.CallbackSettings)this.GetProperty("CallbackSettings");
            }
        }
        
		
		/// <summary>
		/// Determines the method of sending client-side edited data to server.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Determines the method of sending client-side edited data to server.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public C1.Web.Wijmo.Controls.C1GridView.ClientEditingUpdateMode ClientEditingUpdateMode
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1GridView.ClientEditingUpdateMode)this.GetProperty("ClientEditingUpdateMode");
            }
            set
            {
                this.SetProperty("ClientEditingUpdateMode", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines the method of sending client-side edited data to server. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ClientEditingUpdateMode property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeClientEditingUpdateMode()
        {
			return this.ShouldSerialize("ClientEditingUpdateMode");
        }
        
        
        /// <summary>
		/// Resets the Determines the method of sending client-side edited data to server. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ClientEditingUpdateMode property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetClientEditingUpdateMode()
        {
			this.Reset("ClientEditingUpdateMode");
        }
        
		
		/// <summary>
		/// Represents client-side behavior.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Represents client-side behavior.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public C1.Web.Wijmo.Controls.C1GridView.SelectionMode ClientSelectionMode
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1GridView.SelectionMode)this.GetProperty("ClientSelectionMode");
            }
            set
            {
                this.SetProperty("ClientSelectionMode", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Represents client-side behavior. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ClientSelectionMode property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeClientSelectionMode()
        {
			return this.ShouldSerialize("ClientSelectionMode");
        }
        
        
        /// <summary>
		/// Resets the Represents client-side behavior. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ClientSelectionMode property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetClientSelectionMode()
        {
			this.Reset("ClientSelectionMode");
        }
        
		
		/// <summary>
		/// Gets a collection of objects representing the columns of the C1GridView control.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Default")]
        [System.ComponentModel.Description("Gets a collection of objects representing the columns of the C1GridView control.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public C1.Web.Wijmo.Controls.C1GridView.C1BaseFieldCollection Columns
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1GridView.C1BaseFieldCollection)this.GetProperty("Columns");
            }
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public System.Web.UI.IAutoFieldGenerator ColumnsGenerator
        {
            get
            {
                return (System.Web.UI.IAutoFieldGenerator)this.GetProperty("ColumnsGenerator");
            }
            set
            {
                this.SetProperty("ColumnsGenerator", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if  should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ColumnsGenerator property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeColumnsGenerator()
        {
			return this.ShouldSerialize("ColumnsGenerator");
        }
        
        
        /// <summary>
		/// Resets the  property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ColumnsGenerator property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetColumnsGenerator()
        {
			this.Reset("ColumnsGenerator");
        }
        
		
		/// <summary>
		/// Gets or sets an array that contains the names of the primary key fields for the items displayed in a C1GridView control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Data")]
        [System.ComponentModel.Description("Gets or sets an array that contains the names of the primary key fields for the items displayed in a C1GridView control.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String[] DataKeyNames
        {
            get
            {
                return (System.String[])this.GetProperty("DataKeyNames");
            }
            set
            {
                this.SetProperty("DataKeyNames", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets an array that contains the names of the primary key fields for the items displayed in a C1GridView control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the DataKeyNames property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeDataKeyNames()
        {
			return this.ShouldSerialize("DataKeyNames");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets an array that contains the names of the primary key fields for the items displayed in a C1GridView control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the DataKeyNames property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetDataKeyNames()
        {
			this.Reset("DataKeyNames");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public System.Web.UI.WebControls.DataKeyArray DataKeys
        {
            get
            {
                return (System.Web.UI.WebControls.DataKeyArray)this.GetProperty("DataKeys");
            }
        }
        
		
		/// <summary>
		/// Gets or sets the index of the item to be edited.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Default")]
        [System.ComponentModel.Description("Gets or sets the index of the item to be edited.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 EditIndex
        {
            get
            {
                return (System.Int32)this.GetProperty("EditIndex");
            }
            set
            {
                this.SetProperty("EditIndex", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets the index of the item to be edited. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the EditIndex property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeEditIndex()
        {
			return this.ShouldSerialize("EditIndex");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets the index of the item to be edited. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the EditIndex property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetEditIndex()
        {
			this.Reset("EditIndex");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Web.UI.ITemplate EmptyDataTemplate
        {
            get
            {
                return (System.Web.UI.ITemplate)this.GetProperty("EmptyDataTemplate");
            }
            set
            {
                this.SetProperty("EmptyDataTemplate", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if  should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the EmptyDataTemplate property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeEmptyDataTemplate()
        {
			return this.ShouldSerialize("EmptyDataTemplate");
        }
        
        
        /// <summary>
		/// Resets the  property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the EmptyDataTemplate property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetEmptyDataTemplate()
        {
			this.Reset("EmptyDataTemplate");
        }
        
		
		/// <summary>
		/// Gets or sets the text to display in the empty data row rendered when a C1GridView control is bound to a data source that does not contain any records.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Gets or sets the text to display in the empty data row rendered when a C1GridView control is bound to a data source that does not contain any records.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String EmptyDataText
        {
            get
            {
                return (System.String)this.GetProperty("EmptyDataText");
            }
            set
            {
                this.SetProperty("EmptyDataText", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets the text to display in the empty data row rendered when a C1GridView control is bound to a data source that does not contain any records. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the EmptyDataText property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeEmptyDataText()
        {
			return this.ShouldSerialize("EmptyDataText");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets the text to display in the empty data row rendered when a C1GridView control is bound to a data source that does not contain any records. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the EmptyDataText property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetEmptyDataText()
        {
			this.Reset("EmptyDataText");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow FilterRow
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow)this.GetProperty("FilterRow");
            }
        }
        
		
		/// <summary>
		/// Gets the FilterSettings object that defines the filter behaviors of the column at client-side.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Gets the FilterSettings object that defines the filter behaviors of the column at client-side.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public C1.Web.Wijmo.Controls.C1GridView.FilterSettings FilterSettings
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1GridView.FilterSettings)this.GetProperty("FilterSettings");
            }
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow FooterRow
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow)this.GetProperty("FooterRow");
            }
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow HeaderRow
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow)this.GetProperty("HeaderRow");
            }
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public System.Int32 PageCount
        {
            get
            {
                return (System.Int32)this.GetProperty("PageCount");
            }
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]   
        public System.String PostbackReference
        {
            get
            {
                return (System.String)this.GetProperty("PostbackReference");
            }
        }
        
		
		/// <summary>
		/// Gets or sets the name of the column to use as the column header for the C1GridView control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Accessibility")]
        [System.ComponentModel.Description("Gets or sets the name of the column to use as the column header for the C1GridView control.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String RowHeaderColumn
        {
            get
            {
                return (System.String)this.GetProperty("RowHeaderColumn");
            }
            set
            {
                this.SetProperty("RowHeaderColumn", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets the name of the column to use as the column header for the C1GridView control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the RowHeaderColumn property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeRowHeaderColumn()
        {
			return this.ShouldSerialize("RowHeaderColumn");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets the name of the column to use as the column header for the C1GridView control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the RowHeaderColumn property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetRowHeaderColumn()
        {
			this.Reset("RowHeaderColumn");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public C1.Web.Wijmo.Controls.C1GridView.C1GridViewRowCollection Rows
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1GridView.C1GridViewRowCollection)this.GetProperty("Rows");
            }
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public System.Web.UI.WebControls.DataKey SelectedDataKey
        {
            get
            {
                return (System.Web.UI.WebControls.DataKey)this.GetProperty("SelectedDataKey");
            }
        }
        
		
		/// <summary>
		/// Gets or sets the index of the selected row.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Gets or sets the index of the selected row.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 SelectedIndex
        {
            get
            {
                return (System.Int32)this.GetProperty("SelectedIndex");
            }
            set
            {
                this.SetProperty("SelectedIndex", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets the index of the selected row. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the SelectedIndex property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeSelectedIndex()
        {
			return this.ShouldSerialize("SelectedIndex");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets the index of the selected row. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the SelectedIndex property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetSelectedIndex()
        {
			this.Reset("SelectedIndex");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public System.Web.UI.WebControls.DataKey SelectedPersistedDataKey
        {
            get
            {
                return (System.Web.UI.WebControls.DataKey)this.GetProperty("SelectedPersistedDataKey");
            }
            set
            {
                this.SetProperty("SelectedPersistedDataKey", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if  should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the SelectedPersistedDataKey property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeSelectedPersistedDataKey()
        {
			return this.ShouldSerialize("SelectedPersistedDataKey");
        }
        
        
        /// <summary>
		/// Resets the  property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the SelectedPersistedDataKey property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetSelectedPersistedDataKey()
        {
			this.Reset("SelectedPersistedDataKey");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow SelectedRow
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1GridView.C1GridViewRow)this.GetProperty("SelectedRow");
            }
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]   
        public System.Object SelectedValue
        {
            get
            {
                return (System.Object)this.GetProperty("SelectedValue");
            }
        }
        
		
		/// <summary>
		/// Determines whether the header is displayed.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Determines whether the header is displayed.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowHeader
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowHeader");
            }
            set
            {
                this.SetProperty("ShowHeader", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines whether the header is displayed. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowHeader property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowHeader()
        {
			return this.ShouldSerialize("ShowHeader");
        }
        
        
        /// <summary>
		/// Resets the Determines whether the header is displayed. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowHeader property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowHeader()
        {
			this.Reset("ShowHeader");
        }
        
		
		/// <summary>
		/// Gets or sets a value indicating whether a C1GridView control renders its header in an accessible format.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Accessibility")]
        [System.ComponentModel.Description("Gets or sets a value indicating whether a C1GridView control renders its header in an accessible format.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean UseAccessibleHeader
        {
            get
            {
                return (System.Boolean)this.GetProperty("UseAccessibleHeader");
            }
            set
            {
                this.SetProperty("UseAccessibleHeader", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets a value indicating whether a C1GridView control renders its header in an accessible format. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the UseAccessibleHeader property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeUseAccessibleHeader()
        {
			return this.ShouldSerialize("UseAccessibleHeader");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets a value indicating whether a C1GridView control renders its header in an accessible format. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the UseAccessibleHeader property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetUseAccessibleHeader()
        {
			this.Reset("UseAccessibleHeader");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 VirtualItemCount
        {
            get
            {
                return (System.Int32)this.GetProperty("VirtualItemCount");
            }
            set
            {
                this.SetProperty("VirtualItemCount", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if  should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the VirtualItemCount property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeVirtualItemCount()
        {
			return this.ShouldSerialize("VirtualItemCount");
        }
        
        
        /// <summary>
		/// Resets the  property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the VirtualItemCount property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetVirtualItemCount()
        {
			this.Reset("VirtualItemCount");
        }
        
		
		/// <summary>
		/// Gets a reference to the TableItemStyle object that enables you to set the appearance of alternating data rows in a C1GridView control.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Style")]
        [System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of alternating data rows in a C1GridView control.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public System.Web.UI.WebControls.TableItemStyle AlternatingRowStyle
        {
            get
            {
                return (System.Web.UI.WebControls.TableItemStyle)this.GetProperty("AlternatingRowStyle");
            }
        }
        
		
		/// <summary>
		/// Gets a reference to the TableItemStyle object that enables you to set the appearance of the row selected for editing in a C1GridView control.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Style")]
        [System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of the row selected for editing in a C1GridView control.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public System.Web.UI.WebControls.TableItemStyle EditRowStyle
        {
            get
            {
                return (System.Web.UI.WebControls.TableItemStyle)this.GetProperty("EditRowStyle");
            }
        }
        
		
		/// <summary>
		/// Gets a reference to the TableItemStyle object that enables you to set the appearance of the empty data row rendered when a C1GridView control is bound to a data source that does not contain any records.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Style")]
        [System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of the empty data row rendered when a C1GridView control is bound to a data source that does not contain any records.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public System.Web.UI.WebControls.TableItemStyle EmptyDataRowStyle
        {
            get
            {
                return (System.Web.UI.WebControls.TableItemStyle)this.GetProperty("EmptyDataRowStyle");
            }
        }
        
		
		/// <summary>
		/// Gets a reference to the TableItemStyle object that enables you to set the appearance of the filter row in a C1GridView control.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Style")]
        [System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of the filter row in a C1GridView control.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public System.Web.UI.WebControls.TableItemStyle FilterStyle
        {
            get
            {
                return (System.Web.UI.WebControls.TableItemStyle)this.GetProperty("FilterStyle");
            }
        }
        
		
		/// <summary>
		/// Gets a reference to the TableItemStyle object that enables you to set the appearance of the footer row in a C1GridView control.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Style")]
        [System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of the footer row in a C1GridView control.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public System.Web.UI.WebControls.TableItemStyle FooterStyle
        {
            get
            {
                return (System.Web.UI.WebControls.TableItemStyle)this.GetProperty("FooterStyle");
            }
        }
        
		
		/// <summary>
		/// Gets a reference to the TableItemStyle object that enables you to set the appearance of the header row in a C1GridView control.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Style")]
        [System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of the header row in a C1GridView control.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public System.Web.UI.WebControls.TableItemStyle HeaderStyle
        {
            get
            {
                return (System.Web.UI.WebControls.TableItemStyle)this.GetProperty("HeaderStyle");
            }
        }
        
		
		/// <summary>
		/// Gets a reference to the TableItemStyle object that enables you to set the appearance of the data rows in a C1GridView control.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Style")]
        [System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of the data rows in a C1GridView control.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public System.Web.UI.WebControls.TableItemStyle RowStyle
        {
            get
            {
                return (System.Web.UI.WebControls.TableItemStyle)this.GetProperty("RowStyle");
            }
        }
        
		
		/// <summary>
		/// Gets a reference to the TableItemStyle object that enables you to set the appearance of the selected row in a C1GridView control.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Style")]
        [System.ComponentModel.Description("Gets a reference to the TableItemStyle object that enables you to set the appearance of the selected row in a C1GridView control.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public System.Web.UI.WebControls.TableItemStyle SelectedRowStyle
        {
            get
            {
                return (System.Web.UI.WebControls.TableItemStyle)this.GetProperty("SelectedRowStyle");
            }
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public System.Collections.Hashtable InnerState
        {
            get
            {
                return (System.Collections.Hashtable)this.GetProperty("InnerState");
            }
        }
        
		
		/// <summary>
		/// Name of the theme that will be used to style widgets. Available themes: aristo / midnight / ui-lightness. Note, only one theme can be used for the whole page at one time. Please, make sure that all widget extenders have the same Theme value.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Name of the theme that will be used to style widgets. Available themes: aristo / midnight / ui-lightness. Note, only one theme can be used for the whole page at one time. Please, make sure that all widget extenders have the same Theme value.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public System.String Theme
        {
            get
            {
                return (System.String)this.GetProperty("Theme");
            }
            set
            {
                this.SetProperty("Theme", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Name of the theme that will be used to style widgets. Available themes: aristo / midnight / ui-lightness. Note, only one theme can be used for the whole page at one time. Please, make sure that all widget extenders have the same Theme value. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Theme property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeTheme()
        {
			return this.ShouldSerialize("Theme");
        }
        
        
        /// <summary>
		/// Resets the Name of the theme that will be used to style widgets. Available themes: aristo / midnight / ui-lightness. Note, only one theme can be used for the whole page at one time. Please, make sure that all widget extenders have the same Theme value. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Theme property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetTheme()
        {
			this.Reset("Theme");
        }
        
		
		/// <summary>
		/// Determines whether this extender loads client script references from CDN.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Determines whether this extender loads client script references from CDN.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public System.Boolean UseCDN
        {
            get
            {
                return (System.Boolean)this.GetProperty("UseCDN");
            }
            set
            {
                this.SetProperty("UseCDN", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Determines whether this extender loads client script references from CDN. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the UseCDN property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeUseCDN()
        {
			return this.ShouldSerialize("UseCDN");
        }
        
        
        /// <summary>
		/// Resets the Determines whether this extender loads client script references from CDN. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the UseCDN property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetUseCDN()
        {
			this.Reset("UseCDN");
        }
        
		
		/// <summary>
		/// Content Delivery Network path.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Content Delivery Network path.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public System.String CDNPath
        {
            get
            {
                return (System.String)this.GetProperty("CDNPath");
            }
            set
            {
                this.SetProperty("CDNPath", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Content Delivery Network path. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the CDNPath property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeCDNPath()
        {
			return this.ShouldSerialize("CDNPath");
        }
        
        
        /// <summary>
		/// Resets the Content Delivery Network path. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the CDNPath property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetCDNPath()
        {
			this.Reset("CDNPath");
        }
        
		
		/// <summary>
		/// Indicates the control applies the theme of JQuery UI or Bootstrap.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Indicates the control applies the theme of JQuery UI or Bootstrap.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public System.String WijmoCssAdapter
        {
            get
            {
                return (System.String)this.GetProperty("WijmoCssAdapter");
            }
            set
            {
                this.SetProperty("WijmoCssAdapter", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Indicates the control applies the theme of JQuery UI or Bootstrap. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the WijmoCssAdapter property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeWijmoCssAdapter()
        {
			return this.ShouldSerialize("WijmoCssAdapter");
        }
        
        
        /// <summary>
		/// Resets the Indicates the control applies the theme of JQuery UI or Bootstrap. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the WijmoCssAdapter property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetWijmoCssAdapter()
        {
			this.Reset("WijmoCssAdapter");
        }
        
		
		/// <summary>
		/// A value that indicates mode of the control, whether it is a mobile or web control. Note that only one value can be used for the whole website or project.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("A value that indicates mode of the control, whether it is a mobile or web control. Note that only one value can be used for the whole website or project.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public C1.Web.Wijmo.Controls.WijmoControlMode WijmoControlMode
        {
            get
            {
                return (C1.Web.Wijmo.Controls.WijmoControlMode)this.GetProperty("WijmoControlMode");
            }
            set
            {
                this.SetProperty("WijmoControlMode", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates mode of the control, whether it is a mobile or web control. Note that only one value can be used for the whole website or project. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the WijmoControlMode property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeWijmoControlMode()
        {
			return this.ShouldSerialize("WijmoControlMode");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates mode of the control, whether it is a mobile or web control. Note that only one value can be used for the whole website or project. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the WijmoControlMode property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetWijmoControlMode()
        {
			this.Reset("WijmoControlMode");
        }
        
		
		/// <summary>
		/// A value that indicates the theme swatch of  the control, this property only works when WijmoControlMode property is Mobile.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("A value that indicates the theme swatch of  the control, this property only works when WijmoControlMode property is Mobile.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public System.String ThemeSwatch
        {
            get
            {
                return (System.String)this.GetProperty("ThemeSwatch");
            }
            set
            {
                this.SetProperty("ThemeSwatch", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates the theme swatch of  the control, this property only works when WijmoControlMode property is Mobile. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ThemeSwatch property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeThemeSwatch()
        {
			return this.ShouldSerialize("ThemeSwatch");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates the theme swatch of  the control, this property only works when WijmoControlMode property is Mobile. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ThemeSwatch property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetThemeSwatch()
        {
			this.Reset("ThemeSwatch");
        }
        
		
		/// <summary>
		/// Indicates whether control is enabled.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Indicates whether control is enabled.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean HostedEnabled
        {
            get
            {
                return (System.Boolean)this.GetProperty("Enabled");
            }
            set
            {
                this.SetProperty("Enabled", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Indicates whether control is enabled. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Enabled property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHostedEnabled()
        {
			return this.ShouldSerialize("Enabled");
        }
        
        
        /// <summary>
		/// Resets the Indicates whether control is enabled. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Enabled property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHostedEnabled()
        {
			this.Reset("Enabled");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public System.Boolean DisabledState
        {
            get
            {
                return (System.Boolean)this.GetProperty("DisabledState");
            }
            set
            {
                this.SetProperty("DisabledState", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if  should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the DisabledState property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeDisabledState()
        {
			return this.ShouldSerialize("DisabledState");
        }
        
        
        /// <summary>
		/// Resets the  property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the DisabledState property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetDisabledState()
        {
			this.Reset("DisabledState");
        }
        
		
		/// <summary>
		/// Color of the background of the control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Color of the background of the control.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color HostedBackColor
        {
            get
            {
                return (System.Drawing.Color)this.GetProperty("BackColor");
            }
            set
            {
                this.SetProperty("BackColor", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Color of the background of the control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the BackColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHostedBackColor()
        {
			return this.ShouldSerialize("BackColor");
        }
        
        
        /// <summary>
		/// Resets the Color of the background of the control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the BackColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHostedBackColor()
        {
			this.Reset("BackColor");
        }
        
		
		/// <summary>
		/// Color of the border around the control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Color of the border around the control.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color HostedBorderColor
        {
            get
            {
                return (System.Drawing.Color)this.GetProperty("BorderColor");
            }
            set
            {
                this.SetProperty("BorderColor", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Color of the border around the control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the BorderColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHostedBorderColor()
        {
			return this.ShouldSerialize("BorderColor");
        }
        
        
        /// <summary>
		/// Resets the Color of the border around the control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the BorderColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHostedBorderColor()
        {
			this.Reset("BorderColor");
        }
        
		
		/// <summary>
		/// Style of the border around the control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Style of the border around the control.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Web.UI.WebControls.BorderStyle HostedBorderStyle
        {
            get
            {
                return (System.Web.UI.WebControls.BorderStyle)this.GetProperty("BorderStyle");
            }
            set
            {
                this.SetProperty("BorderStyle", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Style of the border around the control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the BorderStyle property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHostedBorderStyle()
        {
			return this.ShouldSerialize("BorderStyle");
        }
        
        
        /// <summary>
		/// Resets the Style of the border around the control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the BorderStyle property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHostedBorderStyle()
        {
			this.Reset("BorderStyle");
        }
        
		
		/// <summary>
		/// Width of the border around the control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Width of the border around the control.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Web.UI.WebControls.Unit HostedBorderWidth
        {
            get
            {
                return (System.Web.UI.WebControls.Unit)this.GetProperty("BorderWidth");
            }
            set
            {
                this.SetProperty("BorderWidth", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Width of the border around the control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the BorderWidth property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHostedBorderWidth()
        {
			return this.ShouldSerialize("BorderWidth");
        }
        
        
        /// <summary>
		/// Resets the Width of the border around the control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the BorderWidth property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHostedBorderWidth()
        {
			this.Reset("BorderWidth");
        }
        
		
		/// <summary>
		/// The font used for text within the control.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The font used for text within the control.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public System.Web.UI.WebControls.FontInfo HostedFont
        {
            get
            {
                return (System.Web.UI.WebControls.FontInfo)this.GetProperty("Font");
            }
        }
        
		
		/// <summary>
		/// Color of the text within the control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Color of the text within the control.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Drawing.Color HostedForeColor
        {
            get
            {
                return (System.Drawing.Color)this.GetProperty("ForeColor");
            }
            set
            {
                this.SetProperty("ForeColor", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Color of the text within the control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ForeColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHostedForeColor()
        {
			return this.ShouldSerialize("ForeColor");
        }
        
        
        /// <summary>
		/// Resets the Color of the text within the control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ForeColor property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHostedForeColor()
        {
			this.Reset("ForeColor");
        }
        
		
		/// <summary>
		/// The collection of child controls owned by the control.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("The collection of child controls owned by the control.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public System.Web.UI.ControlCollection HostedControls
        {
            get
            {
                return (System.Web.UI.ControlCollection)this.GetProperty("Controls");
            }
        }
        
		
		/// <summary>
		/// The table or view used for binding against.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Data")]
        [System.ComponentModel.Description("The table or view used for binding against.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String DataMember
        {
            get
            {
                return (System.String)this.GetProperty("DataMember");
            }
            set
            {
                this.SetProperty("DataMember", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The table or view used for binding against. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the DataMember property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeDataMember()
        {
			return this.ShouldSerialize("DataMember");
        }
        
        
        /// <summary>
		/// Resets the The table or view used for binding against. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the DataMember property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetDataMember()
        {
			this.Reset("DataMember");
        }
        
		
		/// <summary>
		/// The name of the model type used in the SelectMethod, InsertMethod, UpdateMethod, and DeleteMethod.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Data")]
        [System.ComponentModel.Description("The name of the model type used in the SelectMethod, InsertMethod, UpdateMethod, and DeleteMethod.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String ItemType
        {
            get
            {
                return (System.String)this.GetProperty("ItemType");
            }
            set
            {
                this.SetProperty("ItemType", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The name of the model type used in the SelectMethod, InsertMethod, UpdateMethod, and DeleteMethod. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ItemType property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeItemType()
        {
			return this.ShouldSerialize("ItemType");
        }
        
        
        /// <summary>
		/// Resets the The name of the model type used in the SelectMethod, InsertMethod, UpdateMethod, and DeleteMethod. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ItemType property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetItemType()
        {
			this.Reset("ItemType");
        }
        
		
		/// <summary>
		/// The name of the method on the page that is called when this control does a select operation.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Data")]
        [System.ComponentModel.Description("The name of the method on the page that is called when this control does a select operation.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String SelectMethod
        {
            get
            {
                return (System.String)this.GetProperty("SelectMethod");
            }
            set
            {
                this.SetProperty("SelectMethod", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The name of the method on the page that is called when this control does a select operation. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the SelectMethod property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeSelectMethod()
        {
			return this.ShouldSerialize("SelectMethod");
        }
        
        
        /// <summary>
		/// Resets the The name of the method on the page that is called when this control does a select operation. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the SelectMethod property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetSelectMethod()
        {
			this.Reset("SelectMethod");
        }
        
		
		/// <summary>
		/// The control ID of an IDataSource that will be used as the data source.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Data")]
        [System.ComponentModel.Description("The control ID of an IDataSource that will be used as the data source.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String DataSourceID
        {
            get
            {
                return (System.String)this.GetProperty("DataSourceID");
            }
            set
            {
                this.SetProperty("DataSourceID", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The control ID of an IDataSource that will be used as the data source. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the DataSourceID property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeDataSourceID()
        {
			return this.ShouldSerialize("DataSourceID");
        }
        
        
        /// <summary>
		/// Resets the The control ID of an IDataSource that will be used as the data source. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the DataSourceID property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetDataSourceID()
        {
			this.Reset("DataSourceID");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public System.Web.UI.IDataSource DataSourceObject
        {
            get
            {
                return (System.Web.UI.IDataSource)this.GetProperty("DataSourceObject");
            }
        }
        
		
		/// <summary>
		/// The data source that is used to populate the items in the list.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Data")]
        [System.ComponentModel.Description("The data source that is used to populate the items in the list.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public System.Object DataSource
        {
            get
            {
                return (System.Object)this.GetProperty("DataSource");
            }
            set
            {
                this.SetProperty("DataSource", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The data source that is used to populate the items in the list. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the DataSource property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeDataSource()
        {
			return this.ShouldSerialize("DataSource");
        }
        
        
        /// <summary>
		/// Resets the The data source that is used to populate the items in the list. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the DataSource property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetDataSource()
        {
			this.Reset("DataSource");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]   
        public System.Boolean SupportsDisabledAttribute
        {
            get
            {
                return (System.Boolean)this.GetProperty("SupportsDisabledAttribute");
            }
        }
        

        
        #endregion
        
        #region Methods
		
        /// <summary>
		/// Clean up any resources being used.
		/// </summary>
	    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}
		
		
		
		#endregion
		
		#region Events
		
		
        /// <summary>
        /// Occurs in client editing mode when edits done by user should be persisted to underlying dataset.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs in client editing mode when edits done by user should be persisted to underlying dataset.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewBeginRowUpdateEventHandler BeginRowUpdate
        {
            add
            {
                this.AddEventHandler("BeginRowUpdate", value);
            }
            remove
            {
                this.RemoveEventHandler("BeginRowUpdate", value);
            }
        }
        

        /// <summary>
        /// Occurs when a column has been grouped.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when a column has been grouped.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnGroupedEventHandler ColumnGrouped
        {
            add
            {
                this.AddEventHandler("ColumnGrouped", value);
            }
            remove
            {
                this.RemoveEventHandler("ColumnGrouped", value);
            }
        }
        

        /// <summary>
        /// Occurs when a column is grouped, but before the C1GridView handles the operation.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when a column is grouped, but before the C1GridView handles the operation.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnGroupEventHandler ColumnGrouping
        {
            add
            {
                this.AddEventHandler("ColumnGrouping", value);
            }
            remove
            {
                this.RemoveEventHandler("ColumnGrouping", value);
            }
        }
        

        /// <summary>
        /// Occurs when a column has been moved.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when a column has been moved.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnMovedEventHandler ColumnMoved
        {
            add
            {
                this.AddEventHandler("ColumnMoved", value);
            }
            remove
            {
                this.RemoveEventHandler("ColumnMoved", value);
            }
        }
        

        /// <summary>
        /// Occurs when a column is moved, but before the C1GridView handles the operation.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when a column is moved, but before the C1GridView handles the operation.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnMoveEventHandler ColumnMoving
        {
            add
            {
                this.AddEventHandler("ColumnMoving", value);
            }
            remove
            {
                this.RemoveEventHandler("ColumnMoving", value);
            }
        }
        

        /// <summary>
        /// Occurs when a column has been ungrouped.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when a column has been ungrouped.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnUngroupedEventHandler ColumnUngrouped
        {
            add
            {
                this.AddEventHandler("ColumnUngrouped", value);
            }
            remove
            {
                this.RemoveEventHandler("ColumnUngrouped", value);
            }
        }
        

        /// <summary>
        /// OOccurs when a column is ungrouped, but before the C1GridView handles the operation.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("OOccurs when a column is ungrouped, but before the C1GridView handles the operation.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewColumnUngroupEventHandler ColumnUngrouping
        {
            add
            {
                this.AddEventHandler("ColumnUngrouping", value);
            }
            remove
            {
                this.RemoveEventHandler("ColumnUngrouping", value);
            }
        }
        

        /// <summary>
        /// Occurs in client editing mode when edits done by user should be persisted to underlying dataset.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs in client editing mode when edits done by user should be persisted to underlying dataset.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewEndRowUpdatedEventHandler EndRowUpdated
        {
            add
            {
                this.AddEventHandler("EndRowUpdated", value);
            }
            remove
            {
                this.RemoveEventHandler("EndRowUpdated", value);
            }
        }
        

        /// <summary>
        /// Occurs after filter expression is applied to the underlying DataView's RowFilter property.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs after filter expression is applied to the underlying DataView\u0027s RowFilter property.")]
        [System.ComponentModel.Browsable(true)] 
        public event System.EventHandler Filtered
        {
            add
            {
                this.AddEventHandler("Filtered", value);
            }
            remove
            {
                this.RemoveEventHandler("Filtered", value);
            }
        }
        

        /// <summary>
        /// Occurs when the preparation for filtering is started but before the C1GridView instance handles the filter operation.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when the preparation for filtering is started but before the C1GridView instance handles the filter operation.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewFilterEventHandler Filtering
        {
            add
            {
                this.AddEventHandler("Filtering", value);
            }
            remove
            {
                this.RemoveEventHandler("Filtering", value);
            }
        }
        

        /// <summary>
        /// Occurs when one of the pager buttons is clicked, but after the C1GridView control handles the paging operation.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when one of the pager buttons is clicked, but after the C1GridView control handles the paging operation.")]
        [System.ComponentModel.Browsable(true)] 
        public event System.EventHandler PageIndexChanged
        {
            add
            {
                this.AddEventHandler("PageIndexChanged", value);
            }
            remove
            {
                this.RemoveEventHandler("PageIndexChanged", value);
            }
        }
        

        /// <summary>
        /// Occurs when one of the pager buttons is clicked, but before the C1GridView control handles the paging operation.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when one of the pager buttons is clicked, but before the C1GridView control handles the paging operation.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewPageEventHandler PageIndexChanging
        {
            add
            {
                this.AddEventHandler("PageIndexChanging", value);
            }
            remove
            {
                this.RemoveEventHandler("PageIndexChanging", value);
            }
        }
        

        /// <summary>
        /// Occurs when the Cancel button of a item in edit mode is clicked, but before the item exits edit mode.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when the Cancel button of a item in edit mode is clicked, but before the item exits edit mode.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewCancelEditEventHandler RowCancelingEdit
        {
            add
            {
                this.AddEventHandler("RowCancelingEdit", value);
            }
            remove
            {
                this.RemoveEventHandler("RowCancelingEdit", value);
            }
        }
        

        /// <summary>
        /// Occurs when a button is clicked in a C1GridView control.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when a button is clicked in a C1GridView control.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewCommandEventHandler RowCommand
        {
            add
            {
                this.AddEventHandler("RowCommand", value);
            }
            remove
            {
                this.RemoveEventHandler("RowCommand", value);
            }
        }
        

        /// <summary>
        /// Occurs when a row is created in a C1GridView control.
        /// </summary>
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Occurs when a row is created in a C1GridView control.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewRowEventHandler RowCreated
        {
            add
            {
                this.AddEventHandler("RowCreated", value);
            }
            remove
            {
                this.RemoveEventHandler("RowCreated", value);
            }
        }
        

        /// <summary>
        /// Occurs when a row is bound to data in a C1GridView control.
        /// </summary>
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Occurs when a row is bound to data in a C1GridView control.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewRowEventHandler RowDataBound
        {
            add
            {
                this.AddEventHandler("RowDataBound", value);
            }
            remove
            {
                this.RemoveEventHandler("RowDataBound", value);
            }
        }
        

        /// <summary>
        /// occurs when the Delete button is clicked, but before the C1GridView instance handles the delete operation.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("occurs when the Delete button is clicked, but before the C1GridView instance handles the delete operation.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewDeleteEventHandler RowDeleting
        {
            add
            {
                this.AddEventHandler("RowDeleting", value);
            }
            remove
            {
                this.RemoveEventHandler("RowDeleting", value);
            }
        }
        

        /// <summary>
        /// Occurs when the Delete button is clicked.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when the Delete button is clicked.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewDeleteEventHandler RowDeleted
        {
            add
            {
                this.AddEventHandler("RowDeleted", value);
            }
            remove
            {
                this.RemoveEventHandler("RowDeleted", value);
            }
        }
        

        /// <summary>
        /// Occurs when the Edit button is clicked, but before the C1GridView instance handles the operation.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when the Edit button is clicked, but before the C1GridView instance handles the operation.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewEditEventHandler RowEditing
        {
            add
            {
                this.AddEventHandler("RowEditing", value);
            }
            remove
            {
                this.RemoveEventHandler("RowEditing", value);
            }
        }
        

        /// <summary>
        /// Occurs when a row's Update button is clicked, but before the C1GridView control handles the update operation.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when a row\u0027s Update button is clicked, but before the C1GridView control handles the update operation.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewUpdateEventHandler RowUpdating
        {
            add
            {
                this.AddEventHandler("RowUpdating", value);
            }
            remove
            {
                this.RemoveEventHandler("RowUpdating", value);
            }
        }
        

        /// <summary>
        /// Occurs when a row's Update button is clicked, but after the C1GridView control handles the update operation.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when a row\u0027s Update button is clicked, but after the C1GridView control handles the update operation.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewUpdatedEventHandler RowUpdated
        {
            add
            {
                this.AddEventHandler("RowUpdated", value);
            }
            remove
            {
                this.RemoveEventHandler("RowUpdated", value);
            }
        }
        

        /// <summary>
        /// Occurs when a row's Select button is clicked, but after the C1GridView control handles the select operation.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when a row\u0027s Select button is clicked, but after the C1GridView control handles the select operation.")]
        [System.ComponentModel.Browsable(true)] 
        public event System.EventHandler SelectedIndexChanged
        {
            add
            {
                this.AddEventHandler("SelectedIndexChanged", value);
            }
            remove
            {
                this.RemoveEventHandler("SelectedIndexChanged", value);
            }
        }
        

        /// <summary>
        /// Occurs when a row's Select button is clicked, but before the C1GridView control handles the select operation.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when a row\u0027s Select button is clicked, but before the C1GridView control handles the select operation.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewSelectEventHandler SelectedIndexChanging
        {
            add
            {
                this.AddEventHandler("SelectedIndexChanging", value);
            }
            remove
            {
                this.RemoveEventHandler("SelectedIndexChanging", value);
            }
        }
        

        /// <summary>
        /// Occurs when the hyperlink to sort a column is clicked, but after the C1GridView control handles the sort operation.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when the hyperlink to sort a column is clicked, but after the C1GridView control handles the sort operation.")]
        [System.ComponentModel.Browsable(true)] 
        public event System.EventHandler Sorted
        {
            add
            {
                this.AddEventHandler("Sorted", value);
            }
            remove
            {
                this.RemoveEventHandler("Sorted", value);
            }
        }
        

        /// <summary>
        /// Occurs when the hyperlink to sort a column is clicked, but before the C1GridView control handles the sort operation.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs when the hyperlink to sort a column is clicked, but before the C1GridView control handles the sort operation.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1GridView.C1GridViewSortEventHandler Sorting
        {
            add
            {
                this.AddEventHandler("Sorting", value);
            }
            remove
            {
                this.RemoveEventHandler("Sorting", value);
            }
        }
        

        ///// <summary>
        ///// Raised before the data bound control is data binding using data methods.
        ///// </summary>
        //[System.ComponentModel.Category("Data")]
        //[System.ComponentModel.Description("Raised before the data bound control is data binding using data methods.")]
        //[System.ComponentModel.Browsable(true)] 
        //public event System.Web.UI.WebControls.CreatingModelDataSourceEventHandler CreatingModelDataSource
        //{
        //    add
        //    {
        //        this.AddEventHandler("CreatingModelDataSource", value);
        //    }
        //    remove
        //    {
        //        this.RemoveEventHandler("CreatingModelDataSource", value);
        //    }
        //}
        

        ///// <summary>
        ///// Occurs before model methods are invoked for data operations. Handle this event if the model methods are defined on a custom type other than the code behind file.
        ///// </summary>
        //[System.ComponentModel.Category("Data")]
        //[System.ComponentModel.Description("Occurs before model methods are invoked for data operations. Handle this event if the model methods are defined on a custom type other than the code behind file.")]
        //[System.ComponentModel.Browsable(true)] 
        //public event System.Web.UI.WebControls.CallingDataMethodsEventHandler CallingDataMethods
        //{
        //    add
        //    {
        //        this.AddEventHandler("CallingDataMethods", value);
        //    }
        //    remove
        //    {
        //        this.RemoveEventHandler("CallingDataMethods", value);
        //    }
        //}
        

        /// <summary>
        /// Fires after the control has been databound.
        /// </summary>
        [System.ComponentModel.Category("Data")]
        [System.ComponentModel.Description("Fires after the control has been databound.")]
        [System.ComponentModel.Browsable(true)] 
        public event System.EventHandler DataBound
        {
            add
            {
                this.AddEventHandler("DataBound", value);
            }
            remove
            {
                this.RemoveEventHandler("DataBound", value);
            }
        }
        

		
		#endregion
		
	}
}
