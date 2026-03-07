Namespace Gizmox.WebGUI.Forms.CompanionKit.ComponentOneSampleAppsVB

    Partial Class C1TreeViewWrapper

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
                Return GetType(C1.Web.Wijmo.Controls.C1TreeView.C1TreeView)
            End Get
        End Property

        ''' <summary>
        ''' Get hosted control typed instance
        ''' </summary>
        Protected ReadOnly Property HostedC1TreeView As C1.Web.Wijmo.Controls.C1TreeView.C1TreeView
            Get
                Return CType(Me.HostedControl, C1.Web.Wijmo.Controls.C1TreeView.C1TreeView)
            End Get
        End Property


        ''' <summary>
        ''' Allow to TreeView nodes to perform drag .
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Allow to TreeView nodes to perform drag .")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property HostedAllowDrag() As System.Boolean
            Get
                Return CType(Me.GetProperty("AllowDrag"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AllowDrag", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Allow to TreeView nodes to perform drag . should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AllowDrag property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHostedAllowDrag() As Boolean
            Return Me.ShouldSerialize("AllowDrag")
        End Function


        ''' <summary>
        ''' Resets the Allow to TreeView nodes to perform drag . property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AllowDrag property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetHostedAllowDrag()
            Me.Reset("AllowDrag")
        End Sub


        ''' <summary>
        ''' Allow to TreeView nodes to perform drop .
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Allow to TreeView nodes to perform drop .")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property HostedAllowDrop() As System.Boolean
            Get
                Return CType(Me.GetProperty("AllowDrop"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AllowDrop", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Allow to TreeView nodes to perform drop . should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AllowDrop property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeHostedAllowDrop() As Boolean
            Return Me.ShouldSerialize("AllowDrop")
        End Function


        ''' <summary>
        ''' Resets the Allow to TreeView nodes to perform drop . property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AllowDrop property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetHostedAllowDrop()
            Me.Reset("AllowDrop")
        End Sub


        ''' <summary>
        ''' Allow nodes to be edited at run time.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Allow nodes to be edited at run time.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AllowEdit() As System.Boolean
            Get
                Return CType(Me.GetProperty("AllowEdit"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AllowEdit", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Allow nodes to be edited at run time. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AllowEdit property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAllowEdit() As Boolean
            Return Me.ShouldSerialize("AllowEdit")
        End Function


        ''' <summary>
        ''' Resets the Allow nodes to be edited at run time. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AllowEdit property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAllowEdit()
            Me.Reset("AllowEdit")
        End Sub


        ''' <summary>
        ''' Allow nodes to be sorted at run time.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Allow nodes to be sorted at run time.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AllowSorting() As System.Boolean
            Get
                Return CType(Me.GetProperty("AllowSorting"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AllowSorting", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Allow nodes to be sorted at run time. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AllowSorting property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAllowSorting() As Boolean
            Return Me.ShouldSerialize("AllowSorting")
        End Function


        ''' <summary>
        ''' Resets the Allow nodes to be sorted at run time. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AllowSorting property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAllowSorting()
            Me.Reset("AllowSorting")
        End Sub


        ''' <summary>
        ''' Allow TriState of CheckBox
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Allow TriState of CheckBox")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AllowTriState() As System.Boolean
            Get
                Return CType(Me.GetProperty("AllowTriState"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AllowTriState", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Allow TriState of CheckBox should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AllowTriState property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAllowTriState() As Boolean
            Return Me.ShouldSerialize("AllowTriState")
        End Function


        ''' <summary>
        ''' Resets the Allow TriState of CheckBox property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AllowTriState property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAllowTriState()
            Me.Reset("AllowTriState")
        End Sub


        ''' <summary>
        ''' Allow sub nodes to be checked on parent node check.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Allow sub nodes to be checked on parent node check.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AutoCheckNodes() As System.Boolean
            Get
                Return CType(Me.GetProperty("AutoCheckNodes"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AutoCheckNodes", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Allow sub nodes to be checked on parent node check. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AutoCheckNodes property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAutoCheckNodes() As Boolean
            Return Me.ShouldSerialize("AutoCheckNodes")
        End Function


        ''' <summary>
        ''' Resets the Allow sub nodes to be checked on parent node check. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AutoCheckNodes property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAutoCheckNodes()
            Me.Reset("AutoCheckNodes")
        End Sub


        ''' <summary>
        ''' If this option is set to true, expanded node will be collapsed if other node is expanded.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("If this option is set to true, expanded node will be collapsed if other node is expanded.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AutoCollapse() As System.Boolean
            Get
                Return CType(Me.GetProperty("AutoCollapse"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AutoCollapse", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if If this option is set to true, expanded node will be collapsed if other node is expanded. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AutoCollapse property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAutoCollapse() As Boolean
            Return Me.ShouldSerialize("AutoCollapse")
        End Function


        ''' <summary>
        ''' Resets the If this option is set to true, expanded node will be collapsed if other node is expanded. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AutoCollapse property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAutoCollapse()
            Me.Reset("AutoCollapse")
        End Sub


        ''' <summary>
        ''' Allow nodes to use hover for Expand or Collapse elements.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Allow nodes to use hover for Expand or Collapse elements.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ExpandCollapseHoverUsed() As System.Boolean
            Get
                Return CType(Me.GetProperty("ExpandCollapseHoverUsed"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("ExpandCollapseHoverUsed", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Allow nodes to use hover for Expand or Collapse elements. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ExpandCollapseHoverUsed property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeExpandCollapseHoverUsed() As Boolean
            Return Me.ShouldSerialize("ExpandCollapseHoverUsed")
        End Function


        ''' <summary>
        ''' Resets the Allow nodes to use hover for Expand or Collapse elements. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ExpandCollapseHoverUsed property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetExpandCollapseHoverUsed()
            Me.Reset("ExpandCollapseHoverUsed")
        End Sub


        ''' <summary>
        ''' Allow the check box to be shown on the nodes.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Allow the check box to be shown on the nodes.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ShowCheckBoxes() As System.Boolean
            Get
                Return CType(Me.GetProperty("ShowCheckBoxes"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("ShowCheckBoxes", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Allow the check box to be shown on the nodes. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ShowCheckBoxes property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeShowCheckBoxes() As Boolean
            Return Me.ShouldSerialize("ShowCheckBoxes")
        End Function


        ''' <summary>
        ''' Resets the Allow the check box to be shown on the nodes. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ShowCheckBoxes property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetShowCheckBoxes()
            Me.Reset("ShowCheckBoxes")
        End Sub


        ''' <summary>
        ''' Allow nodes to be expanded or collapsed.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Allow nodes to be expanded or collapsed.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ShowExpandCollapse() As System.Boolean
            Get
                Return CType(Me.GetProperty("ShowExpandCollapse"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("ShowExpandCollapse", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Allow nodes to be expanded or collapsed. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ShowExpandCollapse property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeShowExpandCollapse() As Boolean
            Return Me.ShouldSerialize("ShowExpandCollapse")
        End Function


        ''' <summary>
        ''' Resets the Allow nodes to be expanded or collapsed. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ShowExpandCollapse property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetShowExpandCollapse()
            Me.Reset("ShowExpandCollapse")
        End Sub


        ''' <summary>
        ''' Gets or sets the animation effect when the node is expanded.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Gets or sets the animation effect when the node is expanded.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public Property ExpandAnimation() As C1.Web.Wijmo.Controls.Animation
            Get
                Return CType(Me.GetProperty("ExpandAnimation"), C1.Web.Wijmo.Controls.Animation)
            End Get
            Set(value As C1.Web.Wijmo.Controls.Animation)
                Me.SetProperty("ExpandAnimation", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets the animation effect when the node is expanded. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ExpandAnimation property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeExpandAnimation() As Boolean
            Return Me.ShouldSerialize("ExpandAnimation")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets the animation effect when the node is expanded. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ExpandAnimation property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetExpandAnimation()
            Me.Reset("ExpandAnimation")
        End Sub


        ''' <summary>
        ''' Gets or sets the animation effect when the node is collapsed.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Gets or sets the animation effect when the node is collapsed.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public Property CollapseAnimation() As C1.Web.Wijmo.Controls.Animation
            Get
                Return CType(Me.GetProperty("CollapseAnimation"), C1.Web.Wijmo.Controls.Animation)
            End Get
            Set(value As C1.Web.Wijmo.Controls.Animation)
                Me.SetProperty("CollapseAnimation", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets the animation effect when the node is collapsed. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the CollapseAnimation property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeCollapseAnimation() As Boolean
            Return Me.ShouldSerialize("CollapseAnimation")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets the animation effect when the node is collapsed. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the CollapseAnimation property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetCollapseAnimation()
            Me.Reset("CollapseAnimation")
        End Sub


        ''' <summary>
        ''' Expand delay in milliseconds before child nodes expand.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Expand delay in milliseconds before child nodes expand.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property ExpandDelay() As System.Int32
            Get
                Return CType(Me.GetProperty("ExpandDelay"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("ExpandDelay", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Expand delay in milliseconds before child nodes expand. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the ExpandDelay property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeExpandDelay() As Boolean
            Return Me.ShouldSerialize("ExpandDelay")
        End Function


        ''' <summary>
        ''' Resets the Expand delay in milliseconds before child nodes expand. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the ExpandDelay property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetExpandDelay()
            Me.Reset("ExpandDelay")
        End Sub


        ''' <summary>
        ''' Collapse delay in milliseconds before child nodes collapse.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Options")> _
        <System.ComponentModel.Description("Collapse delay in milliseconds before child nodes collapse.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property CollapseDelay() As System.Int32
            Get
                Return CType(Me.GetProperty("CollapseDelay"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("CollapseDelay", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Collapse delay in milliseconds before child nodes collapse. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the CollapseDelay property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeCollapseDelay() As Boolean
            Return Me.ShouldSerialize("CollapseDelay")
        End Function


        ''' <summary>
        ''' Resets the Collapse delay in milliseconds before child nodes collapse. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the CollapseDelay property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetCollapseDelay()
            Me.Reset("CollapseDelay")
        End Sub


        ''' <summary>
        ''' If specified, the OnClientNodeExpanded client-side event handler is called after a TreeViewNode has been expanded.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("If specified, the OnClientNodeExpanded client-side event handler is called after a TreeViewNode has been expanded.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientNodeExpanded() As System.String
            Get
                Return CType(Me.GetProperty("OnClientNodeExpanded"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientNodeExpanded", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if If specified, the OnClientNodeExpanded client-side event handler is called after a TreeViewNode has been expanded. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientNodeExpanded property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientNodeExpanded() As Boolean
            Return Me.ShouldSerialize("OnClientNodeExpanded")
        End Function


        ''' <summary>
        ''' Resets the If specified, the OnClientNodeExpanded client-side event handler is called after a TreeViewNode has been expanded. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientNodeExpanded property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientNodeExpanded()
            Me.Reset("OnClientNodeExpanded")
        End Sub


        ''' <summary>
        ''' If specified, the OnClientNodeCollapsed client-side event handler is called after a TreeViewNode has been collapsed.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("If specified, the OnClientNodeCollapsed client-side event handler is called after a TreeViewNode has been collapsed.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientNodeCollapsed() As System.String
            Get
                Return CType(Me.GetProperty("OnClientNodeCollapsed"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientNodeCollapsed", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if If specified, the OnClientNodeCollapsed client-side event handler is called after a TreeViewNode has been collapsed. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientNodeCollapsed property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientNodeCollapsed() As Boolean
            Return Me.ShouldSerialize("OnClientNodeCollapsed")
        End Function


        ''' <summary>
        ''' Resets the If specified, the OnClientNodeCollapsed client-side event handler is called after a TreeViewNode has been collapsed. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientNodeCollapsed property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientNodeCollapsed()
            Me.Reset("OnClientNodeCollapsed")
        End Sub


        ''' <summary>
        ''' If specified, the OnClientNodeDragStarted client-side event handler is called before drag is started.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("If specified, the OnClientNodeDragStarted client-side event handler is called before drag is started.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientNodeDragStarted() As System.String
            Get
                Return CType(Me.GetProperty("OnClientNodeDragStarted"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientNodeDragStarted", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if If specified, the OnClientNodeDragStarted client-side event handler is called before drag is started. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientNodeDragStarted property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientNodeDragStarted() As Boolean
            Return Me.ShouldSerialize("OnClientNodeDragStarted")
        End Function


        ''' <summary>
        ''' Resets the If specified, the OnClientNodeDragStarted client-side event handler is called before drag is started. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientNodeDragStarted property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientNodeDragStarted()
            Me.Reset("OnClientNodeDragStarted")
        End Sub


        ''' <summary>
        ''' If specified, the OnClientNodeDragging client-side event handler is called if the user moves the mouse while dragging the node.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("If specified, the OnClientNodeDragging client-side event handler is called if the user moves the mouse while dragging the node.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientNodeDragging() As System.String
            Get
                Return CType(Me.GetProperty("OnClientNodeDragging"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientNodeDragging", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if If specified, the OnClientNodeDragging client-side event handler is called if the user moves the mouse while dragging the node. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientNodeDragging property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientNodeDragging() As Boolean
            Return Me.ShouldSerialize("OnClientNodeDragging")
        End Function


        ''' <summary>
        ''' Resets the If specified, the OnClientNodeDragging client-side event handler is called if the user moves the mouse while dragging the node. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientNodeDragging property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientNodeDragging()
            Me.Reset("OnClientNodeDragging")
        End Sub


        ''' <summary>
        ''' If specified, the OnClientNodeDropped client-side event handler is called before a TreeViewNode has been dropped by user.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("If specified, the OnClientNodeDropped client-side event handler is called before a TreeViewNode has been dropped by user.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientNodeDropped() As System.String
            Get
                Return CType(Me.GetProperty("OnClientNodeDropped"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientNodeDropped", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if If specified, the OnClientNodeDropped client-side event handler is called before a TreeViewNode has been dropped by user. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientNodeDropped property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientNodeDropped() As Boolean
            Return Me.ShouldSerialize("OnClientNodeDropped")
        End Function


        ''' <summary>
        ''' Resets the If specified, the OnClientNodeDropped client-side event handler is called before a TreeViewNode has been dropped by user. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientNodeDropped property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientNodeDropped()
            Me.Reset("OnClientNodeDropped")
        End Sub


        ''' <summary>
        ''' If specified, the OnClientNodeClicked client-side event handler is called after a TreeViewNode has been clicked.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("If specified, the OnClientNodeClicked client-side event handler is called after a TreeViewNode has been clicked.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientNodeClick() As System.String
            Get
                Return CType(Me.GetProperty("OnClientNodeClick"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientNodeClick", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if If specified, the OnClientNodeClicked client-side event handler is called after a TreeViewNode has been clicked. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientNodeClick property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientNodeClick() As Boolean
            Return Me.ShouldSerialize("OnClientNodeClick")
        End Function


        ''' <summary>
        ''' Resets the If specified, the OnClientNodeClicked client-side event handler is called after a TreeViewNode has been clicked. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientNodeClick property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientNodeClick()
            Me.Reset("OnClientNodeClick")
        End Sub


        ''' <summary>
        ''' If specified, the OnClientNodeCheckChanged client-side event handler is called after a TreeViewNode check status has been changed.(If Checkboxes are enabled)
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("If specified, the OnClientNodeCheckChanged client-side event handler is called after a TreeViewNode check status has been changed.(If Checkboxes are enabled)")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientNodeCheckChanged() As System.String
            Get
                Return CType(Me.GetProperty("OnClientNodeCheckChanged"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientNodeCheckChanged", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if If specified, the OnClientNodeCheckChanged client-side event handler is called after a TreeViewNode check status has been changed.(If Checkboxes are enabled) should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientNodeCheckChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientNodeCheckChanged() As Boolean
            Return Me.ShouldSerialize("OnClientNodeCheckChanged")
        End Function


        ''' <summary>
        ''' Resets the If specified, the OnClientNodeCheckChanged client-side event handler is called after a TreeViewNode check status has been changed.(If Checkboxes are enabled) property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientNodeCheckChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientNodeCheckChanged()
            Me.Reset("OnClientNodeCheckChanged")
        End Sub


        ''' <summary>
        ''' If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer over of the node.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer over of the node.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientNodeMouseOver() As System.String
            Get
                Return CType(Me.GetProperty("OnClientNodeMouseOver"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientNodeMouseOver", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer over of the node. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientNodeMouseOver property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientNodeMouseOver() As Boolean
            Return Me.ShouldSerialize("OnClientNodeMouseOver")
        End Function


        ''' <summary>
        ''' Resets the If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer over of the node. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientNodeMouseOver property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientNodeMouseOver()
            Me.Reset("OnClientNodeMouseOver")
        End Sub


        ''' <summary>
        ''' If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer out of the node.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer out of the node.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientNodeMouseOut() As System.String
            Get
                Return CType(Me.GetProperty("OnClientNodeMouseOut"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientNodeMouseOut", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer out of the node. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientNodeMouseOut property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientNodeMouseOut() As Boolean
            Return Me.ShouldSerialize("OnClientNodeMouseOut")
        End Function


        ''' <summary>
        ''' Resets the If specified, the OnClientNodeMouseOut client-side event handler is called if the user moves the mouse pointer out of the node. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientNodeMouseOut property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientNodeMouseOut()
            Me.Reset("OnClientNodeMouseOut")
        End Sub


        ''' <summary>
        ''' If specified, the OnClientNodeTextChanged client-side event handler is called after a TreeViewNode's has been edited.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("If specified, the OnClientNodeTextChanged client-side event handler is called after a TreeViewNode's has been edited.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientNodeTextChanged() As System.String
            Get
                Return CType(Me.GetProperty("OnClientNodeTextChanged"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientNodeTextChanged", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if If specified, the OnClientNodeTextChanged client-side event handler is called after a TreeViewNode's has been edited. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientNodeTextChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientNodeTextChanged() As Boolean
            Return Me.ShouldSerialize("OnClientNodeTextChanged")
        End Function


        ''' <summary>
        ''' Resets the If specified, the OnClientNodeTextChanged client-side event handler is called after a TreeViewNode's has been edited. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientNodeTextChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientNodeTextChanged()
            Me.Reset("OnClientNodeTextChanged")
        End Sub


        ''' <summary>
        ''' If specified, the OnClientSelectedNodesChanged client-side event handler is called after a TreeViewNode has been selected.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Client Events")> _
        <System.ComponentModel.Description("If specified, the OnClientSelectedNodesChanged client-side event handler is called after a TreeViewNode has been selected.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property OnClientSelectedNodeChanged() As System.String
            Get
                Return CType(Me.GetProperty("OnClientSelectedNodeChanged"), System.String)
            End Get
            Set(value As System.String)
                Me.SetProperty("OnClientSelectedNodeChanged", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if If specified, the OnClientSelectedNodesChanged client-side event handler is called after a TreeViewNode has been selected. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the OnClientSelectedNodeChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeOnClientSelectedNodeChanged() As Boolean
            Return Me.ShouldSerialize("OnClientSelectedNodeChanged")
        End Function


        ''' <summary>
        ''' Resets the If specified, the OnClientSelectedNodesChanged client-side event handler is called after a TreeViewNode has been selected. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the OnClientSelectedNodeChanged property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetOnClientSelectedNodeChanged()
            Me.Reset("OnClientSelectedNodeChanged")
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Nodes As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNodeCollection
            Get
                Return CType(Me.GetProperty("Nodes"), C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNodeCollection)
            End Get
        End Property


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property Owner As C1.Web.Wijmo.Controls.C1TreeView.IC1TreeViewNodeCollectionOwner
            Get
                Return CType(Me.GetProperty("Owner"), C1.Web.Wijmo.Controls.C1TreeView.IC1TreeViewNodeCollectionOwner)
            End Get
        End Property


        ''' <summary>
        ''' The unique ID of the control within the page.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("The unique ID of the control within the page.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public ReadOnly Property UniqueID As System.String
            Get
                Return CType(Me.GetProperty("UniqueID"), System.String)
            End Get
        End Property


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property SelectedNodes As System.Collections.Generic.List(Of C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNode)
            Get
                Return CType(Me.GetProperty("SelectedNodes"), System.Collections.Generic.List(Of C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNode))
            End Get
        End Property


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property CheckedNodes As System.Collections.Generic.List(Of C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNode)
            Get
                Return CType(Me.GetProperty("CheckedNodes"), System.Collections.Generic.List(Of C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNode))
            End Get
        End Property


        ''' <summary>
        ''' If specified, this template will be applied for all menu items that does not have other defined templates.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("If specified, this template will be applied for all menu items that does not have other defined templates.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public Property NodesTemplate() As System.Web.UI.ITemplate
            Get
                Return CType(Me.GetProperty("NodesTemplate"), System.Web.UI.ITemplate)
            End Get
            Set(value As System.Web.UI.ITemplate)
                Me.SetProperty("NodesTemplate", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if If specified, this template will be applied for all menu items that does not have other defined templates. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the NodesTemplate property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeNodesTemplate() As Boolean
            Return Me.ShouldSerialize("NodesTemplate")
        End Function


        ''' <summary>
        ''' Resets the If specified, this template will be applied for all menu items that does not have other defined templates. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the NodesTemplate property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetNodesTemplate()
            Me.Reset("NodesTemplate")
        End Sub


        ''' <summary>
        ''' Sets or retrieves a value that indicates whether or not the control posts back to the server each time a user interacts with the control.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Sets or retrieves a value that indicates whether or not the control posts back to the server each time a user interacts with the control.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property AutoPostBack() As System.Boolean
            Get
                Return CType(Me.GetProperty("AutoPostBack"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("AutoPostBack", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Sets or retrieves a value that indicates whether or not the control posts back to the server each time a user interacts with the control. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the AutoPostBack property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeAutoPostBack() As Boolean
            Return Me.ShouldSerialize("AutoPostBack")
        End Function


        ''' <summary>
        ''' Resets the Sets or retrieves a value that indicates whether or not the control posts back to the server each time a user interacts with the control. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the AutoPostBack property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetAutoPostBack()
            Me.Reset("AutoPostBack")
        End Sub


        ''' <summary>
        ''' Gets or sets the value that indicates whether or not Loads on demand is enabled.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Gets or sets the value that indicates whether or not Loads on demand is enabled.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property LoadOnDemand() As System.Boolean
            Get
                Return CType(Me.GetProperty("LoadOnDemand"), System.Boolean)
            End Get
            Set(value As System.Boolean)
                Me.SetProperty("LoadOnDemand", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets the value that indicates whether or not Loads on demand is enabled. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the LoadOnDemand property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeLoadOnDemand() As Boolean
            Return Me.ShouldSerialize("LoadOnDemand")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets the value that indicates whether or not Loads on demand is enabled. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the LoadOnDemand property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetLoadOnDemand()
            Me.Reset("LoadOnDemand")
        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property NodeClickedPostBackReference As System.String
            Get
                Return CType(Me.GetProperty("NodeClickedPostBackReference"), System.String)
            End Get
        End Property


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property NodeCheckChangedPostBackReference As System.String
            Get
                Return CType(Me.GetProperty("NodeCheckChangedPostBackReference"), System.String)
            End Get
        End Property


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property NodeCollapsedPostBackReference As System.String
            Get
                Return CType(Me.GetProperty("NodeCollapsedPostBackReference"), System.String)
            End Get
        End Property


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property NodeExpandedPostBackReference As System.String
            Get
                Return CType(Me.GetProperty("NodeExpandedPostBackReference"), System.String)
            End Get
        End Property


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property NodeDroppedPostBackReference As System.String
            Get
                Return CType(Me.GetProperty("NodeDroppedPostBackReference"), System.String)
            End Get
        End Property


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property NodeTextChangedPostBackReference As System.String
            Get
                Return CType(Me.GetProperty("NodeTextChangedPostBackReference"), System.String)
            End Get
        End Property


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Misc")> _
        <System.ComponentModel.Description("")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property SelectedNodesChangedPostBackReference As System.String
            Get
                Return CType(Me.GetProperty("SelectedNodesChangedPostBackReference"), System.String)
            End Get
        End Property


        ''' <summary>
        ''' Gets or sets the value that indicates DataBind start level.
        ''' </summary>
        ''' <returns></returns>    
        <System.ComponentModel.Category("Behavior")> _
        <System.ComponentModel.Description("Gets or sets the value that indicates DataBind start level.")> _
        <System.ComponentModel.Browsable(True)> _
        <System.ComponentModel.ReadOnly(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Property DataBindStartLevel() As System.Int32
            Get
                Return CType(Me.GetProperty("DataBindStartLevel"), System.Int32)
            End Get
            Set(value As System.Int32)
                Me.SetProperty("DataBindStartLevel", value)
            End Set
        End Property

        ''' <summary>
        ''' Returns a boolean indicating if Gets or sets the value that indicates DataBind start level. should be serialized.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine which is to serialize the DataBindStartLevel property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Function ShouldSerializeDataBindStartLevel() As Boolean
            Return Me.ShouldSerialize("DataBindStartLevel")
        End Function


        ''' <summary>
        ''' Resets the Gets or sets the value that indicates DataBind start level. property to its default value.
        ''' </summary>
        ''' <returns></returns> 
        ''' <remarks>This method is used in design time to determine how to reset the DataBindStartLevel property.</remarks> 
        <System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)> _
        Public Sub ResetDataBindStartLevel()
            Me.Reset("DataBindStartLevel")
        End Sub


        ''' <summary>
        ''' Data bindings for items in the control.
        ''' </summary>
        ''' <returns></returns>        
        <System.ComponentModel.Category("Data")> _
        <System.ComponentModel.Description("Data bindings for items in the control.")> _
        <System.ComponentModel.Browsable(False)> _
        <System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public ReadOnly Property HostedDataBindings As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNodeBindingCollection
            Get
                Return CType(Me.GetProperty("DataBindings"), C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewNodeBindingCollection)
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



        ''' <summary>
        ''' Occurs on the server after the node has been dropped.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs on the server after the node has been dropped.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event NodeDropped As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.AddEventHandler("NodeDropped", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.RemoveEventHandler("NodeDropped", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs)
                If (Not (Me.Events("NodeDropped")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("NodeDropped")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs on the server after the node is expanded.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs on the server after the node is expanded.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event NodeExpanded As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.AddEventHandler("NodeExpanded", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.RemoveEventHandler("NodeExpanded", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs)
                If (Not (Me.Events("NodeExpanded")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("NodeExpanded")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs on the server after the node is collapsed.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs on the server after the node is collapsed.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event NodeCollapsed As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.AddEventHandler("NodeCollapsed", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.RemoveEventHandler("NodeCollapsed", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs)
                If (Not (Me.Events("NodeCollapsed")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("NodeCollapsed")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs on the server if a node in the TreeView control changes its check status.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs on the server if a node in the TreeView control changes its check status.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event NodeCheckChanged As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.AddEventHandler("NodeCheckChanged", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.RemoveEventHandler("NodeCheckChanged", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs)
                If (Not (Me.Events("NodeCheckChanged")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("NodeCheckChanged")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs on the server if a node in the TreeView control has been selected
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs on the server if a node in the TreeView control has been selected")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event SelectedNodesChanged As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.AddEventHandler("SelectedNodesChanged", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.RemoveEventHandler("SelectedNodesChanged", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs)
                If (Not (Me.Events("SelectedNodesChanged")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("SelectedNodesChanged")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs on the server if a node in the TreeView control has been clicked.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs on the server if a node in the TreeView control has been clicked.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event NodeClicked As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.AddEventHandler("NodeClicked", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.RemoveEventHandler("NodeClicked", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs)
                If (Not (Me.Events("NodeClicked")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("NodeClicked")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs on the server when a node's Text property is changed.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs on the server when a node's Text property is changed.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event NodeTextChanged As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.AddEventHandler("NodeTextChanged", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.RemoveEventHandler("NodeTextChanged", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs)
                If (Not (Me.Events("NodeTextChanged")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("NodeTextChanged")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



        ''' <summary>
        ''' Occurs after a node is data bound.
        ''' </summary>
        <System.ComponentModel.Category("Action")> _
        <System.ComponentModel.Description("Occurs after a node is data bound.")> _
        <System.ComponentModel.Browsable(True)> _
        Public Custom Event NodeDataBound As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler

            AddHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.AddEventHandler("NodeDataBound", value)
            End AddHandler

            RemoveHandler(ByVal value As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventHandler)
                Me.RemoveEventHandler("NodeDataBound", value)
            End RemoveHandler

            RaiseEvent(ByVal sender As System.Object, ByVal e As C1.Web.Wijmo.Controls.C1TreeView.C1TreeViewEventArgs)
                If (Not (Me.Events("NodeDataBound")) Is Nothing) Then
                    Dim arrDelegate As List(Of System.Delegate) = Me.Events("NodeDataBound")
                    For Each objDelegate As System.Delegate In arrDelegate
                        objDelegate.DynamicInvoke(New Object() {sender, e})
                    Next
                End If
            End RaiseEvent

        End Event



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