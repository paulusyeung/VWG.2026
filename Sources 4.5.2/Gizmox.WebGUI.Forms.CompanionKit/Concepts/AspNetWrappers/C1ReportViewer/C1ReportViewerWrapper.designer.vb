Namespace ComponentOneSampleAppsVB
    Partial Class C1ReportViewerWrapper

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
                Return GetType(C1.Web.Wijmo.Controls.C1ReportViewer.C1ReportViewer)
            End Get
        End Property

        ''' <summary>
        ''' Get hosted control typed instance
        ''' </summary>
        Protected ReadOnly Property HostedC1ReportViewer As C1.Web.Wijmo.Controls.C1ReportViewer.C1ReportViewer
            Get
                Return CType(Me.HostedControl, C1.Web.Wijmo.Controls.C1ReportViewer.C1ReportViewer)
            End Get
        End Property


        ''' <summary>
        ''' Name for the exported file.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("Name for the exported file.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ExportedFileName() As System.String
            Get
                Return CType(Me.GetProperty("ExportedFileName"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("ExportedFileName", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Name for the exported file. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ExportedFileName property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeExportedFileName() As Boolean
            Return Me.ShouldSerialize("ExportedFileName")
        End Function


        ''' <summary>
        ''' Resets the Name for the exported file. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ExportedFileName property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetExportedFileName()
            Me.Reset("ExportedFileName")
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
        ''' Use the Localization property in order to customize localization strings.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Use the Localization property in order to customize localization strings.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Localization As C1.Web.Wijmo.Controls.C1ReportViewer.LocalizationOption
            Get
                Return CType(Me.GetProperty("Localization"), C1.Web.Wijmo.Controls.C1ReportViewer.LocalizationOption)
            End Get
        End Property


        ''' <summary>
        ''' Indicates whether to automatically generate and show parameter input forms for reports with parameters. The default is true.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("Indicates whether to automatically generate and show parameter input forms for reports with parameters. The default is true.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ShowParameterInputForm() As System.Boolean
            Get
                Return CType(Me.GetProperty("ShowParameterInputForm"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("ShowParameterInputForm", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Indicates whether to automatically generate and show parameter input forms for reports with parameters. The default is true. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ShowParameterInputForm property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeShowParameterInputForm() As Boolean
            Return Me.ShouldSerialize("ShowParameterInputForm")
        End Function


        ''' <summary>
        ''' Resets the Indicates whether to automatically generate and show parameter input forms for reports with parameters. The default is true. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ShowParameterInputForm property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetShowParameterInputForm()
            Me.Reset("ShowParameterInputForm")
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property ExtraOptions As System.Collections.Generic.Dictionary(Of System.String, System.Object)
            Get
                Return CType(Me.GetProperty("ExtraOptions"), System.Collections.Generic.Dictionary(Of System.String, System.Object))
            End Get
        End Property


        ''' <summary>
        ''' Specifies the set of tools that will be available for the user.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Specifies the set of tools that will be available for the user.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AvailableTools() As C1.Web.Wijmo.Controls.C1ReportViewer.AvailableReportTools
            Get
                Return CType(Me.GetProperty("AvailableTools"), C1.Web.Wijmo.Controls.C1ReportViewer.AvailableReportTools)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1ReportViewer.AvailableReportTools)
                Me.SetProperty("AvailableTools", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Specifies the set of tools that will be available for the user. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AvailableTools property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAvailableTools() As Boolean
            Return Me.ShouldSerialize("AvailableTools")
        End Function


        ''' <summary>
        ''' Resets the Specifies the set of tools that will be available for the user. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AvailableTools property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAvailableTools()
            Me.Reset("AvailableTools")
        End Sub


        ''' <summary>
        ''' The default tool that will be expanded in the tools panel.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("The default tool that will be expanded in the tools panel.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ExpandedTool() As C1.Web.Wijmo.Controls.C1ReportViewer.ReportTools
            Get
                Return CType(Me.GetProperty("ExpandedTool"), C1.Web.Wijmo.Controls.C1ReportViewer.ReportTools)
            End Get
            Set(value As C1.Web.Wijmo.Controls.C1ReportViewer.ReportTools)
                Me.SetProperty("ExpandedTool", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The default tool that will be expanded in the tools panel. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ExpandedTool property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeExpandedTool() As Boolean
            Return Me.ShouldSerialize("ExpandedTool")
        End Function


        ''' <summary>
        ''' Resets the The default tool that will be expanded in the tools panel. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ExpandedTool property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetExpandedTool()
            Me.Reset("ExpandedTool")
        End Sub


        ''' <summary>
        ''' Specifies whether the tools panel will be collapsed.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Specifies whether the tools panel will be collapsed.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property CollapseToolsPanel() As System.Boolean
            Get
                Return CType(Me.GetProperty("CollapseToolsPanel"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("CollapseToolsPanel", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Specifies whether the tools panel will be collapsed. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the CollapseToolsPanel property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeCollapseToolsPanel() As Boolean
            Return Me.ShouldSerialize("CollapseToolsPanel")
        End Function


        ''' <summary>
        ''' Resets the Specifies whether the tools panel will be collapsed. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the CollapseToolsPanel property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetCollapseToolsPanel()
            Me.Reset("CollapseToolsPanel")
        End Sub


        ''' <summary>
        ''' A value indicates the location of the splitter, in pixels, from the left edge of the splitter.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("A value indicates the location of the splitter, in pixels, from the left edge of the splitter.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property SplitterDistance() As System.Int32
            Get
                Return CType(Me.GetProperty("SplitterDistance"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("SplitterDistance", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if A value indicates the location of the splitter, in pixels, from the left edge of the splitter. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the SplitterDistance property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeSplitterDistance() As Boolean
            Return Me.ShouldSerialize("SplitterDistance")
        End Function


        ''' <summary>
        ''' Resets the A value indicates the location of the splitter, in pixels, from the left edge of the splitter. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the SplitterDistance property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetSplitterDistance()
            Me.Reset("SplitterDistance")
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
        ''' The name of the file with report.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("The name of the file with report.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property FileName() As System.String
            Get
                Return CType(Me.GetProperty("FileName"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("FileName", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The name of the file with report. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the FileName property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeFileName() As Boolean
            Return Me.ShouldSerialize("FileName")
        End Function


        ''' <summary>
        ''' Resets the The name of the file with report. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the FileName property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetFileName()
            Me.Reset("FileName")
        End Sub


        ''' <summary>
        ''' The name of the report to view.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("The name of the report to view.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ReportName() As System.String
            Get
                Return CType(Me.GetProperty("ReportName"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("ReportName", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The name of the report to view. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ReportName property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeReportName() As Boolean
            Return Me.ShouldSerialize("ReportName")
        End Function


        ''' <summary>
        ''' Resets the The name of the report to view. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ReportName property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetReportName()
            Me.Reset("ReportName")
        End Sub


        ''' <summary>
        ''' The report cache parameters.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("The report cache parameters.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Cache As C1.Web.Wijmo.Controls.C1ReportViewer.ReportService.ReportCache
            Get
                Return CType(Me.GetProperty("Cache"), C1.Web.Wijmo.Controls.C1ReportViewer.ReportService.ReportCache)
            End Get
        End Property


        ''' <summary>
        ''' The relative path to folder that will be used to store generated report data.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("The relative path to folder that will be used to store generated report data.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ReportsFolderPath() As System.String
            Get
                Return CType(Me.GetProperty("ReportsFolderPath"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("ReportsFolderPath", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The relative path to folder that will be used to store generated report data. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ReportsFolderPath property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeReportsFolderPath() As Boolean
            Return Me.ShouldSerialize("ReportsFolderPath")
        End Function


        ''' <summary>
        ''' Resets the The relative path to folder that will be used to store generated report data. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ReportsFolderPath property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetReportsFolderPath()
            Me.Reset("ReportsFolderPath")
        End Sub


        ''' <summary>
        ''' Specifies whether the viewer must show document pages individually (with scrollbars covering the current page only) or continuously (with scrollbars covering the whole document).
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Specifies whether the viewer must show document pages individually (with scrollbars covering the current page only) or continuously (with scrollbars covering the whole document).")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property PagedView() As System.Boolean
            Get
                Return CType(Me.GetProperty("PagedView"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("PagedView", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Specifies whether the viewer must show document pages individually (with scrollbars covering the current page only) or continuously (with scrollbars covering the whole document). should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the PagedView property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializePagedView() As Boolean
            Return Me.ShouldSerialize("PagedView")
        End Function


        ''' <summary>
        ''' Resets the Specifies whether the viewer must show document pages individually (with scrollbars covering the current page only) or continuously (with scrollbars covering the whole document). property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the PagedView property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetPagedView()
            Me.Reset("PagedView")
        End Sub


        ''' <summary>
        ''' Specifies whether the viewer must be shown in full screen mode.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Specifies whether the viewer must be shown in full screen mode.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property FullScreen() As System.Boolean
            Get
                Return CType(Me.GetProperty("FullScreen"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("FullScreen", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Specifies whether the viewer must be shown in full screen mode. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the FullScreen property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeFullScreen() As Boolean
            Return Me.ShouldSerialize("FullScreen")
        End Function


        ''' <summary>
        ''' Resets the Specifies whether the viewer must be shown in full screen mode. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the FullScreen property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetFullScreen()
            Me.Reset("FullScreen")
        End Sub


        ''' <summary>
        ''' The URL to the report service.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("The URL to the report service.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ReportServiceUrl() As System.String
            Get
                Return CType(Me.GetProperty("ReportServiceUrl"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("ReportServiceUrl", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The URL to the report service. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ReportServiceUrl property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeReportServiceUrl() As Boolean
            Return Me.ShouldSerialize("ReportServiceUrl")
        End Function


        ''' <summary>
        ''' Resets the The URL to the report service. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ReportServiceUrl property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetReportServiceUrl()
            Me.Reset("ReportServiceUrl")
        End Sub


        ''' <summary>
        ''' Indicates whether the toolbar will be visible.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Indicates whether the toolbar will be visible.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ToolBarVisible() As System.Boolean
            Get
                Return CType(Me.GetProperty("ToolBarVisible"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("ToolBarVisible", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Indicates whether the toolbar will be visible. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ToolBarVisible property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeToolBarVisible() As Boolean
            Return Me.ShouldSerialize("ToolBarVisible")
        End Function


        ''' <summary>
        ''' Resets the Indicates whether the toolbar will be visible. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ToolBarVisible property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetToolBarVisible()
            Me.Reset("ToolBarVisible")
        End Sub


        ''' <summary>
        ''' Indicates whether the status bar will be visible.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Appearance")> _
        <System.ComponentModel.Description("Indicates whether the status bar will be visible.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property StatusBarVisible() As System.Boolean
            Get
                Return CType(Me.GetProperty("StatusBarVisible"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("StatusBarVisible", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Indicates whether the status bar will be visible. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the StatusBarVisible property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeStatusBarVisible() As Boolean
            Return Me.ShouldSerialize("StatusBarVisible")
        End Function


        ''' <summary>
        ''' Resets the Indicates whether the status bar will be visible. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the StatusBarVisible property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetStatusBarVisible()
            Me.Reset("StatusBarVisible")
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property ToolBar As C1.Web.Wijmo.Controls.C1ReportViewer.C1ReportViewerToolbar
            Get
                Return CType(Me.GetProperty("ToolBar"), C1.Web.Wijmo.Controls.C1ReportViewer.C1ReportViewerToolbar)
            End Get
        End Property


        ''' <summary>
        ''' The page zoom value. Accepts named zoom values like "actual size", "fit page", "fit width", "fit height" or value in percentages, e.g. "50%", "70%".
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("The page zoom value. Accepts named zoom values like ""actual size"", ""fit page"", ""fit width"", ""fit height"" or value in percentages, e.g. ""50%"", ""70%"".")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property Zoom() As System.String
            Get
                Return CType(Me.GetProperty("Zoom"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("Zoom", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if The page zoom value. Accepts named zoom values like "actual size", "fit page", "fit width", "fit height" or value in percentages, e.g. "50%", "70%". should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Zoom property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeZoom() As Boolean
            Return Me.ShouldSerialize("Zoom")
        End Function


        ''' <summary>
        ''' Resets the The page zoom value. Accepts named zoom values like "actual size", "fit page", "fit width", "fit height" or value in percentages, e.g. "50%", "70%". property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the Zoom property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetZoom()
            Me.Reset("Zoom")
        End Sub


        ''' <summary>
        ''' The width of the control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Layout")> _
        <System.ComponentModel.Description("The width of the control.")> _
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
        ''' Returns a boolean indicating if The width of the control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the Width property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHostedWidth() As Boolean
            Return Me.ShouldSerialize("Width")
        End Function


        ''' <summary>
        ''' Resets the The width of the control. property to its default value.
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
        <System.ComponentModel.Category("Layout")> _
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
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property UsedCulture As System.Globalization.CultureInfo
            Get
                Return CType(Me.GetProperty("UsedCulture"), System.Globalization.CultureInfo)
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
