namespace ComponentOneSampleAppsCS
{
	partial class C1BarChartWrapper
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
                return typeof(C1.Web.Wijmo.Controls.C1Chart.C1BarChart);
            }
        }
        
        /// <summary>
        /// Get hosted control typed instance
        /// </summary>
        protected C1.Web.Wijmo.Controls.C1Chart.C1BarChart HostedC1BarChart
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1Chart.C1BarChart)this.HostedControl;
            }
        }
        
        		
		/// <summary>
		/// A value that determines whether the bar chart renders horizontal or vertical.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("A value that determines whether the bar chart renders horizontal or vertical.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean Horizontal
        {
            get
            {
                return (System.Boolean)this.GetProperty("Horizontal");
            }
            set
            {
                this.SetProperty("Horizontal", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that determines whether the bar chart renders horizontal or vertical. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Horizontal property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHorizontal()
        {
			return this.ShouldSerialize("Horizontal");
        }
        
        
        /// <summary>
		/// Resets the A value that determines whether the bar chart renders horizontal or vertical. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Horizontal property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHorizontal()
        {
			this.Reset("Horizontal");
        }
        
		
		/// <summary>
		/// A value that determines whether to show a stacked chart.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("A value that determines whether to show a stacked chart.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean Stacked
        {
            get
            {
                return (System.Boolean)this.GetProperty("Stacked");
            }
            set
            {
                this.SetProperty("Stacked", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that determines whether to show a stacked chart. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Stacked property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeStacked()
        {
			return this.ShouldSerialize("Stacked");
        }
        
        
        /// <summary>
		/// Resets the A value that determines whether to show a stacked chart. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Stacked property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetStacked()
        {
			this.Reset("Stacked");
        }
        
		
		/// <summary>
		/// A value that determines whether to show a stacked and percentage chart.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("A value that determines whether to show a stacked and percentage chart.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean Is100Percent
        {
            get
            {
                return (System.Boolean)this.GetProperty("Is100Percent");
            }
            set
            {
                this.SetProperty("Is100Percent", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that determines whether to show a stacked and percentage chart. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Is100Percent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeIs100Percent()
        {
			return this.ShouldSerialize("Is100Percent");
        }
        
        
        /// <summary>
		/// Resets the A value that determines whether to show a stacked and percentage chart. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Is100Percent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetIs100Percent()
        {
			this.Reset("Is100Percent");
        }
        
		
		/// <summary>
		/// A value that indicates the percentage of bar elements in the same cluster overlap.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("A value that indicates the percentage of bar elements in the same cluster overlap.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 ClusterOverlap
        {
            get
            {
                return (System.Int32)this.GetProperty("ClusterOverlap");
            }
            set
            {
                this.SetProperty("ClusterOverlap", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates the percentage of bar elements in the same cluster overlap. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ClusterOverlap property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeClusterOverlap()
        {
			return this.ShouldSerialize("ClusterOverlap");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates the percentage of bar elements in the same cluster overlap. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ClusterOverlap property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetClusterOverlap()
        {
			this.Reset("ClusterOverlap");
        }
        
		
		/// <summary>
		/// A value that indicates the percentage of the plotarea that each bar cluster occupies.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("A value that indicates the percentage of the plotarea that each bar cluster occupies.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 ClusterWidth
        {
            get
            {
                return (System.Int32)this.GetProperty("ClusterWidth");
            }
            set
            {
                this.SetProperty("ClusterWidth", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates the percentage of the plotarea that each bar cluster occupies. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ClusterWidth property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeClusterWidth()
        {
			return this.ShouldSerialize("ClusterWidth");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates the percentage of the plotarea that each bar cluster occupies. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ClusterWidth property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetClusterWidth()
        {
			this.Reset("ClusterWidth");
        }
        
		
		/// <summary>
		/// A value that indicates the corner-radius for the bar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("A value that indicates the corner-radius for the bar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 ClusterRadius
        {
            get
            {
                return (System.Int32)this.GetProperty("ClusterRadius");
            }
            set
            {
                this.SetProperty("ClusterRadius", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates the corner-radius for the bar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ClusterRadius property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeClusterRadius()
        {
			return this.ShouldSerialize("ClusterRadius");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates the corner-radius for the bar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ClusterRadius property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetClusterRadius()
        {
			this.Reset("ClusterRadius");
        }
        
		
		/// <summary>
		/// A value that indicates the spacing between the adjacent bars.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("A value that indicates the spacing between the adjacent bars.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 ClusterSpacing
        {
            get
            {
                return (System.Int32)this.GetProperty("ClusterSpacing");
            }
            set
            {
                this.SetProperty("ClusterSpacing", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates the spacing between the adjacent bars. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ClusterSpacing property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeClusterSpacing()
        {
			return this.ShouldSerialize("ClusterSpacing");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates the spacing between the adjacent bars. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ClusterSpacing property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetClusterSpacing()
        {
			this.Reset("ClusterSpacing");
        }
        
		
		/// <summary>
		/// A value that indicates whether to show animation and the duration and effect for the animation when reload data.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("A value that indicates whether to show animation and the duration and effect for the animation when reload data.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public C1.Web.Wijmo.Controls.C1Chart.ChartAnimation SeriesTransition
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1Chart.ChartAnimation)this.GetProperty("SeriesTransition");
            }
            set
            {
                this.SetProperty("SeriesTransition", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates whether to show animation and the duration and effect for the animation when reload data. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the SeriesTransition property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeSeriesTransition()
        {
			return this.ShouldSerialize("SeriesTransition");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates whether to show animation and the duration and effect for the animation when reload data. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the SeriesTransition property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetSeriesTransition()
        {
			this.Reset("SeriesTransition");
        }
        
		
		/// <summary>
		/// A value that indicates whether to show animation and the duration and easing for the animation.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("A value that indicates whether to show animation and the duration and easing for the animation.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public C1.Web.Wijmo.Controls.C1Chart.ChartAnimation Animation
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1Chart.ChartAnimation)this.GetProperty("Animation");
            }
            set
            {
                this.SetProperty("Animation", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates whether to show animation and the duration and easing for the animation. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Animation property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAnimation()
        {
			return this.ShouldSerialize("Animation");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates whether to show animation and the duration and easing for the animation. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Animation property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAnimation()
        {
			this.Reset("Animation");
        }
        
		
		/// <summary>
		/// An array collection that contains the data to be charted.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Data")]
        [System.ComponentModel.Description("An array collection that contains the data to be charted.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]   
        public System.Collections.Generic.List<C1.Web.Wijmo.Controls.C1Chart.BarChartSeries> SeriesList
        {
            get
            {
                return (System.Collections.Generic.List<C1.Web.Wijmo.Controls.C1Chart.BarChartSeries>)this.GetProperty("SeriesList");
            }
        }
        
		
		/// <summary>
		/// An array collection that contains the style to be charted.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Style")]
        [System.ComponentModel.Description("An array collection that contains the style to be charted.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]   
        public System.Collections.Generic.List<C1.Web.Wijmo.Controls.C1Chart.ChartStyle> SeriesStyles
        {
            get
            {
                return (System.Collections.Generic.List<C1.Web.Wijmo.Controls.C1Chart.ChartStyle>)this.GetProperty("SeriesStyles");
            }
        }
        
		
		/// <summary>
		/// An array collection that contains the style to be charted when hovering the chart element.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Style")]
        [System.ComponentModel.Description("An array collection that contains the style to be charted when hovering the chart element.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]   
        public System.Collections.Generic.List<C1.Web.Wijmo.Controls.C1Chart.ChartStyle> SeriesHoverStyles
        {
            get
            {
                return (System.Collections.Generic.List<C1.Web.Wijmo.Controls.C1Chart.ChartStyle>)this.GetProperty("SeriesHoverStyles");
            }
        }
        
		
		/// <summary>
		/// Gets or sets the culture information for the input control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Gets or sets the culture information for the input control.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Globalization.CultureInfo Culture
        {
            get
            {
                return (System.Globalization.CultureInfo)this.GetProperty("Culture");
            }
            set
            {
                this.SetProperty("Culture", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets the culture information for the input control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Culture property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeCulture()
        {
			return this.ShouldSerialize("Culture");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets the culture information for the input control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Culture property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetCulture()
        {
			this.Reset("Culture");
        }
        
		
		/// <summary>
		/// A value that indicates the top margin of the chart area.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("A value that indicates the top margin of the chart area.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 MarginTop
        {
            get
            {
                return (System.Int32)this.GetProperty("MarginTop");
            }
            set
            {
                this.SetProperty("MarginTop", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates the top margin of the chart area. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the MarginTop property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeMarginTop()
        {
			return this.ShouldSerialize("MarginTop");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates the top margin of the chart area. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the MarginTop property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetMarginTop()
        {
			this.Reset("MarginTop");
        }
        
		
		/// <summary>
		/// A value that indicates the right margin of the chart area.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("A value that indicates the right margin of the chart area.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 MarginRight
        {
            get
            {
                return (System.Int32)this.GetProperty("MarginRight");
            }
            set
            {
                this.SetProperty("MarginRight", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates the right margin of the chart area. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the MarginRight property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeMarginRight()
        {
			return this.ShouldSerialize("MarginRight");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates the right margin of the chart area. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the MarginRight property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetMarginRight()
        {
			this.Reset("MarginRight");
        }
        
		
		/// <summary>
		/// A value that indicates the bottom margin of the chart area.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("A value that indicates the bottom margin of the chart area.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 MarginBottom
        {
            get
            {
                return (System.Int32)this.GetProperty("MarginBottom");
            }
            set
            {
                this.SetProperty("MarginBottom", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates the bottom margin of the chart area. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the MarginBottom property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeMarginBottom()
        {
			return this.ShouldSerialize("MarginBottom");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates the bottom margin of the chart area. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the MarginBottom property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetMarginBottom()
        {
			this.Reset("MarginBottom");
        }
        
		
		/// <summary>
		/// A value that indicates the left margin of the chart area.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("A value that indicates the left margin of the chart area.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 MarginLeft
        {
            get
            {
                return (System.Int32)this.GetProperty("MarginLeft");
            }
            set
            {
                this.SetProperty("MarginLeft", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates the left margin of the chart area. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the MarginLeft property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeMarginLeft()
        {
			return this.ShouldSerialize("MarginLeft");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates the left margin of the chart area. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the MarginLeft property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetMarginLeft()
        {
			this.Reset("MarginLeft");
        }
        
		
		/// <summary>
		/// A value that indicates the style of the chart text.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Style")]
        [System.ComponentModel.Description("A value that indicates the style of the chart text.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public C1.Web.Wijmo.Controls.C1Chart.ChartStyle TextStyle
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1Chart.ChartStyle)this.GetProperty("TextStyle");
            }
            set
            {
                this.SetProperty("TextStyle", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates the style of the chart text. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the TextStyle property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeTextStyle()
        {
			return this.ShouldSerialize("TextStyle");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates the style of the chart text. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the TextStyle property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetTextStyle()
        {
			this.Reset("TextStyle");
        }
        
		
		/// <summary>
		/// An object that value indicates the header of the chart element.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("An object that value indicates the header of the chart element.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public C1.Web.Wijmo.Controls.C1Chart.ChartTitle Header
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1Chart.ChartTitle)this.GetProperty("Header");
            }
            set
            {
                this.SetProperty("Header", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if An object that value indicates the header of the chart element. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Header property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHeader()
        {
			return this.ShouldSerialize("Header");
        }
        
        
        /// <summary>
		/// Resets the An object that value indicates the header of the chart element. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Header property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHeader()
        {
			this.Reset("Header");
        }
        
		
		/// <summary>
		/// An object value that indicates the footer of the chart element.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("An object value that indicates the footer of the chart element.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public C1.Web.Wijmo.Controls.C1Chart.ChartTitle Footer
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1Chart.ChartTitle)this.GetProperty("Footer");
            }
            set
            {
                this.SetProperty("Footer", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if An object value that indicates the footer of the chart element. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Footer property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeFooter()
        {
			return this.ShouldSerialize("Footer");
        }
        
        
        /// <summary>
		/// Resets the An object value that indicates the footer of the chart element. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Footer property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetFooter()
        {
			this.Reset("Footer");
        }
        
		
		/// <summary>
		/// An object value indicates the legend of the chart element.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("An object value indicates the legend of the chart element.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public C1.Web.Wijmo.Controls.C1Chart.ChartLegend Legend
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1Chart.ChartLegend)this.GetProperty("Legend");
            }
            set
            {
                this.SetProperty("Legend", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if An object value indicates the legend of the chart element. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Legend property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeLegend()
        {
			return this.ShouldSerialize("Legend");
        }
        
        
        /// <summary>
		/// Resets the An object value indicates the legend of the chart element. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Legend property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetLegend()
        {
			this.Reset("Legend");
        }
        
		
		/// <summary>
		/// A value that provides information about the axes.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("A value that provides information about the axes.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public C1.Web.Wijmo.Controls.C1Chart.ChartAxes Axis
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1Chart.ChartAxes)this.GetProperty("Axis");
            }
            set
            {
                this.SetProperty("Axis", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that provides information about the axes. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Axis property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAxis()
        {
			return this.ShouldSerialize("Axis");
        }
        
        
        /// <summary>
		/// Resets the A value that provides information about the axes. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Axis property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAxis()
        {
			this.Reset("Axis");
        }
        
		
		/// <summary>
		/// A value that is used to indicate whether to show and what to show on the open tooltip.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("A value that is used to indicate whether to show and what to show on the open tooltip.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public C1.Web.Wijmo.Controls.C1Chart.ChartHint Hint
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1Chart.ChartHint)this.GetProperty("Hint");
            }
            set
            {
                this.SetProperty("Hint", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that is used to indicate whether to show and what to show on the open tooltip. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Hint property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHint()
        {
			return this.ShouldSerialize("Hint");
        }
        
        
        /// <summary>
		/// Resets the A value that is used to indicate whether to show and what to show on the open tooltip. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Hint property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHint()
        {
			this.Reset("Hint");
        }
        
		
		/// <summary>
		/// A value that indicates whether to show default chart labels.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("A value that indicates whether to show default chart labels.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowChartLabels
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowChartLabels");
            }
            set
            {
                this.SetProperty("ShowChartLabels", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates whether to show default chart labels. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowChartLabels property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowChartLabels()
        {
			return this.ShouldSerialize("ShowChartLabels");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates whether to show default chart labels. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowChartLabels property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowChartLabels()
        {
			this.Reset("ShowChartLabels");
        }
        
		
		/// <summary>
		/// A value that indicates style of the chart labels.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Style")]
        [System.ComponentModel.Description("A value that indicates style of the chart labels.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public C1.Web.Wijmo.Controls.C1Chart.ChartStyle ChartLabelStyle
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1Chart.ChartStyle)this.GetProperty("ChartLabelStyle");
            }
            set
            {
                this.SetProperty("ChartLabelStyle", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates style of the chart labels. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ChartLabelStyle property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeChartLabelStyle()
        {
			return this.ShouldSerialize("ChartLabelStyle");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates style of the chart labels. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ChartLabelStyle property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetChartLabelStyle()
        {
			this.Reset("ChartLabelStyle");
        }
        
		
		/// <summary>
		/// A value that indicates the format string of the chart labels.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("A value that indicates the format string of the chart labels.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String ChartLabelFormatString
        {
            get
            {
                return (System.String)this.GetProperty("ChartLabelFormatString");
            }
            set
            {
                this.SetProperty("ChartLabelFormatString", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates the format string of the chart labels. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ChartLabelFormatString property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeChartLabelFormatString()
        {
			return this.ShouldSerialize("ChartLabelFormatString");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates the format string of the chart labels. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ChartLabelFormatString property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetChartLabelFormatString()
        {
			this.Reset("ChartLabelFormatString");
        }
        
		
		/// <summary>
		/// A value that indicates whether to disable the default text style.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Style")]
        [System.ComponentModel.Description("A value that indicates whether to disable the default text style.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean DisableDefaultTextStyle
        {
            get
            {
                return (System.Boolean)this.GetProperty("DisableDefaultTextStyle");
            }
            set
            {
                this.SetProperty("DisableDefaultTextStyle", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates whether to disable the default text style. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the DisableDefaultTextStyle property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeDisableDefaultTextStyle()
        {
			return this.ShouldSerialize("DisableDefaultTextStyle");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates whether to disable the default text style. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the DisableDefaultTextStyle property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetDisableDefaultTextStyle()
        {
			this.Reset("DisableDefaultTextStyle");
        }
        
		
		/// <summary>
		/// A value that indicates whether to show shadow for the chart.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("A value that indicates whether to show shadow for the chart.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean Shadow
        {
            get
            {
                return (System.Boolean)this.GetProperty("Shadow");
            }
            set
            {
                this.SetProperty("Shadow", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value that indicates whether to show shadow for the chart. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Shadow property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShadow()
        {
			return this.ShouldSerialize("Shadow");
        }
        
        
        /// <summary>
		/// Resets the A value that indicates whether to show shadow for the chart. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Shadow property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShadow()
        {
			this.Reset("Shadow");
        }
        
		
		/// <summary>
		/// Occurs when the user clicks a mouse button.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs when the user clicks a mouse button.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientMouseDown
        {
            get
            {
                return (System.String)this.GetProperty("OnClientMouseDown");
            }
            set
            {
                this.SetProperty("OnClientMouseDown", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs when the user clicks a mouse button. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientMouseDown property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientMouseDown()
        {
			return this.ShouldSerialize("OnClientMouseDown");
        }
        
        
        /// <summary>
		/// Resets the Occurs when the user clicks a mouse button. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientMouseDown property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientMouseDown()
        {
			this.Reset("OnClientMouseDown");
        }
        
		
		/// <summary>
		/// Occurs when the user releases a mouse button while the pointer is over the chart element.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs when the user releases a mouse button while the pointer is over the chart element.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientMouseUp
        {
            get
            {
                return (System.String)this.GetProperty("OnClientMouseUp");
            }
            set
            {
                this.SetProperty("OnClientMouseUp", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs when the user releases a mouse button while the pointer is over the chart element. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientMouseUp property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientMouseUp()
        {
			return this.ShouldSerialize("OnClientMouseUp");
        }
        
        
        /// <summary>
		/// Resets the Occurs when the user releases a mouse button while the pointer is over the chart element. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientMouseUp property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientMouseUp()
        {
			this.Reset("OnClientMouseUp");
        }
        
		
		/// <summary>
		/// Occurs when the user first places the pointer over the chart element.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs when the user first places the pointer over the chart element.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientMouseOver
        {
            get
            {
                return (System.String)this.GetProperty("OnClientMouseOver");
            }
            set
            {
                this.SetProperty("OnClientMouseOver", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs when the user first places the pointer over the chart element. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientMouseOver property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientMouseOver()
        {
			return this.ShouldSerialize("OnClientMouseOver");
        }
        
        
        /// <summary>
		/// Resets the Occurs when the user first places the pointer over the chart element. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientMouseOver property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientMouseOver()
        {
			this.Reset("OnClientMouseOver");
        }
        
		
		/// <summary>
		/// Occurs when the user moves the pointer off of the chart element.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs when the user moves the pointer off of the chart element.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientMouseOut
        {
            get
            {
                return (System.String)this.GetProperty("OnClientMouseOut");
            }
            set
            {
                this.SetProperty("OnClientMouseOut", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs when the user moves the pointer off of the chart element. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientMouseOut property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientMouseOut()
        {
			return this.ShouldSerialize("OnClientMouseOut");
        }
        
        
        /// <summary>
		/// Resets the Occurs when the user moves the pointer off of the chart element. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientMouseOut property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientMouseOut()
        {
			this.Reset("OnClientMouseOut");
        }
        
		
		/// <summary>
		/// Occurs when the user moves the mouse pointer while it is over a chart element.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs when the user moves the mouse pointer while it is over a chart element.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientMouseMove
        {
            get
            {
                return (System.String)this.GetProperty("OnClientMouseMove");
            }
            set
            {
                this.SetProperty("OnClientMouseMove", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs when the user moves the mouse pointer while it is over a chart element. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientMouseMove property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientMouseMove()
        {
			return this.ShouldSerialize("OnClientMouseMove");
        }
        
        
        /// <summary>
		/// Resets the Occurs when the user moves the mouse pointer while it is over a chart element. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientMouseMove property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientMouseMove()
        {
			this.Reset("OnClientMouseMove");
        }
        
		
		/// <summary>
		/// Occurs when the user clicks the chart element.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs when the user clicks the chart element.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientClick
        {
            get
            {
                return (System.String)this.GetProperty("OnClientClick");
            }
            set
            {
                this.SetProperty("OnClientClick", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs when the user clicks the chart element. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientClick property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientClick()
        {
			return this.ShouldSerialize("OnClientClick");
        }
        
        
        /// <summary>
		/// Resets the Occurs when the user clicks the chart element. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientClick property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientClick()
        {
			this.Reset("OnClientClick");
        }
        
		
		/// <summary>
		/// Occurs before the series changes.  This event can be cancelled.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs before the series changes.  This event can be cancelled.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientBeforeSeriesChange
        {
            get
            {
                return (System.String)this.GetProperty("OnClientBeforeSeriesChange");
            }
            set
            {
                this.SetProperty("OnClientBeforeSeriesChange", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs before the series changes.  This event can be cancelled. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeSeriesChange property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientBeforeSeriesChange()
        {
			return this.ShouldSerialize("OnClientBeforeSeriesChange");
        }
        
        
        /// <summary>
		/// Resets the Occurs before the series changes.  This event can be cancelled. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientBeforeSeriesChange property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientBeforeSeriesChange()
        {
			this.Reset("OnClientBeforeSeriesChange");
        }
        
		
		/// <summary>
		/// Occurs when the series changes.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs when the series changes.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientSeriesChanged
        {
            get
            {
                return (System.String)this.GetProperty("OnClientSeriesChanged");
            }
            set
            {
                this.SetProperty("OnClientSeriesChanged", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs when the series changes. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientSeriesChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientSeriesChanged()
        {
			return this.ShouldSerialize("OnClientSeriesChanged");
        }
        
        
        /// <summary>
		/// Resets the Occurs when the series changes. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientSeriesChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientSeriesChanged()
        {
			this.Reset("OnClientSeriesChanged");
        }
        
		
		/// <summary>
		/// Occurs before the canvas is painted.  This event can be cancelled.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs before the canvas is painted.  This event can be cancelled.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientBeforePaint
        {
            get
            {
                return (System.String)this.GetProperty("OnClientBeforePaint");
            }
            set
            {
                this.SetProperty("OnClientBeforePaint", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs before the canvas is painted.  This event can be cancelled. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientBeforePaint property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientBeforePaint()
        {
			return this.ShouldSerialize("OnClientBeforePaint");
        }
        
        
        /// <summary>
		/// Resets the Occurs before the canvas is painted.  This event can be cancelled. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientBeforePaint property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientBeforePaint()
        {
			this.Reset("OnClientBeforePaint");
        }
        
		
		/// <summary>
		/// Occurs after the canvas is painted.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs after the canvas is painted.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientPainted
        {
            get
            {
                return (System.String)this.GetProperty("OnClientPainted");
            }
            set
            {
                this.SetProperty("OnClientPainted", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs after the canvas is painted. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientPainted property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientPainted()
        {
			return this.ShouldSerialize("OnClientPainted");
        }
        
        
        /// <summary>
		/// Resets the Occurs after the canvas is painted. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientPainted property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientPainted()
        {
			this.Reset("OnClientPainted");
        }
        
		
		/// <summary>
		/// Name of the theme that will be used to style widgets. Available themes: aristo / midnight / ui-lightness. Note, only one theme can be used for the whole page at one time. Please, make sure that all widget extenders have the same Theme value.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Name of the theme that will be used to style widgets. Available themes: aristo / midnight / ui-lightness. Note, only one theme can be used for the whole page at one time. Please, make sure that all widget extenders have the same Theme value.")]
        [System.ComponentModel.Browsable(false)]    
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
		/// The width of the control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("The width of the control.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Web.UI.WebControls.Unit HostedWidth
        {
            get
            {
                return (System.Web.UI.WebControls.Unit)this.GetProperty("Width");
            }
            set
            {
                this.SetProperty("Width", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The width of the control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Width property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHostedWidth()
        {
			return this.ShouldSerialize("Width");
        }
        
        
        /// <summary>
		/// Resets the The width of the control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Width property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHostedWidth()
        {
			this.Reset("Width");
        }
        
		
		/// <summary>
		/// The height of the control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("The height of the control.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Web.UI.WebControls.Unit HostedHeight
        {
            get
            {
                return (System.Web.UI.WebControls.Unit)this.GetProperty("Height");
            }
            set
            {
                this.SetProperty("Height", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The height of the control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Height property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHostedHeight()
        {
			return this.ShouldSerialize("Height");
        }
        
        
        /// <summary>
		/// Resets the The height of the control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Height property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHostedHeight()
        {
			this.Reset("Height");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]   
        public System.Collections.Hashtable InnerStates
        {
            get
            {
                return (System.Collections.Hashtable)this.GetProperty("InnerStates");
            }
        }
        
		
		/// <summary>
		/// The table or view used for binding against.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Data")]
        [System.ComponentModel.Description("The table or view used for binding against.")]
        [System.ComponentModel.Browsable(false)]    
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
		/// Gets a collection of C1ChartBinding objects that define the relationship between a data item and the chart series it is binding to.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Data")]
        [System.ComponentModel.Description("Gets a collection of C1ChartBinding objects that define the relationship between a data item and the chart series it is binding to.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public System.Collections.Generic.List<C1.Web.Wijmo.Controls.C1Chart.C1ChartBinding> HostedDataBindings
        {
            get
            {
                return (System.Collections.Generic.List<C1.Web.Wijmo.Controls.C1Chart.C1ChartBinding>)this.GetProperty("DataBindings");
            }
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
		/// Enabled state of the control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Enabled state of the control.")]
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
		/// Returns a boolean indicating if Enabled state of the control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Enabled property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHostedEnabled()
        {
			return this.ShouldSerialize("Enabled");
        }
        
        
        /// <summary>
		/// Resets the Enabled state of the control. property to its default value.
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
