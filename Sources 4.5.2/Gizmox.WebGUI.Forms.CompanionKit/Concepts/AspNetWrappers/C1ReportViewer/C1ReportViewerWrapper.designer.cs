namespace ComponentOneSampleAppsCS
{
    partial class C1ReportViewerWrapper
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
                return typeof(C1.Web.Wijmo.Controls.C1ReportViewer.C1ReportViewer);
            }
        }
        
        /// <summary>
        /// Get hosted control typed instance
        /// </summary>
        protected C1.Web.Wijmo.Controls.C1ReportViewer.C1ReportViewer HostedC1ReportViewer
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1ReportViewer.C1ReportViewer)this.HostedControl;
            }
        }
        
        		
		/// <summary>
		/// Name for the exported file.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Name for the exported file.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String ExportedFileName
        {
            get
            {
                return (System.String)this.GetProperty("ExportedFileName");
            }
            set
            {
                this.SetProperty("ExportedFileName", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Name for the exported file. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ExportedFileName property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeExportedFileName()
        {
			return this.ShouldSerialize("ExportedFileName");
        }
        
        
        /// <summary>
		/// Resets the Name for the exported file. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ExportedFileName property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetExportedFileName()
        {
			this.Reset("ExportedFileName");
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
		/// Use the Localization property in order to customize localization strings.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Use the Localization property in order to customize localization strings.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public C1.Web.Wijmo.Controls.C1ReportViewer.LocalizationOption Localization
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1ReportViewer.LocalizationOption)this.GetProperty("Localization");
            }
        }
        
		
		/// <summary>
		/// Indicates whether to automatically generate and show parameter input forms for reports with parameters. The default is true.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("Indicates whether to automatically generate and show parameter input forms for reports with parameters. The default is true.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowParameterInputForm
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowParameterInputForm");
            }
            set
            {
                this.SetProperty("ShowParameterInputForm", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Indicates whether to automatically generate and show parameter input forms for reports with parameters. The default is true. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowParameterInputForm property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowParameterInputForm()
        {
			return this.ShouldSerialize("ShowParameterInputForm");
        }
        
        
        /// <summary>
		/// Resets the Indicates whether to automatically generate and show parameter input forms for reports with parameters. The default is true. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowParameterInputForm property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowParameterInputForm()
        {
			this.Reset("ShowParameterInputForm");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public System.Collections.Generic.Dictionary<System.String, System.Object> ExtraOptions
        {
            get
            {
                return (System.Collections.Generic.Dictionary<System.String, System.Object>)this.GetProperty("ExtraOptions");
            }
        }
        
		
		/// <summary>
		/// Specifies the set of tools that will be available for the user.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Specifies the set of tools that will be available for the user.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public C1.Web.Wijmo.Controls.C1ReportViewer.AvailableReportTools AvailableTools
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1ReportViewer.AvailableReportTools)this.GetProperty("AvailableTools");
            }
            set
            {
                this.SetProperty("AvailableTools", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Specifies the set of tools that will be available for the user. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AvailableTools property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAvailableTools()
        {
			return this.ShouldSerialize("AvailableTools");
        }
        
        
        /// <summary>
		/// Resets the Specifies the set of tools that will be available for the user. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AvailableTools property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAvailableTools()
        {
			this.Reset("AvailableTools");
        }
        
		
		/// <summary>
		/// The default tool that will be expanded in the tools panel.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("The default tool that will be expanded in the tools panel.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public C1.Web.Wijmo.Controls.C1ReportViewer.ReportTools ExpandedTool
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1ReportViewer.ReportTools)this.GetProperty("ExpandedTool");
            }
            set
            {
                this.SetProperty("ExpandedTool", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The default tool that will be expanded in the tools panel. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ExpandedTool property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeExpandedTool()
        {
			return this.ShouldSerialize("ExpandedTool");
        }
        
        
        /// <summary>
		/// Resets the The default tool that will be expanded in the tools panel. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ExpandedTool property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetExpandedTool()
        {
			this.Reset("ExpandedTool");
        }
        
		
		/// <summary>
		/// Specifies whether the tools panel will be collapsed.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Specifies whether the tools panel will be collapsed.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean CollapseToolsPanel
        {
            get
            {
                return (System.Boolean)this.GetProperty("CollapseToolsPanel");
            }
            set
            {
                this.SetProperty("CollapseToolsPanel", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Specifies whether the tools panel will be collapsed. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the CollapseToolsPanel property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeCollapseToolsPanel()
        {
			return this.ShouldSerialize("CollapseToolsPanel");
        }
        
        
        /// <summary>
		/// Resets the Specifies whether the tools panel will be collapsed. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the CollapseToolsPanel property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetCollapseToolsPanel()
        {
			this.Reset("CollapseToolsPanel");
        }
        
		
		/// <summary>
		/// A value indicates the location of the splitter, in pixels, from the left edge of the splitter.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("A value indicates the location of the splitter, in pixels, from the left edge of the splitter.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 SplitterDistance
        {
            get
            {
                return (System.Int32)this.GetProperty("SplitterDistance");
            }
            set
            {
                this.SetProperty("SplitterDistance", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if A value indicates the location of the splitter, in pixels, from the left edge of the splitter. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the SplitterDistance property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeSplitterDistance()
        {
			return this.ShouldSerialize("SplitterDistance");
        }
        
        
        /// <summary>
		/// Resets the A value indicates the location of the splitter, in pixels, from the left edge of the splitter. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the SplitterDistance property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetSplitterDistance()
        {
			this.Reset("SplitterDistance");
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
		/// The name of the file with report.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("The name of the file with report.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String FileName
        {
            get
            {
                return (System.String)this.GetProperty("FileName");
            }
            set
            {
                this.SetProperty("FileName", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The name of the file with report. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the FileName property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeFileName()
        {
			return this.ShouldSerialize("FileName");
        }
        
        
        /// <summary>
		/// Resets the The name of the file with report. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the FileName property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetFileName()
        {
			this.Reset("FileName");
        }
        
		
		/// <summary>
		/// The name of the report to view.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("The name of the report to view.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String ReportName
        {
            get
            {
                return (System.String)this.GetProperty("ReportName");
            }
            set
            {
                this.SetProperty("ReportName", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The name of the report to view. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ReportName property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeReportName()
        {
			return this.ShouldSerialize("ReportName");
        }
        
        
        /// <summary>
		/// Resets the The name of the report to view. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ReportName property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetReportName()
        {
			this.Reset("ReportName");
        }
        
		
		/// <summary>
		/// The report cache parameters.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("The report cache parameters.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public C1.Web.Wijmo.Controls.C1ReportViewer.ReportService.ReportCache Cache
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1ReportViewer.ReportService.ReportCache)this.GetProperty("Cache");
            }
        }
        
		
		/// <summary>
		/// The relative path to folder that will be used to store generated report data.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("The relative path to folder that will be used to store generated report data.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String ReportsFolderPath
        {
            get
            {
                return (System.String)this.GetProperty("ReportsFolderPath");
            }
            set
            {
                this.SetProperty("ReportsFolderPath", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The relative path to folder that will be used to store generated report data. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ReportsFolderPath property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeReportsFolderPath()
        {
			return this.ShouldSerialize("ReportsFolderPath");
        }
        
        
        /// <summary>
		/// Resets the The relative path to folder that will be used to store generated report data. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ReportsFolderPath property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetReportsFolderPath()
        {
			this.Reset("ReportsFolderPath");
        }
        
		
		/// <summary>
		/// Specifies whether the viewer must show document pages individually (with scrollbars covering the current page only) or continuously (with scrollbars covering the whole document).
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Specifies whether the viewer must show document pages individually (with scrollbars covering the current page only) or continuously (with scrollbars covering the whole document).")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean PagedView
        {
            get
            {
                return (System.Boolean)this.GetProperty("PagedView");
            }
            set
            {
                this.SetProperty("PagedView", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Specifies whether the viewer must show document pages individually (with scrollbars covering the current page only) or continuously (with scrollbars covering the whole document). should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the PagedView property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializePagedView()
        {
			return this.ShouldSerialize("PagedView");
        }
        
        
        /// <summary>
		/// Resets the Specifies whether the viewer must show document pages individually (with scrollbars covering the current page only) or continuously (with scrollbars covering the whole document). property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the PagedView property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetPagedView()
        {
			this.Reset("PagedView");
        }
        
		
		/// <summary>
		/// Specifies whether the viewer must be shown in full screen mode.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Specifies whether the viewer must be shown in full screen mode.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean FullScreen
        {
            get
            {
                return (System.Boolean)this.GetProperty("FullScreen");
            }
            set
            {
                this.SetProperty("FullScreen", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Specifies whether the viewer must be shown in full screen mode. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the FullScreen property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeFullScreen()
        {
			return this.ShouldSerialize("FullScreen");
        }
        
        
        /// <summary>
		/// Resets the Specifies whether the viewer must be shown in full screen mode. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the FullScreen property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetFullScreen()
        {
			this.Reset("FullScreen");
        }
        
		
		/// <summary>
		/// The URL to the report service.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("The URL to the report service.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String ReportServiceUrl
        {
            get
            {
                return (System.String)this.GetProperty("ReportServiceUrl");
            }
            set
            {
                this.SetProperty("ReportServiceUrl", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The URL to the report service. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ReportServiceUrl property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeReportServiceUrl()
        {
			return this.ShouldSerialize("ReportServiceUrl");
        }
        
        
        /// <summary>
		/// Resets the The URL to the report service. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ReportServiceUrl property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetReportServiceUrl()
        {
			this.Reset("ReportServiceUrl");
        }
        
		
		/// <summary>
		/// Indicates whether the toolbar will be visible.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Indicates whether the toolbar will be visible.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ToolBarVisible
        {
            get
            {
                return (System.Boolean)this.GetProperty("ToolBarVisible");
            }
            set
            {
                this.SetProperty("ToolBarVisible", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Indicates whether the toolbar will be visible. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ToolBarVisible property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeToolBarVisible()
        {
			return this.ShouldSerialize("ToolBarVisible");
        }
        
        
        /// <summary>
		/// Resets the Indicates whether the toolbar will be visible. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ToolBarVisible property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetToolBarVisible()
        {
			this.Reset("ToolBarVisible");
        }
        
		
		/// <summary>
		/// Indicates whether the status bar will be visible.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Appearance")]
        [System.ComponentModel.Description("Indicates whether the status bar will be visible.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean StatusBarVisible
        {
            get
            {
                return (System.Boolean)this.GetProperty("StatusBarVisible");
            }
            set
            {
                this.SetProperty("StatusBarVisible", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Indicates whether the status bar will be visible. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the StatusBarVisible property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeStatusBarVisible()
        {
			return this.ShouldSerialize("StatusBarVisible");
        }
        
        
        /// <summary>
		/// Resets the Indicates whether the status bar will be visible. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the StatusBarVisible property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetStatusBarVisible()
        {
			this.Reset("StatusBarVisible");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public C1.Web.Wijmo.Controls.C1ReportViewer.C1ReportViewerToolbar ToolBar
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1ReportViewer.C1ReportViewerToolbar)this.GetProperty("ToolBar");
            }
        }
        
		
		/// <summary>
		/// The page zoom value. Accepts named zoom values like "actual size", "fit page", "fit width", "fit height" or value in percentages, e.g. "50%", "70%".
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("The page zoom value. Accepts named zoom values like \"actual size\", \"fit page\", \"fit width\", \"fit height\" or value in percentages, e.g. \"50%\", \"70%\".")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String Zoom
        {
            get
            {
                return (System.String)this.GetProperty("Zoom");
            }
            set
            {
                this.SetProperty("Zoom", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if The page zoom value. Accepts named zoom values like "actual size", "fit page", "fit width", "fit height" or value in percentages, e.g. "50%", "70%". should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the Zoom property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeZoom()
        {
			return this.ShouldSerialize("Zoom");
        }
        
        
        /// <summary>
		/// Resets the The page zoom value. Accepts named zoom values like "actual size", "fit page", "fit width", "fit height" or value in percentages, e.g. "50%", "70%". property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the Zoom property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetZoom()
        {
			this.Reset("Zoom");
        }
        
		
		/// <summary>
		/// The width of the control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Layout")]
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
        [System.ComponentModel.Category("Layout")]
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
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public System.Globalization.CultureInfo UsedCulture
        {
            get
            {
                return (System.Globalization.CultureInfo)this.GetProperty("UsedCulture");
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
