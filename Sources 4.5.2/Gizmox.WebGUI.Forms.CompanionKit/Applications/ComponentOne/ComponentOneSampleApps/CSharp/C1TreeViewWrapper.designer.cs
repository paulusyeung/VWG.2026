namespace Gizmox.WebGUI.Forms.CompanionKit.ComponentOneSampleAppsCS
{
	partial class C1TreeViewWrapper
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
                return typeof(C1.Web.Wijmo.Controls.C1TreeView.C1TreeView);
            }
        }
        
        /// <summary>
        /// Get hosted control typed instance
        /// </summary>
        protected C1.Web.Wijmo.Controls.C1TreeView.C1TreeView HostedC1TreeView
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1TreeView.C1TreeView)this.HostedControl;
            }
        }
        
        		
		/// <summary>
		/// Allow to TreeView nodes to perform drag .
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Allow to TreeView nodes to perform drag .")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean HostedAllowDrag
        {
            get
            {
                return (System.Boolean)this.GetProperty("AllowDrag");
            }
            set
            {
                this.SetProperty("AllowDrag", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Allow to TreeView nodes to perform drag . should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AllowDrag property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHostedAllowDrag()
        {
			return this.ShouldSerialize("AllowDrag");
        }
        
        
        /// <summary>
		/// Resets the Allow to TreeView nodes to perform drag . property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AllowDrag property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHostedAllowDrag()
        {
			this.Reset("AllowDrag");
        }
        
		
		/// <summary>
		/// Allow to TreeView nodes to perform drop .
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Allow to TreeView nodes to perform drop .")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean HostedAllowDrop
        {
            get
            {
                return (System.Boolean)this.GetProperty("AllowDrop");
            }
            set
            {
                this.SetProperty("AllowDrop", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Allow to TreeView nodes to perform drop . should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AllowDrop property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeHostedAllowDrop()
        {
			return this.ShouldSerialize("AllowDrop");
        }
        
        
        /// <summary>
		/// Resets the Allow to TreeView nodes to perform drop . property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AllowDrop property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetHostedAllowDrop()
        {
			this.Reset("AllowDrop");
        }
        
		
		/// <summary>
		/// Allow nodes to be edited at run time.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Allow nodes to be edited at run time.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AllowEdit
        {
            get
            {
                return (System.Boolean)this.GetProperty("AllowEdit");
            }
            set
            {
                this.SetProperty("AllowEdit", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Allow nodes to be edited at run time. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AllowEdit property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAllowEdit()
        {
			return this.ShouldSerialize("AllowEdit");
        }
        
        
        /// <summary>
		/// Resets the Allow nodes to be edited at run time. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AllowEdit property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAllowEdit()
        {
			this.Reset("AllowEdit");
        }
        
		
		/// <summary>
		/// Allow nodes to be sorted at run time.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Allow nodes to be sorted at run time.")]
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
		/// Returns a boolean indicating if Allow nodes to be sorted at run time. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AllowSorting property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAllowSorting()
        {
			return this.ShouldSerialize("AllowSorting");
        }
        
        
        /// <summary>
		/// Resets the Allow nodes to be sorted at run time. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AllowSorting property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAllowSorting()
        {
			this.Reset("AllowSorting");
        }
        
		
		/// <summary>
		/// Allow TriState of CheckBox
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Allow TriState of CheckBox")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AllowTriState
        {
            get
            {
                return (System.Boolean)this.GetProperty("AllowTriState");
            }
            set
            {
                this.SetProperty("AllowTriState", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Allow TriState of CheckBox should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AllowTriState property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAllowTriState()
        {
			return this.ShouldSerialize("AllowTriState");
        }
        
        
        /// <summary>
		/// Resets the Allow TriState of CheckBox property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AllowTriState property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAllowTriState()
        {
			this.Reset("AllowTriState");
        }
        
		
		/// <summary>
		/// Allow sub nodes to be checked on parent node check.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Allow sub nodes to be checked on parent node check.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AutoCheckNodes
        {
            get
            {
                return (System.Boolean)this.GetProperty("AutoCheckNodes");
            }
            set
            {
                this.SetProperty("AutoCheckNodes", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Allow sub nodes to be checked on parent node check. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AutoCheckNodes property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAutoCheckNodes()
        {
			return this.ShouldSerialize("AutoCheckNodes");
        }
        
        
        /// <summary>
		/// Resets the Allow sub nodes to be checked on parent node check. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AutoCheckNodes property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAutoCheckNodes()
        {
			this.Reset("AutoCheckNodes");
        }
        
		
		/// <summary>
		/// If this option is set to true, expanded node will be collapsed if other node is expanded.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("If this option is set to true, expanded node will be collapsed if other node is expanded.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AutoCollapse
        {
            get
            {
                return (System.Boolean)this.GetProperty("AutoCollapse");
            }
            set
            {
                this.SetProperty("AutoCollapse", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if If this option is set to true, expanded node will be collapsed if other node is expanded. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AutoCollapse property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAutoCollapse()
        {
			return this.ShouldSerialize("AutoCollapse");
        }
        
        
        /// <summary>
		/// Resets the If this option is set to true, expanded node will be collapsed if other node is expanded. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AutoCollapse property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAutoCollapse()
        {
			this.Reset("AutoCollapse");
        }
        
		
		/// <summary>
		/// Allow nodes to use hover for Expand or Collapse elements.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Allow nodes to use hover for Expand or Collapse elements.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ExpandCollapseHoverUsed
        {
            get
            {
                return (System.Boolean)this.GetProperty("ExpandCollapseHoverUsed");
            }
            set
            {
                this.SetProperty("ExpandCollapseHoverUsed", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Allow nodes to use hover for Expand or Collapse elements. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ExpandCollapseHoverUsed property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeExpandCollapseHoverUsed()
        {
			return this.ShouldSerialize("ExpandCollapseHoverUsed");
        }
        
        
        /// <summary>
		/// Resets the Allow nodes to use hover for Expand or Collapse elements. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ExpandCollapseHoverUsed property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetExpandCollapseHoverUsed()
        {
			this.Reset("ExpandCollapseHoverUsed");
        }
        
		
		/// <summary>
		/// Allow the check box to be shown on the nodes.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Allow the check box to be shown on the nodes.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowCheckBoxes
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowCheckBoxes");
            }
            set
            {
                this.SetProperty("ShowCheckBoxes", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Allow the check box to be shown on the nodes. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowCheckBoxes property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowCheckBoxes()
        {
			return this.ShouldSerialize("ShowCheckBoxes");
        }
        
        
        /// <summary>
		/// Resets the Allow the check box to be shown on the nodes. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowCheckBoxes property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowCheckBoxes()
        {
			this.Reset("ShowCheckBoxes");
        }
        
		
		/// <summary>
		/// Allow nodes to be expanded or collapsed.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Allow nodes to be expanded or collapsed.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean ShowExpandCollapse
        {
            get
            {
                return (System.Boolean)this.GetProperty("ShowExpandCollapse");
            }
            set
            {
                this.SetProperty("ShowExpandCollapse", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Allow nodes to be expanded or collapsed. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ShowExpandCollapse property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeShowExpandCollapse()
        {
			return this.ShouldSerialize("ShowExpandCollapse");
        }
        
        
        /// <summary>
		/// Resets the Allow nodes to be expanded or collapsed. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ShowExpandCollapse property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetShowExpandCollapse()
        {
			this.Reset("ShowExpandCollapse");
        }
        
		
		/// <summary>
		/// Gets or sets the animation effect when the node is expanded.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Gets or sets the animation effect when the node is expanded.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public C1.Web.Wijmo.Controls.Animation ExpandAnimation
        {
            get
            {
                return (C1.Web.Wijmo.Controls.Animation)this.GetProperty("ExpandAnimation");
            }
            set
            {
                this.SetProperty("ExpandAnimation", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets the animation effect when the node is expanded. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ExpandAnimation property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeExpandAnimation()
        {
			return this.ShouldSerialize("ExpandAnimation");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets the animation effect when the node is expanded. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ExpandAnimation property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetExpandAnimation()
        {
			this.Reset("ExpandAnimation");
        }
        
		
		/// <summary>
		/// Gets or sets the animation effect when the node is collapsed.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Gets or sets the animation effect when the node is collapsed.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public C1.Web.Wijmo.Controls.Animation CollapseAnimation
        {
            get
            {
                return (C1.Web.Wijmo.Controls.Animation)this.GetProperty("CollapseAnimation");
            }
            set
            {
                this.SetProperty("CollapseAnimation", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets the animation effect when the node is collapsed. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the CollapseAnimation property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeCollapseAnimation()
        {
			return this.ShouldSerialize("CollapseAnimation");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets the animation effect when the node is collapsed. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the CollapseAnimation property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetCollapseAnimation()
        {
			this.Reset("CollapseAnimation");
        }
        
		
		/// <summary>
		/// Expand delay in milliseconds before child nodes expand.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Expand delay in milliseconds before child nodes expand.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 ExpandDelay
        {
            get
            {
                return (System.Int32)this.GetProperty("ExpandDelay");
            }
            set
            {
                this.SetProperty("ExpandDelay", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Expand delay in milliseconds before child nodes expand. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the ExpandDelay property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeExpandDelay()
        {
			return this.ShouldSerialize("ExpandDelay");
        }
        
        
        /// <summary>
		/// Resets the Expand delay in milliseconds before child nodes expand. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the ExpandDelay property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetExpandDelay()
        {
			this.Reset("ExpandDelay");
        }
        
		
		/// <summary>
		/// Collapse delay in milliseconds before child nodes collapse.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Options")]
        [System.ComponentModel.Description("Collapse delay in milliseconds before child nodes collapse.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 CollapseDelay
        {
            get
            {
                return (System.Int32)this.GetProperty("CollapseDelay");
            }
            set
            {
                this.SetProperty("CollapseDelay", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Collapse delay in milliseconds before child nodes collapse. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the CollapseDelay property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeCollapseDelay()
        {
			return this.ShouldSerialize("CollapseDelay");
        }
        
        
        /// <summary>
		/// Resets the Collapse delay in milliseconds before child nodes collapse. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the CollapseDelay property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetCollapseDelay()
        {
			this.Reset("CollapseDelay");
        }
        
		
		/// <summary>
		/// If specified, the OnClientNodeExpanded client-side event handler is called after a TreeViewNode has been expanded.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("If specified, the OnClientNodeExpanded client-side event handler is called after a TreeViewNode has been expanded.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientNodeExpanded
        {
            get
            {
                return (System.String)this.GetProperty("OnClientNodeExpanded");
            }
            set
            {
                this.SetProperty("OnClientNodeExpanded", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if If specified, the OnClientNodeExpanded client-side event handler is called after a TreeViewNode has been expanded. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientNodeExpanded property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientNodeExpanded()
        {
			return this.ShouldSerialize("OnClientNodeExpanded");
        }
        
        
        /// <summary>
		/// Resets the If specified, the OnClientNodeExpanded client-side event handler is called after a TreeViewNode has been expanded. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientNodeExpanded property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientNodeExpanded()
        {
			this.Reset("OnClientNodeExpanded");
        }
        
		
		/// <summary>
		/// If specified, the OnClientNodeCollapsed client-side event handler is called after a TreeViewNode has been collapsed.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("If specified, the OnClientNodeCollapsed client-side event handler is called after a TreeViewNode has been collapsed.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientNodeCollapsed
        {
            get
            {
                return (System.String)this.GetProperty("OnClientNodeCollapsed");
            }
            set
            {
                this.SetProperty("OnClientNodeCollapsed", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if If specified, the OnClientNodeCollapsed client-side event handler is called after a TreeViewNode has been collapsed. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientNodeCollapsed property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientNodeCollapsed()
        {
			return this.ShouldSerialize("OnClientNodeCollapsed");
        }
        
        
        /// <summary>
		/// Resets the If specified, the OnClientNodeCollapsed client-side event handler is called after a TreeViewNode has been collapsed. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientNodeCollapsed property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientNodeCollapsed()
        {
			this.Reset("OnClientNodeCollapsed");
        }
        
		
		/// <summary>
		/// If specified, the OnClientNodeDragStarted client-side event handler is called before drag is started.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("If specified, the OnClientNodeDragStarted client-side event handler is called before drag is started.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientNodeDragStarted
        {
            get
            {
                return (System.String)this.GetProperty("OnClientNodeDragStarted");
            }
            set
            {
                this.SetProperty("OnClientNodeDragStarted", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if If specified, the OnClientNodeDragStarted client-side event handler is called before drag is started. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientNodeDragStarted property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientNodeDragStarted()
        {
			return this.ShouldSerialize("OnClientNodeDragStarted");
        }
        
        
        /// <summary>
		/// Resets the If specified, the OnClientNodeDragStarted client-side event handler is called before drag is started. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientNodeDragStarted property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientNodeDragStarted()
        {
			this.Reset("OnClientNodeDragStarted");
        }
        
		
		/// <summary>
		/// If specified, the OnClientNodeDragging client-side event handler is called if the user moves the mouse while dragging the node.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("If specified, the OnClientNodeDragging client-side event handler is called if the user moves the mouse while dragging the node.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientNodeDragging
        {
            get
            {
                return (System.String)this.GetProperty("OnClientNodeDragging");
            }
            set
            {
                this.SetProperty("OnClientNodeDragging", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if If specified, the OnClientNodeDragging client-side event handler is called if the user moves the mouse while dragging the node. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientNodeDragging property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientNodeDragging()
        {
			return this.ShouldSerialize("OnClientNodeDragging");
        }
        
        
        /// <summary>
		/// Resets the If specified, the OnClientNodeDragging client-side event handler is called if the user moves the mouse while dragging the node. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientNodeDragging property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientNodeDragging()
        {
			this.Reset("OnClientNodeDragging");
        }
        
		
		/// <summary>
		/// If specified, the OnClientNodeDropped client-side event handler is called before a TreeViewNode has been dropped by user.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("If specified, the OnClientNodeDropped client-side event handler is called before a TreeViewNode has been dropped by user.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientNodeDropped
        {
            get
            {
                return (System.String)this.GetProperty("OnClientNodeDropped");
            }
            set
            {
                this.SetProperty("OnClientNodeDropped", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if If specified, the OnClientNodeDropped client-side event handler is called before a TreeViewNode has been dropped by user. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientNodeDropped property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientNodeDropped()
        {
			return this.ShouldSerialize("OnClientNodeDropped");
        }
        
        
        /// <summary>
		/// Resets the If specified, the OnClientNodeDropped client-side event handler is called before a TreeViewNode has been dropped by user. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientNodeDropped property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientNodeDropped()
        {
			this.Reset("OnClientNodeDropped");
        }
        
		
		/// <summary>
		/// If specified, the OnClientNodeClicked client-side event handler is called after a TreeViewNode has been clicked.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("If specified, the OnClientNodeClicked client-side event handler is called after a TreeViewNode has been clicked.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientNodeClick
        {
            get
            {
                return (System.String)this.GetProperty("OnClientNodeClick");
            }
            set
            {
                this.SetProperty("OnClientNodeClick", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if If specified, the OnClientNodeClicked client-side event handler is called after a TreeViewNode has been clicked. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientNodeClick property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientNodeClick()
        {
			return this.ShouldSerialize("OnClientNodeClick");
        }
        
        
        /// <summary>
		/// Resets the If specified, the OnClientNodeClicked client-side event handler is called after a TreeViewNode has been clicked. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientNodeClick property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientNodeClick()
        {
			this.Reset("OnClientNodeClick");
        }
        
		
		/// <summary>
		/// If specified, the OnClientNodeCheckChanged client-side event handler is called after a TreeViewNode check status has been changed.(If Checkboxes are enabled)
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("If specified, the OnClientNodeCheckChanged client-side event handler is called after a TreeViewNode check status has been changed.(If Checkboxes are enabled)")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientNodeCheckChanged
        {
            get
            {
                return (System.String)this.GetProperty("OnClientNodeCheckChanged");
            }
            set
            {
                this.SetProperty("OnClientNodeCheckChanged", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if If specified, the OnClientNodeCheckChanged client-side event handler is called after a TreeViewNode check status has been changed.(If Checkboxes are enabled) should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientNodeCheckChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientNodeCheckChanged()
        {
			return this.ShouldSerialize("OnClientNodeCheckChanged");
        }
        
        
        /// <summary>
		/// Resets the If specified, the OnClientNodeCheckChanged client-side event handler is called after a TreeViewNode check status has been changed.(If Checkboxes are enabled) property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientNodeCheckChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientNodeCheckChanged()
        {
			this.Reset("OnClientNodeCheckChanged");
        }
        
		
		/// <summary>
		/// If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer over of the node.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer over of the node.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientNodeMouseOver
        {
            get
            {
                return (System.String)this.GetProperty("OnClientNodeMouseOver");
            }
            set
            {
                this.SetProperty("OnClientNodeMouseOver", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer over of the node. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientNodeMouseOver property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientNodeMouseOver()
        {
			return this.ShouldSerialize("OnClientNodeMouseOver");
        }
        
        
        /// <summary>
		/// Resets the If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer over of the node. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientNodeMouseOver property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientNodeMouseOver()
        {
			this.Reset("OnClientNodeMouseOver");
        }
        
		
		/// <summary>
		/// If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer out of the node.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer out of the node.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientNodeMouseOut
        {
            get
            {
                return (System.String)this.GetProperty("OnClientNodeMouseOut");
            }
            set
            {
                this.SetProperty("OnClientNodeMouseOut", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer out of the node. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientNodeMouseOut property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientNodeMouseOut()
        {
			return this.ShouldSerialize("OnClientNodeMouseOut");
        }
        
        
        /// <summary>
		/// Resets the If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer out of the node. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientNodeMouseOut property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientNodeMouseOut()
        {
			this.Reset("OnClientNodeMouseOut");
        }
        
		
		/// <summary>
		/// If specified, the OnClientNodeTextChanged client-side event handler is called after a TreeViewNode's has been edited.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("If specified, the OnClientNodeTextChanged client-side event handler is called after a TreeViewNode\u0027s has been edited.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientNodeTextChanged
        {
            get
            {
                return (System.String)this.GetProperty("OnClientNodeTextChanged");
            }
            set
            {
                this.SetProperty("OnClientNodeTextChanged", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if If specified, the OnClientNodeTextChanged client-side event handler is called after a TreeViewNode's has been edited. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientNodeTextChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientNodeTextChanged()
        {
			return this.ShouldSerialize("OnClientNodeTextChanged");
        }
        
        
        /// <summary>
		/// Resets the If specified, the OnClientNodeTextChanged client-side event handler is called after a TreeViewNode's has been edited. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientNodeTextChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientNodeTextChanged()
        {
			this.Reset("OnClientNodeTextChanged");
        }
        
		
		/// <summary>
		/// If specified, the OnClientSelectedNodesChanged client-side event handler is called after a TreeViewNode has been selected.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Client Events")]
        [System.ComponentModel.Description("If specified, the OnClientSelectedNodesChanged client-side event handler is called after a TreeViewNode has been selected.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.String OnClientSelectedNodeChanged
        {
            get
            {
                return (System.String)this.GetProperty("OnClientSelectedNodeChanged");
            }
            set
            {
                this.SetProperty("OnClientSelectedNodeChanged", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if If specified, the OnClientSelectedNodesChanged client-side event handler is called after a TreeViewNode has been selected. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the OnClientSelectedNodeChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeOnClientSelectedNodeChanged()
        {
			return this.ShouldSerialize("OnClientSelectedNodeChanged");
        }
        
        
        /// <summary>
		/// Resets the If specified, the OnClientSelectedNodesChanged client-side event handler is called after a TreeViewNode has been selected. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the OnClientSelectedNodeChanged property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetOnClientSelectedNodeChanged()
        {
			this.Reset("OnClientSelectedNodeChanged");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]   
        public C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNodeCollection Nodes
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNodeCollection)this.GetProperty("Nodes");
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
        public C1.Web.Wijmo.Controls.C1TreeView.IC1TreeViewNodeCollectionOwner Owner
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1TreeView.IC1TreeViewNodeCollectionOwner)this.GetProperty("Owner");
            }
        }
        
		
		/// <summary>
		/// The unique ID of the control within the page.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("The unique ID of the control within the page.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]   
        public System.String UniqueID
        {
            get
            {
                return (System.String)this.GetProperty("UniqueID");
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
        public System.Collections.Generic.List<C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNode> SelectedNodes
        {
            get
            {
                return (System.Collections.Generic.List<C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNode>)this.GetProperty("SelectedNodes");
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
        public System.Collections.Generic.List<C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNode> CheckedNodes
        {
            get
            {
                return (System.Collections.Generic.List<C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNode>)this.GetProperty("CheckedNodes");
            }
        }
        
		
		/// <summary>
		/// If specified, this template will be applied for all menu items that does not have other defined templates.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("If specified, this template will be applied for all menu items that does not have other defined templates.")]
        [System.ComponentModel.Browsable(false)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public System.Web.UI.ITemplate NodesTemplate
        {
            get
            {
                return (System.Web.UI.ITemplate)this.GetProperty("NodesTemplate");
            }
            set
            {
                this.SetProperty("NodesTemplate", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if If specified, this template will be applied for all menu items that does not have other defined templates. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the NodesTemplate property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeNodesTemplate()
        {
			return this.ShouldSerialize("NodesTemplate");
        }
        
        
        /// <summary>
		/// Resets the If specified, this template will be applied for all menu items that does not have other defined templates. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the NodesTemplate property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetNodesTemplate()
        {
			this.Reset("NodesTemplate");
        }
        
		
		/// <summary>
		/// Sets or retrieves a value that indicates whether or not the control posts back to the server each time a user interacts with the control.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Sets or retrieves a value that indicates whether or not the control posts back to the server each time a user interacts with the control.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean AutoPostBack
        {
            get
            {
                return (System.Boolean)this.GetProperty("AutoPostBack");
            }
            set
            {
                this.SetProperty("AutoPostBack", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Sets or retrieves a value that indicates whether or not the control posts back to the server each time a user interacts with the control. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the AutoPostBack property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeAutoPostBack()
        {
			return this.ShouldSerialize("AutoPostBack");
        }
        
        
        /// <summary>
		/// Resets the Sets or retrieves a value that indicates whether or not the control posts back to the server each time a user interacts with the control. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the AutoPostBack property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetAutoPostBack()
        {
			this.Reset("AutoPostBack");
        }
        
		
		/// <summary>
		/// Gets or sets the value that indicates whether or not Loads on demand is enabled.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Gets or sets the value that indicates whether or not Loads on demand is enabled.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Boolean LoadOnDemand
        {
            get
            {
                return (System.Boolean)this.GetProperty("LoadOnDemand");
            }
            set
            {
                this.SetProperty("LoadOnDemand", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets the value that indicates whether or not Loads on demand is enabled. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the LoadOnDemand property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeLoadOnDemand()
        {
			return this.ShouldSerialize("LoadOnDemand");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets the value that indicates whether or not Loads on demand is enabled. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the LoadOnDemand property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetLoadOnDemand()
        {
			this.Reset("LoadOnDemand");
        }
        
		
		/// <summary>
		/// 
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Misc")]
        [System.ComponentModel.Description("")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]   
        public System.String NodeClickedPostBackReference
        {
            get
            {
                return (System.String)this.GetProperty("NodeClickedPostBackReference");
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
        public System.String NodeCheckChangedPostBackReference
        {
            get
            {
                return (System.String)this.GetProperty("NodeCheckChangedPostBackReference");
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
        public System.String NodeCollapsedPostBackReference
        {
            get
            {
                return (System.String)this.GetProperty("NodeCollapsedPostBackReference");
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
        public System.String NodeExpandedPostBackReference
        {
            get
            {
                return (System.String)this.GetProperty("NodeExpandedPostBackReference");
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
        public System.String NodeDroppedPostBackReference
        {
            get
            {
                return (System.String)this.GetProperty("NodeDroppedPostBackReference");
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
        public System.String NodeTextChangedPostBackReference
        {
            get
            {
                return (System.String)this.GetProperty("NodeTextChangedPostBackReference");
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
        public System.String SelectedNodesChangedPostBackReference
        {
            get
            {
                return (System.String)this.GetProperty("SelectedNodesChangedPostBackReference");
            }
        }
        
		
		/// <summary>
		/// Gets or sets the value that indicates DataBind start level.
		/// </summary>
        /// <returns></returns>    
        [System.ComponentModel.Category("Behavior")]
        [System.ComponentModel.Description("Gets or sets the value that indicates DataBind start level.")]
        [System.ComponentModel.Browsable(true)]    
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public System.Int32 DataBindStartLevel
        {
            get
            {
                return (System.Int32)this.GetProperty("DataBindStartLevel");
            }
            set
            {
                this.SetProperty("DataBindStartLevel", value);
            }
        }
        
        /// <summary>
		/// Returns a boolean indicating if Gets or sets the value that indicates DataBind start level. should be serialized.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine which is to serialize the DataBindStartLevel property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public bool ShouldSerializeDataBindStartLevel()
        {
			return this.ShouldSerialize("DataBindStartLevel");
        }
        
        
        /// <summary>
		/// Resets the Gets or sets the value that indicates DataBind start level. property to its default value.
		/// </summary>
        /// <returns></returns> 
        /// <remarks>This method is used in design time to determine how to reset the DataBindStartLevel property.</remarks> 
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public void ResetDataBindStartLevel()
        {
			this.Reset("DataBindStartLevel");
        }
        
		
		/// <summary>
		/// Data bindings for items in the control.
		/// </summary>
        /// <returns></returns>        
        [System.ComponentModel.Category("Data")]
        [System.ComponentModel.Description("Data bindings for items in the control.")]
        [System.ComponentModel.Browsable(false)] 
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]   
        public C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNodeBindingCollection HostedDataBindings
        {
            get
            {
                return (C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNodeBindingCollection)this.GetProperty("DataBindings");
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
        /// Occurs on the server after the node has been dropped.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs on the server after the node has been dropped.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler NodeDropped
        {
            add
            {
                this.AddEventHandler("NodeDropped", value);
            }
            remove
            {
                this.RemoveEventHandler("NodeDropped", value);
            }
        }
        

        /// <summary>
        /// Occurs on the server after the node is expanded.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs on the server after the node is expanded.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler NodeExpanded
        {
            add
            {
                this.AddEventHandler("NodeExpanded", value);
            }
            remove
            {
                this.RemoveEventHandler("NodeExpanded", value);
            }
        }
        

        /// <summary>
        /// Occurs on the server after the node is collapsed.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs on the server after the node is collapsed.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler NodeCollapsed
        {
            add
            {
                this.AddEventHandler("NodeCollapsed", value);
            }
            remove
            {
                this.RemoveEventHandler("NodeCollapsed", value);
            }
        }
        

        /// <summary>
        /// Occurs on the server if a node in the TreeView control changes its check status.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs on the server if a node in the TreeView control changes its check status.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler NodeCheckChanged
        {
            add
            {
                this.AddEventHandler("NodeCheckChanged", value);
            }
            remove
            {
                this.RemoveEventHandler("NodeCheckChanged", value);
            }
        }
        

        /// <summary>
        /// Occurs on the server if a node in the TreeView control has been selected
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs on the server if a node in the TreeView control has been selected")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler SelectedNodesChanged
        {
            add
            {
                this.AddEventHandler("SelectedNodesChanged", value);
            }
            remove
            {
                this.RemoveEventHandler("SelectedNodesChanged", value);
            }
        }
        

        /// <summary>
        /// Occurs on the server if a node in the TreeView control has been clicked.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs on the server if a node in the TreeView control has been clicked.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler NodeClicked
        {
            add
            {
                this.AddEventHandler("NodeClicked", value);
            }
            remove
            {
                this.RemoveEventHandler("NodeClicked", value);
            }
        }
        

        /// <summary>
        /// Occurs on the server when a node's Text property is changed.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs on the server when a node Text property is changed.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler NodeTextChanged
        {
            add
            {
                this.AddEventHandler("NodeTextChanged", value);
            }
            remove
            {
                this.RemoveEventHandler("NodeTextChanged", value);
            }
        }
        

        /// <summary>
        /// Occurs after a node is data bound.
        /// </summary>
        [System.ComponentModel.Category("Action")]
        [System.ComponentModel.Description("Occurs after a node is data bound.")]
        [System.ComponentModel.Browsable(true)] 
        public event C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler NodeDataBound
        {
            add
            {
                this.AddEventHandler("NodeDataBound", value);
            }
            remove
            {
                this.RemoveEventHandler("NodeDataBound", value);
            }
        }
        

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
