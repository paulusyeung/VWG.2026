namespace ComponentOneSampleAppsCS
{
	partial class C1EventsCalendarWrapper
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
                return typeof(C1.Web.Wijmo.Controls.C1EventsCalendar.C1EventsCalendar);
            }
        }
        
        /// <summary>
        /// Get hosted control typed instance
        /// </summary>
        protected C1.Web.Wijmo.Controls.C1EventsCalendar.C1EventsCalendar HostedC1EventsCalendar
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1EventsCalendar.C1EventsCalendar)this.HostedControl;
            }
        }
        
        		
		/// <summary>
		/// The URL to the web service which will be used to store information about events.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("The URL to the web service which will be used to store information about events.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String WebServiceUrl
        {
            get
            {
                return (System.String)this.GetProperty("WebServiceUrl");
            }
            set
            {
                this.SetProperty("WebServiceUrl", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The URL to the web service which will be used to store information about events. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the WebServiceUrl property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeWebServiceUrl()
        {
			return this.ShouldSerialize("WebServiceUrl");
        }
        
        
        /// <summary>
		/// Resets the The URL to the web service which will be used to store information about events. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the WebServiceUrl property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetWebServiceUrl()
        {
			this.Reset("WebServiceUrl");
        }
        
		
		/// <summary>
		/// The Colors property specifies the list of color name which will be shown in the color name drop down list in the event dialog.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The Colors property specifies the list of color name which will be shown in the color name drop down list in the event dialog.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String[] Colors
        {
            get
            {
                return (System.String[])this.GetProperty("Colors");
            }
            set
            {
                this.SetProperty("Colors", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The Colors property specifies the list of color name which will be shown in the color name drop down list in the event dialog. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Colors property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeColors()
        {
			return this.ShouldSerialize("Colors");
        }
        
        
        /// <summary>
		/// Resets the The Colors property specifies the list of color name which will be shown in the color name drop down list in the event dialog. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Colors property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetColors()
        {
			this.Reset("Colors");
        }
        
		
		/// <summary>
		/// Enables built-in log console.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Enables built-in log console.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean EnableLogs
        {
            get
            {
                return (System.Boolean)this.GetProperty("EnableLogs");
            }
            set
            {
                this.SetProperty("EnableLogs", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Enables built-in log console. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the EnableLogs property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeEnableLogs()
        {
			return this.ShouldSerialize("EnableLogs");
        }
        
        
        /// <summary>
		/// Resets the Enables built-in log console. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the EnableLogs property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetEnableLogs()
        {
			this.Reset("EnableLogs");
        }
        
		
		/// <summary>
		/// Indicates whether the header bar will be visible.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Indicates whether the header bar will be visible.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean HeaderBarVisible
        {
            get
            {
                return (System.Boolean)this.GetProperty("HeaderBarVisible");
            }
            set
            {
                this.SetProperty("HeaderBarVisible", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Indicates whether the header bar will be visible. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the HeaderBarVisible property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHeaderBarVisible()
        {
			return this.ShouldSerialize("HeaderBarVisible");
        }
        
        
        /// <summary>
		/// Resets the Indicates whether the header bar will be visible. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the HeaderBarVisible property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHeaderBarVisible()
        {
			this.Reset("HeaderBarVisible");
        }
        
		
		/// <summary>
		/// Indicates whether the bottom navigation bar will be visible.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Indicates whether the bottom navigation bar will be visible.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean NavigationBarVisible
        {
            get
            {
                return (System.Boolean)this.GetProperty("NavigationBarVisible");
            }
            set
            {
                this.SetProperty("NavigationBarVisible", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Indicates whether the bottom navigation bar will be visible. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the NavigationBarVisible property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeNavigationBarVisible()
        {
			return this.ShouldSerialize("NavigationBarVisible");
        }
        
        
        /// <summary>
		/// Resets the Indicates whether the bottom navigation bar will be visible. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the NavigationBarVisible property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetNavigationBarVisible()
        {
			this.Reset("NavigationBarVisible");
        }
        
		
		/// <summary>
		/// The selected date.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("The selected date.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.DateTime SelectedDate
        {
            get
            {
                return (System.DateTime)this.GetProperty("SelectedDate");
            }
            set
            {
                this.SetProperty("SelectedDate", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The selected date. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the SelectedDate property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeSelectedDate()
        {
			return this.ShouldSerialize("SelectedDate");
        }
        
        
        /// <summary>
		/// Resets the The selected date. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the SelectedDate property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetSelectedDate()
        {
			this.Reset("SelectedDate");
        }
        
		
		/// <summary>
		/// Collection of DateTime objects that represent the selected dates on the C1EventsCalendar control for the DayView.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Collection of DateTime objects that represent the selected dates on the C1EventsCalendar control for the DayView.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public System.Web.UI.WebControls.SelectedDatesCollection SelectedDates
        {
            get
            {
                return (System.Web.UI.WebControls.SelectedDatesCollection)this.GetProperty("SelectedDates");
            }
        }
        
		
		/// <summary>
		/// Format of the title text for the event. Format arguments: {0} = Start, {1} = End, {2} = Subject, {3} = Location, {4} = Icons.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Format of the title text for the event. Format arguments: {0} = Start, {1} = End, {2} = Subject, {3} = Location, {4} = Icons.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String EventTitleFormat
        {
            get
            {
                return (System.String)this.GetProperty("EventTitleFormat");
            }
            set
            {
                this.SetProperty("EventTitleFormat", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Format of the title text for the event. Format arguments: {0} = Start, {1} = End, {2} = Subject, {3} = Location, {4} = Icons. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the EventTitleFormat property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeEventTitleFormat()
        {
			return this.ShouldSerialize("EventTitleFormat");
        }
        
        
        /// <summary>
		/// Resets the Format of the title text for the event. Format arguments: {0} = Start, {1} = End, {2} = Subject, {3} = Location, {4} = Icons. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the EventTitleFormat property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetEventTitleFormat()
        {
			this.Reset("EventTitleFormat");
        }
        
		
		/// <summary>
		/// First day of the week. This property is read-only. Use Culture property in order to change the first day of the week.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("First day of the week. This property is read-only. Use Culture property in order to change the first day of the week.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public System.Int32 FirstDayOfWeek
        {
            get
            {
                return (System.Int32)this.GetProperty("FirstDayOfWeek");
            }
        }
        
		
		/// <summary>
		/// CultureInfo object what currently used by control. This property is read-only. Use Culture property in order to change active culture.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("CultureInfo object what currently used by control. This property is read-only. Use Culture property in order to change active culture.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public System.Globalization.CultureInfo UsedCulture
        {
            get
            {
                return (System.Globalization.CultureInfo)this.GetProperty("UsedCulture");
            }
        }
        
		
		/// <summary>
		/// CultureInfo object. Each culture has different conventions for displaying dates, time, numbers, and other information. Neutrals cultures are not supported.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("CultureInfo object. Each culture has different conventions for displaying dates, time, numbers, and other information. Neutrals cultures are not supported.")]
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
		/// Returns a boolean indicating if CultureInfo object. Each culture has different conventions for displaying dates, time, numbers, and other information. Neutrals cultures are not supported. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Culture property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeCulture()
        {
			return this.ShouldSerialize("Culture");
        }
        
        
        /// <summary>
		/// Resets the CultureInfo object. Each culture has different conventions for displaying dates, time, numbers, and other information. Neutrals cultures are not supported. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Culture property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetCulture()
        {
			this.Reset("Culture");
        }
        
		
		/// <summary>
		/// Time interval for the Day view (in minutes).
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Time interval for the Day view (in minutes).")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 TimeInterval
        {
            get
            {
                return (System.Int32)this.GetProperty("TimeInterval");
            }
            set
            {
                this.SetProperty("TimeInterval", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Time interval for the Day view (in minutes). should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the TimeInterval property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeTimeInterval()
        {
			return this.ShouldSerialize("TimeInterval");
        }
        
        
        /// <summary>
		/// Resets the Time interval for the Day view (in minutes). property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the TimeInterval property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetTimeInterval()
        {
			this.Reset("TimeInterval");
        }
        
		
		/// <summary>
		/// The Day view time interval row height in pixels.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The Day view time interval row height in pixels.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 TimeIntervalHeight
        {
            get
            {
                return (System.Int32)this.GetProperty("TimeIntervalHeight");
            }
            set
            {
                this.SetProperty("TimeIntervalHeight", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The Day view time interval row height in pixels. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the TimeIntervalHeight property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeTimeIntervalHeight()
        {
			return this.ShouldSerialize("TimeIntervalHeight");
        }
        
        
        /// <summary>
		/// Resets the The Day view time interval row height in pixels. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the TimeIntervalHeight property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetTimeIntervalHeight()
        {
			this.Reset("TimeIntervalHeight");
        }
        
		
		/// <summary>
		/// Time ruler interval for the Day view (in minutes).
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Time ruler interval for the Day view (in minutes).")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 TimeRulerInterval
        {
            get
            {
                return (System.Int32)this.GetProperty("TimeRulerInterval");
            }
            set
            {
                this.SetProperty("TimeRulerInterval", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Time ruler interval for the Day view (in minutes). should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the TimeRulerInterval property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeTimeRulerInterval()
        {
			return this.ShouldSerialize("TimeRulerInterval");
        }
        
        
        /// <summary>
		/// Resets the Time ruler interval for the Day view (in minutes). property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the TimeRulerInterval property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetTimeRulerInterval()
        {
			this.Reset("TimeRulerInterval");
        }
        
		
		/// <summary>
		/// Time ruler format for the Day view. Format argument: {0} = Current ruler time.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Time ruler format for the Day view. Format argument: {0} = Current ruler time.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String TimeRulerFormat
        {
            get
            {
                return (System.String)this.GetProperty("TimeRulerFormat");
            }
            set
            {
                this.SetProperty("TimeRulerFormat", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Time ruler format for the Day view. Format argument: {0} = Current ruler time. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the TimeRulerFormat property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeTimeRulerFormat()
        {
			return this.ShouldSerialize("TimeRulerFormat");
        }
        
        
        /// <summary>
		/// Resets the Time ruler format for the Day view. Format argument: {0} = Current ruler time. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the TimeRulerFormat property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetTimeRulerFormat()
        {
			this.Reset("TimeRulerFormat");
        }
        
		
		/// <summary>
		/// Format of the text for the day cell header in the month view. Format argument: {0} = Day date.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Format of the text for the day cell header in the month view. Format argument: {0} = Day date.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String DayHeaderFormat
        {
            get
            {
                return (System.String)this.GetProperty("DayHeaderFormat");
            }
            set
            {
                this.SetProperty("DayHeaderFormat", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Format of the text for the day cell header in the month view. Format argument: {0} = Day date. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the DayHeaderFormat property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeDayHeaderFormat()
        {
			return this.ShouldSerialize("DayHeaderFormat");
        }
        
        
        /// <summary>
		/// Resets the Format of the text for the day cell header in the month view. Format argument: {0} = Day date. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the DayHeaderFormat property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetDayHeaderFormat()
        {
			this.Reset("DayHeaderFormat");
        }
        
		
		/// <summary>
		/// Format of the text for the first cell header in the first row of the month view. Format argument: {0} = Day date.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Format of the text for the first cell header in the first row of the month view. Format argument: {0} = Day date.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String FirstRowDayHeaderFormat
        {
            get
            {
                return (System.String)this.GetProperty("FirstRowDayHeaderFormat");
            }
            set
            {
                this.SetProperty("FirstRowDayHeaderFormat", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Format of the text for the first cell header in the first row of the month view. Format argument: {0} = Day date. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the FirstRowDayHeaderFormat property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeFirstRowDayHeaderFormat()
        {
			return this.ShouldSerialize("FirstRowDayHeaderFormat");
        }
        
        
        /// <summary>
		/// Resets the Format of the text for the first cell header in the first row of the month view. Format argument: {0} = Day date. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the FirstRowDayHeaderFormat property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetFirstRowDayHeaderFormat()
        {
			this.Reset("FirstRowDayHeaderFormat");
        }
        
		
		/// <summary>
		/// Array of the calendar names which need to be shown.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Array of the calendar names which need to be shown.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String[] VisibleCalendars
        {
            get
            {
                return (System.String[])this.GetProperty("VisibleCalendars");
            }
            set
            {
                this.SetProperty("VisibleCalendars", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Array of the calendar names which need to be shown. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the VisibleCalendars property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeVisibleCalendars()
        {
			return this.ShouldSerialize("VisibleCalendars");
        }
        
        
        /// <summary>
		/// Resets the Array of the calendar names which need to be shown. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the VisibleCalendars property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetVisibleCalendars()
        {
			this.Reset("VisibleCalendars");
        }
        
		
		/// <summary>
		/// The active view type. Possible values are: day, week, month, list.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The active view type. Possible values are: day, week, month, list.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public C1.Web.Wijmo.Controls.C1EventsCalendar.C1EventsCalendarViewType ViewType
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1EventsCalendar.C1EventsCalendarViewType)this.GetProperty("ViewType");
            }
            set
            {
                this.SetProperty("ViewType", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The active view type. Possible values are: day, week, month, list. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ViewType property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeViewType()
        {
			return this.ShouldSerialize("ViewType");
        }
        
        
        /// <summary>
		/// Resets the The active view type. Possible values are: day, week, month, list. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ViewType property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetViewType()
        {
			this.Reset("ViewType");
        }
        
		
		/// <summary>
		/// Format of the text for the day header in the day/week or list view. Format argument: {0} = Day date.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Format of the text for the day header in the day/week or list view. Format argument: {0} = Day date.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public C1.Web.Wijmo.Controls.C1EventsCalendar.DayViewHeaderFormatOption DayViewHeaderFormat
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1EventsCalendar.DayViewHeaderFormatOption)this.GetProperty("DayViewHeaderFormat");
            }
        }
        
		
		/// <summary>
		/// Use the Localization property in order to customize localization strings.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Use the Localization property in order to customize localization strings.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public C1.Web.Wijmo.Controls.C1EventsCalendar.LocalizationOption Localization
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1EventsCalendar.LocalizationOption)this.GetProperty("Localization");
            }
        }
        
		
		/// <summary>
		/// Use the Localization property in order to customize localization strings.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Use the Localization property in order to customize localization strings.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public C1.Web.Wijmo.Controls.C1EventsCalendar.DatePagerLocalizationOption DatePagerLocalization
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1EventsCalendar.DatePagerLocalizationOption)this.GetProperty("DatePagerLocalization");
            }
        }
        
		
		/// <summary>
		/// Occurs before the built-in event dialog is shown. Return false or call event.preventDefault() in order to cancel event and prevent the built-in dialog to be shown. args.data - the event data. args.targetCell - target offset DOM element which can be used for popup callout.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs before the built-in event dialog is shown. Return false or call event.preventDefault() in order to cancel event and prevent the built-in dialog to be shown. args.data - the event data. args.targetCell - target offset DOM element which can be used for popup callout.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientBeforeEditEventDialogShow
        {
            get
            {
                return (System.String)this.GetProperty("OnClientBeforeEditEventDialogShow");
            }
            set
            {
                this.SetProperty("OnClientBeforeEditEventDialogShow", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs before the built-in event dialog is shown. Return false or call event.preventDefault() in order to cancel event and prevent the built-in dialog to be shown. args.data - the event data. args.targetCell - target offset DOM element which can be used for popup callout. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeEditEventDialogShow property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientBeforeEditEventDialogShow()
        {
			return this.ShouldSerialize("OnClientBeforeEditEventDialogShow");
        }
        
        
        /// <summary>
		/// Resets the Occurs before the built-in event dialog is shown. Return false or call event.preventDefault() in order to cancel event and prevent the built-in dialog to be shown. args.data - the event data. args.targetCell - target offset DOM element which can be used for popup callout. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientBeforeEditEventDialogShow property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientBeforeEditEventDialogShow()
        {
			this.Reset("OnClientBeforeEditEventDialogShow");
        }
        
		
		/// <summary>
		/// Occurs when calendars option has been changed. args.calendars - the new calendars option value.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs when calendars option has been changed. args.calendars - the new calendars option value.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientCalendarsChanged
        {
            get
            {
                return (System.String)this.GetProperty("OnClientCalendarsChanged");
            }
            set
            {
                this.SetProperty("OnClientCalendarsChanged", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs when calendars option has been changed. args.calendars - the new calendars option value. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientCalendarsChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientCalendarsChanged()
        {
			return this.ShouldSerialize("OnClientCalendarsChanged");
        }
        
        
        /// <summary>
		/// Resets the Occurs when calendars option has been changed. args.calendars - the new calendars option value. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientCalendarsChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientCalendarsChanged()
        {
			this.Reset("OnClientCalendarsChanged");
        }
        
		
		/// <summary>
		/// Occurs when events calendar is constructed and events data is loaded from an external or local data source.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs when events calendar is constructed and events data is loaded from an external or local data source.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientInitialized
        {
            get
            {
                return (System.String)this.GetProperty("OnClientInitialized");
            }
            set
            {
                this.SetProperty("OnClientInitialized", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs when events calendar is constructed and events data is loaded from an external or local data source. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientInitialized property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientInitialized()
        {
			return this.ShouldSerialize("OnClientInitialized");
        }
        
        
        /// <summary>
		/// Resets the Occurs when events calendar is constructed and events data is loaded from an external or local data source. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientInitialized property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientInitialized()
        {
			this.Reset("OnClientInitialized");
        }
        
		
		/// <summary>
		/// Occurs when selectedDates option has been changed. args.selectedDates - the new selectedDates value.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs when selectedDates option has been changed. args.selectedDates - the new selectedDates value.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientSelectedDatesChanged
        {
            get
            {
                return (System.String)this.GetProperty("OnClientSelectedDatesChanged");
            }
            set
            {
                this.SetProperty("OnClientSelectedDatesChanged", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs when selectedDates option has been changed. args.selectedDates - the new selectedDates value. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientSelectedDatesChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientSelectedDatesChanged()
        {
			return this.ShouldSerialize("OnClientSelectedDatesChanged");
        }
        
        
        /// <summary>
		/// Resets the Occurs when selectedDates option has been changed. args.selectedDates - the new selectedDates value. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientSelectedDatesChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientSelectedDatesChanged()
        {
			this.Reset("OnClientSelectedDatesChanged");
        }
        
		
		/// <summary>
		/// Occurs when viewType option has been changed.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs when viewType option has been changed.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientViewTypeChanged
        {
            get
            {
                return (System.String)this.GetProperty("OnClientViewTypeChanged");
            }
            set
            {
                this.SetProperty("OnClientViewTypeChanged", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs when viewType option has been changed. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientViewTypeChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientViewTypeChanged()
        {
			return this.ShouldSerialize("OnClientViewTypeChanged");
        }
        
        
        /// <summary>
		/// Resets the Occurs when viewType option has been changed. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientViewTypeChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientViewTypeChanged()
        {
			this.Reset("OnClientViewTypeChanged");
        }
        
		
		/// <summary>
		/// Occurs before the add event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be added to a data source.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs before the add event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be added to a data source.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientBeforeAddEvent
        {
            get
            {
                return (System.String)this.GetProperty("OnClientBeforeAddEvent");
            }
            set
            {
                this.SetProperty("OnClientBeforeAddEvent", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs before the add event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be added to a data source. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeAddEvent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientBeforeAddEvent()
        {
			return this.ShouldSerialize("OnClientBeforeAddEvent");
        }
        
        
        /// <summary>
		/// Resets the Occurs before the add event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be added to a data source. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientBeforeAddEvent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientBeforeAddEvent()
        {
			this.Reset("OnClientBeforeAddEvent");
        }
        
		
		/// <summary>
		/// Occurs before the save event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be updated. args.prevData - previous event data, this argument is empty for a new event.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs before the save event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be updated. args.prevData - previous event data, this argument is empty for a new event.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientBeforeUpdateEvent
        {
            get
            {
                return (System.String)this.GetProperty("OnClientBeforeUpdateEvent");
            }
            set
            {
                this.SetProperty("OnClientBeforeUpdateEvent", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs before the save event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be updated. args.prevData - previous event data, this argument is empty for a new event. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeUpdateEvent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientBeforeUpdateEvent()
        {
			return this.ShouldSerialize("OnClientBeforeUpdateEvent");
        }
        
        
        /// <summary>
		/// Resets the Occurs before the save event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be updated. args.prevData - previous event data, this argument is empty for a new event. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientBeforeUpdateEvent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientBeforeUpdateEvent()
        {
			this.Reset("OnClientBeforeUpdateEvent");
        }
        
		
		/// <summary>
		/// Occurs before the delete action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the new event data that should be saved to a data source. args.data - the event object that should be deleted.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs before the delete action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the new event data that should be saved to a data source. args.data - the event object that should be deleted.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientBeforeDeleteEvent
        {
            get
            {
                return (System.String)this.GetProperty("OnClientBeforeDeleteEvent");
            }
            set
            {
                this.SetProperty("OnClientBeforeDeleteEvent", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs before the delete action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the new event data that should be saved to a data source. args.data - the event object that should be deleted. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeDeleteEvent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientBeforeDeleteEvent()
        {
			return this.ShouldSerialize("OnClientBeforeDeleteEvent");
        }
        
        
        /// <summary>
		/// Resets the Occurs before the delete action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the new event data that should be saved to a data source. args.data - the event object that should be deleted. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientBeforeDeleteEvent property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientBeforeDeleteEvent()
        {
			this.Reset("OnClientBeforeDeleteEvent");
        }
        
		
		/// <summary>
		/// Occurs before the save calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new calendar data that should be saved to a data source. args.prevData - previous calendar data, this argument is empty for a new calendar.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs before the save calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new calendar data that should be saved to a data source. args.prevData - previous calendar data, this argument is empty for a new calendar.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientBeforeSaveCalendar
        {
            get
            {
                return (System.String)this.GetProperty("OnClientBeforeSaveCalendar");
            }
            set
            {
                this.SetProperty("OnClientBeforeSaveCalendar", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs before the save calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new calendar data that should be saved to a data source. args.prevData - previous calendar data, this argument is empty for a new calendar. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeSaveCalendar property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientBeforeSaveCalendar()
        {
			return this.ShouldSerialize("OnClientBeforeSaveCalendar");
        }
        
        
        /// <summary>
		/// Resets the Occurs before the save calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new calendar data that should be saved to a data source. args.prevData - previous calendar data, this argument is empty for a new calendar. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientBeforeSaveCalendar property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientBeforeSaveCalendar()
        {
			this.Reset("OnClientBeforeSaveCalendar");
        }
        
		
		/// <summary>
		/// Occurs before the delete calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the calendar data that should be deleted from a data source.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client-Side Events")]
        [System.ComponentModel.Description("Occurs before the delete calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the calendar data that should be deleted from a data source.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientBeforeDeleteCalendar
        {
            get
            {
                return (System.String)this.GetProperty("OnClientBeforeDeleteCalendar");
            }
            set
            {
                this.SetProperty("OnClientBeforeDeleteCalendar", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Occurs before the delete calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the calendar data that should be deleted from a data source. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeDeleteCalendar property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientBeforeDeleteCalendar()
        {
			return this.ShouldSerialize("OnClientBeforeDeleteCalendar");
        }
        
        
        /// <summary>
		/// Resets the Occurs before the delete calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the calendar data that should be deleted from a data source. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientBeforeDeleteCalendar property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientBeforeDeleteCalendar()
        {
			this.Reset("OnClientBeforeDeleteCalendar");
        }
        
		
		/// <summary>
		/// C1EventsCalendar storage configuration.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Data")]
        [System.ComponentModel.Description("C1EventsCalendar storage configuration.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]   
        public C1.Web.Wijmo.Controls.C1EventsCalendar.C1EventsCalendarStorage DataStorage
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1EventsCalendar.C1EventsCalendarStorage)this.GetProperty("DataStorage");
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
		
		
		
		#endregion
		
	}
}
