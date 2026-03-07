Namespace Gizmox.WebGUI.Forms.CompanionKit.ComponentOneSampleAppsVB
    Partial Class C1EventsCalendarWrapper

#Region "Fields"

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

#End Region

#Region "Visual WebGui Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
        End Sub

#End Region

#Region "Properties"

        ''' <summary>
        ''' Get the hosted control type
        ''' </summary>
        Protected Overrides ReadOnly Property HostedControlType() As System.Type
            Get
                Return GetType(C1.Web.Wijmo.Controls.C1EventsCalendar.C1EventsCalendar)
            End Get
        End Property

        ''' <summary>
        ''' Get hosted control typed instance
        ''' </summary>
        Protected ReadOnly Property HostedC1EventsCalendar As C1.Web.Wijmo.Controls.C1EventsCalendar.C1EventsCalendar
            Get
                Return CType(Me.HostedControl, C1.Web.Wijmo.Controls.C1EventsCalendar.C1EventsCalendar)
            End Get
        End Property


        ''' <summary>
        ''' The URL to the web service which will be used to store information about events.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("The URL to the web service which will be used to store information about events.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property WebServiceUrl() As System.String
            Get
                Return CType(Me.GetProperty("WebServiceUrl"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("WebServiceUrl", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The URL to the web service which will be used to store information about events. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the WebServiceUrl property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeWebServiceUrl() As Boolean
            Return Me.ShouldSerialize("WebServiceUrl")
        End Function


        ''' <summary>
        ''' Resets the The URL to the web service which will be used to store information about events. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the WebServiceUrl property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetWebServiceUrl()
            Me.Reset("WebServiceUrl")
        End Sub


        ''' <summary>
        ''' The Colors property specifies the list of color name which will be shown in the color name drop down list in the event dialog.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("The Colors property specifies the list of color name which will be shown in the color name drop down list in the event dialog.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property Colors() As System.String()
            Get
                Return CType(Me.GetProperty("Colors"), System.String())
            End Get
            Set(value As System.String())
                Me.SetProperty("Colors", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The Colors property specifies the list of color name which will be shown in the color name drop down list in the event dialog. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Colors property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeColors() As Boolean
            Return Me.ShouldSerialize("Colors")
        End Function


        ''' <summary>
        ''' Resets the The Colors property specifies the list of color name which will be shown in the color name drop down list in the event dialog. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Colors property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetColors()
            Me.Reset("Colors")
        End Sub


        ''' <summary>
        ''' Enables built-in log console.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Enables built-in log console.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property EnableLogs() As System.Boolean
            Get
                Return CType(Me.GetProperty("EnableLogs"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("EnableLogs", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Enables built-in log console. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the EnableLogs property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeEnableLogs() As Boolean
            Return Me.ShouldSerialize("EnableLogs")
        End Function


        ''' <summary>
        ''' Resets the Enables built-in log console. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the EnableLogs property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetEnableLogs()
            Me.Reset("EnableLogs")
        End Sub


        ''' <summary>
        ''' Indicates whether the header bar will be visible.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Indicates whether the header bar will be visible.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property HeaderBarVisible() As System.Boolean
            Get
                Return CType(Me.GetProperty("HeaderBarVisible"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("HeaderBarVisible", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Indicates whether the header bar will be visible. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the HeaderBarVisible property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHeaderBarVisible() As Boolean
            Return Me.ShouldSerialize("HeaderBarVisible")
        End Function


        ''' <summary>
        ''' Resets the Indicates whether the header bar will be visible. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the HeaderBarVisible property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetHeaderBarVisible()
            Me.Reset("HeaderBarVisible")
        End Sub


        ''' <summary>
        ''' Indicates whether the bottom navigation bar will be visible.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Indicates whether the bottom navigation bar will be visible.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property NavigationBarVisible() As System.Boolean
            Get
                Return CType(Me.GetProperty("NavigationBarVisible"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("NavigationBarVisible", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Indicates whether the bottom navigation bar will be visible. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the NavigationBarVisible property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeNavigationBarVisible() As Boolean
            Return Me.ShouldSerialize("NavigationBarVisible")
        End Function


        ''' <summary>
        ''' Resets the Indicates whether the bottom navigation bar will be visible. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the NavigationBarVisible property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetNavigationBarVisible()
            Me.Reset("NavigationBarVisible")
        End Sub


        ''' <summary>
        ''' The selected date.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("The selected date.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property SelectedDate() As System.DateTime
            Get
                Return CType(Me.GetProperty("SelectedDate"), System.DateTime)
            End Get
            Set(value As System.DateTime)
                Me.SetProperty("SelectedDate", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The selected date. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the SelectedDate property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeSelectedDate() As Boolean
            Return Me.ShouldSerialize("SelectedDate")
        End Function


        ''' <summary>
        ''' Resets the The selected date. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the SelectedDate property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetSelectedDate()
            Me.Reset("SelectedDate")
        End Sub


        ''' <summary>
        ''' Collection of DateTime objects that represent the selected dates on the C1EventsCalendar control for the DayView.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("Collection of DateTime objects that represent the selected dates on the C1EventsCalendar control for the DayView.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property SelectedDates As System.Web.UI.WebControls.SelectedDatesCollection
            Get
                Return CType(Me.GetProperty("SelectedDates"), System.Web.UI.WebControls.SelectedDatesCollection)
            End Get
        End Property


        ''' <summary>
        ''' Format of the title text for the event. Format arguments: {0} = Start, {1} = End, {2} = Subject, {3} = Location, {4} = Icons.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Format of the title text for the event. Format arguments: {0} = Start, {1} = End, {2} = Subject, {3} = Location, {4} = Icons.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property EventTitleFormat() As System.String
            Get
                Return CType(Me.GetProperty("EventTitleFormat"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("EventTitleFormat", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Format of the title text for the event. Format arguments: {0} = Start, {1} = End, {2} = Subject, {3} = Location, {4} = Icons. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the EventTitleFormat property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeEventTitleFormat() As Boolean
            Return Me.ShouldSerialize("EventTitleFormat")
        End Function


        ''' <summary>
        ''' Resets the Format of the title text for the event. Format arguments: {0} = Start, {1} = End, {2} = Subject, {3} = Location, {4} = Icons. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the EventTitleFormat property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetEventTitleFormat()
            Me.Reset("EventTitleFormat")
        End Sub


        ''' <summary>
        ''' First day of the week. This property is read-only. Use Culture property in order to change the first day of the week.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("First day of the week. This property is read-only. Use Culture property in order to change the first day of the week.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property FirstDayOfWeek As System.Int32
            Get
                Return CType(Me.GetProperty("FirstDayOfWeek"), System.Int32)
            End Get
        End Property


        ''' <summary>
        ''' CultureInfo object what currently used by control. This property is read-only. Use Culture property in order to change active culture.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("CultureInfo object what currently used by control. This property is read-only. Use Culture property in order to change active culture.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property UsedCulture As System.Globalization.CultureInfo
            Get
                Return CType(Me.GetProperty("UsedCulture"), System.Globalization.CultureInfo)
            End Get
        End Property


        ''' <summary>
        ''' CultureInfo object. Each culture has different conventions for displaying dates, time, numbers, and other information. Neutrals cultures are not supported.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("CultureInfo object. Each culture has different conventions for displaying dates, time, numbers, and other information. Neutrals cultures are not supported.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property Culture() As System.Globalization.CultureInfo
            Get
                Return CType(Me.GetProperty("Culture"), System.Globalization.CultureInfo)
            End Get
            Set(value As System.Globalization.CultureInfo)
                Me.SetProperty("Culture", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if CultureInfo object. Each culture has different conventions for displaying dates, time, numbers, and other information. Neutrals cultures are not supported. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Culture property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeCulture() As Boolean
            Return Me.ShouldSerialize("Culture")
        End Function


        ''' <summary>
        ''' Resets the CultureInfo object. Each culture has different conventions for displaying dates, time, numbers, and other information. Neutrals cultures are not supported. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Culture property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetCulture()
            Me.Reset("Culture")
        End Sub


        ''' <summary>
        ''' Time interval for the Day view (in minutes).
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Time interval for the Day view (in minutes).")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property TimeInterval() As System.Int32
            Get
                Return CType(Me.GetProperty("TimeInterval"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("TimeInterval", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Time interval for the Day view (in minutes). should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the TimeInterval property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeTimeInterval() As Boolean
            Return Me.ShouldSerialize("TimeInterval")
        End Function


        ''' <summary>
        ''' Resets the Time interval for the Day view (in minutes). property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the TimeInterval property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetTimeInterval()
            Me.Reset("TimeInterval")
        End Sub


        ''' <summary>
        ''' The Day view time interval row height in pixels.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("The Day view time interval row height in pixels.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property TimeIntervalHeight() As System.Int32
            Get
                Return CType(Me.GetProperty("TimeIntervalHeight"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("TimeIntervalHeight", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The Day view time interval row height in pixels. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the TimeIntervalHeight property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeTimeIntervalHeight() As Boolean
            Return Me.ShouldSerialize("TimeIntervalHeight")
        End Function


        ''' <summary>
        ''' Resets the The Day view time interval row height in pixels. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the TimeIntervalHeight property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetTimeIntervalHeight()
            Me.Reset("TimeIntervalHeight")
        End Sub


        ''' <summary>
        ''' Time ruler interval for the Day view (in minutes).
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Time ruler interval for the Day view (in minutes).")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property TimeRulerInterval() As System.Int32
            Get
                Return CType(Me.GetProperty("TimeRulerInterval"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("TimeRulerInterval", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Time ruler interval for the Day view (in minutes). should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the TimeRulerInterval property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeTimeRulerInterval() As Boolean
            Return Me.ShouldSerialize("TimeRulerInterval")
        End Function


        ''' <summary>
        ''' Resets the Time ruler interval for the Day view (in minutes). property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the TimeRulerInterval property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetTimeRulerInterval()
            Me.Reset("TimeRulerInterval")
        End Sub


        ''' <summary>
        ''' Time ruler format for the Day view. Format argument: {0} = Current ruler time.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Time ruler format for the Day view. Format argument: {0} = Current ruler time.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property TimeRulerFormat() As System.String
            Get
                Return CType(Me.GetProperty("TimeRulerFormat"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("TimeRulerFormat", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Time ruler format for the Day view. Format argument: {0} = Current ruler time. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the TimeRulerFormat property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeTimeRulerFormat() As Boolean
            Return Me.ShouldSerialize("TimeRulerFormat")
        End Function


        ''' <summary>
        ''' Resets the Time ruler format for the Day view. Format argument: {0} = Current ruler time. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the TimeRulerFormat property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetTimeRulerFormat()
            Me.Reset("TimeRulerFormat")
        End Sub


        ''' <summary>
        ''' Format of the text for the day cell header in the month view. Format argument: {0} = Day date.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Format of the text for the day cell header in the month view. Format argument: {0} = Day date.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property DayHeaderFormat() As System.String
            Get
                Return CType(Me.GetProperty("DayHeaderFormat"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("DayHeaderFormat", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Format of the text for the day cell header in the month view. Format argument: {0} = Day date. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the DayHeaderFormat property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeDayHeaderFormat() As Boolean
            Return Me.ShouldSerialize("DayHeaderFormat")
        End Function


        ''' <summary>
        ''' Resets the Format of the text for the day cell header in the month view. Format argument: {0} = Day date. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the DayHeaderFormat property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetDayHeaderFormat()
            Me.Reset("DayHeaderFormat")
        End Sub


        ''' <summary>
        ''' Format of the text for the first cell header in the first row of the month view. Format argument: {0} = Day date.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Format of the text for the first cell header in the first row of the month view. Format argument: {0} = Day date.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property FirstRowDayHeaderFormat() As System.String
            Get
                Return CType(Me.GetProperty("FirstRowDayHeaderFormat"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("FirstRowDayHeaderFormat", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Format of the text for the first cell header in the first row of the month view. Format argument: {0} = Day date. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the FirstRowDayHeaderFormat property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeFirstRowDayHeaderFormat() As Boolean
            Return Me.ShouldSerialize("FirstRowDayHeaderFormat")
        End Function


        ''' <summary>
        ''' Resets the Format of the text for the first cell header in the first row of the month view. Format argument: {0} = Day date. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the FirstRowDayHeaderFormat property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetFirstRowDayHeaderFormat()
            Me.Reset("FirstRowDayHeaderFormat")
        End Sub


        ''' <summary>
        ''' Array of the calendar names which need to be shown.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Array of the calendar names which need to be shown.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property VisibleCalendars() As System.String()
            Get
                Return CType(Me.GetProperty("VisibleCalendars"), System.String())
            End Get
            Set(value As System.String())
                Me.SetProperty("VisibleCalendars", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Array of the calendar names which need to be shown. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the VisibleCalendars property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeVisibleCalendars() As Boolean
            Return Me.ShouldSerialize("VisibleCalendars")
        End Function


        ''' <summary>
        ''' Resets the Array of the calendar names which need to be shown. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the VisibleCalendars property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetVisibleCalendars()
            Me.Reset("VisibleCalendars")
        End Sub


        ''' <summary>
        ''' The active view type. Possible values are: day, week, month, list.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("The active view type. Possible values are: day, week, month, list.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ViewType() As C1.Web.Wijmo.Controls.C1EventsCalendar.C1EventsCalendarViewType
            Get
                Return CType(Me.GetProperty("ViewType"), C1.Web.Wijmo.Controls.C1EventsCalendar.C1EventsCalendarViewType)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1EventsCalendar.C1EventsCalendarViewType)
                Me.SetProperty("ViewType", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The active view type. Possible values are: day, week, month, list. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ViewType property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeViewType() As Boolean
            Return Me.ShouldSerialize("ViewType")
        End Function


        ''' <summary>
        ''' Resets the The active view type. Possible values are: day, week, month, list. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ViewType property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetViewType()
            Me.Reset("ViewType")
        End Sub


        ''' <summary>
        ''' Format of the text for the day header in the day/week or list view. Format argument: {0} = Day date.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Format of the text for the day header in the day/week or list view. Format argument: {0} = Day date.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property DayViewHeaderFormat As C1.Web.Wijmo.Controls.C1EventsCalendar.DayViewHeaderFormatOption
            Get
                Return CType(Me.GetProperty("DayViewHeaderFormat"), C1.Web.Wijmo.Controls.C1EventsCalendar.DayViewHeaderFormatOption)
            End Get
        End Property


        ''' <summary>
        ''' Use the Localization property in order to customize localization strings.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Use the Localization property in order to customize localization strings.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Localization As C1.Web.Wijmo.Controls.C1EventsCalendar.LocalizationOption
            Get
                Return CType(Me.GetProperty("Localization"), C1.Web.Wijmo.Controls.C1EventsCalendar.LocalizationOption)
            End Get
        End Property


        ''' <summary>
        ''' Use the Localization property in order to customize localization strings.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Use the Localization property in order to customize localization strings.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property DatePagerLocalization As C1.Web.Wijmo.Controls.C1EventsCalendar.DatePagerLocalizationOption
            Get
                Return CType(Me.GetProperty("DatePagerLocalization"), C1.Web.Wijmo.Controls.C1EventsCalendar.DatePagerLocalizationOption)
            End Get
        End Property


        ''' <summary>
        ''' Occurs before the built-in event dialog is shown. Return false or call event.preventDefault() in order to cancel event and prevent the built-in dialog to be shown. args.data - the event data. args.targetCell - target offset DOM element which can be used for popup callout.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs before the built-in event dialog is shown. Return false or call event.preventDefault() in order to cancel event and prevent the built-in dialog to be shown. args.data - the event data. args.targetCell - target offset DOM element which can be used for popup callout.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientBeforeEditEventDialogShow() As System.String
            Get
                Return CType(Me.GetProperty("OnClientBeforeEditEventDialogShow"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientBeforeEditEventDialogShow", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs before the built-in event dialog is shown. Return false or call event.preventDefault() in order to cancel event and prevent the built-in dialog to be shown. args.data - the event data. args.targetCell - target offset DOM element which can be used for popup callout. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeEditEventDialogShow property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientBeforeEditEventDialogShow() As Boolean
            Return Me.ShouldSerialize("OnClientBeforeEditEventDialogShow")
        End Function


        ''' <summary>
        ''' Resets the Occurs before the built-in event dialog is shown. Return false or call event.preventDefault() in order to cancel event and prevent the built-in dialog to be shown. args.data - the event data. args.targetCell - target offset DOM element which can be used for popup callout. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientBeforeEditEventDialogShow property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientBeforeEditEventDialogShow()
            Me.Reset("OnClientBeforeEditEventDialogShow")
        End Sub


        ''' <summary>
        ''' Occurs when calendars option has been changed. args.calendars - the new calendars option value.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs when calendars option has been changed. args.calendars - the new calendars option value.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientCalendarsChanged() As System.String
            Get
                Return CType(Me.GetProperty("OnClientCalendarsChanged"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientCalendarsChanged", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs when calendars option has been changed. args.calendars - the new calendars option value. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientCalendarsChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientCalendarsChanged() As Boolean
            Return Me.ShouldSerialize("OnClientCalendarsChanged")
        End Function


        ''' <summary>
        ''' Resets the Occurs when calendars option has been changed. args.calendars - the new calendars option value. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientCalendarsChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientCalendarsChanged()
            Me.Reset("OnClientCalendarsChanged")
        End Sub


        ''' <summary>
        ''' Occurs when events calendar is constructed and events data is loaded from an external or local data source.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs when events calendar is constructed and events data is loaded from an external or local data source.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientInitialized() As System.String
            Get
                Return CType(Me.GetProperty("OnClientInitialized"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientInitialized", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs when events calendar is constructed and events data is loaded from an external or local data source. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientInitialized property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientInitialized() As Boolean
            Return Me.ShouldSerialize("OnClientInitialized")
        End Function


        ''' <summary>
        ''' Resets the Occurs when events calendar is constructed and events data is loaded from an external or local data source. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientInitialized property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientInitialized()
            Me.Reset("OnClientInitialized")
        End Sub


        ''' <summary>
        ''' Occurs when selectedDates option has been changed. args.selectedDates - the new selectedDates value.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs when selectedDates option has been changed. args.selectedDates - the new selectedDates value.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientSelectedDatesChanged() As System.String
            Get
                Return CType(Me.GetProperty("OnClientSelectedDatesChanged"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientSelectedDatesChanged", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs when selectedDates option has been changed. args.selectedDates - the new selectedDates value. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientSelectedDatesChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientSelectedDatesChanged() As Boolean
            Return Me.ShouldSerialize("OnClientSelectedDatesChanged")
        End Function


        ''' <summary>
        ''' Resets the Occurs when selectedDates option has been changed. args.selectedDates - the new selectedDates value. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientSelectedDatesChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientSelectedDatesChanged()
            Me.Reset("OnClientSelectedDatesChanged")
        End Sub


        ''' <summary>
        ''' Occurs when viewType option has been changed.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs when viewType option has been changed.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientViewTypeChanged() As System.String
            Get
                Return CType(Me.GetProperty("OnClientViewTypeChanged"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientViewTypeChanged", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs when viewType option has been changed. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientViewTypeChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientViewTypeChanged() As Boolean
            Return Me.ShouldSerialize("OnClientViewTypeChanged")
        End Function


        ''' <summary>
        ''' Resets the Occurs when viewType option has been changed. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientViewTypeChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientViewTypeChanged()
            Me.Reset("OnClientViewTypeChanged")
        End Sub


        ''' <summary>
        ''' Occurs before the add event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be added to a data source.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs before the add event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be added to a data source.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientBeforeAddEvent() As System.String
            Get
                Return CType(Me.GetProperty("OnClientBeforeAddEvent"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientBeforeAddEvent", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs before the add event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be added to a data source. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeAddEvent property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientBeforeAddEvent() As Boolean
            Return Me.ShouldSerialize("OnClientBeforeAddEvent")
        End Function


        ''' <summary>
        ''' Resets the Occurs before the add event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be added to a data source. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientBeforeAddEvent property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientBeforeAddEvent()
            Me.Reset("OnClientBeforeAddEvent")
        End Sub


        ''' <summary>
        ''' Occurs before the save event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be updated. args.prevData - previous event data, this argument is empty for a new event.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs before the save event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be updated. args.prevData - previous event data, this argument is empty for a new event.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientBeforeUpdateEvent() As System.String
            Get
                Return CType(Me.GetProperty("OnClientBeforeUpdateEvent"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientBeforeUpdateEvent", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs before the save event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be updated. args.prevData - previous event data, this argument is empty for a new event. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeUpdateEvent property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientBeforeUpdateEvent() As Boolean
            Return Me.ShouldSerialize("OnClientBeforeUpdateEvent")
        End Function


        ''' <summary>
        ''' Resets the Occurs before the save event action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new event data that should be updated. args.prevData - previous event data, this argument is empty for a new event. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientBeforeUpdateEvent property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientBeforeUpdateEvent()
            Me.Reset("OnClientBeforeUpdateEvent")
        End Sub


        ''' <summary>
        ''' Occurs before the delete action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the new event data that should be saved to a data source. args.data - the event object that should be deleted.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs before the delete action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the new event data that should be saved to a data source. args.data - the event object that should be deleted.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientBeforeDeleteEvent() As System.String
            Get
                Return CType(Me.GetProperty("OnClientBeforeDeleteEvent"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientBeforeDeleteEvent", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs before the delete action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the new event data that should be saved to a data source. args.data - the event object that should be deleted. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeDeleteEvent property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientBeforeDeleteEvent() As Boolean
            Return Me.ShouldSerialize("OnClientBeforeDeleteEvent")
        End Function


        ''' <summary>
        ''' Resets the Occurs before the delete action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the new event data that should be saved to a data source. args.data - the event object that should be deleted. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientBeforeDeleteEvent property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientBeforeDeleteEvent()
            Me.Reset("OnClientBeforeDeleteEvent")
        End Sub


        ''' <summary>
        ''' Occurs before the save calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new calendar data that should be saved to a data source. args.prevData - previous calendar data, this argument is empty for a new calendar.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs before the save calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new calendar data that should be saved to a data source. args.prevData - previous calendar data, this argument is empty for a new calendar.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientBeforeSaveCalendar() As System.String
            Get
                Return CType(Me.GetProperty("OnClientBeforeSaveCalendar"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientBeforeSaveCalendar", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs before the save calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new calendar data that should be saved to a data source. args.prevData - previous calendar data, this argument is empty for a new calendar. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeSaveCalendar property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientBeforeSaveCalendar() As Boolean
            Return Me.ShouldSerialize("OnClientBeforeSaveCalendar")
        End Function


        ''' <summary>
        ''' Resets the Occurs before the save calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the save action. args.data - the new calendar data that should be saved to a data source. args.prevData - previous calendar data, this argument is empty for a new calendar. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientBeforeSaveCalendar property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientBeforeSaveCalendar()
            Me.Reset("OnClientBeforeSaveCalendar")
        End Sub


        ''' <summary>
        ''' Occurs before the delete calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the calendar data that should be deleted from a data source.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs before the delete calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the calendar data that should be deleted from a data source.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientBeforeDeleteCalendar() As System.String
            Get
                Return CType(Me.GetProperty("OnClientBeforeDeleteCalendar"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientBeforeDeleteCalendar", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs before the delete calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the calendar data that should be deleted from a data source. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeDeleteCalendar property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientBeforeDeleteCalendar() As Boolean
            Return Me.ShouldSerialize("OnClientBeforeDeleteCalendar")
        End Function


        ''' <summary>
        ''' Resets the Occurs before the delete calendar action. Return false or call event.preventDefault() in order to cancel event and prevent the delete action. args.data - the calendar data that should be deleted from a data source. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientBeforeDeleteCalendar property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientBeforeDeleteCalendar()
            Me.Reset("OnClientBeforeDeleteCalendar")
        End Sub


        ''' <summary>
        ''' C1EventsCalendar storage configuration.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Data")> _
        <System.ComponentModel.Description("C1EventsCalendar storage configuration.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property DataStorage As C1.Web.Wijmo.Controls.C1EventsCalendar.C1EventsCalendarStorage
            Get
                Return CType(Me.GetProperty("DataStorage"), C1.Web.Wijmo.Controls.C1EventsCalendar.C1EventsCalendarStorage)
            End Get
        End Property


        ''' <summary>
        ''' Name of the theme that will be used to style widgets. Available themes: aristo / midnight / ui-lightness. Note, only one theme can be used for the whole page at one time. Please, make sure that all widget extenders have the same Theme value.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Name of the theme that will be used to style widgets. Available themes: aristo / midnight / ui-lightness. Note, only one theme can be used for the whole page at one time. Please, make sure that all widget extenders have the same Theme value.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public Property Theme() As System.String
            Get
                Return CType(Me.GetProperty("Theme"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("Theme", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Name of the theme that will be used to style widgets. Available themes: aristo / midnight / ui-lightness. Note, only one theme can be used for the whole page at one time. Please, make sure that all widget extenders have the same Theme value. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Theme property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeTheme() As Boolean
            Return Me.ShouldSerialize("Theme")
        End Function


        ''' <summary>
        ''' Resets the Name of the theme that will be used to style widgets. Available themes: aristo / midnight / ui-lightness. Note, only one theme can be used for the whole page at one time. Please, make sure that all widget extenders have the same Theme value. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Theme property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetTheme()
            Me.Reset("Theme")
        End Sub


        ''' <summary>
        ''' Determines whether this extender loads client script references from CDN.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Determines whether this extender loads client script references from CDN.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public Property UseCDN() As System.Boolean
            Get
                Return CType(Me.GetProperty("UseCDN"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("UseCDN", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Determines whether this extender loads client script references from CDN. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the UseCDN property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeUseCDN() As Boolean
            Return Me.ShouldSerialize("UseCDN")
        End Function


        ''' <summary>
        ''' Resets the Determines whether this extender loads client script references from CDN. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the UseCDN property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetUseCDN()
            Me.Reset("UseCDN")
        End Sub


        ''' <summary>
        ''' Content Delivery Network path.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Content Delivery Network path.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public Property CDNPath() As System.String
            Get
                Return CType(Me.GetProperty("CDNPath"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("CDNPath", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Content Delivery Network path. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the CDNPath property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeCDNPath() As Boolean
            Return Me.ShouldSerialize("CDNPath")
        End Function


        ''' <summary>
        ''' Resets the Content Delivery Network path. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the CDNPath property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetCDNPath()
            Me.Reset("CDNPath")
        End Sub


        ''' <summary>
        ''' Indicates the control applies the theme of JQuery UI or Bootstrap.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Indicates the control applies the theme of JQuery UI or Bootstrap.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public Property WijmoCssAdapter() As System.String
            Get
                Return CType(Me.GetProperty("WijmoCssAdapter"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("WijmoCssAdapter", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Indicates the control applies the theme of JQuery UI or Bootstrap. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the WijmoCssAdapter property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeWijmoCssAdapter() As Boolean
            Return Me.ShouldSerialize("WijmoCssAdapter")
        End Function


        ''' <summary>
        ''' Resets the Indicates the control applies the theme of JQuery UI or Bootstrap. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the WijmoCssAdapter property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetWijmoCssAdapter()
            Me.Reset("WijmoCssAdapter")
        End Sub


        ''' <summary>
        ''' A value that indicates mode of the control, whether it is a mobile or web control. Note that only one value can be used for the whole website or project.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("A value that indicates mode of the control, whether it is a mobile or web control. Note that only one value can be used for the whole website or project.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public Property WijmoControlMode() As C1.Web.Wijmo.Controls.WijmoControlMode
            Get
                Return CType(Me.GetProperty("WijmoControlMode"), C1.Web.Wijmo.Controls.WijmoControlMode)
            End Get
            Set(value As C1.Web.Wijmo.Controls.WijmoControlMode)
                Me.SetProperty("WijmoControlMode", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates mode of the control, whether it is a mobile or web control. Note that only one value can be used for the whole website or project. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the WijmoControlMode property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeWijmoControlMode() As Boolean
            Return Me.ShouldSerialize("WijmoControlMode")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates mode of the control, whether it is a mobile or web control. Note that only one value can be used for the whole website or project. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the WijmoControlMode property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetWijmoControlMode()
            Me.Reset("WijmoControlMode")
        End Sub


        ''' <summary>
        ''' A value that indicates the theme swatch of  the control, this property only works when WijmoControlMode property is Mobile.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("A value that indicates the theme swatch of  the control, this property only works when WijmoControlMode property is Mobile.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public Property ThemeSwatch() As System.String
            Get
                Return CType(Me.GetProperty("ThemeSwatch"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("ThemeSwatch", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates the theme swatch of  the control, this property only works when WijmoControlMode property is Mobile. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ThemeSwatch property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeThemeSwatch() As Boolean
            Return Me.ShouldSerialize("ThemeSwatch")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates the theme swatch of  the control, this property only works when WijmoControlMode property is Mobile. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ThemeSwatch property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetThemeSwatch()
            Me.Reset("ThemeSwatch")
        End Sub


        ''' <summary>
        ''' Enabled state of the control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Enabled state of the control.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property HostedEnabled() As System.Boolean
            Get
                Return CType(Me.GetProperty("Enabled"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("Enabled", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Enabled state of the control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Enabled property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHostedEnabled() As Boolean
            Return Me.ShouldSerialize("Enabled")
        End Function


        ''' <summary>
        ''' Resets the Enabled state of the control. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Enabled property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetHostedEnabled()
            Me.Reset("Enabled")
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public Property DisabledState() As System.Boolean
            Get
                Return CType(Me.GetProperty("DisabledState"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("DisabledState", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if  should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the DisabledState property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeDisabledState() As Boolean
            Return Me.ShouldSerialize("DisabledState")
        End Function


        ''' <summary>
        ''' Resets the  property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the DisabledState property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetDisabledState()
            Me.Reset("DisabledState")
        End Sub


        ''' <summary>
        ''' Color of the background of the control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Color of the background of the control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property HostedBackColor() As System.Drawing.Color
            Get
                Return CType(Me.GetProperty("BackColor"), System.Drawing.Color)
            End Get
            Set(value As System.Drawing.Color)
                Me.SetProperty("BackColor", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Color of the background of the control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the BackColor property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHostedBackColor() As Boolean
            Return Me.ShouldSerialize("BackColor")
        End Function


        ''' <summary>
        ''' Resets the Color of the background of the control. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the BackColor property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetHostedBackColor()
            Me.Reset("BackColor")
        End Sub


        ''' <summary>
        ''' Color of the border around the control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Color of the border around the control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property HostedBorderColor() As System.Drawing.Color
            Get
                Return CType(Me.GetProperty("BorderColor"), System.Drawing.Color)
            End Get
            Set(value As System.Drawing.Color)
                Me.SetProperty("BorderColor", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Color of the border around the control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the BorderColor property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHostedBorderColor() As Boolean
            Return Me.ShouldSerialize("BorderColor")
        End Function


        ''' <summary>
        ''' Resets the Color of the border around the control. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the BorderColor property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetHostedBorderColor()
            Me.Reset("BorderColor")
        End Sub


        ''' <summary>
        ''' Style of the border around the control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Style of the border around the control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property HostedBorderStyle() As System.Web.UI.WebControls.BorderStyle
            Get
                Return CType(Me.GetProperty("BorderStyle"), System.Web.UI.WebControls.BorderStyle)
            End Get
            Set(value As System.Web.UI.WebControls.BorderStyle)
                Me.SetProperty("BorderStyle", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Style of the border around the control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the BorderStyle property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHostedBorderStyle() As Boolean
            Return Me.ShouldSerialize("BorderStyle")
        End Function


        ''' <summary>
        ''' Resets the Style of the border around the control. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the BorderStyle property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetHostedBorderStyle()
            Me.Reset("BorderStyle")
        End Sub


        ''' <summary>
        ''' Width of the border around the control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Width of the border around the control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property HostedBorderWidth() As System.Web.UI.WebControls.Unit
            Get
                Return CType(Me.GetProperty("BorderWidth"), System.Web.UI.WebControls.Unit)
            End Get
            Set(value As System.Web.UI.WebControls.Unit)
                Me.SetProperty("BorderWidth", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Width of the border around the control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the BorderWidth property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHostedBorderWidth() As Boolean
            Return Me.ShouldSerialize("BorderWidth")
        End Function


        ''' <summary>
        ''' Resets the Width of the border around the control. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the BorderWidth property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetHostedBorderWidth()
            Me.Reset("BorderWidth")
        End Sub


        ''' <summary>
        ''' The font used for text within the control.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("The font used for text within the control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property HostedFont As System.Web.UI.WebControls.FontInfo
            Get
                Return CType(Me.GetProperty("Font"), System.Web.UI.WebControls.FontInfo)
            End Get
        End Property


        ''' <summary>
        ''' Color of the text within the control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Color of the text within the control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property HostedForeColor() As System.Drawing.Color
            Get
                Return CType(Me.GetProperty("ForeColor"), System.Drawing.Color)
            End Get
            Set(value As System.Drawing.Color)
                Me.SetProperty("ForeColor", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Color of the text within the control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ForeColor property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHostedForeColor() As Boolean
            Return Me.ShouldSerialize("ForeColor")
        End Function


        ''' <summary>
        ''' Resets the Color of the text within the control. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ForeColor property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetHostedForeColor()
            Me.Reset("ForeColor")
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property InnerStates As System.Collections.Hashtable
            Get
                Return CType(Me.GetProperty("InnerStates"), System.Collections.Hashtable)
            End Get
        End Property



#End Region

#Region "Methods"

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)

            If disposing And Not (components Is Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub



#End Region

#Region "Events"



#End Region

    End Class
End Namespace