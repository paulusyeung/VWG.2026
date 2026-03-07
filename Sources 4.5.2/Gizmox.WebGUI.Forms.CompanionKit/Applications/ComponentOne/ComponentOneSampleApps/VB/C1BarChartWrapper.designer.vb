Namespace Gizmox.WebGUI.Forms.CompanionKit.ComponentOneSampleAppsVB
    Partial Class C1BarChartWrapper

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
                Return GetType(C1.Web.Wijmo.Controls.C1Chart.C1BarChart)
            End Get
        End Property

        ''' <summary>
        ''' Get hosted control typed instance
        ''' </summary>
        Protected ReadOnly Property HostedC1BarChart As C1.Web.Wijmo.Controls.C1Chart.C1BarChart
            Get
                Return CType(Me.HostedControl, C1.Web.Wijmo.Controls.C1Chart.C1BarChart)
            End Get
        End Property


        ''' <summary>
        ''' A value that determines whether the bar chart renders horizontal or vertical.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("A value that determines whether the bar chart renders horizontal or vertical.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property Horizontal() As System.Boolean
            Get
                Return CType(Me.GetProperty("Horizontal"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("Horizontal", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that determines whether the bar chart renders horizontal or vertical. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Horizontal property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHorizontal() As Boolean
            Return Me.ShouldSerialize("Horizontal")
        End Function


        ''' <summary>
        ''' Resets the A value that determines whether the bar chart renders horizontal or vertical. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Horizontal property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetHorizontal()
            Me.Reset("Horizontal")
        End Sub


        ''' <summary>
        ''' A value that determines whether to show a stacked chart.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("A value that determines whether to show a stacked chart.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property Stacked() As System.Boolean
            Get
                Return CType(Me.GetProperty("Stacked"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("Stacked", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that determines whether to show a stacked chart. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Stacked property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeStacked() As Boolean
            Return Me.ShouldSerialize("Stacked")
        End Function


        ''' <summary>
        ''' Resets the A value that determines whether to show a stacked chart. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Stacked property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetStacked()
            Me.Reset("Stacked")
        End Sub


        ''' <summary>
        ''' A value that determines whether to show a stacked and percentage chart.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("A value that determines whether to show a stacked and percentage chart.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property Is100Percent() As System.Boolean
            Get
                Return CType(Me.GetProperty("Is100Percent"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("Is100Percent", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that determines whether to show a stacked and percentage chart. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Is100Percent property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeIs100Percent() As Boolean
            Return Me.ShouldSerialize("Is100Percent")
        End Function


        ''' <summary>
        ''' Resets the A value that determines whether to show a stacked and percentage chart. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Is100Percent property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetIs100Percent()
            Me.Reset("Is100Percent")
        End Sub


        ''' <summary>
        ''' A value that indicates the percentage of bar elements in the same cluster overlap.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("A value that indicates the percentage of bar elements in the same cluster overlap.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ClusterOverlap() As System.Int32
            Get
                Return CType(Me.GetProperty("ClusterOverlap"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("ClusterOverlap", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates the percentage of bar elements in the same cluster overlap. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ClusterOverlap property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeClusterOverlap() As Boolean
            Return Me.ShouldSerialize("ClusterOverlap")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates the percentage of bar elements in the same cluster overlap. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ClusterOverlap property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetClusterOverlap()
            Me.Reset("ClusterOverlap")
        End Sub


        ''' <summary>
        ''' A value that indicates the percentage of the plotarea that each bar cluster occupies.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("A value that indicates the percentage of the plotarea that each bar cluster occupies.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ClusterWidth() As System.Int32
            Get
                Return CType(Me.GetProperty("ClusterWidth"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("ClusterWidth", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates the percentage of the plotarea that each bar cluster occupies. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ClusterWidth property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeClusterWidth() As Boolean
            Return Me.ShouldSerialize("ClusterWidth")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates the percentage of the plotarea that each bar cluster occupies. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ClusterWidth property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetClusterWidth()
            Me.Reset("ClusterWidth")
        End Sub


        ''' <summary>
        ''' A value that indicates the corner-radius for the bar.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("A value that indicates the corner-radius for the bar.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ClusterRadius() As System.Int32
            Get
                Return CType(Me.GetProperty("ClusterRadius"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("ClusterRadius", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates the corner-radius for the bar. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ClusterRadius property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeClusterRadius() As Boolean
            Return Me.ShouldSerialize("ClusterRadius")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates the corner-radius for the bar. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ClusterRadius property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetClusterRadius()
            Me.Reset("ClusterRadius")
        End Sub


        ''' <summary>
        ''' A value that indicates the spacing between the adjacent bars.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("A value that indicates the spacing between the adjacent bars.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ClusterSpacing() As System.Int32
            Get
                Return CType(Me.GetProperty("ClusterSpacing"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("ClusterSpacing", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates the spacing between the adjacent bars. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ClusterSpacing property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeClusterSpacing() As Boolean
            Return Me.ShouldSerialize("ClusterSpacing")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates the spacing between the adjacent bars. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ClusterSpacing property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetClusterSpacing()
            Me.Reset("ClusterSpacing")
        End Sub


        ''' <summary>
        ''' A value that indicates whether to show animation and the duration and effect for the animation when reload data.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("A value that indicates whether to show animation and the duration and effect for the animation when reload data.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public Property SeriesTransition() As C1.Web.Wijmo.Controls.C1Chart.ChartAnimation
            Get
                Return CType(Me.GetProperty("SeriesTransition"), C1.Web.Wijmo.Controls.C1Chart.ChartAnimation)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1Chart.ChartAnimation)
                Me.SetProperty("SeriesTransition", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates whether to show animation and the duration and effect for the animation when reload data. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the SeriesTransition property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeSeriesTransition() As Boolean
            Return Me.ShouldSerialize("SeriesTransition")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates whether to show animation and the duration and effect for the animation when reload data. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the SeriesTransition property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetSeriesTransition()
            Me.Reset("SeriesTransition")
        End Sub


        ''' <summary>
        ''' A value that indicates whether to show animation and the duration and easing for the animation.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("A value that indicates whether to show animation and the duration and easing for the animation.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public Property Animation() As C1.Web.Wijmo.Controls.C1Chart.ChartAnimation
            Get
                Return CType(Me.GetProperty("Animation"), C1.Web.Wijmo.Controls.C1Chart.ChartAnimation)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1Chart.ChartAnimation)
                Me.SetProperty("Animation", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates whether to show animation and the duration and easing for the animation. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Animation property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAnimation() As Boolean
            Return Me.ShouldSerialize("Animation")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates whether to show animation and the duration and easing for the animation. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Animation property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAnimation()
            Me.Reset("Animation")
        End Sub


        ''' <summary>
        ''' An array collection that contains the data to be charted.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Data")> _
        <System.ComponentModel.Description("An array collection that contains the data to be charted.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property SeriesList As System.Collections.Generic.List(Of C1.Web.Wijmo.Controls.C1Chart.BarChartSeries)
            Get
                Return CType(Me.GetProperty("SeriesList"), System.Collections.Generic.List(Of C1.Web.Wijmo.Controls.C1Chart.BarChartSeries))
            End Get
        End Property


        ''' <summary>
        ''' An array collection that contains the style to be charted.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Style")> _
        <System.ComponentModel.Description("An array collection that contains the style to be charted.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property SeriesStyles As System.Collections.Generic.List(Of C1.Web.Wijmo.Controls.C1Chart.ChartStyle)
            Get
                Return CType(Me.GetProperty("SeriesStyles"), System.Collections.Generic.List(Of C1.Web.Wijmo.Controls.C1Chart.ChartStyle))
            End Get
        End Property


        ''' <summary>
        ''' An array collection that contains the style to be charted when hovering the chart element.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Style")> _
        <System.ComponentModel.Description("An array collection that contains the style to be charted when hovering the chart element.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property SeriesHoverStyles As System.Collections.Generic.List(Of C1.Web.Wijmo.Controls.C1Chart.ChartStyle)
            Get
                Return CType(Me.GetProperty("SeriesHoverStyles"), System.Collections.Generic.List(Of C1.Web.Wijmo.Controls.C1Chart.ChartStyle))
            End Get
        End Property


        ''' <summary>
        ''' Gets or sets the culture information for the input control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Gets or sets the culture information for the input control.")> _
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
        ''' Returns a boolean indicating if Gets or sets the culture information for the input control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Culture property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeCulture() As Boolean
            Return Me.ShouldSerialize("Culture")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets the culture information for the input control. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Culture property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetCulture()
            Me.Reset("Culture")
        End Sub


        ''' <summary>
        ''' A value that indicates the top margin of the chart area.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("A value that indicates the top margin of the chart area.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property MarginTop() As System.Int32
            Get
                Return CType(Me.GetProperty("MarginTop"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("MarginTop", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates the top margin of the chart area. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the MarginTop property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeMarginTop() As Boolean
            Return Me.ShouldSerialize("MarginTop")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates the top margin of the chart area. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the MarginTop property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetMarginTop()
            Me.Reset("MarginTop")
        End Sub


        ''' <summary>
        ''' A value that indicates the right margin of the chart area.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("A value that indicates the right margin of the chart area.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property MarginRight() As System.Int32
            Get
                Return CType(Me.GetProperty("MarginRight"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("MarginRight", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates the right margin of the chart area. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the MarginRight property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeMarginRight() As Boolean
            Return Me.ShouldSerialize("MarginRight")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates the right margin of the chart area. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the MarginRight property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetMarginRight()
            Me.Reset("MarginRight")
        End Sub


        ''' <summary>
        ''' A value that indicates the bottom margin of the chart area.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("A value that indicates the bottom margin of the chart area.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property MarginBottom() As System.Int32
            Get
                Return CType(Me.GetProperty("MarginBottom"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("MarginBottom", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates the bottom margin of the chart area. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the MarginBottom property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeMarginBottom() As Boolean
            Return Me.ShouldSerialize("MarginBottom")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates the bottom margin of the chart area. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the MarginBottom property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetMarginBottom()
            Me.Reset("MarginBottom")
        End Sub


        ''' <summary>
        ''' A value that indicates the left margin of the chart area.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("A value that indicates the left margin of the chart area.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property MarginLeft() As System.Int32
            Get
                Return CType(Me.GetProperty("MarginLeft"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("MarginLeft", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates the left margin of the chart area. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the MarginLeft property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeMarginLeft() As Boolean
            Return Me.ShouldSerialize("MarginLeft")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates the left margin of the chart area. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the MarginLeft property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetMarginLeft()
            Me.Reset("MarginLeft")
        End Sub


        ''' <summary>
        ''' A value that indicates the style of the chart text.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Style")> _
        <System.ComponentModel.Description("A value that indicates the style of the chart text.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public Property TextStyle() As C1.Web.Wijmo.Controls.C1Chart.ChartStyle
            Get
                Return CType(Me.GetProperty("TextStyle"), C1.Web.Wijmo.Controls.C1Chart.ChartStyle)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1Chart.ChartStyle)
                Me.SetProperty("TextStyle", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates the style of the chart text. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the TextStyle property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeTextStyle() As Boolean
            Return Me.ShouldSerialize("TextStyle")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates the style of the chart text. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the TextStyle property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetTextStyle()
            Me.Reset("TextStyle")
        End Sub


        ''' <summary>
        ''' An object that value indicates the header of the chart element.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("An object that value indicates the header of the chart element.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public Property Header() As C1.Web.Wijmo.Controls.C1Chart.ChartTitle
            Get
                Return CType(Me.GetProperty("Header"), C1.Web.Wijmo.Controls.C1Chart.ChartTitle)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1Chart.ChartTitle)
                Me.SetProperty("Header", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if An object that value indicates the header of the chart element. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Header property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHeader() As Boolean
            Return Me.ShouldSerialize("Header")
        End Function


        ''' <summary>
        ''' Resets the An object that value indicates the header of the chart element. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Header property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetHeader()
            Me.Reset("Header")
        End Sub


        ''' <summary>
        ''' An object value that indicates the footer of the chart element.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("An object value that indicates the footer of the chart element.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public Property Footer() As C1.Web.Wijmo.Controls.C1Chart.ChartTitle
            Get
                Return CType(Me.GetProperty("Footer"), C1.Web.Wijmo.Controls.C1Chart.ChartTitle)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1Chart.ChartTitle)
                Me.SetProperty("Footer", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if An object value that indicates the footer of the chart element. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Footer property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeFooter() As Boolean
            Return Me.ShouldSerialize("Footer")
        End Function


        ''' <summary>
        ''' Resets the An object value that indicates the footer of the chart element. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Footer property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetFooter()
            Me.Reset("Footer")
        End Sub


        ''' <summary>
        ''' An object value indicates the legend of the chart element.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("An object value indicates the legend of the chart element.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public Property Legend() As C1.Web.Wijmo.Controls.C1Chart.ChartLegend
            Get
                Return CType(Me.GetProperty("Legend"), C1.Web.Wijmo.Controls.C1Chart.ChartLegend)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1Chart.ChartLegend)
                Me.SetProperty("Legend", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if An object value indicates the legend of the chart element. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Legend property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeLegend() As Boolean
            Return Me.ShouldSerialize("Legend")
        End Function


        ''' <summary>
        ''' Resets the An object value indicates the legend of the chart element. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Legend property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetLegend()
            Me.Reset("Legend")
        End Sub


        ''' <summary>
        ''' A value that provides information about the axes.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("A value that provides information about the axes.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public Property Axis() As C1.Web.Wijmo.Controls.C1Chart.ChartAxes
            Get
                Return CType(Me.GetProperty("Axis"), C1.Web.Wijmo.Controls.C1Chart.ChartAxes)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1Chart.ChartAxes)
                Me.SetProperty("Axis", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that provides information about the axes. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Axis property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAxis() As Boolean
            Return Me.ShouldSerialize("Axis")
        End Function


        ''' <summary>
        ''' Resets the A value that provides information about the axes. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Axis property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAxis()
            Me.Reset("Axis")
        End Sub


        ''' <summary>
        ''' A value that is used to indicate whether to show and what to show on the open tooltip.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("A value that is used to indicate whether to show and what to show on the open tooltip.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public Property Hint() As C1.Web.Wijmo.Controls.C1Chart.ChartHint
            Get
                Return CType(Me.GetProperty("Hint"), C1.Web.Wijmo.Controls.C1Chart.ChartHint)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1Chart.ChartHint)
                Me.SetProperty("Hint", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that is used to indicate whether to show and what to show on the open tooltip. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Hint property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHint() As Boolean
            Return Me.ShouldSerialize("Hint")
        End Function


        ''' <summary>
        ''' Resets the A value that is used to indicate whether to show and what to show on the open tooltip. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Hint property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetHint()
            Me.Reset("Hint")
        End Sub


        ''' <summary>
        ''' A value that indicates whether to show default chart labels.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("A value that indicates whether to show default chart labels.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ShowChartLabels() As System.Boolean
            Get
                Return CType(Me.GetProperty("ShowChartLabels"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("ShowChartLabels", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates whether to show default chart labels. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ShowChartLabels property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeShowChartLabels() As Boolean
            Return Me.ShouldSerialize("ShowChartLabels")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates whether to show default chart labels. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ShowChartLabels property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetShowChartLabels()
            Me.Reset("ShowChartLabels")
        End Sub


        ''' <summary>
        ''' A value that indicates style of the chart labels.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Style")> _
        <System.ComponentModel.Description("A value that indicates style of the chart labels.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public Property ChartLabelStyle() As C1.Web.Wijmo.Controls.C1Chart.ChartStyle
            Get
                Return CType(Me.GetProperty("ChartLabelStyle"), C1.Web.Wijmo.Controls.C1Chart.ChartStyle)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1Chart.ChartStyle)
                Me.SetProperty("ChartLabelStyle", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates style of the chart labels. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ChartLabelStyle property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeChartLabelStyle() As Boolean
            Return Me.ShouldSerialize("ChartLabelStyle")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates style of the chart labels. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ChartLabelStyle property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetChartLabelStyle()
            Me.Reset("ChartLabelStyle")
        End Sub


        ''' <summary>
        ''' A value that indicates the format string of the chart labels.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("A value that indicates the format string of the chart labels.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ChartLabelFormatString() As System.String
            Get
                Return CType(Me.GetProperty("ChartLabelFormatString"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("ChartLabelFormatString", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates the format string of the chart labels. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ChartLabelFormatString property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeChartLabelFormatString() As Boolean
            Return Me.ShouldSerialize("ChartLabelFormatString")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates the format string of the chart labels. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ChartLabelFormatString property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetChartLabelFormatString()
            Me.Reset("ChartLabelFormatString")
        End Sub


        ''' <summary>
        ''' A value that indicates whether to disable the default text style.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Style")> _
        <System.ComponentModel.Description("A value that indicates whether to disable the default text style.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property DisableDefaultTextStyle() As System.Boolean
            Get
                Return CType(Me.GetProperty("DisableDefaultTextStyle"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("DisableDefaultTextStyle", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates whether to disable the default text style. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the DisableDefaultTextStyle property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeDisableDefaultTextStyle() As Boolean
            Return Me.ShouldSerialize("DisableDefaultTextStyle")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates whether to disable the default text style. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the DisableDefaultTextStyle property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetDisableDefaultTextStyle()
            Me.Reset("DisableDefaultTextStyle")
        End Sub


        ''' <summary>
        ''' A value that indicates whether to show shadow for the chart.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("A value that indicates whether to show shadow for the chart.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property Shadow() As System.Boolean
            Get
                Return CType(Me.GetProperty("Shadow"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("Shadow", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates whether to show shadow for the chart. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Shadow property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeShadow() As Boolean
            Return Me.ShouldSerialize("Shadow")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates whether to show shadow for the chart. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Shadow property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetShadow()
            Me.Reset("Shadow")
        End Sub


        ''' <summary>
        ''' Occurs when the user clicks a mouse button.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs when the user clicks a mouse button.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientMouseDown() As System.String
            Get
                Return CType(Me.GetProperty("OnClientMouseDown"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientMouseDown", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs when the user clicks a mouse button. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientMouseDown property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientMouseDown() As Boolean
            Return Me.ShouldSerialize("OnClientMouseDown")
        End Function


        ''' <summary>
        ''' Resets the Occurs when the user clicks a mouse button. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientMouseDown property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientMouseDown()
            Me.Reset("OnClientMouseDown")
        End Sub


        ''' <summary>
        ''' Occurs when the user releases a mouse button while the pointer is over the chart element.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs when the user releases a mouse button while the pointer is over the chart element.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientMouseUp() As System.String
            Get
                Return CType(Me.GetProperty("OnClientMouseUp"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientMouseUp", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs when the user releases a mouse button while the pointer is over the chart element. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientMouseUp property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientMouseUp() As Boolean
            Return Me.ShouldSerialize("OnClientMouseUp")
        End Function


        ''' <summary>
        ''' Resets the Occurs when the user releases a mouse button while the pointer is over the chart element. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientMouseUp property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientMouseUp()
            Me.Reset("OnClientMouseUp")
        End Sub


        ''' <summary>
        ''' Occurs when the user first places the pointer over the chart element.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs when the user first places the pointer over the chart element.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientMouseOver() As System.String
            Get
                Return CType(Me.GetProperty("OnClientMouseOver"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientMouseOver", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs when the user first places the pointer over the chart element. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientMouseOver property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientMouseOver() As Boolean
            Return Me.ShouldSerialize("OnClientMouseOver")
        End Function


        ''' <summary>
        ''' Resets the Occurs when the user first places the pointer over the chart element. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientMouseOver property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientMouseOver()
            Me.Reset("OnClientMouseOver")
        End Sub


        ''' <summary>
        ''' Occurs when the user moves the pointer off of the chart element.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs when the user moves the pointer off of the chart element.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientMouseOut() As System.String
            Get
                Return CType(Me.GetProperty("OnClientMouseOut"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientMouseOut", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs when the user moves the pointer off of the chart element. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientMouseOut property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientMouseOut() As Boolean
            Return Me.ShouldSerialize("OnClientMouseOut")
        End Function


        ''' <summary>
        ''' Resets the Occurs when the user moves the pointer off of the chart element. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientMouseOut property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientMouseOut()
            Me.Reset("OnClientMouseOut")
        End Sub


        ''' <summary>
        ''' Occurs when the user moves the mouse pointer while it is over a chart element.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs when the user moves the mouse pointer while it is over a chart element.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientMouseMove() As System.String
            Get
                Return CType(Me.GetProperty("OnClientMouseMove"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientMouseMove", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs when the user moves the mouse pointer while it is over a chart element. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientMouseMove property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientMouseMove() As Boolean
            Return Me.ShouldSerialize("OnClientMouseMove")
        End Function


        ''' <summary>
        ''' Resets the Occurs when the user moves the mouse pointer while it is over a chart element. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientMouseMove property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientMouseMove()
            Me.Reset("OnClientMouseMove")
        End Sub


        ''' <summary>
        ''' Occurs when the user clicks the chart element.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs when the user clicks the chart element.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientClick() As System.String
            Get
                Return CType(Me.GetProperty("OnClientClick"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientClick", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs when the user clicks the chart element. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientClick property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientClick() As Boolean
            Return Me.ShouldSerialize("OnClientClick")
        End Function


        ''' <summary>
        ''' Resets the Occurs when the user clicks the chart element. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientClick property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientClick()
            Me.Reset("OnClientClick")
        End Sub


        ''' <summary>
        ''' Occurs before the series changes.  This event can be cancelled.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs before the series changes.  This event can be cancelled.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientBeforeSeriesChange() As System.String
            Get
                Return CType(Me.GetProperty("OnClientBeforeSeriesChange"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientBeforeSeriesChange", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs before the series changes.  This event can be cancelled. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientBeforeSeriesChange property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientBeforeSeriesChange() As Boolean
            Return Me.ShouldSerialize("OnClientBeforeSeriesChange")
        End Function


        ''' <summary>
        ''' Resets the Occurs before the series changes.  This event can be cancelled. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientBeforeSeriesChange property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientBeforeSeriesChange()
            Me.Reset("OnClientBeforeSeriesChange")
        End Sub


        ''' <summary>
        ''' Occurs when the series changes.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs when the series changes.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientSeriesChanged() As System.String
            Get
                Return CType(Me.GetProperty("OnClientSeriesChanged"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientSeriesChanged", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs when the series changes. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientSeriesChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientSeriesChanged() As Boolean
            Return Me.ShouldSerialize("OnClientSeriesChanged")
        End Function


        ''' <summary>
        ''' Resets the Occurs when the series changes. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientSeriesChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientSeriesChanged()
            Me.Reset("OnClientSeriesChanged")
        End Sub


        ''' <summary>
        ''' Occurs before the canvas is painted.  This event can be cancelled.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs before the canvas is painted.  This event can be cancelled.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientBeforePaint() As System.String
            Get
                Return CType(Me.GetProperty("OnClientBeforePaint"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientBeforePaint", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs before the canvas is painted.  This event can be cancelled. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientBeforePaint property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientBeforePaint() As Boolean
            Return Me.ShouldSerialize("OnClientBeforePaint")
        End Function


        ''' <summary>
        ''' Resets the Occurs before the canvas is painted.  This event can be cancelled. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientBeforePaint property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientBeforePaint()
            Me.Reset("OnClientBeforePaint")
        End Sub


        ''' <summary>
        ''' Occurs after the canvas is painted.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client-Side Events")> _
        <System.ComponentModel.Description("Occurs after the canvas is painted.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientPainted() As System.String
            Get
                Return CType(Me.GetProperty("OnClientPainted"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientPainted", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Occurs after the canvas is painted. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientPainted property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientPainted() As Boolean
            Return Me.ShouldSerialize("OnClientPainted")
        End Function


        ''' <summary>
        ''' Resets the Occurs after the canvas is painted. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientPainted property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientPainted()
            Me.Reset("OnClientPainted")
        End Sub


        ''' <summary>
        ''' Name of the theme that will be used to style widgets. Available themes: aristo / midnight / ui-lightness. Note, only one theme can be used for the whole page at one time. Please, make sure that all widget extenders have the same Theme value.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Name of the theme that will be used to style widgets. Available themes: aristo / midnight / ui-lightness. Note, only one theme can be used for the whole page at one time. Please, make sure that all widget extenders have the same Theme value.")> _
        <System.ComponentModel.Browsable(False)> _
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
        ''' A value that indicates the width of chart.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("A value that indicates the width of chart.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property HostedWidth() As System.Web.UI.WebControls.Unit
            Get
                Return CType(Me.GetProperty("Width"), System.Web.UI.WebControls.Unit)
            End Get
            Set(value As System.Web.UI.WebControls.Unit)
                Me.SetProperty("Width", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value that indicates the width of chart. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Width property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHostedWidth() As Boolean
            Return Me.ShouldSerialize("Width")
        End Function


        ''' <summary>
        ''' Resets the A value that indicates the width of chart. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Width property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetHostedWidth()
            Me.Reset("Width")
        End Sub


        ''' <summary>
        ''' The height of the control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("The height of the control.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property HostedHeight() As System.Web.UI.WebControls.Unit
            Get
                Return CType(Me.GetProperty("Height"), System.Web.UI.WebControls.Unit)
            End Get
            Set(value As System.Web.UI.WebControls.Unit)
                Me.SetProperty("Height", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The height of the control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Height property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHostedHeight() As Boolean
            Return Me.ShouldSerialize("Height")
        End Function


        ''' <summary>
        ''' Resets the The height of the control. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Height property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetHostedHeight()
            Me.Reset("Height")
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


        ''' <summary>
        ''' The table or view used for binding against.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Data")> _
        <System.ComponentModel.Description("The table or view used for binding against.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property DataMember() As System.String
            Get
                Return CType(Me.GetProperty("DataMember"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("DataMember", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The table or view used for binding against. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the DataMember property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeDataMember() As Boolean
            Return Me.ShouldSerialize("DataMember")
        End Function


        ''' <summary>
        ''' Resets the The table or view used for binding against. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the DataMember property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetDataMember()
            Me.Reset("DataMember")
        End Sub


        ''' <summary>
        ''' Gets a collection of C1ChartBinding objects that define the relationship between a data item and the chart series it is binding to.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Data")> _
        <System.ComponentModel.Description("Gets a collection of C1ChartBinding objects that define the relationship between a data item and the chart series it is binding to.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property HostedDataBindings As System.Collections.Generic.List(Of C1.Web.Wijmo.Controls.C1Chart.C1ChartBinding)
            Get
                Return CType(Me.GetProperty("DataBindings"), System.Collections.Generic.List(Of C1.Web.Wijmo.Controls.C1Chart.C1ChartBinding))
            End Get
        End Property


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
        ''' Indicates whether control is enabled.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Indicates whether control is enabled.")> _
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
        ''' Returns a boolean indicating if Indicates whether control is enabled. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Enabled property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHostedEnabled() As Boolean
            Return Me.ShouldSerialize("Enabled")
        End Function


        ''' <summary>
        ''' Resets the Indicates whether control is enabled. property to its default value.
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
        ''' The name of the model type used in the SelectMethod, InsertMethod, UpdateMethod, and DeleteMethod.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Data")> _
        <System.ComponentModel.Description("The name of the model type used in the SelectMethod, InsertMethod, UpdateMethod, and DeleteMethod.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ItemType() As System.String
            Get
                Return CType(Me.GetProperty("ItemType"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("ItemType", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The name of the model type used in the SelectMethod, InsertMethod, UpdateMethod, and DeleteMethod. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ItemType property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeItemType() As Boolean
            Return Me.ShouldSerialize("ItemType")
        End Function


        ''' <summary>
        ''' Resets the The name of the model type used in the SelectMethod, InsertMethod, UpdateMethod, and DeleteMethod. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ItemType property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetItemType()
            Me.Reset("ItemType")
        End Sub


        ''' <summary>
        ''' The name of the method on the page that is called when this control does a select operation.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Data")> _
        <System.ComponentModel.Description("The name of the method on the page that is called when this control does a select operation.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property SelectMethod() As System.String
            Get
                Return CType(Me.GetProperty("SelectMethod"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("SelectMethod", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The name of the method on the page that is called when this control does a select operation. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the SelectMethod property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeSelectMethod() As Boolean
            Return Me.ShouldSerialize("SelectMethod")
        End Function


        ''' <summary>
        ''' Resets the The name of the method on the page that is called when this control does a select operation. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the SelectMethod property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetSelectMethod()
            Me.Reset("SelectMethod")
        End Sub


        ''' <summary>
        ''' The control ID of an IDataSource that will be used as the data source.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Data")> _
        <System.ComponentModel.Description("The control ID of an IDataSource that will be used as the data source.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property DataSourceID() As System.String
            Get
                Return CType(Me.GetProperty("DataSourceID"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("DataSourceID", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The control ID of an IDataSource that will be used as the data source. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the DataSourceID property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeDataSourceID() As Boolean
            Return Me.ShouldSerialize("DataSourceID")
        End Function


        ''' <summary>
        ''' Resets the The control ID of an IDataSource that will be used as the data source. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the DataSourceID property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetDataSourceID()
            Me.Reset("DataSourceID")
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property DataSourceObject As System.Web.UI.IDataSource
            Get
                Return CType(Me.GetProperty("DataSourceObject"), System.Web.UI.IDataSource)
            End Get
        End Property


        ''' <summary>
        ''' The data source that is used to populate the items in the list.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Data")> _
        <System.ComponentModel.Description("The data source that is used to populate the items in the list.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public Property DataSource() As System.Object
            Get
                Return CType(Me.GetProperty("DataSource"), System.Object)
            End Get
            Set(value As System.Object)
                Me.SetProperty("DataSource", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The data source that is used to populate the items in the list. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the DataSource property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeDataSource() As Boolean
            Return Me.ShouldSerialize("DataSource")
        End Function


        ''' <summary>
        ''' Resets the The data source that is used to populate the items in the list. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the DataSource property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetDataSource()
            Me.Reset("DataSource")
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property SupportsDisabledAttribute As System.Boolean
            Get
                Return CType(Me.GetProperty("SupportsDisabledAttribute"), System.Boolean)
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



        ' ''' <summary>
        '      ''' Raised before the data bound control is data binding using data methods.
        '      ''' </summary>
        '      <System.ComponentModel.Category("Data")> _
        '      <System.ComponentModel.Description("Raised before the data bound control is data binding using data methods.")> _
        '      <System.ComponentModel.Browsable(true)> _
        '      Public Custom Event CreatingModelDataSource As System.Web.UI.WebControls.CreatingModelDataSourceEventHandler

        '	AddHandler(ByVal value As System.Web.UI.WebControls.CreatingModelDataSourceEventHandler)
        '		Me.AddEventHandler("CreatingModelDataSource", value)
        '          End AddHandler

        '          RemoveHandler(ByVal value As System.Web.UI.WebControls.CreatingModelDataSourceEventHandler)
        '		Me.RemoveEventHandler("CreatingModelDataSource", value)
        '          End RemoveHandler

        '          RaiseEvent(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CreatingModelDataSourceEventArgs)
        '		If (Not (Me.Events("CreatingModelDataSource")) Is Nothing) Then
        '               Dim arrDelegate As List(Of System.Delegate) = Me.Events("CreatingModelDataSource")
        '			For Each objDelegate As System.Delegate In arrDelegate
        '				objDelegate.DynamicInvoke(New Object() {sender, e})
        '			Next
        '		End If
        '	End RaiseEvent

        '      End Event



        ' ''' <summary>
        '      ''' Occurs before model methods are invoked for data operations. Handle this event if the model methods are defined on a custom type other than the code behind file.
        '      ''' </summary>
        '      <System.ComponentModel.Category("Data")> _
        '      <System.ComponentModel.Description("Occurs before model methods are invoked for data operations. Handle this event if the model methods are defined on a custom type other than the code behind file.")> _
        '      <System.ComponentModel.Browsable(true)> _
        '      Public Custom Event CallingDataMethods As System.Web.UI.WebControls.CallingDataMethodsEventHandler

        '	AddHandler(ByVal value As System.Web.UI.WebControls.CallingDataMethodsEventHandler)
        '		Me.AddEventHandler("CallingDataMethods", value)
        '          End AddHandler

        '          RemoveHandler(ByVal value As System.Web.UI.WebControls.CallingDataMethodsEventHandler)
        '		Me.RemoveEventHandler("CallingDataMethods", value)
        '          End RemoveHandler

        '          RaiseEvent(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.CallingDataMethodsEventArgs)
        '		If (Not (Me.Events("CallingDataMethods")) Is Nothing) Then
        '               Dim arrDelegate As List(Of System.Delegate) = Me.Events("CallingDataMethods")
        '			For Each objDelegate As System.Delegate In arrDelegate
        '				objDelegate.DynamicInvoke(New Object() {sender, e})
        '			Next
        '		End If
        '	End RaiseEvent

        '      End Event



        ''' <summary>
        ''' Fires after the control has been databound.
        ''' </summary>
        <System.ComponentModel.Category("Data")> _
        <System.ComponentModel.Description("Fires after the control has been databound.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event DataBound As System.EventHandler

            AddHandler(ByVal value As System.EventHandler)
                Me.AddEventHandler("DataBound", value)
            End AddHandler

            RemoveHandler(ByVal value As System.EventHandler)
                Me.RemoveEventHandler("DataBound", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)
                If (Not (Me.Events("DataBound")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("DataBound")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



#End Region

    End Class
End Namespace